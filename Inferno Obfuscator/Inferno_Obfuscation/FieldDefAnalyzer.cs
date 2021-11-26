using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000031 RID: 49
	public class FieldDefAnalyzer : iAnalyze
	{
		// Token: 0x060000FE RID: 254 RVA: 0x00017668 File Offset: 0x00015868
		public override bool Execute(object context)
		{
			FieldDef field = (FieldDef)context;
			bool isRuntimeSpecialName = field.IsRuntimeSpecialName;
			bool result;
			if (isRuntimeSpecialName)
			{
				result = false;
			}
			else
			{
				bool flag = field.IsLiteral && field.DeclaringType.IsEnum;
				result = !flag;
			}
			return result;
		}
	}
}
