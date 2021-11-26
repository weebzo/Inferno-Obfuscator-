using System;
using System.Collections.Generic;
using System.Linq;

namespace Inferno_Obfuscation.ProxyV2
{
	// Token: 0x02000062 RID: 98
	public static class EnumerableHelper
	{
		// Token: 0x06000205 RID: 517 RVA: 0x000292B8 File Offset: 0x000274B8
		public static E Random<E>(IEnumerable<E> input)
		{
			E[] enumerable = (input as E[]) ?? input.ToArray<E>();
			return enumerable.ElementAt(EnumerableHelper.r.Next(enumerable.Length));
		}

		// Token: 0x0400011D RID: 285
		private static readonly Random r = new Random();
	}
}
