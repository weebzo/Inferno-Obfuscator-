using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x0200000D RID: 13
internal class Class42
{
	// Token: 0x06000044 RID: 68 RVA: 0x00008500 File Offset: 0x00006700
	public static string smethod_0(int int_0)
	{
		return new string(Enumerable.Repeat<string>("他是说汉语的Ⓟⓡⓞⓣⓔⓒⓣｱ尺Ծｲ乇ζｲ丂INFERNO丂;͐̇̋̍̿̎̀͌ͣ͌҉9αβφχψω卍卍卍卍卍卍卍", int_0).Select(new Func<string, char>(Class42.Class43.method_0)).ToArray<char>());
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00008538 File Offset: 0x00006738
	public static string smethod_1(int int_0)
	{
		return new string(Enumerable.Repeat<string>("他是说汉语的Ⓟⓡⓞⓣⓔⓒⓣｱ尺Ծｲ乇ζｲ丂INFERNO丂;͐̇̋̍̿̎̀͌ͣ͌҉9αβφχψω卍卍卍卍卍卍卍", int_0).Select(new Func<string, char>(Class42.Class43.method_1)).ToArray<char>());
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00008570 File Offset: 0x00006770
	public static OpCode smethod_2(string string_0)
	{
		bool flag = string_0 == "ret";
		OpCode result;
		if (flag)
		{
			result = OpCodes.Ret;
		}
		else
		{
			bool flag2 = string_0 == "calli";
			if (flag2)
			{
				result = OpCodes.Calli;
			}
			else
			{
				bool flag3 = string_0 == "sizeof";
				if (flag3)
				{
					result = OpCodes.Sizeof;
				}
				else
				{
					bool flag4 = !(string_0 == "stloc");
					if (flag4)
					{
						result = OpCodes.UNKNOWN2;
					}
					else
					{
						result = OpCodes.Stloc;
					}
				}
			}
		}
		return result;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x000085EC File Offset: 0x000067EC
	public static void smethod_3([Optional] string string_0)
	{
		foreach (MethodDef methodDef in Class64.moduleDef_0.GetTypes().SelectMany(new Func<TypeDef, IEnumerable<MethodDef>>(Class42.Class43.method_2)))
		{
			bool flag = methodDef.HasBody && methodDef.Body.HasInstructions;
			if (flag)
			{
				IList<Instruction> instructions = methodDef.Body.Instructions;
				bool flag2 = string_0 != "true";
				if (flag2)
				{
					bool flag3 = methodDef.DeclaringType.Name != "<Module>";
					if (flag3)
					{
						continue;
					}
				}
				else
				{
					bool flag4 = methodDef.DeclaringType.Name == "<Module>";
					if (flag4)
					{
						continue;
					}
				}
				for (int i = 0; i < instructions.Count - 2; i++)
				{
					try
					{
						Instruction target = methodDef.Body.Instructions[i + 1];
						methodDef.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Unaligned, byte.MaxValue));
						methodDef.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Br_S, target));
						i += 2;
						break;
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error Occured When Obfuscating Methods, Error: " + ex.ToString());
					}
				}
				bool flag5 = methodDef.Body != null;
				if (flag5)
				{
					methodDef.Body.SimplifyBranches();
					bool flag6 = !(methodDef.ReturnType.FullName != "System.Void") && methodDef.HasBody && methodDef.Body.Instructions.Count != 0;
					if (flag6)
					{
						Local local = new Local(Class64.moduleDef_0.Import(typeof(int)).ToTypeSig());
						Local local2 = new Local(Class64.moduleDef_0.Import(typeof(bool)).ToTypeSig());
						methodDef.Body.Variables.Add(local);
						methodDef.Body.Variables.Add(local2);
						Instruction operand = null;
						int num = new Random().Next(1);
						bool flag7 = num != 0;
						if (flag7)
						{
							bool flag8 = num == 1;
							if (flag8)
							{
								operand = methodDef.Body.Instructions[methodDef.Body.Instructions.Count - 4];
							}
						}
						else
						{
							operand = methodDef.Body.Instructions[methodDef.Body.Instructions.Count - 1];
						}
						Instruction instruction = new Instruction(OpCodes.Ret);
						Instruction instruction2 = new Instruction(OpCodes.Ldc_I4_1);
						methodDef.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4_0));
						methodDef.Body.Instructions.Insert(1, new Instruction(Class42.smethod_2("stloc"), local));
						methodDef.Body.Instructions.Insert(2, new Instruction(OpCodes.Br, instruction2));
						Instruction instruction3 = new Instruction(OpCodes.Ldloc, local);
						methodDef.Body.Instructions.Insert(3, instruction3);
						methodDef.Body.Instructions.Insert(4, new Instruction(OpCodes.Ldc_I4_0));
						methodDef.Body.Instructions.Insert(5, new Instruction(OpCodes.Ceq));
						methodDef.Body.Instructions.Insert(6, new Instruction(OpCodes.Ldc_I4_1));
						methodDef.Body.Instructions.Insert(7, new Instruction(OpCodes.Ceq));
						methodDef.Body.Instructions.Insert(8, new Instruction(Class42.smethod_2("stloc"), local2));
						methodDef.Body.Instructions.Insert(9, new Instruction(OpCodes.Ldloc, local2));
						methodDef.Body.Instructions.Insert(10, new Instruction(OpCodes.Brtrue, methodDef.Body.Instructions[10]));
						num = new Random().Next(1);
						bool flag9 = num != 0;
						if (flag9)
						{
							bool flag10 = num == 1;
							if (flag10)
							{
								methodDef.Body.Instructions.Insert(15, new Instruction(Class42.smethod_2("ret")));
								methodDef.Body.Instructions.Insert(16, new Instruction(Class42.smethod_2("calli")));
								methodDef.Body.Instructions.Insert(17, new Instruction(Class42.smethod_2("sizeof"), operand));
								methodDef.Body.Instructions.Insert(18, new Instruction(Class42.smethod_2("calli")));
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, instruction2);
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Stloc_S, local2));
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Br, instruction3));
								methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, instruction);
							}
						}
						else
						{
							methodDef.Body.Instructions.Insert(11, new Instruction(OpCodes.Ret));
							methodDef.Body.Instructions.Insert(12, new Instruction(OpCodes.Calli));
							methodDef.Body.Instructions.Insert(13, new Instruction(OpCodes.Sizeof, operand));
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, instruction2);
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(Class42.smethod_2("stloc"), local2));
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, new Instruction(OpCodes.Br, instruction3));
							methodDef.Body.Instructions.Insert(methodDef.Body.Instructions.Count, instruction);
						}
						ExceptionHandler item = new ExceptionHandler(ExceptionHandlerType.Finally)
						{
							HandlerStart = methodDef.Body.Instructions[10],
							HandlerEnd = methodDef.Body.Instructions[11],
							TryEnd = methodDef.Body.Instructions[14],
							TryStart = methodDef.Body.Instructions[12]
						};
						bool flag11 = !methodDef.Body.HasExceptionHandlers;
						if (flag11)
						{
							methodDef.Body.ExceptionHandlers.Add(item);
						}
						operand = new Instruction(OpCodes.Br, instruction);
						methodDef.Body.OptimizeBranches();
						methodDef.Body.OptimizeMacros();
						TypeDef declaringType = methodDef.DeclaringType;
						bool flag12 = !declaringType.IsGlobalModuleType && !(declaringType.Name == "GeneratedInternalTypeHelper") && methodDef.HasBody && !(methodDef.Name == ".ctor");
						if (flag12)
						{
							methodDef.Name == ".cctor";
						}
					}
				}
			}
		}
	}

	// Token: 0x04000010 RID: 16
	private static Random random_0 = new Random();

	// Token: 0x0200006E RID: 110
	[CompilerGenerated]
	[Serializable]
	private sealed class Class43
	{
		// Token: 0x06000221 RID: 545 RVA: 0x00029808 File Offset: 0x00027A08
		internal static char method_0(string string_0)
		{
			return string_0[Class42.random_0.Next(string_0.Length)];
		}

		// Token: 0x06000222 RID: 546 RVA: 0x00029830 File Offset: 0x00027A30
		internal static char method_1(string string_0)
		{
			return string_0[Class42.random_0.Next(string_0.Length)];
		}

		// Token: 0x06000223 RID: 547 RVA: 0x00029858 File Offset: 0x00027A58
		internal static IEnumerable<MethodDef> method_2(TypeDef typeDef_0)
		{
			return typeDef_0.Methods;
		}
	}
}
