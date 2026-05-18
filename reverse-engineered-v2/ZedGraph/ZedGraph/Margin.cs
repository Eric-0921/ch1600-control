using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Margin : ICloneable, ISerializable
{
	public class Default
	{
		public static float Left = 10f;

		public static float Right = 10f;

		public static float Top = 10f;

		public static float Bottom = 10f;
	}

	public const int schema = 10;

	protected float _left;

	protected float _right;

	protected float _top;

	protected float _bottom;

	public float Left
	{
		get
		{
			return _left;
		}
		set
		{
			_left = value;
		}
	}

	public float Right
	{
		get
		{
			return _right;
		}
		set
		{
			_right = value;
		}
	}

	public float Top
	{
		get
		{
			return _top;
		}
		set
		{
			_top = value;
		}
	}

	public float Bottom
	{
		get
		{
			return _bottom;
		}
		set
		{
			_bottom = value;
		}
	}

	public float All
	{
		set
		{
			_bottom = value;
			_top = value;
			_left = value;
			_right = value;
		}
	}

	public Margin()
	{
		_left = Default.Left;
		_right = Default.Right;
		_top = Default.Top;
		_bottom = Default.Bottom;
	}

	public Margin(Margin rhs)
	{
		_left = rhs._left;
		_right = rhs._right;
		_top = rhs._top;
		_bottom = rhs._bottom;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Margin Clone()
	{
		return new Margin(this);
	}

	protected Margin(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_left = info.GetSingle("left");
		_right = info.GetSingle("right");
		_top = info.GetSingle("top");
		_bottom = info.GetSingle("bottom");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("left", _left);
		info.AddValue("right", _right);
		info.AddValue("top", _top);
		info.AddValue("bottom", _bottom);
	}
}
