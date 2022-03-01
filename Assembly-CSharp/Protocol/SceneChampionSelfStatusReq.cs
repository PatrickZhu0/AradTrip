using System;

namespace Protocol
{
	// Token: 0x02000757 RID: 1879
	[Protocol]
	public class SceneChampionSelfStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D37 RID: 23863 RVA: 0x0011852E File Offset: 0x0011692E
		public uint GetMsgID()
		{
			return 509819U;
		}

		// Token: 0x06005D38 RID: 23864 RVA: 0x00118535 File Offset: 0x00116935
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D39 RID: 23865 RVA: 0x0011853D File Offset: 0x0011693D
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D3A RID: 23866 RVA: 0x00118546 File Offset: 0x00116946
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D3B RID: 23867 RVA: 0x00118548 File Offset: 0x00116948
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D3C RID: 23868 RVA: 0x0011854A File Offset: 0x0011694A
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D3D RID: 23869 RVA: 0x0011854C File Offset: 0x0011694C
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D3E RID: 23870 RVA: 0x00118550 File Offset: 0x00116950
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002639 RID: 9785
		public const uint MsgID = 509819U;

		// Token: 0x0400263A RID: 9786
		public uint Sequence;
	}
}
