using System;

namespace Protocol
{
	// Token: 0x02000BE5 RID: 3045
	[Protocol]
	public class TeamCopyTeamDetailReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007FAB RID: 32683 RVA: 0x00169F20 File Offset: 0x00168320
		public uint GetMsgID()
		{
			return 1100043U;
		}

		// Token: 0x06007FAC RID: 32684 RVA: 0x00169F27 File Offset: 0x00168327
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007FAD RID: 32685 RVA: 0x00169F2F File Offset: 0x0016832F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007FAE RID: 32686 RVA: 0x00169F38 File Offset: 0x00168338
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06007FAF RID: 32687 RVA: 0x00169F48 File Offset: 0x00168348
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06007FB0 RID: 32688 RVA: 0x00169F58 File Offset: 0x00168358
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
		}

		// Token: 0x06007FB1 RID: 32689 RVA: 0x00169F68 File Offset: 0x00168368
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
		}

		// Token: 0x06007FB2 RID: 32690 RVA: 0x00169F78 File Offset: 0x00168378
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003CEF RID: 15599
		public const uint MsgID = 1100043U;

		// Token: 0x04003CF0 RID: 15600
		public uint Sequence;

		// Token: 0x04003CF1 RID: 15601
		public uint teamId;
	}
}
