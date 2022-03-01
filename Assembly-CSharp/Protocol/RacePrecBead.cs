using System;

namespace Protocol
{
	// Token: 0x020009F2 RID: 2546
	public class RacePrecBead : IProtocolStream
	{
		// Token: 0x06007168 RID: 29032 RVA: 0x00147074 File Offset: 0x00145474
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
		}

		// Token: 0x06007169 RID: 29033 RVA: 0x00147092 File Offset: 0x00145492
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
		}

		// Token: 0x0600716A RID: 29034 RVA: 0x001470B0 File Offset: 0x001454B0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.preciousBeadId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buffId);
		}

		// Token: 0x0600716B RID: 29035 RVA: 0x001470CE File Offset: 0x001454CE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preciousBeadId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffId);
		}

		// Token: 0x0600716C RID: 29036 RVA: 0x001470EC File Offset: 0x001454EC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x040033CF RID: 13263
		public uint preciousBeadId;

		// Token: 0x040033D0 RID: 13264
		public uint buffId;
	}
}
