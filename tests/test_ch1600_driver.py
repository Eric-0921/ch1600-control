"""CH1600Driver 6 种设备模型解析器单元测试

验证标准：解析结果与 DataReader2 源码行为一致（误差 < 1e-6）
"""

import math
import unittest
from unittest.mock import patch

import sys
from pathlib import Path

sys.path.insert(0, str(Path(__file__).parent.parent))

from instruments.ch1600_driver import CH1600Driver


class TestParse1DGauss(unittest.TestCase):
    """一维高斯计解析测试"""

    def test_standard_frame(self):
        """标准短帧: #field/freq/temp>"""
        line = b"#-12345.6789/050/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], -12345.6789, places=6)
        self.assertAlmostEqual(result["freq_hz"], 50.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 23.4, places=2)
        self.assertAlmostEqual(result["field_total_mt"], -12345.6789, places=6)
        self.assertAlmostEqual(result["field_mt"], -12345.6789, places=6)

    def test_positive_field(self):
        """正磁场值"""
        line = b"#+00001.2345/100/+0123>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 1.2345, places=6)
        self.assertAlmostEqual(result["temp_c"], 12.3, places=2)

    def test_dc_zero_freq(self):
        """DC 模式频率为 000"""
        line = b"#-00000.0001/000/+0000>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["freq_hz"], 0.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 0.0, places=2)

    def test_special_prefix_hstdc(self):
        """HSTDC: 前缀帧 — 温度不 ÷10"""
        line = b"HSTDC:/1234.5/50/25>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 123.45, places=6)
        self.assertAlmostEqual(result["freq_hz"], 50.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 25.0, places=2)  # raw, no ÷10

    def test_special_prefix_uhsdc(self):
        """UHSDC: 前缀帧"""
        line = b"UHSDC:/999.9/60/30>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 0.09999, places=6)
        self.assertAlmostEqual(result["temp_c"], 30.0, places=2)  # raw

    def test_invalid_no_hash(self):
        """不以 # 开头且无特殊前缀 → 解析失败"""
        line = b"12345.6789/050/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNone(result)

    def test_invalid_short(self):
        """字段不足 → 解析失败"""
        line = b"#12345.6789/050>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNone(result)


class TestParse2DGauss(unittest.TestCase):
    """二维高斯计解析测试"""

    def test_short_frame(self):
        """短帧 (<40): #X/freq/Y>"""
        line = b"#12.34/50/56.78>\n"
        result = CH1600Driver.parse_stream_frame(line, model="2d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 12.34, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 56.78, places=6)
        self.assertAlmostEqual(result["freq_hz"], 50.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 0.0, places=2)
        expected_total = math.sqrt(12.34 ** 2 + 56.78 ** 2)
        self.assertAlmostEqual(result["field_total_mt"], expected_total, places=6)

    def test_long_frame(self):
        """长帧 (≥40): #X/freq/temp;Y/freq/temp>"""
        line = b"#1234.567890/500/+023456;5678.901234/600/+025678>\n"
        result = CH1600Driver.parse_stream_frame(line, model="2d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 1234.567890, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 5678.901234, places=6)
        self.assertAlmostEqual(result["freq_hz"], 500.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 2345.6, places=2)

    def test_long_frame_with_datareader2_third_segment(self):
        """兼容 DataReader2 反编译源码里的 dg2[2] 长帧索引。"""
        line = b"#1234.567890/500/+023456;0.000000/000/+000000;5678.901234/600/+025678>\n"
        result = CH1600Driver.parse_stream_frame(line, model="2d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 1234.567890, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 5678.901234, places=6)
        self.assertAlmostEqual(result["freq_hz"], 500.0, places=1)

    def test_negative_components(self):
        """负值分量"""
        line = b"#-12.34/50/-56.78>\n"
        result = CH1600Driver.parse_stream_frame(line, model="2d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], -12.34, places=6)
        self.assertAlmostEqual(result["field_y_mt"], -56.78, places=6)

    def test_invalid_no_semicolon(self):
        """长帧缺少 ; 分隔符 → 可能按短帧解析或失败"""
        line = b"#12.34/50/56.78/90.12>\n"
        result = CH1600Driver.parse_stream_frame(line, model="2d_gauss")
        # 长度 < 40 按短帧: parts = [12.34, 50, 56.78/90.12] — 第 3 部分不是纯数字
        # 实际上会失败，因为 parts[2] = "56.78/90.12" 无法转为 float
        self.assertIsNone(result)


class TestParse3DGauss(unittest.TestCase):
    """三维高斯计解析测试"""

    def test_short_frame(self):
        """短帧 (<60): #X/Y/Z>"""
        line = b"#12.34/56.78/90.12>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 12.34, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 56.78, places=6)
        self.assertAlmostEqual(result["field_z_mt"], 90.12, places=6)
        self.assertEqual(result["freq_hz"], 0.0)
        self.assertEqual(result["temp_c"], 0.0)
        expected_total = math.sqrt(12.34 ** 2 + 56.78 ** 2 + 90.12 ** 2)
        self.assertAlmostEqual(result["field_total_mt"], expected_total, places=6)

    def test_long_frame(self):
        """长帧 (≥60): #X/freq/temp;Y/freq/temp;Z/freq/temp>"""
        line = b"#1234.567890/500/+023456;5678.901234/600/+025678;9012.345678/700/+027890>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 1234.567890, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 5678.901234, places=6)
        self.assertAlmostEqual(result["field_z_mt"], 9012.345678, places=6)
        self.assertAlmostEqual(result["freq_hz"], 500.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 2345.6, places=2)

    def test_zero_field(self):
        """零磁场"""
        line = b"#0.00/0.00/0.00>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_gauss")
        self.assertIsNotNone(result)
        self.assertEqual(result["field_total_mt"], 0.0)


class TestParseFluxmeter(unittest.TestCase):
    """磁通计解析测试"""

    def test_with_null_prefix(self):
        """带 \0 前缀的标准帧"""
        line = b"\0#123.45/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="fluxmeter")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 123.45, places=6)
        self.assertAlmostEqual(result["freq_hz"], 50.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 23.4, places=2)

    def test_without_hash(self):
        """不带 # 的帧（\0 后直接数值）"""
        line = b"\x00123.45/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="fluxmeter")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 123.45, places=6)

    def test_no_null_prefix(self):
        """不带 \0 前缀（某些批次可能不发 \0）"""
        line = b"#123.45/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="fluxmeter")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 123.45, places=6)


class TestParse1DFluxgate(unittest.TestCase):
    """一维磁通门计解析测试"""

    def test_standard_frame(self):
        """标准帧: #value/freq/temp>"""
        line = b"#123.45/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_fluxgate")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 123.45, places=6)
        self.assertAlmostEqual(result["freq_hz"], 50.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 23.4, places=2)

    def test_nt_precision(self):
        """nT 级精度小数位"""
        line = b"#0.12345/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_fluxgate")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 0.12345, places=6)

    def test_invalid_no_hash(self):
        """不以 # 开头 → 失败"""
        line = b"123.45/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_fluxgate")
        self.assertIsNone(result)


