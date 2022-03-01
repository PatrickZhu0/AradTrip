using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001359 RID: 4953
	public class MapGridItemData
	{
		// Token: 0x04006C71 RID: 27761
		public int gridIndex;

		// Token: 0x04006C72 RID: 27762
		public int gridType;

		// Token: 0x04006C73 RID: 27763
		public int randomType;

		// Token: 0x04006C74 RID: 27764
		public string gridIconPath;

		// Token: 0x04006C75 RID: 27765
		public string gridName;

		// Token: 0x04006C76 RID: 27766
		public string gridDesc;

		// Token: 0x04006C77 RID: 27767
		public int itemCount;

		// Token: 0x04006C78 RID: 27768
		public List<ItemSimpleData> rewardList;
	}
}
