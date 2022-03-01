using System;

namespace Protocol
{
	// Token: 0x02000820 RID: 2080
	public class GuildBattleBaseInfo : IProtocolStream
	{
		// Token: 0x060062AD RID: 25261 RVA: 0x00127A20 File Offset: 0x00125E20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.enrollTerrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildBattleScore);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyCrossTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.historyTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.inspire);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.selfGuildBattleRecord.Length);
			for (int i = 0; i < this.selfGuildBattleRecord.Length; i++)
			{
				this.selfGuildBattleRecord[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.terrInfos.Length);
			for (int j = 0; j < this.terrInfos.Length; j++)
			{
				this.terrInfos[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.guildBattleType);
			BaseDLL.encode_int8(buffer, ref pos_, this.guildBattleStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildBattleStatusEndTime);
		}

		// Token: 0x060062AE RID: 25262 RVA: 0x00127B20 File Offset: 0x00125F20
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enrollTerrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildBattleScore);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyCrossTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.historyTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inspire);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.selfGuildBattleRecord = new GuildBattleRecord[(int)num];
			for (int i = 0; i < this.selfGuildBattleRecord.Length; i++)
			{
				this.selfGuildBattleRecord[i] = new GuildBattleRecord();
				this.selfGuildBattleRecord[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.terrInfos = new GuildTerritoryBaseInfo[(int)num2];
			for (int j = 0; j < this.terrInfos.Length; j++)
			{
				this.terrInfos[j] = new GuildTerritoryBaseInfo();
				this.terrInfos[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.guildBattleType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.guildBattleStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildBattleStatusEndTime);
		}

		// Token: 0x060062AF RID: 25263 RVA: 0x00127C48 File Offset: 0x00126048
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.enrollTerrId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildBattleScore);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.occupyCrossTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.historyTerrId);
			BaseDLL.encode_int8(buffer, ref pos_, this.inspire);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.selfGuildBattleRecord.Length);
			for (int i = 0; i < this.selfGuildBattleRecord.Length; i++)
			{
				this.selfGuildBattleRecord[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.terrInfos.Length);
			for (int j = 0; j < this.terrInfos.Length; j++)
			{
				this.terrInfos[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.guildBattleType);
			BaseDLL.encode_int8(buffer, ref pos_, this.guildBattleStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.guildBattleStatusEndTime);
		}

		// Token: 0x060062B0 RID: 25264 RVA: 0x00127D48 File Offset: 0x00126148
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.enrollTerrId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildBattleScore);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.occupyCrossTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.historyTerrId);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.inspire);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.selfGuildBattleRecord = new GuildBattleRecord[(int)num];
			for (int i = 0; i < this.selfGuildBattleRecord.Length; i++)
			{
				this.selfGuildBattleRecord[i] = new GuildBattleRecord();
				this.selfGuildBattleRecord[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.terrInfos = new GuildTerritoryBaseInfo[(int)num2];
			for (int j = 0; j < this.terrInfos.Length; j++)
			{
				this.terrInfos[j] = new GuildTerritoryBaseInfo();
				this.terrInfos[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.guildBattleType);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.guildBattleStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.guildBattleStatusEndTime);
		}

		// Token: 0x060062B1 RID: 25265 RVA: 0x00127E70 File Offset: 0x00126270
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num++;
			num++;
			num++;
			num++;
			num += 2;
			for (int i = 0; i < this.selfGuildBattleRecord.Length; i++)
			{
				num += this.selfGuildBattleRecord[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.terrInfos.Length; j++)
			{
				num += this.terrInfos[j].getLen();
			}
			num++;
			num++;
			return num + 4;
		}

		// Token: 0x04002C2F RID: 11311
		public byte enrollTerrId;

		// Token: 0x04002C30 RID: 11312
		public uint guildBattleScore;

		// Token: 0x04002C31 RID: 11313
		public byte occupyTerrId;

		// Token: 0x04002C32 RID: 11314
		public byte occupyCrossTerrId;

		// Token: 0x04002C33 RID: 11315
		public byte historyTerrId;

		// Token: 0x04002C34 RID: 11316
		public byte inspire;

		// Token: 0x04002C35 RID: 11317
		public GuildBattleRecord[] selfGuildBattleRecord = new GuildBattleRecord[0];

		// Token: 0x04002C36 RID: 11318
		public GuildTerritoryBaseInfo[] terrInfos = new GuildTerritoryBaseInfo[0];

		// Token: 0x04002C37 RID: 11319
		public byte guildBattleType;

		// Token: 0x04002C38 RID: 11320
		public byte guildBattleStatus;

		// Token: 0x04002C39 RID: 11321
		public uint guildBattleStatusEndTime;
	}
}
