using System;
using System.Collections.Generic;

namespace GameClient
{
	// Token: 0x02001AB6 RID: 6838
	internal class CommonGetItemData
	{
		// Token: 0x0400AC32 RID: 44082
		public string title;

		// Token: 0x0400AC33 RID: 44083
		public List<ResultItemData> itemDatas;

		// Token: 0x0400AC34 RID: 44084
		public ComItem.OnItemClicked itemClickCallback;
	}
}
