using System;

namespace Protocol
{
	// Token: 0x020009F4 RID: 2548
	public class RaceItem : IProtocolStream
	{
		// Token: 0x06007174 RID: 29044 RVA: 0x001480A5 File Offset: 0x001464A5
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06007175 RID: 29045 RVA: 0x001480C3 File Offset: 0x001464C3
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007176 RID: 29046 RVA: 0x001480E1 File Offset: 0x001464E1
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_uint16(buffer, ref pos_, this.num);
		}

		// Token: 0x06007177 RID: 29047 RVA: 0x001480FF File Offset: 0x001464FF
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.num);
		}

		// Token: 0x06007178 RID: 29048 RVA: 0x00148120 File Offset: 0x00146520
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 2;
		}

		// Token: 0x040033F5 RID: 13301
		public uint id;

		// Token: 0x040033F6 RID: 13302
		public ushort num;
	}
}
