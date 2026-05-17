# CH-1600 Digital Gauss Meter Control & Data Acquisition

[![Python](https://img.shields.io/badge/Python-3.9+-blue.svg)](https://www.python.org/)
[![PyQt5](https://img.shields.io/badge/PyQt-5.15-green.svg)](https://www.riverbankcomputing.com/software/pyqt/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A high-performance Python application for controlling and acquiring data from the CH-1600 Digital Gauss Meter / Teslameter (北京翠海佳诚磁电科技). Features real-time magnetic field visualization at 30+ FPS with an industrial-grade Siemens-style UI.

## Features

- **30+ FPS real-time chart** — pyqtgraph-based waveform display with adaptive downsampling
- **Hardware sampling rate control** — `FAST020>` ~ `FAST300>` commands for true high-speed acquisition (20–300 Hz)
- **5-unit display** — real-time switching between mT, G, Oe, A/m, mGs (CSV always stores raw mT)
- **Threshold alarm** — NG/OK real-time status with closed/open interval and ABS modes
- **Real-time data table** — scrollable QTableWidget with configurable row limit (100–5000)
- **CSV data recording** — batch-write with UTF-8 BOM encoding; auto file rollover by size or row count
- **Data export** — Excel (`.xlsx`, SimSun headers, auto-format protection) and tab-delimited TXT
- **Data review** — load historical CSV/TXT files, multi-file merge, waveform playback with dual Y-axes
- **Raw serial debug** — Hex/ASCII TX/RX monitor with manual command input and quick buttons
- **External IPC** — ZMQ PUB/REP + Windows NamedPipe for third-party integration
- **Chart customization** — curve colors, line width, history points, manual/auto Y-axis range
- **Industrial UI** — Siemens-style dark/light theme with connection/stream/record status LEDs
- **6-layer architecture** — clean separation: data → instruments → core → workers → app

## Screenshots

```
┌──────────────────────────────────────────────────────────┐
│ [● conn] [● stream] [○ rec]  mT | Auto  FPS: 33.2  12580 pts │
├──────────┬───────────────────────────────────────────────┤
│ 连接     │  ┌─────────────────────────────────────────┐  │
│ 参数     │  │  磁场: -12345.6789 mT                    │  │
│ 实时数据 │  │  频率: 50 Hz    温度: 23.4 °C            │  │
│ 数据回看 │  │  ┌─────────────────────────────────────┐│  │
│ 调试     │  │  │    ╱╲    ╱╲   ← 磁场波形 33 FPS     ││  │
│ 日志     │  │  │───╱────╲╱────╲───────────────────  ││  │
│          │  │  └─────────────────────────────────────┘│  │
│          │  └─────────────────────────────────────────┘  │
└──────────┴───────────────────────────────────────────────┘
```

## Quick Start

### Prerequisites

- Python 3.9+
- CH-1600 Digital Gauss Meter connected via RS-232 (or USB-to-RS232 adapter)

### Installation

```bash
git clone https://github.com/YOUR_USERNAME/ch1600-control.git
cd ch1600-control
pip install -r requirements.txt
```

### Run

```bash
python main.py
```

1. Click **扫描端口 / Scan Ports** to detect the CH-1600
2. Click **连接 / Connect** to establish the serial connection
3. Click **开始采集 / Start Acquisition** to begin real-time data streaming
4. Use **数据记录 / Recording** panel to save data to CSV
5. Use **数据回看 / Data Review** page to load and visualize historical data

## Architecture

```
main.py                     # Entry point (QApplication + Fusion style)
├── app/
│   ├── gui.py              # QMainWindow (Siemens CSS, 6 pages, pyqtgraph)
│   └── config_io.py        # JSON config load/save with deep-merge fallback
├── core/
│   ├── commands.py         # CommandType enum + Command dataclass
│   ├── command_service.py  # Single-threaded command bus (queue.Queue)
│   ├── instrument_controller.py  # Facade + QThread worker lifecycle
│   └── external_ipc.py     # ZMQ PUB/REP + Windows NamedPipe server
├── workers/
│   ├── ch1600_stream_worker.py   # High-speed streaming with mode-aware start
│   └── ch1600_monitor_worker.py  # Low-rate status polling
├── instruments/
│   └── ch1600_driver.py    # RS-232 driver (all 16 commands + FASTxxx>)
└── data/
    ├── circular_buffer.py  # Thread-safe ring buffer with downsampling
    ├── recorder.py         # CSV recorder with auto file rollover
    └── review_loader.py    # Historical CSV/TXT loader + merge
```

**Signal flow:** `CH1600Driver → InstrumentController → CommandService → GUI`

**IPC flow:** `CommandService → GUI → ExternalIPCService → ZMQ/NamedPipe clients`

## CH-1600 Serial Protocol

| Parameter | Value |
|-----------|-------|
| Connector | DB-9 Female (DCE) |
| Baud rates | 19200 / 57600 / 115200 (default) |
| Format | 1 start + 8 data + 1 stop, no parity |
| Terminator | CR (`\r`, 0x0D) |
| Max command rate | 10 commands/sec |

**Data frame (streaming):** `#±xxxxx.xxxx/xxx/±xxxx>\n`
- `field_mt`: magnetic field in mT
- `freq_hz`: frequency (000 for DC)
- `temp_c`: probe temperature ×10

**High-speed mode commands:**

| Mode | Command | Rate |
|------|---------|------|
| Normal | `DATA?>` | ~4–10 Hz |
| Fast 20 | `FAST020>` | 20 Hz |
| Fast 50 | `FAST050>` | 50 Hz |
| Fast 100 | `FAST100>` | 100 Hz |
| Fast 200 | `FAST200>` | 200 Hz |
| Fast 300 | `FAST300>` | 300 Hz |

See [docs/CH-1600_commands_reference.md](docs/CH-1600_commands_reference.md) for the complete command set.

## Configuration

Edit `config.json` to customize:

```json
{
  "ch1600": {
    "port": "COM1",
    "baudrate": 115200
  },
  "acquisition": {
    "save_dir": "./experiments",
    "mode_key": "dc_normal",
    "max_file_size_mb": 100,
    "max_file_rows": 100000,
    "rollover_strategy": "new_file"
  },
  "ui": {
    "display_interval_ms": 30,
    "chart_history_points": 5000,
    "chart_colors": {
      "field": "#0080c8",
      "freq": "#00a651"
    },
    "chart_line_width": 2
  },
  "external_ipc": {
    "enabled": false,
    "mode": "zmq",
    "zmq_data_port": 5555,
    "zmq_cmd_port": 5556,
    "namedpipe_name": "m1600_control"
  }
}
```

## Dependencies

- **PyQt5** ≥ 5.15 — GUI framework
- **pyserial** ≥ 3.5 — RS-232 communication
- **numpy** ≥ 1.24 — array operations
- **pyqtgraph** ≥ 0.13 — real-time charting
- **openpyxl** ≥ 3.0 — Excel export
- **pyzmq** ≥ 25.0 — ZMQ IPC (optional)
- **pywin32** — NamedPipe support on Windows (optional)

## Changelog

See [CHANGELOG.md](CHANGELOG.md) for a detailed list of all changes.

## License

MIT License. See [LICENSE](LICENSE) for details.

## Related Projects

This project follows the architecture of [ODMR Control](https://github.com/...) — a multi-instrument quantum sensing control system.

## References

- [CH-1600 User Manual (Chinese)](docs/CH-1600详细版-说明书.pdf_by_PaddleOCR-VL-1.5.md)
- [CH-1600 Command Reference](docs/CH-1600_commands_reference.md)
- [Reverse Engineering Findings](docs/reverse_engineering_findings.md)
- [Improvement Roadmap](docs/improvement_roadmap.md)
