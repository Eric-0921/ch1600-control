"""Device model and probe capability metadata for CH-1600 workflows.

The CH-1600 software has three independent notions of dimension:
measurement channels (X/Y/Z/Total), spatial scan coordinates
(x_mm/y_mm/z_mm), and visualization mode (time/heatmap/surface). Keeping this
metadata centralized prevents GUI, recorder, SQLite, and reports from drifting.
"""

from __future__ import annotations

from dataclasses import dataclass
import math
from typing import Any, Dict, Iterable, Mapping, Tuple


@dataclass(frozen=True)
class DeviceCapability:
    model: str
    label: str
    measurement_dimension: int
    field_unit: str
    available_units: Tuple[str, ...]
    display_scales: Mapping[str, float]
    field_components: Tuple[str, ...]
    has_total: bool
    has_freq: bool
    has_temp: bool
    stream_channels: Tuple[str, ...]
    recorder_fields: Tuple[str, ...]
    threshold_channels: Tuple[str, ...]
    table_columns: Tuple[str, ...]


@dataclass(frozen=True)
class ProbeProfile:
    name: str
    label: str
    range_label: str
    field_unit: str
    resolution: str
    accuracy: str
    measurement_dimension: int | None
    has_temperature: bool | None
    calibration_source: str
    notes: str


GAUSS_DISPLAY_SCALES = {
    "mT": 1.0,
    "G": 10.0,
    "Oe": 10.0,
    "A/m": 795.77,
    "mGs": 10000.0,
}


DEVICE_CAPABILITIES: Dict[str, DeviceCapability] = {
    "1d_gauss": DeviceCapability(
        model="1d_gauss",
        label="一维高斯计 / 1D Gauss",
        measurement_dimension=1,
        field_unit="mT",
        available_units=("mT", "G", "Oe", "A/m", "mGs"),
        display_scales=GAUSS_DISPLAY_SCALES,
        field_components=("x",),
        has_total=True,
        has_freq=True,
        has_temp=True,
        stream_channels=("field_mt", "freq_hz", "temp_c"),
        recorder_fields=("timestamp_s", "field_total_mt", "freq_hz", "temp_c"),
        threshold_channels=("field_total", "field_x"),
        table_columns=("序号 / #", "磁场 / Field (mT)", "频率 / Freq (Hz)", "温度 / Temp (°C)", "时间戳 / Timestamp"),
    ),
    "2d_gauss": DeviceCapability(
        model="2d_gauss",
        label="二维高斯计 / 2D Gauss",
        measurement_dimension=2,
        field_unit="mT",
        available_units=("mT", "G", "Oe", "A/m", "mGs"),
        display_scales=GAUSS_DISPLAY_SCALES,
        field_components=("x", "y"),
        has_total=True,
        has_freq=True,
        has_temp=True,
        stream_channels=("field_x_mt", "field_y_mt", "field_total_mt", "freq_hz", "temp_c"),
        recorder_fields=("timestamp_s", "field_x_mt", "field_y_mt", "field_total_mt", "freq_hz", "temp_c"),
        threshold_channels=("field_total", "field_x", "field_y"),
        table_columns=("序号 / #", "X (mT)", "Y (mT)", "Total B (mT)", "频率 / Freq (Hz)", "温度 / Temp (°C)", "时间戳 / Timestamp"),
    ),
    "3d_gauss": DeviceCapability(
        model="3d_gauss",
        label="三维高斯计 / 3D Gauss",
        measurement_dimension=3,
        field_unit="mT",
        available_units=("mT", "G", "Oe", "A/m", "mGs"),
        display_scales=GAUSS_DISPLAY_SCALES,
        field_components=("x", "y", "z"),
        has_total=True,
        has_freq=True,
        has_temp=True,
        stream_channels=("field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt", "freq_hz", "temp_c"),
        recorder_fields=("timestamp_s", "field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt", "freq_hz", "temp_c"),
        threshold_channels=("field_total", "field_x", "field_y", "field_z"),
        table_columns=("序号 / #", "X (mT)", "Y (mT)", "Z (mT)", "Total B (mT)", "频率 / Freq (Hz)", "温度 / Temp (°C)", "时间戳 / Timestamp"),
    ),
    "fluxmeter": DeviceCapability(
        model="fluxmeter",
        label="磁通计 / Fluxmeter",
        measurement_dimension=1,
        field_unit="mWb",
        available_units=("mWb",),
        display_scales={"mWb": 1.0},
        field_components=("x",),
        has_total=True,
        has_freq=True,
        has_temp=True,
        stream_channels=("field_mt", "freq_hz", "temp_c"),
        recorder_fields=("timestamp_s", "field_total_mt", "freq_hz", "temp_c"),
        threshold_channels=("field_total", "field_x"),
        table_columns=("序号 / #", "磁通 / Flux (mWb)", "频率 / Freq (Hz)", "温度 / Temp (°C)", "时间戳 / Timestamp"),
    ),
    "1d_fluxgate": DeviceCapability(
        model="1d_fluxgate",
        label="一维磁通门计 / 1D Fluxgate",
        measurement_dimension=1,
        field_unit="nT",
        available_units=("nT",),
        display_scales={"nT": 1.0},
        field_components=("x",),
        has_total=True,
        has_freq=True,
        has_temp=True,
        stream_channels=("field_mt", "freq_hz", "temp_c"),
        recorder_fields=("timestamp_s", "field_total_mt", "freq_hz", "temp_c"),
        threshold_channels=("field_total", "field_x"),
        table_columns=("序号 / #", "磁场 / Field (nT)", "频率 / Freq (Hz)", "温度 / Temp (°C)", "时间戳 / Timestamp"),
    ),
    "3d_fluxgate": DeviceCapability(
        model="3d_fluxgate",
        label="三维磁通门计 / 3D Fluxgate",
        measurement_dimension=3,
        field_unit="nT",
        available_units=("nT",),
        display_scales={"nT": 1.0},
        field_components=("x", "y", "z"),
        has_total=True,
        has_freq=False,
        has_temp=False,
        stream_channels=("field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt"),
        recorder_fields=("timestamp_s", "field_x_mt", "field_y_mt", "field_z_mt", "field_total_mt"),
        threshold_channels=("field_total", "field_x", "field_y", "field_z"),
        table_columns=("序号 / #", "X (nT)", "Y (nT)", "Z (nT)", "Total B (nT)", "时间戳 / Timestamp"),
    ),
}


