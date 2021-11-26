using System;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000048 RID: 72
	internal class RandomOutlinedMethods : SecureRandoms
	{
		// Token: 0x0600015C RID: 348 RVA: 0x0001C0B8 File Offset: 0x0001A2B8
		public static void Execute(ModuleDef module)
		{
			foreach (TypeDef type in module.Types)
			{
				foreach (MethodDef method in type.Methods.ToArray<MethodDef>())
				{
					MethodDef strings = RandomOutlinedMethods.CreateReturnMethodDef(SecureRandoms.GenerateRandomString(SecureRandoms.Next(50, 70)), method);
					MethodDef ints = RandomOutlinedMethods.CreateReturnMethodDef(SecureRandoms.Next(11111, 999999999), method);
					type.Methods.Add(strings);
					type.Methods.Add(ints);
				}
			}
		}

		// Token: 0x0600015D RID: 349 RVA: 0x0001C178 File Offset: 0x0001A378
		public static MethodDef CreateReturnMethodDef(object value, MethodDef source_method)
		{
			CorLibTypeSig corlib = null;
			bool flag = value is int;
			if (flag)
			{
				corlib = source_method.Module.CorLibTypes.Int32;
			}
			else
			{
				bool flag2 = value is string;
				if (flag2)
				{
					corlib = source_method.Module.CorLibTypes.String;
				}
			}
			MethodDef newMethod = new MethodDefUser(SecureRandoms.GenerateRandomString(50), MethodSig.CreateStatic(corlib), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
			{
				Body = new CilBody()
			};
			bool flag3 = value is int;
			if (flag3)
			{
				newMethod.Body.Instructions.Add(Instruction.Create(OpCodes.Ldc_I4, (int)value));
			}
			else
			{
				bool flag4 = value is string;
				if (flag4)
				{
					newMethod.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, (string)value));
				}
			}
			newMethod.Body.Instructions.Add(new Instruction(OpCodes.Ret));
			return newMethod;
		}
	}
}
