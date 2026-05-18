using System;
using System.Collections.Generic;

namespace ZedGraph;

public class ZoomStateStack : List<ZoomState>, ICloneable
{
	public bool IsEmpty => base.Count == 0;

	public ZoomState Top
	{
		get
		{
			if (!IsEmpty)
			{
				return base[base.Count - 1];
			}
			return null;
		}
	}

	public ZoomStateStack()
	{
	}

	public ZoomStateStack(ZoomStateStack rhs)
	{
		foreach (ZoomState rh in rhs)
		{
			Add(new ZoomState(rh));
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ZoomStateStack Clone()
	{
		return new ZoomStateStack(this);
	}

	public ZoomState Push(GraphPane pane, ZoomState.StateType type)
	{
		ZoomState zoomState = new ZoomState(pane, type);
		Add(zoomState);
		return zoomState;
	}

	public ZoomState Push(ZoomState state)
	{
		Add(state);
		return state;
	}

	public ZoomState Pop(GraphPane pane)
	{
		if (!IsEmpty)
		{
			ZoomState zoomState = base[base.Count - 1];
			RemoveAt(base.Count - 1);
			zoomState.ApplyState(pane);
			return zoomState;
		}
		return null;
	}

	public ZoomState PopAll(GraphPane pane)
	{
		if (!IsEmpty)
		{
			ZoomState zoomState = base[0];
			Clear();
			zoomState.ApplyState(pane);
			return zoomState;
		}
		return null;
	}
}
