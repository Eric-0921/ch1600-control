# GUI 界面与指令映射

分析来源：`decompiled/数据读取软件/datapick/Form1.cs`。本报告只基于静态反编译，没有启动原程序，也没有访问真实设备。

## 窗口概览

- 窗口标题：`CH-Hall数据采集软件`
- 固定窗口尺寸：`800 x 600`
- 左侧：`设置`
  - `通讯设置`
  - `命令`
  - 图形刷新/保存按钮
  - 数据清空/导出按钮
  - `绝对值` 复选框
- 右侧顶部：
  - `磁场值(mT)` / `磁通量(...)`
  - `频率(Hz)`
  - `温度(℃)`
- 右侧下方：
  - 上半区：`ZedGraph` 实时曲线
  - 下半区：`DataGridView` 数据表格

初始化表格列：

| 列名 | 标题 |
| --- | --- |
| `no` | `序号` |
| `T` | `磁场值(mT)`，磁通模式下会改为磁通量 |
| `H` | `频率(Hz)` |
| `C` | `温度(℃)` |
| `TIME` | `时间` |

## 通讯设置区

| GUI 控件 | 可选项 | 事件函数 | 对设备指令 |
| --- | --- | --- | --- |
| `仪器型号` | `CH-1300`, `CH-1500`, `CH-1500B`, `CH-1600`, `CH-1800`, `CH-260`, `CH-290`, 手动型号 | `comboBoxModel_SelectedIndexChanged` | 切换时本身不发新命令，但会触发数据来源切换，可能先发 `DATAC>` 后重开串口 |
| `通讯方式` | `串口`, `USB` | `comboBoxfangshi_SelectedIndexChanged` | 开头调用 `buttonSTOP_Click`；因为事件触发时选中值已经改变，是否发 `DATAC>` 取决于当前选中模式和串口打开状态 |
| `串口选择` | 初始 `COM1` ~ `COM21`，点击后刷新为 `SerialPort.GetPortNames()` | `comboBoxCOM_Click`, `comboBoxCOM_SelectedIndexChanged` | 不发采集命令；会关闭旧串口并打开新串口 |
| `波特率` | `110`, `300`, `600`, `1200`, `2400`, `4800`, `9600`, `14400`, `19200`, `38400`, `56000`, `57600`, `115200` | `comboBoxBAUDE_SelectedIndexChanged` | 不发采集命令；会关闭串口、设置波特率、重新打开 |
| `数据类型` | `普通数据`, `高速数据`, `历史数据` | `comboBoxDataType_SelectedIndexChanged` | 开头调用 `buttonSTOP_Click`，串口模式下如果端口已打开会发 `DATAC>` |

型号切换副作用：

| 型号 | 数据来源 | 普通帧长度 | 高速帧基长 | 数据类型 |
| --- | --- | ---: | ---: | --- |
| `CH-1300` | 高斯计 | 20 | 13 默认值 | 普通/历史 |
| `CH-1500` | 高斯计 | 21 | 11 | 普通/高速/历史 |
| `CH-1500B` | 高斯计(弱磁) | 23 默认值 | 13 默认值 | 普通/高速/历史 |
| `CH-1600` | 高斯计 | 23 默认值 | 13 默认值 | 普通/高速/历史，允许 USB |
| `CH-1800` | 高斯计 | 24 | 14 | 普通/高速/历史，允许 USB |
| `CH-260` / `CH-290` | 磁通计 | 24 | 14 | 普通/历史 |

## 命令区

| GUI 控件 | 可选项/文本 | 事件函数 | 串口指令 | USB 指令 |
| --- | --- | --- | --- | --- |
| `数据单位` | 高斯计：`mT`, `G`, `A/m`, `Oe` | `comboBoxdanwei_SelectedIndexChanged` | 无 | 无 |
| `普通采集 周期(s)` | `默认`, `1`, `2`, ..., `30` | `comboBoxT_SelectedIndexChanged` | 无 | 无 |
| `高速采集 速率` | `20组/s`, `50组/s`, `100组/s`, `150组/s`, `200组/s`, `250组/s`, `300组/s` | `comboBoxSpeed_SelectedIndexChanged` | 切换前会调用停止，可能发 `DATAC>` | 切换前会调用停止 |
| `开始` | 按钮 | `buttonSTART_Click` | 普通：`DATA?>`；高速：见下表 | `senddata[1] = 17` 后 `WriteFile(..., 17 bytes)` |
| `停止` | 按钮 | `buttonSTOP_Click` | `DATAC>` | `senddata[1] = 18` 后 `WriteFile(..., 17 bytes)` |
| `Zero` | 按钮 | `buttonZERO_Click` | `ZERO>` | `senddata[1] = 32` 后 `WriteFile(..., 17 bytes)` |

高速速率映射：

