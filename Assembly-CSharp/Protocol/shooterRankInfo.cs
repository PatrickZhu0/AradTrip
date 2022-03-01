using System;

namespace Protocol
{
	// Token: 0x02000743 RID: 1859
	public class shooterRankInfo : IProtocolStream
	{
		// Token: 0x06005C9E RID: 23710 RVA: 0x00117494 File Offset: 0x00115894
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.shooterId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winRate);
		}

		// Token: 0x06005C9F RID: 23711 RVA: 0x001174C0 File Offset: 0x001158C0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shooterId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winRate);
		}

		// Token: 0x06005CA0 RID: 23712 RVA: 0x001174EC File Offset: 0x001158EC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.shooterId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.battleNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.winRate);
		}

		// Token: 0x06005CA1 RID: 23713 RVA: 0x00117518 File Offset: 0x00115918
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.shooterId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.battleNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.winRate);
		}

		// Token: 0x06005CA2 RID: 23714 RVA: 0x00117544 File Offset: 0x00115944
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x040025CF RID: 9679
		public uint shooterId;

		// Token: 0x040025D0 RID: 9680
		public uint battleNum;

		// Token: 0x040025D1 RID: 9681
		public uint winRate;
	}
}
