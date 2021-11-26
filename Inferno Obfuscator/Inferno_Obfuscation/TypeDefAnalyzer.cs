using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000054 RID: 84
	public class TypeDefAnalyzer : iAnalyze
	{
		// Token: 0x0600019C RID: 412 RVA: 0x00022BC0 File Offset: 0x00020DC0
		public override bool Execute(object context)
		{
			TypeDef type = (TypeDef)context;
			bool isRuntimeSpecialName = type.IsRuntimeSpecialName;
			bool result;
			if (isRuntimeSpecialName)
			{
				result = false;
			}
			else
			{
				bool isGlobalModuleType = type.IsGlobalModuleType;
				result = !isGlobalModuleType;
			}
			return result;
		}
	}
}
