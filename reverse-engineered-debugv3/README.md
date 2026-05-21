# CH-Hall / CH-1600 原厂软件反编译工作区

本目录用于分析原厂 Windows 程序 `数据读取软件.exe`。当前目标是还原 GUI 操作、串口/USB 指令、数据帧格式，并和上级 Python 项目中的 CH-1600 驱动实现做对照。

## 重要安全提示

- 本机可能实际连接了 CH-1600 设备。
- 默认只做静态分析，不要直接运行 `Debug/数据读取软件.exe`。
- 不要随意打开 COM13 或其他真实串口。
- 如必须做动态验证，先使用虚拟串口、串口抓包或 mock 设备，并明确记录会发送的命令。
- 已有反编译产物可直接阅读，通常不需要重新反编译。

## 目录说明

```text
Debug/
  数据读取软件.exe              # 原厂主程序，.NET/MSIL WinForms
  数据读取软件.pdb              # 调试符号
  SystemConfig.xml              # 原厂配置，GBK XML
  ZedGraph.dll                  # 图表依赖
  Microsoft.Office.Interop.Excel.dll
  Interop.*.dll                 # Excel/Office 互操作依赖

decompiled/
  数据读取软件/                 # ILSpy 导出的 C# 工程
    datapick/Form1.cs           # 主窗体、GUI、串口、USB、数据解析核心
    datapick/SystemConfig.cs    # SystemConfig.xml 读写
    datapick/PointerConvert.cs  # USB 字节转 float/int/double
  il/数据读取软件.il            # IL 输出，供核对 C# 反编译结果

reverse_reports/
  dotnet_metadata.md            # .NET 元数据和依赖
  decompile_summary.md          # 反编译摘要
  protocol_findings.md          # 串口/USB 协议发现
  gui_command_map.md            # GUI 控件与指令映射
  file_inventory.csv            # 文件清单和 SHA256
  method_index.txt              # 方法索引
  strings_ldstr.txt             # IL 字符串表
  types_raw.txt                 # 类型列表
```

## 推荐阅读顺序

1. `reverse_reports/decompile_summary.md`
2. `reverse_reports/gui_command_map.md`
3. `reverse_reports/protocol_findings.md`
4. `decompiled/数据读取软件/datapick/Form1.cs`
5. `decompiled/数据读取软件/datapick/SystemConfig.cs`
6. `decompiled/数据读取软件/datapick/PointerConvert.cs`

## 已确认的关键结论

- 主程序是 `.NET WinForms / net20 / MSIL`，带 PDB，反编译质量较好。
- 窗口标题是 `CH-Hall数据采集软件`。
- 普通串口采集启动命令：`DATA?>`
- 停止命令：`DATAC>`
- 归零命令：`ZERO>`
- 高速 20 组/s 命令：`FAST2>`，不是 `FAST020>`
- 高速命令还包括：`FAST050>`, `FAST100>`, `FAST150>`, `FAST200>`, `FAST250>`, `FAST300>`
- `CH-1600` 高速启动时原程序直接发送 `FASTxxx>`。
- `CH-1500` / `CH-1500B` 高速启动时发送 `DATA?>FASTxxx>NORM>`。
- 普通数据帧按 `磁场/频率/温度` 三段解析，温度值除以 10。
- 高速数据帧只解析磁场值，频率和温度在表格中写 0。
- USB HID 条件：VendorID `1155`，ProductID `22352`，读 65 字节，写 17 字节。

## GUI 到指令的快速索引

| GUI 操作 | 串口模式 | USB 模式 |
| --- | --- | --- |
| 开始普通采集 | `DATA?>` | `senddata[1] = 17` |
| 开始高速采集 CH-1600 | `FAST2>` / `FAST050>` / ... | 原程序 USB 只保留普通读取路径 |
| 停止 | `DATAC>` | `senddata[1] = 18` |
| Zero | `ZERO>` | `senddata[1] = 32` |
| 切换数据类型/速率 | 先调用停止，可能发 `DATAC>` | 先调用停止 |
| 关闭窗口 | 若串口打开则发 `DATAC>` | 发停止并关闭 HID |

完整映射见 `reverse_reports/gui_command_map.md`。

## 后续建议任务

- 对照上级 Python 项目的 `instruments/ch1600_driver.py`，重点核对：
  - `FAST2>` vs `FAST020>`
  - `DATAC>` 停止命令
  - `FAST150>` / `FAST250>` 是否需要支持
  - CH-1600 高速启动是否应只发 `FASTxxx>`
  - 普通帧温度是否应除以 10
- 为 Python 驱动补充基于反编译帧格式的单元测试。
- 如果要动态验证，先写一个只读串口监听/虚拟串口脚本，不直接运行原厂 exe。

## 反编译工具记录

已使用 `ilspycmd 9.1.0.7988` 导出源码和 IL：

```powershell
dotnet tool run ilspycmd -- --use-varnames-from-pdb --nested-directories -p -r Debug -o decompiled/数据读取软件 Debug/数据读取软件.exe
dotnet tool run ilspycmd -- --use-varnames-from-pdb -il -r Debug -o decompiled/il Debug/数据读取软件.exe
```

如果重新执行，请确认输出路径不会覆盖人工补充的报告文件。
# Agent Handoff Warning

This subdirectory is the evidence trail for the CH-1600/DataReader2
reverse-engineering work. Future agents must not reinterpret the protocol into a
more "standard" serial form unless a new live-device trace proves it.

Current validated behavior:

- Vendor/debug behavior and COM13 live tests use raw ASCII commands, no CR/LF.
- `DATA?>` works; `DATA?>\r` did not respond on the tested device.
- 20 Hz high-speed mode uses `FAST2>`.
- Additional high-speed commands include `FAST050>`, `FAST100>`, `FAST150>`,
  `FAST200>`, `FAST250>`, `FAST300>`.
- High-speed frames may be single-value frames like `#+0000.1433>`.
- Do not let scan verification, panel/preview stream detection, or monitor
  polling block actual acquisition or `DATAC>` recovery.

If this conflicts with an older parent README/manual note, the live reverse-
engineering evidence here wins until superseded by a newer hardware log.

