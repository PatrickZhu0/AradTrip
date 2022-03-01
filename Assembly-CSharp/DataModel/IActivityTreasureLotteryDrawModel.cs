using System;

namespace DataModel
{
	// Token: 0x02001CE4 RID: 7396
	public interface IActivityTreasureLotteryDrawModel
	{
		// Token: 0x17001E6A RID: 7786
		// (get) Token: 0x06012285 RID: 74373
		string WinnerName { get; }

		// Token: 0x17001E6B RID: 7787
		// (get) Token: 0x06012286 RID: 74374
		string WinnerRate { get; }

		// Token: 0x17001E6C RID: 7788
		// (get) Token: 0x06012287 RID: 74375
		string ServerName { get; }

		// Token: 0x17001E6D RID: 7789
		// (get) Token: 0x06012288 RID: 74376
		string PlatformName { get; }

		// Token: 0x17001E6E RID: 7790
		// (get) Token: 0x06012289 RID: 74377
		bool IsPlayerWin { get; }

		// Token: 0x17001E6F RID: 7791
		// (get) Token: 0x0601228A RID: 74378
		int ItemId { get; }

		// Token: 0x17001E70 RID: 7792
		// (get) Token: 0x0601228B RID: 74379
		DrawWinnerData[] TopFiveInvestPlayers { get; }
	}
}
