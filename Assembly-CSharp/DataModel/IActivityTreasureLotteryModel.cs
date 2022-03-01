using System;
using Protocol;

namespace DataModel
{
	// Token: 0x02001CE1 RID: 7393
	public interface IActivityTreasureLotteryModel : IActivityTreasureLotteryModelBase
	{
		// Token: 0x17001E4D RID: 7757
		// (get) Token: 0x06012268 RID: 74344
		int TotalNum { get; }

		// Token: 0x17001E4E RID: 7758
		// (get) Token: 0x06012269 RID: 74345
		uint LeftNum { get; }

		// Token: 0x17001E4F RID: 7759
		// (get) Token: 0x0601226A RID: 74346
		int LeftGroupNum { get; }

		// Token: 0x17001E50 RID: 7760
		// (get) Token: 0x0601226B RID: 74347
		int TotalGroup { get; }

		// Token: 0x17001E51 RID: 7761
		// (get) Token: 0x0601226C RID: 74348
		int BoughtNum { get; }

		// Token: 0x17001E52 RID: 7762
		// (get) Token: 0x0601226D RID: 74349
		int UnitPrice { get; }

		// Token: 0x17001E53 RID: 7763
		// (get) Token: 0x0601226E RID: 74350
		int MoneyId { get; }

		// Token: 0x17001E54 RID: 7764
		// (get) Token: 0x0601226F RID: 74351
		ushort GroupId { get; }

		// Token: 0x17001E55 RID: 7765
		// (get) Token: 0x06012270 RID: 74352
		string TimeRemainStr { get; }

		// Token: 0x17001E56 RID: 7766
		// (get) Token: 0x06012271 RID: 74353
		int TimeRemain { get; }

		// Token: 0x17001E57 RID: 7767
		// (get) Token: 0x06012272 RID: 74354
		ItemReward[] Compensation { get; }

		// Token: 0x17001E58 RID: 7768
		// (get) Token: 0x06012273 RID: 74355
		GambingItemStatus State { get; }
	}
}
