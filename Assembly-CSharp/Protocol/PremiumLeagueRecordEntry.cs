using System;

namespace Protocol
{
	// Token: 0x02000A64 RID: 2660
	public class PremiumLeagueRecordEntry : IProtocolStream
	{
		// Token: 0x060074BC RID: 29884 RVA: 0x001521AA File Offset: 0x001505AA
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			this.winner.encode(buffer, ref pos_);
			this.loser.encode(buffer, ref pos_);
		}

		// Token: 0x060074BD RID: 29885 RVA: 0x001521E2 File Offset: 0x001505E2
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			this.winner.decode(buffer, ref pos_);
			this.loser.decode(buffer, ref pos_);
		}

		// Token: 0x060074BE RID: 29886 RVA: 0x0015221A File Offset: 0x0015061A
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.index);
			BaseDLL.encode_uint32(buffer, ref pos_, this.time);
			this.winner.encode(buffer, ref pos_);
			this.loser.encode(buffer, ref pos_);
		}

		// Token: 0x060074BF RID: 29887 RVA: 0x00152252 File Offset: 0x00150652
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.index);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.time);
			this.winner.decode(buffer, ref pos_);
			this.loser.decode(buffer, ref pos_);
		}

		// Token: 0x060074C0 RID: 29888 RVA: 0x0015228C File Offset: 0x0015068C
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += this.winner.getLen();
			return num + this.loser.getLen();
		}

		// Token: 0x0400364B RID: 13899
		public uint index;

		// Token: 0x0400364C RID: 13900
		public uint time;

		// Token: 0x0400364D RID: 13901
		public PremiumLeagueRecordFighter winner = new PremiumLeagueRecordFighter();

		// Token: 0x0400364E RID: 13902
		public PremiumLeagueRecordFighter loser = new PremiumLeagueRecordFighter();
	}
}
