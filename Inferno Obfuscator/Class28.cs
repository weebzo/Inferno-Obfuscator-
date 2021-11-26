using System;
using System.Linq;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000009 RID: 9
internal class Class28
{
	// Token: 0x06000029 RID: 41 RVA: 0x000073D4 File Offset: 0x000055D4
	public static void smethod_0(ModuleDef moduleDef_0)
	{
		Class28.methodDef_0 = (MethodDef)Class21.smethod_10(ModuleDefMD.Load(typeof(Class27).Module).ResolveTypeDef(MDToken.ToRID(typeof(Class27).MetadataToken)), moduleDef_0.GlobalType, moduleDef_0).Single(new Func<IDnlibDef, bool>(Class28.Class29.method_0));
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

	// Token: 0x0600002A RID: 42 RVA: 0x0000749C File Offset: 0x0000569C
	public static void smethod_1()
	{
		Class28.smethod_0(Class64.moduleDef_0);
		foreach (TypeDef typeDef in Class64.moduleDef_0.GetTypes())
		{
			foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
			{
				bool flag = methodDef != Class28.methodDef_0 && methodDef.HasBody && methodDef.Body.HasInstructions;
				if (flag)
				{
					int count = methodDef.Body.Instructions.Count;
					for (int i = 0; i < count; i++)
					{
						Instruction instruction = methodDef.Body.Instructions[i];
						bool flag2 = instruction.OpCode == OpCodes.Ldstr;
						if (flag2)
						{
							Class28.smethod_5(i, methodDef, instruction, Class28.methodDef_0);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000075B8 File Offset: 0x000057B8
	public static string smethod_2(string string_0, DateTime dateTime_0)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(string_0.PadRight(32, '\0'));
		byte[] bytes2 = Encoding.UTF8.GetBytes(dateTime_0.Ticks.ToString().PadRight(32, '\0'));
		int num = ((bytes.Length % 8 == 0) ? 0 : 1) + bytes.Length / 8;
		long[] array = new long[num];
		for (int i = 0; i < num - 1; i++)
		{
			array[i] = BitConverter.ToInt64(bytes, i * 8);
		}
		byte[] array2 = new byte[8];
		Array.Copy(bytes, (num - 1) * 8, array2, 0, bytes.Length - (num - 1) * 8);
		array[num - 1] = BitConverter.ToInt64(array2, 0);
		int num2 = ((bytes2.Length % 8 == 0) ? 0 : 1) + bytes2.Length / 8;
		long[] array3 = new long[num2];
		for (int j = 0; j < num2 - 1; j++)
		{
			array3[j] = BitConverter.ToInt64(bytes2, j * 8);
		}
		byte[] array4 = new byte[8];
		Array.Copy(bytes2, (num2 - 1) * 8, array4, 0, bytes2.Length - (num2 - 1) * 8);
		array3[num2 - 1] = BitConverter.ToInt64(array4, 0);
		int num3 = array.Length;
		bool flag = num3 < 1;
		if (flag)
		{
		}
		long num4 = array[array.Length - 1];
		long num5 = array[0];
		long num6 = 0L;
		long num7 = (long)(6 + 52 / num3);
		for (;;)
		{
			long num8 = num7;
			num7 = num8 - 1L;
			bool flag2 = num8 <= 0L;
			if (flag2)
			{
				break;
			}
			num6 += (long)((ulong)-1640531527);
			long num9 = num6 >> 2 & 3L;
			long num10;
			for (num10 = 0L; num10 < (long)(num3 - 1); num10 += 1L)
			{
				num5 = array[(int)((IntPtr)(num10 + 1L))];
				num4 = (array[(int)((IntPtr)num10)] += ((num4 >> 5 ^ num5 << 2) + (num5 >> 3 ^ num4 << 4) ^ (num6 ^ num5) + (array3[(int)((IntPtr)((num10 & 3L) ^ num9))] ^ num4)));
			}
			num5 = array[0];
			num4 = (array[num3 - 1] += ((num4 >> 5 ^ num5 << 2) + (num5 >> 3 ^ num4 << 4) ^ (num6 ^ num5) + (array3[(int)((IntPtr)((num10 & 3L) ^ num9))] ^ num4)));
		}
		StringBuilder stringBuilder = new StringBuilder();
		for (int k = 0; k < array.Length; k++)
		{
			stringBuilder.Append(array[k].ToString("x2").PadLeft(16, '0'));
		}
		return stringBuilder.ToString();
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00007870 File Offset: 0x00005A70
	public static void smethod_3(long long_0, out DateTime dateTime_0, out Instruction instruction_0)
	{
		Importer importer = new Importer(Class64.moduleDef_0, ImporterOptions.TryToUseDefs);
		instruction_0 = null;
		dateTime_0 = DateTime.MinValue;
		instruction_0 = new Instruction(OpCodes.Call, importer.Import(typeof(DateTime).GetMethod("FromBinary", new Type[]
		{
			typeof(long)
		})));
		dateTime_0 = DateTime.FromBinary(long_0);
	}

	// Token: 0x0600002D RID: 45 RVA: 0x000078E0 File Offset: 0x00005AE0
	public static DateTime smethod_4()
	{
		long num = DateTime.MaxValue.ToBinary() - DateTime.MinValue.ToBinary();
		long ticks = DateTime.MinValue.Ticks + (long)(new Random().NextDouble() * (double)num);
		return new DateTime(ticks);
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00007934 File Offset: 0x00005B34
	public static void smethod_5(int int_0, MethodDef methodDef_1, Instruction instruction_0, MethodDef methodDef_2)
	{
		long num = Class28.smethod_4().ToBinary();
		Instruction item = null;
		DateTime maxValue = DateTime.MaxValue;
		Class28.smethod_3(num, out maxValue, out item);
		string operand = Class28.smethod_2(instruction_0.Operand.ToString(), maxValue);
		instruction_0.Operand = operand;
		methodDef_1.Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I8.ToInstruction(num));
		methodDef_1.Body.Instructions.Insert(int_0 + 2, item);
		methodDef_1.Body.Instructions.Insert(int_0 + 3, new Instruction(OpCodes.Call, methodDef_2));
	}

	// Token: 0x04000009 RID: 9
	public static MethodDef methodDef_0;

	// Token: 0x0400000A RID: 10
	private static Random random_0 = new Random();

	// Token: 0x0200006B RID: 107
	[Serializable]
	private sealed class Class29
	{
		// Token: 0x06000219 RID: 537 RVA: 0x00029734 File Offset: 0x00027934
		internal static bool method_0(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞";
		}
	}
}
