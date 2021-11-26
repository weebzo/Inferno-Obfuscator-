using System;
using System.Collections.Generic;

namespace Inferno_Obfuscation.ProxyV2
{
	// Token: 0x02000063 RID: 99
	public static class EnumerableExtensions
	{
		// Token: 0x06000206 RID: 518 RVA: 0x000292F0 File Offset: 0x000274F0
		public static T Random<T>(this IEnumerable<T> input)
		{
			return EnumerableHelper.Random<T>(input);
		}
	}
}
