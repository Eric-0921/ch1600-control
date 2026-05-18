using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;
using jur4QVbljpyU3jmFeA;

namespace DMSkin.Metro.Controls;

[ToolboxBitmap(typeof(Label))]
[Designer(typeof(YFIeogBaQrjx2cvN3i))]
public class MetroLabel : Label, IMetroControl
{
	private class pos6rGIqsuP3btNTcCM : TextBox
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public pos6rGIqsuP3btNTcCM()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static pos6rGIqsuP3btNTcCM()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			e5mQ3opiDvKOrGHRLkiw();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void F1d0pRpigEBuXw1uURR6()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void oyoR9wpiJQQ7kH4ed9iv(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EXQccZpiy8xTmrkfFk71(object P_0, ControlStyles P_1, bool P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Yuc9P2pij7eqvkpuP962()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool T6opYJpiwo7Ab0Alp1ZU()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void e5mQ3opiDvKOrGHRLkiw()
		{
		}
	}

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> hwCLdHAbRp;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> BPUL3k2alc;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> MquLKjy6Ip;

	private MetroColorStyle cKJLNwhjkV;

	private MetroThemeStyle QvZLmkPgWV;

	private MetroStyleManager jhiLf0UrA7;

	private bool fDJLybLtdM;

	private bool BK6LA85s1Q;

	private bool TItLeW8u1Y;

	private pos6rGIqsuP3btNTcCM aYeLOa5RCe;

	private MetroLabelSize YrhLwK10Dq;

	private MetroLabelWeight jiaLPEgdkU;

	private MetroLabelMode So7L1SeQio;

	private bool ym3L6crOuO;

	private bool nfNLkV8gxj;

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

	[Description("使用用户自定义的全局颜色")]
	[DefaultValue(false)]
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

	[DefaultValue(MetroLabelSize.Medium)]
	[Category("Metro Appearance")]
	public MetroLabelSize DM_FontSize
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroLabelSize)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	[DefaultValue(MetroLabelWeight.Light)]
	public MetroLabelWeight DM_FontWeight
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroLabelWeight)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(MetroLabelMode.Default)]
	[Category("Metro Appearance")]
	public MetroLabelMode DM_LabelMode
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroLabelMode)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(false)]
	[Category("Metro Behaviour")]
	public bool DM_WrapToLine
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
	public MetroLabel()
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
	public override void Refresh()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public override Size GetPreferredSize(Size proposedSize)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResize(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnSizeChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void aUtLpBopVW()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void o9yLofdKQc(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JeDLsY7ib8(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void B0eLLMnC2K()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TJjLl15pPN()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void TUXLIMFcc6()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Bf5Lb6VHwv()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void aBGLEPkgQ0(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void GvELTDEaJa(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroLabel()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		kN4usCBh3wyQSD6oQRI();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool nNEKgT0ISFoH7F0uhjM(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool D3FbXO03ssqKthcfDhY()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool d5SVV70ViQBLGRqL2MT()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool LMjQlp024CeQJgVvkba(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle Rf3UlR0OcDwKoetEC6p(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle fiKwYR0frJfGaB2SquF(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RDKVmc0qxIn78wylvQR(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gNqeRR0bw5pUkoaN7tM(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VTGuoF06W4rrgEiEfan()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iEr3c80nHGkSOx1uQhL(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tSXDBH0HDJioG1XtmKI(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object GRWXJj0dantgsEG9KPr(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TjBYQj0hEASn2hZNoMP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color sHnrtL0c96GuBw1TJcs(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color V8cLvU07Nb1BDtEHNrk(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object EjRQ8t0PpxSw1dqlev0(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color tq44Zq0vLSAgEZLQyVj(MetroColorStyle style)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object rWlCr40SZQNwnMDEL6F(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object gmsZux0aW1KcWypBBg0(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aPoqgV0EeOajhM7INSE(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Dh79J60GyPOgPx08m6x(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fL6VKX0kkyqtN31NjDX(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YqNJrZ0LvK1a51Y6hAE(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qnHmqN0zRZuqbxUtxUW(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void WZxQlnBldEZsmQjmF3H(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RAN6twBpIwSEjvSXh5D(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color PQ7CWmB5NRKMb7TbIah(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool XSKvlIBAUowyu9kt4UZ(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color IyS51cBoykbjB3GOXei(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color lavTZVBWpc5hKhhhYvE(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color Qctou3BUxATkx1XAFwb(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color M1vmJCBiwLFSBZk40Fl(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool gIRPGCBmVNKIMF5Ar8t(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object NoON16BQ66lRUDqsNau(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object WLPy7dBRe0tng6oROWD(MetroLabelSize labelSize, MetroLabelWeight labelWeight)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle ePCD5YBNOgxnFJ9GO9R(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static ContentAlignment AcG5stB1uYywE31P9ra(object P_0)
	{
		return (ContentAlignment)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags AGXeodBKXU5dbd23tG7(ContentAlignment textAlign)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vwUaBAB8bQyDTol2W2e(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static TextFormatFlags BNKHoNBuhB9sTFFijnH(ContentAlignment textAlign, bool WrapToLine)
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cLJx4TBjhkU2rFSSR84(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OvLcM5Bw8YpJgFBZAmI(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size TouwEnBgjtk04EpcnjM(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object E83vXZBJuhsj915Fmwi(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size t5Ux0JBybqgx1nA8kss(object P_0, object P_1, object P_2, Size P_3, TextFormatFlags P_4)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yGJSHaBD87CBxlk1Dw3(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void X3O5b5BYweM5rqbB5OV(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hPvnsTBeYOHQ9VbqPPK(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YsP1GpBFoanTFvEsNkb(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object rZiTC5Bsd05wBNjhhMJ(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void gDrrv4BMGdeTCdmn0jU(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void MGg8TxBCfjSjH8IRAqV(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color j2TAXJB0LTB55jblPK5()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HFlYqHBBo7CRNsQB2XJ(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ntqUhiBxcZKlKPR8esp(object P_0, BorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Cn0T9VBTWu41XKFpG0p(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void eTMSmbBt5EWgZNnRkmN(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aJ8ldyBXH0xxwbXMYaB(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xUq3aMBZQKU3a5lne30(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size RkBjLEB4TYUGyOT7Omn(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wIKtJiB9w9YvY3ZVuYI(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lTIEVlBrSdjodmhgvXN(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ie3PT2B3RcShdvNrkRy(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void l2OCelBVkZowOkIp56H(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void amxb4RBI9klcQ0xDZSe(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void f6NtTnB2rJGTvkpBt3Q(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iWOlBVBOdDZioC84a5L(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void j56p3KBf6blNrSxYcfh(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XIfd2uBqy5luEerorpU(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void xmpi30Bb7R7ciXwt50G(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dUlqgQB6vsj0hNSQO4u(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zdjAnHBnB9EGAEds8sM(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr UmsngQBH80MS063tm6D(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void C9XJ7ZBdf8D0ApEO3Dx(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kN4usCBh3wyQSD6oQRI()
	{
	}
}
