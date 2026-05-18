using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class LineItem : CurveItem, ICloneable, ISerializable
{
	public const int schema2 = 10;

	protected Symbol _symbol;

	protected Line _line;

	public Symbol Symbol
	{
		get
		{
			return _symbol;
		}
		set
		{
			_symbol = value;
		}
	}

	public Line Line
	{
		get
		{
			return _line;
		}
		set
		{
			_line = value;
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

	public LineItem(string label)
		: base(label)
	{
		_symbol = new Symbol();
		_line = new Line();
	}

	public LineItem(string label, double[] x, double[] y, Color color, SymbolType symbolType, float lineWidth)
		: this(label, new PointPairList(x, y), color, symbolType, lineWidth)
	{
	}

	public LineItem(string label, double[] x, double[] y, Color color, SymbolType symbolType)
		: this(label, new PointPairList(x, y), color, symbolType)
	{
	}

	public LineItem(string label, IPointList points, Color color, SymbolType symbolType, float lineWidth)
		: base(label, points)
	{
		_line = new Line(color);
		if (lineWidth == 0f)
		{
			_line.IsVisible = false;
		}
		else
		{
			_line.Width = lineWidth;
		}
		_symbol = new Symbol(symbolType, color);
	}

	public LineItem(string label, IPointList points, Color color, SymbolType symbolType)
		: this(label, points, color, symbolType, LineBase.Default.Width)
	{
	}

	public LineItem(LineItem rhs)
		: base(rhs)
	{
		_symbol = new Symbol(rhs.Symbol);
		_line = new Line(rhs.Line);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public LineItem Clone()
	{
		return new LineItem(this);
	}

	protected LineItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_symbol = (Symbol)info.GetValue("symbol", typeof(Symbol));
		_line = (Line)info.GetValue("line", typeof(Line));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("symbol", _symbol);
		info.AddValue("line", _line);
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (_isVisible)
		{
			Line.Draw(g, pane, this, scaleFactor);
			Symbol.Draw(g, pane, this, scaleFactor, base.IsSelected);
		}
	}

	public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		int x = (int)(rect.Left + rect.Width / 2f);
		int num = (int)(rect.Top + rect.Height / 2f);
		_line.Fill.Draw(g, rect);
		_line.DrawSegment(g, pane, rect.Left, num, rect.Right, num, scaleFactor);
		_symbol.DrawSymbol(g, pane, x, num, scaleFactor, isSelected: false, null);
	}

	public override void MakeUnique(ColorSymbolRotator rotator)
	{
		base.Color = rotator.NextColor;
		Symbol.Type = rotator.NextSymbol;
	}

	public override bool GetCoords(GraphPane pane, int i, out string coords)
	{
		coords = string.Empty;
		if (i < 0 || i >= _points.Count)
		{
			return false;
		}
		PointPair pointPair = _points[i];
		if (pointPair.IsInvalid)
		{
			return false;
		}
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		valueHandler.GetValues(this, i, out var baseVal, out var _, out var hiVal);
		Axis yAxis = GetYAxis(pane);
		Axis xAxis = GetXAxis(pane);
		PointF pt = new PointF(xAxis.Scale.Transform(_isOverrideOrdinal, i, baseVal), yAxis.Scale.Transform(_isOverrideOrdinal, i, hiVal));
		if (!pane.Chart.Rect.Contains(pt))
		{
			return false;
		}
		float num = _symbol.Size * pane.CalcScaleFactor();
		coords = $"{pt.X - num:f0},{pt.Y - num:f0},{pt.X + num:f0},{pt.Y + num:f0}";
		return true;
	}
}
