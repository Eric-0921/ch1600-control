# AGENTS.md — CH-1600 项目开发规范

## 项目背景

m1600 是对 CH-1600 数字高斯计上位机 DataReader2.exe 进行逆向工程后重构的 Python/PyQt5 替代方案。官方说明书对串口协议、设备型号差异、FAST 指令等关键信息描述不完整，大量细节需通过反编译源码验证。

## 逆向工程资料位置

- 反编译源码：`reverse-engineered-v2/DataReader2/`
- 验证数据：`reverse-engineered/_verification/`（SHA256、MVID、IL 哈希）
- 发现报告：`docs/reverse_engineering_findings.md`
- 改进路线图：`docs/improvement_roadmap.md`

## 开发原则

1. **任何涉及硬件通信的改动，必须与反编译源码交叉验证**
2. **官方说明书仅作为参考，DataReader2.exe 源码是事实标准**
3. **新增功能必须考虑 6 种设备模型的兼容性**
4. **配置默认值必须向后兼容（旧 config.json 缺少字段时不崩溃）**

## 常见疏漏原因与排查清单

### 原因 1：过度依赖官方说明书，忽略反编译源码

**表现**：实现的功能与 DataReader2 实际行为不一致。

**案例**：
- 说明书只写 `FAST020>`~`FAST300>`，未提及一维高斯计的 `FAST2>` 简写
- 说明书未描述不同型号的数据帧格式差异
- 说明书未说明磁通计的 Dual 模式

**排查方法**：
- [ ] 实现前搜索 `reverse-engineered-v2/DataReader2/` 中对应功能的关键词
- [ ] 对比 DataReader2 的变量命名、常量值、分支逻辑
- [ ] 对不确定的行为，在 Form1.cs 中搜索相关事件处理函数

### 原因 2：硬编码一维假设

**表现**：代码中写死 `field_mt` 单通道，未考虑 X/Y/Z/B 多通道。

**案例**：
- `review_loader.py` 的 `dtype` 固定为 4 列一维结构
- `external_ipc.py` 的 `publish_data()` 只发送 `field_mt`
- GUI 的数据表格 `setColumnCount(5)` 固定不变
- 阈值报警只判断 `field_mt`，未考虑多维模型应判断 `field_total_mt`

**排查方法**：
- [ ] 搜索代码中所有 `field_mt` 的引用，评估是否应替换为动态字段
- [ ] 检查 `CircularBuffer` 的 channels 是否为硬编码列表
- [ ] 检查 CSV/TXT 导出逻辑是否假设固定列数
- [ ] 检查图表曲线是否只绑定单条 field 曲线

### 原因 3：未处理边界格式（特殊前缀、空字符、长度阈值）

**表现**：解析函数只处理"标准格式"，遇到变体时返回 None。

**案例**：
- `parse_stream_frame()` 只识别 `#` 开头，未处理 `HSTDC:`、`HSEDC:`、`UHSDC:` 前缀
- `F_analyse()` 需要去除开头 `\0`，当前实现未处理
- 一维高斯计短帧有 `length > 40` 丢弃逻辑，二维有 `<40` 短帧/`≥40` 长帧分支

**排查方法**：
- [ ] 在 DataReader2 源码中搜索 `Substring`、`Split`、`length`、`StartsWith`
- [ ] 检查是否有 `while (str.StartsWith("\0"))` 等清洗逻辑
- [ ] 检查是否有 `if (length > 40)` 等长度分支
- [ ] 为解析函数编写异常输入测试（空字符串、乱码、截断帧）

### 原因 4：单位换算矩阵不完整

**表现**：只实现了高斯计 5 单位换算，未覆盖磁通门计（nT）和磁通计（mWb）。

**案例**：
- `_UNIT_CONVERSION` 只有 mT/G/Oe/A/m/mGs
- DataReader2 中磁通门计固定显示 nT，磁通计显示 mWb，且不受 GuassUnit 切换影响

**排查方法**：
- [ ] 在 DataReader2 源码中搜索 `Xn.Text =`、`读数(`、单位相关字符串
- [ ] 检查不同型号的 `ComboBox_unit` 是否可用
- [ ] 检查 `F_SaveToFile` 中数值是否经过单位换算

### 原因 5：配置项遗漏默认值

**表现**：旧版 `config.json` 缺少新增字段时，程序使用 None 或不合理的默认值。

**案例**：
- 新增 `device_model` 配置后，旧 config 文件中没有该字段
- 新增 `chart_colors` 后，旧 config 中没有颜色值

**排查方法**：
- [ ] 每次新增配置项，必须在 `config_io.py` 的 `DEFAULT_CONFIG` 中设置默认值
- [ ] 代码中使用 `self._cfg.get("section", {}).get("key", default_value)` 而非直接索引
- [ ] 测试时故意删除 `config.json`，验证程序是否能用默认值启动

### 原因 6：IPC/导出接口未随数据模型升级

**表现**：数据层已支持多维，但外部接口仍只传一维。

**案例**：
- `external_ipc.py` 的 payload 只有 `field_mt`
- 数据导出 Excel/TXT 只导出一维 CSV

**排查方法**：
- [ ] 检查所有"出口"（IPC、CSV、TXT、图表、表格）是否使用统一的数据结构
- [ ] 修改数据模型后，搜索所有引用旧字段名的地方
- [ ] 为多维数据编写端到端测试（采集 → 显示 → 保存 → 回看）

## 代码审查 Checklist（Review 时用）

### 通用审查项

- [ ] 新增功能是否通过 `py_compile` 语法检查
- [ ] 导航栏索引是否与 `_pages.addWidget()` 顺序一致
- [ ] 信号连接是否正确（`connect` 后是否 `disconnect` 旧连接）
- [ ] 配置读写是否使用 `deep_merge` 兼容旧文件

### 设备型号相关审查项

- [ ] 解析函数是否支持该型号的所有数据帧变体（短帧/长帧/前缀）
- [ ] 启动命令是否正确（一维用 `FAST2>` 还是 `FAST020>`）
- [ ] 单位标签是否随型号变化（mT / nT / mWb）
- [ ] CSV 表头是否与模型维度匹配
- [ ] 数据表格列数是否动态调整
- [ ] 图表曲线数量是否正确（一维 1 条 / 二维 3 条 / 三维 4 条）
- [ ] 阈值报警是否基于 `field_total_mt`（多维时）
- [ ] IPC 数据格式是否包含所有通道

### 测试要求

- [ ] 单元测试：为每种模型编写至少 3 组测试数据帧
- [ ] 集成测试：模拟数据流验证 GUI 显示
- [ ] 回归测试：一维模型保持现有行为不变
- [ ] 兼容性测试：旧版 CSV 能否被新版 loader 加载

## 子代理分工建议

| 任务类型 | 建议分配给 | 原因 |
|---------|-----------|------|
| 解析层修改 | 单个 agent | 逻辑紧密，需与源码逐行对照 |
| GUI 修改 | 单个 agent | `gui.py` 大文件，避免冲突 |
| 数据层修改 | 可与解析层并行 | 接口定义后独立实现 |
| 测试脚本 | 可与开发并行 | 用模拟数据验证 |
