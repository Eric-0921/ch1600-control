using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Border : LineBase, ISerializable, ICloneable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static float InflateFactor;
	}

	public const int schema = 11;

	private float _inflateFactor;

	public float InflateFactor
	{
		get
		{
			return _inflateFactor;
		}
		set
		{
			_inflateFactor = value;
		}
	}

	public Border()
	{
		_inflateFactor = Default.InflateFactor;
	}

	public Border(bool isVisible, Color color, float width)
		: base(color)
	{
		_width = width;
		_isVisible = isVisible;
	}

	public Border(Color color, float width)
		: this(!color.IsEmpty, color, width)
	{
	}

	public Border(Border rhs)
		: base(rhs)
	{
		_inflateFactor = rhs._inflateFactor;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Border Clone()
	{
		return new Border(this);
	}

	protected Border(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema");
		_inflateFactor = info.GetSingle("inflateFactor");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema", 11);
		info.AddValue("inflateFactor", _inflateFactor);
	}

	public void Draw(Graphics g, PaneBase pane, float scaleFactor, RectangleF rect)
	{
		if (_isVisible)
		{
			RectangleF rectangleF = rect;
			float num = _inflateFactor * scaleFactor;
			rectangleF.Inflate(num, num);
			using Pen pen = GetPen(pane, scaleFactor);
			g.DrawRectangle(pen, rectangleF.X, rectangleF.Y, rectangleF.Width, rectangleF.Height);
		}
	}
}
