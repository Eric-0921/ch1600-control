# 上级程序过度保守审查报告

日期: 2026-05-21  
目标项目: `D:\git-zbw\m1600`  
真机端口: `COM13`, 115200, CH-1600

## 背景结论

原厂 Debug 程序和当前 Python 上级程序都能让设备表盘进入 `transmitting`，但只有原厂 Debug 程序图表有响应。结合真机实测和代码审查，原因不是设备没有发送数据，而是上级程序在启动、验证、监控和解析失败处理上过度保守，导致“收到数据但不上报 UI”或“启动后被其他线程查询命令干扰”。

已经确认的底层协议差异:

- 真机接受裸 ASCII 命令，例如 `DATA?>`, `FAST2>`, `DATAC>`。
- 真机不响应 `DATA?>\r`。
- 高速帧为单值帧，例如 `#+0000.1536>`，普通帧为三段帧，例如 `#+0000.1357/000/+0283>`。
- 原厂 CH-1600 高速 20Hz 使用 `FAST2>`，不是 `FAST020>`。

## 多 Agent 审查分工

### Agent A: 驱动协议审查

审查范围: `instruments/ch1600_driver.py`

主要发现:

1. `connect()` 发现打开串口后已有数据帧时，会设置 `_panel_streaming_mode=True` 并返回“命令不可用”。
   这过度保守。当前真机虽然处于发送状态，但仍可能接受 `DATAC>`、`FASTxxx>` 等串口命令。把“已经在 streaming”直接等同于“命令不可用”，会让 GUI 禁用大量按钮。

2. `connect()` 必须通过 `UNIT?>` 或 `DATA?>` 验证才算连接成功。
   这过度保守。真机已知 `TYPE>` 返回 `M\n`，`UNIT?>` 可能不按预期响应。连接阶段应该优先完成串口打开，验证失败只作为警告，不应直接关闭端口。

3. `_probe_data_stream()` 会主动发送 `DATAC>`、`DATA?>`、`DATAC>`。
   连接验证改变了设备状态。对调试阶段有帮助，但放在普通连接流程中过重，容易和用户刚刚启动的采集状态打架。

4. `stop_streaming()` 在 `_panel_streaming_mode=True` 时不发送 `DATAC>`。
   这与真机观察不一致。既然真机可以被原厂 Debug 程序停止/切换，高层不应提前假设 `DATAC>` 无效。

5. `set_sample_rate()` 注释称“不启动流”，但 `FASTxxx>` 实际会让设备进入 transmitting。
   这会误导 GUI/命令服务的状态判断。

建议:

- 将 `_panel_streaming_mode` 改为“连接时检测到已有流”的弱状态，不要据此禁用命令。
- `stop_streaming()` 始终尝试发送 `DATAC>`，失败再降级为本地标记停止。
- 连接阶段允许“打开串口成功但身份验证未知”，并保留手动 Debug 命令能力。
- `FASTxxx>` 按“启动高速流”处理，而不是“只设置采样率”。

### Agent B: GUI / 线程链路审查

审查范围: `app/gui.py`, `core/command_service.py`, `core/instrument_controller.py`, `workers/ch1600_stream_worker.py`, `workers/ch1600_monitor_worker.py`

主要发现:

1. `CommandService.start_acquisition()` 在启动 stream worker 后立即启动 monitor worker。
   `CH1600MonitorWorker` 会在 `not driver.is_streaming` 时发送 `UNIT?>` 和 `RANGE?>`。启动阶段 `_streaming` 是由 stream worker 稍后设置的，因此存在窗口期: monitor 可能在高速流刚启动时插入查询命令，污染或打断数据流。

2. GUI 在 `_on_start_stream()` 中只要 `start_acquisition()` 返回 True，就立刻显示“采集中”。
   这只代表 QThread 已启动，不代表设备命令成功、不代表已经解析到第一批数据。若 worker 启动失败或一直收到不可解析帧，UI 仍会显示正在采集。

3. `CH1600StreamWorker` 只按 `\n` 分帧。
   真机/串口链路如果出现 `\r`、混合换行或残留内容，当前 worker 很容易卡在 buffer 中不解析。

4. `CH1600StreamWorker` 对解析失败保持沉默。
   如果 raw bytes 持续进入但 `parse_stream_frame()` 返回 None，GUI 不会知道“有数据但解析失败”。这就是 transmitting 但图表/表格完全没反应的关键表现。

5. worker 线程 cleanup 不完整，且 stop 路径会 `quit()` 后再 `terminate()`。
   `quit()` 对当前这种 while-loop worker 不一定能停止，`terminate()` 有概率破坏串口锁/状态。应优先依赖 worker.stop() + finished 信号退出。

建议:

