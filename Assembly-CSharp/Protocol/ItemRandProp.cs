using System;

namespace Protocol
{
	// Token: 0x020008C4 RID: 2244
	public class ItemRandProp : IProtocolStream
	{
		// Token: 0x0600678D RID: 26509 RVA: 0x0013171C File Offset: 0x0012FB1C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x0600678E RID: 26510 RVA: 0x0013173A File Offset: 0x0012FB3A
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x0600678F RID: 26511 RVA: 0x00131758 File Offset: 0x0012FB58
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06006790 RID: 26512 RVA: 0x00131776 File Offset: 0x0012FB76
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06006791 RID: 26513 RVA: 0x00131794 File Offset: 0x0012FB94
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x04002EAD RID: 11949
		public byte type;

		// Token: 0x04002EAE RID: 11950
		public uint value;
	}
}
