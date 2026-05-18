using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public abstract class Axis : ISerializable, ICloneable
{
	public delegate string ScaleFormatHandler(GraphPane pane, Axis axis, double val, int index);

	public delegate string ScaleTitleEventHandler(Axis axis);

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float AxisGap = 5f;

		public static float TitleGap = 0f;

		public static string TitleFontFamily = "Arial";

		public static float TitleFontSize = 14f;

		public static Color TitleFontColor = Color.Black;

		public static bool TitleFontBold = true;

		public static bool TitleFontItalic = false;

		public static bool TitleFontUnderline = false;

		public static Color TitleFillColor = Color.White;

		public static Brush TitleFillBrush = null;

		public static FillType TitleFillType = FillType.None;

		public static Color BorderColor = Color.Black;

		public static bool IsAxisSegmentVisible = true;

		public static AxisType Type = AxisType.Linear;

		public static Color Color = Color.Black;

		public static float MinSpace = 0f;
	}

	public const int schema = 10;

	internal Scale _scale;

	internal MinorTic _minorTic;

	internal MajorTic _majorTic;

	internal MajorGrid _majorGrid;

	internal MinorGrid _minorGrid;

	internal double _cross;

	internal bool _crossAuto;

	protected bool _isVisible;

	protected bool _isAxisSegmentVisible;

	protected AxisLabel _title;

	public object Tag;

	private float _axisGap;

	private float _minSpace;

	private Color _color;

	internal float _tmpSpace;

	public Scale Scale => _scale;

	public double Cross
	{
		get
		{
			return _cross;
		}
		set
		{
			_cross = value;
			_crossAuto = false;
		}
	}

	public bool CrossAuto
	{
		get
		{
			return _crossAuto;
		}
		set
		{
			_crossAuto = value;
		}
	}

	public float MinSpace
	{
		get
		{
			return _minSpace;
		}
		set
		{
			_minSpace = value;
		}
	}

	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
		}
	}

	public MajorTic MajorTic => _majorTic;

	public MinorTic MinorTic => _minorTic;

	public MajorGrid MajorGrid => _majorGrid;

	public MinorGrid MinorGrid => _minorGrid;

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

	public bool IsAxisSegmentVisible
	{
		get
		{
			return _isAxisSegmentVisible;
		}
		set
		{
			_isAxisSegmentVisible = value;
		}
	}

	public AxisType Type
	{
		get
		{
			return _scale.Type;
		}
		set
		{
			_scale = Scale.MakeNewScale(_scale, value);
		}
	}

	public AxisLabel Title
	{
		get
		{
			return _title;
		}
		set
		{
			_title = value;
		}
	}

	public float AxisGap
	{
		get
		{
			return _axisGap;
		}
		set
		{
			_axisGap = value;
		}
	}

	public event ScaleFormatHandler ScaleFormatEvent;

	public event ScaleTitleEventHandler ScaleTitleEvent;

	public Axis()
	{
		_scale = new LinearScale(this);
		_cross = 0.0;
		_crossAuto = true;
		_majorTic = new MajorTic();
		_minorTic = new MinorTic();
		_majorGrid = new MajorGrid();
		_minorGrid = new MinorGrid();
		_axisGap = Default.AxisGap;
		_minSpace = Default.MinSpace;
		_isVisible = true;
		_isAxisSegmentVisible = Default.IsAxisSegmentVisible;
		_title = new AxisLabel("", Default.TitleFontFamily, Default.TitleFontSize, Default.TitleFontColor, Default.TitleFontBold, Default.TitleFontUnderline, Default.TitleFontItalic);
		_title.FontSpec.Fill = new Fill(Default.TitleFillColor, Default.TitleFillBrush, Default.TitleFillType);
		_title.FontSpec.Border.IsVisible = false;
		_color = Default.Color;
	}

	public Axis(string title)
		: this()
	{
		_title._text = title;
	}

	public Axis(Axis rhs)
	{
		_scale = rhs._scale.Clone(this);
		_cross = rhs._cross;
		_crossAuto = rhs._crossAuto;
		_majorTic = rhs.MajorTic.Clone();
		_minorTic = rhs.MinorTic.Clone();
		_majorGrid = rhs._majorGrid.Clone();
		_minorGrid = rhs._minorGrid.Clone();
		_isVisible = rhs.IsVisible;
		_isAxisSegmentVisible = rhs._isAxisSegmentVisible;
		_title = rhs.Title.Clone();
		_axisGap = rhs._axisGap;
		_minSpace = rhs.MinSpace;
		_color = rhs.Color;
	}

	object ICloneable.Clone()
	{
		throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
	}

	protected Axis(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_cross = info.GetDouble("cross");
		_crossAuto = info.GetBoolean("crossAuto");
		_majorTic = (MajorTic)info.GetValue("MajorTic", typeof(MajorTic));
		_minorTic = (MinorTic)info.GetValue("MinorTic", typeof(MinorTic));
		_majorGrid = (MajorGrid)info.GetValue("majorGrid", typeof(MajorGrid));
		_minorGrid = (MinorGrid)info.GetValue("minorGrid", typeof(MinorGrid));
		_isVisible = info.GetBoolean("isVisible");
		_title = (AxisLabel)info.GetValue("title", typeof(AxisLabel));
		_minSpace = info.GetSingle("minSpace");
		_color = (Color)info.GetValue("color", typeof(Color));
		_isAxisSegmentVisible = info.GetBoolean("isAxisSegmentVisible");
		_axisGap = info.GetSingle("axisGap");
		_scale = (Scale)info.GetValue("scale", typeof(Scale));
		_scale._ownerAxis = this;
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("cross", _cross);
		info.AddValue("crossAuto", _crossAuto);
		info.AddValue("MajorTic", MajorTic);
		info.AddValue("MinorTic", MinorTic);
		info.AddValue("majorGrid", _majorGrid);
		info.AddValue("minorGrid", _minorGrid);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("title", _title);
		info.AddValue("minSpace", _minSpace);
		info.AddValue("color", _color);
		info.AddValue("isAxisSegmentVisible", _isAxisSegmentVisible);
		info.AddValue("axisGap", _axisGap);
		info.AddValue("scale", _scale);
	}

	public void ResetAutoScale(GraphPane pane, Graphics g)
	{
		_scale._minAuto = true;
		_scale._maxAuto = true;
		_scale._majorStepAuto = true;
		_scale._minorStepAuto = true;
		_crossAuto = true;
		_scale._magAuto = true;
		_scale._formatAuto = true;
		pane.AxisChange(g);
	}

	public void Draw(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
	{
		Matrix transform = g.Transform;
		_scale.SetupScaleData(pane, this);
		if (_isVisible)
		{
			SetTransformMatrix(g, pane, scaleFactor);
			shiftPos = CalcTotalShift(pane, scaleFactor, shiftPos);
			_scale.Draw(g, pane, scaleFactor, shiftPos);
			g.Transform = transform;
		}
	}

	internal void DrawGrid(Graphics g, GraphPane pane, float scaleFactor, float shiftPos)
	{
		if (_isVisible)
		{
			Matrix transform = g.Transform;
			SetTransformMatrix(g, pane, scaleFactor);
			double baseVal = _scale.CalcBaseTic();
			_scale.GetTopRightPix(pane, out var topPix, out var _);
			shiftPos = CalcTotalShift(pane, scaleFactor, shiftPos);
			_scale.DrawGrid(g, pane, baseVal, topPix, scaleFactor);
			DrawMinorTics(g, pane, baseVal, shiftPos, scaleFactor, topPix);
			g.Transform = transform;
		}
	}

	public void SetMinSpaceBuffer(Graphics g, GraphPane pane, float bufferFraction, bool isGrowOnly)
	{
		float minSpace = MinSpace;
		MinSpace = 0f;
		float fixedSpace;
		float num = CalcSpace(g, pane, 1f, out fixedSpace) * bufferFraction;
		if (isGrowOnly)
		{
			num = Math.Max(minSpace, num);
		}
		MinSpace = num;
	}

	public abstract void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor);

	internal abstract float CalcCrossShift(GraphPane pane);

	public abstract Axis GetCrossAxis(GraphPane pane);

	internal double EffectiveCrossValue(GraphPane pane)
	{
		Axis crossAxis = GetCrossAxis(pane);
		double num = crossAxis._scale.Linearize(_scale._min);
		double num2 = crossAxis._scale.Linearize(_scale._max);
		if (_crossAuto)
		{
			if (crossAxis._scale.IsReverse == (this is Y2Axis || this is X2Axis))
			{
				return num2;
			}
			return num;
		}
		if (_cross < num)
		{
			return num;
		}
		if (_cross > num2)
		{
			return num2;
		}
		return _scale.Linearize(_cross);
	}

	internal bool IsCrossShifted(GraphPane pane)
	{
		if (_crossAuto)
		{
			return false;
		}
		Axis crossAxis = GetCrossAxis(pane);
		if (((this is XAxis || this is YAxis) && !crossAxis._scale.IsReverse) || ((this is X2Axis || this is Y2Axis) && crossAxis._scale.IsReverse))
		{
			if (_cross <= crossAxis._scale._min)
			{
				return false;
			}
		}
		else if (_cross >= crossAxis._scale._max)
		{
			return false;
		}
		return true;
	}

	internal float CalcCrossFraction(GraphPane pane)
	{
		if (!IsCrossShifted(pane))
		{
			if (IsPrimary(pane) && _scale._isLabelsInside)
			{
				return 1f;
			}
			return 0f;
		}
		double num = EffectiveCrossValue(pane);
		Axis crossAxis = GetCrossAxis(pane);
		double num2 = crossAxis._scale.Linearize(_scale._min);
		double num3 = crossAxis._scale.Linearize(_scale._max);
		float num4 = ((((!(this is XAxis) && !(this is YAxis)) || _scale._isLabelsInside != crossAxis._scale.IsReverse) && ((!(this is X2Axis) && !(this is Y2Axis)) || _scale._isLabelsInside == crossAxis._scale.IsReverse)) ? ((float)((num2 - num) / (num2 - num3))) : ((float)((num - num3) / (num2 - num3))));
		if (num4 < 0f)
		{
			num4 = 0f;
		}
		if (num4 > 1f)
		{
			num4 = 1f;
		}
		return num4;
	}

	private float CalcTotalShift(GraphPane pane, float scaleFactor, float shiftPos)
	{
		if (!IsPrimary(pane))
		{
			if (IsCrossShifted(pane))
			{
				shiftPos = 0f;
			}
			else
			{
				float num = _majorTic.ScaledTic(scaleFactor);
				if (_scale._isLabelsInside)
				{
					shiftPos += _tmpSpace;
					if (_majorTic.IsOutside || _majorTic._isCrossOutside || _minorTic.IsOutside || _minorTic._isCrossOutside)
					{
						shiftPos -= num;
					}
				}
				else
				{
					shiftPos += _axisGap * scaleFactor;
					if (_majorTic.IsInside || _majorTic._isCrossInside || _minorTic.IsInside || _minorTic._isCrossInside)
					{
						shiftPos += num;
					}
				}
			}
		}
		float num2 = CalcCrossShift(pane);
		shiftPos += num2;
		return shiftPos;
	}

	public float CalcSpace(Graphics g, GraphPane pane, float scaleFactor, out float fixedSpace)
	{
		float height = _scale._fontSpec.GetHeight(scaleFactor);
		float num = _majorTic.ScaledTic(scaleFactor);
		float num2 = _axisGap * scaleFactor;
		float num3 = _scale._labelGap * height;
		float scaledGap = _title.GetScaledGap(scaleFactor);
		fixedSpace = 0f;
		_tmpSpace = 0f;
		if (_isVisible)
		{
			bool flag = MajorTic.IsOutside || MajorTic._isCrossOutside || MinorTic.IsOutside || MinorTic._isCrossOutside;
			if (flag)
			{
				_tmpSpace += num;
			}
			if (!IsPrimary(pane))
			{
				_tmpSpace += num2;
				if (MajorTic._isInside || MajorTic._isCrossInside || MinorTic._isInside || MinorTic._isCrossInside)
				{
					_tmpSpace += num;
				}
			}
			_tmpSpace += _scale.GetScaleMaxSpace(g, pane, scaleFactor, applyAngle: true).Height + num3;
			string text = MakeTitle();
			if (text.Length > 0 && _title._isVisible)
			{
				fixedSpace = Title.FontSpec.BoundingBox(g, text, scaleFactor).Height + scaledGap;
				_tmpSpace += fixedSpace;
				fixedSpace += scaledGap;
			}
			if (flag)
			{
				fixedSpace += num;
			}
		}
		if (IsPrimary(pane) && ((this is YAxis && ((!pane.XAxis._scale._isSkipFirstLabel && !pane.XAxis._scale._isReverse) || (!pane.XAxis._scale._isSkipLastLabel && pane.XAxis._scale._isReverse))) || (this is Y2Axis && ((!pane.XAxis._scale._isSkipFirstLabel && pane.XAxis._scale._isReverse) || (!pane.XAxis._scale._isSkipLastLabel && !pane.XAxis._scale._isReverse)))) && pane.XAxis.IsVisible && pane.XAxis._scale._isVisible)
		{
			float val = pane.XAxis._scale.GetScaleMaxSpace(g, pane, scaleFactor, applyAngle: true).Width / 2f;
			fixedSpace = Math.Max(val, fixedSpace);
		}
		_tmpSpace = Math.Max(_tmpSpace, _minSpace * scaleFactor);
		fixedSpace = Math.Max(fixedSpace, _minSpace * scaleFactor);
		return _tmpSpace;
	}

	internal abstract bool IsPrimary(GraphPane pane);

	internal void FixZeroLine(Graphics g, GraphPane pane, float scaleFactor, float left, float right)
	{
		if (_isVisible && _majorGrid._isZeroLine && _scale._min < 0.0 && _scale._max > 0.0)
		{
			float num = _scale.Transform(0.0);
			using Pen pen = new Pen(_color, pane.ScaledPenWidth(_majorGrid._penWidth, scaleFactor));
			g.DrawLine(pen, left, num, right, num);
		}
	}

	public void DrawMinorTics(Graphics g, GraphPane pane, double baseVal, float shift, float scaleFactor, float topPix)
	{
		if ((!MinorTic.IsOutside && !MinorTic.IsOpposite && !MinorTic.IsInside && !MinorTic._isCrossOutside && !MinorTic._isCrossInside && !_minorGrid._isVisible) || !_isVisible)
		{
			return;
		}
		double num = _scale._majorStep * _scale.MajorUnitMultiplier;
		double num2 = _scale._minorStep * _scale.MinorUnitMultiplier;
		if (!_scale.IsLog && !(num2 < num))
		{
			return;
		}
		float scaledTic = MinorTic.ScaledTic(scaleFactor);
		double minLinTemp = _scale._minLinTemp;
		double maxLinTemp = _scale._maxLinTemp;
		double num3 = minLinTemp;
		int num4 = _scale.CalcMinorStart(baseVal);
		int num5 = 0;
		double num6 = _scale.CalcMajorTicValue(baseVal, num5);
		using Pen pen = new Pen(_minorTic._color, pane.ScaledPenWidth(MinorTic._penWidth, scaleFactor));
		using Pen pen2 = _minorGrid.GetPen(pane, scaleFactor);
		while (num3 < maxLinTemp && num4 < 5000)
		{
			num3 = _scale.CalcMinorTicValue(baseVal, num4);
			if (num3 > num6)
			{
				num6 = _scale.CalcMajorTicValue(baseVal, ++num5);
			}
			if (((Math.Abs(num3) < 1E-20 && Math.Abs(num3 - num6) > 1E-20) || (Math.Abs(num3) > 1E-20 && Math.Abs((num3 - num6) / num3) > 1E-10)) && num3 >= minLinTemp && num3 <= maxLinTemp)
			{
				float pixVal = _scale.LocalTransform(num3);
				_minorGrid.Draw(g, pen2, pixVal, topPix);
				_minorTic.Draw(g, pane, pen, pixVal, topPix, shift, scaledTic);
			}
			num4++;
		}
	}

	public void DrawTitle(Graphics g, GraphPane pane, float shiftPos, float scaleFactor)
	{
		string text = MakeTitle();
		if (_isVisible && _title._isVisible && text.Length > 0)
		{
			bool flag = ((!_scale._isLabelsInside) ? (MajorTic.IsOutside || MajorTic._isCrossOutside || MinorTic.IsOutside || MinorTic._isCrossOutside) : (MajorTic.IsInside || MajorTic._isCrossInside || MinorTic.IsInside || MinorTic._isCrossInside));
			float x = (_scale._maxPix - _scale._minPix) / 2f;
			float num = MajorTic.ScaledTic(scaleFactor);
			float num2 = _scale._fontSpec.GetHeight(scaleFactor) * _scale._labelGap;
			float scaledGap = _title.GetScaledGap(scaleFactor);
			float num3 = num * (flag ? 1f : 0f) + Title.FontSpec.BoundingBox(g, text, scaleFactor).Height / 2f;
			float num4 = (_scale._isVisible ? (_scale.GetScaleMaxSpace(g, pane, scaleFactor, applyAngle: true).Height + num2) : 0f);
			num4 = ((!_scale._isLabelsInside) ? (shiftPos + num4 + num3) : (shiftPos - num4 - num3));
			if (!_crossAuto && !_title._isTitleAtCross)
			{
				num4 = Math.Max(num4, num3);
			}
			AlignV alignV = AlignV.Center;
			num4 += scaledGap;
			Title.FontSpec.Draw(g, pane, text, x, num4, AlignH.Center, alignV, scaleFactor);
		}
	}

	private string MakeTitle()
	{
		if (this.ScaleTitleEvent != null)
		{
			string text = this.ScaleTitleEvent(this);
			if (text != null)
			{
				return text;
			}
		}
		if (_scale._mag != 0 && !_title._isOmitMag && !_scale.IsLog)
		{
			return _title._text + $" (10^{_scale._mag})";
		}
		return _title._text;
	}

	internal string MakeLabelEventWorks(GraphPane pane, int index, double dVal)
	{
		if (this.ScaleFormatEvent != null)
		{
			string text = this.ScaleFormatEvent(pane, this, dVal, index);
			if (text != null)
			{
				return text;
			}
		}
		if (Scale != null)
		{
			return _scale.MakeLabel(pane, index, dVal);
		}
		return "?";
	}
}
