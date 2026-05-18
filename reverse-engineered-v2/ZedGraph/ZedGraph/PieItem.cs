using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class PieItem : CurveItem, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static double Displacement = 0.0;

		public static float BorderWidth = 1f;

		public static FillType FillType = FillType.Brush;

		public static bool IsBorderVisible = true;

		public static Color BorderColor = Color.Black;

		public static Color FillColor = Color.Red;

		public static Brush FillBrush = null;

		public static bool isVisible = true;

		public static PieLabelType LabelType = PieLabelType.Name;

		public static float FontSize = 10f;

		public static int ValueDecimalDigits = 0;

		public static int PercentDecimalDigits = 2;
	}

	public const int schema2 = 10;

	private double _displacement;

	private TextObj _labelDetail;

	private Fill _fill;

	private Border _border;

	private double _pieValue;

	private PieLabelType _labelType;

	private PointF _intersectionPoint;

	private RectangleF _boundingRectangle;

	private string _labelStr;

	private PointF _pivotPoint;

	private PointF _endPoint;

	private GraphicsPath _slicePath;

	private float _startAngle;

	private float _sweepAngle;

	private float _midAngle;

	private int _valueDecimalDigits;

	private int _percentDecimalDigits;

	private static ColorSymbolRotator _rotator = new ColorSymbolRotator();

	public double Displacement
	{
		get
		{
			return _displacement;
		}
		set
		{
			_displacement = ((value > 0.5) ? 0.5 : value);
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

	private float MidAngle
	{
		get
		{
			return _midAngle;
		}
		set
		{
			_midAngle = value;
		}
	}

	public double Value
	{
		get
		{
			return _pieValue;
		}
		set
		{
			_pieValue = ((value > 0.0) ? value : 0.0);
		}
	}

	public PieLabelType LabelType
	{
		get
		{
			return _labelType;
		}
		set
		{
			_labelType = value;
			if (value == PieLabelType.None)
			{
				LabelDetail.IsVisible = false;
			}
			else
			{
				LabelDetail.IsVisible = true;
			}
		}
	}

	public int ValueDecimalDigits
	{
		get
		{
			return _valueDecimalDigits;
		}
		set
		{
			_valueDecimalDigits = value;
		}
	}

	public int PercentDecimalDigits
	{
		get
		{
			return _percentDecimalDigits;
		}
		set
		{
			_percentDecimalDigits = value;
		}
	}

	internal override bool IsZIncluded(GraphPane pane)
	{
		return false;
	}

	internal override bool IsXIndependent(GraphPane pane)
	{
		return true;
	}

	public PieItem(double pieValue, Color color1, Color color2, float fillAngle, double displacement, string label)
		: this(pieValue, color1, displacement, label)
	{
		if (!color1.IsEmpty && !color2.IsEmpty)
		{
			_fill = new Fill(color1, color2, fillAngle);
		}
	}

	public PieItem(double pieValue, Color color, double displacement, string label)
		: base(label)
	{
		_pieValue = pieValue;
		_fill = new Fill(color.IsEmpty ? _rotator.NextColor : color);
		_displacement = displacement;
		_border = new Border(Default.BorderColor, Default.BorderWidth);
		_labelDetail = new TextObj();
		_labelDetail.FontSpec.Size = Default.FontSize;
		_labelType = Default.LabelType;
		_valueDecimalDigits = Default.ValueDecimalDigits;
		_percentDecimalDigits = Default.PercentDecimalDigits;
		_slicePath = null;
	}

	public PieItem(double pieValue, string label)
		: this(pieValue, _rotator.NextColor, Default.Displacement, label)
	{
	}

	public PieItem(PieItem rhs)
		: base(rhs)
	{
		_pieValue = rhs._pieValue;
		_fill = rhs._fill.Clone();
		Border = rhs._border.Clone();
		_displacement = rhs._displacement;
		_labelDetail = rhs._labelDetail.Clone();
		_labelType = rhs._labelType;
		_valueDecimalDigits = rhs._valueDecimalDigits;
		_percentDecimalDigits = rhs._percentDecimalDigits;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public PieItem Clone()
	{
		return new PieItem(this);
	}

	protected PieItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_displacement = info.GetDouble("displacement");
		_labelDetail = (TextObj)info.GetValue("labelDetail", typeof(TextObj));
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_pieValue = info.GetDouble("pieValue");
		_labelType = (PieLabelType)info.GetValue("labelType", typeof(PieLabelType));
		_intersectionPoint = (PointF)info.GetValue("intersectionPoint", typeof(PointF));
		_boundingRectangle = (RectangleF)info.GetValue("boundingRectangle", typeof(RectangleF));
		_pivotPoint = (PointF)info.GetValue("pivotPoint", typeof(PointF));
		_endPoint = (PointF)info.GetValue("endPoint", typeof(PointF));
		_startAngle = (float)info.GetDouble("startAngle");
		_sweepAngle = (float)info.GetDouble("sweepAngle");
		_midAngle = (float)info.GetDouble("midAngle");
		_labelStr = info.GetString("labelStr");
		_valueDecimalDigits = info.GetInt32("valueDecimalDigits");
		_percentDecimalDigits = info.GetInt32("percentDecimalDigits");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("displacement", _displacement);
		info.AddValue("labelDetail", _labelDetail);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("pieValue", _pieValue);
		info.AddValue("labelType", _labelType);
		info.AddValue("intersectionPoint", _intersectionPoint);
		info.AddValue("boundingRectangle", _boundingRectangle);
		info.AddValue("pivotPoint", _pivotPoint);
		info.AddValue("endPoint", _endPoint);
		info.AddValue("startAngle", _startAngle);
		info.AddValue("sweepAngle", _sweepAngle);
		info.AddValue("midAngle", _midAngle);
		info.AddValue("labelStr", _labelStr);
		info.AddValue("valueDecimalDigits", _valueDecimalDigits);
		info.AddValue("percentDecimalDigits", _percentDecimalDigits);
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (pane.Chart._rect.Width <= 0f && pane.Chart._rect.Height <= 0f)
		{
			_slicePath = null;
			return;
		}
		CalcPieRect(g, pane, scaleFactor, pane.Chart._rect);
		_slicePath = new GraphicsPath();
		if (!_isVisible)
		{
			return;
		}
		RectangleF boundingRectangle = _boundingRectangle;
		if (!(boundingRectangle.Width >= 1f) || !(boundingRectangle.Height >= 1f))
		{
			return;
		}
		SmoothingMode smoothingMode = g.SmoothingMode;
		g.SmoothingMode = SmoothingMode.AntiAlias;
		Fill fill = _fill;
		Border border = _border;
		if (base.IsSelected)
		{
			fill = Selection.Fill;
			border = Selection.Border;
		}
		using (Brush brush = fill.MakeBrush(_boundingRectangle))
		{
			g.FillPie(brush, boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, StartAngle, SweepAngle);
			_slicePath.AddPie(boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, StartAngle, SweepAngle);
			if (Border.IsVisible)
			{
				using Pen pen = border.GetPen(pane, scaleFactor);
				g.DrawPie(pen, boundingRectangle.X, boundingRectangle.Y, boundingRectangle.Width, boundingRectangle.Height, StartAngle, SweepAngle);
			}
			if (_labelType != PieLabelType.None)
			{
				DrawLabel(g, pane, boundingRectangle, scaleFactor);
			}
		}
		g.SmoothingMode = smoothingMode;
	}

	public static RectangleF CalcPieRect(Graphics g, GraphPane pane, float scaleFactor, RectangleF chartRect)
	{
		double maxDisplacement = 0.0;
		RectangleF baseRect = chartRect;
		if (pane.CurveList.IsPieOnly)
		{
			if (baseRect.Width < baseRect.Height)
			{
				baseRect.Inflate(-0.05f * baseRect.Height, -0.05f * baseRect.Width);
				float num = (baseRect.Height - baseRect.Width) / 2f;
				baseRect.Height = baseRect.Width;
				baseRect.Y += num;
			}
			else
			{
				baseRect.Inflate(-0.05f * baseRect.Height, -0.05f * baseRect.Width);
				float num2 = (baseRect.Width - baseRect.Height) / 2f;
				baseRect.Width = baseRect.Height;
				baseRect.X += num2;
			}
			double num3 = chartRect.Width / chartRect.Height;
			if (num3 < 1.5)
			{
				baseRect.Inflate(0f - (float)(0.1 * (1.5 / num3) * (double)baseRect.Width), 0f - (float)(0.1 * (1.5 / num3) * (double)baseRect.Width));
			}
			CalculatePieChartParams(pane, ref maxDisplacement);
			if (maxDisplacement != 0.0)
			{
				CalcNewBaseRect(maxDisplacement, ref baseRect);
			}
			foreach (PieItem curve in pane.CurveList)
			{
				curve._boundingRectangle = baseRect;
				if (curve.Displacement != 0.0)
				{
					RectangleF explRect = baseRect;
					curve.CalcExplodedRect(ref explRect);
					curve._boundingRectangle = explRect;
				}
				curve.DesignLabel(g, pane, curve._boundingRectangle, scaleFactor);
			}
		}
		return baseRect;
	}

	private void CalcExplodedRect(ref RectangleF explRect)
	{
		explRect.X += (float)(Displacement * (double)explRect.Width / 2.0 * Math.Cos((double)_midAngle * Math.PI / 180.0));
		explRect.Y += (float)(Displacement * (double)explRect.Height / 2.0 * Math.Sin((double)_midAngle * Math.PI / 180.0));
	}

	private static void CalculatePieChartParams(GraphPane pane, ref double maxDisplacement)
	{
		double num = 0.0;
		foreach (PieItem curve in pane.CurveList)
		{
			if (curve.IsPie)
			{
				num += curve._pieValue;
				if (curve.Displacement > maxDisplacement)
				{
					maxDisplacement = curve.Displacement;
				}
			}
		}
		double num2 = 0.0;
		foreach (PieItem curve2 in pane.CurveList)
		{
			_ = curve2._labelStr;
			curve2.StartAngle = (float)num2;
			curve2.SweepAngle = (float)(360.0 * curve2.Value / num);
			curve2.MidAngle = curve2.StartAngle + curve2.SweepAngle / 2f;
			num2 = curve2._startAngle + curve2._sweepAngle;
			BuildLabelString(curve2);
		}
	}

	public void DrawLabel(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		if (_labelDetail.IsVisible)
		{
			using (Pen pen = Border.GetPen(pane, scaleFactor))
			{
				g.DrawLine(pen, _intersectionPoint, _pivotPoint);
				g.DrawLine(pen, _pivotPoint, _endPoint);
			}
			_labelDetail.Draw(g, pane, scaleFactor);
		}
	}

	public void DesignLabel(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		if (!_labelDetail.IsVisible)
		{
			return;
		}
		_labelDetail.LayoutArea = default(SizeF);
		CalculateLinePoints(rect, _midAngle);
		SizeF sizeF = _labelDetail.FontSpec.BoundingBox(g, _labelStr, scaleFactor);
		RectangleF rect2 = pane.Chart._rect;
		float num = 0f;
		if (_midAngle > 315f || _midAngle <= 45f)
		{
			num = rect2.X + rect2.Width - _endPoint.X - 5f;
			if (sizeF.Width > num)
			{
				_labelDetail.LayoutArea = new SizeF(num, sizeF.Height * 3f);
			}
		}
		if (_midAngle > 45f && _midAngle <= 135f)
		{
			num = rect2.Y + rect2.Height - _endPoint.Y - 5f;
			if (sizeF.Height / 2f > num)
			{
				if (_midAngle > 90f)
				{
					CalculateLinePoints(rect, _midAngle + (_sweepAngle + _startAngle - _midAngle) / 3f);
				}
				else
				{
					CalculateLinePoints(rect, _midAngle - (_midAngle - (_midAngle - _startAngle) / 3f));
				}
			}
		}
		if (_midAngle > 135f && _midAngle <= 225f)
		{
			num = _endPoint.X - rect2.X - 5f;
			if (sizeF.Width > num)
			{
				_labelDetail.LayoutArea = new SizeF(num, sizeF.Height * 3f);
			}
		}
		if (_midAngle > 225f && _midAngle <= 315f)
		{
			num = _endPoint.Y - 5f - rect2.Y;
			if (sizeF.Height / 2f > num)
			{
				if (_midAngle < 270f)
				{
					CalculateLinePoints(rect, _midAngle - (_sweepAngle + _startAngle - _midAngle) / 3f);
				}
				else
				{
					CalculateLinePoints(rect, _midAngle + (_midAngle - _startAngle) / 3f);
				}
			}
		}
		_labelDetail.Location.AlignV = AlignV.Center;
		_labelDetail.Location.CoordinateFrame = CoordType.PaneFraction;
		_labelDetail.Location.X = (_endPoint.X - pane.Rect.X) / pane.Rect.Width;
		_labelDetail.Location.Y = (_endPoint.Y - pane.Rect.Y) / pane.Rect.Height;
		_labelDetail.Text = _labelStr;
	}

	private void CalculateLinePoints(RectangleF rect, double midAngle)
	{
		PointF pointF = new PointF(rect.X + rect.Width / 2f, rect.Y + rect.Height / 2f);
		_intersectionPoint = new PointF((float)((double)pointF.X + (double)(rect.Width / 2f) * Math.Cos(midAngle * Math.PI / 180.0)), (float)((double)pointF.Y + (double)(rect.Height / 2f) * Math.Sin(midAngle * Math.PI / 180.0)));
		_pivotPoint = new PointF((float)((double)_intersectionPoint.X + 0.05 * (double)rect.Width * Math.Cos(midAngle * Math.PI / 180.0)), (float)((double)_intersectionPoint.Y + 0.05 * (double)rect.Width * Math.Sin(midAngle * Math.PI / 180.0)));
		if (_pivotPoint.X >= pointF.X)
		{
			_endPoint = new PointF((float)((double)_pivotPoint.X + 0.05 * (double)rect.Width), _pivotPoint.Y);
			_labelDetail.Location.AlignH = AlignH.Left;
		}
		else
		{
			_endPoint = new PointF((float)((double)_pivotPoint.X - 0.05 * (double)rect.Width), _pivotPoint.Y);
			_labelDetail.Location.AlignH = AlignH.Right;
		}
		_midAngle = (float)midAngle;
	}

	private static void BuildLabelString(PieItem curve)
	{
		NumberFormatInfo numberFormatInfo = (NumberFormatInfo)NumberFormatInfo.CurrentInfo.Clone();
		numberFormatInfo.NumberDecimalDigits = curve._valueDecimalDigits;
		numberFormatInfo.PercentPositivePattern = 1;
		numberFormatInfo.PercentDecimalDigits = curve._percentDecimalDigits;
		switch (curve._labelType)
		{
		case PieLabelType.Value:
			curve._labelStr = curve._pieValue.ToString("F", numberFormatInfo);
			break;
		case PieLabelType.Percent:
			curve._labelStr = (curve._sweepAngle / 360f).ToString("P", numberFormatInfo);
			break;
		case PieLabelType.Name_Value:
			curve._labelStr = curve._label._text + ": " + curve._pieValue.ToString("F", numberFormatInfo);
			break;
		case PieLabelType.Name_Percent:
			curve._labelStr = curve._label._text + ": " + (curve._sweepAngle / 360f).ToString("P", numberFormatInfo);
			break;
		case PieLabelType.Name_Value_Percent:
			curve._labelStr = curve._label._text + ": " + curve._pieValue.ToString("F", numberFormatInfo) + " (" + (curve._sweepAngle / 360f).ToString("P", numberFormatInfo) + ")";
			break;
		case PieLabelType.Name:
			curve._labelStr = curve._label._text;
			break;
		case PieLabelType.None:
			break;
		}
	}

	private static void CalcNewBaseRect(double maxDisplacement, ref RectangleF baseRect)
	{
		float num = (float)(maxDisplacement * (double)baseRect.Width);
		_ = baseRect.Height;
		baseRect.Inflate(0f - num / 10f, 0f - num / 10f);
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
		PointF location = _boundingRectangle.Location;
		location.X += _boundingRectangle.Width / 2f;
		location.Y += _boundingRectangle.Height / 2f;
		float num = _boundingRectangle.Width / 2f;
		Matrix matrix = new Matrix();
		matrix.Translate(location.X, location.Y);
		matrix.Rotate(StartAngle);
		int num2 = (int)Math.Floor(SweepAngle / 5f) + 1;
		PointF[] array = new PointF[2 + num2];
		ref PointF reference = ref array[0];
		reference = new PointF(0f, 0f);
		ref PointF reference2 = ref array[1];
		reference2 = new PointF(num, 0f);
		double num3 = 0.0;
		for (int j = 2; j < num2 + 2; j++)
		{
			num3 += (double)(SweepAngle / (float)num2);
			ref PointF reference3 = ref array[j];
			reference3 = new PointF(num * (float)Math.Cos(num3 * Math.PI / 180.0), num * (float)Math.Sin(num3 * Math.PI / 180.0));
		}
		matrix.TransformPoints(array);
		coords = $"{array[0].X:f0},{array[0].Y:f0},{array[1].X:f0},{array[1].Y:f0},";
		for (int k = 2; k < num2 + 2; k++)
		{
			coords += string.Format((k > num2) ? "{0:f0},{1:f0}" : "{0:f0},{1:f0},", array[k].X, array[k].Y);
		}
		return true;
	}
}
