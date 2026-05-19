"""CH-1600 高斯计控制程序 — 入口点

遵循 odmr-control 架构:
- PyQt5 + Fusion style
- 6 层分层: data -> instruments -> core -> workers -> app
- Siemens 工业风 UI
- pyqtgraph 实时波形 (30ms → ~33 FPS)
"""

import argparse
import math
import sys
from pathlib import Path

from PyQt5.QtCore import QTimer
from PyQt5.QtWidgets import QApplication

# 确保项目根目录在路径中
PROJECT_ROOT = Path(__file__).parent.resolve()
if str(PROJECT_ROOT) not in sys.path:
    sys.path.insert(0, str(PROJECT_ROOT))

from app.config_io import load_config
from app.gui import GaussMeterGUI
from core.command_service import CommandService
from core.instrument_controller import InstrumentController
from data.review_loader import records_to_review_array


def build_demo_review_data():
    """生成用于验证回看曲线、热图、3D surface 和表格的空间扫描数据。"""

    records = []
    nx = 18
    ny = 14
    for y_idx in range(ny):
        for x_idx in range(nx):
            seq = y_idx * nx + x_idx + 1
            x_mm = x_idx * 2.0
            y_mm = y_idx * 2.0
            cx = (x_idx - (nx - 1) / 2.0) / max(nx, 1)
            cy = (y_idx - (ny - 1) / 2.0) / max(ny, 1)
            hill = 1.35 * math.exp(-18.0 * (cx * cx + cy * cy))
            ripple = 0.18 * math.sin(x_idx * 0.9) * math.cos(y_idx * 0.7)
            slope = 0.012 * x_idx - 0.009 * y_idx
            field_total = hill + ripple + slope + 0.08
            records.append(
                {
                    "session_id": 1600,
                    "sequence": seq,
                    "timestamp_s": (seq - 1) / 50.0,
                    "x_mm": x_mm,
                    "y_mm": y_mm,
                    "z_mm": 0.0,
                    "field_x": field_total * math.cos(x_idx * 0.08),
                    "field_y": field_total * math.sin(y_idx * 0.08),
                    "field_z": field_total * 0.25,
                    "field_total": field_total,
                    "freq_hz": 50.0 + 0.4 * math.sin(seq / 9.0),
                    "temp_c": 25.0 + 0.02 * seq,
                    "source": "demo_review",
                    "field_unit": "mT",
                }
            )
    return records_to_review_array(records)


def _parse_args(argv: list[str]) -> tuple[argparse.Namespace, list[str]]:
    parser = argparse.ArgumentParser(description="CH-1600 Digital Gauss Meter Control")
    parser.add_argument(
        "--demo-review",
        action="store_true",
        help="载入虚拟空间扫描数据并打开数据回看页，用于验证 Time/Heatmap/3D Surface/Table",
    )
    return parser.parse_known_args(argv[1:])


def _load_demo_review(window: GaussMeterGUI) -> None:
    data = build_demo_review_data()
    window._set_review_data(data, files=[])
    window._review_file_info.setText(f"虚拟数据 / Demo review data: {len(data)} pts")
    window._nav_tree.setCurrentItem(window._nav_tree.topLevelItem(3))
    window._review_main_tabs.setCurrentIndex(2)
    if getattr(window, "_review_heatmap_mode_combo", None) is not None:
        idx = window._review_heatmap_mode_combo.findData("interpolated")
        if idx >= 0:
            window._review_heatmap_mode_combo.setCurrentIndex(idx)
    if getattr(window, "_review_plot_tabs", None) is not None:
        window._review_plot_tabs.setCurrentIndex(2)
    window._update_review_plot()
    window.log(f"[GUI] 已载入虚拟空间扫描数据: {len(data)} pts")


def main() -> None:
    args, qt_args = _parse_args(sys.argv)
    app = QApplication([sys.argv[0], *qt_args])
    app.setStyle("Fusion")

    # 初始化核心层
    cfg = load_config()
    controller = InstrumentController()
    cmd_service = CommandService(controller, config=cfg)
    cmd_service.start()

    # 初始化 GUI
    window = GaussMeterGUI(cmd_service=cmd_service)
    window.show()
    if args.demo_review:
        QTimer.singleShot(0, lambda: _load_demo_review(window))

    # 退出时停止 CommandService
    app.aboutToQuit.connect(cmd_service.stop)

    sys.exit(app.exec_())


if __name__ == "__main__":
    main()
