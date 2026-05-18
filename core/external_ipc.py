"""CH-1600 外部 IPC 服务 (ZMQ + NamedPipe)

支持跨平台 ZMQ PUB/REP 和 Windows NamedPipe。
"""

from __future__ import annotations

import json
import threading
from typing import Any, Callable, Dict, Optional

try:
    import zmq
    _HAS_ZMQ = True
except ImportError:
    zmq = None  # type: ignore[assignment]
    _HAS_ZMQ = False

try:
    import win32pipe
    import win32file
    import pywintypes
    _HAS_WIN32 = True
except ImportError:
    _HAS_WIN32 = False


class ExternalIPCService:
    """外部集成 IPC 服务。

    ZMQ 模式:
      - PUB socket 广播实时数据
      - REP socket 接收控制命令
    NamedPipe 模式 (Windows only):
      - 命名管道服务器接收控制命令
    """

    def __init__(self, data_pub_port: int = 5555, cmd_rep_port: int = 5556) -> None:
        self._data_pub_port = data_pub_port
        self._cmd_rep_port = cmd_rep_port

        self._ctx: Optional[zmq.Context] = None
        self._pub_socket: Optional[zmq.Socket] = None
        self._rep_socket: Optional[zmq.Socket] = None
        self._rep_thread: Optional[threading.Thread] = None
        self._rep_stop_event = threading.Event()

        self._pipe_name: str = "m1600_control"
        self._pipe_handle: Any = None
        self._pipe_thread: Optional[threading.Thread] = None
        self._pipe_stop_event = threading.Event()

        self._callbacks: Dict[str, Callable] = {}

    # ------------------------------------------------------------------
    # 回调注册
    # ------------------------------------------------------------------

    def set_command_callbacks(self, callbacks: Dict[str, Callable]) -> None:
        self._callbacks = callbacks

    @property
    def zmq_available(self) -> bool:
        return _HAS_ZMQ

    # ------------------------------------------------------------------
    # ZMQ
    # ------------------------------------------------------------------

    def start(self) -> None:
        if not _HAS_ZMQ or zmq is None:
            raise RuntimeError("pyzmq is not installed; ZMQ IPC is unavailable")
        if self._ctx is not None:
            return
        self._ctx = zmq.Context()
        self._pub_socket = self._ctx.socket(zmq.PUB)
        self._pub_socket.bind(f"tcp://*:{self._data_pub_port}")

        self._rep_socket = self._ctx.socket(zmq.REP)
        self._rep_socket.bind(f"tcp://*:{self._cmd_rep_port}")

        self._rep_stop_event.clear()
        self._rep_thread = threading.Thread(target=self._rep_loop, daemon=True)
        self._rep_thread.start()

    def stop(self) -> None:
        self._rep_stop_event.set()
        if self._rep_thread is not None:
            self._rep_thread.join(timeout=2.0)
            self._rep_thread = None

        if self._rep_socket is not None:
            self._rep_socket.close()
            self._rep_socket = None

        if self._pub_socket is not None:
            self._pub_socket.close()
            self._pub_socket = None

        if self._ctx is not None:
            self._ctx.term()
            self._ctx = None

    def publish_data(
        self,
        timestamp_s: float,
        field_x_mt: float = 0.0,
        field_y_mt: float = 0.0,
        field_z_mt: float = 0.0,
        field_total_mt: float = 0.0,
        freq_hz: float = 0.0,
        temp_c: float = 0.0,
    ) -> None:
        if self._pub_socket is None:
            return
        payload = {
            "timestamp_s": timestamp_s,
            "field_x_mt": field_x_mt,
            "field_y_mt": field_y_mt,
            "field_z_mt": field_z_mt,
            "field_total_mt": field_total_mt,
            "freq_hz": freq_hz,
            "temp_c": temp_c,
        }
        try:
            self._pub_socket.send_json(payload)
        except Exception:
            pass

    def _rep_loop(self) -> None:
        while not self._rep_stop_event.is_set():
            try:
                if self._rep_socket is None:
                    break
                if self._rep_socket.poll(timeout=200):
                    msg = self._rep_socket.recv_string()
                    response = self._handle_command(msg)
                    self._rep_socket.send_string(response)
            except Exception as exc:
                if _HAS_ZMQ and zmq is not None and isinstance(exc, zmq.ContextTerminated):
                    break
                pass

    # ------------------------------------------------------------------
    # NamedPipe
    # ------------------------------------------------------------------

    def start_namedpipe(self, pipe_name: str = "m1600_control") -> None:
        if not _HAS_WIN32:
            return
        if self._pipe_thread is not None:
            return
        self._pipe_name = pipe_name
        self._pipe_stop_event.clear()
        self._pipe_thread = threading.Thread(target=self._pipe_loop, daemon=True)
        self._pipe_thread.start()

    def stop_namedpipe(self) -> None:
        self._pipe_stop_event.set()
        if self._pipe_handle is not None:
            try:
                win32file.CloseHandle(self._pipe_handle)
            except Exception:
                pass
            self._pipe_handle = None
        if self._pipe_thread is not None:
            self._pipe_thread.join(timeout=2.0)
            self._pipe_thread = None

    def _pipe_loop(self) -> None:
        while not self._pipe_stop_event.is_set():
            try:
                handle = win32pipe.CreateNamedPipe(
                    r"\\.\pipe\\" + self._pipe_name,
                    win32pipe.PIPE_ACCESS_DUPLEX,
                    win32pipe.PIPE_TYPE_MESSAGE | win32pipe.PIPE_READMODE_MESSAGE | win32pipe.PIPE_WAIT,
                    1,
                    65536,
                    65536,
                    0,
                    None,
                )
                self._pipe_handle = handle
                win32pipe.ConnectNamedPipe(self._pipe_handle, None)
                while not self._pipe_stop_event.is_set():
                    try:
                        _, data = win32file.ReadFile(self._pipe_handle, 65536)
                        msg = data.decode("utf-8", errors="replace")
                        response = self._handle_command(msg)
                        win32file.WriteFile(self._pipe_handle, response.encode("utf-8"))
                    except pywintypes.error as e:
                        if e.winerror == 109:  # ERROR_BROKEN_PIPE
                            break
                        raise
            except Exception:
                pass
            finally:
                if self._pipe_handle is not None:
                    try:
                        win32file.CloseHandle(self._pipe_handle)
                    except Exception:
                        pass
                    self._pipe_handle = None

    # ------------------------------------------------------------------
    # 命令处理
    # ------------------------------------------------------------------

    def _handle_command(self, msg: str) -> str:
        try:
            cmd = json.loads(msg)
            if isinstance(cmd, str):
                cmd_name = cmd
                params: Dict[str, Any] = {}
            elif isinstance(cmd, dict):
                cmd_name = cmd.get("command", "")
                params = {k: v for k, v in cmd.items() if k != "command"}
            else:
                return json.dumps({"status": "error", "message": "invalid command format"})
        except json.JSONDecodeError:
            return self._handle_legacy_datareader2_command(msg)

        handler = self._callbacks.get(cmd_name)
        if handler is None:
            return json.dumps({"status": "error", "message": f"unknown command: {cmd_name}"})

        try:
            result = handler(**params) if params else handler()
            if result is None:
                result = {"status": "ok"}
            elif isinstance(result, dict):
                result.setdefault("status", "ok")
            else:
                result = {"status": "ok", "result": result}
            return json.dumps(result)
        except Exception as exc:
            return json.dumps({"status": "error", "message": str(exc)})

    def _handle_legacy_datareader2_command(self, msg: str) -> str:
        """Handle DataReader2-style tab-delimited NamedPipe commands.

        Reverse-engineered commands:
          GD\t<count>\t<sample_mode>\t<save>  -> configure and start reading
          SG                                  -> stop reading (sends DATAC> in DataReader2)
          ST\t<port>\t<model>\t<mode>\t<unit>\t<save>\t<max>\t<strategy>\t<always>
                                              -> configure only
        m1600 keeps configuration in the GUI, so unsupported fields are echoed
        back as parsed metadata instead of being silently applied.
        """
        parts = msg.strip().split("\t")
        if not parts or not parts[0]:
            return json.dumps({"status": "error", "message": "invalid json"})
        command = parts[0].upper()
        try:
            if command == "GD":
                if len(parts) != 4:
                    return json.dumps({"status": "error", "message": "GD expects 4 tab-delimited fields"})
                handler = self._callbacks.get("start_acquisition")
                if handler is None:
                    return json.dumps({"status": "error", "message": "start_acquisition callback not registered"})
                result = handler()
                if result is None:
                    result = {}
                if not isinstance(result, dict):
                    result = {"result": result}
                result.setdefault("status", "ok")
                result["legacy_command"] = "GD"
                result["requested_count"] = int(parts[1])
                result["sample_mode_index"] = int(parts[2])
                result["save_enabled"] = parts[3] != "0"
                return json.dumps(result)
            if command == "SG":
                handler = self._callbacks.get("stop_acquisition")
                if handler is None:
                    return json.dumps({"status": "error", "message": "stop_acquisition callback not registered"})
                result = handler()
                if result is None:
                    result = {}
                if not isinstance(result, dict):
                    result = {"result": result}
                result.setdefault("status", "ok")
                result["legacy_command"] = "SG"
                return json.dumps(result)
            if command == "ST":
                if len(parts) != 9:
                    return json.dumps({"status": "error", "message": "ST expects 9 tab-delimited fields"})
                return json.dumps({
                    "status": "ok",
                    "legacy_command": "ST",
                    "applied": False,
                    "message": "configuration parsed but not applied; use JSON API or GUI settings",
                    "port": f"COM{parts[1]}",
                    "model_index": int(parts[2]),
                    "sample_mode_index": int(parts[3]),
                    "unit_index": int(parts[4]),
                    "save_enabled": parts[5] != "0",
                    "max_rows": int(parts[6]),
                    "rollover_strategy_index": int(parts[7]),
                    "always_reading": parts[8] == "1",
                })
            return json.dumps({"status": "error", "message": f"unknown legacy command: {command}"})
        except Exception as exc:
            return json.dumps({"status": "error", "message": str(exc), "legacy_command": command})
