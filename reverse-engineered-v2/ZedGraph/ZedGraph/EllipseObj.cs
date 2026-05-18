using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class EllipseObj : BoxObj, ICloneable, ISerializable
{
	public const int schema3 = 10;

	public EllipseObj(double x, double y, double width, double height)
		: base(x, y, width, height)
	{
	}

	public EllipseObj()
	{
	}

	public EllipseObj(double x, double y, double width, double height, Color borderColor, Color fillColor)
		: base(x, y, width, height, borderColor, fillColor)
	{
	}

	public EllipseObj(double x, double y, double width, double height, Color borderColor, Color fillColor1, Color fillColor2)
		: base(x, y, width, height, borderColor, fillColor1, fillColor2)
	{
	}

	public EllipseObj(BoxObj rhs)
		: base(rhs)
	{
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new EllipseObj Clone()
	{
		return new EllipseObj(this);
	}

	protected EllipseObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema3", 10);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		RectangleF rect = base.Location.TransformRect(pane);
		if (!(Math.Abs(rect.Left) < 100000f) || !(Math.Abs(rect.Top) < 100000f) || !(Math.Abs(rect.Right) < 100000f) || !(Math.Abs(rect.Bottom) < 100000f))
		{
			return;
		}
		if (_fill.IsVisible)
		{
			using Brush brush = _fill.MakeBrush(rect);
			g.FillEllipse(brush, rect);
		}
		if (_border.IsVisible)
		{
			using (Pen pen = _border.GetPen(pane, scaleFactor))
			{
				g.DrawEllipse(pen, rect);
			}
		}
	}

	public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (!base.PointInBox(pt, pane, g, scaleFactor))
		{
			return false;
		}
		RectangleF rect = _location.TransformRect(pane);
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddEllipse(rect);
		return graphicsPath.IsVisible(pt);
	}
}
