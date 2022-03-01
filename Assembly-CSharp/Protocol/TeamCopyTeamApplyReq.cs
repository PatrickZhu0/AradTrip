using System;

namespace Protocol
{
	// Token: 0x02000BC0 RID: 3008
	[Protocol]
	public class TeamCopyTeamApplyReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E70 RID: 32368 RVA: 0x0016741D File Offset: 0x0016581D
		public uint GetMsgID()
		{
			return 1100009U;
		}

		// Token: 0x06007E71 RID: 32369 RVA: 0x00167424 File Offset: 0x00165824
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E72 RID: 32370 RVA: 0x0016742C File Offset: 0x0016582C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E73 RID: 32371 RVA: 0x00167435 File Offset: 0x00165835
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGold);
		}

		// Token: 0x06007E74 RID: 32372 RVA: 0x00167453 File Offset: 0x00165853
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGold);
		}

		// Token: 0x06007E75 RID: 32373 RVA: 0x00167471 File Offset: 0x00165871
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.teamId);
			BaseDLL.encode_uint32(buffer, ref pos_, this.isGold);
		}

		// Token: 0x06007E76 RID: 32374 RVA: 0x0016748F File Offset: 0x0016588F
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.teamId);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.isGold);
		}

		// Token: 0x06007E77 RID: 32375 RVA: 0x001674B0 File Offset: 0x001658B0
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C63 RID: 15459
		public const uint MsgID = 1100009U;

		// Token: 0x04003C64 RID: 15460
		public uint Sequence;

		// Token: 0x04003C65 RID: 15461
		public uint teamId;

		// Token: 0x04003C66 RID: 15462
		public uint isGold;
	}
}
