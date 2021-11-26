using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200002D RID: 45
	internal class Constants__numbers_
	{
		// Token: 0x060000CD RID: 205 RVA: 0x00010AA0 File Offset: 0x0000ECA0
		public static void InjectClass(ModuleDef module)
		{
			ModuleDefMD moduleDefMD = ModuleDefMD.Load(typeof(Numbers).Module);
			TypeDef typeDef = moduleDefMD.ResolveTypeDef(MDToken.ToRID(typeof(Numbers).MetadataToken));
			IEnumerable<IDnlibDef> source = InjectHelper1.InjectHelper.Inject(typeDef, module.GlobalType, module);
			Constants__numbers_.init = (MethodDef)source.Single((IDnlibDef method) => method.Name == "InfernoOBF112");
			Constants__numbers_.init1 = (MethodDef)source.Single((IDnlibDef method) => method.Name == "InfernoOBF110");
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

		// Token: 0x060000CE RID: 206 RVA: 0x00010BC0 File Offset: 0x0000EDC0
		public static void ObfuscateNumbers(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag = !methodDef.HasBody;
					bool flag2 = !flag;
					bool flag7 = flag2;
					if (flag7)
					{
						for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
						{
							bool flag3 = methodDef.Body.Instructions[i].IsLdcI4();
							bool flag4 = flag3;
							bool flag8 = flag4;
							if (flag8)
							{
								int ldcI4Value = methodDef.Body.Instructions[i].GetLdcI4Value();
								bool flag5 = ldcI4Value <= 0;
								bool flag6 = !flag5;
								bool flag9 = flag6;
								if (flag9)
								{
									methodDef.Body.Instructions[i].OpCode = OpCodes.Ldstr;
									methodDef.Body.Instructions[i].Operand = Constants__numbers_.Random(ldcI4Value);
									methodDef.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(md.Import(typeof(string).GetMethod("get_Length"))));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060000CF RID: 207 RVA: 0x00010D88 File Offset: 0x0000EF88
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef typeDef in module.Types)
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag = !isGlobalModuleType;
				bool flag26 = flag;
				if (flag26)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag2 = methodDef.FullName.Contains("My.");
						bool flag3 = !flag2;
						bool flag27 = flag3;
						if (flag27)
						{
							bool flag4 = methodDef.FullName.Contains("InitializeCompnent");
							bool flag5 = !flag4;
							bool flag28 = flag5;
							if (flag28)
							{
								bool isConstructor = methodDef.IsConstructor;
								bool flag6 = !isConstructor;
								bool flag29 = flag6;
								if (flag29)
								{
									bool isGlobalModuleType2 = methodDef.DeclaringType.IsGlobalModuleType;
									bool flag7 = !isGlobalModuleType2;
									bool flag30 = flag7;
									if (flag30)
									{
										bool flag8 = !methodDef.HasBody;
										bool flag9 = !flag8;
										bool flag31 = flag9;
										if (flag31)
										{
											IList<Instruction> instructions = methodDef.Body.Instructions;
											for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
											{
												bool flag10 = methodDef.Body.Instructions[i].ToString().Contains("ResourceManager");
												bool flag11 = flag10;
												bool flag32 = flag11;
												if (flag32)
												{
													i = methodDef.Body.Instructions.Count;
												}
												else
												{
													bool flag12 = methodDef.Body.Instructions[i].ToString().Contains("GetObject");
													bool flag13 = !flag12;
													bool flag33 = flag13;
													if (flag33)
													{
														bool flag14 = instructions[i].OpCode == OpCodes.Ldstr;
														bool flag15 = flag14;
														bool flag34 = flag15;
														if (flag34)
														{
															Random random = new Random();
															for (int j = 1; j < 2; j++)
															{
																bool flag16 = j != 1;
																bool flag17 = flag16;
																bool flag35 = flag17;
																if (flag35)
																{
																	j++;
																}
																Local local = new Local(module.CorLibTypes.String);
																Local local2 = new Local(module.CorLibTypes.String);
																methodDef.Body.Variables.Add(local);
																methodDef.Body.Variables.Add(local2);
																instructions.Insert(i + j, Instruction.Create(OpCodes.Stloc_S, local));
																instructions.Insert(i + (j + 1), Instruction.Create(OpCodes.Ldloc_S, local));
															}
														}
														bool flag18 = methodDef.Body.Instructions[i].ToString().Contains("ResourceManager");
														bool flag19 = !flag18;
														bool flag36 = flag19;
														if (flag36)
														{
															bool flag20 = methodDef.Body.Instructions[i].ToString().Contains("GetObject");
															bool flag21 = !flag20;
															bool flag37 = flag21;
															if (flag37)
															{
																bool flag22 = instructions[i].IsLdcI4();
																bool flag23 = flag22;
																bool flag38 = flag23;
																if (flag38)
																{
																	Random random2 = new Random();
																	for (int k = 1; k < 2; k++)
																	{
																		bool flag24 = k != 1;
																		bool flag25 = flag24;
																		bool flag39 = flag25;
																		if (flag39)
																		{
																			k++;
																		}
																		Local local3 = new Local(module.CorLibTypes.Int32);
																		Local local4 = new Local(module.CorLibTypes.Int32);
																		methodDef.Body.Variables.Add(local3);
																		methodDef.Body.Variables.Add(local4);
																		instructions.Insert(i + k, Instruction.Create(OpCodes.Stloc_S, local3));
																		instructions.Insert(i + (k + 1), Instruction.Create(OpCodes.Ldloc_S, local3));
																	}
																}
															}
														}
													}
												}
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060000D0 RID: 208 RVA: 0x000111FC File Offset: 0x0000F3FC
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwertyuiopasdfghjklzxcvbnmqrtyuio痹瘕番畐畵地狱迷惑阿約拉Infernoh Obfuscator阿約拉地狱迷惑畵蘞虢謊謁phjklxcvbnm", length)
			select s[Constants__numbers_.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000D1 RID: 209 RVA: 0x00011248 File Offset: 0x0000F448
		public static void Melting(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					Constants__numbers_.StringOutliner(methodDef);
					Constants__numbers_.IntegerOutliner(methodDef);
				}
			}
		}

		// Token: 0x060000D2 RID: 210 RVA: 0x000112C8 File Offset: 0x0000F4C8
		public static void StringOutliner(MethodDef methodDef)
		{
			bool hasBody = methodDef.HasBody;
			bool flag = hasBody;
			bool flag6 = flag;
			if (flag6)
			{
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					bool flag2 = instruction.OpCode != OpCodes.Ldstr;
					bool flag3 = !flag2;
					bool flag7 = flag3;
					if (flag7)
					{
						bool flag4 = instruction.Operand == "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵蘞虢謊謁";
						bool flag5 = flag4;
						bool flag8 = flag5;
						if (flag8)
						{
							break;
						}
						MethodDef methodDef2 = new MethodDefUser("Inferno_Obfuscator_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.Object), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
						{
							Body = new CilBody()
						};
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ldstr, instruction.Operand.ToString()));
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						methodDef.Module.GlobalType.Methods.Add(methodDef2);
						instruction.OpCode = OpCodes.Call;
						instruction.Operand = methodDef2;
					}
				}
			}
		}

		// Token: 0x060000D3 RID: 211 RVA: 0x00011454 File Offset: 0x0000F654
		public static void IntegerOutliner(MethodDef methodDef)
		{
			bool hasBody = methodDef.HasBody;
			bool flag = hasBody;
			bool flag4 = flag;
			if (flag4)
			{
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					bool flag2 = instruction.OpCode != OpCodes.Ldc_I4;
					bool flag3 = !flag2;
					bool flag5 = flag3;
					if (flag5)
					{
						MethodDef methodDef2 = new MethodDefUser("Inferno_Obfuscator_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.UInt32), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
						{
							Body = new CilBody()
						};
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ldc_I4, instruction.GetLdcI4Value()));
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						methodDef.Module.GlobalType.Methods.Add(methodDef2);
						instruction.OpCode = OpCodes.Call;
						instruction.Operand = methodDef2;
					}
				}
			}
		}

		// Token: 0x060000D4 RID: 212 RVA: 0x000115C0 File Offset: 0x0000F7C0
		public static void FloatOutliner(MethodDef methodDef)
		{
			bool hasBody = methodDef.HasBody;
			bool flag = hasBody;
			bool flag4 = flag;
			if (flag4)
			{
				foreach (Instruction instruction in methodDef.Body.Instructions)
				{
					bool flag2 = instruction.OpCode != OpCodes.Ldc_R4;
					bool flag3 = !flag2;
					bool flag5 = flag3;
					if (flag5)
					{
						MethodDef methodDef2 = new MethodDefUser("Inferno_Obfuscator_" + Renamer.rnd.Next(1, int.MaxValue).ToString(), MethodSig.CreateStatic(methodDef.DeclaringType.Module.CorLibTypes.Object), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
						{
							Body = new CilBody()
						};
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ldc_R4, instruction.Operand));
						methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
						methodDef.DeclaringType.Methods.Add(methodDef2);
						instruction.OpCode = OpCodes.Call;
						instruction.Operand = methodDef2;
					}
				}
			}
		}

		// Token: 0x060000D5 RID: 213 RVA: 0x00011720 File Offset: 0x0000F920
		public static void Inject(ModuleDef module)
		{
			Constants__numbers_.Execute(module);
			int num = new Random().Next(0, int.MaxValue);
			Constants__numbers_.InjectClass(module);
			foreach (TypeDef typeDef in module.GetTypes())
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag = !isGlobalModuleType;
				bool flag8 = flag;
				if (flag8)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag2 = !methodDef.HasBody;
						bool flag3 = !flag2;
						bool flag9 = flag3;
						if (flag9)
						{
							IList<Instruction> instructions = methodDef.Body.Instructions;
							for (int i = 0; i < instructions.Count - 3; i++)
							{
								bool flag4 = instructions[i].OpCode == OpCodes.Ldc_I4;
								bool flag5 = flag4;
								bool flag10 = flag5;
								if (flag10)
								{
									int num2 = (int)instructions[i].Operand;
									int num3 = num2 * 69;
									num3 *= 2;
									instructions[i].Operand = num3;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, "Inferno"));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, "Inferno"));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Constants__numbers_.init));
								}
								bool flag6 = instructions[i].OpCode == OpCodes.Ldc_R4;
								bool flag7 = flag6;
								bool flag11 = flag7;
								if (flag11)
								{
									float num4 = (float)instructions[i].Operand;
									float num5 = num4 * 69f;
									num5 *= 2f;
									instructions[i].Operand = num5;
									instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, "Inferno"));
									instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, "Inferno"));
									instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Constants__numbers_.init1));
								}
							}
						}
					}
				}
			}
			Constants__numbers_.Melting(module);
		}

		// Token: 0x04000062 RID: 98
		public static Random random = new Random();

		// Token: 0x04000063 RID: 99
		private static IMethod _decrypt;

		// Token: 0x04000064 RID: 100
		private static ModuleDef _mod;

		// Token: 0x04000065 RID: 101
		public static MethodDef init;

		// Token: 0x04000066 RID: 102
		public static MethodDef init1;
	}
}
