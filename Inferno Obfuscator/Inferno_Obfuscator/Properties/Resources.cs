using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Inferno_Obfuscator.Properties
{
	// Token: 0x02000026 RID: 38
	[GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
	[DebuggerNonUserCode]
	[CompilerGenerated]
	internal class Resources
	{
		// Token: 0x060000AB RID: 171 RVA: 0x0000EB7E File Offset: 0x0000CD7E
		internal Resources()
		{
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x060000AC RID: 172 RVA: 0x0000EB88 File Offset: 0x0000CD88
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static ResourceManager ResourceManager
		{
			get
			{
				bool flag = Resources.resourceMan == null;
				if (flag)
				{
					ResourceManager temp = new ResourceManager("Inferno_Obfuscator.Properties.Resources", typeof(Resources).Assembly);
					Resources.resourceMan = temp;
				}
				return Resources.resourceMan;
			}
		}

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x060000AD RID: 173 RVA: 0x0000EBD0 File Offset: 0x0000CDD0
		// (set) Token: 0x060000AE RID: 174 RVA: 0x0000EBE7 File Offset: 0x0000CDE7
		[EditorBrowsable(EditorBrowsableState.Advanced)]
		internal static CultureInfo Culture
		{
			get
			{
				return Resources.resourceCulture;
			}
			set
			{
				Resources.resourceCulture = value;
			}
		}

		// Token: 0x0400005D RID: 93
		private static ResourceManager resourceMan;

		// Token: 0x0400005E RID: 94
		private static CultureInfo resourceCulture;
	}
}
