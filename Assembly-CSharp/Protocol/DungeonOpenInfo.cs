using System;

namespace Protocol
{
	// Token: 0x020007CF RID: 1999
	public class DungeonOpenInfo : IProtocolStream
	{
		// Token: 0x060060B5 RID: 24757 RVA: 0x00122C0F File Offset: 0x0012100F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.hellMode);
		}

		// Token: 0x060060B6 RID: 24758 RVA: 0x00122C2D File Offset: 0x0012102D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hellMode);
		}

		// Token: 0x060060B7 RID: 24759 RVA: 0x00122C4B File Offset: 0x0012104B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.hellMode);
		}

		// Token: 0x060060B8 RID: 24760 RVA: 0x00122C69 File Offset: 0x00121069
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.hellMode);
		}

		// Token: 0x060060B9 RID: 24761 RVA: 0x00122C88 File Offset: 0x00121088
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002858 RID: 10328
		public uint id;

		// Token: 0x04002859 RID: 10329
		public byte hellMode;
	}
}
