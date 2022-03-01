using System;

namespace Protocol
{
	// Token: 0x02000841 RID: 2113
	[Protocol]
	public class WorldGuildSyncStreamInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063BB RID: 25531 RVA: 0x0012AF70 File Offset: 0x00129370
		public uint GetMsgID()
		{
			return 601925U;
		}

		// Token: 0x060063BC RID: 25532 RVA: 0x0012AF77 File Offset: 0x00129377
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063BD RID: 25533 RVA: 0x0012AF7F File Offset: 0x0012937F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063BE RID: 25534 RVA: 0x0012AF88 File Offset: 0x00129388
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060063BF RID: 25535 RVA: 0x0012AF8A File Offset: 0x0012938A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060063C0 RID: 25536 RVA: 0x0012AF8C File Offset: 0x0012938C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060063C1 RID: 25537 RVA: 0x0012AF8E File Offset: 0x0012938E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060063C2 RID: 25538 RVA: 0x0012AF90 File Offset: 0x00129390
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CC2 RID: 11458
		public const uint MsgID = 601925U;

		// Token: 0x04002CC3 RID: 11459
		public uint Sequence;
	}
}
