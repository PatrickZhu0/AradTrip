using System;

namespace Protocol
{
	// Token: 0x02000B44 RID: 2884
	[Protocol]
	public class SceneSetEqualPvpSkillConfigReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B2B RID: 31531 RVA: 0x00160B84 File Offset: 0x0015EF84
		public uint GetMsgID()
		{
			return 501226U;
		}

		// Token: 0x06007B2C RID: 31532 RVA: 0x00160B8B File Offset: 0x0015EF8B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B2D RID: 31533 RVA: 0x00160B93 File Offset: 0x0015EF93
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B2E RID: 31534 RVA: 0x00160B9C File Offset: 0x0015EF9C
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isSetedEqualPvPConfig);
		}

		// Token: 0x06007B2F RID: 31535 RVA: 0x00160BAC File Offset: 0x0015EFAC
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSetedEqualPvPConfig);
		}

		// Token: 0x06007B30 RID: 31536 RVA: 0x00160BBC File Offset: 0x0015EFBC
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isSetedEqualPvPConfig);
		}

		// Token: 0x06007B31 RID: 31537 RVA: 0x00160BCC File Offset: 0x0015EFCC
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isSetedEqualPvPConfig);
		}

		// Token: 0x06007B32 RID: 31538 RVA: 0x00160BDC File Offset: 0x0015EFDC
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003A58 RID: 14936
		public const uint MsgID = 501226U;

		// Token: 0x04003A59 RID: 14937
		public uint Sequence;

		// Token: 0x04003A5A RID: 14938
		public byte isSetedEqualPvPConfig;
	}
}
