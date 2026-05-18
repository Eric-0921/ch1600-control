using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public abstract class CurveItem : ISerializable, ICloneable
{
	public class Comparer : IComparer<CurveItem>
	{
		private int index;

		private SortType sortType;

		public Comparer(SortType type, int index)
		{
			sortType = type;
			this.index = index;
		}

		public int Compare(CurveItem l, CurveItem r)
		{
			if (l == null && r == null)
			{
				return 0;
			}
			if (l == null && r != null)
			{
				return -1;
			}
			if (l != null && r == null)
			{
				return 1;
			}
			if (r != null && r.NPts <= index)
			{
				r = null;
			}
			if (l != null && l.NPts <= index)
			{
				l = null;
			}
			double num;
			double num2;
			if (sortType == SortType.XValues)
			{
				num = ((l != null) ? Math.Abs(l[index].X) : double.MaxValue);
				num2 = ((r != null) ? Math.Abs(r[index].X) : double.MaxValue);
			}
			else
			{
				num = ((l != null) ? Math.Abs(l[index].Y) : double.MaxValue);
				num2 = ((r != null) ? Math.Abs(r[index].Y) : double.MaxValue);
			}
			if (num == double.MaxValue || double.IsInfinity(num) || double.IsNaN(num))
			{
				l = null;
			}
			if (num2 == double.MaxValue || double.IsInfinity(num2) || double.IsNaN(num2))
			{
				r = null;
			}
			if ((l == null && r == null) || Math.Abs(num - num2) < 1E-10)
			{
				return 0;
			}
			if (l == null && r != null)
			{
				return -1;
			}
			if (l != null && r == null)
			{
				return 1;
			}
			if (!(num2 < num))
			{
				return 1;
			}
			return -1;
		}
	}

	public const int schema = 11;

	internal Label _label;

	protected bool _isX2Axis;

	protected bool _isY2Axis;

	protected int _yAxisIndex;

	protected bool _isVisible;

	protected bool _isSelected;

	protected bool _isSelectable;

	protected bool _isOverrideOrdinal;

	protected IPointList _points;

	public object Tag;

	internal Link _link;

	public Label Label
	{
		get
		{
			return _label;
		}
		set
		{
			_label = value;
		}
	}

	public Color Color
	{
		get
		{
			if (this is BarItem)
			{
				return ((BarItem)this).Bar.Fill.Color;
			}
			if (this is LineItem && ((LineItem)this).Line.IsVisible)
			{
				return ((LineItem)this).Line.Color;
			}
			if (this is LineItem)
			{
				return ((LineItem)this).Symbol.Border.Color;
			}
			if (this is ErrorBarItem)
			{
				return ((ErrorBarItem)this).Bar.Color;
			}
			if (this is HiLowBarItem)
			{
				return ((HiLowBarItem)this).Bar.Fill.Color;
			}
			return Color.Empty;
		}
		set
		{
			if (this is BarItem)
			{
				((BarItem)this).Bar.Fill.Color = value;
			}
			else if (this is LineItem)
			{
				((LineItem)this).Line.Color = value;
				((LineItem)this).Symbol.Border.Color = value;
				((LineItem)this).Symbol.Fill.Color = value;
			}
			else if (this is ErrorBarItem)
			{
				((ErrorBarItem)this).Bar.Color = value;
			}
			else if (this is HiLowBarItem)
			{
				((HiLowBarItem)this).Bar.Fill.Color = value;
			}
		}
	}

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			_isVisible = value;
		}
	}

	public bool IsSelected
	{
		get
		{
			return _isSelected;
		}
		set
		{
			_isSelected = value;
		}
	}

	public bool IsSelectable
	{
		get
		{
			return _isSelectable;
		}
		set
		{
			_isSelectable = value;
		}
	}

	public bool IsOverrideOrdinal
	{
		get
		{
			return _isOverrideOrdinal;
		}
		set
		{
			_isOverrideOrdinal = value;
		}
	}

	public bool IsX2Axis
	{
		get
		{
			return _isX2Axis;
		}
		set
		{
			_isX2Axis = value;
		}
	}

	public bool IsY2Axis
	{
		get
		{
			return _isY2Axis;
		}
		set
		{
			_isY2Axis = value;
		}
	}

	public int YAxisIndex
	{
		get
		{
			return _yAxisIndex;
		}
		set
		{
			_yAxisIndex = value;
		}
	}

	public bool IsBar
	{
		get
		{
			if (!(this is BarItem) && !(this is HiLowBarItem))
			{
				return this is ErrorBarItem;
			}
			return true;
		}
	}

	public bool IsPie => this is PieItem;

	public bool IsLine => this is LineItem;

	public int NPts
	{
		get
		{
			if (_points == null)
			{
				return 0;
			}
			return _points.Count;
		}
	}

	public IPointList Points
	{
		get
		{
			return _points;
		}
		set
		{
			_points = value;
		}
	}

	public PointPair this[int index]
	{
		get
		{
			if (_points == null)
			{
				return new PointPair(double.MaxValue, double.MaxValue);
			}
			return _points[index];
		}
	}

	public Link Link
	{
		get
		{
			return _link;
		}
		set
		{
			_link = value;
		}
	}

	public CurveItem(string label, double[] x, double[] y)
		: this(label, new PointPairList(x, y))
	{
	}

	public CurveItem(string label, IPointList points)
	{
		Init(label);
		if (points == null)
		{
			_points = new PointPairList();
		}
		else
		{
			_points = points;
		}
	}

	private void Init(string label)
	{
		_label = new Label(label, null);
		_isY2Axis = false;
		_isX2Axis = false;
		_isVisible = true;
		_isOverrideOrdinal = false;
		Tag = null;
		_yAxisIndex = 0;
		_link = new Link();
	}

	public CurveItem(string label)
		: this(label, null)
	{
	}

	public CurveItem()
	{
		Init(null);
	}

	public CurveItem(CurveItem rhs)
	{
		_label = rhs._label.Clone();
		_isY2Axis = rhs.IsY2Axis;
		_isX2Axis = rhs.IsX2Axis;
		_isVisible = rhs.IsVisible;
		_isOverrideOrdinal = rhs._isOverrideOrdinal;
		_yAxisIndex = rhs._yAxisIndex;
		if (rhs.Tag is ICloneable)
		{
			Tag = ((ICloneable)rhs.Tag).Clone();
		}
		else
		{
			Tag = rhs.Tag;
		}
		_points = (IPointList)rhs.Points.Clone();
		_link = rhs._link.Clone();
	}

	object ICloneable.Clone()
	{
		throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
	}

	protected CurveItem(SerializationInfo info, StreamingContext context)
	{
		int @int = info.GetInt32("schema");
		_label = (Label)info.GetValue("label", typeof(Label));
		_isY2Axis = info.GetBoolean("isY2Axis");
		if (@int >= 11)
		{
			_isX2Axis = info.GetBoolean("isX2Axis");
		}
		else
		{
			_isX2Axis = false;
		}
		_isVisible = info.GetBoolean("isVisible");
		_isOverrideOrdinal = info.GetBoolean("isOverrideOrdinal");
		_points = (PointPairList)info.GetValue("points", typeof(PointPairList));
		Tag = info.GetValue("Tag", typeof(object));
		_yAxisIndex = info.GetInt32("yAxisIndex");
		_link = (Link)info.GetValue("link", typeof(Link));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 11);
		info.AddValue("label", _label);
		info.AddValue("isY2Axis", _isY2Axis);
		info.AddValue("isX2Axis", _isX2Axis);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("isOverrideOrdinal", _isOverrideOrdinal);
		PointPairList value = ((!(_points is PointPairList)) ? new PointPairList(_points) : (_points as PointPairList));
		info.AddValue("points", value);
		info.AddValue("Tag", Tag);
		info.AddValue("yAxisIndex", _yAxisIndex);
		info.AddValue("link", _link);
	}

	internal abstract bool IsZIncluded(GraphPane pane);

	internal abstract bool IsXIndependent(GraphPane pane);

	public abstract void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor);

	public abstract void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor);

	public void AddPoint(double x, double y)
	{
		AddPoint(new PointPair(x, y));
	}

	public void AddPoint(PointPair point)
	{
		if (_points == null)
		{
			Points = new PointPairList();
		}
		if (_points is IPointListEdit)
		{
			(_points as IPointListEdit).Add(point);
			return;
		}
		throw new NotImplementedException();
	}

	public void Clear()
	{
		if (_points is IPointListEdit)
		{
			(_points as IPointListEdit).Clear();
			return;
		}
		throw new NotImplementedException();
	}

	public void RemovePoint(int index)
	{
		if (_points is IPointListEdit)
		{
			(_points as IPointListEdit).RemoveAt(index);
			return;
		}
		throw new NotImplementedException();
	}

	public Axis GetXAxis(GraphPane pane)
	{
		if (_isX2Axis)
		{
			return pane.X2Axis;
		}
		return pane.XAxis;
	}

	public Axis GetYAxis(GraphPane pane)
	{
		if (_isY2Axis)
		{
			if (_yAxisIndex < pane.Y2AxisList.Count)
			{
				return pane.Y2AxisList[_yAxisIndex];
			}
			return pane.Y2AxisList[0];
		}
		if (_yAxisIndex < pane.YAxisList.Count)
		{
			return pane.YAxisList[_yAxisIndex];
		}
		return pane.YAxisList[0];
	}

	public int GetYAxisIndex(GraphPane pane)
	{
		if (_yAxisIndex >= 0 && _yAxisIndex < (_isY2Axis ? pane.Y2AxisList.Count : pane.YAxisList.Count))
		{
			return _yAxisIndex;
		}
		return 0;
	}

	public void MakeUnique()
	{
		MakeUnique(ColorSymbolRotator.StaticInstance);
	}

	public virtual void MakeUnique(ColorSymbolRotator rotator)
	{
		Color = rotator.NextColor;
	}

	public virtual void GetRange(out double xMin, out double xMax, out double yMin, out double yMax, bool ignoreInitial, bool isBoundedRanges, GraphPane pane)
	{
		double num = double.MinValue;
		double num2 = double.MaxValue;
		double num3 = double.MinValue;
		double num4 = double.MaxValue;
		xMin = (yMin = double.MaxValue);
		xMax = (yMax = double.MinValue);
		Axis yAxis = GetYAxis(pane);
		Axis xAxis = GetXAxis(pane);
		if (yAxis == null || xAxis == null)
		{
			return;
		}
		if (isBoundedRanges)
		{
			num = xAxis._scale._lBound;
			num2 = xAxis._scale._uBound;
			num3 = yAxis._scale._lBound;
			num4 = yAxis._scale._uBound;
		}
		bool flag = IsZIncluded(pane);
		bool flag2 = IsXIndependent(pane);
		bool isLog = xAxis.Scale.IsLog;
		bool isLog2 = yAxis.Scale.IsLog;
		bool isAnyOrdinal = xAxis.Scale.IsAnyOrdinal;
		bool isAnyOrdinal2 = yAxis.Scale.IsAnyOrdinal;
		bool isAnyOrdinal3 = (flag2 ? yAxis : xAxis).Scale.IsAnyOrdinal;
		for (int i = 0; i < Points.Count; i++)
		{
			PointPair pointPair = Points[i];
			double num5 = (isAnyOrdinal ? ((double)(i + 1)) : pointPair.X);
			double num6 = (isAnyOrdinal2 ? ((double)(i + 1)) : pointPair.Y);
			double num7 = (isAnyOrdinal3 ? ((double)(i + 1)) : pointPair.Z);
			bool flag3 = num5 < num || num5 > num2 || num6 < num3 || num6 > num4 || (flag && flag2 && (num7 < num3 || num7 > num4)) || (flag && !flag2 && (num7 < num || num7 > num2)) || (num5 <= 0.0 && isLog) || (num6 <= 0.0 && isLog2);
			if (ignoreInitial && num6 != 0.0 && num6 != double.MaxValue)
			{
				ignoreInitial = false;
			}
			if (ignoreInitial || flag3 || num5 == double.MaxValue || num6 == double.MaxValue)
			{
				continue;
			}
			if (num5 < xMin)
			{
				xMin = num5;
			}
			if (num5 > xMax)
			{
				xMax = num5;
			}
			if (num6 < yMin)
			{
				yMin = num6;
			}
			if (num6 > yMax)
			{
				yMax = num6;
			}
			if (flag && flag2 && num7 != double.MaxValue)
			{
				if (num7 < yMin)
				{
					yMin = num7;
				}
				if (num7 > yMax)
				{
					yMax = num7;
				}
			}
			else if (flag && num7 != double.MaxValue)
			{
				if (num7 < xMin)
				{
					xMin = num7;
				}
				if (num7 > xMax)
				{
					xMax = num7;
				}
			}
		}
	}

	public virtual Axis BaseAxis(GraphPane pane)
	{
		return (BarBase)((!(this is BarItem) && !(this is ErrorBarItem) && !(this is HiLowBarItem)) ? (_isX2Axis ? 1 : 0) : ((int)pane._barSettings.Base)) switch
		{
			BarBase.X => pane.XAxis, 
			BarBase.X2 => pane.X2Axis, 
			BarBase.Y => pane.YAxis, 
			_ => pane.Y2Axis, 
		};
	}

	public virtual Axis ValueAxis(GraphPane pane)
	{
		BarBase barBase = ((this is BarItem || this is ErrorBarItem || this is HiLowBarItem) ? pane._barSettings.Base : BarBase.X);
		if (barBase == BarBase.X || barBase == BarBase.X2)
		{
			return GetYAxis(pane);
		}
		return GetXAxis(pane);
	}

	public float GetBarWidth(GraphPane pane)
	{
		float num;
		if (this is ErrorBarItem)
		{
			num = ((ErrorBarItem)this).Bar.Symbol.Size * pane.CalcScaleFactor();
		}
		else
		{
			float num2 = 1f;
			if (pane._barSettings.Type == BarType.Cluster)
			{
				num2 = pane.CurveList.NumClusterableBars;
			}
			float num3 = num2 * (1f + pane._barSettings.MinBarGap) - pane._barSettings.MinBarGap + pane._barSettings.MinClusterGap;
			if (num3 <= 0f)
			{
				num3 = 1f;
			}
			num = pane.BarSettings.GetClusterWidth() / num3;
		}
		if (num <= 0f)
		{
			return 1f;
		}
		return num;
	}

	public abstract bool GetCoords(GraphPane pane, int i, out string coords);
}
