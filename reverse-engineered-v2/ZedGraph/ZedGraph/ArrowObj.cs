using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class ArrowObj : LineObj, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static float Size = 12f;

		public static bool IsArrowHead = true;
	}

	public const int schema3 = 10;

	private float _size;

	private bool _isArrowHead;

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

	public bool IsArrowHead
	{
		get
		{
			return _isArrowHead;
		}
		set
		{
			_isArrowHead = value;
		}
	}

	public ArrowObj(Color color, float size, double x1, double y1, double x2, double y2)
		: base(color, x1, y1, x2, y2)
	{
		_isArrowHead = Default.IsArrowHead;
		_size = size;
	}

	public ArrowObj(double x1, double y1, double x2, double y2)
		: this(LineBase.Default.Color, Default.Size, x1, y1, x2, y2)
	{
	}

	public ArrowObj()
		: this(LineBase.Default.Color, Default.Size, 0.0, 0.0, 1.0, 1.0)
	{
	}

	public ArrowObj(ArrowObj rhs)
		: base(rhs)
	{
		_size = rhs.Size;
		_isArrowHead = rhs.IsArrowHead;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new ArrowObj Clone()
	{
		return new ArrowObj(this);
	}

	protected ArrowObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
		_size = info.GetSingle("size");
		_isArrowHead = info.GetBoolean("isArrowHead");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema3", 11);
		info.AddValue("size", _size);
		info.AddValue("isArrowHead", _isArrowHead);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		PointF pointF = base.Location.TransformTopLeft(pane);
		PointF pointF2 = base.Location.TransformBottomRight(pane);
		if (!(pointF.X > -10000f) || !(pointF.X < 100000f) || !(pointF.Y > -100000f) || !(pointF.Y < 100000f) || !(pointF2.X > -10000f) || !(pointF2.X < 100000f) || !(pointF2.Y > -100000f) || !(pointF2.Y < 100000f))
		{
			return;
		}
		float num = _size * scaleFactor;
		double num2 = pointF2.Y - pointF.Y;
		double num3 = pointF2.X - pointF.X;
		float angle = (float)Math.Atan2(num2, num3) * 180f / (float)Math.PI;
		float num4 = (float)Math.Sqrt(num3 * num3 + num2 * num2);
		Matrix transform = g.Transform;
		g.TranslateTransform(pointF.X, pointF.Y);
		g.RotateTransform(angle);
		using (Pen pen = _line.GetPen(pane, scaleFactor))
		{
			if (_isArrowHead)
			{
				g.DrawLine(pen, 0f, 0f, num4 - num + 1f, 0f);
				PointF[] array = new PointF[4];
				float num5 = num / 3f;
				array[0].X = num4;
				array[0].Y = 0f;
				array[1].X = num4 - num;
				array[1].Y = num5;
				array[2].X = num4 - num;
				array[2].Y = 0f - num5;
				ref PointF reference = ref array[3];
				reference = array[0];
				using SolidBrush brush = new SolidBrush(_line._color);
				g.FillPolygon(brush, array);
			}
			else
			{
				g.DrawLine(pen, 0f, 0f, num4, 0f);
			}
		}
		g.Transform = transform;
	}
}
