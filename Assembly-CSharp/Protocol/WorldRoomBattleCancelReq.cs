using System;

namespace Protocol
{
	// Token: 0x02000AF2 RID: 2802
	[Protocol]
	public class WorldRoomBattleCancelReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078CD RID: 30925 RVA: 0x0015CA04 File Offset: 0x0015AE04
		public uint GetMsgID()
		{
			return 607837U;
		}

		// Token: 0x060078CE RID: 30926 RVA: 0x0015CA0B File Offset: 0x0015AE0B
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078CF RID: 30927 RVA: 0x0015CA13 File Offset: 0x0015AE13
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078D0 RID: 30928 RVA: 0x0015CA1C File Offset: 0x0015AE1C
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060078D1 RID: 30929 RVA: 0x0015CA1E File Offset: 0x0015AE1E
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060078D2 RID: 30930 RVA: 0x0015CA20 File Offset: 0x0015AE20
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060078D3 RID: 30931 RVA: 0x0015CA22 File Offset: 0x0015AE22
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060078D4 RID: 30932 RVA: 0x0015CA24 File Offset: 0x0015AE24
		public int getLen()
		{
			return 0;
		}

		// Token: 0x04003900 RID: 14592
		public const uint MsgID = 607837U;

		// Token: 0x04003901 RID: 14593
		public uint Sequence;
	}
}
