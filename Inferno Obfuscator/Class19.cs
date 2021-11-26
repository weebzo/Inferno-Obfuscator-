using System;
using System.Collections.Generic;
using System.Reflection;
using dnlib.DotNet.Emit;

// Token: 0x02000003 RID: 3
internal class Class19
{
	// Token: 0x0600000B RID: 11 RVA: 0x00005D30 File Offset: 0x00003F30
	public static OpCode smethod_0(OpCode opCode_1)
	{
		bool flag = Class19.dictionary_0.TryGetValue(opCode_1, out Class19.opCode_0);
		OpCode nop;
		if (flag)
		{
			nop = Class19.opCode_0;
		}
		else
		{
			nop = OpCodes.Nop;
		}
		return nop;
	}

	// Token: 0x0600000C RID: 12 RVA: 0x00005D64 File Offset: 0x00003F64
	public static void smethod_1()
	{
		Dictionary<short, OpCode> dictionary = new Dictionary<short, OpCode>(256);
		foreach (FieldInfo fieldInfo in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			bool flag = !(fieldInfo.FieldType != typeof(OpCode));
			if (flag)
			{
				OpCode value = (OpCode)fieldInfo.GetValue(null);
				dictionary[value.Value] = value;
			}
		}
		foreach (FieldInfo fieldInfo2 in typeof(OpCodes).GetFields(BindingFlags.Static | BindingFlags.Public))
		{
			bool flag2 = !(fieldInfo2.FieldType != typeof(OpCode));
			if (flag2)
			{
				OpCode opCode = (OpCode)fieldInfo2.GetValue(null);
				bool flag3 = dictionary.TryGetValue(opCode.Value, out Class19.opCode_0);
				if (flag3)
				{
					Class19.dictionary_0[opCode] = Class19.opCode_0;
				}
			}
		}
	}

	// Token: 0x04000003 RID: 3
	private static Dictionary<OpCode, OpCode> dictionary_0 = new Dictionary<OpCode, OpCode>();

	// Token: 0x04000004 RID: 4
	private static OpCode opCode_0;
}
