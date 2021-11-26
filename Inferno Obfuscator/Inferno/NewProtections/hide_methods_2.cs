using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno.NewProtections
{
	// Token: 0x02000021 RID: 33
	internal class hide_methods_2
	{
		// Token: 0x06000095 RID: 149 RVA: 0x0000D360 File Offset: 0x0000B560
		public static void Execute(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				bool isGlobalModuleType = typeDef.IsGlobalModuleType;
				bool flag2 = !isGlobalModuleType;
				if (flag2)
				{
					foreach (MethodDef methodDef in typeDef.Methods)
					{
						bool flag = methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.Body.HasExceptionHandlers;
						bool flag3 = flag;
						if (flag3)
						{
							int num = 0;
							bool flag4 = num < methodDef.Body.Instructions.Count - 2;
							if (flag4)
							{
								Instruction target = methodDef.Body.Instructions[num + 1];
								methodDef.Body.Instructions.Insert(num + 1, Instruction.Create(OpCodes.Unaligned, byte.MaxValue));
								methodDef.Body.Instructions.Insert(num + 1, Instruction.Create(OpCodes.Br_S, target));
								num += 2;
							}
						}
					}
				}
			}
		}
	}
}
