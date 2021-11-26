using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x0200004D RID: 77
	internal class renamer_v2
	{
		// Token: 0x02000095 RID: 149
		public class RenamerPhase
		{
			// Token: 0x06000292 RID: 658 RVA: 0x0002B838 File Offset: 0x00029A38
			public static void Rename(TypeDef type, [Optional] bool canRename)
			{
				bool flag = renamer_v2.RenamerPhase.typeRename.ContainsKey(type);
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					renamer_v2.RenamerPhase.typeRename[type] = canRename;
				}
				else
				{
					renamer_v2.RenamerPhase.typeRename.Add(type, canRename);
				}
			}

			// Token: 0x06000293 RID: 659 RVA: 0x0002B87C File Offset: 0x00029A7C
			public static void Rename(MethodDef method, [Optional] bool canRename)
			{
				bool flag = renamer_v2.RenamerPhase.methodRename.ContainsKey(method);
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					renamer_v2.RenamerPhase.methodRename[method] = canRename;
				}
				else
				{
					renamer_v2.RenamerPhase.methodRename.Add(method, canRename);
				}
			}

			// Token: 0x06000294 RID: 660 RVA: 0x0002B8C0 File Offset: 0x00029AC0
			public static void Rename(FieldDef field, [Optional] bool canRename)
			{
				bool flag = renamer_v2.RenamerPhase.fieldRename.ContainsKey(field);
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					renamer_v2.RenamerPhase.fieldRename[field] = canRename;
				}
				else
				{
					renamer_v2.RenamerPhase.fieldRename.Add(field, canRename);
				}
			}

			// Token: 0x06000295 RID: 661 RVA: 0x0002B904 File Offset: 0x00029B04
			public static void Execute(ModuleDef module)
			{
				bool isObfuscationActive = renamer_v2.RenamerPhase.IsObfuscationActive;
				bool flag = isObfuscationActive;
				bool flag22 = flag;
				if (flag22)
				{
					string text = renamer_v2.RenamerPhase.GenerateString();
					foreach (TypeDef typeDef in module.Types)
					{
						bool flag3;
						bool flag2 = renamer_v2.RenamerPhase.typeRename.TryGetValue(typeDef, out flag3);
						bool flag4 = flag2;
						bool flag23 = flag4;
						if (flag23)
						{
							bool flag5 = flag3;
							bool flag6 = flag5;
							bool flag24 = flag6;
							if (flag24)
							{
								renamer_v2.RenamerPhase.InternalRename(typeDef);
							}
						}
						else
						{
							renamer_v2.RenamerPhase.InternalRename(typeDef);
						}
						typeDef.Namespace = text;
						foreach (MethodDef methodDef in typeDef.Methods)
						{
							bool flag8;
							bool flag7 = renamer_v2.RenamerPhase.methodRename.TryGetValue(methodDef, out flag8);
							bool flag9 = flag7;
							bool flag25 = flag9;
							if (flag25)
							{
								bool flag10 = flag8 && !methodDef.IsConstructor && !methodDef.IsSpecialName;
								bool flag11 = flag10;
								bool flag26 = flag11;
								if (flag26)
								{
									renamer_v2.RenamerPhase.InternalRename(methodDef);
								}
							}
							else
							{
								bool flag12 = !methodDef.IsConstructor && !methodDef.IsSpecialName;
								bool flag13 = flag12;
								bool flag27 = flag13;
								if (flag27)
								{
									renamer_v2.RenamerPhase.InternalRename(methodDef);
								}
							}
						}
						renamer_v2.RenamerPhase.methodNewName.Clear();
						foreach (FieldDef fieldDef in typeDef.Fields)
						{
							bool flag15;
							bool flag14 = renamer_v2.RenamerPhase.fieldRename.TryGetValue(fieldDef, out flag15);
							bool flag16 = flag14;
							bool flag28 = flag16;
							if (flag28)
							{
								bool flag17 = flag15;
								bool flag18 = flag17;
								bool flag29 = flag18;
								if (flag29)
								{
									renamer_v2.RenamerPhase.InternalRename(fieldDef);
								}
							}
							else
							{
								renamer_v2.RenamerPhase.InternalRename(fieldDef);
							}
						}
						renamer_v2.RenamerPhase.fieldNewName.Clear();
					}
				}
				else
				{
					foreach (KeyValuePair<TypeDef, bool> keyValuePair in renamer_v2.RenamerPhase.typeRename)
					{
						bool value = keyValuePair.Value;
						bool flag19 = value;
						bool flag30 = flag19;
						if (flag30)
						{
							renamer_v2.RenamerPhase.InternalRename(keyValuePair.Key);
						}
					}
					foreach (KeyValuePair<MethodDef, bool> keyValuePair2 in renamer_v2.RenamerPhase.methodRename)
					{
						bool value2 = keyValuePair2.Value;
						bool flag20 = value2;
						bool flag31 = flag20;
						if (flag31)
						{
							renamer_v2.RenamerPhase.InternalRename(keyValuePair2.Key);
						}
					}
					foreach (KeyValuePair<FieldDef, bool> keyValuePair3 in renamer_v2.RenamerPhase.fieldRename)
					{
						bool value3 = keyValuePair3.Value;
						bool flag21 = value3;
						bool flag32 = flag21;
						if (flag32)
						{
							renamer_v2.RenamerPhase.InternalRename(keyValuePair3.Key);
						}
					}
				}
			}

			// Token: 0x06000296 RID: 662 RVA: 0x0002BCA4 File Offset: 0x00029EA4
			private static void InternalRename(TypeDef type)
			{
				string text = renamer_v2.RenamerPhase.GenerateString();
				while (renamer_v2.RenamerPhase.typeNewName.Contains(text))
				{
					text = renamer_v2.RenamerPhase.GenerateString();
				}
				renamer_v2.RenamerPhase.typeNewName.Add(text);
				type.Name = text;
			}

			// Token: 0x06000297 RID: 663 RVA: 0x0002BCEC File Offset: 0x00029EEC
			private static void InternalRename(MethodDef method)
			{
				string text = renamer_v2.RenamerPhase.GenerateString();
				while (renamer_v2.RenamerPhase.methodNewName.Contains(text))
				{
					text = renamer_v2.RenamerPhase.GenerateString();
				}
				renamer_v2.RenamerPhase.methodNewName.Add(text);
				method.Name = text;
			}

			// Token: 0x06000298 RID: 664 RVA: 0x0002BD34 File Offset: 0x00029F34
			private static void InternalRename(FieldDef field)
			{
				string text = renamer_v2.RenamerPhase.GenerateString();
				while (renamer_v2.RenamerPhase.fieldNewName.Contains(text))
				{
					text = renamer_v2.RenamerPhase.GenerateString();
				}
				renamer_v2.RenamerPhase.fieldNewName.Add(text);
				field.Name = text;
			}

			// Token: 0x06000299 RID: 665 RVA: 0x0002BD7C File Offset: 0x00029F7C
			private static string GenerateString()
			{
				string text = "痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵";
				for (int i = 0; i < 3; i++)
				{
					text += ((char)renamer_v2.RenamerPhase.random.Next(8000, 8500)).ToString();
				}
				return text;
			}

			// Token: 0x04000161 RID: 353
			private static Dictionary<TypeDef, bool> typeRename = new Dictionary<TypeDef, bool>();

			// Token: 0x04000162 RID: 354
			private static List<string> typeNewName = new List<string>();

			// Token: 0x04000163 RID: 355
			private static Dictionary<MethodDef, bool> methodRename = new Dictionary<MethodDef, bool>();

			// Token: 0x04000164 RID: 356
			private static List<string> methodNewName = new List<string>();

			// Token: 0x04000165 RID: 357
			private static Dictionary<FieldDef, bool> fieldRename = new Dictionary<FieldDef, bool>();

			// Token: 0x04000166 RID: 358
			private static List<string> fieldNewName = new List<string>();

			// Token: 0x04000167 RID: 359
			public static bool IsObfuscationActive = true;

			// Token: 0x04000168 RID: 360
			private static Random random = new Random();
		}
	}
}
