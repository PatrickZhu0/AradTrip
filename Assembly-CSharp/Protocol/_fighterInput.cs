using System;

namespace Protocol
{
	// Token: 0x02000A90 RID: 2704
	public class _fighterInput : IProtocolStream
	{
		// Token: 0x06007609 RID: 30217 RVA: 0x0015534B File Offset: 0x0015374B
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			this.input.encode(buffer, ref pos_);
		}

		// Token: 0x0600760A RID: 30218 RVA: 0x00155368 File Offset: 0x00153768
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			this.input.decode(buffer, ref pos_);
		}

		// Token: 0x0600760B RID: 30219 RVA: 0x00155385 File Offset: 0x00153785
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			this.input.encode(buffer, ref pos_);
		}

		// Token: 0x0600760C RID: 30220 RVA: 0x001553A2 File Offset: 0x001537A2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			this.input.decode(buffer, ref pos_);
		}

		// Token: 0x0600760D RID: 30221 RVA: 0x001553C0 File Offset: 0x001537C0
		public int getLen()
		{
			int num = 0;
			num++;
			return num + this.input.getLen();
		}

		// Token: 0x0400371D RID: 14109
		public byte seat;

		// Token: 0x0400371E RID: 14110
		public _inputData input = new _inputData();
	}
}
