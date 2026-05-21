#!/usr/bin/env python3
"""COM13 连接诊断 v2 - 测试不同 timeout 和重新打开的影响"""

from __future__ import annotations

import time
import serial

print("=" * 60)
print("COM13 连接诊断 v2")
print("=" * 60)

# 测试1: timeout=1.0, 每次重新打开串口 (和第一次诊断一样)
print("\n[测试1] timeout=1.0, 每次重新打开串口")
for i in range(2):
    with serial.Serial("COM13", baudrate=115200, bytesize=8, parity="N", stopbits=1, timeout=1.0) as s:
        s.reset_input_buffer()
        s.write(b"UNIT?>\r")
        time.sleep(0.3)
        raw = s.read_until(b"\n")
        print(f"  尝试{i+1}: {raw!r}")

# 测试2: timeout=0.05, 每次重新打开串口 (模拟 connect 但重新打开)
print("\n[测试2] timeout=0.05, 每次重新打开串口")
for i in range(2):
    with serial.Serial("COM13", baudrate=115200, bytesize=8, parity="N", stopbits=1, timeout=0.05) as s:
        s.reset_input_buffer()
        s.write(b"UNIT?>\r")
        time.sleep(0.3)
        raw = s.read_until(b"\n")
        print(f"  尝试{i+1}: {raw!r}")

# 测试3: timeout=0.05, 只打开一次, 但发送后sleep不同时间
print("\n[测试3] timeout=0.05, 单次打开, 发送后sleep不同时间")
with serial.Serial("COM13", baudrate=115200, bytesize=8, parity="N", stopbits=1, timeout=0.05) as s:
    for sleep_sec in [0.05, 0.1, 0.2, 0.3, 0.5, 1.0]:
        s.reset_input_buffer()
        s.write(b"UNIT?>\r")
        time.sleep(sleep_sec)
        raw = s.read_until(b"\n")
        print(f"  sleep={sleep_sec}s: {raw!r}")

# 测试4: 用 in_waiting + read 的方式 (模拟 _read_available)
print("\n[测试4] timeout=0.05, 用 in_waiting + read(n) 的方式")
with serial.Serial("COM13", baudrate=115200, bytesize=8, parity="N", stopbits=1, timeout=0.05) as s:
    s.reset_input_buffer()
    s.write(b"UNIT?>\r")
    time.sleep(0.3)
    n = s.in_waiting
    raw = s.read(n) if n else b""
    print(f"  in_waiting={n}, read={raw!r}")

# 测试5: 先静默观察, 再发送 (完整模拟 connect)
print("\n[测试5] 完整模拟 connect() 流程")
with serial.Serial("COM13", baudrate=115200, bytesize=8, parity="N", stopbits=1, timeout=0.05) as s:
    s.reset_input_buffer()
    s.reset_output_buffer()
    time.sleep(0.35)
    preview_n = s.in_waiting
    preview = s.read(preview_n) if preview_n else b""
    print(f"  静默0.35s后: in_waiting={preview_n}, data={preview!r}")

    s.write(b"UNIT?>\r")
    time.sleep(0.15)
    n1 = s.in_waiting
    d1 = s.read(n1) if n1 else b""
    print(f"  发送后0.15s: in_waiting={n1}, data={d1!r}")

    if not d1:
        time.sleep(0.25)
        n2 = s.in_waiting
        d2 = s.read(n2) if n2 else b""
        print(f"  再0.25s后: in_waiting={n2}, data={d2!r}")

print("\n诊断结束")
