using System;
using dnlib.DotNet;

namespace Protector
{
	// Token: 0x0200001B RID: 27
	internal static class Renamer3
	{
		// Token: 0x06000084 RID: 132 RVA: 0x0000C6E0 File Offset: 0x0000A8E0
		public static ModuleDef Rename(ModuleDef mod)
		{
			ModuleDefMD module = (ModuleDefMD)mod;
			IRenaming rnm = new NamespacesRenaming();
			module = rnm.Rename(module);
			rnm = new ClassesRenaming();
			module = rnm.Rename(module);
			rnm = new MethodsRenaming();
			module = rnm.Rename(module);
			rnm = new PropertiesRenaming();
			module = rnm.Rename(module);
			rnm = new FieldsRenaming();
			return rnm.Rename(module);
		}
	}
}