| GUI 速率 | 串口命令 | `HighSpeedNO` |
| --- | --- | ---: |
| `20组/s` | `FAST2>` | 20 |
| `50组/s` | `FAST050>` | 50 |
| `100组/s` | `FAST100>` | 100 |
| `150组/s` | `FAST150>` | 150 |
| `200组/s` | `FAST200>` | 200 |
| `250组/s` | `FAST250>` | 250 |
| `300组/s` | `FAST300>` | 300 |

高速开始命令差异：

| 型号 | 点击 `开始` 时发出的高速启动指令 |
| --- | --- |
| `CH-1500` / `CH-1500B` | `DATA?>` + 速率命令 + `NORM>`，如 `DATA?>FAST050>NORM>` |
| 其他高速型号，例如 `CH-1600` / `CH-1800` | 只发速率命令，如 `FAST2>`、`FAST100>` |

历史数据模式下，界面先提示用户在仪器端执行 UART `Transmit Saved`；代码设置 `ReceivedBytesThreshold = 20000`，之后点击 `开始` 仍会走非高速分支，对非手动型号发送 `DATA?>`。

`buttonSTART_Click` 里保留了一段 `DATAC>` + `TYPE>` 查询逻辑，但函数开头立即把 `FlagEnquire` 设为 `4`，所以按当前反编译结果，这段 `TYPE>` 查询分支不会从 `开始` 按钮正常进入。

## 图形/数据按钮

| GUI 控件 | 位置/文本 | 事件函数 | 功能 | 对设备指令 |
| --- | --- | --- | --- | --- |
| 左侧图形 `刷新` | `button1` | `button1_Click` | 清空曲线点并刷新图形 | 无 |
| 左侧图形 `保存` | `button2` | `button2_Click` | 调用 `zedTIME.SaveAs()` 保存图形 | 无 |
| 左侧数据 `清空` | `buttonLISTCLEAR` | `buttonLISTCLEAR_Click` | 清空表格，序号重置为 1 | 无 |
| 左侧数据 `导出` | `buttonEXCEL` | `buttonEXCEL_Click` | 先执行 `Rows.Add(11, 11, 11)`，再导出为 `.xls` 文本表 | 无 |
| `绝对值` | `checkBox1` | 无直接事件 | 导出时若勾选，第 2 列取绝对值 | 无 |

注意：`buttonEXCEL_Click` 里会先往表格追加一行 `(11, 11, 11)`，这看起来像原程序遗留调试代码，导出时会污染数据。

## 隐藏控件

| 控件 | 状态 | 作用 |
| --- | --- | --- |
| `数据来源` / `comboBoxSource` | `Visible = false` | 内部区分 `磁通计`, `高斯计`, `高斯计(弱磁)` |
| `radioButton1` 数据 | `Visible = false` | 原设计用于显示数据表模式 |
| `radioButton2` 图形 | `Visible = false` | 原设计用于显示图形模式 |

## 数据接收和显示

串口接收入口：`serialPort1_DataReceived`

| 数据类型 | 读取方式 | 帧格式逻辑 | 显示行为 |
| --- | --- | --- | --- |
| 普通数据 | 一次读 `ReadLength` 字符 | `#...>\n`，内容按 `/` 切为磁场/频率/温度 | 表格追加一行，曲线追加一点 |
| 高速数据 | 一次读 `HighSpeedNO * HighSpeedBase` 字符 | 按 `\n` 切行，每行去 `#` 和 `>`，只取数值 | 表格批量追加，频率/温度写 0 |
| 历史数据 | `ReadExisting()` 后按文本拆分 | 解析 500 条历史记录 | 表格批量追加 |

定时器：

| 定时器 | 作用 |
| --- | --- |
| `timerTIME` | 刷新数值框、表格、曲线 |
| `timer1` | 设置 `boolDisplayData = true`，控制普通模式显示周期 |
| `timerRecieve` | USB 模式下启动读取线程 |
| `timerUSBread` | USB 模式下解析 65 字节报告 |
| `timerType` | `TYPE>` 查询后，根据 `WEAK\n` / `NORM\n` 切换数据来源 |

## USB HID

USB 枚举条件：

| 字段 | 值 |
| --- | --- |
| VendorID | `1155` |
| ProductID | `22352` |
| Read report | 65 bytes |
| Write report | 17 bytes |

USB 解析：

| 数据 | 字节位置 |
| --- | --- |
| 磁场 float，小端 | `m_rd_data[4..7]` |
| 频率 | `m_rd_data[9] + m_rd_data[10] * 256` |
| 温度 x10 | `m_rd_data[12] + m_rd_data[13] * 256` |

## 配置保存

关闭窗口时调用 `WriteSystemConfig()` 保存：

- `MODEL`
- `COMWAY`
- `COMMSET`
- `BADURATE`
- `DATATYPE`
- `SPEED`

随后：

- 串口模式：如果串口打开，发送 `DATAC>` 后关闭。
- USB 模式：发送 `senddata[1] = 18`，再关闭 HID handle。
