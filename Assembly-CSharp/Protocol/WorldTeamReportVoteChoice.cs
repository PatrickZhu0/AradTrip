using System;

namespace Protocol
{
	// Token: 0x02000B96 RID: 2966
	[Protocol]
	public class WorldTeamReportVoteChoice : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007DA1 RID: 32161 RVA: 0x0016562C File Offset: 0x00163A2C
		public uint GetMsgID()
		{
			return 601643U;
		}

		// Token: 0x06007DA2 RID: 32162 RVA: 0x00165633 File Offset: 0x00163A33
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007DA3 RID: 32163 RVA: 0x0016563B File Offset: 0x00163A3B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007DA4 RID: 32164 RVA: 0x00165644 File Offset: 0x00163A44
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007DA5 RID: 32165 RVA: 0x00165654 File Offset: 0x00163A54
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007DA6 RID: 32166 RVA: 0x00165664 File Offset: 0x00163A64
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_int8(buffer, ref pos_, this.agree);
		}

		// Token: 0x06007DA7 RID: 32167 RVA: 0x00165674 File Offset: 0x00163A74
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_int8(buffer, ref pos_, ref this.agree);
		}

		// Token: 0x06007DA8 RID: 32168 RVA: 0x00165684 File Offset: 0x00163A84
		public int getLen()
		{
			int num = 0;
			return num + 1;
		}

		// Token: 0x04003B8F RID: 15247
		public const uint MsgID = 601643U;

		// Token: 0x04003B90 RID: 15248
		public uint Sequence;

		// Token: 0x04003B91 RID: 15249
		public byte agree;
	}
}
