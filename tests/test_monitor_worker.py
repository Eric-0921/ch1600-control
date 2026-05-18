"""Monitor worker rate-limit tests."""

from __future__ import annotations

import queue
import unittest

from workers.ch1600_monitor_worker import CH1600MonitorWorker


class _FakeDriver:
    pass


class TestCH1600MonitorWorker(unittest.TestCase):
    def test_interval_keeps_two_query_cycle_under_command_limit(self):
        worker = CH1600MonitorWorker(_FakeDriver(), queue.Queue(), interval_ms=100)
        self.assertEqual(worker._interval_ms, 250)
        worker.set_interval(50)
        self.assertEqual(worker._interval_ms, 250)
        worker.set_interval(500)
        self.assertEqual(worker._interval_ms, 500)


if __name__ == "__main__":
    unittest.main()
