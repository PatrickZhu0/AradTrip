using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;

namespace GameClient
{
	// Token: 0x020012E0 RID: 4832
	public static class ShopNewUtility
	{
		// Token: 0x0600BB82 RID: 48002 RVA: 0x002B878D File Offset: 0x002B6B8D
		public static void OnCloseShopNewFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ShopNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ShopNewFrame>(null, false);
			}
		}

		// Token: 0x0600BB83 RID: 48003 RVA: 0x002B87AB File Offset: 0x002B6BAB
		public static void OnCloseShowNewPurchaseItemFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<ShopNewPurchaseItemFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<ShopNewPurchaseItemFrame>(null, false);
			}
		}

		// Token: 0x0600BB84 RID: 48004 RVA: 0x002B87CC File Offset: 0x002B6BCC
		public static OpActivityData GetActivityShopActivityData(int activityId)
		{
			return DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData((uint)activityId);
		}

		// Token: 0x0600BB85 RID: 48005 RVA: 0x002B87E6 File Offset: 0x002B6BE6
		public static bool IsActivityShop(ShopTable shopTable)
		{
			return shopTable != null && shopTable.ShopKind == ShopTable.eShopKind.SK_Activity;
		}

		// Token: 0x0600BB86 RID: 48006 RVA: 0x002B8800 File Offset: 0x002B6C00
		public static bool IsActivityShopInStartState(ShopTable shopTable)
		{
			int param = shopTable.Param1;
			OpActivityData activityShopActivityData = ShopNewUtility.GetActivityShopActivityData(param);
			return activityShopActivityData != null && activityShopActivityData.state == 1;
		}

		// Token: 0x0600BB87 RID: 48007 RVA: 0x002B8830 File Offset: 0x002B6C30
		public static string GetActivityShopTimeData(ShopTable shopTable)
		{
			int param = shopTable.Param1;
			OpActivityData activityShopActivityData = ShopNewUtility.GetActivityShopActivityData(param);
			if (activityShopActivityData == null)
			{
				return string.Empty;
			}
			return Function.GetTimeWithoutYearNoZero((int)activityShopActivityData.startTime, (int)activityShopActivityData.endTime);
		}

		// Token: 0x0600BB88 RID: 48008 RVA: 0x002B8868 File Offset: 0x002B6C68
		public static List<int> GetShopCostItemEqualItemIdListByOneItem(int costItemId)
		{
			EqualItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(costItemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return null;
			}
			return tableItem.EqualItemIDs.ToList<int>();
		}

		// Token: 0x0600BB89 RID: 48009 RVA: 0x002B88A0 File Offset: 0x002B6CA0
		public static List<int> GetShopCostItemEqualItemIdListByItemList(List<ShopNewCostItemDataModel> itemList)
		{
			List<int> list = new List<int>();
			if (itemList == null || itemList.Count <= 0)
			{
				return list;
			}
			for (int i = 0; i < itemList.Count; i++)
			{
				ShopNewCostItemDataModel shopNewCostItemDataModel = itemList[i];
				if (shopNewCostItemDataModel != null)
				{
					EqualItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<EqualItemTable>(shopNewCostItemDataModel.CostItemId, string.Empty, string.Empty);
					if (tableItem != null && tableItem.EqualItemIDs != null && tableItem.EqualItemIDs.Count > 0)
					{
						list.AddRange(tableItem.EqualItemIDs.ToList<int>());
					}
				}
			}
			if (list.Count > 1)
			{
				return list.Distinct<int>();
			}
			return list;
		}

		// Token: 0x0600BB8A RID: 48010 RVA: 0x002B8958 File Offset: 0x002B6D58
		public static List<ShopNewCostItemDataModel> GetShopItemOtherCostItemDataModelList(string otherCostItems)
		{
			string[] array = otherCostItems.Split(new char[]
			{
				','
			});
			if (array.Length <= 0)
			{
				return null;
			}
			List<ShopNewCostItemDataModel> list = new List<ShopNewCostItemDataModel>();
			foreach (string text in array)
			{
				if (!string.IsNullOrEmpty(text))
				{
					string[] array2 = text.Split(new char[]
					{
						'_'
					});
					if (array2.Length == 2)
					{
						int num = 0;
						int num2 = 0;
						if (int.TryParse(array2[0], out num) && int.TryParse(array2[1], out num2))
						{
							if (num > 0 && num2 > 0)
							{
								list.Add(new ShopNewCostItemDataModel
								{
									CostItemId = num,
									CostItemNumber = num2
								});
							}
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600BB8B RID: 48011 RVA: 0x002B8A34 File Offset: 0x002B6E34
		public static int ShopNewBuyItemNumberByOtherCostItem(int otherCostItemId, int otherCostItemNumber, int discountValue = 0)
		{
			int ownedItemCount = DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(otherCostItemId, true);
			otherCostItemNumber = ShopNewUtility.GetRealCostValue(otherCostItemNumber, discountValue);
			if (otherCostItemNumber <= 0)
			{
				return 0;
			}
			return ownedItemCount / otherCostItemNumber;
		}

		// Token: 0x0600BB8C RID: 48012 RVA: 0x002B8A63 File Offset: 0x002B6E63
		public static int GetRealCostValue(int costValue, int discountValue)
		{
			if (costValue <= 0)
			{
				return 0;
			}
			if (discountValue > 0 && discountValue < 100)
			{
				costValue = Mathf.CeilToInt((float)discountValue / 100f * (float)costValue);
			}
			return costValue;
		}

		// Token: 0x0600BB8D RID: 48013 RVA: 0x002B8A90 File Offset: 0x002B6E90
		public static string GetDiscountStr(int discountValue)
		{
			if (discountValue <= 0 || discountValue >= 100)
			{
				return string.Empty;
			}
			int num = discountValue % 10;
			int num2 = discountValue / 10;
			if (num == 0)
			{
				return TR.Value("shop_item_discount_normal_format", num2);
			}
			float num3 = (float)discountValue / 10f;
			return TR.Value("shop_item_discount_special_format", num3);
		}
	}
}
