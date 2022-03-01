using System;

namespace Protocol
{
	// Token: 0x02000845 RID: 2117
	[Protocol]
	public class WorldGuildDonateLogReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060063DF RID: 25567 RVA: 0x0012B1F4 File Offset: 0x001295F4
		public uint GetMsgID()
		{
			return 601929U;
		}

		// Token: 0x060063E0 RID: 25568 RVA: 0x0012B1FB File Offset: 0x001295FB
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060063E1 RID: 25569 RVA: 0x0012B203 File Offset: 0x00129603
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060063E2 RID: 25570 RVA: 0x0012B20C File Offset: 0x0012960C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060063E3 RID: 25571 RVA: 0x0012B20E File Offset: 0x0012960E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060063E4 RID: 25572 RVA: 0x0012B210 File Offset: 0x00129610
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060063E5 RID: 25573 RVA: 0x0012B212 File Offset: 0x00129612
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060063E6 RID: 25574 RVA: 0x0012B214 File Offset: 0x00129614
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CD1 RID: 11473
		public const uint MsgID = 601929U;

		// Token: 0x04002CD2 RID: 11474
		public uint Sequence;
	}
}
