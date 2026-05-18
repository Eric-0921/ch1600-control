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

public class MetroUserControl : UserControl, IMetroControl
{
	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> KyDTFPBgOC;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> PKSTU3pYnB;

	[CompilerGenerated]
	private EventHandler<MetroPaintEventArgs> LcxT2IgX5k;

	private MetroColorStyle Jw3Tpa6BZZ;

	private MetroThemeStyle oaCTo2w67J;

	private MetroStyleManager exdTsQfgTx;

	private bool k7jTLheDff;

	private bool aO4TldLovt;

	private bool iRVTIZB89f;

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

	[Category("Metro Appearance")]
	[DefaultValue(false)]
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

	[Browsable(false)]
	[DefaultValue(false)]
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
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroUserControl()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroUserControl()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		nT8LgdOzlOCsEXFJ4Th();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool F2IFMUO2xp1LLJl4JID(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool nGBR9ZOVGLqBnoDSlqT()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool WXsxKuOIEIXTY2ckC1Z()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool lchRAGOORfLLwu58iZd(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle XQGUE1OfQYlUtbZfx88(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle PMI7SKOqxkdRRi5blrf(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rs1ajnObGKnBvLad1t2(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color ut8rjIO6IA5qj3gMtWj(object P_0)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color t0GCLkOnuJUOeL6Qvlt(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object rTAZ59OHX0rwNO77Hj3(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ctlcDTOddDrZP9Aft8C(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RffJoLOhTjL2P7JB0f5(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void EQwcF4OcEOcEQ9jfdDu(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void O7GdZvO7GmCKBmqJBlq(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wBYr3FOP4VDC1ulk5rH(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Db0f8iOv73N3YXMKMtX(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void yF29YhOS8UhXYosqlq6(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void f9ZTrvOaLBRGZ8mJCQj(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qNe9rZOESWx4upHEY3O(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QlOONBOGDIlTOeiA7Sd(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HBvJ9GOk9XgMyMJLNpN()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void cQI4O4OLm9d8kaBpLCT(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nT8LgdOzlOCsEXFJ4Th()
	{
	}
}
