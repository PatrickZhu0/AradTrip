using System;

namespace Protocol
{
	// Token: 0x02000A98 RID: 2712
	public class PkRaceEndInfo : IProtocolStream
	{
		// Token: 0x06007642 RID: 30274 RVA: 0x00155EF8 File Offset: 0x001542F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.gamesessionId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.replayScore);
		}

		// Token: 0x06007643 RID: 30275 RVA: 0x00155F5C File Offset: 0x0015435C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.gamesessionId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new PkPlayerRaceEndInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new PkPlayerRaceEndInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.replayScore);
		}

		// Token: 0x06007644 RID: 30276 RVA: 0x00155FD4 File Offset: 0x001543D4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.gamesessionId);
			BaseDLL.encode_uint16(buffer, ref pos_, (ushort)this.infoes.Length);
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i].encode(buffer, ref pos_);
			}
			BaseDLL.encode_uint32(buffer, ref pos_, this.replayScore);
		}

		// Token: 0x06007645 RID: 30277 RVA: 0x00156038 File Offset: 0x00154438
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.gamesessionId);
			ushort num = 0;
			BaseDLL.decode_uint16(buffer, ref pos_, ref num);
			this.infoes = new PkPlayerRaceEndInfo[(int)num];
			for (int i = 0; i < this.infoes.Length; i++)
			{
				this.infoes[i] = new PkPlayerRaceEndInfo();
				this.infoes[i].decode(buffer, ref pos_);
			}
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.replayScore);
		}

		// Token: 0x06007646 RID: 30278 RVA: 0x001560B0 File Offset: 0x001544B0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 2;
			for (int i = 0; i < this.infoes.Length; i++)
			{
				num += this.infoes[i].getLen();
			}
			return num + 4;
		}

		// Token: 0x0400373D RID: 14141
		public ulong gamesessionId;

		// Token: 0x0400373E RID: 14142
		public PkPlayerRaceEndInfo[] infoes = new PkPlayerRaceEndInfo[0];

		// Token: 0x0400373F RID: 14143
		public uint replayScore;
	}
}
