using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.Virtualization
{
	// Token: 0x0200005B RID: 91
	internal class Method_Wiper
	{
		// Token: 0x060001E2 RID: 482 RVA: 0x000259C4 File Offset: 0x00023BC4
		public static MethodDef GenerateMethod(TypeDef declaringType, object targetMethod, [Optional] bool hasThis, [Optional] bool isVoid)
		{
			MemberRef memberRef = (MemberRef)targetMethod;
			MethodDef methodDef = new MethodDefUser("Inferno_" + Method_Wiper.rnd.Next(1, 10000).ToString(), MethodSig.CreateStatic(memberRef.ReturnType), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
			methodDef.Body = new CilBody();
			if (hasThis)
			{
				methodDef.MethodSig.Params.Add(declaringType.Module.Import(declaringType.Module.CorLibTypes.Object));
			}
			foreach (TypeSig item in memberRef.MethodSig.Params)
			{
				methodDef.MethodSig.Params.Add(item);
			}
			methodDef.Parameters.UpdateParameterTypes();
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			Instruction instruction2 = OpCodes.Call.ToInstruction(declaringType.Module.Import(typeof(string).GetMethod("IsNullOrEmpty", new Type[]
			{
				typeof(string)
			})));
			foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef.Parameters))
			{
				methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, parameter));
			}
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Call, memberRef));
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
			return methodDef;
		}

		// Token: 0x060001E3 RID: 483 RVA: 0x00025BA0 File Offset: 0x00023DA0
		public static void Fix(ModuleDef moduleDef)
		{
			AssemblyResolver assemblyResolver = new AssemblyResolver();
			ModuleContext moduleContext = new ModuleContext(assemblyResolver);
			assemblyResolver.DefaultModuleContext = moduleContext;
			assemblyResolver.EnableTypeDefCache = true;
			List<AssemblyRef> list = moduleDef.GetAssemblyRefs().ToList<AssemblyRef>();
			moduleDef.Context = moduleContext;
			foreach (AssemblyRef assemblyRef in list)
			{
				bool flag = assemblyRef == null;
				bool flag2 = !flag;
				bool flag3 = flag2;
				bool flag7 = flag3;
				if (flag7)
				{
					AssemblyDef assemblyDef = assemblyResolver.Resolve(assemblyRef.FullName, moduleDef);
					bool flag4 = assemblyDef == null;
					bool flag5 = !flag4;
					bool flag6 = flag5;
					bool flag8 = flag6;
					if (flag8)
					{
						moduleDef.Context.AssemblyResolver.AddToCache(assemblyDef);
					}
				}
			}
		}

		// Token: 0x060001E4 RID: 484 RVA: 0x00025C7C File Offset: 0x00023E7C
		public static void Execute(ModuleDef md)
		{
			Method_Wiper.Fix(md);
			foreach (TypeDef typeDef in md.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef methodDef in typeDef.Methods.ToArray<MethodDef>())
				{
					bool flag = Method_Wiper.usedMethods.Contains(methodDef);
					bool flag2 = !flag;
					bool flag13 = flag2;
					if (flag13)
					{
						bool flag3 = !methodDef.HasBody;
						bool flag4 = flag3;
						bool flag14 = flag4;
						if (flag14)
						{
							return;
						}
						foreach (Instruction instruction in methodDef.Body.Instructions.ToArray<Instruction>())
						{
							bool flag5 = instruction.OpCode == OpCodes.Call;
							bool flag6 = flag5;
							bool flag15 = flag6;
							if (flag15)
							{
								bool flag7 = instruction.Operand is MemberRef;
								bool flag8 = flag7;
								bool flag16 = flag8;
								if (flag16)
								{
									MemberRef memberRef = (MemberRef)instruction.Operand;
									bool flag9 = !memberRef.FullName.Contains("Collections.Generic") && !memberRef.Name.Contains("ToString") && !memberRef.FullName.Contains("Thread::Start") && !memberRef.FullName.Contains("Properties.Settings");
									bool flag10 = flag9;
									bool flag17 = flag10;
									if (flag17)
									{
										MethodDef methodDef2 = Method_Wiper.GenerateMethod(typeDef, memberRef, memberRef.HasThis, memberRef.FullName.StartsWith("System.Void"));
										bool flag11 = methodDef2 != null;
										bool flag12 = flag11;
										bool flag18 = flag12;
										if (flag18)
										{
											Method_Wiper.usedMethods.Add(methodDef2);
											typeDef.Methods.Add(methodDef2);
											instruction.Operand = methodDef2;
											methodDef2.Body.Instructions.Add(new Instruction(OpCodes.Ret));
										}
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x04000111 RID: 273
		public static Random rnd = new Random();

		// Token: 0x04000112 RID: 274
		private static List<MethodDef> usedMethods = new List<MethodDef>();
	}
}
