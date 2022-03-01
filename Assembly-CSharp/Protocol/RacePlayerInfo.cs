using System;

namespace Protocol
{
	// Token: 0x020009FA RID: 2554
	public class RacePlayerInfo : IProtocolStream
	{
		// Token: 0x06007198 RID: 29080 RVA: 0x00148958 File Offset: 0x00146D58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.robotAIType);
			BaseDLL.encode_int8(buffer, ref pos_, this.robotHard);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occupation);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.matchScore);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonAttr);
			BaseDLL.encode_int8(buffer, ref pos_, this.monthcard);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int j = 0; j < this.equips.Length; j++)
			{
				this.equips[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.raceItems.Length);
			for (int k = 0; k < this.raceItems.Length; k++)
			{
				this.raceItems[k].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffs.Length);
			for (int l = 0; l < this.buffs.Length; l++)
			{
				this.buffs[l].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.warpStones.Length);
			for (int m = 0; m < this.warpStones.Length; m++)
			{
				this.warpStones[m].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.retinues.Length);
			for (int n = 0; n < this.retinues.Length; n++)
			{
				this.retinues[n].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pets.Length);
			for (int num = 0; num < this.pets.Length; num++)
			{
				this.pets[num].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.potionPos.Length);
			for (int num2 = 0; num2 < this.potionPos.Length; num2++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.potionPos[num2]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.secondWeapons.Length);
			for (int num3 = 0; num3 < this.secondWeapons.Length; num3++)
			{
				this.secondWeapons[num3].encode(buffer, ref pos_);
			}
			this.avatar.encode(buffer, ref pos_);
			this.playerLabelInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equipScheme.Length);
			for (int num4 = 0; num4 < this.equipScheme.Length; num4++)
			{
				this.equipScheme[num4].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.wearingEqIds.Length);
			for (int num5 = 0; num5 < this.wearingEqIds.Length; num5++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.wearingEqIds[num5]);
			}
		}

		// Token: 0x06007199 RID: 29081 RVA: 0x00148D5C File Offset: 0x0014715C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.serverName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.robotAIType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.robotHard);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.name = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.guildName = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupation);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.matchScore);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonAttr);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.monthcard);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.skills = new RaceSkillInfo[(int)num4];
			for (int l = 0; l < this.skills.Length; l++)
			{
				this.skills[l] = new RaceSkillInfo();
				this.skills[l].decode(buffer, ref pos_);
			}
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.equips = new RaceEquip[(int)num5];
			for (int m = 0; m < this.equips.Length; m++)
			{
				this.equips[m] = new RaceEquip();
				this.equips[m].decode(buffer, ref pos_);
			}
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.raceItems = new RaceItem[(int)num6];
			for (int n = 0; n < this.raceItems.Length; n++)
			{
				this.raceItems[n] = new RaceItem();
				this.raceItems[n].decode(buffer, ref pos_);
			}
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			this.buffs = new RaceBuffInfo[(int)num7];
			for (int num8 = 0; num8 < this.buffs.Length; num8++)
			{
				this.buffs[num8] = new RaceBuffInfo();
				this.buffs[num8].decode(buffer, ref pos_);
			}
			ushort num9 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num9);
			this.warpStones = new RaceWarpStone[(int)num9];
			for (int num10 = 0; num10 < this.warpStones.Length; num10++)
			{
				this.warpStones[num10] = new RaceWarpStone();
				this.warpStones[num10].decode(buffer, ref pos_);
			}
			ushort num11 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num11);
			this.retinues = new RaceRetinue[(int)num11];
			for (int num12 = 0; num12 < this.retinues.Length; num12++)
			{
				this.retinues[num12] = new RaceRetinue();
				this.retinues[num12].decode(buffer, ref pos_);
			}
			ushort num13 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num13);
			this.pets = new RacePet[(int)num13];
			for (int num14 = 0; num14 < this.pets.Length; num14++)
			{
				this.pets[num14] = new RacePet();
				this.pets[num14].decode(buffer, ref pos_);
			}
			ushort num15 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num15);
			this.potionPos = new uint[(int)num15];
			for (int num16 = 0; num16 < this.potionPos.Length; num16++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.potionPos[num16]);
			}
			ushort num17 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num17);
			this.secondWeapons = new RaceEquip[(int)num17];
			for (int num18 = 0; num18 < this.secondWeapons.Length; num18++)
			{
				this.secondWeapons[num18] = new RaceEquip();
				this.secondWeapons[num18].decode(buffer, ref pos_);
			}
			this.avatar.decode(buffer, ref pos_);
			this.playerLabelInfo.decode(buffer, ref pos_);
			ushort num19 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num19);
			this.equipScheme = new RaceEquipScheme[(int)num19];
			for (int num20 = 0; num20 < this.equipScheme.Length; num20++)
			{
				this.equipScheme[num20] = new RaceEquipScheme();
				this.equipScheme[num20].decode(buffer, ref pos_);
			}
			ushort num21 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num21);
			this.wearingEqIds = new ulong[(int)num21];
			for (int num22 = 0; num22 < this.wearingEqIds.Length; num22++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.wearingEqIds[num22]);
			}
		}

		// Token: 0x0600719A RID: 29082 RVA: 0x001492CC File Offset: 0x001476CC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.zoneId);
			byte[] str = StringHelper.StringToUTF8Bytes(this.serverName);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.robotAIType);
			BaseDLL.encode_int8(buffer, ref pos_, this.robotHard);
			BaseDLL.encode_uint64(buffer, ref pos_, this.roleId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.accid);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.guildName);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.occupation);
			BaseDLL.encode_uint16(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.pkValue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.matchScore);
			BaseDLL.encode_int8(buffer, ref pos_, this.seat);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainHp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.remainMp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.seasonStar);
			BaseDLL.encode_int8(buffer, ref pos_, this.seasonAttr);
			BaseDLL.encode_int8(buffer, ref pos_, this.monthcard);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.skills.Length);
			for (int i = 0; i < this.skills.Length; i++)
			{
				this.skills[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equips.Length);
			for (int j = 0; j < this.equips.Length; j++)
			{
				this.equips[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.raceItems.Length);
			for (int k = 0; k < this.raceItems.Length; k++)
			{
				this.raceItems[k].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffs.Length);
			for (int l = 0; l < this.buffs.Length; l++)
			{
				this.buffs[l].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.warpStones.Length);
			for (int m = 0; m < this.warpStones.Length; m++)
			{
				this.warpStones[m].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.retinues.Length);
			for (int n = 0; n < this.retinues.Length; n++)
			{
				this.retinues[n].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.pets.Length);
			for (int num = 0; num < this.pets.Length; num++)
			{
				this.pets[num].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.potionPos.Length);
			for (int num2 = 0; num2 < this.potionPos.Length; num2++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.potionPos[num2]);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.secondWeapons.Length);
			for (int num3 = 0; num3 < this.secondWeapons.Length; num3++)
			{
				this.secondWeapons[num3].encode(buffer, ref pos_);
			}
			this.avatar.encode(buffer, ref pos_);
			this.playerLabelInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.equipScheme.Length);
			for (int num4 = 0; num4 < this.equipScheme.Length; num4++)
			{
				this.equipScheme[num4].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.wearingEqIds.Length);
			for (int num5 = 0; num5 < this.wearingEqIds.Length; num5++)
			{
				BaseDLL.encode_uint64(buffer, ref pos_, this.wearingEqIds[num5]);
			}
		}

		// Token: 0x0600719B RID: 29083 RVA: 0x001496D8 File Offset: 0x00147AD8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.zoneId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			byte[] array = new byte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array[i]);
			}
			this.serverName = StringHelper.BytesToString(array);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.robotAIType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.robotHard);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.roleId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.accid);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.name = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.guildName = StringHelper.BytesToString(array3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupation);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.pkValue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.matchScore);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seat);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainHp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.remainMp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.seasonStar);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.seasonAttr);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.monthcard);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.skills = new RaceSkillInfo[(int)num4];
			for (int l = 0; l < this.skills.Length; l++)
			{
				this.skills[l] = new RaceSkillInfo();
				this.skills[l].decode(buffer, ref pos_);
			}
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.equips = new RaceEquip[(int)num5];
			for (int m = 0; m < this.equips.Length; m++)
			{
				this.equips[m] = new RaceEquip();
				this.equips[m].decode(buffer, ref pos_);
			}
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.raceItems = new RaceItem[(int)num6];
			for (int n = 0; n < this.raceItems.Length; n++)
			{
				this.raceItems[n] = new RaceItem();
				this.raceItems[n].decode(buffer, ref pos_);
			}
			ushort num7 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num7);
			this.buffs = new RaceBuffInfo[(int)num7];
			for (int num8 = 0; num8 < this.buffs.Length; num8++)
			{
				this.buffs[num8] = new RaceBuffInfo();
				this.buffs[num8].decode(buffer, ref pos_);
			}
			ushort num9 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num9);
			this.warpStones = new RaceWarpStone[(int)num9];
			for (int num10 = 0; num10 < this.warpStones.Length; num10++)
			{
				this.warpStones[num10] = new RaceWarpStone();
				this.warpStones[num10].decode(buffer, ref pos_);
			}
			ushort num11 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num11);
			this.retinues = new RaceRetinue[(int)num11];
			for (int num12 = 0; num12 < this.retinues.Length; num12++)
			{
				this.retinues[num12] = new RaceRetinue();
				this.retinues[num12].decode(buffer, ref pos_);
			}
			ushort num13 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num13);
			this.pets = new RacePet[(int)num13];
			for (int num14 = 0; num14 < this.pets.Length; num14++)
			{
				this.pets[num14] = new RacePet();
				this.pets[num14].decode(buffer, ref pos_);
			}
			ushort num15 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num15);
			this.potionPos = new uint[(int)num15];
			for (int num16 = 0; num16 < this.potionPos.Length; num16++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.potionPos[num16]);
			}
			ushort num17 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num17);
			this.secondWeapons = new RaceEquip[(int)num17];
			for (int num18 = 0; num18 < this.secondWeapons.Length; num18++)
			{
				this.secondWeapons[num18] = new RaceEquip();
				this.secondWeapons[num18].decode(buffer, ref pos_);
			}
			this.avatar.decode(buffer, ref pos_);
			this.playerLabelInfo.decode(buffer, ref pos_);
			ushort num19 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num19);
			this.equipScheme = new RaceEquipScheme[(int)num19];
			for (int num20 = 0; num20 < this.equipScheme.Length; num20++)
			{
				this.equipScheme[num20] = new RaceEquipScheme();
				this.equipScheme[num20].decode(buffer, ref pos_);
			}
			ushort num21 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num21);
			this.wearingEqIds = new ulong[(int)num21];
			for (int num22 = 0; num22 < this.wearingEqIds.Length; num22++)
			{
				BaseDLL.decode_uint64(buffer, ref pos_, ref this.wearingEqIds[num22]);
			}
		}

		// Token: 0x0600719C RID: 29084 RVA: 0x00149C48 File Offset: 0x00148048
		public int getLen()
		{
			int num = 0;
			num += 4;
			byte[] array = StringHelper.StringToUTF8Bytes(this.serverName);
			num += 2 + array.Length;
			num++;
			num++;
			num += 8;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.guildName);
			num += 2 + array3.Length;
			num++;
			num += 2;
			num += 4;
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num++;
			num++;
			num += 2;
			for (int i = 0; i < this.skills.Length; i++)
			{
				num += this.skills[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.equips.Length; j++)
			{
				num += this.equips[j].getLen();
			}
			num += 2;
			for (int k = 0; k < this.raceItems.Length; k++)
			{
				num += this.raceItems[k].getLen();
			}
			num += 2;
			for (int l = 0; l < this.buffs.Length; l++)
			{
				num += this.buffs[l].getLen();
			}
			num += 2;
			for (int m = 0; m < this.warpStones.Length; m++)
			{
				num += this.warpStones[m].getLen();
			}
			num += 2;
			for (int n = 0; n < this.retinues.Length; n++)
			{
				num += this.retinues[n].getLen();
			}
			num += 2;
			for (int num2 = 0; num2 < this.pets.Length; num2++)
			{
				num += this.pets[num2].getLen();
			}
			num += 2 + 4 * this.potionPos.Length;
			num += 2;
			for (int num3 = 0; num3 < this.secondWeapons.Length; num3++)
			{
				num += this.secondWeapons[num3].getLen();
			}
			num += this.avatar.getLen();
			num += this.playerLabelInfo.getLen();
			num += 2;
			for (int num4 = 0; num4 < this.equipScheme.Length; num4++)
			{
				num += this.equipScheme[num4].getLen();
			}
			return num + (2 + 8 * this.wearingEqIds.Length);
		}

		// Token: 0x0400340B RID: 13323
		public uint zoneId;

		// Token: 0x0400340C RID: 13324
		public string serverName;

		// Token: 0x0400340D RID: 13325
		public byte robotAIType;

		// Token: 0x0400340E RID: 13326
		public byte robotHard;

		// Token: 0x0400340F RID: 13327
		public ulong roleId;

		// Token: 0x04003410 RID: 13328
		public uint accid;

		// Token: 0x04003411 RID: 13329
		public string name;

		// Token: 0x04003412 RID: 13330
		public string guildName;

		// Token: 0x04003413 RID: 13331
		public byte occupation;

		// Token: 0x04003414 RID: 13332
		public ushort level;

		// Token: 0x04003415 RID: 13333
		public uint pkValue;

		// Token: 0x04003416 RID: 13334
		public uint matchScore;

		// Token: 0x04003417 RID: 13335
		public byte seat;

		// Token: 0x04003418 RID: 13336
		public uint remainHp;

		// Token: 0x04003419 RID: 13337
		public uint remainMp;

		// Token: 0x0400341A RID: 13338
		public uint seasonLevel;

		// Token: 0x0400341B RID: 13339
		public uint seasonStar;

		// Token: 0x0400341C RID: 13340
		public byte seasonAttr;

		// Token: 0x0400341D RID: 13341
		public byte monthcard;

		// Token: 0x0400341E RID: 13342
		public RaceSkillInfo[] skills = new RaceSkillInfo[0];

		// Token: 0x0400341F RID: 13343
		public RaceEquip[] equips = new RaceEquip[0];

		// Token: 0x04003420 RID: 13344
		public RaceItem[] raceItems = new RaceItem[0];

		// Token: 0x04003421 RID: 13345
		public RaceBuffInfo[] buffs = new RaceBuffInfo[0];

		// Token: 0x04003422 RID: 13346
		public RaceWarpStone[] warpStones = new RaceWarpStone[0];

		// Token: 0x04003423 RID: 13347
		public RaceRetinue[] retinues = new RaceRetinue[0];

		// Token: 0x04003424 RID: 13348
		public RacePet[] pets = new RacePet[0];

		// Token: 0x04003425 RID: 13349
		public uint[] potionPos = new uint[0];

		// Token: 0x04003426 RID: 13350
		public RaceEquip[] secondWeapons = new RaceEquip[0];

		// Token: 0x04003427 RID: 13351
		public PlayerAvatar avatar = new PlayerAvatar();

		// Token: 0x04003428 RID: 13352
		public PlayerLabelInfo playerLabelInfo = new PlayerLabelInfo();

		// Token: 0x04003429 RID: 13353
		public RaceEquipScheme[] equipScheme = new RaceEquipScheme[0];

		// Token: 0x0400342A RID: 13354
		public ulong[] wearingEqIds = new ulong[0];
	}
}
