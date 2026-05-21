"""CH-1600 高斯计控制 GUI

遵循 odmr-control 的 UI 架构:
- QMainWindow + Siemens 工业风 CSS
- QSplitter: 左侧 QTreeWidget 导航 + 右侧 QStackedWidget 页面
- pyqtgraph 实时磁场波形 (30ms QTimer → ~33 FPS)
- 三级信号广播 (CommandService → GUI)
- 底部 QFrame 全局状态栏
"""

from __future__ import annotations

import datetime
import hashlib
import math
import time
import csv
from pathlib import Path
from typing import Any, Dict, List, Optional, Tuple

from PyQt5.QtCore import QAbstractTableModel, QModelIndex, QRectF, Qt, QTimer, pyqtSignal
from PyQt5.QtGui import QColor, QDoubleValidator
from PyQt5.QtWidgets import (
    QApplication, QAbstractItemView, QCheckBox, QColorDialog, QComboBox, QFileDialog, QFrame,
    QGridLayout, QGroupBox, QHBoxLayout, QHeaderView, QLabel, QLineEdit, QMainWindow,
    QMenuBar, QMessageBox, QPushButton, QScrollArea, QSizePolicy, QSplitter,
    QSlider, QSpinBox, QStackedWidget, QStatusBar, QTabWidget, QTableView, QTableWidget, QTableWidgetItem,
    QTextEdit, QTreeWidget, QTreeWidgetItem,
    QVBoxLayout, QWidget,
)

import numpy as np
from data.circular_buffer import CircularBuffer
from data.device_capabilities import (
    get_device_capability, get_probe_profile, iter_device_capabilities,
    iter_probe_profiles, normalize_sample_by_capability,
)
from data.measurement_analysis import (
    analyze_spectrum, analyze_threshold_events, analyze_time_series,
    analyze_vector_components,
)
from data.recorder import CH1600Recorder
from data.reporting import evaluate_threshold, export_html_report
from data.review_loader import (
    export_review_selection_csv, filter_review_data, get_review_summary,
    load_review_files, merge_review_arrays, primary_field_name,
)
from data.spatial import build_heatmap_grid, build_interpolated_heatmap_grid, build_surface_grid
from data.spatial_analysis import analyze_spatial_grid, extract_profile
from data.sqlite_store import CH1600SQLiteStore
from core.command_service import CommandService
from core.commands import Command, CommandType
from core.external_ipc import ExternalIPCService
from app.config_io import ACQ_MODE_TABLE, load_config, save_config
from app.surface_renderer import SurfaceRenderer

try:
    import pyqtgraph as pg
    _HAS_PYG = True
except ImportError:
    _HAS_PYG = False

_HAS_PYG_GL = SurfaceRenderer.is_available()


class LiveTableModel(QAbstractTableModel):
    """实时数据虚拟表格模型，避免高频场景逐行创建 QTableWidgetItem。"""

    def __init__(self, columns: List[str]) -> None:
        super().__init__()
        self._columns = list(columns)
        self._rows: List[List[str]] = []

    def rowCount(self, parent: QModelIndex = QModelIndex()) -> int:  # noqa: N802
        return 0 if parent.isValid() else len(self._rows)

    def columnCount(self, parent: QModelIndex = QModelIndex()) -> int:  # noqa: N802
        return 0 if parent.isValid() else len(self._columns)

    def data(self, index: QModelIndex, role: int = Qt.DisplayRole):
        if not index.isValid() or role != Qt.DisplayRole:
            return None
        try:
            return self._rows[index.row()][index.column()]
        except IndexError:
            return None

    def headerData(self, section: int, orientation: Qt.Orientation, role: int = Qt.DisplayRole):  # noqa: N802
        if role != Qt.DisplayRole:
            return None
        if orientation == Qt.Horizontal:
            if 0 <= section < len(self._columns):
                return self._columns[section]
            return None
        return str(section + 1)

    def set_columns(self, columns: List[str]) -> None:
        self.beginResetModel()
        self._columns = list(columns)
        self._rows = []
        self.endResetModel()

    def clear(self) -> None:
        self.beginResetModel()
        self._rows = []
        self.endResetModel()

    def append_rows(self, rows: List[List[str]], max_rows: int) -> None:
        if not rows:
            return
        merged = self._rows + rows
        if len(merged) > max_rows:
            merged = merged[-max_rows:]
        self.beginResetModel()
        self._rows = merged
        self.endResetModel()


# ------------------------------------------------------------------
# Siemens 工业风样式表 (复用 odmr-control)
# ------------------------------------------------------------------

SIEMENS_STYLE = """
QMainWindow, QWidget {
    background-color: #f0f0f0;
    color: #1a1a1a;
    font-family: Arial;
    font-size: 12px;
}
QScrollArea {
    background-color: #f0f0f0; border: none;
}
QMenuBar {
    background-color: #e8e8e8; border-bottom: 1px solid #c0c0c0;
    padding: 2px; color: #1a1a1a;
}
QMenuBar::item:selected { background-color: #cce4f7; }
QMenu { background-color: #ffffff; border: 1px solid #c0c0c0; }
QMenu::item:selected { background-color: #cce4f7; }
QTreeWidget {
    background-color: #ffffff; border: 1px solid #c0c0c0;
    outline: none; font-size: 13px;
}
QTreeWidget::item {
    padding: 8px 6px; border-bottom: 1px solid #e8e8e8;
}
QTreeWidget::item:selected { background-color: #cce4f7; color: #1a1a1a; }
QTreeWidget::item:hover { background-color: #e5f0fb; }
QGroupBox {
    font-weight: 600; border: 1px solid #c0c0c0; border-radius: 3px;
    margin-top: 14px; padding: 16px 12px 12px 12px;
    background-color: #ffffff; color: #1a1a1a;
}
QGroupBox::title {
    subcontrol-origin: margin; left: 12px; padding: 0 8px;
    color: #005c8a; background-color: #f0f0f0;
}
QLabel { color: #1a1a1a; }
QLabel#sectionTitle {
    font-size: 15px; font-weight: 700; color: #005c8a;
    padding: 4px 0; border-bottom: 2px solid #0080c8;
}
QLabel#bigData {
    font-family: Menlo, Monaco, "Courier New";
    font-size: 22px; font-weight: 700; color: #005c8a;
    padding: 10px; border: 1px solid #c0c0c0; border-radius: 3px;
    background-color: #f8f8f8;
}
QLabel#smallData {
    font-family: Menlo, Monaco, "Courier New";
    font-size: 16px; font-weight: 700; color: #005c8a;
    padding: 8px; border: 1px solid #c0c0c0; border-radius: 3px;
    background-color: #f8f8f8;
}
QLabel#statusLed {
    min-width: 14px; min-height: 14px; max-width: 14px; max-height: 14px;
    border-radius: 7px; border: 1px solid #999;
}
QLabel#statusLed[on="true"] { background-color: #00a651; border-color: #008a44; }
QLabel#statusLed[on="false"] { background-color: #e04040; border-color: #c03030; }
QPushButton {
    min-height: 28px; padding: 5px 14px; border-radius: 3px; font-weight: 600;
    border: 1px solid #b0b0b0; background-color: #e0e0e0; color: #1a1a1a;
}
QPushButton:hover { background-color: #d0d0d0; border-color: #999; }
QPushButton:pressed { background-color: #c0c0c0; }
QPushButton:disabled { background-color: #e8e8e8; color: #999; border-color: #d0d0d0; }
QPushButton#primaryBtn {
    background-color: #0080c8; color: #ffffff; border: 1px solid #006ba0;
}
QPushButton#primaryBtn:hover { background-color: #0070b0; }
QPushButton#primaryBtn:pressed { background-color: #005c8a; }
QPushButton#dangerBtn {
    background-color: #e04040; color: #ffffff; border: 1px solid #c03030;
}
QPushButton#dangerBtn:hover { background-color: #d03030; }
QPushButton#successBtn {
    background-color: #00a651; color: #ffffff; border: 1px solid #008a44;
}
QPushButton#successBtn:hover { background-color: #009040; }
QLineEdit, QComboBox {
    padding: 5px 7px; border: 1px solid #b0b0b0; border-radius: 3px;
    background-color: #ffffff; color: #1a1a1a;
    selection-background-color: #0080c8; selection-color: #ffffff;
}
QLineEdit:focus, QComboBox:focus { border: 1px solid #0080c8; }
QLineEdit:read-only { background-color: #f0f0f0; color: #555; }
QCheckBox { spacing: 8px; color: #1a1a1a; }
QCheckBox::indicator {
    width: 16px; height: 16px; border: 1px solid #888;
    border-radius: 3px; background-color: #ffffff;
}
QCheckBox::indicator:checked { background-color: #0080c8; border-color: #006ba0; }
QTextEdit {
    font-family: Menlo, Monaco, "Courier New"; font-size: 11px;
    background-color: #ffffff; border: 1px solid #c0c0c0; color: #1a1a1a;
}
QStatusBar {
    background-color: #e0e0e0; border-top: 1px solid #c0c0c0;
    color: #1a1a1a; font-size: 12px;
}
QStatusBar QLabel { padding: 0 12px; }
QFrame#globalStatusBar {
    background-color: #2a2a2a; border-bottom: 1px solid #444;
    padding: 2px 8px;
}
QFrame#globalStatusBar QLabel {
    color: #cccccc; font-size: 10px; padding: 0 2px;
}
QLabel#globalLed {
    min-width: 12px; min-height: 12px; max-width: 12px; max-height: 12px;
    border-radius: 6px; border: 1px solid #666;
}
QLabel#globalLed[on="true"] { background-color: #00a651; border-color: #008a44; }
QLabel#globalLed[on="false"] { background-color: #555; border-color: #444; }
QLabel#globalLed[on="warn"] { background-color: #e04040; border-color: #c03030; }
"""


# ------------------------------------------------------------------
# 主窗口
# ------------------------------------------------------------------

