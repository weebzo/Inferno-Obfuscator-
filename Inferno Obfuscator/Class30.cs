using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;

// Token: 0x0200000A RID: 10
internal class Class30
{
	// Token: 0x06000031 RID: 49 RVA: 0x000079E8 File Offset: 0x00005BE8
	public static string smethod_0(int int_0)
	{
		return new string(Enumerable.Repeat<string>("痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞", int_0).Select(new Func<string, char>(Class30.Class31.method_0)).ToArray<char>());
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00007A20 File Offset: 0x00005C20
	public static bool smethod_1(TypeDef typeDef_0)
	{
		bool isGlobalModuleType = typeDef_0.IsGlobalModuleType;
		bool result;
		if (isGlobalModuleType)
		{
			result = false;
		}
		else
		{
			try
			{
				bool flag = typeDef_0.Namespace.Contains("My");
				if (flag)
				{
					return false;
				}
			}
			catch
			{
			}
			result = (typeDef_0.Interfaces.Count <= 0 && !typeDef_0.IsSpecialName && !typeDef_0.IsRuntimeSpecialName);
		}
		return result;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00007A98 File Offset: 0x00005C98
	public static bool smethod_2(MethodDef methodDef_0)
	{
		return !methodDef_0.IsConstructor && !methodDef_0.IsFamily && !methodDef_0.IsRuntimeSpecialName && !methodDef_0.DeclaringType.IsForwarder;
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00007AD4 File Offset: 0x00005CD4
	public static bool smethod_3(FieldDef fieldDef_0)
	{
		return !fieldDef_0.IsRuntimeSpecialName && (!fieldDef_0.IsLiteral || !fieldDef_0.DeclaringType.IsEnum);
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00007B0C File Offset: 0x00005D0C
	public static bool smethod_4(EventDef eventDef_0)
	{
		return !eventDef_0.IsRuntimeSpecialName;
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00007B28 File Offset: 0x00005D28
	public static void smethod_5()
	{
		foreach (TypeDef typeDef in Class64.moduleDef_0.Types.ToArray<TypeDef>())
		{
			foreach (MethodDef methodDef in typeDef.Methods)
			{
				bool flag = Class30.smethod_2(methodDef);
				if (flag)
				{
					methodDef.Name = Class30.smethod_0(15);
				}
				foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef.Parameters))
				{
					parameter.Name = Class30.smethod_0(15);
				}
			}
			foreach (FieldDef fieldDef in typeDef.Fields)
			{
				bool flag2 = Class30.smethod_3(fieldDef);
				if (flag2)
				{
					fieldDef.Name = Class30.smethod_0(15);
				}
			}
			foreach (EventDef eventDef in typeDef.Events)
			{
				bool flag3 = Class30.smethod_4(eventDef);
				if (flag3)
				{
					eventDef.Name = Class30.smethod_0(15);
				}
			}
		}
	}

	// Token: 0x0400000B RID: 11
	private static Random random_0 = new Random();

	// Token: 0x0200006C RID: 108
	[CompilerGenerated]
	[Serializable]
	private sealed class Class31
	{
		// Token: 0x0600021B RID: 539 RVA: 0x00029760 File Offset: 0x00027960
		internal static char method_0(string string_0)
		{
			return string_0[Class30.random_0.Next(string_0.Length)];
		}
	}
}
