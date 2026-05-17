# Changelog

All notable changes to this project are documented in this file.

## [Unreleased] — 2026-05-17

Based on reverse-engineering findings from DataReader2.exe (ILSpy decompilation).

### P0 — Critical

#### Sampling Rate Commands (`FASTxxx>`)
- **Driver** (`instruments/ch1600_driver.py`): `start_streaming()` now sends hardware-specific start commands (`FAST020>` ~ `FAST300>`) based on the selected acquisition mode.
- **Config** (`app/config_io.py`): `ACQ_MODE_TABLE` extended with `start_command` field mapping each mode to its hardware command.
- **Worker** (`workers/ch1600_stream_worker.py`): Accepts `mode_key` parameter and passes it to the driver.
- **Controller / Service / GUI**: Full call-chain wired to propagate `mode_key` from config to driver.

#### Unit Conversion Display
- **GUI** (`app/gui.py`): Added 5-unit display matrix: **mT / G / Oe / A/m / mGs**.
- Conversion coefficients match DataReader2 exactly (×1 / ×10 / ×10 / ×79.577 / ×10000).
- Display unit is independent from device unit; CSV always stores raw mT values.
- User-selected display unit persisted in `config.json`.

### P1 — Important

#### Threshold Alarm Visualization (P1-1)
- Real-time **NG/OK** status label with red/green background.
- Supports three judge modes matching DataReader2 logic:
  - **Closed interval**: value inside [low, high] → OK (green)
  - **Open interval**: value inside (low, high) → NG (red)
  - **ABS**: take absolute value before judging

#### Real-Time Data Table (P1-2)
- `QTableWidget` with 5 columns: index, field (mT), frequency (Hz), temperature (°C), timestamp.
- Configurable max rows (100–5000), auto-scroll to latest.
- Performance-tested: smooth at 100 Hz streaming.

#### Raw Serial Debug Window (P1-3)
- New **Debug** page with dual-pane layout:
  - **RX area**: Hex/ASCII toggle, color-coded (blue = RX)
  - **TX area**: ASCII input with auto `>` suffix, Hex mode (space-separated bytes)
  - Quick-command buttons: `DATA?>`, `DATAC>`, `DATAS>`, `ZERO>`, `FAST020>`, `FAST100>`, `FAST300>`
- Uses `CH1600Driver.set_raw_log_callback()` hook for zero-overhead TX/RX logging.

#### Data Export — Excel & TXT (P1-4)
- **Excel** (`openpyxl`):
  - Header: SimSun (宋体), 12pt, bold, centered, thin borders
  - Values prefixed with `'` to prevent Excel auto-formatting
  - Row-by-row CSV read to avoid OOM on >100k rows
- **TXT**: Tab-delimited, UTF-8 BOM encoding, compatible with DataReader2 "Data Review" feature.
- Export source: current recording CSV or user-selected historical CSV.

### P2 — Optional

#### Auto File Rollover (P2-1)
- `CH1600Recorder` (`data/recorder.py`) now supports:
  - `max_file_size_mb` (default 100 MB)
  - `max_file_rows` (default 100,000 rows)
  - `rollover_strategy`: `"new_file"` (auto-increment suffix `_2`, `_3`…) or `"stop"`
- GUI status bar shows real-time file size and row count (1-second timer).
- Red warning on rollover-triggered stop with reason (rows / size).

#### Data Review — Historical Playback (P2-2)
- New **Data Review** page (`app/gui.py`) + `data/review_loader.py`:
  - Load single or multiple `.csv` / `.txt` files
  - Auto-detect delimiter (comma vs tab) and encoding (UTF-8 BOM)
  - Multi-file merge with timestamp sort + deduplication
  - pyqtgraph historical waveform with dual Y-axes (field on left, frequency on right)
  - Statistics panel: count, duration, min/max/mean field

#### External IPC — NamedPipe & ZMQ (P2-3)
- New `core/external_ipc.py`:
  - **ZMQ PUB** (`tcp://*:5555`): broadcasts latest data point as JSON
  - **ZMQ REP** (`tcp://*:5556`): receives JSON commands (`start_acquisition`, `stop_acquisition`, `get_status`)
  - **NamedPipe** (`\\.\pipe\m1600_control`): Windows-only command server
- GUI parameter page has enable checkboxes and port spinners.
- IPC auto-starts/stops with acquisition stream.
- Config persisted in `config.json` under `external_ipc` section.

#### Chart Interaction Enhancements (P2-4)
- **Curve colors**: `QColorDialog` picker for field and frequency curves, persisted in config.
- **Line width**: slider 1–5 px, real-time update.
- **History points**: slider 1,000–20,000 (step 1,000), controls `max_points` passed to `CircularBuffer.get()`.
- **Y-axis range**: Auto (default) or manual min/max input.
- **Save config** button writes all chart settings to `config.json`.

### Files Added
- `core/external_ipc.py`
- `data/review_loader.py`
- `experiments/test_review/test_loader.py` (test data + validation)

### Files Modified
- `app/gui.py` — major expansion (~2,100 lines, 6 pages, 40+ methods)
- `app/config_io.py` — new config sections: `external_ipc`, rollover params, chart colors
- `data/recorder.py` — rollover logic, file size monitoring
- `instruments/ch1600_driver.py` — `start_streaming(mode_key)`, raw log callback
- `workers/ch1600_stream_worker.py` — `mode_key` parameter
- `core/instrument_controller.py` — `mode_key` propagation
- `core/command_service.py` — `mode_key` propagation

