using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class PointPairBase : ISerializable
{
	public const double Missing = double.MaxValue;

	public const string DefaultFormat = "G";

	public const int schema = 11;

	public double X;

	public double Y;

	public bool IsMissing
	{
		get
		{
			if (X != double.MaxValue)
			{
				return Y == double.MaxValue;
			}
			return true;
		}
	}

	public bool IsInvalid
	{
		get
		{
			if (X != double.MaxValue && Y != double.MaxValue && !double.IsInfinity(X) && !double.IsInfinity(Y) && !double.IsNaN(X))
			{
				return double.IsNaN(Y);
			}
			return true;
		}
	}

	public PointPairBase()
		: this(0.0, 0.0)
	{
	}

	public PointPairBase(double x, double y)
	{
		X = x;
		Y = y;
	}

	public PointPairBase(PointF pt)
		: this(pt.X, pt.Y)
	{
	}

	public PointPairBase(PointPairBase rhs)
	{
		X = rhs.X;
		Y = rhs.Y;
	}

	protected PointPairBase(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		X = info.GetDouble("X");
		Y = info.GetDouble("Y");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 11);
		info.AddValue("X", X);
		info.AddValue("Y", Y);
	}

	public static bool IsValueInvalid(double value)
	{
		if (value != double.MaxValue && !double.IsInfinity(value))
		{
			return double.IsNaN(value);
		}
		return true;
	}

	public static implicit operator PointF(PointPairBase pair)
	{
		return new PointF((float)pair.X, (float)pair.Y);
	}

	public override bool Equals(object obj)
	{
		PointPairBase pointPairBase = obj as PointPairBase;
		if (X == pointPairBase.X)
		{
			return Y == pointPairBase.Y;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public override string ToString()
	{
		return ToString("G");
	}

	public string ToString(string format)
	{
		return "( " + X.ToString(format) + ", " + Y.ToString(format) + " )";
	}

	public string ToString(string formatX, string formatY)
	{
		return "( " + X.ToString(formatX) + ", " + Y.ToString(formatY) + " )";
	}
}
