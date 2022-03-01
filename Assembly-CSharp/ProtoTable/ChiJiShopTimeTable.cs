using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x02000332 RID: 818
	public class ChiJiShopTimeTable : IFlatbufferObject
	{
		// Token: 0x17000672 RID: 1650
		// (get) Token: 0x060020FB RID: 8443 RVA: 0x00087B90 File Offset: 0x00085F90
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060020FC RID: 8444 RVA: 0x00087B9D File Offset: 0x00085F9D
		public static ChiJiShopTimeTable GetRootAsChiJiShopTimeTable(ByteBuffer _bb)
		{
			return ChiJiShopTimeTable.GetRootAsChiJiShopTimeTable(_bb, new ChiJiShopTimeTable());
		}

		// Token: 0x060020FD RID: 8445 RVA: 0x00087BAA File Offset: 0x00085FAA
		public static ChiJiShopTimeTable GetRootAsChiJiShopTimeTable(ByteBuffer _bb, ChiJiShopTimeTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060020FE RID: 8446 RVA: 0x00087BC6 File Offset: 0x00085FC6
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060020FF RID: 8447 RVA: 0x00087BE0 File Offset: 0x00085FE0
		public ChiJiShopTimeTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x17000673 RID: 1651
		// (get) Token: 0x06002100 RID: 8448 RVA: 0x00087BEC File Offset: 0x00085FEC
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1947864910 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000674 RID: 1652
		// (get) Token: 0x06002101 RID: 8449 RVA: 0x00087C38 File Offset: 0x00086038
		public int StartTime
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1947864910 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x17000675 RID: 1653
		// (get) Token: 0x06002102 RID: 8450 RVA: 0x00087C84 File Offset: 0x00086084
		public int ShopID
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1947864910 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06002103 RID: 8451 RVA: 0x00087CCD File Offset: 0x000860CD
		public static Offset<ChiJiShopTimeTable> CreateChiJiShopTimeTable(FlatBufferBuilder builder, int ID = 0, int StartTime = 0, int ShopID = 0)
		{
			builder.StartObject(3);
			ChiJiShopTimeTable.AddShopID(builder, ShopID);
			ChiJiShopTimeTable.AddStartTime(builder, StartTime);
			ChiJiShopTimeTable.AddID(builder, ID);
			return ChiJiShopTimeTable.EndChiJiShopTimeTable(builder);
		}

		// Token: 0x06002104 RID: 8452 RVA: 0x00087CF1 File Offset: 0x000860F1
		public static void StartChiJiShopTimeTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06002105 RID: 8453 RVA: 0x00087CFA File Offset: 0x000860FA
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06002106 RID: 8454 RVA: 0x00087D05 File Offset: 0x00086105
		public static void AddStartTime(FlatBufferBuilder builder, int StartTime)
		{
			builder.AddInt(1, StartTime, 0);
		}

		// Token: 0x06002107 RID: 8455 RVA: 0x00087D10 File Offset: 0x00086110
		public static void AddShopID(FlatBufferBuilder builder, int ShopID)
		{
			builder.AddInt(2, ShopID, 0);
		}

		// Token: 0x06002108 RID: 8456 RVA: 0x00087D1C File Offset: 0x0008611C
		public static Offset<ChiJiShopTimeTable> EndChiJiShopTimeTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<ChiJiShopTimeTable>(value);
		}

		// Token: 0x06002109 RID: 8457 RVA: 0x00087D36 File Offset: 0x00086136
		public static void FinishChiJiShopTimeTableBuffer(FlatBufferBuilder builder, Offset<ChiJiShopTimeTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000FDD RID: 4061
		private Table __p = new Table();

		// Token: 0x02000333 RID: 819
		public enum eCrypt
		{
			// Token: 0x04000FDF RID: 4063
			code = 1947864910
		}
	}
}
