using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace datapick;

public class tishi : Form
{
	private const uint SC_CLOSE = 61536u;

	private const uint MF_BYCOMMAND = 0u;

	public static tishi tis = null;

	private IContainer components = null;

	private Timer timer1;

	public Label label1;

	public Button button1;

	[DllImport("USER32.DLL")]
	private static extern IntPtr GetSystemMenu(IntPtr hWnd, uint bRevert);

	[DllImport("USER32.DLL")]
	private static extern uint RemoveMenu(IntPtr hMenu, uint nPosition, uint wFlags);

	public tishi()
	{
		InitializeComponent();
		tis = this;
	}

	private void tishi_Load(object sender, EventArgs e)
	{
		IntPtr hMenu = GetSystemMenu(base.Handle, 0u);
		RemoveMenu(hMenu, 61536u, 0u);
		label1.Text = "读取中，请耐心等待......";
		button1.Text = "取消";
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
		Form1.mf.groupBox6.Enabled = true;
		Form1.mf.comboBoxDataType.SelectedIndex = 0;
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
		System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(datapick.tishi));
		this.label1 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.Font = new System.Drawing.Font("宋体", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.Location = new System.Drawing.Point(12, 21);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(200, 16);
		this.label1.TabIndex = 0;
		this.label1.Text = "读取中，请耐心等待......";
		this.button1.Location = new System.Drawing.Point(155, 51);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(75, 23);
		this.button1.TabIndex = 1;
		this.button1.Text = "取消";
		this.button1.UseVisualStyleBackColor = true;
		this.button1.Click += new System.EventHandler(button1_Click);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(242, 86);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.label1);
		base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
		base.MaximizeBox = false;
		this.MaximumSize = new System.Drawing.Size(250, 120);
		base.MinimizeBox = false;
		this.MinimumSize = new System.Drawing.Size(250, 120);
		base.Name = "tishi";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "提示";
		base.Load += new System.EventHandler(tishi_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
