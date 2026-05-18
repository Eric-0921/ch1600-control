using System;
using System.Collections.Generic;

namespace ZedGraph;

[Serializable]
public class RadarPointList : List<PointPair>, IPointListEdit, IPointList, ICloneable
{
	private bool _clockwise = true;

	private double _rotation = 90.0;

	public new PointPair this[int index]
	{
		get
		{
			int count = Count;
			if (index == count - 1)
			{
				index = 0;
			}
			if (index < 0 || index >= count)
			{
				return null;
			}
			PointPair pointPair = base[index];
			double num = _rotation * Math.PI / 180.0;
			double num2 = num + (_clockwise ? (-1.0) : 1.0) * ((double)index / (double)(count - 1) * 2.0 * Math.PI);
			double x = pointPair.Y * Math.Cos(num2);
			double y = pointPair.Y * Math.Sin(num2);
			return new PointPair(x, y, pointPair.Z, (string)pointPair.Tag);
		}
		set
		{
			int count = Count;
			if (index == count - 1)
			{
				index = 0;
			}
			if (index >= 0 && index < count)
			{
				PointPair pointPair = base[index];
				pointPair.Y = Math.Sqrt(value.X * value.X + value.Y * value.Y);
			}
		}
	}

	public bool Clockwise
	{
		get
		{
			return _clockwise;
		}
		set
		{
			_clockwise = value;
		}
	}

	public double Rotation
	{
		get
		{
			return _rotation;
		}
		set
		{
			_rotation = value;
		}
	}

	public new int Count => base.Count + 1;

	private PointPair GetAt(int index)
	{
		return base[index];
	}

	public RadarPointList()
	{
	}

	public RadarPointList(RadarPointList rhs)
	{
		for (int i = 0; i < rhs.Count; i++)
		{
			Add(rhs.GetAt(i));
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public RadarPointList Clone()
	{
		return new RadarPointList(this);
	}

	public void Add(double r, double z)
	{
		Add(new PointPair(double.MaxValue, r, z));
	}
}
