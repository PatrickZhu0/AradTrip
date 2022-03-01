using System;

namespace Protocol
{
	// Token: 0x02000754 RID: 1876
	[Protocol]
	public class SceneChampionStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D1F RID: 23839 RVA: 0x0011827A File Offset: 0x0011667A
		public uint GetMsgID()
		{
			return 509817U;
		}

		// Token: 0x06005D20 RID: 23840 RVA: 0x00118281 File Offset: 0x00116681
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D21 RID: 23841 RVA: 0x00118289 File Offset: 0x00116689
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D22 RID: 23842 RVA: 0x00118292 File Offset: 0x00116692
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D23 RID: 23843 RVA: 0x00118294 File Offset: 0x00116694
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D24 RID: 23844 RVA: 0x00118296 File Offset: 0x00116696
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D25 RID: 23845 RVA: 0x00118298 File Offset: 0x00116698
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D26 RID: 23846 RVA: 0x0011829C File Offset: 0x0011669C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400262D RID: 9773
		public const uint MsgID = 509817U;

		// Token: 0x0400262E RID: 9774
		public uint Sequence;
	}
}
