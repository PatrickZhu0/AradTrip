using System;

namespace Protocol
{
	// Token: 0x020008FA RID: 2298
	[Protocol]
	public class SceneUpdateNewItem : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600693A RID: 26938 RVA: 0x001366F0 File Offset: 0x00134AF0
		public uint GetMsgID()
		{
			return 500931U;
		}

		// Token: 0x0600693B RID: 26939 RVA: 0x001366F7 File Offset: 0x00134AF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600693C RID: 26940 RVA: 0x001366FF File Offset: 0x00134AFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600693D RID: 26941 RVA: 0x00136708 File Offset: 0x00134B08
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pack);
		}

		// Token: 0x0600693E RID: 26942 RVA: 0x00136718 File Offset: 0x00134B18
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pack);
		}

		// Token: 0x0600693F RID: 26943 RVA: 0x00136728 File Offset: 0x00134B28
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.pack);
		}

		// Token: 0x06006940 RID: 26944 RVA: 0x00136738 File Offset: 0x00134B38
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.pack);
		}

		// Token: 0x06006941 RID: 26945 RVA: 0x00136748 File Offset: 0x00134B48
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04002FB2 RID: 12210
		public const uint MsgID = 500931U;

		// Token: 0x04002FB3 RID: 12211
		public uint Sequence;

		// Token: 0x04002FB4 RID: 12212
		public byte pack;
	}
}
