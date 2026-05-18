using System;
using System.Collections.Generic;

namespace ZedGraph;

[Serializable]
public class Y2AxisList : List<Y2Axis>, ICloneable
{
	public new Y2Axis this[int index]
	{
		get
		{
			if (index >= 0 && index < base.Count)
			{
				return base[index];
			}
			return null;
		}
	}

	public Y2Axis this[string title]
	{
		get
		{
			int num = IndexOf(title);
			if (num >= 0)
			{
				return this[num];
			}
			return null;
		}
	}

	public Y2AxisList()
	{
	}

	public Y2AxisList(Y2AxisList rhs)
	{
		foreach (Y2Axis rh in rhs)
		{
			Add(rh.Clone());
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Y2AxisList Clone()
	{
		return new Y2AxisList(this);
	}

	public int IndexOf(string title)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Y2Axis current = enumerator.Current;
				if (string.Compare(current.Title._text, title, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public int IndexOfTag(string tagStr)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				Y2Axis current = enumerator.Current;
				if (current.Tag is string && string.Compare((string)current.Tag, tagStr, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public int Add(string title)
	{
		Y2Axis item = new Y2Axis(title);
		Add(item);
		return base.Count - 1;
	}
}
