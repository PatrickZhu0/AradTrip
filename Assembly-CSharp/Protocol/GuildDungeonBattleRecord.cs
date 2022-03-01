using System;

namespace Protocol
{
	// Token: 0x02000888 RID: 2184
	public class GuildDungeonBattleRecord : IProtocolStream
	{
		// Token: 0x0600662E RID: 26158 RVA: 0x0012F070 File Offset: 0x0012D470
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleCnt);
			BaseDLL.encode_uint64(buffer, ref pos_, this.oddBlood);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffVec.Length);
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600662F RID: 26159 RVA: 0x0012F0E0 File Offset: 0x0012D4E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleCnt);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.oddBlood);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffVec = new GuildDungeonBuff[(int)num];
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i] = new GuildDungeonBuff();
				this.buffVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006630 RID: 26160 RVA: 0x0012F164 File Offset: 0x0012D564
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleCnt);
			BaseDLL.encode_uint64(buffer, ref pos_, this.oddBlood);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffVec.Length);
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006631 RID: 26161 RVA: 0x0012F1D4 File Offset: 0x0012D5D4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleCnt);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.oddBlood);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffVec = new GuildDungeonBuff[(int)num];
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i] = new GuildDungeonBuff();
				this.buffVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006632 RID: 26162 RVA: 0x0012F258 File Offset: 0x0012D658
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 8;
			num += 2;
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				num += this.buffVec[i].getLen();
			}
			return num;
		}

		// Token: 0x04002DB8 RID: 11704
		public uint dungeonId;

		// Token: 0x04002DB9 RID: 11705
		public uint battleCnt;

		// Token: 0x04002DBA RID: 11706
		public ulong oddBlood;

		// Token: 0x04002DBB RID: 11707
		public GuildDungeonBuff[] buffVec = new GuildDungeonBuff[0];
	}
}
