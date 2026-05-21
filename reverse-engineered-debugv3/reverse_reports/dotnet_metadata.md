# .NET 元数据分析

分析对象：`Debug/数据读取软件.exe`

## 基本结论

- 主程序是托管 `.NET/MSIL` 程序，不是原生 PE 壳程序。
- 程序类型是 Windows Forms 桌面程序，反编译工程目标为 `net20`。
- 程序带有 `Debug/数据读取软件.pdb`，ILSpy 已使用 PDB 变量名辅助反编译。
- 主命名空间为 `datapick`。

## 程序集

| 文件 | 程序集名 | 版本 | 架构 |
| --- | --- | --- | --- |
| `数据读取软件.exe` | `数据读取软件` | `1.0.0.0` | `MSIL` |
| `ZedGraph.dll` | `ZedGraph` | `5.1.4.31904` | `MSIL` |
| `Microsoft.Office.Interop.Excel.dll` | `Microsoft.Office.Interop.Excel` | `10.0.4504.0` | `None` |
| `Interop.Microsoft.Office.Core.dll` | `Interop.Microsoft.Office.Core` | `2.3.0.0` | `MSIL` |
| `Interop.Excel.dll` | `Interop.Excel` | `1.5.0.0` | `MSIL` |

## 引用依赖

主程序引用：

- `mscorlib, Version=2.0.0.0`
- `System.Windows.Forms, Version=2.0.0.0`
- `System, Version=2.0.0.0`
- `System.Xml, Version=2.0.0.0`
- `System.Drawing, Version=2.0.0.0`
- `ZedGraph, Version=5.1.4.31904`
- `Microsoft.Office.Interop.Excel, Version=10.0.4504.0`

## 嵌入资源

- `datapick.Form1.resources`
- `datapick.Properties.Resources.resources`
- `datapick.tishi.resources`

## 反编译工具

- `ilspycmd 9.1.0.7988`
- `ICSharpCode.Decompiler 9.1.0.7988`
- 临时工具目录：`%TEMP%/codex-ilspy-tools`

