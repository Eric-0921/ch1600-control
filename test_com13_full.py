#!/usr/bin/env python3
"""COM13 全面诊断 - 测试不同波特率、DTR/RTS"""

from __future__ import annotations

import time
import serial

print("=" * 60)
print("COM13 全面诊断")
print("=" * 60)

baudrates = [9600, 19200, 38400, 57600, 115200]

for baud in baudrates:
    print(f"\n[波特率 {baud}] 测试...")
    try:
        with serial.Serial(
            "COM13",
            baudrate=baud,
            bytesize=8,
            parity="N",
            stopbits=1,
            timeout=1.0,
        ) as s:
            s.reset_input_buffer()
            s.write(b"UNIT?>\r")
            time.sleep(0.3)
            raw = s.read_until(b"\n")
            print(f"  响应: {raw!r}")
            if raw:
                print(f"  ASCII: {raw.decode('ascii', errors='ignore')!r}")
                break
    except Exception as e:
        print(f"  错误: {e}")

print("\n" + "=" * 60)
print("诊断结束")
print("=" * 60)
