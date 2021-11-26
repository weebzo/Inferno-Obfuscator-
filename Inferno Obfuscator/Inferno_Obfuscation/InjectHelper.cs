using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000035 RID: 53
	public static class InjectHelper
	{
		// Token: 0x06000112 RID: 274 RVA: 0x0001805C File Offset: 0x0001625C
		private static TypeDefUser Clone(TypeDef origin)
		{
			TypeDefUser ret = new TypeDefUser(origin.Namespace, origin.Name)
			{
				Attributes = origin.Attributes
			};
			bool flag = origin.ClassLayout != null;
			if (flag)
			{
				ret.ClassLayout = new ClassLayoutUser(origin.ClassLayout.PackingSize, origin.ClassSize);
			}
			foreach (GenericParam genericParam in origin.GenericParameters)
			{
				ret.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
			}
			return ret;
		}

		// Token: 0x06000113 RID: 275 RVA: 0x0001811C File Offset: 0x0001631C
		private static MethodDefUser Clone(MethodDef origin)
		{
			MethodDefUser ret = new MethodDefUser(origin.Name, null, origin.ImplAttributes, origin.Attributes);
			foreach (GenericParam genericParam in origin.GenericParameters)
			{
				ret.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
			}
			return ret;
		}

		// Token: 0x06000114 RID: 276 RVA: 0x000181AC File Offset: 0x000163AC
		private static FieldDefUser Clone(FieldDef origin)
		{
			return new FieldDefUser(origin.Name, null, origin.Attributes);
		}

		// Token: 0x06000115 RID: 277 RVA: 0x000181D4 File Offset: 0x000163D4
		private static TypeDef PopulateContext(TypeDef typeDef, InjectHelper.InjectContext ctx)
		{
			IDnlibDef existing;
			bool flag = !ctx.map.TryGetValue(typeDef, out existing);
			TypeDef ret;
			if (flag)
			{
				ret = InjectHelper.Clone(typeDef);
				ctx.map[typeDef] = ret;
			}
			else
			{
				ret = (TypeDef)existing;
			}
			foreach (TypeDef nestedType in typeDef.NestedTypes)
			{
				ret.NestedTypes.Add(InjectHelper.PopulateContext(nestedType, ctx));
			}
			foreach (MethodDef method in typeDef.Methods)
			{
				ret.Methods.Add((MethodDef)(ctx.map[method] = InjectHelper.Clone(method)));
			}
			foreach (FieldDef field in typeDef.Fields)
			{
				ret.Fields.Add((FieldDef)(ctx.map[field] = InjectHelper.Clone(field)));
			}
			return ret;
		}

		// Token: 0x06000116 RID: 278 RVA: 0x00018340 File Offset: 0x00016540
		private static void CopyTypeDef(TypeDef typeDef, InjectHelper.InjectContext ctx)
		{
			TypeDef newTypeDef = (TypeDef)ctx.map[typeDef];
			newTypeDef.BaseType = (ITypeDefOrRef)ctx.Importer.Import(typeDef.BaseType);
			foreach (InterfaceImpl iface in typeDef.Interfaces)
			{
				newTypeDef.Interfaces.Add(new InterfaceImplUser((ITypeDefOrRef)ctx.Importer.Import(iface.Interface)));
			}
		}

		// Token: 0x06000117 RID: 279 RVA: 0x000183E8 File Offset: 0x000165E8
		private static void CopyMethodDef(MethodDef methodDef, InjectHelper.InjectContext ctx)
		{
			MethodDef newMethodDef = (MethodDef)ctx.map[methodDef];
			newMethodDef.Signature = ctx.Importer.Import(methodDef.Signature);
			newMethodDef.Parameters.UpdateParameterTypes();
			bool flag = methodDef.ImplMap != null;
			if (flag)
			{
				newMethodDef.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.TargetModule, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
			}
			foreach (CustomAttribute ca in methodDef.CustomAttributes)
			{
				newMethodDef.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.Importer.Import(ca.Constructor)));
			}
			bool flag2 = !methodDef.HasBody;
			if (!flag2)
			{
				newMethodDef.Body = new CilBody(methodDef.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>())
				{
					MaxStack = methodDef.Body.MaxStack
				};
				Dictionary<object, object> bodyMap = new Dictionary<object, object>();
				foreach (Local local in methodDef.Body.Variables)
				{
					Local newLocal = new Local(ctx.Importer.Import(local.Type));
					newMethodDef.Body.Variables.Add(newLocal);
					newLocal.Name = local.Name;
					newLocal.PdbAttributes = local.PdbAttributes;
					bodyMap[local] = newLocal;
				}
				foreach (Instruction instr in methodDef.Body.Instructions)
				{
					Instruction newInstr = new Instruction(instr.OpCode, instr.Operand)
					{
						SequencePoint = instr.SequencePoint
					};
					object operand = newInstr.Operand;
					object obj = operand;
					IType type = obj as IType;
					if (type == null)
					{
						IMethod method = obj as IMethod;
						if (method == null)
						{
							IField field = obj as IField;
							if (field != null)
							{
								newInstr.Operand = ctx.Importer.Import(field);
							}
						}
						else
						{
							newInstr.Operand = ctx.Importer.Import(method);
						}
					}
					else
					{
						newInstr.Operand = ctx.Importer.Import(type);
					}
					newMethodDef.Body.Instructions.Add(newInstr);
					bodyMap[instr] = newInstr;
				}
				Func<Instruction, Instruction> <>9__0;
				foreach (Instruction instr2 in newMethodDef.Body.Instructions)
				{
					bool flag3 = instr2.Operand != null && bodyMap.ContainsKey(instr2.Operand);
					if (flag3)
					{
						instr2.Operand = bodyMap[instr2.Operand];
					}
					else
					{
						Instruction[] v = instr2.Operand as Instruction[];
						bool flag4 = v != null;
						if (flag4)
						{
							Instruction instruction = instr2;
							IEnumerable<Instruction> source = v;
							Func<Instruction, Instruction> selector;
							if ((selector = <>9__0) == null)
							{
								selector = (<>9__0 = ((Instruction target) => (Instruction)bodyMap[target]));
							}
							instruction.Operand = source.Select(selector).ToArray<Instruction>();
						}
					}
				}
				foreach (ExceptionHandler eh in methodDef.Body.ExceptionHandlers)
				{
					newMethodDef.Body.ExceptionHandlers.Add(new ExceptionHandler(eh.HandlerType)
					{
						CatchType = (ITypeDefOrRef)((eh.CatchType == null) ? null : ctx.Importer.Import(eh.CatchType)),
						TryStart = (Instruction)bodyMap[eh.TryStart],
						TryEnd = (Instruction)bodyMap[eh.TryEnd],
						HandlerStart = (Instruction)bodyMap[eh.HandlerStart],
						HandlerEnd = (Instruction)bodyMap[eh.HandlerEnd],
						FilterStart = ((eh.FilterStart == null) ? null : ((Instruction)bodyMap[eh.FilterStart]))
					});
				}
				newMethodDef.Body.SimplifyMacros(newMethodDef.Parameters);
			}
		}

		// Token: 0x06000118 RID: 280 RVA: 0x0001894C File Offset: 0x00016B4C
		private static void CopyFieldDef(FieldDef fieldDef, InjectHelper.InjectContext ctx)
		{
			FieldDef newFieldDef = (FieldDef)ctx.map[fieldDef];
			newFieldDef.Signature = ctx.Importer.Import(fieldDef.Signature);
		}

		// Token: 0x06000119 RID: 281 RVA: 0x00018988 File Offset: 0x00016B88
		private static void Copy(TypeDef typeDef, InjectHelper.InjectContext ctx, bool copySelf)
		{
			if (copySelf)
			{
				InjectHelper.CopyTypeDef(typeDef, ctx);
			}
			foreach (TypeDef nestedType in typeDef.NestedTypes)
			{
				InjectHelper.Copy(nestedType, ctx, true);
			}
			foreach (MethodDef method in typeDef.Methods)
			{
				InjectHelper.CopyMethodDef(method, ctx);
			}
			foreach (FieldDef field in typeDef.Fields)
			{
				InjectHelper.CopyFieldDef(field, ctx);
			}
		}

		// Token: 0x0600011A RID: 282 RVA: 0x00018A70 File Offset: 0x00016C70
		public static TypeDef Inject(TypeDef typeDef, ModuleDef target)
		{
			InjectHelper.InjectContext ctx = new InjectHelper.InjectContext(typeDef.Module, target);
			InjectHelper.PopulateContext(typeDef, ctx);
			InjectHelper.Copy(typeDef, ctx, true);
			return (TypeDef)ctx.map[typeDef];
		}

		// Token: 0x0600011B RID: 283 RVA: 0x00018AB4 File Offset: 0x00016CB4
		public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
		{
			InjectHelper.InjectContext ctx = new InjectHelper.InjectContext(methodDef.Module, target);
			ctx.map[methodDef] = InjectHelper.Clone(methodDef);
			InjectHelper.CopyMethodDef(methodDef, ctx);
			return (MethodDef)ctx.map[methodDef];
		}

		// Token: 0x0600011C RID: 284 RVA: 0x00018B00 File Offset: 0x00016D00
		public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
		{
			InjectHelper.InjectContext ctx = new InjectHelper.InjectContext(typeDef.Module, target);
			ctx.map[typeDef] = newType;
			InjectHelper.PopulateContext(typeDef, ctx);
			InjectHelper.Copy(typeDef, ctx, false);
			return ctx.map.Values.Except(new TypeDef[]
			{
				newType
			});
		}

		// Token: 0x02000088 RID: 136
		private class InjectContext : ImportMapper
		{
			// Token: 0x0600026C RID: 620 RVA: 0x0002AA84 File Offset: 0x00028C84
			public InjectContext(ModuleDef module, ModuleDef target)
			{
				this.OriginModule = module;
				this.TargetModule = target;
				this.importer = new Importer(target, ImporterOptions.TryToUseTypeDefs, default(GenericParamContext));
			}

			// Token: 0x1700000C RID: 12
			// (get) Token: 0x0600026D RID: 621 RVA: 0x0002AAC8 File Offset: 0x00028CC8
			public Importer Importer
			{
				get
				{
					return this.importer;
				}
			}

			// Token: 0x04000144 RID: 324
			public readonly Dictionary<IDnlibDef, IDnlibDef> map = new Dictionary<IDnlibDef, IDnlibDef>();

			// Token: 0x04000145 RID: 325
			public readonly ModuleDef OriginModule;

			// Token: 0x04000146 RID: 326
			public readonly ModuleDef TargetModule;

			// Token: 0x04000147 RID: 327
			public readonly Importer importer;
		}
	}
}
