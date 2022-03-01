using System;

namespace Protocol
{
	// Token: 0x02000A60 RID: 2656
	public class PremiumLeagueStatusInfo : IProtocolStream
	{
		// Token: 0x060074A4 RID: 29860 RVA: 0x00151AA0 File Offset: 0x0014FEA0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
		}

		// Token: 0x060074A5 RID: 29861 RVA: 0x00151ACC File Offset: 0x0014FECC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
		}

		// Token: 0x060074A6 RID: 29862 RVA: 0x00151AF8 File Offset: 0x0014FEF8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.status);
			BaseDLL.encode_uint32(buffer, ref pos_, this.startTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.endTime);
		}

		// Token: 0x060074A7 RID: 29863 RVA: 0x00151B24 File Offset: 0x0014FF24
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.status);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.startTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.endTime);
		}

		// Token: 0x060074A8 RID: 29864 RVA: 0x00151B50 File Offset: 0x0014FF50
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003637 RID: 13879
		public byte status;

		// Token: 0x04003638 RID: 13880
		public uint startTime;

		// Token: 0x04003639 RID: 13881
		public uint endTime;
	}
}
