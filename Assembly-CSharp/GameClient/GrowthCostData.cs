using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001244 RID: 4676
	public class GrowthCostData
	{
		// Token: 0x0600B3AB RID: 45995 RVA: 0x0027FF92 File Offset: 0x0027E392
		public GrowthCostData(int quality, int growthLevel, int equipLevel, List<ItemSimpleData> growthCosts)
		{
			this.quality = quality;
			this.growthLevel = growthLevel;
			this.equipLevel = equipLevel;
			this.growthCosts = growthCosts;
		}

		// Token: 0x04006557 RID: 25943
		public int quality;

		// Token: 0x04006558 RID: 25944
		public int growthLevel;

		// Token: 0x04006559 RID: 25945
		public int equipLevel;

		// Token: 0x0400655A RID: 25946
		public List<ItemSimpleData> growthCosts;
	}
}
