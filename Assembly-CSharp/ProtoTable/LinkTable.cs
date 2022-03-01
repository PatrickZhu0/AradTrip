using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004DC RID: 1244
	public class LinkTable : IFlatbufferObject
	{
		// Token: 0x1700107B RID: 4219
		// (get) Token: 0x06003EF8 RID: 16120 RVA: 0x000D00BC File Offset: 0x000CE4BC
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003EF9 RID: 16121 RVA: 0x000D00C9 File Offset: 0x000CE4C9
		public static LinkTable GetRootAsLinkTable(ByteBuffer _bb)
		{
			return LinkTable.GetRootAsLinkTable(_bb, new LinkTable());
		}

		// Token: 0x06003EFA RID: 16122 RVA: 0x000D00D6 File Offset: 0x000CE4D6
		public static LinkTable GetRootAsLinkTable(ByteBuffer _bb, LinkTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003EFB RID: 16123 RVA: 0x000D00F2 File Offset: 0x000CE4F2
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003EFC RID: 16124 RVA: 0x000D010C File Offset: 0x000CE50C
		public LinkTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x1700107C RID: 4220
		// (get) Token: 0x06003EFD RID: 16125 RVA: 0x000D0118 File Offset: 0x000CE518
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (110988718 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x1700107D RID: 4221
		// (get) Token: 0x06003EFE RID: 16126 RVA: 0x000D0164 File Offset: 0x000CE564
		public string LinkInfo
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003EFF RID: 16127 RVA: 0x000D01A6 File Offset: 0x000CE5A6
		public ArraySegment<byte>? GetLinkInfoBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06003F00 RID: 16128 RVA: 0x000D01B4 File Offset: 0x000CE5B4
		public static Offset<LinkTable> CreateLinkTable(FlatBufferBuilder builder, int ID = 0, StringOffset LinkInfoOffset = default(StringOffset))
		{
			builder.StartObject(2);
			LinkTable.AddLinkInfo(builder, LinkInfoOffset);
			LinkTable.AddID(builder, ID);
			return LinkTable.EndLinkTable(builder);
		}

		// Token: 0x06003F01 RID: 16129 RVA: 0x000D01D1 File Offset: 0x000CE5D1
		public static void StartLinkTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06003F02 RID: 16130 RVA: 0x000D01DA File Offset: 0x000CE5DA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003F03 RID: 16131 RVA: 0x000D01E5 File Offset: 0x000CE5E5
		public static void AddLinkInfo(FlatBufferBuilder builder, StringOffset LinkInfoOffset)
		{
			builder.AddOffset(1, LinkInfoOffset.Value, 0);
		}

		// Token: 0x06003F04 RID: 16132 RVA: 0x000D01F8 File Offset: 0x000CE5F8
		public static Offset<LinkTable> EndLinkTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<LinkTable>(value);
		}

		// Token: 0x06003F05 RID: 16133 RVA: 0x000D0212 File Offset: 0x000CE612
		public static void FinishLinkTableBuffer(FlatBufferBuilder builder, Offset<LinkTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040017F3 RID: 6131
		private Table __p = new Table();

		// Token: 0x020004DD RID: 1245
		public enum eCrypt
		{
			// Token: 0x040017F5 RID: 6133
			code = 110988718
		}
	}
}
