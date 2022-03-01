using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001A4C RID: 6732
	internal class ShopData
	{
		// Token: 0x0400A84B RID: 43083
		public int? ID;

		// Token: 0x0400A84C RID: 43084
		public string Name;

		// Token: 0x0400A84D RID: 43085
		public string ShopNamePath;

		// Token: 0x0400A84E RID: 43086
		public List<ShopTable.eSubType> GoodsTypes = new List<ShopTable.eSubType>();

		// Token: 0x0400A84F RID: 43087
		public int? NeedRefresh;

		// Token: 0x0400A850 RID: 43088
		public int? RefreshCost;

		// Token: 0x0400A851 RID: 43089
		public uint RefreshTime;

		// Token: 0x0400A852 RID: 43090
		public List<GoodsData> Goods = new List<GoodsData>();

		// Token: 0x0400A853 RID: 43091
		public int RefreshLeftTimes;

		// Token: 0x0400A854 RID: 43092
		public int RefreshTotalTimes;

		// Token: 0x0400A855 RID: 43093
		public uint WeekRefreshTime;

		// Token: 0x0400A856 RID: 43094
		public uint MonthRefreshTime;

		// Token: 0x0400A857 RID: 43095
		public int iLinkNpcId = -1;
	}
}
