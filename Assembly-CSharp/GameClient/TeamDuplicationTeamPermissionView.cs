using System;
using Protocol;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C32 RID: 7218
	public class TeamDuplicationTeamPermissionView : MonoBehaviour
	{
		// Token: 0x06011B67 RID: 72551 RVA: 0x0053084C File Offset: 0x0052EC4C
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011B68 RID: 72552 RVA: 0x00530854 File Offset: 0x0052EC54
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011B69 RID: 72553 RVA: 0x00530862 File Offset: 0x0052EC62
		private void ClearData()
		{
			this._ownerPlayerDataModel = null;
			this._selectedPlayerDataModel = null;
			this._clickScreenPosition = Vector2.zero;
			this._permissionType = TeamDuplicationPermissionType.None;
		}

		// Token: 0x06011B6A RID: 72554 RVA: 0x00530884 File Offset: 0x0052EC84
		private void OnEnable()
		{
			this.BindUiMessage();
		}

		// Token: 0x06011B6B RID: 72555 RVA: 0x0053088C File Offset: 0x0052EC8C
		private void OnDisable()
		{
			this.UnBindUiMessage();
		}

		// Token: 0x06011B6C RID: 72556 RVA: 0x00530894 File Offset: 0x0052EC94
		private void BindUiMessage()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011B6D RID: 72557 RVA: 0x005308B1 File Offset: 0x0052ECB1
		private void UnBindUiMessage()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011B6E RID: 72558 RVA: 0x005308D0 File Offset: 0x0052ECD0
		private void BindUiEvents()
		{
			if (this.playerCheckInformationButton != null)
			{
				this.playerCheckInformationButton.onClick.RemoveAllListeners();
				this.playerCheckInformationButton.onClick.AddListener(new UnityAction(this.OnPlayerCheckInformationButtonClick));
			}
			if (this.captainMakeCaptainButton != null)
			{
				this.captainMakeCaptainButton.onClick.RemoveAllListeners();
				this.captainMakeCaptainButton.onClick.AddListener(new UnityAction(this.OnCaptainMakeCaptainButtonClick));
			}
			if (this.captainCheckInformationButton != null)
			{
				this.captainCheckInformationButton.onClick.RemoveAllListeners();
				this.captainCheckInformationButton.onClick.AddListener(new UnityAction(this.OnCaptainCheckInformationButtonClick));
			}
			if (this.teamLeaderMakeLeaderButton != null)
			{
				this.teamLeaderMakeLeaderButton.onClick.RemoveAllListeners();
				this.teamLeaderMakeLeaderButton.onClick.AddListener(new UnityAction(this.OnTeamLeaderMakeLeaderButtonClick));
			}
			if (this.teamLeaderCheckInformationButton != null)
			{
				this.teamLeaderCheckInformationButton.onClick.RemoveAllListeners();
				this.teamLeaderCheckInformationButton.onClick.AddListener(new UnityAction(this.OnTeamLeaderCheckInformationButtonClick));
			}
			if (this.teamLeaderMakeCaptainButton != null)
			{
				this.teamLeaderMakeCaptainButton.onClick.RemoveAllListeners();
				this.teamLeaderMakeCaptainButton.onClick.AddListener(new UnityAction(this.OnTeamLeaderMakeCaptainButtonClick));
			}
			if (this.teamLeaderTickOutTeamButton != null)
			{
				this.teamLeaderTickOutTeamButton.onClick.RemoveAllListeners();
				this.teamLeaderTickOutTeamButton.onClick.AddListener(new UnityAction(this.OnTeamLeaderTickOutTeamButtonClick));
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
		}

		// Token: 0x06011B6F RID: 72559 RVA: 0x00530AC8 File Offset: 0x0052EEC8
		private void UnBindUiEvents()
		{
			if (this.playerCheckInformationButton != null)
			{
				this.playerCheckInformationButton.onClick.RemoveAllListeners();
			}
			if (this.captainMakeCaptainButton != null)
			{
				this.captainMakeCaptainButton.onClick.RemoveAllListeners();
			}
			if (this.captainCheckInformationButton != null)
			{
				this.captainCheckInformationButton.onClick.RemoveAllListeners();
			}
			if (this.teamLeaderMakeLeaderButton != null)
			{
				this.teamLeaderMakeLeaderButton.onClick.RemoveAllListeners();
			}
			if (this.teamLeaderCheckInformationButton != null)
			{
				this.teamLeaderCheckInformationButton.onClick.RemoveAllListeners();
			}
			if (this.teamLeaderMakeCaptainButton != null)
			{
				this.teamLeaderMakeCaptainButton.onClick.RemoveAllListeners();
			}
			if (this.teamLeaderTickOutTeamButton != null)
			{
				this.teamLeaderTickOutTeamButton.onClick.RemoveAllListeners();
			}
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011B70 RID: 72560 RVA: 0x00530BE0 File Offset: 0x0052EFE0
		public void Init(TeamDuplicationPermissionDataModel permissionDataModel)
		{
			if (permissionDataModel == null)
			{
				return;
			}
			this._ownerPlayerDataModel = permissionDataModel.OwnerPlayerDataModel;
			this._selectedPlayerDataModel = permissionDataModel.SelectedPlayerDataModel;
			this._clickScreenPosition = permissionDataModel.ClickScreenPosition;
			if (this._ownerPlayerDataModel == null || this._selectedPlayerDataModel == null || this._ownerPlayerDataModel.Guid == this._selectedPlayerDataModel.Guid)
			{
				return;
			}
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011B71 RID: 72561 RVA: 0x00530C58 File Offset: 0x0052F058
		private void InitData()
		{
			this._permissionType = TeamDuplicationPermissionType.PermissionPlayer;
			if (this._ownerPlayerDataModel.IsTeamLeader)
			{
				this._permissionType = TeamDuplicationPermissionType.PermissionTeamLeader;
			}
			else if (this._ownerPlayerDataModel.IsCaptain)
			{
				this._permissionType = TeamDuplicationPermissionType.PermissionPlayer;
				bool flag = TeamDuplicationUtility.IsInSameTroopOfTwoPlayer(this._ownerPlayerDataModel.Guid, this._selectedPlayerDataModel.Guid);
				if (flag)
				{
					this._permissionType = TeamDuplicationPermissionType.PermissionCaptain;
				}
			}
			else
			{
				this._permissionType = TeamDuplicationPermissionType.PermissionPlayer;
			}
		}

		// Token: 0x06011B72 RID: 72562 RVA: 0x00530CD4 File Offset: 0x0052F0D4
		private void InitView()
		{
			this.ResetPermissionRoot();
			this.InitPermissionRoot();
		}

		// Token: 0x06011B73 RID: 72563 RVA: 0x00530CE2 File Offset: 0x0052F0E2
		private void ResetPermissionRoot()
		{
			CommonUtility.UpdateGameObjectVisible(this.playerPermissionRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.captainPermissionRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.teamLeaderPermissionRoot, false);
		}

		// Token: 0x06011B74 RID: 72564 RVA: 0x00530D08 File Offset: 0x0052F108
		private void InitPermissionRoot()
		{
			if (this._permissionType == TeamDuplicationPermissionType.PermissionTeamLeader)
			{
				CommonUtility.UpdateGameObjectVisible(this.teamLeaderPermissionRoot, true);
				if (this._selectedPlayerDataModel != null)
				{
					if (this._selectedPlayerDataModel.IsCaptain)
					{
						CommonUtility.UpdateButtonState(this.teamLeaderMakeCaptainButton, this.teamLeaderMakeCaptainButtonGray, false);
					}
					else
					{
						CommonUtility.UpdateButtonState(this.teamLeaderMakeCaptainButton, this.teamLeaderMakeCaptainButtonGray, true);
					}
					if (this._selectedPlayerDataModel.IsGoldOwner)
					{
						CommonUtility.UpdateButtonState(this.teamLeaderMakeLeaderButton, this.teamLeaderMakeLeaderButtonGray, false);
					}
					else
					{
						CommonUtility.UpdateButtonState(this.teamLeaderMakeLeaderButton, this.teamLeaderMakeLeaderButtonGray, true);
					}
				}
				if (TeamDuplicationUtility.GetTeamDuplicationTeamStatus() == TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE)
				{
					CommonUtility.UpdateButtonState(this.teamLeaderTickOutTeamButton, this.teamLeaderTickOutTeamButtonGray, true);
				}
				else
				{
					CommonUtility.UpdateButtonState(this.teamLeaderTickOutTeamButton, this.teamLeaderTickOutTeamButtonGray, false);
				}
				this.SetPermissionRootPosition(this.teamLeaderPermissionRoot, 20f);
			}
			else if (this._permissionType == TeamDuplicationPermissionType.PermissionCaptain)
			{
				CommonUtility.UpdateGameObjectVisible(this.captainPermissionRoot, true);
				this.SetPermissionRootPosition(this.captainPermissionRoot, 0f);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.playerPermissionRoot, true);
				this.SetPermissionRootPosition(this.playerPermissionRoot, 0f);
			}
		}

		// Token: 0x06011B75 RID: 72565 RVA: 0x00530E40 File Offset: 0x0052F240
		private void SetPermissionRootPosition(GameObject permissionRoot, float adjustYPosition = 0f)
		{
			if (this.bgRoot == null)
			{
				return;
			}
			RectTransform rectTransform = this.bgRoot.transform as RectTransform;
			if (rectTransform == null)
			{
				return;
			}
			if (permissionRoot == null)
			{
				return;
			}
			RectTransform rectTransform2 = permissionRoot.transform as RectTransform;
			if (rectTransform2 == null)
			{
				return;
			}
			Vector2 vector;
			if (!RectTransformUtility.ScreenPointToLocalPointInRectangle(rectTransform, this._clickScreenPosition, Singleton<ClientSystemManager>.GetInstance().UICamera, ref vector))
			{
				return;
			}
			Vector2 sizeDelta = rectTransform2.sizeDelta;
			rectTransform2.anchoredPosition = new Vector2(vector.x + sizeDelta.x / 2f, vector.y - sizeDelta.y / 2f + adjustYPosition);
		}

		// Token: 0x06011B76 RID: 72566 RVA: 0x00530F02 File Offset: 0x0052F302
		private void OnPlayerCheckInformationButtonClick()
		{
			this.TeamDuplicationCheckPlayerInformation();
		}

		// Token: 0x06011B77 RID: 72567 RVA: 0x00530F0A File Offset: 0x0052F30A
		private void OnCaptainMakeCaptainButtonClick()
		{
			this.TeamCopyMakeAppoint(TeamCopyPost.TEAM_COPY_POST_CAPTAIN);
		}

		// Token: 0x06011B78 RID: 72568 RVA: 0x00530F13 File Offset: 0x0052F313
		private void OnCaptainCheckInformationButtonClick()
		{
			this.TeamDuplicationCheckPlayerInformation();
		}

		// Token: 0x06011B79 RID: 72569 RVA: 0x00530F1B File Offset: 0x0052F31B
		private void OnTeamLeaderMakeLeaderButtonClick()
		{
			this.TeamCopyMakeAppoint(TeamCopyPost.TEAM_COPY_POST_CHIEF);
		}

		// Token: 0x06011B7A RID: 72570 RVA: 0x00530F24 File Offset: 0x0052F324
		private void OnTeamLeaderCheckInformationButtonClick()
		{
			this.TeamDuplicationCheckPlayerInformation();
		}

		// Token: 0x06011B7B RID: 72571 RVA: 0x00530F2C File Offset: 0x0052F32C
		private void OnTeamLeaderMakeCaptainButtonClick()
		{
			this.TeamCopyMakeAppoint(TeamCopyPost.TEAM_COPY_POST_CAPTAIN);
		}

		// Token: 0x06011B7C RID: 72572 RVA: 0x00530F35 File Offset: 0x0052F335
		private void OnTeamLeaderTickOutTeamButtonClick()
		{
			if (TeamDuplicationUtility.GetTeamDuplicationTeamStatus() != TeamCopyTeamStatus.TEAM_COPY_TEAM_STATUS_PARPARE)
			{
				return;
			}
			TeamDuplicationUtility.OnShowLeaveTeamTipFrame(TR.Value("team_duplication_kick_team_normal_tips"), new Action(this.TeamCopyKickPlayer));
		}

		// Token: 0x06011B7D RID: 72573 RVA: 0x00530F5D File Offset: 0x0052F35D
		private void TeamCopyMakeAppoint(TeamCopyPost teamCopyPost)
		{
			if (this._selectedPlayerDataModel == null)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyAppointmentReq(this._selectedPlayerDataModel.Guid, (int)teamCopyPost);
			this.CloseFrame();
		}

		// Token: 0x06011B7E RID: 72574 RVA: 0x00530F88 File Offset: 0x0052F388
		private void TeamCopyKickPlayer()
		{
			if (this._selectedPlayerDataModel == null)
			{
				return;
			}
			if (TeamDuplicationUtility.GetPlayerDataModelByGuid(this._selectedPlayerDataModel.Guid) == null)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyKickReq(this._selectedPlayerDataModel.Guid);
			this.CloseFrame();
		}

		// Token: 0x06011B7F RID: 72575 RVA: 0x00530FD4 File Offset: 0x0052F3D4
		private void TeamDuplicationCheckPlayerInformation()
		{
			if (this._selectedPlayerDataModel == null)
			{
				return;
			}
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this._selectedPlayerDataModel.Guid, 1U, (uint)this._selectedPlayerDataModel.ZoneId);
			this.CloseFrame();
		}

		// Token: 0x06011B80 RID: 72576 RVA: 0x00531009 File Offset: 0x0052F409
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			if (this._selectedPlayerDataModel == null || TeamDuplicationUtility.GetPlayerDataModelByGuid(this._selectedPlayerDataModel.Guid) == null)
			{
				this.CloseFrame();
			}
		}

		// Token: 0x06011B81 RID: 72577 RVA: 0x00531031 File Offset: 0x0052F431
		private void OnCloseButtonClick()
		{
			this.CloseFrame();
		}

		// Token: 0x06011B82 RID: 72578 RVA: 0x00531039 File Offset: 0x0052F439
		private void CloseFrame()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamPermissionFrame();
		}

		// Token: 0x0400B89E RID: 47262
		private TeamDuplicationPlayerDataModel _ownerPlayerDataModel;

		// Token: 0x0400B89F RID: 47263
		private TeamDuplicationPlayerDataModel _selectedPlayerDataModel;

		// Token: 0x0400B8A0 RID: 47264
		private Vector2 _clickScreenPosition = Vector2.zero;

		// Token: 0x0400B8A1 RID: 47265
		private TeamDuplicationPermissionType _permissionType;

		// Token: 0x0400B8A2 RID: 47266
		[Space(15f)]
		[Header("close")]
		[Space(10f)]
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B8A3 RID: 47267
		[Space(15f)]
		[Header("BgRoot")]
		[Space(15f)]
		[SerializeField]
		private GameObject bgRoot;

		// Token: 0x0400B8A4 RID: 47268
		[Space(15f)]
		[Header("playerPermission")]
		[Space(10f)]
		[SerializeField]
		private Button playerCheckInformationButton;

		// Token: 0x0400B8A5 RID: 47269
		[SerializeField]
		private GameObject playerPermissionRoot;

		// Token: 0x0400B8A6 RID: 47270
		[Space(15f)]
		[Header("captainPermission")]
		[Space(10f)]
		[SerializeField]
		private Button captainMakeCaptainButton;

		// Token: 0x0400B8A7 RID: 47271
		[SerializeField]
		private Button captainCheckInformationButton;

		// Token: 0x0400B8A8 RID: 47272
		[SerializeField]
		private GameObject captainPermissionRoot;

		// Token: 0x0400B8A9 RID: 47273
		[Space(15f)]
		[Header("teamLeaderPermission")]
		[Space(10f)]
		[SerializeField]
		private Button teamLeaderMakeLeaderButton;

		// Token: 0x0400B8AA RID: 47274
		[SerializeField]
		private UIGray teamLeaderMakeLeaderButtonGray;

		// Token: 0x0400B8AB RID: 47275
		[SerializeField]
		private Button teamLeaderCheckInformationButton;

		// Token: 0x0400B8AC RID: 47276
		[SerializeField]
		private Button teamLeaderMakeCaptainButton;

		// Token: 0x0400B8AD RID: 47277
		[SerializeField]
		private UIGray teamLeaderMakeCaptainButtonGray;

		// Token: 0x0400B8AE RID: 47278
		[SerializeField]
		private Button teamLeaderTickOutTeamButton;

		// Token: 0x0400B8AF RID: 47279
		[SerializeField]
		private UIGray teamLeaderTickOutTeamButtonGray;

		// Token: 0x0400B8B0 RID: 47280
		[SerializeField]
		private GameObject teamLeaderPermissionRoot;
	}
}
