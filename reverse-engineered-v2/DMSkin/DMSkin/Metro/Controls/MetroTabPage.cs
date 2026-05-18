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
using nH1QvmhGjfEEHKlRNC;

namespace DMSkin.Metro.Controls;

[Designer(typeof(eF453ZvnW87yRpnmuX))]
[ToolboxItem(false)]
public class MetroTabPage : TabPage, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> niNbNKdOIP;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> IWcbmDhKJm;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> tIKbf5K1T6;

	private MetroColorStyle kRJbypCB4P;

	private MetroThemeStyle I72bAB1xP0;

	private MetroStyleManager q6bbef5Yy5;

	private bool HOAbOXRmUM;

	private bool LwFbwry3yE;

	private bool CaMbPD92BO;

	private MetroScrollBar yh1b1VtOoH;

	private MetroScrollBar UwHb6f7Bap;

	private bool WTAbklhXGo;

	private bool XBXbgZCewU;

	[Category("Metro Appearance")]
	[DefaultValue(MetroColorStyle.Default)]
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

	[DefaultValue(MetroThemeStyle.Default)]
	[Category("Metro Appearance")]
	[Description("主题颜色")]
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

	[Category("Metro Appearance")]
	[DefaultValue(false)]
	[Description("使用用户自定义的字体颜色")]
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

	[Category("Metro Appearance")]
	[Description("使用用户自定义的全局颜色")]
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

	[DefaultValue(false)]
	[Category("Metro Appearance")]
	public bool HorizontalScrollbar
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
	public int HorizontalScrollbarSize
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
	public bool HorizontalScrollbarBarColor
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
	public bool HorizontalScrollbarDM_HighlightOnWheel
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
	public bool VerticalScrollbar
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
	public int VerticalScrollbarSize
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
	public bool VerticalScrollbarBarColor
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
	public bool VerticalScrollbarDM_HighlightOnWheel
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
	public MetroTabPage()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void dcbbdfqG4o(object P_0, ScrollEventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void oUrb358Vq4(object P_0, ScrollEventArgs P_1)
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
	private void cphbKvBT9y()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroTabPage()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		u7FrKRr6v3jN6OueSoO();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool PcjbPd97CESDf4qNelI(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool NFsCWs9hdbXgJo0d8OS()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool LEW1mH9cixdES8KNssB()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool US5sQO9PeAGJ5M6qtxL(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle xSQiOO9v3X8jA5MnPxr(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle kYvP1n9SadLATZ7krC1(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PyFTCg9a5qw1yJIg67l(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int JReDTB9EjNx4rhRtoh7(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Ii8vm89GLj8TRR4CH2g(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool G0n3ce9kMwogh3JJBSa(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DjCBWE9LMemK3441gom(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool PbVJUu9zXtXGAYG7dYv(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hF6qoXrlqFUEZkEWP5H(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool BtxPFnrpAMpxljqpfhR(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nBdjNdr50ClahHc8CIf(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CxXkG2rAnwuNpKVNcQm()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dm2uT8ro3FVEg58MqgS(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object rTXZjarWA2lHEdPG265(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aMxT7jrUKJGKZh6A2W8(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wjlK6EriseeoPH2ysKw(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int JAZtyKrmTih9eua9VCX(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int a5qj1prQttgIjABBPrM(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nUfp7qrRAsIn1S8DJq9(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color yRRkJ3rNL2MZxQi0k3V(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color a7Aj7Ir19Hd2UfHOZsY(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object aQRagNrKr0q9Jnj5fu9(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object Emsjctr8Iw4r36iFNKq(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gMb3LwruYNfc4n4vdv8(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hgtxoHrjh6DB4shbQZa(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ff9so7rwbNAC1U7kS62(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lUpEbsrgZTQMXXeBfCt(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mw1C3PrJuvtR2WhEjL1(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TmKyVKry31sjevvO0lE(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gEm41rrDBdZBdhG5yPo(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void To0xrZrYdcZdxNeg9Qo(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CyaqTpreyjIu0n905kK(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ddafgErFJuINBUtEAFH(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool geRxUers4BIgYQPDVXX(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int tHSw3srM9ZqdUVQZC7q(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mnQCAErC1ZsL4wvgXlo(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int yxU7N8r0JXT3Fx3ICnf(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void EZZck3rBRra573hoYlq(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int veYsJ2rx8U4MCYtTRve(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DDjIQRrTtkLSoavV7AD(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int P3XUGqrt6W1tJGCYDgr(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kwZekBrX8qUrHxNSg75(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object LfPoEerZYXFNPQbYIED(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JAgJq0r4aVlwcjQo8My(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vDh0pNr9B40Qb5mjotc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int TnQT2drrK6V1QtF69Xr(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GNmAqwr3fbZPKki1yJg(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr WonederVTwdYEWEDOFb(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle K0ZafXrIut1IEdD7j2v(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int srxMmcr201G2ZxDJevo(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aEVcSsrOBZtIEJMogPI(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void G5QLEsrf7wMexkIHtnf(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int RpOh4rrqtplwoVpCuWK(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cNvdQnrbgQr1Ffnvi14(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void u7FrKRr6v3jN6OueSoO()
	{
	}
}
