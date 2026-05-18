using System;
using System.Collections.Generic;

namespace ZedGraph;

[Serializable]
public class StockPointList : List<StockPt>, IPointListEdit, IPointList, ICloneable
{
	public new PointPair this[int index]
	{
		get
		{
			return base[index];
		}
		set
		{
			base[index] = new StockPt(value);
		}
	}

	public StockPointList()
	{
	}

	public StockPointList(StockPointList rhs)
	{
		for (int i = 0; i < rhs.Count; i++)
		{
			StockPt point = new StockPt(rhs[i]);
			Add(point);
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public StockPointList Clone()
	{
		return new StockPointList(this);
	}

	public new void Add(StockPt point)
	{
		base.Add(new StockPt(point));
	}

	public void Add(PointPair point)
	{
		base.Add(new StockPt(point));
	}

	public void Add(double date, double high)
	{
		Add(new StockPt(date, high, double.MaxValue, double.MaxValue, double.MaxValue, double.MaxValue));
	}

	public void Add(double date, double high, double low, double open, double close, double vol)
	{
		StockPt point = new StockPt(date, high, low, open, close, vol);
		Add(point);
	}

	public StockPt GetAt(int index)
	{
		return base[index];
	}
}
