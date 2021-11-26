using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Ayorah_Obfuscator;
using dnlib.DotNet;
using dnlib.DotNet.Emit;
using dnlib.DotNet.Writer;
using Inferno.NewProtections;
using Inferno_Obfuscation;
using Inferno_Obfuscation.ProxyV2;
using Inferno_Obfuscation.String_Online;
using Inferno_Obfuscation.Virtualization.Value_Virt;
using Inferno_Obfuscator;
using Protector;

// Token: 0x02000018 RID: 24
internal class Class64
{
	// Token: 0x06000076 RID: 118 RVA: 0x0000B6C9 File Offset: 0x000098C9
	public static void smethod_0(ModuleDef moduleDef_1)
	{
		Class64.moduleDef_0 = moduleDef_1;
		Class64.methodDef_0 = Class64.moduleDef_0.GlobalType.FindOrCreateStaticConstructor();
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0000B6E8 File Offset: 0x000098E8
	public static void smethod_1()
	{
		bool flag = Class64.bool_7;
		if (flag)
		{
			bool flag2 = Class64.bool_9;
			if (flag2)
			{
				Class44.smethod_3();
			}
			bool flag3 = Class64.bool_8;
			if (flag3)
			{
				Class44.smethod_2();
			}
		}
		bool flag4 = Class64.bool_6;
		if (flag4)
		{
			Class24.smethod_1();
			Class42.smethod_3("To Obfuscate Runtime Methods - Inferno");
		}
		bool flag5 = Class64.bool_2;
		if (flag5)
		{
			Class38.smethod_1();
			Class42.smethod_3("To Obfuscate Runtime Methods - Inferno");
		}
		bool flag6 = Class64.bool_10 && !Class64.bool_6;
		if (flag6)
		{
			Class52.smethod_3();
		}
		bool flag7 = Class64.bool_1;
		if (flag7)
		{
			Class48.smethod_0();
		}
		bool flag8 = Class64.bool_007;
		if (flag8)
		{
			foreach (TypeDef typeDef in Class64.moduleDef_0.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef method in typeDef.Methods.ToArray<MethodDef>())
				{
					mutatio.Mutate1(method);
					mutatio.Booleanisator(Class64.moduleDef_0);
				}
			}
		}
		bool flag9 = Class64.bool_5;
		if (flag9)
		{
			bool flag10 = Class64.bool_11;
			if (flag10)
			{
				Class58.smethod_0();
				Class16.smethod_0();
				Class16.smethod_0();
			}
			else
			{
				Class58.smethod_0();
				Class16.smethod_0();
			}
		}
		bool flag11 = Class64.bool_0;
		if (flag11)
		{
			Class42.smethod_3("true");
		}
		bool flag12 = Class64.bool_12;
		if (flag12)
		{
			Class30.smethod_5();
		}
		bool flag13 = Class64.bool_122;
		if (flag13)
		{
			Constant_Mutation.Execute(Class64.moduleDef_0);
		}
		bool flag14 = Class64.bool_88;
		if (flag14)
		{
			Class64.smethod_4(Class64.moduleDef_0);
		}
		bool flag15 = Class64.bool_888;
		if (flag15)
		{
			LocalToFields.Protect(Class64.moduleDef_0);
		}
		bool flag16 = Class64.bool_44;
		if (flag16)
		{
			foreach (TypeDef typeDef2 in Class64.moduleDef_0.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef method2 in typeDef2.Methods.ToArray<MethodDef>())
				{
					Class64.smethod_5(Class64.moduleDef_0);
					Constants__numbers_.ObfuscateNumbers(Class64.moduleDef_0);
					Constants__numbers_.FloatOutliner(method2);
				}
			}
		}
		bool flag17 = Class64.bool_22;
		if (flag17)
		{
			Class64.smethod_6(Class64.moduleDef_0);
		}
		bool flag18 = Class64.bool_222;
		if (flag18)
		{
			Ref_Proxy.Execute(Class64.moduleDef_0);
		}
		bool flag19 = Class64.bool_2222;
		if (flag19)
		{
			StringV4.encryptString(Class64.moduleDef_0);
		}
		bool flag20 = Class64.bool_8888;
		if (flag20)
		{
			Renamer3.Rename(Class64.moduleDef_0);
		}
		bool flag21 = Class64.bool_99;
		if (flag21)
		{
			SizeOf.Sizeof(Class64.moduleDef_0);
		}
		bool flag22 = Class64.bool_818;
		if (flag22)
		{
		}
		bool flag23 = Class64.bool_00;
		if (flag23)
		{
			string s = "InfernoObfuscator";
			byte[] bytes = Encoding.ASCII.GetBytes(s);
			for (int num3 = 0; num3 < 150; num3++)
			{
				EmbeddedResource item = new EmbeddedResource(new UTF8String(UserControlSet.RandomString(10)), bytes, ManifestResourceAttributes.Public);
				Class64.moduleDef_0.Resources.Add(item);
			}
		}
		bool flag24 = Class64.bool_999;
		if (flag24)
		{
			hide_methods_2.Execute(Class64.moduleDef_0);
		}
		bool flag25 = Class64.bool_111;
		if (flag25)
		{
			Anti_De4dot.RemoveDe4dot(Class64.moduleDef_0);
		}
		bool flag26 = Class64.bool_333;
		if (flag26)
		{
			StringEncPhase.Execute(Class64.moduleDef_0);
		}
		bool flag27 = Class64.bool_01;
		if (flag27)
		{
			Calli.Execute(Class64.moduleDef_0);
		}
		bool flag28 = Class64.bool_02;
		if (flag28)
		{
			L2FV2.Execute(Class64.moduleDef_0);
		}
		bool flag29 = Class64.bool_03;
		if (flag29)
		{
			L2F.Execute(Class64.moduleDef_0);
		}
		bool flag30 = Class64.bool_04;
		if (flag30)
		{
			RandomOutlinedMethods.Execute(Class64.moduleDef_0);
		}
		bool flag31 = Class64.bool_05;
		if (flag31)
		{
			MetaStrip.Execute((ModuleDefMD)Class64.moduleDef_0);
		}
		bool flag32 = Class64.bool_06;
		if (flag32)
		{
			AntiDump.Execute(Class64.moduleDef_0);
		}
		bool flag33 = Class64.bool_33;
		if (flag33)
		{
			renamer_v2.RenamerPhase.Execute(Class64.moduleDef_0);
		}
		bool flag34 = Class64.bool_500;
		if (flag34)
		{
			OnlinePhase.Execute(Class64.moduleDef_0);
		}
		bool flag35 = Class64.bool_50;
		if (flag35)
		{
			AddIntPhase.Execute(Class64.moduleDef_0);
			AddIntPhase.Execute2(Class64.moduleDef_0);
		}
		bool flag36 = Class64.bool_400;
		if (flag36)
		{
			ProxyString.Execute(Class64.moduleDef_0);
			ProxyMeth.ScanMemberRef(Class64.moduleDef_0);
			ProxyINT.Execute(Class64.moduleDef_0);
		}
		bool flag37 = Class64.bool_53;
		if (flag37)
		{
			Inject.InjectClass(Class64.moduleDef_0);
			Class16.smethod_0();
			Class44.smethod_3();
			Class42.smethod_3("true");
		}
		bool flag38 = Class64.bool_3;
		if (flag38)
		{
			Class49.smethod_1();
			Class42.smethod_3("To Obfuscate Runtime Methods - Inferno");
		}
		bool flag39 = Class64.bool_4;
		if (flag39)
		{
			bool flag40 = Class64.bool_11;
			if (flag40)
			{
				Class16.smethod_0();
				Class16.smethod_0();
			}
			else
			{
				Class16.smethod_0();
			}
		}
		Class64.smethod_2();
	}

	// Token: 0x06000078 RID: 120 RVA: 0x0000BC08 File Offset: 0x00009E08
	public static void smethod_2()
	{
		TypeDef globalType = Class64.moduleDef_0.GlobalType;
		TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
		globalType.Name = "InfernoObfuscator";
		globalType.BaseType = Class64.moduleDef_0.CorLibTypes.GetTypeRef("System", "Object");
		Class64.moduleDef_0.Types.Insert(0, typeDefUser);
		MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
		MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
		methodDef.Name = "InfernoObfuscator";
		methodDef.IsRuntimeSpecialName = false;
		methodDef.IsSpecialName = false;
		methodDef.Access = MethodAttributes.PrivateScope;
		methodDef2.Body = new CilBody(true, new List<Instruction>
		{
			Instruction.Create(OpCodes.Call, methodDef),
			Instruction.Create(OpCodes.Ret)
		}, new List<ExceptionHandler>(), new List<Local>());
		for (int i = 0; i < globalType.Methods.Count; i++)
		{
			MethodDef methodDef3 = globalType.Methods[i];
			bool isNative = methodDef3.IsNative;
			if (isNative)
			{
				MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone());
				methodDefUser.Attributes = (MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static);
				methodDefUser.Body = new CilBody();
				methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
				methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
				globalType.Methods[i] = methodDefUser;
				typeDefUser.Methods.Add(methodDef3);
			}
		}
	}

	// Token: 0x06000079 RID: 121 RVA: 0x0000BDB8 File Offset: 0x00009FB8
	public static void smethod_3()
	{
		Directory.CreateDirectory(".\\Protected by Inferno\\");
		Class64.moduleDef_0.Write(".\\Protected by Inferno\\" + Path.GetFileName(Class64.string_0), new ModuleWriterOptions(Class64.moduleDef_0)
		{
			Logger = DummyLogger.NoThrowInstance
		});
	}

	// Token: 0x0600007A RID: 122 RVA: 0x0000BE08 File Offset: 0x0000A008
	public static void smethod_4(ModuleDef md)
	{
		TypeDef globalType = md.GlobalType;
		TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
		globalType.Name = "Inferno_Obfuscation";
		globalType.BaseType = md.CorLibTypes.GetTypeRef("System", "Object");
		md.Types.Insert(0, typeDefUser);
		MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
		MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
		methodDef.Name = "Inferno_Obfuscation";
		methodDef.IsRuntimeSpecialName = false;
		methodDef.IsSpecialName = false;
		methodDef.Access = MethodAttributes.PrivateScope;
		methodDef2.Body = new CilBody(true, new List<Instruction>
		{
			Instruction.Create(OpCodes.Call, methodDef),
			Instruction.Create(OpCodes.Ret)
		}, new List<ExceptionHandler>(), new List<Local>());
		for (int i = 0; i < globalType.Methods.Count; i++)
		{
			MethodDef methodDef3 = globalType.Methods[i];
			bool isNative = methodDef3.IsNative;
			bool flag = isNative;
			bool flag2 = flag;
			if (flag2)
			{
				MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone());
				methodDefUser.Attributes = (MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static);
				methodDefUser.Body = new CilBody();
				methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
				methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
				globalType.Methods[i] = methodDefUser;
				typeDefUser.Methods.Add(methodDef3);
			}
		}
	}

	// Token: 0x0600007B RID: 123 RVA: 0x0000BFB4 File Offset: 0x0000A1B4
	public static void smethod_5(ModuleDef module)
	{
		Constants__numbers_.Execute(module);
		int num = new Random().Next(0, int.MaxValue);
		Constants__numbers_.InjectClass(module);
		foreach (TypeDef typeDef in module.GetTypes())
		{
			bool isGlobalModuleType = typeDef.IsGlobalModuleType;
			bool flag = !isGlobalModuleType;
			bool flag8 = flag;
			if (flag8)
			{
				foreach (MethodDef methodDef_ in typeDef.Methods)
				{
					bool flag2 = !methodDef_.HasBody;
					bool flag3 = !flag2;
					bool flag9 = flag3;
					if (flag9)
					{
						IList<Instruction> instructions = methodDef_.Body.Instructions;
						for (int i = 0; i < instructions.Count - 3; i++)
						{
							bool flag4 = instructions[i].OpCode == OpCodes.Ldc_I4;
							bool flag5 = flag4;
							bool flag10 = flag5;
							if (flag10)
							{
								int num2 = (int)instructions[i].Operand;
								int num3 = num2 * 69;
								num3 *= 2;
								instructions[i].Operand = num3;
								instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, "Inferno"));
								instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, "Inferno"));
								instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Constants__numbers_.init));
							}
							bool flag6 = instructions[i].OpCode == OpCodes.Ldc_R4;
							bool flag7 = flag6;
							bool flag11 = flag7;
							if (flag11)
							{
								float num4 = (float)instructions[i].Operand;
								float num5 = num4 * 69f;
								num5 *= 2f;
								instructions[i].Operand = num5;
								instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, "Inferno"));
								instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldstr, "Inferno"));
								instructions.Insert(i + 3, Instruction.Create(OpCodes.Call, Constants__numbers_.init1));
							}
						}
					}
				}
			}
		}
		Constants__numbers_.Melting(module);
	}

	// Token: 0x0600007C RID: 124 RVA: 0x0000C260 File Offset: 0x0000A460
	public static void smethod_6(ModuleDef module)
	{
		String_Encryption.InjectClass(module);
		foreach (TypeDef typeDef in module.GetTypes())
		{
			bool isGlobalModuleType = typeDef.IsGlobalModuleType;
			bool flag = !isGlobalModuleType;
			bool flag6 = flag;
			if (flag6)
			{
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					bool flag2 = !methodDef.HasBody;
					bool flag3 = !flag2;
					bool flag7 = flag3;
					if (flag7)
					{
						IList<Instruction> instructions = methodDef.Body.Instructions;
						for (int i = 0; i < instructions.Count - 3; i++)
						{
							bool flag4 = instructions[i].OpCode == OpCodes.Ldstr;
							bool flag5 = flag4;
							bool flag8 = flag5;
							if (flag8)
							{
								string plainText = instructions[i].Operand as string;
								string operand = String_Encryption.Encrypt(plainText);
								instructions[i].Operand = operand;
								instructions.Insert(i + 1, Instruction.Create(OpCodes.Call, String_Encryption.init));
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0400002A RID: 42
	public static ModuleDef moduleDef_0;

	// Token: 0x0400002B RID: 43
	public static MethodDef methodDef_0;

	// Token: 0x0400002C RID: 44
	public static bool bool_0 = false;

	// Token: 0x0400002D RID: 45
	public static bool bool_1 = false;

	// Token: 0x0400002E RID: 46
	public static bool bool_2 = false;

	// Token: 0x0400002F RID: 47
	public static bool bool_3 = false;

	// Token: 0x04000030 RID: 48
	public static bool bool_4 = false;

	// Token: 0x04000031 RID: 49
	public static bool bool_5 = false;

	// Token: 0x04000032 RID: 50
	public static bool bool_6 = false;

	// Token: 0x04000033 RID: 51
	public static bool bool_999 = false;

	// Token: 0x04000034 RID: 52
	public static bool bool_7 = false;

	// Token: 0x04000035 RID: 53
	public static bool bool_8 = false;

	// Token: 0x04000036 RID: 54
	public static bool bool_9 = true;

	// Token: 0x04000037 RID: 55
	public static bool bool_10 = false;

	// Token: 0x04000038 RID: 56
	public static bool bool_11 = true;

	// Token: 0x04000039 RID: 57
	public static bool bool_12 = false;

	// Token: 0x0400003A RID: 58
	public static string string_0;

	// Token: 0x0400003B RID: 59
	public static bool bool_88 = false;

	// Token: 0x0400003C RID: 60
	public static bool bool_818 = false;

	// Token: 0x0400003D RID: 61
	public static bool bool_00 = false;

	// Token: 0x0400003E RID: 62
	public static bool bool_44 = false;

	// Token: 0x0400003F RID: 63
	public static bool bool_22 = false;

	// Token: 0x04000040 RID: 64
	public static bool bool_2222 = false;

	// Token: 0x04000041 RID: 65
	public static bool bool_53 = false;

	// Token: 0x04000042 RID: 66
	public static bool bool_99 = false;

	// Token: 0x04000043 RID: 67
	public static bool bool_111 = false;

	// Token: 0x04000044 RID: 68
	public static bool bool_8888 = false;

	// Token: 0x04000045 RID: 69
	public static bool bool_888 = false;

	// Token: 0x04000046 RID: 70
	public static bool bool_122 = false;

	// Token: 0x04000047 RID: 71
	public static bool bool_222 = false;

	// Token: 0x04000048 RID: 72
	public static bool bool_33 = false;

	// Token: 0x04000049 RID: 73
	public static bool bool_333 = false;

	// Token: 0x0400004A RID: 74
	public static bool bool_500 = false;

	// Token: 0x0400004B RID: 75
	public static bool bool_400 = false;

	// Token: 0x0400004C RID: 76
	public static bool bool_50 = false;

	// Token: 0x0400004D RID: 77
	public static bool bool_01 = false;

	// Token: 0x0400004E RID: 78
	public static bool bool_02 = false;

	// Token: 0x0400004F RID: 79
	public static bool bool_03 = false;

	// Token: 0x04000050 RID: 80
	public static bool bool_04 = false;

	// Token: 0x04000051 RID: 81
	public static bool bool_05 = false;

	// Token: 0x04000052 RID: 82
	public static bool bool_06 = false;

	// Token: 0x04000053 RID: 83
	public static bool bool_007 = false;
}
