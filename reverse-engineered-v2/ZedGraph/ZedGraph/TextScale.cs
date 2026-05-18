using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class TextScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.Text;

	public TextScale(Axis owner)
		: base(owner)
	{
	}

	public TextScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new TextScale(this, owner);
	}

	internal override int CalcMinorStart(double baseVal)
	{
		return 0;
	}

	internal override double CalcBaseTic()
	{
		if (_baseTic != double.MaxValue)
		{
			return _baseTic;
		}
		return 1.0;
	}

	internal override int CalcNumTics()
	{
		int num = 1;
		num = ((_textLabels != null) ? _textLabels.Length : 10);
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
		if (_textLabels != null)
		{
			if (_minAuto)
			{
				_min = 0.5;
			}
			if (_maxAuto)
			{
				_max = (double)_textLabels.Length + 0.5;
			}
		}
		else
		{
			if (_minAuto)
			{
				_min -= 0.5;
			}
			if (_maxAuto)
			{
				_max += 0.5;
			}
		}
		if (_max - _min < 0.1)
		{
			if (_maxAuto)
			{
				_max = _min + 10.0;
			}
			else
			{
				_min = _max - 10.0;
			}
		}
		if (_majorStepAuto)
		{
			if (!_isPreventLabelOverlap)
			{
				_majorStep = 1.0;
			}
			else if (_textLabels != null)
			{
				double num = CalcMaxLabels(g, pane, scaleFactor);
				double majorStep = Math.Ceiling((_max - _min) / num);
				_majorStep = majorStep;
			}
			else
			{
				_majorStep = (double)(int)((_max - _min - 1.0) / Default.MaxTextLabels) + 1.0;
			}
		}
		else
		{
			_majorStep = (int)_majorStep;
			if (_majorStep <= 0.0)
			{
				_majorStep = 1.0;
			}
		}
		if (_minorStepAuto)
		{
			_minorStep = _majorStep / 10.0;
			if (_minorStep < 1.0)
			{
				_minorStep = 1.0;
			}
		}
		_mag = 0;
	}

	internal override string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		index *= (int)_majorStep;
		if (_textLabels == null || index < 0 || index >= _textLabels.Length)
		{
			return string.Empty;
		}
		return _textLabels[index];
	}

	protected TextScale(SerializationInfo info, StreamingContext context)
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
