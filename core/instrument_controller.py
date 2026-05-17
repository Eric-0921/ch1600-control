"""CH-1600 设备门面 (InstrumentController)

持有 CH1600Driver 实例, 管理后台 Worker 生命周期。
遵循 odmr-control 的 QThread + moveToThread 模式。

三级信号广播:
  Driver -> InstrumentController (信号) -> CommandService (转发) -> GUI (订阅)
"""

from __future__ import annotations

import queue
import time
from typing import Any, Dict, List, Optional

from PyQt5.QtCore import QObject, QThread, pyqtSignal

from instruments.ch1600_driver import CH1600Driver
from workers.ch1600_stream_worker import CH1600StreamWorker
from workers.ch1600_monitor_worker import CH1600MonitorWorker


class InstrumentController(QObject):
    """CH-1600 设备门面。

    管理 driver 实例和后台 worker 线程生命周期。
    所有信号从 worker/driver 转发到上层 (CommandService)。
    """

    # 数据信号
    ch1600_stream_batch = pyqtSignal(dict)      # 批量: {points, count, total, latest}
    ch1600_state_changed = pyqtSignal(dict)     # 状态: {unit, range, streaming, connected, ...}

    # 系统信号
    error_occurred = pyqtSignal(str)
    log_requested = pyqtSignal(str)

    def __init__(self, parent: QObject | None = None) -> None:
        super().__init__(parent)
        self._driver = CH1600Driver()

        # Worker 引用
        self._stream_worker: Optional[CH1600StreamWorker] = None
        self._stream_thread: Optional[QThread] = None
        self._monitor_worker: Optional[CH1600MonitorWorker] = None
        self._monitor_thread: Optional[QThread] = None

    # ------------------------------------------------------------------
    # properties
    # ------------------------------------------------------------------

    @property
    def driver(self) -> CH1600Driver:
        return self._driver

    @property
    def is_connected(self) -> bool:
        return self._driver.is_connected

    @property
    def is_streaming(self) -> bool:
        return self._driver.is_streaming

    # ------------------------------------------------------------------
    # 连接管理
    # ------------------------------------------------------------------

    def connect(self, port: str, baudrate: int = 115200) -> str:
        """连接设备，返回 IDN 字符串。"""
        idn = self._driver.connect(port=port, baudrate=baudrate)
        self.log_requested.emit(f"[Controller] 已连接: {idn}")
        self._emit_state()
        return idn

    def disconnect(self) -> None:
        """断开设备连接，停止所有 worker。"""
        self._stop_streaming()
        self._stop_monitoring()
        self._driver.close()
        self.log_requested.emit("[Controller] 已断开")
        self._emit_state()

    # ------------------------------------------------------------------
    # 数据流 Worker 管理
    # ------------------------------------------------------------------

    def start_streaming(self, batch_size: int = 100, mode_key: str = "dc_normal") -> None:
        """启动高速数据流 Worker。"""
        if not self._driver.is_connected:
            self.error_occurred.emit("[Controller] 设备未连接，无法启动数据流")
            return
        if self._stream_thread is not None:
            self.log_requested.emit("[Controller] 数据流已在运行")
            return

        self._stream_worker = CH1600StreamWorker(
            self._driver, batch_size=batch_size, mode_key=mode_key
        )
        self._stream_thread = QThread(self)

        self._stream_worker.moveToThread(self._stream_thread)

        # 连接信号
        self._stream_worker.batch_ready.connect(self.ch1600_stream_batch.emit)
        self._stream_worker.error_occurred.connect(self.error_occurred.emit)
        self._stream_worker.log_requested.connect(self.log_requested.emit)
        self._stream_worker.finished.connect(self._on_stream_finished)

        self._stream_thread.started.connect(self._stream_worker.run)
        self._stream_thread.start()
        self.log_requested.emit("[Controller] 数据流已启动")
        self._emit_state()

    def _stop_streaming(self) -> None:
        """停止数据流 Worker。"""
        if self._stream_worker is not None:
            self._stream_worker.stop()
        if self._stream_thread is not None:
            self._stream_thread.quit()
            if not self._stream_thread.wait(3000):
                self.log_requested.emit("[Controller] 数据流线程强制终止")
                self._stream_thread.terminate()
                self._stream_thread.wait(1000)
            self._stream_thread = None
        self._stream_worker = None

    def _on_stream_finished(self) -> None:
        """数据流线程结束回调。"""
        self._stream_worker = None
        self._stream_thread = None
        self._emit_state()

    # ------------------------------------------------------------------
    # 状态监控 Worker 管理
    # ------------------------------------------------------------------

    def start_monitoring(self, interval_ms: int = 500) -> None:
        """启动低频状态监控 Worker。"""
        if not self._driver.is_connected:
            return
        if self._monitor_thread is not None:
            return

        cmd_queue: queue.Queue = queue.Queue()
        self._monitor_worker = CH1600MonitorWorker(
            self._driver, cmd_queue, interval_ms=interval_ms
        )
        self._monitor_thread = QThread(self)

        self._monitor_worker.moveToThread(self._monitor_thread)

        self._monitor_worker.state_updated.connect(self._on_monitor_state)
        self._monitor_worker.error_occurred.connect(self.error_occurred.emit)
        self._monitor_worker.log_requested.connect(self.log_requested.emit)
        self._monitor_worker.finished.connect(self._on_monitor_finished)

        self._monitor_thread.started.connect(self._monitor_worker.run)
        self._monitor_thread.start()

    def _stop_monitoring(self) -> None:
        """停止状态监控 Worker。"""
        if self._monitor_worker is not None:
            self._monitor_worker.stop()
        if self._monitor_thread is not None:
            self._monitor_thread.quit()
            if not self._monitor_thread.wait(2000):
                self._monitor_thread.terminate()
                self._monitor_thread.wait(1000)
            self._monitor_thread = None
        self._monitor_worker = None

    def _on_monitor_state(self, state: dict) -> None:
        """监控状态更新，加上连接和流状态后发射。"""
        state["connected"] = self._driver.is_connected
        state["streaming"] = self._driver.is_streaming
        self.ch1600_state_changed.emit(state)

    def _on_monitor_finished(self) -> None:
        self._monitor_worker = None
        self._monitor_thread = None

    # ------------------------------------------------------------------
    # 便捷方法 (委托给 driver)
    # ------------------------------------------------------------------

    def scan_ports(self) -> List[tuple]:
        return self._driver.scan_ports()

    def zero(self) -> None:
        self._driver.zero()
        self.log_requested.emit("[Controller] 执行归零")

    def set_unit_cycle(self) -> None:
        self._driver.set_unit_cycle()

    def set_range_cycle(self) -> None:
        self._driver.set_range_cycle()

    def query_state(self) -> Dict[str, Any]:
        return self._driver.query_state()

    def set_up_threshold(self, value: float) -> None:
        self._driver.set_up_threshold(value)

    def set_low_threshold(self, value: float) -> None:
        self._driver.set_low_threshold(value)

    def show_max_min(self) -> None:
        self._driver.show_max_min()

    def lock_panel(self) -> None:
        self._driver.lock_panel()

    def unlock_panel(self) -> None:
        self._driver.unlock_panel()

    def rela(self) -> str:
        return self._driver.rela()

    # ------------------------------------------------------------------
    # 内部
    # ------------------------------------------------------------------

    def _emit_state(self) -> None:
        """发射当前完整状态。"""
        self.ch1600_state_changed.emit({
            "unit": self._driver.cached_unit,
            "range": self._driver.cached_range,
            "streaming": self._driver.is_streaming,
            "connected": self._driver.is_connected,
            "panel_streaming": self._driver.is_panel_streaming_mode,
        })

    def emergency_stop(self) -> bool:
        """急停：停止数据流并断开设备。"""
        try:
            self._stop_streaming()
            self._stop_monitoring()
            self._driver.close()
            self.log_requested.emit("[Controller] 紧急停止")
            self._emit_state()
            return True
        except Exception as exc:
            self.error_occurred.emit(f"[Controller] 紧急停止失败: {exc}")
            return False
