using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using DMSkin;
using DMSkin.Controls;
using DMSkin.Metro;
using DMSkin.Metro.Controls;
using Microsoft.Office.Interop.Excel;
using ZedGraph;

namespace DataReader2;

public class Form1 : DMSkinForm
{
	private PointPairList listR1 = new PointPairList();

	private LineItem CurveR1;

	private PointPairList listR2 = new PointPairList();

	private LineItem CurveR2;

	private PointPairList listR3 = new PointPairList();

	private LineItem CurveR3;

	private PointPairList listR4 = new PointPairList();

	private LineItem CurveR4;

	private PointPairList listH1 = new PointPairList();

	private LineItem CurveH1;

	private PointPairList listH2 = new PointPairList();

	private LineItem CurveH2;

	private PointPairList listH3 = new PointPairList();

	private LineItem CurveH3;

	private PointPairList listH4 = new PointPairList();

	private LineItem CurveH4;

	private int GraphScaleMax = 300;

	private SerialPort_Connect serial_connecter = new SerialPort_Connect();

	public bool flag_IconShow = true;

	private bool PipeMode = false;

	private bool PipeAlwaysReading = false;

	private int PipeDataCount = 0;

	private NamedPipe.NamedPipeServer pipeS;

	private bool ShowDataPanel = false;

	private bool ShowDataGride = false;

	private bool Calculating = false;

	private bool ScrollToTheLatest = false;

	private List<double> CalListX = new List<double>();

	private List<double> CalListY = new List<double>();

	private List<double> CalListZ = new List<double>();

	private string FilePath = null;

	private long SaveDataCount_Serial = 0L;

	private int[] ProgressBarvalue = new int[4];

	private List<double>[] ReadData = new List<double>[3];

	private bool ShowHistoryData = false;

	private long HistoryDataCount = 0L;

	private bool DebugMode = false;

	private bool SaveData_Serial = false;

	private object[] gaussmeter_fluxgate_sata_list = new object[6];

	private object[] fluxmeter_sata_list = new object[4];

	private bool clear_ram = false;

	private int model_num = 1;

	private bool Show_Normal = false;

	public bool SendOut = false;

	public bool SendOutWith = false;

	private bool Judge = false;

	private bool Judge_ABS = false;

	private bool judgeopen = false;

	private double judgeup = 1.0;

	private double judgedown = -1.0;

	private bool SaveToFile = false;

	private bool STFRM_STOP = true;

	private long STFDataMaximum = 100L;

	private string STFFilePath = "";

	private StreamWriter STFsw;

	private int STFFileSerial = 2;

	private long STFDataCount = 0L;

	private bool DataDebug = false;

	private int CurveWidth = 1;

	private int GuassUnit = 0;

	private bool NeedRestart = false;

	private bool TextBoxDataDebugSendTextHex = false;

	private bool TextBoxDataDebugScreenTextHex = false;

	private bool clear_after_export = false;

	private bool SaveDataTime = false;

	private int SaveDataTimeInterval = 0;

	private int dgvDelIndex;

	private bool b_language_cn = true;

	public bool b_lampEnable = false;

	public byte[] c_GreenForLamp = new byte[8] { 1, 5, 0, 1, 255, 0, 221, 250 };

	public byte[] c_RedForLamp = new byte[8] { 1, 5, 0, 16, 255, 0, 141, 255 };

	public byte[] c_NoneForLamp = new byte[8] { 1, 5, 0, 4, 0, 0, 140, 11 };

	public byte[] c_BeepOnForLamp = new byte[8] { 1, 5, 0, 161, 255, 0, 221, 216 };

	public byte[] c_BeepOffForLamp = new byte[8] { 1, 5, 0, 161, 0, 0, 156, 40 };

	private IContainer components = null;

	private DMTabControl dmTabControl1;

	private PictureBox pictureBox1;

	private TabPage tabPage3;

	private System.Windows.Forms.Label label1;

	private System.Windows.Forms.Label label2;

	private System.Windows.Forms.Timer timer_ui;

	private SaveFileDialog saveFileDialog;

	private OpenFileDialog openFileDialog;

	private TabPage tabPage7;

	private MetroGrid DataGride_readtime_serial;

	private System.Windows.Forms.Button button_showdatagride_serial;

	private System.Windows.Forms.Button button_hidedatagride_serial;

	private ZedGraphControl zedGraphControl_realtime_serial;

	private Panel panel_datapanel_serial;

	private System.Windows.Forms.GroupBox groupX;

	private System.Windows.Forms.Label Xn;

	private System.Windows.Forms.Label Xf;

	private System.Windows.Forms.Label Xr;

	private System.Windows.Forms.Label Xt;

	private System.Windows.Forms.Label label37;

	private MetroCheckBox CheckBox_savedata_serial;

	private DMButton Button_export_serial;

	private DMButton Button_start_stop_serial;

	private MetroComboBox ComboBox_select_data;

	private System.Windows.Forms.GroupBox groupB;

	private System.Windows.Forms.Label Bn;

	private System.Windows.Forms.Label Br;

	private System.Windows.Forms.GroupBox groupZ;

	private System.Windows.Forms.Label Zn;

	private System.Windows.Forms.Label Zf;

	private System.Windows.Forms.Label Zr;

	private System.Windows.Forms.Label Zt;

	private System.Windows.Forms.GroupBox groupY;

	private System.Windows.Forms.Label Yn;

	private System.Windows.Forms.Label Yf;

	private System.Windows.Forms.Label Yr;

	private System.Windows.Forms.Label Yt;

	private DataSet dataSet1;

	private System.Data.DataTable dt;

	private DataColumn dataColumn1;

	private DataColumn dataColumn2;

	private DataColumn dataColumn3;

	private DataColumn dataColumn4;

	private System.Windows.Forms.Label label3;

	private MetroComboBox ComboBox_serial_port_choice;

	private DMButton Button_save_once;

	private System.Windows.Forms.Label label4;

	private MetroComboBox ComboBox_select_model;

	private DMButton Button_clear;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

	private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;

	private System.Windows.Forms.CheckBox checkBox_show_normal;

	private System.Windows.Forms.CheckBox checkBox_always_reading;

	private System.Windows.Forms.CheckBox checkBox_clear_ram;

	private NumericUpDown numeric_refresh_time;

	private System.Windows.Forms.CheckBox checkBox_show_last_row;

	private DMButton Button_refresh_graph;

	private System.Windows.Forms.GroupBox groupBox1;

	private System.Windows.Forms.Label label5;

	private System.Windows.Forms.GroupBox groupBox2;

	private System.Windows.Forms.GroupBox groupBox3;

	private System.Windows.Forms.GroupBox groupBox4;

	private System.Windows.Forms.CheckBox checkBox_send_out_with;

	private System.Windows.Forms.CheckBox checkBox_send_out;

	private System.Windows.Forms.GroupBox groupBox_judge;

	private System.Windows.Forms.Label label_judge;

	private System.Windows.Forms.Label label7;

	private System.Windows.Forms.GroupBox groupBox5;

	private System.Windows.Forms.CheckBox checkBox_judge;

	private System.Windows.Forms.Label label6;

	private System.Windows.Forms.Label label11;

	private System.Windows.Forms.Label label10;

	private NumericUpDown numeric_judge_down;

	private NumericUpDown numeric_judge_up;

	private System.Windows.Forms.Label label9;

	private MetroComboBox ComboBox_judge_type;

	private System.Windows.Forms.Label label_file_path;

	private System.Windows.Forms.GroupBox groupBox6;

	private System.Windows.Forms.Label label8;

	private System.Windows.Forms.CheckBox checkBox_save_to_file;

	private System.Windows.Forms.GroupBox groupBox7;

	private DMButton dmButton1;

	private MetroComboBox ComboBox_STFReachMaximum;

	private System.Windows.Forms.Label label14;

	private NumericUpDown numeric_STFDataMaximum;

	private System.Windows.Forms.Label label13;

	private System.Windows.Forms.GroupBox groupBox8;

	private DMButton Button_open_file;

	private SaveFileDialog saveFileDialog1;

	private System.Windows.Forms.GroupBox groupBox9;

	private System.Windows.Forms.CheckBox checkBox_data_debug;

	private System.Windows.Forms.TextBox textBox_data_debug_screen;

	private DMButton Button_data_debug_send;

	private System.Windows.Forms.TextBox textBox_data_debug_send;

	private ContextMenuStrip contextMenuStrip1;

	private ToolStripMenuItem dATAToolStripMenuItem;

	private ToolStripMenuItem dATACToolStripMenuItem;

	private ToolStripMenuItem fAST20ToolStripMenuItem;

	private ToolStripMenuItem fAST50ToolStripMenuItem;

	private ToolStripMenuItem fAST100ToolStripMenuItem;

	private ToolStripMenuItem fAST200ToolStripMenuItem;

	private ToolStripMenuItem fAST300ToolStripMenuItem;

	private ToolStripMenuItem zEROToolStripMenuItem;

	private ToolStripMenuItem clearScreenToolStripMenuItem;

	private ToolStripMenuItem clearInputToolStripMenuItem;

	private ToolStripMenuItem mODLEToolStripMenuItem;

	private ToolStripMenuItem clearAllToolStripMenuItem;

	private System.Windows.Forms.Label label12;

	private NumericUpDown numericUp_graph_scale;

	private System.Windows.Forms.GroupBox groupBox10;

	private System.Windows.Forms.Label label23;

	private System.Windows.Forms.Label label_ch4_color;

	private System.Windows.Forms.Label label21;

	private System.Windows.Forms.Label label_ch3_color;

	private System.Windows.Forms.Label label19;

	private System.Windows.Forms.Label label_ch2_color;

	private System.Windows.Forms.Label label18;

	private System.Windows.Forms.Label label_ch1_color;

	private System.Windows.Forms.Label label15;

	private DMButton dmButton2;

	private ColorDialog colorDialog1;

	private System.Windows.Forms.Label label16;

	private System.Windows.Forms.Label label20;

	private System.Windows.Forms.Label label_curve_length;

	private TrackBar trackBar_curve_length;

	private MetroComboBox ComboBox_unit;

	private System.Windows.Forms.GroupBox groupBox11;

	private System.Windows.Forms.Label label17;

	private System.Windows.Forms.GroupBox groupBox12;

	private System.Windows.Forms.Label label22;

	private DMButton Button_save_pipe_name;

	private DMButton dmButton3;

	private System.Windows.Forms.TextBox textBox_pipe_name;

	private System.Windows.Forms.GroupBox groupBox13;

	private System.Windows.Forms.TextBox textBox_pipe_last_rec;

	private System.Windows.Forms.Label label28;

	private System.Windows.Forms.GroupBox groupBox14;

	private System.Windows.Forms.Label label26;

	private System.Windows.Forms.Label label27;

	private System.Windows.Forms.Label label25;

	private System.Windows.Forms.Label label24;

	private System.Windows.Forms.Timer timer_display_pipe_notice;

	private System.Windows.Forms.Timer timerGuaid;

	private DMButton dmButton4;

	private System.Windows.Forms.Timer timerSTF;

	private ToolStripMenuItem dEBUGONToolStripMenuItem;

	private ToolStripMenuItem dEBUGOFFToolStripMenuItem;

	private ContextMenuStrip contextMenuStrip2;

	private ToolStripMenuItem HexASCII转换ToolStripMenuItem;

	private ContextMenuStrip contextMenuStrip3;

	private ToolStripMenuItem hexadecimalASCIIToolStripMenuItem;

	private DMButton dmButton5;

	private System.Windows.Forms.CheckBox checkBox_clear_after_export;

	private System.Windows.Forms.GroupBox groupBox_SaveDataTime;

	private NumericUpDown numericUp_SaveDataTime;

	private System.Windows.Forms.CheckBox checkBox_SaveDataTime;

	private System.Windows.Forms.Label label29;

	private System.Windows.Forms.Timer timer_SaveData;

	private DMButton btnDelete;

	private DMButton btn_single;

	private System.Windows.Forms.CheckBox cbx_ABS;

	private MetroComboBox cbx_comAlarmLamp;

	private System.Windows.Forms.GroupBox gpb_lamp;

	private SerialPort sp_lamp;

	public Form1()
	{
		InitializeComponent();
	}

	private void zed_init(ZedGraphControl control)
	{
		control.GraphPane.Fill = new Fill(Color.FromArgb(0, 84, 143));
		control.GraphPane.Chart.Fill.Type = FillType.None;
		control.GraphPane.Title.Text = " ";
		control.GraphPane.Title.FontSpec.FontColor = Color.White;
		control.GraphPane.Border.Color = Color.FromArgb(0, 84, 143);
		control.GraphPane.Border.Width = 1f;
		control.GraphPane.Chart.Border.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.Title.Text = "Data Number";
		control.GraphPane.XAxis.Type = AxisType.Ordinal;
		control.GraphPane.XAxis.Scale.Max = GraphScaleMax;
		control.GraphPane.XAxis.MajorTic.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.MinorTic.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.Title.FontSpec.FontColor = Color.SandyBrown;
		control.GraphPane.XAxis.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.MajorGrid.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.FromArgb(255, 255, 255);
		control.GraphPane.YAxis.Title.Text = "Data";
		control.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.FromArgb(255, 255, 255);
		control.GraphPane.YAxis.MajorTic.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.YAxis.MinorTic.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.YAxis.Title.FontSpec.FontColor = Color.SandyBrown;
		control.GraphPane.YAxis.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.MajorGrid.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.YAxis.MajorGrid.IsZeroLine = true;
		CurveR1 = control.GraphPane.AddCurve("CH 1", listR1, label_ch1_color.BackColor, SymbolType.None);
		CurveR1.Line.Width = 1f;
		CurveR2 = control.GraphPane.AddCurve("CH 2", listR2, label_ch2_color.BackColor, SymbolType.None);
		CurveR2.Line.Width = 1f;
		CurveR3 = control.GraphPane.AddCurve("CH 3", listR3, label_ch3_color.BackColor, SymbolType.None);
		CurveR3.Line.Width = 1f;
	}

	public void UIinit()
	{
		label_ch1_color.BackColor = ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH1Color", "#FFC0C0"));
		label_ch2_color.BackColor = ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH2Color", "#C0FFC0"));
		label_ch3_color.BackColor = ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH3Color", "#C0C0FF"));
		label_ch4_color.BackColor = ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH4Color", "#FFC080"));
		DataGride_readtime_serial.AllowUserToAddRows = false;
		flag_IconShow = bool.Parse(SystemConfig.GetConfigData("ICON_VISABLE", "False"));
		if (!flag_IconShow)
		{
			pictureBox1.Visible = false;
			label2.Visible = false;
		}
	}

	public void logicinit()
	{
		serial_connecter.DataReady += SerialPort_DataReady;
		ReadData[0] = new List<double>();
		ReadData[1] = new List<double>();
		ReadData[2] = new List<double>();
		gaussmeter_fluxgate_sata_list[0] = "常速";
		gaussmeter_fluxgate_sata_list[1] = "20次/秒";
		gaussmeter_fluxgate_sata_list[2] = "50次/秒";
		gaussmeter_fluxgate_sata_list[3] = "100次/秒";
		gaussmeter_fluxgate_sata_list[4] = "200次/秒";
		gaussmeter_fluxgate_sata_list[5] = "200+次/秒";
		fluxmeter_sata_list[0] = "磁通量";
		fluxmeter_sata_list[1] = "磁通量手动";
		fluxmeter_sata_list[2] = "磁感应强度";
		fluxmeter_sata_list[3] = "磁感应强度手动";
		ComboBox_select_model.SelectedItem = SystemConfig.GetConfigData("TYPE", "一维高斯计");
		try
		{
			numeric_refresh_time.Value = Convert.ToDecimal(SystemConfig.GetConfigData("RefreshTime", "0.1"));
			timer_ui.Interval = (int)(numeric_refresh_time.Value * 1000m);
		}
		catch
		{
			numeric_refresh_time.Value = 0.1m;
			timer_ui.Interval = 100;
		}
		if (SystemConfig.GetConfigData("ShowNormal", "false") == "true")
		{
			checkBox_show_normal.Checked = true;
		}
		else
		{
			checkBox_show_normal.Checked = false;
		}
		if (SystemConfig.GetConfigData("AlwaysReading", "false") == "true")
		{
			checkBox_always_reading.Checked = true;
		}
		else
		{
			checkBox_always_reading.Checked = false;
		}
		if (SystemConfig.GetConfigData("ClearRam", "false") == "true")
		{
			checkBox_clear_ram.Checked = true;
		}
		else
		{
			checkBox_clear_ram.Checked = false;
		}
		if (SystemConfig.GetConfigData("ShowLastRow", "false") == "true")
		{
			checkBox_show_last_row.Checked = true;
		}
		else
		{
			checkBox_show_last_row.Checked = false;
		}
		if (SystemConfig.GetConfigData("SendOut", "false") == "true")
		{
			checkBox_send_out.Checked = true;
		}
		else
		{
			checkBox_send_out.Checked = false;
		}
		if (SystemConfig.GetConfigData("SendOutWith", "false") == "true")
		{
			checkBox_send_out_with.Checked = true;
		}
		else
		{
			checkBox_send_out_with.Checked = false;
		}
		if (SystemConfig.GetConfigData("Judge", "false") == "true")
		{
			checkBox_judge.Checked = false;
			checkBox_judge.Checked = true;
			if (SystemConfig.GetConfigData("Judge_ABS", "false") == "true")
			{
				cbx_ABS.Checked = false;
				cbx_ABS.Checked = true;
			}
		}
		else
		{
			checkBox_judge.Checked = true;
			checkBox_judge.Checked = false;
		}
		if (SystemConfig.GetConfigData("JudgeOpen", "false") == "true")
		{
			ComboBox_judge_type.SelectedItem = "开区间";
		}
		else
		{
			ComboBox_judge_type.SelectedItem = "闭区间";
		}
		numeric_judge_up.Value = Convert.ToDecimal(SystemConfig.GetConfigData("JudgeUp", "1"));
		numeric_judge_down.Value = Convert.ToDecimal(SystemConfig.GetConfigData("JudgeDown", "-1"));
		if (SystemConfig.GetConfigData("SaveToFile", "false") == "true")
		{
			checkBox_save_to_file.Checked = false;
			checkBox_save_to_file.Checked = true;
		}
		else
		{
			checkBox_save_to_file.Checked = true;
			checkBox_save_to_file.Checked = false;
		}
		if (SystemConfig.GetConfigData("STFReachMaximum", "STOP") == "ATNF")
		{
			ComboBox_STFReachMaximum.SelectedItem = "自动新建";
		}
		else
		{
			ComboBox_STFReachMaximum.SelectedItem = "停止保存";
		}
		numeric_STFDataMaximum.Value = Convert.ToDecimal(SystemConfig.GetConfigData("STFDataMaximum", "100000"));
		numericUp_graph_scale.Value = Convert.ToDecimal(SystemConfig.GetConfigData("GraphScale", "200"));
		trackBar_curve_length.Value = Convert.ToInt32(SystemConfig.GetConfigData("CurveWidth", "1"));
		ComboBox_unit.SelectedIndex = Convert.ToInt32(SystemConfig.GetConfigData("GuassUnit", "0"));
		if (SystemConfig.GetConfigData("QG", "true") == "true")
		{
			timerGuaid.Enabled = true;
		}
		if (SystemConfig.GetConfigData("PIPE", "false") == "true")
		{
			PipeMode = true;
		}
		if (SystemConfig.GetConfigData("CAE", "false") == "true")
		{
			clear_after_export = true;
		}
		else
		{
			clear_after_export = false;
		}
		if (SystemConfig.GetConfigData("SaveDataByTime", "true") == "true")
		{
			checkBox_SaveDataTime.Checked = true;
		}
		else
		{
			checkBox_SaveDataTime.Checked = false;
		}
		numericUp_SaveDataTime.Value = Convert.ToDecimal(SystemConfig.GetConfigData("SaveDataTime", "0.1"));
		if (PipeMode)
		{
			timer_ui.Enabled = false;
			pipeS = new NamedPipe.NamedPipeServer(SystemConfig.GetConfigData("PipeName", "SerialDataReader"));
			pipeS.MsgCallBack += PipeMessageRecive;
			pipeS.StatusCallBack += PipeStatusChange;
			pipeS.Start();
			checkBox_data_debug.Checked = true;
			groupBox12.Visible = true;
			timer_display_pipe_notice.Enabled = true;
		}
		b_lampEnable = bool.Parse(SystemConfig.GetConfigData("b_lampEnable", "false"));
		if (!b_lampEnable)
		{
			return;
		}
		gpb_lamp.Visible = true;
		string COMPORTNAME_L = "";
		string COMBAUDRATE_L = "";
		COMPORTNAME_L = SystemConfig.GetConfigData("COMMSET_LAMP", "COM4");
		COMBAUDRATE_L = SystemConfig.GetConfigData("BADURATE_LAMP", "9600");
		int combaudrate_L = Convert.ToInt32(COMBAUDRATE_L);
		sp_lamp.PortName = COMPORTNAME_L;
		sp_lamp.BaudRate = combaudrate_L;
		try
		{
			sp_lamp.Open();
			lamp_alarmRight();
			cbx_comAlarmLamp.Items.Clear();
			ComboBox.ObjectCollection items = cbx_comAlarmLamp.Items;
			object[] portNames = SerialPort.GetPortNames();
			items.AddRange(portNames);
			for (int i = 0; i < cbx_comAlarmLamp.Items.Count; i++)
			{
				if (COMPORTNAME_L == cbx_comAlarmLamp.Items[i].ToString())
				{
					cbx_comAlarmLamp.SelectedIndex = i;
					break;
				}
			}
		}
		catch (Exception ex)
		{
			MessageSender.Send("Can not open " + ex.ToString());
		}
	}

	public void lamp_alarmError()
	{
		try
		{
			if (sp_lamp.IsOpen)
			{
				sp_lamp.Write(c_RedForLamp, 0, c_RedForLamp.Length);
				Thread.Sleep(100);
				sp_lamp.Write(c_BeepOnForLamp, 0, c_BeepOnForLamp.Length);
			}
		}
		catch (Exception)
		{
		}
	}

	public void lamp_alarmRight()
	{
		try
		{
			if (sp_lamp.IsOpen)
			{
				sp_lamp.Write(c_GreenForLamp, 0, c_GreenForLamp.Length);
				Thread.Sleep(100);
				sp_lamp.Write(c_BeepOffForLamp, 0, c_BeepOffForLamp.Length);
			}
		}
		catch (Exception)
		{
		}
	}

	public void lamp_alarmClose()
	{
		try
		{
			if (sp_lamp.IsOpen)
			{
				sp_lamp.Write(c_NoneForLamp, 0, c_NoneForLamp.Length);
				Thread.Sleep(100);
				sp_lamp.Write(c_BeepOffForLamp, 0, c_BeepOffForLamp.Length);
			}
		}
		catch (Exception)
		{
		}
	}

