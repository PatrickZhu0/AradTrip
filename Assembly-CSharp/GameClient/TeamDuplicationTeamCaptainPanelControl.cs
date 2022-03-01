using System;
using DG.Tweening;
using ProtoTable;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C39 RID: 7225
	public class TeamDuplicationTeamCaptainPanelControl : MonoBehaviour
	{
		// Token: 0x06011BC4 RID: 72644 RVA: 0x005320DE File Offset: 0x005304DE
		private void Awake()
		{
			this.BindEvents();
		}

		// Token: 0x06011BC5 RID: 72645 RVA: 0x005320E6 File Offset: 0x005304E6
		private void OnDestroy()
		{
			this.UnBindEvents();
			this.ClearData();
		}

		// Token: 0x06011BC6 RID: 72646 RVA: 0x005320F4 File Offset: 0x005304F4
		private void BindEvents()
		{
			if (this.noTeamButton != null)
			{
				this.noTeamButton.onClick.RemoveAllListeners();
				this.noTeamButton.onClick.AddListener(new UnityAction(this.OnNoTeamButtonClick));
			}
			if (this.teamBuildButton != null)
			{
				this.teamBuildButton.onClick.RemoveAllListeners();
				this.teamBuildButton.onClick.AddListener(new UnityAction(this.OnTeamBuildButtonClick));
			}
			if (this.teamJoinInButton != null)
			{
				this.teamJoinInButton.onClick.RemoveAllListeners();
				this.teamJoinInButton.onClick.AddListener(new UnityAction(this.OnTeamJoinInButtonClick));
			}
			if (this.teamToggle != null)
			{
				this.teamToggle.onValueChanged.RemoveAllListeners();
				this.teamToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnTeamToggleClick));
			}
			if (this.captainToggle != null)
			{
				this.captainToggle.onValueChanged.RemoveAllListeners();
				this.captainToggle.onValueChanged.AddListener(new UnityAction<bool>(this.OnCaptainToggleClick));
			}
			if (this.panelFadeInButton != null)
			{
				this.panelFadeInButton.onClick.RemoveAllListeners();
				this.panelFadeInButton.onClick.AddListener(new UnityAction(this.OnPanelFadeInButtonClick));
			}
			if (this.panelFadeOutButton != null)
			{
				this.panelFadeOutButton.onClick.RemoveAllListeners();
				this.panelFadeOutButton.onClick.AddListener(new UnityAction(this.OnPanelFadeOutButtonClick));
			}
			if (this.panelFadeInAnimation != null)
			{
				this.panelFadeInAnimation.onComplete.RemoveAllListeners();
				this.panelFadeInAnimation.onComplete.AddListener(new UnityAction(this.PanelFadeInAnimationComplete));
			}
			if (this.panelFadeOutAnimation != null)
			{
				this.panelFadeOutAnimation.onComplete.RemoveAllListeners();
				this.panelFadeOutAnimation.onComplete.AddListener(new UnityAction(this.PanelFadeOutAnimationComplete));
			}
		}

		// Token: 0x06011BC7 RID: 72647 RVA: 0x00532328 File Offset: 0x00530728
		private void UnBindEvents()
		{
			if (this.noTeamButton != null)
			{
				this.noTeamButton.onClick.RemoveAllListeners();
			}
			if (this.teamBuildButton != null)
			{
				this.teamBuildButton.onClick.RemoveAllListeners();
			}
			if (this.teamJoinInButton != null)
			{
				this.teamJoinInButton.onClick.RemoveAllListeners();
			}
			if (this.teamToggle != null)
			{
				this.teamToggle.onValueChanged.RemoveAllListeners();
			}
			if (this.captainToggle != null)
			{
				this.captainToggle.onValueChanged.RemoveAllListeners();
			}
			if (this.panelFadeInButton != null)
			{
				this.panelFadeInButton.onClick.RemoveAllListeners();
			}
			if (this.panelFadeOutButton != null)
			{
				this.panelFadeOutButton.onClick.RemoveAllListeners();
			}
			if (this.panelFadeInAnimation != null)
			{
				this.panelFadeInAnimation.onComplete.RemoveAllListeners();
			}
			if (this.panelFadeOutAnimation != null)
			{
				this.panelFadeOutAnimation.onComplete.RemoveAllListeners();
			}
		}

		// Token: 0x06011BC8 RID: 72648 RVA: 0x00532460 File Offset: 0x00530860
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamQuitMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamQuitMessage));
		}

		// Token: 0x06011BC9 RID: 72649 RVA: 0x005324C0 File Offset: 0x005308C0
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationDismissMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamQuitMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationQuitTeamMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamQuitMessage));
		}

		// Token: 0x06011BCA RID: 72650 RVA: 0x0053251E File Offset: 0x0053091E
		private void ClearData()
		{
			this._isOwnerTeam = false;
		}

		// Token: 0x06011BCB RID: 72651 RVA: 0x00532527 File Offset: 0x00530927
		public void Init()
		{
			this._isOwnerTeam = DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam;
			this.InitCommonInfo();
			this.InitDoTweenAnimation();
			this.SetTeamToggle();
		}

		// Token: 0x06011BCC RID: 72652 RVA: 0x0053254B File Offset: 0x0053094B
		private void SetTeamToggle()
		{
			if (this.teamToggle != null)
			{
				this.teamToggle.isOn = false;
				this.teamToggle.isOn = true;
			}
		}

		// Token: 0x06011BCD RID: 72653 RVA: 0x00532576 File Offset: 0x00530976
		private void InitCommonInfo()
		{
			if (this.noTeamLabel != null)
			{
				this.noTeamLabel.text = TR.Value("team_duplication_build_or_join_troop");
			}
			this.UpdateNoTeamButton();
		}

		// Token: 0x06011BCE RID: 72654 RVA: 0x005325A4 File Offset: 0x005309A4
		private void InitDoTweenAnimation()
		{
			if (this.panelFadeInAnimation != null)
			{
				this.panelFadeInAnimation.id = DoTweenAnimationFadeType.FadeIn.ToString();
			}
			if (this.panelFadeOutAnimation != null)
			{
				this.panelFadeOutAnimation.id = DoTweenAnimationFadeType.FadeOut.ToString();
			}
		}

		// Token: 0x06011BCF RID: 72655 RVA: 0x00532608 File Offset: 0x00530A08
		private void UpdateNoTeamButton()
		{
			if (this.noTeamButton != null)
			{
				if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
				{
					this.noTeamButton.gameObject.CustomActive(true);
				}
				else
				{
					this.noTeamButton.gameObject.CustomActive(false);
				}
			}
		}

		// Token: 0x06011BD0 RID: 72656 RVA: 0x0053265C File Offset: 0x00530A5C
		private void OnTeamToggleClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				CommonUtility.UpdateGameObjectVisible(this.noTeamRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.teamPanelViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.captainPanelViewRoot, false);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.noTeamRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.captainPanelViewRoot, false);
			if (this.teamPanelViewRoot != null && this.teamPanelViewRoot.activeSelf && this.teamPanelView != null)
			{
				TeamDuplicationUtility.OnOpenTeamDuplicationTeamRoomFrame(0);
			}
			else
			{
				this.UpdateTeamPanelView();
			}
		}

		// Token: 0x06011BD1 RID: 72657 RVA: 0x00532700 File Offset: 0x00530B00
		private void OnCaptainToggleClick(bool value)
		{
			if (!value)
			{
				return;
			}
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam)
			{
				CommonUtility.UpdateGameObjectVisible(this.noTeamRoot, true);
				CommonUtility.UpdateGameObjectVisible(this.teamPanelViewRoot, false);
				CommonUtility.UpdateGameObjectVisible(this.captainPanelViewRoot, false);
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_troop_not_exist"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.noTeamRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.teamPanelViewRoot, false);
			this.UpdateCaptainPanelView();
		}

		// Token: 0x06011BD2 RID: 72658 RVA: 0x00532778 File Offset: 0x00530B78
		private void UpdateTeamPanelView()
		{
			if (this.teamPanelViewRoot != null && !this.teamPanelViewRoot.activeSelf)
			{
				this.teamPanelViewRoot.CustomActive(true);
			}
			if (this.teamPanelView == null)
			{
				this.teamPanelView = this.LoadTeamCaptainPanelBaseView(this.teamPanelViewRoot);
				if (this.teamPanelView != null)
				{
					this.teamPanelView.Init();
				}
			}
			else
			{
				this.teamPanelView.OnEnableView();
			}
		}

		// Token: 0x06011BD3 RID: 72659 RVA: 0x00532804 File Offset: 0x00530C04
		private void UpdateCaptainPanelView()
		{
			if (this.captainPanelViewRoot != null && !this.captainPanelViewRoot.activeSelf)
			{
				this.captainPanelViewRoot.CustomActive(true);
			}
			if (this.captainPanelView == null)
			{
				this.captainPanelView = this.LoadTeamCaptainPanelBaseView(this.captainPanelViewRoot);
				if (this.captainPanelView != null)
				{
					this.captainPanelView.Init();
				}
			}
			else
			{
				this.captainPanelView.OnEnableView();
			}
		}

		// Token: 0x06011BD4 RID: 72660 RVA: 0x00532890 File Offset: 0x00530C90
		private TeamDuplicationTeamCaptainPanelBaseView LoadTeamCaptainPanelBaseView(GameObject contentRoot)
		{
			if (contentRoot == null)
			{
				return null;
			}
			TeamDuplicationTeamCaptainPanelBaseView result = null;
			UIPrefabWrapper component = contentRoot.GetComponent<UIPrefabWrapper>();
			if (component != null)
			{
				GameObject gameObject = component.LoadUIPrefab();
				if (gameObject != null)
				{
					gameObject.transform.SetParent(contentRoot.transform, false);
					result = gameObject.GetComponent<TeamDuplicationTeamCaptainPanelBaseView>();
				}
			}
			return result;
		}

		// Token: 0x06011BD5 RID: 72661 RVA: 0x005328ED File Offset: 0x00530CED
		private void OnReceiveTeamDuplicationTeamQuitMessage(UIEvent uiEvent)
		{
			if (!this._isOwnerTeam)
			{
				return;
			}
			this._isOwnerTeam = DataManager<TeamDuplicationDataManager>.GetInstance().IsTeamDuplicationOwnerTeam;
			this.UpdateNoTeamButton();
			this.SetTeamToggle();
		}

		// Token: 0x06011BD6 RID: 72662 RVA: 0x00532917 File Offset: 0x00530D17
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			if (this._isOwnerTeam)
			{
				return;
			}
			this._isOwnerTeam = true;
			this.UpdateNoTeamButton();
			CommonUtility.UpdateGameObjectVisible(this.noTeamRoot, false);
			CommonUtility.UpdateGameObjectVisible(this.captainPanelViewRoot, false);
			this.UpdateTeamPanelView();
		}

		// Token: 0x06011BD7 RID: 72663 RVA: 0x00532950 File Offset: 0x00530D50
		private void OnNoTeamButtonClick()
		{
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_troop_not_exist"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
		}

		// Token: 0x06011BD8 RID: 72664 RVA: 0x00532963 File Offset: 0x00530D63
		private void OnTeamJoinInButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamListFrame();
		}

		// Token: 0x06011BD9 RID: 72665 RVA: 0x0053296A File Offset: 0x00530D6A
		private void OnTeamBuildButtonClick()
		{
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamBuildFrame();
		}

		// Token: 0x06011BDA RID: 72666 RVA: 0x00532974 File Offset: 0x00530D74
		private void OnPanelFadeOutButtonClick()
		{
			if (this.panelFadeInAnimation == null || this.panelFadeOutAnimation == null)
			{
				return;
			}
			this.panelFadeOutAnimation.CreateTween();
			this.panelFadeOutAnimation.DOPlay();
			CommonUtility.UpdateButtonVisible(this.panelFadeInButton, true);
			CommonUtility.UpdateButtonState(this.panelFadeOutButton, null, false);
		}

		// Token: 0x06011BDB RID: 72667 RVA: 0x005329D4 File Offset: 0x00530DD4
		private void OnPanelFadeInButtonClick()
		{
			if (this.panelFadeInAnimation == null || this.panelFadeOutAnimation == null)
			{
				return;
			}
			this.panelFadeInAnimation.CreateTween();
			this.panelFadeInAnimation.DOPlay();
			CommonUtility.UpdateButtonVisible(this.panelFadeInButton, false);
			CommonUtility.UpdateButtonState(this.panelFadeOutButton, null, true);
		}

		// Token: 0x06011BDC RID: 72668 RVA: 0x00532A33 File Offset: 0x00530E33
		private void PanelFadeInAnimationComplete()
		{
		}

		// Token: 0x06011BDD RID: 72669 RVA: 0x00532A35 File Offset: 0x00530E35
		private void PanelFadeOutAnimationComplete()
		{
		}

		// Token: 0x0400B8DA RID: 47322
		private TeamDuplicationTeamCaptainPanelBaseView teamPanelView;

		// Token: 0x0400B8DB RID: 47323
		private TeamDuplicationTeamCaptainPanelBaseView captainPanelView;

		// Token: 0x0400B8DC RID: 47324
		private bool _isOwnerTeam;

		// Token: 0x0400B8DD RID: 47325
		[Space(15f)]
		[Header("troopTabs")]
		[Space(5f)]
		[SerializeField]
		private Toggle teamToggle;

		// Token: 0x0400B8DE RID: 47326
		[SerializeField]
		private Toggle captainToggle;

		// Token: 0x0400B8DF RID: 47327
		[SerializeField]
		private Button noTeamButton;

		// Token: 0x0400B8E0 RID: 47328
		[Space(15f)]
		[Header("Common")]
		[Space(5f)]
		[SerializeField]
		private Button teamBuildButton;

		// Token: 0x0400B8E1 RID: 47329
		[SerializeField]
		private Button teamJoinInButton;

		// Token: 0x0400B8E2 RID: 47330
		[SerializeField]
		private Text noTeamLabel;

		// Token: 0x0400B8E3 RID: 47331
		[SerializeField]
		private GameObject noTeamRoot;

		// Token: 0x0400B8E4 RID: 47332
		[Space(15f)]
		[Header("Control")]
		[Space(5f)]
		[SerializeField]
		private GameObject teamPanelViewRoot;

		// Token: 0x0400B8E5 RID: 47333
		[SerializeField]
		private GameObject captainPanelViewRoot;

		// Token: 0x0400B8E6 RID: 47334
		[Space(25f)]
		[Header("FadeOutAnimation")]
		[Space(10f)]
		[SerializeField]
		private Button panelFadeOutButton;

		// Token: 0x0400B8E7 RID: 47335
		[SerializeField]
		private DOTweenAnimation panelFadeOutAnimation;

		// Token: 0x0400B8E8 RID: 47336
		[Space(25f)]
		[Header("FadeInAnimation")]
		[Space(10f)]
		[SerializeField]
		private Button panelFadeInButton;

		// Token: 0x0400B8E9 RID: 47337
		[SerializeField]
		private DOTweenAnimation panelFadeInAnimation;
	}
}
