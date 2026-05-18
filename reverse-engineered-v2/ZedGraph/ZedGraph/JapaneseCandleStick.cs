using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class JapaneseCandleStick : OHLCBar, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static Color RisingColor = Color.White;

		public static Color FallingColor = Color.Black;

		public static Color RisingBorder = Color.Black;

		public static Color FallingBorder = Color.Black;
	}

	public const int schema2 = 11;

	private Fill _risingFill;

	private Fill _fallingFill;

	private Border _risingBorder;

	private Border _fallingBorder;

	protected Color _fallingColor;

	public Fill RisingFill
	{
		get
		{
			return _risingFill;
		}
		set
		{
			_risingFill = value;
		}
	}

	public Fill FallingFill
	{
		get
		{
			return _fallingFill;
		}
		set
		{
			_fallingFill = value;
		}
	}

	public Border RisingBorder
	{
		get
		{
			return _risingBorder;
		}
		set
		{
			_risingBorder = value;
		}
	}

	public Border FallingBorder
	{
		get
		{
			return _fallingBorder;
		}
		set
		{
			_fallingBorder = value;
		}
	}

	public Color FallingColor
	{
		get
		{
			return _fallingColor;
		}
		set
		{
			_fallingColor = value;
		}
	}

	public JapaneseCandleStick()
	{
		_risingFill = new Fill(Default.RisingColor);
		_fallingFill = new Fill(Default.FallingColor);
		_risingBorder = new Border(Default.RisingBorder, LineBase.Default.Width);
		_fallingBorder = new Border(Default.FallingBorder, LineBase.Default.Width);
		_fallingColor = Default.FallingColor;
	}

	public JapaneseCandleStick(JapaneseCandleStick rhs)
		: base(rhs)
	{
		_risingFill = rhs._risingFill.Clone();
		_fallingFill = rhs._fallingFill.Clone();
		_risingBorder = rhs._risingBorder.Clone();
		_fallingBorder = rhs._fallingBorder.Clone();
		_fallingColor = rhs._fallingColor;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new JapaneseCandleStick Clone()
	{
		return new JapaneseCandleStick(this);
	}

	protected JapaneseCandleStick(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_risingFill = (Fill)info.GetValue("risingFill", typeof(Fill));
		_fallingFill = (Fill)info.GetValue("fallingFill", typeof(Fill));
		_risingBorder = (Border)info.GetValue("risingBorder", typeof(Border));
		_fallingBorder = (Border)info.GetValue("fallingBorder", typeof(Border));
		_fallingColor = (Color)info.GetValue("fallingColor", typeof(Color));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
		info.AddValue("risingFill", _risingFill);
		info.AddValue("fallingFill", _fallingFill);
		info.AddValue("risingBorder", _risingBorder);
		info.AddValue("fallingBorder", _fallingBorder);
		info.AddValue("fallingColor", _fallingColor);
	}

	public void Draw(Graphics g, GraphPane pane, bool isXBase, float pixBase, float pixHigh, float pixLow, float pixOpen, float pixClose, float halfSize, float scaleFactor, Pen pen, Fill fill, Border border, PointPair pt)
	{
		if ((double)pixBase == double.MaxValue || !(Math.Abs(pixLow) < 1000000f) || !(Math.Abs(pixHigh) < 1000000f))
		{
			return;
		}
		RectangleF rect;
		if (isXBase)
		{
			rect = new RectangleF(pixBase - halfSize, Math.Min(pixOpen, pixClose), halfSize * 2f, Math.Abs(pixOpen - pixClose));
			g.DrawLine(pen, pixBase, pixHigh, pixBase, pixLow);
		}
		else
		{
			rect = new RectangleF(Math.Min(pixOpen, pixClose), pixBase - halfSize, Math.Abs(pixOpen - pixClose), halfSize * 2f);
			g.DrawLine(pen, pixHigh, pixBase, pixLow, pixBase);
		}
		if (_isOpenCloseVisible && Math.Abs(pixOpen) < 1000000f && Math.Abs(pixClose) < 1000000f)
		{
			if (rect.Width == 0f)
			{
				rect.Width = 1f;
			}
			if (rect.Height == 0f)
			{
				rect.Height = 1f;
			}
			fill.Draw(g, rect, pt);
			border.Draw(g, pane, scaleFactor, rect);
		}
	}

	public void Draw(Graphics g, GraphPane pane, JapaneseCandleStickItem curve, Axis baseAxis, Axis valueAxis, float scaleFactor)
	{
		if (curve.Points == null)
		{
			return;
		}
		float barWidth = GetBarWidth(pane, baseAxis, scaleFactor);
		Color color = _color;
		Color color2 = _fallingColor;
		float width = _width;
		Fill fill = _risingFill;
		Fill fill2 = _fallingFill;
		Border border = _risingBorder;
		Border border2 = _fallingBorder;
		if (curve.IsSelected)
		{
			color = Selection.Border.Color;
			color2 = Selection.Border.Color;
			width = Selection.Border.Width;
			fill = Selection.Fill;
			fill2 = Selection.Fill;
			border = Selection.Border;
			border2 = Selection.Border;
		}
		using Pen pen = new Pen(color, width);
		using Pen pen2 = new Pen(color2, width);
		for (int i = 0; i < curve.Points.Count; i++)
		{
			PointPair pointPair = curve.Points[i];
			double x = pointPair.X;
			double y = pointPair.Y;
			double z = pointPair.Z;
			double num = double.MaxValue;
			double num2 = double.MaxValue;
			if (pointPair is StockPt)
			{
				num = (pointPair as StockPt).Open;
				num2 = (pointPair as StockPt).Close;
			}
			if (curve.Points[i].IsInvalid3D || (!(x > 0.0) && baseAxis._scale.IsLog) || ((!(y > 0.0) || !(z > 0.0)) && valueAxis._scale.IsLog))
			{
				continue;
			}
			float pixBase = (int)((double)baseAxis.Scale.Transform(curve.IsOverrideOrdinal, i, x) + 0.5);
			float pixHigh = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, y);
			float pixLow = valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, z);
			float pixOpen = ((!PointPairBase.IsValueInvalid(num)) ? valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, num) : float.MaxValue);
			float pixClose = ((!PointPairBase.IsValueInvalid(num2)) ? valueAxis.Scale.Transform(curve.IsOverrideOrdinal, i, num2) : float.MaxValue);
			if (!curve.IsSelected && _gradientFill.IsGradientValueType)
			{
				using Pen pen3 = GetPen(pane, scaleFactor, pointPair);
				Draw(g, pane, baseAxis is XAxis || baseAxis is X2Axis, pixBase, pixHigh, pixLow, pixOpen, pixClose, barWidth, scaleFactor, pen3, (num2 > num) ? fill : fill2, (num2 > num) ? border : border2, pointPair);
			}
			else
			{
				Draw(g, pane, baseAxis is XAxis || baseAxis is X2Axis, pixBase, pixHigh, pixLow, pixOpen, pixClose, barWidth, scaleFactor, (num2 > num) ? pen : pen2, (num2 > num) ? fill : fill2, (num2 > num) ? border : border2, pointPair);
			}
		}
	}
}
