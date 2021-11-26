using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000029 RID: 41
	internal class AntiDump
	{
		// Token: 0x060000B4 RID: 180 RVA: 0x0000F304 File Offset: 0x0000D504
		public static void Execute(ModuleDef mod)
		{
			ModuleDefMD typeModule = ModuleDefMD.Load(typeof(AntiDumpRun).Module);
			MethodDef cctor = mod.GlobalType.FindOrCreateStaticConstructor();
			TypeDef typeDef = typeModule.ResolveTypeDef(MDToken.ToRID(typeof(AntiDumpRun).MetadataToken));
			IEnumerable<IDnlibDef> members = InjectHelper.Inject(typeDef, mod.GlobalType, mod);
			MethodDef init = (MethodDef)members.Single((IDnlibDef method) => method.Name == "Initialize");
			cctor.Body.Instructions.Insert(0, Instruction.Create(OpCodes.Call, init));
			foreach (MethodDef md in mod.GlobalType.Methods)
			{
				bool flag = md.Name != ".ctor";
				if (!flag)
				{
					mod.GlobalType.Remove(md);
					break;
				}
			}
		}
	}
}
