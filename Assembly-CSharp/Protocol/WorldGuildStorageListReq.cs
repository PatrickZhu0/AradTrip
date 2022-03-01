using System;

namespace Protocol
{
	// Token: 0x0200086E RID: 2158
	[Protocol]
	public class WorldGuildStorageListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006550 RID: 25936 RVA: 0x0012D4D8 File Offset: 0x0012B8D8
		public uint GetMsgID()
		{
			return 601969U;
		}

		// Token: 0x06006551 RID: 25937 RVA: 0x0012D4DF File Offset: 0x0012B8DF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006552 RID: 25938 RVA: 0x0012D4E7 File Offset: 0x0012B8E7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006553 RID: 25939 RVA: 0x0012D4F0 File Offset: 0x0012B8F0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006554 RID: 25940 RVA: 0x0012D4F2 File Offset: 0x0012B8F2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006555 RID: 25941 RVA: 0x0012D4F4 File Offset: 0x0012B8F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006556 RID: 25942 RVA: 0x0012D4F6 File Offset: 0x0012B8F6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006557 RID: 25943 RVA: 0x0012D4F8 File Offset: 0x0012B8F8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D66 RID: 11622
		public const uint MsgID = 601969U;

		// Token: 0x04002D67 RID: 11623
		public uint Sequence;
	}
}
