"""CH1600Driver 6 种设备模型解析器单元测试

验证标准：解析结果与 DataReader2 源码行为一致（误差 < 1e-6）
"""

import math
import unittest

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
        self.assertAlmostEqual(result["field_x_mt"], 1234.5, places=6)
        self.assertAlmostEqual(result["freq_hz"], 50.0, places=1)
        self.assertAlmostEqual(result["temp_c"], 25.0, places=2)  # raw, no ÷10

    def test_special_prefix_uhsdc(self):
        """UHSDC: 前缀帧"""
        line = b"UHSDC:/999.9/60/30>\n"
        result = CH1600Driver.parse_stream_frame(line, model="1d_gauss")
        self.assertIsNotNone(result)
        self.assertAlmostEqual(result["field_x_mt"], 999.9, places=6)
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


if __name__ == "__main__":
    unittest.main()
