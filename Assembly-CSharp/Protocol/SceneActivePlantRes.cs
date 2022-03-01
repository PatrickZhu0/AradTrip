using System;

namespace Protocol
{
	// Token: 0x020009B0 RID: 2480
	[Protocol]
	public class SceneActivePlantRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006F79 RID: 28537 RVA: 0x00141EE0 File Offset: 0x001402E0
		public uint GetMsgID()
		{
			return 501095U;
		}

		// Token: 0x06006F7A RID: 28538 RVA: 0x00141EE7 File Offset: 0x001402E7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006F7B RID: 28539 RVA: 0x00141EEF File Offset: 0x001402EF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006F7C RID: 28540 RVA: 0x00141EF8 File Offset: 0x001402F8
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006F7D RID: 28541 RVA: 0x00141F08 File Offset: 0x00140308
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006F7E RID: 28542 RVA: 0x00141F18 File Offset: 0x00140318
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06006F7F RID: 28543 RVA: 0x00141F28 File Offset: 0x00140328
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06006F80 RID: 28544 RVA: 0x00141F38 File Offset: 0x00140338
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003297 RID: 12951
		public const uint MsgID = 501095U;

		// Token: 0x04003298 RID: 12952
		public uint Sequence;

		// Token: 0x04003299 RID: 12953
		public uint retCode;
	}
}
