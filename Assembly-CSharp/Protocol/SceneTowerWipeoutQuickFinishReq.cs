using System;

namespace Protocol
{
	// Token: 0x020007D9 RID: 2009
	[Protocol]
	public class SceneTowerWipeoutQuickFinishReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x0600610C RID: 24844 RVA: 0x00123729 File Offset: 0x00121B29
		public uint GetMsgID()
		{
			return 507205U;
		}

		// Token: 0x0600610D RID: 24845 RVA: 0x00123730 File Offset: 0x00121B30
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x0600610E RID: 24846 RVA: 0x00123738 File Offset: 0x00121B38
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x0600610F RID: 24847 RVA: 0x00123741 File Offset: 0x00121B41
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006110 RID: 24848 RVA: 0x00123743 File Offset: 0x00121B43
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006111 RID: 24849 RVA: 0x00123745 File Offset: 0x00121B45
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006112 RID: 24850 RVA: 0x00123747 File Offset: 0x00121B47
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006113 RID: 24851 RVA: 0x0012374C File Offset: 0x00121B4C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002878 RID: 10360
		public const uint MsgID = 507205U;

		// Token: 0x04002879 RID: 10361
		public uint Sequence;
	}
}
