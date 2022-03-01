using System;

namespace Protocol
{
	// Token: 0x020006D7 RID: 1751
	[Protocol]
	public class WorldAuctionGetTreasTransactionReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600593B RID: 22843 RVA: 0x0010F5AC File Offset: 0x0010D9AC
		public uint GetMsgID()
		{
			return 603924U;
		}

		// Token: 0x0600593C RID: 22844 RVA: 0x0010F5B3 File Offset: 0x0010D9B3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600593D RID: 22845 RVA: 0x0010F5BB File Offset: 0x0010D9BB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600593E RID: 22846 RVA: 0x0010F5C4 File Offset: 0x0010D9C4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600593F RID: 22847 RVA: 0x0010F5C6 File Offset: 0x0010D9C6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005940 RID: 22848 RVA: 0x0010F5C8 File Offset: 0x0010D9C8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005941 RID: 22849 RVA: 0x0010F5CA File Offset: 0x0010D9CA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005942 RID: 22850 RVA: 0x0010F5CC File Offset: 0x0010D9CC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040023EB RID: 9195
		public const uint MsgID = 603924U;

		// Token: 0x040023EC RID: 9196
		public uint Sequence;
	}
}
