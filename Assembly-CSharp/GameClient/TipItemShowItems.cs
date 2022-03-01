using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020016DE RID: 5854
	internal class TipItemShowItems : TipItem
	{
		// Token: 0x0600E53E RID: 58686 RVA: 0x003B9048 File Offset: 0x003B7448
		public TipItemShowItems(List<GiftTable> a_arrData)
		{
			this.Type = ETipItemType.ShowItems;
			for (int i = 0; i < a_arrData.Count; i++)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(a_arrData[i].ItemID, 100, 0);
				if (itemData != null)
				{
					itemData.Count = a_arrData[i].ItemCount;
					this.arrItemData.Add(itemData);
				}
			}
		}

		// Token: 0x04008AC0 RID: 35520
		public List<ItemData> arrItemData = new List<ItemData>();
	}
}
