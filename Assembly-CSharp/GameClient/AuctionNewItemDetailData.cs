using System;
using System.Collections.Generic;
using Protocol;

namespace GameClient
{
	// Token: 0x020011EB RID: 4587
	public class AuctionNewItemDetailData
	{
		// Token: 0x040062AB RID: 25259
		public int Type;

		// Token: 0x040062AC RID: 25260
		public List<AuctionBaseInfo> ItemDetailDataList;

		// Token: 0x040062AD RID: 25261
		public int CurPage;

		// Token: 0x040062AE RID: 25262
		public int MaxPage;

		// Token: 0x040062AF RID: 25263
		public int NoticeType;
	}
}
