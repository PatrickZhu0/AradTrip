using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004B6 RID: 1206
	public class ItemNotifyGetTable : IFlatbufferObject
	{
		// Token: 0x17000EF2 RID: 3826
		// (get) Token: 0x06003AD9 RID: 15065 RVA: 0x000C5790 File Offset: 0x000C3B90
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003ADA RID: 15066 RVA: 0x000C579D File Offset: 0x000C3B9D
		public static ItemNotifyGetTable GetRootAsItemNotifyGetTable(ByteBuffer _bb)
		{
			return ItemNotifyGetTable.GetRootAsItemNotifyGetTable(_bb, new ItemNotifyGetTable());
		}

		// Token: 0x06003ADB RID: 15067 RVA: 0x000C57AA File Offset: 0x000C3BAA
		public static ItemNotifyGetTable GetRootAsItemNotifyGetTable(ByteBuffer _bb, ItemNotifyGetTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003ADC RID: 15068 RVA: 0x000C57C6 File Offset: 0x000C3BC6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003ADD RID: 15069 RVA: 0x000C57E0 File Offset: 0x000C3BE0
		public ItemNotifyGetTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EF3 RID: 3827
		// (get) Token: 0x06003ADE RID: 15070 RVA: 0x000C57EC File Offset: 0x000C3BEC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1258183434 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EF4 RID: 3828
		// (get) Token: 0x06003ADF RID: 15071 RVA: 0x000C5838 File Offset: 0x000C3C38
		public string Desc
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x06003AE0 RID: 15072 RVA: 0x000C587A File Offset: 0x000C3C7A
		public ArraySegment<byte>? GetDescBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x06003AE1 RID: 15073 RVA: 0x000C5888 File Offset: 0x000C3C88
		public static Offset<ItemNotifyGetTable> CreateItemNotifyGetTable(FlatBufferBuilder builder, int ID = 0, StringOffset DescOffset = default(StringOffset))
		{
			builder.StartObject(2);
			ItemNotifyGetTable.AddDesc(builder, DescOffset);
			ItemNotifyGetTable.AddID(builder, ID);
			return ItemNotifyGetTable.EndItemNotifyGetTable(builder);
		}

		// Token: 0x06003AE2 RID: 15074 RVA: 0x000C58A5 File Offset: 0x000C3CA5
		public static void StartItemNotifyGetTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06003AE3 RID: 15075 RVA: 0x000C58AE File Offset: 0x000C3CAE
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003AE4 RID: 15076 RVA: 0x000C58B9 File Offset: 0x000C3CB9
		public static void AddDesc(FlatBufferBuilder builder, StringOffset DescOffset)
		{
			builder.AddOffset(1, DescOffset.Value, 0);
		}

		// Token: 0x06003AE5 RID: 15077 RVA: 0x000C58CC File Offset: 0x000C3CCC
		public static Offset<ItemNotifyGetTable> EndItemNotifyGetTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ItemNotifyGetTable>(value);
		}

		// Token: 0x06003AE6 RID: 15078 RVA: 0x000C58E6 File Offset: 0x000C3CE6
		public static void FinishItemNotifyGetTableBuffer(FlatBufferBuilder builder, Offset<ItemNotifyGetTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400168C RID: 5772
		private Table __p = new Table();

		// Token: 0x020004B7 RID: 1207
		public enum eCrypt
		{
			// Token: 0x0400168E RID: 5774
			code = -1258183434
		}
	}
}
