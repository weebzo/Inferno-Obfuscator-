using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscator
{
	// Token: 0x02000025 RID: 37
	internal class Renamer
	{
		// Token: 0x02000079 RID: 121
		public interface IRenaming
		{
			// Token: 0x06000245 RID: 581
			ModuleDefMD Rename(ModuleDefMD module);
		}

		// Token: 0x0200007A RID: 122
		public static class Generator
		{
			// Token: 0x06000246 RID: 582 RVA: 0x00029AA4 File Offset: 0x00027CA4
			public static string GenerateString()
			{
				int num = 2;
				byte[] array = new byte[num];
				new RNGCryptoServiceProvider().GetBytes(array);
				string str = null;
				return str + Renamer.Generator.EncodeString(array, Renamer.Generator.unicodeCharset);
			}

			// Token: 0x06000247 RID: 583 RVA: 0x00029AE0 File Offset: 0x00027CE0
			private static string EncodeString(byte[] buff, char[] charset)
			{
				int i = (int)buff[0];
				StringBuilder stringBuilder = new StringBuilder();
				for (int j = 1; j < buff.Length; j++)
				{
					for (i = (i << 8) + (int)buff[j]; i >= charset.Length; i /= charset.Length)
					{
						stringBuilder.Append(charset[i % charset.Length]);
					}
				}
				bool flag = i != 0;
				bool flag2 = flag;
				if (flag2)
				{
					stringBuilder.Append(charset[i % charset.Length]);
				}
				return stringBuilder.ToString();
			}

			// Token: 0x06000248 RID: 584 RVA: 0x00029B68 File Offset: 0x00027D68
			public static byte[] GetBytes(int lenght)
			{
				byte[] array = new byte[lenght];
				new RNGCryptoServiceProvider().GetBytes(array);
				return array;
			}

			// Token: 0x04000131 RID: 305
			private static readonly char[] unicodeCharset = new char[0].Concat(from ord in Enumerable.Range(8203, 5)
			select (char)ord).Concat(from ord in Enumerable.Range(8233, 6)
			select (char)ord).Concat(from ord in Enumerable.Range(8298, 6)
			select (char)ord).Except(new char[]
			{
				'搷'
			}).ToArray<char>();
		}

		// Token: 0x0200007B RID: 123
		public static class Renamer3
		{
			// Token: 0x0600024A RID: 586 RVA: 0x00029C30 File Offset: 0x00027E30
			public static ModuleDef Rename(ModuleDef mod)
			{
				ModuleDefMD module = (ModuleDefMD)mod;
				Renamer.IRenaming renaming = new Renamer.NamespacesRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.ClassesRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.MethodsRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.PropertiesRenaming();
				module = renaming.Rename(module);
				renaming = new Renamer.FieldsRenaming();
				return renaming.Rename(module);
			}
		}

		// Token: 0x0200007C RID: 124
		public class FieldsRenaming : Renamer.IRenaming
		{
			// Token: 0x0600024B RID: 587 RVA: 0x00029C90 File Offset: 0x00027E90
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag2 = !isGlobalModuleType;
					if (flag2)
					{
						foreach (FieldDef fieldDef in typeDef.Fields)
						{
							string s;
							bool flag = Renamer.FieldsRenaming._names.TryGetValue(fieldDef.Name, out s);
							bool flag3 = flag;
							if (flag3)
							{
								fieldDef.Name = s;
							}
							else
							{
								string text = Renamer.Generator.GenerateString();
								Renamer.FieldsRenaming._names.Add(fieldDef.Name, text);
								fieldDef.Name = text;
							}
						}
					}
				}
				return Renamer.FieldsRenaming.ApplyChangesToResources(module);
			}

			// Token: 0x0600024C RID: 588 RVA: 0x00029DA8 File Offset: 0x00027FA8
			private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag4 = !isGlobalModuleType;
					if (flag4)
					{
						foreach (MethodDef methodDef in typeDef.Methods)
						{
							bool flag = methodDef.Name != "InitializeComponent";
							bool flag5 = !flag;
							if (flag5)
							{
								IList<Instruction> instructions = methodDef.Body.Instructions;
								for (int i = 0; i < instructions.Count - 3; i++)
								{
									bool flag2 = instructions[i].OpCode == OpCodes.Ldstr;
									bool flag6 = flag2;
									if (flag6)
									{
										foreach (KeyValuePair<string, string> keyValuePair in Renamer.FieldsRenaming._names)
										{
											bool flag3 = keyValuePair.Key == instructions[i].Operand.ToString();
											bool flag7 = flag3;
											if (flag7)
											{
												instructions[i].Operand = keyValuePair.Value;
											}
										}
									}
								}
							}
						}
					}
				}
				return module;
			}

			// Token: 0x04000132 RID: 306
			private static Dictionary<string, string> _names = new Dictionary<string, string>();
		}

		// Token: 0x0200007D RID: 125
		public class ClassesRenaming : Renamer.IRenaming
		{
			// Token: 0x0600024F RID: 591 RVA: 0x00029F90 File Offset: 0x00028190
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag3 = !isGlobalModuleType;
					if (flag3)
					{
						bool flag = typeDef.Name == "GeneratedInternalTypeHelper" || typeDef.Name == "Resources" || typeDef.Name == "Settings";
						bool flag4 = !flag;
						if (flag4)
						{
							string s;
							bool flag2 = Renamer.ClassesRenaming._names.TryGetValue(typeDef.Name, out s);
							bool flag5 = flag2;
							if (flag5)
							{
								typeDef.Name = s;
							}
							else
							{
								string text = Renamer.Generator.GenerateString();
								Renamer.ClassesRenaming._names.Add(typeDef.Name, text);
								typeDef.Name = text;
							}
						}
					}
				}
				return Renamer.ClassesRenaming.ApplyChangesToResources(module);
			}

			// Token: 0x06000250 RID: 592 RVA: 0x0002A0AC File Offset: 0x000282AC
			private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
			{
				foreach (Resource resource in module.Resources)
				{
					foreach (KeyValuePair<string, string> keyValuePair in Renamer.ClassesRenaming._names)
					{
						bool flag = resource.Name.Contains(keyValuePair.Key);
						bool flag5 = flag;
						if (flag5)
						{
							resource.Name = resource.Name.Replace(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
				foreach (TypeDef typeDef in module.GetTypes())
				{
					foreach (PropertyDef propertyDef in typeDef.Properties)
					{
						bool flag2 = propertyDef.Name != "ResourceManager";
						bool flag6 = !flag2;
						if (flag6)
						{
							IList<Instruction> instructions = propertyDef.GetMethod.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag3 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag7 = flag3;
								if (flag7)
								{
									foreach (KeyValuePair<string, string> keyValuePair2 in Renamer.ClassesRenaming._names)
									{
										bool flag4 = instructions[i].Operand.ToString().Contains(keyValuePair2.Key);
										bool flag8 = flag4;
										if (flag8)
										{
											instructions[i].Operand = instructions[i].Operand.ToString().Replace(keyValuePair2.Key, keyValuePair2.Value);
										}
									}
								}
							}
						}
					}
				}
				return module;
			}

			// Token: 0x04000133 RID: 307
			private static Dictionary<string, string> _names = new Dictionary<string, string>();
		}

		// Token: 0x0200007E RID: 126
		public class MethodsRenaming : Renamer.IRenaming
		{
			// Token: 0x06000253 RID: 595 RVA: 0x0002A37C File Offset: 0x0002857C
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag4 = !isGlobalModuleType;
					if (flag4)
					{
						bool flag = typeDef.Name == "GeneratedInternalTypeHelper";
						bool flag5 = !flag;
						if (flag5)
						{
							foreach (MethodDef methodDef in typeDef.Methods)
							{
								bool flag2 = !methodDef.HasBody;
								bool flag6 = !flag2;
								if (flag6)
								{
									bool flag3 = methodDef.Name == ".ctor" || methodDef.Name == ".cctor";
									bool flag7 = !flag3;
									if (flag7)
									{
										methodDef.Name = Renamer.Generator.GenerateString();
									}
								}
							}
						}
					}
				}
				return module;
			}
		}

		// Token: 0x0200007F RID: 127
		public class NamespacesRenaming : Renamer.IRenaming
		{
			// Token: 0x06000255 RID: 597 RVA: 0x0002A4B8 File Offset: 0x000286B8
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag3 = !isGlobalModuleType;
					if (flag3)
					{
						bool flag = typeDef.Namespace == "";
						bool flag4 = !flag;
						if (flag4)
						{
							string s;
							bool flag2 = Renamer.NamespacesRenaming._names.TryGetValue(typeDef.Namespace, out s);
							bool flag5 = flag2;
							if (flag5)
							{
								typeDef.Namespace = s;
							}
							else
							{
								string text = Renamer.Generator.GenerateString();
								Renamer.NamespacesRenaming._names.Add(typeDef.Namespace, text);
								typeDef.Namespace = text;
							}
						}
					}
				}
				return Renamer.NamespacesRenaming.ApplyChangesToResources(module);
			}

			// Token: 0x06000256 RID: 598 RVA: 0x0002A5AC File Offset: 0x000287AC
			private static ModuleDefMD ApplyChangesToResources(ModuleDefMD module)
			{
				foreach (Resource resource in module.Resources)
				{
					foreach (KeyValuePair<string, string> keyValuePair in Renamer.NamespacesRenaming._names)
					{
						bool flag = resource.Name.Contains(keyValuePair.Key);
						bool flag5 = flag;
						if (flag5)
						{
							resource.Name = resource.Name.Replace(keyValuePair.Key, keyValuePair.Value);
						}
					}
				}
				foreach (TypeDef typeDef in module.GetTypes())
				{
					foreach (PropertyDef propertyDef in typeDef.Properties)
					{
						bool flag2 = propertyDef.Name != "ResourceManager";
						bool flag6 = !flag2;
						if (flag6)
						{
							IList<Instruction> instructions = propertyDef.GetMethod.Body.Instructions;
							for (int i = 0; i < instructions.Count; i++)
							{
								bool flag3 = instructions[i].OpCode == OpCodes.Ldstr;
								bool flag7 = flag3;
								if (flag7)
								{
									foreach (KeyValuePair<string, string> keyValuePair2 in Renamer.NamespacesRenaming._names)
									{
										bool flag4 = instructions[i].ToString().Contains(keyValuePair2.Key);
										bool flag8 = flag4;
										if (flag8)
										{
											instructions[i].Operand = instructions[i].Operand.ToString().Replace(keyValuePair2.Key, keyValuePair2.Value);
										}
									}
								}
							}
						}
					}
				}
				return module;
			}

			// Token: 0x04000134 RID: 308
			private static Dictionary<string, string> _names = new Dictionary<string, string>();
		}

		// Token: 0x02000080 RID: 128
		public class PropertiesRenaming : Renamer.IRenaming
		{
			// Token: 0x06000259 RID: 601 RVA: 0x0002A874 File Offset: 0x00028A74
			public ModuleDefMD Rename(ModuleDefMD module)
			{
				foreach (TypeDef typeDef in module.GetTypes())
				{
					bool isGlobalModuleType = typeDef.IsGlobalModuleType;
					bool flag = !isGlobalModuleType;
					if (flag)
					{
						foreach (PropertyDef propertyDef in typeDef.Properties)
						{
							propertyDef.Name = Renamer.Generator.GenerateString();
						}
					}
				}
				return module;
			}
		}
	}
}
