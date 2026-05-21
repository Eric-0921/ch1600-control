# Changelog

## [Unreleased] - 2026-05-21

### Added

- Added `reverse-engineered-debugv3/` as the reverse-engineering workspace for
  the vendor CH-1600/DataReader2 debug software, including decompiled-source
  notes, protocol findings, GUI command mapping, live COM13 validation notes,
  and agent handoff documentation.
- Added prominent agent/maintainer warnings in project documentation. These
  warnings record that future agents must not replace live-device findings with
  conservative manual guesses, especially around command framing and high-speed
  mode commands.

### Changed

- Updated the runtime protocol implementation to follow the decompiled vendor
  source and real CH-1600 validation:
  - CH-1600 commands are sent as raw ASCII frames with no CR/LF appended.
  - 20 Hz high-speed acquisition uses `FAST2>` on the tested CH-1600.
  - 150 Hz, 250 Hz, and 300 Hz modes are explicit `FAST150>`, `FAST250>`, and
    `FAST300>` entries.
  - High-speed single-value frames such as `#+0000.1433>` are parsed.
  - Low-rate monitor polling is not started during high-speed acquisition.
  - Preview/panel stream detection no longer suppresses `DATAC>` recovery.
  - Scan failure no longer disables manual COM-port connection.
- Fixed chart export for pyqtgraph 0.14.0 by importing
  `pyqtgraph.exporters` explicitly and selecting `SVGExporter` for SVG output.

### Validation

- Live device validation on `COM13` confirmed:
  - `scan_ports()` returns `CH-1600 [DATA?> verified]`.
  - `connect("COM13", 115200)` returns `CH-1600@COM13 (DATA?> verified)`.
  - `FAST2>` produces parseable high-speed frames.
- `python -m unittest discover -v` passed with 79 tests.
- `python -m compileall app core data instruments workers tests` passed.

All notable changes to this project are documented in this file.

## [Unreleased] — 2026-05-18

Roadmap execution pass focused on turning px-1-inspired features into testable
building blocks and documenting the remaining maturity gaps for follow-up
agents.

### Added

- **Scientific measurement presentation**
  - Added `data/measurement_analysis.py` for shared live/review metrics: min/max/mean/std/RMS/peak-to-peak/abs peak/drift/slope/sample rate/duration.
  - Added threshold event summaries with NG count, event count, NG ratio, and longest NG interval.
  - Added vector summaries for 2D/3D probes: direction angle, inclination, direction stability, and component share.
  - Added `data/spatial_analysis.py` for spatial min/max/mean/std, uniformity, gradient, hotspot/coldspot, and profile extraction.
  - Live Data now includes a Measurements panel with current value, Min, Max, Pk-Pk, RMS, Std, actual sample rate, window duration, threshold events, and vector direction.
  - Live and Review time plots now support dual cursors, peak/trough labels, mean reference line, and threshold reference lines.
  - Added live trigger capture v1 with threshold-NG, rising-edge, falling-edge, Single/Arm state, event count, and trigger markers on the live plot.
  - Trigger capture now stores pre/post-trigger replay windows, shows a compact event table, replays the selected/latest event on the live plot, and persists events to SQLite `trigger_events`.
  - Replaced the live `QTableWidget` update path with a `QAbstractTableModel`/`QTableView` cache to reduce high-rate row insertion/removal overhead.
  - Review Plots now include a Spectrum tab using NumPy FFT over the active review dataset/selection.
  - HTML reports now include RMS, Std, Pk-Pk, sample rate, threshold event summary, and spatial scan summary.

- **Conda-first workflow documentation**
  - Roadmap now states that dependency installation, automated testing, and formal runtime are expected to use the conda environment by default.
  - Default validation commands use `conda activate <env-or-D:/anaconda3>` followed by `python -m pip ...`, `compileall`, `unittest`, and `python main.py`.

- **SQLite experiment store** (`data/sqlite_store.py`)
  - Added `sessions`, `samples`, `raw_frames`, and `exports` tables.
  - Added session lifecycle, sample append/query, raw frame traceability, and export provenance APIs.
  - GUI can load review data from SQLite by `session_id` and `source`.

- **Unified review dataset** (`data/review_loader.py`)
  - Normalizes m1600 CSV, DataReader2 tab-delimited TXT, and SQLite query results into one structured dtype.
  - Supports mixed 1D/2D/3D schemas without dtype concat errors.
  - Adds sequence/time/source/session filtering and selected-range CSV export.

