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
	// Token: 0x02001617 RID: 5655
	public class GuildDungeonCityInfoFrame : ChapterBaseFrame
	{
		// Token: 0x0600DDAC RID: 56748 RVA: 0x0038362D File Offset: 0x00381A2D
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Guild/GuildDungeonCityInfo";
		}

		// Token: 0x0600DDAD RID: 56749 RVA: 0x00383634 File Offset: 0x00381A34
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
			this.BOSS = this.mBind.GetCom<BossGuildDungeon>("BOSS");
			this.Medium0 = this.mBind.GetCom<MediumGuildDungeon>("Medium0");
			this.Junior0 = this.mBind.GetCom<JuniorGuildDungeon>("Junior0");
		}

		// Token: 0x0600DDAE RID: 56750 RVA: 0x00383BB8 File Offset: 0x00381FB8
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
			this.BOSS = null;
			this.Medium0 = null;
			this.Junior0 = null;
		}

		// Token: 0x0600DDAF RID: 56751 RVA: 0x00383E33 File Offset: 0x00382233
		private void _bindEvents()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.BuffDrugSettingSubmit, new ClientEventSystem.UIEventHandler(this._onBuffDrugSettingSubmit));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._onUpdateChapterDropProgress));
		}

		// Token: 0x0600DDB0 RID: 56752 RVA: 0x00383E6B File Offset: 0x0038226B
		private void _unBindEvents()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.BuffDrugSettingSubmit, new ClientEventSystem.UIEventHandler(this._onBuffDrugSettingSubmit));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.CounterChanged, new ClientEventSystem.UIEventHandler(this._onUpdateChapterDropProgress));
		}

		// Token: 0x0600DDB1 RID: 56753 RVA: 0x00383EA4 File Offset: 0x003822A4
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

		// Token: 0x0600DDB2 RID: 56754 RVA: 0x00383F12 File Offset: 0x00382312
		private void _onUpdateChapterDropProgress(UIEvent ui)
		{
			if (this.mDungeonID == null)
			{
				return;
			}
			this.UpdateLevelChallengeTimes(this.mDungeonID.dungeonID);
			this.UpdateDropProgress(this.mDungeonID.dungeonID);
		}

		// Token: 0x0600DDB3 RID: 56755 RVA: 0x00383F44 File Offset: 0x00382344
		private void _onSetDrugBtnClick()
		{
			if (this.mChapterInfoDrugs != null)
			{
				int sDungeonID = ChapterBaseFrame.sDungeonID;
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterDrugSettingFrame>(FrameLayer.Middle, sDungeonID, string.Empty);
			}
		}

		// Token: 0x0600DDB4 RID: 56756 RVA: 0x00383F7C File Offset: 0x0038237C
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

		// Token: 0x0600DDB5 RID: 56757 RVA: 0x00383FFB File Offset: 0x003823FB
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

		// Token: 0x0600DDB6 RID: 56758 RVA: 0x00384032 File Offset: 0x00382432
		private void _onNormalStartButtonClick()
		{
			this._onStartButton();
		}

		// Token: 0x0600DDB7 RID: 56759 RVA: 0x0038403A File Offset: 0x0038243A
		private void _onHelpButtonClick()
		{
		}

		// Token: 0x0600DDB8 RID: 56760 RVA: 0x0038403C File Offset: 0x0038243C
		private void _onOnSelectLeftButtonButtonClick()
		{
			this._onLeft();
		}

		// Token: 0x0600DDB9 RID: 56761 RVA: 0x00384044 File Offset: 0x00382444
		private void _onOnSelectRightButtonButtonClick()
		{
			this._onRight();
		}

		// Token: 0x0600DDBA RID: 56762 RVA: 0x0038404C File Offset: 0x0038244C
		private void _onOnRewardButtonClick()
		{
			if (ChapterSelectFrame.IsCurrentSelectChapterShowReward())
			{
				int currentSelectChapter = ChapterSelectFrame.GetCurrentSelectChapter();
				Singleton<ClientSystemManager>.instance.OpenFrame<ChapterRewardFrame>(FrameLayer.Middle, currentSelectChapter, string.Empty);
			}
		}

		// Token: 0x0600DDBB RID: 56763 RVA: 0x00384080 File Offset: 0x00382480
		private void _onDropButtonClick()
		{
			ChapterDropProgressFrame chapterDropProgressFrame = Singleton<ClientSystemManager>.instance.OpenFrame<ChapterDropProgressFrame>(FrameLayer.Middle, null, string.Empty) as ChapterDropProgressFrame;
			chapterDropProgressFrame.SetData(this.mDungeonID.dungeonID, this.mAreaIndex);
		}

		// Token: 0x0600DDBC RID: 56764 RVA: 0x003840BB File Offset: 0x003824BB
		private void _onOnCloseButtonClick()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNormalHalfFrameClose, null, null, null, null);
		}

		// Token: 0x0600DDBD RID: 56765 RVA: 0x003840D0 File Offset: 0x003824D0
		protected sealed override void _loadBg()
		{
		}

		// Token: 0x0600DDBE RID: 56766 RVA: 0x003840D4 File Offset: 0x003824D4
		protected sealed override void _OnOpenFrame()
		{
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
			this.UpdateGuildDungeonInfo();
		}

		// Token: 0x0600DDBF RID: 56767 RVA: 0x0038420C File Offset: 0x0038260C
		private void UpdateGuildDungeonInfo()
		{
			GuildDataManager.GuildDungeonActivityData guildDungeonActivityData = DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityData();
			if (guildDungeonActivityData != null)
			{
				GuildDungeonLvl guildDungeonDiffLevel = (GuildDungeonLvl)DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffLevel((uint)this.mDungeonID.dungeonID);
				if (guildDungeonDiffLevel == GuildDungeonLvl.GUILD_DUNGEON_HIGUH)
				{
					if (guildDungeonActivityData.bossDungeonDamageInfos.Count > 0 && this.BOSS != null)
					{
						this.BOSS.SetUp(guildDungeonActivityData.bossDungeonDamageInfos[0]);
						this.BOSS.CustomActive(true);
					}
				}
				else if (guildDungeonDiffLevel == GuildDungeonLvl.GUILD_DUNGEON_MID)
				{
					for (int i = 0; i < guildDungeonActivityData.mediumDungeonDamgeInfos.Count; i++)
					{
						if (guildDungeonActivityData.mediumDungeonDamgeInfos[i].nDungeonID == (ulong)((long)this.mDungeonID.dungeonID) && this.Medium0 != null)
						{
							this.Medium0.SetUp(guildDungeonActivityData.mediumDungeonDamgeInfos[i]);
							this.Medium0.CustomActive(true);
							break;
						}
					}
				}
				else if (guildDungeonDiffLevel == GuildDungeonLvl.GUILD_DUNGEON_LOW)
				{
					for (int j = 0; j < guildDungeonActivityData.juniorDungeonDamgeInfos.Count; j++)
					{
						if (guildDungeonActivityData.juniorDungeonDamgeInfos[j].nDungeonID == (ulong)((long)this.mDungeonID.dungeonID) && this.Junior0 != null)
						{
							this.Junior0.SetUp(guildDungeonActivityData.juniorDungeonDamgeInfos[j]);
							this.Junior0.CustomActive(true);
							break;
						}
					}
				}
			}
		}

		// Token: 0x0600DDC0 RID: 56768 RVA: 0x00384394 File Offset: 0x00382794
		private bool BIsShowFatigueCombustionGameobject()
		{
			DungeonTable tableItem = Singleton<TableManager>.GetInstance().GetTableItem<DungeonTable>(this.mDungeonID.dungeonID, string.Empty, string.Empty);
			return tableItem != null && (tableItem.SubType == DungeonTable.eSubType.S_NORMAL || tableItem.SubType == DungeonTable.eSubType.S_WUDAOHUI);
		}

		// Token: 0x0600DDC1 RID: 56769 RVA: 0x003843E4 File Offset: 0x003827E4
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

		// Token: 0x0600DDC2 RID: 56770 RVA: 0x0038445C File Offset: 0x0038285C
		protected sealed override void _OnCloseFrame()
		{
			this._unBindEvents();
			MissionManager instance = DataManager<MissionManager>.GetInstance();
			instance.onUpdateMission = (MissionManager.DelegateUpdateMission)Delegate.Remove(instance.onUpdateMission, new MissionManager.DelegateUpdateMission(this._onUpdateMission));
			if (DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager != null)
			{
				DataManager<ActivityLimitTimeCombineManager>.GetInstance().LimitTimeManager.RemoveSyncTaskDataChangeListener(new Action(this._OnTaskChange));
			}
			if (this.mCheckDrug.isOn)
			{
				DataManager<ChapterBuffDrugManager>.GetInstance().SetBuffDrugToggleState(true);
			}
			else
			{
				DataManager<ChapterBuffDrugManager>.GetInstance().SetBuffDrugToggleState(false);
			}
		}

		// Token: 0x0600DDC3 RID: 56771 RVA: 0x003844EA File Offset: 0x003828EA
		public sealed override bool IsNeedUpdate()
		{
			return true;
		}

		// Token: 0x0600DDC4 RID: 56772 RVA: 0x003844ED File Offset: 0x003828ED
		protected sealed override void _OnUpdate(float timeElapsed)
		{
			if (this.BIsShowFatigueCombustionGameobject())
			{
				this._SetFatigueCombustionTime();
			}
		}

		// Token: 0x0600DDC5 RID: 56773 RVA: 0x00384500 File Offset: 0x00382900
		private void _onUpdateMission(uint taskID)
		{
			this._updateRewardRedPoint();
		}

		// Token: 0x0600DDC6 RID: 56774 RVA: 0x00384508 File Offset: 0x00382908
		private void _updateRewardRedPoint()
		{
		}

		// Token: 0x0600DDC7 RID: 56775 RVA: 0x00384515 File Offset: 0x00382915
		private void _updateDungeonRewardStatus()
		{
			this.mOnReward.gameObject.SetActive(ChapterSelectFrame.IsCurrentSelectChapterShowReward());
		}

		// Token: 0x0600DDC8 RID: 56776 RVA: 0x0038452C File Offset: 0x0038292C
		private void _updateRedPointNum(int RedPointSum)
		{
			this.mRedPointSum.text = RedPointSum.ToString();
		}

		// Token: 0x0600DDC9 RID: 56777 RVA: 0x00384548 File Offset: 0x00382948
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

		// Token: 0x0600DDCA RID: 56778 RVA: 0x003845E0 File Offset: 0x003829E0
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

		// Token: 0x0600DDCB RID: 56779 RVA: 0x00384858 File Offset: 0x00382C58
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

		// Token: 0x0600DDCC RID: 56780 RVA: 0x003848E4 File Offset: 0x00382CE4
		private void _updateDungeonInfo()
		{
			if (this.mDungeonTable != null)
			{
				this.mDungeonUnitInfo.SetBackgroud(this.mDungeonTable.TumbPath);
				this.mDungeonUnitInfo.SetCharactorSprite(this.mDungeonTable.TumbChPath);
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
				this.mDungeonUnitInfo.CustomActive(false);
			}
		}

		// Token: 0x0600DDCD RID: 56781 RVA: 0x003849F1 File Offset: 0x00382DF1
		protected override void _loadRightPanel()
		{
		}

		// Token: 0x0600DDCE RID: 56782 RVA: 0x003849F3 File Offset: 0x00382DF3
		protected override void _updateDiffculteInfo()
		{
			base._updateDiffculteInfo();
			this.mChapterInfoDiffculte.SetDiffculteCallback(new ChapterDiffCallback(this._onDiffSelected));
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			this._onDiffSelected(this.mDungeonID.diffID);
		}

		// Token: 0x0600DDCF RID: 56783 RVA: 0x00384A33 File Offset: 0x00382E33
		private bool _getTeamBattleIsLock()
		{
			return !ChapterUtility.IsTeamDungeonID(this.mDungeonID.dungeonID) || this._isTeamBattleLevelLimte();
		}

		// Token: 0x0600DDD0 RID: 56784 RVA: 0x00384A53 File Offset: 0x00382E53
		private bool _isTeamBattleLevelLimte()
		{
			return !Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team);
		}

		// Token: 0x0600DDD1 RID: 56785 RVA: 0x00384A5F File Offset: 0x00382E5F
		private void _updateTeamBattleLockState()
		{
			this.mTeamButton.enabled = this._getTeamBattleIsLock();
		}

		// Token: 0x0600DDD2 RID: 56786 RVA: 0x00384A74 File Offset: 0x00382E74
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
				this.mHellroot0.CustomActive(true);
				this.mHellroot1.CustomActive(true);
				this.mTicketRoot.SetActive(false);
				this.mBindTicketRoot.SetActive(false);
				break;
			default:
				if (subType == DungeonTable.eSubType.S_YUANGU)
				{
					this.mYg0.CustomActive(true);
					this.mYg1.CustomActive(true);
					this.mTicketRoot.SetActive(false);
					this.mBindTicketRoot.SetActive(false);
				}
				break;
			case DungeonTable.eSubType.S_TEAM_BOSS:
				this.mBosschallengeRoot.SetActive(true);
				this.mFatigueRoot.SetActive(false);
				this.mComsumeRoot.SetActive(false);
				this.mStartRoot.SetActive(false);
				break;
			}
		}

		// Token: 0x0600DDD3 RID: 56787 RVA: 0x00384BC4 File Offset: 0x00382FC4
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
			this.mStartButton.enabled = false;
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
		}

		// Token: 0x0600DDD4 RID: 56788 RVA: 0x00384D98 File Offset: 0x00383198
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

		// Token: 0x0600DDD5 RID: 56789 RVA: 0x00384EC8 File Offset: 0x003832C8
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

		// Token: 0x0600DDD6 RID: 56790 RVA: 0x00384F08 File Offset: 0x00383308
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
		}

		// Token: 0x0600DDD7 RID: 56791 RVA: 0x00384FB4 File Offset: 0x003833B4
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

		// Token: 0x0600DDD8 RID: 56792 RVA: 0x0038502C File Offset: 0x0038342C
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

		// Token: 0x0600DDD9 RID: 56793 RVA: 0x00385048 File Offset: 0x00383448
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

		// Token: 0x0600DDDA RID: 56794 RVA: 0x0038509C File Offset: 0x0038349C
		private void EnterGuildDungeon()
		{
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
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x0600DDDB RID: 56795 RVA: 0x00385134 File Offset: 0x00383534
		private void _onStartButton()
		{
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
				if (DataManager<GuildDataManager>.GetInstance().IsGuildDungeonMap(this.mDungeonID.dungeonID) && !Utility.CheckTeamEnterGuildDungeon())
				{
					return;
				}
			}
			else
			{
				if (DataManager<GuildDataManager>.GetInstance().GetGuildDungeonActivityStatus() != GuildDungeonStatus.GUILD_DUNGEON_START)
				{
					SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("guildDungeonNotOpenTip"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
					return;
				}
				if (DataManager<GuildDataManager>.GetInstance().GetGuildDungeonDiffLevel((uint)this.mDungeonID.dungeonID) == 3)
				{
					SystemNotifyManager.SysNotifyMsgBoxCancelOk(TR.Value("enterGuildBossDungeonJoinATeam"), null, delegate()
					{
						this.EnterGuildDungeon();
					}, 0f, false, null);
					return;
				}
			}
			this.EnterGuildDungeon();
		}

		// Token: 0x0600DDDC RID: 56796 RVA: 0x0038526F File Offset: 0x0038366F
		private void MessageBoxOKCallBack()
		{
			ChapterUtility.OpenComsumeFatigueAddFrame(ChapterBaseFrame.sDungeonID);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x0600DDDD RID: 56797 RVA: 0x0038528D File Offset: 0x0038368D
		private void _onLeft()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNextDungeon, true, null, null, null);
		}

		// Token: 0x0600DDDE RID: 56798 RVA: 0x003852A7 File Offset: 0x003836A7
		private void _onRight()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNextDungeon, false, null, null, null);
		}

		// Token: 0x0600DDDF RID: 56799 RVA: 0x003852C4 File Offset: 0x003836C4
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

		// Token: 0x0600DDE0 RID: 56800 RVA: 0x0038539E File Offset: 0x0038379E
		public void SetMask(bool enabled)
		{
			this.mMask.SetActive(enabled);
		}

		// Token: 0x0600DDE1 RID: 56801 RVA: 0x003853AC File Offset: 0x003837AC
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

		// Token: 0x0600DDE2 RID: 56802 RVA: 0x0038540C File Offset: 0x0038380C
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

		// Token: 0x0600DDE3 RID: 56803 RVA: 0x003855FC File Offset: 0x003839FC
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

		// Token: 0x0600DDE4 RID: 56804 RVA: 0x00385798 File Offset: 0x00383B98
		private void _UpdateFatigueConsume()
		{
			if (this.mChapterConsume != null)
			{
				this.mChapterConsume.SetFatigueConsume(this.mDungeonTable.CostFatiguePerArea * this.mDungeonTable.MostCostStamina, this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY, this.mDungeonTable.ID);
			}
		}

		// Token: 0x0600DDE5 RID: 56805 RVA: 0x003857EC File Offset: 0x00383BEC
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

		// Token: 0x0600DDE6 RID: 56806 RVA: 0x0038585F File Offset: 0x00383C5F
		private void _OnTaskChange()
		{
			this._UpdateFatigueCombustionData(this.mFatigueCombustionRoot, this.mData, false);
		}

		// Token: 0x04008336 RID: 33590
		private bool mBisFlag;

		// Token: 0x04008337 RID: 33591
		private ActivityLimitTimeData data;

		// Token: 0x04008338 RID: 33592
		private ActivityLimitTimeDetailData mData;

		// Token: 0x04008339 RID: 33593
		private bool mFatigueCombustionTimeIsOpen;

		// Token: 0x0400833A RID: 33594
		private Text mTime;

		// Token: 0x0400833B RID: 33595
		private int mFatigueCombustionTime = -1;

		// Token: 0x0400833C RID: 33596
		private uint mAreaIndex;

		// Token: 0x0400833D RID: 33597
		private GameObject mlevelChallengeTimesRoot;

		// Token: 0x0400833E RID: 33598
		private Text mRebornLimitNumberValue;

		// Token: 0x0400833F RID: 33599
		private Text mLevelChallengeTimesNumber;

		// Token: 0x04008340 RID: 33600
		private GameObject mLevelResistValueRoot;

		// Token: 0x04008341 RID: 33601
		private Text mLevelResistValueLabel;

		// Token: 0x04008342 RID: 33602
		private Text mLevelResistValueNumber;

		// Token: 0x04008343 RID: 33603
		private Text mOwnerResistValueLabel;

		// Token: 0x04008344 RID: 33604
		private Text mOwnerResistValueNumber;

		// Token: 0x04008345 RID: 33605
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04008346 RID: 33606
		private Button mTeamStart;

		// Token: 0x04008347 RID: 33607
		private Button mNormalStart;

		// Token: 0x04008348 RID: 33608
		private UIGray mStartButton;

		// Token: 0x04008349 RID: 33609
		private UIGray mTeamButton;

		// Token: 0x0400834A RID: 33610
		private GameObject mHellroot0;

		// Token: 0x0400834B RID: 33611
		private GameObject mHellroot1;

		// Token: 0x0400834C RID: 33612
		private GameObject mYg0;

		// Token: 0x0400834D RID: 33613
		private GameObject mYg1;

		// Token: 0x0400834E RID: 33614
		private GameObject mBosschallengeRoot;

		// Token: 0x0400834F RID: 33615
		private GameObject mComsumeRoot;

		// Token: 0x04008350 RID: 33616
		private GameObject mStartRoot;

		// Token: 0x04008351 RID: 33617
		private GameObject mBindTicketRoot;

		// Token: 0x04008352 RID: 33618
		private GameObject mTicketRoot;

		// Token: 0x04008353 RID: 33619
		private LinkParse mMissionContent;

		// Token: 0x04008354 RID: 33620
		private GameObject mFatigueRoot;

		// Token: 0x04008355 RID: 33621
		private Text mMissionInfo;

		// Token: 0x04008356 RID: 33622
		private GameObject mMissionInfoRoot;

		// Token: 0x04008357 RID: 33623
		private ComChapterDungeonUnit mDungeonUnitInfo;

		// Token: 0x04008358 RID: 33624
		private Button mOnSelectLeftButton;

		// Token: 0x04008359 RID: 33625
		private Button mOnSelectRightButton;

		// Token: 0x0400835A RID: 33626
		private Button mOnReward;

		// Token: 0x0400835B RID: 33627
		private GameObject mOnRewardRed;

		// Token: 0x0400835C RID: 33628
		private Text mChapterRewardCount;

		// Token: 0x0400835D RID: 33629
		private Text mChapterRewardSum;

		// Token: 0x0400835E RID: 33630
		private Button mOnClose;

		// Token: 0x0400835F RID: 33631
		private GameObject mMask;

		// Token: 0x04008360 RID: 33632
		private GameObject[] mHards = new GameObject[4];

		// Token: 0x04008361 RID: 33633
		private GameObject mRedPoint;

		// Token: 0x04008362 RID: 33634
		private Text mRedPointSum;

		// Token: 0x04008363 RID: 33635
		private GameObject mRewardComplete;

		// Token: 0x04008364 RID: 33636
		private GameObject mFatigueCombustionRoot;

		// Token: 0x04008365 RID: 33637
		private Button mGroupDrug;

		// Token: 0x04008366 RID: 33638
		private Toggle mCheckDrug;

		// Token: 0x04008367 RID: 33639
		private Button mDropButton;

		// Token: 0x04008368 RID: 33640
		private GameObject mDropButtonEffect;

		// Token: 0x04008369 RID: 33641
		private GameObject mDropProgress;

		// Token: 0x0400836A RID: 33642
		private BossGuildDungeon BOSS;

		// Token: 0x0400836B RID: 33643
		private MediumGuildDungeon Medium0;

		// Token: 0x0400836C RID: 33644
		private JuniorGuildDungeon Junior0;
	}
}
