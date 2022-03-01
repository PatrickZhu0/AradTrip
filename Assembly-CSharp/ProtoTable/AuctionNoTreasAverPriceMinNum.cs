using System;
using FlatBuffers;

namespace ProtoTable
{
	// Token: 0x020002C4 RID: 708
	public class AuctionNoTreasAverPriceMinNum : IFlatbufferObject
	{
		// Token: 0x170003E0 RID: 992
		// (get) Token: 0x06001948 RID: 6472 RVA: 0x000755E0 File Offset: 0x000739E0
		public ByteBuffer ByteBuffer
		{
			get
			{
				return this.__p.bb;
			}
		}

		// Token: 0x06001949 RID: 6473 RVA: 0x000755ED File Offset: 0x000739ED
		public static AuctionNoTreasAverPriceMinNum GetRootAsAuctionNoTreasAverPriceMinNum(ByteBuffer _bb)
		{
			return AuctionNoTreasAverPriceMinNum.GetRootAsAuctionNoTreasAverPriceMinNum(_bb, new AuctionNoTreasAverPriceMinNum());
		}

		// Token: 0x0600194A RID: 6474 RVA: 0x000755FA File Offset: 0x000739FA
		public static AuctionNoTreasAverPriceMinNum GetRootAsAuctionNoTreasAverPriceMinNum(ByteBuffer _bb, AuctionNoTreasAverPriceMinNum obj)
		{
			return obj.__assign(_bb.GetInt(_bb.Position) + _bb.Position, _bb);
		}

		// Token: 0x0600194B RID: 6475 RVA: 0x00075616 File Offset: 0x00073A16
		public void __init(int _i, ByteBuffer _bb)
		{
			this.__p.bb_pos = _i;
			this.__p.bb = _bb;
		}

		// Token: 0x0600194C RID: 6476 RVA: 0x00075630 File Offset: 0x00073A30
		public AuctionNoTreasAverPriceMinNum __assign(int _i, ByteBuffer _bb)
		{
			this.__init(_i, _bb);
			return this;
		}

		// Token: 0x170003E1 RID: 993
		// (get) Token: 0x0600194D RID: 6477 RVA: 0x0007563C File Offset: 0x00073A3C
		public int ID
		{
			get
			{
				int num = this.__p.__offset(4);
				return (num == 0) ? 0 : (-1934113566 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x170003E2 RID: 994
		// (get) Token: 0x0600194E RID: 6478 RVA: 0x00075688 File Offset: 0x00073A88
		public string Name
		{
			get
			{
				int num = this.__p.__offset(6);
				return (num == 0) ? string.Empty : this.__p.__string(num + this.__p.bb_pos);
			}
		}

		// Token: 0x0600194F RID: 6479 RVA: 0x000756CA File Offset: 0x00073ACA
		public ArraySegment<byte>? GetNameBytes()
		{
			return this.__p.__vector_as_arraysegment(6);
		}

		// Token: 0x170003E3 RID: 995
		// (get) Token: 0x06001950 RID: 6480 RVA: 0x000756D8 File Offset: 0x00073AD8
		public int MinNum
		{
			get
			{
				int num = this.__p.__offset(8);
				return (num == 0) ? 0 : (-1934113566 ^ this.__p.bb.GetInt(num + this.__p.bb_pos));
			}
		}

		// Token: 0x06001951 RID: 6481 RVA: 0x00075721 File Offset: 0x00073B21
		public static Offset<AuctionNoTreasAverPriceMinNum> CreateAuctionNoTreasAverPriceMinNum(FlatBufferBuilder builder, int ID = 0, StringOffset NameOffset = default(StringOffset), int MinNum = 0)
		{
			builder.StartObject(3);
			AuctionNoTreasAverPriceMinNum.AddMinNum(builder, MinNum);
			AuctionNoTreasAverPriceMinNum.AddName(builder, NameOffset);
			AuctionNoTreasAverPriceMinNum.AddID(builder, ID);
			return AuctionNoTreasAverPriceMinNum.EndAuctionNoTreasAverPriceMinNum(builder);
		}

		// Token: 0x06001952 RID: 6482 RVA: 0x00075745 File Offset: 0x00073B45
		public static void StartAuctionNoTreasAverPriceMinNum(FlatBufferBuilder builder)
		{
			builder.StartObject(3);
		}

		// Token: 0x06001953 RID: 6483 RVA: 0x0007574E File Offset: 0x00073B4E
		public static void AddID(FlatBufferBuilder builder, int ID)
		{
			builder.AddInt(0, ID, 0);
		}

		// Token: 0x06001954 RID: 6484 RVA: 0x00075759 File Offset: 0x00073B59
		public static void AddName(FlatBufferBuilder builder, StringOffset NameOffset)
		{
			builder.AddOffset(1, NameOffset.Value, 0);
		}

		// Token: 0x06001955 RID: 6485 RVA: 0x0007576A File Offset: 0x00073B6A
		public static void AddMinNum(FlatBufferBuilder builder, int MinNum)
		{
			builder.AddInt(2, MinNum, 0);
		}

		// Token: 0x06001956 RID: 6486 RVA: 0x00075778 File Offset: 0x00073B78
		public static Offset<AuctionNoTreasAverPriceMinNum> EndAuctionNoTreasAverPriceMinNum(FlatBufferBuilder builder)
		{
			int value = builder.EndObject();
			return new Offset<AuctionNoTreasAverPriceMinNum>(value);
		}

		// Token: 0x06001957 RID: 6487 RVA: 0x00075792 File Offset: 0x00073B92
		public static void FinishAuctionNoTreasAverPriceMinNumBuffer(FlatBufferBuilder builder, Offset<AuctionNoTreasAverPriceMinNum> offset)
		{
			builder.Finish(offset.Value);
		}

		// Token: 0x04000E84 RID: 3716
		private Table __p = new Table();

		// Token: 0x020002C5 RID: 709
		public enum eCrypt
		{
			// Token: 0x04000E86 RID: 3718
			code = -1934113566
		}
	}
}
