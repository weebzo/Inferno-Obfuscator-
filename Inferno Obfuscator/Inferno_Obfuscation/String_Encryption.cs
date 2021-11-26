using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000053 RID: 83
	internal class String_Encryption
	{
		// Token: 0x06000197 RID: 407 RVA: 0x0002284C File Offset: 0x00020A4C
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(String_Encryption).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(String_Encryption).MetadataToken));
			IEnumerable<IDnlibDef> enumerable = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x06000198 RID: 408 RVA: 0x0002290C File Offset: 0x00020B0C
		public static string Encrypt(string plainText)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(plainText);
			byte[] bytes2 = new Rfc2898DeriveBytes(String_Encryption.PasswordHash, Encoding.ASCII.GetBytes(String_Encryption.SaltKey)).GetBytes(32);
			RijndaelManaged rijndaelManaged = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.Zeros
			};
			ICryptoTransform transform = rijndaelManaged.CreateEncryptor(bytes2, Encoding.ASCII.GetBytes(String_Encryption.VIKey));
			byte[] inArray;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write))
				{
					cryptoStream.Write(bytes, 0, bytes.Length);
					cryptoStream.FlushFinalBlock();
					inArray = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00022A00 File Offset: 0x00020C00
		public static void Inject(ModuleDef module)
		{
			String_Encryption.InjectClass(module);
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag = !isGlobalModuleType;
				bool flag6 = flag;
				if (flag6)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag2 = !methodDef.HasBody;
						bool flag3 = !flag2;
						bool flag7 = flag3;
						if (flag7)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count - 3; i++)
							{
								bool flag4 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag5 = flag4;
								bool flag8 = flag5;
								if (flag8)
								{
									string plainText = instructions[i].Operand as string;
									string operand = String_Encryption.Encrypt(plainText);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, String_Encryption.init));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x040000D6 RID: 214
		public static Random random = new Random();

		// Token: 0x040000D7 RID: 215
		private static IMethod _decrypt;

		// Token: 0x040000D8 RID: 216
		private static ModuleDef _mod;

		// Token: 0x040000D9 RID: 217
		public static MethodDef init;

		// Token: 0x040000DA RID: 218
		private static readonly string PasswordHash = "P@@$Sw0rd";

		// Token: 0x040000DB RID: 219
		private static readonly string SaltKey = "S@L$%^#T&&$%*%^$^#$KEY";

		// Token: 0x040000DC RID: 220
		private static readonly string VIKey = "@1B2c3D4e5F6g7H8";
	}
}
