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

public class MetroContextMenu : ContextMenuStrip, IMetroControl
{
	private class mQQD8cIbqL8MJQT15i1 : ToolStripProfessionalRenderer
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public mQQD8cIbqL8MJQT15i1(MetroThemeStyle P_0, MetroColorStyle P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static mQQD8cIbqL8MJQT15i1()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			F3wfNFpimVCZLWhbcLwS();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void SsW93jpiUlYTJhCZQk2Z()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void GtuVi7piisGnpCiNDnnW(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool kOdWqMpio3XIURZkjQSx()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool rax5b0piWxNWZkBW37UZ()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void F3wfNFpimVCZLWhbcLwS()
		{
		}
	}

	private class B7IcImItVfpsbXhKtd6 : ProfessionalColorTable
	{
		private MetroThemeStyle CXIwv0eHSI;

		private MetroColorStyle wpswJwORIQ;

		public override Color MenuItemSelected
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
		}

		public override Color MenuBorder
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
		}

		public override Color MenuItemBorder
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
		}

		public override Color ImageMarginGradientBegin
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
		}

		public override Color ImageMarginGradientMiddle
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
		}

		public override Color ImageMarginGradientEnd
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return (Color)(object)null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public B7IcImItVfpsbXhKtd6(MetroThemeStyle P_0, MetroColorStyle P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static B7IcImItVfpsbXhKtd6()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			WZoe9Opiuif0IJrguVgr();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void dNfmerpiNeyvaTg6rMtB()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void zbybjrpi11BAH0Luq1dN(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool a2HQv4piQ9IEFhSl8fCt()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool VFUDorpiRJNs262jUKxF()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color KR8EoQpiKS6FtMIdV5BS(MetroColorStyle style)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color MT2Xstpi8TQKXGmqrZYX(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void WZoe9Opiuif0IJrguVgr()
		{
		}
	}

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> TI0sbwARG7;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> CT8sEgOnO8;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> mOHsTUKAij;

	private MetroColorStyle ffvsd1onWG;

	private MetroThemeStyle T8Zs3TeKI5;

	private MetroStyleManager WfesKlBh4X;

	private bool gjrsN7qUoX;

	private bool sIHsmSQogn;

	private bool ymysftvVWn;

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

	[Category("Metro Appearance")]
	[Description("使用用户自定义的背景色")]
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
	public MetroContextMenu(IContainer Container)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void veVsIjwQ4B()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroContextMenu()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		PUuou2sOBYDhZt4g2Uu();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool xmvU1ZsBFOYeZpFaT5L(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool GdjGdusC5oCgv5r6SI9()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool C53cM4s0YBM9BOHeEVA()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool f4jTYxsx8Vf6d258Xly(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle FJmConsTvs4n8Hq4RGV(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle mgKoWIst6G7TWG8GEKU(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wfeRUssX2bwjnqQf3iE(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void a8nJFhsZpKl1aiPEWxX()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qTCgiSs45h2xdY2ATV1(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void orUjIps93j9BvXy00o4(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color PiNhvAsrSpJ9c9eDlK0(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void JMnrhls3iNfeNN4v9kr(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color NxpY4esVJgeoekq63I3(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vAhAZGsILuklpp60Qcv(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rEwSiWs23iwfKCEUmlo(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void PUuou2sOBYDhZt4g2Uu()
	{
	}
}
