using System;

namespace Protocol
{
	// Token: 0x02000CBE RID: 3262
	[Protocol]
	public class WorldNotifyFinSchEvent : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008665 RID: 34405 RVA: 0x00177874 File Offset: 0x00175C74
		public uint GetMsgID()
		{
			return 601777U;
		}

		// Token: 0x06008666 RID: 34406 RVA: 0x0017787B File Offset: 0x00175C7B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008667 RID: 34407 RVA: 0x00177883 File Offset: 0x00175C83
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008668 RID: 34408 RVA: 0x0017788C File Offset: 0x00175C8C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008669 RID: 34409 RVA: 0x0017788E File Offset: 0x00175C8E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600866A RID: 34410 RVA: 0x00177890 File Offset: 0x00175C90
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600866B RID: 34411 RVA: 0x00177892 File Offset: 0x00175C92
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600866C RID: 34412 RVA: 0x00177894 File Offset: 0x00175C94
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400404F RID: 16463
		public const uint MsgID = 601777U;

		// Token: 0x04004050 RID: 16464
		public uint Sequence;
	}
}
