using System;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000057 RID: 87
	public class UserControlSet : UserControl
	{
		// Token: 0x060001A2 RID: 418
		[DllImport("user32.dll")]
		public static extern int SendMessage(IntPtr intptr_0, int int_2, int int_3, int int_4);

		// Token: 0x060001A3 RID: 419
		[DllImport("user32.dll")]
		public static extern bool ReleaseCapture();

		// Token: 0x060001A4 RID: 420 RVA: 0x00022DEB File Offset: 0x00020FEB
		public UserControlSet()
		{
			this.InitializeComponent();
		}

		// Token: 0x060001A5 RID: 421 RVA: 0x00022E0A File Offset: 0x0002100A
		private void UserControlSet_Load(object sender, EventArgs e)
		{
		}

		// Token: 0x060001A6 RID: 422 RVA: 0x00022E10 File Offset: 0x00021010
		private void Main_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				UserControlSet.ReleaseCapture();
				UserControlSet.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060001A7 RID: 423 RVA: 0x00022E4C File Offset: 0x0002104C
		private void tabPage1_MouseDown(object sender, MouseEventArgs e)
		{
			bool flag = e.Button == MouseButtons.Left;
			if (flag)
			{
				UserControlSet.ReleaseCapture();
				UserControlSet.SendMessage(base.Handle, 161, 2, 0);
			}
		}

		// Token: 0x060001A8 RID: 424 RVA: 0x00022E86 File Offset: 0x00021086
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_6 = !Class64.bool_6;
		}

		// Token: 0x060001A9 RID: 425 RVA: 0x00022E98 File Offset: 0x00021098
		private void button1_Click(object sender, EventArgs e)
		{
			ModuleDef moduleDef_ = ModuleDefMD.Load(this.textBox1.Text);
			Class64.string_0 = this.textBox1.Text;
			Watermark.Execute(moduleDef_);
			ModuleDef manifestModule = moduleDef_.Assembly.ManifestModule;
			moduleDef_.EntryPoint.Name = "INFERNO_OBFUSCATION";
			moduleDef_.Mvid = new Guid?(Guid.NewGuid());
			Class64.smethod_0(moduleDef_);
			Class64.smethod_1();
			Class64.smethod_3();
		}

		// Token: 0x060001AA RID: 426 RVA: 0x00022F14 File Offset: 0x00021114
		private void Close()
		{
			this.Close();
		}

		// Token: 0x060001AB RID: 427 RVA: 0x00022F1E File Offset: 0x0002111E
		private void textBox1_TextChanged_1(object sender, EventArgs e)
		{
		}

		// Token: 0x060001AC RID: 428 RVA: 0x00022F24 File Offset: 0x00021124
		private void textBox1_DragDrop_1(object sender, DragEventArgs e)
		{
			try
			{
				Array array = (Array)e.Data.GetData(DataFormats.FileDrop);
				bool flag = array != null;
				if (flag)
				{
					string text = array.GetValue(0).ToString();
					int num = text.LastIndexOf(".");
					bool flag2 = num != -1;
					if (flag2)
					{
						string a = text.Substring(num).ToLower();
						bool flag3 = a == ".exe" || a == ".dll";
						if (flag3)
						{
							this.textBox1.Enabled = true;
							this.textBox1.Text = text;
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060001AD RID: 429 RVA: 0x00022FE0 File Offset: 0x000211E0
		private void textBox1_DragEnter_1(object sender, DragEventArgs e)
		{
			bool dataPresent = e.Data.GetDataPresent(DataFormats.FileDrop);
			if (dataPresent)
			{
				e.Effect = DragDropEffects.Copy;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}

		// Token: 0x060001AE RID: 430 RVA: 0x00023015 File Offset: 0x00021215
		private void checkBox4_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_12 = !Class64.bool_12;
		}

		// Token: 0x060001AF RID: 431 RVA: 0x00023025 File Offset: 0x00021225
		private void checkBox8_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_1 = !Class64.bool_1;
		}

		// Token: 0x060001B0 RID: 432 RVA: 0x00023035 File Offset: 0x00021235
		private void checkBox10_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_7 = !Class64.bool_7;
		}

		// Token: 0x060001B1 RID: 433 RVA: 0x00023045 File Offset: 0x00021245
		private void checkBox9_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_4 = !Class64.bool_4;
		}

		// Token: 0x060001B2 RID: 434 RVA: 0x00023055 File Offset: 0x00021255
		private void checkBox2_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_10 = !Class64.bool_10;
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00023065 File Offset: 0x00021265
		private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
		{
			Class64.bool_0 = !Class64.bool_0;
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00023075 File Offset: 0x00021275
		private void checkBox6_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_8 = !Class64.bool_8;
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00023085 File Offset: 0x00021285
		private void checkBox5_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_88 = !Class64.bool_88;
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00023095 File Offset: 0x00021295
		private void checkBox3_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_44 = !Class64.bool_44;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000230A5 File Offset: 0x000212A5
		private void checkBox7_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_22 = !Class64.bool_22;
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000230B5 File Offset: 0x000212B5
		private void checkBox11_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_53 = !Class64.bool_53;
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000230C5 File Offset: 0x000212C5
		private void checkBox12_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_99 = !Class64.bool_99;
		}

		// Token: 0x060001BA RID: 442 RVA: 0x000230D5 File Offset: 0x000212D5
		private void checkBox13_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_111 = !Class64.bool_111;
		}

		// Token: 0x060001BB RID: 443 RVA: 0x000230E5 File Offset: 0x000212E5
		private void checkBox14_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_888 = !Class64.bool_888;
		}

		// Token: 0x060001BC RID: 444 RVA: 0x000230F5 File Offset: 0x000212F5
		private void checkBox15_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_122 = !Class64.bool_122;
		}

		// Token: 0x060001BD RID: 445 RVA: 0x00023105 File Offset: 0x00021305
		private void checkBox16_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_222 = !Class64.bool_222;
		}

		// Token: 0x060001BE RID: 446 RVA: 0x00023115 File Offset: 0x00021315
		private void checkBox17_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_33 = !Class64.bool_33;
		}

		// Token: 0x060001BF RID: 447 RVA: 0x00023125 File Offset: 0x00021325
		private void mainpanel_Paint(object sender, PaintEventArgs e)
		{
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x00023128 File Offset: 0x00021328
		private void checkBox18_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_333 = !Class64.bool_333;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00023138 File Offset: 0x00021338
		private void checkBox19_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_500 = !Class64.bool_500;
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x00023148 File Offset: 0x00021348
		private void checkBox20_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_400 = !Class64.bool_400;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x00023158 File Offset: 0x00021358
		private void checkBox21_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_50 = !Class64.bool_50;
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00023168 File Offset: 0x00021368
		private void checkBox22_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_01 = !Class64.bool_01;
		}

		// Token: 0x060001C5 RID: 453 RVA: 0x00023178 File Offset: 0x00021378
		private void checkBox23_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_02 = !Class64.bool_02;
		}

		// Token: 0x060001C6 RID: 454 RVA: 0x00023188 File Offset: 0x00021388
		private void checkBox24_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_03 = !Class64.bool_03;
		}

		// Token: 0x060001C7 RID: 455 RVA: 0x00023198 File Offset: 0x00021398
		private void checkBox25_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_04 = !Class64.bool_04;
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x000231A8 File Offset: 0x000213A8
		private void checkBox26_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_05 = !Class64.bool_05;
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000231B8 File Offset: 0x000213B8
		private void checkBox27_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_06 = !Class64.bool_06;
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000231C8 File Offset: 0x000213C8
		private void checkBox28_CheckedChanged_2(object sender, EventArgs e)
		{
			Class64.bool_2222 = !Class64.bool_2222;
		}

		// Token: 0x060001CB RID: 459 RVA: 0x000231D8 File Offset: 0x000213D8
		private void checkBox29_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_007 = !Class64.bool_007;
		}

		// Token: 0x060001CC RID: 460 RVA: 0x000231E8 File Offset: 0x000213E8
		private void checkBox30_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_8888 = !Class64.bool_8888;
		}

		// Token: 0x060001CD RID: 461 RVA: 0x000231F8 File Offset: 0x000213F8
		private void checkBox31_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_999 = !Class64.bool_999;
		}

		// Token: 0x060001CE RID: 462 RVA: 0x00023208 File Offset: 0x00021408
		private void checkBox32_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_00 = !Class64.bool_00;
		}

		// Token: 0x060001CF RID: 463 RVA: 0x00023218 File Offset: 0x00021418
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("INFERNO_INFERNO_SEX_SEX_SEX", length)
			select s[UserControlSet.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060001D0 RID: 464 RVA: 0x00023263 File Offset: 0x00021463
		private void checkBox33_CheckedChanged(object sender, EventArgs e)
		{
			Class64.bool_818 = !Class64.bool_818;
		}

		// Token: 0x060001D1 RID: 465 RVA: 0x00023274 File Offset: 0x00021474
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x060001D2 RID: 466 RVA: 0x000232AC File Offset: 0x000214AC
		private void InitializeComponent()
		{
			this.mainpanel = new Panel();
			this.checkBox32 = new CheckBox();
			this.checkBox31 = new CheckBox();
			this.checkBox30 = new CheckBox();
			this.checkBox29 = new CheckBox();
			this.checkBox28 = new CheckBox();
			this.checkBox27 = new CheckBox();
			this.checkBox26 = new CheckBox();
			this.checkBox25 = new CheckBox();
			this.checkBox24 = new CheckBox();
			this.checkBox23 = new CheckBox();
			this.checkBox22 = new CheckBox();
			this.checkBox21 = new CheckBox();
			this.checkBox20 = new CheckBox();
			this.checkBox19 = new CheckBox();
			this.checkBox18 = new CheckBox();
			this.checkBox17 = new CheckBox();
			this.checkBox16 = new CheckBox();
			this.checkBox15 = new CheckBox();
			this.checkBox14 = new CheckBox();
			this.checkBox13 = new CheckBox();
			this.checkBox12 = new CheckBox();
			this.checkBox11 = new CheckBox();
			this.checkBox7 = new CheckBox();
			this.checkBox3 = new CheckBox();
			this.checkBox6 = new CheckBox();
			this.checkBox5 = new CheckBox();
			this.checkBox2 = new CheckBox();
			this.checkBox1 = new CheckBox();
			this.checkBox10 = new CheckBox();
			this.checkBox9 = new CheckBox();
			this.checkBox8 = new CheckBox();
			this.textBox1 = new TextBox();
			this.checkBox4 = new CheckBox();
			this.button1 = new Button();
			this.mainpanel.SuspendLayout();
			base.SuspendLayout();
			this.mainpanel.BackColor = Color.FromArgb(15, 30, 60);
			this.mainpanel.Controls.Add(this.checkBox32);
			this.mainpanel.Controls.Add(this.checkBox31);
			this.mainpanel.Controls.Add(this.checkBox30);
			this.mainpanel.Controls.Add(this.checkBox29);
			this.mainpanel.Controls.Add(this.checkBox28);
			this.mainpanel.Controls.Add(this.checkBox27);
			this.mainpanel.Controls.Add(this.checkBox26);
			this.mainpanel.Controls.Add(this.checkBox25);
			this.mainpanel.Controls.Add(this.checkBox24);
			this.mainpanel.Controls.Add(this.checkBox23);
			this.mainpanel.Controls.Add(this.checkBox22);
			this.mainpanel.Controls.Add(this.checkBox21);
			this.mainpanel.Controls.Add(this.checkBox20);
			this.mainpanel.Controls.Add(this.checkBox19);
			this.mainpanel.Controls.Add(this.checkBox18);
			this.mainpanel.Controls.Add(this.checkBox17);
			this.mainpanel.Controls.Add(this.checkBox16);
			this.mainpanel.Controls.Add(this.checkBox15);
			this.mainpanel.Controls.Add(this.checkBox14);
			this.mainpanel.Controls.Add(this.checkBox13);
			this.mainpanel.Controls.Add(this.checkBox12);
			this.mainpanel.Controls.Add(this.checkBox11);
			this.mainpanel.Controls.Add(this.checkBox7);
			this.mainpanel.Controls.Add(this.checkBox3);
			this.mainpanel.Controls.Add(this.checkBox6);
			this.mainpanel.Controls.Add(this.checkBox5);
			this.mainpanel.Controls.Add(this.checkBox2);
			this.mainpanel.Controls.Add(this.checkBox1);
			this.mainpanel.Controls.Add(this.checkBox10);
			this.mainpanel.Controls.Add(this.checkBox9);
			this.mainpanel.Controls.Add(this.checkBox8);
			this.mainpanel.Controls.Add(this.textBox1);
			this.mainpanel.Controls.Add(this.checkBox4);
			this.mainpanel.Controls.Add(this.button1);
			this.mainpanel.Location = new Point(0, 0);
			this.mainpanel.Name = "mainpanel";
			this.mainpanel.Size = new Size(935, 592);
			this.mainpanel.TabIndex = 11;
			this.mainpanel.Paint += this.mainpanel_Paint;
			this.checkBox32.AutoSize = true;
			this.checkBox32.ForeColor = Color.White;
			this.checkBox32.Location = new Point(434, 193);
			this.checkBox32.Name = "checkBox32";
			this.checkBox32.Size = new Size(124, 17);
			this.checkBox32.TabIndex = 41;
			this.checkBox32.Text = "Ressource Spammer";
			this.checkBox32.UseVisualStyleBackColor = true;
			this.checkBox32.CheckedChanged += this.checkBox32_CheckedChanged;
			this.checkBox31.AutoSize = true;
			this.checkBox31.ForeColor = Color.White;
			this.checkBox31.Location = new Point(434, 170);
			this.checkBox31.Name = "checkBox31";
			this.checkBox31.Size = new Size(108, 17);
			this.checkBox31.TabIndex = 40;
			this.checkBox31.Text = "Hide Methods V2";
			this.checkBox31.UseVisualStyleBackColor = true;
			this.checkBox31.CheckedChanged += this.checkBox31_CheckedChanged;
			this.checkBox30.AutoSize = true;
			this.checkBox30.ForeColor = Color.White;
			this.checkBox30.Location = new Point(434, 147);
			this.checkBox30.Name = "checkBox30";
			this.checkBox30.Size = new Size(79, 17);
			this.checkBox30.TabIndex = 39;
			this.checkBox30.Text = "Rename all";
			this.checkBox30.UseVisualStyleBackColor = true;
			this.checkBox30.CheckedChanged += this.checkBox30_CheckedChanged;
			this.checkBox29.AutoSize = true;
			this.checkBox29.ForeColor = Color.White;
			this.checkBox29.Location = new Point(434, 124);
			this.checkBox29.Name = "checkBox29";
			this.checkBox29.Size = new Size(122, 17);
			this.checkBox29.TabIndex = 38;
			this.checkBox29.Text = "Encrypt Numbers v2";
			this.checkBox29.UseVisualStyleBackColor = true;
			this.checkBox29.CheckedChanged += this.checkBox29_CheckedChanged;
			this.checkBox28.AutoSize = true;
			this.checkBox28.ForeColor = Color.White;
			this.checkBox28.Location = new Point(434, 101);
			this.checkBox28.Name = "checkBox28";
			this.checkBox28.Size = new Size(122, 17);
			this.checkBox28.TabIndex = 37;
			this.checkBox28.Text = "String Encryption V4";
			this.checkBox28.UseVisualStyleBackColor = true;
			this.checkBox28.CheckedChanged += this.checkBox28_CheckedChanged_2;
			this.checkBox27.AutoSize = true;
			this.checkBox27.ForeColor = Color.White;
			this.checkBox27.Location = new Point(434, 78);
			this.checkBox27.Name = "checkBox27";
			this.checkBox27.Size = new Size(73, 17);
			this.checkBox27.TabIndex = 36;
			this.checkBox27.Text = "Anti dumb";
			this.checkBox27.UseVisualStyleBackColor = true;
			this.checkBox27.CheckedChanged += this.checkBox27_CheckedChanged;
			this.checkBox26.AutoSize = true;
			this.checkBox26.ForeColor = Color.White;
			this.checkBox26.Location = new Point(434, 55);
			this.checkBox26.Name = "checkBox26";
			this.checkBox26.Size = new Size(122, 17);
			this.checkBox26.TabIndex = 35;
			this.checkBox26.Text = "MetaStrip Protection";
			this.checkBox26.UseVisualStyleBackColor = true;
			this.checkBox26.CheckedChanged += this.checkBox26_CheckedChanged;
			this.checkBox25.AutoSize = true;
			this.checkBox25.ForeColor = Color.White;
			this.checkBox25.Location = new Point(434, 32);
			this.checkBox25.Name = "checkBox25";
			this.checkBox25.Size = new Size(153, 17);
			this.checkBox25.TabIndex = 34;
			this.checkBox25.Text = "Random Outline Protection";
			this.checkBox25.UseVisualStyleBackColor = true;
			this.checkBox25.CheckedChanged += this.checkBox25_CheckedChanged;
			this.checkBox24.AutoSize = true;
			this.checkBox24.ForeColor = Color.White;
			this.checkBox24.Location = new Point(235, 285);
			this.checkBox24.Name = "checkBox24";
			this.checkBox24.Size = new Size(105, 17);
			this.checkBox24.TabIndex = 33;
			this.checkBox24.Text = "Local to Field V3";
			this.checkBox24.UseVisualStyleBackColor = true;
			this.checkBox24.CheckedChanged += this.checkBox24_CheckedChanged;
			this.checkBox23.AutoSize = true;
			this.checkBox23.ForeColor = Color.White;
			this.checkBox23.Location = new Point(235, 262);
			this.checkBox23.Name = "checkBox23";
			this.checkBox23.Size = new Size(105, 17);
			this.checkBox23.TabIndex = 32;
			this.checkBox23.Text = "Local to Field V2";
			this.checkBox23.UseVisualStyleBackColor = true;
			this.checkBox23.CheckedChanged += this.checkBox23_CheckedChanged;
			this.checkBox22.AutoSize = true;
			this.checkBox22.ForeColor = Color.White;
			this.checkBox22.Location = new Point(235, 239);
			this.checkBox22.Name = "checkBox22";
			this.checkBox22.Size = new Size(77, 17);
			this.checkBox22.TabIndex = 31;
			this.checkBox22.Text = "Single Calli";
			this.checkBox22.UseVisualStyleBackColor = true;
			this.checkBox22.CheckedChanged += this.checkBox22_CheckedChanged;
			this.checkBox21.AutoSize = true;
			this.checkBox21.ForeColor = Color.White;
			this.checkBox21.Location = new Point(235, 216);
			this.checkBox21.Name = "checkBox21";
			this.checkBox21.Size = new Size(101, 17);
			this.checkBox21.TabIndex = 30;
			this.checkBox21.Text = "Math Protection";
			this.checkBox21.UseVisualStyleBackColor = true;
			this.checkBox21.CheckedChanged += this.checkBox21_CheckedChanged;
			this.checkBox20.AutoSize = true;
			this.checkBox20.ForeColor = Color.White;
			this.checkBox20.Location = new Point(235, 193);
			this.checkBox20.Name = "checkBox20";
			this.checkBox20.Size = new Size(88, 17);
			this.checkBox20.TabIndex = 29;
			this.checkBox20.Text = "Ref Proxy V2";
			this.checkBox20.UseVisualStyleBackColor = true;
			this.checkBox20.CheckedChanged += this.checkBox20_CheckedChanged;
			this.checkBox19.AutoSize = true;
			this.checkBox19.ForeColor = Color.White;
			this.checkBox19.Location = new Point(235, 170);
			this.checkBox19.Name = "checkBox19";
			this.checkBox19.Size = new Size(122, 17);
			this.checkBox19.TabIndex = 28;
			this.checkBox19.Text = "String Encryption V3";
			this.checkBox19.UseVisualStyleBackColor = true;
			this.checkBox19.CheckedChanged += this.checkBox19_CheckedChanged;
			this.checkBox18.AutoSize = true;
			this.checkBox18.ForeColor = Color.White;
			this.checkBox18.Location = new Point(235, 147);
			this.checkBox18.Name = "checkBox18";
			this.checkBox18.Size = new Size(122, 17);
			this.checkBox18.TabIndex = 27;
			this.checkBox18.Text = "String Encryption V2";
			this.checkBox18.UseVisualStyleBackColor = true;
			this.checkBox18.CheckedChanged += this.checkBox18_CheckedChanged;
			this.checkBox17.AutoSize = true;
			this.checkBox17.ForeColor = Color.White;
			this.checkBox17.Location = new Point(235, 124);
			this.checkBox17.Name = "checkBox17";
			this.checkBox17.Size = new Size(84, 17);
			this.checkBox17.TabIndex = 26;
			this.checkBox17.Text = "Renamer v2";
			this.checkBox17.UseVisualStyleBackColor = true;
			this.checkBox17.CheckedChanged += this.checkBox17_CheckedChanged;
			this.checkBox16.AutoSize = true;
			this.checkBox16.ForeColor = Color.White;
			this.checkBox16.Location = new Point(235, 101);
			this.checkBox16.Name = "checkBox16";
			this.checkBox16.Size = new Size(72, 17);
			this.checkBox16.TabIndex = 25;
			this.checkBox16.Text = "Ref Proxy";
			this.checkBox16.UseVisualStyleBackColor = true;
			this.checkBox16.CheckedChanged += this.checkBox16_CheckedChanged;
			this.checkBox15.AutoSize = true;
			this.checkBox15.ForeColor = Color.White;
			this.checkBox15.Location = new Point(235, 78);
			this.checkBox15.Name = "checkBox15";
			this.checkBox15.Size = new Size(112, 17);
			this.checkBox15.TabIndex = 24;
			this.checkBox15.Text = "Constant Mutation";
			this.checkBox15.UseVisualStyleBackColor = true;
			this.checkBox15.CheckedChanged += this.checkBox15_CheckedChanged;
			this.checkBox14.AutoSize = true;
			this.checkBox14.ForeColor = Color.White;
			this.checkBox14.Location = new Point(235, 55);
			this.checkBox14.Name = "checkBox14";
			this.checkBox14.Size = new Size(89, 17);
			this.checkBox14.TabIndex = 23;
			this.checkBox14.Text = "Local to Field";
			this.checkBox14.UseVisualStyleBackColor = true;
			this.checkBox14.CheckedChanged += this.checkBox14_CheckedChanged;
			this.checkBox13.AutoSize = true;
			this.checkBox13.ForeColor = Color.White;
			this.checkBox13.Location = new Point(235, 32);
			this.checkBox13.Name = "checkBox13";
			this.checkBox13.Size = new Size(80, 17);
			this.checkBox13.TabIndex = 22;
			this.checkBox13.Text = "Anti de4dot";
			this.checkBox13.UseVisualStyleBackColor = true;
			this.checkBox13.CheckedChanged += this.checkBox13_CheckedChanged;
			this.checkBox12.AutoSize = true;
			this.checkBox12.ForeColor = Color.White;
			this.checkBox12.Location = new Point(23, 279);
			this.checkBox12.Name = "checkBox12";
			this.checkBox12.Size = new Size(57, 17);
			this.checkBox12.TabIndex = 21;
			this.checkBox12.Text = "SizeOf";
			this.checkBox12.UseVisualStyleBackColor = true;
			this.checkBox12.CheckedChanged += this.checkBox12_CheckedChanged;
			this.checkBox11.AutoSize = true;
			this.checkBox11.ForeColor = Color.White;
			this.checkBox11.Location = new Point(23, 256);
			this.checkBox11.Name = "checkBox11";
			this.checkBox11.Size = new Size(112, 17);
			this.checkBox11.TabIndex = 20;
			this.checkBox11.Text = "Fake Virtualization";
			this.checkBox11.UseVisualStyleBackColor = true;
			this.checkBox11.CheckedChanged += this.checkBox11_CheckedChanged;
			this.checkBox7.AutoSize = true;
			this.checkBox7.ForeColor = Color.White;
			this.checkBox7.Location = new Point(23, 233);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.Size = new Size(106, 17);
			this.checkBox7.TabIndex = 19;
			this.checkBox7.Text = "String Encryption";
			this.checkBox7.UseVisualStyleBackColor = true;
			this.checkBox7.CheckedChanged += this.checkBox7_CheckedChanged;
			this.checkBox3.AutoSize = true;
			this.checkBox3.ForeColor = Color.White;
			this.checkBox3.Location = new Point(23, 210);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.Size = new Size(116, 17);
			this.checkBox3.TabIndex = 18;
			this.checkBox3.Text = "Number Encryption";
			this.checkBox3.UseVisualStyleBackColor = true;
			this.checkBox3.CheckedChanged += this.checkBox3_CheckedChanged;
			this.checkBox6.AutoSize = true;
			this.checkBox6.ForeColor = Color.White;
			this.checkBox6.Location = new Point(23, 164);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.Size = new Size(162, 17);
			this.checkBox6.TabIndex = 17;
			this.checkBox6.Text = "Use Calli for Call Obfuscation";
			this.checkBox6.UseVisualStyleBackColor = true;
			this.checkBox6.CheckedChanged += this.checkBox6_CheckedChanged;
			this.checkBox5.AutoSize = true;
			this.checkBox5.ForeColor = Color.White;
			this.checkBox5.Location = new Point(23, 187);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.Size = new Size(111, 17);
			this.checkBox5.TabIndex = 16;
			this.checkBox5.Text = "Fake VM Attribute";
			this.checkBox5.UseVisualStyleBackColor = true;
			this.checkBox5.CheckedChanged += this.checkBox5_CheckedChanged;
			this.checkBox2.AutoSize = true;
			this.checkBox2.ForeColor = Color.White;
			this.checkBox2.Location = new Point(23, 122);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.Size = new Size(67, 17);
			this.checkBox2.TabIndex = 14;
			this.checkBox2.Text = "Mutation";
			this.checkBox2.UseVisualStyleBackColor = true;
			this.checkBox2.CheckedChanged += this.checkBox2_CheckedChanged;
			this.checkBox1.AutoSize = true;
			this.checkBox1.ForeColor = Color.White;
			this.checkBox1.Location = new Point(23, 143);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.Size = new Size(119, 17);
			this.checkBox1.TabIndex = 13;
			this.checkBox1.Text = "Obfuscate Methods";
			this.checkBox1.UseVisualStyleBackColor = true;
			this.checkBox1.CheckedChanged += this.checkBox1_CheckedChanged_1;
			this.checkBox10.AutoSize = true;
			this.checkBox10.ForeColor = Color.White;
			this.checkBox10.Location = new Point(23, 78);
			this.checkBox10.Name = "checkBox10";
			this.checkBox10.Size = new Size(103, 17);
			this.checkBox10.TabIndex = 12;
			this.checkBox10.Text = "Call Obfuscation";
			this.checkBox10.UseVisualStyleBackColor = true;
			this.checkBox10.CheckedChanged += this.checkBox10_CheckedChanged;
			this.checkBox9.AutoSize = true;
			this.checkBox9.ForeColor = Color.White;
			this.checkBox9.Location = new Point(23, 101);
			this.checkBox9.Name = "checkBox9";
			this.checkBox9.Size = new Size(116, 17);
			this.checkBox9.TabIndex = 11;
			this.checkBox9.Text = "Weak Control Flow";
			this.checkBox9.UseVisualStyleBackColor = true;
			this.checkBox9.CheckedChanged += this.checkBox9_CheckedChanged;
			this.checkBox8.AutoSize = true;
			this.checkBox8.ForeColor = Color.White;
			this.checkBox8.Location = new Point(23, 55);
			this.checkBox8.Name = "checkBox8";
			this.checkBox8.Size = new Size(122, 17);
			this.checkBox8.TabIndex = 10;
			this.checkBox8.Text = "Obfuscate Assembly";
			this.checkBox8.UseVisualStyleBackColor = true;
			this.checkBox8.CheckedChanged += this.checkBox8_CheckedChanged;
			this.textBox1.AllowDrop = true;
			this.textBox1.BackColor = Color.FromArgb(15, 30, 60);
			this.textBox1.BorderStyle = BorderStyle.FixedSingle;
			this.textBox1.ForeColor = Color.White;
			this.textBox1.Location = new Point(104, 339);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new Size(232, 23);
			this.textBox1.TabIndex = 9;
			this.textBox1.Text = "Drag your Application here..";
			this.textBox1.TextChanged += this.textBox1_TextChanged_1;
			this.textBox1.DragDrop += this.textBox1_DragDrop_1;
			this.textBox1.DragEnter += this.textBox1_DragEnter_1;
			this.checkBox4.AutoSize = true;
			this.checkBox4.ForeColor = Color.White;
			this.checkBox4.Location = new Point(23, 32);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.Size = new Size(69, 17);
			this.checkBox4.TabIndex = 5;
			this.checkBox4.Text = "Renamer";
			this.checkBox4.UseVisualStyleBackColor = true;
			this.checkBox4.CheckedChanged += this.checkBox4_CheckedChanged;
			this.button1.BackColor = Color.FromArgb(15, 30, 60);
			this.button1.FlatStyle = FlatStyle.Flat;
			this.button1.ForeColor = Color.White;
			this.button1.Location = new Point(104, 368);
			this.button1.Name = "button1";
			this.button1.Size = new Size(232, 51);
			this.button1.TabIndex = 1;
			this.button1.Text = "Protect";
			this.button1.UseVisualStyleBackColor = false;
			this.button1.Click += this.button1_Click;
			base.AutoScaleDimensions = new SizeF(6f, 13f);
			base.AutoScaleMode = AutoScaleMode.Font;
			base.Controls.Add(this.mainpanel);
			base.Name = "UserControlSet";
			base.Size = new Size(935, 592);
			base.Load += this.UserControlSet_Load;
			this.mainpanel.ResumeLayout(false);
			this.mainpanel.PerformLayout();
			base.ResumeLayout(false);
		}

		// Token: 0x040000E0 RID: 224
		public static MethodDef Init;

		// Token: 0x040000E1 RID: 225
		public static MethodDef Init2;

		// Token: 0x040000E2 RID: 226
		private bool encryptstring = false;

		// Token: 0x040000E3 RID: 227
		public const int int_0 = 161;

		// Token: 0x040000E4 RID: 228
		public const int int_1 = 2;

		// Token: 0x040000E5 RID: 229
		public static bool bool_0;

		// Token: 0x040000E6 RID: 230
		public static bool bool_1;

		// Token: 0x040000E7 RID: 231
		public static bool flag13 = false;

		// Token: 0x040000E8 RID: 232
		public static bool flag = false;

		// Token: 0x040000E9 RID: 233
		private IContainer icontainer_0;

		// Token: 0x040000EA RID: 234
		private static Random random = new Random();

		// Token: 0x040000EB RID: 235
		private IContainer components = null;

		// Token: 0x040000EC RID: 236
		private Panel mainpanel;

		// Token: 0x040000ED RID: 237
		private Button button1;

		// Token: 0x040000EE RID: 238
		private CheckBox checkBox4;

		// Token: 0x040000EF RID: 239
		private TextBox textBox1;

		// Token: 0x040000F0 RID: 240
		private CheckBox checkBox10;

		// Token: 0x040000F1 RID: 241
		private CheckBox checkBox9;

		// Token: 0x040000F2 RID: 242
		private CheckBox checkBox8;

		// Token: 0x040000F3 RID: 243
		private CheckBox checkBox2;

		// Token: 0x040000F4 RID: 244
		private CheckBox checkBox1;

		// Token: 0x040000F5 RID: 245
		private CheckBox checkBox6;

		// Token: 0x040000F6 RID: 246
		private CheckBox checkBox5;

		// Token: 0x040000F7 RID: 247
		private CheckBox checkBox7;

		// Token: 0x040000F8 RID: 248
		private CheckBox checkBox3;

		// Token: 0x040000F9 RID: 249
		private CheckBox checkBox11;

		// Token: 0x040000FA RID: 250
		private CheckBox checkBox12;

		// Token: 0x040000FB RID: 251
		private CheckBox checkBox13;

		// Token: 0x040000FC RID: 252
		private CheckBox checkBox14;

		// Token: 0x040000FD RID: 253
		private CheckBox checkBox15;

		// Token: 0x040000FE RID: 254
		private CheckBox checkBox16;

		// Token: 0x040000FF RID: 255
		private CheckBox checkBox17;

		// Token: 0x04000100 RID: 256
		private CheckBox checkBox18;

		// Token: 0x04000101 RID: 257
		private CheckBox checkBox19;

		// Token: 0x04000102 RID: 258
		private CheckBox checkBox20;

		// Token: 0x04000103 RID: 259
		private CheckBox checkBox21;

		// Token: 0x04000104 RID: 260
		private CheckBox checkBox22;

		// Token: 0x04000105 RID: 261
		private CheckBox checkBox23;

		// Token: 0x04000106 RID: 262
		private CheckBox checkBox24;

		// Token: 0x04000107 RID: 263
		private CheckBox checkBox25;

		// Token: 0x04000108 RID: 264
		private CheckBox checkBox26;

		// Token: 0x04000109 RID: 265
		private CheckBox checkBox27;

		// Token: 0x0400010A RID: 266
		private CheckBox checkBox28;

		// Token: 0x0400010B RID: 267
		private CheckBox checkBox29;

		// Token: 0x0400010C RID: 268
		private CheckBox checkBox30;

		// Token: 0x0400010D RID: 269
		private CheckBox checkBox31;

		// Token: 0x0400010E RID: 270
		private CheckBox checkBox32;
	}
}
