using System;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C37 RID: 7223
	public class TeamDuplicationCaptainPanelView : TeamDuplicationTeamCaptainPanelBaseView
	{
		// Token: 0x06011BB4 RID: 72628 RVA: 0x00531EA6 File Offset: 0x005302A6
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011BB5 RID: 72629 RVA: 0x00531EAE File Offset: 0x005302AE
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011BB6 RID: 72630 RVA: 0x00531EBC File Offset: 0x005302BC
		private void BindUiEvents()
		{
			if (this.playerItemList != null)
			{
				this.playerItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.playerItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06011BB7 RID: 72631 RVA: 0x00531F0C File Offset: 0x0053030C
		private void UnBindUiEvents()
		{
			if (this.playerItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.playerItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06011BB8 RID: 72632 RVA: 0x00531F46 File Offset: 0x00530346
		private void ClearData()
		{
			this._playerDataModel = null;
		}

		// Token: 0x06011BB9 RID: 72633 RVA: 0x00531F4F File Offset: 0x0053034F
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011BBA RID: 72634 RVA: 0x00531F6C File Offset: 0x0053036C
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011BBB RID: 72635 RVA: 0x00531F89 File Offset: 0x00530389
		public override void Init()
		{
			this.UpdateTroopList();
		}

		// Token: 0x06011BBC RID: 72636 RVA: 0x00531F91 File Offset: 0x00530391
		public override void OnEnableView()
		{
			this.UpdateTroopList();
		}

		// Token: 0x06011BBD RID: 72637 RVA: 0x00531F99 File Offset: 0x00530399
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			this.UpdateTroopList();
		}

		// Token: 0x06011BBE RID: 72638 RVA: 0x00531FA4 File Offset: 0x005303A4
		private void UpdateTroopList()
		{
			this._playerDataModel = TeamDuplicationUtility.GetTeamDuplicationCaptainDataModelByPlayerGuid(DataManager<PlayerBaseData>.GetInstance().RoleID);
			if (this.playerItemList != null)
			{
				if (this._playerDataModel != null)
				{
					if (this._playerDataModel.PlayerList == null || this._playerDataModel.PlayerList.Count <= 0)
					{
						this.playerItemList.SetElementAmount(0);
					}
					else
					{
						this.playerItemList.SetElementAmount(this._playerDataModel.PlayerList.Count);
					}
				}
				else
				{
					this.playerItemList.SetElementAmount(0);
				}
			}
		}

		// Token: 0x06011BBF RID: 72639 RVA: 0x00532048 File Offset: 0x00530448
		private void OnItemVisible(ComUIListElementScript item)
		{
			if (item == null)
			{
				return;
			}
			if (this._playerDataModel.PlayerList == null || this._playerDataModel.PlayerList.Count <= 0)
			{
				return;
			}
			if (item.m_index >= this._playerDataModel.PlayerList.Count)
			{
				return;
			}
			TeamDuplicationCaptainPlayerItem component = item.GetComponent<TeamDuplicationCaptainPlayerItem>();
			TeamDuplicationPlayerDataModel playerDataModel = this._playerDataModel.PlayerList[item.m_index];
			if (component != null)
			{
				component.Init(playerDataModel);
			}
		}

		// Token: 0x0400B8D8 RID: 47320
		private TeamDuplicationCaptainDataModel _playerDataModel;

		// Token: 0x0400B8D9 RID: 47321
		[Space(15f)]
		[Header("ComUIList")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScriptEx playerItemList;
	}
}