class TestParse3DFluxgate(unittest.TestCase):
    """三维磁通门计解析测试"""

    def test_standard_frame(self):
        """标准帧: #X/Y/Z>"""
        line = b"#12.34/56.78/90.12>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_fluxgate")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 12.34, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 56.78, places=6)
        self.assertAlmostEqual(result["field_z_mt"], 90.12, places=6)
        self.assertEqual(result["freq_hz"], 0.0)
        self.assertEqual(result["temp_c"], 0.0)
        expected_total = math.sqrt(12.34 ** 2 + 56.78 ** 2 + 90.12 ** 2)
        self.assertAlmostEqual(result["field_total_mt"], expected_total, places=6)

    def test_no_freq_temp(self):
        """确认无频率温度字段"""
        line = b"#1.0/2.0/3.0>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_fluxgate")
        self.assertIsNotNone(result)
        self.assertEqual(result["freq_hz"], 0.0)
        self.assertEqual(result["temp_c"], 0.0)

    def test_invalid_short(self):
        """字段不足 → 失败"""
        line = b"#12.34/56.78>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_fluxgate")
        self.assertIsNone(result)


class TestUnifiedReturnFormat(unittest.TestCase):
    """统一返回格式验证"""

    def test_all_models_return_same_keys(self):
        """所有模型返回相同的键集合"""
        expected_keys = {
            "field_x_mt", "field_y_mt", "field_z_mt",
            "field_total_mt", "freq_hz", "temp_c", "field_mt",
        }
        models = ["1d_gauss", "2d_gauss", "3d_gauss", "fluxmeter", "1d_fluxgate", "3d_fluxgate"]
        lines = [
            b"#123.45/50/+0234>\n",
            b"#12.34/50/56.78>\n",
            b"#12.34/56.78/90.12>\n",
            b"\0#123.45/50/+0234>\n",
            b"#123.45/50/+0234>\n",
            b"#12.34/56.78/90.12>\n",
        ]
        for model, line in zip(models, lines):
            with self.subTest(model=model):
                result = CH1600Driver.parse_stream_frame(line, model=model)
                self.assertIsNotNone(result)
                self.assertEqual(set(result.keys()), expected_keys)

    def test_backward_compat_field_mt(self):
        """field_mt 别名等于 field_total_mt"""
        line = b"#12.34/56.78/90.12>\n"
        result = CH1600Driver.parse_stream_frame(line, model="3d_gauss")
        self.assertAlmostEqual(result["field_mt"], result["field_total_mt"], places=10)


