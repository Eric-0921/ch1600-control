# AGENTS.md -- CH-1600 Digital Gauss Meter Control

> This file is intended for AI coding agents. Assume the reader knows nothing about the project.

## Project Overview

This is a Python control and data acquisition application for the **CH-1600 Digital Gauss Meter / Teslameter** (Beijing Cuihai Jiacheng Magnetic Electric Technology). It communicates with the device via RS-232 serial port and provides:

- Real-time magnetic field waveform display at 30+ FPS
- Hardware sampling rate control (20--300 Hz via `FAST020>` ~ `FAST300>`)
- 5-unit display switching (mT, G, Oe, A/m, mGs)
- Threshold alarm with closed/open interval and ABS modes
- CSV data recording with auto file rollover
- SQLite experiment sessions with indexed samples/raw frames/exports
- Historical data review (CSV/TXT/SQLite) with filtering and HTML reports
- Raw serial debug monitor (Hex/ASCII TX/RX)
- External IPC via ZMQ PUB/REP and Windows NamedPipe
- Multi-device model support (1D/2D/3D Gauss, Fluxmeter, 1D/3D Fluxgate)

The GUI uses **PyQt5 + Siemens industrial CSS** with **pyqtgraph** for real-time charting. The architecture follows the 6-layer design established by `odmr-control`.

## Technology Stack

| Component | Version / Notes |
|-----------|-----------------|
| Python | 3.9+ |
| PyQt5 | >= 5.15 (GUI framework) |
| pyserial | >= 3.5 (RS-232 communication) |
| numpy | >= 1.24 (array operations) |
| pyqtgraph | >= 0.13 (real-time charting) |
| openpyxl | >= 3.0 (Excel export) |
| pyzmq | >= 25.0 (optional, ZMQ IPC) |
| pywin32 | >= 306 (optional, Windows NamedPipe) |

## Project Structure

```
main.py                     # Entry point: QApplication + Fusion style + core init
app/
  gui.py              # QMainWindow: Siemens CSS, 6-page nav, pyqtgraph charts
  config_io.py        # JSON config load/save with DEFAULT_CONFIG deep-merge fallback
core/
  commands.py         # CommandType enum + frozen Command dataclass
  command_service.py  # Single-threaded command bus (queue.Queue)
  instrument_controller.py  # Facade: manages Driver + Worker lifecycles
  external_ipc.py     # ZMQ PUB/REP + Windows NamedPipe server
workers/
  ch1600_stream_worker.py   # High-speed streaming QThread (DATA?> frames)
  ch1600_monitor_worker.py  # Low-rate status polling QThread (unit/range)
instruments/
  ch1600_driver.py    # RS-232 driver: 16 commands + 6 model-aware frame parsers
data/
  circular_buffer.py  # Thread-safe multi-channel ring buffer with downsampling
  recorder.py         # CSV recorder with dynamic schema and auto rollover
  review_loader.py    # Historical data loader (CSV/TXT/SQLite -> normalized arrays)
  sqlite_store.py     # SQLite session/sample/raw-frame/export store
  reporting.py        # HTML report exporter + threshold evaluation
  spatial.py          # Heatmap grid builders for spatial scan data
tests/                      # unittest-based test suite
docs/                       # Command reference, OCR manuals, reverse-engineering notes
experiments/                # Runtime output directory (CSV, SQLite)
config.json                 # User config (deep-merged over DEFAULT_CONFIG)
requirements.txt            # Core dependencies
requirements-optional.txt   # Optional integrations (ZMQ, pywin32)
run_ch1600.bat / .sh        # Windows/Bash launchers (activate conda)
```

## Architecture and Signal Flow

**Layer model (bottom-up):**

1. **Data**: `CircularBuffer`, `CH1600Recorder`, `CH1600SQLiteStore`, `review_loader`
2. **Instruments**: `CH1600Driver` -- RS-232 serial I/O and frame parsing
3. **Core + Workers**: `InstrumentController` (facade), `CommandService` (command bus), `CH1600StreamWorker` / `CH1600MonitorWorker` (QThreads)
4. **App**: `GaussMeterGUI` -- 6-tab main window subscribing to CommandService signals

**Three-level signal broadcast:**

```
CH1600Driver -> InstrumentController (pyqtSignal)
  -> CommandService (forward) -> GUI (subscribe and update)
```

**Thread model:**

- **Main thread**: GUI + QTimer (30 ms display refresh -> ~33 FPS)
- **CommandService thread**: `threading.Thread`, serializes all hardware commands via `queue.Queue`
- **StreamWorker thread**: `QThread`, tight non-blocking loop reading serial stream data
- **MonitorWorker thread**: `QThread`, polls unit/range at configured interval (default 500 ms, min 100 ms)
- **IPC threads**: daemon threads for ZMQ REP and NamedPipe servers

**Command bus pattern:**

- `CommandService.submit(cmd)` -- asynchronous, returns `request_id`
- `CommandService.submit_sync(cmd, timeout)` -- synchronous, uses `QEventLoop` to wait for Qt cross-thread signals
- `CH1600_START_STREAM` and `CH1600_STOP_STREAM` are **routed to errors**; streaming must be started/stopped via `start_acquisition()` / `stop_acquisition()` on the main thread because they create `QThread` objects

## Build, Run, and Test Commands

### Installation

```bash
pip install -r requirements.txt
# Optional:
pip install -r requirements-optional.txt
```

### Run

```bash
python main.py
```

Or use the provided launchers:

