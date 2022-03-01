using System;

namespace Protocol
{
	// Token: 0x0200088A RID: 2186
	[Protocol]
	public class WorldGuildDungeonLotteryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600663D RID: 26173 RVA: 0x0012F45D File Offset: 0x0012D85D
		public uint GetMsgID()
		{
			return 608507U;
		}

		// Token: 0x0600663E RID: 26174 RVA: 0x0012F464 File Offset: 0x0012D864
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600663F RID: 26175 RVA: 0x0012F46C File Offset: 0x0012D86C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006640 RID: 26176 RVA: 0x0012F475 File Offset: 0x0012D875
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006641 RID: 26177 RVA: 0x0012F477 File Offset: 0x0012D877
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006642 RID: 26178 RVA: 0x0012F479 File Offset: 0x0012D879
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006643 RID: 26179 RVA: 0x0012F47B File Offset: 0x0012D87B
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006644 RID: 26180 RVA: 0x0012F480 File Offset: 0x0012D880
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002DBF RID: 11711
		public const uint MsgID = 608507U;

		// Token: 0x04002DC0 RID: 11712
		public uint Sequence;
	}
}
