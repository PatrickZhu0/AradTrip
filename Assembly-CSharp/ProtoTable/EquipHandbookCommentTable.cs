using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020003E8 RID: 1000
	public class EquipHandbookCommentTable : IFlatbufferObject
	{
		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06002DAD RID: 11693 RVA: 0x000A7104 File Offset: 0x000A5504
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002DAE RID: 11694 RVA: 0x000A7111 File Offset: 0x000A5511
		public static EquipHandbookCommentTable GetRootAsEquipHandbookCommentTable(ByteBuffer _bb)
		{
			return EquipHandbookCommentTable.GetRootAsEquipHandbookCommentTable(_bb, new EquipHandbookCommentTable());
		}

		// Token: 0x06002DAF RID: 11695 RVA: 0x000A711E File Offset: 0x000A551E
		public static EquipHandbookCommentTable GetRootAsEquipHandbookCommentTable(ByteBuffer _bb, EquipHandbookCommentTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002DB0 RID: 11696 RVA: 0x000A713A File Offset: 0x000A553A
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06002DB1 RID: 11697 RVA: 0x000A7154 File Offset: 0x000A5554
		public EquipHandbookCommentTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x06002DB2 RID: 11698 RVA: 0x000A7160 File Offset: 0x000A5560
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-249624373 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06002DB3 RID: 11699 RVA: 0x000A71AC File Offset: 0x000A55AC
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002DB4 RID: 11700 RVA: 0x000A71EE File Offset: 0x000A55EE
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x06002DB5 RID: 11701 RVA: 0x000A71FC File Offset: 0x000A55FC
		public int SortOrder
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-249624373 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x06002DB6 RID: 11702 RVA: 0x000A7248 File Offset: 0x000A5648
		public string Comment
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06002DB7 RID: 11703 RVA: 0x000A728B File Offset: 0x000A568B
		public ArraySegment<byte>? GetCommentBytes()
		{
			return this.__p.__vector_as_arraysegment(10);
		}

		// Token: 0x06002DB8 RID: 11704 RVA: 0x000A729A File Offset: 0x000A569A
		public static Offset<EquipHandbookCommentTable> CreateEquipHandbookCommentTable(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int SortOrder = 0, StringOffset CommentOffset = default(StringOffset))
		{
			builder.StartObject(4);
			EquipHandbookCommentTable.AddComment(builder, CommentOffset);
			EquipHandbookCommentTable.AddSortOrder(builder, SortOrder);
			EquipHandbookCommentTable.AddName(builder, NameOffset);
			EquipHandbookCommentTable.AddID(builder, ID);
			return EquipHandbookCommentTable.EndEquipHandbookCommentTable(builder);
		}

		// Token: 0x06002DB9 RID: 11705 RVA: 0x000A72C6 File Offset: 0x000A56C6
		public static void StartEquipHandbookCommentTable(FlatBufferBuilder builder)
		{
			builder.StartObject(4);
		}

		// Token: 0x06002DBA RID: 11706 RVA: 0x000A72CF File Offset: 0x000A56CF
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002DBB RID: 11707 RVA: 0x000A72DA File Offset: 0x000A56DA
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06002DBC RID: 11708 RVA: 0x000A72EB File Offset: 0x000A56EB
		public static void AddSortOrder(FlatBufferBuilder builder, int SortOrder)
		{
			builder.AddInt(2, SortOrder, 0);
		}

		// Token: 0x06002DBD RID: 11709 RVA: 0x000A72F6 File Offset: 0x000A56F6
		public static void AddComment(FlatBufferBuilder builder, StringOffset CommentOffset)
		{
			builder.AddOffset(3, CommentOffset.Value, 0);
		}

		// Token: 0x06002DBE RID: 11710 RVA: 0x000A7308 File Offset: 0x000A5708
		public static Offset<EquipHandbookCommentTable> EndEquipHandbookCommentTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<EquipHandbookCommentTable>(value);
		}

		// Token: 0x06002DBF RID: 11711 RVA: 0x000A7322 File Offset: 0x000A5722
		public static void FinishEquipHandbookCommentTableBuffer(FlatBufferBuilder builder, Offset<EquipHandbookCommentTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04001352 RID: 4946
		private Table __p = new Table();

		// Token: 0x020003E9 RID: 1001
		public enum eCrypt
		{
			// Token: 0x04001354 RID: 4948
			code = -249624373
		}
	}
}
