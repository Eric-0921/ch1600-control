# CLAUDE.md — CH-1600 Gauss Meter Control

## Project Overview

High-performance Python control and data acquisition program for the CH-1600 Digital Gauss Meter. Follows the 6-layer architecture established by `odmr-control`.

## Architecture

```
Layer 5 (UI):        app/gui.py, app/config_io.py
Layer 4 (Service):   core/command_service.py
Layer 3 (Control):   core/instrument_controller.py, core/commands.py
Layer 3 (IPC):       core/external_ipc.py          ← ZMQ + NamedPipe
Layer 1 (Driver):    instruments/ch1600_driver.py
Layer 0 (Data):      data/circular_buffer.py,
                     data/recorder.py,
                     data/review_loader.py           ← Historical playback
Workers:             workers/ch1600_stream_worker.py,
                     workers/ch1600_monitor_worker.py
```

## Key Patterns

- **Signal broadcast**: Driver → InstrumentController (pyqtSignal) → CommandService (forward) → GUI (subscribe)
- **Thread model**: Main (GUI+QTimer 30ms), CommandService (threading.Thread), StreamWorker (QThread), MonitorWorker (QThread), IPC threads (daemon)
- **Command bus**: Single-threaded `queue.Queue` in CommandService, `submit()` async / `submit_sync()` blocking
- **Config**: `config.json` with `DEFAULT_CONFIG` deep-merge fallback in `config_io.py`
- **Style**: Siemens industrial CSS (`SIEMENS_STYLE`) applied at QApplication level with Fusion style

## GUI Pages (6 tabs)

| Index | Page | Key Features |
|-------|------|-------------|
| 0 | Connection | Port scan, baud rate, connect/disconnect |
| 1 | Parameters | Acquisition mode, threshold settings, zero offset, **IPC enable** |
| 2 | Live Data | Real-time chart, **5-unit display**, **threshold alarm**, **data table**, **chart config** |
| 3 | Data Review | Load CSV/TXT, multi-file merge, historical waveform, statistics |
| 4 | Debug | Hex/ASCII serial monitor, manual TX, quick-command buttons |
| 5 | Log | Application log with clear button |

## CH-1600 Protocol

- RS-232C: 115200 bps default, 8N1, CR terminator (0x0D), half-duplex
- Max 10 commands/sec for query-response; `DATA?>` streaming mode is unbounded
- High-speed modes: `FAST020>` ~ `FAST300>` (20–300 Hz)
- Data frame: `#±xxxxx.xxxx/xxx/±xxxx>\n` → field_mt / freq_hz / temp_c

## External IPC

- **ZMQ PUB** (`tcp://*:5555`): broadcasts latest data point as JSON
- **ZMQ REP** (`tcp://*:5556`): receives JSON commands (`start_acquisition`, `stop_acquisition`, `get_status`)
- **NamedPipe** (`\\.\pipe\m1600_control`): Windows-only command server
- Auto-starts/stops with acquisition stream

## Data Export

- **Excel**: `openpyxl`, SimSun headers, `'` prefix prevents auto-formatting
- **TXT**: tab-delimited, UTF-8 BOM, DataReader2-compatible

## File Rollover

- `CH1600Recorder` supports size/row-based rollover
- Strategy: `"new_file"` (suffix `_2`, `_3`…) or `"stop"`
- Real-time file size shown in GUI status bar

## Adding Features

- **New serial commands**: add to `CommandType` enum → `_execute()` routing → driver method → controller convenience
- **New UI pages**: add to `_build_*_page()` in gui.py, add nav item in `_setup_ui()`, update `_nav_items`
- **New worker**: follow `QObject + moveToThread(QThread)` pattern, connect signals in controller
- **New IPC command**: add callback in `gui.py __init__`, handle in `external_ipc.py._handle_command()`

## Dependencies

Core: `PyQt5>=5.15`, `pyserial>=3.5`, `numpy>=1.24`, `pyqtgraph>=0.13`
Export: `openpyxl>=3.0`
IPC: `pyzmq>=25.0`, `pywin32` (Windows only)
