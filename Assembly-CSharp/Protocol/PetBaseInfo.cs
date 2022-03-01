using System;

namespace Protocol
{
	// Token: 0x02000A4D RID: 2637
	public class PetBaseInfo : IProtocolStream
	{
		// Token: 0x06007411 RID: 29713 RVA: 0x00150A00 File Offset: 0x0014EE00
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint16(buffer, ref pos_, this.hunger);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.petScore);
		}

		// Token: 0x06007412 RID: 29714 RVA: 0x00150A54 File Offset: 0x0014EE54
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.hunger);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.petScore);
		}

		// Token: 0x06007413 RID: 29715 RVA: 0x00150AA8 File Offset: 0x0014EEA8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint16(buffer, ref pos_, this.hunger);
			BaseDLL.encode_int8(buffer, ref pos_, this.skillIndex);
			BaseDLL.encode_uint32(buffer, ref pos_, this.petScore);
		}

		// Token: 0x06007414 RID: 29716 RVA: 0x00150AFC File Offset: 0x0014EEFC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.hunger);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.skillIndex);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.petScore);
		}

		// Token: 0x06007415 RID: 29717 RVA: 0x00150B50 File Offset: 0x0014EF50
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 2;
			num += 2;
			num++;
			return num + 4;
		}

		// Token: 0x040035E5 RID: 13797
		public uint dataId;

		// Token: 0x040035E6 RID: 13798
		public ushort level;

		// Token: 0x040035E7 RID: 13799
		public ushort hunger;

		// Token: 0x040035E8 RID: 13800
		public byte skillIndex;

		// Token: 0x040035E9 RID: 13801
		public uint petScore;
	}
}
