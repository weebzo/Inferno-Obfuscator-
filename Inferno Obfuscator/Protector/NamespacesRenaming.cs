using System;
using System.Collections.Generic;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Protector
{
	// Token: 0x0200001F RID: 31
	public class NamespacesRenaming : IRenaming
	{
		// Token: 0x0600008F RID: 143 RVA: 0x0000CF0C File Offset: 0x0000B10C
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					bool flag = type.Namespace == "";
					if (!flag)
					{
						string nameValue;
						bool flag2 = NamespacesRenaming._names.TryGetValue(type.Namespace, out nameValue);
						if (flag2)
						{
							type.Namespace = nameValue;
						}
						else
						{
							string newName = Generator.GenerateString();
							NamespacesRenaming._names.Add(type.Namespace, newName);
							type.Namespace = newName;
						}
					}
				}
			}
			return NamespacesRenaming.ApplyChangesToResources(module);
		}

		// Token: 0x06000090 RID: 144 RVA: 0x0000CFEC File Offset: 0x0000B1EC
		private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
		{
			foreach (Resource resource in module.Resources)
			{
				foreach (KeyValuePair<string, string> item in NamespacesRenaming._names)
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
								foreach (KeyValuePair<string, string> item2 in NamespacesRenaming._names)
								{
									bool flag4 = instr[i].ToString().Contains(item2.Key);
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

		// Token: 0x04000057 RID: 87
		private static Dictionary<string, string> _names = new Dictionary<string, string>();
	}
}
