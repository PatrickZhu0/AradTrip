using System;

namespace GameClient
{
	// Token: 0x02001A4D RID: 6733
	public struct BuyGoodsResult
	{
		// Token: 0x06010873 RID: 67699 RVA: 0x004A88B0 File Offset: 0x004A6CB0
		public BuyGoodsResult(int a_nGoodsID, int a_nLimitBuyCount)
		{
			this.goodsID = a_nGoodsID;
			this.limitBuyCount = a_nLimitBuyCount;
		}

		// Token: 0x0400A858 RID: 43096
		public int goodsID;

		// Token: 0x0400A859 RID: 43097
		public int limitBuyCount;
	}
}
