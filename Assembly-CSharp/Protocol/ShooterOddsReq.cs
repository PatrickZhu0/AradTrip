using System;

namespace Protocol
{
	// Token: 0x02000733 RID: 1843
	[Protocol]
	public class ShooterOddsReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C1A RID: 23578 RVA: 0x001165F6 File Offset: 0x001149F6
		public uint GetMsgID()
		{
			return 708303U;
		}

		// Token: 0x06005C1B RID: 23579 RVA: 0x001165FD File Offset: 0x001149FD
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C1C RID: 23580 RVA: 0x00116605 File Offset: 0x00114A05
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C1D RID: 23581 RVA: 0x0011660E File Offset: 0x00114A0E
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C1E RID: 23582 RVA: 0x00116610 File Offset: 0x00114A10
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C1F RID: 23583 RVA: 0x00116612 File Offset: 0x00114A12
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C20 RID: 23584 RVA: 0x00116614 File Offset: 0x00114A14
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C21 RID: 23585 RVA: 0x00116618 File Offset: 0x00114A18
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400259C RID: 9628
		public const uint MsgID = 708303U;

		// Token: 0x0400259D RID: 9629
		public uint Sequence;
	}
}
