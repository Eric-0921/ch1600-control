using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class MajorGrid : MinorGrid, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static float DashOn = 1f;

		public static float DashOff = 5f;

		public static float PenWidth = 1f;

		public static Color Color = Color.Black;

		public static bool IsVisible = false;

		public static bool IsZeroLine = false;
	}

	public const int schema2 = 10;

	internal bool _isZeroLine;

	public bool IsZeroLine
	{
		get
		{
			return _isZeroLine;
		}
		set
		{
			_isZeroLine = value;
		}
	}

	public MajorGrid()
	{
		_dashOn = Default.DashOn;
		_dashOff = Default.DashOff;
		_penWidth = Default.PenWidth;
		_isVisible = Default.IsVisible;
		_color = Default.Color;
		_isZeroLine = Default.IsZeroLine;
	}

	public MajorGrid(MajorGrid rhs)
		: base(rhs)
	{
		_isZeroLine = rhs._isZeroLine;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new MajorGrid Clone()
	{
		return new MajorGrid(this);
	}

	protected MajorGrid(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_isZeroLine = info.GetBoolean("isZeroLine");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("isZeroLine", _isZeroLine);
	}
}
