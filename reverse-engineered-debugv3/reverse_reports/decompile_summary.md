# 反编译摘要

## 输出目录

- C# 工程：`decompiled/数据读取软件/`
- IL 输出：`decompiled/il/数据读取软件.il`
- 类型列表：`reverse_reports/types_raw.txt`
- 字符串列表：`reverse_reports/strings_ldstr.txt`
- 方法索引：`reverse_reports/method_index.txt`
- 文件清单：`reverse_reports/file_inventory.csv`

## 反编译出的主要类型

| 类型 | 作用 |
| --- | --- |
| `datapick.Form1` | 主窗体，包含串口、USB HID、绘图、表格、导出、采集控制和协议解析 |
| `datapick.SystemConfig` | `SystemConfig.xml` 读写，GBK XML，`key name/value` 结构 |
| `datapick.PointerConvert` | USB HID 数据中的小端 float/int/double 转换 |
| `datapick.Program` | WinForms 入口 |
| `datapick.tishi` | 历史数据读取提示窗口 |
| `datapick.Properties.Resources` | 资源包装类 |
| `datapick.Properties.Settings` | 设置包装类 |

## 工程性质

反编译工程显示：

- `OutputType`: `WinExe`
- `UseWindowsForms`: `True`
- `TargetFramework`: `net20`
- `AllowUnsafeBlocks`: `True`
- 依赖 `ZedGraph` 做实时曲线
- 依赖 `Microsoft.Office.Interop.Excel` 做 Excel 导出

## 主流程位置

| 功能 | 文件/位置 |
| --- | --- |
| 串口接收解析 | `decompiled/数据读取软件/datapick/Form1.cs:345` |
| 普通/高速/历史数据 UI 定时刷新 | `decompiled/数据读取软件/datapick/Form1.cs:867` |
| 开始采集 | `decompiled/数据读取软件/datapick/Form1.cs:969` |
| 停止采集 | `decompiled/数据读取软件/datapick/Form1.cs:1074` |
| 归零 | `decompiled/数据读取软件/datapick/Form1.cs:1126` |
| 型号选择与帧长度 | `decompiled/数据读取软件/datapick/Form1.cs:1470` |
| 数据类型选择 | `decompiled/数据读取软件/datapick/Form1.cs:1654` |
| 高速采样率选择 | `decompiled/数据读取软件/datapick/Form1.cs:1705` |
| 配置读写 | `decompiled/数据读取软件/datapick/SystemConfig.cs:237` |

## 当前状态

这轮只做了静态反编译和文件生成，没有运行原程序，也没有访问或写入真实串口设备。

