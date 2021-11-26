using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200003B RID: 59
	internal class L2FV2
	{
		// Token: 0x06000127 RID: 295 RVA: 0x00018FBC File Offset: 0x000171BC
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
					L2FV2.convertedLocals = new Dictionary<Local, FieldDef>();
					L2FV2.Process(Module, method2);
				}
			}
		}

		// Token: 0x06000128 RID: 296 RVA: 0x000190B8 File Offset: 0x000172B8
		public static void Process(ModuleDef Module, MethodDef method)
		{
			method.Body.SimplifyMacros(method.Parameters);
			IList<Instruction> instructions = method.Body.Instructions;
			foreach (Instruction t in instructions)
			{
				Local local = t.Operand as Local;
				bool flag = local == null;
				if (!flag)
				{
					bool flag2 = !L2FV2.convertedLocals.ContainsKey(local);
					FieldDef def;
					if (flag2)
					{
						def = new FieldDefUser(RenamerPhase.GenerateString(RenamerPhase.RenameMode.Normal), new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
						Module.GlobalType.Fields.Add(def);
						L2FV2.convertedLocals.Add(local, def);
					}
					else
					{
						def = L2FV2.convertedLocals[local];
					}
					OpCode eq = null;
					switch (t.OpCode.Code)
					{
					case Code.Ldloc:
						eq = OpCodes.Ldsfld;
						break;
					case Code.Ldloca:
						eq = OpCodes.Ldsflda;
						break;
					case Code.Stloc:
						eq = OpCodes.Stsfld;
						break;
					}
					t.OpCode = eq;
					t.Operand = def;
				}
			}
			L2FV2.convertedLocals.ToList<KeyValuePair<Local, FieldDef>>().ForEach(delegate(KeyValuePair<Local, FieldDef> x)
			{
				method.Body.Variables.Remove(x.Key);
			});
			L2FV2.convertedLocals = new Dictionary<Local, FieldDef>();
		}

		// Token: 0x04000081 RID: 129
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
