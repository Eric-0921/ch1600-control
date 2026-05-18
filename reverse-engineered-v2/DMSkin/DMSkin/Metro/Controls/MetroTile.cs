using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;
using o19Vgml3LXKc9XuPcs;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(Button))]
[Designer(typeof(WSjwLWpCanDvu1hVpf))]
public class MetroTile : Button, IContainerControl, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> FsfEFIRbv0;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> SeQEUwvKT8;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> s0fE2jTbAh;

	private MetroColorStyle JZ4Epb2lSe;

	private MetroThemeStyle WQ0EoPqjbO;

	private MetroStyleManager veVEsOLXxs;

	private bool X0yELGTyfc;

	private bool OQkEl7gSu9;

	private bool VFKEIraAZF;

	private Control uGSEbOb0qM;

	private bool r5rEEOsPIx;

	private int cu2ETOX0jn;

	private Image FVtEd2lQUw;

	private bool l6pE3Y2U9P;

	private ContentAlignment dbdEKawHSv;

	private MetroTileTextSize UeYENIjh3r;

	private MetroTileTextWeight HgWEmcts3q;

	private bool t9pEfN7Mw0;

	private bool f6YEyjErNQ;

	private bool U6qEA0hfYU;

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

	[Category("Metro Appearance")]
	[DefaultValue(MetroThemeStyle.Default)]
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

	[Description("使用用户自定义的字体颜色")]
	[Category("Metro Appearance")]
	[DefaultValue(false)]
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
	[DefaultValue(false)]
	[Description("使用用户自定义的全局颜色")]
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

	[Browsable(false)]
	public Control ActiveControl
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

	[DefaultValue(true)]
	[Category("Metro Appearance")]
	public bool DM_PaintTileCount
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

	[DefaultValue(0)]
	public int DM_TileCount
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

	[DefaultValue(ContentAlignment.BottomLeft)]
	public new ContentAlignment TextAlign
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

	[DefaultValue(null)]
	[Category("Metro Appearance")]
	public Image DM_TileImage
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

	[DefaultValue(false)]
	[Category("Metro Appearance")]
	public bool DM_UseTileImage
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

	[DefaultValue(ContentAlignment.TopLeft)]
	[Category("Metro Appearance")]
	public ContentAlignment DM_TileImageAlign
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

	[Category("Metro Appearance")]
	[DefaultValue(MetroTileTextSize.Medium)]
	public MetroTileTextSize DM_TileTextDM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroTileTextSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(MetroTileTextWeight.Light)]
	[Category("Metro Appearance")]
	public MetroTileTextWeight DM_TileTextDM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroTileTextWeight)(object)null;
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
	public bool ActivateControl(Control ctrl)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroTile()
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
	static MetroTile()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		vYkDQMItLhlRPhQn2v8();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool mY8EL7V9VoCrjktoVtw(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool inPRBSVZl9j3BALL2ba()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool kLFWVQV4DBb59CWhPek()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool VYk8T2VrFF7g9ZwbI8I(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle vLVNyiV3h5jfvFy79ro(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle Mptq7mVVawgeWee4db5(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JanQP2VIQt0I7QfDJxJ(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object nwcqvjV2kRB6ugthL0X(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool HosrVCVOmPfDgEY0rC6(object P_0, object P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xy6l6EVf0weFPSBkBDp(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ContentAlignment a4BaDpVqPv7NWU7NgSB(object P_0)
	{
		return (ContentAlignment)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NyaTaQVbIJX0KtW9g35(object P_0, ContentAlignment P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FUZdHPV6X776TLQHPPU(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gbkB3JVnJ8YZWlEuCr6()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LbWd2KVH3m7RRqsuvwI(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color DhCMDQVd6fCHkF1JnxP(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color fKfabiVhqmGb8e3TRjC(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object HD9kMdVcMLAkoKDVDWY(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LqF8faV7eLciXNL6RHk(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NDCZa9VPWcpdUxnWmGI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gZw2nKVvMemGfDhS8rc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Ik1hA0VSk70XD1ok9MU(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void T7M4WiVahxK3fToGmkZ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vDQ9ooVEtkhGmw3DG1j(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kvFAKXVGpYW3XybK0C7(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool rJAC04VkIaHsTFbwmTg(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color dr4TBbVLVgrLxHX76o1(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color tAWdaxVz4o9lo2FPXAY(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color RRb2ecIlkInuuZKWYrC(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ggVjOqIp99yNZtQUHi2(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color KPr3XJI53jDoaOd9JLu(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zSxDDMIAu8Bn3tYlJ45(object P_0, SmoothingMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void uomLRQIorsqiCwDnvjl(object P_0, CompositingQuality P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int xnOCExIW8O0uaKPEHCu(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int zM3bhiIUTF5grUYLvyx(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int ktkhwIIiBfiCknyiWXj(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int UZL1FCImHSqlrovq67r(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void V6SwV7IQeKWCt00Y2iY(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object X9if8fIRSSfL0VIFafO()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size L7oDIPINsrr6yEiXqnD(object P_0, object P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Cc9u6DI1RabNA4x1Cs5(object P_0, TextRenderingHint P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yYXEQFIKVxmK2QohBKg(object P_0, object P_1, object P_2, Point P_3, Color P_4)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object a5Y5DbI8Ae0vbKn7n29(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object aX2VUIIuj2K50oZ8CY1(MetroTileTextSize labelSize, MetroTileTextWeight labelWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags QV4LNCIj08TLXRSEytM(ContentAlignment textAlign)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle rL86yrIwv3U3EfHiQ8W(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mlFta2Ig8hiW3jNSZIT(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GX58xLIJoDrkfnRJ9J1(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ljIyOIIyNGxP7sVbZpr(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VqJ6Y6IDTjbIA9UdWSO(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void c8SJaPIYI8NrX2vHbAI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Keys uW824yIeSnQDbev3dj8(object P_0)
	{
		return (Keys)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TOQfT4IF6cEiTtvM5mB(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DHobUbIsJqGuCcTHJGx(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zQsKESIMWE15OeJn35U(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons GRfjQBICsfA0cD8rM8w(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IDOra8I0dW9NHoA7Bim(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AaP9ipIBL9LVN6JHWfU(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void thF6krIx1NrELgLtlun(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wLQJRRITgalH3ugQT6U(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vYkDQMItLhlRPhQn2v8()
	{
	}
}
