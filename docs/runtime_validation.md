# 本机运行验收记录

> 日期：2026-05-18  
> 机器：当前开发/运行一体机，Windows 11  
> Python：`C:\Users\Piwei Tseng\AppData\Local\Python\pythoncore-3.14-64\python.exe`

## 环境定位

- 当前 PowerShell 中 `conda` 不在 `PATH`。
- 常见 Anaconda/Miniconda 路径未找到 `conda.exe`。
- 本轮实际使用 `py -3` 指向的 Python 3.14.4 环境。

## 已安装依赖

基础依赖已存在：

- PyQt5 5.15.11
- pyqtgraph 0.14.0
- numpy 2.4.4

本轮安装 optional 依赖：

- PyOpenGL 3.1.10
- pyzmq 27.1.0
- pywin32 311

安装命令：

```powershell
py -3 -m pip install -r requirements-optional.txt
```

## GUI / OpenGL 验收

本轮执行了本机 GUI smoke，不使用 `QT_QPA_PLATFORM=offscreen`，并生成验证产物：

- `experiments/runtime_validation/gui_window_validation.png`
- `experiments/runtime_validation/gui_heatmap_validation.png`
- `experiments/runtime_validation/gui_surface_validation.png`
- `experiments/runtime_validation/runtime_report_validation.html`
- `experiments/runtime_validation/runtime_validation.json`

结果：

- GUI 可实例化并显示主窗口。
- 6 类设备模型切换通过。
- 探头 profile 下拉可切换。
- 2D heatmap PNG 导出通过。
- 3D Surface widget 创建通过。
- 3D Surface PNG 导出通过。
- HTML 报告导出通过。

发现并修复：

- PyOpenGL 安装后，`pyqtgraph.opengl.GLSurfacePlotItem` 在 pyqtgraph 0.14.0 中渲染 2x2 surface 时，颜色数组必须按顶点扁平化为 `(N, 4)`；未扁平化会触发 `IndexError: index 2 is out of bounds`。
- 当前实现已在 GUI 3D surface 颜色生成处扁平化 vertex colors。

## 能力矩阵验收

确认 6 类设备模型的单位、表格列和阈值通道不再硬编码散落：

| 模型 | 单位 | 通道 | 频率/温度 |
| --- | --- | --- | --- |
| `1d_gauss` | mT/G/Oe/A/m/mGs | Total/X | 有 |
| `2d_gauss` | mT/G/Oe/A/m/mGs | Total/X/Y | 有 |
| `3d_gauss` | mT/G/Oe/A/m/mGs | Total/X/Y/Z | 有 |
| `fluxmeter` | mWb | Total/X | 有 |
| `1d_fluxgate` | nT | Total/X | 有 |
| `3d_fluxgate` | nT | Total/X/Y/Z | 无 |

注意：`3d_fluxgate` 的实时表格不再显示伪造的频率/温度列。

## 自动化验证

```powershell
py -3 -m compileall app core data instruments workers tests
py -3 -m unittest discover -v
git diff --check
```

本轮结果：

- compileall 通过。
- unittest discover 通过，54 个测试。
- `git diff --check` 通过，仅有既有 CRLF/LF warning。

## 仍需真机验证

- FAST 档位真实帧率。
- 2D 长帧到底是二段还是三段。
- `HST/HSE/UHS` 特殊前缀 raw 缩放。
- 标准/弱磁/自定义探头的真实帧、量程和温度行为。
- 探头 EEPROM/非易失存储器是否存在可读串口协议。
## 2026-05-21 CH-1600 COM13 Live Validation

Hardware validation was run against the actual CH-1600 connected as `COM13`
through a CH340 USB serial adapter at 115200 baud.

Results:

- `CH1600Driver.scan_ports()` returned `('COM13', 'CH-1600 [DATA?> verified]')`.
- `CH1600Driver.connect('COM13', 115200)` returned
  `CH-1600@COM13 (DATA?> verified)`.
- `FAST2>` caused the device to stream high-speed frames such as
  `#+0000.1433>`, which parsed as a single magnetic-field value.
- `DATAC>` stopped the stream path after the validation script.
- Previous direct tests showed `DATA?>` works while `DATA?>\r` does not on this
  hardware.

Agent warning: future validation or refactoring must not silently replace these
observed commands with manual-style CR-terminated commands. If another hardware
revision behaves differently, document it as a new hardware profile instead of
overwriting this one.
