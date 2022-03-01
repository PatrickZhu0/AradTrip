using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C3E RID: 7230
	public class TeamDuplicationFightCommonControl : MonoBehaviour
	{
		// Token: 0x06011C08 RID: 72712 RVA: 0x00533282 File Offset: 0x00531682
		private void Awake()
		{
			this._isLoadingFinish = false;
			this.BindEvents();
		}

		// Token: 0x06011C09 RID: 72713 RVA: 0x00533291 File Offset: 0x00531691
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06011C0A RID: 72714 RVA: 0x0053329F File Offset: 0x0053169F
		private void ClearData()
		{
			this._isLoadingFinish = false;
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011C0B RID: 72715 RVA: 0x005332B0 File Offset: 0x005316B0
		private void BindEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
				this.backButton.onClick.AddListener(new UnityAction(this.OnBackBuildButtonClick));
			}
			if (this.fightPreSettingButtonWithStart != null)
			{
				this.fightPreSettingButtonWithStart.onClick.RemoveAllListeners();
				this.fightPreSettingButtonWithStart.onClick.AddListener(new UnityAction(this.OnFightPreSettingWithStartButtonClick));
			}
			if (this.fightStartButtonWithCd != null)
			{
				this.fightStartButtonWithCd.ResetButtonListener();
				this.fightStartButtonWithCd.SetButtonListener(new Action(this.OnFightStartButtonClick));
			}
			if (this.fightEndVoteButtonWithCd != null)
			{
				this.fightEndVoteButtonWithCd.ResetButtonListener();
				this.fightEndVoteButtonWithCd.SetButtonListener(new Action(this.OnFightEndVoteButtonClick));
			}
			if (this.leaveButton != null)
			{
				this.leaveButton.onClick.RemoveAllListeners();
				this.leaveButton.onClick.AddListener(new UnityAction(this.OnLeaveButtonClick));
			}
			if (this.packageButton != null)
			{
				this.packageButton.onClick.RemoveAllListeners();
				this.packageButton.onClick.AddListener(new UnityAction(this.OnPackageButtonClick));
			}
			if (this.skillButton != null)
			{
				this.skillButton.onClick.RemoveAllListeners();
				this.skillButton.onClick.AddListener(new UnityAction(this.OnSkillButtonClick));
			}
		}

		// Token: 0x06011C0C RID: 72716 RVA: 0x00533454 File Offset: 0x00531854
		private void UnBindEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
			}
			if (this.fightPreSettingButtonWithStart != null)
			{
				this.fightPreSettingButtonWithStart.onClick.RemoveAllListeners();
			}
			if (this.fightStartButtonWithCd != null)
			{
				this.fightStartButtonWithCd.ResetButtonListener();
			}
			if (this.fightEndVoteButtonWithCd != null)
			{
				this.fightEndVoteButtonWithCd.ResetButtonListener();
			}
			if (this.leaveButton != null)
			{
				this.leaveButton.onClick.RemoveAllListeners();
			}
			if (this.packageButton != null)
			{
				this.packageButton.onClick.RemoveAllListeners();
			}
			if (this.skillButton != null)
			{
				this.skillButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011C0D RID: 72717 RVA: 0x00533540 File Offset: 0x00531940
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationInBattleMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationInBattleMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageEndNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageEndNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnTeamDuplicationFightStageBeginMessage, new ClientEventSystem.UIEventHandler(this.OnTeamDuplicationFightStageBeginMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageNotifyMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamStatusNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGameResultMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedLoadingFinish, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneChangeLoadingFinish));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationStageEndDescriptionCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationStageEndDescriptionCloseMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationMiddleStageRewardCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationMiddleStageRewardCloseMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFinalResultCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFinalResultCloseMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this.OnSwitchToBuildSceneByQuitTeam));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this.OnSwitchToBuildSceneByQuitTeam));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteFlagMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteFlagMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridCountDownTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridCountDownMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridFightBeginMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridFightBeginMessage));
		}

		// Token: 0x06011C0E RID: 72718 RVA: 0x00533700 File Offset: 0x00531B00
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationInBattleMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationInBattleMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageEndNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageEndNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnTeamDuplicationFightStageBeginMessage, new ClientEventSystem.UIEventHandler(this.OnTeamDuplicationFightStageBeginMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightStageNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightStageNotifyMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamStatusNotifyMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGameResultMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedLoadingFinish, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneChangeLoadingFinish));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationStageEndDescriptionCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationStageEndDescriptionCloseMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationMiddleStageRewardCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationMiddleStageRewardCloseMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFinalResultCloseMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFinalResultCloseMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this.OnSwitchToBuildSceneByQuitTeam));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this.OnSwitchToBuildSceneByQuitTeam));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteFlagMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteFlagMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridCountDownTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridCountDownMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationGridFightBeginMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationGridFightBeginMessage));
		}

		// Token: 0x06011C0F RID: 72719 RVA: 0x005338BD File Offset: 0x00531CBD
		public void Init(bool isIn65LevelTeamDuplication = false)
		{
			this._isIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
			this.InitFightButton();
			this.InitFightPanelControl();
			this.UpdateHelpButton();
		}

		// Token: 0x06011C10 RID: 72720 RVA: 0x005338D8 File Offset: 0x00531CD8
		private void InitFightButton()
		{
			this.ResetButton();
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			if (teamDuplicationTeamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE)
			{
				this.UpdateRelationStartButtonInPrepareStatus();
			}
			else if (teamDuplicationTeamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_BATTLE)
			{
				this.UpdateTeamDuplicationFightView(true);
				CommonUtility.UpdateGameObjectVisible(this.backButtonRoot, false);
				this.UpdateFightEndVoteButton();
			}
			else
			{
				this.UpdateGameOverView();
			}
		}

		// Token: 0x06011C11 RID: 72721 RVA: 0x00533943 File Offset: 0x00531D43
		private void InitFightPanelControl()
		{
			if (this.fightPanelControl != null)
			{
				this.fightPanelControl.InitFightPanelControl(this._isIn65LevelTeamDuplication);
			}
		}

		// Token: 0x06011C12 RID: 72722 RVA: 0x00533968 File Offset: 0x00531D68
		private void UpdateHelpButton()
		{
			if (this.helpNewAssistant == null)
			{
				return;
			}
			int helpId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightHelpIdWithNormalLevel;
			if (this._isIn65LevelTeamDuplication)
			{
				helpId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightHelpIdWith65Level;
			}
			this.helpNewAssistant.HelpId = helpId;
		}

		// Token: 0x06011C13 RID: 72723 RVA: 0x005339B4 File Offset: 0x00531DB4
		private void OnBackBuildButtonClick()
		{
			TeamDuplicationUtility.BackToTeamDuplicationBuildScene();
		}

		// Token: 0x06011C14 RID: 72724 RVA: 0x005339BB File Offset: 0x00531DBB
		private void OnFightPreSettingWithStartButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationFightPreSettingFrame();
		}

		// Token: 0x06011C15 RID: 72725 RVA: 0x005339C4 File Offset: 0x00531DC4
		private void OnFightStartButtonClick()
		{
			if (!TeamDuplicationUtility.IsEveryTroopOwnerPlayer())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_start_battle_by_player_not_enough"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._isIn65LevelTeamDuplication)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartBattleReq(TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_INVALID, true);
				return;
			}
			if (TeamDuplicationUtility.IsTeamDuplicationTeamDifficultyHardLevel())
			{
				this.OnFightStartWithHardLevel();
				return;
			}
			if (DataManager<TeamDuplicationDataManager>.GetInstance().FightSettingConfigPlanModel == TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_INVALID)
			{
				string contentStr = TR.Value("team_duplication_start_fighting_without_pre_setting");
				TeamDuplicationUtility.OnShowCommonMsgBoxFrame(contentStr, new Action(this.OnFightStartAction), 4);
				return;
			}
			this.OnFightStartAction();
		}

		// Token: 0x06011C16 RID: 72726 RVA: 0x00533A4A File Offset: 0x00531E4A
		private void OnFightStartAction()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartBattleReq(DataManager<TeamDuplicationDataManager>.GetInstance().FightSettingConfigPlanModel, false);
		}

		// Token: 0x06011C17 RID: 72727 RVA: 0x00533A61 File Offset: 0x00531E61
		private void OnFightStartWithHardLevel()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartBattleReq(TeamCopyPlanModel.TEAM_COPY_PLAN_MODEL_FREE, false);
		}

		// Token: 0x06011C18 RID: 72728 RVA: 0x00533A6F File Offset: 0x00531E6F
		private void OnLeaveButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamQuitReq();
			DataManager<TeamDuplicationDataManager>.GetInstance().ClearData();
			TeamDuplicationUtility.BackToTeamDuplicationBuildScene();
		}

		// Token: 0x06011C19 RID: 72729 RVA: 0x00533A8A File Offset: 0x00531E8A
		private void OnPackageButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationPackageNewFrame();
		}

		// Token: 0x06011C1A RID: 72730 RVA: 0x00533A91 File Offset: 0x00531E91
		private void OnSkillButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationSkillFrame();
		}

		// Token: 0x06011C1B RID: 72731 RVA: 0x00533A98 File Offset: 0x00531E98
		private void UpdateTeamDuplicationFightView(bool flag)
		{
			if (this.fightPanelControl != null)
			{
				this.fightPanelControl.UpdateFightPanelShowButton(flag);
			}
			this.UpdateFightCountDownTimeControl(flag);
		}

		// Token: 0x06011C1C RID: 72732 RVA: 0x00533AC0 File Offset: 0x00531EC0
		private void UpdateFightCountDownTimeControl(bool flag)
		{
			if (this.fightCountDownTimeControl == null)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.fightCountDownTimeControl.gameObject, flag);
			if (flag)
			{
				this.fightCountDownTimeControl.EndTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightFinishTime;
				this.fightCountDownTimeControl.InitCountDownTimeController();
			}
		}

		// Token: 0x06011C1D RID: 72733 RVA: 0x00533B16 File Offset: 0x00531F16
		private void ResetButton()
		{
			CommonUtility.UpdateButtonVisible(this.fightPreSettingButtonWithStart, false);
			CommonUtility.UpdateButtonWithCdVisible(this.fightStartButtonWithCd, false);
			CommonUtility.UpdateButtonWithCdVisible(this.fightEndVoteButtonWithCd, false);
			this.UpdateTeamDuplicationFightView(false);
		}

		// Token: 0x06011C1E RID: 72734 RVA: 0x00533B44 File Offset: 0x00531F44
		private void ShowGameOverView()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			if (teamDuplicationTeamDataModel.TeamStatus != TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_FAILED && teamDuplicationTeamDataModel.TeamStatus != TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_VICTORY)
			{
				return;
			}
			if (teamDuplicationTeamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_FAILED && DataManager<TeamDuplicationDataManager>.GetInstance().IsNeedShowGameFailResult)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationGameResultFrame(false);
				DataManager<TeamDuplicationDataManager>.GetInstance().IsNeedShowGameFailResult = false;
			}
			if (this._isIn65LevelTeamDuplication)
			{
				TeamDuplicationUtility.OnCloseRelationFrameOf65LevelTeamDuplication();
			}
			this.UpdateGameOverView();
		}

		// Token: 0x06011C1F RID: 72735 RVA: 0x00533BBE File Offset: 0x00531FBE
		private void UpdateGameOverView()
		{
			CommonUtility.UpdateGameObjectVisible(this.gameOverRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.fightingRoot, false);
			if (this.fightCountDownTimeControl != null)
			{
				this.fightCountDownTimeControl.ResetCountDownTimeController();
			}
		}

		// Token: 0x06011C20 RID: 72736 RVA: 0x00533BF4 File Offset: 0x00531FF4
		private void OnTeamDuplicationFightStageBeginMessage(UIEvent uiEvent)
		{
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			if (this.fightPanelControl != null)
			{
				this.fightPanelControl.OnFightPanelShow();
			}
		}

		// Token: 0x06011C21 RID: 72737 RVA: 0x00533C18 File Offset: 0x00532018
		private void OnReceiveTeamDuplicationInBattleMessage(UIEvent uiEvent)
		{
			if (this._isIn65LevelTeamDuplication)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationGridMapFightBeginFrame();
			}
			else
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationFightCountDownFrame();
			}
			CommonUtility.UpdateGameObjectVisible(this.fightStartButtonWithCd.gameObject, false);
			CommonUtility.UpdateButtonVisible(this.fightPreSettingButtonWithStart, false);
			this.UpdateTeamDuplicationFightView(true);
			CommonUtility.UpdateGameObjectVisible(this.backButtonRoot, false);
		}

		// Token: 0x06011C22 RID: 72738 RVA: 0x00533C70 File Offset: 0x00532070
		private void ShowTeamDuplicationFightVoteFrameBySceneChangeLoadingFinish()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().FightVoteAgreeBySwitchFightScene)
			{
				return;
			}
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsInStartBattleVotingTime)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().FightVoteAgreeBySwitchFightScene = false;
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			TeamDuplicationUtility.OnOpenTeamDuplicationFightStartVoteFrame();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyStartBattleVote(true);
		}

		// Token: 0x06011C23 RID: 72739 RVA: 0x00533CBD File Offset: 0x005320BD
		private void ShowTeamDuplicationGameOverBySceneChangeLoadingFinish()
		{
			this.ShowGameOverView();
		}

		// Token: 0x06011C24 RID: 72740 RVA: 0x00533CC5 File Offset: 0x005320C5
		private void OnReceiveTeamDuplicationFightStageEndNotifyMessage(UIEvent uiEvent)
		{
			if (this._isIn65LevelTeamDuplication)
			{
				TeamDuplicationUtility.OnCloseTeamDuplicationGridMapFrame();
			}
			else
			{
				TeamDuplicationUtility.OnCloseTeamDuplicationFightStagePanelFrame();
			}
			this.ShowFightStageEndView();
		}

		// Token: 0x06011C25 RID: 72741 RVA: 0x00533CE7 File Offset: 0x005320E7
		private void ShowTeamDuplicationFightStageEndViewBySceneChangeLoadingFinish()
		{
			this.ShowFightStageEndView();
		}

		// Token: 0x06011C26 RID: 72742 RVA: 0x00533CF0 File Offset: 0x005320F0
		private void ShowFightStageEndView()
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationEndStageId <= 0)
			{
				return;
			}
			TeamDuplicationUtility.OnOpenTeamDuplicationFightStageEndDescriptionFrame(DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationEndStageId, this._isIn65LevelTeamDuplication, DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationStagePassTypeWith65Level);
			DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationEndStageId = 0;
			DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationStagePassTypeWith65Level = TC2PassType.TC_2_PASS_TYPE_COMMON;
		}

		// Token: 0x06011C27 RID: 72743 RVA: 0x00533D44 File Offset: 0x00532144
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel != null && teamDuplicationTeamDataModel.TeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE)
			{
				this.UpdateRelationStartButtonInPrepareStatus();
			}
			this.UpdateFightEndVoteByTeamDataMessage();
		}

		// Token: 0x06011C28 RID: 72744 RVA: 0x00533D79 File Offset: 0x00532179
		private void OnReceiveTeamDuplicationFightStageNotifyMessage(UIEvent uiEvent)
		{
			if (this._isIn65LevelTeamDuplication)
			{
				return;
			}
			if (this.fightCountDownTimeControl == null)
			{
				return;
			}
			this.fightCountDownTimeControl.EndTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightFinishTime;
			this.fightCountDownTimeControl.InitCountDownTimeController();
		}

		// Token: 0x06011C29 RID: 72745 RVA: 0x00533DB9 File Offset: 0x005321B9
		private void OnReceiveTeamDuplicationGameResultMessage(UIEvent uiEvent)
		{
			this.ShowGameOverView();
		}

		// Token: 0x06011C2A RID: 72746 RVA: 0x00533DC4 File Offset: 0x005321C4
		private void OnReceiveTeamDuplicationStageEndDescriptionCloseMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			TC2PassType passType = TC2PassType.TC_2_PASS_TYPE_COMMON;
			if (uiEvent.Param2 != null)
			{
				passType = (TC2PassType)uiEvent.Param2;
			}
			if (num == 1 || num == 2)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationMiddleStageRewardFrame(num, this._isIn65LevelTeamDuplication, passType);
			}
		}

		// Token: 0x06011C2B RID: 72747 RVA: 0x00533E24 File Offset: 0x00532224
		private void OnReceiveTeamDuplicationMiddleStageRewardCloseMessage(UIEvent uiEvent)
		{
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num == 1)
			{
				if (this._isIn65LevelTeamDuplication)
				{
					TeamDuplicationUtility.OnOpenTeamDuplicationGameResultFrame(true);
				}
				else if (DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageId == 2)
				{
					TeamDuplicationUtility.OnOpenTeamDuplicationFightStageBeginDescriptionFrame(DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightStageId);
				}
			}
			else
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationGameResultFrame(true);
			}
		}

		// Token: 0x06011C2C RID: 72748 RVA: 0x00533E96 File Offset: 0x00532296
		private void OnReceiveTeamDuplicationFinalResultCloseMessage(UIEvent uiEvent)
		{
			if (this._isIn65LevelTeamDuplication)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationFinalCardFrame();
			}
			else
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationFinalStageCardFrame();
			}
		}

		// Token: 0x06011C2D RID: 72749 RVA: 0x00533EB2 File Offset: 0x005322B2
		private void OnReceiveSceneChangeLoadingFinish(UIEvent uiEvent)
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationFightSceneLeaveTipFrame();
				return;
			}
			this._isLoadingFinish = true;
			this.ShowTeamDuplicationFightVoteFrameBySceneChangeLoadingFinish();
			this.ShowTeamDuplicationGameOverBySceneChangeLoadingFinish();
			this.ShowTeamDuplicationFightStageEndViewBySceneChangeLoadingFinish();
		}

		// Token: 0x06011C2E RID: 72750 RVA: 0x00533EE2 File Offset: 0x005322E2
		private void OnSwitchToBuildSceneByQuitTeam(UIEvent uiEvent)
		{
			if (!this._isLoadingFinish)
			{
				return;
			}
			TeamDuplicationUtility.OnCloseRelationFrameBySwitchBuildSceneInTeamDuplication();
			if (this._isIn65LevelTeamDuplication)
			{
				TeamDuplicationUtility.OnCloseRelationFrameOf65LevelTeamDuplication();
			}
			TeamDuplicationUtility.SwitchTeamDuplicationToBuildSceneByQuitTeam();
		}

		// Token: 0x06011C2F RID: 72751 RVA: 0x00533F0A File Offset: 0x0053230A
		private void OnReceiveTeamDuplicationGridCountDownMessage(UIEvent uiEvent)
		{
			if (!this._isIn65LevelTeamDuplication)
			{
				return;
			}
			if (this.fightCountDownTimeControl == null)
			{
				return;
			}
			this.fightCountDownTimeControl.EndTime = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightFinishTime;
			this.fightCountDownTimeControl.InitCountDownTimeController();
		}

		// Token: 0x06011C30 RID: 72752 RVA: 0x00533F4A File Offset: 0x0053234A
		private void OnReceiveTeamDuplicationGridFightBeginMessage(UIEvent uiEvent)
		{
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			if (this.fightPanelControl != null)
			{
				this.fightPanelControl.OnFightPanelShow();
			}
		}

		// Token: 0x06011C31 RID: 72753 RVA: 0x00533F6D File Offset: 0x0053236D
		private void UpdateFightEndVoteByTeamDataMessage()
		{
			if (!TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication())
			{
				CommonUtility.UpdateButtonWithCdVisible(this.fightEndVoteButtonWithCd, false);
				DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightEndVoteFlag = false;
				return;
			}
			this.UpdateFightEndVoteButton();
		}

		// Token: 0x06011C32 RID: 72754 RVA: 0x00533F97 File Offset: 0x00532397
		private void OnReceiveTeamDuplicationFightEndVoteFlagMessage(UIEvent uiEvent)
		{
			this.UpdateFightEndVoteButton();
		}

		// Token: 0x06011C33 RID: 72755 RVA: 0x00533F9F File Offset: 0x0053239F
		private void OnReceiveTeamDuplicationFightEndVoteResultSucceedMessage(UIEvent uiEvent)
		{
			this.UpdateFightEndVoteButton();
		}

		// Token: 0x06011C34 RID: 72756 RVA: 0x00533FA7 File Offset: 0x005323A7
		private void UpdateFightEndVoteButton()
		{
			CommonUtility.UpdateButtonWithCdVisible(this.fightEndVoteButtonWithCd, false);
			if (!TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication())
			{
				return;
			}
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationFightEndVoteFlag)
			{
				return;
			}
			if (!TeamDuplicationUtility.IsTeamDuplicationInFightingStatus())
			{
				return;
			}
			CommonUtility.UpdateButtonWithCdVisible(this.fightEndVoteButtonWithCd, true);
		}

		// Token: 0x06011C35 RID: 72757 RVA: 0x00533FE7 File Offset: 0x005323E7
		private void OnFightEndVoteButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyForceEndReq();
		}

		// Token: 0x06011C36 RID: 72758 RVA: 0x00533FF4 File Offset: 0x005323F4
		private void UpdateRelationStartButtonInPrepareStatus()
		{
			if (TeamDuplicationUtility.IsSelfPlayerIsTeamLeaderInTeamDuplication())
			{
				if (TeamDuplicationUtility.IsTeamDuplicationTeamDifficultyHardLevel())
				{
					CommonUtility.UpdateButtonVisible(this.fightPreSettingButtonWithStart, false);
				}
				else if (this._isIn65LevelTeamDuplication)
				{
					CommonUtility.UpdateButtonVisible(this.fightPreSettingButtonWithStart, false);
				}
				else
				{
					CommonUtility.UpdateButtonVisible(this.fightPreSettingButtonWithStart, true);
				}
				CommonUtility.UpdateGameObjectVisible(this.fightStartButtonWithCd.gameObject, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.fightStartButtonWithCd.gameObject, false);
				CommonUtility.UpdateButtonVisible(this.fightPreSettingButtonWithStart, false);
			}
		}

		// Token: 0x0400B901 RID: 47361
		private bool _isLoadingFinish;

		// Token: 0x0400B902 RID: 47362
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B903 RID: 47363
		[Space(15f)]
		[Header("CommonButton")]
		[Space(5f)]
		[SerializeField]
		private GameObject backButtonRoot;

		// Token: 0x0400B904 RID: 47364
		[SerializeField]
		private Button backButton;

		// Token: 0x0400B905 RID: 47365
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x0400B906 RID: 47366
		[Space(15f)]
		[Header("BottomButton")]
		[Space(5f)]
		[SerializeField]
		private Button fightPreSettingButtonWithStart;

		// Token: 0x0400B907 RID: 47367
		[SerializeField]
		private ComButtonWithCd fightStartButtonWithCd;

		// Token: 0x0400B908 RID: 47368
		[SerializeField]
		private ComButtonWithCd fightEndVoteButtonWithCd;

		// Token: 0x0400B909 RID: 47369
		[SerializeField]
		private Button skillButton;

		// Token: 0x0400B90A RID: 47370
		[SerializeField]
		private Button packageButton;

		// Token: 0x0400B90B RID: 47371
		[Space(15f)]
		[Header("fightCountDownTime")]
		[Space(5f)]
		[SerializeField]
		private CountDownTimeController fightCountDownTimeControl;

		// Token: 0x0400B90C RID: 47372
		[Space(15f)]
		[Header("FightPanelControl")]
		[Space(5f)]
		[SerializeField]
		private TeamDuplicationFightPanelControl fightPanelControl;

		// Token: 0x0400B90D RID: 47373
		[Space(15f)]
		[Header("GameOver")]
		[Space(5f)]
		[SerializeField]
		private GameObject gameOverRoot;

		// Token: 0x0400B90E RID: 47374
		[SerializeField]
		private Button leaveButton;

		// Token: 0x0400B90F RID: 47375
		[SerializeField]
		private GameObject fightingRoot;
	}
}
