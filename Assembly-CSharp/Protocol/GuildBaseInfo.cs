using System;

namespace Protocol
{
	// Token: 0x02000821 RID: 2081
	public class GuildBaseInfo : IProtocolStream
	{
		// Token: 0x060062B3 RID: 25267 RVA: 0x00127F2C File Offset: 0x0012632C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fund);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.announcement);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.dismissTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.memberNum);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.leaderName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.winProbability);
			BaseDLL.encode_int8(buffer, ref pos_, this.loseProbability);
			BaseDLL.encode_int8(buffer, ref pos_, this.storageAddPost);
			BaseDLL.encode_int8(buffer, ref pos_, this.storageDelPost);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.building.Length);
			for (int i = 0; i < this.building.Length; i++)
			{
				this.building[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.hasRequester);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tableMembers.Length);
			for (int j = 0; j < this.tableMembers.Length; j++)
			{
				this.tableMembers[j].encode(buffer, ref pos_);
			}
			this.guildBattleInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.emblemLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekAddedFund);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastWeekAddedFund);
		}

		// Token: 0x060062B4 RID: 25268 RVA: 0x00128104 File Offset: 0x00126504
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fund);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.declaration = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.announcement = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dismissTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.memberNum);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.leaderName = StringHelper.BytesToString(array4);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.winProbability);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.loseProbability);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.storageAddPost);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.storageDelPost);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.building = new GuildBuilding[(int)num5];
			for (int m = 0; m < this.building.Length; m++)
			{
				this.building[m] = new GuildBuilding();
				this.building[m].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasRequester);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.tableMembers = new GuildTableMember[(int)num6];
			for (int n = 0; n < this.tableMembers.Length; n++)
			{
				this.tableMembers[n] = new GuildTableMember();
				this.tableMembers[n].decode(buffer, ref pos_);
			}
			this.guildBattleInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.emblemLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekAddedFund);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastWeekAddedFund);
		}

		// Token: 0x060062B5 RID: 25269 RVA: 0x001283B8 File Offset: 0x001267B8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.id);
			byte[] str = StringHelper.StringToUTF8Bytes(this.name);
			BaseDLL.encode_string(buffer, ref pos_, str, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fund);
			byte[] str2 = StringHelper.StringToUTF8Bytes(this.declaration);
			BaseDLL.encode_string(buffer, ref pos_, str2, (ushort)(buffer.Length - pos_));
			byte[] str3 = StringHelper.StringToUTF8Bytes(this.announcement);
			BaseDLL.encode_string(buffer, ref pos_, str3, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_uint32(buffer, ref pos_, this.dismissTime);
			BaseDLL.encode_uint16(buffer, ref pos_, this.memberNum);
			byte[] str4 = StringHelper.StringToUTF8Bytes(this.leaderName);
			BaseDLL.encode_string(buffer, ref pos_, str4, (ushort)(buffer.Length - pos_));
			BaseDLL.encode_int8(buffer, ref pos_, this.winProbability);
			BaseDLL.encode_int8(buffer, ref pos_, this.loseProbability);
			BaseDLL.encode_int8(buffer, ref pos_, this.storageAddPost);
			BaseDLL.encode_int8(buffer, ref pos_, this.storageDelPost);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.building.Length);
			for (int i = 0; i < this.building.Length; i++)
			{
				this.building[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.hasRequester);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.tableMembers.Length);
			for (int j = 0; j < this.tableMembers.Length; j++)
			{
				this.tableMembers[j].encode(buffer, ref pos_);
			}
			this.guildBattleInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.emblemLevel);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.weekAddedFund);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastWeekAddedFund);
		}

		// Token: 0x060062B6 RID: 25270 RVA: 0x0012859C File Offset: 0x0012699C
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
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fund);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			byte[] array2 = new byte[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array2[j]);
			}
			this.declaration = StringHelper.BytesToString(array2);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			byte[] array3 = new byte[(int)num3];
			for (int k = 0; k < (int)num3; k++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array3[k]);
			}
			this.announcement = StringHelper.BytesToString(array3);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dismissTime);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.memberNum);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			byte[] array4 = new byte[(int)num4];
			for (int l = 0; l < (int)num4; l++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref array4[l]);
			}
			this.leaderName = StringHelper.BytesToString(array4);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.winProbability);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.loseProbability);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.storageAddPost);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.storageDelPost);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.building = new GuildBuilding[(int)num5];
			for (int m = 0; m < this.building.Length; m++)
			{
				this.building[m] = new GuildBuilding();
				this.building[m].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hasRequester);
			ushort num6 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num6);
			this.tableMembers = new GuildTableMember[(int)num6];
			for (int n = 0; n < this.tableMembers.Length; n++)
			{
				this.tableMembers[n] = new GuildTableMember();
				this.tableMembers[n].decode(buffer, ref pos_);
			}
			this.guildBattleInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.emblemLevel);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.weekAddedFund);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastWeekAddedFund);
		}

		// Token: 0x060062B7 RID: 25271 RVA: 0x00128850 File Offset: 0x00126C50
		public int getLen()
		{
			int num = 0;
			num += 8;
			byte[] array = StringHelper.StringToUTF8Bytes(this.name);
			num += 2 + array.Length;
			num++;
			num += 4;
			byte[] array2 = StringHelper.StringToUTF8Bytes(this.declaration);
			num += 2 + array2.Length;
			byte[] array3 = StringHelper.StringToUTF8Bytes(this.announcement);
			num += 2 + array3.Length;
			num += 4;
			num += 2;
			byte[] array4 = StringHelper.StringToUTF8Bytes(this.leaderName);
			num += 2 + array4.Length;
			num++;
			num++;
			num++;
			num++;
			num += 2;
			for (int i = 0; i < this.building.Length; i++)
			{
				num += this.building[i].getLen();
			}
			num++;
			num += 2;
			for (int j = 0; j < this.tableMembers.Length; j++)
			{
				num += this.tableMembers[j].getLen();
			}
			num += this.guildBattleInfo.getLen();
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002C3A RID: 11322
		public ulong id;

		// Token: 0x04002C3B RID: 11323
		public string name;

		// Token: 0x04002C3C RID: 11324
		public byte level;

		// Token: 0x04002C3D RID: 11325
		public uint fund;

		// Token: 0x04002C3E RID: 11326
		public string declaration;

		// Token: 0x04002C3F RID: 11327
		public string announcement;

		// Token: 0x04002C40 RID: 11328
		public uint dismissTime;

		// Token: 0x04002C41 RID: 11329
		public ushort memberNum;

		// Token: 0x04002C42 RID: 11330
		public string leaderName;

		// Token: 0x04002C43 RID: 11331
		public byte winProbability;

		// Token: 0x04002C44 RID: 11332
		public byte loseProbability;

		// Token: 0x04002C45 RID: 11333
		public byte storageAddPost;

		// Token: 0x04002C46 RID: 11334
		public byte storageDelPost;

		// Token: 0x04002C47 RID: 11335
		public GuildBuilding[] building = new GuildBuilding[0];

		// Token: 0x04002C48 RID: 11336
		public byte hasRequester;

		// Token: 0x04002C49 RID: 11337
		public GuildTableMember[] tableMembers = new GuildTableMember[0];

		// Token: 0x04002C4A RID: 11338
		public GuildBattleBaseInfo guildBattleInfo = new GuildBattleBaseInfo();

		// Token: 0x04002C4B RID: 11339
		public uint joinLevel;

		// Token: 0x04002C4C RID: 11340
		public uint emblemLevel;

		// Token: 0x04002C4D RID: 11341
		public uint dungeonType;

		// Token: 0x04002C4E RID: 11342
		public uint weekAddedFund;

		// Token: 0x04002C4F RID: 11343
		public uint lastWeekAddedFund;
	}
}
