using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.ProxyV2
{
	// Token: 0x02000060 RID: 96
	public static class ProxyINT
	{
		// Token: 0x060001FD RID: 509 RVA: 0x000286B0 File Offset: 0x000268B0
		public static void Execute(ModuleDef module)
		{
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
								bool flag2 = method.Body.Instructions[i].IsLdcI4();
								if (flag2)
								{
									MethodImplAttributes methImplFlags = MethodImplAttributes.IL;
									MethodAttributes methFlags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
									MethodDefUser meth = new MethodDefUser(string.Format("InfernoOBF{0}", ProxyINT.rand.Next(0, int.MaxValue)), MethodSig.CreateStatic(module.CorLibTypes.Int32), methImplFlags, methFlags);
									module.GlobalType.Methods.Add(meth);
									meth.Body = new CilBody();
									meth.Body.Variables.Add(new Local(module.CorLibTypes.Int32));
									meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, instr[i].GetLdcI4Value()));
									meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
									instr[i].OpCode = OpCodes.Call;
									instr[i].Operand = meth;
								}
								else
								{
									bool flag3 = method.Body.Instructions[i].OpCode == OpCodes.Ldc_R4;
									if (flag3)
									{
										MethodImplAttributes methImplFlags2 = MethodImplAttributes.IL;
										MethodAttributes methFlags2 = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
										MethodDefUser meth2 = new MethodDefUser(string.Format("InfernoOBF{0}", ProxyINT.rand.Next(0, int.MaxValue)), MethodSig.CreateStatic(module.CorLibTypes.Double), methImplFlags2, methFlags2);
										module.GlobalType.Methods.Add(meth2);
										meth2.Body = new CilBody();
										meth2.Body.Variables.Add(new Local(module.CorLibTypes.Double));
										meth2.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_R4, (float)method.Body.Instructions[i].Operand));
										meth2.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
										instr[i].OpCode = OpCodes.Call;
										instr[i].Operand = meth2;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400011A RID: 282
		public static Random rand = new Random();
	}
}
