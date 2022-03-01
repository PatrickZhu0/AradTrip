using System;

namespace Protocol
{
	// Token: 0x02000A78 RID: 2680
	public class RedPacketReceiverEntry : IProtocolStream
	{
		// Token: 0x06007552 RID: 30034 RVA: 0x0015389B File Offset: 0x00151C9B
		public void encode(byte[] buffer, ref int pos_)
		{
			this.icon.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.money);
		}

		// Token: 0x06007553 RID: 30035 RVA: 0x001538B8 File Offset: 0x00151CB8
		public void decode(byte[] buffer, ref int pos_)
		{
			this.icon.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.money);
		}

		// Token: 0x06007554 RID: 30036 RVA: 0x001538D5 File Offset: 0x00151CD5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			this.icon.encode(buffer, ref pos_);
			BaseDLL.encode_uint32(buffer, ref pos_, this.money);
		}

		// Token: 0x06007555 RID: 30037 RVA: 0x001538F2 File Offset: 0x00151CF2
		public void decode(MapViewStream buffer, ref int pos_)
		{
			this.icon.decode(buffer, ref pos_);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.money);
		}

		// Token: 0x06007556 RID: 30038 RVA: 0x00153910 File Offset: 0x00151D10
		public int getLen()
		{
			int num = 0;
			num += this.icon.getLen();
			return num + 4;
		}

		// Token: 0x040036A3 RID: 13987
		public PlayerIcon icon = new PlayerIcon();

		// Token: 0x040036A4 RID: 13988
		public uint money;
	}
}
