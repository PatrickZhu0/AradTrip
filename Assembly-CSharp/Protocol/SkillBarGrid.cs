using System;

namespace Protocol
{
	// Token: 0x02000B33 RID: 2867
	public class SkillBarGrid : IProtocolStream
	{
		// Token: 0x06007A9B RID: 31387 RVA: 0x0015FD58 File Offset: 0x0015E158
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.slot);
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
		}

		// Token: 0x06007A9C RID: 31388 RVA: 0x0015FD76 File Offset: 0x0015E176
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slot);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007A9D RID: 31389 RVA: 0x0015FD94 File Offset: 0x0015E194
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.slot);
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
		}

		// Token: 0x06007A9E RID: 31390 RVA: 0x0015FDB2 File Offset: 0x0015E1B2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slot);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
		}

		// Token: 0x06007A9F RID: 31391 RVA: 0x0015FDD0 File Offset: 0x0015E1D0
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 2;
		}

		// Token: 0x04003A24 RID: 14884
		public byte slot;

		// Token: 0x04003A25 RID: 14885
		public ushort id;
	}
}
