using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using DMSkin.SkinClass;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin;

public class Main : Form
{
	public MainForm skin;

	private SkinFormRenderer uH676anmoe;

	private RoundStyle XAd7ktaBTN;

	private Rectangle lDx7gJwXu8;

	private int gDc7Dvi8eU;

	private bool jIk7r3OgUQ;

	private Padding hEo79ijLI9;

	private ToolTip gvg7ZtxIrI;

	private MobileStyle BBI7CYwpI6;

	private static readonly object Gj57tOmCul;

	private bool ADc7RWclDX;

	private int VcF7B47MZY;

	private bool uFr7SkVDwn;

	private bool OK17VhBaPs;

	private Padding zNs7HBRcKT;

	private bool T5m7aROKdE;

	private bool WOZ7XanA9c;

	private Color Cbm701vkvG;

	private int jYW7xPAGx5;

	private SkinFormColorTable eox7uSMtYw;

	private bool cJy7vpPlvE;

	public bool isMouseDown;

	public AnchorStyles Aanhor;

	[Description("可以用鼠标拖动改变窗体大小")]
	[DefaultValue(true)]
	public bool DM_CanResize
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

	[Description("可以用鼠标拖动窗体位置")]
	[DefaultValue(true)]
	public bool DM_CanMove
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

	protected internal Padding DM_BorderPadding
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

	[Category("Skin")]
	[DefaultValue(true)]
	[Description("是否在窗体上绘画边框")]
	public bool DM_howBorder
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
	[Description("是否启用窗体阴影")]
	[Category("Shadow")]
	public bool DM_Shadow
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

	[Description("窗体阴影颜色")]
	[DefaultValue(typeof(Color), "Black")]
	[Category("Shadow")]
	public Color DM_ShadowColor
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

	[Description("窗体阴影宽度")]
	[Category("Shadow")]
	[DefaultValue(typeof(int), "2")]
	public int DM_ShadowWidth
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

	public SkinFormColorTable Colortable
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

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	[Browsable(false)]
	[Description("设置或获取窗体的绘制方法")]
	public SkinFormRenderer Renderer
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

	[DefaultValue(typeof(RoundStyle), "1")]
	[Category("Skin")]
	[Description("设置或获取窗体的圆角样式")]
	public RoundStyle DM_RoundStyle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (RoundStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[DefaultValue(typeof(MobileStyle), "2")]
	[Category("Skin")]
	[Description("移动窗体的条件")]
	public MobileStyle DM_Mobile
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (MobileStyle)(object)null;
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		set
		{
		}
	}

	[Description("设置或获取窗体的圆角的大小")]
	[Category("Skin")]
	[DefaultValue(1)]
	public int DM_Radius
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

	[DefaultValue(typeof(Padding), "0")]
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

