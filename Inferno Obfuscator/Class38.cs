using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x0200000B RID: 11
internal class Class38
{
	// Token: 0x06000039 RID: 57 RVA: 0x00007CF0 File Offset: 0x00005EF0
	public static void smethod_0(ModuleDef moduleDef_0)
	{
		IEnumerable<IDnlibDef> source = Class21.smethod_10(ModuleDefMD.Load(typeof(Class40).Module).ResolveTypeDef(MDToken.ToRID(typeof(Class40).MetadataToken)), moduleDef_0.GlobalType, moduleDef_0);
		Class38.methodDef_0 = (MethodDef)source.Single(new Func<IDnlibDef, bool>(Class38.Class39.method_0));
		Class38.methodDef_1 = (MethodDef)source.Single(new Func<IDnlibDef, bool>(Class38.Class39.method_1));
		Class38.methodDef_2 = (MethodDef)source.Single(new Func<IDnlibDef, bool>(Class38.Class39.method_2));
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

	// Token: 0x0600003A RID: 58 RVA: 0x00007DF4 File Offset: 0x00005FF4
	public static void smethod_1()
	{
		Class38.smethod_0(Class64.moduleDef_0);
		foreach (TypeDef typeDef in Class64.moduleDef_0.GetTypes())
		{
			foreach (MethodDef methodDef in typeDef.Methods)
			{
				bool flag = methodDef != Class38.methodDef_0 && methodDef != Class38.methodDef_1 && methodDef != Class38.methodDef_2 && methodDef.Body != null;
				if (flag)
				{
					int count = methodDef.Body.Instructions.Count;
					for (int i = 0; i < count; i++)
					{
						Instruction instruction = methodDef.Body.Instructions[i];
						bool flag2 = instruction.OpCode == OpCodes.Ldc_I4_S;
						if (flag2)
						{
							int.Parse(instruction.Operand.ToString());
							Class38.smethod_2(i, methodDef, instruction, Class38.methodDef_0);
						}
					}
				}
			}
		}
	}

	// Token: 0x0600003B RID: 59 RVA: 0x00007F38 File Offset: 0x00006138
	public static void smethod_2(int int_0, MethodDef methodDef_3, Instruction instruction_0, MethodDef methodDef_4)
	{
		byte[] bytes = BitConverter.GetBytes(int.Parse(instruction_0.Operand.ToString()));
		byte[] array = SHA1.Create().ComputeHash(BitConverter.GetBytes(1993));
		for (int i = 0; i <= bytes.Length * 2 + array.Length; i++)
		{
			bytes[i % bytes.Length] = ((byte)((int)(bytes[i % bytes.Length] + bytes[(i + 1) % bytes.Length]) % 256) ^ array[i % array.Length]);
		}
		string s = Convert.ToBase64String(bytes);
		string text = Class38.random_0.Next(1, 10000).ToString();
		byte[] bytes2 = Encoding.UTF8.GetBytes(s);
		methodDef_3.Module.Resources.Add(new EmbeddedResource(text, bytes2, ManifestResourceAttributes.Private));
		instruction_0.OpCode = OpCodes.Ldstr;
		instruction_0.Operand = text;
		methodDef_3.Body.Instructions.Insert(int_0 + 1, new Instruction(OpCodes.Call, methodDef_4));
	}

	// Token: 0x0600003C RID: 60 RVA: 0x00008040 File Offset: 0x00006240
	public static void smethod_3(int int_0, MethodDef methodDef_3, Instruction instruction_0, MethodDef methodDef_4)
	{
		byte[] bytes = BitConverter.GetBytes(float.Parse(instruction_0.Operand.ToString()));
		byte[] array = SHA1.Create().ComputeHash(BitConverter.GetBytes(1993));
		for (int i = 0; i <= bytes.Length * 2 + array.Length; i++)
		{
			bytes[i % bytes.Length] = 32;
		}
		string s = Convert.ToBase64String(bytes);
		string text = Class38.random_0.Next(1, 10000).ToString();
		byte[] bytes2 = Encoding.UTF8.GetBytes(s);
		methodDef_3.Module.Resources.Add(new EmbeddedResource(text, bytes2, ManifestResourceAttributes.Private));
		instruction_0.OpCode = OpCodes.Ldstr;
		instruction_0.Operand = text;
		methodDef_3.Body.Instructions.Insert(int_0 + 1, new Instruction(OpCodes.Call, methodDef_4));
	}

	// Token: 0x0600003D RID: 61 RVA: 0x00008124 File Offset: 0x00006324
	public static void smethod_4(int int_0, MethodDef methodDef_3, Instruction instruction_0, MethodDef methodDef_4)
	{
		byte[] bytes = BitConverter.GetBytes(long.Parse(instruction_0.Operand.ToString()));
		byte[] array = SHA1.Create().ComputeHash(BitConverter.GetBytes(1993));
		for (int i = 0; i <= bytes.Length * 2 + array.Length; i++)
		{
			bytes[i % bytes.Length] = ((byte)((int)(bytes[i % bytes.Length] + bytes[(i + 1) % bytes.Length]) % 256) ^ array[i % array.Length]);
		}
		string s = Convert.ToBase64String(bytes);
		string text = Class38.random_0.Next(1, 10000).ToString();
		byte[] bytes2 = Encoding.UTF8.GetBytes(s);
		methodDef_3.Module.Resources.Add(new EmbeddedResource(text, bytes2, ManifestResourceAttributes.Private));
		instruction_0.OpCode = OpCodes.Ldstr;
		instruction_0.Operand = text;
		methodDef_3.Body.Instructions.Insert(int_0 + 1, new Instruction(OpCodes.Call, methodDef_4));
	}

	// Token: 0x0400000C RID: 12
	public static MethodDef methodDef_0;

	// Token: 0x0400000D RID: 13
	public static MethodDef methodDef_1;

	// Token: 0x0400000E RID: 14
	public static MethodDef methodDef_2;

	// Token: 0x0400000F RID: 15
	private static Random random_0 = new Random();

	// Token: 0x0200006D RID: 109
	[Serializable]
	private sealed class Class39
	{
		// Token: 0x0600021D RID: 541 RVA: 0x00029794 File Offset: 0x00027994
		internal static bool method_0(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "InfernoObfuscator";
		}

		// Token: 0x0600021E RID: 542 RVA: 0x000297B8 File Offset: 0x000279B8
		internal static bool method_1(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "InfernoObfuscator";
		}

		// Token: 0x0600021F RID: 543 RVA: 0x000297DC File Offset: 0x000279DC
		internal static bool method_2(IDnlibDef idnlibDef_0)
		{
			return idnlibDef_0.Name == "InfernoObfuscator";
		}
	}
}
