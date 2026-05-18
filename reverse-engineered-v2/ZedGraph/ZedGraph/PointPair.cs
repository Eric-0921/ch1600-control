using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class PointPair : PointPairBase, ISerializable, ICloneable
{
	public class PointPairComparerY : IComparer<PointPair>
	{
		public int Compare(PointPair l, PointPair r)
		{
			if (l == null && r == null)
			{
				return 0;
			}
			if (l == null && r != null)
			{
				return -1;
			}
			if (l != null && r == null)
			{
				return 1;
			}
			double y = l.Y;
			double y2 = r.Y;
			if (Math.Abs(y - y2) < 1E-09)
			{
				return 0;
			}
			if (!(y < y2))
			{
				return 1;
			}
			return -1;
		}
	}

	public class PointPairComparer : IComparer<PointPair>
	{
		private SortType sortType;

		public PointPairComparer(SortType type)
		{
			sortType = type;
		}

		public int Compare(PointPair l, PointPair r)
		{
			if (l == null && r == null)
			{
				return 0;
			}
			if (l == null && r != null)
			{
				return -1;
			}
			if (l != null && r == null)
			{
				return 1;
			}
			double num;
			double num2;
			if (sortType == SortType.XValues)
			{
				num = l.X;
				num2 = r.X;
			}
			else
			{
				num = l.Y;
				num2 = r.Y;
			}
			if (num == double.MaxValue || double.IsInfinity(num) || double.IsNaN(num))
			{
				l = null;
			}
			if (num2 == double.MaxValue || double.IsInfinity(num2) || double.IsNaN(num2))
			{
				r = null;
			}
			if ((l == null && r == null) || Math.Abs(num - num2) < 1E-100)
			{
				return 0;
			}
			if (l == null && r != null)
			{
				return -1;
			}
			if (l != null && r == null)
			{
				return 1;
			}
			if (!(num < num2))
			{
				return 1;
			}
			return -1;
		}
	}

	public const int schema2 = 11;

	public double Z;

	public object Tag;

	public bool IsInvalid3D
	{
		get
		{
			if (X != double.MaxValue && Y != double.MaxValue && Z != double.MaxValue && !double.IsInfinity(X) && !double.IsInfinity(Y) && !double.IsInfinity(Z) && !double.IsNaN(X) && !double.IsNaN(Y))
			{
				return double.IsNaN(Z);
			}
			return true;
		}
	}

	public double LowValue
	{
		get
		{
			return Z;
		}
		set
		{
			Z = value;
		}
	}

	public virtual double ColorValue
	{
		get
		{
			return Z;
		}
		set
		{
			Z = value;
		}
	}

	public PointPair()
		: this(0.0, 0.0, 0.0, null)
	{
	}

	public PointPair(double x, double y)
		: this(x, y, 0.0, null)
	{
	}

	public PointPair(double x, double y, string label)
		: this(x, y, 0.0, (object)label)
	{
	}

	public PointPair(double x, double y, double z)
		: this(x, y, z, null)
	{
	}

	public PointPair(double x, double y, double z, string label)
		: this(x, y, z, (object)label)
	{
	}

	public PointPair(double x, double y, double z, object tag)
		: base(x, y)
	{
		Z = z;
		Tag = tag;
	}

	public PointPair(PointF pt)
		: this(pt.X, pt.Y, 0.0, null)
	{
	}

	public PointPair(PointPair rhs)
		: base(rhs)
	{
		Z = rhs.Z;
		if (rhs.Tag is ICloneable)
		{
			Tag = ((ICloneable)rhs.Tag).Clone();
		}
		else
		{
			Tag = rhs.Tag;
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public PointPair Clone()
	{
		return new PointPair(this);
	}

	protected PointPair(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		Z = info.GetDouble("Z");
		Tag = info.GetValue("Tag", typeof(object));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
		info.AddValue("Z", Z);
		info.AddValue("Tag", Tag);
	}

	public override bool Equals(object obj)
	{
		PointPair pointPair = obj as PointPair;
		if (X == pointPair.X && Y == pointPair.Y)
		{
			return Z == pointPair.Z;
		}
		return false;
	}

	public override int GetHashCode()
	{
		return base.GetHashCode();
	}

	public virtual string ToString(bool isShowZ)
	{
		return ToString("G", isShowZ);
	}

	public virtual string ToString(string format, bool isShowZ)
	{
		return "( " + X.ToString(format) + ", " + Y.ToString(format) + (isShowZ ? (", " + Z.ToString(format)) : "") + " )";
	}

	public string ToString(string formatX, string formatY, string formatZ)
	{
		return "( " + X.ToString(formatX) + ", " + Y.ToString(formatY) + ", " + Z.ToString(formatZ) + " )";
	}
}
