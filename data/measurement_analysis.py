"""科研级测量指标与频谱分析工具。"""

from __future__ import annotations

from typing import Any, Dict, Iterable, Mapping, Optional, Sequence

import numpy as np


def _finite_xy(timestamps: Sequence[float], values: Sequence[float]) -> tuple[np.ndarray, np.ndarray]:
    ts = np.asarray(timestamps, dtype=float)
    vals = np.asarray(values, dtype=float)
    if ts.size != vals.size:
        size = min(ts.size, vals.size)
        ts = ts[:size]
        vals = vals[:size]
    mask = np.isfinite(ts) & np.isfinite(vals)
    return ts[mask], vals[mask]


def estimate_sample_rate(timestamps: Sequence[float]) -> float:
    """按时间戳中位间隔估算有效采样率。"""
    ts = np.asarray(timestamps, dtype=float)
    ts = ts[np.isfinite(ts)]
    if ts.size < 2:
        return 0.0
    diffs = np.diff(np.sort(ts))
    diffs = diffs[np.isfinite(diffs) & (diffs > 0)]
    if diffs.size == 0:
        return 0.0
    return float(1.0 / np.median(diffs))


def analyze_time_series(
    timestamps: Sequence[float],
    values: Sequence[float],
) -> Dict[str, float]:
    """返回单通道时间序列的稳定统计指标。"""
    ts, vals = _finite_xy(timestamps, values)
    if vals.size == 0:
        return {
            "count": 0,
            "duration_s": 0.0,
            "sample_rate_hz": 0.0,
            "current": 0.0,
            "min": 0.0,
            "max": 0.0,
            "mean": 0.0,
            "std": 0.0,
            "rms": 0.0,
            "peak_to_peak": 0.0,
            "abs_peak": 0.0,
            "drift": 0.0,
            "slope": 0.0,
        }
    duration = float(np.max(ts) - np.min(ts)) if ts.size > 1 else 0.0
    drift = float(vals[-1] - vals[0]) if vals.size > 1 else 0.0
    slope = drift / duration if duration > 0 else 0.0
    v_min = float(np.min(vals))
    v_max = float(np.max(vals))
    return {
        "count": int(vals.size),
        "duration_s": duration,
        "sample_rate_hz": estimate_sample_rate(ts),
        "current": float(vals[-1]),
        "min": v_min,
        "max": v_max,
        "mean": float(np.mean(vals)),
        "std": float(np.std(vals)),
        "rms": float(np.sqrt(np.mean(vals * vals))),
        "peak_to_peak": float(v_max - v_min),
        "abs_peak": float(np.max(np.abs(vals))),
        "drift": drift,
        "slope": slope,
    }


def analyze_channels(
    timestamps: Sequence[float],
    channels: Mapping[str, Sequence[float]],
) -> Dict[str, Dict[str, float]]:
    """批量分析多个通道。"""
    return {name: analyze_time_series(timestamps, values) for name, values in channels.items()}


def analyze_vector_components(
    x_values: Sequence[float],
    y_values: Sequence[float],
    z_values: Optional[Sequence[float]] = None,
) -> Dict[str, float]:
    """计算二维/三维矢量方向与稳定性摘要。"""
    x = np.asarray(x_values, dtype=float)
    y = np.asarray(y_values, dtype=float)
    if z_values is None:
        z = np.zeros_like(x)
    else:
        z = np.asarray(z_values, dtype=float)
    size = min(x.size, y.size, z.size)
    if size == 0:
        return {
            "count": 0,
            "mean_total": 0.0,
            "direction_xy_deg": 0.0,
            "inclination_deg": 0.0,
            "direction_std_deg": 0.0,
            "x_share": 0.0,
            "y_share": 0.0,
            "z_share": 0.0,
        }
    x = x[:size]
    y = y[:size]
    z = z[:size]
    mask = np.isfinite(x) & np.isfinite(y) & np.isfinite(z)
    x = x[mask]
    y = y[mask]
    z = z[mask]
    if x.size == 0:
        return analyze_vector_components([], [])
    total = np.sqrt(x * x + y * y + z * z)
    finite_total = total[np.isfinite(total)]
    mean_total = float(np.mean(finite_total)) if finite_total.size else 0.0
    mean_x = float(np.mean(x))
    mean_y = float(np.mean(y))
    mean_z = float(np.mean(z))
    denom = abs(mean_x) + abs(mean_y) + abs(mean_z)
    angles = np.degrees(np.arctan2(y, x))
    direction_std = float(np.std(angles)) if angles.size else 0.0
    xy_norm = float(np.hypot(mean_x, mean_y))
    return {
        "count": int(x.size),
        "mean_total": mean_total,
        "direction_xy_deg": float(np.degrees(np.arctan2(mean_y, mean_x))),
        "inclination_deg": float(np.degrees(np.arctan2(mean_z, xy_norm))) if xy_norm or mean_z else 0.0,
        "direction_std_deg": direction_std,
        "x_share": abs(mean_x) / denom if denom else 0.0,
        "y_share": abs(mean_y) / denom if denom else 0.0,
        "z_share": abs(mean_z) / denom if denom else 0.0,
    }


