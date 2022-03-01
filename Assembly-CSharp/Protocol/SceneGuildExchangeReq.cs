using System;

namespace Protocol
{
	// Token: 0x02000852 RID: 2130
	[Protocol]
	public class SceneGuildExchangeReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006454 RID: 25684 RVA: 0x0012B990 File Offset: 0x00129D90
		public uint GetMsgID()
		{
			return 501901U;
		}

		// Token: 0x06006455 RID: 25685 RVA: 0x0012B997 File Offset: 0x00129D97
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006456 RID: 25686 RVA: 0x0012B99F File Offset: 0x00129D9F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006457 RID: 25687 RVA: 0x0012B9A8 File Offset: 0x00129DA8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006458 RID: 25688 RVA: 0x0012B9AA File Offset: 0x00129DAA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006459 RID: 25689 RVA: 0x0012B9AC File Offset: 0x00129DAC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600645A RID: 25690 RVA: 0x0012B9AE File Offset: 0x00129DAE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x0600645B RID: 25691 RVA: 0x0012B9B0 File Offset: 0x00129DB0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002CF6 RID: 11510
		public const uint MsgID = 501901U;

		// Token: 0x04002CF7 RID: 11511
		public uint Sequence;
	}
}
