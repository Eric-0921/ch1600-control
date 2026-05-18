using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZedGraph;

[Serializable]
public class GraphObjList : List<GraphObj>, ICloneable
{
	public GraphObj this[string tag]
	{
		get
		{
			int num = IndexOfTag(tag);
			if (num >= 0)
			{
				return base[num];
			}
			return null;
		}
	}

	public GraphObjList()
	{
	}

	public GraphObjList(GraphObjList rhs)
	{
		foreach (GraphObj rh in rhs)
		{
			Add((GraphObj)((ICloneable)rh).Clone());
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public GraphObjList Clone()
	{
		return new GraphObjList(this);
	}

	public int IndexOfTag(string tag)
	{
		int num = 0;
		using (Enumerator enumerator = GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				GraphObj current = enumerator.Current;
				if (current.Tag is string && string.Compare((string)current.Tag, tag, ignoreCase: true) == 0)
				{
					return num;
				}
				num++;
			}
		}
		return -1;
	}

	public int Move(int index, int relativePos)
	{
		if (index < 0 || index >= base.Count)
		{
			return -1;
		}
		GraphObj item = base[index];
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

	public void Draw(Graphics g, PaneBase pane, float scaleFactor, ZOrder zOrder)
	{
		for (int num = base.Count - 1; num >= 0; num--)
		{
			GraphObj graphObj = base[num];
			if (graphObj.ZOrder == zOrder && graphObj.IsVisible)
			{
				Region clip = null;
				if (graphObj.IsClippedToChartRect && pane is GraphPane)
				{
					clip = g.Clip.Clone();
					g.SetClip(((GraphPane)pane).Chart._rect);
				}
				graphObj.Draw(g, pane, scaleFactor);
				if (graphObj.IsClippedToChartRect && pane is GraphPane)
				{
					g.Clip = clip;
				}
			}
		}
	}

	public bool FindPoint(PointF mousePt, PaneBase pane, Graphics g, float scaleFactor, out int index)
	{
		index = -1;
		for (int num = base.Count - 1; num >= 0; num--)
		{
			if (base[num].PointInBox(mousePt, pane, g, scaleFactor) && ((index >= 0 && base[num].ZOrder > base[index].ZOrder) || index < 0))
			{
				index = num;
			}
		}
		if (index >= 0)
		{
			return true;
		}
		return false;
	}
}
