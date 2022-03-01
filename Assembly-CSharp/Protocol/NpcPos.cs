using System;

namespace Protocol
{
	// Token: 0x02000AFE RID: 2814
	public class NpcPos : IProtocolStream
	{
		// Token: 0x0600790F RID: 30991 RVA: 0x0015CE28 File Offset: 0x0015B228
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.x);
			BaseDLL.encode_int32(buffer, ref pos_, this.y);
		}

		// Token: 0x06007910 RID: 30992 RVA: 0x0015CE46 File Offset: 0x0015B246
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06007911 RID: 30993 RVA: 0x0015CE64 File Offset: 0x0015B264
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int32(buffer, ref pos_, this.x);
			BaseDLL.encode_int32(buffer, ref pos_, this.y);
		}

		// Token: 0x06007912 RID: 30994 RVA: 0x0015CE82 File Offset: 0x0015B282
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_int32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06007913 RID: 30995 RVA: 0x0015CEA0 File Offset: 0x0015B2A0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003925 RID: 14629
		public int x;

		// Token: 0x04003926 RID: 14630
		public int y;
	}
}
