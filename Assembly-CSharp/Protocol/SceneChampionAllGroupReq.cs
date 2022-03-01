using System;

namespace Protocol
{
	// Token: 0x0200076D RID: 1901
	[Protocol]
	public class SceneChampionAllGroupReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DEE RID: 24046 RVA: 0x00119E32 File Offset: 0x00118232
		public uint GetMsgID()
		{
			return 509832U;
		}

		// Token: 0x06005DEF RID: 24047 RVA: 0x00119E39 File Offset: 0x00118239
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DF0 RID: 24048 RVA: 0x00119E41 File Offset: 0x00118241
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DF1 RID: 24049 RVA: 0x00119E4A File Offset: 0x0011824A
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005DF2 RID: 24050 RVA: 0x00119E4C File Offset: 0x0011824C
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005DF3 RID: 24051 RVA: 0x00119E4E File Offset: 0x0011824E
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005DF4 RID: 24052 RVA: 0x00119E50 File Offset: 0x00118250
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005DF5 RID: 24053 RVA: 0x00119E54 File Offset: 0x00118254
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002685 RID: 9861
		public const uint MsgID = 509832U;

		// Token: 0x04002686 RID: 9862
		public uint Sequence;
	}
}
