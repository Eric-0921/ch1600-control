# m1600 改进路线图

> 更新日期：2026-05-18
> 依据：CH-1600 官方文档 5.4 节 px-1 绘图软件截图/OCR、DataReader2 逆向工程记录、当前 m1600 代码审查。
> 定位：这是项目 todo list + agent 交接文档。状态标记含义为 `[ ]` 未做、`[~]` 已有基础实现但未成熟、`[x]` 已有测试覆盖的基础可用实现、`[✓]` 经过代码审查 + 测试 + 真机/集成验收的成熟功能。当前大部分 `[x]` 仍不是 `[✓]`，因为缺少 CH-1600 真机、Windows NamedPipe/ZMQ 客户端和大数据性能验收。

## 0. 当前结论

m1600 已经不再是早期的单通道实时曲线程序。当前代码中已经出现了 FAST 采样模式、单位显示、阈值状态、实时表格、调试页、Excel/TXT 导出、数据回看、文件轮转、ZMQ/NamedPipe、6 类设备解析等实现雏形。

P0 正确性问题已进入可验收基线：串口命令帧、GUI 初始化、IPC 可选依赖、IPC 主线程投递、标准 unittest discovery 已修复。P1 的 SQLite 实验会话数据库、统一回看数据集、节选绘图、HTML 报告、空间扫描数据模型和设备/探头能力矩阵已经有基础实现；当前主线应继续推进 P1-3/P1-4 的空间可视化与报告完善，同时持续做 P2 的隐藏协议逆向验证。

验证记录：

- `[x]` `python -m compileall app core data instruments workers tests` 通过。
- `[x]` `python -m unittest discover -v` 通过，当前 54 个测试覆盖 driver、SQLite、review loader、GUI smoke、IPC legacy command、recorder rollover、设备能力矩阵。
- `[x]` GUI 离屏实例化通过，`pyzmq` 缺失时不阻塞基础 GUI。
- `[x]` `pyzmq` 已从基础 `requirements.txt` 移到 `requirements-optional.txt`；本机 `py -3` 环境已安装 PyOpenGL/pyzmq/pywin32。
- `[x]` 本机 GUI/OpenGL smoke 通过，2D heatmap、3D Surface PNG 和 HTML 报告导出产物记录在 `experiments/runtime_validation/`。
- `[ ]` 真机/串口逻辑分析仪仍需验收 FAST 档位帧率变化和设备内部存储命令。

## 0.1 当前未完成内容总览

这些是后续 agent 最应该优先看的缺口：

| 优先级 | 主题 | 当前成熟度 | 还差什么 | 主要入口 |
| --- | --- | --- | --- | --- |
| P0/P2 | 真机串口验收 | `[ ]` 未做 | FAST 档位真实帧率、命令帧、电平/串口日志、特殊前缀样本 | `instruments/ch1600_driver.py`、`docs/CH-1600_commands_reference.md` |
| P1 | 大文件/高频性能 | `[ ]` 未做 | 300 Hz 表格虚拟化、review loader 后台 worker、数据库后台队列 | `app/gui.py`、`data/review_loader.py`、`data/sqlite_store.py` |
| P1 | 空间绘图 | `[~]` 可试用 | 已有规则/插值 heatmap、contour、2D/3D PNG 导出和报告嵌入；3D surface v1 已按可选 PyOpenGL 接入并通过本机 OpenGL smoke；3D 渲染已抽出 `app/surface_renderer.py`，为后续 PyVista/VTK 可选后端预留接口；缺真实空间扫描样本和大网格性能验收 | `data/spatial.py`、`app/gui.py`、`app/surface_renderer.py` |
| P1 | 报告/打印 | `[~]` 基础可用 | HTML 已有统计/曲线/阈值/hash，缺 PDF、打印预览、空间图嵌入、版本号/配置快照细化 | `data/reporting.py`、`app/gui.py` |
| P1/P2 | 探头/维度能力矩阵 | `[x]` 基础可用 | 已集中 6 类设备 capability 和 3 类 probe profile；缺真机探头 profile 样本、EEPROM/校准数据读取协议确认 | `data/device_capabilities.py`、`app/gui.py` |
| P1/P2 | Fluxmeter/Fluxgate 单位语义 | `[~]` 基础可用 | 内部字段仍保留 `_mt` 兼容别名，长期应迁移到 unit-aware 字段 | `instruments/ch1600_driver.py`、`data/review_loader.py` |
| P2 | 设备内部存储读取 | `[ ]` 未做 | 官方文档提到本机数据阅读，但 DataReader2 暂未找到批量读取命令 | `docs/reverse_engineering_findings.md`、`reverse-engineered-v2/DataReader2/` |
| P2 | 工业集成 | `[~]` 基础可用 | NamedPipe legacy 命令有单测，缺 Windows 客户端实测；Modbus 报警灯未实现 | `core/external_ipc.py`、`app/gui.py` |
| P2 | 解析策略/设备批次 | `[~]` 基础可用 | HST/HSE/UHS 默认缩放已实现，缺可配置批次策略和真实样本确认 | `instruments/ch1600_driver.py`、`docs/reverse_engineering_findings.md` |

