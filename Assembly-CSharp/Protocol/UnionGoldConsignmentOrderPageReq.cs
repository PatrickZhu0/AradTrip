using System;

namespace Protocol
{
	// Token: 0x020007F4 RID: 2036
	[Protocol]
	public class UnionGoldConsignmentOrderPageReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061E4 RID: 25060 RVA: 0x00124830 File Offset: 0x00122C30
		public uint GetMsgID()
		{
			return 1210101U;
		}

		// Token: 0x060061E5 RID: 25061 RVA: 0x00124837 File Offset: 0x00122C37
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061E6 RID: 25062 RVA: 0x0012483F File Offset: 0x00122C3F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061E7 RID: 25063 RVA: 0x00124848 File Offset: 0x00122C48
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060061E8 RID: 25064 RVA: 0x0012484A File Offset: 0x00122C4A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060061E9 RID: 25065 RVA: 0x0012484C File Offset: 0x00122C4C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060061EA RID: 25066 RVA: 0x0012484E File Offset: 0x00122C4E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060061EB RID: 25067 RVA: 0x00124850 File Offset: 0x00122C50
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002B27 RID: 11047
		public const uint MsgID = 1210101U;

		// Token: 0x04002B28 RID: 11048
		public uint Sequence;
	}
}
