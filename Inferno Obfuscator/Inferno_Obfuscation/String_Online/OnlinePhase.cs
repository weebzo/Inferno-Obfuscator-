using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.String_Online
{
	// Token: 0x0200005E RID: 94
	public static class OnlinePhase
	{
		// Token: 0x060001F8 RID: 504 RVA: 0x00028350 File Offset: 0x00026550
		public static void Execute(ModuleDef module)
		{
			OnlinePhase.InjectClass1(module);
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef methodDef2 in type.Methods)
					{
						bool flag = !methodDef2.HasBody || !methodDef2.Body.HasInstructions;
						if (!flag)
						{
							bool flag2 = methodDef2.Name.Contains("Decoder");
							if (!flag2)
							{
								for (int i = 0; i < methodDef2.Body.Instructions.Count; i++)
								{
									bool flag3 = methodDef2.Body.Instructions[i].OpCode != OpCodes.Ldstr;
									if (!flag3)
									{
										string plainText = methodDef2.Body.Instructions[i].Operand.ToString();
										string operand = OnlinePhase.ConvertStringToHex(plainText);
										methodDef2.Body.Instructions[i].Operand = operand;
										methodDef2.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, UserControlSet.Init));
									}
								}
								methodDef2.Body.SimplifyBranches();
							}
						}
					}
				}
			}
		}

		// Token: 0x060001F9 RID: 505 RVA: 0x00028520 File Offset: 0x00026720
		public static string ConvertStringToHex(string asciiString)
		{
			string hex = string.Empty;
			foreach (char c in asciiString)
			{
				int tmp = (int)c;
				hex += string.Format("{0:x2}", Convert.ToUInt32(tmp.ToString()));
			}
			return hex;
		}

		// Token: 0x060001FA RID: 506 RVA: 0x00028580 File Offset: 0x00026780
		public static void InjectClass1(ModuleDef module)
		{
			ModuleDefMD typeModule = ModuleDefMD.Load(typeof(OnlineString).Module);
			TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(OnlineString).MetadataToken));
			IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, module.GlobalType, module);
			UserControlSet.Init = (MethodDef)members.Single((IDnlibDef method) => method.Name == "Decoder");
			foreach (MethodDef md in module.GlobalType.Methods)
			{
				bool flag = md.Name != ".ctor";
				if (!flag)
				{
					module.GlobalType.Remove(md);
					break;
				}
			}
		}
	}
}
