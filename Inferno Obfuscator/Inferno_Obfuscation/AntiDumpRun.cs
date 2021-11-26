using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Inferno_Obfuscation
{
	// Token: 0x0200002A RID: 42
	internal class AntiDumpRun
	{
		// Token: 0x060000B6 RID: 182 RVA: 0x0000F421 File Offset: 0x0000D621
		public unsafe static void CopyBlock(void* destination, void* source, uint byteCount)
		{
		}

		// Token: 0x060000B7 RID: 183 RVA: 0x0000F424 File Offset: 0x0000D624
		public unsafe static void InitBlock(void* startAddress, byte value, uint byteCount)
		{
		}

		// Token: 0x060000B8 RID: 184
		[DllImport("kernel32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		internal static extern bool VirtualProtect(IntPtr lpAddress, uint dwSize, [MarshalAs(UnmanagedType.U4)] AntiDumpRun.MemoryProtection flNewProtect, [MarshalAs(UnmanagedType.U4)] out AntiDumpRun.MemoryProtection lpflOldProtect);

		// Token: 0x060000B9 RID: 185 RVA: 0x0000F428 File Offset: 0x0000D628
		private unsafe static void Initialize()
		{
			Module module = typeof(AntiDumpRun).Module;
			byte* bas = (byte*)((void*)Marshal.GetHINSTANCE(module));
			byte* ptr = bas + 60;
			ptr = bas + *(uint*)ptr;
			ptr += 6;
			ushort sectNum = *(ushort*)ptr;
			ptr += 14;
			ushort optSize = *(ushort*)ptr;
			ptr = ptr + 4 + optSize;
			byte* @new = stackalloc byte[(UIntPtr)11];
			bool flag = module.FullyQualifiedName[0] != '<';
			if (flag)
			{
				byte* mdDir = bas + *(uint*)(ptr - 16);
				bool flag2 = *(uint*)(ptr - 120) > 0U;
				AntiDumpRun.MemoryProtection memoryProtection;
				if (flag2)
				{
					byte* importDir = bas + *(uint*)(ptr - 120);
					byte* oftMod = bas + *(uint*)importDir;
					byte* modName = bas + *(uint*)(importDir + 12);
					byte* funcName = bas + *(uint*)oftMod + 2;
					AntiDumpRun.VirtualProtect(new IntPtr((void*)modName), 11U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					*(int*)@new = 1818522734;
					*(int*)(@new + 4) = 1818504812;
					*(short*)(@new + (IntPtr)4 * 2) = 108;
					@new[10] = 0;
					AntiDumpRun.CopyBlock((void*)modName, (void*)@new, 11U);
					AntiDumpRun.VirtualProtect(new IntPtr((void*)funcName), 11U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					*(int*)@new = 1866691662;
					*(int*)(@new + 4) = 1852404846;
					*(short*)(@new + (IntPtr)4 * 2) = 25973;
					@new[10] = 0;
					AntiDumpRun.CopyBlock((void*)funcName, (void*)@new, 11U);
				}
				for (int i = 0; i < (int)sectNum; i++)
				{
					AntiDumpRun.VirtualProtect(new IntPtr((void*)ptr), 8U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					AntiDumpRun.InitBlock((void*)ptr, 0, 8U);
					ptr += 40;
				}
				AntiDumpRun.VirtualProtect(new IntPtr((void*)mdDir), 72U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				byte* mdHdr = bas + *(uint*)(mdDir + 8);
				AntiDumpRun.InitBlock((void*)mdDir, 0, 16U);
				AntiDumpRun.VirtualProtect(new IntPtr((void*)mdHdr), 4U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				*(int*)mdHdr = 0;
				mdHdr += 12;
				mdHdr += *(uint*)mdHdr;
				mdHdr = (mdHdr + 7L & -4L);
				mdHdr += 2;
				ushort numOfStream = (ushort)(*mdHdr);
				mdHdr += 2;
				for (int j = 0; j < (int)numOfStream; j++)
				{
					AntiDumpRun.VirtualProtect(new IntPtr((void*)mdHdr), 8U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					mdHdr += 4;
					mdHdr += 4;
					for (int ii = 0; ii < 8; ii++)
					{
						AntiDumpRun.VirtualProtect(new IntPtr((void*)mdHdr), 4U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
						*mdHdr = 0;
						mdHdr++;
						bool flag3 = *mdHdr == 0;
						if (flag3)
						{
							mdHdr += 3;
							break;
						}
						*mdHdr = 0;
						mdHdr++;
						bool flag4 = *mdHdr == 0;
						if (flag4)
						{
							mdHdr += 2;
							break;
						}
						*mdHdr = 0;
						mdHdr++;
						bool flag5 = *mdHdr == 0;
						if (flag5)
						{
							mdHdr++;
							break;
						}
						*mdHdr = 0;
						mdHdr++;
					}
				}
			}
			else
			{
				uint mdDir2 = *(uint*)(ptr - 16);
				uint importDir2 = *(uint*)(ptr - 120);
				uint[] vAdrs = new uint[(int)sectNum];
				uint[] vSizes = new uint[(int)sectNum];
				uint[] rAdrs = new uint[(int)sectNum];
				AntiDumpRun.MemoryProtection memoryProtection;
				for (int k = 0; k < (int)sectNum; k++)
				{
					AntiDumpRun.VirtualProtect(new IntPtr((void*)ptr), 8U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					Marshal.Copy(new byte[8], 0, (IntPtr)((void*)ptr), 8);
					vAdrs[k] = *(uint*)(ptr + 12);
					vSizes[k] = *(uint*)(ptr + 8);
					rAdrs[k] = *(uint*)(ptr + 20);
					ptr += 40;
				}
				bool flag6 = importDir2 > 0U;
				if (flag6)
				{
					for (int l = 0; l < (int)sectNum; l++)
					{
						bool flag7 = vAdrs[l] <= importDir2 && importDir2 < vAdrs[l] + vSizes[l];
						if (flag7)
						{
							importDir2 = importDir2 - vAdrs[l] + rAdrs[l];
							break;
						}
					}
					byte* importDirPtr = bas + importDir2;
					uint oftMod2 = *(uint*)importDirPtr;
					for (int m = 0; m < (int)sectNum; m++)
					{
						bool flag8 = vAdrs[m] <= oftMod2 && oftMod2 < vAdrs[m] + vSizes[m];
						if (flag8)
						{
							oftMod2 = oftMod2 - vAdrs[m] + rAdrs[m];
							break;
						}
					}
					byte* oftModPtr = bas + oftMod2;
					uint modName2 = *(uint*)(importDirPtr + 12);
					for (int n = 0; n < (int)sectNum; n++)
					{
						bool flag9 = vAdrs[n] <= modName2 && modName2 < vAdrs[n] + vSizes[n];
						if (flag9)
						{
							modName2 = modName2 - vAdrs[n] + rAdrs[n];
							break;
						}
					}
					uint funcName2 = *(uint*)oftModPtr + 2U;
					for (int i2 = 0; i2 < (int)sectNum; i2++)
					{
						bool flag10 = vAdrs[i2] <= funcName2 && funcName2 < vAdrs[i2] + vSizes[i2];
						if (flag10)
						{
							funcName2 = funcName2 - vAdrs[i2] + rAdrs[i2];
							break;
						}
					}
					AntiDumpRun.VirtualProtect(new IntPtr((void*)(bas + modName2)), 11U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					*(int*)@new = 1818522734;
					*(int*)(@new + 4) = 1818504812;
					*(short*)(@new + (IntPtr)4 * 2) = 108;
					@new[10] = 0;
					AntiDumpRun.CopyBlock((void*)(bas + modName2), (void*)@new, 11U);
					AntiDumpRun.VirtualProtect(new IntPtr((void*)(bas + funcName2)), 11U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					*(int*)@new = 1866691662;
					*(int*)(@new + 4) = 1852404846;
					*(short*)(@new + (IntPtr)4 * 2) = 25973;
					@new[10] = 0;
					AntiDumpRun.CopyBlock((void*)(bas + funcName2), (void*)@new, 11U);
				}
				for (int i3 = 0; i3 < (int)sectNum; i3++)
				{
					bool flag11 = vAdrs[i3] <= mdDir2 && mdDir2 < vAdrs[i3] + vSizes[i3];
					if (flag11)
					{
						mdDir2 = mdDir2 - vAdrs[i3] + rAdrs[i3];
						break;
					}
				}
				byte* mdDirPtr = bas + mdDir2;
				AntiDumpRun.VirtualProtect(new IntPtr((void*)mdDirPtr), 72U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				uint mdHdr2 = *(uint*)(mdDirPtr + 8);
				for (int i4 = 0; i4 < (int)sectNum; i4++)
				{
					bool flag12 = vAdrs[i4] <= mdHdr2 && mdHdr2 < vAdrs[i4] + vSizes[i4];
					if (flag12)
					{
						mdHdr2 = mdHdr2 - vAdrs[i4] + rAdrs[i4];
						break;
					}
				}
				AntiDumpRun.InitBlock((void*)mdDirPtr, 0, 16U);
				byte* mdHdrPtr = bas + mdHdr2;
				AntiDumpRun.VirtualProtect(new IntPtr((void*)mdHdrPtr), 4U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
				*(int*)mdHdrPtr = 0;
				mdHdrPtr += 12;
				mdHdrPtr += *(uint*)mdHdrPtr;
				mdHdrPtr = (mdHdrPtr + 7L & -4L);
				mdHdrPtr += 2;
				ushort numOfStream2 = (ushort)(*mdHdrPtr);
				mdHdrPtr += 2;
				for (int i5 = 0; i5 < (int)numOfStream2; i5++)
				{
					AntiDumpRun.VirtualProtect(new IntPtr((void*)mdHdrPtr), 8U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
					mdHdrPtr += 4;
					mdHdrPtr += 4;
					for (int ii2 = 0; ii2 < 8; ii2++)
					{
						AntiDumpRun.VirtualProtect(new IntPtr((void*)mdHdrPtr), 4U, AntiDumpRun.MemoryProtection.ExecuteReadWrite, out memoryProtection);
						*mdHdrPtr = 0;
						mdHdrPtr++;
						bool flag13 = *mdHdrPtr == 0;
						if (flag13)
						{
							mdHdrPtr += 3;
							break;
						}
						*mdHdrPtr = 0;
						mdHdrPtr++;
						bool flag14 = *mdHdrPtr == 0;
						if (flag14)
						{
							mdHdrPtr += 2;
							break;
						}
						*mdHdrPtr = 0;
						mdHdrPtr++;
						bool flag15 = *mdHdrPtr == 0;
						if (flag15)
						{
							mdHdrPtr++;
							break;
						}
						*mdHdrPtr = 0;
						mdHdrPtr++;
					}
				}
			}
		}

		// Token: 0x02000082 RID: 130
		internal enum MemoryProtection
		{
			// Token: 0x04000138 RID: 312
			ExecuteReadWrite = 64
		}
	}
}
