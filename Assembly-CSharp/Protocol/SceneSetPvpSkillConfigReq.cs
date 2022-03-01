using System;

namespace Protocol
{
	// Token: 0x02000B42 RID: 2882
	[Protocol]
	public class SceneSetPvpSkillConfigReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B19 RID: 31513 RVA: 0x00160A9C File Offset: 0x0015EE9C
		public uint GetMsgID()
		{
			return 501221U;
		}

		// Token: 0x06007B1A RID: 31514 RVA: 0x00160AA3 File Offset: 0x0015EEA3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B1B RID: 31515 RVA: 0x00160AAB File Offset: 0x0015EEAB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B1C RID: 31516 RVA: 0x00160AB4 File Offset: 0x0015EEB4
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isUsePvpConfig);
		}

		// Token: 0x06007B1D RID: 31517 RVA: 0x00160AC4 File Offset: 0x0015EEC4
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isUsePvpConfig);
		}

		// Token: 0x06007B1E RID: 31518 RVA: 0x00160AD4 File Offset: 0x0015EED4
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.isUsePvpConfig);
		}

		// Token: 0x06007B1F RID: 31519 RVA: 0x00160AE4 File Offset: 0x0015EEE4
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.isUsePvpConfig);
		}

		// Token: 0x06007B20 RID: 31520 RVA: 0x00160AF4 File Offset: 0x0015EEF4
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003A52 RID: 14930
		public const uint MsgID = 501221U;

		// Token: 0x04003A53 RID: 14931
		public uint Sequence;

		// Token: 0x04003A54 RID: 14932
		public byte isUsePvpConfig;
	}
}
