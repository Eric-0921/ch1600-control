"""External IPC command compatibility tests."""

from __future__ import annotations

import json
import unittest

from core.external_ipc import ExternalIPCService


class TestExternalIPCService(unittest.TestCase):
    def test_json_command_still_works(self):
        service = ExternalIPCService()
        service.set_command_callbacks({"get_status": lambda: {"streaming": False}})

        response = json.loads(service._handle_command('{"command": "get_status"}'))

        self.assertEqual(response["status"], "ok")
        self.assertFalse(response["streaming"])

    def test_datareader2_gd_starts_acquisition(self):
        calls = []
        service = ExternalIPCService()
        service.set_command_callbacks({"start_acquisition": lambda: calls.append("start") or {"queued": True}})

        response = json.loads(service._handle_command("GD\t0\t3\t1"))

        self.assertEqual(calls, ["start"])
        self.assertEqual(response["status"], "ok")
        self.assertEqual(response["legacy_command"], "GD")
        self.assertEqual(response["requested_count"], 0)
        self.assertEqual(response["sample_mode_index"], 3)
        self.assertTrue(response["save_enabled"])

    def test_datareader2_sg_stops_acquisition(self):
        calls = []
        service = ExternalIPCService()
        service.set_command_callbacks({"stop_acquisition": lambda: calls.append("stop") or {"queued": True}})

        response = json.loads(service._handle_command("SG"))

        self.assertEqual(calls, ["stop"])
        self.assertEqual(response["status"], "ok")
        self.assertEqual(response["legacy_command"], "SG")

    def test_datareader2_st_is_parsed_but_not_applied(self):
        service = ExternalIPCService()

        response = json.loads(service._handle_command("ST\t7\t3\t2\t0\t1\t1000\t0\t1"))

        self.assertEqual(response["status"], "ok")
        self.assertEqual(response["legacy_command"], "ST")
        self.assertFalse(response["applied"])
        self.assertEqual(response["port"], "COM7")
        self.assertEqual(response["sample_mode_index"], 2)


if __name__ == "__main__":
    unittest.main()
