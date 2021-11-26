using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using Inferno_Obfuscation;
using Inferno_Obfuscation.Virtualization.Value_Virt;

namespace Inferno_Obfuscator
{
	// Token: 0x02000024 RID: 36
	internal class numbers
	{
		// Token: 0x060000A0 RID: 160 RVA: 0x0000E1C4 File Offset: 0x0000C3C4
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				bool flag2 = flag;
				if (flag2)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x060000A1 RID: 161 RVA: 0x0000E280 File Offset: 0x0000C480
		public static void InjectClass1(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Runtime).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Runtime).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			numbers.init1 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "Season");
			foreach (MethodDef methodDef in module.GlobalType.Methods)
			{
				bool flag = methodDef.Name == ".ctor";
				bool flag2 = flag;
				if (flag2)
				{
					module.GlobalType.Remove(methodDef);
					break;
				}
			}
		}

		// Token: 0x060000A2 RID: 162 RVA: 0x0000E36C File Offset: 0x0000C56C
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

		// Token: 0x060000A3 RID: 163 RVA: 0x0000E3C8 File Offset: 0x0000C5C8
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("1234567890", length)
			select s[numbers.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000A4 RID: 164 RVA: 0x0000E414 File Offset: 0x0000C614
		public static void String(ModuleDef module)
		{
			numbers.InjectClass(module);
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag3 = !isGlobalModuleType;
				if (flag3)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = !methodDef.HasBody;
						bool flag4 = !flag;
						if (flag4)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag5 = flag2;
								if (flag5)
								{
									string s = numbers.Random(5);
									string szPlainText = (string)instructions[i].Operand;
									string text = numbers.EncryptDecrypt(szPlainText, int.Parse(s));
									text += "                                                                                                                                       ";
									instructions[i].Operand = text;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldc_I4, int.Parse(s)));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Call, numbers.init1));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060000A5 RID: 165 RVA: 0x0000E5D4 File Offset: 0x0000C7D4
		public static double RandomDouble(double min, double max)
		{
			return numbers.rnd.NextDouble() * (max - min) + min;
		}

		// Token: 0x060000A6 RID: 166 RVA: 0x0000E5F8 File Offset: 0x0000C7F8
		public static void InlineInteger(MethodDef method, int i)
		{
			bool isGlobalModuleType = method.DeclaringType.IsGlobalModuleType;
			bool flag7 = !isGlobalModuleType;
			if (flag7)
			{
				IList<Instruction> instructions = method.Body.Instructions;
				try
				{
					bool flag = instructions[i - 1].OpCode == OpCodes.Callvirt;
					bool flag8 = flag;
					if (flag8)
					{
						bool flag2 = instructions[i + 1].OpCode == OpCodes.Call;
						bool flag9 = flag2;
						if (flag9)
						{
							return;
						}
					}
					bool flag3 = instructions[i + 4].IsBr();
					bool flag10 = !flag3;
					if (flag10)
					{
						bool flag4 = true;
						int num = numbers.random.Next(0, 2);
						int num2 = num;
						bool flag11 = num2 != 0;
						if (flag11)
						{
							bool flag12 = num2 == 1;
							if (flag12)
							{
								flag4 = false;
							}
						}
						else
						{
							flag4 = true;
						}
						Local local = new Local(method.Module.CorLibTypes.String);
						method.Body.Variables.Add(local);
						Local local2 = new Local(method.Module.CorLibTypes.Int32);
						method.Body.Variables.Add(local2);
						int ldcI4Value = instructions[i].GetLdcI4Value();
						string s = Renamer.Generator.GenerateString();
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local2));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local2));
						bool flag5 = flag4;
						bool flag13 = flag5;
						if (flag13)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
						}
						instructions.Insert(i, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(string).GetMethod("op_Equality", new Type[]
						{
							typeof(string),
							typeof(string)
						}))));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local));
						bool flag6 = flag4;
						bool flag14 = flag6;
						if (flag14)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, s));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, Renamer.Generator.GenerateString()));
						}
						instructions.Insert(i + 5, Instruction.Create(OpCodes.Brtrue_S, instructions[i + 6]));
						instructions.Insert(i + 7, Instruction.Create(OpCodes.Br_S, instructions[i + 8]));
						instructions.RemoveAt(i + 10);
					}
				}
				catch
				{
				}
			}
		}

		// Token: 0x060000A7 RID: 167 RVA: 0x0000E8F4 File Offset: 0x0000CAF4
		public static void encrypt(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = !methodDef.HasBody;
					bool flag5 = !flag;
					if (flag5)
					{
						bool flag2 = !methodDef.Body.HasInstructions;
						bool flag6 = !flag2;
						if (flag6)
						{
							bool flag3 = methodDef.DeclaringType == md.GlobalType;
							bool flag7 = !flag3;
							if (flag7)
							{
								for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
								{
									bool flag4 = methodDef.Body.Instructions[i].OpCode == OpCodes.Ldc_I4;
									bool flag8 = flag4;
									if (flag8)
									{
										int ldcI4Value = methodDef.Body.Instructions[i].GetLdcI4Value();
										double value = numbers.RandomDouble(1.0, 1000.0);
										string s = Convert.ToString(value);
										double num = double.Parse(s);
										int num2 = ldcI4Value - (int)num;
										methodDef.Body.Instructions[i].Operand = num2;
										methodDef.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
										methodDef.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, s));
										methodDef.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, numbers.rnd.Next(1, 10000)));
										methodDef.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, numbers.init));
										methodDef.Body.Instructions.Insert(i + 4, OpCodes.Conv_I4.ToInstruction());
										methodDef.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Add));
										i += 5;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000059 RID: 89
		public static MethodDef init;

		// Token: 0x0400005A RID: 90
		public static MethodDef init1;

		// Token: 0x0400005B RID: 91
		public static Random rnd = new Random();

		// Token: 0x0400005C RID: 92
		public static Random random = new Random();
	}
}
