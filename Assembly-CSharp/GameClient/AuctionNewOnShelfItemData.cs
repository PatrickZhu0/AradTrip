using System;
using Protocol;

namespace GameClient
{
	// Token: 0x0200148A RID: 5258
	public class AuctionNewOnShelfItemData
	{
		// Token: 0x0400766F RID: 30319
		public ulong PackageItemGuid;

		// Token: 0x04007670 RID: 30320
		public bool IsTreasure;

		// Token: 0x04007671 RID: 30321
		public bool IsTimeOverItem;

		// Token: 0x04007672 RID: 30322
		public AuctionBaseInfo ItemAuctionBaseInfo;

		// Token: 0x04007673 RID: 30323
		public int MaxShelfNum;

		// Token: 0x04007674 RID: 30324
		public int SelfOnShelfItemNum;
	}
}
