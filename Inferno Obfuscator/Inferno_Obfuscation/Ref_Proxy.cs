using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000049 RID: 73
	internal class Ref_Proxy
	{
		// Token: 0x17000008 RID: 8
		// (get) Token: 0x0600015F RID: 351 RVA: 0x0001C27D File Offset: 0x0001A47D
		// (set) Token: 0x06000160 RID: 352 RVA: 0x0001C284 File Offset: 0x0001A484
		public static int Intensity { get; set; } = 20;

		// Token: 0x17000009 RID: 9
		// (get) Token: 0x06000161 RID: 353 RVA: 0x0001C28C File Offset: 0x0001A48C
		// (set) Token: 0x06000162 RID: 354 RVA: 0x0001C293 File Offset: 0x0001A493
		private static int Amount { get; set; }

		// Token: 0x06000163 RID: 355 RVA: 0x0001C29C File Offset: 0x0001A49C
		public static void Execute(ModuleDef md)
		{
			for (int i = 0; i < Ref_Proxy.Intensity; i++)
			{
				foreach (TypeDef typeDef in md.Types)
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag = !isGlobalModuleType;
					bool flag10 = flag;
					if (flag10)
					{
						foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
						{
							bool flag2 = !methodDef.HasBody;
							bool flag3 = !flag2;
							bool flag11 = flag3;
							if (flag11)
							{
								for (int j = 0; j < methodDef.Body.Instructions.Count; j++)
								{
									bool flag4 = methodDef.Body.Instructions[j].OpCode == OpCodes.Call;
									bool flag5 = flag4;
									bool flag12 = flag5;
									if (flag12)
									{
										try
										{
											MethodDef methodDef2 = methodDef.Body.Instructions[j].Operand as MethodDef;
											bool flag6 = !methodDef2.FullName.Contains(md.Assembly.Name);
											bool flag7 = !flag6;
											bool flag13 = flag7;
											if (flag13)
											{
												bool flag8 = methodDef2.Parameters.Count == 0 || methodDef2.Parameters.Count > 4;
												bool flag9 = !flag8;
												bool flag14 = flag9;
												if (flag14)
												{
													MethodDef methodDef3 = methodDef2.CopyMethod(md);
													methodDef2.Module.GlobalType.Methods.Add(methodDef3);
													ProxyExtension.CloneSignature(methodDef2, methodDef3);
													CilBody cilBody = new CilBody();
													cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
													for (int k = 0; k < methodDef2.Parameters.Count; k++)
													{
														switch (k)
														{
														case 0:
															cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
															break;
														case 1:
															cilBody.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
															break;
														case 2:
															cilBody.Instructions.Add(OpCodes.Ldarg_2.ToInstruction());
															break;
														case 3:
															cilBody.Instructions.Add(OpCodes.Ldarg_3.ToInstruction());
															break;
														}
													}
													cilBody.Instructions.Add(OpCodes.Call.ToInstruction(methodDef3));
													cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
													methodDef2.Body = cilBody;
													Ref_Proxy.Amount++;
												}
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
		}
	}
}
