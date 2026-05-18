using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class FontSpec : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float SuperSize = 0.85f;

		public static float SuperShift = 0.4f;

		public static Color FillColor = Color.White;

		public static Brush FillBrush = null;

		public static FillType FillType = FillType.Solid;

		public static StringAlignment StringAlignment = StringAlignment.Center;

		public static bool IsDropShadow = false;

		public static bool IsAntiAlias = false;

		public static Color DropShadowColor = Color.Black;

		public static float DropShadowAngle = 45f;

		public static float DropShadowOffset = 0.05f;
	}

	public const int schema = 10;

	private Color _fontColor;

	private string _family;

	private bool _isBold;

	private bool _isItalic;

	private bool _isUnderline;

	private Fill _fill;

	private Border _border;

	private float _angle;

	private StringAlignment _stringAlignment;

	private float _size;

	private Font _font;

	private bool _isAntiAlias;

	private bool _isDropShadow;

	private Color _dropShadowColor;

	private float _dropShadowAngle;

	private float _dropShadowOffset;

	private Font _superScriptFont;

	private float _scaledSize;

	public Color FontColor
	{
		get
		{
			return _fontColor;
		}
		set
		{
			_fontColor = value;
		}
	}

	public string Family
	{
		get
		{
			return _family;
		}
		set
		{
			if (value != _family)
			{
				_family = value;
				Remake(_scaledSize / _size, Size, ref _scaledSize, ref _font);
			}
		}
	}

	public bool IsBold
	{
		get
		{
			return _isBold;
		}
		set
		{
			if (value != _isBold)
			{
				_isBold = value;
				Remake(_scaledSize / _size, Size, ref _scaledSize, ref _font);
			}
		}
	}

	public bool IsItalic
	{
		get
		{
			return _isItalic;
		}
		set
		{
			if (value != _isItalic)
			{
				_isItalic = value;
				Remake(_scaledSize / _size, Size, ref _scaledSize, ref _font);
			}
		}
	}

	public bool IsUnderline
	{
		get
		{
			return _isUnderline;
		}
		set
		{
			if (value != _isUnderline)
			{
				_isUnderline = value;
				Remake(_scaledSize / _size, Size, ref _scaledSize, ref _font);
			}
		}
	}

	public float Angle
	{
		get
		{
			return _angle;
		}
		set
		{
			_angle = value;
		}
	}

	public StringAlignment StringAlignment
	{
		get
		{
			return _stringAlignment;
		}
		set
		{
			_stringAlignment = value;
		}
	}

	public float Size
	{
		get
		{
			return _size;
		}
		set
		{
			if (value != _size)
			{
				Remake(_scaledSize / _size * value, _size, ref _scaledSize, ref _font);
				_size = value;
			}
		}
	}

	public Border Border
	{
		get
		{
			return _border;
		}
		set
		{
			_border = value;
		}
	}

	public Fill Fill
	{
		get
		{
			return _fill;
		}
		set
		{
			_fill = value;
		}
	}

	public bool IsAntiAlias
	{
		get
		{
			return _isAntiAlias;
		}
		set
		{
			_isAntiAlias = value;
		}
	}

	public bool IsDropShadow
	{
		get
		{
			return _isDropShadow;
		}
		set
		{
			_isDropShadow = value;
		}
	}

	public Color DropShadowColor
	{
		get
		{
			return _dropShadowColor;
		}
		set
		{
			_dropShadowColor = value;
		}
	}

	public float DropShadowAngle
	{
		get
		{
			return _dropShadowAngle;
		}
		set
		{
			_dropShadowAngle = value;
		}
	}

	public float DropShadowOffset
	{
		get
		{
			return _dropShadowOffset;
		}
		set
		{
			_dropShadowOffset = value;
		}
	}

	public FontSpec()
		: this("Arial", 12f, Color.Black, isBold: false, isItalic: false, isUnderline: false)
	{
	}

	public FontSpec(string family, float size, Color color, bool isBold, bool isItalic, bool isUnderline)
	{
		Init(family, size, color, isBold, isItalic, isUnderline, Default.FillColor, Default.FillBrush, Default.FillType);
	}

	public FontSpec(string family, float size, Color color, bool isBold, bool isItalic, bool isUnderline, Color fillColor, Brush fillBrush, FillType fillType)
	{
		Init(family, size, color, isBold, isItalic, isUnderline, fillColor, fillBrush, fillType);
	}

	private void Init(string family, float size, Color color, bool isBold, bool isItalic, bool isUnderline, Color fillColor, Brush fillBrush, FillType fillType)
	{
		_fontColor = color;
		_family = family;
		_isBold = isBold;
		_isItalic = isItalic;
		_isUnderline = isUnderline;
		_size = size;
		_angle = 0f;
		_isAntiAlias = Default.IsAntiAlias;
		_stringAlignment = Default.StringAlignment;
		_isDropShadow = Default.IsDropShadow;
		_dropShadowColor = Default.DropShadowColor;
		_dropShadowAngle = Default.DropShadowAngle;
		_dropShadowOffset = Default.DropShadowOffset;
		_fill = new Fill(fillColor, fillBrush, fillType);
		_border = new Border(isVisible: true, Color.Black, 1f);
		_scaledSize = -1f;
		Remake(1f, _size, ref _scaledSize, ref _font);
	}

	public FontSpec(FontSpec rhs)
	{
		_fontColor = rhs.FontColor;
		_family = rhs.Family;
		_isBold = rhs.IsBold;
		_isItalic = rhs.IsItalic;
		_isUnderline = rhs.IsUnderline;
		_fill = rhs.Fill.Clone();
		_border = rhs.Border.Clone();
		_isAntiAlias = rhs._isAntiAlias;
		_stringAlignment = rhs.StringAlignment;
		_angle = rhs.Angle;
		_size = rhs.Size;
		_isDropShadow = rhs._isDropShadow;
		_dropShadowColor = rhs._dropShadowColor;
		_dropShadowAngle = rhs._dropShadowAngle;
		_dropShadowOffset = rhs._dropShadowOffset;
		_scaledSize = rhs._scaledSize;
		Remake(1f, _size, ref _scaledSize, ref _font);
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public FontSpec Clone()
	{
		return new FontSpec(this);
	}

	protected FontSpec(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_fontColor = (Color)info.GetValue("fontColor", typeof(Color));
		_family = info.GetString("family");
		_isBold = info.GetBoolean("isBold");
		_isItalic = info.GetBoolean("isItalic");
		_isUnderline = info.GetBoolean("isUnderline");
		_isAntiAlias = info.GetBoolean("isAntiAlias");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_angle = info.GetSingle("angle");
		_stringAlignment = (StringAlignment)info.GetValue("stringAlignment", typeof(StringAlignment));
		_size = info.GetSingle("size");
		_isDropShadow = info.GetBoolean("isDropShadow");
		_dropShadowColor = (Color)info.GetValue("dropShadowColor", typeof(Color));
		_dropShadowAngle = info.GetSingle("dropShadowAngle");
		_dropShadowOffset = info.GetSingle("dropShadowOffset");
		_scaledSize = -1f;
		Remake(1f, _size, ref _scaledSize, ref _font);
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("fontColor", _fontColor);
		info.AddValue("family", _family);
		info.AddValue("isBold", _isBold);
		info.AddValue("isItalic", _isItalic);
		info.AddValue("isUnderline", _isUnderline);
		info.AddValue("isAntiAlias", _isAntiAlias);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("angle", _angle);
		info.AddValue("stringAlignment", _stringAlignment);
		info.AddValue("size", _size);
		info.AddValue("isDropShadow", _isDropShadow);
		info.AddValue("dropShadowColor", _dropShadowColor);
		info.AddValue("dropShadowAngle", _dropShadowAngle);
		info.AddValue("dropShadowOffset", _dropShadowOffset);
	}

	private void Remake(float scaleFactor, float size, ref float scaledSize, ref Font font)
	{
		float num = size * scaleFactor;
		float num2 = ((font == null) ? 0f : font.Size);
		if (font == null || (double)Math.Abs(num - num2) > 0.1 || font.Name != Family || font.Bold != _isBold || font.Italic != _isItalic || font.Underline != _isUnderline)
		{
			FontStyle fontStyle = FontStyle.Regular;
			fontStyle = (_isBold ? FontStyle.Bold : fontStyle) | (_isItalic ? FontStyle.Italic : fontStyle) | (_isUnderline ? FontStyle.Underline : fontStyle);
			scaledSize = size * scaleFactor;
			font = new Font(_family, scaledSize, fontStyle, GraphicsUnit.World);
		}
	}

	public Font GetFont(float scaleFactor)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		return _font;
	}

	public void Draw(Graphics g, PaneBase pane, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor)
	{
		Draw(g, pane, text, x, y, alignH, alignV, scaleFactor, default(SizeF));
	}

	public void Draw(Graphics g, PaneBase pane, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor, SizeF layoutArea)
	{
		SmoothingMode smoothingMode = g.SmoothingMode;
		TextRenderingHint textRenderingHint = g.TextRenderingHint;
		if (_isAntiAlias)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		SizeF sizeF = ((!layoutArea.IsEmpty) ? MeasureString(g, text, scaleFactor, layoutArea) : MeasureString(g, text, scaleFactor));
		Matrix transform = g.Transform;
		g.Transform = SetupMatrix(g.Transform, x, y, sizeF, alignH, alignV, _angle);
		RectangleF rectangleF = new RectangleF((0f - sizeF.Width) / 2f, 0f, sizeF.Width, sizeF.Height);
		_fill.Draw(g, rectangleF);
		_border.Draw(g, pane, scaleFactor, rectangleF);
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = _stringAlignment;
		if (_isDropShadow)
		{
			float x2 = (float)(Math.Cos(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
			float y2 = (float)(Math.Sin(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
			RectangleF layoutRectangle = rectangleF;
			layoutRectangle.Offset(x2, y2);
			using SolidBrush brush = new SolidBrush(_dropShadowColor);
			g.DrawString(text, _font, brush, layoutRectangle, stringFormat);
		}
		using (SolidBrush brush2 = new SolidBrush(_fontColor))
		{
			g.DrawString(text, _font, brush2, rectangleF, stringFormat);
		}
		g.Transform = transform;
		g.SmoothingMode = smoothingMode;
		g.TextRenderingHint = textRenderingHint;
	}

	public void DrawTenPower(Graphics g, GraphPane pane, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor)
	{
		SmoothingMode smoothingMode = g.SmoothingMode;
		TextRenderingHint textRenderingHint = g.TextRenderingHint;
		if (_isAntiAlias)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
		}
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		float scaledSize = _scaledSize * Default.SuperSize;
		Remake(scaleFactor, Size * Default.SuperSize, ref scaledSize, ref _superScriptFont);
		SizeF sizeF = g.MeasureString("10", _font);
		SizeF sizeF2 = g.MeasureString(text, _superScriptFont);
		SizeF sizeF3 = new SizeF(sizeF.Width + sizeF2.Width, sizeF.Height + sizeF2.Height * Default.SuperShift);
		float width = g.MeasureString("x", _superScriptFont).Width;
		Matrix transform = g.Transform;
		g.Transform = SetupMatrix(g.Transform, x, y, sizeF3, alignH, alignV, _angle);
		StringFormat stringFormat = new StringFormat();
		stringFormat.Alignment = _stringAlignment;
		RectangleF rect = new RectangleF((0f - sizeF3.Width) / 2f, 0f, sizeF3.Width, sizeF3.Height);
		_fill.Draw(g, rect);
		_border.Draw(g, pane, scaleFactor, rect);
		using (SolidBrush brush = new SolidBrush(_fontColor))
		{
			g.DrawString("10", _font, brush, (0f - sizeF3.Width + sizeF.Width) / 2f, sizeF2.Height * Default.SuperShift, stringFormat);
			g.DrawString(text, _superScriptFont, brush, (sizeF3.Width - sizeF2.Width - width) / 2f, 0f, stringFormat);
		}
		g.Transform = transform;
		g.SmoothingMode = smoothingMode;
		g.TextRenderingHint = textRenderingHint;
	}

	public float GetHeight(float scaleFactor)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		float num = _font.Height;
		if (_isDropShadow)
		{
			num += (float)(Math.Sin(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
		}
		return num;
	}

	public float GetWidth(Graphics g, float scaleFactor)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		return g.MeasureString("x", _font).Width;
	}

	public float GetWidth(Graphics g, string text, float scaleFactor)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		float num = g.MeasureString(text, _font).Width;
		if (_isDropShadow)
		{
			num += (float)(Math.Cos(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
		}
		return num;
	}

	public SizeF MeasureString(Graphics g, string text, float scaleFactor)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		SizeF result = g.MeasureString(text, _font);
		if (_isDropShadow)
		{
			result.Width += (float)(Math.Cos(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
			result.Height += (float)(Math.Sin(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
		}
		return result;
	}

	public SizeF MeasureString(Graphics g, string text, float scaleFactor, SizeF layoutArea)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		SizeF result = g.MeasureString(text, _font, layoutArea);
		if (_isDropShadow)
		{
			result.Width += (float)(Math.Cos(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
			result.Height += (float)(Math.Sin(_dropShadowAngle) * (double)_dropShadowOffset * (double)_font.Height);
		}
		return result;
	}

	public SizeF BoundingBox(Graphics g, string text, float scaleFactor)
	{
		return BoundingBox(g, text, scaleFactor, default(SizeF));
	}

	public SizeF BoundingBox(Graphics g, string text, float scaleFactor, SizeF layoutArea)
	{
		SizeF sizeF = ((!layoutArea.IsEmpty) ? MeasureString(g, text, scaleFactor, layoutArea) : MeasureString(g, text, scaleFactor));
		float num = (float)Math.Abs(Math.Cos((double)_angle * Math.PI / 180.0));
		float num2 = (float)Math.Abs(Math.Sin((double)_angle * Math.PI / 180.0));
		return new SizeF(sizeF.Width * num + sizeF.Height * num2, sizeF.Width * num2 + sizeF.Height * num);
	}

	public SizeF BoundingBoxTenPower(Graphics g, string text, float scaleFactor)
	{
		float scaledSize = _scaledSize * Default.SuperSize;
		Remake(scaleFactor, Size * Default.SuperSize, ref scaledSize, ref _superScriptFont);
		SizeF sizeF = MeasureString(g, "10", scaleFactor);
		SizeF sizeF2 = g.MeasureString(text, _superScriptFont);
		if (_isDropShadow)
		{
			sizeF2.Width += (float)(Math.Cos(_dropShadowAngle) * (double)_dropShadowOffset * (double)_superScriptFont.Height);
			sizeF2.Height += (float)(Math.Sin(_dropShadowAngle) * (double)_dropShadowOffset * (double)_superScriptFont.Height);
		}
		SizeF sizeF3 = new SizeF(sizeF.Width + sizeF2.Width, sizeF.Height + sizeF2.Height * Default.SuperShift);
		float num = (float)Math.Abs(Math.Cos((double)_angle * Math.PI / 180.0));
		float num2 = (float)Math.Abs(Math.Sin((double)_angle * Math.PI / 180.0));
		return new SizeF(sizeF3.Width * num + sizeF3.Height * num2, sizeF3.Width * num2 + sizeF3.Height * num);
	}

	public bool PointInBox(PointF pt, Graphics g, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor)
	{
		return PointInBox(pt, g, text, x, y, alignH, alignV, scaleFactor, default(SizeF));
	}

	public bool PointInBox(PointF pt, Graphics g, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor, SizeF layoutArea)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		SizeF sizeF = ((!layoutArea.IsEmpty) ? g.MeasureString(text, _font, layoutArea) : g.MeasureString(text, _font));
		RectangleF rectangleF = new RectangleF(new PointF((0f - sizeF.Width) / 2f, 0f), sizeF);
		Matrix matrix = GetMatrix(x, y, sizeF, alignH, alignV, _angle);
		PointF[] array = new PointF[1] { pt };
		matrix.TransformPoints(array);
		return rectangleF.Contains(array[0]);
	}

	private Matrix SetupMatrix(Matrix matrix, float x, float y, SizeF sizeF, AlignH alignH, AlignV alignV, float angle)
	{
		matrix.Translate(x, y, MatrixOrder.Prepend);
		if (_angle != 0f)
		{
			matrix.Rotate(0f - angle, MatrixOrder.Prepend);
		}
		matrix.Translate(alignH switch
		{
			AlignH.Left => sizeF.Width / 2f, 
			AlignH.Right => (0f - sizeF.Width) / 2f, 
			_ => 0f, 
		}, alignV switch
		{
			AlignV.Center => (0f - sizeF.Height) / 2f, 
			AlignV.Bottom => 0f - sizeF.Height, 
			_ => 0f, 
		}, MatrixOrder.Prepend);
		return matrix;
	}

	private Matrix GetMatrix(float x, float y, SizeF sizeF, AlignH alignH, AlignV alignV, float angle)
	{
		Matrix matrix = new Matrix();
		matrix.Translate(0f - alignH switch
		{
			AlignH.Left => sizeF.Width / 2f, 
			AlignH.Right => (0f - sizeF.Width) / 2f, 
			_ => 0f, 
		}, 0f - alignV switch
		{
			AlignV.Center => (0f - sizeF.Height) / 2f, 
			AlignV.Bottom => 0f - sizeF.Height, 
			_ => 0f, 
		}, MatrixOrder.Prepend);
		if (angle != 0f)
		{
			matrix.Rotate(angle, MatrixOrder.Prepend);
		}
		matrix.Translate(0f - x, 0f - y, MatrixOrder.Prepend);
		return matrix;
	}

	public PointF[] GetBox(Graphics g, string text, float x, float y, AlignH alignH, AlignV alignV, float scaleFactor, SizeF layoutArea)
	{
		Remake(scaleFactor, Size, ref _scaledSize, ref _font);
		SizeF sizeF = ((!layoutArea.IsEmpty) ? g.MeasureString(text, _font, layoutArea) : g.MeasureString(text, _font));
		RectangleF rectangleF = new RectangleF(new PointF((0f - sizeF.Width) / 2f, 0f), sizeF);
		Matrix matrix = new Matrix();
		SetupMatrix(matrix, x, y, sizeF, alignH, alignV, _angle);
		PointF[] array = new PointF[4]
		{
			new PointF(rectangleF.Left, rectangleF.Top),
			new PointF(rectangleF.Right, rectangleF.Top),
			new PointF(rectangleF.Right, rectangleF.Bottom),
			new PointF(rectangleF.Left, rectangleF.Bottom)
		};
		matrix.TransformPoints(array);
		return array;
	}
}
