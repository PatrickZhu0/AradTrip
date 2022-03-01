using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C26 RID: 7206
	public class TeamDuplicationFindTeamMateView : MonoBehaviour
	{
		// Token: 0x06011ACB RID: 72395 RVA: 0x0052DD54 File Offset: 0x0052C154
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011ACC RID: 72396 RVA: 0x0052DD5C File Offset: 0x0052C15C
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011ACD RID: 72397 RVA: 0x0052DD6A File Offset: 0x0052C16A
		private void ClearData()
		{
			this._teamMateDataModelList = null;
		}

		// Token: 0x06011ACE RID: 72398 RVA: 0x0052DD74 File Offset: 0x0052C174
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.inviteAllButton != null)
			{
				this.inviteAllButton.ResetListener();
				this.inviteAllButton.SetButtonListener(new Action(this.OnInviteAllButtonClick));
			}
			if (this.recruitSendButton != null)
			{
				this.recruitSendButton.ResetListener();
				this.recruitSendButton.SetButtonListener(new Action(this.OnRecruitSendButtonClick));
			}
			if (this.changeTeamMateButton != null)
			{
				this.changeTeamMateButton.ResetListener();
				this.changeTeamMateButton.SetButtonListener(new Action(this.OnChangeTeamMateButtonClick));
				this.changeTeamMateButton.SetCountDownTimeDescription(TR.Value("team_duplication_change_teamMate_count_down_format_content"), TR.Value("team_duplication_change_teamMate_count_down_refresh_content"));
			}
			if (this.teamMateItemList != null)
			{
				this.teamMateItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.teamMateItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.teamMateItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
				ComUIListScriptEx comUIListScriptEx3 = this.teamMateItemList;
				comUIListScriptEx3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Combine(comUIListScriptEx3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
		}

		// Token: 0x06011ACF RID: 72399 RVA: 0x0052DF08 File Offset: 0x0052C308
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.inviteAllButton != null)
			{
				this.inviteAllButton.ResetListener();
			}
			if (this.recruitSendButton != null)
			{
				this.recruitSendButton.ResetListener();
			}
			if (this.changeTeamMateButton != null)
			{
				this.changeTeamMateButton.ResetButtonListener();
			}
			if (this.teamMateItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.teamMateItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.teamMateItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
				ComUIListScriptEx comUIListScriptEx3 = this.teamMateItemList;
				comUIListScriptEx3.OnItemUpdate = (ComUIListScript.OnItemUpdateDelegate)Delegate.Remove(comUIListScriptEx3.OnItemUpdate, new ComUIListScript.OnItemUpdateDelegate(this.OnItemUpdate));
			}
		}

		// Token: 0x06011AD0 RID: 72400 RVA: 0x0052E010 File Offset: 0x0052C410
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamMateListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamMateMessage));
		}

		// Token: 0x06011AD1 RID: 72401 RVA: 0x0052E02D File Offset: 0x0052C42D
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamMateListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamMateMessage));
		}

		// Token: 0x06011AD2 RID: 72402 RVA: 0x0052E04A File Offset: 0x0052C44A
		public void Init()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyFindTeamMateReq();
			this.InitView();
		}

		// Token: 0x06011AD3 RID: 72403 RVA: 0x0052E05C File Offset: 0x0052C45C
		private void InitView()
		{
			this.InitCommonView();
		}

		// Token: 0x06011AD4 RID: 72404 RVA: 0x0052E064 File Offset: 0x0052C464
		private void InitCommonView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("team_duplication_troop_find_player_title");
			}
		}

		// Token: 0x06011AD5 RID: 72405 RVA: 0x0052E08C File Offset: 0x0052C48C
		private void OnReceiveTeamDuplicationTeamMateMessage(UIEvent uiEvent)
		{
			this._teamMateDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamFriendDataModelList();
			this.UpdateTeamMateList();
		}

		// Token: 0x06011AD6 RID: 72406 RVA: 0x0052E0A4 File Offset: 0x0052C4A4
		private void UpdateTeamMateList()
		{
			if (this.teamMateItemList == null)
			{
				return;
			}
			this.teamMateItemList.ResetComUiListScriptEx();
			int elementAmount;
			if (this._teamMateDataModelList == null || this._teamMateDataModelList.Count <= 0)
			{
				elementAmount = 0;
			}
			else
			{
				elementAmount = this._teamMateDataModelList.Count;
			}
			this.teamMateItemList.SetElementAmount(elementAmount);
		}

		// Token: 0x06011AD7 RID: 72407 RVA: 0x0052E10C File Offset: 0x0052C50C
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.teamMateItemList == null)
			{
				return;
			}
			if (this._teamMateDataModelList == null || this._teamMateDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._teamMateDataModelList.Count)
			{
				return;
			}
			TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = this._teamMateDataModelList[item.m_index];
			TeamDuplicationTeamRequesterItem component = item.GetComponent<TeamDuplicationTeamRequesterItem>();
			if (teamDuplicationRequesterDataModel != null && component != null)
			{
				component.Init(teamDuplicationRequesterDataModel, false);
			}
		}

		// Token: 0x06011AD8 RID: 72408 RVA: 0x0052E1A0 File Offset: 0x0052C5A0
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.teamMateItemList == null)
			{
				return;
			}
			TeamDuplicationTeamRequesterItem component = item.GetComponent<TeamDuplicationTeamRequesterItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x06011AD9 RID: 72409 RVA: 0x0052E1E8 File Offset: 0x0052C5E8
		private void OnItemUpdate(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.teamMateItemList == null)
			{
				return;
			}
			if (this._teamMateDataModelList == null || this._teamMateDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._teamMateDataModelList.Count)
			{
				return;
			}
			TeamDuplicationTeamRequesterItem component = item.GetComponent<TeamDuplicationTeamRequesterItem>();
			if (component != null)
			{
				component.OnInviteButtonUpdate();
			}
		}

		// Token: 0x06011ADA RID: 72410 RVA: 0x0052E264 File Offset: 0x0052C664
		private void OnInviteAllButtonClick()
		{
			if (this._teamMateDataModelList == null || this._teamMateDataModelList.Count <= 0)
			{
				return;
			}
			SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_troop_invite_friend"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
			List<ulong> allTeamMateGuid = this.GetAllTeamMateGuid();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyInvitePlayer(allTeamMateGuid);
			if (this.teamMateItemList != null)
			{
				this.teamMateItemList.UpdateElement();
			}
		}

		// Token: 0x06011ADB RID: 72411 RVA: 0x0052E2CD File Offset: 0x0052C6CD
		private void OnRecruitSendButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamRecruitReq();
		}

		// Token: 0x06011ADC RID: 72412 RVA: 0x0052E2D9 File Offset: 0x0052C6D9
		private void OnChangeTeamMateButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyFindTeamMateReq();
		}

		// Token: 0x06011ADD RID: 72413 RVA: 0x0052E2E5 File Offset: 0x0052C6E5
		private void OnCloseButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationFindTeamMateFrame();
		}

		// Token: 0x06011ADE RID: 72414 RVA: 0x0052E2EC File Offset: 0x0052C6EC
		private List<ulong> GetAllTeamMateGuid()
		{
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < this._teamMateDataModelList.Count; i++)
			{
				TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = this._teamMateDataModelList[i];
				if (teamDuplicationRequesterDataModel != null)
				{
					list.Add(teamDuplicationRequesterDataModel.PlayerGuid);
				}
			}
			return list;
		}

		// Token: 0x0400B841 RID: 47169
		private List<TeamDuplicationRequesterDataModel> _teamMateDataModelList;

		// Token: 0x0400B842 RID: 47170
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B843 RID: 47171
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B844 RID: 47172
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private ComButtonWithCd inviteAllButton;

		// Token: 0x0400B845 RID: 47173
		[SerializeField]
		private ComButtonWithCd recruitSendButton;

		// Token: 0x0400B846 RID: 47174
		[SerializeField]
		private ComButtonWithCd changeTeamMateButton;

		// Token: 0x0400B847 RID: 47175
		[Space(15f)]
		[Header("TeamMateItemList")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx teamMateItemList;
	}
}
