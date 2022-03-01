using System;

namespace Protocol
{
	// Token: 0x02000C8E RID: 3214
	public class PlayerWatchInfo : IProtocolStream
	{
		// Token: 0x060084BB RID: 33979 RVA: 0x001742CC File Offset: 0x001726CC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int i = 0; i < this.equips.Length; i++)
			{
				this.equips[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.fashionEquips.Length);
			for (int j = 0; j < this.fashionEquips.Length; j++)
			{
				this.fashionEquips[j].encode(buffer, ref pos_);
			}
			this.retinue.encode(buffer, ref pos_);
			this.pkInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.matchScore);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			this.guildTitle.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pets.Length);
			for (int k = 0; k < this.pets.Length; k++)
			{
				this.pets[k].encode(buffer, ref pos_);
			}
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.playerLabelInfo.encode(buffer, ref pos_);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.adventureTeamGrade);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamRanking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.emblemLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalEquipScore);
		}

		// Token: 0x060084BC RID: 33980 RVA: 0x00174500 File Offset: 0x00172900
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.equips = new ItemBaseInfo[(int)num2];
			for (int j = 0; j < this.equips.Length; j++)
			{
				this.equips[j] = new ItemBaseInfo();
				this.equips[j].decode(buffer, ref pos_);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.fashionEquips = new ItemBaseInfo[(int)num3];
			for (int k = 0; k < this.fashionEquips.Length; k++)
			{
				this.fashionEquips[k] = new ItemBaseInfo();
				this.fashionEquips[k].decode(buffer, ref pos_);
			}
			this.retinue.decode(buffer, ref pos_);
			this.pkInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.matchScore);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			this.guildTitle.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.pets = new PetBaseInfo[(int)num4];
			for (int l = 0; l < this.pets.Length; l++)
			{
				this.pets[l] = new PetBaseInfo();
				this.pets[l].decode(buffer, ref pos_);
			}
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array2 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[m]);
			}
			this.declaration = StringHelper.BytesToString(array2);
			this.playerLabelInfo.decode(buffer, ref pos_);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			byte[] array3 = new byte[(int)num6];
			for (int n = 0; n < (int)num6; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[n]);
			}
			this.adventureTeamName = StringHelper.BytesToString(array3);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			byte[] array4 = new byte[(int)num7];
			for (int num8 = 0; num8 < (int)num7; num8++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[num8]);
			}
			this.adventureTeamGrade = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamRanking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.emblemLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalEquipScore);
		}

		// Token: 0x060084BD RID: 33981 RVA: 0x00174830 File Offset: 0x00172C30
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occu);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int i = 0; i < this.equips.Length; i++)
			{
				this.equips[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.fashionEquips.Length);
			for (int j = 0; j < this.fashionEquips.Length; j++)
			{
				this.fashionEquips[j].encode(buffer, ref pos_);
			}
			this.retinue.encode(buffer, ref pos_);
			this.pkInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.matchScore);
			BaseDLL.encode_int8(buffer, ref pos_, this.vipLevel);
			this.guildTitle.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pets.Length);
			for (int k = 0; k < this.pets.Length; k++)
			{
				this.pets[k].encode(buffer, ref pos_);
			}
			this.avatar.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.activeTimeType);
			BaseDLL.encode_int8(buffer, ref pos_, this.masterType);
			BaseDLL.encode_int8(buffer, ref pos_, this.regionId);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			this.playerLabelInfo.encode(buffer, ref pos_);
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.adventureTeamGrade);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.adventureTeamRanking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.emblemLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalEquipScore);
		}

		// Token: 0x060084BE RID: 33982 RVA: 0x00174A70 File Offset: 0x00172E70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.id);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.name = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occu);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.equips = new ItemBaseInfo[(int)num2];
			for (int j = 0; j < this.equips.Length; j++)
			{
				this.equips[j] = new ItemBaseInfo();
				this.equips[j].decode(buffer, ref pos_);
			}
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.fashionEquips = new ItemBaseInfo[(int)num3];
			for (int k = 0; k < this.fashionEquips.Length; k++)
			{
				this.fashionEquips[k] = new ItemBaseInfo();
				this.fashionEquips[k].decode(buffer, ref pos_);
			}
			this.retinue.decode(buffer, ref pos_);
			this.pkInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.matchScore);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.vipLevel);
			this.guildTitle.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.pets = new PetBaseInfo[(int)num4];
			for (int l = 0; l < this.pets.Length; l++)
			{
				this.pets[l] = new PetBaseInfo();
				this.pets[l].decode(buffer, ref pos_);
			}
			this.avatar.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.activeTimeType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.masterType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.regionId);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			byte[] array2 = new byte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[m]);
			}
			this.declaration = StringHelper.BytesToString(array2);
			this.playerLabelInfo.decode(buffer, ref pos_);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			byte[] array3 = new byte[(int)num6];
			for (int n = 0; n < (int)num6; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[n]);
			}
			this.adventureTeamName = StringHelper.BytesToString(array3);
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			byte[] array4 = new byte[(int)num7];
			for (int num8 = 0; num8 < (int)num7; num8++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[num8]);
			}
			this.adventureTeamGrade = StringHelper.BytesToString(array4);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.adventureTeamRanking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.emblemLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalEquipScore);
		}

		// Token: 0x060084BF RID: 33983 RVA: 0x00174DA0 File Offset: 0x001731A0
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 2;
			num += 2;
			for (int i = 0; i < this.equips.Length; i++)
			{
				num += this.equips[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.fashionEquips.Length; j++)
			{
				num += this.fashionEquips[j].getLen();
			}
			num += this.retinue.getLen();
			num += this.pkInfo.getLen();
			num += 4;
			num += 4;
			num++;
			num += this.guildTitle.getLen();
			num += 4;
			num += 4;
			num += 2;
			for (int k = 0; k < this.pets.Length; k++)
			{
				num += this.pets[k].getLen();
			}
			num += this.avatar.getLen();
			num++;
			num++;
			num++;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.declaration);
			num += 2 + array2.Length;
			num += this.playerLabelInfo.getLen();
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.adventureTeamName);
			num += 2 + array3.Length;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.adventureTeamGrade);
			num += 2 + array4.Length;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003F8F RID: 16271
		public ulong id;

		// Token: 0x04003F90 RID: 16272
		public string name;

		// Token: 0x04003F91 RID: 16273
		public byte occu;

		// Token: 0x04003F92 RID: 16274
		public ushort level;

		// Token: 0x04003F93 RID: 16275
		public ItemBaseInfo[] equips = new ItemBaseInfo[0];

		// Token: 0x04003F94 RID: 16276
		public ItemBaseInfo[] fashionEquips = new ItemBaseInfo[0];

		// Token: 0x04003F95 RID: 16277
		public RetinueInfo retinue = new RetinueInfo();

		// Token: 0x04003F96 RID: 16278
		public PkStatisticInfo pkInfo = new PkStatisticInfo();

		// Token: 0x04003F97 RID: 16279
		public uint pkValue;

		// Token: 0x04003F98 RID: 16280
		public uint matchScore;

		// Token: 0x04003F99 RID: 16281
		public byte vipLevel;

		// Token: 0x04003F9A RID: 16282
		public GuildTitle guildTitle = new GuildTitle();

		// Token: 0x04003F9B RID: 16283
		public uint seasonLevel;

		// Token: 0x04003F9C RID: 16284
		public uint seasonStar;

		// Token: 0x04003F9D RID: 16285
		public PetBaseInfo[] pets = new PetBaseInfo[0];

		// Token: 0x04003F9E RID: 16286
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04003F9F RID: 16287
		public byte activeTimeType;

		// Token: 0x04003FA0 RID: 16288
		public byte masterType;

		// Token: 0x04003FA1 RID: 16289
		public byte regionId;

		// Token: 0x04003FA2 RID: 16290
		public string declaration;

		// Token: 0x04003FA3 RID: 16291
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();

		// Token: 0x04003FA4 RID: 16292
		public string adventureTeamName;

		// Token: 0x04003FA5 RID: 16293
		public string adventureTeamGrade;

		// Token: 0x04003FA6 RID: 16294
		public uint adventureTeamRanking;

		// Token: 0x04003FA7 RID: 16295
		public uint emblemLevel;

		// Token: 0x04003FA8 RID: 16296
		public uint totalEquipScore;
	}
}
