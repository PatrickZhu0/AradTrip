using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A71 RID: 6769
	public class ShopNewSpecialPriceControl : MonoBehaviour
	{
		// Token: 0x060109E9 RID: 68073 RVA: 0x004B3610 File Offset: 0x004B1A10
		public void InitSpecialPriceControl(List<ShopNewCostItemDataModel> costItemDataModelList, int vipDisCount = 100, int curBuyNumber = 1)
		{
			if (costItemDataModelList == null || costItemDataModelList.Count <= 0)
			{
				return;
			}
			this.ResetCostItem();
			int num = (this.shopNewCostItemList.Count < costItemDataModelList.Count) ? this.shopNewCostItemList.Count : costItemDataModelList.Count;
			for (int i = 0; i < num; i++)
			{
				ShopNewCostItem shopNewCostItem = this.shopNewCostItemList[i];
				ShopNewCostItemDataModel shopNewCostItemDataModel = costItemDataModelList[i];
				if (!(shopNewCostItem == null) && shopNewCostItemDataModel != null)
				{
					CommonUtility.UpdateGameObjectVisible(shopNewCostItem.gameObject, true);
					shopNewCostItem.InitCostItem(shopNewCostItemDataModel.CostItemId, shopNewCostItemDataModel.CostItemNumber, vipDisCount);
					if (curBuyNumber > 1)
					{
						shopNewCostItem.UpdateCostItemValueByBuyNumber(curBuyNumber);
					}
					else
					{
						shopNewCostItem.UpdateCostItemValue();
					}
				}
			}
		}

		// Token: 0x060109EA RID: 68074 RVA: 0x004B36DC File Offset: 0x004B1ADC
		private void ResetCostItem()
		{
			if (this.shopNewCostItemList == null || this.shopNewCostItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.shopNewCostItemList.Count; i++)
			{
				if (this.shopNewCostItemList[i] != null)
				{
					CommonUtility.UpdateGameObjectVisible(this.shopNewCostItemList[i].gameObject, false);
				}
			}
		}

		// Token: 0x060109EB RID: 68075 RVA: 0x004B3750 File Offset: 0x004B1B50
		public void UpdateCostItemListValue()
		{
			for (int i = 0; i < this.shopNewCostItemList.Count; i++)
			{
				ShopNewCostItem shopNewCostItem = this.shopNewCostItemList[i];
				if (shopNewCostItem != null && shopNewCostItem.gameObject.activeSelf)
				{
					shopNewCostItem.UpdateCostItemValue();
				}
			}
		}

		// Token: 0x060109EC RID: 68076 RVA: 0x004B37A8 File Offset: 0x004B1BA8
		public void UpdateCostItemListValueByNumber(int buyNumber)
		{
			for (int i = 0; i < this.shopNewCostItemList.Count; i++)
			{
				ShopNewCostItem shopNewCostItem = this.shopNewCostItemList[i];
				if (shopNewCostItem != null && shopNewCostItem.gameObject.activeSelf)
				{
					shopNewCostItem.UpdateCostItemValueByBuyNumber(buyNumber);
				}
			}
		}

		// Token: 0x0400A99D RID: 43421
		[Space(10f)]
		[Header("SpecialPriceItem")]
		[Space(10f)]
		[SerializeField]
		private List<ShopNewCostItem> shopNewCostItemList = new List<ShopNewCostItem>();
	}
}
