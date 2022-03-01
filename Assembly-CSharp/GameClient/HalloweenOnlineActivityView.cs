using System;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001896 RID: 6294
	public class HalloweenOnlineActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F632 RID: 63026 RVA: 0x00426FF4 File Offset: 0x004253F4
		public sealed override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			this.mOnItemClick = onItemClick;
			this.mTextLotteryCount.SafeSetText(string.Format(TR.Value("HalloweenRollActivity_Lettety_Count"), DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_ONLINE_TIME)));
			if (this.mActiveUpdate != null)
			{
				this.mActiveUpdate.SetTotlaNum((int)model.Param);
			}
			this.mTimeTxt.SafeSetText(string.Format("{0}~{1}", this._TransTimeStampToStr(model.StartTime), this._TransTimeStampToStr(model.EndTime)));
			this.mRuleTxt.SafeSetText(model.RuleDesc.Replace('|', '\n'));
			this.FindPetTaskData(model);
			if (this.mPetTaskData != null && this.mPetTaskData.AwardDataList.Count > 0)
			{
				ComItem comItem = ComItemManager.Create(this.mPetItemRoot);
				if (comItem != null)
				{
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.mPetTaskData.AwardDataList[0].id, 100, 0);
					itemData.Count = (int)this.mPetTaskData.AwardDataList[0].num;
					ComItem comItem2 = comItem;
					ItemData item = itemData;
					if (HalloweenOnlineActivityView.<>f__mg$cache0 == null)
					{
						HalloweenOnlineActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem2.Setup(item, HalloweenOnlineActivityView.<>f__mg$cache0);
					(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
				}
				this.mTotalDaysTxt.SafeSetText(string.Format(TR.Value("HalloweenRollActivity_TotalDays"), this.mPetTaskData.DoneNum, this.mPetTaskData.TotalNum));
				this.ShowHaveUsedNumState();
			}
			if (this.mActivitiyTurnTableRoot != null)
			{
				GameObject gameObject = Singleton<AssetLoader>.GetInstance().LoadResAsGameObject(this.mActivityTurnTablePath, true, 0U);
				if (gameObject != null)
				{
					gameObject.transform.SetParent(this.mActivitiyTurnTableRoot.transform);
					gameObject.transform.localPosition = Vector3.zero;
					gameObject.transform.localScale = Vector3.one;
					ActivityTurnTable component = gameObject.GetComponent<ActivityTurnTable>();
					if (component != null)
					{
						component.Init(10006);
					}
				}
				else
				{
					Logger.LogError("加载活动转盘预制体出错");
				}
			}
			this.mGetPetRewardBtn.SafeAddOnClickListener(new UnityAction(this._OnGetRewardBtnClick));
			this.mReviewPetBtn.SafeAddOnClickListener(new UnityAction(this._OnReviewPetBtnClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnActivityCounterUpdate));
			this.UpdateData(model);
		}

		// Token: 0x0600F633 RID: 63027 RVA: 0x00427278 File Offset: 0x00425678
		public override void UpdateData(ILimitTimeActivityModel data)
		{
			if (!this.mIsLeftMinus0)
			{
				this.FindPetTaskData(data);
				if (this.mPetTaskData != null)
				{
					switch (this.mPetTaskData.State)
					{
					case OpActTaskState.OATS_INIT:
					case OpActTaskState.OATS_UNFINISH:
						if (this.mGray != null)
						{
							this.mGray.enabled = true;
						}
						if (this.mGetPetRewardBtn != null)
						{
							this.mGetPetRewardBtn.interactable = false;
						}
						break;
					case OpActTaskState.OATS_FINISHED:
						if (this.mGray != null)
						{
							this.mGray.enabled = false;
						}
						if (this.mGetPetRewardBtn != null)
						{
							this.mGetPetRewardBtn.interactable = true;
						}
						break;
					case OpActTaskState.OATS_OVER:
						if (this.mGray != null)
						{
							this.mGray.enabled = true;
						}
						if (this.mGetPetRewardBtn != null)
						{
							this.mGetPetRewardBtn.interactable = false;
						}
						break;
					}
				}
			}
			else if (this.mGray != null)
			{
				this.mGray.enabled = true;
			}
		}

		// Token: 0x0600F634 RID: 63028 RVA: 0x004273B0 File Offset: 0x004257B0
		public override void Dispose()
		{
			base.Dispose();
			this.mIsLeftMinus0 = false;
			this.mPetTaskData = null;
			this.mGetPetRewardBtn.SafeRemoveOnClickListener(new UnityAction(this._OnGetRewardBtnClick));
			this.mReviewPetBtn.SafeRemoveOnClickListener(new UnityAction(this._OnReviewPetBtnClick));
		}

		// Token: 0x0600F635 RID: 63029 RVA: 0x004273FF File Offset: 0x004257FF
		public void UpdateLotteryCount()
		{
			this.mTextLotteryCount.SafeSetText(string.Format(TR.Value("HalloweenRollActivity_Lettety_Count"), DataManager<CountDataManager>.GetInstance().GetCount(CounterKeys.COUNTER_LOTTERY_ONLINE_TIME)));
		}

		// Token: 0x0600F636 RID: 63030 RVA: 0x00427430 File Offset: 0x00425830
		private void _OnReviewPetBtnClick()
		{
			if (this.mPetTaskData != null && this.mPetTaskData.AwardDataList.Count > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)this.mPetTaskData.AwardDataList[0].id, 100, 0);
				if (itemData != null)
				{
					PreViewItemData preViewItemData = new PreViewItemData();
					preViewItemData.itemId = itemData.TableID;
					PreViewDataModel preViewDataModel = new PreViewDataModel();
					preViewDataModel.preViewItemList.Add(preViewItemData);
					Singleton<ClientSystemManager>.GetInstance().OpenFrame<PreviewModelFrame>(FrameLayer.Middle, preViewDataModel, string.Empty);
				}
			}
		}

		// Token: 0x0600F637 RID: 63031 RVA: 0x004274BC File Offset: 0x004258BC
		private void _OnGetRewardBtnClick()
		{
			if (this.mPetTaskData != null)
			{
				this.mOnItemClick((int)this.mPetTaskData.DataId, 0, 0UL);
				if (this.mPetTaskData.AccountDailySubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mPetTaskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
				}
				if (this.mPetTaskData.AccountTotalSubmitLimit > 0)
				{
					DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mPetTaskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
				}
			}
		}

		// Token: 0x0600F638 RID: 63032 RVA: 0x00427544 File Offset: 0x00425944
		private void FindPetTaskData(ILimitTimeActivityModel model)
		{
			int num = 0;
			if (model != null && model.ParamArray != null && model.ParamArray.Length > 0)
			{
				num = (int)model.ParamArray[0];
			}
			for (int i = 0; i < model.TaskDatas.Count; i++)
			{
				ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = model.TaskDatas[i];
				if (limitTimeActivityTaskDataModel != null)
				{
					if ((ulong)limitTimeActivityTaskDataModel.DataId == (ulong)((long)num))
					{
						this.mPetTaskData = limitTimeActivityTaskDataModel;
						break;
					}
				}
			}
		}

		// Token: 0x0600F639 RID: 63033 RVA: 0x004275C9 File Offset: 0x004259C9
		private void _OnActivityCounterUpdate(UIEvent uiEvent)
		{
			if (this.mPetTaskData != null && (uint)uiEvent.Param1 == this.mPetTaskData.DataId)
			{
				this.ShowHaveUsedNumState();
			}
		}

		// Token: 0x0600F63A RID: 63034 RVA: 0x004275F8 File Offset: 0x004259F8
		private void ShowHaveUsedNumState()
		{
			if (this.mPetTaskData != null)
			{
				int num = 0;
				int num2 = 0;
				if (this.mPetTaskData.AccountDailySubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mPetTaskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_DAILY_SUBMIT_TASK);
					num = this.mPetTaskData.AccountDailySubmitLimit;
				}
				else if (this.mPetTaskData.AccountTotalSubmitLimit > 0)
				{
					num2 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(this.mPetTaskData.DataId, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_TOTAL_SUBMIT_TASK);
					num = this.mPetTaskData.AccountTotalSubmitLimit;
				}
				int num3 = num - num2;
				if (num3 <= 0 && num > 0)
				{
					if (this.mGray != null)
					{
						this.mGray.enabled = true;
					}
					if (this.mGetPetRewardBtn != null)
					{
						this.mGetPetRewardBtn.interactable = false;
					}
					this.mIsLeftMinus0 = true;
					num3 = 0;
				}
				this.mAccountLimitTxt.CustomActive(num > 0);
				this.mAccountLimitTxt.SafeSetText(string.Format(TR.Value("HalloweenRollActivity_AccountTip"), num3, num));
			}
		}

		// Token: 0x0600F63B RID: 63035 RVA: 0x00427714 File Offset: 0x00425B14
		private string _TransTimeStampToStr(uint timeStamp)
		{
			DateTime dateTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1)).AddSeconds(timeStamp);
			return string.Format("{0}年{1}月{2}日{3:HH:mm}", new object[]
			{
				dateTime.Year,
				dateTime.Month,
				dateTime.Day,
				dateTime
			});
		}

		// Token: 0x04009703 RID: 38659
		[SerializeField]
		private Text mTextLotteryCount;

		// Token: 0x04009704 RID: 38660
		[SerializeField]
		private ActiveUpdate mActiveUpdate;

		// Token: 0x04009705 RID: 38661
		[SerializeField]
		private Text mTimeTxt;

		// Token: 0x04009706 RID: 38662
		[SerializeField]
		private Text mRuleTxt;

		// Token: 0x04009707 RID: 38663
		[SerializeField]
		private Text mTotalDaysTxt;

		// Token: 0x04009708 RID: 38664
		[SerializeField]
		private GameObject mPetItemRoot;

		// Token: 0x04009709 RID: 38665
		[SerializeField]
		private Text mAccountLimitTxt;

		// Token: 0x0400970A RID: 38666
		[SerializeField]
		private Button mReviewPetBtn;

		// Token: 0x0400970B RID: 38667
		[SerializeField]
		private Button mGetPetRewardBtn;

		// Token: 0x0400970C RID: 38668
		[SerializeField]
		private UIGray mGray;

		// Token: 0x0400970D RID: 38669
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x0400970E RID: 38670
		[SerializeField]
		private GameObject mActivitiyTurnTableRoot;

		// Token: 0x0400970F RID: 38671
		private string mActivityTurnTablePath = "UIFlatten/Prefabs/OperateActivity/LimitTime/Activities/ActivityTurnTable";

		// Token: 0x04009710 RID: 38672
		private ILimitTimeActivityTaskDataModel mPetTaskData;

		// Token: 0x04009711 RID: 38673
		private bool mIsLeftMinus0;

		// Token: 0x04009712 RID: 38674
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
