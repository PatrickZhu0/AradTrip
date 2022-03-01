using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x020018E6 RID: 6374
	public class DailyChallengeItem : ActivityItemBase
	{
		// Token: 0x0600F8BF RID: 63679 RVA: 0x0043BBB4 File Offset: 0x00439FB4
		private void Awake()
		{
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveAllListeners();
				this.mReceiveBtn.onClick.AddListener(new UnityAction(this.OnReceiveBtnClick));
			}
			if (this.mGoToBtn != null)
			{
				this.mGoToBtn.onClick.RemoveAllListeners();
				this.mGoToBtn.onClick.AddListener(new UnityAction(this.OnGoToBtnClick));
			}
			if (this.mTakeTaskBtn != null)
			{
				this.mTakeTaskBtn.onClick.RemoveAllListeners();
				this.mTakeTaskBtn.onClick.AddListener(new UnityAction(this.OnTakeTaskBtnClick));
			}
		}

		// Token: 0x0600F8C0 RID: 63680 RVA: 0x0043BC78 File Offset: 0x0043A078
		private void OnDestroy()
		{
			this.Dispose();
		}

		// Token: 0x0600F8C1 RID: 63681 RVA: 0x0043BC80 File Offset: 0x0043A080
		public override void Dispose()
		{
			base.Dispose();
			if (this.mReceiveBtn != null)
			{
				this.mReceiveBtn.onClick.RemoveListener(new UnityAction(this.OnReceiveBtnClick));
			}
			if (this.mGoToBtn != null)
			{
				this.mGoToBtn.onClick.RemoveListener(new UnityAction(this.OnGoToBtnClick));
			}
			if (this.mTakeTaskBtn != null)
			{
				this.mTakeTaskBtn.onClick.RemoveListener(new UnityAction(this.OnTakeTaskBtnClick));
			}
		}

		// Token: 0x0600F8C2 RID: 63682 RVA: 0x0043BD1C File Offset: 0x0043A11C
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK);
			int num = this.mAcountTotalReceiveNum - activityConunter;
			if (num <= 0)
			{
				num = 0;
			}
			List<uint> haveRecivedTaskID = DataManager<ActivityDataManager>.GetInstance().GetHaveRecivedTaskID(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY);
			if (haveRecivedTaskID != null && haveRecivedTaskID.Count > 0 && data != null && !haveRecivedTaskID.Contains(data.DataId) && haveRecivedTaskID.Count >= this.mRoleTotalReceiveNum)
			{
				this.OnlyShowUnTakeTask();
				return;
			}
			switch (data.State)
			{
			case OpActTaskState.OATS_INIT:
				if (DataManager<PlayerBaseData>.GetInstance().Level < data.PlayerLevelLimit)
				{
					this.OnlyShowLvLockTxt();
				}
				else if (num <= 0)
				{
					this.OnlyShowNumHaveUsedTxt();
				}
				else
				{
					this.OnlyShowTakeTaskBtn();
				}
				break;
			case OpActTaskState.OATS_UNFINISH:
				this.OnlyShowGoToBtn();
				break;
			case OpActTaskState.OATS_FINISHED:
				this.OnlyRewardBtn();
				break;
			case OpActTaskState.OATS_OVER:
				this.OnlyHaveToReceive();
				break;
			}
		}

		// Token: 0x0600F8C3 RID: 63683 RVA: 0x0043BE2C File Offset: 0x0043A22C
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mData = data;
			string key = (this.mData.DataId % 2U != 1U) ? "Limit_Time_Activity_DailyChalleng_0" : "Limit_Time_Activity_DailyChalleng_1";
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY);
			if (activeDataFromType != null && activeDataFromType.parm2 != null && activeDataFromType.parm2.Length >= 2)
			{
				this.mAcountTotalReceiveNum = (int)activeDataFromType.parm2[0];
				this.mRoleTotalReceiveNum = (int)activeDataFromType.parm2[1];
			}
			if (this.mTaskDesc != null)
			{
				this.mTaskDesc.text = TR.Value(key, this.mData.Desc);
			}
			if (this.mLvLockDesc != null)
			{
				this.mLvLockDesc.text = TR.Value("limitactivity_dailychallenge_levelDesc", this.mData.PlayerLevelLimit);
			}
			if (this.mNumHasUsedDesc != null)
			{
				this.mNumHasUsedDesc.text = TR.Value("limitactivity_dailychallenge_numhaveused");
			}
			if (this.mProgressDesc != null)
			{
				this.mProgressDesc.text = TR.Value(key, TR.Value("limitactivity_dailychallenge_progress", this.mData.DoneNum, this.mData.TotalNum));
			}
			if (this.mData.AwardDataList != null)
			{
				for (int i = 0; i < this.mData.AwardDataList.Count; i++)
				{
					OpTaskReward opTaskReward = this.mData.AwardDataList[i];
					if (opTaskReward != null)
					{
						CommonNewItemDataModel dataModel = new CommonNewItemDataModel
						{
							ItemId = (int)opTaskReward.id,
							ItemCount = (int)opTaskReward.num
						};
						CommonNewItem commonNewItem = CommonUtility.CreateCommonNewItem(this.mItemRoot);
						if (commonNewItem != null)
						{
							commonNewItem.InitItem(dataModel);
							commonNewItem.SetItemCountFontSize(26);
							commonNewItem.SetItemLevelFontSize(26);
							(commonNewItem.transform as RectTransform).sizeDelta = this.mComItemSize;
						}
					}
				}
			}
		}

		// Token: 0x0600F8C4 RID: 63684 RVA: 0x0043C04C File Offset: 0x0043A44C
		private void OnlyShowUnTakeTask()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(false);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(false);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(false);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(false);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
		}

		// Token: 0x0600F8C5 RID: 63685 RVA: 0x0043C108 File Offset: 0x0043A508
		private void OnlyShowLvLockTxt()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(false);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(true);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(false);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(false);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
		}

		// Token: 0x0600F8C6 RID: 63686 RVA: 0x0043C1C4 File Offset: 0x0043A5C4
		private void OnlyShowNumHaveUsedTxt()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(true);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(false);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(false);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(false);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
		}

		// Token: 0x0600F8C7 RID: 63687 RVA: 0x0043C280 File Offset: 0x0043A680
		private void OnlyShowTakeTaskBtn()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(false);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(false);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(true);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(false);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
		}

		// Token: 0x0600F8C8 RID: 63688 RVA: 0x0043C33C File Offset: 0x0043A73C
		private void OnlyShowGoToBtn()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(false);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(false);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(false);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(true);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
		}

		// Token: 0x0600F8C9 RID: 63689 RVA: 0x0043C3F8 File Offset: 0x0043A7F8
		private void OnlyRewardBtn()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(false);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(false);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(false);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(false);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(true);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(false);
			}
		}

		// Token: 0x0600F8CA RID: 63690 RVA: 0x0043C4B4 File Offset: 0x0043A8B4
		private void OnlyHaveToReceive()
		{
			if (this.mNumHaveUseGo != null)
			{
				this.mNumHaveUseGo.CustomActive(false);
			}
			if (this.mLvLockGo != null)
			{
				this.mLvLockGo.CustomActive(false);
			}
			if (this.mTakeTaskGo != null)
			{
				this.mTakeTaskGo.CustomActive(false);
			}
			if (this.mGoToGo != null)
			{
				this.mGoToGo.CustomActive(false);
			}
			if (this.mGoReceive != null)
			{
				this.mGoReceive.CustomActive(false);
			}
			if (this.mGoHaveToReceive != null)
			{
				this.mGoHaveToReceive.CustomActive(true);
			}
		}

		// Token: 0x0600F8CB RID: 63691 RVA: 0x0043C56F File Offset: 0x0043A96F
		private void OnReceiveBtnClick()
		{
			this._OnItemClick();
		}

		// Token: 0x0600F8CC RID: 63692 RVA: 0x0043C578 File Offset: 0x0043A978
		private void OnGoToBtnClick()
		{
			if (this.mData != null)
			{
				if (this.mData.EventType == 14)
				{
					if (!Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Duel))
					{
						SystemNotifyManager.SysNotifyFloatingEffect("未解锁决斗场", CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						return;
					}
					if (DataManager<TeamDataManager>.GetInstance().HasTeam())
					{
						SystemNotifyManager.SystemNotify(1104, string.Empty);
						return;
					}
					Utility.SwitchToPkWaitingRoom(PkRoomType.TraditionPk);
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
				}
				else if (this.mData.EventType == 11 || this.mData.EventType == 15)
				{
					if (this.mData.ParamNums != null && this.mData.ParamNums.Count > 0)
					{
						int subType = (int)this.mData.ParamNums[0];
						DungeonModelTable.eType dugeonModleTypeById = DungeonUtility.GetDugeonModleTypeById((DungeonTable.eSubType)subType);
						if (dugeonModleTypeById != DungeonModelTable.eType.Type_None)
						{
							ChallengeUtility.OnOpenChallengeMapFrame(dugeonModleTypeById, 0, 0);
						}
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
					}
					else if (this.mData.ParamNums2 != null && this.mData.ParamNums2.Count > 0)
					{
						DungeonModelTable.eType dugeonModleTypeById2 = DungeonUtility.GetDugeonModleTypeById((int)this.mData.ParamNums2[0]);
						if (dugeonModleTypeById2 == DungeonModelTable.eType.Type_None)
						{
							ClientSystemTown targetSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
							if (targetSystem != null)
							{
								targetSystem.MainPlayer.CommandMoveToDungeon((int)this.mData.ParamNums2[0]);
							}
						}
						else
						{
							ChallengeUtility.OnOpenChallengeMapFrame(dugeonModleTypeById2, 0, 0);
						}
						Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
					}
					else
					{
						WeeklyCheckInActivityView.OnRecommendedDungeonsBtnClick();
					}
				}
			}
		}

		// Token: 0x0600F8CD RID: 63693 RVA: 0x0043C708 File Offset: 0x0043AB08
		private void OnTakeTaskBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = string.Format(TR.Value("limitactivity_dailychallenge_content"), this.mAcountTotalReceiveNum),
				IsShowNotify = false,
				LeftButtonText = TR.Value("limitactivity_dailychallenge_cancel"),
				RightButtonText = TR.Value("limitactivity_dailychallenge_ok"),
				OnRightButtonClickCallBack = new Action(this.OnOKBtnClick)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600F8CE RID: 63694 RVA: 0x0043C77C File Offset: 0x0043AB7C
		private void OnOKBtnClick()
		{
			uint activeIdFromType = (uint)DataManager<ActivityDataManager>.GetInstance().GetActiveIdFromType(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY);
			uint taskId = 0U;
			if (this.mData != null)
			{
				taskId = this.mData.DataId;
			}
			DataManager<ActivityDataManager>.GetInstance().OnSceneOpActivityAcceptTaskReq(activeIdFromType, taskId);
			DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq(ActivityLimitTimeFactory.EActivityType.OAT_DAILYCHALLENGEACTIVITY, ActivityLimitTimeFactory.EActivityCounterType.OP_ACTIVITY_BEHAVIOR_WEEKLY_ACCEPT_TASK);
		}

		// Token: 0x04009A33 RID: 39475
		[SerializeField]
		private Text mTaskDesc;

		// Token: 0x04009A34 RID: 39476
		[SerializeField]
		private Text mLvLockDesc;

		// Token: 0x04009A35 RID: 39477
		[SerializeField]
		private Text mNumHasUsedDesc;

		// Token: 0x04009A36 RID: 39478
		[SerializeField]
		private GameObject mLvLockGo;

		// Token: 0x04009A37 RID: 39479
		[SerializeField]
		private GameObject mNumHaveUseGo;

		// Token: 0x04009A38 RID: 39480
		[SerializeField]
		private GameObject mItemRoot;

		// Token: 0x04009A39 RID: 39481
		[SerializeField]
		private Button mReceiveBtn;

		// Token: 0x04009A3A RID: 39482
		[SerializeField]
		private Button mGoToBtn;

		// Token: 0x04009A3B RID: 39483
		[SerializeField]
		private Button mTakeTaskBtn;

		// Token: 0x04009A3C RID: 39484
		[SerializeField]
		private GameObject mTakeTaskGo;

		// Token: 0x04009A3D RID: 39485
		[SerializeField]
		private GameObject mGoToGo;

		// Token: 0x04009A3E RID: 39486
		[SerializeField]
		private GameObject mGoReceive;

		// Token: 0x04009A3F RID: 39487
		[SerializeField]
		private GameObject mGoHaveToReceive;

		// Token: 0x04009A40 RID: 39488
		[SerializeField]
		private Text mProgressDesc;

		// Token: 0x04009A41 RID: 39489
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(70f, 70f);

		// Token: 0x04009A42 RID: 39490
		private int mAcountTotalReceiveNum;

		// Token: 0x04009A43 RID: 39491
		private int mRoleTotalReceiveNum;

		// Token: 0x04009A44 RID: 39492
		private ILimitTimeActivityTaskDataModel mData;
	}
}
