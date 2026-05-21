"""Small self-contained HTML report exporter for review datasets."""

from __future__ import annotations

import html
from pathlib import Path
from typing import Any, Dict, Optional

import numpy as np

from data.review_loader import get_review_summary, primary_field_name
from data.measurement_analysis import analyze_threshold_events
from data.spatial import build_heatmap_grid, build_interpolated_heatmap_grid
from data.spatial_analysis import analyze_spatial_grid, extract_profile


def _line_svg(arr: np.ndarray, width: int = 900, height: int = 260) -> str:
    if arr is None or len(arr) == 0:
        return "<p>No data.</p>"
    field_key = primary_field_name(arr)
    xs = arr["timestamp_s"] - arr["timestamp_s"][0]
    ys = arr[field_key]
    valid = ~(np.isnan(xs) | np.isnan(ys))
    xs = xs[valid]
    ys = ys[valid]
    if len(xs) == 0:
        return "<p>No numeric data.</p>"
    max_points = 1200
    if len(xs) > max_points:
        idx = np.linspace(0, len(xs) - 1, max_points).astype(int)
        xs = xs[idx]
        ys = ys[idx]
    x_min, x_max = float(xs.min()), float(xs.max())
    y_min, y_max = float(ys.min()), float(ys.max())
    if x_max == x_min:
        x_max = x_min + 1.0
    if y_max == y_min:
        y_max = y_min + 1.0
    pad = 36
    pts = []
    for x, y in zip(xs, ys):
        px = pad + (float(x) - x_min) / (x_max - x_min) * (width - 2 * pad)
        py = height - pad - (float(y) - y_min) / (y_max - y_min) * (height - 2 * pad)
        pts.append(f"{px:.1f},{py:.1f}")
    polyline = " ".join(pts)
    return f"""
<svg viewBox="0 0 {width} {height}" width="100%" height="{height}" role="img">
  <rect x="0" y="0" width="{width}" height="{height}" fill="#ffffff" />
  <line x1="{pad}" y1="{height-pad}" x2="{width-pad}" y2="{height-pad}" stroke="#888" />
  <line x1="{pad}" y1="{pad}" x2="{pad}" y2="{height-pad}" stroke="#888" />
  <polyline fill="none" stroke="#0080c8" stroke-width="1.5" points="{polyline}" />
  <text x="{pad}" y="{height-8}" font-size="12">0 s</text>
  <text x="{width-pad-60}" y="{height-8}" font-size="12">{x_max:.3f} s</text>
  <text x="6" y="{pad+4}" font-size="12">{y_max:.6g}</text>
  <text x="6" y="{height-pad}" font-size="12">{y_min:.6g}</text>
</svg>
"""


def evaluate_threshold(
    arr: np.ndarray,
    *,
    low: float,
    high: float,
    channel: str = "field_total",
    absolute: bool = False,
    mode: str = "closed",
) -> Dict[str, Any]:
    """Evaluate threshold status for a report dataset."""
    if arr is None or len(arr) == 0:
        return {"enabled": False, "status": "NO_DATA", "count": 0}
    if low == 0.0 and high == 0.0:
        return {"enabled": False, "status": "DISABLED", "count": len(arr)}

    names = arr.dtype.names or ()
    value_key = channel if channel in names else primary_field_name(arr)
    values = np.asarray(arr[value_key], dtype=float)
    valid = values[np.isfinite(values)]
    if len(valid) == 0:
        return {"enabled": False, "status": "NO_NUMERIC_DATA", "count": len(arr), "channel": value_key}

    if absolute:
        valid = np.abs(valid)
        low = abs(low)
        high = abs(high)
    if low > high:
        low, high = high, low

    in_range = (valid >= low) & (valid <= high)
    open_mode = mode == "open"
    ok_mask = ~in_range if open_mode else in_range
    ok_count = int(np.count_nonzero(ok_mask))
    ng_count = int(len(valid) - ok_count)
    return {
        "enabled": True,
        "status": "OK" if ng_count == 0 else "NG",
        "count": len(arr),
        "valid_count": int(len(valid)),
        "ok_count": ok_count,
        "ng_count": ng_count,
        "low": float(low),
        "high": float(high),
        "channel": value_key,
        "absolute": bool(absolute),
        "mode": "open" if open_mode else "closed",
    }


