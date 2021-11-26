using System;
using System.Reflection;
using System.Windows.Forms;

// Token: 0x02000012 RID: 18
internal class Class51
{
	// Token: 0x06000059 RID: 89 RVA: 0x00009F4C File Offset: 0x0000814C
	public static void smethod_0()
	{
		bool flag = MethodBase.GetCurrentMethod().Name != "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞";
		if (flag)
		{
			MessageBox.Show("Inferno Obfuscator has detected a renamer change, the application will now close!");
			Environment.Exit(0);
		}
	}

	// Token: 0x0600005A RID: 90 RVA: 0x00009F88 File Offset: 0x00008188
	public static void smethod_1(string string_0, MethodBase methodBase_0)
	{
		bool flag = methodBase_0.Name != string_0;
		if (flag)
		{
			MessageBox.Show("Inferno Obfuscator has detected a renamer change, the application will now close!");
			Environment.Exit(0);
		}
	}
}
