using System;

namespace Protocol
{
	// Token: 0x0200091F RID: 2335
	[Protocol]
	public class SceneQuickBuyRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006A84 RID: 27268 RVA: 0x00138B84 File Offset: 0x00136F84
		public uint GetMsgID()
		{
			return 507102U;
		}

		// Token: 0x06006A85 RID: 27269 RVA: 0x00138B8B File Offset: 0x00136F8B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006A86 RID: 27270 RVA: 0x00138B93 File Offset: 0x00136F93
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006A87 RID: 27271 RVA: 0x00138B9C File Offset: 0x00136F9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006A88 RID: 27272 RVA: 0x00138BAC File Offset: 0x00136FAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006A89 RID: 27273 RVA: 0x00138BBC File Offset: 0x00136FBC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06006A8A RID: 27274 RVA: 0x00138BCC File Offset: 0x00136FCC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06006A8B RID: 27275 RVA: 0x00138BDC File Offset: 0x00136FDC
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003049 RID: 12361
		public const uint MsgID = 507102U;

		// Token: 0x0400304A RID: 12362
		public uint Sequence;

		// Token: 0x0400304B RID: 12363
		public uint result;
	}
}