def _threshold_table(threshold: Optional[Dict[str, Any]]) -> str:
    if not threshold:
        return "<p>未配置阈值判定。</p>"
    if not threshold.get("enabled"):
        return f"<p>阈值判定未启用：{html.escape(str(threshold.get('status', 'DISABLED')))}</p>"
    rows = [
        ("结果", threshold.get("status", "")),
        ("通道", threshold.get("channel", "")),
        ("范围", f"{threshold.get('low', '')} .. {threshold.get('high', '')}"),
        ("模式", threshold.get("mode", "")),
        ("ABS", threshold.get("absolute", False)),
        ("有效点数", threshold.get("valid_count", "")),
        ("OK 点数", threshold.get("ok_count", "")),
        ("NG 点数", threshold.get("ng_count", "")),
    ]
    return "<table>" + "\n".join(
        f"<tr><th>{html.escape(str(k))}</th><td>{html.escape(str(v))}</td></tr>"
        for k, v in rows
    ) + "</table>"


def _advanced_summary_rows(summary: Dict[str, Any]) -> str:
    rows = [
        ("磁场 RMS", f"{summary.get('field_rms', 0.0):.9g} {summary.get('field_unit', '')}"),
        ("磁场标准差", f"{summary.get('field_std', 0.0):.9g} {summary.get('field_unit', '')}"),
        ("峰峰值", f"{summary.get('field_peak_to_peak', 0.0):.9g} {summary.get('field_unit', '')}"),
        ("估算采样率", f"{summary.get('sample_rate_hz', 0.0):.9g} Hz"),
    ]
    return "\n".join(
        f"<tr><th>{html.escape(str(k))}</th><td>{html.escape(str(v))}</td></tr>"
        for k, v in rows
    )


def _threshold_event_rows(arr: np.ndarray, threshold: Optional[Dict[str, Any]]) -> str:
    if not threshold or not threshold.get("enabled") or arr is None or len(arr) == 0:
        return ""
    channel = str(threshold.get("channel") or primary_field_name(arr))
    if channel not in (arr.dtype.names or ()):
        channel = primary_field_name(arr)
    events = analyze_threshold_events(
        arr["timestamp_s"],
        arr[channel],
        low=float(threshold.get("low", 0.0)),
        high=float(threshold.get("high", 0.0)),
        absolute=bool(threshold.get("absolute", False)),
        mode=str(threshold.get("mode", "closed")),
    )
    if not events.get("enabled"):
        return ""
    rows = [
        ("超限点数", events.get("ng_count", 0)),
        ("超限事件数", events.get("event_count", 0)),
        ("超限占比", f"{float(events.get('ng_ratio', 0.0)) * 100.0:.4g}%"),
        ("最长超限区间", f"{events.get('longest_event_s', 0.0):.6g} s"),
    ]
    return "<h2>阈值事件摘要</h2><table>" + "\n".join(
        f"<tr><th>{html.escape(str(k))}</th><td>{html.escape(str(v))}</td></tr>"
        for k, v in rows
    ) + "</table>"


def _spatial_summary_table(arr: np.ndarray, value_key: str | None = None) -> str:
    try:
        xs, ys, grid = build_interpolated_heatmap_grid(arr, value_key=value_key, resolution=80)
    except ValueError:
        return ""
    stats = analyze_spatial_grid(xs, ys, grid)
    profile = extract_profile(xs, ys, grid, axis="x")
    rows = [
        ("有效格点", stats["count"]),
        ("区域最小值", f"{stats['min']:.9g}"),
        ("区域最大值", f"{stats['max']:.9g}"),
        ("区域平均值", f"{stats['mean']:.9g}"),
        ("区域标准差", f"{stats['std']:.9g}"),
        ("均匀性 pk-pk/mean", f"{stats['uniformity_pct']:.6g}%"),
        ("最大梯度", f"{stats['gradient_max']:.9g}"),
        ("热点坐标", f"X={stats['hotspot'][0]:.6g}, Y={stats['hotspot'][1]:.6g}, V={stats['hotspot'][2]:.9g}"),
        ("冷点坐标", f"X={stats['coldspot'][0]:.6g}, Y={stats['coldspot'][1]:.6g}, V={stats['coldspot'][2]:.9g}"),
    ]
    if profile.get("ok"):
        rows.append(("中心剖面峰峰值", f"{profile['peak_to_peak']:.9g}"))
    return "<h2>空间扫描摘要</h2><table>" + "\n".join(
        f"<tr><th>{html.escape(str(k))}</th><td>{html.escape(str(v))}</td></tr>"
        for k, v in rows
    ) + "</table>"


