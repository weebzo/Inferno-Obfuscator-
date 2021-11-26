using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.Virtualization
{
	// Token: 0x0200005A RID: 90
	internal class Locals
	{
		// Token: 0x060001DF RID: 479 RVA: 0x0002571C File Offset: 0x0002391C
		public static void Protect(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.GetTypes())
			{
				bool flag = !typeDef.IsGlobalModuleType;
				bool flag2 = flag;
				bool flag8 = flag2;
				if (flag8)
				{
					using (IEnumerator<MethodDef> enumerator2 = typeDef.Methods.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							MethodDef method = enumerator2.Current;
							bool hasBody = method.HasBody;
							bool flag3 = hasBody;
							bool flag9 = flag3;
							if (flag9)
							{
								method.Body.SimplifyMacros(method.Parameters);
								IList<Instruction> instructions = method.Body.Instructions;
								for (int i = 0; i < instructions.Count; i++)
								{
									Local local = instructions[i].Operand as Local;
									bool flag4 = local != null;
									bool flag5 = flag4;
									bool flag10 = flag5;
									if (flag10)
									{
										bool flag6 = !Locals.convertedLocals.ContainsKey(local);
										bool flag7 = flag6;
										bool flag11 = flag7;
										FieldDef fieldDef;
										if (flag11)
										{
											fieldDef = new FieldDefUser("Inferno_" + Assembly.Random(8), new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static);
											md.GlobalType.Fields.Add(fieldDef);
											Locals.convertedLocals.Add(local, fieldDef);
										}
										else
										{
											fieldDef = Locals.convertedLocals[local];
										}
										OpCode opCode = null;
										switch (instructions[i].OpCode.Code)
										{
										case Code.Ldloc:
											opCode = OpCodes.Ldsfld;
											break;
										case Code.Ldloca:
											opCode = OpCodes.Ldsflda;
											break;
										case Code.Stloc:
											opCode = OpCodes.Stsfld;
											break;
										}
										instructions[i].OpCode = opCode;
										instructions[i].Operand = fieldDef;
									}
								}
								Locals.convertedLocals.ToList<KeyValuePair<Local, FieldDef>>().ForEach(delegate(KeyValuePair<Local, FieldDef> x)
								{
									method.Body.Variables.Remove(x.Key);
								});
								Locals.convertedLocals = new Dictionary<Local, FieldDef>();
							}
						}
					}
				}
			}
		}

		// Token: 0x04000110 RID: 272
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
