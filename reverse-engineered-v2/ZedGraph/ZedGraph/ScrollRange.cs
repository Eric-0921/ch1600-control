namespace ZedGraph;

public struct ScrollRange
{
	private bool _isScrollable;

	private double _min;

	private double _max;

	public bool IsScrollable
	{
		get
		{
			return _isScrollable;
		}
		set
		{
			_isScrollable = value;
		}
	}

	public double Min
	{
		get
		{
			return _min;
		}
		set
		{
			_min = value;
		}
	}

	public double Max
	{
		get
		{
			return _max;
		}
		set
		{
			_max = value;
		}
	}

	public ScrollRange(double min, double max, bool isScrollable)
	{
		_min = min;
		_max = max;
		_isScrollable = isScrollable;
	}

	public ScrollRange(bool isScrollable)
	{
		_min = 0.0;
		_max = 0.0;
		_isScrollable = isScrollable;
	}

	public ScrollRange(ScrollRange rhs)
	{
		_min = rhs._min;
		_max = rhs._max;
		_isScrollable = rhs._isScrollable;
	}
}
