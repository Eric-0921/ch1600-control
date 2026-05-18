using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;
using XePcb8ImSTLyJa4dTT1;
using dFVBhvSpMhKsmnFvTP;
using naQvUrLcNWsWUZpXP2;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(TabControl))]
[Designer(typeof(fWbX2Rsnr5hrJJZTtR))]
public class MetroTabControl : TabControl, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> nalbq4rbBG;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> xj2bjiyU2C;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> AmDb7ZHnUq;

	private MetroColorStyle YTDbFdiNKe;

	private MetroThemeStyle OYXbUixN6H;

	private MetroStyleManager Ofub20oiFS;

	private bool MAYbptM7oE;

	private bool K8BboMY27U;

	private bool PCJbsE5XQ0;

	private PY53YSITyDTe3NoERMd S97bLg04jE;

	private bool EJCblXEmk3;

	private MetroTabControlSize EGdbIhFDRN;

	private MetroTabControlWeight FPbbb2QOPx;

	private ContentAlignment gk4bEN169K;

	private bool ETSbT7feVW;

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
	[DefaultValue(false)]
	[Category("Metro Appearance")]
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

	[DefaultValue(false)]
	[Description("使用用户自定义的字体颜色")]
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

	[Category("Metro Appearance")]
	[DefaultValue(MetroTabControlSize.Medium)]
	public MetroTabControlSize DM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroTabControlSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(MetroTabControlWeight.Light)]
	[Category("Metro Appearance")]
	public MetroTabControlWeight DM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroTabControlWeight)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(ContentAlignment.MiddleLeft)]
	public ContentAlignment TextAlign
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (ContentAlignment)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Editor(typeof(DGNiTpy3JN7seIvrXn), typeof(UITypeEditor))]
	public new TabPageCollection TabPages
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(false)]
	public new bool IsMirrored
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

	protected override CreateParams CreateParams
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
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
	public MetroTabControl()
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
	private void e2ZInUNOO7(int P_0, Graphics P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void gcLIiCeVgc(int P_0, Graphics P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Size BwqIYd0umL(string P_0)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void KhlIhbqkg7(int P_0, Graphics P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void XTFIc2n33P(Graphics P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnParentBackColorChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResize(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	protected override void WndProc(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Rectangle a5iI8ghLjg(int P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseWheel(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCreateControl()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnControlAdded(ControlEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnControlRemoved(ControlEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSelectedIndexChanged(EventArgs e)
	{
	}

	[DllImport("user32.dll", EntryPoint = "SendMessage")]
	private static extern IntPtr ttXIM8BdML(IntPtr P_0, int P_1, IntPtr P_2, IntPtr P_3);

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	protected override void OnFontChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void nwwIQZnNfe()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void D45IGlLVC0()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private int w9YIzHOUZR(ref Message P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroTabControl()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		QwCCQb9d24rMasrrAtC();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ax7QXN4Zc3hP91fspGa(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool PReNHW4tgtibOkJOK41()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool xaXV5u4Xlg53c7ivYVN()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool GqLELT44tdNYq6tvNDg(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle pRnxKD49CFVq79pQn0Q(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle N9u5Ve4rJH8khjkkj20(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sEyUdW43eA4TwKrtr7l(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object tmiDN54Vcybp7sVGkR0(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cqfyHs4IVmeUnQMmHjF(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Yj5wOT42o3d9W1jekDm()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void igsVau4OxpCjQkaGaUj(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void N5bxfp4fjFr1xp8blTB(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color HxvHwF4qXnqiolHKfxT(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color f0VBK24ba74fJkTj5I7(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object hNmh684694lEy6bFjRf(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object UwCHKv4nTPvVpdw5PFG(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nrKWCO4Hh0b4cNsnwoS(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AZQylK4dN6nGqP255Rh(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xnxQtn4hV05Al61Z2QT(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VWN8sM4cLsXGxBTJLbp(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Sy6w34478V98looCqlw(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void P0PGBk4Pd64wItdKj0B(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void n6KjN54vxxfiKkHLp1d(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int zpUVpU4SBmut83cS6vB(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int IpB9Rc4adQUrBRD45Do(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void c52PI94EK1eN2cOqisA(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color rwy86i4Gh99aZk7b0KF(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle NbWOL64kRDUeEnkBYO0(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zRjfIt4LMi6Xoo7g9My(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wDgVJ24z6QHKivZnWfe(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color kYGcEm9lJBsDeXa28ll(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object x36qM89pORTE5MgKKUI(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object gcrFSQ95blOVWtPjfAY(MetroTabControlSize labelSize, MetroTabControlWeight labelWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags MK8f4w9ALr0j6NKSSyJ(ContentAlignment textAlign)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size KBaUXD9oou9aoOfkVdu(object P_0, object P_1, object P_2, Size P_3, TextFormatFlags P_4)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object e9eaF19Wp5JVH47ZvAb(object P_0, int P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ioWNHY9UrxMi0ihiPtu(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color QIvinc9iZWZYQ8oyegv(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color jAmbv49mZL4uqplKqSy()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color VMGwt69Qsbyxaby5l2h(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WsOcZx9RLAwOwdqyh0s(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void d5XH6B9N7WbO3paIYTq(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, Color P_5, TextFormatFlags P_6)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object JJa7m791qiIxtnibckr(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr xOVi6g9KfNgTe2yGeq9(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lt6IqD98wjiA65LQdrL(object P_0, CompositingQuality P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void J5br2l9uLH1XFdo1ukj(object P_0, SmoothingMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NJpMkT9j3hagRudQgGB(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void V9sr1s9wGO3QKu4x9H9(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LqCsLA9gfKleISnWLB3(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dCA9ck9JubCN5qxw6jQ(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gOhxpl9yEip8hYdGudH(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Pj3sXF9DcTPj7Y56seS(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LHI3dq9YC9ungDg5dCG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr TpAmeu9epyORlsbSAjJ(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object BQPFA49FgO8hhsV9Imb(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int kKoSDT9sBDMOlJXD7dQ(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hwCkuj9MglV3atDeaMd(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle AjLyF79C0KBQnQkvyK8(object P_0, int P_1)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool iZmIHW90DCmMXxjOfK1(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object orCXpj9Bfdpx1cq1uJt(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object H7VjLx9xu12jFddtAkw(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object hmAEVo9Tg2C6F24k2Ti(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool s5iFFK9t8UpjercBCeY(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kj2eK39XpNYrcQQr9Rr(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool aVXfWs9Z8gVt2KRBdyi(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sAm3Fx94ZZlyDxApOjy(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Yc1y2c99Jx81ipsTjeh(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IgSBS59r0EhGS4ZWg5p(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dBuhni93QHRbyNM9XsQ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YwB9O79VnM9F21jymkq(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mADTfO9ItlpAghJWh7J(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Ee9c31927x0D8SaLANJ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr Q5fnhk9OrHAa7YC8dXy(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr hWsp8E9f2m5JSjOEDv4(int P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool at7Qsy9qsbR3cKZCKLS(object P_0, object P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Pw7Wka9b1uxsheKK70A(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool mgTiI3963JwPEYJqfKP(IntPtr P_0, IntPtr P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object fGY72y9n4lWHqYOXCpH(IntPtr P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wVq49c9H1wfjfWUblo0(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QwCCQb9d24rMasrrAtC()
	{
	}
}
