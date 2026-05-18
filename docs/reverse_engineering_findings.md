# DataReader2 逆向工程发现报告

> 逆向对象：`origin-DataReader2/DataReader2.exe`（原厂上位机软件）
> 逆向时间：2026-05-17
> 工具：ILSpyCmd 10.0.1 + dnlib + PowerShell PE 解析器
> 分析人员：AI 编码助手

---

## 1. 项目概述

本项目对北京翠海佳诚磁电科技 CH-1600 数字高斯计的原厂配套上位机软件 **DataReader2.exe** 进行了完整的逆向工程。目标是从原厂代码中挖掘未公开的硬件指令、数据解析协议和软件设计模式，为 m1600 项目的改进提供技术输入。

### 1.1 逆向范围

| 模块 | 文件 | 分析内容 |
|------|------|----------|
| 主窗体 | `Form1.cs` (4,947 行) | UI 逻辑、设备控制、数据解析、文件操作 |
| 串口通信 | `SerialPort_Connect.cs` (275 行) | 指令集、波特率、读取线程 |
| 数据回看 | `DataReview.cs` (285 行) | 历史数据回放 |
| 命名管道 | `NamedPipe.cs` (329 行) | IPC 通信协议 |
| 配置管理 | `SystemConfig.cs` (287 行) | XML 持久化 |
| 动画/UI | `Animation.cs`, `MessageForm.cs` | UI 辅助 |

### 1.2 验证数据

原始 DLL 指纹（SHA256 + MVID）：

| 文件 | SHA256 | MVID | Runtime |
|------|--------|------|---------|
| DataReader2.exe | `949bf307b20223d3...` | `5B5990FF-6E01-43A3-8FCC-129889E512B6` | v4.0.30319 |
| ZedGraph.dll | `07ada5e13acceef1...` | `932CBBAD-436D-4A74-870E-A941DA9E1DA5` | v2.0.50727 |
| DMSkin.dll | `0276c589d4e90f02...` | `33FF8758-1EBB-4E61-BD59-F377E637C698` | v2.0.50727 |
| C1.Win.*.dll | — | — | v2.0.50727 |

Round-trip 验证：ZedGraph 反编译后重新编译，SHA256 完全不同，证明 IL→C#→IL 在字节层面不可逆。

---

## 2. 发现的串口指令集

### 2.1 CH-1600 协议指令

DataReader2 中硬编码了 **两套串口协议**：CH-1600 协议和 UDAU 协议（通过构造函数参数切换）。

#### CH-1600 标准指令

| 指令字符串 | 功能 | 在 m1600 中状态 | 文档来源 |
|-----------|------|----------------|---------|
| `DATA?>` | 启动实时数据流 | ✅ 已实现 | 说明书 |
| `DATAC>` | 停止实时数据流 | ✅ 已实现 | 说明书 |
| `DATAS>` | 单次采样查询 | ✅ 已实现 | 说明书 |
| `ZERO>` | 设备硬件归零 | ✅ 已实现 | 说明书 |
| `FAST2>` | 一维高斯计 20Hz 快速模式 | ✅ 已实现 | **未公开** |
| `FAST020>` | 20 次/秒采样 | ✅ 已实现 | **未公开** |
| `FAST050>` | 50 次/秒采样 | ✅ 已实现 | **未公开** |
| `FAST100>` | 100 次/秒采样 | ✅ 已实现 | **未公开** |
| `FAST200>` | 200 次/秒采样 | ✅ 已实现 | **未公开** |
| `FAST300>` | 300 次/秒采样 | ✅ 已实现 | **未公开** |
| `FAST` | 快速模式前缀（SerialPort_Connect 用于判断是否进入读取状态） | ✅ 间接兼容 | **未公开** |

#### UDAU 协议指令（非 CH-1600）

| 指令 | 功能 |
|------|------|
| `START>` | 启动数据流 |
| `F` | 快速模式 |
| `STOP>` | 停止数据流 |

> UDAU 是另一套设备协议，与 CH-1600 无关，本文档不做深入分析。

### 2.2 关键发现：`FASTxxx>` 系列指令

