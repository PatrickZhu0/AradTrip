using System;

namespace Protocol
{
	// Token: 0x02000A0A RID: 2570
	[Protocol]
	public class WorldMonopolyCoinReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600721F RID: 29215 RVA: 0x0014B290 File Offset: 0x00149690
		public uint GetMsgID()
		{
			return 610201U;
		}

		// Token: 0x06007220 RID: 29216 RVA: 0x0014B297 File Offset: 0x00149697
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007221 RID: 29217 RVA: 0x0014B29F File Offset: 0x0014969F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007222 RID: 29218 RVA: 0x0014B2A8 File Offset: 0x001496A8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007223 RID: 29219 RVA: 0x0014B2AA File Offset: 0x001496AA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007224 RID: 29220 RVA: 0x0014B2AC File Offset: 0x001496AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007225 RID: 29221 RVA: 0x0014B2AE File Offset: 0x001496AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007226 RID: 29222 RVA: 0x0014B2B0 File Offset: 0x001496B0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400347A RID: 13434
		public const uint MsgID = 610201U;

		// Token: 0x0400347B RID: 13435
		public uint Sequence;
	}
}
