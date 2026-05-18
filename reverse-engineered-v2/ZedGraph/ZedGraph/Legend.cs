using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class Legend : ICloneable, ISerializable
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public struct Default
	{
		public static float BorderWidth = 1f;

		public static Color BorderColor = Color.Black;

		public static Color FillColor = Color.White;

		public static Brush FillBrush = null;

		public static FillType FillType = FillType.Brush;

		public static LegendPos Position = LegendPos.Top;

		public static bool IsBorderVisible = true;

		public static bool IsVisible = true;

		public static bool IsFilled = true;

		public static bool IsHStack = true;

		public static string FontFamily = "Arial";

		public static float FontSize = 12f;

		public static Color FontColor = Color.Black;

		public static bool FontBold = false;

		public static bool FontItalic = false;

		public static bool FontUnderline = false;

		public static Color FontFillColor = Color.White;

		public static Brush FontFillBrush = null;

		public static FillType FontFillType = FillType.None;

		public static float Gap = 0.5f;

		public static bool IsReverse = false;

		public static bool IsShowLegendSymbols = true;
	}

	public const int schema = 12;

	private RectangleF _rect;

	private LegendPos _position;

	private bool _isHStack;

	private bool _isVisible;

	private Fill _fill;

	private Border _border;

	private FontSpec _fontSpec;

	private Location _location;

	private int _hStack;

	private float _legendItemWidth;

	private float _legendItemHeight;

	private float _gap;

	private bool _isReverse;

	private float _tmpSize;

	private bool _isShowLegendSymbols;

	public RectangleF Rect => _rect;

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
				throw new ArgumentNullException("Uninitialized FontSpec in Legend");
			}
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

	public bool IsHStack
	{
		get
		{
			return _isHStack;
		}
		set
		{
			_isHStack = value;
		}
	}

	public LegendPos Position
	{
		get
		{
			return _position;
		}
		set
		{
			_position = value;
		}
	}

	public Location Location
	{
		get
		{
			return _location;
		}
		set
		{
			_location = value;
		}
	}

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

	public bool IsReverse
	{
		get
		{
			return _isReverse;
		}
		set
		{
			_isReverse = value;
		}
	}

	public bool IsShowLegendSymbols
	{
		get
		{
			return _isShowLegendSymbols;
		}
		set
		{
			_isShowLegendSymbols = value;
		}
	}

	public Legend()
	{
		_position = Default.Position;
		_isHStack = Default.IsHStack;
		_isVisible = Default.IsVisible;
		Location = new Location(0.0, 0.0, CoordType.PaneFraction);
		_fontSpec = new FontSpec(Default.FontFamily, Default.FontSize, Default.FontColor, Default.FontBold, Default.FontItalic, Default.FontUnderline, Default.FontFillColor, Default.FontFillBrush, Default.FontFillType);
		_fontSpec.Border.IsVisible = false;
		_border = new Border(Default.IsBorderVisible, Default.BorderColor, Default.BorderWidth);
		_fill = new Fill(Default.FillColor, Default.FillBrush, Default.FillType);
		_gap = Default.Gap;
		_isReverse = Default.IsReverse;
		_isShowLegendSymbols = Default.IsShowLegendSymbols;
	}

	public Legend(Legend rhs)
	{
		_rect = rhs.Rect;
		_position = rhs.Position;
		_isHStack = rhs.IsHStack;
		_isVisible = rhs.IsVisible;
		_location = rhs.Location;
		_border = rhs.Border.Clone();
		_fill = rhs.Fill.Clone();
		_fontSpec = rhs.FontSpec.Clone();
		_gap = rhs._gap;
		_isReverse = rhs._isReverse;
		_isShowLegendSymbols = rhs._isShowLegendSymbols;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public Legend Clone()
	{
		return new Legend(this);
	}

	protected Legend(SerializationInfo info, StreamingContext context)
	{
		info.GetInt32("schema");
		_position = (LegendPos)info.GetValue("position", typeof(LegendPos));
		_isHStack = info.GetBoolean("isHStack");
		_isVisible = info.GetBoolean("isVisible");
		_fill = (Fill)info.GetValue("fill", typeof(Fill));
		_border = (Border)info.GetValue("border", typeof(Border));
		_fontSpec = (FontSpec)info.GetValue("fontSpec", typeof(FontSpec));
		_location = (Location)info.GetValue("location", typeof(Location));
		_gap = info.GetSingle("gap");
		_isReverse = info.GetBoolean("isReverse");
		_isShowLegendSymbols = info.GetBoolean("isShowLegendSymbols");
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		info.AddValue("schema", 12);
		info.AddValue("position", _position);
		info.AddValue("isHStack", _isHStack);
		info.AddValue("isVisible", _isVisible);
		info.AddValue("fill", _fill);
		info.AddValue("border", _border);
		info.AddValue("fontSpec", _fontSpec);
		info.AddValue("location", _location);
		info.AddValue("gap", _gap);
		info.AddValue("isReverse", _isReverse);
		info.AddValue("isShowLegendSymbols", _isShowLegendSymbols);
	}

	public void Draw(Graphics g, PaneBase pane, float scaleFactor)
	{
		if (!_isVisible)
		{
			return;
		}
		_fill.Draw(g, _rect);
		PaneList paneList = GetPaneList(pane);
		float num = _tmpSize / 2f;
		if (_hStack <= 0)
		{
			_hStack = 1;
		}
		if (_legendItemWidth <= 0f)
		{
			_legendItemWidth = 100f;
		}
		if (_legendItemHeight <= 0f)
		{
			_legendItemHeight = _tmpSize;
		}
		int num2 = 0;
		using (new SolidBrush(Color.Black))
		{
			foreach (GraphPane item in paneList)
			{
				int count = item.CurveList.Count;
				for (int i = 0; i < count; i++)
				{
					CurveItem curveItem = item.CurveList[_isReverse ? (count - i - 1) : i];
					if (!(curveItem._label._text != "") || !curveItem._label._isVisible)
					{
						continue;
					}
					float num3 = _rect.Left + num / 2f + (float)(num2 % _hStack) * _legendItemWidth;
					float num4 = _rect.Top + (float)(num2 / _hStack) * _legendItemHeight;
					FontSpec fontSpec = ((curveItem._label._fontSpec != null) ? curveItem._label._fontSpec : FontSpec);
					fontSpec.StringAlignment = StringAlignment.Near;
					if (_isShowLegendSymbols)
					{
						fontSpec.Draw(g, pane, curveItem._label._text, num3 + 2.5f * _tmpSize, num4 + _legendItemHeight / 2f, AlignH.Left, AlignV.Center, scaleFactor);
						RectangleF rect = new RectangleF(num3, num4 + _legendItemHeight / 4f, 2f * _tmpSize, _legendItemHeight / 2f);
						curveItem.DrawLegendKey(g, item, rect, scaleFactor);
					}
					else
					{
						if (curveItem._label._fontSpec == null)
						{
							fontSpec.FontColor = curveItem.Color;
						}
						fontSpec.Draw(g, pane, curveItem._label._text, num3 + 0f * _tmpSize, num4 + _legendItemHeight / 2f, AlignH.Left, AlignV.Center, scaleFactor);
					}
					num2++;
				}
				if (pane is MasterPane && ((MasterPane)pane).IsUniformLegendEntries)
				{
					break;
				}
			}
			if (num2 > 0)
			{
				Border.Draw(g, pane, scaleFactor, _rect);
			}
		}
	}

	private float GetMaxHeight(PaneList paneList, Graphics g, float scaleFactor)
	{
		float height = FontSpec.GetHeight(scaleFactor);
		float num = height;
		foreach (GraphPane pane in paneList)
		{
			foreach (CurveItem curve in pane.CurveList)
			{
				if (curve._label._text != string.Empty && curve._label._isVisible)
				{
					float num2 = height;
					if (curve._label._fontSpec != null)
					{
						num2 = curve._label._fontSpec.GetHeight(scaleFactor);
					}
					num2 *= (float)curve._label._text.Split('\n').Length;
					if (num2 > num)
					{
						num = num2;
					}
				}
			}
		}
		return num;
	}

	public bool FindPoint(PointF mousePt, PaneBase pane, float scaleFactor, out int index)
	{
		index = -1;
		if (_rect.Contains(mousePt))
		{
			int num = (int)((mousePt.Y - _rect.Top) / _legendItemHeight);
			int num2 = (int)((mousePt.X - _rect.Left - _tmpSize / 2f) / _legendItemWidth);
			if (num2 < 0)
			{
				num2 = 0;
			}
			if (num2 >= _hStack)
			{
				num2 = _hStack - 1;
			}
			int num3 = num2 + num * _hStack;
			index = 0;
			PaneList paneList = GetPaneList(pane);
			foreach (GraphPane item in paneList)
			{
				foreach (CurveItem curve in item.CurveList)
				{
					if (curve._label._isVisible && curve._label._text != string.Empty)
					{
						if (num3 == 0)
						{
							return true;
						}
						num3--;
					}
					index++;
				}
			}
			return true;
		}
		return false;
	}

	private PaneList GetPaneList(PaneBase pane)
	{
		PaneList paneList;
		if (pane is GraphPane)
		{
			paneList = new PaneList();
			paneList.Add((GraphPane)pane);
		}
		else
		{
			paneList = ((MasterPane)pane).PaneList;
		}
		return paneList;
	}

	public void CalcRect(Graphics g, PaneBase pane, float scaleFactor, ref RectangleF tChartRect)
	{
		_rect = Rectangle.Empty;
		_hStack = 1;
		_legendItemWidth = 1f;
		_legendItemHeight = 0f;
		RectangleF rectangleF = pane.CalcClientRect(g, scaleFactor);
		if (!_isVisible)
		{
			return;
		}
		int num = 0;
		PaneList paneList = GetPaneList(pane);
		_tmpSize = GetMaxHeight(paneList, g, scaleFactor);
		float num2 = _tmpSize / 2f;
		float num3 = 0f;
		float num4 = _gap * _tmpSize;
		foreach (GraphPane item in paneList)
		{
			int count = item.CurveList.Count;
			for (int i = 0; i < count; i++)
			{
				CurveItem curveItem = item.CurveList[_isReverse ? (count - i - 1) : i];
				if (curveItem._label._text != string.Empty && curveItem._label._isVisible)
				{
					FontSpec fontSpec = ((curveItem._label._fontSpec != null) ? curveItem._label._fontSpec : FontSpec);
					float width = fontSpec.GetWidth(g, curveItem._label._text, scaleFactor);
					if (width > num3)
					{
						num3 = width;
					}
					if (curveItem is LineItem && ((LineItem)curveItem).Symbol.Size > _legendItemHeight)
					{
						_legendItemHeight = ((LineItem)curveItem).Symbol.Size;
					}
					num++;
				}
			}
			if (pane is MasterPane && ((MasterPane)pane).IsUniformLegendEntries)
			{
				break;
			}
		}
		if (_isHStack)
		{
			float num5;
			switch (_position)
			{
			case LegendPos.Left:
			case LegendPos.Right:
				num5 = 0f;
				break;
			case LegendPos.Top:
			case LegendPos.Bottom:
			case LegendPos.TopCenter:
			case LegendPos.BottomCenter:
				num5 = tChartRect.Width;
				break;
			case LegendPos.TopFlushLeft:
			case LegendPos.BottomFlushLeft:
				num5 = rectangleF.Width;
				break;
			case LegendPos.InsideTopLeft:
			case LegendPos.InsideTopRight:
			case LegendPos.InsideBotLeft:
			case LegendPos.InsideBotRight:
			case LegendPos.Float:
				num5 = tChartRect.Width / 2f;
				break;
			default:
				num5 = 0f;
				break;
			}
			if (_isShowLegendSymbols)
			{
				_legendItemWidth = 3f * _tmpSize + num3;
			}
			else
			{
				_legendItemWidth = 0.5f * _tmpSize + num3;
			}
			if (num3 > 0f)
			{
				_hStack = (int)((num5 - num2) / _legendItemWidth);
			}
			if (_hStack > num)
			{
				_hStack = num;
			}
			if (_hStack == 0)
			{
				_hStack = 1;
			}
		}
		else if (_isShowLegendSymbols)
		{
			_legendItemWidth = 3f * _tmpSize + num3;
		}
		else
		{
			_legendItemWidth = 0.5f * _tmpSize + num3;
		}
		float num6 = (float)_hStack * _legendItemWidth;
		_legendItemHeight = _legendItemHeight * scaleFactor + num2;
		if (_tmpSize > _legendItemHeight)
		{
			_legendItemHeight = _tmpSize;
		}
		float num7 = (float)Math.Ceiling((double)num / (double)_hStack) * _legendItemHeight;
		RectangleF rect = default(RectangleF);
		if (num > 0)
		{
			rect = new RectangleF(0f, 0f, num6, num7);
			switch (_position)
			{
			case LegendPos.Right:
				rect.X = rectangleF.Right - num6;
				rect.Y = tChartRect.Top;
				tChartRect.Width -= num6 + num4;
				break;
			case LegendPos.Top:
				rect.X = tChartRect.Left;
				rect.Y = rectangleF.Top;
				tChartRect.Y += num7 + num4;
				tChartRect.Height -= num7 + num4;
				break;
			case LegendPos.TopFlushLeft:
				rect.X = rectangleF.Left;
				rect.Y = rectangleF.Top;
				tChartRect.Y += num7 + num4 * 1.5f;
				tChartRect.Height -= num7 + num4 * 1.5f;
				break;
			case LegendPos.TopCenter:
				rect.X = tChartRect.Left + (tChartRect.Width - num6) / 2f;
				rect.Y = tChartRect.Top;
				tChartRect.Y += num7 + num4;
				tChartRect.Height -= num7 + num4;
				break;
			case LegendPos.Bottom:
				rect.X = tChartRect.Left;
				rect.Y = rectangleF.Bottom - num7;
				tChartRect.Height -= num7 + num4;
				break;
			case LegendPos.BottomFlushLeft:
				rect.X = rectangleF.Left;
				rect.Y = rectangleF.Bottom - num7;
				tChartRect.Height -= num7 + num4;
				break;
			case LegendPos.BottomCenter:
				rect.X = tChartRect.Left + (tChartRect.Width - num6) / 2f;
				rect.Y = rectangleF.Bottom - num7;
				tChartRect.Height -= num7 + num4;
				break;
			case LegendPos.Left:
				rect.X = rectangleF.Left;
				rect.Y = tChartRect.Top;
				tChartRect.X += num6 + num2;
				tChartRect.Width -= num6 + num4;
				break;
			case LegendPos.InsideTopRight:
				rect.X = tChartRect.Right - num6;
				rect.Y = tChartRect.Top;
				break;
			case LegendPos.InsideTopLeft:
				rect.X = tChartRect.Left;
				rect.Y = tChartRect.Top;
				break;
			case LegendPos.InsideBotRight:
				rect.X = tChartRect.Right - num6;
				rect.Y = tChartRect.Bottom - num7;
				break;
			case LegendPos.InsideBotLeft:
				rect.X = tChartRect.Left;
				rect.Y = tChartRect.Bottom - num7;
				break;
			case LegendPos.Float:
				rect.Location = Location.TransformTopLeft(pane, num6, num7);
				break;
			}
		}
		_rect = rect;
	}
}
