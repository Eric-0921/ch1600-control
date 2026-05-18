using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class ErrorBar : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float Size = 7f;

		public static float PenWidth = 1f;

		public static bool IsVisible = true;

		public static Color Color = Color.Red;

		public static SymbolType Type = SymbolType.HDash;
	}

	public const int schema = 10;

	private bool _isVisible;

	private Color _color;

	private float _penWidth;

	private Symbol _symbol;

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

	public float PenWidth
	{
		get
		{
			return _penWidth;
		}
		set
		{
			_penWidth = value;
		}
	}

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

	public ErrorBar()
		: this(Default.Color)
	{
	}

	public ErrorBar(Color color)
	{
		_symbol = new Symbol(Default.Type, color);
		_symbol.Size = Default.Size;
		_color = color;
		_penWidth = Default.PenWidth;
		_isVisible = Default.IsVisible;
	}

	public ErrorBar(ErrorBar rhs)
	{
		_color = rhs.Color;
		_isVisible = rhs.IsVisible;
		_penWidth = rhs.PenWidth;
		_symbol = rhs.Symbol.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ErrorBar Clone()
	{
		return new ErrorBar(this);
	}

	protected ErrorBar(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_isVisible = info.GetBoolean("isVisible");
		_color = (Color)info.GetValue("color", typeof(Color));
		_penWidth = info.GetSingle("penWidth");
		_symbol = (Symbol)info.GetValue("symbol", typeof(Symbol));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("color", _color);
		info.AddValue("penWidth", _penWidth);
		info.AddValue("symbol", _symbol);
	}

	public void Draw(Graphics g, GraphPane pane, bool isXBase, float pixBase, float pixValue, float pixLowValue, float scaleFactor, Pen pen, bool isSelected, PointPair dataValue)
	{
		if (isXBase)
		{
			g.DrawLine(pen, pixBase, pixValue, pixBase, pixLowValue);
			_symbol.DrawSymbol(g, pane, (int)pixBase, (int)pixValue, scaleFactor, isSelected, dataValue);
			_symbol.DrawSymbol(g, pane, (int)pixBase, (int)pixLowValue, scaleFactor, isSelected, dataValue);
		}
		else
		{
			g.DrawLine(pen, pixValue, pixBase, pixLowValue, pixBase);
			_symbol.DrawSymbol(g, pane, (int)pixValue, (int)pixBase, scaleFactor, isSelected, dataValue);
			_symbol.DrawSymbol(g, pane, (int)pixLowValue, (int)pixBase, scaleFactor, isSelected, dataValue);
		}
	}

	public void Draw(Graphics g, GraphPane pane, ErrorBarItem curve, Axis baseAxis, Axis valueAxis, float scaleFactor)
	{
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		if (curve.Points == null || !IsVisible)
		{
			return;
		}
		using Pen pen = ((!curve.IsSelected) ? new Pen(_color, _penWidth) : new Pen(Selection.Border.Color, Selection.Border.Width));
		for (int i = 0; i < curve.Points.Count; i++)
		{
			valueHandler.GetValues(curve, i, out var baseVal, out var lowVal, out var hiVal);
			if (!curve.Points[i].IsInvalid3D && (baseVal > 0.0 || !baseAxis._scale.IsLog) && ((hiVal > 0.0 && lowVal > 0.0) || !valueAxis._scale.IsLog))
			{
				float pixBase = baseAxis.Scale.Transform(curve.IsOverrideOrdinal, i, baseVal);
				float pixValue = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, hiVal);
				float pixLowValue = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, lowVal);
				Draw(g, pane, baseAxis is XAxis || baseAxis is X2Axis, pixBase, pixValue, pixLowValue, scaleFactor, pen, curve.IsSelected, curve.Points[i]);
			}
		}
	}
}
