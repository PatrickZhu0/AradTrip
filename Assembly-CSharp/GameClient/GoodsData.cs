using System;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001A49 RID: 6729
	internal class GoodsData
	{
		// Token: 0x06010871 RID: 67697 RVA: 0x004A8848 File Offset: 0x004A6C48
		public GoodsData.GoodsDataShowType GetShowType(int iVipLevel)
		{
			if (this.VipLimitLevel > 0)
			{
				return GoodsData.GoodsDataShowType.GDST_VIP;
			}
			if (this.LimitBuyTimes >= 0)
			{
				return GoodsData.GoodsDataShowType.GDST_LIMIT_COUNT;
			}
			return GoodsData.GoodsDataShowType.GDST_NORMAL;
		}

		// Token: 0x0400A831 RID: 43057
		public int? ID;

		// Token: 0x0400A832 RID: 43058
		public ItemData ItemData;

		// Token: 0x0400A833 RID: 43059
		public ShopTable.eSubType? Type;

		// Token: 0x0400A834 RID: 43060
		public ItemData CostItemData;

		// Token: 0x0400A835 RID: 43061
		public int? CostItemCount;

		// Token: 0x0400A836 RID: 43062
		public int? VipLimitLevel;

		// Token: 0x0400A837 RID: 43063
		public int? VipDiscount;

		// Token: 0x0400A838 RID: 43064
		public int? LimitBuyCount;

		// Token: 0x0400A839 RID: 43065
		public int LimitBuyTimes;

		// Token: 0x0400A83A RID: 43066
		public GoodsLimitButyType eGoodsLimitButyType;

		// Token: 0x0400A83B RID: 43067
		public int iLimitValue;

		// Token: 0x0400A83C RID: 43068
		public ShopItemTable shopItem;

		// Token: 0x0400A83D RID: 43069
		public int TotalLimitBuyTimes;

		// Token: 0x0400A83E RID: 43070
		public int? GoodsDisCount;

		// Token: 0x0400A83F RID: 43071
		public int LeaseEndTimeStamp;

		// Token: 0x02001A4A RID: 6730
		public enum GoodsDataShowType
		{
			// Token: 0x0400A841 RID: 43073
			GDST_NORMAL,
			// Token: 0x0400A842 RID: 43074
			GDST_VIP,
			// Token: 0x0400A843 RID: 43075
			GDST_LIMIT_COUNT,
			// Token: 0x0400A844 RID: 43076
			GDST_HIDE
		}
	}
}
