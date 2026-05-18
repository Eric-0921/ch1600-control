using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class X2Axis : Axis, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static bool IsVisible;

		public static bool IsZeroLine;
	}

	public const int schema2 = 11;

	public X2Axis()
		: this("X2 Axis")
	{
	}

	public X2Axis(string title)
		: base(title)
	{
		_isVisible = Default.IsVisible;
		_majorGrid._isZeroLine = Default.IsZeroLine;
		_scale._fontSpec.Angle = 180f;
		_title._fontSpec.Angle = 180f;
	}

	public X2Axis(X2Axis rhs)
		: base(rhs)
	{
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public X2Axis Clone()
	{
		return new X2Axis(this);
	}

	protected X2Axis(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
	}

	public override void SetTransformMatrix(Graphics g, GraphPane pane, float scaleFactor)
	{
		g.TranslateTransform(pane.Chart._rect.Right, pane.Chart._rect.Top);
		g.RotateTransform(180f);
	}

	internal override bool IsPrimary(GraphPane pane)
	{
		return this == pane.X2Axis;
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
