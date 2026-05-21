#!/usr/bin/env python3
"""直接测试 COM13 连接（绕过 scan_ports）"""

from __future__ import annotations

import sys
sys.path.insert(0, r"D:\git-zbw\m1600")

from instruments.ch1600_driver import CH1600Driver

print("=" * 60)
print("直接连接 COM13 测试")
print("=" * 60)

driver = CH1600Driver()
try:
    idn = driver.connect("COM13", baudrate=115200)
    print(f"连接成功: {idn}")
    print(f"面板实时发送模式: {driver.is_panel_streaming_mode}")
except Exception as e:
    print(f"连接失败: {type(e).__name__}: {e}")
finally:
    try:
        driver.close()
        print("串口已关闭")
    except Exception:
        pass
