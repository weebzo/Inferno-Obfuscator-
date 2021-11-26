using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Protector
{
	// Token: 0x0200001A RID: 26
	internal static class Generator
	{
		// Token: 0x06000080 RID: 128 RVA: 0x0000C4F0 File Offset: 0x0000A6F0
		public static string GenerateString()
		{
			int lengt = 2;
			byte[] buffer = new byte[lengt];
			new RNGCryptoServiceProvider().GetBytes(buffer);
			string str_result = null;
			for (int i = 0; i < 200; i++)
			{
				str_result += "_";
			}
			str_result += Generator.EncodeString(buffer, Generator.unicodeCharset);
			int counter = int.MaxValue;
			foreach (byte b in buffer)
			{
				counter--;
				str_result += ((char)((int)b ^ counter)).ToString();
			}
			return str_result;
		}

		// Token: 0x06000081 RID: 129 RVA: 0x0000C598 File Offset: 0x0000A798
		private static string EncodeString(byte[] buff, char[] charset)
		{
			int current = (int)buff[0];
			StringBuilder ret = new StringBuilder();
			for (int i = 1; i < buff.Length; i++)
			{
				for (current = (current << 8) + (int)buff[i]; current >= charset.Length; current /= charset.Length)
				{
					ret.Append(charset[current % charset.Length]);
				}
			}
			bool flag = current != 0;
			if (flag)
			{
				ret.Append(charset[current % charset.Length]);
			}
			return ret.ToString();
		}

		// Token: 0x06000082 RID: 130 RVA: 0x0000C618 File Offset: 0x0000A818
		public static byte[] GetBytes(int lenght)
		{
			byte[] b = new byte[lenght];
			new RNGCryptoServiceProvider().GetBytes(b);
			return b;
		}

		// Token: 0x04000054 RID: 84
		private static readonly char[] unicodeCharset = new char[0].Concat(from ord in Enumerable.Range(8203, 5)
		select (char)ord).Concat(from ord in Enumerable.Range(8233, 6)
		select (char)ord).Concat(from ord in Enumerable.Range(8298, 6)
		select (char)ord).Except(new char[]
		{
			'†'
		}).ToArray<char>();
	}
}
