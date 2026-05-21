using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Office.Interop.Excel;
using ZedGraph;

namespace datapick;

public class Form1 : Form
{
	public struct SP_DEVICE_INTERFACE_DATA
	{
		public int cbSize;

		public Guid interfaceClassGuid;

		public int flags;

		public int reserved;
	}

	[StructLayout(LayoutKind.Sequential)]
	public class SP_DEVINFO_DATA
	{
		public int cbSize = Marshal.SizeOf(typeof(SP_DEVINFO_DATA));

		public Guid classGuid = Guid.Empty;

		public int devInst = 0;

		public int reserved = 0;
	}

	[StructLayout(LayoutKind.Sequential, Pack = 2)]
	internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
	{
		internal int cbSize;

		internal short devicePath;
	}

	public enum DIGCF
	{
		DIGCF_DEFAULT = 1,
		DIGCF_PRESENT = 2,
		DIGCF_ALLCLASSES = 4,
		DIGCF_PROFILE = 8,
		DIGCF_DEVICEINTERFACE = 0x10
	}

	internal struct HIDD_ATTRIBUTES
	{
		internal int Size;

		internal ushort VendorID;

		internal ushort ProductID;

		internal ushort VersionNumber;
	}

	private struct OVERLAPPED
	{
		public int Internal;

		public int InternalHigh;

		public int Offset;

		public int OffsetHigh;

		public int hEvent;
	}

	public const uint GENERIC_READ = 2147483648u;

	public const uint GENERIC_WRITE = 1073741824u;

	public const uint FILE_SHARE_READ = 1u;

	public const uint FILE_SHARE_WRITE = 2u;

	public const int OPEN_EXISTING = 3;

	public const int FILE_FLAG_OVERLAPPED = 1073741824;

	private Guid guidHID = Guid.Empty;

	private IntPtr hDevInfo;

	private bool listadd = false;

	private double Bdate = 0.0;

	private string Bdatedisplay;

	private double pinlv = 0.0;

	private double tempwendu = 0.0;

	private bool Ready = false;

	private bool boolDisplayData = false;

	private int ReadLength = 23;

	private int Circle = 1;

	private bool readsuccess = false;

	private string[] Bdate_highspeed;

	private int HighSpeedBase = 13;

	private int HighSpeedNO = 20;

	private string Speed = null;

	private string[] Bdate_lots = new string[500];

	private int[] nono_lots = new int[500];

	private string[] Date_lots = new string[500];

	private string[] Time_lots = new string[500];

	private string[] DateTime_lots = new string[500];

	private bool Ready_lots = false;

	private PointPairList list = new PointPairList();

	private LineItem myCurve;

	public static Form1 mf = null;

	private ulong nono = 1uL;

	private string mashineType = "";

	private bool dwChangeFlag = false;

	private string TdataReceived = null;

	private int FlagEnquire = 4;

	private int tishiflag = 0;

	private OVERLAPPED ovSEND = default(OVERLAPPED);

	private byte[] senddata = new byte[17];

	private int USBwrite = 0;

	private ProgressBar pb3;

	private int DWflag = 1;

	private string MODEL;

	private int DataType_flag = 0;

	private tishi ts = new tishi();

	private int HidHandle = -1;

	private Thread readUSB = null;

	private OVERLAPPED ovREAD = default(OVERLAPPED);

	private byte[] m_rd_data = new byte[65];

	private bool isread;

	private uint USBread = 0u;

	private float temp;

	private float temp_abs;

	private int communicate_fangshi = 0;

	private IContainer components = null;

	private System.Windows.Forms.GroupBox groupBox1;

	private SerialPort serialPort1;

	private System.Windows.Forms.GroupBox groupBox5;

	private System.Windows.Forms.Label labelwendu;

	private System.Windows.Forms.GroupBox groupBox4;

	private System.Windows.Forms.Label labelpinlv;

	private System.Windows.Forms.GroupBox groupBox2;

	private System.Windows.Forms.Label labelcichang;

	private ComboBox comboBoxBAUDE;

	private System.Windows.Forms.Label label2;

	private ComboBox comboBoxCOM;

	private System.Windows.Forms.Label label1;

	private System.Windows.Forms.Button buttonZERO;

	private System.Windows.Forms.Button buttonSTOP;

	private System.Windows.Forms.Button buttonSTART;

	private System.Windows.Forms.Timer timerTIME;

	private DataGridView dataGridViewDATA;

	private System.Windows.Forms.Button buttonLISTCLEAR;

	private System.Windows.Forms.Button buttonEXCEL;

	private ComboBox comboBoxdanwei;

	private System.Windows.Forms.Label label3;

	private StatusStrip StatusStrip1;

	private ToolStripStatusLabel ToolStripStatusLabel1;

	private ToolStripStatusLabel toolStripStatusLabel2;

	private RadioButton radioButton2;

	private RadioButton radioButton1;

	private ZedGraphControl zedTIME;

	private System.Windows.Forms.Label labelSource;

	private ComboBox comboBoxSource;

	private System.Windows.Forms.Timer timer1;

	private ComboBox comboBoxfangshi;

	private System.Windows.Forms.Label label4;

	private System.Windows.Forms.Timer timerRecieve;

	private System.Windows.Forms.Timer timerUSBread;

	private System.Windows.Forms.Label label5;

	public System.Windows.Forms.GroupBox groupBox6;

	public System.Windows.Forms.GroupBox groupBox3;

	public ComboBox comboBoxDataType;

	private System.Windows.Forms.Label label6;

	private ComboBox comboBoxModel;

	public ComboBox comboBoxSpeed;

	private System.Windows.Forms.Label label7;

	private ComboBox comboBoxT;

	private System.Windows.Forms.Label label8;

	private System.Windows.Forms.Timer timerType;

	private SplitContainer splitContainer1;

	private System.Windows.Forms.Button button2;

	private System.Windows.Forms.Button button1;

	private System.Windows.Forms.Label label11;

	private System.Windows.Forms.Label label10;

	private System.Windows.Forms.Label label9;

	private System.Windows.Forms.CheckBox checkBox1;

	public Form1()
	{
		InitializeComponent();
		mf = this;
	}

	[DllImport("hid.dll")]
	public static extern void HidD_GetHidGuid(ref Guid HidGuid);

	[DllImport("setupapi.dll", SetLastError = true)]
	public static extern IntPtr SetupDiGetClassDevs(ref Guid ClassGuid, uint Enumerator, IntPtr HwndParent, DIGCF Flags);

	[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	public static extern bool SetupDiEnumDeviceInterfaces(IntPtr hDevInfo, IntPtr devInfo, ref Guid interfaceClassGuid, uint memberIndex, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData);

	[DllImport("setupapi.dll", CharSet = CharSet.Auto, SetLastError = true)]
	private static extern bool SetupDiGetDeviceInterfaceDetail(IntPtr deviceInfoSet, ref SP_DEVICE_INTERFACE_DATA deviceInterfaceData, IntPtr deviceInterfaceDetailData, int deviceInterfaceDetailDataSize, ref int requiredSize, SP_DEVINFO_DATA deviceInfoData);

	[DllImport("hid.dll")]
	private static extern bool HidD_GetAttributes(int HidhandleValue, ref HIDD_ATTRIBUTES hidDeviceAttributes);

	[DllImport("kernel32.dll", SetLastError = true)]
	private static extern int CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, uint lpSecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, uint hTemplateFile);

	[DllImport("Kernel32.dll", SetLastError = true)]
	private static extern bool ReadFile(IntPtr hFile, byte[] lpBuffer, uint nNumberOfBytesToRead, ref uint lpNumberOfBytesRead, ref OVERLAPPED lpOverlapped);

	[DllImport("kernel32.dll")]
	private static extern bool WriteFile(IntPtr hFile, byte[] lpBuffer, int nNumberOfBytesToWrite, ref int lpNumberOfBytesWritten, ref OVERLAPPED lpOverlapped);

	[DllImport("hid.dll")]
	public static extern bool HidD_FreePreparsedData(ref IntPtr PreparsedData);

	[DllImport("kernel32.dll")]
	public static extern int CloseHandle(int hObject);

	private bool isdoublenum(string ppp)
	{
		try
		{
			double xx = Convert.ToDouble(ppp.Trim());
			return true;
		}
		catch
		{
			return false;
		}
	}

	private void serialPort1_DataReceived(object sender, SerialDataReceivedEventArgs e)
	{
		if (FlagEnquire == 4)
		{
			if (DataType_flag == 1)
			{
				char[] Temp = new char[ReadLength];
				serialPort1.Read(Temp, 0, ReadLength);
				TdataReceived = new string(Temp);
				if (mashineType == "高斯计" && TdataReceived.Length == ReadLength && TdataReceived.StartsWith("#") && TdataReceived.EndsWith(">\n"))
				{
					TdataReceived = TdataReceived.TrimStart('#');
					TdataReceived = TdataReceived.TrimEnd('\n');
					TdataReceived = TdataReceived.TrimEnd('>');
				}
				else if (mashineType == "磁通计" && TdataReceived.Length == ReadLength && TdataReceived.StartsWith("#") && TdataReceived.EndsWith(">\n"))
				{
					TdataReceived = TdataReceived.TrimStart('#');
					TdataReceived = TdataReceived.TrimEnd('\n');
					TdataReceived = TdataReceived.TrimEnd('>');
					if (TdataReceived.StartsWith("F"))
					{
						TdataReceived = TdataReceived.TrimStart('F');
						if (DWflag != 5 && DWflag != 6)
						{
							dwChangeFlag = true;
						}
					}
					else
					{
						if (!TdataReceived.StartsWith("M") && !TdataReceived.StartsWith("B"))
						{
							return;
						}
						TdataReceived = TdataReceived.TrimStart('M');
						TdataReceived = TdataReceived.TrimStart('B');
						if (DWflag == 5 || DWflag == 6)
						{
							dwChangeFlag = true;
						}
					}
				}
				if (isdoublenum(TdataReceived.Split('/')[0]) && isdoublenum(TdataReceived.Split('/')[1]) && isdoublenum(TdataReceived.Split('/')[2]))
				{
					Bdatedisplay = BdataDisplayConvert(TdataReceived.Split('/')[0]);
					Bdate = Convert.ToDouble(Bdatedisplay.Trim());
					pinlv = Convert.ToDouble(TdataReceived.Split('/')[1]);
					tempwendu = Convert.ToDouble(TdataReceived.Split('/')[2]) / 10.0;
					listadd = true;
					if (!Ready)
					{
						Ready = true;
					}
				}
			}
			else if (DataType_flag == 2)
			{
				char[] highspeedRead = new char[HighSpeedNO * HighSpeedBase];
				try
				{
					serialPort1.Read(highspeedRead, 0, HighSpeedNO * HighSpeedBase);
				}
				catch
				{
					return;
				}
				TdataReceived = new string(highspeedRead);
				readsuccess = true;
			}
			else
			{
				if (DataType_flag != 3)
				{
					return;
				}
				int i = 0;
				Thread.Sleep(1000);
				TdataReceived = serialPort1.ReadExisting();
				string[] temp = TdataReceived.Split('\n');
				for (; i < 500; i++)
				{
					Bdate_lots[i] = temp[i].Split(' ')[2];
					if (Bdate_lots[i].Contains(";"))
					{
						Bdate_lots[i] = Bdate_lots[i].Substring(0, 1) + Bdate_lots[i].Substring(2);
					}
					nono_lots[i] = Convert.ToInt32(temp[i].Split(' ')[0].Trim('.')) + 1;
					Date_lots[i] = temp[i].Split(' ')[10].Trim();
					Time_lots[i] = temp[i].Split(' ')[14].Trim();
					if (Convert.ToInt32(Date_lots[i].Split('-')[0]) < DateTime.Now.Month)
					{
						DateTime_lots[i] = DateTime.Now.Year + "-" + Date_lots[i] + " " + Time_lots[i];
					}
					else
					{
						DateTime_lots[i] = DateTime.Now.Year - 1 + "-" + Date_lots[i] + " " + Time_lots[i];
					}
				}
				Ready_lots = true;
			}
		}
		else
		{
			if (FlagEnquire != 1)
			{
				return;
			}
			char[] Temp = new char[5];
			serialPort1.Read(Temp, 0, 5);
			TdataReceived = new string(Temp);
			if ((TdataReceived.StartsWith("W") || TdataReceived.StartsWith("N")) && TdataReceived.EndsWith("\n"))
			{
				TdataReceived = TdataReceived.TrimEnd('\n');
				if (TdataReceived == "WEAK")
				{
					FlagEnquire = 2;
				}
				else if (TdataReceived == "NORM")
				{
					FlagEnquire = 3;
				}
			}
		}
	}

