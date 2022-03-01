using System;

namespace Protocol
{
	// Token: 0x020009EE RID: 2542
	[Protocol]
	public class WorldMatchCancelReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600714A RID: 29002 RVA: 0x00146E5C File Offset: 0x0014525C
		public uint GetMsgID()
		{
			return 506702U;
		}

		// Token: 0x0600714B RID: 29003 RVA: 0x00146E63 File Offset: 0x00145263
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600714C RID: 29004 RVA: 0x00146E6B File Offset: 0x0014526B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600714D RID: 29005 RVA: 0x00146E74 File Offset: 0x00145274
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600714E RID: 29006 RVA: 0x00146E76 File Offset: 0x00145276
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600714F RID: 29007 RVA: 0x00146E78 File Offset: 0x00145278
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007150 RID: 29008 RVA: 0x00146E7A File Offset: 0x0014527A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007151 RID: 29009 RVA: 0x00146E7C File Offset: 0x0014527C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040033C5 RID: 13253
		public const uint MsgID = 506702U;

		// Token: 0x040033C6 RID: 13254
		public uint Sequence;
	}
}
