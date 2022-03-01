using System;

namespace Protocol
{
	// Token: 0x020009F1 RID: 2545
	public class RaceItemRandProperty : IProtocolStream
	{
		// Token: 0x06007162 RID: 29026 RVA: 0x00146FDC File Offset: 0x001453DC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06007163 RID: 29027 RVA: 0x00146FFA File Offset: 0x001453FA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06007164 RID: 29028 RVA: 0x00147018 File Offset: 0x00145418
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.value);
		}

		// Token: 0x06007165 RID: 29029 RVA: 0x00147036 File Offset: 0x00145436
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.value);
		}

		// Token: 0x06007166 RID: 29030 RVA: 0x00147054 File Offset: 0x00145454
		public int getLen()
		{
			int num = 0;
			num++;
			return num + 4;
		}

		// Token: 0x040033CD RID: 13261
		public byte type;

		// Token: 0x040033CE RID: 13262
		public uint value;
	}
}
