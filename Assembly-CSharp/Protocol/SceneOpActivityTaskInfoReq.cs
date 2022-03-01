using System;

namespace Protocol
{
	// Token: 0x02000A39 RID: 2617
	[Protocol]
	public class SceneOpActivityTaskInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007366 RID: 29542 RVA: 0x0014F270 File Offset: 0x0014D670
		public uint GetMsgID()
		{
			return 501158U;
		}

		// Token: 0x06007367 RID: 29543 RVA: 0x0014F277 File Offset: 0x0014D677
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007368 RID: 29544 RVA: 0x0014F27F File Offset: 0x0014D67F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007369 RID: 29545 RVA: 0x0014F288 File Offset: 0x0014D688
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
		}

		// Token: 0x0600736A RID: 29546 RVA: 0x0014F298 File Offset: 0x0014D698
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
		}

		// Token: 0x0600736B RID: 29547 RVA: 0x0014F2A8 File Offset: 0x0014D6A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.opActId);
		}

		// Token: 0x0600736C RID: 29548 RVA: 0x0014F2B8 File Offset: 0x0014D6B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.opActId);
		}

		// Token: 0x0600736D RID: 29549 RVA: 0x0014F2C8 File Offset: 0x0014D6C8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003591 RID: 13713
		public const uint MsgID = 501158U;

		// Token: 0x04003592 RID: 13714
		public uint Sequence;

		// Token: 0x04003593 RID: 13715
		public uint opActId;
	}
}
