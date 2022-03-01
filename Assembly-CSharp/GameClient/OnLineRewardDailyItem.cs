using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001901 RID: 6401
	public class OnLineRewardDailyItem : ActivityItemBase
	{
		// Token: 0x0600F96E RID: 63854 RVA: 0x00441AA8 File Offset: 0x0043FEA8
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.mReceiveGrayItemGo.CustomActive(false);
				this.mNotReachItemGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
				this.mItemGray.enabled = false;
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mNotReachItemGo.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mReceiveBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mItemGray.enabled = true;
					this.mReceiveGrayItemGo.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mItemGray.enabled = true;
				this.mReceiveGrayItemGo.CustomActive(true);
				this.mNotReachItemGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
			}
			this.UpdateOnLineTimeDesc();
		}

		// Token: 0x0600F96F RID: 63855 RVA: 0x00441B97 File Offset: 0x0043FF97
		public sealed override void Dispose()
		{
			this.mIsLeftMinus0 = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F970 RID: 63856 RVA: 0x00441BBC File Offset: 0x0043FFBC
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.ParamNums2.Count > 0)
			{
				this.totalTime = (int)(data.ParamNums2[0] / 60U);
			}
			if (data.AwardDataList.Count == 1)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				if (opTaskReward != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
					if (itemData != null)
					{
						itemData.Count = (int)opTaskReward.num;
						if (this.mItemBackground != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemBackground, itemData.GetQualityInfo().Background, true);
						}
						if (this.mItemIcon != null)
						{
							ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
						}
						if (opTaskReward.num > 1U)
						{
							if (this.mItemCount != null)
							{
								this.mItemCount.text = opTaskReward.num.ToString();
							}
						}
						else if (this.mItemCount != null)
						{
							this.mItemCount.text = string.Empty;
						}
						if (this.mItemIconBtn != null)
						{
							this.mItemIconBtn.SafeRemoveAllListener();
							this.mItemIconBtn.SafeAddOnClickListener(delegate
							{
								DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
							});
						}
						if (this.mGoLimitTime != null)
						{
							int num;
							bool flag;
							itemData.GetTimeLeft(out num, out flag);
							if ((flag && num > 0) || itemData.IsTimeLimit)
							{
								this.mGoLimitTime.CustomActive(true);
							}
							else
							{
								this.mGoLimitTime.CustomActive(false);
							}
						}
					}
				}
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this._OnMyItemClick));
			}
			this.mData = data;
			this.UpdateOnLineTimeDesc();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F971 RID: 63857 RVA: 0x00441DF8 File Offset: 0x004401F8
		private void UpdateOnLineTimeDesc()
		{
			int num = 0;
			if (this.mData.ParamProgressList != null)
			{
				for (int i = 0; i < this.mData.ParamProgressList.Count; i++)
				{
					OpActTaskParam opActTaskParam = this.mData.ParamProgressList[i];
					if (opActTaskParam != null)
					{
						if (opActTaskParam.key == "daily_online_count")
						{
							num = (int)(opActTaskParam.value / 60U);
						}
					}
				}
			}
			if (num >= this.totalTime)
			{
				num = this.totalTime;
			}
			if (this.mTimeDesc != null)
			{
				this.mTimeDesc.text = string.Format("{0}/{1}分钟", num, this.totalTime);
			}
		}

		// Token: 0x0600F972 RID: 63858 RVA: 0x00441EC0 File Offset: 0x004402C0
		private void _OnMyItemClick()
		{
			this._OnItemClick();
			if (this.mData != null)
			{
				if (this.mData.AccountDailySubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
				}
				if (this.mData.AccountTotalSubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
				}
			}
		}

		// Token: 0x0600F973 RID: 63859 RVA: 0x00441F34 File Offset: 0x00440334
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F974 RID: 63860 RVA: 0x00441F68 File Offset: 0x00440368
		private void ShowHaveUsedNumState(ILimitTimeActivityTaskDataModel data)
		{
			if (data != null)
			{
				int num = 0;
				int num2 = 0;
				if (data.AccountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					num = data.AccountDailySubmitLimit;
				}
				else if (data.AccountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = data.AccountTotalSubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0 && num > 0)
				{
					this.mItemGray.enabled = true;
					this.mReceiveGrayItemGo.CustomActive(true);
					this.mNotReachItemGo.CustomActive(false);
					this.mReceiveBtn.CustomActive(false);
					this.mIsLeftMinus0 = true;
				}
			}
		}

		// Token: 0x04009B3E RID: 39742
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009B3F RID: 39743
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009B40 RID: 39744
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009B41 RID: 39745
		[SerializeField]
		private Text mTimeDesc;

		// Token: 0x04009B42 RID: 39746
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009B43 RID: 39747
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x04009B44 RID: 39748
		[SerializeField]
		private UIGray mItemGray;

		// Token: 0x04009B45 RID: 39749
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x04009B46 RID: 39750
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x04009B47 RID: 39751
		[SerializeField]
		private GameObject mGoLimitTime;

		// Token: 0x04009B48 RID: 39752
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009B49 RID: 39753
		private bool mIsLeftMinus0;

		// Token: 0x04009B4A RID: 39754
		private int totalTime;
	}
}
