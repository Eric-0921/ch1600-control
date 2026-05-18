using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class BoxObj : GraphObj, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static float PenWidth = 1f;

		public static Color BorderColor = Color.Black;

		public static Color FillColor = Color.White;
	}

	public const int schema2 = 10;

	protected Fill _fill;

	protected Border _border;

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

	public BoxObj(double x, double y, double width, double height, Color borderColor, Color fillColor)
		: base(x, y, width, height)
	{
		Border = new Border(borderColor, Default.PenWidth);
		Fill = new Fill(fillColor);
	}

	public BoxObj(double x, double y, double width, double height)
		: base(x, y, width, height)
	{
		Border = new Border(Default.BorderColor, Default.PenWidth);
		Fill = new Fill(Default.FillColor);
	}

	public BoxObj()
		: this(0.0, 0.0, 1.0, 1.0)
	{
	}

	public BoxObj(double x, double y, double width, double height, Color borderColor, Color fillColor1, Color fillColor2)
		: base(x, y, width, height)
	{
		Border = new Border(borderColor, Default.PenWidth);
		Fill = new Fill(fillColor1, fillColor2);
	}

	public BoxObj(BoxObj rhs)
		: base(rhs)
	{
		Border = rhs.Border.Clone();
		Fill = rhs.Fill.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public BoxObj Clone()
	{
		return new BoxObj(this);
	}

	protected BoxObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		RectangleF rect = base.Location.TransformRect(pane);
		RectangleF rect2 = pane.Rect;
		rect2.Inflate(20f, 20f);
		rect.Intersect(rect2);
		if (Math.Abs(rect.Left) < 100000f && Math.Abs(rect.Top) < 100000f && Math.Abs(rect.Right) < 100000f && Math.Abs(rect.Bottom) < 100000f)
		{
			_fill.Draw(g, rect);
			_border.Draw(g, pane, scaleFactor, rect);
		}
	}

	public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (!base.PointInBox(pt, pane, g, scaleFactor))
		{
			return false;
		}
		return _location.TransformRect(pane).Contains(pt);
	}

	public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
	{
		RectangleF rectangleF = _location.TransformRect(pane);
		shape = "rect";
		coords = $"{rectangleF.Left:f0},{rectangleF.Top:f0},{rectangleF.Right:f0},{rectangleF.Bottom:f0}";
	}
}
