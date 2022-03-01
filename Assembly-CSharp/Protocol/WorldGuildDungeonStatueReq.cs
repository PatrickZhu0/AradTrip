using System;

namespace Protocol
{
	// Token: 0x0200088E RID: 2190
	[Protocol]
	public class WorldGuildDungeonStatueReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600665E RID: 26206 RVA: 0x0012F7C8 File Offset: 0x0012DBC8
		public uint GetMsgID()
		{
			return 608510U;
		}

		// Token: 0x0600665F RID: 26207 RVA: 0x0012F7CF File Offset: 0x0012DBCF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006660 RID: 26208 RVA: 0x0012F7D7 File Offset: 0x0012DBD7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006661 RID: 26209 RVA: 0x0012F7E0 File Offset: 0x0012DBE0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006662 RID: 26210 RVA: 0x0012F7E2 File Offset: 0x0012DBE2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006663 RID: 26211 RVA: 0x0012F7E4 File Offset: 0x0012DBE4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006664 RID: 26212 RVA: 0x0012F7E6 File Offset: 0x0012DBE6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006665 RID: 26213 RVA: 0x0012F7E8 File Offset: 0x0012DBE8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002DCB RID: 11723
		public const uint MsgID = 608510U;

		// Token: 0x04002DCC RID: 11724
		public uint Sequence;
	}
}
