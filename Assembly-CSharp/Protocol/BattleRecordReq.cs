using System;

namespace Protocol
{
	// Token: 0x0200073F RID: 1855
	[Protocol]
	public class BattleRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C7D RID: 23677 RVA: 0x0011715D File Offset: 0x0011555D
		public uint GetMsgID()
		{
			return 708312U;
		}

		// Token: 0x06005C7E RID: 23678 RVA: 0x00117164 File Offset: 0x00115564
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C7F RID: 23679 RVA: 0x0011716C File Offset: 0x0011556C
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C80 RID: 23680 RVA: 0x00117175 File Offset: 0x00115575
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C81 RID: 23681 RVA: 0x00117177 File Offset: 0x00115577
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C82 RID: 23682 RVA: 0x00117179 File Offset: 0x00115579
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C83 RID: 23683 RVA: 0x0011717B File Offset: 0x0011557B
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C84 RID: 23684 RVA: 0x00117180 File Offset: 0x00115580
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040025C4 RID: 9668
		public const uint MsgID = 708312U;

		// Token: 0x040025C5 RID: 9669
		public uint Sequence;
	}
}
