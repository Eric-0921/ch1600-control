#!/usr/bin/env python3
"""根据手册逐个尝试 CH-1600 指令"""

from __future__ import annotations

import sys
import time

sys.path.insert(0, r"D:\git-zbw\m1600")

import serial
from serial.tools import list_ports

COMMANDS = [
    (b"DATA?>\r", "开始实时数据流"),
    (b"DATAC>\r", "停止实时数据流"),
    (b"DATAS>\r", "单次查询数据"),
    (b"UNIT?>\r", "查询当前单位"),
    (b"RANGE?>\r", "查询当前量程"),
    (b"UPHRES?>\r", "查询上限阈值"),
    (b"LOWTHRES?>\r", "查询下限阈值"),
    (b"UNITSET>\r", "切换单位"),
    (b"RANGESET>\r", "切换量程"),
    (b"ZERO>\r", "归零"),
    (b"MAX_MIN>\r", "显示最大最小值"),
    (b"LOCK>\r", "界面锁定"),
    (b"UNLOCK>\r", "解除锁定"),
    (b"RELA>\r", "清零后恢复原显示值"),
]

BAUDRATES = [9600, 19200, 38400, 57600, 115200]
PORT = "COM13"

print("=" * 70)
print("CH-1600 手册指令逐个测试")
print("=" * 70)
print("目标端口: %s" % PORT)
print("波特率列表: %s" % BAUDRATES)
print("指令数量: %d" % len(COMMANDS))

for baud in BAUDRATES:
    print("\n" + "="*70)
    print("[波特率 %d]" % baud)
    print("="*70)

    try:
        with serial.Serial(
            PORT,
            baudrate=baud,
            bytesize=8,
            parity="N",
            stopbits=1,
            timeout=1.0,
            dsrdtr=False,
            rtscts=False,
            xonxoff=False,
        ) as s:
            s.dtr = False
            s.rts = False
            print("串口已打开: %s, timeout=%s" % (s.name, s.timeout))

            for cmd_bytes, desc in COMMANDS:
                s.reset_input_buffer()
                s.reset_output_buffer()
                time.sleep(0.05)

                s.write(cmd_bytes)
                time.sleep(0.4)

                n = s.in_waiting
                raw = s.read(n) if n else b""

                status = "[有响应]" if raw else "[无响应]"
                print("\n  %s %s" % (status, desc))
                print("       发送 (hex): %s" % cmd_bytes.hex())
                print("       发送 (ascii): %r" % cmd_bytes.decode("ascii", errors="ignore"))
                if raw:
                    print("       响应 (hex): %s" % raw.hex())
                    print("       响应 (repr): %r" % raw)
                    print("       响应 (ascii): %r" % raw.decode("ascii", errors="ignore"))

    except serial.SerialException as e:
        print("串口错误: %s" % e)
    except Exception as e:
        print("其他错误: %s: %s" % (type(e).__name__, e))

print("\n" + "=" * 70)
print("测试结束")
print("=" * 70)
