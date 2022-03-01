using System;

namespace Protocol
{
	// Token: 0x020008C7 RID: 2247
	public class GemStone : IProtocolStream
	{
		// Token: 0x0600679F RID: 26527 RVA: 0x00131AC0 File Offset: 0x0012FEC0
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x060067A0 RID: 26528 RVA: 0x00131ADE File Offset: 0x0012FEDE
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x060067A1 RID: 26529 RVA: 0x00131AFC File Offset: 0x0012FEFC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.id);
			BaseDLL.encode_int8(buffer, ref pos_, this.level);
		}

		// Token: 0x060067A2 RID: 26530 RVA: 0x00131B1A File Offset: 0x0012FF1A
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.id);
			BaseDLL.decode_int8(buffer, ref pos_, ref this.level);
		}

		// Token: 0x060067A3 RID: 26531 RVA: 0x00131B38 File Offset: 0x0012FF38
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 1;
		}

		// Token: 0x04002EBA RID: 11962
		public uint id;

		// Token: 0x04002EBB RID: 11963
		public byte level;
	}
}
