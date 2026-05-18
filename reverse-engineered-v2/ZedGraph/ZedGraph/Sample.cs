using System;

namespace ZedGraph;

public class Sample
{
	private DateTime _time;

	private double _position;

	private double _velocity;

	public DateTime Time
	{
		get
		{
			return _time;
		}
		set
		{
			_time = value;
		}
	}

	public double Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public double Velocity
	{
		get
		{
			return _velocity;
		}
		set
		{
			_velocity = value;
		}
	}
}
