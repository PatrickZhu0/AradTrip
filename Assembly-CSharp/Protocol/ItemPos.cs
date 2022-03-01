using System;

namespace Protocol
{
	// Token: 0x020009A6 RID: 2470
	public class ItemPos : IProtocolStream
	{
		// Token: 0x06006F25 RID: 28453 RVA: 0x00141354 File Offset: 0x0013F754
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06006F26 RID: 28454 RVA: 0x00141372 File Offset: 0x0013F772
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06006F27 RID: 28455 RVA: 0x00141390 File Offset: 0x0013F790
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
		}

		// Token: 0x06006F28 RID: 28456 RVA: 0x001413AE File Offset: 0x0013F7AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
		}

		// Token: 0x06006F29 RID: 28457 RVA: 0x001413CC File Offset: 0x0013F7CC
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x0400326D RID: 12909
		public byte type;

		// Token: 0x0400326E RID: 12910
		public uint index;
	}
}
