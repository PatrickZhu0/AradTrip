using System;

namespace GameClient
{
	// Token: 0x02001245 RID: 4677
	public class GrowthAttributeData
	{
		// Token: 0x0600B3AC RID: 45996 RVA: 0x0027FFB7 File Offset: 0x0027E3B7
		public GrowthAttributeData(int quality, int growthLevel, int equipLevel, int growthAttributeNum)
		{
			this.quality = quality;
			this.growthLevel = growthLevel;
			this.equipLevel = equipLevel;
			this.growthAttributeNum = growthAttributeNum;
		}

		// Token: 0x0400655B RID: 25947
		public int quality;

		// Token: 0x0400655C RID: 25948
		public int growthLevel;

		// Token: 0x0400655D RID: 25949
		public int equipLevel;

		// Token: 0x0400655E RID: 25950
		public int growthAttributeNum;
	}
}