	public override Rectangle DisplayRectangle
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Rectangle)(object)null;
		}
	}

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

	protected override Padding DefaultPadding
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Padding)(object)null;
		}
	}

	protected Rectangle RealClientRect
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return (Rectangle)(object)null;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	public Main()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnCreateControl()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnClosed(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnVisibleChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLoad(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void OnRendererChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseMove(MouseEventArgs e)
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
	protected override void OnMouseDoubleClick(MouseEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseLeave(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnMouseHover(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnLocationChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void HUR7fK5flv()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnPaint(PaintEventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void WndProc(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void Dispose(bool disposing)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnStyleChanged(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetClientSizeCore(int x, int y)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Size SizeFromClientSize(Size clientSize)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override Rectangle GetScaledBounds(Rectangle bounds, SizeF factor, BoundsSpecified specified)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void ScaleControl(SizeF factor, BoundsSpecified specified)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected override void OnResize(EventArgs e)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void ResizeCore()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void CalcDeltaRect()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void WmWindowPosChanged(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void WmNcRButtonUp(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void TrackPopupSysMenu(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected void TrackPopupSysMenu(IntPtr hWnd, Point point)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected virtual void WmNcCalcSize(ref Message m)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void cZ97yHceZV(ref Message P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Joi7A9B0E8(ref Message P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void VEq7ejFP26(ref Message P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void Jat7OgLM8s()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void hqa7wVoWh4()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void qWp7PfKsLm()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	private void w2G71UvNpS()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Main()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		_ = 1;
		int num = ((!KxM0gOW0Hka022RYXyi()) ? 1 : 3);
		while (true)
		{
			switch (num)
			{
			case 0:
			case 1:
				utMZnhiiNhfbrTtqZEh();
				num = 4;
				continue;
			case 4:
				H2c7y7WBv4itv3gXfaE();
				break;
			case 5:
				return;
			}
			Gj57tOmCul = new object();
			num = 5;
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void H2c7y7WBv4itv3gXfaE()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Color d1s8jnWxuZwU65grHWe()
	{
		return (Color)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Of99R7WTvyA6vHCDviX(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool WOHkdGWCIevgInLeMqm()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool KxM0gOW0Hka022RYXyi()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void R86DdVWtExCcNNu27Ks(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool utDJKkWXywMo2mnMCRC(Color P_0, Color P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void RS2VCuWZjElk8vkGYJH(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nKbWGyW4ym0EbiPkFEQ(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void R3xpqXW9GT0XJ4sUJcQ(object P_0, Padding P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FormBorderStyle G2oV8NWrSN4NPCYjNx0(object P_0)
	{
		return (FormBorderStyle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void tbe0VlW37W8HufnDFOT(object P_0, FormBorderStyle P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static FormWindowState UUrDcsWVMHrSP3nhCoe(object P_0)
	{
		return (FormWindowState)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int z4uJdAWIyNAEIcg6iBH(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int lSSO3uW27TqNVoE3wOi(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size dCBaUSWOrsMBLROaGfK(object P_0)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void EmkERuWf7wP1dXDQdeO(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void kr4aokWqN31iqs47iCj(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void i3NArqWbHRT18noHW8Y(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool cXBsfqW6egPQF1YqFMx(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool WAcpZuWnaas1aMPhoHD(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void HGp19lWH5irujtS0q4C(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void TRLlG9WdKqJSfgH2yBI(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iUJZplWhExegEOMLROH(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void UCvS0eWcDbc7X6BjNTw(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nckwgdW7jU6QAFY2dcq(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object zGRwUuWPYxYWM92wA0o(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object n9r3tkWvvJm0iUopLNt(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OcN4PEWS4VsrIOqObPf(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Mj8cUPWag5afuuUMUoY(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OPkA6nWEOsa7gFyys2K(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point FSLRShWGn5jkeKDwaHY(object P_0)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static MouseButtons IAnQ59WkPbF8o0fTyOD(object P_0)
	{
		return (MouseButtons)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int SgFWEDWL2wLVmfSQGOe(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static IntPtr L8r3AAWznfsG8ywXnAt(object P_0)
	{
		return (IntPtr)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void X2QuHXUlIt1XwCCeZNX(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void lDnxPdUpDDEyYo7V3Id(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vX69vuU5dgvqvdGnYQP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void Y04LlTUADauHdcL5JLC(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool ygXBV0UoAeg7GkQRtA6(object P_0)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void up2Ko9UW344MRVKIr25(object P_0, FormWindowState P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int icfiY4UU5rKnVAgaZl6(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void k9nAiCUijjHV7xL7vSP(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void jJmknGUmrG5kbnw4gyC(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CbEy7GUQU9Tscnkkl4C(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void fjJy5GURMvnrVOfi9x6(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int snZOZfUNZaqiIUiSi58(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object P1i55CU1sH1ZnOj5saW()
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle I4xrb0UKMjHCCCZm0th(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static int coaxOWU8CIbHQJgKdjd(object P_0)
	{
		return 0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void dSOJwlUufccd0ntcCZw(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object qdFoEIUjBd8XxBABhGZ(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void hyGNJZUwwE9nB87ipss(object P_0, SmoothingMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void aWfNYkUgsONxDQFC8ic(object P_0, PixelOffsetMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle qtylENUJOxkPwCnoxCY(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void CDGM6AUyec9md7hTV0r(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qaBqK3UDoTKCCslHTvj(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KmA2gdUYXWRi0rLrdK5(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size Ojq8ssUeXC2pBDtPLxC(object P_0)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void f0EB6vUF9UkrReapvlD(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void M9LdBJUscHjUxWCAliX(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static RuntimeTypeHandle yVfDDDUMbADxe8W1OoY(int token)
	{
		return (RuntimeTypeHandle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Type sabCArUCyU259XUagRi(RuntimeTypeHandle P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XxkuA2U0FEc8dE1xroJ(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void coCX0vUB8OINMZGIsSq(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object hkxH4UUx3P7BHunsBTM(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zQtphcUTB2HQsO1HmWG(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void KC6BQXUtxcDafDydtgR(object P_0, int P_1, int P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle toKnj0UXTcOHvdxvUCP(object P_0, Rectangle P_1, SizeF P_2, BoundsSpecified P_3)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size X9JIYqUZk5Fk9I08XHv(object P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool pYh6pSU46ym4nWhKf1F(object P_0, ControlStyles P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static double KGgk2iU9Jyw6qmBL1ob(double P_0)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size D7S07hUrJefE7vBAYWX(object P_0)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size DA3pM3U3nm8qvjTaMdA(object P_0)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pBD762UVgTQoTocBRdw(object P_0, SizeF P_1, BoundsSpecified P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool FwTmNTUIBDurdxSKGBA(Size P_0, Size P_1)
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size akDVxkU2E9JSf7H5pNj(Size P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Size KkxGgdUOCiKWqDw1FAt(Size P_0, Size P_1)
	{
		return (Size)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DglJnRUffKSFNktuiAm(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void wcVJxoUqlAkjgRUPDh9(object P_0, Size P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void T2b9kFUbEMoA7uHK3ee(object P_0, int P_1, int P_2, int P_3, int P_4, BoundsSpecified P_5)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void ztTRPHU6Jg7dlqASqpN(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle T4qmtyUnt8vnFL5K6sw(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Rectangle tFmm6nUHowTcDLfcaLc(object P_0)
	{
		return (Rectangle)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static double dFX51QUdfDxjKQunlh6(object P_0)
	{
		return 0.0;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Point GBHSaZUh3BnQ4kgFJNC(object P_0, Point P_1)
	{
		return (Point)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object Ct9c4kUcbykXEtJQ4I7(IntPtr P_0, Type P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void BjBNS2U7MGmovPO2gv8(object P_0, IntPtr P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void X8yeidUPRsjlPjdQowl(object P_0, ControlStyles P_1, bool P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void FqFMYTUvuCiqn96ssTM(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void O5GXOeUS9SsNjQmXjIF(object P_0, AutoScaleMode P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object ke75QNUac401qT6aHYH(object P_0)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void pZft5eUEJupJIECK1ym(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rrMkovUGUvns2ccUFCA(object P_0, Rectangle bounds, int radius, RoundStyle roundStyle)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void T9iQf7Uk5JZh5feCNml(object P_0, ImageLayout P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static Padding s31ZlTULmIlTWDeQM7M(object P_0)
	{
		return (Padding)(object)null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nJ0kjBUz59lbWOCS01w(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void OrckVMilc6t7JSUM340(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object PbnKeZipMrxXVEjsPFp(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void LhbF67i5weiF7RXEobb(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void DOZFLeiALZoCgoFtdTU(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vUj2uwionZKhsT64gZ5(object P_0, FormStartPosition P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void o35mxIiWuuGlEi38oK6(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XBfjtFiUO1r2r23v1gI(object P_0, bool P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void utMZnhiiNhfbrTtqZEh()
	{
	}
}
