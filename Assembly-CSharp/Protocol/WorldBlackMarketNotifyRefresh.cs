using System;

namespace Protocol
{
	// Token: 0x02000978 RID: 2424
	[Protocol]
	public class WorldBlackMarketNotifyRefresh : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006D90 RID: 28048 RVA: 0x0013E1D6 File Offset: 0x0013C5D6
		public uint GetMsgID()
		{
			return 609008U;
		}

		// Token: 0x06006D91 RID: 28049 RVA: 0x0013E1DD File Offset: 0x0013C5DD
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006D92 RID: 28050 RVA: 0x0013E1E5 File Offset: 0x0013C5E5
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006D93 RID: 28051 RVA: 0x0013E1EE File Offset: 0x0013C5EE
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D94 RID: 28052 RVA: 0x0013E1F0 File Offset: 0x0013C5F0
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006D95 RID: 28053 RVA: 0x0013E1F2 File Offset: 0x0013C5F2
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D96 RID: 28054 RVA: 0x0013E1F4 File Offset: 0x0013C5F4
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006D97 RID: 28055 RVA: 0x0013E1F8 File Offset: 0x0013C5F8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400319D RID: 12701
		public const uint MsgID = 609008U;

		// Token: 0x0400319E RID: 12702
		public uint Sequence;
	}
}
