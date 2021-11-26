using System;
using System.Net;
using System.Reflection;

namespace Inferno_Obfuscation.String_Online
{
	// Token: 0x0200005F RID: 95
	internal class OnlineString
	{
		// Token: 0x060001FB RID: 507 RVA: 0x00028668 File Offset: 0x00026868
		public static string Decoder(string encrypted)
		{
			bool flag = Assembly.GetExecutingAssembly() != Assembly.GetCallingAssembly();
			string result;
			if (flag)
			{
				result = "AyorahOBF.protect";
			}
			else
			{
				WebClient webClient = new WebClient();
				result = webClient.DownloadString("https://www.instagram.com/encorecfw/");
			}
			return result;
		}
	}
}