## 0.2 本轮改动交接 / Changelog 摘要

> 详细历史也同步到 `CHANGELOG.md`。这里写给下一位 agent：看到这些文件有改动是正常的，不要误以为是无关脏改。

### 已改动的核心文件

- `instruments/ch1600_driver.py`
  - 统一 `_send_command()` 命令帧补齐 `>`，修复 `FAST100\r` 这类错误帧风险。
  - `start_streaming()` 发送 `DATA?>/FASTxxx>`，1D 20 Hz 使用 DataReader2 的 `FAST2>` 简写。
  - 新增 `parse_first_stream_frame()`，连接预读按 CR/LF 拆多帧后找首个合法帧。
  - 特殊前缀 `HST/HSE/UHS` 按 DataReader2 mT 分支归一：`HST/HSE raw ×0.1`、`UHS raw ×0.0001`；温度保持 raw 摄氏度。
  - 2D 长帧兼容二段和 DataReader2 源码可疑的三段 `dg2[2]` 行为。

- `core/external_ipc.py`
  - `pyzmq` 变为可选依赖，未安装不阻塞 GUI import。
  - JSON 命令保持兼容；新增 DataReader2 风格明文 `GD/ST/SG` 解析。
  - `GD` 排队启动、`SG` 按源码语义停止、`ST` 只解析回显不直接修改 GUI 配置。

- `app/gui.py`
  - 修复 GUI 初始化顺序，`device_model` 在 buffer 构建前初始化。
  - IPC start/stop 通过 Qt signal 投递到主线程，避免 IPC 线程直接创建 Qt 对象。
  - 增加 SQLite 查询、回看筛选、表格/ROI 联动、选区 CSV、HTML 报告、空间热图视图。
  - 高斯计 A/m 换算修正为 `×795.77`，因为内部统一保存 mT。
  - 空间热图已支持值通道选择、自动/手动色阶、LUT 色条、等值线叠加；3D Surface 本机 OpenGL smoke/export 已通过。
  - 设备型号、探头 profile、单位、阈值通道、实时表格列、缓冲通道改为引用统一 capability/profile。
  - 实时数据表格改为 150 ms 批量刷新，回看图表按当前 tab 懒刷新，降低高采样和 3D/heatmap 同时重算造成的 UI 压力。
- `app/surface_renderer.py`
  - 新增 pyqtgraph/OpenGL 3D surface renderer 适配层；当前仍以轻量 PyOpenGL 为默认，PyVista/VTK 作为后续 spike 的可选后端，而不是立即进入基础依赖。

- `data/sqlite_store.py`
  - 新增 SQLite 存储层：`sessions/samples/raw_frames/exports`。
  - 当前定位是本地可追溯主索引，不替代 CSV/XLSX/TXT 交换格式。
  - session 新增 `probe_profile` 元数据；样本写入前按 capability 归一。

- `data/device_capabilities.py`
  - 新增 `DeviceCapability`、`ProbeProfile`、`get_device_capability()`、`get_probe_profile()`、`normalize_sample_by_capability()`。
  - 明确测量维度、空间坐标维度、可视化维度不能混用。

- `data/review_loader.py`
  - 统一回看 dtype，兼容 m1600 CSV、DataReader2 TXT、SQLite 查询结果。
  - 支持多 schema 合并、序号/时间/source/session 筛选、选区导出。

- `data/reporting.py`
  - 新增 HTML 报告导出，包含统计、曲线 SVG、阈值判定、输入文件 SHA256、metadata。

- `data/spatial.py`
  - 新增 `build_heatmap_grid()`、`build_interpolated_heatmap_grid()` 和 `build_surface_grid()`，规则网格重复点取平均、缺失点为 NaN，插值网格用 NumPy IDW，3D surface 复用同一套空间标量场语义。

