using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Y2Axis : Axis, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static bool IsVisible = false;

		public static bool IsZeroLine = true;
	}

	public const int schema2 = 10;

	public Y2Axis()
		: this("Y2 Axis")
	{
	}

	public Y2Axis(string title)
		: base(title)
	{
		_isVisible = Default.IsVisible;
		_majorGrid._isZeroLine = Default.IsZeroLine;
		_scale._fontSpec.Angle = -90f;
	}

	public Y2Axis(Y2Axis rhs)
		: base(rhs)
	{
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Y2Axis Clone()
	{
		return new Y2Axis(this);
	}

	protected Y2Axis(SerializationInfo info, StreamingContext context)
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
		g.TranslateTransform(pane.Chart._rect.Right, pane.Chart._rect.Bottom);
		g.RotateTransform(-90f);
	}

	internal override bool IsPrimary(GraphPane pane)
	{
		return this == pane.Y2Axis;
	}

	internal override float CalcCrossShift(GraphPane pane)
	{
		double x = EffectiveCrossValue(pane);
		if (!_crossAuto)
		{
			return pane.XAxis.Scale.Transform(x) - pane.XAxis.Scale._maxPix;
		}
		return 0f;
	}

	public override Axis GetCrossAxis(GraphPane pane)
	{
		return pane.XAxis;
	}
}
