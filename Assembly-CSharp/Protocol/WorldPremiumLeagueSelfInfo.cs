using System;

namespace Protocol
{
	// Token: 0x02000A6E RID: 2670
	[Protocol]
	public class WorldPremiumLeagueSelfInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600750D RID: 29965 RVA: 0x00152C4F File Offset: 0x0015104F
		public uint GetMsgID()
		{
			return 607708U;
		}

		// Token: 0x0600750E RID: 29966 RVA: 0x00152C56 File Offset: 0x00151056
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600750F RID: 29967 RVA: 0x00152C5E File Offset: 0x0015105E
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007510 RID: 29968 RVA: 0x00152C67 File Offset: 0x00151067
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007511 RID: 29969 RVA: 0x00152C76 File Offset: 0x00151076
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007512 RID: 29970 RVA: 0x00152C85 File Offset: 0x00151085
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06007513 RID: 29971 RVA: 0x00152C94 File Offset: 0x00151094
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06007514 RID: 29972 RVA: 0x00152CA4 File Offset: 0x001510A4
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04003670 RID: 13936
		public const uint MsgID = 607708U;

		// Token: 0x04003671 RID: 13937
		public uint Sequence;

		// Token: 0x04003672 RID: 13938
		public PremiumLeagueSelfInfo info = new PremiumLeagueSelfInfo();
	}
}
