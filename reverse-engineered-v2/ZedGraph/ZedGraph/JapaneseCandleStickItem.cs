using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class JapaneseCandleStickItem : CurveItem, ICloneable, ISerializable
{
	public const int schema2 = 10;

	private JapaneseCandleStick _stick;

	public JapaneseCandleStick Stick => _stick;

	internal override bool IsXIndependent(GraphPane pane)
	{
		return pane._barSettings.Base == BarBase.X;
	}

	internal override bool IsZIncluded(GraphPane pane)
	{
		return true;
	}

	public JapaneseCandleStickItem(string label)
		: base(label)
	{
		_stick = new JapaneseCandleStick();
	}

	public JapaneseCandleStickItem(string label, IPointList points)
		: base(label, points)
	{
		_stick = new JapaneseCandleStick();
	}

	public JapaneseCandleStickItem(JapaneseCandleStickItem rhs)
		: base(rhs)
	{
		_stick = rhs._stick.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public JapaneseCandleStickItem Clone()
	{
		return new JapaneseCandleStickItem(this);
	}

	protected JapaneseCandleStickItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_stick = (JapaneseCandleStick)info.GetValue("stick", typeof(JapaneseCandleStick));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("stick", _stick);
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (_isVisible)
		{
			_stick.Draw(g, pane, this, BaseAxis(pane), ValueAxis(pane), scaleFactor);
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
		Axis baseAxis = BaseAxis(pane);
		float barWidth = _stick.GetBarWidth(pane, baseAxis, scaleFactor);
		using Pen pen = new Pen(_stick.Color, _stick._width);
		_stick.Draw(g, pane, pane._barSettings.Base == BarBase.X, pixBase, num, num2, pixOpen, pixClose, barWidth, scaleFactor, pen, _stick.RisingFill, _stick.RisingBorder, null);
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
		float num = _stick.Size * pane.CalcScaleFactor();
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
