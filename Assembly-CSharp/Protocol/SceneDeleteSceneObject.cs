using System;

namespace Protocol
{
	// Token: 0x02000B07 RID: 2823
	[Protocol]
	public class SceneDeleteSceneObject : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007957 RID: 31063 RVA: 0x0015D7E0 File Offset: 0x0015BBE0
		public uint GetMsgID()
		{
			return 500604U;
		}

		// Token: 0x06007958 RID: 31064 RVA: 0x0015D7E7 File Offset: 0x0015BBE7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007959 RID: 31065 RVA: 0x0015D7EF File Offset: 0x0015BBEF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600795A RID: 31066 RVA: 0x0015D7F8 File Offset: 0x0015BBF8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600795B RID: 31067 RVA: 0x0015D7FA File Offset: 0x0015BBFA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600795C RID: 31068 RVA: 0x0015D7FC File Offset: 0x0015BBFC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600795D RID: 31069 RVA: 0x0015D7FE File Offset: 0x0015BBFE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600795E RID: 31070 RVA: 0x0015D800 File Offset: 0x0015BC00
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003948 RID: 14664
		public const uint MsgID = 500604U;

		// Token: 0x04003949 RID: 14665
		public uint Sequence;
	}
}
