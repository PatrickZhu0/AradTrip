using System;

namespace Protocol
{
	// Token: 0x02000B04 RID: 2820
	[Protocol]
	public class SceneSynSelf : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600793C RID: 31036 RVA: 0x0015D738 File Offset: 0x0015BB38
		public uint GetMsgID()
		{
			return 500601U;
		}

		// Token: 0x0600793D RID: 31037 RVA: 0x0015D73F File Offset: 0x0015BB3F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600793E RID: 31038 RVA: 0x0015D747 File Offset: 0x0015BB47
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600793F RID: 31039 RVA: 0x0015D750 File Offset: 0x0015BB50
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007940 RID: 31040 RVA: 0x0015D752 File Offset: 0x0015BB52
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007941 RID: 31041 RVA: 0x0015D754 File Offset: 0x0015BB54
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007942 RID: 31042 RVA: 0x0015D756 File Offset: 0x0015BB56
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007943 RID: 31043 RVA: 0x0015D758 File Offset: 0x0015BB58
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003942 RID: 14658
		public const uint MsgID = 500601U;

		// Token: 0x04003943 RID: 14659
		public uint Sequence;
	}
}
