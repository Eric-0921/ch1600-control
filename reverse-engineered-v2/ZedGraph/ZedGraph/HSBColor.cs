using System;
using System.Drawing;

namespace ZedGraph;

[Serializable]
public struct HSBColor
{
	public byte H;

	public byte S;

	public byte B;

	public byte A;

	public HSBColor(int h, int s, int b)
	{
		H = (byte)h;
		S = (byte)s;
		B = (byte)b;
		A = byte.MaxValue;
	}

	public HSBColor(int a, int h, int s, int b)
	{
		this = new HSBColor(h, s, b);
		A = (byte)a;
	}

	public HSBColor(Color color)
	{
		this = FromRGB(color);
	}

	public static implicit operator Color(HSBColor hsbColor)
	{
		return ToRGB(hsbColor);
	}

	public static Color ToRGB(HSBColor hsbColor)
	{
		Color black = Color.Black;
		int num = (int)Math.Floor((double)(int)hsbColor.H / 42.5);
		double num2 = (double)(int)hsbColor.H / 42.5 - (double)num;
		double num3 = (double)(int)hsbColor.S / 255.0;
		byte b = (byte)((double)(int)hsbColor.B * (1.0 - num3) + 0.5);
		byte b2 = (byte)((double)(int)hsbColor.B * (1.0 - num3 * num2) + 0.5);
		byte b3 = (byte)((double)(int)hsbColor.B * (1.0 - num3 * (1.0 - num2)) + 0.5);
		return num switch
		{
			0 => Color.FromArgb(hsbColor.A, hsbColor.B, b3, b), 
			1 => Color.FromArgb(hsbColor.A, b2, hsbColor.B, b), 
			2 => Color.FromArgb(hsbColor.A, b, hsbColor.B, b3), 
			3 => Color.FromArgb(hsbColor.A, b, b2, hsbColor.B), 
			4 => Color.FromArgb(hsbColor.A, b3, b, hsbColor.B), 
			_ => Color.FromArgb(hsbColor.A, hsbColor.B, b, b2), 
		};
	}

	public Color ToRGB()
	{
		return ToRGB(this);
	}

	public HSBColor FromRGB()
	{
		return FromRGB(this);
	}

	public static HSBColor FromRGB(Color rgbColor)
	{
		double num = (double)(int)rgbColor.R / 255.0;
		double num2 = (double)(int)rgbColor.G / 255.0;
		double num3 = (double)(int)rgbColor.B / 255.0;
		double num4 = Math.Min(Math.Min(num, num2), num3);
		double num5 = Math.Max(Math.Max(num, num2), num3);
		HSBColor result = new HSBColor(rgbColor.A, 0, 0, 0);
		result.B = (byte)(num5 * 255.0 + 0.5);
		double num6 = num5 - num4;
		if (num5 != 0.0)
		{
			result.S = (byte)(num6 / num5 * 255.0 + 0.5);
			double num7 = ((num == num5) ? ((num2 - num3) / num6) : ((num2 != num5) ? (4.0 + (num - num2) / num6) : (2.0 + (num3 - num) / num6)));
			result.H = (byte)(num7 * 42.5);
			if (result.H < 0)
			{
				result.H += byte.MaxValue;
			}
			return result;
		}
		result.S = 0;
		result.H = 0;
		return result;
	}
}