- **Review selection workflow** (`app/gui.py`)
  - Added sequence range, relative time range, session/source filters.
  - Added table selection and plot ROI linkage.
  - Added manual X/Y axis presets and selected-range CSV export.

- **HTML reporting** (`data/reporting.py`, `app/gui.py`)
  - Added HTML report exporter with statistics and SVG curve.
  - Added threshold evaluation summary.
  - Added optional spatial heatmap SVG section when review data contains `x_mm/y_mm`.
  - Added input file SHA256 metadata for reproducibility.
  - Export records are stored in SQLite `exports` when the database is available.

- **Spatial heatmap foundation** (`data/spatial.py`, `app/gui.py`)
  - Added `build_heatmap_grid()` for `x_mm/y_mm` spatial scan data.
  - Added NumPy-only IDW interpolation via `build_interpolated_heatmap_grid()`.
  - Review page now has separate `Time` and `Heatmap` views to avoid confusing 3-axis time traces with spatial maps.
  - Heatmap supports value-channel selection, raw/interpolated grids, automatic/manual levels, LUT color bar, contour overlay, and PNG export.

- **Optional 3D Surface preview** (`data/spatial.py`, `app/gui.py`)
  - Added `build_surface_grid()` as the data interface for spatial scalar-field surfaces.
  - Review page now includes a `3D Surface` tab that reuses heatmap value channel, grid mode, resolution, and levels.
  - 3D rendering uses optional `pyqtgraph.opengl`/`PyOpenGL`; missing OpenGL dependencies show a clear disabled state while the rest of the GUI keeps working.
  - Added 3D PNG export and SQLite export provenance type `surface_3d_png`.

- **GUI rendering/performance seam** (`app/gui.py`, `app/surface_renderer.py`)
  - Added a small 3D surface renderer adapter around `pyqtgraph.opengl`, so a future PyVista/VTK backend can be evaluated without rewriting the review page.
  - Review plots now refresh only the active `Time` / `Heatmap` / `3D Surface` tab, avoiding unnecessary heatmap interpolation or OpenGL work while another view is visible.
  - Live data table updates are buffered and flushed every 150 ms instead of inserting rows inside the stream batch callback.

- **Device/probe capability matrix** (`data/device_capabilities.py`)
  - Added `DeviceCapability`, `ProbeProfile`, `get_device_capability()`, `get_probe_profile()`, and `normalize_sample_by_capability()`.
  - Centralized 1D/2D/3D Gauss, Fluxmeter, 1D/3D Fluxgate units, channels, frequency/temperature support, recorder schema, table columns, and threshold channels.
  - Added probe profiles for the documented HCHD801F standard Hall probe, weak-field probe, and custom/unknown probes.
  - GUI now exposes probe profile metadata and uses the capability matrix for device model options, live table columns, display units, threshold channels, and buffer channels.

- **Optional IPC dependencies**
  - Moved `pyzmq` out of base `requirements.txt` into `requirements-optional.txt`.
  - GUI disables ZMQ controls when `pyzmq` is unavailable instead of failing import.
  - Added optional `PyOpenGL` for the review-page 3D Surface preview.

- **Runtime validation record** (`docs/runtime_validation.md`)
  - Installed optional dependencies on the target machine's active `py -3` Python environment: PyOpenGL 3.1.10, pyzmq 27.1.0, and pywin32 311.
  - Recorded GUI/OpenGL validation artifacts under `experiments/runtime_validation/`.
  - Captured that `conda` is not currently on PATH in this PowerShell session.

- **DataReader2 legacy IPC compatibility** (`core/external_ipc.py`)
  - JSON API still works.
  - Added tab-delimited `GD`, `SG`, and `ST` command parsing.
  - `SG` follows reverse-engineered DataReader2 behavior and stops acquisition.
  - `ST` is parsed and echoed but does not silently mutate GUI state.

- **Regression tests**
  - Added standard unittest discovery entry.
  - Added tests for fake serial framing, DataReader2 legacy IPC, GUI offscreen smoke, SQLite store, recorder rollover, review loader/reporting/spatial heatmap, and device capabilities.
  - Current local baseline: `python -m unittest discover -v` runs 54 tests.

### Changed

- **Command framing** (`instruments/ch1600_driver.py`)
  - `_send_command()` now accepts either command bodies or full `...>` protocol frames and appends `>`/`\r` consistently.
  - Fixed `FASTxxx>`/`DATA?>` paths that could previously lose `>`.
  - 1D gaussmeter 20 Hz still uses DataReader2's `FAST2>` shorthand.

