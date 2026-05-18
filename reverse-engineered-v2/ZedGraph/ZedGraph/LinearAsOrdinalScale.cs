using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
internal class LinearAsOrdinalScale : Scale, ISerializable
{
	public const int schema2 = 10;

	public override AxisType Type => AxisType.LinearAsOrdinal;

	public LinearAsOrdinalScale(Axis owner)
		: base(owner)
	{
	}

	public LinearAsOrdinalScale(Scale rhs, Axis owner)
		: base(rhs, owner)
	{
	}

	public override Scale Clone(Axis owner)
	{
		return new LinearAsOrdinalScale(this, owner);
	}

	public override void PickScale(GraphPane pane, Graphics g, float scaleFactor)
	{
		base.PickScale(pane, g, scaleFactor);
		double num = 0.0;
		double num2 = 1.0;
		foreach (CurveItem curve in pane.CurveList)
		{
			if ((_ownerAxis is Y2Axis && curve.IsY2Axis) || (_ownerAxis is YAxis && !curve.IsY2Axis) || (_ownerAxis is X2Axis && curve.IsX2Axis) || (_ownerAxis is XAxis && !curve.IsX2Axis))
			{
				curve.GetRange(out var xMin, out var xMax, out var yMin, out var yMax, ignoreInitial: false, isBoundedRanges: false, pane);
				if (_ownerAxis is XAxis || _ownerAxis is X2Axis)
				{
					num = xMin;
					num2 = xMax;
				}
				else
				{
					num = yMin;
					num2 = yMax;
				}
			}
		}
		double num3 = Math.Abs(num2 - num);
		base.PickScale(pane, g, scaleFactor);
		OrdinalScale.PickScale(pane, g, scaleFactor, this);
		SetScaleMag(num, num2, num3 / Default.TargetXSteps);
	}

	internal override string MakeLabel(GraphPane pane, int index, double dVal)
	{
		if (_format == null)
		{
			_format = Default.Format;
		}
		int num = (int)dVal - 1;
		if (pane.CurveList.Count > 0 && pane.CurveList[0].Points.Count > num)
		{
			double x = pane.CurveList[0].Points[num].X;
			double num2 = Math.Pow(10.0, _mag);
			return (x / num2).ToString(_format);
		}
		return string.Empty;
	}

	protected LinearAsOrdinalScale(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
	}
}
