using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Bar : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float BorderWidth = 1f;

		public static FillType FillType = FillType.Brush;

		public static bool IsBorderVisible = true;

		public static Color BorderColor = Color.Black;

		public static Color FillColor = Color.Red;

		public static Brush FillBrush = null;
	}

	public const int schema = 10;

	private Fill _fill;

	private Border _border;

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

	public Bar()
		: this(Color.Empty)
	{
	}

	public Bar(Color color)
	{
		_border = new Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderWidth);
		_fill = new Fill(color.IsEmpty ? Default.FillColor : color, Default.FillBrush, Default.FillType);
	}

	public Bar(Bar rhs)
	{
		_border = rhs.Border.Clone();
		_fill = rhs.Fill.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Bar Clone()
	{
		return new Bar(this);
	}

	protected Bar(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
	}

	public void Draw(Graphics g, GraphPane pane, float left, float right, float top, float bottom, float scaleFactor, bool fullFrame, bool isSelected, PointPair dataValue)
	{
		if (top > bottom)
		{
			float num = top;
			top = bottom;
			bottom = num;
		}
		if (left > right)
		{
			float num2 = right;
			right = left;
			left = num2;
		}
		if (top < -10000f)
		{
			top = -10000f;
		}
		else if (top > 10000f)
		{
			top = 10000f;
		}
		if (left < -10000f)
		{
			left = -10000f;
		}
		else if (left > 10000f)
		{
			left = 10000f;
		}
		if (right < -10000f)
		{
			right = -10000f;
		}
		else if (right > 10000f)
		{
			right = 10000f;
		}
		if (bottom < -10000f)
		{
			bottom = -10000f;
		}
		else if (bottom > 10000f)
		{
			bottom = 10000f;
		}
		RectangleF rect = new RectangleF(left, top, right - left, bottom - top);
		Draw(g, pane, rect, scaleFactor, fullFrame, isSelected, dataValue);
	}

	public void Draw(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor, bool fullFrame, bool isSelected, PointPair dataValue)
	{
		if (isSelected)
		{
			Selection.Fill.Draw(g, rect, dataValue);
			Selection.Border.Draw(g, pane, scaleFactor, rect);
		}
		else
		{
			_fill.Draw(g, rect, dataValue);
			_border.Draw(g, pane, scaleFactor, rect);
		}
	}

	public void DrawBars(Graphics g, GraphPane pane, CurveItem curve, Axis baseAxis, Axis valueAxis, float barWidth, int pos, float scaleFactor)
	{
		BarType type = pane._barSettings.Type;
		if (type == BarType.Overlay || type == BarType.Stack || type == BarType.PercentStack || type == BarType.SortedOverlay)
		{
			pos = 0;
		}
		for (int i = 0; i < curve.Points.Count; i++)
		{
			DrawSingleBar(g, pane, curve, i, pos, baseAxis, valueAxis, barWidth, scaleFactor);
		}
	}

	public void DrawSingleBar(Graphics g, GraphPane pane, CurveItem curve, Axis baseAxis, Axis valueAxis, int pos, int index, float barWidth, float scaleFactor)
	{
		if (index < curve.Points.Count)
		{
			if (pane._barSettings.Type == BarType.Overlay || pane._barSettings.Type == BarType.Stack || pane._barSettings.Type == BarType.PercentStack)
			{
				pos = 0;
			}
			DrawSingleBar(g, pane, curve, index, pos, baseAxis, valueAxis, barWidth, scaleFactor);
		}
	}

	protected virtual void DrawSingleBar(Graphics g, GraphPane pane, CurveItem curve, int index, int pos, Axis baseAxis, Axis valueAxis, float barWidth, float scaleFactor)
	{
		float clusterWidth = pane.BarSettings.GetClusterWidth();
		float num = pane._barSettings.MinClusterGap * barWidth;
		float num2 = barWidth * pane._barSettings.MinBarGap;
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		valueHandler.GetValues(curve, index, out var baseVal, out var lowVal, out var hiVal);
		if (!curve.Points[index].IsInvalid)
		{
			float num3 = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, index, lowVal);
			float num4 = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, index, hiVal);
			float num5 = baseAxis.Scale.Transform(curve.IsOverrideOrdinal, index, baseVal);
			float num6 = num5 - clusterWidth / 2f + num / 2f + (float)pos * (barWidth + num2);
			if (pane._barSettings.Base == BarBase.X)
			{
				Draw(g, pane, num6, num6 + barWidth, num3, num4, scaleFactor, fullFrame: true, curve.IsSelected, curve.Points[index]);
			}
			else
			{
				Draw(g, pane, num3, num4, num6, num6 + barWidth, scaleFactor, fullFrame: true, curve.IsSelected, curve.Points[index]);
			}
		}
	}
}
