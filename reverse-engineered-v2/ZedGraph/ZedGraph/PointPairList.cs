using System;
using System.Collections.Generic;

namespace ZedGraph;

[Serializable]
public class PointPairList : List<PointPair>, IPointListEdit, IPointList, ICloneable
{
	protected bool _sorted = true;

	public bool Sorted => _sorted;

	public PointPairList()
	{
		_sorted = false;
	}

	public PointPairList(double[] x, double[] y)
	{
		Add(x, y);
		_sorted = false;
	}

	public PointPairList(IPointList list)
	{
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			Add(list[i]);
		}
		_sorted = false;
	}

	public PointPairList(double[] x, double[] y, double[] baseVal)
	{
		Add(x, y, baseVal);
		_sorted = false;
	}

	public PointPairList(PointPairList rhs)
	{
		Add(rhs);
		_sorted = false;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public PointPairList Clone()
	{
		return new PointPairList(this);
	}

	public new void Add(PointPair point)
	{
		_sorted = false;
		base.Add(point.Clone());
	}

	public void Add(PointPairList pointList)
	{
		foreach (PointPair point in pointList)
		{
			Add(point);
		}
		_sorted = false;
	}

	public void Add(double[] x, double[] y)
	{
		int num = 0;
		if (x != null)
		{
			num = x.Length;
		}
		if (y != null && y.Length > num)
		{
			num = y.Length;
		}
		for (int i = 0; i < num; i++)
		{
			PointPair pointPair = new PointPair(0.0, 0.0, 0.0);
			if (x == null)
			{
				pointPair.X = (double)i + 1.0;
			}
			else if (i < x.Length)
			{
				pointPair.X = x[i];
			}
			else
			{
				pointPair.X = double.MaxValue;
			}
			if (y == null)
			{
				pointPair.Y = (double)i + 1.0;
			}
			else if (i < y.Length)
			{
				pointPair.Y = y[i];
			}
			else
			{
				pointPair.Y = double.MaxValue;
			}
			base.Add(pointPair);
		}
		_sorted = false;
	}

	public void Add(double[] x, double[] y, double[] z)
	{
		int num = 0;
		if (x != null)
		{
			num = x.Length;
		}
		if (y != null && y.Length > num)
		{
			num = y.Length;
		}
		if (z != null && z.Length > num)
		{
			num = z.Length;
		}
		for (int i = 0; i < num; i++)
		{
			PointPair pointPair = new PointPair();
			if (x == null)
			{
				pointPair.X = (double)i + 1.0;
			}
			else if (i < x.Length)
			{
				pointPair.X = x[i];
			}
			else
			{
				pointPair.X = double.MaxValue;
			}
			if (y == null)
			{
				pointPair.Y = (double)i + 1.0;
			}
			else if (i < y.Length)
			{
				pointPair.Y = y[i];
			}
			else
			{
				pointPair.Y = double.MaxValue;
			}
			if (z == null)
			{
				pointPair.Z = (double)i + 1.0;
			}
			else if (i < z.Length)
			{
				pointPair.Z = z[i];
			}
			else
			{
				pointPair.Z = double.MaxValue;
			}
			base.Add(pointPair);
		}
		_sorted = false;
	}

	public void Add(double x, double y)
	{
		_sorted = false;
		PointPair item = new PointPair(x, y);
		base.Add(item);
	}

	public void Add(double x, double y, string tag)
	{
		_sorted = false;
		PointPair item = new PointPair(x, y, tag);
		base.Add(item);
	}

	public void Add(double x, double y, double z)
	{
		_sorted = false;
		PointPair item = new PointPair(x, y, z);
		base.Add(item);
	}

	public void Add(double x, double y, double z, string tag)
	{
		_sorted = false;
		PointPair item = new PointPair(x, y, z, tag);
		base.Add(item);
	}

	public new void Insert(int index, PointPair point)
	{
		_sorted = false;
		base.Insert(index, point);
	}

	public void Insert(int index, double x, double y)
	{
		_sorted = false;
		base.Insert(index, new PointPair(x, y));
	}

	public void Insert(int index, double x, double y, double z)
	{
		_sorted = false;
		Insert(index, new PointPair(x, y, z));
	}

	public int IndexOfTag(string label)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				PointPair current = enumerator.Current;
				if (current.Tag is string && string.Compare((string)current.Tag, label, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public override bool Equals(object obj)
	{
		PointPairList pointPairList = obj as PointPairList;
		if (base.Count != pointPairList.Count)
		{
			return false;
		}
		for (int i = 0; i < base.Count; i++)
		{
			if (!base[i].Equals(pointPairList[i]))
			{
				return false;
			}
		}
		return true;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public new bool Sort()
	{
		if (_sorted)
		{
			return true;
		}
		Sort(new PointPair.PointPairComparer(SortType.XValues));
		return false;
	}

	public bool Sort(SortType type)
	{
		if (_sorted)
		{
			return true;
		}
		Sort(new PointPair.PointPairComparer(type));
		return false;
	}

	public void SetX(double[] x)
	{
		for (int i = 0; i < x.Length; i++)
		{
			if (i < base.Count)
			{
				base[i].X = x[i];
			}
		}
		_sorted = false;
	}

	public void SetY(double[] y)
	{
		for (int i = 0; i < y.Length; i++)
		{
			if (i < base.Count)
			{
				base[i].Y = y[i];
			}
		}
		_sorted = false;
	}

	public void SetZ(double[] z)
	{
		for (int i = 0; i < z.Length; i++)
		{
			if (i < base.Count)
			{
				base[i].Z = z[i];
			}
		}
		_sorted = false;
	}

	public void SumY(PointPairList sumList)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (i < sumList.Count)
			{
				base[i].Y += sumList[i].Y;
			}
		}
	}

	public void SumX(PointPairList sumList)
	{
		for (int i = 0; i < base.Count; i++)
		{
			if (i < sumList.Count)
			{
				base[i].X += sumList[i].X;
			}
		}
		_sorted = false;
	}

	public double InterpolateX(double xTarget)
	{
		if (base.Count < 2)
		{
			throw new Exception("Error: Not enough points in curve to interpolate");
		}
		int num;
		int num2;
		if (xTarget <= base[0].X)
		{
			num = 0;
			num2 = 1;
		}
		else if (xTarget >= base[base.Count - 1].X)
		{
			num = base.Count - 2;
			num2 = base.Count - 1;
		}
		else
		{
			num = 0;
			num2 = base.Count - 1;
			int i;
			for (i = 0; i < 1000; i++)
			{
				if (num2 <= num + 1)
				{
					break;
				}
				int num3 = (num2 + num) / 2;
				if (xTarget > base[num3].X)
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			if (i >= 1000)
			{
				throw new Exception("Error: Infinite loop in interpolation");
			}
		}
		return (xTarget - base[num].X) / (base[num2].X - base[num].X) * (base[num2].Y - base[num].Y) + base[num].Y;
	}

	public double SplineInterpolateX(double xTarget, double tension)
	{
		tension /= 3.0;
		if (base.Count < 2)
		{
			throw new Exception("Error: Not enough points in curve to interpolate");
		}
		if (xTarget <= base[0].X || xTarget >= base[base.Count - 1].X)
		{
			return double.MaxValue;
		}
		int num = 0;
		int num2 = base.Count - 1;
		int i;
		for (i = 0; i < 1000; i++)
		{
			if (num2 <= num + 1)
			{
				break;
			}
			int num3 = (num2 + num) / 2;
			if (xTarget > base[num3].X)
			{
				num = num3;
			}
			else
			{
				num2 = num3;
			}
		}
		if (i >= 1000)
		{
			throw new Exception("Error: Infinite loop in interpolation");
		}
		double x = base[num].X;
		double x2 = base[num2].X;
		double y = base[num].Y;
		double y2 = base[num2].Y;
		double num4;
		double num5;
		if (num == 0)
		{
			num4 = x - (x2 - x) / 3.0;
			num5 = y - (y2 - y) / 3.0;
		}
		else
		{
			num4 = base[num - 1].X;
			num5 = base[num - 1].Y;
		}
		double num6;
		double num7;
		if (num2 == base.Count - 1)
		{
			num6 = x2 + (x2 - x) / 3.0;
			num7 = y2 + (y2 - y) / 3.0;
		}
		else
		{
			num6 = base[num2 + 1].X;
			num7 = base[num2 + 1].Y;
		}
		double num8 = x;
		double num9 = y;
		for (double num10 = 0.01; num10 <= 1.0; num10 += 0.01)
		{
			double num11 = (1.0 - num10) * (1.0 - num10) * (1.0 - num10);
			double num12 = 3.0 * num10 * (1.0 - num10) * (1.0 - num10);
			double num13 = 3.0 * num10 * num10 * (1.0 - num10);
			double num14 = num10 * num10 * num10;
			double num15 = x * num11 + (x + (x2 - num4) * tension) * num12 + (x2 - (num6 - x) * tension) * num13 + x2 * num14;
			double num16 = y * num11 + (y + (y2 - num5) * tension) * num12 + (y2 - (num7 - y) * tension) * num13 + y2 * num14;
			if (num15 >= xTarget)
			{
				return (xTarget - num8) / (num15 - num8) * (num16 - num9) + num9;
			}
			num8 = num15;
			num9 = num16;
		}
		return y2;
	}

	public double InterpolateY(double yTarget)
	{
		if (base.Count < 2)
		{
			throw new Exception("Error: Not enough points in curve to interpolate");
		}
		int num;
		int num2;
		if (yTarget <= base[0].Y)
		{
			num = 0;
			num2 = 1;
		}
		else if (yTarget >= base[base.Count - 1].Y)
		{
			num = base.Count - 2;
			num2 = base.Count - 1;
		}
		else
		{
			num = 0;
			num2 = base.Count - 1;
			int i;
			for (i = 0; i < 1000; i++)
			{
				if (num2 <= num + 1)
				{
					break;
				}
				int num3 = (num2 + num) / 2;
				if (yTarget > base[num3].Y)
				{
					num = num3;
				}
				else
				{
					num2 = num3;
				}
			}
			if (i >= 1000)
			{
				throw new Exception("Error: Infinite loop in interpolation");
			}
		}
		return (yTarget - base[num].Y) / (base[num2].Y - base[num].Y) * (base[num2].X - base[num].X) + base[num].X;
	}

	public PointPairList LinearRegression(IPointList points, int pointCount)
	{
		double num = double.MaxValue;
		double num2 = double.MinValue;
		for (int i = 0; i < points.Count; i++)
		{
			PointPair pointPair = points[i];
			if (!pointPair.IsInvalid)
			{
				num = ((pointPair.X < num) ? pointPair.X : num);
				num2 = ((pointPair.X > num2) ? pointPair.X : num2);
			}
		}
		return LinearRegression(points, pointCount, num, num2);
	}

	public PointPairList LinearRegression(IPointList points, int pointCount, double minX, double maxX)
	{
		double num = 0.0;
		double num2 = 0.0;
		double num3 = 0.0;
		double num4 = 0.0;
		double num5 = 0.0;
		for (int i = 0; i < points.Count; i++)
		{
			PointPair pointPair = points[i];
			if (!pointPair.IsInvalid)
			{
				num += points[i].X;
				num2 += points[i].Y;
				num3 += points[i].X * points[i].X;
				num4 += points[i].X * points[i].Y;
				num5 += 1.0;
			}
		}
		if (num5 < 2.0 || maxX - minX < 1E-20)
		{
			return null;
		}
		double num6 = (num5 * num4 - num * num2) / (num5 * num3 - num * num);
		double num7 = (num2 - num6 * num) / num5;
		PointPairList pointPairList = new PointPairList();
		double num8 = (maxX - minX) / (double)pointCount;
		double num9 = minX;
		for (int j = 0; j < pointCount; j++)
		{
			pointPairList.Add(new PointPair(num9, num9 * num6 + num7));
			num9 += num8;
		}
		return pointPairList;
	}
}
