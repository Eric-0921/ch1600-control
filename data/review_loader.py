"""CH-1600 historical data loader and review dataset helpers.

The review page consumes one normalized structured array no matter whether the
data came from m1600 CSV files, DataReader2 tab-delimited text, or SQLite query
results.  Numeric field values are kept in generic ``field_*`` columns and the
legacy ``*_mt`` aliases are retained for backward compatibility with existing
plots and exports.
"""

from __future__ import annotations

import csv
import math
from pathlib import Path
from typing import Any, Dict, Iterable, List, Optional, Sequence, Tuple

import numpy as np

from data.measurement_analysis import analyze_time_series


REVIEW_DTYPE: List[Tuple[str, str]] = [
    ("session_id", "i8"),
    ("sequence", "i8"),
    ("timestamp_s", "f8"),
    ("x_mm", "f8"),
    ("y_mm", "f8"),
    ("z_mm", "f8"),
    ("field_x", "f8"),
    ("field_y", "f8"),
    ("field_z", "f8"),
    ("field_total", "f8"),
    ("field_x_mt", "f8"),
    ("field_y_mt", "f8"),
    ("field_z_mt", "f8"),
    ("field_total_mt", "f8"),
    ("field_mt", "f8"),
    ("freq_hz", "f8"),
    ("temp_c", "f8"),
    ("source", "U32"),
    ("field_unit", "U16"),
]


_HEADER_ALIASES: Dict[str, str] = {
    "session_id": "session_id",
    "session": "session_id",
    "序号": "sequence",
    "编号": "sequence",
    "index": "sequence",
    "seq": "sequence",
    "sequence": "sequence",
    "timestamp": "timestamp_s",
    "timestamp_s": "timestamp_s",
    "time": "timestamp_s",
    "time_s": "timestamp_s",
    "测量时间": "timestamp_s",
    "采样时间": "timestamp_s",
    "x_mm": "x_mm",
    "y_mm": "y_mm",
    "z_mm": "z_mm",
    "x": "field_x",
    "y": "field_y",
    "z": "field_z",
    "bx": "field_x",
    "by": "field_y",
    "bz": "field_z",
    "field_x": "field_x",
    "field_y": "field_y",
    "field_z": "field_z",
    "field_x_mt": "field_x",
    "field_y_mt": "field_y",
    "field_z_mt": "field_z",
    "field": "field_total",
    "field_mt": "field_total",
    "field_total": "field_total",
    "field_total_mt": "field_total",
    "测量值": "field_total",
    "磁场值": "field_total",
    "磁场": "field_total",
    "b": "field_total",
    "b_total": "field_total",
    "freq": "freq_hz",
    "frequency": "freq_hz",
    "freq_hz": "freq_hz",
    "频率": "freq_hz",
    "temp": "temp_c",
    "temperature": "temp_c",
    "temp_c": "temp_c",
    "温度": "temp_c",
    "source": "source",
    "数据源": "source",
    "unit": "field_unit",
    "field_unit": "field_unit",
    "单位": "field_unit",
}


def _empty_array() -> np.ndarray:
    return np.array([], dtype=REVIEW_DTYPE)


def _norm_header(value: str) -> str:
    return value.strip().strip("\ufeff").lower().replace("（", "(").replace("）", ")")


def _canonical_header(value: str) -> Optional[str]:
    norm = _norm_header(value)
    if norm in _HEADER_ALIASES:
        return _HEADER_ALIASES[norm]
    # Accept common unit-suffixed labels such as "测量值(mT)".
    for prefix, key in (
        ("测量值", "field_total"),
        ("磁场值", "field_total"),
        ("磁场", "field_total"),
        ("field", "field_total"),
    ):
        if norm.startswith(prefix.lower()):
            return key
    return None


def _source_for_path(path: Path) -> str:
    if path.suffix.lower() == ".txt":
        return "import_txt"
    return "import_csv"


def _safe_float(value: Any, default: float = 0.0) -> float:
    if value is None:
        return default
    text = str(value).strip().strip("'")
    if not text or text in {"—", "-", "--", "nan", "NaN"}:
        return default
    try:
        return float(text)
    except ValueError:
        return default


def _safe_int(value: Any, default: int = 0) -> int:
    try:
        return int(float(str(value).strip()))
    except (TypeError, ValueError):
        return default


