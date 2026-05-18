"""CH-1600 低频状态监控 Worker

在独立 QThread 中以设定间隔查询设备状态 (单位、量程、阈值)。
仅在非流模式下运行, 严格遵循 10 命令/秒的限制 (间隔 >= 100ms)。
"""

from __future__ import annotations

import queue
import time
from typing import Optional

from PyQt5.QtCore import QObject, pyqtSignal

from instruments.ch1600_driver import CH1600Driver


class CH1600MonitorWorker(QObject):
    """CH-1600 设备状态轮询 Worker。

    以 interval_ms 间隔查询 unit、range 等状态信息。
    通过命令队列支持外部控制请求。
    """

    state_updated = pyqtSignal(dict)       # {unit, range, up_threshold, low_threshold}
    error_occurred = pyqtSignal(str)
    log_requested = pyqtSignal(str)
    finished = pyqtSignal()

    def __init__(
        self,
        driver: CH1600Driver,
        command_queue: queue.Queue,
        interval_ms: int = 500,
    ) -> None:
        super().__init__()
        self._driver = driver
        self._queue = command_queue
        # 每轮会查询 UNIT? 和 RANGE? 两条命令；最低 250ms 保留余量，避免超过 10 cmd/s。
        self._interval_ms = max(250, interval_ms)
        self._stop_requested = False
        self._query_count = 0

    def run(self) -> None:
        self.log_requested.emit("[CH-1600] 状态监控线程启动")
        consecutive_errors = 0
        MAX_CONSEC_ERRORS = 5

        try:
            while not self._stop_requested:
                self._drain_commands()

                try:
                    if self._driver.is_connected and not self._driver.is_streaming:
                        unit = self._driver.query_unit()
                        rng = self._driver.query_range()

                        self.state_updated.emit({
                            "unit": unit,
                            "range": rng,
                        })
                        consecutive_errors = 0

                        self._query_count += 1
                        if self._query_count % 20 == 0:
                            self.log_requested.emit(
                                f"[CH-1600] 已查询 {self._query_count} 次状态"
                            )
                except Exception as exc:
                    consecutive_errors += 1
                    self.error_occurred.emit(f"[CH-1600] 状态查询失败: {exc}")
                    if consecutive_errors >= MAX_CONSEC_ERRORS:
                        self.error_occurred.emit(
                            f"[CH-1600] 连续 {consecutive_errors} 次状态查询失败, 退出"
                        )
                        break

                time.sleep(self._interval_ms / 1000.0)

        except Exception as exc:
            self.error_occurred.emit(f"[CH-1600] 监控线程异常: {exc}")
        finally:
            self.log_requested.emit("[CH-1600] 状态监控线程结束")
            self.finished.emit()

    def stop(self) -> None:
        self._stop_requested = True

    def set_interval(self, ms: int) -> None:
        self._interval_ms = max(250, ms)

    def _drain_commands(self) -> None:
        """处理命令队列中的待处理命令。"""
        while True:
            try:
                cmd, args = self._queue.get_nowait()
            except queue.Empty:
                break
            try:
                method = getattr(self._driver, cmd)
                method(*args)
                self.log_requested.emit(
                    f"[CH-1600] 执行: {cmd}({', '.join(str(a) for a in args)})"
                )
            except Exception as exc:
                self.error_occurred.emit(f"[CH-1600] 命令 {cmd} 失败: {exc}")
