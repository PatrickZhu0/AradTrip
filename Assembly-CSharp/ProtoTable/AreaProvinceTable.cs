using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002A5 RID: 677
	public class AreaProvinceTable : IFlatbufferObject
	{
		// Token: 0x17000385 RID: 901
		// (get) Token: 0x0600181D RID: 6173 RVA: 0x00072D10 File Offset: 0x00071110
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600181E RID: 6174 RVA: 0x00072D1D File Offset: 0x0007111D
		public static AreaProvinceTable GetRootAsAreaProvinceTable(ByteBuffer _bb)
		{
			return AreaProvinceTable.GetRootAsAreaProvinceTable(_bb, new AreaProvinceTable());
		}

		// Token: 0x0600181F RID: 6175 RVA: 0x00072D2A File Offset: 0x0007112A
		public static AreaProvinceTable GetRootAsAreaProvinceTable(ByteBuffer _bb, AreaProvinceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06001820 RID: 6176 RVA: 0x00072D46 File Offset: 0x00071146
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06001821 RID: 6177 RVA: 0x00072D60 File Offset: 0x00071160
		public AreaProvinceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06001822 RID: 6178 RVA: 0x00072D6C File Offset: 0x0007116C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (704479087 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000387 RID: 903
		// (get) Token: 0x06001823 RID: 6179 RVA: 0x00072DB8 File Offset: 0x000711B8
		public string FirstLetter
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001824 RID: 6180 RVA: 0x00072DFA File Offset: 0x000711FA
		public ArraySegment<byte>? GetFirstLetterBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x06001825 RID: 6181 RVA: 0x00072E08 File Offset: 0x00071208
		public string Name
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06001826 RID: 6182 RVA: 0x00072E4A File Offset: 0x0007124A
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06001827 RID: 6183 RVA: 0x00072E58 File Offset: 0x00071258
		public static Offset<AreaProvinceTable> CreateAreaProvinceTable(FlatBufferBuilder builder, int ID = 0, StringOffset FirstLetterOffset = default(StringOffset), StringOffset NameOffset = default(StringOffset))
		{
			builder.StartObject(3);
			AreaProvinceTable.AddName(builder, NameOffset);
			AreaProvinceTable.AddFirstLetter(builder, FirstLetterOffset);
			AreaProvinceTable.AddID(builder, ID);
			return AreaProvinceTable.EndAreaProvinceTable(builder);
		}

		// Token: 0x06001828 RID: 6184 RVA: 0x00072E7C File Offset: 0x0007127C
		public static void StartAreaProvinceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001829 RID: 6185 RVA: 0x00072E85 File Offset: 0x00071285
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x0600182A RID: 6186 RVA: 0x00072E90 File Offset: 0x00071290
		public static void AddFirstLetter(FlatBufferBuilder builder, StringOffset FirstLetterOffset)
		{
			builder.AddOffset(1, FirstLetterOffset.Value, 0);
		}

		// Token: 0x0600182B RID: 6187 RVA: 0x00072EA1 File Offset: 0x000712A1
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(2, NameOffset.Value, 0);
		}

		// Token: 0x0600182C RID: 6188 RVA: 0x00072EB4 File Offset: 0x000712B4
		public static Offset<AreaProvinceTable> EndAreaProvinceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AreaProvinceTable>(value);
		}

		// Token: 0x0600182D RID: 6189 RVA: 0x00072ECE File Offset: 0x000712CE
		public static void FinishAreaProvinceTableBuffer(FlatBufferBuilder builder, Offset<AreaProvinceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000DF1 RID: 3569
		private Table __p = new Table();

		// Token: 0x020002A6 RID: 678
		public enum eCrypt
		{
			// Token: 0x04000DF3 RID: 3571
			code = 704479087
		}
	}
}
