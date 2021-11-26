using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace Inferno_Obfuscation
{
	// Token: 0x0200002F RID: 47
	internal class EncryptionHelper
	{
		// Token: 0x060000F5 RID: 245 RVA: 0x000173DC File Offset: 0x000155DC
		public static void Generate()
		{
			using (Stream manifestResourceStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("InfernoOBF.Protect"))
			{
				using (StreamReader streamReader = new StreamReader(new MemoryStream(EncryptionHelper.UnHush(EncryptionHelper.Read(manifestResourceStream)))))
				{
					EncryptionHelper._list = streamReader.ReadToEnd().Split(new string[]
					{
						Environment.NewLine
					}, StringSplitOptions.None).ToList<string>();
				}
			}
		}

		// Token: 0x060000F6 RID: 246 RVA: 0x00017470 File Offset: 0x00015670
		public static string Search(int key)
		{
			return EncryptionHelper._list.ElementAt(key);
		}

		// Token: 0x060000F7 RID: 247 RVA: 0x00017490 File Offset: 0x00015690
		private static byte[] Read(Stream input)
		{
			byte[] result;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				input.CopyTo(memoryStream);
				result = memoryStream.ToArray();
			}
			return result;
		}

		// Token: 0x060000F8 RID: 248 RVA: 0x000174D4 File Offset: 0x000156D4
		public static byte[] UnHush(byte[] text)
		{
			byte[] key = new Rfc2898DeriveBytes("p7K95451qB88sZ7J", Encoding.ASCII.GetBytes("2GM23j301t60Z96T")).GetBytes(32);
			byte[] xor = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				xor[i] = (text[i] ^ key[i % key.Length]);
			}
			return xor;
		}

		// Token: 0x060000F9 RID: 249 RVA: 0x00017538 File Offset: 0x00015738
		public static string Decrypt(string encryptedText)
		{
			bool flag = Assembly.GetExecutingAssembly() != Assembly.GetCallingAssembly();
			string result;
			if (flag)
			{
				result = "InfernoOBF.Protect";
			}
			else
			{
				byte[] cipherTextBytes = Convert.FromBase64String(encryptedText);
				byte[] keyBytes = new Rfc2898DeriveBytes("p7K95451qB88sZ7J", Encoding.ASCII.GetBytes("2GM23j301t60Z96T")).GetBytes(32);
				RijndaelManaged symmetricKey = new RijndaelManaged
				{
					Mode = CipherMode.CBC,
					Padding = PaddingMode.PKCS7
				};
				ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes("IzTdhG6S8uwg141S"));
				MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
				CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
				byte[] plainTextBytes = new byte[cipherTextBytes.Length];
				int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
				memoryStream.Close();
				cryptoStream.Close();
				result = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
			}
			return result;
		}

		// Token: 0x0400006C RID: 108
		private const string PasswordHash = "p7K95451qB88sZ7J";

		// Token: 0x0400006D RID: 109
		private const string SaltKey = "2GM23j301t60Z96T";

		// Token: 0x0400006E RID: 110
		private const string VIKey = "IzTdhG6S8uwg141S";

		// Token: 0x0400006F RID: 111
		private static List<string> _list = new List<string>();
	}
}
