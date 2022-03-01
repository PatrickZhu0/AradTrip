using System;

namespace Protocol
{
	// Token: 0x020006E0 RID: 1760
	public class AuctionMagicOnsale : IProtocolStream
	{
		// Token: 0x0600598C RID: 22924 RVA: 0x0011020C File Offset: 0x0010E60C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x0600598D RID: 22925 RVA: 0x0011022A File Offset: 0x0010E62A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x0600598E RID: 22926 RVA: 0x00110248 File Offset: 0x0010E648
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.strength);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x0600598F RID: 22927 RVA: 0x00110266 File Offset: 0x0010E666
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.strength);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06005990 RID: 22928 RVA: 0x00110284 File Offset: 0x0010E684
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04002411 RID: 9233
		public byte strength;

		// Token: 0x04002412 RID: 9234
		public uint num;
	}
}
