using System;

namespace Protocol
{
	// Token: 0x02000976 RID: 2422
	[Protocol]
	public class WorldBlackMarketAuctionCancelReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D7E RID: 28030 RVA: 0x0013E09E File Offset: 0x0013C49E
		public uint GetMsgID()
		{
			return 609006U;
		}

		// Token: 0x06006D7F RID: 28031 RVA: 0x0013E0A5 File Offset: 0x0013C4A5
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D80 RID: 28032 RVA: 0x0013E0AD File Offset: 0x0013C4AD
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D81 RID: 28033 RVA: 0x0013E0B6 File Offset: 0x0013C4B6
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.auction_guid);
		}

		// Token: 0x06006D82 RID: 28034 RVA: 0x0013E0C6 File Offset: 0x0013C4C6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auction_guid);
		}

		// Token: 0x06006D83 RID: 28035 RVA: 0x0013E0D6 File Offset: 0x0013C4D6
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.auction_guid);
		}

		// Token: 0x06006D84 RID: 28036 RVA: 0x0013E0E6 File Offset: 0x0013C4E6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.auction_guid);
		}

		// Token: 0x06006D85 RID: 28037 RVA: 0x0013E0F8 File Offset: 0x0013C4F8
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04003196 RID: 12694
		public const uint MsgID = 609006U;

		// Token: 0x04003197 RID: 12695
		public uint Sequence;

		// Token: 0x04003198 RID: 12696
		public ulong auction_guid;
	}
}
