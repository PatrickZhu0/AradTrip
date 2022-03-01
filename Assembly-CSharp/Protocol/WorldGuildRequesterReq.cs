using System;

namespace Protocol
{
	// Token: 0x02000831 RID: 2097
	[Protocol]
	public class WorldGuildRequesterReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600632B RID: 25387 RVA: 0x0012A175 File Offset: 0x00128575
		public uint GetMsgID()
		{
			return 601909U;
		}

		// Token: 0x0600632C RID: 25388 RVA: 0x0012A17C File Offset: 0x0012857C
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600632D RID: 25389 RVA: 0x0012A184 File Offset: 0x00128584
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600632E RID: 25390 RVA: 0x0012A18D File Offset: 0x0012858D
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600632F RID: 25391 RVA: 0x0012A18F File Offset: 0x0012858F
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006330 RID: 25392 RVA: 0x0012A191 File Offset: 0x00128591
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006331 RID: 25393 RVA: 0x0012A193 File Offset: 0x00128593
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006332 RID: 25394 RVA: 0x0012A198 File Offset: 0x00128598
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002C8E RID: 11406
		public const uint MsgID = 601909U;

		// Token: 0x04002C8F RID: 11407
		public uint Sequence;
	}
}
