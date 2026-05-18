using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;
using gHYfT96fCk0vMm4sKR;

namespace DMSkin.Metro.Controls;

[Designer(typeof(i7VCdPMxlJroJevnEm))]
[ToolboxBitmap(typeof(CheckBox))]
public class MetroCheckBox : CheckBox, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> SpRoSGoHRx;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> yuXoVcbToi;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> nxQoH6sbag;

	private MetroColorStyle jM8oaC2pwg;

	private MetroThemeStyle PFioXgY8f4;

	private MetroStyleManager tSro0OC0rO;

	private bool J4foxWhogX;

	private bool SbGouNGw4y;

	private bool sQjovRBWL3;

	private bool flDoJWd9Zf;

	private MetroCheckBoxSize BVIo4QVgAn;

	private MetroCheckBoxWeight guro56wUZ1;

	private bool N4coW8Jei5;

	private bool eCHonLjfhW;

	private bool ikDoiLEYZ4;

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

	[DefaultValue(false)]
	[Description("使用用户自定义的背景色")]
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
	[Category("Metro Appearance")]
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

	[Category("Metro Appearance")]
	[DefaultValue(false)]
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
	[DefaultValue(MetroCheckBoxSize.Small)]
	public MetroCheckBoxSize DM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroCheckBoxSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(MetroCheckBoxWeight.Regular)]
	public MetroCheckBoxWeight DM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroCheckBoxWeight)(object)null;
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
	public MetroCheckBox()
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
	static MetroCheckBox()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		fJD0rYFmPasBDqEinKf();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool eXuu87eiE6MLgQyxkPr(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool qfPlEJeWjPxwex4d5Bh()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool JYnNAPeUXeyCTvIcUSj()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool h7qSQ4emluwvebi9xxR(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle kOOqFpeQu7q6O7lSwRl(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle XHsY4ieRZXrcdZmqVZS(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mHIU2seN2vAojHYCWBr(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object mJvNPxe1NKjFuX1D3tP(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aAlqwZeKb6NrBFuE4pt(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nUfYoEe8mTRonvAmeMe()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OLJJiXeuPeB4goPKAK8(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Uj2W6dej9q7TgjKVRZR(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color rCZXGyewVBVwiraDsDJ(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object Qs7PP2egqKLXu55wJBT(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color LsDRF4eJd5uAvfeI4GN(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object KOfH8keyqIZ2ESXk4v5(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void K4tSNIeDSI9tmHw6ewV(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GsQtGNeYFE5FjYWDYGg(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jw46ofeePNJlHIg5jDN(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void a71wCDeF6mcFXZ8kYO1(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IoC4ODesvP6svIT6rWc(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XtY0ZbeMPoCeqW4XpnG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ksVcM5eCpubeg27W6mi(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color qoneU6e0ZVBNxOKGhH4(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool H60JIJeByaGjvTlwPgk(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color hMlhKHexTlGpierbxsi(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color FXFZ1LeTloi3RhPrEGb(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color M39IAMet05a72hC2THg(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color pAdoMdeXNU5QxnM0QKi(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color UhTNiEeZSH7hXxpmXyv(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color OCMGTfe46MCMZMu6ixE(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color aJmtJGe9hS9vRM9BeOE(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color MXi7WferdNKf5bIdcPs(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int XyrsUYe3sq8moCHVfgw(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LVQCgdeVEn5y9QtNVFV(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wh41N8eImc0NoFRXGYY(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool wBHPyMe2je5id3EKk30(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static CheckState H2ptLCeOJ7H81CQjyP5(object P_0)
	{
		return (CheckState)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tH70U4efbn9yVow2hRX(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int dhQ1WQeqTBF2uX9Z0gk(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object LLyx1rebCooU7WdOOAB(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object L5ZV4Me6XVliZSC271E(MetroCheckBoxSize linkSize, MetroCheckBoxWeight linkWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ContentAlignment dSoaSmeni2H2bAQsyKB(object P_0)
	{
		return (ContentAlignment)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags Kjng2SeHthafaQQL0Q3(ContentAlignment textAlign)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PAArHjed0CZlRdToZ6Q(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VvfjmZeh4PV03JfNkrX(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle LQ2s2oecgqjgGeQcVog(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RhrFFve7JXjf6vuFBC5(object P_0, Rectangle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XDns10eP5uDu7QOsQTS(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JTDW4FevPdKlIeq48gP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void H7ix8JeSO9Bfc4qwBfO(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XZ7hnQeaMxLJdWabtOn(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Keys MsawixeELHuKVg86Ieb(object P_0)
	{
		return (Keys)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tHAHgJeGRVaKv3jrdWt(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CdPRBqeknySkAWxOpY3(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void I4ccLgeLwVdW3Te8yjb(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons tQ9YWhez2Fgip5LAFAa(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pojX59FlvrxYirEcUhZ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tRdbL6FpGsiiNl5iiPN(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void S4CKUcF5EOcmcrjiA9H(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void p0ScZfFAXB3h82868p9(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void K3D9pTFoM2qfUSWW6JN(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size xWykavFWAWYvPDyoLZW(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object suKMNcFUokaVSsp9Svp(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size G9x70oFi0Q8YeIKKaSs(object P_0, object P_1, object P_2, Size P_3, TextFormatFlags P_4)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fJD0rYFmPasBDqEinKf()
	{
	}
}
