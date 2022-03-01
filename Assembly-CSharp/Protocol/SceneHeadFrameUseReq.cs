using System;

namespace Protocol
{
	// Token: 0x020008A9 RID: 2217
	[Protocol]
	public class SceneHeadFrameUseReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600674B RID: 26443 RVA: 0x00130F01 File Offset: 0x0012F301
		public uint GetMsgID()
		{
			return 509103U;
		}

		// Token: 0x0600674C RID: 26444 RVA: 0x00130F08 File Offset: 0x0012F308
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600674D RID: 26445 RVA: 0x00130F10 File Offset: 0x0012F310
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600674E RID: 26446 RVA: 0x00130F19 File Offset: 0x0012F319
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrameId);
		}

		// Token: 0x0600674F RID: 26447 RVA: 0x00130F29 File Offset: 0x0012F329
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrameId);
		}

		// Token: 0x06006750 RID: 26448 RVA: 0x00130F39 File Offset: 0x0012F339
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.headFrameId);
		}

		// Token: 0x06006751 RID: 26449 RVA: 0x00130F49 File Offset: 0x0012F349
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.headFrameId);
		}

		// Token: 0x06006752 RID: 26450 RVA: 0x00130F5C File Offset: 0x0012F35C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002E28 RID: 11816
		public const uint MsgID = 509103U;

		// Token: 0x04002E29 RID: 11817
		public uint Sequence;

		// Token: 0x04002E2A RID: 11818
		public uint headFrameId;
	}
}