- `tests/`
  - 新增标准 discovery 入口 `tests/__init__.py`。
  - 新增/扩展 driver、IPC、GUI smoke、recorder、review loader、SQLite、device capability 测试。

### 当前本地验证命令

```powershell
& "$env:LOCALAPPDATA\Python\bin\python.exe" -m compileall app core data instruments workers tests
& "$env:LOCALAPPDATA\Python\bin\python.exe" -m unittest discover -v
git diff --check
```

当前结果：compileall 通过，54 个 unittest 通过，`git diff --check` 仅提示工作区 CRLF/LF 换行，不报 whitespace error。运行环境记录见 `docs/runtime_validation.md`。

## 0.3 成熟度说明

- `[x]` 不等于生产成熟。它只表示代码路径已经实现并有本地自动化测试。
- `[✓]` 目前几乎没有使用，因为真机验收、Windows NamedPipe 客户端、ZMQ 客户端、200/300 Hz 性能压测都还没跑。
- 下一个 agent 修改前应先跑全量 unittest；涉及 GUI 时至少跑 `tests.test_gui_smoke`；涉及串口解析时必须同步更新 `docs/reverse_engineering_findings.md`。

## 1. px-1 图片功能对照

### 1.1 我们现在没有或不足的功能

- `[x]` 查询型数据库：已新增 SQLite `sessions/samples/raw_frames/exports`，并可从回看页按 session/source 查询。
- `[ ]` 设备内部存储批量读取：官方文档提到本机数据阅读、超过 70 条进入下一组、可通过串口让计算机查询。m1600 尚未逆向出读取设备内部历史数据的命令。
- `[x]` 按序号/范围节选绘图：回看页已支持序号、相对时间、session/source 过滤，选区可导出 CSV/HTML 报告。
- `[~]` 空间二维/三维绘图：已定义 `x_mm/y_mm/z_mm` 数据字段，规则/插值 heatmap 已接入 GUI；支持 2D heatmap、3D surface 预览、PNG 导出和报告嵌入；3D 已通过本机 OpenGL smoke，并已抽出 renderer 接口方便后续 PyVista/VTK 评估；仍需真实空间扫描样本。
- `[x]` 图表报告：已新增 HTML 报告导出，PDF/打印预览仍待做。
- `[x]` 测试会话元数据：SQLite session 已保存设备型号、采样模式、单位、量程、阈值、开始/结束时间等。

### 1.2 值得学习借鉴的设计

- `[x]` 数据源明确分层：已引入 `realtime/import_csv/import_txt/device_memory` source，`device_memory` 留给 P2 逆向。
- `[x]` 数据表和曲线联动：回看表格选中范围可驱动当前选区与曲线刷新。
- `[x]` X/Y 轴手动尺度：回看页已支持手动轴范围并保存 view preset。
- `[x]` “节选数据绘图”作为一等功能：选区可作为导出/报告输入。
- `[x]` 三维图不应只是 3D 设备的 X/Y/Z 时间曲线，而应支持空间坐标 `x_mm/y_mm/z_mm` 到 `B` 的 surface/heatmap/contour；当前 3D surface v1 用 `x_mm/y_mm` 作平面坐标，值通道作高度和颜色。

### 1.3 比较落后、应替换的点

- `[x]` Access2003/Excel2003 数据库查看已过时。已采用 SQLite 作为主索引库，CSV/XLSX/TXT 作为交换格式。
- `[ ]` Office Interop 自动化不适合现代部署。继续用 `openpyxl`，后续补 PDF/HTML 报告。
- `[ ]` WinXP 风格固定窗口与老式打印按钮只作为功能参考，不作为 UI 目标。
- `[x]` 只保存处理后数值不够。采集 worker 已把 raw frame 带入数据库 raw_frames。

### 1.4 可以用更好方案实现的启发

