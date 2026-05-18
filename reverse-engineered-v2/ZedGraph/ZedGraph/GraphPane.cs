using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class GraphPane : PaneBase, ICloneable, ISerializable
{
	public delegate void AxisChangeEventHandler(GraphPane pane);

	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static bool IsIgnoreInitial = false;

		public static bool IsBoundedRanges = false;

		public static LineType LineType = LineType.Normal;

		public static double ClusterScaleWidth = 1.0;

		public static double NearestTol = 7.0;
	}

	public const int schema2 = 11;

	private XAxis _xAxis;

	private X2Axis _x2Axis;

	private YAxisList _yAxisList;

	private Y2AxisList _y2AxisList;

	private CurveList _curveList;

	private ZoomStateStack _zoomStack;

	internal Chart _chart;

	internal BarSettings _barSettings;

	private bool _isIgnoreInitial;

	private bool _isIgnoreMissing;

	private bool _isBoundedRanges;

	private bool _isAlignGrids;

	private LineType _lineType;

	public CurveList CurveList
	{
		get
		{
			return _curveList;
		}
		set
		{
			_curveList = value;
		}
	}

	public XAxis XAxis => _xAxis;

	public X2Axis X2Axis => _x2Axis;

	public YAxis YAxis => _yAxisList[0];

	public Y2Axis Y2Axis => _y2AxisList[0];

	public YAxisList YAxisList => _yAxisList;

	public Y2AxisList Y2AxisList => _y2AxisList;

	public Chart Chart => _chart;

	public BarSettings BarSettings => _barSettings;

	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Description("Determines whether the auto-ranged scale will include all data points or just the visible data points")]
	[Category("Display")]
	[Browsable(true)]
	public bool IsIgnoreInitial
	{
		get
		{
			return _isIgnoreInitial;
		}
		set
		{
			_isIgnoreInitial = value;
		}
	}

	public bool IsBoundedRanges
	{
		get
		{
			return _isBoundedRanges;
		}
		set
		{
			_isBoundedRanges = value;
		}
	}

	public bool IsIgnoreMissing
	{
		get
		{
			return _isIgnoreMissing;
		}
		set
		{
			_isIgnoreMissing = value;
		}
	}

	public bool IsAlignGrids
	{
		get
		{
			return _isAlignGrids;
		}
		set
		{
			_isAlignGrids = value;
		}
	}

	public LineType LineType
	{
		get
		{
			return _lineType;
		}
		set
		{
			_lineType = value;
		}
	}

	public bool IsZoomed => !_zoomStack.IsEmpty;

	public ZoomStateStack ZoomStack => _zoomStack;

	public event AxisChangeEventHandler AxisChangeEvent;

	public GraphPane()
		: this(new RectangleF(0f, 0f, 500f, 375f), "", "", "")
	{
	}

	public GraphPane(RectangleF rect, string title, string xTitle, string yTitle)
		: base(title, rect)
	{
		_xAxis = new XAxis(xTitle);
		_x2Axis = new X2Axis("");
		_yAxisList = new YAxisList();
		_y2AxisList = new Y2AxisList();
		_yAxisList.Add(new YAxis(yTitle));
		_y2AxisList.Add(new Y2Axis(string.Empty));
		_curveList = new CurveList();
		_zoomStack = new ZoomStateStack();
		_isIgnoreInitial = Default.IsIgnoreInitial;
		_isBoundedRanges = Default.IsBoundedRanges;
		_isAlignGrids = false;
		_chart = new Chart();
		_barSettings = new BarSettings(this);
		_lineType = Default.LineType;
	}

	public GraphPane(GraphPane rhs)
		: base(rhs)
	{
		_isIgnoreInitial = rhs.IsIgnoreInitial;
		_isBoundedRanges = rhs._isBoundedRanges;
		_isAlignGrids = rhs._isAlignGrids;
		_chart = rhs._chart.Clone();
		_barSettings = new BarSettings(rhs._barSettings, this);
		_lineType = rhs.LineType;
		_xAxis = new XAxis(rhs.XAxis);
		_x2Axis = new X2Axis(rhs.X2Axis);
		_yAxisList = new YAxisList(rhs._yAxisList);
		_y2AxisList = new Y2AxisList(rhs._y2AxisList);
		_curveList = new CurveList(rhs.CurveList);
		_zoomStack = new ZoomStateStack(rhs._zoomStack);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public GraphPane Clone()
	{
		return new GraphPane(this);
	}

	protected GraphPane(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		int @int = info.GetInt32("schema2");
		_xAxis = (XAxis)info.GetValue("xAxis", typeof(XAxis));
		if (@int >= 11)
		{
			_x2Axis = (X2Axis)info.GetValue("x2Axis", typeof(X2Axis));
		}
		else
		{
			_x2Axis = new X2Axis("");
		}
		_yAxisList = (YAxisList)info.GetValue("yAxisList", typeof(YAxisList));
		_y2AxisList = (Y2AxisList)info.GetValue("y2AxisList", typeof(Y2AxisList));
		_curveList = (CurveList)info.GetValue("curveList", typeof(CurveList));
		_chart = (Chart)info.GetValue("chart", typeof(Chart));
		_barSettings = (BarSettings)info.GetValue("barSettings", typeof(BarSettings));
		_barSettings._ownerPane = this;
		_isIgnoreInitial = info.GetBoolean("isIgnoreInitial");
		_isBoundedRanges = info.GetBoolean("isBoundedRanges");
		_isIgnoreMissing = info.GetBoolean("isIgnoreMissing");
		_isAlignGrids = info.GetBoolean("isAlignGrids");
		_lineType = (LineType)info.GetValue("lineType", typeof(LineType));
		_zoomStack = new ZoomStateStack();
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
		info.AddValue("xAxis", _xAxis);
		info.AddValue("x2Axis", _x2Axis);
		info.AddValue("yAxisList", _yAxisList);
		info.AddValue("y2AxisList", _y2AxisList);
		info.AddValue("curveList", _curveList);
		info.AddValue("chart", _chart);
		info.AddValue("barSettings", _barSettings);
		info.AddValue("isIgnoreInitial", _isIgnoreInitial);
		info.AddValue("isBoundedRanges", _isBoundedRanges);
		info.AddValue("isIgnoreMissing", _isIgnoreMissing);
		info.AddValue("isAlignGrids", _isAlignGrids);
		info.AddValue("lineType", _lineType);
	}

	public void AxisChange()
	{
		using Graphics g = Graphics.FromHwnd(IntPtr.Zero);
		AxisChange(g);
	}

	public void AxisChange(Graphics g)
	{
		_curveList.GetRange(_isIgnoreInitial, _isBoundedRanges, this);
		float scaleFactor = CalcScaleFactor();
		if (CurveList.IsPieOnly)
		{
			XAxis.IsVisible = false;
			X2Axis.IsVisible = false;
			YAxis.IsVisible = false;
			Y2Axis.IsVisible = false;
			_chart.Border.IsVisible = false;
		}
		if (_barSettings._clusterScaleWidthAuto)
		{
			_barSettings._clusterScaleWidth = 1.0;
		}
		if (_chart._isRectAuto)
		{
			PickScale(g, scaleFactor);
			_chart._rect = CalcChartRect(g);
		}
		PickScale(g, scaleFactor);
		_barSettings.CalcClusterScaleWidth();
		if (this.AxisChangeEvent != null)
		{
			this.AxisChangeEvent(this);
		}
	}

	private void PickScale(Graphics g, float scaleFactor)
	{
		int num = 0;
		_xAxis._scale.PickScale(this, g, scaleFactor);
		_x2Axis._scale.PickScale(this, g, scaleFactor);
		foreach (YAxis yAxis in _yAxisList)
		{
			yAxis._scale.PickScale(this, g, scaleFactor);
			if (yAxis._scale.MaxAuto)
			{
				int num2 = yAxis._scale.CalcNumTics();
				num = ((num2 > num) ? num2 : num);
			}
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			y2Axis._scale.PickScale(this, g, scaleFactor);
			if (y2Axis._scale.MaxAuto)
			{
				int num3 = y2Axis._scale.CalcNumTics();
				num = ((num3 > num) ? num3 : num);
			}
		}
		if (!_isAlignGrids)
		{
			return;
		}
		foreach (YAxis yAxis2 in _yAxisList)
		{
			ForceNumTics(yAxis2, num);
		}
		foreach (Y2Axis y2Axis2 in _y2AxisList)
		{
			ForceNumTics(y2Axis2, num);
		}
	}

	private void ForceNumTics(Axis axis, int numTics)
	{
		if (axis._scale.MaxAuto)
		{
			int num = axis._scale.CalcNumTics();
			if (num < numTics)
			{
				axis._scale._maxLinearized += axis._scale._majorStep * (double)(numTics - num);
			}
		}
	}

	public override void Draw(Graphics g)
	{
		base.Draw(g);
		if (_rect.Width <= 1f || _rect.Height <= 1f)
		{
			return;
		}
		g.SetClip(_rect);
		float scaleFactor = CalcScaleFactor();
		if (_chart._isRectAuto)
		{
			_chart._rect = CalcChartRect(g, scaleFactor);
		}
		else
		{
			CalcChartRect(g, scaleFactor);
		}
		if (_chart._rect.Width < 1f || _chart._rect.Height < 1f)
		{
			return;
		}
		bool flag = AxisRangesValid();
		_xAxis.Scale.SetupScaleData(this, _xAxis);
		_x2Axis.Scale.SetupScaleData(this, _x2Axis);
		foreach (YAxis yAxis in _yAxisList)
		{
			yAxis.Scale.SetupScaleData(this, yAxis);
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			y2Axis.Scale.SetupScaleData(this, y2Axis);
		}
		if (flag)
		{
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.G_BehindChartFill);
		}
		_chart.Fill.Draw(g, _chart._rect);
		if (flag)
		{
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.F_BehindGrid);
			DrawGrid(g, scaleFactor);
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.E_BehindCurves);
			g.SetClip(_chart._rect);
			_curveList.Draw(g, this, scaleFactor);
			g.SetClip(_rect);
		}
		if (flag)
		{
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.D_BehindAxis);
			_xAxis.Draw(g, this, scaleFactor, 0f);
			_x2Axis.Draw(g, this, scaleFactor, 0f);
			float num = 0f;
			foreach (YAxis yAxis2 in _yAxisList)
			{
				yAxis2.Draw(g, this, scaleFactor, num);
				num += yAxis2._tmpSpace;
			}
			num = 0f;
			foreach (Y2Axis y2Axis2 in _y2AxisList)
			{
				y2Axis2.Draw(g, this, scaleFactor, num);
				num += y2Axis2._tmpSpace;
			}
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.C_BehindChartBorder);
		}
		_chart.Border.Draw(g, this, scaleFactor, _chart._rect);
		if (flag)
		{
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.B_BehindLegend);
			_legend.Draw(g, this, scaleFactor);
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.A_InFront);
		}
		g.ResetClip();
	}

	internal void DrawGrid(Graphics g, float scaleFactor)
	{
		_xAxis.DrawGrid(g, this, scaleFactor, 0f);
		_x2Axis.DrawGrid(g, this, scaleFactor, 0f);
		float num = 0f;
		foreach (YAxis yAxis in _yAxisList)
		{
			yAxis.DrawGrid(g, this, scaleFactor, num);
			num += yAxis._tmpSpace;
		}
		num = 0f;
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			y2Axis.DrawGrid(g, this, scaleFactor, num);
			num += y2Axis._tmpSpace;
		}
	}

	private bool AxisRangesValid()
	{
		bool result = _xAxis._scale._min < _xAxis._scale._max && _x2Axis._scale._min < _x2Axis._scale._max;
		foreach (YAxis yAxis in _yAxisList)
		{
			if (yAxis._scale._min >= yAxis._scale._max)
			{
				result = false;
			}
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			if (y2Axis._scale._min >= y2Axis._scale._max)
			{
				result = false;
			}
		}
		return result;
	}

	public RectangleF CalcChartRect(Graphics g)
	{
		return CalcChartRect(g, CalcScaleFactor());
	}

	public RectangleF CalcChartRect(Graphics g, float scaleFactor)
	{
		RectangleF rectangleF = CalcClientRect(g, scaleFactor);
		float num = 0f;
		float num2 = 0f;
		float num3 = 0f;
		float fixedSpace = 0f;
		float fixedSpace2 = 0f;
		_xAxis.CalcSpace(g, this, scaleFactor, out fixedSpace);
		_x2Axis.CalcSpace(g, this, scaleFactor, out fixedSpace2);
		foreach (YAxis yAxis in _yAxisList)
		{
			float fixedSpace3;
			float num4 = yAxis.CalcSpace(g, this, scaleFactor, out fixedSpace3);
			if (yAxis.IsCrossShifted(this))
			{
				num += num4;
			}
			num2 += fixedSpace3;
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			float fixedSpace4;
			float num5 = y2Axis.CalcSpace(g, this, scaleFactor, out fixedSpace4);
			if (y2Axis.IsCrossShifted(this))
			{
				num += num5;
			}
			num3 += fixedSpace4;
		}
		float spaceNorm = 0f;
		float spaceAlt = 0f;
		float spaceAlt2 = 0f;
		float spaceNorm2 = 0f;
		SetSpace(_xAxis, rectangleF.Height - _xAxis._tmpSpace, ref spaceNorm, ref spaceAlt);
		SetSpace(_x2Axis, rectangleF.Height - _x2Axis._tmpSpace, ref spaceAlt, ref spaceNorm);
		_xAxis._tmpSpace = spaceNorm;
		_x2Axis._tmpSpace = spaceAlt;
		float num6 = 0f;
		float num7 = 0f;
		foreach (YAxis yAxis2 in _yAxisList)
		{
			SetSpace(yAxis2, rectangleF.Width - num, ref spaceAlt2, ref spaceNorm2);
			num3 = Math.Max(num3, spaceNorm2);
			num6 += spaceAlt2;
			yAxis2._tmpSpace = spaceAlt2;
		}
		foreach (Y2Axis y2Axis2 in _y2AxisList)
		{
			SetSpace(y2Axis2, rectangleF.Width - num, ref spaceNorm2, ref spaceAlt2);
			num2 = Math.Max(num2, spaceAlt2);
			num7 += spaceNorm2;
			y2Axis2._tmpSpace = spaceNorm2;
		}
		RectangleF tChartRect = rectangleF;
		num6 = Math.Max(num6, num2);
		num7 = Math.Max(num7, num3);
		spaceNorm = Math.Max(spaceNorm, fixedSpace);
		spaceAlt = Math.Max(spaceAlt, fixedSpace2);
		tChartRect.X += num6;
		tChartRect.Width -= num6 + num7;
		tChartRect.Height -= spaceAlt + spaceNorm;
		tChartRect.Y += spaceAlt;
		_legend.CalcRect(g, this, scaleFactor, ref tChartRect);
		return tChartRect;
	}

	private void SetSpace(Axis axis, float clientSize, ref float spaceNorm, ref float spaceAlt)
	{
		float num = axis.CalcCrossFraction(this);
		float num2 = num * (1f + num) * (1f + num * num) * clientSize;
		if (!axis.IsPrimary(this) && axis.IsCrossShifted(this))
		{
			axis._tmpSpace = 0f;
		}
		if (axis._tmpSpace < num2)
		{
			axis._tmpSpace = 0f;
		}
		else if (num2 > 0f)
		{
			axis._tmpSpace -= num2;
		}
		if (axis._scale._isLabelsInside && (axis.IsPrimary(this) || ((double)num != 0.0 && (double)num != 1.0)))
		{
			spaceAlt = axis._tmpSpace;
		}
		else
		{
			spaceNorm = axis._tmpSpace;
		}
	}

	public void SetMinSpaceBuffer(Graphics g, float bufferFraction, bool isGrowOnly)
	{
		_xAxis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
		_x2Axis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
		foreach (YAxis yAxis in _yAxisList)
		{
			yAxis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			y2Axis.SetMinSpaceBuffer(g, this, bufferFraction, isGrowOnly);
		}
	}

	public LineItem AddCurve(string label, double[] x, double[] y, Color color)
	{
		LineItem lineItem = new LineItem(label, x, y, color, SymbolType.Default);
		_curveList.Add(lineItem);
		return lineItem;
	}

	public LineItem AddCurve(string label, IPointList points, Color color)
	{
		LineItem lineItem = new LineItem(label, points, color, SymbolType.Default);
		_curveList.Add(lineItem);
		return lineItem;
	}

	public LineItem AddCurve(string label, double[] x, double[] y, Color color, SymbolType symbolType)
	{
		LineItem lineItem = new LineItem(label, x, y, color, symbolType);
		_curveList.Add(lineItem);
		return lineItem;
	}

	public LineItem AddCurve(string label, IPointList points, Color color, SymbolType symbolType)
	{
		LineItem lineItem = new LineItem(label, points, color, symbolType);
		_curveList.Add(lineItem);
		return lineItem;
	}

	public StickItem AddStick(string label, double[] x, double[] y, Color color)
	{
		StickItem stickItem = new StickItem(label, x, y, color);
		_curveList.Add(stickItem);
		return stickItem;
	}

	public StickItem AddStick(string label, IPointList points, Color color)
	{
		StickItem stickItem = new StickItem(label, points, color);
		_curveList.Add(stickItem);
		return stickItem;
	}

	public OHLCBarItem AddOHLCBar(string label, IPointList points, Color color)
	{
		OHLCBarItem oHLCBarItem = new OHLCBarItem(label, points, color);
		_curveList.Add(oHLCBarItem);
		return oHLCBarItem;
	}

	public JapaneseCandleStickItem AddJapaneseCandleStick(string label, IPointList points)
	{
		JapaneseCandleStickItem japaneseCandleStickItem = new JapaneseCandleStickItem(label, points);
		_curveList.Add(japaneseCandleStickItem);
		return japaneseCandleStickItem;
	}

	public ErrorBarItem AddErrorBar(string label, double[] x, double[] y, double[] baseValue, Color color)
	{
		ErrorBarItem errorBarItem = new ErrorBarItem(label, new PointPairList(x, y, baseValue), color);
		_curveList.Add(errorBarItem);
		return errorBarItem;
	}

	public ErrorBarItem AddErrorBar(string label, IPointList points, Color color)
	{
		ErrorBarItem errorBarItem = new ErrorBarItem(label, points, color);
		_curveList.Add(errorBarItem);
		return errorBarItem;
	}

	public BarItem AddBar(string label, IPointList points, Color color)
	{
		BarItem barItem = new BarItem(label, points, color);
		_curveList.Add(barItem);
		return barItem;
	}

	public BarItem AddBar(string label, double[] x, double[] y, Color color)
	{
		BarItem barItem = new BarItem(label, x, y, color);
		_curveList.Add(barItem);
		return barItem;
	}

	public HiLowBarItem AddHiLowBar(string label, double[] x, double[] y, double[] baseVal, Color color)
	{
		HiLowBarItem hiLowBarItem = new HiLowBarItem(label, x, y, baseVal, color);
		_curveList.Add(hiLowBarItem);
		return hiLowBarItem;
	}

	public HiLowBarItem AddHiLowBar(string label, IPointList points, Color color)
	{
		HiLowBarItem hiLowBarItem = new HiLowBarItem(label, points, color);
		_curveList.Add(hiLowBarItem);
		return hiLowBarItem;
	}

	public PieItem AddPieSlice(double value, Color color, double displacement, string label)
	{
		PieItem pieItem = new PieItem(value, color, displacement, label);
		CurveList.Add(pieItem);
		return pieItem;
	}

	public PieItem AddPieSlice(double value, Color color1, Color color2, float fillAngle, double displacement, string label)
	{
		PieItem pieItem = new PieItem(value, color1, color2, fillAngle, displacement, label);
		CurveList.Add(pieItem);
		return pieItem;
	}

	public PieItem[] AddPieSlices(double[] values, string[] labels)
	{
		PieItem[] array = new PieItem[values.Length];
		for (int i = 0; i < values.Length; i++)
		{
			array[i] = new PieItem(values[i], labels[i]);
			CurveList.Add(array[i]);
		}
		return array;
	}

	public PointF GeneralTransform(PointF ptF, CoordType coord)
	{
		_xAxis.Scale.SetupScaleData(this, _xAxis);
		foreach (YAxis yAxis in _yAxisList)
		{
			yAxis.Scale.SetupScaleData(this, yAxis);
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			y2Axis.Scale.SetupScaleData(this, y2Axis);
		}
		return TransformCoord(ptF.X, ptF.Y, coord);
	}

	public PointF GeneralTransform(double x, double y, CoordType coord)
	{
		_xAxis.Scale.SetupScaleData(this, _xAxis);
		foreach (YAxis yAxis in _yAxisList)
		{
			yAxis.Scale.SetupScaleData(this, yAxis);
		}
		foreach (Y2Axis y2Axis in _y2AxisList)
		{
			y2Axis.Scale.SetupScaleData(this, y2Axis);
		}
		return TransformCoord(x, y, coord);
	}

	public void ReverseTransform(PointF ptF, out double x, out double y)
	{
		_xAxis.Scale.SetupScaleData(this, _xAxis);
		YAxis.Scale.SetupScaleData(this, YAxis);
		x = XAxis.Scale.ReverseTransform(ptF.X);
		y = YAxis.Scale.ReverseTransform(ptF.Y);
	}

	public void ReverseTransform(PointF ptF, out double x, out double x2, out double y, out double y2)
	{
		_xAxis.Scale.SetupScaleData(this, _xAxis);
		_x2Axis.Scale.SetupScaleData(this, _x2Axis);
		YAxis.Scale.SetupScaleData(this, YAxis);
		Y2Axis.Scale.SetupScaleData(this, Y2Axis);
		x = XAxis.Scale.ReverseTransform(ptF.X);
		x2 = X2Axis.Scale.ReverseTransform(ptF.X);
		y = YAxis.Scale.ReverseTransform(ptF.Y);
		y2 = Y2Axis.Scale.ReverseTransform(ptF.Y);
	}

	public void ReverseTransform(PointF ptF, bool isX2Axis, bool isY2Axis, int yAxisIndex, out double x, out double y)
	{
		Axis axis = _xAxis;
		if (isX2Axis)
		{
			axis = _x2Axis;
		}
		axis.Scale.SetupScaleData(this, axis);
		x = axis.Scale.ReverseTransform(ptF.X);
		Axis axis2 = null;
		if (isY2Axis && Y2AxisList.Count > yAxisIndex)
		{
			axis2 = Y2AxisList[yAxisIndex];
		}
		else if (!isY2Axis && YAxisList.Count > yAxisIndex)
		{
			axis2 = YAxisList[yAxisIndex];
		}
		if (axis2 != null)
		{
			axis2.Scale.SetupScaleData(this, axis2);
			y = axis2.Scale.ReverseTransform(ptF.Y);
		}
		else
		{
			y = double.MaxValue;
		}
	}

	public void ReverseTransform(PointF ptF, out double x, out double x2, out double[] y, out double[] y2)
	{
		_xAxis.Scale.SetupScaleData(this, _xAxis);
		x = XAxis.Scale.ReverseTransform(ptF.X);
		_x2Axis.Scale.SetupScaleData(this, _x2Axis);
		x2 = X2Axis.Scale.ReverseTransform(ptF.X);
		y = new double[_yAxisList.Count];
		y2 = new double[_y2AxisList.Count];
		for (int i = 0; i < _yAxisList.Count; i++)
		{
			Axis axis = _yAxisList[i];
			axis.Scale.SetupScaleData(this, axis);
			y[i] = axis.Scale.ReverseTransform(ptF.Y);
		}
		for (int j = 0; j < _y2AxisList.Count; j++)
		{
			Axis axis2 = _y2AxisList[j];
			axis2.Scale.SetupScaleData(this, axis2);
			y2[j] = axis2.Scale.ReverseTransform(ptF.Y);
		}
	}

	public int AddYAxis(string title)
	{
		YAxis yAxis = new YAxis(title);
		yAxis.MajorTic.IsOpposite = false;
		yAxis.MinorTic.IsOpposite = false;
		yAxis.MajorTic.IsInside = false;
		yAxis.MinorTic.IsInside = false;
		_yAxisList.Add(yAxis);
		return _yAxisList.Count - 1;
	}

	public int AddY2Axis(string title)
	{
		Y2Axis y2Axis = new Y2Axis(title);
		y2Axis.MajorTic.IsOpposite = false;
		y2Axis.MinorTic.IsOpposite = false;
		y2Axis.MajorTic.IsInside = false;
		y2Axis.MinorTic.IsInside = false;
		_y2AxisList.Add(y2Axis);
		return _y2AxisList.Count - 1;
	}

	public bool FindNearestObject(PointF mousePt, Graphics g, out object nearestObj, out int index)
	{
		nearestObj = null;
		index = -1;
		if (AxisRangesValid())
		{
			float num = CalcScaleFactor();
			GraphObj graphObj = null;
			int num2 = -1;
			ZOrder zOrder = ZOrder.H_BehindAll;
			RectangleF rectangleF = CalcChartRect(g, num);
			if (base.GraphObjList.FindPoint(mousePt, this, g, num, out index))
			{
				graphObj = base.GraphObjList[index];
				num2 = index;
				zOrder = graphObj.ZOrder;
			}
			if (zOrder <= ZOrder.B_BehindLegend && base.Legend.FindPoint(mousePt, this, num, out index))
			{
				nearestObj = base.Legend;
				return true;
			}
			SizeF sizeF = _title._fontSpec.BoundingBox(g, _title._text, num);
			if (zOrder <= ZOrder.H_BehindAll && _title._isVisible && new RectangleF((_rect.Left + _rect.Right - sizeF.Width) / 2f, _rect.Top + _margin.Top * num, sizeF.Width, sizeF.Height).Contains(mousePt))
			{
				nearestObj = this;
				return true;
			}
			float num3 = rectangleF.Left;
			RectangleF rectangleF2;
			for (int i = 0; i < _yAxisList.Count; i++)
			{
				Axis axis = _yAxisList[i];
				float tmpSpace = axis._tmpSpace;
				if (tmpSpace > 0f)
				{
					rectangleF2 = new RectangleF(num3 - tmpSpace, rectangleF.Top, tmpSpace, rectangleF.Height);
					if (zOrder <= ZOrder.D_BehindAxis && rectangleF2.Contains(mousePt))
					{
						nearestObj = axis;
						index = i;
						return true;
					}
					num3 -= tmpSpace;
				}
			}
			num3 = rectangleF.Right;
			for (int j = 0; j < _y2AxisList.Count; j++)
			{
				Axis axis2 = _y2AxisList[j];
				float tmpSpace2 = axis2._tmpSpace;
				if (tmpSpace2 > 0f)
				{
					rectangleF2 = new RectangleF(num3, rectangleF.Top, tmpSpace2, rectangleF.Height);
					if (zOrder <= ZOrder.D_BehindAxis && rectangleF2.Contains(mousePt))
					{
						nearestObj = axis2;
						index = j;
						return true;
					}
					num3 += tmpSpace2;
				}
			}
			float tmpSpace3 = _xAxis._tmpSpace;
			rectangleF2 = new RectangleF(rectangleF.Left, rectangleF.Bottom, rectangleF.Width, tmpSpace3);
			if (zOrder <= ZOrder.D_BehindAxis && rectangleF2.Contains(mousePt))
			{
				nearestObj = XAxis;
				return true;
			}
			tmpSpace3 = _x2Axis._tmpSpace;
			rectangleF2 = new RectangleF(rectangleF.Left, rectangleF.Top - tmpSpace3, rectangleF.Width, tmpSpace3);
			if (zOrder <= ZOrder.D_BehindAxis && rectangleF2.Contains(mousePt))
			{
				nearestObj = X2Axis;
				return true;
			}
			if (zOrder <= ZOrder.E_BehindCurves && FindNearestPoint(mousePt, out var nearestCurve, out index))
			{
				nearestObj = nearestCurve;
				return true;
			}
			if (graphObj != null)
			{
				index = num2;
				nearestObj = graphObj;
				return true;
			}
		}
		return false;
	}

	public bool FindNearestPoint(PointF mousePt, CurveItem targetCurve, out CurveItem nearestCurve, out int iNearest)
	{
		CurveList curveList = new CurveList();
		curveList.Add(targetCurve);
		return FindNearestPoint(mousePt, curveList, out nearestCurve, out iNearest);
	}

	public bool FindNearestPoint(PointF mousePt, out CurveItem nearestCurve, out int iNearest)
	{
		return FindNearestPoint(mousePt, _curveList, out nearestCurve, out iNearest);
	}

	public bool FindNearestPoint(PointF mousePt, CurveList targetCurveList, out CurveItem nearestCurve, out int iNearest)
	{
		CurveItem curveItem = null;
		int num = -1;
		nearestCurve = null;
		iNearest = -1;
		if (!_chart._rect.Contains(mousePt))
		{
			return false;
		}
		ReverseTransform(mousePt, out double x, out double x2, out double[] y, out double[] y2);
		if (!AxisRangesValid())
		{
			return false;
		}
		ValueHandler valueHandler = new ValueHandler(this, initialize: false);
		double num2 = 1E+20;
		double num3 = 99999.0;
		double num4 = Default.NearestTol * Default.NearestTol;
		int num5 = 0;
		foreach (CurveItem targetCurve in targetCurveList)
		{
			if (targetCurve is PieItem && targetCurve.IsVisible)
			{
				if (((PieItem)targetCurve).SlicePath != null && ((PieItem)targetCurve).SlicePath.IsVisible(mousePt))
				{
					curveItem = targetCurve;
					num = 0;
				}
			}
			else
			{
				if (!targetCurve.IsVisible)
				{
					continue;
				}
				int yAxisIndex = targetCurve.GetYAxisIndex(this);
				Axis yAxis = targetCurve.GetYAxis(this);
				Axis xAxis = targetCurve.GetXAxis(this);
				double num6;
				double min;
				double max;
				if (targetCurve.IsY2Axis)
				{
					num6 = y2[yAxisIndex];
					min = _y2AxisList[yAxisIndex]._scale._min;
					max = _y2AxisList[yAxisIndex]._scale._max;
				}
				else
				{
					num6 = y[yAxisIndex];
					min = _yAxisList[yAxisIndex]._scale._min;
					max = _yAxisList[yAxisIndex]._scale._max;
				}
				double num7 = (double)_chart._rect.Height / (max - min);
				double num8 = (double)_chart._rect.Width / (xAxis._scale._max - xAxis._scale._min);
				double num9 = ((xAxis is XAxis) ? x : x2);
				IPointList points = targetCurve.Points;
				float barWidth = targetCurve.GetBarWidth(this);
				Axis axis = targetCurve.BaseAxis(this);
				bool flag = axis is XAxis || axis is X2Axis;
				double num10 = ((!flag) ? ((double)barWidth / num7 / 2.0) : ((double)barWidth / num8 / 2.0));
				if (points == null)
				{
					continue;
				}
				for (int i = 0; i < targetCurve.NPts; i++)
				{
					double baseVal = ((!xAxis._scale.IsAnyOrdinal || targetCurve.IsOverrideOrdinal) ? points[i].X : ((double)i + 1.0));
					double hiVal = ((!yAxis._scale.IsAnyOrdinal || targetCurve.IsOverrideOrdinal) ? points[i].Y : ((double)i + 1.0));
					if (baseVal == double.MaxValue || hiVal == double.MaxValue)
					{
						continue;
					}
					if (targetCurve.IsBar || targetCurve is ErrorBarItem || targetCurve is HiLowBarItem || targetCurve is OHLCBarItem || targetCurve is JapaneseCandleStickItem)
					{
						valueHandler.GetValues(targetCurve, i, out var _, out var lowVal, out var hiVal2);
						if (lowVal > hiVal2)
						{
							double num11 = lowVal;
							lowVal = hiVal2;
							hiVal2 = num11;
						}
						if (flag)
						{
							double num12 = valueHandler.BarCenterValue(targetCurve, barWidth, i, baseVal, num5);
							if (num9 < num12 - num10 || num9 > num12 + num10 || num6 < lowVal || num6 > hiVal2)
							{
								continue;
							}
						}
						else
						{
							double num13 = valueHandler.BarCenterValue(targetCurve, barWidth, i, hiVal, num5);
							if (num6 < num13 - num10 || num6 > num13 + num10 || num9 < lowVal || num9 > hiVal2)
							{
								continue;
							}
						}
						if (curveItem == null)
						{
							num = i;
							curveItem = targetCurve;
						}
					}
					else if (baseVal >= xAxis._scale._min && baseVal <= xAxis._scale._max && hiVal >= min && hiVal <= max)
					{
						if (targetCurve is LineItem && _lineType == LineType.Stack)
						{
							valueHandler.GetValues(targetCurve, i, out baseVal, out var _, out hiVal);
						}
						double num14 = (baseVal - num9) * num8;
						double num15 = (hiVal - num6) * num7;
						num3 = num14 * num14 + num15 * num15;
						if (!(num3 >= num2))
						{
							num2 = num3;
							iNearest = i;
							nearestCurve = targetCurve;
						}
					}
				}
				if (targetCurve.IsBar)
				{
					num5++;
				}
			}
		}
		if (nearestCurve is LineItem)
		{
			float num16 = ((LineItem)nearestCurve).Symbol.Size * CalcScaleFactor() / 2f;
			num2 -= (double)(num16 * num16);
			if (num2 < 0.0)
			{
				num2 = 0.0;
			}
		}
		if (num2 >= num4 && curveItem != null)
		{
			nearestCurve = curveItem;
			iNearest = num;
			return true;
		}
		if (num2 < num4)
		{
			return true;
		}
		return false;
	}

	public bool FindLinkableObject(PointF mousePt, Graphics g, float scaleFactor, out object source, out Link link, out int index)
	{
		index = -1;
		foreach (GraphObj graphObj in _graphObjList)
		{
			link = graphObj._link;
			_ = graphObj.IsInFrontOfData;
			if (link.IsActive && graphObj.PointInBox(mousePt, this, g, scaleFactor))
			{
				source = graphObj;
				return true;
			}
		}
		foreach (CurveItem curve in _curveList)
		{
			link = curve._link;
			if (link.IsActive && FindNearestPoint(mousePt, curve, out var _, out index))
			{
				source = curve;
				return true;
			}
		}
		foreach (GraphObj graphObj2 in _graphObjList)
		{
			link = graphObj2._link;
			_ = graphObj2.IsInFrontOfData;
			if (link.IsActive && graphObj2.PointInBox(mousePt, this, g, scaleFactor))
			{
				source = graphObj2;
				return true;
			}
		}
		source = null;
		link = null;
		index = -1;
		return false;
	}

	public bool FindContainedObjects(RectangleF rectF, Graphics g, out CurveList containedObjs)
	{
		containedObjs = new CurveList();
		foreach (CurveItem curve in CurveList)
		{
			for (int i = 0; i < curve.Points.Count; i++)
			{
				if (curve.Points[i].X > (double)rectF.Left && curve.Points[i].X < (double)rectF.Right && curve.Points[i].Y > (double)rectF.Bottom && curve.Points[i].Y < (double)rectF.Top)
				{
					containedObjs.Add(curve);
				}
			}
		}
		return containedObjs.Count > 0;
	}
}
