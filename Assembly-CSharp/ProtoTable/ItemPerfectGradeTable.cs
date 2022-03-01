using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020004B8 RID: 1208
	public class ItemPerfectGradeTable : IFlatbufferObject
	{
		// Token: 0x17000EF5 RID: 3829
		// (get) Token: 0x06003AE8 RID: 15080 RVA: 0x000C5908 File Offset: 0x000C3D08
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06003AE9 RID: 15081 RVA: 0x000C5915 File Offset: 0x000C3D15
		public static ItemPerfectGradeTable GetRootAsItemPerfectGradeTable(ByteBuffer _bb)
		{
			return ItemPerfectGradeTable.GetRootAsItemPerfectGradeTable(_bb, new ItemPerfectGradeTable());
		}

		// Token: 0x06003AEA RID: 15082 RVA: 0x000C5922 File Offset: 0x000C3D22
		public static ItemPerfectGradeTable GetRootAsItemPerfectGradeTable(ByteBuffer _bb, ItemPerfectGradeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x06003AEB RID: 15083 RVA: 0x000C593E File Offset: 0x000C3D3E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x06003AEC RID: 15084 RVA: 0x000C5958 File Offset: 0x000C3D58
		public ItemPerfectGradeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000EF6 RID: 3830
		// (get) Token: 0x06003AED RID: 15085 RVA: 0x000C5964 File Offset: 0x000C3D64
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (148214225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000EF7 RID: 3831
		// (get) Token: 0x06003AEE RID: 15086 RVA: 0x000C59B0 File Offset: 0x000C3DB0
		public int Order
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (148214225 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06003AEF RID: 15087 RVA: 0x000C59F9 File Offset: 0x000C3DF9
		public static Offset<ItemPerfectGradeTable> CreateItemPerfectGradeTable(FlatBufferBuilder builder, int ID = 0, int Order = 0)
		{
			builder.StartObject(2);
			ItemPerfectGradeTable.AddOrder(builder, Order);
			ItemPerfectGradeTable.AddID(builder, ID);
			return ItemPerfectGradeTable.EndItemPerfectGradeTable(builder);
		}

		// Token: 0x06003AF0 RID: 15088 RVA: 0x000C5A16 File Offset: 0x000C3E16
		public static void StartItemPerfectGradeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(2);
		}

		// Token: 0x06003AF1 RID: 15089 RVA: 0x000C5A1F File Offset: 0x000C3E1F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06003AF2 RID: 15090 RVA: 0x000C5A2A File Offset: 0x000C3E2A
		public static void AddOrder(FlatBufferBuilder builder, int Order)
		{
			builder.AddInt(1, Order, 0);
		}

		// Token: 0x06003AF3 RID: 15091 RVA: 0x000C5A38 File Offset: 0x000C3E38
		public static Offset<ItemPerfectGradeTable> EndItemPerfectGradeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ItemPerfectGradeTable>(value);
		}

		// Token: 0x06003AF4 RID: 15092 RVA: 0x000C5A52 File Offset: 0x000C3E52
		public static void FinishItemPerfectGradeTableBuffer(FlatBufferBuilder builder, Offset<ItemPerfectGradeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x0400168F RID: 5775
		private Table __p = new Table();

		// Token: 0x020004B9 RID: 1209
		public enum eCrypt
		{
			// Token: 0x04001691 RID: 5777
			code = 148214225
		}
	}
}
