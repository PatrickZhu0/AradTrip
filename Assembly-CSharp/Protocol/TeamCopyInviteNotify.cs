using System;

namespace Protocol
{
	// Token: 0x02000BDC RID: 3036
	[Protocol]
	public class TeamCopyInviteNotify : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007F5D RID: 32605 RVA: 0x001696CB File Offset: 0x00167ACB
		public uint GetMsgID()
		{
			return 1100032U;
		}

		// Token: 0x06007F5E RID: 32606 RVA: 0x001696D2 File Offset: 0x00167AD2
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007F5F RID: 32607 RVA: 0x001696DA File Offset: 0x00167ADA
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007F60 RID: 32608 RVA: 0x001696E3 File Offset: 0x00167AE3
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007F61 RID: 32609 RVA: 0x001696E5 File Offset: 0x00167AE5
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007F62 RID: 32610 RVA: 0x001696E7 File Offset: 0x00167AE7
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007F63 RID: 32611 RVA: 0x001696E9 File Offset: 0x00167AE9
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007F64 RID: 32612 RVA: 0x001696EC File Offset: 0x00167AEC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003CCC RID: 15564
		public const uint MsgID = 1100032U;

		// Token: 0x04003CCD RID: 15565
		public uint Sequence;
	}
}