- `[x]` 用 SQLite 建 `sessions/samples/raw_frames/exports`，每条样本带 session、model、unit、source。
- `[x]` 回看页加入 ROI/brush 选区、序号范围、时间范围、按 session 过滤、按 source 过滤。
- `[~]` 三维绘图先实现 2D heatmap/contour，再实现 3D surface；规则/插值 heatmap、contour、2D PNG 导出已有 GUI，3D surface v1 已接入可选 PyOpenGL 并通过本机 smoke/export；当前不引入 PyVista 基础依赖，但 renderer 层已预留后端切换入口，后续需做 PyVista/VTK spike 和真实空间扫描数据验收。
- `[~]` 报告导出走模板化：HTML 报告已有曲线 SVG、统计摘要和元数据，阈值结果/文件哈希待补。
- `[~]` 引入“解析策略/设备批次”概念：当前已按 DataReader2 的 mT 分支实现默认缩放，后续仍需把批次覆盖策略做成显式配置。

## 2. P0：先修正确性和可启动性

### P0-1 串口命令帧统一修复

问题：`CH1600Driver.start_streaming()` 和 `set_sample_rate()` 使用 `cmd.rstrip(">")` 后交给 `_send_command()`，实际发送会变成 `FAST100\r` 而不是官方协议的 `FAST100>\r`。同类风险还存在于 `DATAC`、`DATAS`、`ZERO`、`UNIT?`、`RANGE?`、`UPTHRES...` 等命令封装。

Todo：

- `[x]` 统一 `_send_command()` 语义：调用方可传命令主体或完整 `...>`，driver 统一补齐协议终止符。
- `[x]` fake serial 测试覆盖 `UNIT?>\r`、`DATA?>\r`、`FAST2>\r`、`FAST100>\r`、阈值设置命令。
- `[x]` 串口调试页不要再剥离 `>`，手动命令和快捷命令应显示并发送同一个协议帧。
- `[ ]` 真机或串口逻辑分析仪验收：切换采集档位后设备返回帧率变化。

### P0-2 GUI 启动依赖和 IPC 可选化

问题：`core/external_ipc.py` 顶层直接 `import zmq`。当前环境没有 `zmq`，导致 `from app.gui import GaussMeterGUI` 直接失败，即使用户没有启用 IPC。

Todo：

- `[x]` 像 pywin32 一样把 `pyzmq` 做成可选依赖，未安装时禁用 ZMQ 控件并给出清晰提示。
- `[x]` GUI 离屏启动测试：IPC disabled 且无 `zmq` 时仍可打开主窗体。
- `[x]` README/requirements 明确“基础运行依赖”和“可选 IPC 依赖”。
- `[x]` 本地验证命令增加 `python -m compileall`、driver unittest、GUI import smoke test。

### P0-3 GUI 初始化顺序修复

问题：`app/gui.py` 在初始化环形缓冲区时先读 `self._device_model`，但该属性在后面才赋值。安装 `zmq` 后，窗口初始化预计会触发 `AttributeError`。

Todo：

- `[x]` 在构建 buffer 前先读取 `device_model`。
- `[x]` 单元或 smoke test 覆盖 `GaussMeterGUI()` 离屏实例化。
- `[x]` 检查 `_display_unit`、`_UNIT_CONVERSION_BY_MODEL`、`_sample_rate_combo` 等初始化顺序。

### P0-4 IPC 线程安全

问题：`ExternalIPCService._rep_loop()` 在线程中直接执行回调，而 `CommandService.start_acquisition()` 注释明确要求在主线程创建 `QThread`。IPC 远程 start/stop 现在有跨线程创建 Qt 对象的风险。

Todo：

- `[x]` IPC 命令改为发 Qt signal 或投递到 `CommandService` 主线程入口。
- `[ ]` start/stop/get_status 的线程模型写入 docs。
- `[ ]` 用 ZMQ 客户端脚本验收远程启动、停止、状态查询。

### P0-5 测试入口整理

问题：`python -m unittest discover -v` 当前发现 0 个测试，但直接运行 `tests/test_ch1600_driver.py` 可以跑到 30 个测试。

Todo：

- `[x]` 让标准发现命令能找到测试。
- `[x]` 移除 pytest 假设，README 使用标准库 unittest 命令。
- `[~]` 增加 fake serial、review_loader、SQLite、GUI smoke、IPC legacy command 测试；recorder 已有文件轮转测试，真实 ZMQ/NamedPipe 客户端验收仍待补。

## 3. P1：补 px-1 核心工作流

### P1-1 SQLite 数据库与实验会话

- `[x]` 建立 `sessions` 表：测试点名、等级、环境温度、设备型号、采样模式、单位、量程、阈值、开始/结束时间。
- `[x]` 建立 `samples` 表：session_id、序号、时间戳、X/Y/Z/Total、频率、温度、source。
- `[x]` 建立 `raw_frames` 表：保存原始串口帧、解析器版本、解析状态。
- `[x]` CSV 仍保留为交换格式，但数据库作为查询和回看的主索引。

