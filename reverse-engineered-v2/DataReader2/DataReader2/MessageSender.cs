namespace DataReader2;

internal class MessageSender
{
	public static void Send(string str)
	{
		MessageForm mf = new MessageForm(str);
		mf.TopMost = true;
		mf.ShowDialog();
	}
}
