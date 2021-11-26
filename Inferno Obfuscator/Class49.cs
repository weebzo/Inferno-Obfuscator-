using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000011 RID: 17
internal class Class49
{
	// Token: 0x06000056 RID: 86 RVA: 0x00009CA4 File Offset: 0x00007EA4
	public static void smethod_0(ModuleDef moduleDef_0)
	{
		IEnumerable<IDnlibDef> source = Class21.smethod_10(ModuleDefMD.Load(typeof(Class51).Module).ResolveTypeDef(MDToken.ToRID(typeof(Class51).MetadataToken)), moduleDef_0.GlobalType, moduleDef_0);
		Class49.methodDef_0 = (MethodDef)source.Single(new Func<IDnlibDef, bool>(Class49.Class50.method_0));
		Class49.methodDef_1 = (MethodDef)source.Single(new Func<IDnlibDef, bool>(Class49.Class50.method_1));
		foreach (MethodDef methodDef in moduleDef_0.GlobalType.Methods)
		{
			bool flag = methodDef.Name == ".ctor";
			if (flag)
			{
				moduleDef_0.GlobalType.Remove(methodDef);
				break;
			}
		}
	}

	// Token: 0x06000057 RID: 87 RVA: 0x00009D8C File Offset: 0x00007F8C
	public static void smethod_1()
	{
		Class49.smethod_0(Class64.moduleDef_0);
		Class64.moduleDef_0.GlobalType.FindOrCreateStaticConstructor().Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, Class49.methodDef_0));
		foreach (MethodDef methodDef in Class64.moduleDef_0.GetTypes().SelectMany(new Func<TypeDef, IEnumerable<MethodDef>>(Class49.Class50.method_2)))
		{
			bool flag = !methodDef.FullName.Contains("My.") && !methodDef.FullName.Contains("InitializeCompnent") && !methodDef.IsConstructor && !methodDef.DeclaringType.IsGlobalModuleType && methodDef.HasBody;
			if (flag)
			{
				IList<Instruction> instructions = methodDef.Body.Instructions;
				int num = 0;
				bool flag2 = 0 < methodDef.Body.Instructions.Count - 2;
				if (flag2)
				{
					methodDef.Body.Instructions.Insert(num + 1, Instruction.Create(OpCodes.Ldstr, methodDef.Name));
					methodDef.Body.Instructions.Insert(num + 2, OpCodes.Call.ToInstruction(Class64.moduleDef_0.Import(typeof(MethodBase).GetMethod("GetCurrentMethod"))));
					methodDef.Body.Instructions.Insert(num + 3, Instruction.Create(OpCodes.Call, Class49.methodDef_1));
				}
			}
		}
	}

	// Token: 0x04000018 RID: 24
	public static MethodDef methodDef_0;

	// Token: 0x04000019 RID: 25
	public static MethodDef methodDef_1;

	// Token: 0x02000071 RID: 113
	[CompilerGenerated]
	[Serializable]
	private sealed class Class50
	{
		// Token: 0x0600022B RID: 555 RVA: 0x00029930 File Offset: 0x00027B30
		internal static bool method_0(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞";
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00029954 File Offset: 0x00027B54
		internal static bool method_1(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "CheckCurrentMethod";
		}

		// Token: 0x0600022D RID: 557 RVA: 0x00029978 File Offset: 0x00027B78
		internal static IEnumerable<MethodDef> method_2(TypeDef typeDef_0)
		{
			return typeDef_0.Methods;
		}
	}
}
