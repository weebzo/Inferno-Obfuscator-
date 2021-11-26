using System;
using dnlib.DotNet;

namespace Protector
{
	// Token: 0x0200001E RID: 30
	public class MethodsRenaming : IRenaming
	{
		// Token: 0x0600008D RID: 141 RVA: 0x0000CDE8 File Offset: 0x0000AFE8
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					bool flag = type.Name == "GeneratedInternalTypeHelper";
					if (!flag)
					{
						foreach (MethodDef method in type.Methods)
						{
							bool flag2 = !method.HasBody;
							if (!flag2)
							{
								bool flag3 = method.Name == ".ctor" || method.Name == ".cctor";
								if (!flag3)
								{
									method.Name = Generator.GenerateString();
								}
							}
						}
					}
				}
			}
			return module;
		}
	}
}