def _looks_like_header(row: Sequence[str]) -> bool:
    if not row:
        return False
    for cell in row:
        if _canonical_header(cell) is not None:
            return True
    return not all(str(cell).strip().replace(".", "", 1).replace("-", "", 1).isdigit() for cell in row[:2])


def _guess_unit(headers: Sequence[str], explicit: str = "") -> str:
    if explicit:
        return explicit
    joined = " ".join(headers).lower()
    if "mwb" in joined:
        return "mWb"
    if "nt" in joined:
        return "nT"
    if "g)" in joined or "gauss" in joined:
        return "G"
    return "mT"


def _record_from_mapping(
    mapping: Dict[str, Any],
    sequence: int,
    source: str,
    headers: Sequence[str] = (),
) -> Dict[str, Any]:
    unit = str(mapping.get("field_unit") or _guess_unit(headers)).strip() or "mT"
    timestamp = _safe_float(mapping.get("timestamp_s"), float(sequence))
    field_x = _safe_float(mapping.get("field_x"))
    field_y = _safe_float(mapping.get("field_y"))
    field_z = _safe_float(mapping.get("field_z"))
    field_total = _safe_float(mapping.get("field_total"))

    if field_total == 0.0 and any(v != 0.0 for v in (field_x, field_y, field_z)):
        field_total = math.sqrt(field_x * field_x + field_y * field_y + field_z * field_z)
    if field_x == 0.0 and field_total != 0.0:
        field_x = field_total

    seq = _safe_int(mapping.get("sequence"), sequence)
    src = str(mapping.get("source") or source)
    return {
        "session_id": _safe_int(mapping.get("session_id"), 0),
        "sequence": seq,
        "timestamp_s": timestamp,
        "x_mm": _safe_float(mapping.get("x_mm"), float("nan")),
        "y_mm": _safe_float(mapping.get("y_mm"), float("nan")),
        "z_mm": _safe_float(mapping.get("z_mm"), float("nan")),
        "field_x": field_x,
        "field_y": field_y,
        "field_z": field_z,
        "field_total": field_total,
        "field_x_mt": field_x,
        "field_y_mt": field_y,
        "field_z_mt": field_z,
        "field_total_mt": field_total,
        "field_mt": field_total,
        "freq_hz": _safe_float(mapping.get("freq_hz")),
        "temp_c": _safe_float(mapping.get("temp_c")),
        "source": src,
        "field_unit": unit,
    }


def records_to_review_array(records: Iterable[Dict[str, Any]]) -> np.ndarray:
    rows = []
    for idx, record in enumerate(records, start=1):
        rows.append(_record_from_mapping(record, idx, str(record.get("source") or "realtime")))
    if not rows:
        return _empty_array()
    return np.array([tuple(row[name] for name, _ in REVIEW_DTYPE) for row in rows], dtype=REVIEW_DTYPE)


def load_review_file(path: Path) -> Optional[np.ndarray]:
    """Load one CSV/TXT historical data file into the normalized review dtype."""
    if not path.exists():
        return None

    with open(path, "r", encoding="utf-8-sig", newline="") as f:
        sample = f.readline()
        if not sample:
            return None
        delimiter = "\t" if "\t" in sample else ","
        f.seek(0)
        reader = csv.reader(f, delimiter=delimiter)
        rows = [row for row in reader if row]

    if not rows:
        return None

    source = _source_for_path(path)
    first = rows[0]
    has_header = _looks_like_header(first)
    if has_header:
        headers = first
        data_rows = rows[1:]
        header_map = [_canonical_header(h) for h in headers]
    else:
        headers = ["timestamp_s", "field_total", "freq_hz", "temp_c"]
        data_rows = rows
        header_map = headers

    records: List[Dict[str, Any]] = []
    for idx, row in enumerate(data_rows, start=1):
        mapping: Dict[str, Any] = {}
        for col_idx, value in enumerate(row):
            if col_idx >= len(header_map):
                continue
            key = header_map[col_idx]
            if key is None:
                continue
            mapping[key] = value
        records.append(_record_from_mapping(mapping, idx, source, headers=headers))

    if not records:
        return None
    return records_to_review_array(records)


def merge_review_arrays(arrays: Iterable[np.ndarray]) -> np.ndarray:
    chunks = [arr for arr in arrays if arr is not None and len(arr) > 0]
    if not chunks:
        return _empty_array()
    merged = np.concatenate(chunks)
    if "timestamp_s" in (merged.dtype.names or ()):
        merged.sort(order="timestamp_s")
    return merged


