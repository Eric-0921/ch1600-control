using System;
using System.Drawing;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Label : ICloneable, ISerializable
{
	public const int schema = 10;

	internal string _text;

	internal FontSpec _fontSpec;

	internal bool _isVisible;

	public string Text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
		}
	}

	public FontSpec FontSpec
	{
		get
		{
			return _fontSpec;
		}
		set
		{
			_fontSpec = value;
		}
	}

	public bool IsVisible
	{
		get
		{
			return _isVisible;
		}
		set
		{
			_isVisible = value;
		}
	}

	public Label(string text, string fontFamily, float fontSize, Color color, bool isBold, bool isItalic, bool isUnderline)
	{
		_text = ((text == null) ? string.Empty : text);
		_fontSpec = new FontSpec(fontFamily, fontSize, color, isBold, isItalic, isUnderline);
		_isVisible = true;
	}

	public Label(string text, FontSpec fontSpec)
	{
		_text = ((text == null) ? string.Empty : text);
		_fontSpec = fontSpec;
		_isVisible = true;
	}

	public Label(Label rhs)
	{
		if (rhs._text != null)
		{
			_text = (string)rhs._text.Clone();
		}
		else
		{
			_text = string.Empty;
		}
		_isVisible = rhs._isVisible;
		if (rhs._fontSpec != null)
		{
			_fontSpec = rhs._fontSpec.Clone();
		}
		else
		{
			_fontSpec = null;
		}
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Label Clone()
	{
		return new Label(this);
	}

	protected Label(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_text = info.GetString("text");
		_isVisible = info.GetBoolean("isVisible");
		_fontSpec = (FontSpec)info.GetValue("fontSpec", typeof(FontSpec));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("text", _text);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("fontSpec", _fontSpec);
	}
}
