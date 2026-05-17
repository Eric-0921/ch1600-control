"""CH-1600 CSV 数据记录器

将磁场数据流写入 CSV 文件, 带 UTF-8 BOM 编码。
"""

from __future__ import annotations

from pathlib import Path
from typing import Dict, List, Optional
import datetime


class CH1600Recorder:
    """CSV 数据记录器。

    写入格式: timestamp_s,field_mt,freq_hz,temp_c
    """

    def __init__(
        self,
        output_dir: Optional[Path] = None,
        max_file_size_mb: float = 100.0,
        max_file_rows: int = 100000,
        rollover_strategy: str = "new_file",
    ) -> None:
        self._output_dir = output_dir or Path("./experiments")
        self._handle = None
        self._file_path: Optional[Path] = None
        self._row_count = 0
        self._file_index = 1
        self._prefix = "ch1600"
        self._timestamp = ""
        self.max_file_size_mb = max_file_size_mb
        self.max_file_rows = max_file_rows
        self.rollover_strategy = rollover_strategy
        self._stopped_by_rollover = False
        self._rollover_reason: Optional[str] = None

    @property
    def is_recording(self) -> bool:
        return self._handle is not None

    @property
    def file_path(self) -> Optional[Path]:
        return self._file_path

    @property
    def row_count(self) -> int:
        return self._row_count

    @property
    def stopped_by_rollover(self) -> bool:
        return self._stopped_by_rollover

    @property
    def current_file_size_mb(self) -> float:
        if self._file_path is None or not self._file_path.exists():
            return 0.0
        return self._file_path.stat().st_size / (1024 * 1024)

    @property
    def rollover_reason(self) -> Optional[str]:
        return self._rollover_reason

    def _check_rollover(self) -> None:
        """检查是否需要 rollover。"""
        if self._handle is None:
            return

        reason = None
        if self._row_count >= self.max_file_rows:
            reason = "rows"
        elif self.current_file_size_mb >= self.max_file_size_mb:
            reason = "size"

        if reason is None:
            return

        self._rollover_reason = reason

        if self.rollover_strategy == "stop":
            self._stopped_by_rollover = True
            self.stop()
            return

        # rollover_strategy == "new_file"
        self._handle.close()
        self._file_index += 1
        self._file_path = (
            self._output_dir
            / f"{self._prefix}_{self._timestamp}_{self._file_index}.csv"
        )
        self._handle = open(self._file_path, "w", encoding="utf-8-sig")
        self._handle.write("timestamp_s,field_mt,freq_hz,temp_c\n")
        self._row_count = 0

    def start(self, prefix: str = "ch1600") -> Path:
        """开始记录, 返回文件路径。"""
        if self._handle is not None:
            raise RuntimeError("已在记录中")

        self._output_dir.mkdir(parents=True, exist_ok=True)
        self._prefix = prefix
        self._timestamp = datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
        self._file_path = self._output_dir / f"{prefix}_{self._timestamp}.csv"

        self._handle = open(self._file_path, "w", encoding="utf-8-sig")
        self._handle.write("timestamp_s,field_mt,freq_hz,temp_c\n")
        self._row_count = 0
        self._stopped_by_rollover = False
        self._rollover_reason = None

        return self._file_path

    def stop(self) -> None:
        """停止记录。"""
        if self._handle is not None:
            self._handle.close()
            self._handle = None

    def write_point(
        self, field_mt: float, freq_hz: float, temp_c: float, timestamp_s: float
    ) -> None:
        """写入单点。"""
        if self._handle is None or self._stopped_by_rollover:
            return
        self._handle.write(
            f"{timestamp_s:.6f},{field_mt:.6f},{freq_hz:.1f},{temp_c:.2f}\n"
        )
        self._row_count += 1
        self._check_rollover()

    def write_batch(self, points: List[Dict[str, float]]) -> None:
        """批量写入。每个点包含 {field_mt, freq_hz, temp_c, timestamp_s}。"""
        if self._handle is None or self._stopped_by_rollover:
            return
        for p in points:
            self._handle.write(
                f"{p.get('timestamp_s', 0):.6f},"
                f"{p.get('field_mt', 0):.6f},"
                f"{p.get('freq_hz', 0):.1f},"
                f"{p.get('temp_c', 0):.2f}\n"
            )
        self._row_count += len(points)
        self._check_rollover()
