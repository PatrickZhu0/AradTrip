using System;

namespace Protocol
{
	// Token: 0x02000C1C RID: 3100
	public class ChargeInfo : IProtocolStream
	{
		// Token: 0x0600817F RID: 33151 RVA: 0x0016D970 File Offset: 0x0016BD70
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06008180 RID: 33152 RVA: 0x0016D98E File Offset: 0x0016BD8E
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06008181 RID: 33153 RVA: 0x0016D9AC File Offset: 0x0016BDAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x06008182 RID: 33154 RVA: 0x0016D9CA File Offset: 0x0016BDCA
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06008183 RID: 33155 RVA: 0x0016D9E8 File Offset: 0x0016BDE8
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003DD1 RID: 15825
		public uint id;

		// Token: 0x04003DD2 RID: 15826
		public uint num;
	}
}
