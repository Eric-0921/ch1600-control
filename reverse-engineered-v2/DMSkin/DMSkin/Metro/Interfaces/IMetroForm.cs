using DMSkin.Metro.Components;

namespace DMSkin.Metro.Interfaces;

public interface IMetroForm
{
	MetroColorStyle Style { get; set; }

	MetroThemeStyle Theme { get; set; }

	MetroStyleManager StyleManager { get; set; }
}
