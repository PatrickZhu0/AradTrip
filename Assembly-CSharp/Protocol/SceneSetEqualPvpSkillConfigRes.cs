using System;

namespace Protocol
{
	// Token: 0x02000B45 RID: 2885
	[Protocol]
	public class SceneSetEqualPvpSkillConfigRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B34 RID: 31540 RVA: 0x00160BF8 File Offset: 0x0015EFF8
		public uint GetMsgID()
		{
			return 501227U;
		}

		// Token: 0x06007B35 RID: 31541 RVA: 0x00160BFF File Offset: 0x0015EFFF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B36 RID: 31542 RVA: 0x00160C07 File Offset: 0x0015F007
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B37 RID: 31543 RVA: 0x00160C10 File Offset: 0x0015F010
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007B38 RID: 31544 RVA: 0x00160C20 File Offset: 0x0015F020
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007B39 RID: 31545 RVA: 0x00160C30 File Offset: 0x0015F030
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.result);
		}

		// Token: 0x06007B3A RID: 31546 RVA: 0x00160C40 File Offset: 0x0015F040
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.result);
		}

		// Token: 0x06007B3B RID: 31547 RVA: 0x00160C50 File Offset: 0x0015F050
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003A5B RID: 14939
		public const uint MsgID = 501227U;

		// Token: 0x04003A5C RID: 14940
		public uint Sequence;

		// Token: 0x04003A5D RID: 14941
		public uint result;
	}
}
