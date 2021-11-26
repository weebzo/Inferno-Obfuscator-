using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation.Virtualization
{
	// Token: 0x02000059 RID: 89
	internal class Assembly
	{
		// Token: 0x060001D7 RID: 471 RVA: 0x00024F04 File Offset: 0x00023104
		public static string Random(int length)
		{
			return new string((from s in Enumerable.Repeat<string>("qwertyuiopasdfghjklzxcqwer1234590tyuiopasdfghjklz1234567890cvQWERTPASDF痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞GHJZXCVNMbnmqwertyuiopasdfghjklzxcvbnmqwertyuiopasdfghjklzxcvbnmvbnm", length)
			select s[Assembly.random.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060001D8 RID: 472 RVA: 0x00024F50 File Offset: 0x00023150
		public static bool CanRename(TypeDef type)
		{
			bool isGlobalModuleType = type.IsGlobalModuleType;
			bool flag = isGlobalModuleType;
			bool flag10 = flag;
			bool result;
			if (flag10)
			{
				result = false;
			}
			else
			{
				try
				{
					bool flag2 = type.Namespace.Contains("My");
					bool flag3 = flag2;
					bool flag11 = flag3;
					if (flag11)
					{
						return false;
					}
				}
				catch
				{
				}
				bool isGlobalModuleType2 = type.IsGlobalModuleType;
				bool flag4 = isGlobalModuleType2;
				bool flag12 = flag4;
				if (flag12)
				{
					result = false;
				}
				else
				{
					bool flag5 = type.Name == "GeneratedInternalTypeHelper" || type.Name == "Resources" || type.Name == "Settings";
					bool flag6 = flag5;
					bool flag13 = flag6;
					if (flag13)
					{
						result = false;
					}
					else
					{
						bool flag7 = type.Interfaces.Count > 0;
						bool flag8 = flag7;
						bool flag14 = flag8;
						if (flag14)
						{
							result = false;
						}
						else
						{
							bool isSpecialName = type.IsSpecialName;
							bool flag9 = isSpecialName;
							bool flag15 = flag9;
							if (flag15)
							{
								result = false;
							}
							else
							{
								bool isRuntimeSpecialName = type.IsRuntimeSpecialName;
								result = !isRuntimeSpecialName;
							}
						}
					}
				}
			}
			return result;
		}

		// Token: 0x060001D9 RID: 473 RVA: 0x00025078 File Offset: 0x00023278
		public static bool CanRename(EventDef ev)
		{
			bool isRuntimeSpecialName = ev.IsRuntimeSpecialName;
			return !isRuntimeSpecialName;
		}

		// Token: 0x060001DA RID: 474 RVA: 0x00025098 File Offset: 0x00023298
		public static bool CanRename(MethodDef method)
		{
			bool isConstructor = method.IsConstructor;
			bool flag = isConstructor;
			bool flag4 = flag;
			bool result;
			if (flag4)
			{
				result = false;
			}
			else
			{
				bool isFamily = method.IsFamily;
				bool flag2 = isFamily;
				bool flag5 = flag2;
				if (flag5)
				{
					result = false;
				}
				else
				{
					bool isRuntimeSpecialName = method.IsRuntimeSpecialName;
					bool flag3 = isRuntimeSpecialName;
					bool flag6 = flag3;
					if (flag6)
					{
						result = false;
					}
					else
					{
						bool isForwarder = method.DeclaringType.IsForwarder;
						result = !isForwarder;
					}
				}
			}
			return result;
		}

		// Token: 0x060001DB RID: 475 RVA: 0x00025110 File Offset: 0x00023310
		public static bool CanRename(FieldDef field)
		{
			bool flag = field.IsFamily || field.IsFamilyOrAssembly || field.IsPublic;
			bool flag2 = flag;
			bool flag7 = flag2;
			bool result;
			if (flag7)
			{
				result = false;
			}
			else
			{
				bool isRuntimeSpecialName = field.IsRuntimeSpecialName;
				bool flag3 = isRuntimeSpecialName;
				bool flag8 = flag3;
				if (flag8)
				{
					result = false;
				}
				else
				{
					bool flag4 = field.DeclaringType.IsSerializable && !field.IsNotSerialized;
					bool flag5 = flag4;
					bool flag9 = flag5;
					if (flag9)
					{
						result = false;
					}
					else
					{
						bool flag6 = field.IsLiteral && field.DeclaringType.IsEnum;
						result = !flag6;
					}
				}
			}
			return result;
		}

		// Token: 0x060001DC RID: 476 RVA: 0x000251B8 File Offset: 0x000233B8
		public static void MarkAssembly(ModuleDef md)
		{
			md.Name = "\ud835\udd04\ud835\udd31\ud835\udd2c\ud835\udd2a\ud835\udd26\ud835\udd20 \ud835\udd12\ud835\udd1f\ud835\udd23\ud835\udd32\ud835\udd30\ud835\udd20\ud835\udd1e\ud835\udd31\ud835\udd2c��";
			md.Assembly.Name = "\ud835\udd04\ud835\udd31\ud835\udd2c\ud835\udd2a\ud835\udd26\ud835\udd20 \ud835\udd12\ud835\udd1f\ud835\udd23\ud835\udd32\ud835\udd30\ud835\udd20\ud835\udd1e\ud835\udd31\ud835\udd2c��";
			md.EntryPoint.DeclaringType = md.GlobalType;
			md.EntryPoint.Name = "INFERNO_OBF";
			TypeDef globalType = md.GlobalType;
			TypeDefUser typeDefUser = new TypeDefUser(globalType.Name);
			globalType.Name = "Inferno";
			globalType.BaseType = md.CorLibTypes.GetTypeRef("System", "Object");
			md.Types.Insert(0, typeDefUser);
			MethodDef methodDef = globalType.FindOrCreateStaticConstructor();
			MethodDef methodDef2 = typeDefUser.FindOrCreateStaticConstructor();
			methodDef.Name = "Inferno";
			methodDef.IsRuntimeSpecialName = false;
			methodDef.IsSpecialName = false;
			methodDef.Access = MethodAttributes.PrivateScope;
			methodDef2.Body = new CilBody(true, new List<Instruction>
			{
				Instruction.Create(OpCodes.Call, methodDef),
				Instruction.Create(OpCodes.Ret)
			}, new List<ExceptionHandler>(), new List<Local>());
			for (int i = 0; i < globalType.Methods.Count; i++)
			{
				MethodDef methodDef3 = globalType.Methods[i];
				bool isNative = methodDef3.IsNative;
				bool flag = isNative;
				bool flag9 = flag;
				if (flag9)
				{
					MethodDefUser methodDefUser = new MethodDefUser(methodDef3.Name, methodDef3.MethodSig.Clone());
					methodDefUser.Attributes = (MethodAttributes.Private | MethodAttributes.FamANDAssem | MethodAttributes.Static);
					methodDefUser.Body = new CilBody();
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Jmp, methodDef3));
					methodDefUser.Body.Instructions.Add(new Instruction(OpCodes.Ret));
					globalType.Methods[i] = methodDefUser;
					typeDefUser.Methods.Add(methodDef3);
				}
			}
			foreach (TypeDef typeDef in md.Types)
			{
				int num = 1;
				foreach (FieldDef fieldDef in typeDef.Fields)
				{
					bool flag2 = Assembly.CanRename(fieldDef);
					bool flag3 = flag2;
					bool flag10 = flag3;
					if (flag10)
					{
						num++;
						fieldDef.Name = "Inferno" + num.ToString();
					}
				}
				foreach (EventDef eventDef in typeDef.Events)
				{
					bool flag4 = Assembly.CanRename(eventDef);
					bool flag5 = flag4;
					bool flag11 = flag5;
					if (flag11)
					{
						num++;
						eventDef.Name = "Inferno" + num.ToString();
					}
				}
				foreach (MethodDef methodDef4 in typeDef.Methods)
				{
					bool flag6 = Assembly.CanRename(methodDef4);
					bool flag7 = flag6;
					bool flag12 = flag7;
					if (flag12)
					{
						num++;
						methodDef4.Name = "Inferno" + num.ToString();
					}
					foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef4.Parameters))
					{
						num++;
						parameter.Name = "Inferno" + num.ToString();
					}
					bool hasBody = methodDef4.HasBody;
					bool flag8 = hasBody;
					bool flag13 = flag8;
					if (flag13)
					{
						foreach (Local local in methodDef4.Body.Variables)
						{
							num++;
							local.Name = "Inferno" + num.ToString();
						}
					}
					foreach (GenericParam genericParam in methodDef4.GenericParameters)
					{
						genericParam.Name = ((char)(genericParam.Number + 1)).ToString();
					}
				}
			}
		}

		// Token: 0x0400010F RID: 271
		public static Random random = new Random();
	}
}
