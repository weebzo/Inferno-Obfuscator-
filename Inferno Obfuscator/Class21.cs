using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x02000005 RID: 5
internal class Class21
{
	// Token: 0x06000013 RID: 19 RVA: 0x00005FD8 File Offset: 0x000041D8
	private static TypeDefUser smethod_0(TypeDef typeDef_0)
	{
		TypeDefUser typeDefUser = new TypeDefUser(typeDef_0.Namespace, typeDef_0.Name);
		typeDefUser.Attributes = typeDef_0.Attributes;
		bool flag = typeDef_0.ClassLayout != null;
		if (flag)
		{
			typeDefUser.ClassLayout = new ClassLayoutUser(typeDef_0.ClassLayout.PackingSize, typeDef_0.ClassSize);
		}
		foreach (GenericParam genericParam in typeDef_0.GenericParameters)
		{
			typeDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
		}
		return typeDefUser;
	}

	// Token: 0x06000014 RID: 20 RVA: 0x0000609C File Offset: 0x0000429C
	private static MethodDefUser smethod_1(MethodDef methodDef_0)
	{
		MethodDefUser methodDefUser = new MethodDefUser(methodDef_0.Name, null, methodDef_0.ImplAttributes, methodDef_0.Attributes);
		foreach (GenericParam genericParam in methodDef_0.GenericParameters)
		{
			methodDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
		}
		return methodDefUser;
	}

	// Token: 0x06000015 RID: 21 RVA: 0x0000612C File Offset: 0x0000432C
	private static FieldDefUser smethod_2(FieldDef fieldDef_0)
	{
		return new FieldDefUser(fieldDef_0.Name, null, fieldDef_0.Attributes);
	}

