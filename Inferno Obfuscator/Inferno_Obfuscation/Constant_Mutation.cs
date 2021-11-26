using System;
using System.Collections.Generic;
using System.Linq;
using dnlib.DotNet;
using dnlib.DotNet.Emit;

namespace Inferno_Obfuscation
{
	// Token: 0x0200002E RID: 46
	internal class Constant_Mutation
	{
		// Token: 0x060000D8 RID: 216 RVA: 0x000119E4 File Offset: 0x0000FBE4
		public static bool CanObfuscateLDCI4(IList<Instruction> instructions, int i)
		{
			bool flag = instructions[i + 1].GetOperand() != null;
			bool flag2 = flag;
			bool flag8 = flag2;
			if (flag8)
			{
				bool flag3 = instructions[i + 1].Operand.ToString().Contains("bool");
				bool flag4 = flag3;
				bool flag9 = flag4;
				if (flag9)
				{
					return false;
				}
			}
			bool flag5 = instructions[i + 1].OpCode == OpCodes.Newobj;
			bool flag6 = flag5;
			bool flag10 = flag6;
			bool result;
			if (flag10)
			{
				result = false;
			}
			else
			{
				bool flag7 = instructions[i].GetLdcI4Value() == 0 || instructions[i].GetLdcI4Value() == 1;
				result = !flag7;
			}
			return result;
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x00011A9C File Offset: 0x0000FC9C
		public static void Execute(ModuleDef md)
		{
			foreach (TypeDef typeDef in md.Types)
			{
				foreach (MethodDef method in typeDef.Methods)
				{
					Constant_Mutation.Mutation(method);
				}
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x00011B28 File Offset: 0x0000FD28
		public static void EmptyType(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				method.Body.Instructions[i].Operand = ldcI4Value - Type.EmptyTypes.Length;
				method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
				method.Body.Instructions.Insert(i + 1, OpCodes.Ldsfld.ToInstruction(method.Module.Import(typeof(Type).GetField("EmptyTypes"))));
				method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldlen));
				method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Add));
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x00011C30 File Offset: 0x0000FE30
		public static void DoubleParse(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				double value = Constant_Mutation.RandomDouble(1.0, 1000.0);
				string text = Convert.ToString(value);
				double num = double.Parse(text);
				int num2 = ldcI4Value - (int)num;
				method.Body.Instructions[i].Operand = num2;
				method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
				method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Ldstr, text));
				method.Body.Instructions.Insert(i + 2, OpCodes.Call.ToInstruction(method.Module.Import(typeof(double).GetMethod("Parse", new Type[]
				{
					typeof(string)
				}))));
				method.Body.Instructions.Insert(i + 3, OpCodes.Conv_I4.ToInstruction());
				method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Add));
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x00011D98 File Offset: 0x0000FF98
		public static void Brs(MethodDef method)
		{
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				Instruction instruction = method.Body.Instructions[i];
				bool flag = instruction.IsLdcI4();
				bool flag2 = flag;
				bool flag3 = flag2;
				if (flag3)
				{
					int ldcI4Value = instruction.GetLdcI4Value();
					instruction.OpCode = OpCodes.Ldc_I4;
					instruction.Operand = ldcI4Value - 1;
					int num = Constant_Mutation.rnd.Next(100, 500);
					int num2 = Constant_Mutation.rnd.Next(1000, 5000);
					method.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(num));
					method.Body.Instructions.Insert(i + 2, Instruction.CreateLdcI4(num2));
					method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Clt));
					method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Conv_I4));
					method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Add));
					i += 5;
				}
			}
		}

		// Token: 0x060000DD RID: 221 RVA: 0x00011ED8 File Offset: 0x000100D8
		public static string RandomString(int length, string chars)
		{
			return new string((from s in Enumerable.Repeat<string>(chars, length)
			select s[Constant_Mutation.rnd.Next(s.Length)]).ToArray<char>());
		}

		// Token: 0x060000DE RID: 222 RVA: 0x00011F20 File Offset: 0x00010120
		private static void Calc(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			bool flag2 = flag;
			bool flag3 = flag2;
			if (flag3)
			{
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				int num = Constant_Mutation.rnd.Next(-100, 10000);
				switch (Constant_Mutation.rnd.Next(1, 4))
				{
				case 1:
					method.Body.Instructions[i].Operand = ldcI4Value - num;
					method.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
					method.Body.Instructions.Insert(i + 2, OpCodes.Add.ToInstruction());
					i += 2;
					break;
				case 2:
					method.Body.Instructions[i].Operand = ldcI4Value + num;
					method.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
					method.Body.Instructions.Insert(i + 2, OpCodes.Sub.ToInstruction());
					i += 2;
					break;
				case 3:
					method.Body.Instructions[i].Operand = (ldcI4Value ^ num);
					method.Body.Instructions.Insert(i + 1, OpCodes.Ldc_I4.ToInstruction(num));
					method.Body.Instructions.Insert(i + 2, OpCodes.Xor.ToInstruction());
					i += 2;
					break;
				case 4:
				{
					int ldcI4Value2 = method.Body.Instructions[i].GetLdcI4Value();
					method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					method.Body.Instructions[i].Operand = ldcI4Value2 - 1;
					int num2 = Constant_Mutation.rnd.Next(100, 500);
					int num3 = Constant_Mutation.rnd.Next(1000, 5000);
					method.Body.Instructions.Insert(i + 1, Instruction.CreateLdcI4(num2));
					method.Body.Instructions.Insert(i + 2, Instruction.CreateLdcI4(num3));
					method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Clt));
					method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Conv_I4));
					method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Add));
					i += 5;
					break;
				}
				}
			}
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0001220C File Offset: 0x0001040C
		private static double RandomDouble(double min, double max)
		{
			return new Random().NextDouble() * (max - min) + min;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x00012230 File Offset: 0x00010430
		public static void Abs(MethodDef method, ref int index)
		{
			IList<Instruction> instructions = method.Body.Instructions;
			int num = index + 1;
			index = num;
			instructions.Insert(num, new Instruction(OpCodes.Call, method.Module.Import(typeof(Math).GetMethod("Abs", new Type[]
			{
				typeof(int)
			}))));
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x00012298 File Offset: 0x00010498
		public static void MutationVirt(MethodDef method)
		{
			bool flag = !method.HasBody;
			bool flag2 = !flag;
			bool flag5 = flag2;
			if (flag5)
			{
				for (int i = 0; i < method.Body.Instructions.Count; i++)
				{
					bool flag3 = method.Body.Instructions[i].IsLdcI4();
					bool flag4 = flag3;
					bool flag6 = flag4;
					if (flag6)
					{
						Constant_Mutation.Abs(method, ref i);
					}
				}
			}
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x00012310 File Offset: 0x00010510
		public static void Mutation(MethodDef method)
		{
			bool flag = !method.HasBody;
			bool flag2 = !flag;
			bool flag5 = flag2;
			if (flag5)
			{
				for (int i = 0; i < method.Body.Instructions.Count; i++)
				{
					bool flag3 = method.Body.Instructions[i].IsLdcI4();
					bool flag4 = flag3;
					bool flag6 = flag4;
					if (flag6)
					{
						Constant_Mutation.FloorReplacer(method, method.Body.Instructions[i], ref i);
						Constant_Mutation.EmptyType(method, ref i);
						Constant_Mutation.DoubleParse(method, ref i);
						Constant_Mutation.RoundReplacer(method, method.Body.Instructions[i], ref i);
					}
				}
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000123CC File Offset: 0x000105CC
		public static void Varible(MethodDef method, ref int index)
		{
			int ldcI4Value = method.Body.Instructions[index].GetLdcI4Value();
			Local local = new Local(method.Module.CorLibTypes.Int32);
			method.Body.Variables.Add(local);
			method.Body.Instructions.Insert(0, new Instruction(OpCodes.Stloc, local));
			method.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4, ldcI4Value));
			index += 2;
			method.Body.Instructions[index] = new Instruction(OpCodes.Ldloc, local);
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00012480 File Offset: 0x00010680
		public static void Execute(MethodDef method, ref int index)
		{
			bool flag = method.Body.Instructions[index].OpCode != OpCodes.Call;
			bool flag2 = flag;
			bool flag6 = flag2;
			if (flag6)
			{
				int ldcI4Value = method.Body.Instructions[index].GetLdcI4Value();
				Local local = new Local(method.Module.CorLibTypes.Int32);
				Local local2 = new Local(method.Module.CorLibTypes.Int32);
				method.Body.Variables.Add(local);
				method.Body.Variables.Add(local2);
				int num = new Random().Next();
				int num2 = new Random().Next();
				bool flag3 = Convert.ToBoolean(new Random().Next(2));
				bool flag4 = flag3;
				bool flag5 = flag4;
				bool flag7 = flag5;
				int num3;
				if (flag7)
				{
					num3 = num2 - num;
				}
				else
				{
					num3 = new Random().Next();
					while (num3 + num == num2)
					{
						num3 = new Random().Next();
					}
				}
				method.Body.Instructions[index] = Instruction.CreateLdcI4(num);
				IList<Instruction> instructions = method.Body.Instructions;
				int num4 = index + 1;
				index = num4;
				instructions.Insert(num4, new Instruction(OpCodes.Stloc, local));
				IList<Instruction> instructions2 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions2.Insert(num4, Instruction.CreateLdcI4(num3));
				IList<Instruction> instructions3 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions3.Insert(num4, new Instruction(OpCodes.Stloc, local2));
				IList<Instruction> instructions4 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions4.Insert(num4, new Instruction(OpCodes.Ldloc, local));
				IList<Instruction> instructions5 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions5.Insert(num4, new Instruction(OpCodes.Ldloc, local2));
				IList<Instruction> instructions6 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions6.Insert(num4, new Instruction(OpCodes.Add));
				IList<Instruction> instructions7 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions7.Insert(num4, new Instruction(OpCodes.Ldc_I4, num2));
				IList<Instruction> instructions8 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions8.Insert(num4, new Instruction(OpCodes.Ceq));
				Instruction instruction = OpCodes.Nop.ToInstruction();
				IList<Instruction> instructions9 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions9.Insert(num4, new Instruction(flag3 ? OpCodes.Brfalse : OpCodes.Brtrue, instruction));
				IList<Instruction> instructions10 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions10.Insert(num4, new Instruction(OpCodes.Nop));
				IList<Instruction> instructions11 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions11.Insert(num4, new Instruction(OpCodes.Ldc_I4, ldcI4Value));
				IList<Instruction> instructions12 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions12.Insert(num4, new Instruction(OpCodes.Stloc, local));
				IList<Instruction> instructions13 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions13.Insert(num4, new Instruction(OpCodes.Nop));
				Instruction instruction2 = OpCodes.Ldloc_S.ToInstruction(local);
				IList<Instruction> instructions14 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions14.Insert(num4, new Instruction(OpCodes.Br, instruction2));
				IList<Instruction> instructions15 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions15.Insert(num4, instruction);
				IList<Instruction> instructions16 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions16.Insert(num4, new Instruction(OpCodes.Ldc_I4, new Random().Next()));
				IList<Instruction> instructions17 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions17.Insert(num4, new Instruction(OpCodes.Stloc, local));
				IList<Instruction> instructions18 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions18.Insert(num4, new Instruction(OpCodes.Nop));
				IList<Instruction> instructions19 = method.Body.Instructions;
				num4 = index + 1;
				index = num4;
				instructions19.Insert(num4, instruction2);
			}
		}

		// Token: 0x060000E5 RID: 229 RVA: 0x00012924 File Offset: 0x00010B24
		public static void Divsion(MethodDef method, ref int index)
		{
			int ldcI4Value = method.Body.Instructions[index].GetLdcI4Value();
			int num = new Random().Next(1, 5);
			method.Body.Instructions[index].OpCode = OpCodes.Ldc_I4;
			method.Body.Instructions[index].Operand = ldcI4Value * num;
			IList<Instruction> instructions = method.Body.Instructions;
			int num2 = index + 1;
			index = num2;
			instructions.Insert(num2, new Instruction(OpCodes.Ldc_I4, num));
			IList<Instruction> instructions2 = method.Body.Instructions;
			num2 = index + 1;
			index = num2;
			instructions2.Insert(num2, new Instruction(OpCodes.Div));
		}

		// Token: 0x060000E6 RID: 230 RVA: 0x000129E8 File Offset: 0x00010BE8
		public static void Process(MethodDef method, ref int index)
		{
			try
			{
				bool flag = method.Body.Instructions[index - 1].IsLdcI4() && method.Body.Instructions[index - 2].IsLdcI4();
				bool flag2 = flag;
				bool flag11 = flag2;
				if (flag11)
				{
					int ldcI4Value = method.Body.Instructions[index - 2].GetLdcI4Value();
					int ldcI4Value2 = method.Body.Instructions[index - 1].GetLdcI4Value();
					bool flag3 = ldcI4Value2 >= 3;
					bool flag4 = flag3;
					bool flag12 = flag4;
					if (flag12)
					{
						Local local = new Local(method.Module.CorLibTypes.Int32);
						method.Body.Variables.Add(local);
						method.Body.Instructions.Insert(0, new Instruction(OpCodes.Stloc, local));
						method.Body.Instructions.Insert(0, new Instruction(OpCodes.Ldc_I4, ldcI4Value));
						index += 2;
						method.Body.Instructions[index - 2].OpCode = OpCodes.Ldloc;
						method.Body.Instructions[index - 2].Operand = local;
						method.Body.Instructions[index - 1].OpCode = OpCodes.Nop;
						method.Body.Instructions[index].OpCode = OpCodes.Nop;
						int num = 0;
						for (int i = ldcI4Value2; i > 0; i >>= 1)
						{
							bool flag5 = (i & 1) == 1;
							bool flag6 = flag5;
							bool flag13 = flag6;
							if (flag13)
							{
								bool flag7 = num != 0;
								bool flag8 = flag7;
								bool flag14 = flag8;
								if (flag14)
								{
									IList<Instruction> instructions = method.Body.Instructions;
									int num2 = index + 1;
									index = num2;
									instructions.Insert(num2, new Instruction(OpCodes.Ldloc, local));
									IList<Instruction> instructions2 = method.Body.Instructions;
									num2 = index + 1;
									index = num2;
									instructions2.Insert(num2, new Instruction(OpCodes.Ldc_I4, num));
									IList<Instruction> instructions3 = method.Body.Instructions;
									num2 = index + 1;
									index = num2;
									instructions3.Insert(num2, new Instruction(OpCodes.Shl));
									IList<Instruction> instructions4 = method.Body.Instructions;
									num2 = index + 1;
									index = num2;
									instructions4.Insert(num2, new Instruction(OpCodes.Add));
								}
							}
							num++;
						}
						bool flag9 = (ldcI4Value2 & 1) == 0;
						bool flag10 = flag9;
						bool flag15 = flag10;
						if (flag15)
						{
							IList<Instruction> instructions5 = method.Body.Instructions;
							int num3 = index + 1;
							index = num3;
							instructions5.Insert(num3, new Instruction(OpCodes.Ldloc, local));
							IList<Instruction> instructions6 = method.Body.Instructions;
							num3 = index + 1;
							index = num3;
							instructions6.Insert(num3, new Instruction(OpCodes.Sub));
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x00012D10 File Offset: 0x00010F10
		public bool Supported(Instruction instr)
		{
			return instr.OpCode == OpCodes.Mul;
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x00012D30 File Offset: 0x00010F30
		public static void StructGenerator(MethodDef method, ref int i)
		{
			bool flag = method.Body.Instructions[i].IsLdcI4();
			bool flag2 = flag;
			bool flag5 = flag2;
			if (flag5)
			{
				ITypeDefOrRef typeDefOrRef = new Importer(method.Module).Import(typeof(ValueType));
				TypeDef structDef = new TypeDefUser(Constant_Mutation.RandomString(Constant_Mutation.rnd.Next(10, 30), "畹畞疲疷疹痲痹痹瘕番畐畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵藴虜蘞虢謊謁abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ01"), typeDefOrRef);
				structDef.ClassLayout = new ClassLayoutUser(1, 0U);
				List<Type> list = new List<Type>();
				int num = Constant_Mutation.rndsizevalues[Constant_Mutation.rnd.Next(0, 6)];
				list.Add(Constant_Mutation.GetType(num));
				list.ForEach(delegate(Type x)
				{
					structDef.Fields.Add(new FieldDefUser(Constant_Mutation.RandomString(Constant_Mutation.rnd.Next(10, 30), "畹畞疲疷疹痲痹痹瘕番畐畞畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵虜蘞虢謊謁abcdefghijlmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"), new FieldSig(new Importer(method.Module).Import(x).ToTypeSig()), FieldAttributes.Public));
				});
				int ldcI4Value = method.Body.Instructions[i].GetLdcI4Value();
				bool flag3 = Constant_Mutation.abc < 25;
				bool flag4 = flag3;
				bool flag6 = flag4;
				if (flag6)
				{
					method.Module.Types.Add(structDef);
					Constant_Mutation.Dick.Add(Constant_Mutation.abc++, new Tuple<TypeDef, int>(structDef, num));
					int num2 = ldcI4Value - num;
					method.Body.Instructions[i].Operand = num2;
					method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, structDef));
					method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
				}
				else
				{
					Tuple<TypeDef, int> tuple;
					Constant_Mutation.Dick.TryGetValue(Constant_Mutation.rnd.Next(1, 24), out tuple);
					int num3 = ldcI4Value - tuple.Item2;
					method.Body.Instructions[i].Operand = num3;
					method.Body.Instructions[i].OpCode = OpCodes.Ldc_I4;
					method.Body.Instructions.Insert(i + 1, Instruction.Create(OpCodes.Sizeof, tuple.Item1));
					method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Add));
				}
			}
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x00013040 File Offset: 0x00011240
		private static Type GetType(int operand)
		{
			bool flag = operand <= 8;
			bool flag7 = flag;
			if (flag7)
			{
				switch (operand)
				{
				case 1:
					switch (Constant_Mutation.rnd.Next(0, 3))
					{
					case 0:
						return typeof(bool);
					case 1:
						return typeof(sbyte);
					case 2:
						return typeof(byte);
					}
					break;
				case 2:
					switch (Constant_Mutation.rnd.Next(0, 3))
					{
					case 0:
						return typeof(short);
					case 1:
						return typeof(ushort);
					case 2:
						return typeof(char);
					}
					break;
				case 3:
					break;
				case 4:
					switch (Constant_Mutation.rnd.Next(0, 3))
					{
					case 0:
						return typeof(int);
					case 1:
						return typeof(float);
					case 2:
						return typeof(uint);
					}
					break;
				default:
				{
					bool flag2 = operand == 8;
					bool flag8 = flag2;
					if (flag8)
					{
						switch (Constant_Mutation.rnd.Next(0, 5))
						{
						case 0:
							return typeof(DateTime);
						case 1:
							return typeof(TimeSpan);
						case 2:
							return typeof(long);
						case 3:
							return typeof(double);
						case 4:
							return typeof(ulong);
						}
					}
					break;
				}
				}
			}
			else
			{
				bool flag3 = operand == 12;
				bool flag9 = flag3;
				if (flag9)
				{
					return typeof(ConsoleKeyInfo);
				}
				bool flag4 = operand == 16;
				bool flag10 = flag4;
				if (flag10)
				{
					int num = Constant_Mutation.rnd.Next(0, 2);
					int num2 = num;
					bool flag5 = num2 == 0;
					bool flag11 = flag5;
					if (flag11)
					{
						return typeof(Guid);
					}
					bool flag6 = num2 == 1;
					bool flag12 = flag6;
					if (flag12)
					{
						return typeof(decimal);
					}
				}
			}
			return null;
		}

		// Token: 0x060000EA RID: 234 RVA: 0x000132C8 File Offset: 0x000114C8
		public static List<Type> CreateTypeList(int size, out int total)
		{
			List<Type> list = new List<Type>();
			int num = 0;
			while (size != 0)
			{
				bool flag = 16 <= size;
				bool flag2 = flag;
				bool flag13 = flag2;
				if (flag13)
				{
					size -= 16;
					num += 16;
					list.Add(Constant_Mutation.GetType(16));
				}
				else
				{
					bool flag3 = 12 <= size;
					bool flag4 = flag3;
					bool flag14 = flag4;
					if (flag14)
					{
						size -= 12;
						num += 12;
						list.Add(Constant_Mutation.GetType(12));
					}
					else
					{
						bool flag5 = 8 <= size;
						bool flag6 = flag5;
						bool flag15 = flag6;
						if (flag15)
						{
							size -= 8;
							num += 8;
							list.Add(Constant_Mutation.GetType(8));
						}
						else
						{
							bool flag7 = 4 <= size;
							bool flag8 = flag7;
							bool flag16 = flag8;
							if (flag16)
							{
								size -= 4;
								num += 4;
								list.Add(Constant_Mutation.GetType(4));
							}
							else
							{
								bool flag9 = 2 <= size;
								bool flag10 = flag9;
								bool flag17 = flag10;
								if (flag17)
								{
									size -= 2;
									num += 2;
									list.Add(Constant_Mutation.GetType(2));
								}
								else
								{
									bool flag11 = 1 <= size;
									bool flag12 = flag11;
									bool flag18 = flag12;
									if (flag18)
									{
										size--;
										num++;
										list.Add(Constant_Mutation.GetType(1));
									}
								}
							}
						}
					}
				}
			}
			total = num;
			return list;
		}

		// Token: 0x060000EB RID: 235 RVA: 0x0001342C File Offset: 0x0001162C
		public static string RandomOrNo()
		{
			string[] array = new string[]
			{
				"CausalityTraceLevel",
				"BitConverter",
				"UnhandledExceptionEventHandler",
				"PinnedBufferMemoryStream",
				"RichTextBoxScrollBars",
				"RichTextBoxSelectionAttribute",
				"RichTextBoxSelectionTypes",
				"RichTextBoxStreamType",
				"RichTextBoxWordPunctuations",
				"RightToLeft",
				"RTLAwareMessageBox",
				"SafeNativeMethods",
				"SaveFileDialog",
				"Screen",
				"ScreenOrientation",
				"ScrollableControl",
				"ScrollBar",
				"ScrollBarRenderer",
				"ScrollBars",
				"ScrollButton",
				"ScrollEventArgs",
				"ScrollEventHandler",
				"ScrollEventType",
				"ScrollOrientation",
				"ScrollProperties",
				"SearchDirectionHint",
				"SearchForVirtualItemEventArgs",
				"SearchForVirtualItemEventHandler",
				"SecurityIDType",
				"SelectedGridItemChangedEventArgs",
				"SelectedGridItemChangedEventHandler",
				"SelectionMode",
				"SelectionRange",
				"SelectionRangeConverter",
				"SendKeys",
				"Shortcut",
				"SizeGripStyle",
				"SortOrder",
				"SpecialFolderEnumConverter",
				"SplitContainer",
				"Splitter",
				"SplitterCancelEventArgs",
				"SplitterCancelEventHandler",
				"SplitterEventArgs",
				"SplitterEventHandler",
				"SplitterPanel",
				"StatusBar",
				"StatusBarDrawItemEventArgs",
				"StatusBarDrawItemEventHandler",
				"StatusBarPanel",
				"StatusBarPanelAutoSize",
				"StatusBarPanelBorderStyle",
				"StatusBarPanelClickEventArgs",
				"StatusBarPanelClickEventHandler",
				"StatusBarPanelStyle",
				"StatusStrip",
				"StringSorter",
				"StringSource",
				"StructFormat",
				"SystemInformation",
				"SystemParameter",
				"TabAlignment",
				"TabAppearance",
				"TabControl",
				"TabControlAction",
				"TabControlCancelEventArgs",
				"TabControlCancelEventHandler",
				"TabControlEventArgs",
				"TabControlEventHandler",
				"TabDrawMode",
				"TableLayoutPanel",
				"TableLayoutControlCollection",
				"TableLayoutPanelCellBorderStyle",
				"TableLayoutPanelCellPosition",
				"TableLayoutPanelCellPositionTypeConverter",
				"TableLayoutPanelGrowStyle",
				"TableLayoutSettings",
				"SizeType",
				"ColumnStyle",
				"RowStyle",
				"TableLayoutStyle",
				"TableLayoutStyleCollection",
				"TableLayoutCellPaintEventArgs",
				"TableLayoutCellPaintEventHandler",
				"TableLayoutColumnStyleCollection",
				"TableLayoutRowStyleCollection",
				"TabPage",
				"TabRenderer",
				"TabSizeMode",
				"TextBox",
				"TextBoxAutoCompleteSourceConverter",
				"TextBoxBase",
				"TextBoxRenderer",
				"TextDataFormat",
				"TextImageRelation",
				"ThreadExceptionDialog",
				"TickStyle",
				"ToolBar",
				"ToolBarAppearance",
				"ToolBarButton",
				"ToolBarButtonClickEventArgs",
				"ToolBarButtonClickEventHandler",
				"ToolBarButtonStyle",
				"ToolBarTextAlign",
				"ToolStrip",
				"CachedItemHdcInfo",
				"MouseHoverTimer",
				"ToolStripSplitStackDragDropHandler",
				"ToolStripArrowRenderEventArgs",
				"ToolStripArrowRenderEventHandler",
				"ToolStripButton",
				"ToolStripComboBox",
				"ToolStripControlHost",
				"ToolStripDropDown",
				"ToolStripDropDownCloseReason",
				"ToolStripDropDownClosedEventArgs",
				"ToolStripDropDownClosedEventHandler",
				"ToolStripDropDownClosingEventArgs",
				"ToolStripDropDownClosingEventHandler",
				"ToolStripDropDownDirection",
				"ToolStripDropDownButton",
				"ToolStripDropDownItem",
				"ToolStripDropDownItemAccessibleObject",
				"ToolStripDropDownMenu",
				"ToolStripDropTargetManager",
				"ToolStripHighContrastRenderer",
				"ToolStripGrip",
				"ToolStripGripDisplayStyle",
				"ToolStripGripRenderEventArgs",
				"ToolStripGripRenderEventHandler",
				"ToolStripGripStyle",
				"ToolStripItem",
				"ToolStripItemImageIndexer",
				"ToolStripItemInternalLayout",
				"ToolStripItemAlignment",
				"ToolStripItemClickedEventArgs",
				"ToolStripItemClickedEventHandler",
				"ToolStripItemCollection",
				"ToolStripItemDisplayStyle",
				"ToolStripItemEventArgs",
				"ToolStripItemEventHandler",
				"ToolStripItemEventType",
				"ToolStripItemImageRenderEventArgs",
				"ToolStripItemImageRenderEventHandler",
				"ToolStripItemImageScaling",
				"ToolStripItemOverflow",
				"ToolStripItemPlacement",
				"ToolStripItemRenderEventArgs",
				"ToolStripItemRenderEventHandler",
				"ToolStripItemStates",
				"ToolStripItemTextRenderEventArgs",
				"ToolStripItemTextRenderEventHandler",
				"ToolStripLabel",
				"ToolStripLayoutStyle",
				"ToolStripManager",
				"ToolStripCustomIComparer",
				"MergeHistory",
				"MergeHistoryItem",
				"ToolStripManagerRenderMode",
				"ToolStripMenuItem",
				"MenuTimer",
				"ToolStripMenuItemInternalLayout",
				"ToolStripOverflow",
				"ToolStripOverflowButton",
				"ToolStripContainer",
				"ToolStripContentPanel",
				"ToolStripPanel",
				"ToolStripPanelCell",
				"ToolStripPanelRenderEventArgs",
				"ToolStripPanelRenderEventHandler",
				"ToolStripContentPanelRenderEventArgs",
				"ToolStripContentPanelRenderEventHandler",
				"ToolStripPanelRow",
				"ToolStripPointType",
				"ToolStripProfessionalRenderer",
				"ToolStripProfessionalLowResolutionRenderer",
				"ToolStripProgressBar",
				"ToolStripRenderer",
				"ToolStripRendererSwitcher",
				"ToolStripRenderEventArgs",
				"ToolStripRenderEventHandler",
				"ToolStripRenderMode",
				"ToolStripScrollButton",
				"ToolStripSeparator",
				"ToolStripSeparatorRenderEventArgs",
				"ToolStripSeparatorRenderEventHandler",
				"ToolStripSettings",
				"ToolStripSettingsManager",
				"ToolStripSplitButton",
				"ToolStripSplitStackLayout",
				"ToolStripStatusLabel",
				"ToolStripStatusLabelBorderSides",
				"ToolStripSystemRenderer",
				"ToolStripTextBox",
				"ToolStripTextDirection",
				"ToolStripLocationCancelEventArgs",
				"ToolStripLocationCancelEventHandler",
				"ToolTip",
				"ToolTipIcon",
				"TrackBar",
				"TrackBarRenderer",
				"TreeNode",
				"TreeNodeMouseClickEventArgs",
				"TreeNodeMouseClickEventHandler",
				"TreeNodeCollection",
				"TreeNodeConverter",
				"TreeNodeMouseHoverEventArgs",
				"TreeNodeMouseHoverEventHandler",
				"TreeNodeStates",
				"TreeView",
				"TreeViewAction",
				"TreeViewCancelEventArgs",
				"TreeViewCancelEventHandler",
				"TreeViewDrawMode",
				"TreeViewEventArgs",
				"TreeViewEventHandler",
				"TreeViewHitTestInfo",
				"TreeViewHitTestLocations",
				"TreeViewImageIndexConverter",
				"TreeViewImageKeyConverter",
				"Triangle",
				"TriangleDirection",
				"TypeValidationEventArgs",
				"TypeValidationEventHandler",
				"UICues",
				"UICuesEventArgs",
				"UICuesEventHandler",
				"UpDownBase",
				"UpDownEventArgs",
				"UpDownEventHandler",
				"UserControl",
				"ValidationConstraints",
				"View",
				"VScrollBar",
				"VScrollProperties",
				"WebBrowser",
				"WebBrowserEncryptionLevel",
				"WebBrowserReadyState",
				"WebBrowserRefreshOption",
				"WebBrowserBase",
				"WebBrowserContainer",
				"WebBrowserDocumentCompletedEventHandler",
				"WebBrowserDocumentCompletedEventArgs",
				"WebBrowserHelper",
				"WebBrowserNavigatedEventHandler",
				"WebBrowserNavigatedEventArgs",
				"WebBrowserNavigatingEventHandler",
				"WebBrowserNavigatingEventArgs",
				"WebBrowserProgressChangedEventHandler",
				"WebBrowserProgressChangedEventArgs",
				"WebBrowserSiteBase",
				"WebBrowserUriTypeConverter",
				"WinCategoryAttribute",
				"WindowsFormsSection",
				"WindowsFormsSynchronizationContext",
				"IntSecurity",
				"WindowsFormsUtils",
				"IComponentEditorPageSite",
				"LayoutSettings",
				"PageSetupDialog",
				"PrintControllerWithStatusDialog",
				"PrintDialog",
				"PrintPreviewControl",
				"PrintPreviewDialog",
				"TextFormatFlags",
				"TextRenderer",
				"WindowsGraphicsWrapper",
				"SRDescriptionAttribute",
				"SRCategoryAttribute",
				"SR",
				"VisualStyleElement",
				"VisualStyleInformation",
				"VisualStyleRenderer",
				"VisualStyleState",
				"ComboBoxState",
				"CheckBoxState",
				"GroupBoxState",
				"HeaderItemState",
				"PushButtonState",
				"RadioButtonState",
				"ScrollBarArrowButtonState",
				"ScrollBarState",
				"ScrollBarSizeBoxState",
				"TabItemState",
				"TextBoxState",
				"ToolBarState",
				"TrackBarThumbState",
				"BackgroundType",
				"BorderType",
				"ImageOrientation",
				"SizingType",
				"FillType",
				"HorizontalAlign",
				"ContentAlignment",
				"VerticalAlignment",
				"OffsetType",
				"IconEffect",
				"TextShadowType",
				"GlyphType",
				"ImageSelectType",
				"TrueSizeScalingType",
				"GlyphFontSizingType",
				"ColorProperty",
				"EnumProperty",
				"FilenameProperty",
				"FontProperty",
				"IntegerProperty",
				"PointProperty",
				"MarginProperty",
				"StringProperty",
				"BooleanProperty",
				"Edges",
				"EdgeStyle",
				"EdgeEffects",
				"TextMetrics",
				"TextMetricsPitchAndFamilyValues",
				"TextMetricsCharacterSet",
				"HitTestOptions",
				"HitTestCode",
				"ThemeSizeType",
				"VisualStyleDocProperty",
				"VisualStyleSystemProperty",
				"ArrayElementGridEntry",
				"CategoryGridEntry",
				"DocComment",
				"DropDownButton",
				"DropDownButtonAdapter",
				"GridEntry",
				"AttributeTypeSorter",
				"GridEntryRecreateChildrenEventHandler",
				"GridEntryRecreateChildrenEventArgs",
				"GridEntryCollection",
				"GridErrorDlg",
				"GridToolTip",
				"HotCommands",
				"ImmutablePropertyDescriptorGridEntry",
				"IRootGridEntry",
				"MergePropertyDescriptor",
				"MultiPropertyDescriptorGridEntry",
				"MultiSelectRootGridEntry",
				"PropertiesTab",
				"PropertyDescriptorGridEntry",
				"PropertyGridCommands",
				"PropertyGridView",
				"SingleSelectRootGridEntry",
				"ComponentEditorForm",
				"ComponentEditorPage",
				"EventsTab",
				"IUIService",
				"IWindowsFormsEditorService",
				"PropertyTab",
				"ToolStripItemDesignerAvailability",
				"ToolStripItemDesignerAvailabilityAttribute",
				"WindowsFormsComponentEditor",
				"BaseCAMarshaler",
				"Com2AboutBoxPropertyDescriptor",
				"Com2ColorConverter",
				"Com2ComponentEditor",
				"Com2DataTypeToManagedDataTypeConverter",
				"Com2Enum",
				"Com2EnumConverter",
				"Com2ExtendedBrowsingHandler",
				"Com2ExtendedTypeConverter",
				"Com2FontConverter",
				"Com2ICategorizePropertiesHandler",
				"Com2IDispatchConverter",
				"Com2IManagedPerPropertyBrowsingHandler",
				"Com2IPerPropertyBrowsingHandler",
				"Com2IProvidePropertyBuilderHandler",
				"Com2IVsPerPropertyBrowsingHandler",
				"Com2PictureConverter",
				"Com2Properties",
				"Com2PropertyBuilderUITypeEditor",
				"Com2PropertyDescriptor",
				"GetAttributesEvent",
				"Com2EventHandler",
				"GetAttributesEventHandler",
				"GetNameItemEvent",
				"GetNameItemEventHandler",
				"DynamicMetaObjectProviderDebugView",
				"ExpressionTreeCallRewriter",
				"ICSharpInvokeOrInvokeMemberBinder",
				"ResetBindException",
				"RuntimeBinder",
				"RuntimeBinderController",
				"RuntimeBinderException",
				"RuntimeBinderInternalCompilerException",
				"SpecialNames",
				"SymbolTable",
				"RuntimeBinderExtensions",
				"NameManager",
				"Name",
				"NameTable",
				"OperatorKind",
				"PredefinedName",
				"PredefinedType",
				"TokenFacts",
				"TokenKind",
				"OutputContext",
				"UNSAFESTATES",
				"CheckedContext",
				"BindingFlag",
				"ExpressionBinder",
				"BinOpKind",
				"BinOpMask",
				"CandidateFunctionMember",
				"ConstValKind",
				"CONSTVAL",
				"ConstValFactory",
				"ConvKind",
				"CONVERTTYPE",
				"BetterType",
				"ListExtensions",
				"CConversions",
				"Operators",
				"UdConvInfo",
				"ArgInfos",
				"BodyType",
				"ConstCastResult",
				"AggCastResult",
				"UnaryOperatorSignatureFindResult",
				"UnaOpKind",
				"UnaOpMask",
				"OpSigFlags",
				"LiftFlags",
				"CheckLvalueKind",
				"BinOpFuncKind",
				"UnaOpFuncKind",
				"ExpressionKind",
				"ExpressionKindExtensions",
				"EXPRExtensions",
				"ExprFactory",
				"EXPRFLAG",
				"FileRecord",
				"FUNDTYPE",
				"GlobalSymbolContext",
				"InputFile",
				"LangCompiler",
				"MemLookFlags",
				"MemberLookup",
				"CMemberLookupResults",
				"mdToken",
				"CorAttributeTargets",
				"MethodKindEnum",
				"MethodTypeInferrer",
				"NameGenerator",
				"CNullable",
				"NullableCallLiftKind",
				"CONSTRESKIND",
				"LambdaParams",
				"TypeOrSimpleNameResolution",
				"InitializerKind",
				"ConstantStringConcatenation",
				"ForeachKind",
				"PREDEFATTR",
				"PREDEFMETH",
				"PREDEFPROP",
				"MethodRequiredEnum",
				"MethodCallingConventionEnum",
				"MethodSignatureEnum",
				"PredefinedMethodInfo",
				"PredefinedPropertyInfo",
				"PredefinedMembers",
				"ACCESSERROR",
				"CSemanticChecker",
				"SubstTypeFlags",
				"SubstContext",
				"CheckConstraintsFlags",
				"TypeBind",
				"UtilityTypeExtensions",
				"SymWithType",
				"MethPropWithType",
				"MethWithType",
				"PropWithType",
				"EventWithType",
				"FieldWithType",
				"MethPropWithInst",
				"MethWithInst",
				"AggregateDeclaration",
				"Declaration",
				"GlobalAttributeDeclaration",
				"ITypeOrNamespace",
				"AggregateSymbol",
				"AssemblyQualifiedNamespaceSymbol",
				"EventSymbol",
				"FieldSymbol",
				"IndexerSymbol",
				"LabelSymbol",
				"LocalVariableSymbol",
				"MethodOrPropertySymbol",
				"MethodSymbol",
				"InterfaceImplementationMethodSymbol",
				"IteratorFinallyMethodSymbol",
				"MiscSymFactory",
				"NamespaceOrAggregateSymbol",
				"NamespaceSymbol",
				"ParentSymbol",
				"PropertySymbol",
				"Scope",
				"KAID",
				"ACCESS",
				"AggKindEnum",
				"ARRAYMETHOD",
				"SpecCons",
				"Symbol",
				"SymbolExtensions",
				"SymFactory",
				"SymFactoryBase",
				"SYMKIND",
				"SynthAggKind",
				"SymbolLoader",
				"AidContainer",
				"BSYMMGR",
				"symbmask_t",
				"SYMTBL",
				"TransparentIdentifierMemberSymbol",
				"TypeParameterSymbol",
				"UnresolvedAggregateSymbol",
				"VariableSymbol",
				"EXPRARRAYINDEX",
				"EXPRARRINIT",
				"EXPRARRAYLENGTH",
				"EXPRASSIGNMENT",
				"EXPRBINOP",
				"EXPRBLOCK",
				"EXPRBOUNDLAMBDA",
				"EXPRCALL",
				"EXPRCAST",
				"EXPRCLASS",
				"EXPRMULTIGET",
				"EXPRMULTI",
				"EXPRCONCAT",
				"EXPRQUESTIONMARK",
				"EXPRCONSTANT",
				"EXPREVENT",
				"EXPR",
				"ExpressionIterator",
				"EXPRFIELD",
				"EXPRFIELDINFO",
				"EXPRHOISTEDLOCALEXPR",
				"EXPRLIST",
				"EXPRLOCAL",
				"EXPRMEMGRP",
				"EXPRMETHODINFO",
				"EXPRFUNCPTR",
				"EXPRNamedArgumentSpecification",
				"EXPRPROP",
				"EXPRPropertyInfo",
				"EXPRRETURN",
				"EXPRSTMT",
				"EXPRWRAP",
				"EXPRTHISPOINTER",
				"EXPRTYPEARGUMENTS",
				"EXPRTYPEOF",
				"EXPRTYPEORNAMESPACE",
				"EXPRUNARYOP",
				"EXPRUNBOUNDLAMBDA",
				"EXPRUSERDEFINEDCONVERSION",
				"EXPRUSERLOGOP",
				"EXPRZEROINIT",
				"ExpressionTreeRewriter",
				"ExprVisitorBase",
				"AggregateType",
				"ArgumentListType",
				"ArrayType",
				"BoundLambdaType",
				"ErrorType",
				"MethodGroupType",
				"NullableType",
				"NullType",
				"OpenTypePlaceholderType",
				"ParameterModifierType",
				"PointerType",
				"PredefinedTypes",
				"PredefinedTypeFacts",
				"CType",
				"TypeArray",
				"TypeFactory",
				"TypeManager",
				"TypeParameterType",
				"KeyPair`2",
				"TypeTable",
				"VoidType",
				"CError",
				"CParameterizedError",
				"CErrorFactory",
				"ErrorFacts",
				"ErrArgKind",
				"ErrArgFlags",
				"SymWithTypeMemo",
				"MethPropWithInstMemo",
				"ErrArg",
				"ErrArgRef",
				"ErrArgRefOnly",
				"ErrArgNoRef",
				"ErrArgIds",
				"ErrArgSymKind",
				"ErrorHandling",
				"IErrorSink",
				"MessageID",
				"UserStringBuilder",
				"CController",
				"<Cons>d__10`1",
				"<Cons>d__11`1",
				"DynamicProperty",
				"DynamicDebugViewEmptyException",
				"<>c__DisplayClass20_0",
				"ExpressionEXPR",
				"ArgumentObject",
				"NameHashKey",
				"<>c__DisplayClass18_0",
				"<>c__DisplayClass18_1",
				"<>c__DisplayClass43_0",
				"<>c__DisplayClass45_0",
				"KnownName",
				"BinOpArgInfo",
				"BinOpSig",
				"BinOpFullSig",
				"ConversionFunc",
				"ExplicitConversion",
				"PfnBindBinOp",
				"PfnBindUnaOp",
				"GroupToArgsBinder",
				"GroupToArgsBinderResult",
				"ImplicitConversion",
				"UnaOpSig",
				"UnaOpFullSig",
				"OPINFO",
				"<ToEnumerable>d__1",
				"CMethodIterator",
				"NewInferenceResult",
				"Dependency",
				"<InterfaceAndBases>d__0",
				"<AllConstraintInterfaces>d__1",
				"<TypeAndBaseClasses>d__2",
				"<TypeAndBaseClassInterfaces>d__3",
				"<AllPossibleInterfaces>d__4",
				"<Children>d__0",
				"Kind",
				"TypeArrayKey",
				"Key",
				"PredefinedTypeInfo",
				"StdTypeVarColl",
				"<>c__DisplayClass71_0",
				"__StaticArrayInitTypeSize=104",
				"__StaticArrayInitTypeSize=169",
				"SNINativeMethodWrapper",
				"QTypes",
				"ProviderEnum",
				"IOType",
				"ConsumerNumber",
				"SqlAsyncCallbackDelegate",
				"ConsumerInfo",
				"SNI_Error",
				"Win32NativeMethods",
				"NativeOledbWrapper",
				"AdalException",
				"ADALNativeWrapper",
				"Sni_Consumer_Info",
				"SNI_ConnWrapper",
				"SNI_Packet_IOType",
				"ConsumerNum",
				"$ArrayType$$$BY08$$CBG",
				"_GUID",
				"SNI_CLIENT_CONSUMER_INFO",
				"IUnknown",
				"__s_GUID",
				"IChapteredRowset",
				"_FILETIME",
				"ProviderNum",
				"ITransactionLocal",
				"SNI_ERROR",
				"$ArrayType$$$BY08G",
				"BOID",
				"ModuleLoadException",
				"ModuleLoadExceptionHandlerException",
				"ModuleUninitializer",
				"LanguageSupport",
				"gcroot<System::String ^>",
				"$ArrayType$$$BY00Q6MPBXXZ",
				"Progress",
				"$ArrayType$$$BY0A@P6AXXZ",
				"$ArrayType$$$BY0A@P6AHXZ",
				"__enative_startup_state",
				"TriBool",
				"ICLRRuntimeHost",
				"ThisModule",
				"_EXCEPTION_POINTERS",
				"Bid",
				"SqlDependencyProcessDispatcher",
				"BidIdentityAttribute",
				"BidMetaTextAttribute",
				"BidMethodAttribute",
				"BidArgumentTypeAttribute",
				"ExtendedClrTypeCode",
				"ITypedGetters",
				"ITypedGettersV3",
				"ITypedSetters",
				"ITypedSettersV3",
				"MetaDataUtilsSmi",
				"SmiConnection",
				"SmiContext",
				"SmiContextFactory",
				"SmiEventSink",
				"SmiEventSink_Default",
				"SmiEventSink_DeferedProcessing",
				"SmiEventStream",
				"SmiExecuteType",
				"SmiGettersStream",
				"SmiLink",
				"SmiMetaData",
				"SmiExtendedMetaData",
				"SmiParameterMetaData",
				"SmiStorageMetaData",
				"SmiQueryMetaData",
				"SmiRecordBuffer",
				"SmiRequestExecutor",
				"SmiSettersStream",
				"SmiStream",
				"SmiXetterAccessMap",
				"SmiXetterTypeCode",
				"SqlContext",
				"SqlDataRecord",
				"SqlPipe",
				"SqlTriggerContext",
				"ValueUtilsSmi",
				"SqlClientWrapperSmiStream",
				"SqlClientWrapperSmiStreamChars",
				"IBinarySerialize",
				"InvalidUdtException",
				"SqlFacetAttribute",
				"DataAccessKind",
				"SystemDataAccessKind",
				"SqlFunctionAttribute",
				"SqlMetaData",
				"SqlMethodAttribute",
				"FieldInfoEx",
				"BinaryOrderedUdtNormalizer",
				"Normalizer",
				"BooleanNormalizer",
				"SByteNormalizer",
				"ByteNormalizer",
				"ShortNormalizer",
				"UShortNormalizer",
				"IntNormalizer",
				"UIntNormalizer",
				"LongNormalizer",
				"ULongNormalizer",
				"FloatNormalizer",
				"DoubleNormalizer",
				"SqlProcedureAttribute",
				"SerializationHelperSql9",
				"Serializer",
				"NormalizedSerializer",
				"BinarySerializeSerializer",
				"DummyStream",
				"SqlTriggerAttribute",
				"SqlUserDefinedAggregateAttribute",
				"SqlUserDefinedTypeAttribute",
				"TriggerAction",
				"MemoryRecordBuffer",
				"SmiPropertySelector",
				"SmiMetaDataPropertyCollection",
				"SmiMetaDataProperty",
				"SmiUniqueKeyProperty",
				"SmiOrderProperty",
				"SmiDefaultFieldsProperty",
				"SmiTypedGetterSetter",
				"SqlRecordBuffer",
				"BaseTreeIterator",
				"DataDocumentXPathNavigator",
				"DataPointer",
				"DataSetMapper",
				"IXmlDataVirtualNode",
				"BaseRegionIterator",
				"RegionIterator",
				"TreeIterator",
				"ElementState",
				"XmlBoundElement",
				"XmlDataDocument",
				"XmlDataImplementation",
				"XPathNodePointer",
				"AcceptRejectRule",
				"InternalDataCollectionBase",
				"TypedDataSetGenerator",
				"StrongTypingException",
				"TypedDataSetGeneratorException",
				"ColumnTypeConverter",
				"CommandBehavior",
				"CommandType",
				"KeyRestrictionBehavior",
				"ConflictOption",
				"ConnectionState",
				"Constraint",
				"ConstraintCollection",
				"ConstraintConverter",
				"ConstraintEnumerator",
				"ForeignKeyConstraintEnumerator",
				"ChildForeignKeyConstraintEnumerator",
				"ParentForeignKeyConstraintEnumerator",
				"DataColumn",
				"AutoIncrementValue",
				"AutoIncrementInt64",
				"AutoIncrementBigInteger",
				"DataColumnChangeEventArgs",
				"DataColumnChangeEventHandler",
				"DataColumnCollection",
				"DataColumnPropertyDescriptor",
				"DataError",
				"DataException",
				"ConstraintException",
				"DeletedRowInaccessibleException",
				"DuplicateNameException",
				"InRowChangingEventException",
				"InvalidConstraintException",
				"MissingPrimaryKeyException",
				"NoNullAllowedException",
				"ReadOnlyException",
				"RowNotInTableException",
				"VersionNotFoundException",
				"ExceptionBuilder",
				"DataKey",
				"DataRelation",
				"DataRelationCollection",
				"DataRelationPropertyDescriptor",
				"DataRow",
				"DataRowBuilder",
				"DataRowAction",
				"DataRowChangeEventArgs",
				"DataRowChangeEventHandler",
				"DataRowCollection",
				"DataRowCreatedEventHandler",
				"DataSetClearEventhandler",
				"DataRowState",
				"DataRowVersion",
				"DataRowView",
				"SerializationFormat",
				"DataSet",
				"DataSetSchemaImporterExtension",
				"DataSetDateTime",
				"DataSysDescriptionAttribute",
				"DataTable",
				"DataTableClearEventArgs",
				"DataTableClearEventHandler",
				"DataTableCollection",
				"DataTableNewRowEventArgs",
				"DataTableNewRowEventHandler",
				"DataTablePropertyDescriptor",
				"DataTableReader",
				"DataTableReaderListener",
				"DataTableTypeConverter",
				"DataView",
				"DataViewListener",
				"DataViewManager",
				"DataViewManagerListItemTypeDescriptor",
				"DataViewRowState",
				"DataViewSetting",
				"DataViewSettingCollection",
				"DBConcurrencyException",
				"DbType",
				"DefaultValueTypeConverter",
				"FillErrorEventArgs",
				"FillErrorEventHandler",
				"AggregateNode",
				"BinaryNode",
				"LikeNode",
				"ConstNode",
				"DataExpression",
				"ExpressionNode",
				"ExpressionParser",
				"Tokens",
				"OperatorInfo",
				"InvalidExpressionException",
				"EvaluateException",
				"SyntaxErrorException",
				"ExprException",
				"FunctionNode",
				"FunctionId",
				"Function",
				"IFilter",
				"LookupNode",
				"NameNode",
				"UnaryNode",
				"ZeroOpNode",
				"ForeignKeyConstraint",
				"IColumnMapping",
				"IColumnMappingCollection",
				"IDataAdapter",
				"IDataParameter",
				"IDataParameterCollection",
				"IDataReader",
				"IDataRecord",
				"IDbCommand",
				"IDbConnection",
				"IDbDataAdapter",
				"IDbDataParameter",
				"IDbTransaction",
				"IsolationLevel",
				"ITableMapping",
				"ITableMappingCollection",
				"LoadOption",
				"MappingType",
				"MergeFailedEventArgs",
				"MergeFailedEventHandler",
				"Merger",
				"MissingMappingAction",
				"MissingSchemaAction",
				"OperationAbortedException",
				"ParameterDirection",
				"PrimaryKeyTypeConverter",
				"PropertyCollection",
				"RBTreeError",
				"TreeAccessMethod",
				"RBTree`1",
				"RecordManager",
				"StatementCompletedEventArgs",
				"StatementCompletedEventHandler",
				"RelatedView",
				"RelationshipConverter",
				"Rule",
				"SchemaSerializationMode",
				"SchemaType",
				"IndexField",
				"Index",
				"Listeners`1",
				"SimpleType",
				"LocalDBAPI",
				"LocalDBInstanceElement",
				"LocalDBInstancesCollection",
				"LocalDBConfigurationSection",
				"SqlDbType",
				"StateChangeEventArgs",
				"StateChangeEventHandler",
				"StatementType",
				"UniqueConstraint",
				"UpdateRowSource",
				"UpdateStatus",
				"XDRSchema",
				"XmlDataLoader",
				"XMLDiffLoader",
				"XmlReadMode",
				"SchemaFormat",
				"XmlTreeGen",
				"NewDiffgramGen",
				"XmlDataTreeWriter",
				"DataTextWriter",
				"DataTextReader",
				"XMLSchema",
				"ConstraintTable",
				"XSDSchema",
				"XmlIgnoreNamespaceReader",
				"XmlToDatasetMap",
				"XmlWriteMode",
				"SqlEventSource",
				"SqlDataSourceEnumerator",
				"SqlGenericUtil",
				"SqlNotificationRequest",
				"INullable",
				"SqlBinary",
				"SqlBoolean",
				"SqlByte",
				"SqlBytesCharsState",
				"SqlBytes",
				"StreamOnSqlBytes",
				"SqlChars",
				"StreamOnSqlChars",
				"SqlStreamChars",
				"SqlDateTime",
				"SqlDecimal",
				"SqlDouble",
				"SqlFileStream",
				"UnicodeString",
				"SecurityQualityOfService",
				"FileFullEaInformation",
				"SqlGuid",
				"SqlInt16",
				"SqlInt32",
				"SqlInt64",
				"SqlMoney",
				"SQLResource",
				"SqlSingle",
				"SqlCompareOptions",
				"SqlString",
				"SqlTypesSchemaImporterExtensionHelper",
				"TypeCharSchemaImporterExtension",
				"TypeNCharSchemaImporterExtension",
				"TypeVarCharSchemaImporterExtension",
				"TypeNVarCharSchemaImporterExtension",
				"TypeTextSchemaImporterExtension",
				"TypeNTextSchemaImporterExtension",
				"TypeVarBinarySchemaImporterExtension",
				"TypeBinarySchemaImporterExtension",
				"TypeVarImageSchemaImporterExtension",
				"TypeDecimalSchemaImporterExtension",
				"TypeNumericSchemaImporterExtension",
				"TypeBigIntSchemaImporterExtension",
				"TypeIntSchemaImporterExtension",
				"TypeSmallIntSchemaImporterExtension",
				"TypeTinyIntSchemaImporterExtension",
				"TypeBitSchemaImporterExtension",
				"TypeFloatSchemaImporterExtension",
				"TypeRealSchemaImporterExtension",
				"TypeDateTimeSchemaImporterExtension",
				"TypeSmallDateTimeSchemaImporterExtension",
				"TypeMoneySchemaImporterExtension",
				"TypeSmallMoneySchemaImporterExtension",
				"TypeUniqueIdentifierSchemaImporterExtension",
				"EComparison",
				"StorageState",
				"SqlTypeException",
				"SqlNullValueException",
				"SqlTruncateException",
				"SqlNotFilledException",
				"SqlAlreadyFilledException",
				"SQLDebug",
				"SqlXml",
				"SqlXmlStreamWrapper",
				"SqlClientEncryptionAlgorithmFactoryList",
				"SqlSymmetricKeyCache",
				"SqlColumnEncryptionKeyStoreProvider",
				"SqlColumnEncryptionCertificateStoreProvider",
				"SqlColumnEncryptionCngProvider",
				"SqlColumnEncryptionCspProvider",
				"SqlAeadAes256CbcHmac256Algorithm",
				"SqlAeadAes256CbcHmac256Factory",
				"SqlAeadAes256CbcHmac256EncryptionKey",
				"SqlAes256CbcAlgorithm",
				"SqlAes256CbcFactory",
				"SqlClientEncryptionAlgorithm",
				"SqlClientEncryptionAlgorithmFactory",
				"SqlClientEncryptionType",
				"SqlClientSymmetricKey",
				"SqlSecurityUtility",
				"SqlQueryMetadataCache",
				"ApplicationIntent",
				"SqlCredential",
				"SqlConnectionPoolKey",
				"AssemblyCache",
				"OnChangeEventHandler",
				"SqlRowsCopiedEventArgs",
				"SqlRowsCopiedEventHandler",
				"SqlBuffer",
				"_ColumnMapping",
				"Row",
				"BulkCopySimpleResultSet",
				"SqlBulkCopy",
				"SqlBulkCopyColumnMapping",
				"SqlBulkCopyColumnMappingCollection",
				"SqlBulkCopyOptions",
				"SqlCachedBuffer",
				"SqlClientFactory",
				"SqlClientMetaDataCollectionNames",
				"SqlClientPermission",
				"SqlClientPermissionAttribute",
				"SqlCommand",
				"SqlCommandBuilder",
				"SqlCommandSet",
				"SqlConnection",
				"SQLDebugging",
				"ISQLDebug",
				"SqlDebugContext",
				"MEMMAP",
				"SqlConnectionFactory",
				"SqlPerformanceCounters",
				"SqlConnectionPoolGroupProviderInfo",
				"SqlConnectionPoolProviderInfo",
				"SqlConnectionString",
				"SqlConnectionStringBuilder",
				"SqlConnectionTimeoutErrorPhase",
				"SqlConnectionInternalSourceType",
				"SqlConnectionTimeoutPhaseDuration",
				"SqlConnectionTimeoutErrorInternal",
				"SqlDataAdapter",
				"SqlDataReader",
				"SqlDataReaderSmi",
				"SqlDelegatedTransaction",
				"SqlDependency",
				"SqlDependencyPerAppDomainDispatcher",
				"SqlNotification",
				"MetaType",
				"TdsDateTime",
				"SqlError",
				"SqlErrorCollection",
				"SqlException",
				"SqlInfoMessageEventArgs",
				"SqlInfoMessageEventHandler",
				"SqlInternalConnection",
				"SqlInternalConnectionSmi",
				"SessionStateRecord",
				"SessionData",
				"SqlInternalConnectionTds",
				"ServerInfo",
				"TransactionState",
				"TransactionType",
				"SqlInternalTransaction",
				"SqlMetaDataFactory",
				"SqlNotificationEventArgs",
				"SqlNotificationInfo",
				"SqlNotificationSource",
				"SqlNotificationType",
				"DataFeed",
				"StreamDataFeed",
				"TextDataFeed",
				"XmlDataFeed",
				"SqlParameter",
				"SqlParameterCollection",
				"SqlReferenceCollection",
				"SqlRowUpdatedEventArgs",
				"SqlRowUpdatedEventHandler",
				"SqlRowUpdatingEventArgs",
				"SqlRowUpdatingEventHandler",
				"SqlSequentialStream",
				"SqlSequentialStreamSmi",
				"System.Diagnostics.DebuggableAttribute",
				"System.Diagnostics",
				"System.Net.WebClient",
				"System",
				"System.Specialized.Protection"
			};
			return array[Constant_Mutation.rnd.Next(array.Length)];
		}

		// Token: 0x060000EC RID: 236 RVA: 0x00016738 File Offset: 0x00014938
		private static void FloorReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				bool flag2 = flag;
				bool flag7 = flag2;
				if (flag7)
				{
					bool flag3 = instruction.IsLdcI4();
					bool flag4 = flag3;
					bool flag8 = flag4;
					if (flag8)
					{
						bool flag5 = instruction.GetLdcI4Value() < int.MaxValue;
						bool flag6 = flag5;
						bool flag9 = flag6;
						if (flag9)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num + Constant_Mutation.RandomDouble(0.01, 0.99);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Floor", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000ED RID: 237 RVA: 0x0001686C File Offset: 0x00014A6C
		public static void IfInliner(MethodDef method)
		{
			Local local = new Local(method.Module.ImportAsTypeSig(typeof(int)));
			method.Body.Variables.Add(local);
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				bool flag = method.Body.Instructions[i].IsLdcI4();
				bool flag2 = flag;
				bool flag5 = flag2;
				if (flag5)
				{
					bool flag3 = Constant_Mutation.CanObfuscateLDCI4(method.Body.Instructions, i);
					bool flag4 = flag3;
					bool flag6 = flag4;
					if (flag6)
					{
						int num = Constant_Mutation.rnd.Next();
						int num2 = Constant_Mutation.rnd.Next();
						int num3 = num ^ num2;
						Instruction instruction = OpCodes.Nop.ToInstruction();
						method.Body.Instructions.Insert(i + 1, OpCodes.Stloc_S.ToInstruction(local));
						method.Body.Instructions.Insert(i + 2, Instruction.Create(OpCodes.Ldc_I4, method.Body.Instructions[i].GetLdcI4Value() - 4));
						method.Body.Instructions.Insert(i + 3, Instruction.Create(OpCodes.Ldc_I4, num3));
						method.Body.Instructions.Insert(i + 4, Instruction.Create(OpCodes.Ldc_I4, num2));
						method.Body.Instructions.Insert(i + 5, Instruction.Create(OpCodes.Xor));
						method.Body.Instructions.Insert(i + 6, Instruction.Create(OpCodes.Ldc_I4, num));
						method.Body.Instructions.Insert(i + 7, Instruction.Create(OpCodes.Bne_Un, instruction));
						method.Body.Instructions.Insert(i + 8, Instruction.Create(OpCodes.Ldc_I4, 2));
						method.Body.Instructions.Insert(i + 9, OpCodes.Stloc_S.ToInstruction(local));
						method.Body.Instructions.Insert(i + 10, Instruction.Create(OpCodes.Sizeof, method.Module.Import(typeof(float))));
						method.Body.Instructions.Insert(i + 11, Instruction.Create(OpCodes.Add));
						method.Body.Instructions.Insert(i + 12, instruction);
						i += 12;
					}
				}
			}
		}

		// Token: 0x060000EE RID: 238 RVA: 0x00016AE8 File Offset: 0x00014CE8
		public static void InlineInteger(MethodDef method)
		{
			Local local = new Local(method.Module.CorLibTypes.String);
			method.Body.Variables.Add(local);
			Local local2 = new Local(method.Module.CorLibTypes.Int32);
			method.Body.Variables.Add(local2);
			for (int i = 0; i < method.Body.Instructions.Count; i++)
			{
				bool flag = method.Body.Instructions[i].IsLdcI4();
				bool flag2 = flag;
				bool flag21 = flag2;
				if (flag21)
				{
					bool flag3 = Constant_Mutation.CanObfuscateLDCI4(method.Body.Instructions, i);
					bool flag4 = flag3;
					bool flag22 = flag4;
					if (flag22)
					{
						bool isGlobalModuleType = method.DeclaringType.IsGlobalModuleType;
						bool flag5 = isGlobalModuleType;
						bool flag23 = flag5;
						if (flag23)
						{
							break;
						}
						bool flag6 = !method.HasBody;
						bool flag7 = flag6;
						bool flag24 = flag7;
						if (flag24)
						{
							break;
						}
						IList<Instruction> instructions = method.Body.Instructions;
						bool flag8 = i - 1 > 0;
						bool flag9 = flag8;
						bool flag25 = flag9;
						if (flag25)
						{
							try
							{
								bool flag10 = instructions[i - 1].OpCode == OpCodes.Callvirt;
								bool flag11 = flag10;
								bool flag26 = flag11;
								if (flag26)
								{
									bool flag12 = instructions[i + 1].OpCode == OpCodes.Call;
									bool flag13 = flag12;
									bool flag27 = flag13;
									if (flag27)
									{
										break;
									}
								}
							}
							catch
							{
							}
						}
						bool flag14 = true;
						int num = Constant_Mutation.rnd.Next(0, 2);
						int num2 = num;
						bool flag15 = num2 != 0;
						bool flag28 = flag15;
						if (flag28)
						{
							bool flag16 = num2 == 1;
							bool flag29 = flag16;
							if (flag29)
							{
								flag14 = false;
							}
						}
						else
						{
							flag14 = true;
						}
						int ldcI4Value = instructions[i].GetLdcI4Value();
						string text = Constant_Mutation.RandomString(5, "畹畞疲疷疹痲痹痹瘕番畐畞畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵蘞虢謊謁");
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local2));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local2));
						bool flag17 = flag14;
						bool flag18 = flag17;
						bool flag30 = flag18;
						if (flag30)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value + 1));
							instructions.Insert(i, Instruction.Create(OpCodes.Ldc_I4, ldcI4Value));
						}
						instructions.Insert(i, Instruction.Create(OpCodes.Call, method.Module.Import(typeof(string).GetMethod("op_Equality", new Type[]
						{
							typeof(string),
							typeof(string)
						}))));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, text));
						instructions.Insert(i, Instruction.Create(OpCodes.Ldloc_S, local));
						instructions.Insert(i, Instruction.Create(OpCodes.Stloc_S, local));
						bool flag19 = flag14;
						bool flag20 = flag19;
						bool flag31 = flag20;
						if (flag31)
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, text));
						}
						else
						{
							instructions.Insert(i, Instruction.Create(OpCodes.Ldstr, Constant_Mutation.RandomString(7, "疷疹痲痹痹瘕番畐畞畵地狱迷惑阿約拉Inferno Obfuscator阿約拉地狱迷惑畵蘞虢謊謁")));
						}
						instructions.Insert(i + 5, Instruction.Create(OpCodes.Brtrue_S, instructions[i + 6]));
						instructions.Insert(i + 7, Instruction.Create(OpCodes.Br_S, instructions[i + 8]));
						instructions.RemoveAt(i + 10);
						i += 10;
					}
				}
			}
		}

		// Token: 0x060000EF RID: 239 RVA: 0x00016E9C File Offset: 0x0001509C
		private static void RoundReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				bool flag2 = flag;
				bool flag7 = flag2;
				if (flag7)
				{
					bool flag3 = instruction.IsLdcI4();
					bool flag4 = flag3;
					bool flag8 = flag4;
					if (flag8)
					{
						bool flag5 = instruction.GetLdcI4Value() < int.MaxValue;
						bool flag6 = flag5;
						bool flag9 = flag6;
						if (flag9)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num + Constant_Mutation.RandomDouble(0.01, 0.5);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Round", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000F0 RID: 240 RVA: 0x00016FD0 File Offset: 0x000151D0
		private static void SqrtReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				bool flag2 = flag;
				bool flag9 = flag2;
				if (flag9)
				{
					bool flag3 = instruction.IsLdcI4();
					bool flag4 = flag3;
					bool flag10 = flag4;
					if (flag10)
					{
						bool flag5 = instruction.GetLdcI4Value() < int.MaxValue;
						bool flag6 = flag5;
						bool flag11 = flag6;
						if (flag11)
						{
							bool flag7 = (int)instruction.Operand > 1;
							bool flag8 = flag7;
							bool flag12 = flag8;
							if (flag12)
							{
								int num = (int)instruction.Operand;
								double num2 = (double)num * (double)num;
								instruction.OpCode = OpCodes.Ldc_R8;
								instruction.Operand = num2;
								method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Sqrt", new Type[]
								{
									typeof(double)
								}))));
								method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
							}
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000F1 RID: 241 RVA: 0x00017110 File Offset: 0x00015310
		private static void CeilingReplacer(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				bool flag2 = flag;
				bool flag7 = flag2;
				if (flag7)
				{
					bool flag3 = instruction.IsLdcI4();
					bool flag4 = flag3;
					bool flag8 = flag4;
					if (flag8)
					{
						bool flag5 = instruction.GetLdcI4Value() < int.MaxValue;
						bool flag6 = flag5;
						bool flag9 = flag6;
						if (flag9)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num - 1.0 + Constant_Mutation.RandomDouble(0.01, 0.99);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Ceiling", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x060000F2 RID: 242 RVA: 0x0001724C File Offset: 0x0001544C
		private static void CeilingReplacer1(MethodDef method, Instruction instruction, ref int i)
		{
			try
			{
				bool flag = instruction.Operand != null;
				bool flag2 = flag;
				bool flag7 = flag2;
				if (flag7)
				{
					bool flag3 = instruction.OpCode == OpCodes.Ldc_R4;
					bool flag4 = flag3;
					bool flag8 = flag4;
					if (flag8)
					{
						bool flag5 = (int)instruction.Operand < int.MaxValue;
						bool flag6 = flag5;
						bool flag9 = flag6;
						if (flag9)
						{
							int num = (int)instruction.Operand;
							double num2 = (double)num - 1.0 + Constant_Mutation.RandomDouble(0.01, 0.99);
							instruction.OpCode = OpCodes.Ldc_R8;
							instruction.Operand = num2;
							method.Body.Instructions.Insert(i + 1, OpCodes.Call.ToInstruction(method.Module.Import(typeof(Math).GetMethod("Ceiling", new Type[]
							{
								typeof(double)
							}))));
							method.Body.Instructions.Insert(i + 2, OpCodes.Conv_I4.ToInstruction());
						}
					}
				}
			}
			catch
			{
			}
		}

		// Token: 0x04000067 RID: 103
		private static Random rnd = new Random();

		// Token: 0x04000068 RID: 104
		public static List<Instruction> instr = new List<Instruction>();

		// Token: 0x04000069 RID: 105
		public static int[] rndsizevalues = new int[]
		{
			9460301,
			3,
			4,
			65535,
			184,
			0
		};

		// Token: 0x0400006A RID: 106
		public static Dictionary<int, Tuple<TypeDef, int>> Dick = new Dictionary<int, Tuple<TypeDef, int>>();

		// Token: 0x0400006B RID: 107
		private static int abc = 0;
	}
}
