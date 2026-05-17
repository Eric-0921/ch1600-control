"""CH-1600 历史数据加载器

支持 m1600 生成的 CSV 和 DataReader2 生成的 TXT 回看。
"""

from __future__ import annotations

from pathlib import Path
from typing import List, Optional, Tuple

import numpy as np


# 列名到 dtype 的映射 (有序, 决定输出数组列顺序)
_COLUMN_MAP = {
    "timestamp_s": ("timestamp_s", "f8"),
    "field_mt": ("field_total_mt", "f8"),
    "field_total_mt": ("field_total_mt", "f8"),
    "field_x_mt": ("field_x_mt", "f8"),
    "field_y_mt": ("field_y_mt", "f8"),
    "field_z_mt": ("field_z_mt", "f8"),
    "freq_hz": ("freq_hz", "f8"),
    "temp_c": ("temp_c", "f8"),
}

# 后备读取映射: 如果 genfromtxt names=True 失败, 按位置映射前 N 列
_FALLBACK_COLUMNS = ["timestamp_s", "field_mt", "freq_hz", "temp_c"]


def _build_dtype_from_headers(headers: List[str]) -> List[Tuple[str, str]]:
    """根据 CSV 首行表头构建结构化 dtype 列表。"""
    dtype: List[Tuple[str, str]] = []
    seen = set()
    for h in headers:
        h = h.strip()
        entry = _COLUMN_MAP.get(h)
        if entry and entry[0] not in seen:
            dtype.append(entry)
            seen.add(entry[0])
    # 若未匹配到任何已知列, 退回到默认 4 列
    if not dtype:
        dtype = [("timestamp_s", "f8"), ("field_mt", "f8"), ("freq_hz", "f8"), ("temp_c", "f8")]
    return dtype


def _fallback_dtype() -> List[Tuple[str, str]]:
    return [("timestamp_s", "f8"), ("field_mt", "f8"), ("freq_hz", "f8"), ("temp_c", "f8")]


def load_review_file(path: Path) -> Optional[np.ndarray]:
    """加载单个历史数据文件, 返回结构化数组或 None。

    dtype 根据 CSV 首行表头动态推断, 支持一维/二维/三维 CSV。
    """
    if not path.exists():
        return None

    # 探测分隔符并读取首行表头
    with open(path, "r", encoding="utf-8-sig") as f:
        first = f.readline()
    delimiter = "\t" if "\t" in first else ","
    headers = [h.strip() for h in first.strip().split(delimiter)]
    dtype = _build_dtype_from_headers(headers)

    try:
        arr = np.genfromtxt(
            path,
            delimiter=delimiter,
            names=True,
            dtype=dtype,
            encoding="utf-8-sig",
            invalid_raise=False,
        )
    except ValueError:
        # 列名不匹配时, 尝试按位置读取前 N 列
        fb_dtype = _fallback_dtype()
        usecols = tuple(range(len(fb_dtype)))
        arr = np.genfromtxt(
            path,
            delimiter=delimiter,
            skip_header=1,
            usecols=usecols,
            dtype=fb_dtype,
            encoding="utf-8-sig",
            invalid_raise=False,
        )

    if arr is None or arr.size == 0:
        return None

    # 确保一维数组
    if arr.ndim == 0:
        arr = np.array([arr], dtype=arr.dtype)

    return arr


def load_review_files(paths: List[Path]) -> Tuple[np.ndarray, int]:
    """批量加载多个文件, 按时间戳拼接, 返回 (合并数组, 成功文件数)。

    文件间按 timestamp_s 排序。
    """
    chunks: List[np.ndarray] = []
    ok_count = 0
    for p in paths:
        arr = load_review_file(p)
        if arr is not None and arr.size > 0:
            chunks.append(arr)
            ok_count += 1

    if not chunks:
        return np.array([], dtype=_fallback_dtype()), 0

    # 统一 dtype: 取所有 chunk 列名的并集
    all_names = set()
    for arr in chunks:
        all_names.update(arr.dtype.names or ())
    # 保持固定顺序
    ordered_names = [n for n, _ in _fallback_dtype()]
    for extra in ("field_total_mt", "field_x_mt", "field_y_mt", "field_z_mt"):
        if extra in all_names and extra not in ordered_names:
            ordered_names.append(extra)
    # 再补充其他可能出现的列
    for n in all_names:
        if n not in ordered_names:
            ordered_names.append(n)

    unified_dtype = [(n, "f8") for n in ordered_names]

    # 将每个 chunk 转换为统一 dtype
    unified_chunks = []
    for arr in chunks:
        new_arr = np.empty(arr.shape, dtype=unified_dtype)
        for name in arr.dtype.names or ():
            if name in new_arr.dtype.names:
                new_arr[name] = arr[name]
        for name in new_arr.dtype.names or ():
            if name not in (arr.dtype.names or ()):
                new_arr[name] = 0.0
        unified_chunks.append(new_arr)

    merged = np.concatenate(unified_chunks)
    merged.sort(order="timestamp_s")
    return merged, ok_count


def _safe_channel_stats(arr: np.ndarray, name: str) -> dict:
    """安全地获取某通道统计信息。"""
    if name not in (arr.dtype.names or ()):
        return {"min": 0.0, "max": 0.0, "mean": 0.0, "std": 0.0}
    data = arr[name]
    # 过滤 NaN
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
    """返回数据摘要（支持多通道）。"""
    if arr is None or arr.size == 0:
        return {
            "count": 0,
            "duration_s": 0.0,
            "field_min": 0.0,
            "field_max": 0.0,
            "field_mean": 0.0,
            "channels": {},
        }
    ts = arr["timestamp_s"]
    # 优先使用 field_total_mt, 否则回退到 field_mt (向后兼容)
    if "field_total_mt" in (arr.dtype.names or ()):
        field = arr["field_total_mt"]
    else:
        field = arr["field_mt"]

    # 收集所有可用的 field_* 通道统计
    channels = {}
    for ch in ("field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt", "field_mt"):
        if ch in (arr.dtype.names or ()):
            channels[ch] = _safe_channel_stats(arr, ch)
    for ch in ("freq_hz", "temp_c"):
        if ch in (arr.dtype.names or ()):
            channels[ch] = _safe_channel_stats(arr, ch)

    return {
        "count": int(arr.size),
        "duration_s": float(ts[-1] - ts[0]) if arr.size > 1 else 0.0,
        "field_min": float(np.min(field)),
        "field_max": float(np.max(field)),
        "field_mean": float(np.mean(field)),
        "channels": channels,
    }
