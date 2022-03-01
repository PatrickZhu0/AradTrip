using System;

namespace Protocol
{
	// Token: 0x02000A3A RID: 2618
	[Protocol]
	public class GASNonExistent : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600736F RID: 29551 RVA: 0x0014F2E4 File Offset: 0x0014D6E4
		public uint GetMsgID()
		{
			return 700001U;
		}

		// Token: 0x06007370 RID: 29552 RVA: 0x0014F2EB File Offset: 0x0014D6EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007371 RID: 29553 RVA: 0x0014F2F3 File Offset: 0x0014D6F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007372 RID: 29554 RVA: 0x0014F2FC File Offset: 0x0014D6FC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007373 RID: 29555 RVA: 0x0014F2FE File Offset: 0x0014D6FE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007374 RID: 29556 RVA: 0x0014F300 File Offset: 0x0014D700
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007375 RID: 29557 RVA: 0x0014F302 File Offset: 0x0014D702
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007376 RID: 29558 RVA: 0x0014F304 File Offset: 0x0014D704
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003594 RID: 13716
		public const uint MsgID = 700001U;

		// Token: 0x04003595 RID: 13717
		public uint Sequence;
	}
}
