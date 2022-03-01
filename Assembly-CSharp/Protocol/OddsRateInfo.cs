using System;

namespace Protocol
{
	// Token: 0x02000734 RID: 1844
	public class OddsRateInfo : IProtocolStream
	{
		// Token: 0x06005C23 RID: 23587 RVA: 0x00116630 File Offset: 0x00114A30
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
		}

		// Token: 0x06005C24 RID: 23588 RVA: 0x0011664E File Offset: 0x00114A4E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
		}

		// Token: 0x06005C25 RID: 23589 RVA: 0x0011666C File Offset: 0x00114A6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
		}

		// Token: 0x06005C26 RID: 23590 RVA: 0x0011668A File Offset: 0x00114A8A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
		}

		// Token: 0x06005C27 RID: 23591 RVA: 0x001166A8 File Offset: 0x00114AA8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400259E RID: 9630
		public uint id;

		// Token: 0x0400259F RID: 9631
		public uint odds;
	}
}
