using System;

namespace Protocol
{
	// Token: 0x02000967 RID: 2407
	public class ArtifactJarBuy : IProtocolStream
	{
		// Token: 0x06006D03 RID: 27907 RVA: 0x0013CD48 File Offset: 0x0013B148
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCnt);
		}

		// Token: 0x06006D04 RID: 27908 RVA: 0x0013CD74 File Offset: 0x0013B174
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCnt);
		}

		// Token: 0x06006D05 RID: 27909 RVA: 0x0013CDA0 File Offset: 0x0013B1A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.jarId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.buyCnt);
			BaseDLL.encode_uint32(buffer, ref pos_, this.totalCnt);
		}

		// Token: 0x06006D06 RID: 27910 RVA: 0x0013CDCC File Offset: 0x0013B1CC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.jarId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.buyCnt);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.totalCnt);
		}

		// Token: 0x06006D07 RID: 27911 RVA: 0x0013CDF8 File Offset: 0x0013B1F8
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x0400315E RID: 12638
		public uint jarId;

		// Token: 0x0400315F RID: 12639
		public uint buyCnt;

		// Token: 0x04003160 RID: 12640
		public uint totalCnt;
	}
}