### P1-2 节选数据绘图

- `[x]` 回看页增加序号范围、时间范围、session/source 筛选。
- `[x]` 表格选区和图表 ROI 联动。
- `[x]` 支持把选区另存为 dataset/export/report。
- `[x]` 手动设置 X/Y 轴范围，并保存为 view preset。

### P1-3 三维和空间扫描绘图

- `[x]` 定义空间扫描数据结构：`x_mm/y_mm/z_mm/Bx/By/Bz/B_total`。
- `[x]` 先做 2D heatmap/contour，用于规则网格和插值网格：回看页已支持值通道选择、原始/插值网格、自动/手动色阶、LUT 色条、等值线叠加和 PNG 导出。
- `[x]` 3D surface v1：已新增回看页 `3D Surface` tab，复用 heatmap 通道/分辨率/色阶，采用 `pyqtgraph.opengl` + 可选 `PyOpenGL`；缺依赖时 GUI 只显示禁用提示，不影响 2D 图。
- `[x]` 3D renderer 边界：已新增 `app/surface_renderer.py`，GUI 不再直接创建/移除 `GLSurfacePlotItem`，后续 PyVista/VTK 后端可通过同类接口接入。
- `[~]` 3D surface 仍待成熟化：本机 PyOpenGL/OpenGL smoke 和 PNG 导出已通过；仍需真实空间扫描数据下的相机/高度比例、色条说明和大网格性能验收；PyVista 先做可选 spike，不进入基础依赖。
- `[x]` 明确“3D 探头时间序列”和“空间三维图”的区别：回看页用“时间曲线 / 空间热图 / 3D Surface”三个视图拆开，避免把三轴探头曲线误当空间图。

### P1-4 数据导出、打印和报告

- `[~]` Excel/TXT 已有雏形，需在 GUI 可启动后验收。
- `[~]` 新增 PDF/HTML 报告，HTML 已含曲线、统计、阈值判定、空间热图、输入文件 SHA256 和元数据；PDF 待补。
- `[ ]` 增加 Qt 打印预览或系统打印对话框。
- `[x]` 导出时记录 provenance，能追溯到 session 和 raw frame。

### P1-5 回看加载器健壮性

- `[x]` 多文件追加时先统一 dtype/schema，再 concatenate，避免 1D 文件和 2D/3D 文件混合时报错。
- `[x]` 支持 DataReader2 制表符 TXT、m1600 CSV、SQLite 查询结果三种输入。
- `[~]` 对重复时间戳的去重策略可配置：当前保留全部并追加序号，策略 UI 待补。
- `[ ]` 大文件加载移到后台 worker，避免 UI 卡死。

### P1-6 多维零点、单位和阈值策略

- `[x]` `_on_set_zero()` 在 2D/3D 模式下不能只取 `field_mt`，应按当前主通道或 Total B 设置零点。
- `[x]` 阈值判断支持 Total B、X、Y、Z 可选。DataReader2 似乎偏 X 轴，m1600 默认 Total B，但应可配置。
- `[x]` 复核 A/m 系数：m1600 内部统一保存 mT，GUI 高斯计 A/m 换算使用 `×795.77`；特殊前缀的 `79.577` 差异来自 raw 先按 0.1 mT 归一。
- `[~]` Fluxmeter/Fluxgate 的单位命名和字段名不要继续用 `_mt` 误导，SQLite/review/report 已有 `field_unit`，driver 兼容字段仍待长期迁移。

### P1-7 探头/设备能力矩阵

- `[x]` 新增统一 capability 表，覆盖 1D/2D/3D Gauss、Fluxmeter、1D/3D Fluxgate 的通道、单位、频率/温度、recorder schema、表格列、阈值通道。
- `[x]` 新增 probe profile：`standard_hall`、`weak_field`、`custom`，记录说明书中的 HCHD801F、弱磁探头和未知探头策略。
- `[x]` GUI 设备模型、探头 profile、显示单位、阈值通道、实时表格列和 buffer 通道引用 capability/profile。
- `[x]` SQLite session 保存 `probe_profile`，样本写入按 capability 归一；3D fluxgate 不再显示伪造的频率/温度列。
- `[ ]` 真机探头 profile 采样：标准探头、弱磁探头、自定义探头各采集 raw frame，确认单位、量程、温度行为。
- `[ ]` 探头 EEPROM/非易失存储器读取协议仍未知，说明书只证明“存在存储器”，不证明串口协议可读。

