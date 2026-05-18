using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Line : LineBase, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static Color Color = Color.Red;

		public static Color FillColor = Color.Red;

		public static Brush FillBrush = null;

		public static FillType FillType = FillType.None;

		public static bool IsSmooth = false;

		public static float SmoothTension = 0.5f;

		public static bool IsOptimizedDraw = false;

		public static StepType StepType = StepType.NonStep;
	}

	public const int schema = 14;

	private bool _isSmooth;

	private float _smoothTension;

	private StepType _stepType;

	private Fill _fill;

	private bool _isOptimizedDraw;

	public bool IsSmooth
	{
		get
		{
			return _isSmooth;
		}
		set
		{
			_isSmooth = value;
		}
	}

	public float SmoothTension
	{
		get
		{
			return _smoothTension;
		}
		set
		{
			_smoothTension = value;
		}
	}

	public StepType StepType
	{
		get
		{
			return _stepType;
		}
		set
		{
			_stepType = value;
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

	public bool IsOptimizedDraw
	{
		get
		{
			return _isOptimizedDraw;
		}
		set
		{
			_isOptimizedDraw = value;
		}
	}

	public Line()
		: this(Color.Empty)
	{
	}

	public Line(Color color)
	{
		_color = (color.IsEmpty ? Default.Color : color);
		_stepType = Default.StepType;
		_isSmooth = Default.IsSmooth;
		_smoothTension = Default.SmoothTension;
		_fill = new Fill(Default.FillColor, Default.FillBrush, Default.FillType);
		_isOptimizedDraw = Default.IsOptimizedDraw;
	}

	public Line(Line rhs)
	{
		_color = rhs._color;
		_stepType = rhs._stepType;
		_isSmooth = rhs._isSmooth;
		_smoothTension = rhs._smoothTension;
		_fill = rhs._fill.Clone();
		_isOptimizedDraw = rhs._isOptimizedDraw;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Line Clone()
	{
		return new Line(this);
	}

	protected Line(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		int @int = info.GetInt32("schema");
		if (@int >= 14)
		{
			_color = (Color)info.GetValue("color", typeof(Color));
		}
		_stepType = (StepType)info.GetValue("stepType", typeof(StepType));
		_isSmooth = info.GetBoolean("isSmooth");
		_smoothTension = info.GetSingle("smoothTension");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		if (@int >= 13)
		{
			_isOptimizedDraw = info.GetBoolean("isOptimizedDraw");
		}
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema", 14);
		info.AddValue("color", _color);
		info.AddValue("stepType", _stepType);
		info.AddValue("isSmooth", _isSmooth);
		info.AddValue("smoothTension", _smoothTension);
		info.AddValue("fill", _fill);
		info.AddValue("isOptimizedDraw", _isOptimizedDraw);
	}

	public void Draw(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
	{
		if (base.IsVisible)
		{
			SmoothingMode smoothingMode = g.SmoothingMode;
			if (_isAntiAlias)
			{
				g.SmoothingMode = SmoothingMode.HighQuality;
			}
			if (curve is StickItem)
			{
				DrawSticks(g, pane, curve, scaleFactor);
			}
			else if (IsSmooth || Fill.IsVisible)
			{
				DrawSmoothFilledCurve(g, pane, curve, scaleFactor);
			}
			else
			{
				DrawCurve(g, pane, curve, scaleFactor);
			}
			g.SmoothingMode = smoothingMode;
		}
	}

	public void DrawSegment(Graphics g, GraphPane pane, float x1, float y1, float x2, float y2, float scaleFactor)
	{
		if (_isVisible && !base.Color.IsEmpty)
		{
			using (Pen pen = GetPen(pane, scaleFactor))
			{
				g.DrawLine(pen, x1, y1, x2, y2);
			}
		}
	}

	public void DrawSticks(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
	{
		Line line = this;
		if (curve.IsSelected)
		{
			line = Selection.Line;
		}
		Axis yAxis = curve.GetYAxis(pane);
		Axis xAxis = curve.GetXAxis(pane);
		float y = yAxis.Scale.Transform(0.0);
		using Pen pen = line.GetPen(pane, scaleFactor);
		for (int i = 0; i < curve.Points.Count; i++)
		{
			PointPair pointPair = curve.Points[i];
			if (pointPair.X == double.MaxValue || pointPair.Y == double.MaxValue || double.IsNaN(pointPair.X) || double.IsNaN(pointPair.Y) || double.IsInfinity(pointPair.X) || double.IsInfinity(pointPair.Y) || (xAxis._scale.IsLog && !(pointPair.X > 0.0)) || (yAxis._scale.IsLog && !(pointPair.Y > 0.0)))
			{
				continue;
			}
			float num = yAxis.Scale.Transform(curve.IsOverrideOrdinal, i, pointPair.Y);
			float num2 = xAxis.Scale.Transform(curve.IsOverrideOrdinal, i, pointPair.X);
			if (!(num2 >= pane.Chart._rect.Left) || !(num2 <= pane.Chart._rect.Right))
			{
				continue;
			}
			if (num > pane.Chart._rect.Bottom)
			{
				num = pane.Chart._rect.Bottom;
			}
			if (num < pane.Chart._rect.Top)
			{
				num = pane.Chart._rect.Top;
			}
			if (!curve.IsSelected && _gradientFill.IsGradientValueType)
			{
				using Pen pen2 = GetPen(pane, scaleFactor, pointPair);
				g.DrawLine(pen2, num2, num, num2, y);
			}
			else
			{
				g.DrawLine(pen, num2, num, num2, y);
			}
		}
	}

	public void DrawSmoothFilledCurve(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
	{
		Line line = this;
		if (curve.IsSelected)
		{
			line = Selection.Line;
		}
		IPointList points = curve.Points;
		if (!base.IsVisible || base.Color.IsEmpty || points == null || !BuildPointsArray(pane, curve, out var arrPoints, out var count) || count <= 2)
		{
			return;
		}
		float tension = (_isSmooth ? _smoothTension : 0f);
		if (Fill.IsVisible)
		{
			Axis yAxis = curve.GetYAxis(pane);
			using GraphicsPath graphicsPath = new GraphicsPath(FillMode.Winding);
			graphicsPath.AddCurve(arrPoints, 0, count - 2, tension);
			double yMin = ((yAxis._scale._min < 0.0) ? 0.0 : yAxis._scale._min);
			CloseCurve(pane, curve, arrPoints, count, yMin, graphicsPath);
			RectangleF bounds = graphicsPath.GetBounds();
			using (Brush brush = line._fill.MakeBrush(bounds))
			{
				if (pane.LineType == LineType.Stack && yAxis.Scale._min < 0.0 && IsFirstLine(pane, curve))
				{
					float num = yAxis.Scale.Transform(0.0);
					RectangleF rect = pane.Chart._rect;
					rect.Height = num - rect.Top;
					if (rect.Height > 0f)
					{
						_ = g.Clip;
						g.SetClip(rect);
						g.FillPath(brush, graphicsPath);
						g.SetClip(pane.Chart._rect);
					}
				}
				else
				{
					g.FillPath(brush, graphicsPath);
				}
			}
			yAxis.FixZeroLine(g, pane, scaleFactor, bounds.Left, bounds.Right);
		}
		if (_isSmooth)
		{
			using (Pen pen = GetPen(pane, scaleFactor))
			{
				g.DrawCurve(pen, arrPoints, 0, count - 2, tension);
				return;
			}
		}
		DrawCurve(g, pane, curve, scaleFactor);
	}

	private bool IsFirstLine(GraphPane pane, CurveItem curve)
	{
		CurveList curveList = pane.CurveList;
		for (int i = 0; i < curveList.Count; i++)
		{
			CurveItem curveItem = curveList[i];
			if (curveItem is LineItem && curveItem.IsY2Axis == curve.IsY2Axis && curveItem.YAxisIndex == curve.YAxisIndex)
			{
				return curveItem == curve;
			}
		}
		return false;
	}

	public void DrawCurve(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
	{
		Line line = this;
		if (curve.IsSelected)
		{
			line = Selection.Line;
		}
		int num = int.MaxValue;
		int num2 = int.MaxValue;
		PointPair pointPair = new PointPair();
		bool flag = true;
		IPointList points = curve.Points;
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		Axis yAxis = curve.GetYAxis(pane);
		Axis xAxis = curve.GetXAxis(pane);
		bool isLog = xAxis._scale.IsLog;
		bool isLog2 = yAxis._scale.IsLog;
		int num3 = (int)pane.Chart.Rect.Left;
		int num4 = (int)pane.Chart.Rect.Right;
		int num5 = (int)pane.Chart.Rect.Top;
		int num6 = (int)pane.Chart.Rect.Bottom;
		using Pen pen = line.GetPen(pane, scaleFactor);
		if (points == null || _color.IsEmpty || !base.IsVisible)
		{
			return;
		}
		bool flag2 = _isOptimizedDraw && points.Count > 1000;
		bool[,] array = null;
		if (flag2)
		{
			array = new bool[num4 + 1, num6 + 1];
		}
		for (int i = 0; i < points.Count; i++)
		{
			PointPair pointPair2 = points[i];
			double baseVal;
			double hiVal;
			if (pane.LineType == LineType.Stack)
			{
				if (!valueHandler.GetValues(curve, i, out baseVal, out var _, out hiVal))
				{
					baseVal = double.MaxValue;
					hiVal = double.MaxValue;
				}
			}
			else
			{
				baseVal = pointPair2.X;
				hiVal = pointPair2.Y;
			}
			bool flag3;
			if (baseVal == double.MaxValue || hiVal == double.MaxValue || double.IsNaN(baseVal) || double.IsNaN(hiVal) || double.IsInfinity(baseVal) || double.IsInfinity(hiVal) || (isLog && baseVal <= 0.0) || (isLog2 && hiVal <= 0.0))
			{
				flag = flag || !pane.IsIgnoreMissing;
				flag3 = true;
				continue;
			}
			int num7 = (int)xAxis.Scale.Transform(curve.IsOverrideOrdinal, i, baseVal);
			int num8 = (int)yAxis.Scale.Transform(curve.IsOverrideOrdinal, i, hiVal);
			if (flag2 && num7 >= num3 && num7 <= num4 && num8 >= num5 && num8 <= num6)
			{
				if (array[num7, num8])
				{
					continue;
				}
				array[num7, num8] = true;
			}
			flag3 = (num7 < num3 && num < num3) || (num7 > num4 && num > num4) || (num8 < num5 && num2 < num5) || (num8 > num6 && num2 > num6);
			if (!flag)
			{
				try
				{
					if (num > 5000000 || num < -5000000 || num2 > 5000000 || num2 < -5000000 || num7 > 5000000 || num7 < -5000000 || num8 > 5000000 || num8 < -5000000)
					{
						InterpolatePoint(g, pane, curve, pointPair, scaleFactor, pen, num, num2, num7, num8);
					}
					else if (!flag3)
					{
						if (!curve.IsSelected && _gradientFill.IsGradientValueType)
						{
							using Pen pen2 = GetPen(pane, scaleFactor, pointPair);
							if (StepType == StepType.NonStep)
							{
								g.DrawLine(pen2, num, num2, num7, num8);
							}
							else if (StepType == StepType.ForwardStep)
							{
								g.DrawLine(pen2, num, num2, num7, num2);
								g.DrawLine(pen2, num7, num2, num7, num8);
							}
							else if (StepType == StepType.RearwardStep)
							{
								g.DrawLine(pen2, num, num2, num, num8);
								g.DrawLine(pen2, num, num8, num7, num8);
							}
							else if (StepType == StepType.ForwardSegment)
							{
								g.DrawLine(pen2, num, num2, num7, num2);
							}
							else
							{
								g.DrawLine(pen2, num, num8, num7, num8);
							}
						}
						else if (StepType == StepType.NonStep)
						{
							g.DrawLine(pen, num, num2, num7, num8);
						}
						else if (StepType == StepType.ForwardStep)
						{
							g.DrawLine(pen, num, num2, num7, num2);
							g.DrawLine(pen, num7, num2, num7, num8);
						}
						else if (StepType == StepType.RearwardStep)
						{
							g.DrawLine(pen, num, num2, num, num8);
							g.DrawLine(pen, num, num8, num7, num8);
						}
						else if (StepType == StepType.ForwardSegment)
						{
							g.DrawLine(pen, num, num2, num7, num2);
						}
						else if (StepType == StepType.RearwardSegment)
						{
							g.DrawLine(pen, num, num8, num7, num8);
						}
					}
				}
				catch
				{
					InterpolatePoint(g, pane, curve, pointPair, scaleFactor, pen, num, num2, num7, num8);
				}
			}
			pointPair = pointPair2;
			num = num7;
			num2 = num8;
			flag = false;
		}
	}

	public void DrawCurveOriginal(Graphics g, GraphPane pane, CurveItem curve, float scaleFactor)
	{
		Line line = this;
		if (curve.IsSelected)
		{
			line = Selection.Line;
		}
		float num = float.MaxValue;
		float num2 = float.MaxValue;
		PointPair pointPair = new PointPair();
		bool flag = true;
		IPointList points = curve.Points;
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		Axis yAxis = curve.GetYAxis(pane);
		Axis xAxis = curve.GetXAxis(pane);
		bool isLog = xAxis._scale.IsLog;
		bool isLog2 = yAxis._scale.IsLog;
		float left = pane.Chart.Rect.Left;
		float right = pane.Chart.Rect.Right;
		float top = pane.Chart.Rect.Top;
		float bottom = pane.Chart.Rect.Bottom;
		using Pen pen = line.GetPen(pane, scaleFactor);
		if (points == null || _color.IsEmpty || !base.IsVisible)
		{
			return;
		}
		for (int i = 0; i < points.Count; i++)
		{
			PointPair pointPair2 = points[i];
			double baseVal;
			double hiVal;
			if (pane.LineType == LineType.Stack)
			{
				if (!valueHandler.GetValues(curve, i, out baseVal, out var _, out hiVal))
				{
					baseVal = double.MaxValue;
					hiVal = double.MaxValue;
				}
			}
			else
			{
				baseVal = pointPair2.X;
				hiVal = pointPair2.Y;
			}
			bool flag2;
			if (baseVal == double.MaxValue || hiVal == double.MaxValue || double.IsNaN(baseVal) || double.IsNaN(hiVal) || double.IsInfinity(baseVal) || double.IsInfinity(hiVal) || (isLog && baseVal <= 0.0) || (isLog2 && hiVal <= 0.0))
			{
				flag = flag || !pane.IsIgnoreMissing;
				flag2 = true;
				continue;
			}
			float num3 = xAxis.Scale.Transform(curve.IsOverrideOrdinal, i, baseVal);
			float num4 = yAxis.Scale.Transform(curve.IsOverrideOrdinal, i, hiVal);
			flag2 = (num3 < left && num < left) || (num3 > right && num > right) || (num4 < top && num2 < top) || (num4 > bottom && num2 > bottom);
			if (!flag)
			{
				try
				{
					if (num > 5000000f || num < -5000000f || num2 > 5000000f || num2 < -5000000f || num3 > 5000000f || num3 < -5000000f || num4 > 5000000f || num4 < -5000000f)
					{
						InterpolatePoint(g, pane, curve, pointPair, scaleFactor, pen, num, num2, num3, num4);
					}
					else if (!flag2)
					{
						if (!curve.IsSelected && _gradientFill.IsGradientValueType)
						{
							using Pen pen2 = GetPen(pane, scaleFactor, pointPair);
							if (StepType == StepType.NonStep)
							{
								g.DrawLine(pen2, num, num2, num3, num4);
							}
							else if (StepType == StepType.ForwardStep)
							{
								g.DrawLine(pen2, num, num2, num3, num2);
								g.DrawLine(pen2, num3, num2, num3, num4);
							}
							else if (StepType == StepType.RearwardStep)
							{
								g.DrawLine(pen2, num, num2, num, num4);
								g.DrawLine(pen2, num, num4, num3, num4);
							}
							else if (StepType == StepType.ForwardSegment)
							{
								g.DrawLine(pen2, num, num2, num3, num2);
							}
							else
							{
								g.DrawLine(pen2, num, num4, num3, num4);
							}
						}
						else if (StepType == StepType.NonStep)
						{
							g.DrawLine(pen, num, num2, num3, num4);
						}
						else if (StepType == StepType.ForwardStep)
						{
							g.DrawLine(pen, num, num2, num3, num2);
							g.DrawLine(pen, num3, num2, num3, num4);
						}
						else if (StepType == StepType.RearwardStep)
						{
							g.DrawLine(pen, num, num2, num, num4);
							g.DrawLine(pen, num, num4, num3, num4);
						}
						else if (StepType == StepType.ForwardSegment)
						{
							g.DrawLine(pen, num, num2, num3, num2);
						}
						else if (StepType == StepType.RearwardSegment)
						{
							g.DrawLine(pen, num, num4, num3, num4);
						}
					}
				}
				catch
				{
					InterpolatePoint(g, pane, curve, pointPair, scaleFactor, pen, num, num2, num3, num4);
				}
			}
			pointPair = pointPair2;
			num = num3;
			num2 = num4;
			flag = false;
		}
	}

	private void InterpolatePoint(Graphics g, GraphPane pane, CurveItem curve, PointPair lastPt, float scaleFactor, Pen pen, float lastX, float lastY, float tmpX, float tmpY)
	{
		try
		{
			RectangleF rect = pane.Chart._rect;
			bool flag = rect.Contains(lastX, lastY);
			bool flag2 = rect.Contains(tmpX, tmpY);
			if (!flag)
			{
				float num;
				float num2;
				if (Math.Abs(lastX) > Math.Abs(lastY))
				{
					num = ((lastX < 0f) ? rect.Left : rect.Right);
					num2 = lastY + (tmpY - lastY) * (num - lastX) / (tmpX - lastX);
				}
				else
				{
					num2 = ((lastY < 0f) ? rect.Top : rect.Bottom);
					num = lastX + (tmpX - lastX) * (num2 - lastY) / (tmpY - lastY);
				}
				lastX = num;
				lastY = num2;
			}
			if (!flag2)
			{
				float num3;
				float num4;
				if (Math.Abs(tmpX) > Math.Abs(tmpY))
				{
					num3 = ((tmpX < 0f) ? rect.Left : rect.Right);
					num4 = tmpY + (lastY - tmpY) * (num3 - tmpX) / (lastX - tmpX);
				}
				else
				{
					num4 = ((tmpY < 0f) ? rect.Top : rect.Bottom);
					num3 = tmpX + (lastX - tmpX) * (num4 - tmpY) / (lastY - tmpY);
				}
				tmpX = num3;
				tmpY = num4;
			}
			if (!curve.IsSelected && _gradientFill.IsGradientValueType)
			{
				using (Pen pen2 = GetPen(pane, scaleFactor, lastPt))
				{
					if (StepType == StepType.NonStep)
					{
						g.DrawLine(pen2, lastX, lastY, tmpX, tmpY);
					}
					else if (StepType == StepType.ForwardStep)
					{
						g.DrawLine(pen2, lastX, lastY, tmpX, lastY);
						g.DrawLine(pen2, tmpX, lastY, tmpX, tmpY);
					}
					else if (StepType == StepType.RearwardStep)
					{
						g.DrawLine(pen2, lastX, lastY, lastX, tmpY);
						g.DrawLine(pen2, lastX, tmpY, tmpX, tmpY);
					}
					else if (StepType == StepType.ForwardSegment)
					{
						g.DrawLine(pen2, lastX, lastY, tmpX, lastY);
					}
					else
					{
						g.DrawLine(pen2, lastX, tmpY, tmpX, tmpY);
					}
					return;
				}
			}
			if (StepType == StepType.NonStep)
			{
				g.DrawLine(pen, lastX, lastY, tmpX, tmpY);
			}
			else if (StepType == StepType.ForwardStep)
			{
				g.DrawLine(pen, lastX, lastY, tmpX, lastY);
				g.DrawLine(pen, tmpX, lastY, tmpX, tmpY);
			}
			else if (StepType == StepType.RearwardStep)
			{
				g.DrawLine(pen, lastX, lastY, lastX, tmpY);
				g.DrawLine(pen, lastX, tmpY, tmpX, tmpY);
			}
			else if (StepType == StepType.ForwardSegment)
			{
				g.DrawLine(pen, lastX, lastY, tmpX, lastY);
			}
			else if (StepType == StepType.RearwardSegment)
			{
				g.DrawLine(pen, lastX, tmpY, tmpX, tmpY);
			}
		}
		catch
		{
		}
	}

	public bool BuildPointsArray(GraphPane pane, CurveItem curve, out PointF[] arrPoints, out int count)
	{
		arrPoints = null;
		count = 0;
		IPointList points = curve.Points;
		if (base.IsVisible && !base.Color.IsEmpty && points != null)
		{
			int num = 0;
			float x = 0f;
			float y = 0f;
			ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
			arrPoints = new PointF[((_stepType == StepType.NonStep) ? 1 : 2) * points.Count + 1];
			for (int i = 0; i < points.Count; i++)
			{
				if (points[i].IsInvalid)
				{
					continue;
				}
				double baseVal;
				double hiVal;
				if (pane.LineType == LineType.Stack)
				{
					valueHandler.GetValues(curve, i, out baseVal, out var _, out hiVal);
				}
				else
				{
					baseVal = points[i].X;
					hiVal = points[i].Y;
				}
				if (baseVal == double.MaxValue || hiVal == double.MaxValue)
				{
					continue;
				}
				Axis xAxis = curve.GetXAxis(pane);
				float num2 = xAxis.Scale.Transform(curve.IsOverrideOrdinal, i, baseVal);
				Axis yAxis = curve.GetYAxis(pane);
				float num3 = yAxis.Scale.Transform(curve.IsOverrideOrdinal, i, hiVal);
				if (!(num2 < -1000000f) && !(num3 < -1000000f) && !(num2 > 1000000f) && !(num3 > 1000000f))
				{
					if (_isSmooth || num == 0 || StepType == StepType.NonStep)
					{
						arrPoints[num].X = num2;
						arrPoints[num].Y = num3;
					}
					else if (StepType == StepType.ForwardStep || StepType == StepType.ForwardSegment)
					{
						arrPoints[num].X = num2;
						arrPoints[num].Y = y;
						num++;
						arrPoints[num].X = num2;
						arrPoints[num].Y = num3;
					}
					else if (StepType == StepType.RearwardStep || StepType == StepType.RearwardSegment)
					{
						arrPoints[num].X = x;
						arrPoints[num].Y = num3;
						num++;
						arrPoints[num].X = num2;
						arrPoints[num].Y = num3;
					}
					x = num2;
					y = num3;
					num++;
				}
			}
			if (num == 0)
			{
				return false;
			}
			ref PointF reference = ref arrPoints[num];
			reference = arrPoints[num - 1];
			num++;
			count = num;
			return true;
		}
		return false;
	}

	public bool BuildLowPointsArray(GraphPane pane, CurveItem curve, out PointF[] arrPoints, out int count)
	{
		arrPoints = null;
		count = 0;
		IPointList points = curve.Points;
		if (base.IsVisible && !base.Color.IsEmpty && points != null)
		{
			int num = 0;
			float x = 0f;
			float y = 0f;
			ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
			arrPoints = new PointF[((_stepType == StepType.NonStep) ? 1 : 2) * ((pane.LineType != LineType.Stack) ? 1 : 2) * points.Count + 1];
			for (int num2 = points.Count - 1; num2 >= 0; num2--)
			{
				if (!points[num2].IsInvalid)
				{
					valueHandler.GetValues(curve, num2, out var baseVal, out var lowVal, out var _);
					if (baseVal != double.MaxValue && lowVal != double.MaxValue)
					{
						Axis xAxis = curve.GetXAxis(pane);
						float num3 = xAxis.Scale.Transform(curve.IsOverrideOrdinal, num2, baseVal);
						Axis yAxis = curve.GetYAxis(pane);
						float num4 = yAxis.Scale.Transform(curve.IsOverrideOrdinal, num2, lowVal);
						if (_isSmooth || num == 0 || StepType == StepType.NonStep)
						{
							arrPoints[num].X = num3;
							arrPoints[num].Y = num4;
						}
						else if (StepType == StepType.ForwardStep)
						{
							arrPoints[num].X = num3;
							arrPoints[num].Y = y;
							num++;
							arrPoints[num].X = num3;
							arrPoints[num].Y = num4;
						}
						else if (StepType == StepType.RearwardStep)
						{
							arrPoints[num].X = x;
							arrPoints[num].Y = num4;
							num++;
							arrPoints[num].X = num3;
							arrPoints[num].Y = num4;
						}
						x = num3;
						y = num4;
						num++;
					}
				}
			}
			if (num == 0)
			{
				return false;
			}
			ref PointF reference = ref arrPoints[num];
			reference = arrPoints[num - 1];
			num++;
			count = num;
			return true;
		}
		return false;
	}

	public void CloseCurve(GraphPane pane, CurveItem curve, PointF[] arrPoints, int count, double yMin, GraphicsPath path)
	{
		if (pane.LineType != LineType.Stack)
		{
			Axis yAxis = curve.GetYAxis(pane);
			float num = yAxis.Scale.Transform(yMin);
			path.AddLine(arrPoints[count - 1].X, arrPoints[count - 1].Y, arrPoints[count - 1].X, num);
			path.AddLine(arrPoints[count - 1].X, num, arrPoints[0].X, num);
			path.AddLine(arrPoints[0].X, num, arrPoints[0].X, arrPoints[0].Y);
			return;
		}
		float tension = (_isSmooth ? _smoothTension : 0f);
		int num2 = pane.CurveList.IndexOf(curve);
		if (num2 > 0)
		{
			for (int num3 = num2 - 1; num3 >= 0; num3--)
			{
				CurveItem curveItem = pane.CurveList[num3];
				if (curveItem is LineItem)
				{
					tension = (((LineItem)curveItem).Line.IsSmooth ? ((LineItem)curveItem).Line.SmoothTension : 0f);
					break;
				}
			}
		}
		BuildLowPointsArray(pane, curve, out var arrPoints2, out var count2);
		path.AddCurve(arrPoints2, 0, count2 - 2, tension);
	}
}
