using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class LogScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.Log;

	public override double Min
	{
		get
		{
			return _min;
		}
		set
		{
			if (value > 0.0)
			{
				_min = value;
			}
		}
	}

	public override double Max
	{
		get
		{
			return _max;
		}
		set
		{
			if (value > 0.0)
			{
				_max = value;
			}
		}
	}

	private double CyclesPerStep => _majorStep;

	public LogScale(Axis owner)
		: base(owner)
	{
	}

	public LogScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new LogScale(this, owner);
	}

	public override void SetupScaleData(GraphPane pane, Axis axis)
	{
		base.SetupScaleData(pane, axis);
		_minLinTemp = Linearize(_min);
		_maxLinTemp = Linearize(_max);
	}

	public override double Linearize(double val)
	{
		return Scale.SafeLog(val);
	}

	public override double DeLinearize(double val)
	{
		return Math.Pow(10.0, val);
	}

	internal override double CalcMajorTicValue(double baseVal, double tic)
	{
		return baseVal + tic * CyclesPerStep;
	}

	internal override double CalcMinorTicValue(double baseVal, int iTic)
	{
		double[] array = new double[10] { 0.0, 0.301029995663981, 0.477121254719662, 0.602059991327962, 0.698970004336019, 0.778151250383644, 0.845098040014257, 0.903089986991944, 0.954242509439325, 1.0 };
		return baseVal + Math.Floor((double)iTic / 9.0) + array[(iTic + 9) % 9];
	}

	internal override int CalcMinorStart(double baseVal)
	{
		return -9;
	}

	internal override double CalcBaseTic()
	{
		if (_baseTic != double.MaxValue)
		{
			return _baseTic;
		}
		return Math.Ceiling(Scale.SafeLog(_min) - 1E-08);
	}

	internal override int CalcNumTics()
	{
		int num = 1;
		num = (int)((Scale.SafeLog(_max) - Scale.SafeLog(_min)) / CyclesPerStep) + 1;
		if (num < 1)
		{
			num = 1;
		}
		else if (num > 1000)
		{
			num = 1000;
		}
		return num;
	}

	public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		base.PickScale(pane, g, scaleFactor);
		if (_majorStepAuto)
		{
			_majorStep = 1.0;
		}
		_mag = 0;
		if (_min <= 0.0 && _max <= 0.0)
		{
			_min = 1.0;
			_max = 10.0;
		}
		else if (_min <= 0.0)
		{
			_min = _max / 10.0;
		}
		else if (_max <= 0.0)
		{
			_max = _min * 10.0;
		}
		if (_max - _min < 1E-20)
		{
			if (_maxAuto)
			{
				_max *= 2.0;
			}
			if (_minAuto)
			{
				_min /= 2.0;
			}
		}
		if (_minAuto)
		{
			_min = Math.Pow(10.0, Math.Floor(Math.Log10(_min)));
		}
		if (_maxAuto)
		{
			_max = Math.Pow(10.0, Math.Ceiling(Math.Log10(_max)));
		}
	}

	internal override string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		if (_isUseTenPower)
		{
			return $"{dVal:F0}";
		}
		return Math.Pow(10.0, dVal).ToString(_format);
	}

	protected LogScale(SerializationInfo info, StreamingContext context)
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
