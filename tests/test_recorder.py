"""CSV recorder tests."""

from __future__ import annotations

import tempfile
import unittest
from pathlib import Path

from data.recorder import CH1600Recorder


class TestCH1600Recorder(unittest.TestCase):
    def test_dynamic_schema_and_rollover_new_file(self):
        with tempfile.TemporaryDirectory() as td:
            recorder = CH1600Recorder(
                output_dir=Path(td),
                max_file_rows=1,
                rollover_strategy="new_file",
                device_model="2d_gauss",
            )
            first = recorder.start(prefix="test")
            recorder.write_batch([
                {
                    "timestamp_s": 1.0,
                    "field_x_mt": 1.0,
                    "field_y_mt": 2.0,
                    "field_total_mt": 2.2360679,
                    "freq_hz": 50.0,
                    "temp_c": 25.0,
                },
                {
                    "timestamp_s": 2.0,
                    "field_x_mt": 3.0,
                    "field_y_mt": 4.0,
                    "field_total_mt": 5.0,
                    "freq_hz": 60.0,
                    "temp_c": 26.0,
                },
            ])
            second = recorder.file_path
            recorder.stop()

            self.assertTrue(first.exists())
            self.assertIsNotNone(second)
            self.assertNotEqual(first, second)
            self.assertEqual(recorder.schema[1:4], ["field_x_mt", "field_y_mt", "field_total_mt"])

    def test_fluxgate_schema_has_no_fake_freq_temp_columns(self):
        recorder = CH1600Recorder(device_model="3d_fluxgate")
        self.assertEqual(
            recorder.schema,
            ["timestamp_s", "field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt"],
        )


if __name__ == "__main__":
    unittest.main()
