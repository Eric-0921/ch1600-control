using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

public abstract class PaneBase : ICloneable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static bool IsShowTitle = true;

		public static string FontFamily = "Arial";

		public static float FontSize = 16f;

		public static Color FontColor = Color.Black;

		public static bool FontBold = true;

		public static bool FontItalic = false;

		public static bool FontUnderline = false;

		public static bool IsBorderVisible = true;

		public static Color BorderColor = Color.Black;

		public static Color FillColor = Color.White;

		public static float BorderPenWidth = 1f;

		public static float BaseDimension = 8f;

		public static bool IsPenWidthScaled = false;

		public static bool IsFontsScaled = true;

		public static float TitleGap = 0.5f;
	}

	public const int schema = 10;

	protected RectangleF _rect;

	protected GapLabel _title;

	protected Legend _legend;

	protected object _tag;

	internal Margin _margin;

	protected bool _isFontsScaled;

	protected bool _isPenWidthScaled;

	protected Fill _fill;

	protected Border _border;

	protected GraphObjList _graphObjList;

	protected float _baseDimension;

	protected float _titleGap;

	public RectangleF Rect
	{
		get
		{
			return _rect;
		}
		set
		{
			_rect = value;
		}
	}

	public Legend Legend => _legend;

	public Label Title => _title;

	public object Tag
	{
		get
		{
			return _tag;
		}
		set
		{
			_tag = value;
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

	public GraphObjList GraphObjList
	{
		get
		{
			return _graphObjList;
		}
		set
		{
			_graphObjList = value;
		}
	}

	public Margin Margin
	{
		get
		{
			return _margin;
		}
		set
		{
			_margin = value;
		}
	}

	public float BaseDimension
	{
		get
		{
			return _baseDimension;
		}
		set
		{
			_baseDimension = value;
		}
	}

	public float TitleGap
	{
		get
		{
			return _titleGap;
		}
		set
		{
			_titleGap = value;
		}
	}

	public bool IsFontsScaled
	{
		get
		{
			return _isFontsScaled;
		}
		set
		{
			_isFontsScaled = value;
		}
	}

	public bool IsPenWidthScaled
	{
		get
		{
			return _isPenWidthScaled;
		}
		set
		{
			_isPenWidthScaled = value;
		}
	}

	public PaneBase()
		: this("", new RectangleF(0f, 0f, 0f, 0f))
	{
	}

	public PaneBase(string title, RectangleF paneRect)
	{
		_rect = paneRect;
		_legend = new Legend();
		_baseDimension = Default.BaseDimension;
		_margin = new Margin();
		_titleGap = Default.TitleGap;
		_isFontsScaled = Default.IsFontsScaled;
		_isPenWidthScaled = Default.IsPenWidthScaled;
		_fill = new Fill(Default.FillColor);
		_border = new Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderPenWidth);
		_title = new GapLabel(title, Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontItalic, Default.FontUnderline);
		_title._fontSpec.Fill.IsVisible = false;
		_title._fontSpec.Border.IsVisible = false;
		_graphObjList = new GraphObjList();
		_tag = null;
	}

	public PaneBase(PaneBase rhs)
	{
		_isFontsScaled = rhs._isFontsScaled;
		_isPenWidthScaled = rhs._isPenWidthScaled;
		_titleGap = rhs._titleGap;
		_baseDimension = rhs._baseDimension;
		_margin = rhs._margin.Clone();
		_rect = rhs._rect;
		_fill = rhs._fill.Clone();
		_border = rhs._border.Clone();
		_title = rhs._title.Clone();
		_legend = rhs.Legend.Clone();
		_title = rhs._title.Clone();
		_graphObjList = rhs._graphObjList.Clone();
		if (rhs._tag is ICloneable)
		{
			_tag = ((ICloneable)rhs._tag).Clone();
		}
		else
		{
			_tag = rhs._tag;
		}
	}

	object ICloneable.Clone()
	{
		throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
	}

	public PaneBase ShallowClone()
	{
		return MemberwiseClone() as PaneBase;
	}

	protected PaneBase(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_rect = (RectangleF)info.GetValue("rect", typeof(RectangleF));
		_legend = (Legend)info.GetValue("legend", typeof(Legend));
		_title = (GapLabel)info.GetValue("title", typeof(GapLabel));
		_isFontsScaled = info.GetBoolean("isFontsScaled");
		_isPenWidthScaled = info.GetBoolean("isPenWidthScaled");
		_titleGap = info.GetSingle("titleGap");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_baseDimension = info.GetSingle("baseDimension");
		_margin = (Margin)info.GetValue("margin", typeof(Margin));
		_graphObjList = (GraphObjList)info.GetValue("graphObjList", typeof(GraphObjList));
		_tag = info.GetValue("tag", typeof(object));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("rect", _rect);
		info.AddValue("legend", _legend);
		info.AddValue("title", _title);
		info.AddValue("isFontsScaled", _isFontsScaled);
		info.AddValue("isPenWidthScaled", _isPenWidthScaled);
		info.AddValue("titleGap", _titleGap);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("baseDimension", _baseDimension);
		info.AddValue("margin", _margin);
		info.AddValue("graphObjList", _graphObjList);
		info.AddValue("tag", _tag);
	}

	public virtual void Draw(Graphics g)
	{
		if (!(_rect.Width <= 1f) && !(_rect.Height <= 1f))
		{
			float scaleFactor = CalcScaleFactor();
			DrawPaneFrame(g, scaleFactor);
			g.SetClip(_rect);
			_graphObjList.Draw(g, this, scaleFactor, ZOrder.H_BehindAll);
			DrawTitle(g, scaleFactor);
			g.ResetClip();
		}
	}

	public RectangleF CalcClientRect(Graphics g, float scaleFactor)
	{
		float height = _title._fontSpec.GetHeight(scaleFactor);
		RectangleF result = new RectangleF(_rect.Left + _margin.Left * scaleFactor, _rect.Top + _margin.Top * scaleFactor, _rect.Width - scaleFactor * (_margin.Left + _margin.Right), _rect.Height - scaleFactor * (_margin.Top + _margin.Bottom));
		if (_title._isVisible && _title._text != string.Empty)
		{
			SizeF sizeF = _title._fontSpec.BoundingBox(g, _title._text, scaleFactor);
			result.Y += sizeF.Height + height * _titleGap;
			result.Height -= sizeF.Height + height * _titleGap;
		}
		return result;
	}

	public void DrawPaneFrame(Graphics g, float scaleFactor)
	{
		_fill.Draw(g, _rect);
		RectangleF rect = new RectangleF(_rect.X, _rect.Y, _rect.Width - 1f, _rect.Height - 1f);
		_border.Draw(g, this, scaleFactor, rect);
	}

	public void DrawTitle(Graphics g, float scaleFactor)
	{
		if (_title._isVisible)
		{
			SizeF sizeF = _title._fontSpec.BoundingBox(g, _title._text, scaleFactor);
			_title._fontSpec.Draw(g, this, _title._text, (_rect.Left + _rect.Right) / 2f, _rect.Top + _margin.Top * scaleFactor + sizeF.Height / 2f, AlignH.Center, AlignV.Center, scaleFactor);
		}
	}

	public virtual void ReSize(Graphics g, RectangleF rect)
	{
		_rect = rect;
	}

	public float CalcScaleFactor()
	{
		if (!_isFontsScaled)
		{
			return 1f;
		}
		if (_rect.Height <= 0f)
		{
			return 1f;
		}
		float num = _rect.Width;
		float num2 = _rect.Width / _rect.Height;
		if (num2 > 1.5f)
		{
			num = _rect.Height * 1.5f;
		}
		if (num2 < 2f / 3f)
		{
			num = _rect.Width * 1.5f;
		}
		float num3 = num / (_baseDimension * 72f);
		if (num3 < 0.1f)
		{
			num3 = 0.1f;
		}
		return num3;
	}

	public float ScaledPenWidth(float penWidth, float scaleFactor)
	{
		if (_isPenWidthScaled)
		{
			return penWidth * scaleFactor;
		}
		return penWidth;
	}

	public Bitmap GetImage()
	{
		return GetImage(isAntiAlias: false);
	}

	public Bitmap GetImage(bool isAntiAlias)
	{
		Bitmap bitmap = new Bitmap((int)_rect.Width, (int)_rect.Height);
		using Graphics graphics = Graphics.FromImage(bitmap);
		graphics.TranslateTransform(0f - _rect.Left, 0f - _rect.Top);
		Draw(graphics);
		return bitmap;
	}

	public Bitmap GetImage(int width, int height, float dpi, bool isAntiAlias)
	{
		Bitmap bitmap = new Bitmap(width, height);
		bitmap.SetResolution(dpi, dpi);
		using Graphics g = Graphics.FromImage(bitmap);
		MakeImage(g, width, height, isAntiAlias);
		return bitmap;
	}

	public Bitmap GetImage(int width, int height, float dpi)
	{
		return GetImage(width, height, dpi, isAntiAlias: false);
	}

	internal void SetAntiAliasMode(Graphics g, bool isAntiAlias)
	{
		if (isAntiAlias)
		{
			g.SmoothingMode = SmoothingMode.HighQuality;
			g.TextRenderingHint = TextRenderingHint.AntiAlias;
			g.CompositingQuality = CompositingQuality.HighQuality;
			g.InterpolationMode = InterpolationMode.HighQualityBicubic;
		}
	}

	private void MakeImage(Graphics g, int width, int height, bool antiAlias)
	{
		SetAntiAliasMode(g, antiAlias);
		PaneBase paneBase = ShallowClone();
		paneBase.ReSize(g, new RectangleF(0f, 0f, width, height));
		paneBase.Draw(g);
		Bitmap image = new Bitmap(1, 1);
		using Graphics g2 = Graphics.FromImage(image);
		ReSize(g2, Rect);
		SetAntiAliasMode(g2, antiAlias);
		Draw(g2);
	}

	public Metafile GetMetafile(int width, int height, bool isAntiAlias)
	{
		Bitmap image = new Bitmap(1, 1);
		using Graphics graphics = Graphics.FromImage(image);
		IntPtr hdc = graphics.GetHdc();
		Stream stream = new MemoryStream();
		Metafile metafile = new Metafile(stream, hdc, _rect, MetafileFrameUnit.Pixel, EmfType.EmfPlusDual);
		graphics.ReleaseHdc(hdc);
		using Graphics graphics2 = Graphics.FromImage(metafile);
		graphics2.PageUnit = GraphicsUnit.Pixel;
		PointF pointF = new PointF(width, height);
		PointF[] pts = new PointF[1] { pointF };
		graphics2.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pts);
		MakeImage(graphics2, width, height, isAntiAlias);
		return metafile;
	}

	public Metafile GetMetafile(int width, int height)
	{
		return GetMetafile(width, height, isAntiAlias: false);
	}

	public Metafile GetMetafile()
	{
		Bitmap image = new Bitmap(1, 1);
		using Graphics graphics = Graphics.FromImage(image);
		IntPtr hdc = graphics.GetHdc();
		Stream stream = new MemoryStream();
		Metafile metafile = new Metafile(stream, hdc, _rect, MetafileFrameUnit.Pixel, EmfType.EmfOnly);
		using Graphics graphics2 = Graphics.FromImage(metafile);
		graphics2.TranslateTransform(0f - _rect.Left, 0f - _rect.Top);
		graphics2.PageUnit = GraphicsUnit.Pixel;
		PointF pointF = new PointF(_rect.Width, _rect.Height);
		PointF[] pts = new PointF[1] { pointF };
		graphics2.TransformPoints(CoordinateSpace.Page, CoordinateSpace.Device, pts);
		Draw(graphics2);
		graphics.ReleaseHdc(hdc);
		return metafile;
	}

	internal PointF TransformCoord(double x, double y, CoordType coord)
	{
		if (!(this is GraphPane) && coord != CoordType.PaneFraction)
		{
			coord = CoordType.PaneFraction;
			x = 0.5;
			y = 0.5;
		}
		GraphPane graphPane = null;
		RectangleF rectangleF = new RectangleF(0f, 0f, 1f, 1f);
		if (this is GraphPane)
		{
			graphPane = this as GraphPane;
			rectangleF = graphPane.Chart._rect;
		}
		PointF result = default(PointF);
		switch (coord)
		{
		case CoordType.ChartFraction:
			result.X = (float)((double)rectangleF.Left + x * (double)rectangleF.Width);
			result.Y = (float)((double)rectangleF.Top + y * (double)rectangleF.Height);
			break;
		case CoordType.AxisXYScale:
			result.X = graphPane.XAxis.Scale.Transform(x);
			result.Y = graphPane.YAxis.Scale.Transform(y);
			break;
		case CoordType.AxisXY2Scale:
			result.X = graphPane.XAxis.Scale.Transform(x);
			result.Y = graphPane.Y2Axis.Scale.Transform(y);
			break;
		case CoordType.XScaleYChartFraction:
			result.X = graphPane.XAxis.Scale.Transform(x);
			result.Y = (float)((double)rectangleF.Top + y * (double)rectangleF.Height);
			break;
		case CoordType.XChartFractionYScale:
			result.X = (float)((double)rectangleF.Left + x * (double)rectangleF.Width);
			result.Y = graphPane.YAxis.Scale.Transform(y);
			break;
		case CoordType.XChartFractionY2Scale:
			result.X = (float)((double)rectangleF.Left + x * (double)rectangleF.Width);
			result.Y = graphPane.Y2Axis.Scale.Transform(y);
			break;
		case CoordType.XChartFractionYPaneFraction:
			result.X = (float)((double)rectangleF.Left + x * (double)rectangleF.Width);
			result.Y = (float)((double)Rect.Top + y * (double)_rect.Height);
			break;
		case CoordType.XPaneFractionYChartFraction:
			result.X = (float)((double)Rect.Left + x * (double)_rect.Width);
			result.Y = (float)((double)rectangleF.Top + y * (double)rectangleF.Height);
			break;
		default:
			result.X = (float)((double)_rect.Left + x * (double)_rect.Width);
			result.Y = (float)((double)_rect.Top + y * (double)_rect.Height);
			break;
		}
		return result;
	}
}
