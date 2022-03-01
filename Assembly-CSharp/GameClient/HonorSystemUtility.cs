using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200127E RID: 4734
	public static class HonorSystemUtility
	{
		// Token: 0x0600B5FE RID: 46590 RVA: 0x00290A69 File Offset: 0x0028EE69
		public static void OnOpenHonorSystemProtectCardFrame()
		{
			HonorSystemUtility.OnCloseHonorSystemProtectCardFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HonorSystemProtectCardFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B5FF RID: 46591 RVA: 0x00290A82 File Offset: 0x0028EE82
		public static void OnCloseHonorSystemProtectCardFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<HonorSystemProtectCardFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<HonorSystemProtectCardFrame>(null, false);
			}
		}

		// Token: 0x0600B600 RID: 46592 RVA: 0x00290AA0 File Offset: 0x0028EEA0
		public static void OnOpenHonorSystemPreviewFrame()
		{
			HonorSystemUtility.OnCloseHonorSystemPreviewFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HonorSystemPreviewFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B601 RID: 46593 RVA: 0x00290AB9 File Offset: 0x0028EEB9
		public static void OnCloseHonorSystemPreviewFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<HonorSystemPreviewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<HonorSystemPreviewFrame>(null, false);
			}
		}

		// Token: 0x0600B602 RID: 46594 RVA: 0x00290AD7 File Offset: 0x0028EED7
		public static void SendHonorSystemRedPointUpdateMessage()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnReceiveHonorSystemRedPointUpdateMessage, null, null, null, null);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RedPointChanged, ERedPoint.PackageMain, null, null, null);
		}

		// Token: 0x0600B603 RID: 46595 RVA: 0x00290B02 File Offset: 0x0028EF02
		public static bool IsShowHonorSystemRedPoint()
		{
			return DataManager<HonorSystemDataManager>.GetInstance().IsShowRedPointFlag;
		}

		// Token: 0x0600B604 RID: 46596 RVA: 0x00290B0E File Offset: 0x0028EF0E
		public static bool IsShowHonorSystem()
		{
			return HonorSystemUtility.IsHonorSystemUnLock() && !CommonUtility.IsInGameBattleScene();
		}

		// Token: 0x0600B605 RID: 46597 RVA: 0x00290B29 File Offset: 0x0028EF29
		public static bool IsHonorSystemUnLock()
		{
			return DataManager<PlayerBaseData>.GetInstance().Level >= 30;
		}

		// Token: 0x0600B606 RID: 46598 RVA: 0x00290B3F File Offset: 0x0028EF3F
		public static void OnOpenHonorSystemFrame()
		{
			HonorSystemUtility.OnCloseHonorSystemFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<HonorSystemFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B607 RID: 46599 RVA: 0x00290B58 File Offset: 0x0028EF58
		public static void OnCloseHonorSystemFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<HonorSystemFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<HonorSystemFrame>(null, false);
			}
		}

		// Token: 0x0600B608 RID: 46600 RVA: 0x00290B78 File Offset: 0x0028EF78
		public static PlayerHistoryHonorInfo CreatePlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE dateType)
		{
			return new PlayerHistoryHonorInfo
			{
				HonorDateType = dateType,
				HonorTotalNumber = 0U
			};
		}

		// Token: 0x0600B609 RID: 46601 RVA: 0x00290B9C File Offset: 0x0028EF9C
		public static void AddPvpNumberStatisticsInPlayerHistoryHonorInfo(PlayerHistoryHonorInfo playerHistoryHonorInfo, HonorPlayerTable honorPlayerTable)
		{
			if (playerHistoryHonorInfo == null)
			{
				return;
			}
			if (honorPlayerTable == null)
			{
				return;
			}
			if (playerHistoryHonorInfo.PvpNumberStatisticsList == null)
			{
				playerHistoryHonorInfo.PvpNumberStatisticsList = new List<PvpNumberStatistics>();
			}
			PvpNumberStatistics pvpNumberStatistics = HonorSystemUtility.CreatePvpNumberStatisticsByHonorPlayerTable(honorPlayerTable);
			if (pvpNumberStatistics != null)
			{
				playerHistoryHonorInfo.PvpNumberStatisticsList.Add(pvpNumberStatistics);
			}
		}

		// Token: 0x0600B60A RID: 46602 RVA: 0x00290BE8 File Offset: 0x0028EFE8
		public static void UpdatePlayerNewFlagInHistoryInfo(PlayerHistoryHonorInfo playerHistoryHonorInfo, HistoryHonorInfo historyHonorInfo)
		{
			if (playerHistoryHonorInfo == null)
			{
				return;
			}
			if (playerHistoryHonorInfo.PvpNumberStatisticsList == null || playerHistoryHonorInfo.PvpNumberStatisticsList.Count <= 0)
			{
				return;
			}
			for (int i = 0; i < playerHistoryHonorInfo.PvpNumberStatisticsList.Count; i++)
			{
				PvpNumberStatistics pvpNumberStatistics = playerHistoryHonorInfo.PvpNumberStatisticsList[i];
				if (pvpNumberStatistics != null)
				{
					pvpNumberStatistics.IsNewFlag = false;
					if (pvpNumberStatistics.PvpCount == 1U)
					{
						if (historyHonorInfo == null || historyHonorInfo.pvpStatisticsList == null || historyHonorInfo.pvpStatisticsList.Length <= 0)
						{
							pvpNumberStatistics.IsNewFlag = true;
						}
						else
						{
							bool flag = false;
							int num = 0;
							for (int j = 0; j < historyHonorInfo.pvpStatisticsList.Length; j++)
							{
								PvpStatistics pvpStatistics = historyHonorInfo.pvpStatisticsList[j];
								if (pvpStatistics != null && pvpStatistics.pvpType == pvpNumberStatistics.PvpType)
								{
									flag = true;
									num = (int)pvpStatistics.pvpCnt;
									break;
								}
							}
							if (!flag || num == 0)
							{
								pvpNumberStatistics.IsNewFlag = true;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600B60B RID: 46603 RVA: 0x00290CF4 File Offset: 0x0028F0F4
		public static void UpdatePlayerHistoryInfo(PlayerHistoryHonorInfo playerHistoryHonorInfo, HistoryHonorInfo historyHonorInfo)
		{
			if (playerHistoryHonorInfo == null || historyHonorInfo == null)
			{
				return;
			}
			if (playerHistoryHonorInfo.HonorDateType != (HONOR_DATE_TYPE)historyHonorInfo.dateType)
			{
				return;
			}
			playerHistoryHonorInfo.HonorTotalNumber = historyHonorInfo.totalHonor;
			if (playerHistoryHonorInfo.PvpNumberStatisticsList == null || playerHistoryHonorInfo.PvpNumberStatisticsList.Count <= 0)
			{
				return;
			}
			if (historyHonorInfo.pvpStatisticsList == null || historyHonorInfo.pvpStatisticsList.Length <= 0)
			{
				return;
			}
			for (int i = 0; i < historyHonorInfo.pvpStatisticsList.Length; i++)
			{
				PvpStatistics pvpStatistics = historyHonorInfo.pvpStatisticsList[i];
				if (pvpStatistics != null)
				{
					for (int j = 0; j < playerHistoryHonorInfo.PvpNumberStatisticsList.Count; j++)
					{
						PvpNumberStatistics pvpNumberStatistics = playerHistoryHonorInfo.PvpNumberStatisticsList[j];
						if (pvpNumberStatistics != null)
						{
							if (pvpNumberStatistics.PvpType == pvpStatistics.pvpType)
							{
								pvpNumberStatistics.PvpCount = pvpStatistics.pvpCnt;
								break;
							}
						}
					}
				}
			}
		}

		// Token: 0x0600B60C RID: 46604 RVA: 0x00290DEC File Offset: 0x0028F1EC
		public static bool IsPvpShowInWeekDay(int weekDay, HonorPlayerTable honorPlayerTable)
		{
			if (weekDay <= 0 || weekDay > 7)
			{
				return false;
			}
			if (honorPlayerTable == null)
			{
				return false;
			}
			List<int> numberListBySplitString = CommonUtility.GetNumberListBySplitString(honorPlayerTable.OpenWeekDay);
			if (numberListBySplitString == null || numberListBySplitString.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < numberListBySplitString.Count; i++)
			{
				if (weekDay == numberListBySplitString[i])
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B60D RID: 46605 RVA: 0x00290E58 File Offset: 0x0028F258
		private static PvpNumberStatistics CreatePvpNumberStatisticsByHonorPlayerTable(HonorPlayerTable honorPlayerTable)
		{
			if (honorPlayerTable == null)
			{
				return null;
			}
			return new PvpNumberStatistics
			{
				PvpType = (uint)honorPlayerTable.ID,
				PvpCount = 0U,
				PvpName = honorPlayerTable.name,
				PvpIconPath = honorPlayerTable.HornorPlayIcon,
				PvpSort = honorPlayerTable.Sort
			};
		}

		// Token: 0x0600B60E RID: 46606 RVA: 0x00290EAC File Offset: 0x0028F2AC
		public static HonorLevelTable GetHonorLevelTableByLevel(int honorLevel)
		{
			return Singleton<TableManager>.GetInstance().GetTableItem<HonorLevelTable>(honorLevel, string.Empty, string.Empty);
		}

		// Token: 0x0600B60F RID: 46607 RVA: 0x00290ED0 File Offset: 0x0028F2D0
		public static List<PvpNumberStatistics> GetPvpNumberStaticsListByDateType(HONOR_DATE_TYPE honorDateType)
		{
			List<PlayerHistoryHonorInfo> playerHistoryHonorInfoList = DataManager<HonorSystemDataManager>.GetInstance().PlayerHistoryHonorInfoList;
			if (playerHistoryHonorInfoList == null || playerHistoryHonorInfoList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < playerHistoryHonorInfoList.Count; i++)
			{
				PlayerHistoryHonorInfo playerHistoryHonorInfo = playerHistoryHonorInfoList[i];
				if (playerHistoryHonorInfo != null)
				{
					if (playerHistoryHonorInfo.HonorDateType == honorDateType)
					{
						return playerHistoryHonorInfo.PvpNumberStatisticsList;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B610 RID: 46608 RVA: 0x00290F3C File Offset: 0x0028F33C
		public static PlayerHistoryHonorInfo GetPlayerHistoryHonorInfoByDateType(HONOR_DATE_TYPE honorDateType)
		{
			List<PlayerHistoryHonorInfo> playerHistoryHonorInfoList = DataManager<HonorSystemDataManager>.GetInstance().PlayerHistoryHonorInfoList;
			if (playerHistoryHonorInfoList == null || playerHistoryHonorInfoList.Count <= 0)
			{
				return null;
			}
			for (int i = 0; i < playerHistoryHonorInfoList.Count; i++)
			{
				PlayerHistoryHonorInfo playerHistoryHonorInfo = playerHistoryHonorInfoList[i];
				if (playerHistoryHonorInfo != null)
				{
					if (playerHistoryHonorInfo.HonorDateType == honorDateType)
					{
						return playerHistoryHonorInfo;
					}
				}
			}
			return null;
		}

		// Token: 0x0600B611 RID: 46609 RVA: 0x00290FA4 File Offset: 0x0028F3A4
		private static PreviewLevelItemDataModel CreatePreviewLevelItemDataModel(HonorLevelTable honorLevelTable)
		{
			PreviewLevelItemDataModel previewLevelItemDataModel = new PreviewLevelItemDataModel();
			if (honorLevelTable.ID == 1000)
			{
				previewLevelItemDataModel.HonorSystemLevel = 0;
			}
			else
			{
				previewLevelItemDataModel.HonorSystemLevel = honorLevelTable.ID;
			}
			previewLevelItemDataModel.HonorLevelName = honorLevelTable.name;
			previewLevelItemDataModel.HonorSystemTotalNeedExpValue = honorLevelTable.NeedExp;
			previewLevelItemDataModel.HonorLevelFlagPath = honorLevelTable.TitleFlag;
			previewLevelItemDataModel.TitleId = honorLevelTable.Title;
			previewLevelItemDataModel.ShopDiscountList.Clear();
			for (int i = 0; i < honorLevelTable.ShopDiscount.Count; i++)
			{
				string text = honorLevelTable.ShopDiscount[i];
				if (!string.IsNullOrEmpty(text))
				{
					previewLevelItemDataModel.ShopDiscountList.Add(text);
				}
			}
			previewLevelItemDataModel.UnLockShopItemList.Clear();
			if (!string.IsNullOrEmpty(honorLevelTable.UnlockItem))
			{
				List<int> numberListBySplitString = CommonUtility.GetNumberListBySplitString(honorLevelTable.UnlockItem);
				if (numberListBySplitString != null && numberListBySplitString.Count > 0)
				{
					numberListBySplitString.Sort();
					previewLevelItemDataModel.UnLockShopItemList.AddRange(numberListBySplitString.ToList<int>());
				}
			}
			return previewLevelItemDataModel;
		}

		// Token: 0x0600B612 RID: 46610 RVA: 0x002910AC File Offset: 0x0028F4AC
		public static List<PreviewLevelItemDataModel> GetPreviewLevelItemDataModelList()
		{
			List<PreviewLevelItemDataModel> list = new List<PreviewLevelItemDataModel>();
			HonorLevelTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<HonorLevelTable>(1000, string.Empty, string.Empty);
			if (tableItem != null)
			{
				PreviewLevelItemDataModel item = HonorSystemUtility.CreatePreviewLevelItemDataModel(tableItem);
				list.Add(item);
			}
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<HonorLevelTable>();
			if (table != null)
			{
				foreach (KeyValuePair<int, object> keyValuePair in table)
				{
					HonorLevelTable honorLevelTable = keyValuePair.Value as HonorLevelTable;
					if (honorLevelTable != null)
					{
						if (honorLevelTable.ID != 1000)
						{
							PreviewLevelItemDataModel item2 = HonorSystemUtility.CreatePreviewLevelItemDataModel(honorLevelTable);
							list.Add(item2);
						}
					}
				}
			}
			if (list.Count > 1)
			{
				list.Sort((PreviewLevelItemDataModel x, PreviewLevelItemDataModel y) => x.HonorSystemLevel.CompareTo(y.HonorSystemLevel));
			}
			int count = list.Count;
			for (int i = 1; i < count; i++)
			{
				PreviewLevelItemDataModel previewLevelItemDataModel = list[i];
				PreviewLevelItemDataModel previewLevelItemDataModel2 = list[i - 1];
				if (previewLevelItemDataModel != null && previewLevelItemDataModel2 != null)
				{
					previewLevelItemDataModel.HonorSystemNeedExpValue = previewLevelItemDataModel.HonorSystemTotalNeedExpValue - previewLevelItemDataModel2.HonorSystemTotalNeedExpValue;
					if (previewLevelItemDataModel2.UnLockShopItemList != null && previewLevelItemDataModel2.UnLockShopItemList.Count > 0)
					{
						previewLevelItemDataModel.UnLockShopItemList.AddRange(previewLevelItemDataModel2.UnLockShopItemList.ToList<int>());
					}
				}
			}
			return list;
		}

		// Token: 0x0600B613 RID: 46611 RVA: 0x00291225 File Offset: 0x0028F625
		public static ItemData GetProtectCardItemData(int itemTableId)
		{
			return null;
		}

		// Token: 0x0600B614 RID: 46612 RVA: 0x00291228 File Offset: 0x0028F628
		public static string GetTitleNameByTitleId(int titleId)
		{
			if (titleId <= 0)
			{
				return string.Empty;
			}
			NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>(titleId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			if (tableItem.Type == 1)
			{
				return tableItem.name;
			}
			string name = tableItem.name;
			string playerProfessionName = CommonUtility.GetPlayerProfessionName();
			return string.Format(name, playerProfessionName);
		}

		// Token: 0x0600B615 RID: 46613 RVA: 0x00291290 File Offset: 0x0028F690
		public static string GetTitleIconPathByTitleId(int titleId)
		{
			NewTitleTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<NewTitleTable>(titleId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return string.Empty;
			}
			return tableItem.path;
		}

		// Token: 0x0600B616 RID: 46614 RVA: 0x002912C8 File Offset: 0x0028F6C8
		public static string GetShopDiscountValue(List<string> shopDiscountList)
		{
			if (shopDiscountList == null || shopDiscountList.Count <= 0)
			{
				return string.Empty;
			}
			string text = string.Empty;
			for (int i = 0; i < shopDiscountList.Count; i++)
			{
				string text2 = shopDiscountList[i];
				if (text2 != null)
				{
					List<int> numberListBySplitStringWithLine = CommonUtility.GetNumberListBySplitStringWithLine(text2);
					if (numberListBySplitStringWithLine != null && numberListBySplitStringWithLine.Count == 2)
					{
						int num = numberListBySplitStringWithLine[0];
						int num2 = numberListBySplitStringWithLine[1];
						if (num > 0)
						{
							if (num2 > 0 && num2 < 100)
							{
								ShopTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ShopTable>(num, string.Empty, string.Empty);
								if (tableItem != null)
								{
									if (i != 0)
									{
										text += TR.Value("Common_Format_Split_Flag");
									}
									string shopName = tableItem.ShopName;
									string discountStr = ShopNewUtility.GetDiscountStr(num2);
									string str = TR.Value("Honor_System_Shop_Item_Discount_Value", shopName, discountStr);
									text += str;
								}
							}
						}
					}
				}
			}
			return text;
		}

		// Token: 0x0600B617 RID: 46615 RVA: 0x002913D8 File Offset: 0x0028F7D8
		public static string GetThisWeekHonorExpStrInPk()
		{
			if (DataManager<HonorSystemDataManager>.GetInstance().PkHonorExpMaxValue == 0)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(648, string.Empty, string.Empty);
				if (tableItem != null)
				{
					DataManager<HonorSystemDataManager>.GetInstance().PkHonorExpMaxValue = tableItem.Value;
				}
			}
			int pkHonorExpMaxValue = DataManager<HonorSystemDataManager>.GetInstance().PkHonorExpMaxValue;
			int count = DataManager<CountDataManager>.GetInstance().GetCount(DataManager<HonorSystemDataManager>.GetInstance().PkHonorExpCounterStr);
			return TR.Value("Common_Two_Number_Format_One", count, pkHonorExpMaxValue);
		}

		// Token: 0x0600B618 RID: 46616 RVA: 0x0029145C File Offset: 0x0028F85C
		public static string GetThisWeekHonorExpStrInChiJi()
		{
			if (DataManager<HonorSystemDataManager>.GetInstance().ChiJiHonorExpMaxValue == 0)
			{
				SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(659, string.Empty, string.Empty);
				if (tableItem != null)
				{
					DataManager<HonorSystemDataManager>.GetInstance().ChiJiHonorExpMaxValue = tableItem.Value;
				}
			}
			int chiJiHonorExpMaxValue = DataManager<HonorSystemDataManager>.GetInstance().ChiJiHonorExpMaxValue;
			int count = DataManager<CountDataManager>.GetInstance().GetCount(DataManager<HonorSystemDataManager>.GetInstance().ChiJiHonorExpCounterStr);
			return TR.Value("Common_Two_Number_Format_One", count, chiJiHonorExpMaxValue);
		}
	}
}
