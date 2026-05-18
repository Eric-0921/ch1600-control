using System;
using System.Collections.Generic;

namespace ZedGraph;

[Serializable]
public class YAxisList : List<YAxis>, ICloneable
{
	public new YAxis this[int index]
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

	public YAxis this[string title]
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

	public YAxisList()
	{
	}

	public YAxisList(YAxisList rhs)
	{
		foreach (YAxis rh in rhs)
		{
			Add(rh.Clone());
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public YAxisList Clone()
	{
		return new YAxisList(this);
	}

	public int IndexOf(string title)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				YAxis current = enumerator.Current;
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
				YAxis current = enumerator.Current;
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
		YAxis item = new YAxis(title);
		Add(item);
		return base.Count - 1;
	}
}