DataReader2 通过下拉框 `ComboBox_select_data` 提供 **6 档采样速率**，每种速率发送不同的 `FASTxxx>` 指令：

| 索引 | 显示名称 | 发送指令 | 适用设备 |
|------|----------|----------|----------|
| 0 | 常速 | `DATA?>` | 全部 |
| 1 | 20次/秒 | `FAST2>`（一维）/ `FAST020>`（其他） | 一维高斯计用简写 |
| 2 | 50次/秒 | `FAST050>` | 全部 |
| 3 | 100次/秒 | `FAST100>` | 全部 |
| 4 | 200次/秒 | `FAST200>` | 全部 |
| 5 | 200+次/秒 | `FAST300>` | 全部 |

**注意**：一维高斯计在 20Hz 模式下使用的是 `FAST2>`（而非 `FAST020>`），这是一个特殊简写。其他设备型号使用完整的三位数字格式。

**对 m1600 的影响**：早期 m1600 只在 GUI 上列出高速档位，未真正发送 `FASTxxx>`。当前实现已在 `CH1600Driver.start_streaming()` 中按设备型号发送硬件 FAST 指令；仍需真机或串口逻辑分析仪验收实际返回帧率。

---

## 3. 数据帧格式解析

### 3.1 标准数据帧

说明书公开的标准格式：
```
#±xxxxx.xxxx/xxx/±xxxx>
示例: #-12345.6789/050/+0234>
- field_mt: -12345.6789 mT
- freq_hz: 50 Hz
- temp_c: +23.4 °C
```

### 3.2 DataReader2 发现的扩展格式

DataReader2 的 `Form1.cs` 中实现了 **6 种设备模型**的解析，每种模型有独立的解析函数：

#### Model 1: 一维高斯计 (`OD_analyse`)
- **短帧**（<40 字符）：`值/频率/温度`
- **长帧**：以 `HSTDC:`、`HSTACL:`、`HSTACH:`、`HSEDC:`、`HSEACL:`、`HSEACH:`、`UHSDC:`、`UHSACL:`、`UHSACH:` 为前缀，后接 `/值/频率/温度`
- 温度需要 `÷10.0`

#### Model 2: 二维高斯计 (`TD_analyse`)
- 短帧：`X值/Y值`，以 `/` 分隔
- 长帧：`X/频率/温度;Y/频率/温度`，以 `;` 分隔两轴

#### Model 3: 三维高斯计 (`TTD_analyse`)
- 短帧：`X值/Y值/Z值`
- 长帧：`X/频率/温度;Y/频率/温度;Z/频率/温度`，以 `;` 分隔三轴

#### Model 4: 磁通计 (`F_analyse`)
- 去除开头的 `\0` 字符
- 从第 3 个字符开始解析：`值/频率/温度`

#### Model 5: 一维磁通门计 (`FG_analyse`)
- 格式：`值/频率/温度`
- nT 级精度

#### Model 6: 三维磁通门计 (`TFG_analyse`)
- 格式：`X值/Y值/Z值`
- **无温度频率信息**

### 3.3 特殊前缀帧

DataReader2 支持以下前缀识别（可能是不同批次/代次的 CH-1600 设备）：

| 前缀 | 含义推测 |
|------|---------|
| `HSTDC:` | 超高斯计 DC 模式 |
| `HSTACL:` | 超高斯计 ACL 模式 |
| `HSTACH:` | 超高斯计 ACH 模式 |
| `HSEDC:` | 高斯计 EDC 模式 |
| `HSEACL:` | 高斯计 EACL 模式 |
| `HSEACH:` | 高斯计 EACH 模式 |
| `UHSDC:` | 超高斯计 UHSDC 模式 |
| `UHSACL:` | 超高斯计 UHSACL 模式 |
| `UHSACH:` | 超高斯计 UHSACH 模式 |

> 当前 m1600 已识别这些前缀，并按 DataReader2 的 mT 基准缩放：`HST/HSE` 原始值 ×0.1，`UHS` 原始值 ×0.0001；温度保持 raw 摄氏度。

---

## 4. 单位换算体系

DataReader2 支持 5 种显示单位，通过 `ComboBox_unit` 切换，有完整的换算矩阵：

