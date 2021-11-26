using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200003A RID: 58
	internal class L2F
	{
		// Token: 0x06000123 RID: 291 RVA: 0x00018D24 File Offset: 0x00016F24
		public static void Execute(ModuleDef Module)
		{
			IEnumerable<TypeDef> types = Module.Types;
			Func<TypeDef, bool> <>9__0;
			Func<TypeDef, bool> predicate;
			if ((predicate = <>9__0) == null)
			{
				predicate = (<>9__0 = ((TypeDef x) => x != Module.GlobalType));
			}
			foreach (TypeDef type in types.Where(predicate))
			{
				foreach (MethodDef method2 in from x in type.Methods
				where x.HasBody && x.Body.HasInstructions && !x.IsConstructor
				select x)
				{
					L2F.convertedLocals = new Dictionary<Local, FieldDef>();
					L2F.Process(Module, method2);
				}
			}
		}

		// Token: 0x06000124 RID: 292 RVA: 0x00018E20 File Offset: 0x00017020
		public static void Process(ModuleDef module, MethodDef method)
		{
			IList<Instruction> instructions = method.Body.Instructions;
			foreach (Instruction t in instructions)
			{
				Local local = t.Operand as Local;
				bool flag = local == null;
				if (!flag)
				{
					bool flag2 = !L2F.convertedLocals.ContainsKey(local);
					FieldDef def;
					if (flag2)
					{
						def = new FieldDefUser(RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal), new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
						module.GlobalType.Fields.Add(def);
						L2F.convertedLocals.Add(local, def);
					}
					else
					{
						def = L2F.convertedLocals[local];
					}
					OpCode eq = null;
					Code code = t.OpCode.Code;
					Code code2 = code;
					switch (code2)
					{
					case Code.Ldloc_0:
					case Code.Ldloc_1:
					case Code.Ldloc_2:
					case Code.Ldloc_3:
					case Code.Ldloc_S:
						goto IL_117;
					case Code.Stloc_0:
					case Code.Stloc_1:
					case Code.Stloc_2:
					case Code.Stloc_3:
					case Code.Stloc_S:
						goto IL_129;
					case Code.Ldarg_S:
					case Code.Ldarga_S:
					case Code.Starg_S:
						break;
					case Code.Ldloca_S:
						goto IL_120;
					default:
						switch (code2)
						{
						case Code.Ldloc:
							goto IL_117;
						case Code.Ldloca:
							goto IL_120;
						case Code.Stloc:
							goto IL_129;
						}
						break;
					}
					IL_132:
					t.OpCode = eq;
					t.Operand = def;
					continue;
					IL_117:
					eq = OpCodes.Ldsfld;
					goto IL_132;
					IL_120:
					eq = OpCodes.Ldsflda;
					goto IL_132;
					IL_129:
					eq = OpCodes.Stsfld;
					goto IL_132;
				}
			}
		}

		// Token: 0x04000080 RID: 128
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
