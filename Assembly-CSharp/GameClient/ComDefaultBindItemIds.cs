using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001BB9 RID: 7097
	public class ComDefaultBindItemIds : MonoBehaviour
	{
		// Token: 0x0400B436 RID: 46134
		[Header("材料合成默认展示, 除特殊物品")]
		public List<int> mergeBindItemIds;

		// Token: 0x0400B437 RID: 46135
		[Header("材料合成默认展示，特殊物品")]
		public List<int> specialMergeItemIds;

		// Token: 0x0400B438 RID: 46136
		[Header("融合默认展示")]
		public List<int> fuseBindItemIds;

		// Token: 0x0400B439 RID: 46137
		[Header("合成或融合时，只需要展示需要数量的道具ids")]
		public List<int> onlyShowNeedCountItemIds;

		// Token: 0x0400B43A RID: 46138
		[Header("前往获取默认")]
		public int getBindItemId;

		// Token: 0x0400B43B RID: 46139
		[Header("融合强化券数目")]
		public int fuseTicketCount = 2;

		// Token: 0x0400B43C RID: 46140
		[Header("等待加载特效界面时间")]
		public float waitToLoadEffectPlane = 0.2f;

		// Token: 0x0400B43D RID: 46141
		[Header("等待材料合成界面选中时间")]
		public float waitToSelectMaterialFirstItem = 0.2f;

		// Token: 0x0400B43E RID: 46142
		[Header("合成或融合时，需要快捷购买的道具ids")]
		public List<int> needFastButItemIds;
	}
}
