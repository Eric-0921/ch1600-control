using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;
using kiZOoEEfBl7hCxy1aq;
using wTZxo5ZQLlLpJ1fFJI;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(CheckBox))]
[Designer(typeof(eB4o5lirRu44p3JwOd))]
public class MetroToggle : CheckBox, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> yAvEeioTip;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> N1NEOYsQiw;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> PyZEwZL0XL;

	private MetroColorStyle aP9EPjTVtK;

	private MetroThemeStyle SPLE1E3f5K;

	private MetroStyleManager aaBE61L3LB;

	private bool WXWEkEKgB6;

	private bool rNEEgYisUB;

	private bool HnaEDE3m2C;

	private bool Gv8ErbwkNF;

	private xdly2EVP1ItSpMQg3i YXuE9jDwJg;

	private MetroLinkSize yVKEZyKhjx;

	private MetroLinkWeight pDeECjKnsb;

	private bool ceHEtVM6qB;

	private bool NilERY0EHG;

	private bool Sv6EBxg1KC;

	private bool wqLES8jvjJ;

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

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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
	[Description("使用用户自定义的背景色")]
	[DefaultValue(false)]
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
	[Browsable(false)]
	[DefaultValue(false)]
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
	public bool DM_DisplayFocus
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
	[DefaultValue(MetroLinkSize.Small)]
	public MetroLinkSize DM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroLinkSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(MetroLinkWeight.Regular)]
	[Category("Metro Appearance")]
	public MetroLinkWeight DM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroLinkWeight)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(true)]
	public bool DisplayStatus
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

	[Browsable(false)]
	public override Font Font
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

	[Browsable(false)]
	public override Color ForeColor
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

	[Browsable(false)]
	public override string Text
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
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
	public MetroToggle()
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
	protected override void OnGotFocus(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLostFocus(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnter(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLeave(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnKeyDown(KeyEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnKeyUp(KeyEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseEnter(EventArgs e)
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
	protected override void OnMouseLeave(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCheckedChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Size GetPreferredSize(Size proposedSize)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroToggle()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		AGPL502X0wvruqBHsR9();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool F2VnceI4wWPq2XVesWt(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ElbRRDIXLTqpXkw2VWj()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool eywwL3IZQhy09srteDm()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool qDXd5lI99x3qF1GQVlS(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle wJKR3tIrpvcOB3M1LkO(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle gsg7nkI3SYJ15neBcNi(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xr6FrWIV3Zilo4g9C7q(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object NIPYCeIIUxfHCX3PNYB(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void k1qEvTI2Qix4lY1Z5om(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Q0glbiIO59oCfDL6DgU(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void uCalb1IfyLyiEn6E3R5(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool FG6AZkIq4C9rkTppBTn(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object yE5veQIblgIOjBEwwSx(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NMgrL6I6xDSZnxgOHmx()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GUHM91InevtAl3s8WkS(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CItwslIHtMB6sl8PvE4(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color BHHpCNId1yfmhS4Z90T(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color YVHFjAIhFDZEkw4t8VH(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WstWtbIcdalSh85onNp(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void s94JW6I7QKOLW440DJX(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void U8S3tmIPnD7iE2omZfg(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vXhXD2IvrLqvO6diXnP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TGCR6jISQFdvJ6W6Sr7(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IIAlyGIaiv8MDTdUqKA(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pIJYTLIEZ89r3KxOOTw(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HF4ThjIGECA5XcrZ67v(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool KreMj5IkjJ2ZvfCphgP(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color u4PjcWILq5GUxt5W4VB(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color k1hDdOIz50oXX0c8G4R(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color DlArcO2lMuTOPxyw6Rm(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color rJ7lxU2pDFwC9ZOUFuc(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color RssYfV25Ic0SKtQE8Oj(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color TrYREL2ApFZbbhJrp7P(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color nUZK502oS767WFVU2bJ(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color vd8A752WELpEp8EAjRX(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color nOor5B2UhBx2uJkn5DD(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle O0iNdS2iD2ZBxSSa4Zi(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ShYsHA2mCeDjUwxuIh6(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void D5HsGg2QxNtEZua2RhL(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void w9LWrI2R8qW83HDPIOW(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int L3ovME2NKLDOcRxdOyQ(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object fDvp4321CmZwSw6xMJ5(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object pw8C1w2KgJuTtS4xZ3s(MetroLinkSize linkSize, MetroLinkWeight linkWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ContentAlignment Ib2Iso28Eds8yjjgroJ(object P_0)
	{
		return (ContentAlignment)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags S1V2mF2uuGkcdU7UyfQ(ContentAlignment textAlign)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gdrLmh2j3grqF2P4VVB(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void stIHWl2w75tWqvlTx3A(object P_0, Rectangle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void e563XS2geDnmtHeY30P(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void efHAIp2JwxKpa5ArvUc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nwU0Xm2yp2pvpudwdsL(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FxQsHs2DNX6SV3WyArc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Keys wOwsSF2Y6IGAMavqaGt(object P_0)
	{
		return (Keys)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QW6Xkv2eyKVSowWJhA5(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YB7C9R2Fw3DWx55a6Wj(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ssbwxd2sVn8uyLsX9RR(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons g5Iv202MZTaf5kRmpA0(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SB8ulw2C5dbYX7CliJI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Gmlnf620MGm5iEgrlRF(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GqmfHh2BxRUnQiJTFoD(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IxkEoZ2xb91wsTABN7C(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ggXhGg2TPhQOGeUvl1W(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size KHHAlO2t8Q94RE30jDq(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AGPL502X0wvruqBHsR9()
	{
	}
}
