using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000047 RID: 71
	public static class ProxyExtension
	{
		// Token: 0x06000158 RID: 344 RVA: 0x0001BA5C File Offset: 0x00019C5C
		public static string GenerateRandomString(int size)
		{
			byte[] array = new byte[4 * size];
			ProxyExtension.csp.GetNonZeroBytes(array);
			StringBuilder stringBuilder = new StringBuilder(size);
			for (int i = 0; i < size; i++)
			{
				stringBuilder.Append(ProxyExtension.chars[(int)((IntPtr)(checked((long)(unchecked((ulong)BitConverter.ToUInt32(array, i * 4) % (ulong)((long)ProxyExtension.chars.Length))))))]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000159 RID: 345 RVA: 0x0001BAD0 File Offset: 0x00019CD0
		public static MethodDef CloneSignature(MethodDef from, MethodDef to)
		{
			to.Attributes = from.Attributes;
			bool isHideBySig = from.IsHideBySig;
			bool flag = isHideBySig;
			bool flag3 = flag;
			if (flag3)
			{
				to.IsHideBySig = true;
			}
			bool isStatic = from.IsStatic;
			bool flag2 = isStatic;
			bool flag4 = flag2;
			if (flag4)
			{
				to.IsStatic = true;
			}
			return to;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x0001BB28 File Offset: 0x00019D28
		public static MethodDef CopyMethod(this MethodDef originMethod, ModuleDef mod)
		{
			InjectContext injectContext = new InjectContext(mod, mod);
			Random random = new Random();
			MethodDefUser methodDefUser = new MethodDefUser
			{
				Signature = injectContext.Importer.Import(originMethod.Signature),
				Name = "Inferno_" + Renamer.rnd.Next(1, int.MaxValue).ToString()
			};
			methodDefUser.Parameters.UpdateParameterTypes();
			bool flag = originMethod.ImplMap != null;
			bool flag2 = flag;
			bool flag14 = flag2;
			if (flag14)
			{
				methodDefUser.ImplMap = new ImplMapUser(new ModuleRefUser(injectContext.TargetModule, originMethod.ImplMap.Module.Name), originMethod.ImplMap.Name, originMethod.ImplMap.Attributes);
			}
			foreach (CustomAttribute customAttribute in originMethod.CustomAttributes)
			{
				methodDefUser.CustomAttributes.Add(new CustomAttribute((ICustomAttributeType)injectContext.Importer.Import(customAttribute.Constructor)));
			}
			bool hasBody = originMethod.HasBody;
			bool flag3 = hasBody;
			bool flag15 = flag3;
			if (flag15)
			{
				methodDefUser.Body = new CilBody
				{
					InitLocals = originMethod.Body.InitLocals,
					MaxStack = originMethod.Body.MaxStack
				};
				Dictionary<object, object> bodyMap = new Dictionary<object, object>();
				foreach (Local local in originMethod.Body.Variables)
				{
					Local local2 = new Local(injectContext.Importer.Import(local.Type));
					methodDefUser.Body.Variables.Add(local2);
					local2.Name = local.Name;
					bodyMap[local] = local2;
				}
				foreach (Instruction instruction in originMethod.Body.Instructions)
				{
					Instruction instruction2 = new Instruction(instruction.OpCode, instruction.Operand)
					{
						SequencePoint = instruction.SequencePoint
					};
					bool flag4 = instruction2.Operand is IType;
					bool flag5 = flag4;
					bool flag16 = flag5;
					if (flag16)
					{
						instruction2.Operand = injectContext.Importer.Import((IType)instruction2.Operand);
					}
					else
					{
						bool flag6 = instruction2.Operand is IMethod;
						bool flag7 = flag6;
						bool flag17 = flag7;
						if (flag17)
						{
							instruction2.Operand = injectContext.Importer.Import((IMethod)instruction2.Operand);
						}
						else
						{
							bool flag8 = instruction2.Operand is IField;
							bool flag9 = flag8;
							bool flag18 = flag9;
							if (flag18)
							{
								instruction2.Operand = injectContext.Importer.Import((IField)instruction2.Operand);
							}
						}
					}
					methodDefUser.Body.Instructions.Add(instruction2);
					bodyMap[instruction] = instruction2;
				}
				foreach (Instruction instruction3 in methodDefUser.Body.Instructions)
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
							IEnumerable<Instruction> source = (Instruction[])instruction3.Operand;
						}
					}
				}
				foreach (ExceptionHandler exceptionHandler in originMethod.Body.ExceptionHandlers)
				{
					methodDefUser.Body.ExceptionHandlers.Add(new ExceptionHandler(exceptionHandler.HandlerType)
					{
						TryStart = (Instruction)bodyMap[exceptionHandler.TryStart],
						TryEnd = (Instruction)bodyMap[exceptionHandler.TryEnd],
						HandlerStart = (Instruction)bodyMap[exceptionHandler.HandlerStart],
						HandlerEnd = (Instruction)bodyMap[exceptionHandler.HandlerEnd],
						FilterStart = ((exceptionHandler.FilterStart == null) ? null : ((Instruction)bodyMap[exceptionHandler.FilterStart]))
					});
				}
				methodDefUser.Body.SimplifyMacros(methodDefUser.Parameters);
			}
			return methodDefUser;
		}

		// Token: 0x04000098 RID: 152
		private static readonly RandomNumberGenerator csp = RandomNumberGenerator.Create();

		// Token: 0x04000099 RID: 153
		private static readonly char[] chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵!:;,ù^$*&é\"'(-è_çà)=?./§%¨£µ1234567890°+".ToCharArray();
	}
}
