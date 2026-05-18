namespace ZedGraph;

public class PerformanceData
{
	public double time;

	public double distance;

	public double velocity;

	public double acceleration;

	public double this[PerfDataType type]
	{
		get
		{
			return type switch
			{
				PerfDataType.Distance => distance, 
				PerfDataType.Velocity => velocity, 
				PerfDataType.Acceleration => acceleration, 
				_ => time, 
			};
		}
		set
		{
			switch (type)
			{
			case PerfDataType.Time:
				time = value;
				break;
			case PerfDataType.Distance:
				distance = value;
				break;
			case PerfDataType.Velocity:
				velocity = value;
				break;
			case PerfDataType.Acceleration:
				acceleration = value;
				break;
			}
		}
	}

	public PerformanceData(double time, double distance, double velocity, double acceleration)
	{
		this.time = time;
		this.distance = distance;
		this.velocity = velocity;
		this.acceleration = acceleration;
	}
}
