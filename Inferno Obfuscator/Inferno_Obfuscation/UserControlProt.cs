using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Inferno_Obfuscation
{
	// Token: 0x02000056 RID: 86
	public class UserControlProt : UserControl
	{
		// Token: 0x0600019F RID: 415 RVA: 0x00022C0E File Offset: 0x00020E0E
		public UserControlProt()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001A0 RID: 416 RVA: 0x00022C28 File Offset: 0x00020E28
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001A1 RID: 417 RVA: 0x00022C60 File Offset: 0x00020E60
		private void InitializeComponent()
		{
			this.mainpanel = new Panel();
			this.label1 = new Label();
			this.mainpanel.SuspendLayout();
			base.SuspendLayout();
			this.mainpanel.BackColor = Color.FromArgb(15, 30, 60);
			this.mainpanel.Controls.Add(this.label1);
			this.mainpanel.Location = new Point(-80, -43);
			this.mainpanel.Name = "mainpanel";
			this.mainpanel.Size = new Size(983, 639);
			this.mainpanel.TabIndex = 12;
			this.label1.AutoSize = true;
			this.label1.Location = new Point(0, 0);
			this.label1.Name = "label1";
			this.label1.Size = new Size(35, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "label1";
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.mainpanel);
			base.Name = "UserControlProt";
			base.Size = new Size(822, 552);
			this.mainpanel.ResumeLayout(false);
			this.mainpanel.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000DD RID: 221
		private IContainer components = null;

		// Token: 0x040000DE RID: 222
		private Panel mainpanel;

		// Token: 0x040000DF RID: 223
		private Label label1;
	}
}
