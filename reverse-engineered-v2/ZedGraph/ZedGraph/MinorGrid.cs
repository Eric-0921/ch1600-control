using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class MinorGrid : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float DashOn = 1f;

		public static float DashOff = 10f;

		public static float PenWidth = 1f;

		public static Color Color = Color.Gray;

		public static bool IsVisible = false;
	}

	public const int schema = 10;

	internal bool _isVisible;

	internal float _dashOn;

	internal float _dashOff;

	internal float _penWidth;

	internal Color _color;

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

	public float PenWidth
	{
		get
		{
			return _penWidth;
		}
		set
		{
			_penWidth = value;
		}
	}

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

	public MinorGrid()
	{
		_dashOn = Default.DashOn;
		_dashOff = Default.DashOff;
		_penWidth = Default.PenWidth;
		_isVisible = Default.IsVisible;
		_color = Default.Color;
	}

	public MinorGrid(MinorGrid rhs)
	{
		_dashOn = rhs._dashOn;
		_dashOff = rhs._dashOff;
		_penWidth = rhs._penWidth;
		_isVisible = rhs._isVisible;
		_color = rhs._color;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public MinorGrid Clone()
	{
		return new MinorGrid(this);
	}

	protected MinorGrid(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_isVisible = info.GetBoolean("isVisible");
		_dashOn = info.GetSingle("dashOn");
		_dashOff = info.GetSingle("dashOff");
		_penWidth = info.GetSingle("penWidth");
		_color = (Color)info.GetValue("color", typeof(Color));
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("dashOn", _dashOn);
		info.AddValue("dashOff", _dashOff);
		info.AddValue("penWidth", _penWidth);
		info.AddValue("color", _color);
	}

	internal void Draw(Graphics g, Pen pen, float pixVal, float topPix)
	{
		if (_isVisible)
		{
			g.DrawLine(pen, pixVal, 0f, pixVal, topPix);
		}
	}

	internal Pen GetPen(GraphPane pane, float scaleFactor)
	{
		Pen pen = new Pen(_color, pane.ScaledPenWidth(_penWidth, scaleFactor));
		if ((double)_dashOff > 1E-10 && (double)_dashOn > 1E-10)
		{
			pen.DashStyle = DashStyle.Custom;
			pen.DashPattern = new float[2] { _dashOn, _dashOff };
		}
		return pen;
	}
}