def _heat_color(value: float, v_min: float, v_max: float) -> str:
    if v_max <= v_min:
        ratio = 0.5
    else:
        ratio = (value - v_min) / (v_max - v_min)
    ratio = min(1.0, max(0.0, float(ratio)))
    # Compact blue -> cyan -> yellow -> red palette, readable on white reports.
    stops = [
        (0.0, (33, 102, 172)),
        (0.35, (103, 169, 207)),
        (0.65, (255, 255, 191)),
        (1.0, (178, 24, 43)),
    ]
    for idx in range(len(stops) - 1):
        left_pos, left_rgb = stops[idx]
        right_pos, right_rgb = stops[idx + 1]
        if ratio <= right_pos:
            local = (ratio - left_pos) / (right_pos - left_pos)
            rgb = tuple(
                int(round(left_rgb[channel] + (right_rgb[channel] - left_rgb[channel]) * local))
                for channel in range(3)
            )
            return f"rgb({rgb[0]},{rgb[1]},{rgb[2]})"
    r, g, b = stops[-1][1]
    return f"rgb({r},{g},{b})"


def heatmap_svg(
    arr: np.ndarray,
    *,
    value_key: str | None = None,
    interpolated: bool = True,
    resolution: int = 80,
    width: int = 560,
    height: int = 420,
) -> str:
    """Render a spatial heatmap as a small self-contained SVG fragment."""
    try:
        if interpolated:
            xs, ys, grid = build_interpolated_heatmap_grid(
                arr, value_key=value_key, resolution=resolution
            )
        else:
            xs, ys, grid = build_heatmap_grid(arr, value_key=value_key)
    except ValueError:
        return ""
    if len(xs) == 0 or len(ys) == 0 or grid.size == 0:
        return ""

    finite = grid[np.isfinite(grid)]
    if finite.size == 0:
        return ""
    v_min = float(finite.min())
    v_max = float(finite.max())
    pad_left = 54
    pad_bottom = 42
    pad_top = 18
    pad_right = 86
    plot_w = width - pad_left - pad_right
    plot_h = height - pad_top - pad_bottom
    cell_w = plot_w / max(1, len(xs))
    cell_h = plot_h / max(1, len(ys))

    rects = []
    for y_idx in range(len(ys)):
        for x_idx in range(len(xs)):
            value = float(grid[y_idx, x_idx])
            if not np.isfinite(value):
                continue
            x = pad_left + x_idx * cell_w
            y = pad_top + (len(ys) - 1 - y_idx) * cell_h
            rects.append(
                f'<rect x="{x:.2f}" y="{y:.2f}" width="{cell_w + 0.2:.2f}" '
                f'height="{cell_h + 0.2:.2f}" fill="{_heat_color(value, v_min, v_max)}" />'
            )
    if not rects:
        return ""
    key = value_key or primary_field_name(arr)
    x_label = f"{float(xs[0]):.6g} .. {float(xs[-1]):.6g} mm"
    y_label = f"{float(ys[0]):.6g} .. {float(ys[-1]):.6g} mm"
    legend_x = width - pad_right + 28
    legend_rects = []
    for idx in range(40):
        ratio = idx / 39
        value = v_min + (v_max - v_min) * ratio
        y = pad_top + (39 - idx) * (plot_h / 40)
        legend_rects.append(
            f'<rect x="{legend_x}" y="{y:.2f}" width="18" height="{plot_h / 40 + 0.3:.2f}" '
            f'fill="{_heat_color(value, v_min, v_max)}" />'
        )
    return f"""
<svg viewBox="0 0 {width} {height}" width="100%" height="{height}" role="img">
  <rect x="0" y="0" width="{width}" height="{height}" fill="#ffffff" />
  <g>{''.join(rects)}</g>
  <rect x="{pad_left}" y="{pad_top}" width="{plot_w}" height="{plot_h}" fill="none" stroke="#666" />
  <line x1="{pad_left}" y1="{height-pad_bottom}" x2="{pad_left + plot_w}" y2="{height-pad_bottom}" stroke="#666" />
  <line x1="{pad_left}" y1="{pad_top}" x2="{pad_left}" y2="{height-pad_bottom}" stroke="#666" />
  <text x="{pad_left}" y="{height-12}" font-size="12">X: {html.escape(x_label)}</text>
  <text x="8" y="{pad_top+12}" font-size="12">Y: {html.escape(y_label)}</text>
  <text x="{pad_left}" y="14" font-size="12">Value: {html.escape(str(key))}</text>
  <g>{''.join(legend_rects)}</g>
  <rect x="{legend_x}" y="{pad_top}" width="18" height="{plot_h}" fill="none" stroke="#666" />
  <text x="{legend_x + 24}" y="{pad_top+8}" font-size="12">{v_max:.6g}</text>
  <text x="{legend_x + 24}" y="{height-pad_bottom}" font-size="12">{v_min:.6g}</text>
</svg>
"""


