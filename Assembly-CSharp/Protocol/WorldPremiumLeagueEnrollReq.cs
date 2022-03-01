using System;

namespace Protocol
{
	// Token: 0x02000A6A RID: 2666
	[Protocol]
	public class WorldPremiumLeagueEnrollReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060074E9 RID: 29929 RVA: 0x001528F5 File Offset: 0x00150CF5
		public uint GetMsgID()
		{
			return 607704U;
		}

		// Token: 0x060074EA RID: 29930 RVA: 0x001528FC File Offset: 0x00150CFC
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060074EB RID: 29931 RVA: 0x00152904 File Offset: 0x00150D04
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060074EC RID: 29932 RVA: 0x0015290D File Offset: 0x00150D0D
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060074ED RID: 29933 RVA: 0x0015290F File Offset: 0x00150D0F
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060074EE RID: 29934 RVA: 0x00152911 File Offset: 0x00150D11
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060074EF RID: 29935 RVA: 0x00152913 File Offset: 0x00150D13
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060074F0 RID: 29936 RVA: 0x00152918 File Offset: 0x00150D18
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003663 RID: 13923
		public const uint MsgID = 607704U;

		// Token: 0x04003664 RID: 13924
		public uint Sequence;
	}
}
