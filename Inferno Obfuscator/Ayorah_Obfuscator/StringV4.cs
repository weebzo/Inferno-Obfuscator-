using System;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Ayorah_Obfuscator
{
	// Token: 0x02000022 RID: 34
	internal class StringV4
	{
		// Token: 0x06000097 RID: 151 RVA: 0x0000D4EC File Offset: 0x0000B6EC
		public static void encryptString(ModuleDef module)
		{
			foreach (TypeDef type in module.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					bool flag = method.Body == null;
					if (!flag)
					{
						method.Body.SimplifyBranches();
						for (int i = 0; i < method.Body.Instructions.Count; i++)
						{
							bool flag2 = method.Body.Instructions[i].OpCode == OpCodes.Ldstr;
							if (flag2)
							{
								string base64toencrypt = method.Body.Instructions[i].Operand.ToString();
								string base64EncryptedString = Convert.ToBase64String(Encoding.UTF8.GetBytes(base64toencrypt));
								method.Body.Instructions[i].OpCode = OpCodes.Nop;
								method.Body.Instructions.Insert(i + 1, new Instruction(OpCodes.Call, module.Import(typeof(Encoding).GetMethod("get_UTF8", new Type[0]))));
								method.Body.Instructions.Insert(i + 2, new Instruction(OpCodes.Ldstr, base64EncryptedString));
								method.Body.Instructions.Insert(i + 3, new Instruction(OpCodes.Call, module.Import(typeof(Convert).GetMethod("FromBase64String", new Type[]
								{
									typeof(string)
								}))));
								method.Body.Instructions.Insert(i + 4, new Instruction(OpCodes.Callvirt, module.Import(typeof(Encoding).GetMethod("GetString", new Type[]
								{
									typeof(byte[])
								}))));
								i += 4;
							}
						}
					}
				}
			}
		}

		// Token: 0x06000098 RID: 152 RVA: 0x0000D758 File Offset: 0x0000B958
		public static byte[] encodeBytes(byte[] bytes, string pass)
		{
			byte[] XorBytes = Encoding.Unicode.GetBytes(pass);
			for (int i = 0; i < bytes.Length; i++)
			{
				int num = i;
				bytes[num] ^= XorBytes[i % 16];
			}
			return bytes;
		}

		// Token: 0x06000099 RID: 153 RVA: 0x0000D7A0 File Offset: 0x0000B9A0
		public static byte[] decryptBytes(byte[] bytes, string pass)
		{
			byte[] XorBytes = Encoding.Unicode.GetBytes(pass);
			for (int i = 0; i < bytes.Length; i++)
			{
				int num = i;
				bytes[num] ^= XorBytes[i % 16];
			}
			return bytes;
		}

		// Token: 0x0600009A RID: 154 RVA: 0x0000D7E8 File Offset: 0x0000B9E8
		public static string RandomString(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz", length)
			select s[StringV4.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x04000058 RID: 88
		private static Random random = new Random();
	}
}
