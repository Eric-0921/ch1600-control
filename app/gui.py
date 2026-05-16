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
import time
from pathlib import Path
from typing import Any, Dict, List, Optional

from PyQt5.QtCore import Qt, QTimer
from PyQt5.QtGui import QDoubleValidator
from PyQt5.QtWidgets import (
    QApplication, QCheckBox, QComboBox, QFileDialog, QFrame,
    QGridLayout, QGroupBox, QHBoxLayout, QLabel, QLineEdit, QMainWindow,
    QMenuBar, QMessageBox, QPushButton, QSizePolicy, QSplitter,
    QStackedWidget, QStatusBar, QTextEdit, QTreeWidget, QTreeWidgetItem,
    QVBoxLayout, QWidget,
)

from data.circular_buffer import CircularBuffer
from data.recorder import CH1600Recorder
from core.command_service import CommandService
from core.commands import Command, CommandType
from app.config_io import ACQ_MODE_TABLE, load_config, save_config

try:
    import pyqtgraph as pg
    _HAS_PYG = True
except ImportError:
    _HAS_PYG = False


# ------------------------------------------------------------------
# Siemens 工业风样式表 (复用 odmr-control)
# ------------------------------------------------------------------

SIEMENS_STYLE = """
QMainWindow, QWidget {
    background-color: #f0f0f0;
    color: #1a1a1a;
    font-family: "Segoe UI", "Microsoft YaHei", "PingFang SC", sans-serif;
    font-size: 12px;
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
    font-family: Consolas, "Courier New", monospace;
    font-size: 22px; font-weight: 700; color: #005c8a;
    padding: 10px; border: 1px solid #c0c0c0; border-radius: 3px;
    background-color: #f8f8f8;
}
QLabel#smallData {
    font-family: Consolas, "Courier New", monospace;
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
    font-family: Consolas, "Courier New", monospace; font-size: 11px;
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

    def __init__(self, cmd_service: CommandService | None = None) -> None:
        super().__init__()
        self.setWindowTitle("CH-1600 数字高斯计 / CH-1600 Digital Gauss Meter")
        self.setMinimumSize(1200, 800)

        # 配置
        self._cfg = load_config()

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
        else:
            self._ctrl = None

        # 数据缓冲
        buffer_cap = self._cfg.get("ui", {}).get("chart_history_points", 5000)
        self._buffer = CircularBuffer(
            channels=["field_mt", "freq_hz", "temp_c"],
            capacity=buffer_cap,
        )

        # 记录
        self._recorder: Optional[CH1600Recorder] = None

        # 软件零点偏移 (仅主线程读写, 无需加锁)
        self._zero_offset: float = self._cfg.get("acquisition", {}).get("zero_offset", 0.0)

        # 显示暂停
        self._display_paused = False

        # FPS 跟踪
        self._display_fps = 0.0
        self._display_count = 0
        self._display_fps_ts = time.time()
        self._total_points = 0

        # 应用样式
        self.setStyleSheet(SIEMENS_STYLE)

        # 构建 UI
        self._setup_ui()

        # 显示更新定时器
        display_ms = self._cfg.get("ui", {}).get("display_interval_ms", 30)
        self._display_timer = QTimer(self)
        self._display_timer.timeout.connect(self._on_display_tick)
        self._display_timer.start(max(16, display_ms))  # 最低 ~60 FPS cap

        # 初始化全局状态栏
        self._update_global_bar(False, False)

        # 恢复保存的采集模式
        saved_mode = self._cfg.get("acquisition", {}).get("mode_key", "dc_normal")
        idx = self._sample_rate_combo.findData(saved_mode)
        if idx >= 0:
            self._sample_rate_combo.setCurrentIndex(idx)
        self._on_acq_mode_changed()

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
            ("日志 / Log", 3),
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
        page = QWidget()
        layout = QVBoxLayout(page)
        layout.setContentsMargins(16, 16, 16, 16)

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

        # 模式信息
        self._acq_info_label = QLabel()
        self._acq_info_label.setObjectName("smallData")
        self._acq_info_label.setWordWrap(True)
        ag.addWidget(self._acq_info_label, 2, 0, 1, 2)

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
            "<b>▶ 采集速率调节：</b><br>"
            "  按前面板 <b>[Menu]</b> 键进入菜单 → 找到采集速度选项 →<br>"
            "  &nbsp;&nbsp;用 ▲▼ 键选择目标速率 → 按 Enter 确认 → 选择 Exit 退出。<br>"
            "  <i>出厂默认：常速 (~4-10 Hz, 最高精度 ±0.00001 mT)。</i><br>"
            "  <i>速率越高精度越低，详见说明书表 4-2。</i><br>"
            "<br>"
            "<b>▶ 实时发送 (Realtime Transmit) 模式：</b><br>"
            "  按 <b>[Menu]</b> → 选择 <b>Realtime Transmit</b> → 按 Enter →<br>"
            "  设备开始持续串口发送数据帧，此时 <b>RS-232 指令不可用</b>。<br>"
            "  <i>要恢复指令控制：在设备面板按 Enter 退出实时发送模式。</i>"
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

        g1.addWidget(QLabel("当前量程:"), 1, 0)
        self._range_label = QLabel("--")
        self._range_label.setObjectName("smallData")
        g1.addWidget(self._range_label, 1, 1)

        self._range_btn = QPushButton("切换量程 / Cycle Range")
        self._range_btn.clicked.connect(self._on_cycle_range)
        self._range_btn.setEnabled(False)
        g1.addWidget(self._range_btn, 1, 2)

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

        layout.addStretch()
        return page

    # ==================================================================
    # 页面 2: 实时数据
    # ==================================================================

    def _build_live_data_page(self) -> QWidget:
        page = QWidget()
        layout = QVBoxLayout(page)
        layout.setContentsMargins(16, 16, 16, 16)

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
        ctrl_row.addWidget(self._zero_offset_label)

        ctrl_row.addStretch()

        # 统计
        self._live_stats = QLabel("FPS: -- | 数据点: 0 | 状态: 就绪")
        ctrl_row.addWidget(self._live_stats)

        layout.addLayout(ctrl_row)

        # pyqtgraph 图表
        if _HAS_PYG:
            self._plot_widget = pg.PlotWidget()
            self._plot_widget.setLabel("left", "磁场", units="mT")
            self._plot_widget.setLabel("bottom", "时间", units="s")
            self._plot_widget.showGrid(x=True, y=True, alpha=0.3)
            self._plot_widget.addLegend()
            self._plot_widget.setMinimumHeight(200)

            # 性能优化
            self._plot_widget.setClipToView(True)
            self._plot_widget.setAntialiasing(False)

            self._field_curve = self._plot_widget.plot(
                pen=pg.mkPen("#0080c8", width=1.5), name="磁场/mT"
            )
            self._freq_curve = self._plot_widget.plot(
                pen=pg.mkPen("#00a651", width=1.0), name="频率/Hz"
            )
            self._freq_curve.setVisible(False)

            # 零位参考线
            self._zero_line = pg.InfiniteLine(
                pos=0, angle=0, pen=pg.mkPen("#c0c0c0", width=1, style=Qt.DashLine)
            )
            self._plot_widget.addItem(self._zero_line)

            layout.addWidget(self._plot_widget, 1)
        else:
            self._plot_widget = None
            no_plot = QLabel("pyqtgraph 未安装, 图表不可用 / pyqtgraph not installed")
            no_plot.setAlignment(Qt.AlignCenter)
            layout.addWidget(no_plot)

        # 复选框行
        chk_row = QHBoxLayout()
        self._show_freq_cb = QCheckBox("显示频率曲线 / Show Frequency")
        self._show_freq_cb.toggled.connect(self._on_toggle_freq_curve)
        chk_row.addWidget(self._show_freq_cb)

        self._auto_y_cb = QCheckBox("自动 Y 轴范围 / Auto Y Range")
        self._auto_y_cb.setChecked(True)
        chk_row.addWidget(self._auto_y_cb)

        chk_row.addStretch()
        layout.addLayout(chk_row)

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
        layout.addLayout(chart_btn_row)

        # ── 数据记录组 (可折叠) ──
        rec_grp = QGroupBox("数据记录 / Recording")
        rec_grp.setCheckable(True)
        rec_grp.setChecked(False)
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
        rec_ctrl_row.addStretch()
        rv.addLayout(rec_ctrl_row)

        # 记录统计
        self._rec_stats_label = QLabel("未记录 / Not Recording")
        rv.addWidget(self._rec_stats_label)

        layout.addWidget(rec_grp)

        return page

    # ==================================================================
    # 页面 3: 日志
    # ==================================================================

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
            self.log(f"[GUI] 找到 {len(ports)} 个端口")
        else:
            self._port_combo.addItem("未找到设备 / No device found")
            self.log("[GUI] 未找到 CH-1600 设备")

    def _on_connect(self) -> None:
        if self._cmd_service is None:
            return
        port_text = self._port_combo.currentText()
        port = port_text.split(" - ")[0].strip() if " - " in port_text else port_text.strip()
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

    def _get_active_acq_mode(self) -> dict:
        """获取当前生效的采集模式参数。"""
        rate_key = self._sample_rate_combo.currentData()
        if rate_key in ACQ_MODE_TABLE:
            return ACQ_MODE_TABLE[rate_key]
        return ACQ_MODE_TABLE["dc_normal"]

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

    def _on_set_zero(self) -> None:
        """以当前读数为零点，后续数据均减去此偏移。"""
        # 从 buffer 取的是已修正值，需加回当前 offset 得到原始仪器值
        field_display = self._buffer.get_latest("field_mt")
        self._zero_offset = field_display + self._zero_offset
        self._zero_offset_label.setText(f"Zero offset: {self._zero_offset:.4f} mT")
        self._cfg.setdefault("acquisition", {})["zero_offset"] = self._zero_offset
        save_config(self._cfg)
        self.log(f"[GUI] 设置软件零点偏移: {self._zero_offset:.4f} mT")

    def _on_clear_zero(self) -> None:
        """清除零点偏移，恢复原始读数。"""
        self._zero_offset = 0.0
        self._zero_offset_label.setText("Zero offset: 0.0000 mT")
        self._cfg.setdefault("acquisition", {})["zero_offset"] = 0.0
        save_config(self._cfg)
        self.log("[GUI] 已清除软件零点偏移")

    # ------------------------------------------------------------------
    # 图表控制操作
    # ------------------------------------------------------------------

    def _on_clear_chart(self) -> None:
        """清空图表数据和缓冲区。"""
        self._buffer.clear()
        self._total_points = 0
        if hasattr(self, '_field_curve') and self._field_curve is not None:
            self._field_curve.clear()
        if hasattr(self, '_freq_curve') and self._freq_curve is not None:
            self._freq_curve.clear()
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
                _, vals = self._buffer.get("field_mt", max_points=5000, downsample=1)
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

    # ==================================================================
    # 数据流操作
    # ==================================================================

    def _on_start_stream(self) -> None:
        if self._cmd_service is None:
            return
        self._cmd_service.start_acquisition()
        self._stream_start_btn.setEnabled(False)
        self._stream_stop_btn.setEnabled(True)
        self._buffer.clear()
        self._update_global_bar(self._ctrl.is_connected if self._ctrl else False, True)
        self.log("[GUI] 数据采集已启动")

    def _on_stop_stream(self) -> None:
        if self._cmd_service is None:
            return
        self._cmd_service.stop_acquisition()
        self._stream_start_btn.setEnabled(True)
        self._stream_stop_btn.setEnabled(False)
        self._update_global_bar(self._ctrl.is_connected if self._ctrl else False, False)
        self.log("[GUI] 数据采集已停止")

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
        self._recorder = CH1600Recorder(output_dir=save_dir)
        try:
            file_path = self._recorder.start()
            self._rec_start_btn.setEnabled(False)
            self._rec_stop_btn.setEnabled(True)
            self._rec_stats_label.setText(f"记录中: {file_path.name}\n0 行")
            self._update_global_bar(
                self._ctrl.is_connected if self._ctrl else False,
                self._ctrl.is_streaming if self._ctrl else False,
            )
            self.log(f"[GUI] 开始记录: {file_path}")
        except OSError as exc:
            self.log(f"[GUI] 记录失败: {exc}")
            self._recorder = None

    def _on_stop_recording(self) -> None:
        if self._recorder:
            self._recorder.stop()
            row_count = self._recorder.row_count
            file_path = self._recorder.file_path
            self._recorder = None
            self.log(f"[GUI] 停止记录: {file_path} ({row_count} 行)")
        self._rec_start_btn.setEnabled(True)
        self._rec_stop_btn.setEnabled(False)
        self._rec_stats_label.setText("记录已停止")
        self._update_global_bar(
            self._ctrl.is_connected if self._ctrl else False,
            self._ctrl.is_streaming if self._ctrl else False,
        )

    # ==================================================================
    # 信号处理 — 来自 CommandService 的广播
    # ==================================================================

    def _on_stream_batch(self, batch: dict) -> None:
        """批量数据: 应用零偏、更新数值显示、推入 CircularBuffer、CSV 记录。"""
        points = batch.get("points", [])
        if not points:
            return

        # 应用软件零点偏移
        if self._zero_offset != 0.0:
            offset = self._zero_offset
            points = [{**p, "field_mt": p.get("field_mt", 0.0) - offset} for p in points]

        # 用批量中的最新点更新数值显示 (精度跟随当前采集模式)
        latest = batch.get("latest", {})
        if latest:
            mode = self._get_active_acq_mode()
            dec = mode["decimals"]
            field_raw = latest.get("field_mt", 0)
            field_display = field_raw - self._zero_offset
            self._field_label.setText(f"{field_display:.{dec}f} mT")

            freq = latest.get("freq_hz", 0)
            if freq < 0.01:
                self._freq_label.setText("DC")
            else:
                self._freq_label.setText(f"{freq:.0f} Hz")

            self._temp_label.setText(f"{latest.get('temp_c', 0):.1f} °C")

        self._total_points += len(points)

        # 推入环形缓冲区 (图表用)
        field_vals = [p.get("field_mt", 0.0) for p in points]
        freq_vals = [p.get("freq_hz", 0.0) for p in points]
        temp_vals = [p.get("temp_c", 0.0) for p in points]
        timestamps = [p.get("timestamp_s", 0.0) for p in points]

        self._buffer.extend(
            {"field_mt": field_vals, "freq_hz": freq_vals, "temp_c": temp_vals},
            timestamps,
        )

        # CSV 记录 (使用 CH1600Recorder)
        if self._recorder and self._recorder.is_recording:
            try:
                self._recorder.write_batch(points)
            except Exception:
                pass

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
        max_pts = self._cfg.get("ui", {}).get("chart_history_points", 5000) // ds

        # 图表更新 — 暂停时跳过
        if not self._display_paused:
            # 磁场曲线
            ts_arr, vals = self._buffer.get("field_mt", max_points=max_pts, downsample=ds)
            if len(ts_arr) > 0:
                ts_rel = ts_arr - ts_arr[-1]  # 相对时间 (秒)
                self._field_curve.setData(ts_rel, vals)

                # 固定 X 轴窗口 (滚动视图)
                self._plot_widget.setXRange(-x_window, 0.5, padding=0)

                # 自动 Y 轴
                if self._auto_y_cb.isChecked():
                    y_min, y_max = vals.min(), vals.max()
                    margin = max(abs(y_min), abs(y_max)) * 0.1 + 1e-6
                    self._plot_widget.setYRange(y_min - margin, y_max + margin, padding=0)

            # 频率曲线
            if self._show_freq_cb.isChecked():
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

        # 记录统计
        if self._recorder and self._recorder.is_recording:
            fname = self._recorder.file_path.name if self._recorder.file_path else "?"
            self._rec_stats_label.setText(
                f"记录中: {fname}\n"
                f"已记录: {self._recorder.row_count} 行"
            )

    def _on_toggle_freq_curve(self, visible: bool) -> None:
        if hasattr(self, '_freq_curve'):
            self._freq_curve.setVisible(visible)

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
        if self._cmd_service:
            self._cmd_service.stop()
        if self._recorder and self._recorder.is_recording:
            self._recorder.stop()
        # 保存配置
        try:
            save_config(self._cfg)
        except Exception:
            pass
        super().closeEvent(event)
