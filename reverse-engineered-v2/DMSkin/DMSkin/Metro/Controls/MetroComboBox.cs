using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(ComboBox))]
public class MetroComboBox : ComboBox, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> UgeocvDNTk;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> hqmo8BgAXx;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> RjAoMbwMfG;

	private MetroColorStyle hXNoQbOaqW;

	private MetroThemeStyle UkMoGZWdR8;

	private MetroStyleManager aAAozdBa4I;

	private bool CyksqVJOI5;

	private bool Vqqsjmjksi;

	private bool v1Ls7bQQS3;

	private bool mTrsFdDYrb;

	private MetroComboBoxSize yXAsUYbK0a;

	private MetroComboBoxWeight M6Cs2m9adB;

	private string YDlspF7QEe;

	private bool DK3soJejK0;

	private bool Fp5sshMt2Z;

	private bool B0EsLqOXJa;

	private bool XayslZCyVR;

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
	[Description("主题颜色")]
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

	[Description("使用用户自定义的背景色")]
	[Category("Metro Appearance")]
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

	[DefaultValue(false)]
	[Description("使用用户自定义的全局颜色")]
	[Category("Metro Appearance")]
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

	[DefaultValue(false)]
	[Browsable(false)]
	[Category("Metro Behaviour")]
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

	[Browsable(false)]
	[DefaultValue(DrawMode.OwnerDrawFixed)]
	public new DrawMode DrawMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (DrawMode)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Browsable(false)]
	[DefaultValue(ComboBoxStyle.DropDownList)]
	public new ComboBoxStyle DropDownStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (ComboBoxStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(MetroComboBoxSize.Medium)]
	public MetroComboBoxSize DM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroComboBoxSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(MetroComboBoxWeight.Regular)]
	public MetroComboBoxWeight DM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroComboBoxWeight)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[EditorBrowsable(EditorBrowsableState.Always)]
	[DefaultValue("")]
	[Category("Metro Appearance")]
	[Browsable(true)]
	public string PromptText
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
	public MetroComboBox()
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
	protected override void OnDrawItem(DrawItemEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void p3woYLg3Ej()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B3TohqcZy7(Graphics P_0)
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
	public override Size GetPreferredSize(Size proposedSize)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSelectedIndexChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void WndProc(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroComboBox()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		Ht05PPsMvCsTyMJZVsM();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool UWkvwMFNGVmZdp4yjUc(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool pw8LkTFQKtrF8AuEOSC()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool uf5LiCFRCEWSL72Cedk()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool JKry3KF1MQwCQFoZAxO(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle gqPnFGFKvitxoLSrhDw(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle tb1WAFF8RhS6XEOOLxn(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vbr6QaFuLpJ0x0b15dK(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DwIJ96FjEUyF57D1ZYx(object P_0, DrawMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DyF5eSFw26NOQgS4yQI(object P_0, ComboBoxStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object xvkuPcFgUFd2JLvkywc(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JStOyKFJkvgTebYGhho(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object T1ib5uFy0IthvMJLw5k(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qHJCfwFDxG7k4qpy4WT(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vyBqjeFYT94DTBG9GGy()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void WfauxkFe8pPViCIs8Gg(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int PEcY9YFFN9i47p3adOC(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color fwxoLDFs9gI1LPdnTlc(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color arGForFMKP91XTZQW6K(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object tlw1QIFCB1u02TwaWye(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object vBE7YeF0peALmVJaxEU(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void C9HBWUFBoHDmFELJoX7(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KG1rQ2FxYSxA9Ep9Irf(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xVRkP0FTtdSWfZlfPpw(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PxYNT1FtCCBeMm7SiiH(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PsuQ40FXcQA8hKePTgc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tkH9OUFZhbclPSXWGiE(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size TS2sYJF4O20CEU5s9Yo(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vndljgF9Or19aG14D92(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool mRdVBXFrjOIK4PgG82H(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Khv6rhF3Ht1YrossMJo(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color rKmOGgFVy2aacw9F96G(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color KlB3FdFIwoB8EvMHJgC(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color VHAoTjF2UauPgJROxYv(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color k0XLSJFOUbCqUyEcBKH(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color KP5MmBFfOP3qp20colT(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color W44iIvFqNu8byBM1fd7(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color QSOxAcFbCYRpwLN2fkE(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int TGdAn5F6q3QGhy21Hmx(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int FRXbfEFn6SKPR9dG8uF(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cHEeHAFHyLmCCInX1nJ(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pPwBokFdR6rFB5pqTN0(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TCxDutFhR771lFK4cfX(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ULGEAVFcSWlBwEOksJA(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object UtmxGBF7geGoAKay4Dc(MetroComboBoxSize linkSize, MetroComboBoxWeight linkWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OEOsc1FPYUHR1ZN88FI(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kq0G8BFvysUirQD9W3t(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle vrZtv9FSZFfq2qgLNte(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void H0v6SlFa1aGauRA3egB(object P_0, Rectangle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int e8WYjWFEM0tJiOXxjuI(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static DrawItemState AODVUnFGJXiFQS6LJnd(object P_0)
	{
		return (DrawItemState)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WeMyIgFk9Yv2xUyqF0N(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle sHs5uTFLYq7xruv6nn8(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lUJfcVFztW6Wi1sAYDm(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color htsacuslSDCWI4sdf8p(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color c13icAspUI105CmXVsm(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Ano5fTs5NbHVuKmIQxN(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object wFDxfcsA3wsCTqnQf5o(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object zedq7xsoR6Zhuv3C203(object P_0, int P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WCq28msWgXf9xlsq93P(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Fm3RgnsUVCAXExSj8AK(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object pRm93osieGDc6JWqyEY(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color aLIxWcsmMMSVu3ig7gO()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void obO7nSsQ5JcGUvjLIPC(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, Color P_5, TextFormatFlags P_6)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pbnkeIsRJFknhOFNKqK(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void UcTJsQsNX9TDQRxWWwS(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vb5LW4s1RifvjYcENib(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void p6bMV0sKNidoyolrGtw(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Keys ktlohxs8fZETjqKpCte(object P_0)
	{
		return (Keys)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fdoLN1suiKCorhjtWwZ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ICoYccsjsinKF2jSoFo(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sNLlGrswFJXOYkd6bcc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons E6XKKusgu9NN3ehdqw3(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XmDyoCsJOMM0wXqk6cj(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kjlFJtsyVRBaKhZyScL(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hmSjpDsDIoPstBoO3Lg(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size s1ambMsYS7Yvb1pLsVj(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int ltOXSusedRs4jjqeWmr(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size PmyNNTsFpkJRRjn6aOB(object P_0, object P_1, object P_2, Size P_3, TextFormatFlags P_4)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PGqdcLssdoE2VVcS1JK(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Ht05PPsMvCsTyMJZVsM()
	{
	}
}
