using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DataReader2.Properties;

namespace DataReader2;

public class QuickGuaid : Form
{
	private int picnum = 1;

	private IContainer components = null;

	private Label label1;

	private PictureBox pictureBox1;

	private Timer timer1;

	private Timer timer2;

	private Label label2;

	public QuickGuaid()
	{
		InitializeComponent();
	}

	private void QuickGuaid_Load(object sender, EventArgs e)
	{
	}

	private void pictureBox1_Click(object sender, EventArgs e)
	{
		picnum++;
	}

	private void timer2_Tick(object sender, EventArgs e)
	{
		switch (picnum)
		{
		case 1:
			pictureBox1.BackgroundImage = Resources._1;
			break;
		case 2:
			timer1.Enabled = false;
			pictureBox1.BackgroundImage = Resources._2;
			label1.Visible = false;
			label2.Visible = false;
			break;
		case 3:
			pictureBox1.BackgroundImage = Resources._3;
			break;
		case 4:
			pictureBox1.BackgroundImage = Resources._4;
			break;
		case 5:
			pictureBox1.BackgroundImage = Resources._5;
			break;
		case 6:
			pictureBox1.BackgroundImage = Resources._6;
			break;
		case 7:
			pictureBox1.BackgroundImage = Resources._7;
			break;
		case 8:
			pictureBox1.BackgroundImage = Resources.F;
			break;
		default:
			Close();
			break;
		}
	}

	private void timer1_Tick(object sender, EventArgs e)
	{
		picnum++;
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
		this.timer2 = new System.Windows.Forms.Timer(this.components);
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.label2 = new System.Windows.Forms.Label();
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
		base.SuspendLayout();
		this.label1.AutoSize = true;
		this.label1.BackColor = System.Drawing.Color.FromArgb(44, 99, 201);
		this.label1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(579, 643);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(42, 21);
		this.label1.TabIndex = 0;
		this.label1.Text = "跳过";
		this.label1.Click += new System.EventHandler(label1_Click);
		this.timer1.Enabled = true;
		this.timer1.Interval = 10000;
		this.timer1.Tick += new System.EventHandler(timer1_Tick);
		this.timer2.Enabled = true;
		this.timer2.Interval = 200;
		this.timer2.Tick += new System.EventHandler(timer2_Tick);
		this.pictureBox1.BackgroundImage = DataReader2.Properties.Resources._11;
		this.pictureBox1.Location = new System.Drawing.Point(0, 0);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(1200, 700);
		this.pictureBox1.TabIndex = 1;
		this.pictureBox1.TabStop = false;
		this.pictureBox1.Click += new System.EventHandler(pictureBox1_Click);
		this.label2.AutoSize = true;
		this.label2.BackColor = System.Drawing.Color.FromArgb(40, 85, 180);
		this.label2.Font = new System.Drawing.Font("微软雅黑", 10.5f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.label2.ForeColor = System.Drawing.Color.FromArgb(255, 128, 0);
		this.label2.Location = new System.Drawing.Point(740, 644);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(79, 19);
		this.label2.TabIndex = 2;
		this.label2.Text = "单击以继续";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		base.ClientSize = new System.Drawing.Size(1200, 700);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.pictureBox1);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "QuickGuaid";
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "QuickGuaid";
		base.Load += new System.EventHandler(QuickGuaid_Load);
		((System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
