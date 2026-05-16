"""CH-1600 命令类型定义

遵循 odmr-control 的 Command 模式:
- CommandType 枚举: 所有可用命令
- Command dataclass: frozen 命令对象, 携带参数和请求 ID
"""

from __future__ import annotations

import uuid
from dataclasses import dataclass, field
from enum import Enum, auto
from typing import Any, Dict


class CommandType(Enum):
    # 连接管理
    CH1600_CONNECT = auto()
    CH1600_DISCONNECT = auto()
    CH1600_SCAN_PORTS = auto()

    # 数据流控制
    CH1600_START_STREAM = auto()
    CH1600_STOP_STREAM = auto()
    CH1600_QUERY_DATA_ONCE = auto()

    # 查询命令
    CH1600_QUERY_UNIT = auto()
    CH1600_QUERY_RANGE = auto()
    CH1600_QUERY_UP_THRESH = auto()
    CH1600_QUERY_LOW_THRESH = auto()
    CH1600_QUERY_STATE = auto()

    # 控制命令
    CH1600_SET_UNIT_CYCLE = auto()
    CH1600_SET_RANGE_CYCLE = auto()
    CH1600_ZERO = auto()
    CH1600_MAX_MIN = auto()
    CH1600_LOCK = auto()
    CH1600_UNLOCK = auto()
    CH1600_RELA = auto()

    # 阈值设置
    CH1600_SET_UP_THRESH = auto()
    CH1600_SET_LOW_THRESH = auto()

    # 数据记录
    ACQ_START_RECORDING = auto()
    ACQ_STOP_RECORDING = auto()

    # 系统
    SYS_EMERGENCY_STOP = auto()


@dataclass(frozen=True)
class Command:
    """不可变命令对象。"""

    cmd_type: CommandType
    params: Dict[str, Any] = field(default_factory=dict)
    request_id: str = field(default_factory=lambda: str(uuid.uuid4())[:8])
    source: str = "gui"
