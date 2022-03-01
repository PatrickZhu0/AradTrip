using System;

namespace Protocol
{
	// Token: 0x02000A13 RID: 2579
	public class MonpolyCard : IProtocolStream
	{
		// Token: 0x06007270 RID: 29296 RVA: 0x0014B6A4 File Offset: 0x00149AA4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06007271 RID: 29297 RVA: 0x0014B6C2 File Offset: 0x00149AC2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007272 RID: 29298 RVA: 0x0014B6E0 File Offset: 0x00149AE0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06007273 RID: 29299 RVA: 0x0014B6FE File Offset: 0x00149AFE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007274 RID: 29300 RVA: 0x0014B71C File Offset: 0x00149B1C
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003495 RID: 13461
		public uint id;

		// Token: 0x04003496 RID: 13462
		public uint num;
	}
}
