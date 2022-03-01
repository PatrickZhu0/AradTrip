using System;

namespace Protocol
{
	// Token: 0x02000B91 RID: 2961
	[Protocol]
	public class WorldTeamRequesterListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D74 RID: 32116 RVA: 0x0016526C File Offset: 0x0016366C
		public uint GetMsgID()
		{
			return 601638U;
		}

		// Token: 0x06007D75 RID: 32117 RVA: 0x00165273 File Offset: 0x00163673
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D76 RID: 32118 RVA: 0x0016527B File Offset: 0x0016367B
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D77 RID: 32119 RVA: 0x00165284 File Offset: 0x00163684
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007D78 RID: 32120 RVA: 0x00165286 File Offset: 0x00163686
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007D79 RID: 32121 RVA: 0x00165288 File Offset: 0x00163688
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007D7A RID: 32122 RVA: 0x0016528A File Offset: 0x0016368A
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007D7B RID: 32123 RVA: 0x0016528C File Offset: 0x0016368C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003B7F RID: 15231
		public const uint MsgID = 601638U;

		// Token: 0x04003B80 RID: 15232
		public uint Sequence;
	}
}
