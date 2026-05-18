using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class PolyObj : BoxObj, ICloneable, ISerializable
{
	public const int schema3 = 11;

	private PointD[] _points;

	private bool _isClosedFigure = true;

	public PointD[] Points
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

	public bool IsClosedFigure
	{
		get
		{
			return _isClosedFigure;
		}
		set
		{
			_isClosedFigure = value;
		}
	}

	public PolyObj(PointD[] points, Color borderColor, Color fillColor)
		: base(0.0, 0.0, 1.0, 1.0, borderColor, fillColor)
	{
		_points = points;
	}

	public PolyObj(PointD[] points)
		: base(0.0, 0.0, 1.0, 1.0)
	{
		_points = points;
	}

	public PolyObj()
		: this(new PointD[0])
	{
	}

	public PolyObj(PointD[] points, Color borderColor, Color fillColor1, Color fillColor2)
		: base(0.0, 0.0, 1.0, 1.0, borderColor, fillColor1, fillColor2)
	{
		_points = points;
	}

	public PolyObj(PolyObj rhs)
		: base(rhs)
	{
		rhs._points = (PointD[])_points.Clone();
		rhs._isClosedFigure = _isClosedFigure;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new PolyObj Clone()
	{
		return new PolyObj(this);
	}

	protected PolyObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
		_points = (PointD[])info.GetValue("points", typeof(PointD[]));
		_isClosedFigure = info.GetBoolean("isClosedFigure");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema3", 11);
		info.AddValue("points", _points);
		info.AddValue("isClosedFigure", _isClosedFigure);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		if (_points == null || _points.Length <= 1)
		{
			return;
		}
		using GraphicsPath graphicsPath = MakePath(pane);
		if (_fill.IsVisible)
		{
			using Brush brush = base.Fill.MakeBrush(graphicsPath.GetBounds());
			g.FillPath(brush, graphicsPath);
		}
		if (_border.IsVisible)
		{
			using (Pen pen = _border.GetPen(pane, scaleFactor))
			{
				g.DrawPath(pen, graphicsPath);
				return;
			}
		}
	}

	internal GraphicsPath MakePath(PaneBase pane)
	{
		GraphicsPath graphicsPath = new GraphicsPath();
		bool flag = true;
		PointF pt = default(PointF);
		PointD[] points = _points;
		for (int i = 0; i < points.Length; i++)
		{
			PointD pointD = points[i];
			PointF pointF = Location.Transform(pane, pointD.X + _location.X, pointD.Y + _location.Y, _location.CoordinateFrame);
			if (Math.Abs(pointF.X) < 100000f && Math.Abs(pointF.Y) < 100000f)
			{
				if (flag)
				{
					flag = false;
				}
				else
				{
					graphicsPath.AddLine(pt, pointF);
				}
				pt = pointF;
			}
		}
		if (_isClosedFigure)
		{
			graphicsPath.CloseFigure();
		}
		return graphicsPath;
	}

	public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (_points != null && _points.Length > 1)
		{
			if (!base.PointInBox(pt, pane, g, scaleFactor))
			{
				return false;
			}
			using GraphicsPath graphicsPath = MakePath(pane);
			return graphicsPath.IsVisible(pt);
		}
		return false;
	}
}
