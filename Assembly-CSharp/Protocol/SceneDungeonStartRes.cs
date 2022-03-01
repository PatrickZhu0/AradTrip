using System;

namespace Protocol
{
	// Token: 0x020007BE RID: 1982
	[Protocol]
	public class SceneDungeonStartRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600601F RID: 24607 RVA: 0x0012022C File Offset: 0x0011E62C
		public uint GetMsgID()
		{
			return 506806U;
		}

		// Token: 0x06006020 RID: 24608 RVA: 0x00120233 File Offset: 0x0011E633
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006021 RID: 24609 RVA: 0x0012023B File Offset: 0x0011E63B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006022 RID: 24610 RVA: 0x00120244 File Offset: 0x0011E644
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isCointnue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.hp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.key1);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.areas.Length);
			for (int i = 0; i < this.areas.Length; i++)
			{
				this.areas[i].encode(buffer, ref pos_);
			}
			this.hellInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.key2);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			this.addr.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int j = 0; j < this.players.Length; j++)
			{
				this.players[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.key3);
			BaseDLL.encode_int8(buffer, ref pos_, this.openAutoBattle);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startAreaId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.key4);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.bossDropItems.Length);
			for (int k = 0; k < this.bossDropItems.Length; k++)
			{
				this.bossDropItems[k].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordLog);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordReplay);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropOverMonster.Length);
			for (int l = 0; l < this.dropOverMonster.Length; l++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.dropOverMonster[l]);
			}
			this.guildDungeonInfo.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.hellAutoClose);
			BaseDLL.encode_uint64(buffer, ref pos_, this.battleFlag);
			this.zjslDungeonInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.clearedDungeonIds.Length);
			for (int m = 0; m < this.clearedDungeonIds.Length; m++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.clearedDungeonIds[m]);
			}
			for (int n = 0; n < this.md5.Length; n++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[n]);
			}
		}

		// Token: 0x06006023 RID: 24611 RVA: 0x001204B8 File Offset: 0x0011E8B8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCointnue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.hp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key1);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.areas = new SceneDungeonArea[(int)num];
			for (int i = 0; i < this.areas.Length; i++)
			{
				this.areas[i] = new SceneDungeonArea();
				this.areas[i].decode(buffer, ref pos_);
			}
			this.hellInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key2);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			this.addr.decode(buffer, ref pos_);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.players = new RacePlayerInfo[(int)num2];
			for (int j = 0; j < this.players.Length; j++)
			{
				this.players[j] = new RacePlayerInfo();
				this.players[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openAutoBattle);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startAreaId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key4);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.bossDropItems = new SceneDungeonDropItem[(int)num3];
			for (int k = 0; k < this.bossDropItems.Length; k++)
			{
				this.bossDropItems[k] = new SceneDungeonDropItem();
				this.bossDropItems[k].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordLog);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordReplay);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.dropOverMonster = new uint[(int)num4];
			for (int l = 0; l < this.dropOverMonster.Length; l++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.dropOverMonster[l]);
			}
			this.guildDungeonInfo.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hellAutoClose);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.battleFlag);
			this.zjslDungeonInfo.decode(buffer, ref pos_);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.clearedDungeonIds = new uint[(int)num5];
			for (int m = 0; m < this.clearedDungeonIds.Length; m++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.clearedDungeonIds[m]);
			}
			for (int n = 0; n < this.md5.Length; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[n]);
			}
		}

		// Token: 0x06006024 RID: 24612 RVA: 0x00120794 File Offset: 0x0011EB94
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isCointnue);
			BaseDLL.encode_uint32(buffer, ref pos_, this.hp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.key1);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.areas.Length);
			for (int i = 0; i < this.areas.Length; i++)
			{
				this.areas[i].encode(buffer, ref pos_);
			}
			this.hellInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.mp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.key2);
			BaseDLL.encode_uint64(buffer, ref pos_, this.session);
			this.addr.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.players.Length);
			for (int j = 0; j < this.players.Length; j++)
			{
				this.players[j].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.key3);
			BaseDLL.encode_int8(buffer, ref pos_, this.openAutoBattle);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startAreaId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.key4);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.bossDropItems.Length);
			for (int k = 0; k < this.bossDropItems.Length; k++)
			{
				this.bossDropItems[k].encode(buffer, ref pos_);
			}
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordLog);
			BaseDLL.encode_int8(buffer, ref pos_, this.isRecordReplay);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.dropOverMonster.Length);
			for (int l = 0; l < this.dropOverMonster.Length; l++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.dropOverMonster[l]);
			}
			this.guildDungeonInfo.encode(buffer, ref pos_);
			BaseDLL.encode_int8(buffer, ref pos_, this.hellAutoClose);
			BaseDLL.encode_uint64(buffer, ref pos_, this.battleFlag);
			this.zjslDungeonInfo.encode(buffer, ref pos_);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.clearedDungeonIds.Length);
			for (int m = 0; m < this.clearedDungeonIds.Length; m++)
			{
				BaseDLL.encode_uint32(buffer, ref pos_, this.clearedDungeonIds[m]);
			}
			for (int n = 0; n < this.md5.Length; n++)
			{
				BaseDLL.encode_int8(buffer, ref pos_, this.md5[n]);
			}
		}

		// Token: 0x06006025 RID: 24613 RVA: 0x00120A08 File Offset: 0x0011EE08
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isCointnue);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.hp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key1);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.areas = new SceneDungeonArea[(int)num];
			for (int i = 0; i < this.areas.Length; i++)
			{
				this.areas[i] = new SceneDungeonArea();
				this.areas[i].decode(buffer, ref pos_);
			}
			this.hellInfo.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.mp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key2);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.session);
			this.addr.decode(buffer, ref pos_);
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.players = new RacePlayerInfo[(int)num2];
			for (int j = 0; j < this.players.Length; j++)
			{
				this.players[j] = new RacePlayerInfo();
				this.players[j].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key3);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.openAutoBattle);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startAreaId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.key4);
			ushort num3 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num3);
			this.bossDropItems = new SceneDungeonDropItem[(int)num3];
			for (int k = 0; k < this.bossDropItems.Length; k++)
			{
				this.bossDropItems[k] = new SceneDungeonDropItem();
				this.bossDropItems[k].decode(buffer, ref pos_);
			}
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordLog);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isRecordReplay);
			ushort num4 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num4);
			this.dropOverMonster = new uint[(int)num4];
			for (int l = 0; l < this.dropOverMonster.Length; l++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.dropOverMonster[l]);
			}
			this.guildDungeonInfo.decode(buffer, ref pos_);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hellAutoClose);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.battleFlag);
			this.zjslDungeonInfo.decode(buffer, ref pos_);
			ushort num5 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num5);
			this.clearedDungeonIds = new uint[(int)num5];
			for (int m = 0; m < this.clearedDungeonIds.Length; m++)
			{
				BaseDLL.decode_uint32(buffer, ref pos_, ref this.clearedDungeonIds[m]);
			}
			for (int n = 0; n < this.md5.Length; n++)
			{
				BaseDLL.decode_int8(buffer, ref pos_, ref this.md5[n]);
			}
		}

		// Token: 0x06006026 RID: 24614 RVA: 0x00120CE4 File Offset: 0x0011F0E4
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.areas.Length; i++)
			{
				num += this.areas[i].getLen();
			}
			num += this.hellInfo.getLen();
			num += 4;
			num += 4;
			num += 8;
			num += this.addr.getLen();
			num += 2;
			for (int j = 0; j < this.players.Length; j++)
			{
				num += this.players[j].getLen();
			}
			num += 4;
			num++;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int k = 0; k < this.bossDropItems.Length; k++)
			{
				num += this.bossDropItems[k].getLen();
			}
			num++;
			num++;
			num += 2 + 4 * this.dropOverMonster.Length;
			num += this.guildDungeonInfo.getLen();
			num++;
			num += 8;
			num += this.zjslDungeonInfo.getLen();
			num += 2 + 4 * this.clearedDungeonIds.Length;
			return num + this.md5.Length;
		}

		// Token: 0x040027D9 RID: 10201
		public const uint MsgID = 506806U;

		// Token: 0x040027DA RID: 10202
		public uint Sequence;

		// Token: 0x040027DB RID: 10203
		public byte isCointnue;

		// Token: 0x040027DC RID: 10204
		public uint hp;

		// Token: 0x040027DD RID: 10205
		public uint result;

		// Token: 0x040027DE RID: 10206
		public uint key1;

		// Token: 0x040027DF RID: 10207
		public SceneDungeonArea[] areas = new SceneDungeonArea[0];

		// Token: 0x040027E0 RID: 10208
		public DungeonHellInfo hellInfo = new DungeonHellInfo();

		// Token: 0x040027E1 RID: 10209
		public uint mp;

		// Token: 0x040027E2 RID: 10210
		public uint key2;

		// Token: 0x040027E3 RID: 10211
		public ulong session;

		// Token: 0x040027E4 RID: 10212
		public SockAddr addr = new SockAddr();

		// Token: 0x040027E5 RID: 10213
		public RacePlayerInfo[] players = new RacePlayerInfo[0];

		// Token: 0x040027E6 RID: 10214
		public uint key3;

		// Token: 0x040027E7 RID: 10215
		public byte openAutoBattle;

		// Token: 0x040027E8 RID: 10216
		public uint dungeonId;

		// Token: 0x040027E9 RID: 10217
		public uint startAreaId;

		// Token: 0x040027EA RID: 10218
		public uint key4;

		// Token: 0x040027EB RID: 10219
		public SceneDungeonDropItem[] bossDropItems = new SceneDungeonDropItem[0];

		// Token: 0x040027EC RID: 10220
		public byte isRecordLog;

		// Token: 0x040027ED RID: 10221
		public byte isRecordReplay;

		// Token: 0x040027EE RID: 10222
		public uint[] dropOverMonster = new uint[0];

		// Token: 0x040027EF RID: 10223
		public GuildDungeonInfo guildDungeonInfo = new GuildDungeonInfo();

		// Token: 0x040027F0 RID: 10224
		public byte hellAutoClose;

		// Token: 0x040027F1 RID: 10225
		public ulong battleFlag;

		// Token: 0x040027F2 RID: 10226
		public ZjslDungeonInfo zjslDungeonInfo = new ZjslDungeonInfo();

		// Token: 0x040027F3 RID: 10227
		public uint[] clearedDungeonIds = new uint[0];

		// Token: 0x040027F4 RID: 10228
		public byte[] md5 = new byte[16];
	}
}
