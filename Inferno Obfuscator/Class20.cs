using System;
using System.Collections.Generic;
using System.Reflection;
using dnlib.DotNet.Emit;

// Token: 0x02000004 RID: 4
internal class Class20
{
	// Token: 0x0600000F RID: 15 RVA: 0x00005E84 File Offset: 0x00004084
	public static OpCode smethod_0(OpCode opCode_1)
	{
		bool flag = Class20.dictionary_0.TryGetValue(opCode_1, out Class20.opCode_0);
		OpCode nop;
		if (flag)
		{
			nop = Class20.opCode_0;
		}
		else
		{
			nop = OpCodes.Nop;
		}
		return nop;
	}

	// Token: 0x06000010 RID: 16 RVA: 0x00005EB8 File Offset: 0x000040B8
	public static void smethod_1()
	{
		Dictionary<short, OpCode> dictionary = new Dictionary<short, OpCode>(256);
		foreach (FieldInfo fieldInfo in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			bool flag = !(fieldInfo.FieldType != typeof(OpCode));
			if (flag)
			{
				OpCode opCode = (OpCode)fieldInfo.GetValue(null);
				dictionary[opCode.Value] = opCode;
			}
		}
		foreach (FieldInfo fieldInfo2 in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			bool flag2 = !(fieldInfo2.FieldType != typeof(OpCode));
			if (flag2)
			{
				OpCode key = (OpCode)fieldInfo2.GetValue(null);
				bool flag3 = dictionary.TryGetValue(key.Value, out Class20.opCode_0);
				if (flag3)
				{
					Class20.dictionary_0[key] = Class20.opCode_0;
				}
			}
		}
	}

	// Token: 0x04000005 RID: 5
	private static Dictionary<OpCode, OpCode> dictionary_0 = new Dictionary<OpCode, OpCode>();

	// Token: 0x04000006 RID: 6
	private static OpCode opCode_0;
}
