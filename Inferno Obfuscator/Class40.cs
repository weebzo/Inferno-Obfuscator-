using System;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

// Token: 0x0200000C RID: 12
internal class Class40
{
	// Token: 0x06000040 RID: 64 RVA: 0x00008240 File Offset: 0x00006440
	public static int smethod_0(string string_0)
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
		byte[] array2 = Convert.FromBase64String(Encoding.UTF8.GetString(bytes));
		byte[] array3 = SHA1.Create().ComputeHash(BitConverter.GetBytes(1993));
		for (int i = array2.Length * 2 + array3.Length; i >= 0; i += -1)
		{
			array2[i % array2.Length] = (byte)(((int)((array2[i % array2.Length] ^ array3[i % array3.Length]) - array2[(i + 1) % array2.Length]) + 256) % 256);
		}
		return BitConverter.ToInt32(array2, 0);
	}

	// Token: 0x06000041 RID: 65 RVA: 0x00008320 File Offset: 0x00006520
	public static float smethod_1(string string_0)
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
		byte[] array2 = Convert.FromBase64String(Encoding.UTF8.GetString(bytes));
		byte[] array3 = SHA1.Create().ComputeHash(BitConverter.GetBytes(1993));
		for (int i = array2.Length * 2 + array3.Length; i >= 0; i += -1)
		{
			array2[i % array2.Length] = (byte)(((int)((array2[i % array2.Length] ^ array3[i % array3.Length]) - array2[(i + 1) % array2.Length]) + 256) % 256);
		}
		return float.Parse(Encoding.UTF8.GetString(array2, 0, array2.Length));
	}

	// Token: 0x06000042 RID: 66 RVA: 0x0000840C File Offset: 0x0000660C
	public static long smethod_2(string string_0)
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
		byte[] array2 = Convert.FromBase64String(Encoding.UTF8.GetString(bytes));
		byte[] array3 = SHA1.Create().ComputeHash(BitConverter.GetBytes(1993));
		for (int i = array2.Length * 2 + array3.Length; i >= 0; i += -1)
		{
			array2[i % array2.Length] = (byte)(((int)((array2[i % array2.Length] ^ array3[i % array3.Length]) - array2[(i + 1) % array2.Length]) + 256) % 256);
		}
		return long.Parse(Encoding.UTF8.GetString(array2, 0, array2.Length));
	}
}
