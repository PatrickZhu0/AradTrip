using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x0200129E RID: 4766
	public static class MagicCardMergeUtility
	{
		// Token: 0x0600B76F RID: 46959 RVA: 0x0029DE74 File Offset: 0x0029C274
		public static bool IsShowMagicCardMergeLevelTip()
		{
			return !DataManager<MagicCardMergeDataManager>.GetInstance().IsNotShowMagicCardMergeLevelTip;
		}

		// Token: 0x0600B770 RID: 46960 RVA: 0x0029DE88 File Offset: 0x0029C288
		public static bool IsShowMagicCardMergeOwnerDifferentTip(ItemData leftItem, ItemData rightItem)
		{
			return leftItem != null && leftItem.TableData != null && rightItem != null && rightItem.TableData != null && !DataManager<MagicCardMergeDataManager>.GetInstance().IsNotShowMagicCardMergeOwnerDifferentTip && ((leftItem.TableData.Owner == ItemTable.eOwner.NOTBIND && rightItem.TableData.Owner != ItemTable.eOwner.NOTBIND) || (rightItem.TableData.Owner == ItemTable.eOwner.NOTBIND && leftItem.TableData.Owner != ItemTable.eOwner.NOTBIND));
		}

		// Token: 0x0600B771 RID: 46961 RVA: 0x0029DF14 File Offset: 0x0029C314
		public static void OnShowMagicCardMergeOwnerTip(Action onMergeClick, OnCommonMsgBoxToggleClick onLoginClick)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("magic_card_merge_bind_tip"),
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = onLoginClick,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onMergeClick
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B772 RID: 46962 RVA: 0x0029DF74 File Offset: 0x0029C374
		public static void OnShowMagicCardMergeLevelTip(Action onMergeClick, OnCommonMsgBoxToggleClick onLoginClick)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = TR.Value("magic_card_merge_level_tip"),
				IsShowNotify = true,
				OnCommonMsgBoxToggleClick = onLoginClick,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure_merge"),
				OnRightButtonClickCallBack = onMergeClick
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B773 RID: 46963 RVA: 0x0029DFD4 File Offset: 0x0029C3D4
		public static int GetMagicCardStrengthLevel(ItemData itemData)
		{
			if (itemData == null)
			{
				return 0;
			}
			if (itemData.SubType != 25)
			{
				return 0;
			}
			if (itemData.mPrecEnchantmentCard == null)
			{
				return 0;
			}
			if (itemData.mPrecEnchantmentCard.iEnchantmentCardLevel <= 0)
			{
				return 0;
			}
			return itemData.mPrecEnchantmentCard.iEnchantmentCardLevel;
		}

		// Token: 0x0600B774 RID: 46964 RVA: 0x0029E023 File Offset: 0x0029C423
		public static void OnOpenMagicCardOneKeyMergeResultFrame()
		{
			MagicCardMergeUtility.OnCloseMagicCardOneKeyMergeResultFrame();
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MagicCardOneKeyMergeResultFrame>(FrameLayer.Middle, null, string.Empty);
		}

		// Token: 0x0600B775 RID: 46965 RVA: 0x0029E03C File Offset: 0x0029C43C
		public static void OnCloseMagicCardOneKeyMergeResultFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MagicCardOneKeyMergeResultFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MagicCardOneKeyMergeResultFrame>(null, false);
			}
		}

		// Token: 0x0600B776 RID: 46966 RVA: 0x0029E05C File Offset: 0x0029C45C
		public static void OnOpenMagicCardOneKeyMergeTipFrame(Action magicCardMergeAction)
		{
			MagicCardMergeUtility.OnCloseMagicCardOneKeyMergeTipFrame();
			MagicCardMergeData magicCardMergeData = new MagicCardMergeData();
			magicCardMergeData.MagicCardMergeAction = magicCardMergeAction;
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<MagicCardOneKeyMergeTipFrame>(FrameLayer.Middle, magicCardMergeData, string.Empty);
		}

		// Token: 0x0600B777 RID: 46967 RVA: 0x0029E08D File Offset: 0x0029C48D
		public static void SortMagicCardMergeResultData(List<ItemReward> itemRewardList)
		{
			if (itemRewardList == null || itemRewardList.Count <= 1)
			{
				return;
			}
			itemRewardList.Sort(delegate(ItemReward x, ItemReward y)
			{
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)x.id, string.Empty, string.Empty);
				ItemTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>((int)y.id, string.Empty, string.Empty);
				if (tableItem == null || tableItem2 == null)
				{
					return -1;
				}
				int num = -tableItem.Color.CompareTo(tableItem2.Color);
				if (num == 0)
				{
					num = -x.num.CompareTo(y.num);
				}
				if (num == 0)
				{
					num = x.id.CompareTo(y.id);
				}
				return num;
			});
		}

		// Token: 0x0600B778 RID: 46968 RVA: 0x0029E0C8 File Offset: 0x0029C4C8
		public static ItemData GetMagicCardItem(ulong guid)
		{
			ItemData item = DataManager<ItemDataManager>.GetInstance().GetItem(guid);
			if (item != null && item.Type == ItemTable.eType.EXPENDABLE && item.SubType == 25 && item.PackageType != EPackageType.Storage && item.PackageType != EPackageType.RoleStorage && MagicCardMergeUtility.GetMagicCardStrengthLevel(item) < 1)
			{
				return item;
			}
			return null;
		}

		// Token: 0x0600B779 RID: 46969 RVA: 0x0029E128 File Offset: 0x0029C528
		public static void GetMagicCardOneKeyMergeInfo(ref int whiteMagicCardNumber, ref int blueMagicCardNumber, ref int whiteMagicCardCost, ref int blueMagicCardCost)
		{
			List<ItemData> list = null;
			List<ItemData> list2 = null;
			if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseWhiteCard)
			{
				list = MagicCardMergeUtility.GetWhiteMagicCardItemList();
			}
			if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseBlueCard)
			{
				list2 = MagicCardMergeUtility.GetBlueMagicCardItemList();
			}
			if (list != null)
			{
				int num = 0;
				int num2 = 0;
				int num3 = 0;
				for (int i = 0; i < list.Count; i++)
				{
					if (list[i] != null)
					{
						if (list[i].TableData != null)
						{
							if (list[i].TableData.Owner == ItemTable.eOwner.NOTBIND)
							{
								num2 += list[i].Count;
							}
							else
							{
								num += list[i].Count;
							}
						}
						if (num3 == 0)
						{
							MagicCardTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(list[i].TableID, string.Empty, string.Empty);
							if (tableItem != null)
							{
								num3 = tableItem.CostNum;
							}
						}
					}
				}
				int num4;
				if (!DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseNoBindItem)
				{
					num4 = num / 2 * 2;
				}
				else
				{
					num4 = (num2 + num) / 2 * 2;
				}
				if (num4 >= 2)
				{
					whiteMagicCardNumber = num4;
					whiteMagicCardCost = num3;
				}
			}
			if (list2 != null)
			{
				int num5 = 0;
				int num6 = 0;
				int num7 = 0;
				for (int j = 0; j < list2.Count; j++)
				{
					if (list2[j] != null)
					{
						if (list2[j].TableData != null)
						{
							if (list2[j].TableData.Owner == ItemTable.eOwner.NOTBIND)
							{
								num6 += list2[j].Count;
							}
							else
							{
								num5 += list2[j].Count;
							}
						}
						if (num7 == 0)
						{
							MagicCardTable tableItem2 = Singleton<TableManager>.GetInstance().GetTableItem<MagicCardTable>(list2[j].TableID, string.Empty, string.Empty);
							if (tableItem2 != null)
							{
								num7 = tableItem2.CostNum;
							}
						}
					}
				}
				int num8;
				if (!DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUseNoBindItem)
				{
					num8 = num5 / 2 * 2;
				}
				else
				{
					num8 = (num5 + num6) / 2 * 2;
				}
				if (num8 >= 2)
				{
					blueMagicCardNumber = num8;
					blueMagicCardCost = num7;
				}
			}
		}

		// Token: 0x0600B77A RID: 46970 RVA: 0x0029E358 File Offset: 0x0029C758
		public static int GetMaxMergeTimes()
		{
			int num = 0;
			SystemValueTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<SystemValueTable>(575, string.Empty, string.Empty);
			if (tableItem != null)
			{
				num = tableItem.Value;
			}
			if (num <= 0)
			{
				num = 50;
			}
			return num;
		}

		// Token: 0x0600B77B RID: 46971 RVA: 0x0029E39C File Offset: 0x0029C79C
		public static string GetMagicCardOneKeyMergeTipContent(int whiteMagicCardNumber, int whiteMergeCost, int blueMagicCardNumber, int blueMergeCost)
		{
			int maxMergeTimes = MagicCardMergeUtility.GetMaxMergeTimes();
			string text = "白色";
			string text2 = "蓝色";
			string result = string.Empty;
			int num = whiteMagicCardNumber / 2;
			int num2 = blueMagicCardNumber / 2;
			if (num + num2 > maxMergeTimes)
			{
				if (num >= maxMergeTimes)
				{
					num = maxMergeTimes;
					num2 = 0;
				}
				else
				{
					num2 = maxMergeTimes - num;
				}
			}
			ulong num3 = DataManager<PlayerBaseData>.GetInstance().BindGold;
			if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold)
			{
				num3 += DataManager<PlayerBaseData>.GetInstance().Gold;
			}
			ulong num4 = (ulong)((long)(num * whiteMergeCost + num2 * blueMergeCost));
			if (num3 >= num4)
			{
				ulong num5 = (num4 <= DataManager<PlayerBaseData>.GetInstance().BindGold) ? num4 : DataManager<PlayerBaseData>.GetInstance().BindGold;
				ulong num6 = (num4 - num5 <= 0UL) ? 0UL : (num4 - num5);
				if (num6 > 0UL)
				{
					if (num > 0 && num2 > 0)
					{
						result = string.Format(TR.Value("magic_card_merge_money_enough_four"), new object[]
						{
							text,
							num * 2,
							text2,
							num2 * 2,
							num5,
							num6
						});
					}
					else if (num > 0)
					{
						result = string.Format(TR.Value("magic_card_merge_money_enough_two"), new object[]
						{
							text,
							num * 2,
							num5,
							num6
						});
					}
					else
					{
						result = string.Format(TR.Value("magic_card_merge_money_enough_two"), new object[]
						{
							text2,
							num2 * 2,
							num5,
							num6
						});
					}
				}
				else if (num > 0 && num2 > 0)
				{
					result = string.Format(TR.Value("magic_card_merge_money_enough_three"), new object[]
					{
						text,
						num * 2,
						text2,
						num2 * 2,
						num5
					});
				}
				else if (num > 0)
				{
					result = string.Format(TR.Value("magic_card_merge_money_enough_one"), text, num * 2, num5);
				}
				else
				{
					result = string.Format(TR.Value("magic_card_merge_money_enough_one"), text2, num2 * 2, num5);
				}
			}
			else if (num > 0)
			{
				ulong num7 = (ulong)((long)(num * whiteMergeCost));
				if (num3 < num7 + (ulong)((long)blueMergeCost))
				{
					ulong num8 = (ulong)((long)num);
					if (whiteMergeCost > 0)
					{
						num8 = num3 / (ulong)((long)whiteMergeCost);
					}
					if (num8 >= (ulong)((long)num))
					{
						num8 = (ulong)((long)num);
					}
					ulong canCostMoneyNumber = num8 * (ulong)((long)whiteMergeCost);
					ulong num9 = 0UL;
					ulong num10 = 0UL;
					MagicCardMergeUtility.GetCostBindGoldAndGoldInfo(canCostMoneyNumber, out num10, out num9);
					if (num9 > 0UL)
					{
						result = string.Format(TR.Value("magic_card_merge_money_less_two"), new object[]
						{
							num10,
							num9,
							text,
							num8 * 2UL
						});
					}
					else
					{
						result = string.Format(TR.Value("magic_card_merge_money_less_one"), num10, text, num8 * 2UL);
					}
				}
				else
				{
					ulong num11 = num3 - num7;
					ulong num12 = (ulong)((long)num2);
					if (blueMergeCost > 0)
					{
						num12 = num11 / (ulong)((long)blueMergeCost);
					}
					if (num12 >= (ulong)((long)num2))
					{
						num12 = (ulong)((long)num2);
					}
					ulong num13 = num12 * (ulong)((long)blueMergeCost);
					ulong canCostMoneyNumber2 = num7 + num13;
					ulong num14 = 0UL;
					ulong num15 = 0UL;
					MagicCardMergeUtility.GetCostBindGoldAndGoldInfo(canCostMoneyNumber2, out num15, out num14);
					if (num14 > 0UL)
					{
						result = string.Format(TR.Value("magic_card_merge_money_less_four"), new object[]
						{
							num15,
							num14,
							text,
							num * 2,
							text2,
							num12 * 2UL
						});
					}
					else
					{
						result = string.Format(TR.Value("magic_card_merge_money_less_three"), new object[]
						{
							num15,
							text,
							num * 2,
							text2,
							num12 * 2UL
						});
					}
				}
			}
			else
			{
				ulong num16 = (ulong)((long)num2);
				if (blueMergeCost > 0)
				{
					num16 = num3 / (ulong)((long)blueMergeCost);
				}
				if (num16 > (ulong)((long)num2))
				{
					num16 = (ulong)((long)num2);
				}
				ulong canCostMoneyNumber3 = num16 * (ulong)((long)blueMergeCost);
				ulong num17 = 0UL;
				ulong num18 = 0UL;
				MagicCardMergeUtility.GetCostBindGoldAndGoldInfo(canCostMoneyNumber3, out num18, out num17);
				if (num17 > 0UL)
				{
					result = string.Format(TR.Value("magic_card_merge_money_less_two"), new object[]
					{
						num18,
						num17,
						text2,
						num16 * 2UL
					});
				}
				else
				{
					result = string.Format(TR.Value("magic_card_merge_money_less_one"), num18, text2, num16 * 2UL);
				}
			}
			return result;
		}

		// Token: 0x0600B77C RID: 46972 RVA: 0x0029E85C File Offset: 0x0029CC5C
		private static void GetCostBindGoldAndGoldInfo(ulong canCostMoneyNumber, out ulong canCostBindGoldNumber, out ulong canCostGoldNumber)
		{
			canCostBindGoldNumber = 0UL;
			canCostGoldNumber = 0UL;
			if (canCostMoneyNumber > DataManager<PlayerBaseData>.GetInstance().BindGold)
			{
				canCostBindGoldNumber = DataManager<PlayerBaseData>.GetInstance().BindGold;
				canCostGoldNumber = DataManager<PlayerBaseData>.GetInstance().Gold;
			}
			else
			{
				canCostBindGoldNumber = DataManager<PlayerBaseData>.GetInstance().BindGold;
				if (DataManager<MagicCardMergeDataManager>.GetInstance().IsMagicCardOneKeyMergeUserGold)
				{
					canCostGoldNumber = DataManager<PlayerBaseData>.GetInstance().Gold;
				}
			}
		}

		// Token: 0x0600B77D RID: 46973 RVA: 0x0029E8C5 File Offset: 0x0029CCC5
		public static List<ItemData> GetWhiteMagicCardItemList()
		{
			return MagicCardMergeUtility.GetMagicCardItemListByQuality(ItemTable.eColor.WHITE);
		}

		// Token: 0x0600B77E RID: 46974 RVA: 0x0029E8CD File Offset: 0x0029CCCD
		public static List<ItemData> GetBlueMagicCardItemList()
		{
			return MagicCardMergeUtility.GetMagicCardItemListByQuality(ItemTable.eColor.BLUE);
		}

		// Token: 0x0600B77F RID: 46975 RVA: 0x0029E8D8 File Offset: 0x0029CCD8
		public static List<ItemData> GetMagicCardItemListByQuality(ItemTable.eColor itemColor)
		{
			List<ItemData> list = new List<ItemData>();
			List<ulong> itemsByType = DataManager<ItemDataManager>.GetInstance().GetItemsByType(ItemTable.eType.EXPENDABLE);
			for (int i = 0; i < itemsByType.Count; i++)
			{
				ItemData magicCardItem = MagicCardMergeUtility.GetMagicCardItem(itemsByType[i]);
				if (magicCardItem != null && magicCardItem.Quality == itemColor)
				{
					list.Add(magicCardItem);
				}
			}
			return list;
		}

		// Token: 0x0600B780 RID: 46976 RVA: 0x0029E938 File Offset: 0x0029CD38
		public static void OnShowOneKeyMergeTipContent(string tipContent, Action onMergeAction)
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = tipContent,
				IsShowNotify = false,
				LeftButtonText = TR.Value("common_data_cancel"),
				RightButtonText = TR.Value("common_data_sure"),
				OnRightButtonClickCallBack = onMergeAction
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600B781 RID: 46977 RVA: 0x0029E988 File Offset: 0x0029CD88
		public static void OnCloseMagicCardOneKeyMergeTipFrame()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<MagicCardOneKeyMergeTipFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<MagicCardOneKeyMergeTipFrame>(null, false);
			}
		}
	}
}
