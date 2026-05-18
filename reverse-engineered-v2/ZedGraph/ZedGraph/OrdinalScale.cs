using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class OrdinalScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.Ordinal;

	public OrdinalScale(Axis owner)
		: base(owner)
	{
	}

	public OrdinalScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new OrdinalScale(this, owner);
	}

	public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		base.PickScale(pane, g, scaleFactor);
		PickScale(pane, g, scaleFactor, this);
	}

	internal static void PickScale(GraphPane pane, Graphics g, float scaleFactor, Scale scale)
	{
		if (scale._max - scale._min < 1.0)
		{
			if (scale._maxAuto)
			{
				scale._max = scale._min + 0.5;
			}
			else
			{
				scale._min = scale._max - 0.5;
			}
			return;
		}
		if (scale._majorStepAuto)
		{
			scale._majorStep = Scale.CalcStepSize(scale._max - scale._min, (scale._ownerAxis is XAxis || scale._ownerAxis is X2Axis) ? Default.TargetXSteps : Default.TargetYSteps);
			if (scale.IsPreventLabelOverlap)
			{
				double num = scale.CalcMaxLabels(g, pane, scaleFactor);
				double num2 = Math.Ceiling((scale._max - scale._min) / num);
				if (num2 > scale._majorStep)
				{
					scale._majorStep = num2;
				}
			}
		}
		scale._majorStep = (int)scale._majorStep;
		if (scale._majorStep < 1.0)
		{
			scale._majorStep = 1.0;
		}
		if (scale._minorStepAuto)
		{
			scale._minorStep = Scale.CalcStepSize(scale._majorStep, (scale._ownerAxis is XAxis || scale._ownerAxis is X2Axis) ? Default.TargetMinorXSteps : Default.TargetMinorYSteps);
		}
		if (scale._minAuto)
		{
			scale._min -= 0.5;
		}
		if (scale._maxAuto)
		{
			scale._max += 0.5;
		}
	}

	protected OrdinalScale(SerializationInfo info, StreamingContext context)
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
}
