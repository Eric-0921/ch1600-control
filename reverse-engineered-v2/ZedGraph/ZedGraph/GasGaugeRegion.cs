using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class GasGaugeRegion : CurveItem, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float BorderWidth = 1f;

		public static FillType FillType = FillType.Brush;

		public static bool IsBorderVisible = true;

		public static Color BorderColor = Color.Gray;

		public static Color FillColor = Color.Empty;

		public static Brush FillBrush = null;

		public static bool isVisible = true;

		public static float FontSize = 10f;
	}

	public const int schema2 = 10;

	private double _minValue;

	private double _maxValue;

	private Color _color;

	private float _startAngle;

	private float _sweepAngle;

	private Fill _fill;

	private TextObj _labelDetail;

	private Border _border;

	private RectangleF _boundingRectangle;

	private GraphicsPath _slicePath;

	public GraphicsPath SlicePath => _slicePath;

	public TextObj LabelDetail
	{
		get
		{
			return _labelDetail;
		}
		set
		{
			_labelDetail = value;
		}
	}

	public Border Border
	{
		get
		{
			return _border;
		}
		set
		{
			_border = value;
		}
	}

	public Color RegionColor
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			Fill = new Fill(_color);
		}
	}

	public Fill Fill
	{
		get
		{
			return _fill;
		}
		set
		{
			_fill = value;
		}
	}

	private float SweepAngle
	{
		get
		{
			return _sweepAngle;
		}
		set
		{
			_sweepAngle = value;
		}
	}

	private float StartAngle
	{
		get
		{
			return _startAngle;
		}
		set
		{
			_startAngle = value;
		}
	}

	public double MinValue
	{
		get
		{
			return _minValue;
		}
		set
		{
			_minValue = ((value > 0.0) ? value : 0.0);
		}
	}

	public double MaxValue
	{
		get
		{
			return _maxValue;
		}
		set
		{
			_maxValue = ((value > 0.0) ? value : 0.0);
		}
	}

	protected GasGaugeRegion(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_labelDetail = (TextObj)info.GetValue("labelDetail", typeof(TextObj));
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_color = (Color)info.GetValue("color", typeof(Color));
		_minValue = info.GetDouble("minValue");
		_maxValue = info.GetDouble("maxValue");
		_startAngle = (float)info.GetDouble("startAngle");
		_sweepAngle = (float)info.GetDouble("sweepAngle");
		_boundingRectangle = (RectangleF)info.GetValue("boundingRectangle", typeof(RectangleF));
		_slicePath = (GraphicsPath)info.GetValue("slicePath", typeof(GraphicsPath));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("labelDetail", _labelDetail);
		info.AddValue("fill", _fill);
		info.AddValue("color", _color);
		info.AddValue("border", _border);
		info.AddValue("minVal", _minValue);
		info.AddValue("maxVal", _maxValue);
		info.AddValue("startAngle", _startAngle);
		info.AddValue("sweepAngle", _sweepAngle);
		info.AddValue("boundingRectangle", _boundingRectangle);
		info.AddValue("slicePath", _slicePath);
	}

	public GasGaugeRegion(string label, double minVal, double maxVal, Color color)
		: base(label)
	{
		MinValue = minVal;
		MaxValue = maxVal;
		RegionColor = color;
		StartAngle = 0f;
		SweepAngle = 0f;
		_border = new Border(Default.BorderColor, Default.BorderWidth);
		_labelDetail = new TextObj();
		_labelDetail.FontSpec.Size = Default.FontSize;
		_slicePath = null;
	}

	public GasGaugeRegion(GasGaugeRegion ggr)
		: base(ggr)
	{
		_minValue = ggr._minValue;
		_maxValue = ggr._maxValue;
		_color = ggr._color;
		_startAngle = ggr._startAngle;
		_sweepAngle = ggr._sweepAngle;
		_border = ggr._border.Clone();
		_labelDetail = ggr._labelDetail.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public GasGaugeRegion Clone()
	{
		return new GasGaugeRegion(this);
	}

	internal override bool IsZIncluded(GraphPane pane)
	{
		return false;
	}

	internal override bool IsXIndependent(GraphPane pane)
	{
		return true;
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (pane.Chart._rect.Width <= 0f && pane.Chart._rect.Height <= 0f)
		{
			_slicePath = null;
			return;
		}
		CalcRectangle(g, pane, scaleFactor, pane.Chart._rect);
		_slicePath = new GraphicsPath();
		if (!_isVisible)
		{
			return;
		}
		RectangleF boundingRectangle = _boundingRectangle;
		if (boundingRectangle.Width >= 1f && boundingRectangle.Height >= 1f)
		{
			SmoothingMode smoothingMode = g.SmoothingMode;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			_slicePath.AddPie(boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, -0f, -180f);
			g.FillPie(Fill.MakeBrush(_boundingRectangle), boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, 0f - StartAngle, 0f - SweepAngle);
			if (Border.IsVisible)
			{
				Pen pen = _border.GetPen(pane, scaleFactor);
				g.DrawPie(pen, boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, -0f, -180f);
				pen.Dispose();
			}
			g.SmoothingMode = smoothingMode;
		}
	}

	public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		if (!_isVisible)
		{
			return;
		}
		if (_fill.IsVisible)
		{
			using Brush brush = _fill.MakeBrush(rect);
			g.FillRectangle(brush, rect);
		}
		if (!_border.Color.IsEmpty)
		{
			_border.Draw(g, pane, scaleFactor, rect);
		}
	}

	public override bool GetCoords(GraphPane pane, int i, out string coords)
	{
		coords = string.Empty;
		return false;
	}

	public static void CalculateGasGuageParameters(GraphPane pane)
	{
		double num = double.MaxValue;
		double num2 = double.MinValue;
		foreach (CurveItem curve in pane.CurveList)
		{
			if (curve is GasGaugeRegion)
			{
				GasGaugeRegion gasGaugeRegion = (GasGaugeRegion)curve;
				if (num2 < gasGaugeRegion.MaxValue)
				{
					num2 = gasGaugeRegion.MaxValue;
				}
				if (num > gasGaugeRegion.MinValue)
				{
					num = gasGaugeRegion.MinValue;
				}
			}
		}
		foreach (CurveItem curve2 in pane.CurveList)
		{
			if (curve2 is GasGaugeRegion)
			{
				GasGaugeRegion gasGaugeRegion2 = (GasGaugeRegion)curve2;
				float num3 = ((float)gasGaugeRegion2.MinValue - (float)num) / ((float)num2 - (float)num) * 180f;
				float num4 = ((float)gasGaugeRegion2.MaxValue - (float)num) / ((float)num2 - (float)num) * 180f;
				num4 -= num3;
				Fill fill = new Fill(Color.White, gasGaugeRegion2.RegionColor, 0f - num4 / 2f);
				gasGaugeRegion2.Fill = fill;
				gasGaugeRegion2.StartAngle = num3;
				gasGaugeRegion2.SweepAngle = num4;
			}
		}
	}

	public static RectangleF CalcRectangle(Graphics g, GraphPane pane, float scaleFactor, RectangleF chartRect)
	{
		RectangleF rectangleF = chartRect;
		if (2f * rectangleF.Height > rectangleF.Width)
		{
			float num = (rectangleF.Height * 2f - rectangleF.Width) / (rectangleF.Height * 2f);
			rectangleF.Height = rectangleF.Height * 2f - rectangleF.Height * 2f * num;
		}
		else
		{
			rectangleF.Height *= 2f;
		}
		rectangleF.Width = rectangleF.Height;
		float num2 = chartRect.Width / 2f - rectangleF.Width / 2f;
		rectangleF.X += num2;
		rectangleF.Inflate(-0.05f * rectangleF.Height, -0.05f * rectangleF.Width);
		CalculateGasGuageParameters(pane);
		foreach (CurveItem curve in pane.CurveList)
		{
			if (curve is GasGaugeRegion)
			{
				GasGaugeRegion gasGaugeRegion = (GasGaugeRegion)curve;
				gasGaugeRegion._boundingRectangle = rectangleF;
			}
		}
		return rectangleF;
	}
}
