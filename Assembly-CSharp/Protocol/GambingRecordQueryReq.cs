using System;

namespace Protocol
{
	// Token: 0x0200094E RID: 2382
	[Protocol]
	public class GambingRecordQueryReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06006C22 RID: 27682 RVA: 0x0013B571 File Offset: 0x00139971
		public uint GetMsgID()
		{
			return 707907U;
		}

		// Token: 0x06006C23 RID: 27683 RVA: 0x0013B578 File Offset: 0x00139978
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06006C24 RID: 27684 RVA: 0x0013B580 File Offset: 0x00139980
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06006C25 RID: 27685 RVA: 0x0013B589 File Offset: 0x00139989
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006C26 RID: 27686 RVA: 0x0013B58B File Offset: 0x0013998B
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06006C27 RID: 27687 RVA: 0x0013B58D File Offset: 0x0013998D
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006C28 RID: 27688 RVA: 0x0013B58F File Offset: 0x0013998F
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06006C29 RID: 27689 RVA: 0x0013B594 File Offset: 0x00139994
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040030F5 RID: 12533
		public const uint MsgID = 707907U;

		// Token: 0x040030F6 RID: 12534
		public uint Sequence;
	}
}
