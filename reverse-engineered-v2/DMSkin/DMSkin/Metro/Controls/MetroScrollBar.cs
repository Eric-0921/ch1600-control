using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using EdrdnfHtalfxERCKII;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Metro.Controls;

[DefaultProperty("Value")]
[Designer(typeof(wm32lc4DD4K852AIlR))]
[DefaultEvent("Scroll")]
public class MetroScrollBar : Control, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> It1IlbEKT1;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> kdTIIskRmd;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> BQcIbZkB1P;

	private MetroColorStyle QitIEctJfO;

	private MetroThemeStyle KnCITGRV2h;

	private MetroStyleManager LZoIdnbBLO;

	private bool M8pI38iOpJ;

	private bool jPeIKQXkgf;

	private bool UY8INMyoOZ;

	private Color GNVImGPZht;

	private Color hyiIfBRIKK;

	[CompilerGenerated]
	private ScrollEventHandler B9NIyJXUyZ;

	private bool scuIAA8G1M;

	private bool cg9Ie1mAwl;

	private bool mPfIO83G4E;

	private Rectangle QbTIwlM7G3;

	private Rectangle YRgIPmOKFL;

	private bool Q76I1h9XQa;

	private bool tX9I6YxKJp;

	private bool rs7IkfnUTO;

	private int pjGIg8sx7U;

	private int xgXIDwSg2t;

	private int IT1IrtMSaU;

	private int yCdI9MIcTI;

	private int vWnIZJgWa8;

	private int T5uICIsht3;

	private int TkLItsBAYl;

	private readonly Timer YSAIRW3KGB;

	private int aAbIBkH1u7;

	private bool A4oISuq0J6;

	private bool wkdIVNZDWN;

	private bool zHUIHS3jbw;

	private bool hU4IaGEGBX;

	private MetroScrollOrientation ntVIXeLFhY;

	private ScrollOrientation ScTI0Ce2mt;

	private int mGaIxM2Vcr;

	private int dGvIuWKt6c;

	private int VnYIvWKDUL;

	private int e7qIJNq4m5;

	private int DEII4G2R1O;

	private bool WgAI5CM9o7;

	private Timer caPIWldYr6;

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
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Category("Metro Appearance")]
	[DefaultValue(false)]
	[Browsable(false)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("使用用户自定义的全局颜色")]
	[Category("Metro Appearance")]
	[Browsable(false)]
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

	public int DM_MouseWheelBarPartitions
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
	[DefaultValue(false)]
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
	public int DM_ScrollbarSize
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

	[DefaultValue(false)]
	[Category("Metro Appearance")]
	public bool DM_HighlightOnWheel
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

	public MetroScrollOrientation Orientation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroScrollOrientation)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	public int DM_Minimum
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

	public int DM_Maximum
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
	public int DM_SmallChange
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
	public int DM_LargeChange
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
	[Browsable(false)]
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
	private void SkUlQMjnrB(ScrollEventType P_0, int P_1, int P_2, ScrollOrientation P_3)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void mGxlGk7w7X(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroScrollBar()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroScrollBar(MetroScrollOrientation orientation)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroScrollBar(MetroScrollOrientation orientation, int width)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public bool HitTest(Point point)
	{
		return true;
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
	private void DeSlzgyZ0u(Graphics P_0, Color P_1, Color P_2, Color P_3)
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
	protected override void OnMouseEnter(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseLeave(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseMove(MouseEventArgs e)
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
	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSizeChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override bool ProcessDialogKey(Keys keyData)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ud7IqGYlCG()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ujqIjMd5CN()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void fQgI7LFpbV(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int TqtIFXl9EG(bool P_0, bool P_1)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int DvjIUX3ITF()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private int cu2I2At9JB()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OCKIpjJ65w()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Ri9IoNGeiO()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void g9NIslDkhv(int P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qiXILJIbHB(bool P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroScrollBar()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		rnFFOF4FqqVMZWVjY5f();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool heJ5pwZjqQDaImw0NcZ(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool i9220nZ8MiGeklUpbnw()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool qdw6LuZus4U5LK6md9W()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool dAfUHeZwi6nQdmcPSQa(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle aEY0POZglCSqCo21uDm(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle XsNv2vZJdeymgrSB1Ut(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xZEVuhZytvW2h7t6cCk(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object YZhTCsZDt0ricHHFvVu(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object kQCGlEZYAvkWJsl4Hit(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wacYS6Ze2ExRgm9QTxu(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int aeePCaZF6cF0ULAS86d(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int gOAZh0ZspGUelK9LLBI(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zT8ZCrZMZp33dUvYxnr(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FS0LSNZCL3ei4sw06Ym(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void h7KVMgZ01VNoDlvK4Kv(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Q70dtLZB3Y8WxAvATKu(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CwspVlZxQDGyU2CDIqc(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void EMR6waZTC5pvY18hRZ7(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cFFl1TZtJBa1VqBTwQK(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TT2tTVZXuPo69YoGp8J(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DpJJakZZDBmosMZrNpo(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zssXfMZ4RMw80QbW4J3()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color DbMOfWZ9ZMpx5h4Hoqf()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VZhVpOZrdYynMWc913H(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color cAfXA9Z3065Ykq5Thxv(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object LP4UcwZVHeDSDk71tfu(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color OToOZFZIs9j42oDsK2D(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object z6iWSRZ2gfQFCAvHwuw(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JOQ3KUZO1JGmCByGmEM(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Q5gb42Zf3iAS5uudnHI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rrPi5DZq8h3NfGgQKsH(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xy64UYZbXlNFrcImqpR(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void W26cHeZ6p48ivBA0BBb(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iWqJp3ZnjgfU9eR7mDr(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool g7oTA8ZHKRaxLjoVqwa(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color DfV0JdZdTuBWrsdXNcL(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color jqwqE3ZhoLBjDPOyGmZ(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color JXrSYyZcrjnYasYXWZD(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color c7vgVjZ7bQ4PMkDP630(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yxlY5RZP3nfn6ZUVULy(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle WYA7GuZvx0MEKxrTlNf(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YHvUMuZS362X7ri6ARX(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dnDGNZZaEJe8pVusYTd(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void S4M6MeZEZbrKKbdTHaA(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NoREwkZGdvmFIQEJmUI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vAPYhOZkEn76WOKLIbD(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void UCoEVJZLJTxtY8gecF6(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void goVvE5Zz4RpPn6MgW1P(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int FsWEwc4lHGPGtteoyWp(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons Qr7iLF4pNKMrp8S0DiO(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IdTIxf45NjAGGxgPJB8(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool Qxf7a84AD4sBd02wJ6N(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point FS8EDT4o6qAoTQRMK9Z(object P_0)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PpOfm64WQGbApTpO7VA(object P_0, Rectangle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int RX7deQ4UrwpodiaaHGL(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int yYpgNN4ivd9ZaLO7jIR(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nNoDDq4mw1pchBkEOVp(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rUYqsU4QR65WApp7Y3b(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KqnTnO4RwQHaoWe62vR(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Bl1kMw4NpKUo50V03Id(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int vkgArS419gqCMX5XEc1(float P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void MOkLLI4KYtoUOxRHwP5(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vHi7ha48rgDPyNv7gox(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void h5LT9H4uCl1mfbAuFcm(object P_0, int P_1, int P_2, int P_3, int P_4, BoundsSpecified P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void AeSB0I4jG3iShjPLrSu(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool wDN4v14wiDKcCL61yPX(object P_0, Keys P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PTPWCN4gxJ3r94DbZjp(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int yl22Rm4JHjBP1OBZWJn(int P_0, int P_1)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int C7xqwq4ynF6uvTUgGfb(int P_0, int P_1)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float Yw8Na54DmBndEZt5WIt(float P_0, float P_1)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float m8xmgS4YucyOCi4wywi(float P_0, float P_1)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool mQpr3q4ee1WTUkTt4xm(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rnFFOF4FqqVMZWVjY5f()
	{
	}
}
