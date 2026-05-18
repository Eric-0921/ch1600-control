using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class DateAsOrdinalScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.DateAsOrdinal;

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

	public DateAsOrdinalScale(Axis owner)
		: base(owner)
	{
	}

	public DateAsOrdinalScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new DateAsOrdinalScale(this, owner);
	}

	public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		base.PickScale(pane, g, scaleFactor);
		SetDateFormat(pane);
		base.PickScale(pane, g, scaleFactor);
		OrdinalScale.PickScale(pane, g, scaleFactor, this);
	}

	internal void SetDateFormat(GraphPane pane)
	{
		if (!_formatAuto)
		{
			return;
		}
		double num = 10.0;
		if (pane.CurveList.Count > 0 && pane.CurveList[0].Points.Count > 1)
		{
			PointPair pointPair = pane.CurveList[0].Points[0];
			PointPair pointPair2 = pane.CurveList[0].Points[pane.CurveList[0].Points.Count - 1];
			int num2 = 1;
			int count = pane.CurveList[0].Points.Count;
			if (pane.IsBoundedRanges)
			{
				num2 = (int)Math.Floor(_ownerAxis.Scale.Min);
				count = (int)Math.Ceiling(_ownerAxis.Scale.Max);
				num2 = Math.Min(Math.Max(num2, 1), pane.CurveList[0].Points.Count);
				count = Math.Min(Math.Max(count, 1), pane.CurveList[0].Points.Count);
				if (count > num2)
				{
					pointPair = pane.CurveList[0].Points[num2 - 1];
					pointPair2 = pane.CurveList[0].Points[count - 1];
				}
			}
			double num3;
			double num4;
			if (_ownerAxis is XAxis || _ownerAxis is X2Axis)
			{
				num3 = pointPair.X;
				num4 = pointPair2.X;
			}
			else
			{
				num3 = pointPair.Y;
				num4 = pointPair2.Y;
			}
			if (num3 != double.MaxValue && num4 != double.MaxValue && !double.IsNaN(num3) && !double.IsNaN(num4) && !double.IsInfinity(num3) && !double.IsInfinity(num4) && Math.Abs(num4 - num3) > 1E-10)
			{
				num = Math.Abs(num4 - num3);
			}
		}
		if (num > Default.RangeYearYear)
		{
			_format = Default.FormatYearYear;
		}
		else if (num > Default.RangeYearMonth)
		{
			_format = Default.FormatYearMonth;
		}
		else if (num > Default.RangeMonthMonth)
		{
			_format = Default.FormatMonthMonth;
		}
		else if (num > Default.RangeDayDay)
		{
			_format = Default.FormatDayDay;
		}
		else if (num > Default.RangeDayHour)
		{
			_format = Default.FormatDayHour;
		}
		else if (num > Default.RangeHourHour)
		{
			_format = Default.FormatHourHour;
		}
		else if (num > Default.RangeHourMinute)
		{
			_format = Default.FormatHourMinute;
		}
		else if (num > Default.RangeMinuteMinute)
		{
			_format = Default.FormatMinuteMinute;
		}
		else if (num > Default.RangeMinuteSecond)
		{
			_format = Default.FormatMinuteSecond;
		}
		else if (num > Default.RangeSecondSecond)
		{
			_format = Default.FormatSecondSecond;
		}
		else
		{
			_format = Default.FormatMillisecond;
		}
	}

	internal override string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		int num = (int)dVal - 1;
		if (pane.CurveList.Count > 0 && pane.CurveList[0].Points.Count > num)
		{
			double num2 = ((!(_ownerAxis is XAxis) && !(_ownerAxis is X2Axis)) ? pane.CurveList[0].Points[num].Y : pane.CurveList[0].Points[num].X);
			return XDate.ToString(num2, _format);
		}
		return string.Empty;
	}

	protected DateAsOrdinalScale(SerializationInfo info, StreamingContext context)
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
