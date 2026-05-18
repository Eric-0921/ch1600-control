using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public abstract class GraphObj : ISerializable, ICloneable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static AlignV AlignV = AlignV.Center;

		public static AlignH AlignH = AlignH.Center;

		public static CoordType CoordFrame = CoordType.AxisXYScale;

		public static bool IsClippedToChartRect = false;
	}

	public const int schema = 10;

	protected Location _location;

	protected bool _isVisible;

	protected bool _isClippedToChartRect;

	public object Tag;

	internal ZOrder _zOrder;

	internal Link _link;

	public Location Location
	{
		get
		{
			return _location;
		}
		set
		{
			_location = value;
		}
	}

	public ZOrder ZOrder
	{
		get
		{
			return _zOrder;
		}
		set
		{
			_zOrder = value;
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

	public bool IsClippedToChartRect
	{
		get
		{
			return _isClippedToChartRect;
		}
		set
		{
			_isClippedToChartRect = value;
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

	public bool IsInFrontOfData
	{
		get
		{
			if (_zOrder != ZOrder.A_InFront && _zOrder != ZOrder.B_BehindLegend)
			{
				return _zOrder == ZOrder.C_BehindChartBorder;
			}
			return true;
		}
	}

	public GraphObj()
		: this(0.0, 0.0, Default.CoordFrame, Default.AlignH, Default.AlignV)
	{
	}

	public GraphObj(double x, double y)
		: this(x, y, Default.CoordFrame, Default.AlignH, Default.AlignV)
	{
	}

	public GraphObj(double x, double y, double x2, double y2)
		: this(x, y, x2, y2, Default.CoordFrame, Default.AlignH, Default.AlignV)
	{
	}

	public GraphObj(double x, double y, CoordType coordType)
		: this(x, y, coordType, Default.AlignH, Default.AlignV)
	{
	}

	public GraphObj(double x, double y, CoordType coordType, AlignH alignH, AlignV alignV)
	{
		_isVisible = true;
		_isClippedToChartRect = Default.IsClippedToChartRect;
		Tag = null;
		_zOrder = ZOrder.A_InFront;
		_location = new Location(x, y, coordType, alignH, alignV);
		_link = new Link();
	}

	public GraphObj(double x, double y, double x2, double y2, CoordType coordType, AlignH alignH, AlignV alignV)
	{
		_isVisible = true;
		_isClippedToChartRect = Default.IsClippedToChartRect;
		Tag = null;
		_zOrder = ZOrder.A_InFront;
		_location = new Location(x, y, x2, y2, coordType, alignH, alignV);
		_link = new Link();
	}

	public GraphObj(GraphObj rhs)
	{
		_isVisible = rhs.IsVisible;
		_isClippedToChartRect = rhs._isClippedToChartRect;
		_zOrder = rhs.ZOrder;
		if (rhs.Tag is ICloneable)
		{
			Tag = ((ICloneable)rhs.Tag).Clone();
		}
		else
		{
			Tag = rhs.Tag;
		}
		_location = rhs.Location.Clone();
		_link = rhs._link.Clone();
	}

	object ICloneable.Clone()
	{
		throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
	}

	protected GraphObj(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_location = (Location)info.GetValue("location", typeof(Location));
		_isVisible = info.GetBoolean("isVisible");
		Tag = info.GetValue("Tag", typeof(object));
		_zOrder = (ZOrder)info.GetValue("zOrder", typeof(ZOrder));
		_isClippedToChartRect = info.GetBoolean("isClippedToChartRect");
		_link = (Link)info.GetValue("link", typeof(Link));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("location", _location);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("Tag", Tag);
		info.AddValue("zOrder", _zOrder);
		info.AddValue("isClippedToChartRect", _isClippedToChartRect);
		info.AddValue("link", _link);
	}

	public abstract void Draw(Graphics g, PaneBase pane, float scaleFactor);

	public virtual bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (pane is GraphPane graphPane && _isClippedToChartRect && !graphPane.Chart.Rect.Contains(pt))
		{
			return false;
		}
		return true;
	}

	public abstract void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords);
}
