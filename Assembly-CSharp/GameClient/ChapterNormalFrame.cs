using System;
using System.Collections.Generic;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001531 RID: 5425
	public class ChapterNormalFrame : ChapterBaseFrame
	{
		// Token: 0x0600D33C RID: 54076 RVA: 0x003452CE File Offset: 0x003436CE
		public override string GetPrefabPath()
		{
			return "UIFlatten/Prefabs/Chapter/Normal/ChapterNormal.prefab";
		}

		// Token: 0x0600D33D RID: 54077 RVA: 0x003452D8 File Offset: 0x003436D8
		protected override void _bindExUI()
		{
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
			this.mFatigueRoot = this.mBind.GetGameObject("fatigueRoot");
			this.mDiffText = this.mBind.GetCom<Text>("diff");
			this.mDimRoot = this.mBind.GetGameObject("dimRoot");
			this.mDim2Root = this.mBind.GetGameObject("dim (2)Root");
			this.mWTRoot = this.mBind.GetGameObject("WT (1)");
			this.mGTRoot = this.mBind.GetGameObject("GT (1)");
			this.mExpAddRoot = this.mBind.GetGameObject("ExpAdd");
			this.mGT3Root = this.mBind.GetGameObject("GT (3)");
		}

		// Token: 0x0600D33E RID: 54078 RVA: 0x00345504 File Offset: 0x00343904
		protected override void _unbindExUI()
		{
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
			this.mFatigueRoot = null;
			this.mDiffText = null;
			this.mDimRoot = null;
			this.mDim2Root = null;
			this.mWTRoot = null;
			this.mGTRoot = null;
			this.mExpAddRoot = null;
			this.mGT3Root = null;
		}

		// Token: 0x0600D33F RID: 54079 RVA: 0x003455E3 File Offset: 0x003439E3
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

		// Token: 0x0600D340 RID: 54080 RVA: 0x0034561A File Offset: 0x00343A1A
		private void _onNormalStartButtonClick()
		{
			this._onStartButton();
		}

		// Token: 0x0600D341 RID: 54081 RVA: 0x00345622 File Offset: 0x00343A22
		private void _onHelpButtonClick()
		{
		}

		// Token: 0x0600D342 RID: 54082 RVA: 0x00345624 File Offset: 0x00343A24
		protected override void _loadBg()
		{
		}

		// Token: 0x0600D343 RID: 54083 RVA: 0x00345626 File Offset: 0x00343A26
		protected override void _OnOpenFrame()
		{
			base._OnOpenFrame();
			this.mTeamStart.CustomActive(Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team));
			DataManager<ChapterBuffDrugManager>.GetInstance().ResetAllMarkedBuffDrugs();
		}

		// Token: 0x0600D344 RID: 54084 RVA: 0x0034564C File Offset: 0x00343A4C
		protected sealed override void _loadLeftPanel()
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
			}
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			if (DataManager<ActivityDungeonDataManager>.GetInstance()._judgeDungeonIDIsRotteneterHell(ChapterBaseFrame.sDungeonID))
			{
				this._HideRoot();
				for (int i = 0; i < 4; i++)
				{
					if (i > this.mDungeonID.diffID)
					{
						this.mChapterInfoDiffculte.SetActiveDiffculteByIdx(i, false);
					}
				}
			}
			this.mChapterInfoDiffculte.SetDiffculte(this.mDungeonID.diffID, this.mDungeonID.dungeonID);
			this._updateTeamBattleLockState();
			List<eChapterNodeState> list = new List<eChapterNodeState>();
			List<int> list2 = new List<int>();
			List<DungeonScore> list3 = new List<DungeonScore>();
			List<string> list4 = new List<string>();
			int dungeonTopHard = ChapterUtility.GetDungeonTopHard(this.mDungeonID.dungeonIDWithOutDiff);
			DungeonID dungeonID = new DungeonID(this.mDungeonID.dungeonID);
			for (int j = 0; j <= dungeonTopHard; j++)
			{
				dungeonID.diffID = j;
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
					if ((int)DataManager<PlayerBaseData>.GetInstance().Level >= list2[j])
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
			for (int k = dungeonTopHard + 1; k < 4; k++)
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
			if (this.mChapterDungeonMap != null)
			{
				DDungeonData dungeonMap = Singleton<AssetLoader>.instance.LoadRes(this.mDungeonTable.DungeonConfig, typeof(DDungeonData), true, 0U).obj as DDungeonData;
				this.mChapterDungeonMap.SetDungeonMap(dungeonMap);
			}
			if (this.mChapterInfoDrugs != null)
			{
				this.mChapterInfoDrugs.SetBuffDrugs(this.mDungeonTable.BuffDrugConfig);
			}
			if (!Singleton<NewbieGuideManager>.GetInstance().IsGuidingControl() || !Singleton<NewbieGuideManager>.GetInstance().IsGuidingTask(NewbieGuideTable.eNewbieGuideTask.GuanKaGuide))
			{
			}
		}

		// Token: 0x0600D345 RID: 54085 RVA: 0x0034597A File Offset: 0x00343D7A
		protected override void _loadRightPanel()
		{
		}

		// Token: 0x0600D346 RID: 54086 RVA: 0x0034597C File Offset: 0x00343D7C
		protected override void _updateDiffculteInfo()
		{
			base._updateDiffculteInfo();
			this.mChapterInfoDiffculte.SetDiffculteCallback(new ChapterDiffCallback(this._onDiffSelected));
			this.mDungeonID.dungeonID = ChapterBaseFrame.sDungeonID;
			this._onDiffSelected(this.mDungeonID.diffID);
		}

		// Token: 0x0600D347 RID: 54087 RVA: 0x003459BC File Offset: 0x00343DBC
		private void _HideRoot()
		{
			this.mDiffText.text = "王者";
			this.mDimRoot.CustomActive(false);
			this.mDim2Root.CustomActive(true);
			this.mWTRoot.CustomActive(false);
			this.mGTRoot.CustomActive(false);
			this.mExpAddRoot.CustomActive(false);
			this.mGT3Root.CustomActive(false);
		}

		// Token: 0x0600D348 RID: 54088 RVA: 0x00345A24 File Offset: 0x00343E24
		private bool _getTeamBattleIsLock()
		{
			ComChapterDungeonUnit.eState dungeonState = ChapterUtility.GetDungeonState(this.mDungeonID.dungeonID);
			bool flag = dungeonState == ComChapterDungeonUnit.eState.Locked;
			return this.mDungeonID.prestoryID > 0 || flag || this._isTeamBattleLevelLimte();
		}

		// Token: 0x0600D349 RID: 54089 RVA: 0x00345A67 File Offset: 0x00343E67
		private bool _isTeamBattleLevelLimte()
		{
			return !Utility.IsFunctionCanUnlock(FunctionUnLock.eFuncType.Team);
		}

		// Token: 0x0600D34A RID: 54090 RVA: 0x00345A73 File Offset: 0x00343E73
		private void _updateTeamBattleLockState()
		{
			this.mTeamButton.enabled = this._getTeamBattleIsLock();
		}

		// Token: 0x0600D34B RID: 54091 RVA: 0x00345A88 File Offset: 0x00343E88
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
				if (subType == DungeonTable.eSubType.S_YUANGU)
				{
					this.mYg0.CustomActive(true);
					this.mYg1.CustomActive(true);
					this.mTicketRoot.SetActive(false);
					this.mBindTicketRoot.SetActive(false);
					return;
				}
				if (subType != DungeonTable.eSubType.S_LIMIT_TIME_HELL && subType != DungeonTable.eSubType.S_LIMIT_TIME__FREE_HELL)
				{
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

		// Token: 0x0600D34C RID: 54092 RVA: 0x00345BE8 File Offset: 0x00343FE8
		private void _onDiffSelected(int idx)
		{
			this.mDungeonID.diffID = idx;
			int dungeonID = this.mDungeonID.dungeonID;
			base._loadTableData();
			this._updateScore();
			this._updateTeamBattleLockState();
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
				this.mChapterConsume.SetFatigueConsume(this.mDungeonTable.CostFatiguePerArea * this.mDungeonTable.MostCostStamina, this.mDungeonTable.SubType == DungeonTable.eSubType.S_HELL_ENTRY, dungeonID);
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
		}

		// Token: 0x0600D34D RID: 54093 RVA: 0x00345D88 File Offset: 0x00344188
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

		// Token: 0x0600D34E RID: 54094 RVA: 0x00345DDC File Offset: 0x003441DC
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
			}
			ChapterUtility.OpenComsumeFatigueAddFrame(ChapterBaseFrame.sDungeonID);
			MonoSingleton<GameFrameWork>.instance.StartCoroutine(base._commonStart());
		}

		// Token: 0x0600D34F RID: 54095 RVA: 0x00345EA2 File Offset: 0x003442A2
		private void _onLeft()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNextDungeon, true, null, null, null);
		}

		// Token: 0x0600D350 RID: 54096 RVA: 0x00345EBC File Offset: 0x003442BC
		private void _onRight()
		{
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.ChapterNextDungeon, false, null, null, null);
		}

		// Token: 0x04007B9C RID: 31644
		private ComCommonChapterInfo mChapterInfo;

		// Token: 0x04007B9D RID: 31645
		private Button mTeamStart;

		// Token: 0x04007B9E RID: 31646
		private Button mNormalStart;

		// Token: 0x04007B9F RID: 31647
		private UIGray mStartButton;

		// Token: 0x04007BA0 RID: 31648
		private UIGray mTeamButton;

		// Token: 0x04007BA1 RID: 31649
		private GameObject mHellroot0;

		// Token: 0x04007BA2 RID: 31650
		private GameObject mHellroot1;

		// Token: 0x04007BA3 RID: 31651
		private GameObject mYg0;

		// Token: 0x04007BA4 RID: 31652
		private GameObject mYg1;

		// Token: 0x04007BA5 RID: 31653
		private GameObject mBosschallengeRoot;

		// Token: 0x04007BA6 RID: 31654
		private GameObject mComsumeRoot;

		// Token: 0x04007BA7 RID: 31655
		private GameObject mStartRoot;

		// Token: 0x04007BA8 RID: 31656
		private GameObject mBindTicketRoot;

		// Token: 0x04007BA9 RID: 31657
		private GameObject mTicketRoot;

		// Token: 0x04007BAA RID: 31658
		private GameObject mFatigueRoot;

		// Token: 0x04007BAB RID: 31659
		private Text mDiffText;

		// Token: 0x04007BAC RID: 31660
		private GameObject mDimRoot;

		// Token: 0x04007BAD RID: 31661
		private GameObject mDim2Root;

		// Token: 0x04007BAE RID: 31662
		private GameObject mWTRoot;

		// Token: 0x04007BAF RID: 31663
		private GameObject mGTRoot;

		// Token: 0x04007BB0 RID: 31664
		private GameObject mExpAddRoot;

		// Token: 0x04007BB1 RID: 31665
		private GameObject mGT3Root;
	}
}
