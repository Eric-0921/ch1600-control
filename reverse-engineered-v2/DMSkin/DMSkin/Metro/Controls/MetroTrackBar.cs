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

[DefaultEvent("Scroll")]
[ToolboxBitmap(typeof(TrackBar))]
public class MetroTrackBar : Control, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> HvDE09Foli;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> SJwExHZVgD;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> Av4EuqH5Ft;

	private MetroColorStyle t9KEv4bV2f;

	private MetroThemeStyle Gn7EJsryy2;

	private MetroStyleManager WrmE4R6cKc;

	private bool P5bE5G6R2e;

	private bool dwrEWGtGtQ;

	private bool ajiEndQZqx;

	[CompilerGenerated]
	private EventHandler IgrEig4JkL;

	[CompilerGenerated]
	private ScrollEventHandler P0rEYThx4R;

	private bool Dm2EhFecPW;

	private int dmnEcWGjk3;

	private int WTEE8aVIfS;

	private int VQZEMfrR1a;

	private int xH3EQm3fgg;

	private int a28EGasqkJ;

	private int iBxEzcspwM;

	private bool SrITqK8dyE;

	private bool z7pTjK3YhN;

	private bool yAvT7TFpWP;

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
	[Category("Metro Appearance")]
	[DefaultValue(MetroThemeStyle.Default)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("使用用户自定义的字体颜色")]
	[Category("Metro Appearance")]
	[Browsable(false)]
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

	[Description("使用用户自定义的全局颜色")]
	[DefaultValue(false)]
	[Browsable(false)]
	[Category("Metro Appearance")]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

	[DefaultValue(true)]
	[Category("Metro Behaviour")]
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

	[DefaultValue(50)]
	public int Value
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

	[DefaultValue(0)]
	public int Minimum
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

	[DefaultValue(100)]
	public int Maximum
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

	[DefaultValue(1)]
	public int SmallChange
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

	[DefaultValue(5)]
	public int LargeChange
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

	[DefaultValue(10)]
	public int MouseWheelBarPartitions
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

	public event EventHandler ValueChanged
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

	public event ScrollEventHandler Scroll
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
	private void y1PEVsUQ11()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void WccEHn8QEp(ScrollEventType P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroTrackBar(int min, int max, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroTrackBar()
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
	private void gRpEaE7JYG(Graphics P_0, Color P_1, Color P_2)
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
	protected override bool ProcessDialogKey(Keys keyData)
	{
		return true;
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
	protected override void OnMouseMove(MouseEventArgs e)
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
	protected override void OnMouseWheel(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void UWlEXb91mc(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroTrackBar()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		jBhFDSO3R10XrQNEGI0();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool lbnNJR29aFbaGwcMDo6(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool cVUarE2ZMvtAChVwHlo()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool E3t38D24V4pgetK8iPf()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool isYULK2rPppqg1EhvP3(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle eL1oEO23MdbCCUg070b(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle h6ebQH2VRyGRAQAa8Na(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PNeWAn2I8ivuUN57sJ9(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object PL7HuE228PKaAGsArwf(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object FKGECx2OTREx4rw4IRF(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tEDsot2fuUfEsslhZGM(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PdTGA52qHQFNj5Digjl(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void y4IV3a2bDVwB9niOvrf(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lwaclT2633oV4hSeYf3()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XxaEFN2nEkJPd08WAnE(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color jtaa2Y2HRiUwiuQitPE()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QGbeUf2d7nkLVCTvsIn(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color zVUwUo2hmmXBUhQs0Sw(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color c2pXL82cA1WHaXsCfWS(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object g4R0Bl27gRBZL2VSlZv(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void eKchYn2PCg9bOMBFldo(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void y3F29n2vJQUhROdWSUP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Fwa5g92S1JDp759peDB(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Hxg1ZW2a7qhYvPh2x44(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jVpm2Z2EWejHBPuZ0EH(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IV6nwq2GO7iBWVIgBWJ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool z2D0wT2kZSKa8Z4KJB1(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color CweTyO2L2Dtt4gd6cyY(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color afXwDH2zdwjAKQ1gVbw(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color SMvZByOl5vCJ2VOQAfZ(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color XVRN7vOpwEyfZyGlMYw(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color DL47rVO5JSAmaa3mIWt(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color t0vpn6OABr7KFPtQpui(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Coe0CGOo3lGA0j6JgmQ(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color UQW6uoOWpNJepLqRW76(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle IqvfunOUFPhmi3nhcZ8(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TyJ2P9OiXEF6UtbxbKY(object P_0, Rectangle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int Eh9cubOmHU1YqZgKl8B(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int zPDD7COQ07JQ7FYwyxU(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cgH7CgORYbWDmnqq8K1(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TrwJLfON7N7bJXIYx4e(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pxVWegO1oyj3FQId1ch(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void a8BoiNOKXPk5eFVABBD(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TapTOuO8w2iyRNsGXD3(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Qt7OP7OuEL6sk5jquJA(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hWd8mWOj6YRTUmiNwHO(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LjwLXlOwIWROwgMgE2r(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Keys DxeOicOgi8xWZPXlB7v(object P_0)
	{
		return (Keys)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point Hge4ZeOJlBybcVQhWwE()
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point gYrItDOy2fiwDOngYsX(object P_0, Point P_1)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void R1VV3UODXetyoS0uAvq(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Keys W7pci0OYqXR3Ap1Zn4i()
	{
		return (Keys)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool agCVoIOev5pMIWSEA3Q(object P_0, Keys P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TkxjCvOFgj8TLKuNeRZ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Qc95qfOssUwq7cx0csM(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons yIascFOMYCwxDf74kUC(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TXo5PTOCYiEeScJJkkU(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void c0nBQxO0LDaxdHoPWmm(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VMvYBkOBm5o1Q6p0E3g(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool wAnHYaOx0QH5uDs8Syj(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point SBgOiOOTXAKG6O9jFO5(object P_0)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size SInDHBOtldK8RgjQj2b(object P_0)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rWp2gVOX3cPaB6GZhLt(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void l4apEIOZ5LCXArL2LAG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LeLGToO4PFuit3C0htI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int NpIHsSO9iNwcaVZeX0R(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RBXjBMOrH3K9eD3R0K5(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jBhFDSO3R10XrQNEGI0()
	{
	}
}
