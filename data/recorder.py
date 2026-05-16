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

    def __init__(self, output_dir: Optional[Path] = None) -> None:
        self._output_dir = output_dir or Path("./experiments")
        self._handle = None
        self._file_path: Optional[Path] = None
        self._row_count = 0

    @property
    def is_recording(self) -> bool:
        return self._handle is not None

    @property
    def file_path(self) -> Optional[Path]:
        return self._file_path

    @property
    def row_count(self) -> int:
        return self._row_count

    def start(self, prefix: str = "ch1600") -> Path:
        """开始记录, 返回文件路径。"""
        if self._handle is not None:
            raise RuntimeError("已在记录中")

        self._output_dir.mkdir(parents=True, exist_ok=True)
        ts = datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
        self._file_path = self._output_dir / f"{prefix}_{ts}.csv"

        self._handle = open(self._file_path, "w", encoding="utf-8-sig")
        self._handle.write("timestamp_s,field_mt,freq_hz,temp_c\n")
        self._row_count = 0

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
        if self._handle is None:
            return
        self._handle.write(
            f"{timestamp_s:.6f},{field_mt:.6f},{freq_hz:.1f},{temp_c:.2f}\n"
        )
        self._row_count += 1

    def write_batch(self, points: List[Dict[str, float]]) -> None:
        """批量写入。每个点包含 {field_mt, freq_hz, temp_c, timestamp_s}。"""
        if self._handle is None:
            return
        for p in points:
            self._handle.write(
                f"{p.get('timestamp_s', 0):.6f},"
                f"{p.get('field_mt', 0):.6f},"
                f"{p.get('freq_hz', 0):.1f},"
                f"{p.get('temp_c', 0):.2f}\n"
            )
        self._row_count += len(points)
