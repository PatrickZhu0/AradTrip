using System;

namespace Protocol
{
	// Token: 0x020008AE RID: 2222
	public class PvpStatistics : IProtocolStream
	{
		// Token: 0x0600676F RID: 26479 RVA: 0x001310E8 File Offset: 0x0012F4E8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pvpType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pvpCnt);
		}

		// Token: 0x06006770 RID: 26480 RVA: 0x00131106 File Offset: 0x0012F506
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pvpType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pvpCnt);
		}

		// Token: 0x06006771 RID: 26481 RVA: 0x00131124 File Offset: 0x0012F524
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.pvpType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pvpCnt);
		}

		// Token: 0x06006772 RID: 26482 RVA: 0x00131142 File Offset: 0x0012F542
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pvpType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pvpCnt);
		}

		// Token: 0x06006773 RID: 26483 RVA: 0x00131160 File Offset: 0x0012F560
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002E3B RID: 11835
		public uint pvpType;

		// Token: 0x04002E3C RID: 11836
		public uint pvpCnt;
	}
}
