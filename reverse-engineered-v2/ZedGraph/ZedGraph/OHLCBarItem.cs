using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class OHLCBarItem : CurveItem, ICloneable, ISerializable
{
	public const int schema2 = 10;

	protected OHLCBar _bar;

	public OHLCBar Bar => _bar;

	internal override bool IsXIndependent(GraphPane pane)
	{
		return pane._barSettings.Base == BarBase.X;
	}

	internal override bool IsZIncluded(GraphPane pane)
	{
		return true;
	}

	public OHLCBarItem(string label)
		: base(label)
	{
		_bar = new OHLCBar();
	}

	public OHLCBarItem(string label, IPointList points, Color color)
		: base(label, points)
	{
		_bar = new OHLCBar(color);
	}

	public OHLCBarItem(OHLCBarItem rhs)
		: base(rhs)
	{
		_bar = rhs._bar.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public OHLCBarItem Clone()
	{
		return new OHLCBarItem(this);
	}

	protected OHLCBarItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_bar = (OHLCBar)info.GetValue("stick", typeof(OHLCBar));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("stick", _bar);
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (_isVisible)
		{
			_bar.Draw(g, pane, this, BaseAxis(pane), ValueAxis(pane), scaleFactor);
		}
	}

	public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		float pixBase;
		float num;
		float num2;
		float pixOpen;
		float pixClose;
		if (pane._barSettings.Base == BarBase.X)
		{
			pixBase = rect.Left + rect.Width / 2f;
			num = rect.Top;
			num2 = rect.Bottom;
			pixOpen = num + rect.Height / 3f;
			pixClose = num2 - rect.Height / 3f;
		}
		else
		{
			pixBase = rect.Top + rect.Height / 2f;
			num = rect.Right;
			num2 = rect.Left;
			pixOpen = num - rect.Width / 3f;
			pixClose = num2 + rect.Width / 3f;
		}
		using Pen pen = new Pen(_bar.Color, _bar._width);
		_bar.Draw(g, pane, pane._barSettings.Base == BarBase.X, pixBase, num, num2, pixOpen, pixClose, scaleFactor, pen);
	}

	public override bool GetCoords(GraphPane pane, int i, out string coords)
	{
		coords = string.Empty;
		if (i < 0 || i >= _points.Count)
		{
			return false;
		}
		Axis axis = ValueAxis(pane);
		Axis axis2 = BaseAxis(pane);
		float num = _bar.Size * pane.CalcScaleFactor();
		PointPair pointPair = _points[i];
		double x = pointPair.X;
		double y = pointPair.Y;
		double z = pointPair.Z;
		if (!pointPair.IsInvalid3D && (x > 0.0 || !axis2._scale.IsLog) && ((y > 0.0 && z > 0.0) || !axis._scale.IsLog))
		{
			float num2 = axis2.Scale.Transform(_isOverrideOrdinal, i, x);
			float num3 = axis.Scale.Transform(_isOverrideOrdinal, i, y);
			float num4 = axis.Scale.Transform(_isOverrideOrdinal, i, z);
			float num5 = num2 - num;
			if (axis2 is XAxis || axis2 is X2Axis)
			{
				coords = $"{num5:f0},{num4:f0},{num5 + num * 2f:f0},{num3:f0}";
			}
			else
			{
				coords = $"{num4:f0},{num5:f0},{num3:f0},{num5 + num * 2f:f0}";
			}
			return true;
		}
		return false;
	}
}
