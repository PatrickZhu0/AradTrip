using System;

namespace Protocol
{
	// Token: 0x020009F8 RID: 2552
	public class RacePet : IProtocolStream
	{
		// Token: 0x0600718C RID: 29068 RVA: 0x00148543 File Offset: 0x00146943
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint16(buffer, ref pos_, this.hunger);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
		}

		// Token: 0x0600718D RID: 29069 RVA: 0x0014857D File Offset: 0x0014697D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.hunger);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
		}

		// Token: 0x0600718E RID: 29070 RVA: 0x001485B7 File Offset: 0x001469B7
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint16(buffer, ref pos_, this.hunger);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
		}

		// Token: 0x0600718F RID: 29071 RVA: 0x001485F1 File Offset: 0x001469F1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.hunger);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
		}

		// Token: 0x06007190 RID: 29072 RVA: 0x0014862C File Offset: 0x00146A2C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			num += 2;
			return num + 1;
		}

		// Token: 0x04003402 RID: 13314
		public uint dataId;

		// Token: 0x04003403 RID: 13315
		public ushort level;

		// Token: 0x04003404 RID: 13316
		public ushort hunger;

		// Token: 0x04003405 RID: 13317
		public byte skillIndex;
	}
}
