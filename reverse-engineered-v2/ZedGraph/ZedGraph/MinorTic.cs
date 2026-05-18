using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class MinorTic : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float Size = 2.5f;

		public static float PenWidth = 1f;

		public static bool IsOutside = true;

		public static bool IsInside = true;

		public static bool IsOpposite = true;

		public static bool IsCrossOutside = false;

		public static bool IsCrossInside = false;

		public static Color Color = Color.Black;
	}

	public const int schema = 10;

	internal bool _isOutside;

	internal bool _isInside;

	internal bool _isOpposite;

	internal bool _isCrossOutside;

	internal bool _isCrossInside;

	internal float _penWidth;

	internal float _size;

	internal Color _color;

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

	public bool IsAllTics
	{
		set
		{
			IsOutside = value;
			IsInside = value;
			IsOpposite = value;
			_isCrossOutside = value;
			_isCrossInside = value;
		}
	}

	public bool IsOutside
	{
		get
		{
			return _isOutside;
		}
		set
		{
			_isOutside = value;
		}
	}

	public bool IsInside
	{
		get
		{
			return _isInside;
		}
		set
		{
			_isInside = value;
		}
	}

	public bool IsOpposite
	{
		get
		{
			return _isOpposite;
		}
		set
		{
			_isOpposite = value;
		}
	}

	public bool IsCrossOutside
	{
		get
		{
			return _isCrossOutside;
		}
		set
		{
			_isCrossOutside = value;
		}
	}

	public bool IsCrossInside
	{
		get
		{
			return _isCrossInside;
		}
		set
		{
			_isCrossInside = value;
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

	public MinorTic()
	{
		_size = Default.Size;
		_color = Default.Color;
		_penWidth = Default.PenWidth;
		IsOutside = Default.IsOutside;
		IsInside = Default.IsInside;
		IsOpposite = Default.IsOpposite;
		_isCrossOutside = Default.IsCrossOutside;
		_isCrossInside = Default.IsCrossInside;
	}

	public MinorTic(MinorTic rhs)
	{
		_size = rhs._size;
		_color = rhs._color;
		_penWidth = rhs._penWidth;
		IsOutside = rhs.IsOutside;
		IsInside = rhs.IsInside;
		IsOpposite = rhs.IsOpposite;
		_isCrossOutside = rhs._isCrossOutside;
		_isCrossInside = rhs._isCrossInside;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public MinorTic Clone()
	{
		return new MinorTic(this);
	}

	public float ScaledTic(float scaleFactor)
	{
		return _size * scaleFactor;
	}

	protected MinorTic(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_color = (Color)info.GetValue("color", typeof(Color));
		_size = info.GetSingle("size");
		_penWidth = info.GetSingle("penWidth");
		IsOutside = info.GetBoolean("IsOutside");
		IsInside = info.GetBoolean("IsInside");
		IsOpposite = info.GetBoolean("IsOpposite");
		_isCrossOutside = info.GetBoolean("isCrossOutside");
		_isCrossInside = info.GetBoolean("isCrossInside");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("color", _color);
		info.AddValue("size", _size);
		info.AddValue("penWidth", _penWidth);
		info.AddValue("IsOutside", IsOutside);
		info.AddValue("IsInside", IsInside);
		info.AddValue("IsOpposite", IsOpposite);
		info.AddValue("isCrossOutside", _isCrossOutside);
		info.AddValue("isCrossInside", _isCrossInside);
	}

	internal void Draw(Graphics g, GraphPane pane, Pen pen, float pixVal, float topPix, float shift, float scaledTic)
	{
		if (IsOutside)
		{
			g.DrawLine(pen, pixVal, shift, pixVal, shift + scaledTic);
		}
		if (_isCrossOutside)
		{
			g.DrawLine(pen, pixVal, 0f, pixVal, scaledTic);
		}
		if (IsInside)
		{
			g.DrawLine(pen, pixVal, shift, pixVal, shift - scaledTic);
		}
		if (_isCrossInside)
		{
			g.DrawLine(pen, pixVal, 0f, pixVal, 0f - scaledTic);
		}
		if (IsOpposite)
		{
			g.DrawLine(pen, pixVal, topPix, pixVal, topPix + scaledTic);
		}
	}

	internal Pen GetPen(GraphPane pane, float scaleFactor)
	{
		return new Pen(_color, pane.ScaledPenWidth(_penWidth, scaleFactor));
	}
}
