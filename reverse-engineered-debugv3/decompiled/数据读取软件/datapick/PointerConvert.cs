using System;
using System.Runtime.InteropServices;

namespace datapick;

public class PointerConvert
{
	public unsafe static byte[] ToByte(int data)
	{
		byte* pdata = (byte*)(&data);
		byte[] byteArray = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			byteArray[i] = *(pdata++);
		}
		return byteArray;
	}

	public unsafe static byte[] ToByte(float data)
	{
		byte* pdata = (byte*)(&data);
		byte[] byteArray = new byte[4];
		for (int i = 0; i < 4; i++)
		{
			byteArray[i] = *(pdata++);
		}
		return byteArray;
	}

	public unsafe static byte[] ToByte(double data)
	{
		byte* pdata = (byte*)(&data);
		byte[] byteArray = new byte[8];
		for (int i = 0; i < 8; i++)
		{
			byteArray[i] = *(pdata++);
		}
		return byteArray;
	}

	public unsafe static int ToInt(byte[] data, int index)
	{
		int n = 0;
		fixed (byte* p = data)
		{
			byte* pn = p + index;
			n = Marshal.ReadInt32((IntPtr)pn);
		}
		return n;
	}

	public unsafe static float ToFloat(byte[] data, int index)
	{
		float a = 0f;
		fixed (byte* px = data)
		{
			void* pf = &a;
			for (byte i = 0; i < 4; i++)
			{
				((sbyte*)pf)[(int)i] = (sbyte)(px + index)[(int)i];
			}
		}
		return a;
	}

	public unsafe static double ToDouble(byte[] data)
	{
		double a = 0.0;
		fixed (byte* px = data)
		{
			void* pf = &a;
			for (byte i = 0; i < data.Length; i++)
			{
				((sbyte*)pf)[(int)i] = (sbyte)px[(int)i];
			}
		}
		return a;
	}
}
