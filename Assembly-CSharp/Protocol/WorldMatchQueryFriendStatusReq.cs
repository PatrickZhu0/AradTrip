using System;

namespace Protocol
{
	// Token: 0x02000A05 RID: 2565
	[Protocol]
	public class WorldMatchQueryFriendStatusReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060071F2 RID: 29170 RVA: 0x0014AC84 File Offset: 0x00149084
		public uint GetMsgID()
		{
			return 606706U;
		}

		// Token: 0x060071F3 RID: 29171 RVA: 0x0014AC8B File Offset: 0x0014908B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060071F4 RID: 29172 RVA: 0x0014AC93 File Offset: 0x00149093
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060071F5 RID: 29173 RVA: 0x0014AC9C File Offset: 0x0014909C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071F6 RID: 29174 RVA: 0x0014AC9E File Offset: 0x0014909E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060071F7 RID: 29175 RVA: 0x0014ACA0 File Offset: 0x001490A0
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071F8 RID: 29176 RVA: 0x0014ACA2 File Offset: 0x001490A2
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060071F9 RID: 29177 RVA: 0x0014ACA4 File Offset: 0x001490A4
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003461 RID: 13409
		public const uint MsgID = 606706U;

		// Token: 0x04003462 RID: 13410
		public uint Sequence;
	}
}
