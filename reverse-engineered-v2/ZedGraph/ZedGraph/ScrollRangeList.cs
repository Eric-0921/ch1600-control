using System;
using System.Collections.Generic;

namespace ZedGraph;

public class ScrollRangeList : List<ScrollRange>, ICloneable
{
	public new ScrollRange this[int index]
	{
		get
		{
			if (index < 0 || index >= base.Count)
			{
				return new ScrollRange(isScrollable: false);
			}
			return base[index];
		}
		set
		{
			base[index] = value;
		}
	}

	public ScrollRangeList()
	{
	}

	public ScrollRangeList(ScrollRangeList rhs)
	{
		foreach (ScrollRange rh in rhs)
		{
			Add(new ScrollRange(rh));
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ScrollRangeList Clone()
	{
		return new ScrollRangeList(this);
	}
}
