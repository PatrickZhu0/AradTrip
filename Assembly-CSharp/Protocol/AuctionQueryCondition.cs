using System;

namespace Protocol
{
	// Token: 0x020006BC RID: 1724
	public class AuctionQueryCondition : IProtocolStream
	{
		// Token: 0x06005854 RID: 22612 RVA: 0x0010CBC4 File Offset: 0x0010AFC4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.goodState);
			BaseDLL.encode_int8(buffer, ref pos_, this.itemMainType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemSubTypes.Length);
			for (int i = 0; i < this.itemSubTypes.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.itemSubTypes[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.excludeItemSubTypes.Length);
			for (int j = 0; j < this.excludeItemSubTypes.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.excludeItemSubTypes[j]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeID);
			BaseDLL.encode_int8(buffer, ref pos_, this.quality);
			BaseDLL.encode_int8(buffer, ref pos_, this.minLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.minStrength);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxStrength);
			BaseDLL.encode_int8(buffer, ref pos_, this.sortType);
			BaseDLL.encode_uint16(buffer, ref pos_, this.page);
			BaseDLL.encode_int8(buffer, ref pos_, this.itemNumPerPage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.couponStrengthToLev);
			BaseDLL.encode_int8(buffer, ref pos_, this.attent);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.occus.Length);
			for (int k = 0; k < this.occus.Length; k++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.occus[k]);
			}
		}

		// Token: 0x06005855 RID: 22613 RVA: 0x0010CD44 File Offset: 0x0010B144
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goodState);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.itemMainType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemSubTypes = new uint[(int)num];
			for (int i = 0; i < this.itemSubTypes.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemSubTypes[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.excludeItemSubTypes = new uint[(int)num2];
			for (int j = 0; j < this.excludeItemSubTypes.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.excludeItemSubTypes[j]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.quality);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.minLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.minStrength);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxStrength);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sortType);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.page);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.itemNumPerPage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.couponStrengthToLev);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.attent);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.occus = new byte[(int)num3];
			for (int k = 0; k < this.occus.Length; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.occus[k]);
			}
		}

		// Token: 0x06005856 RID: 22614 RVA: 0x0010CEEC File Offset: 0x0010B2EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_int8(buffer, ref pos_, this.goodState);
			BaseDLL.encode_int8(buffer, ref pos_, this.itemMainType);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.itemSubTypes.Length);
			for (int i = 0; i < this.itemSubTypes.Length; i++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.itemSubTypes[i]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.excludeItemSubTypes.Length);
			for (int j = 0; j < this.excludeItemSubTypes.Length; j++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.excludeItemSubTypes[j]);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.itemTypeID);
			BaseDLL.encode_int8(buffer, ref pos_, this.quality);
			BaseDLL.encode_int8(buffer, ref pos_, this.minLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxLevel);
			BaseDLL.encode_int8(buffer, ref pos_, this.minStrength);
			BaseDLL.encode_int8(buffer, ref pos_, this.maxStrength);
			BaseDLL.encode_int8(buffer, ref pos_, this.sortType);
			BaseDLL.encode_uint16(buffer, ref pos_, this.page);
			BaseDLL.encode_int8(buffer, ref pos_, this.itemNumPerPage);
			BaseDLL.encode_uint32(buffer, ref pos_, this.couponStrengthToLev);
			BaseDLL.encode_int8(buffer, ref pos_, this.attent);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.occus.Length);
			for (int k = 0; k < this.occus.Length; k++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.occus[k]);
			}
		}

		// Token: 0x06005857 RID: 22615 RVA: 0x0010D06C File Offset: 0x0010B46C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.goodState);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.itemMainType);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.itemSubTypes = new uint[(int)num];
			for (int i = 0; i < this.itemSubTypes.Length; i++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemSubTypes[i]);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.excludeItemSubTypes = new uint[(int)num2];
			for (int j = 0; j < this.excludeItemSubTypes.Length; j++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.excludeItemSubTypes[j]);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.itemTypeID);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.quality);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.minLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxLevel);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.minStrength);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.maxStrength);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.sortType);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.page);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.itemNumPerPage);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.couponStrengthToLev);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.attent);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.occus = new byte[(int)num3];
			for (int k = 0; k < this.occus.Length; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.occus[k]);
			}
		}

		// Token: 0x06005858 RID: 22616 RVA: 0x0010D214 File Offset: 0x0010B614
		public int getLen()
		{
			int num = 0;
			num++;
			num++;
			num++;
			num += 2 + 4 * this.itemSubTypes.Length;
			num += 2 + 4 * this.excludeItemSubTypes.Length;
			num += 4;
			num++;
			num++;
			num++;
			num++;
			num++;
			num++;
			num += 2;
			num++;
			num += 4;
			num++;
			return num + (2 + this.occus.Length);
		}

		// Token: 0x04002347 RID: 9031
		public byte type;

		// Token: 0x04002348 RID: 9032
		public byte goodState;

		// Token: 0x04002349 RID: 9033
		public byte itemMainType;

		// Token: 0x0400234A RID: 9034
		public uint[] itemSubTypes = new uint[0];

		// Token: 0x0400234B RID: 9035
		public uint[] excludeItemSubTypes = new uint[0];

		// Token: 0x0400234C RID: 9036
		public uint itemTypeID;

		// Token: 0x0400234D RID: 9037
		public byte quality;

		// Token: 0x0400234E RID: 9038
		public byte minLevel;

		// Token: 0x0400234F RID: 9039
		public byte maxLevel;

		// Token: 0x04002350 RID: 9040
		public byte minStrength;

		// Token: 0x04002351 RID: 9041
		public byte maxStrength;

		// Token: 0x04002352 RID: 9042
		public byte sortType;

		// Token: 0x04002353 RID: 9043
		public ushort page;

		// Token: 0x04002354 RID: 9044
		public byte itemNumPerPage;

		// Token: 0x04002355 RID: 9045
		public uint couponStrengthToLev;

		// Token: 0x04002356 RID: 9046
		public byte attent;

		// Token: 0x04002357 RID: 9047
		public byte[] occus = new byte[0];
	}
}
