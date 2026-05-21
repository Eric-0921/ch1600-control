"""空间扫描数据判定与剖面分析。"""

from __future__ import annotations

from typing import Any, Dict, Literal

import numpy as np


def analyze_spatial_grid(xs: np.ndarray, ys: np.ndarray, grid: np.ndarray) -> Dict[str, Any]:
    """返回热图/曲面网格的区域统计、均匀性和热点坐标。"""
    arr = np.asarray(grid, dtype=float)
    finite = arr[np.isfinite(arr)]
    if finite.size == 0:
        return {
            "count": 0,
            "min": 0.0,
            "max": 0.0,
            "mean": 0.0,
            "std": 0.0,
            "uniformity_pct": 0.0,
            "gradient_max": 0.0,
            "hotspot": (0.0, 0.0, 0.0),
            "coldspot": (0.0, 0.0, 0.0),
        }
    xs_arr = np.asarray(xs, dtype=float)
    ys_arr = np.asarray(ys, dtype=float)
    max_idx = np.unravel_index(int(np.nanargmax(arr)), arr.shape)
    min_idx = np.unravel_index(int(np.nanargmin(arr)), arr.shape)
    mean = float(np.mean(finite))
    peak_to_peak = float(np.max(finite) - np.min(finite))
    uniformity = 0.0 if mean == 0.0 else float((peak_to_peak / abs(mean)) * 100.0)
    try:
        gy, gx = np.gradient(arr.astype(float))
        grad = np.sqrt(gx * gx + gy * gy)
        gradient_max = float(np.nanmax(grad))
    except Exception:
        gradient_max = 0.0
    return {
        "count": int(finite.size),
        "min": float(np.min(finite)),
        "max": float(np.max(finite)),
        "mean": mean,
        "std": float(np.std(finite)),
        "uniformity_pct": uniformity,
        "gradient_max": gradient_max,
        "hotspot": (
            float(xs_arr[max_idx[1]]) if xs_arr.size else 0.0,
            float(ys_arr[max_idx[0]]) if ys_arr.size else 0.0,
            float(arr[max_idx]),
        ),
        "coldspot": (
            float(xs_arr[min_idx[1]]) if xs_arr.size else 0.0,
            float(ys_arr[min_idx[0]]) if ys_arr.size else 0.0,
            float(arr[min_idx]),
        ),
    }


def extract_profile(
    xs: np.ndarray,
    ys: np.ndarray,
    grid: np.ndarray,
    *,
    axis: Literal["x", "y"] = "x",
    coordinate: float | None = None,
) -> Dict[str, Any]:
    """从规则网格提取最近一条 X/Y 剖面线。"""
    xs_arr = np.asarray(xs, dtype=float)
    ys_arr = np.asarray(ys, dtype=float)
    arr = np.asarray(grid, dtype=float)
    if arr.size == 0 or xs_arr.size == 0 or ys_arr.size == 0:
        return {"ok": False, "reason": "空间网格为空", "axis_values": np.array([]), "values": np.array([])}
    if axis == "y":
        target = float(coordinate) if coordinate is not None else float(xs_arr[len(xs_arr) // 2])
        idx = int(np.argmin(np.abs(xs_arr - target)))
        axis_values = ys_arr
        values = arr[:, idx]
        actual = float(xs_arr[idx])
    else:
        target = float(coordinate) if coordinate is not None else float(ys_arr[len(ys_arr) // 2])
        idx = int(np.argmin(np.abs(ys_arr - target)))
        axis_values = xs_arr
        values = arr[idx, :]
        actual = float(ys_arr[idx])
    finite = values[np.isfinite(values)]
    if finite.size == 0:
        return {"ok": False, "reason": "剖面没有有效数值", "axis_values": axis_values, "values": values}
    return {
        "ok": True,
        "reason": "",
        "axis": axis,
        "coordinate": actual,
        "axis_values": axis_values,
        "values": values,
        "min": float(np.min(finite)),
        "max": float(np.max(finite)),
        "peak_to_peak": float(np.max(finite) - np.min(finite)),
        "mean": float(np.mean(finite)),
    }
