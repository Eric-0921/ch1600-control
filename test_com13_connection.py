#!/usr/bin/env python3
"""单独测试 COM13 连接诊断脚本"""

from __future__ import annotations

import sys
import time

print("=" * 60)
print("CH-1600 COM13 连接诊断")
print("=" * 60)

# 1. 检查 pyserial 与 list_ports
print("\n[1] 检查 pyserial...")
try:
    import serial
    from serial.tools import list_ports
    print(f"    pyserial 版本: {serial.__version__}")
except Exception as e:
    print(f"    错误: {e}")
    sys.exit(1)

# 2. 列出所有串口
print("\n[2] 系统串口列表 (serial.tools.list_ports.comports):")
all_ports = list(list_ports.comports())
if not all_ports:
    print("    (无)")
else:
    for p in all_ports:
        print(f"    {p.device} | {p.description} | {p.hwid}")

com13_found = any(p.device.upper() == "COM13" for p in all_ports)
print(f"\n    COM13 是否出现在列表中: {'是' if com13_found else '否'}")

# 3. 直接尝试打开 COM13 并发送 UNIT?>
print("\n[3] 直接打开 COM13 并发送 UNIT?>")
BAUD = 115200
TIMEOUT = 1.0

for attempt in range(1, 4):
    print(f"\n    尝试 #{attempt} (baud={BAUD}, timeout={TIMEOUT}s)...")
    try:
        with serial.Serial("COM13", baudrate=BAUD, bytesize=8, parity="N", stopbits=1, timeout=TIMEOUT) as s:
            print(f"    串口已打开: {s.name}")
            print(f"    输入缓冲区当前字节数: {s.in_waiting}")
            s.reset_input_buffer()
            s.reset_output_buffer()
            time.sleep(0.1)

            cmd = b"UNIT\r>\r"
            print(f"    发送 (hex): {cmd.hex()}")
            s.write(cmd)
            time.sleep(0.3)

            raw = s.read_until(b"\n")
            print(f"    原始响应 (hex): {raw.hex()}")
            print(f"    原始响应 (repr): {raw!r}")
            print(f"    原始响应 (ascii): {raw.decode('ascii', errors='replace')!r}")
            print(f"    去除首尾空白后: {raw.decode('ascii', errors='ignore').strip()!r}")

            # 再试一次正确格式
            s.reset_input_buffer()
            cmd2 = b"UNIT\r>"
            print(f"\n    发送修正格式 (hex): {cmd2.hex()}")
            s.write(cmd2)
            time.sleep(0.3)
            raw2 = s.read_until(b"\n")
            print(f"    原始响应 (hex): {raw2.hex()}")
            print(f"    原始响应 (repr): {raw2!r}")
            print(f"    去除首尾空白后: {raw2.decode('ascii', errors='ignore').strip()!r}")

            # 再试一次标准格式
            s.reset_input_buffer()
            cmd3 = b"UNIT?>\r"
            print(f"\n    发送标准格式 (hex): {cmd3.hex()}")
            s.write(cmd3)
            time.sleep(0.3)
            raw3 = s.read_until(b"\n")
            print(f"    原始响应 (hex): {raw3.hex()}")
            print(f"    原始响应 (repr): {raw3!r}")
            print(f"    去除首尾空白后: {raw3.decode('ascii', errors='ignore').strip()!r}")

    except serial.SerialException as e:
        print(f"    串口错误: {e}")
    except Exception as e:
        print(f"    其他错误: {type(e).__name__}: {e}")

# 4. 使用项目自带的 driver 测试
print("\n[4] 使用 CH1600Driver 测试 scan_ports:")
try:
    from instruments.ch1600_driver import CH1600Driver
    results = CH1600Driver.scan_ports(baudrate=115200, timeout=1.0)
    print(f"    扫描结果: {results}")
except Exception as e:
    print(f"    错误: {type(e).__name__}: {e}")

print("\n" + "=" * 60)
print("诊断结束")
print("=" * 60)
