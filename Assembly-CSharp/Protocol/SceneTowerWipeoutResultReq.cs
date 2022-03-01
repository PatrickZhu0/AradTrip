using System;

namespace Protocol
{
	// Token: 0x020007D5 RID: 2005
	[Protocol]
	public class SceneTowerWipeoutResultReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060060E8 RID: 24808 RVA: 0x00123274 File Offset: 0x00121674
		public uint GetMsgID()
		{
			return 507203U;
		}

		// Token: 0x060060E9 RID: 24809 RVA: 0x0012327B File Offset: 0x0012167B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060060EA RID: 24810 RVA: 0x00123283 File Offset: 0x00121683
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060060EB RID: 24811 RVA: 0x0012328C File Offset: 0x0012168C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060060EC RID: 24812 RVA: 0x0012328E File Offset: 0x0012168E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060060ED RID: 24813 RVA: 0x00123290 File Offset: 0x00121690
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060060EE RID: 24814 RVA: 0x00123292 File Offset: 0x00121692
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060060EF RID: 24815 RVA: 0x00123294 File Offset: 0x00121694
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400286A RID: 10346
		public const uint MsgID = 507203U;

		// Token: 0x0400286B RID: 10347
		public uint Sequence;
	}
}