	private void InitialSetting()
	{
		string Model = SystemConfig.GetConfigData("MODEL", "CH-1300");
		for (int i = 0; i < comboBoxModel.Items.Count; i++)
		{
			if (Model == comboBoxModel.Items[i].ToString())
			{
				comboBoxModel.SelectedIndex = i;
				break;
			}
		}
		string ComWay = SystemConfig.GetConfigData("COMWAY", "串口");
		for (int i = 0; i < comboBoxfangshi.Items.Count; i++)
		{
			if (ComWay == comboBoxfangshi.Items[i].ToString())
			{
				comboBoxfangshi.SelectedIndex = i;
				break;
			}
		}
		string COMPORTNAME = SystemConfig.GetConfigData("COMMSET", "COM1");
		string COMBAUDRATE = SystemConfig.GetConfigData("BADURATE", "9600");
		for (int i = 0; i < comboBoxCOM.Items.Count; i++)
		{
			if (COMPORTNAME == comboBoxCOM.Items[i].ToString())
			{
				comboBoxCOM.SelectedIndex = i;
				break;
			}
		}
		for (int i = 0; i < comboBoxBAUDE.Items.Count; i++)
		{
			if (COMBAUDRATE == comboBoxBAUDE.Items[i].ToString())
			{
				comboBoxBAUDE.SelectedIndex = i;
				break;
			}
		}
		string DataType = SystemConfig.GetConfigData("DATATYPE", "普通数据");
		for (int i = 0; i < comboBoxDataType.Items.Count; i++)
		{
			if (DataType == comboBoxDataType.Items[i].ToString())
			{
				comboBoxDataType.SelectedIndex = i;
				break;
			}
		}
		string Speed = SystemConfig.GetConfigData("SPEED", "50组/s");
		for (int i = 0; i < comboBoxSpeed.Items.Count; i++)
		{
			if (Speed == comboBoxSpeed.Items[i].ToString())
			{
				comboBoxSpeed.SelectedIndex = i;
				break;
			}
		}
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		StatusStrip1.LayoutStyle = ToolStripLayoutStyle.HorizontalStackWithOverflow;
		toolStripStatusLabel2.Alignment = ToolStripItemAlignment.Right;
		dataGridViewDATA.RowHeadersVisible = false;
		dataGridViewDATA.Rows.Clear();
		dataGridViewDATA.Columns.Clear();
		dataGridViewDATA.Columns.Add("no", "序号");
		dataGridViewDATA.Columns.Add("T", "磁场值(mT)");
		dataGridViewDATA.Columns.Add("H", "频率(Hz)");
		dataGridViewDATA.Columns.Add("C", "温度(℃)");
		dataGridViewDATA.Columns.Add("TIME", "时间");
		dataGridViewDATA.Columns["no"].Width = 74;
		dataGridViewDATA.Columns["T"].Width = 104;
		dataGridViewDATA.Columns["H"].Width = 90;
		dataGridViewDATA.Columns["C"].Width = 90;
		dataGridViewDATA.Columns["TIME"].Width = 163;
		dataGridViewDATA.Columns[0].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewDATA.Columns[1].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewDATA.Columns[2].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewDATA.Columns[3].SortMode = DataGridViewColumnSortMode.NotSortable;
		dataGridViewDATA.Columns[4].SortMode = DataGridViewColumnSortMode.NotSortable;
		zedTIME.GraphPane.Fill = new Fill(Color.Green, Color.Blue, 45f);
		zedTIME.GraphPane.Chart.Fill.Type = FillType.None;
		zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
		zedTIME.GraphPane.XAxis.Title.Text = "时间";
		zedTIME.GraphPane.YAxis.Title.Text = "磁场值(mT)";
		zedTIME.GraphPane.XAxis.Type = AxisType.DateAsOrdinal;
		zedTIME.GraphPane.XAxis.Scale.Max = 100.0;
		zedTIME.GraphPane.XAxis.Scale.MajorStep = 20.0;
		zedTIME.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.Gold;
		zedTIME.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.Gold;
		zedTIME.GraphPane.Title.FontSpec.FontColor = Color.White;
		zedTIME.GraphPane.XAxis.Title.FontSpec.FontColor = Color.White;
		zedTIME.GraphPane.YAxis.Title.FontSpec.FontColor = Color.White;
		zedTIME.GraphPane.YAxis.Color = Color.Transparent;
		for (int i = 0; i <= 100; i++)
		{
			double x = new XDate(DateTime.Now.AddSeconds(-(100 - i)));
			double y = 0.0;
			list.Add(x, y);
		}
		myCurve = zedTIME.GraphPane.AddCurve("", list, Color.Yellow, SymbolType.None);
		zedTIME.AxisChange();
		zedTIME.Refresh();
		InitialSetting();
		comboBoxT.SelectedIndex = 0;
		radioButton1.Checked = true;
		radioButton2.Checked = false;
	}

