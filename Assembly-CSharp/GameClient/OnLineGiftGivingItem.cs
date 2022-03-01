using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001900 RID: 6400
	public class OnLineGiftGivingItem : ActivityItemBase
	{
		// Token: 0x0600F966 RID: 63846 RVA: 0x004414EC File Offset: 0x0043F8EC
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.mReceiveGrayItemGo.CustomActive(false);
				this.mNotReachItemGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mNotReachItemGo.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mReceiveBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mReceiveGrayItemGo.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mReceiveGrayItemGo.CustomActive(true);
				this.mNotReachItemGo.CustomActive(false);
				this.mReceiveBtn.CustomActive(false);
			}
		}

		// Token: 0x0600F967 RID: 63847 RVA: 0x004415B1 File Offset: 0x0043F9B1
		public sealed override void Dispose()
		{
			this.mIsLeftMinus0 = false;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F968 RID: 63848 RVA: 0x004415D8 File Offset: 0x0043F9D8
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (this.mTaskName != null)
			{
				this.mTaskName.text = data.Desc;
			}
			if (data.DataId == 1710001U)
			{
				int num = 0;
				if (data.ParamProgressList != null)
				{
					for (int i = 0; i < data.ParamProgressList.Count; i++)
					{
						OpActTaskParam opActTaskParam = data.ParamProgressList[i];
						if (opActTaskParam != null)
						{
							if (opActTaskParam.key == "daily_online_count")
							{
								num = (int)opActTaskParam.value;
							}
						}
					}
				}
				if ((long)num >= (long)((ulong)data.TotalNum))
				{
					num = (int)data.TotalNum;
				}
				if (this.mTaskName != null)
				{
					this.mTaskName.text = string.Format("账号在线{0}/{1}分钟", num, data.TotalNum);
				}
				Logger.LogErrorFormat("Time = {0}", new object[]
				{
					num
				});
			}
			else if (this.mTaskName != null)
			{
				this.mTaskName.text = string.Format("累计{0}/{1}天", data.DoneNum, data.TotalNum);
			}
			if (data.AwardDataList.Count == 1)
			{
				OpTaskReward opTaskReward = data.AwardDataList[0];
				if (opTaskReward != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
					if (itemData != null)
					{
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
							int num2;
							bool flag;
							itemData.GetTimeLeft(out num2, out flag);
							if ((flag && num2 > 0) || itemData.IsTimeLimit)
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
				this.mReceiveBtn.SafeRemoveAllListener();
				this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this._OnMyItemClick));
			}
			this.mData = data;
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.OnRequsetAccountData(data);
		}

		// Token: 0x0600F969 RID: 63849 RVA: 0x0044190C File Offset: 0x0043FD0C
		public void OnSetArrowIsShow(bool isFlag)
		{
			if (this.mArrowItemGo != null)
			{
				this.mArrowItemGo.CustomActive(isFlag);
			}
		}

		// Token: 0x0600F96A RID: 63850 RVA: 0x0044192C File Offset: 0x0043FD2C
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

		// Token: 0x0600F96B RID: 63851 RVA: 0x004419A0 File Offset: 0x0043FDA0
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F96C RID: 63852 RVA: 0x004419D4 File Offset: 0x0043FDD4
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
					this.mReceiveGrayItemGo.CustomActive(true);
					this.mNotReachItemGo.CustomActive(false);
					this.mReceiveBtn.CustomActive(false);
					this.mIsLeftMinus0 = true;
				}
			}
		}

		// Token: 0x04009B31 RID: 39729
		[SerializeField]
		private Text mTaskName;

		// Token: 0x04009B32 RID: 39730
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009B33 RID: 39731
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009B34 RID: 39732
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009B35 RID: 39733
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009B36 RID: 39734
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x04009B37 RID: 39735
		[SerializeField]
		private GameObject mArrowItemGo;

		// Token: 0x04009B38 RID: 39736
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x04009B39 RID: 39737
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x04009B3A RID: 39738
		[SerializeField]
		private GameObject mGoLimitTime;

		// Token: 0x04009B3B RID: 39739
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009B3C RID: 39740
		private bool mIsLeftMinus0;

		// Token: 0x04009B3D RID: 39741
		private bool isNumberDayActivity;
	}
}
