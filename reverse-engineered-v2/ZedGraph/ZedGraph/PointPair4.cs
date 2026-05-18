using System;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class PointPair4 : PointPair, ISerializable
{
	public const int schema3 = 11;

	public double T;

	public bool IsInvalid4D
	{
		get
		{
			if (X != double.MaxValue && Y != double.MaxValue && Z != double.MaxValue && T != double.MaxValue && !double.IsInfinity(X) && !double.IsInfinity(Y) && !double.IsInfinity(Z) && !double.IsInfinity(T) && !double.IsNaN(X) && !double.IsNaN(Y) && !double.IsNaN(Z))
			{
				return double.IsNaN(T);
			}
			return true;
		}
	}

	public PointPair4()
	{
		T = 0.0;
	}

	public PointPair4(double x, double y, double z, double t)
		: base(x, y, z)
	{
		T = t;
	}

	public PointPair4(double x, double y, double z, double t, string label)
		: base(x, y, z, label)
	{
		T = t;
	}

	public PointPair4(PointPair4 rhs)
		: base(rhs)
	{
		T = rhs.T;
	}

	protected PointPair4(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
		T = info.GetDouble("T");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
		info.AddValue("T", T);
	}

	public new string ToString(bool isShowZT)
	{
		return ToString("G", isShowZT);
	}

	public new string ToString(string format, bool isShowZT)
	{
		return "( " + X.ToString(format) + ", " + Y.ToString(format) + (isShowZT ? (", " + Z.ToString(format) + ", " + T.ToString(format)) : "") + " )";
	}

	public string ToString(string formatX, string formatY, string formatZ, string formatT)
	{
		return "( " + X.ToString(formatX) + ", " + Y.ToString(formatY) + ", " + Z.ToString(formatZ) + ", " + T.ToString(formatT) + " )";
	}
}
