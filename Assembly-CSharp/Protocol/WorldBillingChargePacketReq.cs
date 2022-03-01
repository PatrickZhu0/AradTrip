using System;

namespace Protocol
{
	// Token: 0x02000C31 RID: 3121
	[Protocol]
	public class WorldBillingChargePacketReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008221 RID: 33313 RVA: 0x0016F0D1 File Offset: 0x0016D4D1
		public uint GetMsgID()
		{
			return 604009U;
		}

		// Token: 0x06008222 RID: 33314 RVA: 0x0016F0D8 File Offset: 0x0016D4D8
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008223 RID: 33315 RVA: 0x0016F0E0 File Offset: 0x0016D4E0
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008224 RID: 33316 RVA: 0x0016F0E9 File Offset: 0x0016D4E9
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008225 RID: 33317 RVA: 0x0016F0EB File Offset: 0x0016D4EB
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008226 RID: 33318 RVA: 0x0016F0ED File Offset: 0x0016D4ED
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008227 RID: 33319 RVA: 0x0016F0EF File Offset: 0x0016D4EF
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008228 RID: 33320 RVA: 0x0016F0F4 File Offset: 0x0016D4F4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003E2E RID: 15918
		public const uint MsgID = 604009U;

		// Token: 0x04003E2F RID: 15919
		public uint Sequence;
	}
}