- **Panel streaming preview**
  - Added `parse_first_stream_frame()` so connection probing splits CR/LF preview buffers and parses the first valid frame instead of treating multiple frames as one malformed line.

- **Special prefix scaling**
  - `HST/HSE` prefixes now normalize raw values by `×0.1`.
  - `UHS` prefixes now normalize raw values by `×0.0001`.
  - Special-prefix temperature remains raw Celsius, matching DataReader2 source behavior.

- **2D long-frame compatibility**
  - Parser accepts both two-segment `X/f/t;Y/f/t>` frames and DataReader2's suspicious three-segment `dg2[2]` Y-channel behavior.
  - True segment meaning still needs real device samples.

- **A/m conversion**
  - GUI gaussmeter A/m conversion now uses `×795.77` because m1600 stores normalized mT internally.
  - The apparent DataReader2 `79.577` branch is explained by `HST/HSE` raw values being 0.1 mT units before display conversion.

- **3D Surface color handling**
  - Flattened OpenGL vertex colors for pyqtgraph 0.14.0, fixing an `IndexError` seen during target-machine 2x2 surface export.

- **Roadmap documentation**
  - `docs/improvement_roadmap.md` now includes maturity semantics, incomplete work overview, changed-file handoff notes, and validation commands.
  - `docs/reverse_engineering_findings.md` now includes a 2026-05-18 line-by-line difference matrix for DataReader2 vs Python behavior and manual-derived probe/dimension notes.

### Known Gaps

- No real CH-1600 hardware or logic-analyzer validation yet for FAST frame rates, special prefixes, or 2D three-segment long frames.
- ZMQ/NamedPipe dependencies are installed locally, but no real Windows NamedPipe or external ZMQ client integration test has been run yet.
- Review loader still runs on the GUI thread; large-file loading needs a worker.
- 300 Hz realtime table is now throttled, but it still uses `QTableWidget`; a true `QAbstractTableModel`/virtual table remains the mature solution for long high-rate sessions.
- 3D surface is now a v1 optional OpenGL preview and has passed target-machine smoke/export validation; real spatial scan samples, PyVista spike, PDF export, and print preview remain pending.
- Fluxmeter/Fluxgate are unit-aware at UI/review/report layers, but some compatibility aliases still use `_mt` names.

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
- Initial pass used DataReader2's special-prefix-looking A/m factor. This was corrected on 2026-05-18: normalized mT values use **×795.77** for A/m.
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
  - HSTDC/HSEDC/UHSDC 前缀帧的 field 值额外缩放（2026-05-18 已实现默认缩放，仍需硬件验证）
  - 2D 长帧 `dg2[2]` 索引疑云（DataReader2 源码疑似 bug）
  - Fluxmeter `\0` 去除循环的无限循环风险
  - `#` 前缀检查的严格化决策
  - 阈值判断仅基于 X 轴的 DataReader2 行为 vs m1600 基于 Total B 的设计差异
  - 审查方法论 6 条建议

### Dependencies Added
- `openpyxl` — Excel export (already present in Anaconda environment)
- `pyzmq` — ZMQ IPC (already present in Anaconda environment)
- `pywin32` — NamedPipe support (Windows only, already present)

## 2026-05-19 — Reliability Fixes Without Hardware Dependencies

### Fixed
- Tightened serial discovery so `scan_ports()` only returns ports that answer `UNIT?>` with a recognized CH-1600 unit. Unverified serial devices are no longer shown as `CH-1600?` candidates.
- Changed connection verification so an invalid or empty `UNIT?>` response raises an error and closes the serial handle instead of enabling the GUI in an unverified state.
- Disabled the Connect button until a verified scan result exists, and guarded against connecting the placeholder `No device found` row.
- Reworked software zeroing for 2D/3D devices: offsets are now stored per component (`field_x_mt`, `field_y_mt`, `field_z_mt`) and Total B is recomputed from corrected components. The legacy scalar offset remains for 1D/backward compatibility.
- Raised the monitor worker minimum interval to 250 ms because each polling cycle sends two serial commands (`UNIT?` and `RANGE?`), keeping the command rate under the 10 cmd/s protocol limit.
- Flushed CSV recorder writes after each point/batch to reduce data loss if the process exits unexpectedly.

### Tests
- Added fake-serial coverage for rejecting unverified connection responses and omitting unverified ports from scan results.
- Added GUI smoke coverage for component-wise zero offsets and disabled Connect state when no verified ports are found.
- Added monitor worker rate-limit coverage.
