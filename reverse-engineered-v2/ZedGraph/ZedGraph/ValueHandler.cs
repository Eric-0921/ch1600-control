using System;

namespace ZedGraph;

public class ValueHandler
{
	private GraphPane _pane;

	public ValueHandler(GraphPane pane, bool initialize)
	{
		_pane = pane;
		if (initialize)
		{
			using (pane.GetImage())
			{
			}
		}
	}

	public bool GetValues(CurveItem curve, int iPt, out double baseVal, out double lowVal, out double hiVal)
	{
		return GetValues(_pane, curve, iPt, out baseVal, out lowVal, out hiVal);
	}

	public static bool GetValues(GraphPane pane, CurveItem curve, int iPt, out double baseVal, out double lowVal, out double hiVal)
	{
		hiVal = double.MaxValue;
		lowVal = double.MaxValue;
		baseVal = double.MaxValue;
		if (curve == null || curve.Points.Count <= iPt || !curve.IsVisible)
		{
			return false;
		}
		Axis axis = curve.BaseAxis(pane);
		Axis axis2 = curve.ValueAxis(pane);
		if (axis is XAxis || axis is X2Axis)
		{
			baseVal = curve.Points[iPt].X;
		}
		else
		{
			baseVal = curve.Points[iPt].Y;
		}
		if (curve is BarItem && (pane._barSettings.Type == BarType.Stack || pane._barSettings.Type == BarType.PercentStack))
		{
			double num = 0.0;
			double num2 = 0.0;
			foreach (CurveItem curve2 in pane.CurveList)
			{
				if (!curve2.IsBar || !curve2.IsVisible)
				{
					continue;
				}
				double num3 = double.MaxValue;
				if (curve.IsOverrideOrdinal || !axis._scale.IsAnyOrdinal)
				{
					IPointList points = curve2.Points;
					for (int i = 0; i < points.Count; i++)
					{
						if ((axis is XAxis || axis is X2Axis) && points[i].X == baseVal)
						{
							num3 = points[i].Y;
							break;
						}
						if (!(axis is XAxis) && !(axis is X2Axis) && points[i].Y == baseVal)
						{
							num3 = points[i].X;
							break;
						}
					}
				}
				else if (iPt < curve2.Points.Count)
				{
					num3 = ((!(axis is XAxis) && !(axis is X2Axis)) ? curve2.Points[iPt].X : curve2.Points[iPt].Y);
				}
				if (num3 == double.MaxValue)
				{
					num = double.MaxValue;
					num2 = double.MaxValue;
				}
				if (curve2 == curve)
				{
					if (num3 >= 0.0)
					{
						lowVal = num;
						hiVal = ((num3 == double.MaxValue || num == double.MaxValue) ? double.MaxValue : (num + num3));
					}
					else
					{
						hiVal = num2;
						lowVal = ((num3 == double.MaxValue || num2 == double.MaxValue) ? double.MaxValue : (num2 + num3));
					}
				}
				if (num3 >= 0.0)
				{
					num = ((num3 == double.MaxValue || num == double.MaxValue) ? double.MaxValue : (num + num3));
				}
				else
				{
					num2 = ((num3 == double.MaxValue || num2 == double.MaxValue) ? double.MaxValue : (num2 + num3));
				}
			}
			if (pane._barSettings.Type == BarType.PercentStack && hiVal != double.MaxValue && lowVal != double.MaxValue)
			{
				num += Math.Abs(num2);
				if (num != 0.0)
				{
					lowVal = lowVal / num * 100.0;
					hiVal = hiVal / num * 100.0;
				}
				else
				{
					lowVal = 0.0;
					hiVal = 0.0;
				}
			}
			if (baseVal == double.MaxValue || lowVal == double.MaxValue || hiVal == double.MaxValue)
			{
				return false;
			}
			return true;
		}
		if (curve is LineItem && pane.LineType == LineType.Stack)
		{
			double num4 = 0.0;
			foreach (CurveItem curve3 in pane.CurveList)
			{
				if (!(curve3 is LineItem) || !curve3.IsVisible)
				{
					continue;
				}
				double num5 = double.MaxValue;
				if (curve.IsOverrideOrdinal || !axis._scale.IsAnyOrdinal)
				{
					IPointList points2 = curve3.Points;
					for (int j = 0; j < points2.Count; j++)
					{
						if (points2[j].X == baseVal)
						{
							num5 = points2[j].Y;
							break;
						}
					}
				}
				else if (iPt < curve3.Points.Count)
				{
					num5 = curve3.Points[iPt].Y;
				}
				if (num5 == double.MaxValue)
				{
					num4 = double.MaxValue;
				}
				if (curve3 == curve)
				{
					lowVal = num4;
					hiVal = ((num5 == double.MaxValue || num4 == double.MaxValue) ? double.MaxValue : (num4 + num5));
				}
				num4 = ((num5 == double.MaxValue || num4 == double.MaxValue) ? double.MaxValue : (num4 + num5));
			}
			if (baseVal == double.MaxValue || lowVal == double.MaxValue || hiVal == double.MaxValue)
			{
				return false;
			}
			return true;
		}
		if (!(curve is HiLowBarItem))
		{
			lowVal = 0.0;
		}
		else
		{
			lowVal = curve.Points[iPt].LowValue;
		}
		if (axis is XAxis || axis is X2Axis)
		{
			hiVal = curve.Points[iPt].Y;
		}
		else
		{
			hiVal = curve.Points[iPt].X;
		}
		if (curve is BarItem && axis2._scale.IsLog && lowVal == 0.0)
		{
			lowVal = axis2._scale._min;
		}
		if (baseVal == double.MaxValue || hiVal == double.MaxValue || (lowVal == double.MaxValue && (curve is ErrorBarItem || curve is HiLowBarItem)))
		{
			return false;
		}
		return true;
	}

	public double BarCenterValue(CurveItem curve, float barWidth, int iCluster, double val, int iOrdinal)
	{
		Axis axis = curve.BaseAxis(_pane);
		if (curve is ErrorBarItem || curve is HiLowBarItem || curve is OHLCBarItem || curve is JapaneseCandleStickItem)
		{
			if (axis._scale.IsAnyOrdinal && iCluster >= 0 && !curve.IsOverrideOrdinal)
			{
				return (double)iCluster + 1.0;
			}
			return val;
		}
		float clusterWidth = _pane._barSettings.GetClusterWidth();
		float num = _pane._barSettings.MinClusterGap * barWidth;
		float num2 = barWidth * _pane._barSettings.MinBarGap;
		if (curve.IsBar && _pane._barSettings.Type != BarType.Cluster)
		{
			iOrdinal = 0;
		}
		float pixVal = axis.Scale.Transform(curve.IsOverrideOrdinal, iCluster, val) - clusterWidth / 2f + num / 2f + (float)iOrdinal * (barWidth + num2) + 0.5f * barWidth;
		return axis.Scale.ReverseTransform(pixVal);
	}
}
