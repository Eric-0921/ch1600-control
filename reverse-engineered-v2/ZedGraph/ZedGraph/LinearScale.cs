using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class LinearScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.Linear;

	public LinearScale(Axis owner)
		: base(owner)
	{
	}

	public LinearScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new LinearScale(this, owner);
	}

	public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		base.PickScale(pane, g, scaleFactor);
		if (_max - _min < 1E-30)
		{
			if (_maxAuto)
			{
				_max += 0.2 * ((_max == 0.0) ? 1.0 : Math.Abs(_max));
			}
			if (_minAuto)
			{
				_min -= 0.2 * ((_min == 0.0) ? 1.0 : Math.Abs(_min));
			}
		}
		if (_minAuto && _min > 0.0 && _min / (_max - _min) < Default.ZeroLever)
		{
			_min = 0.0;
		}
		if (_maxAuto && _max < 0.0 && Math.Abs(_max / (_max - _min)) < Default.ZeroLever)
		{
			_max = 0.0;
		}
		if (_majorStepAuto)
		{
			double targetSteps = ((_ownerAxis is XAxis || _ownerAxis is X2Axis) ? Default.TargetXSteps : Default.TargetYSteps);
			_majorStep = Scale.CalcStepSize(_max - _min, targetSteps);
			if (_isPreventLabelOverlap)
			{
				double num = CalcMaxLabels(g, pane, scaleFactor);
				if (num < (_max - _min) / _majorStep)
				{
					_majorStep = CalcBoundedStepSize(_max - _min, num);
				}
			}
		}
		if (_minorStepAuto)
		{
			_minorStep = Scale.CalcStepSize(_majorStep, (_ownerAxis is XAxis || _ownerAxis is X2Axis) ? Default.TargetMinorXSteps : Default.TargetMinorYSteps);
		}
		if (_minAuto)
		{
			_min -= MyMod(_min, _majorStep);
		}
		if (_maxAuto)
		{
			_max = ((MyMod(_max, _majorStep) == 0.0) ? _max : (_max + _majorStep - MyMod(_max, _majorStep)));
		}
		SetScaleMag(_min, _max, _majorStep);
	}

	protected LinearScale(SerializationInfo info, StreamingContext context)
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
