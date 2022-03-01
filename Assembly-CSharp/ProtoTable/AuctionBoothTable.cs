using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002AE RID: 686
	public class AuctionBoothTable : IFlatbufferObject
	{
		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x0600187A RID: 6266 RVA: 0x000738E8 File Offset: 0x00071CE8
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x0600187B RID: 6267 RVA: 0x000738F5 File Offset: 0x00071CF5
		public static AuctionBoothTable GetRootAsAuctionBoothTable(ByteBuffer _bb)
		{
			return AuctionBoothTable.GetRootAsAuctionBoothTable(_bb, new AuctionBoothTable());
		}

		// Token: 0x0600187C RID: 6268 RVA: 0x00073902 File Offset: 0x00071D02
		public static AuctionBoothTable GetRootAsAuctionBoothTable(ByteBuffer _bb, AuctionBoothTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600187D RID: 6269 RVA: 0x0007391E File Offset: 0x00071D1E
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600187E RID: 6270 RVA: 0x00073938 File Offset: 0x00071D38
		public AuctionBoothTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x0600187F RID: 6271 RVA: 0x00073944 File Offset: 0x00071D44
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1347207501 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x06001880 RID: 6272 RVA: 0x00073990 File Offset: 0x00071D90
		public int CostItemID
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (-1347207501 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x06001881 RID: 6273 RVA: 0x000739DC File Offset: 0x00071DDC
		public int Num
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1347207501 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001882 RID: 6274 RVA: 0x00073A25 File Offset: 0x00071E25
		public static Offset<AuctionBoothTable> CreateAuctionBoothTable(FlatBufferBuilder builder, int ID = 0, int CostItemID = 0, int Num = 0)
		{
			builder.StartObject(3);
			AuctionBoothTable.AddNum(builder, Num);
			AuctionBoothTable.AddCostItemID(builder, CostItemID);
			AuctionBoothTable.AddID(builder, ID);
			return AuctionBoothTable.EndAuctionBoothTable(builder);
		}

		// Token: 0x06001883 RID: 6275 RVA: 0x00073A49 File Offset: 0x00071E49
		public static void StartAuctionBoothTable(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001884 RID: 6276 RVA: 0x00073A52 File Offset: 0x00071E52
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001885 RID: 6277 RVA: 0x00073A5D File Offset: 0x00071E5D
		public static void AddCostItemID(FlatBufferBuilder builder, int CostItemID)
		{
			builder.AddInt(1, CostItemID, 0);
		}

		// Token: 0x06001886 RID: 6278 RVA: 0x00073A68 File Offset: 0x00071E68
		public static void AddNum(FlatBufferBuilder builder, int Num)
		{
			builder.AddInt(2, Num, 0);
		}

		// Token: 0x06001887 RID: 6279 RVA: 0x00073A74 File Offset: 0x00071E74
		public static Offset<AuctionBoothTable> EndAuctionBoothTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionBoothTable>(value);
		}

		// Token: 0x06001888 RID: 6280 RVA: 0x00073A8E File Offset: 0x00071E8E
		public static void FinishAuctionBoothTableBuffer(FlatBufferBuilder builder, Offset<AuctionBoothTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E06 RID: 3590
		private Table __p = new Table();

		// Token: 0x020002AF RID: 687
		public enum eCrypt
		{
			// Token: 0x04000E08 RID: 3592
			code = -1347207501
		}
	}
}
