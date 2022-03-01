using System;

namespace Protocol
{
	// Token: 0x02000A71 RID: 2673
	[Protocol]
	public class WorldPremiumLeagueBattleRecordSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007528 RID: 29992 RVA: 0x00152FA8 File Offset: 0x001513A8
		public uint GetMsgID()
		{
			return 607711U;
		}

		// Token: 0x06007529 RID: 29993 RVA: 0x00152FAF File Offset: 0x001513AF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600752A RID: 29994 RVA: 0x00152FB7 File Offset: 0x001513B7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600752B RID: 29995 RVA: 0x00152FC0 File Offset: 0x001513C0
		public void encode(byte[] buffer, ref int pos_)
		{
			this.record.encode(buffer, ref pos_);
		}

		// Token: 0x0600752C RID: 29996 RVA: 0x00152FCF File Offset: 0x001513CF
		public void decode(byte[] buffer, ref int pos_)
		{
			this.record.decode(buffer, ref pos_);
		}

		// Token: 0x0600752D RID: 29997 RVA: 0x00152FDE File Offset: 0x001513DE
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.record.encode(buffer, ref pos_);
		}

		// Token: 0x0600752E RID: 29998 RVA: 0x00152FED File Offset: 0x001513ED
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.record.decode(buffer, ref pos_);
		}

		// Token: 0x0600752F RID: 29999 RVA: 0x00152FFC File Offset: 0x001513FC
		public int getLen()
		{
			int num = 0;
			return num + this.record.getLen();
		}

		// Token: 0x0400367C RID: 13948
		public const uint MsgID = 607711U;

		// Token: 0x0400367D RID: 13949
		public uint Sequence;

		// Token: 0x0400367E RID: 13950
		public PremiumLeagueRecordEntry record = new PremiumLeagueRecordEntry();
	}
}
