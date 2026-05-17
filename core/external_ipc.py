"""CH-1600 外部 IPC 服务 (ZMQ + NamedPipe)

支持跨平台 ZMQ PUB/REP 和 Windows NamedPipe。
"""

from __future__ import annotations

import json
import threading
from typing import Any, Callable, Dict, Optional

import zmq

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

    # ------------------------------------------------------------------
    # ZMQ
    # ------------------------------------------------------------------

    def start(self) -> None:
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
            except zmq.ContextTerminated:
                break
            except Exception:
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
            return json.dumps({"status": "error", "message": "invalid json"})

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
