using System;

namespace GameClient
{
	// Token: 0x02001116 RID: 4374
	public class SettlementInfo
	{
		// Token: 0x0600A5F3 RID: 42483 RVA: 0x002261F2 File Offset: 0x002245F2
		public void ClearData()
		{
			this.rank = 0U;
			this.playerNum = 0U;
			this.kills = 0U;
			this.survivalTime = 0U;
			this.score = 0U;
			this.glory = 0U;
		}

		// Token: 0x04005CBF RID: 23743
		public uint rank;

		// Token: 0x04005CC0 RID: 23744
		public uint playerNum;

		// Token: 0x04005CC1 RID: 23745
		public uint kills;

		// Token: 0x04005CC2 RID: 23746
		public uint survivalTime;

		// Token: 0x04005CC3 RID: 23747
		public uint score;

		// Token: 0x04005CC4 RID: 23748
		public uint glory;
	}
}
