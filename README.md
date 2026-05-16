# CH-1600 Digital Gauss Meter Control & Data Acquisition

[![Python](https://img.shields.io/badge/Python-3.9+-blue.svg)](https://www.python.org/)
[![PyQt5](https://img.shields.io/badge/PyQt-5.15-green.svg)](https://www.riverbankcomputing.com/software/pyqt/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

A high-performance Python application for controlling and acquiring data from the CH-1600 Digital Gauss Meter / Teslameter (北京翠海佳诚磁电科技). Features real-time magnetic field visualization at 30+ FPS with an industrial-grade Siemens-style UI.

## Features

- **30+ FPS real-time chart** — pyqtgraph-based waveform display with adaptive downsampling
- **High-speed serial streaming** — dedicated QThread worker reads DATA?> stream at full device rate
- **Full device control** — all 16 RS-232 commands: zero, unit/range cycling, threshold alarm, panel lock
- **CSV data recording** — batch-write recording with UTF-8 BOM encoding
- **Industrial UI** — Siemens-style dark/light theme with connection/stream/record status LEDs
- **6-layer architecture** — clean separation: data → instruments → core → workers → app

## Screenshots

```
┌──────────────────────────────────────────────────────────┐
│  [● connected] [● streaming] [○ rec]  mT | Auto    FPS: 33.2   12580 pts │
├──────────┬───────────────────────────────────────────────┤
│ 连接     │  ┌─────────────────────────────────────────┐  │
│ 参数     │  │  磁场: -12345.6789 mT                    │  │
│ 实时数据 │  │  频率: 50 Hz    温度: 23.4 °C            │  │
│ 数据记录 │  │  ┌─────────────────────────────────────┐│  │
│ 日志     │  │  │     ╱╲    ╱╲                        ││  │
│          │  │  │    ╱  ╲  ╱  ╲   ← 磁场波形 33 FPS   ││  │
│          │  │  │───╱────╲╱────╲─────────────────── ││  │
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
4. Use **数据记录 / Recording** tab to save data to CSV

## Architecture

```
main.py                     # Entry point (QApplication + Fusion style)
├── app/
│   ├── gui.py              # QMainWindow (Siemens CSS, 5 pages, pyqtgraph)
│   └── config_io.py        # JSON config load/save
├── core/
│   ├── commands.py         # CommandType enum + Command dataclass
│   ├── command_service.py  # Single-threaded command bus (queue.Queue)
│   └── instrument_controller.py  # Facade + QThread worker lifecycle
├── workers/
│   ├── ch1600_stream_worker.py   # High-speed DATA?> streaming (2ms poll)
│   └── ch1600_monitor_worker.py  # Low-rate status polling
├── instruments/
│   └── ch1600_driver.py    # RS-232 driver (all 16 commands, frame parser)
└── data/
    ├── circular_buffer.py  # Thread-safe ring buffer with downsampling
    └── recorder.py         # CSV recorder (UTF-8 BOM)
```

**Signal flow:** `CH1600Driver → InstrumentController → CommandService → GUI`

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

See [docs/CH-1600_commands_reference.md](docs/CH-1600_commands_reference.md) for the complete command set.

## Configuration

Edit `config.json` to customize:

```json
{
  "ch1600": {
    "port": "COM1",
    "baudrate": 115200
  },
  "ui": {
    "display_interval_ms": 30,
    "chart_history_points": 5000
  },
  "acquisition": {
    "save_dir": "./experiments"
  }
}
```

## Dependencies

- **PyQt5** ≥ 5.15 — GUI framework
- **pyserial** ≥ 3.5 — RS-232 communication
- **numpy** ≥ 1.24 — array operations
- **pyqtgraph** ≥ 0.13 — real-time charting

## License

MIT License. See [LICENSE](LICENSE) for details.

## Related Projects

This project follows the architecture of [ODMR Control](https://github.com/...) — a multi-instrument quantum sensing control system.

## References

- [CH-1600 User Manual (Chinese)](docs/CH-1600详细版-说明书.pdf_by_PaddleOCR-VL-1.5.md)
- [CH-1600 Command Reference](docs/CH-1600_commands_reference.md)
