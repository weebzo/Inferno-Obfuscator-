using System;
using System.Diagnostics;
using dnlib.DotNet;
using dnlib.DotNet.Writer;

namespace Inferno_Obfuscation
{
	// Token: 0x02000040 RID: 64
	public class ModuleWriterListener : IModuleWriterListener
	{
		// Token: 0x06000140 RID: 320 RVA: 0x0001A78C File Offset: 0x0001898C
		void IModuleWriterListener.OnWriterEvent(ModuleWriterBase writer, ModuleWriterEvent evt)
		{
			bool flag = evt == ModuleWriterEvent.PESectionsCreated;
			if (flag)
			{
				NativeEraser.Erase(writer as NativeModuleWriter, writer.Module as ModuleDefMD);
			}
			bool flag2 = this.OnWriterEvent != null;
			if (flag2)
			{
				this.OnWriterEvent(writer, new ModuleWriterListenerEventArgs(evt));
			}
		}

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000141 RID: 321 RVA: 0x0001A7DC File Offset: 0x000189DC
		// (remove) Token: 0x06000142 RID: 322 RVA: 0x0001A814 File Offset: 0x00018A14
		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		public event EventHandler<ModuleWriterListenerEventArgs> OnWriterEvent;
	}
}
