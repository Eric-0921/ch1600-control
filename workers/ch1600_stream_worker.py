"""CH-1600 高速数据流 Worker

在独立 QThread 中以紧凑循环读取 DATA?> 实时数据流:
- 非阻塞读取串口可用字节
- 积累字节, 按 \\n 分割帧
- 解析每帧为 {field_mt, freq_hz, temp_c}
- 每 batch_size 点或每 ~30ms 批量发射 batch_ready
- 单点发射 data_ready (用于实时数值显示)

设计目标: 支持 30+ FPS 的 GUI 刷新率。
"""

from __future__ import annotations

import time
from typing import Dict, List, Optional

from PyQt5.QtCore import QObject, pyqtSignal

from instruments.ch1600_driver import CH1600Driver


class CH1600StreamWorker(QObject):
    """高速 DATA?> 数据流读取 Worker。

    在独立 QThread 中运行, 通过 pyqtSignal 与主线程通信。
    """

    batch_ready = pyqtSignal(dict)       # 批量: {points: [...], count, total, latest: {...}}
    error_occurred = pyqtSignal(str)
    log_requested = pyqtSignal(str)
    finished = pyqtSignal()

    def __init__(
        self,
        driver: CH1600Driver,
        batch_size: int = 100,
        batch_interval_s: float = 0.030,
        mode_key: str = "dc_normal",
        device_model: str = "1d_gauss",
    ) -> None:
        super().__init__()
        self._driver = driver
        self._batch_size = batch_size
        self._batch_interval_s = batch_interval_s
        self._mode_key = mode_key
        self._device_model = device_model
        self._stop_requested = False
        self._read_buffer = b""
        self._point_count = 0

    def run(self) -> None:
        self.log_requested.emit("[CH-1600] 数据流线程启动 (DATA?>)")
        consecutive_errors = 0
        MAX_CONSEC_ERRORS = 20

        # 启动设备端的实时发送
        try:
            self._driver.start_streaming(self._mode_key, model=self._device_model)
        except Exception as exc:
            self.error_occurred.emit(f"[CH-1600] 启动数据流失败: {exc}")
            self.finished.emit()
            return

        batch_points: List[Dict[str, float]] = []
        batch_start = time.perf_counter()
        latest_point: Dict[str, float] = {}

        try:
            while not self._stop_requested:
                try:
                    if not self._driver.is_connected:
                        self.error_occurred.emit("[CH-1600] 设备连接断开, 数据流退出")
                        break

                    # 非阻塞读取所有可用字节
                    raw = self._driver.read_stream_data()
                    if raw:
                        self._read_buffer += raw
                        consecutive_errors = 0

                        # 按 \n 分割完整帧
                        while b"\n" in self._read_buffer:
                            line, self._read_buffer = self._read_buffer.split(b"\n", 1)
                            parsed = CH1600Driver.parse_stream_frame(
                                line, model=self._device_model
                            )
                            if parsed is not None:
                                parsed["timestamp_s"] = time.perf_counter()
                                parsed["_raw_frame"] = line.decode("ascii", errors="replace")
                                batch_points.append(parsed)
                                latest_point = parsed
                                self._point_count += 1

                    # 检查是否需要发射批次
                    now = time.perf_counter()
                    should_emit = False

                    if len(batch_points) >= self._batch_size:
                        should_emit = True
                    elif batch_points and (now - batch_start) >= self._batch_interval_s:
                        should_emit = True

                    if should_emit and batch_points:
                        self.batch_ready.emit({
                            "points": batch_points,
                            "count": len(batch_points),
                            "total": self._point_count,
                            "latest": latest_point,
                        })
                        batch_points = []
                        batch_start = now

                    # 无数据时短暂休眠, 避免 100% CPU 空转
                    if not raw:
                        time.sleep(0.001)

                except Exception as exc:
                    consecutive_errors += 1
                    self.error_occurred.emit(f"[CH-1600] 读取错误: {exc}")
                    if consecutive_errors >= MAX_CONSEC_ERRORS:
                        self.error_occurred.emit(
                            f"[CH-1600] 连续 {consecutive_errors} 次错误, 退出"
                        )
                        break
                    time.sleep(0.01)

        finally:
            # 停止设备端发送
            try:
                if self._driver.is_connected:
                    self._driver.stop_streaming()
            except Exception:
                pass
            self.log_requested.emit(
                f"[CH-1600] 数据流线程结束, 共 {self._point_count} 点"
            )
            self.finished.emit()

    def stop(self) -> None:
        self._stop_requested = True