class GaussMeterGUI(QMainWindow):
    _ipc_start_requested = pyqtSignal()
    _ipc_stop_requested = pyqtSignal()
    _raw_log_received = pyqtSignal(str, bytes)

    def __init__(self, cmd_service: CommandService | None = None) -> None:
        super().__init__()
        self.setWindowTitle("CH-1600 数字高斯计 / CH-1600 Digital Gauss Meter")
        self.setMinimumSize(1200, 800)

        # 配置
        self._cfg = load_config()
        self._device_model = self._cfg.get("device_model", "1d_gauss")
        self._probe_profile = self._cfg.get("probe_profile", "standard_hall")

        # 核心
        self._cmd_service = cmd_service
        if self._cmd_service is not None:
            self._ctrl = self._cmd_service._ctrl
            self._cmd_service.ch1600_stream_batch_broadcast.connect(self._on_stream_batch)
            self._cmd_service.ch1600_state_broadcast.connect(self._on_state_changed)
            self._cmd_service.error_occurred.connect(self._on_error)
            self._cmd_service.log_requested.connect(self._on_log)
            self._cmd_service.command_completed.connect(self._on_command_completed)
            self._cmd_service.command_error.connect(self._on_command_error)
            if self._ctrl and hasattr(self._ctrl, "driver"):
                self._ctrl.driver.set_raw_log_callback(self._on_raw_log)
        else:
            self._ctrl = None

        # 数据缓冲 (通道根据设备型号动态决定)
        buffer_cap = self._cfg.get("ui", {}).get("chart_history_points", 5000)
        init_channels = list(get_device_capability(self._device_model).stream_channels)
        self._buffer = CircularBuffer(
            channels=init_channels,
            capacity=buffer_cap,
        )

        # 记录
        self._recorder: Optional[CH1600Recorder] = None
        self._db_store: Optional[CH1600SQLiteStore] = None
        self._db_session_id: Optional[int] = None

        # 数据回看
        self._review_data: Optional[np.ndarray] = None
        self._review_filtered_data: Optional[np.ndarray] = None
        self._review_file_paths: List[Path] = []
        self._review_table_updating = False
        self._pending_live_table_rows: List[List[str]] = []
        self._live_table_model = LiveTableModel(list(get_device_capability(self._device_model).table_columns))

        # 示波器式触发/事件捕获状态
        trigger_cfg = self._cfg.get("trigger", {})
        self._trigger_events: List[Dict[str, Any]] = []
        self._trigger_prev_value: Optional[float] = None
        self._trigger_prev_threshold_ng: Optional[bool] = None
        self._trigger_next_event_id = 1
        self._trigger_armed = True
        self._trigger_max_events = int(trigger_cfg.get("max_events", 100) or 100)
        self._trigger_pre_points: List[Dict[str, float]] = []
        self._trigger_pending_events: List[Dict[str, Any]] = []

        # 软件零点偏移 (仅主线程读写, 无需加锁)。保留 legacy scalar，新增分量级 offset。
        acq_cfg = self._cfg.get("acquisition", {})
        self._zero_offset: float = float(acq_cfg.get("zero_offset", 0.0) or 0.0)
        raw_offsets = acq_cfg.get("zero_offsets", {})
        self._zero_offsets: Dict[str, float] = {}
        if isinstance(raw_offsets, dict):
            for key, value in raw_offsets.items():
                try:
                    self._zero_offsets[str(key)] = float(value)
                except (TypeError, ValueError):
                    pass

        # 显示单位换算 (独立于设备单位, GUI 层实时换算)
        self._UNIT_CONVERSION = dict(get_device_capability(self._device_model).display_scales)
        self._display_unit: str = self._cfg.get("ui", {}).get("display_unit", self._default_unit_for_model())

        # 外部 IPC
        ipc_cfg = self._cfg.get("external_ipc", {})
        self._ipc_service = ExternalIPCService(
            data_pub_port=ipc_cfg.get("zmq_data_port", 5555),
            cmd_rep_port=ipc_cfg.get("zmq_cmd_port", 5556),
        )
        self._ipc_start_requested.connect(self._on_start_stream)
        self._ipc_stop_requested.connect(self._on_stop_stream)
        self._raw_log_received.connect(self._append_raw_log)
        # 注册命令回调
        self._ipc_service.set_command_callbacks({
            "start_acquisition": self._queue_ipc_start,
            "stop_acquisition": self._queue_ipc_stop,
            "get_status": self._get_ipc_status,
        })

        # 显示暂停
        self._display_paused = False

        # 图表交互状态
        self._chart_auto_y = True
        self._chart_y_min = -1.0
        self._chart_y_max = 1.0
        self._live_cursor_data: Tuple[np.ndarray, np.ndarray] = (np.array([]), np.array([]))
        self._review_cursor_data: Tuple[np.ndarray, np.ndarray] = (np.array([]), np.array([]))
        self._last_live_analysis: Dict[str, Dict[str, float]] = {}

        # FPS 跟踪
        self._display_fps = 0.0
        self._display_count = 0
        self._display_fps_ts = time.time()
        self._total_points = 0

        # 应用样式
        self.setStyleSheet(SIEMENS_STYLE)

        # 构建 UI
        self._setup_ui()
        self._init_database_store()

        # 显示更新定时器
        display_ms = self._cfg.get("ui", {}).get("display_interval_ms", 30)
        self._display_timer = QTimer(self)
        self._display_timer.timeout.connect(self._on_display_tick)
        self._display_timer.start(max(16, display_ms))  # 最低 ~60 FPS cap

        self._live_table_timer = QTimer(self)
        self._live_table_timer.timeout.connect(self._flush_live_table_rows)
        self._live_table_timer.start(150)

        # 记录统计定时器
        self._rec_stats_timer = QTimer(self)
        self._rec_stats_timer.timeout.connect(self._update_rec_stats)
        self._rec_stats_timer.setInterval(1000)

        # 初始化全局状态栏
        self._update_global_bar(False, False)

        # 恢复保存的采集模式
        saved_mode = self._cfg.get("acquisition", {}).get("mode_key", "dc_normal")
        idx = self._sample_rate_combo.findData(saved_mode)
        if idx >= 0:
            self._sample_rate_combo.setCurrentIndex(idx)
        self._on_acq_mode_changed()

        # 恢复保存的显示单位
        saved_unit = self._cfg.get("ui", {}).get("display_unit", self._default_unit_for_model())
        unit_idx = self._display_unit_combo.findText(saved_unit)
        if unit_idx >= 0:
            self._display_unit_combo.setCurrentIndex(unit_idx)
        else:
            self._display_unit_combo.setCurrentIndex(0)
            self._display_unit = self._display_unit_combo.currentText()
        self._update_zero_offset_label()

        self.log("[GUI] CH-1600 高斯计控制程序已启动")

    # ==================================================================
    # UI 构建
    # ==================================================================

    def _setup_ui(self) -> None:
        """构建完整 UI 布局。"""
        central = QWidget()
        self.setCentralWidget(central)
        main_layout = QVBoxLayout(central)
        main_layout.setContentsMargins(4, 0, 4, 2)
        main_layout.setSpacing(0)

        # 全局状态栏
        self._global_bar = self._build_global_bar()
        main_layout.addWidget(self._global_bar)

        # 主分隔器
        splitter = QSplitter(Qt.Horizontal)
        splitter.setHandleWidth(1)

        # 左侧导航树
        self._nav_tree = QTreeWidget()
        self._nav_tree.setHeaderHidden(True)
        self._nav_tree.setFixedWidth(200)
        self._nav_tree.setRootIsDecorated(False)
        self._nav_tree.currentItemChanged.connect(self._on_nav_changed)

        nav_items = [
            ("连接 / Connection", 0),
            ("参数设置 / Parameters", 1),
            ("实时数据 / Live Data", 2),
            ("数据回看 / Data Review", 3),
            ("调试 / Debug", 4),
            ("日志 / Log", 5),
        ]
        for label, idx in nav_items:
            item = QTreeWidgetItem([label])
            item.setData(0, Qt.UserRole, idx)
            self._nav_tree.addTopLevelItem(item)

        # 右侧堆叠页面
        self._pages = QStackedWidget()
        self._pages.addWidget(self._build_connection_page())
        self._pages.addWidget(self._build_param_page())
        self._pages.addWidget(self._build_live_data_page())
        self._pages.addWidget(self._build_review_page())
        self._pages.addWidget(self._build_debug_page())
        self._pages.addWidget(self._build_log_page())

        splitter.addWidget(self._nav_tree)
        splitter.addWidget(self._pages)
        splitter.setStretchFactor(0, 0)
        splitter.setStretchFactor(1, 1)
        main_layout.addWidget(splitter, 1)

        # 默认选中第一项
        self._nav_tree.setCurrentItem(self._nav_tree.topLevelItem(0))

        # 状态栏
        self._status_bar = QStatusBar()
        self.setStatusBar(self._status_bar)
        self._status_label = QLabel("就绪 / Ready")
        self._status_bar.addPermanentWidget(self._status_label)

    def _create_scrolled_page(self) -> Tuple[QScrollArea, QWidget, QVBoxLayout]:
        """创建可滚动页面，避免长控制面板在小窗口内互相挤压。"""
        scroll = QScrollArea()
        scroll.setWidgetResizable(True)
        scroll.setFrameShape(QFrame.NoFrame)
        scroll.setHorizontalScrollBarPolicy(Qt.ScrollBarAlwaysOff)

        content = QWidget()
        layout = QVBoxLayout(content)
        layout.setContentsMargins(16, 16, 16, 16)
        layout.setSpacing(10)
        scroll.setWidget(content)
        return scroll, content, layout

    # ------------------------------------------------------------------
    # 全局状态栏
    # ------------------------------------------------------------------

    def _build_global_bar(self) -> QFrame:
        bar = QFrame()
        bar.setObjectName("globalStatusBar")
        bar.setFixedHeight(28)
        layout = QHBoxLayout(bar)
        layout.setContentsMargins(8, 2, 8, 2)
        layout.setSpacing(16)

        # 连接 LED
        self._conn_led = QLabel()
        self._conn_led.setObjectName("globalLed")
        self._conn_led.setProperty("on", "false")
        self._conn_led.setToolTip("设备连接状态")
        layout.addWidget(QLabel("CH-1600"))
        layout.addWidget(self._conn_led)

        # 流状态 LED
        self._stream_led = QLabel()
        self._stream_led.setObjectName("globalLed")
        self._stream_led.setProperty("on", "false")
        self._stream_led.setToolTip("数据流状态")
        layout.addWidget(QLabel("Stream"))
        layout.addWidget(self._stream_led)

        # 记录状态 LED
        self._rec_led = QLabel()
        self._rec_led.setObjectName("globalLed")
        self._rec_led.setProperty("on", "false")
        self._rec_led.setToolTip("记录状态")
        layout.addWidget(QLabel("REC"))
        layout.addWidget(self._rec_led)

        layout.addStretch()

        # 设备信息
        self._global_info = QLabel("未连接")
        layout.addWidget(self._global_info)
        layout.addStretch()

        # FPS
        self._global_fps = QLabel("FPS: --")
        layout.addWidget(self._global_fps)

        # 数据点计数
        self._global_pts = QLabel("0 pts")
        layout.addWidget(self._global_pts)

        return bar

    def _update_global_bar(self, connected: bool, streaming: bool) -> None:
        self._conn_led.setProperty("on", "true" if connected else "false")
        self._conn_led.style().unpolish(self._conn_led)
        self._conn_led.style().polish(self._conn_led)

        self._stream_led.setProperty("on", "true" if streaming else "false")
        self._stream_led.style().unpolish(self._stream_led)
        self._stream_led.style().polish(self._stream_led)

        self._rec_led.setProperty("on", "true" if (self._recorder and self._recorder.is_recording) else "false")
        self._rec_led.style().unpolish(self._rec_led)
        self._rec_led.style().polish(self._rec_led)

        if connected:
            unit = self._ctrl.driver.cached_unit if self._ctrl else "?"
            rng = self._ctrl.driver.cached_range if self._ctrl else "?"
            mode = self._get_active_acq_mode()
            short_label = mode["label"].split("(")[0].strip()
            self._global_info.setText(f"{unit} | {rng} | {short_label}")
        else:
            self._global_info.setText("未连接")

    def _get_ipc_status(self) -> dict:
        return {
            "connected": self._ctrl.is_connected if self._ctrl else False,
            "streaming": self._ctrl.is_streaming if self._ctrl else False,
        }

    def _queue_ipc_start(self) -> dict:
        self._ipc_start_requested.emit()
        return {"queued": True}

    def _queue_ipc_stop(self) -> dict:
        self._ipc_stop_requested.emit()
        return {"queued": True}

    def _init_database_store(self) -> None:
        db_cfg = self._cfg.get("database", {})
        if not db_cfg.get("enabled", True):
            self.log("[DB] SQLite 记录已禁用")
            return
        try:
            db_path = Path(db_cfg.get("path", "./experiments/m1600.sqlite3"))
            self._db_store = CH1600SQLiteStore(db_path)
            self.log(f"[DB] SQLite 数据库就绪: {db_path}")
        except Exception as exc:
            self._db_store = None
            self.log(f"[DB] SQLite 初始化失败: {exc}")

    # ==================================================================
    # 页面 0: 连接
    # ==================================================================

    def _build_connection_page(self) -> QWidget:
        page = QWidget()
        layout = QVBoxLayout(page)
        layout.setContentsMargins(16, 16, 16, 16)

        title = QLabel("设备连接 / Device Connection")
        title.setObjectName("sectionTitle")
        layout.addWidget(title)

        # 串口设置
        grp = QGroupBox("串口设置 / Serial Settings")
        g = QGridLayout(grp)

        g.addWidget(QLabel("端口 / Port:"), 0, 0)
        self._port_combo = QComboBox()
        self._port_combo.setEditable(True)
        self._port_combo.setMinimumWidth(150)
        g.addWidget(self._port_combo, 0, 1)

        g.addWidget(QLabel("波特率 / Baud:"), 0, 2)
        self._baud_combo = QComboBox()
        self._baud_combo.addItems(["115200", "57600", "19200"])
        self._baud_combo.setCurrentText("115200")
        g.addWidget(self._baud_combo, 0, 3)

        layout.addWidget(grp)

        # 按钮
        btn_row = QHBoxLayout()
        self._scan_btn = QPushButton("扫描端口 / Scan Ports")
        self._scan_btn.clicked.connect(self._on_scan_ports)
        btn_row.addWidget(self._scan_btn)

        self._connect_btn = QPushButton("连接 / Connect")
        self._connect_btn.setObjectName("primaryBtn")
        self._connect_btn.clicked.connect(self._on_connect)
        self._connect_btn.setEnabled(False)
        btn_row.addWidget(self._connect_btn)

        self._disconnect_btn = QPushButton("断开 / Disconnect")
        self._disconnect_btn.setObjectName("dangerBtn")
        self._disconnect_btn.setEnabled(False)
        self._disconnect_btn.clicked.connect(self._on_disconnect)
        btn_row.addWidget(self._disconnect_btn)

        btn_row.addStretch()
        layout.addLayout(btn_row)

        # 设备信息
        info_grp = QGroupBox("设备信息 / Device Info")
        info_layout = QVBoxLayout(info_grp)
        self._conn_info_label = QLabel("未连接 / Not Connected")
        self._conn_info_label.setObjectName("smallData")
        info_layout.addWidget(self._conn_info_label)
        layout.addWidget(info_grp)

        layout.addStretch()
        return page

    # ==================================================================
    # 页面 1: 参数设置
    # ==================================================================

    def _build_param_page(self) -> QWidget:
        page, _content, layout = self._create_scrolled_page()

        title = QLabel("参数设置 / Parameters")
        title.setObjectName("sectionTitle")
        layout.addWidget(title)

        # ── 采集模式 ──
        acq_grp = QGroupBox("采集模式 / Acquisition Mode")
        ag = QGridLayout(acq_grp)

        ag.addWidget(QLabel("测量类型 / Meas. Type:"), 0, 0)
        self._meas_type_combo = QComboBox()
        self._meas_type_combo.addItems([
            "DC 直流 (默认)",
            "AC 低频 / ACL",
            "AC 中高频 / ACH",
        ])
        self._meas_type_combo.currentIndexChanged.connect(self._on_acq_mode_changed)
        ag.addWidget(self._meas_type_combo, 0, 1)

        ag.addWidget(QLabel("采集速率 / Sample Rate:"), 1, 0)
        self._sample_rate_combo = QComboBox()
        # 按 ACQ_MODE_TABLE 的 key 顺序
        self._rate_keys = ["dc_normal", "dc_20hz", "dc_50hz", "dc_100hz",
                           "dc_200hz", "dc_200plus",
                           "ac_20hz", "ac_50hz", "ac_100hz", "ac_200hz"]
        for k in self._rate_keys:
            self._sample_rate_combo.addItem(ACQ_MODE_TABLE[k]["label"], k)
        self._sample_rate_combo.currentIndexChanged.connect(self._on_acq_mode_changed)
        ag.addWidget(self._sample_rate_combo, 1, 1)

        ag.addWidget(QLabel("设备型号 / Device Model:"), 2, 0)
        self._device_model_combo = QComboBox()
        for cap in iter_device_capabilities():
            self._device_model_combo.addItem(cap.label, cap.model)
        idx = self._device_model_combo.findData(self._device_model)
        if idx >= 0:
            self._device_model_combo.setCurrentIndex(idx)
        self._device_model_combo.currentIndexChanged.connect(self._on_device_model_changed)
        ag.addWidget(self._device_model_combo, 2, 1)

        ag.addWidget(QLabel("探头档案 / Probe Profile:"), 3, 0)
        self._probe_profile_combo = QComboBox()
        for profile in iter_probe_profiles():
            self._probe_profile_combo.addItem(profile.label, profile.name)
        pidx = self._probe_profile_combo.findData(self._probe_profile)
        if pidx >= 0:
            self._probe_profile_combo.setCurrentIndex(pidx)
        self._probe_profile_combo.currentIndexChanged.connect(self._on_probe_profile_changed)
        ag.addWidget(self._probe_profile_combo, 3, 1)

        # 模式信息
        self._acq_info_label = QLabel()
        self._acq_info_label.setObjectName("smallData")
        self._acq_info_label.setWordWrap(True)
        ag.addWidget(self._acq_info_label, 4, 0, 1, 2)

        layout.addWidget(acq_grp)

        # ── 设备面板操作引导 ──
        guide_grp = QGroupBox("设备面板操作引导 / Device Panel Guide")
        guide_grp.setCheckable(True)
        guide_grp.setChecked(False)
        gv = QVBoxLayout(guide_grp)

        guide_text = QLabel(
            "<b>⚠ 以下参数仅可通过 CH-1600 前面板设置，RS-232 协议不支持远程控制。</b><br>"
            "<br>"
            "<b>▶ AC/DC 模式切换：</b><br>"
            "  按前面板 <b>[AC/DC]</b> 键循环切换：<br>"
            "  &nbsp;&nbsp;DC 直流 → AC 低频 (ACL) → AC 中高频 (ACH) → DC ...<br>"
            "  <i>切换后请在上方手动同步选择对应模式。</i><br>"
            "<br>"
            "<b>▶ 采集速率调节（已支持软件远程切换）：</b><br>"
            "  软件可直接通过 RS-232 发送 FASTxxx> 指令切换采样速率。<br>"
            "  常速: DATA?> | 20Hz: FAST020> | 50Hz: FAST050> | 100Hz: FAST100><br>"
            "  200Hz: FAST200> | 200+Hz: FAST300><br>"
            "  <i>出厂默认：常速 (~4-10 Hz, 最高精度 ±0.00001 mT)。</i><br>"
            "  <i>速率越高精度越低，详见说明书表 4-2。</i><br>"
            "<br>"
            "<b>▶ 实时发送 (Realtime Transmit) 模式：</b><br>"
            "  按 <b>[Menu]</b> → 选择 <b>Realtime Transmit</b> → 按 Enter →<br>"
            "  设备开始持续串口发送数据帧，此时 <b>RS-232 指令不可用</b>。<br>"
            "  <i>要恢复指令控制：在设备面板按 Enter 退出实时发送模式。</i><br>"
            "  <b>设备人工超控：</b>menu-urat-连续按enter切换回指令模式"
        )
        guide_text.setWordWrap(True)
        guide_text.setStyleSheet("font-size: 11px; color: #555;")
        gv.addWidget(guide_text)
        layout.addWidget(guide_grp)

        # ── 单位和量程 ──
        grp1 = QGroupBox("单位和量程 / Unit & Range")
        g1 = QGridLayout(grp1)

        g1.addWidget(QLabel("当前单位:"), 0, 0)
        self._unit_label = QLabel("--")
        self._unit_label.setObjectName("smallData")
        g1.addWidget(self._unit_label, 0, 1)

        self._unit_btn = QPushButton("切换单位 / Cycle Unit")
        self._unit_btn.clicked.connect(self._on_cycle_unit)
        self._unit_btn.setEnabled(False)
        g1.addWidget(self._unit_btn, 0, 2)

        g1.addWidget(QLabel("显示单位:"), 1, 0)
        self._display_unit_combo = QComboBox()
        self._display_unit_combo.addItems(self._get_display_unit_options(self._device_model))
        self._display_unit_combo.currentTextChanged.connect(self._on_display_unit_changed)
        g1.addWidget(self._display_unit_combo, 1, 1)

        g1.addWidget(QLabel("当前量程:"), 2, 0)
        self._range_label = QLabel("--")
        self._range_label.setObjectName("smallData")
        g1.addWidget(self._range_label, 2, 1)

        self._range_btn = QPushButton("切换量程 / Cycle Range")
        self._range_btn.clicked.connect(self._on_cycle_range)
        self._range_btn.setEnabled(False)
        g1.addWidget(self._range_btn, 2, 2)

        layout.addWidget(grp1)

        # 阈值
        grp2 = QGroupBox("阈值报警 / Threshold Alarm")
        g2 = QGridLayout(grp2)

        g2.addWidget(QLabel("上限 (mT):"), 0, 0)
        self._up_thresh_edit = QLineEdit("0.00")
        self._up_thresh_edit.setValidator(QDoubleValidator(-99999, 99999, 2))
        self._up_thresh_edit.setEnabled(False)
        g2.addWidget(self._up_thresh_edit, 0, 1)
        self._set_up_thresh_btn = QPushButton("设置 / Set")
        self._set_up_thresh_btn.clicked.connect(self._on_set_up_thresh)
        self._set_up_thresh_btn.setEnabled(False)
        g2.addWidget(self._set_up_thresh_btn, 0, 2)

        g2.addWidget(QLabel("下限 (mT):"), 1, 0)
        self._low_thresh_edit = QLineEdit("0.00")
        self._low_thresh_edit.setValidator(QDoubleValidator(-99999, 99999, 2))
        self._low_thresh_edit.setEnabled(False)
        g2.addWidget(self._low_thresh_edit, 1, 1)
        self._set_low_thresh_btn = QPushButton("设置 / Set")
        self._set_low_thresh_btn.clicked.connect(self._on_set_low_thresh)
        self._set_low_thresh_btn.setEnabled(False)
        g2.addWidget(self._set_low_thresh_btn, 1, 2)

        layout.addWidget(grp2)

        # 操作
        grp3 = QGroupBox("操作 / Operations")
        g3 = QHBoxLayout(grp3)

        self._zero_btn = QPushButton("归零 / Zero")
        self._zero_btn.clicked.connect(self._on_zero)
        self._zero_btn.setEnabled(False)
        g3.addWidget(self._zero_btn)

        self._maxmin_btn = QPushButton("最大/最小值 / Max-Min")
        self._maxmin_btn.clicked.connect(self._on_max_min)
        self._maxmin_btn.setEnabled(False)
        g3.addWidget(self._maxmin_btn)

        self._lock_btn = QPushButton("锁定面板 / Lock Panel")
        self._lock_btn.setCheckable(True)
        self._lock_btn.clicked.connect(self._on_toggle_lock)
        self._lock_btn.setEnabled(False)
        g3.addWidget(self._lock_btn)

        g3.addStretch()
        layout.addWidget(grp3)

        # ── 外部集成 / External IPC ──
        ipc_cfg = self._cfg.get("external_ipc", {})
        ipc_grp = QGroupBox("外部集成 / External IPC")
        ipc_v = QVBoxLayout(ipc_grp)

        ipc_mode_row = QHBoxLayout()
        self._ipc_enabled_cb = QCheckBox("启用 ZMQ 广播 / Enable ZMQ")
        self._ipc_enabled_cb.setChecked(
            ipc_cfg.get("enabled", False) and ipc_cfg.get("mode", "zmq") == "zmq"
        )
        if not self._ipc_service.zmq_available:
            self._ipc_enabled_cb.setChecked(False)
            self._ipc_enabled_cb.setEnabled(False)
            self._ipc_enabled_cb.setToolTip("pyzmq 未安装，ZMQ IPC 不可用")
        ipc_mode_row.addWidget(self._ipc_enabled_cb)

        self._ipc_namedpipe_cb = QCheckBox("启用 NamedPipe / Enable NamedPipe")
        self._ipc_namedpipe_cb.setChecked(
            ipc_cfg.get("enabled", False) and ipc_cfg.get("mode", "zmq") == "namedpipe"
        )
        ipc_mode_row.addWidget(self._ipc_namedpipe_cb)
        ipc_mode_row.addStretch()
        ipc_v.addLayout(ipc_mode_row)

        ipc_port_row = QHBoxLayout()
        ipc_port_row.addWidget(QLabel("ZMQ 数据端口 / Data Port:"))
        self._ipc_data_port_spin = QSpinBox()
        self._ipc_data_port_spin.setRange(1024, 65535)
        self._ipc_data_port_spin.setValue(ipc_cfg.get("zmq_data_port", 5555))
        ipc_port_row.addWidget(self._ipc_data_port_spin)

        ipc_port_row.addWidget(QLabel("ZMQ 命令端口 / Cmd Port:"))
        self._ipc_cmd_port_spin = QSpinBox()
        self._ipc_cmd_port_spin.setRange(1024, 65535)
        self._ipc_cmd_port_spin.setValue(ipc_cfg.get("zmq_cmd_port", 5556))
        ipc_port_row.addWidget(self._ipc_cmd_port_spin)
        ipc_port_row.addStretch()
        ipc_v.addLayout(ipc_port_row)

        layout.addWidget(ipc_grp)

        layout.addStretch()
        return page

    # ==================================================================
    # 页面 2: 实时数据
    # ==================================================================

    def _build_live_data_page(self) -> QWidget:
        page, _content, layout = self._create_scrolled_page()

        title = QLabel("实时数据 / Live Data")
        title.setObjectName("sectionTitle")
        layout.addWidget(title)

        # 数值显示行
        num_row = QHBoxLayout()

        # 磁场值
        field_box = QVBoxLayout()
        field_box.addWidget(QLabel("磁场 / Field"))
        self._field_label = QLabel("0.0000 mT")
        self._field_label.setObjectName("bigData")
        self._field_label.setAlignment(Qt.AlignCenter)
        self._field_label.setMinimumWidth(180)
        field_box.addWidget(self._field_label)
        num_row.addLayout(field_box)

        # 频率
        freq_box = QVBoxLayout()
        freq_label_title = QLabel("频率 / Frequency")
        freq_box.addWidget(freq_label_title)
        self._freq_label = QLabel("DC")
        self._freq_label.setObjectName("smallData")
        self._freq_label.setAlignment(Qt.AlignCenter)
        self._freq_label.setMinimumWidth(120)
        self._freq_label.setToolTip(
            "DC 模式下频率恒为 0，需按设备面板 [AC/DC] 键切换到 ACL/ACH 模式才能测量交流频率"
        )
        freq_box.addWidget(self._freq_label)
        num_row.addLayout(freq_box)

        # 温度
        temp_box = QVBoxLayout()
        temp_box.addWidget(QLabel("温度 / Temperature"))
        self._temp_label = QLabel("0.0 °C")
        self._temp_label.setObjectName("smallData")
        self._temp_label.setAlignment(Qt.AlignCenter)
        self._temp_label.setMinimumWidth(120)
        temp_box.addWidget(self._temp_label)
        num_row.addLayout(temp_box)

        layout.addLayout(num_row)

        # ── 阈值状态显示 ──
        judge_grp = QGroupBox("阈值判断 / Threshold Judge")
        judge_grp.setObjectName("judgeGroup")
        jv = QHBoxLayout(judge_grp)

        self._judge_status_label = QLabel("未启用 / Disabled")
        self._judge_status_label.setObjectName("smallData")
        self._judge_status_label.setAlignment(Qt.AlignCenter)
        self._judge_status_label.setMinimumWidth(120)
        jv.addWidget(self._judge_status_label)

        self._judge_mode_combo = QComboBox()
        self._judge_mode_combo.addItems(["闭区间 / Closed", "开区间 / Open"])
        self._judge_mode_combo.setToolTip(
            "闭区间: 值在[下限,上限]内为OK; 开区间: 值在(下限,上限)内为NG"
        )
        jv.addWidget(self._judge_mode_combo)

        self._judge_abs_cb = QCheckBox("ABS 绝对值 / Absolute")
        self._judge_abs_cb.setToolTip("先取绝对值再判断")
        jv.addWidget(self._judge_abs_cb)

        self._judge_channel_combo = QComboBox()
        saved_judge_channel = self._cfg.get("acquisition", {}).get("threshold_channel", "field_total")
        self._populate_threshold_channel_combo(saved_judge_channel)
        self._judge_channel_combo.currentTextChanged.connect(self._on_threshold_channel_changed)
        self._judge_channel_combo.setToolTip("阈值判断通道，默认使用 Total B")
        jv.addWidget(QLabel("通道 / Channel:"))
        jv.addWidget(self._judge_channel_combo)

        jv.addStretch()
        layout.addWidget(judge_grp)

        # 流控制按钮行 1: 采集 + 归零
        ctrl_row = QHBoxLayout()

        self._stream_start_btn = QPushButton("开始采集 / Start Acquisition")
        self._stream_start_btn.setObjectName("successBtn")
        self._stream_start_btn.clicked.connect(self._on_start_stream)
        self._stream_start_btn.setEnabled(False)
        ctrl_row.addWidget(self._stream_start_btn)

        self._stream_stop_btn = QPushButton("停止采集 / Stop Acquisition")
        self._stream_stop_btn.setObjectName("dangerBtn")
        self._stream_stop_btn.clicked.connect(self._on_stop_stream)
        self._stream_stop_btn.setEnabled(False)
        ctrl_row.addWidget(self._stream_stop_btn)

        self._zero_btn2 = QPushButton("归零 / Zero")
        self._zero_btn2.clicked.connect(self._on_zero)
        self._zero_btn2.setEnabled(False)
        ctrl_row.addWidget(self._zero_btn2)

        ctrl_row.addSpacing(16)

        # 软件零点偏移
        self._set_zero_btn = QPushButton("软件归零 / Set Zero")
        self._set_zero_btn.clicked.connect(self._on_set_zero)
        self._set_zero_btn.setEnabled(False)
        ctrl_row.addWidget(self._set_zero_btn)

        self._clear_zero_btn = QPushButton("清除归零 / Clear Zero")
        self._clear_zero_btn.clicked.connect(self._on_clear_zero)
        self._clear_zero_btn.setEnabled(False)
        ctrl_row.addWidget(self._clear_zero_btn)

        self._zero_offset_label = QLabel("Zero offset: 0.0000 mT")
        self._zero_offset_label.setObjectName("smallData")

        ctrl_row.addStretch()
        self._live_stats = QLabel("FPS: -- | 数据点: 0 | 状态: 就绪")

        layout.addLayout(ctrl_row)

        ctrl_status_row = QHBoxLayout()
        ctrl_status_row.addWidget(self._zero_offset_label)
        ctrl_status_row.addStretch()
        ctrl_status_row.addWidget(self._live_stats)
        layout.addLayout(ctrl_status_row)

        measure_grp = QGroupBox("测量指标 / Measurements")
        measure_grid = QGridLayout(measure_grp)
        measure_grid.setHorizontalSpacing(14)
        measure_grid.setVerticalSpacing(6)
        self._live_metric_labels: Dict[str, QLabel] = {}
        metric_defs = [
            ("current", "当前 / Current"),
            ("min", "Min"),
            ("max", "Max"),
            ("peak_to_peak", "Pk-Pk"),
            ("rms", "RMS"),
            ("std", "Std"),
            ("sample_rate_hz", "实际采样率 / Sample Rate"),
            ("duration_s", "窗口时长 / Duration"),
            ("threshold", "阈值事件 / Threshold"),
            ("vector", "矢量方向 / Vector"),
        ]
        for idx, (key, label_text) in enumerate(metric_defs):
            row = idx // 5
            col = (idx % 5) * 2
            measure_grid.addWidget(QLabel(label_text + ":"), row, col)
            value = QLabel("--")
            value.setTextInteractionFlags(Qt.TextSelectableByMouse)
            value.setMinimumWidth(110)
            self._live_metric_labels[key] = value
            measure_grid.addWidget(value, row, col + 1)
        layout.addWidget(measure_grp)

        trigger_grp = QGroupBox("触发捕获 / Trigger Capture")
        trigger_grid = QGridLayout(trigger_grp)
        self._trigger_enabled_cb = QCheckBox("启用 / Enable")
        self._trigger_enabled_cb.toggled.connect(self._on_trigger_enabled_changed)
        trigger_grid.addWidget(self._trigger_enabled_cb, 0, 0)
        self._trigger_mode_combo = QComboBox()
        self._trigger_mode_combo.addItem("阈值超限 / Threshold NG", "threshold")
        self._trigger_mode_combo.addItem("上升沿 / Rising Edge", "rising")
        self._trigger_mode_combo.addItem("下降沿 / Falling Edge", "falling")
        trigger_grid.addWidget(self._trigger_mode_combo, 0, 1)
        trigger_grid.addWidget(QLabel("电平 / Level:"), 0, 2)
        self._trigger_level_edit = QLineEdit(str(self._cfg.get("trigger", {}).get("level", 0.0)))
        self._trigger_level_edit.setValidator(QDoubleValidator())
        self._trigger_level_edit.setFixedWidth(90)
        trigger_grid.addWidget(self._trigger_level_edit, 0, 3)
        trigger_grid.addWidget(QLabel("Pre/Post:"), 0, 4)
        self._trigger_pre_spin = QSpinBox()
        self._trigger_pre_spin.setRange(0, 5000)
        self._trigger_pre_spin.setValue(int(self._cfg.get("trigger", {}).get("pre_points", 50) or 50))
        self._trigger_pre_spin.setToolTip("每个事件保存的触发前点数")
        trigger_grid.addWidget(self._trigger_pre_spin, 0, 5)
        self._trigger_post_spin = QSpinBox()
        self._trigger_post_spin.setRange(0, 5000)
        self._trigger_post_spin.setValue(int(self._cfg.get("trigger", {}).get("post_points", 50) or 50))
        self._trigger_post_spin.setToolTip("每个事件保存的触发后点数")
        trigger_grid.addWidget(self._trigger_post_spin, 0, 6)
        self._trigger_single_cb = QCheckBox("Single")
        self._trigger_single_cb.setToolTip("触发一次后自动解除 armed 状态")
        trigger_grid.addWidget(self._trigger_single_cb, 0, 7)
        arm_btn = QPushButton("Arm")
        arm_btn.clicked.connect(self._arm_trigger)
        trigger_grid.addWidget(arm_btn, 0, 8)
        clear_trig_btn = QPushButton("清空事件 / Clear Events")
        clear_trig_btn.clicked.connect(self._clear_trigger_events)
        trigger_grid.addWidget(clear_trig_btn, 0, 9)
        replay_trig_btn = QPushButton("回放最后事件 / Replay Last")
        replay_trig_btn.clicked.connect(self._replay_last_trigger_event)
        trigger_grid.addWidget(replay_trig_btn, 0, 10)
        self._trigger_status_label = QLabel("未启用 / Disabled")
        self._trigger_status_label.setTextInteractionFlags(Qt.TextSelectableByMouse)
        trigger_grid.addWidget(self._trigger_status_label, 1, 0, 1, 11)
        self._trigger_event_table = QTableWidget()
        self._trigger_event_table.setColumnCount(6)
        self._trigger_event_table.setHorizontalHeaderLabels(["#", "Time(s)", "Mode", "Value", "Window", "DB"])
        self._trigger_event_table.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self._trigger_event_table.setMaximumHeight(120)
        self._trigger_event_table.setSelectionBehavior(QAbstractItemView.SelectRows)
        self._trigger_event_table.setEditTriggers(QAbstractItemView.NoEditTriggers)
        self._trigger_event_table.itemSelectionChanged.connect(self._on_trigger_event_selected)
        trigger_grid.addWidget(self._trigger_event_table, 2, 0, 1, 11)
        trigger_grid.setColumnStretch(10, 1)
        layout.addWidget(trigger_grp)

        self._live_tabs = QTabWidget()
        chart_page = QWidget()
        chart_layout = QVBoxLayout(chart_page)
        chart_layout.setContentsMargins(8, 8, 8, 8)
        chart_layout.setSpacing(8)
        table_page = QWidget()
        table_layout = QVBoxLayout(table_page)
        table_layout.setContentsMargins(8, 8, 8, 8)
        table_layout.setSpacing(8)
        recording_page = QWidget()
        recording_layout = QVBoxLayout(recording_page)
        recording_layout.setContentsMargins(8, 8, 8, 8)
        recording_layout.setSpacing(8)
        self._live_tabs.addTab(chart_page, "波形 / Chart")
        self._live_tabs.addTab(table_page, "实时表格 / Table")
        self._live_tabs.addTab(recording_page, "数据记录 / Recording")
        layout.addWidget(self._live_tabs)

        # pyqtgraph 图表
        if _HAS_PYG:
            self._plot_widget = pg.PlotWidget()
            self._plot_widget.setLabel("left", "磁场", units="mT")
            self._plot_widget.setLabel("bottom", "时间", units="s")
            self._plot_widget.showGrid(x=True, y=True, alpha=0.3)
            self._plot_widget.addLegend()
            self._plot_widget.setMinimumHeight(360)

            # 性能优化
            self._plot_widget.setClipToView(True)
            self._plot_widget.setAntialiasing(False)

            field_color = self._cfg.get("ui", {}).get("chart_colors", {}).get("field", "#0080c8")
            freq_color = self._cfg.get("ui", {}).get("chart_colors", {}).get("freq", "#00a651")
            line_width = self._cfg.get("ui", {}).get("chart_line_width", 2)
            self._field_curve = self._plot_widget.plot(
                pen=pg.mkPen(field_color, width=line_width), name="Total B"
            )
            self._freq_curve = self._plot_widget.plot(
                pen=pg.mkPen(freq_color, width=line_width), name="频率/Hz"
            )
            self._freq_curve.setVisible(False)

            # 多通道分量曲线 (2D/3D 模式下使用)
            self._field_x_curve = self._plot_widget.plot(
                pen=pg.mkPen("#e04040", width=1), name="X"
            )
            self._field_y_curve = self._plot_widget.plot(
                pen=pg.mkPen("#00a651", width=1), name="Y"
            )
            self._field_z_curve = self._plot_widget.plot(
                pen=pg.mkPen("#f0a000", width=1), name="Z"
            )
            self._field_x_curve.setVisible(False)
            self._field_y_curve.setVisible(False)
            self._field_z_curve.setVisible(False)

            # 零位参考线
            self._zero_line = pg.InfiniteLine(
                pos=0, angle=0, pen=pg.mkPen("#c0c0c0", width=1, style=Qt.DashLine)
            )
            self._plot_widget.addItem(self._zero_line)
            self._live_mean_line = pg.InfiniteLine(
                pos=0, angle=0, pen=pg.mkPen("#ffaa00", width=1, style=Qt.DashLine)
            )
            self._live_mean_line.setVisible(False)
            self._plot_widget.addItem(self._live_mean_line)
            self._live_thresh_low_line = pg.InfiniteLine(
                pos=0, angle=0, pen=pg.mkPen("#e04040", width=1, style=Qt.DotLine)
            )
            self._live_thresh_high_line = pg.InfiniteLine(
                pos=0, angle=0, pen=pg.mkPen("#e04040", width=1, style=Qt.DotLine)
            )
            self._live_thresh_low_line.setVisible(False)
            self._live_thresh_high_line.setVisible(False)
            self._plot_widget.addItem(self._live_thresh_low_line)
            self._plot_widget.addItem(self._live_thresh_high_line)
            self._live_cursor_a = pg.InfiniteLine(pos=-1.0, angle=90, movable=True, pen=pg.mkPen("#f0a000", width=1))
            self._live_cursor_b = pg.InfiniteLine(pos=0.0, angle=90, movable=True, pen=pg.mkPen("#f0a000", width=1))
            self._live_cursor_a.sigPositionChanged.connect(self._update_live_cursor_readout)
            self._live_cursor_b.sigPositionChanged.connect(self._update_live_cursor_readout)
            self._live_cursor_a.setVisible(False)
            self._live_cursor_b.setVisible(False)
            self._plot_widget.addItem(self._live_cursor_a)
            self._plot_widget.addItem(self._live_cursor_b)
            self._live_cursor_label = pg.TextItem("", color="#f0a000", anchor=(0, 1))
            self._live_cursor_label.setVisible(False)
            self._plot_widget.addItem(self._live_cursor_label)
            self._live_peak_labels = []
            self._trigger_marker_item = pg.ScatterPlotItem(size=9, brush=pg.mkBrush("#e04040"), pen=pg.mkPen("#ffffff"))
            self._plot_widget.addItem(self._trigger_marker_item)

            chart_layout.addWidget(self._plot_widget)
        else:
            self._plot_widget = None
            no_plot = QLabel("pyqtgraph 未安装, 图表不可用 / pyqtgraph not installed")
            no_plot.setAlignment(Qt.AlignCenter)
            chart_layout.addWidget(no_plot)

        # 复选框行
        chk_row = QHBoxLayout()
        self._show_freq_cb = QCheckBox("显示频率曲线 / Show Frequency")
        self._show_freq_cb.toggled.connect(self._on_toggle_freq_curve)
        chk_row.addWidget(self._show_freq_cb)
        self._live_cursor_cb = QCheckBox("游标 / Cursors")
        self._live_cursor_cb.toggled.connect(self._on_toggle_live_cursors)
        chk_row.addWidget(self._live_cursor_cb)
        self._live_peaks_cb = QCheckBox("峰谷标注 / Peaks")
        self._live_peaks_cb.toggled.connect(lambda _checked: self._update_live_peak_markers())
        chk_row.addWidget(self._live_peaks_cb)
        chk_row.addStretch()
        chart_layout.addLayout(chk_row)

        # 图表配置区
        chart_cfg_grp = QGroupBox("图表配置 / Chart Config")
        cfg_g = QGridLayout(chart_cfg_grp)

        # 曲线颜色
        cfg_g.addWidget(QLabel("曲线颜色 / Curve Colors:"), 0, 0)
        color_row = QHBoxLayout()
        self._field_color_btn = QPushButton("磁场颜色 / Field Color")
        self._field_color_btn.clicked.connect(self._on_field_color)
        color_row.addWidget(self._field_color_btn)
        self._freq_color_btn = QPushButton("频率颜色 / Freq Color")
        self._freq_color_btn.clicked.connect(self._on_freq_color)
        color_row.addWidget(self._freq_color_btn)
        cfg_g.addLayout(color_row, 0, 1)

        # 线宽
        cfg_g.addWidget(QLabel("线宽 / Line Width:"), 1, 0)
        self._line_width_slider = QSlider(Qt.Horizontal)
        self._line_width_slider.setRange(1, 5)
        default_width = self._cfg.get("ui", {}).get("chart_line_width", 2)
        self._line_width_slider.setValue(default_width)
        self._line_width_slider.valueChanged.connect(self._on_line_width_changed)
        cfg_g.addWidget(self._line_width_slider, 1, 1)

        # 历史点数
        cfg_g.addWidget(QLabel("历史点数 / History:"), 2, 0)
        self._history_slider = QSlider(Qt.Horizontal)
        self._history_slider.setRange(1000, 20000)
        self._history_slider.setSingleStep(1000)
        self._history_slider.setPageStep(1000)
        default_hist = self._cfg.get("ui", {}).get("chart_history_points", 5000)
        self._history_slider.setValue(default_hist)
        self._history_slider.valueChanged.connect(self._on_history_points_changed)
        cfg_g.addWidget(self._history_slider, 2, 1)

        # Y 轴范围
        y_row = QHBoxLayout()
        self._auto_y_cb = QCheckBox("自动 Y 轴 / Auto Y Range")
        self._auto_y_cb.setChecked(True)
        self._auto_y_cb.toggled.connect(self._on_auto_y_toggled)
        y_row.addWidget(self._auto_y_cb)

        self._y_min_edit = QLineEdit(str(self._chart_y_min))
        self._y_min_edit.setFixedWidth(80)
        self._y_min_edit.setEnabled(False)
        self._y_min_edit.editingFinished.connect(self._on_y_range_changed)
        y_row.addWidget(QLabel("Min:"))
        y_row.addWidget(self._y_min_edit)

        self._y_max_edit = QLineEdit(str(self._chart_y_max))
        self._y_max_edit.setFixedWidth(80)
        self._y_max_edit.setEnabled(False)
        self._y_max_edit.editingFinished.connect(self._on_y_range_changed)
        y_row.addWidget(QLabel("Max:"))
        y_row.addWidget(self._y_max_edit)

        y_row.addStretch()
        cfg_g.addLayout(y_row, 3, 0, 1, 2)

        # 保存配置按钮
        save_cfg_btn = QPushButton("保存图表配置 / Save Chart Config")
        save_cfg_btn.clicked.connect(self._on_save_chart_config)
        cfg_g.addWidget(save_cfg_btn, 4, 0, 1, 2, alignment=Qt.AlignLeft)

        chart_layout.addWidget(chart_cfg_grp)

        # 图表控制按钮行 (清除 / 暂停 / 保存)
        chart_btn_row = QHBoxLayout()

        clear_chart_btn = QPushButton("清除图表 / Clear Chart")
        clear_chart_btn.clicked.connect(self._on_clear_chart)
        chart_btn_row.addWidget(clear_chart_btn)

        self._pause_btn = QPushButton("暂停显示 / Pause")
        self._pause_btn.setCheckable(True)
        self._pause_btn.clicked.connect(self._on_pause_display)
        chart_btn_row.addWidget(self._pause_btn)

        save_chart_btn = QPushButton("保存图表 / Save Chart")
        save_chart_btn.clicked.connect(self._on_save_chart)
        chart_btn_row.addWidget(save_chart_btn)

        chart_btn_row.addStretch()
        chart_layout.addLayout(chart_btn_row)

        # ── 实时数据表格 ──
        table_grp = QGroupBox("实时数据表格 / Live Data Table")
        tv = QVBoxLayout(table_grp)

        columns = self._get_table_columns(self._device_model)
        self._live_table_model.set_columns(columns)
        self._data_table = QTableView()
        self._data_table.setModel(self._live_table_model)
        self._data_table.horizontalHeader().setStretchLastSection(True)
        self._data_table.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self._data_table.setMinimumHeight(360)
        self._data_table.setVerticalScrollBarPolicy(Qt.ScrollBarAlwaysOn)
        self._data_table.setHorizontalScrollBarPolicy(Qt.ScrollBarAsNeeded)
        self._data_table.setAlternatingRowColors(True)
        self._data_table.setSelectionBehavior(QAbstractItemView.SelectRows)
        tv.addWidget(self._data_table)

        table_ctrl = QHBoxLayout()
        self._table_max_rows_spin = QSpinBox()
        self._table_max_rows_spin.setRange(100, 5000)
        self._table_max_rows_spin.setValue(1000)
        self._table_max_rows_spin.setSuffix(" 行")
        self._table_max_rows_spin.setToolTip("表格最大保留行数")
        table_ctrl.addWidget(QLabel("最大行数:"))
        table_ctrl.addWidget(self._table_max_rows_spin)

        clear_table_btn = QPushButton("清空表格 / Clear Table")
        clear_table_btn.clicked.connect(self._on_clear_data_table)
        table_ctrl.addWidget(clear_table_btn)
        table_ctrl.addStretch()
        tv.addLayout(table_ctrl)

        table_layout.addWidget(table_grp)
        table_layout.addStretch()

        # ── 数据记录组 (可折叠) ──
        rec_grp = QGroupBox("数据记录 / Recording")
        rv = QVBoxLayout(rec_grp)

        # 保存目录选择
        dir_row = QHBoxLayout()
        dir_row.addWidget(QLabel("目录 / Directory:"))
        self._save_dir_edit = QLineEdit(
            self._cfg.get("acquisition", {}).get("save_dir", "./experiments")
        )
        dir_row.addWidget(self._save_dir_edit)
        browse_btn = QPushButton("浏览 / Browse")
        browse_btn.clicked.connect(self._on_browse_save_dir)
        dir_row.addWidget(browse_btn)
        rv.addLayout(dir_row)

        # 文件轮转配置
        rollover_row = QHBoxLayout()
        rollover_row.addWidget(QLabel("文件大小上限 / Max Size:"))
        self._max_size_spin = QSpinBox()
        self._max_size_spin.setRange(10, 1000)
        self._max_size_spin.setSuffix(" MB")
        self._max_size_spin.setValue(
            self._cfg.get("acquisition", {}).get("max_file_size_mb", 100)
        )
        rollover_row.addWidget(self._max_size_spin)

        rollover_row.addWidget(QLabel("行数上限 / Max Rows:"))
        self._max_rows_spin = QSpinBox()
        self._max_rows_spin.setRange(1000, 1000000)
        self._max_rows_spin.setSuffix(" 行")
        self._max_rows_spin.setValue(
            self._cfg.get("acquisition", {}).get("max_file_rows", 100000)
        )
        rollover_row.addWidget(self._max_rows_spin)

        rollover_row.addWidget(QLabel("超限策略 / Strategy:"))
        self._strategy_combo = QComboBox()
        self._strategy_combo.addItems(["new_file", "stop"])
        self._strategy_combo.setCurrentText(
            self._cfg.get("acquisition", {}).get("rollover_strategy", "new_file")
        )
        rollover_row.addWidget(self._strategy_combo)

        rollover_row.addStretch()
        rv.addLayout(rollover_row)

        # 记录控制按钮
        rec_ctrl_row = QHBoxLayout()
        self._rec_start_btn = QPushButton("开始记录 / Start Recording")
        self._rec_start_btn.setObjectName("successBtn")
        self._rec_start_btn.clicked.connect(self._on_start_recording)
        self._rec_start_btn.setEnabled(False)
        rec_ctrl_row.addWidget(self._rec_start_btn)

        self._rec_stop_btn = QPushButton("停止记录 / Stop Recording")
        self._rec_stop_btn.setObjectName("dangerBtn")
        self._rec_stop_btn.clicked.connect(self._on_stop_recording)
        self._rec_stop_btn.setEnabled(False)
        rec_ctrl_row.addWidget(self._rec_stop_btn)

        rec_ctrl_row.addSpacing(16)

        export_excel_btn = QPushButton("导出 Excel / Export Excel")
        export_excel_btn.clicked.connect(self._on_export_excel)
        rec_ctrl_row.addWidget(export_excel_btn)

        export_txt_btn = QPushButton("导出 TXT / Export TXT")
        export_txt_btn.clicked.connect(self._on_export_txt)
        rec_ctrl_row.addWidget(export_txt_btn)

        rec_ctrl_row.addStretch()
        rv.addLayout(rec_ctrl_row)

        # 记录统计
        self._rec_stats_label = QLabel("未记录 / Not Recording")
        rv.addWidget(self._rec_stats_label)

        recording_layout.addWidget(rec_grp)
        recording_layout.addStretch()

        return page

    # ==================================================================
    # 页面 3: 数据回看
    # ==================================================================

    def _build_review_page(self) -> QWidget:
        page = QWidget()
        layout = QVBoxLayout(page)
        layout.setContentsMargins(16, 16, 16, 16)

        title = QLabel("数据回看 / Data Review")
        title.setObjectName("sectionTitle")
        layout.addWidget(title)

        self._review_main_tabs = QTabWidget()
        source_page = QWidget()
        source_tab_layout = QVBoxLayout(source_page)
        source_tab_layout.setContentsMargins(8, 8, 8, 8)
        source_tab_layout.setSpacing(8)
        filter_page = QWidget()
        filter_tab_layout = QVBoxLayout(filter_page)
        filter_tab_layout.setContentsMargins(8, 8, 8, 8)
        filter_tab_layout.setSpacing(8)
        plot_page = QWidget()
        plot_tab_layout = QVBoxLayout(plot_page)
        plot_tab_layout.setContentsMargins(8, 8, 8, 8)
        plot_tab_layout.setSpacing(8)
        table_page = QWidget()
        table_tab_layout = QVBoxLayout(table_page)
        table_tab_layout.setContentsMargins(8, 8, 8, 8)
        table_tab_layout.setSpacing(8)
        self._review_main_tabs.addTab(source_page, "数据源 / Source")
        self._review_main_tabs.addTab(filter_page, "筛选统计 / Filter && Stats")
        self._review_main_tabs.addTab(plot_page, "图表 / Plots")
        self._review_main_tabs.addTab(table_page, "数据表 / Table")
        layout.addWidget(self._review_main_tabs, 1)

        # 文件选择区
        file_grp = QGroupBox("文件选择 / File Selection")
        file_layout = QHBoxLayout(file_grp)
        self._review_select_btn = QPushButton("选择文件 / Select Files")
        self._review_select_btn.clicked.connect(self._on_select_review_files)
        file_layout.addWidget(self._review_select_btn)

        self._review_file_info = QLabel("未选择文件 / No files selected")
        file_layout.addWidget(self._review_file_info)
        file_layout.addStretch()

        self._review_append_btn = QPushButton("追加文件 / Append Files")
        self._review_append_btn.clicked.connect(self._on_append_review_files)
        file_layout.addWidget(self._review_append_btn)

        self._review_clear_btn = QPushButton("清空 / Clear")
        self._review_clear_btn.setObjectName("dangerBtn")
        self._review_clear_btn.clicked.connect(self._on_clear_review)
        file_layout.addWidget(self._review_clear_btn)

        source_tab_layout.addWidget(file_grp)

        # 数据库查询区
        db_grp = QGroupBox("数据库查询 / SQLite Query")
        db_layout = QHBoxLayout(db_grp)
        db_layout.addWidget(QLabel("Session ID:"))
        self._review_db_session_spin = QSpinBox()
        self._review_db_session_spin.setRange(0, 2_000_000_000)
        self._review_db_session_spin.setToolTip("0 表示查询全部 session")
        db_layout.addWidget(self._review_db_session_spin)

        db_layout.addWidget(QLabel("Source:"))
        self._review_db_source_combo = QComboBox()
        self._review_db_source_combo.addItems(["all", "realtime", "import_csv", "import_txt", "device_memory"])
        self._review_db_source_combo.setCurrentText(
            self._cfg.get("review", {}).get("default_source", "all")
        )
        db_layout.addWidget(self._review_db_source_combo)

        self._review_load_db_btn = QPushButton("载入数据库 / Load DB")
        self._review_load_db_btn.clicked.connect(self._on_load_review_from_database)
        db_layout.addWidget(self._review_load_db_btn)
        db_layout.addStretch()
        source_tab_layout.addWidget(db_grp)
        source_tab_layout.addStretch()

        # 选区与坐标控制
        filter_grp = QGroupBox("筛选与坐标 / Filters && Axes")
        filter_grid = QGridLayout(filter_grp)
        filter_grid.setHorizontalSpacing(12)
        filter_grid.setVerticalSpacing(8)

        self._review_seq_start_spin = QSpinBox()
        self._review_seq_start_spin.setRange(0, 2_000_000_000)
        self._review_seq_start_spin.setToolTip("0 表示不限制起始序号")
        self._review_seq_end_spin = QSpinBox()
        self._review_seq_end_spin.setRange(0, 2_000_000_000)
        self._review_seq_end_spin.setToolTip("0 表示不限制截止序号")
        self._review_time_start_edit = QLineEdit()
        self._review_time_start_edit.setPlaceholderText("相对秒，可空")
        self._review_time_start_edit.setMinimumWidth(150)
        self._review_time_end_edit = QLineEdit()
        self._review_time_end_edit.setPlaceholderText("相对秒，可空")
        self._review_time_end_edit.setMinimumWidth(150)

        filter_grid.addWidget(QLabel("起始序号 / Seq From:"), 0, 0)
        filter_grid.addWidget(self._review_seq_start_spin, 0, 1)
        filter_grid.addWidget(QLabel("截止序号 / Seq To:"), 0, 2)
        filter_grid.addWidget(self._review_seq_end_spin, 0, 3)
        filter_grid.addWidget(QLabel("起始时间 / Time From:"), 1, 0)
        filter_grid.addWidget(self._review_time_start_edit, 1, 1)
        filter_grid.addWidget(QLabel("截止时间 / Time To:"), 1, 2)
        filter_grid.addWidget(self._review_time_end_edit, 1, 3)

        self._review_apply_filter_btn = QPushButton("应用筛选 / Apply Filter")
        self._review_apply_filter_btn.setToolTip("按当前序号和时间范围筛选数据，并刷新图表、统计和表格")
        self._review_apply_filter_btn.clicked.connect(self._apply_review_filter)

        self._review_reset_filter_btn = QPushButton("重置筛选 / Reset Filter")
        self._review_reset_filter_btn.setToolTip("清空筛选条件，恢复显示完整数据集")
        self._review_reset_filter_btn.clicked.connect(self._reset_review_filter_controls)

        self._review_auto_axis_cb = QCheckBox("自动坐标 / Auto Axes")
        self._review_auto_axis_cb.setChecked(
            not self._cfg.get("review", {}).get("manual_axis_enabled", False)
        )
        self._review_auto_axis_cb.toggled.connect(self._update_review_plot)
        filter_grid.addWidget(self._review_auto_axis_cb, 2, 0, 1, 2)

        self._review_x_min_edit = QLineEdit(str(self._cfg.get("review", {}).get("x_min_s", 0.0)))
        self._review_x_min_edit.setMinimumWidth(110)
        self._review_x_max_edit = QLineEdit(str(self._cfg.get("review", {}).get("x_max_s", 60.0)))
        self._review_x_max_edit.setMinimumWidth(110)
        self._review_y_min_edit = QLineEdit(str(self._cfg.get("review", {}).get("y_min", -1.0)))
        self._review_y_min_edit.setMinimumWidth(110)
        self._review_y_max_edit = QLineEdit(str(self._cfg.get("review", {}).get("y_max", 1.0)))
        self._review_y_max_edit.setMinimumWidth(110)
        for edit in (self._review_x_min_edit, self._review_x_max_edit, self._review_y_min_edit, self._review_y_max_edit):
            edit.editingFinished.connect(self._update_review_plot)

        filter_grid.addWidget(QLabel("X 范围 / X Range:"), 2, 2)
        filter_grid.addWidget(self._review_x_min_edit, 2, 3)
        filter_grid.addWidget(self._review_x_max_edit, 2, 4)
        filter_grid.addWidget(QLabel("Y 范围 / Y Range:"), 3, 2)
        filter_grid.addWidget(self._review_y_min_edit, 3, 3)
        filter_grid.addWidget(self._review_y_max_edit, 3, 4)

        save_view_btn = QPushButton("保存坐标 / Save Axes")
        save_view_btn.setToolTip("保存当前手动 X/Y 坐标范围到配置，下次启动继续使用")
        save_view_btn.clicked.connect(self._save_review_view_preset)

        export_sel_btn = QPushButton("导出选区 CSV / Export Selection")
        export_sel_btn.setToolTip("导出当前筛选后的回看数据到 CSV 文件")
        export_sel_btn.clicked.connect(self._on_export_review_selection)

        report_btn = QPushButton("HTML 报告 / HTML Report")
        report_btn.setToolTip("基于当前筛选后的回看数据生成 HTML 报告")
        report_btn.clicked.connect(self._on_export_review_report)

        filter_actions = QHBoxLayout()
        for btn in (
            self._review_apply_filter_btn,
            self._review_reset_filter_btn,
            save_view_btn,
            export_sel_btn,
            report_btn,
        ):
            btn.setMinimumWidth(145)
            filter_actions.addWidget(btn)
        filter_actions.addStretch()
        filter_grid.addLayout(filter_actions, 4, 0, 1, 5)
        for col in (1, 3, 4):
            filter_grid.setColumnStretch(col, 1)

        filter_tab_layout.addWidget(filter_grp)

        # 统计信息区
        stats_grp = QGroupBox("统计信息 / Statistics")
        stats_layout = QGridLayout(stats_grp)
        stats_layout.setHorizontalSpacing(16)
        stats_layout.setVerticalSpacing(8)

        self._review_stat_count = QLabel("--")
        self._review_stat_duration = QLabel("--")
        self._review_stat_min = QLabel("--")
        self._review_stat_max = QLabel("--")
        self._review_stat_mean = QLabel("--")
        self._review_stat_rms = QLabel("--")
        self._review_stat_std = QLabel("--")
        self._review_stat_pkpk = QLabel("--")
        self._review_stat_sample_rate = QLabel("--")
        for value_label in (
            self._review_stat_count,
            self._review_stat_duration,
            self._review_stat_min,
            self._review_stat_max,
            self._review_stat_mean,
            self._review_stat_rms,
            self._review_stat_std,
            self._review_stat_pkpk,
            self._review_stat_sample_rate,
        ):
            value_label.setMinimumWidth(160)
            value_label.setTextInteractionFlags(Qt.TextSelectableByMouse)

        stats_layout.addWidget(QLabel("数据点数 / Count:"), 0, 0)
        stats_layout.addWidget(self._review_stat_count, 0, 1)
        stats_layout.addWidget(QLabel("时长 / Duration:"), 0, 2)
        stats_layout.addWidget(self._review_stat_duration, 0, 3)

        stats_layout.addWidget(QLabel("磁场最小值 / Field Min:"), 1, 0)
        stats_layout.addWidget(self._review_stat_min, 1, 1)
        stats_layout.addWidget(QLabel("磁场最大值 / Field Max:"), 1, 2)
        stats_layout.addWidget(self._review_stat_max, 1, 3)

        stats_layout.addWidget(QLabel("磁场平均值 / Field Mean:"), 2, 0)
        stats_layout.addWidget(self._review_stat_mean, 2, 1)
        stats_layout.addWidget(QLabel("RMS / Std:"), 2, 2)
        stats_layout.addWidget(self._review_stat_rms, 2, 3)
        stats_layout.addWidget(QLabel("Pk-Pk / Sample Rate:"), 3, 0)
        stats_layout.addWidget(self._review_stat_pkpk, 3, 1)
        stats_layout.addWidget(self._review_stat_sample_rate, 3, 3)

        self._review_stat_channels = QLabel("")
        self._review_stat_channels.setWordWrap(True)
        self._review_stat_channels.setStyleSheet("font-size: 11px; color: #555;")
        stats_layout.addWidget(self._review_stat_channels, 4, 0, 1, 4)

        stats_layout.setColumnStretch(1, 1)
        stats_layout.setColumnStretch(3, 1)
        filter_tab_layout.addWidget(stats_grp)
        filter_tab_layout.addStretch()

        # 图表区
        if _HAS_PYG:
            self._review_plot_tabs = QTabWidget()
            self._review_plot_tabs.setMinimumHeight(460)
            time_plot_page = QWidget()
            time_plot_layout = QVBoxLayout(time_plot_page)
            time_plot_layout.setContentsMargins(0, 0, 0, 0)

            self._review_plot_widget = pg.PlotWidget()
            self._review_plot_widget.setLabel("left", "磁场", units="mT")
            self._review_plot_widget.setLabel("bottom", "时间", units="s")
            self._review_plot_widget.showGrid(x=True, y=True, alpha=0.3)
            self._review_plot_widget.setMinimumHeight(420)

            self._review_field_curve = self._review_plot_widget.plot(
                pen=pg.mkPen("#0080c8", width=1.5), name="磁场/mT"
            )

            # 右侧Y轴用于频率
            plot_item = self._review_plot_widget.getPlotItem()
            self._review_freq_axis = pg.AxisItem("right")
            plot_item.layout.addItem(self._review_freq_axis, 2, 3)
            self._review_freq_vb = pg.ViewBox()
            plot_item.scene().addItem(self._review_freq_vb)
            self._review_freq_axis.linkToView(self._review_freq_vb)
            self._review_freq_vb.setXLink(plot_item)

            self._review_freq_curve = pg.PlotCurveItem(
                pen=pg.mkPen("#00a651", width=1.0), name="频率/Hz"
            )
            self._review_freq_vb.addItem(self._review_freq_curve)
            self._review_region = pg.LinearRegionItem()
            self._review_region.setZValue(-10)
            self._review_region.sigRegionChangeFinished.connect(self._on_review_region_changed)
            self._review_plot_widget.addItem(self._review_region)
            self._review_mean_line = pg.InfiniteLine(
                pos=0, angle=0, pen=pg.mkPen("#ffaa00", width=1, style=Qt.DashLine)
            )
            self._review_plot_widget.addItem(self._review_mean_line)
            self._review_cursor_a = pg.InfiniteLine(pos=0.0, angle=90, movable=True, pen=pg.mkPen("#f0a000", width=1))
            self._review_cursor_b = pg.InfiniteLine(pos=1.0, angle=90, movable=True, pen=pg.mkPen("#f0a000", width=1))
            self._review_cursor_a.sigPositionChanged.connect(self._update_review_cursor_readout)
            self._review_cursor_b.sigPositionChanged.connect(self._update_review_cursor_readout)
            self._review_cursor_a.setVisible(False)
            self._review_cursor_b.setVisible(False)
            self._review_plot_widget.addItem(self._review_cursor_a)
            self._review_plot_widget.addItem(self._review_cursor_b)
            self._review_cursor_label = pg.TextItem("", color="#f0a000", anchor=(0, 1))
            self._review_cursor_label.setVisible(False)
            self._review_plot_widget.addItem(self._review_cursor_label)
            self._review_peak_labels = []

            def _update_review_freq_view():
                self._review_freq_vb.setGeometry(plot_item.vb.sceneBoundingRect())
                self._review_freq_vb.linkedViewChanged(plot_item.vb, self._review_freq_vb.XAxis)

            plot_item.vb.sigResized.connect(_update_review_freq_view)

            time_plot_layout.addWidget(self._review_plot_widget)
            self._review_plot_tabs.addTab(time_plot_page, "时间曲线 / Time")

            spectrum_page = QWidget()
            spectrum_layout = QVBoxLayout(spectrum_page)
            spectrum_layout.setContentsMargins(0, 0, 0, 0)
            self._review_spectrum_status = QLabel("载入数据后显示频谱")
            self._review_spectrum_status.setStyleSheet("color: #555; padding: 4px;")
            spectrum_layout.addWidget(self._review_spectrum_status)
            self._review_spectrum_widget = pg.PlotWidget()
            self._review_spectrum_widget.setLabel("bottom", "频率", units="Hz")
            self._review_spectrum_widget.setLabel("left", "幅值")
            self._review_spectrum_widget.showGrid(x=True, y=True, alpha=0.25)
            self._review_spectrum_curve = self._review_spectrum_widget.plot(
                pen=pg.mkPen("#0080c8", width=1.2), name="Spectrum"
            )
            spectrum_layout.addWidget(self._review_spectrum_widget, 1)
            self._review_plot_tabs.addTab(spectrum_page, "频谱 / Spectrum")

            heatmap_page = QWidget()
            heatmap_layout = QVBoxLayout(heatmap_page)
            heatmap_layout.setContentsMargins(0, 0, 0, 0)
            heatmap_ctrl = QGridLayout()
            heatmap_ctrl.setHorizontalSpacing(10)
            heatmap_ctrl.setVerticalSpacing(6)
            heatmap_ctrl.addWidget(QLabel("值 / Value:"), 0, 0)
            self._review_heatmap_channel_combo = QComboBox()
            self._review_heatmap_channel_combo.currentTextChanged.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(self._review_heatmap_channel_combo, 0, 1)
            heatmap_ctrl.addWidget(QLabel("网格 / Grid:"), 0, 2)
            self._review_heatmap_mode_combo = QComboBox()
            self._review_heatmap_mode_combo.addItem("原始网格 / Raw", "raw")
            self._review_heatmap_mode_combo.addItem("插值网格 / Interpolated", "interpolated")
            self._review_heatmap_mode_combo.currentTextChanged.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(self._review_heatmap_mode_combo, 0, 3)
            heatmap_ctrl.addWidget(QLabel("分辨率 / Resolution:"), 0, 4)
            self._review_heatmap_resolution_spin = QSpinBox()
            self._review_heatmap_resolution_spin.setRange(10, 300)
            self._review_heatmap_resolution_spin.setValue(80)
            self._review_heatmap_resolution_spin.valueChanged.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(self._review_heatmap_resolution_spin, 0, 5)
            self._review_heatmap_auto_levels_cb = QCheckBox("自动色阶 / Auto Levels")
            self._review_heatmap_auto_levels_cb.setChecked(True)
            self._review_heatmap_auto_levels_cb.toggled.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(self._review_heatmap_auto_levels_cb, 0, 6)
            self._review_heatmap_min_edit = QLineEdit()
            self._review_heatmap_min_edit.setPlaceholderText("min")
            self._review_heatmap_min_edit.setMinimumWidth(100)
            self._review_heatmap_min_edit.editingFinished.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(QLabel("最小 / Min:"), 1, 0)
            heatmap_ctrl.addWidget(self._review_heatmap_min_edit, 1, 1)
            self._review_heatmap_max_edit = QLineEdit()
            self._review_heatmap_max_edit.setPlaceholderText("max")
            self._review_heatmap_max_edit.setMinimumWidth(100)
            self._review_heatmap_max_edit.editingFinished.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(QLabel("最大 / Max:"), 1, 2)
            heatmap_ctrl.addWidget(self._review_heatmap_max_edit, 1, 3)
            self._review_heatmap_contour_cb = QCheckBox("等值线 / Contour")
            self._review_heatmap_contour_cb.toggled.connect(self._update_review_plot)
            heatmap_ctrl.addWidget(self._review_heatmap_contour_cb, 1, 4)
            self._review_heatmap_export_btn = QPushButton("导出 PNG / Export PNG")
            self._review_heatmap_export_btn.clicked.connect(self._on_export_review_heatmap_image)
            heatmap_ctrl.addWidget(self._review_heatmap_export_btn, 1, 5)
            heatmap_ctrl.setColumnStretch(6, 1)
            heatmap_layout.addLayout(heatmap_ctrl)
            self._review_heatmap_status = QLabel("载入包含 x_mm/y_mm 的数据后显示空间热图")
            self._review_heatmap_status.setStyleSheet("color: #555; padding: 4px;")
            heatmap_layout.addWidget(self._review_heatmap_status)
            heatmap_plot_row = QHBoxLayout()
            self._review_heatmap_widget = pg.PlotWidget()
            self._review_heatmap_widget.setLabel("bottom", "X", units="mm")
            self._review_heatmap_widget.setLabel("left", "Y", units="mm")
            self._review_heatmap_widget.showGrid(x=True, y=True, alpha=0.25)
            self._review_heatmap_widget.setMinimumHeight(420)
            self._review_heatmap_item = pg.ImageItem()
            self._review_heatmap_contours = []
            try:
                cmap = pg.colormap.get("viridis")
                self._review_heatmap_item.setLookupTable(cmap.getLookupTable(0.0, 1.0, 256))
            except Exception:
                pass
            self._review_heatmap_widget.addItem(self._review_heatmap_item)
            heatmap_plot_row.addWidget(self._review_heatmap_widget, 1)
            self._review_heatmap_lut = pg.HistogramLUTWidget()
            self._review_heatmap_lut.setImageItem(self._review_heatmap_item)
            self._review_heatmap_lut.setMaximumWidth(110)
            heatmap_plot_row.addWidget(self._review_heatmap_lut)
            heatmap_layout.addLayout(heatmap_plot_row)
            self._review_plot_tabs.addTab(heatmap_page, "空间热图 / Heatmap")

            surface_page = QWidget()
            surface_layout = QVBoxLayout(surface_page)
            surface_layout.setContentsMargins(0, 0, 0, 0)
            surface_ctrl = QHBoxLayout()
            self._review_surface_reset_btn = QPushButton("Reset View")
            self._review_surface_reset_btn.clicked.connect(self._reset_review_surface_view)
            surface_ctrl.addWidget(self._review_surface_reset_btn)
            self._review_surface_export_btn = QPushButton("Export 3D PNG")
            self._review_surface_export_btn.clicked.connect(self._on_export_review_surface_image)
            surface_ctrl.addWidget(self._review_surface_export_btn)
            surface_ctrl.addStretch()
            surface_layout.addLayout(surface_ctrl)
            self._review_surface_status = QLabel(
                "Load x_mm/y_mm data and install PyOpenGL to show 3D surface"
            )
            self._review_surface_status.setStyleSheet("color: #555; padding: 4px;")
            surface_layout.addWidget(self._review_surface_status)
            self._review_surface_widget = None
            self._review_surface_item = None
            self._review_surface_renderer = None
            surface_error = ""
            if SurfaceRenderer.is_available():
                try:
                    self._review_surface_renderer = SurfaceRenderer()
                    self._review_surface_widget = self._review_surface_renderer.widget
                    surface_layout.addWidget(self._review_surface_widget, 1)
                except Exception as exc:
                    self._review_surface_widget = None
                    self._review_surface_renderer = None
                    surface_error = f" OpenGL init failed: {exc}"
            if self._review_surface_widget is None:
                self._review_surface_export_btn.setEnabled(False)
                self._review_surface_reset_btn.setEnabled(False)
                missing = QLabel(
                    "3D Surface requires optional PyOpenGL and a working OpenGL driver."
                    " Other review plots remain available." + surface_error
                )
                missing.setAlignment(Qt.AlignCenter)
                missing.setMinimumHeight(420)
                surface_layout.addWidget(missing, 1)
            self._review_plot_tabs.addTab(surface_page, "3D Surface")
            self._review_plot_tabs.currentChanged.connect(self._on_review_plot_tab_changed)

            plot_tab_layout.addWidget(self._review_plot_tabs, 1)
        else:
            self._review_plot_widget = None
            self._review_region = None
            self._review_mean_line = None
            self._review_cursor_a = None
            self._review_cursor_b = None
            self._review_cursor_label = None
            self._review_peak_labels = []
            self._review_spectrum_status = None
            self._review_spectrum_widget = None
            self._review_spectrum_curve = None
            self._review_heatmap_widget = None
            self._review_heatmap_item = None
            self._review_heatmap_lut = None
            self._review_heatmap_status = None
            self._review_heatmap_channel_combo = None
            self._review_heatmap_auto_levels_cb = None
            self._review_heatmap_min_edit = None
            self._review_heatmap_max_edit = None
            self._review_heatmap_contour_cb = None
            self._review_heatmap_mode_combo = None
            self._review_heatmap_resolution_spin = None
            self._review_heatmap_export_btn = None
            self._review_heatmap_contours = []
            self._review_surface_status = None
            self._review_surface_widget = None
            self._review_surface_item = None
            self._review_surface_renderer = None
            self._review_surface_reset_btn = None
            self._review_surface_export_btn = None
            no_plot = QLabel("pyqtgraph 未安装, 图表不可用 / pyqtgraph not installed")
            no_plot.setAlignment(Qt.AlignCenter)
            plot_tab_layout.addWidget(no_plot, 1)

        self._review_table = QTableWidget()
        self._review_table.setColumnCount(6)
        self._review_table.setHorizontalHeaderLabels(["Seq", "Time(s)", "Field", "Freq", "Temp", "Source"])
        self._review_table.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self._review_table.setSelectionBehavior(QAbstractItemView.SelectRows)
        self._review_table.setSelectionMode(QAbstractItemView.ExtendedSelection)
        self._review_table.setMinimumHeight(220)
        self._review_table.setVerticalScrollBarPolicy(Qt.ScrollBarAlwaysOn)
        self._review_table.setHorizontalScrollBarPolicy(Qt.ScrollBarAsNeeded)
        self._review_table.setAlternatingRowColors(True)
        self._review_table.itemSelectionChanged.connect(self._on_review_table_selection_changed)
        table_tab_layout.addWidget(self._review_table, 1)

        # 控制区
        ctrl_row = QHBoxLayout()
        self._review_show_freq_cb = QCheckBox("显示频率曲线 / Show Frequency")
        self._review_show_freq_cb.toggled.connect(self._update_review_plot)
        ctrl_row.addWidget(self._review_show_freq_cb)
        self._review_cursor_cb = QCheckBox("游标 / Cursors")
        self._review_cursor_cb.toggled.connect(self._on_toggle_review_cursors)
        ctrl_row.addWidget(self._review_cursor_cb)
        self._review_peaks_cb = QCheckBox("峰谷标注 / Peaks")
        self._review_peaks_cb.toggled.connect(lambda _checked: self._update_review_peak_markers())
        ctrl_row.addWidget(self._review_peaks_cb)
        ctrl_row.addStretch()
        plot_tab_layout.addLayout(ctrl_row)

        return page

    def _active_review_data(self) -> Optional[np.ndarray]:
        if self._review_filtered_data is not None:
            return self._review_filtered_data
        return self._review_data

    def _set_review_data(self, data: np.ndarray, *, files: Optional[List[Path]] = None) -> None:
        self._review_data = data
        self._review_filtered_data = None
        if files is not None:
            self._review_file_paths = list(dict.fromkeys(files))
            self._update_review_file_info()
        self._reset_review_filter_controls(update=False)
        self._update_review_heatmap_channel_options(data)
        self._update_review_plot()
        self._update_review_stats()
        self._update_review_table()

    def _parse_optional_float(self, edit: QLineEdit) -> Optional[float]:
        text = edit.text().strip()
        if not text:
            return None
        try:
            return float(text)
        except ValueError:
            return None

    def _reset_review_filter_controls(self, *args, update: bool = True) -> None:
        self._review_seq_start_spin.setValue(0)
        self._review_seq_end_spin.setValue(0)
        self._review_time_start_edit.clear()
        self._review_time_end_edit.clear()
        if update:
            self._reset_review_filter()

    def _update_review_file_info(self) -> None:
        count = len(self._review_file_paths)
        total_size = 0
        for p in self._review_file_paths:
            try:
                total_size += p.stat().st_size
            except OSError:
                pass
        if total_size < 1024:
            size_str = f"{total_size} B"
        elif total_size < 1024 * 1024:
            size_str = f"{total_size / 1024:.1f} KB"
        else:
            size_str = f"{total_size / (1024 * 1024):.1f} MB"
        self._review_file_info.setText(f"{count} 个文件 / {size_str}")

    def _on_select_review_files(self) -> None:
        files, _ = QFileDialog.getOpenFileNames(
            self, "选择数据文件 / Select Data Files", "",
            "数据文件 (*.csv *.txt);;所有文件 (*.*)"
        )
        if not files:
            return
        paths = [Path(f) for f in files]
        data, ok_count = load_review_files(paths)
        if ok_count == 0:
            QMessageBox.warning(self, "加载失败", "未能成功加载任何文件。\nNo file loaded successfully.")
            return
        self._set_review_data(data, files=paths)
        self.log(f"[GUI] 数据回看: 已加载 {ok_count} 个文件, {len(data)} 个点")

    def _on_append_review_files(self) -> None:
        files, _ = QFileDialog.getOpenFileNames(
            self, "追加数据文件 / Append Data Files", "",
            "数据文件 (*.csv *.txt);;所有文件 (*.*)"
        )
        if not files:
            return
        paths = [Path(f) for f in files]
        new_data, ok_count = load_review_files(paths)
        if ok_count == 0:
            QMessageBox.warning(self, "加载失败", "未能成功加载任何文件。\nNo file loaded successfully.")
            return
        if self._review_data is not None and len(self._review_data) > 0:
            self._review_data = merge_review_arrays([self._review_data, new_data])
            self._review_filtered_data = None
        else:
            self._review_data = new_data
        self._review_file_paths = list(dict.fromkeys(self._review_file_paths + paths))
        self._update_review_file_info()
        self._update_review_heatmap_channel_options(self._review_data)
        self._update_review_plot()
        self._update_review_stats()
        self._update_review_table()
        self.log(f"[GUI] 数据回看: 已追加 {ok_count} 个文件, 当前共 {len(self._review_data)} 个点")

    def _on_clear_review(self) -> None:
        self._review_data = None
        self._review_filtered_data = None
        self._review_file_paths = []
        self._review_file_info.setText("未选择文件 / No files selected")
        if _HAS_PYG and self._review_plot_widget is not None:
            self._review_field_curve.clear()
            self._review_freq_curve.clear()
            self._update_review_heatmap_channel_options(None)
            self._update_review_heatmap(None)
            self._update_review_surface(None)
        self._update_review_stats()
        self._update_review_table()
        self.log("[GUI] 数据回看: 已清空")

    def _on_load_review_from_database(self) -> None:
        if self._db_store is None:
            QMessageBox.warning(self, "数据库不可用", "SQLite 数据库尚未初始化。")
            return
        session_id = self._review_db_session_spin.value() or None
        source = self._review_db_source_combo.currentText()
        try:
            data = self._db_store.query_samples(session_id=session_id, source=source)
        except Exception as exc:
            QMessageBox.critical(self, "数据库查询失败", str(exc))
            self.log(f"[DB] 查询失败: {exc}")
            return
        if len(data) == 0:
            QMessageBox.information(self, "无数据", "没有匹配的数据库样本。")
            return
        self._set_review_data(data, files=[])
        self._review_file_info.setText(f"SQLite 查询 / {len(data):,} 点")
        self.log(f"[DB] 已载入 {len(data)} 个数据库样本")

    def _apply_review_filter(self) -> None:
        if self._review_data is None or len(self._review_data) == 0:
            return
        seq_start = self._review_seq_start_spin.value() or None
        seq_end = self._review_seq_end_spin.value() or None
        time_start = self._parse_optional_float(self._review_time_start_edit)
        time_end = self._parse_optional_float(self._review_time_end_edit)
        source = self._review_db_source_combo.currentText()
        session_id = self._review_db_session_spin.value() or None
        self._review_filtered_data = filter_review_data(
            self._review_data,
            sequence_start=seq_start,
            sequence_end=seq_end,
            time_start_s=time_start,
            time_end_s=time_end,
            source=source,
            session_id=session_id,
        )
        self._update_review_plot()
        self._update_review_stats()
        self._update_review_table()

    def _reset_review_filter(self) -> None:
        self._review_filtered_data = None
        self._update_review_plot()
        self._update_review_stats()
        self._update_review_table()

    def _update_review_plot(self, *_args) -> None:
        if not _HAS_PYG or self._review_plot_widget is None:
            return
        data = self._active_review_data()
        if data is None or len(data) == 0:
            self._review_field_curve.clear()
            self._review_freq_curve.clear()
            if self._review_spectrum_curve is not None:
                self._review_spectrum_curve.clear()
            if self._review_spectrum_status is not None:
                self._review_spectrum_status.setText("载入数据后显示频谱")
            self._update_review_heatmap(None)
            self._update_review_surface(None)
            return

        active_tab = self._review_plot_tabs.currentIndex() if hasattr(self, "_review_plot_tabs") else 0
        if active_tab == 1:
            self._update_review_spectrum(data)
        elif active_tab == 2:
            self._update_review_heatmap(data)
        elif active_tab == 3:
            self._update_review_surface(data)
        else:
            self._update_review_time_plot(data)

    def _on_review_plot_tab_changed(self, _index: int) -> None:
        self._update_review_plot()

    def _update_review_time_plot(self, data: np.ndarray) -> None:
        if self._review_plot_widget is None:
            return

        ts = data["timestamp_s"]
        ts_rel = ts - ts[0]
        field_key = primary_field_name(data)
        self._review_field_curve.setData(ts_rel, data[field_key])
        values = np.asarray(data[field_key], dtype=float)
        self._review_cursor_data = (np.asarray(ts_rel, dtype=float), values)
        finite = values[np.isfinite(values)]
        if finite.size and self._review_mean_line is not None:
            self._review_mean_line.setPos(float(np.mean(finite)))

        if self._review_show_freq_cb.isChecked() and "freq_hz" in (data.dtype.names or ()):
            self._review_freq_curve.setData(ts_rel, data["freq_hz"])
            self._review_freq_axis.setVisible(True)
            freq = data["freq_hz"]
            if len(freq) > 0:
                margin = max(abs(freq.min()), abs(freq.max())) * 0.1 + 1e-6
                self._review_freq_vb.setYRange(freq.min() - margin, freq.max() + margin, padding=0)
        else:
            self._review_freq_curve.clear()
            self._review_freq_axis.setVisible(False)

        if self._review_region is not None and len(ts_rel) > 0:
            self._review_region.blockSignals(True)
            self._review_region.setRegion((float(ts_rel[0]), float(ts_rel[-1])))
            self._review_region.blockSignals(False)
            if self._review_cursor_a is not None and self._review_cursor_b is not None:
                self._review_cursor_a.blockSignals(True)
                self._review_cursor_b.blockSignals(True)
                self._review_cursor_a.setPos(float(ts_rel[0]))
                self._review_cursor_b.setPos(float(ts_rel[-1]))
                self._review_cursor_a.blockSignals(False)
                self._review_cursor_b.blockSignals(False)
        self._update_review_cursor_readout()
        self._update_review_peak_markers()

        if self._review_auto_axis_cb.isChecked():
            self._review_plot_widget.autoRange()
        else:
            try:
                x_min = float(self._review_x_min_edit.text())
                x_max = float(self._review_x_max_edit.text())
                y_min = float(self._review_y_min_edit.text())
                y_max = float(self._review_y_max_edit.text())
                if x_max > x_min:
                    self._review_plot_widget.setXRange(x_min, x_max, padding=0)
                if y_max > y_min:
                    self._review_plot_widget.setYRange(y_min, y_max, padding=0)
            except ValueError:
                self._review_plot_widget.autoRange()

    def _update_review_spectrum(self, data: np.ndarray) -> None:
        if self._review_spectrum_curve is None:
            return
        field_key = primary_field_name(data)
        ts = data["timestamp_s"]
        spectrum = analyze_spectrum(ts, data[field_key])
        if not spectrum.get("ok"):
            self._review_spectrum_curve.clear()
            if self._review_spectrum_status is not None:
                self._review_spectrum_status.setText(str(spectrum.get("reason", "无法计算频谱")))
            return
        self._review_spectrum_curve.setData(spectrum["frequencies"], spectrum["amplitudes"])
        peaks = spectrum.get("peaks", [])
        peak_text = ", ".join(
            f"{p['frequency_hz']:.3g} Hz/{p['amplitude']:.3g}" for p in peaks[:3]
        ) or "--"
        if self._review_spectrum_status is not None:
            self._review_spectrum_status.setText(
                f"主频 {spectrum['dominant_frequency_hz']:.6g} Hz；"
                f"分辨率 {spectrum['resolution_hz']:.6g} Hz；"
                f"采样率 {spectrum['sample_rate_hz']:.6g} Hz；RMS {spectrum['rms']:.6g}；峰值 {peak_text}"
            )

    def _update_review_heatmap(self, data: Optional[np.ndarray]) -> None:
        if not _HAS_PYG or self._review_heatmap_item is None:
            return
        self._clear_review_heatmap_contours()
        if data is None or len(data) == 0:
            self._review_heatmap_item.clear()
            if self._review_heatmap_status is not None:
                self._review_heatmap_status.setText("没有可显示的数据")
            return
        names = data.dtype.names or ()
        if "x_mm" not in names or "y_mm" not in names:
            self._review_heatmap_item.clear()
            if self._review_heatmap_status is not None:
                self._review_heatmap_status.setText("当前数据没有 x_mm/y_mm 空间坐标")
            return
        value_key = self._selected_review_heatmap_channel(data)
        try:
            mode = self._review_heatmap_mode()
            if mode == "interpolated":
                resolution = self._review_heatmap_resolution()
                xs, ys, grid = build_interpolated_heatmap_grid(
                    data, value_key=value_key, resolution=resolution
                )
            else:
                xs, ys, grid = build_heatmap_grid(data, value_key=value_key)
        except ValueError as exc:
            self._review_heatmap_item.clear()
            if self._review_heatmap_status is not None:
                self._review_heatmap_status.setText(str(exc))
            return
        if len(xs) == 0 or len(ys) == 0 or grid.size == 0:
            self._review_heatmap_item.clear()
            if self._review_heatmap_status is not None:
                self._review_heatmap_status.setText("空间坐标或磁场值为空，无法生成热图")
            return

        dx = float(np.median(np.diff(xs))) if len(xs) > 1 else 1.0
        dy = float(np.median(np.diff(ys))) if len(ys) > 1 else 1.0
        if dx == 0.0 or not np.isfinite(dx):
            dx = 1.0
        if dy == 0.0 or not np.isfinite(dy):
            dy = 1.0
        x0 = float(xs[0]) - dx / 2.0
        y0 = float(ys[0]) - dy / 2.0
        width = float(xs[-1] - xs[0]) + dx
        height = float(ys[-1] - ys[0]) + dy

        image = np.array(grid.T, dtype=float)
        levels = self._review_heatmap_levels(image)
        if levels is None:
            self._review_heatmap_item.setImage(image, autoLevels=True)
        else:
            self._review_heatmap_item.setImage(image, levels=levels, autoLevels=False)
        self._review_heatmap_item.setRect(QRectF(x0, y0, width, height))
        self._update_review_heatmap_contours(image)
        if self._review_heatmap_status is not None:
            finite_count = int(np.isfinite(grid).sum())
            finite_values = grid[np.isfinite(grid)]
            value_range = ""
            if finite_values.size:
                value_range = f"，范围 {float(finite_values.min()):.6g}..{float(finite_values.max()):.6g}"
            mode_label = "插值" if self._review_heatmap_mode() == "interpolated" else "原始"
            spatial_stats = analyze_spatial_grid(xs, ys, grid)
            profile = extract_profile(xs, ys, grid, axis="x")
            profile_text = ""
            if profile.get("ok"):
                profile_text = (
                    f"，中心剖面 pk-pk {profile['peak_to_peak']:.6g}"
                )
            self._review_heatmap_status.setText(
                f"{mode_label} {len(xs)} × {len(ys)} 网格，{finite_count} 个有效格，值: {value_key}{value_range}；"
                f"均匀性 {spatial_stats['uniformity_pct']:.3g}%；"
                f"热点 ({spatial_stats['hotspot'][0]:.3g}, {spatial_stats['hotspot'][1]:.3g})"
                f"{profile_text}"
            )
        if self._review_heatmap_widget is not None:
            self._review_heatmap_widget.autoRange()

    def _review_heatmap_mode(self) -> str:
        if self._review_heatmap_mode_combo is not None:
            mode = self._review_heatmap_mode_combo.currentData()
            if mode in {"raw", "interpolated"}:
                return str(mode)
        return "raw"

    def _review_heatmap_resolution(self) -> int:
        if self._review_heatmap_resolution_spin is not None:
            return int(self._review_heatmap_resolution_spin.value())
        return 80

    def _update_review_heatmap_channel_options(self, data: Optional[np.ndarray]) -> None:
        if not _HAS_PYG or self._review_heatmap_channel_combo is None:
            return
        current = self._review_heatmap_channel_combo.currentData()
        names = data.dtype.names if data is not None else ()
        options = []
        for key, label in (
            ("field_total", "Total B"),
            ("field_x", "X"),
            ("field_y", "Y"),
            ("field_z", "Z"),
            ("field_total_mt", "Total B (mT alias)"),
            ("field_x_mt", "X (mT alias)"),
            ("field_y_mt", "Y (mT alias)"),
            ("field_z_mt", "Z (mT alias)"),
        ):
            if names and key in names:
                values = np.asarray(data[key], dtype=float)
                if np.any(np.isfinite(values)):
                    options.append((label, key))
        if not options and names:
            key = primary_field_name(data)
            options.append((key, key))

        self._review_heatmap_channel_combo.blockSignals(True)
        try:
            self._review_heatmap_channel_combo.clear()
            for label, key in options:
                self._review_heatmap_channel_combo.addItem(label, key)
            index = self._review_heatmap_channel_combo.findData(current)
            if index >= 0:
                self._review_heatmap_channel_combo.setCurrentIndex(index)
        finally:
            self._review_heatmap_channel_combo.blockSignals(False)

    def _selected_review_heatmap_channel(self, data: np.ndarray) -> str:
        if self._review_heatmap_channel_combo is not None:
            selected = self._review_heatmap_channel_combo.currentData()
            if selected in (data.dtype.names or ()):
                return str(selected)
        return primary_field_name(data)

    def _review_heatmap_levels(self, image: np.ndarray) -> Optional[Tuple[float, float]]:
        if self._review_heatmap_auto_levels_cb is None or self._review_heatmap_auto_levels_cb.isChecked():
            finite = image[np.isfinite(image)]
            if finite.size and self._review_heatmap_min_edit is not None and self._review_heatmap_max_edit is not None:
                self._review_heatmap_min_edit.blockSignals(True)
                self._review_heatmap_max_edit.blockSignals(True)
                try:
                    self._review_heatmap_min_edit.setText(f"{float(finite.min()):.6g}")
                    self._review_heatmap_max_edit.setText(f"{float(finite.max()):.6g}")
                finally:
                    self._review_heatmap_min_edit.blockSignals(False)
                    self._review_heatmap_max_edit.blockSignals(False)
            return None
        try:
            low = float(self._review_heatmap_min_edit.text()) if self._review_heatmap_min_edit is not None else 0.0
            high = float(self._review_heatmap_max_edit.text()) if self._review_heatmap_max_edit is not None else 1.0
        except ValueError:
            return None
        if not np.isfinite(low) or not np.isfinite(high) or high <= low:
            return None
        return (low, high)

    def _clear_review_heatmap_contours(self) -> None:
        for contour in getattr(self, "_review_heatmap_contours", []):
            try:
                contour.setParentItem(None)
                if self._review_heatmap_widget is not None:
                    self._review_heatmap_widget.removeItem(contour)
            except Exception:
                pass
        self._review_heatmap_contours = []

    def _update_review_heatmap_contours(self, image: np.ndarray) -> None:
        if self._review_heatmap_contour_cb is None or not self._review_heatmap_contour_cb.isChecked():
            return
        finite = image[np.isfinite(image)]
        if finite.size < 4:
            return
        low = float(finite.min())
        high = float(finite.max())
        if high <= low:
            return
        for level in np.linspace(low, high, 7)[1:-1]:
            contour = pg.IsocurveItem(data=image, level=float(level), pen=pg.mkPen("#202020", width=1))
            contour.setParentItem(self._review_heatmap_item)
            contour.setZValue(10)
            self._review_heatmap_contours.append(contour)

    def _on_export_review_heatmap_image(self) -> None:
        if not _HAS_PYG or self._review_heatmap_widget is None or self._review_heatmap_item is None:
            QMessageBox.information(self, "图表不可用", "pyqtgraph 未安装或热图尚未初始化。")
            return
        image = getattr(self._review_heatmap_item, "image", None)
        if image is None or np.asarray(image).size == 0:
            QMessageBox.information(self, "无热图", "当前没有可导出的空间热图。")
            return
        out, _ = QFileDialog.getSaveFileName(
            self, "导出空间热图 / Export Heatmap", "spatial_heatmap.png", "PNG Images (*.png)"
        )
        if not out:
            return
        try:
            pixmap = self._review_heatmap_widget.grab()
            if not pixmap.save(out, "PNG"):
                raise OSError("QPixmap.save returned false")
            if self._db_store is not None:
                session_id = self._review_db_session_spin.value() or self._db_session_id
                self._db_store.record_export(path=out, export_type="heatmap_png", session_id=session_id)
            self.log(f"[GUI] 空间热图已导出: {out}")
        except Exception as exc:
            QMessageBox.critical(self, "导出失败", str(exc))

    def _update_review_surface(self, data: Optional[np.ndarray]) -> None:
        if self._review_surface_status is None:
            return
        renderer = getattr(self, "_review_surface_renderer", None)
        if renderer is None:
            self._review_surface_status.setText(
                "3D Surface requires optional PyOpenGL; install requirements-optional.txt to enable it."
            )
            return
        self._clear_review_surface()
        if data is None or len(data) == 0:
            self._review_surface_status.setText("没有可显示的数据 / No data")
            return
        names = data.dtype.names or ()
        if "x_mm" not in names or "y_mm" not in names:
            self._review_surface_status.setText("当前数据没有 x_mm/y_mm 空间坐标")
            return
        value_key = self._selected_review_heatmap_channel(data)
        try:
            xs, ys, grid = build_surface_grid(
                data,
                value_key=value_key,
                resolution=self._review_heatmap_resolution(),
                interpolated=self._review_heatmap_mode() == "interpolated",
            )
        except ValueError as exc:
            self._review_surface_status.setText(str(exc))
            return
        if len(xs) == 0 or len(ys) == 0 or grid.size == 0:
            self._review_surface_status.setText("空间坐标或磁场值为空，无法生成 3D surface")
            return
        finite = grid[np.isfinite(grid)]
        if finite.size == 0:
            self._review_surface_status.setText("3D surface 没有有效数值")
            return

        z_grid = np.asarray(grid, dtype=float).T
        levels = self._review_heatmap_levels(z_grid)
        colors = self._review_surface_colors(z_grid, levels)

        try:
            renderer.set_surface(np.asarray(xs, dtype=float), np.asarray(ys, dtype=float), grid, colors)
            self._review_surface_item = renderer.has_surface
            self._review_surface_export_btn.setEnabled(True)
            self._review_surface_reset_btn.setEnabled(True)
            mode_label = "Interpolated" if self._review_heatmap_mode() == "interpolated" else "Raw"
            self._review_surface_status.setText(
                f"{mode_label} 3D surface {len(xs)} × {len(ys)}, value: {value_key}, "
                f"range {float(finite.min()):.6g}..{float(finite.max()):.6g}; "
                "X/Y are centered for display."
            )
        except Exception as exc:
            self._clear_review_surface()
            self._review_surface_status.setText(f"3D surface render failed: {exc}")

    def _review_surface_colors(
        self, z_grid: np.ndarray, levels: Optional[Tuple[float, float]]
    ) -> np.ndarray:
        finite = z_grid[np.isfinite(z_grid)]
        if finite.size == 0:
            low, high = 0.0, 1.0
        elif levels is not None:
            low, high = levels
        else:
            low, high = float(finite.min()), float(finite.max())
        if not np.isfinite(low) or not np.isfinite(high) or high <= low:
            high = low + 1.0

        ratio = (z_grid - low) / (high - low)
        ratio = np.clip(np.nan_to_num(ratio, nan=0.0), 0.0, 1.0)
        colors = np.zeros(z_grid.shape + (4,), dtype=float)
        stops = np.array([
            [0.13, 0.40, 0.67],
            [0.40, 0.66, 0.81],
            [1.00, 1.00, 0.75],
            [0.70, 0.09, 0.17],
        ], dtype=float)
        first = ratio <= 0.35
        second = (ratio > 0.35) & (ratio <= 0.65)
        third = ratio > 0.65
        for mask, left, right, denom, offset in (
            (first, stops[0], stops[1], 0.35, 0.0),
            (second, stops[1], stops[2], 0.30, 0.35),
            (third, stops[2], stops[3], 0.35, 0.65),
        ):
            if np.any(mask):
                local = ((ratio[mask] - offset) / denom).reshape(-1, 1)
                colors[mask, :3] = left + (right - left) * local
        colors[..., 3] = np.where(np.isfinite(z_grid), 1.0, 0.0)
        return colors.reshape((-1, 4))

    def _clear_review_surface(self) -> None:
        renderer = getattr(self, "_review_surface_renderer", None)
        if renderer is not None:
            renderer.clear()
        self._review_surface_item = None

    def _reset_review_surface_view(self) -> None:
        renderer = getattr(self, "_review_surface_renderer", None)
        if renderer is not None:
            renderer.reset_view()

    def _on_export_review_surface_image(self) -> None:
        renderer = getattr(self, "_review_surface_renderer", None)
        if renderer is None or not renderer.has_surface:
            QMessageBox.information(self, "3D 不可用", "当前没有可导出的 3D Surface。")
            return
        out, _ = QFileDialog.getSaveFileName(
            self, "导出 3D Surface / Export 3D Surface", "spatial_surface_3d.png", "PNG Images (*.png)"
        )
        if not out:
            return
        try:
            renderer.export_png(out)
            if self._db_store is not None:
                session_id = self._review_db_session_spin.value() or self._db_session_id
                self._db_store.record_export(path=out, export_type="surface_3d_png", session_id=session_id)
            self.log(f"[GUI] 3D Surface 已导出: {out}")
        except Exception as exc:
            QMessageBox.critical(self, "导出失败", str(exc))

    def _update_review_stats(self) -> None:
        data = self._active_review_data()
        if data is None or len(data) == 0:
            self._review_stat_count.setText("--")
            self._review_stat_duration.setText("--")
            self._review_stat_min.setText("--")
            self._review_stat_max.setText("--")
            self._review_stat_mean.setText("--")
            self._review_stat_rms.setText("--")
            self._review_stat_std.setText("--")
            self._review_stat_pkpk.setText("--")
            self._review_stat_sample_rate.setText("--")
            self._review_stat_channels.setText("")
            return
        summary = get_review_summary(data)
        self._review_stat_count.setText(f"{summary['count']:,}")
        self._review_stat_duration.setText(f"{summary['duration_s']:.3f} s")
        self._review_stat_min.setText(f"{summary['field_min']:.6f}")
        self._review_stat_max.setText(f"{summary['field_max']:.6f}")
        self._review_stat_mean.setText(f"{summary['field_mean']:.6f}")
        self._review_stat_rms.setText(f"{summary.get('field_rms', 0.0):.6f} / {summary.get('field_std', 0.0):.6f}")
        self._review_stat_pkpk.setText(f"{summary.get('field_peak_to_peak', 0.0):.6f}")
        self._review_stat_sample_rate.setText(f"{summary.get('sample_rate_hz', 0.0):.3f} Hz")

        # 多通道统计摘要
        ch_lines = []
        for ch_name, ch_stats in summary.get("channels", {}).items():
            if ch_name in ("freq_hz", "temp_c"):
                continue
            label = {"field_x": "X", "field_y": "Y", "field_z": "Z", "field_total": "Total"}.get(ch_name, ch_name)
            ch_lines.append(
                f"{label}: min={ch_stats['min']:.4f} max={ch_stats['max']:.4f} rms={ch_stats.get('rms', 0.0):.4f} pkpk={ch_stats.get('peak_to_peak', 0.0):.4f}"
            )
        if ch_lines:
            self._review_stat_channels.setText(" | ".join(ch_lines))
        else:
            self._review_stat_channels.setText("")

    def _update_review_table(self) -> None:
        data = self._active_review_data()
        self._review_table_updating = True
        try:
            self._review_table.setRowCount(0)
            if data is None or len(data) == 0:
                return
            field_key = primary_field_name(data)
            limit = min(len(data), 500)
            self._review_table.setRowCount(limit)
            for row_idx in range(limit):
                row = data[row_idx]
                values = [
                    str(int(row["sequence"])),
                    f"{float(row['timestamp_s'] - data['timestamp_s'][0]):.6f}",
                    f"{float(row[field_key]):.6f}",
                    f"{float(row['freq_hz']):.3f}",
                    f"{float(row['temp_c']):.3f}",
                    str(row["source"]),
                ]
                for col_idx, value in enumerate(values):
                    self._review_table.setItem(row_idx, col_idx, QTableWidgetItem(value))
            self._review_table.resizeColumnsToContents()
        finally:
            self._review_table_updating = False

    def _on_review_table_selection_changed(self) -> None:
        if self._review_table_updating:
            return
        rows = {idx.row() for idx in self._review_table.selectedIndexes()}
        if not rows:
            return
        sequences = []
        for row in rows:
            item = self._review_table.item(row, 0)
            if item is not None:
                try:
                    sequences.append(int(item.text()))
                except ValueError:
                    pass
        if not sequences:
            return
        self._review_seq_start_spin.setValue(min(sequences))
        self._review_seq_end_spin.setValue(max(sequences))
        self._apply_review_filter()

    def _on_review_region_changed(self) -> None:
        if self._review_region is None:
            return
        start, end = self._review_region.getRegion()
        self._review_time_start_edit.setText(f"{float(start):.6f}")
        self._review_time_end_edit.setText(f"{float(end):.6f}")

    def _save_review_view_preset(self) -> None:
        review_cfg = self._cfg.setdefault("review", {})
        review_cfg["manual_axis_enabled"] = not self._review_auto_axis_cb.isChecked()
        for key, edit in (
            ("x_min_s", self._review_x_min_edit),
            ("x_max_s", self._review_x_max_edit),
            ("y_min", self._review_y_min_edit),
            ("y_max", self._review_y_max_edit),
        ):
            try:
                review_cfg[key] = float(edit.text())
            except ValueError:
                pass
        review_cfg["default_source"] = self._review_db_source_combo.currentText()
        save_config(self._cfg)
        self.log("[GUI] 回看视图配置已保存")

    def _on_export_review_selection(self) -> None:
        data = self._active_review_data()
        if data is None or len(data) == 0:
            QMessageBox.information(self, "无数据", "当前没有可导出的选区数据。")
            return
        out, _ = QFileDialog.getSaveFileName(
            self, "导出选区 CSV / Export Selection", "review_selection.csv", "CSV Files (*.csv)"
        )
        if not out:
            return
        try:
            export_review_selection_csv(Path(out), data)
            if self._db_store is not None:
                session_id = self._review_db_session_spin.value() or self._db_session_id
                self._db_store.record_export(path=out, export_type="selection_csv", session_id=session_id)
            self.log(f"[GUI] 选区 CSV 已导出: {out}")
        except Exception as exc:
            QMessageBox.critical(self, "导出失败", str(exc))

    def _on_export_review_report(self) -> None:
        data = self._active_review_data()
        if data is None or len(data) == 0:
            QMessageBox.information(self, "无数据", "当前没有可生成报告的数据。")
            return
        out, _ = QFileDialog.getSaveFileName(
            self, "导出 HTML 报告 / Export HTML Report", "m1600_report.html", "HTML Files (*.html)"
        )
        if not out:
            return
        metadata = {
            "device_model": self._device_model,
            "display_unit": self._display_unit,
            "source": self._review_db_source_combo.currentText(),
            "database": self._cfg.get("database", {}).get("path", ""),
        }
        if self._review_file_paths:
            file_hashes = []
            for path in self._review_file_paths:
                try:
                    digest = hashlib.sha256(path.read_bytes()).hexdigest()
                    file_hashes.append(f"{path.name}: {digest}")
                except OSError:
                    file_hashes.append(f"{path.name}: unreadable")
            metadata["input_file_sha256"] = " | ".join(file_hashes)
        try:
            threshold = evaluate_threshold(
                data,
                low=float(self._low_thresh_edit.text() or 0.0),
                high=float(self._up_thresh_edit.text() or 0.0),
                channel=self._threshold_channel_key(),
                absolute=self._judge_abs_cb.isChecked(),
                mode="open" if self._judge_mode_combo.currentIndex() == 1 else "closed",
            )
        except ValueError:
            threshold = {"enabled": False, "status": "INVALID_THRESHOLD"}
        try:
            export_html_report(
                Path(out),
                data,
                metadata=metadata,
                threshold=threshold,
                include_heatmap=True,
                heatmap_value_key=self._selected_review_heatmap_channel(data),
            )
            if self._db_store is not None:
                session_id = self._review_db_session_spin.value() or self._db_session_id
                self._db_store.record_export(path=out, export_type="html_report", session_id=session_id)
            self.log(f"[GUI] HTML 报告已导出: {out}")
        except Exception as exc:
            QMessageBox.critical(self, "报告失败", str(exc))

    # ==================================================================
    # 页面 4: 调试
    # ==================================================================

    def _build_debug_page(self) -> QWidget:
        page = QWidget()
        layout = QVBoxLayout(page)
        layout.setContentsMargins(16, 16, 16, 16)

        title = QLabel("调试 / Debug")
        title.setObjectName("sectionTitle")
        layout.addWidget(title)

        rx_grp = QGroupBox("接收 / RX")
        rx_v = QVBoxLayout(rx_grp)
        self._debug_rx_text = QTextEdit()
        self._debug_rx_text.setReadOnly(True)
        self._debug_rx_text.setStyleSheet("font-family: Menlo, Monaco, 'Courier New'; font-size: 11px;")
        rx_v.addWidget(self._debug_rx_text)
        rx_ctrl = QHBoxLayout()
        self._debug_rx_hex_cb = QCheckBox("Hex 显示")
        rx_ctrl.addWidget(self._debug_rx_hex_cb)
        rx_ctrl.addStretch()
        clear_rx_btn = QPushButton("清除 / Clear")
        clear_rx_btn.clicked.connect(lambda: self._debug_rx_text.clear())
        rx_ctrl.addWidget(clear_rx_btn)
        rx_v.addLayout(rx_ctrl)
        layout.addWidget(rx_grp)

        tx_grp = QGroupBox("发送 / TX")
        tx_v = QVBoxLayout(tx_grp)
        self._debug_tx_input = QLineEdit()
        self._debug_tx_input.setPlaceholderText("输入指令 (如 DATA?>)...")
        tx_v.addWidget(self._debug_tx_input)
        tx_ctrl = QHBoxLayout()
        self._debug_tx_hex_cb = QCheckBox("Hex 模式")
        tx_ctrl.addWidget(self._debug_tx_hex_cb)
        send_btn = QPushButton("发送 / Send")
        send_btn.clicked.connect(self._on_debug_send)
        tx_ctrl.addWidget(send_btn)
        tx_ctrl.addStretch()
        tx_v.addLayout(tx_ctrl)
        quick_row = QHBoxLayout()
        for cmd in ["DATA?>", "DATAC>", "DATAS>", "ZERO>", "FAST020>", "FAST100>", "FAST300>"]:
            btn = QPushButton(cmd)
            btn.clicked.connect(lambda checked, c=cmd: self._debug_tx_input.setText(c))
            quick_row.addWidget(btn)
        quick_row.addStretch()
        tx_v.addLayout(quick_row)
        layout.addWidget(tx_grp)

        return page

    def _on_debug_send(self) -> None:
        if not (self._ctrl and self._ctrl.is_connected):
            self.log("[DEBUG] 设备未连接"); return
        text = self._debug_tx_input.text().strip()
        if not text: return
        try:
            if self._debug_tx_hex_cb.isChecked():
                data = bytes(int(b, 16) for b in text.split())
                self._ctrl.driver._send_raw(data)
                self._debug_rx_text.append(f'<span style="color:#00a651;">[TX-Hex] {data.hex(" ")}</span>')
            else:
                self._ctrl.driver._send_command(text)
                self._debug_rx_text.append(f'<span style="color:#00a651;">[TX] {text}</span>')
        except Exception as exc:
            self.log(f"[DEBUG] 发送失败: {exc}")

    def _on_raw_log(self, direction: str, data: bytes) -> None:
        """Driver raw-log callback; may be invoked outside the GUI thread."""
        self._raw_log_received.emit(direction, data)

    def _append_raw_log(self, direction: str, data: bytes) -> None:
        if direction == "TX":
            text = data.decode("ascii", errors="replace").replace("\r", "\\r").replace("\n", "\\n")
            self._debug_rx_text.append(f'<span style="color:#00a651;">[TX] {text}</span>')
        else:
            if self._debug_rx_hex_cb.isChecked():
                text = data.hex(" ")
            else:
                text = data.decode("ascii", errors="replace").replace("\r", "\\r").replace("\n", "\\n")
            self._debug_rx_text.append(f'<span style="color:#0080c8;">[RX] {text}</span>')

    def _build_log_page(self) -> QWidget:
        page = QWidget()
        layout = QVBoxLayout(page)
        layout.setContentsMargins(16, 16, 16, 16)

        title = QLabel("日志 / Log")
        title.setObjectName("sectionTitle")
        layout.addWidget(title)

        self._log_text = QTextEdit()
        self._log_text.setReadOnly(True)
        self._log_text.setMinimumHeight(100)
        layout.addWidget(self._log_text, 1)

        # 清除按钮
        clear_btn = QPushButton("清除 / Clear")
        clear_btn.clicked.connect(lambda: self._log_text.clear())
        layout.addWidget(clear_btn)

        return page

    # ==================================================================
    # 导航
    # ==================================================================

    def _on_nav_changed(self, current: QTreeWidgetItem, previous: QTreeWidgetItem) -> None:
        if current is None:
            return
        idx = current.data(0, Qt.UserRole)
        self._pages.setCurrentIndex(idx)

    # ==================================================================
    # 连接操作
    # ==================================================================

    def _on_scan_ports(self) -> None:
        if self._cmd_service is None:
            self.log("[GUI] CommandService 不可用")
            return
        self.log("[GUI] 扫描串口...")
        try:
            ports = self._ctrl.scan_ports() if self._ctrl else []
        except Exception as exc:
            self.log(f"[GUI] 扫描失败: {exc}")
            return

        self._port_combo.clear()
        if ports:
            for port, label in ports:
                self._port_combo.addItem(f"{port} - {label}", port)
            self._connect_btn.setEnabled(True)
            self.log(f"[GUI] 找到 {len(ports)} 个端口")
        else:
            self._port_combo.addItem("未找到设备 / No device found")
            self._connect_btn.setEnabled(False)
            self.log("[GUI] 未找到 CH-1600 设备")

    def _on_connect(self) -> None:
        if self._cmd_service is None:
            return
        port_text = self._port_combo.currentText()
        port = port_text.split(" - ")[0].strip() if " - " in port_text else port_text.strip()
        if not port or "未找到设备" in port or "No device found" in port:
            self.log("[GUI] 未选择已验证的 CH-1600 串口")
            return
        baud = int(self._baud_combo.currentText())

        self.log(f"[GUI] 正在连接 {port} @ {baud}...")
        try:
            idn = self._cmd_service.connect_device(port, baud)
            self.log(f"[GUI] 已连接: {idn}")
            self._conn_info_label.setText(f"已连接 / Connected\n{idn}")
            self._connect_btn.setEnabled(False)
            self._disconnect_btn.setEnabled(True)

            # 检测面板实时发送模式
            if self._ctrl and self._ctrl.driver.is_panel_streaming_mode:
                self._update_connected_ui(False)  # 禁用指令按钮
                self._stream_start_btn.setEnabled(True)  # 但可以开始采集
                self.log("[GUI] 设备处于面板实时发送模式 — RS-232 指令不可用")
                self.log("[GUI] 要使用完整功能, 请在设备面板按 Enter 退出实时发送模式")
                self._status_label.setText("面板实时发送模式 — 指令不可用 / Panel Streaming — No Commands")
            else:
                self._update_connected_ui(True)

            self._update_global_bar(True, False)
        except Exception as exc:
            self.log(f"[GUI] 连接失败: {exc}")
            QMessageBox.critical(self, "连接失败", str(exc))

    def _on_disconnect(self) -> None:
        if self._cmd_service is None:
            return
        self._cmd_service.disconnect_device()
        self._conn_info_label.setText("未连接 / Not Connected")
        self._connect_btn.setEnabled(True)
        self._disconnect_btn.setEnabled(False)
        self._update_connected_ui(False)
        self._update_global_bar(False, False)
        self.log("[GUI] 已断开连接")

    def _update_connected_ui(self, connected: bool) -> None:
        """连接/断开时更新各页面控件状态。"""
        for widget in [
            self._unit_btn, self._range_btn,
            self._zero_btn, self._zero_btn2,
            self._maxmin_btn, self._lock_btn,
            self._stream_start_btn,
            self._rec_start_btn,
            self._set_zero_btn, self._clear_zero_btn,
            self._up_thresh_edit, self._set_up_thresh_btn,
            self._low_thresh_edit, self._set_low_thresh_btn,
        ]:
            widget.setEnabled(connected)

    # ==================================================================
    # 参数操作
    # ==================================================================

    def _convert_field_display(self, field_mt: float) -> float:
        """将原始 mT 值按当前显示单位换算。"""
        return field_mt * self._UNIT_CONVERSION.get(self._display_unit, 1.0)

    def _primary_field_channel(self) -> str:
        channels = self._buffer.get_channels()
        for channel in ("field_mt", "field_total_mt", "field_x_mt"):
            if channel in channels:
                return channel
        return "field_mt"

    def _populate_threshold_channel_combo(self, selected_key: str = "field_total") -> None:
        if not hasattr(self, "_judge_channel_combo"):
            return
        label_map = {
            "field_total": "Total B",
            "field_x": "X",
            "field_y": "Y",
            "field_z": "Z",
        }
        cap = get_device_capability(self._device_model)
        self._judge_channel_combo.blockSignals(True)
        try:
            self._judge_channel_combo.clear()
            for key in cap.threshold_channels:
                self._judge_channel_combo.addItem(label_map.get(key, key), key)
            index = self._judge_channel_combo.findData(selected_key)
            if index < 0:
                index = self._judge_channel_combo.findData("field_total")
            self._judge_channel_combo.setCurrentIndex(max(0, index))
        finally:
            self._judge_channel_combo.blockSignals(False)
        self._cfg.setdefault("acquisition", {})["threshold_channel"] = self._threshold_channel_key()

    def _threshold_channel_key(self) -> str:
        if hasattr(self, "_judge_channel_combo"):
            selected = self._judge_channel_combo.currentData()
            if selected:
                return str(selected)
        return "field_total"

    def _threshold_value_from_latest(self, latest: Dict[str, float]) -> float:
        key = self._threshold_channel_key()
        if key == "field_x":
            return latest.get("field_x_mt", latest.get("field_mt", latest.get("field_total_mt", 0.0)))
        if key == "field_y":
            return latest.get("field_y_mt", 0.0)
        if key == "field_z":
            return latest.get("field_z_mt", 0.0)
        return latest.get("field_total_mt", latest.get("field_mt", latest.get("field_x_mt", 0.0)))

    def _threshold_buffer_channel(self) -> str:
        """将阈值通道配置映射到实时缓冲区通道名。"""
        key = self._threshold_channel_key()
        channels = self._buffer.get_channels()
        if key == "field_x":
            return "field_x_mt" if "field_x_mt" in channels else "field_mt"
        if key == "field_y":
            return "field_y_mt"
        if key == "field_z":
            return "field_z_mt"
        return "field_total_mt" if "field_total_mt" in channels else "field_mt"

    def _on_threshold_channel_changed(self) -> None:
        self._cfg.setdefault("acquisition", {})["threshold_channel"] = self._threshold_channel_key()
        save_config(self._cfg)

    def _on_display_unit_changed(self, unit: str) -> None:
        """显示单位变更: 更新换算系数并保存配置。"""
        self._display_unit = unit
        self._cfg.setdefault("ui", {})["display_unit"] = unit
        save_config(self._cfg)
        self.log(f"[GUI] 显示单位已切换: {unit}")
        # 立即刷新当前显示值
        latest = self._buffer.get_latest(self._primary_field_channel())
        if latest != 0.0:
            mode = self._get_active_acq_mode()
            dec = mode["decimals"]
            field_display = self._convert_field_display(latest)
            self._field_label.setText(f"{field_display:.{dec}f} {unit}")
        # 更新零点偏移标签的单位
        self._update_zero_offset_label()

    def _on_acq_mode_changed(self) -> None:
        """采集模式变更: 更新图表优化参数 + 模式信息显示。"""
        rate_key = self._sample_rate_combo.currentData()
        if rate_key not in ACQ_MODE_TABLE:
            return
        mode = ACQ_MODE_TABLE[rate_key]

        # 更新信息标签
        meas_type = self._meas_type_combo.currentText().split(" ")[0]
        self._acq_info_label.setText(
            f"当前: {mode['label']} ({meas_type}) | "
            f"预期 FPS: {mode['expect_fps']} | 分辨率: {mode['resolution']} | "
            f"精度: {mode['accuracy']}"
        )

        # 保存到配置
        self._cfg.setdefault("acquisition", {})["mode_key"] = rate_key
        save_config(self._cfg)

        self.log(f"[GUI] 采集模式已切换: {mode['label']}")

    def _on_device_model_changed(self) -> None:
        """设备型号变更: 更新单位选项、表格列、配置，并提示用户。"""
        new_model = self._device_model_combo.currentData()
        if new_model == self._device_model:
            return

        # 如果正在采集，阻止切换并恢复旧选项
        if self._ctrl and self._ctrl.is_streaming:
            QMessageBox.information(
                self, "采集中", "请先停止数据采集，再切换设备型号。\nStop acquisition before changing device model."
            )
            idx = self._device_model_combo.findData(self._device_model)
            if idx >= 0:
                self._device_model_combo.setCurrentIndex(idx)
            return

        self._device_model = new_model
        cap = get_device_capability(new_model)
        self._UNIT_CONVERSION = dict(cap.display_scales)

        # 更新显示单位下拉框
        self._display_unit_combo.clear()
        self._display_unit_combo.addItems(self._get_display_unit_options(new_model))
        default_unit = self._default_unit_for_model()
        self._display_unit = default_unit
        self._display_unit_combo.setCurrentText(default_unit)

        # 更新实时数据表格列
        columns = self._get_table_columns(new_model)
        self._pending_live_table_rows.clear()
        self._live_table_model.set_columns(columns)

        # 重新初始化环形缓冲区通道
        self._reinit_buffer_for_model(new_model)
        self._populate_threshold_channel_combo(self._threshold_channel_key())

        # 更新图表分量曲线可见性
        if hasattr(self, '_field_x_curve'):
            self._field_x_curve.setVisible("field_x_mt" in cap.stream_channels)
        if hasattr(self, '_field_y_curve'):
            self._field_y_curve.setVisible("field_y_mt" in cap.stream_channels)
        if hasattr(self, '_field_z_curve'):
            self._field_z_curve.setVisible("field_z_mt" in cap.stream_channels)

        # 保存配置
        self._cfg["device_model"] = new_model
        self._cfg.setdefault("ui", {})["display_unit"] = default_unit
        save_config(self._cfg)
        self.log(f"[GUI] 设备型号已切换: {new_model}")

    def _reinit_buffer_for_model(self, model: str) -> None:
        """根据设备型号重新初始化环形缓冲区通道。"""
        channels = list(get_device_capability(model).stream_channels)
        self._buffer = CircularBuffer(channels=channels, capacity=self._buffer.capacity)

    def _get_active_acq_mode(self) -> dict:
        """获取当前生效的采集模式参数。"""
        rate_key = self._sample_rate_combo.currentData()
        if rate_key in ACQ_MODE_TABLE:
            return ACQ_MODE_TABLE[rate_key]
        return ACQ_MODE_TABLE["dc_normal"]

    def _default_unit_for_model(self) -> str:
        """根据设备模型返回默认显示单位。"""
        return get_device_capability(self._device_model).field_unit

    def _get_display_unit_options(self, model: str) -> List[str]:
        """根据设备模型返回可用的显示单位选项。"""
        return list(get_device_capability(model).available_units)

    def _get_table_columns(self, model: str) -> List[str]:
        """根据设备模型返回实时数据表格的列标题。"""
        return list(get_device_capability(model).table_columns)

    def _on_probe_profile_changed(self) -> None:
        profile_name = self._probe_profile_combo.currentData()
        if not profile_name:
            return
        self._probe_profile = str(profile_name)
        profile = get_probe_profile(self._probe_profile)
        self._cfg["probe_profile"] = self._probe_profile
        save_config(self._cfg)
        self.log(f"[GUI] 探头档案已切换: {profile.label}")

    def _live_table_row_values(self, sequence: int, point: Dict[str, float]) -> List[str]:
        cap = get_device_capability(self._device_model)
        values = [str(sequence)]
        if cap.measurement_dimension == 1:
            values.append(f"{point.get('field_mt', point.get('field_total_mt', 0.0)):.6f}")
        else:
            values.append(f"{point.get('field_x_mt', 0.0):.6f}")
            values.append(f"{point.get('field_y_mt', 0.0):.6f}")
            if cap.measurement_dimension >= 3:
                values.append(f"{point.get('field_z_mt', 0.0):.6f}")
            values.append(f"{point.get('field_total_mt', 0.0):.6f}")
        if cap.has_freq:
            values.append(f"{point.get('freq_hz', 0.0):.1f}")
        if cap.has_temp:
            values.append(f"{point.get('temp_c', 0.0):.1f}")
        values.append(f"{point.get('timestamp_s', 0.0):.6f}")
        return values

    def _on_cycle_unit(self) -> None:
        if self._cmd_service:
            self._cmd_service.cycle_unit()

    def _on_cycle_range(self) -> None:
        if self._cmd_service:
            self._cmd_service.cycle_range()

    def _on_zero(self) -> None:
        if self._cmd_service:
            self._cmd_service.do_zero()
            self.log("[GUI] 执行归零")

    def _on_max_min(self) -> None:
        if self._cmd_service:
            self._cmd_service.submit(Command(cmd_type=CommandType.CH1600_MAX_MIN))
            self.log("[GUI] 显示最大/最小值")

    def _on_toggle_lock(self, checked: bool) -> None:
        if self._cmd_service is None:
            return
        if checked:
            self._cmd_service.submit(Command(cmd_type=CommandType.CH1600_LOCK))
            self.log("[GUI] 面板已锁定")
        else:
            self._cmd_service.submit(Command(cmd_type=CommandType.CH1600_UNLOCK))
            self.log("[GUI] 面板已解锁")

    def _on_set_up_thresh(self) -> None:
        if self._cmd_service is None:
            return
        try:
            val = float(self._up_thresh_edit.text())
            self._cmd_service.submit(
                Command(cmd_type=CommandType.CH1600_SET_UP_THRESH, params={"value": val})
            )
            self.log(f"[GUI] 设置上限阈值: {val:.2f} mT")
        except ValueError:
            pass

    def _on_set_low_thresh(self) -> None:
        if self._cmd_service is None:
            return
        try:
            val = float(self._low_thresh_edit.text())
            self._cmd_service.submit(
                Command(cmd_type=CommandType.CH1600_SET_LOW_THRESH, params={"value": val})
            )
            self.log(f"[GUI] 设置下限阈值: {val:.2f} mT")
        except ValueError:
            pass

    # ------------------------------------------------------------------
    # 软件零点偏移校准
    # ------------------------------------------------------------------

    def _offset_for_channel(self, channel: str) -> float:
        return self._zero_offsets.get(channel, self._zero_offset)

    def _update_zero_offset_label(self) -> None:
        unit = self._display_unit
        cap = get_device_capability(self._device_model)
        if cap.measurement_dimension >= 2 and any(
            abs(self._zero_offsets.get(ch, 0.0)) > 0.0
            for ch in ("field_x_mt", "field_y_mt", "field_z_mt")
        ):
            parts = []
            for label, channel in (("X", "field_x_mt"), ("Y", "field_y_mt"), ("Z", "field_z_mt")):
                if channel in cap.stream_channels:
                    value = self._convert_field_display(self._zero_offsets.get(channel, 0.0))
                    parts.append(f"{label}:{value:.4f}")
            self._zero_offset_label.setText(f"Zero offset: {' '.join(parts)} {unit}")
            return
        value = self._convert_field_display(self._offset_for_channel(self._primary_field_channel()))
        self._zero_offset_label.setText(f"Zero offset: {value:.4f} {unit}")

    def _apply_zero_offsets_to_point(self, point: Dict[str, float]) -> Dict[str, float]:
        corrected = dict(point)
        cap = get_device_capability(self._device_model)
        if cap.measurement_dimension >= 2:
            components = []
            for channel in ("field_x_mt", "field_y_mt", "field_z_mt"):
                if channel in corrected:
                    corrected[channel] = corrected[channel] - self._zero_offsets.get(channel, 0.0)
                    components.append(corrected[channel])
            if components:
                total = math.sqrt(sum(value * value for value in components))
                corrected["field_total_mt"] = total
                corrected["field_mt"] = total
            return corrected

        offset = self._offset_for_channel("field_total_mt")
        for channel in ("field_mt", "field_x_mt", "field_total_mt"):
            if channel in corrected:
                corrected[channel] = corrected[channel] - offset
        return corrected

    def _on_set_zero(self) -> None:
        """以当前读数为零点，后续数据均减去此偏移。"""
        cap = get_device_capability(self._device_model)
        if cap.measurement_dimension >= 2:
            for channel in ("field_x_mt", "field_y_mt", "field_z_mt"):
                if channel in cap.stream_channels:
                    self._zero_offsets[channel] = (
                        self._buffer.get_latest(channel) + self._zero_offsets.get(channel, 0.0)
                    )
            self._zero_offset = 0.0
        else:
            channel = self._primary_field_channel()
            self._zero_offset = self._buffer.get_latest(channel) + self._offset_for_channel(channel)
            self._zero_offsets = {
                "field_mt": self._zero_offset,
                "field_x_mt": self._zero_offset,
                "field_total_mt": self._zero_offset,
            }
        self._update_zero_offset_label()
        acq_cfg = self._cfg.setdefault("acquisition", {})
        acq_cfg["zero_offset"] = self._zero_offset
        acq_cfg["zero_offsets"] = dict(self._zero_offsets)
        save_config(self._cfg)
        self.log(f"[GUI] 设置软件零点偏移: {self._zero_offset_label.text()}")

    def _on_clear_zero(self) -> None:
        """清除零点偏移，恢复原始读数。"""
        self._zero_offset = 0.0
        self._zero_offsets.clear()
        self._update_zero_offset_label()
        acq_cfg = self._cfg.setdefault("acquisition", {})
        acq_cfg["zero_offset"] = 0.0
        acq_cfg["zero_offsets"] = {}
        save_config(self._cfg)
        self.log("[GUI] 已清除软件零点偏移")

    # ------------------------------------------------------------------
    # 图表控制操作
    # ------------------------------------------------------------------

    def _on_clear_data_table(self) -> None:
        """清空实时数据表格。"""
        self._pending_live_table_rows.clear()
        self._live_table_model.clear()
        self.log("[GUI] 数据表格已清空")

    def _flush_live_table_rows(self) -> None:
        if not self._pending_live_table_rows:
            return
        rows = self._pending_live_table_rows
        self._pending_live_table_rows = []
        max_rows = self._table_max_rows_spin.value()
        self._live_table_model.append_rows(rows, max_rows)
        self._data_table.scrollToBottom()

    def _on_clear_chart(self) -> None:
        """清空图表数据和缓冲区。"""
        self._buffer.clear()
        self._total_points = 0
        for curve_name in ('_field_curve', '_freq_curve', '_field_x_curve', '_field_y_curve', '_field_z_curve'):
            curve = getattr(self, curve_name, None)
            if curve is not None:
                curve.clear()
        self.log("[GUI] 图表已清除")

    def _on_pause_display(self, checked: bool) -> None:
        """暂停/恢复图表显示 (数据采集继续)。"""
        self._display_paused = checked
        if checked:
            self._pause_btn.setText("恢复显示 / Resume")
            self.log("[GUI] 图表显示已暂停 (数据采集继续)")
        else:
            self._pause_btn.setText("暂停显示 / Pause")
            self.log("[GUI] 图表显示已恢复")
            # 恢复时立即刷新 Y 轴范围，避免因暂停期间数据变化导致范围过期
            if self._auto_y_cb.isChecked() and hasattr(self, '_field_curve'):
                total_ch = "field_mt" if "field_mt" in self._buffer.get_channels() else "field_total_mt"
                _, vals = self._buffer.get(total_ch, max_points=5000, downsample=1)
                if len(vals) > 0:
                    y_min, y_max = vals.min(), vals.max()
                    margin = max(abs(y_min), abs(y_max)) * 0.1 + 1e-6
                    self._plot_widget.setYRange(y_min - margin, y_max + margin, padding=0)

    def _on_save_chart(self) -> None:
        """导出图表为 PNG/SVG/JPG 图片。"""
        if not _HAS_PYG or self._plot_widget is None:
            return
        path, _ = QFileDialog.getSaveFileName(
            self, "保存图表", "chart.png",
            "PNG (*.png);;SVG (*.svg);;JPEG (*.jpg)"
        )
        if not path:
            return
        try:
            exporter = pg.exporters.ImageExporter(self._plot_widget.plotItem)
            exporter.export(path)
            self.log(f"[GUI] 图表已保存: {path}")
        except Exception as exc:
            self.log(f"[GUI] 保存图表失败: {exc}")
            QMessageBox.critical(self, "保存失败", str(exc))

    # ------------------------------------------------------------------
    # 图表配置交互
    # ------------------------------------------------------------------

    def _on_field_color(self) -> None:
        if not _HAS_PYG or self._plot_widget is None:
            return
        init_color = self._cfg.get("ui", {}).get("chart_colors", {}).get("field", "#0080c8")
        color = QColorDialog.getColor(QColor(init_color))
        if color.isValid():
            hex_color = color.name()
            width = self._line_width_slider.value()
            self._field_curve.setPen(pg.mkPen(hex_color, width=width))
            self._cfg.setdefault("ui", {}).setdefault("chart_colors", {})["field"] = hex_color

    def _on_freq_color(self) -> None:
        if not _HAS_PYG or self._plot_widget is None:
            return
        init_color = self._cfg.get("ui", {}).get("chart_colors", {}).get("freq", "#00a651")
        color = QColorDialog.getColor(QColor(init_color))
        if color.isValid():
            hex_color = color.name()
            width = self._line_width_slider.value()
            self._freq_curve.setPen(pg.mkPen(hex_color, width=width))
            self._cfg.setdefault("ui", {}).setdefault("chart_colors", {})["freq"] = hex_color

    def _on_line_width_changed(self, value: int) -> None:
        if not _HAS_PYG:
            return
        if hasattr(self, '_field_curve') and self._field_curve is not None:
            field_color = self._cfg.get("ui", {}).get("chart_colors", {}).get("field", "#0080c8")
            self._field_curve.setPen(pg.mkPen(field_color, width=value))
        if hasattr(self, '_freq_curve') and self._freq_curve is not None:
            freq_color = self._cfg.get("ui", {}).get("chart_colors", {}).get("freq", "#00a651")
            self._freq_curve.setPen(pg.mkPen(freq_color, width=value))

    def _on_history_points_changed(self, value: int) -> None:
        self._cfg.setdefault("ui", {})["chart_history_points"] = value

    def _on_auto_y_toggled(self, checked: bool) -> None:
        self._chart_auto_y = checked
        self._y_min_edit.setEnabled(not checked)
        self._y_max_edit.setEnabled(not checked)
        if not checked:
            self._on_y_range_changed()

    def _on_y_range_changed(self) -> None:
        try:
            self._chart_y_min = float(self._y_min_edit.text())
        except ValueError:
            pass
        try:
            self._chart_y_max = float(self._y_max_edit.text())
        except ValueError:
            pass

    def _on_save_chart_config(self) -> None:
        ui_cfg = self._cfg.setdefault("ui", {})
        ui_cfg["chart_line_width"] = self._line_width_slider.value()
        ui_cfg["chart_history_points"] = self._history_slider.value()
        save_config(self._cfg)
        self.log("[GUI] 图表配置已保存")

    # ==================================================================
    # 数据流操作
    # ==================================================================

    def _on_start_stream(self) -> None:
        if self._cmd_service is None:
            return
        self._cmd_service.update_config(self._cfg)
        started = self._cmd_service.start_acquisition()
        if not started:
            self._stream_start_btn.setEnabled(True)
            self._stream_stop_btn.setEnabled(False)
            self._update_global_bar(self._ctrl.is_connected if self._ctrl else False, False)
            self.log("[GUI] 数据采集未启动")
            return
        self._stream_start_btn.setEnabled(False)
        self._stream_stop_btn.setEnabled(True)
        self._buffer.clear()
        self._update_global_bar(self._ctrl.is_connected if self._ctrl else False, True)
        self.log("[GUI] 数据采集已启动")
        # 启动外部 IPC
        if self._ipc_enabled_cb.isChecked():
            try:
                self._ipc_service.start()
            except Exception as exc:
                self._ipc_enabled_cb.setChecked(False)
                self.log(f"[GUI] ZMQ IPC 启动失败: {exc}")
        if self._ipc_namedpipe_cb.isChecked():
            self._ipc_service.start_namedpipe(
                self._cfg.get("external_ipc", {}).get("namedpipe_name", "m1600_control")
            )

    def _on_stop_stream(self) -> None:
        if self._cmd_service is None:
            return
        self._finalize_pending_trigger_events()
        self._cmd_service.stop_acquisition()
        self._stream_start_btn.setEnabled(True)
        self._stream_stop_btn.setEnabled(False)
        self._update_global_bar(self._ctrl.is_connected if self._ctrl else False, False)
        self.log("[GUI] 数据采集已停止")
        # 停止外部 IPC
        self._ipc_service.stop()
        self._ipc_service.stop_namedpipe()

    # ==================================================================
    # 数据记录操作 (使用 CH1600Recorder)
    # ==================================================================

    def _on_browse_save_dir(self) -> None:
        d = QFileDialog.getExistingDirectory(self, "选择保存目录")
        if d:
            self._save_dir_edit.setText(d)

    def _on_start_recording(self) -> None:
        if not (self._ctrl and self._ctrl.is_streaming):
            QMessageBox.warning(self, "未在采集", "请先开始数据采集再记录。\nStart acquisition before recording.")
            return
        save_dir = Path(self._save_dir_edit.text())
        self._recorder = CH1600Recorder(
            output_dir=save_dir,
            max_file_size_mb=self._max_size_spin.value(),
            max_file_rows=self._max_rows_spin.value(),
            rollover_strategy=self._strategy_combo.currentText(),
            device_model=self._device_model,
        )
        try:
            file_path = self._recorder.start()
            self._db_session_id = None
            if self._db_store is not None:
                try:
                    mode_key = self._sample_rate_combo.currentData() or "dc_normal"
                    self._db_session_id = self._db_store.create_session(
                        device_model=self._device_model,
                        probe_profile=self._probe_profile,
                        mode_key=mode_key,
                        display_unit=self._display_unit,
                        range_label=self._range_label.text(),
                        up_threshold=float(self._up_thresh_edit.text() or 0.0),
                        low_threshold=float(self._low_thresh_edit.text() or 0.0),
                        threshold_channel=self._threshold_channel_key(),
                        source="realtime",
                        notes=f"csv={file_path}",
                    )
                except Exception as exc:
                    self.log(f"[DB] 创建 session 失败: {exc}")
            self._rec_start_btn.setEnabled(False)
            self._rec_stop_btn.setEnabled(True)
            self._rec_stats_label.setText(f"记录中: {file_path.name} | 0 行 | 0.0 MB")
            self._rec_stats_label.setStyleSheet("")
            self._rec_stats_timer.start()
            self._update_global_bar(
                self._ctrl.is_connected if self._ctrl else False,
                self._ctrl.is_streaming if self._ctrl else False,
            )
            self.log(f"[GUI] 开始记录: {file_path}")
        except OSError as exc:
            self.log(f"[GUI] 记录失败: {exc}")
            self._recorder = None

    def _on_stop_recording(self) -> None:
        self._rec_stats_timer.stop()
        self._finalize_pending_trigger_events()
        if self._recorder:
            self._recorder.stop()
            row_count = self._recorder.row_count
            file_path = self._recorder.file_path
            self._recorder = None
            if self._db_store is not None and self._db_session_id is not None:
                try:
                    self._db_store.close_session(self._db_session_id)
                except Exception as exc:
                    self.log(f"[DB] 关闭 session 失败: {exc}")
                self._db_session_id = None
            self.log(f"[GUI] 停止记录: {file_path} ({row_count} 行)")
        self._rec_start_btn.setEnabled(True)
        self._rec_stop_btn.setEnabled(False)
        self._rec_stats_label.setText("记录已停止")
        self._rec_stats_label.setStyleSheet("")
        self._update_global_bar(
            self._ctrl.is_connected if self._ctrl else False,
            self._ctrl.is_streaming if self._ctrl else False,
        )

    def _update_rec_stats(self) -> None:
        """记录统计定时器回调: 更新文件大小、行数, 检测 rollover 停止。"""
        if not (self._recorder and self._recorder.is_recording):
            return

        if self._recorder.stopped_by_rollover:
            self._rec_stats_timer.stop()
            reason = self._recorder.rollover_reason or "未知"
            reason_text = {"rows": "行数", "size": "大小"}.get(reason, reason)
            self._rec_stats_label.setText(f"已停止: 达到上限 (原因: {reason_text})")
            self._rec_stats_label.setStyleSheet("color: #e04040; font-weight: 700;")
            self._rec_start_btn.setEnabled(True)
            self._rec_stop_btn.setEnabled(False)
            self._recorder = None
            if self._db_store is not None and self._db_session_id is not None:
                try:
                    self._db_store.close_session(self._db_session_id)
                except Exception:
                    pass
                self._db_session_id = None
            self._update_global_bar(
                self._ctrl.is_connected if self._ctrl else False,
                self._ctrl.is_streaming if self._ctrl else False,
            )
            return

        fname = self._recorder.file_path.name if self._recorder.file_path else "?"
        rows = self._recorder.row_count
        size_mb = self._recorder.current_file_size_mb
        self._rec_stats_label.setText(
            f"记录中: {fname} | {rows:,} 行 | {size_mb:.1f} MB"
        )

    def _get_export_source(self) -> Tuple[Path, str] | Tuple[None, None]:
        """返回 (csv_path, suggested_name) 或 (None, None)。"""
        if self._recorder and self._recorder.file_path:
            return self._recorder.file_path, self._recorder.file_path.stem
        file_path, _ = QFileDialog.getOpenFileName(
            self, "选择 CSV 数据源 / Select CSV", "", "CSV Files (*.csv)"
        )
        if file_path:
            p = Path(file_path)
            return p, p.stem
        return None, None

    def _on_export_excel(self) -> None:
        src, name = self._get_export_source()
        if src is None:
            return
        out, _ = QFileDialog.getSaveFileName(
            self, "导出 Excel / Export Excel", f"{name}.xlsx", "Excel Files (*.xlsx)"
        )
        if not out:
            return
        try:
            from openpyxl import Workbook
            from openpyxl.styles import Font, Alignment, Border, Side

            wb = Workbook()
            ws = wb.active
            ws.title = "CH1600 Data"

            header_font = Font(name="宋体", size=12, bold=True)
            header_align = Alignment(horizontal="center", vertical="center")
            thin_border = Border(
                left=Side(style="thin"), right=Side(style="thin"),
                top=Side(style="thin"), bottom=Side(style="thin")
            )

            with open(src, "r", encoding="utf-8-sig", newline="") as f:
                reader = csv.reader(f)
                for ridx, row in enumerate(reader, start=1):
                    for cidx, val in enumerate(row, start=1):
                        cell = ws.cell(row=ridx, column=cidx, value=f"'{val}" if ridx > 1 else val)
                        cell.border = thin_border
                        if ridx == 1:
                            cell.font = header_font
                            cell.alignment = header_align

            wb.save(out)
            self.log(f"[GUI] 导出 Excel 成功: {out}")
            QMessageBox.information(self, "导出成功", f"已保存到:\n{out}")
        except Exception as exc:
            self.log(f"[GUI] 导出 Excel 失败: {exc}")
            QMessageBox.critical(self, "导出失败", str(exc))

    def _on_export_txt(self) -> None:
        src, name = self._get_export_source()
        if src is None:
            return
        out, _ = QFileDialog.getSaveFileName(
            self, "导出 TXT / Export TXT", f"{name}.txt", "Text Files (*.txt)"
        )
        if not out:
            return
        try:
            with open(src, "r", encoding="utf-8-sig", newline="") as f_in:
                reader = csv.reader(f_in)
                with open(out, "w", encoding="utf-8-sig", newline="") as f_out:
                    writer = csv.writer(f_out, delimiter="\t")
                    for row in reader:
                        writer.writerow(row)
            self.log(f"[GUI] 导出 TXT 成功: {out}")
            QMessageBox.information(self, "导出成功", f"已保存到:\n{out}")
        except Exception as exc:
            self.log(f"[GUI] 导出 TXT 失败: {exc}")
            QMessageBox.critical(self, "导出失败", str(exc))

    # ==================================================================
    # 信号处理 — 来自 CommandService 的广播
    # ==================================================================

    def _update_live_display(self, latest: Dict[str, float], mode: dict, dec: int) -> None:
        """根据设备型号更新实时数值显示 (Field/Freq/Temp)。"""
        model = self._device_model
        cap = get_device_capability(model)
        unit = self._display_unit

        if cap.measurement_dimension == 1:
            field_raw = latest.get("field_mt", 0.0)
            field_display = self._convert_field_display(field_raw)
            self._field_label.setText(f"{field_display:.{dec}f} {unit}")
            self._update_judge_status(self._threshold_value_from_latest(latest))
        elif cap.measurement_dimension == 2:
            x = self._convert_field_display(latest.get("field_x_mt", 0.0))
            y = self._convert_field_display(latest.get("field_y_mt", 0.0))
            t = self._convert_field_display(latest.get("field_total_mt", 0.0))
            self._field_label.setText(f"X:{x:.{dec}f} Y:{y:.{dec}f} B:{t:.{dec}f} {unit}")
            self._update_judge_status(self._threshold_value_from_latest(latest))
        elif cap.measurement_dimension == 3:
            x = self._convert_field_display(latest.get("field_x_mt", 0.0))
            y = self._convert_field_display(latest.get("field_y_mt", 0.0))
            z = self._convert_field_display(latest.get("field_z_mt", 0.0))
            t = self._convert_field_display(latest.get("field_total_mt", 0.0))
            self._field_label.setText(f"X:{x:.{dec}f} Y:{y:.{dec}f} Z:{z:.{dec}f} B:{t:.{dec}f} {unit}")
            self._update_judge_status(self._threshold_value_from_latest(latest))
        else:
            field_raw = latest.get("field_mt", 0.0)
            field_display = self._convert_field_display(field_raw)
            self._field_label.setText(f"{field_display:.{dec}f} {unit}")
            self._update_judge_status(self._threshold_value_from_latest(latest))

        if cap.has_freq:
            freq = latest.get("freq_hz", 0.0)
            if freq < 0.01:
                self._freq_label.setText("DC")
            else:
                self._freq_label.setText(f"{freq:.0f} Hz")
        else:
            self._freq_label.setText("—")

        if cap.has_temp:
            temp = latest.get("temp_c", 0.0)
            self._temp_label.setText(f"{temp:.1f} °C")
        else:
            self._temp_label.setText("—")

    def _update_judge_status(self, field_mt: float) -> None:
        """阈值判断: 根据上下限和判断模式更新状态标签。"""
        try:
            up = float(self._up_thresh_edit.text())
            low = float(self._low_thresh_edit.text())
        except ValueError:
            self._judge_status_label.setText("未启用 / Disabled")
            self._judge_status_label.setStyleSheet("background-color: #f0f0f0; color: #666;")
            return

        # 如果上下限都为 0，视为未启用
        if up == 0.0 and low == 0.0:
            self._judge_status_label.setText("未启用 / Disabled")
            self._judge_status_label.setStyleSheet("background-color: #f0f0f0; color: #666;")
            return

        # ABS 模式
        val = abs(field_mt) if self._judge_abs_cb.isChecked() else field_mt
        low_v = abs(low) if self._judge_abs_cb.isChecked() else low
        up_v = abs(up) if self._judge_abs_cb.isChecked() else up

        # 确保 low <= up
        if low_v > up_v:
            low_v, up_v = up_v, low_v

        in_range = low_v <= val <= up_v
        is_open = self._judge_mode_combo.currentIndex() == 1  # 1 = 开区间

        if is_open:
            # 开区间: 范围内 = NG, 范围外 = OK
            if in_range:
                self._judge_status_label.setText("NG")
                self._judge_status_label.setStyleSheet(
                    "background-color: #e04040; color: #ffffff; font-weight: 700; border-radius: 4px; padding: 4px 12px;"
                )
            else:
                self._judge_status_label.setText("OK")
                self._judge_status_label.setStyleSheet(
                    "background-color: #00a651; color: #ffffff; font-weight: 700; border-radius: 4px; padding: 4px 12px;"
                )
        else:
            # 闭区间: 范围内 = OK, 范围外 = NG
            if in_range:
                self._judge_status_label.setText("OK")
                self._judge_status_label.setStyleSheet(
                    "background-color: #00a651; color: #ffffff; font-weight: 700; border-radius: 4px; padding: 4px 12px;"
                )
            else:
                self._judge_status_label.setText("NG")
                self._judge_status_label.setStyleSheet(
                    "background-color: #e04040; color: #ffffff; font-weight: 700; border-radius: 4px; padding: 4px 12px;"
                )

    def _on_stream_batch(self, batch: dict) -> None:
        """批量数据: 应用零偏、更新数值显示、推入 CircularBuffer、CSV 记录。"""
        points = batch.get("points", [])
        if not points:
            return

        # 应用软件零点偏移。多轴设备按分量归零并重新计算 Total B。
        if self._zero_offset != 0.0 or self._zero_offsets:
            points = [self._apply_zero_offsets_to_point(p) for p in points]

        # 用批量中的最新点更新数值显示
        latest = points[-1] if points else batch.get("latest", {})
        if latest:
            mode = self._get_active_acq_mode()
            dec = mode["decimals"]
            self._update_live_display(latest, mode, dec)

        self._total_points += len(points)
        first_sequence = self._total_points - len(points) + 1
        for i, p in enumerate(points):
            p["_sequence"] = first_sequence + i

        # 推入环形缓冲区 (图表用)
        timestamps = [p.get("timestamp_s", 0.0) for p in points]
        buffer_data: Dict[str, List[float]] = {}
        for ch in self._buffer.get_channels():
            buffer_data[ch] = [p.get(ch, 0.0) for p in points]
        self._buffer.extend(buffer_data, timestamps)
        self._process_trigger_points(points)

        # 更新实时数据表格
        for i, p in enumerate(points):
            sequence = int(p.get("_sequence", first_sequence + i))
            self._pending_live_table_rows.append(self._live_table_row_values(sequence, p))
        max_pending = max(self._table_max_rows_spin.value() * 2, 1000)
        if len(self._pending_live_table_rows) > max_pending:
            self._pending_live_table_rows = self._pending_live_table_rows[-max_pending:]

        # CSV 记录 (使用 CH1600Recorder)
        if self._recorder and self._recorder.is_recording:
            try:
                self._recorder.write_batch(points)
            except Exception:
                pass

        # SQLite session store (query/review/provenance)
        if self._db_store is not None and self._db_session_id is not None:
            try:
                first_seq = first_sequence
                db_points = []
                raw_frames = []
                for i, p in enumerate(points):
                    sequence = first_seq + i
                    db_point = normalize_sample_by_capability(p, self._device_model)
                    db_point["sequence"] = sequence
                    db_point["device_model"] = self._device_model
                    db_point["source"] = "realtime"
                    db_point["field_unit"] = self._default_unit_for_model()
                    db_points.append(db_point)
                    raw_frame = p.get("_raw_frame")
                    if raw_frame and self._cfg.get("database", {}).get("store_raw_frames", True):
                        raw_frames.append({
                            "sequence": sequence,
                            "timestamp_s": p.get("timestamp_s", 0.0),
                            "direction": "RX",
                            "frame": raw_frame,
                            "parsed_ok": True,
                        })
                self._db_store.append_samples(
                    self._db_session_id,
                    db_points,
                    source="realtime",
                    device_model=self._device_model,
                    field_unit=self._default_unit_for_model(),
                )
                if raw_frames:
                    self._db_store.append_raw_frames(self._db_session_id, raw_frames)
            except Exception as exc:
                self.log(f"[DB] 写入样本失败: {exc}")

        # 外部 IPC 广播
        if latest:
            self._ipc_service.publish_data(
                timestamp_s=latest.get("timestamp_s", 0.0),
                field_x_mt=latest.get("field_x_mt", 0.0),
                field_y_mt=latest.get("field_y_mt", 0.0),
                field_z_mt=latest.get("field_z_mt", 0.0),
                field_total_mt=latest.get("field_total_mt", latest.get("field_mt", 0.0)),
                freq_hz=latest.get("freq_hz", 0.0),
                temp_c=latest.get("temp_c", 0.0),
            )

    def _on_state_changed(self, state: dict) -> None:
        """设备状态更新。"""
        unit = state.get("unit", "--")
        rng = state.get("range", "--")
        self._unit_label.setText(unit)
        self._range_label.setText(rng)

        panel_streaming = state.get("panel_streaming", False)
        if panel_streaming:
            self._status_label.setText("面板实时发送模式 — 指令不可用 / Panel Streaming — No Commands")
        elif self._ctrl and self._ctrl.is_connected:
            self._status_label.setText("就绪 / Ready")

        if self._ctrl:
            mode = self._get_active_acq_mode()
            short_label = mode["label"].split("(")[0].strip()
            self._global_info.setText(f"{unit} | {rng} | {short_label}")

    def _on_error(self, msg: str) -> None:
        self.log(f"[ERROR] {msg}")

    def _on_log(self, msg: str) -> None:
        self.log(msg)

    def _on_command_completed(self, req_id: str, result: object) -> None:
        pass  # 静默处理, 日志已在各方法中记录

    def _on_command_error(self, req_id: str, error: str) -> None:
        self.log(f"[CMD ERROR] {req_id}: {error}")

    # ==================================================================
    # 显示刷新 (30ms QTimer)
    # ==================================================================

    def _on_display_tick(self) -> None:
        """定时器回调, 刷新 pyqtgraph 图表 (目标 ~33 FPS)。"""
        if not _HAS_PYG or self._plot_widget is None:
            return

        # FPS 计数 (始终更新, 不受暂停影响)
        self._display_count += 1
        now = time.time()
        elapsed = max(now - self._display_fps_ts, 0.001)
        if elapsed >= 1.0:
            self._display_fps = self._display_count / elapsed
            self._display_count = 0
            self._display_fps_ts = now

        # 根据采集模式选择图表参数
        mode = self._get_active_acq_mode()
        ds = mode["downsample"]
        x_window = mode["x_window_s"]
        max_pts = int(self._cfg.get("ui", {}).get("chart_history_points", 5000) or 5000)

        # 图表更新 — 暂停时跳过
        if not self._display_paused:
            # 主磁场曲线 (Total B)
            total_ch = "field_mt" if "field_mt" in self._buffer.get_channels() else "field_total_mt"
            raw_ts_arr, raw_vals = self._buffer.get(total_ch, max_points=max_pts, downsample=1)
            ts_arr, vals = self._buffer.get(total_ch, max_points=max_pts, downsample=ds)
            if len(ts_arr) > 0:
                ts_rel = ts_arr - ts_arr[-1]  # 相对时间 (秒)
                self._field_curve.setData(ts_rel, vals)
                self._live_cursor_data = (np.asarray(ts_rel, dtype=float), np.asarray(vals, dtype=float))
                raw_ts_rel = raw_ts_arr - raw_ts_arr[-1] if len(raw_ts_arr) > 0 else ts_rel
                metric_vals = raw_vals if len(raw_vals) > 0 else vals
                analysis = analyze_time_series(raw_ts_rel, metric_vals)
                self._last_live_analysis[total_ch] = analysis
                if hasattr(self, "_live_mean_line"):
                    self._live_mean_line.setPos(analysis["mean"])
                    self._live_mean_line.setVisible(True)
                self._update_live_measurements(raw_ts_rel, metric_vals, total_ch)
                self._update_live_reference_lines()
                self._update_live_cursor_readout()
                self._update_live_peak_markers()
                self._update_trigger_markers(float(ts_arr[-1]))

                # 多通道分量曲线
                if "field_x_mt" in self._buffer.get_channels():
                    ts_x, vx = self._buffer.get("field_x_mt", max_points=max_pts, downsample=ds)
                    if len(ts_x) > 0:
                        self._field_x_curve.setData(ts_x - ts_x[-1], vx)
                if "field_y_mt" in self._buffer.get_channels():
                    ts_y, vy = self._buffer.get("field_y_mt", max_points=max_pts, downsample=ds)
                    if len(ts_y) > 0:
                        self._field_y_curve.setData(ts_y - ts_y[-1], vy)
                if "field_z_mt" in self._buffer.get_channels():
                    ts_z, vz = self._buffer.get("field_z_mt", max_points=max_pts, downsample=ds)
                    if len(ts_z) > 0:
                        self._field_z_curve.setData(ts_z - ts_z[-1], vz)

                # 固定 X 轴窗口 (滚动视图)
                self._plot_widget.setXRange(-x_window, 0.5, padding=0)

                # Y 轴范围
                if self._auto_y_cb.isChecked():
                    self._plot_widget.autoRange()
                else:
                    self._plot_widget.setYRange(self._chart_y_min, self._chart_y_max, padding=0)

            # 频率曲线
            if self._show_freq_cb.isChecked() and "freq_hz" in self._buffer.get_channels():
                ts_f, v_f = self._buffer.get("freq_hz", max_points=max_pts, downsample=ds)
                if len(ts_f) > 0:
                    ts_f_rel = ts_f - ts_f[-1]
                    self._freq_curve.setData(ts_f_rel, v_f)

        # 统计 — 显示实际 FPS 和期望 FPS
        pause_indicator = " [PAUSED]" if self._display_paused else ""
        self._live_stats.setText(
            f"FPS: {self._display_fps:.1f} (期望~{mode['expect_fps']} Hz) | "
            f"数据点: {self._total_points} | 模式: {mode['label'].split('(')[0].strip()}"
            f"{pause_indicator}"
        )

        self._global_fps.setText(f"FPS: {self._display_fps:.1f}")
        self._global_pts.setText(f"{self._total_points} pts")

        # 记录统计由 _update_rec_stats 定时器处理

    def _on_toggle_freq_curve(self, visible: bool) -> None:
        if hasattr(self, '_freq_curve'):
            self._freq_curve.setVisible(visible)

    def _format_metric_value(self, value: float, *, unit: str = "", precision: int = 4) -> str:
        if not np.isfinite(value):
            return "--"
        suffix = f" {unit}" if unit else ""
        return f"{value:.{precision}g}{suffix}"

    def _update_live_measurements(self, ts_rel: np.ndarray, vals: np.ndarray, total_ch: str) -> None:
        if not hasattr(self, "_live_metric_labels"):
            return
        unit = self._display_unit
        scale = self._UNIT_CONVERSION.get(unit, 1.0)
        analysis = analyze_time_series(ts_rel, vals * scale)
        self._live_metric_labels["current"].setText(self._format_metric_value(analysis["current"], unit=unit))
        self._live_metric_labels["min"].setText(self._format_metric_value(analysis["min"], unit=unit))
        self._live_metric_labels["max"].setText(self._format_metric_value(analysis["max"], unit=unit))
        self._live_metric_labels["peak_to_peak"].setText(self._format_metric_value(analysis["peak_to_peak"], unit=unit))
        self._live_metric_labels["rms"].setText(self._format_metric_value(analysis["rms"], unit=unit))
        self._live_metric_labels["std"].setText(self._format_metric_value(analysis["std"], unit=unit))
        self._live_metric_labels["sample_rate_hz"].setText(self._format_metric_value(analysis["sample_rate_hz"], unit="Hz"))
        self._live_metric_labels["duration_s"].setText(self._format_metric_value(analysis["duration_s"], unit="s"))
        try:
            low = float(self._low_thresh_edit.text())
            high = float(self._up_thresh_edit.text())
            threshold_ch = self._threshold_buffer_channel()
            if threshold_ch == total_ch:
                threshold_ts = ts_rel
                threshold_vals = vals
            elif threshold_ch in self._buffer.get_channels():
                threshold_ts_abs, threshold_vals = self._buffer.get(
                    threshold_ch, max_points=len(vals), downsample=1
                )
                threshold_ts = threshold_ts_abs - threshold_ts_abs[-1] if len(threshold_ts_abs) else threshold_ts_abs
            else:
                threshold_ts = np.array([])
                threshold_vals = np.array([])
            thresh = analyze_threshold_events(
                threshold_ts,
                threshold_vals,
                low=low,
                high=high,
                absolute=self._judge_abs_cb.isChecked(),
                mode="open" if self._judge_mode_combo.currentIndex() == 1 else "closed",
            )
            if thresh.get("enabled"):
                self._live_metric_labels["threshold"].setText(
                    f"NG {thresh['ng_count']} / {thresh['event_count']} 次"
                )
            else:
                self._live_metric_labels["threshold"].setText("--")
        except ValueError:
            self._live_metric_labels["threshold"].setText("--")
        channels = self._buffer.get_channels()
        if "field_x_mt" in channels and "field_y_mt" in channels:
            _, vx = self._buffer.get("field_x_mt", max_points=len(vals), downsample=1)
            _, vy = self._buffer.get("field_y_mt", max_points=len(vals), downsample=1)
            vz = None
            if "field_z_mt" in channels:
                _, vz_arr = self._buffer.get("field_z_mt", max_points=len(vals), downsample=1)
                vz = vz_arr
            vector = analyze_vector_components(vx, vy, vz)
            self._live_metric_labels["vector"].setText(
                f"XY {vector['direction_xy_deg']:.1f}° / σ {vector['direction_std_deg']:.1f}°"
            )
        else:
            self._live_metric_labels["vector"].setText("--")

    def _update_live_reference_lines(self) -> None:
        if not hasattr(self, "_live_thresh_low_line"):
            return
        try:
            low = float(self._low_thresh_edit.text())
            high = float(self._up_thresh_edit.text())
        except ValueError:
            low = high = 0.0
        enabled = not (low == 0.0 and high == 0.0)
        self._live_thresh_low_line.setVisible(enabled)
        self._live_thresh_high_line.setVisible(enabled)
        if enabled:
            self._live_thresh_low_line.setPos(low)
            self._live_thresh_high_line.setPos(high)

    def _on_toggle_live_cursors(self, visible: bool) -> None:
        for item in (getattr(self, "_live_cursor_a", None), getattr(self, "_live_cursor_b", None), getattr(self, "_live_cursor_label", None)):
            if item is not None:
                item.setVisible(visible)
        self._update_live_cursor_readout()

    def _on_toggle_review_cursors(self, visible: bool) -> None:
        for item in (getattr(self, "_review_cursor_a", None), getattr(self, "_review_cursor_b", None), getattr(self, "_review_cursor_label", None)):
            if item is not None:
                item.setVisible(visible)
        self._update_review_cursor_readout()

    def _cursor_text(self, cursor_a, cursor_b, data_pair: Tuple[np.ndarray, np.ndarray]) -> Tuple[str, float, float]:
        xs, ys = data_pair
        if xs.size == 0 or ys.size == 0:
            return "", 0.0, 0.0
        x1 = float(cursor_a.value())
        x2 = float(cursor_b.value())
        order = np.argsort(xs)
        sx = xs[order]
        sy = ys[order]
        y1 = float(np.interp(x1, sx, sy))
        y2 = float(np.interp(x2, sx, sy))
        text = f"t1={x1:.3f}s t2={x2:.3f}s Δt={abs(x2-x1):.3f}s\nY1={y1:.6g} Y2={y2:.6g} ΔY={y2-y1:.6g}"
        return text, min(x1, x2), max(y1, y2)

    def _update_live_cursor_readout(self) -> None:
        if not getattr(self, "_live_cursor_cb", None) or not self._live_cursor_cb.isChecked():
            return
        if getattr(self, "_live_cursor_label", None) is None:
            return
        text, x, y = self._cursor_text(self._live_cursor_a, self._live_cursor_b, self._live_cursor_data)
        self._live_cursor_label.setText(text)
        self._live_cursor_label.setPos(x, y)

    def _update_review_cursor_readout(self) -> None:
        if not getattr(self, "_review_cursor_cb", None) or not self._review_cursor_cb.isChecked():
            return
        if getattr(self, "_review_cursor_label", None) is None:
            return
        text, x, y = self._cursor_text(self._review_cursor_a, self._review_cursor_b, self._review_cursor_data)
        self._review_cursor_label.setText(text)
        self._review_cursor_label.setPos(x, y)

    def _clear_peak_labels(self, plot_widget, labels: list) -> None:
        while labels:
            item = labels.pop()
            try:
                plot_widget.removeItem(item)
            except Exception:
                pass

    def _add_peak_labels(self, plot_widget, labels: list, xs: np.ndarray, ys: np.ndarray) -> None:
        finite = np.isfinite(xs) & np.isfinite(ys)
        if not np.any(finite):
            return
        xs = xs[finite]
        ys = ys[finite]
        for idx, name in ((int(np.argmax(ys)), "MAX"), (int(np.argmin(ys)), "MIN")):
            item = pg.TextItem(f"{name}\n{ys[idx]:.6g}", color="#ffaa00", anchor=(0.5, 1.0))
            item.setPos(float(xs[idx]), float(ys[idx]))
            plot_widget.addItem(item)
            labels.append(item)

    def _update_live_peak_markers(self) -> None:
        if not _HAS_PYG or not hasattr(self, "_live_peak_labels"):
            return
        self._clear_peak_labels(self._plot_widget, self._live_peak_labels)
        if not getattr(self, "_live_peaks_cb", None) or not self._live_peaks_cb.isChecked():
            return
        xs, ys = self._live_cursor_data
        self._add_peak_labels(self._plot_widget, self._live_peak_labels, xs, ys)

    def _update_review_peak_markers(self) -> None:
        if not _HAS_PYG or not hasattr(self, "_review_peak_labels"):
            return
        self._clear_peak_labels(self._review_plot_widget, self._review_peak_labels)
        if not getattr(self, "_review_peaks_cb", None) or not self._review_peaks_cb.isChecked():
            return
        xs, ys = self._review_cursor_data
        self._add_peak_labels(self._review_plot_widget, self._review_peak_labels, xs, ys)

    def _on_trigger_enabled_changed(self, checked: bool) -> None:
        self._trigger_armed = checked
        self._trigger_prev_value = None
        self._trigger_prev_threshold_ng = None
        self._update_trigger_status()

    def _arm_trigger(self) -> None:
        self._trigger_armed = True
        self._trigger_prev_value = None
        self._trigger_prev_threshold_ng = None
        if hasattr(self, "_trigger_enabled_cb"):
            self._trigger_enabled_cb.setChecked(True)
        self._update_trigger_status()

    def _clear_trigger_events(self) -> None:
        self._trigger_events.clear()
        self._trigger_pending_events.clear()
        self._trigger_pre_points.clear()
        self._trigger_prev_threshold_ng = None
        if hasattr(self, "_trigger_marker_item"):
            self._trigger_marker_item.setData([], [])
        if hasattr(self, "_trigger_event_table"):
            self._trigger_event_table.setRowCount(0)
        self._update_trigger_status()
        self.log("[GUI] 触发事件已清空")

    def _trigger_point_value(self, point: Dict[str, float]) -> float:
        return self._threshold_value_from_latest(point)

    def _point_is_threshold_ng(self, point: Dict[str, float]) -> bool:
        try:
            up = float(self._up_thresh_edit.text())
            low = float(self._low_thresh_edit.text())
        except ValueError:
            return False
        if up == 0.0 and low == 0.0:
            return False
        value = self._trigger_point_value(point)
        if self._judge_abs_cb.isChecked():
            value = abs(value)
            low = abs(low)
            up = abs(up)
        if low > up:
            low, up = up, low
        in_range = low <= value <= up
        return in_range if self._judge_mode_combo.currentIndex() == 1 else not in_range

    def _process_trigger_points(self, points: List[Dict[str, float]]) -> None:
        if not hasattr(self, "_trigger_enabled_cb"):
            return
        pre_limit = int(self._trigger_pre_spin.value()) if hasattr(self, "_trigger_pre_spin") else 50
        post_limit = int(self._trigger_post_spin.value()) if hasattr(self, "_trigger_post_spin") else 50
        mode = self._trigger_mode_combo.currentData()
        try:
            level = float(self._trigger_level_edit.text() or 0.0)
        except ValueError:
            level = 0.0
        for point in points:
            compact = self._compact_trigger_point(point)
            self._extend_pending_trigger_events(compact)
            if not self._trigger_enabled_cb.isChecked() or not self._trigger_armed:
                self._append_trigger_pre_point(compact, pre_limit)
                continue
            value = self._trigger_point_value(point)
            triggered = False
            if mode == "threshold":
                is_ng = self._point_is_threshold_ng(point)
                triggered = is_ng and self._trigger_prev_threshold_ng is not True
                self._trigger_prev_threshold_ng = is_ng
            elif mode == "rising" and self._trigger_prev_value is not None:
                triggered = self._trigger_prev_value < level <= value
            elif mode == "falling" and self._trigger_prev_value is not None:
                triggered = self._trigger_prev_value > level >= value
            self._trigger_prev_value = value
            if not triggered:
                self._append_trigger_pre_point(compact, pre_limit)
                continue
            sequence = int(point.get("_sequence", self._total_points))
            event = {
                "id": self._trigger_next_event_id,
                "timestamp_s": float(point.get("timestamp_s", 0.0)),
                "value": float(value),
                "mode": str(mode),
                "sequence": sequence,
                "channel": self._threshold_channel_key(),
                "level": level if mode in {"rising", "falling"} else None,
                "window_points": list(self._trigger_pre_points) + [compact],
                "pre_points": len(self._trigger_pre_points),
                "post_points": 0,
                "post_remaining": post_limit,
                "db_id": None,
            }
            self._trigger_next_event_id += 1
            self._trigger_events.append(event)
            if len(self._trigger_events) > self._trigger_max_events:
                self._trigger_events = self._trigger_events[-self._trigger_max_events:]
            if post_limit > 0:
                self._trigger_pending_events.append(event)
            else:
                self._finalize_trigger_event(event)
            self.log(
                f"[TRIGGER] {event['mode']} t={event['timestamp_s']:.6f}s value={event['value']:.6g}"
            )
            if self._trigger_single_cb.isChecked():
                self._trigger_armed = False
            self._append_trigger_pre_point(compact, pre_limit)
        self._update_trigger_status()
        self._update_trigger_event_table()

    def _compact_trigger_point(self, point: Dict[str, float]) -> Dict[str, float]:
        keys = (
            "_sequence", "timestamp_s", "field_mt", "field_x_mt", "field_y_mt", "field_z_mt",
            "field_total_mt", "freq_hz", "temp_c",
        )
        compact: Dict[str, float] = {}
        for key in keys:
            if key in point:
                try:
                    compact[key] = float(point[key])
                except (TypeError, ValueError):
                    pass
        return compact

    def _append_trigger_pre_point(self, point: Dict[str, float], limit: int) -> None:
        if limit <= 0:
            self._trigger_pre_points = []
            return
        self._trigger_pre_points.append(dict(point))
        if len(self._trigger_pre_points) > limit:
            self._trigger_pre_points = self._trigger_pre_points[-limit:]

    def _extend_pending_trigger_events(self, point: Dict[str, float]) -> None:
        if not self._trigger_pending_events:
            return
        remaining_events = []
        for event in self._trigger_pending_events:
            if int(event.get("post_remaining", 0)) <= 0:
                self._finalize_trigger_event(event)
                continue
            event.setdefault("window_points", []).append(dict(point))
            event["post_remaining"] = int(event.get("post_remaining", 0)) - 1
            event["post_points"] = int(event.get("post_points", 0)) + 1
            if int(event.get("post_remaining", 0)) <= 0:
                self._finalize_trigger_event(event)
            else:
                remaining_events.append(event)
        self._trigger_pending_events = remaining_events

    def _finalize_pending_trigger_events(self) -> None:
        if not self._trigger_pending_events:
            return
        for event in list(self._trigger_pending_events):
            self._finalize_trigger_event(event)
        self._trigger_pending_events.clear()
        self._update_trigger_event_table()

    def _finalize_trigger_event(self, event: Dict[str, Any]) -> None:
        if event.get("db_id") is not None:
            return
        if self._db_store is None:
            event["db_id"] = ""
            return
        try:
            event["db_id"] = self._db_store.append_trigger_event(
                session_id=self._db_session_id,
                timestamp_s=float(event.get("timestamp_s", 0.0)),
                value=float(event.get("value", 0.0)),
                channel=str(event.get("channel", self._threshold_channel_key())),
                mode=str(event.get("mode", "")),
                sequence=int(event.get("sequence", 0)),
                level=event.get("level"),
                pre_points=int(event.get("pre_points", 0)),
                post_points=int(event.get("post_points", 0)),
                window_points=list(event.get("window_points", [])),
            )
        except Exception as exc:
            event["db_id"] = ""
            self.log(f"[DB] 保存触发事件失败: {exc}")

    def _update_trigger_event_table(self) -> None:
        if not hasattr(self, "_trigger_event_table"):
            return
        rows = self._trigger_events[-20:]
        self._trigger_event_table.setRowCount(len(rows))
        for row_idx, event in enumerate(rows):
            values = [
                str(event.get("id", row_idx + 1)),
                f"{float(event.get('timestamp_s', 0.0)):.6f}",
                str(event.get("mode", "")),
                f"{float(event.get('value', 0.0)):.6g}",
                str(len(event.get("window_points", []))),
                str(event.get("db_id", "")),
            ]
            for col_idx, value in enumerate(values):
                self._trigger_event_table.setItem(row_idx, col_idx, QTableWidgetItem(value))
        self._trigger_event_table.scrollToBottom()

    def _selected_trigger_event(self) -> Optional[Dict[str, Any]]:
        if not hasattr(self, "_trigger_event_table") or not self._trigger_events:
            return self._trigger_events[-1] if self._trigger_events else None
        selected = self._trigger_event_table.selectionModel().selectedRows()
        if not selected:
            return self._trigger_events[-1]
        visible_rows = self._trigger_events[-20:]
        row = selected[0].row()
        if 0 <= row < len(visible_rows):
            return visible_rows[row]
        return self._trigger_events[-1]

    def _on_trigger_event_selected(self) -> None:
        event = self._selected_trigger_event()
        if event:
            self._trigger_status_label.setText(
                f"Selected #{event.get('id')} | {event.get('mode')} "
                f"t={float(event.get('timestamp_s', 0.0)):.6f}s | window {len(event.get('window_points', []))}"
            )

    def _replay_last_trigger_event(self) -> None:
        event = self._selected_trigger_event()
        if not event:
            return
        points = event.get("window_points", [])
        if not points or not _HAS_PYG:
            self.log("[TRIGGER] 当前事件没有可回放窗口")
            return
        ts = np.asarray([p.get("timestamp_s", 0.0) for p in points], dtype=float)
        values = np.asarray([
            p.get("field_total_mt", p.get("field_mt", p.get("field_x_mt", 0.0))) for p in points
        ], dtype=float)
        if ts.size == 0:
            return
        ts_rel = ts - float(event.get("timestamp_s", ts[0]))
        self._display_paused = True
        self._pause_btn.setChecked(True)
        self._pause_btn.setText("恢复显示 / Resume")
        self._field_curve.setData(ts_rel, values)
        self._plot_widget.setXRange(float(np.min(ts_rel)), float(np.max(ts_rel)) if ts_rel.size > 1 else 1.0, padding=0.05)
        if values.size:
            margin = max(float(np.ptp(values)) * 0.1, 1e-6)
            self._plot_widget.setYRange(float(np.min(values)) - margin, float(np.max(values)) + margin, padding=0)
        self.log(f"[TRIGGER] 已回放事件 #{event.get('id')}")

    def _update_trigger_status(self) -> None:
        if not hasattr(self, "_trigger_status_label"):
            return
        if not self._trigger_enabled_cb.isChecked():
            self._trigger_status_label.setText("未启用 / Disabled")
            return
        state = "ARMED" if self._trigger_armed else "HOLD"
        last = self._trigger_events[-1] if self._trigger_events else None
        if last:
            self._trigger_status_label.setText(
                f"{state} | 事件 {len(self._trigger_events)} | "
                f"Last: {last['mode']} t={last['timestamp_s']:.6f}s value={last['value']:.6g}"
            )
        else:
            self._trigger_status_label.setText(f"{state} | 等待触发 / Waiting")

    def _update_trigger_markers(self, latest_timestamp: float) -> None:
        if not hasattr(self, "_trigger_marker_item"):
            return
        if not self._trigger_events:
            self._trigger_marker_item.setData([], [])
            return
        xs = []
        ys = []
        window = self._get_active_acq_mode().get("x_window_s", 5.0)
        for event in self._trigger_events:
            x = float(event["timestamp_s"]) - latest_timestamp
            if -window <= x <= 0.5:
                xs.append(x)
                ys.append(float(event["value"]))
        self._trigger_marker_item.setData(xs, ys)

    # ==================================================================
    # 日志
    # ==================================================================

    def log(self, msg: str) -> None:
        ts = datetime.datetime.now().strftime("%H:%M:%S.%f")[:-3]
        self._log_text.append(f"[{ts}] {msg}")
        self._status_label.setText(msg)

    # ==================================================================
    # 关闭
    # ==================================================================

    def closeEvent(self, event) -> None:
        self._finalize_pending_trigger_events()
        if self._ctrl:
            try:
                if self._ctrl.is_streaming and self._cmd_service:
                    self._cmd_service.stop_acquisition()
                if self._ctrl.is_connected:
                    self._ctrl.disconnect()
            except Exception as exc:
                self.log(f"[GUI] 关闭设备失败: {exc}")
        if self._cmd_service:
            self._cmd_service.stop()
        if self._recorder and self._recorder.is_recording:
            self._recorder.stop()
        if self._db_store and self._db_session_id is not None:
            try:
                self._db_store.close_session(self._db_session_id)
            except Exception:
                pass
            self._db_session_id = None
        self._ipc_service.stop()
        self._ipc_service.stop_namedpipe()
        # 保存 IPC 配置
        try:
            ipc_cfg = self._cfg.setdefault("external_ipc", {})
            ipc_cfg["enabled"] = self._ipc_enabled_cb.isChecked() or self._ipc_namedpipe_cb.isChecked()
            if self._ipc_namedpipe_cb.isChecked():
                ipc_cfg["mode"] = "namedpipe"
            elif self._ipc_enabled_cb.isChecked():
                ipc_cfg["mode"] = "zmq"
            ipc_cfg["zmq_data_port"] = self._ipc_data_port_spin.value()
            ipc_cfg["zmq_cmd_port"] = self._ipc_cmd_port_spin.value()
        except Exception:
            pass
        # 保存配置
        try:
            save_config(self._cfg)
        except Exception:
            pass
        if self._db_store:
            try:
                self._db_store.close()
            except Exception:
                pass
        super().closeEvent(event)
