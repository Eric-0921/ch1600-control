using System;

namespace ZedGraph;

public class ScaleState : ICloneable
{
	private double _min;

	private double _minorStep;

	private double _majorStep;

	private double _max;

	private bool _minAuto;

	private bool _minorStepAuto;

	private bool _majorStepAuto;

	private bool _maxAuto;

	private bool _formatAuto;

	private bool _magAuto;

	private DateUnit _minorUnit;

	private DateUnit _majorUnit;

	private string _format;

	private int _mag;

	public ScaleState(Axis axis)
	{
		_min = axis._scale._min;
		_minorStep = axis._scale._minorStep;
		_majorStep = axis._scale._majorStep;
		_max = axis._scale._max;
		_majorUnit = axis._scale._majorUnit;
		_minorUnit = axis._scale._minorUnit;
		_format = axis._scale._format;
		_mag = axis._scale._mag;
		_minAuto = axis._scale._minAuto;
		_majorStepAuto = axis._scale._majorStepAuto;
		_minorStepAuto = axis._scale._minorStepAuto;
		_maxAuto = axis._scale._maxAuto;
		_formatAuto = axis._scale._formatAuto;
		_magAuto = axis._scale._magAuto;
	}

	public ScaleState(ScaleState rhs)
	{
		_min = rhs._min;
		_majorStep = rhs._majorStep;
		_minorStep = rhs._minorStep;
		_max = rhs._max;
		_majorUnit = rhs._majorUnit;
		_minorUnit = rhs._minorUnit;
		_format = rhs._format;
		_mag = rhs._mag;
		_minAuto = rhs._minAuto;
		_majorStepAuto = rhs._majorStepAuto;
		_minorStepAuto = rhs._minorStepAuto;
		_maxAuto = rhs._maxAuto;
		_formatAuto = rhs._formatAuto;
		_magAuto = rhs._magAuto;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ScaleState Clone()
	{
		return new ScaleState(this);
	}

	public void ApplyScale(Axis axis)
	{
		axis._scale._min = _min;
		axis._scale._majorStep = _majorStep;
		axis._scale._minorStep = _minorStep;
		axis._scale._max = _max;
		axis._scale._majorUnit = _majorUnit;
		axis._scale._minorUnit = _minorUnit;
		axis._scale._format = _format;
		axis._scale._mag = _mag;
		axis._scale._minAuto = _minAuto;
		axis._scale._minorStepAuto = _minorStepAuto;
		axis._scale._majorStepAuto = _majorStepAuto;
		axis._scale._maxAuto = _maxAuto;
		axis._scale._formatAuto = _formatAuto;
		axis._scale._magAuto = _magAuto;
	}

	public bool IsChanged(Axis axis)
	{
		if (axis._scale._min == _min && axis._scale._majorStep == _majorStep && axis._scale._minorStep == _minorStep && axis._scale._max == _max && axis._scale._minorUnit == _minorUnit && axis._scale._majorUnit == _majorUnit && axis._scale._minAuto == _minAuto && axis._scale._minorStepAuto == _minorStepAuto && axis._scale._majorStepAuto == _majorStepAuto)
		{
			return axis._scale._maxAuto != _maxAuto;
		}
		return true;
	}
}
