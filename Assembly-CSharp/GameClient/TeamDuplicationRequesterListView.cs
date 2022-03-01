using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C2A RID: 7210
	public class TeamDuplicationRequesterListView : MonoBehaviour
	{
		// Token: 0x06011AF7 RID: 72439 RVA: 0x0052E70C File Offset: 0x0052CB0C
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011AF8 RID: 72440 RVA: 0x0052E714 File Offset: 0x0052CB14
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011AF9 RID: 72441 RVA: 0x0052E722 File Offset: 0x0052CB22
		private void ClearData()
		{
			this._requesterDataModelList = null;
		}

		// Token: 0x06011AFA RID: 72442 RVA: 0x0052E72C File Offset: 0x0052CB2C
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.refuseAllButton != null)
			{
				this.refuseAllButton.onClick.RemoveAllListeners();
				this.refuseAllButton.onClick.AddListener(new UnityAction(this.OnRefuseAllButtonClick));
			}
			if (this.agreeAllButton != null)
			{
				this.agreeAllButton.onClick.RemoveAllListeners();
				this.agreeAllButton.onClick.AddListener(new UnityAction(this.OnAgreeAllButtonClick));
			}
			if (this.refreshButton != null)
			{
				this.refreshButton.ResetListener();
				this.refreshButton.SetButtonListener(new Action(this.OnRefreshButtonClick));
				this.refreshButton.SetCountDownTimeDescription(TR.Value("team_duplication_count_down_time_refresh_content"), TR.Value("team_duplication_count_down_time_refresh_format"));
			}
			if (this.requesterItemList != null)
			{
				this.requesterItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.requesterItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.requesterItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x06011AFB RID: 72443 RVA: 0x0052E8AC File Offset: 0x0052CCAC
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.refuseAllButton != null)
			{
				this.refuseAllButton.onClick.RemoveAllListeners();
			}
			if (this.agreeAllButton != null)
			{
				this.agreeAllButton.onClick.RemoveAllListeners();
			}
			if (this.refreshButton != null)
			{
				this.refreshButton.ResetButtonListener();
			}
			if (this.requesterItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.requesterItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.requesterItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnItemRecycle));
			}
		}

		// Token: 0x06011AFC RID: 72444 RVA: 0x0052E997 File Offset: 0x0052CD97
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationRequesterListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationRequesterListMessage));
		}

		// Token: 0x06011AFD RID: 72445 RVA: 0x0052E9B4 File Offset: 0x0052CDB4
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationRequesterListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationRequesterListMessage));
		}

		// Token: 0x06011AFE RID: 72446 RVA: 0x0052E9D1 File Offset: 0x0052CDD1
		public void Init()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyListReq();
			this.InitView();
		}

		// Token: 0x06011AFF RID: 72447 RVA: 0x0052E9E3 File Offset: 0x0052CDE3
		private void InitView()
		{
			this.InitCommonView();
		}

		// Token: 0x06011B00 RID: 72448 RVA: 0x0052E9EC File Offset: 0x0052CDEC
		private void InitCommonView()
		{
			if (this.titleLabel != null)
			{
				this.titleLabel.text = TR.Value("team_duplication_troop_request_list_title");
			}
			if (this.refreshButtonText != null)
			{
				this.refreshButtonText.text = TR.Value("team_duplication_count_down_time_refresh_content");
			}
		}

		// Token: 0x06011B01 RID: 72449 RVA: 0x0052EA45 File Offset: 0x0052CE45
		private void OnReceiveTeamDuplicationRequesterListMessage(UIEvent uiEvent)
		{
			this._requesterDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().GetRequesterDataModelList();
			this.UpdateFriendList();
		}

		// Token: 0x06011B02 RID: 72450 RVA: 0x0052EA60 File Offset: 0x0052CE60
		private void UpdateFriendList()
		{
			if (this.requesterItemList == null)
			{
				return;
			}
			this.requesterItemList.ResetComUiListScriptEx();
			int elementAmount;
			if (this._requesterDataModelList == null || this._requesterDataModelList.Count <= 0)
			{
				elementAmount = 0;
			}
			else
			{
				elementAmount = this._requesterDataModelList.Count;
			}
			this.requesterItemList.SetElementAmount(elementAmount);
		}

		// Token: 0x06011B03 RID: 72451 RVA: 0x0052EAC8 File Offset: 0x0052CEC8
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.requesterItemList == null)
			{
				return;
			}
			if (this._requesterDataModelList == null || this._requesterDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._requesterDataModelList.Count)
			{
				return;
			}
			TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = this._requesterDataModelList[item.m_index];
			TeamDuplicationTeamRequesterItem component = item.GetComponent<TeamDuplicationTeamRequesterItem>();
			if (teamDuplicationRequesterDataModel != null && component != null)
			{
				component.Init(teamDuplicationRequesterDataModel, true);
			}
		}

		// Token: 0x06011B04 RID: 72452 RVA: 0x0052EB5C File Offset: 0x0052CF5C
		private void OnItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.requesterItemList == null)
			{
				return;
			}
			TeamDuplicationTeamRequesterItem component = item.GetComponent<TeamDuplicationTeamRequesterItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x06011B05 RID: 72453 RVA: 0x0052EBA1 File Offset: 0x0052CFA1
		private void OnRefreshButtonClick()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyListReq();
		}

		// Token: 0x06011B06 RID: 72454 RVA: 0x0052EBB0 File Offset: 0x0052CFB0
		private void OnRefuseAllButtonClick()
		{
			if (this._requesterDataModelList == null || this._requesterDataModelList.Count <= 0)
			{
				return;
			}
			List<ulong> allRequesterGuid = this.GetAllRequesterGuid();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyReplyReq(false, allRequesterGuid);
		}

		// Token: 0x06011B07 RID: 72455 RVA: 0x0052EBF0 File Offset: 0x0052CFF0
		private void OnAgreeAllButtonClick()
		{
			if (TeamDuplicationUtility.IsTeamTroopIsFull())
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_troop_is_full"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			if (this._requesterDataModelList == null || this._requesterDataModelList.Count <= 0)
			{
				return;
			}
			List<ulong> allRequesterGuid = this.GetAllRequesterGuid();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyTeamApplyReplyReq(true, allRequesterGuid);
		}

		// Token: 0x06011B08 RID: 72456 RVA: 0x0052EC49 File Offset: 0x0052D049
		private void OnCloseButtonClick()
		{
			TeamDuplicationUtility.OnCloseTeamDuplicationRequesterListFrame();
		}

		// Token: 0x06011B09 RID: 72457 RVA: 0x0052EC50 File Offset: 0x0052D050
		private List<ulong> GetAllRequesterGuid()
		{
			List<ulong> list = new List<ulong>();
			for (int i = 0; i < this._requesterDataModelList.Count; i++)
			{
				TeamDuplicationRequesterDataModel teamDuplicationRequesterDataModel = this._requesterDataModelList[i];
				if (teamDuplicationRequesterDataModel != null)
				{
					list.Add(teamDuplicationRequesterDataModel.PlayerGuid);
				}
			}
			return list;
		}

		// Token: 0x0400B854 RID: 47188
		private List<TeamDuplicationRequesterDataModel> _requesterDataModelList;

		// Token: 0x0400B855 RID: 47189
		[Space(15f)]
		[Header("Common")]
		[Space(10f)]
		[SerializeField]
		private Text titleLabel;

		// Token: 0x0400B856 RID: 47190
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B857 RID: 47191
		[Space(15f)]
		[Header("Button")]
		[Space(10f)]
		[SerializeField]
		private Button refuseAllButton;

		// Token: 0x0400B858 RID: 47192
		[SerializeField]
		private Button agreeAllButton;

		// Token: 0x0400B859 RID: 47193
		[SerializeField]
		private ComButtonWithCd refreshButton;

		// Token: 0x0400B85A RID: 47194
		[SerializeField]
		private Text refreshButtonText;

		// Token: 0x0400B85B RID: 47195
		[Space(15f)]
		[Header("ComUIListScript")]
		[Space(10f)]
		[SerializeField]
		private ComUIListScriptEx requesterItemList;
	}
}
