using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x0200000E RID: 14
internal class Class44
{
	// Token: 0x0600004A RID: 74 RVA: 0x00008DD8 File Offset: 0x00006FD8
	public static void smethod_0(ModuleDef moduleDef_0)
	{
		AssemblyResolver assemblyResolver = new AssemblyResolver();
		ModuleContext moduleContext = new ModuleContext(assemblyResolver);
		assemblyResolver.DefaultModuleContext = moduleContext;
		assemblyResolver.EnableTypeDefCache = true;
		List<AssemblyRef> list = moduleDef_0.GetAssemblyRefs().ToList<AssemblyRef>();
		moduleDef_0.Context = moduleContext;
		foreach (AssemblyRef assemblyRef in list)
		{
			bool flag = assemblyRef != null;
			if (flag)
			{
				AssemblyDef assemblyDef = assemblyResolver.Resolve(assemblyRef.FullName, moduleDef_0);
				bool flag2 = assemblyDef != null;
				if (flag2)
				{
					moduleDef_0.Context.AssemblyResolver.AddToCache(assemblyDef);
				}
			}
		}
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00008E94 File Offset: 0x00007094
	private static bool smethod_1(MemberRef memberRef_0)
	{
		Class44.Class45 @class = new Class44.Class45();
		@class.memberRef_0 = memberRef_0;
		bool flag2 = !@class.memberRef_0.ResolveMethodDefThrow().ReturnType.FullName.ToLower().Contains("bool");
		bool flag;
		if (flag2)
		{
			bool flag3 = !@class.memberRef_0.ResolveMethodDefThrow().ParamDefs.Any(new Func<ParamDef, bool>(Class44.Class46.method_0)) && !Class44.string_0.Any(new Func<string, bool>(@class.method_0));
			if (flag3)
			{
				flag = Class44.string_0.Any(new Func<string, bool>(@class.method_1));
				goto IL_9C;
			}
		}
		flag = true;
		IL_9C:
		bool flag4 = flag;
		bool result;
		if (flag4)
		{
			result = false;
		}
		else
		{
			bool flag5 = @class.memberRef_0.ResolveMethodDef().IsVirtual && @class.memberRef_0.Name != "GetMethod";
			if (flag5)
			{
				return false;
			}
			result = true;
		}
		return result;
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00008F8C File Offset: 0x0000718C
	public static void smethod_2()
	{
		foreach (TypeDef typeDef in Class64.moduleDef_0.Types.ToArray<TypeDef>())
		{
			foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
			{
				TypeDef globalType = methodDef.Module.GlobalType;
				bool flag = typeDef != globalType && !methodDef.FullName.Contains("My.") && methodDef.HasBody && methodDef.Body.HasInstructions;
				if (flag)
				{
					for (int i = 0; i < methodDef.Body.Instructions.Count; i++)
					{
						bool flag2 = methodDef.Body.Instructions[i].OpCode == OpCodes.Call || methodDef.Body.Instructions[i].OpCode == OpCodes.Callvirt;
						if (flag2)
						{
							try
							{
								MemberRef memberRef = (MemberRef)methodDef.Body.Instructions[i].Operand;
								methodDef.Body.Instructions[i].OpCode = OpCodes.Calli;
								methodDef.Body.Instructions[i].Operand = memberRef.MethodSig;
								methodDef.Body.Instructions.Insert(i, Instruction.Create(OpCodes.Ldftn, memberRef));
							}
							catch
							{
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00009148 File Offset: 0x00007348
	public static void smethod_3()
	{
		foreach (MethodDef methodDef in Class64.moduleDef_0.GetTypes().SelectMany(new Func<TypeDef, IEnumerable<MethodDef>>(Class44.Class46.method_1)))
		{
			bool flag = !methodDef.Name.Contains("Dispose");
			if (flag)
			{
				ModuleDef module = methodDef.Module;
				Class47 @class = new Class47();
				Class44.smethod_0(methodDef.Module);
				bool flag2 = !Class44.list_2.Contains(methodDef) && methodDef.HasBody;
				if (flag2)
				{
					foreach (Instruction instruction in methodDef.Body.Instructions.ToArray<Instruction>())
					{
						bool flag3 = instruction.OpCode == OpCodes.Newobj;
						if (flag3)
						{
							IMethodDefOrRef methodDefOrRef = instruction.Operand as IMethodDefOrRef;
							bool flag4 = !methodDefOrRef.IsMethodSpec && methodDefOrRef != null;
							if (flag4)
							{
								MethodDef methodDef2 = @class.method_1(methodDefOrRef, methodDef);
								bool flag5 = methodDef2 != null;
								if (flag5)
								{
									methodDef.DeclaringType.Methods.Add(methodDef2);
									Class44.list_2.Add(methodDef2);
									instruction.OpCode = OpCodes.Call;
									instruction.Operand = methodDef2;
									Class44.list_2.Add(methodDef2);
								}
							}
						}
						else
						{
							bool flag6 = instruction.OpCode == OpCodes.Stfld;
							if (flag6)
							{
								FieldDef fieldDef = instruction.Operand as FieldDef;
								bool flag7 = fieldDef != null;
								if (flag7)
								{
									CilBody cilBody = new CilBody();
									cilBody.Instructions.Add(OpCodes.Nop.ToInstruction());
									cilBody.Instructions.Add(OpCodes.Ldarg_0.ToInstruction());
									cilBody.Instructions.Add(OpCodes.Ldarg_1.ToInstruction());
									cilBody.Instructions.Add(OpCodes.Stfld.ToInstruction(fieldDef));
									cilBody.Instructions.Add(OpCodes.Ret.ToInstruction());
									MethodSig methodSig = MethodSig.CreateInstance(module.CorLibTypes.Void, fieldDef.FieldSig.GetFieldType());
									methodSig.HasThis = true;
									MethodDefUser methodDefUser = new MethodDefUser(Class42.smethod_1(4), methodSig)
									{
										Body = cilBody,
										IsHideBySig = true
									};
									Class44.list_2.Add(methodDefUser);
									methodDef.DeclaringType.Methods.Add(methodDefUser);
									instruction.Operand = methodDefUser;
									instruction.OpCode = OpCodes.Call;
								}
							}
							else
							{
								bool flag8 = instruction.OpCode == OpCodes.Ldfld;
								if (flag8)
								{
									FieldDef fieldDef2 = instruction.Operand as FieldDef;
									bool flag9 = fieldDef2 != null;
									if (flag9)
									{
										MethodDef methodDef3 = @class.method_2(fieldDef2, methodDef);
										instruction.OpCode = OpCodes.Call;
										instruction.Operand = methodDef3;
										Class44.list_2.Add(methodDef3);
									}
								}
								else
								{
									bool flag10 = instruction.OpCode == OpCodes.Call && instruction.Operand is MemberRef;
									if (flag10)
									{
										MemberRef memberRef = (MemberRef)instruction.Operand;
										bool flag11 = !memberRef.FullName.Contains("Collections.Generic") && !memberRef.Name.Contains("ToString") && !memberRef.FullName.Contains("Thread::Start");
										if (flag11)
										{
											MethodDef methodDef4 = @class.method_0(methodDef.DeclaringType, memberRef, memberRef.HasThis, memberRef.FullName.StartsWith("System.Void"));
											bool flag12 = methodDef4 != null;
											if (flag12)
											{
												Class44.list_2.Add(methodDef4);
												methodDef4.Attributes = MethodAttributes.Static;
												methodDef.Module.GlobalType.Methods.Add(methodDef4);
												instruction.Operand = methodDef4;
												methodDef4.Body.Instructions.Add(new Instruction(OpCodes.Ret));
											}
										}
									}
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x04000011 RID: 17
	public static MethodDef methodDef_0;

	// Token: 0x04000012 RID: 18
	private static Random random_0 = new Random();

	// Token: 0x04000013 RID: 19
	private static string[] string_0 = new string[]
	{
		"ToArray",
		"set_foregroundcolor",
		"get_conte",
		"GetTypeFromHandle",
		"TypeFromHandle",
		"GetFunctionPointer",
		"get_value",
		"GetIndex",
		"set_IgnoreProtocal",
		"Split",
		"WithAuthor",
		"Match",
		"ClearAllHeaders",
		"Post",
		"set_IgnoreProtocal",
		"GetChannel",
		"op_Implicit",
		"invoke",
		"get_Task",
		"get_ContentType",
		"ADD",
		"op_Equality",
		"op_Inequality",
		"Contains",
		"FreeHGlobal",
		"get_Module",
		"ResolveMethod",
		".ctor",
		"ReadLine",
		"Dispose",
		"Next",
		"Async",
		"GetAwaiter",
		"SetException",
		"Exception",
		"Enter",
		"ReadLines",
		"UnaryOperation",
		"BinaryOperation",
		"Close",
		"WithTitle",
		"Format",
		"get_Memeber",
		"set_IgnoreProtocallErrors",
		"MoveNext",
		"Getinstances",
		"Build",
		"Serialize",
		"Exists",
		"UseCommandsNext",
		"Delay"
	};

	// Token: 0x04000014 RID: 20
	public static int int_0 = 0;

	// Token: 0x04000015 RID: 21
	public static List<MemberRef> list_0 = new List<MemberRef>();

	// Token: 0x04000016 RID: 22
	public static List<int> list_1 = new List<int>();

	// Token: 0x04000017 RID: 23
	public static List<MethodDef> list_2 = new List<MethodDef>();

	// Token: 0x0200006F RID: 111
	private sealed class Class45
	{
		// Token: 0x06000225 RID: 549 RVA: 0x0002987C File Offset: 0x00027A7C
		internal bool method_0(string string_0)
		{
			return string_0.ToLower().Contains(this.memberRef_0.Name.ToLower());
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000298B0 File Offset: 0x00027AB0
		internal bool method_1(string string_0)
		{
			return string_0.ToLower().Contains(this.memberRef_0.ResolveMethodDef().ReturnType.FullName.ToLower());
		}

		// Token: 0x0400012A RID: 298
		public MemberRef memberRef_0;
	}

	// Token: 0x02000070 RID: 112
	[Serializable]
	private sealed class Class46
	{
		// Token: 0x06000228 RID: 552 RVA: 0x000298F0 File Offset: 0x00027AF0
		internal static bool method_0(ParamDef paramDef_0)
		{
			return paramDef_0.IsOut;
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00029908 File Offset: 0x00027B08
		internal static IEnumerable<MethodDef> method_1(TypeDef typeDef_0)
		{
			return typeDef_0.Methods.ToArray<MethodDef>();
		}
	}
}
