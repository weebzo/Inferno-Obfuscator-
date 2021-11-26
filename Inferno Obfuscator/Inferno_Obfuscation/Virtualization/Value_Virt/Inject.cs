using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.Virtualization.Value_Virt
{
	// Token: 0x0200005C RID: 92
	internal class Inject
	{
		// Token: 0x060001E7 RID: 487 RVA: 0x00025EA4 File Offset: 0x000240A4
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			Inject.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "VirtualizeValue");
			Inject.init1 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Double");
			Inject.init2 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "OnlyString");
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

		// Token: 0x060001E8 RID: 488 RVA: 0x00025FF0 File Offset: 0x000241F0
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwrtyuiopasdfghjkl痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞zxcvbnm,1234567890", length)
			select s[Inject.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060001E9 RID: 489 RVA: 0x0002603C File Offset: 0x0002423C
		public static string EncryptString(string plainText, string passPhrase)
		{
			byte[] bytes = Encoding.UTF8.GetBytes(Inject.initVector);
			byte[] bytes2 = Encoding.UTF8.GetBytes(plainText);
			PasswordDeriveBytes passwordDeriveBytes = new PasswordDeriveBytes(passPhrase, null);
			byte[] bytes3 = passwordDeriveBytes.GetBytes(32);
			ICryptoTransform transform = new RijndaelManaged
			{
				Mode = CipherMode.CBC
			}.CreateEncryptor(bytes3, bytes);
			MemoryStream memoryStream = new MemoryStream();
			CryptoStream cryptoStream = new CryptoStream(memoryStream, transform, CryptoStreamMode.Write);
			cryptoStream.Write(bytes2, 0, bytes2.Length);
			cryptoStream.FlushFinalBlock();
			byte[] inArray = memoryStream.ToArray();
			memoryStream.Close();
			cryptoStream.Close();
			return Convert.ToBase64String(inArray);
		}

		// Token: 0x060001EA RID: 490 RVA: 0x000260DC File Offset: 0x000242DC
		public static string EncryptDecrypt(string szPlainText, int szEncryptionKey)
		{
			StringBuilder stringBuilder = new StringBuilder(szPlainText);
			StringBuilder stringBuilder2 = new StringBuilder(szPlainText.Length);
			for (int i = 0; i < szPlainText.Length; i++)
			{
				char c = stringBuilder[i];
				c = (char)((int)c ^ szEncryptionKey);
				stringBuilder2.Append(c);
			}
			return stringBuilder2.ToString();
		}

		// Token: 0x060001EB RID: 491 RVA: 0x00026138 File Offset: 0x00024338
		public static void ProtectValue(ModuleDef module)
		{
			Inject.InjectClass(module);
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag = !isGlobalModuleType;
				bool flag17 = flag;
				if (flag17)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag2 = !methodDef.HasBody;
						bool flag3 = !flag2;
						bool flag18 = flag3;
						if (flag18)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag4 = instructions[i].OpCode == OpCodes.Ldc_I4 || instructions[i].OpCode == OpCodes.Ldc_I4_S;
								bool flag5 = flag4;
								bool flag19 = flag5;
								if (flag19)
								{
									try
									{
										string text = instructions[i].Operand.ToString();
										instructions[i].OpCode = OpCodes.Nop;
										instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, text));
										instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(int).GetMethod("Parse", new Type[]
										{
											typeof(string)
										}))));
									}
									catch
									{
									}
								}
								bool flag6 = instructions[i].OpCode == OpCodes.Ldc_I4_S;
								bool flag7 = flag6;
								bool flag8 = flag7;
								bool flag20 = flag8;
								if (flag20)
								{
									string text2 = instructions[i].Operand.ToString();
									instructions[i].OpCode = OpCodes.Nop;
									instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, text2));
									instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(short).GetMethod("Parse", new Type[]
									{
										typeof(string)
									}))));
								}
								else
								{
									bool flag9 = instructions[i].OpCode == OpCodes.Ldc_I8;
									bool flag10 = flag9;
									bool flag11 = flag10;
									bool flag21 = flag11;
									if (flag21)
									{
										string text3 = instructions[i].Operand.ToString();
										instructions[i].OpCode = OpCodes.Nop;
										instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, text3));
										instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(long).GetMethod("Parse", new Type[]
										{
											typeof(string)
										}))));
									}
									else
									{
										bool flag12 = methodDef.Body.Instructions[i].OpCode == OpCodes.Ldc_R4;
										bool flag13 = flag12;
										bool flag14 = flag13;
										bool flag22 = flag14;
										if (flag22)
										{
											string text4 = methodDef.Body.Instructions[i].Operand.ToString();
											methodDef.Body.Instructions[i].OpCode = OpCodes.Nop;
											methodDef.Body.Instructions.Insert(++i, Instruction.Create(OpCodes.Ldstr, text4));
											methodDef.Body.Instructions.Insert(++i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(float).GetMethod("Parse", new Type[]
											{
												typeof(string)
											}))));
										}
									}
								}
								bool flag15 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag16 = flag15;
								bool flag23 = flag16;
								if (flag23)
								{
									string plainText = (string)instructions[i].Operand;
									string text5 = Inject.Random(32);
									Inject.initVector = Inject.Random(16);
									string operand = Inject.EncryptString(plainText, text5);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text5));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, Inject.initVector));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 5, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 10, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 11, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 12, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 13, Instruction.Create(OpCodes.Call, Inject.init));
									i += 13;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060001EC RID: 492 RVA: 0x00026824 File Offset: 0x00024A24
		public static void Triple(ModuleDef module)
		{
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
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag4 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag5 = flag4;
								bool flag8 = flag5;
								if (flag8)
								{
									string plainText = (string)instructions[i].Operand;
									string text = Inject.Random(32);
									string operand = Inject.EncryptString(plainText, text);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, Inject.initVector));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Inject.init2));
									i += 3;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060001ED RID: 493 RVA: 0x000269F4 File Offset: 0x00024BF4
		public static void DoubleProtect(ModuleDef module)
		{
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
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag4 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag5 = flag4;
								bool flag8 = flag5;
								if (flag8)
								{
									string plainText = (string)instructions[i].Operand;
									string text = Inject.Random(32);
									Inject.initVector = Inject.Random(16);
									string operand = Inject.EncryptString(plainText, text);
									instructions[i].Operand = operand;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, Inject.initVector));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 5, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 7, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 10, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 11, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 12, Instruction.Create(OpCodes.Ldc_I4, Inject.random.Next(int.MinValue, int.MaxValue)));
									instructions.Insert(i + 13, Instruction.Create(OpCodes.Call, Inject.init));
									i += 13;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000113 RID: 275
		public static MethodDef init;

		// Token: 0x04000114 RID: 276
		public static MethodDef init1;

		// Token: 0x04000115 RID: 277
		public static MethodDef init2;

		// Token: 0x04000116 RID: 278
		public static Random random = new Random();

		// Token: 0x04000117 RID: 279
		public static string initVector = "pemgail9uzpgzl88";

		// Token: 0x04000118 RID: 280
		private const int keysize = 256;
	}
}
