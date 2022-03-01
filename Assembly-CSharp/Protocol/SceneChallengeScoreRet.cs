using System;

namespace Protocol
{
	// Token: 0x0200068A RID: 1674
	[Protocol]
	public class SceneChallengeScoreRet : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005702 RID: 22274 RVA: 0x00109F70 File Offset: 0x00108370
		public uint GetMsgID()
		{
			return 507415U;
		}

		// Token: 0x06005703 RID: 22275 RVA: 0x00109F77 File Offset: 0x00108377
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005704 RID: 22276 RVA: 0x00109F7F File Offset: 0x0010837F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005705 RID: 22277 RVA: 0x00109F88 File Offset: 0x00108388
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06005706 RID: 22278 RVA: 0x00109F98 File Offset: 0x00108398
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06005707 RID: 22279 RVA: 0x00109FA8 File Offset: 0x001083A8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.score);
		}

		// Token: 0x06005708 RID: 22280 RVA: 0x00109FB8 File Offset: 0x001083B8
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.score);
		}

		// Token: 0x06005709 RID: 22281 RVA: 0x00109FC8 File Offset: 0x001083C8
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x0400228D RID: 8845
		public const uint MsgID = 507415U;

		// Token: 0x0400228E RID: 8846
		public uint Sequence;

		// Token: 0x0400228F RID: 8847
		public uint score;
	}
}
