using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001CF9 RID: 7417
	public class FinancialPlanRewardModel
	{
		// Token: 0x060123B0 RID: 74672 RVA: 0x0054E941 File Offset: 0x0054CD41
		public int GetRewardItemId()
		{
			if (this.RewardItemList.Count > 0)
			{
				return this.RewardItemList[0].ItemID;
			}
			return 0;
		}

		// Token: 0x060123B1 RID: 74673 RVA: 0x0054E967 File Offset: 0x0054CD67
		public int GetRewardItemCount()
		{
			if (this.RewardItemList.Count > 0)
			{
				return this.RewardItemList[0].Count;
			}
			return 0;
		}

		// Token: 0x060123B2 RID: 74674 RVA: 0x0054E98D File Offset: 0x0054CD8D
		public void PrintRewardModel()
		{
		}

		// Token: 0x0400BDA5 RID: 48549
		public int Index = 1;

		// Token: 0x0400BDA6 RID: 48550
		public int Id;

		// Token: 0x0400BDA7 RID: 48551
		public int LevelLimit;

		// Token: 0x0400BDA8 RID: 48552
		public List<ItemSimpleData> RewardItemList = new List<ItemSimpleData>();

		// Token: 0x0400BDA9 RID: 48553
		public FinancialPlanState RewardState = FinancialPlanState.Invalid;

		// Token: 0x0400BDAA RID: 48554
		public FinancialPlanState ShowRewardState = FinancialPlanState.Invalid;
	}
}
