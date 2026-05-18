using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class GasGaugeNeedle : CurveItem, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float NeedleWidth = 10f;

		public static float BorderWidth = 1f;

		public static bool IsBorderVisible = true;

		public static Color BorderColor = Color.Gray;

		public static FillType FillType = FillType.Brush;

		public static Color FillColor = Color.Empty;

		public static Brush FillBrush = null;

		public static bool isVisible = true;

		public static float FontSize = 10f;
	}

	public const int schema2 = 10;

	private double _needleValue;

	private float _needleWidth;

	private Color _color;

	private float _sweepAngle;

	private Fill _fill;

	private TextObj _labelDetail;

	private Border _border;

	private RectangleF _boundingRectangle;

	private GraphicsPath _slicePath;

	public float NeedleWidth
	{
		get
		{
			return _needleWidth;
		}
		set
		{
			_needleWidth = value;
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

	public Color NeedleColor
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

	public double NeedleValue
	{
		get
		{
			return _needleValue;
		}
		set
		{
			_needleValue = ((value > 0.0) ? value : 0.0);
		}
	}

	public GasGaugeNeedle(string label, double val, Color color)
		: base(label)
	{
		NeedleValue = val;
		NeedleColor = color;
		NeedleWidth = Default.NeedleWidth;
		SweepAngle = 0f;
		_border = new Border(Default.BorderColor, Default.BorderWidth);
		_labelDetail = new TextObj();
		_labelDetail.FontSpec.Size = Default.FontSize;
		_slicePath = null;
	}

	public GasGaugeNeedle(GasGaugeNeedle ggn)
		: base(ggn)
	{
		NeedleValue = ggn.NeedleValue;
		NeedleColor = ggn.NeedleColor;
		NeedleWidth = ggn.NeedleWidth;
		SweepAngle = ggn.SweepAngle;
		_border = ggn.Border.Clone();
		_labelDetail = ggn.LabelDetail.Clone();
		_labelDetail.FontSpec.Size = ggn.LabelDetail.FontSpec.Size;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public GasGaugeNeedle Clone()
	{
		return new GasGaugeNeedle(this);
	}

	internal override bool IsZIncluded(GraphPane pane)
	{
		return false;
	}

	internal override bool IsXIndependent(GraphPane pane)
	{
		return true;
	}

	protected GasGaugeNeedle(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_labelDetail = (TextObj)info.GetValue("labelDetail", typeof(TextObj));
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_needleValue = info.GetDouble("needleValue");
		_boundingRectangle = (RectangleF)info.GetValue("boundingRectangle", typeof(RectangleF));
		_slicePath = (GraphicsPath)info.GetValue("slicePath", typeof(GraphicsPath));
		_sweepAngle = (float)info.GetDouble("sweepAngle");
		_color = (Color)info.GetValue("color", typeof(Color));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("labelDetail", _labelDetail);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("needleValue", _needleValue);
		info.AddValue("boundingRectangle", _boundingRectangle);
		info.AddValue("slicePath", _slicePath);
		info.AddValue("sweepAngle", _sweepAngle);
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
		if (_isVisible)
		{
			RectangleF boundingRectangle = _boundingRectangle;
			if (boundingRectangle.Width >= 1f && boundingRectangle.Height >= 1f)
			{
				SmoothingMode smoothingMode = g.SmoothingMode;
				g.SmoothingMode = SmoothingMode.AntiAlias;
				Matrix matrix = new Matrix();
				matrix.Translate(boundingRectangle.X + boundingRectangle.Width / 2f, boundingRectangle.Y + boundingRectangle.Height / 2f, MatrixOrder.Prepend);
				PointF[] array = new PointF[2]
				{
					new PointF(boundingRectangle.Height * 0.1f / 2f * (float)Math.Cos((double)(0f - SweepAngle) * Math.PI / 180.0), boundingRectangle.Height * 0.1f / 2f * (float)Math.Sin((double)(0f - SweepAngle) * Math.PI / 180.0)),
					new PointF(boundingRectangle.Width / 2f * (float)Math.Cos((double)(0f - SweepAngle) * Math.PI / 180.0), boundingRectangle.Width / 2f * (float)Math.Sin((double)(0f - SweepAngle) * Math.PI / 180.0))
				};
				matrix.TransformPoints(array);
				Pen pen = new Pen(NeedleColor, boundingRectangle.Height * 0.1f / 2f);
				pen.EndCap = LineCap.ArrowAnchor;
				g.DrawLine(pen, array[0].X, array[0].Y, array[1].X, array[1].Y);
				Fill fill = new Fill(Color.Black);
				RectangleF rect = new RectangleF(boundingRectangle.X + boundingRectangle.Width / 2f - 1f, boundingRectangle.Y + boundingRectangle.Height / 2f - 1f, 1f, 1f);
				rect.Inflate(boundingRectangle.Height * 0.1f, boundingRectangle.Height * 0.1f);
				Brush brush = fill.MakeBrush(rect);
				g.FillPie(brush, rect.X, rect.Y, rect.Width, rect.Height, 0f, -180f);
				Pen pen2 = new Pen(Color.White, 2f);
				g.DrawPie(pen2, rect.X, rect.Y, rect.Width, rect.Height, 0f, -180f);
				g.SmoothingMode = smoothingMode;
			}
		}
	}

	public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		if (_isVisible)
		{
			float num = rect.Top + rect.Height / 2f;
			Pen pen = new Pen(NeedleColor, pane.ScaledPenWidth(NeedleWidth / 2f, scaleFactor));
			pen.StartCap = LineCap.Round;
			pen.EndCap = LineCap.ArrowAnchor;
			pen.DashStyle = DashStyle.Solid;
			g.DrawLine(pen, rect.Left, num, rect.Right, num);
		}
	}

	public override bool GetCoords(GraphPane pane, int i, out string coords)
	{
		coords = string.Empty;
		return false;
	}

	public static void CalculateGasGaugeParameters(GraphPane pane)
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
			if (curve2 is GasGaugeNeedle)
			{
				GasGaugeNeedle gasGaugeNeedle = (GasGaugeNeedle)curve2;
				float sweepAngle = ((float)gasGaugeNeedle.NeedleValue - (float)num) / ((float)num2 - (float)num) * 180f;
				gasGaugeNeedle.SweepAngle = sweepAngle;
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
		CalculateGasGaugeParameters(pane);
		foreach (CurveItem curve in pane.CurveList)
		{
			if (curve is GasGaugeNeedle)
			{
				GasGaugeNeedle gasGaugeNeedle = (GasGaugeNeedle)curve;
				gasGaugeNeedle._boundingRectangle = rectangleF;
			}
		}
		return rectangleF;
	}
}
