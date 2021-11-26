using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000002 RID: 2
internal class Class16
{
	// Token: 0x06000001 RID: 1 RVA: 0x00002050 File Offset: 0x00000250
	public static void smethod_0()
	{
		foreach (MethodDef methodDef_ in Class64.moduleDef_0.GetTypes().SelectMany(new Func<TypeDef, IEnumerable<MethodDef>>(Class16.Class17.method_0)))
		{
			try
			{
				Class16.smethod_2(methodDef_);
			}
			catch
			{
			}
		}
	}

	// Token: 0x06000002 RID: 2 RVA: 0x000020CC File Offset: 0x000002CC
	public static void smethod_1(MethodDef methodDef_0)
	{
		Class16.Class18 @class = new Class16.Class18();
		@class.random_0 = new Random();
		int num = @class.random_0.Next(3, 5);
		@class.list_0 = new List<List<Instruction>>
		{
			new List<Instruction>()
		};
		for (int i = 0; i < methodDef_0.Body.Instructions.Count; i++)
		{
			List<Instruction> list = @class.list_0.Last<List<Instruction>>();
			bool flag = list.Count == num;
			if (flag)
			{
				num = @class.random_0.Next(3, 5);
				list = new List<Instruction>();
				@class.list_0.Add(list);
			}
			list.Add(methodDef_0.Body.Instructions[i]);
		}
		for (int j = 0; j < @class.list_0.Count - 1; j++)
		{
			switch (@class.random_0.Next(1, 4))
			{
			case 0:
				@class.list_0[j].Add((@class.random_0.Next(0, 2) == 0) ? dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction() : dnlib.DotNet.Emit.OpCodes.Ldc_I4_0.ToInstruction());
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Brfalse.ToInstruction(@class.list_0[j + 1][0]));
				break;
			case 1:
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(@class.random_0.Next(1, 1337)));
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Brtrue.ToInstruction(@class.list_0[j + 1][0]));
				break;
			case 2:
			{
				int num2 = @class.random_0.Next(1, 1337);
				int value = @class.random_0.Next(num2, 69420);
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num2));
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(value));
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Clt.ToInstruction());
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Brtrue.ToInstruction(@class.list_0[j + 1][0]));
				break;
			}
			case 3:
			{
				int value2 = @class.random_0.Next(1, 1337);
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(value2));
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(value2));
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Ceq.ToInstruction());
				@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Brtrue.ToInstruction(@class.list_0[j + 1][0]));
				break;
			}
			}
			@class.list_0[j].Add(dnlib.DotNet.Emit.OpCodes.Br.ToInstruction(@class.list_0[j][0]));
		}
		methodDef_0.Body.Instructions.Clear();
		IEnumerable<List<Instruction>> list_ = @class.list_0;
		Func<List<Instruction>, int> keySelector;
		bool flag2 = (keySelector = @class.func_0) == null;
		if (flag2)
		{
			keySelector = (@class.func_0 = new Func<List<Instruction>, int>(@class.method_0));
		}
		foreach (Instruction item in list_.OrderByDescending(keySelector).SelectMany(new Func<List<Instruction>, IEnumerable<Instruction>>(Class16.Class17.method_1)))
		{
			methodDef_0.Body.Instructions.Add(item);
		}
	}

	// Token: 0x06000003 RID: 3 RVA: 0x000024F8 File Offset: 0x000006F8
	public static void smethod_2(MethodDef methodDef_0)
	{
		methodDef_0.Body.Instructions.SimplifyBranches();
		methodDef_0.Body.Instructions.SimplifyMacros(methodDef_0.Body.Variables, methodDef_0.Parameters);
		List<Instruction> list = new List<Instruction>();
		Local local = new Local(new SZArraySig(methodDef_0.Module.CorLibTypes.Object));
		Local local2 = new Local(methodDef_0.Module.CorLibTypes.Object);
		Local local3 = new Local(new SZArraySig(methodDef_0.Module.CorLibTypes.Int32));
		Local local4 = new Local(methodDef_0.Module.CorLibTypes.Int32);
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(methodDef_0.Body.Variables.Count));
		list.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
		list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local3));
		for (int i = 0; i < methodDef_0.Body.Variables.Count; i++)
		{
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(i));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_M1.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_0.ToInstruction());
		list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local4));
		int j = 0;
		while (j < methodDef_0.Body.Instructions.Count)
		{
			Instruction instruction = methodDef_0.Body.Instructions[j];
			list.Add(instruction);
			bool flag = instruction.OpCode.Code == Code.Ldloc;
			if (flag)
			{
				goto IL_50D;
			}
			bool flag2 = instruction.OpCode.Code == Code.Ldloca;
			if (flag2)
			{
				goto IL_50D;
			}
			bool flag3 = instruction.OpCode.Code == Code.Stloc;
			if (flag3)
			{
				Local local5 = (Local)instruction.Operand;
				int index = local5.Index;
				bool isValueType = local5.Type.IsValueType;
				if (isValueType)
				{
					list.Add(dnlib.DotNet.Emit.OpCodes.Box.ToInstruction(local5.Type.ToTypeDefOrRef()));
				}
				else
				{
					list.Add(dnlib.DotNet.Emit.OpCodes.Castclass.ToInstruction(methodDef_0.Module.CorLibTypes.Object));
				}
				Instruction instruction2 = dnlib.DotNet.Emit.OpCodes.Nop.ToInstruction();
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_M1.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Ceq.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Brtrue.ToInstruction(instruction2));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(methodDef_0.Module.CorLibTypes.Object));
				list.Add(instruction2);
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local4));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_1.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Add.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local4));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local4));
				list.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
				list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local2));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local2));
				list.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local2));
				instruction.Operand = null;
				instruction.OpCode = dnlib.DotNet.Emit.OpCodes.Nop;
			}
			IL_501:
			j++;
			continue;
			IL_50D:
			Local local6 = (Local)instruction.Operand;
			int index2 = local6.Index;
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index2));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Object));
			list.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index2));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(methodDef_0.Module.CorLibTypes.Object));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local4));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_1.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Add.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local4));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index2));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local4));
			list.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
			list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local2));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local3));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(index2));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(methodDef_0.Module.CorLibTypes.Int32));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc.ToInstruction(local2));
			list.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
			list.Add(dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local2));
			bool isValueType2 = local6.Type.IsValueType;
			if (isValueType2)
			{
				bool flag4 = instruction.OpCode.Code == Code.Ldloc;
				if (flag4)
				{
					list.Add(dnlib.DotNet.Emit.OpCodes.Unbox_Any.ToInstruction(local6.Type.ToTypeDefOrRef()));
				}
				else
				{
					list.Add(dnlib.DotNet.Emit.OpCodes.Unbox.ToInstruction(local6.Type.ToTypeDefOrRef()));
				}
			}
			else
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Castclass.ToInstruction(local6.Type.ToTypeDefOrRef()));
			}
			instruction.Operand = null;
			instruction.OpCode = dnlib.DotNet.Emit.OpCodes.Nop;
			goto IL_501;
		}
		methodDef_0.Body.Variables.Clear();
		methodDef_0.Body.Variables.Add(local);
		methodDef_0.Body.Variables.Add(local2);
		methodDef_0.Body.Variables.Add(local3);
		methodDef_0.Body.Variables.Add(local4);
		list.Insert(0, dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(133769));
		list.Insert(1, dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(methodDef_0.Module.CorLibTypes.Object));
		list.Insert(2, dnlib.DotNet.Emit.OpCodes.Stloc.ToInstruction(local));
		list.OptimizeBranches();
		list.OptimizeMacros();
		methodDef_0.Body.Instructions.Clear();
		foreach (Instruction item in list)
		{
			methodDef_0.Body.Instructions.Add(item);
		}
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002E6C File Offset: 0x0000106C
	public static void smethod_3(MethodDef methodDef_0, ModuleDef moduleDef_0)
	{
		AssemblyDef assembly = moduleDef_0.Assembly;
		Class19.smethod_1();
		Class20.smethod_1();
		TypeDef declaringType = methodDef_0.DeclaringType;
		bool flag = !methodDef_0.HasBody;
		if (!flag)
		{
			bool flag2 = !methodDef_0.Body.HasInstructions;
			if (!flag2)
			{
				bool flag3 = methodDef_0.ReturnType.TypeName != "Void";
				if (!flag3)
				{
					bool flag4 = declaringType.Namespace == "";
					if (!flag4)
					{
						bool flag5 = declaringType.Namespace.Contains(".Properties");
						if (!flag5)
						{
							bool flag6 = declaringType.IsGlobalModuleType && methodDef_0.Name == ".cctor";
							if (!flag6)
							{
								Instruction[] instruction_ = methodDef_0.Body.Instructions.ToArray<Instruction>();
								Instruction[] array = null;
								Local local = new Local(assembly.ManifestModule.Import(typeof(List<Type>)).ToTypeSig());
								Local local2 = new Local(assembly.ManifestModule.Import(typeof(DynamicMethod)).ToTypeSig());
								Local local3 = new Local(assembly.ManifestModule.Import(typeof(ILGenerator)).ToTypeSig());
								Local local4 = new Local(assembly.ManifestModule.Import(typeof(Label[])).ToTypeSig());
								TypeSig returnType = methodDef_0.ReturnType;
								Local[] local_ = methodDef_0.Body.Variables.ToArray<Local>();
								List<Local> list = new List<Local>();
								bool flag7 = methodDef_0.Name != ".ctor";
								if (flag7)
								{
									bool hasParamDefs = methodDef_0.HasParamDefs;
									if (hasParamDefs)
									{
										array = Class16.smethod_4(methodDef_0.Body.Instructions.ToArray<Instruction>(), declaringType, methodDef_0, methodDef_0.ParamDefs[0].DeclaringMethod.MethodSig.Params, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, false, out list, returnType);
									}
									else
									{
										array = Class16.smethod_4(methodDef_0.Body.Instructions.ToArray<Instruction>(), declaringType, methodDef_0, null, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, false, out list, returnType);
									}
								}
								else
								{
									bool hasParamDefs2 = methodDef_0.HasParamDefs;
									if (hasParamDefs2)
									{
										array = Class16.smethod_4(methodDef_0.Body.Instructions.ToArray<Instruction>(), declaringType, methodDef_0, methodDef_0.ParamDefs[0].DeclaringMethod.MethodSig.Params, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, true, out list, returnType);
									}
									else
									{
										array = Class16.smethod_4(methodDef_0.Body.Instructions.ToArray<Instruction>(), declaringType, methodDef_0, null, methodDef_0.ReturnType.ToTypeDefOrRef(), methodDef_0.Parameters.ToArray<Parameter>(), declaringType, local, local2, local3, local4, local_, instruction_, assembly, true, out list, returnType);
									}
								}
								methodDef_0.Body.Instructions.Clear();
								methodDef_0.Body.Variables.Add(local);
								methodDef_0.Body.Variables.Add(local2);
								methodDef_0.Body.Variables.Add(local3);
								methodDef_0.Body.Variables.Add(local4);
								foreach (Local local5 in list)
								{
									methodDef_0.Body.Variables.Add(local5);
								}
								foreach (Instruction item in array)
								{
									methodDef_0.Body.Instructions.Add(item);
								}
							}
						}
					}
				}
			}
		}
	}

	// Token: 0x06000005 RID: 5 RVA: 0x0000325C File Offset: 0x0000145C
	public static Instruction[] smethod_4(Instruction[] instruction_0, TypeDef typeDef_0, MethodDef methodDef_0, IList<TypeSig> ilist_0, ITypeDefOrRef itypeDefOrRef_0, IList<Parameter> ilist_1, TypeDef typeDef_1, Local local_0, Local local_1, Local local_2, Local local_3, Local[] local_4, Instruction[] instruction_1, AssemblyDef assemblyDef_0, bool bool_0, out List<Local> list_0, TypeSig typeSig_0)
	{
		List<Instruction> list = new List<Instruction>();
		List<Local> list2 = new List<Local>();
		list.Add(dnlib.DotNet.Emit.OpCodes.Nop.ToInstruction());
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(9999));
		list.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_3));
		list.Add(dnlib.DotNet.Emit.OpCodes.Newobj.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetConstructor(new Type[0]))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_0));
		bool flag = ilist_1.ToArray<Parameter>().Count<Parameter>() != 0 && ilist_1[0] != null;
		if (flag)
		{
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(ilist_1[0].Type.ToTypeDefOrRef()));
			list.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
			{
				typeof(RuntimeTypeHandle)
			}))));
			list.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetMethod("Add", new Type[]
			{
				typeof(Type)
			}))));
		}
		bool flag2 = ilist_0 != null;
		if (flag2)
		{
			foreach (TypeSig sig in ilist_0)
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(sig.ToTypeDefOrRef()));
				list.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
				{
					typeof(RuntimeTypeHandle)
				}))));
				list.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetMethod("Add", new Type[]
				{
					typeof(Type)
				}))));
			}
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction("Night"));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(itypeDefOrRef_0));
		list.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
		{
			typeof(RuntimeTypeHandle)
		}))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
		list.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(List<Type>).GetMethod("ToArray", new Type[0]))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(typeDef_1));
		list.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
		{
			typeof(RuntimeTypeHandle)
		}))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("get_Module"))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_1.ToInstruction());
		list.Add(dnlib.DotNet.Emit.OpCodes.Newobj.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(DynamicMethod).GetConstructor(new Type[]
		{
			typeof(string),
			typeof(Type),
			typeof(Type[]),
			typeof(Module),
			typeof(bool)
		}))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_1));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_1));
		list.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Callvirt, assemblyDef_0.ManifestModule.Import(typeof(DynamicMethod).GetMethod("GetILGenerator", new Type[0]))));
		list.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(local_2));
		if (bool_0)
		{
			Class16.smethod_7(new Local(assemblyDef_0.ManifestModule.Import(typeDef_0).ToTypeSig()), local_2, ref list, assemblyDef_0, ref list2);
		}
		bool flag3 = local_4.Count<Local>() != 0;
		if (flag3)
		{
			for (int i = 0; i < local_4.Length; i++)
			{
				Class16.smethod_7(local_4[i], local_2, ref list, assemblyDef_0, ref list2);
			}
		}
		List<Instruction> list3 = new List<Instruction>();
		foreach (Instruction instruction in instruction_1)
		{
			bool flag4 = instruction.OpCode.OperandType == dnlib.DotNet.Emit.OperandType.InlineBrTarget || instruction.OpCode.OperandType == dnlib.DotNet.Emit.OperandType.ShortInlineBrTarget;
			if (flag4)
			{
				list3.Add(instruction);
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_3));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction((int)((Instruction)instruction.Operand).Offset));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_2));
				list.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("DefineLabel", new Type[0]))));
				list.Add(dnlib.DotNet.Emit.OpCodes.Stelem.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
			}
		}
		Class16.int_0 = 0;
		foreach (Instruction instruction2 in instruction_1)
		{
			bool flag5 = instruction2.Operand != null;
			if (flag5)
			{
				Class16.smethod_5(instruction2, local_2, ref list, list2, list3, assemblyDef_0);
			}
			else
			{
				Class16.smethod_6(instruction2, local_2, ref list, assemblyDef_0);
			}
		}
		list.UpdateInstructionOffsets();
		List<Instruction> list4 = new List<Instruction>();
		List<Instruction> list5 = new List<Instruction>();
		List<int> list6 = new List<int>();
		List<int> list7 = new List<int>();
		foreach (Instruction instruction3 in list)
		{
			bool flag6 = instruction3.OpCode == dnlib.DotNet.Emit.OpCodes.Ldsfld;
			if (flag6)
			{
				list4.Add(instruction3);
			}
		}
		foreach (Instruction instruction4 in instruction_1)
		{
			bool flag7 = instruction4.OpCode.OperandType == dnlib.DotNet.Emit.OperandType.InlineBrTarget || instruction4.OpCode.OperandType == dnlib.DotNet.Emit.OperandType.ShortInlineBrTarget;
			if (flag7)
			{
				list5.Add(instruction4);
				Instruction instruction5 = (Instruction)instruction4.Operand;
				int num = 0;
				for (int j = 0; j < instruction_1.Count<Instruction>(); j++)
				{
					bool flag8 = instruction_1[j].OpCode == instruction5.OpCode;
					if (flag8)
					{
						num++;
						bool flag9 = instruction_1[j] == instruction5;
						if (flag9)
						{
							list6.Add(num);
							instruction5 = instruction4;
							int num2 = 0;
							for (int k = 0; k < instruction_1.Count<Instruction>(); k++)
							{
								bool flag10 = instruction_1[k].OpCode == instruction5.OpCode;
								if (flag10)
								{
									num2++;
									bool flag11 = instruction_1[k] == instruction5;
									if (flag11)
									{
										list7.Add(num2);
										break;
									}
								}
							}
							break;
						}
					}
				}
			}
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		string a = "";
		int num6 = 0;
		for (int l = 0; l < list5.Count; l++)
		{
			for (int m = 0; m < list.Count; m++)
			{
				bool flag12 = list[m].OpCode == dnlib.DotNet.Emit.OpCodes.Ldsfld;
				if (flag12)
				{
					bool flag13 = num4 != 0;
					if (flag13)
					{
						num4--;
					}
					else
					{
						string text = ((Instruction)list5[l].Operand).ToString().Substring(9).ToLower();
						string b = list[m].ToString().Replace("System.Reflection.Emit.OpCode System.Reflection.Emit.OpCodes::", "").ToLower().Replace("_", ".").Substring(16);
						bool flag14 = text == b;
						if (flag14)
						{
							bool flag15 = a != text;
							if (flag15)
							{
								num6 = 0;
							}
							num6++;
							a = text;
							bool flag16 = num6 == list6[num3];
							if (flag16)
							{
								num6 = 0;
								num5++;
								num4 = num5;
								num3++;
								int num7 = m;
								list.Insert(num7 - 1, dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_2));
								list.Insert(num7, dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_3));
								list.Insert(num7 + 1, dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction((int)((Instruction)list5[l].Operand).Offset));
								list.Insert(num7 + 2, dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
								list.Insert(num7 + 3, dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("MarkLabel", new Type[]
								{
									typeof(Label)
								}))));
								m += 3;
							}
						}
						else
						{
							num4 = num5;
						}
					}
				}
			}
		}
		num3 = 0;
		num4 = 0;
		num5 = 0;
		a = "";
		num6 = 0;
		for (int n = 0; n < list5.Count; n++)
		{
			for (int num8 = 0; num8 < list.Count; num8++)
			{
				bool flag17 = list[num8].OpCode == dnlib.DotNet.Emit.OpCodes.Ldsfld;
				if (flag17)
				{
					bool flag18 = num4 != 0;
					if (flag18)
					{
						num4--;
					}
					else
					{
						string text2 = list5[n].OpCode.ToString().ToLower();
						string b2 = list[num8].ToString().Replace("System.Reflection.Emit.OpCode System.Reflection.Emit.OpCodes::", "").ToLower().Replace("_", ".").Substring(16);
						bool flag19 = text2 == b2;
						if (flag19)
						{
							bool flag20 = a != text2;
							if (flag20)
							{
								num6 = 0;
							}
							num6++;
							a = text2;
							bool flag21 = num6 == list7[num3];
							if (flag21)
							{
								num6 = 0;
								num5++;
								num4 = num5;
								num3++;
								int num9 = num8;
								list.Insert(num9 + 1, dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_3));
								list.Insert(num9 + 2, dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction((int)((Instruction)list5[n].Operand).Offset));
								list.Insert(num9 + 3, dnlib.DotNet.Emit.OpCodes.Ldelem.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Label))));
								list.Insert(num9 + 4, dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(dnlib.DotNet.Emit.OpCode),
									typeof(Label)
								}))));
								num8 += 3;
							}
						}
						else
						{
							num4 = num5;
						}
					}
				}
			}
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_1));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
		bool flag22 = ilist_0 != null;
		if (flag22)
		{
			list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(ilist_0.Count + 1));
		}
		else
		{
			bool flag23 = ilist_1.ToArray<Parameter>().Count<Parameter>() != 0;
			if (flag23)
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(ilist_1.ToArray<Parameter>().Count<Parameter>()));
			}
			else
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(0));
			}
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(object))));
		bool flag24 = ilist_0 != null;
		if (flag24)
		{
			int num10 = 0;
			list.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
			foreach (Parameter parameter in ilist_1)
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num10));
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldarg_S.ToInstruction(parameter));
				list.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
				list.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
				num10++;
			}
			list.RemoveAt(list.Count - 1);
		}
		else
		{
			bool flag25 = ilist_1.ToArray<Parameter>().Count<Parameter>() != 0;
			if (flag25)
			{
				int num11 = 0;
				list.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
				foreach (Parameter parameter2 in ilist_1)
				{
					list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num11));
					list.Add(dnlib.DotNet.Emit.OpCodes.Ldarg_S.ToInstruction(parameter2));
					list.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
					list.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
					num11++;
				}
				list.RemoveAt(list.Count - 1);
			}
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(MethodBase).GetMethod("Invoke", new Type[]
		{
			typeof(object),
			typeof(object[])
		}))));
		bool flag26 = typeSig_0.TypeName != "Void";
		if (flag26)
		{
			list.Add(dnlib.DotNet.Emit.OpCodes.Unbox_Any.ToInstruction(typeSig_0.ToTypeDefOrRef()));
		}
		else
		{
			list.Add(dnlib.DotNet.Emit.OpCodes.Pop.ToInstruction());
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Ret.ToInstruction());
		list_0 = list2;
		return list.ToArray();
	}

	// Token: 0x06000006 RID: 6 RVA: 0x00004200 File Offset: 0x00002400
	public static void smethod_5(Instruction instruction_0, Local local_0, ref List<Instruction> list_0, List<Local> list_1, List<Instruction> list_2, AssemblyDef assemblyDef_0)
	{
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
		char[] array = Class19.smethod_0(instruction_0.OpCode).Name.ToCharArray();
		array[0] = Convert.ToChar(array[0].ToString().Replace(array[0].ToString(), array[0].ToString().ToUpper()));
		string text = new string(array);
		bool flag = text.Contains(".");
		if (flag)
		{
			string text2 = text.Substring(text.IndexOf('.')).ToUpper();
			text = text.Replace(text2.ToLower(), text2);
		}
		FieldInfo field = typeof(System.Reflection.Emit.OpCodes).GetField(text.Replace(".", "_"), BindingFlags.Static | BindingFlags.Public);
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldsfld.ToInstruction(assemblyDef_0.ManifestModule.Import(field)));
		object operand = instruction_0.Operand;
		bool flag2 = !(operand is ConstructorInfo);
		if (flag2)
		{
			bool flag3 = operand is MethodDef;
			if (flag3)
			{
				bool flag4 = operand.ToString().Contains(".ctor");
				if (flag4)
				{
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
					{
						typeof(RuntimeTypeHandle)
					}))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(0));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[]
					{
						typeof(Type[])
					}))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
					{
						typeof(dnlib.DotNet.Emit.OpCode),
						typeof(ConstructorInfo)
					}))));
					return;
				}
				bool flag5 = instruction_0.OpCode == dnlib.DotNet.Emit.OpCodes.Ldftn;
				if (flag5)
				{
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
					{
						typeof(RuntimeTypeHandle)
					}))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((MethodDef)operand).Name));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
					int num = 0;
					int num2 = 0;
					foreach (TypeSig sig in ((MethodBaseSig)((MethodDef)operand).Signature).Params)
					{
						bool flag6 = num == 0;
						if (flag6)
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MethodDef)operand).Signature).Params.Count));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
							num++;
						}
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num2));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(sig.ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
						{
							typeof(RuntimeTypeHandle)
						}))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
						num2++;
					}
					list_0.RemoveAt(list_0.Count - 1);
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
					{
						typeof(string),
						typeof(BindingFlags),
						typeof(Binder),
						typeof(Type[]),
						typeof(ParameterModifier[])
					}))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
					{
						typeof(dnlib.DotNet.Emit.OpCode),
						typeof(MethodInfo)
					}))));
					return;
				}
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MethodDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
				{
					typeof(RuntimeTypeHandle)
				}))));
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((MethodDef)operand).Name));
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
				int num3 = 0;
				int num4 = 0;
				bool flag7 = ((MethodBaseSig)((MethodDef)operand).Signature).Params.Count >= 1;
				if (flag7)
				{
					foreach (TypeSig sig2 in ((MethodBaseSig)((MethodDef)operand).Signature).Params)
					{
						bool flag8 = num3 == 0;
						if (flag8)
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MethodDef)operand).Signature).Params.Count));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
							num3++;
						}
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num4));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(sig2.ToTypeDefOrRef()));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
						{
							typeof(RuntimeTypeHandle)
						}))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
						num4++;
					}
					list_0.RemoveAt(list_0.Count - 1);
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
					{
						typeof(string),
						typeof(BindingFlags),
						typeof(Binder),
						typeof(Type[]),
						typeof(ParameterModifier[])
					}))));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
					{
						typeof(dnlib.DotNet.Emit.OpCode),
						typeof(MethodInfo)
					}))));
					return;
				}
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_0.ToInstruction());
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
				{
					typeof(string),
					typeof(BindingFlags),
					typeof(Binder),
					typeof(Type[]),
					typeof(ParameterModifier[])
				}))));
				list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
				{
					typeof(dnlib.DotNet.Emit.OpCode),
					typeof(MethodInfo)
				}))));
				return;
			}
			else
			{
				bool flag9 = operand is string;
				if (flag9)
				{
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(operand.ToString()));
					list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
					{
						typeof(dnlib.DotNet.Emit.OpCode),
						typeof(string)
					}))));
					return;
				}
				bool flag10 = operand is TypeDef;
				if (flag10)
				{
					return;
				}
				bool flag11 = !(operand is ConstructorInfo);
				if (flag11)
				{
					bool flag12 = operand is int;
					if (flag12)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(int.Parse(operand.ToString())));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(dnlib.DotNet.Emit.OpCode),
							typeof(int)
						}))));
						return;
					}
					bool flag13 = instruction_0.OpCode == dnlib.DotNet.Emit.OpCodes.Ldc_I4_S;
					if (flag13)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_S.ToInstruction(sbyte.Parse(operand.ToString())));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(sbyte)
						}))));
						return;
					}
					bool flag14 = operand is double;
					if (flag14)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_R8.ToInstruction(double.Parse(operand.ToString().Replace(".", ","))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(System.Reflection.Emit.OpCode),
							typeof(double)
						}))));
						return;
					}
					bool flag15 = operand is float;
					if (flag15)
					{
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_R4.ToInstruction(float.Parse(operand.ToString().Replace(".", ","))));
						list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
						{
							typeof(dnlib.DotNet.Emit.OpCode),
							typeof(float)
						}))));
						return;
					}
					bool flag16 = operand is MemberRef;
					if (flag16)
					{
						bool flag17 = instruction_0.OpCode == dnlib.DotNet.Emit.OpCodes.Ldftn;
						if (flag17)
						{
							return;
						}
						bool flag18 = operand.ToString().Contains(".ctor");
						if (flag18)
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MemberRef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							int num5 = 0;
							int num6 = 0;
							bool flag19 = ((MethodBaseSig)((MemberRef)operand).Signature).Params.Count >= 1;
							if (flag19)
							{
								foreach (TypeSig sig3 in ((MethodBaseSig)((MemberRef)operand).Signature).Params)
								{
									bool flag20 = num5 == 0;
									if (flag20)
									{
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MemberRef)operand).Signature).Params.Count));
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
										num5++;
									}
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num6));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(sig3.ToTypeDefOrRef()));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
									{
										typeof(RuntimeTypeHandle)
									}))));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
									num6++;
								}
								list_0.RemoveAt(list_0.Count - 1);
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[]
								{
									typeof(Type[])
								}))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(dnlib.DotNet.Emit.OpCode),
									typeof(ConstructorInfo)
								}))));
								return;
							}
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(0));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetConstructor", new Type[]
							{
								typeof(Type[])
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(dnlib.DotNet.Emit.OpCode),
								typeof(ConstructorInfo)
							}))));
							return;
						}
						else
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((MemberRef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((MemberRef)operand).Name));
							int num7 = 0;
							int num8 = 0;
							bool flag21 = ((MethodBaseSig)((MemberRef)operand).Signature).Params.Count >= 1;
							if (flag21)
							{
								foreach (TypeSig sig4 in ((MethodBaseSig)((MemberRef)operand).Signature).Params)
								{
									bool flag22 = num7 == 0;
									if (flag22)
									{
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(((MethodBaseSig)((MemberRef)operand).Signature).Params.Count));
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
										list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
										num7++;
									}
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num8));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(sig4.ToTypeDefOrRef()));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
									{
										typeof(RuntimeTypeHandle)
									}))));
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Stelem_Ref.ToInstruction());
									list_0.Add(dnlib.DotNet.Emit.OpCodes.Dup.ToInstruction());
									num8++;
								}
								list_0.RemoveAt(list_0.Count - 1);
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
								{
									typeof(string),
									typeof(Type[])
								}))));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(dnlib.DotNet.Emit.OpCode),
									typeof(MethodInfo)
								}))));
								return;
							}
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4_0.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Newarr.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldnull.ToInstruction());
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetMethod", new Type[]
							{
								typeof(string),
								typeof(BindingFlags),
								typeof(Binder),
								typeof(Type[]),
								typeof(ParameterModifier[])
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(dnlib.DotNet.Emit.OpCode),
								typeof(MethodInfo)
							}))));
							return;
						}
					}
					else
					{
						bool flag23 = operand is FieldDef;
						if (flag23)
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((FieldDef)operand).DeclaringType.ToTypeSig().ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldstr.ToInstruction(((FieldDef)operand).Name));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(17301375));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetField", new Type[]
							{
								typeof(string),
								typeof(BindingFlags)
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(dnlib.DotNet.Emit.OpCode),
								typeof(FieldInfo)
							}))));
							return;
						}
						bool flag24 = operand is TypeRef;
						if (flag24)
						{
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(((TypeRef)operand).ToTypeSig().ToTypeDefOrRef()));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
							{
								typeof(RuntimeTypeHandle)
							}))));
							list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
							{
								typeof(dnlib.DotNet.Emit.OpCode),
								typeof(Type)
							}))));
							return;
						}
						bool flag25 = operand is Local;
						if (flag25)
						{
							try
							{
								Local local;
								list_1.ToDictionary(new Func<Local, Local>(Class16.Class17.method_2), new Func<Local, Local>(Class16.Class17.method_3)).TryGetValue(list_1[int.Parse(((Local)operand).ToString().Replace("V_", ""))], out local);
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local));
								list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
								{
									typeof(dnlib.DotNet.Emit.OpCode),
									typeof(LocalBuilder)
								}))));
								return;
							}
							catch (Exception ex)
							{
								Console.WriteLine(string.Format("{0}::{1} msg: {2}", instruction_0.OpCode, operand, ex.Message));
								goto IL_1810;
							}
						}
						bool flag26 = instruction_0.OpCode.OperandType > dnlib.DotNet.Emit.OperandType.InlineBrTarget;
						if (flag26)
						{
							bool flag27 = instruction_0.OpCode.OperandType != dnlib.DotNet.Emit.OperandType.ShortInlineBrTarget;
							if (flag27)
							{
								bool flag28 = instruction_0.OpCode == dnlib.DotNet.Emit.OpCodes.Nop;
								if (!flag28)
								{
									goto IL_1810;
								}
							}
						}
						return;
					}
				}
			}
		}
		IL_1810:
		list_0.RemoveAt(list_0.Count - 1);
		list_0.RemoveAt(list_0.Count - 1);
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00005ABC File Offset: 0x00003CBC
	public static void smethod_6(Instruction instruction_0, Local local_0, ref List<Instruction> list_0, AssemblyDef assemblyDef_0)
	{
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_0));
		char[] array = Class19.smethod_0(instruction_0.OpCode).Name.ToCharArray();
		array[0] = Convert.ToChar(array[0].ToString().Replace(array[0].ToString(), array[0].ToString().ToUpper()));
		string text = new string(array);
		bool flag = text.Contains(".");
		if (flag)
		{
			string text2 = text.Substring(text.IndexOf('.')).ToUpper();
			text = text.Replace(text2.ToLower(), text2);
		}
		FieldInfo field = typeof(dnlib.DotNet.Emit.OpCodes).GetField(text.Replace(".", "_"), BindingFlags.Static | BindingFlags.Public);
		bool flag2 = field == null;
		if (flag2)
		{
			Console.WriteLine(text);
		}
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldsfld.ToInstruction(assemblyDef_0.ManifestModule.Import(field)));
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("Emit", new Type[]
		{
			typeof(dnlib.DotNet.Emit.OpCode)
		}))));
	}

	// Token: 0x06000008 RID: 8 RVA: 0x00005C00 File Offset: 0x00003E00
	public static void smethod_7(Local local_0, Local local_1, ref List<Instruction> list_0, AssemblyDef assemblyDef_0, ref List<Local> list_1)
	{
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldloc_S.ToInstruction(local_1));
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Ldtoken.ToInstruction(local_0.Type.ToTypeDefOrRef()));
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Call.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(Type).GetMethod("GetTypeFromHandle", new Type[]
		{
			typeof(RuntimeTypeHandle)
		}))));
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Callvirt.ToInstruction(assemblyDef_0.ManifestModule.Import(typeof(ILGenerator).GetMethod("DeclareLocal", new Type[]
		{
			typeof(Type)
		}))));
		list_1.Add(new Local(assemblyDef_0.ManifestModule.Import(typeof(LocalBuilder)).ToTypeSig()));
		list_0.Add(dnlib.DotNet.Emit.OpCodes.Stloc_S.ToInstruction(list_1[list_1.Count - 1]));
	}

	// Token: 0x04000001 RID: 1
	private static Dictionary<int, int> dictionary_0 = new Dictionary<int, int>();

	// Token: 0x04000002 RID: 2
	private static int int_0 = 0;

	// Token: 0x02000066 RID: 102
	[CompilerGenerated]
	[Serializable]
	private static class Class17
	{
		// Token: 0x0600020A RID: 522 RVA: 0x00029548 File Offset: 0x00027748
		internal static IEnumerable<MethodDef> method_0(TypeDef typeDef_0)
		{
			return typeDef_0.Methods;
		}

		// Token: 0x0600020B RID: 523 RVA: 0x00029560 File Offset: 0x00027760
		internal static IEnumerable<Instruction> method_1(List<Instruction> list_0)
		{
			return list_0;
		}

		// Token: 0x0600020C RID: 524 RVA: 0x00029574 File Offset: 0x00027774
		internal static Local method_2(Local local_0)
		{
			return local_0;
		}

		// Token: 0x0600020D RID: 525 RVA: 0x00029588 File Offset: 0x00027788
		internal static Local method_3(Local local_0)
		{
			return local_0;
		}
	}

	// Token: 0x02000067 RID: 103
	private sealed class Class18
	{
		// Token: 0x0600020E RID: 526 RVA: 0x0002959C File Offset: 0x0002779C
		internal int method_0(List<Instruction> list_1)
		{
			bool flag = this.list_0.IndexOf(list_1) != 0;
			int result;
			if (flag)
			{
				result = this.random_0.Next(0, 2);
			}
			else
			{
				result = 2;
			}
			return result;
		}

		// Token: 0x04000121 RID: 289
		public List<List<Instruction>> list_0;

		// Token: 0x04000122 RID: 290
		public Random random_0;

		// Token: 0x04000123 RID: 291
		public Func<List<Instruction>, int> func_0;
	}
}
