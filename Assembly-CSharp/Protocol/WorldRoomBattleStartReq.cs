using System;

namespace Protocol
{
	// Token: 0x02000AF0 RID: 2800
	[Protocol]
	public class WorldRoomBattleStartReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060078BB RID: 30907 RVA: 0x0015C958 File Offset: 0x0015AD58
		public uint GetMsgID()
		{
			return 607835U;
		}

		// Token: 0x060078BC RID: 30908 RVA: 0x0015C95F File Offset: 0x0015AD5F
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060078BD RID: 30909 RVA: 0x0015C967 File Offset: 0x0015AD67
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060078BE RID: 30910 RVA: 0x0015C970 File Offset: 0x0015AD70
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060078BF RID: 30911 RVA: 0x0015C972 File Offset: 0x0015AD72
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060078C0 RID: 30912 RVA: 0x0015C974 File Offset: 0x0015AD74
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060078C1 RID: 30913 RVA: 0x0015C976 File Offset: 0x0015AD76
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060078C2 RID: 30914 RVA: 0x0015C978 File Offset: 0x0015AD78
		public int getLen()
		{
			return 0;
		}

		// Token: 0x040038FB RID: 14587
		public const uint MsgID = 607835U;

		// Token: 0x040038FC RID: 14588
		public uint Sequence;
	}
}
