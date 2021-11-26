using System;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000006 RID: 6
internal class Class24
{
	// Token: 0x0600001F RID: 31 RVA: 0x00006B48 File Offset: 0x00004D48
	public static void smethod_0(ModuleDef moduleDef_0)
	{
		Class24.methodDef_0 = (MethodDef)Class21.smethod_10(ModuleDefMD.Load(typeof(Class26).Module).ResolveTypeDef(MDToken.ToRID(typeof(Class26).MetadataToken)), moduleDef_0.GlobalType, moduleDef_0).Single(new Func<IDnlibDef, bool>(Class24.Class25.method_0));
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

	// Token: 0x06000020 RID: 32 RVA: 0x00006C10 File Offset: 0x00004E10
	public static void smethod_1()
	{
		Class24.smethod_0(Class64.moduleDef_0);
		foreach (TypeDef typeDef in Class64.moduleDef_0.GetTypes())
		{
			foreach (MethodDef methodDef in typeDef.Methods)
			{
				bool flag = methodDef != Class24.methodDef_0 && methodDef.Body != null;
				if (flag)
				{
					int count = methodDef.Body.Instructions.Count;
					for (int i = 0; i < count; i++)
					{
						Instruction instruction = methodDef.Body.Instructions[i];
						bool flag2 = instruction.OpCode == OpCodes.Ldstr;
						if (flag2)
						{
							Class24.smethod_2(i, methodDef, instruction, Class24.methodDef_0);
						}
					}
				}
			}
		}
	}

	// Token: 0x06000021 RID: 33 RVA: 0x00006D30 File Offset: 0x00004F30
	public static void smethod_2(int int_0, MethodDef methodDef_1, Instruction instruction_0, MethodDef methodDef_2)
	{
		long num = Class28.smethod_4().ToBinary();
		Instruction item = null;
		DateTime maxValue = DateTime.MaxValue;
		Class28.smethod_3(num, out maxValue, out item);
		string s = Class28.smethod_2(instruction_0.Operand.ToString(), maxValue);
		byte[] bytes = Encoding.ASCII.GetBytes(s);
		string text = Class42.smethod_1(15).ToString();
		byte[] data = bytes;
		methodDef_1.Module.Resources.Add(new EmbeddedResource(text, data, ManifestResourceAttributes.Public));
		instruction_0.OpCode = OpCodes.Ldstr;
		instruction_0.Operand = text;
		methodDef_1.Body.Instructions.Insert(int_0 + 1, OpCodes.Ldc_I8.ToInstruction(num));
		methodDef_1.Body.Instructions.Insert(int_0 + 2, item);
		methodDef_1.Body.Instructions.Insert(int_0 + 3, new Instruction(OpCodes.Call, methodDef_2));
	}

	// Token: 0x04000007 RID: 7
	public static MethodDef methodDef_0;

	// Token: 0x04000008 RID: 8
	private static Random random_0 = new Random();

	// Token: 0x0200006A RID: 106
	[CompilerGenerated]
	[Serializable]
	private sealed class Class25
	{
		// Token: 0x06000217 RID: 535 RVA: 0x00029708 File Offset: 0x00027908
		internal static bool method_0(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞";
		}
	}
}
