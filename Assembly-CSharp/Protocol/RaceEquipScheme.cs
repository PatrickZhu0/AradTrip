using System;

namespace Protocol
{
	// Token: 0x020009F9 RID: 2553
	public class RaceEquipScheme : IProtocolStream
	{
		// Token: 0x06007192 RID: 29074 RVA: 0x00148660 File Offset: 0x00146A60
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isWear);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.equips[i]);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.title);
		}

		// Token: 0x06007193 RID: 29075 RVA: 0x001486E0 File Offset: 0x00146AE0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isWear);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equips = new ulong[(int)num];
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.equips[i]);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.title);
		}

		// Token: 0x06007194 RID: 29076 RVA: 0x0014876C File Offset: 0x00146B6C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.isWear);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.equips[i]);
			}
			BaseDLL.encode_uint64(buffer, ref pos_, this.title);
		}

		// Token: 0x06007195 RID: 29077 RVA: 0x001487EC File Offset: 0x00146BEC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isWear);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equips = new ulong[(int)num];
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.equips[i]);
			}
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.title);
		}

		// Token: 0x06007196 RID: 29078 RVA: 0x00148878 File Offset: 0x00146C78
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num++;
			num += 2 + 8 * this.equips.Length;
			return num + 8;
		}

		// Token: 0x04003406 RID: 13318
		public byte type;

		// Token: 0x04003407 RID: 13319
		public uint id;

		// Token: 0x04003408 RID: 13320
		public byte isWear;

		// Token: 0x04003409 RID: 13321
		public ulong[] equips = new ulong[0];

		// Token: 0x0400340A RID: 13322
		public ulong title;
	}
}
