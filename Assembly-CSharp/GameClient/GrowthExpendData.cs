using System;
using UnityEngine.Events;

namespace GameClient
{
	// Token: 0x02001B7C RID: 7036
	public class GrowthExpendData
	{
		// Token: 0x0400B25F RID: 45663
		public StrengthenGrowthType mStrengthenGrowthType;

		// Token: 0x0400B260 RID: 45664
		public ItemData mEquipItemData;

		// Token: 0x0400B261 RID: 45665
		public UnityAction<ItemData> mOnItemClick;
	}
}
