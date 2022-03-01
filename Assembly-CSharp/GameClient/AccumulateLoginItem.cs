using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018D3 RID: 6355
	public class AccumulateLoginItem : ActivityItemBase
	{
		// Token: 0x0600F822 RID: 63522 RVA: 0x00435D38 File Offset: 0x00434138
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.mCanTakeReward.CustomActive(false);
				this.mCount.CustomActive(false);
				this.mHasTakenReward.CustomActive(false);
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mCount.CustomActive(true);
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
				this.mCanTakeReward.CustomActive(false);
				this.mCount.CustomActive(false);
				this.mHasTakenReward.CustomActive(true);
			}
		}

		// Token: 0x0600F823 RID: 63523 RVA: 0x00435E00 File Offset: 0x00434200
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
		}

		// Token: 0x0600F824 RID: 63524 RVA: 0x00435E70 File Offset: 0x00434270
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
						if (AccumulateLoginItem.<>f__mg$cache0 == null)
						{
							AccumulateLoginItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
						}
						comItem2.Setup(item, AccumulateLoginItem.<>f__mg$cache0);
						this.mComItems.Add(comItem);
						(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
					}
				}
				this.mAwardsScrollRect.enabled = (data.AwardDataList.Count > this.mScrollCount);
			}
			this.mTextDescription.SafeSetText(data.Desc);
			this.mButtonTakeReward.SafeAddOnClickListener(new UnityAction(this._OnMyItemClick));
			this.mCount.text = string.Format(TR.Value("activity_accumulate_login_tips"), data.DoneNum, data.TotalNum);
			this.mData = data;
			this.ShowHaveUsedNumState(data);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F825 RID: 63525 RVA: 0x00435FD8 File Offset: 0x004343D8
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

		// Token: 0x0600F826 RID: 63526 RVA: 0x0043604C File Offset: 0x0043444C
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F827 RID: 63527 RVA: 0x00436080 File Offset: 0x00434480
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
					this.mCanTakeReward.CustomActive(false);
					this.mCount.CustomActive(false);
					this.mHasTakenReward.CustomActive(true);
					this.mIsLeftMinus0 = true;
					num3 = 0;
				}
				this.mAccountNumTxt.CustomActive(num > 0);
				this.mAccountNumTxt.SafeSetText(string.Format(TR.Value("ConsumeRebate_AccountLimt_Content"), num3, num));
			}
		}

		// Token: 0x04009942 RID: 39234
		[SerializeField]
		private Text mTextDescription;

		// Token: 0x04009943 RID: 39235
		[SerializeField]
		private RectTransform mRewardItemRoot;

		// Token: 0x04009944 RID: 39236
		[SerializeField]
		private Button mButtonTakeReward;

		// Token: 0x04009945 RID: 39237
		[SerializeField]
		private GameObject mHasTakenReward;

		// Token: 0x04009946 RID: 39238
		[SerializeField]
		private GameObject mUnTakeReward;

		// Token: 0x04009947 RID: 39239
		[SerializeField]
		private GameObject mCanTakeReward;

		// Token: 0x04009948 RID: 39240
		[SerializeField]
		private ScrollRect mAwardsScrollRect;

		// Token: 0x04009949 RID: 39241
		[SerializeField]
		private Text mCount;

		// Token: 0x0400994A RID: 39242
		[SerializeField]
		private Text mAccountNumTxt;

		// Token: 0x0400994B RID: 39243
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x0400994C RID: 39244
		[SerializeField]
		private int mScrollCount = 5;

		// Token: 0x0400994D RID: 39245
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x0400994E RID: 39246
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x0400994F RID: 39247
		private bool mIsLeftMinus0;

		// Token: 0x04009950 RID: 39248
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
