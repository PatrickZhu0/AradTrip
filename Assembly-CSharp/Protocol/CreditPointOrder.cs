using System;

namespace Protocol
{
	// Token: 0x02000803 RID: 2051
	public class CreditPointOrder : IProtocolStream
	{
		// Token: 0x06006262 RID: 25186 RVA: 0x00125DFC File Offset: 0x001241FC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.getNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getTime);
		}

		// Token: 0x06006263 RID: 25187 RVA: 0x00125E1A File Offset: 0x0012421A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getTime);
		}

		// Token: 0x06006264 RID: 25188 RVA: 0x00125E38 File Offset: 0x00124238
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.getNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.getTime);
		}

		// Token: 0x06006265 RID: 25189 RVA: 0x00125E56 File Offset: 0x00124256
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.getTime);
		}

		// Token: 0x06006266 RID: 25190 RVA: 0x00125E74 File Offset: 0x00124274
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002B6F RID: 11119
		public uint getNum;

		// Token: 0x04002B70 RID: 11120
		public uint getTime;
	}
}