```bash
# Windows
run_ch1600.bat

# Bash (Git for Windows / WSL)
./run_ch1600.sh
```

Both launchers activate a conda environment at `D:\anaconda3` and run `python main.py`.

### Compile Check

```bash
python -m compileall app core data instruments workers tests
```

### Run Tests

```bash
python -m unittest discover -v
```

Test files:

- `tests/test_ch1600_driver.py` -- Frame parsing for all 6 device models, command framing
- `tests/test_recorder.py` -- CSV schema and rollover logic
- `tests/test_review_loader.py` -- Mixed schema merge, DataReader2 tab-text compatibility, HTML/heatmap
- `tests/test_sqlite_store.py` -- Session/sample/raw-frame lifecycle and reopen
- `tests/test_external_ipc.py` -- JSON commands and legacy DataReader2 NamedPipe protocol
- `tests/test_gui_smoke.py` -- GUI instantiation and review heatmap (uses offscreen platform)

## Configuration

Configuration lives in `config.json` at the project root. `app/config_io.py` provides `load_config()` which deep-merges the file over `DEFAULT_CONFIG` (hard-coded fallback). `save_config()` writes back to JSON.

Key configuration sections:

- `ch1600` -- serial port, baudrate (default 115200), batch size/interval
- `device_model` -- one of: `1d_gauss`, `2d_gauss`, `3d_gauss`, `fluxmeter`, `1d_fluxgate`, `3d_fluxgate`
- `acquisition` -- save directory, auto-save, mode key, zero offset, threshold channel, rollover settings
- `database` -- SQLite path, enabled flag, store_raw_frames
- `monitor` -- polling interval in ms (default 500)
- `ui` -- display interval, chart history points, downsample, colors, line width, window size
- `external_ipc` -- ZMQ/NamedPipe enable, ports, pipe name

The `ACQ_MODE_TABLE` in `config_io.py` maps mode keys to:

- label, expected FPS, decimal places, X-axis window seconds, downsample factor
- resolution, accuracy, hardware start command (`DATA?>`, `FAST020>` ~ `FAST300>`)

## Code Style Guidelines

- **Language**: Docstrings and comments are written in **Chinese** (mixed with English technical terms). Follow this convention.
- **Type hints**: Use `from __future__ import annotations` and modern type hints (`dict`, `list`, `|` union).
- **String formatting**: Use f-strings for formatting.
- **Threading**: Driver serial access is protected by `threading.Lock`. Buffer access is protected by its own lock. GUI state that is only read/written from the main thread does not need locks.
- **Qt patterns**: Use `QObject.moveToThread(QThread)` for workers. Connect signals before starting threads.
- **Error handling**: Emit errors via `pyqtSignal(str)` to the GUI rather than raising in worker threads. Track consecutive errors and exit after a max threshold (e.g., 20 for stream, 5 for monitor).

## CH-1600 Serial Protocol

- **Physical**: RS-232C, DB-9 Female (DCE), baud 19200/57600/115200 (default), 8N1, no hardware handshake
- **Command terminator**: CR (`\r`, 0x0D)
- **Response terminator**: LF (`\n`)
- **Max command rate**: 10 commands/sec for query-response modes
- **Streaming mode**: `DATA?>` sends continuous frames, unbounded rate

**High-speed mode commands:**

| Mode | Command | Rate |
|------|---------|------|
| Normal | `DATA?>` | ~4--10 Hz |
| Fast 20 | `FAST020>` | 20 Hz |
| Fast 50 | `FAST050>` | 50 Hz |
| Fast 100 | `FAST100>` | 100 Hz |
| Fast 200 | `FAST200>` | 200 Hz |
| Fast 300 | `FAST300>` | 300 Hz |

**1D Gauss shortcut**: For `dc_20hz` and `ac_20hz` on `1d_gauss`, the driver sends `FAST2>` instead of `FAST020>`.

**Data frame formats** vary by `device_model`. All parsers return a unified dict with keys:
`field_x_mt`, `field_y_mt`, `field_z_mt`, `field_total_mt`, `freq_hz`, `temp_c`, `field_mt` (backward-compat alias).

## Adding Features

- **New serial commands**: Add to `CommandType` enum -> `_execute()` routing in `command_service.py` -> driver method in `ch1600_driver.py` -> controller convenience method in `instrument_controller.py`
- **New UI pages**: Add `_build_*_page()` in `app/gui.py`, add nav item in `_setup_ui()`, update `_nav_items`
- **New worker**: Follow `QObject + moveToThread(QThread)` pattern, connect signals in `InstrumentController`
- **New IPC command**: Add callback in `gui.py __init__`, handle in `external_ipc.py._handle_command()`
- **New device model**: Add entry to `CH1600Driver.DEVICE_MODEL_TABLE` and `_parse_*()` static method, update `recorder.py` schema and `gui.py` channel initialization

## Security Considerations

- Serial port access requires appropriate OS permissions.
- No network exposure by default. ZMQ binds to `tcp://*:<port>` only when explicitly enabled in config.
- `config.local.json` is listed in `.gitignore` for local secrets; do not commit it.
- The application runs with user-level privileges; no elevation is required.

## Documentation References

- `docs/CH-1600_commands_reference.md` -- Complete serial command reference (Chinese)
- `docs/CH-1600详细版-说明书.pdf_by_PaddleOCR-VL-1.5.md` -- OCR of the Chinese user manual
- `docs/reverse_engineering_findings.md` -- Notes from reverse-engineering the original DataReader2 C# application
- `docs/improvement_roadmap.md` -- Planned improvements and known issues
