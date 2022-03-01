using System;

namespace Protocol
{
	// Token: 0x02000972 RID: 2418
	[Protocol]
	public class WorldBlackMarketAuctionListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D5A RID: 27994 RVA: 0x0013DD04 File Offset: 0x0013C104
		public uint GetMsgID()
		{
			return 609002U;
		}

		// Token: 0x06006D5B RID: 27995 RVA: 0x0013DD0B File Offset: 0x0013C10B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D5C RID: 27996 RVA: 0x0013DD13 File Offset: 0x0013C113
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D5D RID: 27997 RVA: 0x0013DD1C File Offset: 0x0013C11C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D5E RID: 27998 RVA: 0x0013DD1E File Offset: 0x0013C11E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D5F RID: 27999 RVA: 0x0013DD20 File Offset: 0x0013C120
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D60 RID: 28000 RVA: 0x0013DD22 File Offset: 0x0013C122
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D61 RID: 28001 RVA: 0x0013DD24 File Offset: 0x0013C124
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003188 RID: 12680
		public const uint MsgID = 609002U;

		// Token: 0x04003189 RID: 12681
		public uint Sequence;
	}
}
