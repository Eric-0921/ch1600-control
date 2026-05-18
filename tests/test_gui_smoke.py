"""GUI import/instantiation smoke tests."""

from __future__ import annotations

import copy
import os
import tempfile
import unittest
from pathlib import Path
from unittest.mock import patch

import numpy as np

os.environ.setdefault("QT_QPA_PLATFORM", "offscreen")

from PyQt5.QtWidgets import QApplication

from app.config_io import DEFAULT_CONFIG
from app.gui import GaussMeterGUI, _HAS_PYG, _HAS_PYG_GL
from data.review_loader import records_to_review_array


class TestGUISmoke(unittest.TestCase):
    def test_gui_instantiates_without_zmq_or_config_mutation(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                self.assertIsNotNone(window)
                self.assertIsInstance(window._ipc_service.zmq_available, bool)
                window._display_unit = "A/m"
                self.assertAlmostEqual(window._convert_field_display(1.0), 795.77, places=2)
                idx = window._device_model_combo.findData("3d_fluxgate")
                self.assertGreaterEqual(idx, 0)
                window._device_model_combo.setCurrentIndex(idx)
                self.assertEqual(window._get_display_unit_options("3d_fluxgate"), ["nT"])
                self.assertNotIn("频率", " ".join(window._get_table_columns("3d_fluxgate")))
                self.assertEqual(window._judge_channel_combo.findData("field_z") >= 0, True)
                pidx = window._probe_profile_combo.findData("weak_field")
                window._probe_profile_combo.setCurrentIndex(pidx)
                self.assertEqual(window._probe_profile, "weak_field")
            finally:
                window.close()
        self.assertIsNotNone(app)

    @unittest.skipUnless(_HAS_PYG, "pyqtgraph is not installed")
    def test_review_heatmap_updates_from_spatial_data(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        records = records_to_review_array([
            {"sequence": 1, "timestamp_s": 0.0, "x_mm": 0.0, "y_mm": 0.0, "field_total": 1.0},
            {"sequence": 2, "timestamp_s": 1.0, "x_mm": 1.0, "y_mm": 0.0, "field_total": 2.0},
            {"sequence": 3, "timestamp_s": 2.0, "x_mm": 0.0, "y_mm": 1.0, "field_total": 3.0},
            {"sequence": 4, "timestamp_s": 3.0, "x_mm": 1.0, "y_mm": 1.0, "field_total": 4.0},
        ])
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                window._set_review_data(records, files=[])
                self.assertGreaterEqual(window._review_plot_tabs.count(), 3)
                window._review_plot_tabs.setCurrentIndex(1)
                window._update_review_plot()
                self.assertIn("2 × 2", window._review_heatmap_status.text())
                self.assertTrue(np.isfinite(window._review_heatmap_item.image).all())
                window._review_plot_tabs.setCurrentIndex(2)
                window._update_review_plot()
                if _HAS_PYG_GL and window._review_surface_widget is not None:
                    self.assertIsNotNone(window._review_surface_item)
                else:
                    self.assertRegex(window._review_surface_status.text(), "PyOpenGL|OpenGL")
                self.assertGreaterEqual(window._review_heatmap_channel_combo.count(), 1)
                window._review_plot_tabs.setCurrentIndex(1)
                window._review_heatmap_auto_levels_cb.setChecked(False)
                window._review_heatmap_min_edit.setText("0")
                window._review_heatmap_max_edit.setText("5")
                window._review_heatmap_contour_cb.setChecked(True)
                window._update_review_plot()
                self.assertGreater(len(window._review_heatmap_contours), 0)
                window._review_heatmap_mode_combo.setCurrentIndex(
                    window._review_heatmap_mode_combo.findData("interpolated")
                )
                window._review_heatmap_resolution_spin.setValue(16)
                window._update_review_plot()
                self.assertEqual(window._review_heatmap_item.image.shape, (16, 16))
                with tempfile.TemporaryDirectory() as td:
                    out = Path(td) / "heatmap.png"
                    with patch("app.gui.QFileDialog.getSaveFileName", return_value=(str(out), "PNG Images (*.png)")):
                        window._on_export_review_heatmap_image()
                    self.assertTrue(out.exists())
                    self.assertGreater(out.stat().st_size, 0)
            finally:
                window.close()
        self.assertIsNotNone(app)


if __name__ == "__main__":
    unittest.main()
