using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003ED RID: 1005
	public class EquipHandbookSourceTable : IFlatbufferObject
	{
		// Token: 0x17000AED RID: 2797
		// (get) Token: 0x06002DDC RID: 11740 RVA: 0x000A76F8 File Offset: 0x000A5AF8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002DDD RID: 11741 RVA: 0x000A7705 File Offset: 0x000A5B05
		public static EquipHandbookSourceTable GetRootAsEquipHandbookSourceTable(ByteBuffer _bb)
		{
			return EquipHandbookSourceTable.GetRootAsEquipHandbookSourceTable(_bb, new EquipHandbookSourceTable());
		}

		// Token: 0x06002DDE RID: 11742 RVA: 0x000A7712 File Offset: 0x000A5B12
		public static EquipHandbookSourceTable GetRootAsEquipHandbookSourceTable(ByteBuffer _bb, EquipHandbookSourceTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002DDF RID: 11743 RVA: 0x000A772E File Offset: 0x000A5B2E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002DE0 RID: 11744 RVA: 0x000A7748 File Offset: 0x000A5B48
		public EquipHandbookSourceTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AEE RID: 2798
		// (get) Token: 0x06002DE1 RID: 11745 RVA: 0x000A7754 File Offset: 0x000A5B54
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-716887355 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AEF RID: 2799
		// (get) Token: 0x06002DE2 RID: 11746 RVA: 0x000A77A0 File Offset: 0x000A5BA0
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002DE3 RID: 11747 RVA: 0x000A77E2 File Offset: 0x000A5BE2
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000AF0 RID: 2800
		// (get) Token: 0x06002DE4 RID: 11748 RVA: 0x000A77F0 File Offset: 0x000A5BF0
		public string SuperLink
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002DE5 RID: 11749 RVA: 0x000A7832 File Offset: 0x000A5C32
		public ArraySegment<byte>? GetSuperLinkBytes()
		{
			return this.__p.__vector_as_arraysegment(8);
		}

		// Token: 0x06002DE6 RID: 11750 RVA: 0x000A7840 File Offset: 0x000A5C40
		public static Offset<EquipHandbookSourceTable> CreateEquipHandbookSourceTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), StringOffset SuperLinkOffset = default(StringOffset))
		{
			builder.StartObject(3);
			EquipHandbookSourceTable.AddSuperLink(builder, SuperLinkOffset);
			EquipHandbookSourceTable.AddName(builder, NameOffset);
			EquipHandbookSourceTable.AddID(builder, ID);
			return EquipHandbookSourceTable.EndEquipHandbookSourceTable(builder);
		}

		// Token: 0x06002DE7 RID: 11751 RVA: 0x000A7864 File Offset: 0x000A5C64
		public static void StartEquipHandbookSourceTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002DE8 RID: 11752 RVA: 0x000A786D File Offset: 0x000A5C6D
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002DE9 RID: 11753 RVA: 0x000A7878 File Offset: 0x000A5C78
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002DEA RID: 11754 RVA: 0x000A7889 File Offset: 0x000A5C89
		public static void AddSuperLink(FlatBufferBuilder builder, StringOffset SuperLinkOffset)
		{
			builder.AddOffset(2, SuperLinkOffset.Value, 0);
		}

		// Token: 0x06002DEB RID: 11755 RVA: 0x000A789C File Offset: 0x000A5C9C
		public static Offset<EquipHandbookSourceTable> EndEquipHandbookSourceTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipHandbookSourceTable>(value);
		}

		// Token: 0x06002DEC RID: 11756 RVA: 0x000A78B6 File Offset: 0x000A5CB6
		public static void FinishEquipHandbookSourceTableBuffer(FlatBufferBuilder builder, Offset<EquipHandbookSourceTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400135B RID: 4955
		private Table __p = new Table();

		// Token: 0x020003EE RID: 1006
		public enum eCrypt
		{
			// Token: 0x0400135D RID: 4957
			code = -716887355
		}
	}
}
