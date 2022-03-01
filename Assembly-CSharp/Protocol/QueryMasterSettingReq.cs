using System;

namespace Protocol
{
	// Token: 0x02000C9C RID: 3228
	[Protocol]
	public class QueryMasterSettingReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008533 RID: 34099 RVA: 0x00175A14 File Offset: 0x00173E14
		public uint GetMsgID()
		{
			return 601720U;
		}

		// Token: 0x06008534 RID: 34100 RVA: 0x00175A1B File Offset: 0x00173E1B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008535 RID: 34101 RVA: 0x00175A23 File Offset: 0x00173E23
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008536 RID: 34102 RVA: 0x00175A2C File Offset: 0x00173E2C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008537 RID: 34103 RVA: 0x00175A2E File Offset: 0x00173E2E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06008538 RID: 34104 RVA: 0x00175A30 File Offset: 0x00173E30
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06008539 RID: 34105 RVA: 0x00175A32 File Offset: 0x00173E32
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600853A RID: 34106 RVA: 0x00175A34 File Offset: 0x00173E34
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003FD3 RID: 16339
		public const uint MsgID = 601720U;

		// Token: 0x04003FD4 RID: 16340
		public uint Sequence;
	}
}