| 索引 | 单位 | 高斯计换算 | 磁通门计换算 |
|------|------|-----------|-------------|
| 0 | mT（毫特斯拉） | ×1 | ÷10 |
| 1 | G（高斯） | ×10 | ×1000 |
| 2 | Oe（奥斯特） | ×10 | ×1000 |
| 3 | A/m | ×79.577 或 ×795.77 | ÷1000 |
| 4 | mGs | ×10000 | ×10000 |

**温度处理**：所有设备的温度值都需要 `÷10.0`（设备端将温度放大了 10 倍发送）。

---

## 5. DataReader2 软件架构分析

### 5.1 分层架构

```
┌─────────────────────────────────────┐
│  UI 层 (Form1.cs)                   │
│  - DMSkin Metro 风格                │
│  - ZedGraph 实时绘图                │
│  - DataGridView 数据表格            │
│  - Excel 导出 (Office Interop)      │
├─────────────────────────────────────┤
│  通信层 (SerialPort_Connect.cs)     │
│  - 串口读写                         │
│  - 后台读取线程                     │
│  - AutoResetEvent 同步              │
├─────────────────────────────────────┤
│  解析层 (Form1.cs 中的 *_analyse)   │
│  - 6 种设备模型独立解析             │
│  - 单位换算                         │
│  - 阈值判断                         │
├─────────────────────────────────────┤
│  持久化层 (SystemConfig.cs)         │
│  - XML 配置文件                     │
│  - 键值对存储                       │
├─────────────────────────────────────┤
│  扩展层                             │
│  - NamedPipe IPC                    │
│  - SendKeys 键盘输出                │
│  - 报警灯串口控制                   │
└─────────────────────────────────────┘
```

### 5.2 线程模型

| 线程 | 职责 | 类型 |
|------|------|------|
| 主线程 | UI + timer_ui (100ms) + timer_display_pipe_notice | WinForms 主循环 |
| RecMethod | 串口后台读取，100ms 轮询 | `Thread` (IsBackground = true) |
| timerSTF | 文件保存定时器 | `System.Windows.Forms.Timer` |
| timer_SaveData | 按时间间隔保存 | `System.Windows.Forms.Timer` |
| NamedPipeServer | 命名管道监听 | 独立线程 |

### 5.3 数据流

```
串口 → ReadExisting() → Split('\r','\n') → DataReady 事件
  → *_analyse() → 单位换算 → ZedGraph / DataGridView / 阈值判断
  → StreamWriter (文件) / NamedPipe (IPC) / SendKeys (键盘)
```

---

## 6. 功能对比矩阵：DataReader2 vs m1600

### 6.1 指令覆盖对比

| 指令 | 功能 | DataReader2 | m1600 |
|------|------|-------------|-------|
| `DATA?>` | 启动数据流 | ✅ | ✅ |
| `DATAC>` | 停止数据流 | ✅ | ✅ |
| `DATAS>` | 单次采样 | ✅ | ✅ |
| `ZERO>` | 硬件归零 | ✅ | ✅ |
| `FAST2>` / `FAST020>` | 20Hz 采样 | ✅ | ✅ |
| `FAST050>` | 50Hz 采样 | ✅ | ✅ |
| `FAST100>` | 100Hz 采样 | ✅ | ✅ |
| `FAST200>` | 200Hz 采样 | ✅ | ✅ |
| `FAST300>` | 300Hz 采样 | ✅ | ✅ |
| `UNITSET>` | 切换单位 | ❌ | ✅ |
| `RANGESET>` | 切换量程 | ❌ | ✅ |
| `UPTHRES>` | 设置上限阈值 | ❌ | ✅ |
| `LOWTHRES>` | 设置下限阈值 | ❌ | ✅ |
| `LOCK>` / `UNLOCK>` | 面板锁定 | ❌ | ✅ |
| `MAX_MIN>` | 最大最小值 | ❌ | ✅ |
| `RELA>` | RELA 清零恢复 | ❌ | ✅ |

**结论**：DataReader2 和 m1600 是**互补**关系。DataReader2 专注于数据采集和显示，把设备参数设置留给前面板；m1600 同时覆盖设备参数控制、状态查询和硬件高速采样。

