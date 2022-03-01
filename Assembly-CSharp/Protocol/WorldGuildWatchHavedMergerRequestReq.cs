using System;

namespace Protocol
{
	// Token: 0x020008A1 RID: 2209
	[Protocol]
	public class WorldGuildWatchHavedMergerRequestReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006706 RID: 26374 RVA: 0x00130884 File Offset: 0x0012EC84
		public uint GetMsgID()
		{
			return 601983U;
		}

		// Token: 0x06006707 RID: 26375 RVA: 0x0013088B File Offset: 0x0012EC8B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006708 RID: 26376 RVA: 0x00130893 File Offset: 0x0012EC93
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006709 RID: 26377 RVA: 0x0013089C File Offset: 0x0012EC9C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600670A RID: 26378 RVA: 0x0013089E File Offset: 0x0012EC9E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600670B RID: 26379 RVA: 0x001308A0 File Offset: 0x0012ECA0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600670C RID: 26380 RVA: 0x001308A2 File Offset: 0x0012ECA2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600670D RID: 26381 RVA: 0x001308A4 File Offset: 0x0012ECA4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002E10 RID: 11792
		public const uint MsgID = 601983U;

		// Token: 0x04002E11 RID: 11793
		public uint Sequence;
	}
}
