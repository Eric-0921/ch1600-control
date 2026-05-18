using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class XAxis : Axis, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static bool IsVisible = true;

		public static bool IsZeroLine = false;
	}

	public const int schema2 = 10;

	public XAxis()
		: this("X Axis")
	{
	}

	public XAxis(string title)
		: base(title)
	{
		_isVisible = Default.IsVisible;
		_majorGrid._isZeroLine = Default.IsZeroLine;
		_scale._fontSpec.Angle = 0f;
	}

	public XAxis(XAxis rhs)
		: base(rhs)
	{
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public XAxis Clone()
	{
		return new XAxis(this);
	}

	protected XAxis(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
	}

	public override void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor)
	{
		g.TranslateTransform(pane.Chart._rect.Left, pane.Chart._rect.Bottom);
	}

	internal override bool IsPrimary(GraphPane pane)
	{
		return this == pane.XAxis;
	}

	internal override float CalcCrossShift(GraphPane pane)
	{
		double x = EffectiveCrossValue(pane);
		if (!_crossAuto)
		{
			return pane.YAxis.Scale.Transform(x) - pane.YAxis.Scale._maxPix;
		}
		return 0f;
	}

	public override Axis GetCrossAxis(GraphPane pane)
	{
		return pane.YAxis;
	}
}
