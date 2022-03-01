using System;

namespace Protocol
{
	// Token: 0x02000C8C RID: 3212
	public class PkStatisticInfo : IProtocolStream
	{
		// Token: 0x060084AF RID: 33967 RVA: 0x00174034 File Offset: 0x00172434
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalWinNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalLoseNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x060084B0 RID: 33968 RVA: 0x00174060 File Offset: 0x00172460
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalWinNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalLoseNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x060084B1 RID: 33969 RVA: 0x0017408C File Offset: 0x0017248C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalWinNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalLoseNum);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalNum);
		}

		// Token: 0x060084B2 RID: 33970 RVA: 0x001740B8 File Offset: 0x001724B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalWinNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalLoseNum);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalNum);
		}

		// Token: 0x060084B3 RID: 33971 RVA: 0x001740E4 File Offset: 0x001724E4
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003F8A RID: 16266
		public uint totalWinNum;

		// Token: 0x04003F8B RID: 16267
		public uint totalLoseNum;

		// Token: 0x04003F8C RID: 16268
		public uint totalNum;
	}
}
