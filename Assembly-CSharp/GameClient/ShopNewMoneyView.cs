using System;
using System.Collections.Generic;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001A86 RID: 6790
	public class ShopNewMoneyView : MonoBehaviour
	{
		// Token: 0x06010A8D RID: 68237 RVA: 0x004B7858 File Offset: 0x004B5C58
		public void InitShopNewMoney(int shopId)
		{
			this._shopId = shopId;
			this._shopCostItemIdList = DataManager<ShopNewDataManager>.GetInstance().GetShopCostItems(this._shopId);
			if (this._shopCostItemIdList == null || this._shopCostItemIdList.Count <= 0)
			{
				return;
			}
			this.InitShopNewMoneyView();
		}

		// Token: 0x06010A8E RID: 68238 RVA: 0x004B78A5 File Offset: 0x004B5CA5
		public void InitShopNewMoneyByShopTab(int shopId, int shopTab)
		{
			this._shopCostItemIdList = DataManager<ShopNewDataManager>.GetInstance().GetShopCostItemsByShopTab(shopId, shopTab);
			if (this._shopCostItemIdList == null || this._shopCostItemIdList.Count <= 0)
			{
				return;
			}
			this.InitShopNewMoneyView();
		}

		// Token: 0x06010A8F RID: 68239 RVA: 0x004B78DC File Offset: 0x004B5CDC
		private void InitShopNewMoneyView()
		{
			if (this.shopNewMoneyItemList == null || this.shopNewMoneyItemList.Count <= 0)
			{
				return;
			}
			this.ResetShopNewMoneyItemList();
			int count = this._shopCostItemIdList.Count;
			int count2 = this.shopNewMoneyItemList.Count;
			int num = (count < count2) ? count : count2;
			for (int i = 0; i < num; i++)
			{
				int moneyId = this._shopCostItemIdList[i];
				ShopNewMoneyItem shopNewMoneyItem = this.shopNewMoneyItemList[i];
				if (shopNewMoneyItem != null)
				{
					shopNewMoneyItem.gameObject.CustomActive(true);
					shopNewMoneyItem.InitMoneyItem(moneyId);
				}
			}
		}

		// Token: 0x06010A90 RID: 68240 RVA: 0x004B7984 File Offset: 0x004B5D84
		private void ResetShopNewMoneyItemList()
		{
			if (this.shopNewMoneyItemList == null || this.shopNewMoneyItemList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < this.shopNewMoneyItemList.Count; i++)
			{
				ShopNewMoneyItem shopNewMoneyItem = this.shopNewMoneyItemList[i];
				if (!(shopNewMoneyItem == null))
				{
					shopNewMoneyItem.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06010A91 RID: 68241 RVA: 0x004B79F4 File Offset: 0x004B5DF4
		private void OnDestroy()
		{
			if (this._shopCostItemIdList != null)
			{
				this._shopCostItemIdList.Clear();
			}
		}

		// Token: 0x0400AA35 RID: 43573
		private int _shopId;

		// Token: 0x0400AA36 RID: 43574
		private List<int> _shopCostItemIdList;

		// Token: 0x0400AA37 RID: 43575
		[SerializeField]
		private List<ShopNewMoneyItem> shopNewMoneyItemList;
	}
}
