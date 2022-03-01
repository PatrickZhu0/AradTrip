using System;

namespace Protocol
{
	// Token: 0x02000BFE RID: 3070
	[Protocol]
	public class TeamCopyFieldUnlockRate : IProtocolStream, IGetMsgID
	{
		// Token: 0x06008089 RID: 32905 RVA: 0x0016BBF0 File Offset: 0x00169FF0
		public uint GetMsgID()
		{
			return 1100067U;
		}

		// Token: 0x0600808A RID: 32906 RVA: 0x0016BBF7 File Offset: 0x00169FF7
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600808B RID: 32907 RVA: 0x0016BBFF File Offset: 0x00169FFF
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600808C RID: 32908 RVA: 0x0016BC08 File Offset: 0x0016A008
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.bossPhase);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bossBloodRate);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unlockRate);
		}

		// Token: 0x0600808D RID: 32909 RVA: 0x0016BC42 File Offset: 0x0016A042
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bossPhase);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bossBloodRate);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unlockRate);
		}

		// Token: 0x0600808E RID: 32910 RVA: 0x0016BC7C File Offset: 0x0016A07C
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.bossPhase);
			BaseDLL.encode_uint32(buffer, ref pos_, this.bossBloodRate);
			BaseDLL.encode_uint32(buffer, ref pos_, this.fieldId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.unlockRate);
		}

		// Token: 0x0600808F RID: 32911 RVA: 0x0016BCB6 File Offset: 0x0016A0B6
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bossPhase);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.bossBloodRate);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.fieldId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.unlockRate);
		}

		// Token: 0x06008090 RID: 32912 RVA: 0x0016BCF0 File Offset: 0x0016A0F0
		public int getLen()
		{
			int num = 0;
			num += 4;
			num += 4;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D5B RID: 15707
		public const uint MsgID = 1100067U;

		// Token: 0x04003D5C RID: 15708
		public uint Sequence;

		// Token: 0x04003D5D RID: 15709
		public uint bossPhase;

		// Token: 0x04003D5E RID: 15710
		public uint bossBloodRate;

		// Token: 0x04003D5F RID: 15711
		public uint fieldId;

		// Token: 0x04003D60 RID: 15712
		public uint unlockRate;
	}
}
