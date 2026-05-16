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

        Raises:
            RuntimeError: pyserial 未安装
            serial.SerialException: 串口打开失败
        """
        if serial is None:
            raise RuntimeError("pyserial is not installed")
        # 使用极短超时: 命令模式用 read_until 覆盖, 流模式用 in_waiting+read
        self._serial = serial.Serial(
            port=port,
            baudrate=baudrate,
            bytesize=bytesize,
            parity=parity,
            stopbits=stopbits,
            timeout=0.05,  # 短超时用于流读取, 命令读取用 read_until
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

        # 查询设备单位，验证 CH-1600 身份
        try:
            unit = self.query_unit()
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

    def _send_command(self, cmd: str) -> bytes:
        """发送命令并读取响应行。

        命令以 CR (0x0D) 结尾，响应以 \\n 结尾。
        read_until 使用较长的内部超时 (1.0s) 等待完整响应。
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
            # 临时设为较长超时等待命令响应，完成后恢复短超时
            old_timeout = self._serial.timeout
            self._serial.timeout = 1.0
            try:
                line = self._serial.read_until(b"\n")
            finally:
                self._serial.timeout = old_timeout
            if self._raw_log_cb:
                try:
                    self._raw_log_cb("RX", line)
                except Exception:
                    pass
            return line

    def read_stream_data(self, timeout: float = 0.0) -> Optional[bytes]:
        """非阻塞读取可用字节（用于数据流模式）。

        不修改 serial.timeout，避免 Windows pyserial 缓冲区重置。
        返回 None 表示无可用数据。
        """
        with self._lock:
            if self._serial is None or not self._serial.is_open:
                raise ConnectionError("CH-1600 未连接")
            try:
                waiting = self._serial.in_waiting
                if waiting == 0:
                    return None
                data = self._serial.read(waiting)
                return data if data else None
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
        """启动实时数据流 (DATA?>)。"""
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
        """停止实时数据流 (DATAC>)。"""
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
