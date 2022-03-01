using System;

namespace GameClient
{
	// Token: 0x02000F52 RID: 3922
	public interface IActivityConsumeData
	{
		// Token: 0x0600986C RID: 39020
		long GetLeftCount();

		// Token: 0x0600986D RID: 39021
		long GetSumCount();

		// Token: 0x0600986E RID: 39022
		bool IsCanBuyCount();

		// Token: 0x0600986F RID: 39023
		long GetLeftBuyCount();

		// Token: 0x06009870 RID: 39024
		long GetHasUsedCount();

		// Token: 0x06009871 RID: 39025
		long GetHasBuyCount();

		// Token: 0x06009872 RID: 39026
		int GetCostItemID();

		// Token: 0x06009873 RID: 39027
		int GetCostItemCount();

		// Token: 0x06009874 RID: 39028
		byte GetCostItemType();
	}
}
