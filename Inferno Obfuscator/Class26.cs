using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

// Token: 0x02000007 RID: 7
internal class Class26
{
	// Token: 0x06000024 RID: 36 RVA: 0x00006E2C File Offset: 0x0000502C
	public static string smethod_0(string string_0, DateTime dateTime_0)
	{
		int num = string_0.Length / 16;
		long[] array = new long[num];
		for (int i = 0; i < num; i++)
		{
			array[i] = Convert.ToInt64(string_0.Substring(i * 16, 16), 16);
		}
		byte[] bytes = Encoding.UTF8.GetBytes(dateTime_0.Ticks.ToString().PadRight(32, '\0'));
		int num2 = ((bytes.Length % 8 == 0) ? 0 : 1) + bytes.Length / 8;
		long[] array2 = new long[num2];
		for (int j = 0; j < num2 - 1; j++)
		{
			array2[j] = BitConverter.ToInt64(bytes, j * 8);
		}
		byte[] array3 = new byte[8];
		Array.Copy(bytes, (num2 - 1) * 8, array3, 0, bytes.Length - (num2 - 1) * 8);
		array2[num2 - 1] = BitConverter.ToInt64(array3, 0);
		int num3 = array.Length;
		bool flag = num3 < 1;
		string result;
		if (flag)
		{
			result = string_0;
		}
		else
		{
			long num4 = array[array.Length - 1];
			long num5 = array[0];
			for (long num6 = (long)(6 + 52 / num3) * (long)((ulong)-1640531527); num6 != 0L; num6 -= (long)((ulong)-1640531527))
			{
				long num7 = num6 >> 2 & 3L;
				long num8;
				for (num8 = (long)(num3 - 1); num8 > 0L; num8 -= 1L)
				{
					num4 = array[(int)((IntPtr)(num8 - 1L))];
					num5 = (array[(int)((IntPtr)num8)] -= ((num4 >> 5 ^ num5 << 2) + (num5 >> 3 ^ num4 << 4) ^ (num6 ^ num5) + (array2[(int)((IntPtr)((num8 & 3L) ^ num7))] ^ num4)));
				}
				num4 = array[num3 - 1];
				num5 = (array[0] -= ((num4 >> 5 ^ num5 << 2) + (num5 >> 3 ^ num4 << 4) ^ (num6 ^ num5) + (array2[(int)((IntPtr)((num8 & 3L) ^ num7))] ^ num4)));
			}
			List<byte> list = new List<byte>(array.Length * 8);
			for (int k = 0; k < array.Length; k++)
			{
				list.AddRange(BitConverter.GetBytes(array[k]));
			}
			while (list[list.Count - 1] == 0)
			{
				list.RemoveAt(list.Count - 1);
			}
			byte[] array4 = list.ToArray();
			result = Encoding.UTF8.GetString(array4, 0, array4.Length);
		}
		return result;
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000070C4 File Offset: 0x000052C4
	public static string smethod_1(string string_0, DateTime dateTime_0)
	{
		byte[] bytes = new byte[0];
		Stream manifestResourceStream = MethodBase.GetCurrentMethod().Module.Assembly.GetManifestResourceStream(string_0);
		bool flag = manifestResourceStream != null;
		if (flag)
		{
			byte[] array = new byte[manifestResourceStream.Length];
			manifestResourceStream.Read(array, 0, array.Length);
			bytes = array;
		}
		return Class26.smethod_0(Encoding.UTF8.GetString(bytes), dateTime_0);
	}
}
