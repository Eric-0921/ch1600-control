using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class ExponentScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.Exponent;

	public ExponentScale(Axis owner)
		: base(owner)
	{
	}

	public ExponentScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new ExponentScale(this, owner);
	}

	public override void SetupScaleData(GraphPane pane, Axis axis)
	{
		base.SetupScaleData(pane, axis);
		if (_exponent > 0.0)
		{
			_minLinTemp = Linearize(_min);
			_maxLinTemp = Linearize(_max);
		}
		else if (_exponent < 0.0)
		{
			_minLinTemp = Linearize(_max);
			_maxLinTemp = Linearize(_min);
		}
	}

	public override double Linearize(double val)
	{
		return Scale.SafeExp(val, _exponent);
	}

	public override double DeLinearize(double val)
	{
		return Math.Pow(val, 1.0 / _exponent);
	}

	internal override double CalcMajorTicValue(double baseVal, double tic)
	{
		if (_exponent > 0.0)
		{
			return Math.Pow(Math.Pow(baseVal, 1.0 / _exponent) + _majorStep * tic, _exponent);
		}
		if (_exponent < 0.0)
		{
			return Math.Pow(Math.Pow(baseVal, 1.0 / _exponent) + _majorStep * tic, _exponent);
		}
		return 1.0;
	}

	internal override double CalcMinorTicValue(double baseVal, int iTic)
	{
		return baseVal + Math.Pow(_majorStep * (double)iTic, _exponent);
	}

	internal override int CalcMinorStart(double baseVal)
	{
		return (int)((Math.Pow(_min, _exponent) - baseVal) / Math.Pow(_minorStep, _exponent));
	}

	public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		base.PickScale(pane, g, scaleFactor);
		if (_max - _min < 1E-20)
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
		if (_magAuto)
		{
			double num2 = 0.0;
			double num3 = 0.0;
			if (Math.Abs(_min) > 1E-10)
			{
				num2 = Math.Floor(Math.Log10(Math.Abs(_min)));
			}
			if (Math.Abs(_max) > 1E-10)
			{
				num3 = Math.Floor(Math.Log10(Math.Abs(_max)));
			}
			if (Math.Abs(num3) > Math.Abs(num2))
			{
				num2 = num3;
			}
			if (Math.Abs(num2) <= 3.0)
			{
				num2 = 0.0;
			}
			_mag = (int)(Math.Floor(num2 / 3.0) * 3.0);
		}
		if (_formatAuto)
		{
			int num4 = -(int)(Math.Floor(Math.Log10(_majorStep)) - (double)_mag);
			if (num4 < 0)
			{
				num4 = 0;
			}
			_format = "f" + num4;
		}
	}

	internal override string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		double num = Math.Pow(10.0, _mag);
		return (Math.Pow(dVal, 1.0 / _exponent) / num).ToString(_format);
	}

	protected ExponentScale(SerializationInfo info, StreamingContext context)
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
