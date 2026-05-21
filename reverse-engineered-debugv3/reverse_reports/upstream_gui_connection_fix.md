# 上级 GUI 连接/指令失败排查记录

时间：2026-05-21

排查对象：上级目录 `D:\git-zbw\m1600`

## 现象

GUI 界面中设备连接不成功，或者连接后指令发送看起来不成功。

## 根因

### 1. 默认配置端口错误

上级 `config.json` 原来是：

```json
"port": "COM1"
```

但原厂配置和真机枚举都是：

```text
COM13    USB-SERIAL CH340 (COM13)
```

已改为：

```json
"port": "COM13"
```

### 2. Python 驱动给命令追加了 CR

原驱动 `_send_command()` 会发送：

```text
DATA?>\r
FAST2>\r
DATAC>\r
```

但真机实测：

```text
DATA?>      有响应
DATA?>\r    无响应
```

原厂 C# 反编译代码也是直接 `serialPort1.Write("DATA?>")`，没有追加 `\r`。

已改为发送裸 ASCII 命令：

```text
DATA?>
FAST2>
DATAC>
ZERO>
```

### 3. 连接验证过度依赖 UNIT?>

原驱动连接时使用 `UNIT?>` 验证设备身份，但这台 CH-1600 对 `UNIT?>` 没有返回，导致：

```text
scan_ports() -> []
connect("COM13") -> 无法验证 CH-1600 设备身份: 未识别的 UNIT?> 响应: ''
```

已增加 `DATA?>` 短采样验证兜底：

1. 发送 `DATAC>`
2. 发送 `DATA?>`
3. 等待有效数据帧
4. 发送 `DATAC>` 停止

### 4. 高速单值帧解析缺失

真机 `FAST2>` 返回：

```text
#+0000.1536>
#+0000.1571>
```

原 `1d_gauss` 解析器只接受三段普通帧：

```text
#{field}/{freq}/{temp_x10}>
```

所以高速模式即使命令发成功，GUI 也可能没有数据点。

已支持高速单值帧，频率和温度填 `0.0`。

## 已修改文件

上级目录中已修改：

- `config.json`
- `app/gui.py`
- `instruments/ch1600_driver.py`
- `tests/test_ch1600_driver.py`

## 验证结果

单元测试：

```text
D:\anaconda3\python.exe -m unittest tests.test_ch1600_driver -v
Ran 43 tests
OK
```

编译检查：

```text
D:\anaconda3\python.exe -m compileall app core data instruments workers tests
OK
```

真机回归：

```text
scan_ports()
[('COM13', 'CH-1600 [DATA?> verified]')]

connect('COM13', 115200)
CH-1600@COM13 (DATA?> verified)

start_streaming('dc_20hz', model='1d_gauss')
parsed_count 10
FRAME ('#+0000.1536>', 0.1536, 0.0, 0.0)
FRAME ('#+0000.1571>', 0.1571, 0.0, 0.0)
```

## 仍需注意

- `UNIT?>` / `RANGE?>` 在这台设备上可能仍无响应，不应作为连接必要条件。
- 监控线程只在非 streaming 时查询单位/量程；如果后续在 GUI 中启用独立查询按钮，失败提示应允许用户忽略。
- `FAST020>` 仍应避免用于这台 CH-1600，实测有效的是 `FAST2>`。

