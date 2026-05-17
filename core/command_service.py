"""CH-1600 命令服务 (CommandService)

单线程命令队列总线, 遵循 odmr-control 的架构模式:
- queue.Queue 串行化所有命令
- _execute() 路由 CommandType 到具体操作
- 三级信号广播: 订阅 InstrumentController 信号 → 转发到 GUI

同时还处理时间戳同步注入 (TimestampSync)。
"""

from __future__ import annotations

import queue
import threading
from typing import Any, Dict, Optional

from PyQt5.QtCore import QEventLoop, QObject, QTimer, pyqtSignal

from core.commands import Command, CommandType
from core.instrument_controller import InstrumentController


class CommandService(QObject):
    """单线程命令总线。

    所有命令通过 submit() / submit_sync() 进入队列,
    由 _process_loop() 在工作线程中串行执行。
    """

    # 命令完成信号
    command_completed = pyqtSignal(str, object)   # (request_id, result)
    command_error = pyqtSignal(str, str)           # (request_id, error_message)

    # 三级广播信号 (转发自 InstrumentController)
    ch1600_stream_batch_broadcast = pyqtSignal(dict)
    ch1600_state_broadcast = pyqtSignal(dict)
    error_occurred = pyqtSignal(str)
    log_requested = pyqtSignal(str)

    def __init__(
        self,
        controller: InstrumentController,
        config: Optional[Dict[str, Any]] = None,
        parent: Optional[QObject] = None,
    ) -> None:
        super().__init__(parent)
        self._ctrl = controller
        self._cfg = config or {}
        self._queue: queue.Queue = queue.Queue()
        self._stop_event = threading.Event()
        self._thread: Optional[threading.Thread] = None

        # 转发控制器信号
        self._ctrl.ch1600_stream_batch.connect(self._on_stream_batch)
        self._ctrl.ch1600_state_changed.connect(self.ch1600_state_broadcast.emit)
        self._ctrl.error_occurred.connect(self.error_occurred.emit)
        self._ctrl.log_requested.connect(self.log_requested.emit)

    # ------------------------------------------------------------------
    # 生命周期
    # ------------------------------------------------------------------

    def start(self) -> None:
        """启动命令处理线程。"""
        if self._thread is not None:
            return
        self._stop_event.clear()
        self._thread = threading.Thread(target=self._process_loop, daemon=True)
        self._thread.start()
        self.log_requested.emit("[CmdSvc] 命令服务已启动")

    def stop(self) -> None:
        """停止命令处理线程。"""
        self._stop_event.set()
        if self._thread is not None:
            self._thread.join(timeout=3.0)
            self._thread = None
        self.log_requested.emit("[CmdSvc] 命令服务已停止")

    # ------------------------------------------------------------------
    # 命令提交
    # ------------------------------------------------------------------

    def submit(self, cmd: Command) -> str:
        """异步提交命令, 返回 request_id。"""
        self._queue.put(cmd)
        return cmd.request_id

    def submit_sync(self, cmd: Command, timeout: float = 5.0) -> Any:
        """同步提交命令, 等待完成并返回结果。

        使用 QEventLoop 而非 threading.Event, 确保 Qt 跨线程信号
        (command_completed / command_error) 能在主线程事件循环中被正常投递。
        """
        loop = QEventLoop()
        result_holder: Dict[str, Any] = {}

        def _on_done(rid: str, result: Any) -> None:
            if rid == cmd.request_id:
                result_holder["result"] = result
                loop.quit()

        def _on_err(rid: str, err: str) -> None:
            if rid == cmd.request_id:
                result_holder["error"] = err
                loop.quit()

        self.command_completed.connect(_on_done)
        self.command_error.connect(_on_err)

        timer = QTimer()
        timer.setSingleShot(True)
        timer.timeout.connect(loop.quit)
        timer.start(int(timeout * 1000))

        try:
            self._queue.put(cmd)
            loop.exec_()
            if not timer.isActive():
                # timer fired → timeout
                raise TimeoutError(f"命令 {cmd.cmd_type.name} 超时 ({timeout}s)")
            timer.stop()
            if "error" in result_holder:
                raise RuntimeError(result_holder["error"])
            return result_holder.get("result")
        finally:
            try:
                self.command_completed.disconnect(_on_done)
                self.command_error.disconnect(_on_err)
            except Exception:
                pass

    # ------------------------------------------------------------------
    # 处理循环 (工作线程)
    # ------------------------------------------------------------------

    def _process_loop(self) -> None:
        """命令处理主循环, 运行在工作线程中。"""
        while not self._stop_event.is_set():
            try:
                cmd = self._queue.get(timeout=0.1)
            except queue.Empty:
                continue

            try:
                result = self._execute(cmd)
                self.command_completed.emit(cmd.request_id, result)
            except Exception as exc:
                self.command_error.emit(cmd.request_id, str(exc))

    # ------------------------------------------------------------------
    # 命令路由
    # ------------------------------------------------------------------

    def _execute(self, cmd: Command) -> Any:
        """根据 CommandType 路由到具体操作。"""
        ct = cmd.cmd_type
        p = cmd.params

        # 连接管理
        if ct == CommandType.CH1600_CONNECT:
            return self._ctrl.connect(
                port=p["port"],
                baudrate=p.get("baudrate", 115200),
            )
        elif ct == CommandType.CH1600_DISCONNECT:
            self._ctrl.disconnect()
            return None
        elif ct == CommandType.CH1600_SCAN_PORTS:
            return self._ctrl.scan_ports()

        # 数据流 (由 start_acquisition/stop_acquisition 直接调用, 不走命令队列)
        elif ct == CommandType.CH1600_START_STREAM:
            raise RuntimeError("START_STREAM 必须通过 start_acquisition() 在主线程调用")
        elif ct == CommandType.CH1600_STOP_STREAM:
            raise RuntimeError("STOP_STREAM 必须通过 stop_acquisition() 在主线程调用")
        elif ct == CommandType.CH1600_QUERY_DATA_ONCE:
            return self._ctrl.driver.query_data_once()

        # 查询
        elif ct == CommandType.CH1600_QUERY_UNIT:
            return self._ctrl.driver.query_unit()
        elif ct == CommandType.CH1600_QUERY_RANGE:
            return self._ctrl.driver.query_range()
        elif ct == CommandType.CH1600_QUERY_UP_THRESH:
            return self._ctrl.driver.query_up_threshold()
        elif ct == CommandType.CH1600_QUERY_LOW_THRESH:
            return self._ctrl.driver.query_low_threshold()
        elif ct == CommandType.CH1600_QUERY_STATE:
            return self._ctrl.query_state()

        # 控制
        elif ct == CommandType.CH1600_SET_UNIT_CYCLE:
            self._ctrl.set_unit_cycle()
            return None
        elif ct == CommandType.CH1600_SET_RANGE_CYCLE:
            self._ctrl.set_range_cycle()
            return None
        elif ct == CommandType.CH1600_ZERO:
            self._ctrl.zero()
            return None
        elif ct == CommandType.CH1600_MAX_MIN:
            self._ctrl.show_max_min()
            return None
        elif ct == CommandType.CH1600_LOCK:
            self._ctrl.lock_panel()
            return None
        elif ct == CommandType.CH1600_UNLOCK:
            self._ctrl.unlock_panel()
            return None
        elif ct == CommandType.CH1600_RELA:
            return self._ctrl.rela()

        # 阈值
        elif ct == CommandType.CH1600_SET_UP_THRESH:
            self._ctrl.set_up_threshold(float(p["value"]))
            return None
        elif ct == CommandType.CH1600_SET_LOW_THRESH:
            self._ctrl.set_low_threshold(float(p["value"]))
            return None

        # 系统
        elif ct == CommandType.SYS_EMERGENCY_STOP:
            return self._ctrl.emergency_stop()

        else:
            raise ValueError(f"未知命令类型: {ct}")

    # ------------------------------------------------------------------
    # 信号转发
    # ------------------------------------------------------------------

    def _on_stream_batch(self, batch: dict) -> None:
        """批量数据转发。"""
        self.ch1600_stream_batch_broadcast.emit(batch)

    # ------------------------------------------------------------------
    # 便捷方法 (供 GUI 直接调用)
    # ------------------------------------------------------------------

    def connect_device(self, port: str, baudrate: int = 115200) -> str:
        """同步连接设备。"""
        cmd = Command(
            cmd_type=CommandType.CH1600_CONNECT,
            params={"port": port, "baudrate": baudrate},
        )
        return self.submit_sync(cmd)

    def disconnect_device(self) -> None:
        """同步断开设备。"""
        cmd = Command(cmd_type=CommandType.CH1600_DISCONNECT)
        self.submit_sync(cmd, timeout=3.0)

    def start_acquisition(self) -> None:
        """启动数据采集 (流 + 监控)。必须在主线程调用。"""
        # 直接调用 (创建 QThread 必须在主线程)
        mode_key = self._cfg.get("acquisition", {}).get("mode_key", "dc_normal")
        device_model = self._cfg.get("device_model", "1d_gauss")
        self._ctrl.start_streaming(
            batch_size=self._cfg.get("ch1600", {}).get("stream_batch_size", 100),
            mode_key=mode_key,
            device_model=device_model,
        )
        self._ctrl.start_monitoring(interval_ms=500)

    def stop_acquisition(self) -> None:
        """停止数据采集。必须在主线程调用。"""
        self._ctrl._stop_streaming()
        self._ctrl._stop_monitoring()

    def do_zero(self) -> None:
        self.submit(Command(cmd_type=CommandType.CH1600_ZERO))

    def cycle_unit(self) -> None:
        self.submit(Command(cmd_type=CommandType.CH1600_SET_UNIT_CYCLE))

    def cycle_range(self) -> None:
        self.submit(Command(cmd_type=CommandType.CH1600_SET_RANGE_CYCLE))
