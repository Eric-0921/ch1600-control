using System.IO;
using System.IO.Ports;
using System.Text;
using System.Threading;
using System.Timers;

namespace DataReader2;

internal class SerialPort_Connect
{
	public delegate void Call_Back(string data, int data_size);

	private SerialPort Port = new SerialPort();

	private Thread thread;

	private bool DebugMode = false;

	private bool alwaysreading = false;

	private bool reading = false;

	private Stream stream;

	private StreamReader streamreader;

	private StringBuilder sb = new StringBuilder();

	private static AutoResetEvent key = new AutoResetEvent(initialState: false);

	private System.Timers.Timer timer = new System.Timers.Timer();

	private string CHstart = "DATA?>";

	private string CHfast = "FAST";

	private string CHstop = "DATAC>";

	private string UDAUstart = "START>";

	private string UDAUfast = "F";

	private string UDAUstop = "STOP>";

	private string Start = "DATA?>";

	private string Fast = "FAST";

	private string Stop = "DATAC>";

	private string tstr = null;

	public bool IsOpen => Port.IsOpen;

	public event Call_Back DataReady;

	public SerialPort_Connect()
	{
		Port.BaudRate = 115200;
		Port.ReadBufferSize = 40960;
		thread = new Thread(RecMethod);
		thread.IsBackground = true;
		thread.Start();
		timer.Interval = 200.0;
		timer.AutoReset = false;
		timer.Elapsed += delegate
		{
			if (!alwaysreading)
			{
				reading = false;
			}
		};
	}

	public SerialPort_Connect(string type)
	{
		Port.BaudRate = 115200;
		Port.ReadBufferSize = 40960;
		thread = new Thread(RecMethod);
		thread.IsBackground = true;
		thread.Start();
		timer.Interval = 200.0;
		timer.AutoReset = false;
		timer.Elapsed += delegate
		{
			if (!alwaysreading)
			{
				reading = false;
			}
		};
		if (type == "UDAU")
		{
			Start = UDAUstart;
			Fast = UDAUfast;
			Stop = UDAUstop;
		}
		else
		{
			Start = CHstart;
			Fast = CHfast;
			Stop = CHstop;
		}
	}

	private void RecMethod()
	{
		while (true)
		{
			bool flag = true;
			while (reading)
			{
				try
				{
					if (DebugMode)
					{
						tstr = Port.ReadExisting();
					}
					else
					{
						tstr = Port.ReadExisting();
					}
				}
				catch
				{
					continue;
				}
				if (this.DataReady != null && reading)
				{
					string[] s_temp = tstr.Split('\r', '\n');
					int i_temp = s_temp.Length;
					for (int i = 0; i < i_temp; i++)
					{
						this.DataReady(s_temp[i], s_temp[i].Length);
					}
				}
				Thread.Sleep(100);
			}
			key.WaitOne();
		}
	}

	public bool SetPortName(string name)
	{
		if (Port.IsOpen)
		{
			Port.Close();
		}
		Port.PortName = name;
		try
		{
			return Open();
		}
		catch
		{
			return false;
		}
	}

	public bool SetBaudRate(int baudrate)
	{
		if (Port.IsOpen)
		{
			Port.Close();
		}
		Port.BaudRate = baudrate;
		try
		{
			Port.Open();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool Open()
	{
		try
		{
			Port.Open();
			stream = Port.BaseStream;
			streamreader = new StreamReader(stream);
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool Close()
	{
		try
		{
			if (!alwaysreading)
			{
				reading = false;
			}
			if (Port.IsOpen)
			{
				Port.Write(Stop);
			}
			Thread.Sleep(50);
			Port.Close();
			return true;
		}
		catch
		{
			return false;
		}
	}

	public bool Write(string str)
	{
		if (!Port.IsOpen)
		{
			try
			{
				Port.Open();
				stream = Port.BaseStream;
				streamreader = new StreamReader(stream);
				stream.ReadTimeout = 5000;
			}
			catch
			{
				return false;
			}
			return false;
		}
		Port.Write(str);
		if (str.StartsWith(Start) || str.StartsWith(Fast))
		{
			Port.DiscardInBuffer();
			reading = true;
			key.Set();
		}
		if (str.StartsWith(Stop))
		{
			timer.Enabled = true;
		}
		return true;
	}

	public void KeepReading(bool keep, bool always)
	{
		if (keep)
		{
			Port.DiscardInBuffer();
			reading = true;
			key.Set();
		}
		else
		{
			reading = false;
			timer.Enabled = true;
		}
		alwaysreading = always;
	}

	public void SetDebugMode(bool Mode)
	{
		if (Mode)
		{
			DebugMode = Mode;
			reading = true;
			key.Set();
		}
		else
		{
			DebugMode = Mode;
			timer.Enabled = true;
		}
	}
}
