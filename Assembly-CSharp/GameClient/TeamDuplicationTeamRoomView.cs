using System;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C34 RID: 7220
	public class TeamDuplicationTeamRoomView : MonoBehaviour
	{
		// Token: 0x06011B89 RID: 72585 RVA: 0x005310B5 File Offset: 0x0052F4B5
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011B8A RID: 72586 RVA: 0x005310BD File Offset: 0x0052F4BD
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011B8B RID: 72587 RVA: 0x005310CB File Offset: 0x0052F4CB
		private void ClearData()
		{
			this._ownerPlayerDataModel = null;
			this._teamDataModel = null;
			this._isOtherTeamDetailFlag = false;
			this._otherTeamDetailId = 0;
			CommonNewDragUtility.ResetFirstDragPointerId();
		}

		// Token: 0x06011B8C RID: 72588 RVA: 0x005310F0 File Offset: 0x0052F4F0
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.teamRoomList != null)
			{
				this.teamRoomList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.teamRoomList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06011B8D RID: 72589 RVA: 0x00531180 File Offset: 0x0052F580
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.teamRoomList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.teamRoomList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06011B8E RID: 72590 RVA: 0x005311E6 File Offset: 0x0052F5E6
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDetailDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDetailDataMessage));
		}

		// Token: 0x06011B8F RID: 72591 RVA: 0x0053121E File Offset: 0x0052F61E
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDetailDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDetailDataMessage));
		}

		// Token: 0x06011B90 RID: 72592 RVA: 0x00531258 File Offset: 0x0052F658
		public void Init(int teamId = 0)
		{
			this._otherTeamDetailId = teamId;
			if (this._otherTeamDetailId == 0)
			{
				this._isOtherTeamDetailFlag = false;
			}
			else
			{
				this._isOtherTeamDetailFlag = true;
			}
			if (!this._isOtherTeamDetailFlag)
			{
				this._teamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
				if (this._teamDataModel == null)
				{
					return;
				}
				this._ownerPlayerDataModel = TeamDuplicationUtility.GetOwnerPlayerDataModel();
				if (this._ownerPlayerDataModel == null || this._ownerPlayerDataModel.Guid == 0UL)
				{
					return;
				}
				this.InitView();
			}
			else
			{
				this.UpdateOwnerGoldRoot(false);
				this.UpdateBottomControl();
				DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamDetailReq(this._otherTeamDetailId);
			}
			CommonNewDragUtility.ResetFirstDragPointerId();
		}

		// Token: 0x06011B91 RID: 72593 RVA: 0x00531307 File Offset: 0x0052F707
		private void InitView()
		{
			this.UpdateTeamRoomTitle();
			this.UpdateGoldValue();
			this.UpdateTroopRoomList();
			this.UpdateBottomControl();
		}

		// Token: 0x06011B92 RID: 72594 RVA: 0x00531324 File Offset: 0x0052F724
		private void UpdateTeamRoomTitle()
		{
			if (this.titleLabel == null)
			{
				return;
			}
			if (this._teamDataModel == null)
			{
				return;
			}
			if (!string.IsNullOrEmpty(this._teamDataModel.TeamName))
			{
				this.titleLabel.text = string.Format(TR.Value("team_duplication_team_name_format"), this._teamDataModel.TeamName);
			}
		}

		// Token: 0x06011B93 RID: 72595 RVA: 0x0053138C File Offset: 0x0052F78C
		private void UpdateBottomControl()
		{
			if (this.teamRoomBottomControl == null)
			{
				return;
			}
			if (this._isOtherTeamDetailFlag)
			{
				this.teamRoomBottomControl.Init(false, this._isOtherTeamDetailFlag, this._otherTeamDetailId);
			}
			else
			{
				bool isTeamLeader = this._ownerPlayerDataModel.IsTeamLeader;
				this.teamRoomBottomControl.Init(isTeamLeader, this._isOtherTeamDetailFlag, 0);
			}
		}

		// Token: 0x06011B94 RID: 72596 RVA: 0x005313F5 File Offset: 0x0052F7F5
		private void UpdateOwnerGoldRoot(bool flag)
		{
			CommonUtility.UpdateGameObjectVisible(this.ownerGoldRoot, flag);
		}

		// Token: 0x06011B95 RID: 72597 RVA: 0x00531404 File Offset: 0x0052F804
		private void UpdateGoldValue()
		{
			if (this._teamDataModel == null)
			{
				return;
			}
			if (this._teamDataModel.TeamModel == 1)
			{
				return;
			}
			CommonUtility.UpdateGameObjectVisible(this.totalGoldRoot, true);
			CommonUtility.UpdateGameObjectVisible(this.helpRoot, true);
			if (this.totalGoldValueText != null)
			{
				int totalCommission = this._teamDataModel.TotalCommission;
				this.totalGoldValueText.text = totalCommission.ToString();
			}
			if (this._isOtherTeamDetailFlag)
			{
				this.UpdateOwnerGoldRoot(false);
			}
			else if (this._ownerPlayerDataModel.IsGoldOwner)
			{
				this.UpdateOwnerGoldRoot(false);
			}
			else
			{
				if (this.ownerGoldValueText != null)
				{
					int bonusCommission = this._teamDataModel.BonusCommission;
					this.ownerGoldValueText.text = bonusCommission.ToString();
				}
				this.UpdateOwnerGoldRoot(true);
			}
		}

		// Token: 0x06011B96 RID: 72598 RVA: 0x005314EC File Offset: 0x0052F8EC
		private void UpdateTroopRoomList()
		{
			int elementAmount = 0;
			if (this._teamDataModel != null && this._teamDataModel.CaptainDataModelList != null && this._teamDataModel.CaptainDataModelList.Count > 0)
			{
				elementAmount = this._teamDataModel.CaptainDataModelList.Count;
			}
			if (this.teamRoomList != null)
			{
				this.teamRoomList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x06011B97 RID: 72599 RVA: 0x0053155C File Offset: 0x0052F95C
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._teamDataModel == null || this._teamDataModel.CaptainDataModelList == null || this._teamDataModel.CaptainDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._teamDataModel.CaptainDataModelList.Count)
			{
				return;
			}
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = this._teamDataModel.CaptainDataModelList[item.m_index];
			TeamDuplicationTeamRoomItem component = item.GetComponent<TeamDuplicationTeamRoomItem>();
			if (component != null && teamDuplicationCaptainDataModel != null)
			{
				component.Init(teamDuplicationCaptainDataModel, this._isOtherTeamDetailFlag, this._teamDataModel.TeamType);
			}
		}

		// Token: 0x06011B98 RID: 72600 RVA: 0x0053160C File Offset: 0x0052FA0C
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			if (this._isOtherTeamDetailFlag)
			{
				return;
			}
			this._teamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (this._teamDataModel == null)
			{
				return;
			}
			this._ownerPlayerDataModel = TeamDuplicationUtility.GetOwnerPlayerDataModel();
			if (this._ownerPlayerDataModel == null || this._ownerPlayerDataModel.Guid == 0UL)
			{
				return;
			}
			this.UpdateTeamRoomTitle();
			this.UpdateGoldValue();
			this.UpdateTroopRoomList();
			this.UpdateBottomControl();
		}

		// Token: 0x06011B99 RID: 72601 RVA: 0x00531684 File Offset: 0x0052FA84
		private void OnReceiveTeamDuplicationTeamDetailDataMessage(UIEvent uiEvent)
		{
			if (!this._isOtherTeamDetailFlag)
			{
				return;
			}
			int num = (int)uiEvent.Param1;
			if (num != this._otherTeamDetailId)
			{
				return;
			}
			this._teamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().OtherTeamDataModel;
			this.UpdateTeamRoomTitle();
			this.UpdateGoldValue();
			this.UpdateTroopRoomList();
		}

		// Token: 0x06011B9A RID: 72602 RVA: 0x005316D8 File Offset: 0x0052FAD8
		private void OnCloseButtonClick()
		{
			if (this._isOtherTeamDetailFlag)
			{
				DataManager<TeamDuplicationDataManager>.GetInstance().ResetOtherTeamDataModel();
			}
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamRoomFrame();
		}

		// Token: 0x0400B8B2 RID: 47282
		private int _otherTeamDetailId;

		// Token: 0x0400B8B3 RID: 47283
		private bool _isOtherTeamDetailFlag;

		// Token: 0x0400B8B4 RID: 47284
		private TeamDuplicationPlayerDataModel _ownerPlayerDataModel;

		// Token: 0x0400B8B5 RID: 47285
		private TeamDuplicationTeamDataModel _teamDataModel;

		// Token: 0x0400B8B6 RID: 47286
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B8B7 RID: 47287
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B8B8 RID: 47288
		[Space(15f)]
		[Header("Gold")]
		[Space(10f)]
		[SerializeField]
		private GameObject totalGoldRoot;

		// Token: 0x0400B8B9 RID: 47289
		[SerializeField]
		private Text totalGoldValueText;

		// Token: 0x0400B8BA RID: 47290
		[SerializeField]
		private GameObject ownerGoldRoot;

		// Token: 0x0400B8BB RID: 47291
		[SerializeField]
		private Text ownerGoldValueText;

		// Token: 0x0400B8BC RID: 47292
		[SerializeField]
		private GameObject helpRoot;

		// Token: 0x0400B8BD RID: 47293
		[Space(15f)]
		[Header("BottomButton")]
		[Space(10f)]
		[SerializeField]
		private TeamDuplicationTeamRoomBottomControl teamRoomBottomControl;

		// Token: 0x0400B8BE RID: 47294
		[Space(15f)]
		[Header("TroopRoomList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx teamRoomList;
	}
}
