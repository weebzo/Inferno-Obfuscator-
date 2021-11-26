using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200002B RID: 43
	internal class Anti_De4dot
	{
		// Token: 0x060000BB RID: 187 RVA: 0x0000FB3C File Offset: 0x0000DD3C
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("⻏ㄩ讠ᐯ⻏⻏卄丿ᗪ\ud83d\udf57ᐯ卄⻏\ud83d\udf57ᗪ丂卄ᐯ\ud835\udcddㄩ讠山丂〤⼕丿闩ㄖ", length)
			select s[new Random().Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000BC RID: 188 RVA: 0x0000FB88 File Offset: 0x0000DD88
		public static void confuserex()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser item = new TypeDefUser("", "ConfusedByAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(item);
		}

		// Token: 0x060000BD RID: 189 RVA: 0x0000FBDC File Offset: 0x0000DDDC
		public static void babel()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "BabelObfuscatorAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000BE RID: 190 RVA: 0x0000FD0C File Offset: 0x0000DF0C
		public static void dotfuscator()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "DotfuscatorAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000BF RID: 191 RVA: 0x0000FE3C File Offset: 0x0000E03C
		public static void ninerays()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "NineRays.Obfuscator.Evaluation", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C0 RID: 192 RVA: 0x0000FF6C File Offset: 0x0000E16C
		public static void mango()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "();\t", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C1 RID: 193 RVA: 0x0001009C File Offset: 0x0000E29C
		public static void bithelmet()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "EMyPID_8234_", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			methodDefUser.Body.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
			methodDefUser.Body.Instructions.Add(OpCodes.Call.ToInstruction(new MemberRefUser(Anti_De4dot.publicmodule, ".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void), typeRef)));
			methodDefUser.Body.Instructions.Add(OpCodes.Ret.ToInstruction());
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C2 RID: 194 RVA: 0x000101CC File Offset: 0x0000E3CC
		public static void crypto()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "CryptoObfuscator.ProtectedWithCryptoObfuscatorAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C3 RID: 195 RVA: 0x00010280 File Offset: 0x0000E480
		public static void yano()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "YanoAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C4 RID: 196 RVA: 0x00010334 File Offset: 0x0000E534
		public static void dnguard()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "ZYXDNGuarder", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C5 RID: 197 RVA: 0x000103E8 File Offset: 0x0000E5E8
		public static void goliath()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "ObfuscatedByGoliath", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C6 RID: 198 RVA: 0x0001049C File Offset: 0x0000E69C
		public static void agile()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "SecureTeam.Attributes.ObfuscatedByAgileDotNetAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C7 RID: 199 RVA: 0x00010550 File Offset: 0x0000E750
		public static void smartassembly()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "SmartAssembly.Attributes.PoweredByAttribute", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C8 RID: 200 RVA: 0x00010604 File Offset: 0x0000E804
		public static void xenocode()
		{
			TypeRef typeRef = Anti_De4dot.publicmodule.CorLibTypes.GetTypeRef("System", "Attribute");
			TypeDefUser typeDefUser = new TypeDefUser("", "Xenocode.Client.Attributes.AssemblyAttributes.ProcessedByXenocode", typeRef);
			Anti_De4dot.publicmodule.Types.Add(typeDefUser);
			MethodDefUser methodDefUser = new MethodDefUser(".ctor", MethodSig.CreateInstance(Anti_De4dot.publicmodule.CorLibTypes.Void, Anti_De4dot.publicmodule.CorLibTypes.String), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.HideBySig | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
			methodDefUser.Body = new CilBody();
			methodDefUser.Body.MaxStack = 1;
			typeDefUser.Methods.Add(methodDefUser);
		}

		// Token: 0x060000C9 RID: 201 RVA: 0x000106B8 File Offset: 0x0000E8B8
		public static void RemoveDe4dot(ModuleDef md)
		{
			Anti_De4dot.publicmodule = md;
			for (int i = 1; i < 100; i++)
			{
				TypeDef typeDef = new TypeDefUser("", Renamer.Random(8) + Renamer.Random(8), md.CorLibTypes.GetTypeRef("System", "Attribute"));
				InterfaceImpl item = new InterfaceImplUser(typeDef);
				md.Types.Add(typeDef);
				typeDef.Interfaces.Add(item);
			}
			Anti_De4dot.xenocode();
			Anti_De4dot.smartassembly();
			Anti_De4dot.agile();
			Anti_De4dot.goliath();
			Anti_De4dot.yano();
			Anti_De4dot.crypto();
			Anti_De4dot.confuserex();
			Anti_De4dot.babel();
			Anti_De4dot.dotfuscator();
			Anti_De4dot.ninerays();
			Anti_De4dot.bithelmet();
			Anti_De4dot.mango();
			Anti_De4dot.dnguard();
		}

		// Token: 0x04000060 RID: 96
		private Random rnd = new Random();

		// Token: 0x04000061 RID: 97
		public static ModuleDef publicmodule;
	}
}
