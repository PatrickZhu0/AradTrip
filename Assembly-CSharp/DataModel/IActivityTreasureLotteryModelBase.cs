using System;

namespace DataModel
{
	// Token: 0x02001CE0 RID: 7392
	public interface IActivityTreasureLotteryModelBase
	{
		// Token: 0x17001E47 RID: 7751
		// (get) Token: 0x06012262 RID: 74338
		int ItemId { get; }

		// Token: 0x17001E48 RID: 7752
		// (get) Token: 0x06012263 RID: 74339
		string IconPath { get; }

		// Token: 0x17001E49 RID: 7753
		// (get) Token: 0x06012264 RID: 74340
		string Name { get; }

		// Token: 0x17001E4A RID: 7754
		// (get) Token: 0x06012265 RID: 74341
		uint LotteryId { get; }

		// Token: 0x17001E4B RID: 7755
		// (get) Token: 0x06012266 RID: 74342
		int SortId { get; }

		// Token: 0x17001E4C RID: 7756
		// (get) Token: 0x06012267 RID: 74343
		uint ItemNum { get; }
	}
}
