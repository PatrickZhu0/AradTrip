using System;

namespace Protocol
{
	// Token: 0x02000737 RID: 1847
	public class ShooterRecord : IProtocolStream
	{
		// Token: 0x06005C3B RID: 23611 RVA: 0x001168F0 File Offset: 0x00114CF0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.coutrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005C3C RID: 23612 RVA: 0x0011691C File Offset: 0x00114D1C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.coutrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005C3D RID: 23613 RVA: 0x00116948 File Offset: 0x00114D48
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.coutrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06005C3E RID: 23614 RVA: 0x00116974 File Offset: 0x00114D74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.coutrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06005C3F RID: 23615 RVA: 0x001169A0 File Offset: 0x00114DA0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025A6 RID: 9638
		public uint coutrId;

		// Token: 0x040025A7 RID: 9639
		public uint odds;

		// Token: 0x040025A8 RID: 9640
		public uint result;
	}
}
