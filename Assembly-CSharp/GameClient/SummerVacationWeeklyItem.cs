using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001910 RID: 6416
	public class SummerVacationWeeklyItem : ActivityItemBase
	{
		// Token: 0x0600F9C8 RID: 63944 RVA: 0x00444F70 File Offset: 0x00443370
		protected override void OnInit(ILimitTimeActivityTaskDataModel data)
		{
			if (data == null)
			{
				return;
			}
			this.mData = data;
			if (this.mDesTxt != null)
			{
				this.mDesTxt.text = data.Desc;
			}
			if (this.mTitleTxt != null)
			{
				this.mTitleTxt.text = data.taskName;
			}
			if (data.AwardDataList != null)
			{
				for (int i = 0; i < data.AwardDataList.Count; i++)
				{
					if (this.mRewardRoot != null)
					{
						ComItem comItem = ComItemManager.Create(this.mRewardRoot.gameObject);
						if (comItem != null)
						{
							ItemData itemData = ItemDataManager.CreateItemDataFromTable((int)data.AwardDataList[i].id, 100, 0);
							itemData.Count = (int)data.AwardDataList[i].num;
							ComItem comItem2 = comItem;
							ItemData item = itemData;
							if (SummerVacationWeeklyItem.<>f__mg$cache0 == null)
							{
								SummerVacationWeeklyItem.<>f__mg$cache0 = new ComItem.OnItemClicked(Utility.OnItemClicked);
							}
							comItem2.Setup(item, SummerVacationWeeklyItem.<>f__mg$cache0);
							this.mComItems.Add(comItem);
							(comItem.transform as RectTransform).sizeDelta = this.mComItemSize;
						}
					}
				}
			}
			if (this.mTakeTaskBtn != null)
			{
				this.mTakeTaskBtn.SafeAddOnClickListener(new UnityAction(this.OnTakeBtnClick));
			}
			if (this.mGoToBtn != null)
			{
				this.mGoToBtn.SafeAddOnClickListener(new UnityAction(this.OnGoToDungeonClikc));
			}
			if (this.mRewardBtn != null)
			{
				this.mRewardBtn.SafeAddOnClickListener(new UnityAction(this._OnItemClick));
			}
		}

		// Token: 0x0600F9C9 RID: 63945 RVA: 0x00445114 File Offset: 0x00443514
		public override void UpdateData(ILimitTimeActivityTaskDataModel data)
		{
			int activityConunter = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION, ActivityLimitTimeFactory.EActivityCounterType.OAT_SUMMER_WEEKLY_VACATION);
			OpActivityData activeDataFromType = DataManager<ActivityDataManager>.GetInstance().GetActiveDataFromType(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION);
			if (activeDataFromType != null && activeDataFromType.parm2 != null && activeDataFromType.parm2.Length >= 2)
			{
				this.mTotalReceiveAcountNum = (int)activeDataFromType.parm2[0];
				this.mTotalReceiveRoleNum = (int)activeDataFromType.parm2[1];
			}
			this.mCanReceiveAccountNum = this.mTotalReceiveAcountNum - activityConunter;
			if (this.mCanReceiveAccountNum <= 0)
			{
				this.mCanReceiveAccountNum = 0;
			}
			List<uint> haveRecivedTaskID = DataManager<ActivityDataManager>.GetInstance().GetHaveRecivedTaskID(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION);
			if (haveRecivedTaskID != null && haveRecivedTaskID.Count > 0 && data != null && !haveRecivedTaskID.Contains(data.DataId) && haveRecivedTaskID.Count >= this.mTotalReceiveRoleNum)
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
				else if (this.mCanReceiveAccountNum <= 0)
				{
					this.OnlyShowNumHaveUsedTxt();
				}
				else
				{
					this.OnlyShowTakeTaskBtn();
					this.ShowTaskProgress();
				}
				break;
			case OpActTaskState.OATS_UNFINISH:
				this.OnlyShowGoToBtn();
				this.ShowTaskProgress();
				break;
			case OpActTaskState.OATS_FINISHED:
				this.OnlyRewardBtn();
				this.ShowTaskProgress();
				break;
			case OpActTaskState.OATS_OVER:
				this.OnlyRewardAfter();
				this.ShowTaskProgress();
				break;
			}
		}

		// Token: 0x0600F9CA RID: 63946 RVA: 0x004452A0 File Offset: 0x004436A0
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
			if (this.mTakeTaskBtn != null)
			{
				this.mTakeTaskBtn.SafeRemoveOnClickListener(new UnityAction(this.OnTakeBtnClick));
			}
			if (this.mGoToBtn != null)
			{
				this.mGoToBtn.SafeRemoveOnClickListener(new UnityAction(this.OnGoToDungeonClikc));
			}
			if (this.mRewardBtn != null)
			{
				this.mRewardBtn.SafeRemoveOnClickListener(new UnityAction(this._OnItemClick));
			}
			this.mData = null;
		}

		// Token: 0x0600F9CB RID: 63947 RVA: 0x00445378 File Offset: 0x00443778
		private void OnTakeBtnClick()
		{
			CommonMsgBoxOkCancelNewParamData paramData = new CommonMsgBoxOkCancelNewParamData
			{
				ContentLabel = string.Format(TR.Value("limitactivity_shuqi_conetnt"), 3),
				IsShowNotify = false,
				LeftButtonText = TR.Value("limitactivity_shuqi_cancel"),
				RightButtonText = TR.Value("limitactivity_shuqi_ok"),
				OnRightButtonClickCallBack = new Action(this.OnOKBtnClick)
			};
			SystemNotifyManager.OpenCommonMsgBoxOkCancelNewFrame(paramData);
		}

		// Token: 0x0600F9CC RID: 63948 RVA: 0x004453E8 File Offset: 0x004437E8
		private void OnOKBtnClick()
		{
			SceneOpActivityAcceptTaskReq sceneOpActivityAcceptTaskReq = new SceneOpActivityAcceptTaskReq();
			sceneOpActivityAcceptTaskReq.opActId = (uint)DataManager<ActivityDataManager>.GetInstance().GetActiveIdFromType(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION);
			if (this.mData != null)
			{
				sceneOpActivityAcceptTaskReq.taskId = this.mData.DataId;
			}
			NetManager netManager = NetManager.Instance();
			if (netManager != null)
			{
				netManager.SendCommand<SceneOpActivityAcceptTaskReq>(ServerType.GATE_SERVER, sceneOpActivityAcceptTaskReq);
			}
			DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq(ActivityLimitTimeFactory.EActivityType.OAT_SUMMER_WEEKLY_VACATION, ActivityLimitTimeFactory.EActivityCounterType.OAT_SUMMER_WEEKLY_VACATION);
		}

		// Token: 0x0600F9CD RID: 63949 RVA: 0x0044545C File Offset: 0x0044385C
		private void OnGoToDungeonClikc()
		{
			if (this.mData != null)
			{
				if (this.mData.ParamNums2 != null && this.mData.ParamNums2.Count > 0)
				{
					DungeonModelTable.eType dugeonModleTypeById = DungeonUtility.GetDugeonModleTypeById((int)this.mData.ParamNums2[0]);
					if (dugeonModleTypeById == DungeonModelTable.eType.Type_None)
					{
						ClientSystemTown targetSystem = ClientSystem.GetTargetSystem<ClientSystemTown>();
						if (targetSystem != null)
						{
							targetSystem.MainPlayer.CommandMoveToDungeon((int)this.mData.ParamNums2[0]);
						}
					}
					else
					{
						ChallengeUtility.OnOpenChallengeMapFrame(dugeonModleTypeById, 0, 0);
					}
					Singleton<ClientSystemManager>.GetInstance().CloseFrame<LimitTimeActivityFrame>(null, false);
				}
				else
				{
					WeeklyCheckInActivityView.OnRecommendedDungeonsBtnClick();
				}
			}
		}

		// Token: 0x0600F9CE RID: 63950 RVA: 0x00445504 File Offset: 0x00443904
		private void ShowTaskProgress()
		{
			if (this.mData == null)
			{
				return;
			}
			if (this.mTaskProgressSlider != null)
			{
				this.mTaskProgressSlider.value = this.mData.DoneNum * 1f / this.mData.TotalNum * 1f;
			}
			if (this.mTaskProgressTxt != null)
			{
				this.mTaskProgressTxt.text = string.Format("{0}/{1}", this.mData.DoneNum, this.mData.TotalNum);
			}
		}

		// Token: 0x0600F9CF RID: 63951 RVA: 0x004455A8 File Offset: 0x004439A8
		private void OnlyRewardAfter()
		{
			this.mRewardAfterGo.CustomActive(true);
			this.mRewardBtn.CustomActive(false);
			this.mGoToBtn.CustomActive(false);
			this.maskGo.CustomActive(false);
			this.mTakeTaskBtn.CustomActive(false);
			this.mLvLockTxt.CustomActive(false);
			this.mNumHaveUsedTxt.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(true);
			this.mTaskProgressSlider.CustomActive(true);
		}

		// Token: 0x0600F9D0 RID: 63952 RVA: 0x00445624 File Offset: 0x00443A24
		private void OnlyRewardBtn()
		{
			this.mRewardBtn.CustomActive(true);
			this.mGoToBtn.CustomActive(false);
			this.maskGo.CustomActive(false);
			this.mTakeTaskBtn.CustomActive(false);
			this.mLvLockTxt.CustomActive(false);
			this.mNumHaveUsedTxt.CustomActive(false);
			this.mRewardAfterGo.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(true);
			this.mTaskProgressSlider.CustomActive(true);
		}

		// Token: 0x0600F9D1 RID: 63953 RVA: 0x004456A0 File Offset: 0x00443AA0
		private void OnlyShowGoToBtn()
		{
			this.mGoToBtn.CustomActive(true);
			this.maskGo.CustomActive(false);
			this.mTakeTaskBtn.CustomActive(false);
			this.mLvLockTxt.CustomActive(false);
			this.mNumHaveUsedTxt.CustomActive(false);
			this.mRewardBtn.CustomActive(false);
			this.mRewardAfterGo.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(true);
			this.mTaskProgressSlider.CustomActive(true);
		}

		// Token: 0x0600F9D2 RID: 63954 RVA: 0x0044571C File Offset: 0x00443B1C
		private void OnlyShowTakeTaskBtn()
		{
			this.mTakeTaskBtn.CustomActive(true);
			this.mLvLockTxt.CustomActive(false);
			this.mNumHaveUsedTxt.CustomActive(false);
			this.mGoToBtn.CustomActive(false);
			this.mRewardBtn.CustomActive(false);
			this.mRewardAfterGo.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
		}

		// Token: 0x0600F9D3 RID: 63955 RVA: 0x0044578C File Offset: 0x00443B8C
		private void OnlyShowLvLockTxt()
		{
			this.maskGo.CustomActive(true);
			this.mLvLockTxt.CustomActive(true);
			if (this.mData != null)
			{
				this.mLvLockTxt.text = string.Format(TR.Value("limitactivity_shuqi_limitLevel"), this.mData.PlayerLevelLimit);
			}
			this.mTakeTaskBtn.CustomActive(false);
			this.mNumHaveUsedTxt.CustomActive(false);
			this.mGoToBtn.CustomActive(false);
			this.mRewardBtn.CustomActive(false);
			this.mRewardAfterGo.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
		}

		// Token: 0x0600F9D4 RID: 63956 RVA: 0x0044583C File Offset: 0x00443C3C
		private void OnlyShowNumHaveUsedTxt()
		{
			this.mNumHaveUsedTxt.CustomActive(true);
			this.mNumHaveUsedTxt.text = TR.Value("limitactivity_shuqi_numhaveused");
			this.maskGo.CustomActive(true);
			this.mTakeTaskBtn.CustomActive(false);
			this.mLvLockTxt.CustomActive(false);
			this.mGoToBtn.CustomActive(false);
			this.mRewardBtn.CustomActive(false);
			this.mRewardAfterGo.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
		}

		// Token: 0x0600F9D5 RID: 63957 RVA: 0x004458CC File Offset: 0x00443CCC
		private void OnlyShowUnTakeTask()
		{
			this.maskGo.CustomActive(true);
			this.mNumHaveUsedTxt.CustomActive(false);
			this.mTakeTaskBtn.CustomActive(false);
			this.mLvLockTxt.CustomActive(false);
			this.mGoToBtn.CustomActive(false);
			this.mRewardBtn.CustomActive(false);
			this.mRewardAfterGo.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
			this.mTaskProgressSlider.CustomActive(false);
		}

		// Token: 0x04009BE9 RID: 39913
		[SerializeField]
		private Text mTitleTxt;

		// Token: 0x04009BEA RID: 39914
		[SerializeField]
		private Text mDesTxt;

		// Token: 0x04009BEB RID: 39915
		[SerializeField]
		private Transform mRewardRoot;

		// Token: 0x04009BEC RID: 39916
		[SerializeField]
		private Vector2 mComItemSize = new Vector2(100f, 100f);

		// Token: 0x04009BED RID: 39917
		[SerializeField]
		private Text mLvLockTxt;

		// Token: 0x04009BEE RID: 39918
		[SerializeField]
		private Text mNumHaveUsedTxt;

		// Token: 0x04009BEF RID: 39919
		[SerializeField]
		private Button mTakeTaskBtn;

		// Token: 0x04009BF0 RID: 39920
		[SerializeField]
		private Button mRewardBtn;

		// Token: 0x04009BF1 RID: 39921
		[SerializeField]
		private Button mGoToBtn;

		// Token: 0x04009BF2 RID: 39922
		[SerializeField]
		private GameObject mRewardAfterGo;

		// Token: 0x04009BF3 RID: 39923
		[SerializeField]
		private Slider mTaskProgressSlider;

		// Token: 0x04009BF4 RID: 39924
		[SerializeField]
		private Text mTaskProgressTxt;

		// Token: 0x04009BF5 RID: 39925
		private List<ComItem> mComItems = new List<ComItem>();

		// Token: 0x04009BF6 RID: 39926
		[SerializeField]
		private GameObject maskGo;

		// Token: 0x04009BF7 RID: 39927
		private ILimitTimeActivityTaskDataModel mData;

		// Token: 0x04009BF8 RID: 39928
		private int mTotalReceiveAcountNum;

		// Token: 0x04009BF9 RID: 39929
		private int mCanReceiveAccountNum = 3;

		// Token: 0x04009BFA RID: 39930
		private int mCanReceiveRoleNum = 1;

		// Token: 0x04009BFB RID: 39931
		private int mTotalReceiveRoleNum = 1;

		// Token: 0x04009BFC RID: 39932
		[CompilerGenerated]
		private static ComItem.OnItemClicked <>f__mg$cache0;
	}
}
