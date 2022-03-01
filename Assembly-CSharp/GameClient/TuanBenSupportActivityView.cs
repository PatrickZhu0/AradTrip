using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001819 RID: 6169
	public class TuanBenSupportActivityView : MonoBehaviour, IActivityView, IDisposable
	{
		// Token: 0x0600F30C RID: 62220 RVA: 0x0041A97C File Offset: 0x00418D7C
		public void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model.Id == 0U)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mModel = model;
			this.mIsLeftMinus0 = false;
			this.mOnItemClick = onItemClick;
			this.mTakeRewardBtn.SafeAddOnClickListener(new UnityAction(this._OnTakeRewardBtnClick));
			this.mTimeTxt.SafeSetText(Function.GetTimeWithMonthDayHour((int)model.StartTime, (int)model.EndTime));
			this.mRuleDesTxt.SafeSetText(model.RuleDesc);
			this.UpdateData(model);
			this._InitItems();
			this.ShowWeeklyUseNumState(this.mTaskData);
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			if (this.mTaskData != null && this.mTaskData.AccountWeeklySubmitLimit > 0)
			{
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mTaskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK);
			}
		}

		// Token: 0x0600F30D RID: 62221 RVA: 0x0041AA64 File Offset: 0x00418E64
		public void UpdateData(ILimitTimeActivityModel data)
		{
			if (data.Id == 0U || data.TaskDatas == null || data.TaskDatas.Count < 1)
			{
				return;
			}
			this.mHaveTakenGo.CustomActive(false);
			this.mNotTakenGo.CustomActive(false);
			this.mCanTakenGo.CustomActive(false);
			this.mTaskData = data.TaskDatas[0];
			if (this.mTaskData == null)
			{
				return;
			}
			if (!this.mIsLeftMinus0)
			{
				this.UpdateRoleWeeklyLimitDesc(1);
				OpActTaskState state = this.mTaskData.State;
				if (state != OpActTaskState.OATS_UNFINISH)
				{
					if (state != OpActTaskState.OATS_FINISHED)
					{
						if (state == OpActTaskState.OATS_OVER)
						{
							this.mHaveTakenGo.CustomActive(true);
							this.UpdateRoleWeeklyLimitDesc(0);
						}
					}
					else
					{
						this.mCanTakenGo.CustomActive(true);
					}
				}
				else
				{
					this.mNotTakenGo.CustomActive(true);
				}
			}
			else
			{
				this.mHaveTakenGo.CustomActive(true);
				this.mNotTakenGo.CustomActive(false);
				this.mCanTakenGo.CustomActive(false);
			}
		}

		// Token: 0x0600F30E RID: 62222 RVA: 0x0041AB78 File Offset: 0x00418F78
		public void Close()
		{
			this.mIsLeftMinus0 = false;
			this.mTaskData = null;
			this.mOnItemClick = null;
			this.mTakeRewardBtn.SafeRemoveOnClickListener(new UnityAction(this._OnTakeRewardBtnClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			Object.Destroy(base.gameObject);
		}

		// Token: 0x0600F30F RID: 62223 RVA: 0x0041ABD7 File Offset: 0x00418FD7
		public void Show()
		{
			base.gameObject.CustomActive(true);
		}

		// Token: 0x0600F310 RID: 62224 RVA: 0x0041ABE5 File Offset: 0x00418FE5
		public void Hide()
		{
			base.gameObject.CustomActive(false);
		}

		// Token: 0x0600F311 RID: 62225 RVA: 0x0041ABF3 File Offset: 0x00418FF3
		public void Dispose()
		{
		}

		// Token: 0x0600F312 RID: 62226 RVA: 0x0041ABF8 File Offset: 0x00418FF8
		private void _OnTakeRewardBtnClick()
		{
			if (this.mOnItemClick != null && this.mTaskData != null)
			{
				this.mOnItemClick((int)this.mTaskData.DataId, 0, 0UL);
				if (this.mTaskData.AccountWeeklySubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mTaskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK);
				}
			}
		}

		// Token: 0x0600F313 RID: 62227 RVA: 0x0041AC60 File Offset: 0x00419060
		private void _InitItems()
		{
			if (this.mTaskData != null && this.mTaskData.AwardDataList != null && this.mTaskData.AwardDataList.Count >= 1)
			{
				OpTaskReward opTaskReward = this.mTaskData.AwardDataList[0];
				if (opTaskReward == null)
				{
					return;
				}
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, 0);
				if (itemData == null)
				{
					return;
				}
				itemData.Count = (int)opTaskReward.num;
				if (this.mItemName != null)
				{
					this.mItemName.text = itemData.GetColorName(string.Empty, false);
				}
				if (this.mItemBackGround != null)
				{
					ETCImageLoader.LoadSprite(ref this.mItemBackGround, itemData.GetQualityInfo().Background, true);
				}
				if (this.mItemIcon != null)
				{
					ETCImageLoader.LoadSprite(ref this.mItemIcon, itemData.Icon, true);
				}
				if (this.mItemCount != null && itemData.Count > 1)
				{
					this.mItemCount.text = itemData.Count.ToString();
				}
				if (this.mItemIconBtn != null)
				{
					this.mItemIconBtn.onClick.RemoveAllListeners();
					this.mItemIconBtn.onClick.AddListener(delegate()
					{
						DataManager<ItemTipManager>.GetInstance().ShowTip(itemData, null, 4, true, false, true);
					});
				}
			}
		}

		// Token: 0x0600F314 RID: 62228 RVA: 0x0041ADF2 File Offset: 0x004191F2
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mTaskData != null && (uint)uiEvent.Param1 == this.mTaskData.DataId)
			{
				this.ShowWeeklyUseNumState(this.mTaskData);
			}
		}

		// Token: 0x0600F315 RID: 62229 RVA: 0x0041AE26 File Offset: 0x00419226
		private void UpdateRoleWeeklyLimitDesc(int num)
		{
			if (this.mRoleWeeklyLimitDesc != null)
			{
				this.mRoleWeeklyLimitDesc.text = string.Format(this.mRoleWeeklyDesc, num);
			}
		}

		// Token: 0x0600F316 RID: 62230 RVA: 0x0041AE58 File Offset: 0x00419258
		private void ShowWeeklyUseNumState(ILimitTimeActivityTaskDataModel data)
		{
			this.mIsLeftMinus0 = false;
			if (data != null)
			{
				int num = 0;
				int num2 = 0;
				if (data.AccountWeeklySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(data.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_SUBMIT_TASK);
					num = data.AccountWeeklySubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0 && num > 0)
				{
					this.mHaveTakenGo.CustomActive(true);
					this.mNotTakenGo.CustomActive(false);
					this.mCanTakenGo.CustomActive(false);
					this.mIsLeftMinus0 = true;
					num3 = 0;
					this.UpdateRoleWeeklyLimitDesc(0);
				}
				if (this.mAccountWeeklyLimitDesc != null)
				{
					this.mAccountWeeklyLimitDesc.text = string.Format(this.mWeeklyDesc, num3, num);
				}
				this.UpdateData(this.mModel);
			}
		}

		// Token: 0x04009581 RID: 38273
		[SerializeField]
		private GameObject mHaveTakenGo;

		// Token: 0x04009582 RID: 38274
		[SerializeField]
		private GameObject mNotTakenGo;

		// Token: 0x04009583 RID: 38275
		[SerializeField]
		private GameObject mCanTakenGo;

		// Token: 0x04009584 RID: 38276
		[SerializeField]
		private Button mTakeRewardBtn;

		// Token: 0x04009585 RID: 38277
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009586 RID: 38278
		[SerializeField]
		private Text mRuleDesTxt;

		// Token: 0x04009587 RID: 38279
		[SerializeField]
		private Text mItemName;

		// Token: 0x04009588 RID: 38280
		[SerializeField]
		private Text mItemCount;

		// Token: 0x04009589 RID: 38281
		[SerializeField]
		private Image mItemBackGround;

		// Token: 0x0400958A RID: 38282
		[SerializeField]
		private Image mItemIcon;

		// Token: 0x0400958B RID: 38283
		[SerializeField]
		private Button mItemIconBtn;

		// Token: 0x0400958C RID: 38284
		[SerializeField]
		private Text mAccountWeeklyLimitDesc;

		// Token: 0x0400958D RID: 38285
		[SerializeField]
		private Text mRoleWeeklyLimitDesc;

		// Token: 0x0400958E RID: 38286
		[SerializeField]
		private string mWeeklyDesc = "账号每周限领次数:{0}/{1}";

		// Token: 0x0400958F RID: 38287
		[SerializeField]
		private string mRoleWeeklyDesc = "角色每周限领次数:{0}/1";

		// Token: 0x04009590 RID: 38288
		private ActivityItemBase.OnActivityItemClick<int> mOnItemClick;

		// Token: 0x04009591 RID: 38289
		private ILimitTimeActivityTaskDataModel mTaskData;

		// Token: 0x04009592 RID: 38290
		private bool mIsLeftMinus0;

		// Token: 0x04009593 RID: 38291
		private ILimitTimeActivityModel mModel;
	}
}
