"""SQLite session store for CH-1600 experiments.

CSV remains the exchange format, while this store provides indexed sessions,
samples, raw serial frames, and export provenance for review/query workflows.
"""

from __future__ import annotations

import datetime as _dt
import json
import sqlite3
from pathlib import Path
from typing import Any, Dict, Iterable, List, Optional

import numpy as np

from data.device_capabilities import get_device_capability, normalize_sample_by_capability
from data.review_loader import records_to_review_array


SCHEMA_VERSION = 3
VALID_SOURCES = {"realtime", "import_csv", "import_txt", "device_memory"}


def _utc_now() -> str:
    return _dt.datetime.now(_dt.timezone.utc).isoformat(timespec="seconds")


def _field_value(sample: Dict[str, Any], *names: str) -> float:
    for name in names:
        if name in sample and sample[name] is not None:
            try:
                return float(sample[name])
            except (TypeError, ValueError):
                return 0.0
    return 0.0


def _column_exists(conn: sqlite3.Connection, table: str, column: str) -> bool:
    rows = conn.execute(f"PRAGMA table_info({table})").fetchall()
    return any(str(row["name"]) == column for row in rows)


class CH1600SQLiteStore:
    """Small SQLite wrapper with explicit public methods used by the GUI/tests."""

    def __init__(self, path: Path | str) -> None:
        self.path = Path(path)
        self.path.parent.mkdir(parents=True, exist_ok=True)
        self._conn = sqlite3.connect(self.path)
        self._conn.row_factory = sqlite3.Row
        self._init_schema()

    def close(self) -> None:
        self._conn.close()

    def _init_schema(self) -> None:
        cur = self._conn.cursor()
        cur.execute("PRAGMA journal_mode=WAL")
        cur.execute("PRAGMA foreign_keys=ON")
        cur.execute(
            """
            CREATE TABLE IF NOT EXISTS schema_meta (
                key TEXT PRIMARY KEY,
                value TEXT NOT NULL
            )
            """
        )
        cur.execute(
            """
            CREATE TABLE IF NOT EXISTS sessions (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                started_at TEXT NOT NULL,
                ended_at TEXT,
                test_point TEXT,
                grade TEXT,
                ambient_temp_c REAL,
                device_model TEXT NOT NULL,
                probe_profile TEXT NOT NULL DEFAULT 'standard_hall',
                mode_key TEXT,
                display_unit TEXT,
                range_label TEXT,
                up_threshold REAL,
                low_threshold REAL,
                threshold_channel TEXT,
                source TEXT NOT NULL DEFAULT 'realtime',
                notes TEXT
            )
            """
        )
        cur.execute(
            """
            CREATE TABLE IF NOT EXISTS samples (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                session_id INTEGER NOT NULL REFERENCES sessions(id) ON DELETE CASCADE,
                sequence INTEGER NOT NULL,
                timestamp_s REAL NOT NULL,
                received_at TEXT NOT NULL,
                device_model TEXT NOT NULL,
                source TEXT NOT NULL,
                field_x REAL NOT NULL DEFAULT 0,
                field_y REAL NOT NULL DEFAULT 0,
                field_z REAL NOT NULL DEFAULT 0,
                field_total REAL NOT NULL DEFAULT 0,
                field_unit TEXT NOT NULL DEFAULT 'mT',
                freq_hz REAL NOT NULL DEFAULT 0,
                temp_c REAL NOT NULL DEFAULT 0,
                x_mm REAL,
                y_mm REAL,
                z_mm REAL,
                UNIQUE(session_id, sequence)
            )
            """
        )
        cur.execute("CREATE INDEX IF NOT EXISTS idx_samples_session_seq ON samples(session_id, sequence)")
        cur.execute("CREATE INDEX IF NOT EXISTS idx_samples_time ON samples(timestamp_s)")
        cur.execute("CREATE INDEX IF NOT EXISTS idx_samples_source ON samples(source)")
        cur.execute(
            """
            CREATE TABLE IF NOT EXISTS raw_frames (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                session_id INTEGER NOT NULL REFERENCES sessions(id) ON DELETE CASCADE,
                sequence INTEGER,
                timestamp_s REAL,
                direction TEXT NOT NULL DEFAULT 'RX',
                frame TEXT NOT NULL,
                parser_version TEXT NOT NULL DEFAULT 'v1',
                parsed_ok INTEGER NOT NULL DEFAULT 1,
                received_at TEXT NOT NULL
            )
            """
        )
        cur.execute("CREATE INDEX IF NOT EXISTS idx_raw_frames_session_seq ON raw_frames(session_id, sequence)")
        if not _column_exists(self._conn, "sessions", "probe_profile"):
            cur.execute("ALTER TABLE sessions ADD COLUMN probe_profile TEXT NOT NULL DEFAULT 'standard_hall'")
        cur.execute(
            """
            CREATE TABLE IF NOT EXISTS trigger_events (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                session_id INTEGER REFERENCES sessions(id) ON DELETE CASCADE,
                created_at TEXT NOT NULL,
                timestamp_s REAL NOT NULL,
                sequence INTEGER,
                channel TEXT NOT NULL,
                mode TEXT NOT NULL,
                level REAL,
                value REAL NOT NULL,
                pre_points INTEGER NOT NULL DEFAULT 0,
                post_points INTEGER NOT NULL DEFAULT 0,
                window_json TEXT,
                notes TEXT
            )
            """
        )
        cur.execute("CREATE INDEX IF NOT EXISTS idx_trigger_events_session_time ON trigger_events(session_id, timestamp_s)")
        cur.execute(
            """
            CREATE TABLE IF NOT EXISTS exports (
                id INTEGER PRIMARY KEY AUTOINCREMENT,
                session_id INTEGER REFERENCES sessions(id) ON DELETE SET NULL,
                created_at TEXT NOT NULL,
                export_type TEXT NOT NULL,
                path TEXT NOT NULL,
                source_query TEXT,
                file_sha256 TEXT,
                notes TEXT
            )
            """
        )
        cur.execute(
            "INSERT OR REPLACE INTO schema_meta(key, value) VALUES('schema_version', ?)",
            (str(SCHEMA_VERSION),),
        )
        self._conn.commit()

    def append_trigger_event(
        self,
        *,
        session_id: Optional[int],
        timestamp_s: float,
        value: float,
        channel: str,
        mode: str,
        sequence: Optional[int] = None,
        level: Optional[float] = None,
        pre_points: int = 0,
        post_points: int = 0,
        window_points: Optional[List[Dict[str, Any]]] = None,
        notes: str = "",
    ) -> int:
        """Persist one trigger event with an optional compact replay window."""
        window_json = json.dumps(window_points or [], ensure_ascii=False, separators=(",", ":"))
        cur = self._conn.execute(
            """
            INSERT INTO trigger_events (
                session_id, created_at, timestamp_s, sequence, channel, mode, level, value,
                pre_points, post_points, window_json, notes
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """,
            (
                session_id, _utc_now(), float(timestamp_s), sequence, channel, mode, level,
                float(value), int(pre_points), int(post_points), window_json, notes,
            ),
        )
        self._conn.commit()
        return int(cur.lastrowid)

    def list_trigger_events(self, session_id: Optional[int] = None, limit: int = 200) -> List[Dict[str, Any]]:
        """Return recent trigger events for review/debugging."""
        if session_id is None:
            rows = self._conn.execute(
                "SELECT * FROM trigger_events ORDER BY id DESC LIMIT ?",
                (int(limit),),
            ).fetchall()
        else:
            rows = self._conn.execute(
                "SELECT * FROM trigger_events WHERE session_id = ? ORDER BY id DESC LIMIT ?",
                (session_id, int(limit)),
            ).fetchall()
        return [dict(row) for row in rows]

    def create_session(
        self,
        *,
        device_model: str,
        probe_profile: str = "standard_hall",
        mode_key: str = "",
        display_unit: str = "mT",
        range_label: str = "",
        up_threshold: Optional[float] = None,
        low_threshold: Optional[float] = None,
        threshold_channel: str = "field_total",
        source: str = "realtime",
        test_point: str = "",
        grade: str = "",
        ambient_temp_c: Optional[float] = None,
        notes: str = "",
    ) -> int:
        if source not in VALID_SOURCES:
            raise ValueError(f"unknown data source: {source}")
        cur = self._conn.execute(
            """
            INSERT INTO sessions (
                started_at, test_point, grade, ambient_temp_c, device_model, probe_profile,
                mode_key, display_unit, range_label, up_threshold, low_threshold,
                threshold_channel, source, notes
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """,
            (
                _utc_now(), test_point, grade, ambient_temp_c, device_model, probe_profile,
                mode_key, display_unit, range_label, up_threshold, low_threshold,
                threshold_channel, source, notes,
            ),
        )
        self._conn.commit()
        return int(cur.lastrowid)

    def close_session(self, session_id: int) -> None:
        self._conn.execute("UPDATE sessions SET ended_at = ? WHERE id = ?", (_utc_now(), session_id))
        self._conn.commit()

    def _next_sequence(self, session_id: int) -> int:
        row = self._conn.execute(
            "SELECT COALESCE(MAX(sequence), 0) AS seq FROM samples WHERE session_id = ?",
            (session_id,),
        ).fetchone()
        return int(row["seq"]) + 1

    def append_samples(
        self,
        session_id: int,
        samples: Iterable[Dict[str, Any]],
        *,
        source: str = "realtime",
        device_model: str = "1d_gauss",
        field_unit: str = "mT",
    ) -> int:
        if source not in VALID_SOURCES:
            raise ValueError(f"unknown data source: {source}")
        rows = []
        next_seq = self._next_sequence(session_id)
        for sample in samples:
            sample_model = str(sample.get("device_model") or device_model)
            cap = get_device_capability(sample_model)
            normalized = normalize_sample_by_capability(sample, cap)
            sequence = int(normalized.get("sequence") or next_seq)
            next_seq = max(next_seq + 1, sequence + 1)
            field_total = _field_value(normalized, "field_total", "field_total_mt", "field_mt")
            field_x = _field_value(normalized, "field_x", "field_x_mt", "field_mt", "field_total_mt")
            field_y = _field_value(normalized, "field_y", "field_y_mt")
            field_z = _field_value(normalized, "field_z", "field_z_mt")
            rows.append((
                session_id,
                sequence,
                float(normalized.get("timestamp_s", 0.0)),
                _utc_now(),
                sample_model,
                str(normalized.get("source") or source),
                field_x,
                field_y,
                field_z,
                field_total,
                str(normalized.get("field_unit") or field_unit or cap.field_unit),
                float(normalized.get("freq_hz", 0.0)),
                float(normalized.get("temp_c", 0.0)),
                normalized.get("x_mm"),
                normalized.get("y_mm"),
                normalized.get("z_mm"),
            ))
        if not rows:
            return 0
        self._conn.executemany(
            """
            INSERT OR REPLACE INTO samples (
                session_id, sequence, timestamp_s, received_at, device_model, source,
                field_x, field_y, field_z, field_total, field_unit,
                freq_hz, temp_c, x_mm, y_mm, z_mm
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)
            """,
            rows,
        )
        self._conn.commit()
        return len(rows)

    def append_raw_frames(
        self,
        session_id: int,
        frames: Iterable[Dict[str, Any] | bytes | str],
        *,
        parser_version: str = "v1",
    ) -> int:
        rows = []
        for frame in frames:
            if isinstance(frame, dict):
                frame_text = str(frame.get("frame", ""))
                sequence = frame.get("sequence")
                timestamp_s = frame.get("timestamp_s")
                direction = str(frame.get("direction") or "RX")
                parsed_ok = 1 if frame.get("parsed_ok", True) else 0
            elif isinstance(frame, bytes):
                frame_text = frame.decode("ascii", errors="replace")
                sequence = None
                timestamp_s = None
                direction = "RX"
                parsed_ok = 1
            else:
                frame_text = str(frame)
                sequence = None
                timestamp_s = None
                direction = "RX"
                parsed_ok = 1
            if not frame_text:
                continue
            rows.append((
                session_id, sequence, timestamp_s, direction, frame_text,
                parser_version, parsed_ok, _utc_now(),
            ))
        if not rows:
            return 0
        self._conn.executemany(
            """
            INSERT INTO raw_frames (
                session_id, sequence, timestamp_s, direction, frame,
                parser_version, parsed_ok, received_at
            ) VALUES (?, ?, ?, ?, ?, ?, ?, ?)
            """,
            rows,
        )
        self._conn.commit()
        return len(rows)

    def record_export(
        self,
        *,
        path: Path | str,
        export_type: str,
        session_id: Optional[int] = None,
        source_query: str = "",
        file_sha256: str = "",
        notes: str = "",
    ) -> int:
        cur = self._conn.execute(
            """
            INSERT INTO exports (
                session_id, created_at, export_type, path, source_query, file_sha256, notes
            ) VALUES (?, ?, ?, ?, ?, ?, ?)
            """,
            (session_id, _utc_now(), export_type, str(path), source_query, file_sha256, notes),
        )
        self._conn.commit()
        return int(cur.lastrowid)

    def query_samples(
        self,
        *,
        session_id: Optional[int] = None,
        source: Optional[str] = None,
        sequence_start: Optional[int] = None,
        sequence_end: Optional[int] = None,
        time_start_s: Optional[float] = None,
        time_end_s: Optional[float] = None,
    ) -> np.ndarray:
        where = []
        params: List[Any] = []
        if session_id:
            where.append("session_id = ?")
            params.append(session_id)
        if source and source != "all":
            where.append("source = ?")
            params.append(source)
        if sequence_start is not None:
            where.append("sequence >= ?")
            params.append(sequence_start)
        if sequence_end is not None:
            where.append("sequence <= ?")
            params.append(sequence_end)
        if time_start_s is not None:
            where.append("timestamp_s >= ?")
            params.append(time_start_s)
        if time_end_s is not None:
            where.append("timestamp_s <= ?")
            params.append(time_end_s)

        sql = """
            SELECT session_id, sequence, timestamp_s, x_mm, y_mm, z_mm,
                   field_x, field_y, field_z, field_total, field_unit,
                   freq_hz, temp_c, source
            FROM samples
        """
        if where:
            sql += " WHERE " + " AND ".join(where)
        sql += " ORDER BY timestamp_s, sequence"
        rows = self._conn.execute(sql, params).fetchall()
        records = [dict(row) for row in rows]
        return records_to_review_array(records)

    def list_sessions(self, limit: int = 200) -> List[Dict[str, Any]]:
        rows = self._conn.execute(
            """
            SELECT s.*, COUNT(samples.id) AS sample_count
            FROM sessions s
            LEFT JOIN samples ON samples.session_id = s.id
            GROUP BY s.id
            ORDER BY s.id DESC
            LIMIT ?
            """,
            (limit,),
        ).fetchall()
        return [dict(row) for row in rows]

    def raw_frame_count(self, session_id: int) -> int:
        row = self._conn.execute(
            "SELECT COUNT(*) AS count FROM raw_frames WHERE session_id = ?",
            (session_id,),
        ).fetchone()
        return int(row["count"])
