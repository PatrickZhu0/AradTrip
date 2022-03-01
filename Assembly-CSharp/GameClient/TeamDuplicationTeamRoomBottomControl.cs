using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C47 RID: 7239
	public class TeamDuplicationTeamRoomBottomControl : MonoBehaviour
	{
		// Token: 0x06011C6E RID: 72814 RVA: 0x00534C9C File Offset: 0x0053309C
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011C6F RID: 72815 RVA: 0x00534CA4 File Offset: 0x005330A4
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011C70 RID: 72816 RVA: 0x00534CB2 File Offset: 0x005330B2
		private void ClearData()
		{
			this._isTeamLeader = false;
		}

		// Token: 0x06011C71 RID: 72817 RVA: 0x00534CBC File Offset: 0x005330BC
		private void BindUiEvents()
		{
			if (this.quitButton != null)
			{
				this.quitButton.onClick.RemoveAllListeners();
				this.quitButton.onClick.AddListener(new UnityAction(this.OnQuitButtonClick));
			}
			if (this.requestListButton != null)
			{
				this.requestListButton.onClick.RemoveAllListeners();
				this.requestListButton.onClick.AddListener(new UnityAction(this.OnRequesterListButtonClick));
			}
			if (this.recruitButton != null)
			{
				this.recruitButton.onClick.RemoveAllListeners();
				this.recruitButton.onClick.AddListener(new UnityAction(this.OnRecruitButtonClick));
			}
			if (this.chatButton != null)
			{
				this.chatButton.onClick.RemoveAllListeners();
				this.chatButton.onClick.AddListener(new UnityAction(this.OnChatButtonClick));
			}
			if (this.requestJoinInTeamButton != null)
			{
				this.requestJoinInTeamButton.onClick.RemoveAllListeners();
				this.requestJoinInTeamButton.onClick.AddListener(new UnityAction(this.OnRequestJoinInTeamButtonClick));
			}
			if (this.autoAgreeGoldJoinInButton != null)
			{
				this.autoAgreeGoldJoinInButton.ResetButtonListener();
				this.autoAgreeGoldJoinInButton.SetButtonListener(new Action(this.OnAutoJoinInButtonClick));
			}
			if (this.teamSettingButton != null)
			{
				this.teamSettingButton.onClick.RemoveAllListeners();
				this.teamSettingButton.onClick.AddListener(new UnityAction(this.OnTeamSettingButtonClicked));
			}
		}

		// Token: 0x06011C72 RID: 72818 RVA: 0x00534E6C File Offset: 0x0053326C
		private void UnBindUiEvents()
		{
			if (this.quitButton != null)
			{
				this.quitButton.onClick.RemoveAllListeners();
			}
			if (this.requestListButton != null)
			{
				this.requestListButton.onClick.RemoveAllListeners();
			}
			if (this.recruitButton != null)
			{
				this.recruitButton.onClick.RemoveAllListeners();
			}
			if (this.chatButton != null)
			{
				this.chatButton.onClick.RemoveAllListeners();
			}
			if (this.requestJoinInTeamButton != null)
			{
				this.requestJoinInTeamButton.onClick.RemoveAllListeners();
			}
			if (this.autoAgreeGoldJoinInButton != null)
			{
				this.autoAgreeGoldJoinInButton.ResetButtonListener();
			}
			if (this.teamSettingButton != null)
			{
				this.teamSettingButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011C73 RID: 72819 RVA: 0x00534F5B File Offset: 0x0053335B
		private void OnEnable()
		{
			this.BindUiMessages();
		}

		// Token: 0x06011C74 RID: 72820 RVA: 0x00534F63 File Offset: 0x00533363
		private void OnDisable()
		{
			this.UnBindUiMessages();
		}

		// Token: 0x06011C75 RID: 72821 RVA: 0x00534F6B File Offset: 0x0053336B
		private void BindUiMessages()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationAutoAgreeGoldMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationAutoAgreeGoldMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationOwnerNewRequesterMessage));
		}

		// Token: 0x06011C76 RID: 72822 RVA: 0x00534FA3 File Offset: 0x005333A3
		private void UnBindUiMessages()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationAutoAgreeGoldMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationAutoAgreeGoldMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationOwnerNewRequesterMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationOwnerNewRequesterMessage));
		}

		// Token: 0x06011C77 RID: 72823 RVA: 0x00534FDB File Offset: 0x005333DB
		public void Init(bool isTeamLeader = false, bool isOtherTeam = false, int otherTeamId = 0)
		{
			this._isTeamLeader = isTeamLeader;
			this._isOtherTeam = isOtherTeam;
			this._otherTeamId = otherTeamId;
			this.UpdateTeamLeaderRoot();
		}

		// Token: 0x06011C78 RID: 72824 RVA: 0x00534FF8 File Offset: 0x005333F8
		private void UpdateTeamLeaderRoot()
		{
			if (this._isOtherTeam)
			{
				CommonUtility.UpdateGameObjectVisible(this.teamLeaderRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.normalPlayerRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.otherTeamRoot, true);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.otherTeamRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.normalPlayerRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.teamLeaderRoot, this._isTeamLeader);
			if (this._isTeamLeader)
			{
				this.UpdateAutoAgreeGoldJoinInRoot();
				this.UpdateAutoAgreeGoldJoinInFlag();
				if (this.autoJoinInLabel != null)
				{
					this.autoJoinInLabel.text = TR.Value("team_duplication_troop_room_auto_join_in_team");
				}
				this.UpdateTeamAdjustPositionTip();
				this.UpdateRequestListButtonRedPoint();
			}
		}

		// Token: 0x06011C79 RID: 72825 RVA: 0x005350A8 File Offset: 0x005334A8
		private void UpdateTeamAdjustPositionTip()
		{
			if (this.adjustTeamPositionLabel != null)
			{
				this.adjustTeamPositionLabel.text = TR.Value("team_duplication_troop_room_adjust_team_position");
			}
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyShowPositionAdjustTip)
			{
				CommonUtility.UpdateGameObjectVisible(this.adjustTeamPositionRoot, true);
				if (this.adjustTeamPositionControl != null)
				{
					this.adjustTeamPositionControl.SetVisibleControl();
				}
				DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyShowPositionAdjustTip = true;
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.adjustTeamPositionRoot, false);
			}
		}

		// Token: 0x06011C7A RID: 72826 RVA: 0x00535130 File Offset: 0x00533530
		private void OnQuitButtonClick()
		{
			TeamCopyTeamStatus teamDuplicationTeamStatus = TeamDuplicationUtility.GetTeamDuplicationTeamStatus();
			string contentStr = string.Empty;
			if (teamDuplicationTeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_VICTORY)
			{
				if (DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyReceiveFinalReward)
				{
					this.QuitTeamAction();
					return;
				}
				contentStr = TR.Value("team_duplication_leave_team_with_pass");
			}
			else if (teamDuplicationTeamStatus == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE)
			{
				contentStr = TR.Value("team_duplication_leave_team_normal_tips");
			}
			else
			{
				contentStr = TR.Value("team_duplication_leave_team_without_cost_tips");
				if (!TeamDuplicationUtility.IsPlayerCanFreeQuitTeam())
				{
					contentStr = TR.Value("team_duplication_leave_team_with_cost_tips");
				}
			}
			TeamDuplicationUtility.OnShowLeaveTeamTipFrame(contentStr, new Action(this.QuitTeamAction));
		}

		// Token: 0x06011C7B RID: 72827 RVA: 0x005351BE File Offset: 0x005335BE
		private void QuitTeamAction()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamQuitReq();
		}

		// Token: 0x06011C7C RID: 72828 RVA: 0x005351CA File Offset: 0x005335CA
		private void OnRequesterListButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationRequesterListFrame();
			this.UpdateRequestListButtonRedPoint();
		}

		// Token: 0x06011C7D RID: 72829 RVA: 0x005351D7 File Offset: 0x005335D7
		private void OnRecruitButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationFindTeamMateFrame();
		}

		// Token: 0x06011C7E RID: 72830 RVA: 0x005351DE File Offset: 0x005335DE
		private void OnChatButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationChatFrame();
		}

		// Token: 0x06011C7F RID: 72831 RVA: 0x005351E5 File Offset: 0x005335E5
		private void OnRequestJoinInTeamButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyReq(this._otherTeamId);
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamRoomFrame();
		}

		// Token: 0x06011C80 RID: 72832 RVA: 0x005351FC File Offset: 0x005335FC
		private void OnAutoJoinInButtonClick()
		{
			if (!this._isTeamLeader)
			{
				return;
			}
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyAutoAgreeGoldReq(!teamDuplicationTeamDataModel.AutoAgreeGold);
		}

		// Token: 0x06011C81 RID: 72833 RVA: 0x0053523C File Offset: 0x0053363C
		private void OnTeamSettingButtonClicked()
		{
			if (!this._isTeamLeader)
			{
				return;
			}
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamSettingFrame(new TeamDuplicationTeamBuildDataModel
			{
				TeamDifficultyLevel = teamDuplicationTeamDataModel.TeamDifficultyLevel,
				TeamModelType = teamDuplicationTeamDataModel.TeamModel,
				IsResetEquipmentScore = true,
				OwnerEquipmentScore = teamDuplicationTeamDataModel.TeamEquipScore
			});
		}

		// Token: 0x06011C82 RID: 72834 RVA: 0x005352A0 File Offset: 0x005336A0
		private void UpdateAutoAgreeGoldJoinInRoot()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			if (this.autoAgreeGoldJoinInRoot == null)
			{
				return;
			}
			if (teamDuplicationTeamDataModel.TeamModel == 1)
			{
				CommonUtility.UpdateGameObjectVisible(this.autoAgreeGoldJoinInRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.autoAgreeGoldJoinInRoot, true);
			}
		}

		// Token: 0x06011C83 RID: 72835 RVA: 0x005352FC File Offset: 0x005336FC
		private void UpdateAutoAgreeGoldJoinInFlag()
		{
			TeamDuplicationTeamDataModel teamDuplicationTeamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (teamDuplicationTeamDataModel == null)
			{
				return;
			}
			bool autoAgreeGold = teamDuplicationTeamDataModel.AutoAgreeGold;
			CommonUtility.UpdateGameObjectVisible(this.autoJoinInFlag, autoAgreeGold);
		}

		// Token: 0x06011C84 RID: 72836 RVA: 0x0053532E File Offset: 0x0053372E
		private void UpdateRequestListButtonRedPoint()
		{
			CommonUtility.UpdateGameObjectVisible(this.requestListButtonRedPoint, DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerNewRequester);
		}

		// Token: 0x06011C85 RID: 72837 RVA: 0x00535345 File Offset: 0x00533745
		private void OnAdjustTeamPositionRootAnimationComplete()
		{
			CommonUtility.UpdateGameObjectVisible(this.adjustTeamPositionRoot, false);
		}

		// Token: 0x06011C86 RID: 72838 RVA: 0x00535353 File Offset: 0x00533753
		private void OnReceiveTeamDuplicationAutoAgreeGoldMessage(UIEvent uiEvent)
		{
			if (!this._isTeamLeader)
			{
				return;
			}
			this.UpdateAutoAgreeGoldJoinInFlag();
		}

		// Token: 0x06011C87 RID: 72839 RVA: 0x00535367 File Offset: 0x00533767
		private void OnReceiveTeamDuplicationOwnerNewRequesterMessage(UIEvent uiEvent)
		{
			if (!this._isTeamLeader)
			{
				return;
			}
			this.UpdateRequestListButtonRedPoint();
		}

		// Token: 0x0400B938 RID: 47416
		private bool _isTeamLeader;

		// Token: 0x0400B939 RID: 47417
		private bool _isOtherTeam;

		// Token: 0x0400B93A RID: 47418
		private int _otherTeamId;

		// Token: 0x0400B93B RID: 47419
		[Space(15f)]
		[Header("CommonButton")]
		[Space(5f)]
		[SerializeField]
		private Button quitButton;

		// Token: 0x0400B93C RID: 47420
		[SerializeField]
		private Button recruitButton;

		// Token: 0x0400B93D RID: 47421
		[SerializeField]
		private Button chatButton;

		// Token: 0x0400B93E RID: 47422
		[SerializeField]
		private Button requestJoinInTeamButton;

		// Token: 0x0400B93F RID: 47423
		[SerializeField]
		private Button requestListButton;

		// Token: 0x0400B940 RID: 47424
		[SerializeField]
		private GameObject requestListButtonRedPoint;

		// Token: 0x0400B941 RID: 47425
		[SerializeField]
		private Button teamSettingButton;

		// Token: 0x0400B942 RID: 47426
		[Space(15f)]
		[Header("AutoAgreeGold")]
		[Space(5f)]
		[SerializeField]
		private GameObject autoAgreeGoldJoinInRoot;

		// Token: 0x0400B943 RID: 47427
		[SerializeField]
		private ComButtonWithCd autoAgreeGoldJoinInButton;

		// Token: 0x0400B944 RID: 47428
		[SerializeField]
		private GameObject autoJoinInFlag;

		// Token: 0x0400B945 RID: 47429
		[SerializeField]
		private Text autoJoinInLabel;

		// Token: 0x0400B946 RID: 47430
		[Space(15f)]
		[Header("AdjustTeamPosition")]
		[Space(5f)]
		[SerializeField]
		private GameObject adjustTeamPositionRoot;

		// Token: 0x0400B947 RID: 47431
		[SerializeField]
		private Text adjustTeamPositionLabel;

		// Token: 0x0400B948 RID: 47432
		[SerializeField]
		private CommonGameObjectVisibleControl adjustTeamPositionControl;

		// Token: 0x0400B949 RID: 47433
		[Space(15f)]
		[Header("GameObjectRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject teamLeaderRoot;

		// Token: 0x0400B94A RID: 47434
		[SerializeField]
		private GameObject normalPlayerRoot;

		// Token: 0x0400B94B RID: 47435
		[SerializeField]
		private GameObject otherTeamRoot;
	}
}
