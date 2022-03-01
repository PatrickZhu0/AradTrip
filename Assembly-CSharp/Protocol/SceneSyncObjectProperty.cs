using System;

namespace Protocol
{
	// Token: 0x02000B06 RID: 2822
	[Protocol]
	public class SceneSyncObjectProperty : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600794E RID: 31054 RVA: 0x0015D7A8 File Offset: 0x0015BBA8
		public uint GetMsgID()
		{
			return 500603U;
		}

		// Token: 0x0600794F RID: 31055 RVA: 0x0015D7AF File Offset: 0x0015BBAF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007950 RID: 31056 RVA: 0x0015D7B7 File Offset: 0x0015BBB7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007951 RID: 31057 RVA: 0x0015D7C0 File Offset: 0x0015BBC0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007952 RID: 31058 RVA: 0x0015D7C2 File Offset: 0x0015BBC2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007953 RID: 31059 RVA: 0x0015D7C4 File Offset: 0x0015BBC4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007954 RID: 31060 RVA: 0x0015D7C6 File Offset: 0x0015BBC6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007955 RID: 31061 RVA: 0x0015D7C8 File Offset: 0x0015BBC8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003946 RID: 14662
		public const uint MsgID = 500603U;

		// Token: 0x04003947 RID: 14663
		public uint Sequence;
	}
}
