using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018F3 RID: 6387
	public class FeedbackGiftActivityItem : ActivityItemBase
	{
		// Token: 0x0600F90B RID: 63755 RVA: 0x0043E3DC File Offset: 0x0043C7DC
		public sealed override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.mUnFinishBtn.CustomActive(false);
				this.mFinishBtn.CustomActive(false);
				this.mOverBtn.CustomActive(false);
				this.mOverText.CustomActive(false);
				this.mGray.enabled = false;
				switch (data.State)
				{
				case OpActTaskState.OATS_UNFINISH:
					this.mUnFinishBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_FINISHED:
					this.mFinishBtn.CustomActive(true);
					break;
				case OpActTaskState.OATS_OVER:
					this.mOverBtn.CustomActive(true);
					this.mOverText.CustomActive(true);
					this.mGray.enabled = true;
					break;
				}
			}
			else
			{
				this.mOverBtn.CustomActive(true);
				this.mOverText.CustomActive(true);
				this.mGray.enabled = true;
				this.mUnFinishBtn.CustomActive(false);
				this.mFinishBtn.CustomActive(false);
			}
		}

		// Token: 0x0600F90C RID: 63756 RVA: 0x0043E4E9 File Offset: 0x0043C8E9
		public sealed override void Dispose()
		{
			base.Dispose();
			this.mIsLeftMinus0 = false;
			this.itemData = null;
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F90D RID: 63757 RVA: 0x0043E51C File Offset: 0x0043C91C
		protected sealed override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mData = data;
			if (this.mData.AwardDataList.Count > 0)
			{
				this.itemData = ItemDataManager.CreateItemDataFromTable((int)this.mData.AwardDataList[0].id, 100, 0);
				if (this.mItemBackground != null)
				{
					ETCImageLoader.LoadSprite(ref this.mItemBackground, this.itemData.GetQualityInfo().Background, true);
				}
				if (this.mItemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mItemIcon, this.itemData.Icon, true);
				}
				this.mItemNum.SafeSetText(this.mData.AwardDataList[0].num.ToString());
			}
			this.mTaskCount.SafeSetText(string.Format("{0}积分", this.mData.TotalNum));
			this.mUnFinishBtn.SafeRemoveAllListener();
			this.mUnFinishBtn.SafeAddOnClickListener(new UnityAction(this.OmItemShowTips));
			this.mFinishBtn.SafeRemoveAllListener();
			this.mFinishBtn.SafeAddOnClickListener(new UnityAction(this._OnMyItemClick));
			this.mOverBtn.SafeRemoveAllListener();
			this.mOverBtn.SafeAddOnClickListener(new UnityAction(this.OmItemShowTips));
			this.ShowHaveUsedNumState(data);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
		}

		// Token: 0x0600F90E RID: 63758 RVA: 0x0043E6A1 File Offset: 0x0043CAA1
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mData != null && (uint)uiEvent.Param1 == this.mData.DataId)
			{
				this.ShowHaveUsedNumState(this.mData);
			}
		}

		// Token: 0x0600F90F RID: 63759 RVA: 0x0043E6D5 File Offset: 0x0043CAD5
		private void OmItemShowTips()
		{
			DataManager<ItemTipManager>.GetInstance().ShowTip(this.itemData, null, 4, true, false, true);
		}

		// Token: 0x0600F910 RID: 63760 RVA: 0x0043E6EC File Offset: 0x0043CAEC
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

		// Token: 0x0600F911 RID: 63761 RVA: 0x0043E760 File Offset: 0x0043CB60
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
					this.mOverBtn.CustomActive(true);
					this.mFinishBtn.CustomActive(false);
					this.mUnFinishBtn.CustomActive(false);
					this.mIsLeftMinus0 = true;
				}
			}
		}

		// Token: 0x04009AA7 RID: 39591
		[SerializeField]
		private Button mUnFinishBtn;

		// Token: 0x04009AA8 RID: 39592
		[SerializeField]
		private Button mFinishBtn;

		// Token: 0x04009AA9 RID: 39593
		[SerializeField]
		private Button mOverBtn;

		// Token: 0x04009AAA RID: 39594
		[SerializeField]
		private Image mItemBackground;

		// Token: 0x04009AAB RID: 39595
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x04009AAC RID: 39596
		[SerializeField]
		private Text mItemNum;

		// Token: 0x04009AAD RID: 39597
		[SerializeField]
		private Text mTaskCount;

		// Token: 0x04009AAE RID: 39598
		[SerializeField]
		private UIGray mGray;

		// Token: 0x04009AAF RID: 39599
		[SerializeField]
		private GameObject mOverText;

		// Token: 0x04009AB0 RID: 39600
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009AB1 RID: 39601
		private bool mIsLeftMinus0;

		// Token: 0x04009AB2 RID: 39602
		private ItemData itemData;
	}
}
