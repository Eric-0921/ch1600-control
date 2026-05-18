using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace ZedGraph;

[Serializable]
public class MasterPane : PaneBase, ICloneable, ISerializable, IDeserializationCallback
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	public new struct Default
	{
		public static PaneLayout PaneLayout = PaneLayout.SquareColPreferred;

		public static float InnerPaneGap = 10f;

		public static bool IsShowLegend = false;

		public static bool IsUniformLegendEntries = false;

		public static bool IsCommonScaleFactor = false;
	}

	public const int schema2 = 11;

	internal PaneList _paneList;

	internal float _innerPaneGap;

	private bool _isUniformLegendEntries;

	private bool _isCommonScaleFactor;

	internal PaneLayout _paneLayout;

	internal bool _isColumnSpecified;

	internal int[] _countList;

	internal float[] _prop;

	private bool _isAntiAlias;

	public PaneList PaneList
	{
		get
		{
			return _paneList;
		}
		set
		{
			_paneList = value;
		}
	}

	public float InnerPaneGap
	{
		get
		{
			return _innerPaneGap;
		}
		set
		{
			_innerPaneGap = value;
		}
	}

	public bool IsUniformLegendEntries
	{
		get
		{
			return _isUniformLegendEntries;
		}
		set
		{
			_isUniformLegendEntries = value;
		}
	}

	public bool IsCommonScaleFactor
	{
		get
		{
			return _isCommonScaleFactor;
		}
		set
		{
			_isCommonScaleFactor = value;
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

	public GraphPane this[int index]
	{
		get
		{
			return _paneList[index];
		}
		set
		{
			_paneList[index] = value;
		}
	}

	public GraphPane this[string title] => _paneList[title];

	public MasterPane()
		: this("", new RectangleF(0f, 0f, 500f, 375f))
	{
	}

	public MasterPane(string title, RectangleF paneRect)
		: base(title, paneRect)
	{
		_innerPaneGap = Default.InnerPaneGap;
		_isUniformLegendEntries = Default.IsUniformLegendEntries;
		_isCommonScaleFactor = Default.IsCommonScaleFactor;
		_paneList = new PaneList();
		_legend.IsVisible = Default.IsShowLegend;
		_isAntiAlias = false;
		InitLayout();
	}

	private void InitLayout()
	{
		_paneLayout = Default.PaneLayout;
		_countList = null;
		_isColumnSpecified = false;
		_prop = null;
	}

	public MasterPane(MasterPane rhs)
		: base(rhs)
	{
		_innerPaneGap = rhs._innerPaneGap;
		_isUniformLegendEntries = rhs._isUniformLegendEntries;
		_isCommonScaleFactor = rhs._isCommonScaleFactor;
		_paneList = rhs._paneList.Clone();
		_paneLayout = rhs._paneLayout;
		_countList = rhs._countList;
		_isColumnSpecified = rhs._isColumnSpecified;
		_prop = rhs._prop;
		_isAntiAlias = rhs._isAntiAlias;
	}

	object ICloneable.Clone()
	{
		return Clone();
	}

	public MasterPane Clone()
	{
		return new MasterPane(this);
	}

	protected MasterPane(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
		int @int = info.GetInt32("schema2");
		_paneList = (PaneList)info.GetValue("paneList", typeof(PaneList));
		_innerPaneGap = info.GetSingle("innerPaneGap");
		_isUniformLegendEntries = info.GetBoolean("isUniformLegendEntries");
		_isCommonScaleFactor = info.GetBoolean("isCommonScaleFactor");
		_paneLayout = (PaneLayout)info.GetValue("paneLayout", typeof(PaneLayout));
		_countList = (int[])info.GetValue("countList", typeof(int[]));
		_isColumnSpecified = info.GetBoolean("isColumnSpecified");
		_prop = (float[])info.GetValue("prop", typeof(float[]));
		if (@int >= 11)
		{
			_isAntiAlias = info.GetBoolean("isAntiAlias");
		}
	}

	[SecurityPermission(SecurityAction.Demand, SerializationFormatter = true)]
	public override void GetObjectData(SerializationInfo info, StreamingContext context)
	{
		base.GetObjectData(info, context);
		info.AddValue("schema2", 11);
		info.AddValue("paneList", _paneList);
		info.AddValue("innerPaneGap", _innerPaneGap);
		info.AddValue("isUniformLegendEntries", _isUniformLegendEntries);
		info.AddValue("isCommonScaleFactor", _isCommonScaleFactor);
		info.AddValue("paneLayout", _paneLayout);
		info.AddValue("countList", _countList);
		info.AddValue("isColumnSpecified", _isColumnSpecified);
		info.AddValue("prop", _prop);
		info.AddValue("isAntiAlias", _isAntiAlias);
	}

	public void OnDeserialization(object sender)
	{
		Bitmap image = new Bitmap(10, 10);
		Graphics g = Graphics.FromImage(image);
		ReSize(g, _rect);
	}

	public void Add(GraphPane pane)
	{
		_paneList.Add(pane);
	}

	public void AxisChange()
	{
		using Graphics g = Graphics.FromHwnd(IntPtr.Zero);
		AxisChange(g);
	}

	public void AxisChange(Graphics g)
	{
		foreach (GraphPane pane in _paneList)
		{
			pane.AxisChange(g);
		}
	}

	public void ReSize(Graphics g)
	{
		ReSize(g, _rect);
	}

	public override void ReSize(Graphics g, RectangleF rect)
	{
		_rect = rect;
		DoLayout(g);
		CommonScaleFactor();
	}

	public void CommonScaleFactor()
	{
		if (!_isCommonScaleFactor)
		{
			return;
		}
		float num = 0f;
		foreach (GraphPane pane in PaneList)
		{
			pane.BaseDimension = PaneBase.Default.BaseDimension;
			float num2 = pane.CalcScaleFactor();
			num = ((num2 > num) ? num2 : num);
		}
		foreach (GraphPane pane2 in PaneList)
		{
			float num3 = pane2.CalcScaleFactor();
			pane2.BaseDimension *= num3 / num;
		}
	}

	public override void Draw(Graphics g)
	{
		SmoothingMode smoothingMode = g.SmoothingMode;
		TextRenderingHint textRenderingHint = g.TextRenderingHint;
		CompositingQuality compositingQuality = g.CompositingQuality;
		InterpolationMode interpolationMode = g.InterpolationMode;
		SetAntiAliasMode(g, _isAntiAlias);
		base.Draw(g);
		if (_rect.Width <= 1f || _rect.Height <= 1f)
		{
			return;
		}
		float scaleFactor = CalcScaleFactor();
		g.SetClip(_rect);
		_graphObjList.Draw(g, this, scaleFactor, ZOrder.G_BehindChartFill);
		_graphObjList.Draw(g, this, scaleFactor, ZOrder.E_BehindCurves);
		_graphObjList.Draw(g, this, scaleFactor, ZOrder.D_BehindAxis);
		_graphObjList.Draw(g, this, scaleFactor, ZOrder.C_BehindChartBorder);
		g.ResetClip();
		foreach (GraphPane pane in _paneList)
		{
			pane.Draw(g);
		}
		g.SetClip(_rect);
		_graphObjList.Draw(g, this, scaleFactor, ZOrder.B_BehindLegend);
		RectangleF tChartRect = CalcClientRect(g, scaleFactor);
		_legend.CalcRect(g, this, scaleFactor, ref tChartRect);
		_legend.Draw(g, this, scaleFactor);
		_graphObjList.Draw(g, this, scaleFactor, ZOrder.A_InFront);
		g.ResetClip();
		g.SmoothingMode = smoothingMode;
		g.TextRenderingHint = textRenderingHint;
		g.CompositingQuality = compositingQuality;
		g.InterpolationMode = interpolationMode;
	}

	public bool FindNearestPaneObject(PointF mousePt, Graphics g, out GraphPane pane, out object nearestObj, out int index)
	{
		pane = null;
		nearestObj = null;
		index = -1;
		GraphObj graphObj = null;
		int num = -1;
		float scaleFactor = CalcScaleFactor();
		if (base.GraphObjList.FindPoint(mousePt, this, g, scaleFactor, out index))
		{
			graphObj = base.GraphObjList[index];
			num = index;
			if (graphObj.ZOrder == ZOrder.A_InFront)
			{
				nearestObj = graphObj;
				index = num;
				return true;
			}
		}
		foreach (GraphPane pane2 in _paneList)
		{
			if (pane2.Rect.Contains(mousePt))
			{
				pane = pane2;
				return pane2.FindNearestObject(mousePt, g, out nearestObj, out index);
			}
		}
		if (graphObj != null)
		{
			nearestObj = graphObj;
			index = num;
			return true;
		}
		return false;
	}

	public GraphPane FindPane(PointF mousePt)
	{
		foreach (GraphPane pane in _paneList)
		{
			if (pane.Rect.Contains(mousePt))
			{
				return pane;
			}
		}
		return null;
	}

	public GraphPane FindChartRect(PointF mousePt)
	{
		foreach (GraphPane pane in _paneList)
		{
			if (pane.Chart._rect.Contains(mousePt))
			{
				return pane;
			}
		}
		return null;
	}

	public void SetLayout(Graphics g, PaneLayout paneLayout)
	{
		InitLayout();
		_paneLayout = paneLayout;
		DoLayout(g);
	}

	public void SetLayout(Graphics g, int rows, int columns)
	{
		InitLayout();
		if (rows < 1)
		{
			rows = 1;
		}
		if (columns < 1)
		{
			columns = 1;
		}
		int[] array = new int[rows];
		for (int i = 0; i < rows; i++)
		{
			array[i] = columns;
		}
		SetLayout(g, isColumnSpecified: true, array, null);
	}

	public void SetLayout(Graphics g, bool isColumnSpecified, int[] countList)
	{
		SetLayout(g, isColumnSpecified, countList, null);
	}

	public void SetLayout(Graphics g, bool isColumnSpecified, int[] countList, float[] proportion)
	{
		InitLayout();
		if (countList != null && countList.Length > 0)
		{
			_prop = new float[countList.Length];
			float num = 0f;
			for (int i = 0; i < countList.Length; i++)
			{
				_prop[i] = ((proportion == null || proportion.Length <= i || (double)proportion[i] < 1E-10) ? 1f : proportion[i]);
				num += _prop[i];
			}
			for (int j = 0; j < countList.Length; j++)
			{
				_prop[j] /= num;
			}
			_isColumnSpecified = isColumnSpecified;
			_countList = countList;
			DoLayout(g);
		}
	}

	public void DoLayout(Graphics g)
	{
		if (_countList != null)
		{
			DoLayout(g, _isColumnSpecified, _countList, _prop);
			return;
		}
		int count = _paneList.Count;
		if (count == 0)
		{
			return;
		}
		int num = (int)(Math.Sqrt(count) + 0.9999999);
		switch (_paneLayout)
		{
		case PaneLayout.ForceSquare:
		{
			int rows = num;
			int num2 = num;
			DoLayout(g, rows, num2);
			break;
		}
		case PaneLayout.SingleColumn:
		{
			int rows = count;
			int num2 = 1;
			DoLayout(g, rows, num2);
			break;
		}
		case PaneLayout.SingleRow:
		{
			int rows = 1;
			int num2 = count;
			DoLayout(g, rows, num2);
			break;
		}
		default:
		{
			int rows = num;
			int num2 = num;
			if (count <= num * (num - 1))
			{
				rows--;
			}
			DoLayout(g, rows, num2);
			break;
		}
		case PaneLayout.SquareRowPreferred:
		{
			int rows = num;
			int num2 = num;
			if (count <= num * (num - 1))
			{
				num2--;
			}
			DoLayout(g, rows, num2);
			break;
		}
		case PaneLayout.ExplicitCol12:
			DoLayout(g, isColumnSpecified: true, new int[2] { 1, 2 }, null);
			break;
		case PaneLayout.ExplicitCol21:
			DoLayout(g, isColumnSpecified: true, new int[2] { 2, 1 }, null);
			break;
		case PaneLayout.ExplicitCol23:
			DoLayout(g, isColumnSpecified: true, new int[2] { 2, 3 }, null);
			break;
		case PaneLayout.ExplicitCol32:
			DoLayout(g, isColumnSpecified: true, new int[2] { 3, 2 }, null);
			break;
		case PaneLayout.ExplicitRow12:
			DoLayout(g, isColumnSpecified: false, new int[2] { 1, 2 }, null);
			break;
		case PaneLayout.ExplicitRow21:
			DoLayout(g, isColumnSpecified: false, new int[2] { 2, 1 }, null);
			break;
		case PaneLayout.ExplicitRow23:
			DoLayout(g, isColumnSpecified: false, new int[2] { 2, 3 }, null);
			break;
		case PaneLayout.ExplicitRow32:
			DoLayout(g, isColumnSpecified: false, new int[2] { 3, 2 }, null);
			break;
		}
	}

	internal void DoLayout(Graphics g, int rows, int columns)
	{
		if (rows < 1)
		{
			rows = 1;
		}
		if (columns < 1)
		{
			columns = 1;
		}
		int[] array = new int[rows];
		for (int i = 0; i < rows; i++)
		{
			array[i] = columns;
		}
		DoLayout(g, isColumnSpecified: true, array, null);
	}

	internal void DoLayout(Graphics g, bool isColumnSpecified, int[] countList, float[] proportion)
	{
		float num = CalcScaleFactor();
		RectangleF tChartRect = CalcClientRect(g, num);
		_legend.CalcRect(g, this, num, ref tChartRect);
		float num2 = _innerPaneGap * num;
		int num3 = 0;
		if (isColumnSpecified)
		{
			int num4 = countList.Length;
			float num5 = 0f;
			for (int i = 0; i < num4; i++)
			{
				float num6 = ((_prop == null) ? (1f / (float)num4) : _prop[i]);
				float num7 = (tChartRect.Height - (float)(num4 - 1) * num2) * num6;
				int num8 = countList[i];
				if (num8 <= 0)
				{
					num8 = 1;
				}
				float num9 = (tChartRect.Width - (float)(num8 - 1) * num2) / (float)num8;
				for (int j = 0; j < num8; j++)
				{
					if (num3 >= _paneList.Count)
					{
						return;
					}
					this[num3].Rect = new RectangleF(tChartRect.X + (float)j * (num9 + num2), tChartRect.Y + num5, num9, num7);
					num3++;
				}
				num5 += num7 + num2;
			}
			return;
		}
		int num10 = countList.Length;
		float num11 = 0f;
		for (int k = 0; k < num10; k++)
		{
			float num12 = ((_prop == null) ? (1f / (float)num10) : _prop[k]);
			float num13 = (tChartRect.Width - (float)(num10 - 1) * num2) * num12;
			int num14 = countList[k];
			if (num14 <= 0)
			{
				num14 = 1;
			}
			float num15 = (tChartRect.Height - (float)(num14 - 1) * num2) / (float)num14;
			for (int l = 0; l < num14; l++)
			{
				if (num3 >= _paneList.Count)
				{
					return;
				}
				this[num3].Rect = new RectangleF(tChartRect.X + num11, tChartRect.Y + (float)l * (num15 + num2), num13, num15);
				num3++;
			}
			num11 += num13 + num2;
		}
	}
}
