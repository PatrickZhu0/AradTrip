using System;

namespace Protocol
{
	// Token: 0x02000BC8 RID: 3016
	[Protocol]
	public class TeamCopyStartBattleVote : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007EB5 RID: 32437 RVA: 0x00167B0C File Offset: 0x00165F0C
		public uint GetMsgID()
		{
			return 1100016U;
		}

		// Token: 0x06007EB6 RID: 32438 RVA: 0x00167B13 File Offset: 0x00165F13
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007EB7 RID: 32439 RVA: 0x00167B1B File Offset: 0x00165F1B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007EB8 RID: 32440 RVA: 0x00167B24 File Offset: 0x00165F24
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x06007EB9 RID: 32441 RVA: 0x00167B34 File Offset: 0x00165F34
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x06007EBA RID: 32442 RVA: 0x00167B44 File Offset: 0x00165F44
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x06007EBB RID: 32443 RVA: 0x00167B54 File Offset: 0x00165F54
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x06007EBC RID: 32444 RVA: 0x00167B64 File Offset: 0x00165F64
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003C7F RID: 15487
		public const uint MsgID = 1100016U;

		// Token: 0x04003C80 RID: 15488
		public uint Sequence;

		// Token: 0x04003C81 RID: 15489
		public uint vote;
	}
}
