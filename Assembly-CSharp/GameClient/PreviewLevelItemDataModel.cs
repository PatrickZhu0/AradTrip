using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x0200127C RID: 4732
	public class PreviewLevelItemDataModel
	{
		// Token: 0x040066F4 RID: 26356
		public int HonorSystemLevel;

		// Token: 0x040066F5 RID: 26357
		public int HonorSystemTotalNeedExpValue;

		// Token: 0x040066F6 RID: 26358
		public int HonorSystemNeedExpValue;

		// Token: 0x040066F7 RID: 26359
		public int TitleId;

		// Token: 0x040066F8 RID: 26360
		public string HonorLevelName;

		// Token: 0x040066F9 RID: 26361
		public string HonorLevelFlagPath;

		// Token: 0x040066FA RID: 26362
		public List<string> ShopDiscountList = new List<string>();

		// Token: 0x040066FB RID: 26363
		public List<int> UnLockShopItemList = new List<int>();
	}
}
