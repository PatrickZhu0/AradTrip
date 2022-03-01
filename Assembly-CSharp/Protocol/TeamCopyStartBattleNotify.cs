using System;

namespace Protocol
{
	// Token: 0x02000BC7 RID: 3015
	[Protocol]
	public class TeamCopyStartBattleNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EAC RID: 32428 RVA: 0x00167A5C File Offset: 0x00165E5C
		public uint GetMsgID()
		{
			return 1100015U;
		}

		// Token: 0x06007EAD RID: 32429 RVA: 0x00167A63 File Offset: 0x00165E63
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EAE RID: 32430 RVA: 0x00167A6B File Offset: 0x00165E6B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EAF RID: 32431 RVA: 0x00167A74 File Offset: 0x00165E74
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteDurationTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteEndTime);
		}

		// Token: 0x06007EB0 RID: 32432 RVA: 0x00167A92 File Offset: 0x00165E92
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteDurationTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteEndTime);
		}

		// Token: 0x06007EB1 RID: 32433 RVA: 0x00167AB0 File Offset: 0x00165EB0
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteDurationTime);
			BaseDLL.encode_uint32(buffer, ref pos_, this.voteEndTime);
		}

		// Token: 0x06007EB2 RID: 32434 RVA: 0x00167ACE File Offset: 0x00165ECE
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteDurationTime);
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.voteEndTime);
		}

		// Token: 0x06007EB3 RID: 32435 RVA: 0x00167AEC File Offset: 0x00165EEC
		public int getLen()
		{
			int num = 0;
			num += 4;
			return num + 4;
		}

		// Token: 0x04003C7B RID: 15483
		public const uint MsgID = 1100015U;

		// Token: 0x04003C7C RID: 15484
		public uint Sequence;

		// Token: 0x04003C7D RID: 15485
		public uint voteDurationTime;

		// Token: 0x04003C7E RID: 15486
		public uint voteEndTime;
	}
}
