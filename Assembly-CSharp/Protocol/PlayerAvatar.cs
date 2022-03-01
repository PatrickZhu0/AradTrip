using System;

namespace Protocol
{
	// Token: 0x020006EA RID: 1770
	public class PlayerAvatar : IProtocolStream
	{
		// Token: 0x060059C5 RID: 22981 RVA: 0x00110A9C File Offset: 0x0010EE9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equipItemIds.Length);
			for (int i = 0; i < this.equipItemIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.equipItemIds[i]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.weaponStrengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.isShoWeapon);
		}

		// Token: 0x060059C6 RID: 22982 RVA: 0x00110B00 File Offset: 0x0010EF00
		public void decode(byte[] buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equipItemIds = new uint[(int)num];
			for (int i = 0; i < this.equipItemIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipItemIds[i]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.weaponStrengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShoWeapon);
		}

		// Token: 0x060059C7 RID: 22983 RVA: 0x00110B70 File Offset: 0x0010EF70
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equipItemIds.Length);
			for (int i = 0; i < this.equipItemIds.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.equipItemIds[i]);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.weaponStrengthen);
			BaseDLL.encode_int8(buffer, ref pos_, this.isShoWeapon);
		}

		// Token: 0x060059C8 RID: 22984 RVA: 0x00110BD4 File Offset: 0x0010EFD4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.equipItemIds = new uint[(int)num];
			for (int i = 0; i < this.equipItemIds.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.equipItemIds[i]);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.weaponStrengthen);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isShoWeapon);
		}

		// Token: 0x060059C9 RID: 22985 RVA: 0x00110C44 File Offset: 0x0010F044
		public int getLen()
		{
			int num = 0;
			num += 2 + 4 * this.equipItemIds.Length;
			num++;
			return num + 1;
		}

		// Token: 0x04002441 RID: 9281
		public uint[] equipItemIds = new uint[0];

		// Token: 0x04002442 RID: 9282
		public byte weaponStrengthen;

		// Token: 0x04002443 RID: 9283
		public byte isShoWeapon;
	}
}
