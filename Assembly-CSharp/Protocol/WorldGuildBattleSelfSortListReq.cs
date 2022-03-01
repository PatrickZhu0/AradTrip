using System;

namespace Protocol
{
	// Token: 0x02000860 RID: 2144
	[Protocol]
	public class WorldGuildBattleSelfSortListReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060064D2 RID: 25810 RVA: 0x0012C461 File Offset: 0x0012A861
		public uint GetMsgID()
		{
			return 601955U;
		}

		// Token: 0x060064D3 RID: 25811 RVA: 0x0012C468 File Offset: 0x0012A868
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060064D4 RID: 25812 RVA: 0x0012C470 File Offset: 0x0012A870
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060064D5 RID: 25813 RVA: 0x0012C479 File Offset: 0x0012A879
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060064D6 RID: 25814 RVA: 0x0012C47B File Offset: 0x0012A87B
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060064D7 RID: 25815 RVA: 0x0012C47D File Offset: 0x0012A87D
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060064D8 RID: 25816 RVA: 0x0012C47F File Offset: 0x0012A87F
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060064D9 RID: 25817 RVA: 0x0012C484 File Offset: 0x0012A884
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002D28 RID: 11560
		public const uint MsgID = 601955U;

		// Token: 0x04002D29 RID: 11561
		public uint Sequence;
	}
}
