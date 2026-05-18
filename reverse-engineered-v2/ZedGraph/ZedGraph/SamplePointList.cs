using System;
using System.Collections;

namespace ZedGraph;

[Serializable]
public class SamplePointList : IPointList, ICloneable
{
	public SampleType XType;

	public SampleType YType;

	private ArrayList list;

	public PointPair this[int index]
	{
		get
		{
			PointPair pointPair = new PointPair();
			Sample sample = (Sample)list[index];
			pointPair.X = GetValue(sample, XType);
			pointPair.Y = GetValue(sample, YType);
			return pointPair;
		}
	}

	public int Count => list.Count;

	public double GetValue(Sample sample, SampleType type)
	{
		switch (type)
		{
		case SampleType.Position:
			return sample.Position;
		case SampleType.Time:
			return sample.Time.ToOADate();
		case SampleType.TimeDiff:
			return sample.Time.ToOADate() - ((Sample)list[0]).Time.ToOADate();
		case SampleType.VelocityAvg:
		{
			double num = sample.Time.ToOADate() - ((Sample)list[0]).Time.ToOADate();
			if (num <= 0.0)
			{
				return double.MaxValue;
			}
			return (sample.Position - ((Sample)list[0]).Position) / num;
		}
		case SampleType.VelocityInst:
			return sample.Velocity;
		default:
			return double.MaxValue;
		}
	}

	public int Add(Sample sample)
	{
		return list.Add(sample);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public SamplePointList Clone()
	{
		return new SamplePointList(this);
	}

	public SamplePointList()
	{
		XType = SampleType.Time;
		YType = SampleType.Position;
		list = new ArrayList();
	}

	public SamplePointList(SamplePointList rhs)
	{
		XType = rhs.XType;
		YType = rhs.YType;
		list = rhs.list;
	}
}
