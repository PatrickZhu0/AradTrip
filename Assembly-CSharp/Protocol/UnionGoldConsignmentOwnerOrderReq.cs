using System;

namespace Protocol
{
	// Token: 0x020007FC RID: 2044
	[Protocol]
	public class UnionGoldConsignmentOwnerOrderReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006226 RID: 25126 RVA: 0x00125692 File Offset: 0x00123A92
		public uint GetMsgID()
		{
			return 1210105U;
		}

		// Token: 0x06006227 RID: 25127 RVA: 0x00125699 File Offset: 0x00123A99
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006228 RID: 25128 RVA: 0x001256A1 File Offset: 0x00123AA1
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006229 RID: 25129 RVA: 0x001256AA File Offset: 0x00123AAA
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600622A RID: 25130 RVA: 0x001256AC File Offset: 0x00123AAC
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x0600622B RID: 25131 RVA: 0x001256AE File Offset: 0x00123AAE
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600622C RID: 25132 RVA: 0x001256B0 File Offset: 0x00123AB0
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600622D RID: 25133 RVA: 0x001256B4 File Offset: 0x00123AB4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002B54 RID: 11092
		public const uint MsgID = 1210105U;

		// Token: 0x04002B55 RID: 11093
		public uint Sequence;
	}
}
