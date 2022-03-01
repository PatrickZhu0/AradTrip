using System;

namespace Protocol
{
	// Token: 0x02000759 RID: 1881
	[Protocol]
	public class SceneChampionSelfBattleRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005D49 RID: 23881 RVA: 0x001185DC File Offset: 0x001169DC
		public uint GetMsgID()
		{
			return 509821U;
		}

		// Token: 0x06005D4A RID: 23882 RVA: 0x001185E3 File Offset: 0x001169E3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005D4B RID: 23883 RVA: 0x001185EB File Offset: 0x001169EB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005D4C RID: 23884 RVA: 0x001185F4 File Offset: 0x001169F4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D4D RID: 23885 RVA: 0x001185F6 File Offset: 0x001169F6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005D4E RID: 23886 RVA: 0x001185F8 File Offset: 0x001169F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D4F RID: 23887 RVA: 0x001185FA File Offset: 0x001169FA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005D50 RID: 23888 RVA: 0x001185FC File Offset: 0x001169FC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400263E RID: 9790
		public const uint MsgID = 509821U;

		// Token: 0x0400263F RID: 9791
		public uint Sequence;
	}
}
