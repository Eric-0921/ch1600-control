using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using MqIncE1rMbDntiH7V9;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(ProgressBar))]
[Designer(typeof(sJYXutO3vcMdMfaHUn))]
public class MetroProgressBar : ProgressBar, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> aZnlLv3IvC;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> NTBllm2wxk;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> PEclIbQmvG;

	private MetroColorStyle DAElbEGTaa;

	private MetroThemeStyle tHklEso7qy;

	private MetroStyleManager J6OlT7ep4a;

	private bool WBXldGBA1R;

	private bool i4Zl3fooG6;

	private bool UNMlKxrpJi;

	private MetroProgressBarSize aHglNbrETD;

	private MetroProgressBarWeight NeSlmVrc0F;

	private ContentAlignment QrylfECsKJ;

	private bool XVOly2qeVt;

	private ProgressBarStyle gOIlAUbSyq;

	private int T7Ele0Fgs6;

	private Timer hqclOggt1v;

	[DefaultValue(MetroColorStyle.Default)]
	[Category("Metro Appearance")]
	public new MetroColorStyle Style
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

	[DefaultValue(false)]
	[Category("Metro Appearance")]
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
	[Browsable(false)]
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Description("使用用户自定义的全局颜色")]
	[DefaultValue(true)]
	[Browsable(false)]
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

	[DefaultValue(MetroProgressBarSize.Medium)]
	[Category("Metro Appearance")]
	public MetroProgressBarSize DM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroProgressBarSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(MetroProgressBarWeight.Light)]
	public MetroProgressBarWeight DM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroProgressBarWeight)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(ContentAlignment.MiddleRight)]
	[Category("Metro Appearance")]
	public ContentAlignment DM_TextAlign
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

	[DefaultValue(true)]
	[Category("Metro Appearance")]
	public bool DM_HideProgressText
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
	[DefaultValue(ProgressBarStyle.Continuous)]
	public ProgressBarStyle DM_ProgressBarStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (ProgressBarStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	public new int Value
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

	[Browsable(false)]
	public double DM_ProgressTotalPercent
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return 0.0;
		}
	}

	[Browsable(false)]
	public double DM_ProgressTotalValue
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return 0.0;
		}
	}

	[Browsable(false)]
	public string DM_ProgressPercentText
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
	[SpecialName]
	private double DutlFkATXc()
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	private int LRfl2WUZif()
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroProgressBar()
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
	private void ltCLQ9RvrW(Graphics P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void ibcLGNePDF(Graphics P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void lj5LzE8Wex(Graphics P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Size GetPreferredSize(Size proposedSize)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SpecialName]
	private bool l8ployDxq5()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void EWHlqZefnO()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void uJZljjwc9F()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void QrVl7PKxMj(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroProgressBar()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		oEATdGt0bEQeMq1hk22();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool TDZT0TTfE40RtxhSfSQ(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool a3OtINT2DbOuV9AxM3H()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool EIZrOvTOFJAZkGM3pxt()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool YYSeMiTqIfT5Gac62HB(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle vsqQJpTbwDvySPCZBw3(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle jmSmKxT6PAmGpnNfRrH(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rIgmKmTnZfpNQGcZ3dP(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int hdstxNTHm3j6kGBuBoG(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int sWYAhhTds73tCWjWcpV(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aSJlDXTheQPlbvCdCm8(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QPZ53oTc7awaBCOhQ9C(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static double E9FFT6T7pwlPOLaTtg4(double P_0)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object eCYpmjTPQS0SVf1MV0s(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle KFGZyWTvap3Z1nroRFS(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cbVcKgTSgxZN8b3cL4n()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QUkdQITa3fKytEvBkAn(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color POstl2TEWfuMYieBGUl(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool n10ankTGvOwBUWuFMLy(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color PKx80dTkkHLkWOj9bow(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color OblIPYTLJQBUhmKrRjS(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object XBqRtbTzPRvaVSNb4fP(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YbtoCrtl4E4JJEMhWOA(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aETlUEtp6by74IvD3NG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void S7URFUt5KYcSv427sMk(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wO2fZStATyYYHy51gJO(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gJrgkjtoX6V8tXvNRwI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void X4Fi8xtWE4prTtce1x8(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ALqqjZtULNHtpYHXAnO(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int LkSeBntiJQZSfNUY1pd(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GEjhOEtmm5LPq7aSxSi(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CCXBSGtQ4uWVDl7pUFM(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wKcW6btRreUaIlbdDeO(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Vc92GZtNsoqpVHYCYLX(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object JSUmM3t18XV5iEwhcF5(MetroColorStyle style)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void eXj3oLtK0SgkVBxtBtV(object P_0, object P_1, int P_2, int P_3, int P_4, int P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color E8QAc2t8eEFqRSskpxq(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color pArQfttuy3ZXCyhVXva(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object V4fyLptjjwqKvrHo0IC(MetroProgressBarSize labelSize, MetroProgressBarWeight labelWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags mTF2sItwcEUuh57o0rL(ContentAlignment textAlign)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Yr3yMHtgaymbrTTecbh(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size CddngatJlpQ2pbKuBhm(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object u9VjDmtyHWPjjtt1s02(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size yes84ptDnWWtqwDiYqe(object P_0, object P_1, object P_2, Size P_3, TextFormatFlags P_4)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool zpIwXgtY6oJ750wmASB(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aoZ5t8teIjMFXcQJKJS(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zCeQ5QtFIRy4LSE0PdC(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Fbp3HAtsmyMZF8rZCm6(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gHwLoltM04ToLaAWnXh(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qkMKnktCscKnhQ5D2xU(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void oEATdGt0bEQeMq1hk22()
	{
	}
}
