using System;
using System.Collections.Generic;

namespace ZedGraph;

[Serializable]
public class NoDupePointList : List<DataPoint>, IPointListEdit, IPointList, ICloneable
{
	protected bool _isFiltered;

	protected int _filteredCount;

	protected int[] _visibleIndicies;

	protected int _filterMode;

	public int FilterMode
	{
		get
		{
			return _filterMode;
		}
		set
		{
			_filterMode = value;
		}
	}

	public bool IsFiltered => _isFiltered;

	public new PointPair this[int index]
	{
		get
		{
			int index2 = index;
			if (_isFiltered)
			{
				index2 = _visibleIndicies[index];
			}
			DataPoint dataPoint = base[index2];
			return new PointPair(dataPoint.X, dataPoint.Y);
		}
		set
		{
			int index2 = index;
			if (_isFiltered)
			{
				index2 = _visibleIndicies[index];
			}
			DataPoint value2 = default(DataPoint);
			value2.X = value.X;
			value2.Y = value.Y;
			base[index2] = value2;
		}
	}

	public new int Count
	{
		get
		{
			if (!_isFiltered)
			{
				return base.Count;
			}
			return _filteredCount;
		}
	}

	public int TotalCount => base.Count;

	public void Add(PointPair pt)
	{
		Add(new DataPoint
		{
			X = pt.X,
			Y = pt.Y
		});
	}

	public void Add(double x, double y)
	{
		Add(new DataPoint
		{
			X = x,
			Y = y
		});
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public NoDupePointList Clone()
	{
		return new NoDupePointList(this);
	}

	public NoDupePointList()
	{
		_isFiltered = false;
		_filteredCount = 0;
		_visibleIndicies = null;
		_filterMode = 0;
	}

	public NoDupePointList(NoDupePointList rhs)
	{
		int totalCount = rhs.TotalCount;
		for (int i = 0; i < totalCount; i++)
		{
			Add(rhs.GetDataPointAt(i));
		}
		_filteredCount = rhs._filteredCount;
		_isFiltered = rhs._isFiltered;
		_filterMode = rhs._filterMode;
		if (rhs._visibleIndicies != null)
		{
			_visibleIndicies = (int[])rhs._visibleIndicies.Clone();
		}
		else
		{
			_visibleIndicies = null;
		}
	}

	protected DataPoint GetDataPointAt(int index)
	{
		return base[index];
	}

	public void ClearFilter()
	{
		_isFiltered = false;
		_filteredCount = 0;
	}

	public void FilterData(GraphPane pane, Axis xAxis, Axis yAxis)
	{
		if (_visibleIndicies == null || _visibleIndicies.Length < base.Count)
		{
			_visibleIndicies = new int[base.Count];
		}
		_filteredCount = 0;
		_isFiltered = true;
		int num = (int)pane.Chart.Rect.Width;
		int num2 = (int)pane.Chart.Rect.Height;
		if (num <= 0 || num2 <= 0)
		{
			throw new IndexOutOfRangeException("Error in FilterData: Chart rect not valid");
		}
		bool[,] array = new bool[num, num2];
		for (int i = 0; i < num; i++)
		{
			for (int j = 0; j < num2; j++)
			{
				array[i, j] = false;
			}
		}
		xAxis.Scale.SetupScaleData(pane, xAxis);
		yAxis.Scale.SetupScaleData(pane, yAxis);
		int num3 = ((_filterMode >= 0) ? _filterMode : 0);
		int num4 = (int)pane.Chart.Rect.Left;
		int num5 = (int)pane.Chart.Rect.Top;
		for (int k = 0; k < base.Count; k++)
		{
			DataPoint dataPoint = base[k];
			int num6 = (int)((double)xAxis.Scale.Transform(dataPoint.X) + 0.5) - num4;
			int num7 = (int)((double)yAxis.Scale.Transform(dataPoint.Y) + 0.5) - num5;
			if (num6 < 0 || num6 >= num || num7 < 0 || num7 >= num2)
			{
				continue;
			}
			bool flag = false;
			if (num3 <= 0)
			{
				flag = array[num6, num7];
			}
			else
			{
				for (int l = num6 - num3; l <= num6 + num3; l++)
				{
					for (int m = num7 - num3; m <= num7 + num3; m++)
					{
						flag |= l >= 0 && l < num && m >= 0 && m < num2 && array[l, m];
					}
				}
			}
			if (!flag)
			{
				array[num6, num7] = true;
				_visibleIndicies[_filteredCount] = k;
				_filteredCount++;
			}
		}
	}
}
