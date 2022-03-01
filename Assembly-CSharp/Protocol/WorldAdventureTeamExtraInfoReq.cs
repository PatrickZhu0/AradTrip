using System;

namespace Protocol
{
	// Token: 0x0200069E RID: 1694
	[Protocol]
	public class WorldAdventureTeamExtraInfoReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060057A1 RID: 22433 RVA: 0x0010B180 File Offset: 0x00109580
		public uint GetMsgID()
		{
			return 608609U;
		}

		// Token: 0x060057A2 RID: 22434 RVA: 0x0010B187 File Offset: 0x00109587
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060057A3 RID: 22435 RVA: 0x0010B18F File Offset: 0x0010958F
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060057A4 RID: 22436 RVA: 0x0010B198 File Offset: 0x00109598
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060057A5 RID: 22437 RVA: 0x0010B19A File Offset: 0x0010959A
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060057A6 RID: 22438 RVA: 0x0010B19C File Offset: 0x0010959C
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060057A7 RID: 22439 RVA: 0x0010B19E File Offset: 0x0010959E
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060057A8 RID: 22440 RVA: 0x0010B1A0 File Offset: 0x001095A0
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040022D8 RID: 8920
		public const uint MsgID = 608609U;

		// Token: 0x040022D9 RID: 8921
		public uint Sequence;
	}
}
