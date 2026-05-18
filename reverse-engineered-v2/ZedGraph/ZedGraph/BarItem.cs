using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class BarItem : CurveItem, ICloneable, ISerializable
{
	public const int schema2 = 10;

	protected Bar _bar;

	public Bar Bar => _bar;

	internal override bool IsZIncluded(GraphPane pane)
	{
		return this is HiLowBarItem;
	}

	internal override bool IsXIndependent(GraphPane pane)
	{
		if (pane._barSettings.Base != BarBase.X)
		{
			return pane._barSettings.Base == BarBase.X2;
		}
		return true;
	}

	public BarItem(string label)
		: base(label)
	{
		_bar = new Bar();
	}

	public BarItem(string label, double[] x, double[] y, Color color)
		: this(label, new PointPairList(x, y), color)
	{
	}

	public BarItem(string label, IPointList points, Color color)
		: base(label, points)
	{
		_bar = new Bar(color);
	}

	public BarItem(BarItem rhs)
		: base(rhs)
	{
		_bar = rhs._bar.Clone();
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public BarItem Clone()
	{
		return new BarItem(this);
	}

	protected BarItem(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_bar = (Bar)info.GetValue("bar", typeof(Bar));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("bar", _bar);
	}

	public override void Draw(Graphics g, GraphPane pane, int pos, float scaleFactor)
	{
		if (_isVisible)
		{
			_bar.DrawBars(g, pane, this, BaseAxis(pane), ValueAxis(pane), GetBarWidth(pane), pos, scaleFactor);
		}
	}

	public override void DrawLegendKey(Graphics g, GraphPane pane, RectangleF rect, float scaleFactor)
	{
		_bar.Draw(g, pane, rect, scaleFactor, fullFrame: true, isSelected: false, null);
	}

	public static void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat)
	{
		CreateBarLabels(pane, isBarCenter, valueFormat, TextObj.Default.FontFamily, TextObj.Default.FontSize, TextObj.Default.FontColor, TextObj.Default.FontBold, TextObj.Default.FontItalic, TextObj.Default.FontUnderline);
	}

	public static void CreateBarLabels(GraphPane pane, bool isBarCenter, string valueFormat, string fontFamily, float fontSize, Color fontColor, bool isBold, bool isItalic, bool isUnderline)
	{
		bool flag = pane.BarSettings.Base == BarBase.X;
		int num = 0;
		ValueHandler valueHandler = new ValueHandler(pane, initialize: true);
		foreach (CurveItem curve in pane.CurveList)
		{
			if (curve is BarItem barItem)
			{
				IPointList points = curve.Points;
				Scale scale = curve.ValueAxis(pane).Scale;
				float num2 = (float)(scale._max - scale._min) * 0.015f;
				for (int i = 0; i < points.Count; i++)
				{
					valueHandler.GetValues(curve, i, out var baseVal, out var lowVal, out var hiVal);
					float num3 = (float)valueHandler.BarCenterValue(barItem, barItem.GetBarWidth(pane), i, baseVal, num);
					string text = (flag ? points[i].Y : points[i].X).ToString(valueFormat);
					float num4 = ((!isBarCenter) ? ((!(hiVal >= 0.0)) ? ((float)hiVal - num2) : ((float)hiVal + num2)) : ((float)(hiVal + lowVal) / 2f));
					TextObj textObj = ((!flag) ? new TextObj(text, num4, num3) : new TextObj(text, num3, num4));
					textObj.FontSpec.Family = fontFamily;
					textObj.Location.CoordinateFrame = ((flag && curve.IsY2Axis) ? CoordType.AxisXY2Scale : CoordType.AxisXYScale);
					textObj.FontSpec.Size = fontSize;
					textObj.FontSpec.FontColor = fontColor;
					textObj.FontSpec.IsItalic = isItalic;
					textObj.FontSpec.IsBold = isBold;
					textObj.FontSpec.IsUnderline = isUnderline;
					textObj.FontSpec.Angle = (flag ? 90 : 0);
					textObj.Location.AlignH = (isBarCenter ? AlignH.Center : ((!(hiVal >= 0.0)) ? AlignH.Right : AlignH.Left));
					textObj.Location.AlignV = AlignV.Center;
					textObj.FontSpec.Border.IsVisible = false;
					textObj.FontSpec.Fill.IsVisible = false;
					pane.GraphObjList.Add(textObj);
				}
				num++;
			}
		}
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
		float clusterWidth = pane.BarSettings.GetClusterWidth();
		float barWidth = GetBarWidth(pane);
		float num = pane._barSettings.MinClusterGap * barWidth;
		float num2 = barWidth * pane._barSettings.MinBarGap;
		ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
		valueHandler.GetValues(this, i, out var baseVal, out var lowVal, out var hiVal);
		if (!_points[i].IsInvalid3D)
		{
			float num3 = axis.Scale.Transform(_isOverrideOrdinal, i, lowVal);
			float num4 = axis.Scale.Transform(_isOverrideOrdinal, i, hiVal);
			float num5 = axis2.Scale.Transform(_isOverrideOrdinal, i, baseVal);
			float num6 = num5 - clusterWidth / 2f + num / 2f + (float)pane.CurveList.GetBarItemPos(pane, this) * (barWidth + num2);
			if (axis2 is XAxis || axis2 is X2Axis)
			{
				coords = $"{num6:f0},{num3:f0},{num6 + barWidth:f0},{num4:f0}";
			}
			else
			{
				coords = $"{num3:f0},{num6:f0},{num4:f0},{num6 + barWidth:f0}";
			}
			return true;
		}
		return false;
	}
}
