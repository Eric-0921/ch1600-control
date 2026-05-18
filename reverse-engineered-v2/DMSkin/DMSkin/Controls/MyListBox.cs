using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using QICRVTTCyDiJuV7eLP6;
using QqMs8dIaBNwKSNPGRJc;

namespace DMSkin.Controls;

public class MyListBox : Control
{
	public delegate void ChatListEventHandler(object sender, MyListBoxtEventArgs e);

	public class MyListBoxItemCollection : IList, ICollection, IEnumerable
	{
		private int XWd1RyXLWa;

		private MyListBoxItem[] gwF1Bns6bi;

		private MyListBox gpn1SwVgGD;

		public int Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return 0;
			}
		}

		public MyListBoxItem this[int index]
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		bool IList.IsFixedSize
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return true;
			}
		}

		bool IList.IsReadOnly
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return true;
			}
		}

		object IList.this[int index]
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			set
			{
			}
		}

		int ICollection.Count
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return 0;
			}
		}

		bool ICollection.IsSynchronized
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return true;
			}
		}

		object ICollection.SyncRoot
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MyListBoxItemCollection(MyListBox owner)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void cX21t4QCFQ(int P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public int IndexOf(MyListBoxItem item)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Add(MyListBoxItem item)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void AddRange(MyListBoxItem[] items)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Remove(MyListBoxItem item)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void RemoveAt(int index)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Clear()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void Insert(int index, MyListBoxItem item)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public bool Contains(MyListBoxItem item)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public void CopyTo(Array array, int index)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		int IList.Add(object value)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IList.Clear()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		bool IList.Contains(object value)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		int IList.IndexOf(object value)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IList.Insert(int index, object value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IList.Remove(object value)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void IList.RemoveAt(int index)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		void ICollection.CopyTo(Array array, int index)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		IEnumerator IEnumerable.GetEnumerator()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static MyListBoxItemCollection()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			qmKpqRpQXAOWfH7r99be();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void E1N7HmpQCdLShalV8KOb()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void QXOT2IpQ0xFLqkQjeY1k(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool njSrDfpQsEaNtnpjMVVR()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Aj8f2YpQMXH3QicwUf7R()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int aWKRnkpQBnKbNeZEcBs4(int P_0, int P_1)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qx9fjxpQxnMdiu6hf4Cu(object P_0, object P_1, int P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void BmRDtKpQT7oY0NrxRLh4(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void o7fk7mpQtv0kXjq3AKIe(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void qmKpqRpQXAOWfH7r99be()
		{
		}
	}

	private MyListBoxItemIcon HTYfeZjde0;

	private MyListBoxItemCollection AIUfOk8O34;

	private MyListBoxSubItem C2cfwLECeb;

	private Color oJjfPZx3MF;

	private Color NA8f1yx6co;

	private Color gwlf6Gifmi;

	private Color gVGfk3vBdt;

	private Color qHtfgilbd1;

	private Color MwjfDjPvWG;

	[CompilerGenerated]
	private ChatListEventHandler GoZfrSJMwN;

	[CompilerGenerated]
	private ChatListEventHandler E2Ef9Y5bml;

	[CompilerGenerated]
	private ChatListEventHandler oehfZwXIss;

	private UVbppqIFXXaB2VWF9qn pBofCTdaYh;

	protected Point m_ptMousePos;

	protected MyListBoxItem m_mouseOnItem;

	protected bool m_bOnMouseEnterHeaded;

	protected MyListBoxSubItem m_mouseOnSubItem;

	private IContainer gfpftq8iV9;

	[DefaultValue(MyListBoxItemIcon.Small)]
	public MyListBoxItemIcon IconSizeMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MyListBoxItemIcon)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public MyListBoxItemCollection Items
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[Browsable(false)]
	public MyListBoxSubItem SelectSubItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[Description("滚动条的背景颜色")]
	[DefaultValue(typeof(Color), "LightYellow")]
	[Category("ControlColor")]
	public Color ScrollBackColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("ControlColor")]
	[Description("滚动条滑块默认情况下的颜色")]
	[DefaultValue(typeof(Color), "Gray")]
	public Color ScrollSliderDefaultColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("ControlColor")]
	[Description("滚动条滑块被点击或者鼠标移动到上面时候的颜色")]
	[DefaultValue(typeof(Color), "DarkGray")]
	public Color ScrollSliderDownColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(Color), "Gray")]
	[Category("ControlColor")]
	[Description("滚动条箭头的背景颜色")]
	public Color ScrollArrowBackColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(Color), "White")]
	[Category("ControlColor")]
	[Description("滚动条箭头的颜色")]
	public Color ScrollArrowColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("ControlColor")]
	[DefaultValue(typeof(Color), "DarkGray")]
	[Description("列表项上面的箭头的颜色")]
	public Color ArrowColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(Color), "White")]
	[Description("列表项的背景色")]
	[Category("ControlColor")]
	public Color ItemColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(Color), "White")]
	[Description("列表子项的背景色")]
	[Category("ControlColor")]
	public Color SubItemColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Description("当鼠标移动到列表项上面的颜色")]
	[Category("ControlColor")]
	[DefaultValue(typeof(Color), "LightYellow")]
	public Color ItemMouseOnColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(Color), "LightBlue")]
	[Description("当鼠标移动到子项上面的颜色")]
	[Category("ControlColor")]
	public Color SubItemMouseOnColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(Color), "Wheat")]
	[Category("ControlColor")]
	[Description("当列表子项被选中时候的颜色")]
	public Color SubItemSelectColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	public event ChatListEventHandler DoubleClickSubItem
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
		}
	}

	public event ChatListEventHandler MouseEnterHead
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
		}
	}

	public event ChatListEventHandler MouseLeaveHead
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		add
		{
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		[CompilerGenerated]
		remove
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MyListBox()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnDoubleClickSubItem(MyListBoxtEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnMouseEnterHead(MyListBoxtEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnMouseLeaveHead(MyListBoxtEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCreateControl()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseWheel(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseDown(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseUp(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseMove(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseLeave(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnClick(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnDoubleClick(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DrawItem(Graphics g, MyListBoxItem item, Rectangle rectItem, SolidBrush sb)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DrawSubItem(Graphics g, MyListBoxSubItem subItem, ref Rectangle rectSubItem, SolidBrush sb)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DrawHeadImage(Graphics g, MyListBoxSubItem subItem, Rectangle rectSubItem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DrawLargeSubItem(Graphics g, MyListBoxSubItem subItem, Rectangle rectSubItem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void DrawSmallSubItem(Graphics g, MyListBoxSubItem subItem, Rectangle rectSubItem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VcZfmBB16e()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EFfff5SyKy()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MyListBoxSubItem[] GetSubItemsById(int userId)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MyListBoxSubItem[] GetSubItemsByNicName(string nicName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MyListBoxSubItem[] GetSubItemsByDisplayName(string displayName)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cFCfyLbXJF()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[CompilerGenerated]
	private void E5VfAcH4Xr()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MyListBox()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		C7hReKGY78fm1p3XpCo();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void v5wAYVaWQ1Q5LkxPQjf()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NAQf4xaUUU3MnaLpfX4(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Gj3AFnai9ZLwl1JlX2d(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color kJ0SDcam3p7QFbADNLY()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sGAW6haQ9QGVPkDqqTd(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color UguMiiaR6tfr9rk8JhF()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void saaKMJaNLjPI1nWpaf8(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color yEYnYVa1dYjjRxItoOl(int P_0, Color P_1)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color qarkZkaKsJF6m2ANgM2()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Nv9qZ6a8JtMPnfJO79F()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color nMY2cjauNHR4wDLPaad()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ads8xwajKZNsN4wbrkr()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QE0bYsawMWrPwjQqefi(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool vfA05saAk2IEiLpm81y()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool mi3BEgaokxP5Vcm7Wto()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Bw2jVmagQo6iD0YFIkQ(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color cB831faJlD5cwMVqHDw(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void W756smayQBwZkl6EmUU(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color JymB8HaDGjNCxsseX7x(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HnnmljaY3ONVUErp66v(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color emUgLTaeE3Y2So8XFvd(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JnhBrgaFTa4gCZmfXw9(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ayUVciasY7WJn9xWVVw(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CflNiVaMWvAeTfS1mKU(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color pfdoVRaCjhGFsYmrCCo(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VTRTc5a0ZjNmMAlqYxT(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool VtZWXKaBjywCfeRvQVU(Color P_0, Color P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object scAjHZax7L1W3GavRiR(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ypgrlfaTyEHI5GvHiDZ(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dVPZEVatxPasQDVxboe(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NaIP4jaXwarg8D94NZy(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void o3A2oJaZkn0kpQgd1MH(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KRZl34a4AmGBwEbq6YK(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object cTNwjua9dxBvIPYhiKV(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int u6fJ7WarjTIAHtusK14(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vCW5EMa3YuiZGridFmA(object P_0, float P_1, float P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GY1ORGaVKfHCQ5GvRte(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int igdsU9aI0jmIcMrfQKl(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object TRbmU8a2pg75gUDDjNZ(object P_0, int index)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void WqO8XWaOsc8IVpyK8BO(object P_0, object P_1, object P_2, Rectangle rectItem, object P_4)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool NMbS9aaf9rmQwwDB7mc(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object RIpNIMaq2JfNR1CY4N8(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int OY6fSoabj8sYW0JQU7e(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object TDkHM9a61uyGYxq0fmG(object P_0, int index)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void USN5wbann9cFUHkDhBN(object P_0, Rectangle value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iHukGWaHJxEDmH01PXB(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Btsar2advE9IJDkmK1I(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool OtKPKZahftZNVamaTBD(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void WRG9lvaccBCqZJpBxsG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DTKpQja7fKc07r98e3r(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void v3ciVBaP2MNMDsChyBk(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int mgIM9YavqBYY8A0IPte(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void L3VaUEaSixM6LHgSSsO(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PEG9IyaaCtEbHMwY53W(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons obOX52aEs3RtcPftIlU(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle vImIWUaGig2N0JLF1VH(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point Jqq5ZeakOcMLvkhQCJv(object P_0)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void odL7LkaLbGE6HgGi7uk(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int YOxCuLazkNKjQofv56E(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PYy5gFElREgJNhDkTkV(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool W2B1r7EpZVuUEFaTwbd(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rk5u5RE5K7bolf2nAsl(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void a6OFLBEAlL2iEdeeMVH(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool n0F5SxEolPSN1W5nTe9(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lbn1JUEW5diMyMGgd4W(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle XXpc0ZEUeBYtcKHJYGs(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TrDZJqEiDgSli8VfY9n(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle EkWGIZEm041m3PLQDUv(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xwO2N9EQUKtSGUc2pV1(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle LimAueERXvEKWEipixN(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void K6e8aIEN6urj5BLtMKk(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GI3C24E1stKvGhnjcTw(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle M3ZP2sEK4BWsRr1r5sw(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle j7oXUHE8c7HXXjUKTC3(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle T4anATEuSZbxEPGndd8(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TKjdSEEj122kftVicC9(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yKXTjqEwMf5XwPZhuhN(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void smRrC4EgmvUIag2JCJA(object P_0, Rectangle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NJUfCsEJgQsIb2R7Nwa(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void y7s8OBEyDQFq5eFCDIe(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sdkep5EDaLaqHXd3RHs(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object FRlKpGEYqmhbPS1BsRx(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object MB0wTWEeP3lLWRbMfdh(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool UBvWdIEFJmf4N1SupNW(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void uEyq1DEse3u5a55oZi9(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hmq9NGEMlAj5huNLY5u(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kKpP51ECCK2XiAtOdAN(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QU3ZWdE0U7N4nf6Ou01(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point JLu8RWEBjsvmvLiB7xp()
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point GowiG3Exqs5nDRA8OS5(object P_0, Point P_1)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ru0MFWETtrCqQTIHAmi(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qfLfgWEtJ9niuevWqno(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void k5DNiIEXeFUjjnnLWsB(object P_0, StringAlignment P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qujun5EZG51kK3AaGXW(object P_0, float P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iDdGnfE4d5a3wdLKqCQ(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gN6AybE9rpCaXnNE9iA(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Ie3yOcEr0FO3RY68tlx(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int K9Df0BE3BVHf6ApwHy8(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ELr6h0EVCq605H9Ljye(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WOaRMLEIx2qTTSw1Q3I(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object gp67C1E2a0ZTSO8ueE4(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color fREhoNEOOJvNam4vb5x(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rqL7GtEfPna55ClLPGV(object P_0, StringAlignment P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object RH4LE8Eqpq1iC1cpyDu(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static RectangleF vnOGenEbVHCYmYtnNQt(Rectangle P_0)
	{
		return (RectangleF)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tUT2hyE630rv2kP8ICn(object P_0, object P_1, object P_2, object P_3, RectangleF P_4, object P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object Mgve3LEng4xOELNgVxk(object P_0, object P_1, object P_2)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qRSxPHEHOSqUkDauwN6(object P_0, object P_1, object P_2, Rectangle rectSubItem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void eQTx5iEdbnsAk7f1qTC(object P_0, object P_1, object P_2, Rectangle rectSubItem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Xh0bIgEhfaQALk3cWBy(object P_0, Rectangle value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void c4P739EchSMTcfdDUZd(object P_0, object P_1, object P_2, Rectangle rectSubItem)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ldWPBeE7IsluRI0XFxM(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ndPyjMEPPH4sOLpFaB4(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wQxQHDEvvTrbxwhF8Rk(object P_0, Rectangle value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object J8JmJdESYKfBHF8Wvym(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object gA6qlvEa4tVp51gvPtZ()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QX29UIEEOJ8oosKvibr(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MyListBoxSubItem.UserStatus woEy2hEGYD5r4MsaDnr(object P_0)
	{
		return (MyListBoxSubItem.UserStatus)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ltmqYKEkRCu0rKBYHQt(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iGMrH7ELu6DMsAEGc60(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object kS2dhFEzf7WqG3yTU9Y()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sDnenuGllrlrhvdxQYb(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object a9Uf5ZGpTOq9yqfSZbr()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object TPj7mkG5h2VEPbTRl5m(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size i6Rn6GGAy33SOPsEM6l(object P_0, object P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NPfhQPGoxtk9EnT2idO(object P_0, object P_1, object P_2, object P_3, float P_4, float P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object IXwGKtGW8Ccm3d9NkRm(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object zqXrnKGUYYcmlSYnfXA(object P_0, object P_1, object P_2)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object D3IOh3Gi2tFXO0bKbfX()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object tZ9IIgGmrs6oCvEag9o(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int s5XWYhGQPjCIAQ3Vj1Z(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RwQsRVGRhYxIKMxA6ar(object P_0, StringFormatFlags P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool c4Of6rGNE4cNtYjw7qL(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int kmPclWG1t3LUI7annFS(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object xd3VJZGKRnZqn7l7mob(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool FtEda0G8BvJkA4a14YI(object P_0, object P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nFp4YJGuYXK8a09CLSx(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KIVES1Gjy1skeE56GhG(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FgLd5dGw3YcnLChu4Nh(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int UsqdTPGg19r1AiYB3AB(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LQY6FTGJfKJiPW1Q32v(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TwvxJiGyA16uBKPNNHB(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void x6j2bCGDAB222kGxG6O(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void C7hReKGY78fm1p3XpCo()
	{
	}
}
