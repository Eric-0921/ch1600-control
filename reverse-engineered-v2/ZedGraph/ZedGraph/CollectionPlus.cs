using System;
using System.Collections;

namespace ZedGraph;

[Serializable]
public class CollectionPlus : CollectionBase
{
	public int IndexOf(object item)
	{
		return base.List.IndexOf(item);
	}

	public void Remove(int index)
	{
		if (index >= 0 && index < base.List.Count)
		{
			base.List.RemoveAt(index);
		}
	}

	public void Remove(object item)
	{
		base.List.Remove(item);
	}

	public int Move(int index, int relativePos)
	{
		if (index < 0 || index >= base.List.Count)
		{
			return -1;
		}
		object value = base.List[index];
		base.List.RemoveAt(index);
		index += relativePos;
		if (index < 0)
		{
			index = 0;
		}
		if (index > base.List.Count)
		{
			index = base.List.Count;
		}
		base.List.Insert(index, value);
		return index;
	}
}
