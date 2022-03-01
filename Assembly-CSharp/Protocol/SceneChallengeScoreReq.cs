using System;

namespace Protocol
{
	// Token: 0x02000689 RID: 1673
	[Protocol]
	public class SceneChallengeScoreReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060056F9 RID: 22265 RVA: 0x00109F35 File Offset: 0x00108335
		public uint GetMsgID()
		{
			return 507414U;
		}

		// Token: 0x060056FA RID: 22266 RVA: 0x00109F3C File Offset: 0x0010833C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060056FB RID: 22267 RVA: 0x00109F44 File Offset: 0x00108344
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060056FC RID: 22268 RVA: 0x00109F4D File Offset: 0x0010834D
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060056FD RID: 22269 RVA: 0x00109F4F File Offset: 0x0010834F
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060056FE RID: 22270 RVA: 0x00109F51 File Offset: 0x00108351
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060056FF RID: 22271 RVA: 0x00109F53 File Offset: 0x00108353
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005700 RID: 22272 RVA: 0x00109F58 File Offset: 0x00108358
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400228B RID: 8843
		public const uint MsgID = 507414U;

		// Token: 0x0400228C RID: 8844
		public uint Sequence;
	}
}
