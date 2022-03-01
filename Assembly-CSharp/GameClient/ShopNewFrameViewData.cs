using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001A69 RID: 6761
	public class ShopNewFrameViewData
	{
		// Token: 0x0601098E RID: 67982 RVA: 0x004B1638 File Offset: 0x004AFA38
		public ShopNewFrameViewData()
		{
			this.totalTabDataList = new List<ShopNewMainTabData>();
			this.currentSelectedTabData = new ShopNewMainTabData();
			this.defaultSelectedTabData = new ShopNewMainTabData();
			this.currFirstFilterData = new ShopNewFilterData();
			this.currSecondFilterData = new ShopNewFilterData();
		}

		// Token: 0x0601098F RID: 67983 RVA: 0x004B168C File Offset: 0x004AFA8C
		public void Clear()
		{
			this.shopId = 0;
			this.npcId = 0;
			this.currentSelectedTabData = null;
			this.defaultSelectedTabData = null;
			this.currentSelectedTabIndex = 0;
			this.defaultSelectedTabIndex = 0;
			this.currFirstFilterData = null;
			this.currSecondFilterData = null;
			if (this.totalTabDataList != null)
			{
				this.totalTabDataList.Clear();
				this.totalTabDataList = null;
			}
		}

		// Token: 0x0400A953 RID: 43347
		public int shopId;

		// Token: 0x0400A954 RID: 43348
		public int npcId = -1;

		// Token: 0x0400A955 RID: 43349
		public List<ShopNewMainTabData> totalTabDataList;

		// Token: 0x0400A956 RID: 43350
		public ShopNewMainTabData currentSelectedTabData;

		// Token: 0x0400A957 RID: 43351
		public ShopNewMainTabData defaultSelectedTabData;

		// Token: 0x0400A958 RID: 43352
		public int currentSelectedTabIndex;

		// Token: 0x0400A959 RID: 43353
		public int defaultSelectedTabIndex;

		// Token: 0x0400A95A RID: 43354
		public ShopNewFilterData currFirstFilterData;

		// Token: 0x0400A95B RID: 43355
		public ShopNewFilterData currSecondFilterData;
	}
}
