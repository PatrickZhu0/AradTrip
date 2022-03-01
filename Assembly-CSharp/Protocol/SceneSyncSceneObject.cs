using System;

namespace Protocol
{
	// Token: 0x02000B05 RID: 2821
	[Protocol]
	public class SceneSyncSceneObject : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007945 RID: 31045 RVA: 0x0015D770 File Offset: 0x0015BB70
		public uint GetMsgID()
		{
			return 500602U;
		}

		// Token: 0x06007946 RID: 31046 RVA: 0x0015D777 File Offset: 0x0015BB77
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007947 RID: 31047 RVA: 0x0015D77F File Offset: 0x0015BB7F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007948 RID: 31048 RVA: 0x0015D788 File Offset: 0x0015BB88
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007949 RID: 31049 RVA: 0x0015D78A File Offset: 0x0015BB8A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600794A RID: 31050 RVA: 0x0015D78C File Offset: 0x0015BB8C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600794B RID: 31051 RVA: 0x0015D78E File Offset: 0x0015BB8E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600794C RID: 31052 RVA: 0x0015D790 File Offset: 0x0015BB90
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003944 RID: 14660
		public const uint MsgID = 500602U;

		// Token: 0x04003945 RID: 14661
		public uint Sequence;
	}
}
