using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class StockPt : PointPair, ISerializable
{
	public const int schema3 = 11;

	public double Open;

	public double Close;

	public double Vol;

	private double _colorValue;

	public double Date
	{
		get
		{
			return X;
		}
		set
		{
			X = value;
		}
	}

	public double High
	{
		get
		{
			return Y;
		}
		set
		{
			Y = value;
		}
	}

	public double Low
	{
		get
		{
			return Z;
		}
		set
		{
			Z = value;
		}
	}

	public override double ColorValue
	{
		get
		{
			return _colorValue;
		}
		set
		{
			_colorValue = value;
		}
	}

	public bool IsInvalid5D
	{
		get
		{
			if (Date != double.MaxValue && Close != double.MaxValue && Open != double.MaxValue && High != double.MaxValue && Low != double.MaxValue && !double.IsInfinity(Date) && !double.IsInfinity(Close) && !double.IsInfinity(Open) && !double.IsInfinity(High) && !double.IsInfinity(Low) && !double.IsNaN(Date) && !double.IsNaN(Close) && !double.IsNaN(Open) && !double.IsNaN(High))
			{
				return double.IsNaN(Low);
			}
			return true;
		}
	}

	public StockPt()
		: this(0.0, 0.0, 0.0, 0.0, 0.0, 0.0, null)
	{
	}

	public StockPt(double date, double high, double low, double open, double close, double vol)
		: this(date, high, low, open, close, vol, null)
	{
	}

	public StockPt(double date, double high, double low, double open, double close, double vol, string tag)
		: base(date, high)
	{
		Low = low;
		Open = open;
		Close = close;
		Vol = vol;
		ColorValue = double.MaxValue;
		Tag = tag;
	}

	public StockPt(StockPt rhs)
		: base(rhs)
	{
		Low = rhs.Low;
		Open = rhs.Open;
		Close = rhs.Close;
		Vol = rhs.Vol;
		ColorValue = rhs.ColorValue;
		if (rhs.Tag is ICloneable)
		{
			Tag = ((ICloneable)rhs.Tag).Clone();
		}
		else
		{
			Tag = rhs.Tag;
		}
	}

	public StockPt(PointPair rhs)
		: base(rhs)
	{
		if (rhs is StockPt)
		{
			StockPt stockPt = rhs as StockPt;
			Open = stockPt.Open;
			Close = stockPt.Close;
			Vol = stockPt.Vol;
			ColorValue = rhs.ColorValue;
		}
		else
		{
			Open = double.MaxValue;
			Close = double.MaxValue;
			Vol = double.MaxValue;
			ColorValue = double.MaxValue;
		}
	}

	protected StockPt(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
		Open = info.GetDouble("Open");
		Close = info.GetDouble("Close");
		Vol = info.GetDouble("Vol");
		ColorValue = info.GetDouble("ColorValue");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema3", 11);
		info.AddValue("Open", Open);
		info.AddValue("Close", Close);
		info.AddValue("Vol", Vol);
		info.AddValue("ColorValue", ColorValue);
	}

	public override string ToString(bool isShowAll)
	{
		return ToString("G", isShowAll);
	}

	public override string ToString(string format, bool isShowAll)
	{
		return "( " + XDate.ToString(Date, "g") + ", " + Close.ToString(format) + (isShowAll ? (", " + Low.ToString(format) + ", " + Open.ToString(format) + ", " + Close.ToString(format)) : "") + " )";
	}
}