### 6.2 软件功能对比

| 功能 | DataReader2 | m1600 | 差距分析 |
|------|------------|-------|---------|
| **UI 框架** | WinForms + DMSkin + ZedGraph | PyQt5 + pyqtgraph + 西门子 CSS | 风格不同，功能相当 |
| **设备支持** | 6 种模型（1D/2D/3D 高斯计 + 磁通计 + 磁通门） | 6 种模型解析与动态 GUI | 已覆盖，需真机样本继续验证 |
| **通道数** | 最多 4 通道（CH1-CH4 + 合成 B） | X/Y/Z/Total + 频率/温度 | m1600 已统一数据模型 |
| **采样速率** | 6 档（常速 + 20/50/100/200/300 Hz） | 常速 + FAST 20/50/100/200/300 | 需真机帧率验收 |
| **实时数据表格** | DataGridView 展示每帧 | ✅ 动态表格 | 300 Hz 下需虚拟表格优化 |
| **阈值报警** | NG/OK 颜色 + 外接报警灯（Modbus RTU） | OK/NG 状态 + Total/X/Y/Z 通道选择 | 外接报警灯待做 |
| **单位显示** | 5 种单位实时切换 | 高斯计 5 单位实时切换 | Fluxmeter/Fluxgate 字段语义待长期迁移 |
| **数据保存** | 制表符分隔 + 自动新建/停止 | CSV + SQLite + raw frame + 文件轮转 | m1600 追溯性更强 |
| **Excel 导出** | Office Interop 自动化 | openpyxl `.xlsx` + TXT/CSV/HTML | m1600 更适合现代部署 |
| **NamedPipe** | ✅ 命名管道服务器 | ✅ JSON + DataReader2 风格 `GD/SG/ST` 兼容 | `ST` 仅解析不直接改 GUI |
| **SendKeys** | ✅ 模拟键盘输出 | ❌ | m1600 可添加 |
| **调试窗口** | Hex/ASCII 收发监视 | 日志页面 | m1600 可加强 |
| **数据回看** | ZedGraph 回放 + 追加 | ✅ 文件/SQLite 回看 + 选区联动 | 大文件 worker 待做 |
| **软件零点** | ❌ 仅硬件 ZERO> | ✅ GUI 层实现 | m1600 更灵活 |
| **状态查询** | ❌ | ✅ UNIT?>/RANGE?> 等 | m1600 更强 |
| **面板锁定** | ❌ | ✅ LOCK>/UNLOCK> | m1600 更强 |
| **西门子风格** | ❌ Metro 风格 | ✅ 工业级 | m1600 更专业 |

---

## 7. 值得借鉴的软件设计

### 7.1 阈值报警系统（最值得借鉴）

DataReader2 的阈值报警功能非常完整：

- **开区间/闭区间**切换（`judgeopen`）
- **ABS 绝对值**模式（`Judge_ABS`）
- **NG/OK 可视化**：NG 红色背景，OK 绿色背景
- **外接报警灯**：通过**第二个独立串口** `sp_lamp` 发送 Modbus RTU 指令控制

报警灯控制字节序列：
```csharp
// 红灯 + 蜂鸣
byte[] c_RedForLamp = {1, 5, 0, 16, 255, 0, 141, 255};
byte[] c_BeepOnForLamp = {1, 5, 0, 161, 255, 0, 221, 216};

// 绿灯 + 静音
byte[] c_GreenForLamp = {1, 5, 0, 1, 255, 0, 221, 250};
byte[] c_BeepOffForLamp = {1, 5, 0, 161, 0, 0, 156, 40};

// 关灯
byte[] c_NoneForLamp = {1, 5, 0, 4, 0, 0, 140, 11};
```

### 7.2 文件保存策略

| 特性 | DataReader2 | m1600 现状 |
|------|------------|-----------|
| 编码 | UTF-16 LE | UTF-8 BOM |
| 分隔符 | `\t`（制表符） | `,`（逗号） |
| 实时写入 | StreamWriter 逐行追加 | 逐行追加 |
| 自动新建 | ✅ 达到上限自动 `_2`, `_3` | ✅ `new_file` 策略 |
| 按时间保存 | ✅ 可设置保存间隔 | `[ ]` 待做 |
| 文件轮转策略 | 达到上限后"停止"或"自动新建" | ✅ `stop` / `new_file` |

