using System;
using DMSkin.Metro.Components;
using DMSkin.Metro.Drawing;

namespace DMSkin.Metro.Interfaces;

public interface IMetroControl
{
	MetroColorStyle Style { get; set; }

	MetroThemeStyle Theme { get; set; }

	MetroStyleManager StyleManager { get; set; }

	bool DM_UseCustomBackColor { get; set; }

	bool DM_UseCustomForeColor { get; set; }

	bool DM_UseStyleColors { get; set; }

	bool DM_UseSelectable { get; set; }

	event EventHandler<MetroPaintEventArgs> CustomPaintBackground;

	event EventHandler<MetroPaintEventArgs> CustomPaint;

	event EventHandler<MetroPaintEventArgs> CustomPaintForeground;
}
