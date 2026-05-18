using System;

namespace ZedGraph;

public struct XDate : IComparable
{
	public const double XLDay1 = 2415018.5;

	public const double JulDayMin = 0.0;

	public const double JulDayMax = 5373483.5;

	public const double XLDayMin = -2415018.5;

	public const double XLDayMax = 2958465.0;

	public const double MonthsPerYear = 12.0;

	public const double HoursPerDay = 24.0;

	public const double MinutesPerHour = 60.0;

	public const double SecondsPerMinute = 60.0;

	public const double MinutesPerDay = 1440.0;

	public const double SecondsPerDay = 86400.0;

	public const double MillisecondsPerSecond = 1000.0;

	public const double MillisecondsPerDay = 86400000.0;

	public const string DefaultFormatStr = "g";

	private double _xlDate;

	public double XLDate
	{
		get
		{
			return _xlDate;
		}
		set
		{
			_xlDate = value;
		}
	}

	public bool IsValidDate
	{
		get
		{
			if (_xlDate >= -2415018.5)
			{
				return _xlDate <= 2958465.0;
			}
			return false;
		}
	}

	public DateTime DateTime
	{
		get
		{
			return XLDateToDateTime(_xlDate);
		}
		set
		{
			_xlDate = DateTimeToXLDate(value);
		}
	}

	public double JulianDay
	{
		get
		{
			return XLDateToJulianDay(_xlDate);
		}
		set
		{
			_xlDate = JulianDayToXLDate(value);
		}
	}

	public double DecimalYear
	{
		get
		{
			return XLDateToDecimalYear(_xlDate);
		}
		set
		{
			_xlDate = DecimalYearToXLDate(value);
		}
	}

	public XDate(double xlDate)
	{
		_xlDate = xlDate;
	}

	public XDate(DateTime dateTime)
	{
		_xlDate = CalendarDateToXLDate(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond);
	}

	public XDate(int year, int month, int day)
	{
		_xlDate = CalendarDateToXLDate(year, month, day, 0, 0, 0);
	}

	public XDate(int year, int month, int day, int hour, int minute, int second)
	{
		_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
	}

	public XDate(int year, int month, int day, int hour, int minute, double second)
	{
		_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
	}

	public XDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
	{
		_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
	}

	public XDate(XDate rhs)
	{
		_xlDate = rhs._xlDate;
	}

	private static bool CheckValidDate(double xlDate)
	{
		if (xlDate >= -2415018.5)
		{
			return xlDate <= 2958465.0;
		}
		return false;
	}

	public static double MakeValidDate(double xlDate)
	{
		if (xlDate < -2415018.5)
		{
			xlDate = -2415018.5;
		}
		if (xlDate > 2958465.0)
		{
			xlDate = 2958465.0;
		}
		return xlDate;
	}

	public void GetDate(out int year, out int month, out int day)
	{
		XLDateToCalendarDate(_xlDate, out year, out month, out day, out int _, out int _, out int _);
	}

	public void SetDate(int year, int month, int day)
	{
		_xlDate = CalendarDateToXLDate(year, month, day, 0, 0, 0);
	}

	public void GetDate(out int year, out int month, out int day, out int hour, out int minute, out int second)
	{
		XLDateToCalendarDate(_xlDate, out year, out month, out day, out hour, out minute, out second);
	}

	public void SetDate(int year, int month, int day, int hour, int minute, int second)
	{
		_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
	}

	public double GetDayOfYear()
	{
		return XLDateToDayOfYear(_xlDate);
	}

