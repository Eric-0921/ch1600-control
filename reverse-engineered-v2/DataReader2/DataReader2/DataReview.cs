using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ZedGraph;

namespace DataReader2;

public class DataReview : Form
{
	private int pointcount = 0;

	private int GraphScaleMax = 300;

	private PointPairList listR1 = new PointPairList();

	private LineItem CurveR1;

	private PointPairList listR2 = new PointPairList();

	private LineItem CurveR2;

	private PointPairList listR3 = new PointPairList();

	private LineItem CurveR3;

	private PointPairList listR4 = new PointPairList();

	private LineItem CurveR4;

	private IContainer components = null;

	private Button button1;

	private ZedGraphControl zedGraphControl_data_review;

	private OpenFileDialog openFileDialog1;

	private Button button2;

	private System.Windows.Forms.Label label1;

	private System.Windows.Forms.Label label2;

	private System.Windows.Forms.Label label3;

	private System.Windows.Forms.Label label4;

	public DataReview(int x, int y, int h, int w)
	{
		InitializeComponent();
		base.Left = x;
		base.Top = y;
		base.Height = h;
		base.Width = w;
		base.TopMost = true;
		base.ShowInTaskbar = false;
	}

	private void DataReview_Load(object sender, EventArgs e)
	{
		zed_init(zedGraphControl_data_review);
		if (openFileDialog1.ShowDialog() == DialogResult.OK)
		{
			StreamReader sr;
			try
			{
				sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
			}
			catch
			{
				MessageSender.Send("该文件正在被占用 请解除占用后打开");
				Close();
				return;
			}
			try
			{
				string line;
				while (!string.IsNullOrEmpty(line = sr.ReadLine()))
				{
					listR1.Add(pointcount, Convert.ToDouble(line.Split('\t')[0]));
					listR2.Add(pointcount, Convert.ToDouble(line.Split('\t')[1]));
					listR3.Add(pointcount, Convert.ToDouble(line.Split('\t')[2]));
					pointcount++;
				}
				FileInfo FI = new FileInfo(openFileDialog1.FileName);
				label2.Text = FI.CreationTime.ToString("yyyy-MM-dd HH:mm:ss");
				label3.Text = FI.LastWriteTime.ToString("yyyy-MM-dd HH:mm:ss");
			}
			catch
			{
				MessageSender.Send("错误的文件格式");
				Close();
			}
		}
		else
		{
			Close();
		}
		zedGraphControl_data_review.AxisChange();
		zedGraphControl_data_review.Refresh();
	}

