using System;

namespace Protocol
{
	// Token: 0x0200076C RID: 1900
	[Protocol]
	public class SceneChampionGroupStatusSync : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005DE5 RID: 24037 RVA: 0x00119DB7 File Offset: 0x001181B7
		public uint GetMsgID()
		{
			return 509831U;
		}

		// Token: 0x06005DE6 RID: 24038 RVA: 0x00119DBE File Offset: 0x001181BE
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005DE7 RID: 24039 RVA: 0x00119DC6 File Offset: 0x001181C6
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005DE8 RID: 24040 RVA: 0x00119DCF File Offset: 0x001181CF
		public void encode(byte[] buffer, ref int pos_)
		{
			this.group.encode(buffer, ref pos_);
		}

		// Token: 0x06005DE9 RID: 24041 RVA: 0x00119DDE File Offset: 0x001181DE
		public void decode(byte[] buffer, ref int pos_)
		{
			this.group.decode(buffer, ref pos_);
		}

		// Token: 0x06005DEA RID: 24042 RVA: 0x00119DED File Offset: 0x001181ED
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.group.encode(buffer, ref pos_);
		}

		// Token: 0x06005DEB RID: 24043 RVA: 0x00119DFC File Offset: 0x001181FC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.group.decode(buffer, ref pos_);
		}

		// Token: 0x06005DEC RID: 24044 RVA: 0x00119E0C File Offset: 0x0011820C
		public int getLen()
		{
			int num = 0;
			return num + this.group.getLen();
		}

		// Token: 0x04002682 RID: 9858
		public const uint MsgID = 509831U;

		// Token: 0x04002683 RID: 9859
		public uint Sequence;

		// Token: 0x04002684 RID: 9860
		public ChampionGroup group = new ChampionGroup();
	}
}
