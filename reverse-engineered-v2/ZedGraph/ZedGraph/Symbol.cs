using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Symbol : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float Size = 7f;

		public static float PenWidth = 1f;

		public static Color FillColor = Color.Red;

		public static Brush FillBrush = null;

		public static FillType FillType = FillType.None;

		public static SymbolType Type = SymbolType.Square;

		public static bool IsAntiAlias = false;

		public static bool IsVisible = true;

		public static bool IsBorderVisible = true;

		public static Color BorderColor = Color.Red;
	}

	public const int schema = 11;

	private float _size;

	private SymbolType _type;

	private bool _isAntiAlias;

	private bool _isVisible;

	private Fill _fill;

	private Border _border;

	private GraphicsPath _userSymbol;

	public float Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
		}
	}

	public SymbolType Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	public bool IsAntiAlias
	{
		get
		{
			return _isAntiAlias;
		}
		set
		{
			_isAntiAlias = value;
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

	public GraphicsPath UserSymbol
	{
		get
		{
			return _userSymbol;
		}
		set
		{
			_userSymbol = value;
		}
	}

	public Symbol()
		: this(SymbolType.Default, Color.Empty)
	{
	}

	public Symbol(SymbolType type, Color color)
	{
		_size = Default.Size;
		_type = type;
		_isAntiAlias = Default.IsAntiAlias;
		_isVisible = Default.IsVisible;
		_border = new Border(Default.IsBorderVisible, color, Default.PenWidth);
		_fill = new Fill(color, Default.FillBrush, Default.FillType);
		_userSymbol = null;
	}

	public Symbol(Symbol rhs)
	{
		_size = rhs.Size;
		_type = rhs.Type;
		_isAntiAlias = rhs._isAntiAlias;
		_isVisible = rhs.IsVisible;
		_fill = rhs.Fill.Clone();
		_border = rhs.Border.Clone();
		if (rhs.UserSymbol != null)
		{
			_userSymbol = rhs.UserSymbol.Clone() as GraphicsPath;
		}
		else
		{
			_userSymbol = null;
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Symbol Clone()
	{
		return new Symbol(this);
	}

	protected Symbol(SerializationInfo info, StreamingContext context)
	{
		int @int = info.GetInt32("schema");
		_size = info.GetSingle("size");
		_type = (SymbolType)info.GetValue("type", typeof(SymbolType));
		_isAntiAlias = info.GetBoolean("isAntiAlias");
		_isVisible = info.GetBoolean("isVisible");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		if (@int >= 11)
		{
			_userSymbol = (GraphicsPath)info.GetValue("userSymbol", typeof(GraphicsPath));
		}
		else
		{
			_userSymbol = null;
		}
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 11);
		info.AddValue("size", _size);
		info.AddValue("type", _type);
		info.AddValue("isAntiAlias", _isAntiAlias);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("userSymbol", _userSymbol);
	}

	private void DrawSymbol(Graphics g, int x, int y, GraphicsPath path, Pen pen, Brush brush)
	{
		if (_isVisible && Type != SymbolType.None && x < 100000 && x > -100000 && y < 100000 && y > -100000)
		{
			Matrix transform = g.Transform;
			g.TranslateTransform(x, y);
			if (_fill.IsVisible)
			{
				g.FillPath(brush, path);
			}
			if (_border.IsVisible)
			{
				g.DrawPath(pen, path);
			}
			g.Transform = transform;
		}
	}

	public void DrawSymbol(Graphics g, GraphPane pane, int x, int y, float scaleFactor, bool isSelected, PointPair dataValue)
	{
		if (isSelected)
		{
			_ = Selection.Symbol;
		}
		if (!_isVisible || Type == SymbolType.None || x >= 100000 || x <= -100000 || y >= 100000 || y <= -100000)
		{
			return;
		}
		SmoothingMode smoothingMode = g.SmoothingMode;
		if (_isAntiAlias)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
		}
		using (Pen pen = _border.GetPen(pane, scaleFactor, dataValue))
		{
			using GraphicsPath graphicsPath = MakePath(g, scaleFactor);
			using Brush brush = Fill.MakeBrush(graphicsPath.GetBounds(), dataValue);
			DrawSymbol(g, x, y, graphicsPath, pen, brush);
		}
		g.SmoothingMode = smoothingMode;
	}

	public GraphicsPath MakePath(Graphics g, float scaleFactor)
	{
		float num = _size * scaleFactor;
		float num2 = num / 2f;
		float num3 = num2 + 1f;
		GraphicsPath graphicsPath = new GraphicsPath();
		switch ((_type == SymbolType.Default || (_type == SymbolType.UserDefined && _userSymbol == null)) ? Default.Type : _type)
		{
		case SymbolType.Square:
			graphicsPath.AddLine(0f - num2, 0f - num2, num2, 0f - num2);
			graphicsPath.AddLine(num2, 0f - num2, num2, num2);
			graphicsPath.AddLine(num2, num2, 0f - num2, num2);
			graphicsPath.AddLine(0f - num2, num2, 0f - num2, 0f - num2);
			break;
		case SymbolType.Diamond:
			graphicsPath.AddLine(0f, 0f - num2, num2, 0f);
			graphicsPath.AddLine(num2, 0f, 0f, num2);
			graphicsPath.AddLine(0f, num2, 0f - num2, 0f);
			graphicsPath.AddLine(0f - num2, 0f, 0f, 0f - num2);
			break;
		case SymbolType.Triangle:
			graphicsPath.AddLine(0f, 0f - num2, num2, num2);
			graphicsPath.AddLine(num2, num2, 0f - num2, num2);
			graphicsPath.AddLine(0f - num2, num2, 0f, 0f - num2);
			break;
		case SymbolType.Circle:
			graphicsPath.AddEllipse(0f - num2, 0f - num2, num, num);
			break;
		case SymbolType.XCross:
			graphicsPath.AddLine(0f - num2, 0f - num2, num3, num3);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(num2, 0f - num2, 0f - num3, num3);
			break;
		case SymbolType.Plus:
			graphicsPath.AddLine(0f, 0f - num2, 0f, num3);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(0f - num2, 0f, num3, 0f);
			break;
		case SymbolType.Star:
			graphicsPath.AddLine(0f, 0f - num2, 0f, num3);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(0f - num2, 0f, num3, 0f);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(0f - num2, 0f - num2, num3, num3);
			graphicsPath.StartFigure();
			graphicsPath.AddLine(num2, 0f - num2, 0f - num3, num3);
			break;
		case SymbolType.TriangleDown:
			graphicsPath.AddLine(0f, num2, num2, 0f - num2);
			graphicsPath.AddLine(num2, 0f - num2, 0f - num2, 0f - num2);
			graphicsPath.AddLine(0f - num2, 0f - num2, 0f, num2);
			break;
		case SymbolType.HDash:
			graphicsPath.AddLine(0f - num2, 0f, num3, 0f);
			break;
		case SymbolType.VDash:
			graphicsPath.AddLine(0f, 0f - num2, 0f, num3);
			break;
		case SymbolType.UserDefined:
		{
			graphicsPath = _userSymbol.Clone() as GraphicsPath;
			Matrix matrix = new Matrix(num, 0f, 0f, num, 0f, 0f);
			graphicsPath.Transform(matrix);
			break;
		}
		}
		return graphicsPath;
	}

	public void Draw(Graphics g, GraphPane pane, LineItem curve, float scaleFactor, bool isSelected)
	{
		Symbol symbol = this;
		if (isSelected)
		{
			symbol = Selection.Symbol;
		}
		int num = (int)pane.Chart.Rect.Left;
		int num2 = (int)pane.Chart.Rect.Right;
		int num3 = (int)pane.Chart.Rect.Top;
		int num4 = (int)pane.Chart.Rect.Bottom;
		bool[,] array = new bool[num2 + 1, num4 + 1];
		IPointList points = curve.Points;
		if (points == null || (!_border.IsVisible && !_fill.IsVisible))
		{
			return;
		}
		SmoothingMode smoothingMode = g.SmoothingMode;
		if (_isAntiAlias)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
		}
		using (Pen pen = symbol._border.GetPen(pane, scaleFactor))
		{
			using GraphicsPath graphicsPath = MakePath(g, scaleFactor);
			RectangleF bounds = graphicsPath.GetBounds();
			using Brush brush = symbol.Fill.MakeBrush(bounds);
			ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
			Scale scale = curve.GetXAxis(pane).Scale;
			Scale scale2 = curve.GetYAxis(pane).Scale;
			bool isLog = scale.IsLog;
			bool isLog2 = scale2.IsLog;
			bool isAnyOrdinal = scale.IsAnyOrdinal;
			double min = scale.Min;
			double max = scale.Max;
			for (int i = 0; i < points.Count; i++)
			{
				double baseVal;
				double hiVal;
				if (pane.LineType == LineType.Stack)
				{
					valueHandler.GetValues(curve, i, out baseVal, out var _, out hiVal);
				}
				else
				{
					baseVal = points[i].X;
					hiVal = ((!(curve is StickItem)) ? points[i].Y : points[i].Z);
				}
				if (baseVal == double.MaxValue || hiVal == double.MaxValue || double.IsNaN(baseVal) || double.IsNaN(hiVal) || double.IsInfinity(baseVal) || double.IsInfinity(hiVal) || (!(baseVal > 0.0) && isLog) || (isLog2 && !(hiVal > 0.0)) || (!isAnyOrdinal && (!(baseVal >= min) || !(baseVal <= max))))
				{
					continue;
				}
				int num5 = (int)scale.Transform(curve.IsOverrideOrdinal, i, baseVal);
				int num6 = (int)scale2.Transform(curve.IsOverrideOrdinal, i, hiVal);
				if (num5 >= num && num5 <= num2 && num6 >= num3 && num6 <= num4)
				{
					if (array[num5, num6])
					{
						continue;
					}
					array[num5, num6] = true;
				}
				if (_fill.IsGradientValueType || _border._gradientFill.IsGradientValueType)
				{
					using Brush brush2 = _fill.MakeBrush(bounds, points[i]);
					using Pen pen2 = _border.GetPen(pane, scaleFactor, points[i]);
					DrawSymbol(g, num5, num6, graphicsPath, pen2, brush2);
				}
				else
				{
					DrawSymbol(g, num5, num6, graphicsPath, pen, brush);
				}
			}
		}
		g.SmoothingMode = smoothingMode;
	}
}
