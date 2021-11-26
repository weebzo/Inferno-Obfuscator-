using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000015 RID: 21
internal class Class58
{
	// Token: 0x06000069 RID: 105 RVA: 0x0000A954 File Offset: 0x00008B54
	public static void smethod_0()
	{
		Class58.dictionary_0 = Class58.smethod_4(Class64.moduleDef_0);
		Class58.moduleDef_0 = Class64.moduleDef_0;
		foreach (TypeDef typeDef in Class58.moduleDef_0.Types)
		{
			foreach (MethodDef methodDef in typeDef.Methods)
			{
				bool flag = methodDef.HasBody && methodDef.Body.HasInstructions && !methodDef.IsNative && methodDef.DeclaringType != methodDef.Module.GlobalType;
				if (flag)
				{
					CilBody body = methodDef.Body;
					body.SimplifyBranches();
					CilBody cilBody = body;
					ushort maxStack = cilBody.MaxStack;
					cilBody.MaxStack = maxStack;
					List<Instruction> list_ = body.Instructions.ToList<Instruction>();
					new List<GClass0>();
					List<GClass0> list = new List<GClass0>();
					try
					{
						list.Add(Class58.smethod_2(new GClass0
						{
							list_0 = list_
						}, false));
					}
					catch
					{
					}
					body.Instructions.Clear();
					List<GClass0>.Enumerator enumerator3 = list.GetEnumerator();
				}
			}
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x0000AAEC File Offset: 0x00008CEC
	public static List<T> smethod_1<T>(List<T> list_0, out int[] int_0)
	{
		Random random = new Random();
		List<KeyValuePair<int, T>> list = new List<KeyValuePair<int, T>>();
		foreach (T value in list_0)
		{
			list.Add(new KeyValuePair<int, T>(random.Next(), value));
		}
		IEnumerable<KeyValuePair<int, T>> enumerable = list.OrderBy(new Func<KeyValuePair<int, T>, int>(Class58.Class59<T>.method_0));
		T[] array = new T[list_0.Count];
		int num = 0;
		foreach (KeyValuePair<int, T> keyValuePair in enumerable)
		{
			array[num] = keyValuePair.Value;
			num++;
		}
		List<int> list2 = new List<int>();
		for (int i = 0; i < list_0.Count; i++)
		{
			list2.Add(Array.IndexOf<T>(list_0.ToArray(), array[i]));
		}
		int_0 = list2.ToArray();
		return array.ToList<T>();
	}

	// Token: 0x0600006B RID: 107 RVA: 0x0000AC20 File Offset: 0x00008E20
	public static GClass0 smethod_2(GClass0 gclass0_0, bool bool_0)
	{
		List<GClass1> list = new List<GClass1>();
		List<Instruction> list_ = gclass0_0.list_0;
		Instruction item = Instruction.Create(OpCodes.Br, list_[0]);
		GClass1 gclass = new GClass1
		{
			list_0 = new List<Instruction>(),
			list_2 = new List<Instruction>(),
			list_1 = new List<Instruction>()
		};
		int num = 0;
		for (int i = 0; i < list_.Count; i++)
		{
			Instruction instruction = list_[i];
			int num2;
			int num3;
			instruction.CalculateStackUsage(out num2, out num3);
			num += num2 - num3;
			bool flag = instruction.OpCode == OpCodes.Ret;
			if (flag)
			{
				gclass.list_1.Add(instruction);
				list.Add((GClass1)gclass.Clone());
				gclass.method_0();
			}
			else
			{
				bool flag2 = num == 0 && instruction.OpCode.OpCodeType != OpCodeType.Prefix;
				if (flag2)
				{
					MethodDef methodDef = Class58.dictionary_0.Keys.ToArray<MethodDef>()[Class58.random_0.Next(0, 4)];
					gclass.list_0.Add(instruction);
					bool flag3 = Class58.random_0.Next(0, 2) == 0;
					if (flag3)
					{
						gclass.list_1.Add(Instruction.CreateLdcI4(Class58.dictionary_0[methodDef].Item2[Class58.random_0.Next(0, 4)]));
						gclass.list_1.Add(Instruction.Create(OpCodes.Call, methodDef));
						gclass.list_1.Add(Instruction.Create(OpCodes.Brfalse, list_[i + 1]));
					}
					else
					{
						gclass.list_1.Add(Instruction.CreateLdcI4(Class58.dictionary_0[methodDef].Item1[Class58.random_0.Next(0, 4)]));
						gclass.list_1.Add(Instruction.Create(OpCodes.Call, methodDef));
						gclass.list_1.Add(Instruction.Create(OpCodes.Brtrue, list_[i + 1]));
					}
					list.Add((GClass1)gclass.Clone());
					gclass.method_0();
				}
				else
				{
					gclass.list_0.Add(instruction);
				}
			}
		}
		int[] array;
		list = Class58.smethod_1<GClass1>(list, out array);
		int index = Array.IndexOf<int>(array, array.Length - 1);
		GClass1 value = list[array.Length - 1];
		GClass1 value2 = list[index];
		list[index] = value;
		list[array.Length - 1] = value2;
		if (bool_0)
		{
			int index2 = Array.IndexOf<int>(array, 0);
			GClass1 value3 = list[0];
			GClass1 value4 = list[index2];
			list[index2] = value3;
			list[0] = value4;
		}
		foreach (GClass1 gclass2 in list)
		{
			bool flag4 = gclass2.list_1[0].OpCode != OpCodes.Ret;
			if (flag4)
			{
				MethodDef methodDef2 = Class58.dictionary_0.Keys.ToArray<MethodDef>()[Class58.random_0.Next(0, 4)];
				int index3 = Class58.random_0.Next(0, list.Count);
				while (list[index3].list_0.Count == 0)
				{
					index3 = Class58.random_0.Next(0, list.Count);
				}
				bool flag5 = Class58.random_0.Next(0, 2) == 0;
				if (flag5)
				{
					gclass2.list_2.Add(Instruction.CreateLdcI4(Class58.dictionary_0[methodDef2].Item1[Class58.random_0.Next(0, 4)]));
					gclass2.list_2.Add(Instruction.Create(OpCodes.Call, methodDef2));
					gclass2.list_2.Add(Instruction.Create(OpCodes.Brfalse, list[index3].list_0[0]));
				}
				else
				{
					gclass2.list_2.Add(Instruction.CreateLdcI4(Class58.dictionary_0[methodDef2].Item2[Class58.random_0.Next(0, 4)]));
					gclass2.list_2.Add(Instruction.Create(OpCodes.Call, methodDef2));
					gclass2.list_2.Add(Instruction.Create(OpCodes.Brtrue, list[index3].list_0[0]));
				}
			}
		}
		List<Instruction> list2 = new List<Instruction>();
		foreach (GClass1 gclass3 in list)
		{
			list2.AddRange(gclass3.list_0);
			bool flag6 = Class58.random_0.Next(0, 2) == 0;
			if (flag6)
			{
				bool flag7 = gclass3.list_1.Count != 0;
				if (flag7)
				{
					list2.AddRange(gclass3.list_1);
				}
				bool flag8 = gclass3.list_2.Count != 0;
				if (flag8)
				{
					list2.AddRange(gclass3.list_2);
				}
			}
			else
			{
				bool flag9 = gclass3.list_2.Count != 0;
				if (flag9)
				{
					list2.AddRange(gclass3.list_2);
				}
				bool flag10 = gclass3.list_1.Count != 0;
				if (flag10)
				{
					list2.AddRange(gclass3.list_1);
				}
			}
			bool flag11 = gclass3.instruction_0 != null;
			if (flag11)
			{
				list2.Add(gclass3.instruction_0);
			}
		}
		bool flag12 = !bool_0;
		if (flag12)
		{
			list2.Insert(0, item);
		}
		return new GClass0
		{
			list_0 = list2
		};
	}

	// Token: 0x0600006C RID: 108 RVA: 0x0000B224 File Offset: 0x00009424
	public static string smethod_3(int int_0)
	{
		return new string(Enumerable.Repeat<string>("痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵蘞虢謊謁AKJDJWJHDJ8928473278_--e--..efew", int_0).Select(new Func<string, char>(Class58.Class60.method_0)).ToArray<char>());
	}

	// Token: 0x0600006D RID: 109 RVA: 0x0000B25C File Offset: 0x0000945C
	public static Dictionary<MethodDef, Tuple<int[], int[]>> smethod_4(ModuleDef moduleDef_1)
	{
		Class57 @class = new Class57(3);
		int[] array = new int[4];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Class58.random_0.Next(2, 25);
		}
		Instruction[,] array2 = new Instruction[4, 10];
		for (int j = 0; j < 4; j++)
		{
			Instruction[] array3 = @class.method_0();
			for (int k = 0; k < array3.Length; k++)
			{
				array2[j, k] = array3[k];
			}
		}
		List<Tuple<Instruction[], Tuple<int, Tuple<int[], int[]>>>> list = new List<Tuple<Instruction[], Tuple<int, Tuple<int[], int[]>>>>();
		for (int l = 0; l < 4; l++)
		{
			List<Instruction> list2 = new List<Instruction>();
			int[] array4 = new int[5];
			int[] array5 = new int[5];
			for (int m = 0; m < 10; m++)
			{
				list2.Add(array2[l, m]);
			}
			for (int n = 0; n < 5; n++)
			{
				array4[n] = @class.method_1(list2.ToArray(), array[l], true);
			}
			for (int num = 0; num < 5; num++)
			{
				array5[num] = @class.method_1(list2.ToArray(), array[l], false);
			}
			list.Add(Tuple.Create<Instruction[], Tuple<int, Tuple<int[], int[]>>>(list2.ToArray(), Tuple.Create<int, Tuple<int[], int[]>>(array[l], Tuple.Create<int[], int[]>(array4, array5))));
		}
		Dictionary<MethodDef, Tuple<int[], int[]>> dictionary = new Dictionary<MethodDef, Tuple<int[], int[]>>();
		MethodAttributes flags = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig;
		MethodImplAttributes implFlags = MethodImplAttributes.IL;
		for (int num2 = 0; num2 < 4; num2++)
		{
			MethodDef methodDef = new MethodDefUser("", MethodSig.CreateStatic(moduleDef_1.CorLibTypes.Boolean, moduleDef_1.CorLibTypes.Int32), implFlags, flags);
			methodDef.Name = Class58.smethod_3(15);
			methodDef.Body = new CilBody();
			methodDef.ParamDefs.Add(new ParamDefUser("痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵蘞虢謊謁", 0));
			List<Instruction> list3 = new List<Instruction>(list[num2].Item1);
			int item = list[num2].Item2.Item1;
			list3.Insert(list3.Count - 1, Instruction.CreateLdcI4(item));
			list3.Insert(list3.Count - 1, OpCodes.Rem.ToInstruction());
			list3.Insert(list3.Count - 1, Instruction.CreateLdcI4(0));
			list3.Insert(list3.Count - 1, Instruction.Create(OpCodes.Ceq));
			foreach (Instruction item2 in list3)
			{
				methodDef.Body.Instructions.Add(item2);
			}
			dictionary.Add(methodDef, list[num2].Item2.Item2);
		}
		TypeDef typeDef = new TypeDefUser("", "", moduleDef_1.CorLibTypes.Object.TypeDefOrRef);
		typeDef.Name = Class58.smethod_3(15);
		typeDef.Attributes = TypeAttributes.Public;
		moduleDef_1.Types.Add(typeDef);
		foreach (KeyValuePair<MethodDef, Tuple<int[], int[]>> keyValuePair in dictionary)
		{
			typeDef.Methods.Add(keyValuePair.Key);
		}
		return dictionary;
	}

	// Token: 0x04000021 RID: 33
	private static ModuleDef moduleDef_0;

	// Token: 0x04000022 RID: 34
	private static Dictionary<MethodDef, Tuple<int[], int[]>> dictionary_0;

	// Token: 0x04000023 RID: 35
	private static Random random_0 = new Random();

	// Token: 0x04000024 RID: 36
	private static Random random_1 = new Random();

	// Token: 0x02000074 RID: 116
	[CompilerGenerated]
	[Serializable]
	private sealed class Class59<T>
	{
		// Token: 0x06000235 RID: 565 RVA: 0x000299C0 File Offset: 0x00027BC0
		internal static int method_0(KeyValuePair<int, T> keyValuePair_0)
		{
			KeyValuePair<int, T> keyValuePair = keyValuePair_0;
			return keyValuePair.Key;
		}
	}

	// Token: 0x02000075 RID: 117
	[CompilerGenerated]
	[Serializable]
	private sealed class Class60
	{
		// Token: 0x06000237 RID: 567 RVA: 0x000299E4 File Offset: 0x00027BE4
		internal static char method_0(string string_0)
		{
			return string_0[Class58.random_1.Next(string_0.Length)];
		}
	}
}
