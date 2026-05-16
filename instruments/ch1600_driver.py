"""CH-1600 数字高斯计 RS-232 设备驱动

协议规格:
- 异步串行: 1 起始位 + 8 数据位 + 1 停止位, 无校验
- 命令结束符: CR (0x0D)
- 响应终止符: \\n (换行符)
- 波特率: 19200 / 57600 / 115200 (默认 115200)
- 半双工, 最大 10 命令/秒
- 实时流模式 (DATA?>) 持续发送数据帧, 不受命令速率限制

数据帧格式: #±xxxxx.xxxx/xxx/±xxxx>\\n
示例: #-12345.6789/050/+0234>\\n
  -> 磁场: -12345.6789 mT, 频率: 50 Hz, 温度: +23.4 °C
"""

from __future__ import annotations

import threading
import time as _time
from typing import Any, Callable, Dict, List, Optional, Tuple

try:
    import serial
except ImportError:
    serial = None  # type: ignore[assignment]


class CH1600Driver:
    """CH-1600 数字高斯计 RS-232 驱动。"""

    DEFAULT_BAUDRATE = 115200
    DEFAULT_BYTESIZE = 8
    DEFAULT_PARITY = "N"
    DEFAULT_STOPBITS = 1
    DEFAULT_TIMEOUT = 1.0

    def __init__(self) -> None:
        self._serial: Optional[serial.Serial] = None  # type: ignore[name-defined]
        self._lock = threading.Lock()
        self._raw_log_cb: Optional[Callable[[str, bytes], None]] = None

        # 缓存状态
        self._cached_field_mt: float = 0.0
        self._cached_freq_hz: float = 0.0
        self._cached_temp_c: float = 0.0
        self._cached_unit: str = "mT"
        self._cached_range: str = "Auto"
        self._streaming: bool = False

    # ------------------------------------------------------------------
    # properties
    # ------------------------------------------------------------------

    @property
    def is_connected(self) -> bool:
        with self._lock:
            return self._serial is not None and self._serial.is_open

    @property
    def is_streaming(self) -> bool:
        with self._lock:
            return self._streaming

    @property
    def is_panel_streaming_mode(self) -> bool:
        """设备是否处于面板实时发送模式 (此模式下 RS-232 指令不可用)。"""
        with self._lock:
            return getattr(self, '_panel_streaming_mode', False)

    @property
    def cached_field_mt(self) -> float:
        with self._lock:
            return self._cached_field_mt

    @property
    def cached_freq_hz(self) -> float:
        with self._lock:
            return self._cached_freq_hz

    @property
    def cached_temp_c(self) -> float:
        with self._lock:
            return self._cached_temp_c

    @property
    def cached_unit(self) -> str:
        with self._lock:
            return self._cached_unit

    @property
    def cached_range(self) -> str:
        with self._lock:
            return self._cached_range

    # ------------------------------------------------------------------
    # callback
    # ------------------------------------------------------------------

    def set_raw_log_callback(self, cb: Optional[Callable[[str, bytes], None]]) -> None:
        self._raw_log_cb = cb

    # ------------------------------------------------------------------
    # connection
    # ------------------------------------------------------------------

    def connect(
        self,
        port: str,
        baudrate: int = DEFAULT_BAUDRATE,
        bytesize: int = DEFAULT_BYTESIZE,
        parity: str = DEFAULT_PARITY,
        stopbits: int = DEFAULT_STOPBITS,
        timeout: float = DEFAULT_TIMEOUT,
    ) -> str:
        """打开串口并返回设备标识。

        自动检测面板实时发送模式: 连接后等待 300ms,
        若有数据帧到达则判定为面板流模式 (此模式下 RS-232 指令不可用)。
        """
        if serial is None:
            raise RuntimeError("pyserial is not installed")
        self._serial = serial.Serial(
            port=port,
            baudrate=baudrate,
            bytesize=bytesize,
            parity=parity,
            stopbits=stopbits,
            timeout=0.05,
        )
        try:
            self._serial.reset_input_buffer()
            self._serial.reset_output_buffer()
        except Exception:
            try:
                self._serial.close()
            except Exception:
                pass
            self._serial = None
            raise

        self._panel_streaming_mode = False

        # 先静默观察: 设备是否已在发送数据?
        _time.sleep(0.35)
        preview = self._read_available()
        if preview:
            # 检查是否是数据帧 (面板实时发送模式)
            frame = CH1600Driver.parse_stream_frame(preview)
            if frame is not None:
                self._panel_streaming_mode = True
                self._cached_field_mt = frame["field_mt"]
                self._cached_freq_hz = frame["freq_hz"]
                self._cached_temp_c = frame["temp_c"]
                return f"CH-1600@{port} (面板实时发送模式, 指令不可用)"

        # 正常模式: 发送 UNIT?> 查询设备身份
        try:
            unit = self.query_unit()
            if unit.startswith("#"):
                self._panel_streaming_mode = True
                idn = f"CH-1600@{port} (面板实时发送模式, 指令不可用)"
            else:
                idn = f"CH-1600@{port} (unit={unit})"
        except Exception:
            idn = f"CH-1600@{port} (unverified)"

        return idn

    def close(self) -> None:
        """关闭串口，先停止数据流。"""
        with self._lock:
            if self._serial is not None:
                try:
                    if self._streaming:
                        self._send_raw(b"DATAC>\r")
                        self._streaming = False
                except Exception:
                    pass
                try:
                    self._serial.close()
                except Exception:
                    pass
                self._serial = None

    # ------------------------------------------------------------------
    # scan
    # ------------------------------------------------------------------

    @staticmethod
    def scan_ports(
        baudrate: int = DEFAULT_BAUDRATE,
        timeout: float = 0.5,
    ) -> List[Tuple[str, str]]:
        """扫描所有串口，识别 CH-1600 设备。

        策略: 打开每个端口，发送 UNIT?>，检查响应是否为已知单位字符串。
        """
        if serial is None:
            raise RuntimeError("pyserial is not installed")
        from serial.tools import list_ports as _list_ports

        valid_units = {"mT", "Gauss", "A/m", "oe"}
        results: List[Tuple[str, str]] = []
        for p in _list_ports.comports():
            port = p.device
            try:
                with serial.Serial(
                    port=port,
                    baudrate=baudrate,
                    bytesize=8,
                    parity="N",
                    stopbits=1,
                    timeout=timeout,
                ) as s:
                    s.reset_input_buffer()
                    s.reset_output_buffer()
                    s.write(b"UNIT?>\r")
                    resp = s.read_until(b"\n").decode("ascii", errors="ignore").strip()
                    if resp in valid_units:
                        label = f"CH-1600 [unit={resp}]"
                    else:
                        # 可能是 CH-1600 但响应了其他内容
                        label = "CH-1600? (unverified)"
                        if p.serial_number:
                            label += f" [USB SN:{p.serial_number}]"
                    results.append((port, label))
            except Exception:
                pass
        return results

    # ------------------------------------------------------------------
    # low-level I/O
    # ------------------------------------------------------------------

    def _send_raw(self, data: bytes) -> None:
        """原始字节写入（需在 _lock 内调用）。"""
        if self._serial is None or not self._serial.is_open:
            raise ConnectionError("CH-1600 未连接")
        self._serial.write(data)
        if self._raw_log_cb:
            try:
                self._raw_log_cb("TX", data)
            except Exception:
                pass

    def _read_available(self) -> bytes:
        """读取串口缓冲区中所有可用字节 (无阻塞)。需在 _lock 内调用。"""
        if self._serial is None or not self._serial.is_open:
            return b""
        n = self._serial.in_waiting
        if n == 0:
            return b""
        data = self._serial.read(n)
        return data if data else b""

    def _send_command(self, cmd: str) -> bytes:
        """发送命令并读取响应。

        命令以 CR (0x0D) 结尾。先发送命令, 等待设备处理,
        然后读取所有可用字节作为响应。
        兼容有/无 \\n 终止符的响应格式。
        """
        with self._lock:
            if self._serial is None or not self._serial.is_open:
                raise ConnectionError("CH-1600 未连接")
            tx = (cmd + "\r").encode("ascii")
            self._serial.write(tx)
            if self._raw_log_cb:
                try:
                    self._raw_log_cb("TX", tx)
                except Exception:
                    pass
            # 等待设备处理命令 (150ms) + 响应到达 (最多再等 250ms)
            _time.sleep(0.15)
            # 分两轮读取, 确保捕获完整响应
            data = self._read_available()
            if len(data) == 0:
                _time.sleep(0.25)
                data = self._read_available()
            if self._raw_log_cb and data:
                try:
                    self._raw_log_cb("RX", data)
                except Exception:
                    pass
            return data

    def read_stream_data(self) -> Optional[bytes]:
        """非阻塞读取可用字节（用于数据流模式）。返回 None 表示无可用数据。"""
        with self._lock:
            if self._serial is None or not self._serial.is_open:
                raise ConnectionError("CH-1600 未连接")
            try:
                return self._read_available() or None
            except Exception:
                return None

    # ------------------------------------------------------------------
    # 数据帧解析 (static, 无锁)
    # ------------------------------------------------------------------

    @staticmethod
    def parse_stream_frame(line: bytes) -> Optional[Dict[str, float]]:
        """解析单帧 DATA?> 流数据。

        格式: #±xxxxx.xxxx/xxx/±xxxx>\\n
        示例: b'#-12345.6789/050/+0234>\\n'

        Returns:
            {"field_mt": float, "freq_hz": float, "temp_c": float} 或 None
        """
        try:
            text = line.decode("ascii", errors="ignore").strip()
            if not text.startswith("#"):
                return None
            # 移除末尾的 > 和空白
            core = text[1:].rstrip(">").strip()
            parts = core.split("/")
            if len(parts) != 3:
                return None
            field_mt = float(parts[0])
            freq_hz = float(parts[1])
            temp_c = float(parts[2]) / 10.0
            return {"field_mt": field_mt, "freq_hz": freq_hz, "temp_c": temp_c}
        except (ValueError, UnicodeDecodeError):
            return None

    # ------------------------------------------------------------------
    # 数据流控制
    # ------------------------------------------------------------------

    def start_streaming(self) -> None:
        """启动实时数据流 (DATA?> 或直接读取面板模式流)。"""
        if self._panel_streaming_mode:
            # 面板模式: 设备已在发送数据, 直接开始读取
            with self._lock:
                self._streaming = True
            return
        self._send_command("DATA?")
        # 排空启动时的残留缓冲数据，需在锁内访问 _serial
        with self._lock:
            self._streaming = True
            try:
                if self._serial is not None and self._serial.is_open:
                    self._serial.read(self._serial.in_waiting)
            except Exception:
                pass

    def stop_streaming(self) -> None:
        """停止实时数据流 (DATAC> 或仅标记停止)。"""
        if self._panel_streaming_mode:
            # 面板模式: 不发送 DATAC> (会被忽略), 仅标记停止
            with self._lock:
                self._streaming = False
            return
        try:
            self._send_command("DATAC")
        except Exception:
            pass
        with self._lock:
            self._streaming = False

    # ------------------------------------------------------------------
    # 查询命令
    # ------------------------------------------------------------------

    def query_unit(self) -> str:
        """查询当前单位。返回: "mT" | "Gauss" | "A/m" | "oe" """
        raw = self._send_command("UNIT?")
        unit = raw.decode("ascii", errors="ignore").strip()
        self._cached_unit = unit
        return unit

    def query_range(self) -> str:
        """查询当前量程。返回: "30" | "300" | "3k" | "Auto" """
        raw = self._send_command("RANGE?")
        rng = raw.decode("ascii", errors="ignore").strip()
        self._cached_range = rng
        return rng

    def query_up_threshold(self) -> float:
        """查询上限阈值 (mT)。"""
        raw = self._send_command("UPHRES?")
        try:
            return float(raw.decode("ascii", errors="ignore").strip())
        except ValueError:
            return 0.0

    def query_low_threshold(self) -> float:
        """查询下限阈值 (mT)。"""
        raw = self._send_command("LOWTHRES?")
        try:
            return float(raw.decode("ascii", errors="ignore").strip())
        except ValueError:
            return 0.0

    def query_data_once(self) -> Optional[Dict[str, float]]:
        """单次查询数据 (DATAS>)。返回完整帧或 None。"""
        raw = self._send_command("DATAS")
        text = raw.decode("ascii", errors="ignore").strip()
        # 格式: "ACK" + 实时数据
        if text.startswith("ACK"):
            text = text[3:]
        return CH1600Driver.parse_stream_frame(text.encode("ascii"))

    def query_state(self) -> Dict[str, Any]:
        """查询完整状态快照。"""
        try:
            unit = self.query_unit()
        except Exception:
            unit = "?"
        try:
            rng = self.query_range()
        except Exception:
            rng = "?"
        try:
            up = self.query_up_threshold()
        except Exception:
            up = 0.0
        try:
            low = self.query_low_threshold()
        except Exception:
            low = 0.0
        return {
            "unit": unit,
            "range": rng,
            "up_threshold": up,
            "low_threshold": low,
            "streaming": self._streaming,
            "connected": self.is_connected,
        }

    # ------------------------------------------------------------------
    # 控制命令
    # ------------------------------------------------------------------

    def set_unit_cycle(self) -> None:
        """切换单位（循环: mT→Gauss→A/m→Oe→mT...）"""
        self._send_command("UNITSET")

    def set_range_cycle(self) -> None:
        """切换量程（循环: 30mT→300mT→3T→Auto→30mT...）"""
        self._send_command("RANGESET")

    def zero(self) -> None:
        """归零：将当前磁场读数设为零点。"""
        self._send_command("ZERO")

    def show_max_min(self) -> None:
        """显示最大/最小值。"""
        self._send_command("MAX_MIN")

    def lock_panel(self) -> None:
        """锁定前面板按键。"""
        self._send_command("LOCK")

    def unlock_panel(self) -> None:
        """解锁前面板按键。"""
        self._send_command("UNLOCK")

    def set_up_threshold(self, value: float) -> None:
        """设置上限阈值 (mT)。"""
        sign = "+" if value >= 0 else ""
        self._send_command(f"UPTHRES{sign}{value:.2f}")

    def set_low_threshold(self, value: float) -> None:
        """设置下限阈值 (mT)。"""
        sign = "+" if value >= 0 else ""
        self._send_command(f"LOWTHRES{sign}{value:.2f}")

    def rela(self) -> str:
        """清零后恢复原显示值。返回响应字符串。"""
        raw = self._send_command("RELA")
        return raw.decode("ascii", errors="ignore").strip()