def analyze_threshold_events(
    timestamps: Sequence[float],
    values: Sequence[float],
    *,
    low: float,
    high: float,
    absolute: bool = False,
    mode: str = "closed",
) -> Dict[str, Any]:
    """统计阈值 OK/NG 事件，closed 表示区间内 OK，open 表示区间内 NG。"""
    ts, vals = _finite_xy(timestamps, values)
    if ts.size == 0 or vals.size == 0 or (low == 0.0 and high == 0.0):
        return {"enabled": False, "ng_count": 0, "event_count": 0, "ng_ratio": 0.0, "longest_event_s": 0.0}
    if absolute:
        vals = np.abs(vals)
        low = abs(low)
        high = abs(high)
    if low > high:
        low, high = high, low
    in_range = (vals >= low) & (vals <= high)
    ng_mask = in_range if mode == "open" else ~in_range
    ng_count = int(np.count_nonzero(ng_mask))
    event_count = 0
    longest = 0.0
    start_idx: Optional[int] = None
    for idx, is_ng in enumerate(ng_mask):
        if is_ng and start_idx is None:
            start_idx = idx
            event_count += 1
        elif not is_ng and start_idx is not None:
            longest = max(longest, float(ts[idx - 1] - ts[start_idx]))
            start_idx = None
    if start_idx is not None:
        longest = max(longest, float(ts[-1] - ts[start_idx]))
    return {
        "enabled": True,
        "ng_count": ng_count,
        "event_count": event_count,
        "ng_ratio": float(ng_count / len(ng_mask)) if len(ng_mask) else 0.0,
        "longest_event_s": longest,
    }


def analyze_spectrum(
    timestamps: Sequence[float],
    values: Sequence[float],
    *,
    peak_count: int = 5,
) -> Dict[str, Any]:
    """计算单边 FFT 幅度谱和主峰列表。"""
    ts, vals = _finite_xy(timestamps, values)
    if vals.size < 4:
        return {"ok": False, "reason": "至少需要 4 个有效采样点", "frequencies": np.array([]), "amplitudes": np.array([])}
    sample_rate = estimate_sample_rate(ts)
    if sample_rate <= 0.0:
        return {"ok": False, "reason": "无法从时间戳估算采样率", "frequencies": np.array([]), "amplitudes": np.array([])}
    diffs = np.diff(np.sort(ts))
    diffs = diffs[np.isfinite(diffs) & (diffs > 0)]
    if diffs.size and np.std(diffs) / np.mean(diffs) > 0.2:
        return {"ok": False, "reason": "时间戳间隔不均匀，暂不执行 FFT", "frequencies": np.array([]), "amplitudes": np.array([])}
    centered = vals - np.mean(vals)
    window = np.hanning(centered.size)
    coherent_gain = float(np.sum(window) / len(window)) or 1.0
    fft_vals = np.fft.rfft(centered * window)
    freqs = np.fft.rfftfreq(centered.size, d=1.0 / sample_rate)
    amps = np.abs(fft_vals) * 2.0 / (centered.size * coherent_gain)
    if amps.size:
        amps[0] = 0.0
    order = np.argsort(amps)[::-1]
    peaks = []
    for idx in order[:max(0, peak_count)]:
        if idx == 0 or not np.isfinite(amps[idx]):
            continue
        peaks.append({"frequency_hz": float(freqs[idx]), "amplitude": float(amps[idx])})
    return {
        "ok": True,
        "reason": "",
        "sample_rate_hz": sample_rate,
        "resolution_hz": float(freqs[1] - freqs[0]) if freqs.size > 1 else 0.0,
        "rms": float(np.sqrt(np.mean(vals * vals))),
        "dominant_frequency_hz": peaks[0]["frequency_hz"] if peaks else 0.0,
        "peaks": peaks,
        "frequencies": freqs,
        "amplitudes": amps,
    }
