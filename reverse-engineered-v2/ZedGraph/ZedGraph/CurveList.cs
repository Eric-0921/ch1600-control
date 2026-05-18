using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZedGraph;

[Serializable]
public class CurveList : List<CurveItem>, ICloneable
{
	private int maxPts;

	public int MaxPts => maxPts;

	public int NumBars
	{
		get
		{
			int num = 0;
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (current.IsBar)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int NumClusterableBars
	{
		get
		{
			int num = 0;
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (current.IsBar || current is HiLowBarItem)
				{
					num++;
				}
			}
			return num;
		}
	}

	public int NumPies
	{
		get
		{
			int num = 0;
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (current.IsPie)
				{
					num++;
				}
			}
			return num;
		}
	}

	public bool IsPieOnly
	{
		get
		{
			bool result = false;
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (!current.IsPie)
				{
					return false;
				}
				result = true;
			}
			return result;
		}
	}

	public IEnumerable<CurveItem> Backward
	{
		get
		{
			for (int i = base.Count - 1; i >= 0; i--)
			{
				yield return base[i];
			}
		}
	}

	public IEnumerable<CurveItem> Forward
	{
		get
		{
			for (int i = 0; i < base.Count; i++)
			{
				yield return base[i];
			}
		}
	}

	public CurveItem this[string label]
	{
		get
		{
			int num = IndexOf(label);
			if (num >= 0)
			{
				return base[num];
			}
			return null;
		}
	}

	public bool HasData()
	{
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (current.Points.Count > 0)
				{
					return true;
				}
			}
		}
		return false;
	}

	public CurveList()
	{
		maxPts = 1;
	}

	public CurveList(CurveList rhs)
	{
		maxPts = rhs.maxPts;
		foreach (CurveItem rh in rhs)
		{
			Add((CurveItem)((ICloneable)rh).Clone());
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public CurveList Clone()
	{
		return new CurveList(this);
	}

	public int IndexOf(string label)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (string.Compare(current._label._text, label, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public int IndexOfTag(string tag)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (current.Tag is string && string.Compare((string)current.Tag, tag, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public void Sort(SortType type, int index)
	{
		Sort(new CurveItem.Comparer(type, index));
	}

	public int Move(int index, int relativePos)
	{
		if (index < 0 || index >= base.Count)
		{
			return -1;
		}
		CurveItem item = base[index];
		RemoveAt(index);
		index += relativePos;
		if (index < 0)
		{
			index = 0;
		}
		if (index > base.Count)
		{
			index = base.Count;
		}
		Insert(index, item);
		return index;
	}

	public void GetRange(bool bIgnoreInitial, bool isBoundedRanges, GraphPane pane)
	{
		InitScale(pane.XAxis.Scale, isBoundedRanges);
		InitScale(pane.X2Axis.Scale, isBoundedRanges);
		foreach (YAxis yAxis in pane.YAxisList)
		{
			InitScale(yAxis.Scale, isBoundedRanges);
		}
		foreach (Y2Axis y2Axis in pane.Y2AxisList)
		{
			InitScale(y2Axis.Scale, isBoundedRanges);
		}
		maxPts = 1;
		using (Enumerator enumerator3 = GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				CurveItem current3 = enumerator3.Current;
				if (!current3.IsVisible)
				{
					continue;
				}
				double tXMinVal;
				double tYMinVal;
				double tXMaxVal;
				double tYMaxVal;
				if ((current3 is BarItem && (pane._barSettings.Type == BarType.Stack || pane._barSettings.Type == BarType.PercentStack)) || (current3 is LineItem && pane.LineType == LineType.Stack))
				{
					GetStackRange(pane, current3, out tXMinVal, out tYMinVal, out tXMaxVal, out tYMaxVal);
				}
				else
				{
					current3.GetRange(out tXMinVal, out tXMaxVal, out tYMinVal, out tYMaxVal, bIgnoreInitial, isBoundedRanges: true, pane);
				}
				Scale scale = current3.GetYAxis(pane).Scale;
				Scale scale2 = current3.GetXAxis(pane).Scale;
				bool isAnyOrdinal = scale.IsAnyOrdinal;
				bool isAnyOrdinal2 = scale2.IsAnyOrdinal;
				if (isAnyOrdinal && !current3.IsOverrideOrdinal)
				{
					tYMinVal = 1.0;
					tYMaxVal = current3.NPts;
				}
				if (isAnyOrdinal2 && !current3.IsOverrideOrdinal)
				{
					tXMinVal = 1.0;
					tXMaxVal = current3.NPts;
				}
				if (current3.IsBar)
				{
					if (pane._barSettings.Base == BarBase.X || pane._barSettings.Base == BarBase.X2)
					{
						if (!(current3 is HiLowBarItem))
						{
							if (tYMinVal > 0.0)
							{
								tYMinVal = 0.0;
							}
							else if (tYMaxVal < 0.0)
							{
								tYMaxVal = 0.0;
							}
						}
						if (!isAnyOrdinal2)
						{
							tXMinVal -= pane._barSettings._clusterScaleWidth / 2.0;
							tXMaxVal += pane._barSettings._clusterScaleWidth / 2.0;
						}
					}
					else
					{
						if (!(current3 is HiLowBarItem))
						{
							if (tXMinVal > 0.0)
							{
								tXMinVal = 0.0;
							}
							else if (tXMaxVal < 0.0)
							{
								tXMaxVal = 0.0;
							}
						}
						if (!isAnyOrdinal)
						{
							tYMinVal -= pane._barSettings._clusterScaleWidth / 2.0;
							tYMaxVal += pane._barSettings._clusterScaleWidth / 2.0;
						}
					}
				}
				if (current3.NPts > maxPts)
				{
					maxPts = current3.NPts;
				}
				if (tYMinVal < scale._rangeMin)
				{
					scale._rangeMin = tYMinVal;
				}
				if (tYMaxVal > scale._rangeMax)
				{
					scale._rangeMax = tYMaxVal;
				}
				if (tXMinVal < scale2._rangeMin)
				{
					scale2._rangeMin = tXMinVal;
				}
				if (tXMaxVal > scale2._rangeMax)
				{
					scale2._rangeMax = tXMaxVal;
				}
			}
		}
		pane.XAxis.Scale.SetRange(pane, pane.XAxis);
		pane.X2Axis.Scale.SetRange(pane, pane.X2Axis);
		foreach (YAxis yAxis2 in pane.YAxisList)
		{
			yAxis2.Scale.SetRange(pane, yAxis2);
		}
		foreach (Y2Axis y2Axis2 in pane.Y2AxisList)
		{
			y2Axis2.Scale.SetRange(pane, y2Axis2);
		}
	}

	private void InitScale(Scale scale, bool isBoundedRanges)
	{
		scale._rangeMin = double.MaxValue;
		scale._rangeMax = double.MinValue;
		scale._lBound = ((isBoundedRanges && !scale._minAuto) ? scale._min : double.MinValue);
		scale._uBound = ((isBoundedRanges && !scale._maxAuto) ? scale._max : double.MaxValue);
	}

	private void GetStackRange(GraphPane pane, CurveItem curve, out double tXMinVal, out double tYMinVal, out double tXMaxVal, out double tYMaxVal)
	{
		tXMinVal = (tYMinVal = double.MaxValue);
		tXMaxVal = (tYMaxVal = double.MinValue);
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		Axis axis = curve.BaseAxis(pane);
		bool flag = axis is XAxis || axis is X2Axis;
		for (int i = 0; i < curve.Points.Count; i++)
		{
			valueHandler.GetValues(curve, i, out var baseVal, out var lowVal, out var hiVal);
			double num = (flag ? baseVal : hiVal);
			double num2 = (flag ? hiVal : baseVal);
			if (num == double.MaxValue || num2 == double.MaxValue || lowVal == double.MaxValue)
			{
				continue;
			}
			if (num < tXMinVal)
			{
				tXMinVal = num;
			}
			if (num > tXMaxVal)
			{
				tXMaxVal = num;
			}
			if (num2 < tYMinVal)
			{
				tYMinVal = num2;
			}
			if (num2 > tYMaxVal)
			{
				tYMaxVal = num2;
			}
			if (!flag)
			{
				if (lowVal < tXMinVal)
				{
					tXMinVal = lowVal;
				}
				if (lowVal > tXMaxVal)
				{
					tXMaxVal = lowVal;
				}
			}
			else
			{
				if (lowVal < tYMinVal)
				{
					tYMinVal = lowVal;
				}
				if (lowVal > tYMaxVal)
				{
					tYMaxVal = lowVal;
				}
			}
		}
	}

	public void Draw(Graphics g, GraphPane pane, float scaleFactor)
	{
		int num = NumBars;
		if (pane._barSettings.Type == BarType.SortedOverlay)
		{
			CurveList curveList = new CurveList();
			using (Enumerator enumerator = GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					CurveItem current = enumerator.Current;
					if (current.IsBar)
					{
						curveList.Add(current);
					}
				}
			}
			for (int i = 0; i < maxPts; i++)
			{
				curveList.Sort((pane._barSettings.Base != BarBase.X) ? SortType.XValues : SortType.YValues, i);
				foreach (BarItem item in curveList)
				{
					item.Bar.DrawSingleBar(g, pane, item, item.BaseAxis(pane), item.ValueAxis(pane), 0, i, item.GetBarWidth(pane), scaleFactor);
				}
			}
		}
		for (int num2 = base.Count - 1; num2 >= 0; num2--)
		{
			CurveItem curveItem = base[num2];
			if (curveItem.IsBar)
			{
				num--;
			}
			if (!curveItem.IsBar || pane._barSettings.Type != BarType.SortedOverlay)
			{
				curveItem.Draw(g, pane, num, scaleFactor);
			}
		}
	}

	public int GetBarItemPos(GraphPane pane, BarItem barItem)
	{
		if (pane._barSettings.Type == BarType.Overlay || pane._barSettings.Type == BarType.Stack || pane._barSettings.Type == BarType.PercentStack)
		{
			return 0;
		}
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				CurveItem current = enumerator.Current;
				if (current == barItem)
				{
					return num;
				}
				if (current is BarItem)
				{
					num++;
				}
			}
		}
		return -1;
	}
}
