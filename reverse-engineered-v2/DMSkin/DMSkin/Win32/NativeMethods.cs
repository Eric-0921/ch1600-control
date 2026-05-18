using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.Win32;

public class NativeMethods
{
	public struct Size
	{
		public int cx;

		public int cy;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Size(int x, int y)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Size()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			EeGnf0pRwcqXggfFPuYf();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void wqrfeKpRjHSt6Ti8Rhm8()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool mffFAhpR8NbFuUdFRdMs()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool njtsROpRup9J0B7rM295()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void EeGnf0pRwcqXggfFPuYf()
		{
		}
	}

	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct BLENDFUNCTION
	{
		public byte BlendOp;

		public byte BlendFlags;

		public byte SourceConstantAlpha;

		public byte AlphaFormat;
	}

	public struct Point
	{
		public int x;

		public int y;

		[MethodImpl(MethodImplOptions.NoInlining)]
		public Point(int x, int y)
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		static Point()
		{
			cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
			MlKpJZpReGpOLGxSHCl9();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void iUEpdZpRYnTJCIj6Nob8()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool X1asCQpRywsLJg1SKnFx()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool QYSwIvpRDO97mp26ggCJ()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void MlKpJZpReGpOLGxSHCl9()
		{
		}
	}

	public const int ULW_ALPHA = 2;

	[MethodImpl(MethodImplOptions.NoInlining)]
	private NativeMethods()
	{
	}

	[DllImport("user32.dll")]
	public static extern bool ReleaseCapture();

	[DllImport("user32.dll")]
	public static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);

	[DllImport("user32.dll")]
	public static extern IntPtr TrackPopupMenu(IntPtr hMenu, int uFlags, int x, int y, int nReserved, IntPtr hWnd, IntPtr par);

	[DllImport("user32")]
	public static extern int GetWindowLong(IntPtr hwnd, int nIndex);

	[DllImport("user32.dll")]
	public static extern int SetWindowLong(IntPtr hwnd, int nIndex, int dwNewLong);

	[DllImport("user32.dll")]
	public static extern IntPtr GetDC(IntPtr handle);

	[DllImport("user32.dll")]
	public static extern int ReleaseDC(IntPtr handle, IntPtr hdc);

	[DllImport("user32.dll", SetLastError = true)]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool PostMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);

	[DllImport("user32.dll")]
	public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

	[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern bool UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pprSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

	[DllImport("gdi32.dll")]
	public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

	[DllImport("gdi32.dll")]
	public static extern bool DeleteDC(IntPtr hdc);

	[DllImport("gdi32.dll", ExactSpelling = true)]
	public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

	[DllImport("gdi32.dll")]
	[return: MarshalAs(UnmanagedType.Bool)]
	public static extern bool DeleteObject(IntPtr hObject);

	[MethodImpl(MethodImplOptions.NoInlining)]
	static NativeMethods()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		VE7tIdp5PDpKl6Cc4Pte();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void QmR9ylp5colc3W5f3lGb()
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void opxPXcp57yU3blEaWQJo(object P_0)
	{
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool VhqoVJp5dHCKSA9MkIeP()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static bool FDxKOxp5hSOPZnbHdRiK()
	{
		return true;
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void VE7tIdp5PDpKl6Cc4Pte()
	{
	}
}
