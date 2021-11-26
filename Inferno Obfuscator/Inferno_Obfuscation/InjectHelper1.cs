using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000037 RID: 55
	internal class InjectHelper1
	{
		// Token: 0x0200008A RID: 138
		public static class InjectHelper
		{
			// Token: 0x06000270 RID: 624 RVA: 0x0002AAEC File Offset: 0x00028CEC
			private static TypeDefUser Clone(TypeDef origin)
			{
				TypeDefUser typeDefUser = new TypeDefUser(origin.Namespace, origin.Name);
				typeDefUser.Attributes = origin.Attributes;
				bool flag = origin.ClassLayout != null;
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					typeDefUser.ClassLayout = new ClassLayoutUser(origin.ClassLayout.PackingSize, origin.ClassSize);
				}
				foreach (GenericParam genericParam in origin.GenericParameters)
				{
					typeDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
				}
				return typeDefUser;
			}

			// Token: 0x06000271 RID: 625 RVA: 0x0002ABBC File Offset: 0x00028DBC
			private static MethodDefUser Clone(MethodDef origin)
			{
				MethodDefUser methodDefUser = new MethodDefUser(origin.Name, null, origin.ImplAttributes, origin.Attributes);
				foreach (GenericParam genericParam in origin.GenericParameters)
				{
					methodDefUser.GenericParameters.Add(new GenericParamUser(genericParam.Number, genericParam.Flags, "-"));
				}
				return methodDefUser;
			}

			// Token: 0x06000272 RID: 626 RVA: 0x0002AC4C File Offset: 0x00028E4C
			private static FieldDefUser Clone(FieldDef origin)
			{
				return new FieldDefUser(origin.Name, null, origin.Attributes);
			}

			// Token: 0x06000273 RID: 627 RVA: 0x0002AC70 File Offset: 0x00028E70
			private static TypeDef PopulateContext(TypeDef typeDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				IDnlibDef dnlibDef;
				bool flag = !ctx.Map.TryGetValue(typeDef, out dnlibDef);
				bool flag2 = flag;
				bool flag3 = flag2;
				TypeDef typeDef2;
				if (flag3)
				{
					typeDef2 = InjectHelper1.InjectHelper.Clone(typeDef);
					ctx.Map[typeDef] = typeDef2;
				}
				else
				{
					typeDef2 = (TypeDef)dnlibDef;
				}
				foreach (TypeDef typeDef3 in typeDef.NestedTypes)
				{
					typeDef2.NestedTypes.Add(InjectHelper1.InjectHelper.PopulateContext(typeDef3, ctx));
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					typeDef2.Methods.Add((MethodDef)(ctx.Map[methodDef] = InjectHelper1.InjectHelper.Clone(methodDef)));
				}
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					typeDef2.Fields.Add((FieldDef)(ctx.Map[fieldDef] = InjectHelper1.InjectHelper.Clone(fieldDef)));
				}
				return typeDef2;
			}

			// Token: 0x06000274 RID: 628 RVA: 0x0002ADF0 File Offset: 0x00028FF0
			private static void CopyTypeDef(TypeDef typeDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				TypeDef typeDef2 = (TypeDef)ctx.Map[typeDef];
				typeDef2.BaseType = (ITypeDefOrRef)ctx.Importer.Import(typeDef.BaseType);
				foreach (InterfaceImpl interfaceImpl in typeDef.Interfaces)
				{
					typeDef2.Interfaces.Add(new InterfaceImplUser((ITypeDefOrRef)ctx.Importer.Import(interfaceImpl.Interface)));
				}
			}

			// Token: 0x06000275 RID: 629 RVA: 0x0002AE98 File Offset: 0x00029098
			private static void CopyMethodDef(MethodDef methodDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				MethodDef methodDef2 = (MethodDef)ctx.Map[methodDef];
				methodDef2.Signature = ctx.Importer.Import(methodDef.Signature);
				methodDef2.Parameters.UpdateParameterTypes();
				bool flag = methodDef.ImplMap != null;
				bool flag2 = flag;
				bool flag14 = flag2;
				if (flag14)
				{
					methodDef2.ImplMap = new ImplMapUser(new ModuleRefUser(ctx.TargetModule, methodDef.ImplMap.Module.Name), methodDef.ImplMap.Name, methodDef.ImplMap.Attributes);
				}
				foreach (CustomAttribute customAttribute in methodDef.CustomAttributes)
				{
					methodDef2.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)ctx.Importer.Import(customAttribute.Constructor)));
				}
				bool hasBody = methodDef.HasBody;
				bool flag3 = hasBody;
				bool flag15 = flag3;
				if (flag15)
				{
					methodDef2.Body = new CilBody(methodDef.Body.InitLocals, new List<Instruction>(), new List<ExceptionHandler>(), new List<Local>());
					methodDef2.Body.MaxStack = methodDef.Body.MaxStack;
					Dictionary<object, object> bodyMap = new Dictionary<object, object>();
					foreach (Local local in methodDef.Body.Variables)
					{
						Local local2 = new Local(ctx.Importer.Import(local.Type));
						methodDef2.Body.Variables.Add(local2);
						local2.Name = local.Name;
						local2.PdbAttributes = local.PdbAttributes;
						bodyMap[local] = local2;
					}
					foreach (Instruction instruction in methodDef.Body.Instructions)
					{
						Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand);
						instruction2.SequencePoint = instruction.SequencePoint;
						bool flag4 = instruction2.Operand is IType;
						bool flag5 = flag4;
						bool flag16 = flag5;
						if (flag16)
						{
							instruction2.Operand = ctx.Importer.Import((IType)instruction2.Operand);
						}
						else
						{
							bool flag6 = instruction2.Operand is IMethod;
							bool flag7 = flag6;
							bool flag17 = flag7;
							if (flag17)
							{
								instruction2.Operand = ctx.Importer.Import((IMethod)instruction2.Operand);
							}
							else
							{
								bool flag8 = instruction2.Operand is IField;
								bool flag9 = flag8;
								bool flag18 = flag9;
								if (flag18)
								{
									instruction2.Operand = ctx.Importer.Import((IField)instruction2.Operand);
								}
							}
						}
						methodDef2.Body.Instructions.Add(instruction2);
						bodyMap[instruction] = instruction2;
					}
					Func<Instruction, Instruction> <>9__0;
					foreach (Instruction instruction3 in methodDef2.Body.Instructions)
					{
						bool flag10 = instruction3.Operand != null && bodyMap.ContainsKey(instruction3.Operand);
						bool flag11 = flag10;
						bool flag19 = flag11;
						if (flag19)
						{
							instruction3.Operand = bodyMap[instruction3.Operand];
						}
						else
						{
							bool flag12 = instruction3.Operand is Instruction[];
							bool flag13 = flag12;
							bool flag20 = flag13;
							if (flag20)
							{
								Instruction instruction4 = instruction3;
								IEnumerable<Instruction> source = (Instruction[])instruction3.Operand;
								Func<Instruction, Instruction> func2;
								Func<Instruction, Instruction> func = func2 = null;
								bool flag21 = func2 == null;
								if (!flag21)
								{
									Func<Instruction, Instruction> func3;
									if ((func3 = <>9__0) == null)
									{
										func3 = (<>9__0 = ((Instruction target) => (Instruction)bodyMap[target]));
									}
									func = func3;
								}
								Func<Instruction, Instruction> selector = func;
								instruction4.Operand = source.Select(selector).ToArray<Instruction>();
							}
						}
					}
					foreach (ExceptionHandler exceptionHandler in methodDef.Body.ExceptionHandlers)
					{
						methodDef2.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
						{
							CatchType = ((exceptionHandler.CatchType == null) ? null : ((ITypeDefOrRef)ctx.Importer.Import(exceptionHandler.CatchType))),
							TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
							TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
							HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
							HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
							FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
						});
					}
					methodDef2.Body.SimplifyMacros(methodDef2.Parameters);
				}
			}

			// Token: 0x06000276 RID: 630 RVA: 0x0002B4B4 File Offset: 0x000296B4
			private static void CopyFieldDef(FieldDef fieldDef, InjectHelper1.InjectHelper.InjectContext ctx)
			{
				FieldDef fieldDef2 = (FieldDef)ctx.Map[fieldDef];
				fieldDef2.Signature = ctx.Importer.Import(fieldDef.Signature);
			}

			// Token: 0x06000277 RID: 631 RVA: 0x0002B4F0 File Offset: 0x000296F0
			private static void Copy(TypeDef typeDef, InjectHelper1.InjectHelper.InjectContext ctx, bool copySelf)
			{
				if (copySelf)
				{
					InjectHelper1.InjectHelper.CopyTypeDef(typeDef, ctx);
				}
				foreach (TypeDef typeDef2 in typeDef.NestedTypes)
				{
					InjectHelper1.InjectHelper.Copy(typeDef2, ctx, true);
				}
				foreach (MethodDef methodDef in typeDef.Methods)
				{
					InjectHelper1.InjectHelper.CopyMethodDef(methodDef, ctx);
				}
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					InjectHelper1.InjectHelper.CopyFieldDef(fieldDef, ctx);
				}
			}

			// Token: 0x06000278 RID: 632 RVA: 0x0002B5E0 File Offset: 0x000297E0
			public static TypeDef Inject(TypeDef typeDef, ModuleDef target)
			{
				InjectHelper1.InjectHelper.InjectContext injectContext = new InjectHelper1.InjectHelper.InjectContext(typeDef.Module, target);
				InjectHelper1.InjectHelper.PopulateContext(typeDef, injectContext);
				InjectHelper1.InjectHelper.Copy(typeDef, injectContext, true);
				return (TypeDef)injectContext.Map[typeDef];
			}

			// Token: 0x06000279 RID: 633 RVA: 0x0002B624 File Offset: 0x00029824
			public static MethodDef Inject(MethodDef methodDef, ModuleDef target)
			{
				InjectHelper1.InjectHelper.InjectContext injectContext = new InjectHelper1.InjectHelper.InjectContext(methodDef.Module, target);
				injectContext.Map[methodDef] = InjectHelper1.InjectHelper.Clone(methodDef);
				InjectHelper1.InjectHelper.CopyMethodDef(methodDef, injectContext);
				return (MethodDef)injectContext.Map[methodDef];
			}

			// Token: 0x0600027A RID: 634 RVA: 0x0002B670 File Offset: 0x00029870
			public static IEnumerable<IDnlibDef> Inject(TypeDef typeDef, TypeDef newType, ModuleDef target)
			{
				InjectHelper1.InjectHelper.InjectContext injectContext = new InjectHelper1.InjectHelper.InjectContext(typeDef.Module, target);
				injectContext.Map[typeDef] = newType;
				InjectHelper1.InjectHelper.PopulateContext(typeDef, injectContext);
				InjectHelper1.InjectHelper.Copy(typeDef, injectContext, false);
				return injectContext.Map.Values.Except(new TypeDef[]
				{
					newType
				});
			}

			// Token: 0x020000A1 RID: 161
			private class InjectContext : ImportResolver
			{
				// Token: 0x060002BB RID: 699 RVA: 0x0002BFF2 File Offset: 0x0002A1F2
				public InjectContext(ModuleDef module, ModuleDef target)
				{
					this.OriginModule = module;
					this.TargetModule = target;
					this.importer = new Importer(target, ImporterOptions.TryToUseTypeDefs);
					this.importer.Resolver = this;
				}

				// Token: 0x1700000D RID: 13
				// (get) Token: 0x060002BC RID: 700 RVA: 0x0002C030 File Offset: 0x0002A230
				public Importer Importer
				{
					get
					{
						return this.importer;
					}
				}

				// Token: 0x060002BD RID: 701 RVA: 0x0002C048 File Offset: 0x0002A248
				public override TypeDef Resolve(TypeDef typeDef)
				{
					bool flag = this.Map.ContainsKey(typeDef);
					bool flag2 = flag;
					bool flag3 = flag2;
					TypeDef result;
					if (flag3)
					{
						result = (TypeDef)this.Map[typeDef];
					}
					else
					{
						result = null;
					}
					return result;
				}

				// Token: 0x060002BE RID: 702 RVA: 0x0002C08C File Offset: 0x0002A28C
				public override MethodDef Resolve(MethodDef methodDef)
				{
					bool flag = this.Map.ContainsKey(methodDef);
					bool flag2 = flag;
					bool flag3 = flag2;
					MethodDef result;
					if (flag3)
					{
						result = (MethodDef)this.Map[methodDef];
					}
					else
					{
						result = null;
					}
					return result;
				}

				// Token: 0x060002BF RID: 703 RVA: 0x0002C0D0 File Offset: 0x0002A2D0
				public override FieldDef Resolve(FieldDef fieldDef)
				{
					bool flag = this.Map.ContainsKey(fieldDef);
					bool flag2 = flag;
					bool flag3 = flag2;
					FieldDef result;
					if (flag3)
					{
						result = (FieldDef)this.Map[fieldDef];
					}
					else
					{
						result = null;
					}
					return result;
				}

				// Token: 0x0400017D RID: 381
				public readonly Dictionary<IDnlibDef, IDnlibDef> Map = new Dictionary<IDnlibDef, IDnlibDef>();

				// Token: 0x0400017E RID: 382
				public readonly ModuleDef OriginModule;

				// Token: 0x0400017F RID: 383
				public readonly ModuleDef TargetModule;

				// Token: 0x04000180 RID: 384
				private readonly Importer importer;
			}
		}
	}
}
