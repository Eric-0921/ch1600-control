using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class DateScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.Date;

	public override double Min
	{
		get
		{
			return _min;
		}
		set
		{
			_min = XDate.MakeValidDate(value);
			_minAuto = false;
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
			_max = XDate.MakeValidDate(value);
			_maxAuto = false;
		}
	}

	internal override double MajorUnitMultiplier => GetUnitMultiple(_majorUnit);

	internal override double MinorUnitMultiplier => GetUnitMultiple(_minorUnit);

	public DateScale(Axis owner)
		: base(owner)
	{
	}

	public DateScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new DateScale(this, owner);
	}

	internal override double CalcMajorTicValue(double baseVal, double tic)
	{
		XDate xDate = new XDate(baseVal);
		switch (_majorUnit)
		{
		default:
			xDate.AddYears(tic * _majorStep);
			break;
		case DateUnit.Month:
			xDate.AddMonths(tic * _majorStep);
			break;
		case DateUnit.Day:
			xDate.AddDays(tic * _majorStep);
			break;
		case DateUnit.Hour:
			xDate.AddHours(tic * _majorStep);
			break;
		case DateUnit.Minute:
			xDate.AddMinutes(tic * _majorStep);
			break;
		case DateUnit.Second:
			xDate.AddSeconds(tic * _majorStep);
			break;
		case DateUnit.Millisecond:
			xDate.AddMilliseconds(tic * _majorStep);
			break;
		}
		return xDate.XLDate;
	}

	internal override double CalcMinorTicValue(double baseVal, int iTic)
	{
		XDate xDate = new XDate(baseVal);
		switch (_minorUnit)
		{
		default:
			xDate.AddYears((double)iTic * _minorStep);
			break;
		case DateUnit.Month:
			xDate.AddMonths((double)iTic * _minorStep);
			break;
		case DateUnit.Day:
			xDate.AddDays((double)iTic * _minorStep);
			break;
		case DateUnit.Hour:
			xDate.AddHours((double)iTic * _minorStep);
			break;
		case DateUnit.Minute:
			xDate.AddMinutes((double)iTic * _minorStep);
			break;
		case DateUnit.Second:
			xDate.AddSeconds((double)iTic * _minorStep);
			break;
		}
		return xDate.XLDate;
	}

	internal override int CalcMinorStart(double baseVal)
	{
		return _minorUnit switch
		{
			DateUnit.Month => (int)((_min - baseVal) / (28.0 * _minorStep)), 
			DateUnit.Day => (int)((_min - baseVal) / _minorStep), 
			DateUnit.Hour => (int)((_min - baseVal) * 24.0 / _minorStep), 
			DateUnit.Minute => (int)((_min - baseVal) * 1440.0 / _minorStep), 
			DateUnit.Second => (int)((_min - baseVal) * 86400.0 / _minorStep), 
			_ => (int)((_min - baseVal) / (365.0 * _minorStep)), 
		};
	}

	internal override double CalcBaseTic()
	{
		if (_baseTic != double.MaxValue)
		{
			return _baseTic;
		}
		XDate.XLDateToCalendarDate(_min, out var year, out var month, out var day, out var hour, out var minute, out var second, out var millisecond);
		switch (_majorUnit)
		{
		default:
			month = 1;
			day = 1;
			hour = 0;
			minute = 0;
			second = 0;
			millisecond = 0;
			break;
		case DateUnit.Month:
			day = 1;
			hour = 0;
			minute = 0;
			second = 0;
			millisecond = 0;
			break;
		case DateUnit.Day:
			hour = 0;
			minute = 0;
			second = 0;
			millisecond = 0;
			break;
		case DateUnit.Hour:
			minute = 0;
			second = 0;
			millisecond = 0;
			break;
		case DateUnit.Minute:
			second = 0;
			millisecond = 0;
			break;
		case DateUnit.Second:
			millisecond = 0;
			break;
		case DateUnit.Millisecond:
			break;
		}
		double num = XDate.CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
		if (num < _min)
		{
			switch (_majorUnit)
			{
			default:
				year++;
				break;
			case DateUnit.Month:
				month++;
				break;
			case DateUnit.Day:
				day++;
				break;
			case DateUnit.Hour:
				hour++;
				break;
			case DateUnit.Minute:
				minute++;
				break;
			case DateUnit.Second:
				second++;
				break;
			case DateUnit.Millisecond:
				millisecond++;
				break;
			}
			num = XDate.CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
		}
		return num;
	}

	internal override int CalcNumTics()
	{
		int num = 1;
		XDate.XLDateToCalendarDate(_min, out var year, out var month, out var _, out var _, out var _, out var _, out var _);
		XDate.XLDateToCalendarDate(_max, out var year2, out var month2, out var _, out var _, out var _, out var _, out var _);
		num = _majorUnit switch
		{
			DateUnit.Month => (int)(((double)(month2 - month) + 12.0 * (double)(year2 - year)) / _majorStep + 1.001), 
			DateUnit.Day => (int)((_max - _min) / _majorStep + 1.001), 
			DateUnit.Hour => (int)((_max - _min) / (_majorStep / 24.0) + 1.001), 
			DateUnit.Minute => (int)((_max - _min) / (_majorStep / 1440.0) + 1.001), 
			DateUnit.Second => (int)((_max - _min) / (_majorStep / 86400.0) + 1.001), 
			DateUnit.Millisecond => (int)((_max - _min) / (_majorStep / 86400000.0) + 1.001), 
			_ => (int)((double)(year2 - year) / _majorStep + 1.001), 
		};
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
		double targetSteps = ((_ownerAxis is XAxis || _ownerAxis is X2Axis) ? Default.TargetXSteps : Default.TargetYSteps);
		double majorStep = CalcDateStepSize(_max - _min, targetSteps);
		if (_majorStepAuto)
		{
			_majorStep = majorStep;
			if (_isPreventLabelOverlap)
			{
				double num = CalcMaxLabels(g, pane, scaleFactor);
				if (num < (double)CalcNumTics())
				{
					_majorStep = CalcDateStepSize(_max - _min, num);
				}
			}
		}
		if (_minAuto)
		{
			_min = CalcEvenStepDate(_min, -1);
		}
		if (_maxAuto)
		{
			_max = CalcEvenStepDate(_max, 1);
		}
		_mag = 0;
	}

	protected double CalcDateStepSize(double range, double targetSteps)
	{
		return CalcDateStepSize(range, targetSteps, this);
	}

	internal static double CalcDateStepSize(double range, double targetSteps, Scale scale)
	{
		double num = range / targetSteps;
		if (range > Default.RangeYearYear)
		{
			scale._majorUnit = DateUnit.Year;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatYearYear;
			}
			num = Math.Ceiling(num / 365.0);
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Year;
				if (num == 1.0)
				{
					scale._minorStep = 0.25;
				}
				else
				{
					scale._minorStep = Scale.CalcStepSize(num, targetSteps);
				}
			}
		}
		else if (range > Default.RangeYearMonth)
		{
			scale._majorUnit = DateUnit.Year;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatYearMonth;
			}
			num = Math.Ceiling(num / 365.0);
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Month;
				scale._minorStep = Math.Ceiling(range / (targetSteps * 3.0) / 30.0);
				if (scale._minorStep > 6.0)
				{
					scale._minorStep = 12.0;
				}
				else if (scale._minorStep > 3.0)
				{
					scale._minorStep = 6.0;
				}
			}
		}
		else if (range > Default.RangeMonthMonth)
		{
			scale._majorUnit = DateUnit.Month;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatMonthMonth;
			}
			num = Math.Ceiling(num / 30.0);
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Month;
				scale._minorStep = num * 0.25;
			}
		}
		else if (range > Default.RangeDayDay)
		{
			scale._majorUnit = DateUnit.Day;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatDayDay;
			}
			num = Math.Ceiling(num);
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Day;
				scale._minorStep = num * 0.25;
			}
		}
		else if (range > Default.RangeDayHour)
		{
			scale._majorUnit = DateUnit.Day;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatDayHour;
			}
			num = Math.Ceiling(num);
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Hour;
				scale._minorStep = Math.Ceiling(range / (targetSteps * 3.0) * 24.0);
				if (scale._minorStep > 6.0)
				{
					scale._minorStep = 12.0;
				}
				else if (scale._minorStep > 3.0)
				{
					scale._minorStep = 6.0;
				}
				else
				{
					scale._minorStep = 1.0;
				}
			}
		}
		else if (range > Default.RangeHourHour)
		{
			scale._majorUnit = DateUnit.Hour;
			num = Math.Ceiling(num * 24.0);
			if (scale._formatAuto)
			{
				scale._format = Default.FormatHourHour;
			}
			num = ((num > 12.0) ? 24.0 : ((num > 6.0) ? 12.0 : ((num > 2.0) ? 6.0 : ((!(num > 1.0)) ? 1.0 : 2.0))));
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Hour;
				if (num <= 1.0)
				{
					scale._minorStep = 0.25;
				}
				else if (num <= 6.0)
				{
					scale._minorStep = 1.0;
				}
				else if (num <= 12.0)
				{
					scale._minorStep = 2.0;
				}
				else
				{
					scale._minorStep = 4.0;
				}
			}
		}
		else if (range > Default.RangeHourMinute)
		{
			scale._majorUnit = DateUnit.Hour;
			num = Math.Ceiling(num * 24.0);
			if (scale._formatAuto)
			{
				scale._format = Default.FormatHourMinute;
			}
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Minute;
				scale._minorStep = Math.Ceiling(range / (targetSteps * 3.0) * 1440.0);
				if (scale._minorStep > 15.0)
				{
					scale._minorStep = 30.0;
				}
				else if (scale._minorStep > 5.0)
				{
					scale._minorStep = 15.0;
				}
				else if (scale._minorStep > 1.0)
				{
					scale._minorStep = 5.0;
				}
				else
				{
					scale._minorStep = 1.0;
				}
			}
		}
		else if (range > Default.RangeMinuteMinute)
		{
			scale._majorUnit = DateUnit.Minute;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatMinuteMinute;
			}
			num = Math.Ceiling(num * 1440.0);
			num = ((num > 15.0) ? 30.0 : ((num > 5.0) ? 15.0 : ((!(num > 1.0)) ? 1.0 : 5.0)));
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Minute;
				if (num <= 1.0)
				{
					scale._minorStep = 0.25;
				}
				else if (num <= 5.0)
				{
					scale._minorStep = 1.0;
				}
				else
				{
					scale._minorStep = 5.0;
				}
			}
		}
		else if (range > Default.RangeMinuteSecond)
		{
			scale._majorUnit = DateUnit.Minute;
			num = Math.Ceiling(num * 1440.0);
			if (scale._formatAuto)
			{
				scale._format = Default.FormatMinuteSecond;
			}
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Second;
				scale._minorStep = Math.Ceiling(range / (targetSteps * 3.0) * 86400.0);
				if (scale._minorStep > 15.0)
				{
					scale._minorStep = 30.0;
				}
				else if (scale._minorStep > 5.0)
				{
					scale._minorStep = 15.0;
				}
				else if (scale._minorStep > 1.0)
				{
					scale._minorStep = 5.0;
				}
				else
				{
					scale._minorStep = 1.0;
				}
			}
		}
		else if (range > Default.RangeSecondSecond)
		{
			scale._majorUnit = DateUnit.Second;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatSecondSecond;
			}
			num = Math.Ceiling(num * 86400.0);
			num = ((num > 15.0) ? 30.0 : ((num > 5.0) ? 15.0 : ((!(num > 1.0)) ? 1.0 : 5.0)));
			if (scale._minorStepAuto)
			{
				scale._minorUnit = DateUnit.Second;
				if (num <= 1.0)
				{
					scale._minorStep = 0.25;
				}
				else if (num <= 5.0)
				{
					scale._minorStep = 1.0;
				}
				else
				{
					scale._minorStep = 5.0;
				}
			}
		}
		else
		{
			scale._majorUnit = DateUnit.Millisecond;
			if (scale._formatAuto)
			{
				scale._format = Default.FormatMillisecond;
			}
			num = Scale.CalcStepSize(range * 86400000.0, Default.TargetXSteps);
			if (scale._minorStepAuto)
			{
				scale._minorStep = Scale.CalcStepSize(num, (scale._ownerAxis is XAxis || scale._ownerAxis is X2Axis) ? Default.TargetMinorXSteps : Default.TargetMinorYSteps);
				scale._minorUnit = DateUnit.Millisecond;
			}
		}
		return num;
	}

	protected double CalcEvenStepDate(double date, int direction)
	{
		XDate.XLDateToCalendarDate(date, out var year, out var month, out var day, out var hour, out var minute, out var second, out var millisecond);
		if (direction < 0)
		{
			direction = 0;
		}
		switch (_majorUnit)
		{
		default:
			if (direction == 1 && month == 1 && day == 1 && hour == 0 && minute == 0 && second == 0)
			{
				return date;
			}
			return XDate.CalendarDateToXLDate(year + direction, 1, 1, 0, 0, 0);
		case DateUnit.Month:
			if (direction == 1 && day == 1 && hour == 0 && minute == 0 && second == 0)
			{
				return date;
			}
			return XDate.CalendarDateToXLDate(year, month + direction, 1, 0, 0, 0);
		case DateUnit.Day:
			if (direction == 1 && hour == 0 && minute == 0 && second == 0)
			{
				return date;
			}
			return XDate.CalendarDateToXLDate(year, month, day + direction, 0, 0, 0);
		case DateUnit.Hour:
			if (direction == 1 && minute == 0 && second == 0)
			{
				return date;
			}
			return XDate.CalendarDateToXLDate(year, month, day, hour + direction, 0, 0);
		case DateUnit.Minute:
			if (direction == 1 && second == 0)
			{
				return date;
			}
			return XDate.CalendarDateToXLDate(year, month, day, hour, minute + direction, 0);
		case DateUnit.Second:
			return XDate.CalendarDateToXLDate(year, month, day, hour, minute, second + direction);
		case DateUnit.Millisecond:
			return XDate.CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond + direction);
		}
	}

	internal override string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		return XDate.ToString(dVal, _format);
	}

	private double GetUnitMultiple(DateUnit unit)
	{
		return unit switch
		{
			DateUnit.Month => 30.0, 
			DateUnit.Day => 1.0, 
			DateUnit.Hour => 1.0 / 24.0, 
			DateUnit.Minute => 0.0006944444444444445, 
			DateUnit.Second => 1.1574074074074073E-05, 
			DateUnit.Millisecond => 1.1574074074074074E-08, 
			_ => 365.0, 
		};
	}

	protected DateScale(SerializationInfo info, StreamingContext context)
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
