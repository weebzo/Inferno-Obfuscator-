using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000013 RID: 19
internal class Class52
{
	// Token: 0x0600005C RID: 92 RVA: 0x00009FC4 File Offset: 0x000081C4
	public static bool smethod_0(IList<Instruction> ilist_0, int int_1)
	{
		return (ilist_0[int_1 + 1].GetOperand() == null || !ilist_0[int_1 + 1].Operand.ToString().Contains("bool")) && ilist_0[int_1 + 1].OpCode != OpCodes.Newobj && ilist_0[int_1].GetLdcI4Value() != 0 && ilist_0[int_1].GetLdcI4Value() != 1;
	}

	// Token: 0x0600005D RID: 93 RVA: 0x0000A040 File Offset: 0x00008240
	public static double smethod_1(double double_0, double double_1)
	{
		return new Random().NextDouble() * (double_1 - double_0) + double_0;
	}

	// Token: 0x0600005E RID: 94 RVA: 0x0000A064 File Offset: 0x00008264
	public static bool smethod_2(List<Instruction> list_3, int int_1)
	{
		return !new int[]
		{
			-2,
			-1,
			0,
			1,
			2
		}.Contains(list_3[int_1].GetLdcI4Value());
	}

	// Token: 0x0600005F RID: 95 RVA: 0x0000A09C File Offset: 0x0000829C
	public static void smethod_3()
	{
		foreach (MethodDef methodDef in Class64.moduleDef_0.GetTypes().SelectMany(new Func<TypeDef, IEnumerable<MethodDef>>(Class52.Class53.method_0)))
		{
			bool hasBody = methodDef.HasBody;
			if (hasBody)
			{
				for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
				{
					bool flag = methodDef.Body.Instructions[i].OpCode == OpCodes.Ldc_I4;
					if (flag)
					{
						int ldcI4Value = methodDef.Body.Instructions[i].GetLdcI4Value();
						int num = Class52.random_0.Next(3, 12);
						methodDef.Body.Instructions[i].Operand = ldcI4Value + num;
						methodDef.Body.Instructions.Insert(i + 1, OpCodes.Ldstr.ToInstruction(Class42.smethod_1(num)));
						methodDef.Body.Instructions.Insert(i + 2, OpCodes.Ldlen.ToInstruction());
						methodDef.Body.Instructions.Insert(i + 3, OpCodes.Sub.ToInstruction());
					}
				}
				for (int j = 0; j < methodDef.Body.Instructions.Count; j++)
				{
					bool flag2 = methodDef.Body.Instructions[j].OpCode == OpCodes.Ldc_I4;
					if (flag2)
					{
						methodDef.Body.Instructions.Insert(j + 1, Instruction.Create(OpCodes.Call, methodDef.Module.Import(typeof(Math).GetMethod("Abs", new Type[]
						{
							typeof(int)
						}))));
					}
				}
				for (int k = 0; k < methodDef.Body.Instructions.Count; k++)
				{
					bool flag3 = methodDef.Body.Instructions[k].OpCode == OpCodes.Ldc_I4 && methodDef.Body.Instructions[k].GetLdcI4Value() < int.MaxValue;
					if (flag3)
					{
						int num2 = (int)methodDef.Body.Instructions[k].Operand;
						double num3 = (double)num2 * (double)num2;
						methodDef.Body.Instructions[k].OpCode = OpCodes.Ldc_R8;
						methodDef.Body.Instructions[k].Operand = num3;
						methodDef.Body.Instructions.Insert(k + 1, OpCodes.Call.ToInstruction(methodDef.Module.Import(typeof(Math).GetMethod("Sqrt", new Type[]
						{
							typeof(double)
						}))));
						methodDef.Body.Instructions.Insert(k + 2, OpCodes.Conv_I4.ToInstruction());
					}
				}
			}
		}
	}

	// Token: 0x0400001A RID: 26
	public static Random random_0 = new Random();

	// Token: 0x0400001B RID: 27
	public static List<Instruction> list_0 = new List<Instruction>();

	// Token: 0x0400001C RID: 28
	private static List<int> list_1 = new List<int>();

	// Token: 0x0400001D RID: 29
	private static List<int> list_2 = new List<int>();

	// Token: 0x0400001E RID: 30
	private static int int_0 = 0;

	// Token: 0x02000072 RID: 114
	[CompilerGenerated]
	[Serializable]
	private sealed class Class53
	{
		// Token: 0x0600022F RID: 559 RVA: 0x0002999C File Offset: 0x00027B9C
		internal static IEnumerable<MethodDef> method_0(TypeDef typeDef_0)
		{
			return typeDef_0.Methods;
		}
	}
}
