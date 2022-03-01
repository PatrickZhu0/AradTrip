using System;

namespace Protocol
{
	// Token: 0x02000A0C RID: 2572
	[Protocol]
	public class WorldMonopolyStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007231 RID: 29233 RVA: 0x0014B33C File Offset: 0x0014973C
		public uint GetMsgID()
		{
			return 610203U;
		}

		// Token: 0x06007232 RID: 29234 RVA: 0x0014B343 File Offset: 0x00149743
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007233 RID: 29235 RVA: 0x0014B34B File Offset: 0x0014974B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007234 RID: 29236 RVA: 0x0014B354 File Offset: 0x00149754
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007235 RID: 29237 RVA: 0x0014B356 File Offset: 0x00149756
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007236 RID: 29238 RVA: 0x0014B358 File Offset: 0x00149758
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007237 RID: 29239 RVA: 0x0014B35A File Offset: 0x0014975A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007238 RID: 29240 RVA: 0x0014B35C File Offset: 0x0014975C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400347F RID: 13439
		public const uint MsgID = 610203U;

		// Token: 0x04003480 RID: 13440
		public uint Sequence;
	}
}
