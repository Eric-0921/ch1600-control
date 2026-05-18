"""CH-1600 CSV 数据记录器

将磁场数据流写入 CSV 文件, 带 UTF-8 BOM 编码。
支持根据设备型号动态调整表头和列数。
"""

from __future__ import annotations

from pathlib import Path
from typing import Dict, List, Optional
import datetime

from data.device_capabilities import get_device_capability


def _get_schema(model: str) -> List[str]:
    return list(get_device_capability(model).recorder_fields)


class CH1600Recorder:
    """CSV 数据记录器。

    写入格式根据 device_model 动态决定:
      1D : timestamp_s,field_total_mt,freq_hz,temp_c
      2D : timestamp_s,field_x_mt,field_y_mt,field_total_mt,freq_hz,temp_c
      3D : timestamp_s,field_x_mt,field_y_mt,field_z_mt,field_total_mt,freq_hz,temp_c
    """

    def __init__(
        self,
        output_dir: Optional[Path] = None,
        max_file_size_mb: float = 100.0,
        max_file_rows: int = 100000,
        rollover_strategy: str = "new_file",
        device_model: str = "1d_gauss",
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
        self._device_model = device_model
        self._schema = _get_schema(device_model)

    # ------------------------------------------------------------------
    # properties
    # ------------------------------------------------------------------

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

    @property
    def schema(self) -> List[str]:
        return list(self._schema)

    # ------------------------------------------------------------------
    # rollover
    # ------------------------------------------------------------------

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
        self._handle.write(",".join(self._schema) + "\n")
        self._row_count = 0

    # ------------------------------------------------------------------
    # lifecycle
    # ------------------------------------------------------------------

    def start(self, prefix: str = "ch1600") -> Path:
        """开始记录, 返回文件路径。"""
        if self._handle is not None:
            raise RuntimeError("已在记录中")

        self._output_dir.mkdir(parents=True, exist_ok=True)
        self._prefix = prefix
        self._timestamp = datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
        self._file_path = self._output_dir / f"{prefix}_{self._timestamp}.csv"

        self._handle = open(self._file_path, "w", encoding="utf-8-sig")
        self._handle.write(",".join(self._schema) + "\n")
        self._row_count = 0
        self._stopped_by_rollover = False
        self._rollover_reason = None

        return self._file_path

    def stop(self) -> None:
        """停止记录。"""
        if self._handle is not None:
            self._handle.close()
            self._handle = None

    # ------------------------------------------------------------------
    # write
    # ------------------------------------------------------------------

    def write_point(self, data: Dict[str, float]) -> None:
        """写入单点。

        Args:
            data: 必须包含 'timestamp_s' 以及 schema 中定义的所有字段。
                  缺失字段自动补 0.0。
        """
        if self._handle is None or self._stopped_by_rollover:
            return
        values = [data.get(col, 0.0) for col in self._schema]
        # 格式化: timestamp 6位小数, field 6位, freq 1位, temp 2位
        fmt_parts: List[str] = []
        for col, val in zip(self._schema, values):
            if col == "timestamp_s":
                fmt_parts.append(f"{val:.6f}")
            elif col.startswith("field_"):
                fmt_parts.append(f"{val:.6f}")
            elif col == "freq_hz":
                fmt_parts.append(f"{val:.1f}")
            elif col == "temp_c":
                fmt_parts.append(f"{val:.2f}")
            else:
                fmt_parts.append(str(val))
        self._handle.write(",".join(fmt_parts) + "\n")
        self._handle.flush()
        self._row_count += 1
        self._check_rollover()

    def write_batch(self, points: List[Dict[str, float]]) -> None:
        """批量写入。

        每个点包含 schema 中对应字段即可, 缺失字段自动补 0.0。
        """
        if self._handle is None or self._stopped_by_rollover:
            return
        lines: List[str] = []
        for p in points:
            values = [p.get(col, 0.0) for col in self._schema]
            fmt_parts: List[str] = []
            for col, val in zip(self._schema, values):
                if col == "timestamp_s":
                    fmt_parts.append(f"{val:.6f}")
                elif col.startswith("field_"):
                    fmt_parts.append(f"{val:.6f}")
                elif col == "freq_hz":
                    fmt_parts.append(f"{val:.1f}")
                elif col == "temp_c":
                    fmt_parts.append(f"{val:.2f}")
                else:
                    fmt_parts.append(str(val))
            lines.append(",".join(fmt_parts))
        if lines:
            self._handle.write("\n".join(lines) + "\n")
            self._handle.flush()
            self._row_count += len(points)
            self._check_rollover()
