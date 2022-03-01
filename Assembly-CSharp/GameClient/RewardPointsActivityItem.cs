using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001909 RID: 6409
	public class RewardPointsActivityItem : ActivityItemBase
	{
		// Token: 0x0600F99B RID: 63899 RVA: 0x00443A28 File Offset: 0x00441E28
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

		// Token: 0x0600F99C RID: 63900 RVA: 0x00443AF0 File Offset: 0x00441EF0
		public sealed override void Dispose()
		{
			base.Dispose();
			if (this.mComItems != null)
			{
				for (int i = this.mComItems.Count - 1; i >= 0; i--)
				{
					ComItemManager.Destroy(this.mComItems[i]);
				}
				this.mComItems.Clear();
			}
			this.mIsLeftMinus0 = false;
			this.totalScore = 0;
		}

		// Token: 0x0600F99D RID: 63901 RVA: 0x00443B58 File Offset: 0x00441F58
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			int activityId = DataManager<ActivityDataManager>.GetInstance()._GetLimitTimeActivityIdByTaskId(data.DataId);
			OpActivityData limitTimeActivityData = DataManager<ActivityDataManager>.GetInstance().GetLimitTimeActivityData((uint)activityId);
			if (limitTimeActivityData != null)
			{
				if (limitTimeActivityData.tmpType == 7200U)
				{
					if (data.ParamNums.Count > 0)
					{
						if (data.ParamNums[0] == 0U)
						{
							this.totalScore = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_CHALLENGE_DAY_SCORE);
						}
						else
						{
							this.totalScore = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_CHALLENGE_SCORE);
						}
					}
				}
				else if (limitTimeActivityData.tmpType == 7400U)
				{
					this.totalScore = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_SPRING_SCORE);
				}
			}
			if (this.mTaskName != null)
			{
				this.mTaskName.text = data.Desc;
			}
			if (this.mIntegralCount != null)
			{
				this.mIntegralCount.text = string.Format("{0}/{1}", this.totalScore, data.ParamNums2[0]);
			}
			for (int i = 0; i < data.AwardDataList.Count; i++)
			{
				OpTaskReward opTaskReward = data.AwardDataList[i];
				if (opTaskReward != null)
				{
					ComItem comItem = ComItemManager.Create(this.mItemParent);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
						itemData.Count = (int)opTaskReward.num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (RewardPointsActivityItem.<>f__mg$cache0 == null)
						{
							RewardPointsActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, RewardPointsActivityItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
			}
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.SafeRemoveAllListener();
				this.mReceiveBtn.SafeAddOnClickListener(new UnityAction(this._OnMyItemClick));
			}
			this.mData = data;
			this.ShowHaveUsedNumState(data);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F99E RID: 63902 RVA: 0x00443D88 File Offset: 0x00442188
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

		// Token: 0x0600F99F RID: 63903 RVA: 0x00443DFC File Offset: 0x004421FC
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F9A0 RID: 63904 RVA: 0x00443E30 File Offset: 0x00442230
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

		// Token: 0x04009BA5 RID: 39845
		[SerializeField]
		private Text mTaskName;

		// Token: 0x04009BA6 RID: 39846
		[SerializeField]
		private Text mIntegralCount;

		// Token: 0x04009BA7 RID: 39847
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x04009BA8 RID: 39848
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009BA9 RID: 39849
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x04009BAA RID: 39850
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x04009BAB RID: 39851
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009BAC RID: 39852
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009BAD RID: 39853
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009BAE RID: 39854
		private bool mIsLeftMinus0;

		// Token: 0x04009BAF RID: 39855
		private int totalScore;

		// Token: 0x04009BB0 RID: 39856
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
