using System;
using DataModel;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E5 RID: 5093
	public class ActivityTreasureLotteryMyLotteryView : ActivityTreasureLotteryActivityViewBase<IActivityTreasureLotteryMyLotteryModel>
	{
		// Token: 0x0600C57C RID: 50556 RVA: 0x002F9B08 File Offset: 0x002F7F08
		protected override void OnInit()
		{
			base.OnInit();
			if (this.mDataManager.GetModelAmount<IActivityTreasureLotteryMyLotteryModel>() <= 0)
			{
				this.mTextEmptyTip.SafeSetText(TR.Value("activity_treasure_my_lottery_empty_tip"));
				this.mTextEmptyTip.gameObject.CustomActive(true);
				this.mRightPanel.CustomActive(false);
			}
			else
			{
				this.mTextEmptyTip.gameObject.CustomActive(false);
				this.mRightPanel.CustomActive(true);
			}
		}

		// Token: 0x0600C57D RID: 50557 RVA: 0x002F9B80 File Offset: 0x002F7F80
		protected sealed override void OnSelectItem(IActivityTreasureLotteryMyLotteryModel data)
		{
			if (this.mComItem == null)
			{
				this.mComItem = ComItemManager.Create(this.mComItemRoot.gameObject);
			}
			if (data == null)
			{
				return;
			}
			if (this.mTextEmptyTip != null && this.mTextEmptyTip.gameObject.activeSelf)
			{
				this.mTextEmptyTip.gameObject.CustomActive(false);
				this.mRightPanel.CustomActive(true);
			}
			ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(data.ItemId, string.Empty, string.Empty);
			ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(data.ItemId);
			this.mComItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.ShowItemTip));
			if (tableItem != null)
			{
				ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, false, false);
				if (qualityInfo != null)
				{
					this.mTextItemName.SafeSetText(string.Format("<color={0}>{1}*{2}</color>", qualityInfo.ColStr, tableItem.Name, data.ItemNum));
				}
				else
				{
					Logger.LogError(string.Format("找不到匹配的qualityInfo, 道具id为 {0}, ", data.ItemId));
				}
			}
			else
			{
				Logger.LogError(string.Format("错误的 itemId:{0} 在道具表中找不到此id", data.ItemId));
			}
			GambingMineStatus status = data.Status;
			if (status != GambingMineStatus.GMS_WAIT)
			{
				if (status == GambingMineStatus.GMS_SUCCESS || status == GambingMineStatus.GMS_FAILE)
				{
					this.InitCloseState(data);
				}
			}
			else
			{
				this.InitOpenState(data);
			}
		}

		// Token: 0x0600C57E RID: 50558 RVA: 0x002F9CFF File Offset: 0x002F80FF
		protected override void OnDispose()
		{
			base.OnDispose();
			ComItemManager.Destroy(this.mComItem);
			this.mComItem = null;
		}

		// Token: 0x0600C57F RID: 50559 RVA: 0x002F9D19 File Offset: 0x002F8119
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C580 RID: 50560 RVA: 0x002F9D31 File Offset: 0x002F8131
		private void InitOpenState(IActivityTreasureLotteryMyLotteryModel model)
		{
			this.mTextState.SafeSetText(TR.Value("activity_treasure_my_lottery_state_open"));
			this.InitBaseInfo(model);
			this.mWinnerPanel.CustomActive(false);
		}

		// Token: 0x0600C581 RID: 50561 RVA: 0x002F9D5C File Offset: 0x002F815C
		private void InitCloseState(IActivityTreasureLotteryMyLotteryModel model)
		{
			this.InitBaseInfo(model);
			this.mTextState.SafeSetText(TR.Value("activity_treasure_my_lottery_state_close"));
			this.mWinnerPanel.CustomActive(true);
			if (model != null)
			{
				this.mTextWinnerInfo.SafeSetText(string.Format(TR.Value("activity_treasure_my_lottery_winner"), model.WinnerName, model.WinnerInvestment, model.CurrencyName));
			}
		}

		// Token: 0x0600C582 RID: 50562 RVA: 0x002F9DC8 File Offset: 0x002F81C8
		private void InitBaseInfo(IActivityTreasureLotteryMyLotteryModel model)
		{
			if (model != null)
			{
				this.mTextRate.SafeSetText(string.Format(TR.Value("activity_treasure_my_lottery_rate"), model.WinRate));
				this.mTextGroupId.SafeSetText(string.Format(TR.Value("activity_treasure_my_lottery_group_id"), model.GroupId));
				this.mTextSoldInfo.SafeSetText(string.Format(TR.Value("activity_treasure_my_lottery_sold"), model.TotalNum - model.RestNum, model.TotalNum));
				this.mTextBought.SafeSetText(string.Format(TR.Value("activity_treasure_my_lottery_bought"), model.MyInvestment, model.CurrencyName, model.BoughtNum));
			}
		}

		// Token: 0x040070CB RID: 28875
		[SerializeField]
		private Text mTextItemName;

		// Token: 0x040070CC RID: 28876
		[SerializeField]
		private Text mTextState;

		// Token: 0x040070CD RID: 28877
		[SerializeField]
		private Text mTextRate;

		// Token: 0x040070CE RID: 28878
		[SerializeField]
		private Text mTextGroupId;

		// Token: 0x040070CF RID: 28879
		[SerializeField]
		private Text mTextSoldInfo;

		// Token: 0x040070D0 RID: 28880
		[SerializeField]
		private Text mTextBought;

		// Token: 0x040070D1 RID: 28881
		[SerializeField]
		private GameObject mWinnerPanel;

		// Token: 0x040070D2 RID: 28882
		[SerializeField]
		private Text mTextWinnerInfo;

		// Token: 0x040070D3 RID: 28883
		[SerializeField]
		private Transform mComItemRoot;

		// Token: 0x040070D4 RID: 28884
		[SerializeField]
		private Text mTextEmptyTip;

		// Token: 0x040070D5 RID: 28885
		[SerializeField]
		private GameObject mRightPanel;

		// Token: 0x040070D6 RID: 28886
		private ComItem mComItem;
	}
}
