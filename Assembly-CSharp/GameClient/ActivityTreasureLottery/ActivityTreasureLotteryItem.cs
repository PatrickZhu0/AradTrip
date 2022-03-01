using System;
using DataModel;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient.ActivityTreasureLottery
{
	// Token: 0x020013E4 RID: 5092
	public class ActivityTreasureLotteryItem : MonoBehaviour, IActivityTreasureLotteryItem
	{
		// Token: 0x0600C572 RID: 50546 RVA: 0x002F94BC File Offset: 0x002F78BC
		public void Init<T>(T model, bool isOn) where T : IActivityTreasureLotteryModelBase
		{
			if (model is IActivityTreasureLotteryModel)
			{
				this.Init(model as IActivityTreasureLotteryModel, isOn);
			}
			else if (model is IActivityTreasureLotteryMyLotteryModel)
			{
				this.Init(model as IActivityTreasureLotteryMyLotteryModel, isOn);
			}
			else if (model is IActivityTreasureLotteryHistoryModel)
			{
				this.Init(model as IActivityTreasureLotteryHistoryModel, isOn);
			}
		}

		// Token: 0x0600C573 RID: 50547 RVA: 0x002F9539 File Offset: 0x002F7939
		public void OnSelect(bool value)
		{
			this.mToggleSelect.isOn = value;
		}

		// Token: 0x0600C574 RID: 50548 RVA: 0x002F9548 File Offset: 0x002F7948
		private void Update()
		{
			if (this.mModel is IActivityTreasureLotteryModel)
			{
				IActivityTreasureLotteryModel activityTreasureLotteryModel = this.mModel as IActivityTreasureLotteryModel;
				if (activityTreasureLotteryModel != null && activityTreasureLotteryModel.State == GambingItemStatus.GIS_PREPARE)
				{
					if (activityTreasureLotteryModel.TimeRemain <= 0)
					{
						this.mTextLeftGroup.SafeSetText(TR.Value("activity_treasure_lottery_item_loading"));
					}
					else
					{
						this.mTextLeftGroup.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_item_prepare"), activityTreasureLotteryModel.TimeRemainStr, activityTreasureLotteryModel.LeftGroupNum));
					}
				}
			}
		}

		// Token: 0x0600C575 RID: 50549 RVA: 0x002F95D4 File Offset: 0x002F79D4
		private void Init(IActivityTreasureLotteryModel model, bool isOn)
		{
			this.InitBase(model, isOn);
			this.mMainViewInfo.CustomActive(true);
			this.mMyLotteryViewInfo.CustomActive(false);
			this.mHistroyViewRoot.CustomActive(false);
			if (model != null)
			{
				this.mTextLeftGroup.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_group_num"), model.LeftGroupNum));
				this.mTextLeftNum.SafeSetText(string.Format("{0}/{1}", model.LeftNum, model.TotalNum));
				this.mSliderProgress.value = 0f;
				if (model.TotalNum > 0)
				{
					this.mSliderProgress.value = model.LeftNum / (float)model.TotalNum;
				}
				this.mTipPanel.CustomActive(false);
				GambingItemStatus state = model.State;
				if (state != GambingItemStatus.GIS_PREPARE)
				{
					if (state == GambingItemStatus.GIS_SOLD_OUE || state == GambingItemStatus.GIS_LOTTERY)
					{
						this.mTipPanel.CustomActive(true);
						this.mTextTip.SafeSetText(TR.Value("activity_treasure_lottery_item_sell_out"));
					}
				}
				else
				{
					this.mTextLeftGroup.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_item_prepare"), model.TimeRemainStr, model.TotalGroup));
				}
			}
		}

		// Token: 0x0600C576 RID: 50550 RVA: 0x002F9720 File Offset: 0x002F7B20
		private void Init(IActivityTreasureLotteryMyLotteryModel model, bool isOn)
		{
			this.InitBase(model, isOn);
			this.mMainViewInfo.CustomActive(false);
			this.mMyLotteryViewInfo.CustomActive(true);
			this.mHistroyViewRoot.CustomActive(false);
			if (model == null)
			{
				return;
			}
			this.mTextMyLotteryBought.SafeSetText(string.Format(TR.Value("activity_treasure_lottery_bought"), model.BoughtNum));
			GambingMineStatus status = model.Status;
			if (status != GambingMineStatus.GMS_WAIT)
			{
				if (status != GambingMineStatus.GMS_SUCCESS)
				{
					if (status == GambingMineStatus.GMS_FAILE)
					{
						this.mMyLotterProgressRoot.CustomActive(false);
						this.mTextMyLotteryState.SafeSetText(TR.Value("activity_treasure_lottery_lose"));
					}
				}
				else
				{
					this.mMyLotterProgressRoot.CustomActive(false);
					this.mTextMyLotteryState.SafeSetText(TR.Value("activity_treasure_lottery_win"));
				}
			}
			else
			{
				this.mMyLotterProgressRoot.CustomActive(true);
				if (this.mMyLotteryProgress != null)
				{
					this.mMyLotteryProgress.value = 0f;
				}
				if (model.TotalNum > 0)
				{
					this.mMyLotteryProgress.value = (float)model.RestNum / (float)model.TotalNum;
				}
				this.mTextMyLotteryLeftNum.SafeSetText(string.Format("{0}/{1}", model.RestNum, model.TotalNum));
				this.mTextMyLotteryState.SafeSetText(TR.Value("activity_treasure_lottery_waiting"));
			}
		}

		// Token: 0x0600C577 RID: 50551 RVA: 0x002F988C File Offset: 0x002F7C8C
		private void Init(IActivityTreasureLotteryHistoryModel model, bool isOn)
		{
			this.InitBase(model, isOn);
			this.mMainViewInfo.CustomActive(false);
			this.mMyLotteryViewInfo.CustomActive(false);
			this.mHistroyViewRoot.CustomActive(true);
			if (model != null)
			{
				if (model.IsWin)
				{
					this.mImageWin.CustomActive(true);
				}
				else
				{
					this.mImageWin.CustomActive(false);
				}
				this.mTextHistoryResult.SafeSetText((!model.IsSellOut) ? TR.Value("activity_treasure_history_selling") : string.Format(TR.Value("activity_treasure_history_sold_out"), model.TimeSoldOut));
			}
		}

		// Token: 0x0600C578 RID: 50552 RVA: 0x002F9930 File Offset: 0x002F7D30
		private void InitBase(IActivityTreasureLotteryModelBase model, bool isOn)
		{
			this.mModel = model;
			if (this.mComItem != null)
			{
				if (this.mComItem.ItemData.TableID != model.ItemId)
				{
					ComItemManager.Destroy(this.mComItem);
					this.mComItem = null;
					this.mComItem = ComItemManager.Create(this.mComItemRoot.gameObject);
				}
			}
			else
			{
				this.mComItem = ComItemManager.Create(this.mComItemRoot.gameObject);
			}
			if (this.mModel != null)
			{
				if (this.mComItem.ItemData == null || this.mComItem.ItemData.TableID != this.mModel.ItemId)
				{
					ItemData commonItemTableDataByID = DataManager<ItemDataManager>.GetInstance().GetCommonItemTableDataByID(this.mModel.ItemId);
					if (this.mComItem != null)
					{
						this.mComItem.Setup(commonItemTableDataByID, new ComItem.OnItemClicked(this.ShowItemTip));
					}
				}
				if (this.mToggleSelect != null)
				{
					this.mToggleSelect.isOn = isOn;
				}
				ItemTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<ItemTable>(this.mModel.ItemId, string.Empty, string.Empty);
				if (tableItem != null)
				{
					ItemData.QualityInfo qualityInfo = ItemData.GetQualityInfo(tableItem.Color, false, false);
					if (qualityInfo != null)
					{
						this.mTextName.SafeSetText(string.Format("<color={0}>{1}*{2}</color>", qualityInfo.ColStr, this.mModel.Name, this.mModel.ItemNum));
					}
				}
				else
				{
					Logger.LogError("未找到的物品id:" + model.ItemId);
				}
			}
		}

		// Token: 0x0600C579 RID: 50553 RVA: 0x002F9AD9 File Offset: 0x002F7ED9
		private void ShowItemTip(GameObject go, ItemData itemData)
		{
			if (itemData != null)
			{
				DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
			}
		}

		// Token: 0x0600C57A RID: 50554 RVA: 0x002F9AF1 File Offset: 0x002F7EF1
		private void OnDestroy()
		{
			ComItemManager.Destroy(this.mComItem);
		}

		// Token: 0x040070B7 RID: 28855
		[SerializeField]
		private GameObject mMainViewInfo;

		// Token: 0x040070B8 RID: 28856
		[SerializeField]
		private GameObject mMyLotteryViewInfo;

		// Token: 0x040070B9 RID: 28857
		[SerializeField]
		private GameObject mHistroyViewRoot;

		// Token: 0x040070BA RID: 28858
		[Header("公共部分数据")]
		[SerializeField]
		private Text mTextName;

		// Token: 0x040070BB RID: 28859
		[SerializeField]
		private Transform mComItemRoot;

		// Token: 0x040070BC RID: 28860
		[SerializeField]
		private Toggle mToggleSelect;

		// Token: 0x040070BD RID: 28861
		[Header("夺宝中界面的数据")]
		[SerializeField]
		private Slider mSliderProgress;

		// Token: 0x040070BE RID: 28862
		[SerializeField]
		private Text mTextLeftNum;

		// Token: 0x040070BF RID: 28863
		[SerializeField]
		private Text mTextLeftGroup;

		// Token: 0x040070C0 RID: 28864
		[SerializeField]
		private GameObject mTipPanel;

		// Token: 0x040070C1 RID: 28865
		[SerializeField]
		private Text mTextTip;

		// Token: 0x040070C2 RID: 28866
		[Header("我的夺宝界面的数据")]
		[SerializeField]
		private Slider mMyLotteryProgress;

		// Token: 0x040070C3 RID: 28867
		[SerializeField]
		private Text mTextMyLotteryLeftNum;

		// Token: 0x040070C4 RID: 28868
		[SerializeField]
		private Text mTextMyLotteryBought;

		// Token: 0x040070C5 RID: 28869
		[SerializeField]
		private Text mTextMyLotteryState;

		// Token: 0x040070C6 RID: 28870
		[SerializeField]
		private GameObject mMyLotterProgressRoot;

		// Token: 0x040070C7 RID: 28871
		[Header("夺宝记录界面的数据")]
		[SerializeField]
		private Text mTextHistoryResult;

		// Token: 0x040070C8 RID: 28872
		[SerializeField]
		private Image mImageWin;

		// Token: 0x040070C9 RID: 28873
		private ComItem mComItem;

		// Token: 0x040070CA RID: 28874
		private IActivityTreasureLotteryModelBase mModel;
	}
}
