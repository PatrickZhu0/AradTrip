using System;

namespace Protocol
{
	// Token: 0x0200073C RID: 1852
	[Protocol]
	public class StakeRecordReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005C65 RID: 23653 RVA: 0x00116DF8 File Offset: 0x001151F8
		public uint GetMsgID()
		{
			return 708310U;
		}

		// Token: 0x06005C66 RID: 23654 RVA: 0x00116DFF File Offset: 0x001151FF
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005C67 RID: 23655 RVA: 0x00116E07 File Offset: 0x00115207
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005C68 RID: 23656 RVA: 0x00116E10 File Offset: 0x00115210
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C69 RID: 23657 RVA: 0x00116E12 File Offset: 0x00115212
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005C6A RID: 23658 RVA: 0x00116E14 File Offset: 0x00115214
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C6B RID: 23659 RVA: 0x00116E16 File Offset: 0x00115216
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005C6C RID: 23660 RVA: 0x00116E18 File Offset: 0x00115218
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040025BA RID: 9658
		public const uint MsgID = 708310U;

		// Token: 0x040025BB RID: 9659
		public uint Sequence;
	}
}
