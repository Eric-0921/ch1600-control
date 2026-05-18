using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class YAxis : Axis, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static bool IsVisible = true;

		public static bool IsZeroLine = true;
	}

	public const int schema2 = 10;

	public YAxis()
		: this("Y Axis")
	{
	}

	public YAxis(string title)
		: base(title)
	{
		_isVisible = Default.IsVisible;
		_majorGrid._isZeroLine = Default.IsZeroLine;
		_scale._fontSpec.Angle = 90f;
		_title._fontSpec.Angle = -180f;
	}

	public YAxis(YAxis rhs)
		: base(rhs)
	{
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public YAxis Clone()
	{
		return new YAxis(this);
	}

	protected YAxis(SerializationInfo info, StreamingContext context)
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
		g.TranslateTransform(pane.Chart._rect.Left, pane.Chart._rect.Top);
		g.RotateTransform(90f);
	}

	internal override bool IsPrimary(GraphPane pane)
	{
		return this == pane.YAxis;
	}

	internal override float CalcCrossShift(GraphPane pane)
	{
		double x = EffectiveCrossValue(pane);
		if (!_crossAuto)
		{
			return pane.XAxis.Scale._minPix - pane.XAxis.Scale.Transform(x);
		}
		return 0f;
	}

	public override Axis GetCrossAxis(GraphPane pane)
	{
		return pane.XAxis;
	}
}
