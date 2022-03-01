using System;
using System.Collections;
using System.Collections.Generic;
using ActivityLimitTime;
using Network;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001532 RID: 5426
	public class ChapterNormalHalfFrame : ChapterBaseFrame
	{
		// Token: 0x0600D352 RID: 54098 RVA: 0x00345F2C File Offset: 0x0034432C
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterNormalHalf.prefab";
		}

		// Token: 0x0600D353 RID: 54099 RVA: 0x00345F34 File Offset: 0x00344334
		protected override void _bindExUI()
		{
			this.mlevelChallengeTimesRoot = this.mBind.GetGameObject("ChallengeTimesRoot");
			this.mLevelChallengeTimesNumber = this.mBind.GetCom<Text>("ChallengeTimesValue");
			this.mRebornLimitNumberValue = this.mBind.GetCom<Text>("RebornLimitNumberValue");
			this.mLevelResistValueRoot = this.mBind.GetGameObject("LevelResistValueRoot");
			this.mLevelResistValueLabel = this.mBind.GetCom<Text>("LevelResistValueLabel");
			this.mLevelResistValueNumber = this.mBind.GetCom<Text>("LevelResistValueNumber");
			this.mOwnerResistValueLabel = this.mBind.GetCom<Text>("OwnerResistValueLabel");
			this.mOwnerResistValueNumber = this.mBind.GetCom<Text>("OwnerResistValueNumber");
			this.mChapterInfo = this.mBind.GetCom<ComCommonChapterInfo>("chapterInfo");
			this.mTeamStart = this.mBind.GetCom<Button>("teamStart");
			this.mTeamStart.onClick.AddListener(new UnityAction(this._onTeamStartButtonClick));
			this.mNormalStart = this.mBind.GetCom<Button>("normalStart");
			this.mNormalStart.onClick.AddListener(new UnityAction(this._onNormalStartButtonClick));
			this.mStartButton = this.mBind.GetCom<UIGray>("startButton");
			this.mTeamButton = this.mBind.GetCom<UIGray>("teamButton");
			this.mHellroot0 = this.mBind.GetGameObject("hellroot0");
			this.mHellroot1 = this.mBind.GetGameObject("hellroot1");
			this.mYg0 = this.mBind.GetGameObject("yg0");
			this.mYg1 = this.mBind.GetGameObject("yg1");
			this.mBosschallengeRoot = this.mBind.GetGameObject("bosschallengeRoot");
			this.mComsumeRoot = this.mBind.GetGameObject("comsumeRoot");
			this.mStartRoot = this.mBind.GetGameObject("startRoot");
			this.mBindTicketRoot = this.mBind.GetGameObject("bindTicketRoot");
			this.mTicketRoot = this.mBind.GetGameObject("ticketRoot");
			this.mMissionContent = this.mBind.GetCom<LinkParse>("missionContent");
			this.mFatigueRoot = this.mBind.GetGameObject("fatigueRoot");
			this.mMissionInfo = this.mBind.GetCom<Text>("missionInfo");
			this.mMissionInfoRoot = this.mBind.GetGameObject("missionInfoRoot");
			this.mDungeonUnitInfo = this.mBind.GetCom<ComChapterDungeonUnit>("dungeonUnitInfo");
			this.mOnSelectLeftButton = this.mBind.GetCom<Button>("onSelectLeftButton");
			this.mOnSelectLeftButton.onClick.AddListener(new UnityAction(this._onOnSelectLeftButtonButtonClick));
			this.mOnSelectRightButton = this.mBind.GetCom<Button>("onSelectRightButton");
			this.mOnSelectRightButton.onClick.AddListener(new UnityAction(this._onOnSelectRightButtonButtonClick));
			this.mOnReward = this.mBind.GetCom<Button>("onReward");
			this.mOnReward.onClick.AddListener(new UnityAction(this._onOnRewardButtonClick));
			this.mOnRewardRed = this.mBind.GetGameObject("onRewardRed");
			this.mChapterRewardCount = this.mBind.GetCom<Text>("chapterRewardCount");
			this.mChapterRewardSum = this.mBind.GetCom<Text>("chapterRewardSum");
			this.mOnClose = this.mBind.GetCom<Button>("onClose");
			this.mOnClose.onClick.AddListener(new UnityAction(this._onOnCloseButtonClick));
			this.mMask = this.mBind.GetGameObject("mask");
			this.mHards[0] = this.mBind.GetGameObject("hard0");
			this.mHards[1] = this.mBind.GetGameObject("hard1");
			this.mHards[2] = this.mBind.GetGameObject("hard2");
			this.mHards[3] = this.mBind.GetGameObject("hard3");
			this.mRedPoint = this.mBind.GetGameObject("RedPoint");
			this.mRedPointSum = this.mBind.GetCom<Text>("RedPointSum");
			this.mRewardComplete = this.mBind.GetGameObject("RewardComplete");
			this.mFatigueCombustionRoot = this.mBind.GetGameObject("FatigueCombustionRoot");
			this.mGroupDrug = this.mBind.GetCom<Button>("GroupDrug");
			this.mGroupDrug.onClick.AddListener(new UnityAction(this._onSetDrugBtnClick));
			this.mCheckDrug = this.mBind.GetCom<Toggle>("CheckDrug");
			this.mCheckDrug.onValueChanged.AddListener(delegate(bool A_1)
			{
				this._onCheckDrugToggleChanged();
			});
			this.mDropButton = this.mBind.GetCom<Button>("DropButton");
			if (null != this.mDropButton)
			{
				this.mDropButton.onClick.AddListener(new UnityAction(this._onDropButtonClick));
			}
			this.mDropButtonEffect = this.mBind.GetGameObject("DropButtonEffect");
			this.mDropProgress = this.mBind.GetGameObject("DropProgress");
			this.mStrategySkillsBtn = this.mBind.GetCom<Button>("StrategySkills");
			if (this.mStrategySkillsBtn != null)
			{
				this.mStrategySkillsBtn.onClick.AddListener(new UnityAction(this._onmStrategySkillsBtnClick));
			}
			this.StartContinueRoot = this.mBind.GetGameObject("StartContinueRoot");
			this.StartContinue = this.mBind.GetCom<Button>("StartContinue");
			this.StartContinue.SafeSetOnClickListener(new UnityAction(this._onNormalStartButtonClick));
			this.mNormalDiffTxt = this.mBind.GetCom<Text>("NormallDiff");
			this.mDropDetailBtn = this.mBind.GetCom<Button>("DropDetailBtn");
			this.mDropDetailBtn.SafeAddOnClickListener(new UnityAction(this._OnDropDetailBtnClick));
			this.mNotCostFatigue = this.mBind.GetGameObject("NotCostFatigue");
			this.mBtNotCostFatigue = this.mBind.GetCom<Toggle>("btNotCostFatigue");
			this.mBtNotCostFatigue.SafeSetOnValueChangedListener(delegate(bool value)
			{
				if (this.bToggleInit)
				{
					this.bToggleInit = false;
					return;
				}
				if (value)
				{
					if (DataManager<TeamDataManager>.GetInstance().GetMemberNum() == 0)
					{
						SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("elite_dungeon_can_not_set_toggle_state_with_one_player"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
						this.mBtNotCostFatigue.SafeSetToggleOnState(false);
					}
					else
					{
						LoginToggleMsgBoxOKCancelFrame.TryShowMsgBox(LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType.NotCostFatigue, TR.Value("elite_dungeon_not_cost_fatigu_have_no_award"), delegate
						{
							DataManager<TeamDataManager>.GetInstance().SendSceneSaveOptionsReq(SaveOptionMask.SOM_NOT_COUSUME_EBERGY, true);
						}, delegate
						{
							this.mBtNotCostFatigue.SafeSetToggleOnState(false);
						}, string.Empty, string.Empty);
					}
				}
				else
				{
					DataManager<TeamDataManager>.GetInstance().SendSceneSaveOptionsReq(SaveOptionMask.SOM_NOT_COUSUME_EBERGY, false);
				}
			});
			this.mEliteDungeonTipRoot = this.mBind.GetGameObject("EliteDungeonTipRoot");
			this.mSpringFestivalRoot = this.mBind.GetGameObject("SpringFestivalDungeonRoot");
			this.mRoleNumTxt = this.mBind.GetCom<Text>("RoleNumTxt");
			this.mAccountNumTxt = this.mBind.GetCom<Text>("AccountNumTxt");
			this.mStartBtnEffectGo = this.mBind.GetGameObject("EffUI_qixijiemian_lingquanniu");
			this.mMoneiesGo = this.mBind.GetGameObject("Moneies");
		}

		// Token: 0x0600D354 RID: 54100 RVA: 0x00346608 File Offset: 0x00344A08
		protected override void _unbindExUI()
		{
			this.mlevelChallengeTimesRoot = null;
			this.mRebornLimitNumberValue = null;
			this.mLevelChallengeTimesNumber = null;
			this.mLevelResistValueRoot = null;
			this.mLevelResistValueLabel = null;
			this.mLevelResistValueNumber = null;
			this.mOwnerResistValueLabel = null;
			this.mOwnerResistValueLabel = null;
			this.mChapterInfo = null;
			this.mTeamStart.onClick.RemoveListener(new UnityAction(this._onTeamStartButtonClick));
			this.mTeamStart = null;
			this.mNormalStart.onClick.RemoveListener(new UnityAction(this._onNormalStartButtonClick));
			this.mNormalStart = null;
			this.mStartButton = null;
			this.mTeamButton = null;
			this.mHellroot0 = null;
			this.mHellroot1 = null;
			this.mYg0 = null;
			this.mYg1 = null;
			this.mBosschallengeRoot = null;
			this.mComsumeRoot = null;
			this.mStartRoot = null;
			this.mBindTicketRoot = null;
			this.mTicketRoot = null;
			this.mMissionContent = null;
			this.mFatigueRoot = null;
			this.mMissionInfo = null;
			this.mMissionInfoRoot = null;
			this.mDungeonUnitInfo = null;
			this.mOnSelectLeftButton.onClick.RemoveListener(new UnityAction(this._onOnSelectLeftButtonButtonClick));
			this.mOnSelectLeftButton = null;
			this.mOnSelectRightButton.onClick.RemoveListener(new UnityAction(this._onOnSelectRightButtonButtonClick));
			this.mOnSelectRightButton = null;
			this.mOnReward.onClick.RemoveListener(new UnityAction(this._onOnRewardButtonClick));
			this.mOnReward = null;
			this.mOnRewardRed = null;
			this.mChapterRewardCount = null;
			this.mChapterRewardSum = null;
			this.mOnClose.onClick.RemoveListener(new UnityAction(this._onOnCloseButtonClick));
			this.mOnClose = null;
			this.mMask = null;
			this.mHards[0] = null;
			this.mHards[1] = null;
			this.mHards[2] = null;
			this.mHards[3] = null;
			this.mRedPoint = null;
			this.mRedPointSum = null;
			this.mRewardComplete = null;
			this.mFatigueCombustionRoot = null;
			this.mGroupDrug.onClick.RemoveListener(new UnityAction(this._onSetDrugBtnClick));
			this.mCheckDrug.onValueChanged.RemoveAllListeners();
			this.mGroupDrug = null;
			this.mCheckDrug = null;
			if (null != this.mDropButton)
			{
				this.mDropButton.onClick.RemoveListener(new UnityAction(this._onDropButtonClick));
			}
			this.mDropButton = null;
			this.mDropButtonEffect = null;
			this.mDropProgress = null;
			if (this.mStrategySkillsBtn != null)
			{
				this.mStrategySkillsBtn.onClick.RemoveListener(new UnityAction(this._onmStrategySkillsBtnClick));
			}
			this.mStrategySkillsBtn = null;
			this.StartContinueRoot = null;
			this.StartContinue = null;
			this.mNormalDiffTxt = null;
			this.mDropDetailBtn.SafeRemoveOnClickListener(new UnityAction(this._OnDropDetailBtnClick));
			this.mDropDetailBtn = null;
			this.mNotCostFatigue = null;
			this.mBtNotCostFatigue = null;
			this.mEliteDungeonTipRoot = null;
			this.mSpringFestivalRoot = null;
			this.mRoleNumTxt = null;
			this.mAccountNumTxt = null;
			this.mStartBtnEffectGo = null;
			this.mMoneiesGo = null;
		}

		// Token: 0x0600D355 RID: 54101 RVA: 0x00346910 File Offset: 0x00344D10
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffDrugSettingSubmit, new ClientEventSystem.UIEventHandler(this._onBuffDrugSettingSubmit));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._onUpdateChapterDropProgress));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.UpdateGameOptions, new ClientEventSystem.UIEventHandler(this._onUpdateGameOptions));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateAccounterNum));
		}

		// Token: 0x0600D356 RID: 54102 RVA: 0x0034698C File Offset: 0x00344D8C
		private void _unBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffDrugSettingSubmit, new ClientEventSystem.UIEventHandler(this._onBuffDrugSettingSubmit));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._onUpdateChapterDropProgress));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.UpdateGameOptions, new ClientEventSystem.UIEventHandler(this._onUpdateGameOptions));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.ActivtiyLimitTimeAccounterNumUpdate, new ClientEventSystem.UIEventHandler(this._OnUpdateAccounterNum));
		}

		// Token: 0x0600D357 RID: 54103 RVA: 0x00346A08 File Offset: 0x00344E08
		private void _onBuffDrugSettingSubmit(UIEvent ui)
		{
			if (null == this.mCheckDrug)
			{
				return;
			}
			this.mCheckDrug.isOn = true;
			if (null != this.mChapterInfo)
			{
				this.mChapterInfo.SetBuffDrugsInfo(this.mDungeonTable.BuffDrugConfig);
				this.mChapterInfo.UpDateCost(this.mCheckDrug.isOn, this.mDungeonID);
			}
		}

		// Token: 0x0600D358 RID: 54104 RVA: 0x00346A76 File Offset: 0x00344E76
		private void _onUpdateChapterDropProgress(UIEvent ui)
		{
			if (this.mDungeonID == null)
			{
				return;
			}
			this.UpdateLevelChallengeTimes(this.mDungeonID.dungeonID);
			this.UpdateDropProgress(this.mDungeonID.dungeonID);
		}

		// Token: 0x0600D359 RID: 54105 RVA: 0x00346AA6 File Offset: 0x00344EA6
		private void _onUpdateGameOptions(UIEvent ui)
		{
			this._UpdateFatigueConsume();
			this.bToggleInit = true;
			this.UpdateEliteNotCostFatigueUI();
		}

		// Token: 0x0600D35A RID: 54106 RVA: 0x00346ABC File Offset: 0x00344EBC
		private void _onSetDrugBtnClick()
		{
			if (this.mChapterInfoDrugs != null)
			{
				int sDungeonID = ChapterBaseFrame.sDungeonID;
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterDrugSettingFrame>(FrameLayer.Middle, sDungeonID, string.Empty);
			}
		}

		// Token: 0x0600D35B RID: 54107 RVA: 0x00346AF4 File Offset: 0x00344EF4
		private void _onCheckDrugToggleChanged()
		{
			if (null != this.mCheckDrug)
			{
				if (this.mCheckDrug.isOn)
				{
					DataManager<ChapterBuffDrugManager>.GetInstance().ResetBuffDrugsFromLocal(this.mDungeonTable.BuffDrugConfig);
				}
				else
				{
					DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
				}
			}
			if (null != this.mChapterInfo)
			{
				this.mChapterInfo.UpDateCost(this.mCheckDrug.isOn, this.mDungeonID);
			}
		}

		// Token: 0x0600D35C RID: 54108 RVA: 0x00346B73 File Offset: 0x00344F73
		private void _onTeamStartButtonClick()
		{
			if (!this._getTeamBattleIsLock())
			{
				this._onTeamButton();
			}
			else if (!this._isTeamBattleLevelLimte())
			{
				SystemNotifyManager.SystemNotify(3050, string.Empty);
			}
		}

		// Token: 0x0600D35D RID: 54109 RVA: 0x00346BAC File Offset: 0x00344FAC
		private void _onNormalStartButtonClick()
		{
			if (TeamUtility.IsEliteDungeonID(this.mDungeonID.dungeonID))
			{
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					this._onStartButton();
				}
				else
				{
					LoginToggleMsgBoxOKCancelFrame.TryShowMsgBox(LoginToggleMsgBoxOKCancelFrame.LoginToggleMsgType.EnterEliteDungeonTip, TR.Value("elite_dungeon_need_team"), delegate
					{
						this._onStartButton();
					}, delegate
					{
						this._onTeamButton();
					}, TR.Value("elite_dungeon_need_team_ok_content"), TR.Value("elite_dungeon_need_team_cancel_content"));
				}
			}
			else
			{
				this._onStartButton();
			}
		}

		// Token: 0x0600D35E RID: 54110 RVA: 0x00346C2F File Offset: 0x0034502F
		private void _onHelpButtonClick()
		{
		}

		// Token: 0x0600D35F RID: 54111 RVA: 0x00346C31 File Offset: 0x00345031
		private void _onOnSelectLeftButtonButtonClick()
		{
			this._onLeft();
		}

		// Token: 0x0600D360 RID: 54112 RVA: 0x00346C39 File Offset: 0x00345039
		private void _onOnSelectRightButtonButtonClick()
		{
			this._onRight();
		}

		// Token: 0x0600D361 RID: 54113 RVA: 0x00346C44 File Offset: 0x00345044
		private void _onOnRewardButtonClick()
		{
			if (ChapterBaseFrame.sDungeonID == this.mSpringFestivalDungeonId)
			{
				int num = 0;
				int.TryParse(TR.Value("treasurehunt_activity_id"), out num);
				Singleton<ClientSystemManager>.GetInstance().OpenFrame<LimitTimeActivityFrame>(FrameLayer.Middle, num, string.Empty);
			}
			else if (ChapterSelectFrame.IsCurrentSelectChapterShowReward())
			{
				int currentSelectChapter = ChapterSelectFrame.GetCurrentSelectChapter();
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterRewardFrame>(FrameLayer.Middle, currentSelectChapter, string.Empty);
			}
		}

		// Token: 0x0600D362 RID: 54114 RVA: 0x00346CB8 File Offset: 0x003450B8
		private void _onDropButtonClick()
		{
			ChapterDropProgressFrame chapterDropProgressFrame = Singleton<ClientSystemManager>.instance.OpenFrame<ChapterDropProgressFrame>(FrameLayer.Middle, null, string.Empty) as ChapterDropProgressFrame;
			chapterDropProgressFrame.SetData(this.mDungeonID.dungeonID, this.mAreaIndex);
		}

		// Token: 0x0600D363 RID: 54115 RVA: 0x00346CF3 File Offset: 0x003450F3
		private void _onOnCloseButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNormalHalfFrameClose, null, null, null, null);
		}

		// Token: 0x0600D364 RID: 54116 RVA: 0x00346D08 File Offset: 0x00345108
		private void _onmStrategySkillsBtnClick()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.mDungeonID.dungeonIDWithOutDiff, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			Singleton<ClientSystemManager>.GetInstance().OpenFrame<CheckPointHelpFrame>(FrameLayer.Middle, tableItem.PlayingDescription, string.Empty);
		}

		// Token: 0x0600D365 RID: 54117 RVA: 0x00346D53 File Offset: 0x00345153
		protected sealed override void _loadBg()
		{
		}

		// Token: 0x0600D366 RID: 54118 RVA: 0x00346D58 File Offset: 0x00345158
		protected sealed override void _OnOpenFrame()
		{
			this.bToggleInit = true;
			base._OnOpenFrame();
			this._bindEvents();
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNormalHalfFrameOpen, null, null, null, null);
			this.mTeamStart.CustomActive(Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team));
			DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
			if (DataManager<ChapterBuffDrugManager>.GetInstance().IsBuffDrugToggleOn())
			{
				this.mCheckDrug.isOn = true;
				DataManager<ChapterBuffDrugManager>.GetInstance().ResetBuffDrugsFromLocal(this.mDungeonTable.BuffDrugConfig);
			}
			if (null != this.mChapterInfo)
			{
				this.mChapterInfo.UpDateCost(this.mCheckDrug.isOn, this.mDungeonID);
			}
			this._updateRewardRedPoint();
			this._updateDungeonRewardStatus();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Combine(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.AddSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			this._updateLeftRightSwitchButtonStatus();
			this.SetMask(false);
			this.mFatigueCombustionRoot.CustomActive(false);
			if (this.BIsShowFatigueCombustionGameobject())
			{
				this._InitFatigueCombustionGameObject(this.mFatigueCombustionRoot);
			}
			this.InitStrategySkillsBtn();
			this.SetAnniversayDungeonData();
			this.UpdateEliteNotCostFatigueUI();
			this.SetSpringFestivalData();
		}

		// Token: 0x0600D367 RID: 54119 RVA: 0x00346EA8 File Offset: 0x003452A8
		private void InitStrategySkillsBtn()
		{
			bool bActive = this.StrategySkillsBtnIsShow();
			this.mStrategySkillsBtn.CustomActive(bActive);
		}

		// Token: 0x0600D368 RID: 54120 RVA: 0x00346EC8 File Offset: 0x003452C8
		private bool StrategySkillsBtnIsShow()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.mDungeonID.dungeonIDWithOutDiff, string.Empty, string.Empty);
			return tableItem != null && !(tableItem.PlayingDescription == string.Empty) && tableItem.PlayingDescription != null;
		}

		// Token: 0x0600D369 RID: 54121 RVA: 0x00346F20 File Offset: 0x00345320
		private bool BIsShowFatigueCombustionGameobject()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.mDungeonID.dungeonID, string.Empty, string.Empty);
			if (tableItem != null)
			{
				if (tableItem.ThreeType == DungeonTable.eThreeType.T_T_TEAM_ELITE)
				{
					return false;
				}
				if (tableItem.SubType == DungeonTable.eSubType.S_NORMAL || tableItem.SubType == DungeonTable.eSubType.S_WUDAOHUI)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0600D36A RID: 54122 RVA: 0x00346F7C File Offset: 0x0034537C
		private void _updateLeftRightSwitchButtonStatus()
		{
			ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
			if (chapterSelectFrame != null)
			{
				if (!chapterSelectFrame.IsCanSelectLeftDungeon())
				{
					UIGray uigray = this.mOnSelectLeftButton.gameObject.SafeAddComponent(false);
					uigray.enabled = true;
				}
				if (!chapterSelectFrame.IsCanSelectRightDungeon())
				{
					UIGray uigray2 = this.mOnSelectRightButton.gameObject.SafeAddComponent(false);
					uigray2.enabled = true;
				}
			}
		}

		// Token: 0x0600D36B RID: 54123 RVA: 0x00346FF4 File Offset: 0x003453F4
		protected sealed override void _OnCloseFrame()
		{
			this.bToggleInit = false;
			this._unBindEvents();
			if (DataManager<MissionManager>.GetInstance().onUpdateMission != null)
			{
				MissionManager instance = DataManager<MissionManager>.GetInstance();
				instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
			}
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RemoveSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			if (this.mCheckDrug != null && this.mCheckDrug.isOn)
			{
				DataManager<ChapterBuffDrugManager>.GetInstance().SetBuffDrugToggleState(true);
			}
			else
			{
				DataManager<ChapterBuffDrugManager>.GetInstance().SetBuffDrugToggleState(false);
			}
		}

		// Token: 0x0600D36C RID: 54124 RVA: 0x003470A9 File Offset: 0x003454A9
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600D36D RID: 54125 RVA: 0x003470AC File Offset: 0x003454AC
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.BIsShowFatigueCombustionGameobject())
			{
				this._SetFatigueCombustionTime();
			}
		}

		// Token: 0x0600D36E RID: 54126 RVA: 0x003470BF File Offset: 0x003454BF
		private void _onUpdateMission(uint taskID)
		{
			this._updateRewardRedPoint();
		}

		// Token: 0x0600D36F RID: 54127 RVA: 0x003470C8 File Offset: 0x003454C8
		private void _updateRewardRedPoint()
		{
			int currentSelectChapter = ChapterSelectFrame.GetCurrentSelectChapter();
			bool flag = ChapterUtility.IsChapterCanGetChapterReward(currentSelectChapter);
			this.mOnRewardRed.CustomActive(flag);
			KeyValuePair<int, int> chapterRewardByChapterIdx = ChapterUtility.GetChapterRewardByChapterIdx(currentSelectChapter);
			int chapterCanGetByChapterIdx = ChapterUtility.GetChapterCanGetByChapterIdx(currentSelectChapter);
			if (chapterCanGetByChapterIdx == 0 && chapterRewardByChapterIdx.Key == 0)
			{
				this.mOnRewardRed.CustomActive(false);
				this.mRewardComplete.CustomActive(false);
			}
			else if (chapterCanGetByChapterIdx != 0)
			{
				this.mOnRewardRed.CustomActive(false);
				this.mRedPoint.CustomActive(true);
				this._updateRedPointNum(chapterCanGetByChapterIdx);
				this.mRewardComplete.CustomActive(false);
			}
			else if (chapterCanGetByChapterIdx == 0 && chapterRewardByChapterIdx.Key > 0 && flag)
			{
				this.mOnRewardRed.CustomActive(true);
				this.mRedPoint.CustomActive(false);
				this.mRewardComplete.CustomActive(false);
			}
			else if (chapterCanGetByChapterIdx == 0 && chapterRewardByChapterIdx.Key == chapterRewardByChapterIdx.Value && !flag)
			{
				this.mOnRewardRed.CustomActive(false);
				this.mRedPoint.CustomActive(false);
				this.mRewardComplete.CustomActive(true);
			}
			else
			{
				this.mOnRewardRed.CustomActive(false);
				this.mRedPoint.CustomActive(false);
				this.mRewardComplete.CustomActive(false);
			}
			this.mChapterRewardCount.text = chapterRewardByChapterIdx.Key.ToString();
			this.mChapterRewardSum.text = chapterRewardByChapterIdx.Value.ToString();
			if (ChapterBaseFrame.sDungeonID == this.mSpringFestivalDungeonId)
			{
				this.mOnRewardRed.CustomActive(false);
				this.mRedPoint.CustomActive(false);
				this.mRewardComplete.CustomActive(false);
			}
		}

		// Token: 0x0600D370 RID: 54128 RVA: 0x00347285 File Offset: 0x00345685
		private void _updateDungeonRewardStatus()
		{
			this.mOnReward.gameObject.SetActive(ChapterSelectFrame.IsCurrentSelectChapterShowReward());
		}

		// Token: 0x0600D371 RID: 54129 RVA: 0x0034729C File Offset: 0x0034569C
		private void _updateRedPointNum(int RedPointSum)
		{
			this.mRedPointSum.text = RedPointSum.ToString();
		}

		// Token: 0x0600D372 RID: 54130 RVA: 0x003472B8 File Offset: 0x003456B8
		private void _updateDefaultDiffSelected()
		{
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			int missionDungeonDiff = ChapterUtility.GetMissionDungeonDiff(this.mDungeonID.dungeonID);
			if (missionDungeonDiff >= 0)
			{
				this.mDungeonID.diffID = missionDungeonDiff;
			}
			for (int i = 0; i < 4; i++)
			{
				this.mHards[i].SetActive(missionDungeonDiff == i);
			}
			ChapterBaseFrame.sDungeonID = this.mDungeonID.dungeonID;
			this.mChapterInfoDiffculte.SetDiffculte(this.mDungeonID.diffID, this.mDungeonID.dungeonID);
		}

		// Token: 0x0600D373 RID: 54131 RVA: 0x00347350 File Offset: 0x00345750
		protected override void _loadLeftPanel()
		{
			GlobalEventSystem.GetInstance().SendUIEvent(EUIEventID.EndNewbieGuideCover, null, null, null, null);
			if (null != this.mChapterInfo)
			{
				ComCommonChapterInfo comCommonChapterInfo = this.mChapterInfo;
				this.mChapterInfoCommon = comCommonChapterInfo;
				this.mChapterInfoDiffculte = comCommonChapterInfo;
				this.mChapterInfoDrops = comCommonChapterInfo;
				this.mChapterPassReward = comCommonChapterInfo;
				this.mChapterScore = comCommonChapterInfo;
				this.mChapterProcess = comCommonChapterInfo;
				this.mChapterInfoDrugs = comCommonChapterInfo;
				this.mChapterDungeonMap = comCommonChapterInfo;
				this.mChapterNodeState = comCommonChapterInfo;
				this.mChapterConsume = comCommonChapterInfo;
				this.mChapterMask = comCommonChapterInfo;
				this.mChapterInfo.SetBuffDrugsInfo(this.mDungeonTable.BuffDrugConfig);
			}
			this._updateDefaultDiffSelected();
			this._updateTeamBattleLockState();
			List<eChapterNodeState> list = new List<eChapterNodeState>();
			List<int> list2 = new List<int>();
			List<DungeonScore> list3 = new List<DungeonScore>();
			List<string> list4 = new List<string>();
			int dungeonTopHard = ChapterUtility.GetDungeonTopHard(this.mDungeonID.dungeonIDWithOutDiff);
			DungeonID dungeonID = new DungeonID(this.mDungeonID.dungeonID);
			for (int i = 0; i <= dungeonTopHard; i++)
			{
				dungeonID.diffID = i;
				list3.Add(ChapterUtility.GetDungeonBestScore(dungeonID.dungeonID));
				DungeonTable tableItem = Singleton<TableManager>.instance.GetTableItem<DungeonTable>(dungeonID.dungeonID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					list4.Add(tableItem.RecommendLevel);
					list2.Add(tableItem.MinLevel);
				}
				else
				{
					list4.Add(string.Empty);
					list2.Add(0);
				}
				switch (ChapterUtility.GetDungeonState(dungeonID.dungeonID))
				{
				case ComChapterDungeonUnit.eState.Locked:
					list.Add(eChapterNodeState.Lock);
					break;
				case ComChapterDungeonUnit.eState.Unlock:
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= list2[i])
					{
						list.Add(eChapterNodeState.Unlock);
					}
					else
					{
						list.Add(eChapterNodeState.LockLevel);
					}
					break;
				case ComChapterDungeonUnit.eState.Passed:
				case ComChapterDungeonUnit.eState.LockPassed:
					list.Add(eChapterNodeState.Passed);
					break;
				}
			}
			for (int j = dungeonTopHard + 1; j < 4; j++)
			{
				list.Add(eChapterNodeState.Miss);
			}
			if (this.mChapterInfoCommon != null)
			{
				this.mChapterInfoCommon.SetRecommnedLevel(list4.ToArray());
			}
			if (this.mChapterNodeState != null)
			{
				this.mChapterNodeState.SetChapterScore(list3.ToArray());
				this.mChapterNodeState.SetChapterState(list.ToArray(), list2.ToArray());
			}
			this._updateDungeonMissionInfo();
			this._updateDungeonInfo();
			if (this.mChapterMask != null)
			{
				this.mChapterMask.SetChapterMask(dungeonID.dungeonID);
			}
		}

		// Token: 0x0600D374 RID: 54132 RVA: 0x003475C8 File Offset: 0x003459C8
		private void _updateDungeonMissionInfo()
		{
			this.mMissionInfoRoot.SetActive(false);
			if (ChapterUtility.GetDungeonMissionState(this.mDungeonID.dungeonID))
			{
				int missionIDByDungeonID = (int)ChapterUtility.GetMissionIDByDungeonID(this.mDungeonID.dungeonID);
				this.mMissionInfoRoot.SetActive(true);
				this.mMissionInfo.text = ChapterUtility.GetDungeonMissionInfo(this.mDungeonID.dungeonID);
				this.mDungeonUnitInfo.SetType(ChapterUtility.GetMissionType(missionIDByDungeonID));
				this.mMissionContent.SetText(Utility.ParseMissionText(missionIDByDungeonID, true, false, false), true);
			}
		}

		// Token: 0x0600D375 RID: 54133 RVA: 0x00347654 File Offset: 0x00345A54
		private void _updateDungeonInfo()
		{
			if (this.mDungeonTable != null)
			{
				this.mDungeonUnitInfo.SetBackgroud(this.mDungeonTable.TumbPath);
				this.mDungeonUnitInfo.SetCharactorSprite(this.mDungeonTable.TumbChPath);
				this.mDungeonUnitInfo.SetDungeonID(this.mDungeonTable.ID);
				this.mDungeonUnitInfo.SetName(this.mDungeonTable.Name, this.mDungeonTable.RecommendLevel);
				this.mDungeonUnitInfo.SetState(ChapterUtility.GetDungeonState(this.mDungeonID.dungeonID));
				this.mChapterMask.SetBarState(this.mDungeonID.diffID);
				if (this.mDungeonID.prestoryID > 0)
				{
					this.mDungeonUnitInfo.SetDungeonType(ComChapterDungeonUnit.eDungeonType.Prestory);
				}
				else
				{
					this.mDungeonUnitInfo.SetDungeonType(ComChapterDungeonUnit.eDungeonType.Normal);
				}
				ChapterSelectFrame chapterSelectFrame = Singleton<ClientSystemManager>.instance.GetFrame(typeof(ChapterSelectFrame)) as ChapterSelectFrame;
				if (chapterSelectFrame != null && chapterSelectFrame._GetChapterIndex() == 31)
				{
					this.mDungeonUnitInfo.SetEffect("Effects/UI/Prefab/EffUI_Yijie/Prefab/Eff_UI_YiJie_fangjian");
				}
			}
		}

		// Token: 0x0600D376 RID: 54134 RVA: 0x0034776B File Offset: 0x00345B6B
		protected override void _loadRightPanel()
		{
		}

		// Token: 0x0600D377 RID: 54135 RVA: 0x0034776D File Offset: 0x00345B6D
		protected override void _updateDiffculteInfo()
		{
			base._updateDiffculteInfo();
			this.mChapterInfoDiffculte.SetDiffculteCallback(new ChapterDiffCallback(this._onDiffSelected));
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			this._onDiffSelected(this.mDungeonID.diffID);
		}

		// Token: 0x0600D378 RID: 54136 RVA: 0x003477B0 File Offset: 0x00345BB0
		private bool _getTeamBattleIsLock()
		{
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(this.mDungeonID.dungeonID);
			bool flag = dungeonState == ComChapterDungeonUnit.eState.Locked;
			return !ChapterUtility.IsTeamDungeonID(this.mDungeonID.dungeonID) || flag || this._isTeamBattleLevelLimte();
		}

		// Token: 0x0600D379 RID: 54137 RVA: 0x003477F7 File Offset: 0x00345BF7
		private bool _isTeamBattleLevelLimte()
		{
			return !Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team);
		}

		// Token: 0x0600D37A RID: 54138 RVA: 0x00347803 File Offset: 0x00345C03
		private void _updateTeamBattleLockState()
		{
			this.mTeamButton.enabled = this._getTeamBattleIsLock();
		}

		// Token: 0x0600D37B RID: 54139 RVA: 0x00347818 File Offset: 0x00345C18
		private void _setConsumeMode(DungeonTable.eSubType subType)
		{
			this.mYg0.CustomActive(false);
			this.mYg1.CustomActive(false);
			this.mHellroot0.CustomActive(false);
			this.mHellroot1.CustomActive(false);
			this.mStartRoot.SetActive(true);
			this.mBosschallengeRoot.SetActive(false);
			this.mComsumeRoot.SetActive(true);
			this.mTicketRoot.SetActive(true);
			this.mBindTicketRoot.SetActive(true);
			this.mFatigueRoot.SetActive(true);
			switch (subType)
			{
			case DungeonTable.eSubType.S_HELL:
			case DungeonTable.eSubType.S_HELL_ENTRY:
				break;
			default:
				if (subType != DungeonTable.eSubType.S_ANNIVERSARY_HARD)
				{
					if (subType == DungeonTable.eSubType.S_TREASUREMAP)
					{
						this.mComsumeRoot.SetActive(false);
						return;
					}
					if (subType != DungeonTable.eSubType.S_YUANGU)
					{
						return;
					}
					this.mYg0.CustomActive(true);
					this.mYg1.CustomActive(true);
					this.mTicketRoot.SetActive(false);
					this.mBindTicketRoot.SetActive(false);
					return;
				}
				break;
			case DungeonTable.eSubType.S_TEAM_BOSS:
				this.mBosschallengeRoot.SetActive(true);
				this.mFatigueRoot.SetActive(false);
				this.mComsumeRoot.SetActive(false);
				this.mStartRoot.SetActive(false);
				return;
			}
			this.mHellroot0.CustomActive(true);
			this.mHellroot1.CustomActive(true);
			this.mTicketRoot.SetActive(false);
			this.mBindTicketRoot.SetActive(false);
		}

		// Token: 0x0600D37C RID: 54140 RVA: 0x00347988 File Offset: 0x00345D88
		private void _onDiffSelected(int idx)
		{
			this.mDungeonID.diffID = idx;
			int dungeonID = this.mDungeonID.dungeonID;
			base._loadTableData();
			this._updateScore();
			this._updateTeamBattleLockState();
			this._updateDungeonMissionInfo();
			this._updateDungeonInfo();
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(dungeonID);
			bool flag = dungeonState == ComChapterDungeonUnit.eState.Locked;
			this.mChapterInfoDiffculte.SetLock(flag);
			this.mChapterInfoDiffculte.SetDiffculte(this.mChapterInfoDiffculte.GetDiffculte(), this.mDungeonID.dungeonID);
			this.mStartButton.enabled = flag;
			bool flag2 = dungeonState == ComChapterDungeonUnit.eState.Passed;
			this.mChapterScore.SetPassed(flag2);
			if (flag2)
			{
				this.mChapterScore.SetBestScore(ChapterUtility.GetDungeonBestScore(dungeonID));
			}
			this._setConsumeMode(this.mDungeonTable.SubType);
			if (this.mChapterConsume != null)
			{
				this.mChapterConsume.SetFatigueConsume(this.mDungeonTable.CostFatiguePerArea * this.mDungeonTable.MostCostStamina, this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY, this.mDungeonTable.ID);
				ItemTable tableItem = Singleton<TableManager>.instance.GetTableItem<ItemTable>(this.mDungeonTable.TicketID, string.Empty, string.Empty);
				if (tableItem != null)
				{
					this.mChapterConsume.SetHellConsume(tableItem.Name, this.mDungeonTable.TicketNum, tableItem.Icon, this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL);
				}
				else
				{
					this.mChapterConsume.SetHellConsume(string.Empty, 0, null, this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL);
				}
			}
			if (this.mChapterInfoDrops != null)
			{
				this.mChapterInfoDrops.SetDropList(this.mDungeonTable.DropItems, this.mDungeonTable.ID);
			}
			this.UpdateLevelResistValue(dungeonID);
			this.UpdateLevelChallengeTimes(dungeonID);
			this.UpdateDropProgress(dungeonID);
			if (ChapterNormalHalfFrame.IsYiJieDungeon(this.mDungeonID.dungeonID))
			{
				bool flag3 = ChapterNormalHalfFrame.IsCurrentDungeonInChallenge();
				bool flag4 = !flag && flag3;
				this.StartContinueRoot.CustomActive(flag4);
				this.mStartRoot.CustomActive(!flag4);
			}
		}

		// Token: 0x0600D37D RID: 54141 RVA: 0x00347B98 File Offset: 0x00345F98
		private void UpdateLevelResistValue(int dungeonId)
		{
			int dungeonResistMagicValueById = DungeonUtility.GetDungeonResistMagicValueById(dungeonId);
			if (dungeonResistMagicValueById <= 0)
			{
				this.mLevelResistValueRoot.gameObject.CustomActive(false);
			}
			else
			{
				this.mLevelResistValueRoot.gameObject.CustomActive(true);
				this.mLevelResistValueNumber.text = dungeonResistMagicValueById.ToString();
				int dungeonMainPlayerResistMagicValue = DungeonUtility.GetDungeonMainPlayerResistMagicValue();
				int mainPlayerResistAddByBuff = BeUtility.GetMainPlayerResistAddByBuff();
				if (mainPlayerResistAddByBuff == 0)
				{
					if (dungeonResistMagicValueById > dungeonMainPlayerResistMagicValue)
					{
						this.mOwnerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_less"), dungeonMainPlayerResistMagicValue);
					}
					else
					{
						this.mOwnerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_normal"), dungeonMainPlayerResistMagicValue);
					}
				}
				else
				{
					int num = dungeonMainPlayerResistMagicValue - mainPlayerResistAddByBuff;
					if (dungeonResistMagicValueById > num)
					{
						this.mOwnerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_add_buff_less"), num, mainPlayerResistAddByBuff);
					}
					else
					{
						this.mOwnerResistValueNumber.text = string.Format(TR.Value("resist_magic_value_add_buff_normal"), num, mainPlayerResistAddByBuff);
					}
				}
				if (DataManager<TeamDataManager>.GetInstance().HasTeam())
				{
					DungeonUtility.ShowResistMagicValueTips(dungeonResistMagicValueById);
				}
			}
		}

		// Token: 0x0600D37E RID: 54142 RVA: 0x00347CC8 File Offset: 0x003460C8
		private int _getLeftTimes()
		{
			int dungeonDailyFinishedTimes = DungeonUtility.GetDungeonDailyFinishedTimes(this.mDungeonID.dungeonID);
			int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(this.mDungeonID.dungeonID);
			int num = dungeonDailyMaxTimes - dungeonDailyFinishedTimes;
			if (num < 0)
			{
				num = 0;
			}
			return num;
		}

		// Token: 0x0600D37F RID: 54143 RVA: 0x00347D08 File Offset: 0x00346108
		private void UpdateLevelChallengeTimes(int dungeonId)
		{
			if (this.mlevelChallengeTimesRoot == null)
			{
				return;
			}
			int dungeonDailyBaseTimes = DungeonUtility.GetDungeonDailyBaseTimes(dungeonId);
			if (dungeonDailyBaseTimes <= 0)
			{
				this.mlevelChallengeTimesRoot.CustomActive(false);
			}
			else
			{
				this.mlevelChallengeTimesRoot.CustomActive(true);
				if (this.mLevelChallengeTimesNumber != null)
				{
					int num = this._getLeftTimes();
					this.mLevelChallengeTimesNumber.text = string.Format(TR.Value("resist_magic_challenge_times"), num, dungeonDailyBaseTimes);
				}
				if (this.mRebornLimitNumberValue != null)
				{
					this.mRebornLimitNumberValue.text = DungeonUtility.GetDungeonRebornNumber(dungeonId);
				}
			}
			if (ChapterBaseFrame.sDungeonID == this.mSpringFestivalDungeonId)
			{
				this.mlevelChallengeTimesRoot.CustomActive(false);
			}
		}

		// Token: 0x0600D380 RID: 54144 RVA: 0x00347DD0 File Offset: 0x003461D0
		private void UpdateEliteNotCostFatigueUI()
		{
			this.mNotCostFatigue.CustomActive(TeamUtility.IsEliteDungeonID(this.mDungeonID.dungeonID));
			this.mBtNotCostFatigue.SafeSetToggleOnState(DataManager<TeamDataManager>.GetInstance().IsNotCostFatigueInEliteDungeon);
			this.bToggleInit = false;
			this.mBtNotCostFatigue.SafeSetGray(DataManager<TeamDataManager>.GetInstance().GetMemberNum() == 0, false);
			this.mEliteDungeonTipRoot.CustomActive(TeamUtility.IsEliteDungeonID(this.mDungeonID.dungeonID));
		}

		// Token: 0x0600D381 RID: 54145 RVA: 0x00347E48 File Offset: 0x00346248
		private void UpdateDropProgress(int dungeonId)
		{
			if (this.mDropProgress == null)
			{
				return;
			}
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonId, string.Empty, string.Empty);
			if (tableItem == null)
			{
				return;
			}
			if (tableItem.SubType != DungeonTable.eSubType.S_DEVILDDOM)
			{
				this.mDropProgress.CustomActive(false);
			}
			else
			{
				this.mDropProgress.CustomActive(true);
				MonoSingleton<GameFrameWork>.instance.StartCoroutine(this._onWorldDungeonGetAreaIndex());
			}
		}

		// Token: 0x0600D382 RID: 54146 RVA: 0x00347EC0 File Offset: 0x003462C0
		private IEnumerator _onWorldDungeonGetAreaIndex()
		{
			WorldDungeonGetAreaIndexReq req = new WorldDungeonGetAreaIndexReq();
			req.dungeonId = (uint)this.mDungeonID.dungeonID;
			WorldDungeonGetAreaIndexRes res = new WorldDungeonGetAreaIndexRes();
			MessageEvents msg = new MessageEvents();
			yield return MessageUtility.Wait<WorldDungeonGetAreaIndexReq, WorldDungeonGetAreaIndexRes>(ServerType.GATE_SERVER, msg, req, res, false, 20f);
			if (msg.IsAllMessageReceived())
			{
				this.mAreaIndex = res.areaIndex >> 1;
				this.mDropButtonEffect.CustomActive(this.mAreaIndex > 0U);
			}
			yield break;
		}

		// Token: 0x0600D383 RID: 54147 RVA: 0x00347EDC File Offset: 0x003462DC
		private void _onTeamButton()
		{
			int diffID = 0;
			if (this.mChapterInfoDiffculte != null)
			{
				diffID = this.mChapterInfoDiffculte.GetDiffculte();
			}
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			this.mDungeonID.diffID = diffID;
			Utility.OpenTeamFrame(this.mDungeonID.dungeonID);
		}

		// Token: 0x0600D384 RID: 54148 RVA: 0x00347F30 File Offset: 0x00346330
		public static bool IsYiJieDungeon(int dungeonID)
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(dungeonID, string.Empty, string.Empty);
			return tableItem != null && tableItem.SubType == DungeonTable.eSubType.S_DEVILDDOM;
		}

		// Token: 0x0600D385 RID: 54149 RVA: 0x00347F68 File Offset: 0x00346368
		public static bool IsCurrentDungeonInChallenge()
		{
			DungeonID dungeonID = new DungeonID(ChapterBaseFrame.sDungeonID);
			if (dungeonID != null)
			{
				dungeonID.diffID = 0;
				return ChapterSelectFrame.IsInChallenge(dungeonID.dungeonID);
			}
			return false;
		}

		// Token: 0x0600D386 RID: 54150 RVA: 0x00347F9C File Offset: 0x0034639C
		private void _onStartButton()
		{
			if (this.mDropProgress != null && this.mDropProgress.activeSelf && this._getLeftTimes() <= 0)
			{
				if (!ChapterNormalHalfFrame.IsYiJieDungeon(this.mDungeonID.dungeonID) || !ChapterNormalHalfFrame.IsCurrentDungeonInChallenge())
				{
					this._usePassItem();
					return;
				}
			}
			if (DataManager<TeamDataManager>.GetInstance().HasTeam())
			{
				int diffID = 0;
				if (this.mChapterInfoDiffculte != null)
				{
					diffID = this.mChapterInfoDiffculte.GetDiffculte();
				}
				this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
				this.mDungeonID.diffID = diffID;
				if (!DataManager<TeamDataManager>.GetInstance().IsTeamLeader())
				{
					SystemNotifyManager.SystemNotify(1105, string.Empty);
					return;
				}
				int iTeamDungeonTableID = 0;
				if (!Utility.CheckIsTeamDungeon(this.mDungeonID.dungeonID, ref iTeamDungeonTableID))
				{
					SystemNotifyManager.SystemNotify(1106, string.Empty);
					return;
				}
				if (!Utility.CheckTeamEnterDungeonCondition(iTeamDungeonTableID))
				{
					return;
				}
			}
			string empty = string.Empty;
			bool flag = DungeonUtility.IsShowDungeonResistMagicValueTip(this.mDungeonID.dungeonID, ref empty);
			if (flag)
			{
				ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(this.mDungeonID.dungeonID);
				if (dungeonState != ComChapterDungeonUnit.eState.Locked)
				{
					SystemNotifyManager.SysNotifyMsgBoxCancelOk(empty, null, new UnityAction(this.MessageBoxOKCallBack), 0f, false, null);
					return;
				}
			}
			bool flag2 = DataManager<SkillDataManager>.GetInstance().IsShowSkillTreeFrameTipBySkillConfig(new Action(this.MessageBoxOKCallBack));
			if (flag2)
			{
				return;
			}
			ChapterUtility.OpenComsumeFatigueAddFrame(ChapterBaseFrame.sDungeonID);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x0600D387 RID: 54151 RVA: 0x00348136 File Offset: 0x00346536
		private void MessageBoxOKCallBack()
		{
			ChapterUtility.OpenComsumeFatigueAddFrame(ChapterBaseFrame.sDungeonID);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x0600D388 RID: 54152 RVA: 0x00348154 File Offset: 0x00346554
		private void _onLeft()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNextDungeon, true, null, null, null);
		}

		// Token: 0x0600D389 RID: 54153 RVA: 0x0034816E File Offset: 0x0034656E
		private void _onRight()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNextDungeon, false, null, null, null);
		}

		// Token: 0x0600D38A RID: 54154 RVA: 0x00348188 File Offset: 0x00346588
		private void _usePassItem()
		{
			bool flag = false;
			foreach (int num in new int[]
			{
				800000798,
				330000200,
				330000194
			})
			{
				if (DataManager<ItemDataManager>.GetInstance().GetOwnedItemCount(num, true) >= 1)
				{
					ItemData item = DataManager<ItemDataManager>.GetInstance().GetItemByTableID(num, true, true);
					if (item != null)
					{
						if (item.GetCurrentRemainUseTime() > 0)
						{
							SystemNotifyManager.SysNotifyMsgBoxOkCancel(TR.Value("drop_progress_challenge_times_not_enough_has_item"), delegate()
							{
								DataManager<ItemDataManager>.GetInstance().UseItemWithoutDoubleCheck(item, false, 0, 0);
							}, null, 0f, false);
							return;
						}
						flag = true;
					}
				}
			}
			if (flag)
			{
				SystemNotifyManager.SystemNotify(1226, string.Empty);
			}
			else
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guild_redpacket_has_no_cost_time"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			}
		}

		// Token: 0x0600D38B RID: 54155 RVA: 0x00348262 File Offset: 0x00346662
		public void SetMask(bool enabled)
		{
			if (this.mMask != null)
			{
				this.mMask.SetActive(enabled);
			}
		}

		// Token: 0x0600D38C RID: 54156 RVA: 0x00348284 File Offset: 0x00346684
		private void SetAnniversayDungeonData()
		{
			if (this.mAniversaryPartyDungeonIdList[1] == ChapterBaseFrame.sDungeonID)
			{
				this.mStartButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(240f, 64f);
				this.StartContinueRoot.GetComponent<RectTransform>().anchoredPosition = new Vector2(240f, 64f);
				this.mTeamButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-240f, 64f);
				this.mComsumeRoot.GetComponent<RectTransform>().anchoredPosition = new Vector2(326.5f, -153f);
				this.mlevelChallengeTimesRoot.GetComponent<RectTransform>().anchoredPosition = new Vector2(276f, -188f);
			}
			else if (this.mAniversaryPartyDungeonIdList[0] == ChapterBaseFrame.sDungeonID)
			{
				this.mStartButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(240f, 64f);
				this.StartContinueRoot.GetComponent<RectTransform>().anchoredPosition = new Vector2(240f, 64f);
				this.mTeamButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-240f, 64f);
				this.mComsumeRoot.GetComponent<RectTransform>().anchoredPosition = new Vector2(326.5f, -163f);
			}
			if (this.mAniversaryPartyDungeonIdList.Contains(ChapterBaseFrame.sDungeonID))
			{
				this.mOnReward.CustomActive(false);
				this.mNormalDiffTxt.SafeSetText(TR.Value("AnniversaryParty_Normall_Diff_Des"));
				this.mDropDetailBtn.CustomActive(true);
			}
			else
			{
				this.mDropDetailBtn.CustomActive(false);
			}
		}

		// Token: 0x0600D38D RID: 54157 RVA: 0x0034842C File Offset: 0x0034682C
		private void SetSpringFestivalData()
		{
			if (ChapterBaseFrame.sDungeonID == this.mSpringFestivalDungeonId)
			{
				this.mSpringFestivalRoot.CustomActive(true);
				this.mNormalDiffTxt.SafeSetText(TR.Value("AnniversaryParty_Normall_Diff_Des"));
				this.mStartButton.GetComponent<RectTransform>().anchoredPosition = new Vector2(-2f, 25f);
				DataManager<ActivityDataManager>.GetInstance().SendSceneOpActivityGetCounterReq((int)this.mDungeonTable.SubType);
				this.mTeamStart.CustomActive(false);
				this.mComsumeRoot.CustomActive(false);
				this.mEliteDungeonTipRoot.CustomActive(false);
				this.mNotCostFatigue.CustomActive(false);
				this.mlevelChallengeTimesRoot.CustomActive(false);
				this.mOnSelectLeftButton.CustomActive(false);
				this.mOnSelectRightButton.CustomActive(false);
				this.mMoneiesGo.CustomActive(false);
				this.mStartButton.CustomActive(false);
			}
			else
			{
				this.mSpringFestivalRoot.CustomActive(false);
			}
		}

		// Token: 0x0600D38E RID: 54158 RVA: 0x0034851C File Offset: 0x0034691C
		private void _OnUpdateAccounterNum(UIEvent uiEvent)
		{
			if ((ulong)((uint)uiEvent.Param1) == (ulong)((long)this.mDungeonTable.SubType))
			{
				int num = DungeonUtility.GetDungeonDailyLeftTimes(ChapterBaseFrame.sDungeonID);
				int dungeonDailyMaxTimes = DungeonUtility.GetDungeonDailyMaxTimes(ChapterBaseFrame.sDungeonID);
				int num2 = 0;
				int num3 = (int)DataManager<ActivityDataManager>.GetInstance().GetActivityConunter((int)this.mDungeonTable.SubType);
				DungeonTimesTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTimesTable>((int)this.mDungeonTable.SubType, string.Empty, string.Empty);
				if (tableItem != null)
				{
					num2 = tableItem.AccountDailyTimesLimit;
				}
				else
				{
					Logger.LogErrorFormat(string.Format("加载地下城次数表为null id=", (int)this.mDungeonTable.SubType), new object[0]);
				}
				if (num3 >= num2)
				{
					num3 = num2;
				}
				int num4 = num2 - num3;
				if (num4 <= num)
				{
					num = num4;
				}
				if (num4 <= 0)
				{
					num4 = 0;
					this.mNormalStart.interactable = false;
					this.mStartButton.enabled = true;
					this.mStartBtnEffectGo.CustomActive(false);
				}
				else if (num <= 0)
				{
					num = 0;
					this.mNormalStart.interactable = false;
					this.mStartButton.enabled = true;
					this.mStartBtnEffectGo.CustomActive(false);
				}
				else
				{
					this.mNormalStart.interactable = true;
					this.mStartButton.enabled = false;
					this.mStartBtnEffectGo.CustomActive(true);
				}
				this.mStartButton.CustomActive(true);
				this.mAccountNumTxt.SafeSetText(string.Format(TR.Value("AccountChallengeTimers_Tip", num4, num2), new object[0]));
				this.mRoleNumTxt.SafeSetText(TR.Value("RoleChallengeTimers_Tip", num, dungeonDailyMaxTimes));
			}
		}

		// Token: 0x0600D38F RID: 54159 RVA: 0x003486CB File Offset: 0x00346ACB
		private void _OnDropDetailBtnClick()
		{
			ChallengeUtility.OnOpenChallengeDropDetailFrame(ChapterBaseFrame.sDungeonID);
		}

		// Token: 0x0600D390 RID: 54160 RVA: 0x003486D8 File Offset: 0x00346AD8
		private void _InitFatigueCombustionGameObject(GameObject mFatigueCombustionRoot)
		{
			DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.FindFatigueCombustionActivityIsOpen(ref this.mBisFlag, ref this.data);
			if (this.mBisFlag && this.data != null)
			{
				mFatigueCombustionRoot.CustomActive(true);
				this._InitFatigueCombustionInfo(mFatigueCombustionRoot, this.data);
			}
			else
			{
				mFatigueCombustionRoot.CustomActive(false);
			}
		}

		// Token: 0x0600D391 RID: 54161 RVA: 0x00348738 File Offset: 0x00346B38
		private void _InitFatigueCombustionInfo(GameObject go, ActivityLimitTimeData activityData)
		{
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			uint activityId = activityData.DataId;
			Text com = component.GetCom<Text>("Time");
			Button com2 = component.GetCom<Button>("Open");
			Button com3 = component.GetCom<Button>("Stop");
			GameObject gameObject = component.GetGameObject("OrdinaryName");
			GameObject gameObject2 = component.GetGameObject("SeniorName");
			SetButtonGrayCD mCDGray = component.GetCom<SetButtonGrayCD>("CDGray");
			gameObject.CustomActive(false);
			gameObject2.CustomActive(false);
			for (int i = 0; i < activityData.activityDetailDataList.Count; i++)
			{
				if (activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.Init && activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.UnFinish)
				{
					this.mData = activityData.activityDetailDataList[i];
					uint mTaskId = this.mData.DataId;
					string text = mTaskId.ToString();
					string s = text.Substring(text.Length - 1);
					int num = 0;
					if (int.TryParse(s, out num))
					{
						if (num == 1)
						{
							gameObject.CustomActive(true);
							gameObject2.CustomActive(false);
						}
						else
						{
							gameObject2.CustomActive(true);
							gameObject.CustomActive(false);
						}
					}
					com2.onClick.RemoveAllListeners();
					com2.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, mTaskId);
						mCDGray.StartGrayCD();
					});
					com3.onClick.RemoveAllListeners();
					com3.onClick.AddListener(delegate()
					{
						DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RequestOnTakeActTask(activityId, mTaskId);
						mCDGray.StartGrayCD();
					});
					this._UpdateFatigueCombustionData(go, this.mData, true);
					if (activityData.activityDetailDataList[i].ActivityDetailState != ActivityTaskState.Failed)
					{
						return;
					}
				}
			}
		}

		// Token: 0x0600D392 RID: 54162 RVA: 0x00348928 File Offset: 0x00346D28
		private void _UpdateFatigueCombustionData(GameObject go, ActivityLimitTimeDetailData activityData, bool isInit = true)
		{
			if (go == null || activityData == null)
			{
				return;
			}
			ComCommonBind component = go.GetComponent<ComCommonBind>();
			if (component == null)
			{
				return;
			}
			this.mTime = component.GetCom<Text>("Time");
			Button com = component.GetCom<Button>("Open");
			Button com2 = component.GetCom<Button>("Stop");
			com.CustomActive(false);
			com2.CustomActive(false);
			this.mFatigueCombustionTimeIsOpen = false;
			switch (activityData.ActivityDetailState)
			{
			case ActivityTaskState.Init:
			case ActivityTaskState.UnFinish:
				if (this.mChapterInfo != null)
				{
					this.mChapterInfo.mComChapterInfoDrop.RefreshFaFatigueCombustionBuff();
				}
				this._UpdateFatigueConsume();
				break;
			case ActivityTaskState.Finished:
				com2.CustomActive(true);
				this.mFatigueCombustionTimeIsOpen = true;
				this.mFatigueCombustionTime = this.mData.DoneNum;
				if (this.mChapterInfoDrops != null)
				{
					this.mChapterInfoDrops.SetDropList(this.mDungeonTable.DropItems, this.mDungeonTable.ID);
				}
				this._UpdateFatigueConsume();
				break;
			case ActivityTaskState.Failed:
				this.mTime.text = Function.GetLastsTimeStr((double)this.mData.DoneNum);
				com.CustomActive(true);
				if (isInit)
				{
					if (this.mChapterInfoDrops != null)
					{
						this.mChapterInfoDrops.SetDropList(this.mDungeonTable.DropItems, this.mDungeonTable.ID);
					}
				}
				else if (this.mChapterInfo != null)
				{
					this.mChapterInfo.mComChapterInfoDrop.RefreshFaFatigueCombustionBuff();
				}
				this._UpdateFatigueConsume();
				break;
			}
		}

		// Token: 0x0600D393 RID: 54163 RVA: 0x00348AC4 File Offset: 0x00346EC4
		private void _UpdateFatigueConsume()
		{
			if (this.mChapterConsume != null)
			{
				this.mChapterConsume.SetFatigueConsume(this.mDungeonTable.CostFatiguePerArea * this.mDungeonTable.MostCostStamina, this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY, this.mDungeonTable.ID);
			}
		}

		// Token: 0x0600D394 RID: 54164 RVA: 0x00348B18 File Offset: 0x00346F18
		private void _SetFatigueCombustionTime()
		{
			if (this.mFatigueCombustionTimeIsOpen && this.mTime != null)
			{
				if (this.mFatigueCombustionTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime() > 0)
				{
					this.mTime.text = Function.GetLastsTimeStr((double)(this.mFatigueCombustionTime - (int)DataManager<TimeManager>.GetInstance().GetServerTime()));
				}
				else
				{
					this.mFatigueCombustionRoot.CustomActive(false);
				}
			}
		}

		// Token: 0x0600D395 RID: 54165 RVA: 0x00348B8B File Offset: 0x00346F8B
		private void _OnTaskChange()
		{
			this._UpdateFatigueCombustionData(this.mFatigueCombustionRoot, this.mData, false);
		}

		// Token: 0x04007BB2 RID: 31666
		private bool mBisFlag;

		// Token: 0x04007BB3 RID: 31667
		private ActivityLimitTimeData data;

		// Token: 0x04007BB4 RID: 31668
		private ActivityLimitTimeDetailData mData;

		// Token: 0x04007BB5 RID: 31669
		private bool mFatigueCombustionTimeIsOpen;

		// Token: 0x04007BB6 RID: 31670
		private Text mTime;

		// Token: 0x04007BB7 RID: 31671
		private int mFatigueCombustionTime = -1;

		// Token: 0x04007BB8 RID: 31672
		private uint mAreaIndex;

		// Token: 0x04007BB9 RID: 31673
		private bool bToggleInit;

		// Token: 0x04007BBA RID: 31674
		private List<int> mAniversaryPartyDungeonIdList = new List<int>
		{
			6511000,
			6512000
		};

		// Token: 0x04007BBB RID: 31675
		private int mSpringFestivalDungeonId = 6521000;

		// Token: 0x04007BBC RID: 31676
		private GameObject mlevelChallengeTimesRoot;

		// Token: 0x04007BBD RID: 31677
		private Text mRebornLimitNumberValue;

		// Token: 0x04007BBE RID: 31678
		private Text mLevelChallengeTimesNumber;

		// Token: 0x04007BBF RID: 31679
		private GameObject mLevelResistValueRoot;

		// Token: 0x04007BC0 RID: 31680
		private Text mLevelResistValueLabel;

		// Token: 0x04007BC1 RID: 31681
		private Text mLevelResistValueNumber;

		// Token: 0x04007BC2 RID: 31682
		private Text mOwnerResistValueLabel;

		// Token: 0x04007BC3 RID: 31683
		private Text mOwnerResistValueNumber;

		// Token: 0x04007BC4 RID: 31684
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04007BC5 RID: 31685
		private Button mTeamStart;

		// Token: 0x04007BC6 RID: 31686
		private Button mNormalStart;

		// Token: 0x04007BC7 RID: 31687
		private UIGray mStartButton;

		// Token: 0x04007BC8 RID: 31688
		private UIGray mTeamButton;

		// Token: 0x04007BC9 RID: 31689
		private GameObject mHellroot0;

		// Token: 0x04007BCA RID: 31690
		private GameObject mHellroot1;

		// Token: 0x04007BCB RID: 31691
		private GameObject mYg0;

		// Token: 0x04007BCC RID: 31692
		private GameObject mYg1;

		// Token: 0x04007BCD RID: 31693
		private GameObject mBosschallengeRoot;

		// Token: 0x04007BCE RID: 31694
		private GameObject mComsumeRoot;

		// Token: 0x04007BCF RID: 31695
		private GameObject mStartRoot;

		// Token: 0x04007BD0 RID: 31696
		private GameObject mBindTicketRoot;

		// Token: 0x04007BD1 RID: 31697
		private GameObject mTicketRoot;

		// Token: 0x04007BD2 RID: 31698
		private LinkParse mMissionContent;

		// Token: 0x04007BD3 RID: 31699
		private GameObject mFatigueRoot;

		// Token: 0x04007BD4 RID: 31700
		private Text mMissionInfo;

		// Token: 0x04007BD5 RID: 31701
		private GameObject mMissionInfoRoot;

		// Token: 0x04007BD6 RID: 31702
		private ComChapterDungeonUnit mDungeonUnitInfo;

		// Token: 0x04007BD7 RID: 31703
		private Button mOnSelectLeftButton;

		// Token: 0x04007BD8 RID: 31704
		private Button mOnSelectRightButton;

		// Token: 0x04007BD9 RID: 31705
		private Button mOnReward;

		// Token: 0x04007BDA RID: 31706
		private GameObject mOnRewardRed;

		// Token: 0x04007BDB RID: 31707
		private Text mChapterRewardCount;

		// Token: 0x04007BDC RID: 31708
		private Text mChapterRewardSum;

		// Token: 0x04007BDD RID: 31709
		private Button mOnClose;

		// Token: 0x04007BDE RID: 31710
		private GameObject mMask;

		// Token: 0x04007BDF RID: 31711
		private GameObject[] mHards = new GameObject[4];

		// Token: 0x04007BE0 RID: 31712
		private GameObject mRedPoint;

		// Token: 0x04007BE1 RID: 31713
		private Text mRedPointSum;

		// Token: 0x04007BE2 RID: 31714
		private GameObject mRewardComplete;

		// Token: 0x04007BE3 RID: 31715
		private GameObject mFatigueCombustionRoot;

		// Token: 0x04007BE4 RID: 31716
		private Button mGroupDrug;

		// Token: 0x04007BE5 RID: 31717
		private Toggle mCheckDrug;

		// Token: 0x04007BE6 RID: 31718
		private Button mDropButton;

		// Token: 0x04007BE7 RID: 31719
		private GameObject mDropButtonEffect;

		// Token: 0x04007BE8 RID: 31720
		private GameObject mDropProgress;

		// Token: 0x04007BE9 RID: 31721
		private Button mStrategySkillsBtn;

		// Token: 0x04007BEA RID: 31722
		private GameObject StartContinueRoot;

		// Token: 0x04007BEB RID: 31723
		private Button StartContinue;

		// Token: 0x04007BEC RID: 31724
		private Text mNormalDiffTxt;

		// Token: 0x04007BED RID: 31725
		private Button mDropDetailBtn;

		// Token: 0x04007BEE RID: 31726
		private GameObject mNotCostFatigue;

		// Token: 0x04007BEF RID: 31727
		private Toggle mBtNotCostFatigue;

		// Token: 0x04007BF0 RID: 31728
		private GameObject mEliteDungeonTipRoot;

		// Token: 0x04007BF1 RID: 31729
		private GameObject mSpringFestivalRoot;

		// Token: 0x04007BF2 RID: 31730
		private Text mRoleNumTxt;

		// Token: 0x04007BF3 RID: 31731
		private Text mAccountNumTxt;

		// Token: 0x04007BF4 RID: 31732
		private GameObject mStartBtnEffectGo;

		// Token: 0x04007BF5 RID: 31733
		private GameObject mMoneiesGo;
	}
}
