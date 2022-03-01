using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004AE RID: 1198
	public class ItemBuffTable : IFlatbufferObject
	{
		// Token: 0x17000ED6 RID: 3798
		// (get) Token: 0x06003A7B RID: 14971 RVA: 0x000C4A7C File Offset: 0x000C2E7C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003A7C RID: 14972 RVA: 0x000C4A89 File Offset: 0x000C2E89
		public static ItemBuffTable GetRootAsItemBuffTable(ByteBuffer _bb)
		{
			return ItemBuffTable.GetRootAsItemBuffTable(_bb, new ItemBuffTable());
		}

		// Token: 0x06003A7D RID: 14973 RVA: 0x000C4A96 File Offset: 0x000C2E96
		public static ItemBuffTable GetRootAsItemBuffTable(ByteBuffer _bb, ItemBuffTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003A7E RID: 14974 RVA: 0x000C4AB2 File Offset: 0x000C2EB2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003A7F RID: 14975 RVA: 0x000C4ACC File Offset: 0x000C2ECC
		public ItemBuffTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000ED7 RID: 3799
		// (get) Token: 0x06003A80 RID: 14976 RVA: 0x000C4AD8 File Offset: 0x000C2ED8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-983801236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000ED8 RID: 3800
		// (get) Token: 0x06003A81 RID: 14977 RVA: 0x000C4B24 File Offset: 0x000C2F24
		public string buffName
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003A82 RID: 14978 RVA: 0x000C4B66 File Offset: 0x000C2F66
		public ArraySegment<byte>? GetBuffNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000ED9 RID: 3801
		// (get) Token: 0x06003A83 RID: 14979 RVA: 0x000C4B74 File Offset: 0x000C2F74
		public int buffId
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-983801236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EDA RID: 3802
		// (get) Token: 0x06003A84 RID: 14980 RVA: 0x000C4BC0 File Offset: 0x000C2FC0
		public int buffMaxLvl
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (-983801236 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003A85 RID: 14981 RVA: 0x000C4C0A File Offset: 0x000C300A
		public static Offset<ItemBuffTable> CreateItemBuffTable(FlatBufferBuilder builder, int ID = 0, StringOffset buffNameOffset = default(StringOffset), int buffId = 0, int buffMaxLvl = 0)
		{
			builder.StartObject(4);
			ItemBuffTable.AddBuffMaxLvl(builder, buffMaxLvl);
			ItemBuffTable.AddBuffId(builder, buffId);
			ItemBuffTable.AddBuffName(builder, buffNameOffset);
			ItemBuffTable.AddID(builder, ID);
			return ItemBuffTable.EndItemBuffTable(builder);
		}

		// Token: 0x06003A86 RID: 14982 RVA: 0x000C4C36 File Offset: 0x000C3036
		public static void StartItemBuffTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06003A87 RID: 14983 RVA: 0x000C4C3F File Offset: 0x000C303F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003A88 RID: 14984 RVA: 0x000C4C4A File Offset: 0x000C304A
		public static void AddBuffName(FlatBufferBuilder builder, StringOffset buffNameOffset)
		{
			builder.AddOffset(1, buffNameOffset.Value, 0);
		}

		// Token: 0x06003A89 RID: 14985 RVA: 0x000C4C5B File Offset: 0x000C305B
		public static void AddBuffId(FlatBufferBuilder builder, int buffId)
		{
			builder.AddInt(2, buffId, 0);
		}

		// Token: 0x06003A8A RID: 14986 RVA: 0x000C4C66 File Offset: 0x000C3066
		public static void AddBuffMaxLvl(FlatBufferBuilder builder, int buffMaxLvl)
		{
			builder.AddInt(3, buffMaxLvl, 0);
		}

		// Token: 0x06003A8B RID: 14987 RVA: 0x000C4C74 File Offset: 0x000C3074
		public static Offset<ItemBuffTable> EndItemBuffTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ItemBuffTable>(value);
		}

		// Token: 0x06003A8C RID: 14988 RVA: 0x000C4C8E File Offset: 0x000C308E
		public static void FinishItemBuffTableBuffer(FlatBufferBuilder builder, Offset<ItemBuffTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001674 RID: 5748
		private Table __p = new Table();

		// Token: 0x020004AF RID: 1199
		public enum eCrypt
		{
			// Token: 0x04001676 RID: 5750
			code = -983801236
		}
	}
}
