using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002BA RID: 698
	public class AuctionMagicExpectUpTimesTable : IFlatbufferObject
	{
		// Token: 0x170003B6 RID: 950
		// (get) Token: 0x060018C2 RID: 6338 RVA: 0x0007424C File Offset: 0x0007264C
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x060018C3 RID: 6339 RVA: 0x00074259 File Offset: 0x00072659
		public static AuctionMagicExpectUpTimesTable GetRootAsAuctionMagicExpectUpTimesTable(ByteBuffer _bb)
		{
			return AuctionMagicExpectUpTimesTable.GetRootAsAuctionMagicExpectUpTimesTable(_bb, new AuctionMagicExpectUpTimesTable());
		}

		// Token: 0x060018C4 RID: 6340 RVA: 0x00074266 File Offset: 0x00072666
		public static AuctionMagicExpectUpTimesTable GetRootAsAuctionMagicExpectUpTimesTable(ByteBuffer _bb, AuctionMagicExpectUpTimesTable obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x060018C5 RID: 6341 RVA: 0x00074282 File Offset: 0x00072682
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x060018C6 RID: 6342 RVA: 0x0007429C File Offset: 0x0007269C
		public AuctionMagicExpectUpTimesTable __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003B7 RID: 951
		// (get) Token: 0x060018C7 RID: 6343 RVA: 0x000742A8 File Offset: 0x000726A8
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (1816831156 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003B8 RID: 952
		// (get) Token: 0x060018C8 RID: 6344 RVA: 0x000742F4 File Offset: 0x000726F4
		public int Type
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? 0 : (1816831156 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003B9 RID: 953
		// (get) Token: 0x060018C9 RID: 6345 RVA: 0x00074340 File Offset: 0x00072740
		public int Quality
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (1816831156 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003BA RID: 954
		// (get) Token: 0x060018CA RID: 6346 RVA: 0x0007438C File Offset: 0x0007278C
		public int Strengthenlv
		{
			get
			{
				int num = this.__p.__offset(10);
				return (num == 0) ? 0 : (1816831156 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003BB RID: 955
		// (get) Token: 0x060018CB RID: 6347 RVA: 0x000743D8 File Offset: 0x000727D8
		public int ExpectUpTimes
		{
			get
			{
				int num = this.__p.__offset(12);
				return (num == 0) ? 0 : (1816831156 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x060018CC RID: 6348 RVA: 0x00074422 File Offset: 0x00072822
		public static Offset<AuctionMagicExpectUpTimesTable> CreateAuctionMagicExpectUpTimesTable(FlatBufferBuilder builder, int ID = 0, int Type = 0, int Quality = 0, int Strengthenlv = 0, int ExpectUpTimes = 0)
		{
			builder.StartObject(5);
			AuctionMagicExpectUpTimesTable.AddExpectUpTimes(builder, ExpectUpTimes);
			AuctionMagicExpectUpTimesTable.AddStrengthenlv(builder, Strengthenlv);
			AuctionMagicExpectUpTimesTable.AddQuality(builder, Quality);
			AuctionMagicExpectUpTimesTable.AddType(builder, Type);
			AuctionMagicExpectUpTimesTable.AddID(builder, ID);
			return AuctionMagicExpectUpTimesTable.EndAuctionMagicExpectUpTimesTable(builder);
		}

		// Token: 0x060018CD RID: 6349 RVA: 0x00074456 File Offset: 0x00072856
		public static void StartAuctionMagicExpectUpTimesTable(FlatBufferBuilder builder)
		{
			builder.StartObject(5);
		}

		// Token: 0x060018CE RID: 6350 RVA: 0x0007445F File Offset: 0x0007285F
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x060018CF RID: 6351 RVA: 0x0007446A File Offset: 0x0007286A
		public static void AddType(FlatBufferBuilder builder, int Type)
		{
			builder.AddInt(1, Type, 0);
		}

		// Token: 0x060018D0 RID: 6352 RVA: 0x00074475 File Offset: 0x00072875
		public static void AddQuality(FlatBufferBuilder builder, int Quality)
		{
			builder.AddInt(2, Quality, 0);
		}

		// Token: 0x060018D1 RID: 6353 RVA: 0x00074480 File Offset: 0x00072880
		public static void AddStrengthenlv(FlatBufferBuilder builder, int Strengthenlv)
		{
			builder.AddInt(3, Strengthenlv, 0);
		}

		// Token: 0x060018D2 RID: 6354 RVA: 0x0007448B File Offset: 0x0007288B
		public static void AddExpectUpTimes(FlatBufferBuilder builder, int ExpectUpTimes)
		{
			builder.AddInt(4, ExpectUpTimes, 0);
		}

		// Token: 0x060018D3 RID: 6355 RVA: 0x00074498 File Offset: 0x00072898
		public static Offset<AuctionMagicExpectUpTimesTable> EndAuctionMagicExpectUpTimesTable(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionMagicExpectUpTimesTable>(value);
		}

		// Token: 0x060018D4 RID: 6356 RVA: 0x000744B2 File Offset: 0x000728B2
		public static void FinishAuctionMagicExpectUpTimesTableBuffer(FlatBufferBuilder builder, Offset<AuctionMagicExpectUpTimesTable> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E59 RID: 3673
		private Table __p = new Table();

		// Token: 0x020002BB RID: 699
		public enum eCrypt
		{
			// Token: 0x04000E5B RID: 3675
			code = 1816831156
		}
	}
}
