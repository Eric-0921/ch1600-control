using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Runtime.CompilerServices;
using System.Security;
using System.Windows.Forms;
using DMSkin.Metro;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;
using DMSkin.Metro.Interfaces;
using H7hU6tICQw7ac6Req6J;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin;

public class MetroForm : Form, IMetroForm, IDisposable
{
	private enum DWrG99I3ffVfOoaWeeT
	{

	}

	private class SfvcTFIXlKp2EDq2ImU : Button, IMetroControl
	{
		[CompilerGenerated]
		private EventHandler<MetroPaintEventArgs> SXdwIBfDCC;

		[CompilerGenerated]
		private EventHandler<MetroPaintEventArgs> Ap3wbg97i5;

		[CompilerGenerated]
		private EventHandler<MetroPaintEventArgs> vS6wEITu7p;

		private MetroColorStyle yxUwTaNH9E;

		private MetroThemeStyle YnYwd2bX1E;

		private object kxGw30B537;

		private bool SnswKTDIx5;

		private bool EtGwNF5l0g;

		private bool fgrwmGxct4;

		private bool vn0wf77vrN;

		private bool Tsswym3Cuh;

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

		[Description("使用用户自定义的字体颜色")]
		[DefaultValue(false)]
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

		[DefaultValue(false)]
		[Category("Metro Appearance")]
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
		[Category("Metro Behaviour")]
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
		protected virtual void OnCustomPaintBackground(MetroPaintEventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual void OnCustomPaint(MetroPaintEventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected virtual void OnCustomPaintForeground(MetroPaintEventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		public SfvcTFIXlKp2EDq2ImU()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnPaint(PaintEventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnMouseEnter(EventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnMouseDown(MouseEventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnMouseUp(MouseEventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnMouseLeave(EventArgs P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static SfvcTFIXlKp2EDq2ImU()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			gXKjh1pobXRKdu7mwPf7();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool mlpQjFpoj4OYdNa5Fbuo(object P_0, ControlStyles P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool BuVw1Ppo8MBdtew5xUaL()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool t9FcJSpou9LGCxpVdZe3()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Nejv1vpowmm9UxhJhwIW(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static MetroColorStyle CBXy4npogCuSAoc8ubKT(object P_0)
		{
			return (MetroColorStyle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static MetroThemeStyle Q2QXnopoJrDM4expyOQ7(object P_0)
		{
			return (MetroThemeStyle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void IxyoakpoyhiE15gqKeKw(object P_0, ControlStyles P_1, bool P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ePZtOEpoDt8oLBsp0ixn()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void c0xRtfpoYYhrjYPKnlxU(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object I17buApoefhfY0CK0RtR(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static MetroThemeStyle al8h4epoFD9VEobxpxQt(object P_0)
		{
			return (MetroThemeStyle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color liECybposdrfCUVICmnY(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color DVQ3YspoM18Bv6HvnbtH(MetroColorStyle style)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color DySN29poCGJk8RWvnSlU(object P_0)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool aAiSaApo0hjkSr7YFNB4(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color EX2Vy0poBKQvdJdyvMwV(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color hRnU6Gpoxj7pQglLd33y(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color L56iyqpoTsQGijBE8Oul(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color Lgm8vqpotNLrPqsp57AC(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color ugC3tCpoXKRLmsAt3Urc(MetroThemeStyle theme)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object Nuf1ZcpoZyvFOt6gRMMI(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void dBlBVipo4jZSNP0xV0F8(object P_0, Color P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object lsoW4Bpo9Vh2HNhTtFRn(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Rectangle pAM5rYporFL0p2Q6L6vP(object P_0)
		{
			return (Rectangle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void BBeyFipo3pwPEZpfQwMD(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, Color P_5, TextFormatFlags P_6)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TUblWRpoV0tlEp8V07pc(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void mvUe2MpoIXisqOnB38yJ(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static MouseButtons tL43icpo28VrE9Bbggye(object P_0)
		{
			return (MouseButtons)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void aOqBCIpoOedurk52s8Zs(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void wuCwwFpofBxmF75kqjlR(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void FfH16hpoqrcxho0scR1n(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gXKjh1pobXRKdu7mwPf7()
		{
		}
	}

	protected abstract class MetroShadowBase : Form
	{
		[CompilerGenerated]
		private Form gI0wZXbZkD;

		private readonly int xMQwCbgmTM;

		private readonly int ftVwtXf7qm;

		private bool EbOwRL3v4b;

		private long PFGwBAJAa4;

		protected const int WS_EX_TRANSPARENT = 32;

		protected const int WS_EX_LAYERED = 524288;

		protected const int WS_EX_NOACTIVATE = 134217728;

		protected Form TargetForm
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			get
			{
				return null;
			}
			[MethodImpl(MethodImplOptions.NoInlining)]
			[CompilerGenerated]
			private set
			{
			}
		}

		protected override CreateParams CreateParams
		{
			[MethodImpl(MethodImplOptions.NoInlining)]
			get
			{
				return null;
			}
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected MetroShadowBase(Form targetForm, int shadowSize, int wsExStyle)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Rectangle DqUwAgxw2U()
		{
			return (Rectangle)(object)null;
		}

		protected abstract void PaintShadow();

		protected abstract void ClearShadow();

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnDeactivate(EventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void IvgweK9DQw(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void Gx5wO716e2(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SpecialName]
		private bool n0SwrCE8CQ()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void tDOwwxqH5r(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void ar8wPSQ2BN(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void d0Fw1JqVd0(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void YXcw6FdQj2(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void qTSwkMb98E(object P_0, EventArgs P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void uiDwg0j41p()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static MetroShadowBase()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			MruM2dpWgyBgIYYLBp7u();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool AbuAY1po6qZZXsd6RFZA()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool sw5JrYponQRIhIVv5moq()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gwrklEpoHjEVi9cEmk87()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void wN2Ed0podji9ug4oNcmo(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void X16n4dpoh39ITqEXDJ1S(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void PNJoavpocL0swn9ehhE1(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void vFiauNpo7CJIZvWKq5j9(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void YOARGypoPa4og6vtPBQJ(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void cmDQK0povWEBji1yBqOl(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void voklYepoSYmIxTg75mX3(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void HhNJfopoaxrLBM0f0y5A(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object fhFL2fpoENDspQV0YSaw(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void aMyXTgpoG9bne9knwBe5(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void SCCwJkpok6tdIBu6AOwc(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void wiRjewpoL5Bt4f2lDJQ9(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void LFKJEwpozHmpRW6N3H6n(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void muZANZpWljlqjBsDyIKl(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Lx1P2xpWpbbfr6JKyeuy(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void oYiCTepW5W9NL1b3X7vE(object P_0, FormBorderStyle P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void tuXnywpWANkWmaOtkp9e(object P_0, Rectangle P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object WQU5SLpWoCS4vWtUoN0m(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int RSgZl5pWWH6SGKuWP4xJ(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void GLDgCRpWUduafQ9SXbHG(object P_0, int P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Rectangle KsG6ZepWiX5NwcXYQT50(object P_0)
		{
			return (Rectangle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void h7kJhnpWmXXBLOHJdFuK(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool jRPObKpWQMPMA8x1TNYi(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void gw2pSKpWR5ghRYlH4Gic(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void fE0rJxpWNMA5u6t91Gc6(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void aoChmopW1jYLp5Qmmibs(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool SLV6yFpWKkatBRiOLxkv(object P_0)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static FormWindowState RriGZApW806UTMBfQOUn(object P_0)
		{
			return (FormWindowState)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static DateTime r1ikNFpWu4ewR7taGgSt()
		{
			return (DateTime)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void UWhrOapWjLF0MUkOh5TZ(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void sX14ajpWwI1jkGEi7UMS(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void MruM2dpWgyBgIYYLBp7u()
		{
		}
	}

	protected class MetroAeroDropShadow : MetroShadowBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetroAeroDropShadow(Form targetForm)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void PaintShadow()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void ClearShadow()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static MetroAeroDropShadow()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			EUsRO9pWsSvGNFNWxWjt();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void oWLkyvpWDhO727lyIUhX()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void D218TgpWYQAjpeUQ0Imf(object P_0, FormBorderStyle P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool yBnscUpWJdfpSgKldKbb()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool QvtU91pWyJabvOvkhDfA()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void VZ3wMLpWeWFdo97idQVB(object P_0, int P_1, int P_2, int P_3, int P_4, BoundsSpecified P_5)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void swsXTApWFiQl9hcQXVAo(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EUsRO9pWsSvGNFNWxWjt()
		{
		}
	}

	protected class MetroFlatDropShadow : MetroShadowBase
	{
		private Point MG4waOH5xF;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetroFlatDropShadow(Form targetForm)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnLoad(EventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnPaint(PaintEventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void PaintShadow()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void ClearShadow()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SecuritySafeCritical]
		private void nQmwSyxrpk(Bitmap P_0, byte P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Bitmap KWHwVYA9i3()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Image Ig6wHQB0tC(Color P_0, Rectangle P_1)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static MetroFlatDropShadow()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			dnmTtvpWaxlIPNvl39Dy();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void lFOcPHpW0YkWCkei0gXA()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Q7ipsspWMxcfQ9qBuIw1()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool JMI5AUpWCHWFHlyfmq7e()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void cZ2UEJpWBN5Kb6NyxKaw(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void ttMlfypWxqx1JgE5brZn(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void REmZAqpWTm2rALTowxOf(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void v3JGOJpWtA87DKI46Itv(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int gNLD2EpWXgIdToxKpO4F(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int aPUcdPpWZyq6IeF773sj(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object m0lFMrpW4pbAlx6s68hl(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color TSv8wKpW9nwc4o8fgep0()
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void LVO0NxpWr9U6HjYoi18a(object P_0, Color P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void COAd5epW3RPVb9TBSRwb(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void KN4SJqpWVMlreCkPwxu7(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void P5NiqNpWIRBRqrSp9OMb(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static PixelFormat HWvLh3pW2teJCVrsnSK8(object P_0)
		{
			return (PixelFormat)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color Hcms5CpWOpKYksW21Gs0(int P_0)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr FSlqPkpWfsW4P6deYVcM(object P_0, Color P_1)
		{
			return (IntPtr)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int I2hAjhpWqHcIQDbiBIlZ(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int rr7M1upWbDE9KoLbvvPe(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int pfBtb6pW6QuewQcqP0mL(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int fET9t8pWnfUytqjfsdFM(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr fbI03OpWHiivtUZ9bjAd(object P_0)
		{
			return (IntPtr)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool mOgOcOpWd3iderrsi5Ej(IntPtr P_0, IntPtr P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color T2wRVPpWhmVA1QRtmOX9()
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Rectangle olxqYEpWcCVjvlbcr7fr(object P_0)
		{
			return (Rectangle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void UMZuR0pW7PT4tDK3QdDd(object P_0, SmoothingMode P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void caaVhcpWPNIZGvr1lkGM(object P_0, InterpolationMode P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color rK2TWqpWvK8HTxNZqnus(int P_0, Color P_1)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void OnokcIpWS9osn2KE30Fe(object P_0, object P_1, Rectangle P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void dnmTtvpWaxlIPNvl39Dy()
		{
		}
	}

	protected class MetroRealisticDropShadow : MetroShadowBase
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		public MetroRealisticDropShadow(Form targetForm)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnLoad(EventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void OnPaint(PaintEventArgs e)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void PaintShadow()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		protected override void ClearShadow()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		[SecuritySafeCritical]
		private void mpYwXnh1dk(Bitmap P_0, byte P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Bitmap iFcw0QsrxM()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private Image z8IwxigPNv(int P_0, int P_1, int P_2, int P_3, Color P_4, Rectangle P_5)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		private void t61wuGJX06(Graphics P_0, Rectangle P_1, int P_2, Pen P_3, Color P_4)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static MetroRealisticDropShadow()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			mu9vbRpUrU1hJej5p5Xc();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Nmc943pWkMy6rBDleHZx()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool jbu5dwpWE2t8VBQABMfv()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool tHTsLepWGcuG3NFuxEFr()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void k3qU9MpWLZE7q86GoWqe(object P_0, object P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EWF48ZpWz1wh0oCEsEMb(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void xeGNsYpUlx51Z7PEZ8W6(object P_0, bool P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EBiR3fpUph6MAAnB8vrf(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int ARsqmTpU5ZNPf10C3Z9w(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int F4VWuHpUAcRSDautU6t4(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object jvwNVIpUolO7CPkW856C(object P_0)
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color ywf8nTpUW3ncRqJxeGx5()
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void CGISPxpUUvkodhgopQ5p(object P_0, Color P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DPh0xwpUiiLeoucAw3KZ(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void dvC6ALpUmEX0EorNJWWQ(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void QOcSbLpUQVh9mOpW2QAw(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static PixelFormat PwVORepURN4rpvMcejqX(object P_0)
		{
			return (PixelFormat)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color JKTK8rpUN23d1oXThX1V(int P_0)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr n7Pf8jpU1WAAiGcFBKH3(object P_0, Color P_1)
		{
			return (IntPtr)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int j9sZaJpUKqWyDOv65yq8(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int evS2GnpU8y1LdoQN5dkn(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int JOsZqBpUu73IlvB3vuqv(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int L1bDKApUjfBdTUBJ9QmX(object P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static IntPtr BOXAyTpUw93sCnbpWdjL(object P_0)
		{
			return (IntPtr)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool rQ7WvYpUg3r6FI39Ui00(IntPtr P_0, IntPtr P_1)
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color jds3UApUJwN91Ua4SiTb()
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Rectangle d1Z4ixpUyoAfycvAlFkA(object P_0)
		{
			return (Rectangle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void JlLdhFpUD9red3FUo9y9(object P_0, SmoothingMode P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Vy6XfNpUYnp1RjqdSNWX(object P_0, InterpolationMode P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color nFiCsLpUe9v3uTSwXLQF(int P_0, Color P_1)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static object XkIktopUFAd2ZcsYHM5b()
		{
			return null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static float UC92ripUs68DkhDqA0mO(object P_0)
		{
			return 0f;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static double RPmAhipUMpxk0JMrlQHC(double P_0)
		{
			return 0.0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static int r2Jb14pUCm6iD0RrLh1Q(double P_0)
		{
			return 0;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Rectangle Hwf6XKpU0Ov1pWq7N8lJ(Rectangle P_0, int P_1, int P_2)
		{
			return (Rectangle)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void myqkkdpUBZGUyaeamC3F(object P_0, int P_1, int P_2, int P_3, int P_4, float P_5, float P_6)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void BLkFCKpUxM5WNHFu7H1M(object P_0, Rectangle P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void wqTQIupUTuLqjCUZ6WRN(object P_0)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void U10YTNpUtmbq1q1yhCs1(object P_0, object P_1, object P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static Color WCuGAFpUX7Z9bAjHkVLy(object P_0)
		{
			return (Color)(object)null;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void lCQTYgpUZStJlHGm9Uy4(object P_0, LineCap P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void GLE8rspU4dRx2VJC7XtB(object P_0, LineCap P_1)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void DsnGcxpU98Yi0xMnaRsi(object P_0, object P_1, object P_2)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void mu9vbRpUrU1hJej5p5Xc()
		{
		}
	}

	private MetroColorStyle ouyFlKbAht;

	private MetroThemeStyle SMiFIoAOy4;

	private MetroStyleManager mbDFbf6YgX;

	private MetroFormTextAlign GXuFE12Rwc;

	private MetroFormBorderStyle sZQFTGZZqJ;

	private bool jLjFdPnlyo;

	private bool yFFF3Di4GJ;

	private bool Bq4FKf3Aa9;

	private MetroFormShadowType p2DFNXwRxf;

	private Bitmap QTDFmbalHW;

	private Image wMKFfGZ3R0;

	private Padding BMwFye0PKm;

	private int TGcFA4hgmH;

	private BackLocation GyaFeMM9QM;

	private bool CCDFOAoCQ2;

	private Dictionary<DWrG99I3ffVfOoaWeeT, SfvcTFIXlKp2EDq2ImU> k1GFwJ5bot;

	private Form HiQFPWhMax;

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

	[Browsable(true)]
	[Category("Metro Appearance")]
	public MetroFormTextAlign TextAlign
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroFormTextAlign)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Browsable(false)]
	public override Color BackColor
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Color)(object)null;
		}
	}

	[DefaultValue(MetroFormBorderStyle.None)]
	[Category("Metro Appearance")]
	[Browsable(true)]
	public MetroFormBorderStyle BorderStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroFormBorderStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public bool Movable
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

	public new Padding Padding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Padding)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	protected override Padding DefaultPadding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Padding)(object)null;
		}
	}

	[DefaultValue(true)]
	[Category("Metro Appearance")]
	public bool DisplayHeader
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
	public bool Resizable
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

	[DefaultValue(MetroFormShadowType.Flat)]
	[Category("Metro Appearance")]
	public MetroFormShadowType ShadowType
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MetroFormShadowType)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Browsable(false)]
	public new FormBorderStyle FormBorderStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (FormBorderStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	public new Form MdiParent
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

	[DefaultValue(null)]
	[Category("Metro Appearance")]
	public Image BackImage
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
	public Padding BackImagePadding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Padding)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Category("Metro Appearance")]
	public int BackMaxSize
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
	[DefaultValue(BackLocation.TopLeft)]
	public BackLocation BackLocation
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (BackLocation)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(true)]
	[Category("Metro Appearance")]
	public bool ApplyImageInvert
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

	protected override CreateParams CreateParams
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public MetroForm()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Bitmap ApplyInvert(Bitmap bitmapImage)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private TextFormatFlags kNb7Giy87w()
	{
		return (TextFormatFlags)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnClosing(CancelEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnClosed(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	public bool FocusMe()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLoad(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnActivated(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnEnabledChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResizeEnd(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void WndProc(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void Klg7zP39GL(IntPtr P_0, IntPtr P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private GbXFWgIj0HDyQOIOWHC.D4O9ThIzAholiZEx0Kh C4RFq402In(IntPtr P_0, IntPtr P_1, IntPtr P_2)
	{
		return (GbXFWgIj0HDyQOIOWHC.D4O9ThIzAholiZEx0Kh)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseDown(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private void Bn0Fja8B5T()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	private static bool PvYF7NMDDk()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private static bool IH1FFmZyr1()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void XDkFUS38M4(DWrG99I3ffVfOoaWeeT P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void OGAF2q7UHB(object P_0, EventArgs P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void G44FpjSjec()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void iCOFoJ8SJo()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void pfZFsZumox()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[SecuritySafeCritical]
	public void RemoveCloseButton()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private Rectangle QrWFLm6wOJ(Graphics P_0, Rectangle P_1, Font P_2, string P_3, TextFormatFlags P_4)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static MetroForm()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		Wcr6NaRmbtxd0eD2rpc();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroColorStyle S8AEVvm0xFGJQYr5r5V(object P_0)
	{
		return (MetroColorStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool cCIokQmMOI5N5aiDpYx()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool AatP2RmCDM3idMPNAnc()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MetroThemeStyle RhSZYwmBuL6ObkS5Jhp(object P_0)
	{
		return (MetroThemeStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color pWZGm9mx3n8iN6pOR9s(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Padding hBNgMZmTI8nckalnPUr(object P_0)
	{
		return (Padding)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int FVn4JZmtPQR3yGCUKUS(int P_0, int P_1)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wC9uGxmXg4V5bpZFU89(object P_0, Padding P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool GDx1MtmZbNfQt8IJxvp(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FormBorderStyle OF42Zqm4um6NTLwuVhj(object P_0)
	{
		return (FormBorderStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dN9bQJm9K6nEsi6QODe(object P_0, FormBorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object Xkx0RGmr3tEdrIrtOUI(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NOi20Fm3RJfrswEB3xi(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lRMgA7mVumXm8GIa1Qi(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zNghDwmIFRYkuUOcaIc()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void uc41QOm2b4pl1cW64Zu(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RnkZBumOHeya4aM1u4v(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lAyvo5mfaxTiSLY2oYO(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CkW1I8mqN6v2TMWQwpx(object P_0, FormStartPosition P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color RTaYSRmbw5f0fpPhq5h()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zxvnB4m6IhonSxn7UZp(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Y7VXr3mnU8xNYEwOyLd(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color hgHarmmHKS1wmCwpVUa(object P_0, int P_1, int P_2)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color CGdg6DmdMsgrk6OQvMN(int P_0, int P_1, int P_2)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FeTQtMmhwG8rmqfUfbC(object P_0, int P_1, int P_2, Color P_3)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int LH7MDBmc9B34vpBrOoL(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int v2fRw0m7vmc6rMt1nEu(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color uKbHwxmP7rKBYj3Fxp2(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object w1o659mvTE7GsdbjbsS(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void G2HwO3mStQmdmpfOOOD(object P_0, Color P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object oUvewjmaDGg9fEJMODM(MetroColorStyle style)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int aehkoGmE87qjPfyd3QS(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LYRuCjmG1jUxi7MPclh(object P_0, object P_1, Rectangle P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void YnOn96mk1cBBKFknuh6(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color LWIBHrmLGpYURqNeUd5(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int aW6AgXmzCFaLDRrSpCX(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RgGDPQQlG87vrWEdYV2(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object gpu01uQpgXWFv4PIypS(object P_0, Rectangle P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void BWZn6bQ5dRoWSOlJI8D(object P_0, object P_1, int P_2, int P_3)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle MkSQf1QAWRnSdp2flhB(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object w5w8LbQo9QADYlh3v0B(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object YioEoiQWqSInAAZYCZF()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fRTRexQUc18XbnCoZ9o(object P_0, object P_1, object P_2, Rectangle P_3, Color P_4, TextFormatFlags P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static SizeGripStyle jy9WUBQiu3ydYVI1WIZ(object P_0)
	{
		return (SizeGripStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color RufWWXQmBZ21IPXqOE8(MetroThemeStyle theme)
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void oMgQ1xQQypt8BqIK0Im(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kHxUjZQRndNH511w1c1(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void prdwOZQN8l3XiHcD9ug(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr ryKGVKQ1laqemMUKRcb(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Hbiy3GQKAqWMkdffR87(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool iUruTsQ8bBn7wIVYsgJ(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FormStartPosition WdjmWCQut4niSDwdEt4(object P_0)
	{
		return (FormStartPosition)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rtJpuGQjr0vZ7D91jq8(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void s27W4JQwh8LHb5quQ4X(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool sgeqYsQgUnpFsj6H2sP(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool X9lmWDQJaYdcSxi9Xjj(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool Nn6DkgQy7SgpVP0F4s1(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void sZygJSQD045NCirBpsq(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool IPIMcrQYZfV0tA514K1()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool Q38AwKQe5PotiWYL21h()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void uK1sD4QFPD6Uotb3StS(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pymPT8QshqIJ59OrAHA(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jTrphUQMqBWk7vFIXKG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr lgDldbQC4PtcCSTW1Dx(int P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object BMgYkoQ0yxW7BsjMSFy(IntPtr P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle gkhyEjQBXuHnip8RoOZ(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle og9XSPQx8gqd0x2TFV8(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int hM0rmdQTIJ9mVfieHcD(int P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int LXpLddQtO1YDQ7XoqNS(IntPtr P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle IvRrtaQX111iReQVstA(object P_0, Rectangle P_1)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tlIP4IQZeOLbwHQ6xXf(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons BDmFG4Q4sFe6HjykT97(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FormWindowState i2DLyXQ9RAw9NHrHrj9(object P_0)
	{
		return (FormWindowState)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point pmCpRmQrciVTRJGErd6(object P_0)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ssTqUBQ3slw3mwQWSRP()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object JgcvUZQVgO5YxtAFCDP(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int p8PhSrQILB167MSP2AB(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool AMWU7EQ2JffVcimaejV()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hGadnhQO1GdUxt3w4MF(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void M4IYirQf2S2WZsV4bIY(object P_0, MetroColorStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zHkxKiQq8cHfs5XUiex(object P_0, MetroThemeStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void V6EtcNQbeXU1dYOUrIA(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void oAKUctQ61aDZGoGeBjC(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qlb0phQn4cSdWo2ONlK(object P_0, AnchorStyles P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void mMVgQNQHHqqjpQJojHm(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void MrwsDwQdkdKYAKYrwD3(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object skvTaTQh3oY2OOkymuj(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void SnVXHGQcpR5gumy4FtL(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object L6y5UMQ759wXnkq7N65(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ctsgesQPWoKlJH3P5OB(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void NWWY8EQvfpsJH4cv6UI(object P_0, FormWindowState P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int GiIL4fQSjIHn1I6ieHU(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LiMfRtQaAjbMe4bVQeP(object P_0, Point P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object uvxTSLQEtlbyZhXsbX0(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int C9jPT8QGbbWbHaYmL90(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XJL5d8QkGbeR3CR4EHY(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int o5GMYCQLlUcp2M58LqM(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zSb6qMQzFxLYX1qD0Ru(object P_0, int P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool JUVDLZRlpVO5TCV1Mso(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void IpbQifRpaSyl522etEC(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object P7FkD7R5VpP1W4xd8qy(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void E7qcfKRA5S7gRROrAnx(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void INNCQqRoxIB3BfD1yPP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zbSSFWRW8eVwWSaspJm(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool qPJCO4RUlPmGim2iEeD(IntPtr P_0, IntPtr P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size R4VLDWRi4S8V7YhROkM(object P_0, object P_1, object P_2, Size P_3, TextFormatFlags P_4)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Wcr6NaRmbtxd0eD2rpc()
	{
	}
}
