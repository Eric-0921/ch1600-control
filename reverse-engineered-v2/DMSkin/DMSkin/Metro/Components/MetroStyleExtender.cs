using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.Metro.Interfaces;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Metro.Components;

[ProvideProperty("ApplyMetroTheme", typeof(Control))]
public sealed class MetroStyleExtender : Component, IExtenderProvider, IMetroComponent
{
	private MetroThemeStyle htKTEgwUV7;

	private MetroStyleManager LwuTTZhK96;

	private readonly List<Control> iPMTdWkw6M;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
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

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroStyleExtender()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroStyleExtender(IContainer parent)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void JLvTb2TBA3()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	bool IExtenderProvider.CanExtend(object target)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[Description("Apply Metro Theme BackColor and ForeColor.")]
	[Category("Metro Appearance")]
	[DefaultValue(false)]
	public bool GetApplyMetroTheme(Control control)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void SetApplyMetroTheme(Control control, bool value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroStyleExtender()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		IpQRncfNpENDQMrRHdk();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool earJHXf50ru1J0f10wH(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle XtUjd0fAbtITQUgZ6xs(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool hF7gAQflYoxDfll1MIN()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool lwWxdYfplBwBttpG9ia()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rjawy2fo26DL1OQ8fOP()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void E074DBfW5s9gQweEJne(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void arqJ0WfUIgxvt0OZqAQ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color PXtCcOfiZuiuqyhIxEY(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color GNlu4Kfmc1qiP7p8f7k(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zw9KVCfQvmgC3fFWvE0(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VRECQAfRVipMcf68vd0(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IpQRncfNpENDQMrRHdk()
	{
	}
}
