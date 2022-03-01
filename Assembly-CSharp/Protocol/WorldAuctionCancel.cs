using System;

namespace Protocol
{
	// Token: 0x020006C5 RID: 1733
	[Protocol]
	public class WorldAuctionCancel : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600589C RID: 22684 RVA: 0x0010E208 File Offset: 0x0010C608
		public uint GetMsgID()
		{
			return 603909U;
		}

		// Token: 0x0600589D RID: 22685 RVA: 0x0010E20F File Offset: 0x0010C60F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600589E RID: 22686 RVA: 0x0010E217 File Offset: 0x0010C617
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600589F RID: 22687 RVA: 0x0010E220 File Offset: 0x0010C620
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x060058A0 RID: 22688 RVA: 0x0010E230 File Offset: 0x0010C630
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060058A1 RID: 22689 RVA: 0x0010E240 File Offset: 0x0010C640
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
		}

		// Token: 0x060058A2 RID: 22690 RVA: 0x0010E250 File Offset: 0x0010C650
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
		}

		// Token: 0x060058A3 RID: 22691 RVA: 0x0010E260 File Offset: 0x0010C660
		public int getLen()
		{
			int num = 0;
			return num + 8;
		}

		// Token: 0x04002393 RID: 9107
		public const uint MsgID = 603909U;

		// Token: 0x04002394 RID: 9108
		public uint Sequence;

		// Token: 0x04002395 RID: 9109
		public ulong id;
	}
}
