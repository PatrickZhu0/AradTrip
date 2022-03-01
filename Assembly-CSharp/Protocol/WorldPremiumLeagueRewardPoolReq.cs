using System;

namespace Protocol
{
	// Token: 0x02000A68 RID: 2664
	[Protocol]
	public class WorldPremiumLeagueRewardPoolReq : IProtocolStream, IGetMsgID
	{
		// Token: 0x060074D7 RID: 29911 RVA: 0x00152712 File Offset: 0x00150B12
		public uint GetMsgID()
		{
			return 607702U;
		}

		// Token: 0x060074D8 RID: 29912 RVA: 0x00152719 File Offset: 0x00150B19
		public uint GetSequence()
		{
			return this.Sequence;
		}

		// Token: 0x060074D9 RID: 29913 RVA: 0x00152721 File Offset: 0x00150B21
		public void SetSequence(uint sequence)
		{
			this.Sequence = sequence;
		}

		// Token: 0x060074DA RID: 29914 RVA: 0x0015272A File Offset: 0x00150B2A
		public void encode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060074DB RID: 29915 RVA: 0x0015272C File Offset: 0x00150B2C
		public void decode(byte[] buffer, ref int pos_)
		{
		}

		// Token: 0x060074DC RID: 29916 RVA: 0x0015272E File Offset: 0x00150B2E
		public void encode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060074DD RID: 29917 RVA: 0x00152730 File Offset: 0x00150B30
		public void decode(MapViewStream buffer, ref int pos_)
		{
		}

		// Token: 0x060074DE RID: 29918 RVA: 0x00152734 File Offset: 0x00150B34
		public int getLen()
		{
			return 0;
		}

		// Token: 0x0400365C RID: 13916
		public const uint MsgID = 607702U;

		// Token: 0x0400365D RID: 13917
		public uint Sequence;
	}
}
