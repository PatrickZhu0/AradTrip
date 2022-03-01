using System;

namespace Protocol
{
	// Token: 0x02000974 RID: 2420
	[Protocol]
	public class WorldBlackMarketAuctionReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D6C RID: 28012 RVA: 0x0013DEED File Offset: 0x0013C2ED
		public uint GetMsgID()
		{
			return 609004U;
		}

		// Token: 0x06006D6D RID: 28013 RVA: 0x0013DEF4 File Offset: 0x0013C2F4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D6E RID: 28014 RVA: 0x0013DEFC File Offset: 0x0013C2FC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D6F RID: 28015 RVA: 0x0013DF05 File Offset: 0x0013C305
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.auction_guid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.item_guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auction_price);
		}

		// Token: 0x06006D70 RID: 28016 RVA: 0x0013DF31 File Offset: 0x0013C331
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auction_guid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.item_guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auction_price);
		}

		// Token: 0x06006D71 RID: 28017 RVA: 0x0013DF5D File Offset: 0x0013C35D
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.auction_guid);
			BaseDLL.encode_uint64(buffer, ref pos_, this.item_guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.auction_price);
		}

		// Token: 0x06006D72 RID: 28018 RVA: 0x0013DF89 File Offset: 0x0013C389
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auction_guid);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.item_guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.auction_price);
		}

		// Token: 0x06006D73 RID: 28019 RVA: 0x0013DFB8 File Offset: 0x0013C3B8
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400318D RID: 12685
		public const uint MsgID = 609004U;

		// Token: 0x0400318E RID: 12686
		public uint Sequence;

		// Token: 0x0400318F RID: 12687
		public ulong auction_guid;

		// Token: 0x04003190 RID: 12688
		public ulong item_guid;

		// Token: 0x04003191 RID: 12689
		public uint auction_price;
	}
}
