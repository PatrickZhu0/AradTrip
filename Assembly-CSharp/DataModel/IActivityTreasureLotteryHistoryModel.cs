using System;

namespace DataModel
{
	// Token: 0x02001CE3 RID: 7395
	public interface IActivityTreasureLotteryHistoryModel : IActivityTreasureLotteryModelBase
	{
		// Token: 0x17001E65 RID: 7781
		// (get) Token: 0x06012280 RID: 74368
		string TimeSoldOut { get; }

		// Token: 0x17001E66 RID: 7782
		// (get) Token: 0x06012281 RID: 74369
		bool IsSellOut { get; }

		// Token: 0x17001E67 RID: 7783
		// (get) Token: 0x06012282 RID: 74370
		bool IsWin { get; }

		// Token: 0x17001E68 RID: 7784
		// (get) Token: 0x06012283 RID: 74371
		string CurrencyName { get; }

		// Token: 0x17001E69 RID: 7785
		// (get) Token: 0x06012284 RID: 74372
		HistroyPlayerData[] PlayerList { get; }
	}
}
