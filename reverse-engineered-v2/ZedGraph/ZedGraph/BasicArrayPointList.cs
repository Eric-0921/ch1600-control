using System;

namespace ZedGraph;

[Serializable]
public class BasicArrayPointList : IPointList, ICloneable
{
	public double[] x;

	public double[] y;

	public PointPair this[int index]
	{
		get
		{
			double num = ((index < 0 || index >= x.Length) ? double.MaxValue : x[index]);
			double num2 = ((index < 0 || index >= y.Length) ? double.MaxValue : y[index]);
			return new PointPair(num, num2, double.MaxValue, null);
		}
		set
		{
			if (index >= 0 && index < x.Length)
			{
				x[index] = value.X;
			}
			if (index >= 0 && index < y.Length)
			{
				y[index] = value.Y;
			}
		}
	}

	public int Count
	{
		get
		{
			if (x.Length <= y.Length)
			{
				return y.Length;
			}
			return x.Length;
		}
	}

	public BasicArrayPointList(double[] x, double[] y)
	{
		this.x = x;
		this.y = y;
	}

	public BasicArrayPointList(BasicArrayPointList rhs)
	{
		x = (double[])rhs.x.Clone();
		y = (double[])rhs.y.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public BasicArrayPointList Clone()
	{
		return new BasicArrayPointList(this);
	}
}
