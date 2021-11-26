using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Protector
{
	// Token: 0x0200001D RID: 29
	public class ClassesRenaming : IRenaming
	{
		// Token: 0x06000089 RID: 137 RVA: 0x0000CA24 File Offset: 0x0000AC24
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					bool flag = type.Name == "GeneratedInternalTypeHelper" || type.Name == "Resources" || type.Name == "Settings";
					if (!flag)
					{
						string nameValue;
						bool flag2 = ClassesRenaming._names.TryGetValue(type.Name, out nameValue);
						if (flag2)
						{
							type.Name = nameValue;
						}
						else
						{
							string newName = Generator.GenerateString();
							ClassesRenaming._names.Add(type.Name, newName);
							type.Name = newName;
						}
					}
				}
			}
			return ClassesRenaming.ApplyChangesToResources(module);
		}

		// Token: 0x0600008A RID: 138 RVA: 0x0000CB30 File Offset: 0x0000AD30
		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			foreach (Resource resource in module.Resources)
			{
				foreach (KeyValuePair<string, string> item in ClassesRenaming._names)
				{
					bool flag = resource.Name.Contains(item.Key);
					if (flag)
					{
						resource.Name = resource.Name.Replace(item.Key, item.Value);
					}
				}
			}
			foreach (TypeDef type in module.GetTypes())
			{
				foreach (PropertyDef property in type.Properties)
				{
					bool flag2 = property.Name != "ResourceManager";
					if (!flag2)
					{
						IList<Instruction> instr = property.GetMethod.Body.Instructions;
						for (int i = 0; i < instr.Count; i++)
						{
							bool flag3 = instr[i].OpCode == OpCodes.Ldstr;
							if (flag3)
							{
								foreach (KeyValuePair<string, string> item2 in ClassesRenaming._names)
								{
									bool flag4 = instr[i].Operand.ToString().Contains(item2.Key);
									if (flag4)
									{
										instr[i].Operand = instr[i].Operand.ToString().Replace(item2.Key, item2.Value);
									}
								}
							}
						}
					}
				}
			}
			return module;
		}

		// Token: 0x04000056 RID: 86
		private static Dictionary<string, string> _names = new Dictionary<string, string>();
	}
}
