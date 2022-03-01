using System;

namespace Protocol
{
	// Token: 0x02000BD8 RID: 3032
	[Protocol]
	public class TeamCopyStartChallengeRes : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F39 RID: 32569 RVA: 0x001692E8 File Offset: 0x001676E8
		public uint GetMsgID()
		{
			return 1100028U;
		}

		// Token: 0x06007F3A RID: 32570 RVA: 0x001692EF File Offset: 0x001676EF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F3B RID: 32571 RVA: 0x001692F7 File Offset: 0x001676F7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F3C RID: 32572 RVA: 0x00169300 File Offset: 0x00167700
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007F3D RID: 32573 RVA: 0x00169310 File Offset: 0x00167710
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007F3E RID: 32574 RVA: 0x00169320 File Offset: 0x00167720
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.retCode);
		}

		// Token: 0x06007F3F RID: 32575 RVA: 0x00169330 File Offset: 0x00167730
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.retCode);
		}

		// Token: 0x06007F40 RID: 32576 RVA: 0x00169340 File Offset: 0x00167740
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003CC1 RID: 15553
		public const uint MsgID = 1100028U;

		// Token: 0x04003CC2 RID: 15554
		public uint Sequence;

		// Token: 0x04003CC3 RID: 15555
		public uint retCode;
	}
}
