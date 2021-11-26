using System;
using System.Windows.Forms;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000045 RID: 69
	internal static class Program
	{
		// Token: 0x06000154 RID: 340 RVA: 0x0001BA27 File Offset: 0x00019C27
		[STAThread]
		private static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new Login());
		}

		// Token: 0x17000007 RID: 7
		// (get) Token: 0x06000155 RID: 341 RVA: 0x0001BA42 File Offset: 0x00019C42
		// (set) Token: 0x06000156 RID: 342 RVA: 0x0001BA49 File Offset: 0x00019C49
		public static ModuleDefMD Module { get; set; }
	}
}
