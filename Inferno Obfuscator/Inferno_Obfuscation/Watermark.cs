using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000058 RID: 88
	internal class Watermark
	{
		// Token: 0x060001D4 RID: 468 RVA: 0x00024E3C File Offset: 0x0002303C
		public static void Execute(ModuleDef module)
		{
			MethodDef source_method = module.GlobalType.FindOrCreateStaticConstructor();
			string value = "阿約拉Protected by Inferno Obfuscator 0.1阿約拉";
			MethodDef item = Watermark.CreateReturnMethodDef(value, source_method);
			module.GlobalType.Methods.Add(item);
		}

		// Token: 0x060001D5 RID: 469 RVA: 0x00024E78 File Offset: 0x00023078
		private static MethodDef CreateReturnMethodDef(string value, MethodDef source_method)
		{
			CorLibTypeSig @string = source_method.Module.CorLibTypes.String;
			MethodDef methodDef = new MethodDefUser("InfernoObfuscator", MethodSig.CreateStatic(@string), MethodImplAttributes.IL, MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static | MethodAttributes.HideBySig)
			{
				Body = new CilBody()
			};
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldstr, value));
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
			return methodDef;
		}
	}
}
