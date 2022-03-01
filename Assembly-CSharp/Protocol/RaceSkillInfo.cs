using System;

namespace Protocol
{
	// Token: 0x020009F0 RID: 2544
	public class RaceSkillInfo : IProtocolStream
	{
		// Token: 0x0600715C RID: 29020 RVA: 0x00146F08 File Offset: 0x00145308
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.slot);
		}

		// Token: 0x0600715D RID: 29021 RVA: 0x00146F34 File Offset: 0x00145334
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slot);
		}

		// Token: 0x0600715E RID: 29022 RVA: 0x00146F60 File Offset: 0x00145360
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.slot);
		}

		// Token: 0x0600715F RID: 29023 RVA: 0x00146F8C File Offset: 0x0014538C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.slot);
		}

		// Token: 0x06007160 RID: 29024 RVA: 0x00146FB8 File Offset: 0x001453B8
		public int getLen()
		{
			int num = 0;
			num += 2;
			num++;
			return num + 1;
		}

		// Token: 0x040033CA RID: 13258
		public ushort id;

		// Token: 0x040033CB RID: 13259
		public byte level;

		// Token: 0x040033CC RID: 13260
		public byte slot;
	}
}
