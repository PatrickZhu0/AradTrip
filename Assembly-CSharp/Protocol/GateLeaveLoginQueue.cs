using System;

namespace Protocol
{
	// Token: 0x020009CE RID: 2510
	[Protocol]
	public class GateLeaveLoginQueue : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007066 RID: 28774 RVA: 0x00145410 File Offset: 0x00143810
		public uint GetMsgID()
		{
			return 300318U;
		}

		// Token: 0x06007067 RID: 28775 RVA: 0x00145417 File Offset: 0x00143817
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007068 RID: 28776 RVA: 0x0014541F File Offset: 0x0014381F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007069 RID: 28777 RVA: 0x00145428 File Offset: 0x00143828
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600706A RID: 28778 RVA: 0x0014542A File Offset: 0x0014382A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600706B RID: 28779 RVA: 0x0014542C File Offset: 0x0014382C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600706C RID: 28780 RVA: 0x0014542E File Offset: 0x0014382E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600706D RID: 28781 RVA: 0x00145430 File Offset: 0x00143830
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003336 RID: 13110
		public const uint MsgID = 300318U;

		// Token: 0x04003337 RID: 13111
		public uint Sequence;
	}
}
