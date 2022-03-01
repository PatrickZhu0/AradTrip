using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C28 RID: 7208
	public class TeamDuplicationMainBuildView : MonoBehaviour
	{
		// Token: 0x06011AE7 RID: 72423 RVA: 0x0052E482 File Offset: 0x0052C882
		private void OnDestroy()
		{
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011AE8 RID: 72424 RVA: 0x0052E48B File Offset: 0x0052C88B
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationBuildTeamSuccessMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationBuildTeamSuccessMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.SceneChangedLoadingFinish, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneChangeLoadingFinish));
		}

		// Token: 0x06011AE9 RID: 72425 RVA: 0x0052E4C3 File Offset: 0x0052C8C3
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationBuildTeamSuccessMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationBuildTeamSuccessMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.SceneChangedLoadingFinish, new ClientEventSystem.UIEventHandler(this.OnReceiveSceneChangeLoadingFinish));
		}

		// Token: 0x06011AEA RID: 72426 RVA: 0x0052E4FB File Offset: 0x0052C8FB
		public void Init()
		{
			this.InitData();
			this.InitView();
		}

		// Token: 0x06011AEB RID: 72427 RVA: 0x0052E509 File Offset: 0x0052C909
		private void InitData()
		{
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
		}

		// Token: 0x06011AEC RID: 72428 RVA: 0x0052E518 File Offset: 0x0052C918
		private void InitView()
		{
			if (this.titleLabel != null)
			{
				if (this._isIn65LevelTeamDuplication)
				{
					this.titleLabel.text = TR.Value("team_duplication_build_title_with_65_level");
				}
				else
				{
					this.titleLabel.text = TR.Value("team_duplication_build_title");
				}
			}
			if (this.buildCommonControl != null)
			{
				this.buildCommonControl.Init(this._isIn65LevelTeamDuplication);
			}
			if (this.headControl != null)
			{
				this.headControl.Init();
			}
			if (this.teamCaptainPanelControl != null)
			{
				this.teamCaptainPanelControl.Init();
			}
		}

		// Token: 0x06011AED RID: 72429 RVA: 0x0052E5CA File Offset: 0x0052C9CA
		private void OnReceiveTeamDuplicationBuildTeamSuccessMessage(UIEvent uiEvent)
		{
			TeamDuplicationUtility.OnCloseRelationFrameByOwnerTeam();
			TeamDuplicationUtility.OnForceCloseRelationFrameInTeamDuplication();
			TeamDuplicationUtility.OnOpenTeamDuplicationTeamRoomFrame(0);
		}

		// Token: 0x06011AEE RID: 72430 RVA: 0x0052E5DC File Offset: 0x0052C9DC
		private void OnReceiveSceneChangeLoadingFinish(UIEvent uiEvent)
		{
			this.OnEnterTeamDuplicationBuildSceneFrameTown();
		}

		// Token: 0x06011AEF RID: 72431 RVA: 0x0052E5E4 File Offset: 0x0052C9E4
		private void OnEnterTeamDuplicationBuildSceneFrameTown()
		{
			if (!DataManager<TeamDuplicationDataManager>.GetInstance().IsEnterTeamDuplicationBuildSceneFromTown)
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().IsEnterTeamDuplicationBuildSceneFromTown = false;
			if (DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyShowTicketIsNotEnoughTip)
			{
				return;
			}
			if (!TeamDuplicationUtility.IsPlayerCanDoTeamDuplication())
			{
				return;
			}
			if (TeamDuplicationUtility.IsPlayerTicketIsEnough())
			{
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().IsAlreadyShowTicketIsNotEnoughTip = true;
			string ticketItemNameOfTeamDuplication = TeamDuplicationUtility.GetTicketItemNameOfTeamDuplication(this._isIn65LevelTeamDuplication);
			string tipContent = TR.Value("team_duplication_less_cost_item_tip", ticketItemNameOfTeamDuplication);
			CommonUtility.OnShowCommonMsgBox(tipContent, new Action(this.OnOpenTeamDuplicationShop), TR.Value("common_data_forward"));
		}

		// Token: 0x06011AF0 RID: 72432 RVA: 0x0052E674 File Offset: 0x0052CA74
		private void OnOpenTeamDuplicationShop()
		{
			int shopId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationShopIdWithNormalLevel;
			if (this._isIn65LevelTeamDuplication)
			{
				shopId = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationShopIdWith65Level;
			}
			DataManager<ShopNewDataManager>.GetInstance().OpenShopNewFrame(shopId, 0, 0, -1);
		}

		// Token: 0x0400B84D RID: 47181
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B84E RID: 47182
		[Space(15f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B84F RID: 47183
		[Space(15f)]
		[Header("Control")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationBuildCommonControl buildCommonControl;

		// Token: 0x0400B850 RID: 47184
		[SerializeField]
		private TeamDuplicationHeadControl headControl;

		// Token: 0x0400B851 RID: 47185
		[SerializeField]
		private TeamDuplicationTeamCaptainPanelControl teamCaptainPanelControl;

		// Token: 0x0400B852 RID: 47186
		[SerializeField]
		private GameObject voiceTalkParent;
	}
}
