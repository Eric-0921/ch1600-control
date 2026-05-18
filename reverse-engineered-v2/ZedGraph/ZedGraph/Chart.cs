using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Chart : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static Color BorderColor = Color.Black;

		public static Color FillColor = Color.White;

		public static Brush FillBrush = null;

		public static FillType FillType = FillType.Brush;

		public static float BorderPenWidth = 1f;

		public static bool IsBorderVisible = true;
	}

	public const int schema = 10;

	internal RectangleF _rect;

	internal Fill _fill;

	internal Border _border;

	internal bool _isRectAuto;

	public RectangleF Rect
	{
		get
		{
			return _rect;
		}
		set
		{
			_rect = value;
			_isRectAuto = false;
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

	public bool IsRectAuto
	{
		get
		{
			return _isRectAuto;
		}
		set
		{
			_isRectAuto = value;
		}
	}

	public Chart()
	{
		_isRectAuto = true;
		_border = new Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderPenWidth);
		_fill = new Fill(Default.FillColor, Default.FillBrush, Default.FillType);
	}

	public Chart(Chart rhs)
	{
		_border = rhs._border.Clone();
		_fill = rhs._fill.Clone();
		_rect = rhs._rect;
		_isRectAuto = rhs._isRectAuto;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Chart Clone()
	{
		return new Chart(this);
	}

	protected Chart(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_rect = (RectangleF)info.GetValue("rect", typeof(RectangleF));
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_isRectAuto = info.GetBoolean("isRectAuto");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 10);
		info.AddValue("rect", _rect);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("isRectAuto", _isRectAuto);
	}
}
