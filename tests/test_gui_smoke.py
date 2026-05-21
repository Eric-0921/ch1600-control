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

from PyQt5.QtCore import Qt
from PyQt5.QtWidgets import QApplication

from app.config_io import DEFAULT_CONFIG
from app.gui import GaussMeterGUI, _HAS_PYG, _HAS_PYG_GL
from main import build_demo_review_data
from data.review_loader import records_to_review_array


class _FakeController:
    def __init__(self, *, connected: bool = False, streaming: bool = False) -> None:
        self._connected = connected
        self._streaming = streaming
        self.disconnect_called = False

    @property
    def is_connected(self) -> bool:
        return self._connected

    @property
    def is_streaming(self) -> bool:
        return self._streaming

    def disconnect(self) -> None:
        self.disconnect_called = True
        self._connected = False
        self._streaming = False


class _FakeCommandService:
    def __init__(self, start_result: bool = False) -> None:
        self.start_result = start_result
        self.update_config_called = False
        self.stop_acquisition_called = False
        self.stop_called = False

    def update_config(self, _cfg) -> None:
        self.update_config_called = True

    def start_acquisition(self) -> bool:
        return self.start_result

    def stop_acquisition(self) -> None:
        self.stop_acquisition_called = True

    def stop(self) -> None:
        self.stop_called = True


