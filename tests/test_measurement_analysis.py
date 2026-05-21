"""Measurement analysis helpers."""

from __future__ import annotations

import unittest

import numpy as np

from data.measurement_analysis import (
    analyze_spectrum,
    analyze_threshold_events,
    analyze_time_series,
    analyze_vector_components,
)
from data.spatial_analysis import analyze_spatial_grid, extract_profile


class TestMeasurementAnalysis(unittest.TestCase):
    def test_time_series_metrics_are_stable(self):
        ts = np.array([0.0, 0.5, 1.0, 1.5])
        vals = np.array([1.0, -1.0, 3.0, 5.0])
        result = analyze_time_series(ts, vals)
        self.assertEqual(result["count"], 4)
        self.assertAlmostEqual(result["sample_rate_hz"], 2.0)
        self.assertAlmostEqual(result["peak_to_peak"], 6.0)
        self.assertAlmostEqual(result["rms"], np.sqrt(np.mean(vals * vals)))

    def test_time_series_handles_empty_and_nan(self):
        result = analyze_time_series([0.0, 1.0], [float("nan"), float("nan")])
        self.assertEqual(result["count"], 0)
        self.assertEqual(result["rms"], 0.0)

    def test_threshold_events_closed_mode(self):
        result = analyze_threshold_events(
            [0.0, 1.0, 2.0, 3.0],
            [0.0, 2.0, 5.0, 1.0],
            low=0.0,
            high=3.0,
        )
        self.assertTrue(result["enabled"])
        self.assertEqual(result["ng_count"], 1)
        self.assertEqual(result["event_count"], 1)

    def test_vector_direction(self):
        result = analyze_vector_components([1.0, 1.0], [1.0, 1.0], [0.0, 0.0])
        self.assertAlmostEqual(result["direction_xy_deg"], 45.0)
        self.assertGreater(result["mean_total"], 1.0)

    def test_spectrum_finds_sine_frequency(self):
        sample_rate = 100.0
        ts = np.arange(0, 2.0, 1.0 / sample_rate)
        vals = np.sin(2 * np.pi * 5.0 * ts)
        result = analyze_spectrum(ts, vals)
        self.assertTrue(result["ok"], result.get("reason"))
        self.assertAlmostEqual(result["dominant_frequency_hz"], 5.0, delta=0.6)

    def test_spatial_grid_and_profile(self):
        xs = np.array([0.0, 1.0, 2.0])
        ys = np.array([0.0, 1.0])
        grid = np.array([[1.0, 2.0, 3.0], [2.0, 4.0, 6.0]])
        stats = analyze_spatial_grid(xs, ys, grid)
        self.assertEqual(stats["count"], 6)
        self.assertEqual(stats["hotspot"], (2.0, 1.0, 6.0))
        profile = extract_profile(xs, ys, grid, axis="x", coordinate=0.0)
        self.assertTrue(profile["ok"])
        self.assertAlmostEqual(profile["peak_to_peak"], 2.0)


if __name__ == "__main__":
    unittest.main()
