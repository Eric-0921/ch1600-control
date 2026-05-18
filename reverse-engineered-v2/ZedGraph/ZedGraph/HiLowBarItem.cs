using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class HiLowBarItem : BarItem, ICloneable, ISerializable
{
	public const int schema3 = 11;

	public HiLowBarItem(string label, double[] x, double[] y, double[] baseVal, Color color)
		: this(label, new PointPairList(x, y, baseVal), color)
	{
	}

	public HiLowBarItem(string label, IPointList points, Color color)
		: base(label, points, color)
	{
	}

	public HiLowBarItem(HiLowBarItem rhs)
		: base(rhs)
	{
		_bar = rhs._bar.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new HiLowBarItem Clone()
	{
		return new HiLowBarItem(this);
	}

	protected HiLowBarItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
	}
}
