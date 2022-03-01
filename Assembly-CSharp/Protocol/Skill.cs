using System;

namespace Protocol
{
	// Token: 0x02000B57 RID: 2903
	public class Skill : IProtocolStream
	{
		// Token: 0x06007BC1 RID: 31681 RVA: 0x001623AB File Offset: 0x001607AB
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x06007BC2 RID: 31682 RVA: 0x001623C9 File Offset: 0x001607C9
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06007BC3 RID: 31683 RVA: 0x001623E7 File Offset: 0x001607E7
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint16(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x06007BC4 RID: 31684 RVA: 0x00162405 File Offset: 0x00160805
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint16(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x06007BC5 RID: 31685 RVA: 0x00162424 File Offset: 0x00160824
		public int getLen()
		{
			int num = 0;
			num += 2;
			return num + 1;
		}

		// Token: 0x04003AAA RID: 15018
		public ushort id;

		// Token: 0x04003AAB RID: 15019
		public byte level;
	}
}
