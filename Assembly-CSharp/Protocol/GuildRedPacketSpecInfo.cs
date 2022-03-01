using System;

namespace Protocol
{
	// Token: 0x02000A7B RID: 2683
	public class GuildRedPacketSpecInfo : IProtocolStream
	{
		// Token: 0x06007564 RID: 30052 RVA: 0x00153DB4 File Offset: 0x001521B4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinNum);
		}

		// Token: 0x06007565 RID: 30053 RVA: 0x00153DE0 File Offset: 0x001521E0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinNum);
		}

		// Token: 0x06007566 RID: 30054 RVA: 0x00153E0C File Offset: 0x0015220C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.type);
			BaseDLL.encode_uint32(buffer, ref pos_, this.lastTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.joinNum);
		}

		// Token: 0x06007567 RID: 30055 RVA: 0x00153E38 File Offset: 0x00152238
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.type);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.lastTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.joinNum);
		}

		// Token: 0x06007568 RID: 30056 RVA: 0x00153E64 File Offset: 0x00152264
		public int getLen()
		{
			int num = 0;
			num++;
			num += 4;
			return num + 4;
		}

		// Token: 0x040036AE RID: 13998
		public byte type;

		// Token: 0x040036AF RID: 13999
		public uint lastTime;

		// Token: 0x040036B0 RID: 14000
		public uint joinNum;
	}
}
