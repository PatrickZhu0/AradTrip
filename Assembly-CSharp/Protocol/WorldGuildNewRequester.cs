using System;

namespace Protocol
{
	// Token: 0x02000833 RID: 2099
	[Protocol]
	public class WorldGuildNewRequester : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600633D RID: 25405 RVA: 0x0012A361 File Offset: 0x00128761
		public uint GetMsgID()
		{
			return 601911U;
		}

		// Token: 0x0600633E RID: 25406 RVA: 0x0012A368 File Offset: 0x00128768
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600633F RID: 25407 RVA: 0x0012A370 File Offset: 0x00128770
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006340 RID: 25408 RVA: 0x0012A379 File Offset: 0x00128779
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006341 RID: 25409 RVA: 0x0012A37B File Offset: 0x0012877B
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006342 RID: 25410 RVA: 0x0012A37D File Offset: 0x0012877D
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006343 RID: 25411 RVA: 0x0012A37F File Offset: 0x0012877F
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006344 RID: 25412 RVA: 0x0012A384 File Offset: 0x00128784
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002C93 RID: 11411
		public const uint MsgID = 601911U;

		// Token: 0x04002C94 RID: 11412
		public uint Sequence;
	}
}
