using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(Panel))]
public class MetroPanel : Panel, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> VqeLJ1Vfob;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> JJmL4yMrnl;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> RLnL590vkV;

	private MetroColorStyle DdyLWks0a3;

	private MetroThemeStyle wrxLn6OEFo;

	private MetroStyleManager N8XLi3VOWv;

	private bool Qy3LYHFao2;

	private bool vHOLhdrfwv;

	private bool nAGLcjHxde;

	public MetroScrollBar verticalScrollbar;

	public MetroScrollBar horizontalScrollbar;

	private bool D4eL8WiksU;

	private bool RwiLM5Zo7x;

	[DefaultValue(MetroColorStyle.Default)]
	[Category("Metro Appearance")]
	public MetroColorStyle Style
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroColorStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Description("主题颜色")]
	[DefaultValue(MetroThemeStyle.Default)]
	[Category("Metro Appearance")]
	public MetroThemeStyle Theme
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroThemeStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	public MetroStyleManager StyleManager
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

	[Category("Metro Appearance")]
	[DefaultValue(false)]
	[Description("使用用户自定义的背景色")]
	public bool DM_UseCustomBackColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Description("使用用户自定义的字体颜色")]
	[DefaultValue(false)]
	[Category("Metro Appearance")]
	public bool DM_UseCustomForeColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Description("使用用户自定义的全局颜色")]
	[Category("Metro Appearance")]
	[DefaultValue(false)]
	public bool DM_UseStyleColors
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Behaviour")]
	[DefaultValue(false)]
	[Browsable(false)]
	public bool DM_UseSelectable
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	public Color DM_ThumbColor
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

	public Color DM_ThumbNormalColor
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

	public bool DM_UseBarColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(false)]
	public bool DM_HorizontalScrollbar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public int DM_HorizontalScrollbarSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return 0;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public bool DM_HorizontalScrollbarBarColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public bool DM_HorizontalScrollbarDM_HighlightOnWheel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(false)]
	public bool DM_VerticalScrollbar
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public int DM_VerticalScrollbarSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return 0;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public bool DM_VerticalScrollbarBarColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public bool DM_VerticalScrollbarDM_HighlightOnWheel
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public new bool AutoScroll
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return true;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public event EventHandler<MetroPaintEventArgs> CustomPaintBackground
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

	[Category("Metro Appearance")]
	public event EventHandler<MetroPaintEventArgs> CustomPaint
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

	[Category("Metro Appearance")]
	public event EventHandler<MetroPaintEventArgs> CustomPaintForeground
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
	protected virtual void OnCustomPaintBackground(MetroPaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnCustomPaint(MetroPaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnCustomPaintForeground(MetroPaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroPanel()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void LJtLxCyiLQ(object P_0, ScrollEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void MvlLu7dRSH(object P_0, ScrollEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaintBackground(PaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnPaintForeground(PaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseWheel(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	protected override void WndProc(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void NwwLvkYmA5()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroPanel()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		yEjGNJTItdbdkZH06xP();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool koFYguxOsbL78xOLShy(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool PH2gXbxIbsCx4Gk5nOK()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool fvIgYLx2YWhwupnsaH6()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool qSW3d7xfEAsjZUrxajJ(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle DrZFEwxqRT6WNOJc9sf(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle hkll5axbynEjjEKfBsc(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NKyac9x6oADiCiuexmS(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color xiW1P3xnHXdIDPS0OCA(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OOCf0AxHXD5im9GlsLw(object P_0, Color value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color H2CPBWxdc4fh1CBcV0K(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gmv1VJxh8O39A4UOAKT(object P_0, Color value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool wfBlq4xccg8b0accXaL(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void F3gMYBx7BEEML22B3Me(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int Xx30oIxP4iLR7hhUrdq(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yF3ySAxvOpVJUe2P3pc(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IZ7s3yxSVFxOHs5pEcT(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HeZJ89xam2eJreU9EEh(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool d4UYqaxEWFbg145oWJ1(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fbiW3cxGeRltPEDPUHy(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void I5XxHnxkBMM8VR1i7Vo()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SHj2HyxL3ely5ZrcBtK(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object aVqq2cxzEjah6yAIRsY(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xoZ4pVTltWRpxS9xP2w(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Nbv6hPTpNO1kDWH4OwD(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void l3330CT53GQFMhuy8Z1(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int ESFfW9TAFA9aAnqbmHO(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int YM58VgToZJleItf0oiS(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jArj6XTW48pfu86wyq2(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color q3hPxkTUTbFcXV8ytNU(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color f8bSX5TinhBRlhDbSQO(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WS4R8TTmwkHI4mCGlLA(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object HaHsIYTQYU3vhP8eDKp(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jRU2cyTRJ6N28Rn9rlb(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void c4Me8wTNPhhEsEZ2Lq0(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KhZyhZT1jQqyABC81KC(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Rln2RYTKmcK1974thLq(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xnV8MeT8aN0dhLWMKr6(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sTZ5cyTurwL8GhabPno(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vwLEQPTjxNrI85I8V0f(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object XDmWKSTw2mQrQbeykCh(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool e00PXBTgULWXttVtoby(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int l0sURwTJFbKU4NxYk4O(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qyhXrgTyKvFFWP5COsi(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int arDdU9TDbNwie9e7v5B(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PI37PMTYXYmooq2kqf4(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int mDKJMUTeWer3XOqUHWH(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tBDZyDTFepBQEniI69O(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int WyTALnTskWqnhlraKCb(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Xfa0gmTMvQ0RyBH11Ui(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object xDhNoOTCHE55kxuWNPQ(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ssiCBsT0vgCDBApc3qo(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iSjffpTBPFU40K2NyCb(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int mc3XXZTxtCS5ENKmxgU(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int MVr3yXTTQM3EbUBdnyo(int P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yovNJ5TtP8WJ9vligpP(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr dZgFAJTXNIj7e2GgZIC(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle S11yVUTZ0ubJhIhdVVE(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int N5DfUMT4plBNpHqH8tS(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vUgbN5T9n5Vk4LvSvbA(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int mgDF86TrHySHR0Iq8bd(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wlFfCMT3qsHa22BRaxo(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TRKIOWTVDSPWdXFaklc(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yEjGNJTItdbdkZH06xP()
	{
	}
}
