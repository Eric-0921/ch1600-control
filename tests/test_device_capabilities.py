"""Device capability and probe profile tests."""

from __future__ import annotations

import unittest

from data.device_capabilities import (
    get_device_capability, get_probe_profile, iter_device_capabilities,
    normalize_sample_by_capability,
)


class TestDeviceCapabilities(unittest.TestCase):
    def test_six_device_models_have_expected_dimensions_and_units(self):
        caps = {cap.model: cap for cap in iter_device_capabilities()}
        self.assertEqual(set(caps), {
            "1d_gauss", "2d_gauss", "3d_gauss",
            "fluxmeter", "1d_fluxgate", "3d_fluxgate",
        })
        self.assertEqual(caps["1d_gauss"].measurement_dimension, 1)
        self.assertEqual(caps["2d_gauss"].measurement_dimension, 2)
        self.assertEqual(caps["3d_gauss"].measurement_dimension, 3)
        self.assertEqual(caps["fluxmeter"].field_unit, "mWb")
        self.assertEqual(caps["1d_fluxgate"].field_unit, "nT")
        self.assertEqual(caps["3d_fluxgate"].field_unit, "nT")
        self.assertFalse(caps["3d_fluxgate"].has_freq)
        self.assertFalse(caps["3d_fluxgate"].has_temp)
        self.assertNotIn("频率", " ".join(caps["3d_fluxgate"].table_columns))
        self.assertIn("field_z", caps["3d_fluxgate"].threshold_channels)

    def test_normalize_sample_respects_capability(self):
        gauss = normalize_sample_by_capability(
            {"field_x_mt": 3.0, "field_y_mt": 4.0, "freq_hz": 50.0, "temp_c": 25.0},
            "2d_gauss",
        )
        self.assertAlmostEqual(gauss["field_total"], 5.0)
        self.assertEqual(gauss["field_unit"], "mT")
        self.assertEqual(gauss["freq_hz"], 50.0)

        fluxgate = normalize_sample_by_capability(
            {"field_x_mt": 1.0, "field_y_mt": 2.0, "field_z_mt": 2.0, "freq_hz": 99.0, "temp_c": 30.0},
            "3d_fluxgate",
        )
        self.assertAlmostEqual(fluxgate["field_total"], 3.0)
        self.assertEqual(fluxgate["field_unit"], "nT")
        self.assertEqual(fluxgate["freq_hz"], 0.0)
        self.assertEqual(fluxgate["temp_c"], 0.0)

    def test_probe_profiles_document_manual_assumptions(self):
        standard = get_probe_profile("standard_hall")
        weak = get_probe_profile("weak_field")
        custom = get_probe_profile("missing")
        self.assertIn("HCHD801F", standard.label)
        self.assertIn("probe_nvm", standard.calibration_source)
        self.assertEqual(weak.range_label, "6 Gs")
        self.assertEqual(custom.name, "custom")


if __name__ == "__main__":
    unittest.main()
