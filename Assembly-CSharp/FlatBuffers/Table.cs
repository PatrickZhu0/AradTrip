using System;
using System.Text;

namespace FlatBuffers
{
	// Token: 0x02004B4D RID: 19277
	public class Table
	{
		// Token: 0x170027D8 RID: 10200
		// (get) Token: 0x0601C524 RID: 116004 RVA: 0x000281C8 File Offset: 0x000265C8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.bb;
			}
		}

		// Token: 0x0601C525 RID: 116005 RVA: 0x000281D0 File Offset: 0x000265D0
		public int __offset(int vtableOffset)
		{
			int num = this.bb_pos - this.bb.GetInt(this.bb_pos);
			return (int)((vtableOffset >= (int)this.bb.GetShort(num)) ? 0 : this.bb.GetShort(num + vtableOffset));
		}

		// Token: 0x0601C526 RID: 116006 RVA: 0x0002821C File Offset: 0x0002661C
		public static int __offset(int vtableOffset, int offset, ByteBuffer bb)
		{
			int num = bb.Length - offset;
			return (int)bb.GetShort(num + vtableOffset - bb.GetInt(num)) + num;
		}

		// Token: 0x0601C527 RID: 116007 RVA: 0x00028245 File Offset: 0x00026645
		public int __indirect(int offset)
		{
			return offset + this.bb.GetInt(offset);
		}

		// Token: 0x0601C528 RID: 116008 RVA: 0x00028255 File Offset: 0x00026655
		public static int __indirect(int offset, ByteBuffer bb)
		{
			return offset + bb.GetInt(offset);
		}

		// Token: 0x0601C529 RID: 116009 RVA: 0x00028260 File Offset: 0x00026660
		public string __string(int offset)
		{
			offset += this.bb.GetInt(offset);
			int @int = this.bb.GetInt(offset);
			int index = offset + 4;
			return Encoding.UTF8.GetString(this.bb.Data, index, @int);
		}

		// Token: 0x0601C52A RID: 116010 RVA: 0x000282A5 File Offset: 0x000266A5
		public int __vector_len(int offset)
		{
			offset += this.bb_pos;
			offset += this.bb.GetInt(offset);
			return this.bb.GetInt(offset);
		}

		// Token: 0x0601C52B RID: 116011 RVA: 0x000282CD File Offset: 0x000266CD
		public int __vector(int offset)
		{
			offset += this.bb_pos;
			return offset + this.bb.GetInt(offset) + 4;
		}

		// Token: 0x0601C52C RID: 116012 RVA: 0x000282EC File Offset: 0x000266EC
		public ArraySegment<byte>? __vector_as_arraysegment(int offset)
		{
			int num = this.__offset(offset);
			if (num == 0)
			{
				return null;
			}
			int offset2 = this.__vector(num);
			int count = this.__vector_len(num);
			return new ArraySegment<byte>?(new ArraySegment<byte>(this.bb.Data, offset2, count));
		}

		// Token: 0x0601C52D RID: 116013 RVA: 0x00028338 File Offset: 0x00026738
		public T __union<T>(int offset) where T : class, IFlatbufferObject, new()
		{
			offset += this.bb_pos;
			T result = Activator.CreateInstance<T>();
			result.__init(offset + this.bb.GetInt(offset), this.bb);
			return result;
		}

		// Token: 0x0601C52E RID: 116014 RVA: 0x00028378 File Offset: 0x00026778
		public static bool __has_identifier(ByteBuffer bb, string ident)
		{
			if (ident.Length != 4)
			{
				throw new ArgumentException("FlatBuffers: file identifier must be length " + 4, "ident");
			}
			for (int i = 0; i < 4; i++)
			{
				if (ident[i] != (char)bb.Get(bb.Position + 4 + i))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0601C52F RID: 116015 RVA: 0x000283E0 File Offset: 0x000267E0
		public static int CompareStrings(int offset_1, int offset_2, ByteBuffer bb)
		{
			offset_1 += bb.GetInt(offset_1);
			offset_2 += bb.GetInt(offset_2);
			int @int = bb.GetInt(offset_1);
			int int2 = bb.GetInt(offset_2);
			int num = offset_1 + 4;
			int num2 = offset_2 + 4;
			int num3 = Math.Min(@int, int2);
			byte[] data = bb.Data;
			for (int i = 0; i < num3; i++)
			{
				if (data[i + num] != data[i + num2])
				{
					return (int)(data[i + num] - data[i + num2]);
				}
			}
			return @int - int2;
		}

		// Token: 0x0601C530 RID: 116016 RVA: 0x0002846C File Offset: 0x0002686C
		public static int CompareStrings(int offset_1, byte[] key, ByteBuffer bb)
		{
			offset_1 += bb.GetInt(offset_1);
			int @int = bb.GetInt(offset_1);
			int num = key.Length;
			int num2 = offset_1 + 4;
			int num3 = Math.Min(@int, num);
			byte[] data = bb.Data;
			for (int i = 0; i < num3; i++)
			{
				if (data[i + num2] != key[i])
				{
					return (int)(data[i + num2] - key[i]);
				}
			}
			return @int - num;
		}

		// Token: 0x040137E3 RID: 79843
		public int bb_pos;

		// Token: 0x040137E4 RID: 79844
		public ByteBuffer bb;
	}
}
