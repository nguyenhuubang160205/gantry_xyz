#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
====================================================================================================
  AJINEXTEK 3-AXIS XYZ GANTRY CNC - GIAO DIỆN QUAN SÁT ĐỒ THỊ & RECORD CSV (LIGHT THEME)
  - Giao diện nền trắng (White Theme) đơn giản, trực quan, dễ nhìn.
  - Người dùng tự thêm/xóa đồ thị ("+ Thêm Đồ Thị Mới") và tự chọn bất kỳ giá trị nào muốn xem:
    cmd_pos, act_pos, pos_error, cmd_vel, act_vel, cmd_acc, act_acc (Trục X, Y, Z).
  - Tích hợp quy trình chuẩn:
      1. Nhấn [🔴 Bắt đầu Record] -> Qua chạy mô phỏng C++
      2. Chạy xong nhấn [⏹ End Record] để chốt dữ liệu và giữ nguyên đồ thị
      3. Nhấn [💾 Xuất File CSV...] để chọn thư mục và tên file lưu dữ liệu
====================================================================================================
"""

import os
import sys
import csv
import math
import time
import mmap
import ctypes
from collections import deque
from datetime import datetime

from PyQt5.QtCore import Qt, QTimer, QRectF, QPointF
from PyQt5.QtGui import QPainter, QPen, QColor, QFont, QBrush, QPolygonF
from PyQt5.QtWidgets import (
    QApplication, QMainWindow, QWidget, QVBoxLayout, QHBoxLayout, QGridLayout,
    QTabWidget, QGroupBox, QCheckBox, QPushButton, QLabel, QComboBox,
    QTableWidget, QTableWidgetItem, QHeaderView, QFileDialog, QFrame,
    QScrollArea, QMessageBox, QDialog, QDialogButtonBox
)


# ====================================================================================================
# 1. CẤU TRÚC BỘ NHỚ CHIA SẺ (KHỚP 100% VỚI IPCSharedMemory.hpp)
# ====================================================================================================
class MotionSharedData(ctypes.Structure):
    _fields_ = [
        ("target_pos", ctypes.c_double * 3),       # cmd_pos [X, Y, Z] (mm)
        ("control_word", ctypes.c_uint32 * 3),
        ("actual_pos", ctypes.c_double * 3),       # act_pos [X, Y, Z] (mm)
        ("status_word", ctypes.c_uint32 * 3),
        ("digital_in", ctypes.c_uint32 * 3),
        ("probe_triggered", ctypes.c_bool),
        ("probe_latched_z", ctypes.c_double),
        ("heartbeat_tx", ctypes.c_uint32),
        ("heartbeat_rx", ctypes.c_uint32),
        ("sim_active", ctypes.c_bool),
        ("toolpath_epoch", ctypes.c_uint32),
        ("cmd_vel", ctypes.c_double * 3),          # Command Velocity (mm/s)
        ("act_vel", ctypes.c_double * 3),          # Actual Velocity (mm/s)
        ("cmd_acc", ctypes.c_double * 3),          # Command Acceleration (mm/s^2)
        ("act_acc", ctypes.c_double * 3),          # Actual Acceleration (mm/s^2)
        ("pos_error", ctypes.c_double * 3),        # Following Error: cmd_pos - act_pos (mm)
        ("imu_acc", ctypes.c_double * 3),          # MEMS IMU Vibration Acceleration (mm/s^2)
        ("axis_in_motion", ctypes.c_uint32 * 3),
        ("home_step", ctypes.c_uint32 * 3),
        ("home_progress", ctypes.c_uint32 * 3),
        ("home_result", ctypes.c_uint32 * 3),
        ("abs_rel_mode", ctypes.c_uint32 * 3),
        ("profile_mode", ctypes.c_uint32 * 3),
        ("conti_in_motion", ctypes.c_uint32),
        ("conti_node_index", ctypes.c_int32),
        ("conti_total_nodes", ctypes.c_int32),
    ]


SHM_PATH = "/dev/shm/xyz_motion_shm"
SHM_SIZE = ctypes.sizeof(MotionSharedData)


def ensure_shared_memory():
    if not os.path.exists(SHM_PATH):
        with open(SHM_PATH, "wb") as f:
            f.write(b"\x00" * SHM_SIZE)
    elif os.path.getsize(SHM_PATH) < SHM_SIZE:
        with open(SHM_PATH, "r+b") as f:
            f.seek(0, os.SEEK_END)
            f.write(b"\x00" * (SHM_SIZE - f.tell()))


# ====================================================================================================
# 2. DANH MỤC CÁC TÍN HIỆU ĐỂ NGƯỜI DÙNG CHỌN THÊM VÀO ĐỒ THỊ (MÀU ĐẬM RÕ TRÊN NỀN TRẮNG)
# ====================================================================================================
SIGNAL_DEFS = [
    # (key, short_name, full_label, unit, group, hex_color, pen_style)
    ("cmd_pos_x", "cmd_pos X", "Vị trí lệnh X (cmd_pos X)", "mm", "pos", "#2563eb", Qt.SolidLine),
    ("act_pos_x", "act_pos X", "Vị trí thực X (act_pos X)", "mm", "pos", "#dc2626", Qt.DashLine),
    ("cmd_pos_y", "cmd_pos Y", "Vị trí lệnh Y (cmd_pos Y)", "mm", "pos", "#16a34a", Qt.SolidLine),
    ("act_pos_y", "act_pos Y", "Vị trí thực Y (act_pos Y)", "mm", "pos", "#ea580c", Qt.DashLine),
    ("cmd_pos_z", "cmd_pos Z", "Vị trí lệnh Z (cmd_pos Z)", "mm", "pos", "#7c3aed", Qt.SolidLine),
    ("act_pos_z", "act_pos Z", "Vị trí thực Z (act_pos Z)", "mm", "pos", "#0891b2", Qt.DashLine),

    ("pos_err_x", "pos_error X", "Sai số bám X (pos_error X)", "mm", "err", "#e11d48", Qt.SolidLine),
    ("pos_err_y", "pos_error Y", "Sai số bám Y (pos_error Y)", "mm", "err", "#15803d", Qt.SolidLine),
    ("pos_err_z", "pos_error Z", "Sai số bám Z (pos_error Z)", "mm", "err", "#9333ea", Qt.SolidLine),

    ("cmd_vel_x", "cmd_vel X", "Vận tốc lệnh X (cmd_vel X)", "mm/s", "vel", "#1d4ed8", Qt.SolidLine),
    ("act_vel_x", "act_vel X", "Vận tốc thực X (act_vel X)", "mm/s", "vel", "#b91c1c", Qt.DashLine),
    ("cmd_vel_y", "cmd_vel Y", "Vận tốc lệnh Y (cmd_vel Y)", "mm/s", "vel", "#15803d", Qt.SolidLine),
    ("act_vel_y", "act_vel Y", "Vận tốc thực Y (act_vel Y)", "mm/s", "vel", "#c2410c", Qt.DashLine),
    ("cmd_vel_z", "cmd_vel Z", "Vận tốc lệnh Z (cmd_vel Z)", "mm/s", "vel", "#6d28d9", Qt.SolidLine),
    ("act_vel_z", "act_vel Z", "Vận tốc thực Z (act_vel Z)", "mm/s", "vel", "#0e7490", Qt.DashLine),

    ("cmd_acc_x", "cmd_acc X", "Gia tốc lệnh X (cmd_acc X)", "mm/s²", "acc", "#2563eb", Qt.SolidLine),
    ("act_acc_x", "act_acc X", "Gia tốc thực X (act_acc X)", "mm/s²", "acc", "#dc2626", Qt.DashLine),
    ("cmd_acc_y", "cmd_acc Y", "Gia tốc lệnh Y (cmd_acc Y)", "mm/s²", "acc", "#16a34a", Qt.SolidLine),
    ("act_acc_y", "act_acc Y", "Gia tốc thực Y (act_acc Y)", "mm/s²", "acc", "#ea580c", Qt.DashLine),
    ("cmd_acc_z", "cmd_acc Z", "Gia tốc lệnh Z (cmd_acc Z)", "mm/s²", "acc", "#7c3aed", Qt.SolidLine),
    ("act_acc_z", "act_acc Z", "Gia tốc thực Z (act_acc Z)", "mm/s²", "acc", "#0891b2", Qt.DashLine),

    ("imu_acc_x", "imu_acc X", "Gia tốc rung IMU đầu dao X (imu_acc X)", "mm/s²", "imu", "#be123c", Qt.SolidLine),
    ("imu_acc_y", "imu_acc Y", "Gia tốc rung IMU đầu dao Y (imu_acc Y)", "mm/s²", "imu", "#047857", Qt.SolidLine),
    ("imu_acc_z", "imu_acc Z", "Gia tốc rung IMU đầu dao Z (imu_acc Z)", "mm/s²", "imu", "#6d28d9", Qt.SolidLine),
]

SIGNAL_MAP = {item[0]: item for item in SIGNAL_DEFS}


# ====================================================================================================
# 3. HỘP THOẠI CHỌN TÍN HIỆU KHI NHẤN "➕ THÊM ĐỒ THỊ MỚI"
# ====================================================================================================
class AddChartDialog(QDialog):
    def __init__(self, parent=None):
        super().__init__(parent)
        self.setWindowTitle("Thêm Đồ Thị Mới - Chọn Giá Trị Muốn Quan Sát")
        self.resize(520, 420)
        self.setStyleSheet("""
            QDialog { background-color: #ffffff; color: #0f172a; }
            QGroupBox {
                font-weight: bold; color: #1e293b;
                border: 1px solid #cbd5e1; border-radius: 6px;
                margin-top: 8px; padding-top: 8px; background-color: #f8fafc;
            }
            QCheckBox { color: #0f172a; padding: 3px; font-weight: 500; }
        """)

        layout = QVBoxLayout(self)
        lbl = QLabel("<b>Tích chọn một hoặc nhiều giá trị bạn muốn hiển thị chung trên đồ thị mới:</b>")
        layout.addWidget(lbl)

        self.checks = {}
        groups = [
            ("pos", "Vị trí Lệnh và Thực tế (cmd_pos / act_pos) [mm]"),
            ("err", "Sai số Bám Vị trí (pos_error = cmd_pos - act_pos) [mm]"),
            ("vel", "Vận tốc Lệnh và Thực tế (cmd_vel / act_vel) [mm/s]"),
            ("acc", "Gia tốc Lệnh và Thực tế (cmd_acc / act_acc) [mm/s²]"),
            ("imu", "Cảm biến Rung Đầu Dao MEMS IMU (imu_acc) [mm/s²]"),
        ]

        for grp_id, grp_title in groups:
            box = QGroupBox(grp_title)
            grid = QGridLayout(box)
            r, c = 0, 0
            for key, short_name, full_lbl, unit, g, color_hex, _ in SIGNAL_DEFS:
                if g != grp_id:
                    continue
                chk = QCheckBox(f"{short_name} ({unit})")
                chk.setStyleSheet(f"color: {color_hex}; font-weight: bold;")
                self.checks[key] = chk
                grid.addWidget(chk, r, c)
                c += 1
                if c >= 3:
                    c = 0
                    r += 1
            layout.addWidget(box)

        btns = QDialogButtonBox(QDialogButtonBox.Ok | QDialogButtonBox.Cancel)
        btns.button(QDialogButtonBox.Ok).setText("➕ Tạo Đồ Thị")
        btns.button(QDialogButtonBox.Cancel).setText("Hủy")
        btns.accepted.connect(self.accept)
        btns.rejected.connect(self.reject)
        layout.addWidget(btns)

    def get_selected_keys(self):
        return [k for k, chk in self.checks.items() if chk.isChecked()]


# ====================================================================================================
# 4. CANVAS VẼ ĐỒ THỊ NỀN TRẮNG RÕ NÉT (WHITE SCIENTIFIC PLOT)
# ====================================================================================================
class WhitePlotCanvas(QWidget):
    def __init__(self, history_ref, parent=None):
        super().__init__(parent)
        self.history = history_ref
        self.series_keys = []
        self.time_window = 15.0
        self.show_full_record = False
        self.setMinimumHeight(210)

    def paintEvent(self, event):
        painter = QPainter(self)
        painter.setRenderHint(QPainter.Antialiasing, True)

        w = self.width()
        h = self.height()

        # Nền trắng tinh khiết
        painter.fillRect(0, 0, w, h, QColor("#ffffff"))

        margin_left = 72
        margin_right = 20
        margin_top = 14
        margin_bottom = 28
        plot_w = max(20, w - margin_left - margin_right)
        plot_h = max(20, h - margin_top - margin_bottom)
        plot_rect = QRectF(margin_left, margin_top, plot_w, plot_h)

        # Khung đồ thị nền xám cực nhạt dễ nhìn
        painter.fillRect(plot_rect, QColor("#f8fafc"))
        painter.setPen(QPen(QColor("#cbd5e1"), 1.2))
        painter.drawRect(plot_rect)

        if not self.series_keys:
            painter.setPen(QColor("#64748b"))
            painter.setFont(QFont("DejaVu Sans", 10))
            painter.drawText(plot_rect, Qt.AlignCenter, "Hãy chọn tín hiệu ở thanh phía trên để vẽ đồ thị...")
            return

        times = list(self.history["time"])
        if len(times) < 2:
            painter.setPen(QColor("#64748b"))
            painter.setFont(QFont("DejaVu Sans", 10))
            painter.drawText(plot_rect, Qt.AlignCenter, "Đang chờ dữ liệu từ hệ thống...")
            return

        if self.show_full_record:
            t_min = times[0]
            t_max = max(t_min + 1.0, times[-1])
            start_idx = 0
        else:
            t_max = times[-1]
            t_min = max(0.0, t_max - self.time_window)
            start_idx = 0
            for idx, tv in enumerate(times):
                if tv >= t_min:
                    start_idx = idx
                    break

        y_min = float("inf")
        y_max = float("-inf")
        active_data = []
        groups_present = set()

        for key in self.series_keys:
            if key not in self.history:
                continue
            vals = list(self.history[key])[start_idx:]
            if not vals:
                continue
            vmin = min(vals)
            vmax = max(vals)
            if vmin < y_min:
                y_min = vmin
            if vmax > y_max:
                y_max = vmax
            active_data.append((key, vals))
            if key in SIGNAL_MAP:
                groups_present.add(SIGNAL_MAP[key][4])

        if not active_data or math.isinf(y_min) or math.isinf(y_max):
            return

        # Đặt độ mở tối thiểu hợp lý để quan sát rõ cả động lực học thực tế (trọng lực, ma sát, độ rơ, nhiễu IMU)
        min_span = 1.0
        if groups_present == {"err"}:
            min_span = 0.015
        elif groups_present == {"vel"}:
            min_span = 5.0
        elif groups_present in ({"acc"}, {"imu"}, {"acc", "imu"}):
            min_span = 40.0

        span = y_max - y_min
        if span < min_span:
            mid = 0.5 * (y_max + y_min)
            y_min = mid - 0.5 * min_span
            y_max = mid + 0.5 * min_span
        else:
            y_min -= span * 0.12
            y_max += span * 0.12

        # Vẽ lưới ngang & nhãn trục Y
        painter.setFont(QFont("DejaVu Sans Mono", 8))
        num_h = 4
        for i in range(num_h + 1):
            frac = i / num_h
            y_px = margin_top + frac * plot_h
            val = y_max - frac * (y_max - y_min)
            painter.setPen(QPen(QColor("#e2e8f0"), 1, Qt.DashLine))
            painter.drawLine(int(margin_left), int(y_px), int(margin_left + plot_w), int(y_px))
            painter.setPen(QColor("#334155"))
            lbl = f"{val:.3f}" if (y_max - y_min) < 0.5 else (f"{val:.2f}" if (y_max - y_min) < 20.0 else f"{val:.1f}")
            painter.drawText(QRectF(4, y_px - 8, margin_left - 10, 16), Qt.AlignRight | Qt.AlignVCenter, lbl)

        # Đường 0 chuẩn
        if y_min < 0.0 < y_max:
            zy = margin_top + (y_max - 0.0) / (y_max - y_min) * plot_h
            painter.setPen(QPen(QColor("#94a3b8"), 1.2, Qt.SolidLine))
            painter.drawLine(int(margin_left), int(zy), int(margin_left + plot_w), int(zy))

        # Vẽ lưới dọc & nhãn thời gian trục X
        num_v = 5
        t_span = max(0.5, t_max - t_min)
        for i in range(num_v + 1):
            frac = i / num_v
            x_px = margin_left + frac * plot_w
            t_val = t_min + frac * t_span
            painter.setPen(QPen(QColor("#e2e8f0"), 1, Qt.DashLine))
            painter.drawLine(int(x_px), int(margin_top), int(x_px), int(margin_top + plot_h))
            painter.setPen(QColor("#334155"))
            painter.drawText(QRectF(x_px - 28, margin_top + plot_h + 5, 56, 18), Qt.AlignCenter, f"{t_val:.1f}s")

        # Vẽ các đường tín hiệu
        t_slice = times[start_idx:]
        n_pts = len(t_slice)
        step = max(1, n_pts // int(plot_w))

        painter.setClipRect(plot_rect)
        for key, vals in active_data:
            s_def = SIGNAL_MAP.get(key)
            color = QColor(s_def[5]) if s_def else QColor("#2563eb")
            style = s_def[6] if s_def else Qt.SolidLine
            painter.setPen(QPen(color, 2.0, style))

            poly = QPolygonF()
            for idx in range(0, len(vals), step):
                tv = t_slice[idx]
                yv = vals[idx]
                x_px = margin_left + ((tv - t_min) / t_span) * plot_w
                y_px = margin_top + ((y_max - yv) / (y_max - y_min)) * plot_h
                poly.append(QPointF(x_px, y_px))
            if (len(vals) - 1) % step != 0:
                tv = t_slice[-1]
                yv = vals[-1]
                x_px = margin_left + ((tv - t_min) / t_span) * plot_w
                y_px = margin_top + ((y_max - yv) / (y_max - y_min)) * plot_h
                poly.append(QPointF(x_px, y_px))
            painter.drawPolyline(poly)
        painter.setClipping(False)


# ====================================================================================================
# 5. THẺ ĐỒ THỊ ĐỘNG (CHO PHÉP THÊM/XÓA TÍN HIỆU HOẶC XÓA ĐỒ THỊ BẤT KỲ LÚC NÀO)
# ====================================================================================================
class DynamicChartCard(QFrame):
    def __init__(self, chart_idx, initial_keys, history_ref, on_remove_callback, parent=None):
        super().__init__(parent)
        self.chart_idx = chart_idx
        self.history = history_ref
        self.on_remove_callback = on_remove_callback

        self.setStyleSheet("""
            DynamicChartCard {
                background-color: #ffffff;
                border: 1px solid #cbd5e1;
                border-radius: 8px;
            }
        """)

        vbox = QVBoxLayout(self)
        vbox.setContentsMargins(10, 8, 10, 8)
        vbox.setSpacing(6)

        # Thanh tiêu đề & chọn tín hiệu của đồ thị
        top_bar = QHBoxLayout()
        self.lbl_title = QLabel(f"<b>Đồ thị #{chart_idx}</b>")
        self.lbl_title.setStyleSheet("color: #0f172a; font-size: 13px;")
        top_bar.addWidget(self.lbl_title)

        # ComboBox chọn thêm tín hiệu vào đồ thị này
        self.cmb_add_sig = QComboBox()
        self.cmb_add_sig.setMinimumWidth(240)
        self.cmb_add_sig.addItem("+ Chọn thêm giá trị vào đồ thị này...", "")
        for key, short_name, full_lbl, unit, _, _, _ in SIGNAL_DEFS:
            self.cmb_add_sig.addItem(f"{short_name} [{unit}] — {full_lbl}", key)
        self.cmb_add_sig.currentIndexChanged.connect(self._on_combo_add_signal)
        top_bar.addWidget(self.cmb_add_sig)

        # Khu vực hiển thị các nút tag tín hiệu đang bật (bấm ✕ để gỡ)
        self.tags_layout = QHBoxLayout()
        self.tags_layout.setSpacing(4)
        top_bar.addLayout(self.tags_layout, 1)

        btn_del_chart = QPushButton("🗑 Xóa đồ thị")
        btn_del_chart.setStyleSheet("""
            QPushButton {
                background-color: #fee2e2; color: #b91c1c;
                border: 1px solid #fca5a5; border-radius: 4px;
                padding: 4px 10px; font-weight: bold;
            }
            QPushButton:hover { background-color: #fecaca; }
        """)
        btn_del_chart.clicked.connect(lambda: self.on_remove_callback(self))
        top_bar.addWidget(btn_del_chart)

        vbox.addLayout(top_bar)

        # Canvas vẽ đồ thị
        self.canvas = WhitePlotCanvas(self.history, self)
        self.canvas.series_keys = list(initial_keys)
        vbox.addWidget(self.canvas, 1)

        self._rebuild_tags()

    def _on_combo_add_signal(self, idx):
        if idx <= 0:
            return
        key = self.cmb_add_sig.itemData(idx)
        self.cmb_add_sig.setCurrentIndex(0)
        if key and key not in self.canvas.series_keys:
            self.canvas.series_keys.append(key)
            self._rebuild_tags()
            self.canvas.update()

    def _remove_signal(self, key):
        if key in self.canvas.series_keys:
            self.canvas.series_keys.remove(key)
            self._rebuild_tags()
            self.canvas.update()

    def _rebuild_tags(self):
        while self.tags_layout.count():
            item = self.tags_layout.takeAt(0)
            if item.widget():
                item.widget().deleteLater()

        for key in self.canvas.series_keys:
            s_def = SIGNAL_MAP.get(key)
            if not s_def:
                continue
            short_name, unit, color_hex = s_def[1], s_def[3], s_def[5]
            btn_tag = QPushButton(f"● {short_name} ({unit})  ✕")
            btn_tag.setToolTip("Nhấn để gỡ giá trị này khỏi đồ thị")
            btn_tag.setStyleSheet(f"""
                QPushButton {{
                    background-color: #f1f5f9;
                    color: {color_hex};
                    border: 1px solid {color_hex};
                    border-radius: 12px;
                    padding: 3px 10px;
                    font-weight: bold;
                    font-size: 11px;
                }}
                QPushButton:hover {{
                    background-color: #e2e8f0;
                }}
            """)
            btn_tag.clicked.connect(lambda checked, k=key: self._remove_signal(k))
            self.tags_layout.addWidget(btn_tag)

        self.tags_layout.addStretch()


# ====================================================================================================
# 6. CỬA SỔ CHÍNH (LIGHT THEME ĐƠN GIẢN, DỄ NHÌN)
# ====================================================================================================
class AjinextekSimpleLightGUI(QMainWindow):
    def __init__(self):
        super().__init__()
        self.setWindowTitle("Ajinextek 3-Axis Gantry CNC - Quan Sát Đồ Thị Động Học & Xuất CSV")
        self.resize(1420, 860)

        # Giao diện sáng (White / Light Theme) rõ ràng, dễ nhìn
        self.setStyleSheet("""
            QMainWindow, QWidget {
                background-color: #f1f5f9;
                color: #0f172a;
                font-family: 'DejaVu Sans', sans-serif;
                font-size: 12px;
            }
            QTabWidget::pane {
                border: 1px solid #cbd5e1;
                background-color: #f8fafc;
                border-radius: 6px;
            }
            QTabBar::tab {
                background-color: #e2e8f0;
                color: #475569;
                padding: 8px 18px;
                margin-right: 4px;
                border-top-left-radius: 6px;
                border-top-right-radius: 6px;
                font-weight: bold;
            }
            QTabBar::tab:selected {
                background-color: #2563eb;
                color: #ffffff;
            }
            QPushButton {
                background-color: #ffffff;
                color: #1e293b;
                border: 1px solid #cbd5e1;
                border-radius: 6px;
                padding: 6px 14px;
                font-weight: bold;
            }
            QPushButton:hover {
                background-color: #f8fafc;
                border-color: #2563eb;
            }
            QComboBox {
                background-color: #ffffff;
                color: #0f172a;
                border: 1px solid #cbd5e1;
                border-radius: 5px;
                padding: 4px 8px;
            }
            QTableWidget {
                background-color: #ffffff;
                gridline-color: #e2e8f0;
                border: 1px solid #cbd5e1;
                color: #0f172a;
            }
            QHeaderView::section {
                background-color: #f1f5f9;
                color: #1e293b;
                padding: 6px;
                border: 1px solid #cbd5e1;
                font-weight: bold;
            }
        """)

        ensure_shared_memory()
        self.shm_file = open(SHM_PATH, "r+b")
        self.shm_mmap = mmap.mmap(self.shm_file.fileno(), SHM_SIZE, mmap.MAP_SHARED, mmap.PROT_READ | mmap.PROT_WRITE)

        # Bộ nhớ lưu dữ liệu (tối đa 30,000 mẫu = 10 phút ở 50Hz)
        self.max_samples = 30000
        self.history = {"time": deque(maxlen=self.max_samples)}
        for s_def in SIGNAL_DEFS:
            self.history[s_def[0]] = deque(maxlen=self.max_samples)

        self.t0 = time.monotonic()
        # Trạng thái ghi: "LIVE" (xem trực tiếp), "RECORDING" (đang ghi), "STOPPED" (đã bấm End Record, giữ nguyên đồ thị)
        self.mode = "LIVE"
        self.chart_counter = 0
        self.chart_cards = []

        self._build_ui()

        # Tạo mặc định 2 đồ thị mẫu để người dùng thấy ngay, có thể xóa hoặc thêm tùy ý
        self._add_chart_card(["cmd_pos_x", "act_pos_x", "cmd_pos_y", "act_pos_y"])
        self._add_chart_card(["cmd_vel_x", "act_vel_x", "cmd_vel_y", "act_vel_y"])

        self.timer = QTimer(self)
        self.timer.timeout.connect(self._on_tick)
        self.timer.start(20) # 50Hz

    def _read_shm(self):
        self.shm_mmap.seek(0)
        buf = self.shm_mmap.read(SHM_SIZE)
        return MotionSharedData.from_buffer_copy(buf)

    def _build_ui(self):
        central = QWidget()
        self.setCentralWidget(central)
        main_vbox = QVBoxLayout(central)
        main_vbox.setContentsMargins(10, 10, 10, 10)
        main_vbox.setSpacing(8)

        # --------------------------------------------------------------------------------------------
        # 1. THANH CÔNG CỤ CHÍNH: RECORD -> END RECORD -> XUẤT CSV -> THÊM ĐỒ THỊ
        # --------------------------------------------------------------------------------------------
        toolbar = QFrame()
        toolbar.setStyleSheet("background-color: #ffffff; border: 1px solid #cbd5e1; border-radius: 8px;")
        tb_layout = QHBoxLayout(toolbar)
        tb_layout.setContentsMargins(12, 8, 12, 8)
        tb_layout.setSpacing(10)

        self.btn_record = QPushButton("🔴 Bắt đầu Record")
        self.btn_record.setStyleSheet("""
            QPushButton {
                background-color: #dc2626; color: #ffffff;
                border: none; border-radius: 6px; padding: 8px 16px; font-weight: bold; font-size: 13px;
            }
            QPushButton:hover { background-color: #b91c1c; }
        """)
        self.btn_record.clicked.connect(self._start_record)
        tb_layout.addWidget(self.btn_record)

        self.btn_end_record = QPushButton("⏹ End Record (Dừng ghi)")
        self.btn_end_record.setEnabled(False)
        self.btn_end_record.setStyleSheet("""
            QPushButton {
                background-color: #334155; color: #ffffff;
                border: none; border-radius: 6px; padding: 8px 16px; font-weight: bold; font-size: 13px;
            }
            QPushButton:disabled { background-color: #cbd5e1; color: #64748b; }
            QPushButton:hover:enabled { background-color: #1e293b; }
        """)
        self.btn_end_record.clicked.connect(self._end_record)
        tb_layout.addWidget(self.btn_end_record)

        self.btn_export_csv = QPushButton("💾 Xuất File CSV...")
        self.btn_export_csv.setStyleSheet("""
            QPushButton {
                background-color: #16a34a; color: #ffffff;
                border: none; border-radius: 6px; padding: 8px 16px; font-weight: bold; font-size: 13px;
            }
            QPushButton:hover { background-color: #15803d; }
        """)
        self.btn_export_csv.clicked.connect(self._export_csv)
        tb_layout.addWidget(self.btn_export_csv)

        btn_clear = QPushButton("🔄 Xóa / Xem Live")
        btn_clear.clicked.connect(self._reset_live)
        tb_layout.addWidget(btn_clear)

        # Nút Thêm Đồ Thị Mới
        btn_add_chart = QPushButton("➕ Thêm Đồ Thị Mới (Add Chart)")
        btn_add_chart.setStyleSheet("""
            QPushButton {
                background-color: #2563eb; color: #ffffff;
                border: none; border-radius: 6px; padding: 8px 16px; font-weight: bold; font-size: 13px;
            }
            QPushButton:hover { background-color: #1d4ed8; }
        """)
        btn_add_chart.clicked.connect(self._open_add_chart_dialog)
        tb_layout.addWidget(btn_add_chart)

        self.lbl_status = QLabel("🟢 Chế độ: Đang xem trực tiếp (LIVE)")
        self.lbl_status.setStyleSheet("color: #15803d; font-weight: bold; font-size: 13px; padding-left: 8px;")
        tb_layout.addWidget(self.lbl_status, 1)

        main_vbox.addWidget(toolbar)

        # --------------------------------------------------------------------------------------------
        # 2. THANH HIỂN THỊ SỐ TỨC THỜI (DRO) CHO 3 TRỤC X, Y, Z NỀN TRẮNG DỄ ĐỌC
        # --------------------------------------------------------------------------------------------
        dro_bar = QFrame()
        dro_bar.setStyleSheet("background-color: #ffffff; border: 1px solid #cbd5e1; border-radius: 8px;")
        dro_layout = QHBoxLayout(dro_bar)
        dro_layout.setContentsMargins(12, 6, 12, 6)

        self.lbl_dro = []
        colors = ["#2563eb", "#16a34a", "#7c3aed"]
        names = ["TRỤC X (Axis 0)", "TRỤC Y (Axis 1)", "TRỤC Z (Axis 2)"]
        for i in range(3):
            lbl = QLabel()
            lbl.setFont(QFont("DejaVu Sans Mono", 10))
            lbl.setStyleSheet(f"color: #0f172a; border-left: 4px solid {colors[i]}; padding-left: 8px;")
            lbl.setText(f"<b>{names[i]}</b><br>cmd_pos: 0.000 mm | act_pos: 0.000 mm<br>cmd_vel: 0.00 mm/s | act_vel: 0.00 mm/s")
            dro_layout.addWidget(lbl, 1)
            self.lbl_dro.append(lbl)

        main_vbox.addWidget(dro_bar)

        # --------------------------------------------------------------------------------------------
        # 3. HAI TAB ĐƠN GIẢN: TAB 1 (ĐỒ THỊ TỰ CHỌN) & TAB 2 (BẢNG GIÁ TRỊ TRẢ VỀ CHI TIẾT)
        # --------------------------------------------------------------------------------------------
        self.tabs = QTabWidget()
        main_vbox.addWidget(self.tabs, 1)

        # Tab 1: Khu vực chứa các đồ thị động do người dùng thêm vào
        tab1 = QWidget()
        tab1_vbox = QVBoxLayout(tab1)
        tab1_vbox.setContentsMargins(4, 4, 4, 4)

        self.scroll_charts = QScrollArea()
        self.scroll_charts.setWidgetResizable(True)
        self.scroll_charts.setStyleSheet("QScrollArea { border: none; background-color: transparent; }")
        self.charts_container = QWidget()
        self.charts_vbox = QVBoxLayout(self.charts_container)
        self.charts_vbox.setContentsMargins(4, 4, 4, 4)
        self.charts_vbox.setSpacing(10)
        self.charts_vbox.addStretch()
        self.scroll_charts.setWidget(self.charts_container)

        tab1_vbox.addWidget(self.scroll_charts, 1)
        self.tabs.addTab(tab1, "📈 Tab 1: Đồ Thị Quan Sát (Tự chọn & Thêm đồ thị)")

        # Tab 2: Bảng giá trị trả về của toàn bộ hệ thống (X, Y, Z)
        tab2 = QWidget()
        tab2_vbox = QVBoxLayout(tab2)
        tab2_vbox.setContentsMargins(8, 8, 8, 8)

        self.tbl = QTableWidget(15, 4)
        self.tbl.setHorizontalHeaderLabels([
            "Thông số / Hàm trả về chuẩn Ajinextek",
            "Trục X (Axis 0)",
            "Trục Y (Axis 1)",
            "Trục Z (Axis 2)"
        ])
        self.tbl.horizontalHeader().setSectionResizeMode(QHeaderView.Stretch)
        self.tbl.verticalHeader().setVisible(False)
        self.tbl.setEditTriggers(QTableWidget.NoEditTriggers)

        row_names = [
            "Độ phân giải cơ khí (Encoder 20-bit / Vít me 2cm)",
            "cmd_pos — Vị trí lệnh (AxmStatusGetCmdPos) [mm]",
            "act_pos — Vị trí thực (AxmStatusGetActPos) [mm]",
            "pos_error — Sai số bám (AxmStatusReadPosError) [mm / µm]",
            "cmd_vel — Vận tốc lệnh (AxmStatusReadVel) [mm/s]",
            "act_vel — Vận tốc thực (AxmStatusReadActVel) [mm/s]",
            "cmd_acc — Gia tốc lệnh [mm/s²]",
            "act_acc — Gia tốc thực [mm/s²]",
            "imu_acc — Gia tốc rung cảm biến MEMS IMU đầu dao [mm/s²]",
            "Xung lệnh / Xung thực (Encoder 20-bit = 1,048,576 xung/vòng)",
            "Trạng thái chuyển động (AxmStatusReadInMotion)",
            "Chế độ tọa độ (AxmMotGetAbsRelMode: 0=ABS, 1=REL)",
            "Biên dạng vận tốc (AxmMotGetProfileMode)",
            "Cảm biến Hành trình (+Limit / -Limit / Home ORG)",
            "Tiến trình Homing 7 bước (AxmHomeGetRate / Result)",
        ]
        for r, name in enumerate(row_names):
            it = QTableWidgetItem(name)
            it.setFont(QFont("DejaVu Sans", 10, QFont.Bold))
            self.tbl.setItem(r, 0, it)
            for c in range(1, 4):
                cell = QTableWidgetItem("0.000")
                cell.setTextAlignment(Qt.AlignCenter)
                self.tbl.setItem(r, c, cell)

        tab2_vbox.addWidget(self.tbl, 1)
        self.tabs.addTab(tab2, "📋 Tab 2: Bảng Giá Trị Trả Về Chi Tiết (3 Trục X, Y, Z)")

    # ================================================================================================
    # 7. THÊM / XÓA ĐỒ THỊ ĐỘNG
    # ================================================================================================
    def _open_add_chart_dialog(self):
        dlg = AddChartDialog(self)
        if dlg.exec_() == QDialog.Accepted:
            keys = dlg.get_selected_keys()
            if not keys:
                keys = ["cmd_pos_x", "act_pos_x"]
            self._add_chart_card(keys)

    def _add_chart_card(self, initial_keys):
        self.chart_counter += 1
        card = DynamicChartCard(self.chart_counter, initial_keys, self.history, self._remove_chart_card, self)
        card.canvas.show_full_record = (self.mode in ("RECORDING", "STOPPED"))
        self.chart_cards.append(card)
        # Chèn trước stretch ở cuối
        self.charts_vbox.insertWidget(self.charts_vbox.count() - 1, card)

    def _remove_chart_card(self, card):
        if card in self.chart_cards:
            self.chart_cards.remove(card)
            self.charts_vbox.removeWidget(card)
            card.deleteLater()

    # ================================================================================================
    # 8. QUY TRÌNH RECORD -> END RECORD -> XUẤT CSV
    # ================================================================================================
    def _start_record(self):
        for k in self.history:
            self.history[k].clear()
        self.t0 = time.monotonic()
        self.mode = "RECORDING"
        self.btn_record.setEnabled(False)
        self.btn_end_record.setEnabled(True)
        for c in self.chart_cards:
            c.canvas.show_full_record = True
        self.lbl_status.setText("🔴 ĐANG RECORD... (Hãy chạy chương trình mô phỏng C++ của bạn)")
        self.lbl_status.setStyleSheet("color: #dc2626; font-weight: bold; font-size: 13px; padding-left: 8px;")

    def _end_record(self):
        self.mode = "STOPPED"
        self.btn_record.setEnabled(True)
        self.btn_end_record.setEnabled(False)
        n = len(self.history["time"])
        dur = self.history["time"][-1] if n > 0 else 0.0
        for c in self.chart_cards:
            c.canvas.show_full_record = True
            c.canvas.update()
        self.lbl_status.setText(f"⏹ ĐÃ DỪNG RECORD — Đã ghi {n} mẫu ({dur:.1f} giây). Nhấn [💾 Xuất File CSV...] để lưu.")
        self.lbl_status.setStyleSheet("color: #1e293b; font-weight: bold; font-size: 13px; padding-left: 8px;")

    def _reset_live(self):
        for k in self.history:
            self.history[k].clear()
        self.t0 = time.monotonic()
        self.mode = "LIVE"
        self.btn_record.setEnabled(True)
        self.btn_end_record.setEnabled(False)
        for c in self.chart_cards:
            c.canvas.show_full_record = False
            c.canvas.update()
        self.lbl_status.setText("🟢 Chế độ: Đang xem trực tiếp (LIVE)")
        self.lbl_status.setStyleSheet("color: #15803d; font-weight: bold; font-size: 13px; padding-left: 8px;")

    def _export_csv(self):
        n = len(self.history["time"])
        if n == 0:
            QMessageBox.information(self, "Thông báo", "Chưa có dữ liệu để xuất CSV!")
            return

        default_name = f"telemetry_record_{datetime.now().strftime('%Y%m%d_%H%M%S')}.csv"
        path, _ = QFileDialog.getSaveFileName(
            self,
            "Chọn vị trí lưu tệp CSV",
            os.path.join(os.path.expanduser("~"), default_name),
            "CSV Files (*.csv);;All Files (*)"
        )
        if not path:
            return
        if not path.endswith(".csv"):
            path += ".csv"

        keys = ["time"] + [s[0] for s in SIGNAL_DEFS]
        headers = [
            "time_sec",
            "cmd_pos_x_mm", "act_pos_x_mm", "cmd_pos_y_mm", "act_pos_y_mm", "cmd_pos_z_mm", "act_pos_z_mm",
            "pos_error_x_mm", "pos_error_y_mm", "pos_error_z_mm",
            "cmd_vel_x_mms", "act_vel_x_mms", "cmd_vel_y_mms", "act_vel_y_mms", "cmd_vel_z_mms", "act_vel_z_mms",
            "cmd_acc_x_mms2", "act_acc_x_mms2", "cmd_acc_y_mms2", "act_acc_y_mms2", "cmd_acc_z_mms2", "act_acc_z_mms2",
            "imu_acc_x_mms2", "imu_acc_y_mms2", "imu_acc_z_mms2"
        ]
        with open(path, "w", newline="", encoding="utf-8") as f:
            writer = csv.writer(f)
            writer.writerow(headers)
            for idx in range(n):
                row = [f"{self.history[k][idx]:.6f}" if idx < len(self.history[k]) else "0.0" for k in keys]
                writer.writerow(row)

        QMessageBox.information(self, "Đã lưu CSV thành công", f"Đã xuất {n} mẫu dữ liệu ra tệp:\n{path}")

    # ================================================================================================
    # 9. VÒNG LẶP ĐỌC SHM & CẬP NHẬT ĐỒ THỊ (50 HZ)
    # ================================================================================================
    def _on_tick(self):
        try:
            data = self._read_shm()
        except Exception:
            return

        pos_err = [data.target_pos[i] - data.actual_pos[i] for i in range(3)]

        # Cập nhật DRO số tức thời luôn hoạt động
        names = ["TRỤC X (Axis 0)", "TRỤC Y (Axis 1)", "TRỤC Z (Axis 2)"]
        for i in range(3):
            self.lbl_dro[i].setText(
                f"<b>{names[i]}</b>  [pos_error: <b>{pos_err[i]*1000.0:+.1f} µm</b>]<br>"
                f"cmd_pos: <b>{data.target_pos[i]:8.3f}</b> mm   | act_pos: <b>{data.actual_pos[i]:8.3f}</b> mm<br>"
                f"cmd_vel: <b>{data.cmd_vel[i]:8.2f}</b> mm/s | act_vel: <b>{data.act_vel[i]:8.2f}</b> mm/s<br>"
                f"cmd_acc: <b>{data.cmd_acc[i]:8.1f}</b> mm/s²| act_acc: <b>{data.act_acc[i]:8.1f}</b> mm/s²"
            )

        # Nếu đang ở chế độ LIVE hoặc RECORDING thì thu thập mẫu mới vào history
        if self.mode in ("LIVE", "RECORDING"):
            now_sec = time.monotonic() - self.t0
            self.history["time"].append(now_sec)
            self.history["cmd_pos_x"].append(data.target_pos[0])
            self.history["act_pos_x"].append(data.actual_pos[0])
            self.history["cmd_pos_y"].append(data.target_pos[1])
            self.history["act_pos_y"].append(data.actual_pos[1])
            self.history["cmd_pos_z"].append(data.target_pos[2])
            self.history["act_pos_z"].append(data.actual_pos[2])

            self.history["pos_err_x"].append(pos_err[0])
            self.history["pos_err_y"].append(pos_err[1])
            self.history["pos_err_z"].append(pos_err[2])

            self.history["cmd_vel_x"].append(data.cmd_vel[0])
            self.history["act_vel_x"].append(data.act_vel[0])
            self.history["cmd_vel_y"].append(data.cmd_vel[1])
            self.history["act_vel_y"].append(data.act_vel[1])
            self.history["cmd_vel_z"].append(data.cmd_vel[2])
            self.history["act_vel_z"].append(data.act_vel[2])

            self.history["cmd_acc_x"].append(data.cmd_acc[0])
            self.history["act_acc_x"].append(data.act_acc[0])
            self.history["cmd_acc_y"].append(data.cmd_acc[1])
            self.history["act_acc_y"].append(data.act_acc[1])
            self.history["cmd_acc_z"].append(data.cmd_acc[2])
            self.history["act_acc_z"].append(data.act_acc[2])

            self.history["imu_acc_x"].append(data.imu_acc[0])
            self.history["imu_acc_y"].append(data.imu_acc[1])
            self.history["imu_acc_z"].append(data.imu_acc[2])

            if self.mode == "RECORDING":
                n = len(self.history["time"])
                self.lbl_status.setText(f"🔴 ĐANG RECORD... Thời gian: {now_sec:.1f}s ({n} mẫu) — Nhấn [⏹ End Record] khi chạy xong")

            if self.tabs.currentIndex() == 0:
                for card in self.chart_cards:
                    card.canvas.update()

        if self.tabs.currentIndex() == 1:
            self._update_table(data, pos_err)

    def _update_table(self, data, pos_err):
        PULSES_PER_MM = 1048576.0 / 20.0
        for i in range(3):
            col = i + 1
            dig = data.digital_in[i]
            lim_neg = "ON" if (dig & 0x02) else "OFF"
            lim_pos = "ON" if (dig & 0x04) else "OFF"
            home_org = "ON" if (dig & 0x08) else "OFF"
            cmd_p = int(round(data.target_pos[i] * PULSES_PER_MM))
            act_p = int(round(data.actual_pos[i] * PULSES_PER_MM))

            vals = [
                "20.0 mm / 1,048,576 xung (0.019 µm/xung)",
                f"{data.target_pos[i]:.4f} mm",
                f"{data.actual_pos[i]:.4f} mm",
                f"{pos_err[i]:.4f} mm ({pos_err[i]*1000.0:+.1f} µm)",
                f"{data.cmd_vel[i]:.2f} mm/s",
                f"{data.act_vel[i]:.2f} mm/s",
                f"{data.cmd_acc[i]:.1f} mm/s²",
                f"{data.act_acc[i]:.1f} mm/s²",
                f"{data.imu_acc[i]:.1f} mm/s²",
                f"{cmd_p:,} / {act_p:,} xung",
                "Đang chạy (1)" if data.axis_in_motion[i] else "Đứng yên (0)",
                "Tương đối G91 (1)" if data.abs_rel_mode[i] == 1 else "Tuyệt đối G90 (0)",
                f"Mode {data.profile_mode[i]} (S-Curve)" if data.profile_mode[i] >= 2 else f"Mode {data.profile_mode[i]} (Trapezoid)",
                f"+Lim: {lim_pos} | -Lim: {lim_neg} | ORG: {home_org}",
                f"Bước {data.home_step[i]} ({data.home_progress[i]}%) - Result: {data.home_result[i]}",
            ]
            for r, v in enumerate(vals):
                self.tbl.item(r, col).setText(v)

    def closeEvent(self, event):
        try:
            self.timer.stop()
            self.shm_mmap.close()
            self.shm_file.close()
        except Exception:
            pass
        super().closeEvent(event)


def main():
    app = QApplication(sys.argv)
    win = AjinextekSimpleLightGUI()
    win.show()
    sys.exit(app.exec_())


if __name__ == "__main__":
    main()