## 4. P2：继续挖官方文档和逆向源码的隐藏内容

### P2-1 设备内部存储读取

- `[ ]` 从官方文档“数据存储/数据阅读/串口发送计算机查询”入手，逆向 DataReader2 和原始串口行为，寻找内部历史数据批量读取命令。
- `[ ]` 如果命令存在，把 px-1 的“实时保存数据/批量读取数据”做成统一 source。
- `[ ]` 保存设备内部序号和 PC 接收序号的映射。

### P2-2 特殊前缀和批次兼容

- `[x]` 解析器已识别 `HSTDC:`、`HSEDC:`、`UHSDC:` 等前缀。
- `[x]` 明确特殊前缀 field 缩放：按 DataReader2 `GuassUnit==0` 分支，`HST/HSE` raw ×0.1，`UHS` raw ×0.0001，温度保持 raw 摄氏度。
- `[x]` 面板实时模式预读按 CR/LF 分帧并寻找首个合法帧，避免把多帧拼在一起解析。
- `[~]` 2D 长帧 `dg2[2]` 疑似 DataReader2 bug：m1600 已兼容二段和三段长帧，真实段含义仍需用真机或样本帧确认。

### P2-3 报警硬件和工业集成

- `[~]` GUI 阈值 OK/NG 已有雏形，需验收。
- `[ ]` 第二串口 Modbus RTU 报警灯/蜂鸣器作为可选模块。
- `[~]` NamedPipe 兼容 DataReader2 风格命令：已支持明文 `GD`、`ST`、`SG` 解析和单元测试；Windows 真实 NamedPipe 客户端验收待做。
- `[ ]` SendKeys 属于老方案，只作为兼容插件，不作为默认集成方式。

### P2-4 性能和大数据

- `[~]` 300 Hz 下实时表格已经改为 150 ms 批量 flush，避免采集回调逐点 `insertRow()`；成熟版本仍应迁移到 `QAbstractTableModel` 或虚拟表格。
- `[ ]` 图表降采样从简单抽点升级为 min/max bucket 或 LTTB，保留尖峰。
- `[ ]` recorder 增加周期 flush 和异常恢复，降低断电/崩溃丢数据风险。
- `[ ]` 数据库批量写入使用事务和后台队列。

## 5. 已有功能的验收清单

- `[~]` FAST 采样：命令帧已修正并覆盖测试，仍需真机/逻辑分析仪验收帧率。
- `[~]` 单位切换：GUI 高斯计 A/m 系数已复核，Fluxmeter/Fluxgate 单位字段迁移仍待做。
- `[~]` 阈值可视化：GUI 已支持 Total B/X/Y/Z 通道选择，硬件报警选项仍待补。
- `[~]` 实时表格：GUI 有实现，需 200/300 Hz 性能测试。
- `[~]` Debug 页：GUI 有实现，需修命令帧发送和 raw RX 分帧显示。
- `[~]` Excel/TXT 导出：代码有实现，需 GUI smoke 和大文件测试。
- `[~]` 数据回看：dtype 合并、选区绘图、SQLite 查询和空间 heatmap 已实现；大文件 worker 仍待做。
- `[~]` IPC：ZMQ 可选依赖、主线程投递、DataReader2 legacy 命令解析已实现，需真实 ZMQ/NamedPipe 客户端验收。
- `[~]` 6 类设备解析：driver 测试通过，特殊前缀缩放和 2D 三段长帧仍需真机/样本帧验证。

## 6. 推荐实施顺序

1. P0-1 到 P0-3：让 GUI 能启动，串口命令发对。
2. P0-4 到 P0-5：让 IPC 和测试入口可信。
3. P1-1 到 P1-2：补 px-1 最核心的数据库与节选绘图。
4. P1-5 到 P1-6：修回看和多维语义，避免数据解释错误。
5. P1-3 到 P1-4：做空间绘图和报告打印。
6. P2 系列：持续逆向隐藏协议、特殊批次和工业集成。

## 7. 参考资料

