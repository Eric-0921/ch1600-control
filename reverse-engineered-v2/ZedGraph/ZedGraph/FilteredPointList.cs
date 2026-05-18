using System;

namespace ZedGraph;

[Serializable]
public class FilteredPointList : IPointList, ICloneable
{
	private double[] _x;

	private double[] _y;

	private int _maxPts = -1;

	private int _minBoundIndex = -1;

	private int _maxBoundIndex = -1;

	public PointPair this[int index]
	{
		get
		{
			if (_minBoundIndex >= 0 && _maxBoundIndex >= 0 && _maxPts >= 0)
			{
				int num = _maxBoundIndex - _minBoundIndex + 1;
				index = ((num <= _maxPts) ? (index + _minBoundIndex) : (_minBoundIndex + (int)((double)index * (double)num / (double)_maxPts)));
			}
			double x = ((index < 0 || index >= _x.Length) ? double.MaxValue : _x[index]);
			double y = ((index < 0 || index >= _y.Length) ? double.MaxValue : _y[index]);
			return new PointPair(x, y, double.MaxValue, null);
		}
		set
		{
			if (_minBoundIndex >= 0 && _maxBoundIndex >= 0 && _maxPts >= 0)
			{
				int num = _maxBoundIndex - _minBoundIndex + 1;
				index = ((num <= _maxPts) ? (index + _minBoundIndex) : (_minBoundIndex + (int)((double)index * (double)num / (double)_maxPts)));
			}
			if (index >= 0 && index < _x.Length)
			{
				_x[index] = value.X;
			}
			if (index >= 0 && index < _y.Length)
			{
				_y[index] = value.Y;
			}
		}
	}

	public int Count
	{
		get
		{
			int num = _x.Length;
			if (_minBoundIndex >= 0 && _maxBoundIndex >= 0 && _maxPts > 0)
			{
				int num2 = _maxBoundIndex - _minBoundIndex + 1;
				if (num2 < num)
				{
					num = num2;
				}
				if (num > _maxPts)
				{
					num = _maxPts;
				}
			}
			return num;
		}
	}

	public int MaxPts => _maxPts;

	public FilteredPointList(double[] x, double[] y)
	{
		_x = x;
		_y = y;
	}

	public FilteredPointList(FilteredPointList rhs)
	{
		_x = (double[])rhs._x.Clone();
		_y = (double[])rhs._y.Clone();
		_minBoundIndex = rhs._minBoundIndex;
		_maxBoundIndex = rhs._maxBoundIndex;
		_maxPts = rhs._maxPts;
	}

	public virtual object Clone()
	{
		return new FilteredPointList(this);
	}

	public void SetBounds(double min, double max, int maxPts)
	{
		_maxPts = maxPts;
		int num = Array.BinarySearch(_x, min);
		int num2 = Array.BinarySearch(_x, max);
		if (num < 0)
		{
			num = ((num != -1) ? (~(num + 1)) : 0);
		}
		if (num2 < 0)
		{
			num2 = ~num2;
		}
		_minBoundIndex = num;
		_maxBoundIndex = num2;
	}
}
