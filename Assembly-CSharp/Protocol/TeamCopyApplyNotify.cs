using System;

namespace Protocol
{
	// Token: 0x02000BF5 RID: 3061
	[Protocol]
	public class TeamCopyApplyNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008038 RID: 32824 RVA: 0x0016B244 File Offset: 0x00169644
		public uint GetMsgID()
		{
			return 1100058U;
		}

		// Token: 0x06008039 RID: 32825 RVA: 0x0016B24B File Offset: 0x0016964B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600803A RID: 32826 RVA: 0x0016B253 File Offset: 0x00169653
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600803B RID: 32827 RVA: 0x0016B25C File Offset: 0x0016965C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.IsHasApply);
		}

		// Token: 0x0600803C RID: 32828 RVA: 0x0016B26C File Offset: 0x0016966C
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.IsHasApply);
		}

		// Token: 0x0600803D RID: 32829 RVA: 0x0016B27C File Offset: 0x0016967C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.IsHasApply);
		}

		// Token: 0x0600803E RID: 32830 RVA: 0x0016B28C File Offset: 0x0016968C
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.IsHasApply);
		}

		// Token: 0x0600803F RID: 32831 RVA: 0x0016B29C File Offset: 0x0016969C
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D30 RID: 15664
		public const uint MsgID = 1100058U;

		// Token: 0x04003D31 RID: 15665
		public uint Sequence;

		// Token: 0x04003D32 RID: 15666
		public uint IsHasApply;
	}
}
