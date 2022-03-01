using System;

namespace Protocol
{
	// Token: 0x02000C93 RID: 3219
	[Protocol]
	public class WorldUpdateRelation : IProtocolStream, IGetMsgID
	{
		// Token: 0x060084E5 RID: 34021 RVA: 0x001751C4 File Offset: 0x001735C4
		public uint GetMsgID()
		{
			return 601712U;
		}

		// Token: 0x060084E6 RID: 34022 RVA: 0x001751CB File Offset: 0x001735CB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060084E7 RID: 34023 RVA: 0x001751D3 File Offset: 0x001735D3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060084E8 RID: 34024 RVA: 0x001751DC File Offset: 0x001735DC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060084E9 RID: 34025 RVA: 0x001751DE File Offset: 0x001735DE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060084EA RID: 34026 RVA: 0x001751E0 File Offset: 0x001735E0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060084EB RID: 34027 RVA: 0x001751E2 File Offset: 0x001735E2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060084EC RID: 34028 RVA: 0x001751E4 File Offset: 0x001735E4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003FB8 RID: 16312
		public const uint MsgID = 601712U;

		// Token: 0x04003FB9 RID: 16313
		public uint Sequence;
	}
}
