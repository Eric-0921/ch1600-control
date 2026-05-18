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

public class MetroGrid : DataGridView, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> xsesBN8P48;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> C9EsSgU6Iq;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> gYgsVqJ6t8;

	private MetroColorStyle JPssH6KgOM;

	private MetroThemeStyle uswsaP3gw5;

	private MetroStyleManager MFksXYO3Io;

	private bool TW1s0QkMLq;

	private bool M6BsxNmbSn;

	private bool DoosuenUN7;

	private MetroDataGridHelper EJHsvXwl9H;

	private MetroDataGridHelper tKusJyLhVO;

	private IContainer PEWs4Tr25S;

	private MetroScrollBar oDEs5mIngq;

	private MetroScrollBar GgXsWYYNcU;

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

	[Category("Metro Appearance")]
	[Description("使用用户自定义的字体颜色")]
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

	[DefaultValue(true)]
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
	public MetroGrid()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseWheel(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void goastbrtCf()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void llusRQ1DQx()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroGrid()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		LjVd7yCqSwPQlH7XQdR();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool fvbZDrMdGnmvdD6jyJx(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool zWsaudMnd366Eb3kOtv()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool TGEZvlMHmg69TEKs2Nt()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool cE2GfkMh1hDSSDMAC2p(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle nPdjtlMc75asq14TPsc(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle PYrC10M7Zu9YlKyroSV(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hbH32tMPBYaGsSJPqaR(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NARJ5fMvZmZ0frxYl8r()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void a4bjBMMSGa4XnXBoUev(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object KiPvd6MatQhjBovSMrh(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tN31lJMEEZkXYX7gQND(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Bi8Q7SMGsYvJDBd9GYp(object P_0, object P_1, int P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cg0HZVMkMKv69Tpc4RS(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void v6dEnqMLAFgEeg1KCum(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int KRoDdSMzXPEAHaRg39b(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int USdkVtCle1mWABISdlH(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void f4w4TUCpkwimylU5yLA(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dtBUQiC5V5YQKgXC9Kw(object P_0, BorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void d0qtYYCADDlC5SZxbTq(object P_0, DataGridViewCellBorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OgZrXuCopOegwlmsL8U(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zv6cAXCWMAyT2ha6alW(object P_0, DataGridViewSelectionMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color meqOn2CUiX0inofBA36(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void UPY8qgCiL3JirTNdFgT(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rB0EuQCmp2r2Hv4ZPvi(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void T4utbkCQaKUheyn8ivy(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color K6dINQCRPR9EOYiRm10(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void I3CWPXCNMl2uWIrfVRD(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void guhqX1C1lNbRu5KYmkE(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fqfkn8CKIgCvRADwb0H(object P_0, DataGridViewRowHeadersWidthSizeMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RseIkCC8uHwnXAHLP2L(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YdKuOQCuDll0RakljjK(object P_0, DataGridViewHeaderBorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object lOhU84Cjp3mdOOjnw01(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color jEJ285CwLqAAGFM76oh(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void faMEjkCgerTyNaiaMK0(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Yjh73lCJ0ynLE02nVMH(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Jf1hWRCyuDWP1EvXrKi(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iJuacxCDWWFC3FVselU(object P_0, DataGridViewHeaderBorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object N89R3tCYL6oUiXRquLH(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object PvbPBBCevbXgeUAYvdR(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void w8SveaCFTJvlnXFlNF9(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color No36R7CsTLwTPjIuTJ0(int P_0, int P_1, int P_2)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JQ0KXXCMvPVj0BgAHfH(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HrLVURCCb9THT6VRMs4(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void uFWosYC0cJQ0RtJG1rn(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zo7igCCBBOOblFycsqF(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void oKsFTDCxEpi6rUViRDY(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xmOA6hCTt7Ks93muxtn(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GMnieQCtYOQkBsgX48O(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mIZWcMCXJ2PgYy7mWKM(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Jqnd3fCZMLLuRR7agJF(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qLr2uLC4ugPBlgvpk2t(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void G0msleC9InVZghLEEUo(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FyOOsCCrdZS7004oMaR(object P_0, MetroScrollOrientation value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void GZovNnC3ilBtTc7vPeF(object P_0, int value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NIrf6UCV0OqyvWYZ5Mq(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PsbtRMCIXeJxRPRI6li(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TPOmirC2yprrijPv4Xw(object P_0, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aM53FQCOEOirlDpgShH(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Kkups9Cf7LWfJkhL3eM(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LjVd7yCqSwPQlH7XQdR()
	{
	}
}
