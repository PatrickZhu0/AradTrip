using System;
using Protocol;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C9E RID: 7326
	public class TeamDuplicationTeamListItem : MonoBehaviour
	{
		// Token: 0x06011F74 RID: 73588 RVA: 0x005408EB File Offset: 0x0053ECEB
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011F75 RID: 73589 RVA: 0x005408F3 File Offset: 0x0053ECF3
		private void OnDestroy()
		{
			this.UnBindUiEvents();
		}

		// Token: 0x06011F76 RID: 73590 RVA: 0x005408FC File Offset: 0x0053ECFC
		private void BindUiEvents()
		{
			if (this.detailButton != null)
			{
				this.detailButton.onClick.RemoveAllListeners();
				this.detailButton.onClick.AddListener(new UnityAction(this.OnDetailButtonClick));
			}
			if (this.requestButton != null)
			{
				this.requestButton.ResetButtonListener();
				this.requestButton.SetButtonListener(new Action(this.OnRequestButtonClick));
			}
		}

		// Token: 0x06011F77 RID: 73591 RVA: 0x00540979 File Offset: 0x0053ED79
		private void UnBindUiEvents()
		{
			if (this.detailButton != null)
			{
				this.detailButton.onClick.RemoveAllListeners();
			}
			if (this.requestButton != null)
			{
				this.requestButton.ResetButtonListener();
			}
		}

		// Token: 0x06011F78 RID: 73592 RVA: 0x005409B8 File Offset: 0x0053EDB8
		private void OnEnable()
		{
			this.BindUiMessage();
		}

		// Token: 0x06011F79 RID: 73593 RVA: 0x005409C0 File Offset: 0x0053EDC0
		private void OnDisable()
		{
			this.UnBindUiMessage();
		}

		// Token: 0x06011F7A RID: 73594 RVA: 0x005409C8 File Offset: 0x0053EDC8
		private void BindUiMessage()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationJoinTeamInCdTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationJoinTeamInCdTimeMessage));
		}

		// Token: 0x06011F7B RID: 73595 RVA: 0x005409E5 File Offset: 0x0053EDE5
		private void UnBindUiMessage()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationJoinTeamInCdTimeMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationJoinTeamInCdTimeMessage));
		}

		// Token: 0x06011F7C RID: 73596 RVA: 0x00540A02 File Offset: 0x0053EE02
		public void Init(TeamDuplicationTeamListDataModel teamDataModel)
		{
			this._teamListDataModel = teamDataModel;
			if (this._teamListDataModel == null)
			{
				Logger.LogErrorFormat("TeamDuplicationTeamItem teamDataModel is null", new object[0]);
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F7D RID: 73597 RVA: 0x00540A30 File Offset: 0x0053EE30
		private void InitItem()
		{
			if (this._teamListDataModel.TeamModel == TeamCopyTeamModel.TEAM_COPY_TEAM_MODEL_CHALLENGE)
			{
				CommonUtility.UpdateGameObjectVisible(this.challengeRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.goldTeamRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.challengeRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.goldTeamRoot, true);
			}
			if (this.goldValue != null)
			{
				if (this._teamListDataModel.GoldValue <= 0)
				{
					this.goldValue.text = TR.Value("team_duplication_team_no_gold");
				}
				else
				{
					this.goldValue.text = this._teamListDataModel.GoldValue.ToString();
				}
			}
			if (this.teamName != null)
			{
				this.teamName.text = this._teamListDataModel.TeamName;
			}
			if (this._teamListDataModel.TeamHardLevel == 2U)
			{
				CommonUtility.UpdateGameObjectVisible(this.teamHardLevelFlag, true);
				CommonUtility.UpdateGameObjectVisible(this.teamNormalLevelFlag, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.teamHardLevelFlag, false);
				CommonUtility.UpdateGameObjectVisible(this.teamNormalLevelFlag, true);
			}
			int totalPlayerNumberInTeamDuplication = TeamDuplicationUtility.GetTotalPlayerNumberInTeamDuplication(this._teamListDataModel.TeamType);
			if (this.teamNumberValue != null)
			{
				this.teamNumberValue.text = TR.Value("team_duplication_team_number", this._teamListDataModel.TeamNumber, totalPlayerNumberInTeamDuplication);
			}
			if (this.equipmentScore != null)
			{
				this.equipmentScore.text = this._teamListDataModel.EquipmentScore.ToString();
			}
			this.UpdateTeamDuplicationStatus(this._teamListDataModel.TroopStatus);
			this.UpdateRequestButton();
		}

		// Token: 0x06011F7E RID: 73598 RVA: 0x00540BE4 File Offset: 0x0053EFE4
		private void UpdateTeamDuplicationStatus(int troopStatus)
		{
			string text = TR.Value("team_duplication_team_status_prepare");
			if (troopStatus == 1)
			{
				text = TR.Value("team_duplication_team_status_fight");
			}
			if (this.teamStatus != null)
			{
				this.teamStatus.text = text;
			}
		}

		// Token: 0x06011F7F RID: 73599 RVA: 0x00540C30 File Offset: 0x0053F030
		private void UpdateRequestButton()
		{
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationGoldOwner && DataManager<PlayerBaseData>.GetInstance().Gold < (ulong)((long)this._teamListDataModel.GoldValue))
			{
				CommonUtility.UpdateGameObjectVisible(this.lockRequest, true);
				CommonUtility.UpdateGameObjectVisible(this.requestButtonRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.lockRequest, false);
				CommonUtility.UpdateGameObjectVisible(this.requestButtonRoot, true);
				if (this.requestButton != null)
				{
					this.requestButton.SetCountDownTimeDescription(TR.Value("team_duplication_request_join_in_normal_format"), TR.Value("team_duplication_request_join_in_count_down_time_format"));
				}
				int teamRequestJoinInEndTime = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamRequestJoinInEndTime((int)this._teamListDataModel.TeamId);
				this.UpdateRequestButton(teamRequestJoinInEndTime);
			}
		}

		// Token: 0x06011F80 RID: 73600 RVA: 0x00540CE9 File Offset: 0x0053F0E9
		private void OnDetailButtonClick()
		{
			if (this._teamListDataModel == null)
			{
				return;
			}
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamRoomFrame((int)this._teamListDataModel.TeamId);
		}

		// Token: 0x06011F81 RID: 73601 RVA: 0x00540D08 File Offset: 0x0053F108
		private void OnRequestButtonClick()
		{
			if (this._teamListDataModel == null)
			{
				Logger.LogErrorFormat("TeamListDataModel is null", new object[0]);
				return;
			}
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_join_in_troop_failed_with_team"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (TeamDuplicationUtility.IsJoinInTeamDuplicationGoldIsNotEnough(this._teamListDataModel.GoldValue))
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_join_in_troop_failed_with_gold"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyReq((int)this._teamListDataModel.TeamId);
			if (this.requestButton != null)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().SetTeamRequestJoinInEndTime((int)this._teamListDataModel.TeamId, (int)(DataManager<TimeManager>.GetInstance().GetServerTime() + (uint)((int)this.requestButton.GetButtonCdTime())));
			}
		}

		// Token: 0x06011F82 RID: 73602 RVA: 0x00540DCC File Offset: 0x0053F1CC
		private void OnReceiveTeamDuplicationJoinTeamInCdTimeMessage(UIEvent uiEvent)
		{
			if (this._teamListDataModel == null)
			{
				return;
			}
			if (uiEvent == null || uiEvent.Param1 == null)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (this._teamListDataModel.TeamId != (uint)num)
			{
				return;
			}
			int teamRequestJoinInEndTime = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamRequestJoinInEndTime(num);
			this.UpdateRequestButton(teamRequestJoinInEndTime);
		}

		// Token: 0x06011F83 RID: 73603 RVA: 0x00540E28 File Offset: 0x0053F228
		private void UpdateRequestButton(int requestJoinInEndTime)
		{
			if (this.requestButton == null)
			{
				return;
			}
			if (requestJoinInEndTime <= 0 || (long)requestJoinInEndTime <= (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime()))
			{
				this.requestButton.Reset();
			}
			else
			{
				this.requestButton.Reset();
				long num = (long)requestJoinInEndTime - (long)((ulong)DataManager<TimeManager>.GetInstance().GetServerTime());
				this.requestButton.SetButtonTimeLimit((float)num);
			}
		}

		// Token: 0x06011F84 RID: 73604 RVA: 0x00540E97 File Offset: 0x0053F297
		public void Reset()
		{
			this._teamListDataModel = null;
		}

		// Token: 0x0400BB43 RID: 47939
		private TeamDuplicationTeamListDataModel _teamListDataModel;

		// Token: 0x0400BB44 RID: 47940
		[Space(10f)]
		[Header("Type")]
		[Space(5f)]
		[SerializeField]
		private GameObject challengeRoot;

		// Token: 0x0400BB45 RID: 47941
		[SerializeField]
		private GameObject goldTeamRoot;

		// Token: 0x0400BB46 RID: 47942
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text goldValue;

		// Token: 0x0400BB47 RID: 47943
		[SerializeField]
		private Text teamName;

		// Token: 0x0400BB48 RID: 47944
		[SerializeField]
		private Text teamNumberValue;

		// Token: 0x0400BB49 RID: 47945
		[SerializeField]
		private Text equipmentScore;

		// Token: 0x0400BB4A RID: 47946
		[SerializeField]
		private Text teamStatus;

		// Token: 0x0400BB4B RID: 47947
		[Space(10f)]
		[Header("TeamHardLevel")]
		[Space(5f)]
		[SerializeField]
		private GameObject teamNormalLevelFlag;

		// Token: 0x0400BB4C RID: 47948
		[SerializeField]
		private GameObject teamHardLevelFlag;

		// Token: 0x0400BB4D RID: 47949
		[Space(10f)]
		[Header("SearchButton")]
		[Space(5f)]
		[SerializeField]
		private Button detailButton;

		// Token: 0x0400BB4E RID: 47950
		[Space(10f)]
		[Header("RequestButton")]
		[Space(5f)]
		[SerializeField]
		private GameObject requestButtonRoot;

		// Token: 0x0400BB4F RID: 47951
		[SerializeField]
		private ComButtonWithCd requestButton;

		// Token: 0x0400BB50 RID: 47952
		[SerializeField]
		private GameObject lockRequest;
	}
}
