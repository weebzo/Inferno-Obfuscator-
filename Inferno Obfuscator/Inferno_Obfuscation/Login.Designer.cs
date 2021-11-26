namespace Inferno_Obfuscation
{
	// Token: 0x0200003D RID: 61
	public partial class Login : global::System.Windows.Forms.Form
	{
		// Token: 0x0600013A RID: 314 RVA: 0x000196CC File Offset: 0x000178CC
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x0600013B RID: 315 RVA: 0x00019704 File Offset: 0x00017904
		private void InitializeComponent()
		{
			global::System.ComponentModel.ComponentResourceManager resources = new global::System.ComponentModel.ComponentResourceManager(typeof(global::Inferno_Obfuscation.Login));
			this.panel2 = new global::System.Windows.Forms.Panel();
			this.pictureBox4 = new global::System.Windows.Forms.PictureBox();
			this.pictureBox1 = new global::System.Windows.Forms.PictureBox();
			this.label3 = new global::System.Windows.Forms.Label();
			this.label1 = new global::System.Windows.Forms.Label();
			this.panel4 = new global::System.Windows.Forms.Panel();
			this.button2 = new global::System.Windows.Forms.Button();
			this.label2 = new global::System.Windows.Forms.Label();
			this.panel3 = new global::System.Windows.Forms.Panel();
			this.password = new global::System.Windows.Forms.RichTextBox();
			this.button1 = new global::System.Windows.Forms.Button();
			this.panel1 = new global::System.Windows.Forms.Panel();
			this.username = new global::System.Windows.Forms.RichTextBox();
			this.panel2.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).BeginInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).BeginInit();
			this.panel4.SuspendLayout();
			this.panel3.SuspendLayout();
			this.panel1.SuspendLayout();
			base.SuspendLayout();
			this.panel2.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.panel2.Controls.Add(this.pictureBox4);
			this.panel2.Controls.Add(this.pictureBox1);
			this.panel2.Controls.Add(this.label3);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Location = new global::System.Drawing.Point(-4, -1);
			this.panel2.Name = "panel2";
			this.panel2.Size = new global::System.Drawing.Size(397, 77);
			this.panel2.TabIndex = 2;
			this.panel2.Paint += new global::System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
			this.panel2.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.panel2_MouseDown);
			this.panel2.MouseMove += new global::System.Windows.Forms.MouseEventHandler(this.panel2_MouseMove);
			this.panel2.MouseUp += new global::System.Windows.Forms.MouseEventHandler(this.panel2_MouseUp);
			this.pictureBox4.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.pictureBox4.Image = (global::System.Drawing.Image)resources.GetObject("pictureBox4.Image");
			this.pictureBox4.Location = new global::System.Drawing.Point(319, 0);
			this.pictureBox4.Name = "pictureBox4";
			this.pictureBox4.Size = new global::System.Drawing.Size(37, 36);
			this.pictureBox4.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox4.TabIndex = 7;
			this.pictureBox4.TabStop = false;
			this.pictureBox4.Click += new global::System.EventHandler(this.pictureBox4_Click);
			this.pictureBox1.BackColor = global::System.Drawing.Color.FromArgb(14, 11, 75);
			this.pictureBox1.Image = (global::System.Drawing.Image)resources.GetObject("pictureBox1.Image");
			this.pictureBox1.Location = new global::System.Drawing.Point(358, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new global::System.Drawing.Size(37, 36);
			this.pictureBox1.SizeMode = global::System.Windows.Forms.PictureBoxSizeMode.StretchImage;
			this.pictureBox1.TabIndex = 6;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new global::System.EventHandler(this.pictureBox1_Click);
			this.label3.AutoSize = true;
			this.label3.Font = new global::System.Drawing.Font("Leelawadee UI", 18f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label3.ForeColor = global::System.Drawing.Color.FromArgb(233, 233, 233);
			this.label3.Location = new global::System.Drawing.Point(152, 31);
			this.label3.Name = "label3";
			this.label3.Size = new global::System.Drawing.Size(89, 32);
			this.label3.TabIndex = 5;
			this.label3.Text = "LOGIN";
			this.label1.AutoSize = true;
			this.label1.Font = new global::System.Drawing.Font("Calibri", 11.25f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label1.ForeColor = global::System.Drawing.Color.FromArgb(233, 233, 233);
			this.label1.Location = new global::System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new global::System.Drawing.Size(167, 18);
			this.label1.TabIndex = 4;
			this.label1.Text = "Welcome back to inferno!";
			this.panel4.BackColor = global::System.Drawing.Color.FromArgb(32, 38, 56);
			this.panel4.Controls.Add(this.button2);
			this.panel4.Controls.Add(this.label2);
			this.panel4.Location = new global::System.Drawing.Point(-4, 315);
			this.panel4.Name = "panel4";
			this.panel4.Size = new global::System.Drawing.Size(393, 54);
			this.panel4.TabIndex = 11;
			this.button2.BackColor = global::System.Drawing.Color.FromArgb(190, 20, 80);
			this.button2.FlatAppearance.BorderColor = global::System.Drawing.Color.FromArgb(42, 48, 66);
			this.button2.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button2.Font = new global::System.Drawing.Font("Microsoft YaHei UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button2.ForeColor = global::System.Drawing.Color.FromArgb(233, 233, 233);
			this.button2.Location = new global::System.Drawing.Point(237, 9);
			this.button2.Name = "button2";
			this.button2.Size = new global::System.Drawing.Size(82, 33);
			this.button2.TabIndex = 5;
			this.button2.Text = "JOIN";
			this.button2.UseVisualStyleBackColor = false;
			this.button2.Click += new global::System.EventHandler(this.button2_Click);
			this.label2.AutoSize = true;
			this.label2.Font = new global::System.Drawing.Font("Calibri", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.label2.ForeColor = global::System.Drawing.Color.FromArgb(233, 233, 233);
			this.label2.Location = new global::System.Drawing.Point(20, 18);
			this.label2.Name = "label2";
			this.label2.Size = new global::System.Drawing.Size(211, 15);
			this.label2.TabIndex = 4;
			this.label2.Text = "Make sure to join our discord server!";
			this.panel3.BackColor = global::System.Drawing.Color.FromArgb(32, 36, 65);
			this.panel3.Controls.Add(this.password);
			this.panel3.Location = new global::System.Drawing.Point(62, 157);
			this.panel3.Name = "panel3";
			this.panel3.Size = new global::System.Drawing.Size(273, 39);
			this.panel3.TabIndex = 10;
			this.password.BackColor = global::System.Drawing.Color.FromArgb(42, 46, 75);
			this.password.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.password.Font = new global::System.Drawing.Font("Microsoft YaHei", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.password.ForeColor = global::System.Drawing.Color.White;
			this.password.Location = new global::System.Drawing.Point(10, 6);
			this.password.Multiline = false;
			this.password.Name = "password";
			this.password.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.None;
			this.password.Size = new global::System.Drawing.Size(253, 25);
			this.password.TabIndex = 7;
			this.password.Text = "Password";
			this.password.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.password_MouseDown);
			this.button1.BackColor = global::System.Drawing.Color.FromArgb(190, 20, 80);
			this.button1.FlatAppearance.BorderColor = global::System.Drawing.Color.FromArgb(42, 48, 66);
			this.button1.FlatStyle = global::System.Windows.Forms.FlatStyle.Flat;
			this.button1.Font = new global::System.Drawing.Font("Microsoft YaHei UI", 9.75f, global::System.Drawing.FontStyle.Regular, global::System.Drawing.GraphicsUnit.Point, 0);
			this.button1.ForeColor = global::System.Drawing.Color.FromArgb(233, 233, 233);
			this.button1.Location = new global::System.Drawing.Point(112, 221);
			this.button1.Name = "button1";
			this.button1.Size = new global::System.Drawing.Size(171, 46);
			this.button1.TabIndex = 9;
			this.button1.Text = "SIGN IN";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += new global::System.EventHandler(this.button1_Click);
			this.panel1.BackColor = global::System.Drawing.Color.FromArgb(32, 36, 65);
			this.panel1.Controls.Add(this.username);
			this.panel1.ForeColor = global::System.Drawing.Color.White;
			this.panel1.Location = new global::System.Drawing.Point(62, 116);
			this.panel1.Name = "panel1";
			this.panel1.Size = new global::System.Drawing.Size(273, 39);
			this.panel1.TabIndex = 8;
			this.username.BackColor = global::System.Drawing.Color.FromArgb(42, 46, 75);
			this.username.BorderStyle = global::System.Windows.Forms.BorderStyle.None;
			this.username.Font = new global::System.Drawing.Font("Microsoft YaHei", 8.25f, global::System.Drawing.FontStyle.Bold, global::System.Drawing.GraphicsUnit.Point, 0);
			this.username.ForeColor = global::System.Drawing.Color.White;
			this.username.Location = new global::System.Drawing.Point(10, 6);
			this.username.Multiline = false;
			this.username.Name = "username";
			this.username.ScrollBars = global::System.Windows.Forms.RichTextBoxScrollBars.None;
			this.username.Size = new global::System.Drawing.Size(253, 25);
			this.username.TabIndex = 6;
			this.username.Text = "Username";
			this.username.MouseDown += new global::System.Windows.Forms.MouseEventHandler(this.username_MouseDown);
			base.AutoScaleDimensions = new global::System.Drawing.SizeF(6f, 13f);
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = global::System.Drawing.Color.FromArgb(42, 48, 66);
			base.ClientSize = new global::System.Drawing.Size(391, 365);
			base.Controls.Add(this.panel4);
			base.Controls.Add(this.panel3);
			base.Controls.Add(this.button1);
			base.Controls.Add(this.panel1);
			base.Controls.Add(this.panel2);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.None;
			base.Name = "Login";
			this.Text = "Login";
			base.Load += new global::System.EventHandler(this.Login_Load);
			this.panel2.ResumeLayout(false);
			this.panel2.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox4).EndInit();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBox1).EndInit();
			this.panel4.ResumeLayout(false);
			this.panel4.PerformLayout();
			this.panel3.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			base.ResumeLayout(false);
		}

		// Token: 0x04000085 RID: 133
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x04000086 RID: 134
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x04000087 RID: 135
		private global::System.Windows.Forms.PictureBox pictureBox4;

		// Token: 0x04000088 RID: 136
		private global::System.Windows.Forms.PictureBox pictureBox1;

		// Token: 0x04000089 RID: 137
		private global::System.Windows.Forms.Label label3;

		// Token: 0x0400008A RID: 138
		private global::System.Windows.Forms.Label label1;

		// Token: 0x0400008B RID: 139
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x0400008C RID: 140
		private global::System.Windows.Forms.Button button2;

		// Token: 0x0400008D RID: 141
		private global::System.Windows.Forms.Label label2;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Panel panel3;

		// Token: 0x0400008F RID: 143
		private global::System.Windows.Forms.RichTextBox password;

		// Token: 0x04000090 RID: 144
		private global::System.Windows.Forms.Button button1;

		// Token: 0x04000091 RID: 145
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x04000092 RID: 146
		private global::System.Windows.Forms.RichTextBox username;
	}
}
