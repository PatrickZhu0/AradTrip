using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001902 RID: 6402
	public class OnLineRewardGrandTotalItem : ActivityItemBase
	{
		// Token: 0x0600F976 RID: 63862 RVA: 0x00442048 File Offset: 0x00440448
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
		}

		// Token: 0x0600F977 RID: 63863 RVA: 0x00442131 File Offset: 0x00440531
		public sealed override void Dispose()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			DataManager<ActivityDataManager>.GetInstance().UnRegisterBossAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
			this.mIsLeftMinus0 = false;
		}

		// Token: 0x0600F978 RID: 63864 RVA: 0x0044216C File Offset: 0x0044056C
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
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
			this.UpdateDayInfo();
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			DataManager<ActivityDataManager>.GetInstance().RegisterBossAccountData(new ClientEventSystem.UIEventHandler(this.OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F979 RID: 63865 RVA: 0x00442398 File Offset: 0x00440798
		private void UpdateDayInfo()
		{
			if (this.mTaskName != null)
			{
				this.mTaskName.text = string.Format("累计{0}/{1}天", this.mData.DoneNum, this.mData.TotalNum);
			}
		}

		// Token: 0x0600F97A RID: 63866 RVA: 0x004423EC File Offset: 0x004407EC
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

		// Token: 0x0600F97B RID: 63867 RVA: 0x00442460 File Offset: 0x00440860
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F97C RID: 63868 RVA: 0x00442494 File Offset: 0x00440894
		private void OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (uiEvent == null)
			{
				return;
			}
			if ((uint)uiEvent.Param1 == 1U && (uint)uiEvent.Param2 == 4009U)
			{
				this.UpdateDayInfo();
			}
		}

		// Token: 0x0600F97D RID: 63869 RVA: 0x004424CC File Offset: 0x004408CC
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

		// Token: 0x04009B4B RID: 39755
		[SerializeField]
		private Text mTaskName;

		// Token: 0x04009B4C RID: 39756
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009B4D RID: 39757
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009B4E RID: 39758
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009B4F RID: 39759
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009B50 RID: 39760
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x04009B51 RID: 39761
		[SerializeField]
		private UIGray mItemGray;

		// Token: 0x04009B52 RID: 39762
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x04009B53 RID: 39763
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x04009B54 RID: 39764
		[SerializeField]
		private GameObject mGoLimitTime;

		// Token: 0x04009B55 RID: 39765
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009B56 RID: 39766
		private bool mIsLeftMinus0;
	}
}
