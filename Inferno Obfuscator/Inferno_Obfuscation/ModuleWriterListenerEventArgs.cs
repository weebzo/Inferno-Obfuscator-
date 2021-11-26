using System;
using dnlib.DotNet.Writer;

namespace Inferno_Obfuscation
{
	// Token: 0x02000041 RID: 65
	public class ModuleWriterListenerEventArgs : EventArgs
	{
		// Token: 0x06000144 RID: 324 RVA: 0x0001A852 File Offset: 0x00018A52
		public ModuleWriterListenerEventArgs(ModuleWriterEvent evt)
		{
			this.WriterEvent = evt;
		}

		// Token: 0x17000006 RID: 6
		// (get) Token: 0x06000145 RID: 325 RVA: 0x0001A864 File Offset: 0x00018A64
		// (set) Token: 0x06000146 RID: 326 RVA: 0x0001A86C File Offset: 0x00018A6C
		public ModuleWriterEvent WriterEvent { get; private set; }
	}
}
