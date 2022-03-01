using System;
using Scripts.UI;
using UnityEngine;

namespace GameClient
{
	// Token: 0x02001C3A RID: 7226
	public class TeamDuplicationTeamPanelView : TeamDuplicationTeamCaptainPanelBaseView
	{
		// Token: 0x06011BDF RID: 72671 RVA: 0x00532A3F File Offset: 0x00530E3F
		private void Awake()
		{
			this.BindUiEvents();
		}

		// Token: 0x06011BE0 RID: 72672 RVA: 0x00532A47 File Offset: 0x00530E47
		private void OnDestroy()
		{
			this.UnBindUiEvents();
			this.ClearData();
		}

		// Token: 0x06011BE1 RID: 72673 RVA: 0x00532A58 File Offset: 0x00530E58
		private void BindUiEvents()
		{
			if (this.captainItemList != null)
			{
				this.captainItemList.Initialize();
				ComUIListScriptEx comUIListScriptEx = this.captainItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Combine(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06011BE2 RID: 72674 RVA: 0x00532AA8 File Offset: 0x00530EA8
		private void UnBindUiEvents()
		{
			if (this.captainItemList != null)
			{
				ComUIListScriptEx comUIListScriptEx = this.captainItemList;
				comUIListScriptEx.onItemVisiable = (ComUIListScript.OnItemVisiableDelegate)Delegate.Remove(comUIListScriptEx.onItemVisiable, new ComUIListScript.OnItemVisiableDelegate(this.OnItemVisible));
			}
		}

		// Token: 0x06011BE3 RID: 72675 RVA: 0x00532AE2 File Offset: 0x00530EE2
		private void ClearData()
		{
			this._teamDataModel = null;
			this._isIn65LevelTeamDuplication = false;
		}

		// Token: 0x06011BE4 RID: 72676 RVA: 0x00532AF2 File Offset: 0x00530EF2
		private void OnEnable()
		{
			UIEventSystem.GetInstance().RegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011BE5 RID: 72677 RVA: 0x00532B0F File Offset: 0x00530F0F
		private void OnDisable()
		{
			UIEventSystem.GetInstance().UnRegisterEventHandler(EUIEventID.OnReceiveTeamDuplicationTeamDataMessage, new ClientEventSystem.UIEventHandler(this.OnReceiveTeamDuplicationTeamDataMessage));
		}

		// Token: 0x06011BE6 RID: 72678 RVA: 0x00532B2C File Offset: 0x00530F2C
		public override void Init()
		{
			this._isIn65LevelTeamDuplication = TeamDuplicationUtility.IsIn65LevelTeamDuplication();
			this.UpdateCaptainItemList();
		}

		// Token: 0x06011BE7 RID: 72679 RVA: 0x00532B3F File Offset: 0x00530F3F
		public override void OnEnableView()
		{
			this.UpdateCaptainItemList();
		}

		// Token: 0x06011BE8 RID: 72680 RVA: 0x00532B47 File Offset: 0x00530F47
		private void OnReceiveTeamDuplicationTeamDataMessage(UIEvent uiEvent)
		{
			this.UpdateCaptainItemList();
		}

		// Token: 0x06011BE9 RID: 72681 RVA: 0x00532B50 File Offset: 0x00530F50
		private void UpdateCaptainItemList()
		{
			this._teamDataModel = DataManager<TeamDuplicationDataManager>.GetInstance().GetTeamDuplicationTeamDataModel();
			if (this.captainItemList != null)
			{
				if (this._teamDataModel == null || this._teamDataModel.CaptainDataModelList == null || this._teamDataModel.CaptainDataModelList.Count <= 0)
				{
					this.captainItemList.SetElementAmount(0);
				}
				else
				{
					int elementAmount = this._teamDataModel.CaptainDataModelList.Count;
					if (this._isIn65LevelTeamDuplication)
					{
						elementAmount = DataManager<TeamDuplicationDataManager>.GetInstance().TeamDuplicationCaptainNumberWith65Level;
					}
					this.captainItemList.SetElementAmount(elementAmount);
				}
			}
		}

		// Token: 0x06011BEA RID: 72682 RVA: 0x00532BF4 File Offset: 0x00530FF4
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
			TeamDuplicationTeamCaptainItem component = item.GetComponent<TeamDuplicationTeamCaptainItem>();
			TeamDuplicationCaptainDataModel teamDuplicationCaptainDataModel = this._teamDataModel.CaptainDataModelList[item.m_index];
			if (component != null && teamDuplicationCaptainDataModel != null)
			{
				component.Init(teamDuplicationCaptainDataModel);
			}
		}

		// Token: 0x0400B8EA RID: 47338
		private TeamDuplicationTeamDataModel _teamDataModel;

		// Token: 0x0400B8EB RID: 47339
		private bool _isIn65LevelTeamDuplication;

		// Token: 0x0400B8EC RID: 47340
		[Space(15f)]
		[Header("ComUIListEx")]
		[Space(5f)]
		[SerializeField]
		private ComUIListScriptEx captainItemList;
	}
}