def load_review_files(paths: List[Path]) -> Tuple[np.ndarray, int]:
    """Load multiple files, normalize schemas, and sort by timestamp."""
    chunks: List[np.ndarray] = []
    ok_count = 0
    for p in paths:
        arr = load_review_file(p)
        if arr is not None and arr.size > 0:
            chunks.append(arr)
            ok_count += 1
    return merge_review_arrays(chunks), ok_count


def filter_review_data(
    arr: np.ndarray,
    *,
    sequence_start: Optional[int] = None,
    sequence_end: Optional[int] = None,
    time_start_s: Optional[float] = None,
    time_end_s: Optional[float] = None,
    source: Optional[str] = None,
    session_id: Optional[int] = None,
) -> np.ndarray:
    """Return a filtered view of a normalized review array.

    Time filters use seconds relative to the first sample in ``arr``.
    """
    if arr is None or len(arr) == 0:
        return _empty_array()
    mask = np.ones(len(arr), dtype=bool)
    if sequence_start is not None:
        mask &= arr["sequence"] >= sequence_start
    if sequence_end is not None:
        mask &= arr["sequence"] <= sequence_end
    if time_start_s is not None or time_end_s is not None:
        ts_rel = arr["timestamp_s"] - arr["timestamp_s"][0]
        if time_start_s is not None:
            mask &= ts_rel >= time_start_s
        if time_end_s is not None:
            mask &= ts_rel <= time_end_s
    if source and source != "all":
        mask &= arr["source"] == source
    if session_id:
        mask &= arr["session_id"] == session_id
    return arr[mask]


def primary_field_name(arr: np.ndarray) -> str:
    names = arr.dtype.names or ()
    for name in ("field_total", "field_total_mt", "field_mt", "field_x", "field_x_mt"):
        if name in names:
            return name
    return "field_total"


def _safe_channel_stats(arr: np.ndarray, name: str) -> dict:
    if name not in (arr.dtype.names or ()):
        return {"min": 0.0, "max": 0.0, "mean": 0.0, "std": 0.0}
    data = arr[name]
    valid = data[~np.isnan(data)]
    if valid.size == 0:
        return {"min": 0.0, "max": 0.0, "mean": 0.0, "std": 0.0}
    return {
        "min": float(np.min(valid)),
        "max": float(np.max(valid)),
        "mean": float(np.mean(valid)),
        "std": float(np.std(valid)),
    }


def get_review_summary(arr: np.ndarray) -> dict:
    """Return count/duration/basic statistics for a review dataset."""
    if arr is None or arr.size == 0:
        return {
            "count": 0,
            "duration_s": 0.0,
            "field_min": 0.0,
            "field_max": 0.0,
            "field_mean": 0.0,
            "field_unit": "",
            "channels": {},
        }
    ts = arr["timestamp_s"]
    field_key = primary_field_name(arr)
    field = arr[field_key]
    channels = {}
    for ch in ("field_x", "field_y", "field_z", "field_total", "freq_hz", "temp_c"):
        if ch in (arr.dtype.names or ()):
            channels[ch] = _safe_channel_stats(arr, ch)
            channels[ch].update(analyze_time_series(ts, arr[ch]))
    field_analysis = analyze_time_series(ts, field)
    units = [str(u) for u in np.unique(arr["field_unit"]) if str(u)]
    return {
        "count": int(arr.size),
        "duration_s": field_analysis["duration_s"],
        "field_min": float(np.nanmin(field)),
        "field_max": float(np.nanmax(field)),
        "field_mean": float(np.nanmean(field)),
        "field_std": field_analysis["std"],
        "field_rms": field_analysis["rms"],
        "field_peak_to_peak": field_analysis["peak_to_peak"],
        "sample_rate_hz": field_analysis["sample_rate_hz"],
        "field_unit": units[0] if len(units) == 1 else "/".join(units[:3]),
        "channels": channels,
    }


def export_review_selection_csv(path: Path, arr: np.ndarray) -> None:
    """Write a selected review dataset as UTF-8 BOM CSV."""
    headers = [
        "session_id", "sequence", "timestamp_s", "source",
        "field_total", "field_x", "field_y", "field_z", "field_unit",
        "freq_hz", "temp_c", "x_mm", "y_mm", "z_mm",
    ]
    with open(path, "w", encoding="utf-8-sig", newline="") as f:
        writer = csv.writer(f)
        writer.writerow(headers)
        for row in arr:
            writer.writerow([row[h] for h in headers])
