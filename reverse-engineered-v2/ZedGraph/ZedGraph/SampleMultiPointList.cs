using System;
using System.Collections;

namespace ZedGraph;

[Serializable]
public class SampleMultiPointList : IPointList, ICloneable
{
	private ArrayList DataCollection;

	public PerfDataType XData;

	public PerfDataType YData;

	public PointPair this[int index]
	{
		get
		{
			double x;
			double y;
			if (index >= 0 && index < Count)
			{
				PerformanceData performanceData = (PerformanceData)DataCollection[index];
				x = performanceData[XData];
				y = performanceData[YData];
			}
			else
			{
				x = double.MaxValue;
				y = double.MaxValue;
			}
			return new PointPair(x, y, double.MaxValue, null);
		}
	}

	public int Count => DataCollection.Count;

	public SampleMultiPointList()
	{
		XData = PerfDataType.Time;
		YData = PerfDataType.Distance;
		DataCollection = new ArrayList();
	}

	public SampleMultiPointList(SampleMultiPointList rhs)
	{
		DataCollection = rhs.DataCollection;
		XData = rhs.XData;
		YData = rhs.YData;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public SampleMultiPointList Clone()
	{
		return new SampleMultiPointList(this);
	}

	public int Add(PerformanceData perfData)
	{
		return DataCollection.Add(perfData);
	}

	public void RemoveAt(int index)
	{
		DataCollection.RemoveAt(index);
	}

	public void Insert(int index, PerformanceData perfData)
	{
		DataCollection.Insert(index, perfData);
	}
}
