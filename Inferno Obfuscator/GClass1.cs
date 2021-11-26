using System;
using System.Collections.Generic;
using dnlib.DotNet.Emit;

// Token: 0x02000017 RID: 23
public class GClass1 : ICloneable
{
	// Token: 0x06000073 RID: 115 RVA: 0x0000B67D File Offset: 0x0000987D
	public void method_0()
	{
		this.list_0 = new List<Instruction>();
		this.list_1 = new List<Instruction>();
		this.instruction_0 = null;
		this.list_2 = new List<Instruction>();
	}

	// Token: 0x06000074 RID: 116 RVA: 0x0000B6A8 File Offset: 0x000098A8
	public object Clone()
	{
		return base.MemberwiseClone();
	}

	// Token: 0x04000026 RID: 38
	public List<Instruction> list_0;

	// Token: 0x04000027 RID: 39
	public List<Instruction> list_1;

	// Token: 0x04000028 RID: 40
	public Instruction instruction_0;

	// Token: 0x04000029 RID: 41
	public List<Instruction> list_2;
}
