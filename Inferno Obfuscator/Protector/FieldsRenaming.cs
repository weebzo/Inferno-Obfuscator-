using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Protector
{
	// Token: 0x0200001C RID: 28
	public class FieldsRenaming : IRenaming
	{
		// Token: 0x06000085 RID: 133 RVA: 0x0000C740 File Offset: 0x0000A940
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (FieldDef field in type.Fields)
					{
						string nameValue;
						bool flag = FieldsRenaming._names.TryGetValue(field.Name, out nameValue);
						if (flag)
						{
							field.Name = nameValue;
						}
						else
						{
							string newName = Generator.GenerateString();
							FieldsRenaming._names.Add(field.Name, newName);
							field.Name = newName;
						}
					}
				}
			}
			return FieldsRenaming.ApplyChangesToResources(module);
		}

		// Token: 0x06000086 RID: 134 RVA: 0x0000C850 File Offset: 0x0000AA50
		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (MethodDef method in type.Methods)
					{
						bool flag = method.Name != "InitializeComponent";
						if (!flag)
						{
							IList<Instruction> instr = method.Body.Instructions;
							for (int i = 0; i < instr.Count - 3; i++)
							{
								bool flag2 = instr[i].OpCode == OpCodes.Ldstr;
								if (flag2)
								{
									foreach (KeyValuePair<string, string> item in FieldsRenaming._names)
									{
										bool flag3 = item.Key == instr[i].Operand.ToString();
										if (flag3)
										{
											instr[i].Operand = item.Value;
										}
									}
								}
							}
						}
					}
				}
			}
			return module;
		}

		// Token: 0x04000055 RID: 85
		private static Dictionary<string, string> _names = new Dictionary<string, string>();
	}
}
