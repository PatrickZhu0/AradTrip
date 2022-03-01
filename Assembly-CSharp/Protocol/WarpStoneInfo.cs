using System;

namespace Protocol
{
	// Token: 0x02000C1B RID: 3099
	public class WarpStoneInfo : IProtocolStream
	{
		// Token: 0x06008179 RID: 33145 RVA: 0x0016D89C File Offset: 0x0016BC9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.energy);
		}

		// Token: 0x0600817A RID: 33146 RVA: 0x0016D8C8 File Offset: 0x0016BCC8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.energy);
		}

		// Token: 0x0600817B RID: 33147 RVA: 0x0016D8F4 File Offset: 0x0016BCF4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.energy);
		}

		// Token: 0x0600817C RID: 33148 RVA: 0x0016D920 File Offset: 0x0016BD20
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.energy);
		}

		// Token: 0x0600817D RID: 33149 RVA: 0x0016D94C File Offset: 0x0016BD4C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			return num + 4;
		}

		// Token: 0x04003DCE RID: 15822
		public uint id;

		// Token: 0x04003DCF RID: 15823
		public byte level;

		// Token: 0x04003DD0 RID: 15824
		public uint energy;
	}
}
