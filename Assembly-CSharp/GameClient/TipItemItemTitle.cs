using System;

namespace GameClient
{
	// Token: 0x020016D9 RID: 5849
	internal class TipItemItemTitle : TipItem
	{
		// Token: 0x0600E539 RID: 58681 RVA: 0x003B8FD1 File Offset: 0x003B73D1
		public TipItemItemTitle(ItemData a_data, string a_levelLimitDesc)
		{
			this.Type = ETipItemType.ItemTitle;
			this.itemData = a_data;
			this.levelLimitDesc = a_levelLimitDesc;
		}

		// Token: 0x04008ABA RID: 35514
		public ItemData itemData;

		// Token: 0x04008ABB RID: 35515
		public string levelLimitDesc;
	}
}
