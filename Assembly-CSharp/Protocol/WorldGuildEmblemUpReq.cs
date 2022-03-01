using System;

namespace Protocol
{
	// Token: 0x02000879 RID: 2169
	[Protocol]
	public class WorldGuildEmblemUpReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065B3 RID: 26035 RVA: 0x0012E2D0 File Offset: 0x0012C6D0
		public uint GetMsgID()
		{
			return 601990U;
		}

		// Token: 0x060065B4 RID: 26036 RVA: 0x0012E2D7 File Offset: 0x0012C6D7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065B5 RID: 26037 RVA: 0x0012E2DF File Offset: 0x0012C6DF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065B6 RID: 26038 RVA: 0x0012E2E8 File Offset: 0x0012C6E8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060065B7 RID: 26039 RVA: 0x0012E2EA File Offset: 0x0012C6EA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060065B8 RID: 26040 RVA: 0x0012E2EC File Offset: 0x0012C6EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060065B9 RID: 26041 RVA: 0x0012E2EE File Offset: 0x0012C6EE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060065BA RID: 26042 RVA: 0x0012E2F0 File Offset: 0x0012C6F0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D8A RID: 11658
		public const uint MsgID = 601990U;

		// Token: 0x04002D8B RID: 11659
		public uint Sequence;
	}
}
