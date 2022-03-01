using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x0200038B RID: 907
	public class DropItemVipLimitTable : IFlatbufferObject
	{
		// Token: 0x170008BB RID: 2235
		// (get) Token: 0x06002756 RID: 10070 RVA: 0x000979D8 File Offset: 0x00095DD8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06002757 RID: 10071 RVA: 0x000979E5 File Offset: 0x00095DE5
		public static DropItemVipLimitTable GetRootAsDropItemVipLimitTable(ByteBuffer _bb)
		{
			return DropItemVipLimitTable.GetRootAsDropItemVipLimitTable(_bb, new DropItemVipLimitTable());
		}

		// Token: 0x06002758 RID: 10072 RVA: 0x000979F2 File Offset: 0x00095DF2
		public static DropItemVipLimitTable GetRootAsDropItemVipLimitTable(ByteBuffer _bb, DropItemVipLimitTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06002759 RID: 10073 RVA: 0x00097A0E File Offset: 0x00095E0E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600275A RID: 10074 RVA: 0x00097A28 File Offset: 0x00095E28
		public DropItemVipLimitTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170008BC RID: 2236
		// (get) Token: 0x0600275B RID: 10075 RVA: 0x00097A34 File Offset: 0x00095E34
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (448371292 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170008BD RID: 2237
		// (get) Token: 0x0600275C RID: 10076 RVA: 0x00097A80 File Offset: 0x00095E80
		public string VipLimit
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600275D RID: 10077 RVA: 0x00097AC2 File Offset: 0x00095EC2
		public ArraySegment<byte>? GetVipLimitBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x0600275E RID: 10078 RVA: 0x00097AD0 File Offset: 0x00095ED0
		public static Offset<DropItemVipLimitTable> CreateDropItemVipLimitTable(FlatBufferBuilder builder, int ID = 0, StringOffset VipLimitOffset = default(StringOffset))
		{
			builder.StartObject(2);
			DropItemVipLimitTable.AddVipLimit(builder, VipLimitOffset);
			DropItemVipLimitTable.AddID(builder, ID);
			return DropItemVipLimitTable.EndDropItemVipLimitTable(builder);
		}

		// Token: 0x0600275F RID: 10079 RVA: 0x00097AED File Offset: 0x00095EED
		public static void StartDropItemVipLimitTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06002760 RID: 10080 RVA: 0x00097AF6 File Offset: 0x00095EF6
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002761 RID: 10081 RVA: 0x00097B01 File Offset: 0x00095F01
		public static void AddVipLimit(FlatBufferBuilder builder, StringOffset VipLimitOffset)
		{
			builder.AddOffset(1, VipLimitOffset.Value, 0);
		}

		// Token: 0x06002762 RID: 10082 RVA: 0x00097B14 File Offset: 0x00095F14
		public static Offset<DropItemVipLimitTable> EndDropItemVipLimitTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<DropItemVipLimitTable>(value);
		}

		// Token: 0x06002763 RID: 10083 RVA: 0x00097B2E File Offset: 0x00095F2E
		public static void FinishDropItemVipLimitTableBuffer(FlatBufferBuilder builder, Offset<DropItemVipLimitTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x040011BE RID: 4542
		private Table __p = new Table();

		// Token: 0x0200038C RID: 908
		public enum eCrypt
		{
			// Token: 0x040011C0 RID: 4544
			code = 448371292
		}
	}
}
