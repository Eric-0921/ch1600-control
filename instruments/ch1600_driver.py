"""CH-1600 数字高斯计 RS-232 设备驱动

协议规格:
- 异步串行: 1 起始位 + 8 数据位 + 1 停止位, 无校验
- 命令: 原厂软件直接发送 ASCII 命令体（例如 DATA?>、DATAC>），真机实测不接受追加 CR
- 响应终止符: \\n (换行符)
- 波特率: 19200 / 57600 / 115200 (默认 115200)
- 半双工, 最大 10 命令/秒
- 实时流模式 (DATA?>) 持续发送数据帧, 不受命令速率限制

数据帧格式: #±xxxxx.xxxx/xxx/±xxxx>\\n
示例: #-12345.6789/050/+0234>\\n
  -> 磁场: -12345.6789 mT, 频率: 50 Hz, 温度: +23.4 °C
"""

from __future__ import annotations

import math
import threading
import time as _time
from typing import Any, Callable, Dict, List, Optional, Tuple

from data.device_capabilities import DEVICE_CAPABILITIES

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

    SPECIAL_PREFIXES = (
        "HSTDC:", "HSTACL:", "HSTACH:",
        "HSEDC:", "HSEACL:", "HSEACH:",
        "UHSDC:", "UHSACL:", "UHSACH:",
    )
    _SPECIAL_PREFIX_SCALE_MT = {
        "HSTDC:": 0.1,
        "HSTACL:": 0.1,
        "HSTACH:": 0.1,
        "HSEDC:": 0.1,
        "HSEACL:": 0.1,
        "HSEACH:": 0.1,
        "UHSDC:": 0.0001,
        "UHSACL:": 0.0001,
        "UHSACH:": 0.0001,
    }

    DEVICE_MODEL_TABLE: Dict[str, Dict[str, Any]] = {
        key: {
            "label": cap.label,
            "dimension": cap.measurement_dimension,
            "has_freq": cap.has_freq,
            "has_temp": cap.has_temp,
            "unit": cap.field_unit,
            "available_units": list(cap.available_units),
        }
        for key, cap in DEVICE_CAPABILITIES.items()
    }

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

        注意: 设备不支持硬件握手, 打开串口后立即拉低 DTR/RTS,
        避免 CH340 等 USB 转串口芯片的 DTR 跳变导致设备复位。
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
            dsrdtr=False,
            rtscts=False,
            xonxoff=False,
        )
        # 拉低 DTR/RTS, 防止 Windows 默认拉高导致设备复位
        self._serial.dtr = False
        self._serial.rts = False
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
            frame = CH1600Driver.parse_first_stream_frame(preview)
            if frame is not None:
                self._panel_streaming_mode = True
                self._cached_field_mt = frame["field_mt"]
                self._cached_freq_hz = frame["freq_hz"]
                self._cached_temp_c = frame["temp_c"]
                return f"CH-1600@{port} (面板实时发送模式, 指令不可用)"

        # 正常模式: 优先发送 UNIT?> 查询设备身份；部分 CH-1600 固件不响应
        # UNIT?>，此时退回到原厂软件使用的 DATA?> 短采样帧验证。
        try:
            unit = self.query_unit()
            if unit.startswith("#"):
                self._panel_streaming_mode = True
                idn = f"CH-1600@{port} (面板实时发送模式, 指令不可用)"
            elif unit in {"mT", "Gauss", "A/m", "Oe", "oe"}:
                idn = f"CH-1600@{port} (unit={unit})"
            else:
                frame = self._probe_data_stream()
                if frame is None:
                    raise RuntimeError(f"未识别的 UNIT?> 响应: {unit!r}")
                self._cached_field_mt = frame["field_mt"]
                self._cached_freq_hz = frame["freq_hz"]
                self._cached_temp_c = frame["temp_c"]
                idn = f"CH-1600@{port} (DATA?> verified)"
        except Exception as exc:
            frame = None
            if "未识别的 UNIT?>" not in str(exc):
                try:
                    frame = self._probe_data_stream()
                except Exception:
                    frame = None
            if frame is not None:
                self._cached_field_mt = frame["field_mt"]
                self._cached_freq_hz = frame["freq_hz"]
                self._cached_temp_c = frame["temp_c"]
                return f"CH-1600@{port} (DATA?> verified)"
            try:
                self.close()
            finally:
                raise RuntimeError(f"无法验证 CH-1600 设备身份: {exc}") from exc

        return idn

    def _probe_data_stream(self, duration_s: float = 1.2) -> Optional[Dict[str, float]]:
        """用原厂 DATA?> 短采样验证设备身份，并确保最后发送 DATAC> 停止。

        有些 CH-1600 固件不响应 UNIT?>，但会响应 DATA?>。GUI 连接阶段
        需要一个不依赖 UNIT?> 的验证路径，否则真实设备会被误判为未连接。
        """
        with self._lock:
            if self._serial is None or not self._serial.is_open:
                return None
            data = b""
            try:
                self._serial.reset_input_buffer()
                self._serial.write(b"DATAC>")
                _time.sleep(0.2)
                self._read_available()

                self._serial.write(b"DATA?>")
                deadline = _time.monotonic() + duration_s
                while _time.monotonic() < deadline:
                    chunk = self._read_available()
                    if chunk:
                        data += chunk
                        frame = CH1600Driver.parse_first_stream_frame(data)
                        if frame is not None:
                            return frame
                    _time.sleep(0.03)
                return None
            finally:
                try:
                    self._serial.write(b"DATAC>")
                    _time.sleep(0.1)
                    self._read_available()
                except Exception:
                    pass

    def close(self) -> None:
        """关闭串口，先停止数据流。"""
        with self._lock:
            if self._serial is not None:
                try:
                    if self._streaming:
                        self._send_raw(b"DATAC>")
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

        策略:
        1. 打开端口后先静默观察 ~0.4s，若收到自动数据帧则判定为面板实时发送模式。
        2. 否则发送 UNIT?>，检查响应是否包含已知单位字符串（兼容响应与数据帧粘连的情况）。
        """
        if serial is None:
            raise RuntimeError("pyserial is not installed")
        from serial.tools import list_ports as _list_ports

        valid_units = {"mT", "Gauss", "A/m", "Oe", "oe"}
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
                    dsrdtr=False,
                    rtscts=False,
                    xonxoff=False,
                ) as s:
                    # 拉低 DTR/RTS, 防止 Windows 默认拉高导致设备复位
                    s.dtr = False
                    s.rts = False
                    s.reset_input_buffer()
                    s.reset_output_buffer()

                    # 步骤1: 静默观察面板实时发送模式
                    _time.sleep(0.4)
                    preview = b""
                    n = s.in_waiting
                    if n:
                        preview = s.read(n)
                    frame = CH1600Driver.parse_first_stream_frame(preview)
                    if frame is not None:
                        results.append((port, "CH-1600 [面板实时发送模式 / Panel Streaming]"))
                        continue

                    # 步骤2: 发送 UNIT?> 验证
                    s.write(b"UNIT?>")
                    resp = s.read_until(b"\n").decode("ascii", errors="ignore").strip()
                    # 精确匹配或前缀匹配（处理响应与数据帧粘连，如 "mT #-0003.5144/..."）
                    matched_unit = None
                    if resp in valid_units:
                        matched_unit = resp
                    else:
                        for unit in valid_units:
                            if resp.startswith(unit) or (" " in resp and resp.split()[0] == unit):
                                matched_unit = unit
                                break
                    if matched_unit:
                        results.append((port, f"CH-1600 [unit={matched_unit}]"))
                        continue

                    # 步骤3: 部分固件不响应 UNIT?>，使用 DATA?> 短采样兜底。
                    try:
                        s.reset_input_buffer()
                        s.write(b"DATAC>")
                        _time.sleep(0.2)
                        if s.in_waiting:
                            s.read(s.in_waiting)
                        s.write(b"DATA?>")
                        data = b""
                        deadline = _time.monotonic() + 1.2
                        while _time.monotonic() < deadline:
                            n = s.in_waiting
                            if n:
                                data += s.read(n)
                                if CH1600Driver.parse_first_stream_frame(data) is not None:
                                    results.append((port, "CH-1600 [DATA?> verified]"))
                                    break
                            _time.sleep(0.03)
                    finally:
                        try:
                            s.write(b"DATAC>")
                        except Exception:
                            pass
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

        原厂程序直接发送命令文本，不追加 CR/LF。先发送命令，等待设备处理，
        然后读取所有可用字节作为响应。
        兼容有/无 \\n 终止符的响应格式。
        """
        with self._lock:
            if self._serial is None or not self._serial.is_open:
                raise ConnectionError("CH-1600 未连接")
            clean_cmd = cmd.strip()
            if not clean_cmd:
                raise ValueError("empty CH-1600 command")
            if not clean_cmd.endswith(">"):
                clean_cmd += ">"
            tx = clean_cmd.encode("ascii")
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
    def parse_stream_frame(line: bytes, model: str = "1d_gauss") -> Optional[Dict[str, float]]:
        """解析单帧 DATA?> 流数据。

        根据 model 分发到对应的私有解析方法，返回统一格式字典。

        Returns:
            {
                "field_x_mt": float,
                "field_y_mt": float,
                "field_z_mt": float,
                "field_total_mt": float,
                "freq_hz": float,
                "temp_c": float,
                "field_mt": float,  # 向后兼容别名
            } 或 None
        """
        try:
            text = line.decode("ascii", errors="ignore").strip()
            length = len(text)
        except (ValueError, UnicodeDecodeError):
            return None

        if model == "1d_gauss":
            return CH1600Driver._parse_1d_gauss(text, length)
        elif model == "2d_gauss":
            return CH1600Driver._parse_2d_gauss(text, length)
        elif model == "3d_gauss":
            return CH1600Driver._parse_3d_gauss(text, length)
        elif model == "fluxmeter":
            return CH1600Driver._parse_fluxmeter(text, length)
        elif model == "1d_fluxgate":
            return CH1600Driver._parse_1d_fluxgate(text, length)
        elif model == "3d_fluxgate":
            return CH1600Driver._parse_3d_fluxgate(text, length)
        else:
            return CH1600Driver._parse_1d_gauss(text, length)

    @staticmethod
    def parse_first_stream_frame(data: bytes, model: str = "1d_gauss") -> Optional[Dict[str, float]]:
        """Parse the first valid frame from a serial preview buffer.

        DataReader2 splits ``ReadExisting()`` chunks on CR/LF before analysis.
        Doing the same here avoids treating multiple already-buffered panel
        frames as one malformed frame during connection probing.
        """
        for line in data.replace(b"\r", b"\n").split(b"\n"):
            if not line.strip():
                continue
            parsed = CH1600Driver.parse_stream_frame(line, model=model)
            if parsed is not None:
                return parsed
        return None

    @staticmethod
    def _parse_1d_gauss(text: str, length: int) -> Optional[Dict[str, float]]:
        try:
            for prefix in CH1600Driver.SPECIAL_PREFIXES:
                if text.startswith(prefix):
                    parts = text.split("/")
                    if len(parts) < 4:
                        return None
                    # DataReader2 applies GuassUnit-dependent scaling to these
                    # undocumented prefixes. m1600 stores base values as mT, so
                    # use the GuassUnit==0 branch: HST/HSE raw units are 0.1 mT,
                    # UHS raw units are 0.0001 mT. Temperature is already raw °C.
                    field_x = float(parts[1]) * CH1600Driver._SPECIAL_PREFIX_SCALE_MT[prefix]
                    freq = float(parts[2])
                    temp = float(parts[3].rstrip(">"))
                    return {
                        "field_x_mt": field_x,
                        "field_y_mt": 0.0,
                        "field_z_mt": 0.0,
                        "field_total_mt": field_x,
                        "freq_hz": freq,
                        "temp_c": temp,
                        "field_mt": field_x,
                    }
            if not text.startswith("#"):
                return None
            if not text.endswith(">"):
                return None
            core = text[1:].rstrip(">").strip()
            parts = core.split("/")
            if len(parts) == 1:
                # 原厂高速 FAST2>/FASTxxx> 数据帧只有磁场值:
                # #+0000.1496>
                field_x = float(parts[0])
                return {
                    "field_x_mt": field_x,
                    "field_y_mt": 0.0,
                    "field_z_mt": 0.0,
                    "field_total_mt": field_x,
                    "freq_hz": 0.0,
                    "temp_c": 0.0,
                    "field_mt": field_x,
                }
            if len(parts) != 3:
                return None
            field_x = float(parts[0])
            freq = float(parts[1])
            temp = float(parts[2]) / 10.0
            return {
                "field_x_mt": field_x,
                "field_y_mt": 0.0,
                "field_z_mt": 0.0,
                "field_total_mt": field_x,
                "freq_hz": freq,
                "temp_c": temp,
                "field_mt": field_x,
            }
        except (ValueError, UnicodeDecodeError):
            return None

    @staticmethod
    def _parse_2d_gauss(text: str, length: int) -> Optional[Dict[str, float]]:
        try:
            if not text.startswith("#"):
                return None
            core = text[1:].rstrip(">").strip()
            if length < 40:
                # 短帧: #X/频率/Y>
                parts = core.split("/")
                if len(parts) != 3:
                    return None
                field_x = float(parts[0])
                freq = float(parts[1])
                field_y = float(parts[2])
                temp = 0.0
            else:
                # 长帧: #X/频率/温度;Y/频率/温度>
                # DataReader2 decompiled code uses dg2[2] for Y, which implies
                # some batches may emit a third segment. Prefer that when
                # present, but keep the documented two-segment shape working.
                dg2 = core.split(";")
                if len(dg2) < 2:
                    return None
                x_parts = dg2[0].split("/")
                y_parts = (dg2[2] if len(dg2) >= 3 else dg2[1]).split("/")
                if len(x_parts) < 3 or len(y_parts) < 1:
                    return None
                field_x = float(x_parts[0])
                field_y = float(y_parts[0])
                freq = float(x_parts[1])
                temp = float(x_parts[2]) / 10.0
            total = math.sqrt(field_x * field_x + field_y * field_y)
            return {
                "field_x_mt": field_x,
                "field_y_mt": field_y,
                "field_z_mt": 0.0,
                "field_total_mt": total,
                "freq_hz": freq,
                "temp_c": temp,
                "field_mt": total,
            }
        except (ValueError, UnicodeDecodeError):
            return None

    @staticmethod
    def _parse_3d_gauss(text: str, length: int) -> Optional[Dict[str, float]]:
        try:
            if not text.startswith("#"):
                return None
            core = text[1:].rstrip(">").strip()
            if length < 60:
                # 短帧: #X/Y/Z>
                parts = core.split("/")
                if len(parts) != 3:
                    return None
                field_x = float(parts[0])
                field_y = float(parts[1])
                field_z = float(parts[2])
                freq = 0.0
                temp = 0.0
            else:
                # 长帧: #X/频率/温度;Y/频率/温度;Z/频率/温度>
                dg3 = core.split(";")
                if len(dg3) < 3:
                    return None
                x_parts = dg3[0].split("/")
                y_parts = dg3[1].split("/")
                z_parts = dg3[2].split("/")
                if len(x_parts) < 3 or len(y_parts) < 1 or len(z_parts) < 1:
                    return None
                field_x = float(x_parts[0])
                field_y = float(y_parts[0])
                field_z = float(z_parts[0])
                freq = float(x_parts[1])
                temp = float(x_parts[2]) / 10.0
            total = math.sqrt(field_x * field_x + field_y * field_y + field_z * field_z)
            return {
                "field_x_mt": field_x,
                "field_y_mt": field_y,
                "field_z_mt": field_z,
                "field_total_mt": total,
                "freq_hz": freq,
                "temp_c": temp,
                "field_mt": total,
            }
        except (ValueError, UnicodeDecodeError):
            return None

    @staticmethod
    def _parse_fluxmeter(text: str, length: int) -> Optional[Dict[str, float]]:
        try:
            # C# 行为: 去掉开头的 \0 和 #, 去掉结尾的 >, 然后按 / 分割
            text = text.lstrip("\0").lstrip("#").rstrip(">")
            parts = text.split("/")
            if len(parts) != 3:
                return None
            field_x = float(parts[0])
            freq = float(parts[1])
            temp = float(parts[2]) / 10.0
            return {
                "field_x_mt": field_x,
                "field_y_mt": 0.0,
                "field_z_mt": 0.0,
                "field_total_mt": field_x,
                "freq_hz": freq,
                "temp_c": temp,
                "field_mt": field_x,
            }
        except (ValueError, UnicodeDecodeError):
            return None

    @staticmethod
    def _parse_1d_fluxgate(text: str, length: int) -> Optional[Dict[str, float]]:
        try:
            if not text.startswith("#"):
                return None
            core = text[1:].rstrip(">").strip()
            parts = core.split("/")
            if len(parts) != 3:
                return None
            field_x = float(parts[0])
            freq = float(parts[1])
            temp = float(parts[2]) / 10.0
            return {
                "field_x_mt": field_x,
                "field_y_mt": 0.0,
                "field_z_mt": 0.0,
                "field_total_mt": field_x,
                "freq_hz": freq,
                "temp_c": temp,
                "field_mt": field_x,
            }
        except (ValueError, UnicodeDecodeError):
            return None

    @staticmethod
    def _parse_3d_fluxgate(text: str, length: int) -> Optional[Dict[str, float]]:
        try:
            if not text.startswith("#"):
                return None
            core = text[1:].rstrip(">").strip()
            parts = core.split("/")
            if len(parts) != 3:
                return None
            field_x = float(parts[0])
            field_y = float(parts[1])
            field_z = float(parts[2])
            total = math.sqrt(field_x * field_x + field_y * field_y + field_z * field_z)
            return {
                "field_x_mt": field_x,
                "field_y_mt": field_y,
                "field_z_mt": field_z,
                "field_total_mt": total,
                "freq_hz": 0.0,
                "temp_c": 0.0,
                "field_mt": total,
            }
        except (ValueError, UnicodeDecodeError):
            return None

    # ------------------------------------------------------------------
    # 数据流控制
    # ------------------------------------------------------------------

    def start_streaming(self, mode_key: str = "dc_normal", model: str = "") -> None:
        """启动实时数据流。

        Args:
            mode_key: 采集模式键，对应 ACQ_MODE_TABLE 中的 key。
                      根据模式发送对应的硬件启动指令（DATA?> 或 FASTxxx>）。
            model: 设备型号。若为一维高斯计 ("1d_gauss") 且模式使用 FAST020>，
                   则自动替换为简写 FAST2>。
        """
        # A detected preview stream can also be a leftover remote FAST/DATA
        # stream. Do not skip the requested start command merely because it was
        # labelled as panel/preview streaming during connect.

        # 根据模式选择启动指令
        from app.config_io import ACQ_MODE_TABLE
        mode_cfg = ACQ_MODE_TABLE.get(mode_key, {})
        cmd = mode_cfg.get("start_command", "DATA?>")
        # 一维高斯计 20Hz 快速模式使用简写 FAST2>
        if model == "1d_gauss" and cmd == "FAST020>":
            cmd = mode_cfg.get("fast_1d_command", "FAST2>")
        self._send_command(cmd)

        # 排空启动时的残留缓冲数据，需在锁内访问 _serial
        with self._lock:
            self._streaming = True
            try:
                if self._serial is not None and self._serial.is_open:
                    self._serial.read(self._serial.in_waiting)
            except Exception:
                pass

    def set_sample_rate(self, mode_key: str) -> str:
        """设置采样速率（发送 FASTxxx> 指令，不启动流）。

        Args:
            mode_key: 采集模式键。

        Returns:
            实际发送的指令字符串。
        """
        from app.config_io import ACQ_MODE_TABLE
        cmd = ACQ_MODE_TABLE.get(mode_key, {}).get("start_command", "DATA?>")
        self._send_command(cmd)
        return cmd

    def stop_streaming(self) -> None:
        """停止实时数据流 (DATAC> 或仅标记停止)。"""
        # Always try DATAC>; a preview stream may be a remote stream left by
        # the previous GUI/debug session, not a truly command-locked panel mode.
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

    def query_data_once(self, model: str = "1d_gauss") -> Optional[Dict[str, float]]:
        """单次查询数据 (DATAS>)。返回完整帧或 None。"""
        raw = self._send_command("DATAS")
        text = raw.decode("ascii", errors="ignore").strip()
        # 格式: "ACK" + 实时数据
        if text.startswith("ACK"):
            text = text[3:]
        return CH1600Driver.parse_stream_frame(text.encode("ascii"), model=model)

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
