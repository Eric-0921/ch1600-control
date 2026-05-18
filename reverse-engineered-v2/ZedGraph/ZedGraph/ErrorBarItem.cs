using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class ErrorBarItem : CurveItem, ICloneable, ISerializable
{
	public const int schema2 = 10;

	private ErrorBar _bar;

	public ErrorBar Bar => _bar;

	internal override bool IsZIncluded(GraphPane pane)
	{
		return true;
	}

	internal override bool IsXIndependent(GraphPane pane)
	{
		return pane._barSettings.Base == BarBase.X;
	}

	public ErrorBarItem(string label)
		: base(label)
	{
		_bar = new ErrorBar();
	}

	public ErrorBarItem(string label, double[] x, double[] y, double[] lowValue, Color color)
		: this(label, new PointPairList(x, y, lowValue), color)
	{
	}

	public ErrorBarItem(string label, IPointList points, Color color)
		: base(label, points)
	{
		_bar = new ErrorBar(color);
	}

	public ErrorBarItem(ErrorBarItem rhs)
		: base(rhs)
	{
		_bar = new ErrorBar(rhs.Bar);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ErrorBarItem Clone()
	{
		return new ErrorBarItem(this);
	}

	protected ErrorBarItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_bar = (ErrorBar)info.GetValue("bar", typeof(ErrorBar));
		_ = (BarBase)info.GetValue("barBase", typeof(BarBase));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("bar", _bar);
		info.AddValue("barBase", BarBase.X);
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (_isVisible)
		{
			_bar.Draw(g, pane, this, BaseAxis(pane), ValueAxis(pane), scaleFactor);
		}
	}

	public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		float pixBase;
		float pixValue;
		float pixLowValue;
		if (pane._barSettings.Base == BarBase.X)
		{
			pixBase = rect.Left + rect.Width / 2f;
			pixValue = rect.Top;
			pixLowValue = rect.Bottom;
		}
		else
		{
			pixBase = rect.Top + rect.Height / 2f;
			pixValue = rect.Right;
			pixLowValue = rect.Left;
		}
		using Pen pen = new Pen(_bar.Color, _bar.PenWidth);
		Bar.Draw(g, pane, pane._barSettings.Base == BarBase.X, pixBase, pixValue, pixLowValue, scaleFactor, pen, isSelected: false, null);
	}

	public override bool GetCoords(GraphPane pane, int i, out string coords)
	{
		coords = string.Empty;
		if (i < 0 || i >= _points.Count)
		{
			return false;
		}
		Axis axis = ValueAxis(pane);
		Axis axis2 = BaseAxis(pane);
		float num = _bar.Symbol.Size * pane.CalcScaleFactor();
		pane.BarSettings.GetClusterWidth();
		float barWidth = GetBarWidth(pane);
		_ = pane._barSettings.MinClusterGap;
		_ = pane._barSettings.MinBarGap;
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		valueHandler.GetValues(this, i, out var baseVal, out var lowVal, out var hiVal);
		if (!_points[i].IsInvalid3D)
		{
			float num2 = axis.Scale.Transform(_isOverrideOrdinal, i, lowVal);
			float num3 = axis.Scale.Transform(_isOverrideOrdinal, i, hiVal);
			float num4 = axis2.Scale.Transform(_isOverrideOrdinal, i, baseVal);
			float num5 = num4 - num / 2f;
			if (axis2 is XAxis || axis2 is X2Axis)
			{
				coords = $"{num5:f0},{num2:f0},{num5 + num:f0},{num3:f0}";
			}
			else
			{
				coords = $"{num2:f0},{num5:f0},{num3:f0},{num5 + num:f0}";
			}
			return true;
		}
		return false;
	}
}
