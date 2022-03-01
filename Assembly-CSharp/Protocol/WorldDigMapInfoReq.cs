using System;

namespace Protocol
{
	// Token: 0x020007A0 RID: 1952
	[Protocol]
	public class WorldDigMapInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005F74 RID: 24436 RVA: 0x0011DC64 File Offset: 0x0011C064
		public uint GetMsgID()
		{
			return 608213U;
		}

		// Token: 0x06005F75 RID: 24437 RVA: 0x0011DC6B File Offset: 0x0011C06B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005F76 RID: 24438 RVA: 0x0011DC73 File Offset: 0x0011C073
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005F77 RID: 24439 RVA: 0x0011DC7C File Offset: 0x0011C07C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005F78 RID: 24440 RVA: 0x0011DC7E File Offset: 0x0011C07E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005F79 RID: 24441 RVA: 0x0011DC80 File Offset: 0x0011C080
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005F7A RID: 24442 RVA: 0x0011DC82 File Offset: 0x0011C082
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005F7B RID: 24443 RVA: 0x0011DC84 File Offset: 0x0011C084
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002768 RID: 10088
		public const uint MsgID = 608213U;

		// Token: 0x04002769 RID: 10089
		public uint Sequence;
	}
}
