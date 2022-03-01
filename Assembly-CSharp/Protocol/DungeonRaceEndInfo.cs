using System;

namespace Protocol
{
	// Token: 0x02000A9B RID: 2715
	public class DungeonRaceEndInfo : IProtocolStream
	{
		// Token: 0x06007657 RID: 30295 RVA: 0x00156534 File Offset: 0x00154934
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06007658 RID: 30296 RVA: 0x001565A4 File Offset: 0x001549A4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new DungeonPlayerRaceEndInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new DungeonPlayerRaceEndInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06007659 RID: 30297 RVA: 0x00156628 File Offset: 0x00154A28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.sessionId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.dungeonId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.usedTime);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x0600765A RID: 30298 RVA: 0x00156698 File Offset: 0x00154A98
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.sessionId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.dungeonId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.usedTime);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new DungeonPlayerRaceEndInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new DungeonPlayerRaceEndInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x0600765B RID: 30299 RVA: 0x0015671C File Offset: 0x00154B1C
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 4;
			num += 4;
			num += 2;
			for (int i = 0; i < this.infoes.Length; i++)
			{
				num += this.infoes[i].getLen();
			}
			return num;
		}

		// Token: 0x0400374F RID: 14159
		public ulong sessionId;

		// Token: 0x04003750 RID: 14160
		public uint dungeonId;

		// Token: 0x04003751 RID: 14161
		public uint usedTime;

		// Token: 0x04003752 RID: 14162
		public DungeonPlayerRaceEndInfo[] infoes = new DungeonPlayerRaceEndInfo[0];
	}
}
