"""Review loader, selection, and reporting tests."""

from __future__ import annotations

import tempfile
import unittest
from pathlib import Path

import numpy as np

from data.reporting import evaluate_threshold, export_html_report, heatmap_svg
from data.review_loader import (
    export_review_selection_csv, filter_review_data, get_review_summary,
    load_review_files, records_to_review_array,
)
from data.spatial import build_heatmap_grid, build_interpolated_heatmap_grid, build_surface_grid


class TestReviewLoader(unittest.TestCase):
    def test_mixed_csv_schemas_merge_without_dtype_errors(self):
        with tempfile.TemporaryDirectory() as td:
            root = Path(td)
            one_d = root / "one_d.csv"
            three_d = root / "three_d.csv"
            one_d.write_text(
                "timestamp_s,field_total_mt,freq_hz,temp_c\n"
                "1.0,10.0,0,25.0\n",
                encoding="utf-8-sig",
            )
            three_d.write_text(
                "timestamp_s,field_x_mt,field_y_mt,field_z_mt,field_total_mt,freq_hz,temp_c\n"
                "2.0,1.0,2.0,3.0,3.741657,50,26.0\n",
                encoding="utf-8-sig",
            )

            data, count = load_review_files([one_d, three_d])

        self.assertEqual(count, 2)
        self.assertEqual(len(data), 2)
        self.assertIn("field_total", data.dtype.names)
        self.assertAlmostEqual(float(data["field_total"][0]), 10.0)
        self.assertAlmostEqual(float(data["field_z"][1]), 3.0)

    def test_datareader2_tab_text_and_selection_export(self):
        with tempfile.TemporaryDirectory() as td:
            root = Path(td)
            txt = root / "px1.txt"
            txt.write_text(
                "序号\t测量值\t测量时间\n"
                "1\t100.0\t2010-09-12 11:11:47\n"
                "2\t101.0\t2010-09-12 11:11:48\n"
                "3\t102.0\t2010-09-12 11:11:49\n",
                encoding="utf-8-sig",
            )
            data, count = load_review_files([txt])
            selected = filter_review_data(data, sequence_start=2, sequence_end=3)
            out = root / "selection.csv"
            export_review_selection_csv(out, selected)

            reloaded, reloaded_count = load_review_files([out])

        self.assertEqual(count, 1)
        self.assertEqual(len(selected), 2)
        self.assertEqual(reloaded_count, 1)
        self.assertEqual(len(reloaded), 2)
        self.assertEqual(str(data["source"][0]), "import_txt")

    def test_html_report_and_heatmap_grid(self):
        records = np.array([
            (1, 1, 0.0, 0.0, 0.0, np.nan, 1.0, 0.0, 0.0, 1.0, 1.0, 0.0, 0.0, 1.0, 1.0, 0.0, 25.0, "realtime", "mT"),
            (1, 2, 1.0, 1.0, 0.0, np.nan, 2.0, 0.0, 0.0, 2.0, 2.0, 0.0, 0.0, 2.0, 2.0, 0.0, 25.0, "realtime", "mT"),
            (1, 3, 2.0, 0.0, 1.0, np.nan, 3.0, 0.0, 0.0, 3.0, 3.0, 0.0, 0.0, 3.0, 3.0, 0.0, 25.0, "realtime", "mT"),
            (1, 4, 3.0, 1.0, 1.0, np.nan, 4.0, 0.0, 0.0, 4.0, 4.0, 0.0, 0.0, 4.0, 4.0, 0.0, 25.0, "realtime", "mT"),
        ], dtype=[
            ("session_id", "i8"), ("sequence", "i8"), ("timestamp_s", "f8"),
            ("x_mm", "f8"), ("y_mm", "f8"), ("z_mm", "f8"),
            ("field_x", "f8"), ("field_y", "f8"), ("field_z", "f8"), ("field_total", "f8"),
            ("field_x_mt", "f8"), ("field_y_mt", "f8"), ("field_z_mt", "f8"),
            ("field_total_mt", "f8"), ("field_mt", "f8"),
            ("freq_hz", "f8"), ("temp_c", "f8"), ("source", "U32"), ("field_unit", "U16"),
        ])
        with tempfile.TemporaryDirectory() as td:
            report = Path(td) / "report.html"
            threshold = evaluate_threshold(records, low=0.0, high=4.5, channel="field_total")
            export_html_report(report, records, metadata={"case": "unit"}, threshold=threshold)
            xs, ys, grid = build_heatmap_grid(records)
            ixs, iys, igrid = build_interpolated_heatmap_grid(records, resolution=12)
            sxs, sys, surface = build_surface_grid(records, resolution=12)
            svg = heatmap_svg(records, resolution=12)
            report_text = report.read_text(encoding="utf-8")
            report_exists = report.exists()

        summary = get_review_summary(records)
        self.assertEqual(summary["count"], 4)
        self.assertEqual(report_exists, True)
        self.assertEqual(threshold["status"], "OK")
        self.assertIn("阈值判定", report_text)
        self.assertIn("空间热图", report_text)
        self.assertIn("<svg", svg)
        self.assertEqual(grid.shape, (2, 2))
        self.assertEqual(igrid.shape, (12, 12))
        self.assertEqual(surface.shape, (12, 12))
        self.assertEqual(list(xs), [0.0, 1.0])
        self.assertEqual(list(ys), [0.0, 1.0])
        self.assertEqual(len(ixs), 12)
        self.assertEqual(len(iys), 12)
        self.assertEqual(len(sxs), 12)
        self.assertEqual(len(sys), 12)

    def test_interpolated_heatmap_duplicate_points_and_non_spatial_report(self):
        spatial = records_to_review_array([
            {"sequence": 1, "timestamp_s": 0.0, "x_mm": 0.0, "y_mm": 0.0, "field_total": 1.0},
            {"sequence": 2, "timestamp_s": 1.0, "x_mm": 0.0, "y_mm": 0.0, "field_total": 3.0},
            {"sequence": 3, "timestamp_s": 2.0, "x_mm": 1.0, "y_mm": 0.0, "field_total": 2.0},
            {"sequence": 4, "timestamp_s": 3.0, "x_mm": 0.0, "y_mm": 1.0, "field_total": 4.0},
        ])
        xs, ys, grid = build_interpolated_heatmap_grid(spatial, resolution=8)
        sxs, sys, surface = build_surface_grid(spatial, resolution=8)
        self.assertEqual(grid.shape, (8, 8))
        self.assertEqual(surface.shape, (8, 8))
        self.assertTrue(np.isfinite(grid).all())
        self.assertTrue(np.isfinite(surface).all())
        self.assertEqual(len(xs), 8)
        self.assertEqual(len(ys), 8)
        self.assertEqual(len(sxs), 8)
        self.assertEqual(len(sys), 8)

        non_spatial = records_to_review_array([
            {"sequence": 1, "timestamp_s": 0.0, "field_total": 1.0},
            {"sequence": 2, "timestamp_s": 1.0, "field_total": 2.0},
        ])
        with tempfile.TemporaryDirectory() as td:
            report = Path(td) / "report.html"
            export_html_report(report, non_spatial)
            text = report.read_text(encoding="utf-8")
        self.assertNotIn("空间热图", text)


if __name__ == "__main__":
    unittest.main()
