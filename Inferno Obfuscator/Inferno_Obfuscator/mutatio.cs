using System;
using System.Collections.Generic;
using System.Reflection;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscator
{
	// Token: 0x02000023 RID: 35
	internal class mutatio
	{
		// Token: 0x0600009D RID: 157 RVA: 0x0000D848 File Offset: 0x0000BA48
		public static void Booleanisator(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag6 = !isGlobalModuleType;
				if (flag6)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = !methodDef.HasBody;
						bool flag7 = !flag;
						if (flag7)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag2 = instructions[i].OpCode == OpCodes.Callvirt;
								bool flag8 = flag2;
								if (flag8)
								{
									bool flag3 = instructions[i].Operand.ToString().ToLower().Contains("bool");
									bool flag9 = flag3;
									if (flag9)
									{
										bool flag4 = instructions[i - 1].OpCode == OpCodes.Ldc_I4_0;
										bool flag10 = flag4;
										if (flag10)
										{
											FieldInfo fieldInfo = null;
											Local local = new Local(md.CorLibTypes.Boolean);
											methodDef.Body.Variables.Add(local);
											Instruction instruction = new Instruction();
											FieldInfo[] fields = typeof(string).GetFields();
											foreach (FieldInfo fieldInfo2 in fields)
											{
												bool flag5 = fieldInfo2.Name == "Empty";
												bool flag11 = flag5;
												if (flag11)
												{
													instruction = new Instruction(OpCodes.Ldsfld, fieldInfo2);
													fieldInfo = fieldInfo2;
													break;
												}
											}
											instructions[i - 1].OpCode = OpCodes.Ldsfld;
											instructions[i - 1].Operand = methodDef.Module.Import(fieldInfo);
											instructions.Insert(i, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(string).GetMethod("IsNullOrEmpty"))));
											instructions.Insert(i + 1, Instruction.Create(OpCodes.Stloc_S, local));
											instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldloc_S, local));
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600009E RID: 158 RVA: 0x0000DAFC File Offset: 0x0000BCFC
		public static void Mutate1(MethodDef method)
		{
			CilBody body = method.Body;
			body.SimplifyBranches();
			Random random = new Random();
			int i = 0;
			while (i < body.Instructions.Count)
			{
				bool flag = body.Instructions[i].IsLdcI4();
				bool flag4 = flag;
				if (flag4)
				{
					int ldcI4Value = body.Instructions[i].GetLdcI4Value();
					int num = random.Next(5, 40);
					body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					body.Instructions[i].Operand = num * ldcI4Value;
					body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldc_I4, num));
					body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Div));
					i += 3;
				}
				else
				{
					i++;
				}
			}
			Random random2 = new Random();
			int num2 = 0;
			ITypeDefOrRef type = null;
			for (int j = 0; j < method.Body.Instructions.Count; j++)
			{
				Instruction instruction = method.Body.Instructions[j];
				bool flag2 = instruction.IsLdcI4();
				bool flag5 = flag2;
				if (flag5)
				{
					switch (random2.Next(1, 16))
					{
					case 1:
						type = method.Module.Import(typeof(int));
						num2 = 4;
						break;
					case 2:
						type = method.Module.Import(typeof(sbyte));
						num2 = 1;
						break;
					case 3:
						type = method.Module.Import(typeof(byte));
						num2 = 1;
						break;
					case 4:
						type = method.Module.Import(typeof(bool));
						num2 = 1;
						break;
					case 5:
						type = method.Module.Import(typeof(decimal));
						num2 = 16;
						break;
					case 6:
						type = method.Module.Import(typeof(short));
						num2 = 2;
						break;
					case 7:
						type = method.Module.Import(typeof(long));
						num2 = 8;
						break;
					case 8:
						type = method.Module.Import(typeof(uint));
						num2 = 4;
						break;
					case 9:
						type = method.Module.Import(typeof(float));
						num2 = 4;
						break;
					case 10:
						type = method.Module.Import(typeof(char));
						num2 = 2;
						break;
					case 11:
						type = method.Module.Import(typeof(ushort));
						num2 = 2;
						break;
					case 12:
						type = method.Module.Import(typeof(double));
						num2 = 8;
						break;
					case 13:
						type = method.Module.Import(typeof(DateTime));
						num2 = 8;
						break;
					case 14:
						type = method.Module.Import(typeof(ConsoleKeyInfo));
						num2 = 12;
						break;
					case 15:
						type = method.Module.Import(typeof(Guid));
						num2 = 16;
						break;
					}
					int num3 = random2.Next(1, 1000);
					bool flag3 = Convert.ToBoolean(random2.Next(0, 2));
					switch ((num2 != 0) ? ((Convert.ToInt32(instruction.Operand) % num2 == 0) ? random2.Next(1, 5) : random2.Next(1, 4)) : random2.Next(1, 4))
					{
					case 1:
						method.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Sizeof, type));
						method.Body.Instructions.Insert(j + 2, Instruction.Create(OpCodes.Add));
						instruction.Operand = Convert.ToInt32(instruction.Operand) - num2 + (flag3 ? (-num3) : num3);
						method.Body.Instructions.Insert(j + 3, Instruction.CreateLdcI4(num3));
						method.Body.Instructions.Insert(j + 4, Instruction.Create(flag3 ? OpCodes.Add : OpCodes.Sub));
						j += 4;
						break;
					case 2:
						method.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Sizeof, type));
						method.Body.Instructions.Insert(j + 2, Instruction.Create(OpCodes.Sub));
						instruction.Operand = Convert.ToInt32(instruction.Operand) + num2 + (flag3 ? (-num3) : num3);
						method.Body.Instructions.Insert(j + 3, Instruction.CreateLdcI4(num3));
						method.Body.Instructions.Insert(j + 4, Instruction.Create(flag3 ? OpCodes.Add : OpCodes.Sub));
						j += 4;
						break;
					case 3:
						method.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Sizeof, type));
						method.Body.Instructions.Insert(j + 2, Instruction.Create(OpCodes.Add));
						instruction.Operand = Convert.ToInt32(instruction.Operand) - num2 + (flag3 ? (-num3) : num3);
						method.Body.Instructions.Insert(j + 3, Instruction.CreateLdcI4(num3));
						method.Body.Instructions.Insert(j + 4, Instruction.Create(flag3 ? OpCodes.Add : OpCodes.Sub));
						j += 4;
						break;
					case 4:
						method.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Sizeof, type));
						method.Body.Instructions.Insert(j + 2, Instruction.Create(OpCodes.Mul));
						instruction.Operand = Convert.ToInt32(instruction.Operand) / num2;
						j += 2;
						break;
					default:
						method.Body.Instructions.Insert(j + 3, Instruction.CreateLdcI4(num3));
						method.Body.Instructions.Insert(j + 4, Instruction.Create(flag3 ? OpCodes.Add : OpCodes.Sub));
						j += 4;
						break;
					}
				}
			}
		}
	}
}