### 7.3 命名管道 IPC

DataReader2 实现了 `NamedPipeServer`，支持：
- 外部进程通过管道发送指令控制开始/停止/切换设备
- 数据实时发送至管道（`GoPipe` 模式）
- 管道名称可配置（默认 `"SerialDataReader"`）

管道命令协议（`PipeMessageRecive`）：
```
GD\t数据点数\t采样模式索引\t是否保存\n    → 配置并启动
SG\n                                           → 停止采集（源码中发送 DATAC>）
ST\tCOM口\t设备型号\t采样模式\t单位\t是否保存\t上限\t策略\t持续读取\n → 配置 UI 状态，不直接启动
```

> 注意：`SG` 名称看起来像 start/get，但逐行审查 `PipeMessageRecive` 后确认它实际调用停止逻辑。这是说明书没有写、只在源码中能看到的兼容点。m1600 已兼容 `GD/SG/ST` 明文命令，但 `ST` 只解析回显，不直接修改当前 GUI 配置。

### 7.4 数据调试窗口

DataReader2 有专门的调试模式：
- Hex/ASCII 收发切换显示
- 可手动发送任意指令到串口
- 原始数据直接透传显示
- 右键菜单支持快捷指令发送

---

## 8. 附录：原始数据

### 8.1 IL 方法哈希抽样

ZedGraph 前 5 个方法的 IL 哈希（dnlib 提取）：

| 类型 | 方法 | Token | ILSize | ILHash_MD5 |
|------|------|-------|--------|------------|
| ZedGraph.ZedGraphControl | vScrollBar1_Scroll | 0x06000001 | 122 | c3f695ae1307ae8fe25c2dbf110334cf |
| ZedGraph.ZedGraphControl | ApplyToAllPanes | 0x06000002 | 39 | e2c971356c5206da04f8f9a4b005aa7c |
| ZedGraph.ZedGraphControl | Synchronize | 0x06000003 | 49 | c14618c155bd3ebb16063ee263cc8568 |

DataReader2 前 5 个方法的 IL 哈希：

| 类型 | 方法 | Token | ILSize | ILHash_MD5 |
|------|------|-------|--------|------------|
| DataReader2.Animation | InitTimer | 0x06000001 | 22 | 5965f1f78b38758b997174e7a7862c11 |
| DataReader2.Animation | tmrAnim_Tick | 0x06000002 | 116 | 7cb02f39463bf43d7e707c7bfff91925 |
| DataReader2.Animation | ShowControl | 0x06000003 | 123 | 9d5ae4a474892b92aee70811c603b0e1 |

### 8.2 Round-trip 验证结果

| 指标 | 原始 ZedGraph | 重新编译 | 差异 |
|------|--------------|---------|------|
| SHA256 | `07ADA5E1...` | `99538AAB...` | ❌ 完全不同 |
| MVID | `932CBBAD...` | `24800C71...` | ❌ 完全不同 |
| Runtime | v2.0.50727 | v4.0.30319 | ❌ 不同 |
| 方法数 | 2,132 | 2,136 | ❌ +4 |
| IL 指令数 | 52,215 | 52,473 | ❌ +258 |
| 文件大小 | 307,200 B | 291,328 B | ❌ -15,872 B |

> 结论：反编译→C#→重编译在 .NET 生态中**不可能达到字节级一致**，MVID 和 PE 时间戳是硬性差异。


---

## 9. 源码审查经验与隐藏细节（P2-5 阶段总结）

> 本节记录对 DataReader2 源码进行逐行审查时发现的所有“说明书没写、但源码藏了”的细节，以及我们在重写过程中踩过的坑。供后续维护者参考。

### 9.1 温度缩放：并非所有帧都 ÷10

说明书统一说“温度值为实际值乘以10”。但源码 `OD_analyse` 揭示：

