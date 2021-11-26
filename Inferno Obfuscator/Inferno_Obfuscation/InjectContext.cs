using System;
using System.Collections.Generic;
using dnlib.DotNet;

namespace Inferno_Obfuscation
{
	// Token: 0x02000034 RID: 52
	public class InjectContext
	{
		// Token: 0x0600010E RID: 270 RVA: 0x00017FFC File Offset: 0x000161FC
		public InjectContext(ModuleDef module, ModuleDef target)
		{
			this.OriginModule = module;
			this.TargetModule = target;
			this.Importerk__BackingField = new Importer(target, ImporterOptions.TryToUseTypeDefs);
		}

		// Token: 0x17000004 RID: 4
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00018030 File Offset: 0x00016230
		public Importer Importer
		{
			get
			{
				return this.Importerk__BackingField;
			}
		}

		// Token: 0x17000005 RID: 5
		// (get) Token: 0x06000110 RID: 272 RVA: 0x00018048 File Offset: 0x00016248
		// (set) Token: 0x06000111 RID: 273 RVA: 0x00018050 File Offset: 0x00016250
		public Importer Importerk__BackingField { get; private set; }

		// Token: 0x0400007C RID: 124
		public readonly Dictionary<IDnlibDef, IDnlibDef> Map = new Dictionary<IDnlibDef, IDnlibDef>();

		// Token: 0x0400007D RID: 125
		public readonly ModuleDef OriginModule;

		// Token: 0x0400007E RID: 126
		public readonly ModuleDef TargetModule;

		// Token: 0x0400007F RID: 127
		private readonly Importer ImporterkBackingField;
	}
}
