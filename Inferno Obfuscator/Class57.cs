using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using dnlib.DotNet.Emit;

// Token: 0x02000014 RID: 20
internal class Class57
{
	// Token: 0x06000062 RID: 98 RVA: 0x0000A439 File Offset: 0x00008639
	public Class57(int int_1)
	{
		this.int_0 = int_1;
	}

	// Token: 0x06000063 RID: 99 RVA: 0x0000A458 File Offset: 0x00008658
	public Instruction[] method_0()
	{
		int num = this.random_0.Next(0, this.int_0);
		List<Instruction> list = new List<Instruction>();
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(this.random_0.Next()));
		list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(this.random_0.Next()));
		for (int i = 0; i < this.int_0; i++)
		{
			list.Add(this.method_2().ToInstruction());
			bool flag = num == i;
			if (flag)
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldarg_0.ToInstruction());
			}
			else
			{
				list.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(this.random_0.Next()));
			}
		}
		list.Add(this.method_2().ToInstruction());
		list.Add(dnlib.DotNet.Emit.OpCodes.Ret.ToInstruction());
		return list.ToArray();
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000A54C File Offset: 0x0000874C
	public int method_1(Instruction[] instruction_0, int int_1, bool bool_0)
	{
		int num = int_1 * this.random_0.Next(1, 12);
		num = (bool_0 ? num : (num + 1));
		int num2 = 0;
		List<Instruction> list = new List<Instruction>();
		while (instruction_0[num2].OpCode != dnlib.DotNet.Emit.OpCodes.Ldarg_0)
		{
			list.Add(instruction_0[num2]);
			num2++;
		}
		list.Add(dnlib.DotNet.Emit.OpCodes.Ret.ToInstruction());
		int value = Class57.smethod_1(list.ToArray(), 0);
		List<Instruction> list2 = new List<Instruction>();
		list2.Add(dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(num));
		for (int i = instruction_0.Length - 2; i > num2 + 2; i -= 2)
		{
			Instruction item = this.method_3(instruction_0[i].OpCode).ToInstruction();
			Instruction item2 = instruction_0[i - 1];
			list2.Add(item2);
			list2.Add(item);
		}
		list2.Add(Instruction.Create(dnlib.DotNet.Emit.OpCodes.Ret));
		int value2 = Class57.smethod_1(list2.ToArray(), 0);
		Instruction instruction = this.method_3(instruction_0[num2 + 1].OpCode).ToInstruction();
		int num3 = Class57.smethod_1(new List<Instruction>
		{
			dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(value2),
			dnlib.DotNet.Emit.OpCodes.Ldc_I4.ToInstruction(value),
			(instruction.OpCode == dnlib.DotNet.Emit.OpCodes.Add) ? dnlib.DotNet.Emit.OpCodes.Sub.ToInstruction() : instruction,
			dnlib.DotNet.Emit.OpCodes.Ret.ToInstruction()
		}.ToArray(), 0);
		bool flag = instruction.OpCode != dnlib.DotNet.Emit.OpCodes.Add;
		int result;
		if (flag)
		{
			result = num3;
		}
		else
		{
			result = num3 * -1;
		}
		return result;
	}

	// Token: 0x06000065 RID: 101 RVA: 0x0000A6FC File Offset: 0x000088FC
	public static System.Reflection.Emit.OpCode smethod_0(dnlib.DotNet.Emit.OpCode opCode_0)
	{
		Code code = opCode_0.Code;
		bool flag = code <= Code.Ldc_I4;
		if (flag)
		{
			bool flag2 = code == Code.Ldarg_0;
			if (flag2)
			{
				return System.Reflection.Emit.OpCodes.Ldarg_0;
			}
			bool flag3 = code == Code.Ldc_I4;
			if (flag3)
			{
				return System.Reflection.Emit.OpCodes.Ldc_I4;
			}
		}
		else
		{
			bool flag4 = code == Code.Ret;
			if (flag4)
			{
				return System.Reflection.Emit.OpCodes.Ret;
			}
			switch (code)
			{
			case Code.Add:
				return System.Reflection.Emit.OpCodes.Add;
			case Code.Sub:
				return System.Reflection.Emit.OpCodes.Sub;
			case Code.Mul:
				return System.Reflection.Emit.OpCodes.Mul;
			case Code.And:
				return System.Reflection.Emit.OpCodes.And;
			case Code.Or:
				return System.Reflection.Emit.OpCodes.Or;
			case Code.Xor:
				return System.Reflection.Emit.OpCodes.Xor;
			}
		}
		throw new NotImplementedException();
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0000A7D8 File Offset: 0x000089D8
	public static int smethod_1(Instruction[] instruction_0, int int_1)
	{
		DynamicMethod dynamicMethod = new DynamicMethod("痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵蘞虢謊謁", typeof(int), null);
		ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
		foreach (Instruction instruction in instruction_0)
		{
			bool flag = instruction.OpCode == dnlib.DotNet.Emit.OpCodes.Ldarg_0;
			if (flag)
			{
				ilgenerator.Emit(System.Reflection.Emit.OpCodes.Ldc_I4, int_1);
			}
			else
			{
				bool flag2 = instruction.Operand != null;
				if (flag2)
				{
					ilgenerator.Emit(Class57.smethod_0(instruction.OpCode), Convert.ToInt32(instruction.Operand));
				}
				else
				{
					ilgenerator.Emit(Class57.smethod_0(instruction.OpCode));
				}
			}
		}
		return ((Class57.Delegate1)dynamicMethod.CreateDelegate(typeof(Class57.Delegate1)))();
	}

	// Token: 0x06000067 RID: 103 RVA: 0x0000A8A8 File Offset: 0x00008AA8
	private dnlib.DotNet.Emit.OpCode method_2()
	{
		dnlib.DotNet.Emit.OpCode result = null;
		switch (this.random_0.Next(0, 3))
		{
		case 0:
			result = dnlib.DotNet.Emit.OpCodes.Add;
			break;
		case 1:
			result = dnlib.DotNet.Emit.OpCodes.Sub;
			break;
		case 2:
			result = dnlib.DotNet.Emit.OpCodes.Xor;
			break;
		}
		return result;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x0000A8FC File Offset: 0x00008AFC
	private dnlib.DotNet.Emit.OpCode method_3(dnlib.DotNet.Emit.OpCode opCode_0)
	{
		Code code = opCode_0.Code;
		bool flag = code == Code.Add;
		dnlib.DotNet.Emit.OpCode result;
		if (flag)
		{
			result = dnlib.DotNet.Emit.OpCodes.Sub;
		}
		else
		{
			bool flag2 = code == Code.Sub;
			if (flag2)
			{
				result = dnlib.DotNet.Emit.OpCodes.Add;
			}
			else
			{
				bool flag3 = code != Code.Xor;
				if (flag3)
				{
					throw new NotImplementedException();
				}
				result = dnlib.DotNet.Emit.OpCodes.Xor;
			}
		}
		return result;
	}

	// Token: 0x0400001F RID: 31
	private int int_0;

	// Token: 0x04000020 RID: 32
	private Random random_0 = new Random();

	// Token: 0x02000073 RID: 115
	// (Invoke) Token: 0x06000232 RID: 562
	private delegate int Delegate1();
}