def export_html_report(
    path: Path | str,
    arr: np.ndarray,
    *,
    metadata: Optional[Dict[str, Any]] = None,
    threshold: Optional[Dict[str, Any]] = None,
    include_heatmap: bool = True,
    heatmap_value_key: str | None = None,
) -> None:
    """Export a lightweight HTML report with provenance-friendly metadata."""
    path = Path(path)
    metadata = metadata or {}
    summary = get_review_summary(arr)
    meta_rows = "\n".join(
        f"<tr><th>{html.escape(str(k))}</th><td>{html.escape(str(v))}</td></tr>"
        for k, v in metadata.items()
    )
    heatmap_fragment = heatmap_svg(arr, value_key=heatmap_value_key) if include_heatmap else ""
    heatmap_section = ""
    if heatmap_fragment:
        heatmap_section = f"""
  <h2>空间热图</h2>
  <div class="chart">{heatmap_fragment}</div>
  {_spatial_summary_table(arr, heatmap_value_key)}
"""
    body = f"""<!doctype html>
<html lang="zh-CN">
<head>
  <meta charset="utf-8">
  <title>m1600 CH-1600 Report</title>
  <style>
    body {{ font-family: Segoe UI, Microsoft YaHei, sans-serif; margin: 24px; color: #222; }}
    h1 {{ font-size: 24px; margin: 0 0 16px; }}
    table {{ border-collapse: collapse; margin: 12px 0 20px; width: 100%; max-width: 900px; }}
    th, td {{ border: 1px solid #ccc; padding: 6px 8px; text-align: left; }}
    th {{ background: #f3f6f8; width: 220px; }}
    .chart {{ max-width: 980px; border: 1px solid #ddd; padding: 8px; }}
  </style>
</head>
<body>
  <h1>m1600 CH-1600 测量报告</h1>
  <h2>统计摘要</h2>
  <table>
    <tr><th>数据点数</th><td>{summary['count']}</td></tr>
    <tr><th>时长</th><td>{summary['duration_s']:.6f} s</td></tr>
    <tr><th>磁场最小值</th><td>{summary['field_min']:.9g} {html.escape(summary.get('field_unit', ''))}</td></tr>
    <tr><th>磁场最大值</th><td>{summary['field_max']:.9g} {html.escape(summary.get('field_unit', ''))}</td></tr>
    <tr><th>磁场平均值</th><td>{summary['field_mean']:.9g} {html.escape(summary.get('field_unit', ''))}</td></tr>
    {_advanced_summary_rows(summary)}
  </table>
  <h2>阈值判定</h2>
  {_threshold_table(threshold)}
  {_threshold_event_rows(arr, threshold)}
  <h2>测量曲线</h2>
  <div class="chart">{_line_svg(arr)}</div>
  {heatmap_section}
  <h2>元数据 / Provenance</h2>
  <table>{meta_rows}</table>
</body>
</html>
"""
    path.parent.mkdir(parents=True, exist_ok=True)
    path.write_text(body, encoding="utf-8")
