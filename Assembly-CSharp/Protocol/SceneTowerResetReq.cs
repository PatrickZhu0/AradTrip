using System;

namespace Protocol
{
	// Token: 0x020007DB RID: 2011
	[Protocol]
	public class SceneTowerResetReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600611E RID: 24862 RVA: 0x001237D8 File Offset: 0x00121BD8
		public uint GetMsgID()
		{
			return 507207U;
		}

		// Token: 0x0600611F RID: 24863 RVA: 0x001237DF File Offset: 0x00121BDF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006120 RID: 24864 RVA: 0x001237E7 File Offset: 0x00121BE7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006121 RID: 24865 RVA: 0x001237F0 File Offset: 0x00121BF0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006122 RID: 24866 RVA: 0x001237F2 File Offset: 0x00121BF2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006123 RID: 24867 RVA: 0x001237F4 File Offset: 0x00121BF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006124 RID: 24868 RVA: 0x001237F6 File Offset: 0x00121BF6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006125 RID: 24869 RVA: 0x001237F8 File Offset: 0x00121BF8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400287D RID: 10365
		public const uint MsgID = 507207U;

		// Token: 0x0400287E RID: 10366
		public uint Sequence;
	}
}
