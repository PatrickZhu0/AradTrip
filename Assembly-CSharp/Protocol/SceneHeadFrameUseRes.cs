using System;

namespace Protocol
{
	// Token: 0x020008AA RID: 2218
	[Protocol]
	public class SceneHeadFrameUseRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006754 RID: 26452 RVA: 0x00130F78 File Offset: 0x0012F378
		public uint GetMsgID()
		{
			return 509104U;
		}

		// Token: 0x06006755 RID: 26453 RVA: 0x00130F7F File Offset: 0x0012F37F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006756 RID: 26454 RVA: 0x00130F87 File Offset: 0x0012F387
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006757 RID: 26455 RVA: 0x00130F90 File Offset: 0x0012F390
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006758 RID: 26456 RVA: 0x00130FA0 File Offset: 0x0012F3A0
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006759 RID: 26457 RVA: 0x00130FB0 File Offset: 0x0012F3B0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x0600675A RID: 26458 RVA: 0x00130FC0 File Offset: 0x0012F3C0
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x0600675B RID: 26459 RVA: 0x00130FD0 File Offset: 0x0012F3D0
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04002E2B RID: 11819
		public const uint MsgID = 509104U;

		// Token: 0x04002E2C RID: 11820
		public uint Sequence;

		// Token: 0x04002E2D RID: 11821
		public uint retCode;
	}
}