	private void PipeMessageRecive(string Msg, int Length)
	{
		Invoke((MethodInvoker)delegate
		{
			if (!string.IsNullOrEmpty(Msg))
			{
				textBox_data_debug_screen.AppendText(Msg + "\n");
				textBox_pipe_last_rec.Text = Msg;
			}
			string[] array = Msg.Split('\t');
			if (array.Length == 1 || array.Length == 4 || array.Length == 9)
			{
				switch (array[0])
				{
				case "GD":
				{
					PipeDataCount = Convert.ToInt32(array[1]);
					if (PipeDataCount == 0)
					{
						PipeDataCount = -1;
					}
					else
					{
						PipeAlwaysReading = false;
					}
					if (ComboBox_select_model.SelectedIndex != 3)
					{
						ComboBox_select_data.SelectedIndex = Convert.ToInt32(array[2]);
					}
					if (array[3] == "0")
					{
						CheckBox_savedata_serial.Checked = false;
					}
					else
					{
						CheckBox_savedata_serial.Checked = true;
					}
					switch (ComboBox_select_data.SelectedIndex)
					{
					case 0:
						serial_connecter.Write("DATA?>");
						break;
					case 1:
						serial_connecter.Write("DATA?>");
						serial_connecter.Write("FAST020>");
						break;
					case 2:
						serial_connecter.Write("DATA?>");
						serial_connecter.Write("FAST050>");
						break;
					case 3:
						serial_connecter.Write("DATA?>");
						serial_connecter.Write("FAST100>");
						break;
					case 4:
						serial_connecter.Write("DATA?>");
						serial_connecter.Write("FAST200>");
						break;
					case 5:
						serial_connecter.Write("DATA?>");
						serial_connecter.Write("FAST300>");
						break;
					}
					if (PipeDataCount == 0)
					{
						label26.Text = "无限制\n";
					}
					else
					{
						label26.Text = PipeDataCount + "\n";
					}
					System.Windows.Forms.Label label4 = label26;
					label4.Text = label4.Text + ComboBox_select_data.SelectedItem.ToString() + "\n";
					if (CheckBox_savedata_serial.Checked)
					{
						label26.Text += "是";
					}
					else
					{
						label26.Text += "否";
					}
					break;
				}
				case "SG":
					serial_connecter.Write("DATAC>");
					if (checkBox_always_reading.Checked)
					{
						PipeAlwaysReading = true;
					}
					break;
				case "ST":
				{
					serial_connecter.SetPortName("COM" + array[1]);
					ComboBox_select_model.SelectedIndex = Convert.ToInt32(array[2]);
					if (ComboBox_select_model.SelectedIndex == 3)
					{
						ComboBox_select_data.SelectedIndex = Convert.ToInt32(array[3]);
					}
					ComboBox_unit.SelectedIndex = Convert.ToInt32(array[4]);
					if (array[5] == "0")
					{
						checkBox_save_to_file.Checked = false;
					}
					else
					{
						checkBox_save_to_file.Checked = true;
						numeric_STFDataMaximum.Value = Convert.ToInt32(array[6]);
						ComboBox_STFReachMaximum.SelectedIndex = Convert.ToInt32(array[7]);
					}
					if (array[8] == "1")
					{
						checkBox_always_reading.Checked = true;
						PipeAlwaysReading = true;
					}
					else
					{
						checkBox_always_reading.Checked = false;
						PipeAlwaysReading = false;
					}
					label25.Text = "COM" + array[1] + "\n" + ComboBox_select_model.SelectedItem.ToString() + "\n";
					if (ComboBox_select_model.SelectedIndex != 3)
					{
						label25.Text += "-\n";
					}
					else
					{
						System.Windows.Forms.Label label = label25;
						label.Text = label.Text + ComboBox_select_data.SelectedItem.ToString() + "\n";
					}
					System.Windows.Forms.Label label2 = label25;
					label2.Text = label2.Text + ComboBox_unit.SelectedItem.ToString() + "\n";
					if (checkBox_save_to_file.Checked)
					{
						System.Windows.Forms.Label label3 = label25;
						label3.Text = label3.Text + "文件\n" + numeric_STFDataMaximum.Value + "\n" + ComboBox_STFReachMaximum.SelectedItem.ToString() + "\n";
					}
					else
					{
						label25.Text += "内存\n-\n-\n";
					}
					if (checkBox_always_reading.Checked)
					{
						label25.Text += "是";
					}
					else
					{
						label25.Text += "否";
					}
					break;
				}
				}
			}
		});
	}

	private void PipeStatusChange(string Statuus)
	{
		Invoke((MethodInvoker)delegate
		{
			textBox_data_debug_screen.AppendText(Statuus + "\n");
		});
	}

	private void Form1_Load(object sender, EventArgs e)
	{
		UIinit();
		logicinit();
		zed_init(zedGraphControl_realtime_serial);
	}

	private double CalculateRMS(List<double> pData)
	{
		double ASum = 0.0;
		for (int i = 0; i < pData.Count; i++)
		{
			ASum += pData[i];
		}
		ASum /= (double)pData.Count;
		double fSum = 0.0;
		for (int j = 0; j < pData.Count; j++)
		{
			fSum += (pData[j] - ASum) * (pData[j] - ASum);
		}
		return Math.Sqrt(fSum / (double)pData.Count);
	}

	private void DisplayValue()
	{
	}

	private void timer_ui_Tick(object sender, EventArgs e)
	{
		timer_ui.Enabled = false;
		if (ShowDataPanel)
		{
			try
			{
				DisplayValue();
			}
			catch
			{
				Calculating = false;
			}
		}
		if (listR1.Count > 0)
		{
			Xr.Text = listR1[listR1.Count - 1].Y.ToString();
		}
		if (listR2.Count > 0)
		{
			Yr.Text = listR2[listR2.Count - 1].Y.ToString();
		}
		if (listR3.Count > 0)
		{
			Zr.Text = listR3[listR3.Count - 1].Y.ToString();
		}
		if (Show_Normal && listR4.Count > 0)
		{
			Br.Text = listR4[listR4.Count - 1].Y.ToString();
		}
		try
		{
			zedGraphControl_realtime_serial.AxisChange();
			zedGraphControl_realtime_serial.Refresh();
		}
		catch
		{
		}
		if (ScrollToTheLatest && DataGride_readtime_serial.Rows.Count > 0)
		{
			DataGride_readtime_serial.FirstDisplayedScrollingRowIndex = DataGride_readtime_serial.Rows[DataGride_readtime_serial.Rows.Count - 1].Index;
		}
		if (FilePath != null)
		{
		}
		int a = ReadData[0].Count;
		timer_ui.Enabled = true;
	}

	private void button_hidedatagride_serial_Click(object sender, EventArgs e)
	{
		button_showdatagride_serial.Visible = true;
		zedGraphControl_realtime_serial.Height += 220;
		Button_refresh_graph.Top += 200;
		button_hidedatagride_serial.Visible = false;
		DataGride_readtime_serial.Visible = false;
		Button_clear.Visible = false;
		btnDelete.Visible = false;
		Button_save_once.Visible = false;
		Button_export_serial.Visible = false;
		CheckBox_savedata_serial.Visible = false;
	}

	private void button_showdatagride_serial_Click(object sender, EventArgs e)
	{
		button_showdatagride_serial.Visible = false;
		zedGraphControl_realtime_serial.Height -= 220;
		Button_refresh_graph.Top -= 200;
		button_hidedatagride_serial.Visible = true;
		DataGride_readtime_serial.Visible = true;
		Button_clear.Visible = true;
		btnDelete.Visible = true;
		Button_save_once.Visible = true;
		Button_export_serial.Visible = true;
		CheckBox_savedata_serial.Visible = true;
	}

	public void F_SaveToFile(double a, double b, double c)
	{
		if (!string.IsNullOrEmpty(STFFilePath))
		{
			if (STFDataCount < STFDataMaximum)
			{
				STFsw.Write(a + "\t" + b + "\t" + c + "\t" + DateTime.Now.ToString() + "\n");
				STFDataCount++;
			}
			else if (STFRM_STOP)
			{
				CheckBox_savedata_serial.Checked = false;
				Button_open_file_Click(Button_open_file, EventArgs.Empty);
			}
			else
			{
				STFsw.Flush();
				STFsw.Close();
				STFsw = new StreamWriter(STFFilePath + "_" + STFFileSerial);
				STFDataCount = 0L;
				STFFileSerial++;
				STFsw.Write(a + "\t" + b + "\t" + c + "\t" + DateTime.Now.ToString() + "\n");
			}
		}
	}

	private void GoPipe(double data1, double data2, double data3, int datacount)
	{
		string str = data1.ToString();
		switch (datacount)
		{
		case 2:
			str = str + "\t" + data2 + "\n";
			break;
		case 3:
			str = str + "\t" + data2 + "\t" + data3 + "\n";
			break;
		}
		if (PipeDataCount == -1)
		{
			pipeS.Send(str);
			return;
		}
		if (PipeDataCount > 0)
		{
			pipeS.Send(str);
			PipeDataCount--;
			return;
		}
		serial_connecter.Write("DATAC>");
		if (checkBox_always_reading.Checked)
		{
			PipeAlwaysReading = true;
		}
	}

