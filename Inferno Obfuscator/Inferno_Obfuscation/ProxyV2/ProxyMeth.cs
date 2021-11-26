using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.ProxyV2
{
	// Token: 0x02000061 RID: 97
	public static class ProxyMeth
	{
		// Token: 0x060001FF RID: 511 RVA: 0x00028A04 File Offset: 0x00026C04
		public static void ScanMemberRef(ModuleDef module)
		{
			foreach (TypeDef type in module.Types)
			{
				foreach (MethodDef method in type.Methods)
				{
					bool flag = !method.HasBody || !method.Body.HasInstructions;
					if (!flag)
					{
						for (int i = 0; i < method.Body.Instructions.Count - 1; i++)
						{
							bool flag2 = method.Body.Instructions[i].OpCode != OpCodes.Call;
							if (!flag2)
							{
								try
								{
									MemberRef original = (MemberRef)method.Body.Instructions[i].Operand;
									bool flag3 = !original.HasThis;
									if (flag3)
									{
										ProxyMeth.MemberRefList.Add(original);
									}
								}
								catch
								{
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x06000200 RID: 512 RVA: 0x00028B84 File Offset: 0x00026D84
		public static MethodDef GenerateSwitch(MemberRef original, ModuleDef md)
		{
			MethodDef result;
			try
			{
				List<TypeSig> type = original.MethodSig.Params.ToList<TypeSig>();
				type.Add(md.CorLibTypes.Int32);
				MethodImplAttributes methImplFlags = MethodImplAttributes.IL;
				MethodAttributes methFlags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
				MethodDef meth = new MethodDefUser(string.Format("InfernoOBF{0}", ProxyMeth.rand.Next(0, int.MaxValue)), MethodSig.CreateStatic(original.MethodSig.RetType, type.ToArray()), methImplFlags, methFlags)
				{
					Body = new CilBody()
				};
				meth.Body.Variables.Add(new Local(md.CorLibTypes.Int32));
				meth.Body.Variables.Add(new Local(md.CorLibTypes.Int32));
				meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
				List<Instruction> lst = new List<Instruction>();
				Instruction switchs = new Instruction(OpCodes.Switch);
				meth.Body.Instructions.Add(switchs);
				Instruction br_s = new Instruction(OpCodes.Br_S);
				meth.Body.Instructions.Add(br_s);
				for (int i = 0; i < 5; i++)
				{
					for (int ia = 0; ia <= original.MethodSig.Params.Count - 1; ia++)
					{
						meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, meth.Parameters[ia]));
						bool flag = ia == 0;
						if (flag)
						{
							lst.Add(Instruction.Create(OpCodes.Ldarg, meth.Parameters[ia]));
						}
					}
					Instruction ldstr = Instruction.Create(OpCodes.Ldc_I4, i);
					meth.Body.Instructions.Add(ldstr);
					meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				}
				Instruction ldnull = Instruction.Create(OpCodes.Ldnull);
				meth.Body.Instructions.Add(ldnull);
				meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
				br_s.Operand = ldnull;
				switchs.Operand = lst;
				result = meth;
			}
			catch
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000201 RID: 513 RVA: 0x00028E00 File Offset: 0x00027000
		public static IEnumerable<T> Randomize<T>(IEnumerable<T> source)
		{
			Random rnd = new Random();
			return from item in source
			orderby rnd.Next()
			select item;
		}

		// Token: 0x06000202 RID: 514 RVA: 0x00028E38 File Offset: 0x00027038
		public static void Execute(ModuleDef module)
		{
			ProxyMeth.ScanMemberRef(module);
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef method in type.Methods.ToArray<MethodDef>())
					{
						bool flag = !method.HasBody || method.Name.Contains("Proxy");
						if (!flag)
						{
							IList<Instruction> instr = method.Body.Instructions;
							for (int i = 0; i < instr.Count; i++)
							{
								bool flag2 = method.Body.Instructions[i].OpCode != OpCodes.Call;
								if (!flag2)
								{
									try
									{
										MemberRef original = (MemberRef)method.Body.Instructions[i].Operand;
										bool flag3 = !original.HasThis;
										if (flag3)
										{
											MethodDef proxy = ProxyMeth.GenerateSwitch(original, module);
											method.DeclaringType.Methods.Add(proxy);
											instr[i].OpCode = OpCodes.Call;
											instr[i].Operand = proxy;
											int random = ProxyMeth.rand.Next(0, 5);
											Func<MemberRef, bool> <>9__0;
											for (int b = 0; b < proxy.Body.Instructions.Count - 1; b++)
											{
												bool flag4 = proxy.Body.Instructions[b].OpCode == OpCodes.Ldc_I4;
												if (flag4)
												{
													bool flag5 = string.Compare(proxy.Body.Instructions[b].Operand.ToString(), random.ToString(), StringComparison.Ordinal) != 0;
													if (flag5)
													{
														proxy.Body.Instructions[b].OpCode = OpCodes.Call;
														Instruction instruction = proxy.Body.Instructions[b];
														IEnumerable<MemberRef> memberRefList = ProxyMeth.MemberRefList;
														Func<MemberRef, bool> predicate;
														if ((predicate = <>9__0) == null)
														{
															predicate = (<>9__0 = ((MemberRef m) => m.MethodSig.Params.Count == original.MethodSig.Params.Count));
														}
														instruction.Operand = memberRefList.Where(predicate).ToList<MemberRef>().Random<MemberRef>();
													}
													else
													{
														proxy.Body.Instructions[b].OpCode = OpCodes.Call;
														proxy.Body.Instructions[b].Operand = original;
													}
												}
											}
											method.Body.Instructions.Insert(i, Instruction.CreateLdcI4(random));
											MethodSig originalsignature = original.MethodSig;
											MethodImplAttributes methImplFlags = MethodImplAttributes.IL;
											MethodAttributes methFlags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
											MethodDefUser meth = new MethodDefUser("InfernoOBF" + ProxyMeth.rand.Next(0, int.MaxValue).ToString(), originalsignature, methImplFlags, methFlags);
											module.GlobalType.Methods.Add(meth);
											meth.Body = new CilBody();
											for (int ia = 0; ia <= originalsignature.Params.Count - 1; ia++)
											{
												meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, meth.Parameters[ia]));
											}
											meth.Body.Instructions.Add(Instruction.Create(OpCodes.Call, original));
											meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
											instr[i].OpCode = OpCodes.Call;
											instr[i].Operand = meth;
										}
									}
									catch
									{
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400011B RID: 283
		public static Random rand = new Random();

		// Token: 0x0400011C RID: 284
		public static List<MemberRef> MemberRefList = new List<MemberRef>();
	}
}
