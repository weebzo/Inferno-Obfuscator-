using System;
using System.Collections.Generic;
using System.IO;
using dnlib.DotNet;
using dnlib.DotNet.MD;
using dnlib.DotNet.Writer;
using dnlib.IO;
using dnlib.PE;

namespace Inferno_Obfuscation
{
	// Token: 0x02000043 RID: 67
	internal class NativeEraser
	{
		// Token: 0x0600014B RID: 331 RVA: 0x0001AC2D File Offset: 0x00018E2D
		private static void Erase(Tuple<uint, uint, byte[]> section, uint offset, uint len)
		{
			Array.Clear(section.Item3, (int)(offset - section.Item1), (int)len);
		}

		// Token: 0x0600014C RID: 332 RVA: 0x0001AC48 File Offset: 0x00018E48
		private static void Erase(List<Tuple<uint, uint, byte[]>> sections, uint beginOffset, uint size)
		{
			foreach (Tuple<uint, uint, byte[]> sect in sections)
			{
				bool flag = beginOffset >= sect.Item1 && beginOffset + size < sect.Item2;
				if (flag)
				{
					NativeEraser.Erase(sect, beginOffset, size);
					break;
				}
			}
		}

		// Token: 0x0600014D RID: 333 RVA: 0x0001ACBC File Offset: 0x00018EBC
		private static void Erase(List<Tuple<uint, uint, byte[]>> sections, IFileSection s)
		{
			foreach (Tuple<uint, uint, byte[]> sect in sections)
			{
				bool flag = (uint)s.StartOffset >= sect.Item1 && (uint)s.EndOffset < sect.Item2;
				if (flag)
				{
					NativeEraser.Erase(sect, (uint)s.StartOffset, (uint)(s.EndOffset - s.StartOffset));
					break;
				}
			}
		}

		// Token: 0x0600014E RID: 334 RVA: 0x0001AD4C File Offset: 0x00018F4C
		private static void Erase(List<Tuple<uint, uint, byte[]>> sections, uint methodOffset)
		{
			foreach (Tuple<uint, uint, byte[]> sect in sections)
			{
				bool flag = methodOffset >= sect.Item1 && (ulong)(methodOffset - sect.Item1) < (ulong)((long)sect.Item3.Length);
				if (flag)
				{
					uint f = (uint)sect.Item3[(int)(methodOffset - sect.Item1)];
					uint size;
					switch (f & 7U)
					{
					case 2U:
					case 6U:
						size = (f >> 2) + 1U;
						break;
					case 3U:
					{
						f |= (uint)((uint)sect.Item3[(int)(methodOffset - sect.Item1 + 1U)] << 8);
						size = (f >> 12) * 4U;
						uint codeSize = BitConverter.ToUInt32(sect.Item3, (int)(methodOffset - sect.Item1 + 4U));
						size += codeSize;
						break;
					}
					case 4U:
					case 5U:
						goto IL_BD;
					default:
						goto IL_BD;
					}
					NativeEraser.Erase(sect, methodOffset, size);
					continue;
					IL_BD:
					break;
				}
			}
		}

		// Token: 0x0600014F RID: 335 RVA: 0x0001AE50 File Offset: 0x00019050
		public static void Erase(NativeModuleWriter writer, ModuleDefMD module)
		{
			bool flag = writer == null || module == null;
			if (!flag)
			{
				List<Tuple<uint, uint, byte[]>> sections = new List<Tuple<uint, uint, byte[]>>();
				MemoryStream s = new MemoryStream();
				foreach (NativeModuleWriter.OrigSection origSect in writer.OrigSections)
				{
					BinaryReaderChunk oldChunk = origSect.Chunk;
					ImageSectionHeader sectHdr = origSect.PESection;
					s.SetLength(0L);
					oldChunk.WriteTo(new BinaryWriter(s));
					byte[] buf = s.ToArray();
					BinaryReaderChunk newChunk = new BinaryReaderChunk(MemoryImageStream.Create(buf), oldChunk.GetVirtualSize());
					newChunk.SetOffset(oldChunk.FileOffset, oldChunk.RVA);
					origSect.Chunk = newChunk;
					sections.Add(Tuple.Create<uint, uint, byte[]>(sectHdr.PointerToRawData, sectHdr.PointerToRawData + sectHdr.SizeOfRawData, buf));
				}
				IMetaData md = module.MetaData;
				uint row = md.TablesStream.MethodTable.Rows;
				for (uint i = 1U; i <= row; i += 1U)
				{
					RawMethodRow method = md.TablesStream.ReadMethodRow(i);
					MethodImplAttributes codeType = (MethodImplAttributes)(method.ImplFlags & 3);
					bool flag2 = codeType == MethodImplAttributes.IL;
					if (flag2)
					{
						NativeEraser.Erase(sections, (uint)md.PEImage.ToFileOffset((RVA)method.RVA));
					}
				}
				ImageDataDirectory res = md.ImageCor20Header.Resources;
				bool flag3 = res.Size > 0U;
				if (flag3)
				{
					NativeEraser.Erase(sections, (uint)res.StartOffset, res.Size);
				}
				NativeEraser.Erase(sections, md.ImageCor20Header);
				NativeEraser.Erase(sections, md.MetaDataHeader);
				foreach (DotNetStream stream in md.AllStreams)
				{
					NativeEraser.Erase(sections, stream);
				}
			}
		}
	}
}
