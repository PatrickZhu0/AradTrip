using System;

namespace GameClient
{
	// Token: 0x020017DB RID: 6107
	internal class MoneyRewaradsRankItemData
	{
		// Token: 0x17001CF1 RID: 7409
		// (get) Token: 0x0600F0BC RID: 61628 RVA: 0x0040D06A File Offset: 0x0040B46A
		public bool Mark
		{
			get
			{
				return this.rank <= 8 && this.rank >= 1;
			}
		}

		// Token: 0x17001CF2 RID: 7410
		// (get) Token: 0x0600F0BD RID: 61629 RVA: 0x0040D087 File Offset: 0x0040B487
		public string Rank
		{
			get
			{
				if (this.rank >= 1 && this.rank <= 100)
				{
					return this.rank.ToString();
				}
				return TR.Value("money_rewards_has_no_rank");
			}
		}

		// Token: 0x040093BA RID: 37818
		public int rank;

		// Token: 0x040093BB RID: 37819
		public string name;

		// Token: 0x040093BC RID: 37820
		public int score;

		// Token: 0x040093BD RID: 37821
		public int maxScore;
	}
}
