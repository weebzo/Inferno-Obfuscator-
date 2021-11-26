using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000030 RID: 48
	public class EventDefAnalyzer : iAnalyze
	{
		// Token: 0x060000FC RID: 252 RVA: 0x00017634 File Offset: 0x00015834
		public override bool Execute(object context)
		{
			EventDef ev = (EventDef)context;
			bool isRuntimeSpecialName = ev.IsRuntimeSpecialName;
			return !isRuntimeSpecialName;
		}
	}
}
