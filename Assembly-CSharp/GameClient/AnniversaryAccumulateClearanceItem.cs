using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x0200180E RID: 6158
	public class AnniversaryAccumulateClearanceItem : ActivityItemBase
	{
		// Token: 0x0600F2A5 RID: 62117 RVA: 0x00417350 File Offset: 0x00415750
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mCanTakeReward.CustomActive(false);
			this.mButtonUnFinish.CustomActive(false);
			this.mHasTakenReward.CustomActive(false);
			if (this.isLeftMinusThan0)
			{
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mButtonUnFinish.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mCanTakeReward.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mHasTakenReward.CustomActive(true);
					break;
				}
			}
			else
			{
				this.mHasTakenReward.CustomActive(true);
			}
		}

		// Token: 0x0600F2A6 RID: 62118 RVA: 0x00417400 File Offset: 0x00415800
		public override void Dispose()
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
			this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonTakeReward.SafeRemoveOnClickListener(new UnityAction(this._OnSendMsg));
			base.UnRegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F2A7 RID: 62119 RVA: 0x0041749C File Offset: 0x0041589C
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					ComItem comItem = ComItemManager.Create(this.mRewardItemRoot.gameObject);
					if (comItem != null)
					{
						ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
						itemData.Count = (int)data.AwardDataList[i].num;
						ComItem comItem2 = comItem;
						ItemData item = itemData;
						if (AnniversaryAccumulateClearanceItem.<>f__mg$cache0 == null)
						{
							AnniversaryAccumulateClearanceItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, AnniversaryAccumulateClearanceItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mData = data;
			this.mAccountNumTxt.CustomActive(false);
			this.mTextDescription.CustomActive(false);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnSendMsg));
			base.RegisterAccountData(new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			base.OnRequsetAccountData(this.mData);
		}

		// Token: 0x0600F2A8 RID: 62120 RVA: 0x004175EE File Offset: 0x004159EE
		private void _OnSendMsg()
		{
			if (this.mData != null)
			{
				base.OnRequsetAccountData(this.mData);
			}
		}

		// Token: 0x0600F2A9 RID: 62121 RVA: 0x00417607 File Offset: 0x00415A07
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState();
			}
		}

		// Token: 0x0600F2AA RID: 62122 RVA: 0x00417638 File Offset: 0x00415A38
		private void ShowHaveUsedNumState()
		{
			if (this.mData != null)
			{
				int accountDailySubmitLimit = this.mData.AccountDailySubmitLimit;
				int accountTotalSubmitLimit = this.mData.AccountTotalSubmitLimit;
				int num = 0;
				if (accountDailySubmitLimit > 0)
				{
					num = accountDailySubmitLimit;
				}
				if (accountTotalSubmitLimit > 0)
				{
					num = accountTotalSubmitLimit;
				}
				if (num > 0)
				{
					int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					int num2 = num - activityConunter;
					if (num2 < 0)
					{
						num2 = 0;
					}
					if (this.mAccountNumTxt != null)
					{
						this.mAccountNumTxt.CustomActive(true);
						this.mAccountNumTxt.text = string.Format(TR.Value("limitactivity_dailyreward_tip", num2, num), new object[0]);
					}
					if (num2 <= 0)
					{
						this.isLeftMinusThan0 = false;
						this.mHasTakenReward.CustomActive(true);
						this.mCanTakeReward.CustomActive(false);
						this.mButtonUnFinish.CustomActive(false);
						this.mButtonUnFinish.CustomActive(false);
					}
					this.ShowtxtDescription(this.mData, num2 <= 0);
				}
				else
				{
					this.ShowtxtDescription(this.mData, true);
				}
			}
		}

		// Token: 0x0600F2AB RID: 62123 RVA: 0x00417760 File Offset: 0x00415B60
		private void ShowtxtDescription(ILimitTimeActivityTaskDataModel data, bool isHideProgress)
		{
			if (this.mData != null)
			{
				this.mTextDescription.CustomActive(true);
				if (!isHideProgress)
				{
					this.mTextDescription.text = string.Format(TR.Value("activity_accumulate_exchange_content"), this.mData.Desc, string.Format(TR.Value("activity_accumulate_exchange_tips"), this.mData.DoneNum, this.mData.TotalNum));
				}
				else
				{
					this.mTextDescription.text = string.Format("{0}", this.mData.Desc);
				}
			}
		}

		// Token: 0x04009515 RID: 38165
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009516 RID: 38166
		[SerializeField]
		private Text mAccountNumTxt;

		// Token: 0x04009517 RID: 38167
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009518 RID: 38168
		[SerializeField]
		private Button mButtonUnFinish;

		// Token: 0x04009519 RID: 38169
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x0400951A RID: 38170
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x0400951B RID: 38171
		[SerializeField]
		private GameObject mUnFinish;

		// Token: 0x0400951C RID: 38172
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x0400951D RID: 38173
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x0400951E RID: 38174
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x0400951F RID: 38175
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x04009520 RID: 38176
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009521 RID: 38177
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009522 RID: 38178
		private bool isLeftMinusThan0 = true;

		// Token: 0x04009523 RID: 38179
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
