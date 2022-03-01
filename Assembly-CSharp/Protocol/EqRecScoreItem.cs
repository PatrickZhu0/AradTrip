using System;

namespace Protocol
{
	// Token: 0x0200093B RID: 2363
	public class EqRecScoreItem : IProtocolStream
	{
		// Token: 0x06006B7A RID: 27514 RVA: 0x0013A54F File Offset: 0x0013894F
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06006B7B RID: 27515 RVA: 0x0013A56D File Offset: 0x0013896D
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06006B7C RID: 27516 RVA: 0x0013A58B File Offset: 0x0013898B
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint64(buffer, ref pos_, this.uid);
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06006B7D RID: 27517 RVA: 0x0013A5A9 File Offset: 0x001389A9
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint64(buffer, ref pos_, ref this.uid);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06006B7E RID: 27518 RVA: 0x0013A5C8 File Offset: 0x001389C8
		public int getLen()
		{
			int num = 0;
			num += 8;
			return num + 4;
		}

		// Token: 0x040030B4 RID: 12468
		public ulong uid;

		// Token: 0x040030B5 RID: 12469
		public uint score;
	}
}
