using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x020011F0 RID: 4592
	public static class AuctionNewUtility
	{
		// Token: 0x0600B0D7 RID: 45271 RVA: 0x0026FEE7 File Offset: 0x0026E2E7
		public static void OnCloseAuctionNewPositionFilterFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewPositionFilterFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewPositionFilterFrame>(null, false);
			}
		}

		// Token: 0x0600B0D8 RID: 45272 RVA: 0x0026FF05 File Offset: 0x0026E305
		public static void OnOpenAuctionNewPositionFilterFrame(int filterType)
		{
			AuctionNewUtility.OnCloseAuctionNewPositionFilterFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewPositionFilterFrame>(FrameLayer.Middle, filterType, string.Empty);
		}

		// Token: 0x0600B0D9 RID: 45273 RVA: 0x0026FF23 File Offset: 0x0026E323
		public static void OnCloseAuctionNewMagicCardStrengthLevelFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewMagicCardStrengthenLevelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewMagicCardStrengthenLevelFrame>(null, false);
			}
		}

		// Token: 0x0600B0DA RID: 45274 RVA: 0x0026FF44 File Offset: 0x0026E344
		public static void OnOpenAuctionNewMagicCardStrengthLevelFrame(uint itemId, int defaultLevel)
		{
			AuctionNewUtility.OnCloseAuctionNewMagicCardStrengthLevelFrame();
			AuctionNewMagicCardDataModel userData = new AuctionNewMagicCardDataModel
			{
				ItemId = itemId,
				DefaultLevel = defaultLevel
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewMagicCardStrengthenLevelFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B0DB RID: 45275 RVA: 0x0026FF80 File Offset: 0x0026E380
		public static bool IsMagicCardItem(uint itemId)
		{
			if (itemId <= 0U)
			{
				return false;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)itemId, string.Empty, string.Empty);
			return tableItem != null && (tableItem.Type == ItemTable.eType.EXPENDABLE && tableItem.SubType == ItemTable.eSubType.EnchantmentsCard);
		}

		// Token: 0x0600B0DC RID: 45276 RVA: 0x0026FFD0 File Offset: 0x0026E3D0
		public static string GetMainTabNameByTabType(AuctionNewMainTabType mainTabType)
		{
			if (mainTabType == AuctionNewMainTabType.AuctionBuyType)
			{
				return TR.Value("auction_new_buy_label");
			}
			if (mainTabType == AuctionNewMainTabType.AuctionNoticeType)
			{
				return TR.Value("auction_new_notice_item_label");
			}
			if (mainTabType != AuctionNewMainTabType.AuctionSellType)
			{
				return TR.Value("auction_new_title");
			}
			return TR.Value("auction_new_sell_label");
		}

		// Token: 0x0600B0DD RID: 45277 RVA: 0x00270024 File Offset: 0x0026E424
		public static bool IsEquipItems(ItemData data)
		{
			AuctionMainItemType baseTypeByTableID = DataManager<AuctionDataManager>.GetInstance().GetBaseTypeByTableID(data.TableID);
			if (baseTypeByTableID == AuctionMainItemType.AMIT_WEAPON || baseTypeByTableID == AuctionMainItemType.AMIT_ARMOR || baseTypeByTableID == AuctionMainItemType.AMIT_JEWELRY)
			{
				return true;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(data.TableID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.SubType == ItemTable.eSubType.ST_ASSIST_EQUIP)
				{
					return true;
				}
				if (tableItem.SubType == ItemTable.eSubType.ST_MAGICSTONE_EQUIP)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B0DE RID: 45278 RVA: 0x0027009C File Offset: 0x0026E49C
		public static void OpenAuctionNewFrame(ItemData itemData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewFrame>(null, false);
			}
			bool flag = AuctionNewUtility.IsAuctionNewItemInCoolTime(itemData);
			if (flag)
			{
				AuctionNewUtility.ShowItemInCoolTimeFloatingEffect(itemData.AuctionCoolTimeStamp, DataManager<TimeManager>.GetInstance().GetServerTime());
				return;
			}
			bool flag2 = ItemDataUtility.IsItemTradeLimitBuyNumber(itemData);
			int itemTradeLeftTime = ItemDataUtility.GetItemTradeLeftTime(itemData);
			if (!flag2)
			{
				AuctionNewUtility.OpenAuctionNewFrameAction(itemData);
				return;
			}
			if (itemTradeLeftTime <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_item__trade_number_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			string contentStr = string.Format(TR.Value("auction_new_item_on_shelf_with_trade_number"), itemTradeLeftTime);
			AuctionNewUtility.OnShowItemTradeLimitFrame(contentStr, delegate
			{
				AuctionNewUtility.OpenAuctionNewFrameAction(itemData);
			});
		}

		// Token: 0x0600B0DF RID: 45279 RVA: 0x0027016C File Offset: 0x0026E56C
		private static void OpenAuctionNewFrameAction(ItemData itemData)
		{
			if (itemData == null)
			{
				return;
			}
			AuctionNewUserData auctionNewUserData = new AuctionNewUserData();
			auctionNewUserData.MainTabType = AuctionNewMainTabType.AuctionSellType;
			auctionNewUserData.ItemLinkId = itemData.GUID;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewFrame>(FrameLayer.Middle, auctionNewUserData, string.Empty);
			DataManager<ItemTipManager>.GetInstance().CloseAll();
		}

		// Token: 0x0600B0E0 RID: 45280 RVA: 0x002701B8 File Offset: 0x0026E5B8
		public static string GetQualityColorString(string textStr, ItemTable.eColor qualityColor)
		{
			ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(qualityColor, false, false);
			if (qualityInfo != null)
			{
				return TR.Value("common_color_text", qualityInfo.ColStr, textStr);
			}
			return string.Empty;
		}

		// Token: 0x0600B0E1 RID: 45281 RVA: 0x002701EC File Offset: 0x0026E5EC
		public static string GetCountDownTimeStr(uint endTime, uint curTime)
		{
			uint num = 0U;
			uint num2 = 0U;
			if (endTime <= curTime)
			{
				return string.Format("{0:D2}:{1:D2}", num, num2);
			}
			uint num3 = endTime - curTime;
			num = num3 / 3600U;
			num2 = (num3 - 3600U * num) / 60U;
			return string.Format("{0:D2}:{1:D2}", num, num2);
		}

		// Token: 0x0600B0E2 RID: 45282 RVA: 0x0027024C File Offset: 0x0026E64C
		public static bool IsTreasureItem(int itemId)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			return tableItem != null && tableItem.IsTreas == 1;
		}

		// Token: 0x0600B0E3 RID: 45283 RVA: 0x00270284 File Offset: 0x0026E684
		public static bool IsAuctionNewTreasureRushBuy(byte isTreasure, uint publicEndTime)
		{
			return isTreasure == 1 && DataManager<TimeManager>.GetInstance().GetServerTime() >= publicEndTime && (ulong)DataManager<TimeManager>.GetInstance().GetServerTime() <= (ulong)publicEndTime + (ulong)((long)DataManager<AuctionNewDataManager>.GetInstance().TreasureItemRushBuyTimeInterval);
		}

		// Token: 0x0600B0E4 RID: 45284 RVA: 0x002702DC File Offset: 0x0026E6DC
		public static bool IsAuctionNewItemInCoolTime(ItemData itemData)
		{
			if (itemData == null)
			{
				return false;
			}
			if (itemData.AuctionCoolTimeStamp <= 0U)
			{
				return false;
			}
			uint serverTime = DataManager<TimeManager>.GetInstance().GetServerTime();
			return itemData.AuctionCoolTimeStamp > serverTime;
		}

		// Token: 0x0600B0E5 RID: 45285 RVA: 0x0027031C File Offset: 0x0026E71C
		public static void ShowItemInCoolTimeFloatingEffect(uint endTimeStamp, uint curServerTime)
		{
			string coolDownTimeByDayHour = CountDownTimeUtility.GetCoolDownTimeByDayHour(endTimeStamp, curServerTime);
			string msgContent = string.Format(TR.Value("auction_new_item_trade_in_cd_time_"), coolDownTimeByDayHour);
			SystemNotifyManager.SysNotifyFloatingEffect(msgContent, CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x0600B0E6 RID: 45286 RVA: 0x0027034A File Offset: 0x0026E74A
		public static bool IsAuctionNewSameState(AuctionNewMainTabType mainTabType, AuctionGoodState auctionGoodState)
		{
			return (auctionGoodState == AuctionGoodState.AGS_PUBLIC && mainTabType == AuctionNewMainTabType.AuctionNoticeType) || (auctionGoodState == AuctionGoodState.AGS_ONSALE && mainTabType == AuctionNewMainTabType.AuctionBuyType);
		}

		// Token: 0x0600B0E7 RID: 45287 RVA: 0x0027036D File Offset: 0x0026E76D
		public static AuctionGoodState ConvertToAuctionGoodState(AuctionNewMainTabType mainTabType)
		{
			if (mainTabType == AuctionNewMainTabType.AuctionBuyType)
			{
				return AuctionGoodState.AGS_ONSALE;
			}
			return AuctionGoodState.AGS_PUBLIC;
		}

		// Token: 0x0600B0E8 RID: 45288 RVA: 0x0027037C File Offset: 0x0026E77C
		public static AuctionNewUserData ConvertToAuctionNewUserData(OutComeAuctionData outComeAuctionData)
		{
			if (outComeAuctionData == null)
			{
				return null;
			}
			AuctionNewUserData auctionNewUserData = new AuctionNewUserData();
			if (outComeAuctionData.eLabelType == AuctionPage.MyAuctionPage)
			{
				auctionNewUserData.MainTabType = AuctionNewMainTabType.AuctionSellType;
			}
			else
			{
				auctionNewUserData.MainTabType = AuctionNewMainTabType.AuctionBuyType;
			}
			switch (outComeAuctionData.CurBaseType)
			{
			case AuctionMainItemType.AMIT_WEAPON:
				auctionNewUserData.FirstLayerTabId = 1;
				break;
			case AuctionMainItemType.AMIT_ARMOR:
				auctionNewUserData.FirstLayerTabId = 2;
				break;
			case AuctionMainItemType.AMIT_JEWELRY:
				auctionNewUserData.FirstLayerTabId = 3;
				break;
			case AuctionMainItemType.AMIT_COST:
				auctionNewUserData.FirstLayerTabId = 4;
				break;
			case AuctionMainItemType.AMIT_MATERIAL:
				auctionNewUserData.FirstLayerTabId = 5;
				break;
			default:
				auctionNewUserData.FirstLayerTabId = 1;
				break;
			}
			auctionNewUserData.ItemLinkId = outComeAuctionData.uiLinkId;
			return auctionNewUserData;
		}

		// Token: 0x0600B0E9 RID: 45289 RVA: 0x00270433 File Offset: 0x0026E833
		public static string ConvertDescLine(string descStr)
		{
			if (string.IsNullOrEmpty(descStr))
			{
				return descStr;
			}
			return descStr.Replace("\\n", "\n");
		}

		// Token: 0x0600B0EA RID: 45290 RVA: 0x00270452 File Offset: 0x0026E852
		public static string ConvertDescBlank(string descStr)
		{
			if (string.IsNullOrEmpty(descStr))
			{
				return descStr;
			}
			return descStr.Replace("\\u3000", "\u3000");
		}

		// Token: 0x0600B0EB RID: 45291 RVA: 0x00270474 File Offset: 0x0026E874
		public static void OpenAuctionNewOnShelfFrame(ulong itemGuid, bool isTreasure, int maxShelfNumber, int selfOnShelfNumber)
		{
			AuctionNewOnShelfItemData userData = new AuctionNewOnShelfItemData
			{
				PackageItemGuid = itemGuid,
				MaxShelfNum = maxShelfNumber,
				SelfOnShelfItemNum = selfOnShelfNumber,
				IsTreasure = isTreasure
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewOnShelfFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B0EC RID: 45292 RVA: 0x002704B8 File Offset: 0x0026E8B8
		public static void OpenAuctionNewOnShelfFrameByTimeOverItem(AuctionBaseInfo auctionBaseInfo)
		{
			AuctionNewUtility.CloseAuctionNewOnShelfFrame();
			AuctionNewOnShelfItemData userData = new AuctionNewOnShelfItemData
			{
				PackageItemGuid = auctionBaseInfo.guid,
				IsTreasure = (auctionBaseInfo.isTreas == 1),
				ItemAuctionBaseInfo = auctionBaseInfo,
				IsTimeOverItem = true
			};
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewOnShelfFrame>(FrameLayer.Middle, userData, string.Empty);
		}

		// Token: 0x0600B0ED RID: 45293 RVA: 0x00270517 File Offset: 0x0026E917
		public static void CloseAuctionNewOnShelfFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewOnShelfFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewOnShelfFrame>(null, false);
			}
		}

		// Token: 0x0600B0EE RID: 45294 RVA: 0x00270538 File Offset: 0x0026E938
		public static int[] GetOnShelfItemPriceArray(int averagePrice, int minPrice, int maxPrice, int maxPriceRate = 0)
		{
			if (averagePrice == 0)
			{
				Logger.LogErrorFormat("AveragePrice is 0", new object[0]);
				return new int[1];
			}
			List<int> list = new List<int>
			{
				averagePrice,
				minPrice,
				maxPrice
			};
			int num = 110;
			int i = AuctionNewUtility.GetTempPrice(averagePrice, num);
			int num2 = maxPriceRate * 8;
			while (i < maxPrice)
			{
				list.Add(i);
				if (num2 >= 100 && num > num2)
				{
					break;
				}
				num += 10;
				i = AuctionNewUtility.GetTempPrice(averagePrice, num);
			}
			num = 90;
			for (i = AuctionNewUtility.GetTempPrice(averagePrice, num); i > minPrice; i = AuctionNewUtility.GetTempPrice(averagePrice, num))
			{
				list.Add(i);
				if (num <= 1)
				{
					break;
				}
				if (num > 10)
				{
					num -= 10;
				}
				else if (num > 2)
				{
					num -= 2;
				}
				else
				{
					num--;
				}
				if (num <= 1)
				{
					num = 1;
				}
			}
			list.Sort();
			List<int> list2 = list.Distinct<int>();
			return list2.ToArray();
		}

		// Token: 0x0600B0EF RID: 45295 RVA: 0x0027063C File Offset: 0x0026EA3C
		public static int GetPriceIndexInPriceArray(int[] priceArray, int price)
		{
			for (int i = 0; i < priceArray.Length; i++)
			{
				if (priceArray[i] == price)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600B0F0 RID: 45296 RVA: 0x0027066C File Offset: 0x0026EA6C
		public static bool IsPriceInPriceArray(int[] priceArray, int price)
		{
			if (priceArray == null || priceArray.Length <= 0)
			{
				return false;
			}
			for (int i = 0; i < priceArray.Length; i++)
			{
				if (priceArray[i] == price)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B0F1 RID: 45297 RVA: 0x002706AC File Offset: 0x0026EAAC
		public static int GetNextIndexInPriceArray(int[] priceArray, int price)
		{
			for (int i = 0; i < priceArray.Length; i++)
			{
				if (priceArray[i] > price)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600B0F2 RID: 45298 RVA: 0x002706DC File Offset: 0x0026EADC
		public static int GetPreIndexInPriceArray(int[] priceArray, int price)
		{
			for (int i = priceArray.Length - 1; i >= 0; i--)
			{
				if (priceArray[i] < price)
				{
					return i;
				}
			}
			return 0;
		}

		// Token: 0x0600B0F3 RID: 45299 RVA: 0x0027070C File Offset: 0x0026EB0C
		public static int GetTempPrice(int averagePrice, int priceRate)
		{
			long num = (long)priceRate * (long)averagePrice;
			num = (long)((float)num / 100f);
			return (int)num;
		}

		// Token: 0x0600B0F4 RID: 45300 RVA: 0x0027072C File Offset: 0x0026EB2C
		public static List<AuctionNewMenuTabDataModel> GetAuctionNewChildrenLayerTabDataModelList(AuctionNewMenuTabDataModel parentLayerMenuTabDataModel, AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.AuctionBuyType)
		{
			if (parentLayerMenuTabDataModel == null || parentLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				return null;
			}
			if (parentLayerMenuTabDataModel.AuctionNewFrameTable.LayerRelation.Count == 0 || (parentLayerMenuTabDataModel.AuctionNewFrameTable.LayerRelation.Count == 1 && parentLayerMenuTabDataModel.AuctionNewFrameTable.LayerRelation[0] == 0))
			{
				return null;
			}
			List<AuctionNewMenuTabDataModel> list = new List<AuctionNewMenuTabDataModel>();
			for (int i = 0; i < parentLayerMenuTabDataModel.AuctionNewFrameTable.LayerRelation.Count; i++)
			{
				int id = parentLayerMenuTabDataModel.AuctionNewFrameTable.LayerRelation[i];
				AuctionNewFrameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionNewFrameTable>(id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					if (auctionNewMainTabType != AuctionNewMainTabType.AuctionNoticeType || DataManager<AuctionNewDataManager>.GetInstance().IsNoticeLayerIdValid(tableItem.ID))
					{
						AuctionNewMenuTabDataModel item = new AuctionNewMenuTabDataModel(tableItem.ID, tableItem.Layer, tableItem.Sort, tableItem);
						list.Add(item);
					}
				}
			}
			if (list.Count > 0)
			{
				list.Sort((AuctionNewMenuTabDataModel x, AuctionNewMenuTabDataModel y) => x.Sort.CompareTo(y.Sort));
			}
			return list;
		}

		// Token: 0x0600B0F5 RID: 45301 RVA: 0x00270858 File Offset: 0x0026EC58
		public static List<AuctionNewMenuTabDataModel> GetAuctionNewFirstLayerTabDataModelList(AuctionNewMainTabType auctionNewMainTabType = AuctionNewMainTabType.AuctionBuyType)
		{
			List<AuctionNewMenuTabDataModel> list = new List<AuctionNewMenuTabDataModel>();
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AuctionNewFrameTable>();
			if (table == null)
			{
				return null;
			}
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AuctionNewFrameTable auctionNewFrameTable = keyValuePair.Value as AuctionNewFrameTable;
				if (auctionNewFrameTable != null && auctionNewFrameTable.Layer == 1 && auctionNewFrameTable.IsShow == 1)
				{
					if (auctionNewMainTabType != AuctionNewMainTabType.AuctionNoticeType || auctionNewFrameTable.MenuType == AuctionNewFrameTable.eMenuType.Auction_Menu_Notice || DataManager<AuctionNewDataManager>.GetInstance().IsNoticeLayerIdValid(auctionNewFrameTable.ID))
					{
						if (auctionNewFrameTable.MenuType != AuctionNewFrameTable.eMenuType.Auction_Menu_Notice || AuctionNewUtility.IsAuctionTreasureItemOpen())
						{
							AuctionNewMenuTabDataModel item = new AuctionNewMenuTabDataModel(auctionNewFrameTable.ID, auctionNewFrameTable.Layer, auctionNewFrameTable.Sort, auctionNewFrameTable);
							list.Add(item);
						}
					}
				}
			}
			if (list.Count > 0)
			{
				list.Sort((AuctionNewMenuTabDataModel x, AuctionNewMenuTabDataModel y) => x.Sort.CompareTo(y.Sort));
			}
			return list;
		}

		// Token: 0x0600B0F6 RID: 45302 RVA: 0x00270964 File Offset: 0x0026ED64
		public static void ChatWithOnShelfItemOwner(ulong itemOwnerGuid)
		{
			FunctionUnLock tableItem = Singleton<TableManager>.GetInstance().GetTableItem<FunctionUnLock>(31, string.Empty, string.Empty);
			if (tableItem == null)
			{
				Logger.LogErrorFormat("ChatWithItemOwner and FunctionUnlockData is null and id is {0}", new object[]
				{
					FunctionUnLock.eFuncType.Friend
				});
				return;
			}
			if ((int)DataManager<PlayerBaseData>.GetInstance().Level < tableItem.FinishLevel)
			{
				SystemNotifyManager.SysNotifyTextAnimation(TR.Value("relation_friend_chat_need_lv", tableItem.FinishLevel), CommonTipsDesc.eShowMode.SI_UNIQUE);
				return;
			}
			if (itemOwnerGuid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("auction_new_disable_chat_with_self"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			RelationData relationByRoleID = DataManager<RelationDataManager>.GetInstance().GetRelationByRoleID(itemOwnerGuid);
			if (relationByRoleID != null)
			{
				AuctionNewUtility.OpenChatFrame(relationByRoleID);
				return;
			}
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOnShelfItemOwnerInfo(itemOwnerGuid);
		}

		// Token: 0x0600B0F7 RID: 45303 RVA: 0x00270A20 File Offset: 0x0026EE20
		public static void OpenChatFrame(RelationData relationData)
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<RelationFrameNew>(null))
			{
				DataManager<RelationDataManager>.GetInstance().OnAddPriChatList(relationData, false);
				RelationFrameData relationFrameData = new RelationFrameData();
				relationFrameData.eCurrentRelationData = relationData;
				UIEventSystem.GetInstance().SendUIEvent(EUIEventID.OnTAPStartTalk, relationFrameData, null, null, null);
			}
			else
			{
				DataManager<ChatManager>.GetInstance().OpenPrivateChatFrame(relationData);
			}
		}

		// Token: 0x0600B0F8 RID: 45304 RVA: 0x00270A7C File Offset: 0x0026EE7C
		public static void SortOnSaleItemList(List<AuctionItemBaseInfo> auctionBaseInfoList)
		{
			if (auctionBaseInfoList == null || auctionBaseInfoList.Count <= 1)
			{
				return;
			}
			List<ItemTable> list = new List<ItemTable>();
			for (int i = 0; i < auctionBaseInfoList.Count; i++)
			{
				if (auctionBaseInfoList[i] != null)
				{
					uint itemTypeId = auctionBaseInfoList[i].itemTypeId;
					ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)itemTypeId, string.Empty, string.Empty);
					if (tableItem != null)
					{
						list.Add(tableItem);
					}
				}
			}
			AuctionNewUtility.SortOnSaleItemTableList(list);
			List<AuctionItemBaseInfo> list2 = new List<AuctionItemBaseInfo>();
			for (int j = 0; j < list.Count; j++)
			{
				for (int k = 0; k < auctionBaseInfoList.Count; k++)
				{
					if ((long)list[j].ID == (long)((ulong)auctionBaseInfoList[k].itemTypeId))
					{
						list2.Add(auctionBaseInfoList[k]);
						break;
					}
				}
			}
			auctionBaseInfoList.Clear();
			list.Clear();
			for (int l = 0; l < list2.Count; l++)
			{
				auctionBaseInfoList.Add(list2[l]);
			}
			list2.Clear();
		}

		// Token: 0x0600B0F9 RID: 45305 RVA: 0x00270BAC File Offset: 0x0026EFAC
		public static void SortOnSaleItemTableList(List<ItemTable> notOnSaleItemTableList)
		{
			if (notOnSaleItemTableList != null && notOnSaleItemTableList.Count > 0)
			{
				bool flag = notOnSaleItemTableList[0] != null && notOnSaleItemTableList[0].Type == ItemTable.eType.EQUIP;
				if (flag)
				{
					notOnSaleItemTableList.Sort(delegate(ItemTable x, ItemTable y)
					{
						if (x.Color == ItemTable.eColor.GREEN && y.Color == ItemTable.eColor.GREEN)
						{
							int num = -x.NeedLevel.CompareTo(y.NeedLevel);
							if (num == 0)
							{
								num = x.ID.CompareTo(y.ID);
							}
							return num;
						}
						if (x.Color == ItemTable.eColor.GREEN)
						{
							return -1;
						}
						if (y.Color == ItemTable.eColor.GREEN)
						{
							return 1;
						}
						int num2 = -x.Color.CompareTo(y.Color);
						if (num2 == 0)
						{
							num2 = -x.NeedLevel.CompareTo(y.NeedLevel);
						}
						if (num2 == 0)
						{
							num2 = x.ID.CompareTo(y.ID);
						}
						return num2;
					});
				}
				else
				{
					notOnSaleItemTableList.Sort(delegate(ItemTable x, ItemTable y)
					{
						int num = -x.Color.CompareTo(y.Color);
						if (num == 0)
						{
							num = -x.NeedLevel.CompareTo(y.NeedLevel);
						}
						if (num == 0)
						{
							num = x.ID.CompareTo(y.ID);
						}
						return num;
					});
				}
			}
		}

		// Token: 0x0600B0FA RID: 45306 RVA: 0x00270C3B File Offset: 0x0026F03B
		public static void SortItemListBySinglePrice(List<AuctionBaseInfo> itemList)
		{
			if (itemList != null && itemList.Count > 0)
			{
				itemList.Sort(delegate(AuctionBaseInfo x, AuctionBaseInfo y)
				{
					uint num = x.price;
					if (x.num > 0U)
					{
						num /= x.num;
					}
					uint num2 = y.price;
					if (y.num > 0U)
					{
						num2 /= y.num;
					}
					return num.CompareTo(num2);
				});
			}
		}

		// Token: 0x0600B0FB RID: 45307 RVA: 0x00270C72 File Offset: 0x0026F072
		public static void SortItemListBySellRecordPrice(List<AuctionBaseInfo> itemList)
		{
			if (itemList == null || itemList.Count <= 0)
			{
				return;
			}
			itemList.Sort(delegate(AuctionBaseInfo x, AuctionBaseInfo y)
			{
				uint price = x.price;
				uint price2 = y.price;
				return price.CompareTo(price2);
			});
		}

		// Token: 0x0600B0FC RID: 45308 RVA: 0x00270CAC File Offset: 0x0026F0AC
		public static bool IsItemOnSale(ItemTable itemTable, List<AuctionItemBaseInfo> auctionItemBaseInfoList)
		{
			if (auctionItemBaseInfoList == null || auctionItemBaseInfoList.Count <= 0)
			{
				return false;
			}
			for (int i = 0; i < auctionItemBaseInfoList.Count; i++)
			{
				AuctionItemBaseInfo auctionItemBaseInfo = auctionItemBaseInfoList[i];
				if (auctionItemBaseInfo != null && auctionItemBaseInfo.itemTypeId == (uint)itemTable.ID)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600B0FD RID: 45309 RVA: 0x00270D08 File Offset: 0x0026F108
		public static bool IsItemOfOnSaleCanShow(int itemId, AuctionNewFilterData firstFilterData, AuctionNewFilterData secondFilterData, AuctionNewFilterData thirdFilterData)
		{
			return AuctionNewUtility.IsItemOfOnSaleCanShowByFilterData(itemId, firstFilterData) && AuctionNewUtility.IsItemOfOnSaleCanShowByFilterData(itemId, secondFilterData) && AuctionNewUtility.IsItemOfOnSaleCanShowByFilterData(itemId, thirdFilterData);
		}

		// Token: 0x0600B0FE RID: 45310 RVA: 0x00270D46 File Offset: 0x0026F146
		public static bool IsFilterDataNeedReset(AuctionNewFilterData filterData, AuctionNewFrameTable.eFilterItemType filterItemType)
		{
			return filterData == null || filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_POSITION || filterData.FilterItemType != filterItemType;
		}

		// Token: 0x0600B0FF RID: 45311 RVA: 0x00270D70 File Offset: 0x0026F170
		private static bool IsItemOfOnSaleCanShowByFilterData(int itemId, AuctionNewFilterData filterData)
		{
			if (filterData == null)
			{
				return true;
			}
			if (filterData.FilterItemType != AuctionNewFrameTable.eFilterItemType.FIT_POSITION)
			{
				return true;
			}
			if (filterData.AuctionNewFilterTable == null || filterData.AuctionNewFilterTable.Parameter == null)
			{
				return true;
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return false;
			}
			if (tableItem.Type == ItemTable.eType.EXPENDABLE && tableItem.SubType == ItemTable.eSubType.EnchantmentsCard)
			{
				return AuctionNewUtility.IsItemCanShow(tableItem, filterData);
			}
			return tableItem.Type != ItemTable.eType.EXPENDABLE || tableItem.SubType != ItemTable.eSubType.Bead || AuctionNewUtility.IsItemCanShow(tableItem, filterData);
		}

		// Token: 0x0600B100 RID: 45312 RVA: 0x00270E18 File Offset: 0x0026F218
		public static bool IsItemCanShow(ItemTable itemTable, AuctionNewFilterData filterData)
		{
			if (filterData == null)
			{
				return true;
			}
			if (filterData.AuctionNewFilterTable == null || filterData.AuctionNewFilterTable.Parameter == null)
			{
				return true;
			}
			if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_LEVEL && filterData.AuctionNewFilterTable.Parameter.Count == 2 && itemTable.NeedLevel >= filterData.AuctionNewFilterTable.Parameter[0] && itemTable.NeedLevel <= filterData.AuctionNewFilterTable.Parameter[1])
			{
				return true;
			}
			if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_QUALITY)
			{
				for (int i = 0; i < filterData.AuctionNewFilterTable.Parameter.Length; i++)
				{
					if (itemTable.Color == (ItemTable.eColor)filterData.AuctionNewFilterTable.Parameter[i])
					{
						return true;
					}
				}
			}
			if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_SUCCEEDRAT)
			{
				StrengthenTicketTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(itemTable.StrenTicketDataIndex, string.Empty, string.Empty);
				if (tableItem != null && filterData.AuctionNewFilterTable.Parameter.Count == 2)
				{
					int num = (int)((float)tableItem.Probility * 0.1f);
					if (num >= filterData.AuctionNewFilterTable.Parameter[0] && num <= filterData.AuctionNewFilterTable.Parameter[1])
					{
						return true;
					}
				}
			}
			if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_JOB)
			{
				for (int j = 0; j < itemTable.Occu.Count; j++)
				{
					int num2 = itemTable.Occu[j];
					if (num2 == 0)
					{
						return true;
					}
					int baseJobID = Utility.GetBaseJobID(num2);
					for (int k = 0; k < filterData.AuctionNewFilterTable.Parameter.Count; k++)
					{
						int num3 = filterData.AuctionNewFilterTable.Parameter[k];
						if (num2 == num3)
						{
							return true;
						}
					}
				}
			}
			if (filterData.FilterItemType == AuctionNewFrameTable.eFilterItemType.FIT_POSITION)
			{
				List<int> list = filterData.AuctionNewFilterTable.Parameter.ToList<int>();
				if (list.Count == 1 && list[0] == 0)
				{
					return true;
				}
				if (itemTable.Type == ItemTable.eType.EXPENDABLE && itemTable.SubType == ItemTable.eSubType.EnchantmentsCard)
				{
					MagicCardTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(itemTable.ID, string.Empty, string.Empty);
					if (tableItem2 != null && tableItem2.Parts != null && tableItem2.Parts.Length > 0)
					{
						for (int l = 0; l < list.Count; l++)
						{
							int other = list[l];
							if (tableItem2.Parts.Contains(other))
							{
								return true;
							}
						}
					}
				}
				if (itemTable.Type == ItemTable.eType.EXPENDABLE && itemTable.SubType == ItemTable.eSubType.Bead)
				{
					BeadTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<BeadTable>(itemTable.ID, string.Empty, string.Empty);
					if (tableItem3 != null && tableItem3.Parts != null && tableItem3.Parts.Length > 0)
					{
						for (int m = 0; m < list.Count; m++)
						{
							int other2 = list[m];
							if (tableItem3.Parts.Contains(other2))
							{
								return true;
							}
						}
					}
				}
			}
			return false;
		}

		// Token: 0x0600B101 RID: 45313 RVA: 0x00271166 File Offset: 0x0026F566
		public static ItemTable.eType GetItemTableType(AuctionNewFrameTable.eMainItemType mainItemType)
		{
			if (mainItemType == AuctionNewFrameTable.eMainItemType.MIT_COST)
			{
				return ItemTable.eType.EXPENDABLE;
			}
			if (mainItemType == AuctionNewFrameTable.eMainItemType.MIT_MATERIAL)
			{
				return ItemTable.eType.MATERIAL;
			}
			return ItemTable.eType.EQUIP;
		}

		// Token: 0x0600B102 RID: 45314 RVA: 0x0027117C File Offset: 0x0026F57C
		private static List<int> GetItemIdListByDataModel(ItemTable.eType itemTableType, AuctionNewFrameTable auctionNewFrameTable)
		{
			List<int> list = new List<int>();
			if (auctionNewFrameTable == null)
			{
				return list;
			}
			FlatBufferArray<int> subType = auctionNewFrameTable.SubType;
			FlatBufferArray<int> thirdType = auctionNewFrameTable.ThirdType;
			int length = subType.Length;
			for (int i = 0; i < length; i++)
			{
				int itemSubType = subType[i];
				List<int> auctionItemListBaseFliter = DataManager<ItemDataManager>.GetInstance().GetAuctionItemListBaseFliter(itemTableType, (ItemTable.eSubType)itemSubType);
				if (auctionItemListBaseFliter != null)
				{
					if (i < thirdType.Length)
					{
						ItemTable.eThirdType eThirdType = (ItemTable.eThirdType)thirdType[i];
						for (int j = 0; j < auctionItemListBaseFliter.Count; j++)
						{
							int num = auctionItemListBaseFliter[j];
							ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(num, string.Empty, string.Empty);
							if (tableItem != null)
							{
								if (tableItem.ThirdType == eThirdType)
								{
									if (auctionNewFrameTable.SpecialParametersType == 1)
									{
										if (auctionNewFrameTable.SpecialParameters != (int)tableItem.Color)
										{
											goto IL_1E0;
										}
									}
									else if (auctionNewFrameTable.SpecialParametersType == 2)
									{
										StrengthenTicketTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<StrengthenTicketTable>(tableItem.StrenTicketDataIndex, string.Empty, string.Empty);
										if (tableItem2 == null || tableItem2.Level != auctionNewFrameTable.SpecialParameters)
										{
											goto IL_1E0;
										}
									}
									AuctionNewFrameTable.eJob job = auctionNewFrameTable.Job;
									if (job == AuctionNewFrameTable.eJob.AC_JOB_ALL)
									{
										list.Add(num);
									}
									else if (tableItem.Occu.Count >= 1 && tableItem.Occu[0] != 0)
									{
										bool flag = false;
										for (int k = 0; k < tableItem.Occu.Count; k++)
										{
											JobTable tableItem3 = Singleton<TableManager>.GetInstance().GetTableItem<JobTable>(tableItem.Occu[k], string.Empty, string.Empty);
											if (tableItem3 != null)
											{
												if (job == (AuctionNewFrameTable.eJob)tableItem3.AuctionJob)
												{
													flag = true;
													break;
												}
											}
										}
										if (flag)
										{
											list.Add(num);
										}
									}
								}
							}
							IL_1E0:;
						}
					}
				}
			}
			return list;
		}

		// Token: 0x0600B103 RID: 45315 RVA: 0x0027138C File Offset: 0x0026F78C
		private static List<int> GetItemIdListByDeleteSubTypeList(ItemTable.eType itemTableType, List<int> deleteSubTypeList)
		{
			Dictionary<ItemTable.eSubType, List<int>> auctionItemListByItemType = DataManager<ItemDataManager>.GetInstance().GetAuctionItemListByItemType(itemTableType);
			if (auctionItemListByItemType == null)
			{
				return null;
			}
			List<int> list = new List<int>();
			foreach (KeyValuePair<ItemTable.eSubType, List<int>> keyValuePair in auctionItemListByItemType)
			{
				ItemTable.eSubType key = keyValuePair.Key;
				bool flag = false;
				for (int i = 0; i < deleteSubTypeList.Count; i++)
				{
					if (deleteSubTypeList[i] == (int)key)
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					List<int> list2 = list;
					Dictionary<ItemTable.eSubType, List<int>>.Enumerator enumerator;
					KeyValuePair<ItemTable.eSubType, List<int>> keyValuePair2 = enumerator.Current;
					list2.AddRange(keyValuePair2.Value.ToArray());
				}
			}
			return list;
		}

		// Token: 0x0600B104 RID: 45316 RVA: 0x00271438 File Offset: 0x0026F838
		public static List<int> GetItemIdList(AuctionNewMenuTabDataModel firstLayerMenuTabDataModel, AuctionNewMenuTabDataModel secondLayerMenuTabDataModel, AuctionNewMenuTabDataModel thirdLayerMenuTabDataModel)
		{
			if (firstLayerMenuTabDataModel == null || firstLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogErrorFormat("FirstLayerMenuTabDataModel is Error", new object[0]);
				return null;
			}
			if (secondLayerMenuTabDataModel == null || secondLayerMenuTabDataModel.AuctionNewFrameTable == null)
			{
				Logger.LogErrorFormat("SecondLayerMenuTabDataModel is Error", new object[0]);
				return null;
			}
			List<int> list = new List<int>();
			ItemTable.eType itemTableType = AuctionNewUtility.GetItemTableType(firstLayerMenuTabDataModel.AuctionNewFrameTable.MainItemType);
			if (thirdLayerMenuTabDataModel != null && thirdLayerMenuTabDataModel.AuctionNewFrameTable != null)
			{
				return AuctionNewUtility.GetItemIdListByDataModel(itemTableType, thirdLayerMenuTabDataModel.AuctionNewFrameTable);
			}
			if (secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID.Count == 0 || (secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID.Count == 1 && secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID[0] == 0))
			{
				return AuctionNewUtility.GetItemIdListByDataModel(itemTableType, secondLayerMenuTabDataModel.AuctionNewFrameTable);
			}
			List<int> list2 = new List<int>();
			int count = secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID.Count;
			for (int i = 0; i < count; i++)
			{
				int id = secondLayerMenuTabDataModel.AuctionNewFrameTable.DeleteLayerID[i];
				AuctionNewFrameTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<AuctionNewFrameTable>(id, string.Empty, string.Empty);
				if (tableItem != null)
				{
					for (int j = 0; j < tableItem.SubType.Length; j++)
					{
						list2.Add(tableItem.SubType[j]);
					}
				}
			}
			List<int> list3 = list2.Distinct<int>();
			return AuctionNewUtility.GetItemIdListByDeleteSubTypeList(itemTableType, list3.ToList<int>());
		}

		// Token: 0x0600B105 RID: 45317 RVA: 0x002715C3 File Offset: 0x0026F9C3
		public static bool IsAuctionTreasureItemOpen()
		{
			return !DataManager<ServerSceneFuncSwitchManager>.GetInstance().IsTypeFuncLock(ServiceType.SERVICE_AUCTION_TREAS);
		}

		// Token: 0x0600B106 RID: 45318 RVA: 0x002715DC File Offset: 0x0026F9DC
		public static int GetMagicCardStrengthenAddition(ItemData itemData)
		{
			if (itemData == null || itemData.StrengthenLevel <= 0 || itemData.Quality == ItemTable.eColor.CL_NONE)
			{
				return 0;
			}
			int strengthenLevel = itemData.StrengthenLevel;
			int quality = (int)itemData.Quality;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AuctionMagiStrengAdditTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AuctionMagiStrengAdditTable auctionMagiStrengAdditTable = keyValuePair.Value as AuctionMagiStrengAdditTable;
				if (auctionMagiStrengAdditTable != null && auctionMagiStrengAdditTable.Type == 1 && auctionMagiStrengAdditTable.StrengthenLv == strengthenLevel && auctionMagiStrengAdditTable.Color == quality)
				{
					return auctionMagiStrengAdditTable.StrengthenAddition;
				}
			}
			return 0;
		}

		// Token: 0x0600B107 RID: 45319 RVA: 0x00271687 File Offset: 0x0026FA87
		public static void UpdateItemDataByEquipType(ItemData itemData, AuctionBaseInfo auctionBaseInfo)
		{
			if (itemData == null || auctionBaseInfo == null)
			{
				return;
			}
			itemData.EquipType = (EEquipType)auctionBaseInfo.equipType;
			if (itemData.EquipType == EEquipType.ET_REDMARK)
			{
				itemData.GrowthAttrType = (EGrowthAttrType)auctionBaseInfo.enhanceType;
				itemData.GrowthAttrNum = (int)auctionBaseInfo.enhanceNum;
			}
		}

		// Token: 0x0600B108 RID: 45320 RVA: 0x002716C6 File Offset: 0x0026FAC6
		public static void UpdateItemDataByEquipType(ItemData itemData, byte equipType, byte enhanceType, int enhanceNum)
		{
			if (itemData == null)
			{
				return;
			}
			itemData.EquipType = (EEquipType)equipType;
			if (itemData.EquipType == EEquipType.ET_REDMARK)
			{
				itemData.GrowthAttrType = (EGrowthAttrType)enhanceType;
				itemData.GrowthAttrNum = enhanceNum;
			}
		}

		// Token: 0x0600B109 RID: 45321 RVA: 0x002716F0 File Offset: 0x0026FAF0
		public static int GetRedEquipStrengthLvAdditionalPriceRate(ItemData itemData)
		{
			if (itemData == null || itemData.StrengthenLevel < 0 || itemData.Quality == ItemTable.eColor.CL_NONE)
			{
				return 0;
			}
			int strengthenLevel = itemData.StrengthenLevel;
			int quality = (int)itemData.Quality;
			Dictionary<int, object> table = Singleton<TableManager>.GetInstance().GetTable<AuctionMagiStrengAdditTable>();
			foreach (KeyValuePair<int, object> keyValuePair in table)
			{
				AuctionMagiStrengAdditTable auctionMagiStrengAdditTable = keyValuePair.Value as AuctionMagiStrengAdditTable;
				if (auctionMagiStrengAdditTable != null && auctionMagiStrengAdditTable.Type == 3 && auctionMagiStrengAdditTable.StrengthenLv == strengthenLevel && auctionMagiStrengAdditTable.Color == quality)
				{
					return auctionMagiStrengAdditTable.StrengthenAddition;
				}
			}
			return 0;
		}

		// Token: 0x0600B10A RID: 45322 RVA: 0x0027179C File Offset: 0x0026FB9C
		public static int GetNormalEquipStrengthLvAdditionalPriceRate(int iStrengthLv)
		{
			if (iStrengthLv <= 10)
			{
				return 0;
			}
			if (iStrengthLv == 11)
			{
				return 30;
			}
			if (iStrengthLv == 12)
			{
				return 60;
			}
			if (iStrengthLv == 13)
			{
				return 150;
			}
			if (iStrengthLv == 14)
			{
				return 300;
			}
			if (iStrengthLv == 15)
			{
				return 400;
			}
			if (iStrengthLv == 16)
			{
				return 500;
			}
			if (iStrengthLv == 17)
			{
				return 600;
			}
			if (iStrengthLv == 18)
			{
				return 700;
			}
			if (iStrengthLv == 19)
			{
				return 800;
			}
			if (iStrengthLv == 20)
			{
				return 900;
			}
			return 900;
		}

		// Token: 0x0600B10B RID: 45323 RVA: 0x0027183E File Offset: 0x0026FC3E
		public static ulong GetBasePrice(ulong recommendPrice, int strengthenLevelRate)
		{
			return (ulong)(recommendPrice * (ulong)((long)(100 + strengthenLevelRate)) / 100f);
		}

		// Token: 0x0600B10C RID: 45324 RVA: 0x00271850 File Offset: 0x0026FC50
		public static bool IsItemOwnerTimeValid(int itemId)
		{
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(itemId, string.Empty, string.Empty);
			return tableItem != null && tableItem.TimeLeft > 0;
		}

		// Token: 0x0600B10D RID: 45325 RVA: 0x00271888 File Offset: 0x0026FC88
		public static bool IsTimeItemCanOnShelf(uint endTime)
		{
			return endTime - DataManager<TimeManager>.GetInstance().GetServerTime() >= 172800U;
		}

		// Token: 0x0600B10E RID: 45326 RVA: 0x002718A3 File Offset: 0x0026FCA3
		public static bool IsItemInValidTimeInterval(uint endTime)
		{
			return endTime >= DataManager<TimeManager>.GetInstance().GetServerTime();
		}

		// Token: 0x0600B10F RID: 45327 RVA: 0x002718B8 File Offset: 0x0026FCB8
		public static string GetTimeValidItemLeftTimeStr(uint endTime)
		{
			uint num = endTime - DataManager<TimeManager>.GetInstance().GetServerTime();
			string result = string.Empty;
			if (num >= 86400U)
			{
				uint num2 = num / 86400U;
				uint num3 = num % 86400U / 3600U;
				string arg = string.Format(TR.Value("auction_new_time_day_hour"), num2, num3);
				result = string.Format(TR.Value("auction_new_item_is_valid_time"), arg);
			}
			else
			{
				uint num4 = num / 3600U;
				uint num5 = num % 3600U / 60U;
				string arg2 = string.Format(TR.Value("auction_new_time_hour_minute"), num4, num5);
				result = string.Format(TR.Value("auction_new_item_is_valid_time"), arg2);
			}
			return result;
		}

		// Token: 0x0600B110 RID: 45328 RVA: 0x00271974 File Offset: 0x0026FD74
		public static void OnCloseAuctionNewBuyItemFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<AuctionNewBuyItemFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<AuctionNewBuyItemFrame>(null, false);
			}
		}

		// Token: 0x0600B111 RID: 45329 RVA: 0x00271994 File Offset: 0x0026FD94
		public static void OnOpenAuctionNewBuyItemFrame(AuctionBaseInfo auctionBaseInfo)
		{
			AuctionNewUtility.OnCloseAuctionNewBuyItemFrame();
			AuctionNewBuyItemDataModel auctionNewBuyItemDataModel = new AuctionNewBuyItemDataModel();
			auctionNewBuyItemDataModel.SetBuyItemDataModel(auctionBaseInfo);
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<AuctionNewBuyItemFrame>(FrameLayer.Middle, auctionNewBuyItemDataModel, string.Empty);
		}

		// Token: 0x0600B112 RID: 45330 RVA: 0x002719C8 File Offset: 0x0026FDC8
		public static void OnShowItemTradeLimitFrame(string contentStr, Action onOkClick)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = contentStr,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onOkClick
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B113 RID: 45331 RVA: 0x00271A18 File Offset: 0x0026FE18
		public static int GetDays(int time)
		{
			return time / 86400;
		}

		// Token: 0x0600B114 RID: 45332 RVA: 0x00271A24 File Offset: 0x0026FE24
		public static bool IsItemForeverFreeze(int freezeTime)
		{
			int days = AuctionNewUtility.GetDays(freezeTime);
			return days > 4000;
		}
	}
}
