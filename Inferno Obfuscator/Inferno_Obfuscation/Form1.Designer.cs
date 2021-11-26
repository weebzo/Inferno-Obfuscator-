namespace Inferno_Obfuscation
{
	// Token: 0x02000032 RID: 50
	public partial class Form1 : global::System.Windows.Forms.Form
	{
		// Token: 0x0600010A RID: 266 RVA: 0x00017804 File Offset: 0x00015A04
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600010B RID: 267 RVA: 0x0001783C File Offset: 0x00015A3C
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Inferno_Obfuscation.Form1));
			this.mainpanel = new global::System.Windows.Forms.Panel();
			this.flowLayoutPanel1 = new global::System.Windows.Forms.FlowLayoutPanel();
			this.bunifuFlatButton1 = new global::Bunifu.Framework.UI.BunifuFlatButton();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.label1 = new global::System.Windows.Forms.Label();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.flowLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			base.SuspendLayout();
			this.mainpanel.BackColor = global::System.Drawing.Color.FromArgb(24, 21, 85);
			this.mainpanel.Location = new global::System.Drawing.Point(206, 51);
			this.mainpanel.Name = "mainpanel";
			this.mainpanel.Size = new global::System.Drawing.Size(839, 465);
			this.mainpanel.TabIndex = 10;
			this.mainpanel.Paint += new global::System.Windows.Forms.PaintEventHandler(this.mainpanel_Paint);
			this.flowLayoutPanel1.Anchor = global::System.Windows.Forms.AnchorStyles.None;
			this.flowLayoutPanel1.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			this.flowLayoutPanel1.Controls.Add(this.bunifuFlatButton1);
			this.flowLayoutPanel1.Location = new global::System.Drawing.Point(7, 51);
			this.flowLayoutPanel1.Name = "flowLayoutPanel1";
			this.flowLayoutPanel1.Size = new global::System.Drawing.Size(193, 465);
			this.flowLayoutPanel1.TabIndex = 11;
			this.flowLayoutPanel1.Paint += new global::System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
			this.bunifuFlatButton1.Activecolor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.bunifuFlatButton1.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.bunifuFlatButton1.BackgroundImageLayout = global::System.Windows.Forms.ImageLayout.Stretch;
			this.bunifuFlatButton1.BorderRadius = 0;
			this.bunifuFlatButton1.ButtonText = "Settings";
			this.bunifuFlatButton1.Cursor = global::System.Windows.Forms.Cursors.Hand;
			this.bunifuFlatButton1.DisabledColor = global::System.Drawing.Color.Gray;
			this.bunifuFlatButton1.Iconcolor = global::System.Drawing.Color.Transparent;
			this.bunifuFlatButton1.Iconimage = (global::System.Drawing.Image)resources.GetObject("bunifuFlatButton1.Iconimage");
			this.bunifuFlatButton1.Iconimage_right = null;
			this.bunifuFlatButton1.Iconimage_right_Selected = null;
			this.bunifuFlatButton1.Iconimage_Selected = null;
			this.bunifuFlatButton1.IconMarginLeft = 0;
			this.bunifuFlatButton1.IconMarginRight = 0;
			this.bunifuFlatButton1.IconRightVisible = true;
			this.bunifuFlatButton1.IconRightZoom = 0.0;
			this.bunifuFlatButton1.IconVisible = true;
			this.bunifuFlatButton1.IconZoom = 90.0;
			this.bunifuFlatButton1.IsTab = false;
			this.bunifuFlatButton1.Location = new global::System.Drawing.Point(3, 3);
			this.bunifuFlatButton1.Name = "bunifuFlatButton1";
			this.bunifuFlatButton1.Normalcolor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.bunifuFlatButton1.OnHovercolor = global::System.Drawing.Color.FromArgb(24, 21, 85);
			this.bunifuFlatButton1.OnHoverTextColor = global::System.Drawing.Color.White;
			this.bunifuFlatButton1.selected = false;
			this.bunifuFlatButton1.Size = new global::System.Drawing.Size(186, 55);
			this.bunifuFlatButton1.TabIndex = 0;
			this.bunifuFlatButton1.Text = "Settings";
			this.bunifuFlatButton1.TextAlign = global::System.Drawing.ContentAlignment.MiddleLeft;
			this.bunifuFlatButton1.Textcolor = global::System.Drawing.Color.White;
			this.bunifuFlatButton1.TextFont = new global::System.Drawing.Font("Microsoft Sans Serif", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.bunifuFlatButton1.Click += new global::System.EventHandler(this.bunifuFlatButton1_Click_1);
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.panel1.Controls.Add(this.label1);
			this.panel1.Controls.Add(this.pictureBox4);
			this.panel1.Controls.Add(this.pictureBox1);
			this.panel1.Location = new global::System.Drawing.Point(7, 2);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(1050, 39);
			this.panel1.TabIndex = 17;
			this.panel1.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown_1);
			this.panel1.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
			this.panel1.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp_1);
			this.label1.AutoSize = true;
			this.label1.BackColor = global::System.Drawing.Color.Transparent;
			this.label1.Font = new global::System.Drawing.Font("Microsoft Sans Serif", 27.75f, global::System.Drawing.FontStyle.Bold | global::System.Drawing.FontStyle.Italic, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.White;
			this.label1.Location = new global::System.Drawing.Point(-1, 0);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(483, 42);
			this.label1.TabIndex = 3;
			this.label1.Text = "INFERNO OBFUSCATION";
			this.pictureBox4.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.pictureBox4.Image = (global::System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(987, 6);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(37, 36);
			this.pictureBox4.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 2;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Click += new global::System.EventHandler(this.pictureBox4_Click);
			this.pictureBox1.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.pictureBox1.Image = (global::System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(1013, 2);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(37, 36);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 1;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.BackColor = global::System.Drawing.Color.FromArgb(25, 25, 25);
			base.ClientSize = new global::System.Drawing.Size(1057, 525);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.flowLayoutPanel1);
			base.Controls.Add(this.mainpanel);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Form1";
			base.Load += new global::System.EventHandler(this.Form1_Load_1);
			this.flowLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			base.ResumeLayout(false);
		}

		// Token: 0x04000073 RID: 115
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000074 RID: 116
		private global::System.Windows.Forms.Panel mainpanel;

		// Token: 0x04000075 RID: 117
		private global::System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;

		// Token: 0x04000076 RID: 118
		private global::Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;

		// Token: 0x04000077 RID: 119
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000078 RID: 120
		private global::System.Windows.Forms.Label label1;

		// Token: 0x04000079 RID: 121
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x0400007A RID: 122
		private global::System.Windows.Forms.PictureBox pictureBox1;
	}
}