- 采集期间默认不要启动 monitor worker；流帧本身已经包含磁场、频率、温度。
- GUI 的“采集中”状态应等待第一批 `batch_ready` 或 worker 明确 `stream_started` 信号后再点亮。
- stream worker 增加 raw/parse watchdog:  
  - 有 raw 但 2 秒内 0 parsed，发出“收到原始数据但无法解析”的错误/日志，并打印最近一帧。
  - 2 秒内完全无 raw，发出“设备未返回数据”的错误/日志。
- 分帧时兼容 `\r\n`, `\n`, `\r`。
- worker.finished 连接 `thread.quit`, `worker.deleteLater`, `thread.deleteLater`，避免残留线程。

### Agent C: 配置 / 文档 / 测试审查

审查范围: `app/config_io.py`, `config.json`, `tests/`, `docs/`

主要发现:

1. `ACQ_MODE_TABLE` 中 20Hz 仍保留 `start_command: FAST020>`，仅对 `1d_gauss` 特判为 `FAST2>`。
   反编译结果显示原厂 CH-1600 高速 20Hz 就是 `FAST2>`。这里的 1D 特判过度保守，应直接把 20Hz 默认命令改为 `FAST2>`。

2. 速率表缺少原厂 GUI 中的 `150Hz` 和 `250Hz` 选项。
   原厂有 `FAST150>`、`FAST250>`。当前 `dc_200plus` 用 `FAST300>` 但 `expect_fps=250`，语义混乱。

3. `config.json` 当前端口仍为 `COM1`。
   真机实测为 `COM13`。若未扫描成功，GUI 还会禁用连接按钮，导致用户不能直接手动连已知端口。

4. GUI 扫描失败时禁用连接按钮。
   对 USB 转串口、非标准响应固件和调试阶段来说过度保守。端口输入框是 editable，应该允许用户输入 `COM13` 后直接连接。

5. 文档仍有旧协议表述: CR 终止符、`FAST020>` 等。
   这会误导后续 agent 重新引入错误。

建议:

- 默认端口改为最近成功端口或 `COM13`，并允许手动连接。
- 20Hz 命令直接使用 `FAST2>`。
- 增加 `150Hz/250Hz/300Hz` 显式模式，去掉 `200plus` 这种模糊项或重命名为 `300Hz`。
- 更新 `docs/reverse_engineering_findings.md` 和 `AGENTS.md` 中协议说明: 真机命令无 CR，高速 20Hz 为 `FAST2>`。

## 为什么会出现“transmitting 但上位机无响应”

最可能路径如下:

1. GUI 调用开始采集。
2. driver 发送高速命令，设备进入 `transmitting`。
3. stream worker 启动后可能读到高速单值帧。
4. 如果解析器不接受该帧，或者 buffer 因换行处理没有切出完整帧，则没有 `batch_ready`。
5. GUI 图表和数据表只订阅 `batch_ready`，所以完全不更新。
6. 同时 monitor worker 可能在启动窗口期插入 `UNIT?>/RANGE?>` 查询，使串口返回更混杂。
7. GUI 已经把状态置为“采集中”，但没有 watchdog，所以用户看到的是“设备在 transmitting，上级程序无任何响应”。

## 最小修复顺序

建议先做这 6 个小修复，避免继续堆抽象:

1. `core/command_service.py`
   采集期间不要启动 monitor worker。先让高速数据链路单独跑通。

2. `workers/ch1600_stream_worker.py`
   增加 raw/parse watchdog 和 CR/LF 兼容分帧。这样一旦再次无图表，日志能区分“无数据”和“解析失败”。

3. `instruments/ch1600_driver.py`
   不再把 preview stream 判定为“命令不可用”；`stop_streaming()` 始终尝试 `DATAC>`。

4. `app/gui.py`
   扫描失败也允许手动输入 COM 口连接；不要把 scan 作为硬前置条件。

5. `app/config_io.py`
   20Hz 默认命令改为 `FAST2>`；补全 `FAST150>`, `FAST250>`, `FAST300>`。

6. 文档和测试
   把“命令 CR 终止”和 `FAST020>` 旧描述改掉，防止后续 agent 回滚到旧协议。

## 风险判断

这些修复不会改变原厂协议本身，主要是移除上级程序的过度保护:

- 不再假设已有流等于命令不可用。
- 不再让 monitor 在线程启动窗口期干扰 stream。
- 不再让解析失败静默吞掉。
- 不再把扫描验证失败等同于无法连接。

因此优先级应该高于新增 UI 或复杂 IPC 功能。当前阶段目标是先让真机高速流链路稳定表现为: `FAST2>/FASTxxx>` -> raw bytes -> parsed frame -> `batch_ready` -> 图表/表格刷新。
