using System;

namespace GameClient
{
	// Token: 0x02001B36 RID: 6966
	internal class OptionItemData
	{
		// Token: 0x0400B044 RID: 45124
		public bool IsMaterial;

		// Token: 0x0400B045 RID: 45125
		public ItemData itemData;

		// Token: 0x0400B046 RID: 45126
		public ClientFrame frame;

		// Token: 0x0400B047 RID: 45127
		public bool isLeft;

		// Token: 0x0400B048 RID: 45128
		public Action<ItemData> onItemRemove;

		// Token: 0x0400B049 RID: 45129
		public Action<ItemData, bool> onItemAdd;

		// Token: 0x0400B04A RID: 45130
		public Action<bool> onOpenEquipList;

		// Token: 0x0400B04B RID: 45131
		public string bg;
	}
}
