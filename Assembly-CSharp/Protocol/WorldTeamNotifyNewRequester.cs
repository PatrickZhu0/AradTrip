using System;

namespace Protocol
{
	// Token: 0x02000B90 RID: 2960
	[Protocol]
	public class WorldTeamNotifyNewRequester : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D6B RID: 32107 RVA: 0x00165232 File Offset: 0x00163632
		public uint GetMsgID()
		{
			return 601637U;
		}

		// Token: 0x06007D6C RID: 32108 RVA: 0x00165239 File Offset: 0x00163639
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D6D RID: 32109 RVA: 0x00165241 File Offset: 0x00163641
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D6E RID: 32110 RVA: 0x0016524A File Offset: 0x0016364A
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007D6F RID: 32111 RVA: 0x0016524C File Offset: 0x0016364C
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007D70 RID: 32112 RVA: 0x0016524E File Offset: 0x0016364E
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007D71 RID: 32113 RVA: 0x00165250 File Offset: 0x00163650
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007D72 RID: 32114 RVA: 0x00165254 File Offset: 0x00163654
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003B7D RID: 15229
		public const uint MsgID = 601637U;

		// Token: 0x04003B7E RID: 15230
		public uint Sequence;
	}
}
