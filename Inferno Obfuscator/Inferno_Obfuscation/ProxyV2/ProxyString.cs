using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.ProxyV2
{
	// Token: 0x02000064 RID: 100
	internal class ProxyString
	{
		// Token: 0x06000207 RID: 519 RVA: 0x00029308 File Offset: 0x00027508
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
							foreach (Instruction t in instr)
							{
								bool flag2 = t.OpCode != OpCodes.Ldstr;
								if (!flag2)
								{
									MethodImplAttributes methImplFlags = MethodImplAttributes.IL;
									MethodAttributes methFlags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
									MethodDefUser meth = new MethodDefUser(string.Format("InfernoOBF{0}", ProxyString.rand.Next(0, int.MaxValue)), MethodSig.CreateStatic(module.CorLibTypes.String), methImplFlags, methFlags);
									module.GlobalType.Methods.Add(meth);
									meth.Body = new CilBody();
									meth.Body.Variables.Add(new Local(module.CorLibTypes.String));
									meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, t.Operand.ToString()));
									meth.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
									t.OpCode = OpCodes.Call;
									t.Operand = meth;
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0400011E RID: 286
		public static Random rand = new Random();
	}
}
