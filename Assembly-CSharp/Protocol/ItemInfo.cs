using System;

namespace Protocol
{
	// Token: 0x020008CD RID: 2253
	public class ItemInfo : IProtocolStream
	{
		// Token: 0x060067C3 RID: 26563 RVA: 0x00132024 File Offset: 0x00130424
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x060067C4 RID: 26564 RVA: 0x00132042 File Offset: 0x00130442
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060067C5 RID: 26565 RVA: 0x00132060 File Offset: 0x00130460
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.num);
		}

		// Token: 0x060067C6 RID: 26566 RVA: 0x0013207E File Offset: 0x0013047E
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.num);
		}

		// Token: 0x060067C7 RID: 26567 RVA: 0x0013209C File Offset: 0x0013049C
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x04002ECD RID: 11981
		public ulong uid;

		// Token: 0x04002ECE RID: 11982
		public uint num;
	}
}
