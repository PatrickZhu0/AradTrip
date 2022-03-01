using System;

namespace Protocol
{
	// Token: 0x02000BC2 RID: 3010
	[Protocol]
	public class TeamCopyTeamQuitReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007E82 RID: 32386 RVA: 0x001675BC File Offset: 0x001659BC
		public uint GetMsgID()
		{
			return 1100011U;
		}

		// Token: 0x06007E83 RID: 32387 RVA: 0x001675C3 File Offset: 0x001659C3
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007E84 RID: 32388 RVA: 0x001675CB File Offset: 0x001659CB
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007E85 RID: 32389 RVA: 0x001675D4 File Offset: 0x001659D4
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007E86 RID: 32390 RVA: 0x001675D6 File Offset: 0x001659D6
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007E87 RID: 32391 RVA: 0x001675D8 File Offset: 0x001659D8
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007E88 RID: 32392 RVA: 0x001675DA File Offset: 0x001659DA
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007E89 RID: 32393 RVA: 0x001675DC File Offset: 0x001659DC
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003C6C RID: 15468
		public const uint MsgID = 1100011U;

		// Token: 0x04003C6D RID: 15469
		public uint Sequence;
	}
}
