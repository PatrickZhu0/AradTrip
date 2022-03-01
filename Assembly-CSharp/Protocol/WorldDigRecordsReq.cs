using System;

namespace Protocol
{
	// Token: 0x020007A2 RID: 1954
	[Protocol]
	public class WorldDigRecordsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F86 RID: 24454 RVA: 0x0011DE81 File Offset: 0x0011C281
		public uint GetMsgID()
		{
			return 608215U;
		}

		// Token: 0x06005F87 RID: 24455 RVA: 0x0011DE88 File Offset: 0x0011C288
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F88 RID: 24456 RVA: 0x0011DE90 File Offset: 0x0011C290
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F89 RID: 24457 RVA: 0x0011DE99 File Offset: 0x0011C299
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005F8A RID: 24458 RVA: 0x0011DE9B File Offset: 0x0011C29B
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005F8B RID: 24459 RVA: 0x0011DE9D File Offset: 0x0011C29D
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005F8C RID: 24460 RVA: 0x0011DE9F File Offset: 0x0011C29F
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005F8D RID: 24461 RVA: 0x0011DEA4 File Offset: 0x0011C2A4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400276E RID: 10094
		public const uint MsgID = 608215U;

		// Token: 0x0400276F RID: 10095
		public uint Sequence;
	}
}
