using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using NqiWQMwGuaDGNyHmRI;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(ProgressBar))]
[Designer(typeof(ickFULcG6f0jLPGaAs))]
public class MetroProgressSpinner : Control, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> uJtlPmZNGx;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> rx9l1IYFl2;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> iPal6lsH6C;

	private MetroColorStyle pLslkbHj0f;

	private MetroThemeStyle LjllghODCM;

	private MetroStyleManager VQ0lDEMAMA;

	private bool zLIlrOMfBW;

	private bool ufbl9bDrXi;

	private bool TNslZYpTgQ;

	private Timer mMnlCp73kS;

	private int kJ8ltxF33D;

	private float Y6ZlRbF9KK;

	private int YEwlBbaSRF;

	private int LKulSr7m08;

	private bool DHwlVApFFf;

	private float Ta2lH1YIwd;

	private bool t4blao7yBE;

	private bool f6GlXrrtvw;

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

	[Category("Metro Appearance")]
	[Description("主题颜色")]
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

	[Category("Metro Behaviour")]
	[DefaultValue(true)]
	public bool DM_Spinning
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
	[Category("Metro Appearance")]
	public int DM_Value
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
	[DefaultValue(0)]
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

	[DefaultValue(0)]
	[Category("Metro Appearance")]
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

	[DefaultValue(true)]
	[Category("Metro Appearance")]
	public bool DM_EnsureVisible
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
	[DefaultValue(1f)]
	public float DM_Speed
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return 0f;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Behaviour")]
	[DefaultValue(false)]
	public bool DM_Backwards
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
	public bool DM_CustomBackground
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
	public MetroProgressSpinner()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void Reset()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void DDnlwhfyjn(object P_0, EventArgs P_1)
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
	static MetroProgressSpinner()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		zL54QfXinBXdp3j5uvQ();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool k9QCl8tTsKnmNxB8UxS(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool kwdB2rtB0Z6hJTBBnp9()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool t1RbK0txQ88y8duwcGJ()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool qPRKqvttkTtFoxlHDA7(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle ul3MJOtXc61vcDA1i7M(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle vnpBUctZlXZj9VtdyHv(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void I8fCXjt4NsZZjryYNKl(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool hHVp6wt94N2Vbw4Afb2(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Sy4HIZtrPCliNCs5MRc(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mQ0fNrt3c9uNA8lDNaM(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xuX08vtVJ9yepbjUnZw()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vRIsVUtIKvccZr4lJlG(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DVj7dmt2ouZW6nEP1Rh(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void I3oHTbtOcvdT6QITajP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QhsYFAtfnN6kTEPFPdT(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void MIu9gjtqeatqrl0c9FF(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NCXQPxtbaLwr6T69gap(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color f8rPiut6W0Qgu1jWBCF(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object nocE5qtn9bRnvrSF9ZC(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ADKEj1tHGJOog5ilUj2(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color YZ5C6ttdpaUGMDn4U9C(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object jgAOnathiXRx0IOrtca(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tm1IMrtcuU4OkPHTk7d(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void C9MHqVt7T13OVXTROOa(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void oa9yLctPOkx4yP9tNjt(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void moKpSxtvCRHWOLwWZmk(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tvm3PJtSFfphxGKHWOd(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qyFVnEtaQmQbTnaFp1A(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sg4wYktEfWuMKqSdGdu(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color W6NO3RtGpmE8ynTCYqi(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int L3ol0mtkg8Bc7T26WL9(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static double hGMgLRtLYZp5cVO22rY(double P_0)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void e3U2sotz8t7IyKqWVJr(object P_0, SmoothingMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int JHp7qDXlntjWwwMomY5(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PoHn3qXpGKAI2hTYpGP(object P_0, object P_1, float P_2, float P_3, float P_4, float P_5, float P_6, float P_7)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color SPhkY5X5JrrnbVwxSCy(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ToNsDEXAFd5Rhe2CslR(int P_0, Color P_1)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static float zOlfxGXod1ro4vv04Mf(object P_0)
	{
		return 0f;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void O9lTecXWMNELUcTPhZD(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Unk4mWXUetJIbotgv1M(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zL54QfXinBXdp3j5uvQ()
	{
	}
}
