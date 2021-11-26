using System;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x02000042 RID: 66
	internal class MutateConstants
	{
		// Token: 0x06000147 RID: 327 RVA: 0x0001A878 File Offset: 0x00018A78
		public static double RandomDouble(double min, double max)
		{
			return new Random().NextDouble() * (max - min) + min;
		}

		// Token: 0x06000148 RID: 328 RVA: 0x0001A89C File Offset: 0x00018A9C
		private void Mutate(int i, int sub, int num2, ModuleDef module)
		{
			switch (sub)
			{
			case 1:
				this.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(byte))));
				this.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
				break;
			case 2:
				this.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(byte))));
				this.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(byte))));
				this.body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Add));
				this.body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Add));
				break;
			case 3:
				this.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(int))));
				this.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(byte))));
				this.body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Sub));
				this.body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Add));
				break;
			case 4:
				this.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(int))));
				this.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(byte))));
				this.body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Sub));
				this.body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Add));
				this.body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Mul, module.Import(typeof(int))));
				break;
			case 5:
				this.body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(decimal))));
				this.body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(GCCollectionMode))));
				this.body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Sub));
				this.body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Sizeof, module.Import(typeof(int))));
				this.body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Sub));
				this.body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Add));
				break;
			}
		}

		// Token: 0x04000095 RID: 149
		public CilBody body;

		// Token: 0x04000096 RID: 150
		public static Random rnd = new Random();
	}
}
