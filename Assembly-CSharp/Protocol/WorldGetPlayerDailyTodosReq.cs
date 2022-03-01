using System;

namespace Protocol
{
	// Token: 0x0200078B RID: 1931
	[Protocol]
	public class WorldGetPlayerDailyTodosReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x06005ED8 RID: 24280 RVA: 0x0011C778 File Offset: 0x0011AB78
		public uint GetMsgID()
		{
			return 609301U;
		}

		// Token: 0x06005ED9 RID: 24281 RVA: 0x0011C77F File Offset: 0x0011AB7F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x06005EDA RID: 24282 RVA: 0x0011C787 File Offset: 0x0011AB87
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x06005EDB RID: 24283 RVA: 0x0011C790 File Offset: 0x0011AB90
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005EDC RID: 24284 RVA: 0x0011C792 File Offset: 0x0011AB92
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x06005EDD RID: 24285 RVA: 0x0011C794 File Offset: 0x0011AB94
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005EDE RID: 24286 RVA: 0x0011C796 File Offset: 0x0011AB96
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x06005EDF RID: 24287 RVA: 0x0011C798 File Offset: 0x0011AB98
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04002715 RID: 10005
		public const uint MsgID = 609301U;

		// Token: 0x04002716 RID: 10006
		public uint Sequence;
	}
}