### P2-5 (In Progress) — Multi-Device Model Support

#### Bug Fixes (Preparatory)
- **`FAST2>` command**: 1D gaussmeter 20Hz mode now uses `FAST2>` shorthand (was incorrectly `FAST020>` for all models).
- **Special prefix frames**: `parse_stream_frame()` now recognizes `HSTDC:`, `HSEDC:`, `UHSDC:` and 6 other prefixes used by certain CH-1600 batches.
- **IPC multidim payload**: `external_ipc.py` `publish_data()` now accepts `field_x/y/z/total` for future multidimensional broadcasts.
- **Review loader dynamic dtype**: `review_loader.py` infers column layout from CSV header, preparing for 2D/3D files.
- **Dynamic table columns**: Live data table columns adapt to device model (1D→5 cols, 2D→7 cols, 3D→8 cols).
- **Model-aware units**: Unit dropdown now shows `mWb` for fluxmeter and `nT` for fluxgate; conversion dictionaries are model-scoped.

#### Stage 1 — Driver Parser Layer
- **`DEVICE_MODEL_TABLE`**: Metadata dictionary for all 6 models (dimension, freq/temp support, default units).
- **`parse_stream_frame(model)`**: Dispatches to 6 private parsers based on `model` parameter (defaults to `1d_gauss` for backward compatibility).
- **Six parsers implemented**:
  - `_parse_1d_gauss` — standard short frame + 9 special prefixes
  - `_parse_2d_gauss` — short frame (`<40` chars) vs long frame (`;` delimited)
  - `_parse_3d_gauss` — short frame (`<60` chars) vs long frame (`;` delimited)
  - `_parse_fluxmeter` — strips leading `\0`, parses from 3rd character
  - `_parse_1d_fluxgate` — standard frame, nT precision
  - `_parse_3d_fluxgate` — `X/Y/Z` frame, no freq/temp
- **Unified return format**: All parsers return `{"field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt", "freq_hz", "temp_c", "field_mt"}` where `"field_mt"` is a backward-compat alias equal to `field_total_mt`.

#### Stage 2 — Data Layer
- **`CH1600Recorder`**: Dynamic schema per device model. Table header and `write_point`/`write_batch` now adapt to 1D/2D/3D/fluxmeter/fluxgate columns automatically.
- **`get_review_summary`**: Multi-channel statistics (min/max/mean/std for field_x/y/z/total, freq, temp).
- **`CircularBuffer`**: Already multi-channel capable; no changes required.

#### Stage 3 — Core Layer Propagation
- **`CH1600StreamWorker`**: Accepts `device_model` parameter, passes it to `parse_stream_frame()` and `start_streaming()`.
- **`InstrumentController.start_streaming`**: Forwards `device_model` to worker.
- **`CommandService.start_acquisition`**: Reads `device_model` from config and propagates through the stack.
- **Bugfix (GUI table placeholders)**: 2D/3D live data table was showing `"0.000000"` placeholders instead of actual `field_x/y/z_mt` values — now fixed.

#### Stage 4 — GUI Parameter Page
- **设备型号下拉框**: 6 种模型可选（1D/2D/3D 高斯计、磁通计、1D/3D 磁通门计）。
- **动态配置切换**: 切换型号后自动更新显示单位选项、实时表格列数、环形缓冲区通道、图表分量曲线可见性。
- **采集保护**: 采集中禁止切换型号，防止运行时通道不匹配。

#### Stage 5 — GUI Live Data Page
- **环形缓冲区动态通道**: `CircularBuffer` 根据 `device_model` 初始化通道（1D→3ch, 2D→5ch, 3D→6ch, 3D fluxgate→4ch）。
- **多通道数值显示**: `_update_live_display()` 根据型号显示 `X/Y/Z/Total B` 或单通道 `Field`。
- **多通道图表曲线**: 主曲线显示 Total B，额外添加 X(红)/Y(绿)/Z(橙) 分量曲线，自动根据型号显隐。
- **零点偏移全分量**: 软件零点偏移现在应用到所有 `field_*` 分量（而非仅 `field_mt`）。
- **Buffer 数据推入动态化**: 根据当前 buffer 通道列表自动构建数据字典，避免硬编码。

#### Stage 6 — GUI Review Page
- **回看图表兼容性**: 优先使用 `field_total_mt`，自动回退到 `field_mt`（兼容旧 CSV）。
- **多通道统计摘要**: `get_review_summary` 的 `channels` 统计在回看页面底部显示（X/Y/Z/Total min/max/mean）。

#### 经验文档落地
- **`docs/reverse_engineering_findings.md` 新增第 9 节**: “源码审查经验与隐藏细节”，记录：
  - 特殊前缀帧温度不 ÷10 的发现
  - HSTDC/HSEDC/UHSDC 前缀帧的 field 值额外缩放（当前版本未实现缩放，留待硬件验证）
  - 2D 长帧 `dg2[2]` 索引疑云（DataReader2 源码疑似 bug）
  - Fluxmeter `\0` 去除循环的无限循环风险
  - `#` 前缀检查的严格化决策
  - 阈值判断仅基于 X 轴的 DataReader2 行为 vs m1600 基于 Total B 的设计差异
  - 审查方法论 6 条建议

### Dependencies Added
- `openpyxl` — Excel export (already present in Anaconda environment)
- `pyzmq` — ZMQ IPC (already present in Anaconda environment)
- `pywin32` — NamedPipe support (Windows only, already present)