PROBE_PROFILES: Dict[str, ProbeProfile] = {
    "standard_hall": ProbeProfile(
        name="standard_hall",
        label="Model-HCHD801F 标准横向霍尔探头",
        range_label="0~±10T / 100 KGs",
        field_unit="mT",
        resolution="0.0001 mT",
        accuracy="0.2% rdg ±0.05% F.S. (±2T)",
        measurement_dimension=1,
        has_temperature=True,
        calibration_source="probe_nvm",
        notes="Manual states the probe contains non-volatile calibration memory; software readout protocol is not yet proven.",
    ),
    "weak_field": ProbeProfile(
        name="weak_field",
        label="弱磁探头 / Weak-field probe",
        range_label="6 Gs",
        field_unit="uT",
        resolution="0.01 μT",
        accuracy="0.5%",
        measurement_dimension=None,
        has_temperature=None,
        calibration_source="manual_profile",
        notes="Manual lists weak-field accuracy, but frame/unit behavior still needs real samples.",
    ),
    "custom": ProbeProfile(
        name="custom",
        label="自定义/未知探头 / Custom",
        range_label="user-defined",
        field_unit="",
        resolution="",
        accuracy="",
        measurement_dimension=None,
        has_temperature=None,
        calibration_source="user",
        notes="Use when the connected probe differs from the documented standard probe; preserve raw frames for traceability.",
    ),
}


def get_device_capability(model: str) -> DeviceCapability:
    return DEVICE_CAPABILITIES.get(model, DEVICE_CAPABILITIES["1d_gauss"])


def iter_device_capabilities() -> Iterable[DeviceCapability]:
    return DEVICE_CAPABILITIES.values()


def get_probe_profile(name: str) -> ProbeProfile:
    return PROBE_PROFILES.get(name, PROBE_PROFILES["custom"])


def iter_probe_profiles() -> Iterable[ProbeProfile]:
    return PROBE_PROFILES.values()


def _float_value(sample: Mapping[str, Any], *names: str, default: float = 0.0) -> float:
    for name in names:
        if name in sample and sample[name] is not None:
            try:
                return float(sample[name])
            except (TypeError, ValueError):
                return default
    return default


def normalize_sample_by_capability(
    sample: Mapping[str, Any],
    capability: DeviceCapability | str,
) -> Dict[str, Any]:
    cap = get_device_capability(capability) if isinstance(capability, str) else capability
    field_x = _float_value(sample, "field_x", "field_x_mt", "field_mt", "field_total_mt")
    field_y = _float_value(sample, "field_y", "field_y_mt")
    field_z = _float_value(sample, "field_z", "field_z_mt")

    if "y" not in cap.field_components:
        field_y = 0.0
    if "z" not in cap.field_components:
        field_z = 0.0

    total = _float_value(sample, "field_total", "field_total_mt", "field_mt")
    if total == 0.0 and any(value != 0.0 for value in (field_x, field_y, field_z)):
        total = math.sqrt(field_x * field_x + field_y * field_y + field_z * field_z)
    if field_x == 0.0 and total != 0.0 and cap.measurement_dimension == 1:
        field_x = total

    out = dict(sample)
    out.update({
        "device_model": str(sample.get("device_model") or cap.model),
        "field_x": field_x,
        "field_y": field_y,
        "field_z": field_z,
        "field_total": total,
        "field_x_mt": field_x,
        "field_y_mt": field_y,
        "field_z_mt": field_z,
        "field_total_mt": total,
        "field_mt": total,
        "field_unit": str(sample.get("field_unit") or cap.field_unit),
        "freq_hz": _float_value(sample, "freq_hz") if cap.has_freq else 0.0,
        "temp_c": _float_value(sample, "temp_c") if cap.has_temp else 0.0,
    })
    return out