| 帧类型 | 源码处理 | 说明 |
|--------|---------|------|
| 标准 `#field/freq/temp>` | `dg[2] / 10.0` | ✅ 说明书一致 |
| `HSTDC:` / `HSEDC:` 前缀 | `dg[3]` (raw) | ❌ **不 ÷10** |
| `UHSDC:` 前缀 | `dg[3]` (raw) | ❌ **不 ÷10** |

**推论**：特殊前缀帧的设备发送的温度已经是实际摄氏度，而非放大 10 倍。如果后续遇到这些前缀设备，温度解析正确；但如果有人误以为所有帧都 ÷10，会把特殊前缀帧的温度算错 10 倍。

### 9.2 特殊前缀帧的 field 值还有额外缩放

源码中 `OD_analyse` 对特殊前缀帧做了**值缩放**（根据 `GuassUnit`）：

| 前缀 | GuassUnit==0 (mT) 时的缩放 | 推论 |
|------|---------------------------|------|
| `HSTDC:` / `HSEDC:` | `tt /= 10.0` | 原始值是 0.1 mT 为单位 |
| `UHSDC:` | `tt /= 10000.0` | 原始值是 0.0001 mT 为单位 |

**当前实现**：Python 解析器现在按 DataReader2 的 `GuassUnit==0` 分支归一到 mT：`HST/HSE` raw ×0.1，`UHS` raw ×0.0001。这样后续 GUI 再按 mT→G/Oe/A/m/mGs 做统一换算。

**仍需硬件验证**：这些前缀可能来自早期批次或定制型号；如果真机样本显示 raw 已经是 mT，应通过“解析策略/设备批次”配置覆盖，而不是再次硬编码。

### 9.3 2D 长帧索引：源码疑似 bug

`TD_analyse`（二维高斯计）长帧解析：

```csharp
string[] dg2 = str.Substring(1, length - 2).Split(';');
tt3 = Convert.ToDouble(dg2[0].Split('/')[0]);
tt4 = Convert.ToDouble(dg2[2].Split('/')[0]);  // <-- dg2[2] !?
```

如果 2D 长帧格式确实是 `X/freq/temp;Y/freq/temp>`（2 段），`dg2` 长度只有 2，`dg2[2]` 会抛出 `IndexOutOfRangeException`，被 `catch` 捕获后直接 `return`，**长帧解析失败**。

**可能解释**：
1. DataReader2 源码有 bug，应为 `dg2[1]`
2. 实际 2D 协议有 3 段（`X;Y;?`），中间段为其他信息

**当前实现**：Python 同时兼容两种情况：如果只有 2 段，使用 `dg2[1]` 取 Y；如果有 3 段，优先使用 `dg2[2]` 贴近 DataReader2 源码。这样没有硬件时采用最安全策略，但仍必须用真实 2D 长帧样本确认中间段含义。

### 9.4 Fluxmeter 的 `\0` 去除：源码有无限循环风险

`F_analyse` 源码：

```csharp
while (str.StartsWith("\0"))
{
    str.TrimStart(default(char));  // 返回值被丢弃！str 永远不变
}
```

- `TrimStart` 返回新字符串，**不修改原字符串**
- 如果 `str` 以 `\0` 开头，条件永远为真 → **理论无限循环**
- 实际运行时可能被 JIT 优化或异常捕获跳过，但逻辑上是 bug

**Python 实现**：`text.lstrip("\0")` 安全且正确 ✅

### 9.5 `#` 前缀检查：磁通门计更宽松

C# 的 `FG_analyse` 和 `F_analyse` **没有显式检查 `#`**，而是直接用 `Substring(1, ...)` 去掉首字符。如果帧不以 `#` 开头，会解析出错。Python 显式检查 `startswith('#')`，更安全。

### 9.6 阈值判断：DataReader2 只用 X 轴

在 `TD_analyse` 和 `TTD_analyse` 中，阈值判断（`Judge` 逻辑）只使用 **X 轴的值**（`tt3` 或 `tt4`），而非合成 B。这意味着 2D/3D 模式下，设备是否报警只看 X 方向磁场，不看 Y/Z。

**当前实现**：m1600 默认使用 Total B，但已提供 Total B / X / Y / Z 可选阈值通道。这样既保留更合理的默认值，也可复现 DataReader2 的 X-only 行为。

