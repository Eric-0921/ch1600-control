"""CH-1600 配置读写

遵循 odmr-control 的 config_io 模式:
- DEFAULT_CONFIG 作为硬编码回退
- load_config() 深度合并 JSON 文件
- save_config() 写入 JSON
"""

from __future__ import annotations

import json
from copy import deepcopy
from pathlib import Path
from typing import Any, Dict, Optional

# ------------------------------------------------------------------
# 默认配置
# ------------------------------------------------------------------

# 采集模式 → 图表优化映射
# mode_key: (预期FPS, 数值精度小数位, X轴窗口秒, 降采样因子)
ACQ_MODE_TABLE: Dict[str, Dict[str, Any]] = {
    "dc_normal":   {"label": "DC 常速 (~4-10 Hz)",    "expect_fps": 6,   "decimals": 4, "x_window_s": 60, "downsample": 1, "resolution": "±0.00001 mT", "accuracy": "0.05%"},
    "dc_20hz":     {"label": "DC 快速 20 Hz",          "expect_fps": 20,  "decimals": 3, "x_window_s": 20, "downsample": 1, "resolution": "±0.001 mT",   "accuracy": "0.01%"},
    "dc_50hz":     {"label": "DC 快速 50 Hz",          "expect_fps": 50,  "decimals": 3, "x_window_s": 10, "downsample": 1, "resolution": "±0.001 mT",   "accuracy": "0.015%"},
    "dc_100hz":    {"label": "DC 高速 100 Hz",         "expect_fps": 100, "decimals": 2, "x_window_s": 5,  "downsample": 2, "resolution": "±0.01 mT",    "accuracy": "0.02%"},
    "dc_200hz":    {"label": "DC 高速 200 Hz",         "expect_fps": 200, "decimals": 1, "x_window_s": 2,  "downsample": 4, "resolution": "±0.1 mT",     "accuracy": "0.15%"},
    "dc_200plus":  {"label": "DC 超高速 200+ Hz",      "expect_fps": 250, "decimals": 1, "x_window_s": 1,  "downsample": 6, "resolution": "±0.1 mT",     "accuracy": "0.15%"},
    "ac_20hz":     {"label": "AC 低频 20 Hz",          "expect_fps": 20,  "decimals": 3, "x_window_s": 10, "downsample": 1, "resolution": "±0.001 mT",   "accuracy": "0.01%"},
    "ac_50hz":     {"label": "AC 中高频 50 Hz",        "expect_fps": 50,  "decimals": 2, "x_window_s": 5,  "downsample": 1, "resolution": "±0.01 mT",    "accuracy": "0.015%"},
    "ac_100hz":    {"label": "AC 中高频 100 Hz",       "expect_fps": 100, "decimals": 2, "x_window_s": 2,  "downsample": 2, "resolution": "±0.01 mT",    "accuracy": "0.02%"},
    "ac_200hz":    {"label": "AC 中高频 200 Hz",       "expect_fps": 200, "decimals": 1, "x_window_s": 1,  "downsample": 4, "resolution": "±0.1 mT",     "accuracy": "0.15%"},
}

DEFAULT_CONFIG: Dict[str, Any] = {
    "ch1600": {
        "port": "COM1",
        "baudrate": 115200,
        "bytesize": 8,
        "parity": "N",
        "stopbits": 1,
        "timeout": 1.0,
        "stream_batch_size": 100,
        "stream_batch_interval_s": 0.030,
    },
    "acquisition": {
        "save_dir": "./experiments",
        "auto_save": False,
        "mode_key": "dc_normal",
        "zero_offset": 0.0,
    },
    "monitor": {
        "interval_ms": 500,
    },
    "ui": {
        "display_interval_ms": 30,
        "chart_history_points": 5000,
        "chart_downsample": 2,
        "window_width": 1200,
        "window_height": 800,
    },
}

# 默认配置文件路径
DEFAULT_CONFIG_FILE = Path(__file__).parent.parent / "config.json"


def _deep_merge(base: Dict[str, Any], override: Dict[str, Any]) -> Dict[str, Any]:
    """递归合并, override 覆盖 base 中的值。"""
    result = deepcopy(base)
    for key, val in override.items():
        if key in result and isinstance(result[key], dict) and isinstance(val, dict):
            result[key] = _deep_merge(result[key], val)
        else:
            result[key] = val
    return result


def load_config(path: Optional[Path] = None) -> Dict[str, Any]:
    """加载配置, 合并文件值到默认值之上。"""
    cfg = deepcopy(DEFAULT_CONFIG)
    file_path = path or DEFAULT_CONFIG_FILE

    if file_path.exists():
        try:
            with open(file_path, "r", encoding="utf-8") as f:
                file_cfg = json.load(f)
            cfg = _deep_merge(cfg, file_cfg)
        except (json.JSONDecodeError, OSError):
            pass

    return cfg


def save_config(cfg: Dict[str, Any], path: Optional[Path] = None) -> None:
    """保存配置到 JSON 文件。"""
    file_path = path or DEFAULT_CONFIG_FILE
    with open(file_path, "w", encoding="utf-8") as f:
        json.dump(cfg, f, indent=2, ensure_ascii=False)
