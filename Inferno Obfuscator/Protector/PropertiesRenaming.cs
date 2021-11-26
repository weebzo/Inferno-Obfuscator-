using System;
using dnlib.DotNet;

namespace Protector
{
	// Token: 0x02000020 RID: 32
	public class PropertiesRenaming : IRenaming
	{
		// Token: 0x06000093 RID: 147 RVA: 0x0000D2A0 File Offset: 0x0000B4A0
		public ModuleDefMD Rename(ModuleDefMD module)
		{
			foreach (TypeDef type in module.GetTypes())
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				if (!isGlobalModuleType)
				{
					foreach (PropertyDef property in type.Properties)
					{
						property.Name = Generator.GenerateString();
					}
				}
			}
			return module;
		}
	}
}