### 9.7 单位换算矩阵的隐藏系数

源码中 `GuassUnit` 的换算系数：

| 索引 | 单位 | 标准帧系数 | 备注 |
|------|------|-----------|------|
| 0 | mT | ×1 | 标准探头直接是 mT |
| 1 | G | ×10 | |
| 2 | Oe | ×10 | 源码中 G 和 Oe 系数相同 |
| 3 | A/m | ×795.77 | 标准帧用 795.77；HST/HSE raw 先等效 ×0.1，所以源码中表现为 raw ×79.577 |
| 4 | mGs | ×10000 | |

**注意**：A/m 的系数在标准帧（`795.77`）和 HST/HSE 前缀 raw 值（`79.577`）中看似差 10 倍，本质是前缀 raw 值先按 0.1 mT 归一。m1600 内部统一保存 mT，因此 GUI 高斯计 A/m 换算使用 `×795.77`。

### 9.8 逐行复审差异矩阵（2026-05-18）

本轮按“先通读后精读”重新检索了 `Form1.cs`、`SerialPort_Connect.cs`、`NamedPipe.cs` 和当前 Python 实现，重点如下：

| DataReader2 位置 | 源码行为 | 说明书是否提及 | m1600 当前处理 | 状态 |
|---|---|---|---|---|
| `SerialPort_Connect.Write()` | 只要指令以 `DATA?>` 或 `FAST` 开头，就 `DiscardInBuffer()` 并进入读取线程 | 未写 `FAST` 是读取状态触发前缀 | `start_streaming()` 发 `DATA?>/FASTxxx>` 后清空缓冲并进入 worker 读取 | 已对齐 |
| `SerialPort_Connect.RecMethod()` | `ReadExisting()` 后按 `\r` 和 `\n` 拆多帧，再逐帧回调 | 未写多帧拆分细节 | stream worker 按 `\n` 分帧；连接预读新增 `parse_first_stream_frame()` 按 CR/LF 找首个合法帧 | 已补齐 |
| `OD_analyse()` | `length > 40` 直接丢弃；特殊前缀温度不 ÷10 | 未写长度上限和特殊前缀 | 标准帧严格 3 段；特殊前缀按 raw °C，field 归一到 mT | 已补齐 |
| `OD_analyse()` | `HST/HSE` mT 分支 raw ÷10；`UHS` mT 分支 raw ÷10000 | 未写 | m1600 使用 raw×0.1 / raw×0.0001 | 已补齐 |
| `TD_analyse()` | `length < 40` 短帧：`X/freq/Y`，频率不进入保存列 | 未写 | m1600 解析短帧 `X/freq/Y`，总场为 sqrt(X²+Y²) | 已对齐 |
| `TD_analyse()` | 长帧使用 `dg2[2]` 作为 Y，疑似 3 段帧或反编译/源码 bug | 未写 | m1600 同时兼容 2 段 `dg2[1]` 和 3 段 `dg2[2]`，优先 3 段以贴近源码 | 安全兼容，需真机确认 |
| `TTD_analyse()` | `length < 60` 短帧：`X/Y/Z`；长帧：三段 `X/f/t;Y/f/t;Z/f/t` | 未写长度阈值 | m1600 按相同阈值和三段结构解析 | 已对齐 |
| `F_analyse()` | `while StartsWith("\0") { TrimStart(...) }` 反编译结果丢返回值，有无限循环风险 | 未写磁通计 NUL 前缀 | m1600 使用 `lstrip("\0").lstrip("#")`，避免无限循环 | 比源码更安全 |
| `FG_analyse()` | 直接 `Substring(1, length - 2)`，没有显式 `#` 检查 | 未写 | m1600 显式要求 `#`，避免错位解析 | 比源码更安全 |
| `F_SaveToFile()` | 写 `a\tb\tc\tDateTime.Now`，无表头，UTF-16/系统默认编码路径混杂 | px-1 只展示表格 | m1600 CSV 有表头；review loader 兼容 DataReader2 TXT | 已兼容 |
| `GoPipe()` | `PipeDataCount == -1` 无限发送；倒数到 0 后自动 `DATAC>` | 未写 | m1600 IPC 不自动倒数停机；`GD` 中返回 requested_count 但不强制执行 | 记录差异 |
| `PipeMessageRecive()` | `GD` 启动；`SG` 反而发送 `DATAC>` 停止；`ST` 只配置 UI 状态 | 未写 | m1600 兼容明文 `GD/SG/ST`：`GD` 排队启动，`SG` 排队停止，`ST` 只解析回显不改 GUI | 已补兼容 |

