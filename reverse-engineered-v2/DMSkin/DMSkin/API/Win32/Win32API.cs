using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using QICRVTTCyDiJuV7eLP6;

namespace DMSkin.API.Win32;

public static class Win32API
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
			Rf66FCpRBNwG67J2Gj2T();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void FSAr8vpR0qS6UrC2Rdv8()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool J4sZhxpRMmqkTqZJDRH1()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool Xxv6uGpRCWIp9NOBtVcO()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void Rf66FCpRBNwG67J2Gj2T()
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
			TQQdMlpR4QOiHFsFoOPa();
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void i1CFBOpRZ0Ui1GlWTSN2()
		{
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool NNZNcPpRttNQQXlmchqS()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static bool ex61AMpRX6iIdOVebnYy()
		{
			return true;
		}

		[MethodImpl(MethodImplOptions.NoInlining)]
		internal static void TQQdMlpR4QOiHFsFoOPa()
		{
		}
	}

	public const byte AC_SRC_OVER = 0;

	public const int ULW_ALPHA = 2;

	public const byte AC_SRC_ALPHA = 1;

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr CreateCompatibleDC(IntPtr hDC);

	[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern IntPtr GetDC(IntPtr hWnd);

	[DllImport("gdi32.dll", ExactSpelling = true)]
	public static extern IntPtr SelectObject(IntPtr hDC, IntPtr hObj);

	[DllImport("user32.dll", ExactSpelling = true)]
	public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern int DeleteDC(IntPtr hDC);

	[DllImport("gdi32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern int DeleteObject(IntPtr hObj);

	[DllImport("user32.dll", ExactSpelling = true, SetLastError = true)]
	public static extern int UpdateLayeredWindow(IntPtr hwnd, IntPtr hdcDst, ref Point pptDst, ref Size psize, IntPtr hdcSrc, ref Point pptSrc, int crKey, ref BLENDFUNCTION pblend, int dwFlags);

	[MethodImpl(MethodImplOptions.NoInlining)]
	static Win32API()
	{
		cZBKs5Tj9hVN4MQE4Vn.y0h63WOi92();
		vsVlqfpAvA14iDOJ8ZjO();
	}

	[MethodImpl(MethodImplOptions.NoInlining)]
	internal static void vsVlqfpAvA14iDOJ8ZjO()
	{
	}
}
