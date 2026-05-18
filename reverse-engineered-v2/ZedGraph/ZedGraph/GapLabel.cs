using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class GapLabel : Label, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float Gap = 0.3f;
	}

	public const int schema2 = 10;

	internal float _gap;

	public float Gap
	{
		get
		{
			return _gap;
		}
		set
		{
			_gap = value;
		}
	}

	public GapLabel(string text, string fontFamily, float fontSize, Color color, bool isBold, bool isItalic, bool isUnderline)
		: base(text, fontFamily, fontSize, color, isBold, isItalic, isUnderline)
	{
		_gap = Default.Gap;
	}

	public GapLabel(GapLabel rhs)
		: base(rhs)
	{
		_gap = rhs._gap;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public new GapLabel Clone()
	{
		return new GapLabel(this);
	}

	public float GetScaledGap(float scaleFactor)
	{
		return _fontSpec.GetHeight(scaleFactor) * _gap;
	}

	protected GapLabel(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_gap = info.GetSingle("gap");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("gap", _gap);
	}
}
