using System;

namespace Protocol
{
	// Token: 0x02000882 RID: 2178
	[Protocol]
	public class WorldGuildDungeonInfoRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x060065FE RID: 26110 RVA: 0x0012E808 File Offset: 0x0012CC08
		public uint GetMsgID()
		{
			return 608502U;
		}

		// Token: 0x060065FF RID: 26111 RVA: 0x0012E80F File Offset: 0x0012CC0F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006600 RID: 26112 RVA: 0x0012E817 File Offset: 0x0012CC17
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006601 RID: 26113 RVA: 0x0012E820 File Offset: 0x0012CC20
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.statusEndStamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isReward);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.bossBlood.Length);
			for (int i = 0; i < this.bossBlood.Length; i++)
			{
				this.bossBlood[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.clearGateTime.Length);
			for (int j = 0; j < this.clearGateTime.Length; j++)
			{
				this.clearGateTime[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006602 RID: 26114 RVA: 0x0012E8D8 File Offset: 0x0012CCD8
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.statusEndStamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isReward);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.bossBlood = new GuildDungeonBossBlood[(int)num];
			for (int i = 0; i < this.bossBlood.Length; i++)
			{
				this.bossBlood[i] = new GuildDungeonBossBlood();
				this.bossBlood[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.clearGateTime = new GuildDungeonClearGateTime[(int)num2];
			for (int j = 0; j < this.clearGateTime.Length; j++)
			{
				this.clearGateTime[j] = new GuildDungeonClearGateTime();
				this.clearGateTime[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006603 RID: 26115 RVA: 0x0012E9B8 File Offset: 0x0012CDB8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonStatus);
			BaseDLL.encode_uint32(buffer, ref pos_, this.statusEndStamp);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isReward);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.bossBlood.Length);
			for (int i = 0; i < this.bossBlood.Length; i++)
			{
				this.bossBlood[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.clearGateTime.Length);
			for (int j = 0; j < this.clearGateTime.Length; j++)
			{
				this.clearGateTime[j].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006604 RID: 26116 RVA: 0x0012EA70 File Offset: 0x0012CE70
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonStatus);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.statusEndStamp);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isReward);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.bossBlood = new GuildDungeonBossBlood[(int)num];
			for (int i = 0; i < this.bossBlood.Length; i++)
			{
				this.bossBlood[i] = new GuildDungeonBossBlood();
				this.bossBlood[i].decode(buffer, ref pos_);
			}
			ushort num2 = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num2);
			this.clearGateTime = new GuildDungeonClearGateTime[(int)num2];
			for (int j = 0; j < this.clearGateTime.Length; j++)
			{
				this.clearGateTime[j] = new GuildDungeonClearGateTime();
				this.clearGateTime[j].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006605 RID: 26117 RVA: 0x0012EB50 File Offset: 0x0012CF50
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.bossBlood.Length; i++)
			{
				num += this.bossBlood[i].getLen();
			}
			num += 2;
			for (int j = 0; j < this.clearGateTime.Length; j++)
			{
				num += this.clearGateTime[j].getLen();
			}
			return num;
		}

		// Token: 0x04002DA3 RID: 11683
		public const uint MsgID = 608502U;

		// Token: 0x04002DA4 RID: 11684
		public uint Sequence;

		// Token: 0x04002DA5 RID: 11685
		public uint result;

		// Token: 0x04002DA6 RID: 11686
		public uint dungeonStatus;

		// Token: 0x04002DA7 RID: 11687
		public uint statusEndStamp;

		// Token: 0x04002DA8 RID: 11688
		public uint isReward;

		// Token: 0x04002DA9 RID: 11689
		public GuildDungeonBossBlood[] bossBlood = new GuildDungeonBossBlood[0];

		// Token: 0x04002DAA RID: 11690
		public GuildDungeonClearGateTime[] clearGateTime = new GuildDungeonClearGateTime[0];
	}
}
