using System;

namespace Protocol
{
	// Token: 0x020009F6 RID: 2550
	public class RaceWarpStone : IProtocolStream
	{
		// Token: 0x06007180 RID: 29056 RVA: 0x00148250 File Offset: 0x00146650
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x06007181 RID: 29057 RVA: 0x0014826E File Offset: 0x0014666E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06007182 RID: 29058 RVA: 0x0014828C File Offset: 0x0014668C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x06007183 RID: 29059 RVA: 0x001482AA File Offset: 0x001466AA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06007184 RID: 29060 RVA: 0x001482C8 File Offset: 0x001466C8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x040033FB RID: 13307
		public uint id;

		// Token: 0x040033FC RID: 13308
		public byte level;
	}
}