	// Token: 0x06000016 RID: 22 RVA: 0x00006150 File Offset: 0x00004350
	private static TypeDef smethod_3(TypeDef typeDef_0, Class21.Class22 class22_0)
	{
		IDnlibDef dnlibDef;
		bool flag = !class22_0.dictionary_0.TryGetValue(typeDef_0, out dnlibDef);
		TypeDef typeDef;
		if (flag)
		{
			typeDef = Class21.smethod_0(typeDef_0);
			class22_0.dictionary_0[typeDef_0] = typeDef;
		}
		else
		{
			typeDef = (TypeDef)dnlibDef;
		}
		foreach (TypeDef typeDef_ in typeDef_0.NestedTypes)
		{
			typeDef.NestedTypes.Add(Class21.smethod_3(typeDef_, class22_0));
		}
		foreach (MethodDef methodDef in typeDef_0.Methods)
		{
			typeDef.Methods.Add((MethodDef)(class22_0.dictionary_0[methodDef] = Class21.smethod_1(methodDef)));
		}
		foreach (FieldDef fieldDef in typeDef_0.Fields)
		{
			typeDef.Fields.Add((FieldDef)(class22_0.dictionary_0[fieldDef] = Class21.smethod_2(fieldDef)));
		}
		return typeDef;
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000062C4 File Offset: 0x000044C4
	private static void smethod_4(TypeDef typeDef_0, Class21.Class22 class22_0)
	{
		TypeDef typeDef = (TypeDef)class22_0.dictionary_0[typeDef_0];
		typeDef.BaseType = (ITypeDefOrRef)class22_0.Importer_0.Import(typeDef_0.BaseType);
		foreach (InterfaceImpl interfaceImpl in typeDef_0.Interfaces)
		{
			typeDef.Interfaces.Add(new InterfaceImplUser((ITypeDefOrRef)class22_0.Importer_0.Import(interfaceImpl.Interface)));
		}
	}

	// Token: 0x06000018 RID: 24 RVA: 0x0000636C File Offset: 0x0000456C
	private static void smethod_5(MethodDef methodDef_0, Class21.Class22 class22_0)
	{
		MethodDef methodDef = (MethodDef)class22_0.dictionary_0[methodDef_0];
		methodDef.Signature = class22_0.Importer_0.Import(methodDef_0.Signature);
		methodDef.Parameters.UpdateParameterTypes();
		bool flag = methodDef_0.ImplMap != null;
		if (flag)
		{
			methodDef.ImplMap = new ImplMapUser(new ModuleRefUser(class22_0.moduleDef_1, methodDef_0.ImplMap.Module.Name), methodDef_0.ImplMap.Name, methodDef_0.ImplMap.Attributes);
		}
		foreach (CustomAttribute customAttribute in methodDef_0.CustomAttributes)
		{
			methodDef.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)class22_0.Importer_0.Import(customAttribute.Constructor)));
		}
		bool hasBody = methodDef_0.HasBody;
		if (hasBody)
		{
			Class21.Class23 @class = new Class21.Class23();
			methodDef.Body = new CilBody(methodDef_0.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
			methodDef.Body.MaxStack = methodDef_0.Body.MaxStack;
			@class.dictionary_0 = new Dictionary<object, object>();
			foreach (Local local in methodDef_0.Body.Variables)
			{
				Local local2 = new Local(class22_0.Importer_0.Import(local.Type));
				methodDef.Body.Variables.Add(local2);
				local2.Name = local.Name;
				local2.PdbAttributes = local.PdbAttributes;
				@class.dictionary_0[local] = local2;
			}
			foreach (Instruction instruction in methodDef_0.Body.Instructions)
			{
				Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand);
				instruction2.SequencePoint = instruction.SequencePoint;
				bool flag2 = instruction2.Operand is IType;
				if (flag2)
				{
					instruction2.Operand = class22_0.Importer_0.Import((IType)instruction2.Operand);
				}
				else
				{
					bool flag3 = instruction2.Operand is IMethod;
					if (flag3)
					{
						instruction2.Operand = class22_0.Importer_0.Import((IMethod)instruction2.Operand);
					}
					else
					{
						bool flag4 = instruction2.Operand is IField;
						if (flag4)
						{
							instruction2.Operand = class22_0.Importer_0.Import((IField)instruction2.Operand);
						}
					}
				}
				methodDef.Body.Instructions.Add(instruction2);
				@class.dictionary_0[instruction] = instruction2;
			}
			foreach (Instruction instruction3 in methodDef.Body.Instructions)
			{
				bool flag5 = instruction3.Operand != null && @class.dictionary_0.ContainsKey(instruction3.Operand);
				if (flag5)
				{
					instruction3.Operand = @class.dictionary_0[instruction3.Operand];
				}
				else
				{
					bool flag6 = instruction3.Operand is Instruction[];
					if (flag6)
					{
						Instruction instruction4 = instruction3;
						IEnumerable<Instruction> source = (Instruction[])instruction3.Operand;
						Func<Instruction, Instruction> selector;
						bool flag7 = (selector = @class.func_0) == null;
						if (flag7)
						{
							selector = (@class.func_0 = new Func<Instruction, Instruction>(@class.method_0));
						}
						instruction4.Operand = source.Select(selector).ToArray<Instruction>();
					}
				}
			}
			foreach (ExceptionHandler exceptionHandler in methodDef_0.Body.ExceptionHandlers)
			{
				methodDef.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
				{
					CatchType = ((exceptionHandler.CatchType == null) ? null : ((ITypeDefOrRef)class22_0.Importer_0.Import(exceptionHandler.CatchType))),
					TryStart = (Instruction)@class.dictionary_0[exceptionHandler.TryStart],
					TryEnd = (Instruction)@class.dictionary_0[exceptionHandler.TryEnd],
					HandlerStart = (Instruction)@class.dictionary_0[exceptionHandler.HandlerStart],
					HandlerEnd = (Instruction)@class.dictionary_0[exceptionHandler.HandlerEnd],
					FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)@class.dictionary_0[exceptionHandler.FilterStart]))
				});
			}
			methodDef.Body.SimplifyMacros(methodDef.Parameters);
		}
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00006928 File Offset: 0x00004B28
	private static void smethod_6(FieldDef fieldDef_0, Class21.Class22 class22_0)
	{
		((FieldDef)class22_0.dictionary_0[fieldDef_0]).Signature = class22_0.Importer_0.Import(fieldDef_0.Signature);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x00006964 File Offset: 0x00004B64
	private static void smethod_7(TypeDef typeDef_0, Class21.Class22 class22_0, bool bool_0)
	{
		if (bool_0)
		{
			Class21.smethod_4(typeDef_0, class22_0);
		}
		foreach (TypeDef typeDef_ in typeDef_0.NestedTypes)
		{
			Class21.smethod_7(typeDef_, class22_0, true);
		}
		foreach (MethodDef methodDef_ in typeDef_0.Methods)
		{
			Class21.smethod_5(methodDef_, class22_0);
		}
		foreach (FieldDef fieldDef_ in typeDef_0.Fields)
		{
			Class21.smethod_6(fieldDef_, class22_0);
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x00006A54 File Offset: 0x00004C54
	public static TypeDef smethod_8(TypeDef typeDef_0, ModuleDef moduleDef_0)
	{
		Class21.Class22 @class = new Class21.Class22(typeDef_0.Module, moduleDef_0);
		Class21.smethod_3(typeDef_0, @class);
		Class21.smethod_7(typeDef_0, @class, true);
		return (TypeDef)@class.dictionary_0[typeDef_0];
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00006A98 File Offset: 0x00004C98
	public static MethodDef smethod_9(MethodDef methodDef_0, ModuleDef moduleDef_0)
	{
		Class21.Class22 @class = new Class21.Class22(methodDef_0.Module, moduleDef_0);
		@class.dictionary_0[methodDef_0] = Class21.smethod_1(methodDef_0);
		Class21.smethod_5(methodDef_0, @class);
		return (MethodDef)@class.dictionary_0[methodDef_0];
	}

	// Token: 0x0600001D RID: 29 RVA: 0x00006AE4 File Offset: 0x00004CE4
	public static IEnumerable<IDnlibDef> smethod_10(TypeDef typeDef_0, TypeDef typeDef_1, ModuleDef moduleDef_0)
	{
		Class21.Class22 @class = new Class21.Class22(typeDef_0.Module, moduleDef_0);
		@class.dictionary_0[typeDef_0] = typeDef_1;
		Class21.smethod_3(typeDef_0, @class);
		Class21.smethod_7(typeDef_0, @class, false);
		return @class.dictionary_0.Values.Except(new TypeDef[]
		{
			typeDef_1
		});
	}

	// Token: 0x02000068 RID: 104
	private class Class22 : ImportResolver
	{
		// Token: 0x06000210 RID: 528 RVA: 0x000295DC File Offset: 0x000277DC
		public Class22(ModuleDef moduleDef_2, ModuleDef moduleDef_3)
		{
			this.moduleDef_0 = moduleDef_2;
			this.moduleDef_1 = moduleDef_3;
			this.importer_0 = new Importer(moduleDef_3, ImporterOptions.TryToUseTypeDefs);
			this.importer_0.Resolver = this;
		}

		// Token: 0x1700000B RID: 11
		// (get) Token: 0x06000211 RID: 529 RVA: 0x0002961C File Offset: 0x0002781C
		public Importer Importer_0
		{
			get
			{
				return this.importer_0;
			}
		}

		// Token: 0x06000212 RID: 530 RVA: 0x00029634 File Offset: 0x00027834
		public override TypeDef Resolve(TypeDef typeDef)
		{
			bool flag = this.dictionary_0.ContainsKey(typeDef);
			TypeDef result;
			if (flag)
			{
				result = (TypeDef)this.dictionary_0[typeDef];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000213 RID: 531 RVA: 0x0002966C File Offset: 0x0002786C
		public override MethodDef Resolve(MethodDef methodDef)
		{
			bool flag = this.dictionary_0.ContainsKey(methodDef);
			MethodDef result;
			if (flag)
			{
				result = (MethodDef)this.dictionary_0[methodDef];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x06000214 RID: 532 RVA: 0x000296A4 File Offset: 0x000278A4
		public override FieldDef Resolve(FieldDef fieldDef)
		{
			bool flag = this.dictionary_0.ContainsKey(fieldDef);
			FieldDef result;
			if (flag)
			{
				result = (FieldDef)this.dictionary_0[fieldDef];
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04000124 RID: 292
		public readonly Dictionary<IDnlibDef, IDnlibDef> dictionary_0 = new Dictionary<IDnlibDef, IDnlibDef>();

		// Token: 0x04000125 RID: 293
		public readonly ModuleDef moduleDef_0;

		// Token: 0x04000126 RID: 294
		public readonly ModuleDef moduleDef_1;

		// Token: 0x04000127 RID: 295
		private readonly Importer importer_0;
	}

	// Token: 0x02000069 RID: 105
	private sealed class Class23
	{
		// Token: 0x06000215 RID: 533 RVA: 0x000296DC File Offset: 0x000278DC
		internal Instruction method_0(Instruction instruction_0)
		{
			return (Instruction)this.dictionary_0[instruction_0];
		}

		// Token: 0x04000128 RID: 296
		public Dictionary<object, object> dictionary_0;

		// Token: 0x04000129 RID: 297
		public Func<Instruction, Instruction> func_0;
	}
}
