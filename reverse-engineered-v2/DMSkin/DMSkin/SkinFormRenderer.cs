using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Security.Permissions;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin;

public abstract class SkinFormRenderer
{
	private EventHandlerList shCjKBxrjs;

	private static readonly object Y5ujNFuFvS;

	private static readonly object HgFjmgKlZh;

	private static readonly object cvpjfb3CAe;

	protected EventHandlerList Events
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		get
		{
			return null;
		}
	}

	public event SkinFormBorderRenderEventHandler RenderSkinFormBorder
	{
		[MethodImpl(MethodImplOptions.NoInlining)]
		add
		{
		}
		[MethodImpl(MethodImplOptions.NoInlining)]
		remove
		{
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	protected SkinFormRenderer()
	{
	}

	public abstract Region CreateRegion(Main form);

	public abstract void InitSkinForm(Main form);

	[MethodImpl(MethodImplOptions.NoInlining)]
	public void DrawSkinFormBorder(SkinFormBorderRenderEventArgs e)
	{
	}

	protected abstract void OnRenderSkinFormBorder(SkinFormBorderRenderEventArgs e);

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
	protected void AddHandler(object key, Delegate value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	[UIPermission(SecurityAction.Demand, Window = UIPermissionWindow.AllWindows)]
	protected void RemoveHandler(object key, Delegate value)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	static SkinFormRenderer()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		int num = 5;
		while (true)
		{
			switch (num)
			{
			case 5:
				qNonIK53VbdmbfCVvJy();
				num = 6;
				if (true)
				{
					break;
				}
				goto case 3;
			case 3:
				HgFjmgKlZh = new object();
				goto case 0;
			case 6:
				XXAYsV5TM8fNTlpOf2D();
				efifWD5BINa5vCIrKIK();
				if (jKBxDu5xA1OY7wBU6pT())
				{
					num = 0;
					break;
				}
				num = 1;
				if (0 == 0)
				{
					break;
				}
				goto case 0;
			case 0:
			case 4:
				cvpjfb3CAe = new object();
				num = 7;
				break;
			case 1:
			case 2:
				Y5ujNFuFvS = new object();
				goto case 3;
			default:
				num = 3;
				break;
			case 7:
				return;
			}
		}
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void XXAYsV5TM8fNTlpOf2D()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void iDg4xO5tUj6Z8G9ir6r(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool efifWD5BINa5vCIrKIK()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool jKBxDu5xA1OY7wBU6pT()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void rkWeCX5XnhEaXq094P0(object P_0, object P_1)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static object G7TO145ZdYgiAFV6vWb(object P_0, object P_1)
	{
		return null;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void v01rLS54HlNk9tFhh8r(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void nVPG5459pXsB1O3jRMx(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void zcdPop5rXUZJATHMCRo(object P_0, object P_1, object P_2)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void qNonIK53VbdmbfCVvJy()
	{
	}
}
