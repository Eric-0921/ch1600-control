using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class StickItem : LineItem, ICloneable, ISerializable
{
	public const int schema3 = 10;

	internal override bool IsZIncluded(GraphPane pane)
	{
		return _symbol.IsVisible;
	}

	internal override bool IsXIndependent(GraphPane pane)
	{
		return true;
	}

	public StickItem(string label)
		: base(label)
	{
		_symbol.IsVisible = false;
	}

	public StickItem(string label, double[] x, double[] y, Color color, float lineWidth)
		: this(label, new PointPairList(x, y), color, lineWidth)
	{
	}

	public StickItem(string label, double[] x, double[] y, Color color)
		: this(label, new PointPairList(x, y), color)
	{
	}

	public StickItem(string label, IPointList points, Color color)
		: this(label, points, color, LineBase.Default.Width)
	{
	}

	public StickItem(string label, IPointList points, Color color, float lineWidth)
		: base(label, points, color, Symbol.Default.Type, lineWidth)
	{
		_symbol.IsVisible = false;
	}

	public StickItem(StickItem rhs)
		: base(rhs)
	{
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new StickItem Clone()
	{
		return new StickItem(this);
	}

	protected StickItem(SerializationInfo info, StreamingContext context)
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
}
