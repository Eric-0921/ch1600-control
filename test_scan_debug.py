#!/usr/bin/env python3
"""扫描调试脚本 - 输出每一步详细信息"""

from __future__ import annotations

import sys
import time

sys.path.insert(0, r"D:\git-zbw\m1600")

import serial
from serial.tools import list_ports
from instruments.ch1600_driver import CH1600Driver

print("=" * 70)
print("CH-1600 扫描调试脚本")
print("=" * 70)

print("\n[1] 系统串口列表:")
for p in list_ports.comports():
    print(f"    {p.device} | {p.description} | {p.hwid}")

print("\n[2] 使用 CH1600Driver.scan_ports() 扫描:")
results = CH1600Driver.scan_ports(baudrate=115200, timeout=1.0)
print(f"    结果: {results}")

print("\n[3] 逐个端口详细诊断:")
for p in list_ports.comports():
    port = p.device
    print(f"\n    >>> 测试 {port} ...")
    try:
        s = serial.Serial(
            port=port,
            baudrate=115200,
            bytesize=8,
            parity="N",
            stopbits=1,
            timeout=1.0,
            dsrdtr=False,
            rtscts=False,
            xonxoff=False,
        )
        print(f"        打开成功, timeout={s.timeout}")

        # 拉低 DTR/RTS
        s.dtr = False
        s.rts = False
        print(f"        DTR={s.dtr}, RTS={s.rts}")

        s.reset_input_buffer()
        s.reset_output_buffer()
        print(f"        缓冲区已清空")

        # 静默观察
        print(f"        静默观察 0.4s...")
        time.sleep(0.4)
        n = s.in_waiting
        preview = s.read(n) if n else b""
        print(f"        观察期读到 {len(preview)} 字节: {preview!r}")
        if preview:
            frame = CH1600Driver.parse_first_stream_frame(preview)
            print(f"        是否有效数据帧: {frame is not None}")

        # 发送 UNIT?>
        print(f"        发送 UNIT?> ...")
        s.write(b"UNIT?>\r")
        time.sleep(0.3)
        raw = s.read_until(b"\n")
        print(f"        响应: {raw!r}")
        print(f"        ASCII: {raw.decode('ascii', errors='ignore')!r}")

        s.close()
        print(f"        关闭串口")
    except Exception as e:
        print(f"        错误: {type(e).__name__}: {e}")

print("\n" + "=" * 70)
print("调试结束")
print("=" * 70)
