using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class ImageObj : GraphObj, ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static bool IsScaled = true;
	}

	public const int schema2 = 10;

	private Image _image;

	private bool _isScaled;

	public Image Image
	{
		get
		{
			return _image;
		}
		set
		{
			_image = value;
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

	public ImageObj()
		: this(null, 0.0, 0.0, 1.0, 1.0)
	{
	}

	public ImageObj(Image image, RectangleF rect)
		: this(image, rect.X, rect.Y, rect.Width, rect.Height)
	{
	}

	public ImageObj(Image image, RectangleF rect, CoordType coordType, AlignH alignH, AlignV alignV)
		: base(rect.X, rect.Y, rect.Width, rect.Height, coordType, alignH, alignV)
	{
		_image = image;
		_isScaled = Default.IsScaled;
	}

	public ImageObj(Image image, double left, double top, double width, double height)
		: base(left, top, width, height)
	{
		_image = image;
		_isScaled = Default.IsScaled;
	}

	public ImageObj(ImageObj rhs)
		: base(rhs)
	{
		_image = rhs._image;
		_isScaled = rhs.IsScaled;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public ImageObj Clone()
	{
		return new ImageObj(this);
	}

	protected ImageObj(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		info.GetInt32("schema2");
		_image = (Image)info.GetValue("image", typeof(Image));
		_isScaled = info.GetBoolean("isScaled");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 10);
		info.AddValue("image", _image);
		info.AddValue("isScaled", _isScaled);
	}

	public override void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		if (_image != null)
		{
			RectangleF rectangleF = _location.TransformRect(pane);
			if (_isScaled)
			{
				g.DrawImage(_image, rectangleF);
				return;
			}
			Region clip = g.Clip;
			g.SetClip(rectangleF);
			g.DrawImageUnscaled(_image, Rectangle.Round(rectangleF));
			g.SetClip(clip, CombineMode.Replace);
		}
	}

	public override bool PointInBox(PointF pt, PaneBase pane, Graphics g, float scaleFactor)
	{
		if (_image != null)
		{
			if (!base.PointInBox(pt, pane, g, scaleFactor))
			{
				return false;
			}
			return _location.TransformRect(pane).Contains(pt);
		}
		return false;
	}

	public override void GetCoords(PaneBase pane, Graphics g, float scaleFactor, out string shape, out string coords)
	{
		RectangleF rectangleF = _location.TransformRect(pane);
		shape = "rect";
		coords = $"{rectangleF.Left:f0},{rectangleF.Top:f0},{rectangleF.Right:f0},{rectangleF.Bottom:f0}";
	}
}
