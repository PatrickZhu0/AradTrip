using System;

namespace Protocol
{
	// Token: 0x0200076F RID: 1903
	public class GambleOption : IProtocolStream
	{
		// Token: 0x06005E00 RID: 24064 RVA: 0x0011A01D File Offset: 0x0011841D
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
		}

		// Token: 0x06005E01 RID: 24065 RVA: 0x0011A049 File Offset: 0x00118449
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
		}

		// Token: 0x06005E02 RID: 24066 RVA: 0x0011A075 File Offset: 0x00118475
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.option);
			BaseDLL.encode_uint64(buffer, ref pos_, this.num);
			BaseDLL.encode_uint32(buffer, ref pos_, this.odds);
		}

		// Token: 0x06005E03 RID: 24067 RVA: 0x0011A0A1 File Offset: 0x001184A1
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.option);
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.num);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.odds);
		}

		// Token: 0x06005E04 RID: 24068 RVA: 0x0011A0D0 File Offset: 0x001184D0
		public int getLen()
		{
			int num = 0;
			num += 8;
			num += 8;
			return num + 4;
		}

		// Token: 0x0400268A RID: 9866
		public ulong option;

		// Token: 0x0400268B RID: 9867
		public ulong num;

		// Token: 0x0400268C RID: 9868
		public uint odds;
	}
}
