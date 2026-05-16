# CLAUDE.md — CH-1600 Gauss Meter Control

## Project Overview

High-performance Python control and data acquisition program for the CH-1600 Digital Gauss Meter. Follows the 6-layer architecture established by `D:\git-zbw\odmr-control`.

## Architecture

```
Layer 5 (UI):      app/gui.py, app/config_io.py
Layer 3-4 (Core):  core/command_service.py, core/instrument_controller.py, core/commands.py
Layer 1 (Driver):  instruments/ch1600_driver.py
Layer 0 (Data):    data/circular_buffer.py, data/recorder.py
Workers:           workers/ch1600_stream_worker.py, workers/ch1600_monitor_worker.py
```

## Key Patterns

- **Signal broadcast**: Driver → InstrumentController (pyqtSignal) → CommandService (forward) → GUI (subscribe)
- **Thread model**: Main (GUI+QTimer 30ms), CommandService (threading.Thread), StreamWorker (QThread), MonitorWorker (QThread)
- **Command bus**: Single-threaded `queue.Queue` in CommandService, `submit()` async / `submit_sync()` blocking
- **Config**: `config.json` with `DEFAULT_CONFIG` deep-merge fallback in `config_io.py`
- **Style**: Siemens industrial CSS (`SIEMENS_STYLE`) applied at QApplication level with Fusion style

## CH-1600 Protocol

- RS-232C: 115200 bps default, 8N1, CR terminator (0x0D), half-duplex
- Max 10 commands/sec for query-response; DATA?> streaming mode is unbounded
- Data frame: `#±xxxxx.xxxx/xxx/±xxxx>\n` → field_mt / freq_hz / temp_c

## Running

```bash
python main.py
```

## Adding features

- New serial commands: add to `CommandType` enum → `_execute()` routing → driver method → controller convenience
- New UI pages: add to `_build_*_page()` in gui.py, add nav item in `_setup_ui()`
- New worker: follow `QObject + moveToThread(QThread)` pattern, connect signals in controller

## Dependencies

PyQt5>=5.15, pyserial>=3.5, numpy>=1.24, pyqtgraph>=0.13
