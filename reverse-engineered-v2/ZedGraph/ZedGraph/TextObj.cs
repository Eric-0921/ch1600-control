using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class TextObj : GraphObj, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static string FontFamily = "Arial";

		public static float FontSize = 12f;

		public static Color FontColor = Color.Black;

		public static bool FontBold = false;

		public static bool FontUnderline = false;

		public static bool FontItalic = false;
	}

	public const int schema2 = 10;

	private string _text;

	private FontSpec _fontSpec;

	private SizeF _layoutArea;

	public SizeF LayoutArea
	{
		get
		{
			return _layoutArea;
		}
		set
		{
			_layoutArea = value;
		}
	}

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
			if (value == null)
			{
				throw new ArgumentNullException("Uninitialized FontSpec in TextObj");
			}
			_fontSpec = value;
		}
	}

	public TextObj(string text, double x, double y)
		: base(x, y)
	{
		Init(text);
	}

	private void Init(string text)
	{
		if (text != null)
		{
			_text = text;
		}
		else
		{
			text = "Text";
		}
		_fontSpec = new FontSpec(Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontItalic, Default.FontUnderline);
		_layoutArea = new SizeF(0f, 0f);
	}

	public TextObj(string text, double x, double y, CoordType coordType)
		: base(x, y, coordType)
	{
		Init(text);
	}

	public TextObj(string text, double x, double y, CoordType coordType, AlignH alignH, AlignV alignV)
		: base(x, y, coordType, alignH, alignV)
	{
		Init(text);
	}

	public TextObj()
		: base(0.0, 0.0)
	{
		Init("");
	}

	public TextObj(TextObj rhs)
		: base(rhs)
	{
		_text = rhs.Text;
		_fontSpec = new FontSpec(rhs.FontSpec);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public TextObj Clone()
	{
		return new TextObj(this);
	}

	protected TextObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_text = info.GetString("text");
		_fontSpec = (FontSpec)info.GetValue("fontSpec", typeof(FontSpec));
		_layoutArea = (SizeF)info.GetValue("layoutArea", typeof(SizeF));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("text", _text);
		info.AddValue("fontSpec", _fontSpec);
		info.AddValue("layoutArea", _layoutArea);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		PointF pointF = _location.Transform(pane);
		if (pointF.X > -100000f && pointF.X < 100000f && pointF.Y > -100000f && pointF.Y < 100000f)
		{
			FontSpec.Draw(g, pane, _text, pointF.X, pointF.Y, _location.AlignH, _location.AlignV, scaleFactor, _layoutArea);
		}
	}

	public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (!base.PointInBox(pt, pane, g, scaleFactor))
		{
			return false;
		}
		PointF pointF = _location.Transform(pane);
		return _fontSpec.PointInBox(pt, g, _text, pointF.X, pointF.Y, _location.AlignH, _location.AlignV, scaleFactor, LayoutArea);
	}

	public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
	{
		PointF pointF = _location.Transform(pane);
		PointF[] box = _fontSpec.GetBox(g, _text, pointF.X, pointF.Y, _location.AlignH, _location.AlignV, scaleFactor, default(SizeF));
		shape = "poly";
		coords = $"{box[0].X:f0},{box[0].Y:f0},{box[1].X:f0},{box[1].Y:f0},{box[2].X:f0},{box[2].Y:f0},{box[3].X:f0},{box[3].Y:f0},";
	}
}
