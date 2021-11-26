using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000052 RID: 82
	public static class StringEncPhase
	{
		// Token: 0x06000192 RID: 402 RVA: 0x00022328 File Offset: 0x00020528
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD typeModule = ModuleDefMD.Load(typeof(EncryptionHelper).Module);
			TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(EncryptionHelper).MetadataToken));
			IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, module.GlobalType, module);
			UserControlSet.Init = (MethodDef)members.Single((IDnlibDef method) => method.Name == "Decrypt");
			MethodDef cctor = module.GlobalType.FindStaticConstructor();
			UserControlSet.Init2 = (MethodDef)members.Single((IDnlibDef method) => method.Name == "Search");
			MethodDef init = (MethodDef)members.Single((IDnlibDef method) => method.Name == "Generate");
			cctor.Body.Instructions.Insert(cctor.Body.Instructions.Count - 1, Instruction.Create(OpCodes.Call, init));
			foreach (MethodDef md in module.GlobalType.Methods)
			{
				bool flag = md.Name == ".ctor";
				if (flag)
				{
					module.GlobalType.Remove(md);
					break;
				}
			}
		}

		// Token: 0x06000193 RID: 403 RVA: 0x000224AC File Offset: 0x000206AC
		public static void Execute(ModuleDef module)
		{
			StringEncPhase.InjectClass(module);
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef method in type.Methods)
					{
						bool flag = !method.HasBody;
						if (!flag)
						{
							IList<Instruction> instr = method.Body.Instructions;
							for (int i = 0; i < instr.Count; i++)
							{
								bool flag2 = instr[i].OpCode == OpCodes.Ldstr;
								if (flag2)
								{
									string originalStr = instr[i].Operand as string;
									string encodedStr = StringEncPhase.Encrypt(originalStr);
									instr[i].Operand = encodedStr;
									StringEncPhase.Str.Add(encodedStr);
									instr.Insert(i + 1, Instruction.Create(OpCodes.Ldc_I4, StringEncPhase.Str.LastIndexOf(encodedStr)));
									instr.Insert(i + 2, Instruction.Create(OpCodes.Call, UserControlSet.Init2));
									instr.Insert(i + 3, Instruction.Create(OpCodes.Call, UserControlSet.Init));
									instr.RemoveAt(i);
								}
							}
							method.Body.SimplifyBranches();
						}
					}
				}
			}
			File.WriteAllLines(Path.GetTempPath() + "List.txt", StringEncPhase.Str);
			byte[] bytes = File.ReadAllBytes(Path.GetTempPath() + "List.txt");
			module.Resources.Add(new EmbeddedResource("Inferno.Protect", StringEncPhase.Hush(bytes), ManifestResourceAttributes.Public));
			File.Delete(Path.GetTempPath() + "List.txt");
		}

		// Token: 0x06000194 RID: 404 RVA: 0x000226E8 File Offset: 0x000208E8
		public static byte[] Hush(byte[] text)
		{
			byte[] key = new Rfc2898DeriveBytes("p7K95451qB88sZ7J", Encoding.ASCII.GetBytes("2GM23j301t60Z96T")).GetBytes(32);
			byte[] xor = new byte[text.Length];
			for (int i = 0; i < text.Length; i++)
			{
				xor[i] = (text[i] ^ key[i % key.Length]);
			}
			return xor;
		}

		// Token: 0x06000195 RID: 405 RVA: 0x0002274C File Offset: 0x0002094C
		public static string Encrypt(string plainText)
		{
			byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
			byte[] keyBytes = new Rfc2898DeriveBytes("p7K95451qB88sZ7J", Encoding.ASCII.GetBytes("2GM23j301t60Z96T")).GetBytes(32);
			RijndaelManaged symmetricKey = new RijndaelManaged
			{
				Mode = CipherMode.CBC,
				Padding = PaddingMode.PKCS7
			};
			ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes("IzTdhG6S8uwg141S"));
			byte[] cipherTextBytes;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
				{
					cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
					cryptoStream.FlushFinalBlock();
					cipherTextBytes = memoryStream.ToArray();
					cryptoStream.Close();
				}
				memoryStream.Close();
			}
			return Convert.ToBase64String(cipherTextBytes);
		}

		// Token: 0x040000D2 RID: 210
		private const string PasswordHash = "p7K95451qB88sZ7J";

		// Token: 0x040000D3 RID: 211
		private const string SaltKey = "2GM23j301t60Z96T";

		// Token: 0x040000D4 RID: 212
		private const string VIKey = "IzTdhG6S8uwg141S";

		// Token: 0x040000D5 RID: 213
		public static List<string> Str = new List<string>();
	}
}
