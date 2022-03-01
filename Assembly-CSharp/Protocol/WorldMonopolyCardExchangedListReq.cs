using System;

namespace Protocol
{
	// Token: 0x02000A18 RID: 2584
	[Protocol]
	public class WorldMonopolyCardExchangedListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600729A RID: 29338 RVA: 0x0014BAC4 File Offset: 0x00149EC4
		public uint GetMsgID()
		{
			return 610214U;
		}

		// Token: 0x0600729B RID: 29339 RVA: 0x0014BACB File Offset: 0x00149ECB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600729C RID: 29340 RVA: 0x0014BAD3 File Offset: 0x00149ED3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600729D RID: 29341 RVA: 0x0014BADC File Offset: 0x00149EDC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600729E RID: 29342 RVA: 0x0014BADE File Offset: 0x00149EDE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600729F RID: 29343 RVA: 0x0014BAE0 File Offset: 0x00149EE0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060072A0 RID: 29344 RVA: 0x0014BAE2 File Offset: 0x00149EE2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060072A1 RID: 29345 RVA: 0x0014BAE4 File Offset: 0x00149EE4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040034A5 RID: 13477
		public const uint MsgID = 610214U;

		// Token: 0x040034A6 RID: 13478
		public uint Sequence;
	}
}
