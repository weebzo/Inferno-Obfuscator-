using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x0200003F RID: 63
	public class MethodDefAnalyzer : iAnalyze
	{
		// Token: 0x0600013E RID: 318 RVA: 0x0001A748 File Offset: 0x00018948
		public override bool Execute(object context)
		{
			MethodDef method = (MethodDef)context;
			bool isRuntimeSpecialName = method.IsRuntimeSpecialName;
			bool result;
			if (isRuntimeSpecialName)
			{
				result = false;
			}
			else
			{
				bool isForwarder = method.DeclaringType.IsForwarder;
				result = !isForwarder;
			}
			return result;
		}
	}
}
