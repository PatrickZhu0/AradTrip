using System;

namespace Protocol
{
	// Token: 0x02000B88 RID: 2952
	[Protocol]
	public class WorldDismissTeam : IProtocolStream, IGetMsgID
	{
		// Token: 0x06007D23 RID: 32035 RVA: 0x00164960 File Offset: 0x00162D60
		public uint GetMsgID()
		{
			return 601611U;
		}

		// Token: 0x06007D24 RID: 32036 RVA: 0x00164967 File Offset: 0x00162D67
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06007D25 RID: 32037 RVA: 0x0016496F File Offset: 0x00162D6F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06007D26 RID: 32038 RVA: 0x00164978 File Offset: 0x00162D78
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007D27 RID: 32039 RVA: 0x0016497A File Offset: 0x00162D7A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06007D28 RID: 32040 RVA: 0x0016497C File Offset: 0x00162D7C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007D29 RID: 32041 RVA: 0x0016497E File Offset: 0x00162D7E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06007D2A RID: 32042 RVA: 0x00164980 File Offset: 0x00162D80
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003B59 RID: 15193
		public const uint MsgID = 601611U;

		// Token: 0x04003B5A RID: 15194
		public uint Sequence;
	}
}