### 9.9 说明书中的探头/维度线索

本轮把官方命令参考和 OCR 手册重新对照到 DataReader2 的 6 类模型，补充这些结论：

| 来源 | 细节 | 对 m1600 的影响 |
|---|---|---|
| 后面板接口 | CH-1600 有 15 针 D 型探头连接器 | 探头不是普通无源传感器，软件配置需要保留探头 profile 元数据 |
| `DATAS>` 说明 | 文档给出 `X/f/t;Y/f/t;Z/f/t` 三轴格式，同时注明一维模式仅返回 X 轴 | 不能把三轴格式当成所有探头固定返回；必须按 device model 能力矩阵解析 |
| 测量精度表 | 标准探头 0~±10T，弱磁探头 6 Gs | 不同探头的量程、分辨力和单位语义不同，不能只依赖 `_mt` 字段名 |
| 探头信息 | 标配 Model-HCHD801F 超高精度数字化超薄横向霍尔探头 | 默认 profile 设为 `standard_hall` |
| 探头信息 | 探头内含非易失存储器，存储校准数据；同型号探头可替换 | 先记录为 probe profile 的 `calibration_source=probe_nvm`，不假设已有串口命令可读 EEPROM |
| 连接注意 | 连接前必须关闭设备电源，上电后连接可能导致存储器失效 | 真机测试流程必须写入操作规程，避免热插拔探头 |

**当前实现**：新增 `data.device_capabilities`，把“测量维度 / 空间坐标维度 / 可视化维度”拆开。3D 探头只代表 X/Y/Z 测量通道，不自动等同于空间 3D surface；空间图仍要求 `x_mm/y_mm` 坐标。

### 9.10 本轮新增假设与硬件验证清单

- **2D 长帧三段假设**：如果真机发送 `X/f/t;Y/f/t>`，m1600 用第二段 Y；如果发送 `X/f/t;meta/f/t;Y/f/t>`，m1600 用第三段 Y。需要采集真实 2D 长帧样本确认中间段含义。
- **特殊前缀缩放假设**：当前按 DataReader2 `GuassUnit==0` 归一到 mT。需要真实 `HST/HSE/UHS` 帧确认 raw 单位。
- **DataReader2 管道语义**：`SG` 名字像 start，但源码实际 stop。m1600 保持源码兼容，并在返回 JSON 中标记 `legacy_command`。
- **保存/管道计数差异**：DataReader2 的 `PipeDataCount` 会在计数耗尽后自动 `DATAC>`；m1600 暂不让 IPC 层擅自停机，避免后台线程改变 Qt 采集生命周期。

### 9.11 审查方法论：如何高效全面审查逆向源码

1. **先通读后精读**：先用 Grep 定位关键函数，再逐行阅读。不要一开始就陷入细节。
2. **做差异矩阵**：把 C# 和 Python 的实现并列成表格，一眼看出哪里不同。
3. **关注边界条件**：`length < 40` vs `length > 40`、数组越界、空字符串、异常捕获。
4. **质疑反编译质量**：ILSpy 反编译的代码可能有逻辑错误（如 `TrimStart` 不赋值），需要结合上下文判断。
5. **对照硬件验证**：没有硬件时，优先保证“最安全”的实现（如显式检查 `#`、用 `lstrip` 而不是 while 循环）。
6. **记录所有假设**：对于无法验证的行为（如 2D 长帧到底有几段），在代码注释和文档中明确标注。

---

> 最后更新：2026-05-18 | 审查范围：Form1.cs OD_analyse / TD_analyse / TTD_analyse / F_analyse / FG_analyse / TFG_analyse / PipeMessageRecive / GoPipe，SerialPort_Connect.cs RecMethod / Write；官方命令参考探头接口 / DATAS / 探头信息
