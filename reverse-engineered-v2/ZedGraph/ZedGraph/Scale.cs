using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public abstract class Scale : ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static double ZeroLever = 0.25;

		public static double MinGrace = 0.1;

		public static double MaxGrace = 0.1;

		public static double MaxTextLabels = 12.0;

		public static double TargetXSteps = 7.0;

		public static double TargetYSteps = 7.0;

		public static double TargetMinorXSteps = 5.0;

		public static double TargetMinorYSteps = 5.0;

		public static bool IsReverse = false;

		public static string Format = "g";

		public static double RangeYearYear = 1825.0;

		public static double RangeYearMonth = 730.0;

		public static double RangeMonthMonth = 300.0;

		public static double RangeDayDay = 10.0;

		public static double RangeDayHour = 3.0;

		public static double RangeHourHour = 0.4167;

		public static double RangeHourMinute = 0.125;

		public static double RangeMinuteMinute = 0.00694;

		public static double RangeMinuteSecond = 0.002083;

		public static double RangeSecondSecond = 3.472E-05;

		public static string FormatYearYear = "yyyy";

		public static string FormatYearMonth = "MMM-yyyy";

		public static string FormatMonthMonth = "MMM-yyyy";

		public static string FormatDayDay = "d-MMM";

		public static string FormatDayHour = "d-MMM HH:mm";

		public static string FormatHourHour = "HH:mm";

		public static string FormatHourMinute = "HH:mm";

		public static string FormatMinuteMinute = "HH:mm";

		public static string FormatMinuteSecond = "mm:ss";

		public static string FormatSecondSecond = "mm:ss";

		public static string FormatMillisecond = "ss.fff";

		public static AlignP Align = AlignP.Center;

		public static AlignH AlignH = AlignH.Center;

		public static string FontFamily = "Arial";

		public static float FontSize = 14f;

		public static Color FontColor = Color.Black;

		public static bool FontBold = false;

		public static bool FontItalic = false;

		public static bool FontUnderline = false;

		public static Color FillColor = Color.White;

		public static Brush FillBrush = null;

		public static FillType FillType = FillType.None;

		public static bool IsVisible = true;

		public static bool IsLabelsInside = false;

		public static float EdgeTolerance = 6f;

		public static float LabelGap = 0.3f;
	}

	public const int schema = 11;

	internal double _min;

	internal double _max;

	internal double _majorStep;

	internal double _minorStep;

	internal double _exponent;

	internal double _baseTic;

	internal bool _minAuto;

	internal bool _maxAuto;

	internal bool _majorStepAuto;

	internal bool _minorStepAuto;

	internal bool _magAuto;

	internal bool _formatAuto;

	internal double _minGrace;

	internal double _maxGrace;

	internal int _mag;

	internal bool _isReverse;

	internal bool _isPreventLabelOverlap;

	internal bool _isUseTenPower;

	internal bool _isLabelsInside;

	internal bool _isSkipFirstLabel;

	internal bool _isSkipLastLabel;

	internal bool _isSkipCrossLabel;

	internal bool _isVisible;

	internal string[] _textLabels;

	internal string _format;

	internal DateUnit _majorUnit;

	internal DateUnit _minorUnit;

	internal AlignP _align;

	internal AlignH _alignH;

	internal FontSpec _fontSpec;

	internal float _labelGap;

	internal double _rangeMin;

	internal double _rangeMax;

	internal double _lBound;

	internal double _uBound;

	internal float _minPix;

	internal float _maxPix;

	internal double _minLinTemp;

	internal double _maxLinTemp;

	internal Axis _ownerAxis;

	internal double _minLinearized
	{
		get
		{
			return Linearize(_min);
		}
		set
		{
			_min = DeLinearize(value);
		}
	}

	internal double _maxLinearized
	{
		get
		{
			return Linearize(_max);
		}
		set
		{
			_max = DeLinearize(value);
		}
	}

	public abstract AxisType Type { get; }

	public bool IsLog => this is LogScale;

	public bool IsExponent => this is ExponentScale;

	public bool IsDate => this is DateScale;

	public bool IsText => this is TextScale;

	public bool IsOrdinal => this is OrdinalScale;

	public bool IsAnyOrdinal
	{
		get
		{
			AxisType type = Type;
			if (type != AxisType.Ordinal && type != AxisType.Text && type != AxisType.LinearAsOrdinal)
			{
				return type == AxisType.DateAsOrdinal;
			}
			return true;
		}
	}

	public virtual double Min
	{
		get
		{
			return _min;
		}
		set
		{
			_min = value;
			_minAuto = false;
		}
	}

	public virtual double Max
	{
		get
		{
			return _max;
		}
		set
		{
			_max = value;
			_maxAuto = false;
		}
	}

	public double MajorStep
	{
		get
		{
			return _majorStep;
		}
		set
		{
			if (value < 1E-300)
			{
				_majorStepAuto = true;
				return;
			}
			_majorStep = value;
			_majorStepAuto = false;
		}
	}

	public double MinorStep
	{
		get
		{
			return _minorStep;
		}
		set
		{
			if (value < 1E-300)
			{
				_minorStepAuto = true;
				return;
			}
			_minorStep = value;
			_minorStepAuto = false;
		}
	}

	public double Exponent
	{
		get
		{
			return _exponent;
		}
		set
		{
			_exponent = value;
		}
	}

	public double BaseTic
	{
		get
		{
			return _baseTic;
		}
		set
		{
			_baseTic = value;
		}
	}

	public DateUnit MajorUnit
	{
		get
		{
			return _majorUnit;
		}
		set
		{
			_majorUnit = value;
		}
	}

	public DateUnit MinorUnit
	{
		get
		{
			return _minorUnit;
		}
		set
		{
			_minorUnit = value;
		}
	}

	internal virtual double MajorUnitMultiplier => 1.0;

	internal virtual double MinorUnitMultiplier => 1.0;

	public bool MinAuto
	{
		get
		{
			return _minAuto;
		}
		set
		{
			_minAuto = value;
		}
	}

	public bool MaxAuto
	{
		get
		{
			return _maxAuto;
		}
		set
		{
			_maxAuto = value;
		}
	}

	public bool MajorStepAuto
	{
		get
		{
			return _majorStepAuto;
		}
		set
		{
			_majorStepAuto = value;
		}
	}

	public bool MinorStepAuto
	{
		get
		{
			return _minorStepAuto;
		}
		set
		{
			_minorStepAuto = value;
		}
	}

	public bool FormatAuto
	{
		get
		{
			return _formatAuto;
		}
		set
		{
			_formatAuto = value;
		}
	}

	public string Format
	{
		get
		{
			return _format;
		}
		set
		{
			_format = value;
			_formatAuto = false;
		}
	}

	public int Mag
	{
		get
		{
			return _mag;
		}
		set
		{
			_mag = value;
			_magAuto = false;
		}
	}

	public bool MagAuto
	{
		get
		{
			return _magAuto;
		}
		set
		{
			_magAuto = value;
		}
	}

	public double MinGrace
	{
		get
		{
			return _minGrace;
		}
		set
		{
			_minGrace = value;
		}
	}

	public double MaxGrace
	{
		get
		{
			return _maxGrace;
		}
		set
		{
			_maxGrace = value;
		}
	}

	public AlignP Align
	{
		get
		{
			return _align;
		}
		set
		{
			_align = value;
		}
	}

	public AlignH AlignH
	{
		get
		{
			return _alignH;
		}
		set
		{
			_alignH = value;
		}
	}

	public FontSpec FontSpec
	{
		get
		{
			return _fontSpec;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException("Uninitialized FontSpec in Scale");
			}
			_fontSpec = value;
		}
	}

	public float LabelGap
	{
		get
		{
			return _labelGap;
		}
		set
		{
			_labelGap = value;
		}
	}

	public bool IsLabelsInside
	{
		get
		{
			return _isLabelsInside;
		}
		set
		{
			_isLabelsInside = value;
		}
	}

	public bool IsSkipFirstLabel
	{
		get
		{
			return _isSkipFirstLabel;
		}
		set
		{
			_isSkipFirstLabel = value;
		}
	}

	public bool IsSkipLastLabel
	{
		get
		{
			return _isSkipLastLabel;
		}
		set
		{
			_isSkipLastLabel = value;
		}
	}

	public bool IsSkipCrossLabel
	{
		get
		{
			return _isSkipCrossLabel;
		}
		set
		{
			_isSkipCrossLabel = value;
		}
	}

	public bool IsReverse
	{
		get
		{
			return _isReverse;
		}
		set
		{
			_isReverse = value;
		}
	}

	public bool IsUseTenPower
	{
		get
		{
			return _isUseTenPower;
		}
		set
		{
			_isUseTenPower = value;
		}
	}

	public bool IsPreventLabelOverlap
	{
		get
		{
			return _isPreventLabelOverlap;
		}
		set
		{
			_isPreventLabelOverlap = value;
		}
	}

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			_isVisible = value;
		}
	}

	public string[] TextLabels
	{
		get
		{
			return _textLabels;
		}
		set
		{
			_textLabels = value;
		}
	}

	public Scale(Axis ownerAxis)
	{
		_ownerAxis = ownerAxis;
		_min = 0.0;
		_max = 1.0;
		_majorStep = 0.1;
		_minorStep = 0.1;
		_exponent = 1.0;
		_mag = 0;
		_baseTic = double.MaxValue;
		_minGrace = Default.MinGrace;
		_maxGrace = Default.MaxGrace;
		_minAuto = true;
		_maxAuto = true;
		_majorStepAuto = true;
		_minorStepAuto = true;
		_magAuto = true;
		_formatAuto = true;
		_isReverse = Default.IsReverse;
		_isUseTenPower = true;
		_isPreventLabelOverlap = true;
		_isVisible = true;
		_isSkipFirstLabel = false;
		_isSkipLastLabel = false;
		_isSkipCrossLabel = false;
		_majorUnit = DateUnit.Day;
		_minorUnit = DateUnit.Day;
		_format = null;
		_textLabels = null;
		_isLabelsInside = Default.IsLabelsInside;
		_align = Default.Align;
		_alignH = Default.AlignH;
		_fontSpec = new FontSpec(Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontUnderline, Default.FontItalic, Default.FillColor, Default.FillBrush, Default.FillType);
		_fontSpec.Border.IsVisible = false;
		_labelGap = Default.LabelGap;
	}

	public Scale(Scale rhs, Axis owner)
	{
		_ownerAxis = owner;
		_min = rhs._min;
		_max = rhs._max;
		_majorStep = rhs._majorStep;
		_minorStep = rhs._minorStep;
		_exponent = rhs._exponent;
		_baseTic = rhs._baseTic;
		_minAuto = rhs._minAuto;
		_maxAuto = rhs._maxAuto;
		_majorStepAuto = rhs._majorStepAuto;
		_minorStepAuto = rhs._minorStepAuto;
		_magAuto = rhs._magAuto;
		_formatAuto = rhs._formatAuto;
		_minGrace = rhs._minGrace;
		_maxGrace = rhs._maxGrace;
		_mag = rhs._mag;
		_isUseTenPower = rhs._isUseTenPower;
		_isReverse = rhs._isReverse;
		_isPreventLabelOverlap = rhs._isPreventLabelOverlap;
		_isVisible = rhs._isVisible;
		_isSkipFirstLabel = rhs._isSkipFirstLabel;
		_isSkipLastLabel = rhs._isSkipLastLabel;
		_isSkipCrossLabel = rhs._isSkipCrossLabel;
		_majorUnit = rhs._majorUnit;
		_minorUnit = rhs._minorUnit;
		_format = rhs._format;
		_isLabelsInside = rhs._isLabelsInside;
		_align = rhs._align;
		_alignH = rhs._alignH;
		_fontSpec = rhs._fontSpec.Clone();
		_labelGap = rhs._labelGap;
		if (rhs._textLabels != null)
		{
			_textLabels = (string[])rhs._textLabels.Clone();
		}
		else
		{
			_textLabels = null;
		}
	}

	public abstract Scale Clone(Axis owner);

	public Scale MakeNewScale(Scale oldScale, AxisType type)
	{
		return type switch
		{
			AxisType.Linear => new LinearScale(oldScale, _ownerAxis), 
			AxisType.Date => new DateScale(oldScale, _ownerAxis), 
			AxisType.Log => new LogScale(oldScale, _ownerAxis), 
			AxisType.Exponent => new ExponentScale(oldScale, _ownerAxis), 
			AxisType.Ordinal => new OrdinalScale(oldScale, _ownerAxis), 
			AxisType.Text => new TextScale(oldScale, _ownerAxis), 
			AxisType.DateAsOrdinal => new DateAsOrdinalScale(oldScale, _ownerAxis), 
			AxisType.LinearAsOrdinal => new LinearAsOrdinalScale(oldScale, _ownerAxis), 
			_ => throw new Exception("Implementation Error: Invalid AxisType"), 
		};
	}

	protected Scale(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_min = info.GetDouble("min");
		_max = info.GetDouble("max");
		_majorStep = info.GetDouble("majorStep");
		_minorStep = info.GetDouble("minorStep");
		_exponent = info.GetDouble("exponent");
		_baseTic = info.GetDouble("baseTic");
		_minAuto = info.GetBoolean("minAuto");
		_maxAuto = info.GetBoolean("maxAuto");
		_majorStepAuto = info.GetBoolean("majorStepAuto");
		_minorStepAuto = info.GetBoolean("minorStepAuto");
		_magAuto = info.GetBoolean("magAuto");
		_formatAuto = info.GetBoolean("formatAuto");
		_minGrace = info.GetDouble("minGrace");
		_maxGrace = info.GetDouble("maxGrace");
		_mag = info.GetInt32("mag");
		_isReverse = info.GetBoolean("isReverse");
		_isPreventLabelOverlap = info.GetBoolean("isPreventLabelOverlap");
		_isUseTenPower = info.GetBoolean("isUseTenPower");
		_isVisible = true;
		_isVisible = info.GetBoolean("isVisible");
		_isSkipFirstLabel = info.GetBoolean("isSkipFirstLabel");
		_isSkipLastLabel = info.GetBoolean("isSkipLastLabel");
		_isSkipCrossLabel = info.GetBoolean("isSkipCrossLabel");
		_textLabels = (string[])info.GetValue("textLabels", typeof(string[]));
		_format = info.GetString("format");
		_majorUnit = (DateUnit)info.GetValue("majorUnit", typeof(DateUnit));
		_minorUnit = (DateUnit)info.GetValue("minorUnit", typeof(DateUnit));
		_isLabelsInside = info.GetBoolean("isLabelsInside");
		_align = (AlignP)info.GetValue("align", typeof(AlignP));
		_alignH = (AlignH)info.GetValue("alignH", typeof(AlignH));
		_fontSpec = (FontSpec)info.GetValue("fontSpec", typeof(FontSpec));
		_labelGap = info.GetSingle("labelGap");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 11);
		info.AddValue("min", _min);
		info.AddValue("max", _max);
		info.AddValue("majorStep", _majorStep);
		info.AddValue("minorStep", _minorStep);
		info.AddValue("exponent", _exponent);
		info.AddValue("baseTic", _baseTic);
		info.AddValue("minAuto", _minAuto);
		info.AddValue("maxAuto", _maxAuto);
		info.AddValue("majorStepAuto", _majorStepAuto);
		info.AddValue("minorStepAuto", _minorStepAuto);
		info.AddValue("magAuto", _magAuto);
		info.AddValue("formatAuto", _formatAuto);
		info.AddValue("minGrace", _minGrace);
		info.AddValue("maxGrace", _maxGrace);
		info.AddValue("mag", _mag);
		info.AddValue("isReverse", _isReverse);
		info.AddValue("isPreventLabelOverlap", _isPreventLabelOverlap);
		info.AddValue("isUseTenPower", _isUseTenPower);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("isSkipFirstLabel", _isSkipFirstLabel);
		info.AddValue("isSkipLastLabel", _isSkipLastLabel);
		info.AddValue("isSkipCrossLabel", _isSkipCrossLabel);
		info.AddValue("textLabels", _textLabels);
		info.AddValue("format", _format);
		info.AddValue("majorUnit", _majorUnit);
		info.AddValue("minorUnit", _minorUnit);
		info.AddValue("isLabelsInside", _isLabelsInside);
		info.AddValue("align", _align);
		info.AddValue("alignH", _alignH);
		info.AddValue("fontSpec", _fontSpec);
		info.AddValue("labelGap", _labelGap);
	}

	public virtual void SetupScaleData(GraphPane pane, Axis axis)
	{
		if (axis is XAxis || axis is X2Axis)
		{
			_minPix = pane.Chart._rect.Left;
			_maxPix = pane.Chart._rect.Right;
		}
		else
		{
			_minPix = pane.Chart._rect.Top;
			_maxPix = pane.Chart._rect.Bottom;
		}
		_minLinTemp = Linearize(_min);
		_maxLinTemp = Linearize(_max);
	}

	public virtual double Linearize(double val)
	{
		return val;
	}

	public virtual double DeLinearize(double val)
	{
		return val;
	}

	internal virtual string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		double num = Math.Pow(10.0, _mag);
		return (dVal / num).ToString(_format);
	}

	internal SizeF GetScaleMaxSpace(Graphics g, GraphPane pane, float scaleFactor, bool applyAngle)
	{
		if (_isVisible)
		{
			Math.Pow(10.0, _mag);
			float angle = _fontSpec.Angle;
			if (!applyAngle)
			{
				_fontSpec.Angle = 0f;
			}
			int num = CalcNumTics();
			double baseVal = CalcBaseTic();
			SizeF result = new SizeF(0f, 0f);
			for (int i = 0; i < num; i++)
			{
				double dVal = CalcMajorTicValue(baseVal, i);
				string text = _ownerAxis.MakeLabelEventWorks(pane, i, dVal);
				SizeF sizeF = ((!IsLog || !_isUseTenPower) ? _fontSpec.BoundingBox(g, text, scaleFactor) : _fontSpec.BoundingBoxTenPower(g, text, scaleFactor));
				if (sizeF.Height > result.Height)
				{
					result.Height = sizeF.Height;
				}
				if (sizeF.Width > result.Width)
				{
					result.Width = sizeF.Width;
				}
			}
			_fontSpec.Angle = angle;
			return result;
		}
		return new SizeF(0f, 0f);
	}

	internal virtual double CalcMajorTicValue(double baseVal, double tic)
	{
		return baseVal + _majorStep * tic;
	}

	internal virtual double CalcMinorTicValue(double baseVal, int iTic)
	{
		return baseVal + _minorStep * (double)iTic;
	}

	internal virtual int CalcMinorStart(double baseVal)
	{
		return (int)((_min - baseVal) / _minorStep);
	}

	internal virtual double CalcBaseTic()
	{
		if (_baseTic != double.MaxValue)
		{
			return _baseTic;
		}
		if (IsAnyOrdinal)
		{
			return 1.0;
		}
		return Math.Ceiling(_min / _majorStep - 1E-08) * _majorStep;
	}

	internal void DrawLabels(Graphics g, GraphPane pane, double baseVal, int nTics, float topPix, float shift, float scaleFactor)
	{
		MajorTic majorTic = _ownerAxis._majorTic;
		float scaledTic = majorTic.ScaledTic(scaleFactor);
		Math.Pow(10.0, _mag);
		using Pen pen = majorTic.GetPen(pane, scaleFactor);
		SizeF scaleMaxSpace = GetScaleMaxSpace(g, pane, scaleFactor, applyAngle: true);
		float height = _fontSpec.GetHeight(scaleFactor);
		float height2 = scaleMaxSpace.Height;
		float num = Default.EdgeTolerance * scaleFactor;
		double num2 = (_maxLinTemp - _minLinTemp) * 0.001;
		int num3 = (int)((_minLinTemp - baseVal) / _majorStep + 0.99);
		if (num3 < 0)
		{
			num3 = 0;
		}
		float num4 = -10000f;
		for (int i = num3; i < nTics + num3; i++)
		{
			double num5 = CalcMajorTicValue(baseVal, i);
			if (num5 < _minLinTemp)
			{
				continue;
			}
			if (num5 > _maxLinTemp + num2)
			{
				break;
			}
			float num6 = LocalTransform(num5);
			float pixVal;
			if (majorTic._isBetweenLabels && IsText)
			{
				double num7;
				if (i == 0)
				{
					num7 = CalcMajorTicValue(baseVal, -0.5);
					if (num7 >= _minLinTemp)
					{
						pixVal = LocalTransform(num7);
						majorTic.Draw(g, pane, pen, pixVal, topPix, shift, scaledTic);
					}
				}
				num7 = CalcMajorTicValue(baseVal, (double)i + 0.5);
				if (num7 > _maxLinTemp)
				{
					break;
				}
				pixVal = LocalTransform(num7);
			}
			else
			{
				pixVal = num6;
			}
			majorTic.Draw(g, pane, pen, pixVal, topPix, shift, scaledTic);
			bool flag = ((_ownerAxis is XAxis || _ownerAxis is Y2Axis) && !IsReverse) || (_ownerAxis is Y2Axis && IsReverse);
			bool flag2 = (((_isSkipFirstLabel && flag) || (_isSkipLastLabel && !flag)) && num6 < num) || (((_isSkipLastLabel && flag) || (_isSkipFirstLabel && !flag)) && num6 > _maxPix - _minPix - num);
			bool flag3 = _isSkipCrossLabel && !_ownerAxis._crossAuto && Math.Abs(_ownerAxis._cross - num5) < num2 * 10.0;
			flag2 = flag2 || flag3;
			if (_isVisible && !flag2 && (!IsPreventLabelOverlap || !(Math.Abs(num6 - num4) < scaleMaxSpace.Width)))
			{
				DrawLabel(g, pane, i, num5, num6, shift, height2, scaledTic, height, scaleFactor);
				num4 = num6;
			}
		}
	}

	internal void DrawGrid(Graphics g, GraphPane pane, double baseVal, float topPix, float scaleFactor)
	{
		MajorTic majorTic = _ownerAxis._majorTic;
		MajorGrid majorGrid = _ownerAxis._majorGrid;
		int num = CalcNumTics();
		using Pen pen = majorGrid.GetPen(pane, scaleFactor);
		double num2 = (_maxLinTemp - _minLinTemp) * 0.001;
		int num3 = (int)((_minLinTemp - baseVal) / _majorStep + 0.99);
		if (num3 < 0)
		{
			num3 = 0;
		}
		for (int i = num3; i < num + num3; i++)
		{
			double num4 = CalcMajorTicValue(baseVal, i);
			if (num4 < _minLinTemp)
			{
				continue;
			}
			if (num4 > _maxLinTemp + num2)
			{
				break;
			}
			float num5 = LocalTransform(num4);
			float pixVal;
			if (majorTic._isBetweenLabels && IsText)
			{
				double num6;
				if (i == 0)
				{
					num6 = CalcMajorTicValue(baseVal, -0.5);
					if (num6 >= _minLinTemp)
					{
						pixVal = LocalTransform(num6);
						majorGrid.Draw(g, pen, pixVal, topPix);
					}
				}
				num6 = CalcMajorTicValue(baseVal, (double)i + 0.5);
				if (num6 > _maxLinTemp)
				{
					break;
				}
				pixVal = LocalTransform(num6);
			}
			else
			{
				pixVal = num5;
			}
			majorGrid.Draw(g, pen, pixVal, topPix);
		}
	}

	internal void DrawLabel(Graphics g, GraphPane pane, int i, double dVal, float pixVal, float shift, float maxSpace, float scaledTic, float charHeight, float scaleFactor)
	{
		float num = ((!_ownerAxis.MajorTic.IsOutside) ? (charHeight * _labelGap) : (scaledTic + charHeight * _labelGap));
		string text = _ownerAxis.MakeLabelEventWorks(pane, i, dVal);
		float num2 = ((!IsLog || !_isUseTenPower) ? _fontSpec.BoundingBox(g, text, scaleFactor).Height : _fontSpec.BoundingBoxTenPower(g, text, scaleFactor).Height);
		float num3 = ((_align == AlignP.Center) ? (num + maxSpace / 2f) : ((_align != AlignP.Outside) ? (num + num2 / 2f) : (num + maxSpace - num2 / 2f)));
		num3 = ((!_isLabelsInside) ? (shift + num3) : (shift - num3));
		AlignV alignV = AlignV.Center;
		AlignH alignH = AlignH.Center;
		if (_ownerAxis is XAxis || _ownerAxis is X2Axis)
		{
			alignH = _alignH;
		}
		else
		{
			alignV = ((_alignH != AlignH.Left) ? ((_alignH != AlignH.Right) ? AlignV.Center : AlignV.Bottom) : AlignV.Top);
		}
		if (IsLog && _isUseTenPower)
		{
			_fontSpec.DrawTenPower(g, pane, text, pixVal, num3, alignH, alignV, scaleFactor);
		}
		else
		{
			_fontSpec.Draw(g, pane, text, pixVal, num3, alignH, alignV, scaleFactor);
		}
	}

	internal void Draw(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
	{
		MajorGrid majorGrid = _ownerAxis._majorGrid;
		MajorTic majorTic = _ownerAxis._majorTic;
		_ = _ownerAxis._minorTic;
		GetTopRightPix(pane, out var topPix, out var rightPix);
		int nTics = CalcNumTics();
		double baseVal = CalcBaseTic();
		using (Pen pen = new Pen(_ownerAxis.Color, pane.ScaledPenWidth(majorTic._penWidth, scaleFactor)))
		{
			if (_ownerAxis.IsAxisSegmentVisible)
			{
				g.DrawLine(pen, 0f, shiftPos, rightPix, shiftPos);
			}
			if (majorGrid._isZeroLine && _min < 0.0 && _max > 0.0)
			{
				float num = LocalTransform(0.0);
				g.DrawLine(pen, num, 0f, num, topPix);
			}
		}
		DrawLabels(g, pane, baseVal, nTics, topPix, shiftPos, scaleFactor);
		_ownerAxis.DrawTitle(g, pane, shiftPos, scaleFactor);
	}

	internal void GetTopRightPix(GraphPane pane, out float topPix, out float rightPix)
	{
		if (_ownerAxis is XAxis || _ownerAxis is X2Axis)
		{
			rightPix = pane.Chart._rect.Width;
			topPix = 0f - pane.Chart._rect.Height;
		}
		else
		{
			rightPix = pane.Chart._rect.Height;
			topPix = 0f - pane.Chart._rect.Width;
		}
		if (!(_min >= _max) && !IsLog && !(_majorStep <= 0.0) && !(_minorStep <= 0.0))
		{
			double num = (_max - _min) / (_majorStep * MajorUnitMultiplier);
			double num2 = (_max - _min) / (_minorStep * MinorUnitMultiplier);
			MinorTic minorTic = _ownerAxis._minorTic;
			if (!(num > 1000.0) && (minorTic.IsOutside || minorTic.IsInside || minorTic.IsOpposite) && !(num2 > 5000.0))
			{
			}
		}
	}

	public float GetClusterWidth(GraphPane pane)
	{
		double min = _min;
		return Math.Abs(Transform(min + (IsAnyOrdinal ? 1.0 : pane._barSettings._clusterScaleWidth)) - Transform(min));
	}

	public float GetClusterWidth(double clusterScaleWidth)
	{
		double min = _min;
		return Math.Abs(Transform(min + clusterScaleWidth) - Transform(min));
	}

	public virtual void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		double num = _rangeMin;
		double num2 = _rangeMax;
		if (double.IsInfinity(num) || double.IsNaN(num) || num == double.MaxValue)
		{
			num = 0.0;
		}
		if (double.IsInfinity(num2) || double.IsNaN(num2) || num2 == double.MaxValue)
		{
			num2 = 0.0;
		}
		double num3 = num2 - num;
		bool flag = !IsAnyOrdinal;
		if (_minAuto)
		{
			_min = num;
			if (flag && (_min < 0.0 || num - _minGrace * num3 >= 0.0))
			{
				_min = num - _minGrace * num3;
			}
		}
		if (_maxAuto)
		{
			_max = num2;
			if (flag && (_max > 0.0 || num2 + _maxGrace * num3 <= 0.0))
			{
				_max = num2 + _maxGrace * num3;
			}
		}
		if (_max == _min && _maxAuto && _minAuto)
		{
			if (Math.Abs(_max) > 1E-100)
			{
				_max *= ((_min < 0.0) ? 0.95 : 1.05);
				_min *= ((_min < 0.0) ? 1.05 : 0.95);
			}
			else
			{
				_max = 1.0;
				_min = -1.0;
			}
		}
		if (_max <= _min)
		{
			if (_maxAuto)
			{
				_max = _min + 1.0;
			}
			else if (_minAuto)
			{
				_min = _max - 1.0;
			}
		}
	}

	public int CalcMaxLabels(Graphics g, GraphPane pane, float scaleFactor)
	{
		SizeF scaleMaxSpace = GetScaleMaxSpace(g, pane, scaleFactor, applyAngle: false);
		float num = 1000f;
		float num2 = 1000f;
		float num3 = (float)Math.Abs(Math.Cos((double)_fontSpec.Angle * Math.PI / 180.0));
		float num4 = (float)Math.Abs(Math.Sin((double)_fontSpec.Angle * Math.PI / 180.0));
		if ((double)num3 > 0.001)
		{
			num = scaleMaxSpace.Width / num3;
		}
		if ((double)num4 > 0.001)
		{
			num2 = scaleMaxSpace.Height / num4;
		}
		if (num2 < num)
		{
			num = num2;
		}
		if (num <= 0f)
		{
			num = 1f;
		}
		RectangleF rect = pane.Chart._rect;
		double num5 = ((!(_ownerAxis is XAxis) && !(_ownerAxis is X2Axis)) ? ((rect.Height == 0f) ? ((double)pane.Rect.Height * 0.75) : ((double)rect.Height)) : ((rect.Width == 0f) ? ((double)pane.Rect.Width * 0.75) : ((double)rect.Width)));
		int num6 = (int)(num5 / (double)num);
		if (num6 <= 0)
		{
			num6 = 1;
		}
		return num6;
	}

	internal void SetScaleMag(double min, double max, double step)
	{
		if (_magAuto)
		{
			double val = -100.0;
			double val2 = -100.0;
			if (Math.Abs(_min) > 1E-30)
			{
				val = Math.Floor(Math.Log10(Math.Abs(_min)));
			}
			if (Math.Abs(_max) > 1E-30)
			{
				val2 = Math.Floor(Math.Log10(Math.Abs(_max)));
			}
			val = Math.Max(val2, val);
			if (val == -100.0 || Math.Abs(val) <= 3.0)
			{
				val = 0.0;
			}
			_mag = (int)(Math.Floor(val / 3.0) * 3.0);
		}
		if (_formatAuto)
		{
			int num = -(int)(Math.Floor(Math.Log10(_majorStep)) - (double)_mag);
			if (num < 0)
			{
				num = 0;
			}
			_format = "f" + num;
		}
	}

	protected static double CalcStepSize(double range, double targetSteps)
	{
		double num = range / targetSteps;
		double y = Math.Floor(Math.Log10(num));
		double num2 = Math.Pow(10.0, y);
		double num3 = (int)(num / num2 + 0.5);
		if (num3 > 5.0)
		{
			num3 = 10.0;
		}
		else if (num3 > 2.0)
		{
			num3 = 5.0;
		}
		else if (num3 > 1.0)
		{
			num3 = 2.0;
		}
		return num3 * num2;
	}

	protected double CalcBoundedStepSize(double range, double maxSteps)
	{
		double num = range / maxSteps;
		double y = Math.Floor(Math.Log10(num));
		double num2 = Math.Pow(10.0, y);
		double num3 = Math.Ceiling(num / num2);
		if (num3 > 5.0)
		{
			num3 = 10.0;
		}
		else if (num3 > 2.0)
		{
			num3 = 5.0;
		}
		else if (num3 > 1.0)
		{
			num3 = 2.0;
		}
		return num3 * num2;
	}

	internal virtual int CalcNumTics()
	{
		int num = 1;
		num = (int)((_max - _min) / _majorStep + 0.01) + 1;
		if (num < 1)
		{
			num = 1;
		}
		else if (num > 1000)
		{
			num = 1000;
		}
		return num;
	}

	protected double MyMod(double x, double y)
	{
		if (y == 0.0)
		{
			return 0.0;
		}
		double num = x / y;
		return y * (num - Math.Floor(num));
	}

	internal void SetRange(GraphPane pane, Axis axis)
	{
		if (_rangeMin >= double.MaxValue || _rangeMax <= double.MinValue)
		{
			if (axis != pane.XAxis && axis != pane.X2Axis && pane.YAxis.Scale._rangeMin < double.MaxValue && pane.YAxis.Scale._rangeMax > double.MinValue)
			{
				_rangeMin = pane.YAxis.Scale._rangeMin;
				_rangeMax = pane.YAxis.Scale._rangeMax;
			}
			else if (axis != pane.XAxis && axis != pane.X2Axis && pane.Y2Axis.Scale._rangeMin < double.MaxValue && pane.Y2Axis.Scale._rangeMax > double.MinValue)
			{
				_rangeMin = pane.Y2Axis.Scale._rangeMin;
				_rangeMax = pane.Y2Axis.Scale._rangeMax;
			}
			else
			{
				_rangeMin = 0.0;
				_rangeMax = 1.0;
			}
		}
	}

	public float Transform(double x)
	{
		double num = _maxLinTemp - _minLinTemp;
		double num2 = ((!(num > 1E-100)) ? 0.0 : ((Linearize(x) - _minLinTemp) / num));
		if (_isReverse == (_ownerAxis is XAxis || _ownerAxis is X2Axis))
		{
			return (float)((double)_maxPix - (double)(_maxPix - _minPix) * num2);
		}
		return (float)((double)_minPix + (double)(_maxPix - _minPix) * num2);
	}

	public float Transform(bool isOverrideOrdinal, int i, double x)
	{
		if (IsAnyOrdinal && i >= 0 && !isOverrideOrdinal)
		{
			x = (double)i + 1.0;
		}
		return Transform(x);
	}

	public double ReverseTransform(float pixVal)
	{
		double val = ((_isReverse != (_ownerAxis is XAxis || _ownerAxis is X2Axis)) ? ((double)(pixVal - _minPix) / (double)(_maxPix - _minPix) * (_maxLinTemp - _minLinTemp) + _minLinTemp) : ((double)(pixVal - _maxPix) / (double)(_minPix - _maxPix) * (_maxLinTemp - _minLinTemp) + _minLinTemp));
		return DeLinearize(val);
	}

	public float LocalTransform(double x)
	{
		double num = (x - _minLinTemp) / (_maxLinTemp - _minLinTemp);
		if (_isReverse == (_ownerAxis is YAxis || _ownerAxis is X2Axis))
		{
			return (float)((double)(_maxPix - _minPix) * num);
		}
		return (float)((double)(_maxPix - _minPix) * (1.0 - num));
	}

	public static double SafeLog(double x)
	{
		if (x > 1E-20)
		{
			return Math.Log10(x);
		}
		return 0.0;
	}

	public static double SafeExp(double x, double exponent)
	{
		if (x > 1E-20)
		{
			return Math.Pow(x, exponent);
		}
		return 0.0;
	}
}
