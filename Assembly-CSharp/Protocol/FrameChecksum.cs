using System;

namespace Protocol
{
	// Token: 0x02000A92 RID: 2706
	public class FrameChecksum : IProtocolStream
	{
		// Token: 0x06007615 RID: 30229 RVA: 0x001555B9 File Offset: 0x001539B9
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.frame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.checksum);
		}

		// Token: 0x06007616 RID: 30230 RVA: 0x001555D7 File Offset: 0x001539D7
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.checksum);
		}

		// Token: 0x06007617 RID: 30231 RVA: 0x001555F5 File Offset: 0x001539F5
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.frame);
			BaseDLL.encode_uint32(buffer, ref pos_, this.checksum);
		}

		// Token: 0x06007618 RID: 30232 RVA: 0x00155613 File Offset: 0x00153A13
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.frame);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.checksum);
		}

		// Token: 0x06007619 RID: 30233 RVA: 0x00155634 File Offset: 0x00153A34
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003721 RID: 14113
		public uint frame;

		// Token: 0x04003722 RID: 14114
		public uint checksum;
	}
}
