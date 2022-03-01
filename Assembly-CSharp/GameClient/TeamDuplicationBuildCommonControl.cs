using System;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C3B RID: 7227
	public class TeamDuplicationBuildCommonControl : MonoBehaviour
	{
		// Token: 0x06011BEC RID: 72684 RVA: 0x00532C9B File Offset: 0x0053109B
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06011BED RID: 72685 RVA: 0x00532CA3 File Offset: 0x005310A3
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06011BEE RID: 72686 RVA: 0x00532CB4 File Offset: 0x005310B4
		private void BindEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
				this.backButton.onClick.AddListener(new UnityAction(this.OnBackButtonClick));
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
			if (this.teamDuplicationTroopListButton != null)
			{
				this.teamDuplicationTroopListButton.onClick.RemoveAllListeners();
				this.teamDuplicationTroopListButton.onClick.AddListener(new UnityAction(this.OnTeamDuplicationTroopListButtonClick));
			}
			if (this.teamDuplicationTroopForwardButton != null)
			{
				this.teamDuplicationTroopForwardButton.onClick.RemoveAllListeners();
				this.teamDuplicationTroopForwardButton.onClick.AddListener(new UnityAction(this.OnTeamDuplicationForwardButtonClick));
			}
		}

		// Token: 0x06011BEF RID: 72687 RVA: 0x00532DF4 File Offset: 0x005311F4
		private void UnBindEvents()
		{
			if (this.backButton != null)
			{
				this.backButton.onClick.RemoveAllListeners();
			}
			if (this.packageButton != null)
			{
				this.packageButton.onClick.RemoveAllListeners();
			}
			if (this.skillButton != null)
			{
				this.skillButton.onClick.RemoveAllListeners();
			}
			if (this.teamDuplicationTroopListButton != null)
			{
				this.teamDuplicationTroopListButton.onClick.RemoveAllListeners();
			}
			if (this.teamDuplicationTroopForwardButton != null)
			{
				this.teamDuplicationTroopForwardButton.onClick.RemoveAllListeners();
			}
		}

		// Token: 0x06011BF0 RID: 72688 RVA: 0x00532EA6 File Offset: 0x005312A6
		private void ClearData()
		{
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011BF1 RID: 72689 RVA: 0x00532EB0 File Offset: 0x005312B0
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationLeaveTeamMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationLeaveTeamMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011BF2 RID: 72690 RVA: 0x00532F10 File Offset: 0x00531310
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationLeaveTeamMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationLeaveTeamMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011BF3 RID: 72691 RVA: 0x00532F6E File Offset: 0x0053136E
		public void Init(bool isIn65LevelTeamDuplication = false)
		{
			this._isIn65LevelTeamDuplication = isIn65LevelTeamDuplication;
			this.UpdateTeamDuplicationButton();
			this.UpdateHelpButton();
			this.UpdateShopButtonControl();
		}

		// Token: 0x06011BF4 RID: 72692 RVA: 0x00532F8C File Offset: 0x0053138C
		private void UpdateHelpButton()
		{
			if (this.helpNewAssistant == null)
			{
				return;
			}
			int helpId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildHelpIdWithNormalLevel;
			if (this._isIn65LevelTeamDuplication)
			{
				helpId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationBuildHelpIdWith65Level;
			}
			this.helpNewAssistant.HelpId = helpId;
		}

		// Token: 0x06011BF5 RID: 72693 RVA: 0x00532FD8 File Offset: 0x005313D8
		private void UpdateShopButtonControl()
		{
			if (this.shopButtonControl == null)
			{
				return;
			}
			int shopId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationShopIdWithNormalLevel;
			if (this._isIn65LevelTeamDuplication)
			{
				shopId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationShopIdWith65Level;
			}
			this.shopButtonControl.SetShopId(shopId);
		}

		// Token: 0x06011BF6 RID: 72694 RVA: 0x00533024 File Offset: 0x00531424
		private void UpdateTeamDuplicationButton()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				CommonUtility.UpdateButtonVisible(this.teamDuplicationTroopListButton, true);
				CommonUtility.UpdateButtonVisible(this.teamDuplicationTroopForwardButton, false);
			}
			else
			{
				CommonUtility.UpdateButtonVisible(this.teamDuplicationTroopListButton, false);
				CommonUtility.UpdateButtonVisible(this.teamDuplicationTroopForwardButton, true);
			}
		}

		// Token: 0x06011BF7 RID: 72695 RVA: 0x00533075 File Offset: 0x00531475
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			this.UpdateTeamDuplicationButton();
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				TeamDuplicationUtility.OnCloseRelationFrameByOwnerTeam();
			}
		}

		// Token: 0x06011BF8 RID: 72696 RVA: 0x00533091 File Offset: 0x00531491
		private void OnReceiveTeamDuplicationLeaveTeamMessage(UIEvent uiEvent)
		{
			this.UpdateTeamDuplicationButton();
			TeamDuplicationUtility.OnCloseRelationFrameByLeaveTeam();
		}

		// Token: 0x06011BF9 RID: 72697 RVA: 0x0053309E File Offset: 0x0053149E
		private void OnBackButtonClick()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				this.OnDoBackReturn();
			}
			else
			{
				TeamDuplicationUtility.OnQuitTeamAndReturnToTown(TR.Value("team_duplication_quit_team_and_return_town"), new Action(this.OnDoBackReturn));
			}
		}

		// Token: 0x06011BFA RID: 72698 RVA: 0x005330D5 File Offset: 0x005314D5
		private void OnDoBackReturn()
		{
			TeamDuplicationUtility.SwitchToTeamDuplicationBirthCityScene();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamQuitReq();
			DataManager<TeamDuplicationDataManager>.GetInstance().ClearData();
			DataManager<ChatManager>.GetInstance().ClearChannelChatData(ChanelType.CHAT_CHANNEL_TEAM_COPY_PREPARE);
			UIEventSystem.GetInstance().SendUIEvent(EUIEventID.RefreshChatData, null, null, null, null);
			ComVoiceTalk.ForceDestroy();
		}

		// Token: 0x06011BFB RID: 72699 RVA: 0x00533114 File Offset: 0x00531514
		private void OnPackageButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationPackageNewFrame();
		}

		// Token: 0x06011BFC RID: 72700 RVA: 0x0053311B File Offset: 0x0053151B
		private void OnSkillButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationSkillFrame();
		}

		// Token: 0x06011BFD RID: 72701 RVA: 0x00533122 File Offset: 0x00531522
		private void OnTeamDuplicationTroopListButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamListFrame();
		}

		// Token: 0x06011BFE RID: 72702 RVA: 0x00533129 File Offset: 0x00531529
		private void OnTeamDuplicationForwardButtonClick()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_troop_not_exist"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			TeamDuplicationUtility.SwitchToTeamDuplicationFightScene();
		}

		// Token: 0x0400B8ED RID: 47341
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B8EE RID: 47342
		[Space(15f)]
		[Header("CommonButton")]
		[Space(5f)]
		[SerializeField]
		private Button backButton;

		// Token: 0x0400B8EF RID: 47343
		[SerializeField]
		private Button skillButton;

		// Token: 0x0400B8F0 RID: 47344
		[SerializeField]
		private Button packageButton;

		// Token: 0x0400B8F1 RID: 47345
		[SerializeField]
		private CommonHelpNewAssistant helpNewAssistant;

		// Token: 0x0400B8F2 RID: 47346
		[Space(15f)]
		[Header("TeamDuplicationButton")]
		[Space(5f)]
		[SerializeField]
		private Button teamDuplicationTroopListButton;

		// Token: 0x0400B8F3 RID: 47347
		[SerializeField]
		private Button teamDuplicationTroopForwardButton;

		// Token: 0x0400B8F4 RID: 47348
		[SerializeField]
		private CommonShopButtonControl shopButtonControl;
	}
}
