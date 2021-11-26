using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200003C RID: 60
	internal class LocalToFields
	{
		// Token: 0x0600012B RID: 299 RVA: 0x00019270 File Offset: 0x00017470
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
										bool flag6 = !LocalToFields.convertedLocals.ContainsKey(local);
										bool flag7 = flag6;
										bool flag11 = flag7;
										FieldDef fieldDef;
										if (flag11)
										{
											fieldDef = new FieldDefUser("InfernoOBF", new FieldSig(local.Type), FieldAttributes.FamANDAssem | FieldAttributes.Family | FieldAttributes.Static | FieldAttributes.NotSerialized);
											md.GlobalType.Fields.Add(fieldDef);
											LocalToFields.convertedLocals.Add(local, fieldDef);
										}
										else
										{
											fieldDef = LocalToFields.convertedLocals[local];
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
								LocalToFields.convertedLocals.ToList<KeyValuePair<Local, FieldDef>>().ForEach(delegate(KeyValuePair<Local, FieldDef> x)
								{
									method.Body.Variables.Remove(x.Key);
								});
								LocalToFields.convertedLocals = new Dictionary<Local, FieldDef>();
							}
						}
					}
				}
			}
		}

		// Token: 0x04000082 RID: 130
		private static Dictionary<Local, FieldDef> convertedLocals = new Dictionary<Local, FieldDef>();
	}
}
