using System;

namespace Protocol
{
	// Token: 0x0200075B RID: 1883
	[Protocol]
	public class SceneChampionGroupRankReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D5B RID: 23899 RVA: 0x00118700 File Offset: 0x00116B00
		public uint GetMsgID()
		{
			return 509823U;
		}

		// Token: 0x06005D5C RID: 23900 RVA: 0x00118707 File Offset: 0x00116B07
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D5D RID: 23901 RVA: 0x0011870F File Offset: 0x00116B0F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D5E RID: 23902 RVA: 0x00118718 File Offset: 0x00116B18
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D5F RID: 23903 RVA: 0x0011871A File Offset: 0x00116B1A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D60 RID: 23904 RVA: 0x0011871C File Offset: 0x00116B1C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D61 RID: 23905 RVA: 0x0011871E File Offset: 0x00116B1E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D62 RID: 23906 RVA: 0x00118720 File Offset: 0x00116B20
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002645 RID: 9797
		public const uint MsgID = 509823U;

		// Token: 0x04002646 RID: 9798
		public uint Sequence;
	}
}
