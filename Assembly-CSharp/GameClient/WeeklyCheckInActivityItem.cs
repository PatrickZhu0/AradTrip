using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001912 RID: 6418
	public class WeeklyCheckInActivityItem : ActivityItemBase
	{
		// Token: 0x0600F9DF RID: 63967 RVA: 0x00445CC8 File Offset: 0x004440C8
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

		// Token: 0x0600F9E0 RID: 63968 RVA: 0x00445D90 File Offset: 0x00444190
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
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F9E1 RID: 63969 RVA: 0x00445E0C File Offset: 0x0044420C
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.ParamNums.Count > 0)
			{
				if (data.ParamNums[0] == 1U)
				{
					if (data.ParamNums2.Count > 0)
					{
						int count = DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.TOTAL_WEEKLY_NUM);
						if (this.mTaskName != null)
						{
							this.mTaskName.text = data.Desc + string.Format("({0}/{1})", count, data.ParamNums2[0]);
						}
					}
				}
				else if (this.mTaskName != null)
				{
					this.mTaskName.text = data.Desc + string.Format("({0}/{1})", data.DoneNum, data.TotalNum);
				}
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
						if (WeeklyCheckInActivityItem.<>f__mg$cache0 == null)
						{
							WeeklyCheckInActivityItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, WeeklyCheckInActivityItem.<>f__mg$cache0);
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

		// Token: 0x0600F9E2 RID: 63970 RVA: 0x00446000 File Offset: 0x00444400
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

		// Token: 0x0600F9E3 RID: 63971 RVA: 0x00446074 File Offset: 0x00444474
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F9E4 RID: 63972 RVA: 0x004460A8 File Offset: 0x004444A8
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

		// Token: 0x0600F9E5 RID: 63973 RVA: 0x00446158 File Offset: 0x00444558
		public void SetBackground(int index)
		{
			if (this.mImg1 != null && this.mImg2 != null)
			{
				this.mImg1.CustomActive(index % 2 == 0);
				this.mImg2.CustomActive(index % 2 != 0);
			}
		}

		// Token: 0x04009C09 RID: 39945
		[SerializeField]
		private Text mTaskName;

		// Token: 0x04009C0A RID: 39946
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009C0B RID: 39947
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009C0C RID: 39948
		[SerializeField]
		private GameObject mReceiveGrayItemGo;

		// Token: 0x04009C0D RID: 39949
		[SerializeField]
		private GameObject mNotReachItemGo;

		// Token: 0x04009C0E RID: 39950
		[SerializeField]
		private GameObject mItemParent;

		// Token: 0x04009C0F RID: 39951
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009C10 RID: 39952
		[SerializeField]
		private GameObject mImg1;

		// Token: 0x04009C11 RID: 39953
		[SerializeField]
		private GameObject mImg2;

		// Token: 0x04009C12 RID: 39954
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009C13 RID: 39955
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009C14 RID: 39956
		private bool mIsLeftMinus0;

		// Token: 0x04009C15 RID: 39957
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
