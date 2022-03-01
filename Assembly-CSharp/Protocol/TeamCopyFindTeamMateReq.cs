using System;

namespace Protocol
{
	// Token: 0x02000BD9 RID: 3033
	[Protocol]
	public class TeamCopyFindTeamMateReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F42 RID: 32578 RVA: 0x0016935C File Offset: 0x0016775C
		public uint GetMsgID()
		{
			return 1100029U;
		}

		// Token: 0x06007F43 RID: 32579 RVA: 0x00169363 File Offset: 0x00167763
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F44 RID: 32580 RVA: 0x0016936B File Offset: 0x0016776B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F45 RID: 32581 RVA: 0x00169374 File Offset: 0x00167774
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007F46 RID: 32582 RVA: 0x00169376 File Offset: 0x00167776
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007F47 RID: 32583 RVA: 0x00169378 File Offset: 0x00167778
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007F48 RID: 32584 RVA: 0x0016937A File Offset: 0x0016777A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007F49 RID: 32585 RVA: 0x0016937C File Offset: 0x0016777C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003CC4 RID: 15556
		public const uint MsgID = 1100029U;

		// Token: 0x04003CC5 RID: 15557
		public uint Sequence;
	}
}
