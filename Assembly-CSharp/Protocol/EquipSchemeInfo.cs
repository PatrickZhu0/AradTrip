using System;

namespace Protocol
{
	// Token: 0x020009A9 RID: 2473
	public class EquipSchemeInfo : IProtocolStream
	{
		// Token: 0x06006F3D RID: 28477 RVA: 0x0014156C File Offset: 0x0013F96C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.weared);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.equips[i]);
			}
		}

		// Token: 0x06006F3E RID: 28478 RVA: 0x001415EC File Offset: 0x0013F9EC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.weared);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equips = new ulong[(int)num];
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.equips[i]);
			}
		}

		// Token: 0x06006F3F RID: 28479 RVA: 0x00141678 File Offset: 0x0013FA78
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.guid);
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.weared);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.equips[i]);
			}
		}

		// Token: 0x06006F40 RID: 28480 RVA: 0x001416F8 File Offset: 0x0013FAF8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.guid);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.weared);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equips = new ulong[(int)num];
			for (int i = 0; i < this.equips.Length; i++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.equips[i]);
			}
		}

		// Token: 0x06006F41 RID: 28481 RVA: 0x00141784 File Offset: 0x0013FB84
		public int getLen()
		{
			int num = 0;
			num += 8;
			num++;
			num += 4;
			num++;
			return num + (2 + 8 * this.equips.Length);
		}

		// Token: 0x04003277 RID: 12919
		public ulong guid;

		// Token: 0x04003278 RID: 12920
		public byte type;

		// Token: 0x04003279 RID: 12921
		public uint id;

		// Token: 0x0400327A RID: 12922
		public byte weared;

		// Token: 0x0400327B RID: 12923
		public ulong[] equips = new ulong[0];
	}
}
