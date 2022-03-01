using System;

namespace Protocol
{
	// Token: 0x02000742 RID: 1858
	[Protocol]
	public class shooterRankReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C95 RID: 23701 RVA: 0x00117459 File Offset: 0x00115859
		public uint GetMsgID()
		{
			return 708314U;
		}

		// Token: 0x06005C96 RID: 23702 RVA: 0x00117460 File Offset: 0x00115860
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C97 RID: 23703 RVA: 0x00117468 File Offset: 0x00115868
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C98 RID: 23704 RVA: 0x00117471 File Offset: 0x00115871
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C99 RID: 23705 RVA: 0x00117473 File Offset: 0x00115873
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C9A RID: 23706 RVA: 0x00117475 File Offset: 0x00115875
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C9B RID: 23707 RVA: 0x00117477 File Offset: 0x00115877
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C9C RID: 23708 RVA: 0x0011747C File Offset: 0x0011587C
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040025CD RID: 9677
		public const uint MsgID = 708314U;

		// Token: 0x040025CE RID: 9678
		public uint Sequence;
	}
}