	public void OD_analyse(string str, int length)
	{
		if (length > 40)
		{
			return;
		}
		string[] dg = str.Substring(1, length - 2).Split('/');
		if (dg[0].Contains("#"))
		{
			return;
		}
		double tt = 0.0;
		double temp = 0.0;
		double frq = 0.0;
		if (dg[0] == "HSTDC:" || dg[0] == "HSTACL:" || dg[0] == "HSTACH:" || dg[0] == "HSEDC:" || dg[0] == "HSEACL:" || dg[0] == "HSEACH:")
		{
			tt = Convert.ToDouble(dg[1]);
			switch (GuassUnit)
			{
			default:
				return;
			case 0:
				tt /= 10.0;
				break;
			case 3:
				tt *= 79.577;
				break;
			case 4:
				tt *= 1000.0;
				break;
			case 1:
			case 2:
				break;
			}
			temp = Convert.ToDouble(dg[3]);
			frq = Convert.ToDouble(dg[2]);
		}
		else if (dg[0] == "UHSDC:" || dg[0] == "UHSACL:" || dg[0] == "UHSACH:")
		{
			tt = Convert.ToDouble(dg[1]);
			switch (GuassUnit)
			{
			default:
				return;
			case 0:
				tt /= 10000.0;
				break;
			case 1:
				tt /= 1000.0;
				break;
			case 2:
				tt /= 1000.0;
				break;
			case 3:
				tt /= 1000.0;
				tt *= 79.577;
				break;
			case 4:
				break;
			}
			temp = Convert.ToDouble(dg[3]);
			frq = Convert.ToDouble(dg[2]);
		}
		else
		{
			try
			{
				tt = Convert.ToDouble(dg[0]);
				if (GuassUnit != 0)
				{
					switch (GuassUnit)
					{
					default:
						return;
					case 1:
					case 2:
						tt *= 10.0;
						break;
					case 3:
						tt *= 795.77;
						break;
					case 4:
						tt *= 10000.0;
						break;
					}
				}
				temp = Convert.ToDouble(dg[2]) / 10.0;
				frq = Convert.ToDouble(dg[1]);
			}
			catch
			{
				return;
			}
		}
		listR1.Add(listR1.Count + 1, tt);
		while (listR1.Count > GraphScaleMax)
		{
			listR1.RemoveAt(0);
		}
		if (dg.Length > 1)
		{
			if (PipeMode)
			{
				GoPipe(tt, temp, frq, 3);
				if (SaveData_Serial && !SaveDataTime)
				{
					if (SaveToFile)
					{
						F_SaveToFile(tt, temp, frq);
					}
					SaveDataCount_Serial++;
					DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, temp, frq, DateTime.Now.ToString());
				}
				return;
			}
			Invoke((MethodInvoker)delegate
			{
				Xt.Text = temp + "℃";
				Xf.Text = frq + "Hz";
				if (SaveData_Serial && !SaveDataTime)
				{
					if (SaveToFile)
					{
						F_SaveToFile(tt, temp, frq);
					}
					SaveDataCount_Serial++;
					DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, temp, frq, DateTime.Now.ToString());
				}
				if (Judge)
				{
					double num = tt;
					if (Judge_ABS)
					{
						num = Math.Abs(num);
					}
					if (judgeopen)
					{
						if (num > judgedown && num < judgeup)
						{
							label_judge.BackColor = Color.Red;
							label_judge.Text = "NG";
							lamp_alarmError();
						}
						else
						{
							label_judge.BackColor = Color.Green;
							label_judge.Text = "OK";
							lamp_alarmRight();
						}
					}
					else if (num > judgedown && num < judgeup)
					{
						label_judge.BackColor = Color.Green;
						label_judge.Text = "OK";
						lamp_alarmRight();
					}
					else
					{
						label_judge.BackColor = Color.Red;
						label_judge.Text = "NG";
						lamp_alarmError();
					}
				}
				if (SendOut)
				{
					SendKeys.Send(tt.ToString());
					if (SendOutWith)
					{
						SendKeys.Send("{ENTER}");
					}
				}
			});
			return;
		}
		if (SaveData_Serial && !SaveDataTime)
		{
			if (SaveToFile)
			{
				F_SaveToFile(tt, 0.0, 0.0);
			}
			SaveDataCount_Serial++;
			Invoke((MethodInvoker)delegate
			{
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, 0, 0, DateTime.Now.ToString());
			});
		}
		Invoke((MethodInvoker)delegate
		{
			if (Judge)
			{
				double num = tt;
				if (Judge_ABS)
				{
					num = Math.Abs(num);
				}
				if (judgeopen)
				{
					if (num > judgedown && num < judgeup)
					{
						label_judge.BackColor = Color.Red;
						label_judge.Text = "NG";
						lamp_alarmError();
					}
					else
					{
						label_judge.BackColor = Color.Green;
						label_judge.Text = "OK";
						lamp_alarmRight();
					}
				}
				else if (num > judgedown && num < judgeup)
				{
					label_judge.BackColor = Color.Green;
					label_judge.Text = "OK";
					lamp_alarmRight();
				}
				else
				{
					label_judge.BackColor = Color.Red;
					label_judge.Text = "NG";
					lamp_alarmError();
				}
			}
		});
		if (PipeMode)
		{
			GoPipe(tt, 0.0, 0.0, 1);
		}
	}

	public void TD_analyse(string str, int length)
	{
		if (length < 40)
		{
			string[] dg = str.Substring(1, length - 2).Split('/');
			double tt1 = 0.0;
			double tt2 = 0.0;
			try
			{
				tt1 = Convert.ToDouble(dg[0]);
				tt2 = Convert.ToDouble(dg[2]);
				if (GuassUnit != 0)
				{
					switch (GuassUnit)
					{
					default:
						return;
					case 1:
					case 2:
						tt1 *= 10.0;
						tt2 *= 10.0;
						break;
					case 3:
						tt1 *= 795.77;
						tt2 *= 795.77;
						break;
					}
				}
			}
			catch
			{
				return;
			}
			if (PipeMode)
			{
				GoPipe(tt1, tt2, 0.0, 2);
				if (SaveData_Serial && !SaveDataTime)
				{
					if (SaveToFile)
					{
						F_SaveToFile(tt1, tt2, 0.0);
					}
					SaveDataCount_Serial++;
					Invoke((MethodInvoker)delegate
					{
						DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt1, tt2, "-", DateTime.Now.ToString());
					});
				}
				return;
			}
			if (Show_Normal)
			{
				double B = Math.Sqrt(tt1 * tt1 + tt2 * tt2);
				listR4.Add(listR4.Count + 1, B);
				while (listR4.Count > GraphScaleMax)
				{
					listR4.RemoveAt(0);
				}
			}
			listR1.Add(listR1.Count + 1, tt1);
			listR2.Add(listR2.Count + 1, tt2);
			while (listR1.Count > GraphScaleMax)
			{
				listR1.RemoveAt(0);
			}
			while (listR2.Count > GraphScaleMax)
			{
				listR2.RemoveAt(0);
			}
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt1, tt2, 0.0);
				}
				SaveDataCount_Serial++;
				Invoke((MethodInvoker)delegate
				{
					DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt1, tt2, "-", DateTime.Now.ToString());
				});
			}
			return;
		}
		string[] dg2 = str.Substring(1, length - 2).Split(';');
		double tt3 = 0.0;
		double tt4 = 0.0;
		try
		{
			tt3 = Convert.ToDouble(dg2[0].Split('/')[0]);
			tt4 = Convert.ToDouble(dg2[2].Split('/')[0]);
			if (GuassUnit != 0)
			{
				switch (GuassUnit)
				{
				default:
					return;
				case 1:
				case 2:
					tt3 *= 10.0;
					tt4 *= 10.0;
					break;
				case 3:
					tt3 *= 795.77;
					tt4 *= 795.77;
					break;
				}
			}
		}
		catch
		{
			return;
		}
		if (PipeMode)
		{
			GoPipe(tt3, tt4, 0.0, 2);
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt3, tt4, 0.0);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt3, tt4, "-", DateTime.Now.ToString());
			}
			return;
		}
		if (Show_Normal)
		{
			double B2 = Math.Sqrt(tt3 * tt3 + tt4 * tt4);
			listR4.Add(listR4.Count + 1, B2);
			while (listR4.Count > GraphScaleMax)
			{
				listR4.RemoveAt(0);
			}
		}
		listR1.Add(listR1.Count + 1, tt3);
		listR2.Add(listR2.Count + 1, tt4);
		while (listR1.Count > GraphScaleMax)
		{
			listR1.RemoveAt(0);
		}
		while (listR2.Count > GraphScaleMax)
		{
			listR2.RemoveAt(0);
		}
		Invoke((MethodInvoker)delegate
		{
			Xt.Text = Convert.ToDouble(dg2[0].Split('/')[2]) / 10.0 + "℃";
			Yt.Text = Convert.ToDouble(dg2[2].Split('/')[2]) / 10.0 + "℃";
			Xf.Text = Convert.ToDouble(dg2[0].Split('/')[1]) + "Hz";
			Yf.Text = Convert.ToDouble(dg2[2].Split('/')[1]) + "Hz";
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt3, tt4, 0.0);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt3, tt4, "-", DateTime.Now.ToString());
			}
			if (Judge)
			{
				double num = tt3;
				if (Judge_ABS)
				{
					num = Math.Abs(num);
				}
				if (judgeopen)
				{
					if (num > judgedown && num < judgeup)
					{
						label_judge.BackColor = Color.Red;
						label_judge.Text = "NG";
						lamp_alarmError();
					}
					else
					{
						label_judge.BackColor = Color.Green;
						label_judge.Text = "OK";
						lamp_alarmRight();
					}
				}
				else if (num > judgedown && num < judgeup)
				{
					label_judge.BackColor = Color.Green;
					label_judge.Text = "OK";
					lamp_alarmRight();
				}
				else
				{
					label_judge.BackColor = Color.Red;
					label_judge.Text = "NG";
					lamp_alarmError();
				}
			}
			if (SendOut)
			{
				SendKeys.Send(tt3 + "\t" + tt4);
				if (SendOutWith)
				{
					SendKeys.Send("{ENTER}");
				}
			}
		});
	}

	public void TTD_analyse(string str, int length)
	{
		if (length < 60)
		{
			string[] dg = str.Substring(1, length - 2).Split('/');
			double tt1 = 0.0;
			double tt2 = 0.0;
			double tt3 = 0.0;
			try
			{
				tt1 = Convert.ToDouble(dg[0]);
				tt2 = Convert.ToDouble(dg[1]);
				tt3 = Convert.ToDouble(dg[2]);
				if (GuassUnit != 0)
				{
					switch (GuassUnit)
					{
					default:
						return;
					case 1:
					case 2:
						tt1 *= 10.0;
						tt2 *= 10.0;
						tt3 *= 10.0;
						break;
					case 3:
						tt1 *= 795.77;
						tt2 *= 795.77;
						tt3 *= 795.77;
						break;
					}
				}
			}
			catch
			{
				return;
			}
			if (PipeMode)
			{
				GoPipe(tt1, tt2, tt3, 3);
				if (SaveData_Serial && !SaveDataTime)
				{
					if (SaveToFile)
					{
						F_SaveToFile(tt1, tt2, tt3);
					}
					SaveDataCount_Serial++;
					Invoke((MethodInvoker)delegate
					{
						DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt1, tt2, tt3, DateTime.Now.ToString());
					});
				}
				return;
			}
			listR1.Add(listR1.Count + 1, tt1);
			listR2.Add(listR2.Count + 1, tt2);
			listR3.Add(listR3.Count + 1, tt3);
			if (Show_Normal)
			{
				double B = Math.Sqrt(tt1 * tt1 + tt2 * tt2 + tt3 * tt3);
				listR4.Add(listR4.Count + 1, B);
				while (listR4.Count > GraphScaleMax)
				{
					listR4.RemoveAt(0);
				}
			}
			while (listR1.Count > GraphScaleMax)
			{
				listR1.RemoveAt(0);
			}
			while (listR2.Count > GraphScaleMax)
			{
				listR2.RemoveAt(0);
			}
			while (listR3.Count > GraphScaleMax)
			{
				listR3.RemoveAt(0);
			}
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt1, tt2, tt3);
				}
				SaveDataCount_Serial++;
				Invoke((MethodInvoker)delegate
				{
					DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt1, tt2, tt3, DateTime.Now.ToString());
				});
			}
			return;
		}
		string[] dg2 = str.Substring(1, length - 2).Split(';');
		double tt4 = 0.0;
		double tt5 = 0.0;
		double tt6 = 0.0;
		try
		{
			tt4 = Convert.ToDouble(dg2[0].Split('/')[0]);
			tt5 = Convert.ToDouble(dg2[1].Split('/')[0]);
			tt6 = Convert.ToDouble(dg2[2].Split('/')[0]);
			if (GuassUnit != 0)
			{
				switch (GuassUnit)
				{
				default:
					return;
				case 1:
				case 2:
					tt4 *= 10.0;
					tt5 *= 10.0;
					tt6 *= 10.0;
					break;
				case 3:
					tt4 *= 795.77;
					tt5 *= 795.77;
					tt6 *= 795.77;
					break;
				}
			}
		}
		catch
		{
			return;
		}
		if (PipeMode)
		{
			GoPipe(tt4, tt5, tt6, 3);
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt4, tt5, tt6);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt4, tt5, tt6, DateTime.Now.ToString());
			}
			return;
		}
		if (Show_Normal)
		{
			double B2 = Math.Sqrt(tt4 * tt4 + tt5 * tt5 + tt6 * tt6);
			listR4.Add(listR4.Count + 1, B2);
			while (listR4.Count > GraphScaleMax)
			{
				listR4.RemoveAt(0);
			}
		}
		listR1.Add(listR1.Count + 1, tt4);
		listR2.Add(listR2.Count + 1, tt5);
		listR3.Add(listR3.Count + 1, tt6);
		while (listR1.Count > GraphScaleMax)
		{
			listR1.RemoveAt(0);
		}
		while (listR2.Count > GraphScaleMax)
		{
			listR2.RemoveAt(0);
		}
		while (listR3.Count > GraphScaleMax)
		{
			listR3.RemoveAt(0);
		}
		BeginInvoke((MethodInvoker)delegate
		{
			Xt.Text = Convert.ToDouble(dg2[0].Split('/')[2]) / 10.0 + "℃";
			Yt.Text = Convert.ToDouble(dg2[1].Split('/')[2]) / 10.0 + "℃";
			Zt.Text = Convert.ToDouble(dg2[2].Split('/')[2]) / 10.0 + "℃";
			Xf.Text = Convert.ToDouble(dg2[0].Split('/')[1]) + "Hz";
			Yf.Text = Convert.ToDouble(dg2[1].Split('/')[1]) + "Hz";
			Zf.Text = Convert.ToDouble(dg2[2].Split('/')[1]) + "Hz";
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt4, tt5, tt6);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt4, tt5, tt6, DateTime.Now.ToString());
			}
			if (Judge)
			{
				double num = tt4;
				if (Judge_ABS)
				{
					num = Math.Abs(num);
				}
				if (judgeopen)
				{
					if (num > judgedown && num < judgeup)
					{
						label_judge.BackColor = Color.Red;
						label_judge.Text = "NG";
						lamp_alarmError();
					}
					else
					{
						label_judge.BackColor = Color.Green;
						label_judge.Text = "OK";
						lamp_alarmRight();
					}
				}
				else if (num > judgedown && num < judgeup)
				{
					label_judge.BackColor = Color.Green;
					label_judge.Text = "OK";
					lamp_alarmRight();
				}
				else
				{
					label_judge.BackColor = Color.Red;
					label_judge.Text = "NG";
					lamp_alarmError();
				}
			}
			if (SendOut)
			{
				SendKeys.Send(tt4 + "\t" + tt5 + "\t" + tt6);
				if (SendOutWith)
				{
					SendKeys.Send("{ENTER}");
				}
			}
		});
	}

	public void F_analyse(string str, int length)
	{
		while (str.StartsWith("\0"))
		{
			str.TrimStart(default(char));
		}
		string[] dg = str.Substring(2, length - 3).Split('/');
		double tt;
		try
		{
			tt = Convert.ToDouble(dg[0]);
		}
		catch
		{
			return;
		}
		listR1.Add(listR1.Count + 1, tt);
		while (listR1.Count > GraphScaleMax)
		{
			listR1.RemoveAt(0);
		}
		double temp = Convert.ToDouble(dg[2]) / 10.0;
		double frq = Convert.ToDouble(dg[1]);
		Invoke((MethodInvoker)delegate
		{
			Xt.Text = temp + "℃";
			Xf.Text = frq + "Hz";
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt, temp, frq);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, temp, frq, DateTime.Now.ToString());
			}
			if (Judge)
			{
				double num = tt;
				if (Judge_ABS)
				{
					num = Math.Abs(num);
				}
				if (judgeopen)
				{
					if (num > judgedown && num < judgeup)
					{
						label_judge.BackColor = Color.Red;
						label_judge.Text = "NG";
						lamp_alarmError();
					}
					else
					{
						label_judge.BackColor = Color.Green;
						label_judge.Text = "OK";
						lamp_alarmRight();
					}
				}
				else if (num > judgedown && num < judgeup)
				{
					label_judge.BackColor = Color.Green;
					label_judge.Text = "OK";
					lamp_alarmRight();
				}
				else
				{
					label_judge.BackColor = Color.Red;
					label_judge.Text = "NG";
					lamp_alarmError();
				}
			}
			if (SendOut)
			{
				SendKeys.Send(tt.ToString());
				if (SendOutWith)
				{
					SendKeys.Send("{ENTER}");
				}
			}
		});
	}

	public void FG_analyse(string str, int length)
	{
		string[] dg = str.Substring(1, length - 2).Split('/');
		double tt;
		try
		{
			tt = Convert.ToDouble(dg[0]);
		}
		catch
		{
			return;
		}
		listR1.Add(listR1.Count + 1, tt);
		while (listR1.Count > GraphScaleMax)
		{
			listR1.RemoveAt(0);
		}
		if (dg.Length > 1)
		{
			double temp = Convert.ToDouble(dg[2]) / 10.0;
			double frq = Convert.ToDouble(dg[1]);
			Invoke((MethodInvoker)delegate
			{
				Xt.Text = temp + "℃";
				Xf.Text = frq + "Hz";
				if (PipeMode)
				{
					GoPipe(tt, temp, frq, 3);
					if (SaveData_Serial && !SaveDataTime)
					{
						if (SaveToFile)
						{
							F_SaveToFile(tt, temp, frq);
						}
						SaveDataCount_Serial++;
						DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, temp, frq, DateTime.Now.ToString());
					}
				}
				else
				{
					if (SaveData_Serial && !SaveDataTime)
					{
						if (SaveToFile)
						{
							F_SaveToFile(tt, temp, frq);
						}
						SaveDataCount_Serial++;
						DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, temp, frq, DateTime.Now.ToString());
					}
					if (Judge)
					{
						double num = tt;
						if (Judge_ABS)
						{
							num = Math.Abs(num);
						}
						if (judgeopen)
						{
							if (num > judgedown && num < judgeup)
							{
								label_judge.BackColor = Color.Red;
								label_judge.Text = "NG";
								lamp_alarmError();
							}
							else
							{
								label_judge.BackColor = Color.Green;
								label_judge.Text = "OK";
								lamp_alarmRight();
							}
						}
						else if (num > judgedown && num < judgeup)
						{
							label_judge.BackColor = Color.Green;
							label_judge.Text = "OK";
							lamp_alarmRight();
						}
						else
						{
							label_judge.BackColor = Color.Red;
							label_judge.Text = "NG";
							lamp_alarmError();
						}
					}
					if (SendOut)
					{
						SendKeys.Send(tt.ToString());
						if (SendOutWith)
						{
							SendKeys.Send("{ENTER}");
						}
					}
				}
			});
		}
		else if (PipeMode)
		{
			GoPipe(tt, 0.0, 0.0, 1);
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tt, 0.0, 0.0);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, 0, 0, DateTime.Now.ToString());
			}
		}
		else if (SaveData_Serial && !SaveDataTime)
		{
			if (SaveToFile)
			{
				F_SaveToFile(tt, 0.0, 0.0);
			}
			SaveDataCount_Serial++;
			Invoke((MethodInvoker)delegate
			{
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tt, 0, 0, DateTime.Now.ToString());
			});
		}
	}

	public void TFG_analyse(string str, int length)
	{
		string[] dg = str.Substring(1, length - 2).Split('/');
		double tx;
		double ty;
		double tz;
		try
		{
			tx = Convert.ToDouble(dg[0]);
			ty = Convert.ToDouble(dg[1]);
			tz = Convert.ToDouble(dg[2]);
		}
		catch
		{
			return;
		}
		if (PipeMode)
		{
			GoPipe(tx, ty, tz, 3);
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tx, ty, tz);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tx, ty, tz, DateTime.Now.ToString());
			}
			return;
		}
		if (Show_Normal)
		{
			double B = Math.Sqrt(tx * tx + ty * ty + tz * tz);
			listR4.Add(listR4.Count + 1, B);
			while (listR4.Count > GraphScaleMax)
			{
				listR4.RemoveAt(0);
			}
		}
		listR1.Add(listR1.Count + 1, tx);
		listR2.Add(listR2.Count + 1, ty);
		listR3.Add(listR3.Count + 1, tz);
		while (listR1.Count > GraphScaleMax)
		{
			listR1.RemoveAt(0);
			listR2.RemoveAt(0);
			listR3.RemoveAt(0);
		}
		Invoke((MethodInvoker)delegate
		{
			Xt.Text = "---";
			Xf.Text = "---";
			Yt.Text = "---";
			Yf.Text = "---";
			Zt.Text = "---";
			Zf.Text = "---";
			if (SaveData_Serial && !SaveDataTime)
			{
				if (SaveToFile)
				{
					F_SaveToFile(tx, ty, tz);
				}
				SaveDataCount_Serial++;
				DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, tx, ty, tz, DateTime.Now.ToString());
			}
			if (Judge)
			{
				double num = tx;
				if (Judge_ABS)
				{
					num = Math.Abs(num);
				}
				if (judgeopen)
				{
					if (num > judgedown && num < judgeup)
					{
						label_judge.BackColor = Color.Red;
						label_judge.Text = "NG";
						lamp_alarmError();
					}
					else
					{
						label_judge.BackColor = Color.Green;
						label_judge.Text = "OK";
						lamp_alarmRight();
					}
				}
				else if (num > judgedown && num < judgeup)
				{
					label_judge.BackColor = Color.Green;
					label_judge.Text = "OK";
					lamp_alarmRight();
				}
				else
				{
					label_judge.BackColor = Color.Red;
					label_judge.Text = "NG";
					lamp_alarmError();
				}
			}
			if (ComboBox_select_data.SelectedItem.ToString().StartsWith("常速") && SendOut)
			{
				SendKeys.Send(tx + "\t" + ty + "\t" + tz);
				if (SendOutWith)
				{
					SendKeys.Send("{ENTER}");
				}
			}
		});
	}

	public void SerialPort_DataReady(string str, int length)
	{
		if (DebugMode)
		{
			Invoke((MethodInvoker)delegate
			{
				if (TextBoxDataDebugScreenTextHex)
				{
					char[] array = str.ToCharArray();
					char[] array2 = array;
					foreach (char value in array2)
					{
						int num = Convert.ToInt32(value);
						string text = $"{num:X}";
						if (text.Length == 1)
						{
							textBox_data_debug_screen.AppendText("0" + text + " ");
						}
						else
						{
							textBox_data_debug_screen.AppendText(text + " ");
						}
					}
				}
				else
				{
					str = str.Replace("\n", Environment.NewLine);
					textBox_data_debug_screen.AppendText(str);
				}
			});
			return;
		}
		if (DataDebug)
		{
			Invoke((MethodInvoker)delegate
			{
				textBox_data_debug_screen.AppendText(str + "\n");
			});
		}
		if (PipeMode && PipeAlwaysReading)
		{
			PipeDataCount = -1;
		}
		if (length >= 9)
		{
			switch (model_num)
			{
			case 1:
				OD_analyse(str, length);
				break;
			case 2:
				TD_analyse(str, length);
				break;
			case 3:
				TTD_analyse(str, length);
				break;
			case 4:
				F_analyse(str, length);
				break;
			case 5:
				FG_analyse(str, length);
				break;
			case 6:
				TFG_analyse(str, length);
				break;
			}
		}
	}

	private void Button_start_stop_serial_Click(object sender, EventArgs e)
	{
		if (Button_start_stop_serial.Text == "Start" || Button_start_stop_serial.Text == "开始")
		{
			switch (ComboBox_select_data.SelectedIndex)
			{
			case 0:
				serial_connecter.Write("DATA?>");
				break;
			case 1:
				serial_connecter.Write("DATA?>");
				if ("一维高斯计" == ComboBox_select_model.SelectedItem.ToString())
				{
					serial_connecter.Write("FAST2>");
				}
				else
				{
					serial_connecter.Write("FAST020>");
				}
				break;
			case 2:
				serial_connecter.Write("DATA?>");
				serial_connecter.Write("FAST050>");
				break;
			case 3:
				serial_connecter.Write("DATA?>");
				serial_connecter.Write("FAST100>");
				break;
			case 4:
				serial_connecter.Write("DATA?>");
				serial_connecter.Write("FAST200>");
				break;
			case 5:
				serial_connecter.Write("DATA?>");
				serial_connecter.Write("FAST300>");
				break;
			}
			Button_start_stop_serial.Text = "停止";
		}
		else if (Button_start_stop_serial.Text == "Stop" || Button_start_stop_serial.Text == "停止")
		{
			serial_connecter.Write("DATAC>");
			Button_start_stop_serial.Text = "开始";
		}
	}

	private void CheckBox_savedata_serial_CheckedChanged(object sender, EventArgs e)
	{
		SaveData_Serial = CheckBox_savedata_serial.Checked;
		if (SaveDataTime)
		{
			timer_SaveData.Enabled = SaveData_Serial;
		}
		if (SaveToFile && SaveData_Serial && string.IsNullOrEmpty(STFFilePath))
		{
			SaveData_Serial = false;
			timer_SaveData.Enabled = false;
			if (MessageBox.Show("在‘保存至文件’选定下需新建文件才可保存数据,是否新建?", "无法启用保存数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
			{
				Button_open_file_Click(sender, e);
				if (!string.IsNullOrEmpty(STFFilePath))
				{
					SaveData_Serial = true;
					if (SaveDataTime)
					{
						timer_SaveData.Enabled = true;
					}
				}
			}
			else
			{
				CheckBox_savedata_serial.Checked = false;
			}
		}
		else if (SaveToFile && !string.IsNullOrEmpty(STFFilePath))
		{
			STFsw.Flush();
		}
	}

	private bool PrintGridView(DataGridView gvList)
	{
		if (gvList.Rows.Count != 0)
		{
			ProgressBar pb3 = new ProgressBar();
			pb3.Value = 0;
			pb3.Step = 1;
			pb3.Maximum = gvList.Rows.Count;
			base.Controls.Add(pb3);
			pb3.BringToFront();
			pb3.Visible = true;
			pb3.Tag = 9988;
			pb3.BringToFront();
			pb3.Width = 280;
			pb3.Height = 30;
			System.Drawing.Point pnt = new System.Drawing.Point((base.Width - pb3.Width) / 2, (base.Height - pb3.Height) / 2);
			pb3.Location = pnt;
			Microsoft.Office.Interop.Excel.Application excel = new ApplicationClass();
			int rowsCount = gvList.Rows.Count;
			int colsCount = gvList.Columns.Count;
			excel.Workbooks.Add(Missing.Value);
			Worksheet sheet = (Worksheet)excel.ActiveSheet;
			int columnCount = gvList.Columns.Count;
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
				for (int j = 0; j < colsCount; j++)
				{
					if (gvList.Columns[j].Visible)
					{
						if (gvList.Rows[rowIndex].Cells[j].ValueType == typeof(string))
						{
							excel.Cells[rowIndex + 2, j + 1] = "'" + gvList.Rows[rowIndex].Cells[j].Value.ToString();
						}
						else
						{
							excel.Cells[rowIndex + 2, j + 1] = gvList.Rows[rowIndex].Cells[j].Value.ToString();
						}
						pb3.PerformStep();
					}
				}
			}
			excel.Visible = true;
			pb3.PerformStep();
			pb3.Dispose();
			return true;
		}
		MessageBox.Show("当前表格中无数据！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
		return false;
	}

	private bool exportdata(DataGridView datacontorl)
	{
		SaveFileDialog saveFileDialog = new SaveFileDialog();
		saveFileDialog.Filter = "CSV文件(*.CSV)|*.CSV";
		saveFileDialog.FilterIndex = 0;
		saveFileDialog.RestoreDirectory = true;
		saveFileDialog.CreatePrompt = true;
		saveFileDialog.Title = "数据视图导出CSV文件";
		if (saveFileDialog.ShowDialog() == DialogResult.OK)
		{
			Stream myStream = saveFileDialog.OpenFile();
			StreamWriter sw = new StreamWriter(myStream, Encoding.GetEncoding("Unicode"));
			string str = "";
			DateTime start = DateTime.Now;
			try
			{
				for (int i = 0; i < datacontorl.ColumnCount; i++)
				{
					if (i > 0)
					{
						str += "\t";
					}
					str += datacontorl.Columns[i].HeaderText;
				}
				sw.WriteLine(str);
				for (int j = 0; j < datacontorl.Rows.Count; j++)
				{
					string tempStr = "";
					for (int k = 0; k < datacontorl.Columns.Count; k++)
					{
						if (k > 0)
						{
							tempStr += "\t";
						}
						tempStr = ((datacontorl.Rows[j].Cells[k].Value != null) ? (tempStr + datacontorl.Rows[j].Cells[k].Value.ToString()) : (tempStr + string.Empty));
					}
					sw.WriteLine(tempStr);
				}
				sw.Close();
				myStream.Close();
			}
			catch (Exception ex)
			{
				MessageSender.Send(ex.Message);
			}
			finally
			{
				sw.Close();
				myStream.Close();
			}
			return true;
		}
		return false;
	}

	private void Button_export_serial_Click(object sender, EventArgs e)
	{
		if (DataGride_readtime_serial.Rows.Count != 0 && exportdata(DataGride_readtime_serial) && clear_after_export)
		{
			DataGride_readtime_serial.Rows.Clear();
			SaveDataCount_Serial = 0L;
			GC.Collect();
		}
	}

	private void ComboBox_serial_port_choice_Click(object sender, EventArgs e)
	{
		if (Button_start_stop_serial.Text == "停止")
		{
			Button_start_stop_serial_Click(sender, e);
		}
		ComboBox_serial_port_choice.Items.Clear();
		ComboBox.ObjectCollection items = ComboBox_serial_port_choice.Items;
		object[] portNames = SerialPort.GetPortNames();
		items.AddRange(portNames);
	}

	private void ComboBox_serial_port_choice_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (!serial_connecter.SetPortName(ComboBox_serial_port_choice.SelectedItem.ToString()))
		{
			MessageSender.Send("Can not open " + ComboBox_serial_port_choice.SelectedItem.ToString());
		}
	}

	private void ComboBox_select_data_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (ComboBox_select_model.SelectedItem.ToString().EndsWith("磁通计"))
		{
			if (ComboBox_select_data.SelectedItem.ToString().StartsWith("磁通量"))
			{
				Xn.Text = "读数(mWb)";
				model_num = 4;
			}
			else
			{
				switch (GuassUnit)
				{
				default:
					return;
				case 0:
					Xn.Text = "读数(mT)";
					Yn.Text = "读数(mT)";
					Zn.Text = "读数(mT)";
					Bn.Text = "读数(mT)";
					break;
				case 1:
					Xn.Text = "读数(G)";
					Yn.Text = "读数(G)";
					Zn.Text = "读数(G)";
					Bn.Text = "读数(G)";
					break;
				case 2:
					Xn.Text = "读数(Oe)";
					Yn.Text = "读数(Oe)";
					Zn.Text = "读数(Oe)";
					Bn.Text = "读数(Oe)";
					break;
				case 3:
					Xn.Text = "读数(A/m)";
					Yn.Text = "读数(A/m)";
					Zn.Text = "读数(A/m)";
					Bn.Text = "读数(A/m)";
					break;
				}
				model_num = 1;
			}
		}
		else if (ComboBox_select_model.SelectedItem.ToString().EndsWith("磁通门计"))
		{
			Xn.Text = "读数(nT)";
			Yn.Text = "读数(nT)";
			Zn.Text = "读数(nT)";
			Bn.Text = "读数(nT)";
		}
		else
		{
			Xn.Text = "读数(mT)";
			Yn.Text = "读数(mT)";
			Zn.Text = "读数(mT)";
			Bn.Text = "读数(mT)";
		}
		if (ComboBox_select_data.SelectedItem.ToString().EndsWith("手动"))
		{
			serial_connecter.KeepReading(keep: true, always: false);
			Button_start_stop_serial.Enabled = false;
		}
		else
		{
			serial_connecter.KeepReading(keep: false, always: false);
			Button_start_stop_serial.Enabled = true;
		}
	}

	private void add_select_data_list(string str)
	{
		if (str.EndsWith("高斯计"))
		{
			switch (GuassUnit)
			{
			default:
				return;
			case 0:
				Xn.Text = "读数(mT)";
				Yn.Text = "读数(mT)";
				Zn.Text = "读数(mT)";
				Bn.Text = "读数(mT)";
				break;
			case 1:
				Xn.Text = "读数(G)";
				Yn.Text = "读数(G)";
				Zn.Text = "读数(G)";
				Bn.Text = "读数(G)";
				break;
			case 2:
				Xn.Text = "读数(Oe)";
				Yn.Text = "读数(Oe)";
				Zn.Text = "读数(Oe)";
				Bn.Text = "读数(Oe)";
				break;
			case 3:
				Xn.Text = "读数(A/m)";
				Yn.Text = "读数(A/m)";
				Zn.Text = "读数(A/m)";
				Bn.Text = "读数(A/m)";
				break;
			}
			ComboBox_select_data.Items.Clear();
			ComboBox_select_data.Items.AddRange(gaussmeter_fluxgate_sata_list);
			ComboBox_select_data.SelectedIndex = 0;
		}
		else if (str.EndsWith("磁通门计"))
		{
			Xn.Text = "读数(nT)";
			Yn.Text = "读数(nT)";
			Zn.Text = "读数(nT)";
			Bn.Text = "读数(nT)";
			ComboBox_select_data.Items.Clear();
			ComboBox_select_data.Items.AddRange(gaussmeter_fluxgate_sata_list);
			ComboBox_select_data.SelectedIndex = 0;
		}
		else
		{
			Xn.Text = "读数(mT)";
			Yn.Text = "读数(mT)";
			Zn.Text = "读数(mT)";
			Bn.Text = "读数(mT)";
			ComboBox_select_data.Items.Clear();
			ComboBox_select_data.Items.AddRange(fluxmeter_sata_list);
			ComboBox_select_data.SelectedIndex = 0;
		}
	}

	private void ComboBox_select_model_SelectedIndexChanged(object sender, EventArgs e)
	{
		SystemConfig.WriteConfigData("TYPE", ComboBox_select_model.SelectedItem.ToString());
		switch (ComboBox_select_model.SelectedItem.ToString())
		{
		default:
			return;
		case "一维高斯计":
			model_num = 1;
			groupY.Visible = false;
			groupZ.Visible = false;
			label37.Visible = true;
			ComboBox_select_data.Visible = true;
			add_select_data_list(ComboBox_select_model.SelectedItem.ToString());
			if (Show_Normal)
			{
				groupB.Visible = false;
				if (zedGraphControl_realtime_serial.GraphPane.CurveList.Contains(CurveR4))
				{
					zedGraphControl_realtime_serial.GraphPane.CurveList.Remove(CurveR4);
				}
			}
			break;
		case "二维高斯计":
			model_num = 2;
			groupY.Visible = true;
			groupZ.Visible = false;
			label37.Visible = true;
			ComboBox_select_data.Visible = true;
			add_select_data_list(ComboBox_select_model.SelectedItem.ToString());
			if (Show_Normal)
			{
				groupB.Visible = true;
				if (!zedGraphControl_realtime_serial.GraphPane.CurveList.Contains(CurveR4))
				{
					CurveR4 = zedGraphControl_realtime_serial.GraphPane.AddCurve("B", listR4, label_ch4_color.BackColor, SymbolType.None);
					CurveR4.Line.Width = 2f;
				}
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
				listR1.Clear();
				listR2.Clear();
				listR3.Clear();
				listR4.Clear();
			}
			break;
		case "三维高斯计":
			model_num = 3;
			groupY.Visible = true;
			groupZ.Visible = true;
			label37.Visible = true;
			ComboBox_select_data.Visible = true;
			add_select_data_list(ComboBox_select_model.SelectedItem.ToString());
			if (Show_Normal)
			{
				groupB.Visible = true;
				if (!zedGraphControl_realtime_serial.GraphPane.CurveList.Contains(CurveR4))
				{
					CurveR4 = zedGraphControl_realtime_serial.GraphPane.AddCurve("B", listR4, label_ch4_color.BackColor, SymbolType.None);
					CurveR4.Line.Width = 2f;
				}
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
				listR1.Clear();
				listR2.Clear();
				listR3.Clear();
				listR4.Clear();
			}
			break;
		case "磁通计":
			model_num = 4;
			groupY.Visible = false;
			groupZ.Visible = false;
			groupB.Visible = false;
			label37.Visible = true;
			ComboBox_select_data.Visible = true;
			Xt.Text = "---";
			Xf.Text = "---";
			Yt.Text = "---";
			Yf.Text = "---";
			Zt.Text = "---";
			Zf.Text = "---";
			add_select_data_list(ComboBox_select_model.SelectedItem.ToString());
			if (Show_Normal)
			{
				groupB.Visible = false;
				if (zedGraphControl_realtime_serial.GraphPane.CurveList.Contains(CurveR4))
				{
					zedGraphControl_realtime_serial.GraphPane.CurveList.Remove(CurveR4);
				}
			}
			break;
		case "一维磁通门计":
			model_num = 5;
			groupY.Visible = false;
			groupZ.Visible = false;
			groupB.Visible = false;
			label37.Visible = false;
			ComboBox_select_data.Visible = false;
			Xt.Text = "---";
			Xf.Text = "---";
			Yt.Text = "---";
			Yf.Text = "---";
			Zt.Text = "---";
			Zf.Text = "---";
			add_select_data_list(ComboBox_select_model.SelectedItem.ToString());
			if (Show_Normal)
			{
				groupB.Visible = false;
				if (zedGraphControl_realtime_serial.GraphPane.CurveList.Contains(CurveR4))
				{
					zedGraphControl_realtime_serial.GraphPane.CurveList.Remove(CurveR4);
				}
			}
			break;
		case "三维磁通门计":
			model_num = 6;
			groupY.Visible = true;
			groupZ.Visible = true;
			label37.Visible = true;
			ComboBox_select_data.Visible = true;
			Xt.Text = "---";
			Xf.Text = "---";
			Yt.Text = "---";
			Yf.Text = "---";
			Zt.Text = "---";
			Zf.Text = "---";
			add_select_data_list(ComboBox_select_model.SelectedItem.ToString());
			if (Show_Normal)
			{
				groupB.Visible = true;
				if (!zedGraphControl_realtime_serial.GraphPane.CurveList.Contains(CurveR4))
				{
					CurveR4 = zedGraphControl_realtime_serial.GraphPane.AddCurve("B", listR4, label_ch4_color.BackColor, SymbolType.None);
					CurveR4.Line.Width = 2f;
				}
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
				listR1.Clear();
				listR2.Clear();
				listR3.Clear();
				listR4.Clear();
			}
			break;
		}
		if (clear_ram)
		{
			listR1.Clear();
			listR2.Clear();
			listR3.Clear();
			listR4.Clear();
			DataGride_readtime_serial.Rows.Clear();
			SaveDataCount_Serial = 0L;
			zedGraphControl_realtime_serial.AxisChange();
			zedGraphControl_realtime_serial.Refresh();
		}
	}

	private void Button_clear_Click(object sender, EventArgs e)
	{
		DataGride_readtime_serial.Rows.Clear();
		if (!SaveToFile)
		{
			SaveDataCount_Serial = 0L;
		}
		GC.Collect();
	}

	private void checkBox1_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_show_normal.Checked)
		{
			SystemConfig.WriteConfigData("ShowNormal", "true");
			checkBox_clear_ram.Checked = true;
			Show_Normal = true;
			if (ComboBox_select_model.SelectedItem.ToString().StartsWith("三") || ComboBox_select_model.SelectedItem.ToString().StartsWith("二"))
			{
				groupB.Visible = true;
				CurveR4 = zedGraphControl_realtime_serial.GraphPane.AddCurve("B", listR4, label_ch4_color.BackColor, SymbolType.None);
				CurveR4.Line.Width = 2f;
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
				listR1.Clear();
				listR2.Clear();
				listR3.Clear();
				listR4.Clear();
			}
		}
		else
		{
			SystemConfig.WriteConfigData("ShowNormal", "false");
			Show_Normal = false;
			groupB.Visible = false;
			zedGraphControl_realtime_serial.GraphPane.CurveList.Remove(CurveR4);
			zedGraphControl_realtime_serial.AxisChange();
			zedGraphControl_realtime_serial.Refresh();
		}
	}

	private void checkBox_always_reading_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_always_reading.Checked)
		{
			SystemConfig.WriteConfigData("ClearRam", "true");
		}
		else
		{
			SystemConfig.WriteConfigData("ClearRam", "false");
		}
		serial_connecter.KeepReading(checkBox_always_reading.Checked, checkBox_always_reading.Checked);
	}

	private void numericUpDown1_ValueChanged(object sender, EventArgs e)
	{
		timer_ui.Interval = (int)(numeric_refresh_time.Value * 1000m);
		SystemConfig.WriteConfigData("RefreshTime", numeric_refresh_time.Value.ToString());
	}

	private void checkBox_show_last_row_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_show_last_row.Checked)
		{
			SystemConfig.WriteConfigData("ShowLastRow", "true");
		}
		else
		{
			SystemConfig.WriteConfigData("ShowLastRow", "false");
		}
		ScrollToTheLatest = checkBox_show_last_row.Checked;
	}

	private void Button_save_once_Click(object sender, EventArgs e)
	{
		if (SaveToFile & string.IsNullOrEmpty(STFFilePath))
		{
			if (MessageBox.Show("在‘保存至文件’选定下需新建文件才可保存数据,是否新建?", "无法启用保存数据", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) != DialogResult.OK)
			{
				return;
			}
			Button_open_file_Click(sender, e);
		}
		if (listR1.Count < 1)
		{
			return;
		}
		SaveDataCount_Serial++;
		if (ComboBox_select_model.SelectedItem.ToString().StartsWith("一维") || ComboBox_select_model.SelectedItem.ToString().StartsWith("磁通计"))
		{
			if (SaveToFile)
			{
				F_SaveToFile(listR1[listR1.Count - 1].Y, 0.0, 0.0);
			}
			DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, listR1[listR1.Count - 1].Y, Xt.Text.TrimEnd('℃'), Xf.Text.TrimEnd('z').TrimEnd('H'), DateTime.Now.ToString());
		}
		else if (ComboBox_select_model.SelectedItem.ToString().StartsWith("二维"))
		{
			if (SaveToFile)
			{
				F_SaveToFile(listR1[listR1.Count - 1].Y, listR2[listR2.Count - 1].Y, 0.0);
			}
			DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, listR1[listR1.Count - 1].Y, listR2[listR2.Count - 1].Y, 0, DateTime.Now.ToString());
		}
		else
		{
			if (SaveToFile)
			{
				F_SaveToFile(listR1[listR1.Count - 1].Y, listR2[listR2.Count - 1].Y, listR3[listR3.Count - 1].Y);
			}
			DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, listR1[listR1.Count - 1].Y, listR2[listR2.Count - 1].Y, listR3[listR3.Count - 1].Y, DateTime.Now.ToString());
		}
	}

	private void checkBox_clear_ram_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_clear_ram.Checked)
		{
			SystemConfig.WriteConfigData("ClearRam", "true");
		}
		else
		{
			if (checkBox_show_normal.Checked)
			{
				checkBox_show_normal.Checked = false;
			}
			SystemConfig.WriteConfigData("ClearRam", "false");
		}
		clear_ram = checkBox_clear_ram.Checked;
	}

	private void dmButton1_Click(object sender, EventArgs e)
	{
		listR1.Clear();
		listR2.Clear();
		listR3.Clear();
		listR4.Clear();
		zedGraphControl_realtime_serial.AxisChange();
		zedGraphControl_realtime_serial.Refresh();
	}

	private void ComboBox_select_model_Click(object sender, EventArgs e)
	{
		if (Button_start_stop_serial.Text == "停止")
		{
			Button_start_stop_serial_Click(sender, e);
		}
	}

	private void ComboBox_select_data_Click(object sender, EventArgs e)
	{
		if (Button_start_stop_serial.Text == "停止")
		{
			Button_start_stop_serial_Click(sender, e);
		}
	}

	private void checkBox_send_out_CheckedChanged(object sender, EventArgs e)
	{
		SendOut = checkBox_send_out.Checked;
		if (SendOut)
		{
			SystemConfig.WriteConfigData("SendOut", "true");
			checkBox_send_out_with.Enabled = true;
		}
		else
		{
			SystemConfig.WriteConfigData("SendOut", "false");
			checkBox_send_out_with.Checked = false;
			checkBox_send_out_with.Enabled = false;
		}
	}

	private void checkBox_send_out_with_CheckedChanged(object sender, EventArgs e)
	{
		SendOutWith = checkBox_send_out_with.Checked;
		if (SendOutWith)
		{
			SystemConfig.WriteConfigData("SendOutWith", "true");
		}
		else
		{
			SystemConfig.WriteConfigData("SendOutWith", "false");
		}
	}

	private void checkBox_judge_CheckedChanged(object sender, EventArgs e)
	{
		Judge = checkBox_judge.Checked;
		if (Judge)
		{
			if (b_lampEnable)
			{
				lamp_alarmRight();
			}
			cbx_ABS.Visible = true;
			groupBox_judge.Visible = true;
			numeric_judge_up.Enabled = true;
			numeric_judge_down.Enabled = true;
			ComboBox_judge_type.Enabled = true;
			SystemConfig.WriteConfigData("Judge", "true");
		}
		else
		{
			if (b_lampEnable)
			{
				lamp_alarmClose();
			}
			cbx_ABS.Visible = false;
			groupBox_judge.Visible = false;
			numeric_judge_up.Enabled = false;
			numeric_judge_down.Enabled = false;
			ComboBox_judge_type.Enabled = false;
			SystemConfig.WriteConfigData("Judge", "false");
		}
	}

	private void numeric_judge_up_ValueChanged(object sender, EventArgs e)
	{
		if (numeric_judge_up.Value <= numeric_judge_down.Value)
		{
			numeric_judge_up.Value = numeric_judge_down.Value + 0.001m;
		}
		judgeup = (double)numeric_judge_up.Value;
		SystemConfig.WriteConfigData("JudgeUp", judgeup.ToString());
	}

	private void numeric_judge_down_ValueChanged(object sender, EventArgs e)
	{
		if (numeric_judge_up.Value <= numeric_judge_down.Value)
		{
			numeric_judge_down.Value = numeric_judge_up.Value - 0.001m;
		}
		judgedown = (double)numeric_judge_down.Value;
		SystemConfig.WriteConfigData("JudgeDown", judgedown.ToString());
	}

	private void ComboBox_judge_type_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (ComboBox_judge_type.SelectedIndex)
		{
		case 0:
			judgeopen = true;
			SystemConfig.WriteConfigData("JudgeOpen", "true");
			break;
		case 1:
			judgeopen = false;
			SystemConfig.WriteConfigData("JudgeOpen", "false");
			break;
		}
	}

	private void checkBox_save_to_file_CheckedChanged(object sender, EventArgs e)
	{
		SaveToFile = checkBox_save_to_file.Checked;
		CheckBox_savedata_serial.Checked = false;
		if (SaveToFile)
		{
			groupBox7.Enabled = true;
			groupBox8.Visible = true;
			SystemConfig.WriteConfigData("SaveToFile", "true");
			return;
		}
		if (!string.IsNullOrEmpty(STFFilePath))
		{
			if (SaveData_Serial)
			{
				Button_open_file_Click(sender, e);
			}
			STFFilePath = null;
			label_file_path.Text = "文件位置：未打开";
			STFsw.Flush();
			STFsw.Close();
		}
		groupBox7.Enabled = false;
		groupBox8.Visible = false;
		SystemConfig.WriteConfigData("SaveToFile", "false");
	}

	private void ComboBox_STFReachMaximum_SelectedIndexChanged(object sender, EventArgs e)
	{
		switch (ComboBox_STFReachMaximum.SelectedIndex)
		{
		case 0:
			SystemConfig.WriteConfigData("STFReachMaximum", "STOP");
			STFRM_STOP = true;
			break;
		case 1:
			SystemConfig.WriteConfigData("STFReachMaximum", "ATNF");
			STFRM_STOP = false;
			break;
		}
	}

	private void numeric_STFDataMaximum_ValueChanged(object sender, EventArgs e)
	{
		SystemConfig.WriteConfigData("STFDataMaximum", numeric_STFDataMaximum.Value.ToString());
		STFDataMaximum = Convert.ToInt64(numeric_STFDataMaximum.Value);
	}

	private void Button_open_file_Click(object sender, EventArgs e)
	{
		if (Button_open_file.Text == "新建文件")
		{
			if (saveFileDialog1.ShowDialog() == DialogResult.OK)
			{
				Button_open_file.Text = "结束并关闭";
				STFFilePath = saveFileDialog1.FileName;
				label_file_path.Text = "文件位置：" + STFFilePath;
				STFsw = new StreamWriter(STFFilePath);
				STFsw.AutoFlush = true;
			}
		}
		else if (Button_open_file.Text == "结束并关闭")
		{
			CheckBox_savedata_serial.Checked = false;
			Button_open_file.Text = "新建文件";
			if (!string.IsNullOrEmpty(STFFilePath))
			{
				STFFilePath = null;
				label_file_path.Text = "文件位置：未打开";
				STFsw.Flush();
				STFsw.Close();
				STFFileSerial = 2;
				STFDataCount = 0L;
				SaveDataCount_Serial = 0L;
			}
		}
	}

	private void checkBox_data_debug_CheckedChanged(object sender, EventArgs e)
	{
		DataDebug = checkBox_data_debug.Checked;
		if (DataDebug)
		{
			groupBox9.Visible = true;
			return;
		}
		groupBox9.Visible = false;
		clearAllToolStripMenuItem_Click(sender, e);
	}

	private void Button_data_debug_send_Click(object sender, EventArgs e)
	{
		if (TextBoxDataDebugSendTextHex)
		{
			string[] hexValuesSplit = textBox_data_debug_send.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
			textBox_data_debug_send.Text = "";
			string[] array = hexValuesSplit;
			foreach (string hex in array)
			{
				int value = Convert.ToInt32(hex, 16);
				string stringValue = char.ConvertFromUtf32(value);
				textBox_data_debug_send.AppendText(stringValue);
			}
			TextBoxDataDebugSendTextHex = false;
		}
		if (textBox_data_debug_send.Text.StartsWith("PIPE"))
		{
			if (textBox_data_debug_send.Text.Split(' ')[1] == "1")
			{
				SystemConfig.WriteConfigData("PIPE", "true");
				textBox_data_debug_screen.AppendText("PIPE ON\n");
				groupBox12.Visible = true;
				MessageSender.Send("已开启数据通道，即将重启软件");
				System.Windows.Forms.Application.Exit();
				Process.Start(Assembly.GetExecutingAssembly().Location);
			}
			else
			{
				SystemConfig.WriteConfigData("PIPE", "false");
				textBox_data_debug_screen.AppendText("PIPE OFF\n");
				groupBox12.Visible = false;
				MessageSender.Send("已关闭数据通道，即将重启软件");
				System.Windows.Forms.Application.Exit();
				Process.Start(Assembly.GetExecutingAssembly().Location);
			}
		}
		else if (textBox_data_debug_send.Text.StartsWith("DEBUG"))
		{
			if (textBox_data_debug_send.Text.Split(' ')[1] == "1")
			{
				textBox_data_debug_screen.AppendText("DEBUG ON\n");
				MessageSender.Send("已转换调试模式 Debug ON-RE");
				DebugMode = true;
				serial_connecter.SetDebugMode(Mode: true);
			}
			else
			{
				textBox_data_debug_screen.AppendText("DEBUG OFF\n");
				MessageSender.Send("已转换调试模式 Debug ON-RL");
				DebugMode = false;
				serial_connecter.SetDebugMode(Mode: false);
			}
		}
		else
		{
			serial_connecter.Write(textBox_data_debug_send.Text);
		}
		textBox_data_debug_send.Text = "";
	}

	private void dATAToolStripMenuItem_Click(object sender, EventArgs e)
	{
		serial_connecter.Write(sender.ToString());
	}

	private void clearScreenToolStripMenuItem_Click(object sender, EventArgs e)
	{
		textBox_data_debug_screen.Clear();
	}

	private void clearInputToolStripMenuItem_Click(object sender, EventArgs e)
	{
		textBox_data_debug_send.Clear();
	}

	private void clearAllToolStripMenuItem_Click(object sender, EventArgs e)
	{
		textBox_data_debug_screen.Clear();
		textBox_data_debug_send.Clear();
	}

	private void numericUp_graph_scale_ValueChanged(object sender, EventArgs e)
	{
		GraphScaleMax = (int)numericUp_graph_scale.Value;
		zedGraphControl_realtime_serial.GraphPane.XAxis.Scale.Max = GraphScaleMax;
		zedGraphControl_realtime_serial.AxisChange();
		zedGraphControl_realtime_serial.Refresh();
		SystemConfig.WriteConfigData("GraphScale", GraphScaleMax.ToString());
	}

	private void dmButton2_Click(object sender, EventArgs e)
	{
		label_ch1_color.BackColor = Color.FromArgb(255, 192, 192);
		label_ch2_color.BackColor = Color.FromArgb(192, 255, 192);
		label_ch3_color.BackColor = Color.FromArgb(192, 192, 255);
		label_ch4_color.BackColor = Color.FromArgb(255, 192, 128);
		trackBar_curve_length.Value = 1;
		numericUp_graph_scale.Value = 300m;
	}

	private void label_ch1_color_Click(object sender, EventArgs e)
	{
		if (colorDialog1.ShowDialog() == DialogResult.OK)
		{
			label_ch1_color.BackColor = colorDialog1.Color;
		}
	}

	private void label_ch2_color_Click(object sender, EventArgs e)
	{
		if (colorDialog1.ShowDialog() == DialogResult.OK)
		{
			label_ch2_color.BackColor = colorDialog1.Color;
		}
	}

	private void label_ch3_color_Click(object sender, EventArgs e)
	{
		if (colorDialog1.ShowDialog() == DialogResult.OK)
		{
			label_ch3_color.BackColor = colorDialog1.Color;
		}
	}

	private void label_ch4_color_Click(object sender, EventArgs e)
	{
		if (colorDialog1.ShowDialog() == DialogResult.OK)
		{
			label_ch4_color.BackColor = colorDialog1.Color;
		}
	}

	private void label_ch1_color_BackColorChanged(object sender, EventArgs e)
	{
		Xr.ForeColor = label_ch1_color.BackColor;
		groupX.ForeColor = label_ch1_color.BackColor;
		for (int i = 0; i < zedGraphControl_realtime_serial.GraphPane.CurveList.Count; i++)
		{
			if (zedGraphControl_realtime_serial.GraphPane.CurveList[i].Label.Text == "CH 1")
			{
				zedGraphControl_realtime_serial.GraphPane.CurveList[i].Color = Xr.ForeColor;
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
			}
		}
		SystemConfig.WriteConfigData("CH1Color", ColorTranslator.ToHtml(label_ch1_color.BackColor));
	}

	private void label_ch2_color_BackColorChanged(object sender, EventArgs e)
	{
		Yr.ForeColor = label_ch2_color.BackColor;
		groupY.ForeColor = label_ch2_color.BackColor;
		for (int i = 0; i < zedGraphControl_realtime_serial.GraphPane.CurveList.Count; i++)
		{
			if (zedGraphControl_realtime_serial.GraphPane.CurveList[i].Label.Text == "CH 2")
			{
				zedGraphControl_realtime_serial.GraphPane.CurveList[i].Color = Yr.ForeColor;
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
			}
		}
		SystemConfig.WriteConfigData("CH2Color", ColorTranslator.ToHtml(label_ch2_color.BackColor));
	}

	private void label_ch3_color_BackColorChanged(object sender, EventArgs e)
	{
		Zr.ForeColor = label_ch3_color.BackColor;
		groupZ.ForeColor = label_ch3_color.BackColor;
		for (int i = 0; i < zedGraphControl_realtime_serial.GraphPane.CurveList.Count; i++)
		{
			if (zedGraphControl_realtime_serial.GraphPane.CurveList[i].Label.Text == "CH 3")
			{
				zedGraphControl_realtime_serial.GraphPane.CurveList[i].Color = Zr.ForeColor;
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
			}
		}
		SystemConfig.WriteConfigData("CH3Color", ColorTranslator.ToHtml(label_ch3_color.BackColor));
	}

	private void label_ch4_color_BackColorChanged(object sender, EventArgs e)
	{
		Br.ForeColor = label_ch4_color.BackColor;
		groupB.ForeColor = label_ch4_color.BackColor;
		for (int i = 0; i < zedGraphControl_realtime_serial.GraphPane.CurveList.Count; i++)
		{
			if (zedGraphControl_realtime_serial.GraphPane.CurveList[i].Label.Text == "CH 4")
			{
				zedGraphControl_realtime_serial.GraphPane.CurveList[i].Color = Br.ForeColor;
				zedGraphControl_realtime_serial.AxisChange();
				zedGraphControl_realtime_serial.Refresh();
			}
		}
		SystemConfig.WriteConfigData("CH4Color", ColorTranslator.ToHtml(label_ch4_color.BackColor));
	}

	private void trackBar_curve_length_Scroll(object sender, EventArgs e)
	{
		label_curve_length.Text = trackBar_curve_length.Value.ToString();
		CurveR1.Line.Width = trackBar_curve_length.Value;
		CurveR2.Line.Width = trackBar_curve_length.Value;
		CurveR3.Line.Width = trackBar_curve_length.Value;
		zedGraphControl_realtime_serial.AxisChange();
		zedGraphControl_realtime_serial.Refresh();
		CurveWidth = trackBar_curve_length.Value;
		SystemConfig.WriteConfigData("CurveWidth", CurveWidth.ToString());
	}

	private void ComboBox_unit_SelectedIndexChanged(object sender, EventArgs e)
	{
		GuassUnit = ComboBox_unit.SelectedIndex;
		if (CheckBox_savedata_serial.Checked)
		{
			CheckBox_savedata_serial.Checked = false;
		}
		Button_clear_Click(sender, e);
		dmButton1_Click(sender, e);
		if (ComboBox_select_model.SelectedItem.ToString().EndsWith("高斯计") || (ComboBox_select_model.SelectedItem.ToString().Contains("磁通计") && ComboBox_select_data.SelectedItem.ToString().Contains("感应强度")))
		{
			switch (GuassUnit)
			{
			default:
				return;
			case 0:
				Xn.Text = "读数(mT)";
				Yn.Text = "读数(mT)";
				Zn.Text = "读数(mT)";
				Bn.Text = "读数(mT)";
				break;
			case 1:
				Xn.Text = "读数(G)";
				Yn.Text = "读数(G)";
				Zn.Text = "读数(G)";
				Bn.Text = "读数(G)";
				break;
			case 2:
				Xn.Text = "读数(Oe)";
				Yn.Text = "读数(Oe)";
				Zn.Text = "读数(Oe)";
				Bn.Text = "读数(Oe)";
				break;
			case 3:
				Xn.Text = "读数(A/m)";
				Yn.Text = "读数(A/m)";
				Zn.Text = "读数(A/m)";
				Bn.Text = "读数(A/m)";
				break;
			case 4:
				Xn.Text = "读数(mGs)";
				Yn.Text = "读数(mGs)";
				Zn.Text = "读数(mGs)";
				Bn.Text = "读数(mGs)";
				break;
			}
		}
		SystemConfig.WriteConfigData("GuassUnit", GuassUnit.ToString());
	}

	private void dmButton1_Click_1(object sender, EventArgs e)
	{
		DataReview DR = new DataReview(base.Left, base.Top, base.Height, base.Width);
		DR.ShowDialog();
	}

	private void textBox_data_debug_send_KeyPress(object sender, KeyPressEventArgs e)
	{
		if (e.KeyChar == '\r')
		{
			Button_data_debug_send_Click(sender, e);
		}
	}

	private void Button_save_pipe_name_Click(object sender, EventArgs e)
	{
		SystemConfig.WriteConfigData("PipeName", textBox_pipe_name.Text);
		MessageSender.Send("保存成功，需要使用新的通道命名请重启软件");
	}

	private void dmButton3_Click(object sender, EventArgs e)
	{
		textBox_pipe_name.Text = "SerialDataReader";
	}

	private void Form1_FormClosing(object sender, FormClosingEventArgs e)
	{
		if (PipeMode)
		{
			pipeS.Stop();
		}
		serial_connecter.Close();
		if (b_lampEnable)
		{
			lamp_alarmClose();
		}
	}

	private void timer_display_pipe_notice_Tick(object sender, EventArgs e)
	{
		timer_display_pipe_notice.Enabled = false;
		MessageSender.Send("数据通道已打开");
	}

	private void timerGuaid_Tick(object sender, EventArgs e)
	{
		timerGuaid.Enabled = false;
		SystemConfig.WriteConfigData("QG", "false");
		QuickGuaid QG = new QuickGuaid();
		QG.ShowDialog();
	}

	private void dmButton4_Click(object sender, EventArgs e)
	{
		QuickGuaid QG = new QuickGuaid();
		QG.ShowDialog();
	}

	private void timerSTF_Tick(object sender, EventArgs e)
	{
		DataGride_readtime_serial.Rows.Clear();
		GC.Collect();
	}

	private void dEBUGONToolStripMenuItem_Click(object sender, EventArgs e)
	{
		textBox_data_debug_send.Text = "DEBUG 1";
		Button_data_debug_send_Click(sender, e);
	}

	private void dEBUGOFFToolStripMenuItem_Click(object sender, EventArgs e)
	{
		textBox_data_debug_send.Text = "DEBUG 0";
		Button_data_debug_send_Click(sender, e);
	}

	private void HexASCII转换ToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!DebugMode)
		{
			MessageSender.Send("需启用DebugMode ON-RE");
			return;
		}
		try
		{
			if (TextBoxDataDebugSendTextHex)
			{
				string[] hexValuesSplit = textBox_data_debug_send.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				textBox_data_debug_send.Text = "";
				string[] array = hexValuesSplit;
				foreach (string hex in array)
				{
					int value = Convert.ToInt32(hex, 16);
					string stringValue = char.ConvertFromUtf32(value);
					textBox_data_debug_send.AppendText(stringValue);
				}
				TextBoxDataDebugSendTextHex = false;
				return;
			}
			char[] values = textBox_data_debug_send.Text.ToCharArray();
			textBox_data_debug_send.Text = "";
			char[] array2 = values;
			foreach (char letter in array2)
			{
				int value2 = Convert.ToInt32(letter);
				string hexOutput = $"{value2:X}";
				if (hexOutput.Length == 1)
				{
					textBox_data_debug_send.AppendText("0" + hexOutput + " ");
				}
				else
				{
					textBox_data_debug_send.AppendText(hexOutput + " ");
				}
			}
			TextBoxDataDebugSendTextHex = true;
		}
		catch
		{
			textBox_data_debug_send.Text = "";
		}
	}

	private void hexadecimalASCIIToolStripMenuItem_Click(object sender, EventArgs e)
	{
		if (!DebugMode)
		{
			MessageSender.Send("需启用DebugMode ON-RE");
			return;
		}
		try
		{
			if (TextBoxDataDebugScreenTextHex)
			{
				string[] hexValuesSplit = textBox_data_debug_screen.Text.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
				textBox_data_debug_screen.Text = "";
				string[] array = hexValuesSplit;
				foreach (string hex in array)
				{
					int value = Convert.ToInt32(hex, 16);
					string stringValue = char.ConvertFromUtf32(value);
					textBox_data_debug_screen.AppendText(stringValue);
				}
				TextBoxDataDebugScreenTextHex = false;
				return;
			}
			char[] values = textBox_data_debug_screen.Text.ToCharArray();
			textBox_data_debug_screen.Text = "";
			char[] array2 = values;
			foreach (char letter in array2)
			{
				int value2 = Convert.ToInt32(letter);
				string hexOutput = $"{value2:X}";
				if (hexOutput.Length == 1)
				{
					textBox_data_debug_screen.AppendText("0" + hexOutput + " ");
				}
				else
				{
					textBox_data_debug_screen.AppendText(hexOutput + " ");
				}
			}
			TextBoxDataDebugScreenTextHex = true;
		}
		catch
		{
			textBox_data_debug_screen.Text = "";
		}
	}

	private void dmButton5_Click(object sender, EventArgs e)
	{
		serial_connecter.Write("ZERO>");
	}

	private void checkBox_clear_after_export_CheckedChanged(object sender, EventArgs e)
	{
		clear_after_export = checkBox_clear_after_export.Checked;
		if (clear_after_export)
		{
			SystemConfig.WriteConfigData("CAE", "true");
		}
		else
		{
			SystemConfig.WriteConfigData("CAE", "false");
		}
	}

	private void checkBox_SaveDataTime_CheckedChanged(object sender, EventArgs e)
	{
		if (checkBox_SaveDataTime.Checked)
		{
			SystemConfig.WriteConfigData("SaveDataByTime", "true");
			CheckBox_savedata_serial.Checked = false;
			SaveDataTime = true;
			groupBox_SaveDataTime.Enabled = true;
		}
		else
		{
			SystemConfig.WriteConfigData("SaveDataByTime", "false");
			CheckBox_savedata_serial.Checked = false;
			SaveDataTime = false;
			groupBox_SaveDataTime.Enabled = false;
		}
	}

	private void timer_SaveData_Tick(object sender, EventArgs e)
	{
		double R1 = 0.0;
		double R2 = 0.0;
		double R3 = 0.0;
		R1 = ((listR1.Count <= 0) ? 0.0 : listR1[listR1.Count - 1].Y);
		R2 = ((listR2.Count <= 0) ? 0.0 : listR2[listR2.Count - 1].Y);
		R3 = ((listR3.Count <= 0) ? 0.0 : listR3[listR3.Count - 1].Y);
		if (SaveToFile)
		{
			F_SaveToFile(R1, R2, R3);
		}
		SaveDataCount_Serial++;
		DataGride_readtime_serial.Rows.Add(SaveDataCount_Serial, listR1[listR1.Count - 1].Y, R2, R3, DateTime.Now.ToString());
	}

	private void numericUp_SaveDataTime_ValueChanged(object sender, EventArgs e)
	{
		timer_SaveData.Interval = (int)(numericUp_SaveDataTime.Value * 1000m);
		SystemConfig.WriteConfigData("SaveDataTime", numericUp_SaveDataTime.Value.ToString());
	}

	private void DataGride_readtime_serial_RowEnter(object sender, DataGridViewCellEventArgs e)
	{
		dgvDelIndex = e.RowIndex;
		btnDelete.Enabled = true;
	}

	private void btnDelete_Click(object sender, EventArgs e)
	{
		DialogResult diaRe = MessageBox.Show("确定要删除选定的项目？", "询问", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		if (diaRe == DialogResult.Yes)
		{
			btnDelete.Enabled = false;
			DataGride_readtime_serial.Rows.RemoveAt(dgvDelIndex);
			SaveDataCount_Serial--;
			GC.Collect();
			if (b_language_cn)
			{
				MessageBox.Show("删除成功！", "SUCCESS");
			}
			else
			{
				MessageBox.Show("Delete complete！", "SUCCESS");
			}
		}
	}

	private void btn_single_Click(object sender, EventArgs e)
	{
		if (serial_connecter.IsOpen)
		{
			serial_connecter.Write("DATAS>");
		}
	}

	private void cbx_ABS_CheckedChanged(object sender, EventArgs e)
	{
		if (cbx_ABS.Checked)
		{
			Judge_ABS = true;
			SystemConfig.WriteConfigData("Judge_ABS", "true");
		}
		else
		{
			Judge_ABS = false;
			SystemConfig.WriteConfigData("Judge_ABS", "false");
		}
	}

	private void cbx_comAlarmLamp_Click(object sender, EventArgs e)
	{
		cbx_comAlarmLamp.Items.Clear();
		ComboBox.ObjectCollection items = cbx_comAlarmLamp.Items;
		object[] portNames = SerialPort.GetPortNames();
		items.AddRange(portNames);
	}

	private void cbx_comAlarmLamp_SelectedIndexChanged(object sender, EventArgs e)
	{
		try
		{
			if (b_lampEnable)
			{
				if (sp_lamp.IsOpen)
				{
					sp_lamp.Close();
				}
				sp_lamp.PortName = cbx_comAlarmLamp.SelectedItem.ToString().Trim();
				sp_lamp.Open();
				lamp_alarmRight();
				SystemConfig.WriteConfigData("COMMSET_LAMP", cbx_comAlarmLamp.SelectedItem.ToString().Trim());
			}
		}
		catch (Exception ex)
		{
			MessageSender.Send("Can not open " + ex.ToString());
		}
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataReader2.Form1));
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
		System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
		this.dmTabControl1 = new DMSkin.Controls.DMTabControl();
		this.tabPage7 = new System.Windows.Forms.TabPage();
		this.btnDelete = new DMSkin.Controls.DMButton();
		this.Button_clear = new DMSkin.Controls.DMButton();
		this.Button_refresh_graph = new DMSkin.Controls.DMButton();
		this.CheckBox_savedata_serial = new DMSkin.Metro.Controls.MetroCheckBox();
		this.Button_export_serial = new DMSkin.Controls.DMButton();
		this.Button_save_once = new DMSkin.Controls.DMButton();
		this.panel_datapanel_serial = new System.Windows.Forms.Panel();
		this.btn_single = new DMSkin.Controls.DMButton();
		this.dmButton5 = new DMSkin.Controls.DMButton();
		this.groupBox8 = new System.Windows.Forms.GroupBox();
		this.label_file_path = new System.Windows.Forms.Label();
		this.Button_open_file = new DMSkin.Controls.DMButton();
		this.groupBox_judge = new System.Windows.Forms.GroupBox();
		this.label_judge = new System.Windows.Forms.Label();
		this.label7 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.ComboBox_select_model = new DMSkin.Metro.Controls.MetroComboBox();
		this.label3 = new System.Windows.Forms.Label();
		this.ComboBox_serial_port_choice = new DMSkin.Metro.Controls.MetroComboBox();
		this.label37 = new System.Windows.Forms.Label();
		this.Button_start_stop_serial = new DMSkin.Controls.DMButton();
		this.ComboBox_select_data = new DMSkin.Metro.Controls.MetroComboBox();
		this.button_showdatagride_serial = new System.Windows.Forms.Button();
		this.DataGride_readtime_serial = new DMSkin.Metro.Controls.MetroGrid();
		this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
		this.button_hidedatagride_serial = new System.Windows.Forms.Button();
		this.groupB = new System.Windows.Forms.GroupBox();
		this.Bn = new System.Windows.Forms.Label();
		this.Br = new System.Windows.Forms.Label();
		this.groupX = new System.Windows.Forms.GroupBox();
		this.Xn = new System.Windows.Forms.Label();
		this.Xf = new System.Windows.Forms.Label();
		this.Xr = new System.Windows.Forms.Label();
		this.Xt = new System.Windows.Forms.Label();
		this.groupZ = new System.Windows.Forms.GroupBox();
		this.Zn = new System.Windows.Forms.Label();
		this.Zf = new System.Windows.Forms.Label();
		this.Zr = new System.Windows.Forms.Label();
		this.Zt = new System.Windows.Forms.Label();
		this.groupY = new System.Windows.Forms.GroupBox();
		this.Yn = new System.Windows.Forms.Label();
		this.Yf = new System.Windows.Forms.Label();
		this.Yr = new System.Windows.Forms.Label();
		this.Yt = new System.Windows.Forms.Label();
		this.zedGraphControl_realtime_serial = new ZedGraph.ZedGraphControl();
		this.tabPage3 = new System.Windows.Forms.TabPage();
		this.groupBox12 = new System.Windows.Forms.GroupBox();
		this.textBox_pipe_last_rec = new System.Windows.Forms.TextBox();
		this.label28 = new System.Windows.Forms.Label();
		this.groupBox14 = new System.Windows.Forms.GroupBox();
		this.label26 = new System.Windows.Forms.Label();
		this.label27 = new System.Windows.Forms.Label();
		this.label22 = new System.Windows.Forms.Label();
		this.Button_save_pipe_name = new DMSkin.Controls.DMButton();
		this.dmButton3 = new DMSkin.Controls.DMButton();
		this.textBox_pipe_name = new System.Windows.Forms.TextBox();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.dATAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.dATACToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fAST20ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fAST50ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fAST100ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fAST200ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.fAST300ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.zEROToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.mODLEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.clearScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.clearInputToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.clearAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.dEBUGONToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.dEBUGOFFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox13 = new System.Windows.Forms.GroupBox();
		this.label25 = new System.Windows.Forms.Label();
		this.label24 = new System.Windows.Forms.Label();
		this.groupBox9 = new System.Windows.Forms.GroupBox();
		this.textBox_data_debug_send = new System.Windows.Forms.TextBox();
		this.contextMenuStrip2 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.HexASCII转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.Button_data_debug_send = new DMSkin.Controls.DMButton();
		this.textBox_data_debug_screen = new System.Windows.Forms.TextBox();
		this.contextMenuStrip3 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.hexadecimalASCIIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox3 = new System.Windows.Forms.GroupBox();
		this.checkBox_SaveDataTime = new System.Windows.Forms.CheckBox();
		this.groupBox_SaveDataTime = new System.Windows.Forms.GroupBox();
		this.numericUp_SaveDataTime = new System.Windows.Forms.NumericUpDown();
		this.label29 = new System.Windows.Forms.Label();
		this.dmButton4 = new DMSkin.Controls.DMButton();
		this.checkBox_data_debug = new System.Windows.Forms.CheckBox();
		this.groupBox4 = new System.Windows.Forms.GroupBox();
		this.checkBox_send_out_with = new System.Windows.Forms.CheckBox();
		this.checkBox_send_out = new System.Windows.Forms.CheckBox();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.checkBox_clear_after_export = new System.Windows.Forms.CheckBox();
		this.groupBox11 = new System.Windows.Forms.GroupBox();
		this.label17 = new System.Windows.Forms.Label();
		this.ComboBox_unit = new DMSkin.Metro.Controls.MetroComboBox();
		this.groupBox6 = new System.Windows.Forms.GroupBox();
		this.dmButton1 = new DMSkin.Controls.DMButton();
		this.checkBox_save_to_file = new System.Windows.Forms.CheckBox();
		this.groupBox7 = new System.Windows.Forms.GroupBox();
		this.ComboBox_STFReachMaximum = new DMSkin.Metro.Controls.MetroComboBox();
		this.label14 = new System.Windows.Forms.Label();
		this.numeric_STFDataMaximum = new System.Windows.Forms.NumericUpDown();
		this.label13 = new System.Windows.Forms.Label();
		this.label8 = new System.Windows.Forms.Label();
		this.checkBox_always_reading = new System.Windows.Forms.CheckBox();
		this.checkBox_show_normal = new System.Windows.Forms.CheckBox();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.label20 = new System.Windows.Forms.Label();
		this.groupBox10 = new System.Windows.Forms.GroupBox();
		this.label_curve_length = new System.Windows.Forms.Label();
		this.trackBar_curve_length = new System.Windows.Forms.TrackBar();
		this.label16 = new System.Windows.Forms.Label();
		this.dmButton2 = new DMSkin.Controls.DMButton();
		this.label23 = new System.Windows.Forms.Label();
		this.label_ch4_color = new System.Windows.Forms.Label();
		this.label21 = new System.Windows.Forms.Label();
		this.label_ch3_color = new System.Windows.Forms.Label();
		this.label19 = new System.Windows.Forms.Label();
		this.label_ch2_color = new System.Windows.Forms.Label();
		this.label18 = new System.Windows.Forms.Label();
		this.label_ch1_color = new System.Windows.Forms.Label();
		this.label15 = new System.Windows.Forms.Label();
		this.numericUp_graph_scale = new System.Windows.Forms.NumericUpDown();
		this.label12 = new System.Windows.Forms.Label();
		this.groupBox5 = new System.Windows.Forms.GroupBox();
		this.label11 = new System.Windows.Forms.Label();
		this.label10 = new System.Windows.Forms.Label();
		this.numeric_judge_down = new System.Windows.Forms.NumericUpDown();
		this.numeric_judge_up = new System.Windows.Forms.NumericUpDown();
		this.label9 = new System.Windows.Forms.Label();
		this.ComboBox_judge_type = new DMSkin.Metro.Controls.MetroComboBox();
		this.checkBox_judge = new System.Windows.Forms.CheckBox();
		this.label6 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.numeric_refresh_time = new System.Windows.Forms.NumericUpDown();
		this.checkBox_show_last_row = new System.Windows.Forms.CheckBox();
		this.checkBox_clear_ram = new System.Windows.Forms.CheckBox();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.timer_ui = new System.Windows.Forms.Timer(this.components);
		this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
		this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
		this.dataSet1 = new System.Data.DataSet();
		this.dt = new System.Data.DataTable();
		this.dataColumn1 = new System.Data.DataColumn();
		this.dataColumn2 = new System.Data.DataColumn();
		this.dataColumn3 = new System.Data.DataColumn();
		this.dataColumn4 = new System.Data.DataColumn();
		this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
		this.colorDialog1 = new System.Windows.Forms.ColorDialog();
		this.timer_display_pipe_notice = new System.Windows.Forms.Timer(this.components);
		this.timerGuaid = new System.Windows.Forms.Timer(this.components);
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.timerSTF = new System.Windows.Forms.Timer(this.components);
		this.timer_SaveData = new System.Windows.Forms.Timer(this.components);
		this.cbx_ABS = new System.Windows.Forms.CheckBox();
		this.cbx_comAlarmLamp = new DMSkin.Metro.Controls.MetroComboBox();
		this.gpb_lamp = new System.Windows.Forms.GroupBox();
		this.sp_lamp = new System.IO.Ports.SerialPort(this.components);
		this.dmTabControl1.SuspendLayout();
		this.tabPage7.SuspendLayout();
		this.panel_datapanel_serial.SuspendLayout();
		this.groupBox8.SuspendLayout();
		this.groupBox_judge.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.DataGride_readtime_serial).BeginInit();
		this.groupB.SuspendLayout();
		this.groupX.SuspendLayout();
		this.groupZ.SuspendLayout();
		this.groupY.SuspendLayout();
		this.tabPage3.SuspendLayout();
		this.groupBox12.SuspendLayout();
		this.groupBox14.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		this.groupBox13.SuspendLayout();
		this.groupBox9.SuspendLayout();
		this.contextMenuStrip2.SuspendLayout();
		this.contextMenuStrip3.SuspendLayout();
		this.groupBox3.SuspendLayout();
		this.groupBox_SaveDataTime.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUp_SaveDataTime).BeginInit();
		this.groupBox4.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.groupBox11.SuspendLayout();
		this.groupBox6.SuspendLayout();
		this.groupBox7.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numeric_STFDataMaximum).BeginInit();
		this.groupBox1.SuspendLayout();
		this.groupBox10.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.trackBar_curve_length).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numericUp_graph_scale).BeginInit();
		this.groupBox5.SuspendLayout();
		((System.ComponentModel.ISupportInitialize)this.numeric_judge_down).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numeric_judge_up).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.numeric_refresh_time).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dataSet1).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.dt).BeginInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		this.gpb_lamp.SuspendLayout();
		base.SuspendLayout();
		resources.ApplyResources(this.dmTabControl1, "dmTabControl1");
		this.dmTabControl1.BackColor = System.Drawing.Color.Transparent;
		this.dmTabControl1.Controls.Add(this.tabPage7);
		this.dmTabControl1.Controls.Add(this.tabPage3);
		this.dmTabControl1.DMCheckBackColor = System.Drawing.Color.FromArgb(45, 169, 255);
		this.dmTabControl1.DMCheckColor = System.Drawing.Color.FromArgb(134, 205, 255);
		this.dmTabControl1.DMDrawBack = true;
		this.dmTabControl1.DMHeight = 3;
		this.dmTabControl1.DMHoverBackColor = System.Drawing.Color.White;
		this.dmTabControl1.DMHoverColor = System.Drawing.Color.FromArgb(45, 169, 255);
		this.dmTabControl1.DMNormalBackColor = System.Drawing.Color.White;
		this.dmTabControl1.DMNormalColor = System.Drawing.Color.Silver;
		this.dmTabControl1.Multiline = true;
		this.dmTabControl1.Name = "dmTabControl1";
		this.dmTabControl1.SelectedIndex = 0;
		this.dmTabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
		this.tabPage7.BackColor = System.Drawing.Color.FromArgb(0, 84, 143);
		this.tabPage7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tabPage7.Controls.Add(this.btnDelete);
		this.tabPage7.Controls.Add(this.Button_clear);
		this.tabPage7.Controls.Add(this.Button_refresh_graph);
		this.tabPage7.Controls.Add(this.CheckBox_savedata_serial);
		this.tabPage7.Controls.Add(this.Button_export_serial);
		this.tabPage7.Controls.Add(this.Button_save_once);
		this.tabPage7.Controls.Add(this.panel_datapanel_serial);
		this.tabPage7.Controls.Add(this.button_showdatagride_serial);
		this.tabPage7.Controls.Add(this.DataGride_readtime_serial);
		this.tabPage7.Controls.Add(this.button_hidedatagride_serial);
		this.tabPage7.Controls.Add(this.groupB);
		this.tabPage7.Controls.Add(this.groupX);
		this.tabPage7.Controls.Add(this.groupZ);
		this.tabPage7.Controls.Add(this.groupY);
		this.tabPage7.Controls.Add(this.zedGraphControl_realtime_serial);
		resources.ApplyResources(this.tabPage7, "tabPage7");
		this.tabPage7.Name = "tabPage7";
		resources.ApplyResources(this.btnDelete, "btnDelete");
		this.btnDelete.BackColor = System.Drawing.Color.Transparent;
		this.btnDelete.DM_DisabledColor = System.Drawing.Color.Empty;
		this.btnDelete.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.btnDelete.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.btnDelete.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.btnDelete.DM_Radius = 1;
		this.btnDelete.ForeColor = System.Drawing.Color.White;
		this.btnDelete.Name = "btnDelete";
		this.btnDelete.UseVisualStyleBackColor = false;
		this.btnDelete.Click += new System.EventHandler(btnDelete_Click);
		resources.ApplyResources(this.Button_clear, "Button_clear");
		this.Button_clear.BackColor = System.Drawing.Color.Transparent;
		this.Button_clear.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_clear.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.Button_clear.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.Button_clear.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.Button_clear.DM_Radius = 1;
		this.Button_clear.ForeColor = System.Drawing.Color.White;
		this.Button_clear.Name = "Button_clear";
		this.Button_clear.UseVisualStyleBackColor = false;
		this.Button_clear.Click += new System.EventHandler(Button_clear_Click);
		resources.ApplyResources(this.Button_refresh_graph, "Button_refresh_graph");
		this.Button_refresh_graph.BackColor = System.Drawing.Color.Transparent;
		this.Button_refresh_graph.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_refresh_graph.DM_DownColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.Button_refresh_graph.DM_MoveColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.Button_refresh_graph.DM_NormalColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.Button_refresh_graph.DM_Radius = 10;
		this.Button_refresh_graph.ForeColor = System.Drawing.Color.Black;
		this.Button_refresh_graph.Name = "Button_refresh_graph";
		this.Button_refresh_graph.UseVisualStyleBackColor = false;
		this.Button_refresh_graph.Click += new System.EventHandler(dmButton1_Click);
		resources.ApplyResources(this.CheckBox_savedata_serial, "CheckBox_savedata_serial");
		this.CheckBox_savedata_serial.DM_FontSize = DMSkin.Metro.MetroCheckBoxSize.Medium;
		this.CheckBox_savedata_serial.DM_UseCustomBackColor = true;
		this.CheckBox_savedata_serial.DM_UseCustomForeColor = true;
		this.CheckBox_savedata_serial.DM_UseSelectable = true;
		this.CheckBox_savedata_serial.ForeColor = System.Drawing.Color.White;
		this.CheckBox_savedata_serial.Name = "CheckBox_savedata_serial";
		this.CheckBox_savedata_serial.Style = DMSkin.Metro.MetroColorStyle.Green;
		this.CheckBox_savedata_serial.CheckedChanged += new System.EventHandler(CheckBox_savedata_serial_CheckedChanged);
		resources.ApplyResources(this.Button_export_serial, "Button_export_serial");
		this.Button_export_serial.BackColor = System.Drawing.Color.Transparent;
		this.Button_export_serial.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_export_serial.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.Button_export_serial.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.Button_export_serial.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.Button_export_serial.DM_Radius = 1;
		this.Button_export_serial.ForeColor = System.Drawing.Color.White;
		this.Button_export_serial.Name = "Button_export_serial";
		this.Button_export_serial.UseVisualStyleBackColor = false;
		this.Button_export_serial.Click += new System.EventHandler(Button_export_serial_Click);
		resources.ApplyResources(this.Button_save_once, "Button_save_once");
		this.Button_save_once.BackColor = System.Drawing.Color.Transparent;
		this.Button_save_once.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_save_once.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.Button_save_once.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.Button_save_once.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.Button_save_once.DM_Radius = 1;
		this.Button_save_once.ForeColor = System.Drawing.Color.White;
		this.Button_save_once.Name = "Button_save_once";
		this.Button_save_once.UseVisualStyleBackColor = false;
		this.Button_save_once.Click += new System.EventHandler(Button_save_once_Click);
		resources.ApplyResources(this.panel_datapanel_serial, "panel_datapanel_serial");
		this.panel_datapanel_serial.BackColor = System.Drawing.Color.FromArgb(0, 99, 172);
		this.panel_datapanel_serial.Controls.Add(this.btn_single);
		this.panel_datapanel_serial.Controls.Add(this.dmButton5);
		this.panel_datapanel_serial.Controls.Add(this.groupBox8);
		this.panel_datapanel_serial.Controls.Add(this.groupBox_judge);
		this.panel_datapanel_serial.Controls.Add(this.label4);
		this.panel_datapanel_serial.Controls.Add(this.ComboBox_select_model);
		this.panel_datapanel_serial.Controls.Add(this.label3);
		this.panel_datapanel_serial.Controls.Add(this.ComboBox_serial_port_choice);
		this.panel_datapanel_serial.Controls.Add(this.label37);
		this.panel_datapanel_serial.Controls.Add(this.Button_start_stop_serial);
		this.panel_datapanel_serial.Controls.Add(this.ComboBox_select_data);
		this.panel_datapanel_serial.Name = "panel_datapanel_serial";
		resources.ApplyResources(this.btn_single, "btn_single");
		this.btn_single.BackColor = System.Drawing.Color.Transparent;
		this.btn_single.DM_DisabledColor = System.Drawing.Color.Empty;
		this.btn_single.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.btn_single.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.btn_single.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.btn_single.DM_Radius = 5;
		this.btn_single.ForeColor = System.Drawing.Color.White;
		this.btn_single.Name = "btn_single";
		this.btn_single.UseVisualStyleBackColor = false;
		this.btn_single.Click += new System.EventHandler(btn_single_Click);
		resources.ApplyResources(this.dmButton5, "dmButton5");
		this.dmButton5.BackColor = System.Drawing.Color.Transparent;
		this.dmButton5.DM_DisabledColor = System.Drawing.Color.Empty;
		this.dmButton5.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.dmButton5.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.dmButton5.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.dmButton5.DM_Radius = 5;
		this.dmButton5.ForeColor = System.Drawing.Color.White;
		this.dmButton5.Name = "dmButton5";
		this.dmButton5.UseVisualStyleBackColor = false;
		this.dmButton5.Click += new System.EventHandler(dmButton5_Click);
		this.groupBox8.Controls.Add(this.label_file_path);
		this.groupBox8.Controls.Add(this.Button_open_file);
		resources.ApplyResources(this.groupBox8, "groupBox8");
		this.groupBox8.ForeColor = System.Drawing.Color.White;
		this.groupBox8.Name = "groupBox8";
		this.groupBox8.TabStop = false;
		resources.ApplyResources(this.label_file_path, "label_file_path");
		this.label_file_path.ForeColor = System.Drawing.Color.White;
		this.label_file_path.Name = "label_file_path";
		resources.ApplyResources(this.Button_open_file, "Button_open_file");
		this.Button_open_file.BackColor = System.Drawing.Color.Transparent;
		this.Button_open_file.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_open_file.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.Button_open_file.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.Button_open_file.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.Button_open_file.DM_Radius = 7;
		this.Button_open_file.ForeColor = System.Drawing.Color.White;
		this.Button_open_file.Name = "Button_open_file";
		this.Button_open_file.UseVisualStyleBackColor = false;
		this.Button_open_file.Click += new System.EventHandler(Button_open_file_Click);
		this.groupBox_judge.Controls.Add(this.label_judge);
		this.groupBox_judge.Controls.Add(this.label7);
		resources.ApplyResources(this.groupBox_judge, "groupBox_judge");
		this.groupBox_judge.ForeColor = System.Drawing.Color.White;
		this.groupBox_judge.Name = "groupBox_judge";
		this.groupBox_judge.TabStop = false;
		this.label_judge.BackColor = System.Drawing.Color.Silver;
		resources.ApplyResources(this.label_judge, "label_judge");
		this.label_judge.Name = "label_judge";
		this.label7.BackColor = System.Drawing.Color.FromArgb(255, 128, 0);
		resources.ApplyResources(this.label7, "label7");
		this.label7.Name = "label7";
		resources.ApplyResources(this.label4, "label4");
		this.label4.BackColor = System.Drawing.Color.Transparent;
		this.label4.ForeColor = System.Drawing.Color.White;
		this.label4.Name = "label4";
		resources.ApplyResources(this.ComboBox_select_model, "ComboBox_select_model");
		this.ComboBox_select_model.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.ComboBox_select_model.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.ComboBox_select_model.DM_UseCustomBackColor = true;
		this.ComboBox_select_model.DM_UseCustomForeColor = true;
		this.ComboBox_select_model.DM_UseSelectable = true;
		this.ComboBox_select_model.ForeColor = System.Drawing.Color.White;
		this.ComboBox_select_model.FormattingEnabled = true;
		this.ComboBox_select_model.Items.AddRange(new object[6]
		{
			resources.GetString("ComboBox_select_model.Items"),
			resources.GetString("ComboBox_select_model.Items1"),
			resources.GetString("ComboBox_select_model.Items2"),
			resources.GetString("ComboBox_select_model.Items3"),
			resources.GetString("ComboBox_select_model.Items4"),
			resources.GetString("ComboBox_select_model.Items5")
		});
		this.ComboBox_select_model.Name = "ComboBox_select_model";
		this.ComboBox_select_model.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.ComboBox_select_model.SelectedIndexChanged += new System.EventHandler(ComboBox_select_model_SelectedIndexChanged);
		this.ComboBox_select_model.Click += new System.EventHandler(ComboBox_select_model_Click);
		resources.ApplyResources(this.label3, "label3");
		this.label3.BackColor = System.Drawing.Color.Transparent;
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Name = "label3";
		resources.ApplyResources(this.ComboBox_serial_port_choice, "ComboBox_serial_port_choice");
		this.ComboBox_serial_port_choice.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.ComboBox_serial_port_choice.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.ComboBox_serial_port_choice.DM_UseCustomBackColor = true;
		this.ComboBox_serial_port_choice.DM_UseCustomForeColor = true;
		this.ComboBox_serial_port_choice.DM_UseSelectable = true;
		this.ComboBox_serial_port_choice.ForeColor = System.Drawing.Color.White;
		this.ComboBox_serial_port_choice.FormattingEnabled = true;
		this.ComboBox_serial_port_choice.Items.AddRange(new object[6]
		{
			resources.GetString("ComboBox_serial_port_choice.Items"),
			resources.GetString("ComboBox_serial_port_choice.Items1"),
			resources.GetString("ComboBox_serial_port_choice.Items2"),
			resources.GetString("ComboBox_serial_port_choice.Items3"),
			resources.GetString("ComboBox_serial_port_choice.Items4"),
			resources.GetString("ComboBox_serial_port_choice.Items5")
		});
		this.ComboBox_serial_port_choice.Name = "ComboBox_serial_port_choice";
		this.ComboBox_serial_port_choice.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.ComboBox_serial_port_choice.SelectedIndexChanged += new System.EventHandler(ComboBox_serial_port_choice_SelectedIndexChanged);
		this.ComboBox_serial_port_choice.Click += new System.EventHandler(ComboBox_serial_port_choice_Click);
		resources.ApplyResources(this.label37, "label37");
		this.label37.BackColor = System.Drawing.Color.Transparent;
		this.label37.ForeColor = System.Drawing.Color.White;
		this.label37.Name = "label37";
		resources.ApplyResources(this.Button_start_stop_serial, "Button_start_stop_serial");
		this.Button_start_stop_serial.BackColor = System.Drawing.Color.Transparent;
		this.Button_start_stop_serial.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_start_stop_serial.DM_DownColor = System.Drawing.Color.FromArgb(9, 140, 188);
		this.Button_start_stop_serial.DM_MoveColor = System.Drawing.Color.FromArgb(60, 195, 245);
		this.Button_start_stop_serial.DM_NormalColor = System.Drawing.Color.FromArgb(9, 163, 220);
		this.Button_start_stop_serial.DM_Radius = 5;
		this.Button_start_stop_serial.ForeColor = System.Drawing.Color.White;
		this.Button_start_stop_serial.Name = "Button_start_stop_serial";
		this.Button_start_stop_serial.UseVisualStyleBackColor = false;
		this.Button_start_stop_serial.Click += new System.EventHandler(Button_start_stop_serial_Click);
		resources.ApplyResources(this.ComboBox_select_data, "ComboBox_select_data");
		this.ComboBox_select_data.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.ComboBox_select_data.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.ComboBox_select_data.DM_UseCustomBackColor = true;
		this.ComboBox_select_data.DM_UseCustomForeColor = true;
		this.ComboBox_select_data.DM_UseSelectable = true;
		this.ComboBox_select_data.ForeColor = System.Drawing.Color.White;
		this.ComboBox_select_data.FormattingEnabled = true;
		this.ComboBox_select_data.Items.AddRange(new object[6]
		{
			resources.GetString("ComboBox_select_data.Items"),
			resources.GetString("ComboBox_select_data.Items1"),
			resources.GetString("ComboBox_select_data.Items2"),
			resources.GetString("ComboBox_select_data.Items3"),
			resources.GetString("ComboBox_select_data.Items4"),
			resources.GetString("ComboBox_select_data.Items5")
		});
		this.ComboBox_select_data.Name = "ComboBox_select_data";
		this.ComboBox_select_data.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.ComboBox_select_data.SelectedIndexChanged += new System.EventHandler(ComboBox_select_data_SelectedIndexChanged);
		this.ComboBox_select_data.Click += new System.EventHandler(ComboBox_select_data_Click);
		resources.ApplyResources(this.button_showdatagride_serial, "button_showdatagride_serial");
		this.button_showdatagride_serial.BackColor = System.Drawing.Color.CornflowerBlue;
		this.button_showdatagride_serial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
		this.button_showdatagride_serial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(134, 190, 236);
		this.button_showdatagride_serial.Name = "button_showdatagride_serial";
		this.button_showdatagride_serial.UseVisualStyleBackColor = false;
		this.button_showdatagride_serial.Click += new System.EventHandler(button_showdatagride_serial_Click);
		this.DataGride_readtime_serial.AllowUserToResizeRows = false;
		resources.ApplyResources(this.DataGride_readtime_serial, "DataGride_readtime_serial");
		this.DataGride_readtime_serial.BackgroundColor = System.Drawing.Color.FromArgb(0, 99, 172);
		this.DataGride_readtime_serial.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.DataGride_readtime_serial.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedVertical;
		this.DataGride_readtime_serial.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
		dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(0, 84, 143);
		dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
		dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
		dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(0, 174, 219);
		dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
		dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.DataGride_readtime_serial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
		this.DataGride_readtime_serial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
		this.DataGride_readtime_serial.Columns.AddRange(this.dataGridViewTextBoxColumn1, this.dataGridViewTextBoxColumn2, this.dataGridViewTextBoxColumn3, this.dataGridViewTextBoxColumn4, this.dataGridViewTextBoxColumn5);
		dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(255, 255, 255);
		dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
		dataGridViewCellStyle7.ForeColor = System.Drawing.Color.FromArgb(136, 136, 136);
		dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(0, 174, 219);
		dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
		dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
		this.DataGride_readtime_serial.DefaultCellStyle = dataGridViewCellStyle7;
		this.DataGride_readtime_serial.DM_UseCustomBackColor = true;
		this.DataGride_readtime_serial.DM_UseCustomForeColor = true;
		this.DataGride_readtime_serial.EnableHeadersVisualStyles = false;
		this.DataGride_readtime_serial.GridColor = System.Drawing.Color.FromArgb(0, 84, 143);
		this.DataGride_readtime_serial.Name = "DataGride_readtime_serial";
		this.DataGride_readtime_serial.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
		dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
		dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(0, 174, 219);
		dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 11f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
		dataGridViewCellStyle8.ForeColor = System.Drawing.Color.FromArgb(255, 255, 255);
		dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.FromArgb(0, 174, 219);
		dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.FromArgb(17, 17, 17);
		dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
		this.DataGride_readtime_serial.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
		this.DataGride_readtime_serial.RowHeadersVisible = false;
		this.DataGride_readtime_serial.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
		this.DataGride_readtime_serial.RowTemplate.Height = 23;
		this.DataGride_readtime_serial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
		this.DataGride_readtime_serial.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(DataGride_readtime_serial_RowEnter);
		this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(0, 99, 172);
		dataGridViewCellStyle9.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle9.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle9;
		this.dataGridViewTextBoxColumn1.FillWeight = 10f;
		resources.ApplyResources(this.dataGridViewTextBoxColumn1, "dataGridViewTextBoxColumn1");
		this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
		this.dataGridViewTextBoxColumn1.ReadOnly = true;
		this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(0, 99, 172);
		dataGridViewCellStyle10.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle10.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle10;
		this.dataGridViewTextBoxColumn2.FillWeight = 20f;
		resources.ApplyResources(this.dataGridViewTextBoxColumn2, "dataGridViewTextBoxColumn2");
		this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
		this.dataGridViewTextBoxColumn2.ReadOnly = true;
		this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(0, 99, 172);
		dataGridViewCellStyle11.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle11.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn3.DefaultCellStyle = dataGridViewCellStyle11;
		this.dataGridViewTextBoxColumn3.FillWeight = 20f;
		resources.ApplyResources(this.dataGridViewTextBoxColumn3, "dataGridViewTextBoxColumn3");
		this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
		this.dataGridViewTextBoxColumn3.ReadOnly = true;
		this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(0, 99, 172);
		dataGridViewCellStyle12.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle12.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn4.DefaultCellStyle = dataGridViewCellStyle12;
		this.dataGridViewTextBoxColumn4.FillWeight = 20f;
		resources.ApplyResources(this.dataGridViewTextBoxColumn4, "dataGridViewTextBoxColumn4");
		this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
		this.dataGridViewTextBoxColumn4.ReadOnly = true;
		this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
		dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(0, 99, 172);
		dataGridViewCellStyle13.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		dataGridViewCellStyle13.ForeColor = System.Drawing.Color.White;
		this.dataGridViewTextBoxColumn5.DefaultCellStyle = dataGridViewCellStyle13;
		this.dataGridViewTextBoxColumn5.FillWeight = 30f;
		resources.ApplyResources(this.dataGridViewTextBoxColumn5, "dataGridViewTextBoxColumn5");
		this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
		this.dataGridViewTextBoxColumn5.ReadOnly = true;
		resources.ApplyResources(this.button_hidedatagride_serial, "button_hidedatagride_serial");
		this.button_hidedatagride_serial.BackColor = System.Drawing.Color.CornflowerBlue;
		this.button_hidedatagride_serial.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DeepSkyBlue;
		this.button_hidedatagride_serial.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(134, 190, 236);
		this.button_hidedatagride_serial.Name = "button_hidedatagride_serial";
		this.button_hidedatagride_serial.UseVisualStyleBackColor = false;
		this.button_hidedatagride_serial.Click += new System.EventHandler(button_hidedatagride_serial_Click);
		resources.ApplyResources(this.groupB, "groupB");
		this.groupB.Controls.Add(this.Bn);
		this.groupB.Controls.Add(this.Br);
		this.groupB.ForeColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.groupB.Name = "groupB";
		this.groupB.TabStop = false;
		resources.ApplyResources(this.Bn, "Bn");
		this.Bn.BackColor = System.Drawing.Color.Transparent;
		this.Bn.ForeColor = System.Drawing.Color.White;
		this.Bn.Name = "Bn";
		resources.ApplyResources(this.Br, "Br");
		this.Br.BackColor = System.Drawing.Color.Transparent;
		this.Br.ForeColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.Br.Name = "Br";
		resources.ApplyResources(this.groupX, "groupX");
		this.groupX.Controls.Add(this.Xn);
		this.groupX.Controls.Add(this.Xf);
		this.groupX.Controls.Add(this.Xr);
		this.groupX.Controls.Add(this.Xt);
		this.groupX.ForeColor = System.Drawing.Color.FromArgb(255, 192, 192);
		this.groupX.Name = "groupX";
		this.groupX.TabStop = false;
		resources.ApplyResources(this.Xn, "Xn");
		this.Xn.BackColor = System.Drawing.Color.Transparent;
		this.Xn.ForeColor = System.Drawing.Color.White;
		this.Xn.Name = "Xn";
		resources.ApplyResources(this.Xf, "Xf");
		this.Xf.ForeColor = System.Drawing.Color.White;
		this.Xf.Name = "Xf";
		resources.ApplyResources(this.Xr, "Xr");
		this.Xr.BackColor = System.Drawing.Color.Transparent;
		this.Xr.ForeColor = System.Drawing.Color.FromArgb(255, 192, 192);
		this.Xr.Name = "Xr";
		resources.ApplyResources(this.Xt, "Xt");
		this.Xt.BackColor = System.Drawing.Color.Transparent;
		this.Xt.ForeColor = System.Drawing.Color.White;
		this.Xt.Name = "Xt";
		resources.ApplyResources(this.groupZ, "groupZ");
		this.groupZ.Controls.Add(this.Zn);
		this.groupZ.Controls.Add(this.Zf);
		this.groupZ.Controls.Add(this.Zr);
		this.groupZ.Controls.Add(this.Zt);
		this.groupZ.ForeColor = System.Drawing.Color.FromArgb(192, 192, 255);
		this.groupZ.Name = "groupZ";
		this.groupZ.TabStop = false;
		resources.ApplyResources(this.Zn, "Zn");
		this.Zn.BackColor = System.Drawing.Color.Transparent;
		this.Zn.ForeColor = System.Drawing.Color.White;
		this.Zn.Name = "Zn";
		resources.ApplyResources(this.Zf, "Zf");
		this.Zf.ForeColor = System.Drawing.Color.White;
		this.Zf.Name = "Zf";
		resources.ApplyResources(this.Zr, "Zr");
		this.Zr.BackColor = System.Drawing.Color.Transparent;
		this.Zr.ForeColor = System.Drawing.Color.FromArgb(192, 192, 255);
		this.Zr.Name = "Zr";
		resources.ApplyResources(this.Zt, "Zt");
		this.Zt.BackColor = System.Drawing.Color.Transparent;
		this.Zt.ForeColor = System.Drawing.Color.White;
		this.Zt.Name = "Zt";
		resources.ApplyResources(this.groupY, "groupY");
		this.groupY.Controls.Add(this.Yn);
		this.groupY.Controls.Add(this.Yf);
		this.groupY.Controls.Add(this.Yr);
		this.groupY.Controls.Add(this.Yt);
		this.groupY.ForeColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.groupY.Name = "groupY";
		this.groupY.TabStop = false;
		resources.ApplyResources(this.Yn, "Yn");
		this.Yn.BackColor = System.Drawing.Color.Transparent;
		this.Yn.ForeColor = System.Drawing.Color.White;
		this.Yn.Name = "Yn";
		resources.ApplyResources(this.Yf, "Yf");
		this.Yf.ForeColor = System.Drawing.Color.White;
		this.Yf.Name = "Yf";
		resources.ApplyResources(this.Yr, "Yr");
		this.Yr.BackColor = System.Drawing.Color.Transparent;
		this.Yr.ForeColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.Yr.Name = "Yr";
		resources.ApplyResources(this.Yt, "Yt");
		this.Yt.BackColor = System.Drawing.Color.Transparent;
		this.Yt.ForeColor = System.Drawing.Color.White;
		this.Yt.Name = "Yt";
		resources.ApplyResources(this.zedGraphControl_realtime_serial, "zedGraphControl_realtime_serial");
		this.zedGraphControl_realtime_serial.Name = "zedGraphControl_realtime_serial";
		this.zedGraphControl_realtime_serial.ScrollGrace = 0.0;
		this.zedGraphControl_realtime_serial.ScrollMaxX = 0.0;
		this.zedGraphControl_realtime_serial.ScrollMaxY = 0.0;
		this.zedGraphControl_realtime_serial.ScrollMaxY2 = 0.0;
		this.zedGraphControl_realtime_serial.ScrollMinX = 0.0;
		this.zedGraphControl_realtime_serial.ScrollMinY = 0.0;
		this.zedGraphControl_realtime_serial.ScrollMinY2 = 0.0;
		this.tabPage3.BackColor = System.Drawing.Color.FromArgb(0, 84, 143);
		this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.tabPage3.Controls.Add(this.groupBox12);
		this.tabPage3.Controls.Add(this.groupBox9);
		this.tabPage3.Controls.Add(this.groupBox3);
		this.tabPage3.Controls.Add(this.groupBox2);
		this.tabPage3.Controls.Add(this.groupBox1);
		resources.ApplyResources(this.tabPage3, "tabPage3");
		this.tabPage3.Name = "tabPage3";
		this.groupBox12.Controls.Add(this.textBox_pipe_last_rec);
		this.groupBox12.Controls.Add(this.label28);
		this.groupBox12.Controls.Add(this.groupBox14);
		this.groupBox12.Controls.Add(this.label22);
		this.groupBox12.Controls.Add(this.Button_save_pipe_name);
		this.groupBox12.Controls.Add(this.dmButton3);
		this.groupBox12.Controls.Add(this.textBox_pipe_name);
		this.groupBox12.Controls.Add(this.groupBox13);
		this.groupBox12.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.groupBox12, "groupBox12");
		this.groupBox12.Name = "groupBox12";
		this.groupBox12.TabStop = false;
		this.textBox_pipe_last_rec.BackColor = System.Drawing.Color.Black;
		this.textBox_pipe_last_rec.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		resources.ApplyResources(this.textBox_pipe_last_rec, "textBox_pipe_last_rec");
		this.textBox_pipe_last_rec.ForeColor = System.Drawing.Color.Lime;
		this.textBox_pipe_last_rec.Name = "textBox_pipe_last_rec";
		this.textBox_pipe_last_rec.ReadOnly = true;
		resources.ApplyResources(this.label28, "label28");
		this.label28.Name = "label28";
		this.groupBox14.Controls.Add(this.label26);
		this.groupBox14.Controls.Add(this.label27);
		this.groupBox14.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.groupBox14, "groupBox14");
		this.groupBox14.Name = "groupBox14";
		this.groupBox14.TabStop = false;
		resources.ApplyResources(this.label26, "label26");
		this.label26.Name = "label26";
		resources.ApplyResources(this.label27, "label27");
		this.label27.Name = "label27";
		resources.ApplyResources(this.label22, "label22");
		this.label22.Name = "label22";
		resources.ApplyResources(this.Button_save_pipe_name, "Button_save_pipe_name");
		this.Button_save_pipe_name.BackColor = System.Drawing.Color.Transparent;
		this.Button_save_pipe_name.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_save_pipe_name.DM_DownColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.Button_save_pipe_name.DM_MoveColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.Button_save_pipe_name.DM_NormalColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.Button_save_pipe_name.DM_Radius = 5;
		this.Button_save_pipe_name.ForeColor = System.Drawing.Color.White;
		this.Button_save_pipe_name.Name = "Button_save_pipe_name";
		this.Button_save_pipe_name.UseVisualStyleBackColor = false;
		this.Button_save_pipe_name.Click += new System.EventHandler(Button_save_pipe_name_Click);
		resources.ApplyResources(this.dmButton3, "dmButton3");
		this.dmButton3.BackColor = System.Drawing.Color.Transparent;
		this.dmButton3.DM_DisabledColor = System.Drawing.Color.Empty;
		this.dmButton3.DM_DownColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.dmButton3.DM_MoveColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.dmButton3.DM_NormalColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.dmButton3.DM_Radius = 5;
		this.dmButton3.ForeColor = System.Drawing.Color.White;
		this.dmButton3.Name = "dmButton3";
		this.dmButton3.UseVisualStyleBackColor = false;
		this.dmButton3.Click += new System.EventHandler(dmButton3_Click);
		this.textBox_pipe_name.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.textBox_pipe_name.ContextMenuStrip = this.contextMenuStrip1;
		resources.ApplyResources(this.textBox_pipe_name, "textBox_pipe_name");
		this.textBox_pipe_name.Name = "textBox_pipe_name";
		this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(0, 84, 143);
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[14]
		{
			this.dATAToolStripMenuItem, this.dATACToolStripMenuItem, this.fAST20ToolStripMenuItem, this.fAST50ToolStripMenuItem, this.fAST100ToolStripMenuItem, this.fAST200ToolStripMenuItem, this.fAST300ToolStripMenuItem, this.zEROToolStripMenuItem, this.mODLEToolStripMenuItem, this.clearScreenToolStripMenuItem,
			this.clearInputToolStripMenuItem, this.clearAllToolStripMenuItem, this.dEBUGONToolStripMenuItem, this.dEBUGOFFToolStripMenuItem
		});
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.ShowImageMargin = false;
		resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
		this.dATAToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.dATAToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.dATAToolStripMenuItem.Name = "dATAToolStripMenuItem";
		resources.ApplyResources(this.dATAToolStripMenuItem, "dATAToolStripMenuItem");
		this.dATAToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.dATACToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.dATACToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(255, 128, 128);
		this.dATACToolStripMenuItem.Name = "dATACToolStripMenuItem";
		resources.ApplyResources(this.dATACToolStripMenuItem, "dATACToolStripMenuItem");
		this.dATACToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.fAST20ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.fAST20ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(192, 255, 255);
		this.fAST20ToolStripMenuItem.Name = "fAST20ToolStripMenuItem";
		resources.ApplyResources(this.fAST20ToolStripMenuItem, "fAST20ToolStripMenuItem");
		this.fAST20ToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.fAST50ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.fAST50ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(192, 192, 255);
		this.fAST50ToolStripMenuItem.Name = "fAST50ToolStripMenuItem";
		resources.ApplyResources(this.fAST50ToolStripMenuItem, "fAST50ToolStripMenuItem");
		this.fAST50ToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.fAST100ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.fAST100ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(128, 128, 255);
		this.fAST100ToolStripMenuItem.Name = "fAST100ToolStripMenuItem";
		resources.ApplyResources(this.fAST100ToolStripMenuItem, "fAST100ToolStripMenuItem");
		this.fAST100ToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.fAST200ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.fAST200ToolStripMenuItem.ForeColor = System.Drawing.Color.Blue;
		this.fAST200ToolStripMenuItem.Name = "fAST200ToolStripMenuItem";
		resources.ApplyResources(this.fAST200ToolStripMenuItem, "fAST200ToolStripMenuItem");
		this.fAST200ToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.fAST300ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.fAST300ToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(0, 0, 192);
		this.fAST300ToolStripMenuItem.Name = "fAST300ToolStripMenuItem";
		resources.ApplyResources(this.fAST300ToolStripMenuItem, "fAST300ToolStripMenuItem");
		this.fAST300ToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.zEROToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.zEROToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.zEROToolStripMenuItem.Name = "zEROToolStripMenuItem";
		resources.ApplyResources(this.zEROToolStripMenuItem, "zEROToolStripMenuItem");
		this.zEROToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.mODLEToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.mODLEToolStripMenuItem.ForeColor = System.Drawing.Color.White;
		this.mODLEToolStripMenuItem.Name = "mODLEToolStripMenuItem";
		resources.ApplyResources(this.mODLEToolStripMenuItem, "mODLEToolStripMenuItem");
		this.mODLEToolStripMenuItem.Click += new System.EventHandler(dATAToolStripMenuItem_Click);
		this.clearScreenToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.clearScreenToolStripMenuItem.ForeColor = System.Drawing.Color.White;
		this.clearScreenToolStripMenuItem.Name = "clearScreenToolStripMenuItem";
		resources.ApplyResources(this.clearScreenToolStripMenuItem, "clearScreenToolStripMenuItem");
		this.clearScreenToolStripMenuItem.Click += new System.EventHandler(clearScreenToolStripMenuItem_Click);
		this.clearInputToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
		this.clearInputToolStripMenuItem.ForeColor = System.Drawing.Color.White;
		this.clearInputToolStripMenuItem.Name = "clearInputToolStripMenuItem";
		resources.ApplyResources(this.clearInputToolStripMenuItem, "clearInputToolStripMenuItem");
		this.clearInputToolStripMenuItem.Click += new System.EventHandler(clearInputToolStripMenuItem_Click);
		this.clearAllToolStripMenuItem.ForeColor = System.Drawing.Color.White;
		this.clearAllToolStripMenuItem.Name = "clearAllToolStripMenuItem";
		resources.ApplyResources(this.clearAllToolStripMenuItem, "clearAllToolStripMenuItem");
		this.clearAllToolStripMenuItem.Click += new System.EventHandler(clearAllToolStripMenuItem_Click);
		this.dEBUGONToolStripMenuItem.Name = "dEBUGONToolStripMenuItem";
		resources.ApplyResources(this.dEBUGONToolStripMenuItem, "dEBUGONToolStripMenuItem");
		this.dEBUGONToolStripMenuItem.Click += new System.EventHandler(dEBUGONToolStripMenuItem_Click);
		this.dEBUGOFFToolStripMenuItem.Name = "dEBUGOFFToolStripMenuItem";
		resources.ApplyResources(this.dEBUGOFFToolStripMenuItem, "dEBUGOFFToolStripMenuItem");
		this.dEBUGOFFToolStripMenuItem.Click += new System.EventHandler(dEBUGOFFToolStripMenuItem_Click);
		this.groupBox13.Controls.Add(this.label25);
		this.groupBox13.Controls.Add(this.label24);
		this.groupBox13.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.groupBox13, "groupBox13");
		this.groupBox13.Name = "groupBox13";
		this.groupBox13.TabStop = false;
		resources.ApplyResources(this.label25, "label25");
		this.label25.Name = "label25";
		resources.ApplyResources(this.label24, "label24");
		this.label24.Name = "label24";
		this.groupBox9.Controls.Add(this.textBox_data_debug_send);
		this.groupBox9.Controls.Add(this.Button_data_debug_send);
		this.groupBox9.Controls.Add(this.textBox_data_debug_screen);
		this.groupBox9.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.groupBox9, "groupBox9");
		this.groupBox9.Name = "groupBox9";
		this.groupBox9.TabStop = false;
		this.textBox_data_debug_send.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.textBox_data_debug_send.ContextMenuStrip = this.contextMenuStrip2;
		resources.ApplyResources(this.textBox_data_debug_send, "textBox_data_debug_send");
		this.textBox_data_debug_send.Name = "textBox_data_debug_send";
		this.textBox_data_debug_send.KeyPress += new System.Windows.Forms.KeyPressEventHandler(textBox_data_debug_send_KeyPress);
		this.contextMenuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.HexASCII转换ToolStripMenuItem });
		this.contextMenuStrip2.Name = "contextMenuStrip2";
		resources.ApplyResources(this.contextMenuStrip2, "contextMenuStrip2");
		this.HexASCII转换ToolStripMenuItem.Name = "HexASCII转换ToolStripMenuItem";
		resources.ApplyResources(this.HexASCII转换ToolStripMenuItem, "HexASCII转换ToolStripMenuItem");
		this.HexASCII转换ToolStripMenuItem.Click += new System.EventHandler(HexASCII转换ToolStripMenuItem_Click);
		resources.ApplyResources(this.Button_data_debug_send, "Button_data_debug_send");
		this.Button_data_debug_send.BackColor = System.Drawing.Color.Transparent;
		this.Button_data_debug_send.ContextMenuStrip = this.contextMenuStrip1;
		this.Button_data_debug_send.DM_DisabledColor = System.Drawing.Color.Empty;
		this.Button_data_debug_send.DM_DownColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.Button_data_debug_send.DM_MoveColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.Button_data_debug_send.DM_NormalColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.Button_data_debug_send.DM_Radius = 5;
		this.Button_data_debug_send.ForeColor = System.Drawing.Color.White;
		this.Button_data_debug_send.Name = "Button_data_debug_send";
		this.Button_data_debug_send.UseVisualStyleBackColor = false;
		this.Button_data_debug_send.Click += new System.EventHandler(Button_data_debug_send_Click);
		this.textBox_data_debug_screen.BackColor = System.Drawing.Color.Black;
		this.textBox_data_debug_screen.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.textBox_data_debug_screen.ContextMenuStrip = this.contextMenuStrip3;
		resources.ApplyResources(this.textBox_data_debug_screen, "textBox_data_debug_screen");
		this.textBox_data_debug_screen.ForeColor = System.Drawing.Color.Lime;
		this.textBox_data_debug_screen.Name = "textBox_data_debug_screen";
		this.textBox_data_debug_screen.ReadOnly = true;
		this.contextMenuStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[1] { this.hexadecimalASCIIToolStripMenuItem });
		this.contextMenuStrip3.Name = "contextMenuStrip3";
		resources.ApplyResources(this.contextMenuStrip3, "contextMenuStrip3");
		this.hexadecimalASCIIToolStripMenuItem.Name = "hexadecimalASCIIToolStripMenuItem";
		resources.ApplyResources(this.hexadecimalASCIIToolStripMenuItem, "hexadecimalASCIIToolStripMenuItem");
		this.hexadecimalASCIIToolStripMenuItem.Click += new System.EventHandler(hexadecimalASCIIToolStripMenuItem_Click);
		resources.ApplyResources(this.groupBox3, "groupBox3");
		this.groupBox3.Controls.Add(this.groupBox_SaveDataTime);
		this.groupBox3.Controls.Add(this.dmButton4);
		this.groupBox3.Controls.Add(this.checkBox_data_debug);
		this.groupBox3.Controls.Add(this.gpb_lamp);
		this.groupBox3.Controls.Add(this.groupBox4);
		this.groupBox3.ForeColor = System.Drawing.Color.White;
		this.groupBox3.Name = "groupBox3";
		this.groupBox3.TabStop = false;
		resources.ApplyResources(this.checkBox_SaveDataTime, "checkBox_SaveDataTime");
		this.checkBox_SaveDataTime.Name = "checkBox_SaveDataTime";
		this.checkBox_SaveDataTime.UseVisualStyleBackColor = true;
		this.checkBox_SaveDataTime.CheckedChanged += new System.EventHandler(checkBox_SaveDataTime_CheckedChanged);
		this.groupBox_SaveDataTime.Controls.Add(this.checkBox_SaveDataTime);
		this.groupBox_SaveDataTime.Controls.Add(this.numericUp_SaveDataTime);
		this.groupBox_SaveDataTime.Controls.Add(this.label29);
		resources.ApplyResources(this.groupBox_SaveDataTime, "groupBox_SaveDataTime");
		this.groupBox_SaveDataTime.ForeColor = System.Drawing.Color.White;
		this.groupBox_SaveDataTime.Name = "groupBox_SaveDataTime";
		this.groupBox_SaveDataTime.TabStop = false;
		this.numericUp_SaveDataTime.DecimalPlaces = 1;
		resources.ApplyResources(this.numericUp_SaveDataTime, "numericUp_SaveDataTime");
		this.numericUp_SaveDataTime.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.numericUp_SaveDataTime.Minimum = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.numericUp_SaveDataTime.Name = "numericUp_SaveDataTime";
		this.numericUp_SaveDataTime.Value = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.numericUp_SaveDataTime.ValueChanged += new System.EventHandler(numericUp_SaveDataTime_ValueChanged);
		this.label29.AutoEllipsis = true;
		resources.ApplyResources(this.label29, "label29");
		this.label29.Name = "label29";
		this.dmButton4.BackColor = System.Drawing.Color.Transparent;
		this.dmButton4.DM_DisabledColor = System.Drawing.Color.Empty;
		this.dmButton4.DM_DownColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.dmButton4.DM_MoveColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.dmButton4.DM_NormalColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.dmButton4.DM_Radius = 5;
		resources.ApplyResources(this.dmButton4, "dmButton4");
		this.dmButton4.ForeColor = System.Drawing.Color.White;
		this.dmButton4.Name = "dmButton4";
		this.dmButton4.UseVisualStyleBackColor = false;
		this.dmButton4.Click += new System.EventHandler(dmButton4_Click);
		resources.ApplyResources(this.checkBox_data_debug, "checkBox_data_debug");
		this.checkBox_data_debug.ForeColor = System.Drawing.Color.White;
		this.checkBox_data_debug.Name = "checkBox_data_debug";
		this.checkBox_data_debug.UseVisualStyleBackColor = true;
		this.checkBox_data_debug.CheckedChanged += new System.EventHandler(checkBox_data_debug_CheckedChanged);
		this.groupBox4.Controls.Add(this.checkBox_send_out_with);
		this.groupBox4.Controls.Add(this.checkBox_send_out);
		resources.ApplyResources(this.groupBox4, "groupBox4");
		this.groupBox4.ForeColor = System.Drawing.Color.White;
		this.groupBox4.Name = "groupBox4";
		this.groupBox4.TabStop = false;
		resources.ApplyResources(this.checkBox_send_out_with, "checkBox_send_out_with");
		this.checkBox_send_out_with.ForeColor = System.Drawing.Color.White;
		this.checkBox_send_out_with.Name = "checkBox_send_out_with";
		this.checkBox_send_out_with.UseVisualStyleBackColor = true;
		this.checkBox_send_out_with.CheckedChanged += new System.EventHandler(checkBox_send_out_with_CheckedChanged);
		resources.ApplyResources(this.checkBox_send_out, "checkBox_send_out");
		this.checkBox_send_out.ForeColor = System.Drawing.Color.White;
		this.checkBox_send_out.Name = "checkBox_send_out";
		this.checkBox_send_out.UseVisualStyleBackColor = true;
		this.checkBox_send_out.CheckedChanged += new System.EventHandler(checkBox_send_out_CheckedChanged);
		resources.ApplyResources(this.groupBox2, "groupBox2");
		this.groupBox2.Controls.Add(this.checkBox_clear_after_export);
		this.groupBox2.Controls.Add(this.groupBox11);
		this.groupBox2.Controls.Add(this.groupBox6);
		this.groupBox2.Controls.Add(this.checkBox_always_reading);
		this.groupBox2.Controls.Add(this.checkBox_show_normal);
		this.groupBox2.ForeColor = System.Drawing.Color.White;
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.TabStop = false;
		resources.ApplyResources(this.checkBox_clear_after_export, "checkBox_clear_after_export");
		this.checkBox_clear_after_export.ForeColor = System.Drawing.Color.White;
		this.checkBox_clear_after_export.Name = "checkBox_clear_after_export";
		this.checkBox_clear_after_export.UseVisualStyleBackColor = true;
		this.checkBox_clear_after_export.CheckedChanged += new System.EventHandler(checkBox_clear_after_export_CheckedChanged);
		this.groupBox11.Controls.Add(this.label17);
		this.groupBox11.Controls.Add(this.ComboBox_unit);
		this.groupBox11.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.groupBox11, "groupBox11");
		this.groupBox11.Name = "groupBox11";
		this.groupBox11.TabStop = false;
		this.label17.AutoEllipsis = true;
		resources.ApplyResources(this.label17, "label17");
		this.label17.Name = "label17";
		resources.ApplyResources(this.ComboBox_unit, "ComboBox_unit");
		this.ComboBox_unit.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.ComboBox_unit.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.ComboBox_unit.DM_UseCustomBackColor = true;
		this.ComboBox_unit.DM_UseCustomForeColor = true;
		this.ComboBox_unit.DM_UseSelectable = true;
		this.ComboBox_unit.ForeColor = System.Drawing.Color.White;
		this.ComboBox_unit.FormattingEnabled = true;
		this.ComboBox_unit.Items.AddRange(new object[5]
		{
			resources.GetString("ComboBox_unit.Items"),
			resources.GetString("ComboBox_unit.Items1"),
			resources.GetString("ComboBox_unit.Items2"),
			resources.GetString("ComboBox_unit.Items3"),
			resources.GetString("ComboBox_unit.Items4")
		});
		this.ComboBox_unit.Name = "ComboBox_unit";
		this.ComboBox_unit.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.ComboBox_unit.SelectedIndexChanged += new System.EventHandler(ComboBox_unit_SelectedIndexChanged);
		this.groupBox6.Controls.Add(this.dmButton1);
		this.groupBox6.Controls.Add(this.checkBox_save_to_file);
		this.groupBox6.Controls.Add(this.groupBox7);
		this.groupBox6.Controls.Add(this.label8);
		resources.ApplyResources(this.groupBox6, "groupBox6");
		this.groupBox6.ForeColor = System.Drawing.Color.White;
		this.groupBox6.Name = "groupBox6";
		this.groupBox6.TabStop = false;
		resources.ApplyResources(this.dmButton1, "dmButton1");
		this.dmButton1.BackColor = System.Drawing.Color.Transparent;
		this.dmButton1.DM_DisabledColor = System.Drawing.Color.Empty;
		this.dmButton1.DM_DownColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.dmButton1.DM_MoveColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.dmButton1.DM_NormalColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.dmButton1.DM_Radius = 5;
		this.dmButton1.ForeColor = System.Drawing.Color.White;
		this.dmButton1.Name = "dmButton1";
		this.dmButton1.UseVisualStyleBackColor = false;
		this.dmButton1.Click += new System.EventHandler(dmButton1_Click_1);
		resources.ApplyResources(this.checkBox_save_to_file, "checkBox_save_to_file");
		this.checkBox_save_to_file.Name = "checkBox_save_to_file";
		this.checkBox_save_to_file.UseVisualStyleBackColor = true;
		this.checkBox_save_to_file.CheckedChanged += new System.EventHandler(checkBox_save_to_file_CheckedChanged);
		this.groupBox7.Controls.Add(this.ComboBox_STFReachMaximum);
		this.groupBox7.Controls.Add(this.label14);
		this.groupBox7.Controls.Add(this.numeric_STFDataMaximum);
		this.groupBox7.Controls.Add(this.label13);
		resources.ApplyResources(this.groupBox7, "groupBox7");
		this.groupBox7.Name = "groupBox7";
		this.groupBox7.TabStop = false;
		resources.ApplyResources(this.ComboBox_STFReachMaximum, "ComboBox_STFReachMaximum");
		this.ComboBox_STFReachMaximum.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.ComboBox_STFReachMaximum.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.ComboBox_STFReachMaximum.DM_UseCustomBackColor = true;
		this.ComboBox_STFReachMaximum.DM_UseCustomForeColor = true;
		this.ComboBox_STFReachMaximum.DM_UseSelectable = true;
		this.ComboBox_STFReachMaximum.ForeColor = System.Drawing.Color.White;
		this.ComboBox_STFReachMaximum.FormattingEnabled = true;
		this.ComboBox_STFReachMaximum.Items.AddRange(new object[2]
		{
			resources.GetString("ComboBox_STFReachMaximum.Items"),
			resources.GetString("ComboBox_STFReachMaximum.Items1")
		});
		this.ComboBox_STFReachMaximum.Name = "ComboBox_STFReachMaximum";
		this.ComboBox_STFReachMaximum.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.ComboBox_STFReachMaximum.SelectedIndexChanged += new System.EventHandler(ComboBox_STFReachMaximum_SelectedIndexChanged);
		resources.ApplyResources(this.label14, "label14");
		this.label14.Name = "label14";
		this.numeric_STFDataMaximum.Increment = new decimal(new int[4] { 100, 0, 0, 0 });
		resources.ApplyResources(this.numeric_STFDataMaximum, "numeric_STFDataMaximum");
		this.numeric_STFDataMaximum.Maximum = new decimal(new int[4] { 100000, 0, 0, 0 });
		this.numeric_STFDataMaximum.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.numeric_STFDataMaximum.Name = "numeric_STFDataMaximum";
		this.numeric_STFDataMaximum.Value = new decimal(new int[4] { 100, 0, 0, 0 });
		this.numeric_STFDataMaximum.ValueChanged += new System.EventHandler(numeric_STFDataMaximum_ValueChanged);
		resources.ApplyResources(this.label13, "label13");
		this.label13.Name = "label13";
		this.label8.AutoEllipsis = true;
		resources.ApplyResources(this.label8, "label8");
		this.label8.Name = "label8";
		resources.ApplyResources(this.checkBox_always_reading, "checkBox_always_reading");
		this.checkBox_always_reading.ForeColor = System.Drawing.Color.White;
		this.checkBox_always_reading.Name = "checkBox_always_reading";
		this.checkBox_always_reading.UseVisualStyleBackColor = true;
		this.checkBox_always_reading.CheckedChanged += new System.EventHandler(checkBox_always_reading_CheckedChanged);
		resources.ApplyResources(this.checkBox_show_normal, "checkBox_show_normal");
		this.checkBox_show_normal.ForeColor = System.Drawing.Color.White;
		this.checkBox_show_normal.Name = "checkBox_show_normal";
		this.checkBox_show_normal.UseVisualStyleBackColor = true;
		this.checkBox_show_normal.CheckedChanged += new System.EventHandler(checkBox1_CheckedChanged);
		resources.ApplyResources(this.groupBox1, "groupBox1");
		this.groupBox1.Controls.Add(this.label20);
		this.groupBox1.Controls.Add(this.groupBox10);
		this.groupBox1.Controls.Add(this.groupBox5);
		this.groupBox1.Controls.Add(this.label5);
		this.groupBox1.Controls.Add(this.numeric_refresh_time);
		this.groupBox1.Controls.Add(this.checkBox_show_last_row);
		this.groupBox1.Controls.Add(this.checkBox_clear_ram);
		this.groupBox1.ForeColor = System.Drawing.Color.White;
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.TabStop = false;
		resources.ApplyResources(this.label20, "label20");
		this.label20.Name = "label20";
		this.groupBox10.Controls.Add(this.label_curve_length);
		this.groupBox10.Controls.Add(this.trackBar_curve_length);
		this.groupBox10.Controls.Add(this.label16);
		this.groupBox10.Controls.Add(this.dmButton2);
		this.groupBox10.Controls.Add(this.label23);
		this.groupBox10.Controls.Add(this.label_ch4_color);
		this.groupBox10.Controls.Add(this.label21);
		this.groupBox10.Controls.Add(this.label_ch3_color);
		this.groupBox10.Controls.Add(this.label19);
		this.groupBox10.Controls.Add(this.label_ch2_color);
		this.groupBox10.Controls.Add(this.label18);
		this.groupBox10.Controls.Add(this.label_ch1_color);
		this.groupBox10.Controls.Add(this.label15);
		this.groupBox10.Controls.Add(this.numericUp_graph_scale);
		this.groupBox10.Controls.Add(this.label12);
		this.groupBox10.ForeColor = System.Drawing.Color.White;
		resources.ApplyResources(this.groupBox10, "groupBox10");
		this.groupBox10.Name = "groupBox10";
		this.groupBox10.TabStop = false;
		resources.ApplyResources(this.label_curve_length, "label_curve_length");
		this.label_curve_length.Name = "label_curve_length";
		resources.ApplyResources(this.trackBar_curve_length, "trackBar_curve_length");
		this.trackBar_curve_length.Minimum = 1;
		this.trackBar_curve_length.Name = "trackBar_curve_length";
		this.trackBar_curve_length.Value = 1;
		this.trackBar_curve_length.Scroll += new System.EventHandler(trackBar_curve_length_Scroll);
		resources.ApplyResources(this.label16, "label16");
		this.label16.Name = "label16";
		resources.ApplyResources(this.dmButton2, "dmButton2");
		this.dmButton2.BackColor = System.Drawing.Color.Transparent;
		this.dmButton2.DM_DisabledColor = System.Drawing.Color.Empty;
		this.dmButton2.DM_DownColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.dmButton2.DM_MoveColor = System.Drawing.Color.FromArgb(255, 224, 192);
		this.dmButton2.DM_NormalColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.dmButton2.DM_Radius = 5;
		this.dmButton2.ForeColor = System.Drawing.Color.White;
		this.dmButton2.Name = "dmButton2";
		this.dmButton2.UseVisualStyleBackColor = false;
		this.dmButton2.Click += new System.EventHandler(dmButton2_Click);
		resources.ApplyResources(this.label23, "label23");
		this.label23.Name = "label23";
		this.label_ch4_color.BackColor = System.Drawing.Color.FromArgb(255, 192, 128);
		this.label_ch4_color.Cursor = System.Windows.Forms.Cursors.Hand;
		resources.ApplyResources(this.label_ch4_color, "label_ch4_color");
		this.label_ch4_color.Name = "label_ch4_color";
		this.label_ch4_color.BackColorChanged += new System.EventHandler(label_ch4_color_BackColorChanged);
		this.label_ch4_color.Click += new System.EventHandler(label_ch4_color_Click);
		resources.ApplyResources(this.label21, "label21");
		this.label21.Name = "label21";
		this.label_ch3_color.BackColor = System.Drawing.Color.FromArgb(192, 192, 255);
		this.label_ch3_color.Cursor = System.Windows.Forms.Cursors.Hand;
		resources.ApplyResources(this.label_ch3_color, "label_ch3_color");
		this.label_ch3_color.Name = "label_ch3_color";
		this.label_ch3_color.BackColorChanged += new System.EventHandler(label_ch3_color_BackColorChanged);
		this.label_ch3_color.Click += new System.EventHandler(label_ch3_color_Click);
		resources.ApplyResources(this.label19, "label19");
		this.label19.Name = "label19";
		this.label_ch2_color.BackColor = System.Drawing.Color.FromArgb(192, 255, 192);
		this.label_ch2_color.Cursor = System.Windows.Forms.Cursors.Hand;
		resources.ApplyResources(this.label_ch2_color, "label_ch2_color");
		this.label_ch2_color.Name = "label_ch2_color";
		this.label_ch2_color.BackColorChanged += new System.EventHandler(label_ch2_color_BackColorChanged);
		this.label_ch2_color.Click += new System.EventHandler(label_ch2_color_Click);
		resources.ApplyResources(this.label18, "label18");
		this.label18.Name = "label18";
		this.label_ch1_color.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
		this.label_ch1_color.Cursor = System.Windows.Forms.Cursors.Hand;
		resources.ApplyResources(this.label_ch1_color, "label_ch1_color");
		this.label_ch1_color.Name = "label_ch1_color";
		this.label_ch1_color.BackColorChanged += new System.EventHandler(label_ch1_color_BackColorChanged);
		this.label_ch1_color.Click += new System.EventHandler(label_ch1_color_Click);
		resources.ApplyResources(this.label15, "label15");
		this.label15.Name = "label15";
		resources.ApplyResources(this.numericUp_graph_scale, "numericUp_graph_scale");
		this.numericUp_graph_scale.Increment = new decimal(new int[4] { 100, 0, 0, 0 });
		this.numericUp_graph_scale.Maximum = new decimal(new int[4] { 2147483647, 0, 0, 0 });
		this.numericUp_graph_scale.Minimum = new decimal(new int[4] { 200, 0, 0, 0 });
		this.numericUp_graph_scale.Name = "numericUp_graph_scale";
		this.numericUp_graph_scale.Value = new decimal(new int[4] { 200, 0, 0, 0 });
		this.numericUp_graph_scale.ValueChanged += new System.EventHandler(numericUp_graph_scale_ValueChanged);
		resources.ApplyResources(this.label12, "label12");
		this.label12.Name = "label12";
		this.groupBox5.Controls.Add(this.label11);
		this.groupBox5.Controls.Add(this.label10);
		this.groupBox5.Controls.Add(this.numeric_judge_down);
		this.groupBox5.Controls.Add(this.numeric_judge_up);
		this.groupBox5.Controls.Add(this.label9);
		this.groupBox5.Controls.Add(this.ComboBox_judge_type);
		this.groupBox5.Controls.Add(this.cbx_ABS);
		this.groupBox5.Controls.Add(this.checkBox_judge);
		this.groupBox5.Controls.Add(this.label6);
		resources.ApplyResources(this.groupBox5, "groupBox5");
		this.groupBox5.ForeColor = System.Drawing.Color.White;
		this.groupBox5.Name = "groupBox5";
		this.groupBox5.TabStop = false;
		resources.ApplyResources(this.label11, "label11");
		this.label11.Name = "label11";
		resources.ApplyResources(this.label10, "label10");
		this.label10.Name = "label10";
		this.numeric_judge_down.DecimalPlaces = 3;
		resources.ApplyResources(this.numeric_judge_down, "numeric_judge_down");
		this.numeric_judge_down.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
		this.numeric_judge_down.Minimum = new decimal(new int[4] { 1410065407, 2, 0, -2147483648 });
		this.numeric_judge_down.Name = "numeric_judge_down";
		this.numeric_judge_down.Value = new decimal(new int[4] { 1, 0, 0, -2147483648 });
		this.numeric_judge_down.ValueChanged += new System.EventHandler(numeric_judge_down_ValueChanged);
		this.numeric_judge_up.DecimalPlaces = 3;
		resources.ApplyResources(this.numeric_judge_up, "numeric_judge_up");
		this.numeric_judge_up.Maximum = new decimal(new int[4] { 1410065407, 2, 0, 0 });
		this.numeric_judge_up.Minimum = new decimal(new int[4] { 1410065407, 2, 0, -2147483648 });
		this.numeric_judge_up.Name = "numeric_judge_up";
		this.numeric_judge_up.Value = new decimal(new int[4] { 1, 0, 0, 0 });
		this.numeric_judge_up.ValueChanged += new System.EventHandler(numeric_judge_up_ValueChanged);
		resources.ApplyResources(this.label9, "label9");
		this.label9.Name = "label9";
		resources.ApplyResources(this.ComboBox_judge_type, "ComboBox_judge_type");
		this.ComboBox_judge_type.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.ComboBox_judge_type.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.ComboBox_judge_type.DM_UseCustomBackColor = true;
		this.ComboBox_judge_type.DM_UseCustomForeColor = true;
		this.ComboBox_judge_type.DM_UseSelectable = true;
		this.ComboBox_judge_type.ForeColor = System.Drawing.Color.White;
		this.ComboBox_judge_type.FormattingEnabled = true;
		this.ComboBox_judge_type.Items.AddRange(new object[2]
		{
			resources.GetString("ComboBox_judge_type.Items"),
			resources.GetString("ComboBox_judge_type.Items1")
		});
		this.ComboBox_judge_type.Name = "ComboBox_judge_type";
		this.ComboBox_judge_type.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.ComboBox_judge_type.SelectedIndexChanged += new System.EventHandler(ComboBox_judge_type_SelectedIndexChanged);
		resources.ApplyResources(this.checkBox_judge, "checkBox_judge");
		this.checkBox_judge.Name = "checkBox_judge";
		this.checkBox_judge.UseVisualStyleBackColor = true;
		this.checkBox_judge.CheckedChanged += new System.EventHandler(checkBox_judge_CheckedChanged);
		this.label6.AutoEllipsis = true;
		resources.ApplyResources(this.label6, "label6");
		this.label6.Name = "label6";
		resources.ApplyResources(this.label5, "label5");
		this.label5.Name = "label5";
		this.numeric_refresh_time.DecimalPlaces = 1;
		resources.ApplyResources(this.numeric_refresh_time, "numeric_refresh_time");
		this.numeric_refresh_time.Maximum = new decimal(new int[4] { 10, 0, 0, 0 });
		this.numeric_refresh_time.Minimum = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.numeric_refresh_time.Name = "numeric_refresh_time";
		this.numeric_refresh_time.Value = new decimal(new int[4] { 1, 0, 0, 65536 });
		this.numeric_refresh_time.ValueChanged += new System.EventHandler(numericUpDown1_ValueChanged);
		resources.ApplyResources(this.checkBox_show_last_row, "checkBox_show_last_row");
		this.checkBox_show_last_row.ForeColor = System.Drawing.Color.White;
		this.checkBox_show_last_row.Name = "checkBox_show_last_row";
		this.checkBox_show_last_row.UseVisualStyleBackColor = true;
		this.checkBox_show_last_row.CheckedChanged += new System.EventHandler(checkBox_show_last_row_CheckedChanged);
		resources.ApplyResources(this.checkBox_clear_ram, "checkBox_clear_ram");
		this.checkBox_clear_ram.ForeColor = System.Drawing.Color.White;
		this.checkBox_clear_ram.Name = "checkBox_clear_ram";
		this.checkBox_clear_ram.UseVisualStyleBackColor = true;
		this.checkBox_clear_ram.CheckedChanged += new System.EventHandler(checkBox_clear_ram_CheckedChanged);
		resources.ApplyResources(this.label1, "label1");
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Name = "label1";
		resources.ApplyResources(this.label2, "label2");
		this.label2.ForeColor = System.Drawing.Color.SandyBrown;
		this.label2.Name = "label2";
		this.timer_ui.Enabled = true;
		this.timer_ui.Interval = 200;
		this.timer_ui.Tick += new System.EventHandler(timer_ui_Tick);
		this.openFileDialog.FileName = "openFileDialog1";
		this.dataSet1.DataSetName = "NewDataSet";
		this.dataSet1.Tables.AddRange(new System.Data.DataTable[1] { this.dt });
		this.dt.Columns.AddRange(new System.Data.DataColumn[4] { this.dataColumn1, this.dataColumn2, this.dataColumn3, this.dataColumn4 });
		this.dt.TableName = "historytable";
		this.dataColumn1.ColumnName = "No.";
		this.dataColumn2.ColumnName = "CH1";
		this.dataColumn3.ColumnName = "CH2";
		this.dataColumn4.ColumnName = "CH3";
		this.saveFileDialog1.RestoreDirectory = true;
		this.timer_display_pipe_notice.Tick += new System.EventHandler(timer_display_pipe_notice_Tick);
		this.timerGuaid.Interval = 1000;
		this.timerGuaid.Tick += new System.EventHandler(timerGuaid_Tick);
		resources.ApplyResources(this.pictureBox1, "pictureBox1");
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.TabStop = false;
		this.timerSTF.Interval = 30000;
		this.timerSTF.Tick += new System.EventHandler(timerSTF_Tick);
		this.timer_SaveData.Tick += new System.EventHandler(timer_SaveData_Tick);
		resources.ApplyResources(this.cbx_ABS, "cbx_ABS");
		this.cbx_ABS.Name = "cbx_ABS";
		this.cbx_ABS.UseVisualStyleBackColor = true;
		this.cbx_ABS.CheckedChanged += new System.EventHandler(cbx_ABS_CheckedChanged);
		resources.ApplyResources(this.cbx_comAlarmLamp, "cbx_comAlarmLamp");
		this.cbx_comAlarmLamp.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		this.cbx_comAlarmLamp.DM_FontWeight = DMSkin.Metro.MetroComboBoxWeight.Light;
		this.cbx_comAlarmLamp.DM_UseCustomBackColor = true;
		this.cbx_comAlarmLamp.DM_UseCustomForeColor = true;
		this.cbx_comAlarmLamp.DM_UseSelectable = true;
		this.cbx_comAlarmLamp.ForeColor = System.Drawing.Color.White;
		this.cbx_comAlarmLamp.FormattingEnabled = true;
		this.cbx_comAlarmLamp.Items.AddRange(new object[6]
		{
			resources.GetString("cbx_comAlarmLamp.Items"),
			resources.GetString("cbx_comAlarmLamp.Items1"),
			resources.GetString("cbx_comAlarmLamp.Items2"),
			resources.GetString("cbx_comAlarmLamp.Items3"),
			resources.GetString("cbx_comAlarmLamp.Items4"),
			resources.GetString("cbx_comAlarmLamp.Items5")
		});
		this.cbx_comAlarmLamp.Name = "cbx_comAlarmLamp";
		this.cbx_comAlarmLamp.Style = DMSkin.Metro.MetroColorStyle.Blue;
		this.cbx_comAlarmLamp.SelectedIndexChanged += new System.EventHandler(cbx_comAlarmLamp_SelectedIndexChanged);
		this.cbx_comAlarmLamp.Click += new System.EventHandler(cbx_comAlarmLamp_Click);
		this.gpb_lamp.Controls.Add(this.cbx_comAlarmLamp);
		resources.ApplyResources(this.gpb_lamp, "gpb_lamp");
		this.gpb_lamp.ForeColor = System.Drawing.Color.White;
		this.gpb_lamp.Name = "gpb_lamp";
		this.gpb_lamp.TabStop = false;
		resources.ApplyResources(this, "$this");
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(6, 104, 166);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox1);
		base.Controls.Add(this.dmTabControl1);
		base.DM_ShadowColor = System.Drawing.Color.FromArgb(111, 182, 208);
		base.DM_ShadowWidth = 2;
		base.DM_SystemButtonShowMax = true;
		base.DM_SystemDrawLine = true;
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "Form1";
		base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(Form1_FormClosing);
		base.Load += new System.EventHandler(Form1_Load);
		this.dmTabControl1.ResumeLayout(false);
		this.tabPage7.ResumeLayout(false);
		this.panel_datapanel_serial.ResumeLayout(false);
		this.panel_datapanel_serial.PerformLayout();
		this.groupBox8.ResumeLayout(false);
		this.groupBox_judge.ResumeLayout(false);
		((System.ComponentModel.ISupportInitialize)this.DataGride_readtime_serial).EndInit();
		this.groupB.ResumeLayout(false);
		this.groupB.PerformLayout();
		this.groupX.ResumeLayout(false);
		this.groupX.PerformLayout();
		this.groupZ.ResumeLayout(false);
		this.groupZ.PerformLayout();
		this.groupY.ResumeLayout(false);
		this.groupY.PerformLayout();
		this.tabPage3.ResumeLayout(false);
		this.groupBox12.ResumeLayout(false);
		this.groupBox12.PerformLayout();
		this.groupBox14.ResumeLayout(false);
		this.contextMenuStrip1.ResumeLayout(false);
		this.groupBox13.ResumeLayout(false);
		this.groupBox9.ResumeLayout(false);
		this.groupBox9.PerformLayout();
		this.contextMenuStrip2.ResumeLayout(false);
		this.contextMenuStrip3.ResumeLayout(false);
		this.groupBox3.ResumeLayout(false);
		this.groupBox3.PerformLayout();
		this.groupBox_SaveDataTime.ResumeLayout(false);
		this.groupBox_SaveDataTime.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numericUp_SaveDataTime).EndInit();
		this.groupBox4.ResumeLayout(false);
		this.groupBox4.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.groupBox11.ResumeLayout(false);
		this.groupBox6.ResumeLayout(false);
		this.groupBox6.PerformLayout();
		this.groupBox7.ResumeLayout(false);
		this.groupBox7.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numeric_STFDataMaximum).EndInit();
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox10.ResumeLayout(false);
		this.groupBox10.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.trackBar_curve_length).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numericUp_graph_scale).EndInit();
		this.groupBox5.ResumeLayout(false);
		this.groupBox5.PerformLayout();
		((System.ComponentModel.ISupportInitialize)this.numeric_judge_down).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numeric_judge_up).EndInit();
		((System.ComponentModel.ISupportInitialize)this.numeric_refresh_time).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dataSet1).EndInit();
		((System.ComponentModel.ISupportInitialize)this.dt).EndInit();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		this.gpb_lamp.ResumeLayout(false);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
