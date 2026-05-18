using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class OHLCBar : LineBase, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static float Size = 12f;

		public static bool IsOpenCloseVisible = true;

		public static bool IsAutoSize = true;
	}

	public const int schema = 10;

	protected bool _isOpenCloseVisible;

	protected float _size;

	protected bool _isAutoSize;

	internal double _userScaleSize = 1.0;

	public bool IsOpenCloseVisible
	{
		get
		{
			return _isOpenCloseVisible;
		}
		set
		{
			_isOpenCloseVisible = value;
		}
	}

	public float Size
	{
		get
		{
			return _size;
		}
		set
		{
			_size = value;
			_isAutoSize = false;
		}
	}

	public bool IsAutoSize
	{
		get
		{
			return _isAutoSize;
		}
		set
		{
			_isAutoSize = value;
		}
	}

	public OHLCBar()
		: this(LineBase.Default.Color)
	{
	}

	public OHLCBar(Color color)
		: base(color)
	{
		_size = Default.Size;
		_isAutoSize = Default.IsAutoSize;
		_isOpenCloseVisible = Default.IsOpenCloseVisible;
	}

	public OHLCBar(OHLCBar rhs)
		: base(rhs)
	{
		_isOpenCloseVisible = rhs._isOpenCloseVisible;
		_size = rhs._size;
		_isAutoSize = rhs._isAutoSize;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public OHLCBar Clone()
	{
		return new OHLCBar(this);
	}

	protected OHLCBar(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema");
		_isOpenCloseVisible = info.GetBoolean("isOpenCloseVisible");
		_size = info.GetSingle("size");
		_isAutoSize = info.GetBoolean("isAutoSize");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema", 10);
		info.AddValue("isOpenCloseVisible", _isOpenCloseVisible);
		info.AddValue("size", _size);
		info.AddValue("isAutoSize", _isAutoSize);
	}

	public void Draw(Graphics g, GraphPane pane, bool isXBase, float pixBase, float pixHigh, float pixLow, float pixOpen, float pixClose, float halfSize, Pen pen)
	{
		if ((double)pixBase == double.MaxValue)
		{
			return;
		}
		if (isXBase)
		{
			if (Math.Abs(pixLow) < 1000000f && Math.Abs(pixHigh) < 1000000f)
			{
				g.DrawLine(pen, pixBase, pixHigh, pixBase, pixLow);
			}
			if (_isOpenCloseVisible && Math.Abs(pixOpen) < 1000000f)
			{
				g.DrawLine(pen, pixBase - halfSize, pixOpen, pixBase, pixOpen);
			}
			if (_isOpenCloseVisible && Math.Abs(pixClose) < 1000000f)
			{
				g.DrawLine(pen, pixBase, pixClose, pixBase + halfSize, pixClose);
			}
		}
		else
		{
			if (Math.Abs(pixLow) < 1000000f && Math.Abs(pixHigh) < 1000000f)
			{
				g.DrawLine(pen, pixHigh, pixBase, pixLow, pixBase);
			}
			if (_isOpenCloseVisible && Math.Abs(pixOpen) < 1000000f)
			{
				g.DrawLine(pen, pixOpen, pixBase - halfSize, pixOpen, pixBase);
			}
			if (_isOpenCloseVisible && Math.Abs(pixClose) < 1000000f)
			{
				g.DrawLine(pen, pixClose, pixBase, pixClose, pixBase + halfSize);
			}
		}
	}

	public void Draw(Graphics g, GraphPane pane, OHLCBarItem curve, Axis baseAxis, Axis valueAxis, float scaleFactor)
	{
		if (curve.Points == null)
		{
			return;
		}
		float barWidth = GetBarWidth(pane, baseAxis, scaleFactor);
		using Pen pen = ((!curve.IsSelected) ? new Pen(_color, _width) : new Pen(Selection.Border.Color, Selection.Border.Width));
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
				using Pen pen2 = GetPen(pane, scaleFactor, pointPair);
				Draw(g, pane, baseAxis is XAxis || baseAxis is X2Axis, pixBase, pixHigh, pixLow, pixOpen, pixClose, barWidth, pen2);
			}
			else
			{
				Draw(g, pane, baseAxis is XAxis || baseAxis is X2Axis, pixBase, pixHigh, pixLow, pixOpen, pixClose, barWidth, pen);
			}
		}
	}

	public float GetBarWidth(GraphPane pane, Axis baseAxis, float scaleFactor)
	{
		float num = ((!_isAutoSize) ? (_size * scaleFactor / 2f) : (baseAxis._scale.GetClusterWidth(_userScaleSize) / (1f + pane._barSettings.MinClusterGap) / 2f));
		return (int)(num + 0.5f);
	}
}
