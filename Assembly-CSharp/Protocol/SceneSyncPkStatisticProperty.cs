using System;

namespace Protocol
{
	// Token: 0x020009FE RID: 2558
	[Protocol]
	public class SceneSyncPkStatisticProperty : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071B6 RID: 29110 RVA: 0x0014A3C8 File Offset: 0x001487C8
		public uint GetMsgID()
		{
			return 506704U;
		}

		// Token: 0x060071B7 RID: 29111 RVA: 0x0014A3CF File Offset: 0x001487CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071B8 RID: 29112 RVA: 0x0014A3D7 File Offset: 0x001487D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071B9 RID: 29113 RVA: 0x0014A3E0 File Offset: 0x001487E0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071BA RID: 29114 RVA: 0x0014A3E2 File Offset: 0x001487E2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071BB RID: 29115 RVA: 0x0014A3E4 File Offset: 0x001487E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071BC RID: 29116 RVA: 0x0014A3E6 File Offset: 0x001487E6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071BD RID: 29117 RVA: 0x0014A3E8 File Offset: 0x001487E8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400343C RID: 13372
		public const uint MsgID = 506704U;

		// Token: 0x0400343D RID: 13373
		public uint Sequence;
	}
}
