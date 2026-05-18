using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DataReader2;

public class MessageForm : Form
{
	private IContainer components = null;

	private Label label1;

	private Timer timer1;

	public MessageForm(string msg)
	{
		InitializeComponent();
		label1.Text = msg;
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		Close();
	}

	private void MessageForm_Load(object sender, EventArgs e)
	{
	}

	private void label1_Click(object sender, EventArgs e)
	{
		Close();
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
		this.label1 = new System.Windows.Forms.Label();
		this.timer1 = new System.Windows.Forms.Timer(this.components);
		base.SuspendLayout();
		this.label1.BackColor = System.Drawing.Color.Black;
		this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.ForeColor = System.Drawing.Color.FromArgb(255, 192, 192);
		this.label1.Location = new System.Drawing.Point(2, 2);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(396, 146);
		this.label1.TabIndex = 0;
		this.label1.Text = "label1";
		this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
		this.label1.Click += new System.EventHandler(label1_Click);
		this.timer1.Enabled = true;
		this.timer1.Interval = 3000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
		base.ClientSize = new System.Drawing.Size(400, 150);
		base.Controls.Add(this.label1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "MessageForm";
		base.Opacity = 0.9;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "MessageForm";
		base.Load += new System.EventHandler(MessageForm_Load);
		base.Click += new System.EventHandler(label1_Click);
		base.ResumeLayout(false);
	}
}
