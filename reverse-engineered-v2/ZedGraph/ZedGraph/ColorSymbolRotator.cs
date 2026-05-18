using System.Drawing;

namespace ZedGraph;

public class ColorSymbolRotator
{
	public static readonly Color[] COLORS = new Color[10]
	{
		Color.Red,
		Color.Blue,
		Color.Green,
		Color.Purple,
		Color.Cyan,
		Color.Pink,
		Color.LightBlue,
		Color.PaleVioletRed,
		Color.SeaGreen,
		Color.Yellow
	};

	public static readonly SymbolType[] SYMBOLS = new SymbolType[10]
	{
		SymbolType.Circle,
		SymbolType.Diamond,
		SymbolType.Plus,
		SymbolType.Square,
		SymbolType.Star,
		SymbolType.Triangle,
		SymbolType.TriangleDown,
		SymbolType.XCross,
		SymbolType.HDash,
		SymbolType.VDash
	};

	private static ColorSymbolRotator _staticInstance;

	protected int colorIndex;

	protected int symbolIndex;

	public Color NextColor => COLORS[NextColorIndex];

	public int NextColorIndex
	{
		get
		{
			if (colorIndex >= COLORS.Length)
			{
				colorIndex = 0;
			}
			return colorIndex++;
		}
		set
		{
			colorIndex = value;
		}
	}

	public SymbolType NextSymbol => SYMBOLS[NextSymbolIndex];

	public int NextSymbolIndex
	{
		get
		{
			if (symbolIndex >= SYMBOLS.Length)
			{
				symbolIndex = 0;
			}
			return symbolIndex++;
		}
		set
		{
			symbolIndex = value;
		}
	}

	public static ColorSymbolRotator StaticInstance
	{
		get
		{
			if (_staticInstance == null)
			{
				_staticInstance = new ColorSymbolRotator();
			}
			return _staticInstance;
		}
	}

	public static Color StaticNextColor => StaticInstance.NextColor;

	public static SymbolType StaticNextSymbol => StaticInstance.NextSymbol;
}
