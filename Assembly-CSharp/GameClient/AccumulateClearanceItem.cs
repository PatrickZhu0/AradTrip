using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018D2 RID: 6354
	public class AccumulateClearanceItem : ActivityItemBase
	{
		// Token: 0x0600F81A RID: 63514 RVA: 0x00435878 File Offset: 0x00433C78
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			this.mCanTakeReward.CustomActive(false);
			this.mButtonUnFinish.CustomActive(false);
			this.mHasTakenReward.CustomActive(false);
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

		// Token: 0x0600F81B RID: 63515 RVA: 0x0043590C File Offset: 0x00433D0C
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

		// Token: 0x0600F81C RID: 63516 RVA: 0x004359A8 File Offset: 0x00433DA8
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
						if (AccumulateClearanceItem.<>f__mg$cache0 == null)
						{
							AccumulateClearanceItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, AccumulateClearanceItem.<>f__mg$cache0);
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

		// Token: 0x0600F81D RID: 63517 RVA: 0x00435AFA File Offset: 0x00433EFA
		private void _OnSendMsg()
		{
			if (this.mData != null)
			{
				base.OnRequsetAccountData(this.mData);
			}
		}

		// Token: 0x0600F81E RID: 63518 RVA: 0x00435B13 File Offset: 0x00433F13
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState();
			}
		}

		// Token: 0x0600F81F RID: 63519 RVA: 0x00435B44 File Offset: 0x00433F44
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

		// Token: 0x0600F820 RID: 63520 RVA: 0x00435C64 File Offset: 0x00434064
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

		// Token: 0x04009934 RID: 39220
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009935 RID: 39221
		[SerializeField]
		private Text mAccountNumTxt;

		// Token: 0x04009936 RID: 39222
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009937 RID: 39223
		[SerializeField]
		private Button mButtonUnFinish;

		// Token: 0x04009938 RID: 39224
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009939 RID: 39225
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x0400993A RID: 39226
		[SerializeField]
		private GameObject mUnFinish;

		// Token: 0x0400993B RID: 39227
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x0400993C RID: 39228
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x0400993D RID: 39229
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x0400993E RID: 39230
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x0400993F RID: 39231
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009940 RID: 39232
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009941 RID: 39233
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
