using System;

namespace Protocol
{
	// Token: 0x0200087F RID: 2175
	[Protocol]
	public class WorldGuildDungeonInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065E9 RID: 26089 RVA: 0x0012E588 File Offset: 0x0012C988
		public uint GetMsgID()
		{
			return 608501U;
		}

		// Token: 0x060065EA RID: 26090 RVA: 0x0012E58F File Offset: 0x0012C98F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060065EB RID: 26091 RVA: 0x0012E597 File Offset: 0x0012C997
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060065EC RID: 26092 RVA: 0x0012E5A0 File Offset: 0x0012C9A0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060065ED RID: 26093 RVA: 0x0012E5A2 File Offset: 0x0012C9A2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060065EE RID: 26094 RVA: 0x0012E5A4 File Offset: 0x0012C9A4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060065EF RID: 26095 RVA: 0x0012E5A6 File Offset: 0x0012C9A6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060065F0 RID: 26096 RVA: 0x0012E5A8 File Offset: 0x0012C9A8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D9C RID: 11676
		public const uint MsgID = 608501U;

		// Token: 0x04002D9D RID: 11677
		public uint Sequence;
	}
}
