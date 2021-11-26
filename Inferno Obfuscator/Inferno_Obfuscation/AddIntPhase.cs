using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000028 RID: 40
	public static class AddIntPhase
	{
		// Token: 0x060000B2 RID: 178 RVA: 0x0000EC28 File Offset: 0x0000CE28
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef methodDef2 in type.Methods)
					{
						bool flag = !methodDef2.HasBody;
						if (!flag)
						{
							IList<Instruction> instr = methodDef2.Body.Instructions;
							for (int i = 0; i < instr.Count; i++)
							{
								bool flag2 = !methodDef2.Body.Instructions[i].IsLdcI4();
								if (!flag2)
								{
									Random rnd = new Random();
									int randomuint = rnd.Next(int.MaxValue);
									methodDef2.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, methodDef2.Module.Import(typeof(bool))));
									methodDef2.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
									methodDef2.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_R8, 1.5707963267948966));
									methodDef2.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Call, methodDef2.Module.Import(typeof(Math).GetMethod("Sin", new Type[]
									{
										typeof(double)
									}))));
									methodDef2.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Conv_I4));
									methodDef2.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Sub));
									methodDef2.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Sizeof, methodDef2.Module.Import(typeof(bool))));
									methodDef2.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Add));
									methodDef2.Body.Instructions.Insert(i + 9, Instruction.Create(OpCodes.Ldc_R8, 3.141592653589793 / (double)randomuint));
									methodDef2.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Call, methodDef2.Module.Import(typeof(Math).GetMethod("Cos", new Type[]
									{
										typeof(double)
									}))));
									methodDef2.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Conv_I4));
									methodDef2.Body.Instructions.Insert(i + 12, Instruction.Create(OpCodes.Sub));
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x060000B3 RID: 179 RVA: 0x0000EF90 File Offset: 0x0000D190
		public static void Execute2(ModuleDef md)
		{
			foreach (TypeDef type in md.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef method in type.Methods)
					{
						bool flag = !method.HasBody;
						if (!flag)
						{
							for (int i = 0; i < method.Body.Instructions.Count; i++)
							{
								bool flag2 = !method.Body.Instructions[i].IsLdcI4();
								if (!flag2)
								{
									int numorig = new Random(Guid.NewGuid().GetHashCode()).Next();
									int div = new Random(Guid.NewGuid().GetHashCode()).Next();
									int num = numorig ^ div;
									Instruction nop = OpCodes.Nop.ToInstruction();
									Local local = new Local(method.Module.ImportAsTypeSig(typeof(int)));
									method.Body.Variables.Add(local);
									method.Body.Instructions.Insert(i + 1, OpCodes.Stloc.ToInstruction(local));
									method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, method.Body.Instructions[i].GetLdcI4Value() - 4));
									method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, num));
									method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, div));
									method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
									method.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, numorig));
									method.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, nop));
									method.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
									method.Body.Instructions.Insert(i + 9, OpCodes.Stloc.ToInstruction(local));
									method.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(float))));
									method.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
									method.Body.Instructions.Insert(i + 12, nop);
									i += 12;
								}
							}
							method.Body.SimplifyBranches();
						}
					}
				}
			}
		}
	}
}
