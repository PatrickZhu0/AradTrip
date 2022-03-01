using System;

namespace Protocol
{
	// Token: 0x020008C8 RID: 2248
	public class ItemMagicProperty : IProtocolStream
	{
		// Token: 0x060067A5 RID: 26533 RVA: 0x00131B58 File Offset: 0x0012FF58
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x060067A6 RID: 26534 RVA: 0x00131B84 File Offset: 0x0012FF84
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x060067A7 RID: 26535 RVA: 0x00131BB0 File Offset: 0x0012FFB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param1);
			BaseDLL.encode_uint32(buffer, ref pos_, this.param2);
		}

		// Token: 0x060067A8 RID: 26536 RVA: 0x00131BDC File Offset: 0x0012FFDC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param1);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.param2);
		}

		// Token: 0x060067A9 RID: 26537 RVA: 0x00131C08 File Offset: 0x00130008
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002EBC RID: 11964
		public byte type;

		// Token: 0x04002EBD RID: 11965
		public uint param1;

		// Token: 0x04002EBE RID: 11966
		public uint param2;
	}
}
