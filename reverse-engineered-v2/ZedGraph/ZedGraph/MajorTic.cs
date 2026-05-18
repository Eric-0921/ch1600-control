using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class MajorTic : MinorTic, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static float Size = 5f;

		public static float PenWidth = 1f;

		public static bool IsOutside = true;

		public static bool IsInside = true;

		public static bool IsOpposite = true;

		public static bool IsCrossOutside = false;

		public static bool IsCrossInside = false;

		public static Color Color = Color.Black;
	}

	public const int schema2 = 10;

	internal bool _isBetweenLabels;

	public bool IsBetweenLabels
	{
		get
		{
			return _isBetweenLabels;
		}
		set
		{
			_isBetweenLabels = value;
		}
	}

	public MajorTic()
	{
		_size = Default.Size;
		_color = Default.Color;
		_penWidth = Default.PenWidth;
		base.IsOutside = Default.IsOutside;
		base.IsInside = Default.IsInside;
		base.IsOpposite = Default.IsOpposite;
		_isCrossOutside = Default.IsCrossOutside;
		_isCrossInside = Default.IsCrossInside;
		_isBetweenLabels = false;
	}

	public MajorTic(MajorTic rhs)
		: base(rhs)
	{
		_isBetweenLabels = rhs._isBetweenLabels;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new MajorTic Clone()
	{
		return new MajorTic(this);
	}

	protected MajorTic(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_isBetweenLabels = info.GetBoolean("isBetweenLabels");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("isBetweenLabels", _isBetweenLabels);
	}
}
