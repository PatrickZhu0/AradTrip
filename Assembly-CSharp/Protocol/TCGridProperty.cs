using System;

namespace Protocol
{
	// Token: 0x02000C09 RID: 3081
	public class TCGridProperty : IProtocolStream
	{
		// Token: 0x060080EC RID: 33004 RVA: 0x0016C2C0 File Offset: 0x0016A6C0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.proType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.proValue);
		}

		// Token: 0x060080ED RID: 33005 RVA: 0x0016C2DE File Offset: 0x0016A6DE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.proType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.proValue);
		}

		// Token: 0x060080EE RID: 33006 RVA: 0x0016C2FC File Offset: 0x0016A6FC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.proType);
			BaseDLL.encode_uint32(buffer, ref pos_, this.proValue);
		}

		// Token: 0x060080EF RID: 33007 RVA: 0x0016C31A File Offset: 0x0016A71A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.proType);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.proValue);
		}

		// Token: 0x060080F0 RID: 33008 RVA: 0x0016C338 File Offset: 0x0016A738
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D83 RID: 15747
		public uint proType;

		// Token: 0x04003D84 RID: 15748
		public uint proValue;
	}
}
