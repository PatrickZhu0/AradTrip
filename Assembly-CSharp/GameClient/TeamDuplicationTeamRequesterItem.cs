using System;
using System.Collections.Generic;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C9F RID: 7327
	public class TeamDuplicationTeamRequesterItem : MonoBehaviour
	{
		// Token: 0x06011F86 RID: 73606 RVA: 0x00540EA8 File Offset: 0x0053F2A8
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011F87 RID: 73607 RVA: 0x00540EB0 File Offset: 0x0053F2B0
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011F88 RID: 73608 RVA: 0x00540EC0 File Offset: 0x0053F2C0
		private void BindUiEvents()
		{
			if (this.searchButton != null)
			{
				this.searchButton.onClick.RemoveAllListeners();
				this.searchButton.onClick.AddListener(new UnityAction(this.OnSearchButtonClick));
			}
			if (this.inviteButton != null)
			{
				this.inviteButton.ResetListener();
				this.inviteButton.SetButtonListener(new Action(this.OnInviteButtonClick));
			}
			if (this.refuseButton != null)
			{
				this.refuseButton.ResetListener();
				this.refuseButton.SetButtonListener(new Action(this.OnRefuseButtonClick));
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.ResetListener();
				this.agreeButton.SetButtonListener(new Action(this.OnAgreeButtonClick));
			}
		}

		// Token: 0x06011F89 RID: 73609 RVA: 0x00540FA4 File Offset: 0x0053F3A4
		private void UnBindUiEvents()
		{
			if (this.searchButton != null)
			{
				this.searchButton.onClick.RemoveAllListeners();
			}
			if (this.inviteButton != null)
			{
				this.inviteButton.ResetListener();
			}
			if (this.refuseButton != null)
			{
				this.refuseButton.ResetListener();
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.ResetListener();
			}
		}

		// Token: 0x06011F8A RID: 73610 RVA: 0x00541026 File Offset: 0x0053F426
		private void ClearData()
		{
			this._requesterDataModel = null;
			this._isRequester = false;
		}

		// Token: 0x06011F8B RID: 73611 RVA: 0x00541036 File Offset: 0x0053F436
		public void Init(TeamDuplicationRequesterDataModel requesterDataModel, bool isRequester = true)
		{
			this._requesterDataModel = requesterDataModel;
			this._isRequester = isRequester;
			if (this._requesterDataModel == null)
			{
				return;
			}
			this.InitItem();
		}

		// Token: 0x06011F8C RID: 73612 RVA: 0x00541058 File Offset: 0x0053F458
		private void InitItem()
		{
			this.SetRequestPlayerType();
			if (this.nameText != null)
			{
				this.nameText.text = this._requesterDataModel.Name;
			}
			if (this.professionNameText != null)
			{
				this.professionNameText.text = TeamDuplicationUtility.GetJobName(this._requesterDataModel.ProfessionId, 0);
			}
			if (this.levelText != null)
			{
				this.levelText.text = this._requesterDataModel.Level.ToString();
			}
			if (this.equipmentScoreText != null)
			{
				this.equipmentScoreText.text = this._requesterDataModel.EquipmentScore.ToString();
			}
			this.UpdateButtonRoot();
		}

		// Token: 0x06011F8D RID: 73613 RVA: 0x0054112C File Offset: 0x0053F52C
		private void SetRequestPlayerType()
		{
			if (this.goldRoot == null)
			{
				return;
			}
			if (this._requesterDataModel.IsGold)
			{
				CommonUtility.UpdateGameObjectVisible(this.goldRoot, true);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.goldRoot, false);
			}
		}

		// Token: 0x06011F8E RID: 73614 RVA: 0x00541178 File Offset: 0x0053F578
		private void UpdateButtonRoot()
		{
			this.ResetButtonWithCd();
			if (this._isRequester)
			{
				CommonUtility.UpdateGameObjectVisible(this.requestButtonRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.inviteButtonRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.requestButtonRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.inviteButtonRoot, true);
			}
		}

		// Token: 0x06011F8F RID: 73615 RVA: 0x005411CC File Offset: 0x0053F5CC
		private void ResetButtonWithCd()
		{
			if (this.inviteButton != null)
			{
				this.inviteButton.Reset();
			}
			if (this.agreeButton != null)
			{
				this.agreeButton.Reset();
			}
			if (this.refuseButton != null)
			{
				this.refuseButton.Reset();
			}
		}

		// Token: 0x06011F90 RID: 73616 RVA: 0x00541230 File Offset: 0x0053F630
		private void OnSearchButtonClick()
		{
			if (this._requesterDataModel == null)
			{
				return;
			}
			if (this._requesterDataModel.PlayerGuid <= 0UL)
			{
				return;
			}
			DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this._requesterDataModel.PlayerGuid, 1U, (uint)this._requesterDataModel.ZoneId);
		}

		// Token: 0x06011F91 RID: 73617 RVA: 0x00541280 File Offset: 0x0053F680
		private void OnInviteButtonClick()
		{
			if (this._requesterDataModel == null)
			{
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_troop_invite_friend"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			List<ulong> playerIdList = this.GetPlayerIdList();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyInvitePlayer(playerIdList);
		}

		// Token: 0x06011F92 RID: 73618 RVA: 0x005412BC File Offset: 0x0053F6BC
		private void OnRefuseButtonClick()
		{
			if (this._requesterDataModel == null)
			{
				return;
			}
			List<ulong> playerIdList = this.GetPlayerIdList();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyReplyReq(false, playerIdList);
		}

		// Token: 0x06011F93 RID: 73619 RVA: 0x005412E8 File Offset: 0x0053F6E8
		private void OnAgreeButtonClick()
		{
			if (this._requesterDataModel == null)
			{
				return;
			}
			List<ulong> playerIdList = this.GetPlayerIdList();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyReplyReq(true, playerIdList);
		}

		// Token: 0x06011F94 RID: 73620 RVA: 0x00541314 File Offset: 0x0053F714
		private List<ulong> GetPlayerIdList()
		{
			List<ulong> list = new List<ulong>();
			if (this._requesterDataModel != null)
			{
				list.Add(this._requesterDataModel.PlayerGuid);
			}
			return list;
		}

		// Token: 0x06011F95 RID: 73621 RVA: 0x00541344 File Offset: 0x0053F744
		public void OnInviteButtonUpdate()
		{
			if (this.inviteButton != null)
			{
				this.inviteButton.Reset();
				float buttonCdTime = this.inviteButton.GetButtonCdTime();
				this.inviteButton.SetButtonTimeLimit(buttonCdTime);
			}
		}

		// Token: 0x06011F96 RID: 73622 RVA: 0x00541385 File Offset: 0x0053F785
		public void Reset()
		{
			this.ClearData();
		}

		// Token: 0x0400BB51 RID: 47953
		private TeamDuplicationRequesterDataModel _requesterDataModel;

		// Token: 0x0400BB52 RID: 47954
		private bool _isRequester;

		// Token: 0x0400BB53 RID: 47955
		[Space(10f)]
		[Header("requestPlayerType")]
		[Space(5f)]
		[SerializeField]
		private GameObject goldRoot;

		// Token: 0x0400BB54 RID: 47956
		[Space(10f)]
		[Header("Text")]
		[Space(5f)]
		[SerializeField]
		private Text nameText;

		// Token: 0x0400BB55 RID: 47957
		[SerializeField]
		private Text professionNameText;

		// Token: 0x0400BB56 RID: 47958
		[SerializeField]
		private Text levelText;

		// Token: 0x0400BB57 RID: 47959
		[SerializeField]
		private Text equipmentScoreText;

		// Token: 0x0400BB58 RID: 47960
		[Space(10f)]
		[Header("SearchButton")]
		[Space(5f)]
		[SerializeField]
		private Button searchButton;

		// Token: 0x0400BB59 RID: 47961
		[Space(10f)]
		[Header("RequestButton")]
		[Space(5f)]
		[SerializeField]
		private GameObject inviteButtonRoot;

		// Token: 0x0400BB5A RID: 47962
		[SerializeField]
		private ComButtonWithCd inviteButton;

		// Token: 0x0400BB5B RID: 47963
		[Space(10f)]
		[Header("AgreeButton")]
		[Space(5f)]
		[SerializeField]
		private GameObject requestButtonRoot;

		// Token: 0x0400BB5C RID: 47964
		[SerializeField]
		private ComButtonWithCd refuseButton;

		// Token: 0x0400BB5D RID: 47965
		[SerializeField]
		private ComButtonWithCd agreeButton;
	}
}
