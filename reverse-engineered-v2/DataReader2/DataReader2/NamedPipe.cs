using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading;
using System.Timers;

namespace DataReader2;

public class NamedPipe
{
	public class NamedPipeClient
	{
		public delegate void MessageReceived(string message, int data_size);

		public delegate void StatusChange(string Status);

		private NamedPipeClientStream Pipe;

		private StreamWriter SW = null;

		private StreamReader SR = null;

		public string Status = "N/A";

		public string DataReceive = null;

		private string PipeName = null;

		private Thread Threadw;

		private Thread Threadr;

		public event MessageReceived MsgCallBack;

		public event StatusChange StatusCallBack;

		public NamedPipeClient(string pipe_name)
		{
			if (!(pipe_name == string.Empty))
			{
				PipeName = pipe_name;
			}
		}

		public void Connect()
		{
			Pipe = new NamedPipeClientStream("127.0.0.1", PipeName, PipeDirection.InOut, PipeOptions.Asynchronous, TokenImpersonationLevel.None);
			Threadw = new Thread((ThreadStart)delegate
			{
				if (this.StatusCallBack != null)
				{
					this.StatusCallBack("Connecting");
				}
				Status = "Connecting";
				try
				{
					Pipe.Connect(1000);
				}
				catch (Exception ex)
				{
					if (!(ex.GetType().ToString() == "System.IO.IOException"))
					{
					}
					return;
				}
				if (this.StatusCallBack != null)
				{
					this.StatusCallBack("Connected");
				}
				Status = "Connected";
				SW = new StreamWriter(Pipe);
				SW.AutoFlush = true;
				Threadr = new Thread((ThreadStart)delegate
				{
					SR = new StreamReader(Pipe);
					while (true)
					{
						try
						{
							DataReceive = SR.ReadLine();
						}
						catch
						{
							if (Status == "DisConnect")
							{
								break;
							}
						}
						if (!string.IsNullOrEmpty(DataReceive) && this.MsgCallBack != null)
						{
							this.MsgCallBack(DataReceive, DataReceive.Length);
						}
					}
				});
				Threadr.IsBackground = true;
				Threadr.Start();
			});
			Threadw.IsBackground = true;
			Threadw.Start();
			System.Timers.Timer timer = new System.Timers.Timer(1000.0);
			timer.Elapsed += delegate
			{
				if (Status == "Connecting")
				{
					if (this.StatusCallBack != null)
					{
						this.StatusCallBack("NotFound");
					}
					Status = "NotFound";
					try
					{
						Threadw.Abort();
					}
					catch
					{
					}
				}
			};
			timer.AutoReset = false;
			timer.Enabled = true;
		}

		public bool Send(string message)
		{
			if (message == string.Empty || !Pipe.IsConnected)
			{
				return false;
			}
			try
			{
				SW.WriteLine(message);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void ClearCallBack()
		{
			this.MsgCallBack = null;
		}

		public void Close()
		{
			if (Status == "Connected")
			{
				SW.WriteLine("_CLOSING");
				Pipe.Flush();
				SW.Close();
				SR.Close();
				Pipe.Close();
			}
			if (this.StatusCallBack != null)
			{
				this.StatusCallBack("DisConnect");
			}
			Status = "DisConnect";
		}

		public string GetMesssage()
		{
			return DataReceive;
		}
	}

	public class NamedPipeServer
	{
		public delegate void MessageReceived(string message, int data_size);

		public delegate void StatusChange(string Status);

		private string PipeName = null;

		private NamedPipeServerStream Pipe;

		private StreamWriter SW = null;

		private StreamReader SR = null;

		private string Status = "N/A";

		private bool StopFlag = false;

		public string DataReceive = null;

		public string Name
		{
			get
			{
				return PipeName;
			}
			set
			{
				if (value != null)
				{
					PipeName = value;
				}
			}
		}

		public event MessageReceived MsgCallBack;

		public event StatusChange StatusCallBack;

		public NamedPipeServer(string pipe_name)
		{
			PipeName = pipe_name;
			if (PipeName != null)
			{
				Pipe = new NamedPipeServerStream(PipeName, PipeDirection.InOut, 4, PipeTransmissionMode.Message, PipeOptions.Asynchronous);
			}
		}

		public void Start()
		{
			try
			{
				Pipe.Disconnect();
			}
			catch
			{
			}
			if (this.StatusCallBack != null)
			{
				this.StatusCallBack("Waitting");
			}
			Status = "Waitting";
			Pipe.BeginWaitForConnection(delegate(IAsyncResult arg)
			{
				NamedPipeServerStream namedPipeServerStream = (NamedPipeServerStream)arg.AsyncState;
				namedPipeServerStream.EndWaitForConnection(arg);
				if (this.StatusCallBack != null)
				{
					this.StatusCallBack("Conncted");
				}
				Status = "Conncted";
				SR = new StreamReader(namedPipeServerStream);
				SW = new StreamWriter(namedPipeServerStream);
				SW.AutoFlush = true;
				string impersonationUserName = namedPipeServerStream.GetImpersonationUserName();
				while (true)
				{
					try
					{
						DataReceive = SR.ReadLine();
					}
					catch
					{
					}
					if (DataReceive == "_CLOSING")
					{
						break;
					}
					if (this.MsgCallBack != null)
					{
						this.MsgCallBack(DataReceive, DataReceive.Length);
					}
				}
				if (Pipe.IsConnected)
				{
					Pipe.Disconnect();
				}
				if (StopFlag)
				{
					StopFlag = false;
				}
				else
				{
					if (this.StatusCallBack != null)
					{
						this.StatusCallBack("DisConnected");
					}
					Status = "DisConnected";
					System.Timers.Timer timer = new System.Timers.Timer(500.0);
					timer.Elapsed += delegate
					{
						Start();
					};
					timer.AutoReset = false;
					timer.Enabled = true;
				}
			}, Pipe);
		}

		public void Stop()
		{
			if (!(Status == "Waitting") && Pipe.IsConnected)
			{
				StopFlag = true;
				if (this.StatusCallBack != null)
				{
					this.StatusCallBack("DisConnected");
				}
				Status = "DisConnected";
				Pipe.Disconnect();
			}
		}

		public bool Send(string message)
		{
			if (message == string.Empty || !Pipe.IsConnected)
			{
				return false;
			}
			try
			{
				SW.WriteLine(message);
				return true;
			}
			catch
			{
				return false;
			}
		}

		public void ClearCallBack()
		{
			this.MsgCallBack = null;
		}

		public string GetMesssage()
		{
			return DataReceive;
		}
	}
}
