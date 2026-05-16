"""CH-1600 高斯计控制程序 — 入口点

遵循 odmr-control 架构:
- PyQt5 + Fusion style
- 6 层分层: data -> instruments -> core -> workers -> app
- Siemens 工业风 UI
- pyqtgraph 实时波形 (30ms → ~33 FPS)
"""

import sys
from pathlib import Path

from PyQt5.QtWidgets import QApplication

# 确保项目根目录在路径中
PROJECT_ROOT = Path(__file__).parent.resolve()
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from app.config_io import load_config
from app.gui import GaussMeterGUI
from core.command_service import CommandService
from core.instrument_controller import InstrumentController


def main() -> None:
    app = QApplication(sys.argv)
    app.setStyle("Fusion")

    # 初始化核心层
    cfg = load_config()
    controller = InstrumentController()
    cmd_service = CommandService(controller, config=cfg)
    cmd_service.start()

    # 初始化 GUI
    window = GaussMeterGUI(cmd_service=cmd_service)
    window.show()

    # 退出时停止 CommandService
    app.aboutToQuit.connect(cmd_service.stop)

    sys.exit(app.exec_())


if __name__ == "__main__":
    main()
