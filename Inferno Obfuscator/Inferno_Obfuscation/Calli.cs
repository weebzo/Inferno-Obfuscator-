using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200002C RID: 44
	internal class Calli
	{
		// Token: 0x060000CB RID: 203 RVA: 0x000107A0 File Offset: 0x0000E9A0
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef type in module.Types.ToArray<TypeDef>())
			{
				foreach (MethodDef method in type.Methods.ToArray<MethodDef>())
				{
					bool flag = !method.HasBody;
					if (!flag)
					{
						bool flag2 = !method.Body.HasInstructions;
						if (!flag2)
						{
							bool flag3 = method.FullName.Contains("My.");
							if (!flag3)
							{
								bool flag4 = method.FullName.Contains(".My");
								if (!flag4)
								{
									bool isConstructor = method.IsConstructor;
									if (!isConstructor)
									{
										bool isGlobalModuleType = method.DeclaringType.IsGlobalModuleType;
										if (!isGlobalModuleType)
										{
											int i = 0;
											while (i < method.Body.Instructions.Count - 1)
											{
												try
												{
													bool flag5 = method.Body.Instructions[i].ToString().Contains("ISupportInitialize") || (method.Body.Instructions[i].OpCode != OpCodes.Call && method.Body.Instructions[i].OpCode != OpCodes.Callvirt && method.Body.Instructions[i].OpCode != OpCodes.Ldloc_S);
													if (!flag5)
													{
														try
														{
															MemberRef membertocalli = (MemberRef)method.Body.Instructions[i].Operand;
															method.Body.Instructions[i].OpCode = OpCodes.Calli;
															method.Body.Instructions[i].Operand = membertocalli.MethodSig;
															method.Body.Instructions.Insert(i, Instruction.Create(OpCodes.Ldftn, membertocalli));
														}
														catch (Exception)
														{
														}
													}
												}
												catch (Exception)
												{
												}
												IL_1F3:
												i++;
												continue;
												goto IL_1F3;
											}
										}
									}
								}
							}
						}
					}
				}
				foreach (MethodDef md in module.GlobalType.Methods)
				{
					bool flag6 = md.Name != ".ctor";
					if (!flag6)
					{
						module.GlobalType.Remove(md);
						break;
					}
				}
			}
		}
	}
}
