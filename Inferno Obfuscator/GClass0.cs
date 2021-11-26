using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

// Token: 0x02000016 RID: 22
public class GClass0 : ICloneable
{
	// Token: 0x06000070 RID: 112 RVA: 0x0000B64B File Offset: 0x0000984B
	public void method_0()
	{
		this.list_0 = new List<Instruction>();
	}

	// Token: 0x06000071 RID: 113 RVA: 0x0000B65C File Offset: 0x0000985C
	public object Clone()
	{
		return base.MemberwiseClone();
	}

	// Token: 0x04000025 RID: 37
	public List<Instruction> list_0;
}
