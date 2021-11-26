using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

// Token: 0x0200000F RID: 15
internal class Class47
{
	// Token: 0x06000050 RID: 80 RVA: 0x000097A8 File Offset: 0x000079A8
	public MethodDef method_0(TypeDef typeDef_0, object object_0, [Optional] bool bool_0, [Optional] bool bool_1)
	{
		MemberRef memberRef = (MemberRef)object_0;
		MethodDef methodDef = new MethodDefUser(Class42.smethod_1(4), MethodSig.CreateStatic(memberRef.ReturnType), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
		methodDef.Body = new CilBody();
		if (bool_0)
		{
			methodDef.MethodSig.Params.Add(typeDef_0.Module.Import(typeDef_0.ToTypeSig()));
		}
		foreach (TypeSig item in memberRef.MethodSig.Params)
		{
			methodDef.MethodSig.Params.Add(item);
		}
		methodDef.Parameters.UpdateParameterTypes();
		foreach (Parameter parameter in ((IEnumerable<Parameter>)methodDef.Parameters))
		{
			methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg, parameter));
		}
		methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Call, memberRef));
		methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
		return methodDef;
	}

	// Token: 0x06000051 RID: 81 RVA: 0x0000990C File Offset: 0x00007B0C
	public MethodDef method_1(IMethod imethod_0, MethodDef methodDef_0)
	{
		MethodDef methodDef = new MethodDefUser(Class42.smethod_1(4), MethodSig.CreateStatic(methodDef_0.Module.Import(imethod_0.DeclaringType.ToTypeSig())), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
		methodDef.ImplAttributes = MethodImplAttributes.IL;
		methodDef.IsHideBySig = true;
		methodDef.Body = new CilBody();
		for (int i = 0; i < imethod_0.MethodSig.Params.Count; i++)
		{
			methodDef.ParamDefs.Add(new ParamDefUser(Class42.smethod_1(4), (ushort)(i + 1)));
			methodDef.MethodSig.Params.Add(imethod_0.MethodSig.Params[i]);
		}
		methodDef.Parameters.UpdateParameterTypes();
		for (int j = 0; j < methodDef.Parameters.Count; j++)
		{
			Parameter operand = methodDef.Parameters[j];
			methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ldarg, operand));
		}
		methodDef.Body.Instructions.Add(new Instruction(OpCodes.Newobj, imethod_0));
		methodDef.Body.Instructions.Add(new Instruction(OpCodes.Ret));
		return methodDef;
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00009A5C File Offset: 0x00007C5C
	public MethodDef method_2(FieldDef fieldDef_0, MethodDef methodDef_0)
	{
		MethodDef methodDef = new MethodDefUser(Class42.smethod_1(4), MethodSig.CreateStatic(methodDef_0.Module.Import(fieldDef_0.FieldType)), MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static);
		methodDef.Body = new CilBody();
		TypeDef declaringType = methodDef_0.DeclaringType;
		methodDef.MethodSig.Params.Add(methodDef_0.Module.Import(declaringType).ToTypeSig());
		methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
		methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ldfld, fieldDef_0));
		methodDef.Body.Instructions.Add(Instruction.Create(OpCodes.Ret));
		methodDef_0.DeclaringType.Methods.Add(methodDef);
		return methodDef;
	}
}
