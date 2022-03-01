using System;

namespace Protocol
{
	// Token: 0x020007B9 RID: 1977
	public class GuildDungeonInfo : IProtocolStream
	{
		// Token: 0x06006001 RID: 24577 RVA: 0x0011F988 File Offset: 0x0011DD88
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossOddBlood);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossTotalBlood);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffVec.Length);
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006002 RID: 24578 RVA: 0x0011F9EC File Offset: 0x0011DDEC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossOddBlood);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossTotalBlood);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffVec = new DungeonBuff[(int)num];
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i] = new DungeonBuff();
				this.buffVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006003 RID: 24579 RVA: 0x0011FA64 File Offset: 0x0011DE64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossOddBlood);
			BaseDLL.encode_uint64(buffer, ref pos_, this.bossTotalBlood);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.buffVec.Length);
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i].encode(buffer, ref pos_);
			}
		}

		// Token: 0x06006004 RID: 24580 RVA: 0x0011FAC8 File Offset: 0x0011DEC8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossOddBlood);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.bossTotalBlood);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.buffVec = new DungeonBuff[(int)num];
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				this.buffVec[i] = new DungeonBuff();
				this.buffVec[i].decode(buffer, ref pos_);
			}
		}

		// Token: 0x06006005 RID: 24581 RVA: 0x0011FB40 File Offset: 0x0011DF40
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			num += 2;
			for (int i = 0; i < this.buffVec.Length; i++)
			{
				num += this.buffVec[i].getLen();
			}
			return num;
		}

		// Token: 0x040027C7 RID: 10183
		public ulong bossOddBlood;

		// Token: 0x040027C8 RID: 10184
		public ulong bossTotalBlood;

		// Token: 0x040027C9 RID: 10185
		public DungeonBuff[] buffVec = new DungeonBuff[0];
	}
}
