using System;

namespace Protocol
{
	// Token: 0x02000C01 RID: 3073
	[Protocol]
	public class TeamCopyForceEndReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080A4 RID: 32932 RVA: 0x0016BEE4 File Offset: 0x0016A2E4
		public uint GetMsgID()
		{
			return 1100070U;
		}

		// Token: 0x060080A5 RID: 32933 RVA: 0x0016BEEB File Offset: 0x0016A2EB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080A6 RID: 32934 RVA: 0x0016BEF3 File Offset: 0x0016A2F3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080A7 RID: 32935 RVA: 0x0016BEFC File Offset: 0x0016A2FC
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060080A8 RID: 32936 RVA: 0x0016BEFE File Offset: 0x0016A2FE
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060080A9 RID: 32937 RVA: 0x0016BF00 File Offset: 0x0016A300
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060080AA RID: 32938 RVA: 0x0016BF02 File Offset: 0x0016A302
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060080AB RID: 32939 RVA: 0x0016BF04 File Offset: 0x0016A304
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003D6A RID: 15722
		public const uint MsgID = 1100070U;

		// Token: 0x04003D6B RID: 15723
		public uint Sequence;
	}
}
