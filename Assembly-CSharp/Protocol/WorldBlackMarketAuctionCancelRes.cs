using System;

namespace Protocol
{
	// Token: 0x02000977 RID: 2423
	[Protocol]
	public class WorldBlackMarketAuctionCancelRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D87 RID: 28039 RVA: 0x0013E11F File Offset: 0x0013C51F
		public uint GetMsgID()
		{
			return 609007U;
		}

		// Token: 0x06006D88 RID: 28040 RVA: 0x0013E126 File Offset: 0x0013C526
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D89 RID: 28041 RVA: 0x0013E12E File Offset: 0x0013C52E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D8A RID: 28042 RVA: 0x0013E137 File Offset: 0x0013C537
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			this.item.encode(buffer, ref pos_);
		}

		// Token: 0x06006D8B RID: 28043 RVA: 0x0013E154 File Offset: 0x0013C554
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			this.item.decode(buffer, ref pos_);
		}

		// Token: 0x06006D8C RID: 28044 RVA: 0x0013E171 File Offset: 0x0013C571
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.code);
			this.item.encode(buffer, ref pos_);
		}

		// Token: 0x06006D8D RID: 28045 RVA: 0x0013E18E File Offset: 0x0013C58E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.code);
			this.item.decode(buffer, ref pos_);
		}

		// Token: 0x06006D8E RID: 28046 RVA: 0x0013E1AC File Offset: 0x0013C5AC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + this.item.getLen();
		}

		// Token: 0x04003199 RID: 12697
		public const uint MsgID = 609007U;

		// Token: 0x0400319A RID: 12698
		public uint Sequence;

		// Token: 0x0400319B RID: 12699
		public uint code;

		// Token: 0x0400319C RID: 12700
		public BlackMarketAuctionInfo item = new BlackMarketAuctionInfo();
	}
}
