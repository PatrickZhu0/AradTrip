using System;
using System.Collections.Generic;
using Protocol;

namespace DataModel
{
	// Token: 0x02001CE2 RID: 7394
	public interface IActivityTreasureLotteryMyLotteryModel : IActivityTreasureLotteryModelBase
	{
		// Token: 0x17001E59 RID: 7769
		// (get) Token: 0x06012274 RID: 74356
		GambingMineStatus Status { get; }

		// Token: 0x17001E5A RID: 7770
		// (get) Token: 0x06012275 RID: 74357
		string WinRate { get; }

		// Token: 0x17001E5B RID: 7771
		// (get) Token: 0x06012276 RID: 74358
		int GroupId { get; }

		// Token: 0x17001E5C RID: 7772
		// (get) Token: 0x06012277 RID: 74359
		int MyInvestment { get; }

		// Token: 0x17001E5D RID: 7773
		// (get) Token: 0x06012278 RID: 74360
		string CurrencyName { get; }

		// Token: 0x17001E5E RID: 7774
		// (get) Token: 0x06012279 RID: 74361
		string WinnerName { get; }

		// Token: 0x17001E5F RID: 7775
		// (get) Token: 0x0601227A RID: 74362
		string WinnerServer { get; }

		// Token: 0x17001E60 RID: 7776
		// (get) Token: 0x0601227B RID: 74363
		int WinnerInvestment { get; }

		// Token: 0x17001E61 RID: 7777
		// (get) Token: 0x0601227C RID: 74364
		int BoughtNum { get; }

		// Token: 0x17001E62 RID: 7778
		// (get) Token: 0x0601227D RID: 74365
		int TotalNum { get; }

		// Token: 0x17001E63 RID: 7779
		// (get) Token: 0x0601227E RID: 74366
		int RestNum { get; }

		// Token: 0x17001E64 RID: 7780
		// (get) Token: 0x0601227F RID: 74367
		List<GambingParticipantInfo> AllPlayerInvestInfo { get; }
	}
}
