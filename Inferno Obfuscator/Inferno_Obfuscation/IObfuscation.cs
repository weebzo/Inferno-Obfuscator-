using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000038 RID: 56
	public interface IObfuscation
	{
		// Token: 0x0600011F RID: 287
		void Execute(ModuleDefMD moduleDef);

		// Token: 0x06000120 RID: 288
		bool TryExecute(ModuleDefMD moduleDef);
	}
}
