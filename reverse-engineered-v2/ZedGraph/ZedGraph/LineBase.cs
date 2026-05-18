using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class LineBase : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static bool IsVisible = true;

		public static float Width = 1f;

		public static bool IsAntiAlias = false;

		public static DashStyle Style = DashStyle.Solid;

		public static float DashOn = 1f;

		public static float DashOff = 1f;

		public static Color Color = Color.Black;
	}

	public const int schema0 = 12;

	internal float _width;

	internal DashStyle _style;

	internal float _dashOn;

	internal float _dashOff;

	internal bool _isVisible;

	internal bool _isAntiAlias;

	internal Color _color;

	internal Fill _gradientFill;

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

	public DashStyle Style
	{
		get
		{
			return _style;
		}
		set
		{
			_style = value;
		}
	}

	public float DashOn
	{
		get
		{
			return _dashOn;
		}
		set
		{
			_dashOn = value;
		}
	}

	public float DashOff
	{
		get
		{
			return _dashOff;
		}
		set
		{
			_dashOff = value;
		}
	}

	public float Width
	{
		get
		{
			return _width;
		}
		set
		{
			_width = value;
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

	public Fill GradientFill
	{
		get
		{
			return _gradientFill;
		}
		set
		{
			_gradientFill = value;
		}
	}

	public LineBase()
		: this(Color.Empty)
	{
	}

	public LineBase(Color color)
	{
		_width = Default.Width;
		_style = Default.Style;
		_dashOn = Default.DashOn;
		_dashOff = Default.DashOff;
		_isVisible = Default.IsVisible;
		_color = (color.IsEmpty ? Default.Color : color);
		_isAntiAlias = Default.IsAntiAlias;
		_gradientFill = new Fill(Color.Red, Color.White);
		_gradientFill.Type = FillType.None;
	}

	public LineBase(LineBase rhs)
	{
		_width = rhs._width;
		_style = rhs._style;
		_dashOn = rhs._dashOn;
		_dashOff = rhs._dashOff;
		_isVisible = rhs._isVisible;
		_color = rhs._color;
		_isAntiAlias = rhs._isAntiAlias;
		_gradientFill = new Fill(rhs._gradientFill);
	}

	object ICloneable.Clone()
	{
		throw new NotImplementedException("Can't clone an abstract base type -- child types must implement ICloneable");
	}

	protected LineBase(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema0");
		_width = info.GetSingle("width");
		_style = (DashStyle)info.GetValue("style", typeof(DashStyle));
		_dashOn = info.GetSingle("dashOn");
		_dashOff = info.GetSingle("dashOff");
		_isVisible = info.GetBoolean("isVisible");
		_isAntiAlias = info.GetBoolean("isAntiAlias");
		_color = (Color)info.GetValue("color", typeof(Color));
		_gradientFill = (Fill)info.GetValue("gradientFill", typeof(Fill));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema0", 12);
		info.AddValue("width", _width);
		info.AddValue("style", _style);
		info.AddValue("dashOn", _dashOn);
		info.AddValue("dashOff", _dashOff);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("isAntiAlias", _isAntiAlias);
		info.AddValue("color", _color);
		info.AddValue("gradientFill", _gradientFill);
	}

	public Pen GetPen(PaneBase pane, float scaleFactor)
	{
		return GetPen(pane, scaleFactor, null);
	}

	public Pen GetPen(PaneBase pane, float scaleFactor, PointPair dataValue)
	{
		Color color = _color;
		if (_gradientFill.IsGradientValueType)
		{
			color = _gradientFill.GetGradientColor(dataValue);
		}
		Pen pen = new Pen(color, pane.ScaledPenWidth(_width, scaleFactor));
		pen.DashStyle = _style;
		if (_style == DashStyle.Custom)
		{
			if ((double)_dashOff > 1E-10 && (double)_dashOn > 1E-10)
			{
				pen.DashStyle = DashStyle.Custom;
				pen.DashPattern = new float[2] { _dashOn, _dashOff };
			}
			else
			{
				pen.DashStyle = DashStyle.Solid;
			}
		}
		return pen;
	}
}
