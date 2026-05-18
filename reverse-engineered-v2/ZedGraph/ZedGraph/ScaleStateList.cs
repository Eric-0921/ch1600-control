using System;
using System.Collections.Generic;

namespace ZedGraph;

public class ScaleStateList : List<ScaleState>, ICloneable
{
	public ScaleStateList(YAxisList list)
	{
		foreach (YAxis item in list)
		{
			Add(new ScaleState(item));
		}
	}

	public ScaleStateList(Y2AxisList list)
	{
		foreach (Y2Axis item in list)
		{
			Add(new ScaleState(item));
		}
	}

	public ScaleStateList(ScaleStateList rhs)
	{
		foreach (ScaleState rh in rhs)
		{
			Add(rh.Clone());
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ScaleStateList Clone()
	{
		return new ScaleStateList(this);
	}

	public bool IsChanged(YAxisList list)
	{
		int num = Math.Min(list.Count, base.Count);
		for (int i = 0; i < num; i++)
		{
			if (base[i].IsChanged(list[i]))
			{
				return true;
			}
		}
		return false;
	}

	public bool IsChanged(Y2AxisList list)
	{
		int num = Math.Min(list.Count, base.Count);
		for (int i = 0; i < num; i++)
		{
			if (base[i].IsChanged(list[i]))
			{
				return true;
			}
		}
		return false;
	}

	public void ApplyScale(YAxisList list)
	{
		int num = Math.Min(list.Count, base.Count);
		for (int i = 0; i < num; i++)
		{
			base[i].ApplyScale(list[i]);
		}
	}

	public void ApplyScale(Y2AxisList list)
	{
		int num = Math.Min(list.Count, base.Count);
		for (int i = 0; i < num; i++)
		{
			base[i].ApplyScale(list[i]);
		}
	}
}
