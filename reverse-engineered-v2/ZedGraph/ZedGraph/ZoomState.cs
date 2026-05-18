using System;

namespace ZedGraph;

public class ZoomState : ICloneable
{
	public enum StateType
	{
		Zoom,
		WheelZoom,
		Pan,
		Scroll
	}

	private ScaleState _xAxis;

	private ScaleState _x2Axis;

	private ScaleStateList _yAxis;

	private ScaleStateList _y2Axis;

	private StateType _type;

	public StateType Type => _type;

	public string TypeString => _type switch
	{
		StateType.Pan => "Pan", 
		StateType.WheelZoom => "WheelZoom", 
		StateType.Scroll => "Scroll", 
		_ => "Zoom", 
	};

	public ZoomState(GraphPane pane, StateType type)
	{
		_xAxis = new ScaleState(pane.XAxis);
		_x2Axis = new ScaleState(pane.X2Axis);
		_yAxis = new ScaleStateList(pane.YAxisList);
		_y2Axis = new ScaleStateList(pane.Y2AxisList);
		_type = type;
	}

	public ZoomState(ZoomState rhs)
	{
		_xAxis = new ScaleState(rhs._xAxis);
		_x2Axis = new ScaleState(rhs._x2Axis);
		_yAxis = new ScaleStateList(rhs._yAxis);
		_y2Axis = new ScaleStateList(rhs._y2Axis);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ZoomState Clone()
	{
		return new ZoomState(this);
	}

	public void ApplyState(GraphPane pane)
	{
		_xAxis.ApplyScale(pane.XAxis);
		_x2Axis.ApplyScale(pane.X2Axis);
		_yAxis.ApplyScale(pane.YAxisList);
		_y2Axis.ApplyScale(pane.Y2AxisList);
	}

	public bool IsChanged(GraphPane pane)
	{
		if (!_xAxis.IsChanged(pane.XAxis) && !_x2Axis.IsChanged(pane.X2Axis) && !_yAxis.IsChanged(pane.YAxisList))
		{
			return _y2Axis.IsChanged(pane.Y2AxisList);
		}
		return true;
	}
}
