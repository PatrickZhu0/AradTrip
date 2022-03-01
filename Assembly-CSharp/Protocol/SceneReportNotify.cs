using System;

namespace Protocol
{
	// Token: 0x02000B49 RID: 2889
	[Protocol]
	public class SceneReportNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007B58 RID: 31576 RVA: 0x00160EC8 File Offset: 0x0015F2C8
		public uint GetMsgID()
		{
			return 501228U;
		}

		// Token: 0x06007B59 RID: 31577 RVA: 0x00160ECF File Offset: 0x0015F2CF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007B5A RID: 31578 RVA: 0x00160ED7 File Offset: 0x0015F2D7
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007B5B RID: 31579 RVA: 0x00160EE0 File Offset: 0x0015F2E0
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007B5C RID: 31580 RVA: 0x00160EE2 File Offset: 0x0015F2E2
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007B5D RID: 31581 RVA: 0x00160EE4 File Offset: 0x0015F2E4
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007B5E RID: 31582 RVA: 0x00160EE6 File Offset: 0x0015F2E6
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007B5F RID: 31583 RVA: 0x00160EE8 File Offset: 0x0015F2E8
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003A68 RID: 14952
		public const uint MsgID = 501228U;

		// Token: 0x04003A69 RID: 14953
		public uint Sequence;
	}
}
