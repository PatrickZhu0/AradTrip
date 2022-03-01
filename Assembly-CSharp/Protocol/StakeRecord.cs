using System;

namespace Protocol
{
	// Token: 0x0200073D RID: 1853
	public class StakeRecord : IProtocolStream
	{
		// Token: 0x06005C6E RID: 23662 RVA: 0x00116E30 File Offset: 0x00115230
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.courtId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stakeShooter);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stakeNum);
			BaseDLL.encode_int32(buffer, ref pos_, this.profit);
		}

		// Token: 0x06005C6F RID: 23663 RVA: 0x00116E84 File Offset: 0x00115284
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.courtId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stakeShooter);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stakeNum);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.profit);
		}

		// Token: 0x06005C70 RID: 23664 RVA: 0x00116ED8 File Offset: 0x001152D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.courtId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stakeShooter);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
			BaseDLL.encode_uint32(buffer, ref pos_, this.stakeNum);
			BaseDLL.encode_int32(buffer, ref pos_, this.profit);
		}

		// Token: 0x06005C71 RID: 23665 RVA: 0x00116F2C File Offset: 0x0011532C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.courtId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stakeShooter);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.stakeNum);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.profit);
		}

		// Token: 0x06005C72 RID: 23666 RVA: 0x00116F80 File Offset: 0x00115380
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025BC RID: 9660
		public uint courtId;

		// Token: 0x040025BD RID: 9661
		public uint stakeShooter;

		// Token: 0x040025BE RID: 9662
		public uint odds;

		// Token: 0x040025BF RID: 9663
		public uint stakeNum;

		// Token: 0x040025C0 RID: 9664
		public int profit;
	}
}
