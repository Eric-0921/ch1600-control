"""Spatial scan helpers for heatmap/contour/3D surface review views."""

from __future__ import annotations

from typing import Tuple

import numpy as np

from data.review_loader import primary_field_name


def _spatial_points(arr: np.ndarray, value_key: str | None = None) -> Tuple[np.ndarray, np.ndarray, np.ndarray]:
    if arr is None or len(arr) == 0:
        return np.array([]), np.array([]), np.array([])
    for name in ("x_mm", "y_mm"):
        if name not in (arr.dtype.names or ()):
            raise ValueError("review data does not contain spatial x_mm/y_mm columns")
    key = value_key or primary_field_name(arr)
    if key not in (arr.dtype.names or ()):
        raise ValueError(f"review data does not contain value column {key!r}")

    x = np.asarray(arr["x_mm"], dtype=float)
    y = np.asarray(arr["y_mm"], dtype=float)
    v = np.asarray(arr[key], dtype=float)
    valid = np.isfinite(x) & np.isfinite(y) & np.isfinite(v)
    return x[valid], y[valid], v[valid]


def _average_duplicate_points(x: np.ndarray, y: np.ndarray, v: np.ndarray) -> Tuple[np.ndarray, np.ndarray, np.ndarray]:
    if len(x) == 0:
        return x, y, v
    points = {}
    for xi, yi, vi in zip(x, y, v):
        points.setdefault((float(xi), float(yi)), []).append(float(vi))
    xs = []
    ys = []
    values = []
    for (xi, yi), vals in points.items():
        xs.append(xi)
        ys.append(yi)
        values.append(float(np.mean(vals)))
    return np.asarray(xs, dtype=float), np.asarray(ys, dtype=float), np.asarray(values, dtype=float)


def build_heatmap_grid(
    arr: np.ndarray,
    *,
    value_key: str | None = None,
) -> Tuple[np.ndarray, np.ndarray, np.ndarray]:
    """Build a regular x/y grid from review data with x_mm/y_mm columns.

    Duplicate points on the same grid cell are averaged. Missing cells are NaN.
    This is intentionally data-only so GUI/rendering choices can stay flexible.
    """
    x, y, v = _spatial_points(arr, value_key)
    if len(x) == 0:
        return np.array([]), np.array([]), np.empty((0, 0))

    xs = np.unique(x)
    ys = np.unique(y)
    grid = np.full((len(ys), len(xs)), np.nan, dtype=float)
    counts = np.zeros((len(ys), len(xs)), dtype=int)
    x_index = {value: idx for idx, value in enumerate(xs)}
    y_index = {value: idx for idx, value in enumerate(ys)}
    for xi, yi, vi in zip(x, y, v):
        gx = x_index[xi]
        gy = y_index[yi]
        if np.isnan(grid[gy, gx]):
            grid[gy, gx] = 0.0
        grid[gy, gx] += float(vi)
        counts[gy, gx] += 1
    with np.errstate(invalid="ignore", divide="ignore"):
        grid = grid / counts
    return xs, ys, grid


def build_interpolated_heatmap_grid(
    arr: np.ndarray,
    *,
    value_key: str | None = None,
    resolution: int = 80,
    power: float = 2.0,
    max_distance: float | None = None,
) -> Tuple[np.ndarray, np.ndarray, np.ndarray]:
    """Build an IDW-interpolated x/y heatmap grid.

    This intentionally uses only NumPy so spatial review remains available
    without SciPy. Duplicate source points are averaged before interpolation.
    """
    x, y, v = _spatial_points(arr, value_key)
    x, y, v = _average_duplicate_points(x, y, v)
    if len(x) == 0:
        return np.array([]), np.array([]), np.empty((0, 0))
    if len(x) < 3:
        raise ValueError("interpolated heatmap requires at least 3 spatial points")

    resolution = int(resolution)
    if resolution < 2:
        raise ValueError("interpolated heatmap resolution must be >= 2")
    if power <= 0:
        raise ValueError("interpolated heatmap power must be > 0")

    x_min, x_max = float(np.min(x)), float(np.max(x))
    y_min, y_max = float(np.min(y)), float(np.max(y))
    if x_max == x_min:
        x_min -= 0.5
        x_max += 0.5
    if y_max == y_min:
        y_min -= 0.5
        y_max += 0.5

    xs = np.linspace(x_min, x_max, resolution)
    ys = np.linspace(y_min, y_max, resolution)
    gx, gy = np.meshgrid(xs, ys)
    grid = np.full(gx.shape, np.nan, dtype=float)

    for row in range(gx.shape[0]):
        dx = x - gx[row, :, None]
        dy = y - gy[row, :, None]
        dist = np.sqrt(dx * dx + dy * dy)
        exact = dist == 0.0
        if np.any(exact):
            exact_cols = np.where(np.any(exact, axis=1))[0]
            for col in exact_cols:
                grid[row, col] = float(v[exact[col]][0])
            pending = ~np.any(exact, axis=1)
            if not np.any(pending):
                continue
            dist_pending = dist[pending]
            cols = np.where(pending)[0]
        else:
            dist_pending = dist
            cols = np.arange(gx.shape[1])

        if max_distance is not None:
            outside = np.min(dist_pending, axis=1) > max_distance
        else:
            outside = np.zeros(dist_pending.shape[0], dtype=bool)

        with np.errstate(divide="ignore", invalid="ignore"):
            weights = 1.0 / np.power(dist_pending, power)
            values = np.sum(weights * v, axis=1) / np.sum(weights, axis=1)
        values[outside] = np.nan
        grid[row, cols] = values

    return xs, ys, grid


def build_surface_grid(
    arr: np.ndarray,
    *,
    value_key: str | None = None,
    resolution: int = 80,
    interpolated: bool = True,
) -> Tuple[np.ndarray, np.ndarray, np.ndarray]:
    """Build an x/y/z grid for 3D spatial scalar-field previews.

    The returned ``z_grid`` uses the same orientation as heatmaps:
    ``z_grid.shape == (len(ys), len(xs))``. GUI renderers that require
    ``(len(xs), len(ys))`` should transpose at the rendering boundary.
    """
    if interpolated:
        return build_interpolated_heatmap_grid(
            arr, value_key=value_key, resolution=resolution
        )
    return build_heatmap_grid(arr, value_key=value_key)