	private void zed_init(ZedGraphControl control)
	{
		control.GraphPane.Fill = new Fill(Color.FromArgb(0, 0, 0));
		control.GraphPane.Chart.Fill.Type = FillType.None;
		control.GraphPane.Title.Text = " ";
		control.GraphPane.Title.FontSpec.FontColor = Color.White;
		control.GraphPane.Border.Color = Color.FromArgb(0, 0, 0);
		control.GraphPane.Border.Width = 2f;
		control.GraphPane.Chart.Border.Color = Color.FromArgb(255, 255, 255);
		control.GraphPane.XAxis.Title.Text = "数据序号";
		control.GraphPane.XAxis.Type = AxisType.Ordinal;
		control.GraphPane.XAxis.MajorTic.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.XAxis.MinorTic.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.XAxis.Title.FontSpec.FontColor = Color.SandyBrown;
		control.GraphPane.XAxis.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.XAxis.MajorGrid.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.XAxis.Scale.FontSpec.FontColor = Color.FromArgb(255, 128, 0);
		control.GraphPane.YAxis.Title.Text = "数据值";
		control.GraphPane.YAxis.Scale.FontSpec.FontColor = Color.FromArgb(255, 128, 0);
		control.GraphPane.YAxis.MajorTic.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.YAxis.MinorTic.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.YAxis.Title.FontSpec.FontColor = Color.SandyBrown;
		control.GraphPane.YAxis.Color = Color.FromArgb(255, 128, 0);
		control.GraphPane.XAxis.MajorGrid.Color = Color.FromArgb(255, 128, 0);
		CurveR1 = control.GraphPane.AddCurve("CH 1", listR1, ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH1Color", "#FFC0C0")), SymbolType.None);
		CurveR1.Line.Width = 1f;
		CurveR2 = control.GraphPane.AddCurve("CH 2", listR2, ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH2Color", "#C0FFC0")), SymbolType.None);
		CurveR2.Line.Width = 1f;
		CurveR3 = control.GraphPane.AddCurve("CH 3", listR3, ColorTranslator.FromHtml(SystemConfig.GetConfigData("CH3Color", "#C0C0FF")), SymbolType.None);
		CurveR3.Line.Width = 1f;
	}

	private void button1_Click(object sender, EventArgs e)
	{
		Close();
	}

	private void button2_Click(object sender, EventArgs e)
	{
		if (openFileDialog1.ShowDialog() == DialogResult.OK)
		{
			StreamReader sr = new StreamReader(openFileDialog1.FileName, Encoding.Default);
			try
			{
				string line;
				while (!string.IsNullOrEmpty(line = sr.ReadLine()))
				{
					listR1.Add(pointcount, Convert.ToDouble(line.Split('\t')[0]));
					listR2.Add(pointcount, Convert.ToDouble(line.Split('\t')[1]));
					listR3.Add(pointcount, Convert.ToDouble(line.Split('\t')[2]));
					pointcount++;
				}
			}
			catch
			{
				MessageSender.Send("错误的文件");
			}
		}
		zedGraphControl_data_review.AxisChange();
		zedGraphControl_data_review.Refresh();
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
		this.button1 = new System.Windows.Forms.Button();
		this.zedGraphControl_data_review = new ZedGraph.ZedGraphControl();
		this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.button2 = new System.Windows.Forms.Button();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		base.SuspendLayout();
		this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button1.BackColor = System.Drawing.Color.FromArgb(255, 192, 192);
		this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Red;
		this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(255, 192, 192);
		this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
		this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button1.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.button1.ForeColor = System.Drawing.Color.FromArgb(192, 0, 0);
		this.button1.Location = new System.Drawing.Point(823, 0);
		this.button1.Name = "button1";
		this.button1.Size = new System.Drawing.Size(57, 40);
		this.button1.TabIndex = 0;
		this.button1.Text = "返回";
		this.button1.UseVisualStyleBackColor = false;
		this.button1.Click += new System.EventHandler(button1_Click);
		this.zedGraphControl_data_review.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
		this.zedGraphControl_data_review.Location = new System.Drawing.Point(-13, -59);
		this.zedGraphControl_data_review.Margin = new System.Windows.Forms.Padding(7, 13, 7, 13);
		this.zedGraphControl_data_review.Name = "zedGraphControl_data_review";
		this.zedGraphControl_data_review.ScrollGrace = 0.0;
		this.zedGraphControl_data_review.ScrollMaxX = 0.0;
		this.zedGraphControl_data_review.ScrollMaxY = 0.0;
		this.zedGraphControl_data_review.ScrollMaxY2 = 0.0;
		this.zedGraphControl_data_review.ScrollMinX = 0.0;
		this.zedGraphControl_data_review.ScrollMinY = 0.0;
		this.zedGraphControl_data_review.ScrollMinY2 = 0.0;
		this.zedGraphControl_data_review.Size = new System.Drawing.Size(835, 620);
		this.zedGraphControl_data_review.TabIndex = 2;
		this.openFileDialog1.FileName = "openFileDialog1";
		this.button2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
		this.button2.BackColor = System.Drawing.Color.FromArgb(72, 145, 234);
		this.button2.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(128, 128, 255);
		this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(192, 192, 255);
		this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Blue;
		this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.button2.Font = new System.Drawing.Font("微软雅黑", 12f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 134);
		this.button2.ForeColor = System.Drawing.Color.White;
		this.button2.Location = new System.Drawing.Point(823, 66);
		this.button2.Name = "button2";
		this.button2.Size = new System.Drawing.Size(57, 40);
		this.button2.TabIndex = 3;
		this.button2.Text = "追加";
		this.button2.UseVisualStyleBackColor = false;
		this.button2.Click += new System.EventHandler(button2_Click);
		this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label1.AutoSize = true;
		this.label1.ForeColor = System.Drawing.Color.White;
		this.label1.Location = new System.Drawing.Point(12, 505);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(113, 12);
		this.label1.TabIndex = 4;
		this.label1.Text = "回放文件创建时间：";
		this.label2.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label2.AutoSize = true;
		this.label2.ForeColor = System.Drawing.Color.White;
		this.label2.Location = new System.Drawing.Point(155, 505);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(29, 12);
		this.label2.TabIndex = 5;
		this.label2.Text = "xxxx";
		this.label3.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label3.AutoSize = true;
		this.label3.ForeColor = System.Drawing.Color.White;
		this.label3.Location = new System.Drawing.Point(155, 518);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(29, 12);
		this.label3.TabIndex = 7;
		this.label3.Text = "xxxx";
		this.label4.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
		this.label4.AutoSize = true;
		this.label4.ForeColor = System.Drawing.Color.White;
		this.label4.Location = new System.Drawing.Point(12, 518);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(137, 12);
		this.label4.TabIndex = 6;
		this.label4.Text = "回放文件最新修改时间：";
		base.AutoScaleDimensions = new System.Drawing.SizeF(6f, 12f);
		base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.BackColor = System.Drawing.Color.Black;
		base.ClientSize = new System.Drawing.Size(880, 539);
		base.Controls.Add(this.label3);
		base.Controls.Add(this.label4);
		base.Controls.Add(this.label2);
		base.Controls.Add(this.label1);
		base.Controls.Add(this.button2);
		base.Controls.Add(this.button1);
		base.Controls.Add(this.zedGraphControl_data_review);
		base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
		base.Name = "DataReview";
		base.Opacity = 0.9;
		base.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
		this.Text = "DataReview";
		base.Load += new System.EventHandler(DataReview_Load);
		base.ResumeLayout(false);
		base.PerformLayout();
	}
}
