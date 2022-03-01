using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020012DD RID: 4829
	public class ShopNewShopItemTable
	{
		// Token: 0x0400694C RID: 26956
		public int ShopId;

		// Token: 0x0400694D RID: 26957
		public int ShopItemId;

		// Token: 0x0400694E RID: 26958
		public ShopItemTable ShopItemTable;

		// Token: 0x0400694F RID: 26959
		public int Grid;

		// Token: 0x04006950 RID: 26960
		public int LimitBuyTimes = -1;

		// Token: 0x04006951 RID: 26961
		public int VipLimitLevel;

		// Token: 0x04006952 RID: 26962
		public int VipDiscount;

		// Token: 0x04006953 RID: 26963
		public int GoodDiscount;
	}
}