	private void UnitChange(double Bdata, string Bdatadisplay)
	{
		if (dwChangeFlag)
		{
			if (comboBoxdanwei.SelectedIndex < 2)
			{
				comboBoxdanwei.SelectedIndex = 2;
			}
			else
			{
				comboBoxdanwei.SelectedIndex = 0;
			}
			dwChangeFlag = false;
		}
		switch (DWflag)
		{
		case 1:
			if (Math.Abs(Bdata) <= 2900.0)
			{
				labelcichang.Text = Bdatadisplay;
				groupBox2.Text = "磁场值(mT)";
				break;
			}
			groupBox2.Text = "磁场值(T)";
			if (Bdata >= 0.0)
			{
				labelcichang.Text = "+" + (Bdata / 1000.0).ToString("00.0000");
			}
			else
			{
				labelcichang.Text = (Bdata / 1000.0).ToString("00.0000");
			}
			break;
		case 2:
			if (Math.Abs(Bdata * 10.0) <= 300.0)
			{
				groupBox2.Text = "磁场值(G)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("000.000");
				}
			}
			else if (Math.Abs(Bdata * 10.0) <= 3000.0)
			{
				groupBox2.Text = "磁场值(G)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("0000.00");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("0000.00");
				}
			}
			else if (Math.Abs(Bdata * 10.0) <= 29000.0)
			{
				groupBox2.Text = "磁场值(G)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("00000.0");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("00000.0");
				}
			}
			else
			{
				groupBox2.Text = "磁场值(KG)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0 / 1000.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0 / 1000.0).ToString("000.000");
				}
			}
			break;
		case 3:
			if (Math.Abs(Bdata * 795.77) < 10000.0)
			{
				if (Bdata * 795.77 >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 795.77).ToString("0000.00");
				}
				else
				{
					labelcichang.Text = (Bdata * 795.77).ToString("0000.00");
				}
				break;
			}
			groupBox2.Text = "磁场值(KA/m)";
			if (Math.Abs(Bdata * 795.77 / 1000.0) <= 100.0)
			{
				if (Bdata * 795.77 / 1000.0 >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 795.77 / 1000.0).ToString("00.0000");
				}
				else
				{
					labelcichang.Text = (Bdata * 795.77 / 1000.0).ToString("00.0000");
				}
			}
			else if (Math.Abs(Bdata * 795.77 / 1000.0) <= 1000.0)
			{
				if (Bdata * 795.77 / 1000.0 >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 795.77 / 1000.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 795.77 / 1000.0).ToString("000.000");
				}
			}
			else if (Bdata * 795.77 / 1000.0 >= 0.0)
			{
				labelcichang.Text = "+" + (Bdata * 795.77 / 1000.0).ToString("0000.00");
			}
			else
			{
				labelcichang.Text = (Bdata * 795.77 / 1000.0).ToString("0000.00");
			}
			break;
		case 4:
			if (Math.Abs(Bdata * 10.0) <= 300.0)
			{
				groupBox2.Text = "磁场值(Oe)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("000.000");
				}
			}
			else if (Math.Abs(Bdata * 10.0) <= 3000.0)
			{
				groupBox2.Text = "磁场值(Oe)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("0000.00");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("0000.00");
				}
			}
			else if (Math.Abs(Bdata * 10.0) <= 29000.0)
			{
				groupBox2.Text = "磁场值(Oe)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("00000.0");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("00000.0");
				}
			}
			else
			{
				groupBox2.Text = "磁场值(KOe)";
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0 / 1000.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0 / 1000.0).ToString("000.000");
				}
			}
			break;
		case 5:
			labelcichang.Text = Bdatadisplay;
			break;
		case 6:
			if (Math.Abs(Bdata * 100.0) <= 300.0)
			{
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 100.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 100.0).ToString("000.000");
				}
			}
			else if (Math.Abs(Bdata * 100.0) <= 3000.0)
			{
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 100.0).ToString("0000.00");
				}
				else
				{
					labelcichang.Text = (Bdata * 100.0).ToString("0000.00");
				}
			}
			else if (Bdata >= 0.0)
			{
				labelcichang.Text = "+" + (Bdata * 100.0).ToString("00000.0");
			}
			else
			{
				labelcichang.Text = (Bdata * 100.0).ToString("00000.0");
			}
			break;
		case 7:
			labelcichang.Text = Bdatadisplay;
			break;
		case 8:
			if (Math.Abs(Bdata * 10.0) <= 300.0)
			{
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("000.000");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("000.000");
				}
			}
			else if (Math.Abs(Bdata * 10.0) <= 3000.0)
			{
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("0000.00");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("0000.00");
				}
			}
			else if (Math.Abs(Bdata * 10.0) <= 29000.0)
			{
				if (Bdata >= 0.0)
				{
					labelcichang.Text = "+" + (Bdata * 10.0).ToString("00000.0");
				}
				else
				{
					labelcichang.Text = (Bdata * 10.0).ToString("00000.0");
				}
			}
			break;
		}
	}

	private string BdataDisplayConvert(string Bdata)
	{
		double BB = 0.0;
		try
		{
			BB = Convert.ToDouble(Bdata);
			if (BB >= 0.0)
			{
				if (MODEL == "CH-1500")
				{
					return '+' + BB.ToString("0.00");
				}
				if (MODEL == "CH-1300")
				{
					return '+' + BB.ToString("0.0");
				}
				return '+' + BB.ToString("0.0000");
			}
			if (MODEL == "CH-1500")
			{
				return BB.ToString("0.00");
			}
			if (MODEL == "CH-1300")
			{
				return BB.ToString("0.0");
			}
			return BB.ToString("0.0000");
		}
		catch
		{
			return null;
		}
	}

	private void timerTIME_Tick_1(object sender, EventArgs e)
	{
		if (DataType_flag == 1)
		{
			if (!boolDisplayData)
			{
				return;
			}
			if (Ready)
			{
				boolDisplayData = false;
				labelpinlv.Text = pinlv.ToString();
				labelwendu.Text = tempwendu.ToString();
				UnitChange(Bdate, Bdatedisplay);
				if (tishiflag == 0)
				{
					tishiflag = 2;
					if (comboBoxfangshi.SelectedIndex == 0)
					{
						if (MODEL != "CH-260磁通手动" && MODEL != "CH-290磁通手动" && MODEL != "CH-260磁强手动" && MODEL != "CH-290磁强手动")
						{
							MessageBox.Show("成功通过 串口 连接" + comboBoxSource.SelectedItem.ToString() + "!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						}
					}
					else if (comboBoxfangshi.SelectedIndex == 1 && MODEL != "CH-260磁通手动" && MODEL != "CH-290磁通手动" && MODEL != "CH-260磁强手动" && MODEL != "CH-290磁强手动")
					{
						MessageBox.Show("成功通过 USB 连接" + comboBoxSource.SelectedItem.ToString() + "!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			if (listadd)
			{
				listadd = false;
				dataGridViewDATA.Rows.Add(nono, Bdate, pinlv, tempwendu, DateTime.Now);
				dataGridViewDATA.FirstDisplayedScrollingRowIndex = dataGridViewDATA.RowCount - 1;
				nono++;
				if (list.Count >= 100)
				{
					list.RemoveAt(0);
				}
				double x = new XDate(DateTime.Now);
				double y = Bdate;
				list.Add(x, y);
				zedTIME.AxisChange();
				zedTIME.Refresh();
			}
		}
		else if (DataType_flag == 2)
		{
			if (!readsuccess)
			{
				return;
			}
			readsuccess = false;
			if (list.Count >= HighSpeedNO * 10)
			{
				list.RemoveRange(0, HighSpeedNO);
			}
			Bdate_highspeed = TdataReceived.Split('\n');
			double y = 0.0;
			for (int j = 0; j < Bdate_highspeed.Length - 1; j++)
			{
				if (Bdate_highspeed[j].Length == HighSpeedBase - 1)
				{
					Bdate_highspeed[j] = Bdate_highspeed[j].TrimStart('#').TrimEnd('>');
					Bdate_highspeed[j] = BdataDisplayConvert(Bdate_highspeed[j]);
					if (Bdate_highspeed[j] != null)
					{
						dataGridViewDATA.Rows.Add(nono, Bdate_highspeed[j], 0, 0, DateTime.Now);
						double x = new XDate(DateTime.Now);
						y = Convert.ToDouble(Bdate_highspeed[j]);
						list.Add(x, y);
						nono++;
					}
					continue;
				}
				return;
			}
			try
			{
				dataGridViewDATA.FirstDisplayedScrollingRowIndex = dataGridViewDATA.RowCount - 1;
			}
			catch
			{
				return;
			}
			UnitChange(y, Bdate_highspeed[Bdate_highspeed.Length - 2]);
			zedTIME.AxisChange();
			zedTIME.Refresh();
		}
		else if (DataType_flag == 3 && Ready_lots)
		{
			for (int j = 0; j < 500; j++)
			{
				dataGridViewDATA.Rows.Add(nono_lots[j], Bdate_lots[j], 0, 0, DateTime_lots[j]);
			}
			Ready_lots = false;
			tishi.tis.label1.Text = "读取完成！";
			tishi.tis.button1.Text = "确定";
		}
	}

	private void buttonSTART_Click(object sender, EventArgs e)
	{
		FlagEnquire = 4;
		if (FlagEnquire == 4)
		{
			if (comboBoxfangshi.SelectedIndex == 0)
			{
				if (DataType_flag == 1)
				{
					zedTIME.GraphPane.XAxis.Scale.Max = 100.0;
					zedTIME.GraphPane.XAxis.Scale.MajorStep = 20.0;
					serialPort1.ReceivedBytesThreshold = ReadLength;
					timer1.Enabled = true;
					timer1.Start();
				}
				else if (DataType_flag == 2)
				{
					list.Clear();
					zedTIME.GraphPane.XAxis.Scale.Max = 10 * HighSpeedNO;
					zedTIME.GraphPane.XAxis.Scale.MajorStep = 2 * HighSpeedNO;
					serialPort1.ReceivedBytesThreshold = HighSpeedBase * HighSpeedNO;
					try
					{
						if (comboBoxModel.SelectedItem.ToString() == "CH-1500" || comboBoxModel.SelectedItem.ToString() == "CH-1500B")
						{
							serialPort1.Write("DATA?>" + Speed + "NORM>");
						}
						else
						{
							serialPort1.Write(Speed);
							Thread.Sleep(300);
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					}
				}
				try
				{
					communicate_fangshi = 1;
					if (MODEL != "CH-260磁通手动" && MODEL != "CH-290磁通手动" && MODEL != "CH-260磁强手动" && MODEL != "CH-290磁强手动" && DataType_flag != 2)
					{
						serialPort1.Write("DATA?>");
					}
					buttonSTART.BackColor = Color.Lime;
					buttonSTOP.BackColor = label1.BackColor;
				}
				catch (Exception ex)
				{
					buttonSTART.BackColor = label1.BackColor;
					buttonSTOP.BackColor = label1.BackColor;
					MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else if (comboBoxfangshi.SelectedIndex == 1)
			{
				if (HidHandle == -1)
				{
					MessageBox.Show("未连接USB设备", "提示");
					return;
				}
				timer1.Enabled = true;
				timer1.Start();
				try
				{
					communicate_fangshi = 2;
					senddata[1] = 17;
					bool result = WriteFile((IntPtr)HidHandle, senddata, 17, ref USBwrite, ref ovSEND);
					timerRecieve.Enabled = true;
					Thread.Sleep(10);
					timerUSBread.Enabled = true;
					buttonSTART.BackColor = Color.Lime;
					buttonSTOP.BackColor = label1.BackColor;
				}
				catch (Exception ex)
				{
					buttonSTART.BackColor = label1.BackColor;
					buttonSTOP.BackColor = label1.BackColor;
					MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
			}
			buttonSTART.Enabled = false;
		}
		else if (FlagEnquire == 0)
		{
			try
			{
				timerType.Enabled = true;
				FlagEnquire = 1;
				serialPort1.Write("DATAC>");
				Thread.Sleep(100);
				serialPort1.DiscardInBuffer();
				serialPort1.ReceivedBytesThreshold = 5;
				serialPort1.Write("TYPE>");
				Thread.Sleep(500);
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
	}

	private void buttonSTOP_Click(object sender, EventArgs e)
	{
		if (comboBoxfangshi.SelectedIndex == 0)
		{
			try
			{
				timer1.Enabled = false;
				if (serialPort1.IsOpen)
				{
					serialPort1.Write("DATAC>");
					Thread.Sleep(500);
					serialPort1.DiscardInBuffer();
				}
				buttonSTOP.BackColor = Color.Red;
				buttonSTART.BackColor = label1.BackColor;
			}
			catch (Exception ex)
			{
				buttonSTART.BackColor = label1.BackColor;
				buttonSTOP.BackColor = label1.BackColor;
				MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
		}
		else if (comboBoxfangshi.SelectedIndex == 1)
		{
			if (HidHandle == -1)
			{
				return;
			}
			try
			{
				timer1.Enabled = false;
				timerRecieve.Enabled = false;
				timerUSBread.Enabled = false;
				readUSB.Abort();
				senddata[1] = 18;
				bool result = WriteFile((IntPtr)HidHandle, senddata, 17, ref USBwrite, ref ovSEND);
				buttonSTOP.BackColor = Color.Red;
				buttonSTART.BackColor = label1.BackColor;
				Thread.Sleep(100);
				Ready = false;
			}
			catch (Exception)
			{
				buttonSTART.BackColor = label1.BackColor;
				buttonSTOP.BackColor = label1.BackColor;
				return;
			}
		}
		buttonSTART.Enabled = true;
	}

	private void buttonZERO_Click(object sender, EventArgs e)
	{
		if (comboBoxfangshi.SelectedIndex == 0)
		{
			try
			{
				serialPort1.Write("ZERO>");
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
		if (comboBoxfangshi.SelectedIndex != 1)
		{
			return;
		}
		if (HidHandle != -1)
		{
			try
			{
				senddata[1] = 32;
				bool result = WriteFile((IntPtr)HidHandle, senddata, 17, ref USBwrite, ref ovSEND);
				return;
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
		}
		MessageBox.Show("未连接USB设备", "提示");
	}

	private void buttonLISTCLEAR_Click(object sender, EventArgs e)
	{
		dataGridViewDATA.Rows.Clear();
		nono = 1uL;
	}

	public void quick_get_current_Data_out()
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "Execl文件(*.xls)|*.xls";
		saveFileDialog.FilterIndex = 0;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.CreatePrompt = true;
		saveFileDialog.Title = "数据视图导出EXCEL文件";
		saveFileDialog.ShowDialog();
		Stream myStream = saveFileDialog.OpenFile();
		StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("Unicode"));
		string str = "";
		DateTime start = DateTime.Now;
		try
		{
			for (int i = 0; i < dataGridViewDATA.ColumnCount; i++)
			{
				if (i > 0)
				{
					str += "\t";
				}
				str += dataGridViewDATA.Columns[i].HeaderText;
			}
			sw.WriteLine(str);
			for (int j = 0; j < dataGridViewDATA.Rows.Count; j++)
			{
				string tempStr = "";
				for (int k = 0; k < dataGridViewDATA.Columns.Count; k++)
				{
					if (k > 0)
					{
						tempStr += "\t";
					}
					tempStr = ((dataGridViewDATA.Rows[j].Cells[k].Value != null) ? ((!checkBox1.Checked || k != 1) ? (tempStr + dataGridViewDATA.Rows[j].Cells[k].Value.ToString()) : (tempStr + Math.Abs(Convert.ToDouble(dataGridViewDATA.Rows[j].Cells[k].Value)))) : (tempStr + string.Empty));
				}
				sw.WriteLine(tempStr);
			}
			sw.Close();
			myStream.Close();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message);
		}
		finally
		{
			sw.Close();
			myStream.Close();
		}
		MessageBox.Show("转换结束，将此工作表导出为excel共耗时：" + DateTime.Now.Subtract(start).TotalMilliseconds + "毫秒");
	}

	private void buttonEXCEL_Click(object sender, EventArgs e)
	{
		dataGridViewDATA.Rows.Add(11, 11, 11);
		if (dataGridViewDATA.Rows.Count != 0)
		{
			quick_get_current_Data_out();
		}
	}

	public void PrintGridView(DataGridView gvList)
	{
		pb3 = new ProgressBar();
		pb3.Value = 0;
		pb3.Step = 1;
		base.Controls.Add(pb3);
		pb3.BringToFront();
		pb3.Visible = true;
		pb3.Tag = 9988;
		pb3.BringToFront();
		pb3.Width = 280;
		pb3.Height = 30;
		System.Drawing.Point pnt = new System.Drawing.Point(217, 271);
		pb3.Location = pnt;
		Microsoft.Office.Interop.Excel.Application excel = new ApplicationClass();
		excel.Application.Workbooks.Add(true);
		int rowsCount = gvList.Rows.Count;
		int colsCount = gvList.Columns.Count;
		excel.Workbooks.Add(Missing.Value);
		Worksheet sheet = (Worksheet)excel.ActiveSheet;
		int columnCount = gvList.Columns.Count;
		pb3.Maximum = rowsCount + 1;
		for (int i = 0; i < columnCount; i++)
		{
			Range headRange = sheet.Cells[1, i + 1] as Range;
			headRange.Value2 = gvList.Columns[i].HeaderText;
			headRange.Font.Name = "宋体";
			headRange.Font.Size = 12;
			headRange.HorizontalAlignment = XlHAlign.xlHAlignCenter;
			headRange.VerticalAlignment = XlVAlign.xlVAlignCenter;
			headRange.ColumnWidth = gvList.Columns[i].Width / 8;
			headRange.Borders.LineStyle = XlLineStyle.xlContinuous;
			headRange.Borders.Weight = XlBorderWeight.xlHairline;
		}
		if (gvList.Rows[rowsCount - 1].IsNewRow)
		{
			rowsCount--;
		}
		for (int columnsIndex = 0; columnsIndex < colsCount; columnsIndex++)
		{
			if (gvList.Columns[columnsIndex].Visible)
			{
				excel.Cells[1, columnsIndex + 1] = gvList.Columns[columnsIndex].HeaderText;
			}
		}
		for (int rowIndex = 0; rowIndex < rowsCount; rowIndex++)
		{
			for (int columnsIndex = 0; columnsIndex < colsCount; columnsIndex++)
			{
				if (gvList.Columns[columnsIndex].Visible)
				{
					if (gvList.Rows[rowIndex].Cells[columnsIndex].ValueType == typeof(string))
					{
						excel.Cells[rowIndex + 2, columnsIndex + 1] = "'" + gvList.Rows[rowIndex].Cells[columnsIndex].Value.ToString();
					}
					else
					{
						excel.Cells[rowIndex + 2, columnsIndex + 1] = gvList.Rows[rowIndex].Cells[columnsIndex].Value.ToString();
					}
					pb3.PerformStep();
				}
			}
		}
		pb3.PerformStep();
		pb3.Dispose();
		excel.Visible = true;
	}

	private void comboBoxCOM_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (serialPort1.IsOpen)
			{
				serialPort1.Close();
			}
			serialPort1.PortName = comboBoxCOM.SelectedItem.ToString().Trim();
			serialPort1.Open();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void comboBoxBAUDE_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (serialPort1.IsOpen)
			{
				serialPort1.Close();
			}
			serialPort1.BaudRate = Convert.ToInt32(comboBoxBAUDE.SelectedItem.ToString().Trim());
			serialPort1.Open();
		}
		catch (Exception ex)
		{
			MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
		}
	}

	private void comboBoxdanwei_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBoxSource.SelectedItem.ToString() == "高斯计")
		{
			zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
			zedTIME.GraphPane.XAxis.Title.Text = "时间";
			dataGridViewDATA.Columns["T"].HeaderText = "磁场值(mT)";
			zedTIME.GraphPane.YAxis.Title.Text = "磁场值(mT)";
			zedTIME.AxisChange();
			zedTIME.Refresh();
			if (comboBoxdanwei.SelectedItem.ToString() == "mT")
			{
				groupBox2.Text = "磁场值(mT)";
				DWflag = 1;
			}
			else if (comboBoxdanwei.SelectedItem.ToString() == "G")
			{
				groupBox2.Text = "磁场值(G)";
				DWflag = 2;
			}
			else if (comboBoxdanwei.SelectedItem.ToString() == "A/m")
			{
				groupBox2.Text = "磁场值(A/m)";
				DWflag = 3;
			}
			else if (comboBoxdanwei.SelectedItem.ToString() == "Oe")
			{
				groupBox2.Text = "磁场值(Oe)";
				DWflag = 4;
			}
		}
		else if (comboBoxSource.SelectedItem.ToString() == "高斯计(弱磁)")
		{
			zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
			zedTIME.GraphPane.XAxis.Title.Text = "时间";
			dataGridViewDATA.Columns["T"].HeaderText = "磁场值(μT)";
			zedTIME.GraphPane.YAxis.Title.Text = "磁场值(μT)";
			zedTIME.AxisChange();
			zedTIME.Refresh();
			if (comboBoxdanwei.SelectedItem.ToString() == "μT")
			{
				groupBox2.Text = "磁场值(μT)";
				DWflag = 7;
			}
			else if (comboBoxdanwei.SelectedItem.ToString() == "mG")
			{
				groupBox2.Text = "磁场值(mG)";
				DWflag = 8;
			}
		}
		else if (comboBoxSource.SelectedItem.ToString() == "磁通计")
		{
			switch (comboBoxdanwei.SelectedItem.ToString())
			{
			case "mWb":
				groupBox2.Text = "磁通量(mWb)";
				DWflag = 5;
				dataGridViewDATA.Columns["T"].HeaderText = "磁通量(mWb)";
				zedTIME.GraphPane.Title.Text = "实时磁通大小变化图";
				zedTIME.GraphPane.XAxis.Title.Text = "时间";
				zedTIME.GraphPane.YAxis.Title.Text = "磁通量(mWb)";
				zedTIME.AxisChange();
				zedTIME.Refresh();
				break;
			case "kMx":
				groupBox2.Text = "磁通量(kMx)";
				DWflag = 6;
				dataGridViewDATA.Columns["T"].HeaderText = "磁通量(mWb)";
				zedTIME.GraphPane.Title.Text = "实时磁通大小变化图";
				zedTIME.GraphPane.XAxis.Title.Text = "时间";
				zedTIME.GraphPane.YAxis.Title.Text = "磁通量(mWb)";
				zedTIME.AxisChange();
				zedTIME.Refresh();
				break;
			case "mT":
				groupBox2.Text = "磁场值(mT)";
				DWflag = 1;
				dataGridViewDATA.Columns["T"].HeaderText = "磁场值(mT)";
				zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
				zedTIME.GraphPane.XAxis.Title.Text = "时间";
				zedTIME.GraphPane.YAxis.Title.Text = "磁场值(mT)";
				zedTIME.AxisChange();
				zedTIME.Refresh();
				break;
			case "G":
				groupBox2.Text = "磁场值(G)";
				DWflag = 2;
				dataGridViewDATA.Columns["T"].HeaderText = "磁场值(mT)";
				zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
				zedTIME.GraphPane.XAxis.Title.Text = "时间";
				zedTIME.GraphPane.YAxis.Title.Text = "磁场值(mT)";
				zedTIME.AxisChange();
				zedTIME.Refresh();
				break;
			case "A/m":
				groupBox2.Text = "磁场值(A/m)";
				DWflag = 3;
				dataGridViewDATA.Columns["T"].HeaderText = "磁场值(mT)";
				zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
				zedTIME.GraphPane.XAxis.Title.Text = "时间";
				zedTIME.GraphPane.YAxis.Title.Text = "磁场值(mT)";
				zedTIME.AxisChange();
				zedTIME.Refresh();
				break;
			case "Oe":
				groupBox2.Text = "磁场值(Oe)";
				DWflag = 4;
				dataGridViewDATA.Columns["T"].HeaderText = "磁场值(mT)";
				zedTIME.GraphPane.Title.Text = "实时磁场大小变化图";
				zedTIME.GraphPane.XAxis.Title.Text = "时间";
				zedTIME.GraphPane.YAxis.Title.Text = "磁场值(mT)";
				zedTIME.AxisChange();
				zedTIME.Refresh();
				break;
			}
		}
	}

	private void radioButton1_CheckedChanged(object sender, EventArgs e)
	{
		if (radioButton1.Checked)
		{
			dataGridViewDATA.Visible = true;
			buttonLISTCLEAR.Text = "清空";
			buttonEXCEL.Text = "导出";
		}
	}

	private void radioButton2_CheckedChanged(object sender, EventArgs e)
	{
		if (radioButton2.Checked)
		{
			dataGridViewDATA.Visible = false;
			zedTIME.Visible = true;
			buttonLISTCLEAR.Text = "刷新";
			buttonEXCEL.Text = "保存";
		}
	}

	private void comboBoxModel_SelectedIndexChanged(object sender, EventArgs e)
	{
		MODEL = comboBoxModel.SelectedItem.ToString();
		if (MODEL == "CH-260" || MODEL == "CH-290" || MODEL == "CH-260磁通手动" || MODEL == "CH-290磁通手动")
		{
			comboBoxSource.SelectedIndex = 0;
		}
		else if (MODEL == "CH-1500B")
		{
			comboBoxSource.SelectedIndex = 2;
		}
		else
		{
			comboBoxSource.SelectedIndex = 1;
		}
		if (MODEL == "CH-260" || MODEL == "CH-1800" || MODEL == "CH-290" || MODEL == "CH-260磁通手动" || MODEL == "CH-290磁通手动")
		{
			ReadLength = 24;
			HighSpeedBase = 14;
		}
		else if (MODEL == "CH-1500")
		{
			ReadLength = 21;
			HighSpeedBase = 11;
		}
		else if (MODEL == "CH-1300")
		{
			ReadLength = 20;
		}
		else
		{
			ReadLength = 23;
			HighSpeedBase = 13;
		}
		comboBoxDataType.SelectedIndex = 0;
		if (MODEL == "CH-260" || MODEL == "CH-1300" || MODEL == "CH-290" || MODEL == "CH-260磁通手动" || MODEL == "CH-290磁通手动" || MODEL == "CH-260磁强手动" || MODEL == "CH-290磁强手动")
		{
			FlagEnquire = 4;
			comboBoxDataType.Items.Clear();
			comboBoxDataType.Items.Add("普通数据");
			comboBoxDataType.Items.Add("历史数据");
		}
		else
		{
			FlagEnquire = 0;
			comboBoxDataType.Items.Clear();
			comboBoxDataType.Items.Add("普通数据");
			comboBoxDataType.Items.Add("高速数据");
			comboBoxDataType.Items.Add("历史数据");
		}
		comboBoxDataType.SelectedIndex = 0;
		if ((MODEL == "CH-1500" || MODEL == "CH-1500B") && comboBoxSpeed.Items.Count == 6)
		{
			comboBoxSpeed.Items.RemoveAt(6);
		}
		else if (!comboBoxSpeed.Items.Contains("300组/s"))
		{
			comboBoxSpeed.Items.Add("300组/s");
		}
		comboBoxSpeed.SelectedIndex = 0;
		if (MODEL == "CH-1600" || MODEL == "CH-1800")
		{
			comboBoxfangshi.Items.Clear();
			comboBoxfangshi.Items.Add("串口");
			comboBoxfangshi.Items.Add("USB");
		}
		else
		{
			comboBoxfangshi.Items.Clear();
			comboBoxfangshi.Items.Add("串口");
		}
		comboBoxfangshi.SelectedIndex = 0;
	}

	private void comboBoxSource_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBoxSource.SelectedIndex == 0)
		{
			mashineType = "磁通计";
			if (comboBoxfangshi.SelectedIndex == 0)
			{
				if (serialPort1.IsOpen)
				{
					serialPort1.Write("DATAC>");
					serialPort1.Close();
				}
				try
				{
					serialPort1.Open();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else if (comboBoxfangshi.SelectedIndex == 1 && HidHandle != -1)
			{
				try
				{
					Ready = false;
					senddata[1] = 18;
					bool result = WriteFile((IntPtr)HidHandle, senddata, 17, ref USBwrite, ref ovSEND);
				}
				catch
				{
				}
			}
			comboBoxdanwei.Items.Clear();
			comboBoxdanwei.Items.Add("mWb");
			comboBoxdanwei.Items.Add("kMx");
			comboBoxdanwei.Items.Add("mT");
			comboBoxdanwei.Items.Add("G");
			comboBoxdanwei.Items.Add("A/m");
			comboBoxdanwei.Items.Add("Oe");
			comboBoxdanwei.SelectedIndex = 0;
		}
		else if (comboBoxSource.SelectedIndex == 1)
		{
			mashineType = "高斯计";
			if (comboBoxfangshi.SelectedIndex == 0)
			{
				if (serialPort1.IsOpen)
				{
					serialPort1.Write("DATAC>");
					serialPort1.Close();
				}
				try
				{
					serialPort1.Open();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			else if (comboBoxfangshi.SelectedIndex == 1 && HidHandle != -1)
			{
				try
				{
					Ready = false;
					senddata[1] = 18;
					bool result = WriteFile((IntPtr)HidHandle, senddata, 17, ref USBwrite, ref ovSEND);
				}
				catch
				{
				}
			}
			comboBoxdanwei.Items.Clear();
			comboBoxdanwei.Items.Add("mT");
			comboBoxdanwei.Items.Add("G");
			comboBoxdanwei.Items.Add("A/m");
			comboBoxdanwei.Items.Add("Oe");
			comboBoxdanwei.SelectedIndex = 0;
		}
		else
		{
			if (comboBoxSource.SelectedIndex != 2)
			{
				return;
			}
			mashineType = "高斯计";
			if (comboBoxfangshi.SelectedIndex == 0)
			{
				if (serialPort1.IsOpen)
				{
					serialPort1.Write("DATAC>");
					serialPort1.Close();
				}
				try
				{
					serialPort1.Open();
				}
				catch (Exception ex)
				{
					MessageBox.Show(ex.Message, "警告", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				}
			}
			comboBoxdanwei.Items.Clear();
			comboBoxdanwei.Items.Add("μT");
			comboBoxdanwei.Items.Add("mG");
			comboBoxdanwei.SelectedIndex = 0;
		}
	}

	private void comboBoxDataType_SelectedIndexChanged(object sender, EventArgs e)
	{
		buttonSTOP_Click(sender, e);
		if (comboBoxDataType.SelectedItem.ToString() == "普通数据")
		{
			comboBoxSpeed.Enabled = false;
			comboBoxT.Enabled = true;
			groupBox3.Enabled = true;
			DataType_flag = 1;
			timerTIME.Interval = 100;
			list.Clear();
		}
		else if (comboBoxDataType.SelectedItem.ToString() == "高速数据")
		{
			comboBoxSpeed.Enabled = true;
			comboBoxT.Enabled = false;
			groupBox3.Enabled = true;
			DataType_flag = 2;
			Ready = false;
			listadd = false;
			timerTIME.Interval = 10;
		}
		else
		{
			if (!(comboBoxDataType.SelectedItem.ToString() == "历史数据"))
			{
				return;
			}
			timerTIME.Interval = 100;
			if (comboBoxfangshi.SelectedIndex == 0)
			{
				DialogResult ettr = MessageBox.Show("请首先确认串口号与波特率设置正确，\r\n操作高斯计/磁通计，使用UART中的Transmit Saved功能，\r\n此过程需要大约25秒......", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
				if (ettr == DialogResult.OK)
				{
					serialPort1.ReceivedBytesThreshold = 20000;
					groupBox3.Enabled = false;
					groupBox6.Enabled = false;
					DataType_flag = 3;
					dataGridViewDATA.Focus();
					ts.ShowDialog();
					Ready = false;
					listadd = false;
				}
				else
				{
					comboBoxDataType.SelectedIndex = 0;
				}
			}
		}
	}

	private void comboBoxSpeed_SelectedIndexChanged(object sender, EventArgs e)
	{
		buttonSTOP_Click(sender, e);
		if (comboBoxSpeed.SelectedItem.ToString() == "50组/s")
		{
			Speed = "FAST050>";
			HighSpeedNO = 50;
		}
		else if (comboBoxSpeed.SelectedItem.ToString() == "20组/s")
		{
			Speed = "FAST2>";
			HighSpeedNO = 20;
		}
		else if (comboBoxSpeed.SelectedItem.ToString() == "100组/s")
		{
			Speed = "FAST100>";
			HighSpeedNO = 100;
		}
		else if (comboBoxSpeed.SelectedItem.ToString() == "150组/s")
		{
			Speed = "FAST150>";
			HighSpeedNO = 150;
		}
		else if (comboBoxSpeed.SelectedItem.ToString() == "200组/s")
		{
			Speed = "FAST200>";
			HighSpeedNO = 200;
		}
		else if (comboBoxSpeed.SelectedItem.ToString() == "250组/s")
		{
			Speed = "FAST250>";
			HighSpeedNO = 250;
		}
		else if (comboBoxSpeed.SelectedItem.ToString() == "300组/s")
		{
			Speed = "FAST300>";
			HighSpeedNO = 300;
		}
	}

	private void comboBoxT_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (comboBoxT.SelectedItem.ToString() == "默认")
		{
			timer1.Interval = 20;
		}
		else
		{
			timer1.Interval = Convert.ToInt32(comboBoxT.SelectedItem.ToString()) * 1000;
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		boolDisplayData = true;
	}

	private void WriteSystemConfig()
	{
		SystemConfig.WriteConfigData("MODEL", comboBoxModel.SelectedItem.ToString());
		SystemConfig.WriteConfigData("COMWAY", comboBoxfangshi.SelectedItem.ToString());
		SystemConfig.WriteConfigData("COMMSET", comboBoxCOM.SelectedItem.ToString());
		SystemConfig.WriteConfigData("BADURATE", comboBoxBAUDE.SelectedItem.ToString());
		SystemConfig.WriteConfigData("DATATYPE", comboBoxDataType.SelectedItem.ToString());
		SystemConfig.WriteConfigData("SPEED", comboBoxSpeed.SelectedItem.ToString());
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		WriteSystemConfig();
		if (comboBoxfangshi.SelectedIndex == 0)
		{
			if (serialPort1.IsOpen)
			{
				try
				{
					serialPort1.Write("DATAC>");
					serialPort1.Close();
				}
				catch
				{
				}
			}
		}
		else if (comboBoxfangshi.SelectedIndex == 1 && HidHandle != -1)
		{
			try
			{
				senddata[1] = 18;
				bool result = WriteFile((IntPtr)HidHandle, senddata, 17, ref USBwrite, ref ovSEND);
				CloseHandle(HidHandle);
			}
			catch
			{
			}
		}
	}

	private void comboBoxfangshi_SelectedIndexChanged(object sender, EventArgs e)
	{
		buttonSTOP_Click(sender, e);
		if (comboBoxfangshi.SelectedIndex == 0)
		{
			comboBoxCOM.Enabled = true;
			comboBoxBAUDE.Enabled = true;
			if (MODEL == "CH-260" || MODEL == "CH-1300" || MODEL == "CH-290" || MODEL == "CH-260磁通手动" || MODEL == "CH-290磁通手动" || MODEL == "CH-260磁强手动" || MODEL == "CH-290磁强手动")
			{
				comboBoxDataType.Items.Clear();
				comboBoxDataType.Items.Add("普通数据");
				comboBoxDataType.Items.Add("历史数据");
			}
			else
			{
				comboBoxDataType.Items.Clear();
				comboBoxDataType.Items.Add("普通数据");
				comboBoxDataType.Items.Add("高速数据");
				comboBoxDataType.Items.Add("历史数据");
			}
			comboBoxDataType.SelectedIndex = 0;
		}
		else
		{
			if (comboBoxfangshi.SelectedIndex != 1)
			{
				return;
			}
			comboBoxDataType.Items.Clear();
			comboBoxDataType.Items.Add("普通数据");
			comboBoxDataType.SelectedIndex = 0;
			comboBoxCOM.Enabled = false;
			comboBoxBAUDE.Enabled = false;
			HidD_GetHidGuid(ref guidHID);
			hDevInfo = SetupDiGetClassDevs(ref guidHID, 0u, IntPtr.Zero, (DIGCF)18);
			int bufferSize = 0;
			int index = 0;
			do
			{
				bool flag = true;
				SP_DEVICE_INTERFACE_DATA DeviceInterfaceData = default(SP_DEVICE_INTERFACE_DATA);
				DeviceInterfaceData.cbSize = Marshal.SizeOf(DeviceInterfaceData);
				bool result = SetupDiEnumDeviceInterfaces(hDevInfo, IntPtr.Zero, ref guidHID, (uint)index, ref DeviceInterfaceData);
				index++;
				SP_DEVINFO_DATA strtInterfaceData = new SP_DEVINFO_DATA();
				result = SetupDiGetDeviceInterfaceDetail(hDevInfo, ref DeviceInterfaceData, IntPtr.Zero, 0, ref bufferSize, strtInterfaceData);
				IntPtr detailDataBuffer = Marshal.AllocHGlobal(bufferSize);
				Marshal.StructureToPtr(new SP_DEVICE_INTERFACE_DETAIL_DATA
				{
					cbSize = Marshal.SizeOf(typeof(SP_DEVICE_INTERFACE_DETAIL_DATA))
				}, detailDataBuffer, fDeleteOld: false);
				result = SetupDiGetDeviceInterfaceDetail(hDevInfo, ref DeviceInterfaceData, detailDataBuffer, bufferSize, ref bufferSize, strtInterfaceData);
				IntPtr pdevicePathName = (IntPtr)((int)detailDataBuffer + 4);
				string devicePathName = Marshal.PtrToStringAuto(pdevicePathName);
				HidHandle = CreateFile(devicePathName, 3221225472u, 3u, 0u, 3u, 1073741824u, 0u);
				if (HidHandle != -1)
				{
					HIDD_ATTRIBUTES hidDeviceAttributes = new HIDD_ATTRIBUTES
					{
						Size = Marshal.SizeOf(typeof(HIDD_ATTRIBUTES))
					};
					result = HidD_GetAttributes(HidHandle, ref hidDeviceAttributes);
					if (hidDeviceAttributes.ProductID == 22352 && hidDeviceAttributes.VendorID == 1155)
					{
						return;
					}
				}
			}
			while (index != 1000);
			MessageBox.Show("查找USB设备失败!", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		}
	}

	private void timerRecieve_Tick(object sender, EventArgs e)
	{
		readUSB = new Thread(readUSBdata);
		readUSB.Start();
	}

	private void readUSBdata()
	{
		try
		{
			ovREAD.Offset = 0;
			isread = ReadFile((IntPtr)HidHandle, m_rd_data, 65u, ref USBread, ref ovREAD);
		}
		catch
		{
		}
	}

	private void timerUSBread_Tick(object sender, EventArgs e)
	{
		if (communicate_fangshi == 1)
		{
			comboBoxfangshi.SelectedIndex = 0;
		}
		else if (communicate_fangshi == 2)
		{
			comboBoxfangshi.SelectedIndex = 1;
		}
		if (!isread || !boolDisplayData)
		{
			return;
		}
		boolDisplayData = false;
		temp = PointerConvert.ToFloat(m_rd_data, 4);
		temp_abs = Math.Abs(temp);
		if (temp_abs < 30f)
		{
			Bdatedisplay = temp_abs.ToString("#00.0000");
		}
		else if (temp_abs < 300f)
		{
			Bdatedisplay = temp_abs.ToString("#000.000");
		}
		else
		{
			Bdatedisplay = temp_abs.ToString("#0000.00");
		}
		if (temp >= 0f)
		{
			Bdatedisplay = "+" + Bdatedisplay;
		}
		else
		{
			Bdatedisplay = "-" + Bdatedisplay;
		}
		Bdate = Convert.ToDouble(Bdatedisplay.Trim());
		tempwendu = Convert.ToDouble((float)(m_rd_data[12] + m_rd_data[13] * 256) / 10f);
		tempwendu = Convert.ToDouble(tempwendu.ToString("#0.0"));
		if (tempwendu > 900.0)
		{
			tempwendu = 0.0 - Math.Round(tempwendu - 1000.0, 1);
		}
		pinlv = Convert.ToDouble(m_rd_data[9] + m_rd_data[10] * 256);
		if (pinlv != 0.0 || tempwendu != 0.0 || Bdate != 0.0)
		{
			listadd = true;
			if (!Ready)
			{
				Ready = true;
			}
		}
	}

	private void buttonRefresh_Click(object sender, EventArgs e)
	{
		list.Clear();
		zedTIME.AxisChange();
		zedTIME.Refresh();
		zedTIME.SaveAs();
	}

	private void timerType_Tick(object sender, EventArgs e)
	{
		try
		{
			if (FlagEnquire == 2)
			{
				comboBoxSource.SelectedIndex = 2;
				FlagEnquire = 4;
				buttonSTART_Click(sender, e);
				timerType.Enabled = false;
			}
			else if (FlagEnquire == 3)
			{
				comboBoxSource.SelectedIndex = 1;
				FlagEnquire = 4;
				buttonSTART_Click(sender, e);
				timerType.Enabled = false;
			}
		}
		catch
		{
		}
	}

	private void comboBoxSpeed_EnabledChanged(object sender, EventArgs e)
	{
		int i = 0;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		list.Clear();
		zedTIME.AxisChange();
		zedTIME.Refresh();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		zedTIME.SaveAs();
	}

	private void splitContainer1_Panel1_SizeChanged(object sender, EventArgs e)
	{
	}

	private void splitContainer1_Panel1_Resize(object sender, EventArgs e)
	{
		zedTIME.Height = splitContainer1.SplitterDistance - 15;
		dataGridViewDATA.Height = splitContainer1.Height - splitContainer1.SplitterDistance - 15;
	}

	private void comboBoxCOM_Click(object sender, EventArgs e)
	{
		comboBoxCOM.Items.Clear();
		comboBoxCOM.Items.AddRange(SerialPort.GetPortNames());
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing && components != null)
		{
			components.Dispose();
		}
		base.Dispose(disposing);
	}

	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(datapick.Form1));
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.checkBox1 = new System.Windows.Forms.CheckBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.label9 = new System.Windows.Forms.Label();
		this.button2 = new System.Windows.Forms.Button();
		this.button1 = new System.Windows.Forms.Button();
		this.buttonEXCEL = new System.Windows.Forms.Button();
		this.buttonLISTCLEAR = new System.Windows.Forms.Button();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.label6 = new System.Windows.Forms.Label();
		this.comboBoxModel = new System.Windows.Forms.ComboBox();
		this.comboBoxDataType = new System.Windows.Forms.ComboBox();
		this.comboBoxfangshi = new System.Windows.Forms.ComboBox();
		this.label5 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.comboBoxBAUDE = new System.Windows.Forms.ComboBox();
		this.comboBoxCOM = new System.Windows.Forms.ComboBox();
		this.label2 = new System.Windows.Forms.Label();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.comboBoxT = new System.Windows.Forms.ComboBox();
		this.label8 = new System.Windows.Forms.Label();
		this.comboBoxSpeed = new System.Windows.Forms.ComboBox();
		this.label7 = new System.Windows.Forms.Label();
		this.radioButton2 = new System.Windows.Forms.RadioButton();
		this.radioButton1 = new System.Windows.Forms.RadioButton();
		this.comboBoxdanwei = new System.Windows.Forms.ComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.buttonZERO = new System.Windows.Forms.Button();
		this.buttonSTART = new System.Windows.Forms.Button();
		this.buttonSTOP = new System.Windows.Forms.Button();
		this.labelSource = new System.Windows.Forms.Label();
		this.comboBoxSource = new System.Windows.Forms.ComboBox();
		this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.labelwendu = new System.Windows.Forms.Label();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.labelpinlv = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.labelcichang = new System.Windows.Forms.Label();
		this.timerTIME = new System.Windows.Forms.Timer(this.components);
		this.dataGridViewDATA = new System.Windows.Forms.DataGridView();
		this.StatusStrip1 = new System.Windows.Forms.StatusStrip();
		this.ToolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
		this.zedTIME = new ZedGraph.ZedGraphControl();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		this.timerRecieve = new System.Windows.Forms.Timer(this.components);
		this.timerUSBread = new System.Windows.Forms.Timer(this.components);
		this.timerType = new System.Windows.Forms.Timer(this.components);
		this.splitContainer1 = new System.Windows.Forms.SplitContainer();
		this.groupBox1.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox5.SuspendLayout();
		this.groupBox4.SuspendLayout();
		this.groupBox2.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.dataGridViewDATA).BeginInit();
		this.StatusStrip1.SuspendLayout();
		this.splitContainer1.Panel1.SuspendLayout();
		this.splitContainer1.Panel2.SuspendLayout();
		this.splitContainer1.SuspendLayout();
		base.SuspendLayout();
		this.groupBox1.Controls.Add(this.checkBox1);
		this.groupBox1.Controls.Add(this.label11);
		this.groupBox1.Controls.Add(this.label10);
		this.groupBox1.Controls.Add(this.label9);
		this.groupBox1.Controls.Add(this.button2);
		this.groupBox1.Controls.Add(this.button1);
		this.groupBox1.Controls.Add(this.buttonEXCEL);
		this.groupBox1.Controls.Add(this.buttonLISTCLEAR);
		this.groupBox1.Controls.Add(this.groupBox6);
		this.groupBox1.Controls.Add(this.groupBox3);
		this.groupBox1.Location = new System.Drawing.Point(14, 17);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(194, 524);
		this.groupBox1.TabIndex = 0;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "设置";
		this.checkBox1.AutoSize = true;
		this.checkBox1.Location = new System.Drawing.Point(101, 495);
		this.checkBox1.Name = "checkBox1";
		this.checkBox1.Size = new System.Drawing.Size(60, 16);
		this.checkBox1.TabIndex = 24;
		this.checkBox1.Text = "绝对值";
		this.checkBox1.UseVisualStyleBackColor = true;
		this.label11.BackColor = System.Drawing.Color.Black;
		this.label11.Location = new System.Drawing.Point(95, 413);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(3, 80);
		this.label11.TabIndex = 23;
		this.label11.Text = "label11";
		this.label10.AutoSize = true;
		this.label10.Location = new System.Drawing.Point(124, 417);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(29, 12);
		this.label10.TabIndex = 22;
		this.label10.Text = "数据";
		this.label9.AutoSize = true;
		this.label9.Location = new System.Drawing.Point(40, 417);
		this.label9.Name = "label9";
		this.label9.Size = new System.Drawing.Size(29, 12);
		this.label9.TabIndex = 21;
		this.label9.Text = "图形";
		this.button2.Location = new System.Drawing.Point(18, 466);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(75, 23);
		this.button2.TabIndex = 20;
		this.button2.Text = "保存";
		this.button2.UseVisualStyleBackColor = true;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.button1.Location = new System.Drawing.Point(18, 437);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 19;
		this.button1.Text = "刷新";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.buttonEXCEL.Location = new System.Drawing.Point(101, 466);
		this.buttonEXCEL.Name = "buttonEXCEL";
		this.buttonEXCEL.Size = new System.Drawing.Size(75, 23);
		this.buttonEXCEL.TabIndex = 1;
		this.buttonEXCEL.Text = "导出";
		this.buttonEXCEL.UseVisualStyleBackColor = true;
		this.buttonEXCEL.Click += new System.EventHandler(buttonEXCEL_Click);
		this.buttonLISTCLEAR.Location = new System.Drawing.Point(101, 437);
		this.buttonLISTCLEAR.Name = "buttonLISTCLEAR";
		this.buttonLISTCLEAR.Size = new System.Drawing.Size(75, 23);
		this.buttonLISTCLEAR.TabIndex = 0;
		this.buttonLISTCLEAR.Text = "清空";
		this.buttonLISTCLEAR.UseVisualStyleBackColor = true;
		this.buttonLISTCLEAR.Click += new System.EventHandler(buttonLISTCLEAR_Click);
		this.groupBox6.Controls.Add(this.label6);
		this.groupBox6.Controls.Add(this.comboBoxModel);
		this.groupBox6.Controls.Add(this.comboBoxDataType);
		this.groupBox6.Controls.Add(this.comboBoxfangshi);
		this.groupBox6.Controls.Add(this.label5);
		this.groupBox6.Controls.Add(this.label4);
		this.groupBox6.Controls.Add(this.label1);
		this.groupBox6.Controls.Add(this.comboBoxBAUDE);
		this.groupBox6.Controls.Add(this.comboBoxCOM);
		this.groupBox6.Controls.Add(this.label2);
		this.groupBox6.Location = new System.Drawing.Point(18, 19);
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.Size = new System.Drawing.Size(158, 151);
		this.groupBox6.TabIndex = 18;
		this.groupBox6.TabStop = false;
		this.groupBox6.Text = "通讯设置";
		this.label6.AutoSize = true;
		this.label6.Location = new System.Drawing.Point(5, 25);
		this.label6.Name = "label6";
		this.label6.Size = new System.Drawing.Size(53, 12);
		this.label6.TabIndex = 10;
		this.label6.Text = "仪器型号";
		this.comboBoxModel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxModel.FormattingEnabled = true;
		this.comboBoxModel.Items.AddRange(new object[11]
		{
			"CH-1300", "CH-1500", "CH-1500B", "CH-1600", "CH-1800", "CH-260", "CH-290", "CH-260磁通手动", "CH-290磁通手动", "CH-260磁强手动",
			"CH-290磁强手动"
		});
		this.comboBoxModel.Location = new System.Drawing.Point(65, 20);
		this.comboBoxModel.Name = "comboBoxModel";
		this.comboBoxModel.Size = new System.Drawing.Size(82, 20);
		this.comboBoxModel.TabIndex = 11;
		this.comboBoxModel.SelectedIndexChanged += new System.EventHandler(comboBoxModel_SelectedIndexChanged);
		this.comboBoxDataType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxDataType.FormattingEnabled = true;
		this.comboBoxDataType.Items.AddRange(new object[3] { "普通数据", "高速数据", "历史数据" });
		this.comboBoxDataType.Location = new System.Drawing.Point(65, 122);
		this.comboBoxDataType.Name = "comboBoxDataType";
		this.comboBoxDataType.Size = new System.Drawing.Size(82, 20);
		this.comboBoxDataType.TabIndex = 9;
		this.comboBoxDataType.SelectedIndexChanged += new System.EventHandler(comboBoxDataType_SelectedIndexChanged);
		this.comboBoxfangshi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxfangshi.FormattingEnabled = true;
		this.comboBoxfangshi.Items.AddRange(new object[2] { "串口", "USB" });
		this.comboBoxfangshi.Location = new System.Drawing.Point(65, 47);
		this.comboBoxfangshi.Name = "comboBoxfangshi";
		this.comboBoxfangshi.Size = new System.Drawing.Size(82, 20);
		this.comboBoxfangshi.TabIndex = 7;
		this.comboBoxfangshi.SelectedIndexChanged += new System.EventHandler(comboBoxfangshi_SelectedIndexChanged);
		this.label5.AutoSize = true;
		this.label5.Location = new System.Drawing.Point(5, 125);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(53, 12);
		this.label5.TabIndex = 8;
		this.label5.Text = "数据类型";
		this.label4.AutoSize = true;
		this.label4.Location = new System.Drawing.Point(5, 50);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(53, 12);
		this.label4.TabIndex = 6;
		this.label4.Text = "通讯方式";
		this.label1.AutoSize = true;
		this.label1.Location = new System.Drawing.Point(5, 75);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(53, 12);
		this.label1.TabIndex = 0;
		this.label1.Text = "串口选择";
		this.comboBoxBAUDE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxBAUDE.FormattingEnabled = true;
		this.comboBoxBAUDE.Items.AddRange(new object[13]
		{
			"110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400",
			"56000", "57600", "115200"
		});
		this.comboBoxBAUDE.Location = new System.Drawing.Point(65, 97);
		this.comboBoxBAUDE.Name = "comboBoxBAUDE";
		this.comboBoxBAUDE.Size = new System.Drawing.Size(82, 20);
		this.comboBoxBAUDE.TabIndex = 3;
		this.comboBoxBAUDE.SelectedIndexChanged += new System.EventHandler(comboBoxBAUDE_SelectedIndexChanged);
		this.comboBoxCOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxCOM.FormattingEnabled = true;
		this.comboBoxCOM.Items.AddRange(new object[21]
		{
			"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9", "COM10",
			"COM11", "COM12", "COM13", "COM14", "COM15", "COM16", "COM17", "COM18", "COM19", "COM20",
			"COM21"
		});
		this.comboBoxCOM.Location = new System.Drawing.Point(65, 72);
		this.comboBoxCOM.Name = "comboBoxCOM";
		this.comboBoxCOM.Size = new System.Drawing.Size(82, 20);
		this.comboBoxCOM.TabIndex = 1;
		this.comboBoxCOM.SelectedIndexChanged += new System.EventHandler(comboBoxCOM_SelectedIndexChanged);
		this.comboBoxCOM.Click += new System.EventHandler(comboBoxCOM_Click);
		this.label2.AutoSize = true;
		this.label2.Location = new System.Drawing.Point(5, 100);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(41, 12);
		this.label2.TabIndex = 2;
		this.label2.Text = "波特率";
		this.groupBox3.Controls.Add(this.comboBoxT);
		this.groupBox3.Controls.Add(this.label8);
		this.groupBox3.Controls.Add(this.comboBoxSpeed);
		this.groupBox3.Controls.Add(this.label7);
		this.groupBox3.Controls.Add(this.radioButton2);
		this.groupBox3.Controls.Add(this.radioButton1);
		this.groupBox3.Controls.Add(this.comboBoxdanwei);
		this.groupBox3.Controls.Add(this.label3);
		this.groupBox3.Controls.Add(this.buttonZERO);
		this.groupBox3.Controls.Add(this.buttonSTART);
		this.groupBox3.Controls.Add(this.buttonSTOP);
		this.groupBox3.Location = new System.Drawing.Point(18, 183);
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.Size = new System.Drawing.Size(158, 215);
		this.groupBox3.TabIndex = 18;
		this.groupBox3.TabStop = false;
		this.groupBox3.Text = "命令";
		this.comboBoxT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxT.FormattingEnabled = true;
		this.comboBoxT.Items.AddRange(new object[15]
		{
			"默认", "1", "2", "3", "4", "5", "6", "7", "8", "9",
			"10", "15", "20", "25", "30"
		});
		this.comboBoxT.Location = new System.Drawing.Point(65, 51);
		this.comboBoxT.Name = "comboBoxT";
		this.comboBoxT.Size = new System.Drawing.Size(82, 20);
		this.comboBoxT.TabIndex = 15;
		this.comboBoxT.SelectedIndexChanged += new System.EventHandler(comboBoxT_SelectedIndexChanged);
		this.label8.AutoSize = true;
		this.label8.Location = new System.Drawing.Point(5, 48);
		this.label8.Name = "label8";
		this.label8.Size = new System.Drawing.Size(53, 24);
		this.label8.TabIndex = 14;
		this.label8.Text = "普通采集\r\n 周期(s)";
		this.comboBoxSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxSpeed.FormattingEnabled = true;
		this.comboBoxSpeed.Items.AddRange(new object[7] { "20组/s", "50组/s", "100组/s", "150组/s", "200组/s", "250组/s", "300组/s" });
		this.comboBoxSpeed.Location = new System.Drawing.Point(65, 80);
		this.comboBoxSpeed.Name = "comboBoxSpeed";
		this.comboBoxSpeed.Size = new System.Drawing.Size(82, 20);
		this.comboBoxSpeed.TabIndex = 13;
		this.comboBoxSpeed.SelectedIndexChanged += new System.EventHandler(comboBoxSpeed_SelectedIndexChanged);
		this.comboBoxSpeed.EnabledChanged += new System.EventHandler(comboBoxSpeed_EnabledChanged);
		this.label7.AutoSize = true;
		this.label7.Location = new System.Drawing.Point(5, 80);
		this.label7.Name = "label7";
		this.label7.Size = new System.Drawing.Size(53, 24);
		this.label7.TabIndex = 12;
		this.label7.Text = "高速采集\r\n\u3000速率";
		this.radioButton2.AutoSize = true;
		this.radioButton2.Location = new System.Drawing.Point(-1, 151);
		this.radioButton2.Name = "radioButton2";
		this.radioButton2.Size = new System.Drawing.Size(47, 16);
		this.radioButton2.TabIndex = 10;
		this.radioButton2.TabStop = true;
		this.radioButton2.Text = "图形";
		this.radioButton2.UseVisualStyleBackColor = true;
		this.radioButton2.Visible = false;
		this.radioButton2.CheckedChanged += new System.EventHandler(radioButton2_CheckedChanged);
		this.radioButton1.AutoSize = true;
		this.radioButton1.Location = new System.Drawing.Point(11, 125);
		this.radioButton1.Name = "radioButton1";
		this.radioButton1.Size = new System.Drawing.Size(47, 16);
		this.radioButton1.TabIndex = 9;
		this.radioButton1.TabStop = true;
		this.radioButton1.Text = "数据";
		this.radioButton1.UseVisualStyleBackColor = true;
		this.radioButton1.Visible = false;
		this.radioButton1.CheckedChanged += new System.EventHandler(radioButton1_CheckedChanged);
		this.comboBoxdanwei.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxdanwei.FormattingEnabled = true;
		this.comboBoxdanwei.Items.AddRange(new object[4] { "mT", "G", "A/m", "Oe" });
		this.comboBoxdanwei.Location = new System.Drawing.Point(65, 22);
		this.comboBoxdanwei.Name = "comboBoxdanwei";
		this.comboBoxdanwei.Size = new System.Drawing.Size(82, 20);
		this.comboBoxdanwei.TabIndex = 8;
		this.comboBoxdanwei.SelectedIndexChanged += new System.EventHandler(comboBoxdanwei_SelectedIndexChanged);
		this.label3.AutoSize = true;
		this.label3.Location = new System.Drawing.Point(5, 25);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(53, 12);
		this.label3.TabIndex = 7;
		this.label3.Text = "数据单位";
		this.buttonZERO.Location = new System.Drawing.Point(41, 182);
		this.buttonZERO.Name = "buttonZERO";
		this.buttonZERO.Size = new System.Drawing.Size(75, 23);
		this.buttonZERO.TabIndex = 6;
		this.buttonZERO.Text = "Zero";
		this.buttonZERO.UseVisualStyleBackColor = true;
		this.buttonZERO.Click += new System.EventHandler(buttonZERO_Click);
		this.buttonSTART.Location = new System.Drawing.Point(41, 119);
		this.buttonSTART.Name = "buttonSTART";
		this.buttonSTART.Size = new System.Drawing.Size(75, 23);
		this.buttonSTART.TabIndex = 4;
		this.buttonSTART.Text = "开始";
		this.buttonSTART.UseVisualStyleBackColor = true;
		this.buttonSTART.Click += new System.EventHandler(buttonSTART_Click);
		this.buttonSTOP.Location = new System.Drawing.Point(41, 151);
		this.buttonSTOP.Name = "buttonSTOP";
		this.buttonSTOP.Size = new System.Drawing.Size(75, 23);
		this.buttonSTOP.TabIndex = 5;
		this.buttonSTOP.Text = "停止";
		this.buttonSTOP.UseVisualStyleBackColor = true;
		this.buttonSTOP.Click += new System.EventHandler(buttonSTOP_Click);
		this.labelSource.AutoSize = true;
		this.labelSource.Location = new System.Drawing.Point(221, 106);
		this.labelSource.Name = "labelSource";
		this.labelSource.Size = new System.Drawing.Size(53, 12);
		this.labelSource.TabIndex = 4;
		this.labelSource.Text = "数据来源";
		this.labelSource.Visible = false;
		this.comboBoxSource.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
		this.comboBoxSource.FormattingEnabled = true;
		this.comboBoxSource.Items.AddRange(new object[3] { "磁通计", "高斯计", "高斯计(弱磁)" });
		this.comboBoxSource.Location = new System.Drawing.Point(280, 103);
		this.comboBoxSource.Name = "comboBoxSource";
		this.comboBoxSource.Size = new System.Drawing.Size(82, 20);
		this.comboBoxSource.TabIndex = 5;
		this.comboBoxSource.Visible = false;
		this.comboBoxSource.SelectedIndexChanged += new System.EventHandler(comboBoxSource_SelectedIndexChanged);
		this.serialPort1.ReadBufferSize = 25000;
		this.serialPort1.ReceivedBytesThreshold = 23;
		this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(serialPort1_DataReceived);
		this.groupBox5.Controls.Add(this.labelwendu);
		this.groupBox5.Font = new System.Drawing.Font("宋体", 13f);
		this.groupBox5.ForeColor = System.Drawing.Color.Red;
		this.groupBox5.Location = new System.Drawing.Point(599, 17);
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.Size = new System.Drawing.Size(165, 84);
		this.groupBox5.TabIndex = 17;
		this.groupBox5.TabStop = false;
		this.groupBox5.Text = "温度(℃)";
		this.labelwendu.BackColor = System.Drawing.Color.Blue;
		this.labelwendu.Font = new System.Drawing.Font("宋体", 19f);
		this.labelwendu.ForeColor = System.Drawing.Color.Yellow;
		this.labelwendu.Location = new System.Drawing.Point(8, 26);
		this.labelwendu.Name = "labelwendu";
		this.labelwendu.Size = new System.Drawing.Size(149, 47);
		this.labelwendu.TabIndex = 1;
		this.labelwendu.Tag = "6666";
		this.labelwendu.Text = "null";
		this.labelwendu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.groupBox4.Controls.Add(this.labelpinlv);
		this.groupBox4.Font = new System.Drawing.Font("宋体", 13f);
		this.groupBox4.ForeColor = System.Drawing.Color.Red;
		this.groupBox4.Location = new System.Drawing.Point(412, 17);
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.Size = new System.Drawing.Size(165, 84);
		this.groupBox4.TabIndex = 16;
		this.groupBox4.TabStop = false;
		this.groupBox4.Text = "频率(Hz)";
		this.labelpinlv.BackColor = System.Drawing.Color.Blue;
		this.labelpinlv.Font = new System.Drawing.Font("宋体", 19f);
		this.labelpinlv.ForeColor = System.Drawing.Color.Yellow;
		this.labelpinlv.Location = new System.Drawing.Point(8, 26);
		this.labelpinlv.Name = "labelpinlv";
		this.labelpinlv.Size = new System.Drawing.Size(149, 47);
		this.labelpinlv.TabIndex = 1;
		this.labelpinlv.Tag = "6666";
		this.labelpinlv.Text = "null";
		this.labelpinlv.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.groupBox2.Controls.Add(this.labelcichang);
		this.groupBox2.Font = new System.Drawing.Font("宋体", 13f);
		this.groupBox2.ForeColor = System.Drawing.Color.Red;
		this.groupBox2.Location = new System.Drawing.Point(223, 17);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(165, 84);
		this.groupBox2.TabIndex = 15;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "磁场值(mT)";
		this.labelcichang.BackColor = System.Drawing.Color.Blue;
		this.labelcichang.Font = new System.Drawing.Font("宋体", 19f);
		this.labelcichang.ForeColor = System.Drawing.Color.Yellow;
		this.labelcichang.Location = new System.Drawing.Point(8, 26);
		this.labelcichang.Name = "labelcichang";
		this.labelcichang.Size = new System.Drawing.Size(149, 47);
		this.labelcichang.TabIndex = 0;
		this.labelcichang.Tag = "6666";
		this.labelcichang.Text = "null";
		this.labelcichang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.timerTIME.Enabled = true;
		this.timerTIME.Tick += new System.EventHandler(timerTIME_Tick_1);
		this.dataGridViewDATA.AllowUserToAddRows = false;
		this.dataGridViewDATA.AllowUserToDeleteRows = false;
		this.dataGridViewDATA.Anchor = System.Windows.Forms.AnchorStyles.Top;
		this.dataGridViewDATA.BackgroundColor = System.Drawing.SystemColors.ScrollBar;
		this.dataGridViewDATA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.dataGridViewDATA.GridColor = System.Drawing.Color.Navy;
		this.dataGridViewDATA.Location = new System.Drawing.Point(1, 3);
		this.dataGridViewDATA.Name = "dataGridViewDATA";
		this.dataGridViewDATA.ReadOnly = true;
		this.dataGridViewDATA.RowTemplate.Height = 23;
		this.dataGridViewDATA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.dataGridViewDATA.Size = new System.Drawing.Size(541, 200);
		this.dataGridViewDATA.TabIndex = 18;
		this.StatusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[2] { this.ToolStripStatusLabel1, this.toolStripStatusLabel2 });
		this.StatusStrip1.Location = new System.Drawing.Point(0, 539);
		this.StatusStrip1.Name = "StatusStrip1";
		this.StatusStrip1.Size = new System.Drawing.Size(784, 22);
		this.StatusStrip1.TabIndex = 19;
		this.StatusStrip1.Text = "statusStrip1";
		this.ToolStripStatusLabel1.Name = "ToolStripStatusLabel1";
		this.ToolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
		this.ToolStripStatusLabel1.Text = "状态栏";
		this.ToolStripStatusLabel1.Visible = false;
		this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
		this.toolStripStatusLabel2.Size = new System.Drawing.Size(128, 17);
		this.toolStripStatusLabel2.Text = "北京翠海科贸有限公司";
		this.zedTIME.Location = new System.Drawing.Point(3, 4);
		this.zedTIME.Name = "zedTIME";
		this.zedTIME.ScrollGrace = 0.0;
		this.zedTIME.ScrollMaxX = 0.0;
		this.zedTIME.ScrollMaxY = 0.0;
		this.zedTIME.ScrollMaxY2 = 0.0;
		this.zedTIME.ScrollMinX = 0.0;
		this.zedTIME.ScrollMinY = 0.0;
		this.zedTIME.ScrollMinY2 = 0.0;
		this.zedTIME.Size = new System.Drawing.Size(541, 203);
		this.zedTIME.TabIndex = 20;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.timerRecieve.Interval = 200;
		this.timerRecieve.Tick += new System.EventHandler(timerRecieve_Tick);
		this.timerUSBread.Interval = 200;
		this.timerUSBread.Tick += new System.EventHandler(timerUSBread_Tick);
		this.timerType.Tick += new System.EventHandler(timerType_Tick);
		this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.splitContainer1.Location = new System.Drawing.Point(223, 106);
		this.splitContainer1.Name = "splitContainer1";
		this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
		this.splitContainer1.Panel1.Controls.Add(this.zedTIME);
		this.splitContainer1.Panel1.SizeChanged += new System.EventHandler(splitContainer1_Panel1_SizeChanged);
		this.splitContainer1.Panel1.Resize += new System.EventHandler(splitContainer1_Panel1_Resize);
		this.splitContainer1.Panel2.Controls.Add(this.dataGridViewDATA);
		this.splitContainer1.Size = new System.Drawing.Size(549, 428);
		this.splitContainer1.SplitterDistance = 214;
		this.splitContainer1.TabIndex = 21;
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.SystemColors.Control;
		base.ClientSize = new System.Drawing.Size(784, 561);
		base.Controls.Add(this.splitContainer1);
		base.Controls.Add(this.StatusStrip1);
		base.Controls.Add(this.groupBox5);
		base.Controls.Add(this.groupBox4);
		base.Controls.Add(this.groupBox2);
		base.Controls.Add(this.groupBox1);
		base.Controls.Add(this.labelSource);
		base.Controls.Add(this.comboBoxSource);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		this.MaximumSize = new System.Drawing.Size(800, 600);
		this.MinimumSize = new System.Drawing.Size(800, 600);
		base.Name = "Form1";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "CH-Hall数据采集软件";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
		base.Load += new System.EventHandler(Form1_Load);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.groupBox5.ResumeLayout(false);
		this.groupBox4.ResumeLayout(false);
		this.groupBox2.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.dataGridViewDATA).EndInit();
		this.StatusStrip1.ResumeLayout(false);
		this.StatusStrip1.PerformLayout();
		this.splitContainer1.Panel1.ResumeLayout(false);
		this.splitContainer1.Panel2.ResumeLayout(false);
		this.splitContainer1.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