class TestGUISmoke(unittest.TestCase):
    def test_demo_review_data_covers_spatial_review_views(self):
        data = build_demo_review_data()
        self.assertEqual(len(data), 252)
        for name in ("timestamp_s", "x_mm", "y_mm", "field_total", "freq_hz", "temp_c"):
            self.assertIn(name, data.dtype.names)
            self.assertTrue(np.isfinite(data[name]).all())
        self.assertEqual(len(np.unique(data["x_mm"])), 18)
        self.assertEqual(len(np.unique(data["y_mm"])), 14)
        self.assertGreater(float(np.ptp(data["field_total"])), 0.5)

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
                self.assertEqual(window._live_tabs.count(), 3)
                self.assertEqual(window._review_main_tabs.count(), 4)
                if _HAS_PYG:
                    self.assertGreaterEqual(window._review_plot_tabs.count(), 4)
                    self.assertIsNotNone(window._review_spectrum_curve)
                    self.assertIsNotNone(window._review_cursor_a)
                    self.assertIsNotNone(window._live_cursor_a)
                    self.assertIn("current", window._live_metric_labels)
                self.assertIn("筛选统计", window._review_main_tabs.tabText(1))
                self.assertIn("数据表", window._review_main_tabs.tabText(3))
                self.assertEqual(window._data_table.verticalScrollBarPolicy(), Qt.ScrollBarAlwaysOn)
                self.assertIs(window._data_table.model(), window._live_table_model)
                self.assertEqual(window._review_table.verticalScrollBarPolicy(), Qt.ScrollBarAlwaysOn)
                self.assertIn("Apply Filter", window._review_apply_filter_btn.text())
                self.assertIn("刷新图表", window._review_apply_filter_btn.toolTip())
            finally:
                window.close()
        self.assertIsNotNone(app)

    def test_start_stream_keeps_ui_stopped_when_controller_rejects(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            fake_cmd = _FakeCommandService(start_result=False)
            window._cmd_service = fake_cmd
            window._ctrl = _FakeController(connected=False, streaming=False)
            try:
                window._stream_start_btn.setEnabled(True)
                window._stream_stop_btn.setEnabled(False)
                window._on_start_stream()
                self.assertTrue(fake_cmd.update_config_called)
                self.assertTrue(window._stream_start_btn.isEnabled())
                self.assertFalse(window._stream_stop_btn.isEnabled())
                self.assertIn("未启动", window._status_label.text())
            finally:
                window.close()
        self.assertIsNotNone(app)

    def test_scan_with_no_verified_ports_allows_manual_connect(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            window._ctrl = type("Ctrl", (), {"scan_ports": lambda _self: []})()
            window._cmd_service = _FakeCommandService()
            try:
                window._connect_btn.setEnabled(True)
                window._on_scan_ports()
                self.assertTrue(window._connect_btn.isEnabled())
                self.assertEqual(window._port_combo.currentText(), cfg["ch1600"]["port"])
            finally:
                window.close()
        self.assertIsNotNone(app)

    @unittest.skipUnless(_HAS_PYG, "pyqtgraph not available")
    def test_save_chart_uses_exporters_module(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        tmp_dir = Path(tempfile.mkdtemp())
        out_path = tmp_dir / "chart.png"
        with (
            patch("app.gui.load_config", return_value=cfg),
            patch("app.gui.save_config"),
            patch("app.gui.QFileDialog.getSaveFileName", return_value=(str(out_path), "PNG (*.png)")),
            patch("app.gui.QMessageBox.critical") as critical,
        ):
            window = GaussMeterGUI()
            try:
                window._on_save_chart()
                self.assertTrue(out_path.exists())
                critical.assert_not_called()
            finally:
                window.close()
        self.assertIsNotNone(app)

    def test_close_event_stops_acquisition_and_disconnects_controller(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            fake_cmd = _FakeCommandService()
            fake_ctrl = _FakeController(connected=True, streaming=True)
            window._cmd_service = fake_cmd
            window._ctrl = fake_ctrl
            window.close()
            self.assertTrue(fake_cmd.stop_acquisition_called)
            self.assertTrue(fake_ctrl.disconnect_called)
            self.assertTrue(fake_cmd.stop_called)
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
                self.assertGreaterEqual(window._review_plot_tabs.count(), 4)
                window._review_plot_tabs.setCurrentIndex(1)
                window._update_review_plot()
                self.assertIn("Hz", window._review_spectrum_status.text())
                window._review_plot_tabs.setCurrentIndex(2)
                window._update_review_plot()
                self.assertIn("2 × 2", window._review_heatmap_status.text())
                self.assertTrue(np.isfinite(window._review_heatmap_item.image).all())
                window._review_plot_tabs.setCurrentIndex(3)
                window._update_review_plot()
                if _HAS_PYG_GL and window._review_surface_widget is not None:
                    self.assertIsNotNone(window._review_surface_item)
                else:
                    self.assertRegex(window._review_surface_status.text(), "PyOpenGL|OpenGL")
                self.assertGreaterEqual(window._review_heatmap_channel_combo.count(), 1)
                window._review_plot_tabs.setCurrentIndex(2)
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

    def test_multiaxis_zero_offsets_are_component_wise(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        cfg["device_model"] = "3d_gauss"
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                window._buffer.append(
                    {
                        "field_x_mt": 3.0,
                        "field_y_mt": 4.0,
                        "field_z_mt": 12.0,
                        "field_total_mt": 13.0,
                    },
                    timestamp=1.0,
                )
                window._on_set_zero()
                corrected = window._apply_zero_offsets_to_point(
                    {
                        "field_x_mt": 5.0,
                        "field_y_mt": 7.0,
                        "field_z_mt": 18.0,
                        "field_total_mt": 20.0,
                        "field_mt": 20.0,
                    }
                )
                self.assertAlmostEqual(corrected["field_x_mt"], 2.0)
                self.assertAlmostEqual(corrected["field_y_mt"], 3.0)
                self.assertAlmostEqual(corrected["field_z_mt"], 6.0)
                self.assertAlmostEqual(corrected["field_total_mt"], 7.0)
                self.assertAlmostEqual(corrected["field_mt"], 7.0)
                self.assertIn("X:", window._zero_offset_label.text())
            finally:
                window.close()
        self.assertIsNotNone(app)

    def test_live_table_model_and_trigger_capture(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                window._trigger_enabled_cb.setChecked(True)
                window._trigger_mode_combo.setCurrentIndex(
                    window._trigger_mode_combo.findData("rising")
                )
                window._trigger_level_edit.setText("1.0")
                window._trigger_pre_spin.setValue(1)
                window._trigger_post_spin.setValue(1)
                window._on_stream_batch({
                    "points": [
                        {"timestamp_s": 0.0, "field_mt": 0.0, "field_total_mt": 0.0},
                        {"timestamp_s": 0.1, "field_mt": 1.5, "field_total_mt": 1.5},
                        {"timestamp_s": 0.2, "field_mt": 1.4, "field_total_mt": 1.4},
                    ]
                })
                window._flush_live_table_rows()
                self.assertEqual(window._live_table_model.rowCount(), 3)
                self.assertEqual(len(window._trigger_events), 1)
                self.assertGreaterEqual(len(window._trigger_events[0]["window_points"]), 3)
                self.assertIn("事件 1", window._trigger_status_label.text())

                window._trigger_single_cb.setChecked(True)
                window._arm_trigger()
                window._on_stream_batch({
                    "points": [
                        {"timestamp_s": 0.2, "field_mt": 0.0, "field_total_mt": 0.0},
                        {"timestamp_s": 0.3, "field_mt": 2.0, "field_total_mt": 2.0},
                        {"timestamp_s": 0.4, "field_mt": 2.1, "field_total_mt": 2.1},
                    ]
                })
                self.assertFalse(window._trigger_armed)
                self.assertEqual(len(window._trigger_events), 2)
                self.assertGreaterEqual(window._trigger_event_table.rowCount(), 2)
                window._replay_last_trigger_event()
                self.assertTrue(window._display_paused)
                window._on_clear_data_table()
                self.assertEqual(window._live_table_model.rowCount(), 0)
            finally:
                window.close()
        self.assertIsNotNone(app)

    def test_threshold_trigger_captures_only_ng_entry(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                window._trigger_max_events = 2
                window._trigger_enabled_cb.setChecked(True)
                window._trigger_mode_combo.setCurrentIndex(
                    window._trigger_mode_combo.findData("threshold")
                )
                window._low_thresh_edit.setText("0.0")
                window._up_thresh_edit.setText("1.0")
                window._trigger_pre_spin.setValue(0)
                window._trigger_post_spin.setValue(0)

                window._on_stream_batch({
                    "points": [
                        {"timestamp_s": 0.0, "field_mt": 2.0, "field_total_mt": 2.0},
                        {"timestamp_s": 0.1, "field_mt": 2.1, "field_total_mt": 2.1},
                        {"timestamp_s": 0.2, "field_mt": 2.2, "field_total_mt": 2.2},
                    ]
                })
                self.assertEqual(len(window._trigger_events), 1)
                first_id = window._trigger_events[-1]["id"]

                window._on_stream_batch({
                    "points": [
                        {"timestamp_s": 0.3, "field_mt": 0.5, "field_total_mt": 0.5},
                        {"timestamp_s": 0.4, "field_mt": 2.3, "field_total_mt": 2.3},
                        {"timestamp_s": 0.5, "field_mt": 0.6, "field_total_mt": 0.6},
                        {"timestamp_s": 0.6, "field_mt": 2.4, "field_total_mt": 2.4},
                    ]
                })
                self.assertEqual(len(window._trigger_events), 2)
                self.assertGreater(window._trigger_events[-1]["id"], first_id)
                self.assertEqual(
                    [event["id"] for event in window._trigger_events],
                    [2, 3],
                )
            finally:
                window.close()
        self.assertIsNotNone(app)

    def test_live_threshold_metrics_follow_selected_channel(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        cfg["device_model"] = "2d_gauss"
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                idx = window._judge_channel_combo.findData("field_x")
                self.assertGreaterEqual(idx, 0)
                window._judge_channel_combo.setCurrentIndex(idx)
                window._low_thresh_edit.setText("0.0")
                window._up_thresh_edit.setText("1.0")
                timestamps = [0.0, 0.1, 0.2]
                window._buffer.extend(
                    {
                        "field_x_mt": [0.5, 2.0, 0.4],
                        "field_y_mt": [0.0, 0.0, 0.0],
                        "field_total_mt": [0.5, 0.5, 0.5],
                        "freq_hz": [0.0, 0.0, 0.0],
                        "temp_c": [25.0, 25.0, 25.0],
                    },
                    timestamps,
                )
                window._update_live_measurements(
                    np.asarray(timestamps),
                    np.asarray([0.5, 0.5, 0.5]),
                    "field_total_mt",
                )
                self.assertIn("NG 1 / 1", window._live_metric_labels["threshold"].text())
            finally:
                window.close()
        self.assertIsNotNone(app)

    @unittest.skipUnless(_HAS_PYG, "pyqtgraph is not installed")
    def test_live_sample_rate_uses_raw_points_not_plot_downsample(self):
        app = QApplication.instance() or QApplication([])
        cfg = copy.deepcopy(DEFAULT_CONFIG)
        cfg["database"]["enabled"] = False
        with patch("app.gui.load_config", return_value=cfg), patch("app.gui.save_config"):
            window = GaussMeterGUI()
            try:
                idx = window._sample_rate_combo.findData("dc_200hz")
                self.assertGreaterEqual(idx, 0)
                window._sample_rate_combo.setCurrentIndex(idx)
                timestamps = [i * 0.1 for i in range(12)]
                window._buffer.extend(
                    {
                        "field_mt": [float(i) for i in range(12)],
                        "freq_hz": [0.0] * 12,
                        "temp_c": [25.0] * 12,
                    },
                    timestamps,
                )
                window._on_display_tick()
                self.assertIn("10", window._live_metric_labels["sample_rate_hz"].text())
            finally:
                window.close()
        self.assertIsNotNone(app)


if __name__ == "__main__":
    unittest.main()
