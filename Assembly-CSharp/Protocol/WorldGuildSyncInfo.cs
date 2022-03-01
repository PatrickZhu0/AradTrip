using System;

namespace Protocol
{
	// Token: 0x0200083A RID: 2106
	[Protocol]
	public class WorldGuildSyncInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600637C RID: 25468 RVA: 0x0012A763 File Offset: 0x00128B63
		public uint GetMsgID()
		{
			return 601918U;
		}

		// Token: 0x0600637D RID: 25469 RVA: 0x0012A76A File Offset: 0x00128B6A
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600637E RID: 25470 RVA: 0x0012A772 File Offset: 0x00128B72
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600637F RID: 25471 RVA: 0x0012A77B File Offset: 0x00128B7B
		public void encode(byte[] buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06006380 RID: 25472 RVA: 0x0012A78A File Offset: 0x00128B8A
		public void decode(byte[] buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06006381 RID: 25473 RVA: 0x0012A799 File Offset: 0x00128B99
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.info.encode(buffer, ref pos_);
		}

		// Token: 0x06006382 RID: 25474 RVA: 0x0012A7A8 File Offset: 0x00128BA8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.info.decode(buffer, ref pos_);
		}

		// Token: 0x06006383 RID: 25475 RVA: 0x0012A7B8 File Offset: 0x00128BB8
		public int getLen()
		{
			int num = 0;
			return num + this.info.getLen();
		}

		// Token: 0x04002CAB RID: 11435
		public const uint MsgID = 601918U;

		// Token: 0x04002CAC RID: 11436
		public uint Sequence;

		// Token: 0x04002CAD RID: 11437
		public GuildBaseInfo info = new GuildBaseInfo();
	}
}
