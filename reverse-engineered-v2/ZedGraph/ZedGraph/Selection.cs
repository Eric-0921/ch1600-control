using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZedGraph;

public class Selection : CurveList
{
	public static Border Border = new Border(Color.Gray, 1f);

	public static Fill Fill = new Fill(Color.Gray);

	public static Line Line = new Line(Color.Gray);

	public static Symbol Symbol = new Symbol(SymbolType.Circle, Color.Gray);

	public event EventHandler SelectionChangedEvent;

	public void Select(MasterPane master, CurveItem ci)
	{
		ClearSelection(master, sendEvent: false);
		AddToSelection(master, ci);
	}

	public void Select(MasterPane master, CurveList ciList)
	{
		ClearSelection(master, sendEvent: false);
		AddToSelection(master, ciList);
	}

	public void AddToSelection(MasterPane master, CurveItem ci)
	{
		if (!Contains(ci))
		{
			Add(ci);
		}
		UpdateSelection(master);
	}

	public void AddToSelection(MasterPane master, CurveList ciList)
	{
		foreach (CurveItem ci in ciList)
		{
			if (!Contains(ci))
			{
				Add(ci);
			}
		}
		UpdateSelection(master);
	}

	public void RemoveFromSelection(MasterPane master, CurveItem ci)
	{
		if (Contains(ci))
		{
			Remove(ci);
		}
		UpdateSelection(master);
	}

	public void ClearSelection(MasterPane master)
	{
		ClearSelection(master, sendEvent: true);
	}

	public void ClearSelection(MasterPane master, bool sendEvent)
	{
		Clear();
		foreach (GraphPane pane in master.PaneList)
		{
			foreach (CurveItem curve in pane.CurveList)
			{
				curve.IsSelected = false;
			}
		}
		if (sendEvent && this.SelectionChangedEvent != null)
		{
			this.SelectionChangedEvent(this, new EventArgs());
		}
	}

	public void UpdateSelection(MasterPane master)
	{
		if (base.Count <= 0)
		{
			ClearSelection(master);
			return;
		}
		foreach (GraphPane pane in master.PaneList)
		{
			foreach (CurveItem curve in pane.CurveList)
			{
				curve.IsSelected = false;
			}
		}
		using (Enumerator enumerator3 = GetEnumerator())
		{
			while (enumerator3.MoveNext())
			{
				CurveItem current3 = enumerator3.Current;
				current3.IsSelected = true;
				if (current3.IsLine && master.PaneList.Count == 1)
				{
					GraphPane graphPane = master.PaneList[0];
					graphPane.CurveList.Remove(current3);
					graphPane.CurveList.Insert(0, current3);
				}
			}
		}
		if (this.SelectionChangedEvent != null)
		{
			this.SelectionChangedEvent(this, new EventArgs());
		}
	}
}
