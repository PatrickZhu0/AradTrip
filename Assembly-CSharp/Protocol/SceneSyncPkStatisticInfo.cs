using System;

namespace Protocol
{
	// Token: 0x020009FD RID: 2557
	[Protocol]
	public class SceneSyncPkStatisticInfo : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071AD RID: 29101 RVA: 0x0014A390 File Offset: 0x00148790
		public uint GetMsgID()
		{
			return 506703U;
		}

		// Token: 0x060071AE RID: 29102 RVA: 0x0014A397 File Offset: 0x00148797
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071AF RID: 29103 RVA: 0x0014A39F File Offset: 0x0014879F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071B0 RID: 29104 RVA: 0x0014A3A8 File Offset: 0x001487A8
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071B1 RID: 29105 RVA: 0x0014A3AA File Offset: 0x001487AA
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071B2 RID: 29106 RVA: 0x0014A3AC File Offset: 0x001487AC
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071B3 RID: 29107 RVA: 0x0014A3AE File Offset: 0x001487AE
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071B4 RID: 29108 RVA: 0x0014A3B0 File Offset: 0x001487B0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400343A RID: 13370
		public const uint MsgID = 506703U;

		// Token: 0x0400343B RID: 13371
		public uint Sequence;
	}
}
