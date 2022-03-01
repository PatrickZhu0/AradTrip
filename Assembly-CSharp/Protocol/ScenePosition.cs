using System;

namespace Protocol
{
	// Token: 0x02000AFC RID: 2812
	public class ScenePosition : IProtocolStream
	{
		// Token: 0x06007903 RID: 30979 RVA: 0x0015CCBC File Offset: 0x0015B0BC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x06007904 RID: 30980 RVA: 0x0015CCDA File Offset: 0x0015B0DA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06007905 RID: 30981 RVA: 0x0015CCF8 File Offset: 0x0015B0F8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.x);
			BaseDLL.encode_uint32(buffer, ref pos_, this.y);
		}

		// Token: 0x06007906 RID: 30982 RVA: 0x0015CD16 File Offset: 0x0015B116
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.x);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.y);
		}

		// Token: 0x06007907 RID: 30983 RVA: 0x0015CD34 File Offset: 0x0015B134
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003920 RID: 14624
		public uint x;

		// Token: 0x04003921 RID: 14625
		public uint y;
	}
}
