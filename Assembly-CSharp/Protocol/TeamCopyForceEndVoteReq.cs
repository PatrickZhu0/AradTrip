using System;

namespace Protocol
{
	// Token: 0x02000C04 RID: 3076
	[Protocol]
	public class TeamCopyForceEndVoteReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060080BF RID: 32959 RVA: 0x0016C040 File Offset: 0x0016A440
		public uint GetMsgID()
		{
			return 1100073U;
		}

		// Token: 0x060080C0 RID: 32960 RVA: 0x0016C047 File Offset: 0x0016A447
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060080C1 RID: 32961 RVA: 0x0016C04F File Offset: 0x0016A44F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060080C2 RID: 32962 RVA: 0x0016C058 File Offset: 0x0016A458
		public void encode(byte[] buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x060080C3 RID: 32963 RVA: 0x0016C068 File Offset: 0x0016A468
		public void decode(byte[] buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x060080C4 RID: 32964 RVA: 0x0016C078 File Offset: 0x0016A478
		public void encode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.encode_uint32(buffer, ref pos_, this.vote);
		}

		// Token: 0x060080C5 RID: 32965 RVA: 0x0016C088 File Offset: 0x0016A488
		public void decode(MapViewStream buffer, ref int pos_)
		{
			BaseDLL.decode_uint32(buffer, ref pos_, ref this.vote);
		}

		// Token: 0x060080C6 RID: 32966 RVA: 0x0016C098 File Offset: 0x0016A498
		public int getLen()
		{
			int num = 0;
			return num + 4;
		}

		// Token: 0x04003D73 RID: 15731
		public const uint MsgID = 1100073U;

		// Token: 0x04003D74 RID: 15732
		public uint Sequence;

		// Token: 0x04003D75 RID: 15733
		public uint vote;
	}
}
