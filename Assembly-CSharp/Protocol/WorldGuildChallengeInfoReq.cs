using System;

namespace Protocol
{
	// Token: 0x02000866 RID: 2150
	[Protocol]
	public class WorldGuildChallengeInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006508 RID: 25864 RVA: 0x0012CCD8 File Offset: 0x0012B0D8
		public uint GetMsgID()
		{
			return 601961U;
		}

		// Token: 0x06006509 RID: 25865 RVA: 0x0012CCDF File Offset: 0x0012B0DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600650A RID: 25866 RVA: 0x0012CCE7 File Offset: 0x0012B0E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600650B RID: 25867 RVA: 0x0012CCF0 File Offset: 0x0012B0F0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600650C RID: 25868 RVA: 0x0012CCF2 File Offset: 0x0012B0F2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600650D RID: 25869 RVA: 0x0012CCF4 File Offset: 0x0012B0F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600650E RID: 25870 RVA: 0x0012CCF6 File Offset: 0x0012B0F6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600650F RID: 25871 RVA: 0x0012CCF8 File Offset: 0x0012B0F8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D47 RID: 11591
		public const uint MsgID = 601961U;

		// Token: 0x04002D48 RID: 11592
		public uint Sequence;
	}
}
