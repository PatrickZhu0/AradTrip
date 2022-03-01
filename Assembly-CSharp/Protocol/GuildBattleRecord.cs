using System;

namespace Protocol
{
	// Token: 0x0200081D RID: 2077
	public class GuildBattleRecord : IProtocolStream
	{
		// Token: 0x0600629B RID: 25243 RVA: 0x001274D2 File Offset: 0x001258D2
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			this.winner.encode(buffer, ref pos_);
			this.loser.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x0600629C RID: 25244 RVA: 0x0012750A File Offset: 0x0012590A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			this.winner.decode(buffer, ref pos_);
			this.loser.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x0600629D RID: 25245 RVA: 0x00127542 File Offset: 0x00125942
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			this.winner.encode(buffer, ref pos_);
			this.loser.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
		}

		// Token: 0x0600629E RID: 25246 RVA: 0x0012757A File Offset: 0x0012597A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			this.winner.decode(buffer, ref pos_);
			this.loser.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
		}

		// Token: 0x0600629F RID: 25247 RVA: 0x001275B4 File Offset: 0x001259B4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += this.winner.getLen();
			num += this.loser.getLen();
			return num + 4;
		}

		// Token: 0x04002C24 RID: 11300
		public uint index;

		// Token: 0x04002C25 RID: 11301
		public GuildBattleMember winner = new GuildBattleMember();

		// Token: 0x04002C26 RID: 11302
		public GuildBattleMember loser = new GuildBattleMember();

		// Token: 0x04002C27 RID: 11303
		public uint time;
	}
}
