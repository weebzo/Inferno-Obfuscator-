using System;
using System.Security.Cryptography;
using System.Text;

namespace Inferno_Obfuscation
{
	// Token: 0x0200004F RID: 79
	public class SecureRandoms
	{
		// Token: 0x06000186 RID: 390 RVA: 0x00021448 File Offset: 0x0001F648
		public static int Next(int minValue, int maxExclusiveValue)
		{
			bool flag = minValue >= maxExclusiveValue;
			if (flag)
			{
				throw new ArgumentOutOfRangeException("minValue must be lower than maxExclusiveValue");
			}
			long diff = (long)maxExclusiveValue - (long)minValue;
			long upperBound = (long)((ulong)-1 / (ulong)diff * (ulong)diff);
			uint ui;
			do
			{
				ui = SecureRandoms.GetRandomUInt();
			}
			while ((ulong)ui >= (ulong)upperBound);
			return (int)((long)minValue + (long)((ulong)ui % (ulong)diff));
		}

		// Token: 0x06000187 RID: 391 RVA: 0x000214A0 File Offset: 0x0001F6A0
		private static uint GetRandomUInt()
		{
			byte[] randomBytes = SecureRandoms.GenerateRandomBytes(4);
			return BitConverter.ToUInt32(randomBytes, 0);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x000214C0 File Offset: 0x0001F6C0
		private static byte[] GenerateRandomBytes(int bytesNumber)
		{
			byte[] buffer = new byte[bytesNumber];
			SecureRandoms.csp.GetBytes(buffer);
			return buffer;
		}

		// Token: 0x06000189 RID: 393 RVA: 0x000214E8 File Offset: 0x0001F6E8
		public static string GenerateRandomString(int size)
		{
			byte[] data = new byte[4 * size];
			using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
			{
				crypto.GetBytes(data);
			}
			StringBuilder result = new StringBuilder(size);
			for (int i = 0; i < size; i++)
			{
				uint rnd = BitConverter.ToUInt32(data, i * 4);
				long idx = (long)((ulong)rnd % (ulong)((long)SecureRandoms.chars.Length));
				result.Append(SecureRandoms.chars[(int)(checked((IntPtr)idx))]);
			}
			return result.ToString();
		}

		// Token: 0x040000AC RID: 172
		private static readonly RNGCryptoServiceProvider csp = new RNGCryptoServiceProvider();

		// Token: 0x040000AD RID: 173
		internal static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOP痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵畲畲QRSTUVWXYZ1234567890".ToCharArray();
	}
}
