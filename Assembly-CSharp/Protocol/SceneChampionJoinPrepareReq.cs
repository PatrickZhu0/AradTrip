using System;

namespace Protocol
{
	// Token: 0x02000749 RID: 1865
	[Protocol]
	public class SceneChampionJoinPrepareReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005CBF RID: 23743 RVA: 0x001177C8 File Offset: 0x00115BC8
		public uint GetMsgID()
		{
			return 509804U;
		}

		// Token: 0x06005CC0 RID: 23744 RVA: 0x001177CF File Offset: 0x00115BCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005CC1 RID: 23745 RVA: 0x001177D7 File Offset: 0x00115BD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005CC2 RID: 23746 RVA: 0x001177E0 File Offset: 0x00115BE0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CC3 RID: 23747 RVA: 0x001177E2 File Offset: 0x00115BE2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005CC4 RID: 23748 RVA: 0x001177E4 File Offset: 0x00115BE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CC5 RID: 23749 RVA: 0x001177E6 File Offset: 0x00115BE6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005CC6 RID: 23750 RVA: 0x001177E8 File Offset: 0x00115BE8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002602 RID: 9730
		public const uint MsgID = 509804U;

		// Token: 0x04002603 RID: 9731
		public uint Sequence;
	}
}
