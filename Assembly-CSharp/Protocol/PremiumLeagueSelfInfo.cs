using System;

namespace Protocol
{
	// Token: 0x02000A62 RID: 2658
	public class PremiumLeagueSelfInfo : IProtocolStream
	{
		// Token: 0x060074B0 RID: 29872 RVA: 0x00151DC0 File Offset: 0x001501C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ranking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.loseNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preliminayRewardNum);
		}

		// Token: 0x060074B1 RID: 29873 RVA: 0x00151E24 File Offset: 0x00150224
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ranking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.loseNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preliminayRewardNum);
		}

		// Token: 0x060074B2 RID: 29874 RVA: 0x00151E88 File Offset: 0x00150288
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.winNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
			BaseDLL.encode_uint32(buffer, ref pos_, this.ranking);
			BaseDLL.encode_uint32(buffer, ref pos_, this.enrollCount);
			BaseDLL.encode_uint32(buffer, ref pos_, this.loseNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.preliminayRewardNum);
		}

		// Token: 0x060074B3 RID: 29875 RVA: 0x00151EEC File Offset: 0x001502EC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.ranking);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.enrollCount);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.loseNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.preliminayRewardNum);
		}

		// Token: 0x060074B4 RID: 29876 RVA: 0x00151F50 File Offset: 0x00150350
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003640 RID: 13888
		public uint winNum;

		// Token: 0x04003641 RID: 13889
		public uint score;

		// Token: 0x04003642 RID: 13890
		public uint ranking;

		// Token: 0x04003643 RID: 13891
		public uint enrollCount;

		// Token: 0x04003644 RID: 13892
		public uint loseNum;

		// Token: 0x04003645 RID: 13893
		public uint preliminayRewardNum;
	}
}
