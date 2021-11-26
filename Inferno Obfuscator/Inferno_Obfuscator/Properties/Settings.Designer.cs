using System;
using System.CodeDom.Compiler;
using System.Configuration;
using System.Runtime.CompilerServices;

namespace Inferno_Obfuscator.Properties
{
	// Token: 0x02000027 RID: 39
	[CompilerGenerated]
	[GeneratedCode("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "15.9.0.0")]
	internal sealed partial class Settings : ApplicationSettingsBase
	{
		// Token: 0x17000003 RID: 3
		// (get) Token: 0x060000AF RID: 175 RVA: 0x0000EBF0 File Offset: 0x0000CDF0
		public static Settings Default
		{
			get
			{
				return Settings.defaultInstance;
			}
		}

		// Token: 0x0400005F RID: 95
		private static Settings defaultInstance = (Settings)SettingsBase.Synchronized(new Settings());
	}
}
