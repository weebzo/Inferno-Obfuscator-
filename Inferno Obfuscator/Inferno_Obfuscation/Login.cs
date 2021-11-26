using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Inferno_Obfuscation
{
	// Token: 0x0200003D RID: 61
	public partial class Login : Form
	{
		// Token: 0x0600012E RID: 302 RVA: 0x0001950D File Offset: 0x0001770D
		public Login()
		{
			this.InitializeComponent();
		}

		// Token: 0x0600012F RID: 303 RVA: 0x0001953C File Offset: 0x0001773C
		private void button1_Click(object sender, EventArgs e)
		{
			bool flag = this.username.Text == "Trigger";
			if (flag)
			{
				base.Hide();
				Form1 frmdash = new Form1();
				frmdash.ShowDialog();
				base.Close();
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x00019580 File Offset: 0x00017780
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			base.Close();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0001958A File Offset: 0x0001778A
		private void pictureBox4_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		// Token: 0x06000132 RID: 306 RVA: 0x00019595 File Offset: 0x00017795
		private void button2_Click(object sender, EventArgs e)
		{
			Process.Start("https://discord.gg/k5B9bWp");
		}

		// Token: 0x06000133 RID: 307 RVA: 0x000195A3 File Offset: 0x000177A3
		private void panel2_MouseUp(object sender, MouseEventArgs e)
		{
			this.drag = false;
		}

		// Token: 0x06000134 RID: 308 RVA: 0x000195B0 File Offset: 0x000177B0
		private void panel2_MouseMove(object sender, MouseEventArgs e)
		{
			bool flag = this.drag;
			if (flag)
			{
				Point p = base.PointToScreen(e.Location);
				base.Location = new Point(p.X - this.start_point.X, p.Y - this.start_point.Y);
			}
		}

		// Token: 0x06000135 RID: 309 RVA: 0x00019609 File Offset: 0x00017809
		private void panel2_MouseDown(object sender, MouseEventArgs e)
		{
			this.drag = true;
			this.start_point = new Point(e.X, e.Y);
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0001962C File Offset: 0x0001782C
		private void username_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = this.password.Text == "";
			if (flag)
			{
				this.username.Text = "Password";
			}
			this.username.Text = "";
		}

		// Token: 0x06000137 RID: 311 RVA: 0x00019678 File Offset: 0x00017878
		private void password_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = this.username.Text == "";
			if (flag)
			{
				this.username.Text = "Username";
			}
			this.password.Text = "";
		}

		// Token: 0x06000138 RID: 312 RVA: 0x000196C3 File Offset: 0x000178C3
		private void Login_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x06000139 RID: 313 RVA: 0x000196C6 File Offset: 0x000178C6
		private void panel2_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x04000083 RID: 131
		private bool drag = false;

		// Token: 0x04000084 RID: 132
		private Point start_point = new Point(0, 0);
	}
}
