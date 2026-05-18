using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace ZedGraph;

public class ZedGraphControl : UserControl
{
	public delegate void ContextMenuBuilderEventHandler(ZedGraphControl sender, ContextMenuStrip menuStrip, Point mousePt, ContextMenuObjectState objState);

	public delegate void ZoomEventHandler(ZedGraphControl sender, ZoomState oldState, ZoomState newState);

	public delegate void ScrollDoneHandler(ZedGraphControl sender, ScrollBar scrollBar, ZoomState oldState, ZoomState newState);

	public delegate void ScrollProgressHandler(ZedGraphControl sender, ScrollBar scrollBar, ZoomState oldState, ZoomState newState);

	public delegate string PointEditHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt);

	public delegate string PointValueHandler(ZedGraphControl sender, GraphPane pane, CurveItem curve, int iPt);

	public delegate bool ZedMouseEventHandler(ZedGraphControl sender, MouseEventArgs e);

	public delegate bool LinkEventHandler(ZedGraphControl sender, GraphPane pane, object source, Link link, int index);

	public enum ContextMenuObjectState
	{
		InactiveSelection,
		ActiveSelection,
		Background
	}

	internal class ClipboardMetafileHelper
	{
		[DllImport("user32.dll")]
		private static extern bool OpenClipboard(IntPtr hWndNewOwner);

		[DllImport("user32.dll")]
		private static extern bool EmptyClipboard();

		[DllImport("user32.dll")]
		private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

		[DllImport("user32.dll")]
		private static extern bool CloseClipboard();

		[DllImport("gdi32.dll")]
		private static extern IntPtr CopyEnhMetaFile(IntPtr hemfSrc, StringBuilder hNULL);

		[DllImport("gdi32.dll")]
		private static extern bool DeleteEnhMetaFile(IntPtr hemf);

		internal static bool SaveEnhMetafileToFile(Metafile mf, string fileName)
		{
			bool result = false;
			IntPtr henhmetafile = mf.GetHenhmetafile();
			if (!henhmetafile.Equals(new IntPtr(0)))
			{
				StringBuilder hNULL = new StringBuilder(fileName);
				CopyEnhMetaFile(henhmetafile, hNULL);
				DeleteEnhMetaFile(henhmetafile);
			}
			return result;
		}

		internal static bool SaveEnhMetafileToFile(Metafile mf)
		{
			bool result = false;
			IntPtr henhmetafile = mf.GetHenhmetafile();
			if (!henhmetafile.Equals(new IntPtr(0)))
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();
				saveFileDialog.Filter = "Extended Metafile (*.emf)|*.emf";
				saveFileDialog.DefaultExt = ".emf";
				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					StringBuilder hNULL = new StringBuilder(saveFileDialog.FileName);
					CopyEnhMetaFile(henhmetafile, hNULL);
				}
				DeleteEnhMetaFile(henhmetafile);
			}
			return result;
		}

		internal static bool PutEnhMetafileOnClipboard(IntPtr hWnd, Metafile mf)
		{
			bool result = false;
			IntPtr henhmetafile = mf.GetHenhmetafile();
			if (!henhmetafile.Equals(new IntPtr(0)))
			{
				IntPtr intPtr = CopyEnhMetaFile(henhmetafile, null);
				if (!intPtr.Equals(new IntPtr(0)) && OpenClipboard(hWnd) && EmptyClipboard())
				{
					result = SetClipboardData(14u, intPtr).Equals(intPtr);
					CloseClipboard();
				}
				DeleteEnhMetaFile(henhmetafile);
			}
			return result;
		}
	}

	private const double ZoomResolution = 1E-300;

	private const int _ScrollControlSpan = int.MaxValue;

	private const int _ScrollSmallRatio = 10;

	private MasterPane _masterPane;

	private bool _isShowPointValues;

	private bool _isShowCursorValues;

	private string _pointValueFormat = "G";

	private bool _isShowContextMenu = true;

	private bool _isShowCopyMessage = true;

	private SaveFileDialog _saveFileDialog = new SaveFileDialog();

	private bool _isPrintScaleAll = true;

	private bool _isPrintKeepAspectRatio = true;

	private bool _isPrintFillPage = true;

	private string _pointDateFormat = "g";

	private bool _isEnableVZoom = true;

	private bool _isEnableHZoom = true;

	private bool _isEnableWheelZoom = true;

	private bool _isEnableVEdit;

	private bool _isEnableHEdit;

	private bool _isEnableHPan = true;

	private bool _isEnableVPan = true;

	private bool _isEnableSelection;

	private double _zoomStepFraction = 0.1;

	private ScrollRange _xScrollRange;

	private ScrollRangeList _yScrollRangeList;

	private ScrollRangeList _y2ScrollRangeList;

	private bool _isShowHScrollBar;

	private bool _isShowVScrollBar;

	private bool _isAutoScrollRange;

	private double _scrollGrace;

	private bool _isSynchronizeXAxes;

	private bool _isSynchronizeYAxes;

	private bool _isZoomOnMouseCenter;

	private ResourceManager _resourceManager;

	private PrintDocument _pdSave;

	private Selection _selection = new Selection();

	private MouseButtons _linkButtons = MouseButtons.Left;

	private Keys _linkModifierKeys = Keys.Alt;

	private MouseButtons _editButtons = MouseButtons.Right;

	private Keys _editModifierKeys = Keys.Alt;

	private MouseButtons _selectButtons = MouseButtons.Left;

	private Keys _selectModifierKeys = Keys.Shift;

	private Keys _selectAppendModifierKeys = Keys.Shift | Keys.Control;

	private MouseButtons _zoomButtons = MouseButtons.Left;

	private Keys _zoomModifierKeys;

	private MouseButtons _zoomButtons2;

	private Keys _zoomModifierKeys2;

	private MouseButtons _panButtons = MouseButtons.Left;

	private Keys _panModifierKeys = Keys.Control;

	private MouseButtons _panButtons2 = MouseButtons.Middle;

	private Keys _panModifierKeys2;

	private bool _isZooming;

	private bool _isPanning;

	private bool _isEditing;

	private bool _isSelecting;

	private GraphPane _dragPane;

	private Point _dragStartPt;

	private Point _dragEndPt;

	private int _dragIndex;

	private CurveItem _dragCurve;

	private PointPair _dragStartPair;

	private ZoomState _zoomState;

	private ZoomStateStack _zoomStateStack;

	internal Point _menuClickPt;

	private IContainer components;

	private VScrollBar vScrollBar1;

	private HScrollBar hScrollBar1;

	private ToolTip pointToolTip;

	private ContextMenuStrip contextMenuStrip1;

	[DefaultValue(MouseButtons.Left)]
	[Description("Determines which mouse button is used as the primary for zooming")]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public MouseButtons ZoomButtons
	{
		get
		{
			return _zoomButtons;
		}
		set
		{
			_zoomButtons = value;
		}
	}

	[DefaultValue(MouseButtons.None)]
	[Description("Determines which mouse button is used as the secondary for zooming")]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public MouseButtons ZoomButtons2
	{
		get
		{
			return _zoomButtons2;
		}
		set
		{
			_zoomButtons2 = value;
		}
	}

	[Category("Display")]
	[Description("Determines which modifier key used as the primary for zooming")]
	[NotifyParentProperty(true)]
	[DefaultValue(Keys.None)]
	[Bindable(true)]
	public Keys ZoomModifierKeys
	{
		get
		{
			return _zoomModifierKeys;
		}
		set
		{
			_zoomModifierKeys = value;
		}
	}

	[Category("Display")]
	[DefaultValue(Keys.None)]
	[Description("Determines which modifier key used as the secondary for zooming")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	public Keys ZoomModifierKeys2
	{
		get
		{
			return _zoomModifierKeys2;
		}
		set
		{
			_zoomModifierKeys2 = value;
		}
	}

	[NotifyParentProperty(true)]
	[DefaultValue(MouseButtons.Left)]
	[Description("Determines which mouse button is used as the primary for panning")]
	[Bindable(true)]
	[Category("Display")]
	public MouseButtons PanButtons
	{
		get
		{
			return _panButtons;
		}
		set
		{
			_panButtons = value;
		}
	}

	[DefaultValue(MouseButtons.Middle)]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Description("Determines which mouse button is used as the secondary for panning")]
	[Category("Display")]
	public MouseButtons PanButtons2
	{
		get
		{
			return _panButtons2;
		}
		set
		{
			_panButtons2 = value;
		}
	}

	[Description("Determines which modifier key is used as the primary for panning")]
	[DefaultValue(Keys.Control)]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public Keys PanModifierKeys
	{
		get
		{
			return _panModifierKeys;
		}
		set
		{
			_panModifierKeys = value;
		}
	}

	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Description("Determines which modifier key is used as the secondary for panning")]
	[DefaultValue(Keys.None)]
	[Category("Display")]
	public Keys PanModifierKeys2
	{
		get
		{
			return _panModifierKeys2;
		}
		set
		{
			_panModifierKeys2 = value;
		}
	}

	[Category("Display")]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	[DefaultValue(MouseButtons.Right)]
	[Description("Specify mouse button for point editing")]
	public MouseButtons EditButtons
	{
		get
		{
			return _editButtons;
		}
		set
		{
			_editButtons = value;
		}
	}

	[DefaultValue(Keys.Alt)]
	[Bindable(true)]
	[Category("Display")]
	[Description("Specify modifier key for point editing")]
	[NotifyParentProperty(true)]
	public Keys EditModifierKeys
	{
		get
		{
			return _editModifierKeys;
		}
		set
		{
			_editModifierKeys = value;
		}
	}

	[Category("Display")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	[DefaultValue(MouseButtons.Left)]
	[Description("Specify mouse button for curve selection")]
	public MouseButtons SelectButtons
	{
		get
		{
			return _selectButtons;
		}
		set
		{
			_selectButtons = value;
		}
	}

	[Category("Display")]
	[Bindable(true)]
	[DefaultValue(Keys.Shift)]
	[Description("Specify modifier key for curve selection")]
	[NotifyParentProperty(true)]
	public Keys SelectModifierKeys
	{
		get
		{
			return _selectModifierKeys;
		}
		set
		{
			_selectModifierKeys = value;
		}
	}

	[Bindable(true)]
	[Category("Display")]
	[Description("Specify modifier key for append curve selection")]
	[NotifyParentProperty(true)]
	[DefaultValue(Keys.Shift | Keys.Alt)]
	public Keys SelectAppendModifierKeys => _selectAppendModifierKeys;

	[Description("Specify mouse button for clicking on linkable objects")]
	[DefaultValue(MouseButtons.Left)]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public MouseButtons LinkButtons
	{
		get
		{
			return _linkButtons;
		}
		set
		{
			_linkButtons = value;
		}
	}

	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(Keys.Alt)]
	[Description("Specify modifier key for clicking on linkable objects")]
	[Bindable(true)]
	public Keys LinkModifierKeys
	{
		get
		{
			return _linkModifierKeys;
		}
		set
		{
			_linkModifierKeys = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public MasterPane MasterPane
	{
		get
		{
			lock (this)
			{
				return _masterPane;
			}
		}
		set
		{
			lock (this)
			{
				_masterPane = value;
			}
		}
	}

	[Bindable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public GraphPane GraphPane
	{
		get
		{
			lock (this)
			{
				if (_masterPane != null && _masterPane.PaneList.Count > 0)
				{
					return _masterPane[0];
				}
				return null;
			}
		}
		set
		{
			lock (this)
			{
				if (_masterPane != null)
				{
					_masterPane.PaneList.Clear();
					_masterPane.Add(value);
				}
			}
		}
	}

	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	[Description("true to force all objects to be draw in anti-alias mode")]
	[Bindable(true)]
	public bool IsAntiAlias
	{
		get
		{
			return _masterPane.IsAntiAlias;
		}
		set
		{
			_masterPane.IsAntiAlias = value;
		}
	}

	[Description("true to display tooltips when the mouse hovers over data points")]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	public bool IsShowPointValues
	{
		get
		{
			return _isShowPointValues;
		}
		set
		{
			_isShowPointValues = value;
		}
	}

	[Category("Display")]
	[DefaultValue(false)]
	[Description("true to display tooltips showing the current mouse position within the Chart area")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	public bool IsShowCursorValues
	{
		get
		{
			return _isShowCursorValues;
		}
		set
		{
			_isShowCursorValues = value;
		}
	}

	[Category("Display")]
	[DefaultValue(false)]
	[Description("true to allow horizontal editing by alt-left-click-drag")]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	public bool IsEnableHEdit
	{
		get
		{
			return _isEnableHEdit;
		}
		set
		{
			_isEnableHEdit = value;
		}
	}

	[Description("true to allow vertical editing by alt-left-click-drag")]
	[Category("Display")]
	[DefaultValue(false)]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	public bool IsEnableVEdit
	{
		get
		{
			return _isEnableVEdit;
		}
		set
		{
			_isEnableVEdit = value;
		}
	}

	[Category("Display")]
	[Bindable(true)]
	[DefaultValue(true)]
	[Description("true to allow horizontal and vertical zooming by left-click-drag")]
	[NotifyParentProperty(true)]
	public bool IsEnableZoom
	{
		set
		{
			_isEnableHZoom = value;
			_isEnableVZoom = value;
		}
	}

	[NotifyParentProperty(true)]
	[Bindable(true)]
	[Description("true to allow horizontal zooming by left-click-drag")]
	[Category("Display")]
	[DefaultValue(true)]
	public bool IsEnableHZoom
	{
		get
		{
			return _isEnableHZoom;
		}
		set
		{
			_isEnableHZoom = value;
		}
	}

	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	[Description("true to allow vertical zooming by left-click-drag")]
	public bool IsEnableVZoom
	{
		get
		{
			return _isEnableVZoom;
		}
		set
		{
			_isEnableVZoom = value;
		}
	}

	[Description("true to allow zooming with the mouse wheel")]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	[Bindable(true)]
	public bool IsEnableWheelZoom
	{
		get
		{
			return _isEnableWheelZoom;
		}
		set
		{
			_isEnableWheelZoom = value;
		}
	}

	[Category("Display")]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	[Description("true to allow horizontal panning by middle-mouse-drag or shift-left-drag")]
	public bool IsEnableHPan
	{
		get
		{
			return _isEnableHPan;
		}
		set
		{
			_isEnableHPan = value;
		}
	}

	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	[Description("true to allow vertical panning by middle-mouse-drag or shift-left-drag")]
	[Bindable(true)]
	[Category("Display")]
	public bool IsEnableVPan
	{
		get
		{
			return _isEnableVPan;
		}
		set
		{
			_isEnableVPan = value;
		}
	}

	[Description("true to enable the right mouse button context menu")]
	[DefaultValue(true)]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public bool IsShowContextMenu
	{
		get
		{
			return _isShowContextMenu;
		}
		set
		{
			_isShowContextMenu = value;
		}
	}

	[Bindable(true)]
	[Description("true to show a message box after a 'Copy' context menu action completes")]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	public bool IsShowCopyMessage
	{
		get
		{
			return _isShowCopyMessage;
		}
		set
		{
			_isShowCopyMessage = value;
		}
	}

	[Category("Display")]
	[Bindable(true)]
	[Description("Provides access to the SaveFileDialog for the 'Save As' menu item")]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	public SaveFileDialog SaveFileDialog
	{
		get
		{
			return _saveFileDialog;
		}
		set
		{
			_saveFileDialog = value;
		}
	}

	[Bindable(true)]
	[Description("true to preserve the displayed aspect ratio when printing")]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(true)]
	public bool IsPrintKeepAspectRatio
	{
		get
		{
			return _isPrintKeepAspectRatio;
		}
		set
		{
			_isPrintKeepAspectRatio = value;
		}
	}

	[DefaultValue(true)]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	[Description("true to resize to fill the page when printing")]
	[Category("Display")]
	public bool IsPrintFillPage
	{
		get
		{
			return _isPrintFillPage;
		}
		set
		{
			_isPrintFillPage = value;
		}
	}

	[DefaultValue(true)]
	[Description("true to force font and pen width scaling when printing")]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	public bool IsPrintScaleAll
	{
		get
		{
			return _isPrintScaleAll;
		}
		set
		{
			_isPrintScaleAll = value;
		}
	}

	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	[Description("true to automatically set the scroll bar range to the actual data range")]
	public bool IsAutoScrollRange
	{
		get
		{
			return _isAutoScrollRange;
		}
		set
		{
			_isAutoScrollRange = value;
		}
	}

	public double ScrollGrace
	{
		get
		{
			return _scrollGrace;
		}
		set
		{
			_scrollGrace = value;
		}
	}

	[DefaultValue(false)]
	[Description("true to display the horizontal scroll bar")]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	public bool IsShowHScrollBar
	{
		get
		{
			return _isShowHScrollBar;
		}
		set
		{
			_isShowHScrollBar = value;
			ZedGraphControl_ReSize(this, new EventArgs());
		}
	}

	[Category("Display")]
	[DefaultValue(false)]
	[Description("true to display the vertical scroll bar")]
	[Bindable(true)]
	[NotifyParentProperty(true)]
	public bool IsShowVScrollBar
	{
		get
		{
			return _isShowVScrollBar;
		}
		set
		{
			_isShowVScrollBar = value;
			ZedGraphControl_ReSize(this, new EventArgs());
		}
	}

	[Description("true to force the X axis ranges for all GraphPanes to match")]
	[DefaultValue(false)]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public bool IsSynchronizeXAxes
	{
		get
		{
			return _isSynchronizeXAxes;
		}
		set
		{
			if (_isSynchronizeXAxes != value)
			{
				ZoomStatePurge();
			}
			_isSynchronizeXAxes = value;
		}
	}

	[Bindable(true)]
	[Description("true to force the Y axis ranges for all GraphPanes to match")]
	[Category("Display")]
	[DefaultValue(false)]
	[NotifyParentProperty(true)]
	public bool IsSynchronizeYAxes
	{
		get
		{
			return _isSynchronizeYAxes;
		}
		set
		{
			if (_isSynchronizeYAxes != value)
			{
				ZoomStatePurge();
			}
			_isSynchronizeYAxes = value;
		}
	}

	[Description("true to scroll the Y2 axis along with the Y axis")]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(false)]
	public bool IsScrollY2
	{
		get
		{
			if (_y2ScrollRangeList != null && _y2ScrollRangeList.Count > 0)
			{
				return _y2ScrollRangeList[0].IsScrollable;
			}
			return false;
		}
		set
		{
			if (_y2ScrollRangeList != null && _y2ScrollRangeList.Count > 0)
			{
				ScrollRange value2 = _y2ScrollRangeList[0];
				value2.IsScrollable = value;
				_y2ScrollRangeList[0] = value2;
			}
		}
	}

	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Category("Display")]
	[Description("Sets the manual scroll bar ranges for the collection of Y axes")]
	public ScrollRangeList YScrollRangeList => _yScrollRangeList;

	[NotifyParentProperty(true)]
	[Description("Sets the manual scroll bar ranges for the collection of Y2 axes")]
	[Bindable(true)]
	[Category("Display")]
	public ScrollRangeList Y2ScrollRangeList => _y2ScrollRangeList;

	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Description("Sets the manual scroll minimum value for the X axis")]
	[DefaultValue(0)]
	[Category("Display")]
	public double ScrollMinX
	{
		get
		{
			return _xScrollRange.Min;
		}
		set
		{
			_xScrollRange.Min = value;
		}
	}

	[Description("Sets the manual scroll maximum value for the X axis")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	[DefaultValue(0)]
	[Category("Display")]
	public double ScrollMaxX
	{
		get
		{
			return _xScrollRange.Max;
		}
		set
		{
			_xScrollRange.Max = value;
		}
	}

	[NotifyParentProperty(true)]
	[DefaultValue(0)]
	[Description("Sets the manual scroll minimum value for the Y axis")]
	[Category("Display")]
	[Bindable(true)]
	public double ScrollMinY
	{
		get
		{
			if (_yScrollRangeList != null && _yScrollRangeList.Count > 0)
			{
				return _yScrollRangeList[0].Min;
			}
			return double.NaN;
		}
		set
		{
			if (_yScrollRangeList != null && _yScrollRangeList.Count > 0)
			{
				ScrollRange value2 = _yScrollRangeList[0];
				value2.Min = value;
				_yScrollRangeList[0] = value2;
			}
		}
	}

	[Description("Sets the manual scroll maximum value for the Y axis")]
	[DefaultValue(0)]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public double ScrollMaxY
	{
		get
		{
			if (_yScrollRangeList != null && _yScrollRangeList.Count > 0)
			{
				return _yScrollRangeList[0].Max;
			}
			return double.NaN;
		}
		set
		{
			if (_yScrollRangeList != null && _yScrollRangeList.Count > 0)
			{
				ScrollRange value2 = _yScrollRangeList[0];
				value2.Max = value;
				_yScrollRangeList[0] = value2;
			}
		}
	}

	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue(0)]
	[Description("Sets the manual scroll minimum value for the Y2 axis")]
	[Bindable(true)]
	public double ScrollMinY2
	{
		get
		{
			if (_y2ScrollRangeList != null && _y2ScrollRangeList.Count > 0)
			{
				return _y2ScrollRangeList[0].Min;
			}
			return double.NaN;
		}
		set
		{
			if (_y2ScrollRangeList != null && _y2ScrollRangeList.Count > 0)
			{
				ScrollRange value2 = _y2ScrollRangeList[0];
				value2.Min = value;
				_y2ScrollRangeList[0] = value2;
			}
		}
	}

	[Bindable(true)]
	[Description("Sets the manual scroll maximum value for the Y2 axis")]
	[DefaultValue(0)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	public double ScrollMaxY2
	{
		get
		{
			if (_y2ScrollRangeList != null && _y2ScrollRangeList.Count > 0)
			{
				return _y2ScrollRangeList[0].Max;
			}
			return double.NaN;
		}
		set
		{
			if (_y2ScrollRangeList != null && _y2ScrollRangeList.Count > 0)
			{
				ScrollRange value2 = _y2ScrollRangeList[0];
				value2.Max = value;
				_y2ScrollRangeList[0] = value2;
			}
		}
	}

	public bool IsScrolling
	{
		get
		{
			if (hScrollBar1 != null && vScrollBar1 != null)
			{
				if (!hScrollBar1.Capture)
				{
					return vScrollBar1.Capture;
				}
				return true;
			}
			return false;
		}
	}

	[NotifyParentProperty(true)]
	[Bindable(true)]
	[Category("Display")]
	[Description("Sets the numeric display format string for the point value tooltips")]
	[DefaultValue("G")]
	public string PointValueFormat
	{
		get
		{
			return _pointValueFormat;
		}
		set
		{
			_pointValueFormat = value;
		}
	}

	[Description("Sets the date display format for the point value tooltips")]
	[Bindable(true)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[DefaultValue("g")]
	public string PointDateFormat
	{
		get
		{
			return _pointDateFormat;
		}
		set
		{
			_pointDateFormat = value;
		}
	}

	[Description("Sets the step size fraction for zooming with the mouse wheel")]
	[DefaultValue(0.1)]
	[Category("Display")]
	[NotifyParentProperty(true)]
	[Bindable(true)]
	public double ZoomStepFraction
	{
		get
		{
			return _zoomStepFraction;
		}
		set
		{
			_zoomStepFraction = value;
		}
	}

	[Category("Display")]
	[DefaultValue(false)]
	[Bindable(true)]
	[Description("true to center the mouse wheel zoom at the current mouse location")]
	[NotifyParentProperty(true)]
	public bool IsZoomOnMouseCenter
	{
		get
		{
			return _isZoomOnMouseCenter;
		}
		set
		{
			_isZoomOnMouseCenter = value;
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public bool BeenDisposed
	{
		get
		{
			lock (this)
			{
				return _masterPane == null;
			}
		}
	}

	public Selection Selection => _selection;

	[Bindable(true)]
	[NotifyParentProperty(true)]
	[Description("true to allow selecting Curves")]
	[Category("Display")]
	[DefaultValue(false)]
	public bool IsEnableSelection
	{
		get
		{
			return _isEnableSelection;
		}
		set
		{
			_isEnableSelection = value;
		}
	}

	public PrintDocument PrintDocument
	{
		get
		{
			try
			{
				if (_pdSave == null)
				{
					_pdSave = new PrintDocument();
					_pdSave.PrintPage += Graph_PrintPage;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
			return _pdSave;
		}
		set
		{
			_pdSave = value;
		}
	}

	[Description("Subscribe to this event to be able to modify the ZedGraph context menu")]
	[Category("Events")]
	[Bindable(true)]
	public event ContextMenuBuilderEventHandler ContextMenuBuilder;

	[Description("Subscribe to this event to be notified when the graph is zoomed or panned")]
	[Category("Events")]
	[Bindable(true)]
	public event ZoomEventHandler ZoomEvent;

	[Category("Events")]
	[Description("Subscribe this event to be notified when a scroll operation using the scrollbars is completed")]
	[Bindable(true)]
	public event ScrollDoneHandler ScrollDoneEvent;

	[Description("Subscribe this event to be notified continuously as a scroll operation is taking place")]
	[Bindable(true)]
	[Category("Events")]
	public event ScrollProgressHandler ScrollProgressEvent;

	[Description("Subscribe this event to be notified of general scroll events")]
	[Bindable(true)]
	[Category("Events")]
	public event ScrollEventHandler ScrollEvent;

	[Category("Events")]
	[Bindable(true)]
	[Description("Subscribe to this event to respond to data point edit actions")]
	public event PointEditHandler PointEditEvent;

	[Description("Subscribe to this event to provide custom-formatting for data point tooltips")]
	[Bindable(true)]
	[Category("Events")]
	public event PointValueHandler PointValueEvent;

	[Description("Subscribe to be notified when the left mouse button is clicked down")]
	[Category("Events")]
	[Bindable(true)]
	public event ZedMouseEventHandler MouseDownEvent;

	[Browsable(false)]
	[Bindable(false)]
	public new event MouseEventHandler MouseDown;

	[Bindable(false)]
	[Browsable(false)]
	public new event MouseEventHandler MouseUp;

	[Browsable(false)]
	[Bindable(false)]
	private new event MouseEventHandler MouseMove;

	[Description("Subscribe to be notified when the left mouse button is released")]
	[Category("Events")]
	[Bindable(true)]
	public event ZedMouseEventHandler MouseUpEvent;

	[Category("Events")]
	[Bindable(true)]
	[Description("Subscribe to be notified when the mouse is moved inside the control")]
	public event ZedMouseEventHandler MouseMoveEvent;

	[Category("Events")]
	[Bindable(true)]
	[Description("Subscribe to be notified when the left mouse button is double-clicked")]
	public event ZedMouseEventHandler DoubleClickEvent;

	[Category("Events")]
	[Bindable(true)]
	[Description("Subscribe to be notified when a link-enabled item is clicked")]
	public event LinkEventHandler LinkEvent;

	private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
	{
		if (GraphPane == null)
		{
			return;
		}
		if ((e.Type != ScrollEventType.ThumbPosition && e.Type != ScrollEventType.ThumbTrack) || (e.Type == ScrollEventType.ThumbTrack && _zoomState == null))
		{
			ZoomStateSave(GraphPane, ZoomState.StateType.Scroll);
		}
		for (int i = 0; i < GraphPane.YAxisList.Count; i++)
		{
			ScrollRange scrollRange = _yScrollRangeList[i];
			if (scrollRange.IsScrollable)
			{
				Axis axis = GraphPane.YAxisList[i];
				HandleScroll(axis, e.NewValue, scrollRange.Min, scrollRange.Max, vScrollBar1.LargeChange, !axis.Scale.IsReverse);
			}
		}
		for (int j = 0; j < GraphPane.Y2AxisList.Count; j++)
		{
			ScrollRange scrollRange2 = _y2ScrollRangeList[j];
			if (scrollRange2.IsScrollable)
			{
				Axis axis2 = GraphPane.Y2AxisList[j];
				HandleScroll(axis2, e.NewValue, scrollRange2.Min, scrollRange2.Max, vScrollBar1.LargeChange, !axis2.Scale.IsReverse);
			}
		}
		ApplyToAllPanes(GraphPane);
		ProcessEventStuff(vScrollBar1, e);
	}

	private void ApplyToAllPanes(GraphPane primaryPane)
	{
		foreach (GraphPane pane in _masterPane._paneList)
		{
			if (pane != primaryPane)
			{
				if (_isSynchronizeXAxes)
				{
					Synchronize(primaryPane.XAxis, pane.XAxis);
				}
				if (_isSynchronizeYAxes)
				{
					Synchronize(primaryPane.YAxis, pane.YAxis);
				}
			}
		}
	}

	private void Synchronize(Axis source, Axis dest)
	{
		dest._scale._min = source._scale._min;
		dest._scale._max = source._scale._max;
		dest._scale._majorStep = source._scale._majorStep;
		dest._scale._minorStep = source._scale._minorStep;
		dest._scale._minAuto = source._scale._minAuto;
		dest._scale._maxAuto = source._scale._maxAuto;
		dest._scale._majorStepAuto = source._scale._majorStepAuto;
		dest._scale._minorStepAuto = source._scale._minorStepAuto;
	}

	private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
	{
		if (GraphPane != null)
		{
			if ((e.Type != ScrollEventType.ThumbPosition && e.Type != ScrollEventType.ThumbTrack) || (e.Type == ScrollEventType.ThumbTrack && _zoomState == null))
			{
				ZoomStateSave(GraphPane, ZoomState.StateType.Scroll);
			}
			HandleScroll(GraphPane.XAxis, e.NewValue, _xScrollRange.Min, _xScrollRange.Max, hScrollBar1.LargeChange, GraphPane.XAxis.Scale.IsReverse);
			ApplyToAllPanes(GraphPane);
			ProcessEventStuff(hScrollBar1, e);
		}
	}

	private void ProcessEventStuff(ScrollBar scrollBar, ScrollEventArgs e)
	{
		if (e.Type == ScrollEventType.ThumbTrack)
		{
			if (this.ScrollProgressEvent != null)
			{
				this.ScrollProgressEvent(this, hScrollBar1, _zoomState, new ZoomState(GraphPane, ZoomState.StateType.Scroll));
			}
		}
		else if (_zoomState != null && _zoomState.IsChanged(GraphPane))
		{
			ZoomStatePush(GraphPane);
			if (this.ScrollDoneEvent != null)
			{
				this.ScrollDoneEvent(this, hScrollBar1, _zoomState, new ZoomState(GraphPane, ZoomState.StateType.Scroll));
			}
			_zoomState = null;
		}
		if (this.ScrollEvent != null)
		{
			this.ScrollEvent(scrollBar, e);
		}
	}

	private void HandleScroll(Axis axis, int newValue, double scrollMin, double scrollMax, int largeChange, bool reverse)
	{
		if (axis == null)
		{
			return;
		}
		if (scrollMin > axis._scale._min)
		{
			scrollMin = axis._scale._min;
		}
		if (scrollMax < axis._scale._max)
		{
			scrollMax = axis._scale._max;
		}
		int num = int.MaxValue - largeChange;
		if (num > 0)
		{
			if (reverse)
			{
				newValue = num - newValue;
			}
			Scale scale = axis._scale;
			double num2 = scale._maxLinearized - scale._minLinearized;
			double num3 = scale.Linearize(scrollMax) - num2;
			scrollMin = scale.Linearize(scrollMin);
			double num4 = (scale._minLinearized = scrollMin + (double)newValue / (double)num * (num3 - scrollMin));
			scale._maxLinearized = num4 + num2;
			Invalidate();
		}
	}

	public void SetScrollRangeFromData()
	{
		if (GraphPane == null)
		{
			return;
		}
		double num = CalcScrollGrace(GraphPane.XAxis.Scale._rangeMin, GraphPane.XAxis.Scale._rangeMax);
		_xScrollRange.Min = GraphPane.XAxis.Scale._rangeMin - num;
		_xScrollRange.Max = GraphPane.XAxis.Scale._rangeMax + num;
		_xScrollRange.IsScrollable = true;
		for (int i = 0; i < GraphPane.YAxisList.Count; i++)
		{
			Axis axis = GraphPane.YAxisList[i];
			num = CalcScrollGrace(axis.Scale._rangeMin, axis.Scale._rangeMax);
			ScrollRange scrollRange = new ScrollRange(axis.Scale._rangeMin - num, axis.Scale._rangeMax + num, _yScrollRangeList[i].IsScrollable);
			if (i >= _yScrollRangeList.Count)
			{
				_yScrollRangeList.Add(scrollRange);
			}
			else
			{
				_yScrollRangeList[i] = scrollRange;
			}
		}
		for (int j = 0; j < GraphPane.Y2AxisList.Count; j++)
		{
			Axis axis2 = GraphPane.Y2AxisList[j];
			num = CalcScrollGrace(axis2.Scale._rangeMin, axis2.Scale._rangeMax);
			ScrollRange scrollRange2 = new ScrollRange(axis2.Scale._rangeMin - num, axis2.Scale._rangeMax + num, _y2ScrollRangeList[j].IsScrollable);
			if (j >= _y2ScrollRangeList.Count)
			{
				_y2ScrollRangeList.Add(scrollRange2);
			}
			else
			{
				_y2ScrollRangeList[j] = scrollRange2;
			}
		}
	}

	private double CalcScrollGrace(double min, double max)
	{
		if (Math.Abs(max - min) < 1E-30)
		{
			if (Math.Abs(max) < 1E-30)
			{
				return _scrollGrace;
			}
			return max * _scrollGrace;
		}
		return (max - min) * _scrollGrace;
	}

	private void SetScroll(ScrollBar scrollBar, Axis axis, double scrollMin, double scrollMax)
	{
		if (scrollBar == null || axis == null)
		{
			return;
		}
		scrollBar.Minimum = 0;
		scrollBar.Maximum = 2147483646;
		if (scrollMin > axis._scale._min)
		{
			scrollMin = axis._scale._min;
		}
		if (scrollMax < axis._scale._max)
		{
			scrollMax = axis._scale._max;
		}
		int num = 0;
		Scale scale = axis._scale;
		double minLinearized = scale._minLinearized;
		double maxLinearized = scale._maxLinearized;
		scrollMin = scale.Linearize(scrollMin);
		scrollMax = scale.Linearize(scrollMax);
		double num2 = scrollMax - (maxLinearized - minLinearized);
		if (scrollMin >= num2)
		{
			scrollBar.Enabled = false;
			scrollBar.Value = 0;
			return;
		}
		double num3 = (maxLinearized - minLinearized) / (scrollMax - scrollMin);
		int num4 = (int)(num3 * 2147483647.0 + 0.5);
		if (num4 < 1)
		{
			num4 = 1;
		}
		scrollBar.LargeChange = num4;
		int num5 = num4 / 10;
		if (num5 < 1)
		{
			num5 = 1;
		}
		scrollBar.SmallChange = num5;
		int num6 = int.MaxValue - num4;
		num = (int)((minLinearized - scrollMin) / (num2 - scrollMin) * (double)num6 + 0.5);
		if (num < 0)
		{
			num = 0;
		}
		else if (num > num6)
		{
			num = num6;
		}
		if (axis is XAxis == axis.Scale.IsReverse)
		{
			num = num6 - num;
		}
		if (num < scrollBar.Minimum)
		{
			num = scrollBar.Minimum;
		}
		if (num > scrollBar.Maximum)
		{
			num = scrollBar.Maximum;
		}
		scrollBar.Value = num;
		scrollBar.Enabled = true;
	}

	protected void ZedGraphControl_MouseDown(object sender, MouseEventArgs e)
	{
		_isPanning = false;
		_isZooming = false;
		_isEditing = false;
		_isSelecting = false;
		_dragPane = null;
		Point point = new Point(e.X, e.Y);
		if ((_masterPane != null && e.Clicks > 1 && this.DoubleClickEvent != null && this.DoubleClickEvent(this, e)) || (_masterPane != null && this.MouseDownEvent != null && this.MouseDownEvent(this, e)) || e.Clicks > 1 || _masterPane == null)
		{
			return;
		}
		GraphPane graphPane = MasterPane.FindPane(point);
		if (graphPane != null && e.Button == _linkButtons && Control.ModifierKeys == _linkModifierKeys)
		{
			using Graphics g = CreateGraphics();
			float scaleFactor = graphPane.CalcScaleFactor();
			if (graphPane.FindLinkableObject(point, g, scaleFactor, out var source, out var link, out var index))
			{
				if (this.LinkEvent != null && this.LinkEvent(this, graphPane, source, link, index))
				{
					return;
				}
				string text = ((!(source is CurveItem curve)) ? link._url : link.MakeCurveItemUrl(graphPane, curve, index));
				if (text != string.Empty)
				{
					Process.Start(text);
					return;
				}
			}
		}
		graphPane = MasterPane.FindChartRect(point);
		if (graphPane != null && (_isEnableHPan || _isEnableVPan) && ((e.Button == _panButtons && Control.ModifierKeys == _panModifierKeys) || (e.Button == _panButtons2 && Control.ModifierKeys == _panModifierKeys2)))
		{
			_isPanning = true;
			_dragStartPt = point;
			_dragPane = graphPane;
			ZoomStateSave(_dragPane, ZoomState.StateType.Pan);
		}
		else if (graphPane != null && (_isEnableHZoom || _isEnableVZoom) && ((e.Button == _zoomButtons && Control.ModifierKeys == _zoomModifierKeys) || (e.Button == _zoomButtons2 && Control.ModifierKeys == _zoomModifierKeys2)))
		{
			_isZooming = true;
			_dragStartPt = point;
			_dragEndPt = point;
			_dragEndPt.Offset(1, 1);
			_dragPane = graphPane;
			ZoomStateSave(_dragPane, ZoomState.StateType.Zoom);
		}
		else if (graphPane != null && _isEnableSelection && e.Button == _selectButtons && (Control.ModifierKeys == _selectModifierKeys || Control.ModifierKeys == _selectAppendModifierKeys))
		{
			_isSelecting = true;
			_dragStartPt = point;
			_dragEndPt = point;
			_dragEndPt.Offset(1, 1);
			_dragPane = graphPane;
		}
		else if (graphPane != null && (_isEnableHEdit || _isEnableVEdit) && e.Button == EditButtons && Control.ModifierKeys == EditModifierKeys && graphPane.FindNearestPoint(point, out _dragCurve, out _dragIndex) && _dragCurve.Points is IPointListEdit)
		{
			_isEditing = true;
			_dragPane = graphPane;
			_dragStartPt = point;
			_dragStartPair = _dragCurve[_dragIndex];
		}
	}

	protected void SetCursor()
	{
		SetCursor(PointToClient(Control.MousePosition));
	}

	protected void SetCursor(Point mousePt)
	{
		if (_masterPane != null)
		{
			GraphPane graphPane = _masterPane.FindChartRect(mousePt);
			if ((_isEnableHPan || _isEnableVPan) && (Control.ModifierKeys == Keys.Shift || _isPanning) && (graphPane != null || _isPanning))
			{
				Cursor = Cursors.Hand;
			}
			else if ((_isEnableVZoom || _isEnableHZoom) && (graphPane != null || _isZooming))
			{
				Cursor = Cursors.Cross;
			}
			else if (_isEnableSelection && (graphPane != null || _isSelecting))
			{
				Cursor = Cursors.Cross;
			}
			else
			{
				Cursor = Cursors.Default;
			}
		}
	}

	protected void ZedGraphControl_KeyUp(object sender, KeyEventArgs e)
	{
		SetCursor();
	}

	protected void ZedGraphControl_KeyDown(object sender, KeyEventArgs e)
	{
		SetCursor();
		if (e.KeyCode == Keys.Escape)
		{
			if (_isPanning)
			{
				HandlePanCancel();
			}
			if (_isZooming)
			{
				HandleZoomCancel();
			}
			if (_isEditing)
			{
				HandleEditCancel();
			}
			HandleSelectionCancel();
			_isZooming = false;
			_isPanning = false;
			_isEditing = false;
			_isSelecting = false;
			Refresh();
		}
	}

	protected void ZedGraphControl_MouseUp(object sender, MouseEventArgs e)
	{
		if (_masterPane != null && this.MouseUpEvent != null && this.MouseUpEvent(this, e))
		{
			return;
		}
		if (_masterPane != null && _dragPane != null)
		{
			if (_isZooming)
			{
				HandleZoomFinish(sender, e);
			}
			else if (_isPanning)
			{
				HandlePanFinish();
			}
			else if (_isEditing)
			{
				HandleEditFinish();
			}
			else if (_isSelecting)
			{
				HandleSelectionFinish(sender, e);
			}
		}
		_dragPane = null;
		_isZooming = false;
		_isPanning = false;
		_isEditing = false;
		_isSelecting = false;
		Cursor.Current = Cursors.Default;
	}

	protected string MakeValueLabel(Axis axis, double val, int iPt, bool isOverrideOrdinal)
	{
		if (axis != null)
		{
			if (axis.Scale.IsDate || axis.Scale.Type == AxisType.DateAsOrdinal)
			{
				return XDate.ToString(val, _pointDateFormat);
			}
			if (axis._scale.IsText && axis._scale._textLabels != null)
			{
				int num = iPt;
				if (isOverrideOrdinal)
				{
					num = (int)(val - 0.5);
				}
				if (num >= 0 && num < axis._scale._textLabels.Length)
				{
					return axis._scale._textLabels[num];
				}
				return (num + 1).ToString();
			}
			if (axis.Scale.IsAnyOrdinal && axis.Scale.Type != AxisType.LinearAsOrdinal && !isOverrideOrdinal)
			{
				return iPt.ToString(_pointValueFormat);
			}
			return val.ToString(_pointValueFormat);
		}
		return "";
	}

	protected void ZedGraphControl_MouseMove(object sender, MouseEventArgs e)
	{
		if (_masterPane == null)
		{
			return;
		}
		Point point = new Point(e.X, e.Y);
		if (this.MouseMoveEvent == null || !this.MouseMoveEvent(this, e))
		{
			SetCursor(point);
			if (_isZooming)
			{
				HandleZoomDrag(point);
			}
			else if (_isPanning)
			{
				HandlePanDrag(point);
			}
			else if (_isEditing)
			{
				HandleEditDrag(point);
			}
			else if (_isShowCursorValues)
			{
				HandleCursorValues(point);
			}
			else if (_isShowPointValues)
			{
				HandlePointValues(point);
			}
			else if (_isSelecting)
			{
				HandleZoomDrag(point);
			}
		}
	}

	private Point HandlePointValues(Point mousePt)
	{
		using (Graphics g = CreateGraphics())
		{
			if (_masterPane.FindNearestPaneObject(mousePt, g, out var pane, out var nearestObj, out var index))
			{
				if (nearestObj is CurveItem && index >= 0)
				{
					CurveItem curveItem = (CurveItem)nearestObj;
					if (this.PointValueEvent != null)
					{
						string text = this.PointValueEvent(this, pane, curveItem, index);
						if (text != null && text.Length > 0)
						{
							pointToolTip.SetToolTip(this, text);
							pointToolTip.Active = true;
						}
						else
						{
							pointToolTip.Active = false;
						}
					}
					else
					{
						if (curveItem is PieItem)
						{
							pointToolTip.SetToolTip(this, ((PieItem)curveItem).Value.ToString(_pointValueFormat));
						}
						else
						{
							PointPair pointPair = curveItem.Points[index];
							if (pointPair.Tag is string)
							{
								pointToolTip.SetToolTip(this, (string)pointPair.Tag);
							}
							else
							{
								ValueHandler valueHandler = new ValueHandler(pane, initialize: false);
								double baseVal;
								double lowVal;
								double hiVal;
								if ((curveItem is BarItem || curveItem is ErrorBarItem || curveItem is HiLowBarItem) && pane.BarSettings.Base != BarBase.X)
								{
									valueHandler.GetValues(curveItem, index, out baseVal, out lowVal, out hiVal);
								}
								else
								{
									valueHandler.GetValues(curveItem, index, out hiVal, out lowVal, out baseVal);
								}
								string text2 = MakeValueLabel(curveItem.GetXAxis(pane), hiVal, index, curveItem.IsOverrideOrdinal);
								string text3 = MakeValueLabel(curveItem.GetYAxis(pane), baseVal, index, curveItem.IsOverrideOrdinal);
								pointToolTip.SetToolTip(this, "( " + text2 + ", " + text3 + " )");
							}
						}
						pointToolTip.Active = true;
					}
				}
				else
				{
					pointToolTip.Active = false;
				}
			}
			else
			{
				pointToolTip.Active = false;
			}
		}
		return mousePt;
	}

	private Point HandleCursorValues(Point mousePt)
	{
		GraphPane graphPane = _masterPane.FindPane(mousePt);
		if (graphPane != null && graphPane.Chart._rect.Contains(mousePt))
		{
			graphPane.ReverseTransform((PointF)mousePt, out double val, out double _, out double val2, out double y);
			string text = MakeValueLabel(graphPane.XAxis, val, -1, isOverrideOrdinal: true);
			string text2 = MakeValueLabel(graphPane.YAxis, val2, -1, isOverrideOrdinal: true);
			string text3 = MakeValueLabel(graphPane.Y2Axis, y, -1, isOverrideOrdinal: true);
			pointToolTip.SetToolTip(this, "( " + text + ", " + text2 + ", " + text3 + " )");
			pointToolTip.Active = true;
		}
		else
		{
			pointToolTip.Active = false;
		}
		return mousePt;
	}

	protected void ZedGraphControl_MouseWheel(object sender, MouseEventArgs e)
	{
		if ((!_isEnableVZoom && !_isEnableHZoom) || !_isEnableWheelZoom || _masterPane == null)
		{
			return;
		}
		GraphPane graphPane = MasterPane.FindChartRect(new PointF(e.X, e.Y));
		if (graphPane == null || e.Delta == 0)
		{
			return;
		}
		ZoomState oldState = ZoomStateSave(graphPane, ZoomState.StateType.WheelZoom);
		PointF centerPt = new PointF(e.X, e.Y);
		double zoomFraction = 1.0 + ((e.Delta < 0) ? 1.0 : (-1.0)) * ZoomStepFraction;
		ZoomPane(graphPane, zoomFraction, centerPt, _isZoomOnMouseCenter, isRefresh: false);
		ApplyToAllPanes(graphPane);
		using (Graphics g = CreateGraphics())
		{
			graphPane.AxisChange(g);
			foreach (GraphPane pane in _masterPane._paneList)
			{
				if (pane != graphPane && (_isSynchronizeXAxes || _isSynchronizeYAxes))
				{
					pane.AxisChange(g);
				}
			}
		}
		ZoomStatePush(graphPane);
		if (this.ZoomEvent != null)
		{
			this.ZoomEvent(this, oldState, new ZoomState(graphPane, ZoomState.StateType.WheelZoom));
		}
		Refresh();
	}

	protected void ZoomPane(GraphPane pane, double zoomFraction, PointF centerPt, bool isZoomOnCenter, bool isRefresh)
	{
		pane.ReverseTransform(centerPt, out double centerVal, out double x, out double[] array, out double[] y);
		if (_isEnableHZoom)
		{
			ZoomScale(pane.XAxis, zoomFraction, centerVal, isZoomOnCenter);
			ZoomScale(pane.X2Axis, zoomFraction, x, isZoomOnCenter);
		}
		if (_isEnableVZoom)
		{
			for (int i = 0; i < pane.YAxisList.Count; i++)
			{
				ZoomScale(pane.YAxisList[i], zoomFraction, array[i], isZoomOnCenter);
			}
			for (int j = 0; j < pane.Y2AxisList.Count; j++)
			{
				ZoomScale(pane.Y2AxisList[j], zoomFraction, y[j], isZoomOnCenter);
			}
		}
		using (Graphics g = CreateGraphics())
		{
			pane.AxisChange(g);
		}
		SetScroll(hScrollBar1, pane.XAxis, _xScrollRange.Min, _xScrollRange.Max);
		SetScroll(vScrollBar1, pane.YAxis, _yScrollRangeList[0].Min, _yScrollRangeList[0].Max);
		if (isRefresh)
		{
			Refresh();
		}
	}

	public void ZoomPane(GraphPane pane, double zoomFraction, PointF centerPt, bool isZoomOnCenter)
	{
		ZoomPane(pane, zoomFraction, centerPt, isZoomOnCenter, isRefresh: true);
	}

	protected void ZoomScale(Axis axis, double zoomFraction, double centerVal, bool isZoomOnCenter)
	{
		if (axis != null && zoomFraction > 0.0001 && zoomFraction < 1000.0)
		{
			_ = axis._scale;
			double minLinearized = axis._scale._minLinearized;
			double maxLinearized = axis._scale._maxLinearized;
			double num = (maxLinearized - minLinearized) * zoomFraction / 2.0;
			if (!isZoomOnCenter)
			{
				centerVal = (maxLinearized + minLinearized) / 2.0;
			}
			axis._scale._minLinearized = centerVal - num;
			axis._scale._maxLinearized = centerVal + num;
			axis._scale._minAuto = false;
			axis._scale._maxAuto = false;
		}
	}

	private Point HandlePanDrag(Point mousePt)
	{
		_dragPane.ReverseTransform((PointF)_dragStartPt, out double startVal, out double x, out double[] array, out double[] y);
		_dragPane.ReverseTransform((PointF)mousePt, out double endVal, out double x2, out double[] array2, out double[] y2);
		if (_isEnableHPan)
		{
			PanScale(_dragPane.XAxis, startVal, endVal);
			PanScale(_dragPane.X2Axis, x, x2);
			SetScroll(hScrollBar1, _dragPane.XAxis, _xScrollRange.Min, _xScrollRange.Max);
		}
		if (_isEnableVPan)
		{
			for (int i = 0; i < array.Length; i++)
			{
				PanScale(_dragPane.YAxisList[i], array[i], array2[i]);
			}
			for (int j = 0; j < y.Length; j++)
			{
				PanScale(_dragPane.Y2AxisList[j], y[j], y2[j]);
			}
			SetScroll(vScrollBar1, _dragPane.YAxis, _yScrollRangeList[0].Min, _yScrollRangeList[0].Max);
		}
		ApplyToAllPanes(_dragPane);
		Refresh();
		_dragStartPt = mousePt;
		return mousePt;
	}

	private void HandlePanFinish()
	{
		if (_zoomState != null && _zoomState.IsChanged(_dragPane))
		{
			ZoomStatePush(_dragPane);
			if (this.ZoomEvent != null)
			{
				this.ZoomEvent(this, _zoomState, new ZoomState(_dragPane, ZoomState.StateType.Pan));
			}
			_zoomState = null;
		}
	}

	private void HandlePanCancel()
	{
		if (_isPanning)
		{
			if (_zoomState != null && _zoomState.IsChanged(_dragPane))
			{
				ZoomStateRestore(_dragPane);
			}
			_isPanning = false;
			Refresh();
			ZoomStateClear();
		}
	}

	protected void PanScale(Axis axis, double startVal, double endVal)
	{
		if (axis != null)
		{
			Scale scale = axis._scale;
			double num = scale.Linearize(startVal) - scale.Linearize(endVal);
			scale._minLinearized += num;
			scale._maxLinearized += num;
			scale._minAuto = false;
			scale._maxAuto = false;
		}
	}

	private void HandleEditDrag(Point mousePt)
	{
		_dragPane.ReverseTransform(mousePt, _dragCurve.IsX2Axis, _dragCurve.IsY2Axis, _dragCurve.YAxisIndex, out var val, out var val2);
		_dragPane.ReverseTransform(_dragStartPt, _dragCurve.IsX2Axis, _dragCurve.IsY2Axis, _dragCurve.YAxisIndex, out var val3, out var val4);
		PointPair pointPair = new PointPair(_dragStartPair);
		Scale scale = _dragCurve.GetXAxis(_dragPane)._scale;
		if (_isEnableHEdit)
		{
			pointPair.X = scale.DeLinearize(scale.Linearize(pointPair.X) + scale.Linearize(val) - scale.Linearize(val3));
		}
		Scale scale2 = _dragCurve.GetYAxis(_dragPane)._scale;
		if (_isEnableVEdit)
		{
			pointPair.Y = scale2.DeLinearize(scale2.Linearize(pointPair.Y) + scale2.Linearize(val2) - scale2.Linearize(val4));
		}
		if (_dragCurve.Points is IPointListEdit pointListEdit)
		{
			pointListEdit[_dragIndex] = pointPair;
		}
		Refresh();
	}

	private void HandleEditFinish()
	{
		if (this.PointEditEvent != null)
		{
			this.PointEditEvent(this, _dragPane, _dragCurve, _dragIndex);
		}
	}

	private void HandleEditCancel()
	{
		if (_isEditing)
		{
			if (_dragCurve.Points is IPointListEdit pointListEdit)
			{
				pointListEdit[_dragIndex] = _dragStartPair;
			}
			_isEditing = false;
			Refresh();
		}
	}

	private void HandleZoomDrag(Point mousePt)
	{
		Rectangle rectangle = CalcScreenRect(_dragStartPt, _dragEndPt);
		ControlPaint.DrawReversibleFrame(rectangle, BackColor, FrameStyle.Dashed);
		_dragEndPt = Point.Round(BoundPointToRect(mousePt, _dragPane.Chart._rect));
		rectangle = CalcScreenRect(_dragStartPt, _dragEndPt);
		ControlPaint.DrawReversibleFrame(rectangle, BackColor, FrameStyle.Dashed);
	}

	private void HandleZoomFinish(object sender, MouseEventArgs e)
	{
		PointF ptF = BoundPointToRect(new Point(e.X, e.Y), _dragPane.Chart._rect);
		if ((!(Math.Abs(ptF.X - (float)_dragStartPt.X) > 4f) && _isEnableHZoom) || (!(Math.Abs(ptF.Y - (float)_dragStartPt.Y) > 4f) && _isEnableVZoom))
		{
			return;
		}
		_dragPane.ReverseTransform((PointF)_dragStartPt, out double num, out double x, out double[] array, out double[] y);
		_dragPane.ReverseTransform(ptF, out double num2, out double x2, out double[] array2, out double[] y2);
		bool flag = false;
		if (_isEnableHZoom)
		{
			Math.Min(num, num2);
			Math.Max(num, num2);
			Math.Min(x, x2);
			Math.Max(x, x2);
			if (Math.Abs(num - num2) < 1E-300 || Math.Abs(x - x2) < 1E-300)
			{
				flag = true;
			}
		}
		if (_isEnableVZoom && !flag)
		{
			for (int i = 0; i < array.Length; i++)
			{
				if (Math.Abs(array[i] - array2[i]) < 1E-300)
				{
					flag = true;
					break;
				}
			}
			for (int j = 0; j < y.Length; j++)
			{
				if (Math.Abs(y[j] - y2[j]) < 1E-300)
				{
					flag = true;
					break;
				}
			}
		}
		if (!flag)
		{
			ZoomStatePush(_dragPane);
			if (_isEnableHZoom)
			{
				_dragPane.XAxis._scale._min = Math.Min(num, num2);
				_dragPane.XAxis._scale._minAuto = false;
				_dragPane.XAxis._scale._max = Math.Max(num, num2);
				_dragPane.XAxis._scale._maxAuto = false;
				_dragPane.X2Axis._scale._min = Math.Min(x, x2);
				_dragPane.X2Axis._scale._minAuto = false;
				_dragPane.X2Axis._scale._max = Math.Max(x, x2);
				_dragPane.X2Axis._scale._maxAuto = false;
			}
			if (_isEnableVZoom)
			{
				for (int k = 0; k < array.Length; k++)
				{
					_dragPane.YAxisList[k]._scale._min = Math.Min(array[k], array2[k]);
					_dragPane.YAxisList[k]._scale._max = Math.Max(array[k], array2[k]);
					_dragPane.YAxisList[k]._scale._minAuto = false;
					_dragPane.YAxisList[k]._scale._maxAuto = false;
				}
				for (int l = 0; l < y.Length; l++)
				{
					_dragPane.Y2AxisList[l]._scale._min = Math.Min(y[l], y2[l]);
					_dragPane.Y2AxisList[l]._scale._max = Math.Max(y[l], y2[l]);
					_dragPane.Y2AxisList[l]._scale._minAuto = false;
					_dragPane.Y2AxisList[l]._scale._maxAuto = false;
				}
			}
			SetScroll(hScrollBar1, _dragPane.XAxis, _xScrollRange.Min, _xScrollRange.Max);
			SetScroll(vScrollBar1, _dragPane.YAxis, _yScrollRangeList[0].Min, _yScrollRangeList[0].Max);
			ApplyToAllPanes(_dragPane);
			if (this.ZoomEvent != null)
			{
				this.ZoomEvent(this, _zoomState, new ZoomState(_dragPane, ZoomState.StateType.Zoom));
			}
			using Graphics g = CreateGraphics();
			_dragPane.AxisChange(g);
			foreach (GraphPane pane in _masterPane._paneList)
			{
				if (pane != _dragPane && (_isSynchronizeXAxes || _isSynchronizeYAxes))
				{
					pane.AxisChange(g);
				}
			}
		}
		Refresh();
	}

	private void HandleZoomCancel()
	{
		if (_isZooming)
		{
			_isZooming = false;
			Refresh();
			ZoomStateClear();
		}
	}

	private PointF BoundPointToRect(Point mousePt, RectangleF rect)
	{
		PointF result = new PointF(mousePt.X, mousePt.Y);
		if ((float)mousePt.X < rect.X)
		{
			result.X = rect.X;
		}
		if ((float)mousePt.X > rect.Right)
		{
			result.X = rect.Right;
		}
		if ((float)mousePt.Y < rect.Y)
		{
			result.Y = rect.Y;
		}
		if ((float)mousePt.Y > rect.Bottom)
		{
			result.Y = rect.Bottom;
		}
		return result;
	}

	private Rectangle CalcScreenRect(Point mousePt1, Point mousePt2)
	{
		Point location = PointToScreen(mousePt1);
		Size size = new Size(mousePt2.X - mousePt1.X, mousePt2.Y - mousePt1.Y);
		Rectangle result = new Rectangle(location, size);
		if (_isZooming)
		{
			Rectangle rectangle = Rectangle.Round(_dragPane.Chart._rect);
			Point point = PointToScreen(rectangle.Location);
			if (!_isEnableVZoom)
			{
				result.Y = point.Y;
				result.Height = rectangle.Height + 1;
			}
			else if (!_isEnableHZoom)
			{
				result.X = point.X;
				result.Width = rectangle.Width + 1;
			}
		}
		return result;
	}

	private void HandleSelectionFinish(object sender, MouseEventArgs e)
	{
		if (e.Button != _selectButtons)
		{
			Refresh();
			return;
		}
		PointF ptF = BoundPointToRect(new Point(e.X, e.Y), _dragPane.Chart._rect);
		PointF pointF = BoundPointToRect(new Point(e.X, e.Y), _dragPane.Rect);
		((Control)sender).PointToScreen(Point.Round(pointF));
		if (Math.Abs(ptF.X - (float)_dragStartPt.X) > 4f && Math.Abs(ptF.Y - (float)_dragStartPt.Y) > 4f)
		{
			_ = (PointF)((Control)sender).PointToClient(new Point(Convert.ToInt32(_dragPane.Rect.X), Convert.ToInt32(_dragPane.Rect.Y)));
			_dragPane.ReverseTransform((PointF)_dragStartPt, out double val, out double _, out double[] array, out double[] y);
			_dragPane.ReverseTransform(ptF, out double val2, out double _, out double[] array2, out double[] y2);
			CurveList containedObjs = new CurveList();
			double num = Math.Min(val, val2);
			double num2 = Math.Max(val, val2);
			double num3 = 0.0;
			double num4 = 0.0;
			for (int i = 0; i < array.Length; i++)
			{
				num4 = Math.Min(array[i], array2[i]);
				num3 = Math.Max(array[i], array2[i]);
			}
			for (int j = 0; j < y.Length; j++)
			{
				num4 = Math.Min(num4, y2[j]);
				num4 = Math.Min(y[j], num4);
				num3 = Math.Max(num3, y2[j]);
				num3 = Math.Max(y[j], num3);
			}
			double num5 = num2 - num;
			double num6 = num4 - num3;
			RectangleF rectF = new RectangleF((float)num, (float)num3, (float)num5, (float)num6);
			_dragPane.FindContainedObjects(rectF, CreateGraphics(), out containedObjs);
			if (Control.ModifierKeys == _selectAppendModifierKeys)
			{
				_selection.AddToSelection(_masterPane, containedObjs);
			}
			else
			{
				_selection.Select(_masterPane, containedObjs);
			}
		}
		else
		{
			using Graphics g = CreateGraphics();
			if (MasterPane.FindNearestPaneObject(pointF, g, out var _, out var nearestObj, out var index))
			{
				if (nearestObj is CurveItem && index >= 0)
				{
					if (Control.ModifierKeys == _selectAppendModifierKeys)
					{
						_selection.AddToSelection(_masterPane, nearestObj as CurveItem);
					}
					else
					{
						_selection.Select(_masterPane, nearestObj as CurveItem);
					}
				}
				else
				{
					_selection.ClearSelection(_masterPane);
				}
				Refresh();
			}
			else
			{
				_selection.ClearSelection(_masterPane);
			}
		}
		using (Graphics g2 = CreateGraphics())
		{
			_dragPane.AxisChange(g2);
			foreach (GraphPane pane2 in _masterPane._paneList)
			{
				if (pane2 != _dragPane && (_isSynchronizeXAxes || _isSynchronizeYAxes))
				{
					pane2.AxisChange(g2);
				}
			}
		}
		Refresh();
	}

	private void HandleSelectionCancel()
	{
		_isSelecting = false;
		_selection.ClearSelection(_masterPane);
		Refresh();
	}

	public ZedGraphControl()
	{
		InitializeComponent();
		base.MouseDown += ZedGraphControl_MouseDown;
		base.MouseUp += ZedGraphControl_MouseUp;
		base.MouseMove += ZedGraphControl_MouseMove;
		SetStyle(ControlStyles.UserPaint | ControlStyles.ResizeRedraw | ControlStyles.AllPaintingInWmPaint | ControlStyles.DoubleBuffer, value: true);
		SetStyle(ControlStyles.SupportsTransparentBackColor, value: true);
		_resourceManager = new ResourceManager("ZedGraph.ZedGraph.ZedGraphLocale", Assembly.GetExecutingAssembly());
		Rectangle rectangle = new Rectangle(0, 0, base.Size.Width, base.Size.Height);
		_masterPane = new MasterPane("", rectangle);
		_masterPane.Margin.All = 0f;
		_masterPane.Title.IsVisible = false;
		string title = _resourceManager.GetString("title_def");
		string xTitle = _resourceManager.GetString("x_title_def");
		string yTitle = _resourceManager.GetString("y_title_def");
		GraphPane graphPane = new GraphPane(rectangle, title, xTitle, yTitle);
		using (Graphics g = CreateGraphics())
		{
			graphPane.AxisChange(g);
		}
		_masterPane.Add(graphPane);
		hScrollBar1.Minimum = 0;
		hScrollBar1.Maximum = 100;
		hScrollBar1.Value = 0;
		vScrollBar1.Minimum = 0;
		vScrollBar1.Maximum = 100;
		vScrollBar1.Value = 0;
		_xScrollRange = new ScrollRange(isScrollable: true);
		_yScrollRangeList = new ScrollRangeList();
		_y2ScrollRangeList = new ScrollRangeList();
		_yScrollRangeList.Add(new ScrollRange(isScrollable: true));
		_y2ScrollRangeList.Add(new ScrollRange(isScrollable: false));
		_zoomState = null;
		_zoomStateStack = new ZoomStateStack();
	}

	protected override void Dispose(bool disposing)
	{
		lock (this)
		{
			if (disposing && components != null)
			{
				components.Dispose();
			}
			base.Dispose(disposing);
			_masterPane = null;
		}
	}

	protected override void OnPaint(PaintEventArgs e)
	{
		lock (this)
		{
			if (BeenDisposed || _masterPane == null || GraphPane == null)
			{
				return;
			}
			if (hScrollBar1 != null && GraphPane != null && vScrollBar1 != null && _yScrollRangeList != null)
			{
				SetScroll(hScrollBar1, GraphPane.XAxis, _xScrollRange.Min, _xScrollRange.Max);
				SetScroll(vScrollBar1, GraphPane.YAxis, _yScrollRangeList[0].Min, _yScrollRangeList[0].Max);
			}
			base.OnPaint(e);
			try
			{
				_masterPane.Draw(e.Graphics);
			}
			catch
			{
			}
		}
	}

	protected void ZedGraphControl_ReSize(object sender, EventArgs e)
	{
		lock (this)
		{
			if (!BeenDisposed && _masterPane != null)
			{
				Size size = base.Size;
				if (_isShowHScrollBar)
				{
					hScrollBar1.Visible = true;
					size.Height -= hScrollBar1.Size.Height;
					hScrollBar1.Location = new Point(0, size.Height);
					hScrollBar1.Size = new Size(size.Width, hScrollBar1.Height);
				}
				else
				{
					hScrollBar1.Visible = false;
				}
				if (_isShowVScrollBar)
				{
					vScrollBar1.Visible = true;
					size.Width -= vScrollBar1.Size.Width;
					vScrollBar1.Location = new Point(size.Width, 0);
					vScrollBar1.Size = new Size(vScrollBar1.Width, size.Height);
				}
				else
				{
					vScrollBar1.Visible = false;
				}
				using (Graphics g = CreateGraphics())
				{
					_masterPane.ReSize(g, new RectangleF(0f, 0f, size.Width, size.Height));
				}
				Invalidate();
			}
		}
	}

	public virtual void AxisChange()
	{
		lock (this)
		{
			if (!BeenDisposed && _masterPane != null)
			{
				using (Graphics g = CreateGraphics())
				{
					_masterPane.AxisChange(g);
				}
				if (_isAutoScrollRange)
				{
					SetScrollRangeFromData();
				}
			}
		}
	}

	private ZoomState ZoomStateSave(GraphPane primaryPane, ZoomState.StateType type)
	{
		ZoomStateClear();
		if (_isSynchronizeXAxes || _isSynchronizeYAxes)
		{
			foreach (GraphPane pane in _masterPane._paneList)
			{
				ZoomState zoomState = new ZoomState(pane, type);
				if (pane == primaryPane)
				{
					_zoomState = zoomState;
				}
				_zoomStateStack.Add(zoomState);
			}
		}
		else
		{
			_zoomState = new ZoomState(primaryPane, type);
		}
		return _zoomState;
	}

	private void ZoomStateRestore(GraphPane primaryPane)
	{
		if (_isSynchronizeXAxes || _isSynchronizeYAxes)
		{
			for (int i = 0; i < _masterPane._paneList.Count; i++)
			{
				if (i < _zoomStateStack.Count)
				{
					_zoomStateStack[i].ApplyState(_masterPane._paneList[i]);
				}
			}
		}
		else if (_zoomState != null)
		{
			_zoomState.ApplyState(primaryPane);
		}
		ZoomStateClear();
	}

	private void ZoomStatePush(GraphPane primaryPane)
	{
		if (_isSynchronizeXAxes || _isSynchronizeYAxes)
		{
			for (int i = 0; i < _masterPane._paneList.Count; i++)
			{
				if (i < _zoomStateStack.Count)
				{
					_masterPane._paneList[i].ZoomStack.Add(_zoomStateStack[i]);
				}
			}
		}
		else if (_zoomState != null)
		{
			primaryPane.ZoomStack.Add(_zoomState);
		}
		ZoomStateClear();
	}

	private void ZoomStateClear()
	{
		_zoomStateStack.Clear();
		_zoomState = null;
	}

	private void ZoomStatePurge()
	{
		foreach (GraphPane pane in _masterPane._paneList)
		{
			pane.ZoomStack.Clear();
		}
	}

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Bindable(false)]
	public Image GetImage()
	{
		lock (this)
		{
			if (BeenDisposed || _masterPane == null || _masterPane[0] == null)
			{
				throw new ZedGraphException("The control has been disposed");
			}
			return _masterPane.GetImage();
		}
	}

	protected void MenuClick_PageSetup(object sender, EventArgs e)
	{
		DoPageSetup();
	}

	protected void MenuClick_Print(object sender, EventArgs e)
	{
		DoPrint();
	}

	private void Graph_PrintPage(object sender, PrintPageEventArgs e)
	{
		MasterPane masterPane = MasterPane;
		bool[] array = new bool[masterPane.PaneList.Count + 1];
		bool[] array2 = new bool[masterPane.PaneList.Count + 1];
		array[0] = masterPane.IsPenWidthScaled;
		array2[0] = masterPane.IsFontsScaled;
		for (int i = 0; i < masterPane.PaneList.Count; i++)
		{
			array[i + 1] = masterPane[i].IsPenWidthScaled;
			array2[i + 1] = masterPane[i].IsFontsScaled;
			if (_isPrintScaleAll)
			{
				masterPane[i].IsPenWidthScaled = true;
				masterPane[i].IsFontsScaled = true;
			}
		}
		RectangleF rect = masterPane.Rect;
		SizeF sizeF = masterPane.Rect.Size;
		if (_isPrintFillPage && _isPrintKeepAspectRatio)
		{
			float val = (float)e.MarginBounds.Width / sizeF.Width;
			float val2 = (float)e.MarginBounds.Height / sizeF.Height;
			float num = Math.Min(val, val2);
			sizeF.Width *= num;
			sizeF.Height *= num;
		}
		else if (_isPrintFillPage)
		{
			sizeF = e.MarginBounds.Size;
		}
		masterPane.ReSize(e.Graphics, new RectangleF(e.MarginBounds.Left, e.MarginBounds.Top, sizeF.Width, sizeF.Height));
		masterPane.Draw(e.Graphics);
		using (Graphics g = CreateGraphics())
		{
			masterPane.ReSize(g, rect);
		}
		masterPane.IsPenWidthScaled = array[0];
		masterPane.IsFontsScaled = array2[0];
		for (int j = 0; j < masterPane.PaneList.Count; j++)
		{
			masterPane[j].IsPenWidthScaled = array[j + 1];
			masterPane[j].IsFontsScaled = array2[j + 1];
		}
	}

	public void DoPageSetup()
	{
		PrintDocument printDocument = PrintDocument;
		try
		{
			if (printDocument != null)
			{
				PageSetupDialog pageSetupDialog = new PageSetupDialog();
				pageSetupDialog.Document = printDocument;
				if (pageSetupDialog.ShowDialog() == DialogResult.OK)
				{
					printDocument.PrinterSettings = pageSetupDialog.PrinterSettings;
					printDocument.DefaultPageSettings = pageSetupDialog.PageSettings;
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public void DoPrint()
	{
		try
		{
			PrintDocument printDocument = PrintDocument;
			if (printDocument != null)
			{
				PrintDialog printDialog = new PrintDialog();
				printDialog.Document = printDocument;
				if (printDialog.ShowDialog() == DialogResult.OK)
				{
					printDocument.Print();
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	public void DoPrintPreview()
	{
		try
		{
			PrintDocument printDocument = PrintDocument;
			if (printDocument != null)
			{
				PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
				printPreviewDialog.Document = printDocument;
				printPreviewDialog.Show(this);
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
	}

	private ContextMenuObjectState GetObjectState()
	{
		ContextMenuObjectState result = ContextMenuObjectState.Background;
		Point point = PointToClient(Control.MousePosition);
		using (Graphics g = CreateGraphics())
		{
			if (MasterPane.FindNearestPaneObject(point, g, out var _, out var nearestObj, out var index) && nearestObj is CurveItem curveItem && index >= 0)
			{
				result = (curveItem.IsSelected ? ContextMenuObjectState.ActiveSelection : ContextMenuObjectState.InactiveSelection);
			}
		}
		return result;
	}

	private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
	{
		e.Cancel = true;
		ContextMenuStrip contextMenuStrip = sender as ContextMenuStrip;
		ContextMenuObjectState objectState = GetObjectState();
		if (_masterPane == null || contextMenuStrip == null)
		{
			return;
		}
		contextMenuStrip.Items.Clear();
		_isZooming = false;
		_isPanning = false;
		Cursor.Current = Cursors.Default;
		_menuClickPt = PointToClient(Control.MousePosition);
		GraphPane graphPane = _masterPane.FindPane(_menuClickPt);
		if (!_isShowContextMenu)
		{
			return;
		}
		string text = string.Empty;
		ToolStripMenuItem toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "copy";
		toolStripMenuItem.Tag = "copy";
		toolStripMenuItem.Text = _resourceManager.GetString("copy");
		toolStripMenuItem.Click += MenuClick_Copy;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "save_as";
		toolStripMenuItem.Tag = "save_as";
		toolStripMenuItem.Text = _resourceManager.GetString("save_as");
		toolStripMenuItem.Click += MenuClick_SaveAs;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "page_setup";
		toolStripMenuItem.Tag = "page_setup";
		toolStripMenuItem.Text = _resourceManager.GetString("page_setup");
		toolStripMenuItem.Click += MenuClick_PageSetup;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "print";
		toolStripMenuItem.Tag = "print";
		toolStripMenuItem.Text = _resourceManager.GetString("print");
		toolStripMenuItem.Click += MenuClick_Print;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "show_val";
		toolStripMenuItem.Tag = "show_val";
		toolStripMenuItem.Text = _resourceManager.GetString("show_val");
		toolStripMenuItem.Click += MenuClick_ShowValues;
		toolStripMenuItem.Checked = IsShowPointValues;
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "unzoom";
		toolStripMenuItem.Tag = "unzoom";
		if (graphPane == null || graphPane.ZoomStack.IsEmpty)
		{
			text = _resourceManager.GetString("unzoom");
		}
		else
		{
			switch (graphPane.ZoomStack.Top.Type)
			{
			case ZoomState.StateType.Zoom:
			case ZoomState.StateType.WheelZoom:
				text = _resourceManager.GetString("unzoom");
				break;
			case ZoomState.StateType.Pan:
				text = _resourceManager.GetString("unpan");
				break;
			case ZoomState.StateType.Scroll:
				text = _resourceManager.GetString("unscroll");
				break;
			}
		}
		toolStripMenuItem.Text = text;
		toolStripMenuItem.Click += MenuClick_ZoomOut;
		if (graphPane == null || graphPane.ZoomStack.IsEmpty)
		{
			toolStripMenuItem.Enabled = false;
		}
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "undo_all";
		toolStripMenuItem.Tag = "undo_all";
		text = _resourceManager.GetString("undo_all");
		toolStripMenuItem.Text = text;
		toolStripMenuItem.Click += MenuClick_ZoomOutAll;
		if (graphPane == null || graphPane.ZoomStack.IsEmpty)
		{
			toolStripMenuItem.Enabled = false;
		}
		contextMenuStrip.Items.Add(toolStripMenuItem);
		toolStripMenuItem = new ToolStripMenuItem();
		toolStripMenuItem.Name = "set_default";
		toolStripMenuItem.Tag = "set_default";
		text = _resourceManager.GetString("set_default");
		toolStripMenuItem.Text = text;
		toolStripMenuItem.Click += MenuClick_RestoreScale;
		if (graphPane == null)
		{
			toolStripMenuItem.Enabled = false;
		}
		contextMenuStrip.Items.Add(toolStripMenuItem);
		e.Cancel = false;
		if (this.ContextMenuBuilder != null)
		{
			this.ContextMenuBuilder(this, contextMenuStrip, _menuClickPt, objectState);
		}
	}

	protected void MenuClick_Copy(object sender, EventArgs e)
	{
		Copy(_isShowCopyMessage);
	}

	public void Copy(bool isShowMessage)
	{
		if (_masterPane != null)
		{
			Thread thread = new Thread(ClipboardCopyThread);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
			if (isShowMessage)
			{
				string text = _resourceManager.GetString("copied_to_clip");
				MessageBox.Show(text);
			}
		}
	}

	private void ClipboardCopyThread()
	{
		Clipboard.SetDataObject(ImageRender(), copy: true);
	}

	private Image ImageRender()
	{
		return _masterPane.GetImage(_masterPane.IsAntiAlias);
	}

	public void CopyEmf(bool isShowMessage)
	{
		if (_masterPane != null)
		{
			Thread thread = new Thread(ClipboardCopyThreadEmf);
			thread.SetApartmentState(ApartmentState.STA);
			thread.Start();
			thread.Join();
			if (isShowMessage)
			{
				string text = _resourceManager.GetString("copied_to_clip");
				MessageBox.Show(text);
			}
		}
	}

	private void ClipboardCopyThreadEmf()
	{
		using Graphics graphics = CreateGraphics();
		IntPtr hdc = graphics.GetHdc();
		Metafile metafile = new Metafile(hdc, EmfType.EmfPlusOnly);
		graphics.ReleaseHdc(hdc);
		using (Graphics g = Graphics.FromImage(metafile))
		{
			_masterPane.Draw(g);
		}
		ClipboardMetafileHelper.PutEnhMetafileOnClipboard(base.Handle, metafile);
	}

	protected void MenuClick_SaveAs(object sender, EventArgs e)
	{
		SaveAs();
	}

	public void SaveAs()
	{
		SaveAs(null);
	}

	public string SaveAs(string DefaultFileName)
	{
		if (_masterPane != null)
		{
			_saveFileDialog.Filter = "Emf Format (*.emf)|*.emf|PNG Format (*.png)|*.png|Gif Format (*.gif)|*.gif|Jpeg Format (*.jpg)|*.jpg|Tiff Format (*.tif)|*.tif|Bmp Format (*.bmp)|*.bmp";
			if (DefaultFileName != null && DefaultFileName.Length > 0)
			{
				string text = Path.GetExtension(DefaultFileName).ToLower();
				switch (text)
				{
				case ".emf":
					_saveFileDialog.FilterIndex = 1;
					break;
				case ".png":
					_saveFileDialog.FilterIndex = 2;
					break;
				case ".gif":
					_saveFileDialog.FilterIndex = 3;
					break;
				case ".jpeg":
				case ".jpg":
					_saveFileDialog.FilterIndex = 4;
					break;
				case ".tiff":
				case ".tif":
					_saveFileDialog.FilterIndex = 5;
					break;
				case ".bmp":
					_saveFileDialog.FilterIndex = 6;
					break;
				}
				if (DefaultFileName.Length > text.Length)
				{
					_saveFileDialog.FileName = DefaultFileName;
				}
			}
			if (_saveFileDialog.ShowDialog() == DialogResult.OK)
			{
				Stream stream = _saveFileDialog.OpenFile();
				if (stream != null)
				{
					if (_saveFileDialog.FilterIndex == 1)
					{
						stream.Close();
						SaveEmfFile(_saveFileDialog.FileName);
					}
					else
					{
						ImageFormat format = ImageFormat.Png;
						switch (_saveFileDialog.FilterIndex)
						{
						case 2:
							format = ImageFormat.Png;
							break;
						case 3:
							format = ImageFormat.Gif;
							break;
						case 4:
							format = ImageFormat.Jpeg;
							break;
						case 5:
							format = ImageFormat.Tiff;
							break;
						case 6:
							format = ImageFormat.Bmp;
							break;
						}
						ImageRender().Save(stream, format);
						stream.Close();
					}
					return _saveFileDialog.FileName;
				}
			}
		}
		return "";
	}

	public void SaveAsBitmap()
	{
		if (_masterPane == null)
		{
			return;
		}
		_saveFileDialog.Filter = "PNG Format (*.png)|*.png|Gif Format (*.gif)|*.gif|Jpeg Format (*.jpg)|*.jpg|Tiff Format (*.tif)|*.tif|Bmp Format (*.bmp)|*.bmp";
		if (_saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			ImageFormat format = ImageFormat.Png;
			if (_saveFileDialog.FilterIndex == 2)
			{
				format = ImageFormat.Gif;
			}
			else if (_saveFileDialog.FilterIndex == 3)
			{
				format = ImageFormat.Jpeg;
			}
			else if (_saveFileDialog.FilterIndex == 4)
			{
				format = ImageFormat.Tiff;
			}
			else if (_saveFileDialog.FilterIndex == 5)
			{
				format = ImageFormat.Bmp;
			}
			Stream stream = _saveFileDialog.OpenFile();
			if (stream != null)
			{
				ImageRender().Save(stream, format);
				stream.Close();
			}
		}
	}

	public void SaveAsEmf()
	{
		if (_masterPane == null)
		{
			return;
		}
		_saveFileDialog.Filter = "Emf Format (*.emf)|*.emf";
		if (_saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			Stream stream = _saveFileDialog.OpenFile();
			if (stream != null)
			{
				stream.Close();
				SaveEmfFile(_saveFileDialog.FileName);
			}
		}
	}

	internal void SaveEmfFile(string fileName)
	{
		using Graphics graphics = CreateGraphics();
		IntPtr hdc = graphics.GetHdc();
		Metafile metafile = new Metafile(hdc, EmfType.EmfPlusOnly);
		using (Graphics g = Graphics.FromImage(metafile))
		{
			_masterPane.Draw(g);
		}
		ClipboardMetafileHelper.SaveEnhMetafileToFile(metafile, fileName);
		graphics.ReleaseHdc(hdc);
	}

	protected void MenuClick_ShowValues(object sender, EventArgs e)
	{
		if (sender is ToolStripMenuItem toolStripMenuItem)
		{
			IsShowPointValues = !toolStripMenuItem.Checked;
		}
	}

	protected void MenuClick_RestoreScale(object sender, EventArgs e)
	{
		if (_masterPane != null)
		{
			GraphPane primaryPane = _masterPane.FindPane(_menuClickPt);
			RestoreScale(primaryPane);
		}
	}

	public void RestoreScale(GraphPane primaryPane)
	{
		if (primaryPane == null)
		{
			return;
		}
		ZoomState oldState = new ZoomState(primaryPane, ZoomState.StateType.Zoom);
		using (Graphics g = CreateGraphics())
		{
			if (_isSynchronizeXAxes || _isSynchronizeYAxes)
			{
				foreach (GraphPane pane in _masterPane._paneList)
				{
					pane.ZoomStack.Push(pane, ZoomState.StateType.Zoom);
					ResetAutoScale(pane, g);
				}
			}
			else
			{
				primaryPane.ZoomStack.Push(primaryPane, ZoomState.StateType.Zoom);
				ResetAutoScale(primaryPane, g);
			}
			if (this.ZoomEvent != null)
			{
				this.ZoomEvent(this, oldState, new ZoomState(primaryPane, ZoomState.StateType.Zoom));
			}
		}
		Refresh();
	}

	private void ResetAutoScale(GraphPane pane, Graphics g)
	{
		pane.XAxis.ResetAutoScale(pane, g);
		pane.X2Axis.ResetAutoScale(pane, g);
		foreach (YAxis yAxis in pane.YAxisList)
		{
			yAxis.ResetAutoScale(pane, g);
		}
		foreach (Y2Axis y2Axis in pane.Y2AxisList)
		{
			y2Axis.ResetAutoScale(pane, g);
		}
	}

	protected void MenuClick_ZoomOut(object sender, EventArgs e)
	{
		if (_masterPane != null)
		{
			GraphPane primaryPane = _masterPane.FindPane(_menuClickPt);
			ZoomOut(primaryPane);
		}
	}

	public void ZoomOut(GraphPane primaryPane)
	{
		if (primaryPane == null || primaryPane.ZoomStack.IsEmpty)
		{
			return;
		}
		ZoomState.StateType type = primaryPane.ZoomStack.Top.Type;
		ZoomState oldState = new ZoomState(primaryPane, type);
		ZoomState newState = null;
		if (_isSynchronizeXAxes || _isSynchronizeYAxes)
		{
			foreach (GraphPane pane in _masterPane._paneList)
			{
				ZoomState zoomState = pane.ZoomStack.Pop(pane);
				if (pane == primaryPane)
				{
					newState = zoomState;
				}
			}
		}
		else
		{
			newState = primaryPane.ZoomStack.Pop(primaryPane);
		}
		if (this.ZoomEvent != null)
		{
			this.ZoomEvent(this, oldState, newState);
		}
		Refresh();
	}

	protected void MenuClick_ZoomOutAll(object sender, EventArgs e)
	{
		if (_masterPane != null)
		{
			GraphPane primaryPane = _masterPane.FindPane(_menuClickPt);
			ZoomOutAll(primaryPane);
		}
	}

	public void ZoomOutAll(GraphPane primaryPane)
	{
		if (primaryPane == null || primaryPane.ZoomStack.IsEmpty)
		{
			return;
		}
		ZoomState.StateType type = primaryPane.ZoomStack.Top.Type;
		ZoomState oldState = new ZoomState(primaryPane, type);
		ZoomState newState = null;
		if (_isSynchronizeXAxes || _isSynchronizeYAxes)
		{
			foreach (GraphPane pane in _masterPane._paneList)
			{
				ZoomState zoomState = pane.ZoomStack.PopAll(pane);
				if (pane == primaryPane)
				{
					newState = zoomState;
				}
			}
		}
		else
		{
			newState = primaryPane.ZoomStack.PopAll(primaryPane);
		}
		if (this.ZoomEvent != null)
		{
			this.ZoomEvent(this, oldState, newState);
		}
		Refresh();
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
		this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
		this.pointToolTip = new System.Windows.Forms.ToolTip(this.components);
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		base.SuspendLayout();
		this.vScrollBar1.Location = new System.Drawing.Point(128, 0);
		this.vScrollBar1.Name = "vScrollBar1";
		this.vScrollBar1.Size = new System.Drawing.Size(17, 128);
		this.vScrollBar1.TabIndex = 0;
		this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(vScrollBar1_Scroll);
		this.hScrollBar1.Location = new System.Drawing.Point(0, 128);
		this.hScrollBar1.Name = "hScrollBar1";
		this.hScrollBar1.Size = new System.Drawing.Size(128, 17);
		this.hScrollBar1.TabIndex = 1;
		this.hScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(hScrollBar1_Scroll);
		this.pointToolTip.AutoPopDelay = 5000;
		this.pointToolTip.InitialDelay = 100;
		this.pointToolTip.ReshowDelay = 0;
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
		this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(contextMenuStrip1_Opening);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 13f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ContextMenuStrip = this.contextMenuStrip1;
		base.Controls.Add(this.hScrollBar1);
		base.Controls.Add(this.vScrollBar1);
		base.Name = "ZedGraphControl";
		base.Resize += new System.EventHandler(ZedGraphControl_ReSize);
		base.KeyUp += new System.Windows.Forms.KeyEventHandler(ZedGraphControl_KeyUp);
		base.KeyDown += new System.Windows.Forms.KeyEventHandler(ZedGraphControl_KeyDown);
		base.MouseWheel += new System.Windows.Forms.MouseEventHandler(ZedGraphControl_MouseWheel);
		base.ResumeLayout(false);
	}
}
