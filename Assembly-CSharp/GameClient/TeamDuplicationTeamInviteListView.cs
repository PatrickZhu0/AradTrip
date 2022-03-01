using System;
using System.Collections.Generic;
using ProtoTable;
using Scripts.UI;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GameClient
{
	// Token: 0x02001C2E RID: 7214
	public class TeamDuplicationTeamInviteListView : MonoBehaviour
	{
		// Token: 0x06011B28 RID: 72488 RVA: 0x0052F4B4 File Offset: 0x0052D8B4
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011B29 RID: 72489 RVA: 0x0052F4BC File Offset: 0x0052D8BC
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011B2A RID: 72490 RVA: 0x0052F4CA File Offset: 0x0052D8CA
		private void ClearData()
		{
			this._teamInviteDataModelList = null;
		}

		// Token: 0x06011B2B RID: 72491 RVA: 0x0052F4D4 File Offset: 0x0052D8D4
		private void BindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
				this.closeButton.onClick.AddListener(new UnityAction(this.OnCloseButtonClick));
			}
			if (this.refuseAllButton != null)
			{
				this.refuseAllButton.ResetButtonListener();
				this.refuseAllButton.SetButtonListener(new Action(this.OnRefuseAllButtonClick));
			}
			if (this.teamInviteItemList != null)
			{
				this.teamInviteItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.teamInviteItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTeamInviteItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.teamInviteItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Combine(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTeamInviteItemRecycle));
			}
		}

		// Token: 0x06011B2C RID: 72492 RVA: 0x0052F5BC File Offset: 0x0052D9BC
		private void UnBindUiEvents()
		{
			if (this.closeButton != null)
			{
				this.closeButton.onClick.RemoveAllListeners();
			}
			if (this.refuseAllButton != null)
			{
				this.refuseAllButton.ResetButtonListener();
			}
			if (this.teamInviteItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.teamInviteItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnTeamInviteItemVisible));
				ComUIListScriptEx comUIListScriptEx2 = this.teamInviteItemList;
				comUIListScriptEx2.OnItemRecycle = (ComUIListScript.OnItemRecycleDelegate)Delegate.Remove(comUIListScriptEx2.OnItemRecycle, new ComUIListScript.OnItemRecycleDelegate(this.OnTeamInviteItemRecycle));
			}
		}

		// Token: 0x06011B2D RID: 72493 RVA: 0x0052F665 File Offset: 0x0052DA65
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamInviteChoiceMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamInviteListMessage));
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamInviteListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamInviteListMessage));
		}

		// Token: 0x06011B2E RID: 72494 RVA: 0x0052F69D File Offset: 0x0052DA9D
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamInviteChoiceMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamInviteListMessage));
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamInviteListMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamInviteListMessage));
		}

		// Token: 0x06011B2F RID: 72495 RVA: 0x0052F6D5 File Offset: 0x0052DAD5
		public void Init()
		{
			this.InitView();
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyInviteListReq();
		}

		// Token: 0x06011B30 RID: 72496 RVA: 0x0052F6E7 File Offset: 0x0052DAE7
		private void InitView()
		{
			this.InitCommonView();
		}

		// Token: 0x06011B31 RID: 72497 RVA: 0x0052F6F0 File Offset: 0x0052DAF0
		private void InitCommonView()
		{
			if (this.titleText != null)
			{
				this.titleText.text = TR.Value("team_duplication_team_invite_list_title");
			}
			if (this.noTeamInviteTipText != null)
			{
				this.noTeamInviteTipText.text = TR.Value("team_duplication_team_invite_list_zero");
			}
			if (this.teamInviteItemList != null)
			{
				this.teamInviteItemList.SetElementAmount(0);
			}
		}

		// Token: 0x06011B32 RID: 72498 RVA: 0x0052F768 File Offset: 0x0052DB68
		private void OnReceiveTeamDuplicationTeamInviteListMessage(UIEvent uiEvent)
		{
			this._teamInviteDataModelList = DataManager<TeamDuplicationDataManager>.GetInstance().TeamInviteDataModelList;
			int elementAmount = 0;
			if (this._teamInviteDataModelList != null)
			{
				elementAmount = this._teamInviteDataModelList.Count;
			}
			if (this.teamInviteItemList != null)
			{
				this.teamInviteItemList.SetElementAmount(elementAmount);
			}
		}

		// Token: 0x06011B33 RID: 72499 RVA: 0x0052F7BC File Offset: 0x0052DBBC
		private void OnTeamInviteItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.teamInviteItemList == null)
			{
				return;
			}
			if (this._teamInviteDataModelList == null || this._teamInviteDataModelList.Count <= 0)
			{
				return;
			}
			if (item.m_index < 0 || item.m_index >= this._teamInviteDataModelList.Count)
			{
				return;
			}
			TeamDuplicationTeamInviteItem component = item.GetComponent<TeamDuplicationTeamInviteItem>();
			TeamDuplicationTeamInviteDataModel teamDuplicationTeamInviteDataModel = this._teamInviteDataModelList[item.m_index];
			if (component != null && teamDuplicationTeamInviteDataModel != null)
			{
				component.Init(teamDuplicationTeamInviteDataModel);
			}
		}

		// Token: 0x06011B34 RID: 72500 RVA: 0x0052F85C File Offset: 0x0052DC5C
		private void OnTeamInviteItemRecycle(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this.teamInviteItemList == null)
			{
				return;
			}
			TeamDuplicationTeamInviteItem component = item.GetComponent<TeamDuplicationTeamInviteItem>();
			if (component != null)
			{
				component.Reset();
			}
		}

		// Token: 0x06011B35 RID: 72501 RVA: 0x0052F8A4 File Offset: 0x0052DCA4
		private void OnRefuseAllButtonClick()
		{
			if (this._teamInviteDataModelList == null || this._teamInviteDataModelList.Count <= 0)
			{
				return;
			}
			List<uint> list = new List<uint>();
			for (int i = 0; i < this._teamInviteDataModelList.Count; i++)
			{
				TeamDuplicationTeamInviteDataModel teamDuplicationTeamInviteDataModel = this._teamInviteDataModelList[i];
				if (teamDuplicationTeamInviteDataModel != null)
				{
					list.Add(teamDuplicationTeamInviteDataModel.TeamId);
				}
			}
			if (list.Count <= 0)
			{
				SystemNotifyManager.SysNotifyFloatingEffect(TR.Value("team_duplication_team_invite_list_zero"), CommonTipsDesc.eShowMode.SI_QUEUE, 0);
				return;
			}
			DataManager<TeamDuplicationDataManager>.GetInstance().OnSendTeamCopyInviteChoiceReq(false, list);
		}

		// Token: 0x06011B36 RID: 72502 RVA: 0x0052F93E File Offset: 0x0052DD3E
		private void OnCloseButtonClick()
		{
			this.OnCloseFrame();
		}

		// Token: 0x06011B37 RID: 72503 RVA: 0x0052F946 File Offset: 0x0052DD46
		private void OnCloseFrame()
		{
			DataManager<TeamDuplicationDataManager>.GetInstance().ResetTeamDuplicationTeamInviteDataModelList();
			TeamDuplicationUtility.OnCloseTeamDuplicationTeamInviteListFrame();
		}

		// Token: 0x0400B87B RID: 47227
		private List<TeamDuplicationTeamInviteDataModel> _teamInviteDataModelList;

		// Token: 0x0400B87C RID: 47228
		[Space(15f)]
		[Header("top")]
		[Space(10f)]
		[SerializeField]
		private Text titleText;

		// Token: 0x0400B87D RID: 47229
		[SerializeField]
		private Button closeButton;

		// Token: 0x0400B87E RID: 47230
		[Space(15f)]
		[Header("TeamInviteList")]
		[Space(15f)]
		[SerializeField]
		private ComUIListScriptEx teamInviteItemList;

		// Token: 0x0400B87F RID: 47231
		[SerializeField]
		private Text noTeamInviteTipText;

		// Token: 0x0400B880 RID: 47232
		[Space(15f)]
		[Header("Bottom")]
		[Space(15f)]
		[SerializeField]
		private ComButtonWithCd refuseAllButton;
	}
}
