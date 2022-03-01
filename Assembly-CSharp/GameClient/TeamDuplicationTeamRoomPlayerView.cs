using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001CA2 RID: 7330
	public class TeamDuplicationTeamRoomPlayerView : TeamDuplicationBasePlayerItem
	{
		// Token: 0x06011FBD RID: 73661 RVA: 0x00542189 File Offset: 0x00540589
		protected override void Awake()
		{
			this.BindUiEvents();
			base.Awake();
		}

		// Token: 0x06011FBE RID: 73662 RVA: 0x00542197 File Offset: 0x00540597
		protected override void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
			base.OnDestroy();
		}

		// Token: 0x06011FBF RID: 73663 RVA: 0x005421AB File Offset: 0x005405AB
		private void ClearData()
		{
			this._isOtherTeam = false;
		}

		// Token: 0x06011FC0 RID: 73664 RVA: 0x005421B4 File Offset: 0x005405B4
		private void BindUiEvents()
		{
			if (this.playerItemButton != null)
			{
				this.playerItemButton.onClick.RemoveAllListeners();
				this.playerItemButton.onClick.AddListener(new UnityAction(this.OnPlayerItemButtonClick));
			}
		}

		// Token: 0x06011FC1 RID: 73665 RVA: 0x005421F3 File Offset: 0x005405F3
		private void UnBindUiEvents()
		{
			if (this.playerItemButton != null)
			{
				this.playerItemButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011FC2 RID: 73666 RVA: 0x00542216 File Offset: 0x00540616
		public void InitItem(TeamDuplicationPlayerDataModel playerDataModel, bool isOtherTeam = false)
		{
			this._isOtherTeam = isOtherTeam;
			base.Init(playerDataModel);
			this.InitTeamRoomPlayerView();
		}

		// Token: 0x06011FC3 RID: 73667 RVA: 0x0054222C File Offset: 0x0054062C
		private void InitTeamRoomPlayerView()
		{
			this.UpdatePlayerTypeFlag();
			this.UpdatePlayerDetailInfo();
			this.UpdatePlayerTicketInfo();
			this.InitPlayerGrayCover();
		}

		// Token: 0x06011FC4 RID: 73668 RVA: 0x00542248 File Offset: 0x00540648
		private void InitPlayerGrayCover()
		{
			if (this.PlayerDataModel == null)
			{
				this.ResetPlayerGrayView();
				return;
			}
			ulong expireTime = this.PlayerDataModel.ExpireTime;
			this.UpdatePlayerGrayView(expireTime);
		}

		// Token: 0x06011FC5 RID: 73669 RVA: 0x0054227A File Offset: 0x0054067A
		private void ResetPlayerTypeFlag()
		{
			CommonUtility.UpdateGameObjectVisible(this.teamLeaderRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.captainerRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.goldRoot, false);
		}

		// Token: 0x06011FC6 RID: 73670 RVA: 0x005422A0 File Offset: 0x005406A0
		private void UpdatePlayerTypeFlag()
		{
			this.ResetPlayerTypeFlag();
			if (this.PlayerDataModel.IsTeamLeader)
			{
				CommonUtility.UpdateGameObjectVisible(this.teamLeaderRoot, true);
			}
			else if (this.PlayerDataModel.IsGoldOwner)
			{
				CommonUtility.UpdateGameObjectVisible(this.goldRoot, true);
			}
			else if (this.PlayerDataModel.IsCaptain)
			{
				CommonUtility.UpdateGameObjectVisible(this.captainerRoot, true);
			}
		}

		// Token: 0x06011FC7 RID: 73671 RVA: 0x00542314 File Offset: 0x00540714
		private void UpdatePlayerDetailInfo()
		{
			if (this.playerNameText != null)
			{
				this.playerNameText.text = this.PlayerDataModel.Name;
			}
			if (this.playerEquipmentScoreText != null)
			{
				this.playerEquipmentScoreText.text = this.PlayerDataModel.EquipmentScore.ToString();
			}
			if (this.playerProfessionText != null)
			{
				this.playerProfessionText.text = TeamDuplicationUtility.GetJobName(this.PlayerDataModel.ProfessionId, 0);
			}
			if (this.playerLevelText != null)
			{
				this.playerLevelText.text = string.Format(TR.Value("team_duplication_troop_room_player_level"), this.PlayerDataModel.Level);
			}
		}

		// Token: 0x06011FC8 RID: 73672 RVA: 0x005423E4 File Offset: 0x005407E4
		public void UpdatePlayerTicketInfo()
		{
			if (this.notEnoughTicketRoot == null)
			{
				return;
			}
			if (this._isOtherTeam)
			{
				CommonUtility.UpdateGameObjectVisible(this.notEnoughTicketRoot, false);
			}
			else if (TeamDuplicationUtility.IsTeamDuplicationFightStart())
			{
				CommonUtility.UpdateGameObjectVisible(this.notEnoughTicketRoot, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.notEnoughTicketRoot, !this.PlayerDataModel.TicketIsEnough);
			}
		}

		// Token: 0x06011FC9 RID: 73673 RVA: 0x00542454 File Offset: 0x00540854
		public void UpdatePlayerGrayView(ulong expireTime)
		{
			if (expireTime == 0UL)
			{
				this.ResetPlayerGrayView();
			}
			else
			{
				CommonUtility.UpdateGameObjectUiGray(this.playerUIGray, true);
				if (this._isOtherTeam)
				{
					this.UpdatePlayerGrayCountDownTimeController(false, 0UL);
				}
				else if (!TeamDuplicationUtility.IsTeamDuplicationFightStart())
				{
					this.UpdatePlayerGrayCountDownTimeController(false, 0UL);
				}
				else
				{
					this.UpdatePlayerGrayCountDownTimeController(true, expireTime);
				}
			}
		}

		// Token: 0x06011FCA RID: 73674 RVA: 0x005424BC File Offset: 0x005408BC
		private void UpdatePlayerGrayCountDownTimeController(bool flag, ulong expireTime = 0UL)
		{
			if (this.playerGrayCountDownTimeController == null)
			{
				return;
			}
			if (!flag)
			{
				this.playerGrayCountDownTimeController.ResetCountDownTimeController();
				CommonUtility.UpdateGameObjectVisible(this.playerGrayCountDownTimeController.gameObject, false);
			}
			else
			{
				CommonUtility.UpdateGameObjectVisible(this.playerGrayCountDownTimeController.gameObject, true);
				this.playerGrayCountDownTimeController.EndTime = (uint)expireTime;
				this.playerGrayCountDownTimeController.InitCountDownTimeController();
			}
		}

		// Token: 0x06011FCB RID: 73675 RVA: 0x0054252B File Offset: 0x0054092B
		public void ResetPlayerGrayView()
		{
			CommonUtility.UpdateGameObjectUiGray(this.playerUIGray, false);
			this.UpdatePlayerGrayCountDownTimeController(false, 0UL);
		}

		// Token: 0x06011FCC RID: 73676 RVA: 0x00542544 File Offset: 0x00540944
		private void OnPlayerItemButtonClick()
		{
			if (this.PlayerDataModel == null || this.PlayerDataModel.Guid == 0UL)
			{
				Logger.LogErrorFormat("OnPlayerItemButtonClick PlayerDataModel is Error", new object[0]);
				return;
			}
			if (this._isOtherTeam)
			{
				DataManager<OtherPlayerInfoManager>.GetInstance().SendWatchOtherPlayerInfo(this.PlayerDataModel.Guid, 1U, (uint)this.PlayerDataModel.ZoneId);
				return;
			}
			if (this.PlayerDataModel.Guid == DataManager<PlayerBaseData>.GetInstance().RoleID)
			{
				return;
			}
			TeamDuplicationPlayerDataModel ownerPlayerDataModel = TeamDuplicationUtility.GetOwnerPlayerDataModel();
			if (ownerPlayerDataModel == null || ownerPlayerDataModel.Guid == 0UL)
			{
				return;
			}
			Vector3 vector = Vector2.zero;
			RectTransform rectTransform = this.playerItemButton.transform as RectTransform;
			if (rectTransform != null && Singleton<ClientSystemManager>.GetInstance().UICamera != null)
			{
				vector = Singleton<ClientSystemManager>.GetInstance().UICamera.WorldToScreenPoint(rectTransform.position);
			}
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamPermissionFrame(ownerPlayerDataModel, this.PlayerDataModel, vector);
		}

		// Token: 0x0400BB7B RID: 47995
		private bool _isOtherTeam;

		// Token: 0x0400BB7C RID: 47996
		[Space(25f)]
		[Header("GrayPlayer")]
		[Space(10f)]
		[SerializeField]
		private UIGray playerUIGray;

		// Token: 0x0400BB7D RID: 47997
		[SerializeField]
		private CountDownTimeController playerGrayCountDownTimeController;

		// Token: 0x0400BB7E RID: 47998
		[Space(15f)]
		[Header("OwnerPlayerRoot")]
		[Space(5f)]
		[SerializeField]
		private GameObject teamLeaderRoot;

		// Token: 0x0400BB7F RID: 47999
		[SerializeField]
		private GameObject captainerRoot;

		// Token: 0x0400BB80 RID: 48000
		[SerializeField]
		private GameObject goldRoot;

		// Token: 0x0400BB81 RID: 48001
		[SerializeField]
		private Button playerItemButton;

		// Token: 0x0400BB82 RID: 48002
		[Space(15f)]
		[Header("Detail")]
		[Space(5f)]
		[SerializeField]
		private Text playerNameText;

		// Token: 0x0400BB83 RID: 48003
		[SerializeField]
		private Text playerEquipmentScoreText;

		// Token: 0x0400BB84 RID: 48004
		[SerializeField]
		private Text playerProfessionText;

		// Token: 0x0400BB85 RID: 48005
		[SerializeField]
		private Text playerLevelText;

		// Token: 0x0400BB86 RID: 48006
		[Space(15f)]
		[Header("Ticket")]
		[Space(5f)]
		[SerializeField]
		private GameObject notEnoughTicketRoot;
	}
}