| 资料 | 路径 | 关注点 |
| --- | --- | --- |
| CH-1600 官方 OCR | `docs/CH-1600详细版-说明书.pdf_by_PaddleOCR-VL-1.5.md` | 5.4 px-1、数据存储、设备内部数据阅读、采样精度 |
| 命令参考 | `docs/CH-1600_commands_reference.md` | 串口命令、帧格式、采样率对精度影响 |
| 逆向发现 | `docs/reverse_engineering_findings.md` | FAST、6 类设备解析、特殊前缀、报警、NamedPipe |
| 本机验收 | `docs/runtime_validation.md` | Python 环境、optional 依赖、GUI/OpenGL 导出产物 |
| 当前驱动 | `instruments/ch1600_driver.py` | 命令封装、解析器、面板实时模式 |
| 当前 GUI | `app/gui.py` | px-1 功能替代实现和 P0 初始化问题 |

## 8. 2026-05-19 增量审查与非真机修复记录

> 本节为增量追加，不删除上文历史判断。范围限定：不需要连接 CH-1600 真机即可确认和修复的问题。本节中的 `[x]` 表示已有代码修复和自动化测试；涉及真实设备、真实 Windows 客户端或长时间硬件采集的项目仍保留为 `[~]` 或 `[ ]`。

### 8.1 本轮已完成修复

- `[x]` 串口扫描不再把未知串口设备列为 `CH-1600? (unverified)`；只有 `UNIT?>` 返回合法单位的端口才进入扫描结果。
- `[x]` 连接流程不再接受空响应、乱码或非 CH-1600 的 `UNIT?>` 响应；未验证设备身份时关闭串口并报错。
- `[x]` GUI 初始状态和扫描失败状态下禁用 `连接 / Connect`，避免把 `No device found` 占位文本当作串口号。
- `[x]` 软件归零改为模型感知：1D 保留 scalar offset；2D/3D 使用 X/Y/Z 分量 offset，并从修正后的分量重新计算 Total B。
- `[x]` 状态监控 worker 的最小轮询周期改为 250 ms，因为每轮有 `UNIT?` 和 `RANGE?` 两条命令，避免突破 10 cmd/s 限制。
- `[x]` CSV recorder 每次写点/写 batch 后 flush，降低进程异常退出时最后一批数据丢失风险。
- `[x]` README 增加 conda 环境启动、optional 依赖安装和离屏测试命令。

### 8.2 本轮新增/扩展的自动化验证

- `[x]` fake serial：未验证 `UNIT?>` 响应会导致 `connect()` 抛错并关闭串口。
- `[x]` fake serial：`scan_ports()` 会过滤非 CH-1600 响应。
- `[x]` GUI smoke：无验证端口时 Connect 保持禁用。
- `[x]` GUI smoke：3D 设备软件归零按分量 offset 修正并重新计算 Total B。
- `[x]` monitor worker：配置小于协议安全间隔时会被钳制到 250 ms。

### 8.3 本轮完成后的项目 review 结论

- `[x]` P0 级别的“无需真机即可确认”的身份验证、按钮状态、软件归零和命令速率问题已修复。
- `[~]` FAST 档位、特殊前缀真实缩放、2D 三段长帧含义、探头 profile 真实行为仍不能在无真机条件下升为 `[✓]`。
- `[~]` SQLite/CSV 已可追溯，但 200/300 Hz 长时间采集仍需性能压测；当前只完成 flush 和主线程批处理改进，后台数据库写入队列仍是后续工程项。
- `[~]` 空间 heatmap/3D surface 可本机 smoke，但缺真实空间扫描数据、色条单位验收和大网格性能验收。
- `[~]` ZMQ/NamedPipe 协议有单测，但真实 Windows NamedPipe 客户端、真实 ZMQ 客户端和第三方调用流程仍需集成验收。

### 8.4 增量待办事项

- `[ ]` 数据库写入从 GUI 回调迁移到后台队列，并提供队列积压/写入失败可视化状态。
- `[ ]` 大文件回看加载迁移到后台 worker，增加进度、取消和错误报告；避免百万行 CSV/TXT 阻塞 GUI。
- `[ ]` 实时表格迁移到 `QAbstractTableModel`/虚拟表格，替代高频场景下的 `QTableWidget` 行级更新。
- `[ ]` CSV recorder 增加可配置 fsync 策略：默认 flush，实验室关键记录可开启周期性 fsync。
- `[ ]` IPC 增加本机 ZMQ client smoke test；Windows 环境补 NamedPipe client smoke test。
- `[ ]` PyVista/VTK renderer 继续保持 optional spike，只有在大网格性能和交互收益明确后再作为可选后端接入。