	public static double CalendarDateToXLDate(int year, int month, int day, int hour, int minute, int second, int millisecond)
	{
		double millisecond2 = millisecond;
		NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref millisecond2);
		return _CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond2);
	}

	public static double CalendarDateToXLDate(int year, int month, int day, int hour, int minute, int second)
	{
		double millisecond = 0.0;
		NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref millisecond);
		return _CalendarDateToXLDate(year, month, day, hour, minute, second, millisecond);
	}

	public static double CalendarDateToXLDate(int year, int month, int day, int hour, int minute, double second)
	{
		int second2 = (int)second;
		double millisecond = (second - (double)second2) * 1000.0;
		NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second2, ref millisecond);
		return _CalendarDateToXLDate(year, month, day, hour, minute, second2, millisecond);
	}

	public static double CalendarDateToJulianDay(int year, int month, int day, int hour, int minute, int second)
	{
		double millisecond = 0.0;
		NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref millisecond);
		return _CalendarDateToJulianDay(year, month, day, hour, minute, second, millisecond);
	}

	public static double CalendarDateToJulianDay(int year, int month, int day, int hour, int minute, int second, int millisecond)
	{
		double millisecond2 = millisecond;
		NormalizeCalendarDate(ref year, ref month, ref day, ref hour, ref minute, ref second, ref millisecond2);
		return _CalendarDateToJulianDay(year, month, day, hour, minute, second, millisecond2);
	}

	private static void NormalizeCalendarDate(ref int year, ref int month, ref int day, ref int hour, ref int minute, ref int second, ref double millisecond)
	{
		int num = (int)Math.Floor(millisecond / 1000.0);
		millisecond -= num * 1000;
		second += num;
		num = (int)Math.Floor((double)second / 60.0);
		second -= num * 60;
		minute += num;
		num = (int)Math.Floor((double)minute / 60.0);
		minute -= num * 60;
		hour += num;
		num = (int)Math.Floor((double)hour / 24.0);
		hour -= num * 24;
		day += num;
		num = (int)Math.Floor((double)month / 12.0);
		month -= num * 12;
		year += num;
	}

	private static double _CalendarDateToXLDate(int year, int month, int day, int hour, int minute, int second, double millisecond)
	{
		return JulianDayToXLDate(_CalendarDateToJulianDay(year, month, day, hour, minute, second, millisecond));
	}

	private static double _CalendarDateToJulianDay(int year, int month, int day, int hour, int minute, int second, double millisecond)
	{
		if (month <= 2)
		{
			year--;
			month += 12;
		}
		double num = Math.Floor((double)year / 100.0);
		double num2 = 2.0 - num + Math.Floor(num / 4.0);
		return Math.Floor(365.25 * ((double)year + 4716.0)) + Math.Floor(30.6001 * (double)(month + 1)) + (double)day + num2 - 1524.5 + (double)hour / 24.0 + (double)minute / 1440.0 + (double)second / 86400.0 + millisecond / 86400000.0;
	}

	public static void XLDateToCalendarDate(double xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second)
	{
		double jDay = XLDateToJulianDay(xlDate);
		JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out second);
	}

	public static void XLDateToCalendarDate(double xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second, out int millisecond)
	{
		double jDay = XLDateToJulianDay(xlDate);
		JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out second, out var millisecond2);
		millisecond = (int)millisecond2;
	}

	public static void XLDateToCalendarDate(double xlDate, out int year, out int month, out int day, out int hour, out int minute, out double second)
	{
		double jDay = XLDateToJulianDay(xlDate);
		JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out second);
	}

	public static void JulianDayToCalendarDate(double jDay, out int year, out int month, out int day, out int hour, out int minute, out int second)
	{
		double millisecond = 0.0;
		JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out second, out millisecond);
	}

	public static void JulianDayToCalendarDate(double jDay, out int year, out int month, out int day, out int hour, out int minute, out double second)
	{
		JulianDayToCalendarDate(jDay, out year, out month, out day, out hour, out minute, out var second2, out var millisecond);
		second = (double)second2 + millisecond / 1000.0;
	}

	public static void JulianDayToCalendarDate(double jDay, out int year, out int month, out int day, out int hour, out int minute, out int second, out double millisecond)
	{
		jDay += 5.787037037037037E-09;
		double num = Math.Floor(jDay + 0.5);
		double num2 = jDay + 0.5 - num;
		double num3 = Math.Floor((num - 1867216.25) / 36524.25);
		double num4 = num + 1.0 + num3 - Math.Floor(num3 / 4.0);
		double num5 = num4 + 1524.0;
		double num6 = Math.Floor((num5 - 122.1) / 365.25);
		double num7 = Math.Floor(365.25 * num6);
		double num8 = Math.Floor((num5 - num7) / 30.6001);
		day = (int)Math.Floor(num5 - num7 - Math.Floor(30.6001 * num8) + num2);
		month = (int)((num8 < 14.0) ? (num8 - 1.0) : (num8 - 13.0));
		year = (int)((month > 2) ? (num6 - 4716.0) : (num6 - 4715.0));
		double num9 = jDay - 0.5 - Math.Floor(jDay - 0.5);
		num9 = (num9 - (double)(long)num9) * 24.0;
		hour = (int)num9;
		num9 = (num9 - (double)(long)num9) * 60.0;
		minute = (int)num9;
		num9 = (num9 - (double)(long)num9) * 60.0;
		second = (int)num9;
		num9 = (num9 - (double)(long)num9) * 1000.0;
		millisecond = num9;
	}

	public static double XLDateToJulianDay(double xlDate)
	{
		return xlDate + 2415018.5;
	}

	public static double JulianDayToXLDate(double jDay)
	{
		return jDay - 2415018.5;
	}

	public static double XLDateToDecimalYear(double xlDate)
	{
		XLDateToCalendarDate(xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second);
		double num = CalendarDateToJulianDay(year, 1, 1, 0, 0, 0);
		double num2 = CalendarDateToJulianDay(year + 1, 1, 1, 0, 0, 0);
		double num3 = CalendarDateToJulianDay(year, month, day, hour, minute, second);
		return (double)year + (num3 - num) / (num2 - num);
	}

	public static double DecimalYearToXLDate(double yearDec)
	{
		int num = (int)yearDec;
		double num2 = CalendarDateToJulianDay(num, 1, 1, 0, 0, 0);
		double num3 = CalendarDateToJulianDay(num + 1, 1, 1, 0, 0, 0);
		return JulianDayToXLDate((yearDec - (double)num) * (num3 - num2) + num2);
	}

	public static double XLDateToDayOfYear(double xlDate)
	{
		XLDateToCalendarDate(xlDate, out int year, out int _, out int _, out int _, out int _, out int _);
		return XLDateToJulianDay(xlDate) - CalendarDateToJulianDay(year, 1, 1, 0, 0, 0) + 1.0;
	}

	public static int XLDateToDayOfWeek(double xlDate)
	{
		return (int)(XLDateToJulianDay(xlDate) + 1.5) % 7;
	}

	public static DateTime XLDateToDateTime(double xlDate)
	{
		XLDateToCalendarDate(xlDate, out var year, out var month, out var day, out var hour, out var minute, out var second, out var millisecond);
		return new DateTime(year, month, day, hour, minute, second, millisecond);
	}

	public static double DateTimeToXLDate(DateTime dt)
	{
		return CalendarDateToXLDate(dt.Year, dt.Month, dt.Day, dt.Hour, dt.Minute, dt.Second, dt.Millisecond);
	}

	public void AddMilliseconds(double dMilliseconds)
	{
		_xlDate += dMilliseconds / 86400000.0;
	}

	public void AddSeconds(double dSeconds)
	{
		_xlDate += dSeconds / 86400.0;
	}

	public void AddMinutes(double dMinutes)
	{
		_xlDate += dMinutes / 1440.0;
	}

	public void AddHours(double dHours)
	{
		_xlDate += dHours / 24.0;
	}

	public void AddDays(double dDays)
	{
		_xlDate += dDays;
	}

	public void AddMonths(double dMonths)
	{
		int num = (int)dMonths;
		double num2 = Math.Abs(dMonths - (double)num);
		int num3 = Math.Sign(dMonths);
		XLDateToCalendarDate(_xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second);
		if (num != 0)
		{
			month += num;
			_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
		}
		if (num3 != 0)
		{
			double num4 = CalendarDateToXLDate(year, month + num3, day, hour, minute, second);
			_xlDate += (num4 - _xlDate) * num2;
		}
	}

	public void AddYears(double dYears)
	{
		int num = (int)dYears;
		double num2 = Math.Abs(dYears - (double)num);
		int num3 = Math.Sign(dYears);
		XLDateToCalendarDate(_xlDate, out int year, out int month, out int day, out int hour, out int minute, out int second);
		if (num != 0)
		{
			year += num;
			_xlDate = CalendarDateToXLDate(year, month, day, hour, minute, second);
		}
		if (num3 != 0)
		{
			double num4 = CalendarDateToXLDate(year + num3, month, day, hour, minute, second);
			_xlDate += (num4 - _xlDate) * num2;
		}
	}

	public static double operator -(XDate lhs, XDate rhs)
	{
		return lhs.XLDate - rhs.XLDate;
	}

	public static XDate operator -(XDate lhs, double rhs)
	{
		lhs._xlDate -= rhs;
		return lhs;
	}

	public static XDate operator +(XDate lhs, double rhs)
	{
		lhs._xlDate += rhs;
		return lhs;
	}

	public static XDate operator ++(XDate xDate)
	{
		xDate._xlDate += 1.0;
		return xDate;
	}

	public static XDate operator --(XDate xDate)
	{
		xDate._xlDate -= 1.0;
		return xDate;
	}

	public static implicit operator double(XDate xDate)
	{
		return xDate._xlDate;
	}

	public static implicit operator float(XDate xDate)
	{
		return (float)xDate._xlDate;
	}

	public static implicit operator XDate(double xlDate)
	{
		return new XDate(xlDate);
	}

	public static implicit operator DateTime(XDate xDate)
	{
		return XLDateToDateTime(xDate);
	}

	public static implicit operator XDate(DateTime dt)
	{
		return new XDate(DateTimeToXLDate(dt));
	}

	public override bool Equals(object obj)
	{
		if (obj is XDate)
		{
			return ((XDate)obj)._xlDate == _xlDate;
		}
		if (obj is double)
		{
			return (double)obj == _xlDate;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return _xlDate.GetHashCode();
	}

	public int CompareTo(object target)
	{
		if (!(target is XDate))
		{
			throw new ArgumentException();
		}
		return XLDate.CompareTo(((XDate)target).XLDate);
	}

	public string ToString(double xlDate)
	{
		return ToString(xlDate, "g");
	}

	public override string ToString()
	{
		return ToString(_xlDate, "g");
	}

	public string ToString(string fmtStr)
	{
		return ToString(XLDate, fmtStr);
	}

	public static string ToString(double xlDate, string fmtStr)
	{
		if (!CheckValidDate(xlDate))
		{
			return "Date Error";
		}
		XLDateToCalendarDate(xlDate, out var year, out var month, out var day, out var hour, out var minute, out var second, out var millisecond);
		if (year <= 0)
		{
			year = 1 - year;
			fmtStr += " (BC)";
		}
		if (fmtStr.IndexOf("[d]") >= 0)
		{
			fmtStr = fmtStr.Replace("[d]", ((int)xlDate).ToString());
			xlDate -= (double)(int)xlDate;
		}
		if (fmtStr.IndexOf("[h]") >= 0 || fmtStr.IndexOf("[hh]") >= 0)
		{
			fmtStr = fmtStr.Replace("[h]", ((int)(xlDate * 24.0)).ToString("d"));
			fmtStr = fmtStr.Replace("[hh]", ((int)(xlDate * 24.0)).ToString("d2"));
			xlDate = (xlDate * 24.0 - (double)(int)(xlDate * 24.0)) / 24.0;
		}
		if (fmtStr.IndexOf("[m]") >= 0 || fmtStr.IndexOf("[mm]") >= 0)
		{
			fmtStr = fmtStr.Replace("[m]", ((int)(xlDate * 1440.0)).ToString("d"));
			fmtStr = fmtStr.Replace("[mm]", ((int)(xlDate * 1440.0)).ToString("d2"));
			xlDate = (xlDate * 1440.0 - (double)(int)(xlDate * 1440.0)) / 1440.0;
		}
		if (fmtStr.IndexOf("[s]") >= 0 || fmtStr.IndexOf("[ss]") >= 0)
		{
			fmtStr = fmtStr.Replace("[s]", ((int)(xlDate * 86400.0)).ToString("d"));
			fmtStr = fmtStr.Replace("[ss]", ((int)(xlDate * 86400.0)).ToString("d2"));
			xlDate = (xlDate * 86400.0 - (double)(int)(xlDate * 86400.0)) / 86400.0;
		}
		if (fmtStr.IndexOf("[f]") >= 0)
		{
			fmtStr = fmtStr.Replace("[f]", ((int)(xlDate * 864000.0)).ToString("d"));
		}
		if (fmtStr.IndexOf("[ff]") >= 0)
		{
			fmtStr = fmtStr.Replace("[ff]", ((int)(xlDate * 8640000.0)).ToString("d"));
		}
		if (fmtStr.IndexOf("[fff]") >= 0)
		{
			fmtStr = fmtStr.Replace("[fff]", ((int)(xlDate * 86400000.0)).ToString("d"));
		}
		if (fmtStr.IndexOf("[ffff]") >= 0)
		{
			fmtStr = fmtStr.Replace("[ffff]", ((int)(xlDate * 864000000.0)).ToString("d"));
		}
		if (fmtStr.IndexOf("[fffff]") >= 0)
		{
			fmtStr = fmtStr.Replace("[fffff]", ((int)(xlDate * 8640000000.0)).ToString("d"));
		}
		if (year > 9999)
		{
			year = 9999;
		}
		return new DateTime(year, month, day, hour, minute, second, millisecond).ToString(fmtStr);
	}
}
