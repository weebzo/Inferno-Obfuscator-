using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;

namespace Inferno_Obfuscation
{
	// Token: 0x02000032 RID: 50
	public partial class Form1 : Form
	{
		// Token: 0x06000100 RID: 256 RVA: 0x000176B8 File Offset: 0x000158B8
		public Form1()
		{
			this.InitializeComponent();
			this.mainpanel.Controls.Clear();
			this.papi = new UserControlSet();
			this.mainpanel.Controls.Add(this.papi);
		}

		// Token: 0x06000101 RID: 257 RVA: 0x00017729 File Offset: 0x00015929
		private void bunifuFlatButton1_Click_1(object sender, EventArgs e)
		{
			this.mainpanel.Controls.Clear();
			this.papi = new UserControlSet();
			this.mainpanel.Controls.Add(this.papi);
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0001775F File Offset: 0x0001595F
		private void Form1_Load_1(object sender, EventArgs e)
		{
		}

		// Token: 0x06000103 RID: 259 RVA: 0x00017762 File Offset: 0x00015962
		private void panel1_MouseUp_1(object sender, MouseEventArgs e)
		{
			this.drag = false;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x0001776C File Offset: 0x0001596C
		private void panel1_MouseDown_1(object sender, MouseEventArgs e)
		{
			this.drag = true;
			this.start_point = new Point(e.X, e.Y);
		}

		// Token: 0x06000105 RID: 261 RVA: 0x0001778D File Offset: 0x0001598D
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000106 RID: 262 RVA: 0x00017797 File Offset: 0x00015997
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000107 RID: 263 RVA: 0x000177A4 File Offset: 0x000159A4
		private void panel1_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = this.drag;
			if (flag)
			{
				Point p = base.PointToScreen(e.Location);
				base.Location = new Point(p.X - this.start_point.X, p.Y - this.start_point.Y);
			}
		}

		// Token: 0x06000108 RID: 264 RVA: 0x000177FD File Offset: 0x000159FD
		private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x06000109 RID: 265 RVA: 0x00017800 File Offset: 0x00015A00
		private void mainpanel_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x04000070 RID: 112
		public UserControl papi = null;

		// Token: 0x04000071 RID: 113
		private bool drag = false;

		// Token: 0x04000072 RID: 114
		private Point start_point = new Point(0, 0);
	}
}
