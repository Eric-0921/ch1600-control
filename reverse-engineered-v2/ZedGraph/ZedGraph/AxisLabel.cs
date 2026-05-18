using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class AxisLabel : GapLabel, ICloneable, ISerializable
{
	public const int schema3 = 10;

	internal bool _isOmitMag;

	internal bool _isTitleAtCross;

	public bool IsOmitMag
	{
		get
		{
			return _isOmitMag;
		}
		set
		{
			_isOmitMag = value;
		}
	}

	public bool IsTitleAtCross
	{
		get
		{
			return _isTitleAtCross;
		}
		set
		{
			_isTitleAtCross = value;
		}
	}

	public AxisLabel(string text, string fontFamily, float fontSize, Color color, bool isBold, bool isItalic, bool isUnderline)
		: base(text, fontFamily, fontSize, color, isBold, isItalic, isUnderline)
	{
		_isOmitMag = false;
		_isTitleAtCross = true;
	}

	public AxisLabel(AxisLabel rhs)
		: base(rhs)
	{
		_isOmitMag = rhs._isOmitMag;
		_isTitleAtCross = rhs._isTitleAtCross;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new AxisLabel Clone()
	{
		return new AxisLabel(this);
	}

	protected AxisLabel(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema3");
		_isOmitMag = info.GetBoolean("isOmitMag");
		_isTitleAtCross = info.GetBoolean("isTitleAtCross");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema3", 10);
		info.AddValue("isOmitMag", _isVisible);
		info.AddValue("isTitleAtCross", _isTitleAtCross);
	}
}
