// IL code: 数据读取软件
.class private auto ansi '<Module>'
{
} // end of class <Module>

.class public auto ansi beforefieldinit datapick.PointerConvert
	extends [mscorlib]System.Object
{
	// Methods
	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x2050
		// Header size: 1
		// Code size: 10 (0xa)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [mscorlib]System.Object::.ctor()
		IL_0006: nop
		IL_0007: nop
		IL_0008: nop
		IL_0009: ret
	} // end of method PointerConvert::.ctor

	.method public hidebysig static 
		uint8[] ToByte (
			int32 data
		) cil managed 
	{
		// Method begins at RVA 0x205c
		// Header size: 12
		// Code size: 47 (0x2f)
		.maxstack 5
		.locals init (
			[0] uint8* pdata,
			[1] uint8[] byteArray,
			[2] int32 i,
			[3] uint8[] CS$1$0000,
			[4] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: nop
		IL_0002: ldarga.s data
		IL_0004: conv.u
		IL_0005: stloc.0
		IL_0006: ldc.i4.4
		IL_0007: newarr [mscorlib]System.Byte
		IL_000c: stloc.1
		IL_000d: ldc.i4.0
		IL_000e: stloc.2
		IL_000f: br.s IL_001f
		// loop start (head: IL_001f)
			IL_0011: ldloc.1
			IL_0012: ldloc.2
			IL_0013: ldloc.0
			IL_0014: dup
			IL_0015: ldc.i4.1
			IL_0016: conv.i
			IL_0017: add
			IL_0018: stloc.0
			IL_0019: ldind.u1
			IL_001a: stelem.i1
			IL_001b: ldloc.2
			IL_001c: ldc.i4.1
			IL_001d: add
			IL_001e: stloc.2

			IL_001f: ldloc.2
			IL_0020: ldc.i4.4
			IL_0021: clt
			IL_0023: stloc.s 4
			IL_0025: ldloc.s 4
			IL_0027: brtrue.s IL_0011
		// end loop

		IL_0029: ldloc.1
		IL_002a: stloc.3
		IL_002b: br.s IL_002d

		IL_002d: ldloc.3
		IL_002e: ret
	} // end of method PointerConvert::ToByte

	.method public hidebysig static 
		uint8[] ToByte (
			float32 data
		) cil managed 
	{
		// Method begins at RVA 0x2098
		// Header size: 12
		// Code size: 47 (0x2f)
		.maxstack 5
		.locals init (
			[0] uint8* pdata,
			[1] uint8[] byteArray,
			[2] int32 i,
			[3] uint8[] CS$1$0000,
			[4] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: nop
		IL_0002: ldarga.s data
		IL_0004: conv.u
		IL_0005: stloc.0
		IL_0006: ldc.i4.4
		IL_0007: newarr [mscorlib]System.Byte
		IL_000c: stloc.1
		IL_000d: ldc.i4.0
		IL_000e: stloc.2
		IL_000f: br.s IL_001f
		// loop start (head: IL_001f)
			IL_0011: ldloc.1
			IL_0012: ldloc.2
			IL_0013: ldloc.0
			IL_0014: dup
			IL_0015: ldc.i4.1
			IL_0016: conv.i
			IL_0017: add
			IL_0018: stloc.0
			IL_0019: ldind.u1
			IL_001a: stelem.i1
			IL_001b: ldloc.2
			IL_001c: ldc.i4.1
			IL_001d: add
			IL_001e: stloc.2

			IL_001f: ldloc.2
			IL_0020: ldc.i4.4
			IL_0021: clt
			IL_0023: stloc.s 4
			IL_0025: ldloc.s 4
			IL_0027: brtrue.s IL_0011
		// end loop

		IL_0029: ldloc.1
		IL_002a: stloc.3
		IL_002b: br.s IL_002d

		IL_002d: ldloc.3
		IL_002e: ret
	} // end of method PointerConvert::ToByte

	.method public hidebysig static 
		uint8[] ToByte (
			float64 data
		) cil managed 
	{
		// Method begins at RVA 0x20d4
		// Header size: 12
		// Code size: 47 (0x2f)
		.maxstack 5
		.locals init (
			[0] uint8* pdata,
			[1] uint8[] byteArray,
			[2] int32 i,
			[3] uint8[] CS$1$0000,
			[4] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: nop
		IL_0002: ldarga.s data
		IL_0004: conv.u
		IL_0005: stloc.0
		IL_0006: ldc.i4.8
		IL_0007: newarr [mscorlib]System.Byte
		IL_000c: stloc.1
		IL_000d: ldc.i4.0
		IL_000e: stloc.2
		IL_000f: br.s IL_001f
		// loop start (head: IL_001f)
			IL_0011: ldloc.1
			IL_0012: ldloc.2
			IL_0013: ldloc.0
			IL_0014: dup
			IL_0015: ldc.i4.1
			IL_0016: conv.i
			IL_0017: add
			IL_0018: stloc.0
			IL_0019: ldind.u1
			IL_001a: stelem.i1
			IL_001b: ldloc.2
			IL_001c: ldc.i4.1
			IL_001d: add
			IL_001e: stloc.2

			IL_001f: ldloc.2
			IL_0020: ldc.i4.8
			IL_0021: clt
			IL_0023: stloc.s 4
			IL_0025: ldloc.s 4
			IL_0027: brtrue.s IL_0011
		// end loop

		IL_0029: ldloc.1
		IL_002a: stloc.3
		IL_002b: br.s IL_002d

		IL_002d: ldloc.3
		IL_002e: ret
	} // end of method PointerConvert::ToByte

	.method public hidebysig static 
		int32 ToInt (
			uint8[] data,
			int32 index
		) cil managed 
	{
		// Method begins at RVA 0x2110
		// Header size: 12
		// Code size: 58 (0x3a)
		.maxstack 2
		.locals init (
			[0] int32 n,
			[1] uint8& pinned p,
			[2] uint8* pn,
			[3] int32 CS$1$0000,
			[4] uint8[] CS$0$0001
		)

		IL_0000: nop
		IL_0001: nop
		IL_0002: ldc.i4.0
		IL_0003: stloc.0
		IL_0004: ldarg.0
		IL_0005: dup
		IL_0006: stloc.s 4
		IL_0008: brfalse.s IL_0010

		IL_000a: ldloc.s 4
		IL_000c: ldlen
		IL_000d: conv.i4
		IL_000e: brtrue.s IL_0015

		IL_0010: ldc.i4.0
		IL_0011: conv.u
		IL_0012: stloc.1
		IL_0013: br.s IL_001e

		IL_0015: ldloc.s 4
		IL_0017: ldc.i4.0
		IL_0018: ldelema [mscorlib]System.Byte
		IL_001d: stloc.1

		IL_001e: nop
		IL_001f: ldloc.1
		IL_0020: conv.i
		IL_0021: ldarg.1
		IL_0022: add
		IL_0023: stloc.2
		IL_0024: ldloc.2
		IL_0025: call native int [mscorlib]System.IntPtr::op_Explicit(void*)
		IL_002a: call int32 [mscorlib]System.Runtime.InteropServices.Marshal::ReadInt32(native int)
		IL_002f: stloc.0
		IL_0030: nop
		IL_0031: ldc.i4.0
		IL_0032: conv.u
		IL_0033: stloc.1
		IL_0034: ldloc.0
		IL_0035: stloc.3
		IL_0036: br.s IL_0038

		IL_0038: ldloc.3
		IL_0039: ret
	} // end of method PointerConvert::ToInt

	.method public hidebysig static 
		float32 ToFloat (
			uint8[] data,
			int32 index
		) cil managed 
	{
		// Method begins at RVA 0x2158
		// Header size: 12
		// Code size: 88 (0x58)
		.maxstack 3
		.locals init (
			[0] float32 a,
			[1] uint8 i,
			[2] uint8[] x,
			[3] void* pf,
			[4] uint8& pinned px,
			[5] float32 CS$1$0000,
			[6] uint8[] CS$0$0001,
			[7] bool CS$4$0002
		)

		IL_0000: nop
		IL_0001: ldc.r4 0.0
		IL_0006: stloc.0
		IL_0007: ldarg.0
		IL_0008: stloc.2
		IL_0009: ldloc.2
		IL_000a: dup
		IL_000b: stloc.s 6
		IL_000d: brfalse.s IL_0015

		IL_000f: ldloc.s 6
		IL_0011: ldlen
		IL_0012: conv.i4
		IL_0013: brtrue.s IL_001b

		IL_0015: ldc.i4.0
		IL_0016: conv.u
		IL_0017: stloc.s 4
		IL_0019: br.s IL_0025

		IL_001b: ldloc.s 6
		IL_001d: ldc.i4.0
		IL_001e: ldelema [mscorlib]System.Byte
		IL_0023: stloc.s 4

		IL_0025: nop
		IL_0026: ldloca.s 0
		IL_0028: conv.u
		IL_0029: stloc.3
		IL_002a: ldc.i4.0
		IL_002b: stloc.1
		IL_002c: br.s IL_0041
		// loop start (head: IL_0041)
			IL_002e: nop
			IL_002f: ldloc.3
			IL_0030: ldloc.1
			IL_0031: add
			IL_0032: ldloc.s 4
			IL_0034: conv.i
			IL_0035: ldarg.1
			IL_0036: add
			IL_0037: ldloc.1
			IL_0038: add
			IL_0039: ldind.u1
			IL_003a: stind.i1
			IL_003b: nop
			IL_003c: ldloc.1
			IL_003d: ldc.i4.1
			IL_003e: add
			IL_003f: conv.u1
			IL_0040: stloc.1

			IL_0041: ldloc.1
			IL_0042: ldc.i4.4
			IL_0043: clt
			IL_0045: stloc.s 7
			IL_0047: ldloc.s 7
			IL_0049: brtrue.s IL_002e
		// end loop

		IL_004b: nop
		IL_004c: ldc.i4.0
		IL_004d: conv.u
		IL_004e: stloc.s 4
		IL_0050: ldloc.0
		IL_0051: stloc.s 5
		IL_0053: br.s IL_0055

		IL_0055: ldloc.s 5
		IL_0057: ret
	} // end of method PointerConvert::ToFloat

	.method public hidebysig static 
		float64 ToDouble (
			uint8[] data
		) cil managed 
	{
		// Method begins at RVA 0x21bc
		// Header size: 12
		// Code size: 92 (0x5c)
		.maxstack 3
		.locals init (
			[0] float64 a,
			[1] uint8 i,
			[2] uint8[] x,
			[3] void* pf,
			[4] uint8& pinned px,
			[5] float64 CS$1$0000,
			[6] uint8[] CS$0$0001,
			[7] bool CS$4$0002
		)

		IL_0000: nop
		IL_0001: ldc.r8 0.0
		IL_000a: stloc.0
		IL_000b: ldarg.0
		IL_000c: stloc.2
		IL_000d: ldloc.2
		IL_000e: dup
		IL_000f: stloc.s 6
		IL_0011: brfalse.s IL_0019

		IL_0013: ldloc.s 6
		IL_0015: ldlen
		IL_0016: conv.i4
		IL_0017: brtrue.s IL_001f

		IL_0019: ldc.i4.0
		IL_001a: conv.u
		IL_001b: stloc.s 4
		IL_001d: br.s IL_0029

		IL_001f: ldloc.s 6
		IL_0021: ldc.i4.0
		IL_0022: ldelema [mscorlib]System.Byte
		IL_0027: stloc.s 4

		IL_0029: nop
		IL_002a: ldloca.s 0
		IL_002c: conv.u
		IL_002d: stloc.3
		IL_002e: ldc.i4.0
		IL_002f: stloc.1
		IL_0030: br.s IL_0043
		// loop start (head: IL_0043)
			IL_0032: nop
			IL_0033: ldloc.3
			IL_0034: ldloc.1
			IL_0035: add
			IL_0036: ldloc.s 4
			IL_0038: conv.i
			IL_0039: ldloc.1
			IL_003a: add
			IL_003b: ldind.u1
			IL_003c: stind.i1
			IL_003d: nop
			IL_003e: ldloc.1
			IL_003f: ldc.i4.1
			IL_0040: add
			IL_0041: conv.u1
			IL_0042: stloc.1

			IL_0043: ldloc.1
			IL_0044: ldarg.0
			IL_0045: ldlen
			IL_0046: conv.i4
			IL_0047: clt
			IL_0049: stloc.s 7
			IL_004b: ldloc.s 7
			IL_004d: brtrue.s IL_0032
		// end loop

		IL_004f: nop
		IL_0050: ldc.i4.0
		IL_0051: conv.u
		IL_0052: stloc.s 4
		IL_0054: ldloc.0
		IL_0055: stloc.s 5
		IL_0057: br.s IL_0059

		IL_0059: ldloc.s 5
		IL_005b: ret
	} // end of method PointerConvert::ToDouble

} // end of class datapick.PointerConvert

.class public auto ansi beforefieldinit datapick.Form1
	extends [System.Windows.Forms]System.Windows.Forms.Form
{
	// Nested Types
	.class nested public sequential ansi sealed beforefieldinit SP_DEVICE_INTERFACE_DATA
		extends [mscorlib]System.ValueType
	{
		// Fields
		.field public int32 cbSize
		.field public valuetype [mscorlib]System.Guid interfaceClassGuid
		.field public int32 'flags'
		.field public int32 reserved

	} // end of class SP_DEVICE_INTERFACE_DATA

	.class nested public sequential ansi beforefieldinit SP_DEVINFO_DATA
		extends [mscorlib]System.Object
	{
		// Fields
		.field public int32 cbSize
		.field public valuetype [mscorlib]System.Guid classGuid
		.field public int32 devInst
		.field public int32 reserved

		// Methods
		.method public hidebysig specialname rtspecialname 
			instance void .ctor () cil managed 
		{
			// Method begins at RVA 0x99aa
			// Header size: 1
			// Code size: 54 (0x36)
			.maxstack 8

			IL_0000: ldarg.0
			IL_0001: ldtoken datapick.Form1/SP_DEVINFO_DATA
			IL_0006: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_000b: call int32 [mscorlib]System.Runtime.InteropServices.Marshal::SizeOf(class [mscorlib]System.Type)
			IL_0010: stfld int32 datapick.Form1/SP_DEVINFO_DATA::cbSize
			IL_0015: ldarg.0
			IL_0016: ldsfld valuetype [mscorlib]System.Guid [mscorlib]System.Guid::Empty
			IL_001b: stfld valuetype [mscorlib]System.Guid datapick.Form1/SP_DEVINFO_DATA::classGuid
			IL_0020: ldarg.0
			IL_0021: ldc.i4.0
			IL_0022: stfld int32 datapick.Form1/SP_DEVINFO_DATA::devInst
			IL_0027: ldarg.0
			IL_0028: ldc.i4.0
			IL_0029: stfld int32 datapick.Form1/SP_DEVINFO_DATA::reserved
			IL_002e: ldarg.0
			IL_002f: call instance void [mscorlib]System.Object::.ctor()
			IL_0034: nop
			IL_0035: ret
		} // end of method SP_DEVINFO_DATA::.ctor

	} // end of class SP_DEVINFO_DATA

	.class nested assembly sequential ansi sealed beforefieldinit SP_DEVICE_INTERFACE_DETAIL_DATA
		extends [mscorlib]System.ValueType
	{
		.pack 2
		.size 0

		// Fields
		.field assembly int32 cbSize
		.field assembly int16 devicePath

	} // end of class SP_DEVICE_INTERFACE_DETAIL_DATA

	.class nested public auto ansi sealed DIGCF
		extends [mscorlib]System.Enum
	{
		// Fields
		.field public specialname rtspecialname int32 value__
		.field public static literal valuetype datapick.Form1/DIGCF DIGCF_DEFAULT = int32(1)
		.field public static literal valuetype datapick.Form1/DIGCF DIGCF_PRESENT = int32(2)
		.field public static literal valuetype datapick.Form1/DIGCF DIGCF_ALLCLASSES = int32(4)
		.field public static literal valuetype datapick.Form1/DIGCF DIGCF_PROFILE = int32(8)
		.field public static literal valuetype datapick.Form1/DIGCF DIGCF_DEVICEINTERFACE = int32(16)

	} // end of class DIGCF

	.class nested assembly sequential ansi sealed beforefieldinit HIDD_ATTRIBUTES
		extends [mscorlib]System.ValueType
	{
		// Fields
		.field assembly int32 Size
		.field assembly uint16 VendorID
		.field assembly uint16 ProductID
		.field assembly uint16 VersionNumber

	} // end of class HIDD_ATTRIBUTES

	.class nested private sequential ansi sealed beforefieldinit OVERLAPPED
		extends [mscorlib]System.ValueType
	{
		// Fields
		.field public int32 Internal
		.field public int32 InternalHigh
		.field public int32 Offset
		.field public int32 OffsetHigh
		.field public int32 hEvent

	} // end of class OVERLAPPED


	// Fields
	.field public static literal uint32 GENERIC_READ = uint32(2147483648)
	.field public static literal uint32 GENERIC_WRITE = uint32(1073741824)
	.field public static literal uint32 FILE_SHARE_READ = uint32(1)
	.field public static literal uint32 FILE_SHARE_WRITE = uint32(2)
	.field public static literal int32 OPEN_EXISTING = int32(3)
	.field public static literal int32 FILE_FLAG_OVERLAPPED = int32(1073741824)
	.field private valuetype [mscorlib]System.Guid guidHID
	.field private native int hDevInfo
	.field private bool listadd
	.field private float64 Bdate
	.field private string Bdatedisplay
	.field private float64 pinlv
	.field private float64 tempwendu
	.field private bool Ready
	.field private bool boolDisplayData
	.field private int32 ReadLength
	.field private int32 Circle
	.field private bool readsuccess
	.field private string[] Bdate_highspeed
	.field private int32 HighSpeedBase
	.field private int32 HighSpeedNO
	.field private string Speed
	.field private string[] Bdate_lots
	.field private int32[] nono_lots
	.field private string[] Date_lots
	.field private string[] Time_lots
	.field private string[] DateTime_lots
	.field private bool Ready_lots
	.field private class [ZedGraph]ZedGraph.PointPairList list
	.field private class [ZedGraph]ZedGraph.LineItem myCurve
	.field public static class datapick.Form1 mf
	.field private uint64 nono
	.field private string mashineType
	.field private bool dwChangeFlag
	.field private string TdataReceived
	.field private int32 FlagEnquire
	.field private int32 tishiflag
	.field private valuetype datapick.Form1/OVERLAPPED ovSEND
	.field private uint8[] senddata
	.field private int32 USBwrite
	.field private class [System.Windows.Forms]System.Windows.Forms.ProgressBar pb3
	.field private int32 DWflag
	.field private string MODEL
	.field private int32 DataType_flag
	.field private class datapick.tishi ts
	.field private int32 HidHandle
	.field private class [mscorlib]System.Threading.Thread readUSB
	.field private valuetype datapick.Form1/OVERLAPPED ovREAD
	.field private uint8[] m_rd_data
	.field private bool isread
	.field private uint32 USBread
	.field private float32 temp
	.field private float32 temp_abs
	.field private int32 communicate_fangshi
	.field private class [System]System.ComponentModel.IContainer components
	.field private class [System.Windows.Forms]System.Windows.Forms.GroupBox groupBox1
	.field private class [System]System.IO.Ports.SerialPort serialPort1
	.field private class [System.Windows.Forms]System.Windows.Forms.GroupBox groupBox5
	.field private class [System.Windows.Forms]System.Windows.Forms.Label labelwendu
	.field private class [System.Windows.Forms]System.Windows.Forms.GroupBox groupBox4
	.field private class [System.Windows.Forms]System.Windows.Forms.Label labelpinlv
	.field private class [System.Windows.Forms]System.Windows.Forms.GroupBox groupBox2
	.field private class [System.Windows.Forms]System.Windows.Forms.Label labelcichang
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxBAUDE
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label2
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxCOM
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label1
	.field private class [System.Windows.Forms]System.Windows.Forms.Button buttonZERO
	.field private class [System.Windows.Forms]System.Windows.Forms.Button buttonSTOP
	.field private class [System.Windows.Forms]System.Windows.Forms.Button buttonSTART
	.field private class [System.Windows.Forms]System.Windows.Forms.Timer timerTIME
	.field private class [System.Windows.Forms]System.Windows.Forms.DataGridView dataGridViewDATA
	.field private class [System.Windows.Forms]System.Windows.Forms.Button buttonLISTCLEAR
	.field private class [System.Windows.Forms]System.Windows.Forms.Button buttonEXCEL
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxdanwei
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label3
	.field private class [System.Windows.Forms]System.Windows.Forms.StatusStrip StatusStrip1
	.field private class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel ToolStripStatusLabel1
	.field private class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2
	.field private class [System.Windows.Forms]System.Windows.Forms.RadioButton radioButton2
	.field private class [System.Windows.Forms]System.Windows.Forms.RadioButton radioButton1
	.field private class [ZedGraph]ZedGraph.ZedGraphControl zedTIME
	.field private class [System.Windows.Forms]System.Windows.Forms.Label labelSource
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxSource
	.field private class [System.Windows.Forms]System.Windows.Forms.Timer timer1
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxfangshi
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label4
	.field private class [System.Windows.Forms]System.Windows.Forms.Timer timerRecieve
	.field private class [System.Windows.Forms]System.Windows.Forms.Timer timerUSBread
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label5
	.field public class [System.Windows.Forms]System.Windows.Forms.GroupBox groupBox6
	.field public class [System.Windows.Forms]System.Windows.Forms.GroupBox groupBox3
	.field public class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxDataType
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label6
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxModel
	.field public class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxSpeed
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label7
	.field private class [System.Windows.Forms]System.Windows.Forms.ComboBox comboBoxT
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label8
	.field private class [System.Windows.Forms]System.Windows.Forms.Timer timerType
	.field private class [System.Windows.Forms]System.Windows.Forms.SplitContainer splitContainer1
	.field private class [System.Windows.Forms]System.Windows.Forms.Button button2
	.field private class [System.Windows.Forms]System.Windows.Forms.Button button1
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label11
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label10
	.field private class [System.Windows.Forms]System.Windows.Forms.Label label9
	.field private class [System.Windows.Forms]System.Windows.Forms.CheckBox checkBox1

	// Methods
	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x2224
		// Header size: 12
		// Code size: 409 (0x199)
		.maxstack 2
		.locals init (
			[0] uint8[] CS$0$0000
		)

		IL_0000: ldarg.0
		IL_0001: ldsfld valuetype [mscorlib]System.Guid [mscorlib]System.Guid::Empty
		IL_0006: stfld valuetype [mscorlib]System.Guid datapick.Form1::guidHID
		IL_000b: ldarg.0
		IL_000c: ldc.i4.0
		IL_000d: stfld bool datapick.Form1::listadd
		IL_0012: ldarg.0
		IL_0013: ldc.r8 0.0
		IL_001c: stfld float64 datapick.Form1::Bdate
		IL_0021: ldarg.0
		IL_0022: ldc.r8 0.0
		IL_002b: stfld float64 datapick.Form1::pinlv
		IL_0030: ldarg.0
		IL_0031: ldc.r8 0.0
		IL_003a: stfld float64 datapick.Form1::tempwendu
		IL_003f: ldarg.0
		IL_0040: ldc.i4.0
		IL_0041: stfld bool datapick.Form1::Ready
		IL_0046: ldarg.0
		IL_0047: ldc.i4.0
		IL_0048: stfld bool datapick.Form1::boolDisplayData
		IL_004d: ldarg.0
		IL_004e: ldc.i4.s 23
		IL_0050: stfld int32 datapick.Form1::ReadLength
		IL_0055: ldarg.0
		IL_0056: ldc.i4.1
		IL_0057: stfld int32 datapick.Form1::Circle
		IL_005c: ldarg.0
		IL_005d: ldc.i4.0
		IL_005e: stfld bool datapick.Form1::readsuccess
		IL_0063: ldarg.0
		IL_0064: ldc.i4.s 13
		IL_0066: stfld int32 datapick.Form1::HighSpeedBase
		IL_006b: ldarg.0
		IL_006c: ldc.i4.s 20
		IL_006e: stfld int32 datapick.Form1::HighSpeedNO
		IL_0073: ldarg.0
		IL_0074: ldnull
		IL_0075: stfld string datapick.Form1::Speed
		IL_007a: ldarg.0
		IL_007b: ldc.i4 500
		IL_0080: newarr [mscorlib]System.String
		IL_0085: stfld string[] datapick.Form1::Bdate_lots
		IL_008a: ldarg.0
		IL_008b: ldc.i4 500
		IL_0090: newarr [mscorlib]System.Int32
		IL_0095: stfld int32[] datapick.Form1::nono_lots
		IL_009a: ldarg.0
		IL_009b: ldc.i4 500
		IL_00a0: newarr [mscorlib]System.String
		IL_00a5: stfld string[] datapick.Form1::Date_lots
		IL_00aa: ldarg.0
		IL_00ab: ldc.i4 500
		IL_00b0: newarr [mscorlib]System.String
		IL_00b5: stfld string[] datapick.Form1::Time_lots
		IL_00ba: ldarg.0
		IL_00bb: ldc.i4 500
		IL_00c0: newarr [mscorlib]System.String
		IL_00c5: stfld string[] datapick.Form1::DateTime_lots
		IL_00ca: ldarg.0
		IL_00cb: ldc.i4.0
		IL_00cc: stfld bool datapick.Form1::Ready_lots
		IL_00d1: ldarg.0
		IL_00d2: newobj instance void [ZedGraph]ZedGraph.PointPairList::.ctor()
		IL_00d7: stfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_00dc: ldarg.0
		IL_00dd: ldc.i4.1
		IL_00de: conv.i8
		IL_00df: stfld uint64 datapick.Form1::nono
		IL_00e4: ldarg.0
		IL_00e5: ldstr ""
		IL_00ea: stfld string datapick.Form1::mashineType
		IL_00ef: ldarg.0
		IL_00f0: ldc.i4.0
		IL_00f1: stfld bool datapick.Form1::dwChangeFlag
		IL_00f6: ldarg.0
		IL_00f7: ldnull
		IL_00f8: stfld string datapick.Form1::TdataReceived
		IL_00fd: ldarg.0
		IL_00fe: ldc.i4.4
		IL_00ff: stfld int32 datapick.Form1::FlagEnquire
		IL_0104: ldarg.0
		IL_0105: ldc.i4.0
		IL_0106: stfld int32 datapick.Form1::tishiflag
		IL_010b: ldarg.0
		IL_010c: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
		IL_0111: initobj datapick.Form1/OVERLAPPED
		IL_0117: ldarg.0
		IL_0118: ldc.i4.s 17
		IL_011a: newarr [mscorlib]System.Byte
		IL_011f: stloc.0
		IL_0120: ldloc.0
		IL_0121: stfld uint8[] datapick.Form1::senddata
		IL_0126: ldarg.0
		IL_0127: ldc.i4.0
		IL_0128: stfld int32 datapick.Form1::USBwrite
		IL_012d: ldarg.0
		IL_012e: ldc.i4.1
		IL_012f: stfld int32 datapick.Form1::DWflag
		IL_0134: ldarg.0
		IL_0135: ldc.i4.0
		IL_0136: stfld int32 datapick.Form1::DataType_flag
		IL_013b: ldarg.0
		IL_013c: newobj instance void datapick.tishi::.ctor()
		IL_0141: stfld class datapick.tishi datapick.Form1::ts
		IL_0146: ldarg.0
		IL_0147: ldc.i4.m1
		IL_0148: stfld int32 datapick.Form1::HidHandle
		IL_014d: ldarg.0
		IL_014e: ldnull
		IL_014f: stfld class [mscorlib]System.Threading.Thread datapick.Form1::readUSB
		IL_0154: ldarg.0
		IL_0155: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovREAD
		IL_015a: initobj datapick.Form1/OVERLAPPED
		IL_0160: ldarg.0
		IL_0161: ldc.i4.s 65
		IL_0163: newarr [mscorlib]System.Byte
		IL_0168: stfld uint8[] datapick.Form1::m_rd_data
		IL_016d: ldarg.0
		IL_016e: ldc.i4.0
		IL_016f: stfld uint32 datapick.Form1::USBread
		IL_0174: ldarg.0
		IL_0175: ldc.i4.0
		IL_0176: stfld int32 datapick.Form1::communicate_fangshi
		IL_017b: ldarg.0
		IL_017c: ldnull
		IL_017d: stfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_0182: ldarg.0
		IL_0183: call instance void [System.Windows.Forms]System.Windows.Forms.Form::.ctor()
		IL_0188: nop
		IL_0189: nop
		IL_018a: ldarg.0
		IL_018b: call instance void datapick.Form1::InitializeComponent()
		IL_0190: nop
		IL_0191: ldarg.0
		IL_0192: stsfld class datapick.Form1 datapick.Form1::mf
		IL_0197: nop
		IL_0198: ret
	} // end of method Form1::.ctor

	.method public hidebysig static pinvokeimpl("hid.dll" winapi) 
		void HidD_GetHidGuid (
			valuetype [mscorlib]System.Guid& HidGuid
		) cil managed preservesig 
	{
	} // end of method Form1::HidD_GetHidGuid

	.method public hidebysig static pinvokeimpl("setupapi.dll" lasterr winapi) 
		native int SetupDiGetClassDevs (
			valuetype [mscorlib]System.Guid& ClassGuid,
			uint32 Enumerator,
			native int HwndParent,
			valuetype datapick.Form1/DIGCF Flags
		) cil managed preservesig 
	{
	} // end of method Form1::SetupDiGetClassDevs

	.method public hidebysig static pinvokeimpl("setupapi.dll" autochar lasterr winapi) 
		bool SetupDiEnumDeviceInterfaces (
			native int hDevInfo,
			native int devInfo,
			valuetype [mscorlib]System.Guid& interfaceClassGuid,
			uint32 memberIndex,
			valuetype datapick.Form1/SP_DEVICE_INTERFACE_DATA& deviceInterfaceData
		) cil managed preservesig 
	{
	} // end of method Form1::SetupDiEnumDeviceInterfaces

	.method private hidebysig static pinvokeimpl("setupapi.dll" autochar lasterr winapi) 
		bool SetupDiGetDeviceInterfaceDetail (
			native int deviceInfoSet,
			valuetype datapick.Form1/SP_DEVICE_INTERFACE_DATA& deviceInterfaceData,
			native int deviceInterfaceDetailData,
			int32 deviceInterfaceDetailDataSize,
			int32& requiredSize,
			class datapick.Form1/SP_DEVINFO_DATA deviceInfoData
		) cil managed preservesig 
	{
	} // end of method Form1::SetupDiGetDeviceInterfaceDetail

	.method private hidebysig static pinvokeimpl("hid.dll" winapi) 
		bool HidD_GetAttributes (
			int32 HidhandleValue,
			valuetype datapick.Form1/HIDD_ATTRIBUTES& hidDeviceAttributes
		) cil managed preservesig 
	{
	} // end of method Form1::HidD_GetAttributes

	.method private hidebysig static pinvokeimpl("kernel32.dll" lasterr winapi) 
		int32 CreateFile (
			string lpFileName,
			uint32 dwDesiredAccess,
			uint32 dwShareMode,
			uint32 lpSecurityAttributes,
			uint32 dwCreationDisposition,
			uint32 dwFlagsAndAttributes,
			uint32 hTemplateFile
		) cil managed preservesig 
	{
	} // end of method Form1::CreateFile

	.method private hidebysig static pinvokeimpl("Kernel32.dll" lasterr winapi) 
		bool ReadFile (
			native int hFile,
			uint8[] lpBuffer,
			uint32 nNumberOfBytesToRead,
			uint32& lpNumberOfBytesRead,
			valuetype datapick.Form1/OVERLAPPED& lpOverlapped
		) cil managed preservesig 
	{
	} // end of method Form1::ReadFile

	.method private hidebysig static pinvokeimpl("kernel32.dll" winapi) 
		bool WriteFile (
			native int hFile,
			uint8[] lpBuffer,
			int32 nNumberOfBytesToWrite,
			int32& lpNumberOfBytesWritten,
			valuetype datapick.Form1/OVERLAPPED& lpOverlapped
		) cil managed preservesig 
	{
	} // end of method Form1::WriteFile

	.method public hidebysig static pinvokeimpl("hid.dll" winapi) 
		bool HidD_FreePreparsedData (
			native int& PreparsedData
		) cil managed preservesig 
	{
	} // end of method Form1::HidD_FreePreparsedData

	.method public hidebysig static pinvokeimpl("kernel32.dll" winapi) 
		int32 CloseHandle (
			int32 hObject
		) cil managed preservesig 
	{
	} // end of method Form1::CloseHandle

	.method private hidebysig 
		instance bool isdoublenum (
			string ppp
		) cil managed 
	{
		// Method begins at RVA 0x23cc
		// Header size: 12
		// Code size: 27 (0x1b)
		.maxstack 1
		.locals init (
			[0] float64 xx,
			[1] bool CS$1$0000
		)

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldarg.1
			IL_0003: callvirt instance string [mscorlib]System.String::Trim()
			IL_0008: call float64 [mscorlib]System.Convert::ToDouble(string)
			IL_000d: stloc.0
			IL_000e: ldc.i4.1
			IL_000f: stloc.1
			IL_0010: leave.s IL_0018
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0012: pop
			IL_0013: nop
			IL_0014: ldc.i4.0
			IL_0015: stloc.1
			IL_0016: leave.s IL_0018
		} // end handler

		IL_0018: nop
		IL_0019: ldloc.1
		IL_001a: ret
	} // end of method Form1::isdoublenum

	.method private hidebysig 
		instance void serialPort1_DataReceived (
			object sender,
			class [System]System.IO.Ports.SerialDataReceivedEventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x2404
		// Header size: 12
		// Code size: 2001 (0x7d1)
		.maxstack 6
		.locals init (
			[0] char[] Temp,
			[1] char[] highspeedRead,
			[2] int32 i,
			[3] string[] temp,
			[4] bool CS$4$0000,
			[5] char[] CS$0$0001,
			[6] valuetype [mscorlib]System.DateTime CS$0$0002,
			[7] string[] CS$0$0003,
			[8] int32 CS$0$0004
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld int32 datapick.Form1::FlagEnquire
		IL_0007: ldc.i4.4
		IL_0008: ceq
		IL_000a: ldc.i4.0
		IL_000b: ceq
		IL_000d: stloc.s 4
		IL_000f: ldloc.s 4
		IL_0011: brtrue IL_06e8

		IL_0016: nop
		IL_0017: ldarg.0
		IL_0018: ldfld int32 datapick.Form1::DataType_flag
		IL_001d: ldc.i4.1
		IL_001e: ceq
		IL_0020: ldc.i4.0
		IL_0021: ceq
		IL_0023: stloc.s 4
		IL_0025: ldloc.s 4
		IL_0027: brtrue IL_0416

		IL_002c: nop
		IL_002d: ldarg.0
		IL_002e: ldfld int32 datapick.Form1::ReadLength
		IL_0033: newarr [mscorlib]System.Char
		IL_0038: stloc.0
		IL_0039: ldarg.0
		IL_003a: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_003f: ldloc.0
		IL_0040: ldc.i4.0
		IL_0041: ldarg.0
		IL_0042: ldfld int32 datapick.Form1::ReadLength
		IL_0047: callvirt instance int32 [System]System.IO.Ports.SerialPort::Read(char[], int32, int32)
		IL_004c: pop
		IL_004d: ldarg.0
		IL_004e: ldloc.0
		IL_004f: newobj instance void [mscorlib]System.String::.ctor(char[])
		IL_0054: stfld string datapick.Form1::TdataReceived
		IL_0059: ldarg.0
		IL_005a: ldfld string datapick.Form1::mashineType
		IL_005f: ldstr "高斯计"
		IL_0064: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0069: brfalse.s IL_00a5

		IL_006b: ldarg.0
		IL_006c: ldfld string datapick.Form1::TdataReceived
		IL_0071: callvirt instance int32 [mscorlib]System.String::get_Length()
		IL_0076: ldarg.0
		IL_0077: ldfld int32 datapick.Form1::ReadLength
		IL_007c: bne.un.s IL_00a5

		IL_007e: ldarg.0
		IL_007f: ldfld string datapick.Form1::TdataReceived
		IL_0084: ldstr "#"
		IL_0089: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_008e: brfalse.s IL_00a5

		IL_0090: ldarg.0
		IL_0091: ldfld string datapick.Form1::TdataReceived
		IL_0096: ldstr ">\n"
		IL_009b: callvirt instance bool [mscorlib]System.String::EndsWith(string)
		IL_00a0: ldc.i4.0
		IL_00a1: ceq
		IL_00a3: br.s IL_00a6

		IL_00a5: ldc.i4.1

		IL_00a6: nop
		IL_00a7: stloc.s 4
		IL_00a9: ldloc.s 4
		IL_00ab: brtrue.s IL_0117

		IL_00ad: nop
		IL_00ae: ldarg.0
		IL_00af: ldarg.0
		IL_00b0: ldfld string datapick.Form1::TdataReceived
		IL_00b5: ldc.i4.1
		IL_00b6: newarr [mscorlib]System.Char
		IL_00bb: stloc.s 5
		IL_00bd: ldloc.s 5
		IL_00bf: ldc.i4.0
		IL_00c0: ldc.i4.s 35
		IL_00c2: stelem.i2
		IL_00c3: ldloc.s 5
		IL_00c5: callvirt instance string [mscorlib]System.String::TrimStart(char[])
		IL_00ca: stfld string datapick.Form1::TdataReceived
		IL_00cf: ldarg.0
		IL_00d0: ldarg.0
		IL_00d1: ldfld string datapick.Form1::TdataReceived
		IL_00d6: ldc.i4.1
		IL_00d7: newarr [mscorlib]System.Char
		IL_00dc: stloc.s 5
		IL_00de: ldloc.s 5
		IL_00e0: ldc.i4.0
		IL_00e1: ldc.i4.s 10
		IL_00e3: stelem.i2
		IL_00e4: ldloc.s 5
		IL_00e6: callvirt instance string [mscorlib]System.String::TrimEnd(char[])
		IL_00eb: stfld string datapick.Form1::TdataReceived
		IL_00f0: ldarg.0
		IL_00f1: ldarg.0
		IL_00f2: ldfld string datapick.Form1::TdataReceived
		IL_00f7: ldc.i4.1
		IL_00f8: newarr [mscorlib]System.Char
		IL_00fd: stloc.s 5
		IL_00ff: ldloc.s 5
		IL_0101: ldc.i4.0
		IL_0102: ldc.i4.s 62
		IL_0104: stelem.i2
		IL_0105: ldloc.s 5
		IL_0107: callvirt instance string [mscorlib]System.String::TrimEnd(char[])
		IL_010c: stfld string datapick.Form1::TdataReceived
		IL_0111: nop
		IL_0112: br IL_02dc

		IL_0117: ldarg.0
		IL_0118: ldfld string datapick.Form1::mashineType
		IL_011d: ldstr "磁通计"
		IL_0122: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0127: brfalse.s IL_0163

		IL_0129: ldarg.0
		IL_012a: ldfld string datapick.Form1::TdataReceived
		IL_012f: callvirt instance int32 [mscorlib]System.String::get_Length()
		IL_0134: ldarg.0
		IL_0135: ldfld int32 datapick.Form1::ReadLength
		IL_013a: bne.un.s IL_0163

		IL_013c: ldarg.0
		IL_013d: ldfld string datapick.Form1::TdataReceived
		IL_0142: ldstr "#"
		IL_0147: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_014c: brfalse.s IL_0163

		IL_014e: ldarg.0
		IL_014f: ldfld string datapick.Form1::TdataReceived
		IL_0154: ldstr ">\n"
		IL_0159: callvirt instance bool [mscorlib]System.String::EndsWith(string)
		IL_015e: ldc.i4.0
		IL_015f: ceq
		IL_0161: br.s IL_0164

		IL_0163: ldc.i4.1

		IL_0164: nop
		IL_0165: stloc.s 4
		IL_0167: ldloc.s 4
		IL_0169: brtrue IL_02dc

		IL_016e: nop
		IL_016f: ldarg.0
		IL_0170: ldarg.0
		IL_0171: ldfld string datapick.Form1::TdataReceived
		IL_0176: ldc.i4.1
		IL_0177: newarr [mscorlib]System.Char
		IL_017c: stloc.s 5
		IL_017e: ldloc.s 5
		IL_0180: ldc.i4.0
		IL_0181: ldc.i4.s 35
		IL_0183: stelem.i2
		IL_0184: ldloc.s 5
		IL_0186: callvirt instance string [mscorlib]System.String::TrimStart(char[])
		IL_018b: stfld string datapick.Form1::TdataReceived
		IL_0190: ldarg.0
		IL_0191: ldarg.0
		IL_0192: ldfld string datapick.Form1::TdataReceived
		IL_0197: ldc.i4.1
		IL_0198: newarr [mscorlib]System.Char
		IL_019d: stloc.s 5
		IL_019f: ldloc.s 5
		IL_01a1: ldc.i4.0
		IL_01a2: ldc.i4.s 10
		IL_01a4: stelem.i2
		IL_01a5: ldloc.s 5
		IL_01a7: callvirt instance string [mscorlib]System.String::TrimEnd(char[])
		IL_01ac: stfld string datapick.Form1::TdataReceived
		IL_01b1: ldarg.0
		IL_01b2: ldarg.0
		IL_01b3: ldfld string datapick.Form1::TdataReceived
		IL_01b8: ldc.i4.1
		IL_01b9: newarr [mscorlib]System.Char
		IL_01be: stloc.s 5
		IL_01c0: ldloc.s 5
		IL_01c2: ldc.i4.0
		IL_01c3: ldc.i4.s 62
		IL_01c5: stelem.i2
		IL_01c6: ldloc.s 5
		IL_01c8: callvirt instance string [mscorlib]System.String::TrimEnd(char[])
		IL_01cd: stfld string datapick.Form1::TdataReceived
		IL_01d2: ldarg.0
		IL_01d3: ldfld string datapick.Form1::TdataReceived
		IL_01d8: ldstr "F"
		IL_01dd: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_01e2: ldc.i4.0
		IL_01e3: ceq
		IL_01e5: stloc.s 4
		IL_01e7: ldloc.s 4
		IL_01e9: brtrue.s IL_0238

		IL_01eb: nop
		IL_01ec: ldarg.0
		IL_01ed: ldarg.0
		IL_01ee: ldfld string datapick.Form1::TdataReceived
		IL_01f3: ldc.i4.1
		IL_01f4: newarr [mscorlib]System.Char
		IL_01f9: stloc.s 5
		IL_01fb: ldloc.s 5
		IL_01fd: ldc.i4.0
		IL_01fe: ldc.i4.s 70
		IL_0200: stelem.i2
		IL_0201: ldloc.s 5
		IL_0203: callvirt instance string [mscorlib]System.String::TrimStart(char[])
		IL_0208: stfld string datapick.Form1::TdataReceived
		IL_020d: ldarg.0
		IL_020e: ldfld int32 datapick.Form1::DWflag
		IL_0213: ldc.i4.5
		IL_0214: beq.s IL_0221

		IL_0216: ldarg.0
		IL_0217: ldfld int32 datapick.Form1::DWflag
		IL_021c: ldc.i4.6
		IL_021d: ceq
		IL_021f: br.s IL_0222

		IL_0221: ldc.i4.1

		IL_0222: nop
		IL_0223: stloc.s 4
		IL_0225: ldloc.s 4
		IL_0227: brtrue.s IL_0232

		IL_0229: nop
		IL_022a: ldarg.0
		IL_022b: ldc.i4.1
		IL_022c: stfld bool datapick.Form1::dwChangeFlag
		IL_0231: nop

		IL_0232: nop
		IL_0233: br IL_02db

		IL_0238: ldarg.0
		IL_0239: ldfld string datapick.Form1::TdataReceived
		IL_023e: ldstr "M"
		IL_0243: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_0248: brtrue.s IL_025f

		IL_024a: ldarg.0
		IL_024b: ldfld string datapick.Form1::TdataReceived
		IL_0250: ldstr "B"
		IL_0255: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_025a: ldc.i4.0
		IL_025b: ceq
		IL_025d: br.s IL_0260

		IL_025f: ldc.i4.0

		IL_0260: nop
		IL_0261: stloc.s 4
		IL_0263: ldloc.s 4
		IL_0265: brtrue.s IL_02d5

		IL_0267: nop
		IL_0268: ldarg.0
		IL_0269: ldarg.0
		IL_026a: ldfld string datapick.Form1::TdataReceived
		IL_026f: ldc.i4.1
		IL_0270: newarr [mscorlib]System.Char
		IL_0275: stloc.s 5
		IL_0277: ldloc.s 5
		IL_0279: ldc.i4.0
		IL_027a: ldc.i4.s 77
		IL_027c: stelem.i2
		IL_027d: ldloc.s 5
		IL_027f: callvirt instance string [mscorlib]System.String::TrimStart(char[])
		IL_0284: stfld string datapick.Form1::TdataReceived
		IL_0289: ldarg.0
		IL_028a: ldarg.0
		IL_028b: ldfld string datapick.Form1::TdataReceived
		IL_0290: ldc.i4.1
		IL_0291: newarr [mscorlib]System.Char
		IL_0296: stloc.s 5
		IL_0298: ldloc.s 5
		IL_029a: ldc.i4.0
		IL_029b: ldc.i4.s 66
		IL_029d: stelem.i2
		IL_029e: ldloc.s 5
		IL_02a0: callvirt instance string [mscorlib]System.String::TrimStart(char[])
		IL_02a5: stfld string datapick.Form1::TdataReceived
		IL_02aa: ldarg.0
		IL_02ab: ldfld int32 datapick.Form1::DWflag
		IL_02b0: ldc.i4.5
		IL_02b1: beq.s IL_02c1

		IL_02b3: ldarg.0
		IL_02b4: ldfld int32 datapick.Form1::DWflag
		IL_02b9: ldc.i4.6
		IL_02ba: ceq
		IL_02bc: ldc.i4.0
		IL_02bd: ceq
		IL_02bf: br.s IL_02c2

		IL_02c1: ldc.i4.0

		IL_02c2: nop
		IL_02c3: stloc.s 4
		IL_02c5: ldloc.s 4
		IL_02c7: brtrue.s IL_02d2

		IL_02c9: nop
		IL_02ca: ldarg.0
		IL_02cb: ldc.i4.1
		IL_02cc: stfld bool datapick.Form1::dwChangeFlag
		IL_02d1: nop

		IL_02d2: nop
		IL_02d3: br.s IL_02db

		IL_02d5: nop
		IL_02d6: br IL_07cf

		IL_02db: nop

		IL_02dc: ldarg.0
		IL_02dd: ldarg.0
		IL_02de: ldfld string datapick.Form1::TdataReceived
		IL_02e3: ldc.i4.1
		IL_02e4: newarr [mscorlib]System.Char
		IL_02e9: stloc.s 5
		IL_02eb: ldloc.s 5
		IL_02ed: ldc.i4.0
		IL_02ee: ldc.i4.s 47
		IL_02f0: stelem.i2
		IL_02f1: ldloc.s 5
		IL_02f3: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_02f8: ldc.i4.0
		IL_02f9: ldelem.ref
		IL_02fa: call instance bool datapick.Form1::isdoublenum(string)
		IL_02ff: brfalse.s IL_034e

		IL_0301: ldarg.0
		IL_0302: ldarg.0
		IL_0303: ldfld string datapick.Form1::TdataReceived
		IL_0308: ldc.i4.1
		IL_0309: newarr [mscorlib]System.Char
		IL_030e: stloc.s 5
		IL_0310: ldloc.s 5
		IL_0312: ldc.i4.0
		IL_0313: ldc.i4.s 47
		IL_0315: stelem.i2
		IL_0316: ldloc.s 5
		IL_0318: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_031d: ldc.i4.1
		IL_031e: ldelem.ref
		IL_031f: call instance bool datapick.Form1::isdoublenum(string)
		IL_0324: brfalse.s IL_034e

		IL_0326: ldarg.0
		IL_0327: ldarg.0
		IL_0328: ldfld string datapick.Form1::TdataReceived
		IL_032d: ldc.i4.1
		IL_032e: newarr [mscorlib]System.Char
		IL_0333: stloc.s 5
		IL_0335: ldloc.s 5
		IL_0337: ldc.i4.0
		IL_0338: ldc.i4.s 47
		IL_033a: stelem.i2
		IL_033b: ldloc.s 5
		IL_033d: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_0342: ldc.i4.2
		IL_0343: ldelem.ref
		IL_0344: call instance bool datapick.Form1::isdoublenum(string)
		IL_0349: ldc.i4.0
		IL_034a: ceq
		IL_034c: br.s IL_034f

		IL_034e: ldc.i4.1

		IL_034f: nop
		IL_0350: stloc.s 4
		IL_0352: ldloc.s 4
		IL_0354: brtrue IL_0410

		IL_0359: nop
		IL_035a: ldarg.0
		IL_035b: ldarg.0
		IL_035c: ldarg.0
		IL_035d: ldfld string datapick.Form1::TdataReceived
		IL_0362: ldc.i4.1
		IL_0363: newarr [mscorlib]System.Char
		IL_0368: stloc.s 5
		IL_036a: ldloc.s 5
		IL_036c: ldc.i4.0
		IL_036d: ldc.i4.s 47
		IL_036f: stelem.i2
		IL_0370: ldloc.s 5
		IL_0372: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_0377: ldc.i4.0
		IL_0378: ldelem.ref
		IL_0379: call instance string datapick.Form1::BdataDisplayConvert(string)
		IL_037e: stfld string datapick.Form1::Bdatedisplay
		IL_0383: ldarg.0
		IL_0384: ldarg.0
		IL_0385: ldfld string datapick.Form1::Bdatedisplay
		IL_038a: callvirt instance string [mscorlib]System.String::Trim()
		IL_038f: call float64 [mscorlib]System.Convert::ToDouble(string)
		IL_0394: stfld float64 datapick.Form1::Bdate
		IL_0399: ldarg.0
		IL_039a: ldarg.0
		IL_039b: ldfld string datapick.Form1::TdataReceived
		IL_03a0: ldc.i4.1
		IL_03a1: newarr [mscorlib]System.Char
		IL_03a6: stloc.s 5
		IL_03a8: ldloc.s 5
		IL_03aa: ldc.i4.0
		IL_03ab: ldc.i4.s 47
		IL_03ad: stelem.i2
		IL_03ae: ldloc.s 5
		IL_03b0: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_03b5: ldc.i4.1
		IL_03b6: ldelem.ref
		IL_03b7: call float64 [mscorlib]System.Convert::ToDouble(string)
		IL_03bc: stfld float64 datapick.Form1::pinlv
		IL_03c1: ldarg.0
		IL_03c2: ldarg.0
		IL_03c3: ldfld string datapick.Form1::TdataReceived
		IL_03c8: ldc.i4.1
		IL_03c9: newarr [mscorlib]System.Char
		IL_03ce: stloc.s 5
		IL_03d0: ldloc.s 5
		IL_03d2: ldc.i4.0
		IL_03d3: ldc.i4.s 47
		IL_03d5: stelem.i2
		IL_03d6: ldloc.s 5
		IL_03d8: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_03dd: ldc.i4.2
		IL_03de: ldelem.ref
		IL_03df: call float64 [mscorlib]System.Convert::ToDouble(string)
		IL_03e4: ldc.r8 10
		IL_03ed: div
		IL_03ee: stfld float64 datapick.Form1::tempwendu
		IL_03f3: ldarg.0
		IL_03f4: ldc.i4.1
		IL_03f5: stfld bool datapick.Form1::listadd
		IL_03fa: ldarg.0
		IL_03fb: ldfld bool datapick.Form1::Ready
		IL_0400: stloc.s 4
		IL_0402: ldloc.s 4
		IL_0404: brtrue.s IL_040f

		IL_0406: nop
		IL_0407: ldarg.0
		IL_0408: ldc.i4.1
		IL_0409: stfld bool datapick.Form1::Ready
		IL_040e: nop

		IL_040f: nop

		IL_0410: nop
		IL_0411: br IL_06e2

		IL_0416: ldarg.0
		IL_0417: ldfld int32 datapick.Form1::DataType_flag
		IL_041c: ldc.i4.2
		IL_041d: ceq
		IL_041f: ldc.i4.0
		IL_0420: ceq
		IL_0422: stloc.s 4
		IL_0424: ldloc.s 4
		IL_0426: brtrue.s IL_047c

		IL_0428: nop
		IL_0429: ldarg.0
		IL_042a: ldfld int32 datapick.Form1::HighSpeedNO
		IL_042f: ldarg.0
		IL_0430: ldfld int32 datapick.Form1::HighSpeedBase
		IL_0435: mul
		IL_0436: newarr [mscorlib]System.Char
		IL_043b: stloc.1
		.try
		{
			IL_043c: nop
			IL_043d: ldarg.0
			IL_043e: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0443: ldloc.1
			IL_0444: ldc.i4.0
			IL_0445: ldarg.0
			IL_0446: ldfld int32 datapick.Form1::HighSpeedNO
			IL_044b: ldarg.0
			IL_044c: ldfld int32 datapick.Form1::HighSpeedBase
			IL_0451: mul
			IL_0452: callvirt instance int32 [System]System.IO.Ports.SerialPort::Read(char[], int32, int32)
			IL_0457: pop
			IL_0458: nop
			IL_0459: leave.s IL_0462
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_045b: pop
			IL_045c: nop
			IL_045d: leave IL_07cf
		} // end handler

		IL_0462: nop
		IL_0463: ldarg.0
		IL_0464: ldloc.1
		IL_0465: newobj instance void [mscorlib]System.String::.ctor(char[])
		IL_046a: stfld string datapick.Form1::TdataReceived
		IL_046f: ldarg.0
		IL_0470: ldc.i4.1
		IL_0471: stfld bool datapick.Form1::readsuccess
		IL_0476: nop
		IL_0477: br IL_06e2

		IL_047c: ldarg.0
		IL_047d: ldfld int32 datapick.Form1::DataType_flag
		IL_0482: ldc.i4.3
		IL_0483: ceq
		IL_0485: ldc.i4.0
		IL_0486: ceq
		IL_0488: stloc.s 4
		IL_048a: ldloc.s 4
		IL_048c: brtrue IL_06e2

		IL_0491: nop
		IL_0492: ldc.i4.0
		IL_0493: stloc.2
		IL_0494: ldc.i4 1000
		IL_0499: call void [mscorlib]System.Threading.Thread::Sleep(int32)
		IL_049e: nop
		IL_049f: ldarg.0
		IL_04a0: ldarg.0
		IL_04a1: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_04a6: callvirt instance string [System]System.IO.Ports.SerialPort::ReadExisting()
		IL_04ab: stfld string datapick.Form1::TdataReceived
		IL_04b0: ldarg.0
		IL_04b1: ldfld string datapick.Form1::TdataReceived
		IL_04b6: ldc.i4.1
		IL_04b7: newarr [mscorlib]System.Char
		IL_04bc: stloc.s 5
		IL_04be: ldloc.s 5
		IL_04c0: ldc.i4.0
		IL_04c1: ldc.i4.s 10
		IL_04c3: stelem.i2
		IL_04c4: ldloc.s 5
		IL_04c6: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_04cb: stloc.3
		IL_04cc: br IL_06c9
		// loop start (head: IL_06c9)
			IL_04d1: nop
			IL_04d2: ldarg.0
			IL_04d3: ldfld string[] datapick.Form1::Bdate_lots
			IL_04d8: ldloc.2
			IL_04d9: ldloc.3
			IL_04da: ldloc.2
			IL_04db: ldelem.ref
			IL_04dc: ldc.i4.1
			IL_04dd: newarr [mscorlib]System.Char
			IL_04e2: stloc.s 5
			IL_04e4: ldloc.s 5
			IL_04e6: ldc.i4.0
			IL_04e7: ldc.i4.s 32
			IL_04e9: stelem.i2
			IL_04ea: ldloc.s 5
			IL_04ec: callvirt instance string[] [mscorlib]System.String::Split(char[])
			IL_04f1: ldc.i4.2
			IL_04f2: ldelem.ref
			IL_04f3: stelem.ref
			IL_04f4: ldarg.0
			IL_04f5: ldfld string[] datapick.Form1::Bdate_lots
			IL_04fa: ldloc.2
			IL_04fb: ldelem.ref
			IL_04fc: ldstr ";"
			IL_0501: callvirt instance bool [mscorlib]System.String::Contains(string)
			IL_0506: ldc.i4.0
			IL_0507: ceq
			IL_0509: stloc.s 4
			IL_050b: ldloc.s 4
			IL_050d: brtrue.s IL_0539

			IL_050f: ldarg.0
			IL_0510: ldfld string[] datapick.Form1::Bdate_lots
			IL_0515: ldloc.2
			IL_0516: ldarg.0
			IL_0517: ldfld string[] datapick.Form1::Bdate_lots
			IL_051c: ldloc.2
			IL_051d: ldelem.ref
			IL_051e: ldc.i4.0
			IL_051f: ldc.i4.1
			IL_0520: callvirt instance string [mscorlib]System.String::Substring(int32, int32)
			IL_0525: ldarg.0
			IL_0526: ldfld string[] datapick.Form1::Bdate_lots
			IL_052b: ldloc.2
			IL_052c: ldelem.ref
			IL_052d: ldc.i4.2
			IL_052e: callvirt instance string [mscorlib]System.String::Substring(int32)
			IL_0533: call string [mscorlib]System.String::Concat(string, string)
			IL_0538: stelem.ref

			IL_0539: ldarg.0
			IL_053a: ldfld int32[] datapick.Form1::nono_lots
			IL_053f: ldloc.2
			IL_0540: ldloc.3
			IL_0541: ldloc.2
			IL_0542: ldelem.ref
			IL_0543: ldc.i4.1
			IL_0544: newarr [mscorlib]System.Char
			IL_0549: stloc.s 5
			IL_054b: ldloc.s 5
			IL_054d: ldc.i4.0
			IL_054e: ldc.i4.s 32
			IL_0550: stelem.i2
			IL_0551: ldloc.s 5
			IL_0553: callvirt instance string[] [mscorlib]System.String::Split(char[])
			IL_0558: ldc.i4.0
			IL_0559: ldelem.ref
			IL_055a: ldc.i4.1
			IL_055b: newarr [mscorlib]System.Char
			IL_0560: stloc.s 5
			IL_0562: ldloc.s 5
			IL_0564: ldc.i4.0
			IL_0565: ldc.i4.s 46
			IL_0567: stelem.i2
			IL_0568: ldloc.s 5
			IL_056a: callvirt instance string [mscorlib]System.String::Trim(char[])
			IL_056f: call int32 [mscorlib]System.Convert::ToInt32(string)
			IL_0574: ldc.i4.1
			IL_0575: add
			IL_0576: stelem.i4
			IL_0577: ldarg.0
			IL_0578: ldfld string[] datapick.Form1::Date_lots
			IL_057d: ldloc.2
			IL_057e: ldloc.3
			IL_057f: ldloc.2
			IL_0580: ldelem.ref
			IL_0581: ldc.i4.1
			IL_0582: newarr [mscorlib]System.Char
			IL_0587: stloc.s 5
			IL_0589: ldloc.s 5
			IL_058b: ldc.i4.0
			IL_058c: ldc.i4.s 32
			IL_058e: stelem.i2
			IL_058f: ldloc.s 5
			IL_0591: callvirt instance string[] [mscorlib]System.String::Split(char[])
			IL_0596: ldc.i4.s 10
			IL_0598: ldelem.ref
			IL_0599: callvirt instance string [mscorlib]System.String::Trim()
			IL_059e: stelem.ref
			IL_059f: ldarg.0
			IL_05a0: ldfld string[] datapick.Form1::Time_lots
			IL_05a5: ldloc.2
			IL_05a6: ldloc.3
			IL_05a7: ldloc.2
			IL_05a8: ldelem.ref
			IL_05a9: ldc.i4.1
			IL_05aa: newarr [mscorlib]System.Char
			IL_05af: stloc.s 5
			IL_05b1: ldloc.s 5
			IL_05b3: ldc.i4.0
			IL_05b4: ldc.i4.s 32
			IL_05b6: stelem.i2
			IL_05b7: ldloc.s 5
			IL_05b9: callvirt instance string[] [mscorlib]System.String::Split(char[])
			IL_05be: ldc.i4.s 14
			IL_05c0: ldelem.ref
			IL_05c1: callvirt instance string [mscorlib]System.String::Trim()
			IL_05c6: stelem.ref
			IL_05c7: ldarg.0
			IL_05c8: ldfld string[] datapick.Form1::Date_lots
			IL_05cd: ldloc.2
			IL_05ce: ldelem.ref
			IL_05cf: ldc.i4.1
			IL_05d0: newarr [mscorlib]System.Char
			IL_05d5: stloc.s 5
			IL_05d7: ldloc.s 5
			IL_05d9: ldc.i4.0
			IL_05da: ldc.i4.s 45
			IL_05dc: stelem.i2
			IL_05dd: ldloc.s 5
			IL_05df: callvirt instance string[] [mscorlib]System.String::Split(char[])
			IL_05e4: ldc.i4.0
			IL_05e5: ldelem.ref
			IL_05e6: call int32 [mscorlib]System.Convert::ToInt32(string)
			IL_05eb: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
			IL_05f0: stloc.s 6
			IL_05f2: ldloca.s 6
			IL_05f4: call instance int32 [mscorlib]System.DateTime::get_Month()
			IL_05f9: clt
			IL_05fb: ldc.i4.0
			IL_05fc: ceq
			IL_05fe: stloc.s 4
			IL_0600: ldloc.s 4
			IL_0602: brtrue.s IL_0664

			IL_0604: nop
			IL_0605: ldarg.0
			IL_0606: ldfld string[] datapick.Form1::DateTime_lots
			IL_060b: ldloc.2
			IL_060c: ldc.i4.5
			IL_060d: newarr [mscorlib]System.String
			IL_0612: stloc.s 7
			IL_0614: ldloc.s 7
			IL_0616: ldc.i4.0
			IL_0617: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
			IL_061c: stloc.s 6
			IL_061e: ldloca.s 6
			IL_0620: call instance int32 [mscorlib]System.DateTime::get_Year()
			IL_0625: stloc.s 8
			IL_0627: ldloca.s 8
			IL_0629: call instance string [mscorlib]System.Int32::ToString()
			IL_062e: stelem.ref
			IL_062f: ldloc.s 7
			IL_0631: ldc.i4.1
			IL_0632: ldstr "-"
			IL_0637: stelem.ref
			IL_0638: ldloc.s 7
			IL_063a: ldc.i4.2
			IL_063b: ldarg.0
			IL_063c: ldfld string[] datapick.Form1::Date_lots
			IL_0641: ldloc.2
			IL_0642: ldelem.ref
			IL_0643: stelem.ref
			IL_0644: ldloc.s 7
			IL_0646: ldc.i4.3
			IL_0647: ldstr " "
			IL_064c: stelem.ref
			IL_064d: ldloc.s 7
			IL_064f: ldc.i4.4
			IL_0650: ldarg.0
			IL_0651: ldfld string[] datapick.Form1::Time_lots
			IL_0656: ldloc.2
			IL_0657: ldelem.ref
			IL_0658: stelem.ref
			IL_0659: ldloc.s 7
			IL_065b: call string [mscorlib]System.String::Concat(string[])
			IL_0660: stelem.ref
			IL_0661: nop
			IL_0662: br.s IL_06c4

			IL_0664: nop
			IL_0665: ldarg.0
			IL_0666: ldfld string[] datapick.Form1::DateTime_lots
			IL_066b: ldloc.2
			IL_066c: ldc.i4.5
			IL_066d: newarr [mscorlib]System.String
			IL_0672: stloc.s 7
			IL_0674: ldloc.s 7
			IL_0676: ldc.i4.0
			IL_0677: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
			IL_067c: stloc.s 6
			IL_067e: ldloca.s 6
			IL_0680: call instance int32 [mscorlib]System.DateTime::get_Year()
			IL_0685: ldc.i4.1
			IL_0686: sub
			IL_0687: stloc.s 8
			IL_0689: ldloca.s 8
			IL_068b: call instance string [mscorlib]System.Int32::ToString()
			IL_0690: stelem.ref
			IL_0691: ldloc.s 7
			IL_0693: ldc.i4.1
			IL_0694: ldstr "-"
			IL_0699: stelem.ref
			IL_069a: ldloc.s 7
			IL_069c: ldc.i4.2
			IL_069d: ldarg.0
			IL_069e: ldfld string[] datapick.Form1::Date_lots
			IL_06a3: ldloc.2
			IL_06a4: ldelem.ref
			IL_06a5: stelem.ref
			IL_06a6: ldloc.s 7
			IL_06a8: ldc.i4.3
			IL_06a9: ldstr " "
			IL_06ae: stelem.ref
			IL_06af: ldloc.s 7
			IL_06b1: ldc.i4.4
			IL_06b2: ldarg.0
			IL_06b3: ldfld string[] datapick.Form1::Time_lots
			IL_06b8: ldloc.2
			IL_06b9: ldelem.ref
			IL_06ba: stelem.ref
			IL_06bb: ldloc.s 7
			IL_06bd: call string [mscorlib]System.String::Concat(string[])
			IL_06c2: stelem.ref
			IL_06c3: nop

			IL_06c4: nop
			IL_06c5: ldloc.2
			IL_06c6: ldc.i4.1
			IL_06c7: add
			IL_06c8: stloc.2

			IL_06c9: ldloc.2
			IL_06ca: ldc.i4 500
			IL_06cf: clt
			IL_06d1: stloc.s 4
			IL_06d3: ldloc.s 4
			IL_06d5: brtrue IL_04d1
		// end loop

		IL_06da: ldarg.0
		IL_06db: ldc.i4.1
		IL_06dc: stfld bool datapick.Form1::Ready_lots
		IL_06e1: nop

		IL_06e2: nop
		IL_06e3: br IL_07cf

		IL_06e8: ldarg.0
		IL_06e9: ldfld int32 datapick.Form1::FlagEnquire
		IL_06ee: ldc.i4.1
		IL_06ef: ceq
		IL_06f1: ldc.i4.0
		IL_06f2: ceq
		IL_06f4: stloc.s 4
		IL_06f6: ldloc.s 4
		IL_06f8: brtrue IL_07cf

		IL_06fd: nop
		IL_06fe: ldc.i4.5
		IL_06ff: newarr [mscorlib]System.Char
		IL_0704: stloc.0
		IL_0705: ldarg.0
		IL_0706: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_070b: ldloc.0
		IL_070c: ldc.i4.0
		IL_070d: ldc.i4.5
		IL_070e: callvirt instance int32 [System]System.IO.Ports.SerialPort::Read(char[], int32, int32)
		IL_0713: pop
		IL_0714: ldarg.0
		IL_0715: ldloc.0
		IL_0716: newobj instance void [mscorlib]System.String::.ctor(char[])
		IL_071b: stfld string datapick.Form1::TdataReceived
		IL_0720: ldarg.0
		IL_0721: ldfld string datapick.Form1::TdataReceived
		IL_0726: ldstr "W"
		IL_072b: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_0730: brtrue.s IL_0744

		IL_0732: ldarg.0
		IL_0733: ldfld string datapick.Form1::TdataReceived
		IL_0738: ldstr "N"
		IL_073d: callvirt instance bool [mscorlib]System.String::StartsWith(string)
		IL_0742: brfalse.s IL_0759

		IL_0744: ldarg.0
		IL_0745: ldfld string datapick.Form1::TdataReceived
		IL_074a: ldstr "\n"
		IL_074f: callvirt instance bool [mscorlib]System.String::EndsWith(string)
		IL_0754: ldc.i4.0
		IL_0755: ceq
		IL_0757: br.s IL_075a

		IL_0759: ldc.i4.1

		IL_075a: nop
		IL_075b: stloc.s 4
		IL_075d: ldloc.s 4
		IL_075f: brtrue.s IL_07cc

		IL_0761: nop
		IL_0762: ldarg.0
		IL_0763: ldarg.0
		IL_0764: ldfld string datapick.Form1::TdataReceived
		IL_0769: ldc.i4.1
		IL_076a: newarr [mscorlib]System.Char
		IL_076f: stloc.s 5
		IL_0771: ldloc.s 5
		IL_0773: ldc.i4.0
		IL_0774: ldc.i4.s 10
		IL_0776: stelem.i2
		IL_0777: ldloc.s 5
		IL_0779: callvirt instance string [mscorlib]System.String::TrimEnd(char[])
		IL_077e: stfld string datapick.Form1::TdataReceived
		IL_0783: ldarg.0
		IL_0784: ldfld string datapick.Form1::TdataReceived
		IL_0789: ldstr "WEAK"
		IL_078e: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0793: ldc.i4.0
		IL_0794: ceq
		IL_0796: stloc.s 4
		IL_0798: ldloc.s 4
		IL_079a: brtrue.s IL_07a7

		IL_079c: nop
		IL_079d: ldarg.0
		IL_079e: ldc.i4.2
		IL_079f: stfld int32 datapick.Form1::FlagEnquire
		IL_07a4: nop
		IL_07a5: br.s IL_07c9

		IL_07a7: ldarg.0
		IL_07a8: ldfld string datapick.Form1::TdataReceived
		IL_07ad: ldstr "NORM"
		IL_07b2: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_07b7: ldc.i4.0
		IL_07b8: ceq
		IL_07ba: stloc.s 4
		IL_07bc: ldloc.s 4
		IL_07be: brtrue.s IL_07c9

		IL_07c0: nop
		IL_07c1: ldarg.0
		IL_07c2: ldc.i4.3
		IL_07c3: stfld int32 datapick.Form1::FlagEnquire
		IL_07c8: nop

		IL_07c9: nop
		IL_07ca: br.s IL_07ce

		IL_07cc: br.s IL_07cf

		IL_07ce: nop

		IL_07cf: nop
		IL_07d0: ret
	} // end of method Form1::serialPort1_DataReceived

	.method private hidebysig 
		instance void InitialSetting () cil managed 
	{
		// Method begins at RVA 0x2bf4
		// Header size: 12
		// Code size: 632 (0x278)
		.maxstack 3
		.locals init (
			[0] string Model,
			[1] int32 i,
			[2] string ComWay,
			[3] string COMPORTNAME,
			[4] string COMBAUDRATE,
			[5] string DataType,
			[6] string Speed,
			[7] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldstr "MODEL"
		IL_0006: ldstr "CH-1300"
		IL_000b: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_0010: stloc.0
		IL_0011: ldc.i4.0
		IL_0012: stloc.1
		IL_0013: br.s IL_0050
		// loop start (head: IL_0050)
			IL_0015: nop
			IL_0016: ldloc.0
			IL_0017: ldarg.0
			IL_0018: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
			IL_001d: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_0022: ldloc.1
			IL_0023: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Item(int32)
			IL_0028: callvirt instance string [mscorlib]System.Object::ToString()
			IL_002d: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_0032: ldc.i4.0
			IL_0033: ceq
			IL_0035: stloc.s 7
			IL_0037: ldloc.s 7
			IL_0039: brtrue.s IL_004b

			IL_003b: nop
			IL_003c: ldarg.0
			IL_003d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
			IL_0042: ldloc.1
			IL_0043: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_0048: nop
			IL_0049: br.s IL_0069

			IL_004b: nop
			IL_004c: ldloc.1
			IL_004d: ldc.i4.1
			IL_004e: add
			IL_004f: stloc.1

			IL_0050: ldloc.1
			IL_0051: ldarg.0
			IL_0052: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
			IL_0057: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_005c: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
			IL_0061: clt
			IL_0063: stloc.s 7
			IL_0065: ldloc.s 7
			IL_0067: brtrue.s IL_0015
		// end loop

		IL_0069: ldstr "COMWAY"
		IL_006e: ldstr "串口"
		IL_0073: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_0078: stloc.2
		IL_0079: ldc.i4.0
		IL_007a: stloc.1
		IL_007b: br.s IL_00b8
		// loop start (head: IL_00b8)
			IL_007d: nop
			IL_007e: ldloc.2
			IL_007f: ldarg.0
			IL_0080: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
			IL_0085: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_008a: ldloc.1
			IL_008b: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Item(int32)
			IL_0090: callvirt instance string [mscorlib]System.Object::ToString()
			IL_0095: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_009a: ldc.i4.0
			IL_009b: ceq
			IL_009d: stloc.s 7
			IL_009f: ldloc.s 7
			IL_00a1: brtrue.s IL_00b3

			IL_00a3: nop
			IL_00a4: ldarg.0
			IL_00a5: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
			IL_00aa: ldloc.1
			IL_00ab: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_00b0: nop
			IL_00b1: br.s IL_00d1

			IL_00b3: nop
			IL_00b4: ldloc.1
			IL_00b5: ldc.i4.1
			IL_00b6: add
			IL_00b7: stloc.1

			IL_00b8: ldloc.1
			IL_00b9: ldarg.0
			IL_00ba: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
			IL_00bf: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_00c4: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
			IL_00c9: clt
			IL_00cb: stloc.s 7
			IL_00cd: ldloc.s 7
			IL_00cf: brtrue.s IL_007d
		// end loop

		IL_00d1: ldstr "COMMSET"
		IL_00d6: ldstr "COM1"
		IL_00db: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_00e0: stloc.3
		IL_00e1: ldstr "BADURATE"
		IL_00e6: ldstr "9600"
		IL_00eb: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_00f0: stloc.s 4
		IL_00f2: ldc.i4.0
		IL_00f3: stloc.1
		IL_00f4: br.s IL_0131
		// loop start (head: IL_0131)
			IL_00f6: nop
			IL_00f7: ldloc.3
			IL_00f8: ldarg.0
			IL_00f9: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
			IL_00fe: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_0103: ldloc.1
			IL_0104: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Item(int32)
			IL_0109: callvirt instance string [mscorlib]System.Object::ToString()
			IL_010e: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_0113: ldc.i4.0
			IL_0114: ceq
			IL_0116: stloc.s 7
			IL_0118: ldloc.s 7
			IL_011a: brtrue.s IL_012c

			IL_011c: nop
			IL_011d: ldarg.0
			IL_011e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
			IL_0123: ldloc.1
			IL_0124: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_0129: nop
			IL_012a: br.s IL_014a

			IL_012c: nop
			IL_012d: ldloc.1
			IL_012e: ldc.i4.1
			IL_012f: add
			IL_0130: stloc.1

			IL_0131: ldloc.1
			IL_0132: ldarg.0
			IL_0133: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
			IL_0138: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_013d: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
			IL_0142: clt
			IL_0144: stloc.s 7
			IL_0146: ldloc.s 7
			IL_0148: brtrue.s IL_00f6
		// end loop

		IL_014a: ldc.i4.0
		IL_014b: stloc.1
		IL_014c: br.s IL_018a
		// loop start (head: IL_018a)
			IL_014e: nop
			IL_014f: ldloc.s 4
			IL_0151: ldarg.0
			IL_0152: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
			IL_0157: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_015c: ldloc.1
			IL_015d: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Item(int32)
			IL_0162: callvirt instance string [mscorlib]System.Object::ToString()
			IL_0167: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_016c: ldc.i4.0
			IL_016d: ceq
			IL_016f: stloc.s 7
			IL_0171: ldloc.s 7
			IL_0173: brtrue.s IL_0185

			IL_0175: nop
			IL_0176: ldarg.0
			IL_0177: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
			IL_017c: ldloc.1
			IL_017d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_0182: nop
			IL_0183: br.s IL_01a3

			IL_0185: nop
			IL_0186: ldloc.1
			IL_0187: ldc.i4.1
			IL_0188: add
			IL_0189: stloc.1

			IL_018a: ldloc.1
			IL_018b: ldarg.0
			IL_018c: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
			IL_0191: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_0196: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
			IL_019b: clt
			IL_019d: stloc.s 7
			IL_019f: ldloc.s 7
			IL_01a1: brtrue.s IL_014e
		// end loop

		IL_01a3: ldstr "DATATYPE"
		IL_01a8: ldstr "普通数据"
		IL_01ad: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_01b2: stloc.s 5
		IL_01b4: ldc.i4.0
		IL_01b5: stloc.1
		IL_01b6: br.s IL_01f4
		// loop start (head: IL_01f4)
			IL_01b8: nop
			IL_01b9: ldloc.s 5
			IL_01bb: ldarg.0
			IL_01bc: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
			IL_01c1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_01c6: ldloc.1
			IL_01c7: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Item(int32)
			IL_01cc: callvirt instance string [mscorlib]System.Object::ToString()
			IL_01d1: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_01d6: ldc.i4.0
			IL_01d7: ceq
			IL_01d9: stloc.s 7
			IL_01db: ldloc.s 7
			IL_01dd: brtrue.s IL_01ef

			IL_01df: nop
			IL_01e0: ldarg.0
			IL_01e1: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
			IL_01e6: ldloc.1
			IL_01e7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_01ec: nop
			IL_01ed: br.s IL_020d

			IL_01ef: nop
			IL_01f0: ldloc.1
			IL_01f1: ldc.i4.1
			IL_01f2: add
			IL_01f3: stloc.1

			IL_01f4: ldloc.1
			IL_01f5: ldarg.0
			IL_01f6: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
			IL_01fb: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_0200: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
			IL_0205: clt
			IL_0207: stloc.s 7
			IL_0209: ldloc.s 7
			IL_020b: brtrue.s IL_01b8
		// end loop

		IL_020d: ldstr "SPEED"
		IL_0212: ldstr "50组/s"
		IL_0217: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_021c: stloc.s 6
		IL_021e: ldc.i4.0
		IL_021f: stloc.1
		IL_0220: br.s IL_025e
		// loop start (head: IL_025e)
			IL_0222: nop
			IL_0223: ldloc.s 6
			IL_0225: ldarg.0
			IL_0226: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
			IL_022b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_0230: ldloc.1
			IL_0231: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Item(int32)
			IL_0236: callvirt instance string [mscorlib]System.Object::ToString()
			IL_023b: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_0240: ldc.i4.0
			IL_0241: ceq
			IL_0243: stloc.s 7
			IL_0245: ldloc.s 7
			IL_0247: brtrue.s IL_0259

			IL_0249: nop
			IL_024a: ldarg.0
			IL_024b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
			IL_0250: ldloc.1
			IL_0251: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_0256: nop
			IL_0257: br.s IL_0277

			IL_0259: nop
			IL_025a: ldloc.1
			IL_025b: ldc.i4.1
			IL_025c: add
			IL_025d: stloc.1

			IL_025e: ldloc.1
			IL_025f: ldarg.0
			IL_0260: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
			IL_0265: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
			IL_026a: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
			IL_026f: clt
			IL_0271: stloc.s 7
			IL_0273: ldloc.s 7
			IL_0275: brtrue.s IL_0222
		// end loop

		IL_0277: ret
	} // end of method Form1::InitialSetting

	.method private hidebysig 
		instance void Form1_Load (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x2e78
		// Header size: 12
		// Code size: 1125 (0x465)
		.maxstack 6
		.locals init (
			[0] int32 i,
			[1] float64 x,
			[2] float64 y,
			[3] valuetype [mscorlib]System.DateTime CS$0$0000,
			[4] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_0007: ldc.i4.1
		IL_0008: callvirt instance void [System.Windows.Forms]System.Windows.Forms.StatusStrip::set_LayoutStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ToolStripLayoutStyle)
		IL_000d: nop
		IL_000e: ldarg.0
		IL_000f: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::toolStripStatusLabel2
		IL_0014: ldc.i4.1
		IL_0015: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel::set_Alignment(valuetype [System.Windows.Forms]System.Windows.Forms.ToolStripItemAlignment)
		IL_001a: nop
		IL_001b: ldarg.0
		IL_001c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0021: ldc.i4.0
		IL_0022: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_RowHeadersVisible(bool)
		IL_0027: nop
		IL_0028: ldarg.0
		IL_0029: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_002e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_0033: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::Clear()
		IL_0038: nop
		IL_0039: ldarg.0
		IL_003a: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_003f: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0044: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::Clear()
		IL_0049: nop
		IL_004a: ldarg.0
		IL_004b: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0050: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0055: ldstr "no"
		IL_005a: ldstr "序号"
		IL_005f: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::Add(string, string)
		IL_0064: pop
		IL_0065: ldarg.0
		IL_0066: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_006b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0070: ldstr "T"
		IL_0075: ldstr "磁场值(mT)"
		IL_007a: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::Add(string, string)
		IL_007f: pop
		IL_0080: ldarg.0
		IL_0081: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0086: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_008b: ldstr "H"
		IL_0090: ldstr "频率(Hz)"
		IL_0095: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::Add(string, string)
		IL_009a: pop
		IL_009b: ldarg.0
		IL_009c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_00a1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_00a6: ldstr "C"
		IL_00ab: ldstr "温度(℃)"
		IL_00b0: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::Add(string, string)
		IL_00b5: pop
		IL_00b6: ldarg.0
		IL_00b7: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_00bc: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_00c1: ldstr "TIME"
		IL_00c6: ldstr "时间"
		IL_00cb: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::Add(string, string)
		IL_00d0: pop
		IL_00d1: ldarg.0
		IL_00d2: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_00d7: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_00dc: ldstr "no"
		IL_00e1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_00e6: ldc.i4.s 74
		IL_00e8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_Width(int32)
		IL_00ed: nop
		IL_00ee: ldarg.0
		IL_00ef: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_00f4: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_00f9: ldstr "T"
		IL_00fe: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0103: ldc.i4.s 104
		IL_0105: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_Width(int32)
		IL_010a: nop
		IL_010b: ldarg.0
		IL_010c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0111: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0116: ldstr "H"
		IL_011b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0120: ldc.i4.s 90
		IL_0122: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_Width(int32)
		IL_0127: nop
		IL_0128: ldarg.0
		IL_0129: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_012e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0133: ldstr "C"
		IL_0138: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_013d: ldc.i4.s 90
		IL_013f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_Width(int32)
		IL_0144: nop
		IL_0145: ldarg.0
		IL_0146: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_014b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0150: ldstr "TIME"
		IL_0155: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_015a: ldc.i4 163
		IL_015f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_Width(int32)
		IL_0164: nop
		IL_0165: ldarg.0
		IL_0166: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_016b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0170: ldc.i4.0
		IL_0171: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
		IL_0176: ldc.i4.0
		IL_0177: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_SortMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnSortMode)
		IL_017c: nop
		IL_017d: ldarg.0
		IL_017e: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0183: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_0188: ldc.i4.1
		IL_0189: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
		IL_018e: ldc.i4.0
		IL_018f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_SortMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnSortMode)
		IL_0194: nop
		IL_0195: ldarg.0
		IL_0196: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_019b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_01a0: ldc.i4.2
		IL_01a1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
		IL_01a6: ldc.i4.0
		IL_01a7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_SortMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnSortMode)
		IL_01ac: nop
		IL_01ad: ldarg.0
		IL_01ae: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_01b3: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_01b8: ldc.i4.3
		IL_01b9: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
		IL_01be: ldc.i4.0
		IL_01bf: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_SortMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnSortMode)
		IL_01c4: nop
		IL_01c5: ldarg.0
		IL_01c6: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_01cb: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_01d0: ldc.i4.4
		IL_01d1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
		IL_01d6: ldc.i4.0
		IL_01d7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_SortMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnSortMode)
		IL_01dc: nop
		IL_01dd: ldarg.0
		IL_01de: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_01e3: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_01e8: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Green()
		IL_01ed: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Blue()
		IL_01f2: ldc.r4 45
		IL_01f7: newobj instance void [ZedGraph]ZedGraph.Fill::.ctor(valuetype [System.Drawing]System.Drawing.Color, valuetype [System.Drawing]System.Drawing.Color, float32)
		IL_01fc: callvirt instance void [ZedGraph]ZedGraph.PaneBase::set_Fill(class [ZedGraph]ZedGraph.Fill)
		IL_0201: nop
		IL_0202: ldarg.0
		IL_0203: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0208: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_020d: callvirt instance class [ZedGraph]ZedGraph.Chart [ZedGraph]ZedGraph.GraphPane::get_Chart()
		IL_0212: callvirt instance class [ZedGraph]ZedGraph.Fill [ZedGraph]ZedGraph.Chart::get_Fill()
		IL_0217: ldc.i4.0
		IL_0218: callvirt instance void [ZedGraph]ZedGraph.Fill::set_Type(valuetype [ZedGraph]ZedGraph.FillType)
		IL_021d: nop
		IL_021e: ldarg.0
		IL_021f: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0224: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0229: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_022e: ldstr "实时磁场大小变化图"
		IL_0233: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0238: nop
		IL_0239: ldarg.0
		IL_023a: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_023f: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0244: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0249: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_024e: ldstr "时间"
		IL_0253: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0258: nop
		IL_0259: ldarg.0
		IL_025a: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_025f: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0264: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_0269: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_026e: ldstr "磁场值(mT)"
		IL_0273: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0278: nop
		IL_0279: ldarg.0
		IL_027a: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_027f: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0284: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0289: ldc.i4.5
		IL_028a: callvirt instance void [ZedGraph]ZedGraph.Axis::set_Type(valuetype [ZedGraph]ZedGraph.AxisType)
		IL_028f: nop
		IL_0290: ldarg.0
		IL_0291: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0296: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_029b: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_02a0: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_02a5: ldc.r8 100
		IL_02ae: callvirt instance void [ZedGraph]ZedGraph.Scale::set_Max(float64)
		IL_02b3: nop
		IL_02b4: ldarg.0
		IL_02b5: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_02ba: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_02bf: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_02c4: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_02c9: ldc.r8 20
		IL_02d2: callvirt instance void [ZedGraph]ZedGraph.Scale::set_MajorStep(float64)
		IL_02d7: nop
		IL_02d8: ldarg.0
		IL_02d9: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_02de: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_02e3: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_02e8: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_02ed: callvirt instance class [ZedGraph]ZedGraph.FontSpec [ZedGraph]ZedGraph.Scale::get_FontSpec()
		IL_02f2: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Gold()
		IL_02f7: callvirt instance void [ZedGraph]ZedGraph.FontSpec::set_FontColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_02fc: nop
		IL_02fd: ldarg.0
		IL_02fe: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0303: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0308: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_030d: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_0312: callvirt instance class [ZedGraph]ZedGraph.FontSpec [ZedGraph]ZedGraph.Scale::get_FontSpec()
		IL_0317: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Gold()
		IL_031c: callvirt instance void [ZedGraph]ZedGraph.FontSpec::set_FontColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_0321: nop
		IL_0322: ldarg.0
		IL_0323: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0328: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_032d: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_0332: callvirt instance class [ZedGraph]ZedGraph.FontSpec [ZedGraph]ZedGraph.Label::get_FontSpec()
		IL_0337: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_White()
		IL_033c: callvirt instance void [ZedGraph]ZedGraph.FontSpec::set_FontColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_0341: nop
		IL_0342: ldarg.0
		IL_0343: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0348: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_034d: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0352: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0357: callvirt instance class [ZedGraph]ZedGraph.FontSpec [ZedGraph]ZedGraph.Label::get_FontSpec()
		IL_035c: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_White()
		IL_0361: callvirt instance void [ZedGraph]ZedGraph.FontSpec::set_FontColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_0366: nop
		IL_0367: ldarg.0
		IL_0368: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_036d: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0372: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_0377: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_037c: callvirt instance class [ZedGraph]ZedGraph.FontSpec [ZedGraph]ZedGraph.Label::get_FontSpec()
		IL_0381: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_White()
		IL_0386: callvirt instance void [ZedGraph]ZedGraph.FontSpec::set_FontColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_038b: nop
		IL_038c: ldarg.0
		IL_038d: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0392: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0397: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_039c: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Transparent()
		IL_03a1: callvirt instance void [ZedGraph]ZedGraph.Axis::set_Color(valuetype [System.Drawing]System.Drawing.Color)
		IL_03a6: nop
		IL_03a7: ldc.i4.0
		IL_03a8: stloc.0
		IL_03a9: br.s IL_03e8
		// loop start (head: IL_03e8)
			IL_03ab: nop
			IL_03ac: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
			IL_03b1: stloc.3
			IL_03b2: ldloca.s 3
			IL_03b4: ldc.i4.s 100
			IL_03b6: ldloc.0
			IL_03b7: sub
			IL_03b8: neg
			IL_03b9: conv.r8
			IL_03ba: call instance valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::AddSeconds(float64)
			IL_03bf: newobj instance void [ZedGraph]ZedGraph.XDate::.ctor(valuetype [mscorlib]System.DateTime)
			IL_03c4: call float64 [ZedGraph]ZedGraph.XDate::op_Implicit(valuetype [ZedGraph]ZedGraph.XDate)
			IL_03c9: conv.r8
			IL_03ca: stloc.1
			IL_03cb: ldc.r8 0.0
			IL_03d4: stloc.2
			IL_03d5: ldarg.0
			IL_03d6: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
			IL_03db: ldloc.1
			IL_03dc: ldloc.2
			IL_03dd: callvirt instance void [ZedGraph]ZedGraph.PointPairList::Add(float64, float64)
			IL_03e2: nop
			IL_03e3: nop
			IL_03e4: ldloc.0
			IL_03e5: ldc.i4.1
			IL_03e6: add
			IL_03e7: stloc.0

			IL_03e8: ldloc.0
			IL_03e9: ldc.i4.s 100
			IL_03eb: cgt
			IL_03ed: ldc.i4.0
			IL_03ee: ceq
			IL_03f0: stloc.s 4
			IL_03f2: ldloc.s 4
			IL_03f4: brtrue.s IL_03ab
		// end loop

		IL_03f6: ldarg.0
		IL_03f7: ldarg.0
		IL_03f8: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_03fd: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0402: ldstr ""
		IL_0407: ldarg.0
		IL_0408: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_040d: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Yellow()
		IL_0412: ldc.i4.s 12
		IL_0414: callvirt instance class [ZedGraph]ZedGraph.LineItem [ZedGraph]ZedGraph.GraphPane::AddCurve(string, class [ZedGraph]ZedGraph.IPointList, valuetype [System.Drawing]System.Drawing.Color, valuetype [ZedGraph]ZedGraph.SymbolType)
		IL_0419: stfld class [ZedGraph]ZedGraph.LineItem datapick.Form1::myCurve
		IL_041e: ldarg.0
		IL_041f: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0424: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0429: nop
		IL_042a: ldarg.0
		IL_042b: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0430: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_0435: nop
		IL_0436: ldarg.0
		IL_0437: call instance void datapick.Form1::InitialSetting()
		IL_043c: nop
		IL_043d: ldarg.0
		IL_043e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_0443: ldc.i4.0
		IL_0444: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_0449: nop
		IL_044a: ldarg.0
		IL_044b: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_0450: ldc.i4.1
		IL_0451: callvirt instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::set_Checked(bool)
		IL_0456: nop
		IL_0457: ldarg.0
		IL_0458: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_045d: ldc.i4.0
		IL_045e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::set_Checked(bool)
		IL_0463: nop
		IL_0464: ret
	} // end of method Form1::Form1_Load

	.method private hidebysig 
		instance void UnitChange (
			float64 Bdata,
			string Bdatadisplay
		) cil managed 
	{
		// Method begins at RVA 0x32ec
		// Header size: 12
		// Code size: 3129 (0xc39)
		.maxstack 4
		.locals init (
			[0] bool CS$4$0000,
			[1] int32 CS$4$0001,
			[2] float64 CS$0$0002
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld bool datapick.Form1::dwChangeFlag
		IL_0007: ldc.i4.0
		IL_0008: ceq
		IL_000a: stloc.0
		IL_000b: ldloc.0
		IL_000c: brtrue.s IL_0048

		IL_000e: nop
		IL_000f: ldarg.0
		IL_0010: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0015: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_001a: ldc.i4.2
		IL_001b: clt
		IL_001d: ldc.i4.0
		IL_001e: ceq
		IL_0020: stloc.0
		IL_0021: ldloc.0
		IL_0022: brtrue.s IL_0033

		IL_0024: ldarg.0
		IL_0025: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_002a: ldc.i4.2
		IL_002b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_0030: nop
		IL_0031: br.s IL_0040

		IL_0033: ldarg.0
		IL_0034: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0039: ldc.i4.0
		IL_003a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_003f: nop

		IL_0040: ldarg.0
		IL_0041: ldc.i4.0
		IL_0042: stfld bool datapick.Form1::dwChangeFlag
		IL_0047: nop

		IL_0048: ldarg.0
		IL_0049: ldfld int32 datapick.Form1::DWflag
		IL_004e: stloc.1
		IL_004f: ldloc.1
		IL_0050: ldc.i4.1
		IL_0051: sub
		IL_0052: switch (IL_007c, IL_0130, IL_03aa, IL_0669, IL_08e3, IL_08f5, IL_0a7d, IL_0a90)

		IL_0077: br IL_0c38

		IL_007c: nop
		IL_007d: ldarg.1
		IL_007e: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0083: ldc.r8 2900
		IL_008c: cgt.un
		IL_008e: stloc.0
		IL_008f: ldloc.0
		IL_0090: brtrue.s IL_00b4

		IL_0092: nop
		IL_0093: ldarg.0
		IL_0094: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0099: ldarg.2
		IL_009a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_009f: nop
		IL_00a0: ldarg.0
		IL_00a1: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_00a6: ldstr "磁场值(mT)"
		IL_00ab: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_00b0: nop
		IL_00b1: nop
		IL_00b2: br.s IL_012b

		IL_00b4: nop
		IL_00b5: ldarg.0
		IL_00b6: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_00bb: ldstr "磁场值(T)"
		IL_00c0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_00c5: nop
		IL_00c6: ldarg.1
		IL_00c7: ldc.r8 0.0
		IL_00d0: clt.un
		IL_00d2: stloc.0
		IL_00d3: ldloc.0
		IL_00d4: brtrue.s IL_0106

		IL_00d6: ldarg.0
		IL_00d7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_00dc: ldstr "+"
		IL_00e1: ldarg.1
		IL_00e2: ldc.r8 1000
		IL_00eb: div
		IL_00ec: stloc.2
		IL_00ed: ldloca.s 2
		IL_00ef: ldstr "00.0000"
		IL_00f4: call instance string [mscorlib]System.Double::ToString(string)
		IL_00f9: call string [mscorlib]System.String::Concat(string, string)
		IL_00fe: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0103: nop
		IL_0104: br.s IL_012a

		IL_0106: ldarg.0
		IL_0107: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_010c: ldarg.1
		IL_010d: ldc.r8 1000
		IL_0116: div
		IL_0117: stloc.2
		IL_0118: ldloca.s 2
		IL_011a: ldstr "00.0000"
		IL_011f: call instance string [mscorlib]System.Double::ToString(string)
		IL_0124: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0129: nop

		IL_012a: nop

		IL_012b: br IL_0c38

		IL_0130: ldarg.1
		IL_0131: ldc.r8 10
		IL_013a: mul
		IL_013b: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0140: ldc.r8 300
		IL_0149: cgt.un
		IL_014b: stloc.0
		IL_014c: ldloc.0
		IL_014d: brtrue IL_01d2

		IL_0152: nop
		IL_0153: ldarg.0
		IL_0154: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_0159: ldstr "磁场值(G)"
		IL_015e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0163: nop
		IL_0164: ldarg.1
		IL_0165: ldc.r8 0.0
		IL_016e: clt.un
		IL_0170: stloc.0
		IL_0171: ldloc.0
		IL_0172: brtrue.s IL_01a6

		IL_0174: nop
		IL_0175: ldarg.0
		IL_0176: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_017b: ldstr "+"
		IL_0180: ldarg.1
		IL_0181: ldc.r8 10
		IL_018a: mul
		IL_018b: stloc.2
		IL_018c: ldloca.s 2
		IL_018e: ldstr "000.000"
		IL_0193: call instance string [mscorlib]System.Double::ToString(string)
		IL_0198: call string [mscorlib]System.String::Concat(string, string)
		IL_019d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_01a2: nop
		IL_01a3: nop
		IL_01a4: br.s IL_01cc

		IL_01a6: nop
		IL_01a7: ldarg.0
		IL_01a8: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_01ad: ldarg.1
		IL_01ae: ldc.r8 10
		IL_01b7: mul
		IL_01b8: stloc.2
		IL_01b9: ldloca.s 2
		IL_01bb: ldstr "000.000"
		IL_01c0: call instance string [mscorlib]System.Double::ToString(string)
		IL_01c5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_01ca: nop
		IL_01cb: nop

		IL_01cc: nop
		IL_01cd: br IL_03a5

		IL_01d2: ldarg.1
		IL_01d3: ldc.r8 10
		IL_01dc: mul
		IL_01dd: call float64 [mscorlib]System.Math::Abs(float64)
		IL_01e2: ldc.r8 3000
		IL_01eb: cgt.un
		IL_01ed: stloc.0
		IL_01ee: ldloc.0
		IL_01ef: brtrue IL_0274

		IL_01f4: nop
		IL_01f5: ldarg.0
		IL_01f6: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_01fb: ldstr "磁场值(G)"
		IL_0200: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0205: nop
		IL_0206: ldarg.1
		IL_0207: ldc.r8 0.0
		IL_0210: clt.un
		IL_0212: stloc.0
		IL_0213: ldloc.0
		IL_0214: brtrue.s IL_0248

		IL_0216: nop
		IL_0217: ldarg.0
		IL_0218: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_021d: ldstr "+"
		IL_0222: ldarg.1
		IL_0223: ldc.r8 10
		IL_022c: mul
		IL_022d: stloc.2
		IL_022e: ldloca.s 2
		IL_0230: ldstr "0000.00"
		IL_0235: call instance string [mscorlib]System.Double::ToString(string)
		IL_023a: call string [mscorlib]System.String::Concat(string, string)
		IL_023f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0244: nop
		IL_0245: nop
		IL_0246: br.s IL_026e

		IL_0248: nop
		IL_0249: ldarg.0
		IL_024a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_024f: ldarg.1
		IL_0250: ldc.r8 10
		IL_0259: mul
		IL_025a: stloc.2
		IL_025b: ldloca.s 2
		IL_025d: ldstr "0000.00"
		IL_0262: call instance string [mscorlib]System.Double::ToString(string)
		IL_0267: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_026c: nop
		IL_026d: nop

		IL_026e: nop
		IL_026f: br IL_03a5

		IL_0274: ldarg.1
		IL_0275: ldc.r8 10
		IL_027e: mul
		IL_027f: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0284: ldc.r8 29000
		IL_028d: cgt.un
		IL_028f: stloc.0
		IL_0290: ldloc.0
		IL_0291: brtrue IL_0316

		IL_0296: nop
		IL_0297: ldarg.0
		IL_0298: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_029d: ldstr "磁场值(G)"
		IL_02a2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_02a7: nop
		IL_02a8: ldarg.1
		IL_02a9: ldc.r8 0.0
		IL_02b2: clt.un
		IL_02b4: stloc.0
		IL_02b5: ldloc.0
		IL_02b6: brtrue.s IL_02ea

		IL_02b8: nop
		IL_02b9: ldarg.0
		IL_02ba: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_02bf: ldstr "+"
		IL_02c4: ldarg.1
		IL_02c5: ldc.r8 10
		IL_02ce: mul
		IL_02cf: stloc.2
		IL_02d0: ldloca.s 2
		IL_02d2: ldstr "00000.0"
		IL_02d7: call instance string [mscorlib]System.Double::ToString(string)
		IL_02dc: call string [mscorlib]System.String::Concat(string, string)
		IL_02e1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_02e6: nop
		IL_02e7: nop
		IL_02e8: br.s IL_0310

		IL_02ea: nop
		IL_02eb: ldarg.0
		IL_02ec: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_02f1: ldarg.1
		IL_02f2: ldc.r8 10
		IL_02fb: mul
		IL_02fc: stloc.2
		IL_02fd: ldloca.s 2
		IL_02ff: ldstr "00000.0"
		IL_0304: call instance string [mscorlib]System.Double::ToString(string)
		IL_0309: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_030e: nop
		IL_030f: nop

		IL_0310: nop
		IL_0311: br IL_03a5

		IL_0316: nop
		IL_0317: ldarg.0
		IL_0318: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_031d: ldstr "磁场值(KG)"
		IL_0322: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0327: nop
		IL_0328: ldarg.1
		IL_0329: ldc.r8 0.0
		IL_0332: clt.un
		IL_0334: stloc.0
		IL_0335: ldloc.0
		IL_0336: brtrue.s IL_0374

		IL_0338: nop
		IL_0339: ldarg.0
		IL_033a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_033f: ldstr "+"
		IL_0344: ldarg.1
		IL_0345: ldc.r8 10
		IL_034e: mul
		IL_034f: ldc.r8 1000
		IL_0358: div
		IL_0359: stloc.2
		IL_035a: ldloca.s 2
		IL_035c: ldstr "000.000"
		IL_0361: call instance string [mscorlib]System.Double::ToString(string)
		IL_0366: call string [mscorlib]System.String::Concat(string, string)
		IL_036b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0370: nop
		IL_0371: nop
		IL_0372: br.s IL_03a4

		IL_0374: nop
		IL_0375: ldarg.0
		IL_0376: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_037b: ldarg.1
		IL_037c: ldc.r8 10
		IL_0385: mul
		IL_0386: ldc.r8 1000
		IL_038f: div
		IL_0390: stloc.2
		IL_0391: ldloca.s 2
		IL_0393: ldstr "000.000"
		IL_0398: call instance string [mscorlib]System.Double::ToString(string)
		IL_039d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_03a2: nop
		IL_03a3: nop

		IL_03a4: nop

		IL_03a5: br IL_0c38

		IL_03aa: ldarg.1
		IL_03ab: ldc.r8 795.77
		IL_03b4: mul
		IL_03b5: call float64 [mscorlib]System.Math::Abs(float64)
		IL_03ba: ldc.r8 10000
		IL_03c3: clt
		IL_03c5: ldc.i4.0
		IL_03c6: ceq
		IL_03c8: stloc.0
		IL_03c9: ldloc.0
		IL_03ca: brtrue.s IL_0445

		IL_03cc: nop
		IL_03cd: ldarg.1
		IL_03ce: ldc.r8 795.77
		IL_03d7: mul
		IL_03d8: ldc.r8 0.0
		IL_03e1: clt.un
		IL_03e3: stloc.0
		IL_03e4: ldloc.0
		IL_03e5: brtrue.s IL_0419

		IL_03e7: nop
		IL_03e8: ldarg.0
		IL_03e9: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_03ee: ldstr "+"
		IL_03f3: ldarg.1
		IL_03f4: ldc.r8 795.77
		IL_03fd: mul
		IL_03fe: stloc.2
		IL_03ff: ldloca.s 2
		IL_0401: ldstr "0000.00"
		IL_0406: call instance string [mscorlib]System.Double::ToString(string)
		IL_040b: call string [mscorlib]System.String::Concat(string, string)
		IL_0410: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0415: nop
		IL_0416: nop
		IL_0417: br.s IL_043f

		IL_0419: nop
		IL_041a: ldarg.0
		IL_041b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0420: ldarg.1
		IL_0421: ldc.r8 795.77
		IL_042a: mul
		IL_042b: stloc.2
		IL_042c: ldloca.s 2
		IL_042e: ldstr "0000.00"
		IL_0433: call instance string [mscorlib]System.Double::ToString(string)
		IL_0438: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_043d: nop
		IL_043e: nop

		IL_043f: nop
		IL_0440: br IL_0664

		IL_0445: nop
		IL_0446: ldarg.0
		IL_0447: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_044c: ldstr "磁场值(KA/m)"
		IL_0451: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0456: nop
		IL_0457: ldarg.1
		IL_0458: ldc.r8 795.77
		IL_0461: mul
		IL_0462: ldc.r8 1000
		IL_046b: div
		IL_046c: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0471: ldc.r8 100
		IL_047a: cgt.un
		IL_047c: stloc.0
		IL_047d: ldloc.0
		IL_047e: brtrue IL_0516

		IL_0483: nop
		IL_0484: ldarg.1
		IL_0485: ldc.r8 795.77
		IL_048e: mul
		IL_048f: ldc.r8 1000
		IL_0498: div
		IL_0499: ldc.r8 0.0
		IL_04a2: clt.un
		IL_04a4: stloc.0
		IL_04a5: ldloc.0
		IL_04a6: brtrue.s IL_04e2

		IL_04a8: ldarg.0
		IL_04a9: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_04ae: ldstr "+"
		IL_04b3: ldarg.1
		IL_04b4: ldc.r8 795.77
		IL_04bd: mul
		IL_04be: ldc.r8 1000
		IL_04c7: div
		IL_04c8: stloc.2
		IL_04c9: ldloca.s 2
		IL_04cb: ldstr "00.0000"
		IL_04d0: call instance string [mscorlib]System.Double::ToString(string)
		IL_04d5: call string [mscorlib]System.String::Concat(string, string)
		IL_04da: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_04df: nop
		IL_04e0: br.s IL_0510

		IL_04e2: ldarg.0
		IL_04e3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_04e8: ldarg.1
		IL_04e9: ldc.r8 795.77
		IL_04f2: mul
		IL_04f3: ldc.r8 1000
		IL_04fc: div
		IL_04fd: stloc.2
		IL_04fe: ldloca.s 2
		IL_0500: ldstr "00.0000"
		IL_0505: call instance string [mscorlib]System.Double::ToString(string)
		IL_050a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_050f: nop

		IL_0510: nop
		IL_0511: br IL_0663

		IL_0516: ldarg.1
		IL_0517: ldc.r8 795.77
		IL_0520: mul
		IL_0521: ldc.r8 1000
		IL_052a: div
		IL_052b: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0530: ldc.r8 1000
		IL_0539: cgt.un
		IL_053b: stloc.0
		IL_053c: ldloc.0
		IL_053d: brtrue IL_05d5

		IL_0542: nop
		IL_0543: ldarg.1
		IL_0544: ldc.r8 795.77
		IL_054d: mul
		IL_054e: ldc.r8 1000
		IL_0557: div
		IL_0558: ldc.r8 0.0
		IL_0561: clt.un
		IL_0563: stloc.0
		IL_0564: ldloc.0
		IL_0565: brtrue.s IL_05a1

		IL_0567: ldarg.0
		IL_0568: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_056d: ldstr "+"
		IL_0572: ldarg.1
		IL_0573: ldc.r8 795.77
		IL_057c: mul
		IL_057d: ldc.r8 1000
		IL_0586: div
		IL_0587: stloc.2
		IL_0588: ldloca.s 2
		IL_058a: ldstr "000.000"
		IL_058f: call instance string [mscorlib]System.Double::ToString(string)
		IL_0594: call string [mscorlib]System.String::Concat(string, string)
		IL_0599: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_059e: nop
		IL_059f: br.s IL_05cf

		IL_05a1: ldarg.0
		IL_05a2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_05a7: ldarg.1
		IL_05a8: ldc.r8 795.77
		IL_05b1: mul
		IL_05b2: ldc.r8 1000
		IL_05bb: div
		IL_05bc: stloc.2
		IL_05bd: ldloca.s 2
		IL_05bf: ldstr "000.000"
		IL_05c4: call instance string [mscorlib]System.Double::ToString(string)
		IL_05c9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_05ce: nop

		IL_05cf: nop
		IL_05d0: br IL_0663

		IL_05d5: nop
		IL_05d6: ldarg.1
		IL_05d7: ldc.r8 795.77
		IL_05e0: mul
		IL_05e1: ldc.r8 1000
		IL_05ea: div
		IL_05eb: ldc.r8 0.0
		IL_05f4: clt.un
		IL_05f6: stloc.0
		IL_05f7: ldloc.0
		IL_05f8: brtrue.s IL_0634

		IL_05fa: ldarg.0
		IL_05fb: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0600: ldstr "+"
		IL_0605: ldarg.1
		IL_0606: ldc.r8 795.77
		IL_060f: mul
		IL_0610: ldc.r8 1000
		IL_0619: div
		IL_061a: stloc.2
		IL_061b: ldloca.s 2
		IL_061d: ldstr "0000.00"
		IL_0622: call instance string [mscorlib]System.Double::ToString(string)
		IL_0627: call string [mscorlib]System.String::Concat(string, string)
		IL_062c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0631: nop
		IL_0632: br.s IL_0662

		IL_0634: ldarg.0
		IL_0635: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_063a: ldarg.1
		IL_063b: ldc.r8 795.77
		IL_0644: mul
		IL_0645: ldc.r8 1000
		IL_064e: div
		IL_064f: stloc.2
		IL_0650: ldloca.s 2
		IL_0652: ldstr "0000.00"
		IL_0657: call instance string [mscorlib]System.Double::ToString(string)
		IL_065c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0661: nop

		IL_0662: nop

		IL_0663: nop

		IL_0664: br IL_0c38

		IL_0669: ldarg.1
		IL_066a: ldc.r8 10
		IL_0673: mul
		IL_0674: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0679: ldc.r8 300
		IL_0682: cgt.un
		IL_0684: stloc.0
		IL_0685: ldloc.0
		IL_0686: brtrue IL_070b

		IL_068b: nop
		IL_068c: ldarg.0
		IL_068d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_0692: ldstr "磁场值(Oe)"
		IL_0697: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_069c: nop
		IL_069d: ldarg.1
		IL_069e: ldc.r8 0.0
		IL_06a7: clt.un
		IL_06a9: stloc.0
		IL_06aa: ldloc.0
		IL_06ab: brtrue.s IL_06df

		IL_06ad: nop
		IL_06ae: ldarg.0
		IL_06af: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_06b4: ldstr "+"
		IL_06b9: ldarg.1
		IL_06ba: ldc.r8 10
		IL_06c3: mul
		IL_06c4: stloc.2
		IL_06c5: ldloca.s 2
		IL_06c7: ldstr "000.000"
		IL_06cc: call instance string [mscorlib]System.Double::ToString(string)
		IL_06d1: call string [mscorlib]System.String::Concat(string, string)
		IL_06d6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_06db: nop
		IL_06dc: nop
		IL_06dd: br.s IL_0705

		IL_06df: nop
		IL_06e0: ldarg.0
		IL_06e1: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_06e6: ldarg.1
		IL_06e7: ldc.r8 10
		IL_06f0: mul
		IL_06f1: stloc.2
		IL_06f2: ldloca.s 2
		IL_06f4: ldstr "000.000"
		IL_06f9: call instance string [mscorlib]System.Double::ToString(string)
		IL_06fe: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0703: nop
		IL_0704: nop

		IL_0705: nop
		IL_0706: br IL_08de

		IL_070b: ldarg.1
		IL_070c: ldc.r8 10
		IL_0715: mul
		IL_0716: call float64 [mscorlib]System.Math::Abs(float64)
		IL_071b: ldc.r8 3000
		IL_0724: cgt.un
		IL_0726: stloc.0
		IL_0727: ldloc.0
		IL_0728: brtrue IL_07ad

		IL_072d: nop
		IL_072e: ldarg.0
		IL_072f: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_0734: ldstr "磁场值(Oe)"
		IL_0739: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_073e: nop
		IL_073f: ldarg.1
		IL_0740: ldc.r8 0.0
		IL_0749: clt.un
		IL_074b: stloc.0
		IL_074c: ldloc.0
		IL_074d: brtrue.s IL_0781

		IL_074f: nop
		IL_0750: ldarg.0
		IL_0751: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0756: ldstr "+"
		IL_075b: ldarg.1
		IL_075c: ldc.r8 10
		IL_0765: mul
		IL_0766: stloc.2
		IL_0767: ldloca.s 2
		IL_0769: ldstr "0000.00"
		IL_076e: call instance string [mscorlib]System.Double::ToString(string)
		IL_0773: call string [mscorlib]System.String::Concat(string, string)
		IL_0778: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_077d: nop
		IL_077e: nop
		IL_077f: br.s IL_07a7

		IL_0781: nop
		IL_0782: ldarg.0
		IL_0783: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0788: ldarg.1
		IL_0789: ldc.r8 10
		IL_0792: mul
		IL_0793: stloc.2
		IL_0794: ldloca.s 2
		IL_0796: ldstr "0000.00"
		IL_079b: call instance string [mscorlib]System.Double::ToString(string)
		IL_07a0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_07a5: nop
		IL_07a6: nop

		IL_07a7: nop
		IL_07a8: br IL_08de

		IL_07ad: ldarg.1
		IL_07ae: ldc.r8 10
		IL_07b7: mul
		IL_07b8: call float64 [mscorlib]System.Math::Abs(float64)
		IL_07bd: ldc.r8 29000
		IL_07c6: cgt.un
		IL_07c8: stloc.0
		IL_07c9: ldloc.0
		IL_07ca: brtrue IL_084f

		IL_07cf: nop
		IL_07d0: ldarg.0
		IL_07d1: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_07d6: ldstr "磁场值(Oe)"
		IL_07db: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_07e0: nop
		IL_07e1: ldarg.1
		IL_07e2: ldc.r8 0.0
		IL_07eb: clt.un
		IL_07ed: stloc.0
		IL_07ee: ldloc.0
		IL_07ef: brtrue.s IL_0823

		IL_07f1: nop
		IL_07f2: ldarg.0
		IL_07f3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_07f8: ldstr "+"
		IL_07fd: ldarg.1
		IL_07fe: ldc.r8 10
		IL_0807: mul
		IL_0808: stloc.2
		IL_0809: ldloca.s 2
		IL_080b: ldstr "00000.0"
		IL_0810: call instance string [mscorlib]System.Double::ToString(string)
		IL_0815: call string [mscorlib]System.String::Concat(string, string)
		IL_081a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_081f: nop
		IL_0820: nop
		IL_0821: br.s IL_0849

		IL_0823: nop
		IL_0824: ldarg.0
		IL_0825: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_082a: ldarg.1
		IL_082b: ldc.r8 10
		IL_0834: mul
		IL_0835: stloc.2
		IL_0836: ldloca.s 2
		IL_0838: ldstr "00000.0"
		IL_083d: call instance string [mscorlib]System.Double::ToString(string)
		IL_0842: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0847: nop
		IL_0848: nop

		IL_0849: nop
		IL_084a: br IL_08de

		IL_084f: nop
		IL_0850: ldarg.0
		IL_0851: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_0856: ldstr "磁场值(KOe)"
		IL_085b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0860: nop
		IL_0861: ldarg.1
		IL_0862: ldc.r8 0.0
		IL_086b: clt.un
		IL_086d: stloc.0
		IL_086e: ldloc.0
		IL_086f: brtrue.s IL_08ad

		IL_0871: nop
		IL_0872: ldarg.0
		IL_0873: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0878: ldstr "+"
		IL_087d: ldarg.1
		IL_087e: ldc.r8 10
		IL_0887: mul
		IL_0888: ldc.r8 1000
		IL_0891: div
		IL_0892: stloc.2
		IL_0893: ldloca.s 2
		IL_0895: ldstr "000.000"
		IL_089a: call instance string [mscorlib]System.Double::ToString(string)
		IL_089f: call string [mscorlib]System.String::Concat(string, string)
		IL_08a4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_08a9: nop
		IL_08aa: nop
		IL_08ab: br.s IL_08dd

		IL_08ad: nop
		IL_08ae: ldarg.0
		IL_08af: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_08b4: ldarg.1
		IL_08b5: ldc.r8 10
		IL_08be: mul
		IL_08bf: ldc.r8 1000
		IL_08c8: div
		IL_08c9: stloc.2
		IL_08ca: ldloca.s 2
		IL_08cc: ldstr "000.000"
		IL_08d1: call instance string [mscorlib]System.Double::ToString(string)
		IL_08d6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_08db: nop
		IL_08dc: nop

		IL_08dd: nop

		IL_08de: br IL_0c38

		IL_08e3: ldarg.0
		IL_08e4: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_08e9: ldarg.2
		IL_08ea: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_08ef: nop
		IL_08f0: br IL_0c38

		IL_08f5: ldarg.1
		IL_08f6: ldc.r8 100
		IL_08ff: mul
		IL_0900: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0905: ldc.r8 300
		IL_090e: cgt.un
		IL_0910: stloc.0
		IL_0911: ldloc.0
		IL_0912: brtrue.s IL_0983

		IL_0914: nop
		IL_0915: ldarg.1
		IL_0916: ldc.r8 0.0
		IL_091f: clt.un
		IL_0921: stloc.0
		IL_0922: ldloc.0
		IL_0923: brtrue.s IL_0957

		IL_0925: nop
		IL_0926: ldarg.0
		IL_0927: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_092c: ldstr "+"
		IL_0931: ldarg.1
		IL_0932: ldc.r8 100
		IL_093b: mul
		IL_093c: stloc.2
		IL_093d: ldloca.s 2
		IL_093f: ldstr "000.000"
		IL_0944: call instance string [mscorlib]System.Double::ToString(string)
		IL_0949: call string [mscorlib]System.String::Concat(string, string)
		IL_094e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0953: nop
		IL_0954: nop
		IL_0955: br.s IL_097d

		IL_0957: nop
		IL_0958: ldarg.0
		IL_0959: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_095e: ldarg.1
		IL_095f: ldc.r8 100
		IL_0968: mul
		IL_0969: stloc.2
		IL_096a: ldloca.s 2
		IL_096c: ldstr "000.000"
		IL_0971: call instance string [mscorlib]System.Double::ToString(string)
		IL_0976: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_097b: nop
		IL_097c: nop

		IL_097d: nop
		IL_097e: br IL_0a78

		IL_0983: ldarg.1
		IL_0984: ldc.r8 100
		IL_098d: mul
		IL_098e: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0993: ldc.r8 3000
		IL_099c: cgt.un
		IL_099e: stloc.0
		IL_099f: ldloc.0
		IL_09a0: brtrue.s IL_0a0e

		IL_09a2: nop
		IL_09a3: ldarg.1
		IL_09a4: ldc.r8 0.0
		IL_09ad: clt.un
		IL_09af: stloc.0
		IL_09b0: ldloc.0
		IL_09b1: brtrue.s IL_09e5

		IL_09b3: nop
		IL_09b4: ldarg.0
		IL_09b5: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_09ba: ldstr "+"
		IL_09bf: ldarg.1
		IL_09c0: ldc.r8 100
		IL_09c9: mul
		IL_09ca: stloc.2
		IL_09cb: ldloca.s 2
		IL_09cd: ldstr "0000.00"
		IL_09d2: call instance string [mscorlib]System.Double::ToString(string)
		IL_09d7: call string [mscorlib]System.String::Concat(string, string)
		IL_09dc: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_09e1: nop
		IL_09e2: nop
		IL_09e3: br.s IL_0a0b

		IL_09e5: nop
		IL_09e6: ldarg.0
		IL_09e7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_09ec: ldarg.1
		IL_09ed: ldc.r8 100
		IL_09f6: mul
		IL_09f7: stloc.2
		IL_09f8: ldloca.s 2
		IL_09fa: ldstr "0000.00"
		IL_09ff: call instance string [mscorlib]System.Double::ToString(string)
		IL_0a04: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0a09: nop
		IL_0a0a: nop

		IL_0a0b: nop
		IL_0a0c: br.s IL_0a78

		IL_0a0e: nop
		IL_0a0f: ldarg.1
		IL_0a10: ldc.r8 0.0
		IL_0a19: clt.un
		IL_0a1b: stloc.0
		IL_0a1c: ldloc.0
		IL_0a1d: brtrue.s IL_0a51

		IL_0a1f: nop
		IL_0a20: ldarg.0
		IL_0a21: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0a26: ldstr "+"
		IL_0a2b: ldarg.1
		IL_0a2c: ldc.r8 100
		IL_0a35: mul
		IL_0a36: stloc.2
		IL_0a37: ldloca.s 2
		IL_0a39: ldstr "00000.0"
		IL_0a3e: call instance string [mscorlib]System.Double::ToString(string)
		IL_0a43: call string [mscorlib]System.String::Concat(string, string)
		IL_0a48: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0a4d: nop
		IL_0a4e: nop
		IL_0a4f: br.s IL_0a77

		IL_0a51: nop
		IL_0a52: ldarg.0
		IL_0a53: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0a58: ldarg.1
		IL_0a59: ldc.r8 100
		IL_0a62: mul
		IL_0a63: stloc.2
		IL_0a64: ldloca.s 2
		IL_0a66: ldstr "00000.0"
		IL_0a6b: call instance string [mscorlib]System.Double::ToString(string)
		IL_0a70: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0a75: nop
		IL_0a76: nop

		IL_0a77: nop

		IL_0a78: br IL_0c38

		IL_0a7d: nop
		IL_0a7e: ldarg.0
		IL_0a7f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0a84: ldarg.2
		IL_0a85: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0a8a: nop
		IL_0a8b: br IL_0c38

		IL_0a90: nop
		IL_0a91: ldarg.1
		IL_0a92: ldc.r8 10
		IL_0a9b: mul
		IL_0a9c: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0aa1: ldc.r8 300
		IL_0aaa: cgt.un
		IL_0aac: stloc.0
		IL_0aad: ldloc.0
		IL_0aae: brtrue.s IL_0b1f

		IL_0ab0: nop
		IL_0ab1: ldarg.1
		IL_0ab2: ldc.r8 0.0
		IL_0abb: clt.un
		IL_0abd: stloc.0
		IL_0abe: ldloc.0
		IL_0abf: brtrue.s IL_0af3

		IL_0ac1: nop
		IL_0ac2: ldarg.0
		IL_0ac3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0ac8: ldstr "+"
		IL_0acd: ldarg.1
		IL_0ace: ldc.r8 10
		IL_0ad7: mul
		IL_0ad8: stloc.2
		IL_0ad9: ldloca.s 2
		IL_0adb: ldstr "000.000"
		IL_0ae0: call instance string [mscorlib]System.Double::ToString(string)
		IL_0ae5: call string [mscorlib]System.String::Concat(string, string)
		IL_0aea: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0aef: nop
		IL_0af0: nop
		IL_0af1: br.s IL_0b19

		IL_0af3: nop
		IL_0af4: ldarg.0
		IL_0af5: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0afa: ldarg.1
		IL_0afb: ldc.r8 10
		IL_0b04: mul
		IL_0b05: stloc.2
		IL_0b06: ldloca.s 2
		IL_0b08: ldstr "000.000"
		IL_0b0d: call instance string [mscorlib]System.Double::ToString(string)
		IL_0b12: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0b17: nop
		IL_0b18: nop

		IL_0b19: nop
		IL_0b1a: br IL_0c36

		IL_0b1f: ldarg.1
		IL_0b20: ldc.r8 10
		IL_0b29: mul
		IL_0b2a: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0b2f: ldc.r8 3000
		IL_0b38: cgt.un
		IL_0b3a: stloc.0
		IL_0b3b: ldloc.0
		IL_0b3c: brtrue.s IL_0bad

		IL_0b3e: nop
		IL_0b3f: ldarg.1
		IL_0b40: ldc.r8 0.0
		IL_0b49: clt.un
		IL_0b4b: stloc.0
		IL_0b4c: ldloc.0
		IL_0b4d: brtrue.s IL_0b81

		IL_0b4f: nop
		IL_0b50: ldarg.0
		IL_0b51: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0b56: ldstr "+"
		IL_0b5b: ldarg.1
		IL_0b5c: ldc.r8 10
		IL_0b65: mul
		IL_0b66: stloc.2
		IL_0b67: ldloca.s 2
		IL_0b69: ldstr "0000.00"
		IL_0b6e: call instance string [mscorlib]System.Double::ToString(string)
		IL_0b73: call string [mscorlib]System.String::Concat(string, string)
		IL_0b78: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0b7d: nop
		IL_0b7e: nop
		IL_0b7f: br.s IL_0ba7

		IL_0b81: nop
		IL_0b82: ldarg.0
		IL_0b83: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0b88: ldarg.1
		IL_0b89: ldc.r8 10
		IL_0b92: mul
		IL_0b93: stloc.2
		IL_0b94: ldloca.s 2
		IL_0b96: ldstr "0000.00"
		IL_0b9b: call instance string [mscorlib]System.Double::ToString(string)
		IL_0ba0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0ba5: nop
		IL_0ba6: nop

		IL_0ba7: nop
		IL_0ba8: br IL_0c36

		IL_0bad: ldarg.1
		IL_0bae: ldc.r8 10
		IL_0bb7: mul
		IL_0bb8: call float64 [mscorlib]System.Math::Abs(float64)
		IL_0bbd: ldc.r8 29000
		IL_0bc6: cgt.un
		IL_0bc8: stloc.0
		IL_0bc9: ldloc.0
		IL_0bca: brtrue.s IL_0c36

		IL_0bcc: nop
		IL_0bcd: ldarg.1
		IL_0bce: ldc.r8 0.0
		IL_0bd7: clt.un
		IL_0bd9: stloc.0
		IL_0bda: ldloc.0
		IL_0bdb: brtrue.s IL_0c0f

		IL_0bdd: nop
		IL_0bde: ldarg.0
		IL_0bdf: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0be4: ldstr "+"
		IL_0be9: ldarg.1
		IL_0bea: ldc.r8 10
		IL_0bf3: mul
		IL_0bf4: stloc.2
		IL_0bf5: ldloca.s 2
		IL_0bf7: ldstr "00000.0"
		IL_0bfc: call instance string [mscorlib]System.Double::ToString(string)
		IL_0c01: call string [mscorlib]System.String::Concat(string, string)
		IL_0c06: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0c0b: nop
		IL_0c0c: nop
		IL_0c0d: br.s IL_0c35

		IL_0c0f: nop
		IL_0c10: ldarg.0
		IL_0c11: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_0c16: ldarg.1
		IL_0c17: ldc.r8 10
		IL_0c20: mul
		IL_0c21: stloc.2
		IL_0c22: ldloca.s 2
		IL_0c24: ldstr "00000.0"
		IL_0c29: call instance string [mscorlib]System.Double::ToString(string)
		IL_0c2e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0c33: nop
		IL_0c34: nop

		IL_0c35: nop

		IL_0c36: br.s IL_0c38

		IL_0c38: ret
	} // end of method Form1::UnitChange

	.method private hidebysig 
		instance string BdataDisplayConvert (
			string Bdata
		) cil managed 
	{
		// Method begins at RVA 0x3f34
		// Header size: 12
		// Code size: 279 (0x117)
		.maxstack 3
		.locals init (
			[0] float64 BB,
			[1] string CS$1$0000,
			[2] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldc.r8 0.0
		IL_000a: stloc.0
		.try
		{
			IL_000b: nop
			IL_000c: ldarg.1
			IL_000d: call float64 [mscorlib]System.Convert::ToDouble(string)
			IL_0012: stloc.0
			IL_0013: ldloc.0
			IL_0014: ldc.r8 0.0
			IL_001d: clt.un
			IL_001f: stloc.2
			IL_0020: ldloc.2
			IL_0021: brtrue IL_00af

			IL_0026: nop
			IL_0027: ldarg.0
			IL_0028: ldfld string datapick.Form1::MODEL
			IL_002d: ldstr "CH-1500"
			IL_0032: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_0037: ldc.i4.0
			IL_0038: ceq
			IL_003a: stloc.2
			IL_003b: ldloc.2
			IL_003c: brtrue.s IL_005d

			IL_003e: nop
			IL_003f: ldc.i4.s 43
			IL_0041: box [mscorlib]System.Char
			IL_0046: ldloca.s 0
			IL_0048: ldstr "0.00"
			IL_004d: call instance string [mscorlib]System.Double::ToString(string)
			IL_0052: call string [mscorlib]System.String::Concat(object, object)
			IL_0057: stloc.1
			IL_0058: leave IL_0114

			IL_005d: ldarg.0
			IL_005e: ldfld string datapick.Form1::MODEL
			IL_0063: ldstr "CH-1300"
			IL_0068: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_006d: ldc.i4.0
			IL_006e: ceq
			IL_0070: stloc.2
			IL_0071: ldloc.2
			IL_0072: brtrue.s IL_0093

			IL_0074: nop
			IL_0075: ldc.i4.s 43
			IL_0077: box [mscorlib]System.Char
			IL_007c: ldloca.s 0
			IL_007e: ldstr "0.0"
			IL_0083: call instance string [mscorlib]System.Double::ToString(string)
			IL_0088: call string [mscorlib]System.String::Concat(object, object)
			IL_008d: stloc.1
			IL_008e: leave IL_0114

			IL_0093: nop
			IL_0094: ldc.i4.s 43
			IL_0096: box [mscorlib]System.Char
			IL_009b: ldloca.s 0
			IL_009d: ldstr "0.0000"
			IL_00a2: call instance string [mscorlib]System.Double::ToString(string)
			IL_00a7: call string [mscorlib]System.String::Concat(object, object)
			IL_00ac: stloc.1
			IL_00ad: leave.s IL_0114

			IL_00af: nop
			IL_00b0: ldarg.0
			IL_00b1: ldfld string datapick.Form1::MODEL
			IL_00b6: ldstr "CH-1500"
			IL_00bb: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_00c0: ldc.i4.0
			IL_00c1: ceq
			IL_00c3: stloc.2
			IL_00c4: ldloc.2
			IL_00c5: brtrue.s IL_00d7

			IL_00c7: nop
			IL_00c8: ldloca.s 0
			IL_00ca: ldstr "0.00"
			IL_00cf: call instance string [mscorlib]System.Double::ToString(string)
			IL_00d4: stloc.1
			IL_00d5: leave.s IL_0114

			IL_00d7: ldarg.0
			IL_00d8: ldfld string datapick.Form1::MODEL
			IL_00dd: ldstr "CH-1300"
			IL_00e2: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_00e7: ldc.i4.0
			IL_00e8: ceq
			IL_00ea: stloc.2
			IL_00eb: ldloc.2
			IL_00ec: brtrue.s IL_00fe

			IL_00ee: nop
			IL_00ef: ldloca.s 0
			IL_00f1: ldstr "0.0"
			IL_00f6: call instance string [mscorlib]System.Double::ToString(string)
			IL_00fb: stloc.1
			IL_00fc: leave.s IL_0114

			IL_00fe: nop
			IL_00ff: ldloca.s 0
			IL_0101: ldstr "0.0000"
			IL_0106: call instance string [mscorlib]System.Double::ToString(string)
			IL_010b: stloc.1
			IL_010c: leave.s IL_0114
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_010e: pop
			IL_010f: nop
			IL_0110: ldnull
			IL_0111: stloc.1
			IL_0112: leave.s IL_0114
		} // end handler

		IL_0114: nop
		IL_0115: ldloc.1
		IL_0116: ret
	} // end of method Form1::BdataDisplayConvert

	.method private hidebysig 
		instance void timerTIME_Tick_1 (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x4074
		// Header size: 12
		// Code size: 1485 (0x5cd)
		.maxstack 6
		.locals init (
			[0] float64 x,
			[1] float64 y,
			[2] int32 j,
			[3] bool CS$4$0000,
			[4] object[] CS$0$0001,
			[5] char[] CS$0$0002
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld int32 datapick.Form1::DataType_flag
		IL_0007: ldc.i4.1
		IL_0008: ceq
		IL_000a: ldc.i4.0
		IL_000b: ceq
		IL_000d: stloc.3
		IL_000e: ldloc.3
		IL_000f: brtrue IL_02de

		IL_0014: nop
		IL_0015: ldarg.0
		IL_0016: ldfld bool datapick.Form1::boolDisplayData
		IL_001b: ldc.i4.0
		IL_001c: ceq
		IL_001e: stloc.3
		IL_001f: ldloc.3
		IL_0020: brtrue IL_02d8

		IL_0025: nop
		IL_0026: ldarg.0
		IL_0027: ldfld bool datapick.Form1::Ready
		IL_002c: ldc.i4.0
		IL_002d: ceq
		IL_002f: stloc.3
		IL_0030: ldloc.3
		IL_0031: brtrue IL_01d1

		IL_0036: nop
		IL_0037: ldarg.0
		IL_0038: ldc.i4.0
		IL_0039: stfld bool datapick.Form1::boolDisplayData
		IL_003e: ldarg.0
		IL_003f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_0044: ldarg.0
		IL_0045: ldflda float64 datapick.Form1::pinlv
		IL_004a: call instance string [mscorlib]System.Double::ToString()
		IL_004f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0054: nop
		IL_0055: ldarg.0
		IL_0056: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_005b: ldarg.0
		IL_005c: ldflda float64 datapick.Form1::tempwendu
		IL_0061: call instance string [mscorlib]System.Double::ToString()
		IL_0066: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_006b: nop
		IL_006c: ldarg.0
		IL_006d: ldarg.0
		IL_006e: ldfld float64 datapick.Form1::Bdate
		IL_0073: ldarg.0
		IL_0074: ldfld string datapick.Form1::Bdatedisplay
		IL_0079: call instance void datapick.Form1::UnitChange(float64, string)
		IL_007e: nop
		IL_007f: ldarg.0
		IL_0080: ldfld int32 datapick.Form1::tishiflag
		IL_0085: ldc.i4.0
		IL_0086: ceq
		IL_0088: ldc.i4.0
		IL_0089: ceq
		IL_008b: stloc.3
		IL_008c: ldloc.3
		IL_008d: brtrue IL_01d0

		IL_0092: nop
		IL_0093: ldarg.0
		IL_0094: ldc.i4.2
		IL_0095: stfld int32 datapick.Form1::tishiflag
		IL_009a: ldarg.0
		IL_009b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_00a0: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_00a5: ldc.i4.0
		IL_00a6: ceq
		IL_00a8: ldc.i4.0
		IL_00a9: ceq
		IL_00ab: stloc.3
		IL_00ac: ldloc.3
		IL_00ad: brtrue IL_0137

		IL_00b2: nop
		IL_00b3: ldarg.0
		IL_00b4: ldfld string datapick.Form1::MODEL
		IL_00b9: ldstr "CH-260磁通手动"
		IL_00be: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_00c3: brfalse.s IL_00fe

		IL_00c5: ldarg.0
		IL_00c6: ldfld string datapick.Form1::MODEL
		IL_00cb: ldstr "CH-290磁通手动"
		IL_00d0: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_00d5: brfalse.s IL_00fe

		IL_00d7: ldarg.0
		IL_00d8: ldfld string datapick.Form1::MODEL
		IL_00dd: ldstr "CH-260磁强手动"
		IL_00e2: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_00e7: brfalse.s IL_00fe

		IL_00e9: ldarg.0
		IL_00ea: ldfld string datapick.Form1::MODEL
		IL_00ef: ldstr "CH-290磁强手动"
		IL_00f4: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_00f9: ldc.i4.0
		IL_00fa: ceq
		IL_00fc: br.s IL_00ff

		IL_00fe: ldc.i4.1

		IL_00ff: nop
		IL_0100: stloc.3
		IL_0101: ldloc.3
		IL_0102: brtrue.s IL_0131

		IL_0104: ldstr "成功通过 串口 连接"
		IL_0109: ldarg.0
		IL_010a: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_010f: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0114: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0119: ldstr "!"
		IL_011e: call string [mscorlib]System.String::Concat(string, string, string)
		IL_0123: ldstr "提示"
		IL_0128: ldc.i4.0
		IL_0129: ldc.i4.s 64
		IL_012b: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
		IL_0130: pop

		IL_0131: nop
		IL_0132: br IL_01cf

		IL_0137: ldarg.0
		IL_0138: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_013d: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0142: ldc.i4.1
		IL_0143: ceq
		IL_0145: ldc.i4.0
		IL_0146: ceq
		IL_0148: stloc.3
		IL_0149: ldloc.3
		IL_014a: brtrue IL_01cf

		IL_014f: nop
		IL_0150: ldarg.0
		IL_0151: ldfld string datapick.Form1::MODEL
		IL_0156: ldstr "CH-260磁通手动"
		IL_015b: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_0160: brfalse.s IL_019b

		IL_0162: ldarg.0
		IL_0163: ldfld string datapick.Form1::MODEL
		IL_0168: ldstr "CH-290磁通手动"
		IL_016d: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_0172: brfalse.s IL_019b

		IL_0174: ldarg.0
		IL_0175: ldfld string datapick.Form1::MODEL
		IL_017a: ldstr "CH-260磁强手动"
		IL_017f: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_0184: brfalse.s IL_019b

		IL_0186: ldarg.0
		IL_0187: ldfld string datapick.Form1::MODEL
		IL_018c: ldstr "CH-290磁强手动"
		IL_0191: call bool [mscorlib]System.String::op_Inequality(string, string)
		IL_0196: ldc.i4.0
		IL_0197: ceq
		IL_0199: br.s IL_019c

		IL_019b: ldc.i4.1

		IL_019c: nop
		IL_019d: stloc.3
		IL_019e: ldloc.3
		IL_019f: brtrue.s IL_01ce

		IL_01a1: ldstr "成功通过 USB 连接"
		IL_01a6: ldarg.0
		IL_01a7: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_01ac: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_01b1: callvirt instance string [mscorlib]System.Object::ToString()
		IL_01b6: ldstr "!"
		IL_01bb: call string [mscorlib]System.String::Concat(string, string, string)
		IL_01c0: ldstr "提示"
		IL_01c5: ldc.i4.0
		IL_01c6: ldc.i4.s 64
		IL_01c8: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
		IL_01cd: pop

		IL_01ce: nop

		IL_01cf: nop

		IL_01d0: nop

		IL_01d1: ldarg.0
		IL_01d2: ldfld bool datapick.Form1::listadd
		IL_01d7: ldc.i4.0
		IL_01d8: ceq
		IL_01da: stloc.3
		IL_01db: ldloc.3
		IL_01dc: brtrue IL_02d7

		IL_01e1: nop
		IL_01e2: ldarg.0
		IL_01e3: ldc.i4.0
		IL_01e4: stfld bool datapick.Form1::listadd
		IL_01e9: ldarg.0
		IL_01ea: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_01ef: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_01f4: ldc.i4.5
		IL_01f5: newarr [mscorlib]System.Object
		IL_01fa: stloc.s 4
		IL_01fc: ldloc.s 4
		IL_01fe: ldc.i4.0
		IL_01ff: ldarg.0
		IL_0200: ldfld uint64 datapick.Form1::nono
		IL_0205: box [mscorlib]System.UInt64
		IL_020a: stelem.ref
		IL_020b: ldloc.s 4
		IL_020d: ldc.i4.1
		IL_020e: ldarg.0
		IL_020f: ldfld float64 datapick.Form1::Bdate
		IL_0214: box [mscorlib]System.Double
		IL_0219: stelem.ref
		IL_021a: ldloc.s 4
		IL_021c: ldc.i4.2
		IL_021d: ldarg.0
		IL_021e: ldfld float64 datapick.Form1::pinlv
		IL_0223: box [mscorlib]System.Double
		IL_0228: stelem.ref
		IL_0229: ldloc.s 4
		IL_022b: ldc.i4.3
		IL_022c: ldarg.0
		IL_022d: ldfld float64 datapick.Form1::tempwendu
		IL_0232: box [mscorlib]System.Double
		IL_0237: stelem.ref
		IL_0238: ldloc.s 4
		IL_023a: ldc.i4.4
		IL_023b: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
		IL_0240: box [mscorlib]System.DateTime
		IL_0245: stelem.ref
		IL_0246: ldloc.s 4
		IL_0248: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::Add(object[])
		IL_024d: pop
		IL_024e: ldarg.0
		IL_024f: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0254: ldarg.0
		IL_0255: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_025a: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridView::get_RowCount()
		IL_025f: ldc.i4.1
		IL_0260: sub
		IL_0261: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_FirstDisplayedScrollingRowIndex(int32)
		IL_0266: nop
		IL_0267: ldarg.0
		IL_0268: dup
		IL_0269: ldfld uint64 datapick.Form1::nono
		IL_026e: ldc.i4.1
		IL_026f: conv.i8
		IL_0270: add
		IL_0271: stfld uint64 datapick.Form1::nono
		IL_0276: ldarg.0
		IL_0277: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_027c: callvirt instance int32 class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::get_Count()
		IL_0281: ldc.i4.s 100
		IL_0283: clt
		IL_0285: stloc.3
		IL_0286: ldloc.3
		IL_0287: brtrue.s IL_0298

		IL_0289: nop
		IL_028a: ldarg.0
		IL_028b: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_0290: ldc.i4.0
		IL_0291: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::RemoveAt(int32)
		IL_0296: nop
		IL_0297: nop

		IL_0298: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
		IL_029d: newobj instance void [ZedGraph]ZedGraph.XDate::.ctor(valuetype [mscorlib]System.DateTime)
		IL_02a2: call float64 [ZedGraph]ZedGraph.XDate::op_Implicit(valuetype [ZedGraph]ZedGraph.XDate)
		IL_02a7: conv.r8
		IL_02a8: stloc.0
		IL_02a9: ldarg.0
		IL_02aa: ldfld float64 datapick.Form1::Bdate
		IL_02af: stloc.1
		IL_02b0: ldarg.0
		IL_02b1: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_02b6: ldloc.0
		IL_02b7: ldloc.1
		IL_02b8: callvirt instance void [ZedGraph]ZedGraph.PointPairList::Add(float64, float64)
		IL_02bd: nop
		IL_02be: ldarg.0
		IL_02bf: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_02c4: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_02c9: nop
		IL_02ca: ldarg.0
		IL_02cb: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_02d0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_02d5: nop
		IL_02d6: nop

		IL_02d7: nop

		IL_02d8: nop
		IL_02d9: br IL_05cb

		IL_02de: ldarg.0
		IL_02df: ldfld int32 datapick.Form1::DataType_flag
		IL_02e4: ldc.i4.2
		IL_02e5: ceq
		IL_02e7: ldc.i4.0
		IL_02e8: ceq
		IL_02ea: stloc.3
		IL_02eb: ldloc.3
		IL_02ec: brtrue IL_0505

		IL_02f1: nop
		IL_02f2: ldarg.0
		IL_02f3: ldfld bool datapick.Form1::readsuccess
		IL_02f8: ldc.i4.0
		IL_02f9: ceq
		IL_02fb: stloc.3
		IL_02fc: ldloc.3
		IL_02fd: brtrue IL_04ff

		IL_0302: nop
		IL_0303: ldarg.0
		IL_0304: ldc.i4.0
		IL_0305: stfld bool datapick.Form1::readsuccess
		IL_030a: ldarg.0
		IL_030b: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_0310: callvirt instance int32 class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::get_Count()
		IL_0315: ldarg.0
		IL_0316: ldfld int32 datapick.Form1::HighSpeedNO
		IL_031b: ldc.i4.s 10
		IL_031d: mul
		IL_031e: clt
		IL_0320: stloc.3
		IL_0321: ldloc.3
		IL_0322: brtrue.s IL_0339

		IL_0324: nop
		IL_0325: ldarg.0
		IL_0326: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_032b: ldc.i4.0
		IL_032c: ldarg.0
		IL_032d: ldfld int32 datapick.Form1::HighSpeedNO
		IL_0332: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::RemoveRange(int32, int32)
		IL_0337: nop
		IL_0338: nop

		IL_0339: ldarg.0
		IL_033a: ldarg.0
		IL_033b: ldfld string datapick.Form1::TdataReceived
		IL_0340: ldc.i4.1
		IL_0341: newarr [mscorlib]System.Char
		IL_0346: stloc.s 5
		IL_0348: ldloc.s 5
		IL_034a: ldc.i4.0
		IL_034b: ldc.i4.s 10
		IL_034d: stelem.i2
		IL_034e: ldloc.s 5
		IL_0350: callvirt instance string[] [mscorlib]System.String::Split(char[])
		IL_0355: stfld string[] datapick.Form1::Bdate_highspeed
		IL_035a: ldc.r8 0.0
		IL_0363: stloc.1
		IL_0364: ldc.i4.0
		IL_0365: stloc.2
		IL_0366: br IL_0494
		// loop start (head: IL_0494)
			IL_036b: nop
			IL_036c: ldarg.0
			IL_036d: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_0372: ldloc.2
			IL_0373: ldelem.ref
			IL_0374: callvirt instance int32 [mscorlib]System.String::get_Length()
			IL_0379: ldarg.0
			IL_037a: ldfld int32 datapick.Form1::HighSpeedBase
			IL_037f: ldc.i4.1
			IL_0380: sub
			IL_0381: ceq
			IL_0383: ldc.i4.0
			IL_0384: ceq
			IL_0386: stloc.3
			IL_0387: ldloc.3
			IL_0388: brtrue IL_0489

			IL_038d: nop
			IL_038e: ldarg.0
			IL_038f: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_0394: ldloc.2
			IL_0395: ldarg.0
			IL_0396: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_039b: ldloc.2
			IL_039c: ldelem.ref
			IL_039d: ldc.i4.1
			IL_039e: newarr [mscorlib]System.Char
			IL_03a3: stloc.s 5
			IL_03a5: ldloc.s 5
			IL_03a7: ldc.i4.0
			IL_03a8: ldc.i4.s 35
			IL_03aa: stelem.i2
			IL_03ab: ldloc.s 5
			IL_03ad: callvirt instance string [mscorlib]System.String::TrimStart(char[])
			IL_03b2: ldc.i4.1
			IL_03b3: newarr [mscorlib]System.Char
			IL_03b8: stloc.s 5
			IL_03ba: ldloc.s 5
			IL_03bc: ldc.i4.0
			IL_03bd: ldc.i4.s 62
			IL_03bf: stelem.i2
			IL_03c0: ldloc.s 5
			IL_03c2: callvirt instance string [mscorlib]System.String::TrimEnd(char[])
			IL_03c7: stelem.ref
			IL_03c8: ldarg.0
			IL_03c9: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_03ce: ldloc.2
			IL_03cf: ldarg.0
			IL_03d0: ldarg.0
			IL_03d1: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_03d6: ldloc.2
			IL_03d7: ldelem.ref
			IL_03d8: call instance string datapick.Form1::BdataDisplayConvert(string)
			IL_03dd: stelem.ref
			IL_03de: ldarg.0
			IL_03df: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_03e4: ldloc.2
			IL_03e5: ldelem.ref
			IL_03e6: ldnull
			IL_03e7: ceq
			IL_03e9: stloc.3
			IL_03ea: ldloc.3
			IL_03eb: brtrue IL_0486

			IL_03f0: nop
			IL_03f1: ldarg.0
			IL_03f2: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
			IL_03f7: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
			IL_03fc: ldc.i4.5
			IL_03fd: newarr [mscorlib]System.Object
			IL_0402: stloc.s 4
			IL_0404: ldloc.s 4
			IL_0406: ldc.i4.0
			IL_0407: ldarg.0
			IL_0408: ldfld uint64 datapick.Form1::nono
			IL_040d: box [mscorlib]System.UInt64
			IL_0412: stelem.ref
			IL_0413: ldloc.s 4
			IL_0415: ldc.i4.1
			IL_0416: ldarg.0
			IL_0417: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_041c: ldloc.2
			IL_041d: ldelem.ref
			IL_041e: stelem.ref
			IL_041f: ldloc.s 4
			IL_0421: ldc.i4.2
			IL_0422: ldc.i4.0
			IL_0423: box [mscorlib]System.Int32
			IL_0428: stelem.ref
			IL_0429: ldloc.s 4
			IL_042b: ldc.i4.3
			IL_042c: ldc.i4.0
			IL_042d: box [mscorlib]System.Int32
			IL_0432: stelem.ref
			IL_0433: ldloc.s 4
			IL_0435: ldc.i4.4
			IL_0436: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
			IL_043b: box [mscorlib]System.DateTime
			IL_0440: stelem.ref
			IL_0441: ldloc.s 4
			IL_0443: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::Add(object[])
			IL_0448: pop
			IL_0449: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
			IL_044e: newobj instance void [ZedGraph]ZedGraph.XDate::.ctor(valuetype [mscorlib]System.DateTime)
			IL_0453: call float64 [ZedGraph]ZedGraph.XDate::op_Implicit(valuetype [ZedGraph]ZedGraph.XDate)
			IL_0458: conv.r8
			IL_0459: stloc.0
			IL_045a: ldarg.0
			IL_045b: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_0460: ldloc.2
			IL_0461: ldelem.ref
			IL_0462: call float64 [mscorlib]System.Convert::ToDouble(string)
			IL_0467: stloc.1
			IL_0468: ldarg.0
			IL_0469: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
			IL_046e: ldloc.0
			IL_046f: ldloc.1
			IL_0470: callvirt instance void [ZedGraph]ZedGraph.PointPairList::Add(float64, float64)
			IL_0475: nop
			IL_0476: ldarg.0
			IL_0477: dup
			IL_0478: ldfld uint64 datapick.Form1::nono
			IL_047d: ldc.i4.1
			IL_047e: conv.i8
			IL_047f: add
			IL_0480: stfld uint64 datapick.Form1::nono
			IL_0485: nop

			IL_0486: nop
			IL_0487: br.s IL_048f

			IL_0489: nop
			IL_048a: br IL_05cb

			IL_048f: nop
			IL_0490: ldloc.2
			IL_0491: ldc.i4.1
			IL_0492: add
			IL_0493: stloc.2

			IL_0494: ldloc.2
			IL_0495: ldarg.0
			IL_0496: ldfld string[] datapick.Form1::Bdate_highspeed
			IL_049b: ldlen
			IL_049c: conv.i4
			IL_049d: ldc.i4.1
			IL_049e: sub
			IL_049f: clt
			IL_04a1: stloc.3
			IL_04a2: ldloc.3
			IL_04a3: brtrue IL_036b
		// end loop
		.try
		{
			IL_04a8: nop
			IL_04a9: ldarg.0
			IL_04aa: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
			IL_04af: ldarg.0
			IL_04b0: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
			IL_04b5: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridView::get_RowCount()
			IL_04ba: ldc.i4.1
			IL_04bb: sub
			IL_04bc: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_FirstDisplayedScrollingRowIndex(int32)
			IL_04c1: nop
			IL_04c2: nop
			IL_04c3: leave.s IL_04cc
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_04c5: pop
			IL_04c6: nop
			IL_04c7: leave IL_05cb
		} // end handler

		IL_04cc: nop
		IL_04cd: ldarg.0
		IL_04ce: ldloc.1
		IL_04cf: ldarg.0
		IL_04d0: ldfld string[] datapick.Form1::Bdate_highspeed
		IL_04d5: ldarg.0
		IL_04d6: ldfld string[] datapick.Form1::Bdate_highspeed
		IL_04db: ldlen
		IL_04dc: conv.i4
		IL_04dd: ldc.i4.2
		IL_04de: sub
		IL_04df: ldelem.ref
		IL_04e0: call instance void datapick.Form1::UnitChange(float64, string)
		IL_04e5: nop
		IL_04e6: ldarg.0
		IL_04e7: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_04ec: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_04f1: nop
		IL_04f2: ldarg.0
		IL_04f3: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_04f8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_04fd: nop
		IL_04fe: nop

		IL_04ff: nop
		IL_0500: br IL_05cb

		IL_0505: ldarg.0
		IL_0506: ldfld int32 datapick.Form1::DataType_flag
		IL_050b: ldc.i4.3
		IL_050c: ceq
		IL_050e: ldc.i4.0
		IL_050f: ceq
		IL_0511: stloc.3
		IL_0512: ldloc.3
		IL_0513: brtrue IL_05cb

		IL_0518: nop
		IL_0519: ldarg.0
		IL_051a: ldfld bool datapick.Form1::Ready_lots
		IL_051f: ldc.i4.0
		IL_0520: ceq
		IL_0522: stloc.3
		IL_0523: ldloc.3
		IL_0524: brtrue IL_05ca

		IL_0529: nop
		IL_052a: ldc.i4.0
		IL_052b: stloc.2
		IL_052c: br.s IL_058c
		// loop start (head: IL_058c)
			IL_052e: nop
			IL_052f: ldarg.0
			IL_0530: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
			IL_0535: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
			IL_053a: ldc.i4.5
			IL_053b: newarr [mscorlib]System.Object
			IL_0540: stloc.s 4
			IL_0542: ldloc.s 4
			IL_0544: ldc.i4.0
			IL_0545: ldarg.0
			IL_0546: ldfld int32[] datapick.Form1::nono_lots
			IL_054b: ldloc.2
			IL_054c: ldelem.i4
			IL_054d: box [mscorlib]System.Int32
			IL_0552: stelem.ref
			IL_0553: ldloc.s 4
			IL_0555: ldc.i4.1
			IL_0556: ldarg.0
			IL_0557: ldfld string[] datapick.Form1::Bdate_lots
			IL_055c: ldloc.2
			IL_055d: ldelem.ref
			IL_055e: stelem.ref
			IL_055f: ldloc.s 4
			IL_0561: ldc.i4.2
			IL_0562: ldc.i4.0
			IL_0563: box [mscorlib]System.Int32
			IL_0568: stelem.ref
			IL_0569: ldloc.s 4
			IL_056b: ldc.i4.3
			IL_056c: ldc.i4.0
			IL_056d: box [mscorlib]System.Int32
			IL_0572: stelem.ref
			IL_0573: ldloc.s 4
			IL_0575: ldc.i4.4
			IL_0576: ldarg.0
			IL_0577: ldfld string[] datapick.Form1::DateTime_lots
			IL_057c: ldloc.2
			IL_057d: ldelem.ref
			IL_057e: stelem.ref
			IL_057f: ldloc.s 4
			IL_0581: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::Add(object[])
			IL_0586: pop
			IL_0587: nop
			IL_0588: ldloc.2
			IL_0589: ldc.i4.1
			IL_058a: add
			IL_058b: stloc.2

			IL_058c: ldloc.2
			IL_058d: ldc.i4 500
			IL_0592: clt
			IL_0594: stloc.3
			IL_0595: ldloc.3
			IL_0596: brtrue.s IL_052e
		// end loop

		IL_0598: ldarg.0
		IL_0599: ldc.i4.0
		IL_059a: stfld bool datapick.Form1::Ready_lots
		IL_059f: ldsfld class datapick.tishi datapick.tishi::tis
		IL_05a4: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_05a9: ldstr "读取完成！"
		IL_05ae: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_05b3: nop
		IL_05b4: ldsfld class datapick.tishi datapick.tishi::tis
		IL_05b9: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_05be: ldstr "确定"
		IL_05c3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_05c8: nop
		IL_05c9: nop

		IL_05ca: nop

		IL_05cb: nop
		IL_05cc: ret
	} // end of method Form1::timerTIME_Tick_1

	.method private hidebysig 
		instance void buttonSTART_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x4660
		// Header size: 12
		// Code size: 1188 (0x4a4)
		.maxstack 5
		.locals init (
			[0] class [mscorlib]System.Exception ee,
			[1] bool result,
			[2] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldc.i4.4
		IL_0003: stfld int32 datapick.Form1::FlagEnquire
		IL_0008: ldarg.0
		IL_0009: ldfld int32 datapick.Form1::FlagEnquire
		IL_000e: ldc.i4.4
		IL_000f: ceq
		IL_0011: ldc.i4.0
		IL_0012: ceq
		IL_0014: stloc.2
		IL_0015: ldloc.2
		IL_0016: brtrue IL_040e

		IL_001b: nop
		IL_001c: ldarg.0
		IL_001d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0022: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0027: ldc.i4.0
		IL_0028: ceq
		IL_002a: ldc.i4.0
		IL_002b: ceq
		IL_002d: stloc.2
		IL_002e: ldloc.2
		IL_002f: brtrue IL_02d0

		IL_0034: nop
		IL_0035: ldarg.0
		IL_0036: ldfld int32 datapick.Form1::DataType_flag
		IL_003b: ldc.i4.1
		IL_003c: ceq
		IL_003e: ldc.i4.0
		IL_003f: ceq
		IL_0041: stloc.2
		IL_0042: ldloc.2
		IL_0043: brtrue.s IL_00bf

		IL_0045: nop
		IL_0046: ldarg.0
		IL_0047: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_004c: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0051: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0056: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_005b: ldc.r8 100
		IL_0064: callvirt instance void [ZedGraph]ZedGraph.Scale::set_Max(float64)
		IL_0069: nop
		IL_006a: ldarg.0
		IL_006b: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0070: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0075: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_007a: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_007f: ldc.r8 20
		IL_0088: callvirt instance void [ZedGraph]ZedGraph.Scale::set_MajorStep(float64)
		IL_008d: nop
		IL_008e: ldarg.0
		IL_008f: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0094: ldarg.0
		IL_0095: ldfld int32 datapick.Form1::ReadLength
		IL_009a: callvirt instance void [System]System.IO.Ports.SerialPort::set_ReceivedBytesThreshold(int32)
		IL_009f: nop
		IL_00a0: ldarg.0
		IL_00a1: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_00a6: ldc.i4.1
		IL_00a7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
		IL_00ac: nop
		IL_00ad: ldarg.0
		IL_00ae: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_00b3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::Start()
		IL_00b8: nop
		IL_00b9: nop
		IL_00ba: br IL_01e5

		IL_00bf: ldarg.0
		IL_00c0: ldfld int32 datapick.Form1::DataType_flag
		IL_00c5: ldc.i4.2
		IL_00c6: ceq
		IL_00c8: ldc.i4.0
		IL_00c9: ceq
		IL_00cb: stloc.2
		IL_00cc: ldloc.2
		IL_00cd: brtrue IL_01e5

		IL_00d2: nop
		IL_00d3: ldarg.0
		IL_00d4: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_00d9: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::Clear()
		IL_00de: nop
		IL_00df: ldarg.0
		IL_00e0: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_00e5: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_00ea: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_00ef: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_00f4: ldc.i4.s 10
		IL_00f6: ldarg.0
		IL_00f7: ldfld int32 datapick.Form1::HighSpeedNO
		IL_00fc: mul
		IL_00fd: conv.r8
		IL_00fe: callvirt instance void [ZedGraph]ZedGraph.Scale::set_Max(float64)
		IL_0103: nop
		IL_0104: ldarg.0
		IL_0105: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_010a: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_010f: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0114: callvirt instance class [ZedGraph]ZedGraph.Scale [ZedGraph]ZedGraph.Axis::get_Scale()
		IL_0119: ldc.i4.2
		IL_011a: ldarg.0
		IL_011b: ldfld int32 datapick.Form1::HighSpeedNO
		IL_0120: mul
		IL_0121: conv.r8
		IL_0122: callvirt instance void [ZedGraph]ZedGraph.Scale::set_MajorStep(float64)
		IL_0127: nop
		IL_0128: ldarg.0
		IL_0129: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_012e: ldarg.0
		IL_012f: ldfld int32 datapick.Form1::HighSpeedBase
		IL_0134: ldarg.0
		IL_0135: ldfld int32 datapick.Form1::HighSpeedNO
		IL_013a: mul
		IL_013b: callvirt instance void [System]System.IO.Ports.SerialPort::set_ReceivedBytesThreshold(int32)
		IL_0140: nop
		.try
		{
			IL_0141: nop
			IL_0142: ldarg.0
			IL_0143: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
			IL_0148: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
			IL_014d: callvirt instance string [mscorlib]System.Object::ToString()
			IL_0152: ldstr "CH-1500"
			IL_0157: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_015c: brtrue.s IL_017d

			IL_015e: ldarg.0
			IL_015f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
			IL_0164: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
			IL_0169: callvirt instance string [mscorlib]System.Object::ToString()
			IL_016e: ldstr "CH-1500B"
			IL_0173: call bool [mscorlib]System.String::op_Equality(string, string)
			IL_0178: ldc.i4.0
			IL_0179: ceq
			IL_017b: br.s IL_017e

			IL_017d: ldc.i4.0

			IL_017e: nop
			IL_017f: stloc.2
			IL_0180: ldloc.2
			IL_0181: brtrue.s IL_01a8

			IL_0183: nop
			IL_0184: ldarg.0
			IL_0185: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_018a: ldstr "DATA?>"
			IL_018f: ldarg.0
			IL_0190: ldfld string datapick.Form1::Speed
			IL_0195: ldstr "NORM>"
			IL_019a: call string [mscorlib]System.String::Concat(string, string, string)
			IL_019f: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_01a4: nop
			IL_01a5: nop
			IL_01a6: br.s IL_01c7

			IL_01a8: nop
			IL_01a9: ldarg.0
			IL_01aa: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_01af: ldarg.0
			IL_01b0: ldfld string datapick.Form1::Speed
			IL_01b5: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_01ba: nop
			IL_01bb: ldc.i4 300
			IL_01c0: call void [mscorlib]System.Threading.Thread::Sleep(int32)
			IL_01c5: nop
			IL_01c6: nop

			IL_01c7: nop
			IL_01c8: leave.s IL_01e3
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_01ca: stloc.0
			IL_01cb: nop
			IL_01cc: ldloc.0
			IL_01cd: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_01d2: ldstr "警告"
			IL_01d7: ldc.i4.0
			IL_01d8: ldc.i4.s 48
			IL_01da: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_01df: pop
			IL_01e0: nop
			IL_01e1: leave.s IL_01e3
		} // end handler

		IL_01e3: nop
		IL_01e4: nop
		.try
		{
			IL_01e5: nop
			IL_01e6: ldarg.0
			IL_01e7: ldc.i4.1
			IL_01e8: stfld int32 datapick.Form1::communicate_fangshi
			IL_01ed: ldarg.0
			IL_01ee: ldfld string datapick.Form1::MODEL
			IL_01f3: ldstr "CH-260磁通手动"
			IL_01f8: call bool [mscorlib]System.String::op_Inequality(string, string)
			IL_01fd: brfalse.s IL_0240

			IL_01ff: ldarg.0
			IL_0200: ldfld string datapick.Form1::MODEL
			IL_0205: ldstr "CH-290磁通手动"
			IL_020a: call bool [mscorlib]System.String::op_Inequality(string, string)
			IL_020f: brfalse.s IL_0240

			IL_0211: ldarg.0
			IL_0212: ldfld string datapick.Form1::MODEL
			IL_0217: ldstr "CH-260磁强手动"
			IL_021c: call bool [mscorlib]System.String::op_Inequality(string, string)
			IL_0221: brfalse.s IL_0240

			IL_0223: ldarg.0
			IL_0224: ldfld string datapick.Form1::MODEL
			IL_0229: ldstr "CH-290磁强手动"
			IL_022e: call bool [mscorlib]System.String::op_Inequality(string, string)
			IL_0233: brfalse.s IL_0240

			IL_0235: ldarg.0
			IL_0236: ldfld int32 datapick.Form1::DataType_flag
			IL_023b: ldc.i4.2
			IL_023c: ceq
			IL_023e: br.s IL_0241

			IL_0240: ldc.i4.1

			IL_0241: nop
			IL_0242: stloc.2
			IL_0243: ldloc.2
			IL_0244: brtrue.s IL_0257

			IL_0246: ldarg.0
			IL_0247: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_024c: ldstr "DATA?>"
			IL_0251: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_0256: nop

			IL_0257: ldarg.0
			IL_0258: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_025d: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Lime()
			IL_0262: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_0267: nop
			IL_0268: ldarg.0
			IL_0269: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_026e: ldarg.0
			IL_026f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_0274: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_0279: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_027e: nop
			IL_027f: nop
			IL_0280: leave.s IL_02c9
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_0282: stloc.0
			IL_0283: nop
			IL_0284: ldarg.0
			IL_0285: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_028a: ldarg.0
			IL_028b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_0290: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_0295: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_029a: nop
			IL_029b: ldarg.0
			IL_029c: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_02a1: ldarg.0
			IL_02a2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_02a7: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_02ac: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_02b1: nop
			IL_02b2: ldloc.0
			IL_02b3: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_02b8: ldstr "警告"
			IL_02bd: ldc.i4.0
			IL_02be: ldc.i4.s 48
			IL_02c0: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_02c5: pop
			IL_02c6: nop
			IL_02c7: leave.s IL_02c9
		} // end handler

		IL_02c9: nop
		IL_02ca: nop
		IL_02cb: br IL_03fb

		IL_02d0: ldarg.0
		IL_02d1: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_02d6: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_02db: ldc.i4.1
		IL_02dc: ceq
		IL_02de: ldc.i4.0
		IL_02df: ceq
		IL_02e1: stloc.2
		IL_02e2: ldloc.2
		IL_02e3: brtrue IL_03fb

		IL_02e8: nop
		IL_02e9: ldarg.0
		IL_02ea: ldfld int32 datapick.Form1::HidHandle
		IL_02ef: ldc.i4.m1
		IL_02f0: ceq
		IL_02f2: stloc.2
		IL_02f3: ldloc.2
		IL_02f4: brtrue IL_03e4

		IL_02f9: nop
		IL_02fa: ldarg.0
		IL_02fb: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_0300: ldc.i4.1
		IL_0301: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
		IL_0306: nop
		IL_0307: ldarg.0
		IL_0308: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_030d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::Start()
		IL_0312: nop
		.try
		{
			IL_0313: nop
			IL_0314: ldarg.0
			IL_0315: ldc.i4.2
			IL_0316: stfld int32 datapick.Form1::communicate_fangshi
			IL_031b: ldarg.0
			IL_031c: ldfld uint8[] datapick.Form1::senddata
			IL_0321: ldc.i4.1
			IL_0322: ldc.i4.s 17
			IL_0324: stelem.i1
			IL_0325: ldarg.0
			IL_0326: ldfld int32 datapick.Form1::HidHandle
			IL_032b: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_0330: ldarg.0
			IL_0331: ldfld uint8[] datapick.Form1::senddata
			IL_0336: ldc.i4.s 17
			IL_0338: ldarg.0
			IL_0339: ldflda int32 datapick.Form1::USBwrite
			IL_033e: ldarg.0
			IL_033f: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
			IL_0344: call bool datapick.Form1::WriteFile(native int, uint8[], int32, int32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_0349: stloc.1
			IL_034a: ldarg.0
			IL_034b: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerRecieve
			IL_0350: ldc.i4.1
			IL_0351: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_0356: nop
			IL_0357: ldc.i4.s 10
			IL_0359: call void [mscorlib]System.Threading.Thread::Sleep(int32)
			IL_035e: nop
			IL_035f: ldarg.0
			IL_0360: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerUSBread
			IL_0365: ldc.i4.1
			IL_0366: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_036b: nop
			IL_036c: ldarg.0
			IL_036d: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_0372: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Lime()
			IL_0377: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_037c: nop
			IL_037d: ldarg.0
			IL_037e: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_0383: ldarg.0
			IL_0384: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_0389: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_038e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_0393: nop
			IL_0394: nop
			IL_0395: leave.s IL_03e0
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_0397: stloc.0
			IL_0398: nop
			IL_0399: ldarg.0
			IL_039a: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_039f: ldarg.0
			IL_03a0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_03a5: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_03aa: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_03af: nop
			IL_03b0: ldarg.0
			IL_03b1: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_03b6: ldarg.0
			IL_03b7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_03bc: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_03c1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_03c6: nop
			IL_03c7: ldloc.0
			IL_03c8: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_03cd: ldstr "警告"
			IL_03d2: ldc.i4.0
			IL_03d3: ldc.i4.s 48
			IL_03d5: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_03da: pop
			IL_03db: leave IL_04a2
		} // end handler

		IL_03e0: nop
		IL_03e1: nop
		IL_03e2: br.s IL_03fa

		IL_03e4: nop
		IL_03e5: ldstr "未连接USB设备"
		IL_03ea: ldstr "提示"
		IL_03ef: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string)
		IL_03f4: pop
		IL_03f5: br IL_04a2

		IL_03fa: nop

		IL_03fb: ldarg.0
		IL_03fc: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_0401: ldc.i4.0
		IL_0402: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0407: nop
		IL_0408: nop
		IL_0409: br IL_04a2

		IL_040e: ldarg.0
		IL_040f: ldfld int32 datapick.Form1::FlagEnquire
		IL_0414: ldc.i4.0
		IL_0415: ceq
		IL_0417: ldc.i4.0
		IL_0418: ceq
		IL_041a: stloc.2
		IL_041b: ldloc.2
		IL_041c: brtrue IL_04a2

		IL_0421: nop
		.try
		{
			IL_0422: nop
			IL_0423: ldarg.0
			IL_0424: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerType
			IL_0429: ldc.i4.1
			IL_042a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_042f: nop
			IL_0430: ldarg.0
			IL_0431: ldc.i4.1
			IL_0432: stfld int32 datapick.Form1::FlagEnquire
			IL_0437: ldarg.0
			IL_0438: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_043d: ldstr "DATAC>"
			IL_0442: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_0447: nop
			IL_0448: ldc.i4.s 100
			IL_044a: call void [mscorlib]System.Threading.Thread::Sleep(int32)
			IL_044f: nop
			IL_0450: ldarg.0
			IL_0451: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0456: callvirt instance void [System]System.IO.Ports.SerialPort::DiscardInBuffer()
			IL_045b: nop
			IL_045c: ldarg.0
			IL_045d: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0462: ldc.i4.5
			IL_0463: callvirt instance void [System]System.IO.Ports.SerialPort::set_ReceivedBytesThreshold(int32)
			IL_0468: nop
			IL_0469: ldarg.0
			IL_046a: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_046f: ldstr "TYPE>"
			IL_0474: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_0479: nop
			IL_047a: ldc.i4 500
			IL_047f: call void [mscorlib]System.Threading.Thread::Sleep(int32)
			IL_0484: nop
			IL_0485: nop
			IL_0486: leave.s IL_04a0
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_0488: stloc.0
			IL_0489: nop
			IL_048a: ldloc.0
			IL_048b: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_0490: ldstr "警告"
			IL_0495: ldc.i4.0
			IL_0496: ldc.i4.s 48
			IL_0498: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_049d: pop
			IL_049e: leave.s IL_04a2
		} // end handler

		IL_04a0: nop
		IL_04a1: nop

		IL_04a2: nop
		IL_04a3: ret
	} // end of method Form1::buttonSTART_Click

	.method private hidebysig 
		instance void buttonSTOP_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x4b44
		// Header size: 12
		// Code size: 493 (0x1ed)
		.maxstack 5
		.locals init (
			[0] class [mscorlib]System.Exception ee,
			[1] bool result,
			[2] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0007: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_000c: ldc.i4.0
		IL_000d: ceq
		IL_000f: ldc.i4.0
		IL_0010: ceq
		IL_0012: stloc.2
		IL_0013: ldloc.2
		IL_0014: brtrue IL_00dd

		IL_0019: nop
		.try
		{
			IL_001a: nop
			IL_001b: ldarg.0
			IL_001c: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
			IL_0021: ldc.i4.0
			IL_0022: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_0027: nop
			IL_0028: ldarg.0
			IL_0029: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_002e: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
			IL_0033: ldc.i4.0
			IL_0034: ceq
			IL_0036: stloc.2
			IL_0037: ldloc.2
			IL_0038: brtrue.s IL_0064

			IL_003a: nop
			IL_003b: ldarg.0
			IL_003c: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0041: ldstr "DATAC>"
			IL_0046: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_004b: nop
			IL_004c: ldc.i4 500
			IL_0051: call void [mscorlib]System.Threading.Thread::Sleep(int32)
			IL_0056: nop
			IL_0057: ldarg.0
			IL_0058: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_005d: callvirt instance void [System]System.IO.Ports.SerialPort::DiscardInBuffer()
			IL_0062: nop
			IL_0063: nop

			IL_0064: ldarg.0
			IL_0065: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_006a: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Red()
			IL_006f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_0074: nop
			IL_0075: ldarg.0
			IL_0076: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_007b: ldarg.0
			IL_007c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_0081: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_0086: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_008b: nop
			IL_008c: nop
			IL_008d: leave.s IL_00d6
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_008f: stloc.0
			IL_0090: nop
			IL_0091: ldarg.0
			IL_0092: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_0097: ldarg.0
			IL_0098: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_009d: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_00a2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_00a7: nop
			IL_00a8: ldarg.0
			IL_00a9: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_00ae: ldarg.0
			IL_00af: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_00b4: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_00b9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_00be: nop
			IL_00bf: ldloc.0
			IL_00c0: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_00c5: ldstr "警告"
			IL_00ca: ldc.i4.0
			IL_00cb: ldc.i4.s 48
			IL_00cd: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_00d2: pop
			IL_00d3: nop
			IL_00d4: leave.s IL_00d6
		} // end handler

		IL_00d6: nop
		IL_00d7: nop
		IL_00d8: br IL_01de

		IL_00dd: ldarg.0
		IL_00de: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_00e3: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_00e8: ldc.i4.1
		IL_00e9: ceq
		IL_00eb: ldc.i4.0
		IL_00ec: ceq
		IL_00ee: stloc.2
		IL_00ef: ldloc.2
		IL_00f0: brtrue IL_01de

		IL_00f5: nop
		IL_00f6: ldarg.0
		IL_00f7: ldfld int32 datapick.Form1::HidHandle
		IL_00fc: ldc.i4.m1
		IL_00fd: ceq
		IL_00ff: stloc.2
		IL_0100: ldloc.2
		IL_0101: brtrue IL_01da

		IL_0106: nop
		.try
		{
			IL_0107: nop
			IL_0108: ldarg.0
			IL_0109: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
			IL_010e: ldc.i4.0
			IL_010f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_0114: nop
			IL_0115: ldarg.0
			IL_0116: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerRecieve
			IL_011b: ldc.i4.0
			IL_011c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_0121: nop
			IL_0122: ldarg.0
			IL_0123: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerUSBread
			IL_0128: ldc.i4.0
			IL_0129: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_012e: nop
			IL_012f: ldarg.0
			IL_0130: ldfld class [mscorlib]System.Threading.Thread datapick.Form1::readUSB
			IL_0135: callvirt instance void [mscorlib]System.Threading.Thread::Abort()
			IL_013a: nop
			IL_013b: ldarg.0
			IL_013c: ldfld uint8[] datapick.Form1::senddata
			IL_0141: ldc.i4.1
			IL_0142: ldc.i4.s 18
			IL_0144: stelem.i1
			IL_0145: ldarg.0
			IL_0146: ldfld int32 datapick.Form1::HidHandle
			IL_014b: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_0150: ldarg.0
			IL_0151: ldfld uint8[] datapick.Form1::senddata
			IL_0156: ldc.i4.s 17
			IL_0158: ldarg.0
			IL_0159: ldflda int32 datapick.Form1::USBwrite
			IL_015e: ldarg.0
			IL_015f: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
			IL_0164: call bool datapick.Form1::WriteFile(native int, uint8[], int32, int32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_0169: stloc.1
			IL_016a: ldarg.0
			IL_016b: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_0170: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Red()
			IL_0175: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_017a: nop
			IL_017b: ldarg.0
			IL_017c: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_0181: ldarg.0
			IL_0182: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_0187: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_018c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_0191: nop
			IL_0192: ldc.i4.s 100
			IL_0194: call void [mscorlib]System.Threading.Thread::Sleep(int32)
			IL_0199: nop
			IL_019a: ldarg.0
			IL_019b: ldc.i4.0
			IL_019c: stfld bool datapick.Form1::Ready
			IL_01a1: nop
			IL_01a2: leave.s IL_01d6
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_01a4: stloc.0
			IL_01a5: nop
			IL_01a6: ldarg.0
			IL_01a7: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
			IL_01ac: ldarg.0
			IL_01ad: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_01b2: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_01b7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_01bc: nop
			IL_01bd: ldarg.0
			IL_01be: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
			IL_01c3: ldarg.0
			IL_01c4: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
			IL_01c9: callvirt instance valuetype [System.Drawing]System.Drawing.Color [System.Windows.Forms]System.Windows.Forms.Control::get_BackColor()
			IL_01ce: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
			IL_01d3: nop
			IL_01d4: leave.s IL_01eb
		} // end handler

		IL_01d6: nop
		IL_01d7: nop
		IL_01d8: br.s IL_01dd

		IL_01da: nop
		IL_01db: br.s IL_01eb

		IL_01dd: nop

		IL_01de: ldarg.0
		IL_01df: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_01e4: ldc.i4.1
		IL_01e5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_01ea: nop

		IL_01eb: nop
		IL_01ec: ret
	} // end of method Form1::buttonSTOP_Click

	.method private hidebysig 
		instance void buttonZERO_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x4d5c
		// Header size: 12
		// Code size: 213 (0xd5)
		.maxstack 5
		.locals init (
			[0] class [mscorlib]System.Exception ee,
			[1] bool result,
			[2] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0007: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_000c: ldc.i4.0
		IL_000d: ceq
		IL_000f: ldc.i4.0
		IL_0010: ceq
		IL_0012: stloc.2
		IL_0013: ldloc.2
		IL_0014: brtrue.s IL_004c

		IL_0016: nop
		.try
		{
			IL_0017: nop
			IL_0018: ldarg.0
			IL_0019: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_001e: ldstr "ZERO>"
			IL_0023: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_0028: nop
			IL_0029: nop
			IL_002a: leave.s IL_0045
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_002c: stloc.0
			IL_002d: nop
			IL_002e: ldloc.0
			IL_002f: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_0034: ldstr "警告"
			IL_0039: ldc.i4.0
			IL_003a: ldc.i4.s 48
			IL_003c: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_0041: pop
			IL_0042: nop
			IL_0043: leave.s IL_0045
		} // end handler

		IL_0045: nop
		IL_0046: nop
		IL_0047: br IL_00d3

		IL_004c: ldarg.0
		IL_004d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0052: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0057: ldc.i4.1
		IL_0058: ceq
		IL_005a: ldc.i4.0
		IL_005b: ceq
		IL_005d: stloc.2
		IL_005e: ldloc.2
		IL_005f: brtrue.s IL_00d3

		IL_0061: nop
		IL_0062: ldarg.0
		IL_0063: ldfld int32 datapick.Form1::HidHandle
		IL_0068: ldc.i4.m1
		IL_0069: ceq
		IL_006b: stloc.2
		IL_006c: ldloc.2
		IL_006d: brtrue.s IL_00bf

		IL_006f: nop
		.try
		{
			IL_0070: nop
			IL_0071: ldarg.0
			IL_0072: ldfld uint8[] datapick.Form1::senddata
			IL_0077: ldc.i4.1
			IL_0078: ldc.i4.s 32
			IL_007a: stelem.i1
			IL_007b: ldarg.0
			IL_007c: ldfld int32 datapick.Form1::HidHandle
			IL_0081: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_0086: ldarg.0
			IL_0087: ldfld uint8[] datapick.Form1::senddata
			IL_008c: ldc.i4.s 17
			IL_008e: ldarg.0
			IL_008f: ldflda int32 datapick.Form1::USBwrite
			IL_0094: ldarg.0
			IL_0095: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
			IL_009a: call bool datapick.Form1::WriteFile(native int, uint8[], int32, int32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_009f: stloc.1
			IL_00a0: nop
			IL_00a1: leave.s IL_00bb
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_00a3: stloc.0
			IL_00a4: nop
			IL_00a5: ldloc.0
			IL_00a6: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_00ab: ldstr "警告"
			IL_00b0: ldc.i4.0
			IL_00b1: ldc.i4.s 48
			IL_00b3: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_00b8: pop
			IL_00b9: leave.s IL_00d3
		} // end handler

		IL_00bb: nop
		IL_00bc: nop
		IL_00bd: br.s IL_00d2

		IL_00bf: nop
		IL_00c0: ldstr "未连接USB设备"
		IL_00c5: ldstr "提示"
		IL_00ca: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string)
		IL_00cf: pop
		IL_00d0: br.s IL_00d3

		IL_00d2: nop

		IL_00d3: nop
		IL_00d4: ret
	} // end of method Form1::buttonZERO_Click

	.method private hidebysig 
		instance void buttonLISTCLEAR_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x4e5c
		// Header size: 1
		// Code size: 27 (0x1b)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0007: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_000c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::Clear()
		IL_0011: nop
		IL_0012: ldarg.0
		IL_0013: ldc.i4.1
		IL_0014: conv.i8
		IL_0015: stfld uint64 datapick.Form1::nono
		IL_001a: ret
	} // end of method Form1::buttonLISTCLEAR_Click

	.method public hidebysig 
		instance void quick_get_current_Data_out () cil managed 
	{
		// Method begins at RVA 0x4e78
		// Header size: 12
		// Code size: 668 (0x29c)
		.maxstack 3
		.locals init (
			[0] class [System.Windows.Forms]System.Windows.Forms.SaveFileDialog saveFileDialog,
			[1] class [mscorlib]System.IO.Stream myStream,
			[2] class [mscorlib]System.IO.StreamWriter sw,
			[3] string str,
			[4] valuetype [mscorlib]System.DateTime start,
			[5] int32 i,
			[6] int32 j,
			[7] string tempStr,
			[8] int32 k,
			[9] class [mscorlib]System.Exception ex,
			[10] bool CS$4$0000,
			[11] float64 CS$0$0001,
			[12] valuetype [mscorlib]System.DateTime CS$0$0002,
			[13] valuetype [mscorlib]System.TimeSpan CS$0$0003
		)

		IL_0000: nop
		IL_0001: newobj instance void [System.Windows.Forms]System.Windows.Forms.SaveFileDialog::.ctor()
		IL_0006: stloc.0
		IL_0007: ldloc.0
		IL_0008: ldstr "Execl文件(*.xls)|*.xls"
		IL_000d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.FileDialog::set_Filter(string)
		IL_0012: nop
		IL_0013: ldloc.0
		IL_0014: ldc.i4.0
		IL_0015: callvirt instance void [System.Windows.Forms]System.Windows.Forms.FileDialog::set_FilterIndex(int32)
		IL_001a: nop
		IL_001b: ldloc.0
		IL_001c: ldc.i4.1
		IL_001d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.FileDialog::set_RestoreDirectory(bool)
		IL_0022: nop
		IL_0023: ldloc.0
		IL_0024: ldc.i4.1
		IL_0025: callvirt instance void [System.Windows.Forms]System.Windows.Forms.SaveFileDialog::set_CreatePrompt(bool)
		IL_002a: nop
		IL_002b: ldloc.0
		IL_002c: ldstr "数据视图导出EXCEL文件"
		IL_0031: callvirt instance void [System.Windows.Forms]System.Windows.Forms.FileDialog::set_Title(string)
		IL_0036: nop
		IL_0037: ldloc.0
		IL_0038: callvirt instance valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.CommonDialog::ShowDialog()
		IL_003d: pop
		IL_003e: ldloc.0
		IL_003f: callvirt instance class [mscorlib]System.IO.Stream [System.Windows.Forms]System.Windows.Forms.SaveFileDialog::OpenFile()
		IL_0044: stloc.1
		IL_0045: ldloc.1
		IL_0046: ldstr "Unicode"
		IL_004b: call class [mscorlib]System.Text.Encoding [mscorlib]System.Text.Encoding::GetEncoding(string)
		IL_0050: newobj instance void [mscorlib]System.IO.StreamWriter::.ctor(class [mscorlib]System.IO.Stream, class [mscorlib]System.Text.Encoding)
		IL_0055: stloc.2
		IL_0056: ldstr ""
		IL_005b: stloc.3
		IL_005c: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
		IL_0061: stloc.s 4
		.try
		{
			.try
			{
				IL_0063: nop
				IL_0064: ldc.i4.0
				IL_0065: stloc.s 5
				IL_0067: br.s IL_00ab
				// loop start (head: IL_00ab)
					IL_0069: nop
					IL_006a: ldloc.s 5
					IL_006c: ldc.i4.0
					IL_006d: cgt
					IL_006f: ldc.i4.0
					IL_0070: ceq
					IL_0072: stloc.s 10
					IL_0074: ldloc.s 10
					IL_0076: brtrue.s IL_0086

					IL_0078: nop
					IL_0079: ldloc.3
					IL_007a: ldstr "\t"
					IL_007f: call string [mscorlib]System.String::Concat(string, string)
					IL_0084: stloc.3
					IL_0085: nop

					IL_0086: ldloc.3
					IL_0087: ldarg.0
					IL_0088: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
					IL_008d: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
					IL_0092: ldloc.s 5
					IL_0094: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
					IL_0099: callvirt instance string [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::get_HeaderText()
					IL_009e: call string [mscorlib]System.String::Concat(string, string)
					IL_00a3: stloc.3
					IL_00a4: nop
					IL_00a5: ldloc.s 5
					IL_00a7: ldc.i4.1
					IL_00a8: add
					IL_00a9: stloc.s 5

					IL_00ab: ldloc.s 5
					IL_00ad: ldarg.0
					IL_00ae: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
					IL_00b3: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridView::get_ColumnCount()
					IL_00b8: clt
					IL_00ba: stloc.s 10
					IL_00bc: ldloc.s 10
					IL_00be: brtrue.s IL_0069
				// end loop

				IL_00c0: ldloc.2
				IL_00c1: ldloc.3
				IL_00c2: callvirt instance void [mscorlib]System.IO.TextWriter::WriteLine(string)
				IL_00c7: nop
				IL_00c8: ldc.i4.0
				IL_00c9: stloc.s 6
				IL_00cb: br IL_020e
				// loop start (head: IL_020e)
					IL_00d0: nop
					IL_00d1: ldstr ""
					IL_00d6: stloc.s 7
					IL_00d8: ldc.i4.0
					IL_00d9: stloc.s 8
					IL_00db: br IL_01e1
					// loop start (head: IL_01e1)
						IL_00e0: nop
						IL_00e1: ldloc.s 8
						IL_00e3: ldc.i4.0
						IL_00e4: cgt
						IL_00e6: ldc.i4.0
						IL_00e7: ceq
						IL_00e9: stloc.s 10
						IL_00eb: ldloc.s 10
						IL_00ed: brtrue.s IL_00ff

						IL_00ef: nop
						IL_00f0: ldloc.s 7
						IL_00f2: ldstr "\t"
						IL_00f7: call string [mscorlib]System.String::Concat(string, string)
						IL_00fc: stloc.s 7
						IL_00fe: nop

						IL_00ff: ldarg.0
						IL_0100: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
						IL_0105: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
						IL_010a: ldloc.s 6
						IL_010c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
						IL_0111: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_Cells()
						IL_0116: ldloc.s 8
						IL_0118: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCell [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection::get_Item(int32)
						IL_011d: callvirt instance object [System.Windows.Forms]System.Windows.Forms.DataGridViewCell::get_Value()
						IL_0122: ldnull
						IL_0123: ceq
						IL_0125: ldc.i4.0
						IL_0126: ceq
						IL_0128: stloc.s 10
						IL_012a: ldloc.s 10
						IL_012c: brtrue.s IL_0143

						IL_012e: nop
						IL_012f: ldloc.s 7
						IL_0131: ldsfld string [mscorlib]System.String::Empty
						IL_0136: call string [mscorlib]System.String::Concat(string, string)
						IL_013b: stloc.s 7
						IL_013d: nop
						IL_013e: br IL_01da

						IL_0143: nop
						IL_0144: ldarg.0
						IL_0145: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
						IL_014a: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.CheckBox::get_Checked()
						IL_014f: brfalse.s IL_015b

						IL_0151: ldloc.s 8
						IL_0153: ldc.i4.1
						IL_0154: ceq
						IL_0156: ldc.i4.0
						IL_0157: ceq
						IL_0159: br.s IL_015c

						IL_015b: ldc.i4.1

						IL_015c: nop
						IL_015d: stloc.s 10
						IL_015f: ldloc.s 10
						IL_0161: brtrue.s IL_01a6

						IL_0163: nop
						IL_0164: ldloc.s 7
						IL_0166: ldarg.0
						IL_0167: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
						IL_016c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
						IL_0171: ldloc.s 6
						IL_0173: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
						IL_0178: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_Cells()
						IL_017d: ldloc.s 8
						IL_017f: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCell [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection::get_Item(int32)
						IL_0184: callvirt instance object [System.Windows.Forms]System.Windows.Forms.DataGridViewCell::get_Value()
						IL_0189: call float64 [mscorlib]System.Convert::ToDouble(object)
						IL_018e: call float64 [mscorlib]System.Math::Abs(float64)
						IL_0193: stloc.s 11
						IL_0195: ldloca.s 11
						IL_0197: call instance string [mscorlib]System.Double::ToString()
						IL_019c: call string [mscorlib]System.String::Concat(string, string)
						IL_01a1: stloc.s 7
						IL_01a3: nop
						IL_01a4: br.s IL_01d9

						IL_01a6: nop
						IL_01a7: ldloc.s 7
						IL_01a9: ldarg.0
						IL_01aa: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
						IL_01af: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
						IL_01b4: ldloc.s 6
						IL_01b6: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
						IL_01bb: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_Cells()
						IL_01c0: ldloc.s 8
						IL_01c2: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCell [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection::get_Item(int32)
						IL_01c7: callvirt instance object [System.Windows.Forms]System.Windows.Forms.DataGridViewCell::get_Value()
						IL_01cc: callvirt instance string [mscorlib]System.Object::ToString()
						IL_01d1: call string [mscorlib]System.String::Concat(string, string)
						IL_01d6: stloc.s 7
						IL_01d8: nop

						IL_01d9: nop

						IL_01da: nop
						IL_01db: ldloc.s 8
						IL_01dd: ldc.i4.1
						IL_01de: add
						IL_01df: stloc.s 8

						IL_01e1: ldloc.s 8
						IL_01e3: ldarg.0
						IL_01e4: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
						IL_01e9: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
						IL_01ee: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.BaseCollection::get_Count()
						IL_01f3: clt
						IL_01f5: stloc.s 10
						IL_01f7: ldloc.s 10
						IL_01f9: brtrue IL_00e0
					// end loop

					IL_01fe: ldloc.2
					IL_01ff: ldloc.s 7
					IL_0201: callvirt instance void [mscorlib]System.IO.TextWriter::WriteLine(string)
					IL_0206: nop
					IL_0207: nop
					IL_0208: ldloc.s 6
					IL_020a: ldc.i4.1
					IL_020b: add
					IL_020c: stloc.s 6

					IL_020e: ldloc.s 6
					IL_0210: ldarg.0
					IL_0211: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
					IL_0216: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
					IL_021b: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Count()
					IL_0220: clt
					IL_0222: stloc.s 10
					IL_0224: ldloc.s 10
					IL_0226: brtrue IL_00d0
				// end loop

				IL_022b: ldloc.2
				IL_022c: callvirt instance void [mscorlib]System.IO.TextWriter::Close()
				IL_0231: nop
				IL_0232: ldloc.1
				IL_0233: callvirt instance void [mscorlib]System.IO.Stream::Close()
				IL_0238: nop
				IL_0239: nop
				IL_023a: leave.s IL_024f
			} // end .try
			catch [mscorlib]System.Exception
			{
				IL_023c: stloc.s 9
				IL_023e: nop
				IL_023f: ldloc.s 9
				IL_0241: callvirt instance string [mscorlib]System.Exception::get_Message()
				IL_0246: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
				IL_024b: pop
				IL_024c: nop
				IL_024d: leave.s IL_024f
			} // end handler

			IL_024f: nop
			IL_0250: leave.s IL_0263
		} // end .try
		finally
		{
			IL_0252: nop
			IL_0253: ldloc.2
			IL_0254: callvirt instance void [mscorlib]System.IO.TextWriter::Close()
			IL_0259: nop
			IL_025a: ldloc.1
			IL_025b: callvirt instance void [mscorlib]System.IO.Stream::Close()
			IL_0260: nop
			IL_0261: nop
			IL_0262: endfinally
		} // end handler

		IL_0263: nop
		IL_0264: ldstr "转换结束，将此工作表导出为excel共耗时："
		IL_0269: call valuetype [mscorlib]System.DateTime [mscorlib]System.DateTime::get_Now()
		IL_026e: stloc.s 12
		IL_0270: ldloca.s 12
		IL_0272: ldloc.s 4
		IL_0274: call instance valuetype [mscorlib]System.TimeSpan [mscorlib]System.DateTime::Subtract(valuetype [mscorlib]System.DateTime)
		IL_0279: stloc.s 13
		IL_027b: ldloca.s 13
		IL_027d: call instance float64 [mscorlib]System.TimeSpan::get_TotalMilliseconds()
		IL_0282: stloc.s 11
		IL_0284: ldloca.s 11
		IL_0286: call instance string [mscorlib]System.Double::ToString()
		IL_028b: ldstr "毫秒"
		IL_0290: call string [mscorlib]System.String::Concat(string, string, string)
		IL_0295: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string)
		IL_029a: pop
		IL_029b: ret
	} // end of method Form1::quick_get_current_Data_out

	.method private hidebysig 
		instance void buttonEXCEL_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x5154
		// Header size: 12
		// Code size: 87 (0x57)
		.maxstack 4
		.locals init (
			[0] object[] CS$0$0000,
			[1] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0007: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_000c: ldc.i4.3
		IL_000d: newarr [mscorlib]System.Object
		IL_0012: stloc.0
		IL_0013: ldloc.0
		IL_0014: ldc.i4.0
		IL_0015: ldc.i4.s 11
		IL_0017: box [mscorlib]System.Int32
		IL_001c: stelem.ref
		IL_001d: ldloc.0
		IL_001e: ldc.i4.1
		IL_001f: ldc.i4.s 11
		IL_0021: box [mscorlib]System.Int32
		IL_0026: stelem.ref
		IL_0027: ldloc.0
		IL_0028: ldc.i4.2
		IL_0029: ldc.i4.s 11
		IL_002b: box [mscorlib]System.Int32
		IL_0030: stelem.ref
		IL_0031: ldloc.0
		IL_0032: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::Add(object[])
		IL_0037: pop
		IL_0038: ldarg.0
		IL_0039: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_003e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_0043: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Count()
		IL_0048: ldc.i4.0
		IL_0049: ceq
		IL_004b: stloc.1
		IL_004c: ldloc.1
		IL_004d: brtrue.s IL_0056

		IL_004f: ldarg.0
		IL_0050: call instance void datapick.Form1::quick_get_current_Data_out()
		IL_0055: nop

		IL_0056: ret
	} // end of method Form1::buttonEXCEL_Click

	.method public hidebysig 
		instance void PrintGridView (
			class [System.Windows.Forms]System.Windows.Forms.DataGridView gvList
		) cil managed 
	{
		// Method begins at RVA 0x51b8
		// Header size: 12
		// Code size: 986 (0x3da)
		.maxstack 6
		.locals init (
			[0] valuetype [System.Drawing]System.Drawing.Point pnt,
			[1] class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Application excel,
			[2] int32 rowsCount,
			[3] int32 colsCount,
			[4] class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Worksheet sheet,
			[5] int32 columnCount,
			[6] int32 i,
			[7] class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range headRange,
			[8] int32 columnsIndex,
			[9] int32 rowIndex,
			[10] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: newobj instance void [System.Windows.Forms]System.Windows.Forms.ProgressBar::.ctor()
		IL_0007: stfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_000c: ldarg.0
		IL_000d: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_0012: ldc.i4.0
		IL_0013: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ProgressBar::set_Value(int32)
		IL_0018: nop
		IL_0019: ldarg.0
		IL_001a: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_001f: ldc.i4.1
		IL_0020: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ProgressBar::set_Step(int32)
		IL_0025: nop
		IL_0026: ldarg.0
		IL_0027: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_002c: ldarg.0
		IL_002d: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_0032: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0037: nop
		IL_0038: ldarg.0
		IL_0039: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_003e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::BringToFront()
		IL_0043: nop
		IL_0044: ldarg.0
		IL_0045: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_004a: ldc.i4.1
		IL_004b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_0050: nop
		IL_0051: ldarg.0
		IL_0052: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_0057: ldc.i4 9988
		IL_005c: box [mscorlib]System.Int32
		IL_0061: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Tag(object)
		IL_0066: nop
		IL_0067: ldarg.0
		IL_0068: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_006d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::BringToFront()
		IL_0072: nop
		IL_0073: ldarg.0
		IL_0074: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_0079: ldc.i4 280
		IL_007e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Width(int32)
		IL_0083: nop
		IL_0084: ldarg.0
		IL_0085: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_008a: ldc.i4.s 30
		IL_008c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Height(int32)
		IL_0091: nop
		IL_0092: ldloca.s 0
		IL_0094: ldc.i4 217
		IL_0099: ldc.i4 271
		IL_009e: call instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_00a3: nop
		IL_00a4: ldarg.0
		IL_00a5: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_00aa: ldloc.0
		IL_00ab: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_00b0: nop
		IL_00b1: newobj instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.ApplicationClass::.ctor()
		IL_00b6: stloc.1
		IL_00b7: ldloc.1
		IL_00b8: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Application [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_Application()
		IL_00bd: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Workbooks [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_Workbooks()
		IL_00c2: ldc.i4.1
		IL_00c3: box [mscorlib]System.Boolean
		IL_00c8: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Workbook [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Workbooks::Add(object)
		IL_00cd: pop
		IL_00ce: ldarg.1
		IL_00cf: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_00d4: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Count()
		IL_00d9: stloc.2
		IL_00da: ldarg.1
		IL_00db: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_00e0: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.BaseCollection::get_Count()
		IL_00e5: stloc.3
		IL_00e6: ldloc.1
		IL_00e7: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Workbooks [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_Workbooks()
		IL_00ec: ldsfld class [mscorlib]System.Reflection.Missing [mscorlib]System.Reflection.Missing::Value
		IL_00f1: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Workbook [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Workbooks::Add(object)
		IL_00f6: pop
		IL_00f7: ldloc.1
		IL_00f8: callvirt instance object [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_ActiveSheet()
		IL_00fd: castclass [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Worksheet
		IL_0102: stloc.s 4
		IL_0104: ldarg.1
		IL_0105: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_010a: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.BaseCollection::get_Count()
		IL_010f: stloc.s 5
		IL_0111: ldarg.0
		IL_0112: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_0117: ldloc.2
		IL_0118: ldc.i4.1
		IL_0119: add
		IL_011a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ProgressBar::set_Maximum(int32)
		IL_011f: nop
		IL_0120: ldc.i4.0
		IL_0121: stloc.s 6
		IL_0123: br IL_01fd
		// loop start (head: IL_01fd)
			IL_0128: nop
			IL_0129: ldloc.s 4
			IL_012b: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Worksheet::get_Cells()
			IL_0130: ldc.i4.1
			IL_0131: box [mscorlib]System.Int32
			IL_0136: ldloc.s 6
			IL_0138: ldc.i4.1
			IL_0139: add
			IL_013a: box [mscorlib]System.Int32
			IL_013f: callvirt instance object [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::get__Default(object, object)
			IL_0144: isinst [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range
			IL_0149: stloc.s 7
			IL_014b: ldloc.s 7
			IL_014d: ldarg.1
			IL_014e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
			IL_0153: ldloc.s 6
			IL_0155: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
			IL_015a: callvirt instance string [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::get_HeaderText()
			IL_015f: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set_Value2(object)
			IL_0164: nop
			IL_0165: ldloc.s 7
			IL_0167: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Font [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::get_Font()
			IL_016c: ldstr "宋体"
			IL_0171: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Font::set_Name(object)
			IL_0176: nop
			IL_0177: ldloc.s 7
			IL_0179: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Font [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::get_Font()
			IL_017e: ldc.i4.s 12
			IL_0180: box [mscorlib]System.Int32
			IL_0185: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Font::set_Size(object)
			IL_018a: nop
			IL_018b: ldloc.s 7
			IL_018d: ldc.i4 -4108
			IL_0192: box [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.XlHAlign
			IL_0197: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set_HorizontalAlignment(object)
			IL_019c: nop
			IL_019d: ldloc.s 7
			IL_019f: ldc.i4 -4108
			IL_01a4: box [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.XlVAlign
			IL_01a9: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set_VerticalAlignment(object)
			IL_01ae: nop
			IL_01af: ldloc.s 7
			IL_01b1: ldarg.1
			IL_01b2: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
			IL_01b7: ldloc.s 6
			IL_01b9: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
			IL_01be: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::get_Width()
			IL_01c3: ldc.i4.8
			IL_01c4: div
			IL_01c5: box [mscorlib]System.Int32
			IL_01ca: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set_ColumnWidth(object)
			IL_01cf: nop
			IL_01d0: ldloc.s 7
			IL_01d2: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Borders [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::get_Borders()
			IL_01d7: ldc.i4.1
			IL_01d8: box [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.XlLineStyle
			IL_01dd: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Borders::set_LineStyle(object)
			IL_01e2: nop
			IL_01e3: ldloc.s 7
			IL_01e5: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Borders [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::get_Borders()
			IL_01ea: ldc.i4.1
			IL_01eb: box [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.XlBorderWeight
			IL_01f0: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Borders::set_Weight(object)
			IL_01f5: nop
			IL_01f6: nop
			IL_01f7: ldloc.s 6
			IL_01f9: ldc.i4.1
			IL_01fa: add
			IL_01fb: stloc.s 6

			IL_01fd: ldloc.s 6
			IL_01ff: ldloc.s 5
			IL_0201: clt
			IL_0203: stloc.s 10
			IL_0205: ldloc.s 10
			IL_0207: brtrue IL_0128
		// end loop

		IL_020c: ldarg.1
		IL_020d: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
		IL_0212: ldloc.2
		IL_0213: ldc.i4.1
		IL_0214: sub
		IL_0215: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
		IL_021a: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_IsNewRow()
		IL_021f: ldc.i4.0
		IL_0220: ceq
		IL_0222: stloc.s 10
		IL_0224: ldloc.s 10
		IL_0226: brtrue.s IL_022c

		IL_0228: ldloc.2
		IL_0229: ldc.i4.1
		IL_022a: sub
		IL_022b: stloc.2

		IL_022c: ldc.i4.0
		IL_022d: stloc.s 8
		IL_022f: br.s IL_0283
		// loop start (head: IL_0283)
			IL_0231: nop
			IL_0232: ldarg.1
			IL_0233: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
			IL_0238: ldloc.s 8
			IL_023a: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
			IL_023f: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.DataGridViewBand::get_Visible()
			IL_0244: ldc.i4.0
			IL_0245: ceq
			IL_0247: stloc.s 10
			IL_0249: ldloc.s 10
			IL_024b: brtrue.s IL_027c

			IL_024d: nop
			IL_024e: ldloc.1
			IL_024f: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_Cells()
			IL_0254: ldc.i4.1
			IL_0255: box [mscorlib]System.Int32
			IL_025a: ldloc.s 8
			IL_025c: ldc.i4.1
			IL_025d: add
			IL_025e: box [mscorlib]System.Int32
			IL_0263: ldarg.1
			IL_0264: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
			IL_0269: ldloc.s 8
			IL_026b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
			IL_0270: callvirt instance string [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::get_HeaderText()
			IL_0275: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set__Default(object, object, object)
			IL_027a: nop
			IL_027b: nop

			IL_027c: nop
			IL_027d: ldloc.s 8
			IL_027f: ldc.i4.1
			IL_0280: add
			IL_0281: stloc.s 8

			IL_0283: ldloc.s 8
			IL_0285: ldloc.3
			IL_0286: clt
			IL_0288: stloc.s 10
			IL_028a: ldloc.s 10
			IL_028c: brtrue.s IL_0231
		// end loop

		IL_028e: ldc.i4.0
		IL_028f: stloc.s 9
		IL_0291: br IL_03ab
		// loop start (head: IL_03ab)
			IL_0296: nop
			IL_0297: ldc.i4.0
			IL_0298: stloc.s 8
			IL_029a: br IL_0396
			// loop start (head: IL_0396)
				IL_029f: nop
				IL_02a0: ldarg.1
				IL_02a1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
				IL_02a6: ldloc.s 8
				IL_02a8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(int32)
				IL_02ad: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.DataGridViewBand::get_Visible()
				IL_02b2: ldc.i4.0
				IL_02b3: ceq
				IL_02b5: stloc.s 10
				IL_02b7: ldloc.s 10
				IL_02b9: brtrue IL_038f

				IL_02be: nop
				IL_02bf: ldarg.1
				IL_02c0: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
				IL_02c5: ldloc.s 9
				IL_02c7: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
				IL_02cc: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_Cells()
				IL_02d1: ldloc.s 8
				IL_02d3: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCell [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection::get_Item(int32)
				IL_02d8: callvirt instance class [mscorlib]System.Type [System.Windows.Forms]System.Windows.Forms.DataGridViewCell::get_ValueType()
				IL_02dd: ldtoken [mscorlib]System.String
				IL_02e2: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
				IL_02e7: ceq
				IL_02e9: ldc.i4.0
				IL_02ea: ceq
				IL_02ec: stloc.s 10
				IL_02ee: ldloc.s 10
				IL_02f0: brtrue.s IL_033f

				IL_02f2: ldloc.1
				IL_02f3: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_Cells()
				IL_02f8: ldloc.s 9
				IL_02fa: ldc.i4.2
				IL_02fb: add
				IL_02fc: box [mscorlib]System.Int32
				IL_0301: ldloc.s 8
				IL_0303: ldc.i4.1
				IL_0304: add
				IL_0305: box [mscorlib]System.Int32
				IL_030a: ldstr "'"
				IL_030f: ldarg.1
				IL_0310: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
				IL_0315: ldloc.s 9
				IL_0317: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
				IL_031c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_Cells()
				IL_0321: ldloc.s 8
				IL_0323: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCell [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection::get_Item(int32)
				IL_0328: callvirt instance object [System.Windows.Forms]System.Windows.Forms.DataGridViewCell::get_Value()
				IL_032d: callvirt instance string [mscorlib]System.Object::ToString()
				IL_0332: call string [mscorlib]System.String::Concat(string, string)
				IL_0337: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set__Default(object, object, object)
				IL_033c: nop
				IL_033d: br.s IL_0382

				IL_033f: nop
				IL_0340: ldloc.1
				IL_0341: callvirt instance class [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::get_Cells()
				IL_0346: ldloc.s 9
				IL_0348: ldc.i4.2
				IL_0349: add
				IL_034a: box [mscorlib]System.Int32
				IL_034f: ldloc.s 8
				IL_0351: ldc.i4.1
				IL_0352: add
				IL_0353: box [mscorlib]System.Int32
				IL_0358: ldarg.1
				IL_0359: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Rows()
				IL_035e: ldloc.s 9
				IL_0360: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridViewRowCollection::get_Item(int32)
				IL_0365: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::get_Cells()
				IL_036a: ldloc.s 8
				IL_036c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewCell [System.Windows.Forms]System.Windows.Forms.DataGridViewCellCollection::get_Item(int32)
				IL_0371: callvirt instance object [System.Windows.Forms]System.Windows.Forms.DataGridViewCell::get_Value()
				IL_0376: callvirt instance string [mscorlib]System.Object::ToString()
				IL_037b: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel.Range::set__Default(object, object, object)
				IL_0380: nop
				IL_0381: nop

				IL_0382: ldarg.0
				IL_0383: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
				IL_0388: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ProgressBar::PerformStep()
				IL_038d: nop
				IL_038e: nop

				IL_038f: nop
				IL_0390: ldloc.s 8
				IL_0392: ldc.i4.1
				IL_0393: add
				IL_0394: stloc.s 8

				IL_0396: ldloc.s 8
				IL_0398: ldloc.3
				IL_0399: clt
				IL_039b: stloc.s 10
				IL_039d: ldloc.s 10
				IL_039f: brtrue IL_029f
			// end loop

			IL_03a4: nop
			IL_03a5: ldloc.s 9
			IL_03a7: ldc.i4.1
			IL_03a8: add
			IL_03a9: stloc.s 9

			IL_03ab: ldloc.s 9
			IL_03ad: ldloc.2
			IL_03ae: clt
			IL_03b0: stloc.s 10
			IL_03b2: ldloc.s 10
			IL_03b4: brtrue IL_0296
		// end loop

		IL_03b9: ldarg.0
		IL_03ba: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_03bf: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ProgressBar::PerformStep()
		IL_03c4: nop
		IL_03c5: ldarg.0
		IL_03c6: ldfld class [System.Windows.Forms]System.Windows.Forms.ProgressBar datapick.Form1::pb3
		IL_03cb: callvirt instance void [System]System.ComponentModel.Component::Dispose()
		IL_03d0: nop
		IL_03d1: ldloc.1
		IL_03d2: ldc.i4.1
		IL_03d3: callvirt instance void [Microsoft.Office.Interop.Excel]Microsoft.Office.Interop.Excel._Application::set_Visible(bool)
		IL_03d8: nop
		IL_03d9: ret
	} // end of method Form1::PrintGridView

	.method private hidebysig 
		instance void comboBoxCOM_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x55a0
		// Header size: 12
		// Code size: 109 (0x6d)
		.maxstack 4
		.locals init (
			[0] class [mscorlib]System.Exception ee,
			[1] bool CS$4$0000
		)

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldarg.0
			IL_0003: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0008: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
			IL_000d: ldc.i4.0
			IL_000e: ceq
			IL_0010: stloc.1
			IL_0011: ldloc.1
			IL_0012: brtrue.s IL_0022

			IL_0014: nop
			IL_0015: ldarg.0
			IL_0016: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_001b: callvirt instance void [System]System.IO.Ports.SerialPort::Close()
			IL_0020: nop
			IL_0021: nop

			IL_0022: ldarg.0
			IL_0023: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0028: ldarg.0
			IL_0029: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
			IL_002e: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
			IL_0033: callvirt instance string [mscorlib]System.Object::ToString()
			IL_0038: callvirt instance string [mscorlib]System.String::Trim()
			IL_003d: callvirt instance void [System]System.IO.Ports.SerialPort::set_PortName(string)
			IL_0042: nop
			IL_0043: ldarg.0
			IL_0044: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0049: callvirt instance void [System]System.IO.Ports.SerialPort::Open()
			IL_004e: nop
			IL_004f: nop
			IL_0050: leave.s IL_006b
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_0052: stloc.0
			IL_0053: nop
			IL_0054: ldloc.0
			IL_0055: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_005a: ldstr "警告"
			IL_005f: ldc.i4.0
			IL_0060: ldc.i4.s 48
			IL_0062: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_0067: pop
			IL_0068: nop
			IL_0069: leave.s IL_006b
		} // end handler

		IL_006b: nop
		IL_006c: ret
	} // end of method Form1::comboBoxCOM_SelectedIndexChanged

	.method private hidebysig 
		instance void comboBoxBAUDE_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x562c
		// Header size: 12
		// Code size: 112 (0x70)
		.maxstack 4
		.locals init (
			[0] class [mscorlib]System.Exception ee,
			[1] bool CS$4$0000
		)

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldarg.0
			IL_0003: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0008: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
			IL_000d: ldc.i4.0
			IL_000e: ceq
			IL_0010: stloc.1
			IL_0011: ldloc.1
			IL_0012: brtrue.s IL_0020

			IL_0014: ldarg.0
			IL_0015: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_001a: callvirt instance void [System]System.IO.Ports.SerialPort::Close()
			IL_001f: nop

			IL_0020: ldarg.0
			IL_0021: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0026: ldarg.0
			IL_0027: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
			IL_002c: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
			IL_0031: callvirt instance string [mscorlib]System.Object::ToString()
			IL_0036: callvirt instance string [mscorlib]System.String::Trim()
			IL_003b: call int32 [mscorlib]System.Convert::ToInt32(string)
			IL_0040: callvirt instance void [System]System.IO.Ports.SerialPort::set_BaudRate(int32)
			IL_0045: nop
			IL_0046: ldarg.0
			IL_0047: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_004c: callvirt instance void [System]System.IO.Ports.SerialPort::Open()
			IL_0051: nop
			IL_0052: nop
			IL_0053: leave.s IL_006e
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_0055: stloc.0
			IL_0056: nop
			IL_0057: ldloc.0
			IL_0058: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_005d: ldstr "警告"
			IL_0062: ldc.i4.0
			IL_0063: ldc.i4.s 48
			IL_0065: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_006a: pop
			IL_006b: nop
			IL_006c: leave.s IL_006e
		} // end handler

		IL_006e: nop
		IL_006f: ret
	} // end of method Form1::comboBoxBAUDE_SelectedIndexChanged

	.method private hidebysig 
		instance void comboBoxdanwei_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x56b8
		// Header size: 12
		// Code size: 1959 (0x7a7)
		.maxstack 2
		.locals init (
			[0] bool CS$4$0000,
			[1] string CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_0007: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_000c: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0011: ldstr "高斯计"
		IL_0016: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_001b: ldc.i4.0
		IL_001c: ceq
		IL_001e: stloc.0
		IL_001f: ldloc.0
		IL_0020: brtrue IL_01b4

		IL_0025: nop
		IL_0026: ldarg.0
		IL_0027: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_002c: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0031: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_0036: ldstr "实时磁场大小变化图"
		IL_003b: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0040: nop
		IL_0041: ldarg.0
		IL_0042: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0047: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_004c: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0051: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0056: ldstr "时间"
		IL_005b: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0060: nop
		IL_0061: ldarg.0
		IL_0062: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0067: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_006c: ldstr "T"
		IL_0071: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0076: ldstr "磁场值(mT)"
		IL_007b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_0080: nop
		IL_0081: ldarg.0
		IL_0082: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0087: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_008c: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_0091: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0096: ldstr "磁场值(mT)"
		IL_009b: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_00a0: nop
		IL_00a1: ldarg.0
		IL_00a2: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_00a7: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_00ac: nop
		IL_00ad: ldarg.0
		IL_00ae: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_00b3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_00b8: nop
		IL_00b9: ldarg.0
		IL_00ba: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_00bf: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_00c4: callvirt instance string [mscorlib]System.Object::ToString()
		IL_00c9: ldstr "mT"
		IL_00ce: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00d3: ldc.i4.0
		IL_00d4: ceq
		IL_00d6: stloc.0
		IL_00d7: ldloc.0
		IL_00d8: brtrue.s IL_00f9

		IL_00da: nop
		IL_00db: ldarg.0
		IL_00dc: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_00e1: ldstr "磁场值(mT)"
		IL_00e6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_00eb: nop
		IL_00ec: ldarg.0
		IL_00ed: ldc.i4.1
		IL_00ee: stfld int32 datapick.Form1::DWflag
		IL_00f3: nop
		IL_00f4: br IL_01ae

		IL_00f9: ldarg.0
		IL_00fa: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_00ff: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0104: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0109: ldstr "G"
		IL_010e: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0113: ldc.i4.0
		IL_0114: ceq
		IL_0116: stloc.0
		IL_0117: ldloc.0
		IL_0118: brtrue.s IL_0136

		IL_011a: nop
		IL_011b: ldarg.0
		IL_011c: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_0121: ldstr "磁场值(G)"
		IL_0126: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_012b: nop
		IL_012c: ldarg.0
		IL_012d: ldc.i4.2
		IL_012e: stfld int32 datapick.Form1::DWflag
		IL_0133: nop
		IL_0134: br.s IL_01ae

		IL_0136: ldarg.0
		IL_0137: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_013c: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0141: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0146: ldstr "A/m"
		IL_014b: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0150: ldc.i4.0
		IL_0151: ceq
		IL_0153: stloc.0
		IL_0154: ldloc.0
		IL_0155: brtrue.s IL_0173

		IL_0157: nop
		IL_0158: ldarg.0
		IL_0159: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_015e: ldstr "磁场值(A/m)"
		IL_0163: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0168: nop
		IL_0169: ldarg.0
		IL_016a: ldc.i4.3
		IL_016b: stfld int32 datapick.Form1::DWflag
		IL_0170: nop
		IL_0171: br.s IL_01ae

		IL_0173: ldarg.0
		IL_0174: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0179: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_017e: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0183: ldstr "Oe"
		IL_0188: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_018d: ldc.i4.0
		IL_018e: ceq
		IL_0190: stloc.0
		IL_0191: ldloc.0
		IL_0192: brtrue.s IL_01ae

		IL_0194: nop
		IL_0195: ldarg.0
		IL_0196: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_019b: ldstr "磁场值(Oe)"
		IL_01a0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_01a5: nop
		IL_01a6: ldarg.0
		IL_01a7: ldc.i4.4
		IL_01a8: stfld int32 datapick.Form1::DWflag
		IL_01ad: nop

		IL_01ae: nop
		IL_01af: br IL_07a6

		IL_01b4: ldarg.0
		IL_01b5: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_01ba: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_01bf: callvirt instance string [mscorlib]System.Object::ToString()
		IL_01c4: ldstr "高斯计(弱磁)"
		IL_01c9: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_01ce: ldc.i4.0
		IL_01cf: ceq
		IL_01d1: stloc.0
		IL_01d2: ldloc.0
		IL_01d3: brtrue IL_02ea

		IL_01d8: nop
		IL_01d9: ldarg.0
		IL_01da: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_01df: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_01e4: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_01e9: ldstr "实时磁场大小变化图"
		IL_01ee: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_01f3: nop
		IL_01f4: ldarg.0
		IL_01f5: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_01fa: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_01ff: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_0204: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0209: ldstr "时间"
		IL_020e: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0213: nop
		IL_0214: ldarg.0
		IL_0215: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_021a: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_021f: ldstr "T"
		IL_0224: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0229: ldstr "磁场值(μT)"
		IL_022e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_0233: nop
		IL_0234: ldarg.0
		IL_0235: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_023a: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_023f: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_0244: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0249: ldstr "磁场值(μT)"
		IL_024e: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_0253: nop
		IL_0254: ldarg.0
		IL_0255: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_025a: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_025f: nop
		IL_0260: ldarg.0
		IL_0261: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0266: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_026b: nop
		IL_026c: ldarg.0
		IL_026d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0272: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0277: callvirt instance string [mscorlib]System.Object::ToString()
		IL_027c: ldstr "μT"
		IL_0281: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0286: ldc.i4.0
		IL_0287: ceq
		IL_0289: stloc.0
		IL_028a: ldloc.0
		IL_028b: brtrue.s IL_02a9

		IL_028d: nop
		IL_028e: ldarg.0
		IL_028f: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_0294: ldstr "磁场值(μT)"
		IL_0299: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_029e: nop
		IL_029f: ldarg.0
		IL_02a0: ldc.i4.7
		IL_02a1: stfld int32 datapick.Form1::DWflag
		IL_02a6: nop
		IL_02a7: br.s IL_02e4

		IL_02a9: ldarg.0
		IL_02aa: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_02af: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_02b4: callvirt instance string [mscorlib]System.Object::ToString()
		IL_02b9: ldstr "mG"
		IL_02be: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_02c3: ldc.i4.0
		IL_02c4: ceq
		IL_02c6: stloc.0
		IL_02c7: ldloc.0
		IL_02c8: brtrue.s IL_02e4

		IL_02ca: nop
		IL_02cb: ldarg.0
		IL_02cc: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_02d1: ldstr "磁场值(mG)"
		IL_02d6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_02db: nop
		IL_02dc: ldarg.0
		IL_02dd: ldc.i4.8
		IL_02de: stfld int32 datapick.Form1::DWflag
		IL_02e3: nop

		IL_02e4: nop
		IL_02e5: br IL_07a6

		IL_02ea: ldarg.0
		IL_02eb: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_02f0: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_02f5: callvirt instance string [mscorlib]System.Object::ToString()
		IL_02fa: ldstr "磁通计"
		IL_02ff: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0304: ldc.i4.0
		IL_0305: ceq
		IL_0307: stloc.0
		IL_0308: ldloc.0
		IL_0309: brtrue IL_07a6

		IL_030e: nop
		IL_030f: ldarg.0
		IL_0310: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0315: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_031a: callvirt instance string [mscorlib]System.Object::ToString()
		IL_031f: stloc.1
		IL_0320: ldloc.1
		IL_0321: brfalse IL_07a5

		IL_0326: ldloc.1
		IL_0327: ldstr "mWb"
		IL_032c: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0331: brtrue.s IL_0388

		IL_0333: ldloc.1
		IL_0334: ldstr "kMx"
		IL_0339: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_033e: brtrue IL_0438

		IL_0343: ldloc.1
		IL_0344: ldstr "mT"
		IL_0349: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_034e: brtrue IL_04e8

		IL_0353: ldloc.1
		IL_0354: ldstr "G"
		IL_0359: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_035e: brtrue IL_0598

		IL_0363: ldloc.1
		IL_0364: ldstr "A/m"
		IL_0369: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_036e: brtrue IL_0648

		IL_0373: ldloc.1
		IL_0374: ldstr "Oe"
		IL_0379: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_037e: brtrue IL_06f8

		IL_0383: br IL_07a5

		IL_0388: ldarg.0
		IL_0389: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_038e: ldstr "磁通量(mWb)"
		IL_0393: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0398: nop
		IL_0399: ldarg.0
		IL_039a: ldc.i4.5
		IL_039b: stfld int32 datapick.Form1::DWflag
		IL_03a0: ldarg.0
		IL_03a1: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_03a6: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_03ab: ldstr "T"
		IL_03b0: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_03b5: ldstr "磁通量(mWb)"
		IL_03ba: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_03bf: nop
		IL_03c0: ldarg.0
		IL_03c1: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_03c6: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_03cb: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_03d0: ldstr "实时磁通大小变化图"
		IL_03d5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_03da: nop
		IL_03db: ldarg.0
		IL_03dc: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_03e1: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_03e6: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_03eb: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_03f0: ldstr "时间"
		IL_03f5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_03fa: nop
		IL_03fb: ldarg.0
		IL_03fc: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0401: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0406: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_040b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0410: ldstr "磁通量(mWb)"
		IL_0415: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_041a: nop
		IL_041b: ldarg.0
		IL_041c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0421: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0426: nop
		IL_0427: ldarg.0
		IL_0428: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_042d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_0432: nop
		IL_0433: br IL_07a5

		IL_0438: ldarg.0
		IL_0439: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_043e: ldstr "磁通量(kMx)"
		IL_0443: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0448: nop
		IL_0449: ldarg.0
		IL_044a: ldc.i4.6
		IL_044b: stfld int32 datapick.Form1::DWflag
		IL_0450: ldarg.0
		IL_0451: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0456: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_045b: ldstr "T"
		IL_0460: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0465: ldstr "磁通量(mWb)"
		IL_046a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_046f: nop
		IL_0470: ldarg.0
		IL_0471: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0476: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_047b: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_0480: ldstr "实时磁通大小变化图"
		IL_0485: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_048a: nop
		IL_048b: ldarg.0
		IL_048c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0491: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0496: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_049b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_04a0: ldstr "时间"
		IL_04a5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_04aa: nop
		IL_04ab: ldarg.0
		IL_04ac: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_04b1: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_04b6: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_04bb: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_04c0: ldstr "磁通量(mWb)"
		IL_04c5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_04ca: nop
		IL_04cb: ldarg.0
		IL_04cc: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_04d1: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_04d6: nop
		IL_04d7: ldarg.0
		IL_04d8: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_04dd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_04e2: nop
		IL_04e3: br IL_07a5

		IL_04e8: ldarg.0
		IL_04e9: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_04ee: ldstr "磁场值(mT)"
		IL_04f3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_04f8: nop
		IL_04f9: ldarg.0
		IL_04fa: ldc.i4.1
		IL_04fb: stfld int32 datapick.Form1::DWflag
		IL_0500: ldarg.0
		IL_0501: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0506: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_050b: ldstr "T"
		IL_0510: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0515: ldstr "磁场值(mT)"
		IL_051a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_051f: nop
		IL_0520: ldarg.0
		IL_0521: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0526: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_052b: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_0530: ldstr "实时磁场大小变化图"
		IL_0535: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_053a: nop
		IL_053b: ldarg.0
		IL_053c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0541: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0546: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_054b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0550: ldstr "时间"
		IL_0555: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_055a: nop
		IL_055b: ldarg.0
		IL_055c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0561: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0566: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_056b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0570: ldstr "磁场值(mT)"
		IL_0575: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_057a: nop
		IL_057b: ldarg.0
		IL_057c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0581: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0586: nop
		IL_0587: ldarg.0
		IL_0588: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_058d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_0592: nop
		IL_0593: br IL_07a5

		IL_0598: ldarg.0
		IL_0599: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_059e: ldstr "磁场值(G)"
		IL_05a3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_05a8: nop
		IL_05a9: ldarg.0
		IL_05aa: ldc.i4.2
		IL_05ab: stfld int32 datapick.Form1::DWflag
		IL_05b0: ldarg.0
		IL_05b1: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_05b6: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_05bb: ldstr "T"
		IL_05c0: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_05c5: ldstr "磁场值(mT)"
		IL_05ca: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_05cf: nop
		IL_05d0: ldarg.0
		IL_05d1: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_05d6: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_05db: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_05e0: ldstr "实时磁场大小变化图"
		IL_05e5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_05ea: nop
		IL_05eb: ldarg.0
		IL_05ec: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_05f1: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_05f6: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_05fb: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0600: ldstr "时间"
		IL_0605: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_060a: nop
		IL_060b: ldarg.0
		IL_060c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0611: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0616: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_061b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0620: ldstr "磁场值(mT)"
		IL_0625: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_062a: nop
		IL_062b: ldarg.0
		IL_062c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0631: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0636: nop
		IL_0637: ldarg.0
		IL_0638: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_063d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_0642: nop
		IL_0643: br IL_07a5

		IL_0648: ldarg.0
		IL_0649: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_064e: ldstr "磁场值(A/m)"
		IL_0653: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0658: nop
		IL_0659: ldarg.0
		IL_065a: ldc.i4.3
		IL_065b: stfld int32 datapick.Form1::DWflag
		IL_0660: ldarg.0
		IL_0661: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0666: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_066b: ldstr "T"
		IL_0670: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0675: ldstr "磁场值(mT)"
		IL_067a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_067f: nop
		IL_0680: ldarg.0
		IL_0681: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0686: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_068b: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_0690: ldstr "实时磁场大小变化图"
		IL_0695: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_069a: nop
		IL_069b: ldarg.0
		IL_069c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_06a1: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_06a6: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_06ab: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_06b0: ldstr "时间"
		IL_06b5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_06ba: nop
		IL_06bb: ldarg.0
		IL_06bc: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_06c1: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_06c6: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_06cb: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_06d0: ldstr "磁场值(mT)"
		IL_06d5: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_06da: nop
		IL_06db: ldarg.0
		IL_06dc: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_06e1: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_06e6: nop
		IL_06e7: ldarg.0
		IL_06e8: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_06ed: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_06f2: nop
		IL_06f3: br IL_07a5

		IL_06f8: ldarg.0
		IL_06f9: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_06fe: ldstr "磁场值(Oe)"
		IL_0703: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0708: nop
		IL_0709: ldarg.0
		IL_070a: ldc.i4.4
		IL_070b: stfld int32 datapick.Form1::DWflag
		IL_0710: ldarg.0
		IL_0711: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0716: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection [System.Windows.Forms]System.Windows.Forms.DataGridView::get_Columns()
		IL_071b: ldstr "T"
		IL_0720: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnCollection::get_Item(string)
		IL_0725: ldstr "磁场值(mT)"
		IL_072a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewColumn::set_HeaderText(string)
		IL_072f: nop
		IL_0730: ldarg.0
		IL_0731: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0736: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_073b: callvirt instance class [ZedGraph]ZedGraph.Label [ZedGraph]ZedGraph.PaneBase::get_Title()
		IL_0740: ldstr "实时磁场大小变化图"
		IL_0745: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_074a: nop
		IL_074b: ldarg.0
		IL_074c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0751: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0756: callvirt instance class [ZedGraph]ZedGraph.XAxis [ZedGraph]ZedGraph.GraphPane::get_XAxis()
		IL_075b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0760: ldstr "时间"
		IL_0765: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_076a: nop
		IL_076b: ldarg.0
		IL_076c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0771: callvirt instance class [ZedGraph]ZedGraph.GraphPane [ZedGraph]ZedGraph.ZedGraphControl::get_GraphPane()
		IL_0776: callvirt instance class [ZedGraph]ZedGraph.YAxis [ZedGraph]ZedGraph.GraphPane::get_YAxis()
		IL_077b: callvirt instance class [ZedGraph]ZedGraph.AxisLabel [ZedGraph]ZedGraph.Axis::get_Title()
		IL_0780: ldstr "磁场值(mT)"
		IL_0785: callvirt instance void [ZedGraph]ZedGraph.Label::set_Text(string)
		IL_078a: nop
		IL_078b: ldarg.0
		IL_078c: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0791: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0796: nop
		IL_0797: ldarg.0
		IL_0798: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_079d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_07a2: nop
		IL_07a3: br.s IL_07a5

		IL_07a5: nop

		IL_07a6: ret
	} // end of method Form1::comboBoxdanwei_SelectedIndexChanged

	.method private hidebysig 
		instance void radioButton1_CheckedChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x5e6c
		// Header size: 12
		// Code size: 69 (0x45)
		.maxstack 2
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_0007: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.RadioButton::get_Checked()
		IL_000c: ldc.i4.0
		IL_000d: ceq
		IL_000f: stloc.0
		IL_0010: ldloc.0
		IL_0011: brtrue.s IL_0044

		IL_0013: nop
		IL_0014: ldarg.0
		IL_0015: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_001a: ldc.i4.1
		IL_001b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_0020: nop
		IL_0021: ldarg.0
		IL_0022: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_0027: ldstr "清空"
		IL_002c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0031: nop
		IL_0032: ldarg.0
		IL_0033: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0038: ldstr "导出"
		IL_003d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0042: nop
		IL_0043: nop

		IL_0044: ret
	} // end of method Form1::radioButton1_CheckedChanged

	.method private hidebysig 
		instance void radioButton2_CheckedChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x5ec0
		// Header size: 12
		// Code size: 82 (0x52)
		.maxstack 2
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_0007: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.RadioButton::get_Checked()
		IL_000c: ldc.i4.0
		IL_000d: ceq
		IL_000f: stloc.0
		IL_0010: ldloc.0
		IL_0011: brtrue.s IL_0051

		IL_0013: nop
		IL_0014: ldarg.0
		IL_0015: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_001a: ldc.i4.0
		IL_001b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_0020: nop
		IL_0021: ldarg.0
		IL_0022: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0027: ldc.i4.1
		IL_0028: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_002d: nop
		IL_002e: ldarg.0
		IL_002f: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_0034: ldstr "刷新"
		IL_0039: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_003e: nop
		IL_003f: ldarg.0
		IL_0040: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0045: ldstr "保存"
		IL_004a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_004f: nop
		IL_0050: nop

		IL_0051: ret
	} // end of method Form1::radioButton2_CheckedChanged

	.method private hidebysig 
		instance void comboBoxModel_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x5f20
		// Header size: 12
		// Code size: 1025 (0x401)
		.maxstack 2
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarg.0
		IL_0003: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0008: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_000d: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0012: stfld string datapick.Form1::MODEL
		IL_0017: ldarg.0
		IL_0018: ldfld string datapick.Form1::MODEL
		IL_001d: ldstr "CH-260"
		IL_0022: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0027: brtrue.s IL_0062

		IL_0029: ldarg.0
		IL_002a: ldfld string datapick.Form1::MODEL
		IL_002f: ldstr "CH-290"
		IL_0034: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0039: brtrue.s IL_0062

		IL_003b: ldarg.0
		IL_003c: ldfld string datapick.Form1::MODEL
		IL_0041: ldstr "CH-260磁通手动"
		IL_0046: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_004b: brtrue.s IL_0062

		IL_004d: ldarg.0
		IL_004e: ldfld string datapick.Form1::MODEL
		IL_0053: ldstr "CH-290磁通手动"
		IL_0058: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_005d: ldc.i4.0
		IL_005e: ceq
		IL_0060: br.s IL_0063

		IL_0062: ldc.i4.0

		IL_0063: nop
		IL_0064: stloc.0
		IL_0065: ldloc.0
		IL_0066: brtrue.s IL_0077

		IL_0068: ldarg.0
		IL_0069: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_006e: ldc.i4.0
		IL_006f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_0074: nop
		IL_0075: br.s IL_00aa

		IL_0077: ldarg.0
		IL_0078: ldfld string datapick.Form1::MODEL
		IL_007d: ldstr "CH-1500B"
		IL_0082: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0087: ldc.i4.0
		IL_0088: ceq
		IL_008a: stloc.0
		IL_008b: ldloc.0
		IL_008c: brtrue.s IL_009d

		IL_008e: ldarg.0
		IL_008f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_0094: ldc.i4.2
		IL_0095: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_009a: nop
		IL_009b: br.s IL_00aa

		IL_009d: ldarg.0
		IL_009e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_00a3: ldc.i4.1
		IL_00a4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_00a9: nop

		IL_00aa: ldarg.0
		IL_00ab: ldfld string datapick.Form1::MODEL
		IL_00b0: ldstr "CH-260"
		IL_00b5: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00ba: brtrue.s IL_0107

		IL_00bc: ldarg.0
		IL_00bd: ldfld string datapick.Form1::MODEL
		IL_00c2: ldstr "CH-1800"
		IL_00c7: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00cc: brtrue.s IL_0107

		IL_00ce: ldarg.0
		IL_00cf: ldfld string datapick.Form1::MODEL
		IL_00d4: ldstr "CH-290"
		IL_00d9: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00de: brtrue.s IL_0107

		IL_00e0: ldarg.0
		IL_00e1: ldfld string datapick.Form1::MODEL
		IL_00e6: ldstr "CH-260磁通手动"
		IL_00eb: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00f0: brtrue.s IL_0107

		IL_00f2: ldarg.0
		IL_00f3: ldfld string datapick.Form1::MODEL
		IL_00f8: ldstr "CH-290磁通手动"
		IL_00fd: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0102: ldc.i4.0
		IL_0103: ceq
		IL_0105: br.s IL_0108

		IL_0107: ldc.i4.0

		IL_0108: nop
		IL_0109: stloc.0
		IL_010a: ldloc.0
		IL_010b: brtrue.s IL_0121

		IL_010d: nop
		IL_010e: ldarg.0
		IL_010f: ldc.i4.s 24
		IL_0111: stfld int32 datapick.Form1::ReadLength
		IL_0116: ldarg.0
		IL_0117: ldc.i4.s 14
		IL_0119: stfld int32 datapick.Form1::HighSpeedBase
		IL_011e: nop
		IL_011f: br.s IL_0181

		IL_0121: ldarg.0
		IL_0122: ldfld string datapick.Form1::MODEL
		IL_0127: ldstr "CH-1500"
		IL_012c: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0131: ldc.i4.0
		IL_0132: ceq
		IL_0134: stloc.0
		IL_0135: ldloc.0
		IL_0136: brtrue.s IL_014c

		IL_0138: nop
		IL_0139: ldarg.0
		IL_013a: ldc.i4.s 21
		IL_013c: stfld int32 datapick.Form1::ReadLength
		IL_0141: ldarg.0
		IL_0142: ldc.i4.s 11
		IL_0144: stfld int32 datapick.Form1::HighSpeedBase
		IL_0149: nop
		IL_014a: br.s IL_0181

		IL_014c: ldarg.0
		IL_014d: ldfld string datapick.Form1::MODEL
		IL_0152: ldstr "CH-1300"
		IL_0157: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_015c: ldc.i4.0
		IL_015d: ceq
		IL_015f: stloc.0
		IL_0160: ldloc.0
		IL_0161: brtrue.s IL_016f

		IL_0163: nop
		IL_0164: ldarg.0
		IL_0165: ldc.i4.s 20
		IL_0167: stfld int32 datapick.Form1::ReadLength
		IL_016c: nop
		IL_016d: br.s IL_0181

		IL_016f: nop
		IL_0170: ldarg.0
		IL_0171: ldc.i4.s 23
		IL_0173: stfld int32 datapick.Form1::ReadLength
		IL_0178: ldarg.0
		IL_0179: ldc.i4.s 13
		IL_017b: stfld int32 datapick.Form1::HighSpeedBase
		IL_0180: nop

		IL_0181: ldarg.0
		IL_0182: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0187: ldc.i4.0
		IL_0188: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_018d: nop
		IL_018e: ldarg.0
		IL_018f: ldfld string datapick.Form1::MODEL
		IL_0194: ldstr "CH-260"
		IL_0199: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_019e: brtrue.s IL_020f

		IL_01a0: ldarg.0
		IL_01a1: ldfld string datapick.Form1::MODEL
		IL_01a6: ldstr "CH-1300"
		IL_01ab: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_01b0: brtrue.s IL_020f

		IL_01b2: ldarg.0
		IL_01b3: ldfld string datapick.Form1::MODEL
		IL_01b8: ldstr "CH-290"
		IL_01bd: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_01c2: brtrue.s IL_020f

		IL_01c4: ldarg.0
		IL_01c5: ldfld string datapick.Form1::MODEL
		IL_01ca: ldstr "CH-260磁通手动"
		IL_01cf: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_01d4: brtrue.s IL_020f

		IL_01d6: ldarg.0
		IL_01d7: ldfld string datapick.Form1::MODEL
		IL_01dc: ldstr "CH-290磁通手动"
		IL_01e1: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_01e6: brtrue.s IL_020f

		IL_01e8: ldarg.0
		IL_01e9: ldfld string datapick.Form1::MODEL
		IL_01ee: ldstr "CH-260磁强手动"
		IL_01f3: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_01f8: brtrue.s IL_020f

		IL_01fa: ldarg.0
		IL_01fb: ldfld string datapick.Form1::MODEL
		IL_0200: ldstr "CH-290磁强手动"
		IL_0205: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_020a: ldc.i4.0
		IL_020b: ceq
		IL_020d: br.s IL_0210

		IL_020f: ldc.i4.0

		IL_0210: nop
		IL_0211: stloc.0
		IL_0212: ldloc.0
		IL_0213: brtrue.s IL_025d

		IL_0215: nop
		IL_0216: ldarg.0
		IL_0217: ldc.i4.4
		IL_0218: stfld int32 datapick.Form1::FlagEnquire
		IL_021d: ldarg.0
		IL_021e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0223: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0228: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_022d: nop
		IL_022e: ldarg.0
		IL_022f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0234: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0239: ldstr "普通数据"
		IL_023e: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0243: pop
		IL_0244: ldarg.0
		IL_0245: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_024a: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_024f: ldstr "历史数据"
		IL_0254: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0259: pop
		IL_025a: nop
		IL_025b: br.s IL_02b9

		IL_025d: nop
		IL_025e: ldarg.0
		IL_025f: ldc.i4.0
		IL_0260: stfld int32 datapick.Form1::FlagEnquire
		IL_0265: ldarg.0
		IL_0266: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_026b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0270: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_0275: nop
		IL_0276: ldarg.0
		IL_0277: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_027c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0281: ldstr "普通数据"
		IL_0286: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_028b: pop
		IL_028c: ldarg.0
		IL_028d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0292: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0297: ldstr "高速数据"
		IL_029c: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_02a1: pop
		IL_02a2: ldarg.0
		IL_02a3: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_02a8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_02ad: ldstr "历史数据"
		IL_02b2: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_02b7: pop
		IL_02b8: nop

		IL_02b9: ldarg.0
		IL_02ba: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_02bf: ldc.i4.0
		IL_02c0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_02c5: nop
		IL_02c6: ldarg.0
		IL_02c7: ldfld string datapick.Form1::MODEL
		IL_02cc: ldstr "CH-1500"
		IL_02d1: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_02d6: brtrue.s IL_02ea

		IL_02d8: ldarg.0
		IL_02d9: ldfld string datapick.Form1::MODEL
		IL_02de: ldstr "CH-1500B"
		IL_02e3: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_02e8: brfalse.s IL_0302

		IL_02ea: ldarg.0
		IL_02eb: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_02f0: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_02f5: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::get_Count()
		IL_02fa: ldc.i4.6
		IL_02fb: ceq
		IL_02fd: ldc.i4.0
		IL_02fe: ceq
		IL_0300: br.s IL_0303

		IL_0302: ldc.i4.1

		IL_0303: nop
		IL_0304: stloc.0
		IL_0305: ldloc.0
		IL_0306: brtrue.s IL_031e

		IL_0308: nop
		IL_0309: ldarg.0
		IL_030a: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_030f: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0314: ldc.i4.6
		IL_0315: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::RemoveAt(int32)
		IL_031a: nop
		IL_031b: nop
		IL_031c: br.s IL_034f

		IL_031e: nop
		IL_031f: ldarg.0
		IL_0320: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0325: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_032a: ldstr "300组/s"
		IL_032f: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Contains(object)
		IL_0334: stloc.0
		IL_0335: ldloc.0
		IL_0336: brtrue.s IL_034e

		IL_0338: ldarg.0
		IL_0339: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_033e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0343: ldstr "300组/s"
		IL_0348: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_034d: pop

		IL_034e: nop

		IL_034f: ldarg.0
		IL_0350: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0355: ldc.i4.0
		IL_0356: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_035b: nop
		IL_035c: ldarg.0
		IL_035d: ldfld string datapick.Form1::MODEL
		IL_0362: ldstr "CH-1600"
		IL_0367: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_036c: brtrue.s IL_0383

		IL_036e: ldarg.0
		IL_036f: ldfld string datapick.Form1::MODEL
		IL_0374: ldstr "CH-1800"
		IL_0379: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_037e: ldc.i4.0
		IL_037f: ceq
		IL_0381: br.s IL_0384

		IL_0383: ldc.i4.0

		IL_0384: nop
		IL_0385: stloc.0
		IL_0386: ldloc.0
		IL_0387: brtrue.s IL_03ca

		IL_0389: nop
		IL_038a: ldarg.0
		IL_038b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0390: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0395: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_039a: nop
		IL_039b: ldarg.0
		IL_039c: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_03a1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03a6: ldstr "串口"
		IL_03ab: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_03b0: pop
		IL_03b1: ldarg.0
		IL_03b2: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_03b7: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03bc: ldstr "USB"
		IL_03c1: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_03c6: pop
		IL_03c7: nop
		IL_03c8: br.s IL_03f3

		IL_03ca: nop
		IL_03cb: ldarg.0
		IL_03cc: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_03d1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03d6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_03db: nop
		IL_03dc: ldarg.0
		IL_03dd: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_03e2: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03e7: ldstr "串口"
		IL_03ec: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_03f1: pop
		IL_03f2: nop

		IL_03f3: ldarg.0
		IL_03f4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_03f9: ldc.i4.0
		IL_03fa: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_03ff: nop
		IL_0400: ret
	} // end of method Form1::comboBoxModel_SelectedIndexChanged

	.method private hidebysig 
		instance void comboBoxSource_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6330
		// Header size: 12
		// Code size: 1027 (0x403)
		.maxstack 5
		.locals init (
			[0] class [mscorlib]System.Exception ee,
			[1] bool result,
			[2] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_0007: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_000c: ldc.i4.0
		IL_000d: ceq
		IL_000f: ldc.i4.0
		IL_0010: ceq
		IL_0012: stloc.2
		IL_0013: ldloc.2
		IL_0014: brtrue IL_01a7

		IL_0019: nop
		IL_001a: ldarg.0
		IL_001b: ldstr "磁通计"
		IL_0020: stfld string datapick.Form1::mashineType
		IL_0025: ldarg.0
		IL_0026: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_002b: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0030: ldc.i4.0
		IL_0031: ceq
		IL_0033: ldc.i4.0
		IL_0034: ceq
		IL_0036: stloc.2
		IL_0037: ldloc.2
		IL_0038: brtrue.s IL_0099

		IL_003a: nop
		IL_003b: ldarg.0
		IL_003c: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0041: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
		IL_0046: ldc.i4.0
		IL_0047: ceq
		IL_0049: stloc.2
		IL_004a: ldloc.2
		IL_004b: brtrue.s IL_006c

		IL_004d: nop
		IL_004e: ldarg.0
		IL_004f: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0054: ldstr "DATAC>"
		IL_0059: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
		IL_005e: nop
		IL_005f: ldarg.0
		IL_0060: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0065: callvirt instance void [System]System.IO.Ports.SerialPort::Close()
		IL_006a: nop
		IL_006b: nop
		.try
		{
			IL_006c: nop
			IL_006d: ldarg.0
			IL_006e: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0073: callvirt instance void [System]System.IO.Ports.SerialPort::Open()
			IL_0078: nop
			IL_0079: nop
			IL_007a: leave.s IL_0095
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_007c: stloc.0
			IL_007d: nop
			IL_007e: ldloc.0
			IL_007f: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_0084: ldstr "警告"
			IL_0089: ldc.i4.0
			IL_008a: ldc.i4.s 48
			IL_008c: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_0091: pop
			IL_0092: nop
			IL_0093: leave.s IL_0095
		} // end handler

		IL_0095: nop
		IL_0096: nop
		IL_0097: br.s IL_00ff

		IL_0099: ldarg.0
		IL_009a: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_009f: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_00a4: ldc.i4.1
		IL_00a5: ceq
		IL_00a7: ldc.i4.0
		IL_00a8: ceq
		IL_00aa: stloc.2
		IL_00ab: ldloc.2
		IL_00ac: brtrue.s IL_00ff

		IL_00ae: nop
		IL_00af: ldarg.0
		IL_00b0: ldfld int32 datapick.Form1::HidHandle
		IL_00b5: ldc.i4.m1
		IL_00b6: ceq
		IL_00b8: stloc.2
		IL_00b9: ldloc.2
		IL_00ba: brtrue.s IL_00fe

		IL_00bc: nop
		.try
		{
			IL_00bd: nop
			IL_00be: ldarg.0
			IL_00bf: ldc.i4.0
			IL_00c0: stfld bool datapick.Form1::Ready
			IL_00c5: ldarg.0
			IL_00c6: ldfld uint8[] datapick.Form1::senddata
			IL_00cb: ldc.i4.1
			IL_00cc: ldc.i4.s 18
			IL_00ce: stelem.i1
			IL_00cf: ldarg.0
			IL_00d0: ldfld int32 datapick.Form1::HidHandle
			IL_00d5: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_00da: ldarg.0
			IL_00db: ldfld uint8[] datapick.Form1::senddata
			IL_00e0: ldc.i4.s 17
			IL_00e2: ldarg.0
			IL_00e3: ldflda int32 datapick.Form1::USBwrite
			IL_00e8: ldarg.0
			IL_00e9: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
			IL_00ee: call bool datapick.Form1::WriteFile(native int, uint8[], int32, int32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_00f3: stloc.1
			IL_00f4: nop
			IL_00f5: leave.s IL_00fc
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_00f7: pop
			IL_00f8: nop
			IL_00f9: nop
			IL_00fa: leave.s IL_00fc
		} // end handler

		IL_00fc: nop
		IL_00fd: nop

		IL_00fe: nop

		IL_00ff: ldarg.0
		IL_0100: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0105: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_010a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_010f: nop
		IL_0110: ldarg.0
		IL_0111: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0116: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_011b: ldstr "mWb"
		IL_0120: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0125: pop
		IL_0126: ldarg.0
		IL_0127: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_012c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0131: ldstr "kMx"
		IL_0136: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_013b: pop
		IL_013c: ldarg.0
		IL_013d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0142: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0147: ldstr "mT"
		IL_014c: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0151: pop
		IL_0152: ldarg.0
		IL_0153: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0158: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_015d: ldstr "G"
		IL_0162: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0167: pop
		IL_0168: ldarg.0
		IL_0169: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_016e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0173: ldstr "A/m"
		IL_0178: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_017d: pop
		IL_017e: ldarg.0
		IL_017f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0184: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0189: ldstr "Oe"
		IL_018e: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0193: pop
		IL_0194: ldarg.0
		IL_0195: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_019a: ldc.i4.0
		IL_019b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_01a0: nop
		IL_01a1: nop
		IL_01a2: br IL_0402

		IL_01a7: ldarg.0
		IL_01a8: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_01ad: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_01b2: ldc.i4.1
		IL_01b3: ceq
		IL_01b5: ldc.i4.0
		IL_01b6: ceq
		IL_01b8: stloc.2
		IL_01b9: ldloc.2
		IL_01ba: brtrue IL_0321

		IL_01bf: nop
		IL_01c0: ldarg.0
		IL_01c1: ldstr "高斯计"
		IL_01c6: stfld string datapick.Form1::mashineType
		IL_01cb: ldarg.0
		IL_01cc: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_01d1: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_01d6: ldc.i4.0
		IL_01d7: ceq
		IL_01d9: ldc.i4.0
		IL_01da: ceq
		IL_01dc: stloc.2
		IL_01dd: ldloc.2
		IL_01de: brtrue.s IL_023f

		IL_01e0: nop
		IL_01e1: ldarg.0
		IL_01e2: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_01e7: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
		IL_01ec: ldc.i4.0
		IL_01ed: ceq
		IL_01ef: stloc.2
		IL_01f0: ldloc.2
		IL_01f1: brtrue.s IL_0212

		IL_01f3: nop
		IL_01f4: ldarg.0
		IL_01f5: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_01fa: ldstr "DATAC>"
		IL_01ff: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
		IL_0204: nop
		IL_0205: ldarg.0
		IL_0206: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_020b: callvirt instance void [System]System.IO.Ports.SerialPort::Close()
		IL_0210: nop
		IL_0211: nop
		.try
		{
			IL_0212: nop
			IL_0213: ldarg.0
			IL_0214: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0219: callvirt instance void [System]System.IO.Ports.SerialPort::Open()
			IL_021e: nop
			IL_021f: nop
			IL_0220: leave.s IL_023b
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_0222: stloc.0
			IL_0223: nop
			IL_0224: ldloc.0
			IL_0225: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_022a: ldstr "警告"
			IL_022f: ldc.i4.0
			IL_0230: ldc.i4.s 48
			IL_0232: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_0237: pop
			IL_0238: nop
			IL_0239: leave.s IL_023b
		} // end handler

		IL_023b: nop
		IL_023c: nop
		IL_023d: br.s IL_02a5

		IL_023f: ldarg.0
		IL_0240: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0245: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_024a: ldc.i4.1
		IL_024b: ceq
		IL_024d: ldc.i4.0
		IL_024e: ceq
		IL_0250: stloc.2
		IL_0251: ldloc.2
		IL_0252: brtrue.s IL_02a5

		IL_0254: nop
		IL_0255: ldarg.0
		IL_0256: ldfld int32 datapick.Form1::HidHandle
		IL_025b: ldc.i4.m1
		IL_025c: ceq
		IL_025e: stloc.2
		IL_025f: ldloc.2
		IL_0260: brtrue.s IL_02a4

		IL_0262: nop
		.try
		{
			IL_0263: nop
			IL_0264: ldarg.0
			IL_0265: ldc.i4.0
			IL_0266: stfld bool datapick.Form1::Ready
			IL_026b: ldarg.0
			IL_026c: ldfld uint8[] datapick.Form1::senddata
			IL_0271: ldc.i4.1
			IL_0272: ldc.i4.s 18
			IL_0274: stelem.i1
			IL_0275: ldarg.0
			IL_0276: ldfld int32 datapick.Form1::HidHandle
			IL_027b: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_0280: ldarg.0
			IL_0281: ldfld uint8[] datapick.Form1::senddata
			IL_0286: ldc.i4.s 17
			IL_0288: ldarg.0
			IL_0289: ldflda int32 datapick.Form1::USBwrite
			IL_028e: ldarg.0
			IL_028f: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
			IL_0294: call bool datapick.Form1::WriteFile(native int, uint8[], int32, int32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_0299: stloc.1
			IL_029a: nop
			IL_029b: leave.s IL_02a2
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_029d: pop
			IL_029e: nop
			IL_029f: nop
			IL_02a0: leave.s IL_02a2
		} // end handler

		IL_02a2: nop
		IL_02a3: nop

		IL_02a4: nop

		IL_02a5: ldarg.0
		IL_02a6: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_02ab: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_02b0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_02b5: nop
		IL_02b6: ldarg.0
		IL_02b7: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_02bc: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_02c1: ldstr "mT"
		IL_02c6: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_02cb: pop
		IL_02cc: ldarg.0
		IL_02cd: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_02d2: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_02d7: ldstr "G"
		IL_02dc: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_02e1: pop
		IL_02e2: ldarg.0
		IL_02e3: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_02e8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_02ed: ldstr "A/m"
		IL_02f2: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_02f7: pop
		IL_02f8: ldarg.0
		IL_02f9: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_02fe: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0303: ldstr "Oe"
		IL_0308: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_030d: pop
		IL_030e: ldarg.0
		IL_030f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0314: ldc.i4.0
		IL_0315: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_031a: nop
		IL_031b: nop
		IL_031c: br IL_0402

		IL_0321: ldarg.0
		IL_0322: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_0327: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_032c: ldc.i4.2
		IL_032d: ceq
		IL_032f: ldc.i4.0
		IL_0330: ceq
		IL_0332: stloc.2
		IL_0333: ldloc.2
		IL_0334: brtrue IL_0402

		IL_0339: nop
		IL_033a: ldarg.0
		IL_033b: ldstr "高斯计"
		IL_0340: stfld string datapick.Form1::mashineType
		IL_0345: ldarg.0
		IL_0346: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_034b: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0350: ldc.i4.0
		IL_0351: ceq
		IL_0353: ldc.i4.0
		IL_0354: ceq
		IL_0356: stloc.2
		IL_0357: ldloc.2
		IL_0358: brtrue.s IL_03b7

		IL_035a: nop
		IL_035b: ldarg.0
		IL_035c: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0361: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
		IL_0366: ldc.i4.0
		IL_0367: ceq
		IL_0369: stloc.2
		IL_036a: ldloc.2
		IL_036b: brtrue.s IL_038c

		IL_036d: nop
		IL_036e: ldarg.0
		IL_036f: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0374: ldstr "DATAC>"
		IL_0379: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
		IL_037e: nop
		IL_037f: ldarg.0
		IL_0380: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0385: callvirt instance void [System]System.IO.Ports.SerialPort::Close()
		IL_038a: nop
		IL_038b: nop
		.try
		{
			IL_038c: nop
			IL_038d: ldarg.0
			IL_038e: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0393: callvirt instance void [System]System.IO.Ports.SerialPort::Open()
			IL_0398: nop
			IL_0399: nop
			IL_039a: leave.s IL_03b5
		} // end .try
		catch [mscorlib]System.Exception
		{
			IL_039c: stloc.0
			IL_039d: nop
			IL_039e: ldloc.0
			IL_039f: callvirt instance string [mscorlib]System.Exception::get_Message()
			IL_03a4: ldstr "警告"
			IL_03a9: ldc.i4.0
			IL_03aa: ldc.i4.s 48
			IL_03ac: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_03b1: pop
			IL_03b2: nop
			IL_03b3: leave.s IL_03b5
		} // end handler

		IL_03b5: nop
		IL_03b6: nop

		IL_03b7: ldarg.0
		IL_03b8: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_03bd: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03c2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_03c7: nop
		IL_03c8: ldarg.0
		IL_03c9: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_03ce: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03d3: ldstr "μT"
		IL_03d8: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_03dd: pop
		IL_03de: ldarg.0
		IL_03df: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_03e4: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_03e9: ldstr "mG"
		IL_03ee: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_03f3: pop
		IL_03f4: ldarg.0
		IL_03f5: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_03fa: ldc.i4.0
		IL_03fb: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_0400: nop
		IL_0401: nop

		IL_0402: ret
	} // end of method Form1::comboBoxSource_SelectedIndexChanged

	.method private hidebysig 
		instance void comboBoxDataType_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6780
		// Header size: 12
		// Code size: 453 (0x1c5)
		.maxstack 4
		.locals init (
			[0] valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult ettr,
			[1] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarg.1
		IL_0003: ldarg.2
		IL_0004: call instance void datapick.Form1::buttonSTOP_Click(object, class [mscorlib]System.EventArgs)
		IL_0009: nop
		IL_000a: ldarg.0
		IL_000b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0010: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0015: callvirt instance string [mscorlib]System.Object::ToString()
		IL_001a: ldstr "普通数据"
		IL_001f: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0024: ldc.i4.0
		IL_0025: ceq
		IL_0027: stloc.1
		IL_0028: ldloc.1
		IL_0029: brtrue.s IL_007a

		IL_002b: nop
		IL_002c: ldarg.0
		IL_002d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0032: ldc.i4.0
		IL_0033: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0038: nop
		IL_0039: ldarg.0
		IL_003a: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_003f: ldc.i4.1
		IL_0040: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0045: nop
		IL_0046: ldarg.0
		IL_0047: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_004c: ldc.i4.1
		IL_004d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0052: nop
		IL_0053: ldarg.0
		IL_0054: ldc.i4.1
		IL_0055: stfld int32 datapick.Form1::DataType_flag
		IL_005a: ldarg.0
		IL_005b: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerTIME
		IL_0060: ldc.i4.s 100
		IL_0062: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_0067: nop
		IL_0068: ldarg.0
		IL_0069: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_006e: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::Clear()
		IL_0073: nop
		IL_0074: nop
		IL_0075: br IL_01c4

		IL_007a: ldarg.0
		IL_007b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0080: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0085: callvirt instance string [mscorlib]System.Object::ToString()
		IL_008a: ldstr "高速数据"
		IL_008f: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0094: ldc.i4.0
		IL_0095: ceq
		IL_0097: stloc.1
		IL_0098: ldloc.1
		IL_0099: brtrue.s IL_00ec

		IL_009b: nop
		IL_009c: ldarg.0
		IL_009d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_00a2: ldc.i4.1
		IL_00a3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_00a8: nop
		IL_00a9: ldarg.0
		IL_00aa: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_00af: ldc.i4.0
		IL_00b0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_00b5: nop
		IL_00b6: ldarg.0
		IL_00b7: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_00bc: ldc.i4.1
		IL_00bd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_00c2: nop
		IL_00c3: ldarg.0
		IL_00c4: ldc.i4.2
		IL_00c5: stfld int32 datapick.Form1::DataType_flag
		IL_00ca: ldarg.0
		IL_00cb: ldc.i4.0
		IL_00cc: stfld bool datapick.Form1::Ready
		IL_00d1: ldarg.0
		IL_00d2: ldc.i4.0
		IL_00d3: stfld bool datapick.Form1::listadd
		IL_00d8: ldarg.0
		IL_00d9: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerTIME
		IL_00de: ldc.i4.s 10
		IL_00e0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_00e5: nop
		IL_00e6: nop
		IL_00e7: br IL_01c4

		IL_00ec: ldarg.0
		IL_00ed: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_00f2: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_00f7: callvirt instance string [mscorlib]System.Object::ToString()
		IL_00fc: ldstr "历史数据"
		IL_0101: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0106: ldc.i4.0
		IL_0107: ceq
		IL_0109: stloc.1
		IL_010a: ldloc.1
		IL_010b: brtrue IL_01c4

		IL_0110: nop
		IL_0111: ldarg.0
		IL_0112: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerTIME
		IL_0117: ldc.i4.s 100
		IL_0119: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_011e: nop
		IL_011f: ldarg.0
		IL_0120: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0125: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_012a: ldc.i4.0
		IL_012b: ceq
		IL_012d: ldc.i4.0
		IL_012e: ceq
		IL_0130: stloc.1
		IL_0131: ldloc.1
		IL_0132: brtrue IL_01c3

		IL_0137: nop
		IL_0138: ldstr "请首先确认串口号与波特率设置正确，\r\n操作高斯计/磁通计，使用UART中的Transmit Saved功能，\r\n此过程需要大约25秒......"
		IL_013d: ldstr "提示"
		IL_0142: ldc.i4.1
		IL_0143: ldc.i4.s 32
		IL_0145: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
		IL_014a: stloc.0
		IL_014b: ldloc.0
		IL_014c: ldc.i4.1
		IL_014d: ceq
		IL_014f: ldc.i4.0
		IL_0150: ceq
		IL_0152: stloc.1
		IL_0153: ldloc.1
		IL_0154: brtrue.s IL_01b2

		IL_0156: nop
		IL_0157: ldarg.0
		IL_0158: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_015d: ldc.i4 20000
		IL_0162: callvirt instance void [System]System.IO.Ports.SerialPort::set_ReceivedBytesThreshold(int32)
		IL_0167: nop
		IL_0168: ldarg.0
		IL_0169: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_016e: ldc.i4.0
		IL_016f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0174: nop
		IL_0175: ldarg.0
		IL_0176: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_017b: ldc.i4.0
		IL_017c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0181: nop
		IL_0182: ldarg.0
		IL_0183: ldc.i4.3
		IL_0184: stfld int32 datapick.Form1::DataType_flag
		IL_0189: ldarg.0
		IL_018a: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_018f: callvirt instance bool [System.Windows.Forms]System.Windows.Forms.Control::Focus()
		IL_0194: pop
		IL_0195: ldarg.0
		IL_0196: ldfld class datapick.tishi datapick.Form1::ts
		IL_019b: callvirt instance valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.Form::ShowDialog()
		IL_01a0: pop
		IL_01a1: ldarg.0
		IL_01a2: ldc.i4.0
		IL_01a3: stfld bool datapick.Form1::Ready
		IL_01a8: ldarg.0
		IL_01a9: ldc.i4.0
		IL_01aa: stfld bool datapick.Form1::listadd
		IL_01af: nop
		IL_01b0: br.s IL_01c2

		IL_01b2: nop
		IL_01b3: ldarg.0
		IL_01b4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_01b9: ldc.i4.0
		IL_01ba: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_01bf: nop
		IL_01c0: br.s IL_01c4

		IL_01c2: nop

		IL_01c3: nop

		IL_01c4: ret
	} // end of method Form1::comboBoxDataType_SelectedIndexChanged

	.method private hidebysig 
		instance void comboBoxSpeed_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6954
		// Header size: 12
		// Code size: 425 (0x1a9)
		.maxstack 3
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarg.1
		IL_0003: ldarg.2
		IL_0004: call instance void datapick.Form1::buttonSTOP_Click(object, class [mscorlib]System.EventArgs)
		IL_0009: nop
		IL_000a: ldarg.0
		IL_000b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0010: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0015: callvirt instance string [mscorlib]System.Object::ToString()
		IL_001a: ldstr "50组/s"
		IL_001f: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0024: ldc.i4.0
		IL_0025: ceq
		IL_0027: stloc.0
		IL_0028: ldloc.0
		IL_0029: brtrue.s IL_0045

		IL_002b: nop
		IL_002c: ldarg.0
		IL_002d: ldstr "FAST050>"
		IL_0032: stfld string datapick.Form1::Speed
		IL_0037: ldarg.0
		IL_0038: ldc.i4.s 50
		IL_003a: stfld int32 datapick.Form1::HighSpeedNO
		IL_003f: nop
		IL_0040: br IL_01a8

		IL_0045: ldarg.0
		IL_0046: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_004b: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0050: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0055: ldstr "20组/s"
		IL_005a: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_005f: ldc.i4.0
		IL_0060: ceq
		IL_0062: stloc.0
		IL_0063: ldloc.0
		IL_0064: brtrue.s IL_0080

		IL_0066: nop
		IL_0067: ldarg.0
		IL_0068: ldstr "FAST2>"
		IL_006d: stfld string datapick.Form1::Speed
		IL_0072: ldarg.0
		IL_0073: ldc.i4.s 20
		IL_0075: stfld int32 datapick.Form1::HighSpeedNO
		IL_007a: nop
		IL_007b: br IL_01a8

		IL_0080: ldarg.0
		IL_0081: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0086: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_008b: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0090: ldstr "100组/s"
		IL_0095: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_009a: ldc.i4.0
		IL_009b: ceq
		IL_009d: stloc.0
		IL_009e: ldloc.0
		IL_009f: brtrue.s IL_00bb

		IL_00a1: nop
		IL_00a2: ldarg.0
		IL_00a3: ldstr "FAST100>"
		IL_00a8: stfld string datapick.Form1::Speed
		IL_00ad: ldarg.0
		IL_00ae: ldc.i4.s 100
		IL_00b0: stfld int32 datapick.Form1::HighSpeedNO
		IL_00b5: nop
		IL_00b6: br IL_01a8

		IL_00bb: ldarg.0
		IL_00bc: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_00c1: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_00c6: callvirt instance string [mscorlib]System.Object::ToString()
		IL_00cb: ldstr "150组/s"
		IL_00d0: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00d5: ldc.i4.0
		IL_00d6: ceq
		IL_00d8: stloc.0
		IL_00d9: ldloc.0
		IL_00da: brtrue.s IL_00f9

		IL_00dc: nop
		IL_00dd: ldarg.0
		IL_00de: ldstr "FAST150>"
		IL_00e3: stfld string datapick.Form1::Speed
		IL_00e8: ldarg.0
		IL_00e9: ldc.i4 150
		IL_00ee: stfld int32 datapick.Form1::HighSpeedNO
		IL_00f3: nop
		IL_00f4: br IL_01a8

		IL_00f9: ldarg.0
		IL_00fa: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_00ff: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0104: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0109: ldstr "200组/s"
		IL_010e: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0113: ldc.i4.0
		IL_0114: ceq
		IL_0116: stloc.0
		IL_0117: ldloc.0
		IL_0118: brtrue.s IL_0134

		IL_011a: nop
		IL_011b: ldarg.0
		IL_011c: ldstr "FAST200>"
		IL_0121: stfld string datapick.Form1::Speed
		IL_0126: ldarg.0
		IL_0127: ldc.i4 200
		IL_012c: stfld int32 datapick.Form1::HighSpeedNO
		IL_0131: nop
		IL_0132: br.s IL_01a8

		IL_0134: ldarg.0
		IL_0135: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_013a: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_013f: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0144: ldstr "250组/s"
		IL_0149: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_014e: ldc.i4.0
		IL_014f: ceq
		IL_0151: stloc.0
		IL_0152: ldloc.0
		IL_0153: brtrue.s IL_016f

		IL_0155: nop
		IL_0156: ldarg.0
		IL_0157: ldstr "FAST250>"
		IL_015c: stfld string datapick.Form1::Speed
		IL_0161: ldarg.0
		IL_0162: ldc.i4 250
		IL_0167: stfld int32 datapick.Form1::HighSpeedNO
		IL_016c: nop
		IL_016d: br.s IL_01a8

		IL_016f: ldarg.0
		IL_0170: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0175: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_017a: callvirt instance string [mscorlib]System.Object::ToString()
		IL_017f: ldstr "300组/s"
		IL_0184: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0189: ldc.i4.0
		IL_018a: ceq
		IL_018c: stloc.0
		IL_018d: ldloc.0
		IL_018e: brtrue.s IL_01a8

		IL_0190: nop
		IL_0191: ldarg.0
		IL_0192: ldstr "FAST300>"
		IL_0197: stfld string datapick.Form1::Speed
		IL_019c: ldarg.0
		IL_019d: ldc.i4 300
		IL_01a2: stfld int32 datapick.Form1::HighSpeedNO
		IL_01a7: nop

		IL_01a8: ret
	} // end of method Form1::comboBoxSpeed_SelectedIndexChanged

	.method private hidebysig 
		instance void comboBoxT_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6b0c
		// Header size: 12
		// Code size: 90 (0x5a)
		.maxstack 3
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_0007: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_000c: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0011: ldstr "默认"
		IL_0016: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_001b: ldc.i4.0
		IL_001c: ceq
		IL_001e: stloc.0
		IL_001f: ldloc.0
		IL_0020: brtrue.s IL_0032

		IL_0022: ldarg.0
		IL_0023: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_0028: ldc.i4.s 20
		IL_002a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_002f: nop
		IL_0030: br.s IL_0059

		IL_0032: ldarg.0
		IL_0033: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_0038: ldarg.0
		IL_0039: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_003e: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0043: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0048: call int32 [mscorlib]System.Convert::ToInt32(string)
		IL_004d: ldc.i4 1000
		IL_0052: mul
		IL_0053: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_0058: nop

		IL_0059: ret
	} // end of method Form1::comboBoxT_SelectedIndexChanged

	.method private hidebysig 
		instance void timer1_Tick (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6b72
		// Header size: 1
		// Code size: 9 (0x9)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldc.i4.1
		IL_0003: stfld bool datapick.Form1::boolDisplayData
		IL_0008: ret
	} // end of method Form1::timer1_Tick

	.method private hidebysig 
		instance void WriteSystemConfig () cil managed 
	{
		// Method begins at RVA 0x6b7c
		// Header size: 12
		// Code size: 164 (0xa4)
		.maxstack 2

		IL_0000: nop
		IL_0001: ldstr "MODEL"
		IL_0006: ldarg.0
		IL_0007: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_000c: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0011: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0016: call bool datapick.SystemConfig::WriteConfigData(string, string)
		IL_001b: pop
		IL_001c: ldstr "COMWAY"
		IL_0021: ldarg.0
		IL_0022: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0027: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_002c: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0031: call bool datapick.SystemConfig::WriteConfigData(string, string)
		IL_0036: pop
		IL_0037: ldstr "COMMSET"
		IL_003c: ldarg.0
		IL_003d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0042: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0047: callvirt instance string [mscorlib]System.Object::ToString()
		IL_004c: call bool datapick.SystemConfig::WriteConfigData(string, string)
		IL_0051: pop
		IL_0052: ldstr "BADURATE"
		IL_0057: ldarg.0
		IL_0058: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_005d: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0062: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0067: call bool datapick.SystemConfig::WriteConfigData(string, string)
		IL_006c: pop
		IL_006d: ldstr "DATATYPE"
		IL_0072: ldarg.0
		IL_0073: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0078: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_007d: callvirt instance string [mscorlib]System.Object::ToString()
		IL_0082: call bool datapick.SystemConfig::WriteConfigData(string, string)
		IL_0087: pop
		IL_0088: ldstr "SPEED"
		IL_008d: ldarg.0
		IL_008e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0093: callvirt instance object [System.Windows.Forms]System.Windows.Forms.ComboBox::get_SelectedItem()
		IL_0098: callvirt instance string [mscorlib]System.Object::ToString()
		IL_009d: call bool datapick.SystemConfig::WriteConfigData(string, string)
		IL_00a2: pop
		IL_00a3: ret
	} // end of method Form1::WriteSystemConfig

	.method private hidebysig 
		instance void Form1_FormClosing (
			object sender,
			class [System.Windows.Forms]System.Windows.Forms.FormClosingEventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6c2c
		// Header size: 12
		// Code size: 200 (0xc8)
		.maxstack 5
		.locals init (
			[0] bool result,
			[1] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: call instance void datapick.Form1::WriteSystemConfig()
		IL_0007: nop
		IL_0008: ldarg.0
		IL_0009: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_000e: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0013: ldc.i4.0
		IL_0014: ceq
		IL_0016: ldc.i4.0
		IL_0017: ceq
		IL_0019: stloc.1
		IL_001a: ldloc.1
		IL_001b: brtrue.s IL_005c

		IL_001d: nop
		IL_001e: ldarg.0
		IL_001f: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_0024: callvirt instance bool [System]System.IO.Ports.SerialPort::get_IsOpen()
		IL_0029: ldc.i4.0
		IL_002a: ceq
		IL_002c: stloc.1
		IL_002d: ldloc.1
		IL_002e: brtrue.s IL_0059

		IL_0030: nop
		.try
		{
			IL_0031: nop
			IL_0032: ldarg.0
			IL_0033: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0038: ldstr "DATAC>"
			IL_003d: callvirt instance void [System]System.IO.Ports.SerialPort::Write(string)
			IL_0042: nop
			IL_0043: ldarg.0
			IL_0044: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
			IL_0049: callvirt instance void [System]System.IO.Ports.SerialPort::Close()
			IL_004e: nop
			IL_004f: nop
			IL_0050: leave.s IL_0057
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0052: pop
			IL_0053: nop
			IL_0054: nop
			IL_0055: leave.s IL_0057
		} // end handler

		IL_0057: nop
		IL_0058: nop

		IL_0059: nop
		IL_005a: br.s IL_00c7

		IL_005c: ldarg.0
		IL_005d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0062: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0067: ldc.i4.1
		IL_0068: ceq
		IL_006a: ldc.i4.0
		IL_006b: ceq
		IL_006d: stloc.1
		IL_006e: ldloc.1
		IL_006f: brtrue.s IL_00c7

		IL_0071: nop
		IL_0072: ldarg.0
		IL_0073: ldfld int32 datapick.Form1::HidHandle
		IL_0078: ldc.i4.m1
		IL_0079: ceq
		IL_007b: stloc.1
		IL_007c: ldloc.1
		IL_007d: brtrue.s IL_00c6

		IL_007f: nop
		.try
		{
			IL_0080: nop
			IL_0081: ldarg.0
			IL_0082: ldfld uint8[] datapick.Form1::senddata
			IL_0087: ldc.i4.1
			IL_0088: ldc.i4.s 18
			IL_008a: stelem.i1
			IL_008b: ldarg.0
			IL_008c: ldfld int32 datapick.Form1::HidHandle
			IL_0091: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_0096: ldarg.0
			IL_0097: ldfld uint8[] datapick.Form1::senddata
			IL_009c: ldc.i4.s 17
			IL_009e: ldarg.0
			IL_009f: ldflda int32 datapick.Form1::USBwrite
			IL_00a4: ldarg.0
			IL_00a5: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovSEND
			IL_00aa: call bool datapick.Form1::WriteFile(native int, uint8[], int32, int32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_00af: stloc.0
			IL_00b0: ldarg.0
			IL_00b1: ldfld int32 datapick.Form1::HidHandle
			IL_00b6: call int32 datapick.Form1::CloseHandle(int32)
			IL_00bb: pop
			IL_00bc: nop
			IL_00bd: leave.s IL_00c4
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_00bf: pop
			IL_00c0: nop
			IL_00c1: nop
			IL_00c2: leave.s IL_00c4
		} // end handler

		IL_00c4: nop
		IL_00c5: nop

		IL_00c6: nop

		IL_00c7: ret
	} // end of method Form1::Form1_FormClosing

	.method private hidebysig 
		instance void comboBoxfangshi_SelectedIndexChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x6d1c
		// Header size: 12
		// Code size: 889 (0x379)
		.maxstack 8
		.locals init (
			[0] int32 bufferSize,
			[1] int32 index,
			[2] valuetype datapick.Form1/SP_DEVICE_INTERFACE_DATA DeviceInterfaceData,
			[3] bool result,
			[4] class datapick.Form1/SP_DEVINFO_DATA strtInterfaceData,
			[5] native int detailDataBuffer,
			[6] valuetype datapick.Form1/SP_DEVICE_INTERFACE_DETAIL_DATA detailData,
			[7] native int pdevicePathName,
			[8] string devicePathName,
			[9] valuetype datapick.Form1/HIDD_ATTRIBUTES hidDeviceAttributes,
			[10] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarg.1
		IL_0003: ldarg.2
		IL_0004: call instance void datapick.Form1::buttonSTOP_Click(object, class [mscorlib]System.EventArgs)
		IL_0009: nop
		IL_000a: ldarg.0
		IL_000b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0010: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_0015: ldc.i4.0
		IL_0016: ceq
		IL_0018: ldc.i4.0
		IL_0019: ceq
		IL_001b: stloc.s 10
		IL_001d: ldloc.s 10
		IL_001f: brtrue IL_0171

		IL_0024: nop
		IL_0025: ldarg.0
		IL_0026: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_002b: ldc.i4.1
		IL_002c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0031: nop
		IL_0032: ldarg.0
		IL_0033: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0038: ldc.i4.1
		IL_0039: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_003e: nop
		IL_003f: ldarg.0
		IL_0040: ldfld string datapick.Form1::MODEL
		IL_0045: ldstr "CH-260"
		IL_004a: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_004f: brtrue.s IL_00c0

		IL_0051: ldarg.0
		IL_0052: ldfld string datapick.Form1::MODEL
		IL_0057: ldstr "CH-1300"
		IL_005c: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0061: brtrue.s IL_00c0

		IL_0063: ldarg.0
		IL_0064: ldfld string datapick.Form1::MODEL
		IL_0069: ldstr "CH-290"
		IL_006e: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0073: brtrue.s IL_00c0

		IL_0075: ldarg.0
		IL_0076: ldfld string datapick.Form1::MODEL
		IL_007b: ldstr "CH-260磁通手动"
		IL_0080: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0085: brtrue.s IL_00c0

		IL_0087: ldarg.0
		IL_0088: ldfld string datapick.Form1::MODEL
		IL_008d: ldstr "CH-290磁通手动"
		IL_0092: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0097: brtrue.s IL_00c0

		IL_0099: ldarg.0
		IL_009a: ldfld string datapick.Form1::MODEL
		IL_009f: ldstr "CH-260磁强手动"
		IL_00a4: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00a9: brtrue.s IL_00c0

		IL_00ab: ldarg.0
		IL_00ac: ldfld string datapick.Form1::MODEL
		IL_00b1: ldstr "CH-290磁强手动"
		IL_00b6: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_00bb: ldc.i4.0
		IL_00bc: ceq
		IL_00be: br.s IL_00c1

		IL_00c0: ldc.i4.0

		IL_00c1: nop
		IL_00c2: stloc.s 10
		IL_00c4: ldloc.s 10
		IL_00c6: brtrue.s IL_0109

		IL_00c8: nop
		IL_00c9: ldarg.0
		IL_00ca: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_00cf: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_00d4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_00d9: nop
		IL_00da: ldarg.0
		IL_00db: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_00e0: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_00e5: ldstr "普通数据"
		IL_00ea: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_00ef: pop
		IL_00f0: ldarg.0
		IL_00f1: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_00f6: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_00fb: ldstr "历史数据"
		IL_0100: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0105: pop
		IL_0106: nop
		IL_0107: br.s IL_015e

		IL_0109: nop
		IL_010a: ldarg.0
		IL_010b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0110: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0115: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_011a: nop
		IL_011b: ldarg.0
		IL_011c: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0121: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0126: ldstr "普通数据"
		IL_012b: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0130: pop
		IL_0131: ldarg.0
		IL_0132: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0137: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_013c: ldstr "高速数据"
		IL_0141: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_0146: pop
		IL_0147: ldarg.0
		IL_0148: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_014d: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0152: ldstr "历史数据"
		IL_0157: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_015c: pop
		IL_015d: nop

		IL_015e: ldarg.0
		IL_015f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0164: ldc.i4.0
		IL_0165: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_016a: nop
		IL_016b: nop
		IL_016c: br IL_0378

		IL_0171: ldarg.0
		IL_0172: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0177: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ListControl::get_SelectedIndex()
		IL_017c: ldc.i4.1
		IL_017d: ceq
		IL_017f: ldc.i4.0
		IL_0180: ceq
		IL_0182: stloc.s 10
		IL_0184: ldloc.s 10
		IL_0186: brtrue IL_0378

		IL_018b: nop
		IL_018c: ldarg.0
		IL_018d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0192: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0197: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_019c: nop
		IL_019d: ldarg.0
		IL_019e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_01a3: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_01a8: ldstr "普通数据"
		IL_01ad: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Add(object)
		IL_01b2: pop
		IL_01b3: ldarg.0
		IL_01b4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_01b9: ldc.i4.0
		IL_01ba: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_01bf: nop
		IL_01c0: ldarg.0
		IL_01c1: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_01c6: ldc.i4.0
		IL_01c7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_01cc: nop
		IL_01cd: ldarg.0
		IL_01ce: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_01d3: ldc.i4.0
		IL_01d4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_01d9: nop
		IL_01da: ldarg.0
		IL_01db: ldflda valuetype [mscorlib]System.Guid datapick.Form1::guidHID
		IL_01e0: call void datapick.Form1::HidD_GetHidGuid(valuetype [mscorlib]System.Guid&)
		IL_01e5: nop
		IL_01e6: ldarg.0
		IL_01e7: ldarg.0
		IL_01e8: ldflda valuetype [mscorlib]System.Guid datapick.Form1::guidHID
		IL_01ed: ldc.i4.0
		IL_01ee: ldsfld native int [mscorlib]System.IntPtr::Zero
		IL_01f3: ldc.i4.s 18
		IL_01f5: call native int datapick.Form1::SetupDiGetClassDevs(valuetype [mscorlib]System.Guid&, uint32, native int, valuetype datapick.Form1/DIGCF)
		IL_01fa: stfld native int datapick.Form1::hDevInfo
		IL_01ff: ldc.i4.0
		IL_0200: stloc.0
		IL_0201: ldc.i4.0
		IL_0202: stloc.1
		IL_0203: br IL_0370
		// loop start (head: IL_0370)
			IL_0208: nop
			IL_0209: ldloca.s 2
			IL_020b: initobj datapick.Form1/SP_DEVICE_INTERFACE_DATA
			IL_0211: ldloca.s 2
			IL_0213: ldloc.2
			IL_0214: box datapick.Form1/SP_DEVICE_INTERFACE_DATA
			IL_0219: call int32 [mscorlib]System.Runtime.InteropServices.Marshal::SizeOf(object)
			IL_021e: stfld int32 datapick.Form1/SP_DEVICE_INTERFACE_DATA::cbSize
			IL_0223: ldarg.0
			IL_0224: ldfld native int datapick.Form1::hDevInfo
			IL_0229: ldsfld native int [mscorlib]System.IntPtr::Zero
			IL_022e: ldarg.0
			IL_022f: ldflda valuetype [mscorlib]System.Guid datapick.Form1::guidHID
			IL_0234: ldloc.1
			IL_0235: ldloca.s 2
			IL_0237: call bool datapick.Form1::SetupDiEnumDeviceInterfaces(native int, native int, valuetype [mscorlib]System.Guid&, uint32, valuetype datapick.Form1/SP_DEVICE_INTERFACE_DATA&)
			IL_023c: stloc.3
			IL_023d: ldloc.1
			IL_023e: ldc.i4.1
			IL_023f: add
			IL_0240: stloc.1
			IL_0241: newobj instance void datapick.Form1/SP_DEVINFO_DATA::.ctor()
			IL_0246: stloc.s 4
			IL_0248: ldarg.0
			IL_0249: ldfld native int datapick.Form1::hDevInfo
			IL_024e: ldloca.s 2
			IL_0250: ldsfld native int [mscorlib]System.IntPtr::Zero
			IL_0255: ldc.i4.0
			IL_0256: ldloca.s 0
			IL_0258: ldloc.s 4
			IL_025a: call bool datapick.Form1::SetupDiGetDeviceInterfaceDetail(native int, valuetype datapick.Form1/SP_DEVICE_INTERFACE_DATA&, native int, int32, int32&, class datapick.Form1/SP_DEVINFO_DATA)
			IL_025f: stloc.3
			IL_0260: ldloc.0
			IL_0261: call native int [mscorlib]System.Runtime.InteropServices.Marshal::AllocHGlobal(int32)
			IL_0266: stloc.s 5
			IL_0268: ldloca.s 6
			IL_026a: initobj datapick.Form1/SP_DEVICE_INTERFACE_DETAIL_DATA
			IL_0270: ldloca.s 6
			IL_0272: ldtoken datapick.Form1/SP_DEVICE_INTERFACE_DETAIL_DATA
			IL_0277: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_027c: call int32 [mscorlib]System.Runtime.InteropServices.Marshal::SizeOf(class [mscorlib]System.Type)
			IL_0281: stfld int32 datapick.Form1/SP_DEVICE_INTERFACE_DETAIL_DATA::cbSize
			IL_0286: ldloc.s 6
			IL_0288: box datapick.Form1/SP_DEVICE_INTERFACE_DETAIL_DATA
			IL_028d: ldloc.s 5
			IL_028f: ldc.i4.0
			IL_0290: call void [mscorlib]System.Runtime.InteropServices.Marshal::StructureToPtr(object, native int, bool)
			IL_0295: nop
			IL_0296: ldarg.0
			IL_0297: ldfld native int datapick.Form1::hDevInfo
			IL_029c: ldloca.s 2
			IL_029e: ldloc.s 5
			IL_02a0: ldloc.0
			IL_02a1: ldloca.s 0
			IL_02a3: ldloc.s 4
			IL_02a5: call bool datapick.Form1::SetupDiGetDeviceInterfaceDetail(native int, valuetype datapick.Form1/SP_DEVICE_INTERFACE_DATA&, native int, int32, int32&, class datapick.Form1/SP_DEVINFO_DATA)
			IL_02aa: stloc.3
			IL_02ab: ldloc.s 5
			IL_02ad: call int32 [mscorlib]System.IntPtr::op_Explicit(native int)
			IL_02b2: ldc.i4.4
			IL_02b3: add
			IL_02b4: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_02b9: stloc.s 7
			IL_02bb: ldloc.s 7
			IL_02bd: call string [mscorlib]System.Runtime.InteropServices.Marshal::PtrToStringAuto(native int)
			IL_02c2: stloc.s 8
			IL_02c4: ldarg.0
			IL_02c5: ldloc.s 8
			IL_02c7: ldc.i4 -1073741824
			IL_02cc: ldc.i4.3
			IL_02cd: ldc.i4.0
			IL_02ce: ldc.i4.3
			IL_02cf: ldc.i4 1073741824
			IL_02d4: ldc.i4.0
			IL_02d5: call int32 datapick.Form1::CreateFile(string, uint32, uint32, uint32, uint32, uint32, uint32)
			IL_02da: stfld int32 datapick.Form1::HidHandle
			IL_02df: ldarg.0
			IL_02e0: ldfld int32 datapick.Form1::HidHandle
			IL_02e5: ldc.i4.m1
			IL_02e6: ceq
			IL_02e8: stloc.s 10
			IL_02ea: ldloc.s 10
			IL_02ec: brtrue.s IL_0348

			IL_02ee: nop
			IL_02ef: ldloca.s 9
			IL_02f1: initobj datapick.Form1/HIDD_ATTRIBUTES
			IL_02f7: ldloca.s 9
			IL_02f9: ldtoken datapick.Form1/HIDD_ATTRIBUTES
			IL_02fe: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_0303: call int32 [mscorlib]System.Runtime.InteropServices.Marshal::SizeOf(class [mscorlib]System.Type)
			IL_0308: stfld int32 datapick.Form1/HIDD_ATTRIBUTES::Size
			IL_030d: ldarg.0
			IL_030e: ldfld int32 datapick.Form1::HidHandle
			IL_0313: ldloca.s 9
			IL_0315: call bool datapick.Form1::HidD_GetAttributes(int32, valuetype datapick.Form1/HIDD_ATTRIBUTES&)
			IL_031a: stloc.3
			IL_031b: ldloca.s 9
			IL_031d: ldfld uint16 datapick.Form1/HIDD_ATTRIBUTES::ProductID
			IL_0322: ldc.i4 22352
			IL_0327: bne.un.s IL_033c

			IL_0329: ldloca.s 9
			IL_032b: ldfld uint16 datapick.Form1/HIDD_ATTRIBUTES::VendorID
			IL_0330: ldc.i4 1155
			IL_0335: ceq
			IL_0337: ldc.i4.0
			IL_0338: ceq
			IL_033a: br.s IL_033d

			IL_033c: ldc.i4.1

			IL_033d: nop
			IL_033e: stloc.s 10
			IL_0340: ldloc.s 10
			IL_0342: brtrue.s IL_0347

			IL_0344: nop
			IL_0345: br.s IL_0378

			IL_0347: nop

			IL_0348: ldloc.1
			IL_0349: ldc.i4 1000
			IL_034e: ceq
			IL_0350: ldc.i4.0
			IL_0351: ceq
			IL_0353: stloc.s 10
			IL_0355: ldloc.s 10
			IL_0357: brtrue.s IL_036f

			IL_0359: nop
			IL_035a: ldstr "查找USB设备失败!"
			IL_035f: ldstr "提示"
			IL_0364: ldc.i4.0
			IL_0365: ldc.i4.s 64
			IL_0367: call valuetype [System.Windows.Forms]System.Windows.Forms.DialogResult [System.Windows.Forms]System.Windows.Forms.MessageBox::Show(string, string, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxButtons, valuetype [System.Windows.Forms]System.Windows.Forms.MessageBoxIcon)
			IL_036c: pop
			IL_036d: br.s IL_0378

			IL_036f: nop

			IL_0370: ldc.i4.1
			IL_0371: stloc.s 10
			IL_0373: br IL_0208
		// end loop

		IL_0378: ret
	} // end of method Form1::comboBoxfangshi_SelectedIndexChanged

	.method private hidebysig 
		instance void timerRecieve_Tick (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x70a1
		// Header size: 1
		// Code size: 37 (0x25)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarg.0
		IL_0003: ldftn instance void datapick.Form1::readUSBdata()
		IL_0009: newobj instance void [mscorlib]System.Threading.ThreadStart::.ctor(object, native int)
		IL_000e: newobj instance void [mscorlib]System.Threading.Thread::.ctor(class [mscorlib]System.Threading.ThreadStart)
		IL_0013: stfld class [mscorlib]System.Threading.Thread datapick.Form1::readUSB
		IL_0018: ldarg.0
		IL_0019: ldfld class [mscorlib]System.Threading.Thread datapick.Form1::readUSB
		IL_001e: callvirt instance void [mscorlib]System.Threading.Thread::Start()
		IL_0023: nop
		IL_0024: ret
	} // end of method Form1::timerRecieve_Tick

	.method private hidebysig 
		instance void readUSBdata () cil managed 
	{
		// Method begins at RVA 0x70c8
		// Header size: 12
		// Code size: 66 (0x42)
		.maxstack 6

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldarg.0
			IL_0003: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovREAD
			IL_0008: ldc.i4.0
			IL_0009: stfld int32 datapick.Form1/OVERLAPPED::Offset
			IL_000e: ldarg.0
			IL_000f: ldarg.0
			IL_0010: ldfld int32 datapick.Form1::HidHandle
			IL_0015: call native int [mscorlib]System.IntPtr::op_Explicit(int32)
			IL_001a: ldarg.0
			IL_001b: ldfld uint8[] datapick.Form1::m_rd_data
			IL_0020: ldc.i4.s 65
			IL_0022: ldarg.0
			IL_0023: ldflda uint32 datapick.Form1::USBread
			IL_0028: ldarg.0
			IL_0029: ldflda valuetype datapick.Form1/OVERLAPPED datapick.Form1::ovREAD
			IL_002e: call bool datapick.Form1::ReadFile(native int, uint8[], uint32, uint32&, valuetype datapick.Form1/OVERLAPPED&)
			IL_0033: stfld bool datapick.Form1::isread
			IL_0038: nop
			IL_0039: leave.s IL_0040
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_003b: pop
			IL_003c: nop
			IL_003d: nop
			IL_003e: leave.s IL_0040
		} // end handler

		IL_0040: nop
		IL_0041: ret
	} // end of method Form1::readUSBdata

	.method private hidebysig 
		instance void timerUSBread_Tick (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x7128
		// Header size: 12
		// Code size: 584 (0x248)
		.maxstack 4
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld int32 datapick.Form1::communicate_fangshi
		IL_0007: ldc.i4.1
		IL_0008: ceq
		IL_000a: ldc.i4.0
		IL_000b: ceq
		IL_000d: stloc.0
		IL_000e: ldloc.0
		IL_000f: brtrue.s IL_0020

		IL_0011: ldarg.0
		IL_0012: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0017: ldc.i4.0
		IL_0018: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_001d: nop
		IL_001e: br.s IL_003d

		IL_0020: ldarg.0
		IL_0021: ldfld int32 datapick.Form1::communicate_fangshi
		IL_0026: ldc.i4.2
		IL_0027: ceq
		IL_0029: ldc.i4.0
		IL_002a: ceq
		IL_002c: stloc.0
		IL_002d: ldloc.0
		IL_002e: brtrue.s IL_003d

		IL_0030: ldarg.0
		IL_0031: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0036: ldc.i4.1
		IL_0037: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_003c: nop

		IL_003d: ldarg.0
		IL_003e: ldfld bool datapick.Form1::isread
		IL_0043: ldc.i4.0
		IL_0044: ceq
		IL_0046: stloc.0
		IL_0047: ldloc.0
		IL_0048: brtrue IL_0247

		IL_004d: nop
		IL_004e: ldarg.0
		IL_004f: ldfld bool datapick.Form1::boolDisplayData
		IL_0054: ldc.i4.0
		IL_0055: ceq
		IL_0057: stloc.0
		IL_0058: ldloc.0
		IL_0059: brtrue IL_0246

		IL_005e: nop
		IL_005f: ldarg.0
		IL_0060: ldc.i4.0
		IL_0061: stfld bool datapick.Form1::boolDisplayData
		IL_0066: ldarg.0
		IL_0067: ldarg.0
		IL_0068: ldfld uint8[] datapick.Form1::m_rd_data
		IL_006d: ldc.i4.4
		IL_006e: call float32 datapick.PointerConvert::ToFloat(uint8[], int32)
		IL_0073: stfld float32 datapick.Form1::temp
		IL_0078: ldarg.0
		IL_0079: ldarg.0
		IL_007a: ldfld float32 datapick.Form1::temp
		IL_007f: call float32 [mscorlib]System.Math::Abs(float32)
		IL_0084: stfld float32 datapick.Form1::temp_abs
		IL_0089: ldarg.0
		IL_008a: ldfld float32 datapick.Form1::temp_abs
		IL_008f: ldc.r4 30
		IL_0094: clt
		IL_0096: ldc.i4.0
		IL_0097: ceq
		IL_0099: stloc.0
		IL_009a: ldloc.0
		IL_009b: brtrue.s IL_00b5

		IL_009d: ldarg.0
		IL_009e: ldarg.0
		IL_009f: ldflda float32 datapick.Form1::temp_abs
		IL_00a4: ldstr "#00.0000"
		IL_00a9: call instance string [mscorlib]System.Single::ToString(string)
		IL_00ae: stfld string datapick.Form1::Bdatedisplay
		IL_00b3: br.s IL_00f7

		IL_00b5: ldarg.0
		IL_00b6: ldfld float32 datapick.Form1::temp_abs
		IL_00bb: ldc.r4 300
		IL_00c0: clt
		IL_00c2: ldc.i4.0
		IL_00c3: ceq
		IL_00c5: stloc.0
		IL_00c6: ldloc.0
		IL_00c7: brtrue.s IL_00e1

		IL_00c9: ldarg.0
		IL_00ca: ldarg.0
		IL_00cb: ldflda float32 datapick.Form1::temp_abs
		IL_00d0: ldstr "#000.000"
		IL_00d5: call instance string [mscorlib]System.Single::ToString(string)
		IL_00da: stfld string datapick.Form1::Bdatedisplay
		IL_00df: br.s IL_00f7

		IL_00e1: ldarg.0
		IL_00e2: ldarg.0
		IL_00e3: ldflda float32 datapick.Form1::temp_abs
		IL_00e8: ldstr "#0000.00"
		IL_00ed: call instance string [mscorlib]System.Single::ToString(string)
		IL_00f2: stfld string datapick.Form1::Bdatedisplay

		IL_00f7: ldarg.0
		IL_00f8: ldfld float32 datapick.Form1::temp
		IL_00fd: ldc.r4 0.0
		IL_0102: clt.un
		IL_0104: stloc.0
		IL_0105: ldloc.0
		IL_0106: brtrue.s IL_0120

		IL_0108: ldarg.0
		IL_0109: ldstr "+"
		IL_010e: ldarg.0
		IL_010f: ldfld string datapick.Form1::Bdatedisplay
		IL_0114: call string [mscorlib]System.String::Concat(string, string)
		IL_0119: stfld string datapick.Form1::Bdatedisplay
		IL_011e: br.s IL_0136

		IL_0120: ldarg.0
		IL_0121: ldstr "-"
		IL_0126: ldarg.0
		IL_0127: ldfld string datapick.Form1::Bdatedisplay
		IL_012c: call string [mscorlib]System.String::Concat(string, string)
		IL_0131: stfld string datapick.Form1::Bdatedisplay

		IL_0136: ldarg.0
		IL_0137: ldarg.0
		IL_0138: ldfld string datapick.Form1::Bdatedisplay
		IL_013d: callvirt instance string [mscorlib]System.String::Trim()
		IL_0142: call float64 [mscorlib]System.Convert::ToDouble(string)
		IL_0147: stfld float64 datapick.Form1::Bdate
		IL_014c: ldarg.0
		IL_014d: ldarg.0
		IL_014e: ldfld uint8[] datapick.Form1::m_rd_data
		IL_0153: ldc.i4.s 12
		IL_0155: ldelem.u1
		IL_0156: ldarg.0
		IL_0157: ldfld uint8[] datapick.Form1::m_rd_data
		IL_015c: ldc.i4.s 13
		IL_015e: ldelem.u1
		IL_015f: ldc.i4 256
		IL_0164: mul
		IL_0165: add
		IL_0166: conv.r4
		IL_0167: ldc.r4 10
		IL_016c: div
		IL_016d: call float64 [mscorlib]System.Convert::ToDouble(float32)
		IL_0172: stfld float64 datapick.Form1::tempwendu
		IL_0177: ldarg.0
		IL_0178: ldarg.0
		IL_0179: ldflda float64 datapick.Form1::tempwendu
		IL_017e: ldstr "#0.0"
		IL_0183: call instance string [mscorlib]System.Double::ToString(string)
		IL_0188: call float64 [mscorlib]System.Convert::ToDouble(string)
		IL_018d: stfld float64 datapick.Form1::tempwendu
		IL_0192: ldarg.0
		IL_0193: ldfld float64 datapick.Form1::tempwendu
		IL_0198: ldc.r8 900
		IL_01a1: cgt
		IL_01a3: ldc.i4.0
		IL_01a4: ceq
		IL_01a6: stloc.0
		IL_01a7: ldloc.0
		IL_01a8: brtrue.s IL_01c7

		IL_01aa: ldarg.0
		IL_01ab: ldarg.0
		IL_01ac: ldfld float64 datapick.Form1::tempwendu
		IL_01b1: ldc.r8 1000
		IL_01ba: sub
		IL_01bb: ldc.i4.1
		IL_01bc: call float64 [mscorlib]System.Math::Round(float64, int32)
		IL_01c1: neg
		IL_01c2: stfld float64 datapick.Form1::tempwendu

		IL_01c7: ldarg.0
		IL_01c8: ldarg.0
		IL_01c9: ldfld uint8[] datapick.Form1::m_rd_data
		IL_01ce: ldc.i4.s 9
		IL_01d0: ldelem.u1
		IL_01d1: ldarg.0
		IL_01d2: ldfld uint8[] datapick.Form1::m_rd_data
		IL_01d7: ldc.i4.s 10
		IL_01d9: ldelem.u1
		IL_01da: ldc.i4 256
		IL_01df: mul
		IL_01e0: add
		IL_01e1: call float64 [mscorlib]System.Convert::ToDouble(int32)
		IL_01e6: stfld float64 datapick.Form1::pinlv
		IL_01eb: ldarg.0
		IL_01ec: ldfld float64 datapick.Form1::pinlv
		IL_01f1: ldc.r8 0.0
		IL_01fa: bne.un.s IL_0223

		IL_01fc: ldarg.0
		IL_01fd: ldfld float64 datapick.Form1::tempwendu
		IL_0202: ldc.r8 0.0
		IL_020b: bne.un.s IL_0223

		IL_020d: ldarg.0
		IL_020e: ldfld float64 datapick.Form1::Bdate
		IL_0213: ldc.r8 0.0
		IL_021c: ceq
		IL_021e: ldc.i4.0
		IL_021f: ceq
		IL_0221: br.s IL_0224

		IL_0223: ldc.i4.1

		IL_0224: nop
		IL_0225: stloc.0
		IL_0226: ldloc.0
		IL_0227: brtrue.s IL_022b

		IL_0229: br.s IL_0247

		IL_022b: ldarg.0
		IL_022c: ldc.i4.1
		IL_022d: stfld bool datapick.Form1::listadd
		IL_0232: ldarg.0
		IL_0233: ldfld bool datapick.Form1::Ready
		IL_0238: stloc.0
		IL_0239: ldloc.0
		IL_023a: brtrue.s IL_0245

		IL_023c: nop
		IL_023d: ldarg.0
		IL_023e: ldc.i4.1
		IL_023f: stfld bool datapick.Form1::Ready
		IL_0244: nop

		IL_0245: nop

		IL_0246: nop

		IL_0247: ret
	} // end of method Form1::timerUSBread_Tick

	.method private hidebysig 
		instance void buttonRefresh_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x737c
		// Header size: 1
		// Code size: 50 (0x32)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_0007: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::Clear()
		IL_000c: nop
		IL_000d: ldarg.0
		IL_000e: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0013: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0018: nop
		IL_0019: ldarg.0
		IL_001a: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_001f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_0024: nop
		IL_0025: ldarg.0
		IL_0026: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_002b: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::SaveAs()
		IL_0030: nop
		IL_0031: ret
	} // end of method Form1::buttonRefresh_Click

	.method private hidebysig 
		instance void timerType_Tick (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x73b0
		// Header size: 12
		// Code size: 134 (0x86)
		.maxstack 3
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldarg.0
			IL_0003: ldfld int32 datapick.Form1::FlagEnquire
			IL_0008: ldc.i4.2
			IL_0009: ceq
			IL_000b: ldc.i4.0
			IL_000c: ceq
			IL_000e: stloc.0
			IL_000f: ldloc.0
			IL_0010: brtrue.s IL_0040

			IL_0012: nop
			IL_0013: ldarg.0
			IL_0014: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
			IL_0019: ldc.i4.2
			IL_001a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_001f: nop
			IL_0020: ldarg.0
			IL_0021: ldc.i4.4
			IL_0022: stfld int32 datapick.Form1::FlagEnquire
			IL_0027: ldarg.0
			IL_0028: ldarg.1
			IL_0029: ldarg.2
			IL_002a: call instance void datapick.Form1::buttonSTART_Click(object, class [mscorlib]System.EventArgs)
			IL_002f: nop
			IL_0030: ldarg.0
			IL_0031: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerType
			IL_0036: ldc.i4.0
			IL_0037: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_003c: nop
			IL_003d: nop
			IL_003e: br.s IL_007c

			IL_0040: ldarg.0
			IL_0041: ldfld int32 datapick.Form1::FlagEnquire
			IL_0046: ldc.i4.3
			IL_0047: ceq
			IL_0049: ldc.i4.0
			IL_004a: ceq
			IL_004c: stloc.0
			IL_004d: ldloc.0
			IL_004e: brtrue.s IL_007c

			IL_0050: nop
			IL_0051: ldarg.0
			IL_0052: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
			IL_0057: ldc.i4.1
			IL_0058: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
			IL_005d: nop
			IL_005e: ldarg.0
			IL_005f: ldc.i4.4
			IL_0060: stfld int32 datapick.Form1::FlagEnquire
			IL_0065: ldarg.0
			IL_0066: ldarg.1
			IL_0067: ldarg.2
			IL_0068: call instance void datapick.Form1::buttonSTART_Click(object, class [mscorlib]System.EventArgs)
			IL_006d: nop
			IL_006e: ldarg.0
			IL_006f: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerType
			IL_0074: ldc.i4.0
			IL_0075: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
			IL_007a: nop
			IL_007b: nop

			IL_007c: nop
			IL_007d: leave.s IL_0083
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_007f: pop
			IL_0080: nop
			IL_0081: leave.s IL_0084
		} // end handler

		IL_0083: nop

		IL_0084: nop
		IL_0085: ret
	} // end of method Form1::timerType_Tick

	.method private hidebysig 
		instance void comboBoxSpeed_EnabledChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x7454
		// Header size: 12
		// Code size: 4 (0x4)
		.maxstack 1
		.locals init (
			[0] int32 i
		)

		IL_0000: nop
		IL_0001: ldc.i4.0
		IL_0002: stloc.0
		IL_0003: ret
	} // end of method Form1::comboBoxSpeed_EnabledChanged

	.method private hidebysig 
		instance void button1_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x7464
		// Header size: 1
		// Code size: 38 (0x26)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [ZedGraph]ZedGraph.PointPairList datapick.Form1::list
		IL_0007: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<class [ZedGraph]ZedGraph.PointPair>::Clear()
		IL_000c: nop
		IL_000d: ldarg.0
		IL_000e: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0013: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::AxisChange()
		IL_0018: nop
		IL_0019: ldarg.0
		IL_001a: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_001f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::Refresh()
		IL_0024: nop
		IL_0025: ret
	} // end of method Form1::button1_Click

	.method private hidebysig 
		instance void button2_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x748b
		// Header size: 1
		// Code size: 14 (0xe)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0007: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::SaveAs()
		IL_000c: nop
		IL_000d: ret
	} // end of method Form1::button2_Click

	.method private hidebysig 
		instance void splitContainer1_Panel1_SizeChanged (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x749a
		// Header size: 1
		// Code size: 2 (0x2)
		.maxstack 8

		IL_0000: nop
		IL_0001: ret
	} // end of method Form1::splitContainer1_Panel1_SizeChanged

	.method private hidebysig 
		instance void splitContainer1_Panel1_Resize (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x74a0
		// Header size: 12
		// Code size: 66 (0x42)
		.maxstack 3

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_0007: ldarg.0
		IL_0008: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_000d: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_SplitterDistance()
		IL_0012: ldc.i4.s 15
		IL_0014: sub
		IL_0015: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Height(int32)
		IL_001a: nop
		IL_001b: ldarg.0
		IL_001c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0021: ldarg.0
		IL_0022: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_0027: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.Control::get_Height()
		IL_002c: ldarg.0
		IL_002d: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_0032: callvirt instance int32 [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_SplitterDistance()
		IL_0037: sub
		IL_0038: ldc.i4.s 15
		IL_003a: sub
		IL_003b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Height(int32)
		IL_0040: nop
		IL_0041: ret
	} // end of method Form1::splitContainer1_Panel1_Resize

	.method private hidebysig 
		instance void comboBoxCOM_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0x74ee
		// Header size: 1
		// Code size: 41 (0x29)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0007: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_000c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::Clear()
		IL_0011: nop
		IL_0012: ldarg.0
		IL_0013: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0018: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_001d: call string[] [System]System.IO.Ports.SerialPort::GetPortNames()
		IL_0022: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_0027: nop
		IL_0028: ret
	} // end of method Form1::comboBoxCOM_Click

	.method family hidebysig virtual 
		instance void Dispose (
			bool disposing
		) cil managed 
	{
		// Method begins at RVA 0x7518
		// Header size: 12
		// Code size: 44 (0x2c)
		.maxstack 2
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.1
		IL_0002: brfalse.s IL_000f

		IL_0004: ldarg.0
		IL_0005: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_000a: ldnull
		IL_000b: ceq
		IL_000d: br.s IL_0010

		IL_000f: ldc.i4.1

		IL_0010: nop
		IL_0011: stloc.0
		IL_0012: ldloc.0
		IL_0013: brtrue.s IL_0023

		IL_0015: nop
		IL_0016: ldarg.0
		IL_0017: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_001c: callvirt instance void [mscorlib]System.IDisposable::Dispose()
		IL_0021: nop
		IL_0022: nop

		IL_0023: ldarg.0
		IL_0024: ldarg.1
		IL_0025: call instance void [System.Windows.Forms]System.Windows.Forms.Form::Dispose(bool)
		IL_002a: nop
		IL_002b: ret
	} // end of method Form1::Dispose

	.method private hidebysig 
		instance void InitializeComponent () cil managed 
	{
		// Method begins at RVA 0x7550
		// Header size: 12
		// Code size: 9286 (0x2446)
		.maxstack 4
		.locals init (
			[0] class [System]System.ComponentModel.ComponentResourceManager resources,
			[1] object[] CS$0$0000,
			[2] class [System.Windows.Forms]System.Windows.Forms.ToolStripItem[] CS$0$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: newobj instance void [System]System.ComponentModel.Container::.ctor()
		IL_0007: stfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_000c: ldtoken datapick.Form1
		IL_0011: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_0016: newobj instance void [System]System.ComponentModel.ComponentResourceManager::.ctor(class [mscorlib]System.Type)
		IL_001b: stloc.0
		IL_001c: ldarg.0
		IL_001d: newobj instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::.ctor()
		IL_0022: stfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0027: ldarg.0
		IL_0028: newobj instance void [System.Windows.Forms]System.Windows.Forms.CheckBox::.ctor()
		IL_002d: stfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_0032: ldarg.0
		IL_0033: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0038: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_003d: ldarg.0
		IL_003e: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0043: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_0048: ldarg.0
		IL_0049: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_004e: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_0053: ldarg.0
		IL_0054: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_0059: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_005e: ldarg.0
		IL_005f: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_0064: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_0069: ldarg.0
		IL_006a: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_006f: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0074: ldarg.0
		IL_0075: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_007a: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_007f: ldarg.0
		IL_0080: newobj instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::.ctor()
		IL_0085: stfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_008a: ldarg.0
		IL_008b: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0090: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_0095: ldarg.0
		IL_0096: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_009b: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_00a0: ldarg.0
		IL_00a1: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_00a6: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_00ab: ldarg.0
		IL_00ac: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_00b1: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_00b6: ldarg.0
		IL_00b7: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_00bc: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_00c1: ldarg.0
		IL_00c2: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_00c7: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_00cc: ldarg.0
		IL_00cd: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_00d2: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_00d7: ldarg.0
		IL_00d8: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_00dd: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_00e2: ldarg.0
		IL_00e3: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_00e8: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_00ed: ldarg.0
		IL_00ee: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_00f3: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_00f8: ldarg.0
		IL_00f9: newobj instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::.ctor()
		IL_00fe: stfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_0103: ldarg.0
		IL_0104: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_0109: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_010e: ldarg.0
		IL_010f: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0114: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_0119: ldarg.0
		IL_011a: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_011f: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_0124: ldarg.0
		IL_0125: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_012a: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_012f: ldarg.0
		IL_0130: newobj instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::.ctor()
		IL_0135: stfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_013a: ldarg.0
		IL_013b: newobj instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::.ctor()
		IL_0140: stfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_0145: ldarg.0
		IL_0146: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_014b: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_0150: ldarg.0
		IL_0151: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0156: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_015b: ldarg.0
		IL_015c: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_0161: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_0166: ldarg.0
		IL_0167: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_016c: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_0171: ldarg.0
		IL_0172: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_0177: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_017c: ldarg.0
		IL_017d: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0182: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_0187: ldarg.0
		IL_0188: newobj instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::.ctor()
		IL_018d: stfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_0192: ldarg.0
		IL_0193: ldarg.0
		IL_0194: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_0199: newobj instance void [System]System.IO.Ports.SerialPort::.ctor(class [System]System.ComponentModel.IContainer)
		IL_019e: stfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_01a3: ldarg.0
		IL_01a4: newobj instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::.ctor()
		IL_01a9: stfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_01ae: ldarg.0
		IL_01af: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_01b4: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_01b9: ldarg.0
		IL_01ba: newobj instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::.ctor()
		IL_01bf: stfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_01c4: ldarg.0
		IL_01c5: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_01ca: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_01cf: ldarg.0
		IL_01d0: newobj instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::.ctor()
		IL_01d5: stfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_01da: ldarg.0
		IL_01db: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_01e0: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_01e5: ldarg.0
		IL_01e6: ldarg.0
		IL_01e7: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_01ec: newobj instance void [System.Windows.Forms]System.Windows.Forms.Timer::.ctor(class [System]System.ComponentModel.IContainer)
		IL_01f1: stfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerTIME
		IL_01f6: ldarg.0
		IL_01f7: newobj instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::.ctor()
		IL_01fc: stfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_0201: ldarg.0
		IL_0202: newobj instance void [System.Windows.Forms]System.Windows.Forms.StatusStrip::.ctor()
		IL_0207: stfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_020c: ldarg.0
		IL_020d: newobj instance void [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel::.ctor()
		IL_0212: stfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::ToolStripStatusLabel1
		IL_0217: ldarg.0
		IL_0218: newobj instance void [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel::.ctor()
		IL_021d: stfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::toolStripStatusLabel2
		IL_0222: ldarg.0
		IL_0223: newobj instance void [ZedGraph]ZedGraph.ZedGraphControl::.ctor()
		IL_0228: stfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_022d: ldarg.0
		IL_022e: ldarg.0
		IL_022f: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_0234: newobj instance void [System.Windows.Forms]System.Windows.Forms.Timer::.ctor(class [System]System.ComponentModel.IContainer)
		IL_0239: stfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_023e: ldarg.0
		IL_023f: ldarg.0
		IL_0240: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_0245: newobj instance void [System.Windows.Forms]System.Windows.Forms.Timer::.ctor(class [System]System.ComponentModel.IContainer)
		IL_024a: stfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerRecieve
		IL_024f: ldarg.0
		IL_0250: ldarg.0
		IL_0251: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_0256: newobj instance void [System.Windows.Forms]System.Windows.Forms.Timer::.ctor(class [System]System.ComponentModel.IContainer)
		IL_025b: stfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerUSBread
		IL_0260: ldarg.0
		IL_0261: ldarg.0
		IL_0262: ldfld class [System]System.ComponentModel.IContainer datapick.Form1::components
		IL_0267: newobj instance void [System.Windows.Forms]System.Windows.Forms.Timer::.ctor(class [System]System.ComponentModel.IContainer)
		IL_026c: stfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerType
		IL_0271: ldarg.0
		IL_0272: newobj instance void [System.Windows.Forms]System.Windows.Forms.SplitContainer::.ctor()
		IL_0277: stfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_027c: ldarg.0
		IL_027d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0282: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_0287: nop
		IL_0288: ldarg.0
		IL_0289: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_028e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_0293: nop
		IL_0294: ldarg.0
		IL_0295: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_029a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_029f: nop
		IL_02a0: ldarg.0
		IL_02a1: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_02a6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_02ab: nop
		IL_02ac: ldarg.0
		IL_02ad: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_02b2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_02b7: nop
		IL_02b8: ldarg.0
		IL_02b9: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_02be: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_02c3: nop
		IL_02c4: ldarg.0
		IL_02c5: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_02ca: callvirt instance void [System]System.ComponentModel.ISupportInitialize::BeginInit()
		IL_02cf: nop
		IL_02d0: ldarg.0
		IL_02d1: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_02d6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_02db: nop
		IL_02dc: ldarg.0
		IL_02dd: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_02e2: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel1()
		IL_02e7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_02ec: nop
		IL_02ed: ldarg.0
		IL_02ee: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_02f3: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel2()
		IL_02f8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_02fd: nop
		IL_02fe: ldarg.0
		IL_02ff: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_0304: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_0309: nop
		IL_030a: ldarg.0
		IL_030b: call instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_0310: nop
		IL_0311: ldarg.0
		IL_0312: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0317: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_031c: ldarg.0
		IL_031d: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_0322: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0327: nop
		IL_0328: ldarg.0
		IL_0329: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_032e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_0333: ldarg.0
		IL_0334: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_0339: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_033e: nop
		IL_033f: ldarg.0
		IL_0340: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0345: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_034a: ldarg.0
		IL_034b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_0350: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0355: nop
		IL_0356: ldarg.0
		IL_0357: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_035c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_0361: ldarg.0
		IL_0362: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_0367: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_036c: nop
		IL_036d: ldarg.0
		IL_036e: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0373: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_0378: ldarg.0
		IL_0379: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_037e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0383: nop
		IL_0384: ldarg.0
		IL_0385: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_038a: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_038f: ldarg.0
		IL_0390: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_0395: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_039a: nop
		IL_039b: ldarg.0
		IL_039c: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_03a1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_03a6: ldarg.0
		IL_03a7: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_03ac: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_03b1: nop
		IL_03b2: ldarg.0
		IL_03b3: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_03b8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_03bd: ldarg.0
		IL_03be: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_03c3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_03c8: nop
		IL_03c9: ldarg.0
		IL_03ca: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_03cf: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_03d4: ldarg.0
		IL_03d5: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_03da: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_03df: nop
		IL_03e0: ldarg.0
		IL_03e1: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_03e6: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_03eb: ldarg.0
		IL_03ec: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_03f1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_03f6: nop
		IL_03f7: ldarg.0
		IL_03f8: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_03fd: ldc.i4.s 14
		IL_03ff: ldc.i4.s 17
		IL_0401: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0406: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_040b: nop
		IL_040c: ldarg.0
		IL_040d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0412: ldstr "groupBox1"
		IL_0417: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_041c: nop
		IL_041d: ldarg.0
		IL_041e: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0423: ldc.i4 194
		IL_0428: ldc.i4 524
		IL_042d: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0432: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0437: nop
		IL_0438: ldarg.0
		IL_0439: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_043e: ldc.i4.0
		IL_043f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0444: nop
		IL_0445: ldarg.0
		IL_0446: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_044b: ldc.i4.0
		IL_044c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::set_TabStop(bool)
		IL_0451: nop
		IL_0452: ldarg.0
		IL_0453: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_0458: ldstr "设置"
		IL_045d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0462: nop
		IL_0463: ldarg.0
		IL_0464: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_0469: ldc.i4.1
		IL_046a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_046f: nop
		IL_0470: ldarg.0
		IL_0471: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_0476: ldc.i4.s 101
		IL_0478: ldc.i4 495
		IL_047d: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0482: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0487: nop
		IL_0488: ldarg.0
		IL_0489: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_048e: ldstr "checkBox1"
		IL_0493: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0498: nop
		IL_0499: ldarg.0
		IL_049a: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_049f: ldc.i4.s 60
		IL_04a1: ldc.i4.s 16
		IL_04a3: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_04a8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_04ad: nop
		IL_04ae: ldarg.0
		IL_04af: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_04b4: ldc.i4.s 24
		IL_04b6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_04bb: nop
		IL_04bc: ldarg.0
		IL_04bd: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_04c2: ldstr "绝对值"
		IL_04c7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_04cc: nop
		IL_04cd: ldarg.0
		IL_04ce: ldfld class [System.Windows.Forms]System.Windows.Forms.CheckBox datapick.Form1::checkBox1
		IL_04d3: ldc.i4.1
		IL_04d4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_04d9: nop
		IL_04da: ldarg.0
		IL_04db: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_04e0: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Black()
		IL_04e5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_04ea: nop
		IL_04eb: ldarg.0
		IL_04ec: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_04f1: ldc.i4.s 95
		IL_04f3: ldc.i4 413
		IL_04f8: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_04fd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0502: nop
		IL_0503: ldarg.0
		IL_0504: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_0509: ldstr "label11"
		IL_050e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0513: nop
		IL_0514: ldarg.0
		IL_0515: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_051a: ldc.i4.3
		IL_051b: ldc.i4.s 80
		IL_051d: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0522: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0527: nop
		IL_0528: ldarg.0
		IL_0529: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_052e: ldc.i4.s 23
		IL_0530: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0535: nop
		IL_0536: ldarg.0
		IL_0537: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label11
		IL_053c: ldstr "label11"
		IL_0541: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0546: nop
		IL_0547: ldarg.0
		IL_0548: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_054d: ldc.i4.1
		IL_054e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0553: nop
		IL_0554: ldarg.0
		IL_0555: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_055a: ldc.i4.s 124
		IL_055c: ldc.i4 417
		IL_0561: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0566: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_056b: nop
		IL_056c: ldarg.0
		IL_056d: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_0572: ldstr "label10"
		IL_0577: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_057c: nop
		IL_057d: ldarg.0
		IL_057e: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_0583: ldc.i4.s 29
		IL_0585: ldc.i4.s 12
		IL_0587: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_058c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0591: nop
		IL_0592: ldarg.0
		IL_0593: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_0598: ldc.i4.s 22
		IL_059a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_059f: nop
		IL_05a0: ldarg.0
		IL_05a1: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label10
		IL_05a6: ldstr "数据"
		IL_05ab: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_05b0: nop
		IL_05b1: ldarg.0
		IL_05b2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_05b7: ldc.i4.1
		IL_05b8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_05bd: nop
		IL_05be: ldarg.0
		IL_05bf: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_05c4: ldc.i4.s 40
		IL_05c6: ldc.i4 417
		IL_05cb: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_05d0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_05d5: nop
		IL_05d6: ldarg.0
		IL_05d7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_05dc: ldstr "label9"
		IL_05e1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_05e6: nop
		IL_05e7: ldarg.0
		IL_05e8: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_05ed: ldc.i4.s 29
		IL_05ef: ldc.i4.s 12
		IL_05f1: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_05f6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_05fb: nop
		IL_05fc: ldarg.0
		IL_05fd: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_0602: ldc.i4.s 21
		IL_0604: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0609: nop
		IL_060a: ldarg.0
		IL_060b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label9
		IL_0610: ldstr "图形"
		IL_0615: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_061a: nop
		IL_061b: ldarg.0
		IL_061c: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_0621: ldc.i4.s 18
		IL_0623: ldc.i4 466
		IL_0628: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_062d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0632: nop
		IL_0633: ldarg.0
		IL_0634: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_0639: ldstr "button2"
		IL_063e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0643: nop
		IL_0644: ldarg.0
		IL_0645: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_064a: ldc.i4.s 75
		IL_064c: ldc.i4.s 23
		IL_064e: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0653: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0658: nop
		IL_0659: ldarg.0
		IL_065a: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_065f: ldc.i4.s 20
		IL_0661: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0666: nop
		IL_0667: ldarg.0
		IL_0668: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_066d: ldstr "保存"
		IL_0672: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0677: nop
		IL_0678: ldarg.0
		IL_0679: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_067e: ldc.i4.1
		IL_067f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_0684: nop
		IL_0685: ldarg.0
		IL_0686: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button2
		IL_068b: ldarg.0
		IL_068c: ldftn instance void datapick.Form1::button2_Click(object, class [mscorlib]System.EventArgs)
		IL_0692: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0697: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_069c: nop
		IL_069d: ldarg.0
		IL_069e: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_06a3: ldc.i4.s 18
		IL_06a5: ldc.i4 437
		IL_06aa: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_06af: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_06b4: nop
		IL_06b5: ldarg.0
		IL_06b6: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_06bb: ldstr "button1"
		IL_06c0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_06c5: nop
		IL_06c6: ldarg.0
		IL_06c7: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_06cc: ldc.i4.s 75
		IL_06ce: ldc.i4.s 23
		IL_06d0: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_06d5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_06da: nop
		IL_06db: ldarg.0
		IL_06dc: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_06e1: ldc.i4.s 19
		IL_06e3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_06e8: nop
		IL_06e9: ldarg.0
		IL_06ea: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_06ef: ldstr "刷新"
		IL_06f4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_06f9: nop
		IL_06fa: ldarg.0
		IL_06fb: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_0700: ldc.i4.1
		IL_0701: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_0706: nop
		IL_0707: ldarg.0
		IL_0708: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::button1
		IL_070d: ldarg.0
		IL_070e: ldftn instance void datapick.Form1::button1_Click(object, class [mscorlib]System.EventArgs)
		IL_0714: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0719: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_071e: nop
		IL_071f: ldarg.0
		IL_0720: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0725: ldc.i4.s 101
		IL_0727: ldc.i4 466
		IL_072c: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0731: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0736: nop
		IL_0737: ldarg.0
		IL_0738: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_073d: ldstr "buttonEXCEL"
		IL_0742: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0747: nop
		IL_0748: ldarg.0
		IL_0749: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_074e: ldc.i4.s 75
		IL_0750: ldc.i4.s 23
		IL_0752: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0757: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_075c: nop
		IL_075d: ldarg.0
		IL_075e: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0763: ldc.i4.1
		IL_0764: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0769: nop
		IL_076a: ldarg.0
		IL_076b: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0770: ldstr "导出"
		IL_0775: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_077a: nop
		IL_077b: ldarg.0
		IL_077c: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_0781: ldc.i4.1
		IL_0782: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_0787: nop
		IL_0788: ldarg.0
		IL_0789: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonEXCEL
		IL_078e: ldarg.0
		IL_078f: ldftn instance void datapick.Form1::buttonEXCEL_Click(object, class [mscorlib]System.EventArgs)
		IL_0795: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_079a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_079f: nop
		IL_07a0: ldarg.0
		IL_07a1: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_07a6: ldc.i4.s 101
		IL_07a8: ldc.i4 437
		IL_07ad: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_07b2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_07b7: nop
		IL_07b8: ldarg.0
		IL_07b9: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_07be: ldstr "buttonLISTCLEAR"
		IL_07c3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_07c8: nop
		IL_07c9: ldarg.0
		IL_07ca: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_07cf: ldc.i4.s 75
		IL_07d1: ldc.i4.s 23
		IL_07d3: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_07d8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_07dd: nop
		IL_07de: ldarg.0
		IL_07df: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_07e4: ldc.i4.0
		IL_07e5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_07ea: nop
		IL_07eb: ldarg.0
		IL_07ec: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_07f1: ldstr "清空"
		IL_07f6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_07fb: nop
		IL_07fc: ldarg.0
		IL_07fd: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_0802: ldc.i4.1
		IL_0803: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_0808: nop
		IL_0809: ldarg.0
		IL_080a: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonLISTCLEAR
		IL_080f: ldarg.0
		IL_0810: ldftn instance void datapick.Form1::buttonLISTCLEAR_Click(object, class [mscorlib]System.EventArgs)
		IL_0816: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_081b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_0820: nop
		IL_0821: ldarg.0
		IL_0822: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0827: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_082c: ldarg.0
		IL_082d: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_0832: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0837: nop
		IL_0838: ldarg.0
		IL_0839: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_083e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_0843: ldarg.0
		IL_0844: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0849: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_084e: nop
		IL_084f: ldarg.0
		IL_0850: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0855: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_085a: ldarg.0
		IL_085b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0860: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0865: nop
		IL_0866: ldarg.0
		IL_0867: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_086c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_0871: ldarg.0
		IL_0872: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0877: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_087c: nop
		IL_087d: ldarg.0
		IL_087e: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0883: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_0888: ldarg.0
		IL_0889: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_088e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0893: nop
		IL_0894: ldarg.0
		IL_0895: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_089a: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_089f: ldarg.0
		IL_08a0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_08a5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_08aa: nop
		IL_08ab: ldarg.0
		IL_08ac: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_08b1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_08b6: ldarg.0
		IL_08b7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_08bc: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_08c1: nop
		IL_08c2: ldarg.0
		IL_08c3: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_08c8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_08cd: ldarg.0
		IL_08ce: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_08d3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_08d8: nop
		IL_08d9: ldarg.0
		IL_08da: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_08df: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_08e4: ldarg.0
		IL_08e5: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_08ea: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_08ef: nop
		IL_08f0: ldarg.0
		IL_08f1: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_08f6: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_08fb: ldarg.0
		IL_08fc: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_0901: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0906: nop
		IL_0907: ldarg.0
		IL_0908: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_090d: ldc.i4.s 18
		IL_090f: ldc.i4.s 19
		IL_0911: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0916: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_091b: nop
		IL_091c: ldarg.0
		IL_091d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0922: ldstr "groupBox6"
		IL_0927: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_092c: nop
		IL_092d: ldarg.0
		IL_092e: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0933: ldc.i4 158
		IL_0938: ldc.i4 151
		IL_093d: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0942: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0947: nop
		IL_0948: ldarg.0
		IL_0949: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_094e: ldc.i4.s 18
		IL_0950: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0955: nop
		IL_0956: ldarg.0
		IL_0957: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_095c: ldc.i4.0
		IL_095d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::set_TabStop(bool)
		IL_0962: nop
		IL_0963: ldarg.0
		IL_0964: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0969: ldstr "通讯设置"
		IL_096e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0973: nop
		IL_0974: ldarg.0
		IL_0975: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_097a: ldc.i4.1
		IL_097b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0980: nop
		IL_0981: ldarg.0
		IL_0982: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_0987: ldc.i4.5
		IL_0988: ldc.i4.s 25
		IL_098a: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_098f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0994: nop
		IL_0995: ldarg.0
		IL_0996: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_099b: ldstr "label6"
		IL_09a0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_09a5: nop
		IL_09a6: ldarg.0
		IL_09a7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_09ac: ldc.i4.s 53
		IL_09ae: ldc.i4.s 12
		IL_09b0: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_09b5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_09ba: nop
		IL_09bb: ldarg.0
		IL_09bc: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_09c1: ldc.i4.s 10
		IL_09c3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_09c8: nop
		IL_09c9: ldarg.0
		IL_09ca: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label6
		IL_09cf: ldstr "仪器型号"
		IL_09d4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_09d9: nop
		IL_09da: ldarg.0
		IL_09db: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_09e0: ldc.i4.2
		IL_09e1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_09e6: nop
		IL_09e7: ldarg.0
		IL_09e8: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_09ed: ldc.i4.1
		IL_09ee: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_09f3: nop
		IL_09f4: ldarg.0
		IL_09f5: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_09fa: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_09ff: ldc.i4.s 11
		IL_0a01: newarr [mscorlib]System.Object
		IL_0a06: stloc.1
		IL_0a07: ldloc.1
		IL_0a08: ldc.i4.0
		IL_0a09: ldstr "CH-1300"
		IL_0a0e: stelem.ref
		IL_0a0f: ldloc.1
		IL_0a10: ldc.i4.1
		IL_0a11: ldstr "CH-1500"
		IL_0a16: stelem.ref
		IL_0a17: ldloc.1
		IL_0a18: ldc.i4.2
		IL_0a19: ldstr "CH-1500B"
		IL_0a1e: stelem.ref
		IL_0a1f: ldloc.1
		IL_0a20: ldc.i4.3
		IL_0a21: ldstr "CH-1600"
		IL_0a26: stelem.ref
		IL_0a27: ldloc.1
		IL_0a28: ldc.i4.4
		IL_0a29: ldstr "CH-1800"
		IL_0a2e: stelem.ref
		IL_0a2f: ldloc.1
		IL_0a30: ldc.i4.5
		IL_0a31: ldstr "CH-260"
		IL_0a36: stelem.ref
		IL_0a37: ldloc.1
		IL_0a38: ldc.i4.6
		IL_0a39: ldstr "CH-290"
		IL_0a3e: stelem.ref
		IL_0a3f: ldloc.1
		IL_0a40: ldc.i4.7
		IL_0a41: ldstr "CH-260磁通手动"
		IL_0a46: stelem.ref
		IL_0a47: ldloc.1
		IL_0a48: ldc.i4.8
		IL_0a49: ldstr "CH-290磁通手动"
		IL_0a4e: stelem.ref
		IL_0a4f: ldloc.1
		IL_0a50: ldc.i4.s 9
		IL_0a52: ldstr "CH-260磁强手动"
		IL_0a57: stelem.ref
		IL_0a58: ldloc.1
		IL_0a59: ldc.i4.s 10
		IL_0a5b: ldstr "CH-290磁强手动"
		IL_0a60: stelem.ref
		IL_0a61: ldloc.1
		IL_0a62: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_0a67: nop
		IL_0a68: ldarg.0
		IL_0a69: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0a6e: ldc.i4.s 65
		IL_0a70: ldc.i4.s 20
		IL_0a72: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0a77: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0a7c: nop
		IL_0a7d: ldarg.0
		IL_0a7e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0a83: ldstr "comboBoxModel"
		IL_0a88: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0a8d: nop
		IL_0a8e: ldarg.0
		IL_0a8f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0a94: ldc.i4.s 82
		IL_0a96: ldc.i4.s 20
		IL_0a98: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0a9d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0aa2: nop
		IL_0aa3: ldarg.0
		IL_0aa4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0aa9: ldc.i4.s 11
		IL_0aab: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0ab0: nop
		IL_0ab1: ldarg.0
		IL_0ab2: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxModel
		IL_0ab7: ldarg.0
		IL_0ab8: ldftn instance void datapick.Form1::comboBoxModel_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_0abe: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0ac3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_0ac8: nop
		IL_0ac9: ldarg.0
		IL_0aca: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0acf: ldc.i4.2
		IL_0ad0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_0ad5: nop
		IL_0ad6: ldarg.0
		IL_0ad7: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0adc: ldc.i4.1
		IL_0add: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_0ae2: nop
		IL_0ae3: ldarg.0
		IL_0ae4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0ae9: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0aee: ldc.i4.3
		IL_0aef: newarr [mscorlib]System.Object
		IL_0af4: stloc.1
		IL_0af5: ldloc.1
		IL_0af6: ldc.i4.0
		IL_0af7: ldstr "普通数据"
		IL_0afc: stelem.ref
		IL_0afd: ldloc.1
		IL_0afe: ldc.i4.1
		IL_0aff: ldstr "高速数据"
		IL_0b04: stelem.ref
		IL_0b05: ldloc.1
		IL_0b06: ldc.i4.2
		IL_0b07: ldstr "历史数据"
		IL_0b0c: stelem.ref
		IL_0b0d: ldloc.1
		IL_0b0e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_0b13: nop
		IL_0b14: ldarg.0
		IL_0b15: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0b1a: ldc.i4.s 65
		IL_0b1c: ldc.i4.s 122
		IL_0b1e: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0b23: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0b28: nop
		IL_0b29: ldarg.0
		IL_0b2a: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0b2f: ldstr "comboBoxDataType"
		IL_0b34: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0b39: nop
		IL_0b3a: ldarg.0
		IL_0b3b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0b40: ldc.i4.s 82
		IL_0b42: ldc.i4.s 20
		IL_0b44: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0b49: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0b4e: nop
		IL_0b4f: ldarg.0
		IL_0b50: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0b55: ldc.i4.s 9
		IL_0b57: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0b5c: nop
		IL_0b5d: ldarg.0
		IL_0b5e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0b63: ldarg.0
		IL_0b64: ldftn instance void datapick.Form1::comboBoxDataType_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_0b6a: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0b6f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_0b74: nop
		IL_0b75: ldarg.0
		IL_0b76: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0b7b: ldc.i4.2
		IL_0b7c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_0b81: nop
		IL_0b82: ldarg.0
		IL_0b83: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0b88: ldc.i4.1
		IL_0b89: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_0b8e: nop
		IL_0b8f: ldarg.0
		IL_0b90: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0b95: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0b9a: ldc.i4.2
		IL_0b9b: newarr [mscorlib]System.Object
		IL_0ba0: stloc.1
		IL_0ba1: ldloc.1
		IL_0ba2: ldc.i4.0
		IL_0ba3: ldstr "串口"
		IL_0ba8: stelem.ref
		IL_0ba9: ldloc.1
		IL_0baa: ldc.i4.1
		IL_0bab: ldstr "USB"
		IL_0bb0: stelem.ref
		IL_0bb1: ldloc.1
		IL_0bb2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_0bb7: nop
		IL_0bb8: ldarg.0
		IL_0bb9: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0bbe: ldc.i4.s 65
		IL_0bc0: ldc.i4.s 47
		IL_0bc2: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0bc7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0bcc: nop
		IL_0bcd: ldarg.0
		IL_0bce: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0bd3: ldstr "comboBoxfangshi"
		IL_0bd8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0bdd: nop
		IL_0bde: ldarg.0
		IL_0bdf: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0be4: ldc.i4.s 82
		IL_0be6: ldc.i4.s 20
		IL_0be8: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0bed: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0bf2: nop
		IL_0bf3: ldarg.0
		IL_0bf4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0bf9: ldc.i4.7
		IL_0bfa: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0bff: nop
		IL_0c00: ldarg.0
		IL_0c01: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxfangshi
		IL_0c06: ldarg.0
		IL_0c07: ldftn instance void datapick.Form1::comboBoxfangshi_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_0c0d: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0c12: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_0c17: nop
		IL_0c18: ldarg.0
		IL_0c19: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_0c1e: ldc.i4.1
		IL_0c1f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0c24: nop
		IL_0c25: ldarg.0
		IL_0c26: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_0c2b: ldc.i4.5
		IL_0c2c: ldc.i4.s 125
		IL_0c2e: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0c33: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0c38: nop
		IL_0c39: ldarg.0
		IL_0c3a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_0c3f: ldstr "label5"
		IL_0c44: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0c49: nop
		IL_0c4a: ldarg.0
		IL_0c4b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_0c50: ldc.i4.s 53
		IL_0c52: ldc.i4.s 12
		IL_0c54: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0c59: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0c5e: nop
		IL_0c5f: ldarg.0
		IL_0c60: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_0c65: ldc.i4.8
		IL_0c66: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0c6b: nop
		IL_0c6c: ldarg.0
		IL_0c6d: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label5
		IL_0c72: ldstr "数据类型"
		IL_0c77: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0c7c: nop
		IL_0c7d: ldarg.0
		IL_0c7e: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_0c83: ldc.i4.1
		IL_0c84: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0c89: nop
		IL_0c8a: ldarg.0
		IL_0c8b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_0c90: ldc.i4.5
		IL_0c91: ldc.i4.s 50
		IL_0c93: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0c98: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0c9d: nop
		IL_0c9e: ldarg.0
		IL_0c9f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_0ca4: ldstr "label4"
		IL_0ca9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0cae: nop
		IL_0caf: ldarg.0
		IL_0cb0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_0cb5: ldc.i4.s 53
		IL_0cb7: ldc.i4.s 12
		IL_0cb9: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0cbe: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0cc3: nop
		IL_0cc4: ldarg.0
		IL_0cc5: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_0cca: ldc.i4.6
		IL_0ccb: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0cd0: nop
		IL_0cd1: ldarg.0
		IL_0cd2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label4
		IL_0cd7: ldstr "通讯方式"
		IL_0cdc: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0ce1: nop
		IL_0ce2: ldarg.0
		IL_0ce3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_0ce8: ldc.i4.1
		IL_0ce9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0cee: nop
		IL_0cef: ldarg.0
		IL_0cf0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_0cf5: ldc.i4.5
		IL_0cf6: ldc.i4.s 75
		IL_0cf8: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0cfd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0d02: nop
		IL_0d03: ldarg.0
		IL_0d04: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_0d09: ldstr "label1"
		IL_0d0e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0d13: nop
		IL_0d14: ldarg.0
		IL_0d15: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_0d1a: ldc.i4.s 53
		IL_0d1c: ldc.i4.s 12
		IL_0d1e: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0d23: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0d28: nop
		IL_0d29: ldarg.0
		IL_0d2a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_0d2f: ldc.i4.0
		IL_0d30: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0d35: nop
		IL_0d36: ldarg.0
		IL_0d37: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label1
		IL_0d3c: ldstr "串口选择"
		IL_0d41: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0d46: nop
		IL_0d47: ldarg.0
		IL_0d48: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0d4d: ldc.i4.2
		IL_0d4e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_0d53: nop
		IL_0d54: ldarg.0
		IL_0d55: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0d5a: ldc.i4.1
		IL_0d5b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_0d60: nop
		IL_0d61: ldarg.0
		IL_0d62: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0d67: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0d6c: ldc.i4.s 13
		IL_0d6e: newarr [mscorlib]System.Object
		IL_0d73: stloc.1
		IL_0d74: ldloc.1
		IL_0d75: ldc.i4.0
		IL_0d76: ldstr "110"
		IL_0d7b: stelem.ref
		IL_0d7c: ldloc.1
		IL_0d7d: ldc.i4.1
		IL_0d7e: ldstr "300"
		IL_0d83: stelem.ref
		IL_0d84: ldloc.1
		IL_0d85: ldc.i4.2
		IL_0d86: ldstr "600"
		IL_0d8b: stelem.ref
		IL_0d8c: ldloc.1
		IL_0d8d: ldc.i4.3
		IL_0d8e: ldstr "1200"
		IL_0d93: stelem.ref
		IL_0d94: ldloc.1
		IL_0d95: ldc.i4.4
		IL_0d96: ldstr "2400"
		IL_0d9b: stelem.ref
		IL_0d9c: ldloc.1
		IL_0d9d: ldc.i4.5
		IL_0d9e: ldstr "4800"
		IL_0da3: stelem.ref
		IL_0da4: ldloc.1
		IL_0da5: ldc.i4.6
		IL_0da6: ldstr "9600"
		IL_0dab: stelem.ref
		IL_0dac: ldloc.1
		IL_0dad: ldc.i4.7
		IL_0dae: ldstr "14400"
		IL_0db3: stelem.ref
		IL_0db4: ldloc.1
		IL_0db5: ldc.i4.8
		IL_0db6: ldstr "19200"
		IL_0dbb: stelem.ref
		IL_0dbc: ldloc.1
		IL_0dbd: ldc.i4.s 9
		IL_0dbf: ldstr "38400"
		IL_0dc4: stelem.ref
		IL_0dc5: ldloc.1
		IL_0dc6: ldc.i4.s 10
		IL_0dc8: ldstr "56000"
		IL_0dcd: stelem.ref
		IL_0dce: ldloc.1
		IL_0dcf: ldc.i4.s 11
		IL_0dd1: ldstr "57600"
		IL_0dd6: stelem.ref
		IL_0dd7: ldloc.1
		IL_0dd8: ldc.i4.s 12
		IL_0dda: ldstr "115200"
		IL_0ddf: stelem.ref
		IL_0de0: ldloc.1
		IL_0de1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_0de6: nop
		IL_0de7: ldarg.0
		IL_0de8: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0ded: ldc.i4.s 65
		IL_0def: ldc.i4.s 97
		IL_0df1: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0df6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0dfb: nop
		IL_0dfc: ldarg.0
		IL_0dfd: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0e02: ldstr "comboBoxBAUDE"
		IL_0e07: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0e0c: nop
		IL_0e0d: ldarg.0
		IL_0e0e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0e13: ldc.i4.s 82
		IL_0e15: ldc.i4.s 20
		IL_0e17: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0e1c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0e21: nop
		IL_0e22: ldarg.0
		IL_0e23: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0e28: ldc.i4.3
		IL_0e29: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0e2e: nop
		IL_0e2f: ldarg.0
		IL_0e30: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxBAUDE
		IL_0e35: ldarg.0
		IL_0e36: ldftn instance void datapick.Form1::comboBoxBAUDE_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_0e3c: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0e41: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_0e46: nop
		IL_0e47: ldarg.0
		IL_0e48: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0e4d: ldc.i4.2
		IL_0e4e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_0e53: nop
		IL_0e54: ldarg.0
		IL_0e55: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0e5a: ldc.i4.1
		IL_0e5b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_0e60: nop
		IL_0e61: ldarg.0
		IL_0e62: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0e67: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_0e6c: ldc.i4.s 21
		IL_0e6e: newarr [mscorlib]System.Object
		IL_0e73: stloc.1
		IL_0e74: ldloc.1
		IL_0e75: ldc.i4.0
		IL_0e76: ldstr "COM1"
		IL_0e7b: stelem.ref
		IL_0e7c: ldloc.1
		IL_0e7d: ldc.i4.1
		IL_0e7e: ldstr "COM2"
		IL_0e83: stelem.ref
		IL_0e84: ldloc.1
		IL_0e85: ldc.i4.2
		IL_0e86: ldstr "COM3"
		IL_0e8b: stelem.ref
		IL_0e8c: ldloc.1
		IL_0e8d: ldc.i4.3
		IL_0e8e: ldstr "COM4"
		IL_0e93: stelem.ref
		IL_0e94: ldloc.1
		IL_0e95: ldc.i4.4
		IL_0e96: ldstr "COM5"
		IL_0e9b: stelem.ref
		IL_0e9c: ldloc.1
		IL_0e9d: ldc.i4.5
		IL_0e9e: ldstr "COM6"
		IL_0ea3: stelem.ref
		IL_0ea4: ldloc.1
		IL_0ea5: ldc.i4.6
		IL_0ea6: ldstr "COM7"
		IL_0eab: stelem.ref
		IL_0eac: ldloc.1
		IL_0ead: ldc.i4.7
		IL_0eae: ldstr "COM8"
		IL_0eb3: stelem.ref
		IL_0eb4: ldloc.1
		IL_0eb5: ldc.i4.8
		IL_0eb6: ldstr "COM9"
		IL_0ebb: stelem.ref
		IL_0ebc: ldloc.1
		IL_0ebd: ldc.i4.s 9
		IL_0ebf: ldstr "COM10"
		IL_0ec4: stelem.ref
		IL_0ec5: ldloc.1
		IL_0ec6: ldc.i4.s 10
		IL_0ec8: ldstr "COM11"
		IL_0ecd: stelem.ref
		IL_0ece: ldloc.1
		IL_0ecf: ldc.i4.s 11
		IL_0ed1: ldstr "COM12"
		IL_0ed6: stelem.ref
		IL_0ed7: ldloc.1
		IL_0ed8: ldc.i4.s 12
		IL_0eda: ldstr "COM13"
		IL_0edf: stelem.ref
		IL_0ee0: ldloc.1
		IL_0ee1: ldc.i4.s 13
		IL_0ee3: ldstr "COM14"
		IL_0ee8: stelem.ref
		IL_0ee9: ldloc.1
		IL_0eea: ldc.i4.s 14
		IL_0eec: ldstr "COM15"
		IL_0ef1: stelem.ref
		IL_0ef2: ldloc.1
		IL_0ef3: ldc.i4.s 15
		IL_0ef5: ldstr "COM16"
		IL_0efa: stelem.ref
		IL_0efb: ldloc.1
		IL_0efc: ldc.i4.s 16
		IL_0efe: ldstr "COM17"
		IL_0f03: stelem.ref
		IL_0f04: ldloc.1
		IL_0f05: ldc.i4.s 17
		IL_0f07: ldstr "COM18"
		IL_0f0c: stelem.ref
		IL_0f0d: ldloc.1
		IL_0f0e: ldc.i4.s 18
		IL_0f10: ldstr "COM19"
		IL_0f15: stelem.ref
		IL_0f16: ldloc.1
		IL_0f17: ldc.i4.s 19
		IL_0f19: ldstr "COM20"
		IL_0f1e: stelem.ref
		IL_0f1f: ldloc.1
		IL_0f20: ldc.i4.s 20
		IL_0f22: ldstr "COM21"
		IL_0f27: stelem.ref
		IL_0f28: ldloc.1
		IL_0f29: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_0f2e: nop
		IL_0f2f: ldarg.0
		IL_0f30: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0f35: ldc.i4.s 65
		IL_0f37: ldc.i4.s 72
		IL_0f39: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0f3e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0f43: nop
		IL_0f44: ldarg.0
		IL_0f45: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0f4a: ldstr "comboBoxCOM"
		IL_0f4f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0f54: nop
		IL_0f55: ldarg.0
		IL_0f56: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0f5b: ldc.i4.s 82
		IL_0f5d: ldc.i4.s 20
		IL_0f5f: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0f64: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0f69: nop
		IL_0f6a: ldarg.0
		IL_0f6b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0f70: ldc.i4.1
		IL_0f71: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0f76: nop
		IL_0f77: ldarg.0
		IL_0f78: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0f7d: ldarg.0
		IL_0f7e: ldftn instance void datapick.Form1::comboBoxCOM_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_0f84: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0f89: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_0f8e: nop
		IL_0f8f: ldarg.0
		IL_0f90: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxCOM
		IL_0f95: ldarg.0
		IL_0f96: ldftn instance void datapick.Form1::comboBoxCOM_Click(object, class [mscorlib]System.EventArgs)
		IL_0f9c: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0fa1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_0fa6: nop
		IL_0fa7: ldarg.0
		IL_0fa8: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_0fad: ldc.i4.1
		IL_0fae: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0fb3: nop
		IL_0fb4: ldarg.0
		IL_0fb5: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_0fba: ldc.i4.5
		IL_0fbb: ldc.i4.s 100
		IL_0fbd: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0fc2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_0fc7: nop
		IL_0fc8: ldarg.0
		IL_0fc9: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_0fce: ldstr "label2"
		IL_0fd3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0fd8: nop
		IL_0fd9: ldarg.0
		IL_0fda: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_0fdf: ldc.i4.s 41
		IL_0fe1: ldc.i4.s 12
		IL_0fe3: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0fe8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0fed: nop
		IL_0fee: ldarg.0
		IL_0fef: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_0ff4: ldc.i4.2
		IL_0ff5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_0ffa: nop
		IL_0ffb: ldarg.0
		IL_0ffc: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label2
		IL_1001: ldstr "波特率"
		IL_1006: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_100b: nop
		IL_100c: ldarg.0
		IL_100d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1012: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_1017: ldarg.0
		IL_1018: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_101d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1022: nop
		IL_1023: ldarg.0
		IL_1024: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1029: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_102e: ldarg.0
		IL_102f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_1034: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1039: nop
		IL_103a: ldarg.0
		IL_103b: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1040: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_1045: ldarg.0
		IL_1046: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_104b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1050: nop
		IL_1051: ldarg.0
		IL_1052: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1057: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_105c: ldarg.0
		IL_105d: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_1062: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1067: nop
		IL_1068: ldarg.0
		IL_1069: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_106e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_1073: ldarg.0
		IL_1074: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_1079: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_107e: nop
		IL_107f: ldarg.0
		IL_1080: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1085: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_108a: ldarg.0
		IL_108b: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_1090: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1095: nop
		IL_1096: ldarg.0
		IL_1097: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_109c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_10a1: ldarg.0
		IL_10a2: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_10a7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_10ac: nop
		IL_10ad: ldarg.0
		IL_10ae: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_10b3: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_10b8: ldarg.0
		IL_10b9: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_10be: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_10c3: nop
		IL_10c4: ldarg.0
		IL_10c5: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_10ca: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_10cf: ldarg.0
		IL_10d0: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_10d5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_10da: nop
		IL_10db: ldarg.0
		IL_10dc: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_10e1: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_10e6: ldarg.0
		IL_10e7: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_10ec: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_10f1: nop
		IL_10f2: ldarg.0
		IL_10f3: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_10f8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_10fd: ldarg.0
		IL_10fe: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_1103: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1108: nop
		IL_1109: ldarg.0
		IL_110a: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_110f: ldc.i4.s 18
		IL_1111: ldc.i4 183
		IL_1116: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_111b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1120: nop
		IL_1121: ldarg.0
		IL_1122: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1127: ldstr "groupBox3"
		IL_112c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1131: nop
		IL_1132: ldarg.0
		IL_1133: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1138: ldc.i4 158
		IL_113d: ldc.i4 215
		IL_1142: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1147: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_114c: nop
		IL_114d: ldarg.0
		IL_114e: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1153: ldc.i4.s 18
		IL_1155: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_115a: nop
		IL_115b: ldarg.0
		IL_115c: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_1161: ldc.i4.0
		IL_1162: callvirt instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::set_TabStop(bool)
		IL_1167: nop
		IL_1168: ldarg.0
		IL_1169: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_116e: ldstr "命令"
		IL_1173: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1178: nop
		IL_1179: ldarg.0
		IL_117a: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_117f: ldc.i4.2
		IL_1180: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_1185: nop
		IL_1186: ldarg.0
		IL_1187: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_118c: ldc.i4.1
		IL_118d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_1192: nop
		IL_1193: ldarg.0
		IL_1194: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_1199: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_119e: ldc.i4.s 15
		IL_11a0: newarr [mscorlib]System.Object
		IL_11a5: stloc.1
		IL_11a6: ldloc.1
		IL_11a7: ldc.i4.0
		IL_11a8: ldstr "默认"
		IL_11ad: stelem.ref
		IL_11ae: ldloc.1
		IL_11af: ldc.i4.1
		IL_11b0: ldstr "1"
		IL_11b5: stelem.ref
		IL_11b6: ldloc.1
		IL_11b7: ldc.i4.2
		IL_11b8: ldstr "2"
		IL_11bd: stelem.ref
		IL_11be: ldloc.1
		IL_11bf: ldc.i4.3
		IL_11c0: ldstr "3"
		IL_11c5: stelem.ref
		IL_11c6: ldloc.1
		IL_11c7: ldc.i4.4
		IL_11c8: ldstr "4"
		IL_11cd: stelem.ref
		IL_11ce: ldloc.1
		IL_11cf: ldc.i4.5
		IL_11d0: ldstr "5"
		IL_11d5: stelem.ref
		IL_11d6: ldloc.1
		IL_11d7: ldc.i4.6
		IL_11d8: ldstr "6"
		IL_11dd: stelem.ref
		IL_11de: ldloc.1
		IL_11df: ldc.i4.7
		IL_11e0: ldstr "7"
		IL_11e5: stelem.ref
		IL_11e6: ldloc.1
		IL_11e7: ldc.i4.8
		IL_11e8: ldstr "8"
		IL_11ed: stelem.ref
		IL_11ee: ldloc.1
		IL_11ef: ldc.i4.s 9
		IL_11f1: ldstr "9"
		IL_11f6: stelem.ref
		IL_11f7: ldloc.1
		IL_11f8: ldc.i4.s 10
		IL_11fa: ldstr "10"
		IL_11ff: stelem.ref
		IL_1200: ldloc.1
		IL_1201: ldc.i4.s 11
		IL_1203: ldstr "15"
		IL_1208: stelem.ref
		IL_1209: ldloc.1
		IL_120a: ldc.i4.s 12
		IL_120c: ldstr "20"
		IL_1211: stelem.ref
		IL_1212: ldloc.1
		IL_1213: ldc.i4.s 13
		IL_1215: ldstr "25"
		IL_121a: stelem.ref
		IL_121b: ldloc.1
		IL_121c: ldc.i4.s 14
		IL_121e: ldstr "30"
		IL_1223: stelem.ref
		IL_1224: ldloc.1
		IL_1225: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_122a: nop
		IL_122b: ldarg.0
		IL_122c: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_1231: ldc.i4.s 65
		IL_1233: ldc.i4.s 51
		IL_1235: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_123a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_123f: nop
		IL_1240: ldarg.0
		IL_1241: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_1246: ldstr "comboBoxT"
		IL_124b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1250: nop
		IL_1251: ldarg.0
		IL_1252: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_1257: ldc.i4.s 82
		IL_1259: ldc.i4.s 20
		IL_125b: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1260: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1265: nop
		IL_1266: ldarg.0
		IL_1267: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_126c: ldc.i4.s 15
		IL_126e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1273: nop
		IL_1274: ldarg.0
		IL_1275: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxT
		IL_127a: ldarg.0
		IL_127b: ldftn instance void datapick.Form1::comboBoxT_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_1281: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_1286: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_128b: nop
		IL_128c: ldarg.0
		IL_128d: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_1292: ldc.i4.1
		IL_1293: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_1298: nop
		IL_1299: ldarg.0
		IL_129a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_129f: ldc.i4.5
		IL_12a0: ldc.i4.s 48
		IL_12a2: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_12a7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_12ac: nop
		IL_12ad: ldarg.0
		IL_12ae: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_12b3: ldstr "label8"
		IL_12b8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_12bd: nop
		IL_12be: ldarg.0
		IL_12bf: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_12c4: ldc.i4.s 53
		IL_12c6: ldc.i4.s 24
		IL_12c8: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_12cd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_12d2: nop
		IL_12d3: ldarg.0
		IL_12d4: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_12d9: ldc.i4.s 14
		IL_12db: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_12e0: nop
		IL_12e1: ldarg.0
		IL_12e2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label8
		IL_12e7: ldstr "普通采集\r\n 周期(s)"
		IL_12ec: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_12f1: nop
		IL_12f2: ldarg.0
		IL_12f3: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_12f8: ldc.i4.2
		IL_12f9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_12fe: nop
		IL_12ff: ldarg.0
		IL_1300: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_1305: ldc.i4.1
		IL_1306: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_130b: nop
		IL_130c: ldarg.0
		IL_130d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_1312: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_1317: ldc.i4.7
		IL_1318: newarr [mscorlib]System.Object
		IL_131d: stloc.1
		IL_131e: ldloc.1
		IL_131f: ldc.i4.0
		IL_1320: ldstr "20组/s"
		IL_1325: stelem.ref
		IL_1326: ldloc.1
		IL_1327: ldc.i4.1
		IL_1328: ldstr "50组/s"
		IL_132d: stelem.ref
		IL_132e: ldloc.1
		IL_132f: ldc.i4.2
		IL_1330: ldstr "100组/s"
		IL_1335: stelem.ref
		IL_1336: ldloc.1
		IL_1337: ldc.i4.3
		IL_1338: ldstr "150组/s"
		IL_133d: stelem.ref
		IL_133e: ldloc.1
		IL_133f: ldc.i4.4
		IL_1340: ldstr "200组/s"
		IL_1345: stelem.ref
		IL_1346: ldloc.1
		IL_1347: ldc.i4.5
		IL_1348: ldstr "250组/s"
		IL_134d: stelem.ref
		IL_134e: ldloc.1
		IL_134f: ldc.i4.6
		IL_1350: ldstr "300组/s"
		IL_1355: stelem.ref
		IL_1356: ldloc.1
		IL_1357: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_135c: nop
		IL_135d: ldarg.0
		IL_135e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_1363: ldc.i4.s 65
		IL_1365: ldc.i4.s 80
		IL_1367: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_136c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1371: nop
		IL_1372: ldarg.0
		IL_1373: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_1378: ldstr "comboBoxSpeed"
		IL_137d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1382: nop
		IL_1383: ldarg.0
		IL_1384: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_1389: ldc.i4.s 82
		IL_138b: ldc.i4.s 20
		IL_138d: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1392: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1397: nop
		IL_1398: ldarg.0
		IL_1399: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_139e: ldc.i4.s 13
		IL_13a0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_13a5: nop
		IL_13a6: ldarg.0
		IL_13a7: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_13ac: ldarg.0
		IL_13ad: ldftn instance void datapick.Form1::comboBoxSpeed_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_13b3: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_13b8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_13bd: nop
		IL_13be: ldarg.0
		IL_13bf: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSpeed
		IL_13c4: ldarg.0
		IL_13c5: ldftn instance void datapick.Form1::comboBoxSpeed_EnabledChanged(object, class [mscorlib]System.EventArgs)
		IL_13cb: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_13d0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_EnabledChanged(class [mscorlib]System.EventHandler)
		IL_13d5: nop
		IL_13d6: ldarg.0
		IL_13d7: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_13dc: ldc.i4.1
		IL_13dd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_13e2: nop
		IL_13e3: ldarg.0
		IL_13e4: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_13e9: ldc.i4.5
		IL_13ea: ldc.i4.s 80
		IL_13ec: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_13f1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_13f6: nop
		IL_13f7: ldarg.0
		IL_13f8: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_13fd: ldstr "label7"
		IL_1402: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1407: nop
		IL_1408: ldarg.0
		IL_1409: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_140e: ldc.i4.s 53
		IL_1410: ldc.i4.s 24
		IL_1412: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1417: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_141c: nop
		IL_141d: ldarg.0
		IL_141e: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_1423: ldc.i4.s 12
		IL_1425: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_142a: nop
		IL_142b: ldarg.0
		IL_142c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label7
		IL_1431: ldstr "高速采集\r\n\u3000速率"
		IL_1436: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_143b: nop
		IL_143c: ldarg.0
		IL_143d: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_1442: ldc.i4.1
		IL_1443: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_1448: nop
		IL_1449: ldarg.0
		IL_144a: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_144f: ldc.i4.m1
		IL_1450: ldc.i4 151
		IL_1455: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_145a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_145f: nop
		IL_1460: ldarg.0
		IL_1461: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_1466: ldstr "radioButton2"
		IL_146b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1470: nop
		IL_1471: ldarg.0
		IL_1472: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_1477: ldc.i4.s 47
		IL_1479: ldc.i4.s 16
		IL_147b: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1480: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1485: nop
		IL_1486: ldarg.0
		IL_1487: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_148c: ldc.i4.s 10
		IL_148e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1493: nop
		IL_1494: ldarg.0
		IL_1495: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_149a: ldc.i4.1
		IL_149b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::set_TabStop(bool)
		IL_14a0: nop
		IL_14a1: ldarg.0
		IL_14a2: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_14a7: ldstr "图形"
		IL_14ac: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_14b1: nop
		IL_14b2: ldarg.0
		IL_14b3: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_14b8: ldc.i4.1
		IL_14b9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_14be: nop
		IL_14bf: ldarg.0
		IL_14c0: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_14c5: ldc.i4.0
		IL_14c6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_14cb: nop
		IL_14cc: ldarg.0
		IL_14cd: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton2
		IL_14d2: ldarg.0
		IL_14d3: ldftn instance void datapick.Form1::radioButton2_CheckedChanged(object, class [mscorlib]System.EventArgs)
		IL_14d9: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_14de: callvirt instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::add_CheckedChanged(class [mscorlib]System.EventHandler)
		IL_14e3: nop
		IL_14e4: ldarg.0
		IL_14e5: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_14ea: ldc.i4.1
		IL_14eb: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_14f0: nop
		IL_14f1: ldarg.0
		IL_14f2: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_14f7: ldc.i4.s 11
		IL_14f9: ldc.i4.s 125
		IL_14fb: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1500: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1505: nop
		IL_1506: ldarg.0
		IL_1507: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_150c: ldstr "radioButton1"
		IL_1511: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1516: nop
		IL_1517: ldarg.0
		IL_1518: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_151d: ldc.i4.s 47
		IL_151f: ldc.i4.s 16
		IL_1521: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1526: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_152b: nop
		IL_152c: ldarg.0
		IL_152d: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_1532: ldc.i4.s 9
		IL_1534: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1539: nop
		IL_153a: ldarg.0
		IL_153b: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_1540: ldc.i4.1
		IL_1541: callvirt instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::set_TabStop(bool)
		IL_1546: nop
		IL_1547: ldarg.0
		IL_1548: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_154d: ldstr "数据"
		IL_1552: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1557: nop
		IL_1558: ldarg.0
		IL_1559: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_155e: ldc.i4.1
		IL_155f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_1564: nop
		IL_1565: ldarg.0
		IL_1566: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_156b: ldc.i4.0
		IL_156c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_1571: nop
		IL_1572: ldarg.0
		IL_1573: ldfld class [System.Windows.Forms]System.Windows.Forms.RadioButton datapick.Form1::radioButton1
		IL_1578: ldarg.0
		IL_1579: ldftn instance void datapick.Form1::radioButton1_CheckedChanged(object, class [mscorlib]System.EventArgs)
		IL_157f: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_1584: callvirt instance void [System.Windows.Forms]System.Windows.Forms.RadioButton::add_CheckedChanged(class [mscorlib]System.EventHandler)
		IL_1589: nop
		IL_158a: ldarg.0
		IL_158b: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_1590: ldc.i4.2
		IL_1591: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_1596: nop
		IL_1597: ldarg.0
		IL_1598: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_159d: ldc.i4.1
		IL_159e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_15a3: nop
		IL_15a4: ldarg.0
		IL_15a5: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_15aa: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_15af: ldc.i4.4
		IL_15b0: newarr [mscorlib]System.Object
		IL_15b5: stloc.1
		IL_15b6: ldloc.1
		IL_15b7: ldc.i4.0
		IL_15b8: ldstr "mT"
		IL_15bd: stelem.ref
		IL_15be: ldloc.1
		IL_15bf: ldc.i4.1
		IL_15c0: ldstr "G"
		IL_15c5: stelem.ref
		IL_15c6: ldloc.1
		IL_15c7: ldc.i4.2
		IL_15c8: ldstr "A/m"
		IL_15cd: stelem.ref
		IL_15ce: ldloc.1
		IL_15cf: ldc.i4.3
		IL_15d0: ldstr "Oe"
		IL_15d5: stelem.ref
		IL_15d6: ldloc.1
		IL_15d7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_15dc: nop
		IL_15dd: ldarg.0
		IL_15de: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_15e3: ldc.i4.s 65
		IL_15e5: ldc.i4.s 22
		IL_15e7: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_15ec: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_15f1: nop
		IL_15f2: ldarg.0
		IL_15f3: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_15f8: ldstr "comboBoxdanwei"
		IL_15fd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1602: nop
		IL_1603: ldarg.0
		IL_1604: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_1609: ldc.i4.s 82
		IL_160b: ldc.i4.s 20
		IL_160d: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1612: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1617: nop
		IL_1618: ldarg.0
		IL_1619: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_161e: ldc.i4.8
		IL_161f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1624: nop
		IL_1625: ldarg.0
		IL_1626: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxdanwei
		IL_162b: ldarg.0
		IL_162c: ldftn instance void datapick.Form1::comboBoxdanwei_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_1632: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_1637: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_163c: nop
		IL_163d: ldarg.0
		IL_163e: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_1643: ldc.i4.1
		IL_1644: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_1649: nop
		IL_164a: ldarg.0
		IL_164b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_1650: ldc.i4.5
		IL_1651: ldc.i4.s 25
		IL_1653: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1658: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_165d: nop
		IL_165e: ldarg.0
		IL_165f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_1664: ldstr "label3"
		IL_1669: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_166e: nop
		IL_166f: ldarg.0
		IL_1670: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_1675: ldc.i4.s 53
		IL_1677: ldc.i4.s 12
		IL_1679: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_167e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1683: nop
		IL_1684: ldarg.0
		IL_1685: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_168a: ldc.i4.7
		IL_168b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1690: nop
		IL_1691: ldarg.0
		IL_1692: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::label3
		IL_1697: ldstr "数据单位"
		IL_169c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_16a1: nop
		IL_16a2: ldarg.0
		IL_16a3: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_16a8: ldc.i4.s 41
		IL_16aa: ldc.i4 182
		IL_16af: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_16b4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_16b9: nop
		IL_16ba: ldarg.0
		IL_16bb: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_16c0: ldstr "buttonZERO"
		IL_16c5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_16ca: nop
		IL_16cb: ldarg.0
		IL_16cc: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_16d1: ldc.i4.s 75
		IL_16d3: ldc.i4.s 23
		IL_16d5: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_16da: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_16df: nop
		IL_16e0: ldarg.0
		IL_16e1: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_16e6: ldc.i4.6
		IL_16e7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_16ec: nop
		IL_16ed: ldarg.0
		IL_16ee: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_16f3: ldstr "Zero"
		IL_16f8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_16fd: nop
		IL_16fe: ldarg.0
		IL_16ff: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_1704: ldc.i4.1
		IL_1705: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_170a: nop
		IL_170b: ldarg.0
		IL_170c: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonZERO
		IL_1711: ldarg.0
		IL_1712: ldftn instance void datapick.Form1::buttonZERO_Click(object, class [mscorlib]System.EventArgs)
		IL_1718: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_171d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_1722: nop
		IL_1723: ldarg.0
		IL_1724: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_1729: ldc.i4.s 41
		IL_172b: ldc.i4.s 119
		IL_172d: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1732: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1737: nop
		IL_1738: ldarg.0
		IL_1739: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_173e: ldstr "buttonSTART"
		IL_1743: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1748: nop
		IL_1749: ldarg.0
		IL_174a: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_174f: ldc.i4.s 75
		IL_1751: ldc.i4.s 23
		IL_1753: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1758: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_175d: nop
		IL_175e: ldarg.0
		IL_175f: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_1764: ldc.i4.4
		IL_1765: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_176a: nop
		IL_176b: ldarg.0
		IL_176c: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_1771: ldstr "开始"
		IL_1776: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_177b: nop
		IL_177c: ldarg.0
		IL_177d: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_1782: ldc.i4.1
		IL_1783: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_1788: nop
		IL_1789: ldarg.0
		IL_178a: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTART
		IL_178f: ldarg.0
		IL_1790: ldftn instance void datapick.Form1::buttonSTART_Click(object, class [mscorlib]System.EventArgs)
		IL_1796: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_179b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_17a0: nop
		IL_17a1: ldarg.0
		IL_17a2: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_17a7: ldc.i4.s 41
		IL_17a9: ldc.i4 151
		IL_17ae: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_17b3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_17b8: nop
		IL_17b9: ldarg.0
		IL_17ba: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_17bf: ldstr "buttonSTOP"
		IL_17c4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_17c9: nop
		IL_17ca: ldarg.0
		IL_17cb: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_17d0: ldc.i4.s 75
		IL_17d2: ldc.i4.s 23
		IL_17d4: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_17d9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_17de: nop
		IL_17df: ldarg.0
		IL_17e0: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_17e5: ldc.i4.5
		IL_17e6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_17eb: nop
		IL_17ec: ldarg.0
		IL_17ed: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_17f2: ldstr "停止"
		IL_17f7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_17fc: nop
		IL_17fd: ldarg.0
		IL_17fe: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_1803: ldc.i4.1
		IL_1804: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_1809: nop
		IL_180a: ldarg.0
		IL_180b: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.Form1::buttonSTOP
		IL_1810: ldarg.0
		IL_1811: ldftn instance void datapick.Form1::buttonSTOP_Click(object, class [mscorlib]System.EventArgs)
		IL_1817: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_181c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_1821: nop
		IL_1822: ldarg.0
		IL_1823: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_1828: ldc.i4.1
		IL_1829: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_182e: nop
		IL_182f: ldarg.0
		IL_1830: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_1835: ldc.i4 221
		IL_183a: ldc.i4.s 106
		IL_183c: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1841: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1846: nop
		IL_1847: ldarg.0
		IL_1848: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_184d: ldstr "labelSource"
		IL_1852: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1857: nop
		IL_1858: ldarg.0
		IL_1859: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_185e: ldc.i4.s 53
		IL_1860: ldc.i4.s 12
		IL_1862: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1867: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_186c: nop
		IL_186d: ldarg.0
		IL_186e: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_1873: ldc.i4.4
		IL_1874: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1879: nop
		IL_187a: ldarg.0
		IL_187b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_1880: ldstr "数据来源"
		IL_1885: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_188a: nop
		IL_188b: ldarg.0
		IL_188c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_1891: ldc.i4.0
		IL_1892: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_1897: nop
		IL_1898: ldarg.0
		IL_1899: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_189e: ldc.i4.2
		IL_189f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::set_DropDownStyle(valuetype [System.Windows.Forms]System.Windows.Forms.ComboBoxStyle)
		IL_18a4: nop
		IL_18a5: ldarg.0
		IL_18a6: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_18ab: ldc.i4.1
		IL_18ac: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_FormattingEnabled(bool)
		IL_18b1: nop
		IL_18b2: ldarg.0
		IL_18b3: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_18b8: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection [System.Windows.Forms]System.Windows.Forms.ComboBox::get_Items()
		IL_18bd: ldc.i4.3
		IL_18be: newarr [mscorlib]System.Object
		IL_18c3: stloc.1
		IL_18c4: ldloc.1
		IL_18c5: ldc.i4.0
		IL_18c6: ldstr "磁通计"
		IL_18cb: stelem.ref
		IL_18cc: ldloc.1
		IL_18cd: ldc.i4.1
		IL_18ce: ldstr "高斯计"
		IL_18d3: stelem.ref
		IL_18d4: ldloc.1
		IL_18d5: ldc.i4.2
		IL_18d6: ldstr "高斯计(弱磁)"
		IL_18db: stelem.ref
		IL_18dc: ldloc.1
		IL_18dd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox/ObjectCollection::AddRange(object[])
		IL_18e2: nop
		IL_18e3: ldarg.0
		IL_18e4: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_18e9: ldc.i4 280
		IL_18ee: ldc.i4.s 103
		IL_18f0: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_18f5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_18fa: nop
		IL_18fb: ldarg.0
		IL_18fc: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_1901: ldstr "comboBoxSource"
		IL_1906: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_190b: nop
		IL_190c: ldarg.0
		IL_190d: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_1912: ldc.i4.s 82
		IL_1914: ldc.i4.s 20
		IL_1916: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_191b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1920: nop
		IL_1921: ldarg.0
		IL_1922: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_1927: ldc.i4.5
		IL_1928: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_192d: nop
		IL_192e: ldarg.0
		IL_192f: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_1934: ldc.i4.0
		IL_1935: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Visible(bool)
		IL_193a: nop
		IL_193b: ldarg.0
		IL_193c: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_1941: ldarg.0
		IL_1942: ldftn instance void datapick.Form1::comboBoxSource_SelectedIndexChanged(object, class [mscorlib]System.EventArgs)
		IL_1948: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_194d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ComboBox::add_SelectedIndexChanged(class [mscorlib]System.EventHandler)
		IL_1952: nop
		IL_1953: ldarg.0
		IL_1954: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_1959: ldc.i4 25000
		IL_195e: callvirt instance void [System]System.IO.Ports.SerialPort::set_ReadBufferSize(int32)
		IL_1963: nop
		IL_1964: ldarg.0
		IL_1965: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_196a: ldc.i4.s 23
		IL_196c: callvirt instance void [System]System.IO.Ports.SerialPort::set_ReceivedBytesThreshold(int32)
		IL_1971: nop
		IL_1972: ldarg.0
		IL_1973: ldfld class [System]System.IO.Ports.SerialPort datapick.Form1::serialPort1
		IL_1978: ldarg.0
		IL_1979: ldftn instance void datapick.Form1::serialPort1_DataReceived(object, class [System]System.IO.Ports.SerialDataReceivedEventArgs)
		IL_197f: newobj instance void [System]System.IO.Ports.SerialDataReceivedEventHandler::.ctor(object, native int)
		IL_1984: callvirt instance void [System]System.IO.Ports.SerialPort::add_DataReceived(class [System]System.IO.Ports.SerialDataReceivedEventHandler)
		IL_1989: nop
		IL_198a: ldarg.0
		IL_198b: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_1990: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_1995: ldarg.0
		IL_1996: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_199b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_19a0: nop
		IL_19a1: ldarg.0
		IL_19a2: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_19a7: ldstr "宋体"
		IL_19ac: ldc.r4 13
		IL_19b1: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32)
		IL_19b6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_19bb: nop
		IL_19bc: ldarg.0
		IL_19bd: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_19c2: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Red()
		IL_19c7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_ForeColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_19cc: nop
		IL_19cd: ldarg.0
		IL_19ce: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_19d3: ldc.i4 599
		IL_19d8: ldc.i4.s 17
		IL_19da: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_19df: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_19e4: nop
		IL_19e5: ldarg.0
		IL_19e6: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_19eb: ldstr "groupBox5"
		IL_19f0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_19f5: nop
		IL_19f6: ldarg.0
		IL_19f7: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_19fc: ldc.i4 165
		IL_1a01: ldc.i4.s 84
		IL_1a03: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1a08: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1a0d: nop
		IL_1a0e: ldarg.0
		IL_1a0f: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_1a14: ldc.i4.s 17
		IL_1a16: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1a1b: nop
		IL_1a1c: ldarg.0
		IL_1a1d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_1a22: ldc.i4.0
		IL_1a23: callvirt instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::set_TabStop(bool)
		IL_1a28: nop
		IL_1a29: ldarg.0
		IL_1a2a: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_1a2f: ldstr "温度(℃)"
		IL_1a34: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1a39: nop
		IL_1a3a: ldarg.0
		IL_1a3b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1a40: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Blue()
		IL_1a45: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1a4a: nop
		IL_1a4b: ldarg.0
		IL_1a4c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1a51: ldstr "宋体"
		IL_1a56: ldc.r4 19
		IL_1a5b: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32)
		IL_1a60: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_1a65: nop
		IL_1a66: ldarg.0
		IL_1a67: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1a6c: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Yellow()
		IL_1a71: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_ForeColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1a76: nop
		IL_1a77: ldarg.0
		IL_1a78: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1a7d: ldc.i4.8
		IL_1a7e: ldc.i4.s 26
		IL_1a80: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1a85: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1a8a: nop
		IL_1a8b: ldarg.0
		IL_1a8c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1a91: ldstr "labelwendu"
		IL_1a96: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1a9b: nop
		IL_1a9c: ldarg.0
		IL_1a9d: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1aa2: ldc.i4 149
		IL_1aa7: ldc.i4.s 47
		IL_1aa9: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1aae: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1ab3: nop
		IL_1ab4: ldarg.0
		IL_1ab5: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1aba: ldc.i4.1
		IL_1abb: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1ac0: nop
		IL_1ac1: ldarg.0
		IL_1ac2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1ac7: ldstr "6666"
		IL_1acc: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Tag(object)
		IL_1ad1: nop
		IL_1ad2: ldarg.0
		IL_1ad3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1ad8: ldstr "null"
		IL_1add: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1ae2: nop
		IL_1ae3: ldarg.0
		IL_1ae4: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelwendu
		IL_1ae9: ldc.i4.s 32
		IL_1aeb: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Label::set_TextAlign(valuetype [System.Drawing]System.Drawing.ContentAlignment)
		IL_1af0: nop
		IL_1af1: ldarg.0
		IL_1af2: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1af7: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_1afc: ldarg.0
		IL_1afd: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1b02: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1b07: nop
		IL_1b08: ldarg.0
		IL_1b09: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b0e: ldstr "宋体"
		IL_1b13: ldc.r4 13
		IL_1b18: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32)
		IL_1b1d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_1b22: nop
		IL_1b23: ldarg.0
		IL_1b24: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b29: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Red()
		IL_1b2e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_ForeColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1b33: nop
		IL_1b34: ldarg.0
		IL_1b35: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b3a: ldc.i4 412
		IL_1b3f: ldc.i4.s 17
		IL_1b41: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1b46: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1b4b: nop
		IL_1b4c: ldarg.0
		IL_1b4d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b52: ldstr "groupBox4"
		IL_1b57: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1b5c: nop
		IL_1b5d: ldarg.0
		IL_1b5e: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b63: ldc.i4 165
		IL_1b68: ldc.i4.s 84
		IL_1b6a: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1b6f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1b74: nop
		IL_1b75: ldarg.0
		IL_1b76: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b7b: ldc.i4.s 16
		IL_1b7d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1b82: nop
		IL_1b83: ldarg.0
		IL_1b84: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b89: ldc.i4.0
		IL_1b8a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::set_TabStop(bool)
		IL_1b8f: nop
		IL_1b90: ldarg.0
		IL_1b91: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_1b96: ldstr "频率(Hz)"
		IL_1b9b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1ba0: nop
		IL_1ba1: ldarg.0
		IL_1ba2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1ba7: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Blue()
		IL_1bac: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1bb1: nop
		IL_1bb2: ldarg.0
		IL_1bb3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1bb8: ldstr "宋体"
		IL_1bbd: ldc.r4 19
		IL_1bc2: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32)
		IL_1bc7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_1bcc: nop
		IL_1bcd: ldarg.0
		IL_1bce: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1bd3: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Yellow()
		IL_1bd8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_ForeColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1bdd: nop
		IL_1bde: ldarg.0
		IL_1bdf: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1be4: ldc.i4.8
		IL_1be5: ldc.i4.s 26
		IL_1be7: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1bec: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1bf1: nop
		IL_1bf2: ldarg.0
		IL_1bf3: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1bf8: ldstr "labelpinlv"
		IL_1bfd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1c02: nop
		IL_1c03: ldarg.0
		IL_1c04: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1c09: ldc.i4 149
		IL_1c0e: ldc.i4.s 47
		IL_1c10: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1c15: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1c1a: nop
		IL_1c1b: ldarg.0
		IL_1c1c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1c21: ldc.i4.1
		IL_1c22: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1c27: nop
		IL_1c28: ldarg.0
		IL_1c29: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1c2e: ldstr "6666"
		IL_1c33: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Tag(object)
		IL_1c38: nop
		IL_1c39: ldarg.0
		IL_1c3a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1c3f: ldstr "null"
		IL_1c44: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1c49: nop
		IL_1c4a: ldarg.0
		IL_1c4b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelpinlv
		IL_1c50: ldc.i4.s 32
		IL_1c52: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Label::set_TextAlign(valuetype [System.Drawing]System.Drawing.ContentAlignment)
		IL_1c57: nop
		IL_1c58: ldarg.0
		IL_1c59: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1c5e: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_1c63: ldarg.0
		IL_1c64: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1c69: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_1c6e: nop
		IL_1c6f: ldarg.0
		IL_1c70: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1c75: ldstr "宋体"
		IL_1c7a: ldc.r4 13
		IL_1c7f: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32)
		IL_1c84: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_1c89: nop
		IL_1c8a: ldarg.0
		IL_1c8b: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1c90: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Red()
		IL_1c95: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_ForeColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1c9a: nop
		IL_1c9b: ldarg.0
		IL_1c9c: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1ca1: ldc.i4 223
		IL_1ca6: ldc.i4.s 17
		IL_1ca8: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1cad: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1cb2: nop
		IL_1cb3: ldarg.0
		IL_1cb4: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1cb9: ldstr "groupBox2"
		IL_1cbe: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1cc3: nop
		IL_1cc4: ldarg.0
		IL_1cc5: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1cca: ldc.i4 165
		IL_1ccf: ldc.i4.s 84
		IL_1cd1: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1cd6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1cdb: nop
		IL_1cdc: ldarg.0
		IL_1cdd: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1ce2: ldc.i4.s 15
		IL_1ce4: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1ce9: nop
		IL_1cea: ldarg.0
		IL_1ceb: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1cf0: ldc.i4.0
		IL_1cf1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.GroupBox::set_TabStop(bool)
		IL_1cf6: nop
		IL_1cf7: ldarg.0
		IL_1cf8: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_1cfd: ldstr "磁场值(mT)"
		IL_1d02: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1d07: nop
		IL_1d08: ldarg.0
		IL_1d09: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d0e: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Blue()
		IL_1d13: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1d18: nop
		IL_1d19: ldarg.0
		IL_1d1a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d1f: ldstr "宋体"
		IL_1d24: ldc.r4 19
		IL_1d29: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32)
		IL_1d2e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_1d33: nop
		IL_1d34: ldarg.0
		IL_1d35: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d3a: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Yellow()
		IL_1d3f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_ForeColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1d44: nop
		IL_1d45: ldarg.0
		IL_1d46: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d4b: ldc.i4.8
		IL_1d4c: ldc.i4.s 26
		IL_1d4e: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1d53: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1d58: nop
		IL_1d59: ldarg.0
		IL_1d5a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d5f: ldstr "labelcichang"
		IL_1d64: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1d69: nop
		IL_1d6a: ldarg.0
		IL_1d6b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d70: ldc.i4 149
		IL_1d75: ldc.i4.s 47
		IL_1d77: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1d7c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1d81: nop
		IL_1d82: ldarg.0
		IL_1d83: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d88: ldc.i4.0
		IL_1d89: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1d8e: nop
		IL_1d8f: ldarg.0
		IL_1d90: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1d95: ldstr "6666"
		IL_1d9a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Tag(object)
		IL_1d9f: nop
		IL_1da0: ldarg.0
		IL_1da1: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1da6: ldstr "null"
		IL_1dab: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1db0: nop
		IL_1db1: ldarg.0
		IL_1db2: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelcichang
		IL_1db7: ldc.i4.s 32
		IL_1db9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Label::set_TextAlign(valuetype [System.Drawing]System.Drawing.ContentAlignment)
		IL_1dbe: nop
		IL_1dbf: ldarg.0
		IL_1dc0: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerTIME
		IL_1dc5: ldc.i4.1
		IL_1dc6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Enabled(bool)
		IL_1dcb: nop
		IL_1dcc: ldarg.0
		IL_1dcd: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerTIME
		IL_1dd2: ldarg.0
		IL_1dd3: ldftn instance void datapick.Form1::timerTIME_Tick_1(object, class [mscorlib]System.EventArgs)
		IL_1dd9: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_1dde: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::add_Tick(class [mscorlib]System.EventHandler)
		IL_1de3: nop
		IL_1de4: ldarg.0
		IL_1de5: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1dea: ldc.i4.0
		IL_1deb: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_AllowUserToAddRows(bool)
		IL_1df0: nop
		IL_1df1: ldarg.0
		IL_1df2: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1df7: ldc.i4.0
		IL_1df8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_AllowUserToDeleteRows(bool)
		IL_1dfd: nop
		IL_1dfe: ldarg.0
		IL_1dff: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e04: ldc.i4.1
		IL_1e05: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Anchor(valuetype [System.Windows.Forms]System.Windows.Forms.AnchorStyles)
		IL_1e0a: nop
		IL_1e0b: ldarg.0
		IL_1e0c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e11: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.SystemColors::get_ScrollBar()
		IL_1e16: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_BackgroundColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1e1b: nop
		IL_1e1c: ldarg.0
		IL_1e1d: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e22: ldc.i4.2
		IL_1e23: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_ColumnHeadersHeightSizeMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode)
		IL_1e28: nop
		IL_1e29: ldarg.0
		IL_1e2a: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e2f: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.Color::get_Navy()
		IL_1e34: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_GridColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_1e39: nop
		IL_1e3a: ldarg.0
		IL_1e3b: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e40: ldc.i4.1
		IL_1e41: ldc.i4.3
		IL_1e42: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1e47: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1e4c: nop
		IL_1e4d: ldarg.0
		IL_1e4e: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e53: ldstr "dataGridViewDATA"
		IL_1e58: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1e5d: nop
		IL_1e5e: ldarg.0
		IL_1e5f: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e64: ldc.i4.1
		IL_1e65: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_ReadOnly(bool)
		IL_1e6a: nop
		IL_1e6b: ldarg.0
		IL_1e6c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e71: callvirt instance class [System.Windows.Forms]System.Windows.Forms.DataGridViewRow [System.Windows.Forms]System.Windows.Forms.DataGridView::get_RowTemplate()
		IL_1e76: ldc.i4.s 23
		IL_1e78: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridViewRow::set_Height(int32)
		IL_1e7d: nop
		IL_1e7e: ldarg.0
		IL_1e7f: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e84: ldc.i4.1
		IL_1e85: callvirt instance void [System.Windows.Forms]System.Windows.Forms.DataGridView::set_SelectionMode(valuetype [System.Windows.Forms]System.Windows.Forms.DataGridViewSelectionMode)
		IL_1e8a: nop
		IL_1e8b: ldarg.0
		IL_1e8c: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1e91: ldc.i4 541
		IL_1e96: ldc.i4 200
		IL_1e9b: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1ea0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1ea5: nop
		IL_1ea6: ldarg.0
		IL_1ea7: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_1eac: ldc.i4.s 18
		IL_1eae: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1eb3: nop
		IL_1eb4: ldarg.0
		IL_1eb5: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_1eba: callvirt instance class [System.Windows.Forms]System.Windows.Forms.ToolStripItemCollection [System.Windows.Forms]System.Windows.Forms.ToolStrip::get_Items()
		IL_1ebf: ldc.i4.2
		IL_1ec0: newarr [System.Windows.Forms]System.Windows.Forms.ToolStripItem
		IL_1ec5: stloc.2
		IL_1ec6: ldloc.2
		IL_1ec7: ldc.i4.0
		IL_1ec8: ldarg.0
		IL_1ec9: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::ToolStripStatusLabel1
		IL_1ece: stelem.ref
		IL_1ecf: ldloc.2
		IL_1ed0: ldc.i4.1
		IL_1ed1: ldarg.0
		IL_1ed2: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::toolStripStatusLabel2
		IL_1ed7: stelem.ref
		IL_1ed8: ldloc.2
		IL_1ed9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItemCollection::AddRange(class [System.Windows.Forms]System.Windows.Forms.ToolStripItem[])
		IL_1ede: nop
		IL_1edf: ldarg.0
		IL_1ee0: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_1ee5: ldc.i4.0
		IL_1ee6: ldc.i4 539
		IL_1eeb: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1ef0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1ef5: nop
		IL_1ef6: ldarg.0
		IL_1ef7: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_1efc: ldstr "StatusStrip1"
		IL_1f01: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1f06: nop
		IL_1f07: ldarg.0
		IL_1f08: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_1f0d: ldc.i4 784
		IL_1f12: ldc.i4.s 22
		IL_1f14: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1f19: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1f1e: nop
		IL_1f1f: ldarg.0
		IL_1f20: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_1f25: ldc.i4.s 19
		IL_1f27: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_1f2c: nop
		IL_1f2d: ldarg.0
		IL_1f2e: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_1f33: ldstr "statusStrip1"
		IL_1f38: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_1f3d: nop
		IL_1f3e: ldarg.0
		IL_1f3f: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::ToolStripStatusLabel1
		IL_1f44: ldstr "ToolStripStatusLabel1"
		IL_1f49: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Name(string)
		IL_1f4e: nop
		IL_1f4f: ldarg.0
		IL_1f50: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::ToolStripStatusLabel1
		IL_1f55: ldc.i4.s 44
		IL_1f57: ldc.i4.s 17
		IL_1f59: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1f5e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1f63: nop
		IL_1f64: ldarg.0
		IL_1f65: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::ToolStripStatusLabel1
		IL_1f6a: ldstr "状态栏"
		IL_1f6f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Text(string)
		IL_1f74: nop
		IL_1f75: ldarg.0
		IL_1f76: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::ToolStripStatusLabel1
		IL_1f7b: ldc.i4.0
		IL_1f7c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Visible(bool)
		IL_1f81: nop
		IL_1f82: ldarg.0
		IL_1f83: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::toolStripStatusLabel2
		IL_1f88: ldstr "toolStripStatusLabel2"
		IL_1f8d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Name(string)
		IL_1f92: nop
		IL_1f93: ldarg.0
		IL_1f94: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::toolStripStatusLabel2
		IL_1f99: ldc.i4 128
		IL_1f9e: ldc.i4.s 17
		IL_1fa0: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_1fa5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_1faa: nop
		IL_1fab: ldarg.0
		IL_1fac: ldfld class [System.Windows.Forms]System.Windows.Forms.ToolStripStatusLabel datapick.Form1::toolStripStatusLabel2
		IL_1fb1: ldstr "北京翠海科贸有限公司"
		IL_1fb6: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ToolStripItem::set_Text(string)
		IL_1fbb: nop
		IL_1fbc: ldarg.0
		IL_1fbd: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_1fc2: ldc.i4.3
		IL_1fc3: ldc.i4.4
		IL_1fc4: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_1fc9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_1fce: nop
		IL_1fcf: ldarg.0
		IL_1fd0: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_1fd5: ldstr "zedTIME"
		IL_1fda: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_1fdf: nop
		IL_1fe0: ldarg.0
		IL_1fe1: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_1fe6: ldc.r8 0.0
		IL_1fef: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollGrace(float64)
		IL_1ff4: nop
		IL_1ff5: ldarg.0
		IL_1ff6: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_1ffb: ldc.r8 0.0
		IL_2004: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollMaxX(float64)
		IL_2009: nop
		IL_200a: ldarg.0
		IL_200b: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_2010: ldc.r8 0.0
		IL_2019: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollMaxY(float64)
		IL_201e: nop
		IL_201f: ldarg.0
		IL_2020: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_2025: ldc.r8 0.0
		IL_202e: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollMaxY2(float64)
		IL_2033: nop
		IL_2034: ldarg.0
		IL_2035: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_203a: ldc.r8 0.0
		IL_2043: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollMinX(float64)
		IL_2048: nop
		IL_2049: ldarg.0
		IL_204a: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_204f: ldc.r8 0.0
		IL_2058: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollMinY(float64)
		IL_205d: nop
		IL_205e: ldarg.0
		IL_205f: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_2064: ldc.r8 0.0
		IL_206d: callvirt instance void [ZedGraph]ZedGraph.ZedGraphControl::set_ScrollMinY2(float64)
		IL_2072: nop
		IL_2073: ldarg.0
		IL_2074: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_2079: ldc.i4 541
		IL_207e: ldc.i4 203
		IL_2083: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_2088: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_208d: nop
		IL_208e: ldarg.0
		IL_208f: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_2094: ldc.i4.s 20
		IL_2096: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_209b: nop
		IL_209c: ldarg.0
		IL_209d: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timer1
		IL_20a2: ldarg.0
		IL_20a3: ldftn instance void datapick.Form1::timer1_Tick(object, class [mscorlib]System.EventArgs)
		IL_20a9: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_20ae: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::add_Tick(class [mscorlib]System.EventHandler)
		IL_20b3: nop
		IL_20b4: ldarg.0
		IL_20b5: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerRecieve
		IL_20ba: ldc.i4 200
		IL_20bf: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_20c4: nop
		IL_20c5: ldarg.0
		IL_20c6: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerRecieve
		IL_20cb: ldarg.0
		IL_20cc: ldftn instance void datapick.Form1::timerRecieve_Tick(object, class [mscorlib]System.EventArgs)
		IL_20d2: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_20d7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::add_Tick(class [mscorlib]System.EventHandler)
		IL_20dc: nop
		IL_20dd: ldarg.0
		IL_20de: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerUSBread
		IL_20e3: ldc.i4 200
		IL_20e8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::set_Interval(int32)
		IL_20ed: nop
		IL_20ee: ldarg.0
		IL_20ef: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerUSBread
		IL_20f4: ldarg.0
		IL_20f5: ldftn instance void datapick.Form1::timerUSBread_Tick(object, class [mscorlib]System.EventArgs)
		IL_20fb: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_2100: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::add_Tick(class [mscorlib]System.EventHandler)
		IL_2105: nop
		IL_2106: ldarg.0
		IL_2107: ldfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.Form1::timerType
		IL_210c: ldarg.0
		IL_210d: ldftn instance void datapick.Form1::timerType_Tick(object, class [mscorlib]System.EventArgs)
		IL_2113: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_2118: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Timer::add_Tick(class [mscorlib]System.EventHandler)
		IL_211d: nop
		IL_211e: ldarg.0
		IL_211f: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2124: ldc.i4.2
		IL_2125: callvirt instance void [System.Windows.Forms]System.Windows.Forms.SplitContainer::set_BorderStyle(valuetype [System.Windows.Forms]System.Windows.Forms.BorderStyle)
		IL_212a: nop
		IL_212b: ldarg.0
		IL_212c: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2131: ldc.i4 223
		IL_2136: ldc.i4.s 106
		IL_2138: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_213d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_2142: nop
		IL_2143: ldarg.0
		IL_2144: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2149: ldstr "splitContainer1"
		IL_214e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_2153: nop
		IL_2154: ldarg.0
		IL_2155: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_215a: ldc.i4.0
		IL_215b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.SplitContainer::set_Orientation(valuetype [System.Windows.Forms]System.Windows.Forms.Orientation)
		IL_2160: nop
		IL_2161: ldarg.0
		IL_2162: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2167: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel1()
		IL_216c: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_2171: ldarg.0
		IL_2172: ldfld class [ZedGraph]ZedGraph.ZedGraphControl datapick.Form1::zedTIME
		IL_2177: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_217c: nop
		IL_217d: ldarg.0
		IL_217e: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2183: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel1()
		IL_2188: ldarg.0
		IL_2189: ldftn instance void datapick.Form1::splitContainer1_Panel1_SizeChanged(object, class [mscorlib]System.EventArgs)
		IL_218f: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_2194: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_SizeChanged(class [mscorlib]System.EventHandler)
		IL_2199: nop
		IL_219a: ldarg.0
		IL_219b: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_21a0: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel1()
		IL_21a5: ldarg.0
		IL_21a6: ldftn instance void datapick.Form1::splitContainer1_Panel1_Resize(object, class [mscorlib]System.EventArgs)
		IL_21ac: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_21b1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Resize(class [mscorlib]System.EventHandler)
		IL_21b6: nop
		IL_21b7: ldarg.0
		IL_21b8: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_21bd: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel2()
		IL_21c2: callvirt instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_21c7: ldarg.0
		IL_21c8: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_21cd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_21d2: nop
		IL_21d3: ldarg.0
		IL_21d4: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_21d9: ldc.i4 549
		IL_21de: ldc.i4 428
		IL_21e3: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_21e8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_21ed: nop
		IL_21ee: ldarg.0
		IL_21ef: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_21f4: ldc.i4 214
		IL_21f9: callvirt instance void [System.Windows.Forms]System.Windows.Forms.SplitContainer::set_SplitterDistance(int32)
		IL_21fe: nop
		IL_21ff: ldarg.0
		IL_2200: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2205: ldc.i4.s 21
		IL_2207: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_220c: nop
		IL_220d: ldarg.0
		IL_220e: ldc.r4 6
		IL_2213: ldc.r4 12
		IL_2218: newobj instance void [System.Drawing]System.Drawing.SizeF::.ctor(float32, float32)
		IL_221d: call instance void [System.Windows.Forms]System.Windows.Forms.ContainerControl::set_AutoScaleDimensions(valuetype [System.Drawing]System.Drawing.SizeF)
		IL_2222: nop
		IL_2223: ldarg.0
		IL_2224: ldc.i4.1
		IL_2225: call instance void [System.Windows.Forms]System.Windows.Forms.ContainerControl::set_AutoScaleMode(valuetype [System.Windows.Forms]System.Windows.Forms.AutoScaleMode)
		IL_222a: nop
		IL_222b: ldarg.0
		IL_222c: call valuetype [System.Drawing]System.Drawing.Color [System.Drawing]System.Drawing.SystemColors::get_Control()
		IL_2231: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_BackColor(valuetype [System.Drawing]System.Drawing.Color)
		IL_2236: nop
		IL_2237: ldarg.0
		IL_2238: ldc.i4 784
		IL_223d: ldc.i4 561
		IL_2242: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_2247: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_ClientSize(valuetype [System.Drawing]System.Drawing.Size)
		IL_224c: nop
		IL_224d: ldarg.0
		IL_224e: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_2253: ldarg.0
		IL_2254: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_2259: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_225e: nop
		IL_225f: ldarg.0
		IL_2260: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_2265: ldarg.0
		IL_2266: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_226b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_2270: nop
		IL_2271: ldarg.0
		IL_2272: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_2277: ldarg.0
		IL_2278: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_227d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_2282: nop
		IL_2283: ldarg.0
		IL_2284: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_2289: ldarg.0
		IL_228a: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_228f: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_2294: nop
		IL_2295: ldarg.0
		IL_2296: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_229b: ldarg.0
		IL_229c: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_22a1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_22a6: nop
		IL_22a7: ldarg.0
		IL_22a8: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_22ad: ldarg.0
		IL_22ae: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_22b3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_22b8: nop
		IL_22b9: ldarg.0
		IL_22ba: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_22bf: ldarg.0
		IL_22c0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.Form1::labelSource
		IL_22c5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_22ca: nop
		IL_22cb: ldarg.0
		IL_22cc: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_22d1: ldarg.0
		IL_22d2: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxSource
		IL_22d7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_22dc: nop
		IL_22dd: ldarg.0
		IL_22de: ldloc.0
		IL_22df: ldstr "$this.Icon"
		IL_22e4: callvirt instance object [mscorlib]System.Resources.ResourceManager::GetObject(string)
		IL_22e9: castclass [System.Drawing]System.Drawing.Icon
		IL_22ee: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_Icon(class [System.Drawing]System.Drawing.Icon)
		IL_22f3: nop
		IL_22f4: ldarg.0
		IL_22f5: ldc.i4.0
		IL_22f6: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_MaximizeBox(bool)
		IL_22fb: nop
		IL_22fc: ldarg.0
		IL_22fd: ldc.i4 800
		IL_2302: ldc.i4 600
		IL_2307: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_230c: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_MaximumSize(valuetype [System.Drawing]System.Drawing.Size)
		IL_2311: nop
		IL_2312: ldarg.0
		IL_2313: ldc.i4 800
		IL_2318: ldc.i4 600
		IL_231d: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_2322: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_MinimumSize(valuetype [System.Drawing]System.Drawing.Size)
		IL_2327: nop
		IL_2328: ldarg.0
		IL_2329: ldstr "Form1"
		IL_232e: call instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_2333: nop
		IL_2334: ldarg.0
		IL_2335: ldc.i4.1
		IL_2336: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_StartPosition(valuetype [System.Windows.Forms]System.Windows.Forms.FormStartPosition)
		IL_233b: nop
		IL_233c: ldarg.0
		IL_233d: ldstr "CH-Hall数据采集软件"
		IL_2342: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_2347: nop
		IL_2348: ldarg.0
		IL_2349: ldarg.0
		IL_234a: ldftn instance void datapick.Form1::Form1_FormClosing(object, class [System.Windows.Forms]System.Windows.Forms.FormClosingEventArgs)
		IL_2350: newobj instance void [System.Windows.Forms]System.Windows.Forms.FormClosingEventHandler::.ctor(object, native int)
		IL_2355: call instance void [System.Windows.Forms]System.Windows.Forms.Form::add_FormClosing(class [System.Windows.Forms]System.Windows.Forms.FormClosingEventHandler)
		IL_235a: nop
		IL_235b: ldarg.0
		IL_235c: ldarg.0
		IL_235d: ldftn instance void datapick.Form1::Form1_Load(object, class [mscorlib]System.EventArgs)
		IL_2363: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_2368: call instance void [System.Windows.Forms]System.Windows.Forms.Form::add_Load(class [mscorlib]System.EventHandler)
		IL_236d: nop
		IL_236e: ldarg.0
		IL_236f: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_2374: ldc.i4.0
		IL_2375: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_237a: nop
		IL_237b: ldarg.0
		IL_237c: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox1
		IL_2381: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
		IL_2386: nop
		IL_2387: ldarg.0
		IL_2388: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_238d: ldc.i4.0
		IL_238e: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_2393: nop
		IL_2394: ldarg.0
		IL_2395: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_239a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
		IL_239f: nop
		IL_23a0: ldarg.0
		IL_23a1: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_23a6: ldc.i4.0
		IL_23a7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_23ac: nop
		IL_23ad: ldarg.0
		IL_23ae: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox3
		IL_23b3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
		IL_23b8: nop
		IL_23b9: ldarg.0
		IL_23ba: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox5
		IL_23bf: ldc.i4.0
		IL_23c0: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_23c5: nop
		IL_23c6: ldarg.0
		IL_23c7: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox4
		IL_23cc: ldc.i4.0
		IL_23cd: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_23d2: nop
		IL_23d3: ldarg.0
		IL_23d4: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox2
		IL_23d9: ldc.i4.0
		IL_23da: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_23df: nop
		IL_23e0: ldarg.0
		IL_23e1: ldfld class [System.Windows.Forms]System.Windows.Forms.DataGridView datapick.Form1::dataGridViewDATA
		IL_23e6: callvirt instance void [System]System.ComponentModel.ISupportInitialize::EndInit()
		IL_23eb: nop
		IL_23ec: ldarg.0
		IL_23ed: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_23f2: ldc.i4.0
		IL_23f3: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_23f8: nop
		IL_23f9: ldarg.0
		IL_23fa: ldfld class [System.Windows.Forms]System.Windows.Forms.StatusStrip datapick.Form1::StatusStrip1
		IL_23ff: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
		IL_2404: nop
		IL_2405: ldarg.0
		IL_2406: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_240b: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel1()
		IL_2410: ldc.i4.0
		IL_2411: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_2416: nop
		IL_2417: ldarg.0
		IL_2418: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_241d: callvirt instance class [System.Windows.Forms]System.Windows.Forms.SplitterPanel [System.Windows.Forms]System.Windows.Forms.SplitContainer::get_Panel2()
		IL_2422: ldc.i4.0
		IL_2423: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_2428: nop
		IL_2429: ldarg.0
		IL_242a: ldfld class [System.Windows.Forms]System.Windows.Forms.SplitContainer datapick.Form1::splitContainer1
		IL_242f: ldc.i4.0
		IL_2430: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_2435: nop
		IL_2436: ldarg.0
		IL_2437: ldc.i4.0
		IL_2438: call instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_243d: nop
		IL_243e: ldarg.0
		IL_243f: call instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
		IL_2444: nop
		IL_2445: ret
	} // end of method Form1::InitializeComponent

	.method private hidebysig specialname rtspecialname static 
		void .cctor () cil managed 
	{
		// Method begins at RVA 0x99a2
		// Header size: 1
		// Code size: 7 (0x7)
		.maxstack 8

		IL_0000: ldnull
		IL_0001: stsfld class datapick.Form1 datapick.Form1::mf
		IL_0006: ret
	} // end of method Form1::.cctor

} // end of class datapick.Form1

.class private auto ansi abstract sealed beforefieldinit datapick.Program
	extends [mscorlib]System.Object
{
	// Methods
	.method private hidebysig static 
		void Main () cil managed 
	{
		.custom instance void [mscorlib]System.STAThreadAttribute::.ctor() = (
			01 00 00 00
		)
		// Method begins at RVA 0x99e1
		// Header size: 1
		// Code size: 26 (0x1a)
		.maxstack 8
		.entrypoint

		IL_0000: nop
		IL_0001: call void [System.Windows.Forms]System.Windows.Forms.Application::EnableVisualStyles()
		IL_0006: nop
		IL_0007: ldc.i4.0
		IL_0008: call void [System.Windows.Forms]System.Windows.Forms.Application::SetCompatibleTextRenderingDefault(bool)
		IL_000d: nop
		IL_000e: newobj instance void datapick.Form1::.ctor()
		IL_0013: call void [System.Windows.Forms]System.Windows.Forms.Application::Run(class [System.Windows.Forms]System.Windows.Forms.Form)
		IL_0018: nop
		IL_0019: ret
	} // end of method Program::Main

} // end of class datapick.Program

.class private auto ansi beforefieldinit datapick.Properties.Resources
	extends [mscorlib]System.Object
{
	.custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string, string) = (
		01 00 33 53 79 73 74 65 6d 2e 52 65 73 6f 75 72
		63 65 73 2e 54 6f 6f 6c 73 2e 53 74 72 6f 6e 67
		6c 79 54 79 70 65 64 52 65 73 6f 75 72 63 65 42
		75 69 6c 64 65 72 07 34 2e 30 2e 30 2e 30 00 00
	)
	.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = (
		01 00 00 00
	)
	.custom instance void [mscorlib]System.Diagnostics.DebuggerNonUserCodeAttribute::.ctor() = (
		01 00 00 00
	)
	// Fields
	.field private static class [mscorlib]System.Resources.ResourceManager resourceMan
	.field private static class [mscorlib]System.Globalization.CultureInfo resourceCulture

	// Methods
	.method assembly hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x99fc
		// Header size: 1
		// Code size: 10 (0xa)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [mscorlib]System.Object::.ctor()
		IL_0006: nop
		IL_0007: nop
		IL_0008: nop
		IL_0009: ret
	} // end of method Resources::.ctor

	.method assembly hidebysig specialname static 
		class [mscorlib]System.Resources.ResourceManager get_ResourceManager () cil managed 
	{
		// Method begins at RVA 0x9a08
		// Header size: 12
		// Code size: 63 (0x3f)
		.maxstack 2
		.locals init (
			[0] class [mscorlib]System.Resources.ResourceManager temp,
			[1] class [mscorlib]System.Resources.ResourceManager CS$1$0000,
			[2] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldsfld class [mscorlib]System.Resources.ResourceManager datapick.Properties.Resources::resourceMan
		IL_0006: ldnull
		IL_0007: call bool [mscorlib]System.Object::ReferenceEquals(object, object)
		IL_000c: ldc.i4.0
		IL_000d: ceq
		IL_000f: stloc.2
		IL_0010: ldloc.2
		IL_0011: brtrue.s IL_0035

		IL_0013: nop
		IL_0014: ldstr "datapick.Properties.Resources"
		IL_0019: ldtoken datapick.Properties.Resources
		IL_001e: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_0023: callvirt instance class [mscorlib]System.Reflection.Assembly [mscorlib]System.Type::get_Assembly()
		IL_0028: newobj instance void [mscorlib]System.Resources.ResourceManager::.ctor(string, class [mscorlib]System.Reflection.Assembly)
		IL_002d: stloc.0
		IL_002e: ldloc.0
		IL_002f: stsfld class [mscorlib]System.Resources.ResourceManager datapick.Properties.Resources::resourceMan
		IL_0034: nop

		IL_0035: ldsfld class [mscorlib]System.Resources.ResourceManager datapick.Properties.Resources::resourceMan
		IL_003a: stloc.1
		IL_003b: br.s IL_003d

		IL_003d: ldloc.1
		IL_003e: ret
	} // end of method Resources::get_ResourceManager

	.method assembly hidebysig specialname static 
		class [mscorlib]System.Globalization.CultureInfo get_Culture () cil managed 
	{
		// Method begins at RVA 0x9a54
		// Header size: 12
		// Code size: 11 (0xb)
		.maxstack 1
		.locals init (
			[0] class [mscorlib]System.Globalization.CultureInfo CS$1$0000
		)

		IL_0000: nop
		IL_0001: ldsfld class [mscorlib]System.Globalization.CultureInfo datapick.Properties.Resources::resourceCulture
		IL_0006: stloc.0
		IL_0007: br.s IL_0009

		IL_0009: ldloc.0
		IL_000a: ret
	} // end of method Resources::get_Culture

	.method assembly hidebysig specialname static 
		void set_Culture (
			class [mscorlib]System.Globalization.CultureInfo 'value'
		) cil managed 
	{
		// Method begins at RVA 0x9a6b
		// Header size: 1
		// Code size: 8 (0x8)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: stsfld class [mscorlib]System.Globalization.CultureInfo datapick.Properties.Resources::resourceCulture
		IL_0007: ret
	} // end of method Resources::set_Culture

	// Properties
	.property class [mscorlib]System.Resources.ResourceManager ResourceManager()
	{
		.custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = (
			01 00 02 00 00 00 00 00
		)
		.get class [mscorlib]System.Resources.ResourceManager datapick.Properties.Resources::get_ResourceManager()
	}
	.property class [mscorlib]System.Globalization.CultureInfo Culture()
	{
		.custom instance void [System]System.ComponentModel.EditorBrowsableAttribute::.ctor(valuetype [System]System.ComponentModel.EditorBrowsableState) = (
			01 00 02 00 00 00 00 00
		)
		.get class [mscorlib]System.Globalization.CultureInfo datapick.Properties.Resources::get_Culture()
		.set void datapick.Properties.Resources::set_Culture(class [mscorlib]System.Globalization.CultureInfo)
	}

} // end of class datapick.Properties.Resources

.class private auto ansi sealed beforefieldinit datapick.Properties.Settings
	extends [System]System.Configuration.ApplicationSettingsBase
{
	.custom instance void [mscorlib]System.Runtime.CompilerServices.CompilerGeneratedAttribute::.ctor() = (
		01 00 00 00
	)
	.custom instance void [System]System.CodeDom.Compiler.GeneratedCodeAttribute::.ctor(string, string) = (
		01 00 4b 4d 69 63 72 6f 73 6f 66 74 2e 56 69 73
		75 61 6c 53 74 75 64 69 6f 2e 45 64 69 74 6f 72
		73 2e 53 65 74 74 69 6e 67 73 44 65 73 69 67 6e
		65 72 2e 53 65 74 74 69 6e 67 73 53 69 6e 67 6c
		65 46 69 6c 65 47 65 6e 65 72 61 74 6f 72 08 31
		32 2e 30 2e 30 2e 30 00 00
	)
	// Fields
	.field private static class datapick.Properties.Settings defaultInstance

	// Methods
	.method public hidebysig specialname static 
		class datapick.Properties.Settings get_Default () cil managed 
	{
		// Method begins at RVA 0x9a74
		// Header size: 12
		// Code size: 11 (0xb)
		.maxstack 1
		.locals init (
			[0] class datapick.Properties.Settings CS$1$0000
		)

		IL_0000: nop
		IL_0001: ldsfld class datapick.Properties.Settings datapick.Properties.Settings::defaultInstance
		IL_0006: stloc.0
		IL_0007: br.s IL_0009

		IL_0009: ldloc.0
		IL_000a: ret
	} // end of method Settings::get_Default

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0x9aa1
		// Header size: 1
		// Code size: 7 (0x7)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [System]System.Configuration.ApplicationSettingsBase::.ctor()
		IL_0006: ret
	} // end of method Settings::.ctor

	.method private hidebysig specialname rtspecialname static 
		void .cctor () cil managed 
	{
		// Method begins at RVA 0x9a8b
		// Header size: 1
		// Code size: 21 (0x15)
		.maxstack 8

		IL_0000: newobj instance void datapick.Properties.Settings::.ctor()
		IL_0005: call class [System]System.Configuration.SettingsBase [System]System.Configuration.SettingsBase::Synchronized(class [System]System.Configuration.SettingsBase)
		IL_000a: castclass datapick.Properties.Settings
		IL_000f: stsfld class datapick.Properties.Settings datapick.Properties.Settings::defaultInstance
		IL_0014: ret
	} // end of method Settings::.cctor

	// Properties
	.property class datapick.Properties.Settings Default()
	{
		.get class datapick.Properties.Settings datapick.Properties.Settings::get_Default()
	}

} // end of class datapick.Properties.Settings

.class public auto ansi beforefieldinit datapick.SystemConfig
	extends [mscorlib]System.Object
{
	// Fields
	.field private static string CONFIG_FILE

	// Methods
	.method private hidebysig static 
		string GetWorkDirectory () cil managed 
	{
		// Method begins at RVA 0x9aac
		// Header size: 12
		// Code size: 43 (0x2b)
		.maxstack 1
		.locals init (
			[0] string CS$1$0000
		)

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldtoken datapick.SystemConfig
			IL_0007: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_000c: callvirt instance class [mscorlib]System.Reflection.Assembly [mscorlib]System.Type::get_Assembly()
			IL_0011: callvirt instance string [mscorlib]System.Reflection.Assembly::get_Location()
			IL_0016: call string [mscorlib]System.IO.Path::GetDirectoryName(string)
			IL_001b: stloc.0
			IL_001c: leave.s IL_0028
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_001e: pop
			IL_001f: nop
			IL_0020: call string [System.Windows.Forms]System.Windows.Forms.Application::get_StartupPath()
			IL_0025: stloc.0
			IL_0026: leave.s IL_0028
		} // end handler

		IL_0028: nop
		IL_0029: ldloc.0
		IL_002a: ret
	} // end of method SystemConfig::GetWorkDirectory

	.method private hidebysig static 
		bool IsEmptyString (
			string szString
		) cil managed 
	{
		// Method begins at RVA 0x9af4
		// Header size: 12
		// Code size: 49 (0x31)
		.maxstack 2
		.locals init (
			[0] bool CS$1$0000,
			[1] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldnull
		IL_0003: ceq
		IL_0005: ldc.i4.0
		IL_0006: ceq
		IL_0008: stloc.1
		IL_0009: ldloc.1
		IL_000a: brtrue.s IL_0010

		IL_000c: ldc.i4.1
		IL_000d: stloc.0
		IL_000e: br.s IL_002f

		IL_0010: ldarg.0
		IL_0011: callvirt instance string [mscorlib]System.String::Trim()
		IL_0016: ldsfld string [mscorlib]System.String::Empty
		IL_001b: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0020: ldc.i4.0
		IL_0021: ceq
		IL_0023: stloc.1
		IL_0024: ldloc.1
		IL_0025: brtrue.s IL_002b

		IL_0027: ldc.i4.1
		IL_0028: stloc.0
		IL_0029: br.s IL_002f

		IL_002b: ldc.i4.0
		IL_002c: stloc.0
		IL_002d: br.s IL_002f

		IL_002f: ldloc.0
		IL_0030: ret
	} // end of method SystemConfig::IsEmptyString

	.method private hidebysig static 
		bool CreateXmlFile (
			string szFileName,
			string szRootName
		) cil managed 
	{
		// Method begins at RVA 0x9b34
		// Header size: 12
		// Code size: 141 (0x8d)
		.maxstack 5
		.locals init (
			[0] class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			[1] bool CS$1$0000,
			[2] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: brfalse.s IL_0019

		IL_0004: ldarg.0
		IL_0005: callvirt instance string [mscorlib]System.String::Trim()
		IL_000a: ldstr ""
		IL_000f: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0014: ldc.i4.0
		IL_0015: ceq
		IL_0017: br.s IL_001a

		IL_0019: ldc.i4.0

		IL_001a: nop
		IL_001b: stloc.2
		IL_001c: ldloc.2
		IL_001d: brtrue.s IL_0023

		IL_001f: ldc.i4.0
		IL_0020: stloc.1
		IL_0021: br.s IL_008a

		IL_0023: ldarg.1
		IL_0024: brfalse.s IL_003b

		IL_0026: ldarg.1
		IL_0027: callvirt instance string [mscorlib]System.String::Trim()
		IL_002c: ldstr ""
		IL_0031: call bool [mscorlib]System.String::op_Equality(string, string)
		IL_0036: ldc.i4.0
		IL_0037: ceq
		IL_0039: br.s IL_003c

		IL_003b: ldc.i4.0

		IL_003c: nop
		IL_003d: stloc.2
		IL_003e: ldloc.2
		IL_003f: brtrue.s IL_0045

		IL_0041: ldc.i4.0
		IL_0042: stloc.1
		IL_0043: br.s IL_008a

		IL_0045: newobj instance void [System.Xml]System.Xml.XmlDocument::.ctor()
		IL_004a: stloc.0
		IL_004b: ldloc.0
		IL_004c: ldloc.0
		IL_004d: ldstr "1.0"
		IL_0052: ldstr "GBK"
		IL_0057: ldnull
		IL_0058: callvirt instance class [System.Xml]System.Xml.XmlDeclaration [System.Xml]System.Xml.XmlDocument::CreateXmlDeclaration(string, string, string)
		IL_005d: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::AppendChild(class [System.Xml]System.Xml.XmlNode)
		IL_0062: pop
		IL_0063: ldloc.0
		IL_0064: ldloc.0
		IL_0065: ldc.i4.1
		IL_0066: ldarg.1
		IL_0067: ldstr ""
		IL_006c: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlDocument::CreateNode(valuetype [System.Xml]System.Xml.XmlNodeType, string, string)
		IL_0071: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::AppendChild(class [System.Xml]System.Xml.XmlNode)
		IL_0076: pop
		.try
		{
			IL_0077: nop
			IL_0078: ldloc.0
			IL_0079: ldarg.0
			IL_007a: callvirt instance void [System.Xml]System.Xml.XmlDocument::Save(string)
			IL_007f: nop
			IL_0080: ldc.i4.1
			IL_0081: stloc.1
			IL_0082: leave.s IL_008a
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0084: pop
			IL_0085: nop
			IL_0086: ldc.i4.0
			IL_0087: stloc.1
			IL_0088: leave.s IL_008a
		} // end handler

		IL_008a: nop
		IL_008b: ldloc.1
		IL_008c: ret
	} // end of method SystemConfig::CreateXmlFile

	.method private hidebysig static 
		class [System.Xml]System.Xml.XmlDocument GetXmlDocument (
			string szXmlFile
		) cil managed 
	{
		// Method begins at RVA 0x9be0
		// Header size: 12
		// Code size: 64 (0x40)
		.maxstack 2
		.locals init (
			[0] class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			[1] class [System.Xml]System.Xml.XmlDocument CS$1$0000,
			[2] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: call bool datapick.SystemConfig::IsEmptyString(string)
		IL_0007: ldc.i4.0
		IL_0008: ceq
		IL_000a: stloc.2
		IL_000b: ldloc.2
		IL_000c: brtrue.s IL_0012

		IL_000e: ldnull
		IL_000f: stloc.1
		IL_0010: br.s IL_003d

		IL_0012: ldarg.0
		IL_0013: call bool [mscorlib]System.IO.File::Exists(string)
		IL_0018: stloc.2
		IL_0019: ldloc.2
		IL_001a: brtrue.s IL_0020

		IL_001c: ldnull
		IL_001d: stloc.1
		IL_001e: br.s IL_003d

		IL_0020: newobj instance void [System.Xml]System.Xml.XmlDocument::.ctor()
		IL_0025: stloc.0
		.try
		{
			IL_0026: nop
			IL_0027: ldloc.0
			IL_0028: ldarg.0
			IL_0029: callvirt instance void [System.Xml]System.Xml.XmlDocument::Load(string)
			IL_002e: nop
			IL_002f: nop
			IL_0030: leave.s IL_0038
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0032: pop
			IL_0033: nop
			IL_0034: ldnull
			IL_0035: stloc.1
			IL_0036: leave.s IL_003d
		} // end handler

		IL_0038: nop
		IL_0039: ldloc.0
		IL_003a: stloc.1
		IL_003b: br.s IL_003d

		IL_003d: nop
		IL_003e: ldloc.1
		IL_003f: ret
	} // end of method SystemConfig::GetXmlDocument

	.method private hidebysig static 
		bool SaveXmlDocument (
			class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			string szXmlFile
		) cil managed 
	{
		// Method begins at RVA 0x9c3c
		// Header size: 12
		// Code size: 90 (0x5a)
		.maxstack 2
		.locals init (
			[0] bool CS$1$0000,
			[1] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldnull
		IL_0003: ceq
		IL_0005: ldc.i4.0
		IL_0006: ceq
		IL_0008: stloc.1
		IL_0009: ldloc.1
		IL_000a: brtrue.s IL_0010

		IL_000c: ldc.i4.0
		IL_000d: stloc.0
		IL_000e: br.s IL_0057

		IL_0010: ldarg.1
		IL_0011: call bool datapick.SystemConfig::IsEmptyString(string)
		IL_0016: ldc.i4.0
		IL_0017: ceq
		IL_0019: stloc.1
		IL_001a: ldloc.1
		IL_001b: brtrue.s IL_0021

		IL_001d: ldc.i4.0
		IL_001e: stloc.0
		IL_001f: br.s IL_0057
		.try
		{
			IL_0021: nop
			IL_0022: ldarg.1
			IL_0023: call bool [mscorlib]System.IO.File::Exists(string)
			IL_0028: ldc.i4.0
			IL_0029: ceq
			IL_002b: stloc.1
			IL_002c: ldloc.1
			IL_002d: brtrue.s IL_0036

			IL_002f: ldarg.1
			IL_0030: call void [mscorlib]System.IO.File::Delete(string)
			IL_0035: nop

			IL_0036: nop
			IL_0037: leave.s IL_003f
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0039: pop
			IL_003a: nop
			IL_003b: ldc.i4.0
			IL_003c: stloc.0
			IL_003d: leave.s IL_0057
		} // end handler

		IL_003f: nop
		.try
		{
			IL_0040: nop
			IL_0041: ldarg.0
			IL_0042: ldarg.1
			IL_0043: callvirt instance void [System.Xml]System.Xml.XmlDocument::Save(string)
			IL_0048: nop
			IL_0049: nop
			IL_004a: leave.s IL_0052
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_004c: pop
			IL_004d: nop
			IL_004e: ldc.i4.0
			IL_004f: stloc.0
			IL_0050: leave.s IL_0057
		} // end handler

		IL_0052: nop
		IL_0053: ldc.i4.1
		IL_0054: stloc.0
		IL_0055: br.s IL_0057

		IL_0057: nop
		IL_0058: ldloc.0
		IL_0059: ret
	} // end of method SystemConfig::SaveXmlDocument

	.method private hidebysig static 
		class [System.Xml]System.Xml.XmlNode SelectXmlNode (
			class [System.Xml]System.Xml.XmlNode clsRootNode,
			string szXPath
		) cil managed 
	{
		// Method begins at RVA 0x9cc0
		// Header size: 12
		// Code size: 45 (0x2d)
		.maxstack 2
		.locals init (
			[0] class [System.Xml]System.Xml.XmlNode CS$1$0000,
			[1] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: brfalse.s IL_000f

		IL_0004: ldarg.1
		IL_0005: call bool datapick.SystemConfig::IsEmptyString(string)
		IL_000a: ldc.i4.0
		IL_000b: ceq
		IL_000d: br.s IL_0010

		IL_000f: ldc.i4.0

		IL_0010: nop
		IL_0011: stloc.1
		IL_0012: ldloc.1
		IL_0013: brtrue.s IL_0019

		IL_0015: ldnull
		IL_0016: stloc.0
		IL_0017: br.s IL_002a
		.try
		{
			IL_0019: nop
			IL_001a: ldarg.0
			IL_001b: ldarg.1
			IL_001c: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::SelectSingleNode(string)
			IL_0021: stloc.0
			IL_0022: leave.s IL_002a
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0024: pop
			IL_0025: nop
			IL_0026: ldnull
			IL_0027: stloc.0
			IL_0028: leave.s IL_002a
		} // end handler

		IL_002a: nop
		IL_002b: ldloc.0
		IL_002c: ret
	} // end of method SystemConfig::SelectXmlNode

	.method private hidebysig static 
		class [System.Xml]System.Xml.XmlNodeList SelectXmlNodes (
			class [System.Xml]System.Xml.XmlNode clsRootNode,
			string szXPath
		) cil managed 
	{
		// Method begins at RVA 0x9d0c
		// Header size: 12
		// Code size: 45 (0x2d)
		.maxstack 2
		.locals init (
			[0] class [System.Xml]System.Xml.XmlNodeList CS$1$0000,
			[1] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: brfalse.s IL_000f

		IL_0004: ldarg.1
		IL_0005: call bool datapick.SystemConfig::IsEmptyString(string)
		IL_000a: ldc.i4.0
		IL_000b: ceq
		IL_000d: br.s IL_0010

		IL_000f: ldc.i4.0

		IL_0010: nop
		IL_0011: stloc.1
		IL_0012: ldloc.1
		IL_0013: brtrue.s IL_0019

		IL_0015: ldnull
		IL_0016: stloc.0
		IL_0017: br.s IL_002a
		.try
		{
			IL_0019: nop
			IL_001a: ldarg.0
			IL_001b: ldarg.1
			IL_001c: callvirt instance class [System.Xml]System.Xml.XmlNodeList [System.Xml]System.Xml.XmlNode::SelectNodes(string)
			IL_0021: stloc.0
			IL_0022: leave.s IL_002a
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0024: pop
			IL_0025: nop
			IL_0026: ldnull
			IL_0027: stloc.0
			IL_0028: leave.s IL_002a
		} // end handler

		IL_002a: nop
		IL_002b: ldloc.0
		IL_002c: ret
	} // end of method SystemConfig::SelectXmlNodes

	.method private hidebysig static 
		class [System.Xml]System.Xml.XmlNode CreateXmlNode (
			class [System.Xml]System.Xml.XmlNode clsParentNode,
			string szNodeName
		) cil managed 
	{
		// Method begins at RVA 0x9d58
		// Header size: 12
		// Code size: 121 (0x79)
		.maxstack 4
		.locals init (
			[0] class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			[1] class [System.Xml]System.Xml.XmlNode clsXmlNode,
			[2] class [System.Xml]System.Xml.XmlNode CS$1$0000,
			[3] bool CS$4$0001
		)

		IL_0000: nop
		.try
		{
			IL_0001: nop
			IL_0002: ldnull
			IL_0003: stloc.0
			IL_0004: ldarg.0
			IL_0005: callvirt instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
			IL_000a: ldtoken [System.Xml]System.Xml.XmlDocument
			IL_000f: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_0014: ceq
			IL_0016: stloc.3
			IL_0017: ldloc.3
			IL_0018: brtrue.s IL_0023

			IL_001a: ldarg.0
			IL_001b: callvirt instance class [System.Xml]System.Xml.XmlDocument [System.Xml]System.Xml.XmlNode::get_OwnerDocument()
			IL_0020: stloc.0
			IL_0021: br.s IL_002a

			IL_0023: ldarg.0
			IL_0024: isinst [System.Xml]System.Xml.XmlDocument
			IL_0029: stloc.0

			IL_002a: ldloc.0
			IL_002b: ldc.i4.1
			IL_002c: ldarg.1
			IL_002d: ldsfld string [mscorlib]System.String::Empty
			IL_0032: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlDocument::CreateNode(valuetype [System.Xml]System.Xml.XmlNodeType, string, string)
			IL_0037: stloc.1
			IL_0038: ldarg.0
			IL_0039: callvirt instance class [mscorlib]System.Type [mscorlib]System.Object::GetType()
			IL_003e: ldtoken [System.Xml]System.Xml.XmlDocument
			IL_0043: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
			IL_0048: ceq
			IL_004a: ldc.i4.0
			IL_004b: ceq
			IL_004d: stloc.3
			IL_004e: ldloc.3
			IL_004f: brtrue.s IL_0062

			IL_0051: nop
			IL_0052: ldloc.0
			IL_0053: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::get_LastChild()
			IL_0058: ldloc.1
			IL_0059: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::AppendChild(class [System.Xml]System.Xml.XmlNode)
			IL_005e: pop
			IL_005f: nop
			IL_0060: br.s IL_006c

			IL_0062: nop
			IL_0063: ldarg.0
			IL_0064: ldloc.1
			IL_0065: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNode::AppendChild(class [System.Xml]System.Xml.XmlNode)
			IL_006a: pop
			IL_006b: nop

			IL_006c: ldloc.1
			IL_006d: stloc.2
			IL_006e: leave.s IL_0076
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0070: pop
			IL_0071: nop
			IL_0072: ldnull
			IL_0073: stloc.2
			IL_0074: leave.s IL_0076
		} // end handler

		IL_0076: nop
		IL_0077: ldloc.2
		IL_0078: ret
	} // end of method SystemConfig::CreateXmlNode

	.method private hidebysig static 
		bool SetXmlAttr (
			class [System.Xml]System.Xml.XmlNode clsXmlNode,
			string szAttrName,
			string szAttrValue
		) cil managed 
	{
		// Method begins at RVA 0x9df0
		// Header size: 12
		// Code size: 141 (0x8d)
		.maxstack 2
		.locals init (
			[0] class [System.Xml]System.Xml.XmlAttribute clsAttrNode,
			[1] class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			[2] bool CS$1$0000,
			[3] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldnull
		IL_0003: ceq
		IL_0005: ldc.i4.0
		IL_0006: ceq
		IL_0008: stloc.3
		IL_0009: ldloc.3
		IL_000a: brtrue.s IL_0010

		IL_000c: ldc.i4.0
		IL_000d: stloc.2
		IL_000e: br.s IL_008b

		IL_0010: ldarg.1
		IL_0011: call bool datapick.SystemConfig::IsEmptyString(string)
		IL_0016: ldc.i4.0
		IL_0017: ceq
		IL_0019: stloc.3
		IL_001a: ldloc.3
		IL_001b: brtrue.s IL_0021

		IL_001d: ldc.i4.0
		IL_001e: stloc.2
		IL_001f: br.s IL_008b

		IL_0021: ldarg.2
		IL_0022: call bool datapick.SystemConfig::IsEmptyString(string)
		IL_0027: ldc.i4.0
		IL_0028: ceq
		IL_002a: stloc.3
		IL_002b: ldloc.3
		IL_002c: brtrue.s IL_0035

		IL_002e: ldsfld string [mscorlib]System.String::Empty
		IL_0033: starg.s szAttrValue

		IL_0035: ldarg.0
		IL_0036: callvirt instance class [System.Xml]System.Xml.XmlAttributeCollection [System.Xml]System.Xml.XmlNode::get_Attributes()
		IL_003b: ldarg.1
		IL_003c: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNamedNodeMap::GetNamedItem(string)
		IL_0041: isinst [System.Xml]System.Xml.XmlAttribute
		IL_0046: stloc.0
		IL_0047: ldloc.0
		IL_0048: ldnull
		IL_0049: ceq
		IL_004b: ldc.i4.0
		IL_004c: ceq
		IL_004e: stloc.3
		IL_004f: ldloc.3
		IL_0050: brtrue.s IL_007f

		IL_0052: nop
		IL_0053: ldarg.0
		IL_0054: callvirt instance class [System.Xml]System.Xml.XmlDocument [System.Xml]System.Xml.XmlNode::get_OwnerDocument()
		IL_0059: stloc.1
		IL_005a: ldloc.1
		IL_005b: ldnull
		IL_005c: ceq
		IL_005e: ldc.i4.0
		IL_005f: ceq
		IL_0061: stloc.3
		IL_0062: ldloc.3
		IL_0063: brtrue.s IL_0069

		IL_0065: ldc.i4.0
		IL_0066: stloc.2
		IL_0067: br.s IL_008b

		IL_0069: ldloc.1
		IL_006a: ldarg.1
		IL_006b: callvirt instance class [System.Xml]System.Xml.XmlAttribute [System.Xml]System.Xml.XmlDocument::CreateAttribute(string)
		IL_0070: stloc.0
		IL_0071: ldarg.0
		IL_0072: callvirt instance class [System.Xml]System.Xml.XmlAttributeCollection [System.Xml]System.Xml.XmlNode::get_Attributes()
		IL_0077: ldloc.0
		IL_0078: callvirt instance class [System.Xml]System.Xml.XmlAttribute [System.Xml]System.Xml.XmlAttributeCollection::Append(class [System.Xml]System.Xml.XmlAttribute)
		IL_007d: pop
		IL_007e: nop

		IL_007f: ldloc.0
		IL_0080: ldarg.2
		IL_0081: callvirt instance void [System.Xml]System.Xml.XmlNode::set_Value(string)
		IL_0086: nop
		IL_0087: ldc.i4.1
		IL_0088: stloc.2
		IL_0089: br.s IL_008b

		IL_008b: ldloc.2
		IL_008c: ret
	} // end of method SystemConfig::SetXmlAttr

	.method public hidebysig static 
		int32 GetConfigData (
			string szKeyName,
			int32 nDefaultValue
		) cil managed 
	{
		// Method begins at RVA 0x9e8c
		// Header size: 12
		// Code size: 34 (0x22)
		.maxstack 2
		.locals init (
			[0] string szValue,
			[1] int32 CS$1$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarga.s nDefaultValue
		IL_0004: call instance string [mscorlib]System.Int32::ToString()
		IL_0009: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_000e: stloc.0
		.try
		{
			IL_000f: nop
			IL_0010: ldloc.0
			IL_0011: call int32 [mscorlib]System.Int32::Parse(string)
			IL_0016: stloc.1
			IL_0017: leave.s IL_001f
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0019: pop
			IL_001a: nop
			IL_001b: ldarg.1
			IL_001c: stloc.1
			IL_001d: leave.s IL_001f
		} // end handler

		IL_001f: nop
		IL_0020: ldloc.1
		IL_0021: ret
	} // end of method SystemConfig::GetConfigData

	.method public hidebysig static 
		float32 GetConfigData (
			string szKeyName,
			float32 fDefaultValue
		) cil managed 
	{
		// Method begins at RVA 0x9ecc
		// Header size: 12
		// Code size: 34 (0x22)
		.maxstack 2
		.locals init (
			[0] string szValue,
			[1] float32 CS$1$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarga.s fDefaultValue
		IL_0004: call instance string [mscorlib]System.Single::ToString()
		IL_0009: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_000e: stloc.0
		.try
		{
			IL_000f: nop
			IL_0010: ldloc.0
			IL_0011: call float32 [mscorlib]System.Single::Parse(string)
			IL_0016: stloc.1
			IL_0017: leave.s IL_001f
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0019: pop
			IL_001a: nop
			IL_001b: ldarg.1
			IL_001c: stloc.1
			IL_001d: leave.s IL_001f
		} // end handler

		IL_001f: nop
		IL_0020: ldloc.1
		IL_0021: ret
	} // end of method SystemConfig::GetConfigData

	.method public hidebysig static 
		bool GetConfigData (
			string szKeyName,
			bool bDefaultValue
		) cil managed 
	{
		// Method begins at RVA 0x9f0c
		// Header size: 12
		// Code size: 34 (0x22)
		.maxstack 2
		.locals init (
			[0] string szValue,
			[1] bool CS$1$0000
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: ldarga.s bDefaultValue
		IL_0004: call instance string [mscorlib]System.Boolean::ToString()
		IL_0009: call string datapick.SystemConfig::GetConfigData(string, string)
		IL_000e: stloc.0
		.try
		{
			IL_000f: nop
			IL_0010: ldloc.0
			IL_0011: call bool [mscorlib]System.Boolean::Parse(string)
			IL_0016: stloc.1
			IL_0017: leave.s IL_001f
		} // end .try
		catch [mscorlib]System.Object
		{
			IL_0019: pop
			IL_001a: nop
			IL_001b: ldarg.1
			IL_001c: stloc.1
			IL_001d: leave.s IL_001f
		} // end handler

		IL_001f: nop
		IL_0020: ldloc.1
		IL_0021: ret
	} // end of method SystemConfig::GetConfigData

	.method public hidebysig static 
		string GetConfigData (
			string szKeyName,
			string szDefaultValue
		) cil managed 
	{
		// Method begins at RVA 0x9f4c
		// Header size: 12
		// Code size: 155 (0x9b)
		.maxstack 3
		.locals init (
			[0] string szConfigFile,
			[1] class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			[2] string szXPath,
			[3] class [System.Xml]System.Xml.XmlNode clsXmlNode,
			[4] class [System.Xml]System.Xml.XmlNode clsValueAttr,
			[5] string CS$1$0000,
			[6] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldstr "{0}\\{1}"
		IL_0006: call string datapick.SystemConfig::GetWorkDirectory()
		IL_000b: ldsfld string datapick.SystemConfig::CONFIG_FILE
		IL_0010: call string [mscorlib]System.String::Format(string, object, object)
		IL_0015: stloc.0
		IL_0016: ldloc.0
		IL_0017: call bool [mscorlib]System.IO.File::Exists(string)
		IL_001c: stloc.s 6
		IL_001e: ldloc.s 6
		IL_0020: brtrue.s IL_0028

		IL_0022: nop
		IL_0023: ldarg.1
		IL_0024: stloc.s 5
		IL_0026: br.s IL_0098

		IL_0028: ldloc.0
		IL_0029: call class [System.Xml]System.Xml.XmlDocument datapick.SystemConfig::GetXmlDocument(string)
		IL_002e: stloc.1
		IL_002f: ldloc.1
		IL_0030: ldnull
		IL_0031: ceq
		IL_0033: ldc.i4.0
		IL_0034: ceq
		IL_0036: stloc.s 6
		IL_0038: ldloc.s 6
		IL_003a: brtrue.s IL_0041

		IL_003c: ldarg.1
		IL_003d: stloc.s 5
		IL_003f: br.s IL_0098

		IL_0041: ldstr ".//key[@name='{0}']"
		IL_0046: ldarg.0
		IL_0047: call string [mscorlib]System.String::Format(string, object)
		IL_004c: stloc.2
		IL_004d: ldloc.1
		IL_004e: ldloc.2
		IL_004f: call class [System.Xml]System.Xml.XmlNode datapick.SystemConfig::SelectXmlNode(class [System.Xml]System.Xml.XmlNode, string)
		IL_0054: stloc.3
		IL_0055: ldloc.3
		IL_0056: ldnull
		IL_0057: ceq
		IL_0059: ldc.i4.0
		IL_005a: ceq
		IL_005c: stloc.s 6
		IL_005e: ldloc.s 6
		IL_0060: brtrue.s IL_0068

		IL_0062: nop
		IL_0063: ldarg.1
		IL_0064: stloc.s 5
		IL_0066: br.s IL_0098

		IL_0068: ldloc.3
		IL_0069: callvirt instance class [System.Xml]System.Xml.XmlAttributeCollection [System.Xml]System.Xml.XmlNode::get_Attributes()
		IL_006e: ldstr "value"
		IL_0073: callvirt instance class [System.Xml]System.Xml.XmlNode [System.Xml]System.Xml.XmlNamedNodeMap::GetNamedItem(string)
		IL_0078: stloc.s 4
		IL_007a: ldloc.s 4
		IL_007c: ldnull
		IL_007d: ceq
		IL_007f: ldc.i4.0
		IL_0080: ceq
		IL_0082: stloc.s 6
		IL_0084: ldloc.s 6
		IL_0086: brtrue.s IL_008d

		IL_0088: ldarg.1
		IL_0089: stloc.s 5
		IL_008b: br.s IL_0098

		IL_008d: ldloc.s 4
		IL_008f: callvirt instance string [System.Xml]System.Xml.XmlNode::get_Value()
		IL_0094: stloc.s 5
		IL_0096: br.s IL_0098

		IL_0098: ldloc.s 5
		IL_009a: ret
	} // end of method SystemConfig::GetConfigData

	.method public hidebysig static 
		bool WriteConfigData (
			string szKeyName,
			string szValue
		) cil managed 
	{
		// Method begins at RVA 0x9ff4
		// Header size: 12
		// Code size: 172 (0xac)
		.maxstack 3
		.locals init (
			[0] string szConfigFile,
			[1] class [System.Xml]System.Xml.XmlDocument clsXmlDoc,
			[2] string szXPath,
			[3] class [System.Xml]System.Xml.XmlNode clsXmlNode,
			[4] bool CS$1$0000,
			[5] bool CS$4$0001
		)

		IL_0000: nop
		IL_0001: ldstr "{0}\\{1}"
		IL_0006: call string datapick.SystemConfig::GetWorkDirectory()
		IL_000b: ldsfld string datapick.SystemConfig::CONFIG_FILE
		IL_0010: call string [mscorlib]System.String::Format(string, object, object)
		IL_0015: stloc.0
		IL_0016: ldloc.0
		IL_0017: call bool [mscorlib]System.IO.File::Exists(string)
		IL_001c: stloc.s 5
		IL_001e: ldloc.s 5
		IL_0020: brtrue.s IL_003a

		IL_0022: nop
		IL_0023: ldloc.0
		IL_0024: ldstr "SystemConfig"
		IL_0029: call bool datapick.SystemConfig::CreateXmlFile(string, string)
		IL_002e: stloc.s 5
		IL_0030: ldloc.s 5
		IL_0032: brtrue.s IL_0039

		IL_0034: ldc.i4.0
		IL_0035: stloc.s 4
		IL_0037: br.s IL_00a9

		IL_0039: nop

		IL_003a: ldloc.0
		IL_003b: call class [System.Xml]System.Xml.XmlDocument datapick.SystemConfig::GetXmlDocument(string)
		IL_0040: stloc.1
		IL_0041: ldstr ".//key[@name='{0}']"
		IL_0046: ldarg.0
		IL_0047: call string [mscorlib]System.String::Format(string, object)
		IL_004c: stloc.2
		IL_004d: ldloc.1
		IL_004e: ldloc.2
		IL_004f: call class [System.Xml]System.Xml.XmlNode datapick.SystemConfig::SelectXmlNode(class [System.Xml]System.Xml.XmlNode, string)
		IL_0054: stloc.3
		IL_0055: ldloc.3
		IL_0056: ldnull
		IL_0057: ceq
		IL_0059: ldc.i4.0
		IL_005a: ceq
		IL_005c: stloc.s 5
		IL_005e: ldloc.s 5
		IL_0060: brtrue.s IL_0070

		IL_0062: nop
		IL_0063: ldloc.1
		IL_0064: ldstr "key"
		IL_0069: call class [System.Xml]System.Xml.XmlNode datapick.SystemConfig::CreateXmlNode(class [System.Xml]System.Xml.XmlNode, string)
		IL_006e: stloc.3
		IL_006f: nop

		IL_0070: ldloc.3
		IL_0071: ldstr "name"
		IL_0076: ldarg.0
		IL_0077: call bool datapick.SystemConfig::SetXmlAttr(class [System.Xml]System.Xml.XmlNode, string, string)
		IL_007c: stloc.s 5
		IL_007e: ldloc.s 5
		IL_0080: brtrue.s IL_0087

		IL_0082: ldc.i4.0
		IL_0083: stloc.s 4
		IL_0085: br.s IL_00a9

		IL_0087: ldloc.3
		IL_0088: ldstr "value"
		IL_008d: ldarg.1
		IL_008e: call bool datapick.SystemConfig::SetXmlAttr(class [System.Xml]System.Xml.XmlNode, string, string)
		IL_0093: stloc.s 5
		IL_0095: ldloc.s 5
		IL_0097: brtrue.s IL_009e

		IL_0099: ldc.i4.0
		IL_009a: stloc.s 4
		IL_009c: br.s IL_00a9

		IL_009e: ldloc.1
		IL_009f: ldloc.0
		IL_00a0: call bool datapick.SystemConfig::SaveXmlDocument(class [System.Xml]System.Xml.XmlDocument, string)
		IL_00a5: stloc.s 4
		IL_00a7: br.s IL_00a9

		IL_00a9: ldloc.s 4
		IL_00ab: ret
	} // end of method SystemConfig::WriteConfigData

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0xa0b8
		// Header size: 1
		// Code size: 7 (0x7)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: call instance void [mscorlib]System.Object::.ctor()
		IL_0006: ret
	} // end of method SystemConfig::.ctor

	.method private hidebysig specialname rtspecialname static 
		void .cctor () cil managed 
	{
		// Method begins at RVA 0xa0ac
		// Header size: 1
		// Code size: 11 (0xb)
		.maxstack 8

		IL_0000: ldstr "SystemConfig.xml"
		IL_0005: stsfld string datapick.SystemConfig::CONFIG_FILE
		IL_000a: ret
	} // end of method SystemConfig::.cctor

} // end of class datapick.SystemConfig

.class public auto ansi beforefieldinit datapick.tishi
	extends [System.Windows.Forms]System.Windows.Forms.Form
{
	// Fields
	.field private static literal uint32 SC_CLOSE = uint32(61536)
	.field private static literal uint32 MF_BYCOMMAND = uint32(0)
	.field public static class datapick.tishi tis
	.field private class [System]System.ComponentModel.IContainer components
	.field private class [System.Windows.Forms]System.Windows.Forms.Timer timer1
	.field public class [System.Windows.Forms]System.Windows.Forms.Label label1
	.field public class [System.Windows.Forms]System.Windows.Forms.Button button1

	// Methods
	.method private hidebysig static pinvokeimpl("USER32.DLL" winapi) 
		native int GetSystemMenu (
			native int hWnd,
			uint32 bRevert
		) cil managed preservesig 
	{
	} // end of method tishi::GetSystemMenu

	.method private hidebysig static pinvokeimpl("USER32.DLL" winapi) 
		uint32 RemoveMenu (
			native int hMenu,
			uint32 nPosition,
			uint32 wFlags
		) cil managed preservesig 
	{
	} // end of method tishi::RemoveMenu

	.method public hidebysig specialname rtspecialname 
		instance void .ctor () cil managed 
	{
		// Method begins at RVA 0xa0c0
		// Header size: 1
		// Code size: 30 (0x1e)
		.maxstack 8

		IL_0000: ldarg.0
		IL_0001: ldnull
		IL_0002: stfld class [System]System.ComponentModel.IContainer datapick.tishi::components
		IL_0007: ldarg.0
		IL_0008: call instance void [System.Windows.Forms]System.Windows.Forms.Form::.ctor()
		IL_000d: nop
		IL_000e: nop
		IL_000f: ldarg.0
		IL_0010: call instance void datapick.tishi::InitializeComponent()
		IL_0015: nop
		IL_0016: ldarg.0
		IL_0017: stsfld class datapick.tishi datapick.tishi::tis
		IL_001c: nop
		IL_001d: ret
	} // end of method tishi::.ctor

	.method private hidebysig 
		instance void tishi_Load (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0xa0e0
		// Header size: 12
		// Code size: 62 (0x3e)
		.maxstack 3
		.locals init (
			[0] native int hMenu
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: call instance native int [System.Windows.Forms]System.Windows.Forms.Control::get_Handle()
		IL_0007: ldc.i4.0
		IL_0008: call native int datapick.tishi::GetSystemMenu(native int, uint32)
		IL_000d: stloc.0
		IL_000e: ldloc.0
		IL_000f: ldc.i4 61536
		IL_0014: ldc.i4.0
		IL_0015: call uint32 datapick.tishi::RemoveMenu(native int, uint32, uint32)
		IL_001a: pop
		IL_001b: ldarg.0
		IL_001c: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_0021: ldstr "读取中，请耐心等待......"
		IL_0026: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_002b: nop
		IL_002c: ldarg.0
		IL_002d: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0032: ldstr "取消"
		IL_0037: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_003c: nop
		IL_003d: ret
	} // end of method tishi::tishi_Load

	.method private hidebysig 
		instance void button1_Click (
			object sender,
			class [mscorlib]System.EventArgs e
		) cil managed 
	{
		// Method begins at RVA 0xa12a
		// Header size: 1
		// Code size: 43 (0x2b)
		.maxstack 8

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: call instance void [System.Windows.Forms]System.Windows.Forms.Form::Close()
		IL_0007: nop
		IL_0008: ldsfld class datapick.Form1 datapick.Form1::mf
		IL_000d: ldfld class [System.Windows.Forms]System.Windows.Forms.GroupBox datapick.Form1::groupBox6
		IL_0012: ldc.i4.1
		IL_0013: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Enabled(bool)
		IL_0018: nop
		IL_0019: ldsfld class datapick.Form1 datapick.Form1::mf
		IL_001e: ldfld class [System.Windows.Forms]System.Windows.Forms.ComboBox datapick.Form1::comboBoxDataType
		IL_0023: ldc.i4.0
		IL_0024: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ListControl::set_SelectedIndex(int32)
		IL_0029: nop
		IL_002a: ret
	} // end of method tishi::button1_Click

	.method family hidebysig virtual 
		instance void Dispose (
			bool disposing
		) cil managed 
	{
		// Method begins at RVA 0xa158
		// Header size: 12
		// Code size: 44 (0x2c)
		.maxstack 2
		.locals init (
			[0] bool CS$4$0000
		)

		IL_0000: nop
		IL_0001: ldarg.1
		IL_0002: brfalse.s IL_000f

		IL_0004: ldarg.0
		IL_0005: ldfld class [System]System.ComponentModel.IContainer datapick.tishi::components
		IL_000a: ldnull
		IL_000b: ceq
		IL_000d: br.s IL_0010

		IL_000f: ldc.i4.1

		IL_0010: nop
		IL_0011: stloc.0
		IL_0012: ldloc.0
		IL_0013: brtrue.s IL_0023

		IL_0015: nop
		IL_0016: ldarg.0
		IL_0017: ldfld class [System]System.ComponentModel.IContainer datapick.tishi::components
		IL_001c: callvirt instance void [mscorlib]System.IDisposable::Dispose()
		IL_0021: nop
		IL_0022: nop

		IL_0023: ldarg.0
		IL_0024: ldarg.1
		IL_0025: call instance void [System.Windows.Forms]System.Windows.Forms.Form::Dispose(bool)
		IL_002a: nop
		IL_002b: ret
	} // end of method tishi::Dispose

	.method private hidebysig 
		instance void InitializeComponent () cil managed 
	{
		// Method begins at RVA 0xa190
		// Header size: 12
		// Code size: 571 (0x23b)
		.maxstack 6
		.locals init (
			[0] class [System]System.ComponentModel.ComponentResourceManager resources
		)

		IL_0000: nop
		IL_0001: ldarg.0
		IL_0002: newobj instance void [System]System.ComponentModel.Container::.ctor()
		IL_0007: stfld class [System]System.ComponentModel.IContainer datapick.tishi::components
		IL_000c: ldtoken datapick.tishi
		IL_0011: call class [mscorlib]System.Type [mscorlib]System.Type::GetTypeFromHandle(valuetype [mscorlib]System.RuntimeTypeHandle)
		IL_0016: newobj instance void [System]System.ComponentModel.ComponentResourceManager::.ctor(class [mscorlib]System.Type)
		IL_001b: stloc.0
		IL_001c: ldarg.0
		IL_001d: newobj instance void [System.Windows.Forms]System.Windows.Forms.Label::.ctor()
		IL_0022: stfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_0027: ldarg.0
		IL_0028: newobj instance void [System.Windows.Forms]System.Windows.Forms.Button::.ctor()
		IL_002d: stfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0032: ldarg.0
		IL_0033: ldarg.0
		IL_0034: ldfld class [System]System.ComponentModel.IContainer datapick.tishi::components
		IL_0039: newobj instance void [System.Windows.Forms]System.Windows.Forms.Timer::.ctor(class [System]System.ComponentModel.IContainer)
		IL_003e: stfld class [System.Windows.Forms]System.Windows.Forms.Timer datapick.tishi::timer1
		IL_0043: ldarg.0
		IL_0044: call instance void [System.Windows.Forms]System.Windows.Forms.Control::SuspendLayout()
		IL_0049: nop
		IL_004a: ldarg.0
		IL_004b: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_0050: ldc.i4.1
		IL_0051: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_AutoSize(bool)
		IL_0056: nop
		IL_0057: ldarg.0
		IL_0058: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_005d: ldstr "宋体"
		IL_0062: ldc.r4 12
		IL_0067: ldc.i4.0
		IL_0068: ldc.i4.3
		IL_0069: ldc.i4 134
		IL_006e: newobj instance void [System.Drawing]System.Drawing.Font::.ctor(string, float32, valuetype [System.Drawing]System.Drawing.FontStyle, valuetype [System.Drawing]System.Drawing.GraphicsUnit, uint8)
		IL_0073: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Font(class [System.Drawing]System.Drawing.Font)
		IL_0078: nop
		IL_0079: ldarg.0
		IL_007a: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_007f: ldc.i4.s 12
		IL_0081: ldc.i4.s 21
		IL_0083: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_0088: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_008d: nop
		IL_008e: ldarg.0
		IL_008f: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_0094: ldstr "label1"
		IL_0099: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_009e: nop
		IL_009f: ldarg.0
		IL_00a0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_00a5: ldc.i4 200
		IL_00aa: ldc.i4.s 16
		IL_00ac: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_00b1: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_00b6: nop
		IL_00b7: ldarg.0
		IL_00b8: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_00bd: ldc.i4.0
		IL_00be: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_00c3: nop
		IL_00c4: ldarg.0
		IL_00c5: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_00ca: ldstr "读取中，请耐心等待......"
		IL_00cf: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_00d4: nop
		IL_00d5: ldarg.0
		IL_00d6: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_00db: ldc.i4 155
		IL_00e0: ldc.i4.s 51
		IL_00e2: newobj instance void [System.Drawing]System.Drawing.Point::.ctor(int32, int32)
		IL_00e7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Location(valuetype [System.Drawing]System.Drawing.Point)
		IL_00ec: nop
		IL_00ed: ldarg.0
		IL_00ee: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_00f3: ldstr "button1"
		IL_00f8: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_00fd: nop
		IL_00fe: ldarg.0
		IL_00ff: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0104: ldc.i4.s 75
		IL_0106: ldc.i4.s 23
		IL_0108: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_010d: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Size(valuetype [System.Drawing]System.Drawing.Size)
		IL_0112: nop
		IL_0113: ldarg.0
		IL_0114: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0119: ldc.i4.1
		IL_011a: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_TabIndex(int32)
		IL_011f: nop
		IL_0120: ldarg.0
		IL_0121: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0126: ldstr "取消"
		IL_012b: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0130: nop
		IL_0131: ldarg.0
		IL_0132: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0137: ldc.i4.1
		IL_0138: callvirt instance void [System.Windows.Forms]System.Windows.Forms.ButtonBase::set_UseVisualStyleBackColor(bool)
		IL_013d: nop
		IL_013e: ldarg.0
		IL_013f: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0144: ldarg.0
		IL_0145: ldftn instance void datapick.tishi::button1_Click(object, class [mscorlib]System.EventArgs)
		IL_014b: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0150: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::add_Click(class [mscorlib]System.EventHandler)
		IL_0155: nop
		IL_0156: ldarg.0
		IL_0157: ldc.r4 6
		IL_015c: ldc.r4 12
		IL_0161: newobj instance void [System.Drawing]System.Drawing.SizeF::.ctor(float32, float32)
		IL_0166: call instance void [System.Windows.Forms]System.Windows.Forms.ContainerControl::set_AutoScaleDimensions(valuetype [System.Drawing]System.Drawing.SizeF)
		IL_016b: nop
		IL_016c: ldarg.0
		IL_016d: ldc.i4.1
		IL_016e: call instance void [System.Windows.Forms]System.Windows.Forms.ContainerControl::set_AutoScaleMode(valuetype [System.Windows.Forms]System.Windows.Forms.AutoScaleMode)
		IL_0173: nop
		IL_0174: ldarg.0
		IL_0175: ldc.i4 242
		IL_017a: ldc.i4.s 86
		IL_017c: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_0181: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_ClientSize(valuetype [System.Drawing]System.Drawing.Size)
		IL_0186: nop
		IL_0187: ldarg.0
		IL_0188: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_018d: ldarg.0
		IL_018e: ldfld class [System.Windows.Forms]System.Windows.Forms.Button datapick.tishi::button1
		IL_0193: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_0198: nop
		IL_0199: ldarg.0
		IL_019a: call instance class [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection [System.Windows.Forms]System.Windows.Forms.Control::get_Controls()
		IL_019f: ldarg.0
		IL_01a0: ldfld class [System.Windows.Forms]System.Windows.Forms.Label datapick.tishi::label1
		IL_01a5: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control/ControlCollection::Add(class [System.Windows.Forms]System.Windows.Forms.Control)
		IL_01aa: nop
		IL_01ab: ldarg.0
		IL_01ac: ldloc.0
		IL_01ad: ldstr "$this.Icon"
		IL_01b2: callvirt instance object [mscorlib]System.Resources.ResourceManager::GetObject(string)
		IL_01b7: castclass [System.Drawing]System.Drawing.Icon
		IL_01bc: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_Icon(class [System.Drawing]System.Drawing.Icon)
		IL_01c1: nop
		IL_01c2: ldarg.0
		IL_01c3: ldc.i4.0
		IL_01c4: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_MaximizeBox(bool)
		IL_01c9: nop
		IL_01ca: ldarg.0
		IL_01cb: ldc.i4 250
		IL_01d0: ldc.i4.s 120
		IL_01d2: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_01d7: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_MaximumSize(valuetype [System.Drawing]System.Drawing.Size)
		IL_01dc: nop
		IL_01dd: ldarg.0
		IL_01de: ldc.i4.0
		IL_01df: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_MinimizeBox(bool)
		IL_01e4: nop
		IL_01e5: ldarg.0
		IL_01e6: ldc.i4 250
		IL_01eb: ldc.i4.s 120
		IL_01ed: newobj instance void [System.Drawing]System.Drawing.Size::.ctor(int32, int32)
		IL_01f2: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_MinimumSize(valuetype [System.Drawing]System.Drawing.Size)
		IL_01f7: nop
		IL_01f8: ldarg.0
		IL_01f9: ldstr "tishi"
		IL_01fe: call instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Name(string)
		IL_0203: nop
		IL_0204: ldarg.0
		IL_0205: ldc.i4.4
		IL_0206: call instance void [System.Windows.Forms]System.Windows.Forms.Form::set_StartPosition(valuetype [System.Windows.Forms]System.Windows.Forms.FormStartPosition)
		IL_020b: nop
		IL_020c: ldarg.0
		IL_020d: ldstr "提示"
		IL_0212: callvirt instance void [System.Windows.Forms]System.Windows.Forms.Control::set_Text(string)
		IL_0217: nop
		IL_0218: ldarg.0
		IL_0219: ldarg.0
		IL_021a: ldftn instance void datapick.tishi::tishi_Load(object, class [mscorlib]System.EventArgs)
		IL_0220: newobj instance void [mscorlib]System.EventHandler::.ctor(object, native int)
		IL_0225: call instance void [System.Windows.Forms]System.Windows.Forms.Form::add_Load(class [mscorlib]System.EventHandler)
		IL_022a: nop
		IL_022b: ldarg.0
		IL_022c: ldc.i4.0
		IL_022d: call instance void [System.Windows.Forms]System.Windows.Forms.Control::ResumeLayout(bool)
		IL_0232: nop
		IL_0233: ldarg.0
		IL_0234: call instance void [System.Windows.Forms]System.Windows.Forms.Control::PerformLayout()
		IL_0239: nop
		IL_023a: ret
	} // end of method tishi::InitializeComponent

	.method private hidebysig specialname rtspecialname static 
		void .cctor () cil managed 
	{
		// Method begins at RVA 0xa3d7
		// Header size: 1
		// Code size: 7 (0x7)
		.maxstack 8

		IL_0000: ldnull
		IL_0001: stsfld class datapick.tishi datapick.tishi::tis
		IL_0006: ret
	} // end of method tishi::.cctor

} // end of class datapick.tishi

