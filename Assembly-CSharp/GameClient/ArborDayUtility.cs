using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;

namespace GameClient
{
	// Token: 0x02001875 RID: 6261
	public static class ArborDayUtility
	{
		// Token: 0x0600F55B RID: 62811 RVA: 0x0042313C File Offset: 0x0042153C
		public static int GetTreeSeedOwnerNumber(int seedId)
		{
			return DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(seedId, true);
		}

		// Token: 0x0600F55C RID: 62812 RVA: 0x00423157 File Offset: 0x00421557
		public static int GetTreeSeedNeedNumber()
		{
			return 1;
		}

		// Token: 0x0600F55D RID: 62813 RVA: 0x0042315C File Offset: 0x0042155C
		public static int GetCounterValueByCounterStr(string counterStr)
		{
			return DataManager<CountDataManager>.GetInstance().GetCount(counterStr);
		}

		// Token: 0x0600F55E RID: 62814 RVA: 0x00423176 File Offset: 0x00421576
		public static void OnReceiveArborDayRewardItem(int itemId)
		{
		}

		// Token: 0x0600F55F RID: 62815 RVA: 0x00423178 File Offset: 0x00421578
		public static List<int> GetRewardItemList()
		{
			return null;
		}

		// Token: 0x0600F560 RID: 62816 RVA: 0x0042317C File Offset: 0x0042157C
		public static void OnOpenRewardReviewFrame(int firstRewardItemId = 0, int secondRewardItemId = 0)
		{
			PreViewDataModel preViewDataModel = new PreViewDataModel();
			if (firstRewardItemId > 0)
			{
				PreViewItemData item = new PreViewItemData
				{
					itemId = firstRewardItemId
				};
				preViewDataModel.preViewItemList.Add(item);
			}
			if (secondRewardItemId > 0)
			{
				PreViewItemData item2 = new PreViewItemData
				{
					itemId = secondRewardItemId
				};
				preViewDataModel.preViewItemList.Add(item2);
			}
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PreviewModelFrame>(null))
			{
				Singleton<ClientSystemManager>.GetInstance().CloseFrame<PreviewModelFrame>(null, false);
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
		}

		// Token: 0x0600F561 RID: 62817 RVA: 0x00423204 File Offset: 0x00421604
		public static int GetRewardItemId(ILimitTimeActivityTaskDataModel taskDataModel)
		{
			int result = 0;
			if (taskDataModel.AwardDataList != null && taskDataModel.AwardDataList.Count == 1)
			{
				OpTaskReward opTaskReward = taskDataModel.AwardDataList[0];
				if (opTaskReward != null)
				{
					result = (int)opTaskReward.id;
				}
			}
			return result;
		}

		// Token: 0x0600F562 RID: 62818 RVA: 0x0042324C File Offset: 0x0042164C
		public static string GetRewardItemName(int rewardItemId)
		{
			string empty = string.Empty;
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(rewardItemId, string.Empty, string.Empty);
			return CommonUtility.GetItemColorName(tableItem);
		}
	}
}
