using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class PaneList : List<GraphPane>, ICloneable
{
	public const int schema = 10;

	public GraphPane this[string title]
	{
		get
		{
			int num = IndexOf(title);
			if (num >= 0)
			{
				return base[num];
			}
			return null;
		}
	}

	public PaneList()
	{
	}

	public PaneList(PaneList rhs)
	{
		foreach (GraphPane rh in rhs)
		{
			Add(rh.Clone());
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public PaneList Clone()
	{
		return new PaneList(this);
	}

	protected PaneList(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
	}

	public int IndexOf(string title)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				GraphPane current = enumerator.Current;
				if (string.Compare(current.Title.Text, title, ignoreCase: true) == 0)
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
				GraphPane current = enumerator.Current;
				if (current.Tag is string && string.Compare((string)current.Tag, tagStr, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}
}
