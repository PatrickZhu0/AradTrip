using System;

namespace Protocol
{
	// Token: 0x020007EB RID: 2027
	[Protocol]
	public class SceneDungeonZjslClearGetAwardReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060061AE RID: 25006 RVA: 0x00124348 File Offset: 0x00122748
		public uint GetMsgID()
		{
			return 506840U;
		}

		// Token: 0x060061AF RID: 25007 RVA: 0x0012434F File Offset: 0x0012274F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060061B0 RID: 25008 RVA: 0x00124357 File Offset: 0x00122757
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060061B1 RID: 25009 RVA: 0x00124360 File Offset: 0x00122760
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060061B2 RID: 25010 RVA: 0x00124362 File Offset: 0x00122762
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060061B3 RID: 25011 RVA: 0x00124364 File Offset: 0x00122764
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060061B4 RID: 25012 RVA: 0x00124366 File Offset: 0x00122766
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060061B5 RID: 25013 RVA: 0x00124368 File Offset: 0x00122768
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040028B0 RID: 10416
		public const uint MsgID = 506840U;

		// Token: 0x040028B1 RID: 10417
		public uint Sequence;
	}
}
