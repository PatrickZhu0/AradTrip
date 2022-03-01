using System;

namespace Protocol
{
	// Token: 0x020008A7 RID: 2215
	public class HeadFrame : IProtocolStream
	{
		// Token: 0x0600673C RID: 26428 RVA: 0x00130CB8 File Offset: 0x0012F0B8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrameId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x0600673D RID: 26429 RVA: 0x00130CD6 File Offset: 0x0012F0D6
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrameId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x0600673E RID: 26430 RVA: 0x00130CF4 File Offset: 0x0012F0F4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrameId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.expireTime);
		}

		// Token: 0x0600673F RID: 26431 RVA: 0x00130D12 File Offset: 0x0012F112
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrameId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.expireTime);
		}

		// Token: 0x06006740 RID: 26432 RVA: 0x00130D30 File Offset: 0x0012F130
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04002E23 RID: 11811
		public uint headFrameId;

		// Token: 0x04002E24 RID: 11812
		public uint expireTime;
	}
}
