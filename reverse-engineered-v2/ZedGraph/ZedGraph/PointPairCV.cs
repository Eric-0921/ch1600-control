using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

public class PointPairCV : PointPair
{
	public const int schema3 = 11;

	private double _colorValue;

	public override double ColorValue
	{
		get
		{
			return _colorValue;
		}
		set
		{
			_colorValue = value;
		}
	}

	public PointPairCV(double x, double y, double z)
		: base(x, y, z, null)
	{
	}

	protected PointPairCV(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
		ColorValue = info.GetDouble("ColorValue");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema3", 11);
		info.AddValue("ColorValue", ColorValue);
	}
}
