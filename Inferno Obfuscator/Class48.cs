using System;
using dnlib.DotNet;

// Token: 0x02000010 RID: 16
internal class Class48
{
	// Token: 0x06000054 RID: 84 RVA: 0x00009B3C File Offset: 0x00007D3C
	public static void smethod_0()
	{
		ModuleDef moduleDef_ = Class64.moduleDef_0;
		moduleDef_.Name = "��INFERNO OBFUSCATOR��";
		moduleDef_.Assembly.Name = "��Inferno OBFUSCATOR��";
		for (int i = 0; i < 25; i++)
		{
			InterfaceImpl item = new InterfaceImplUser(moduleDef_.GlobalType);
			TypeDef typeDef = new TypeDefUser("", Class42.smethod_1(6), moduleDef_.CorLibTypes.GetTypeRef("System", "Attribute"));
			InterfaceImpl item2 = new InterfaceImplUser(typeDef);
			moduleDef_.Types.Add(typeDef);
			typeDef.Interfaces.Add(item2);
			typeDef.Interfaces.Add(item);
		}
		for (int j = 0; j < 150; j++)
		{
			InterfaceImpl item3 = new InterfaceImplUser(moduleDef_.GlobalType);
			TypeDef typeDef2 = new TypeDefUser("!" + Class42.smethod_1(4), Class42.smethod_0(1), moduleDef_.CorLibTypes.GetTypeRef("System", "Attribute"));
			InterfaceImpl item4 = new InterfaceImplUser(typeDef2);
			moduleDef_.Types.Add(typeDef2);
			typeDef2.Interfaces.Add(item4);
			typeDef2.Interfaces.Add(item3);
		}
	}
}
