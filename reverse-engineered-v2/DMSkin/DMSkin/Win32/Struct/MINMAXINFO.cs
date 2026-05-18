using System.Drawing;

namespace DMSkin.Win32.Struct;

public struct MINMAXINFO
{
	public Point reserved;

	public Size maxSize;

	public Point maxPosition;

	public Size minTrackSize;

	public Size maxTrackSize;
}
