using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Fill : ISerializable, ICloneable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static bool IsScaled = true;

		public static AlignH AlignH = AlignH.Center;

		public static AlignV AlignV = AlignV.Center;
	}

	public const int schema = 10;

	private Color _color;

	private Color _secondaryValueGradientColor;

	protected Brush _brush;

	private FillType _type;

	private bool _isScaled;

	private AlignH _alignH;

	private AlignV _alignV;

	private double _rangeMin;

	private double _rangeMax;

	private double _rangeDefault;

	private Bitmap _gradientBM;

	private Image _image;

	private WrapMode _wrapMode;

	private Color[] _colorList;

	private float[] _positionList;

	private float _angle;

	public Color Color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
		}
	}

	public Color SecondaryValueGradientColor
	{
		get
		{
			return _secondaryValueGradientColor;
		}
		set
		{
			_secondaryValueGradientColor = value;
		}
	}

	public Brush Brush
	{
		get
		{
			return _brush;
		}
		set
		{
			_brush = value;
		}
	}

	public FillType Type
	{
		get
		{
			return _type;
		}
		set
		{
			_type = value;
		}
	}

	public bool IsVisible
	{
		get
		{
			return _type != FillType.None;
		}
		set
		{
			_type = (value ? ((_type == FillType.None) ? FillType.Brush : _type) : FillType.None);
		}
	}

	public bool IsScaled
	{
		get
		{
			return _isScaled;
		}
		set
		{
			_isScaled = value;
		}
	}

	public AlignH AlignH
	{
		get
		{
			return _alignH;
		}
		set
		{
			_alignH = value;
		}
	}

	public AlignV AlignV
	{
		get
		{
			return _alignV;
		}
		set
		{
			_alignV = value;
		}
	}

	public bool IsGradientValueType
	{
		get
		{
			if (_type != FillType.GradientByX && _type != FillType.GradientByY && _type != FillType.GradientByZ)
			{
				return _type == FillType.GradientByColorValue;
			}
			return true;
		}
	}

	public double RangeMin
	{
		get
		{
			return _rangeMin;
		}
		set
		{
			_rangeMin = value;
		}
	}

	public double RangeMax
	{
		get
		{
			return _rangeMax;
		}
		set
		{
			_rangeMax = value;
		}
	}

	public double RangeDefault
	{
		get
		{
			return _rangeDefault;
		}
		set
		{
			_rangeDefault = value;
		}
	}

	private void Init()
	{
		_color = Color.White;
		_secondaryValueGradientColor = Color.White;
		_brush = null;
		_type = FillType.None;
		_isScaled = Default.IsScaled;
		_alignH = Default.AlignH;
		_alignV = Default.AlignV;
		_rangeMin = 0.0;
		_rangeMax = 1.0;
		_rangeDefault = double.MaxValue;
		_gradientBM = null;
		_colorList = null;
		_positionList = null;
		_angle = 0f;
		_image = null;
		_wrapMode = WrapMode.Tile;
	}

	public Fill()
	{
		Init();
	}

	public Fill(Color color, Brush brush, FillType type)
	{
		Init();
		_color = color;
		_brush = brush;
		_type = type;
	}

	public Fill(Color color)
	{
		Init();
		_color = color;
		if (color != Color.Empty)
		{
			_type = FillType.Solid;
		}
	}

	public Fill(Color color1, Color color2, float angle)
	{
		Init();
		_color = color2;
		ColorBlend colorBlend = new ColorBlend(2);
		colorBlend.Colors[0] = color1;
		colorBlend.Colors[1] = color2;
		colorBlend.Positions[0] = 0f;
		colorBlend.Positions[1] = 1f;
		_type = FillType.Brush;
		CreateBrushFromBlend(colorBlend, angle);
	}

	public Fill(Color color1, Color color2)
		: this(color1, color2, 0f)
	{
	}

	public Fill(Color color1, Color color2, Color color3)
		: this(color1, color2, color3, 0f)
	{
	}

	public Fill(Color color1, Color color2, Color color3, float angle)
	{
		Init();
		_color = color3;
		ColorBlend colorBlend = new ColorBlend(3);
		colorBlend.Colors[0] = color1;
		colorBlend.Colors[1] = color2;
		colorBlend.Colors[2] = color3;
		colorBlend.Positions[0] = 0f;
		colorBlend.Positions[1] = 0.5f;
		colorBlend.Positions[2] = 1f;
		_type = FillType.Brush;
		CreateBrushFromBlend(colorBlend, angle);
	}

	public Fill(ColorBlend blend)
		: this(blend, 0f)
	{
	}

	public Fill(ColorBlend blend, float angle)
	{
		Init();
		_type = FillType.Brush;
		CreateBrushFromBlend(blend, angle);
	}

	public Fill(Color[] colors)
		: this(colors, 0f)
	{
	}

	public Fill(Color[] colors, float angle)
	{
		Init();
		_color = colors[colors.Length - 1];
		ColorBlend colorBlend = new ColorBlend
		{
			Colors = colors,
			Positions = new float[colors.Length]
		};
		colorBlend.Positions[0] = 0f;
		for (int i = 1; i < colors.Length; i++)
		{
			colorBlend.Positions[i] = (float)i / (float)(colors.Length - 1);
		}
		_type = FillType.Brush;
		CreateBrushFromBlend(colorBlend, angle);
	}

	public Fill(Color[] colors, float[] positions)
		: this(colors, positions, 0f)
	{
	}

	public Fill(Color[] colors, float[] positions, float angle)
	{
		Init();
		_color = colors[colors.Length - 1];
		ColorBlend blend = new ColorBlend
		{
			Colors = colors,
			Positions = positions
		};
		_type = FillType.Brush;
		CreateBrushFromBlend(blend, angle);
	}

	public Fill(Image image, WrapMode wrapMode)
	{
		Init();
		_color = Color.White;
		_brush = new TextureBrush(image, wrapMode);
		_type = FillType.Brush;
		_image = image;
		_wrapMode = wrapMode;
	}

	public Fill(Brush brush)
		: this(brush, Default.IsScaled)
	{
	}

	public Fill(Brush brush, bool isScaled)
	{
		Init();
		_isScaled = isScaled;
		_color = Color.White;
		_brush = (Brush)brush.Clone();
		_type = FillType.Brush;
	}

	public Fill(Brush brush, AlignH alignH, AlignV alignV)
	{
		Init();
		_alignH = alignH;
		_alignV = alignV;
		_isScaled = false;
		_color = Color.White;
		_brush = (Brush)brush.Clone();
		_type = FillType.Brush;
	}

	public Fill(Fill rhs)
	{
		_color = rhs._color;
		_secondaryValueGradientColor = rhs._color;
		if (rhs._brush != null)
		{
			_brush = (Brush)rhs._brush.Clone();
		}
		else
		{
			_brush = null;
		}
		_type = rhs._type;
		_alignH = rhs.AlignH;
		_alignV = rhs.AlignV;
		_isScaled = rhs.IsScaled;
		_rangeMin = rhs._rangeMin;
		_rangeMax = rhs._rangeMax;
		_rangeDefault = rhs._rangeDefault;
		_gradientBM = null;
		if (rhs._colorList != null)
		{
			_colorList = (Color[])rhs._colorList.Clone();
		}
		else
		{
			_colorList = null;
		}
		if (rhs._positionList != null)
		{
			_positionList = (float[])rhs._positionList.Clone();
		}
		else
		{
			_positionList = null;
		}
		if (rhs._image != null)
		{
			_image = (Image)rhs._image.Clone();
		}
		else
		{
			_image = null;
		}
		_angle = rhs._angle;
		_wrapMode = rhs._wrapMode;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Fill Clone()
	{
		return new Fill(this);
	}

	private void CreateBrushFromBlend(ColorBlend blend, float angle)
	{
		_angle = angle;
		_colorList = (Color[])blend.Colors.Clone();
		_positionList = (float[])blend.Positions.Clone();
		_brush = new LinearGradientBrush(new Rectangle(0, 0, 100, 100), Color.Red, Color.White, angle);
		((LinearGradientBrush)_brush).InterpolationColors = blend;
	}

	protected Fill(SerializationInfo info, StreamingContext context)
	{
		Init();
		info.GetInt32("schema");
		_color = (Color)info.GetValue("color", typeof(Color));
		_secondaryValueGradientColor = (Color)info.GetValue("secondaryValueGradientColor", typeof(Color));
		_type = (FillType)info.GetValue("type", typeof(FillType));
		_isScaled = info.GetBoolean("isScaled");
		_alignH = (AlignH)info.GetValue("alignH", typeof(AlignH));
		_alignV = (AlignV)info.GetValue("alignV", typeof(AlignV));
		_rangeMin = info.GetDouble("rangeMin");
		_rangeMax = info.GetDouble("rangeMax");
		_colorList = (Color[])info.GetValue("colorList", typeof(Color[]));
		_positionList = (float[])info.GetValue("positionList", typeof(float[]));
		_angle = info.GetSingle("angle");
		_image = (Image)info.GetValue("image", typeof(Image));
		_wrapMode = (WrapMode)info.GetValue("wrapMode", typeof(WrapMode));
		if (_colorList != null && _positionList != null)
		{
			CreateBrushFromBlend(new ColorBlend
			{
				Colors = _colorList,
				Positions = _positionList
			}, _angle);
		}
		else if (_image != null)
		{
			_brush = new TextureBrush(_image, _wrapMode);
		}
		_rangeDefault = info.GetDouble("rangeDefault");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("color", _color);
		info.AddValue("secondaryValueGradientColor", _secondaryValueGradientColor);
		info.AddValue("type", _type);
		info.AddValue("isScaled", _isScaled);
		info.AddValue("alignH", _alignH);
		info.AddValue("alignV", _alignV);
		info.AddValue("rangeMin", _rangeMin);
		info.AddValue("rangeMax", _rangeMax);
		info.AddValue("colorList", _colorList);
		info.AddValue("positionList", _positionList);
		info.AddValue("angle", _angle);
		info.AddValue("image", _image);
		info.AddValue("wrapMode", _wrapMode);
		info.AddValue("rangeDefault", _rangeDefault);
	}

	public Brush MakeBrush(RectangleF rect)
	{
		return MakeBrush(rect, null);
	}

	public Brush MakeBrush(RectangleF rect, PointPair dataValue)
	{
		if (IsVisible && (!_color.IsEmpty || _brush != null))
		{
			if (rect.Height < 1f)
			{
				rect.Height = 1f;
			}
			if (rect.Width < 1f)
			{
				rect.Width = 1f;
			}
			if (_type == FillType.Brush)
			{
				return ScaleBrush(rect, _brush, _isScaled);
			}
			if (IsGradientValueType)
			{
				if (dataValue != null)
				{
					if (!_secondaryValueGradientColor.IsEmpty)
					{
						Fill fill = new Fill(_secondaryValueGradientColor, GetGradientColor(dataValue), _angle);
						return fill.MakeBrush(rect);
					}
					return new SolidBrush(GetGradientColor(dataValue));
				}
				if (_rangeDefault != double.MaxValue)
				{
					if (!_secondaryValueGradientColor.IsEmpty)
					{
						Fill fill2 = new Fill(_secondaryValueGradientColor, GetGradientColor(_rangeDefault), _angle);
						return fill2.MakeBrush(rect);
					}
					return new SolidBrush(GetGradientColor(_rangeDefault));
				}
				return ScaleBrush(rect, _brush, isScaled: true);
			}
			return new SolidBrush(_color);
		}
		return new SolidBrush(Color.White);
	}

	internal Color GetGradientColor(PointPair dataValue)
	{
		double val = ((dataValue == null) ? _rangeDefault : ((_type == FillType.GradientByColorValue) ? dataValue.ColorValue : ((_type == FillType.GradientByZ) ? dataValue.Z : ((_type != FillType.GradientByY) ? dataValue.X : dataValue.Y))));
		return GetGradientColor(val);
	}

	internal Color GetGradientColor(double val)
	{
		if (double.IsInfinity(val) || double.IsNaN(val) || val == double.MaxValue)
		{
			val = _rangeDefault;
		}
		double num = ((!(_rangeMax - _rangeMin < 1E-20) && val != double.MaxValue) ? ((val - _rangeMin) / (_rangeMax - _rangeMin)) : 0.5);
		if (num < 0.0)
		{
			num = 0.0;
		}
		else if (num > 1.0)
		{
			num = 1.0;
		}
		if (_gradientBM == null)
		{
			RectangleF rect = new RectangleF(0f, 0f, 100f, 1f);
			_gradientBM = new Bitmap(100, 1);
			Graphics graphics = Graphics.FromImage(_gradientBM);
			Brush brush = ScaleBrush(rect, _brush, isScaled: true);
			graphics.FillRectangle(brush, rect);
		}
		return _gradientBM.GetPixel((int)(99.9 * num), 0);
	}

	private Brush ScaleBrush(RectangleF rect, Brush brush, bool isScaled)
	{
		if (brush != null)
		{
			if (brush is SolidBrush)
			{
				return (Brush)brush.Clone();
			}
			if (brush is LinearGradientBrush)
			{
				LinearGradientBrush linearGradientBrush = (LinearGradientBrush)brush.Clone();
				if (isScaled)
				{
					linearGradientBrush.ScaleTransform(rect.Width / linearGradientBrush.Rectangle.Width, rect.Height / linearGradientBrush.Rectangle.Height, MatrixOrder.Append);
					linearGradientBrush.TranslateTransform(rect.Left - linearGradientBrush.Rectangle.Left, rect.Top - linearGradientBrush.Rectangle.Top, MatrixOrder.Append);
				}
				else
				{
					float dx = 0f;
					float dy = 0f;
					switch (_alignH)
					{
					case AlignH.Left:
						dx = rect.Left - linearGradientBrush.Rectangle.Left;
						break;
					case AlignH.Center:
						dx = rect.Left + rect.Width / 2f - linearGradientBrush.Rectangle.Left;
						break;
					case AlignH.Right:
						dx = rect.Left + rect.Width - linearGradientBrush.Rectangle.Left;
						break;
					}
					switch (_alignV)
					{
					case AlignV.Top:
						dy = rect.Top - linearGradientBrush.Rectangle.Top;
						break;
					case AlignV.Center:
						dy = rect.Top + rect.Height / 2f - linearGradientBrush.Rectangle.Top;
						break;
					case AlignV.Bottom:
						dy = rect.Top + rect.Height - linearGradientBrush.Rectangle.Top;
						break;
					}
					linearGradientBrush.TranslateTransform(dx, dy, MatrixOrder.Append);
				}
				return linearGradientBrush;
			}
			if (brush is TextureBrush)
			{
				TextureBrush textureBrush = (TextureBrush)brush.Clone();
				if (isScaled)
				{
					textureBrush.ScaleTransform(rect.Width / (float)textureBrush.Image.Width, rect.Height / (float)textureBrush.Image.Height, MatrixOrder.Append);
					textureBrush.TranslateTransform(rect.Left, rect.Top, MatrixOrder.Append);
				}
				else
				{
					float dx2 = 0f;
					float dy2 = 0f;
					switch (_alignH)
					{
					case AlignH.Left:
						dx2 = rect.Left;
						break;
					case AlignH.Center:
						dx2 = rect.Left + rect.Width / 2f;
						break;
					case AlignH.Right:
						dx2 = rect.Left + rect.Width;
						break;
					}
					switch (_alignV)
					{
					case AlignV.Top:
						dy2 = rect.Top;
						break;
					case AlignV.Center:
						dy2 = rect.Top + rect.Height / 2f;
						break;
					case AlignV.Bottom:
						dy2 = rect.Top + rect.Height;
						break;
					}
					textureBrush.TranslateTransform(dx2, dy2, MatrixOrder.Append);
				}
				return textureBrush;
			}
			return (Brush)brush.Clone();
		}
		return new LinearGradientBrush(rect, Color.White, _color, 0f);
	}

	public void Draw(Graphics g, RectangleF rect)
	{
		Draw(g, rect, null);
	}

	public void Draw(Graphics g, RectangleF rect, PointPair pt)
	{
		if (IsVisible)
		{
			using (Brush brush = MakeBrush(rect, pt))
			{
				g.FillRectangle(brush, rect);
			}
		}
	}
}
