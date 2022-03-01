using System;

namespace Protocol
{
	// Token: 0x02000A99 RID: 2713
	[Protocol]
	public class RelaySvrEndGameReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007648 RID: 30280 RVA: 0x00156108 File Offset: 0x00154508
		public uint GetMsgID()
		{
			return 1300007U;
		}

		// Token: 0x06007649 RID: 30281 RVA: 0x0015610F File Offset: 0x0015450F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600764A RID: 30282 RVA: 0x00156117 File Offset: 0x00154517
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600764B RID: 30283 RVA: 0x00156120 File Offset: 0x00154520
		public void encode(byte[] buffer, ref int pos_)
		{
			this.end.encode(buffer, ref pos_);
		}

		// Token: 0x0600764C RID: 30284 RVA: 0x0015612F File Offset: 0x0015452F
		public void decode(byte[] buffer, ref int pos_)
		{
			this.end.decode(buffer, ref pos_);
		}

		// Token: 0x0600764D RID: 30285 RVA: 0x0015613E File Offset: 0x0015453E
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.end.encode(buffer, ref pos_);
		}

		// Token: 0x0600764E RID: 30286 RVA: 0x0015614D File Offset: 0x0015454D
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.end.decode(buffer, ref pos_);
		}

		// Token: 0x0600764F RID: 30287 RVA: 0x0015615C File Offset: 0x0015455C
		public int getLen()
		{
			int num = 0;
			return num + this.end.getLen();
		}

		// Token: 0x04003740 RID: 14144
		public const uint MsgID = 1300007U;

		// Token: 0x04003741 RID: 14145
		public uint Sequence;

		// Token: 0x04003742 RID: 14146
		public PkRaceEndInfo end = new PkRaceEndInfo();
	}
}
