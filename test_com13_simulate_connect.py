#!/usr/bin/env python3
"""模拟 connect() 的精确流程诊断 COM13"""

from __future__ import annotations

import time
import serial

print("=" * 60)
print("模拟 connect() 精确流程诊断")
print("=" * 60)

with serial.Serial("COM13", baudrate=115200, bytesize=8, parity="N", stopbits=1, timeout=0.05) as s:
    print(f"串口已打开: {s.name}, timeout={s.timeout}")
    s.reset_input_buffer()
    s.reset_output_buffer()

    # 步骤1: 静默观察 0.35s (connect() 中的逻辑)
    print("\n[步骤1] 静默观察 0.35s...")
    time.sleep(0.35)
    preview = b""
    n = s.in_waiting
    if n:
        preview = s.read(n)
    print(f"    观察期内读取到 {len(preview)} 字节: {preview!r}")

    # 步骤2: 发送 UNIT?> (connect() 中的 query_unit)
    print("\n[步骤2] 发送 UNIT?> 并模拟 _send_command 读取逻辑...")
    cmd = b"UNIT?>\r"
    print(f"    发送: {cmd!r}")
    s.write(cmd)

    # _send_command: sleep 0.15
    time.sleep(0.15)
    n = s.in_waiting
    data1 = s.read(n) if n else b""
    print(f"    0.15s 后 in_waiting={n}, 读到: {data1!r}")

    # 如果为空，再 sleep 0.25
    if not data1:
        time.sleep(0.25)
        n = s.in_waiting
        data2 = s.read(n) if n else b""
        print(f"    再 0.25s 后 in_waiting={n}, 读到: {data2!r}")
        total = data2
    else:
        total = data1

    print(f"    最终读取结果: {total!r}")
    print(f"    ASCII decode: {total.decode('ascii', errors='ignore')!r}")

    # 步骤3: 直接 read_until 对比
    print("\n[步骤3] 清空后重新发送 UNIT?> 并用 read_until(b'\\n') 读取...")
    s.reset_input_buffer()
    s.write(b"UNIT?>\r")
    time.sleep(0.3)
    raw = s.read_until(b"\n")
    print(f"    read_until 结果: {raw!r}")
    print(f"    ASCII: {raw.decode('ascii', errors='ignore')!r}")

    # 步骤4: 尝试发送 STOP 命令看看设备是否处于流模式
    print("\n[步骤4] 尝试发送 DATAC> 停止流...")
    s.reset_input_buffer()
    s.write(b"DATAC>\r")
    time.sleep(0.3)
    stop_resp = s.read_until(b"\n")
    print(f"    DATAC> 响应: {stop_resp!r}")

    # 步骤5: 停止后再发一次 UNIT?>
    print("\n[步骤5] 停止流后再次发送 UNIT?>...")
    s.reset_input_buffer()
    s.write(b"UNIT?>\r")
    time.sleep(0.3)
    raw5 = s.read_until(b"\n")
    print(f"    响应: {raw5!r}")
    print(f"    ASCII: {raw5.decode('ascii', errors='ignore')!r}")

print("\n诊断结束")
