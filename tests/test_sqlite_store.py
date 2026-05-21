"""SQLite session store tests."""

from __future__ import annotations

import tempfile
import unittest
from pathlib import Path

from data.sqlite_store import CH1600SQLiteStore


class TestCH1600SQLiteStore(unittest.TestCase):
    def test_session_samples_raw_frames_and_reopen(self):
        with tempfile.TemporaryDirectory() as td:
            db_path = Path(td) / "m1600.sqlite3"
            store = CH1600SQLiteStore(db_path)
            session_id = store.create_session(
                device_model="3d_gauss",
                probe_profile="standard_hall",
                mode_key="dc_100hz",
                display_unit="mT",
                threshold_channel="field_total",
            )
            written = store.append_samples(
                session_id,
                [
                    {
                        "sequence": 1,
                        "timestamp_s": 10.0,
                        "field_x_mt": 1.0,
                        "field_y_mt": 2.0,
                        "field_z_mt": 3.0,
                        "field_total_mt": 3.741657,
                        "freq_hz": 50.0,
                        "temp_c": 25.0,
                    },
                    {
                        "sequence": 2,
                        "timestamp_s": 11.0,
                        "field_x_mt": 4.0,
                        "field_total_mt": 4.0,
                        "device_model": "3d_fluxgate",
                        "field_unit": "nT",
                        "freq_hz": 60.0,
                        "temp_c": 26.0,
                    },
                ],
                device_model="3d_gauss",
                field_unit="mT",
            )
            raw_count = store.append_raw_frames(
                session_id,
                [
                    {"sequence": 1, "timestamp_s": 10.0, "frame": "#1/2/3>", "parsed_ok": True},
                    b"#4/0/0>",
                ],
            )
            store.close_session(session_id)
            all_data = store.query_samples(session_id=session_id)
            selected = store.query_samples(session_id=session_id, sequence_start=2)
            sessions = store.list_sessions()
            raw_frames = store.raw_frame_count(session_id)
            event_id = store.append_trigger_event(
                session_id=session_id,
                timestamp_s=1.25,
                sequence=2,
                channel="field_total",
                mode="rising",
                level=1.0,
                value=2.5,
                pre_points=1,
                post_points=1,
                window_points=[
                    {"timestamp_s": 1.0, "field_total_mt": 0.5},
                    {"timestamp_s": 1.25, "field_total_mt": 2.5},
                ],
            )
            events = store.list_trigger_events(session_id=session_id)
            store.close()

            reopened = CH1600SQLiteStore(db_path)
            reopened_data = reopened.query_samples(session_id=session_id)
            reopened.close()

        self.assertEqual(written, 2)
        self.assertEqual(raw_count, 2)
        self.assertEqual(len(all_data), 2)
        self.assertEqual(len(selected), 1)
        self.assertAlmostEqual(float(all_data["field_total"][0]), 3.741657)
        self.assertEqual(str(all_data["field_unit"][1]), "nT")
        self.assertEqual(float(all_data["freq_hz"][1]), 0.0)
        self.assertEqual(sessions[0]["probe_profile"], "standard_hall")
        self.assertEqual(sessions[0]["sample_count"], 2)
        self.assertEqual(raw_frames, 2)
        self.assertGreater(event_id, 0)
        self.assertEqual(len(events), 1)
        self.assertEqual(events[0]["mode"], "rising")
        self.assertIn("field_total_mt", events[0]["window_json"])
        self.assertEqual(len(reopened_data), 2)

    def test_reject_unknown_source(self):
        with tempfile.TemporaryDirectory() as td:
            store = CH1600SQLiteStore(Path(td) / "m1600.sqlite3")
            session_id = store.create_session(device_model="1d_gauss")
            with self.assertRaises(ValueError):
                store.append_samples(session_id, [{"timestamp_s": 0.0}], source="bad")
            store.close()


if __name__ == "__main__":
    unittest.main()
