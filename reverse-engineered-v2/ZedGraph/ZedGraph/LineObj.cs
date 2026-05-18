using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class LineObj : GraphObj, ICloneable, ISerializable
{
	public const int schema2 = 11;

	protected LineBase _line;

	public LineBase Line
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

	public LineObj(Color color, double x1, double y1, double x2, double y2)
		: base(x1, y1, x2 - x1, y2 - y1)
	{
		_line = new LineBase(color);
		base.Location.AlignH = AlignH.Left;
		base.Location.AlignV = AlignV.Top;
	}

	public LineObj(double x1, double y1, double x2, double y2)
		: this(LineBase.Default.Color, x1, y1, x2, y2)
	{
	}

	public LineObj()
		: this(LineBase.Default.Color, 0.0, 0.0, 1.0, 1.0)
	{
	}

	public LineObj(LineObj rhs)
		: base(rhs)
	{
		_line = new LineBase(rhs._line);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public LineObj Clone()
	{
		return new LineObj(this);
	}

	protected LineObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_line = (LineBase)info.GetValue("line", typeof(LineBase));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
		info.AddValue("line", _line);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		PointF pointF = base.Location.TransformTopLeft(pane);
		PointF pointF2 = base.Location.TransformBottomRight(pane);
		if (pointF.X > -10000f && pointF.X < 100000f && pointF.Y > -100000f && pointF.Y < 100000f && pointF2.X > -10000f && pointF2.X < 100000f && pointF2.Y > -100000f && pointF2.Y < 100000f)
		{
			double num = pointF2.Y - pointF.Y;
			double num2 = pointF2.X - pointF.X;
			float angle = (float)Math.Atan2(num, num2) * 180f / (float)Math.PI;
			float x = (float)Math.Sqrt(num2 * num2 + num * num);
			Matrix transform = g.Transform;
			g.TranslateTransform(pointF.X, pointF.Y);
			g.RotateTransform(angle);
			using (Pen pen = _line.GetPen(pane, scaleFactor))
			{
				g.DrawLine(pen, 0f, 0f, x, 0f);
			}
			g.Transform = transform;
		}
	}

	public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (!base.PointInBox(pt, pane, g, scaleFactor))
		{
			return false;
		}
		PointF pt2 = _location.TransformTopLeft(pane);
		PointF pt3 = _location.TransformBottomRight(pane);
		using Pen pen = new Pen(Color.Black, (float)GraphPane.Default.NearestTol * 2f);
		using GraphicsPath graphicsPath = new GraphicsPath();
		graphicsPath.AddLine(pt2, pt3);
		return graphicsPath.IsOutlineVisible(pt, pen);
	}

	public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
	{
		RectangleF rectangleF = _location.TransformRect(pane);
		Matrix matrix = new Matrix();
		if (rectangleF.Right == 0f)
		{
			rectangleF.Width = 1f;
		}
		float angle = (float)Math.Atan((rectangleF.Top - rectangleF.Bottom) / (rectangleF.Left - rectangleF.Right));
		matrix.Rotate(angle, MatrixOrder.Prepend);
		matrix.Translate(0f - rectangleF.Left, 0f - rectangleF.Top, MatrixOrder.Prepend);
		PointF[] array = new PointF[4]
		{
			new PointF(0f, 3f),
			new PointF(rectangleF.Width, 3f),
			new PointF(rectangleF.Width, -3f),
			new PointF(0f, -3f)
		};
		matrix.TransformPoints(array);
		shape = "poly";
		coords = $"{array[0].X:f0},{array[0].Y:f0},{array[1].X:f0},{array[1].Y:f0},{array[2].X:f0},{array[2].Y:f0},{array[3].X:f0},{array[3].Y:f0},";
	}
}
