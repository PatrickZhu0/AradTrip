using System;
using System.Collections.Generic;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200111C RID: 4380
	public static class ChijiShopUtility
	{
		// Token: 0x0600A61E RID: 42526 RVA: 0x0022704C File Offset: 0x0022544C
		public static bool IsChijiShopItemAlreadySoldOver(int shopItemId)
		{
			if (DataManager<ChijiShopDataManager>.GetInstance().ChijiAlreadyBuyShopItemIdList == null || DataManager<ChijiShopDataManager>.GetInstance().ChijiAlreadyBuyShopItemIdList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < DataManager<ChijiShopDataManager>.GetInstance().ChijiAlreadyBuyShopItemIdList.Count; i++)
			{
				int num = DataManager<ChijiShopDataManager>.GetInstance().ChijiAlreadyBuyShopItemIdList[i];
				if (num == shopItemId)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600A61F RID: 42527 RVA: 0x002270BA File Offset: 0x002254BA
		public static bool IsChijiShopCanAutoRefresh()
		{
			return DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshTimeStamp > 0;
		}

		// Token: 0x0600A620 RID: 42528 RVA: 0x002270CF File Offset: 0x002254CF
		public static bool IsChijiShopRefreshTimeUp()
		{
			return DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshTimeStamp > 0 && (ulong)DataManager<TimeManager>.GetInstance().GetServerTime() >= (ulong)((long)DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshTimeStamp);
		}

		// Token: 0x0600A621 RID: 42529 RVA: 0x00227101 File Offset: 0x00225501
		public static bool IsCanRefreshChijiShopByGloryCoin()
		{
			return ChijiShopUtility.GetCurrentOwnerGloryCoinNumber() >= DataManager<ChijiShopDataManager>.GetInstance().ChijiShopRefreshCostValue;
		}

		// Token: 0x0600A622 RID: 42530 RVA: 0x0022711C File Offset: 0x0022551C
		public static ChiJiShopItemTable GetChijiShopItemTable(int shopItemId)
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<ChiJiShopItemTable>(shopItemId, string.Empty, string.Empty);
		}

		// Token: 0x0600A623 RID: 42531 RVA: 0x00227140 File Offset: 0x00225540
		public static void OnBuyItemInChijiScene(ChijiShopItemDataModel shopItemDataModel)
		{
			if (shopItemDataModel == null)
			{
				return;
			}
			if (shopItemDataModel.ShopItemTable == null)
			{
				return;
			}
			ChiJiShopItemTable shopItemTable = shopItemDataModel.ShopItemTable;
			int costItemID = shopItemTable.CostItemID;
			int costNum = shopItemTable.CostNum;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(costItemID, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			int itemID = shopItemTable.ItemID;
			ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemID, string.Empty, string.Empty);
			if (tableItem2 == null)
			{
				return;
			}
			string name = tableItem2.Name;
			string name2 = tableItem.Name;
			string tipContent = TR.Value("Chiji_Shop_Buy_Item_Tip", costNum, name2, name);
			CommonUtility.OnShowCommonMsgBox(tipContent, delegate
			{
				ChijiShopUtility.BuyItem(shopItemDataModel);
			}, TR.Value("Chiji_Shop_Item_Buy_Label"));
		}

		// Token: 0x0600A624 RID: 42532 RVA: 0x0022721D File Offset: 0x0022561D
		private static void BuyItem(ChijiShopItemDataModel chijiShopItemDataModel)
		{
			if (chijiShopItemDataModel == null)
			{
				return;
			}
			DataManager<ChijiShopDataManager>.GetInstance().OnSendBuyShopItemReq(chijiShopItemDataModel.ShopId, chijiShopItemDataModel.ShopItemId);
		}

		// Token: 0x0600A625 RID: 42533 RVA: 0x0022723C File Offset: 0x0022563C
		public static void OnSellItemInChijiScene(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			int priceItemID = itemData.PriceItemID;
			if (Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(priceItemID, string.Empty, string.Empty) == null)
			{
				return;
			}
			ChijiShopUtility.SellItem(itemData);
		}

		// Token: 0x0600A626 RID: 42534 RVA: 0x0022727A File Offset: 0x0022567A
		private static void SellItem(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			DataManager<ItemDataManager>.GetInstance().SellItem(itemData, 1);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600A627 RID: 42535 RVA: 0x0022729C File Offset: 0x0022569C
		public static ItemData GetItemDataByChijiShopItemDataModel(ChijiShopItemDataModel chijiShopItemDataModel)
		{
			if (chijiShopItemDataModel == null)
			{
				return null;
			}
			ItemData result = null;
			if (chijiShopItemDataModel.ChijiShopType == ChijiShopType.Sell)
			{
				result = DataManager<ItemDataManager>.GetInstance().GetItem(chijiShopItemDataModel.ItemGuid);
			}
			else if (chijiShopItemDataModel.ShopItemTable != null)
			{
				result = ItemDataManager.CreateItemDataFromTable(chijiShopItemDataModel.ShopItemTable.ItemID, 100, 0);
			}
			return result;
		}

		// Token: 0x0600A628 RID: 42536 RVA: 0x002272F8 File Offset: 0x002256F8
		public static int GetCurrentOwnerGloryCoinNumber()
		{
			return DataManager<CountDataManager>.GetInstance().GetCount("chi_ji_shop_coin");
		}

		// Token: 0x0600A629 RID: 42537 RVA: 0x00227318 File Offset: 0x00225718
		public static string GetItemDetailStr(ItemData itemData, bool isNeedItemName = true)
		{
			if (itemData == null)
			{
				return string.Empty;
			}
			List<string> list = new List<string>();
			if (isNeedItemName)
			{
				list.Add(itemData.GetColorName(string.Empty, false));
			}
			List<string> baseMainPropDescs = itemData.GetBaseMainPropDescs();
			if (baseMainPropDescs != null && baseMainPropDescs.Count > 0)
			{
				list.AddRange(baseMainPropDescs.ToList<string>());
			}
			List<string> fourAttrAndResistMagicDescs = itemData.GetFourAttrAndResistMagicDescs();
			if (fourAttrAndResistMagicDescs != null && fourAttrAndResistMagicDescs.Count > 0)
			{
				list.AddRange(fourAttrAndResistMagicDescs.ToList<string>());
			}
			List<string> randomAttrDescs = itemData.GetRandomAttrDescs();
			if (randomAttrDescs != null && randomAttrDescs.Count > 0)
			{
				list.AddRange(randomAttrDescs.ToList<string>());
			}
			List<string> attachAttrDescs = itemData.GetAttachAttrDescs();
			if (attachAttrDescs != null && attachAttrDescs.Count > 0)
			{
				list.AddRange(attachAttrDescs.ToList<string>());
			}
			List<string> complexAttrDescs = itemData.GetComplexAttrDescs();
			if (complexAttrDescs != null && complexAttrDescs.Count > 0)
			{
				list.AddRange(complexAttrDescs.ToList<string>());
			}
			List<string> masterAttrDescs = itemData.GetMasterAttrDescs(true);
			if (masterAttrDescs != null && masterAttrDescs.Count > 0)
			{
				list.AddRange(masterAttrDescs.ToList<string>());
			}
			string description = itemData.GetDescription();
			list.Add(description);
			if (list.Count <= 0)
			{
				return string.Empty;
			}
			string text = string.Empty;
			for (int i = 0; i < list.Count; i++)
			{
				text = text + list[i] + "\n";
			}
			return text;
		}
	}
}
