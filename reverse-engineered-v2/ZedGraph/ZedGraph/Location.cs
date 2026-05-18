using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Location : ICloneable, ISerializable
{
	public const int schema = 10;

	private AlignV _alignV;

	private AlignH _alignH;

	private double _x;

	private double _y;

	private double _width;

	private double _height;

	private CoordType _coordinateFrame;

	public AlignH AlignH
	{
		get
		{
			return _alignH;
		}
		set
		{
			_alignH = value;
		}
	}

	public AlignV AlignV
	{
		get
		{
			return _alignV;
		}
		set
		{
			_alignV = value;
		}
	}

	public CoordType CoordinateFrame
	{
		get
		{
			return _coordinateFrame;
		}
		set
		{
			_coordinateFrame = value;
		}
	}

	public double X
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public double Y
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public double X1
	{
		get
		{
			return _x;
		}
		set
		{
			_x = value;
		}
	}

	public double Y1
	{
		get
		{
			return _y;
		}
		set
		{
			_y = value;
		}
	}

	public double Width
	{
		get
		{
			return _width;
		}
		set
		{
			_width = value;
		}
	}

	public double Height
	{
		get
		{
			return _height;
		}
		set
		{
			_height = value;
		}
	}

	public double X2 => _x + _width;

	public double Y2 => _y + _height;

	public RectangleF Rect
	{
		get
		{
			return new RectangleF((float)_x, (float)_y, (float)_width, (float)_height);
		}
		set
		{
			_x = value.X;
			_y = value.Y;
			_width = value.Width;
			_height = value.Height;
		}
	}

	public PointF TopLeft
	{
		get
		{
			return new PointF((float)_x, (float)_y);
		}
		set
		{
			_x = value.X;
			_y = value.Y;
		}
	}

	public PointF BottomRight => new PointF((float)X2, (float)Y2);

	public Location()
		: this(0.0, 0.0, CoordType.ChartFraction)
	{
	}

	public Location(double x, double y, CoordType coordType)
		: this(x, y, coordType, AlignH.Left, AlignV.Top)
	{
	}

	public Location(double x, double y, CoordType coordType, AlignH alignH, AlignV alignV)
	{
		_x = x;
		_y = y;
		_width = 0.0;
		_height = 0.0;
		_coordinateFrame = coordType;
		_alignH = alignH;
		_alignV = alignV;
	}

	public Location(double x, double y, double width, double height, CoordType coordType, AlignH alignH, AlignV alignV)
		: this(x, y, coordType, alignH, alignV)
	{
		_width = width;
		_height = height;
	}

	public Location(Location rhs)
	{
		_x = rhs._x;
		_y = rhs._y;
		_width = rhs._width;
		_height = rhs._height;
		_coordinateFrame = rhs.CoordinateFrame;
		_alignH = rhs.AlignH;
		_alignV = rhs.AlignV;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Location Clone()
	{
		return new Location(this);
	}

	protected Location(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_alignV = (AlignV)info.GetValue("alignV", typeof(AlignV));
		_alignH = (AlignH)info.GetValue("alignH", typeof(AlignH));
		_x = info.GetDouble("x");
		_y = info.GetDouble("y");
		_width = info.GetDouble("width");
		_height = info.GetDouble("height");
		_coordinateFrame = (CoordType)info.GetValue("coordinateFrame", typeof(CoordType));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("alignV", _alignV);
		info.AddValue("alignH", _alignH);
		info.AddValue("x", _x);
		info.AddValue("y", _y);
		info.AddValue("width", _width);
		info.AddValue("height", _height);
		info.AddValue("coordinateFrame", _coordinateFrame);
	}

	public PointF Transform(PaneBase pane)
	{
		return Transform(pane, _x, _y, _coordinateFrame);
	}

	public static PointF Transform(PaneBase pane, double x, double y, CoordType coord)
	{
		return pane.TransformCoord(x, y, coord);
	}

	public PointF TransformTopLeft(PaneBase pane, float width, float height)
	{
		PointF result = Transform(pane);
		if (_alignH == AlignH.Right)
		{
			result.X -= width;
		}
		else if (_alignH == AlignH.Center)
		{
			result.X -= width / 2f;
		}
		if (_alignV == AlignV.Bottom)
		{
			result.Y -= height;
		}
		else if (_alignV == AlignV.Center)
		{
			result.Y -= height / 2f;
		}
		return result;
	}

	public PointF TransformTopLeft(PaneBase pane)
	{
		return Transform(pane);
	}

	public PointF TransformBottomRight(PaneBase pane)
	{
		return Transform(pane, X2, Y2, _coordinateFrame);
	}

	public RectangleF TransformRect(PaneBase pane)
	{
		PointF pointF = TransformTopLeft(pane);
		PointF pointF2 = TransformBottomRight(pane);
		return new RectangleF(pointF.X, pointF.Y, Math.Abs(pointF2.X - pointF.X), Math.Abs(pointF2.Y - pointF.Y));
	}
}
