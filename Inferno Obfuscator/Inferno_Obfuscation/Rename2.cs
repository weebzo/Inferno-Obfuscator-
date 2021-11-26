using System;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x0200004A RID: 74
	internal class Rename2
	{
		// Token: 0x06000166 RID: 358 RVA: 0x0001C5E0 File Offset: 0x0001A7E0
		public static bool CanRename(object obj)
		{
			iAnalyze analyze = null;
			bool flag = obj is TypeDef;
			if (flag)
			{
				analyze = new TypeDefAnalyzer();
			}
			else
			{
				bool flag2 = obj is MethodDef;
				if (flag2)
				{
					analyze = new MethodDefAnalyzer();
				}
				else
				{
					bool flag3 = obj is EventDef;
					if (flag3)
					{
						analyze = new EventDefAnalyzer();
					}
					else
					{
						bool flag4 = obj is FieldDef;
						if (flag4)
						{
							analyze = new FieldDefAnalyzer();
						}
					}
				}
			}
			bool flag5 = analyze == null;
			return !flag5 && analyze.Execute(obj);
		}
	}
}
