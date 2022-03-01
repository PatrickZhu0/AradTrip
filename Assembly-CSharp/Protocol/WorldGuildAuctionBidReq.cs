using System;

namespace Protocol
{
	// Token: 0x02000896 RID: 2198
	[Protocol]
	public class WorldGuildAuctionBidReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060066A3 RID: 26275 RVA: 0x001300DD File Offset: 0x0012E4DD
		public uint GetMsgID()
		{
			return 608515U;
		}

		// Token: 0x060066A4 RID: 26276 RVA: 0x001300E4 File Offset: 0x0012E4E4
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060066A5 RID: 26277 RVA: 0x001300EC File Offset: 0x0012E4EC
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060066A6 RID: 26278 RVA: 0x001300F5 File Offset: 0x0012E4F5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bidPrice);
		}

		// Token: 0x060066A7 RID: 26279 RVA: 0x00130113 File Offset: 0x0012E513
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bidPrice);
		}

		// Token: 0x060066A8 RID: 26280 RVA: 0x00130131 File Offset: 0x0012E531
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bidPrice);
		}

		// Token: 0x060066A9 RID: 26281 RVA: 0x0013014F File Offset: 0x0012E54F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bidPrice);
		}

		// Token: 0x060066AA RID: 26282 RVA: 0x00130170 File Offset: 0x0012E570
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04002DE9 RID: 11753
		public const uint MsgID = 608515U;

		// Token: 0x04002DEA RID: 11754
		public uint Sequence;

		// Token: 0x04002DEB RID: 11755
		public ulong guid;

		// Token: 0x04002DEC RID: 11756
		public uint bidPrice;
	}
}
