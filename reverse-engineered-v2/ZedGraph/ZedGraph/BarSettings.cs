using System;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class BarSettings : ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float MinClusterGap = 1f;

		public static float MinBarGap = 0.2f;

		public static BarBase Base = BarBase.X;

		public static BarType Type = BarType.Cluster;

		public static double ClusterScaleWidth = 1.0;

		public static bool ClusterScaleWidthAuto = true;
	}

	public const int schema = 10;

	private float _minClusterGap;

	private float _minBarGap;

	private BarBase _base;

	private BarType _type;

	internal double _clusterScaleWidth;

	internal bool _clusterScaleWidthAuto;

	internal GraphPane _ownerPane;

	public float MinClusterGap
	{
		get
		{
			return _minClusterGap;
		}
		set
		{
			_minClusterGap = value;
		}
	}

	public float MinBarGap
	{
		get
		{
			return _minBarGap;
		}
		set
		{
			_minBarGap = value;
		}
	}

	public BarBase Base
	{
		get
		{
			return _base;
		}
		set
		{
			_base = value;
		}
	}

	public BarType Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	public double ClusterScaleWidth
	{
		get
		{
			return _clusterScaleWidth;
		}
		set
		{
			_clusterScaleWidth = value;
			_clusterScaleWidthAuto = false;
		}
	}

	public bool ClusterScaleWidthAuto
	{
		get
		{
			return _clusterScaleWidthAuto;
		}
		set
		{
			_clusterScaleWidthAuto = value;
		}
	}

	public BarSettings(GraphPane parentPane)
	{
		_minClusterGap = Default.MinClusterGap;
		_minBarGap = Default.MinBarGap;
		_clusterScaleWidth = Default.ClusterScaleWidth;
		_clusterScaleWidthAuto = Default.ClusterScaleWidthAuto;
		_base = Default.Base;
		_type = Default.Type;
		_ownerPane = parentPane;
	}

	public BarSettings(BarSettings rhs, GraphPane parentPane)
	{
		_minClusterGap = rhs._minClusterGap;
		_minBarGap = rhs._minBarGap;
		_clusterScaleWidth = rhs._clusterScaleWidth;
		_clusterScaleWidthAuto = rhs._clusterScaleWidthAuto;
		_base = rhs._base;
		_type = rhs._type;
		_ownerPane = parentPane;
	}

	internal BarSettings(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_minClusterGap = info.GetSingle("minClusterGap");
		_minBarGap = info.GetSingle("minBarGap");
		_clusterScaleWidth = info.GetDouble("clusterScaleWidth");
		_clusterScaleWidthAuto = info.GetBoolean("clusterScaleWidthAuto");
		_base = (BarBase)info.GetValue("base", typeof(BarBase));
		_type = (BarType)info.GetValue("type", typeof(BarType));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("minClusterGap", _minClusterGap);
		info.AddValue("minBarGap", _minBarGap);
		info.AddValue("clusterScaleWidth", _clusterScaleWidth);
		info.AddValue("clusterScaleWidthAuto", _clusterScaleWidthAuto);
		info.AddValue("base", _base);
		info.AddValue("type", _type);
	}

	public void CalcClusterScaleWidth()
	{
		Axis axis = BarBaseAxis();
		if (_clusterScaleWidthAuto && !axis.Scale.IsAnyOrdinal)
		{
			double num = double.MaxValue;
			foreach (CurveItem curve in _ownerPane.CurveList)
			{
				_ = curve.Points;
				if (curve is BarItem)
				{
					double minStepSize = GetMinStepSize(curve.Points, axis);
					num = ((minStepSize < num) ? minStepSize : num);
				}
			}
			if (num == double.MaxValue)
			{
				num = 1.0;
			}
			_clusterScaleWidth = num;
		}
		foreach (CurveItem curve2 in _ownerPane.CurveList)
		{
			IPointList points = curve2.Points;
			if (curve2 is JapaneseCandleStickItem && (curve2 as JapaneseCandleStickItem).Stick.IsAutoSize)
			{
				(curve2 as JapaneseCandleStickItem).Stick._userScaleSize = GetMinStepSize(points, axis);
			}
		}
	}

	internal static double GetMinStepSize(IPointList list, Axis baseAxis)
	{
		double num = double.MaxValue;
		if (list.Count <= 0 || baseAxis._scale.IsAnyOrdinal)
		{
			return 1.0;
		}
		PointPair pointPair = list[0];
		for (int i = 1; i < list.Count; i++)
		{
			PointPair pointPair2 = list[i];
			if (!pointPair2.IsInvalid || !pointPair.IsInvalid)
			{
				double num2 = ((!(baseAxis is XAxis) && !(baseAxis is X2Axis)) ? (pointPair2.Y - pointPair.Y) : (pointPair2.X - pointPair.X));
				if (num2 > 0.0 && num2 < num)
				{
					num = num2;
				}
			}
			pointPair = pointPair2;
		}
		double num3 = baseAxis.Scale._maxLinearized - baseAxis.Scale._minLinearized;
		if (num3 <= 0.0)
		{
			num = 1.0;
		}
		else if (num <= 0.0 || num < 0.001 * num3 || num > num3)
		{
			num = 0.1 * num3;
		}
		return num;
	}

	public float GetClusterWidth()
	{
		return BarBaseAxis()._scale.GetClusterWidth(_ownerPane);
	}

	public Axis BarBaseAxis()
	{
		if (_base == BarBase.Y)
		{
			return _ownerPane.YAxis;
		}
		if (_base == BarBase.Y2)
		{
			return _ownerPane.Y2Axis;
		}
		if (_base == BarBase.X2)
		{
			return _ownerPane.X2Axis;
		}
		return _ownerPane.XAxis;
	}
}
