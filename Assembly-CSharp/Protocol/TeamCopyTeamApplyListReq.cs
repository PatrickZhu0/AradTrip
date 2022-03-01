using System;

namespace Protocol
{
	// Token: 0x02000BD2 RID: 3026
	[Protocol]
	public class TeamCopyTeamApplyListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F06 RID: 32518 RVA: 0x001689C8 File Offset: 0x00166DC8
		public uint GetMsgID()
		{
			return 1100023U;
		}

		// Token: 0x06007F07 RID: 32519 RVA: 0x001689CF File Offset: 0x00166DCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F08 RID: 32520 RVA: 0x001689D7 File Offset: 0x00166DD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F09 RID: 32521 RVA: 0x001689E0 File Offset: 0x00166DE0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007F0A RID: 32522 RVA: 0x001689E2 File Offset: 0x00166DE2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007F0B RID: 32523 RVA: 0x001689E4 File Offset: 0x00166DE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007F0C RID: 32524 RVA: 0x001689E6 File Offset: 0x00166DE6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007F0D RID: 32525 RVA: 0x001689E8 File Offset: 0x00166DE8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003CA7 RID: 15527
		public const uint MsgID = 1100023U;

		// Token: 0x04003CA8 RID: 15528
		public uint Sequence;
	}
}
