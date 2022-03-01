using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018AB RID: 6315
	public class QiXiQueQiaoActivityView : LimitTimeActivityViewCommon
	{
		// Token: 0x0600F6EC RID: 63212 RVA: 0x0042C174 File Offset: 0x0042A574
		public override void Init(ILimitTimeActivityModel model, ActivityItemBase.OnActivityItemClick<int> onItemClick)
		{
			if (model == null)
			{
				Logger.LogError("LimitTimeActivityModel data is empty");
				return;
			}
			this.mOnItemClick = onItemClick;
			this._InitItems(model);
			this.UpdateData(model);
			this.mButtonTakeAward.SafeAddOnClickListener(new UnityAction(this._OnButtonTakeAwardClick));
			this.mButtonTryOn.SafeAddOnClickListener(new UnityAction(this._OnButtonTryOnClick));
			this.mButtonFinalReward.SafeAddOnClickListener(new UnityAction(this._OnButtonFinalRewardClick));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			if (model.TaskDatas != null && model.TaskDatas.Count > 0)
			{
				List<OpTaskReward> awardDataList = model.TaskDatas[model.TaskDatas.Count - 1].AwardDataList;
				if (awardDataList != null && awardDataList.Count > 0)
				{
					this.mLastGiftPackItemId = (int)awardDataList[0].id;
					DataManager<GiftPackDataManager>.GetInstance().GetGiftPackItem(this.mLastGiftPackItemId);
				}
			}
			if (this.mRoot != null)
			{
				if (this.mItemComItem != null)
				{
					ComItemManager.Destroy(this.mItemComItem);
					this.mItemComItem = null;
				}
				OpTaskReward opTaskReward = model.TaskDatas[model.TaskDatas.Count - 1].AwardDataList[0];
				if (opTaskReward != null)
				{
					this.mItemComItem = ComItemManager.Create(this.mRoot.gameObject);
					ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)opTaskReward.id, 100, (int)opTaskReward.strenth);
					itemData.Count = (int)opTaskReward.num;
					ComItem comItem = this.mItemComItem;
					ItemData item = itemData;
					if (QiXiQueQiaoActivityView.<>f__mg$cache0 == null)
					{
						QiXiQueQiaoActivityView.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
					}
					comItem.Setup(item, QiXiQueQiaoActivityView.<>f__mg$cache0);
				}
			}
		}

		// Token: 0x0600F6ED RID: 63213 RVA: 0x0042C332 File Offset: 0x0042A732
		public override void UpdateData(ILimitTimeActivityModel model)
		{
			if (model == null)
			{
				return;
			}
			base.UpdateData(model);
			this._UpdateTitleInfo(model);
			this._UpdateProgressInfo(model);
			this._UpdateCurrentTaskInfo(model);
		}

		// Token: 0x0600F6EE RID: 63214 RVA: 0x0042C357 File Offset: 0x0042A757
		private void _UpdateTitleInfo(ILimitTimeActivityModel model)
		{
			this.mTextTime.SafeSetText(string.Format(TR.Value("activity_qi_xi_que_qiao_time"), Function.GetTimeWithoutYearNoZero((int)model.StartTime, (int)model.EndTime)));
		}

		// Token: 0x0600F6EF RID: 63215 RVA: 0x0042C384 File Offset: 0x0042A784
		private void _UpdateProgressInfo(ILimitTimeActivityModel model)
		{
			if (model.TaskDatas != null)
			{
				for (int i = 0; i < model.TaskDatas.Count; i++)
				{
					if (i >= this.mTextTargets.Count)
					{
						break;
					}
					if (!(this.mTextTargets[i] == null))
					{
						OpActTaskState state = model.TaskDatas[i].State;
						if (state != OpActTaskState.OATS_FINISHED && state != OpActTaskState.OATS_OVER)
						{
							this.mTextTargets[i].color = this.mUnFinishedColor;
						}
						else
						{
							this.mTextTargets[i].color = this.mFinishedColor;
						}
					}
				}
				this.mTextLastTarget.SafeSetText(string.Format(TR.Value("activity_qi_xi_que_qiao_item_reward"), model.TaskDatas[model.TaskDatas.Count - 1].Desc));
				if (this.mImageProgress != null && model.ParamArray != null && model.ParamArray.Length > 1)
				{
					float num = 0f;
					for (int j = 0; j < model.TaskDatas.Count; j++)
					{
						num += model.TaskDatas[j].DoneNum;
					}
					this.mImageProgress.fillAmount = num / model.ParamArray[0];
					string hexColor = Utility.GetHexColor(this.mTaskUnCompleteColor);
					if (num >= model.ParamArray[0])
					{
						hexColor = Utility.GetHexColor(this.mTaskCompleteColor);
					}
					this.mTextTotalProgress.SafeSetText(string.Format(TR.Value("activity_qi_xi_que_qiao_total_progress"), new object[]
					{
						hexColor,
						num,
						"</color>",
						model.ParamArray[0]
					}));
				}
			}
			if (model.ParamArray != null && model.ParamArray.Length >= 2)
			{
				string name = string.Format("{0}{1}", model.Id, CounterKeys.OPACT_MAGPIE_BRIDGE_DAILY_PROGRESS);
				int count = DataManager<CountDataManager>.GetInstance().GetCount(name);
				uint num2 = model.ParamArray[1];
				string hexColor2 = Utility.GetHexColor(this.mTaskUnCompleteColor);
				if ((long)count >= (long)((ulong)num2))
				{
					hexColor2 = Utility.GetHexColor(this.mTaskCompleteColor);
				}
				this.mTextRule.SafeSetText(model.RuleDesc + string.Format(TR.Value("activity_qi_xi_que_qiao_today_progress"), new object[]
				{
					hexColor2,
					count,
					"</color>",
					model.ParamArray[1]
				}));
			}
		}

		// Token: 0x0600F6F0 RID: 63216 RVA: 0x0042C62C File Offset: 0x0042AA2C
		private void _UpdateCurrentTaskInfo(ILimitTimeActivityModel model)
		{
			if (model.TaskDatas == null || model.TaskDatas.Count == 0)
			{
				return;
			}
			ILimitTimeActivityTaskDataModel limitTimeActivityTaskDataModel = null;
			for (int i = 0; i < model.TaskDatas.Count; i++)
			{
				if (model.TaskDatas[i].State == OpActTaskState.OATS_UNFINISH)
				{
					limitTimeActivityTaskDataModel = model.TaskDatas[i];
					break;
				}
				if (model.TaskDatas[i].State == OpActTaskState.OATS_FINISHED)
				{
					limitTimeActivityTaskDataModel = model.TaskDatas[i];
					break;
				}
			}
			bool flag = false;
			if (limitTimeActivityTaskDataModel == null)
			{
				limitTimeActivityTaskDataModel = model.TaskDatas[model.TaskDatas.Count - 1];
				flag = true;
			}
			if ((ulong)limitTimeActivityTaskDataModel.DataId != (ulong)((long)this.mCurrentTaskId))
			{
				this.mCurrentTaskId = (int)limitTimeActivityTaskDataModel.DataId;
				if (this.mComItem != null)
				{
					ComItemManager.Destroy(this.mComItem);
					this.mComItem = null;
				}
				this.mComItem = ComItemManager.Create(this.mCurrentTaskItemRoot.gameObject);
				ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)limitTimeActivityTaskDataModel.AwardDataList[0].id, 100, (int)limitTimeActivityTaskDataModel.AwardDataList[0].strenth);
				itemData.Count = (int)limitTimeActivityTaskDataModel.AwardDataList[0].num;
				ComItem comItem = this.mComItem;
				ItemData item = itemData;
				if (QiXiQueQiaoActivityView.<>f__mg$cache1 == null)
				{
					QiXiQueQiaoActivityView.<>f__mg$cache1 = new ComItem.OnItemClicked(Utility.OnItemClicked);
				}
				comItem.Setup(item, QiXiQueQiaoActivityView.<>f__mg$cache1);
			}
			OpActTaskState state = limitTimeActivityTaskDataModel.State;
			if (state != OpActTaskState.OATS_FINISHED)
			{
				if (state != OpActTaskState.OATS_OVER)
				{
					this.mFinishedGO.CustomActive(false);
					this.mUnFinishedGO.CustomActive(true);
					this.mEndGO.CustomActive(false);
				}
				else
				{
					this.mFinishedGO.CustomActive(false);
					this.mUnFinishedGO.CustomActive(false);
					this.mEndGO.CustomActive(true);
					if (flag)
					{
						this.mEffectCompleteAllTask.CustomActive(true);
					}
				}
			}
			else
			{
				this.mFinishedGO.CustomActive(true);
				this.mUnFinishedGO.CustomActive(false);
				this.mEndGO.CustomActive(false);
			}
		}

		// Token: 0x0600F6F1 RID: 63217 RVA: 0x0042C854 File Offset: 0x0042AC54
		private void _OnButtonTakeAwardClick()
		{
			if (this.mOnItemClick != null)
			{
				this.mOnItemClick(this.mCurrentTaskId, 0, 0UL);
			}
		}

		// Token: 0x0600F6F2 RID: 63218 RVA: 0x0042C875 File Offset: 0x0042AC75
		private void _OnButtonTryOnClick()
		{
			if (this.mLastGiftPackItemId > 0)
			{
				this._ShowAvartar();
			}
		}

		// Token: 0x0600F6F3 RID: 63219 RVA: 0x0042C88C File Offset: 0x0042AC8C
		private void _OnButtonFinalRewardClick()
		{
			if (this.mLastRewardItemId > 0)
			{
				ItemData itemData = ItemDataManager.CreateItemDataFromTable(this.mLastRewardItemId, 100, 0);
				if (itemData != null)
				{
					Utility.OnItemClicked(null, itemData);
				}
			}
		}

		// Token: 0x0600F6F4 RID: 63220 RVA: 0x0042C8C4 File Offset: 0x0042ACC4
		public override void Dispose()
		{
			base.Dispose();
			if (this.mComItem != null)
			{
				ComItemManager.Destroy(this.mComItem);
				this.mComItem = null;
			}
			this.mButtonTakeAward.SafeRemoveOnClickListener(new UnityAction(this._OnButtonTakeAwardClick));
			this.mButtonTryOn.SafeRemoveOnClickListener(new UnityAction(this._OnButtonTryOnClick));
			this.mButtonFinalReward.SafeRemoveOnClickListener(new UnityAction(this._OnButtonFinalRewardClick));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.GetGiftData, new ClientEventSystem.UIEventHandler(this._OnGetGiftData));
			this.mIsInitAvatar = false;
			this.mCurrentTaskId = -1;
			this.mLastRewardItemId = -1;
		}

		// Token: 0x0600F6F5 RID: 63221 RVA: 0x0042C96F File Offset: 0x0042AD6F
		public override void Show()
		{
			if (this.mIsInitAvatar)
			{
				this._ShowAvartar();
			}
		}

		// Token: 0x0600F6F6 RID: 63222 RVA: 0x0042C984 File Offset: 0x0042AD84
		private void _ShowAvartar()
		{
			if (Singleton<ClientSystemManager>.GetInstance().IsFrameOpen<PlayerTryOnFrame>(null))
			{
				PlayerTryOnFrame playerTryOnFrame = Singleton<ClientSystemManager>.GetInstance().GetFrame(typeof(PlayerTryOnFrame)) as PlayerTryOnFrame;
				if (playerTryOnFrame != null)
				{
					playerTryOnFrame.Reset(this.mLastRewardItemId);
				}
			}
			else
			{
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<PlayerTryOnFrame>(FrameLayer.Middle, this.mLastRewardItemId, string.Empty);
			}
		}

		// Token: 0x0600F6F7 RID: 63223 RVA: 0x0042C9F0 File Offset: 0x0042ADF0
		private void _OnGetGiftData(UIEvent param)
		{
			if (param == null || param.Param1 == null)
			{
				Logger.LogError("礼包数据为空");
				return;
			}
			GiftPackSyncInfo giftPackSyncInfo = param.Param1 as GiftPackSyncInfo;
			if (giftPackSyncInfo != null && (ulong)giftPackSyncInfo.id == (ulong)((long)this.mLastGiftPackItemId))
			{
				for (int i = 0; i < giftPackSyncInfo.gifts.Length; i++)
				{
					GiftPackItemData giftDataFromNet = GiftPackDataManager.GetGiftDataFromNet(giftPackSyncInfo.gifts[i]);
					if (giftDataFromNet.ItemID > 0 && giftDataFromNet.RecommendJobs.Contains(DataManager<PlayerBaseData>.GetInstance().JobTableID))
					{
						this.mLastRewardItemId = giftDataFromNet.ItemID;
						if (this.mIsInitAvatar)
						{
							this._ShowAvartar();
						}
						break;
					}
				}
			}
		}

		// Token: 0x040097C7 RID: 38855
		[SerializeField]
		private Text mTextTime;

		// Token: 0x040097C8 RID: 38856
		[SerializeField]
		private Text mTextRule;

		// Token: 0x040097C9 RID: 38857
		[SerializeField]
		private Text mTextTotalProgress;

		// Token: 0x040097CA RID: 38858
		[SerializeField]
		private Image mImageProgress;

		// Token: 0x040097CB RID: 38859
		[SerializeField]
		private List<Text> mTextTargets;

		// Token: 0x040097CC RID: 38860
		[SerializeField]
		private Text mTextLastTarget;

		// Token: 0x040097CD RID: 38861
		[SerializeField]
		private Button mButtonTryOn;

		// Token: 0x040097CE RID: 38862
		[SerializeField]
		private Color mFinishedColor;

		// Token: 0x040097CF RID: 38863
		[SerializeField]
		private Color mUnFinishedColor;

		// Token: 0x040097D0 RID: 38864
		[SerializeField]
		private Transform mCurrentTaskItemRoot;

		// Token: 0x040097D1 RID: 38865
		[SerializeField]
		private Button mButtonTakeAward;

		// Token: 0x040097D2 RID: 38866
		[SerializeField]
		private Button mButtonFinalReward;

		// Token: 0x040097D3 RID: 38867
		[SerializeField]
		private GameObject mFinishedGO;

		// Token: 0x040097D4 RID: 38868
		[SerializeField]
		private GameObject mUnFinishedGO;

		// Token: 0x040097D5 RID: 38869
		[SerializeField]
		private GameObject mEndGO;

		// Token: 0x040097D6 RID: 38870
		[SerializeField]
		private GameObject mEffectCompleteAllTask;

		// Token: 0x040097D7 RID: 38871
		[SerializeField]
		private Color mTaskCompleteColor = Color.red;

		// Token: 0x040097D8 RID: 38872
		[SerializeField]
		private Color mTaskUnCompleteColor = Color.green;

		// Token: 0x040097D9 RID: 38873
		[SerializeField]
		private Transform mRoot;

		// Token: 0x040097DA RID: 38874
		private ComItem mItemComItem;

		// Token: 0x040097DB RID: 38875
		private ComItem mComItem;

		// Token: 0x040097DC RID: 38876
		private int mCurrentTaskId = -1;

		// Token: 0x040097DD RID: 38877
		private int mLastRewardItemId = -1;

		// Token: 0x040097DE RID: 38878
		private int mLastGiftPackItemId = -1;

		// Token: 0x040097DF RID: 38879
		private bool mIsInitAvatar;

		// Token: 0x040097E0 RID: 38880
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;

		// Token: 0x040097E1 RID: 38881
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache1;
	}
}
