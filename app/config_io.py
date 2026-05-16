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
    "monitor": {
        "interval_ms": 500,
    },
    "acquisition": {
        "save_dir": "./experiments",
        "auto_save": False,
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
