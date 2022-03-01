using System;

namespace GameClient
{
	// Token: 0x02001BB0 RID: 7088
	internal struct StrengthenCost
	{
		// Token: 0x060115AB RID: 71083 RVA: 0x00505619 File Offset: 0x00503A19
		public StrengthenCost(int goldCost, int unColorCost, int colorCost)
		{
			this.GoldCost = goldCost;
			this.UnColorCost = unColorCost;
			this.ColorCost = colorCost;
		}

		// Token: 0x0400B3F3 RID: 46067
		public int GoldCost;

		// Token: 0x0400B3F4 RID: 46068
		public int UnColorCost;

		// Token: 0x0400B3F5 RID: 46069
		public int ColorCost;
	}
}
