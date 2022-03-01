using System;

namespace Protocol
{
	// Token: 0x020009F7 RID: 2551
	public class RaceRetinue : IProtocolStream
	{
		// Token: 0x06007186 RID: 29062 RVA: 0x001482F4 File Offset: 0x001466F4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.star);
			BaseDLL.encode_int8(buffer, ref pos_, this.isMain);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffIds.Length);
			for (int i = 0; i < this.buffIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.buffIds[i]);
			}
		}

		// Token: 0x06007187 RID: 29063 RVA: 0x00148374 File Offset: 0x00146774
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.star);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isMain);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffIds = new uint[(int)num];
			for (int i = 0; i < this.buffIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffIds[i]);
			}
		}

		// Token: 0x06007188 RID: 29064 RVA: 0x00148400 File Offset: 0x00146800
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dataId);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_int8(buffer, ref pos_, this.star);
			BaseDLL.encode_int8(buffer, ref pos_, this.isMain);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffIds.Length);
			for (int i = 0; i < this.buffIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.buffIds[i]);
			}
		}

		// Token: 0x06007189 RID: 29065 RVA: 0x00148480 File Offset: 0x00146880
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dataId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.star);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isMain);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffIds = new uint[(int)num];
			for (int i = 0; i < this.buffIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.buffIds[i]);
			}
		}

		// Token: 0x0600718A RID: 29066 RVA: 0x0014850C File Offset: 0x0014690C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num++;
			num++;
			num++;
			return num + (2 + 4 * this.buffIds.Length);
		}

		// Token: 0x040033FD RID: 13309
		public uint dataId;

		// Token: 0x040033FE RID: 13310
		public byte level;

		// Token: 0x040033FF RID: 13311
		public byte star;

		// Token: 0x04003400 RID: 13312
		public byte isMain;

		// Token: 0x04003401 RID: 13313
		public uint[] buffIds = new uint[0];
	}
}
