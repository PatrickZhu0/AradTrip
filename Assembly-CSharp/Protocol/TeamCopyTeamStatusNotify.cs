using System;

namespace Protocol
{
	// Token: 0x02000BF4 RID: 3060
	[Protocol]
	public class TeamCopyTeamStatusNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600802F RID: 32815 RVA: 0x0016B194 File Offset: 0x00169594
		public uint GetMsgID()
		{
			return 1100057U;
		}

		// Token: 0x06008030 RID: 32816 RVA: 0x0016B19B File Offset: 0x0016959B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06008031 RID: 32817 RVA: 0x0016B1A3 File Offset: 0x001695A3
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06008032 RID: 32818 RVA: 0x0016B1AC File Offset: 0x001695AC
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamStatus);
		}

		// Token: 0x06008033 RID: 32819 RVA: 0x0016B1CA File Offset: 0x001695CA
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamStatus);
		}

		// Token: 0x06008034 RID: 32820 RVA: 0x0016B1E8 File Offset: 0x001695E8
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamStatus);
		}

		// Token: 0x06008035 RID: 32821 RVA: 0x0016B206 File Offset: 0x00169606
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamStatus);
		}

		// Token: 0x06008036 RID: 32822 RVA: 0x0016B224 File Offset: 0x00169624
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003D2C RID: 15660
		public const uint MsgID = 1100057U;

		// Token: 0x04003D2D RID: 15661
		public uint Sequence;

		// Token: 0x04003D2E RID: 15662
		public uint teamId;

		// Token: 0x04003D2F RID: 15663
		public uint teamStatus;
	}
}