class TestEdgeCases(unittest.TestCase):
    """边界条件测试"""

    def test_empty_line(self):
        """空行"""
        result = CH1600Driver.parse_stream_frame(b"", model="1d_gauss")
        self.assertIsNone(result)

    def test_garbage_data(self):
        """乱码数据"""
        result = CH1600Driver.parse_stream_frame(b"\x00\x01\x02\x03", model="1d_gauss")
        self.assertIsNone(result)

    def test_truncated_frame(self):
        """截断帧"""
        result = CH1600Driver.parse_stream_frame(b"#1234", model="1d_gauss")
        self.assertIsNone(result)

    def test_unicode_in_frame(self):
        """非 ASCII 字符"""
        result = CH1600Driver.parse_stream_frame("#你好/50/25>".encode("utf-8"), model="1d_gauss")
        self.assertIsNone(result)

    def test_unknown_model_fallback(self):
        """未知型号回退到 1d_gauss"""
        line = b"#123.45/50/+0234>\n"
        result = CH1600Driver.parse_stream_frame(line, model="unknown_model")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 123.45, places=6)

    def test_parse_first_stream_frame_splits_panel_preview(self):
        preview = b"not-a-frame\r\n#1.0/0/+250>\n#2.0/0/+260>\n"
        result = CH1600Driver.parse_first_stream_frame(preview, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_total_mt"], 1.0, places=6)
        self.assertAlmostEqual(result["temp_c"], 25.0, places=6)


class FakeSerial:
    def __init__(self, response: bytes = b"") -> None:
        self.is_open = True
        self.writes = []
        self._buffer = response
        self.closed = False

    @property
    def in_waiting(self) -> int:
        return len(self._buffer)

    def write(self, data: bytes) -> None:
        self.writes.append(data)

    def read(self, n: int) -> bytes:
        data = self._buffer[:n]
        self._buffer = self._buffer[n:]
        return data

    def read_until(self, _terminator: bytes = b"\n") -> bytes:
        return self.read(len(self._buffer))

    def reset_input_buffer(self) -> None:
        pass

    def reset_output_buffer(self) -> None:
        pass

    def close(self) -> None:
        self.closed = True
        self.is_open = False

    def __enter__(self):
        return self

    def __exit__(self, *_exc):
        self.close()


class TestCommandFraming(unittest.TestCase):
    def _driver_with_fake_serial(self, response: bytes = b""):
        driver = CH1600Driver()
        fake = FakeSerial(response=response)
        driver._serial = fake
        driver._panel_streaming_mode = False
        return driver, fake

    def test_send_command_adds_protocol_terminator(self):
        driver, fake = self._driver_with_fake_serial(b"mT\n")
        with patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            result = driver._send_command("UNIT?")
        self.assertEqual(result, b"mT\n")
        self.assertEqual(fake.writes[-1], b"UNIT?>\r")

    def test_send_command_does_not_duplicate_terminator(self):
        driver, fake = self._driver_with_fake_serial()
        with patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            driver._send_command("DATA?>")
        self.assertEqual(fake.writes[-1], b"DATA?>\r")

    def test_start_streaming_uses_1d_fast2_shorthand(self):
        driver, fake = self._driver_with_fake_serial()
        with patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            driver.start_streaming(mode_key="dc_20hz", model="1d_gauss")
        self.assertEqual(fake.writes[-1], b"FAST2>\r")
        self.assertTrue(driver.is_streaming)

    def test_start_streaming_preserves_fast_command_suffix(self):
        driver, fake = self._driver_with_fake_serial()
        with patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            driver.start_streaming(mode_key="dc_100hz", model="2d_gauss")
        self.assertEqual(fake.writes[-1], b"FAST100>\r")

    def test_threshold_command_is_framed(self):
        driver, fake = self._driver_with_fake_serial()
        with patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            driver.set_up_threshold(-1.23)
        self.assertEqual(fake.writes[-1], b"UPTHRES-1.23>\r")

    def test_query_data_once_uses_requested_model(self):
        driver, fake = self._driver_with_fake_serial(b"ACK#3.0/4.0/12.0>\n")
        with patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            result = driver.query_data_once(model="3d_fluxgate")
        self.assertEqual(fake.writes[-1], b"DATAS>\r")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 3.0, places=6)
        self.assertAlmostEqual(result["field_y_mt"], 4.0, places=6)
        self.assertAlmostEqual(result["field_z_mt"], 12.0, places=6)

    def test_connect_rejects_unverified_unit_response(self):
        fake = FakeSerial(response=b"NOT_A_CH1600\n")
        driver = CH1600Driver()
        with patch("instruments.ch1600_driver.serial.Serial", return_value=fake), \
             patch("instruments.ch1600_driver._time.sleep", lambda _: None):
            with self.assertRaises(RuntimeError):
                driver.connect("COM_FAKE")
        self.assertTrue(fake.closed)

    def test_scan_ports_omits_unverified_devices(self):
        class Port:
            device = "COM_FAKE"

        with patch("serial.tools.list_ports.comports", return_value=[Port()]), \
             patch("instruments.ch1600_driver.serial.Serial", return_value=FakeSerial(response=b"noise\n")):
            self.assertEqual(CH1600Driver.scan_ports(), [])


if __name__ == "__main__":
    unittest.main()
